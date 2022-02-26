Option Explicit On 

Imports System.Data.OleDb

Namespace Buisness
    Public Class GameStopBilling
        Private objMisc As Production.Misc

        '***************************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        '***************************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '***************************************************************
        Public Function IsGameStopDevice(ByVal strDeviceSN As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim booIsGameStopDevice As Boolean = False
            Dim iCnt As Integer

            Try
                strSql &= "SELECT COUNT(*) AS Cnt " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                strSql &= "WHERE B.Cust_ID = 2219 AND A.Device_DateBill IS NOT NULL AND A.Device_DateShip IS NULL AND A.Device_DateRec IS NOT NULL AND A.Device_SN = '" & strDeviceSN & "';"

                objMisc._SQL = strSql
                dt = objMisc.GetDataTable

                If dt.Rows.Count = 1 Then
                    If Not IsDBNull(dt.Rows(0)("Cnt")) Then
                        iCnt = CInt(dt.Rows(0)("Cnt"))

                        If iCnt > 0 Then
                            booIsGameStopDevice = True
                        End If
                    End If
                End If

                Return booIsGameStopDevice
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '***************************************************************
        Public Function GameStopDeviceLotNum(ByVal strDeviceSN As String) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strLotNum As String = ""

            Try
                strSql &= "SELECT WHP_Lot " & Environment.NewLine
                strSql &= "FROM twarehousepallet A " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder B ON B.WO_RecPalletName = A.WHPallet_Number " & Environment.NewLine
                strSql &= "INNER JOIN tdevice C ON C.wo_id = B.wo_id " & Environment.NewLine
                strSql &= "WHERE C.Device_SN = '" & strDeviceSN & "' " & Environment.NewLine
                strSql &= "ORDER BY C.Device_ID DESC LIMIT 1;"

                objMisc._SQL = strSql
                dt = objMisc.GetDataTable

                If dt.Rows.Count > 0 Then
                    If Not IsDBNull(dt.Rows(0)("WHP_Lot")) Then
                        strLotNum = dt.Rows(0)("WHP_Lot")
                    End If
                End If

                Return strLotNum
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '***************************************************************
        Public Sub LoadRURSCRAPINCOMPLETEBillcodes(ByRef cmbBillBillcodes As System.Windows.Forms.ComboBox, _
                                                   ByVal iProd_ID As Integer, _
                                                   ByVal iModel_ID As Integer)
            Dim strSql As String = ""
            Dim dt1 As DataTable

            Try
                strSql &= "SELECT distinct lbillcodes.BillCode_ID, BillCode_Desc " & Environment.NewLine
                strSql &= "FROM tpsmap " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes on tpsmap.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.Inactive = 0 " & Environment.NewLine
                strSql &= "AND Model_ID = " & iModel_ID & " " & Environment.NewLine
                strSql &= "AND Prod_ID = " & iProd_ID & Environment.NewLine
                strSql &= "AND tpsmap.billcode_ID in (874, 875, 1033);"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                dt1.LoadDataRow(New Object() {"0", "-- Select --"}, False)

                '******************************************************
                'Populate the Combo Box
                With cmbBillBillcodes
                    .DataSource = dt1.DefaultView
                    .DisplayMember = dt1.Columns("BillCode_Desc").ToString
                    .ValueMember = dt1.Columns("BillCode_ID").ToString
                    .SelectedValue = 0
                End With
                '*******************************************************

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '***************************************************************
        Public Function GetDevicePallett_IDInWIP(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iPallett_ID As Integer = 0

            Try
                strSql &= "SELECT Pallett_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & ";"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("Pallett_ID")) Then
                        iPallett_ID = dt1.Rows(0)("Pallett_ID")
                    End If
                End If

                Return iPallett_ID
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************
        Public Function VerifyDeviceModel(ByVal iDevice_ID As Integer, _
                                          ByVal iModel_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim booResult As Boolean = False

            Try
                strSql &= "SELECT Model_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & Environment.NewLine
                'strSql &= "AND Model_ID = " & iModel_ID & ";"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If (iModel_ID = 881 Or iModel_ID = 1112) And (dt1.Rows(0)("Model_ID") = 881 Or dt1.Rows(0)("Model_ID") = 1112) Then
                        booResult = True
                    ElseIf iModel_ID = dt1.Rows(0)("Model_ID") Then
                        booResult = True
                    Else
                        booResult = False
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************
        Public Function BillRURSCRAPINCOMPLETE(ByVal iUser_ID As Integer, _
                                     ByVal strUserName As String, _
                                     ByVal iEmpNo As Integer, _
                                     ByVal iShift_ID As Integer, _
                                     ByVal strWorkDate As String, _
                                     ByVal iCust_ID As Integer, _
                                     ByVal iLoc_ID As Integer, _
                                     ByVal iProd_ID As Integer, _
                                     ByVal iBillcode_ID As Integer, _
                                     ByVal lstBillSNs As System.Windows.Forms.ListBox) As Integer

            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iIndex As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim strSN As String = ""
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim objGenBilling As New PSS.Data.Buisness.GenerateBilling()
            Dim booBilling As Boolean = False

            Try

                For iIndex = 0 To lstBillSNs.Items.Count - 1
                    strSN = UCase(Trim(lstBillSNs.Items.Item(iIndex)))

                    iDevice_ID = objGen.GetDevIDInWIPBySNCustID(strSN, iCust_ID)

                    strSql = "SELECT tdevicebill.BillCode_ID " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tdevicebill ON  tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.device_id = " & iDevice_ID
                    Me.objMisc._SQL = strSql
                    dt1 = Me.objMisc.GetDataTable


                    If dt1.Rows.Count > 0 Then
                        For Each R1 In dt1.Rows
                            booBilling = objGenBilling.ab_DELETE(iDevice_ID, R1("BillCode_ID"), iUser_ID, strUserName, iEmpNo, iShift_ID, strWorkDate)
                            If booBilling = False Then
                                Throw New Exception("System failed to un-bill ""billcode " & R1("BillCode_ID") & """ on ""device ID " & iDevice_ID & """")
                            End If
                        Next R1
                    End If

                    booBilling = objGenBilling.ab_ADD(iDevice_ID, iBillcode_ID, iProd_ID, iUser_ID, strUserName, iEmpNo, iShift_ID, strWorkDate)

                    If booBilling = False Then
                        Throw New Exception("System failed to bill ""billcode " & iBillcode_ID & """ on ""device ID " & iDevice_ID & """")
                    End If

                    'Update wipowner to different bucket
                    strSql = "UPDATE tcellopt SET cellopt_WipOwnerOld =  CellOpt_WIPOwner " & Environment.NewLine
                    strSql &= ", CellOpt_WIPOwner = 4 " & Environment.NewLine
                    strSql &= ", cellopt_WipEntryDt = now() " & Environment.NewLine
                    strSql &= ", CellOpt_TechAssigned = " & iEmpNo & Environment.NewLine
                    strSql &= ", cellopt_techassigndate = now() " & Environment.NewLine
                    strSql &= "WHERE device_id = " & iDevice_ID & ";"
                    Me.objMisc._SQL = strSql
                    Me.objMisc.ExecuteNonQuery(strSql)

                    strSN = ""
                    iDevice_ID = 0
                    strSql = ""
                    R1 = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                Next iIndex

                Return iIndex
            Catch ex As Exception
                Throw ex
            Finally
                objGen = Nothing
                objGenBilling = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************

    End Class

End Namespace
