Option Explicit On 

Imports System.Data
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Namespace Buisness
    Public Class AMSInfraStructure

        Private _objDataProc As DBQuery.DataProc

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '******************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '******************************************************************

#Region "-AMS InfraStructure"
        '******************************************************************
        Public Shared ReadOnly Property AMSInfraStructure_CUSTOMER_ID() As Integer
            Get
                Return 2562
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property AMSInfraStructure_LOC_ID() As Integer
            Get
                Return 3364
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property AMSInfraStructure_MANIFEST_DIR() As String
            Get
                Return "P:\Dept\AMS InfraStructure\Pallet Packing List\"
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property AMSInfraStructure_GROUPID() As Integer
            Get
                Return 114
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property AMSInfraStructure_REPORTGROUP_GROUPID() As Integer
            Get
                Return 93
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property Repair_Pallet_ID() As Integer
            Get
                Return 216407
            End Get
        End Property
        '******************************************************************
        Public Shared ReadOnly Property BER_Pallet_ID() As Integer
            Get
                Return 216408
            End Get
        End Property

        '******************************************************************
        Public Function GetPalletNamePrefixStr(ByVal iCustomerID As Integer) As String
            'strPrefix must be an unique: strings of column 'Pallet_Name' in the table tPallett
            Dim strPrefix As String = String.Empty
            Try
                Select Case iCustomerID
                    Case Me.AMSInfraStructure_CUSTOMER_ID
                        strPrefix = "AMSINE"
                End Select
                Return strPrefix
            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

#Region "Create RMA/WO"
        '******************************************************************
        Public Function GetRMA_WO(ByVal iMenuCustID As Integer, ByVal strCustWO As String) As DataTable
            Dim strSql As String

            Try
                strSql &= "SELECT WO_ID, tworkorder.Loc_ID, Cust_Name1, Loc_Name, WO_Quantity, WO_RAQnty, Prod_ID, PO_ID, WO_CameWithFile, WO_Closed " & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tworkorder.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strSql &= "WHERE WO_CustWO = '" & strCustWO & "' " & Environment.NewLine
                strSql &= "AND tlocation.Cust_ID = " & iMenuCustID & ";"
                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "Receiving"

        '******************************************************************
        Public Function GetAMSINE_Models(ByVal iReportGroup_GroupID) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Model_id,Model_desc,Model_MotoSku,Manuf_ID,Prod_ID,UPC_Code" & Environment.NewLine
                strSql &= " FROM tmodel WHERE rptGrp_ID = " & iReportGroup_GroupID & ";"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetDevRcvdByWO(ByVal iWOID As Integer, _
                                       ByVal strWOName As String, _
                                       ByVal strBegDate As String, _
                                       ByVal strEndDate As String) As DataTable
            Dim strSql As String

            Try
                strSql &= "SELECT Model_Desc as 'Model', tdevice.Device_SN as 'SN', Device_RecWorkDate as 'Rcvg Date' " & Environment.NewLine
                strSql &= ", if(tcellopt.Manuf_SN is null, '', tcellopt.Manuf_SN) as 'Manuf SN' " & Environment.NewLine
                strSql &= " FROM tdevice " & Environment.NewLine
                strSql &= " INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= " INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= " WHERE tdevice.WO_ID = " & iWOID & " " & Environment.NewLine
                strSql &= " AND Device_DateRec BETWEEN '" & strBegDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSql &= "ORDER BY tdevice.Device_ID Desc; " & Environment.NewLine

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function ReceiveDevice(ByVal iLocID As Integer, _
                                      ByVal strWOName As String, _
                                      ByVal iWOID As Integer, _
                                      ByVal iTrayID As Integer, _
                                      ByVal iModelID As Integer, _
                                      ByVal strManufSN As String, _
                                      ByVal strSN As String, _
                                      ByVal iShiftID As Integer, _
                                      ByVal iUsrID As Integer, _
                                      ByRef strErrMsg As String) As Integer
            Dim objRec As PSS.Data.Production.Receiving
            Dim strWrkDate As String = ""
            Dim iCnt, iDeviceID, i As Integer
            Dim strSql As String = ""
            Dim strSku As String = ""
            strErrMsg = ""

            Try
                strWrkDate = PSS.Data.Buisness.Generic.GetWorkDate(iShiftID)
                iCnt = objRec.GetNextDeviceCountInTray(iTrayID) + 1

                '1. Writer device to tdevice table
                objRec = New PSS.Data.Production.Receiving()
                iDeviceID = objRec.InsertIntoTdevice(strSN, strWrkDate, iCnt, iTrayID, iLocID, iWOID, iModelID, iShiftID, , , , )
                If iDeviceID = 0 Then
                    strErrMsg = "System has failed to create Device ID."
                End If

                '2. Write into tCellOpt table
                i = objRec.InsertIntoTCellopt(iDeviceID, , , , , , , , , , , , , , , , , , , strManufSN, )
                If i = 0 Then
                    strErrMsg = "System has failed to write data into tCellOpt table."
                End If

                Return iDeviceID
            Catch ex As Exception
                strErrMsg = ex.ToString
            Finally
                objRec = Nothing
            End Try
        End Function


        '******************************************************************
        Public Function GetLastSerialNumber(ByVal iLoc_ID As Integer, _
                                         ByVal strModelMotoSku As String, _
                                         ByVal strRecWorkDate As String) As String
            Dim strSql As String
            Dim dt As DataTable
            Dim strRes As String = "01"
            Dim iNo As Integer = 0

            Try
                strSql = "select Device_SN, Left(trim(Device_SN),Length('" & strModelMotoSku & "')) As Equip," & Environment.NewLine
                strSql &= " Mid(trim(Device_SN),4,6) As DT," & Environment.NewLine
                strSql &= " Right(trim(Device_SN),2) As SqNo" & Environment.NewLine
                strSql &= " from tdevice" & Environment.NewLine
                strSql &= " where Device_RecWorkDate ='" & strRecWorkDate & "'" & Environment.NewLine
                strSql &= " And Left(trim(Device_SN),Length('" & strModelMotoSku & "'))='" & strModelMotoSku & "'" & Environment.NewLine
                strSql &= " And Loc_ID=" & iLoc_ID & Environment.NewLine
                strSql &= " Order by Right(trim(Device_SN),2) desc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    If Not dt.Rows(0).IsNull("SqNo") Then
                        If IsNumeric(dt.Rows(0).Item("SqNo")) Then
                            iNo = dt.Rows(0).Item("SqNo") + 1
                            If iNo < 10 Then
                                strRes = "0" & iNo.ToString
                            Else
                                strRes = iNo.ToString
                            End If
                        End If
                    End If
                End If

                Return strRes

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '******************************************************************

#End Region

#Region "Create Pallett"

        '****************************************************************************************************
        Public Function AutoShip_AMS_Infrastructure(ByVal iDeviceID As Integer, ByVal iShiftID As Integer) As String
            Dim objProdShip As Production.Shipping
            Dim strErrMsg, strSql, strWorkDt As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i, iMaxBillRule, iPalletID, iShipID, iFinishedGood As Integer

            Try
                strErrMsg = "" : strWorkDt = ""
                iMaxBillRule = Generic.GetMaxBillRule(iDeviceID)
                If iMaxBillRule = -1 Then
                    strErrMsg = "Can't define bill rule of device."
                Else
                    objProdShip = New Production.Shipping()
                    If iMaxBillRule = 0 Then
                        iPalletID = Me.Repair_Pallet_ID : iFinishedGood = 1
                    Else
                        iPalletID = Me.BER_Pallet_ID : iFinishedGood = 0
                    End If

                    strWorkDt = Generic.GetWorkDate(iShiftID)
                    iShipID = objProdShip.GetShipIDByPallet(iPalletID)

                    strSql = "SELECT * FROM tdevice WHERE Device_ID = " & iDeviceID
                    dt = Me._objDataProc.GetDataTable(strSql)
                    If dt.Rows.Count = 0 Then
                        strErrMsg = "Device ID does not exist."
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso dt.Rows(0)("Pallett_ID").ToString.Trim.Length > 0 Then
                        strErrMsg = "Device belongs to pallet ID " & dt.Rows(0)("Pallett_ID")
                    ElseIf Not IsDBNull(dt.Rows(0)("Device_Dateship")) Then
                        strErrMsg = "Device has already completed."
                    ElseIf iShipID = 0 Then
                        strErrMsg = "Can't define ship ID."
                    Else
                        i = objProdShip.UpdateShipInfo(iDeviceID, strWorkDt, iShiftID, iPalletID, iShipID, iFinishedGood, "WAITING DOCK SHIP")
                    End If
                End If

                Return strErrMsg
            Catch ex As Exception
                Throw ex
            Finally
                objProdShip = Nothing : R1 = Nothing : PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************************

#End Region

#Region "Print"


        '********************************************************************************
        Public Function Print_ReceivingDataReport(ByVal strWorkOrder As String, _
                                                  ByVal dt As DataTable, _
                                                  ByVal iCopies As Integer) As Integer

            Dim row As DataRow
            Dim objRpt As ReportDocument

            Try

                If Not dt.Rows.Count > 0 Then Exit Function

                'add columns to meet CrystalRpt Field Definition
                Dim newColumn1 As New DataColumn("WorkOrder", GetType(String))
                Dim newColumn2 As New DataColumn("Other1", GetType(String))
                Dim newColumn3 As New DataColumn("Other2", GetType(Int32))
                newColumn1.DefaultValue = strWorkOrder
                newColumn2.DefaultValue = ""
                newColumn3.DefaultValue = 0
                dt.Columns.Add(newColumn1) : dt.Columns.Add(newColumn2) : dt.Columns.Add(newColumn3)

                objRpt = New ReportDocument()
                With objRpt
                    .Load(PSS.Data.ConfigFile.GetBaseReportPath & "AMS InfraStructure Receiving Push.rpt")
                    If Not IsNothing(dt) Then .SetDataSource(dt)
                    .Refresh()
                    .PrintToPrinter(iCopies, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me._objDataProc = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try

        End Function
#End Region

#Region "Dock Ship"

        '******************************************************************
        Public Function GetShipBoxTypes() As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim drNewRow As DataRow

            Try
                strSql = "SELECT 0 as 'ShipTypeID', 'REFURBISHED' as 'ShipTypeDesc' " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                drNewRow = dt.NewRow
                drNewRow("ShipTypeID") = 1
                drNewRow("ShipTypeDesc") = "DBR"
                dt.Rows.Add(drNewRow)

                drNewRow = Nothing
                drNewRow = dt.NewRow
                drNewRow("ShipTypeID") = 2
                drNewRow("ShipTypeDesc") = "NER"
                dt.Rows.Add(drNewRow)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                drNewRow = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetOpenPallets(ByVal strPalletStartName As String, _
                                       ByVal iCustID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Pallett_ID, tpallett.Model_ID, Model_Desc, Loc_ID, Pallet_ShipType, Pallet_SkuLen, Pallett_Name as 'Box Name' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND pallett_name like '" & strPalletStartName & "%' " & Environment.NewLine
                strSql &= "AND Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                strSql &= "Order by Pallett_id Desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function GetOpenPalletsByPalletID(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Pallett_ID, tpallett.Model_ID, Model_Desc, Loc_ID, Pallet_ShipType, Pallet_SkuLen, Pallett_Name as 'Box Name' " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "LEFT JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_ID = " & iPalletID & Environment.NewLine


                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function CreateBoxID(ByVal iBoxType As Integer, _
                            ByVal strPalletPrefix As String, _
                            ByVal iCustID As Integer, _
                            ByVal iLocID As Integer) As Integer

            'Return pallet ID (Primary key)

            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim i As Integer = 0

            Try

                strDate = Generic.GetMySqlDateTime("%y%m%d")
                strPalletPrefix = strPalletPrefix + strDate & "N"
                strPalletName = Me.DefinePalletName(strPalletPrefix, iCustID, iLocID)

                'check for duplicate pallet
                strSql = "Select count(*) as cnt From tpallett where Pallett_Name = '" & strPalletName & "' and Loc_ID = " & iLocID
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Throw New Exception("System is trying to create pallet (" & strPalletName & ") which is already existed in system.")

                'Create pallet
                strSql = "INSERT INTO tpallett ( Pallett_Name,Pallet_ShipType,Cust_ID,Loc_ID)" & Environment.NewLine
                strSql &= " VALUES (  " & Environment.NewLine
                strSql &= "'" & strPalletName & "' " & Environment.NewLine
                strSql &= ", " & iBoxType & Environment.NewLine
                strSql &= ", " & iCustID & " " & Environment.NewLine
                strSql &= ", " & iLocID & ");" & Environment.NewLine

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then 'failed
                    Return 0
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Private Function DefinePalletName(ByVal strPalletPrefix As String, ByVal iCustID As Integer, ByVal iLocID As Integer) As String
            Dim strSQL As String
            Dim dt As DataTable
            Dim strPallett_Name As String = strPalletPrefix

            Try

                strSQL = "SELECT max(right(Pallett_Name, 3) ) + 1 as Pallett_Num " & Environment.NewLine
                strSQL &= "FROM tpallett " & Environment.NewLine
                strSQL &= "WHERE Pallett_Name like '" & strPalletPrefix & "%' " & Environment.NewLine
                strSQL &= "AND Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND Loc_ID = " & iLocID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("Pallett_Num")) Then
                        strPallett_Name &= Format(dt.Rows(0)("Pallett_Num"), "000")
                    Else
                        strPallett_Name &= "001"
                    End If
                Else
                    strPallett_Name &= "001"
                End If

                Return strPallett_Name
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function GetDeviceInfoInWIP(ByVal strSN As String, _
                                           ByVal iLocID As Integer) As DataTable
            Dim strSql As String = ""

            Try

                strSql &= "SELECT A.* " & Environment.NewLine
                strSql &= " FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tpallett B ON A.pallett_ID=B.pallett_ID AND A.Loc_ID=B.Loc_ID " & Environment.NewLine
                strSql &= " WHERE A.Loc_ID= " & iLocID & " AND Pallet_ShipType=0 AND (B.pkSlip_ID is null OR Length(Trim(B.pkSlip_ID))=0) " & Environment.NewLine
                strSql &= " AND A.Device_SN = '" & strSN & "';"

                Return Me._objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function RemoveSNfromPallet(ByVal iRepaired_PallettID As Integer, ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""

            Try
                'Update tdevice table
                strSql = "Update tdevice set Pallett_ID = " & iRepaired_PallettID & " where device_id = " & iDeviceID
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function IsDockShippedPalletID(ByVal strPalletPrefix As String, ByVal iPalletID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "Select * From tpallett where Pallett_Name like '" & strPalletPrefix & "%' "
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************
        Public Function InsertPackingSlip(ByVal iCustID As Integer, _
                                          ByVal iUserID As Integer) As Integer
            'Return pkslip_ID (Primary key)

            Dim strSql As String = ""
            Dim strDate As String = ""
            Dim strPalletName As String = ""
            Dim i As Integer = 0

            Try

                strDate = Generic.GetMySqlDateTime("%Y-%m-%d %T")

                strSql = "INSERT INTO tpackingslip (pkslip_createDt,Cust_ID,pkslip_usrID)" & Environment.NewLine
                strSql &= " VALUES (  " & Environment.NewLine
                strSql &= "'" & strDate & "' " & Environment.NewLine
                strSql &= ", " & iCustID & " " & Environment.NewLine
                strSql &= ", " & iUserID & ");" & Environment.NewLine

                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then 'failed
                    Return 0
                Else
                    strSql = "SELECT LAST_INSERT_ID();"
                    Return Me._objDataProc.GetIntValue(strSql)
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************
        Public Function UpdateAfterShipped(ByVal iPallet_ID As Integer, ByVal iPkslip_ID As Integer, _
                                           ByVal iUserID As Integer, ByVal strScreenName As String, ByVal strFormName As String) As Integer
            'Return pkslip_ID (Primary key)

            Dim strSql, strDate As String
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                strSql = "SELECT tdevice.Device_ID, WorkStation FROM tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE tpallett.pallett_ID = " & iPallet_ID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then Throw New Exception("Pallet/Box is empty.")

                strDate = Generic.GetMySqlDateTime("%Y-%m-%d %T")

                strSql = "UPDATE tpallett " & Environment.NewLine
                strSql &= "SET pkslip_ID = " & iPkslip_ID & Environment.NewLine
                strSql &= "WHERE Pallett_ID = " & iPallet_ID
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "UPDATE tcellopt " & Environment.NewLine
                strSql &= "INNER JOIN tdevice ON tcellopt.Device_ID = tdevice.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "SET WorkStation = 'INTRANSIT'" & Environment.NewLine
                strSql &= ", WorkStationEntryDt = '" & strDate & "'" & Environment.NewLine
                strSql &= ", Cellopt_WIPOwner = 7, Cellopt_WIPOwnerOld = Cellopt_WIPEntryDt, Cellopt_WIPEntryDt = '" & strDate & "'" & Environment.NewLine
                strSql &= "WHERE tpallett.pallett_ID = " & iPallet_ID & Environment.NewLine
                i += Me._objDataProc.ExecuteNonQuery(strSql)

                Generic.SetTcelloptWorkstationJournal(dt, iUserID, "INTRANSIT", strScreenName, strFormName)

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

#End Region

    End Class
End Namespace
