Option Explicit On 

Imports System.Windows.Forms

Namespace Buisness
    Public Class SonitrolReceiving

        Private _objDataProc As DBQuery.DataProc

        '**************************************************************
        Public Sub New()
            Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
        End Sub

        '**************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '***************************************************
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '**************************************************************
        Public Function GetSonitrolModels() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Model_ID, Model_Desc FROM tmodel " & Environment.NewLine
                strSql &= "WHERE Prod_ID = 7 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetPOs(ByVal _iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT distinct tpurchaseorder.* FROM tpurchaseorder " & Environment.NewLine
                strSql &= "where loc_id =  " & _iLoc_ID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetWorkorderInfo(ByVal strWorkOrderName As String, _
                                         ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & Environment.NewLine
                strSql &= "AND WO_CustWO = '" & strWorkOrderName & "' " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function CheckPSSWarranty(ByVal iLoc_ID As Integer, _
                                         ByVal strDevSN As String) As Integer
            Dim strSeverDt As String = ""
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iResult As Integer = 0

            Try
                strSeverDt = Generic.MySQLServerDateTime(1)

                strSql = "SELECT * FROM tdevice " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_SN = '" & strDevSN & "' " & Environment.NewLine
                strSql &= "AND tdevice.Device_DateShip is not null " & Environment.NewLine
                strSql &= "AND Loc_ID = " & iLoc_ID & Environment.NewLine
                strSql &= "ORDER BY Device_DateShip DESC;"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Device_DateShip")) Then
                        If DateDiff(DateInterval.Day, CDate(R1("Device_DateShip")), CDate(strSeverDt)) <= 90 Then
                            iResult = 1
                        End If
                    End If
                Next R1

                Return iResult
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**************************************************************
        Public Function RecDevicesIntoPSSWIP(ByVal iCust_ID As Integer, _
                                              ByVal iLoc_ID As Integer, _
                                              ByVal iPO_ID As Integer, _
                                              ByVal strCustWO As String, _
                                              ByVal iWO_ID As Integer, _
                                              ByVal iTrayID As Integer, _
                                              ByVal iModel_ID As Integer, _
                                              ByVal strUserName As String, _
                                              ByVal iUser_ID As Integer, _
                                              ByVal iEmpNo As Integer, _
                                              ByVal iShift_ID As Integer, _
                                              ByVal strWorkDate As String, _
                                              ByVal strCustRMA As String, _
                                              ByVal strCustSN As String, _
                                              ByVal strMainSN As String, _
                                              ByVal iPSSWarranty As Integer) As Integer
            Dim objRec As Production.Receiving
            Dim iDevice_ID As Integer = 0
            Dim i As Integer = 0
            Dim iCnt As Integer = 0
            Const iCC_ID As Integer = 37

            Try
                objRec = New Production.Receiving()
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1
                '************************
                '3:: Insert into tdevice
                '************************
                iDevice_ID = objRec.InsertIntoTdevice(strMainSN, _
                                                      strWorkDate, _
                                                      iCnt, _
                                                      iTrayID, _
                                                      iLoc_ID, _
                                                      iWO_ID, _
                                                      iModel_ID, _
                                                      iShift_ID, _
                                                      iPSSWarranty, , , iCC_ID)
                If iDevice_ID = 0 Then
                    Throw New Exception("System has failed to insert into tdevice.")
                End If

                '************************
                '4:: Insert into tcellopt
                '************************
                i = objRec.InsertIntoTCellopt(iDevice_ID, , , , , , , , , , , , , , )
                If i = 0 Then
                    Throw New Exception("System has failed to insert into tcellopt.")
                End If

                '***************************
                '5:: Write Customer Device ID into tdyscerndata
                '***************************
                i = Me.InsertIntoTSonitrolData(iDevice_ID, strCustSN, strCustRMA)

                If i = 0 Then
                    Throw New Exception("System has failed to write 'Customer Device ID' receive flag.")
                End If

                Return iDevice_ID
            Catch ex As Exception
                Throw ex
            Finally
                objRec = Nothing
            End Try
        End Function

        '**************************************************************
        Public Function IsBillcodeExist(ByVal iModel_ID As Integer, _
                                        ByVal iBillcode_ID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "Select count(*) from tpsmap where Model_ID = " & iModel_ID & " and billcode_id = " & iBillcode_ID & ";"
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetReceivedDevicesByWOID(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Device_Cnt as 'Seq', Device_SN as 'PSS SN' " & Environment.NewLine
                strSql &= ", if(Device_PSSWrty = 1, 'Yes', 'No') as 'PSS Warranty'" & Environment.NewLine
                strSql &= ", sd_CustSN as 'Customer SN', sd_RMA as 'Customer RMA'" & Environment.NewLine
                strSql &= ", Device_DateRec as 'Receipt Date', Device_DateShip as 'Prod Ship Date'  " & Environment.NewLine
                strSql &= "FROM tdevice  " & Environment.NewLine
                strSql &= "INNER JOIN tsonitroldata ON tdevice.Device_ID = tsonitroldata.Device_ID  " & Environment.NewLine
                strSql &= "WHERE WO_ID = " & iDeviceID & Environment.NewLine
                strSql &= "ORDER BY Device_Cnt Desc;"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function InsertIntoTSonitrolData(ByVal iDevice_ID As Integer, _
                                               ByVal strCustSN As String, _
                                               ByVal strRMA As String) As Integer
            Dim strSql As String

            Try
                strSql = "INSERT INTO tsonitroldata (Device_ID, sd_CustSN, sd_RMA ) VALUES ( " & iDevice_ID & ", '" & strCustSN.Trim & "', '" & strRMA & "')"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Shared Function GetReverseLogisticsCustomers(ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT distinct tcustomer.cust_id, tcustomer.cust_name1 From tcustomer " & Environment.NewLine
                strSql &= "INNER JOIN tcusttoprice ON tcustomer.Cust_ID = tcusttoprice.Cust_ID " & Environment.NewLine
                strSql &= "WHERE Prod_ID = 7 " & Environment.NewLine
                strSql &= "ORDER BY cust_name1;"
                dt = objDataProc.GetDataTable(strSql)
                If booAddSelectRow Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************

    End Class
End Namespace