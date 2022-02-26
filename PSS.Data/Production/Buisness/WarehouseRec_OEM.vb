Option Explicit On 

Namespace Buisness
    Public Class WarehouseRec_OEM
        Const _strNullDateFormat As String = "{0} IS NULL OR LENGTH(TRIM({0})) = 0 OR {0} = '0000-00-00 00:00:00' "
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

        '**************************************************************
        Public Function GetWHPalletInfo(ByVal iCust_id As Integer, _
                                        ByVal strWHPallet_Number As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "select tmodel.Model_Desc, twarehousepallet.* from twarehousepallet " & Environment.NewLine
                strSql &= "inner join tmodel on twarehousepallet.model_id = tmodel.model_id " & Environment.NewLine
                strSql &= "where cust_id = " & iCust_id & " and " & Environment.NewLine
                strSql &= "WHPallet_Number = '" & strWHPallet_Number & "';"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetDevCountFromLoadedFile(ByVal iWHPalletID As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "select count(*) from twarehousepalletload " & Environment.NewLine
                strSql &= "where WHPallet_ID = " & iWHPalletID
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetAcceptedRejectedDevices(ByVal iWHPalletID As Integer, ByVal iAcceptRej As Integer) As Integer
            Dim strSql As String = ""

            Try
                strSql = "select count(*) from twarehousereceive " & Environment.NewLine
                strSql &= "where WHPallet_ID = " & iWHPalletID & Environment.NewLine
                strSql &= "AND WHR_Result  = " & iAcceptRej & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetCurrentWeek() As Integer
            Dim strSql As String = ""

            Try
                strSql = "select WEEK(now()) " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetCurrentYr() As Integer
            Dim strSql As String = ""

            Try
                strSql = "select RIGHT(YEAR(now()),1) " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function IsExistedInWHR(ByVal strIMEI As String, _
                                       ByVal iWHP_ID As Integer) As Boolean
            Dim strSql As String = ""

            Try
                strSql = "select count(*) from twarehousereceive " & Environment.NewLine
                strSql &= "WHERE WHPallet_ID = " & iWHP_ID & Environment.NewLine
                strSql &= "AND WHR_Dev_SN = '" & strIMEI & "' " & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function GetWHPLoadID(ByVal strIMEI As String, _
                                     ByVal iWHPallet_ID As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT twarehousepalletload.WHP_ID from twarehousepalletload " & Environment.NewLine
                strSql &= "WHERE WHPallet_ID = " & iWHPallet_ID & Environment.NewLine
                strSql &= "AND WHP_PieceIdentifier = '" & strIMEI & "' " & Environment.NewLine
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function LoadDockDescrepancies(ByVal iWHPallet_ID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT WHR_ID " & Environment.NewLine
                strSql &= ", IF(WHR_DevSN_Absent_in_file = 0, '', 'X') as 'Device SN not in file' " & Environment.NewLine
                strSql &= ", IF(WHR_WrongSKU = 0, '', 'X') as 'Wrong SKU' " & Environment.NewLine
                strSql &= "FROM twarehousereceive " & Environment.NewLine
                strSql &= "WHERE WHPallet_ID = " & iWHPallet_ID & Environment.NewLine
                strSql &= "AND WHR_Result  = 1 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Public Function ProcessSerialNumbers(ByVal strSN As String, _
                                          ByVal strIMEI As String, _
                                          ByVal iWrty As Integer, _
                                          ByVal iWrongSKU As Integer, _
                                          ByVal iWHP_ID As Integer, _
                                          ByVal iWHPallet_ID As Integer, _
                                          ByVal iTranfWIP As Integer, _
                                          ByVal iUsrID As Integer, _
                                          ByVal iModel_ID As Integer) As Integer
            Dim strFields As String = ""
            Dim strValues As String = ""
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0
            Dim iDevSN_Absent_in_File As Integer = 0
            Dim iWHRResult As Integer = 0
            Dim iWHR_ID As Integer

            Try
                If iWHP_ID = 0 Then
                    iDevSN_Absent_in_File = 1
                End If

                If iDevSN_Absent_in_File > 0 Or iWrongSKU > 0 Then
                    iWHRResult = 1
                End If

                '************************************************
                'Check if device already exist in this twarehousereceive
                '************************************************
                strSql = "select count(*) as cnt from twarehousereceive where WHR_dev_SN = '" & strIMEI & "' and WHPallet_ID = " & iWHPallet_ID & ";"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows(0)("cnt") > 0 Then
                    Throw New Exception("This Serial Number already scanned in.")
                End If

                '******************************************
                'insert device into twarehousereceive
                '******************************************
                strFields &= "WHR_Dev_SN " & Environment.NewLine
                strValues &= "'" & strIMEI & "' " & Environment.NewLine
                strFields &= ", WHR_Box_SN " & Environment.NewLine
                strValues &= ", null " & Environment.NewLine
                strFields &= ", WHR_DateLoaded " & Environment.NewLine
                strValues &= ", now() " & Environment.NewLine
                strFields &= ", WHR_WIPOwner " & Environment.NewLine
                strValues &= ", " & iTranfWIP & " " & Environment.NewLine
                strFields &= ", User_ID " & Environment.NewLine
                strValues &= ", " & iUsrID & " " & Environment.NewLine
                strFields &= ", WHPallet_ID " & Environment.NewLine
                strValues &= ", " & iWHPallet_ID & " " & Environment.NewLine
                strFields &= ", Model_ID " & Environment.NewLine
                strValues &= ", " & iModel_ID & " " & Environment.NewLine
                strFields &= ", WHR_WrongSKU " & Environment.NewLine
                strValues &= ", " & iWrongSKU & " " & Environment.NewLine
                strFields &= ", WHR_DevSN_Absent_in_File " & Environment.NewLine
                strValues &= ", " & iDevSN_Absent_in_File & " " & Environment.NewLine
                strFields &= ", WHR_Result " & Environment.NewLine
                strValues &= ", " & iWHRResult & " " & Environment.NewLine

                strSql = "INSERT INTO twarehousereceive " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= strFields
                strSql &= ") " & Environment.NewLine
                strSql &= "VALUES " & Environment.NewLine
                strSql &= "( " & Environment.NewLine
                strSql &= strValues
                strSql &= ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)


                strSql = "Select twarehousereceive.WHR_ID FROM twarehousereceive WHERE WHPallet_ID = " & iWHPallet_ID & " AND WHR_Dev_SN = '" & strIMEI.Trim.ToUpper & "' ORDER BY WHR_ID desc ;"
                iWHR_ID = Me._objDataProc.GetIntValue(strSql)

                '******************************************
                strSql = "INSERT INTO twhrecwrtinfo ( " & Environment.NewLine
                strSql &= "whrwi_msn, whrwi_wrt, whr_id " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= "'" & strSN & "' " & Environment.NewLine
                strSql &= ", " & iWrty & " " & Environment.NewLine
                strSql &= ", " & iWHR_ID & " " & Environment.NewLine
                strSql &= ");"
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                '******************************************

                If iWHP_ID > 0 Then
                    i += Me.AddRemoveFromWarehouseWIP(iWHP_ID, iTranfWIP, iWHR_ID)
                End If

                Return i
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
        Public Function CloseWHPallet(ByVal strWHPallet_Number As String, _
                               ByVal iWHPallet_id As Integer, _
                               ByVal iRcvdQty As Integer, _
                               ByVal iCust_id As Integer, _
                               ByVal iLoc_ID As Integer, _
                               ByVal iProd_ID As Integer, _
                               ByVal iMachineGroupID As Integer, _
                               ByVal iShiftID As Integer, _
                               ByVal iEmpNo As Integer, _
                               ByVal iUserID As Integer, _
                               ByVal strUserName As String, _
                               ByVal strWorkDate As String, _
                               Optional ByVal iWHPallet_Disc As Integer = 0, _
                               Optional ByVal strModel_Desc As String = "") As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim objRec As Production.Receiving
            Dim iWO_ID As Integer = 0
            Dim iTray_ID As Integer = 0
            Dim R1 As DataRow
            Dim iCnt As Integer = 0
            Dim iDevice_ID As Integer = 0

            Try
                Me.GetPhonesInFileNotOnPallet(iWHPallet_id, iMachineGroupID)
                '********************************************
                'Update twarehousepallet
                '********************************************
                strSql = "UPDATE twarehousepallet " & Environment.NewLine
                strSql &= "SET WHP_CountedQty = " & iRcvdQty & Environment.NewLine
                'strSql &= ", WHP_FileQty = " & iCntQty & Environment.NewLine
                strSql &= ", WHPalletClosed = 1 " & Environment.NewLine
                strSql &= ", WHP_PalletRcvd = 1 " & Environment.NewLine
                strSql &= ", WHPallet_Descrepency = " & iWHPallet_Disc & Environment.NewLine
                strSql &= "WHERE WHPallet_Number = '" & strWHPallet_Number & "' " & Environment.NewLine
                strSql &= "AND WHPallet_id = " & iWHPallet_id & " " & Environment.NewLine
                strSql &= "AND Cust_id = " & iCust_id & ";"
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                strSql = "SELECT * from twarehousereceive " & Environment.NewLine
                strSql &= "WHERE twarehousereceive.WHPallet_ID = " & iWHPallet_id
                dt1 = Me._objDataProc.GetDataTable(strSql)

                '************************************
                'Receive device into production
                '************************************
                objRec = New Production.Receiving()

                '************************
                '1:: Create WO
                '************************
                If iWO_ID = 0 Then
                    iWO_ID = objRec.InsertIntoTworkorder(strWHPallet_Number, _
                                                         strWHPallet_Number, _
                                                         iLoc_ID, _
                                                         iProd_ID, _
                                                         iMachineGroupID, _
                                                         , , , , iRcvdQty, )
                End If
                If iWO_ID = 0 Then
                    Throw New Exception("System has failed to create 'Work Order'.")
                End If

                '***********************************
                '2:: Create Tray
                '***********************************
                iTray_ID = objRec.InsertIntoTtray(iUserID, strUserName, CStr(iWO_ID), )
                If iTray_ID = 0 Then
                    Throw New Exception("System has failed to create tray.")
                End If

                '***********************************
                'Loop through each device
                '***********************************
                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        iCnt += 1

                        '************************
                        '3:: Insert into tdevice
                        '************************
                        iDevice_ID = objRec.InsertIntoTdevice(R1("WHR_Dev_SN"), _
                                                              strWorkDate, _
                                                              iCnt, _
                                                              iTray_ID, _
                                                              iLoc_ID, _
                                                              iWO_ID, _
                                                              R1("Model_ID"), _
                                                              iShiftID, _
                                                              0, , )
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

                        If i = 0 Then
                            Throw New Exception("System has failed to write 'Customer Device ID' receive flag.")
                        End If

                        '******************************************
                        '5:: Update Device_ID in twarehousereceive
                        '******************************************
                        strSql = "UPDATE twarehousereceive SET Device_ID = " & iDevice_ID & " WHERE WHR_ID = " & R1("WHR_ID") & ";"
                        i = Me._objDataProc.ExecuteNonQuery(strSql)

                        '***************************
                        'Reset loop variable
                        '***************************
                        iDevice_ID = 0
                        '***************************
                    Next R1
                End If

                '************************************
                'print Crystal Report
                '************************************
                If iWHPallet_Disc = 1 Then
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                objRec = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        ''**************************************************************
        Public Function GetPhonesInFileNotOnPallet(ByVal iWHPallet_ID As Integer, _
                                                   ByVal iMachineGroupID As Integer) As Integer
            '    Dim strsql As String = ""
            '    Dim dt1, dt2 As DataTable
            '    Dim i As Integer = 0
            '    Dim j As Integer = 0
            '    Dim R1, R2 As DataRow
            '    Dim strDate As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            '    Dim strPrevIMEI As String = ""
            '    Dim booResult As Boolean = False

            '    Try
            '        strsql = "Select twarehousepalletload.WHP_ID, twarehousepalletload.WHP_PieceIdentifier, twarehousepalletload.WHPallet_ID, twarehousepalletload.WHP_Duplicate " & Environment.NewLine
            '        strsql &= "from twarehousepalletload  " & Environment.NewLine
            '        strsql &= "where WHPallet_ID = " & iWHPallet_ID & " " & Environment.NewLine
            '        strsql &= "and twarehousepalletload.WHP_RcvdFlag = 8 order by WHP_PieceIdentifier;"
            '        dt1 = Me._objDataProc.GetDataTable(strsql)

            '        For Each R1 In dt1.Rows
            '            '*********************************************************
            '            i = AddRemoveFromWarehouseWIP(R1("WHPallet_ID"), iMachineGroupID)
            '            '*********************************************************
            '            If strPrevIMEI <> Trim(R1("WHP_PieceIdentifier")) Then
            '                '*****************************************************
            '                'Insert into twarehousereceive
            '                strsql = ""
            '                strsql = "Insert into twarehousereceive " & Environment.NewLine
            '                strsql &= "(WHR_Box_SN, WHR_Dev_SN, WHR_InFile_NotOnPallet, WHR_WIPOwner, WHR_Result, WHR_DateLoaded, WHR_DupInFile, WHPallet_ID) " & Environment.NewLine
            '                strsql &= "values (" & Environment.NewLine
            '                strsql &= "'" & Trim(R1("WHP_PieceIdentifier")) & "', " & Environment.NewLine
            '                strsql &= "'" & Trim(R1("WHP_PieceIdentifier")) & "', " & Environment.NewLine
            '                strsql &= "1, " & Environment.NewLine
            '                strsql &= iParentGroupID & ", " & Environment.NewLine
            '                strsql &= "1, " & Environment.NewLine
            '                strsql &= "'" & strDate & "', " & Environment.NewLine
            '                strsql &= R1("WHP_Duplicate") & ", " & Environment.NewLine
            '                strsql &= R1("WHPallet_ID") & ");"
            '                objMisc._SQL = strsql
            '                i += objMisc.ExecuteNonQuery
            '                'Select the last inserted whr_id
            '                '*****************************************************
            '                'strsql = "Select whr_id from twarehousereceive where WHR_Box_SN = '" & Trim(R1("WHP_PieceIdentifier")) & "' and WHR_InFile_NotOnPallet = 1 and whpallet_id = " & R1("WHPallet_ID") & ";"
            '                'LAN CHANGE 10/19/2006
            '                If R1("WHPallet_NoBox") = 1 Then
            '                    strsql = "Select whr_id from twarehousereceive where WHR_Dev_SN = '" & Trim(R1("WHP_PieceIdentifier")) & "' and WHR_InFile_NotOnPallet = 1 and whpallet_id = " & R1("WHPallet_ID") & ";"
            '                Else
            '                    strsql = "Select whr_id from twarehousereceive where WHR_Box_SN = '" & Trim(R1("WHP_PieceIdentifier")) & "' and WHR_InFile_NotOnPallet = 1 and whpallet_id = " & R1("WHPallet_ID") & ";"
            '                End If
            '                '*****************************************************

            '                objMisc._SQL = strsql
            '                dt2 = objMisc.GetDataTable
            '                If dt2.Rows.Count Then
            '                    R2 = dt2.Rows(0)
            '                    iWHR_ID = R2("WHR_ID")
            '                End If
            '                If iWHR_ID = 0 Then
            '                    Throw New Exception("WHR_ID could not be determined.")
            '                Else
            '                    'Discrepancy Report
            '                    booResult = createDiscrepantReport(iWHR_ID, iCust_id, iParentGroupID)
            '                End If
            '                '*****************************************************
            '                R2 = Nothing
            '                If Not IsNothing(dt2) Then
            '                    dt2.Dispose()
            '                    dt2 = Nothing
            '                End If
            '                '*********************
            '            End If

            '            'i = AddRemoveFromWarehouseWIP(iWHPallet_NoBox, , , iParentGroupID, R1("WHP_ID"))
            '            strPrevIMEI = Trim(R1("WHP_PieceIdentifier"))
            '        Next R1


            '        '**************************
            '        'Added by Lan on 05/07/07
            '        ' Move all device out from warehouse
            '        If iCust_id = 2019 Then
            '            strsql = "select * from twarehousepallet where WHPallet_Number = '" & strPallet & "' and cust_id = " & iCust_id & ";"
            '            objMisc._SQL = strsql
            '            dt1 = objMisc.GetDataTable
            '            If dt1.Rows.Count > 0 Then
            '                strsql = "update twarehousepalletload set WHP_RcvdFlag = " & iParentGroupID & " where WHP_RcvdFlag = 8 and WHPallet_ID = " & dt1.Rows(0)("whpallet_id") & ";"
            '                objMisc._SQL = strsql
            '                i = objMisc.ExecuteNonQuery
            '            End If
            '        End If
            '        '**************************

            '        Return i

            '    Catch ex As Exception
            '        Throw ex
            '    Finally
            '        R1 = Nothing
            '        If Not IsNothing(dt1) Then
            '            dt1.Dispose()
            '            dt1 = Nothing
            '        End If
            '    End Try
        End Function

        '**************************************************************
        Public Function DeleteDescrepancy(ByVal iwhrid As Integer) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                If iwhrid > 0 Then
                    '**************************
                    'i = Me.AddRemoveFromWarehouseWIP(iWHPallet_NoBox, , iwhrid, 8, )  ' 8 - add one device to Warehouse WIP; Removes it from Triage WIP; Group_ID for Warehouse is 8
                    '**************************
                    'Get Pallett_ID from tpallett
                    strSql = "Select pallett_id, WHR_Box_SN, WHR_Dev_SN, WHPallet_ID from twarehousereceive where whr_id = " & iwhrid & ";"
                    dt1 = Me._objDataProc.GetDataTable(strSql)
                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("Device not found.")
                    End If
                    '**************************
                    'Delete from twarehousereceive
                    strSql = "Delete from twarehousereceive where whr_id = " & iwhrid & ";"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    '***************************************
                    'Move device back to warehouse
                    i = Me.AddRemoveFromWarehouseWIP(iwhrid, 8, 0)    ' 8 - add one device to Warehouse WIP; Removes it from Triage WIP; Group_ID for Warehouse is 8
                    '***************************************
                    strSql = "DELETE FROM  twhrecwrtinfo where whr_id = " & iwhrid & ";"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    '**************************
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '**************************************************************
        Public Function AddRemoveFromWarehouseWIP(ByVal iWHP_ID As Integer, _
                                                  ByVal iAddRemoveWIP As Integer, _
                                                  ByVal iWHR_ID As Integer) As Integer
            Dim strsql As String = ""

            Try
                strsql = "Update twarehousepalletload " & Environment.NewLine
                strsql &= "set whp_rcvdFlag = " & iAddRemoveWIP & ", " & Environment.NewLine
                strsql &= "WHP_TraigeWIPEntryDt = now() " & Environment.NewLine
                If iWHR_ID > 0 Then strsql &= ", WHR_ID  = " & iWHR_ID & Environment.NewLine Else strsql &= ", WHR_ID  = null " & Environment.NewLine
                strsql &= "where WHP_ID = " & iWHP_ID & ";"
                Return Me._objDataProc.ExecuteNonQuery(strsql)
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Function


        '**************************************************************



    End Class
End Namespace