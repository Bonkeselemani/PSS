Option Explicit On 

Imports System.IO
Imports System.Windows.Forms

Namespace Buisness

    Public Class Skullcandy
        Public Const CUSTOMERID As Integer = 2552
        Public Const LOCID As Integer = 3352
        Public Const GROUPID As Integer = 108
        Public Const MANUFID As Integer = 212
        Public Const PRODID As Integer = 20

        ' Skullcandy ASTRO
        Public Const ASTRO_CUSTOMERID As Integer = 2569
        Public Const ASTRO_LOCID As Integer = 3371
        Public Const PalletWO_Prefix As String = "SKASTRO" '"SKCNDY"
        Public Const PalletShip_Prefix As String = "SKAREF" 'for both TestOnlt and Repair
        Public Const ASTRO_ShipBoxBundleLimit As Integer = 10
        Public Const ASTRO_ShipColPreFix As String = "SN_"

        'Skullcandy Retail
        Public Const Retail_CUSTOMERID As Integer = 2577
        Public Const Retail_LOCATIONID As Integer = 3380

        Public Enum WrtyClaimServiceBillcode
            Wrty_Date_Code_Internal = 2535
            Wrty_Date_Code_External = 2536
            Wrty_Audio_Testing = 2524
        End Enum

        Public Enum AstroServiceBillcode
            Receiving = 2518
            Scrap = 2521
            UpdateFirmware = 2540
            Testing = 2519
            Repair = 2520
            Masterpack = 2549
        End Enum

        Public Enum ModelPrefixString ' Must be the same as Model_MotoSku defined in tModel fro Skullcandy Astro
            A50 = 1  'Bundle A50
            TXD = 2  'Bundle A50
            A42 = 3  'Bundle A40
            MA3 = 4  'Bundle A40
            NotDefined = 5 'Exception
            A40 = 6 'Bundle A40
            MAUSB = 7 'Bundle A40
        End Enum

        Public Enum ModelProcessType
            Scrap = 1
            Repair = 2
            TestOnly = 3
            NotDefined = 4 'Exception
        End Enum

        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

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


#End Region

#Region "General"

        '***************************************************************************************************
        Public Function GetCustomer(ByVal iCust_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT Cust_ID,Cust_Name1 from tCustomer " & Environment.NewLine
                strSQL &= "WHERE cust_ID = " & iCust_ID
                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function

        '***************************************************************************************************

#End Region

#Region "Astro"

        '***************************************************************************************************
        Public Function Astro_GetModelName(ByVal strSerialNumber As String) As String
            'Input: Astro SN
            'Output: A50,TXD,A42,MA3, or NotDefined

            Dim iLen As Integer = 3, iLen2 As Integer = 5

            Try
                If strSerialNumber.Trim.Length >= iLen Then
                    Select Case strSerialNumber.Trim.ToUpper.Substring(0, iLen)
                        Case ModelPrefixString.A50.ToString.ToUpper
                            Return ModelPrefixString.A50.ToString
                        Case ModelPrefixString.TXD.ToString.ToUpper
                            Return ModelPrefixString.TXD.ToString
                        Case ModelPrefixString.A42.ToString.ToUpper, ModelPrefixString.A40.ToString.ToUpper
                            Return ModelPrefixString.A42.ToString
                        Case ModelPrefixString.MA3.ToString.ToUpper
                            Return ModelPrefixString.MA3.ToString
                        Case Else
                            If strSerialNumber.Trim.ToUpper.Substring(0, iLen2) = ModelPrefixString.MAUSB.ToString.ToUpper Then
                                Return ModelPrefixString.MA3.ToString
                            End If
                            Return ModelPrefixString.NotDefined.ToString
                    End Select
                Else
                    Return ModelPrefixString.NotDefined.ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetModelRepairType(ByVal strSerialNumber As String) As String
            'Input: Astro SN
            'Output: Scrap, Repair, TestOnly, or NotDefined

            Dim TargetValueMA3_Lo As Integer = 1237, TargetValueMA3_Hi As Integer = 1247
            Dim TargetValueA50_Lo As Integer = 1234, TargetValueA50_Hi As Integer = 1235
            Dim TargetValueTXD_Lo As Integer = 1234, TargetValueTXD_Hi As Integer = 1235
            Dim iLen1 As Integer = 3, iLen2 As Integer = 7, iLen3 As Integer = 4, iLen4 As Integer = 5
            Dim iTotalRequiredlen As Integer = 13
            Dim strTmpSN As String = "", strS As String = ""
            Dim Val As Integer, i As Integer

            Try
                If strSerialNumber.Trim.Length <> 13 Then
                    ' MAUSB (14 digits in length) aways is scrap 'add 2014-03---------------
                    strTmpSN = strSerialNumber.Trim.ToUpper
                    strS = strTmpSN.Substring(0, iLen4)
                    If strSerialNumber.Trim.Length = 14 AndAlso strS = ModelPrefixString.MAUSB.ToString.ToUpper Then
                        Return ModelProcessType.Scrap.ToString
                    End If
                    '-----------------------------------------------------------------------

                    Return ModelProcessType.NotDefined.ToString
                Else '=13
                    strTmpSN = strSerialNumber.Trim.ToUpper

                    'A40 (13 digits in lenth) aways is scrap 'add 2014-03 ------------------
                    strS = strTmpSN.Substring(0, iLen1)
                    If strS = ModelPrefixString.A40.ToString.ToUpper Then
                        Return ModelProcessType.Scrap.ToString
                    End If
                    '-----------------------------------------------------------------------

                    'Valid numeric digits
                    strTmpSN = strTmpSN.Substring(strTmpSN.Length - (iTotalRequiredlen - iLen1), iTotalRequiredlen - iLen1) 'last 10
                    For i = 0 To iTotalRequiredlen - iLen1 - 1
                        strS = strTmpSN.Substring(i, 1)
                        If Not Astro_IsValidSingleNumericDigit(strS) Then
                            Return ModelProcessType.NotDefined.ToString
                        End If
                    Next

                    'Valid week number
                    strTmpSN = strSerialNumber.Trim.ToUpper
                    strTmpSN = strTmpSN.Substring(0, iLen2)
                    strS = strTmpSN.Substring(iLen2 - 2, 2)
                    If CInt(strS) < 1 Or CInt(strS) > 53 Then
                        Return ModelProcessType.NotDefined.ToString
                    End If
                End If

                If strSerialNumber.Trim.Length >= iLen2 Then
                    strTmpSN = strSerialNumber.Trim.ToUpper.Substring(0, iLen2)
                    strS = strTmpSN.Substring(strTmpSN.Length - iLen3, iLen3)
                    Select Case strSerialNumber.Trim.ToUpper.Substring(0, iLen1)
                        Case ModelPrefixString.A50.ToString.ToUpper
                            If IsNumeric(strS) Then
                                Val = strS
                                If Val <= TargetValueA50_Lo Then
                                    Return ModelProcessType.Repair.ToString
                                ElseIf Val >= TargetValueA50_Hi Then
                                    Return ModelProcessType.TestOnly.ToString
                                Else
                                    Return ModelProcessType.NotDefined.ToString
                                End If
                            Else
                                Return ModelProcessType.NotDefined.ToString
                            End If
                        Case ModelPrefixString.TXD.ToString.ToUpper
                            If IsNumeric(strS) Then
                                Val = strS
                                If Val <= TargetValueTXD_Lo Then
                                    Return ModelProcessType.Repair.ToString
                                ElseIf Val >= TargetValueTXD_Hi Then
                                    Return ModelProcessType.TestOnly.ToString
                                Else
                                    Return ModelProcessType.NotDefined.ToString
                                End If
                            Else
                                Return ModelProcessType.NotDefined.ToString
                            End If
                        Case ModelPrefixString.A42.ToString.ToUpper
                            Return ModelProcessType.TestOnly.ToString
                        Case ModelPrefixString.MA3.ToString.ToUpper
                            If IsNumeric(strS) Then
                                Val = strS
                                If Val <= TargetValueMA3_Lo Then
                                    Return ModelProcessType.Scrap.ToString
                                ElseIf Val >= TargetValueMA3_Hi Then
                                    Return ModelProcessType.TestOnly.ToString
                                Else
                                    Return ModelProcessType.Repair.ToString
                                End If
                            Else
                                Return ModelProcessType.NotDefined.ToString
                            End If
                        Case Else
                            Return ModelProcessType.NotDefined.ToString
                    End Select
                Else
                    Return ModelProcessType.NotDefined.ToString
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_GetAstro_BundleModelID2(ByVal iCust_ID As Integer, ByVal strModel_MotoSku As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strModel_MotoSku = strModel_MotoSku.Trim
                If strModel_MotoSku.Length > 0 Then
                    Select Case strModel_MotoSku.Trim.ToUpper
                        Case ModelPrefixString.TXD.ToString.ToUpper, ModelPrefixString.MA3.ToString.ToUpper
                            strSQL = "SELECT A.Model_ID,A.Model_Desc,A.Model_MotoSku,B.cust_IncomingSku,B.Cust_Model_Number,B.Cust_model_desc" & Environment.NewLine
                            strSQL &= " FROM tmodel A" & Environment.NewLine
                            strSQL &= " INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID=B.Model_ID" & Environment.NewLine
                            strSQL &= " WHERE B.Cust_ID = " & iCust_ID & " AND A.Model_MotoSku = '" & strModel_MotoSku & "';" & Environment.NewLine
                            dt = Me._objDataProc.GetDataTable(strSQL)
                            If dt.Rows.Count > 0 Then
                                Return dt.Rows(0).Item("Model_ID")
                            Else
                                Return 0
                            End If
                        Case Else
                            Return 0
                    End Select
                Else
                    Return 0
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function Astro_IsValidSingleNumericDigit(ByVal strS) As Boolean
            Dim i As Integer
            Dim bRes As Boolean = False

            Try
                If IsNumeric(strS) AndAlso strS.trim.length = 1 Then
                    Dim myV As Integer = strS
                    For i = 0 To 9
                        If i = myV Then
                            bRes = True
                            Exit For
                        End If
                    Next
                End If

                Return bRes

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************

#End Region

#Region "Skullcandy Wrty Process"

        '***************************************************************************************************
        Public Function GetWorkOrder(ByVal iLoc_ID As Integer, ByVal iEndUser As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT WO_ID, WO_CustWO, EndUser FROM tWorkorder" & Environment.NewLine
                strSQL &= " WHERE Loc_ID = " & iLoc_ID & " AND EndUser = " & iEndUser & Environment.NewLine
                strSQL &= " AND WO_Closed = 0 " & Environment.NewLine
                strSQL &= " Order by WO_CustWO; "

                dt = Me._objDataProc.GetDataTable(strSQL)
                ' If dt.Rows.Count > 0 Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetFamily(ByVal iCust_ID As Integer, _
                                  ByVal bNoModelRequired As Boolean) As DataTable

            Dim strSQL As String
            Dim dt As DataTable

            Try
                If (Not bNoModelRequired) Then    'model required
                    'strSQL = "SELECT Distinct A.ModelFamiliesID, A.Name FROM cogs.modelfamilies A" & Environment.NewLine
                    'strSQL &= " INNER JOIN tcustmodel_pssmodel_map B ON A.ModelFamiliesID = B.ModelFamiliesID" & Environment.NewLine
                    'strSQL &= " WHERE B.Cust_ID = " & iCust_ID & Environment.NewLine
                    'strSQL &= " ORDER BY A.Name;" & Environment.NewLine

                    strSQL = "SELECT Distinct A.ModelFamiliesID, A.Name, C.ScrapUponRec, C.CollectDateCodeInternal, C.CollectDateCodeExternal, C.Cust_ID, C.AudioTest " & Environment.NewLine
                    strSQL &= " FROM cogs.modelfamilies A" & Environment.NewLine
                    strSQL &= " INNER JOIN production.tcustmodel_pssmodel_map B ON A.ModelFamiliesID = B.ModelFamiliesID" & Environment.NewLine
                    strSQL &= " INNER JOIN cogs.modelfamilies_cust_map C ON A.ModelFamiliesID= C.ModelFamiliesID" & Environment.NewLine
                    strSQL &= " WHERE B.Cust_ID=" & iCust_ID & Environment.NewLine
                    strSQL &= " ORDER BY A.Name;" & Environment.NewLine
                Else 'No model required
                    strSQL &= " SELECT  A.ModelFamiliesID, A.Name, B.ScrapUponRec, B.CollectDateCodeInternal, B.CollectDateCodeExternal, B.Cust_ID, B.AudioTest" & Environment.NewLine
                    strSQL &= " FROM cogs.modelfamilies A" & Environment.NewLine
                    strSQL &= " INNER JOIN cogs.modelfamilies_cust_map B ON A.ModelFamiliesID = B.ModelFamiliesID" & Environment.NewLine
                    strSQL &= " WHERE B.Cust_ID=" & iCust_ID & Environment.NewLine
                    strSQL &= " ORDER BY A.Name;" & Environment.NewLine
                End If

                dt = Me._objDataProc.GetDataTable(strSQL)
                ' If dt.Rows.Count > 0 Then dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Function GetModelByFamilyID(ByVal iCust_ID As Integer, ByVal iFamily_ID As Integer) As DataTable
            Dim strSQL As String
            Dim dt As DataTable

            Try
                strSQL = "SELECT A.Model_ID,Model_Desc FROM tmodel A" & Environment.NewLine
                strSQL &= " INNER JOIN tcustmodel_pssmodel_map B ON A.Model_ID = B.Model_ID" & Environment.NewLine
                strSQL &= " WHERE B.Cust_ID = " & iCust_ID & " and ModelFamiliesID= " & iFamily_ID & Environment.NewLine
                strSQL &= " ORDER BY Model_Desc ;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)

                Return dt
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function

        '***************************************************************************************************
        Public Function GetModelID(ByVal iManuf_ID As Integer, ByVal iProd_ID As Integer, ByVal strModel_Desc As String) As Integer
            Dim strSQL As String
            Dim dt As DataTable

            strModel_Desc = strModel_Desc.Replace("'", "''")

            Try
                strSQL = "SELECT Model_ID,Model_Desc FROM tmodel" & Environment.NewLine
                strSQL &= " WHERE Manuf_ID=" & iManuf_ID & " AND Prod_ID=" & iProd_ID & Environment.NewLine
                strSQL &= " AND Model_Desc='" & strModel_Desc & "';"

                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    Return dt.Rows(0).Item("Model_ID")
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function

#End Region

#Region "Reports"

        '***************************************************************************************************
        Public Function CreateReceivingRpt(ByVal iCustID As Integer, ByVal strReportName As String, _
                                           ByVal strDateStart As String, ByVal strDateEnd As String, _
                                           ByVal booEndUserOnly As Boolean) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim objExcelRpt As ExcelReports
            Dim strCols() As String, i As Integer = 0

            Try
                strSql = "SELECT F.InRMA AS 'RA', H.Name AS 'Family', Date_format(A.Device_DateRec, '%m/%d/%Y') AS 'Received Date'" & Environment.NewLine
                strSql &= ", D.DCode_SDesc AS 'PSSI Fail Code', D.Dcode_LDesc AS 'Fail Desc', D.Dcode_L2Desc AS 'SK Fail Code', Upper(I.CellOpt_DateCode) as 'Date Code' " & Environment.NewLine
                strSql &= ",IF(E.EndUser=1,'End User','Bulk') as UserType" & Environment.NewLine
                strSql &= "FROM tdevice A" & Environment.NewLine
                strSql &= "INNER JOIN tlocation B ON A.Loc_ID = B.Loc_ID " & Environment.NewLine
                strSql &= "LEFT JOIN tpretest_data C ON A.Device_ID = C.Device_ID " & Environment.NewLine
                strSql &= "LEFT JOIN lcodesdetail D ON C.PTtf = D.DCode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tworkorder E ON A.WO_ID = E.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN tasndata F ON A.Device_ID = F.Device_ID " & Environment.NewLine
                strSql &= "LEFT JOIN tcustmodel_pssmodel_map G ON A.Model_ID = G.Model_ID AND G.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "LEFT JOIN cogs.modelfamilies H ON G.ModelFamiliesID = H.ModelFamiliesID " & Environment.NewLine
                strSql &= "LEFT JOIN tcellopt I ON A.Device_ID = I.Device_ID " & Environment.NewLine
                strSql &= " WHERE B.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= " AND A.Device_DateRec BETWEEN '" & strDateStart & " 00:00:00' AND '" & strDateEnd & " 23:59:59'" & Environment.NewLine
                If booEndUserOnly Then strSql &= "AND E.EndUser = 1 " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    ReDim strCols(dt.Columns.Count - 1)
                    For i = 0 To dt.Columns.Count - 1
                        strCols(i) = Generic.CalExcelColLetter(i + 1)
                    Next i

                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat(dt, strReportName, strCols)
                    '*************************
                End If

                Return dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************************
        'For Skullcandy Realtail Invoice Report
        Public Function getRetailInvoice_ReceivedData(ByVal iCust_ID As Integer, ByVal strBegDate As String, ByVal strEndDate As String, _
                                                           ByVal dtServiceTypeData As DataTable, ByVal arrlstChargeType As ArrayList) As DataTable
            Dim strSQL As String
            Dim dt As New DataTable()
            Dim row As DataRow
            Dim i As Integer

            Try

                strSQL = "SELECT A.BR_ID,A.RMA,A.DCode_ID,concat('''',A.UPC) AS UPC,A.Quantity,A.RecDate,B.DCode_LDesc AS 'ServiceType'" & Environment.NewLine

                For Each row In dtServiceTypeData.Rows
                    strSQL &= ", 0 AS '" & row("DCode_LDesc") & "'"
                Next
                strSQL &= ",0 AS 'Total Qty'"

                For i = 0 To arrlstChargeType.Count - 1
                    strSQL &= ", 0.00 AS 'Unit " & arrlstChargeType(i) & "'"
                Next
                For i = 0 To arrlstChargeType.Count - 1
                    strSQL &= ", 0.00 AS '" & arrlstChargeType(i) & "'"
                Next
                strSQL &= ",0.00 AS 'Total Charge'"

                strSQL &= " FROM tBulkReceive A" & Environment.NewLine
                strSQL &= " INNER JOIN lcodesdetail B On A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSQL &= " WHERE A.Cust_ID=" & iCust_ID & Environment.NewLine
                strSQL &= " AND A.RecDate BETWEEN '" & strBegDate & " 00:00:00'" & Environment.NewLine
                strSQL &= " AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                strSQL &= " ORDER BY RMA,UPC;"

                dt = Me._objDataProc.GetDataTable(strSQL)
                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************************
        'For Skullcandy Realtail Invoice Report
        Public Function getRetailInvoice_ChargeData() As DataTable
            Dim strSQL As String
            Dim dt As New DataTable()

            Try

                strSQL = "select A.DCode_ID,C.DCode_SDesc,C.DCode_LDesc" & Environment.NewLine
                strSQL &= " ,A.RC_ID,B.RC_Type,B.RC_Value,Active" & Environment.NewLine
                strSQL &= " ,IF(Active=1,RC_Value,0) AS 'ActualCharge'" & Environment.NewLine
                strSQL &= " from tSKRetailChargesMap A" & Environment.NewLine
                strSQL &= " Inner Join tSKRetailCharges B On A.RC_ID=B.RC_ID" & Environment.NewLine
                strSQL &= " Inner Join lcodesdetail C On A.DCode_ID=C.DCode_ID " & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try

        End Function

        '**************************************************************************************************
        'For Skullcandy Realtail Invoice Report
        Public Function getRetailInvoice_ServiceTypeData() As DataTable
            Dim strSQL As String
            Dim dt As New DataTable()

            Try

                strSQL = "Select DCode_ID,DCode_SDesc,DCode_LDesc from lcodesdetail where  mCode_ID=62;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************************
        'For Skullcandy Realtail Invoice Report
        Public Function getOutputDatatableDef(ByVal dtServiceTypeData As DataTable, ByVal arrlstChargeType As ArrayList) As DataTable

            Dim strSQL As String = "select '' AS RMA, '' AS UPC"
            Dim dt As New DataTable()
            Dim row As DataRow
            Dim i As Integer

            Try
                For Each row In dtServiceTypeData.Rows
                    strSQL &= ", 0 AS '" & row("DCode_LDesc") & "'"
                Next
                strSQL &= ",0 AS 'Total Qty'"

                For i = 0 To arrlstChargeType.Count - 1
                    strSQL &= ", 0.00 AS '" & arrlstChargeType(i) & "'"
                Next
                strSQL &= ",0.00 AS 'Total Charge'"

                dt = Me._objDataProc.GetDataTable(strSQL)

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************************
        Public Function getRetailPalletManifestData(ByVal iCustID As Integer, ByVal strPalletName As String) As DataTable

            Dim strSQL As String = ""
            Dim dt As New DataTable()
            Dim row As DataRow
            Dim i As Integer

            Try
                strPalletName = strPalletName.Replace("'", "''") 'if any

                'after new disposition process
                strSQL = "SELECT UPC, SKU, Dcode_LDesc as Disposition, Pallett_name as 'PalletName', MP_ID, count(*) as Quantity" & Environment.NewLine
                strSQL &= "FROM tpallett inner join tsk_device on tpallett.pallett_id = tsk_device.Pallet_ID" & Environment.NewLine
                strSQL &= " INNER JOIN lcodesdetail on tsk_device.dcode_ID = lcodesdetail.dcode_ID" & Environment.NewLine
                strSQL &= " WHERE tpallett.cust_id = " & iCustID & " and pallett_name = '" & strPalletName & "'" & Environment.NewLine
                strSQL &= " GROUP BY UPC, SKU , Dcode_LDesc, Pallett_name, MP_ID ;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)

                If Not dt.Rows.Count > 0 Then
                    'Old disposition process
                    strSQL = "SELECT UPC, '' as SKU,  Dcode_LDesc as Disposition, PalletName, 0 AS MP_ID, sum(tbulkreceive.Quantity) as Quantity" & Environment.NewLine
                    strSQL &= " FROM tbulkreceive INNER JOIN tbulkrecpallet on tbulkreceive.BRP_ID = tbulkrecpallet.BRP_ID" & Environment.NewLine
                    strSQL &= " INNER JOIN lcodesdetail on tbulkreceive.dcode_ID = lcodesdetail.dcode_ID" & Environment.NewLine
                    strSQL &= " WHERE PalletName = '" & strPalletName & "'" & Environment.NewLine
                    strSQL &= " GROUP BY UPC, Dcode_LDesc, PalletName ;" & Environment.NewLine

                    dt = Me._objDataProc.GetDataTable(strSQL)
                End If

                Return dt

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '***************************************************************************************************
        Public Sub PrintNextQCAuditRpt(ByVal iCustID As Integer, ByVal strLoc As String)
            Dim strPath As String = "\\phq-file\public\Dept\Skullcandy\Retail\QCAuditRpt\"
            Dim strSql As String = "", strPathFileName As String = "", strToday As String = ""
            Dim dt As DataTable
            Dim iQCAuditBatchNo As Integer = 0, i As Integer = 0, iOpenQCAuditQty As Integer = 0

            Try
                strToday = Generic.MySQLServerDateTime(1)

                '1: Check if location has no qc audit unit
                strSql = "SELECT count(*) as Qty " & Environment.NewLine
                strSql &= "FROM tsk_device" & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " AND Pallet_ID = 0 " & Environment.NewLine
                strSql &= "AND Location = '" & strLoc & "' AND QC_Audit_Batch = 0 " & Environment.NewLine
                iOpenQCAuditQty = Me._objDataProc.GetIntValue(strSql)
                If iOpenQCAuditQty = 0 Then Throw New Exception("All units has been qc audit.")

                '2: define next qc audit batch #
                strSql = "SELECT (max(QC_Audit_Batch) + 1 ) AS NextQCAuditBatchNo " & Environment.NewLine
                strSql &= "FROM tsk_device" & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " AND Pallet_ID = 0 " & Environment.NewLine
                strSql &= "AND Location = '" & strLoc & "' " & Environment.NewLine
                iQCAuditBatchNo = Me._objDataProc.GetIntValue(strSql)
                If iQCAuditBatchNo = 0 Then Throw New Exception("System can't define next qc audit batch #.")

                '3: Set QC Audit Batch No and date
                strSql = "UPDATE tsk_device SET QC_Audit_Batch = " & iQCAuditBatchNo & ", QC_Audit_Date = '" & strToday & "'" & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & " AND Pallet_ID = 0 " & Environment.NewLine
                strSql &= "AND Location = '" & strLoc & "' AND QC_Audit_Batch = 0 " & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                '4: Print QC audit Report
                strSql = "SELECT A.QC_Audit_Batch as 'QC Bat. #', QC_Audit_Date as 'QC Audit Date' , A.UPC, A.SKU, B.Dcode_LDesc as Disposition, count(*) as Quantity " & Environment.NewLine
                strSql &= "FROM tsk_device A INNER JOIN lcodesdetail B ON A.DCode_ID = B.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & " AND A.Pallet_ID = 0 " & Environment.NewLine
                strSql &= "AND Location = '" & strLoc & "' AND A.QC_Audit_Batch = " & iQCAuditBatchNo & Environment.NewLine
                strSql &= "Group by UPC, SKU , Dcode_LDesc " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strPathFileName = strPath & CDate(strToday).ToString("yyyyMMddHHmmss") & "_" & strLoc & "_" & iQCAuditBatchNo & ".xls"
                    Generic.CreateExelReport(dt, 1, strPathFileName, 0, , 1, 1, "F", New Integer() {3})
                    Kill(strPathFileName)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************************
        Public Sub PrintAllQCAuditRpt(ByVal iCustID As Integer, ByVal strLoc As String)
            Dim strPath As String = "\\phq-file\public\Dept\Skullcandy\Retail\QCAuditRpt\"
            Dim strSql As String = "", strPathFileName As String = "", strToday As String = ""
            Dim dt As DataTable

            Try
                strToday = Generic.MySQLServerDateTime(1)

                ' Print QC audit Report
                strSql = "SELECT A.QC_Audit_Batch as 'QC Bat. #', QC_Audit_Date as 'QC Audit Date' , A.UPC, A.SKU, B.Dcode_LDesc as Disposition, count(*) as Quantity " & Environment.NewLine
                strSql &= "FROM tsk_device A INNER JOIN lcodesdetail B ON A.DCode_ID = B.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & " AND A.Pallet_ID = 0 " & Environment.NewLine
                strSql &= "AND Location = '" & strLoc & "' AND A.QC_Audit_Batch > 0 " & Environment.NewLine
                strSql &= "Group by QC_Audit_Batch, UPC, SKU , Dcode_LDesc " & Environment.NewLine
                strSql &= "ORDER BY QC_Audit_Batch"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    strPathFileName = strPath & CDate(strToday).ToString("yyyyMMddHHmmss") & "_" & strLoc & "_all" & ".xls"
                    Generic.CreateExelReport(dt, 1, strPathFileName, 0, , 1, 1, "F", New Integer() {3})
                    Kill(strPathFileName)
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************************

#End Region

#Region "Skullcandy Retail"

        '******************************************************************************************************************************
        Public Function GetLocationQty(ByVal iCustID As Integer, Optional ByVal strLoc As String = "") As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Location " & Environment.NewLine
                strSql &= ", if(A.Dcode_ID in (3998, 4002), '', A.UPC) as 'UPC'" & Environment.NewLine
                strSql &= ", if(A.Dcode_ID in (3998, 4002), '', A.Sku) as 'Sku' " & Environment.NewLine
                strSql &= ", A.Dcode_ID, Dcode_Ldesc as 'Disposition', Dcode_Sdesc , Count(*) as 'Qty' " & Environment.NewLine
                strSql &= "FROM tsk_device A INNER JOIN lcodesdetail B ON A.DCode_ID = B.Dcode_ID " & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & " AND A.Pallet_ID = 0 " & Environment.NewLine
                If strLoc.Trim.Length > 0 Then strSql &= "AND Location = '" & strLoc & "'" & Environment.NewLine
                strSql &= "GROUP BY Location, UPC, Sku, Dcode_Ldesc "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetRetailReceivingCount(ByVal iCustID As Integer, _
                                                Optional ByVal strRMA As String = "", _
                                                Optional ByVal iUserID As Integer = 0, _
                                                Optional ByVal strRecDate As String = "") As Integer
            Dim strSql As String = ""

            Try
                strSql = "SELECT Count(*) as 'Qty' " & Environment.NewLine
                strSql &= "FROM tsk_device " & Environment.NewLine
                strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
                If strRMA.Trim.Length > 0 Then strSql &= "AND RMA = '" & strRMA & "'" & Environment.NewLine
                If iUserID > 0 Then strSql &= "AND Rec_UserID = " & iUserID & Environment.NewLine
                If strRecDate.Trim.Length > 0 Then strSql &= "AND Rec_Date = '" & strRecDate & "'" & Environment.NewLine

                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function ReceiveRetailDevice(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strRMA As String, ByVal iDispostionID As Integer, _
                                            ByVal strDispositionSDesc As String, ByVal strDispositionLDesc As String, ByVal strUPC As String, _
                                            ByVal strRecDate As String, ByVal iUserID As Integer, ByVal strMasterPackInnerPackPrinterName As String, _
                                            ByVal strDevicePrinterName As String, ByVal iMimAvailLoc As Integer) As Integer
            Dim strSql As String = "", strLoc As String = "", strSku As String
            Dim dtDevices As DataTable, dtPackaging As DataTable, dtLoc As DataTable
            Dim iLocMaxQty As Integer, i As Integer, iPalletID As Integer, iPalletShipType As Integer, iDeviceID As Integer

            Try
                If iDispostionID = 3998 OrElse iDispostionID = 4002 Then  'Scrap & C-Stock
                    'iPalletID = CreatePalletID(iCustID, Me.Retail_LOCATIONID, iDispostionID, strDispositionSDesc, strRecDate, iPalletShipType)
                    'Dim iMasterpackID As Integer = CreateMasterPack(0, 0, 1, "", "", iDispostionID, strRecDate, iUserID, strLoc, iPalletID)
                    'Dim iInnerpackID As Integer = CreateInnerPack(0, 0, iMasterpackID, "", "", iDispostionID, strRecDate, iUserID, strLoc)
                    iPalletShipType = 1
                    strSku = GetSkuFromUPC(strUPC)
                    iDeviceID = SaveDevice(iCustID, strRMA, strUPC, strSku, iDispostionID, strRecDate, iUserID, strDispositionLDesc, False)
                Else
                    iPalletShipType = 0
                    ''SF or B-Stock
                    '1: Get packaging information
                    dtPackaging = GetPackingData(strUPC)
                    If dtPackaging.Rows.Count = 0 Then Throw New Exception("No packaging information for UPC.")
                    iLocMaxQty = CInt(dtPackaging.Rows(0)("InnerPackQty")) * CInt(dtPackaging.Rows(0)("MasterPackQty"))
                    strSku = dtPackaging.Rows(0)("Sku")

                    '2: Check if location has exeeded limit
                    dtDevices = GetLocDeviceCountByUPCDisp(strUPC, iDispostionID)
                    If dtDevices.Rows.Count > 1 Then Throw New Exception("Multiple open location for UPC " & strUPC & " and disposition " & iDispostionID & ".")

                    If dtDevices.Rows.Count > 0 AndAlso CInt(dtDevices.Rows(0)("Qty")) > iLocMaxQty Then
                        Throw New Exception("Location contains more device than the limit. Please contact IT.")
                    ElseIf dtDevices.Rows.Count > 0 AndAlso CInt(dtDevices.Rows(0)("Qty")) = iLocMaxQty Then
                        'Close location
                        i = Me.CloseMasterPack(iCustID, iLocID, strUPC, strSku, dtDevices.Rows(0)("Location"), iDispostionID, iUserID, strRecDate, strDispositionSDesc, iPalletShipType, strMasterPackInnerPackPrinterName)
                        If i = 0 Then Throw New Exception("System has failed to close masterpack.")
                        'Refresh device list
                        dtDevices = GetLocDeviceCountByUPCDisp(strUPC, iDispostionID)
                        If dtDevices.Rows.Count > 1 Then Throw New Exception("Multiple open location for UPC " & strUPC & " and disposition " & iDispostionID & ".")
                    End If

                    '3: Define Location
                    If dtDevices.Rows.Count = 0 Then
                        dtLoc = GetLocation(True)  ' New avialble already when Active=1

                        If dtLoc.Rows.Count = 0 Then
                            Throw New Exception("No available location.")
                        Else
                            strLoc = dtLoc.Rows(0)("Location")
                            i = SetLocation(strLoc, strUPC, strSku, iDispostionID, iLocMaxQty, 0)
                            If i = 0 Then Throw New Exception("System has failed to book location.")
                        End If
                    ElseIf CInt(dtDevices.Rows(0)("Qty")) >= iLocMaxQty Then
                        Throw New Exception("Location " & dtDevices.Rows(0)("Location") & " has exceeded the maxium quantity.")
                    Else
                        strLoc = dtDevices.Rows(0)("Location")
                    End If

                    '4: Save Device
                    iDeviceID = SaveDevice(iCustID, strRMA, strUPC, strSku, iDispostionID, strRecDate, iUserID, strLoc, True)

                    '5: Close Location
                    Dim iLocQty As Integer = 0
                    If dtDevices.Rows.Count > 0 Then iLocQty = CInt(dtDevices.Rows(0)("Qty")) + 1 Else iLocQty = 1
                    If iLocQty = iLocMaxQty Then
                        i = Me.CloseMasterPack(iCustID, iLocID, strUPC, strSku, strLoc, iDispostionID, iUserID, strRecDate, strDispositionSDesc, iPalletShipType, strMasterPackInnerPackPrinterName)
                        If i = 0 Then Throw New Exception("System has failed to close masterpack.")
                    Else
                        strSql = "UPDATE tsk_packagingLoc SET Qty = " & iLocQty & Environment.NewLine
                        strSql &= "WHERE Location = '" & strLoc & "'"
                        i = Me._objDataProc.ExecuteNonQuery(strSql)
                    End If

                    'Print Device Label
                    Me.PrintDeviceLabel(iDeviceID, strDevicePrinterName)

                    '**************************************************************
                    'CLOSE OTHER LOCATION IF TOTAL AVAILABEL LOCATION IS LESS THAN 5
                    '**************************************************************
                    CheckForMinAvailableLoc(iCustID, iLocID, iUserID, strRecDate, iMimAvailLoc, strMasterPackInnerPackPrinterName)
                End If

                Return iDeviceID
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtDevices) : Generic.DisposeDT(dtPackaging) : Generic.DisposeDT(dtLoc)
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetLocDeviceCountByUPCDisp(ByVal strUPC As String, ByVal iDispositionID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT Location, Count(*) as Qty FROM tsk_device " & Environment.NewLine
                strSql &= "WHERE UPC = '" & strUPC & "' and Dcode_ID = " & iDispositionID & " AND MP_ID = 0 " & Environment.NewLine
                strSql &= "Group By Location "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetSkuFromUPC(ByVal strUPC As String) As String
            Dim strSql As String = ""
            Try
                strSql &= "SELECT Sku FROM tsk_packaging WHERE UPC = '" & strUPC & "'"
                Return Me._objDataProc.GetSingletonString(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetPackingData(ByVal strUPC As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql &= "SELECT * FROM tsk_packaging WHERE UPC = '" & strUPC & "'"
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function SetLocation(ByVal strLoc As String, ByVal strUPC As String, ByVal strSku As String, _
                                    ByVal iDCodeID As Integer, ByVal iLocMaxQty As Integer, ByVal iQty As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql &= "UPDATE tsk_packagingLoc SET UPC = '" & strUPC & "', sku = '" & strSku & "', DCode_ID = " & iDCodeID & Environment.NewLine
                strSql &= ", MaxQty = " & iLocMaxQty & ", Qty = " & iQty & " WHERE Location = '" & strLoc & "'"
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function CloseMasterPack(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal strUPC As String, ByVal strSku As String, _
                                        ByVal strLoc As String, ByVal iDcodeID As Integer, _
                                        ByVal iUserID As Integer, ByVal strDateTime As String, ByVal strDispositionSDesc As String, _
                                        ByVal iPalletShipType As Integer, ByVal strMasterPackInnerPackPrinterName As String) As Integer
            Dim strSql As String
            Dim i As Integer, j As Integer, iInnerpackID As Integer, iMasterpackID As Integer, _
                iMaxMPQty As Integer, iMaxIPQty As Integer, iMaxQty As Integer, iTotalInnerpack As Integer, iPalletID As Integer
            Dim dt As DataTable, dtPackaging As DataTable, dtInnerPackIDs As DataTable
            Dim R1 As DataRow
            Dim objSkullcandyPrint As PSS.Data.Buisness.SkullcandyPrint

            Try
                strSql = "SELECT * FROM tsk_device WHERE Location = '" & strLoc & "' AND MP_ID = 0 "
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    If iPalletShipType = 0 Then
                        dtPackaging = Me.GetPackingData(strUPC)
                        If dtPackaging.Rows.Count = 0 Then
                            Throw New Exception("Packaging information is missing for UPC " & strUPC & ".")
                        ElseIf dtPackaging.Rows.Count > 1 Then
                            Throw New Exception("Duplicate packaging information for UPC " & strUPC & ".")
                        Else
                            iMaxMPQty = CInt(dtPackaging.Rows(0)("MasterPackQty"))
                            iMaxIPQty = CInt(dtPackaging.Rows(0)("InnerPackQty"))
                        End If
                    Else
                        iMaxMPQty = 1
                        iMaxIPQty = dt.Rows.Count
                    End If
                    iMaxQty = (iMaxMPQty * iMaxIPQty)

                    If dt.Rows.Count > iMaxQty Then Throw New Exception("Device count has exceeded the maxium quantity of master pack.")

                    'Create Pallet ID
                    iPalletID = Me.CreatePalletID(iCustID, iLocID, iDcodeID, strDispositionSDesc, strDateTime, iPalletShipType)
                    If iPalletID = 0 Then Throw New Exception("System has failed to creat pallet ID.")

                    iTotalInnerpack = Math.Ceiling(dt.Rows.Count / iMaxIPQty)
                    iDcodeID = dt.Rows(0)("DCode_ID")

                    'Create masterpack
                    iMasterpackID = Me.CreateMasterPack(dt.Rows.Count, iMaxQty, iTotalInnerpack, strUPC, strSku, CInt(dt.Rows(0)("DCode_ID")), strDateTime, iUserID, strLoc, iPalletID)

                    'Assign masterpack ID to device
                    strSql = "UPDATE tsk_device SET MP_ID = " & iMasterpackID & ", Pallet_ID = " & iPalletID & Environment.NewLine
                    strSql &= " WHERE Location = '" & strLoc & "' AND MP_ID = 0 and Pallet_ID = 0 "
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                    If i = 0 Then Throw New Exception("System has failed to assign master pack ID to device.")

                    'Create Innerpack ID
                    Dim iQty As Integer
                    For j = 1 To iTotalInnerpack
                        If j = iTotalInnerpack AndAlso (dt.Rows.Count Mod iMaxIPQty) > 0 Then
                            iQty = dt.Rows.Count Mod (iMaxIPQty)
                        Else
                            iQty = iMaxIPQty
                        End If
                        i = Me.CreateInnerPack(iQty, iMaxIPQty, iMasterpackID, strUPC, strSku, dt.Rows(0)("DCode_ID"), strDateTime, iUserID, strLoc)
                    Next j

                    If iPalletShipType = 0 Then
                        'Reset location to be available
                        i = SetLocation(strLoc, "", "", 0, 0, 0)
                        If i = 0 Then Throw New Exception("System has failed to reset location.")
                        'Print Master Pack & Inner Pack label
                        PrintMasterPackLabel(iMasterpackID, strMasterPackInnerPackPrinterName)
                        PrintInnerPackLabel(iMasterpackID, strMasterPackInnerPackPrinterName, iTotalInnerpack)
                    End If
                Else
                    Throw New Exception("Can't close location with no device.")
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtPackaging)
                objSkullcandyPrint = Nothing
            End Try
        End Function

        '******************************************************************************************************************************
        Public Sub PrintMasterPackLabel(ByVal iMasterPackID As Integer, ByVal strMasterPackInnerPackPrinterName As String)
            Dim objSkullcandyPrint As PSS.Data.Buisness.SkullcandyPrint

            Try
                objSkullcandyPrint = New PSS.Data.Buisness.SkullcandyPrint()
                objSkullcandyPrint.Print_RetailMasterPackLabel(iMasterPackID, 1, strMasterPackInnerPackPrinterName)
            Catch ex As Exception
                Throw ex
            Finally
                objSkullcandyPrint = Nothing
            End Try
        End Sub

        '******************************************************************************************************************************
        Public Sub PrintRetailPalletReport(ByVal iPalletID As String)
            Dim objSkullcandyPrint As PSS.Data.Buisness.SkullcandyPrint

            Try
                objSkullcandyPrint = New PSS.Data.Buisness.SkullcandyPrint()
                objSkullcandyPrint.Print_RetailPalletReport(iPalletID, 1)
            Catch ex As Exception
                Throw ex
            Finally
                objSkullcandyPrint = Nothing
            End Try
        End Sub

        '******************************************************************************************************************************
        Public Sub PrintInnerPackLabel(ByVal iMasterPackID As Integer, ByVal strMasterPackInnerPackPrinterName As String, ByVal iCopyQty As Integer)
            Dim strSql As String = ""
            Dim objSkullcandyPrint As PSS.Data.Buisness.SkullcandyPrint
            Dim dt As DataTable
            Dim i As Integer

            Try
                If iCopyQty = 0 Then Exit Sub

                objSkullcandyPrint = New PSS.Data.Buisness.SkullcandyPrint()
                strSql = "SELECT DISTINCT IP_ID FROM tsk_device A" & Environment.NewLine
                strSql &= "INNER JOIN tsk_InnerPack B ON A.MP_ID = B.MP_ID" & Environment.NewLine
                strSql &= "WHERE A.MP_ID = " & iMasterPackID
                dt = Me._objDataProc.GetDataTable(strSql)
                For i = 0 To dt.Rows.Count - 1
                    objSkullcandyPrint.Print_RetailInnerPackLabel(CInt(dt.Rows(i)("IP_ID")), 1, strMasterPackInnerPackPrinterName)
                    If (i + 1) = iCopyQty Then Exit For
                Next i

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : objSkullcandyPrint = Nothing
            End Try
        End Sub

        '******************************************************************************************************************************
        Public Sub PrintDeviceLabel(ByVal iDeviceID As Integer, ByVal strPrinterName As String)
            Dim strSql As String = ""
            Dim objSkullcandyPrint As PSS.Data.Buisness.SkullcandyPrint
            Dim dt As DataTable

            Try
                strSql = "SELECT A.*, DCode_SDesc, DCode_LDesc " & Environment.NewLine
                strSql &= "FROM tsk_device A " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail B ON A.DCode_ID = B.DCode_ID " & Environment.NewLine
                strSql &= "WHERE SC_DeviceID = " & iDeviceID & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                objSkullcandyPrint = New PSS.Data.Buisness.SkullcandyPrint()
                objSkullcandyPrint.Print_RetailShelfLocationLabel(dt.Rows(0)("DCode_SDesc"), dt.Rows(0)("Location"), 1, dt.Rows(0)("SC_DeviceID"), strPrinterName)

            Catch ex As Exception
                Throw ex
            Finally
                objSkullcandyPrint = Nothing : Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************************************************
        Public Sub PrintRMALabel(ByVal strRMA As String, ByVal strPrinterName As String, ByVal iCopyQty As Integer)
            Dim strSql As String = ""
            Dim objSkullcandyPrint As PSS.Data.Buisness.SkullcandyPrint
            Dim dt As DataTable

            Try
                objSkullcandyPrint = New PSS.Data.Buisness.SkullcandyPrint()
                objSkullcandyPrint.Print_RetailRMALabel(strRMA, iCopyQty, strPrinterName)
            Catch ex As Exception
                Throw ex
            Finally
                objSkullcandyPrint = Nothing : Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************************************************
        Public Function CreateMasterPack(ByVal iQty As Integer, ByVal iMaxQty As Integer, ByVal iTotalInnerPack As Integer, _
                                         ByVal strUPC As String, ByVal strSku As String, ByVal iDcodeID As Integer, _
                                         ByVal strDateTime As String, ByVal iUserID As Integer, ByVal strLoc As String, ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Dim iMasterpackID As Integer = 0

            Try
                'Create masterpack
                strSql = "INSERT INTO tsk_masterpack ( " & Environment.NewLine
                strSql &= " Qty, MaxQty, TotalInnerPack, UPC, Sku, DCode_ID, CreatedDate, CreatedUserID, Location, Pallet_ID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= iQty & ", " & iMaxQty & ", " & iTotalInnerPack & Environment.NewLine
                strSql &= ", '" & strUPC & "', '" & strSku & "'," & iDcodeID & Environment.NewLine
                strSql &= ", '" & CDate(strDateTime).ToString("yyyy-MM-dd hh:mm:ss") & "', " & iUserID & ", '" & strLoc & "' " & Environment.NewLine
                strSql &= ", " & iPalletID & Environment.NewLine
                strSql &= ") "
                iMasterpackID = Me._objDataProc.idTransaction(strSql, "tsk_masterpack")
                If iMasterpackID = 0 Then Throw New Exception("System has failed to create master pack ID.")

                Return iMasterpackID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function CreateInnerPack(ByVal iQty As Integer, ByVal iMaxQty As Integer, ByVal iMasterpackID As Integer, _
                                         ByVal strUPC As String, ByVal strSku As String, ByVal iDcodeID As Integer, _
                                         ByVal strDateTime As String, ByVal iUserID As Integer, ByVal strLoc As String) As Integer
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO tsk_InnerPack ( " & Environment.NewLine
                strSql &= " UPC, Sku, DCode_ID, Qty, MaxQty, MP_ID, CreatedDate, CreatedUserID, Location " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " '" & strUPC & "', '" & strSku & "'," & iDcodeID & Environment.NewLine
                strSql &= ", " & iQty & ", " & iMaxQty & ", " & iMasterpackID & Environment.NewLine
                strSql &= ", '" & CDate(strDateTime).ToString("yyyy-MM-dd hh:mm:ss") & "', " & iUserID & ", '" & strLoc & "' " & Environment.NewLine
                strSql &= ") "
                i = Me._objDataProc.ExecuteNonQuery(strSql)

                If i = 0 Then Throw New Exception("System has failed to create innerpack ID.")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function SaveDevice(ByVal iCustID As Integer, ByVal strRMA As String, ByVal strUPC As String, ByVal strSku As String, ByVal iDcodeID As Integer, _
                                   ByVal strRecDate As String, ByVal iUserID As Integer, ByVal strLoc As String, ByVal booGetBackDeviceID As Boolean)
            Dim strSql As String = ""
            Dim i As Integer = 0

            Try
                strSql = "INSERT INTO tsk_device (Cust_ID, RMA, UPC, Sku, DCode_ID, Location, Rec_Date, Rec_UserID " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= iCustID & ", '" & strRMA & "', '" & strUPC & "', '" & strSku & "', " & iDcodeID & ", '" & strLoc & "'" & Environment.NewLine
                strSql &= ", '" & CDate(strRecDate).ToString("yyyy-MM-dd") & "', " & iUserID & Environment.NewLine
                strSql &= ") "
                If booGetBackDeviceID = True Then
                    i = Me._objDataProc.idTransaction(strSql, "tsk_device")
                Else
                    i = Me._objDataProc.idTransaction(strSql, "tsk_device")
                End If
                If i = 0 Then Throw New Exception("System has failed to insert device.")

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function CreatePalletID(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iDisposition As Integer, _
                                       ByVal strDispositionSDesc As String, ByVal strDateTime As String, ByVal iPalletShipType As Integer) As Integer
            Dim strSql As String, strPalletName As String
            Dim iPalletID As Integer

            Try
                strSql = "SELECT Pallett_ID FROM tpallett WHERE Cust_ID = " & iCustID & " AND Pallett_ShipDate is null " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 AND Pallet_SkuLen = " & iDisposition
                iPalletID = Me._objDataProc.GetIntValue(strSql)

                If iPalletID = 0 Then
                    strPalletName = "SCR" & CDate(strDateTime).ToString("yyyyMMdd") & strDispositionSDesc
                    strPalletName = Data.Production.Shipping.GetPalletNameNextSeqNo(Me._objDataProc, iCustID, iLocID, strPalletName, 3)
                    iPalletID = Data.Production.Shipping.CreatePallet(iCustID, iLocID, 0, 0, strPalletName, iPalletShipType, iDisposition, 0, 0, 0)
                End If

                Return iPalletID
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetSkullcandyUnshipPallets(ByVal iCustID As Integer, Optional ByVal strPalletSkuLen As String = "", _
                                                   Optional ByVal iPalletID As Integer = 0) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT Pallett_ID, Pallett_ShipDate, Pallet_Invalid " & Environment.NewLine
                strSql &= ", Loc_ID, Pallet_ShipType, Pallet_SkuLen, Pallett_QTY, Pallett_Name as 'Pallet Name' " & Environment.NewLine
                strSql &= ", If(Dcode_LDesc is null , '', Dcode_LDesc) as 'Disposition'" & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN lcodesdetail ON tpallett.Pallet_SkuLen = lcodesdetail.Dcode_ID" & Environment.NewLine
                strSql &= "WHERE tpallett.cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND Pallett_ShipDate is null " & Environment.NewLine
                strSql &= "AND Pallet_Invalid = 0 " & Environment.NewLine
                If strPalletSkuLen.Trim.Length > 0 Then strSql &= "AND Pallet_SkuLen = '" & strPalletSkuLen & "'" & Environment.NewLine
                If iPalletID > 0 Then strSql &= "AND Pallett_ID = " & iPalletID & Environment.NewLine
                strSql &= "Order by Pallett_Name Desc"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetPalletContent(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT A.MP_ID, Count(*) as qty FROM tsk_masterpack A" & Environment.NewLine
                strSql &= "INNER JOIN tsk_device B ON A.MP_ID = B.MP_ID WHERE A.Pallet_ID = " & iPalletID & Environment.NewLine
                strSql &= "GROUP BY A.MP_ID "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetDeviceCntInPallet(ByVal iPalletID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT count(*) as cnt FROM tsk_device " & Environment.NewLine
                strSql &= "WHERE Pallet_ID = " & iPalletID & Environment.NewLine

                Return Me._objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetCodeDetailByCodeID(ByVal iDcodeID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT * FROM lcodesdetail WHERE DCode_ID = " & iDcodeID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function getPalletData_OldProcess(ByVal strPalletName As String) As DataTable
            'Retail Old Process
            Dim strSql As String
            Try
                strSql = "SELECT sum(tbulkreceive.Quantity) as DeviceCount,PalletName, CONCAT('WH Loc: ', Dcode_LDesc) as Result, Dcode_LDesc as ShipType," & Environment.NewLine
                strSql &= " 'Shipper:' as Footer1,'Approval:' as Footer3,tbulkrecpallet.PalletQty,max(tbulkrecpallet.BRP_ID) as BRP_ID" & Environment.NewLine
                strSql &= " FROM tbulkreceive INNER JOIN tbulkrecpallet on tbulkreceive.BRP_ID = tbulkrecpallet.BRP_ID" & Environment.NewLine
                strSql &= " inner join lcodesdetail on tbulkreceive.dcode_ID = lcodesdetail.dcode_ID" & Environment.NewLine
                strSql &= " where PalletName = '" & strPalletName & "' Group by Dcode_LDesc,lcodesdetail.dcode_ID;" & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function CloseAllInvalidMasterPack(ByVal iPalletID As Integer) As Integer
            Dim strSql As String, strMasterPackIDs As String = ""
            Dim dt As DataTable
            Dim i As Integer

            Try
                strSql = "SELECT DISTINCT A.* FROM tsk_masterpack A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tsk_device B ON A.MP_ID = B.MP_ID " & Environment.NewLine
                strSql &= "WHERE A.Pallet_ID = " & iPalletID & " AND SC_DeviceID is null" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                For i = 0 To dt.Rows.Count - 1
                    If strMasterPackIDs.Trim.Length > 0 Then strMasterPackIDs &= ", "
                    strMasterPackIDs &= dt.Rows(i)("MP_ID")
                Next i

                If strMasterPackIDs.Trim.Length > 0 Then
                    strSql = "Update tsk_masterpack SET Invalid = 1 WHERE MP_ID IN ( " & strMasterPackIDs & ") "
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function AssignMasterpackToPallet(ByVal iPalletID As Integer, ByVal iMasterpackID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "UPDATE tsk_masterpack SET Pallet_ID = " & iPalletID & " WHERE MP_ID = " & iMasterpackID & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function ReopenSkullcandyPallet(ByVal iPalletID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpallett SET Pallett_ShipDate = null, Pallett_BulkShipped = 0, Pallett_ReadyToShipFlg = 0 " & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_ID = " & iPalletID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function CloseSkullcandyPallet(ByVal iPalletID As Integer, ByVal strWHLocation As String, ByVal iQty As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tpallett SET Pallett_ShipDate = now(), Pallett_BulkShipped = 1 " & Environment.NewLine
                strSql &= ", Pallett_ReadyToShipFlg = 1 , WHLocation = '" & strWHLocation & "', Pallett_QTY = " & iQty & Environment.NewLine
                strSql &= "WHERE tpallett.Pallett_ID = " & iPalletID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function SkullcandyRetail_OldProcess_CreatePalletID(ByVal strPalletName As String, ByVal strPalletShipDate As String, _
                                                                 ByVal iPalletSkuLen As Integer, ByVal iCustID As Integer, _
                                                                 ByVal iLocID As Integer, ByVal iQty As Integer, _
                                                                 ByVal iBrpID As Integer) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim i As Integer = 0, iPalletID As Integer = 0
            Try
                'Insert pallet
                strSql = "INSERT tpallett (Pallett_Name,Pallett_ShipDate,Pallett_BulkShipped,Pallett_ReadyToShipFlg,Pallet_ShipType,Pallet_SkuLen,Cust_ID,Loc_ID,Pallett_QTY)" & Environment.NewLine
                strSql &= " VALUES ('" & strPalletName & "','" & strPalletShipDate & "',1,1,1," & iPalletSkuLen & "," & iCustID & "," & iLocID & "," & iQty & ");" & Environment.NewLine
                i = Me._objDataProc.ExecuteNonQuery(strSql)
                If i > 0 Then
                    strSql = "SELECT LAST_INSERT_ID();"
                    iPalletID = Me._objDataProc.GetIntValue(strSql)

                    'update old process tBulkReceive 
                    strSql = "UPDATE tbulkreceive set Pallett_ID=" & iPalletID & " WHERE BRP_ID=" & iBrpID & ";"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                End If

                Return iPalletID

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function CheckForMinAvailableLoc(ByVal iCustID As Integer, ByVal iLocID As Integer, ByVal iUserID As Integer, _
                                                ByVal strDateTime As String, ByVal iMinAvailLoc As Integer, ByVal strMasterPackInnerPackPrinterName As String) As Integer
            Dim strSql As String = ""
            Dim dtNoneAvailLoc As DataTable, dtLoc As DataTable
            Dim i As Integer, iPalletShipType As Integer

            Try
                dtNoneAvailLoc = GetLocation(True)
                If dtNoneAvailLoc.Rows.Count < 5 Then
                    strSql = "SELECT A.*, DCode_SDesc FROM tsk_packagingLoc A " & Environment.NewLine
                    strSql &= "INNER JOIN lcodesdetail B ON A.Dcode_ID = B.DCode_ID " & Environment.NewLine
                    strSql &= "WHERE A.UPC <> '' and A.Dcode_ID <> 0 AND A.Qty > 0 ORDER BY A.Qty DESC "
                    dtLoc = Me._objDataProc.GetDataTable(strSql)
                    If dtLoc.Rows.Count > 0 Then
                        If dtLoc.Rows(0)("DCode_ID") = 3998 OrElse dtLoc.Rows(0)("DCode_ID") = 4002 Then
                            iPalletShipType = 1
                        Else
                            iPalletShipType = 0
                        End If
                        i = Me.CloseMasterPack(iCustID, iLocID, dtLoc.Rows(0)("UPC"), dtLoc.Rows(0)("Sku"), dtLoc.Rows(0)("Location"), dtLoc.Rows(0)("DCode_ID"), iUserID, strDateTime, dtLoc.Rows(0)("DCode_SDesc"), iPalletShipType, strMasterPackInnerPackPrinterName)
                    End If
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtNoneAvailLoc) : Generic.DisposeDT(dtLoc)
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function GetLocation(ByVal booEmptyOnly As Boolean) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT A.*,if(A.Active=1,'Yes','No') as ActiveDesc " & Environment.NewLine
                If booEmptyOnly Then strSql &= ", DCode_LDesc as 'Disposition' " & Environment.NewLine
                strSql &= "FROM tsk_packagingLoc A " & Environment.NewLine
                If booEmptyOnly Then
                    strSql &= "LEFT OUTER JOIN lcodesdetail B ON A.DCode_ID = B.DCode_ID " & Environment.NewLine
                    strSql &= "WHERE A.UPC = '' and A.Dcode_ID = 0  and A.Active=1 " & Environment.NewLine
                    strSql &= "ORDER BY Location " & Environment.NewLine
                Else
                    strSql &= "WHERE A.Active=1 " & Environment.NewLine
                    strSql &= "ORDER BY Location " & Environment.NewLine
                End If

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        ''******************************************************************************************************************************
        'Public Function GetOpenPalletRetailReceiving(ByVal iCustID As Integer) As DataTable
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT Dcode_Ldesc as 'Disposition', SUM(A.Quantity) as 'Qty' " & Environment.NewLine
        '        strSql &= "FROM tbulkreceive A INNER JOIN lcodesdetail B ON A.DCode_ID = B.Dcode_ID " & Environment.NewLine
        '        strSql &= "WHERE A.Cust_ID = " & iCustID & " AND A.BRP_ID = 0 GROUP BY Dcode_Ldesc "
        '        Return Me._objDataProc.GetDataTable(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        ''******************************************************************************************************************************
        'Public Function GetRetailReceivingCount(ByVal iCustID As Integer, _
        '                                        Optional ByVal strRMA As String = "", _
        '                                        Optional ByVal iUserID As Integer = 0, _
        '                                        Optional ByVal strRecDate As String = "") As Integer
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT SUM(Quantity) as 'Qty' " & Environment.NewLine
        '        strSql &= "FROM tbulkreceive " & Environment.NewLine
        '        strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
        '        If strRMA.Trim.Length > 0 Then strSql &= "AND RMA = '" & strRMA & "'" & Environment.NewLine
        '        If iUserID > 0 Then strSql &= "AND RecUserID = " & iUserID & Environment.NewLine
        '        If strRecDate.Trim.Length > 0 Then strSql &= "AND RecDate = '" & strRecDate & "'" & Environment.NewLine

        '        Return Me._objDataProc.GetIntValue(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        ''******************************************************************************************************************************
        'Public Function ReceiveRetailDevice(ByVal iCustID As Integer, ByVal strRMA As String, ByVal iDispostionID As Integer, _
        '                                    ByVal strUPC As String, ByVal strRecDate As String, ByVal iUserID As Integer) As Integer
        '    Dim strSql As String = ""
        '    Dim dt As DataTable

        '    Try
        '        strSql = "SELECT * FROM tbulkreceive WHERE Cust_ID = " & iCustID & " AND RMA = '" & strRMA & "'" & Environment.NewLine
        '        strSql &= "AND UPC = '" & strUPC & "' AND RecDate = '" & strRecDate & "' AND RecUserID = " & iUserID & Environment.NewLine
        '        strSql &= "AND DCode_ID = " & iDispostionID & " AND BRP_ID = 0 "
        '        dt = Me._objDataProc.GetDataTable(strSql)

        '        If dt.Rows.Count > 0 Then
        '            strSql = "UPDATE tbulkreceive SET Quantity = ( Quantity + 1 ) WHERE BR_ID = " & dt.Rows(0)("BR_ID")
        '        Else
        '            strSql = "INSERT INTO tbulkreceive ( RMA, DCode_ID, UPC, Quantity, RecDate, RecUserID, Cust_ID " & Environment.NewLine
        '            strSql &= ") VALUES ( " & Environment.NewLine
        '            strSql &= "'" & strRMA & "', " & iDispostionID & ", '" & strUPC & "', 1, '" & strRecDate & "', " & iUserID & ", " & iCustID & Environment.NewLine
        '            strSql &= ") "
        '        End If

        '        Return Me._objDataProc.ExecuteNonQuery(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Function

        ''******************************************************************************************************************************
        'Public Function GetOpenRecPalletCountByDisposition(ByVal iCustID As Integer, ByVal iDispositionID As Integer) As Integer
        '    Dim strSql As String = ""

        '    Try
        '        strSql = "SELECT SUM(Quantity) as 'Qty' " & Environment.NewLine
        '        strSql &= "FROM tbulkreceive " & Environment.NewLine
        '        strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
        '        strSql &= "AND DCode_ID = " & iDispositionID & Environment.NewLine
        '        strSql &= "AND BRP_ID = 0 " & Environment.NewLine
        '        Return Me._objDataProc.GetIntValue(strSql)
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        ''******************************************************************************************************************************
        'Public Function CloseSCRetailBulkRecPallet(ByVal iCustID As Integer, ByVal iDispositionID As Integer, ByVal strDispositionSDesc As String, _
        '                                           ByVal iUserID As Integer, ByVal iCopyQty As Integer, ByRef strErrMsg As String) As Integer
        '    Dim strSql As String = "", strPalletName As String = "", strToday As String = "", strPalletNextSeqNo As String = ""
        '    Dim dt As DataTable
        '    Dim iPalletQty As Integer = 0, i As Integer = 0

        '    Try
        '        strToday = Generic.MySQLServerDateTime(1)
        '        strPalletName = "SCR" & CDate(strToday).ToString("yyyyMMdd") & strDispositionSDesc
        '        strPalletNextSeqNo = GetBulkRecPalletNameNextSeqNo(iCustID, strPalletName, 3)

        '        If strPalletNextSeqNo.Trim.Length = 0 Then
        '            strErrMsg = "System has failed to define pallet next sequence number." : Return 0
        '        End If

        '        strPalletName &= strPalletNextSeqNo

        '        iPalletQty = GetOpenRecPalletCountByDisposition(iCustID, iDispositionID)
        '        If iPalletQty = 0 Then
        '            strErrMsg = "Pallet is empty." : Return 0
        '        End If

        '        strSql = "SELECT * FROM tbulkrecpallet WHERE Cust_ID = " & iCustID & " AND PalletName = '" & strPalletName & "'" & Environment.NewLine
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        If dt.Rows.Count > 0 Then
        '            strErrMsg = "Pallet '" & strPalletName & "' is already existed. Can't create another one." : Return 0
        '        Else
        '            strSql = "INSERT INTO tbulkrecpallet ( PalletName, PalletCreateDate, PalletCreateUsrID, DCode_ID, PalletQTY, Cust_ID " & Environment.NewLine
        '            strSql &= ") VALUES ( " & Environment.NewLine
        '            strSql &= "'" & strPalletName & "', now(), " & iUserID & ", " & iDispositionID & ", " & iPalletQty & ", " & iCustID & Environment.NewLine
        '            strSql &= ") "
        '            Me._objDataProc.ExecuteNonQuery(strSql)

        '            strSql = "SELECT * FROM tbulkrecpallet WHERE Cust_ID = " & iCustID & " AND PalletName = '" & strPalletName & "'" & Environment.NewLine
        '            dt = Me._objDataProc.GetDataTable(strSql)
        '            If dt.Rows.Count = 0 Then
        '                strErrMsg = "System has failed to create pallet '" & strPalletName & "'." : Return 0
        '            ElseIf dt.Rows.Count > 1 Then
        '                strErrMsg = "Pallet name '" & strPalletName & "' existed more than one." : Return 0
        '            Else
        '                strSql = "UPDATE tbulkreceive SET BRP_ID = " & dt.Rows(0)("BRP_ID") & Environment.NewLine
        '                strSql &= "WHERE Cust_ID = " & iCustID & Environment.NewLine
        '                strSql &= "AND DCode_ID = " & iDispositionID & Environment.NewLine
        '                strSql &= "AND BRP_ID = 0 " & Environment.NewLine
        '                i = Me._objDataProc.ExecuteNonQuery(strSql)
        '                PrintBulkRecPalletLabel(iCustID, strPalletName, iCopyQty)
        '            End If
        '        End If

        '        Return i
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Function

        ''******************************************************************************************************************************
        'Public Sub PrintBulkRecPalletLabel(ByVal iCustID As Integer, ByVal strPalletName As String, ByVal iCopyQty As Integer)
        '    Dim strSql As String = "", strFooter(2) As String
        '    Dim dt, dtPalletInfo As DataTable
        '    Dim objGamestopOpt As PSS.Data.Buisness.GameStopOpt


        '    Try
        '        If IsNothing(dtPalletInfo) Then
        '            strSql = "SELECT A.*, B.Dcode_Ldesc as 'Disposition', C.User_Fullname as 'PalletCreator'" & Environment.NewLine
        '            strSql &= " FROM tbulkrecpallet A  INNER JOIN lcodesdetail B ON A.DCode_ID = B.DCode_ID" & Environment.NewLine
        '            strSql &= "INNER JOIN security.tusers C ON A.PalletCreateUsrID = C.User_ID" & Environment.NewLine
        '            strSql &= "WHERE A.Cust_ID = " & iCustID & " AND A.PalletName = '" & strPalletName & "'"
        '            dtPalletInfo = Me._objDataProc.GetDataTable(strSql)
        '        End If

        '        If dtPalletInfo.Rows.Count = 0 Then
        '            Throw New Exception("System can't find pallet '" & strPalletName & "'.")
        '        ElseIf dtPalletInfo.Rows.Count > 1 Then
        '            Throw New Exception("Pallet '" & strPalletName & "' existed more than one.")
        '        Else
        '            strFooter(0) = "Created Date: " & CDate(dtPalletInfo.Rows(0)("PalletCreateDate")).ToString("MM/dd/yy")
        '            strFooter(1) = "Created By: " & dtPalletInfo.Rows(0)("PalletCreator")
        '            objGamestopOpt = New PSS.Data.Buisness.GameStopOpt()
        '            dt = objGamestopOpt.GetShipPalletData(strPalletName, dtPalletInfo.Rows(0)("PalletQTY"), dtPalletInfo.Rows(0)("Disposition"), "", strFooter)
        '            objGamestopOpt.PrintPalletLabel(dt, iCopyQty)
        '        End If

        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt) : Generic.DisposeDT(dtPalletInfo)
        '    End Try
        'End Sub

        ''******************************************************************************************************************************
        'Public Function GetBulkRecPalletNameNextSeqNo(ByVal iCustID As Integer, ByVal strPalletPrefix As String, ByVal iNumberLength As Integer) As String
        '    Dim strSQL As String = "", strNextSeqNo As String = ""
        '    Dim dt As DataTable

        '    Try
        '        strSQL = "SELECT max(right(PalletName, " & iNumberLength & " ) ) + 1 as NextSequenceNumber " & Environment.NewLine
        '        strSQL &= "FROM tbulkrecpallet " & Environment.NewLine
        '        strSQL &= "WHERE PalletName like '" & strPalletPrefix & "%' " & Environment.NewLine
        '        strSQL &= "AND Cust_ID = " & iCustID & " AND PalletCreateDate = now()" & Environment.NewLine
        '        dt = Me._objDataProc.GetDataTable(strSQL)
        '        If dt.Rows.Count > 0 Then
        '            If Not IsDBNull(dt.Rows(0)("NextSequenceNumber")) Then
        '                strNextSeqNo = dt.Rows(0)("NextSequenceNumber").ToString.Trim.PadLeft(iNumberLength, "0")
        '            Else
        '                strNextSeqNo = "1".PadLeft(iNumberLength, "0")
        '            End If
        '        Else
        '            strNextSeqNo = "1".PadLeft(iNumberLength, "0")
        '        End If

        '        Return strNextSeqNo
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Function

        '******************************************************************************************************************************
        Public Function getRetailPalletData(ByVal iCust_ID As Integer, ByVal strPalletName As String) As DataSet
            Dim strSQL As String = ""
            Dim dt As DataTable
            Dim ds As New DataSet()

            Try
                strSQL = "SELECT C.PalletName,A.RMA,A.UPC,A.Quantity,A.RecDate,B.DCode_LDesc,B.DCode_SDesc" & Environment.NewLine
                strSQL &= " ,C.PalletQTY,C.PalletCreateDate,A.BRP_ID,A.BR_ID,A.DCode_ID,A.Pallett_ID" & Environment.NewLine
                strSQL &= " FROM  tBulkReceive A" & Environment.NewLine
                strSQL &= " INNER JOIN  lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                strSQL &= " INNER JOIN tbulkrecpallet C ON A.BRP_ID=C.BRP_ID" & Environment.NewLine
                strSQL &= " WHERE A.Cust_ID=" & iCust_ID & " AND PalletName ='" & strPalletName.Replace("'", "''") & "'" & Environment.NewLine
                strSQL &= " ORDER BY C.PalletName,A.RMA,A.UPC;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSQL)
                If dt.Rows.Count > 0 Then
                    dt.TableName = "Details"
                    ds.Tables.Add(dt) : dt = Nothing

                    strSQL = "SELECT C.PalletName,A.RMA,SUM(A.Quantity) AS Qty,Count(A.RMA) AS RecorderCount" & Environment.NewLine
                    strSQL &= " FROM  tBulkReceive A" & Environment.NewLine
                    strSQL &= " INNER JOIN  lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                    strSQL &= " INNER JOIN tbulkrecpallet C ON A.BRP_ID=C.BRP_ID" & Environment.NewLine
                    strSQL &= " WHERE A.Cust_ID=" & iCust_ID & " AND PalletName ='" & strPalletName.Replace("'", "''") & "'" & Environment.NewLine
                    strSQL &= " GROUP BY C.PalletName,A.RMA" & Environment.NewLine
                    strSQL &= " ORDER BY C.PalletName,A.RMA,A.UPC;" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSQL)
                    dt.TableName = "ByRMA"
                    ds.Tables.Add(dt) : dt = Nothing

                    strSQL = "SELECT C.PalletName,A.RMA,A.UPC,SUM(A.Quantity) AS Qty,Count(A.UPC) AS RecorderCount" & Environment.NewLine
                    strSQL &= " FROM  tBulkReceive A" & Environment.NewLine
                    strSQL &= " INNER JOIN  lcodesdetail B ON A.DCode_ID=B.DCode_ID" & Environment.NewLine
                    strSQL &= " INNER JOIN tbulkrecpallet C ON A.BRP_ID=C.BRP_ID" & Environment.NewLine
                    strSQL &= " WHERE A.Cust_ID=" & iCust_ID & " AND PalletName ='" & strPalletName.Replace("'", "''") & "'" & Environment.NewLine
                    strSQL &= " GROUP BY C.PalletName,A.RMA,A.UPC" & Environment.NewLine
                    strSQL &= " ORDER BY C.PalletName,A.RMA,A.UPC;" & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSQL)
                    dt.TableName = "ByRMAUPC"
                    ds.Tables.Add(dt) : dt = Nothing
                End If

                Return ds

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try

        End Function

        '******************************************************************************************************************************
        Public Function CreateRetailShipPallet(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, _
                                               ByVal strShipPalletName As String, ByVal strShipDate As String, _
                                               ByVal iPalletQty As Integer, ByVal iBRP_ID As Integer) As Integer

            Dim strSQL As String
            Dim iPallet_ID As Integer = 0
            Dim i As Integer

            Try
                strSQL = "INSERT INTO tPallett (Pallett_Name,Pallett_ShipDate,Pallett_Qty,Cust_ID,Loc_ID)" & Environment.NewLine
                strSQL &= " VALUES ('" & strShipPalletName & "','" & strShipDate & "'," & iPalletQty & "," & iCust_ID & "," & iLoc_ID & ");"
                i = Me._objDataProc.ExecuteNonQuery(strSQL)

                If i > 0 Then
                    strSQL = "SELECT LAST_INSERT_ID();"
                    iPallet_ID = Me._objDataProc.GetIntValue(strSQL)
                    If iPallet_ID > 0 Then
                        strSQL = "UPDATE tBulkReceive SET Pallett_ID= " & iPallet_ID & " where BRP_ID=" & iBRP_ID & ";"
                        Return Me._objDataProc.ExecuteNonQuery(strSQL)
                    Else
                        Return 0
                    End If
                Else
                    Return 0
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        Public Function CreateReceiptReport(ByVal strRptName As String, ByVal strDateStart As String, _
                                            ByVal strDateEnd As String, ByVal iCustID As Integer) As Integer
            Dim strSql, strFileName As String
            Dim dt As DataTable
            Dim objArrData(,) As Object
            Dim i, j As Integer
            Dim objSaveFileDialog As New SaveFileDialog()
            Dim objXL As Excel.Application
            Dim objWorkbook As Excel.Workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try
                strSql = "" : strFileName = ""

                strSql = "SELECT A.RecDate AS 'Receipt Date', C.User_Fullname as 'Receiver', A.RMA" & Environment.NewLine
                strSql &= ", A.UPC , B.Dcode_Ldesc as 'Disposition', SUM(A.Quantity) as 'Qty'" & Environment.NewLine
                strSql &= "FROM tbulkreceive A INNER JOIN lcodesdetail B ON A.DCode_ID = B.Dcode_ID" & Environment.NewLine
                strSql &= "INNER JOIN security.tusers C On A.RecUserID = C.User_ID" & Environment.NewLine
                strSql &= "WHERE A.Cust_ID = " & iCustID & Environment.NewLine
                strSql &= "AND A.RecDate BETWEEN '" & strDateStart & "' AND '" & strDateEnd & "' " & Environment.NewLine
                strSql &= "GROUP BY RecDate, C.User_Fullname, A.RMA, A.UPC, Dcode_Ldesc ;" & Environment.NewLine

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("No data for the selected criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    objXL = New Excel.Application()
                    objWorkbook = objXL.Workbooks.Add

                    ReDim objArrData(dt.Rows.Count + 1, dt.Columns.Count)

                    '***************************************
                    'Assign Data to array
                    '***************************************
                    For i = 0 To dt.Rows.Count - 1
                        For j = 0 To dt.Columns.Count - 1
                            If i = 0 Then objArrData(i, j) = dt.Columns(j).Caption
                            objArrData(i + 1, j) = dt.Rows(i)(j)
                        Next j
                    Next i

                    objXL.Application.DisplayAlerts = False
                    objSheet = objWorkbook.Worksheets("Sheet1")

                    objXL.Columns("B:E").Select()                'Select columns
                    objXL.Selection.NumberFormat = "@"

                    '********************************
                    'Post data to excel sheet
                    '********************************
                    With objSheet
                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & (dt.Rows.Count + 1).ToString).Value = objArrData

                        .Range("A1:" & Buisness.Generic.CalExcelColLetter(dt.Columns.Count) & "1").Select()
                        With objXL.Selection
                            '.WrapText = True
                            .HorizontalAlignment = Excel.Constants.xlCenter
                            .VerticalAlignment = Excel.Constants.xlCenter
                            .font.bold = True
                            '.Font.ColorIndex = 5
                            .Interior.ColorIndex = 37
                            .Interior.Pattern = Excel.Constants.xlSolid
                        End With

                        .Cells.EntireColumn.AutoFit()
                        .Cells.EntireRow.AutoFit()

                        objSaveFileDialog.DefaultExt = "xls"
                        objSaveFileDialog.FileName = strRptName & "_" & Convert.ToDateTime(strDateStart).ToString("yyyyMMdd") & "_" & Convert.ToDateTime(strDateEnd).ToString("yyyyMMdd") & ".xls"
                        objSaveFileDialog.ShowDialog()
                        strFileName = objSaveFileDialog.FileName

                        If strFileName.Trim.Length = 0 Then
                            MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If strFileName.IndexOf("\") < 0 Then Exit Function
                            If File.Exists(strFileName) = True Then Kill(strFileName)
                            objWorkbook.SaveAs(strFileName)
                            MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End With
                    '********************************
                End If

                Return dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objArrData = Nothing
                Generic.DisposeDT(dt)
                If Not IsNothing(objSaveFileDialog) Then
                    objSaveFileDialog.Dispose()
                    objSaveFileDialog = Nothing
                End If
                If Not IsNothing(objSheet) Then
                    PSS.Data.Buisness.Generic.NAR(objSheet)
                End If
                If Not IsNothing(objWorkbook) Then
                    objWorkbook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(objWorkbook)
                End If
                If Not IsNothing(objXL) Then
                    objXL.Quit()
                    PSS.Data.Buisness.Generic.NAR(objXL)
                End If
            End Try
        End Function

        '******************************************************************************************************************************
        Public Sub CreateSkullcandyRetailInvoiceRpt(ByVal strRptName As String, ByVal iCust_ID As Integer, ByVal strBegDate As String, ByVal strEndDate As String)

            Dim strFileName As String
            Dim dtReceived, dtCharge, dtServiceType, dtOutput As DataTable
            Dim arrlstCharges As New ArrayList(), arrlstRMAs As New ArrayList()
            Dim iDCode_ID As Integer, dActualCharge As Double
            Dim strChargeType As String ', strServiceType As String
            Dim arrlstUniqueRMA As New ArrayList()
            Dim oArrData As Object(,)
            Dim row As DataRow, col As DataColumn
            Dim i, j, k, m As Integer

            Dim xlApp As New Excel.Application()
            Dim xlWorkBook As Excel.Workbook = Nothing
            Dim xlWorkSheet As Excel.Worksheet = Nothing
            Dim rng As Excel.Range
            Dim misValue As Object = System.Reflection.Missing.Value

            Dim objSaveFileDialog As New SaveFileDialog()

            Try
                'Get Data------------------------------------------------------------------------------------------------------------------------
                'service Type data
                dtServiceType = getRetailInvoice_ServiceTypeData()

                'Charge data
                dtCharge = getRetailInvoice_ChargeData()

                For Each row In dtCharge.Rows
                    If Not arrlstCharges.Contains(row("RC_Type")) Then
                        arrlstCharges.Add(row("RC_Type"))
                    End If
                Next

                'Received data
                dtReceived = getRetailInvoice_ReceivedData(iCust_ID, strBegDate, strEndDate, dtServiceType, arrlstCharges)

                'Stop if no data
                If Not dtReceived.Rows.Count > 0 Then
                    Throw New Exception("No data for your selection!")
                End If

                'Get unique RMA
                For Each row In dtReceived.Rows
                    If Not arrlstRMAs.Contains(row("RMA")) Then
                        arrlstRMAs.Add(row("RMA"))
                    End If
                Next
                For Each row In dtReceived.Rows
                    iDCode_ID = row("DCode_ID")
                    For i = 0 To arrlstCharges.Count - 1
                        strChargeType = arrlstCharges(i)
                        dActualCharge = getCharge(dtCharge, iDCode_ID, strChargeType)
                        row.BeginEdit()
                        row(row("ServiceType")) = row("quantity")
                        row("Unit " & strChargeType) = dActualCharge
                        row(strChargeType) = Math.Round(dActualCharge * row("quantity"), 2)
                        row.EndEdit()
                    Next
                Next

                'Final Output
                dtOutput = getOutputDatatableDef(dtServiceType, arrlstCharges)
                dtOutput.Rows(0).Delete() : dtOutput.AcceptChanges()
                For Each row In dtReceived.Rows
                    Dim row2 As DataRow = dtOutput.NewRow
                    For Each col In dtOutput.Columns
                        row2(col.ColumnName) = row(col.ColumnName)
                    Next
                    dtOutput.Rows.Add(row2)
                    If Not arrlstUniqueRMA.Contains(row("RMA")) Then
                        arrlstUniqueRMA.Add(row("RMA"))
                    End If
                Next

                If Not dtOutput.Rows.Count > 0 Then
                    Throw New Exception("No data for your selection!")
                End If

                'Create Excel ------------------------------------------------------------------------------------------------------------------------
                xlApp.Visible = False : xlApp.DisplayAlerts = False

                xlApp = New Excel.Application()
                xlWorkBook = DirectCast(xlApp.Workbooks.Add(Type.Missing), Excel.Workbook)

                'Add new worksheets as needed
                If arrlstUniqueRMA.Count > 3 Then
                    For m = 3 To arrlstUniqueRMA.Count - 1 + 1  'one sheet one RMA, plus summary sheet
                        xlWorkSheet = DirectCast(xlApp.Worksheets.Add(misValue, misValue, misValue, misValue), Excel.Worksheet) 'Add sheet
                        xlWorkSheet.Move(misValue, xlApp.ActiveWorkbook.Worksheets(xlApp.ActiveWorkbook.Worksheets.Count)) 'Move to the last 
                    Next
                End If

                For k = 0 To arrlstUniqueRMA.Count - 1  'each RMA
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(k + 1), Excel._Worksheet)

                    Dim dtTmp As DataTable
                    dtTmp = dtOutput.Clone

                    Dim tmpRows() As DataRow = dtOutput.Select("RMA = '" & arrlstUniqueRMA(k) & "'")
                    For Each row In tmpRows
                        dtTmp.ImportRow(row)
                    Next
                    Dim RowsNum As Integer = dtTmp.Rows.Count
                    Dim ColsNum As Integer = dtTmp.Columns.Count
                    ReDim oArrData(RowsNum + 1, ColsNum)

                    For i = 0 To dtTmp.Rows.Count - 1
                        For j = 0 To dtTmp.Columns.Count - 1
                            If i = 0 Then oArrData(i, j) = dtTmp.Columns(j).ColumnName
                            oArrData(i + 1, j) = dtTmp.Rows(i)(j)
                        Next j
                    Next i

                    xlWorkSheet.Range("A1" & ":" & CalExcelColLetter(dtTmp.Columns.Count) & (dtTmp.Rows.Count + 1)).Value = oArrData

                    xlWorkSheet.Name = arrlstUniqueRMA(k)

                    ' rng =  xlWorkSheet.Range(CalExcelColLetter(3) & "1"
                    rng = xlWorkSheet.Range(CalExcelColLetter(7) & "2:" & CalExcelColLetter(7) & dtTmp.Rows.Count + 1.ToString)
                    rng.Formula = "=SUM(C2:F2)"
                    rng = xlWorkSheet.Range(CalExcelColLetter(11) & "2:" & CalExcelColLetter(11) & dtTmp.Rows.Count + 1.ToString)
                    rng.Formula = "=SUM(H2:J2)"

                    rng = xlWorkSheet.Range(CalExcelColLetter(7) & dtTmp.Rows.Count + 2.ToString & ":" & CalExcelColLetter(11) & dtTmp.Rows.Count + 2.ToString)
                    rng.Formula = "=SUM(G2:G" & dtTmp.Rows.Count + 1.ToString & ")"

                    'Auto Fit
                    xlWorkSheet.Cells.EntireColumn.AutoFit()
                    xlWorkSheet.Cells.EntireRow.AutoFit()

                    'Summary sheet
                    xlWorkSheet = DirectCast(xlWorkBook.Sheets(arrlstUniqueRMA.Count + 1), Excel._Worksheet)
                    xlWorkSheet.Name = "Summary"
                    If k = 0 Then
                        xlWorkSheet.Cells(1, 1) = "RMA" : xlWorkSheet.Cells(1, 2) = "Receiving" : xlWorkSheet.Cells(1, 3) = "Label Removal"
                        xlWorkSheet.Cells(1, 4) = "Audio Testing" : xlWorkSheet.Cells(1, 5) = "Total"
                    End If
                    xlWorkSheet.Cells(k + 2, 1) = "'" & arrlstUniqueRMA(k)
                    rng = xlWorkSheet.Range(CalExcelColLetter(2) & k + 2.ToString & ":" & CalExcelColLetter(4) & k + 2.ToString)
                    rng.Formula = "='" & arrlstUniqueRMA(k) & "'!" & CalExcelColLetter(8) & dtTmp.Rows.Count + 2.ToString
                    rng = xlWorkSheet.Range(CalExcelColLetter(5) & k + 2.ToString & ":" & CalExcelColLetter(5) & k + 2.ToString)
                    rng.Formula = "=SUM(B" & (k + 2).ToString & ":D" & (k + 2).ToString & ")"
                    If k = arrlstUniqueRMA.Count - 1 Then
                        rng = xlWorkSheet.Range(CalExcelColLetter(2) & k + 3.ToString & ":" & CalExcelColLetter(5) & k + 3.ToString)
                        rng.Formula = "=SUM(B2" & ":B" & (k + 2).ToString & ")"
                    End If

                    'Auto Fit
                    xlWorkSheet.Cells.EntireColumn.AutoFit()
                    xlWorkSheet.Cells.EntireRow.AutoFit()
                Next


                objSaveFileDialog.DefaultExt = "xls"
                objSaveFileDialog.FileName = strRptName & "_" & Convert.ToDateTime(strBegDate).ToString("yyyyMMdd") & "_" & _
                                             Convert.ToDateTime(strEndDate).ToString("yyyyMMdd") & ".xls"
                objSaveFileDialog.ShowDialog()
                strFileName = objSaveFileDialog.FileName

                If strFileName.Trim.Length = 0 Then
                    MessageBox.Show("No file name has been selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If strFileName.IndexOf("\") < 0 Then Exit Sub
                    If File.Exists(strFileName) = True Then Kill(strFileName)
                    xlWorkBook.SaveAs(strFileName)
                    MessageBox.Show("File has been saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                Throw ex
            Finally

                Generic.DisposeDT(dtReceived) : Generic.DisposeDT(dtCharge)
                Generic.DisposeDT(dtServiceType) : Generic.DisposeDT(dtOutput)
                If Not IsNothing(objSaveFileDialog) Then
                    objSaveFileDialog.Dispose()
                    objSaveFileDialog = Nothing
                End If
                If Not IsNothing(xlWorkSheet) Then
                    PSS.Data.Buisness.Generic.NAR(xlWorkSheet)
                End If
                If Not IsNothing(xlWorkBook) Then
                    xlWorkBook.Close(False)
                    PSS.Data.Buisness.Generic.NAR(xlWorkBook)
                End If
                If Not IsNothing(xlApp) Then
                    xlApp.Quit()
                    PSS.Data.Buisness.Generic.NAR(xlApp)
                End If
            End Try
        End Sub

        '******************************************************************************************************************************
        Private Function getCharge(ByVal dtCharge As DataTable, ByVal iDCode_ID As Integer, ByVal strChargeType As String) As Double
            Dim iDCodeID_Local As Integer
            Dim strChargeType_Local As String
            Dim dResult As Double = 0.0
            Dim row As DataRow

            Try

                For Each row In dtCharge.Rows
                    iDCodeID_Local = row("DCode_ID")
                    strChargeType_Local = row("RC_Type")
                    If iDCodeID_Local = iDCode_ID AndAlso strChargeType_Local = strChargeType Then
                        dResult = row("ActualCharge")
                        Exit For
                    End If
                Next

                Return dResult

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '******************************************************************************************************************************
        Public Function CalExcelColLetter(ByVal iColNo As Integer) As String
            Const iLetterADecNo As Integer = 65
            Const iTotalAlpha As Integer = 26
            Dim strExcelColLetter As String = ""
            Dim iFirstLetter As Integer = 0
            Dim iSecondLeter As Integer = 0
            Dim iTemp As Integer = 0

            Try
                If iColNo < 1 Then Return ""

                If iColNo <= iTotalAlpha Then
                    strExcelColLetter = Chr(iColNo + iLetterADecNo - 1)
                Else
                    iFirstLetter = Math.Floor(iColNo / 26)
                    iSecondLeter = iColNo Mod 26
                    If iSecondLeter = 0 Then
                        iSecondLeter = iTotalAlpha
                        iFirstLetter -= 1
                    End If
                    strExcelColLetter = Chr(iFirstLetter + iLetterADecNo - 1) & Chr(iSecondLeter + iLetterADecNo - 1)
                End If

                Return strExcelColLetter
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************
        'No need. GetLocation for new avialble already take care this by Active=1
        'Public Function IsLocationActive(ByVal strLocation As String) As Boolean
        '    Dim strSql As String = ""
        '    Dim dt As DataTable

        '    Try
        '        strSql &= "SELECT * FROM tsk_packagingLoc where Location ='" & strLocation & "' and Active=1;"
        '        dt = Me._objDataProc.GetDataTable(strSql)
        '        If dt.Rows.Count > 0 Then
        '            Return True
        '        Else
        '            Return False
        '        End If
        '    Catch ex As Exception
        '        Throw ex
        '    End Try
        'End Function

        '******************************************************************************************************************************
        Public Function IsLocationBeingUsed(ByVal strLocation As String) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql &= "SELECT * FROM tsk_packagingLoc Where not Trim(UPC) ='' and Location='" & strLocation & "';"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '******************************************************************************************************************************


#End Region

    End Class
End Namespace