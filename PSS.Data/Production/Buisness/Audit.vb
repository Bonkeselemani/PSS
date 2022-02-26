
Namespace Buisness

    Public Class Audit
        Private objMisc As Production.Misc
        Private strsql As String
        'Private ObjLib As MyLib.Utility

        Public Function RobertMcVey() As Integer
            Dim dtATCLE, dt1, dtWIP As DataTable
            Dim R1, R2 As DataRow
            Dim i As Integer = 0

            Dim strShipDt As String = ""
            Dim strPSSWO As String = ""
            Dim strPSSModel As String = ""
            Dim iFound As Integer = 0

            Dim iInWIPAsking As Integer = 0
            Dim iNotInWIPAsking As Integer = 0
            Dim iNotInDBAsking As Integer = 0
            Dim iShippedCorrectWO As Integer = 0

            Dim iInwip_asking, iNotinwip_asking, iNotindb_asking, iWOMatched, iInWIP_NotAsking As Integer

            Try
                'Step 1
                strsql = "Select * from _imei;"
                objMisc._SQL = strsql
                dtATCLE = objMisc.GetDataTable()

                For Each R1 In dtATCLE.Rows
                    strsql = "Select device_id, device_dateship, wo_custwo, model_desc from tdevice inner join tmodel on tdevice.model_id = tmodel.model_id inner join tworkorder on tdevice.wo_id = tworkorder.wo_id where device_sn = '" & Trim(R1("dtlnum")) & "' and wo_custwo like '" & Left(Trim(R1("stoloc")), 11) & "%' order by Device_id desc;"
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable()

                    If dt1.Rows.Count > 0 Then
                        R2 = dt1.Rows(0)
                        If Not IsDBNull(R2("Device_dateship")) Then
                            strShipDt = Trim(R2("Device_dateship"))
                        End If
                        If Not IsDBNull(R2("wo_custwo")) Then
                            strPSSWO = Trim(R2("wo_custwo"))
                        End If
                        If Not IsDBNull(R2("model_desc")) Then
                            strPSSModel = Trim(R2("model_desc"))
                        End If

                        If strShipDt = "" Then
                            iFound = 1          'In db, in wip, right wo
                        Else
                            iFound = 2          'In db, not in wip, right wo
                        End If
                    Else
                        'Check if it exists in the database at all
                        strsql = "Select device_id, device_dateship, wo_custwo, model_desc from tdevice inner join tmodel on tdevice.model_id = tmodel.model_id inner join tworkorder on tdevice.wo_id = tworkorder.wo_id where device_sn = '" & Trim(R1("dtlnum")) & "' order by Device_id desc;"
                        objMisc._SQL = strsql
                        dt1 = objMisc.GetDataTable()
                        If dt1.Rows.Count > 0 Then
                            R2 = dt1.Rows(0)
                            If Not IsDBNull(R2("Device_dateship")) Then
                                strShipDt = Trim(R2("Device_dateship"))
                            End If
                            If Not IsDBNull(R2("wo_custwo")) Then
                                strPSSWO = Trim(R2("wo_custwo"))
                            End If
                            If Not IsDBNull(R2("model_desc")) Then
                                strPSSModel = Trim(R2("model_desc"))
                            End If

                            If strShipDt = "" Then
                                iFound = 3          'In db, in wip, wrong wo
                            Else
                                iFound = 4          'In db, not in wip, wrong wo
                            End If
                        End If
                    End If
                    '*******************************
                    'Analysis
                    Select Case iFound
                        Case 1      'In db, in wip, right wo
                            iInwip_asking = 1       '1 - Yes; 0 - No
                            iNotinwip_asking = 0    '1 - Yes; 0 - No
                            iNotindb_asking = 0     '1 - Yes; 0 - No
                            iWOMatched = 1  '1 - Yes; 0 - No

                        Case 2      'In db, not in wip, right wo
                            iInwip_asking = 0       '1 - Yes; 0 - No
                            iNotinwip_asking = 1    '1 - Yes; 0 - No
                            iNotindb_asking = 0     '1 - Yes; 0 - No
                            iWOMatched = 1  '1 - Yes; 0 - No

                        Case 3      'In db, in wip, wrong wo
                            iInwip_asking = 1       '1 - Yes; 0 - No
                            iNotinwip_asking = 0    '1 - Yes; 0 - No
                            iNotindb_asking = 0     '1 - Yes; 0 - No
                            iWOMatched = 0  '1 - Yes; 0 - No

                        Case 4      'In db, not in wip, wrong wo
                            iInwip_asking = 0       '1 - Yes; 0 - No
                            iNotinwip_asking = 1    '1 - Yes; 0 - No
                            iNotindb_asking = 0     '1 - Yes; 0 - No
                            iWOMatched = 0  '1 - Yes; 0 - No

                        Case 0      'not in DB, not in wip, wrong wo
                            iInwip_asking = 0       '1 - Yes; 0 - No
                            iNotinwip_asking = 1    '1 - Yes; 0 - No
                            iNotindb_asking = 1     '1 - Yes; 0 - No
                            iWOMatched = 0  '1 - Yes; 0 - No

                    End Select
                    '*******************************
                    'Update the _imei table
                    strsql = "Update _imei set InWIP_Asking = " & iInwip_asking & ", " & Environment.NewLine
                    strsql += "NotInWIP_Asking = " & iNotinwip_asking & ", " & Environment.NewLine
                    strsql += "NotInDB_Asking = " & iNotindb_asking & ", " & Environment.NewLine
                    strsql += "WOMatched = " & iWOMatched & ", " & Environment.NewLine
                    strsql += "pss_model = '" & strPSSModel & "', " & Environment.NewLine
                    strsql += "pss_wo = '" & strPSSWO & "', " & Environment.NewLine
                    If strShipDt = "" Then
                        strsql += "pss_dateship = NULL " & Environment.NewLine
                    Else
                        If strShipDt = "000-00-00 00:00:00" Then
                            strsql += "pss_dateship = NULL " & Environment.NewLine
                        Else
                            strsql += "pss_dateship = '" & Format(CDate(strShipDt), "yyyy-MM-dd HH:mm:ss") & "' " & Environment.NewLine
                        End If

                    End If

                    strsql += "where DID = " & R1("DID") & ";"
                    objMisc._SQL = strsql
                    i = objMisc.ExecuteNonQuery

                    '*******************************
                    'Reset variables
                    strShipDt = ""
                    strPSSWO = ""
                    strPSSModel = ""
                    iFound = 0
                    '*******************************
                Next R1


                '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                'GetWIP
                strsql = "Select Device_ID, Device_SN, Device_dateship, model_desc, wo_custwo from tdevice " & Environment.NewLine
                strsql += "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strsql += "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strsql += "where device_dateship is null and tdevice.loc_id = 2540 and device_daterec > '2005-12-01 00:00:00' and (device_dateship is null or trim(device_dateship) = '') order by device_id desc;"
                objMisc._SQL = strsql
                dtWIP = objMisc.GetDataTable()

                iFound = 0
                For Each R1 In dtWIP.Rows
                    For Each R2 In dtATCLE.Rows
                        If Trim(R1("Device_SN")) = Trim(R2("dtlnum")) Then
                            iFound = 1
                        End If
                    Next R2
                    '****************************
                    If iFound = 0 Then
                        strsql = "Insert into _imei (" & Environment.NewLine
                        strsql += "dtlnum, " & Environment.NewLine
                        strsql += "InWIP_NotAsking, " & Environment.NewLine
                        strsql += "PSS_Model, " & Environment.NewLine
                        strsql += "PSS_WO, " & Environment.NewLine
                        strsql += "PSS_dateShip) values (" & Environment.NewLine
                        strsql += "'" & Trim(R1("Device_SN")) & "', " & Environment.NewLine
                        strsql += 1 & ", " & Environment.NewLine
                        strsql += "'" & Trim(R1("Model_Desc")) & "', " & Environment.NewLine
                        strsql += "'" & Trim(R1("wo_custwo")) & "', " & Environment.NewLine

                        If Not IsDBNull(R1("Device_dateship")) Then
                            If Len(Trim(R1("Device_dateship"))) > 0 Then
                                If Trim(R1("Device_dateship")) = "0000-00-00 00:00:00" Then
                                    strsql += "NULL);"
                                Else
                                    strsql += "'" & Format(CDate(R1("Device_dateship")), "yyyy-MM-dd HH:mm:ss") & "');"
                                End If
                            Else
                                strsql += "NULL);"
                            End If
                        Else
                            strsql += "NULL);"
                        End If

                        objMisc._SQL = strsql
                        i = objMisc.ExecuteNonQuery
                    End If
                    '****************************
                    iFound = 0
                Next R1




                Return 1
                '************************************************************
            Catch ex As Exception
                MsgBox(ex)
            Finally

                R1 = Nothing
                R2 = Nothing

                If Not IsNothing(dtATCLE) Then
                    dtATCLE.Dispose()
                    dtATCLE = Nothing
                End If
                
                If Not IsNothing(dtWIP) Then
                    dtWIP.Dispose()
                    dtWIP = Nothing
                End If
                
            End Try
        End Function

        '***************************************************
        'Get Device Billing History
        '***************************************************
        Public Function GetDeviceBillingHistory(ByVal strDevice_SN As String) As DataSet
            Dim dtReplacement, dtResolder As DataTable
            Dim ds As New DataSet()

            Try
                strsql = "Select tdevice.Device_id as 'Device ID' " & Environment.NewLine
                strsql += ", IF (Trans_Amount = 1, 'Added', 'Removed') AS Transaction " & Environment.NewLine
                strsql += ", tparttransaction.Date_rec as 'Transaction Date' " & Environment.NewLine
                strsql += ", lbillcodes.billcode_desc 'Part/Service' " & Environment.NewLine
                'strsql += ", BinLoc as 'Bin Location', " & Environment.NewLine
                'strsql += ", Security.tusers.EmployeeNo as 'PSSI Employee #' " & Environment.NewLine
                strsql += ", Security.tusers.user_fullname as 'Tech Name' " & Environment.NewLine
                'strsql += ", Security.tusers.tech_id as 'Tech ID' " & Environment.NewLine
                strsql += ", IF( Fail_SDesc is null, '', Fail_SDesc) as 'Fail Code', IF( Fail_LDesc is null, '', Fail_LDesc) as 'Fail Description' " & Environment.NewLine
                strsql += "from tparttransaction " & Environment.NewLine
                strsql += "inner join tdevice on tdevice.device_id = tparttransaction.device_id " & Environment.NewLine
                strsql += "inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strsql += "left outer join security.tusers on production.tparttransaction.user_id =  security.tusers.user_id " & Environment.NewLine
                strsql += "left outer join tdevicebill on tdevice.device_ID = tdevicebill.device_id and tparttransaction.billcode_id = tdevicebill.billcode_id and tparttransaction.Trans_Amount = 1 " & Environment.NewLine
                strsql += "left outer join lfailcodes on tdevicebill.Fail_ID =  lfailcodes.Fail_ID " & Environment.NewLine
                strsql += "where tdevice.device_sn = '" & strDevice_SN & "' " & Environment.NewLine
                strsql += "order by tparttransaction.Date_rec Desc;"

                objMisc._SQL = strsql
                dtReplacement = objMisc.GetDataTable
                dtReplacement.TableName = "Replacement"
                ds.Tables.Add(dtReplacement)

                strsql = "Select lbillcodes.billcode_desc 'Resolder On' " & Environment.NewLine
                strsql += ", if(treflowpart.TransactionDate is null, '', treflowpart.TransactionDate) as 'Transaction Date' " & Environment.NewLine
                strsql += ", Security.tusers.EmployeeNo as 'PSSI Employee #' " & Environment.NewLine
                strsql += ", Security.tusers.user_fullname as 'Tech Name' " & Environment.NewLine
                strsql += ", Security.tusers.tech_id as 'Tech ID' " & Environment.NewLine
                strsql += ", IF( Fail_SDesc is null, '', Fail_SDesc) as 'Fail Code' " & Environment.NewLine
                strsql += ", IF( Fail_LDesc is null, '', Fail_LDesc) as 'Fail Description' " & Environment.NewLine
                strsql += "from tdevice " & Environment.NewLine
                strsql += "inner join treflowpart on tdevice.device_id = treflowpart.device_id  " & Environment.NewLine
                strsql += "inner join lbillcodes on treflowpart.billcode_id = lbillcodes.billcode_id " & Environment.NewLine
                strsql += "left outer join security.tusers on production.treflowpart.user_id =  security.tusers.user_id " & Environment.NewLine
                strsql += "left outer join lfailcodes on treflowpart.Fail_ID =  lfailcodes.Fail_ID " & Environment.NewLine
                strsql += "where tdevice.device_sn = '" & strDevice_SN & "' " & Environment.NewLine
                strsql += "order by treflowpart.TransactionDate Desc;" & Environment.NewLine

                objMisc._SQL = strsql
                dtResolder = objMisc.GetDataTable
                dtResolder.TableName = "Resolder"
                ds.Tables.Add(dtResolder)

                Return ds
            Catch ex As Exception
                DisposeDT(dtReplacement) : DisposeDT(dtResolder)
                Throw New Exception("Buisness.Audit.GetDeviceBillingHistory(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function





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

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
    End Class

End Namespace