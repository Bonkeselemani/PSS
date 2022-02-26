Option Explicit On 

Imports System.Windows

Namespace Buisness
    Public Class PreTest
        Private _objDataProc As DBQuery.DataProc

        '***************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************
        Protected Overrides Sub Finalize()
            Me._objDataProc = Nothing
            MyBase.Finalize()
        End Sub

        '***************************************************************
        'Dispose dt
        '***************************************************************
        Public Function DisposeDT(ByRef dt As DataTable)
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Function

        '***************************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '***************************************************************
        Public Function IsPassedByTestType(ByVal iDeviceID As Integer, ByVal iTestType As Integer) As Boolean
            Dim strSql As String
            Try
                strSql = "SELECT count(*) FROM tpretest_data " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Test_ID = " & iTestType & Environment.NewLine
                strSql &= "AND QCResult_ID = 1 "
                If Me._objDataProc.GetIntValue(strSql) = 0 Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function GetPFCodesComboData(ByVal iProd_ID As Integer, Optional ByVal iCust_ID As Integer = 0) As DataTable
            Dim strSQL As String
            Dim iMCode_ID As Integer = 0
            Dim dt As DataTable
            Dim drArr As DataRow()

            Try
                If iCust_ID = 0 Then
                    Select Case iProd_ID
                        Case 1      'Messaging
                            iMCode_ID = 27
                            strSQL = "SELECT DCode_ID, " & Environment.NewLine
                            strSQL &= "Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_LDesc " & Environment.NewLine
                            strSQL &= "FROM lcodesdetail " & Environment.NewLine
                            strSQL &= "WHERE MCode_ID = " & iMCode_ID & " AND Dcode_ID <> 2515 or Dcode_ID=3408" & Environment.NewLine
                            strSQL &= "ORDER BY DCode_LDesc;"
                        Case 2      'Cellular
                            iMCode_ID = 26
                            strSQL = "SELECT A.DCode_ID, " & Environment.NewLine
                            strSQL &= "Concat(trim(A.Dcode_SDesc), ' - ', trim(A.Dcode_Ldesc)) as DCode_LDesc " & Environment.NewLine
                            strSQL &= "FROM lcodesdetail A " & Environment.NewLine
                            ' strSQL &= "INNER JOIN latcle_codes B ON B.DCode_ID = A.DCode_ID " & Environment.NewLine
                            strSQL &= "WHERE A.Dcode_ID <> 2515 and mcode_id = 26 and prod_id = 2 or Dcode_ID=3408" & Environment.NewLine
                            strSQL &= "ORDER BY A.DCode_SDesc;"
                        Case 5    'Gaming Devices
                            iMCode_ID = 29
                            strSQL = "SELECT DCode_ID, " & Environment.NewLine
                            strSQL &= "IF(DCode_ID = 2515, trim(Dcode_Ldesc) ,Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) ) as DCode_LDesc " & Environment.NewLine
                            strSQL &= "FROM lcodesdetail " & Environment.NewLine
                            strSQL &= "WHERE MCode_ID = " & iMCode_ID & "  AND Dcode_ID <> 2515 or Dcode_ID=3408" & Environment.NewLine
                            strSQL &= "ORDER BY DCode_LDesc;"
                        Case 17    'Appliances
                            iMCode_ID = 41
                            strSQL = "SELECT DCode_ID, " & Environment.NewLine
                            strSQL &= "Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_LDesc " & Environment.NewLine
                            strSQL &= "FROM lcodesdetail " & Environment.NewLine
                            strSQL &= "WHERE MCode_ID = " & iMCode_ID & " AND prod_id = 17 or Dcode_ID = 3408" & Environment.NewLine
                            strSQL &= "ORDER BY DCode_LDesc;"
                        Case Else
                            strSQL = "SELECT MCode_ID " & Environment.NewLine
                            strSQL &= "FROM lcodesmaster " & Environment.NewLine
                            strSQL &= "WHERE Prod_ID = " & iProd_ID & " AND QCScreen = 1" & Environment.NewLine
                            iMCode_ID = Me._objDataProc.GetIntValue(strSQL)
                            strSQL = "SELECT DCode_ID, " & Environment.NewLine
                            strSQL &= "Concat(trim(Dcode_SDesc), ' - ', trim(Dcode_Ldesc)) as DCode_LDesc " & Environment.NewLine
                            strSQL &= "FROM lcodesdetail " & Environment.NewLine
                            strSQL &= "WHERE ( MCode_ID = " & iMCode_ID & " AND Prod_ID = " & iProd_ID & " AND DCode_ID not in (4159,4160)) " & Environment.NewLine
                            strSQL &= "OR Dcode_ID = 3408 " & Environment.NewLine
                            strSQL &= "ORDER BY DCode_LDesc;"
                    End Select

                    dt = Me._objDataProc.GetDataTable(strSQL)
                    dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
                Else
                    Select Case iCust_ID
                        'WiKo: see GetWiKo_FailedCodes
                        'Case PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID
                        '    iMCode_ID = 90
                        '    strSQL = "SELECT A.DCode_ID," & Environment.NewLine
                        '    strSQL &= " Concat(trim(A.Dcode_SDesc), ' - ', trim(A.Dcode_Ldesc)) as DCode_LDesc" & Environment.NewLine
                        '    strSQL &= " FROM lcodesdetail A" & Environment.NewLine
                        '    strSQL &= " WHERE  mcode_id = " & iMCode_ID & " and prod_id = " & iProd_ID & Environment.NewLine
                        '    strSQL &= " ORDER BY A.DCode_SDesc;" & Environment.NewLine

                        '    dt = Me._objDataProc.GetDataTable(strSQL)
                        '    dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
                    End Select
                End If

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function GetWiKo_FailedCodes(ByVal iProd_ID As Integer, ByVal iWiKo_Loc_MDcode_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT A.DCode_ID," & Environment.NewLine
                strSQL &= " Concat(trim(A.Dcode_SDesc), ' - ', trim(A.Dcode_Ldesc)) as DCode_LDesc" & Environment.NewLine
                strSQL &= " FROM lcodesdetail A" & Environment.NewLine
                strSQL &= " WHERE  mcode_id = " & iWiKo_Loc_MDcode_ID & " and prod_id = " & iProd_ID & Environment.NewLine
                strSQL &= " ORDER BY A.DCode_SDesc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************

        Public Function GetCoolpad_FailedCodes(ByVal iProd_ID As Integer, ByVal iWiKo_Loc_MDcode_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT A.DCode_ID," & Environment.NewLine
                strSQL &= " Concat(trim(A.Dcode_SDesc), ' - ', trim(A.Dcode_Ldesc)) as DCode_LDesc" & Environment.NewLine
                strSQL &= " FROM lcodesdetail A" & Environment.NewLine
                strSQL &= " WHERE  mcode_id = " & iWiKo_Loc_MDcode_ID & "  Environment.NewLine"
                strSQL &= " ORDER BY A.DCode_SDesc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function getCustomerLocation(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim strRet As String = ""

            Try
                strSql = "select A.Cust_ID,A.Cust_Name1 AS 'Cust_Name',B.Loc_ID,B.Loc_Name from tcustomer A" & Environment.NewLine
                strSql &= " Inner join tlocation B ON A.Cust_ID=B.Cust_ID where A.cust_ID=" & iCust_ID & " AND B.Loc_ID=" & iLoc_ID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then strRet = dt.Rows(0).Item("Cust_Name") & " " & dt.Rows(0).Item("Loc_Name")
                Return strRet
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        '***************************************************************
        Public Function GetWYZE_FailedCodes(ByVal iProd_ID As Integer, ByVal iWYZE_MDcode_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT A.DCode_ID," & Environment.NewLine
                strSQL &= " Concat(trim(A.Dcode_SDesc), ' - ', trim(A.Dcode_Ldesc)) as DCode_LDesc" & Environment.NewLine
                strSQL &= " FROM lcodesdetail A" & Environment.NewLine
                strSQL &= " WHERE  mcode_id = " & iWYZE_MDcode_ID & " and prod_id = " & iProd_ID & Environment.NewLine
                strSQL &= " And dcode_ID not in (6627,6628)" & Environment.NewLine
                strSQL &= " ORDER BY A.DCode_SDesc;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function GetNI_FailedCodesForKeyBoard() As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT *" & Environment.NewLine
                strSQL &= " FROM lcodesdetail" & Environment.NewLine
                strSQL &= " WHERE MCode_ID = 53 AND Prod_ID = 69 AND DCode_ID in (4159,4160);"

                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function GetNI_KeyBoardBillPrice(Optional ByVal iBillMethod As Integer = 0) As DataTable
            Dim strSQL As String
            Dim dt, dt2 As DataTable
            Dim row As DataRow

            Try
                strSQL = "SELECT Billcode_Desc as 'Billcode', tcab_Amount as 'Charge', Prod_Desc as 'Product', A.BillCode_ID" & Environment.NewLine
                strSQL &= " ,IF(A.BillCode_ID=2933 OR A.BillCode_ID=2936, 3965,IF(A.BillCode_ID=2934 OR A.BillCode_ID=2937,3962,IF(A.BillCode_ID=2935 OR A.BillCode_ID=2938,3966,0))) AS 'Model_ID'" & Environment.NewLine
                strSQL &= " ,'' AS 'Model_Desc'" & Environment.NewLine
                strSQL &= " FROM tcustaggregatebilling A" & Environment.NewLine
                strSQL &= " INNER JOIN lbillcodes B ON A.billcode_id = B.billcode_id" & Environment.NewLine
                strSQL &= " INNER JOIN lproduct C ON B.Device_ID = C.Prod_ID" & Environment.NewLine
                Select Case iBillMethod
                    Case 1
                        strSQL &= " WHERE Cust_ID = 2531 AND A.BillCode_ID in (2933,2934,2935);" & Environment.NewLine
                    Case 2
                        strSQL &= " WHERE Cust_ID = 2531 AND A.BillCode_ID in (2936,2937,2938);" & Environment.NewLine
                    Case Else '0 row return
                        strSQL &= " WHERE Cust_ID = 2531 AND A.BillCode_ID in (2933,2934,2935,2936,2937,2938) limit 0;" & Environment.NewLine
                End Select

                dt = Me._objDataProc.GetDataTable(strSQL)

                For Each row In dt.Rows
                    strSQL = "SELECT * FROM tmodel where model_ID = " & row("Model_ID") & ";"
                    dt2 = Me._objDataProc.GetDataTable(strSQL)
                    If dt2.Rows.Count > 0 Then
                        row.BeginEdit() : row("Model_Desc") = dt2.Rows(0).Item("Model_Desc") : row.AcceptChanges()
                    End If
                Next

                Return dt
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function UpdatePFData(ByVal iDevice_ID As Integer, _
                                     ByVal iPretestResult As Integer, _
                                     ByVal dtFailcode As DataTable, _
                                     ByVal iTechID As Integer, _
                                     ByVal strMachineName As String, _
                                     ByVal strWkDate As String, _
                                     ByVal iWCLocation_ID As Integer, _
                                     ByVal iGrpLineMap_ID As Integer, _
                                     ByVal iUsrID As Integer, _
                                     ByVal iCustID As Integer, _
                                     Optional ByVal strFailOther As String = "", _
                                     Optional ByVal bNIKeyboard As Boolean = False) As Boolean

            Dim bUpdatePFData As Boolean = False
            Dim strSQL As String
            Dim iFunc, iRF, iLiquid, iPhysical, iFlash, iReturn As Integer
            Dim iPassCode_ID As Integer = 2515
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strFailCodes As String
            Dim iExisted As Integer = 0
            Dim iPretestIteration As Integer = 0

            Try
                If iDevice_ID > 0 Then
                    iFunc = 0
                    iRF = 0
                    iFlash = 0
                    iLiquid = 0
                    iPhysical = 0

                    If iPretestResult = 1 Then
                        iFunc = 1
                        iFlash = 1
                        iRF = 1
                        iLiquid = 1
                        iPhysical = 1
                    End If

                    strSQL = "SELECT * " & Environment.NewLine
                    strSQL &= "FROM tpretest_data " & Environment.NewLine
                    strSQL &= "WHERE Device_ID = " & iDevice_ID.ToString & " " & Environment.NewLine
                    strSQL &= "ORDER BY QCResult_ID;"
                    dt1 = Me._objDataProc.GetDataTable(strSQL)

                    '***********************************
                    'Get Pretest Iteration
                    '***********************************
                  
                        If dt1.Rows.Count > 0 Then
                            For Each R1 In dt1.Rows
                                If iPretestIteration < R1("pretest_Iteration") Then
                                    iPretestIteration = R1("pretest_Iteration")
                                End If
                            Next R1
                        End If
                        iPretestIteration += 1

                    If bNIKeyboard Then iPretestIteration = 1
                    'Added by Amazech-Thanga 07.07.2021, 08.07.2021
                    If Not (iCustID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID OrElse iCustID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID OrElse iCustID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID OrElse iCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID OrElse iCustID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_CUSTOMER_ID) Then

                        '***********************************
                        If iPretestResult = 1 AndAlso bNIKeyboard = False Then  'PASS DEVICE, bNIKeyboard = False 
                            If dt1.Rows.Count > 0 Then
                                'A pass record already existed. Do nothing
                                If dt1.Select("QCResult_ID = 1").Length > 0 Then
                                    Throw New Exception("Device has been passed before. Can't pass again.")
                                End If

                                'Remove fail code records
                                Me.DeletePretestDataByDeviceID(iDevice_ID)
                            End If

                            'Pass device
                            iReturn = Me.InsertIntoTpretest_data(iDevice_ID, iTechID, strMachineName, iFunc, iRF, iFlash, iLiquid, iPhysical, iPassCode_ID, iPretestResult, iPretestIteration, iWCLocation_ID, iGrpLineMap_ID, strWkDate, iUsrID, )
                        ElseIf iPretestResult = 1 AndAlso bNIKeyboard = True Then       'PASS DEVICE,bNIKeyboard =true
                            If dt1.Rows.Count > 0 Then
                                Me.DeletePretestDataByDeviceID(iDevice_ID)
                            End If
                            'Pass device
                            iReturn = Me.InsertIntoTpretest_data(iDevice_ID, iTechID, strMachineName, iFunc, iRF, iFlash, iLiquid, iPhysical, iPassCode_ID, iPretestResult, iPretestIteration, iWCLocation_ID, iGrpLineMap_ID, strWkDate, iUsrID, )
                        ElseIf iPretestResult = 2 Then  'FAIL DEVICE
                            'Pretest data existed

                            If dt1.Rows.Count > 0 Then
                                For Each R1 In dtFailcode.Rows
                                    If strFailCodes = "" Then
                                        strFailCodes = R1("Dcode_ID")
                                    Else
                                        strFailCodes &= "," & R1("Dcode_ID")
                                    End If
                                Next R1

                                'Delete all failed codes other than user's selected codes
                                strSQL = "DELETE FROM tpretest_data " & Environment.NewLine
                                strSQL &= "WHERE tpretest_data.Device_ID = " & iDevice_ID.ToString & Environment.NewLine
                                strSQL &= "AND tpretest_data.PTtf NOT IN (" & strFailCodes & ")" & Environment.NewLine
                                Me._objDataProc.ExecuteNonQuery(strSQL)
                            End If

                            R1 = Nothing
                            For Each R1 In dtFailcode.Rows
                                strSQL = "SELECT count(*) as cnt " & Environment.NewLine
                                strSQL &= "FROM tpretest_data " & Environment.NewLine
                                strSQL &= "WHERE Device_ID = " & iDevice_ID.ToString & " " & Environment.NewLine
                                strSQL &= "AND PTtf = " & R1("Dcode_ID").ToString & ";"
                                iExisted = Me._objDataProc.GetIntValue(strSQL)

                                Select Case R1("Dcode_ID")
                                    Case 2516 'Fail - RF Test
                                        iRF = 2
                                    Case 2517 'Fail - UI (Functional) Test 
                                        iFunc = 2
                                    Case 2518 'Fail - Flash Test
                                        iFlash = 2
                                    Case 2519 'RUR (Liquid Intrusion)
                                        iLiquid = 2
                                    Case 2520 'RUR (Physical Damage)
                                        iPhysical = 2
                                End Select

                                If iExisted = 0 Then
                                    iReturn += Me.InsertIntoTpretest_data(iDevice_ID, iTechID, strMachineName, iFunc, iRF, iFlash, iLiquid, iPhysical, R1("Dcode_ID"), iPretestResult, iPretestIteration, iWCLocation_ID, iGrpLineMap_ID, strWkDate, iUsrID, , strFailOther)
                                End If

                                iExisted = 0
                                iFunc = 0
                                iRF = 0
                                iFlash = 0
                                iLiquid = 0
                                iPhysical = 0
                            Next R1
                        End If

                        If iReturn > 0 Then bUpdatePFData = True
                    Else
                        If iPretestResult = 1 AndAlso bNIKeyboard = False Then  'PASS DEVICE, bNIKeyboard = False 
                            iReturn = Me.InsertIntoTpretest_data(iDevice_ID, iTechID, strMachineName, iFunc, iRF, iFlash, iLiquid, iPhysical, iPassCode_ID, iPretestResult, iPretestIteration, iWCLocation_ID, iGrpLineMap_ID, strWkDate, iUsrID, )
                        ElseIf iPretestResult = 1 AndAlso bNIKeyboard = True Then       'PASS DEVICE,bNIKeyboard =true
                            iReturn = Me.InsertIntoTpretest_data(iDevice_ID, iTechID, strMachineName, iFunc, iRF, iFlash, iLiquid, iPhysical, iPassCode_ID, iPretestResult, iPretestIteration, iWCLocation_ID, iGrpLineMap_ID, strWkDate, iUsrID, )
                        ElseIf iPretestResult = 2 Then  'FAIL DEVICE
                            'Pretest data existed

                            For Each R1 In dtFailcode.Rows
                                Select Case R1("Dcode_ID")
                                    Case 2516 'Fail - RF Test
                                        iRF = 2
                                    Case 2517 'Fail - UI (Functional) Test 
                                        iFunc = 2
                                    Case 2518 'Fail - Flash Test
                                        iFlash = 2
                                    Case 2519 'RUR (Liquid Intrusion)
                                        iLiquid = 2
                                    Case 2520 'RUR (Physical Damage)
                                        iPhysical = 2
                                End Select
                                iReturn += Me.InsertIntoTpretest_data(iDevice_ID, iTechID, strMachineName, iFunc, iRF, iFlash, iLiquid, iPhysical, R1("Dcode_ID"), iPretestResult, iPretestIteration, iWCLocation_ID, iGrpLineMap_ID, strWkDate, iUsrID, , strFailOther)
                            Next R1
                        End If
                    End If
                    If iReturn > 0 Then bUpdatePFData = True
                Else
                        MsgBox("Unable to obtain a device ID for this device.  Pretest data not updated.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "No Update")
                End If

                Return bUpdatePFData
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Me.DisposeDT(dt1)
                Me.DisposeDT(dtFailcode)
            End Try
        End Function

        '***************************************************************
        Public Function InsertIntoTpretest_data(ByVal iDevice_ID As Integer, _
                                                ByVal iTech_ID As Integer, _
                                                ByVal strMachineName As String, _
                                                ByVal iFunc As Integer, _
                                                ByVal iRF As Integer, _
                                                ByVal iFlash As Integer, _
                                                ByVal iLiquid As Integer, _
                                                ByVal iPhysical As Integer, _
                                                ByVal iPFCodeID As Integer, _
                                                ByVal iResult As Integer, _
                                                ByVal iPretestIteration As Integer, _
                                                ByVal iWCLocation_ID As Integer, _
                                                ByVal iGrpLineMap_ID As Integer, _
                                                ByVal strPretest_wkDt As String, _
                                                ByVal iUsrID As Integer, _
                                                Optional ByVal iTestTypeID As Integer = 1, _
                                                Optional ByVal strFailOther As String = "") As Integer

            Dim strSQL As String

            Try
                strSQL = "INSERT INTO tpretest_data ( " & Environment.NewLine
                strSQL &= "device_id " & Environment.NewLine
                strSQL &= ", tech_id " & Environment.NewLine
                strSQL &= ", machine_name " & Environment.NewLine
                strSQL &= ", PTfunc " & Environment.NewLine
                strSQL &= ", PTrf " & Environment.NewLine
                strSQL &= ", PTflash " & Environment.NewLine
                strSQL &= ", PTL " & Environment.NewLine
                strSQL &= ", PTP " & Environment.NewLine
                strSQL &= ", PTtf " & Environment.NewLine
                strSQL &= ", Tester_UserID " & Environment.NewLine
                strSQL &= ", Test_ID " & Environment.NewLine
                strSQL &= ", QCResult_ID " & Environment.NewLine
                strSQL &= ", pretest_Iteration " & Environment.NewLine
                strSQL &= ", Date_Rec " & Environment.NewLine
                strSQL &= ", WCLocation_ID " & Environment.NewLine
                strSQL &= ", GrpLineMap_ID " & Environment.NewLine
                strSQL &= ", pretest_wkDt " & Environment.NewLine
                If strFailOther <> "" Then strSQL += ", FailOther" & Environment.NewLine
                strSQL &= ") VALUES ( " & Environment.NewLine
                strSQL &= iDevice_ID.ToString & Environment.NewLine
                strSQL &= ", " & iTech_ID.ToString & Environment.NewLine
                strSQL &= ", '" & strMachineName.ToString & "' " & Environment.NewLine
                strSQL &= ", " & iFunc.ToString & Environment.NewLine
                strSQL &= ", " & iRF.ToString & Environment.NewLine
                strSQL &= ", " & iFlash.ToString & Environment.NewLine
                strSQL &= ", " & iLiquid.ToString & Environment.NewLine
                strSQL &= ", " & iPhysical.ToString & Environment.NewLine
                strSQL &= ", " & iPFCodeID.ToString & Environment.NewLine
                strSQL &= ", " & iUsrID.ToString & Environment.NewLine
                strSQL &= ", " & iTestTypeID.ToString & Environment.NewLine
                strSQL &= ", " & iResult.ToString & Environment.NewLine
                strSQL &= ", " & iPretestIteration.ToString & Environment.NewLine
                strSQL &= ", now() " & Environment.NewLine
                strSQL &= ", " & iWCLocation_ID.ToString & Environment.NewLine
                strSQL &= ", " & iGrpLineMap_ID.ToString & Environment.NewLine
                strSQL &= ", '" & Format(CDate(strPretest_wkDt), "yyyy-MM-dd") & "' " & Environment.NewLine
                If strFailOther <> "" Then strSQL += ", '" & strFailOther & "'" & Environment.NewLine
                strSQL &= ");" & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSQL)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function IsValidSN(ByVal strDeviceSN As String, _
                                  ByVal iCustID As Integer, _
                                  Optional ByRef iDevice_ID As Integer = 0) As Boolean
            Dim bIsValidSN As Boolean = False
            Dim strSQL As String
            Dim iCount As Integer
            Dim dt1 As DataTable

            Try
                strSQL = "SELECT distinct Device_ID " & Environment.NewLine
                strSQL &= "FROM tdevice " & Environment.NewLine
                strSQL &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSQL &= "WHERE Device_SN = '" & strDeviceSN & "'" & Environment.NewLine
                strSQL &= "AND tlocation.Cust_ID = " & iCustID & Environment.NewLine
                strSQL &= "AND Device_DateShip IS NULL " & Environment.NewLine
                strSQL &= "AND Pallett_ID IS NULL"

                dt1 = Me._objDataProc.GetDataTable(strSQL)
                iCount = dt1.Rows.Count

                If iCount = 0 Then
                    MsgBox("Unable to locate a record for a device with serial number " & strDeviceSN & ". Device either does not exist in the system or already ship.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Unable to Locate Device")
                ElseIf iCount > 1 Then
                    MsgBox("Serial Number " & strDeviceSN & " is existing in the system more than one. Please contact IT.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Unable to Locate Device")
                Else
                    bIsValidSN = True
                    iDevice_ID = dt1.Rows(0)("Device_ID")
                End If

                Return bIsValidSN
            Catch ex As Exception
                Throw ex
            Finally
                Me.DisposeDT(dt1)
            End Try
        End Function

        '***************************************************************
        Public Function CheckPassFail(ByVal iCurrentPFCode As Integer, _
                                      ByVal strDeviceSN As String, _
                                      ByVal bCanChangeStatus As Boolean, _
                                      ByVal iCustID As Integer) As Boolean
            Dim bCheckPassFail As Boolean = True
            Dim strSQL As String

            Try
                If Not IsValidSN(strDeviceSN, iCustID, ) Then
                    bCheckPassFail = False
                ElseIf iCurrentPFCode = 2515 Then
                    'If device previously failed, user must have permission to change status to pass.
                    If GetCurrentPFCode(strDeviceSN) > 2515 Then 'Device previously failed
                        If Not bCanChangeStatus Then bCheckPassFail = False
                    End If
                End If

                Return bCheckPassFail
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function GetCurrentPFCode(ByVal strDeviceSN As String) As Integer
            Dim strSQL As String
            Dim iPFCode As Integer = 0

            Try
                strSQL = "SELECT IFNULL(A.PTtf, 0) " & Environment.NewLine
                strSQL &= "FROM tpretest_data A " & Environment.NewLine
                strSQL &= "RIGHT JOIN tdevice B ON B.device_id = A.device_id " & Environment.NewLine
                strSQL &= "WHERE B.device_sn = '" & strDeviceSN & "'" & Environment.NewLine
                strSQL &= "AND Device_DateShip IS NULL " & Environment.NewLine
                strSQL &= "AND Pallett_ID IS NULL"

                iPFCode = Me._objDataProc.GetIntValue(strSQL)

                Return iPFCode
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function GetPretestStatus_ByDeviceID(ByVal iDevice_ID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Dcode_ID, Dcode_Ldesc " & Environment.NewLine
                strSql &= "FROM tpretest_data " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail on tpretest_data.PTtf = lcodesdetail.Dcode_id " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID.ToString

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Get Pretest Status")
            End Try
        End Function

        '***************************************************************
        Public Function GetLoadUserPassFailNumber(ByVal iGroup_ID As Integer, _
                                                  ByVal iWCLocation_ID As Integer, _
                                                  ByVal iTechID As Integer, _
                                                  ByVal strWkDt As String) As Integer()
            Dim strSql As String
            Dim dt As DataTable
            Dim iArr(2) As Integer

            Try
                strSql = "SELECT distinct tpretest_data.Device_ID, tpretest_data.QCResult_ID  as Result " & Environment.NewLine
                strSql &= "FROM tpretest_data " & Environment.NewLine
                strSql &= "WHERE tpretest_data.tech_id = " & iTechID & Environment.NewLine
                strSql &= "AND pretest_wkDt = '" & Format(CDate(strWkDt), "yyyy-MM-dd") & "';"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iArr(0) = dt.Select(" Result = 1").Length  'Pass
                    iArr(1) = dt.Select(" Result = 2").Length  'Fail
                Else
                    iArr(0) = 0
                    iArr(1) = 0
                End If
                Return iArr
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Get User Pass/Fail Number")
            Finally
                Me.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************
        Public Function GetPretestHistory(ByVal iDevice_ID As Integer) As DataTable
            Dim dt1, dt2 As DataTable
            Dim R1, R2 As DataRow
            Dim strsql As String = ""

            Try
                '*****************
                strsql = "Select " & Environment.NewLine
                strsql &= "tpretest_data.pretest_wkDt as 'Pretest Date', " & Environment.NewLine
                strsql &= "lqcresult.qcresult as 'Pretest Result', " & Environment.NewLine
                strsql &= "lcodesdetail.Dcode_SDesc as 'Test Code', " & Environment.NewLine
                strsql &= "lcodesdetail.Dcode_lDesc as 'Code Desc', " & Environment.NewLine
                strsql &= "'' as 'Tester', " & Environment.NewLine
                strsql &= "tpretest_data.QCResult_ID, " & Environment.NewLine
                strsql &= "tpretest_data.PTtf as DCode_ID, " & Environment.NewLine
                strsql &= "tpretest_data.tech_id, " & Environment.NewLine
                strsql &= "tpretest_data.tpretest_id, " & Environment.NewLine
                strsql &= "tpretest_data.Device_ID " & Environment.NewLine
                strsql &= ", tpretest_data.FailOther as 'Other failure'" & Environment.NewLine
                strsql &= "FROM tpretest_data " & Environment.NewLine
                strsql &= "INNER JOIN lcodesdetail on tpretest_data.PTtf = lcodesdetail.dcode_id " & Environment.NewLine
                strsql &= "INNER JOIN lqcresult on tpretest_data.QCResult_ID = lqcresult.QCResult_ID " & Environment.NewLine
                strsql &= "WHERE device_id = " & iDevice_ID & Environment.NewLine
                strsql &= "ORDER BY tpretest_data.tpretest_id, pretest_wkDt;"

                dt1 = Me._objDataProc.GetDataTable(strsql)
                '*****************
                'GEt User' Info
                strsql = ""
                strsql = "Select * from security.tusers order by User_ID;"
                dt2 = Me._objDataProc.GetDataTable(strsql)
                '*****************
                For Each R1 In dt1.Rows
                    'Tech Name
                    For Each R2 In dt2.Rows
                        If Not IsDBNull(R2("tech_id")) Then
                            If R1("tech_id") = R2("tech_id") Then
                                R1("Tester") = R2("tech_id") & " - " & Trim(R2("User_FullName"))
                            End If
                        End If
                    Next R2
                    R2 = Nothing
                    dt1.AcceptChanges()
                Next R1

                Return dt1

            Catch ex As Exception
                Throw New Exception("GetPretestHistory(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                R2 = Nothing
                Me.DisposeDT(dt1)
            End Try
        End Function

        '***************************************************************
        Public Function DeletePretestDataByPretestID(ByVal iPretest_id As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "DELETE FROM tpretest_data " & Environment.NewLine
                strSql &= "WHERE tpretest_data.tpretest_id = " & iPretest_id.ToString & Environment.NewLine

                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "RemovePretestEntry")
            End Try
        End Function

        '***************************************************************
        Public Function DeletePretestDataByDeviceID(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0
            Try
                strSql = "SELECT count(*) as cnt FROM tqc WHERE Device_ID = " & iDevice_ID & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then
                    MsgBox("This unit is already been qc cann't delete.", MsgBoxStyle.Critical, "Delete Pretest Record")
                Else
                    strSql = "DELETE FROM tpretest_data " & Environment.NewLine
                    strSql &= "WHERE tpretest_data.Device_ID = " & iDevice_ID.ToString & Environment.NewLine
                    i = Me._objDataProc.ExecuteNonQuery(strSql)

                    strSql = "UPDATE tdevice SET cc_id = 0 " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_ID = " & iDevice_ID.ToString & Environment.NewLine
                    i += Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "DeletePretestData")
            End Try
        End Function


        '***************************************************************
        Public Function CreatePretestRawDataRpt(ByVal strFromDt As String, _
                                                ByVal strToDt As String, _
                                                ByRef strRptPath As String, _
                                                Optional ByVal iGroup_ID As Integer = 0) As Integer
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim R1, R2 As DataRow
            Dim strsql As String = ""
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            strRptPath = strRptDir & strFileName

            Try
                strsql = "SELECT " & Environment.NewLine
                strsql &= "'' as Pretester, " & Environment.NewLine
                strsql &= "'' as 'Pretester Shift', " & Environment.NewLine
                strsql &= "tpretest_data.tech_id, " & Environment.NewLine
                strsql &= "tpretest_data.Date_Rec as 'Pretest Date', " & Environment.NewLine
                strsql &= "lqcresult.QCResult as 'Result', " & Environment.NewLine
                strsql &= "if(lcodesdetail.Dcode_ID = 2515, '', Concat(trim(lcodesdetail.Dcode_Sdesc), ' - ', trim(Dcode_Ldesc))) as 'Failure Reason', " & Environment.NewLine
                strsql &= "tpretest_data.Device_id , " & Environment.NewLine
                strsql &= "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                strsql &= "lline.Line_Number as 'Line', " & Environment.NewLine
                strsql &= "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as 'CostCenter', " & Environment.NewLine
                strsql &= "tdevice.device_sn as 'Serial No', " & Environment.NewLine
                strsql &= "tmodel.Model_desc as 'Model' " & Environment.NewLine
                strsql &= ", Prod_Desc as 'Product Type', tpretest_data.FailOther " & Environment.NewLine
                strsql &= "FROM tpretest_data " & Environment.NewLine
                strsql &= "INNER JOIN tdevice on tpretest_data.device_id = tdevice.device_id " & Environment.NewLine
                strsql &= "INNER JOIN tmodel on tdevice.Model_id = tmodel.Model_id " & Environment.NewLine
                strsql &= "INNER JOIN lproduct on tmodel.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                strsql &= "INNER JOIN lcodesdetail on tpretest_data.PTtf = lcodesdetail.Dcode_id " & Environment.NewLine
                strsql &= "INNER JOIN lqcresult on tpretest_data.qcresult_id = lqcresult.QCResult_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tgrouplinemap on tpretest_data.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lgroups on tgrouplinemap.Group_ID = lgroups.group_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lline on tgrouplinemap.Line_ID = lline.line_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strsql &= "WHERE tpretest_data.pretest_wkDt >= '" & strFromDt & "' and " & Environment.NewLine
                If iGroup_ID > 0 Then
                    strsql &= "tgrouplinemap.Group_ID = " & iGroup_ID & " and " & Environment.NewLine
                End If
                strsql &= "tpretest_data.pretest_wkDt <= '" & strToDt & "' " & Environment.NewLine
                strsql &= "order by tpretest_data.Device_id;"

                dt1 = Me._objDataProc.GetDataTable(strsql)

                strsql = "select security.tusers.user_id, " & Environment.NewLine
                strsql += "security.tusers.user_FullName, " & Environment.NewLine
                strsql += "security.tusers.shift_id, " & Environment.NewLine
                strsql += "security.tusers.qcstamp, " & Environment.NewLine
                strsql += "security.tusers.tech_id, " & Environment.NewLine
                strsql += "production.tshift.shift_number " & Environment.NewLine
                strsql += "from security.tusers left outer join production.tshift on security.tusers.shift_id = production.tshift.shift_id " & Environment.NewLine
                strsql += "order by security.tusers.user_id;"
                dt2 = _objDataProc.GetDataTable(strsql)

                For Each R1 In dt1.Rows
                    'Loop for Pretester info
                    For Each R2 In dt2.Rows
                        If Not IsDBNull(R1("Tech_ID")) And Not IsDBNull(R2("tech_id")) Then
                            If R1("Tech_ID") = R2("tech_id") Then
                                R1("Pretester") = R2("Tech_ID") & " - " & Trim(R2("user_FullName"))
                                R1("Pretester Shift") = R2("shift_number")
                                Exit For
                            End If
                        End If
                    Next R2

                    R2 = Nothing
                    dt1.AcceptChanges()
                Next R1

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("There is no data in PSS Database for the criterion provided.")
                Else
                    Me.CreateRawDataExcelFile(dt1, strFromDt, strToDt, strRptPath)
                    Return 1
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreatePretestRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing
                DisposeDT(dt1) : DisposeDT(dt2)
            End Try
        End Function

        '***************************************************************
        Public Function CreatePretestSummaryRpt(ByVal strFrom As String, _
                                                ByVal strTo As String, _
                                                ByVal strRptPath As String, _
                                                ByVal iGroup_ID As Integer, _
                                                ByVal strGroupDesc As String) As Integer

            Dim strsql As String = ""

            Dim objExcel As Excel.Application    ' Excel application
            Dim objWorkbook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim xlBI As Excel.XlBordersIndex() = {Excel.XlBordersIndex.xlEdgeLeft, Excel.XlBordersIndex.xlEdgeTop, Excel.XlBordersIndex.xlEdgeBottom, _
                Excel.XlBordersIndex.xlEdgeRight, Excel.XlBordersIndex.xlInsideVertical, Excel.XlBordersIndex.xlInsideHorizontal}

            Dim dtLine, dtData As DataTable
            Dim iTotalDays As Integer = 0
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim iRow As Integer = 1
            Dim iCol As Integer = 65
            Dim strCalDate As String = ""
            Dim strDailyHeaders() As String = {"Pass", "Fail", "Total", "Fail %"}
            Dim arrData(,) As Object
            Dim R1 As DataRow

            Dim iDailyTotalGoodUnits As Integer = 0
            Dim iDailyTotalFailUnits As Integer = 0
            Dim iDailyLineTotalGoodUnits As Integer = 0

            Try
                iTotalDays = DateDiff("d", CDate(strFrom), CDate(strTo), , )

                dtLine = DashBoardRpt.GetCostCenterLine(iGroup_ID.ToString(), False, False, , )

                If dtLine.Rows.Count > 0 Then
                    'Prepare report
                    objExcel = New Excel.Application()
                    objExcel.Application.DisplayAlerts = False
                    objWorkbook = objExcel.Workbooks.Add
                    objSheet = objWorkbook.Sheets("Sheet1")
                    objExcel.Visible = True
                    'objSheet.Activate()
                    objSheet.Name = "Pretest Dash Board Rpt"

                    '***********************************
                    'Daily section
                    '***********************************
                    'write timestamp and group description as title
                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = DashBoardRpt.GetDateTimeStamp
                    iRow += 1
                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = strGroupDesc & " - Pretest Dash Board"
                    iRow += 2

                    'redefine array
                    ReDim arrData(dtLine.Rows.Count + 1, ((iTotalDays + 1) * 4))

                    '**************************************
                    'assign cost-center line to array data for daily section
                    '**************************************
                    arrData(j, 0) = "Line"

                    For Each R1 In dtLine.Rows
                        j += 1
                        arrData(j, 0) = R1("cc_desc")
                    Next R1
                    arrData(j + 1, 0) = "Total"

                    '***********************************
                    'Daily data
                    '***********************************
                    j = 0
                    For i = 0 To iTotalDays
                        'Reset loop variable 
                        j = 0
                        iDailyTotalGoodUnits = 0
                        iDailyTotalFailUnits = 0
                        iDailyLineTotalGoodUnits = 0
                        If Not IsNothing(dtData) Then
                            dtData.Dispose()
                            dtData = Nothing
                        End If

                        'calculate next day
                        strCalDate = Format(DateAdd(DateInterval.Day, i, CDate(strFrom)), "yyyy-MM-dd")

                        'write date and date name
                        objSheet.Range(Chr((65 + (i * 4 + 2))) & iRow.ToString & ":" & Chr((65 + (i * 4 + 2))) & iRow.ToString).Value = Format(CDate(strCalDate), "MM/dd/yyyy")
                        objSheet.Range(Chr((65 + (i * 4 + 2))) & (iRow + 1).ToString & ":" & Chr((65 + (i * 4 + 2))) & (iRow + 1).ToString).Value = WeekdayName(Weekday(CDate(strCalDate), FirstDayOfWeek.Sunday))

                        'Header
                        arrData(j, (i * 4) + 1) = strDailyHeaders(0)
                        arrData(j, (i * 4) + 2) = strDailyHeaders(1)
                        arrData(j, (i * 4) + 3) = strDailyHeaders(2)
                        arrData(j, (i * 4) + 4) = strDailyHeaders(3)

                        '*******************************
                        'Good & Fail Units
                        '*******************************
                        strsql = "SELECT Distinct tdevice.Device_ID " & Environment.NewLine
                        strsql &= ", tpretest_data.qcresult_id " & Environment.NewLine
                        strsql &= ", tdevice.cc_id " & Environment.NewLine
                        strsql &= "FROM tdevice " & Environment.NewLine
                        strsql &= "INNER JOIN tpretest_data on tdevice.device_id = tpretest_data.device_id " & Environment.NewLine
                        strsql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                        strsql &= "WHERE tworkorder.Group_ID = " & iGroup_ID & Environment.NewLine
                        strsql &= "AND tpretest_data.pretest_wkDt = '" & strCalDate & "' " & Environment.NewLine
                        strsql &= "order by tdevice.Device_id;"
                        dtData = Me._objDataProc.GetDataTable(strsql)

                        If dtData.Rows.Count > 0 Then
                            For Each R1 In dtLine.Rows
                                j += 1
                                iDailyTotalGoodUnits = 0
                                iDailyTotalFailUnits = 0

                                If dtData.Select("qcresult_id = 1 AND cc_id = " & R1("cc_id"), "").Length > 0 Then iDailyTotalGoodUnits = dtData.Select("qcresult_id = 1 AND cc_id = " & R1("cc_id"), "").Length
                                If dtData.Select("qcresult_id = 2 AND cc_id = " & R1("cc_id"), "").Length > 0 Then iDailyTotalFailUnits = dtData.Select("qcresult_id = 2 AND cc_id = " & R1("cc_id"), "").Length

                                '*******************************
                                arrData(j, (i * 4) + 1) = iDailyTotalGoodUnits
                                arrData(j, (i * 4) + 2) = iDailyTotalFailUnits
                                arrData(j, (i * 4) + 3) = "=SUM(RC[-2]:RC[-1])"
                                If iDailyTotalGoodUnits > 0 Then arrData(j, (i * 4) + 4) = "=RC[-2]/RC[-1]" Else arrData(j, (i * 4) + 4) = "0"

                                iDailyLineTotalGoodUnits += iDailyTotalGoodUnits
                            Next R1

                            '*********
                            'Total
                            arrData(j + 1, (i * 4) + 1) = "=SUM(R[-" & (dtLine.Rows.Count).ToString & "]C:R[-1]C)"  'Good units
                            arrData(j + 1, (i * 4) + 2) = "=SUM(R[-" & (dtLine.Rows.Count).ToString & "]C:R[-1]C)"  'Fail units
                            arrData(j + 1, (i * 4) + 3) = "=SUM(R[-" & (dtLine.Rows.Count).ToString & "]C:R[-1]C)"  'Srap
                            If iDailyLineTotalGoodUnits > 0 Then arrData(j + 1, (i * 4) + 4) = "=RC[-2]/RC[-1]" Else arrData(j + 1, (i * 4) + 4) = "0" 'Fail %
                            '*********
                        End If
                    Next i

                    iRow += 2

                    '*******************************
                    'post data to excel in daily section
                    objSheet.Range("A" & iRow.ToString & ":" & Chr((65 + ((iTotalDays + 1) * 4))) & (iRow + dtLine.Rows.Count + 1).ToString).Value = arrData
                    '*******************************
                    'set border
                    objExcel.Range("A" & (iRow - 1).ToString & ":" & Chr((65 + ((iTotalDays + 1) * 4))) & (iRow + dtLine.Rows.Count + 1).ToString).Select()
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                    For j = 0 To xlBI.Length - 1
                        With objExcel.Selection.Borders(xlBI(j))
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With
                    Next j
                    '*******************************
                    'Center horizontal and vertical for data in daily section
                    objSheet.Range("A" & (iRow - 2).ToString, Chr((65 + (iTotalDays + 1) * 4)) & (iRow + dtLine.Rows.Count + 1).ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    objSheet.Range("A" & (iRow - 2).ToString, Chr((65 + (iTotalDays + 1) * 4)) & (iRow + dtLine.Rows.Count + 1).ToString).VerticalAlignment = Excel.Constants.xlCenter
                    '*******************************
                    'Set wrap text for header
                    objSheet.Range("A" & (iRow).ToString, Chr((65 + (iTotalDays + 1) * 4)) & (iRow).ToString).WrapText = True
                    '*******************************
                    'format Line cell
                    objSheet.Range("A" & (iRow - 1).ToString, "A" & (iRow).ToString).Merge()
                    '*******************************
                    'Title
                    With objSheet.Range("A" & (iRow - 4).ToString, Chr((65 + (iTotalDays + 1) * 4)) & (iRow - 4).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 14
                        .Underline = True
                        .ColorIndex = 25
                    End With
                    '*******************************
                    'date
                    With objSheet.Range("A" & (iRow - 1).ToString, Chr((65 + (iTotalDays + 1) * 4)) & (iRow - 1).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .ColorIndex = 5
                    End With
                    With objSheet.Range("A" & (iRow - 2).ToString, Chr((65 + (iTotalDays + 1) * 4)) & (iRow - 2).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .ColorIndex = 9
                    End With
                    '*******************************
                    'header
                    With objSheet.Range("A" & (iRow).ToString, Chr((65 + (iTotalDays + 1) * 4)) & (iRow).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 12
                    End With
                    objSheet.Range("B" & (iRow - 1).ToString, Chr((65 + (iTotalDays * 4 + 1))) & (iRow).ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    '*******************************
                    'Total
                    With objSheet.Range("A" & (iRow + dtLine.Rows.Count + 1).ToString, Chr((65 + (iTotalDays + 1) * 4)) & (iRow + dtLine.Rows.Count + 1).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 12
                    End With
                    '*******************************
                    'format
                    '*******************************
                    For i = 0 To iTotalDays
                        objSheet.Range(Chr(65 + (i * 4 + 1)) & (iRow - 1).ToString & ":" & Chr(65 + (i * 4 + 3)) & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0"
                        objSheet.Range(Chr(65 + (i * 4 + 3 + 1)) & (iRow - 1).ToString & ":" & Chr(65 + (i * 4 + 3 + 1)) & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0.0%"

                        'Draw a heavier border on the right side
                        objExcel.Range(Chr(65 + (i * 4 + 4)) & (iRow - 1).ToString & ":" & Chr(65 + (i * 4 + 4)) & (iRow + dtLine.Rows.Count + 1).ToString).Select()

                        With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThick
                            .ColorIndex = 25
                        End With

                        If i = 0 Then
                            'Draw a heavier border on the right side
                            objExcel.Range("A" & (iRow - 1).ToString & ":A" & (iRow + dtLine.Rows.Count + 1).ToString).Select()

                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThick
                                .ColorIndex = 25
                            End With
                            With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .Weight = Excel.XlBorderWeight.xlThick
                                .ColorIndex = 25
                            End With
                        End If
                    Next i

                    'Draw a heavier border on the top & bottom edge  of total
                    objExcel.Range("A" & (iRow + dtLine.Rows.Count + 1).ToString & ":" & Chr((65 + (iTotalDays + 1) * 4)) & (iRow + dtLine.Rows.Count + 1).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With

                    '***********************************
                    'Total section 
                    '***********************************
                    'reset variable
                    If Not IsNothing(dtData) Then
                        dtData.Dispose()
                        dtData = Nothing
                    End If
                    arrData = Nothing
                    j = 0
                    i = 0
                    R1 = Nothing
                    iDailyTotalGoodUnits = 0
                    iDailyTotalFailUnits = 0

                    'move row forward to total section
                    iRow = iRow + dtLine.Rows.Count + 1

                    iRow += 2
                    'write total title
                    objSheet.Range("A" & iRow.ToString & ":A" & iRow.ToString).Value = "Total"

                    iRow += 2

                    'redefine array
                    ReDim arrData(dtLine.Rows.Count + 1, strDailyHeaders.Length)

                    '**************************************
                    'assign cost-center line to array data of total section
                    '**************************************
                    For Each R1 In dtLine.Rows
                        j += 1
                        arrData(j, 0) = R1("cc_desc")
                    Next R1
                    arrData(j + 1, 0) = "Total"

                    j = 0
                    '***********************
                    'Header
                    '***********************
                    For i = 0 To strDailyHeaders.Length - 1
                        arrData(j, i) = strDailyHeaders(i)
                    Next i

                    '*******************************
                    'Good & Fail Units
                    '*******************************
                    strsql = "SELECT Distinct tdevice.Device_ID " & Environment.NewLine
                    strsql &= ", tpretest_data.qcresult_id " & Environment.NewLine
                    strsql &= ", tdevice.cc_id " & Environment.NewLine
                    strsql &= "FROM tdevice " & Environment.NewLine
                    strsql &= "INNER JOIN tpretest_data on tdevice.device_id = tpretest_data.device_id " & Environment.NewLine
                    strsql &= "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    strsql &= "WHERE tworkorder.Group_ID = " & iGroup_ID & Environment.NewLine
                    strsql &= "AND tpretest_data.pretest_wkDt BETWEEN '" & strFrom & "' AND '" & strTo & "'" & Environment.NewLine
                    strsql &= "order by tdevice.Device_id;"
                    dtData = Me._objDataProc.GetDataTable(strsql)

                    If dtData.Rows.Count > 0 Then
                        For Each R1 In dtLine.Rows
                            j += 1
                            iDailyTotalGoodUnits = 0
                            iDailyTotalFailUnits = 0

                            If dtData.Select("qcresult_id = 1 AND cc_id = " & R1("cc_id"), "").Length > 0 Then iDailyTotalGoodUnits = dtData.Select("qcresult_id = 1 AND cc_id = " & R1("cc_id"), "").Length
                            If dtData.Select("qcresult_id = 2 AND cc_id = " & R1("cc_id"), "").Length > 0 Then iDailyTotalFailUnits = dtData.Select("qcresult_id = 2 AND cc_id = " & R1("cc_id"), "").Length

                            '*******************************
                            arrData(j, 1) = iDailyTotalGoodUnits
                            arrData(j, 2) = iDailyTotalFailUnits
                            arrData(j, 3) = "=SUM(RC[-2]:RC[-1])"
                            If iDailyTotalGoodUnits > 0 Then arrData(j, 4) = "=RC[-2]/RC[-1]" Else arrData(j, 4) = "0"

                            iDailyLineTotalGoodUnits += iDailyTotalGoodUnits
                        Next R1

                        '*********
                        'Total
                        arrData(j + 1, 1) = "=SUM(R[-" & (dtLine.Rows.Count).ToString & "]C:R[-1]C)"   'Good units
                        arrData(j + 1, 2) = "=SUM(R[-" & (dtLine.Rows.Count).ToString & "]C:R[-1]C)"  'Fail units
                        arrData(j + 1, 3) = "=SUM(R[-" & (dtLine.Rows.Count).ToString & "]C:R[-1]C)"   'Srap
                        If iDailyLineTotalGoodUnits > 0 Then arrData(j + 1, 4) = "=RC[-2]/RC[-1]" Else arrData(j + 1, 4) = "0" 'Fail %
                        '*********
                    End If

                    '*******************************
                    'post data to excel in daily section
                    objSheet.Range("A" & iRow.ToString & ":" & "E" & (iRow + dtLine.Rows.Count + 1).ToString).Value = arrData
                    '*******************************
                    'set border
                    objExcel.Range("A" & (iRow).ToString & ":" & "E" & (iRow + dtLine.Rows.Count + 1).ToString).Select()
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
                    objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

                    For j = 0 To xlBI.Length - 1
                        With objExcel.Selection.Borders(xlBI(j))
                            .LineStyle = Excel.XlLineStyle.xlContinuous
                            .Weight = Excel.XlBorderWeight.xlThin
                            .ColorIndex = Excel.Constants.xlAutomatic
                        End With
                    Next j
                    '*******************************
                    'Set wrap text for header
                    objSheet.Range("A" & (iRow).ToString, "E" & (iRow).ToString).WrapText = True
                    '*******************************
                    'Title
                    With objSheet.Range("A" & (iRow - 2).ToString, "E" & (iRow - 2).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 14
                        .Underline = True
                        .ColorIndex = 25
                    End With
                    '*******************************
                    'header
                    With objSheet.Range("A" & (iRow).ToString, "E" & (iRow).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 12
                    End With
                    'Center horizontal and vertical
                    objSheet.Range("A" & (iRow).ToString, "E" & (iRow + dtLine.Rows.Count + 1).ToString).HorizontalAlignment = Excel.Constants.xlCenter
                    objSheet.Range("A" & (iRow).ToString, "E" & (iRow + dtLine.Rows.Count + 1).ToString).VerticalAlignment = Excel.Constants.xlCenter
                    '*******************************
                    'Total
                    With objSheet.Range("A" & (iRow + dtLine.Rows.Count + 1).ToString, "E" & (iRow + dtLine.Rows.Count + 1).ToString).Font
                        .Name = "Arial"
                        .FontStyle = "Bold"
                        .Size = 12
                    End With
                    '*******************************
                    'Draw a heavier border on header topedge
                    objExcel.Range("A" & (iRow).ToString & ":" & "E" & iRow.ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With

                    'Draw a heavier border on two side of total section
                    objExcel.Range("A" & (iRow).ToString & ":" & "A" & (iRow + dtLine.Rows.Count + 1).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With
                    objExcel.Range("E" & (iRow).ToString & ":" & "E" & (iRow + dtLine.Rows.Count + 1).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With

                    'Draw a heavier border on the top & bottom edge  of total
                    objExcel.Range("A" & (iRow + dtLine.Rows.Count + 1).ToString & ":" & "E" & (iRow + dtLine.Rows.Count + 1).ToString).Select()
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With
                    With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                        .LineStyle = Excel.XlLineStyle.xlContinuous
                        .Weight = Excel.XlBorderWeight.xlThick
                        .ColorIndex = 25
                    End With
                    '*******************************
                    'format cell
                    objSheet.Range("B" & (iRow + 1).ToString & ":" & "D" & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0"
                    objSheet.Range("E" & (iRow + 1).ToString & ":" & "G" & (iRow + dtLine.Rows.Count + 1).ToString).NumberFormat = "#,##0.0%"
                    '*******************************

                    '***********************************
                    'Adjust column widths
                    '***********************************
                    For i = 0 To ((iTotalDays + 1) * 4)
                        objSheet.Columns(Chr(65 + i) & ":" & Chr(65 + i)).ColumnWidth = 12.43
                    Next i
                    '***********************************
                    'Set page orientation
                    '***********************************
                    objSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape
                    objSheet.PageSetup.RightMargin = 4
                    objSheet.PageSetup.LeftMargin = 4
                    '***********************************
                    'Set zoom
                    '***********************************
                    objExcel.ActiveWindow.Zoom = 75
                    '***********************************
                    'Move selection outside the data region 
                    '***********************************
                    objExcel.Range("C1:C1").Select()
                    '***********************************
                    'Delete unused worksheets
                    '***********************************
                    If objWorkbook.Sheets.Count > 1 Then
                        For i = objWorkbook.Sheets.Count To 2 Step -1
                            objWorkbook.Sheets("Sheet" & i.ToString).Delete()
                        Next i
                    End If
                    '***********************************

                End If
            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreatePretestSummaryDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                xlBI = Nothing
                strDailyHeaders = Nothing
                arrData = Nothing
                R1 = Nothing
                Me.DisposeDT(dtLine)
                Me.DisposeDT(dtData)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '***************************************************************
        Public Sub CreateRawDataExcelFile(ByRef dt1 As DataTable, _
                                           ByVal strFromDt As String, _
                                           ByVal strToDt As String, _
                                           ByVal strRptPath As String)
            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim R1 As DataRow
            Dim i As Integer = 3
            Dim arrData(0, 0) As String
            Dim j As Integer = 0

            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************
                'Create the header
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "Group"
                objExcel.Application.Cells(i, 2).Value = "Line"
                objExcel.Application.Cells(i, 3).Value = "Cost Center"
                objExcel.Application.Cells(i, 4).Value = "Pretester"
                objExcel.Application.Cells(i, 5).Value = "Pretester Shift"
                objExcel.Application.Cells(i, 6).Value = "Pretest Date"
                objExcel.Application.Cells(i, 7).Value = "Pretest Result"
                objExcel.Application.Cells(i, 8).Value = "Fail/Pass Reason"
                objExcel.Application.Cells(i, 9).Value = "Serial No"
                objExcel.Application.Cells(i, 10).Value = "Device ID"
                objExcel.Application.Cells(i, 11).Value = "Model"
                objExcel.Application.Cells(i, 12).Value = "Product Type"
                objExcel.Application.Cells(i, 13).Value = "Other Failure"

                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 11.29 'Group
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("B:B").ColumnWidth = 9.43  'Line
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("C:C").ColumnWidth = 32.71 'Pretester
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("D:D").ColumnWidth = 32.71 'Pretester
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("E:E").ColumnWidth = 9.43  'Pretester Shift
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("F:F").ColumnWidth = 20.86  'Pretest Date
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("G:G").ColumnWidth = 11    'Pretest Result
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("H:H").ColumnWidth = 43.43 'Fail/Pass Reason
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("I:I").ColumnWidth = 18.71 'Serial No
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("J:J").ColumnWidth = 11    'Device ID
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("K:K").ColumnWidth = 20.86 'Model
                objSheet.Columns("K:K").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("L:L").ColumnWidth = 18.71 'Product Type
                objSheet.Columns("L:L").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("M:M").ColumnWidth = 43.43 'FailOther
                objSheet.Columns("M:M").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************
                'Format cells Data Type
                '*****************************************
                objSheet.Columns("A:D").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("E:E").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"              'Need to change this

                objSheet.Columns("F:F").Select()
                objExcel.Selection.NumberFormat = "@"

                objSheet.Columns("G:G").Select()
                objExcel.Selection.NumberFormat = "#,##0;[Red]#,##0"              'Need to change this

                objSheet.Columns("H:M").Select()
                objExcel.Selection.NumberFormat = "@"

                '*****************************************
                'Set horizontal alignment for the header
                '*****************************************
                objSheet.Range("A3:M3").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                With objExcel.Selection.Interior
                    .ColorIndex = 37
                    .Pattern = Excel.Constants.xlSolid
                End With

                'i += 1
                i = 0

                ReDim arrData(dt1.Rows.Count, 12)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Group")) Then
                        arrData(i, 0) = Trim(R1("Group"))
                    End If
                    If Not IsDBNull(R1("Line")) Then
                        arrData(i, 1) = Trim(R1("Line"))
                    End If
                    If Not IsDBNull(R1("CostCenter")) Then
                        arrData(i, 2) = Trim(R1("CostCenter"))
                    End If
                    If Not IsDBNull(R1("Pretester")) Then
                        arrData(i, 3) = Trim(R1("Pretester"))
                    End If
                    If Not IsDBNull(R1("Pretester Shift")) Then
                        arrData(i, 4) = R1("Pretester Shift")
                    End If
                    If Not IsDBNull(R1("Pretest Date")) Then
                        arrData(i, 5) = Trim(R1("Pretest Date"))
                    End If
                    If Not IsDBNull(R1("Result")) Then
                        arrData(i, 6) = Trim(R1("Result"))
                    End If
                    If Not IsDBNull(R1("Failure Reason")) Then
                        arrData(i, 7) = Trim(R1("Failure Reason"))
                    End If
                    If Not IsDBNull(R1("Serial No")) Then
                        arrData(i, 8) = Trim(R1("Serial No"))
                    End If
                    If Not IsDBNull(R1("Device_ID")) Then
                        arrData(i, 9) = Trim(R1("Device_ID"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrData(i, 10) = Trim(R1("Model"))
                    End If
                    If Not IsDBNull(R1("Product Type")) Then
                        arrData(i, 11) = Trim(R1("Product Type"))
                    End If
                    If Not IsDBNull(R1("FailOther")) Then
                        arrData(i, 12) = Trim(R1("FailOther"))
                    End If

                    i += 1
                Next R1

                objSheet.Range("A4", "M" & (dt1.Rows.Count + 3)).Value = arrData

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A3:M" & (dt1.Rows.Count + 3)).Select()

                'Set Font
                With objExcel.Selection
                    .Font.Name = "Microsoft Sans Serif"
                End With

                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                objExcel.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                    .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                With objExcel.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .Weight = Excel.XlBorderWeight.xlThin
                    .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
                End With
                '************************************************
                'Add report header
                objSheet.Range("A1:C1").Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    '.font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Verdana"
                    .Font.ColorIndex = 3        'Red
                End With
                objExcel.Application.Cells(1, 1).Value = "Pretest Raw Data Report"
                '*************************************************
                objExcel.Sheets("Sheet2").Delete()
                objExcel.Sheets("Sheet3").Delete()
                'Save the excel file
                If Len(Dir(strRptPath)) > 0 Then
                    Kill(strRptPath)
                End If
                objBook.SaveAs(strRptPath)
                '*************************************************
                'OPen Excel File
                objXL = New Excel.Application()
                objXL.Workbooks.Open(strRptPath)
                objXL.Visible = True

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreateRawDataExcelFile(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                arrData = Nothing
                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '***************************************************************
        'Public Function CreatePretestSummaryRpt(ByVal strFrom As String, _
        '                                        ByVal strTo As String, _
        '                                        ByVal strRptPath As String, _
        '                                        ByVal iGroup_ID As String) As Integer
        '    Dim dt1 As New DataTable()
        '    Dim dt2 As New DataTable()
        '    Dim R1, R2 As DataRow
        '    Dim strsql As String = ""
        '    Dim strRptDir As String = "R:\Pretest Reports\"
        '    Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
        '    strRptPath = strRptDir & strFileName

        '    Try
        '        strsql = "SELECT " & Environment.NewLine
        '        strsql &= "'' as Pretester, " & Environment.NewLine
        '        strsql &= "'' as 'Pretester Shift', " & Environment.NewLine
        '        strsql &= "tpretest_data.tech_id, " & Environment.NewLine
        '        strsql &= "tpretest_data.Date_Rec as 'Pretest Date', " & Environment.NewLine
        '        strsql &= "lqcresult.QCResult as 'Result', " & Environment.NewLine
        '        strsql &= "if(lcodesdetail.Dcode_ID = 2515, '', Concat(trim(lcodesdetail.Dcode_Sdesc), ' - ', trim(Dcode_Ldesc))) as 'Failure Reason', " & Environment.NewLine
        '        strsql &= "tpretest_data.Device_id , " & Environment.NewLine
        '        strsql &= "lgroups.Group_Desc as 'Group', " & Environment.NewLine
        '        strsql &= "lline.Line_Number as 'Line', " & Environment.NewLine
        '        strsql &= "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as 'CostCenter', " & Environment.NewLine
        '        strsql &= "tdevice.device_sn as 'Serial No', " & Environment.NewLine
        '        strsql &= "tmodel.Model_desc as 'Model' " & Environment.NewLine
        '        strsql &= "FROM tpretest_data " & Environment.NewLine
        '        strsql &= "INNER JOIN tdevice on tpretest_data.device_id = tdevice.device_id " & Environment.NewLine
        '        strsql &= "INNER JOIN tmodel on tdevice.Model_id = tmodel.Model_id " & Environment.NewLine
        '        strsql &= "INNER JOIN lcodesdetail on tpretest_data.PTtf = lcodesdetail.Dcode_id " & Environment.NewLine
        '        strsql &= "INNER JOIN lqcresult on tpretest_data.qcresult_id = lqcresult.QCResult_ID " & Environment.NewLine
        '        strsql &= "LEFT OUTER JOIN tgrouplinemap on tpretest_data.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
        '        strsql &= "LEFT OUTER JOIN lgroups on tgrouplinemap.Group_ID = lgroups.group_id " & Environment.NewLine
        '        strsql &= "LEFT OUTER JOIN lline on tgrouplinemap.Line_ID = lline.line_id " & Environment.NewLine
        '        strsql &= "LEFT OUTER JOIN tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
        '        strsql &= "WHERE tpretest_data.pretest_wkDt >= '" & strFromDt & "' and " & Environment.NewLine
        '        If iGroup_ID > 0 Then
        '            strsql &= "tgrouplinemap.Group_ID = " & iGroup_ID & " and " & Environment.NewLine
        '        End If
        '        strsql &= "tpretest_data.pretest_wkDt <= '" & strToDt & "' " & Environment.NewLine
        '        strsql &= "order by tpretest_data.Device_id;"

        '        dt1 = Me._objDataProc.GetDataTable(strsql)

        '        strsql = "select security.tusers.user_id, " & Environment.NewLine
        '        strsql += "security.tusers.user_FullName, " & Environment.NewLine
        '        strsql += "security.tusers.shift_id, " & Environment.NewLine
        '        strsql += "security.tusers.qcstamp, " & Environment.NewLine
        '        strsql += "security.tusers.tech_id, " & Environment.NewLine
        '        strsql += "production.tshift.shift_number " & Environment.NewLine
        '        strsql += "from security.tusers left outer join production.tshift on security.tusers.shift_id = production.tshift.shift_id " & Environment.NewLine
        '        strsql += "order by security.tusers.user_id;"
        '        dt2 = Me._objDataProc.GetDataTable(strsql)

        '        For Each R1 In dt1.Rows
        '            'Loop for Pretester info
        '            For Each R2 In dt2.Rows
        '                If Not IsDBNull(R1("Tech_ID")) And Not IsDBNull(R2("tech_id")) Then
        '                    If R1("Tech_ID") = R2("tech_id") Then
        '                        R1("Pretester") = R2("Tech_ID") & " - " & Trim(R2("user_FullName"))
        '                        R1("Pretester Shift") = R2("shift_number")
        '                        Exit For
        '                    End If
        '                End If
        '            Next R2

        '            R2 = Nothing
        '            dt1.AcceptChanges()
        '        Next R1

        '        If dt1.Rows.Count = 0 Then
        '            Throw New Exception("There is no data in PSS Database for the criterion provided.")
        '        Else
        '            Me.CreateRawDataExcelFile(dt1, strFromDt, strToDt, strRptPath)
        '            Return 1
        '        End If

        '    Catch ex As Exception
        '        Throw New Exception("Buisness.Pretest.CreatePretestRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
        '    Finally
        '        R1 = Nothing
        '        DisposeDT(dt1)
        '        DisposeDT(dt2)
        '    End Try
        'End Function

        '***************************************************************
        Public Function GetPretestResult(ByVal iDeviceID As Integer) As String
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strTestResult As String = ""

            Try
                strSql = "SELECT Concat(Dcode_Sdesc, '-', Dcode_Ldesc) as Fail, Failother " & Environment.NewLine
                strSql &= "FROM tpretest_data " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON tpretest_data.PTtf = lcodesdetail.Dcode_id  " & Environment.NewLine
                strSql &= "WHERE tpretest_data.device_id = " & iDeviceID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    For Each R1 In dt.Rows
                        If strTestResult.Trim.Length > 0 Then strTestResult &= "; "
                        strTestResult &= R1("Fail")
                    Next R1
                    strTestResult &= Environment.NewLine & dt.Rows(0)("Failother")
                End If
                Return strTestResult
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Function

        '***************************************************************
        Public Function GetMoveToFailStation(ByVal booAddRF1Station As Boolean, _
                                             ByVal booAddPrebill As Boolean, _
                                             ByVal booAddBERHold As Boolean, _
                                             ByVal booAddQuantine As Boolean) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 1

            Try
                strSql = "SELECT DISTINCT wfp_FrStation as ToStation, 0 as ID " & Environment.NewLine
                strSql &= "FROM lworkflowprocess " & Environment.NewLine
                strSql &= "WHERE wfp_Inactive = 0" & Environment.NewLine
                strSql &= "AND wfp_FrStation LIKE 'Functional Fail%' " & Environment.NewLine
                strSql &= "ORDER BY ToStation" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                For Each R1 In dt.Rows
                    R1.BeginEdit() : R1("ID") = i : R1.EndEdit() : i += 1
                Next R1

                If booAddRF1Station = True Then
                    R1 = dt.NewRow : R1("ToStation") = "RF1" : R1("ID") = i : i += 1 : dt.Rows.Add(R1)
                End If
                If booAddPrebill = True Then
                    R1 = dt.NewRow : R1("ToStation") = "PRE-BILL" : R1("ID") = i : i += 1 : dt.Rows.Add(R1)
                End If
                If booAddBERHold = True Then
                    R1 = dt.NewRow : R1("ToStation") = "BER HOLD" : R1("ID") = i : i += 1 : dt.Rows.Add(R1)
                End If
                If booAddQuantine = True Then
                    R1 = dt.NewRow : R1("ToStation") = "QUARANTINE" : R1("ID") = i : i += 1 : dt.Rows.Add(R1)
                End If

                dt.AcceptChanges() : dt.DefaultView.Sort = "ToStation ASC"
                R1 = dt.NewRow() : R1("ToStation") = "--Select--" : R1("ID") = 0
                dt.Rows.Add(R1) : dt.AcceptChanges()

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                R1 = Nothing
            End Try
        End Function

        '***************************************************************
        Public Function CreateRepairRefurbishRURRawDataRpt(ByVal strFromDt As String, _
                                                        ByVal strToDt As String, _
                                                        ByVal iGroup_ID As Integer) As Integer
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim objArrData(,) As Object
            Dim dt1, dtRUR As DataTable
            Dim R1, drNewRow As DataRow
            Dim i, j As Integer
            Dim strsql As String = ""
            Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"

            Try
                dt1 = New DataTable() : dtRUR = New DataTable()
                strsql = "Select Distinct Model_Desc as 'Model', Device_SN as 'SN/IMEI'" & Environment.NewLine
                strsql &= ", a.TD_Sequence as 'Iteration' " & Environment.NewLine
                strsql &= ", b.Test_Desc as 'Test Type' " & Environment.NewLine
                strsql &= ", g.user_fullname as 'Technician' " & Environment.NewLine
                strsql &= ", a.TD_TestDt as 'Transaction Date' " & Environment.NewLine
                strsql &= ", f.cust_name1 As 'Customer Name', d.device_id as 'Device_ID'  " & Environment.NewLine
                strsql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty by Date' " & Environment.NewLine
                strsql &= ", Device_LaborLevel as 'Repair Level' " & Environment.NewLine
                strsql &= ", '' as 'RUR Reason'" & Environment.NewLine
                strsql &= ", if(J.Billcode_ID is null, 'No', 'Yes') as 'Reflow?'" & Environment.NewLine
                strsql &= ", if(K.Billcode_ID is null, 'No', 'Yes') as 'Mechanical Repair?'" & Environment.NewLine
                strsql &= "from ttestdata a " & Environment.NewLine
                strsql &= "inner join ltesttype b on a.Test_ID = b.Test_ID " & Environment.NewLine
                strsql &= "inner join tdevice d on a.device_id = d.device_id " & Environment.NewLine
                strsql &= "INNER JOIN tlocation e on d.loc_id = e.loc_id " & Environment.NewLine
                strsql &= "INNER JOIN tcustomer f on e.cust_id = f.cust_id " & Environment.NewLine
                strsql &= "INNER JOIN Security.tusers g on a.TD_UsrID = g.user_id " & Environment.NewLine
                strsql &= "INNER JOIN tmodel H on d.Model_ID = H.Model_ID " & Environment.NewLine
                strsql &= "inner join tworkorder I on d.WO_ID = I.WO_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tdevicebill J on a.Device_ID = J.Device_ID AND J.Billcode_ID = 531" & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tdevicebill K on a.Device_ID = K.Device_ID AND K.Billcode_ID = 1899" & Environment.NewLine
                strsql &= "where a.TD_TestDt >= '" & strFromDt & " 00:00:00' AND a.TD_TestDt <= '" & strToDt & " 23:59:00'" & Environment.NewLine
                strsql &= "AND a.Test_ID IN ( 7, 13 ) " & Environment.NewLine
                strsql &= "AND I.Group_ID = " & iGroup_ID & Environment.NewLine
                strsql &= " order by a.Device_ID, td_id ;" & Environment.NewLine
                'strsql &= "UNION "
                dt1 = _objDataProc.GetDataTable(strsql)

                Select Case iGroup_ID
                    Case 1
                        strsql = "Select Model_Desc as 'Model', Device_SN as 'SN/IMEI'" & Environment.NewLine
                        strsql &= ", '0' as 'Iteration' " & Environment.NewLine
                        strsql &= ", 'RUR' as 'Test Type' " & Environment.NewLine
                        strsql &= ", D.user_fullname as 'Technician' " & Environment.NewLine
                        strsql &= ", C.Date_Rec as 'Transaction Date' " & Environment.NewLine
                        strsql &= ", F.cust_name1 As 'Customer Name', A.device_id as 'Device_ID'  " & Environment.NewLine
                        strsql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty by Date' " & Environment.NewLine
                        strsql &= ", Device_LaborLevel as 'Repair Level' " & Environment.NewLine
                        strsql &= ", J.Dcode_Ldesc as 'RUR Reason' " & Environment.NewLine
                        strsql &= ", 'No' as 'Reflow?', 'No' as 'Mechanical Repair?'" & Environment.NewLine
                        strsql &= "from tdevice A " & Environment.NewLine
                        strsql &= "inner join tworkorder B on A.WO_ID = B.WO_ID " & Environment.NewLine
                        strsql &= "inner join tdevicebill C on A.device_id = C.device_id " & Environment.NewLine
                        strsql &= "INNER JOIN Security.tusers D on C.User_ID = D.user_id " & Environment.NewLine
                        strsql &= "INNER JOIN tlocation E on A.loc_id = E.loc_id " & Environment.NewLine
                        strsql &= "INNER JOIN tcustomer F on E.cust_id = F.cust_id " & Environment.NewLine
                        strsql &= "INNER JOIN lbillcodes G ON C.Billcode_ID = G.Billcode_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tmodel H ON A.Model_ID = H.Model_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tdevicecodes I ON A.Device_ID = I.Device_ID " & Environment.NewLine
                        strsql &= "INNER JOIN lcodesdetail J ON I.Dcode_id = J.Dcode_id AND J.MCode_ID = 21 " & Environment.NewLine
                        strsql &= "WHERE A.Ship_ID = 9999919 AND A.Device_ShipWorkDate >= '" & strFromDt & "' AND A.Device_ShipWorkDate  <= '" & strToDt & "'" & Environment.NewLine
                        strsql &= "AND G.BillCode_Rule = 1 " & Environment.NewLine
                        strsql &= "AND B.Group_ID = " & iGroup_ID & Environment.NewLine
                        strsql &= "ORDER BY A.Device_ID, C.DBill_ID ;" & Environment.NewLine
                    Case 83
                        strsql = "Select Model_Desc as 'Model', Device_SN as 'SN/IMEI'" & Environment.NewLine
                        strsql &= ", '0' as 'Iteration' " & Environment.NewLine
                        strsql &= ", 'RUR' as 'Test Type' " & Environment.NewLine
                        strsql &= ", D.user_fullname as 'Technician' " & Environment.NewLine
                        strsql &= ", C.Date_Rec as 'Transaction Date' " & Environment.NewLine
                        strsql &= ", F.cust_name1 As 'Customer Name', A.device_id as 'Device_ID'  " & Environment.NewLine
                        strsql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty by Date' " & Environment.NewLine
                        strsql &= ", Device_LaborLevel as 'Repair Level' " & Environment.NewLine
                        strsql &= ", J.Dcode_Ldesc as 'RUR Reason' " & Environment.NewLine
                        strsql &= ", 'No' as 'Reflow?', 'No' as 'Mechanical Repair?'" & Environment.NewLine
                        strsql &= "from tdevice A " & Environment.NewLine
                        strsql &= "inner join tworkorder B on A.WO_ID = B.WO_ID " & Environment.NewLine
                        strsql &= "inner join tdevicebill C on A.device_id = C.device_id " & Environment.NewLine
                        strsql &= "INNER JOIN Security.tusers D on C.User_ID = D.user_id " & Environment.NewLine
                        strsql &= "INNER JOIN tlocation E on A.loc_id = E.loc_id " & Environment.NewLine
                        strsql &= "INNER JOIN tcustomer F on E.cust_id = F.cust_id " & Environment.NewLine
                        strsql &= "INNER JOIN lbillcodes G ON C.Billcode_ID = G.Billcode_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tmodel H ON A.Model_ID = H.Model_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tdevicecodes I ON A.Device_ID = I.Device_ID " & Environment.NewLine
                        strsql &= "INNER JOIN lcodesdetail J ON I.Dcode_id = J.Dcode_id AND J.MCode_ID = 21 " & Environment.NewLine
                        strsql &= "WHERE C.Date_Rec >= '" & strFromDt & "' AND C.Date_Rec <= '" & strToDt & "'" & Environment.NewLine
                        strsql &= "AND G.BillCode_Rule = 1 " & Environment.NewLine
                        strsql &= "AND B.Group_ID = " & iGroup_ID & Environment.NewLine
                        strsql &= "ORDER BY A.Device_ID, C.DBill_ID ;" & Environment.NewLine
                    Case Else
                        strsql = "Select Model_Desc as 'Model', Device_SN as 'SN/IMEI'" & Environment.NewLine
                        strsql &= ", '0' as 'Iteration' " & Environment.NewLine
                        strsql &= ", 'RUR' as 'Test Type' " & Environment.NewLine
                        strsql &= ", D.user_fullname as 'Technician' " & Environment.NewLine
                        strsql &= ", C.Date_Rec as 'Transaction Date' " & Environment.NewLine
                        strsql &= ", F.cust_name1 As 'Customer Name', A.device_id as 'Device_ID'  " & Environment.NewLine
                        strsql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty by Date' " & Environment.NewLine
                        strsql &= ", Device_LaborLevel as 'Repair Level' " & Environment.NewLine
                        strsql &= ", G.Billcode_Desc as 'RUR Reason' " & Environment.NewLine
                        strsql &= ", 'No' as 'Reflow?', 'No' as 'Mechanical Repair?'" & Environment.NewLine
                        strsql &= "from tdevice A " & Environment.NewLine
                        strsql &= "inner join tworkorder B on A.WO_ID = B.WO_ID " & Environment.NewLine
                        strsql &= "inner join tdevicebill C on A.device_id = C.device_id " & Environment.NewLine
                        strsql &= "INNER JOIN Security.tusers D on C.User_ID = D.user_id " & Environment.NewLine
                        strsql &= "INNER JOIN tlocation E on A.loc_id = E.loc_id " & Environment.NewLine
                        strsql &= "INNER JOIN tcustomer F on E.cust_id = F.cust_id " & Environment.NewLine
                        strsql &= "INNER JOIN lbillcodes G ON C.Billcode_ID = G.Billcode_ID " & Environment.NewLine
                        strsql &= "INNER JOIN tmodel H ON A.Model_ID = H.Model_ID " & Environment.NewLine
                        strsql &= "WHERE C.Date_Rec >= '" & strFromDt & "' AND C.Date_Rec <= '" & strToDt & "'" & Environment.NewLine
                        strsql &= "AND G.BillCode_Rule = 1 " & Environment.NewLine
                        strsql &= "AND B.Group_ID = " & iGroup_ID & Environment.NewLine
                        strsql &= "ORDER BY A.Device_ID, C.DBill_ID ;" & Environment.NewLine
                End Select
                dtRUR = _objDataProc.GetDataTable(strsql)

                For Each R1 In dtRUR.Rows
                    drNewRow = dt1.NewRow
                    For i = 0 To dt1.Columns.Count - 1
                        drNewRow(i) = R1(i)
                    Next i
                    dt1.Rows.Add(drNewRow)
                Next R1
                dt1.AcceptChanges()

                If dt1.Rows.Count = 0 Then
                    MsgBox("There is no data in PSS Database for the criterion provided.", MsgBoxStyle.Information, "Information")
                Else
                    'Generic.CreateExelReport(dt1, , , 1, , , , )

                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = True                'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objExcel.ActiveSheet.Pagesetup.Orientation = 1
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this
                    objSheet.Columns("A:B").Select()
                    objExcel.Selection.NumberFormat = "@"

                    ReDim objArrData(dt1.Rows.Count + 1, dt1.Columns.Count)
                    i = 0 : j = 0

                    For Each R1 In dt1.Rows
                        '********************************
                        'Create Header
                        '********************************
                        If i = 0 Then
                            For j = 0 To dt1.Columns.Count - 1
                                objArrData(i, j) = dt1.Columns(j).Caption
                            Next j
                            i += 1
                        End If

                        '********************************
                        'Data
                        '********************************
                        For j = 0 To dt1.Columns.Count - 1
                            objArrData(i, j) = R1(j)
                        Next j
                        i += 1
                        '********************************
                    Next R1

                    With objSheet
                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt1.Columns.Count) & (dt1.Rows.Count + 1).ToString).Value = objArrData

                        '*****************************************
                        'format header
                        '*****************************************
                        objSheet.Rows("1:1").Select()
                        With objExcel.Selection
                            .WrapText = False
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                            .font.bold = True
                            .Font.ColorIndex = 5
                        End With

                        .Cells.EntireColumn.AutoFit()
                        .Cells.EntireRow.AutoFit()

                        'Freeze Panel
                        objExcel.ActiveWindow.FreezePanes = False
                        .Range("A2:" & Buisness.Generic.CalExcelColLetter(dt1.Columns.Count) & "2").Select()
                        objExcel.ActiveWindow.FreezePanes = True
                    End With

                    Return dt1.Rows.Count
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreateRepairRefurbishRURRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '***************************************************************
        Public Function CreateRFTestRawDataRpt(ByVal strFromDt As String, _
                                                 ByVal strToDt As String, _
                                                 ByVal iGroup_ID As Integer) As Integer
            Dim dt1, dtRUR As DataTable
            Dim R1, drNewRow As DataRow
            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"

            Try
                dt1 = New DataTable() : dtRUR = New DataTable()
                strsql = "Select Model_Desc as 'Model', Device_SN as 'SN/IMEI'" & Environment.NewLine
                strsql &= ", a.TD_Sequence as 'Iteration' " & Environment.NewLine
                strsql &= ", b.Test_Desc as 'Test Type' " & Environment.NewLine
                strsql &= ", g.user_fullname as 'Inspector' " & Environment.NewLine
                strsql &= ", a.TD_TestDt as 'Transaction Date' " & Environment.NewLine
                If iGroup_ID = 85 Then strsql &= ", IF(J.WrtyClaimableFlg = 1, 'Yes', 'No') as 'In Warranty by Repair' " & Environment.NewLine
                strsql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty by Date' " & Environment.NewLine
                strsql &= ", I.QCResult as 'Test Result'" & Environment.NewLine
                strsql &= ", K.Fail_LDesc as 'Fail Reason'" & Environment.NewLine
                strsql &= ", d.Device_LaborLevel as 'Repair Level', d.Device_DateShip as 'Produced Date'" & Environment.NewLine
                strsql &= ", f.cust_name1 As 'Customer Name', d.device_id as 'Device_ID'  " & Environment.NewLine
                strsql &= "from ttestdata a " & Environment.NewLine
                strsql &= "inner join ltesttype b on a.Test_ID = b.Test_ID " & Environment.NewLine
                strsql &= "inner join tdevice d on a.device_id = d.device_id " & Environment.NewLine
                strsql &= "INNER JOIN tlocation e on d.loc_id = e.loc_id " & Environment.NewLine
                strsql &= "INNER JOIN tcustomer f on e.cust_id = f.cust_id " & Environment.NewLine
                strsql &= "INNER JOIN Security.tusers g on a.TD_UsrID = g.user_id " & Environment.NewLine
                strsql &= "INNER JOIN tmodel H on d.Model_ID = H.Model_ID " & Environment.NewLine
                strsql &= "INNER JOIN lqcresult I ON a.QCResult_ID = I.QCResult_ID " & Environment.NewLine
                If iGroup_ID = 85 Then strsql &= "INNER JOIN edi.titem J on a.device_id = J.device_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lfailcodes K ON a.Fail_ID = K.Fail_ID " & Environment.NewLine
                strsql &= "where a.TD_TestDt >= '" & strFromDt & " 00:00:00' AND a.TD_TestDt <= '" & strToDt & " 23:59:00'" & Environment.NewLine
                strsql &= "AND a.Test_ID IN ( 2, 10 ) " & Environment.NewLine
                strsql &= " order by a.Device_ID, td_id ;" & Environment.NewLine
                dt1 = _objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count = 0 Then
                    MsgBox("There is no data in PSS Database for the criterion provided.", MsgBoxStyle.Information, "Information")
                Else
                    Generic.CreateExelReport(dt1, , , 1, , , , )
                    Return dt1.Rows.Count
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreatePretestRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
            End Try
        End Function

        '***************************************************************
        Public Function GetPretestDevices(ByVal strWHBoxID As String, ByVal iCustID As Integer) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT Manuf_ID, A.Device_ID" & Environment.NewLine
                strsql &= "FROM edi.titem A " & Environment.NewLine
                strsql &= "INNER JOIN tdevice B on A.Device_ID = B.Device_ID " & Environment.NewLine
                strsql &= "inner join tcellopt C on A.Device_ID = C.Device_ID " & Environment.NewLine
                strsql &= "INNER JOIN tlocation D on B.loc_id = D.loc_id " & Environment.NewLine
                strsql &= "INNER JOIN tcustomer E on D.cust_id = E.cust_id " & Environment.NewLine
                strsql &= "INNER JOIN tmodel F on B.Model_ID = F.Model_ID " & Environment.NewLine
                strsql &= "WHERE B.Device_DateShip is null AND C.Workstation = 'pretest' AND E.Cust_ID = " & iCustID & Environment.NewLine
                strsql &= "AND  A.BoxID = '" & strWHBoxID & "'" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strsql)

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.GetPretestDevices(): " & Environment.NewLine & ex.Message.ToString)
            End Try
        End Function

        '***************************************************************
        Public Function CompletePretestBox(ByVal strWHBoxID As String, ByVal strNextStation As String, ByVal iUserID As Integer, _
                                           ByVal strScreenName As String, ByVal strFormName As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer

            Try
                If strWHBoxID.Trim.Length = 0 Then Throw New Exception("Box ID is empty. Can't set workstation.")

                strSql = "SELECT A.Device_ID, WorkStation FROM production.tcellopt A" & Environment.NewLine
                strSql &= "INNER JOIN edi.titem B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "WHERE B.BoxID = '" & strWHBoxID & "' " & Environment.NewLine
                strSql &= "AND WorkStation = 'Pretest'" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then Throw New Exception("No unit existed in 'PreTest' workstation.")

                strSql = "UPDATE production.tcellopt A" & Environment.NewLine
                strSql &= "INNER JOIN edi.titem B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "SET WorkStation = '" & strNextStation & "', WorkStationEntryDt = now() " & Environment.NewLine
                strSql &= "WHERE B.BoxID = '" & strWHBoxID & "' " & Environment.NewLine
                strSql &= "AND WorkStation = 'Pretest'" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                Generic.SetTcelloptWorkstationJournal(dt, iUserID, strNextStation, strScreenName, strFormName)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************
        Public Function CreateSoftwareRefTestRawDataRpt(ByVal strFromDt As String, _
                                                        ByVal strToDt As String, _
                                                        ByVal iGroup_ID As Integer) As Integer
            Dim dt1, dtRUR As DataTable
            Dim R1, drNewRow As DataRow
            Dim i As Integer = 0
            Dim strsql As String = ""
            Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"

            Try
                dt1 = New DataTable() : dtRUR = New DataTable()
                strsql = "Select Model_Desc as 'Model', Device_SN as 'SN/IMEI'" & Environment.NewLine
                strsql &= ", a.TD_Sequence as 'Iteration' " & Environment.NewLine
                strsql &= ", b.Test_Desc as 'Test Type' " & Environment.NewLine
                strsql &= ", g.user_fullname as 'Inspector' " & Environment.NewLine
                strsql &= ", a.TD_TestDt as 'Transaction Date' " & Environment.NewLine
                If iGroup_ID = 85 Then strsql &= ", IF(J.WrtyClaimableFlg = 1, 'Yes', 'No') as 'In Warranty by Repair' " & Environment.NewLine
                strsql &= ", if(Device_ManufWrty = 1, 'Yes', 'No') as 'In Warranty by Date' " & Environment.NewLine
                strsql &= ", I.QCResult as 'Test Result'" & Environment.NewLine
                strsql &= ", L.Fail_LDesc as 'Fail Reason'" & Environment.NewLine
                strsql &= ", d.Device_LaborLevel as 'Repair Level', d.Device_DateShip as 'Produced Date'" & Environment.NewLine
                strsql &= ", f.cust_name1 As 'Customer Name' " & Environment.NewLine
                If iGroup_ID = 85 Then
                    strsql &= ", IF(K.CellOpt_SoftVerIN is null, '', K.CellOpt_SoftVerIN) as 'Software Version IN' " & Environment.NewLine
                    strsql &= ", IF(K.CellOpt_SoftVerOUT is null, '', K.CellOpt_SoftVerOUT) as 'Software Ver. OUT' " & Environment.NewLine
                    strsql &= ", IF(K.CellOpt_VerificationID is null, '', K.CellOpt_VerificationID) as 'Manuf. Verification ID' " & Environment.NewLine
                End If
                strsql &= ", d.device_id as 'Device_ID'  " & Environment.NewLine
                strsql &= "from ttestdata a " & Environment.NewLine
                strsql &= "inner join ltesttype b on a.Test_ID = b.Test_ID " & Environment.NewLine
                strsql &= "inner join tdevice d on a.device_id = d.device_id " & Environment.NewLine
                strsql &= "INNER JOIN tlocation e on d.loc_id = e.loc_id " & Environment.NewLine
                strsql &= "INNER JOIN tcustomer f on e.cust_id = f.cust_id " & Environment.NewLine
                strsql &= "INNER JOIN Security.tusers g on a.TD_UsrID = g.user_id " & Environment.NewLine
                strsql &= "INNER JOIN tmodel H on d.Model_ID = H.Model_ID " & Environment.NewLine
                strsql &= "INNER JOIN lqcresult I ON a.QCResult_ID = I.QCResult_ID " & Environment.NewLine
                If iGroup_ID = 85 Then
                    strsql &= "INNER JOIN edi.titem J on a.device_id = J.device_id " & Environment.NewLine
                    strsql &= "INNER JOIN tcellopt K on a.device_id = K.device_id " & Environment.NewLine
                End If
                strsql &= "LEFT OUTER JOIN lfailcodes L ON a.Fail_ID = L.Fail_ID " & Environment.NewLine
                strsql &= "where a.TD_TestDt >= '" & strFromDt & " 00:00:00' AND a.TD_TestDt <= '" & strToDt & " 23:59:00'" & Environment.NewLine
                strsql &= "AND a.Test_ID = 14 " & Environment.NewLine
                strsql &= " order by a.Device_ID, td_id ;" & Environment.NewLine
                dt1 = _objDataProc.GetDataTable(strsql)

                If dt1.Rows.Count = 0 Then
                    MsgBox("There is no data in PSS Database for the criterion provided.", MsgBoxStyle.Information, "Information")
                Else
                    Generic.CreateExelReport(dt1, , , 1, , , , , New Integer() {1, 2})
                    Return dt1.Rows.Count
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreatePretestRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                DisposeDT(dt1)
            End Try
        End Function

        '**************************************************************
        Public Function GetPretestDeviceInfoInWIP(ByVal strSN As String, _
                                                  ByVal iCustID As Integer, _
                                                  Optional ByVal iLocID As Integer = 0, _
                                                  Optional ByVal booIncludeCelloptData As Boolean = False) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT C.Manuf_ID, C.Prod_ID , A.* "

                If iCustID = 2258 OrElse booIncludeCelloptData = True Then
                    strSql &= ", if(WorkStation is null, '', WorkStation) as WorkStation " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_SoftVerIN is null, '', D.CellOpt_SoftVerIN) as CellOpt_SoftVerIN " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_SoftVerOUT is null, '', D.CellOpt_SoftVerOUT) as CellOpt_SoftVerOUT " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_MSN is null, '', D.CellOpt_MSN) as CellOpt_MSN " & Environment.NewLine
                    strSql &= ", Cellopt_WIPOwner " & Environment.NewLine
                    strSql &= ", CellOpt_RefurbCompleteDt " & Environment.NewLine
                    strSql &= ", if(D.CellOpt_VerificationID is null, '', D.CellOpt_VerificationID) as CellOpt_VerificationID " & Environment.NewLine

                    If iCustID = 2258 Then
                        strSql &= ", if(E.manuf_date is null, '', E.manuf_date) As 'ManufDate'" & Environment.NewLine
                        strSql &= ", if(E.FuncRep is null, -1, E.FuncRep) as FuncRep " & Environment.NewLine
                    Else
                        strSql &= ", '' as 'ManufDate', -1 as FuncRep " & Environment.NewLine
                    End If
                Else
                    strSql &= ", '' as WorkStation, '' as 'ManufDate', -1 as FuncRep " & Environment.NewLine
                    If iCustID = NI.CUSTOMERID Then strSql &= ",C.Model_desc" & Environment.NewLine
                End If

                strSql &= "FROM production.tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN production.tlocation B ON A.Loc_ID = B.Loc_ID " & Environment.NewLine
                If iCustID = 2485 Then
                    strSql &= "INNER JOIN production.syxdata C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                Else
                    strSql &= "INNER JOIN production.tmodel C ON A.Model_ID = C.Model_ID " & Environment.NewLine
                End If
                If iCustID = 2258 OrElse booIncludeCelloptData = True Then
                    strSql &= "INNER JOIN production.tcellopt D ON A.Device_ID = D.Device_ID " & Environment.NewLine
                    If iCustID = 2258 Then strSql &= "INNER JOIN edi.titem E ON A.device_id = E.device_id " & Environment.NewLine
                End If
                strSql &= String.Format("WHERE A.Device_SN = '{0}' AND Cust_ID = {1}", strSN, iCustID) & Environment.NewLine
                strSql &= "AND (Device_DateShip is null or Device_DateShip = '' or Device_DateShip = '0000-00-00 00:00:00')"

                If iLocID > 0 Then strSql &= String.Format("AND A.Loc_ID = {0}", iLocID) & Environment.NewLine

                Return _objDataProc.GetDataTable(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function UpdateFialOther(ByVal iDeviceID As Integer, ByVal strFailOther As String) As Integer
            Dim strSql As String
            Try
                strSql = "UPDATE tpretest_data SET FailOther = '" & strFailOther & "' WHERE Device_ID = " & iDeviceID
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function HasImageCount(ByVal iModelID As Integer) As Integer
            Dim strSql As String
            Try
                strSql = "SELECT Count(*) as cnt FROM ImageLibrary WHERE Model_ID = " & iModelID & " AND HasImage = 1 "
                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************
        Public Function IsNotAllowToScrap(ByVal iCustID As Integer, ByVal iProdID As Integer) As Boolean
            Dim strSql As String
            Dim dt As DataTable
            Dim booResult As Boolean = False
            Dim strArr As String()
            Dim i As Integer = 0

            Try
                strSql = "SELECT NoScrapProdIDs FROM triagevalidation WHERE Cust_ID = " & iCustID & " AND Active = 1 "
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strArr = dt.Rows(0)("NoScrapProdIDs").ToString.Trim.Split("|")
                    For i = 0 To strArr.Length - 1
                        If strArr(i).Trim.Length > 0 AndAlso strArr(i).Trim = iProdID.ToString Then
                            booResult = True : Exit For
                        End If
                    Next i
                End If

                Return booResult

            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class
End Namespace

