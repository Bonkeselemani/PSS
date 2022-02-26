
Option Explicit On 

Namespace Buisness
    Public Class MessShip

        Private objMisc As Production.Misc

        '***************************************************
        'Dispose dt
        '***************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        '***************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub

        '***************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        ''**************************************************************
        'Private Function verifyLblCreation(ByVal DeviceID As Integer) As Boolean
        '    Dim dtLabel As DataTable
        '    Dim rLabel As DataRow
        '    Dim blnLabel As Boolean = False
        '    objMisc._SQL = "SELECT DISTINCT label_userid FROM tmessdata WHERE device_id = " & DeviceID
        '    dtLabel = objMisc.GetDataTable
        '    If dtLabel.Rows.Count < 1 Then
        '        Return False '//No Record in tmessdata
        '    ElseIf dtLabel.Rows.Count = 1 Then
        '        rLabel = dtLabel.Rows(0)
        '        If rLabel("label_userid") > 0 Then
        '            blnLabel = True
        '        Else
        '            blnLabel = False
        '        End If
        '    ElseIf dtLabel.Rows.Count > 1 Then
        '        Return False '//Duplicate Records in tmessdata
        '    End If
        '    dtLabel = Nothing
        '    Return blnLabel
        'End Function

        '**************************************************************
        Public Function IsQCPassed(ByVal iDevice_ID As Integer) As Boolean
            Dim strSql As String
            Dim iResutl As Integer

            Try
                strSql = "SELECT count(*) as cnt FROM tqc " & Environment.NewLine
                strSql &= "WHERE Device_id = " & iDevice_ID & Environment.NewLine
                strSql &= "AND QCResult_ID = 1 " & Environment.NewLine
                strSql &= "AND QCType_ID NOT IN (0, 4);"
                iResutl = Me.objMisc.GetIntValue(strSql)
                If iResutl = 0 Then
                    Return False
                Else
                    Return True
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetDeviceFreq(ByVal iDevice_ID As Integer) As String
            Dim strSql As String
            Dim dtFreq As DataTable
            Dim strFreqNum As String

            Try
                strSql = "SELECT DISTINCT freq_number " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata ON tdevice.device_id = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN lfrequency ON tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDevice_ID
                Me.objMisc._SQL = strSql
                dtFreq = objMisc.GetDataTable

                If dtFreq.Rows.Count > 0 Then
                    strFreqNum = dtFreq.Rows(0)("freq_number")
                End If

                Return strFreqNum
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtFreq) Then
                    dtFreq.Dispose()
                    dtFreq = Nothing
                End If
            End Try
        End Function

        '**************************************************************
        Public Function GetShipping_CustomerList() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tcustomer.*, tlocation.loc_name, tlocation.loc_id, tlocation.loc_ManifestDetail, lparentco.PCo_Name " & Environment.NewLine
                strSql &= "FROM lparentco " & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON lparentco.PCo_ID = tcustomer.PCo_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tcustomer.cust_id = tlocation.cust_id " & Environment.NewLine
                strSql &= "WHERE tlocation.loc_name is not null " & Environment.NewLine
                strSql &= "ORDER BY tlocation.Loc_Name asc;"

                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetShipInfo_Fr_PO(ByVal iPO_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT ShipTo_ID, Loc_ID " & Environment.NewLine
                strSql &= "FROM tpurchaseorder " & Environment.NewLine
                strSql &= "WHERE po_id = " & iPO_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetShipInfo_ByShipID(ByVal iShip_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tship " & Environment.NewLine
                strSql &= "WHERE Ship_ID = " & iShip_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetShipToInfo_ByShipToID(ByVal iShipTo_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT *  " & Environment.NewLine
                strSql &= "FROM tshipto " & Environment.NewLine
                strSql &= "WHERE ShipTo_ID = " & iShipTo_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetShipToInfo_ByLocID(ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT *  " & Environment.NewLine
                strSql &= "FROM tshipto " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetLocInfo_ByLoc_ID(ByVal iLoc_ID As Integer) As DataRow
            Dim strSql As String = ""

            Try
                strSql = "SELECT * " & Environment.NewLine
                strSql &= "FROM tlocation " & Environment.NewLine
                strSql &= "WHERE Loc_ID = " & iLoc_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataRow

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetLocInfo_ByLoc_Name(ByVal strLoc_Name As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT *  "
                strSql &= "FROM tlocation " & Environment.NewLine
                strSql &= "WHERE  Loc_Name = '" & strLoc_Name & "';"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetDevices_ByShipID(ByVal iShipID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT *  "
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "WHERE Ship_ID = " & iShipID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '**************************************************************
        Public Function GetMessBilledDeviceInWIP_ByLocID(ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.device_sn, tdevice.wo_id, tdevice.device_id, tdevice.tray_id, tdevice.device_manufwrty, tdevice.Model_ID, " & Environment.NewLine
                strSql &= "tmodel.manuf_id, tmodel.prod_id  " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "WHERE device_DateShip is null " & Environment.NewLine
                strSql &= "AND device_DateBill is not null " & Environment.NewLine
                strSql &= "AND tmodel.prod_id = 1 " & Environment.NewLine
                strSql &= "AND Loc_ID = " & iLoc_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetMessBilledDeviceInWIP_ByShipChangeLocID(ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.*, tcustomer.cust_id, tlocation.loc_name, tmodel.manuf_id, tmodel.prod_id " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "INNER JOIN tshipchange ON tdevice.Loc_ID = tshipchange.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tshipchange.loc_id = tlocation.loc_id" & Environment.NewLine
                strSql &= "INNER JOIN tcustomer ON tlocation.cust_id = tcustomer.cust_ID" & Environment.NewLine
                strSql &= "WHERE device_DateShip is null " & Environment.NewLine
                strSql &= "AND device_DateBill is not null " & Environment.NewLine
                strSql &= "AND tmodel.prod_id = 1 " & Environment.NewLine
                strSql &= "AND tshipchange.Loc_id_To =  = " & iLoc_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetAllStatesInfo() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM lstate;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetShipChangeInfo_ByLocID(ByVal iLoc_ID) As DataRow
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tshipchange WHERE Loc_ID = " & iLoc_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataRow

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetCCbyCustID(ByVal iCust_ID As Integer) As DataRow
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tcreditcard WHERE Cust_ID = " & iCust_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataRow

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetCustomerInfo_ByCustID(ByVal iCust_ID As Integer) As DataRow
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tcustomer WHERE Cust_ID =  " & iCust_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataRow

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetAllState() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM lstate;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetAllCountry() As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM lcountry;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function Ship_CheckDupDevice(ByVal strDevice_SN As String, _
                                                  ByVal iLoc_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.*, tmodel.model_desc, lmanuf.manuf_desc " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "INNER JOIN lmanuf ON tmodel.manuf_id = lmanuf.manuf_id " & Environment.NewLine
                strSql &= "WHERE tdevice.device_SN = '" & strDevice_SN & "' " & Environment.NewLine
                strSql &= "AND tdevice.Loc_ID = " & iLoc_ID & " " & Environment.NewLine
                strSql &= "AND tdevice.device_datebill is not null " & Environment.NewLine
                strSql &= "AND tdevice.device_dateship is null;"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function CheckDeviceDBR(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT lbillcodes.billcode_rule " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = " & iDevice_ID & " " & Environment.NewLine
                strSql &= "AND (lbillcodes.billcode_rule= 1 OR lbillcodes.billcode_rule = 2);"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetWorkOrderInfo_ByWOID(ByVal iWO_ID As Integer) As DataRow
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tworkorder WHERE WO_ID = " & iWO_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataRow

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetTrayWOLocInfo_ByTrayID(ByVal iTray_ID As Integer) As DataRow
            Dim strSql As String = ""

            Try
                strSql = "SELECT tlocation.*, ttray.* " & Environment.NewLine
                strSql &= "FROM ttray " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder ON ttray.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tworkorder.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "WHERE ttray.Tray_ID = " & iTray_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataRow

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetAllBillInfo_ByDevicceID(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM tdevicebill WHERE device_Id = " & iDevice_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetTrayInfo_ByTrayID(ByVal iTray_ID As Integer) As DataRow
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM ttray WHERE tray_id = " & iTray_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataRow

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function InsertInto_tshipto(ByVal strName As String, _
                                           ByVal strAdd1 As String, _
                                           ByVal strAdd2 As String, _
                                           ByVal strCity As String, _
                                           ByVal strZip As String, _
                                           ByVal strState As String, _
                                           ByVal strCountry As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO tshipto (" & Environment.NewLine
                strSql &= "ShipTo_Name " & Environment.NewLine
                strSql &= ", ShipTo_Address1 " & Environment.NewLine
                strSql &= ", ShipTo_Address2 " & Environment.NewLine
                strSql &= ", ShipTo_City " & Environment.NewLine
                strSql &= ", ShipTo_Zip " & Environment.NewLine
                strSql &= ", State_ID " & Environment.NewLine
                strSql &= ", Cntry_ID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strName & "'" & Environment.NewLine
                strSql &= ", '" & strAdd1 & "'" & Environment.NewLine
                strSql &= ", '" & strAdd2 & "'" & Environment.NewLine
                strSql &= ", '" & strCity & "'" & Environment.NewLine
                strSql &= ", '" & strZip & "'" & Environment.NewLine
                strSql &= ", " & strState & Environment.NewLine
                strSql &= ", " & strCountry & ")"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.idTransaction(strSql, "tshipto")

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function ExecuteIDTransaction(ByVal strSql As String, _
                                             ByVal strTableName As String) As Integer
            Try
                Return Me.objMisc.idTransaction(strSql, strTableName)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function UpdateShipInfo(ByVal iShipID As Integer, _
                                       ByVal iShiftID As Integer, _
                                       ByVal strWorkDt As String, _
                                       ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim strServerDT As String = ""

            Try
                strServerDT = Generic.MySQLServerDateTime(1)

                strSql = "UPDATE tdevice "
                strSql &= "SET tdevice.Ship_ID = " & iShipID & Environment.NewLine
                strSql &= ", tdevice.device_DateShip = '" & strServerDT & "' " & Environment.NewLine
                strSql &= ", Shift_ID_Ship = " & iShiftID & Environment.NewLine
                strSql &= ", Device_ShipWorkdate = '" & strWorkDt & "' " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDevice_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function UpdateCellopt_RepStatus(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "UPDATE tcellopt "
                strSql &= "SET SET tcellopt.RepairStatus = 'SHP' " & Environment.NewLine
                strSql &= "WHERE tcellopt.Device_ID = " & iDevice_ID & ";"
                Me.objMisc._SQL = strSql
                Return Me.objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetFreqOfShipID(ByVal strShipID As String) As String
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim strFreqNum As String = ""

            Try
                strSql = "SELECT distinct lfrequency.freq_Number " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmessdata on tdevice.Device_ID = tmessdata.device_id " & Environment.NewLine
                strSql &= "INNER JOIN lfrequency on tmessdata.freq_id = lfrequency.freq_id " & Environment.NewLine
                strSql &= "WHERE Ship_ID = " & strShipID & ";"

                Me.objMisc._SQL = strSql
                dt1 = Me.objMisc.GetDataTable

                If dt1.Rows.Count = 1 Then
                    strFreqNum = dt1.Rows(0)("freq_Number")
                End If

                Return strFreqNum

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
        Public Function UpdateWIPOwner(ByVal iShipID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tdevice, tmessdata SET tmessdata.wipowner_id_Old = tmessdata.wipowner_id " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_id = 5 " & Environment.NewLine
                strSql &= ", tmessdata.wipowner_EntryDt =  '" & PSS.Data.Buisness.Generic.MySQLServerDateTime(1) & "' " & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = tmessdata.device_id AND Ship_ID = " & iShipID & ";"
                Me.objMisc._SQL = strSql
                Return objMisc.ExecuteNonQuery
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function CheckPSSWrty(ByVal iDeviceID As Integer, _
                                     ByVal iWOID As Integer, _
                                     ByVal iLocID As Integer, _
                                     ByVal iUsrID As Integer, _
                                     Optional ByVal strWOName As String = "") As Integer
            Dim strSql As String
            Dim i As Integer
            Dim dt As DataTable
            Dim objQC As QC

            Try
                If strWOName.Trim.Length = 0 Then
                    strWOName = Generic.GetWONameByWOID(iWOID)
                End If

                If strWOName.Trim.StartsWith("QR") = True Then
                    objQC = New QC()
                    dt = objQC.GetQRData(True, iWOID, iLocID, Nothing, iDeviceID)

                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("QR Categories") = 11 Then
                            strSql = "UPDATE tdevice, tmessdata " & Environment.NewLine
                            strSql &= "SET Device_LaborCharge = 0.00, Device_PSSWrty = 1 " & Environment.NewLine
                            strSql &= ", QR_PSSWtyUpdateDT = now(), QR_PSSWtyUpdateUsrID = " & iUsrID & Environment.NewLine
                            strSql &= "WHERE tdevice.Device_ID = tmessdata.Device_ID AND tdevice.device_id = " & iDeviceID & ";"
                            Me.objMisc._SQL = strSql
                            i = objMisc.ExecuteNonQuery
                        End If
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt)
                objQC = Nothing
            End Try
        End Function

        '**************************************************************


    End Class

End Namespace
