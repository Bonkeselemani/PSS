Option Explicit On 

Namespace Production
    Public Class Receiving
        Private objMisc As Production.Misc

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************

        '********************************************************************
        Public Function GetCSIN_ID_InStaging(ByVal strIMEI As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iCsin_ID As Integer = 0

            Try
                ''Get CSIN_ID of a staging device
                strSql = "SELECT csin_ID FROM cstincomingdata " & Environment.NewLine
                strSql &= "WHERE csin_ESN = '" & strIMEI & "' " & Environment.NewLine
                strSql &= "AND flgReceived = 0 " & Environment.NewLine
                strSql &= "AND Device_ID = 0 " & Environment.NewLine
                strSql &= "order by csin_id desc;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iCsin_ID = dt1.Rows(0)("csin_ID")
                End If

                Return iCsin_ID
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function InsertIntoCstincomingData(ByVal strRepairOrderNum As String, _
                                                  ByVal strFileTimestamp As String, _
                                                  ByVal strPartUPCNumber As String, _
                                                  ByVal strESN As String, _
                                                  ByVal strEnterprise As String, _
                                                  Optional ByVal iDevice_ID As Integer = 0, _
                                                  Optional ByVal iFlgRcvd As Integer = 0, _
                                                  Optional ByVal iIsSalvageFlg As Integer = 0, _
                                                  Optional ByVal iCameWithFileFlg As Integer = 1, _
                                                  Optional ByVal iQty As Integer = 1, _
                                                  Optional ByVal strStoreLoc As String = "NULL", _
                                                  Optional ByVal strVendor_Item As String = "NULL", _
                                                  Optional ByVal iDevsFrBP As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO cstincomingdata ( " & Environment.NewLine
                strSql &= "csin_RepairOrderNum, " & Environment.NewLine
                strSql &= "csin_Timestamp, " & Environment.NewLine
                strSql &= "csin_ItemNum, " & Environment.NewLine
                strSql &= "csin_ESN, " & Environment.NewLine
                strSql &= "csin_EnterpriseCode, " & Environment.NewLine
                strSql &= "vendor_item, " & Environment.NewLine
                strSql &= "csin_storeloc, " & Environment.NewLine
                strSql &= "Device_ID, " & Environment.NewLine
                strSql &= "flgReceived, " & Environment.NewLine
                strSql &= "cs_DevFrBP, " & Environment.NewLine
                strSql &= "isSalvageFlg, " & Environment.NewLine
                strSql &= "NewLoadFlg, " & Environment.NewLine
                strSql &= "CameWithFileFlg, " & Environment.NewLine
                strSql &= "csin_Qty " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strRepairOrderNum & "' " & Environment.NewLine
                strSql &= ", '" & strFileTimestamp & "' " & Environment.NewLine
                strSql &= ", '" & strPartUPCNumber & "' " & Environment.NewLine
                strSql &= ", '" & strESN & "' " & Environment.NewLine
                strSql &= ", '" & strEnterprise & "' " & Environment.NewLine
                If strVendor_Item = "NULL" Then
                    strSql &= ", " & strVendor_Item & Environment.NewLine
                Else
                    strSql &= ", '" & strVendor_Item & "' " & Environment.NewLine
                End If
                If strStoreLoc = "NULL" Then
                    strSql &= ", " & strStoreLoc & Environment.NewLine
                Else
                    strSql &= ", '" & strStoreLoc & "' " & Environment.NewLine
                End If
                strSql &= ", " & iDevice_ID & Environment.NewLine
                strSql &= ", " & iFlgRcvd & Environment.NewLine
                strSql &= ", " & iDevsFrBP & Environment.NewLine
                strSql &= ", " & iIsSalvageFlg & Environment.NewLine
                strSql &= ", 1 " & Environment.NewLine
                strSql &= ", " & iCameWithFileFlg & Environment.NewLine
                strSql &= ", " & iQty & Environment.NewLine
                strSql &= ");"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function SetRcvdFlgInCstincomingdata(ByVal iCsin_ID As Integer, _
                                                    ByVal iDevice_ID As Integer, _
                                                    Optional ByVal iSalvage As Integer = 0, _
                                                    Optional ByVal iDevsFrBP As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "UPDATE cstincomingdata " & Environment.NewLine
                strSql &= "SET flgReceived = 1 " & Environment.NewLine
                strSql &= ", Device_ID = " & iDevice_ID & Environment.NewLine
                strSql &= ", isSalvageFlg = " & iSalvage & Environment.NewLine
                strSql &= ", cs_DevFrBP = " & iDevsFrBP & Environment.NewLine
                strSql &= "WHERE csin_id = " & iCsin_ID & ";"
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '********************************************************************
        Public Function GetWO_ID(ByVal iLoc_ID As Integer, _
                                 ByVal strWO_CustWO As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iWO_ID As Integer = 0

            Try
                'Check if Work Order already existed
                strSql = "SELECT wo_id FROM tworkorder " & Environment.NewLine
                strSql &= "WHERE WO_CustWO = '" & strWO_CustWO & "' and " & Environment.NewLine
                strSql &= "Loc_ID = " & iLoc_ID & " ORDER BY WO_ID DESC;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iWO_ID = CInt(dt1.Rows(0)("wo_id"))
                End If

                Return iWO_ID
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function InsertIntoTworkorder(ByVal strWO_CustWO As String, _
                                             ByVal strWO_RecPalletName As String, _
                                             ByVal iLoc_ID As Integer, _
                                             ByVal iProd_ID As Integer, _
                                             ByVal iGroup_ID As Integer, _
                                             Optional ByVal strWO_Memo As String = "NULL", _
                                             Optional ByVal strShipTo_ID As String = "NULL", _
                                             Optional ByVal strPO_ID As String = "NULL", _
                                             Optional ByVal strSku_ID As String = "NULL", _
                                             Optional ByVal strWO_Quantity As String = "NULL", _
                                             Optional ByVal iWO_CameWithFile As Integer = 0 _
                                             ) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim iWO_ID As Integer = 0

            Try
                strSql = "INSERT INTO tworkorder ( " & Environment.NewLine
                strSql &= "WO_CustWO " & Environment.NewLine
                strSql &= ", WO_RecPalletName " & Environment.NewLine
                strSql &= ", WO_Date " & Environment.NewLine
                strSql &= ", Loc_ID " & Environment.NewLine
                strSql &= ", Prod_ID " & Environment.NewLine
                strSql &= ", Group_ID " & Environment.NewLine
                strSql &= ", WO_Memo " & Environment.NewLine
                strSql &= ", ShipTo_ID " & Environment.NewLine
                strSql &= ", PO_ID " & Environment.NewLine
                strSql &= ", Sku_ID " & Environment.NewLine
                strSql &= ", WO_Quantity " & Environment.NewLine
                strSql &= ", WO_CameWithFile " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " '" & strWO_CustWO & "'" & Environment.NewLine
                strSql &= ", '" & strWO_RecPalletName & "'" & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ", " & iLoc_ID & Environment.NewLine
                strSql &= ", " & iProd_ID & Environment.NewLine
                strSql &= ", " & iGroup_ID & Environment.NewLine
                strSql &= ", '" & strWO_Memo & "'" & Environment.NewLine
                If IsNumeric(strShipTo_ID) Then
                    strSql &= ", " & CInt(strShipTo_ID) & Environment.NewLine
                Else
                    strSql &= ", '" & strShipTo_ID & "'" & Environment.NewLine
                End If

                If IsNumeric(strPO_ID) Then
                    strSql &= ", " & CInt(strPO_ID) & Environment.NewLine
                Else
                    strSql &= ", '" & strPO_ID & "'" & Environment.NewLine
                End If

                If IsNumeric(strSku_ID) Then
                    strSql &= ", " & CInt(strSku_ID) & Environment.NewLine
                Else
                    strSql &= ", '" & strSku_ID & "'" & Environment.NewLine
                End If

                If IsNumeric(strWO_Quantity) Then
                    strSql &= ", " & CInt(strWO_Quantity) & Environment.NewLine
                Else
                    strSql &= ", '" & strWO_Quantity & "'" & Environment.NewLine
                End If

                strSql &= ", " & iWO_CameWithFile & Environment.NewLine
                strSql &= ");"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                '*******************************
                'Get inserted wo_id
                '*******************************
                If i > 0 Then
                    iWO_ID = Me.GetWO_ID(iLoc_ID, strWO_CustWO)
                End If

                Return iWO_ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function InsertIntoTtray(ByVal iRecUsr_ID As Integer, _
                                        ByVal strRecUsr_Name As String, _
                                        Optional ByVal strWO_ID As String = "NULL", _
                                        Optional ByVal strTrayMemo As String = "NULL") As Integer
            Dim strSql As String = ""
            Dim iTray_ID As Integer = 0

            Try
                strSql = "INSERT INTO ttray (" & Environment.NewLine
                strSql &= "Tray_RecUser, Tray_RecUserID, WO_ID, Tray_Memo"
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "'" & strRecUsr_Name & "', " & iRecUsr_ID & ", " & strWO_ID

                If strTrayMemo = "NULL" Then
                    strSql &= ", " & strTrayMemo & Environment.NewLine
                Else
                    strSql &= ", '" & strTrayMemo.Replace("'", "\'") & "'" & Environment.NewLine
                End If
                strSql &= ");"

                Me.objMisc._SQL = strSql
                iTray_ID = Me.objMisc.idTransaction(strSql, "ttray")

                Return iTray_ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Sub InsertIntoTtray_NoReturnVal(ByVal iRecUsr_ID As Integer, _
                                        ByVal strRecUsr_Name As String, _
                                        Optional ByVal strWO_ID As String = "NULL", _
                                        Optional ByVal strTrayMemo As String = "NULL")
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO ttray (" & Environment.NewLine
                strSql &= "Tray_RecUser, Tray_RecUserID, WO_ID, Tray_Memo"
                strSql &= ") VALUES (" & Environment.NewLine
                strSql &= "'" & strRecUsr_Name & "', " & iRecUsr_ID & ", " & strWO_ID

                If strTrayMemo = "NULL" Then
                    strSql &= ", " & strTrayMemo & Environment.NewLine
                Else
                    strSql &= ", '" & strTrayMemo & "'" & Environment.NewLine
                End If
                strSql &= ");"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery(strSql)

                If i = 0 Then Throw New Exception("System has failed to create tray ID.")
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************
        Public Function GetDeviceID_InWIP(ByVal iWO_ID As Integer, _
                                          ByVal iLoc_ID As Integer, _
                                          ByVal strSN As String) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iDevice_ID As Integer = 0

            Try
                'Check if Work Order already existed
                strSql = "SELECT Device_ID FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Device_SN = '" & strSN & "' " & Environment.NewLine
                strSql &= "AND Loc_ID = " & iLoc_ID & Environment.NewLine
                strSql &= "AND WO_ID = " & iWO_ID & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '') " & Environment.NewLine
                strSql &= "order by Device_ID desc;"
                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    iDevice_ID = CInt(dt1.Rows(0)("Device_ID"))
                End If

                Return iDevice_ID
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '********************************************************************
        Public Function InsertIntoTdevice(ByVal strSN As String, _
                                          ByVal strWorkDate As String, _
                                          ByVal iCnt As Integer, _
                                          ByVal iTray_ID As Integer, _
                                          ByVal iLoc_ID As Integer, _
                                          ByVal iWO_ID As Integer, _
                                          ByVal iModel_ID As Integer, _
                                          ByVal iShift_ID_Rec As Integer, _
                                          Optional ByVal iDevice_PSSWrty As Integer = 0, _
                                          Optional ByVal iDevice_ManufWrty As Integer = 0, _
                                          Optional ByVal strSku_ID As String = "NULL", _
                                          Optional ByVal iCC_ID As Integer = 0, _
                                          Optional ByVal dblLabor As Double = 0.0, _
                                          Optional ByVal iRepeatRepCnt As Integer = 0, _
                                          Optional ByVal strRecDateTime As String = "") As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim iDevice_ID As Integer = 0

            Try
                '************************
                'Insert into tdevice
                '************************
                strSql = "INSERT into tdevice ( " & Environment.NewLine
                strSql &= "Device_SN " & Environment.NewLine
                strSql &= ", Device_DateRec " & Environment.NewLine
                strSql &= ", Device_RecWorkDate " & Environment.NewLine
                strSql &= ", Device_Cnt " & Environment.NewLine
                strSql &= ", Tray_ID " & Environment.NewLine
                strSql &= ", Loc_ID " & Environment.NewLine
                strSql &= ", WO_ID " & Environment.NewLine
                'strSql &= ", WO_ID_OUT " & Environment.NewLine
                strSql &= ", Model_ID " & Environment.NewLine
                strSql &= ", Shift_ID_Rec " & Environment.NewLine
                strSql &= ", Device_PSSWrty " & Environment.NewLine
                strSql &= ", Device_ManufWrty " & Environment.NewLine
                strSql &= ", Sku_ID " & Environment.NewLine
                strSql &= ", cc_id " & Environment.NewLine
                If dblLabor > 0 Then strSql &= ", Device_LaborLevel, Device_LaborCharge, Device_DateBill " & Environment.NewLine
                strSql &= ", RepeatRepCnt " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " '" & strSN & "' " & Environment.NewLine
                If strRecDateTime.Trim.Length = 0 Then strSql &= ", now() " & Environment.NewLine Else strSql &= ", '" & strRecDateTime & "'" & Environment.NewLine
                strSql &= ", '" & strWorkDate & "' " & Environment.NewLine
                strSql &= ", " & iCnt & Environment.NewLine
                strSql &= ", " & iTray_ID & Environment.NewLine
                strSql &= ", " & iLoc_ID & Environment.NewLine
                strSql &= ", " & iWO_ID & Environment.NewLine
                'strSql &= ", " & iWO_ID & Environment.NewLine
                strSql &= ", " & iModel_ID & Environment.NewLine
                strSql &= ", " & iShift_ID_Rec & Environment.NewLine
                strSql &= ", " & iDevice_PSSWrty & Environment.NewLine
                strSql &= ", " & iDevice_ManufWrty & Environment.NewLine
                If IsNumeric(strSku_ID) Then
                    strSql &= ", " & CInt(strSku_ID) & Environment.NewLine
                Else
                    strSql &= ", " & strSku_ID & Environment.NewLine
                End If
                strSql &= ", " & iCC_ID & Environment.NewLine
                If dblLabor > 0 Then strSql &= ", 0, " & dblLabor & ", now() " & Environment.NewLine
                strSql &= ", " & iRepeatRepCnt & Environment.NewLine
                strSql &= ");"

                Me.objMisc._SQL = strSql
                i += Me.objMisc.ExecuteNonQuery

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                ''************************
                ''Get Device ID
                ''************************
                iDevice_ID = Me.GetDeviceID_InWIP(iWO_ID, iLoc_ID, strSN)

                Return iDevice_ID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function InsertIntoTCellopt(ByVal iDevice_ID As Integer, _
                                           Optional ByVal strCellOpt_MSN As String = "NULL", _
                                           Optional ByVal strCellOpt_IMEI As String = "NULL", _
                                           Optional ByVal strCellOpt_CSN As String = "NULL", _
                                           Optional ByVal strCellOpt_CSN_Dec As String = "", _
                                           Optional ByVal strCellOpt_OutMSN As String = "NULL", _
                                           Optional ByVal strCellOpt_OutIMEI As String = "NULL", _
                                           Optional ByVal strCellOpt_OutCSN As String = "NULL", _
                                           Optional ByVal strCellOpt_APC As String = "NULL", _
                                           Optional ByVal strCellOpt_DateCode As String = "NULL", _
                                           Optional ByVal strCellOpt_Transceiver As String = "NULL", _
                                           Optional ByVal strCellOpt_SugIn As String = "NULL", _
                                           Optional ByVal strCellOpt_SugOut As String = "NULL", _
                                           Optional ByVal strCellOpt_SoftVerIN As String = "NULL", _
                                           Optional ByVal strCellOpt_SoftVerOUT As String = "NULL", _
                                           Optional ByVal iRUR_ReturnToCust As Integer = 0, _
                                           Optional ByVal strWorkStation As String = "NULL", _
                                           Optional ByVal strCellopt_ProdCode As String = "NULL", _
                                           Optional ByVal strCelloptWipOwnerID As Integer = 1, _
                                           Optional ByVal strManufSN As String = "", _
                                           Optional ByVal strSoftKeyCode As String = "", _
                                           Optional ByVal iPssWrtyOnDeviceID As Integer = 0, _
                                           Optional ByVal iSN_Discp_Flag As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                'strSvrDt = Generic.MySQLServerDateTime(1)

                strSql = "INSERT INTO tcellopt ( " & Environment.NewLine
                strSql &= "Device_ID " & Environment.NewLine
                strSql &= ", Cellopt_WIPOwner " & Environment.NewLine
                strSql &= ", Cellopt_WIPEntryDt " & Environment.NewLine
                strSql &= ", CellOpt_MSN " & Environment.NewLine
                strSql &= ", CellOpt_IMEI " & Environment.NewLine
                strSql &= ", CellOpt_CSN " & Environment.NewLine
                strSql &= ", CellOpt_CSN_Dec " & Environment.NewLine
                strSql &= ", CellOpt_OutMSN " & Environment.NewLine
                strSql &= ", CellOpt_OutIMEI " & Environment.NewLine
                strSql &= ", CellOpt_OutCSN " & Environment.NewLine
                strSql &= ", CellOpt_APC " & Environment.NewLine
                strSql &= ", CellOpt_DateCode " & Environment.NewLine
                strSql &= ", CellOpt_Transceiver " & Environment.NewLine
                strSql &= ", CellOpt_SugIn " & Environment.NewLine
                strSql &= ", CellOpt_SugOut " & Environment.NewLine
                strSql &= ", CellOpt_SoftVerIN " & Environment.NewLine
                strSql &= ", CellOpt_SoftVerOUT " & Environment.NewLine
                strSql &= ", RUR_ReturnToCust " & Environment.NewLine
                strSql &= ", WorkStationEntryDt " & Environment.NewLine
                strSql &= ", WorkStation " & Environment.NewLine
                strSql &= ", CellOpt_ProdCode " & Environment.NewLine
                strSql &= ", Manuf_SN " & Environment.NewLine
                strSql &= ", SoftKeyCode " & Environment.NewLine
                strSql &= ", PSS_Wrty_Device_ID " & Environment.NewLine
                strSql &= ", SN_Discp_Flag " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= iDevice_ID & Environment.NewLine
                strSql &= ", " & strCelloptWipOwnerID & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                If strCellOpt_MSN = "NULL" Then
                    strSql &= ", " & strCellOpt_MSN & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_MSN & "' " & Environment.NewLine
                End If

                If strCellOpt_IMEI = "NULL" Then
                    strSql &= ", " & strCellOpt_IMEI & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_IMEI & "' " & Environment.NewLine
                End If

                If strCellOpt_CSN = "NULL" Then
                    strSql &= ", " & strCellOpt_CSN & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_CSN & "' " & Environment.NewLine
                End If

                strSql &= ", '" & strCellOpt_CSN_Dec & "'" & Environment.NewLine

                If strCellOpt_OutMSN = "NULL" Then
                    strSql &= ", " & strCellOpt_OutMSN & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_OutMSN & "' " & Environment.NewLine
                End If

                If strCellOpt_OutIMEI = "NULL" Then
                    strSql &= ", " & strCellOpt_OutIMEI & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_OutIMEI & "' " & Environment.NewLine
                End If

                If strCellOpt_OutCSN = "NULL" Then
                    strSql &= ", " & strCellOpt_OutCSN & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_OutCSN & "' " & Environment.NewLine
                End If

                If strCellOpt_APC = "NULL" Then
                    strSql &= ", " & strCellOpt_APC & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_APC & "' " & Environment.NewLine
                End If

                If strCellOpt_DateCode = "NULL" Then
                    strSql &= ", " & strCellOpt_DateCode & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_DateCode & "' " & Environment.NewLine
                End If

                If strCellOpt_Transceiver = "NULL" Then
                    strSql &= ", " & strCellOpt_Transceiver & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_Transceiver & "' " & Environment.NewLine
                End If

                If strCellOpt_SugIn = "NULL" Then
                    strSql &= ", " & strCellOpt_SugIn & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_SugIn & "' " & Environment.NewLine
                End If

                If strCellOpt_SugOut = "NULL" Then
                    strSql &= ", " & strCellOpt_SugOut & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_SugOut & "' " & Environment.NewLine
                End If

                If strCellOpt_SoftVerIN = "NULL" Then
                    strSql &= ", " & strCellOpt_SoftVerIN & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_SoftVerIN & "' " & Environment.NewLine
                End If

                If strCellOpt_SoftVerOUT = "NULL" Then
                    strSql &= ", " & strCellOpt_SoftVerOUT & Environment.NewLine
                Else
                    strSql &= ", '" & strCellOpt_SoftVerOUT & "' " & Environment.NewLine
                End If
                strSql &= ", " & iRUR_ReturnToCust & " " & Environment.NewLine

                If strWorkStation = "NULL" Then
                    strSql &= ", " & strWorkStation & Environment.NewLine
                    strSql &= ", " & strWorkStation & Environment.NewLine
                Else
                    strSql &= ", now() " & Environment.NewLine
                    strSql &= ", '" & strWorkStation & "' " & Environment.NewLine
                End If

                If strCellopt_ProdCode = "NULL" Then
                    strSql &= ", " & strCellopt_ProdCode & Environment.NewLine
                Else
                    strSql &= ", '" & strCellopt_ProdCode & "' " & Environment.NewLine
                End If
                strSql &= ", '" & strManufSN & "'" & Environment.NewLine
                If strSoftKeyCode.Trim.Length > 0 Then
                    strSql &= ", '" & Buisness.Generic.AddMySqlEscapeChar(strSoftKeyCode) & "'" & Environment.NewLine
                Else
                    strSql &= ", null " & Environment.NewLine
                End If
                strSql &= ", " & iPssWrtyOnDeviceID & Environment.NewLine
                strSql &= ", " & iSN_Discp_Flag & Environment.NewLine

                strSql &= ");"

                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function InsertIntoNI_Device(ByVal iDevice_ID As Integer, _
                                            Optional ByVal strCloseDate As String = "" _
                                            ) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO NI_Device (Device_ID,Closed_Date)" & Environment.NewLine
                If strCloseDate.Trim.Length > 0 Then
                    strSql &= " VALUES (" & iDevice_ID & ",'" & strCloseDate & "')" & Environment.NewLine
                Else
                    strSql &= " VALUES (" & iDevice_ID & ",Null)" & Environment.NewLine
                End If
                Me.objMisc._SQL = strSql
                i = Me.objMisc.ExecuteNonQuery
                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function InsertIntoTDriveCamData(ByVal iDeviceID As Integer, ByVal iUserID As Integer, ByVal iAuthorizeCompactFlash As Integer) As Integer
            Dim strSql As String = ""

            Try
                '************************
                'Insert into TDriveCamData
                '************************
                strSql = "INSERT into tdrivecamdata ( " & Environment.NewLine
                strSql &= " Device_ID " & Environment.NewLine
                If iAuthorizeCompactFlash > 0 Then strSql &= ", OnHoldDate, ReleaseFrHoldDate, ReleaseUsrID, CompactFlashApproved " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " " & iDeviceID & Environment.NewLine
                If iAuthorizeCompactFlash > 0 Then strSql &= ", now() , now(), " & iUserID & ", " & iAuthorizeCompactFlash & Environment.NewLine
                strSql &= ");"

                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Shared Function GetNextDeviceCountInTray(ByVal iTrayID As Integer) As Integer
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                strSql = "SELECT max(Device_Cnt ) as NextCount FROM tdevice WHERE tray_id = " & iTrayID & Environment.NewLine
                Return objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function InsertIntoTShipTo(ByVal strCompany As String, ByVal strShipToName As String, ByVal strAddress1 As String, ByVal strAddress2 As String, _
                                          ByVal strCity As String, ByVal iStatesID As Integer, ByVal strZipCode As String, _
                                          ByVal iCountriesCodeID As Integer, ByVal strPhoneNumber As String, ByVal strFaxNumber As String, _
                                          ByVal strEmailAddress As String, _
                                          Optional ByVal iPOID As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim iShipToID As Integer = 0

            Try
                '************************
                'Insert into TDriveCamData
                '************************
                strSql = "INSERT INTO tshipto ( " & Environment.NewLine
                strSql &= " CompanyName, ShipTo_Name, ShipTo_Address1, ShipTo_Address2, ShipTo_City, ShipTo_Zip, State_Id, Cntry_ID, Tel, Fax, Email, PO_ID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strCompany & " ', '" & strShipToName & "', '" & strAddress1 & "', '" & strAddress2 & "', '" & strCity & "', '" & strZipCode & "' " & Environment.NewLine
                strSql &= ", " & iStatesID & ", " & iCountriesCodeID & ", '" & strPhoneNumber & "', '" & strFaxNumber & "', '" & strEmailAddress & "' " & Environment.NewLine
                strSql &= ", " & iPOID & Environment.NewLine
                strSql &= ");"

                iShipToID = Me.objMisc.idTransaction(strSql, "tshipto")

                If iShipToID = 0 Then iShipToID = SelectShipToID(strShipToName, strAddress1, strAddress2, strCity, iStatesID, strZipCode, _
                                           iCountriesCodeID, strPhoneNumber, strFaxNumber, strEmailAddress, iPOID)

                Return iShipToID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function UpdateTShipToInfo(ByVal iShipToID As Integer, ByVal strCompany As String, ByVal strShipToName As String, ByVal strAddress1 As String, ByVal strAddress2 As String, _
                                          ByVal strCity As String, ByVal iStatesID As Integer, ByVal strZipCode As String, _
                                          ByVal iCountriesCodeID As Integer, ByVal strPhoneNumber As String, ByVal strFaxNumber As String, _
                                          ByVal strEmailAddress As String) As Integer
            Dim strSql As String = ""

            Try
                '************************
                'Insert into TDriveCamData
                '************************
                strSql = "UPDATE tshipto SET " & Environment.NewLine
                strSql &= " CompanyName = '" & strCompany & " ', ShipTo_Name = '" & strShipToName & "', ShipTo_Address1 = '" & strAddress1 & "' " & Environment.NewLine
                strSql &= ", ShipTo_Address2 = '" & strAddress2 & "', ShipTo_City = '" & strCity & "', ShipTo_Zip = '" & strZipCode & "' " & Environment.NewLine
                strSql &= ", State_Id = " & iStatesID & ", Cntry_ID = " & iCountriesCodeID & ", Tel = '" & strPhoneNumber & "' " & Environment.NewLine
                strSql &= ", Fax = '" & strFaxNumber & "', Email = '" & strEmailAddress & "'" & Environment.NewLine
                strSql &= "WHERE ShipTo_ID = " & iShipToID

                Return Me.objMisc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '********************************************************************
        Public Function SelectShipToID(ByVal strShipToName As String, ByVal strAddress1 As String, ByVal strAddress2 As String, _
                                          ByVal strCity As String, ByVal iStatesID As Integer, ByVal strZipCode As String, _
                                          ByVal iCountriesCodeID As Integer, ByVal strPhoneNumber As String, ByVal strFaxNumber As String, _
                                          ByVal strEmailAddress As String, ByVal iPOID As Integer) As Integer
            Dim strSql As String = ""

            Try
                '************************
                'Insert into TDriveCamData
                '************************
                strSql = "SELECT ShipTo_ID FROM tshipto WHERE " & Environment.NewLine
                strSql &= " ShipTo_Name = '" & strShipToName & "' AND ShipTo_Address1 = '" & strAddress1 & "' AND ShipTo_Address2 = '" & strAddress2 & "' " & Environment.NewLine
                strSql &= "AND ShipTo_City = '" & strCity & "' AND ShipTo_Zip = '" & strZipCode & "' AND State_Id = " & iStatesID & " AND Cntry_ID = " & iCountriesCodeID & Environment.NewLine
                strSql &= "AND Tel = '" & strPhoneNumber & "' AND Fax = '" & strFaxNumber & "'AND Email = '" & strEmailAddress & "' AND PO_ID = " & iPOID & Environment.NewLine
                Return Me.objMisc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetOpenWorkordersList(ByVal iLocID As Integer, ByVal booIncludeShipToInfo As Boolean) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Distinct tworkorder.WO_ID, tworkorder.WO_CustWO, tworkorder.WO_Quantity as 'WO Qty', tworkorder.WO_RAQnty as 'WO Received Qty'" & Environment.NewLine
                strSql &= ", tworkorder.PO_ID, tworkorder.Loc_ID, tworkorder.Group_ID, tworkorder.Prod_ID  " & Environment.NewLine
                If booIncludeShipToInfo = True Then
                    strSql &= ", ShipTo_Name as 'Ship To Name', tshipto.ShipTo_Address1, tshipto.ShipTo_Address2" & Environment.NewLine
                    strSql &= ", tshipto.ShipTo_City, tshipto.ShipTo_Zip, lstate.State_ID, lstate.State_Short, lcountry.Cntry_ID,  lcountry.Cntry_Name" & Environment.NewLine
                    strSql &= ", tshipto.Tel, tshipto.Fax, tshipto.Email" & Environment.NewLine
                End If
                strSql &= "FROM tworkorder " & Environment.NewLine
                If booIncludeShipToInfo = True Then
                    strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                    strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_ID" & Environment.NewLine
                    strSql &= "INNER JOIN lcountry ON lcountry.Cntry_ID = tshipto.Cntry_ID" & Environment.NewLine
                End If
                strSql &= "WHERE tworkorder.Loc_ID = " & iLocID & " And tworkorder.WO_Closed = 0 AND tworkorder.InvalidOrder = 0 " & Environment.NewLine
                strSql &= "ORDER BY 'WO_CustWO' "
                Return Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetModelList(ByVal booAddSelectRow As Boolean, _
                                     Optional ByVal iProdID As Integer = 0, _
                                     Optional ByVal iManufID As Integer = 0) As DataTable
            Dim strSql, strCriteria As String
            Dim dt As DataTable

            Try
                strSql = "" : strCriteria = ""
                strSql = "SELECT tmodel.Model_ID, tmodel.Model_Desc, Prod_ID, Manuf_ID " & Environment.NewLine
                strSql &= "FROM tmodel " & Environment.NewLine
                If iProdID > 0 Then strCriteria = "WHERE Prod_ID = " & iProdID & Environment.NewLine
                If iManufID > 0 Then
                    If strCriteria.Trim.Length > 0 Then strCriteria &= "AND Manuf_ID = " & iManufID & Environment.NewLine Else strCriteria &= "WHERE Manuf_ID = " & iManufID & Environment.NewLine
                End If
                strSql &= strCriteria
                strSql &= "ORDER BY Model_Desc " & Environment.NewLine
                dt = Me.objMisc.GetDataTable(strSql)
                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetWorkorderInfo(ByVal strRMANo As String, _
                                         Optional ByVal iCustID As Integer = 0, _
                                         Optional ByVal iLocID As Integer = 0) As DataRow
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow = Nothing

            Try
                strSql = "SELECT tworkorder.* FROM tworkorder " & Environment.NewLine
                If iCustID > 0 Then strSql &= "INNER JOIN tlocation ON tworkorder.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "WHERE WO_CustWo = '" & strRMANo & "' AND tworkorder.InvalidOrder = 0 " & Environment.NewLine
                If iLocID > 0 Then strSql &= "AND tworkorder.Loc_ID = " & iLocID & Environment.NewLine
                If iCustID > 0 Then strSql &= "AND tlocation.Cust_ID = " & iCustID & Environment.NewLine
                dt = Me.objMisc.GetDataTable(strSql)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("WO/RMA# " & strRMANo & " existed in the system more than one. Please contact IT.")
                ElseIf dt.Rows.Count = 1 Then
                    R1 = dt.Rows(0)
                End If
                Return R1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetReceivedDeviceInWO(ByVal iWOID As Integer, ByVal booIncludeCelloptSN As Boolean, _
                                              ByVal booIncludeMessData As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer

            Try
                strSql = "SELECT 0 as 'Cnt', Model_Desc as 'Model', Device_SN " & Environment.NewLine
                strSql &= ", if( Device_ManufWrty = 1, 'Yes', 'No') as 'Manuf Warranty?' " & Environment.NewLine
                strSql &= ", if( Device_PSSWrty = 1, 'Yes', 'No') as 'PSS Warranty?' " & Environment.NewLine
                strSql &= ", Device_DateRec as 'Received Date' " & Environment.NewLine
                If booIncludeCelloptSN = True Then strSql &= ", CellOpt_MSN " & Environment.NewLine
                If booIncludeMessData = True Then
                    strSql &= ", if (capcode is null, '', capcode) as 'Capcode' " & Environment.NewLine
                    strSql &= ", if (freq_Number is null, '', freq_Number) as 'Frequency #' " & Environment.NewLine
                    strSql &= ", if (baud_Number is null, '', baud_Number) as 'Baud Rate' " & Environment.NewLine
                End If
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                If booIncludeCelloptSN = True Then strSql &= "INNER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                If booIncludeMessData = True Then
                    strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lfrequency ON tmessdata.Freq_ID = lfrequency.Freq_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lbaud ON tmessdata.baud_id = lbaud.baud_id " & Environment.NewLine
                End If
                strSql &= "WHERE tdevice.WO_ID = " & iWOID & Environment.NewLine
                strSql &= "ORDER BY tdevice.Device_ID " & Environment.NewLine
                dt = Me.objMisc.GetDataTable(strSql)

                For i = 1 To dt.Rows.Count
                    dt.Rows(i - 1).BeginEdit() : dt.Rows(i - 1)("Cnt") = i : dt.Rows(i - 1).EndEdit()
                Next i
                dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetTrayID(ByVal iWOID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Tray_ID FROM ttray WHERE WO_ID = " & iWOID & Environment.NewLine
                Return Me.objMisc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetWorkorderShipToInfoList(ByVal iLocID As Integer, ByVal booAddSelectRow As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT Distinct tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= ", ShipTo_Name, tshipto.CompanyName, tshipto.ShipTo_Address1, tshipto.ShipTo_Address2" & Environment.NewLine
                strSql &= ", tshipto.ShipTo_City, tshipto.ShipTo_Zip, lstate.State_ID, lstate.State_Short, lcountry.Cntry_ID,  lcountry.Cntry_Name" & Environment.NewLine
                strSql &= ", tshipto.Tel, tshipto.Fax, tshipto.Email" & Environment.NewLine
                strSql &= "FROM tworkorder " & Environment.NewLine
                strSql &= "INNER JOIN tshipto ON tworkorder.ShipTo_ID = tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcountry ON lcountry.Cntry_ID = tshipto.Cntry_ID" & Environment.NewLine
                strSql &= "WHERE tworkorder.Loc_ID = " & iLocID & Environment.NewLine
                strSql &= "ORDER BY ShipTo_Name "
                dt = Me.objMisc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--", ""}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetShipToAddress(ByVal iShipTo_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Distinct tshipto.ShipTo_ID" & Environment.NewLine
                strSql &= ", ShipTo_Name, tshipto.CompanyName, tshipto.ShipTo_Address1, tshipto.ShipTo_Address2" & Environment.NewLine
                strSql &= ", tshipto.ShipTo_City, tshipto.ShipTo_Zip, lstate.State_ID, lstate.State_Short, lcountry.Cntry_ID,  lcountry.Cntry_Name" & Environment.NewLine
                strSql &= ", tshipto.Tel, tshipto.Fax, tshipto.Email" & Environment.NewLine
                strSql &= "FROM tshipto " & Environment.NewLine
                strSql &= "INNER JOIN lstate ON tshipto.State_Id = lstate.State_ID" & Environment.NewLine
                strSql &= "INNER JOIN lcountry ON lcountry.Cntry_ID = tshipto.Cntry_ID" & Environment.NewLine
                strSql &= "WHERE tshipto.ShipTo_ID = " & iShipTo_ID & Environment.NewLine
                Return Me.objMisc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetCostCenterLists(ByVal booAddSelectRow As Boolean, ByVal iGroupID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT tcostcenter.cc_id, concat(Group_Desc, '-', tcostcenter.cc_desc) as cc_desc " & Environment.NewLine
                strSql &= "FROM tcostcenter " & Environment.NewLine
                strSql &= "INNER JOIN lgroups ON tcostcenter.Group_ID = lgroups.Group_ID " & Environment.NewLine
                strSql &= "WHERE tcostcenter.Group_ID = " & iGroupID & Environment.NewLine
                dt = Me.objMisc.GetDataTable(strSql)

                If booAddSelectRow = True Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function InsertIntoTmessdata(ByVal iWOID As Integer, ByVal iDeviceID As Integer, ByVal strCap As String, _
                                            ByVal strSku As String, ByVal iBaudID As Integer, ByVal iFreqID As Integer, _
                                            ByVal iCameWithFile As Integer) As Integer
            Dim strSql As String = ""
            Try
                'write device to tmessdata table
                strSql = "INSERT INTO tmessdata " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "capcode, " & Environment.NewLine
                strSql &= "SKU, " & Environment.NewLine
                strSql &= "baud_id, " & Environment.NewLine
                strSql &= "freq_id, " & Environment.NewLine
                strSql &= "CameWithFileFlag, " & Environment.NewLine
                strSql &= "wo_id, " & Environment.NewLine
                strSql &= "device_id, " & Environment.NewLine
                strSql &= "wipowner_id, " & Environment.NewLine
                strSql &= "wipowner_EntryDt " & Environment.NewLine
                strSql &= ") " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= "'" & strCap & "', " & Environment.NewLine
                strSql &= "'" & strSku & "', " & Environment.NewLine
                strSql &= iBaudID & ", " & Environment.NewLine
                strSql &= iFreqID & ", " & Environment.NewLine
                strSql &= iCameWithFile & ", " & Environment.NewLine
                strSql &= iWOID & ", " & Environment.NewLine
                strSql &= iDeviceID & Environment.NewLine
                strSql &= ", 1 " & Environment.NewLine
                strSql &= ", now() " & Environment.NewLine
                strSql &= ");"

                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetRepeatRepCnt(ByVal iLOCID As Integer, ByVal strPSSSN As String) As Integer
            Dim strSql As String = ""
            Try
                'write device to tmessdata table
                strSql = "SELECT Count(*) as cnt FROM tdevice WHERE Loc_ID = " & iLOCID & " AND Device_SN = '" & strPSSSN & "'" & Environment.NewLine

                Return Me.objMisc.GetIntValue(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function GetPrevRep(ByVal strDeviceSn As String, ByVal iLocID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT tdevice.Device_ID, Device_DateShip, CustWrty_DaysinWrty, tdevice.Device_PSSWrty, max(BillCode_Rule) as 'MaxBillRule' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tcustwrty ON tlocation.Cust_ID = tcustwrty.Cust_ID AND tmodel.Prod_ID = tcustwrty.Prod_ID  " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.device_ID = tdevicebill.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.billcode_ID" & Environment.NewLine
                strSql &= "WHERE tdevice.Loc_ID = " & iLocID & " AND Device_SN = '" & strDeviceSn & "'" & Environment.NewLine
                strSql &= "Group by tdevice.Device_ID " & Environment.NewLine
                strSql &= "ORDER BY tdevice.Device_DateShip Desc"
                Return Me.objMisc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function IsDeviceUnderPSSWrty_BaseOnProdShipDate(ByVal strDeviceSn As String, ByVal iLocID As Integer, ByRef iWrtyOnDeviceID As Integer) As Integer
            Dim strSql, strToday As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iPSSWrty As Integer = 0

            Try
                iWrtyOnDeviceID = 0
                dt = GetPrevRep(strDeviceSn, iLocID)

                strSql = "SELECT Date_Format(now(), '%Y-%m-%d') as 'Today' " & Environment.NewLine
                strToday = Me.objMisc.GetSingletonString(strSql)

                For Each R1 In dt.Rows
                    If R1("Device_PSSWrty").ToString.Trim = "0" AndAlso R1("MaxBillRule").ToString.Trim = "0" _
                       AndAlso DateDiff(DateInterval.Day, Convert.ToDateTime(R1("Device_DateShip")), Convert.ToDateTime(strToday)) <= Convert.ToInt32(R1("CustWrty_DaysinWrty")) Then
                        iPSSWrty = 1 : iWrtyOnDeviceID = R1("Device_ID") : Exit For
                    End If
                Next R1

                Return iPSSWrty

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************
        Public Function AddDeviceAccessories(ByVal iDeviceID As String, ByVal arlstAccessories As ArrayList, ByVal iUserID As Integer) As Integer
            Dim strSql As String
            Dim i, j As Integer
            Dim dt As DataTable

            Try
                For i = 0 To arlstAccessories.Count - 1
                    strSql = "SELECT * FROM tdevicerecaccessories WHERE Device_ID = " & iDeviceID & " AND A_ID = " & arlstAccessories(i)
                    dt = Me.objMisc.GetDataTable(strSql)
                    If dt.Rows.Count = 0 Then
                        strSql = "INSERT INTO tdevicerecaccessories ( Device_ID, A_ID, User_ID, RecDate " & Environment.NewLine
                        strSql &= ") VALUES ( " & Environment.NewLine
                        strSql &= iDeviceID & ", " & arlstAccessories(i) & ", " & iUserID & ", now() " & Environment.NewLine
                        strSql &= ") "
                        j += Me.objMisc.ExecuteNonQuery(strSql)
                    End If
                Next i

                Return j
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************************************************

    End Class
End Namespace


