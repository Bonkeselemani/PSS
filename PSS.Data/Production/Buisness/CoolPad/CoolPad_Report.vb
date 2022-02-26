Option Explicit On 

Imports System
Imports System.Data
Imports System.Text
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports System.Globalization
Namespace Buisness.CP
    Public Class CoolPad_Report
        Private _objDataProc As DBQuery.DataProc
        Private _objWikoSharedFunction As PSS.Data.Buisness.WIKO.WIKO_Report
#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
                Me._objWikoSharedFunction = New PSS.Data.Buisness.WIKO.WIKO_Report()
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
#End Region

        Public colDefault As Boolean
        Private strCustomerName As String
       
        Public Function CreateASN(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim dtSummary As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim Locid As Integer = getLocationId(strLocation, iCust_ID)
            Dim strSql, strTempQuery As String
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(Now), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(Now), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xls"
            Dim strRptPath As String = strRptDir & strFileName
            strSql &= " (SELECT ClaimNo as PONumber ,Item_Sku as SKU,Model,SerialNo," & Environment.NewLine
            strSql &= " (Device_sn) as IMEI,'Premier Logitech' as 'Service Center'," & Environment.NewLine
            strSql &= "DATE_FORMAT(D.Device_DateRec,'%m/%d/%Y') as 'Date Received' ,DATE_FORMAT(pkslip_createDT,'%m/%d/%Y') AS 'Date Shipped'," & Environment.NewLine
            strSql &= " (TO_DAYS(P.pkslip_createDT) - TO_DAYS(D.Device_DateRec)) as 'Days',IF(D.Device_Laborlevel=15,0,D.Device_Laborlevel) AS RepairLevel," & Environment.NewLine
            strSql &= "if(G.billcode_id IN(275,267),'RUR',if (G.billcode_id='1020','BER',if (G.billcode_id is Not null,'REF','' ) )) as 'Disposition',pallett_name,Retailer2 as ReturnPlanID,Warranty_Desc AS RepairProgramType,if(Swapped_Device_ID >0,'YES','NO')AS 'Swap device' ,P.pkslip_TrackNo as 'Tracking Number',  D.device_LaborCharge AS  TotalCost   " & Environment.NewLine
            strTempQuery = strSql
            strSql &= "FROM extendedwarranty A" & Environment.NewLine
            strSql &= "inner join tdevice D ON D.device_id=A.device_id " & Environment.NewLine
            strSql &= "inner join Edi.twarehousebox B ON  A.wb_id = B.wb_id" & Environment.NewLine
            strSql &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            strSql &= " INNER JOIN production.tpackingslip P ON P.pkslip_id=C.pkslip_id " & Environment.NewLine
            strSql &= "LEFT JOIN tpretest_data F ON D.device_Id= F.device_Id " & Environment.NewLine
            strSql &= "LEFT JOIN lcodesdetail E ON E.Dcode_id=F.Pttf" & Environment.NewLine
            strSql &= "LEFT JOIN production.tdevicebill G ON D.device_Id= G.device_Id" & Environment.NewLine
            If iOption = 1 Then
                strSql &= " WHERE D.device_SN IN ( " & strImei & " ) AND  bulkordertype_id=1 GROUP BY Device_sn  " & Environment.NewLine
            Else
                strSql &= " WHERE A.sourcefile not like '%seed%' AND  bulkordertype_id=1 AND A.LOC_ID=" & Locid & "  AND pkslip_createDT BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  Pallet_ShipType!=13  " & Environment.NewLine
                strSql &= "GROUP BY D.device_id order by pallett_name" & Environment.NewLine
            End If
            strSql &= " ) UNION " & Environment.NewLine
            strSql &= strTempQuery
            strSql &= "FROM extendedwarranty A" & Environment.NewLine
            strSql &= "inner join Edi.twarehousebox B ON  A.wb_id = B.wb_id" & Environment.NewLine
            strSql &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
            strSql &= " INNER JOIN production.tpackingslip P ON P.pkslip_id=C.pkslip_id " & Environment.NewLine
            strSql &= "inner join tdevice D ON D.device_id=A.Swapped_Device_ID" & Environment.NewLine
            strSql &= "LEFT JOIN tpretest_data F ON D.device_Id= F.device_Id " & Environment.NewLine
            strSql &= "LEFT JOIN lcodesdetail E ON E.Dcode_id=F.Pttf" & Environment.NewLine
            strSql &= "LEFT JOIN production.tdevicebill G ON D.device_Id= G.device_Id" & Environment.NewLine
            If iOption = 1 Then
                strSql &= " WHERE D.device_SN IN ( " & strImei & " )  GROUP BY Device_sn  " & Environment.NewLine
            Else
                strSql &= " WHERE  A.LOC_ID=" & Locid & "  AND pkslip_createDT BETWEEN '" & dateRec & "' AND '" & dateEnd & "'  and  Pallet_ShipType!=13 " & Environment.NewLine
                strSql &= "GROUP BY D.device_id  order by pallett_name )" & Environment.NewLine
            End If
            dt1 = Me._objDataProc.GetDataTable(strSql)
            If dt1.Rows.Count = 0 Then
                MsgBox("There is no data in PSS Database for the criterion provided.")
                Return 0
                Exit Function
            Else

                If iReportType = 3 Then
                    ds.Tables.Add(dt1)
                    objExcelRpt = New ExcelReports(False)
                    objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "AB", "AC", "AD", "AE", "AG", "AH", "AK", "S", "N"})
                    Return dt1.Rows.Count
                Else
                    Return CreateRawDataExcelFileInvoice(dt1, dt2, "yyyy-MM-dd", "yyyy-MM-dd", strRptPath, getCustomerName(iCust_ID))
                End If
            End If

        End Function

        Public Function getCustomerLocation(ByVal iCust_ID As Integer, ByVal cboLocation As ComboBox) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtrow As DataRow

            Try
                strSql = "SELECT Loc_name FROM tlocation INNER JOIN tcustomer " & Environment.NewLine
                strSql &= " ON tlocation.Cust_id = tcustomer.Cust_id  where tcustomer.cust_ID=" & iCust_ID & ";"

                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    cboLocation.Items.Add("Select Location")
                    Return 1
                Else
                    cboLocation.Items.Add("Select Location")
                    For Each dtrow In dt.Rows
                        cboLocation.Items.Add(dtrow("Loc_name"))
                    Next
                End If

            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function

        Public Function getLocationId(ByVal Loc_id As String, ByVal iCust_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim dtrow As DataRow
            Dim LocId As Integer
            Try
                strSql = "SELECT Loc_id FROM tlocation where Loc_name  like '%" & Loc_id & "%' and Cust_ID =" & iCust_ID & " ;" & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Exit Function
                Else
                    For Each dtrow In dt.Rows
                        LocId = dtrow("Loc_id")
                    Next
                End If
                Return LocId
            Catch ex As Exception
                Throw ex
            Finally
                dt = Nothing
            End Try
        End Function



        Public Function CreateInventoryReport(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocation As String, ByVal iReportType As Integer, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer

            Dim strSql As String
            Dim dtSummary As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim strTempQuery As String
            Dim Locid As Integer = getLocationId(strLocation, iCust_ID)
            Try

                strSql &= "   SELECT IF(LoadedDateTime  IS NULL,'', IF(DATE_FORMAT(LoadedDateTime,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(LoadedDateTime ,'%m/%d/%Y')))  AS 'Loaded Date', CONCAT_WS(' ',C.Cust_Name1,D.Loc_Name) AS 'Customer',SerialNo as IMEI,OEM_RA AS RMANumber ,Model,Item_SKU AS SKU ,Rep_ID as Delivery,ClaimNo as PONumber,ClaimLineNo as POLineNumber" & Environment.NewLine
                If iReportType <> 1 Then
                    strSql &= " , IF(Device_DateRec IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(Device_DateRec,'%m/%d/%Y'))) AS 'Date Received'" & Environment.NewLine
                End If
                If iReportType = 1 Then
                    strSql &= " ,In_Pallet_ID" & Environment.NewLine
                ElseIf iReportType = 3 Then
                    strSql &= " ,pallett_Name as 'PAllet Name',pallett_shipdate as 'Ship Date'" & Environment.NewLine
                End If
                strSql &= " ,In_Carton_ID, A.Account, Retailer, ShipTo_Name2, Retailer2, Cust2PSSI_Carrier,Cust2PSSI_TrackNo,Cust2PSSI_BillofLading,ShipTo_Name,Address1" & Environment.NewLine
                strSql &= " ,Address2,City,State_Name,ZipCode,ReturnToName,ReturnAddress1,ReturnAddress2,ReturnCity,ReturnState,ReturnZip,ReturnPhone,ReturnPhoneExt" & Environment.NewLine
                strSql &= " ,BillToName,BillToAttn,Warranty_Desc,Failure_Code,Failure_Reason" & Environment.NewLine
                If iReportType = 4 Then
                    strSql &= ",  Device_DateBill AS 'Bill Date'" & Environment.NewLine
                    'strSql &= ",  IF( pallett_shipdate  IS NOT NULL ,'Produced (Shipped)', IF(Device_DateRec IS NOT NULL, 'Received' , 'Waiting for Receiving (RA Uploaded)' ) ) as Status" & Environment.NewLine
                    strSql &= ",   IF( Device_DateShip  IS NOT NULL AND  Pallet_ShipType!=13 ,'Produced (Shipped)', IF(Device_DateRec IS NOT NULL, 'Received' , 'Waiting for Receiving (RA Uploaded)' ) ) as Status" & Environment.NewLine
                End If
                If iReportType = 1 Then
                    strSql &= " ,B.WO_CustWO AS 'Work_Order',IF(A.device_id>0,'RECEIVED','OPEN') AS 'Status',  SourceFile" & Environment.NewLine
                ElseIf iReportType = 2 Then
                    strSql &= " ,B.WO_CustWO AS 'Work_Order',IF(E.Device_DateShip IS  NULL ,'RECEIVED ','SHIPPED') AS 'Status',  SourceFile" & Environment.NewLine
                End If

                strSql &= " FROM Production.extendedwarranty A" & Environment.NewLine
                strSql &= " INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
                strSql &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
                If iReportType = 7 Then
                    strSql = ""
                    strSql = " SELECT SerialNo AS 'IMEI', (laborLevel) AS 'Labor Level',F.part_Number,PSPrice_Desc as Description " & Environment.NewLine
                End If
                If iReportType = 3 OrElse iReportType = 7 Then
                    strTempQuery = strSql
                End If

                Select Case iReportType

                    Case 1 'RA_uploaded
                        If iOption = 1 Then
                            strSql &= " WHERE SerialNo IN ( " & strImei & " ) and A.sourcefile not like '%REF%'" & Environment.NewLine
                        Else
                            strSql &= " WHERE A.sourcefile not like '%REF%' AND A.Cust_ID=" & iCust_ID & "  AND A.LOC_ID=" & Locid & " AND LoadedDateTime BETWEEN '" & dateRec & "' AND '" & dateEnd & "' " & Environment.NewLine
                        End If

                    Case 2 'Received_Report
                        strSql &= " INNER JOIN production.tdevice E ON A.device_id= E.device_id " & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " ) AND A.sourcefile not like '%REF%' Group BY E.device_id " & Environment.NewLine
                        Else
                            strSql &= " WHERE A.sourcefile not like '%REF%' AND  A.Cust_ID=" & iCust_ID & " AND A.LOC_ID=" & Locid & "   AND E.Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' Group BY E.device_id" & Environment.NewLine
                        End If
                    Case 3, 7 'Shipped 
                        strSql &= " INNER JOIN production.tdevice E ON A.device_id= E.device_id " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpallett P ON P.pallett_id= E.pallett_id " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpackingslip S ON S.pkslip_id=P.pkslip_id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.tdevicebill F ON F.device_Id= E.device_Id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.lpsprice J ON  J.PSPrice_Number=F.part_Number" & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " )AND  A.sourcefile not like '%seed%' Group BY E.device_id" & Environment.NewLine
                        Else
                            strSql &= " WHERE A.sourcefile not like '%seed%' AND A.Cust_ID=" & iCust_ID & " AND  A.LOC_ID=" & Locid & " AND pkslip_createDT BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  Pallet_ShipType!=13 Group BY E.device_id " & Environment.NewLine
                        End If
                        strSql &= " UNION " & Environment.NewLine
                        strSql &= strTempQuery
                        strSql &= " INNER JOIN production.tdevice E ON E.device_id=A.swapped_device_id  " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpallett P ON P.pallett_id= E.pallett_id " & Environment.NewLine
                        strSql &= " INNER JOIN production.tpackingslip S ON S.pkslip_id=P.pkslip_id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.tdevicebill F ON F.device_Id= E.device_Id " & Environment.NewLine
                        strSql &= " LEFT OUTER JOIN  production.lpsprice J ON  J.PSPrice_Number=F.part_Number" & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " ) Group BY E.device_id" & Environment.NewLine
                        Else
                            strSql &= " WHERE A.Cust_ID=" & iCust_ID & " AND  A.LOC_ID=" & Locid & " AND pkslip_createDT BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and  Pallet_ShipType!=13 Group BY E.device_id " & Environment.NewLine
                        End If
                    Case 4 'Status 
                        'strTempQuery = strSql
                        strSql &= " LEFT OUTER JOIN production.tdevice E ON E.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id))   " & Environment.NewLine
                        strSql &= " LEFT JOIN tpallett P ON P.Pallett_ID=E.Pallett_ID " & Environment.NewLine
                        If iOption = 1 Then
                            strSql &= " WHERE device_SN IN ( " & strImei & " ) and A.sourcefile not like '%REF%'  AND (if ( P.Pallett_ID IS NOT  NULL ,  Pallet_ShipType!=13  ,device_dateship IS NULL AND P.Pallett_ID IS null )) " & Environment.NewLine
                        Else
                            strSql &= " WHERE  A.cust_ID=" & iCust_ID & " AND  A.LOC_ID IN (" & Locid & ") AND SOURCEFILE NOT LIKE '%Seed%' AND (if ( P.Pallett_ID IS NOT  NULL ,  Pallet_ShipType!=13 ,device_dateship IS NULL AND P.Pallett_ID IS null ))  " & Environment.NewLine
                        End If
                    Case Else
                        Return 0
                End Select

                dtSummary = Me._objDataProc.GetDataTable(strSql)
                dtSummary.TableName = strRptName
                ds.Tables.Add(dtSummary)
                objExcelRpt = New ExcelReports(False)
                objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(ds, strRptName & Format(Now, "yyyyMMddHHmmss"), New String() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "AB", "AC", "AD", "AE", "AG", "AH", "AK", "S", "N"})
                Return dtSummary.Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function CreatePretestRawDataRpt(ByVal iCust_id As Integer, ByVal strFromDt As String, _
                                        ByVal strToDt As String, _
                                        ByRef strRptPath As String, ByVal strLocation As String, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim dt1 As New DataTable()
            Dim dt2 As New DataTable()
            Dim R1, R2 As DataRow
            Dim strsql As String = ""
            Dim strRptDir As String = "R:\Pretest Reports\"
            Dim strFileName As String = CStr(Format(CDate(strFromDt), "yyyy-MM-dd")) & "__" & CStr(Format(CDate(strToDt), "yyyy-MM-dd")) & "  " & Now.Minute & Now.Second & ".xlsx"
            strRptPath = strRptDir & strFileName
            Dim Locid As Integer = getLocationId(strLocation, iCust_id)
            Try
                strsql = "SELECT Distinct tdevice.device_sn as 'Serial No'," & Environment.NewLine
                strsql &= "'' as Pretester, " & Environment.NewLine
                strsql &= "'' as 'Pretester Shift', " & Environment.NewLine
                strsql &= "tpretest_data.tech_id, " & Environment.NewLine
                strsql &= "DATE_FORMAT(tpretest_data.Date_Rec,'%m/%d/%Y') as 'Pretest Date', " & Environment.NewLine
                strsql &= "lqcresult.QCResult as 'Result', " & Environment.NewLine
                strsql &= "if(lcodesdetail.Dcode_ID = 2515, '', Concat(trim(lcodesdetail.Dcode_Sdesc), ' - ', trim(Dcode_Ldesc))) as 'Failure Reason', " & Environment.NewLine
                strsql &= "tpretest_data.Device_id , " & Environment.NewLine
                strsql &= "lgroups.Group_Desc as 'Group', " & Environment.NewLine
                strsql &= "lline.Line_Number as 'Line', " & Environment.NewLine
                strsql &= "if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as 'CostCenter', " & Environment.NewLine

                strsql &= "tmodel.Model_desc as 'Model' " & Environment.NewLine
                strsql &= ", Prod_Desc as 'Product Type', tpretest_data.FailOther " & Environment.NewLine
                strsql &= ",  if ( Warranty_Desc is NULL,'Underfined', Warranty_Desc) as Account " & Environment.NewLine
                strsql &= " ,MAX(tdevice.device_laborLevel)AS device_laborLevel,SourceFile FROM tpretest_data " & Environment.NewLine
                strsql &= "INNER JOIN tdevice on tpretest_data.device_id = tdevice.device_id " & Environment.NewLine
                strsql &= "INNER JOIN  extendedwarranty on tpretest_data.device_id = extendedwarranty.device_id " & Environment.NewLine
                strsql &= "INNER JOIN tmodel on tdevice.Model_id = tmodel.Model_id " & Environment.NewLine
                strsql &= "INNER JOIN lproduct on tmodel.Prod_ID = lproduct.Prod_ID " & Environment.NewLine
                strsql &= "INNER JOIN lcodesdetail on tpretest_data.PTtf = lcodesdetail.Dcode_id " & Environment.NewLine
                strsql &= "INNER JOIN lqcresult on tpretest_data.qcresult_id = lqcresult.QCResult_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tgrouplinemap on tpretest_data.GrpLineMap_ID = tgrouplinemap.GrpLineMap_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lgroups on tgrouplinemap.Group_ID = lgroups.group_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lline on tgrouplinemap.Line_ID = lline.line_id " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tcostcenter on tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine

                If iOption = 1 Then
                    strsql &= "WHERE device_SN IN ( " & strImei & " )" & Environment.NewLine
                Else
                    strsql &= "WHERE tpretest_data.pretest_wkDt >= '" & strFromDt & "' and " & Environment.NewLine
                    strsql &= "tpretest_data.pretest_wkDt <= '" & strToDt & "' and  " & Environment.NewLine
                    strsql &= " tdevice.LOC_ID=" & Locid & " " & Environment.NewLine

                End If
                strsql &= "GROUP BY tpretest_data.Device_id order by tpretest_data.pretest_wkDt ;"
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


                    CreateRawDataExcelFile(dt1, strFromDt, strToDt, strRptPath, getCustomerName(iCust_id))
                    Return 1
                End If

            Catch ex As Exception
                Throw New Exception("Buisness.Pretest.CreatePretestRawDataRpt(): " & Environment.NewLine & ex.Message.ToString)
            Finally
                R1 = Nothing

            End Try
        End Function
        Public Sub CreateRawDataExcelFile(ByVal dt1 As DataTable, _
                                                   ByVal strFromDt As String, _
                                                   ByVal strToDt As String, _
                                                   ByVal strRptPath As String, ByVal strCustomerName As String)
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
                objExcel.Application.Cells(i, 1).Value = "Serial No"
                objExcel.Application.Cells(i, 2).Value = "Pretester"
                objExcel.Application.Cells(i, 3).Value = "Group"
                objExcel.Application.Cells(i, 4).Value = "Pretest Date"
                objExcel.Application.Cells(i, 5).Value = "Pretest Result"
                objExcel.Application.Cells(i, 6).Value = "Fail/Pass Reason"
                objExcel.Application.Cells(i, 7).Value = "Account"
                objExcel.Application.Cells(i, 8).Value = "Model"
                objExcel.Application.Cells(i, 9).Value = "Product Type"
                objExcel.Application.Cells(i, 10).Value = "Source File"

                '*****************************************
                'Set column widths
                '*****************************************
                objSheet.Columns("A:A").ColumnWidth = 32.71 'Serial No
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("B:B").ColumnWidth = 43.43  'Return Type
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("C:C").ColumnWidth = 32.71 'Group
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("D:D").ColumnWidth = 32.71 'Pretest Date
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("E:E").ColumnWidth = 9.43  'Pretest Result
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("F:F").ColumnWidth = 20.86  'Fail/Pass Reason
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("G:G").ColumnWidth = 20.86    'Account
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("H:H").ColumnWidth = 20.43 'Model
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("I:I").ColumnWidth = 25.71 'Product Type 
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("J:J").ColumnWidth = 25.7    'Source File
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlLeft


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
                objSheet.Range("A3:J3").Select()
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

                ReDim arrData(dt1.Rows.Count, 10)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Serial No")) Then
                        arrData(i, 0) = Trim(R1("Serial No"))
                    End If
                    If Not IsDBNull(R1("Pretester")) Then
                        arrData(i, 1) = Trim(R1("Pretester"))
                    End If
                    If Not IsDBNull(R1("Group")) Then
                        arrData(i, 2) = Trim(R1("Group"))
                    End If
                    If Not IsDBNull(R1("Pretest Date")) Then
                        arrData(i, 3) = Trim(R1("Pretest Date"))
                    End If
                    If Not IsDBNull(R1("Result")) Then
                        arrData(i, 4) = Trim(R1("Result"))
                    End If
                    If Not IsDBNull(R1("Failure Reason")) Then
                        arrData(i, 5) = Trim(R1("Failure Reason"))
                    End If
                    If Not IsDBNull(R1("Account")) Then
                        arrData(i, 6) = Trim(R1("Account"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrData(i, 7) = Trim(R1("Model"))
                    End If
                    If Not IsDBNull(R1("Product Type")) Then
                        arrData(i, 8) = Trim(R1("Product Type"))
                    End If
                    If Not IsDBNull(R1("SourceFile")) Then
                        arrData(i, 9) = Trim(R1("SourceFile"))
                    End If
                    i += 1
                Next R1

                objSheet.Range("A4", "J" & (dt1.Rows.Count + 3)).Value = arrData

                '*****************************************
                'Set the borders for the whole report
                '*****************************************
                objSheet.Range("A3:J" & (dt1.Rows.Count + 3)).Select()

                'Set Font
                setFont(objExcel)
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
                objExcel.Application.Cells(1, 1).Value = strCustomerName & "Pretest Raw Data Report".ToUpper
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
                Throw New Exception(" CreateRawDataExcelFile(): " & Environment.NewLine & ex.Message.ToString)
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
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub


        Public Function CreateRawDataExcelFileInvoice(ByRef dt1 As DataTable, ByRef dt2 As DataTable, ByVal strFromDt As String, _
                                                        ByVal strToDt As String, _
                                                        ByVal strRptPath As String, ByVal strCustomerName As String) As Integer
            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet, objSheet2 As Excel.Worksheet    ' Excel Worksheet
            Dim dSum_Kitting, dSUM As Decimal
            Dim R1, R2 As DataRow
            Dim i As Integer = 3
            Dim k As Integer = dt1.Rows.Count + 6
            Dim arrData(0, 0) As String
            Dim arrDatasummary(0, 0) As String
            Dim arrDatasummary1(0, 0) As String
            Dim iPartCount As Integer
            Dim dBilling As Decimal
            Dim j As Integer = 0

            Try
                '******************************************************************
                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objBook = objExcel.Workbooks.Add                    'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                objSheet = objBook.Worksheets.Item(1)
                objSheet.Name = "INVOICE REPORT" 'Select a Sheet 1 for this
                'objSheet2 = objBook.Worksheets.Item(2)
                objExcel.ActiveSheet.Pagesetup.Orientation = 2      ' 1 = Portrait ; 2 = landscape
                '*****************************************
                objExcel.Application.Cells(i, 1).Value = "PONumber"
                objExcel.Application.Cells(i, 2).Value = "SKU"
                objExcel.Application.Cells(i, 3).Value = "Model"
                objExcel.Application.Cells(i, 4).Value = "Original IMEI"
                objExcel.Application.Cells(i, 5).Value = "New IMEI"
                objExcel.Application.Cells(i, 6).Value = "Service Center"
                objExcel.Application.Cells(i, 7).Value = "Date Received"
                objExcel.Application.Cells(i, 8).Value = "Date Shipped"
                objExcel.Application.Cells(i, 9).Value = "Days"
                objExcel.Application.Cells(i, 10).Value = "Code Failure1"
                objExcel.Application.Cells(i, 11).Value = "Failure Reason1"
                objExcel.Application.Cells(i, 12).Value = "Code Failure2"
                objExcel.Application.Cells(i, 13).Value = "Failure Reason2"
                objExcel.Application.Cells(i, 14).Value = "Code Failure3"
                objExcel.Application.Cells(i, 15).Value = "Failure Reason3"
                objExcel.Application.Cells(i, 16).Value = "Code Failure4"
                objExcel.Application.Cells(i, 17).Value = "Failure Reason4"
                objExcel.Application.Cells(i, 18).Value = "RepairLevel"
                objExcel.Application.Cells(i, 19).Value = "Disposition"
                objExcel.Application.Cells(i, 20).Value = "pallett_name"
                objExcel.Application.Cells(i, 21).Value = "ReturnPlanID"
                objExcel.Application.Cells(i, 22).Value = "RepairProgramType"
                objExcel.Application.Cells(i, 23).Value = "PartNo1"
                objExcel.Application.Cells(i, 24).Value = "UseQty1"
                objExcel.Application.Cells(i, 25).Value = "PartNo2"
                objExcel.Application.Cells(i, 26).Value = "UseQty2"
                objExcel.Application.Cells(i, 27).Value = "PartNo3"
                objExcel.Application.Cells(i, 28).Value = "UseQty3"
                objExcel.Application.Cells(i, 29).Value = "PartNo4"
                objExcel.Application.Cells(i, 30).Value = "UseQty4"
                objExcel.Application.Cells(i, 31).Value = "PartNo5"
                objExcel.Application.Cells(i, 32).Value = "UseQty5"
                objExcel.Application.Cells(i, 33).Value = "PartNo6"
                objExcel.Application.Cells(i, 34).Value = "UseQty6"
                objExcel.Application.Cells(i, 35).Value = "PartNo7"
                objExcel.Application.Cells(i, 36).Value = "UseQty7"
                objExcel.Application.Cells(i, 37).Value = "PartNo8"
                objExcel.Application.Cells(i, 38).Value = "UseQty8"
                objExcel.Application.Cells(i, 39).Value = "PartNo9"
                objExcel.Application.Cells(i, 40).Value = "UseQty9"
                objExcel.Application.Cells(i, 41).Value = "PartNo10"
                objExcel.Application.Cells(i, 42).Value = "UseQty10"
                objExcel.Application.Cells(i, 43).Value = "Swap device"
                objExcel.Application.Cells(i, 44).Value = "Labor Charge"
                objExcel.Application.Cells(i, 45).Value = "Parts Charge"
                objExcel.Application.Cells(i, 46).Value = "Total Cost"
                objExcel.Application.Cells(i, 47).Value = "Tracking Number"

                '*****************************************

                objSheet.Columns("A:A").ColumnWidth = 15 'PO
                objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("B:B").ColumnWidth = 15   'SKU
                objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("C:C").ColumnWidth = 20 'MODEL
                objSheet.Columns("C:C").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("D:D").ColumnWidth = 20   'Original IMEI
                objSheet.Columns("D:D").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("E:E").ColumnWidth = 20  'New IMEI
                objSheet.Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("F:F").ColumnWidth = 20  'Service Center
                objSheet.Columns("F:F").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("G:G").ColumnWidth = 20    'DATE Received
                objSheet.Columns("G:G").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("H:H").ColumnWidth = 20    'Date Shiiped
                objSheet.Columns("H:H").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("I:I").ColumnWidth = 15    'Days
                objSheet.Columns("I:I").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("J:J").ColumnWidth = 30  'Code Failure1
                objSheet.Columns("J:J").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("K:K").ColumnWidth = 35  'Failure Reason1
                objSheet.Columns("K:K").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("L:L").ColumnWidth = 30  'Code Failure2
                objSheet.Columns("L:L").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("M:M").ColumnWidth = 35  'Failure Reason2
                objSheet.Columns("M:M").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("N:N").ColumnWidth = 30  'Code Failure3
                objSheet.Columns("N:N").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("O:O").ColumnWidth = 35  'Failure Reason3
                objSheet.Columns("O:O").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("P:P").ColumnWidth = 30  'Code Failure4
                objSheet.Columns("P:P").HorizontalAlignment = Excel.Constants.xlCenter

                objSheet.Columns("Q:Q").ColumnWidth = 35  'Failure Reason4
                objSheet.Columns("Q:Q").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("R:R").ColumnWidth = 14    'Repair Level
                objSheet.Columns("R:R").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("S:S").ColumnWidth = 20    'Disposition
                objSheet.Columns("S:S").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("T:T").ColumnWidth = 20    'Pallett_Name
                objSheet.Columns("T:T").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("U:U").ColumnWidth = 25    'Return Plan Id
                objSheet.Columns("U:U").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("V:V").ColumnWidth = 30    'Reapair Program Type
                objSheet.Columns("V:V").HorizontalAlignment = Excel.Constants.xlLeft
                ' PART USED 
                objSheet.Columns("W:W").ColumnWidth = 15    'PARTN1
                objSheet.Columns("W:W").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("X:X").ColumnWidth = 15   'USEDQTY1
                objSheet.Columns("X:X").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("Y:Y").ColumnWidth = 15    'PARTN2
                objSheet.Columns("Y:Y").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("Z:Z").ColumnWidth = 15   'USEDQTY2
                objSheet.Columns("Z:Z").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AA:AA").ColumnWidth = 15    'PARTN3
                objSheet.Columns("AA:AA").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AB:AB").ColumnWidth = 15    'USEDQTY3
                objSheet.Columns("AB:AB").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AC:AC").ColumnWidth = 15    'PARTN4
                objSheet.Columns("AC:AC").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AD:AD").ColumnWidth = 15   'USEDQTY4
                objSheet.Columns("AD:AD").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AE:AE").ColumnWidth = 15    'PARTN5
                objSheet.Columns("AE:AE").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AF:AF").ColumnWidth = 15   'USEDQTY5
                objSheet.Columns("AF:AF").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AG:AG").ColumnWidth = 15    'PARTN6
                objSheet.Columns("AG:AG").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AH:AH").ColumnWidth = 15   'USEDQTY6
                objSheet.Columns("AH:AH").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AI:AI").ColumnWidth = 15    'PARTN7
                objSheet.Columns("AI:AI").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AJ:AJ").ColumnWidth = 15    'USEDQTY7
                objSheet.Columns("AJ:AJ").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AK:AK").ColumnWidth = 15   'PARTN8
                objSheet.Columns("AK:AK").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AL:AL").ColumnWidth = 15   'USEDQTY8
                objSheet.Columns("AL:AL").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AM:AM").ColumnWidth = 15    'PARTN9
                objSheet.Columns("AM:AM").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AN:AN").ColumnWidth = 15   'USEDQTY9
                objSheet.Columns("AN:AN").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AO:AO").ColumnWidth = 15    'PARTN10
                objSheet.Columns("AO:AO").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AP:AP").ColumnWidth = 15    'USEDQTY10
                objSheet.Columns("AP:AP").HorizontalAlignment = Excel.Constants.xlLeft

                '*****************************************
                'Format cells Data Type
                '*****************************************
                objSheet.Columns("AQ:AQ").ColumnWidth = 20   'SWAPPED DEVICE
                objSheet.Columns("AQ:AQ").HorizontalAlignment = Excel.Constants.xlLeft

                objSheet.Columns("AR:AR").ColumnWidth = 20    'LASBOR CHARGE
                objSheet.Columns("AR:AR").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AS:AS").ColumnWidth = 20    'PART CHARGE
                objSheet.Columns("AS:AS").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AT:AT").ColumnWidth = 20    'TOTAL COST
                objSheet.Columns("AT:AT").HorizontalAlignment = Excel.Constants.xlLeft
                objSheet.Columns("AU:AU").ColumnWidth = 50    'TOTAL COST
                objSheet.Columns("AU:AU").HorizontalAlignment = Excel.Constants.xlLeft
                '*****************************************
                objSheet.Columns("UA:UA").Select()
                objExcel.Selection.NumberFormat = "@"
                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A3:AU3").Select()
                With objExcel.Selection
                    .WrapText = True
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    .font.bold = True
                    .Font.ColorIndex = 5
                End With

                'Set horizontal alignment for the header for deatils 
                '*****************************************
                objSheet.Range("A" & 1 & ":AU" & 1 & "").Select()
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

                ReDim arrData(dt1.Rows.Count, 50)

                For Each R1 In dt1.Rows
                    dBilling = gettdeviceBill(R1("IMEI"))
                    If Not IsDBNull(R1("PONumber")) Then
                        arrData(i, 0) = Trim(R1("PONumber"))
                    End If
                    If Not IsDBNull(R1("SKU")) Then
                        arrData(i, 1) = Trim(R1("SKU"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrData(i, 2) = Trim(R1("Model"))
                    End If
                    If Not IsDBNull(R1("SerialNo")) Then
                        arrData(i, 3) = Trim(R1("SerialNo"))
                    End If
                    If Not IsDBNull(R1("IMEI")) Then
                        If R1("IMEI") = R1("SerialNo") Then
                            arrData(i, 4) = ""
                        Else
                            arrData(i, 4) = Trim(R1("IMEI"))
                        End If
                    End If
                    If Not IsDBNull(R1("Service Center")) Then
                        arrData(i, 5) = Trim(R1("Service Center"))
                    End If
                    If Not IsDBNull(R1("Date Received")) Then
                        arrData(i, 6) = Trim(R1("Date Received"))
                    End If
                    If Not IsDBNull(R1("Date Shipped")) Then
                        arrData(i, 7) = Trim(R1("Date Shipped"))
                    End If
                    If Not IsDBNull(R1("Days")) Then
                        arrData(i, 8) = Trim(R1("Days"))
                    End If
                    Dim dtFailureCode As New DataTable()
                    dtFailureCode = getDeviceFailCode(R1("SerialNo"))
                    Dim iCountFailure As Integer = 0
                    Dim iFailureCount As Integer
                    For iFailureCount = 9 To 16 Step 2
                        If iCountFailure < dtFailureCode.Rows.Count Then
                            Dim strFailCode As String = dtFailureCode.Rows(iCountFailure).Item("Dcode_Sdesc")
                            Dim strFailCodeDesc As String = dtFailureCode.Rows(iCountFailure).Item("Dcode_Ldesc")
                            arrData(i, iFailureCount) = strFailCode
                            arrData(i, iFailureCount + 1) = strFailCodeDesc
                        Else
                            arrData(i, iFailureCount) = ""
                            arrData(i, iFailureCount + 1) = ""
                        End If
                        iCountFailure += 1
                    Next
                    If Not IsDBNull(R1("RepairLevel")) Then
                        arrData(i, 17) = Trim(R1("RepairLevel"))
                    End If
                    If Not IsDBNull(R1("Disposition")) Then
                        arrData(i, 18) = Trim(R1("Disposition"))
                    End If
                    If Not IsDBNull(R1("pallett_name")) Then
                        arrData(i, 19) = Trim(R1("pallett_name"))
                    End If
                    If Not IsDBNull(R1("ReturnPlanID")) Then
                        arrData(i, 20) = Trim(R1("ReturnPlanID"))
                    End If
                    If Not IsDBNull(R1("RepairProgramType")) Then
                        arrData(i, 21) = Trim(R1("RepairProgramType"))
                    End If
                    Dim dtPartNumber As New DataTable()
                    dtPartNumber = getDevicePart(R1("IMEI"))
                    Dim iCountPart As Integer = 0
                    For iPartCount = 22 To 41 Step 2
                        If iCountPart < dtPartNumber.Rows.Count Then
                            Dim strPartNumber As String = dtPartNumber.Rows(iCountPart).Item("Part_Number")
                            If strPartNumber = "RUR" Or strPartNumber = "Swap" Or strPartNumber = "BER" Then
                                arrData(i, iPartCount) = ""
                                arrData(i, iPartCount + 1) = ""
                            Else
                                arrData(i, iPartCount) = strPartNumber
                                arrData(i, iPartCount + 1) = 1
                            End If
                        Else
                            arrData(i, iPartCount) = ""
                            arrData(i, iPartCount + 1) = ""
                        End If

                        iCountPart += 1
                    Next
                    If Not IsDBNull(R1("Swap device")) Then
                        arrData(i, 42) = Trim(R1("Swap device"))
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        arrData(i, 43) = Trim(R1("TotalCost"))
                    End If
                    If Not IsDBNull(dBilling) Then
                        arrData(i, 44) = Trim(dBilling)
                    End If
                    If Not IsDBNull(R1("TotalCost")) Then
                        dSUM = Convert.ToDecimal(Trim(R1("TotalCost"))) + dBilling ' add Packaging Material Cost,labor charge and Kitting Cost
                        R1("TotalCost") = dSUM
                        arrData(i, 45) = "$" & FormatNumber(Trim(R1("TotalCost")), 2, TriState.False, TriState.True, TriState.True)
                    End If

                    If Not IsDBNull(R1("Tracking Number")) Then
                        arrData(i, 46) = " " & Trim(R1("Tracking Number")).ToString
                    End If
                    i += 1
                Next R1
                objSheet.Range("AU4", "AU" & (dt1.Rows.Count + 3)).NumberFormat = "@"
                objSheet.Range("A4", "AU" & (dt1.Rows.Count + 3)).Value = arrData
                objSheet.Range("A4", "AU" & (dt1.Rows.Count + 3)).Value = objSheet.Range("A4", "AU" & (dt1.Rows.Count + 3)).Value
                objSheet.Range("A3:AU" & (dt1.Rows.Count + 3)).Select()
                objSheet.Range("AR4", "AR" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AS4", "AS4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"
                objSheet.Range("AT4", "AT4" & (dt1.Rows.Count + 3)).NumberFormat = "$#,##0.00;[Red]$#,##0.00"

                objSheet.Range("D4", "D" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("E4", "E" & (dt1.Rows.Count + 3)).NumberFormat = 0
                objSheet.Range("T4", "T" & (dt1.Rows.Count + 3)).NumberFormat = 0

                objSheet.Range("H4", "H" & (dt1.Rows.Count + 3)).NumberFormat = "dd/MM/yyyy"
                objSheet.Range("G4", "G" & (dt1.Rows.Count + 3)).NumberFormat = "dd/MM/yyyy"

                Dim iXrange As Integer = (dt1.Rows.Count + 3)
                Dim result As String
                result = dt1.Compute("SUM(TotalCost)", "")
                objExcel.Application.Cells(dt1.Rows.Count + 4, 44).Value = "TOTAL"
                objExcel.Application.Cells(dt1.Rows.Count + 4, 46).Value = "$" & FormatNumber(result, 2, TriState.False, TriState.True, TriState.True)
               
             setFont(objExcel)
                '************************************************
                'Add report header

                objSheet.Range("A1:S1").Select()
                With objExcel.Selection
                    .MergeCells = True
                    .HorizontalAlignment = Excel.Constants.xlLeft
                    '.font.bold = True
                    .Font.Size = 16
                    .Font.Name = "Verdana"
                    .Font.ColorIndex = 3 'Red
                    .HorizontalAlignment = -4108
                End With
                objExcel.Application.Cells(1, 1).Value = (strCustomerName & "INVOICE REPORT").ToUpper
                '*************************************************

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
                Return 1
            Catch ex As Exception
                Throw New Exception(" CreateRawDataExcelFile(): " & Environment.NewLine & ex.Message.ToString)
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
        End Function
        Private Function gettdeviceBill(ByVal iDeviceId As String) As Decimal
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql &= "SELECT SUM(PsPrice_StndCost)as total FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill B ON A.device_id=B.device_id    " & Environment.NewLine
            strSql &= "INNER JOIN lpsprice C ON  C.PSPrice_Number=B.part_Number" & Environment.NewLine
            strSql &= "WHERE device_sn='  " & iDeviceId & " ' " & Environment.NewLine
            'strSql = "SELECT SUM(PsPrice_StndCost)as total FROM tdevicebill E INNER JOIN production.lpsprice D ON  D.PSPrice_Number=E.part_Number where device_id=" & iDeviceId & "" & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            If Not IsDBNull(dt.Rows(0)("total")) Then
                Return (dt.Rows(0)("total"))
            Else
                Return 0
            End If
        End Function

        Private Function getDevicePart(ByVal iDeviceSN As String) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql = " SELECT distinct(Part_Number) FROM tdevice A " & Environment.NewLine
            strSql &= "INNER JOIN tdevicebill B ON A.device_id=B.device_id    " & Environment.NewLine
            strSql &= "WHERE device_sn='" & iDeviceSN & "' " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function


        Private Function getDeviceFailCode(ByVal iDeviceId As String) As DataTable
            Dim dt As New DataTable()
            Dim strSql As String
            strSql = String.Empty
            strSql &= "SELECT distinct(Dcode_Sdesc),Dcode_Ldesc  " & Environment.NewLine
            strSql &= "FROM tdevice A" & Environment.NewLine
            strSql &= "INNER JOIN tpretest_data C ON A.device_Id= C.device_Id " & Environment.NewLine
            strSql &= "INNER JOIN lcodesdetail B ON B.Dcode_id=C.Pttf" & Environment.NewLine
            strSql &= "WHERE  A.device_sn='" & iDeviceId & "' " & Environment.NewLine
            dt = _objDataProc.GetDataTable(strSql)
            Return dt
        End Function
        Private Function getCustomerName(ByVal iCust_ID As Integer) As String
            If iCust_ID = PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then
                Return "COOLPAD"
            ElseIf iCust_ID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID Then
                Return "WINGTECH T-MOBILE "
            End If
        End Function

        Public Function CreateWexATT(ByVal iCust_ID As Integer, ByVal strRptName As String, ByVal dateRec As String, ByVal dateEnd As String, ByVal strLocationId As String, ByVal iStatus As Integer) As Integer
            Dim strSql As String
            Dim Locid As String
            Dim dtSummary As DataTable
            Dim ds As New DataSet()
            Dim objExcelRpt As ExcelReports
            Dim strFile As String
            Dim dtTime As DateTime = Now
            Dim _dtShipment As New DataTable()
            Dim strPath As String = "P:\OUTBOUND\WEX ORDERS\COOLPAD-WINGTECH\"
            Dim strDate As String = dtTime.ToString("yyyyMMddHHmmss")
            Dim strSQLTemp As String
            Dim dtRow As DataRow
            Locid = getLocationId(strLocationId, iCust_ID)
            Dim i As Integer
            Dim strSql3 As String = ""
            Try
                strSql3 &= "SELECT 'EMBLEM'as OEM,ClaimNo AS 'Order #',item_SKU as SKU" & Environment.NewLine
                If iStatus = 1 Then
                    strSql3 &= " ,In_pallet_ID AS 'Pallett Name' " & Environment.NewLine
                End If
                strSql3 &= ", IF(Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y'))) as 'Order Date (Receive Date)' " & Environment.NewLine
                strSql3 &= ", (TO_DAYS(CURDATE()) - TO_DAYS(Device_DateRec)) AS 'Order Age(TAT)' ,0 AS 'Order Qty',COUNT(device_sn) AS 'Qty Rcvd',0 AS 'Qty Due', " & Environment.NewLine
                If iStatus = 0 Then
                    strSql3 &= " E.pkslip_trackNo AS 'Tracking #',IF(pkslip_createDt  IS NULL,'', IF(DATE_FORMAT(pkslip_createDt,'%m/%d/%Y') ='0000-00-00','',DATE_FORMAT(pkslip_createDt ,'%m/%d/%Y'))) as 'Date Shipped(ASN files uploaded)','' as 'Comments: Overdue TAT reason'" & Environment.NewLine
                Else
                    strSql3 &= " '' AS 'Tracking #','' as 'Date Shipped(ASN files uploaded)','' as 'Comments: Overdue TAT reason'" & Environment.NewLine
                End If
                strSql3 &= "FROM extendedwarranty A" & Environment.NewLine
                strSQLTemp = strSql3
                If iStatus = 0 Then
                    strSql3 &= "Inner join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                    strSql3 &= "inner join tpackingslip E ON E.Pkslip_ID=C.Pkslip_ID " & Environment.NewLine
                    strSql3 &= "inner join tdevice D ON D.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id))  " & Environment.NewLine
                Else
                    'strSql3 &= "inner join tdevice D ON D.device_id=A.device_id " & Environment.NewLine
                    'strSql3 &= "LEFT join production.tpallett  C ON D.Pallett_ID = C.Pallett_ID " & Environment.NewLine
                    strSql3 &= "inner join tdevice D ON D.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id)) " & Environment.NewLine
                    strSql3 &= "LEFT JOIN tpallett P ON D.Pallett_ID=P.Pallett_ID" & Environment.NewLine
                End If

                strSql3 &= "inner join tmodel F ON D.Model_id=F.Model_id " & Environment.NewLine
                If iStatus = 0 Then
                    strSql3 &= "WHERE A.sourceFile NOT LIKE '%seed%'  and  pkslip_createDt  BETWEEN '" & dateRec & "' AND '" & dateEnd & "' and ClaimNo NOT LIKE '%Seed%' AND Pallet_ShipType!=13" & Environment.NewLine
                Else
                    strSql3 &= "WHERE A.sourceFile NOT LIKE '%seed%'  AND Device_DateRec BETWEEN '" & dateRec & "' AND '" & dateEnd & "' AND (if ( D.Pallett_ID IS NOT  NULL ,  Pallet_ShipType=13  ,  ship_ID is null  AND device_dateship IS NULL ))  " & Environment.NewLine

                End If

                If iStatus = 1 Then
                    strSql3 &= " AND A.loc_id IN (" & Locid & " )   GROUP BY claimNo" & Environment.NewLine
                Else
                    strSql3 &= " AND A.loc_id IN (" & Locid & " )  GROUP BY claimNo, E.pkslip_trackNo" & Environment.NewLine
                End If
                dtSummary = Me._objDataProc.GetDataTable(strSql3)
                Dim iQtyOrdered As Integer
                Dim iQtyReceived As Integer
                Dim iQtyShipped As Integer
                Dim Receive_date As Date
                For Each dtRow In dtSummary.Rows
                    iQtyOrdered = _objWikoSharedFunction.wexOrdered(Convert.ToString(dtRow("Order #")))
                    iQtyShipped = _objWikoSharedFunction.wexShipped(Convert.ToString(dtRow("Order #")))
                    dtRow("Order Qty") = iQtyOrdered
                    Receive_date = _objWikoSharedFunction.getWexDate(Convert.ToString(dtRow("Order #")))
                    dtRow("Order Date (Receive Date)") = Receive_date.ToString("MM/dd/yyyy")
                    'dtRow("Order Age(TAT)") = _objWikoSharedFunction.getDateDiff(Receive_date, dtRow("Date Shipped(ASN files uploaded)"))
                    If iStatus = 1 Then
                        iQtyReceived = _objWikoSharedFunction.wexReceived(Convert.ToString(dtRow("Order #")))
                        dtRow("Qty Due") = dtRow("Qty Rcvd")
                        dtRow("Qty Rcvd") = iQtyReceived
                        dtRow("Order Age(TAT)") = _objWikoSharedFunction.getDateDiff(Receive_date, Date.Now.Date)
                    Else
                        dtRow("Order Age(TAT)") = _objWikoSharedFunction.getDateDiff(Receive_date, dtRow("Date Shipped(ASN files uploaded)"))
                        dtRow("Qty Due") = iQtyOrdered - iQtyShipped
                    End If
                Next
                If iStatus = 0 Then
                    dtSummary.Columns("Qty Rcvd").ColumnName = "Qty Shipped"
                End If

                If dtSummary.Rows.Count = 0 Then

                End If
                If iStatus = 1 Then
                    strFile = strLocationId.ToUpper & "WEX Open Orders" & strDate & ".xlsx"
                Else
                    strFile = strLocationId.ToUpper & "WEX Closed Orders" & strDate & ".xlsx"
                End If

                Dim strFilename As String = strPath & strFile
                'If dtSummary.Rows.Count > 0 Then
                _objWikoSharedFunction.CreateExcelFile_ATT(dtSummary, strFilename)
                'End If
                'dtSummary.Clear()
                Return dtSummary.Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function Get_Weekly_Report(ByVal iCust_id As Integer, ByVal strFromDt As String, _
                                                ByVal strToDt As String, _
                                                ByRef strRptPath As String, ByVal strLocation As String, ByVal iOption As Integer, Optional ByVal strImei As String = "") As Integer
            Dim strSQL, strSql1, strSql2, strSql3 As String
            Dim dtrow As DataRow
            Dim dtRepair As New DataTable()
            Dim dtSummary As New DataTable()
            Dim dtReceived As New DataTable()
            Dim dtTMO As New DataTable()
            Dim iweekofYear As Integer = Get_WeekofThe_Year(strToDt)
            Dim strPath As String = "P:\OUTBOUND\WEX ORDERS\Weekly_Reports\"
            Dim Locid As Integer = getLocationId(strLocation, iCust_id)
            Dim strFile As String = strPath & "TMO-S98115-weekly report WK" & iweekofYear & "_" & Date.Now.ToString("MMddyyyyhhmmss") & ".xlsx"
            'Query for Repair sheet
            strSQL = "SELECT IF(E.Device_DateBill IS NULL,'', IF(DATE_FORMAT(E.Device_DateBill,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(E.Device_DateBill ,'%m/%d/%Y')))  AS 'Repair time'" & Environment.NewLine
            strSQL &= ",A.Item_SKU AS  Model ,E.Device_sn as 'IMEI' ,A.Warranty_Desc AS 'TMO Account',A.Failure_Reason AS 'TMO Fail/Pass Reason',H.Dcode_Ldesc  AS 'Premier test Result','' AS 'Repair analysis',''AS 'Defective triage','' AS 'New IMEI'" & Environment.NewLine
            strSQL &= " FROM production.extendedwarranty A" & Environment.NewLine
            strSQL &= " INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
            strSQL &= "INNER JOIN production.tdevice E ON A.device_id= E.device_id " & Environment.NewLine
            strSQL &= " INNER JOIN production.tpretest_data F ON E.Device_ID=F.device_id" & Environment.NewLine
            strSQL &= " INNER JOIN lcodesdetail H on F.PTtf = H.Dcode_id  " & Environment.NewLine
            strSQL &= " INNER JOIN PRODUCTION.tdevicebill G ON G.Device_ID=E.Device_ID " & Environment.NewLine
            strSQL &= " WHERE A.sourcefile not like '%Seed%' AND  A.Cust_ID=" & iCust_id & "   AND A.loc_id=" & Locid & "  AND E.Device_DateBill BETWEEN '" & strFromDt & "' AND '" & strToDt & "' Group BY F.device_id order by E.Device_DateBill" & Environment.NewLine
            'Query for Summary sheet
            strSql2 &= "SELECT warranty_desc AS 'Program', " & iweekofYear & " as 'Week',item_sku AS  'Model',COUNT(*) AS   'On hand WIP',0 AS  'Repaired Plan'," & Environment.NewLine
            strSql2 &= "0 AS  'Swapped',0 AS  'Repaired',0 as  'BER',0 AS  'RUR',0 AS  'NTF',0 AS  'Total Production',AVG (TO_DAYS('" & strToDt & "') - TO_DAYS(Device_DateRec))  AS  'Aged WIP'  , 0 AS  'TotalReceived' " & Environment.NewLine
            strSql2 &= "FROM Production.extendedwarranty A" & Environment.NewLine
            strSql2 &= "INNER JOIN production.tWorkOrder B ON A.WO_ID=B.WO_ID" & Environment.NewLine
            strSql2 &= " INNER JOIN production.tCustomer C ON A.Cust_ID=C.Cust_ID" & Environment.NewLine
            strSql2 &= "INNER JOIN production.tLocation D ON A.Loc_ID=D.Loc_ID" & Environment.NewLine
            strSql2 &= "INNER JOIN production.tdevice E ON E.device_id=A.device_id " & Environment.NewLine
            strSql2 &= "LEFT JOIN tpallett P ON P.Pallett_ID=E.Pallett_ID " & Environment.NewLine
            strSql2 &= "WHERE A.cust_ID=" & iCust_id & "  AND  A.LOC_ID  =" & Locid & " AND   " & Environment.NewLine
            strSql2 &= " Device_DateRec IS NOT NULL AND  pallett_shipdate  IS  NULL AND   SOURCEFILE NOT LIKE '%Seed%' AND" & Environment.NewLine
            strSql2 &= "(if ( P.Pallett_ID IS NOT  NULL ,  Pallet_ShipType!=13  ,device_dateship IS NULL AND P.Pallett_ID IS NULL ))  GROUP BY A.Warranty_Desc" & Environment.NewLine
            'Query for TMO sheet
            strSql3 &= "SELECT CONVERT( IF( B.Device_DateRec  IS NULL,'', IF(DATE_FORMAT(Device_DateRec,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(Device_DateRec ,'%m/%d/%Y'))) , DATE)  AS 'DateReceived',ClaimNo AS 'PO#'" & Environment.NewLine
            strSql3 &= ",A.Model AS Description,SerialNO as 'Original IMEI',A.Warranty_Desc AS 'Account',C.pretest_wkDt AS 'Pretest Date',D.Dcode_Sdesc AS 'Code Failure',D.Dcode_Ldesc AS 'Fail/Pass Reason'," & Environment.NewLine
            strSql3 &= "IF (E.pkslip_id IS NULL,'',if(A.Swapped_Device_ID >0,'Swapp',IF (pallet_ShipType=2,'RUR',if(pallet_ShipType=1,'BER',IF(pallet_ShipType=0 AND B.Device_LaborLevel>0,'Repaired',if(pallet_ShipType =0 AND B.Device_LaborLevel IN (0,15) AND A.Swapped_Device_ID =0,'NTF','')))))) AS 'Swapped'," & Environment.NewLine
            strSql3 &= "IF (device_dateship IS not NULL AND SWAPPED_DEVICE_ID>0, Device_sn,'') AS 'New IMEI', CONVERT( IF( F.pkslip_createDt IS NULL,'', IF(DATE_FORMAT(F.pkslip_createDt,'%m/%d/%Y') ='00/00/0000','',DATE_FORMAT(F.pkslip_createDt ,'%m/%d/%Y'))) , DATE)   AS 'DateShipped',F.pkslip_TrackNo  AS 'Tracking #',CAST(TO_DAYS(F.pkslip_createDt) - TO_DAYS(Device_DateRec) AS UNSIGNED)   AS  'AgedWIP',pallet_ShipType as PallettShipType,IF(B.Device_Laborlevel=15,0,B.Device_Laborlevel) AS RepairLevel" & Environment.NewLine
            strSql3 &= "FROM production.extendedwarranty A" & Environment.NewLine
            strSql3 &= "INNER JOIN production.tdevice B ON B.device_id=(if (swapped_device_id>0 , A.swapped_device_id,A.device_id)) " & Environment.NewLine
            strSql3 &= "LEFT JOIN production.tpretest_data C ON  C.device_id =A.Device_ID" & Environment.NewLine
            strSql3 &= "LEFT JOIN lcodesdetail D on C.PTtf = D.Dcode_id  " & Environment.NewLine
            strSql3 &= "LEFT JOIN production.tpallett E ON E.pallett_id= B.pallett_id " & Environment.NewLine
            strSql3 &= "LEFT JOIN production.tpackingslip F ON F.pkslip_id=E.pkslip_id " & Environment.NewLine
            strSql3 &= "WHERE  A.cust_ID=" & iCust_id & " AND  A.LOC_ID IN (" & Locid & ") AND SOURCEFILE NOT LIKE '%seed%' AND (if ( E.Pallett_ID IS NOT  NULL ,  Pallet_ShipType!=13  ,device_dateship IS NULL AND E.Pallett_ID IS NULL )) AND    B.Device_DateRec BETWEEN '2021-01-01 00:00:00' AND '" & strToDt & "' Group BY B.device_id" & Environment.NewLine

            strSql1 &= "SELECT warranty_desc as Account FROM extendedwarranty A" & Environment.NewLine
            strSql1 &= "INNER JOIN tdevice B ON A.Device_ID=B.Device_ID" & Environment.NewLine
            strSql1 &= "WHERE  A.cust_ID=" & iCust_id & " AND  A.LOC_ID IN (" & Locid & ") AND SOURCEFILE NOT LIKE '%seed%' AND  B.Device_DateRec BETWEEN '" & strFromDt & "' AND '" & strToDt & "'" & Environment.NewLine
            strSql1 &= "AND warranty_desc is not null " & Environment.NewLine

            dtSummary = _objDataProc.GetDataTable(strSql2)
            dtRepair = _objDataProc.GetDataTable(strSQL)
            dtTMO = _objDataProc.GetDataTable(strSql3)
            dtReceived = _objDataProc.GetDataTable(strSql1)
            Dim dtClone As New DataTable()
            dtClone = dtTMO.Clone()
            dtClone.Columns(10).DataType = GetType(DateTime)

            For Each dtrow In dtTMO.Rows
                If Not dtrow(10) = "" Then
                    dtClone.ImportRow(dtrow)
                End If
            Next
            For Each dtrow In dtSummary.Rows
                dtrow("Total Production") = dtClone.Select("DateShipped IS NOT NULL AND Account='" & dtrow("Program") & "' and   dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and  dateshipped <= #" & CDate(strToDt).ToString("MM/dd/yyyy") & "#").Length
                dtrow("Swapped") = dtClone.Select("DateShipped IS NOT NULL AND  Account='" & dtrow("Program") & "' and dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and dateshipped <=  #" & CDate(strToDt).ToString("MM/dd/yyyy") & "# and Swapped='Swapp'").Length
                dtrow("RUR") = dtClone.Select("DateShipped IS NOT NULL AND  Account='" & dtrow("Program") & "' and dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and dateshipped <=  #" & CDate(strToDt).ToString("MM/dd/yyyy") & "# and  PallettShipType =2").Length
                dtrow("BER") = dtClone.Select("DateShipped IS NOT NULL AND  Account='" & dtrow("Program") & "' and dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and dateshipped <=  #" & CDate(strToDt).ToString("MM/dd/yyyy") & "# and  PallettShipType =1").Length
                dtrow("Repaired") = dtClone.Select("DateShipped IS NOT NULL AND  Account='" & dtrow("Program") & "' and dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and dateshipped <=  #" & CDate(strToDt).ToString("MM/dd/yyyy") & "# and  PallettShipType =0 AND RepairLevel>0 ").Length
                dtrow("NTF") = dtClone.Select("DateShipped IS NOT NULL AND  Account='" & dtrow("Program") & "' and dateshipped >= #" & CDate(strFromDt).ToString("MM/dd/yyyy") & "# and dateshipped <=  #" & CDate(strToDt).ToString("MM/dd/yyyy") & "# and  PallettShipType =0 AND RepairLevel=0 AND Swapped <>'Swapp'").Length
                dtrow("TotalReceived") = dtReceived.Select("Account='" & dtrow("Program") & "'").Length
            Next
            dtTMO.Columns.Remove("RepairLevel")
            dtTMO.Columns.Remove("PallettShipType")
            CreateExcelFile_Repair(dtRepair, dtTMO, dtSummary, strFile, iweekofYear)
            Return 1
        End Function
        Private Function Get_WeekofThe_Year(ByVal dtweek As Date) As Integer
            Dim a As DateTimeFormatInfo
            a = New DateTimeFormatInfo()
            Dim dt As New DateTime()
            dt = dtweek
            Dim cal As Calendar = a.Calendar
            Return (cal.GetWeekOfYear(dt, a.CalendarWeekRule, a.FirstDayOfWeek))
        End Function
        Private Sub SetColumn_Header_Summary(ByVal dt As DataTable, ByRef excelSheet As Excel.Worksheet, ByVal iweekofYear As Integer)
            Dim j As Integer = 1
            Dim l As Integer = 0
            Dim i As Integer = 1
            Dim strColumns() As String = {"EWP", "DOA", "IW", "OOW", "SCAR"}
            Dim dtRow As DataRow
            For j = 0 To dt.Rows.Count - 1
                With excelSheet

                    .Cells(i, 1).Value = "Program"
                    .Cells(i, 2).Value = "Week"
                    .Cells(i, 3).Value = "Model"
                    .Cells(i, 4).Value = "On hand WIP"
                    .Cells(i, 5).Value = "Repair Plan"
                    .Cells(i, 6).Value = "Swapped"
                    .Cells(i, 7).Value = "Repaired"
                    .Cells(i, 8).Value = "BER"
                    .Cells(i, 9).Value = "RUR"
                    .Cells(i, 10).Value = "NTF"
                    .Cells(i, 11).Value = "Total Production"
                    .Cells(i, 12).Value = "Aged WIP"
                End With
                Dim strange As String = "A" & i & ":L" & i
                excelSheet.Range(strange).Select()
                With excelSheet.Range(strange)
                    .WrapText = True
                    .HorizontalAlignment = -4108
                    .Font.Bold = True
                    .Font.Size = 11
                    .Interior.ColorIndex = 15
                    .Font.Name = "Times New Roman"
                    .HorizontalAlignment = Excel.Constants.xlCenter
                    setBorders(excelSheet.Range(strange))
                End With
                For l = 0 To dt.Columns.Count - 2
                    excelSheet.Cells(i + 1, l + 1).NumberFormat = "@"
                    excelSheet.Cells(i + 1, l + 1) = dt.Rows(j).Item(l)

                Next
                i = i + 3
            Next
            excelSheet.Range("A1:L" & dt.Rows.Count * 3).RowHeight = 30
            'Header for Details report
            With excelSheet
                .Columns("A:A").ColumnWidth = 18 'PO
                .Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("A:A").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("B:B").ColumnWidth = 8.43   'SKU
                .Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("B:B").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("C:C").ColumnWidth = 12.43 'MODEL
                .Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("C:C").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("D:D").ColumnWidth = 8.43  'Original IMEI
                .Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("D:D").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("E:E").ColumnWidth = 8.43  'New IMEI
                .Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("E:E").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("F:F").ColumnWidth = 8.43  'Service Center
                .Columns("F:F").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("F:F").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("G:G").ColumnWidth = 11.43    'DATE Received
                .Columns("G:G").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("G:G").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("H:H").ColumnWidth = 8.43   'Date Shiiped
                .Columns("H:H").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("H:H").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("I:I").ColumnWidth = 8.43    'Days
                .Columns("I:I").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("I:I").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("J:J").ColumnWidth = 8.43  'Code Failure1
                .Columns("J:J").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("J:J").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("K:K").ColumnWidth = 11.43  'Failure Reason1
                .Columns("K:K").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("K:K").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("L:L").ColumnWidth = 8.43  'Code Failure2
                .Columns("L:L").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("L:L").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("M:M").ColumnWidth = 8.43  'Code Failure2
                .Columns("M:M").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("M:M").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("N:N").ColumnWidth = 8.43  'Failure Reason1
                .Columns("N:N").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("N:N").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("O:O").ColumnWidth = 8.43  'Code Failure2
                .Columns("O:O").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("O:O").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("P:P").ColumnWidth = 8.43  'Code Failure2
                .Columns("P:P").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("P:P").VerticalAlignment = Excel.Constants.xlCenter
            End With
            ' details for summary

            'weekly range
            Dim strRange = "A" & i + 1 & ":P" & i + 1
            With excelSheet.Range(strRange)
                .MergeCells = True
                .Value = "Week " & iweekofYear & "- Summary "
                .Font.Size = 14
                .Font.Bold = True
                .Font.Name = "Times New Roman"
                .RowHeight = 37.5

            End With

            Dim strRange_ProductReceived = "B" & i + 2 & ":F" & i + 2
            Dim strRange_ProductShipped = "G" & i + 2 & ":K" & i + 2
            Dim strRange_ProductonHand = "L" & i + 2 & ":P" & i + 2
            Dim strRange_Description = "A" & i + 2 & ":A" & i + 3
            setRange(excelSheet, strRange_ProductReceived, "Product received " & vbLf & "(Pcs)", False)
            setRange(excelSheet, strRange_ProductShipped, "Product Shipped " & vbLf & "(Pcs)", False)
            setRange(excelSheet, strRange_ProductonHand, "On hand WIP" & vbLf & " (Pcs)", False)
            setRange(excelSheet, strRange_Description, "Description", True)
            'header for EWP,DOA,IW HEIGHT
            With excelSheet.Range("A" & i + 3 & ":P" & i + 3)
                .RowHeight = 24.75
                .Interior.Color = RGB(180, 198, 231)
                setBorders(excelSheet.Range("A" & i + 3 & ":P" & i + 3))
            End With
            'data for summary 
            Dim k As Integer = 0
            For l = 2 To 16
                If l = 7 OrElse l = 12 Then
                    k = 0
                End If
                excelSheet.Cells(i + 3, l) = strColumns(k)
                k = k + 1
            Next
            Dim iwDtrow() As DataRow = dt.Select("Program='IN WARRANTY'")
            Dim outDtrow() As DataRow = dt.Select("Program='OUT OF WARRANTY'")
            Dim DOADtrow() As DataRow = dt.Select("Program='DOA'")
            Dim EWPDtrow() As DataRow = dt.Select("Program='EWP'")
            Dim SCARDtrow() As DataRow = dt.Select("Program='SCAR'")
            For l = 1 To 16
                Select Case l
                    Case 1
                        excelSheet.Cells(i + 4, l) = "TMO REVVL " & vbLf & "V+5G 64G"
                    Case 2
                        excelSheet.Cells(i + 4, l) = EWPDtrow(0).Item("TotalReceived")
                    Case 3
                        excelSheet.Cells(i + 4, l) = DOADtrow(0).Item("TotalReceived")
                    Case 4
                        excelSheet.Cells(i + 4, l) = iwDtrow(0).Item("TotalReceived")
                    Case 5
                        excelSheet.Cells(i + 4, l) = outDtrow(0).Item("TotalReceived")
                    Case 6
                        excelSheet.Cells(i + 4, l) = SCARDtrow(0).Item("TotalReceived")
                    Case 7
                        excelSheet.Cells(i + 4, l) = EWPDtrow(0).Item("Total Production")
                    Case 8
                        excelSheet.Cells(i + 4, l) = DOADtrow(0).Item("Total Production")
                    Case 9
                        excelSheet.Cells(i + 4, l) = iwDtrow(0).Item("Total Production")
                    Case 10
                        excelSheet.Cells(i + 4, l) = outDtrow(0).Item("Total Production")
                    Case 11
                        excelSheet.Cells(i + 4, l) = SCARDtrow(0).Item("Total Production")
                    Case 12
                        excelSheet.Cells(i + 4, l) = EWPDtrow(0).Item("On hand WIP")
                    Case 13
                        excelSheet.Cells(i + 4, l) = DOADtrow(0).Item("On hand WIP")
                    Case 14
                        excelSheet.Cells(i + 4, l) = iwDtrow(0).Item("On hand WIP")
                    Case 15
                        excelSheet.Cells(i + 4, l) = outDtrow(0).Item("On hand WIP")
                    Case 16
                        excelSheet.Cells(i + 4, l) = SCARDtrow(0).Item("On hand WIP")

                End Select
                'excelSheet.Cells(i + 4, l) = strColumns(k)
            Next


        End Sub
        Private Sub setRange(ByRef excelSheet As Excel.Worksheet, ByVal strRange As String, ByVal strTitle As String, ByVal isRow As Boolean)
            With excelSheet.Range(strRange)
                .MergeCells = True
                .WrapText = True
                .Value = strTitle
                .Font.Size = 12
                .Font.Bold = True
                .Font.Name = "Times New Roman"
                If Not isRow Then
                    .RowHeight = 31.5
                End If
                .Interior.Color = RGB(180, 198, 231)

            End With
            setBorders(excelSheet.Range(strRange))
        End Sub
        Private Sub setBorders(ByRef strrange As Excel.Range)
            With strrange
                .Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells.Borders.Color = RGB(0, 0, 0)
                .Cells.Borders.Weight = 2D
            End With
        End Sub
        Private Sub SetColumn_Header_TMO(ByVal dt As DataTable, ByRef excelSheet As Excel.Worksheet)
            Dim j As Integer = 1
            Dim l As Integer = 0
            Dim i As Integer = 2

            With excelSheet
                .Cells(i, 1).Value = "No"
                .Cells(i, 2).Value = "Date Received"
                .Cells(i, 3).Value = "PO#"
                .Cells(i, 4).Value = "Description"
                .Cells(i, 5).Value = "Original IMEI"
                .Cells(i, 6).Value = "Account"
                .Cells(i, 7).Value = "Pretest Date"
                .Cells(i, 8).Value = "Code Failure"
                .Cells(i, 9).Value = "Fail/Pass Reason"
                .Cells(i, 10).Value = "Swaped / Repaired / BER / RUR / NTF"
                .Cells(i, 11).Value = "New IMEI"
                .Cells(i, 12).Value = "Date Shipped"
                .Cells(i, 13).Value = "Tracking #"
                .Cells(i, 14).Value = "Days"
            End With
            With excelSheet
                .Columns("A:A").ColumnWidth = 5.29 'PO
                .Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("A:A").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("B:B").ColumnWidth = 9.43
                .Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("B:B").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("C:C").ColumnWidth = 10.29
                .Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("C:C").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("D:D").ColumnWidth = 23.43
                .Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("D:D").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("E:E").ColumnWidth = 18
                .Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("E:E").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("F:F").ColumnWidth = 21.57  'Service Center
                .Columns("F:F").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("F:F").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("G:G").ColumnWidth = 11.86    'DATE Received
                .Columns("G:G").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("G:G").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("H:H").ColumnWidth = 12.57   'Date Shiiped
                .Columns("H:H").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("H:H").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("I:I").ColumnWidth = 30.86    'Days
                .Columns("I:I").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("I:I").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("J:J").ColumnWidth = 13.29 'Code Failure1
                .Columns("J:J").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("J:J").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("K:K").ColumnWidth = 17.29  'Failure Reason1
                .Columns("K:K").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("K:K").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("L:L").ColumnWidth = 16.71 'Code Failure2
                .Columns("L:L").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("L:L").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("M:M").ColumnWidth = 39.57 'Code Failure2
                .Columns("M:M").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("M:M").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("N:N").ColumnWidth = 6.86  'Code Failure2
                .Columns("N:N").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("N:N").VerticalAlignment = Excel.Constants.xlCenter
            End With
        End Sub


        Private Sub SetColumn_Header_Repair(ByVal dt As DataTable, ByRef excelSheet As Excel.Worksheet)
            Dim i As Integer = 2
            With excelSheet
                .Cells(i, 1).Value = "Repair time"
                .Cells(i, 2).Value = "Model"
                .Cells(i, 3).Value = "IMEI"
                .Cells(i, 4).Value = "TMO Account"
                .Cells(i, 5).Value = "TMO Fail/Pass Reason"
                .Cells(i, 6).Value = "Premier test Result"
                .Cells(i, 7).Value = "Repair analysis"
                .Cells(i, 8).Value = "Defective triage"
                .Cells(i, 9).Value = "New IMEI"

            End With
            With excelSheet
                .Columns("A:A").ColumnWidth = 11.29 'PO
                .Columns("A:A").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("A:A").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("B:B").ColumnWidth = 9.86
                .Columns("B:B").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("B:B").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("C:C").ColumnWidth = 15.43
                .Columns("C:C").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("C:C").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("D:D").ColumnWidth = 21.43
                .Columns("D:D").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("D:D").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("E:E").ColumnWidth = 45.14
                .Columns("E:E").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("E:E").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("F:F").ColumnWidth = 21.14  'Service Center
                .Columns("F:F").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("F:F").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("G:G").ColumnWidth = 20.43   'DATE Received
                .Columns("G:G").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("G:G").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("H:H").ColumnWidth = 21.43  'Date Shiiped
                .Columns("H:H").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("H:H").VerticalAlignment = Excel.Constants.xlCenter

                .Columns("I:I").ColumnWidth = 26.14   'Days
                .Columns("I:I").HorizontalAlignment = Excel.Constants.xlCenter
                .Columns("I:I").VerticalAlignment = Excel.Constants.xlCenter

            End With
        End Sub


        Private Sub CreateExcelFile_Repair(ByVal dtRepair As DataTable, ByVal dtTMO As DataTable, ByVal dtSummary As DataTable, ByVal strRptPath As String, ByVal iweekofYear As Integer)
            Dim i, j As Integer
            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet1 As Excel.Worksheet
            Dim xlWorkSheet2 As Excel.Worksheet
            Dim xlWorkSheet3 As Excel.Worksheet
            Dim R1 As DataRow
            'Dim i As Integer = 3
            Dim arrDataRepair(0, 0) As String
            Dim arrDataTMO(0, 0) As String
            'i = 0
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Excel.Application()
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet1 = xlWorkBook.Sheets("sheet1")
            xlWorkSheet1.Name = "Summary"
            xlWorkSheet2 = xlWorkBook.Sheets("sheet2")
            xlWorkSheet2.Name = "TMO-S98115"
            xlWorkSheet3 = xlWorkBook.Sheets("sheet3")
            xlWorkSheet3.Name = "Repair analysis report"

            SetColumn_Header_Summary(dtSummary, xlWorkSheet1, iweekofYear)
            SetColumn_Header_TMO(dtTMO, xlWorkSheet2)
            SetColumn_Header_Repair(dtRepair, xlWorkSheet3)
            'Format cells Data Type
            '*****************************************
            'Repair Report Tab
            xlWorkSheet3.Range("A1", "I" & (dtRepair.Rows.Count + 5)).NumberFormat = "@"
            For i = 0 To dtRepair.Rows.Count - 1
                i = 0
                ReDim arrDataRepair(dtRepair.Rows.Count, 8)
                For Each R1 In dtRepair.Rows
                    If Not IsDBNull(R1("Repair time")) Then
                        arrDataRepair(i, 0) = Trim(R1("Repair time"))
                    End If
                    If Not IsDBNull(R1("Model")) Then
                        arrDataRepair(i, 1) = Trim(R1("Model"))
                    End If
                    If Not IsDBNull(R1("IMEI")) Then
                        arrDataRepair(i, 2) = Trim(R1("IMEI"))
                    End If
                    If Not IsDBNull(R1("TMO Account")) Then
                        arrDataRepair(i, 3) = Trim(R1("TMO Account"))
                    End If
                    If Not IsDBNull(R1("TMO Fail/Pass Reason")) Then
                        arrDataRepair(i, 4) = Trim(R1("TMO Fail/Pass Reason"))
                    End If
                    If Not IsDBNull(R1("Premier test Result")) Then
                        arrDataRepair(i, 5) = Trim(R1("Premier test Result"))
                    End If
                    If Not IsDBNull(R1("Repair analysis")) Then
                        arrDataRepair(i, 6) = Trim(R1("Repair analysis"))
                    End If
                    If Not IsDBNull(R1("Defective triage")) Then
                        arrDataRepair(i, 7) = Trim(R1("Defective triage"))
                    End If
                    If Not IsDBNull(R1("New IMEI")) Then
                        arrDataRepair(i, 8) = Trim(R1("New IMEI"))
                    End If
                    i += 1
                Next R1
                xlWorkSheet3.Range("A3", "I" & (dtRepair.Rows.Count + 2)).Value = arrDataRepair
            Next
            xlWorkSheet3.Range("A1", "I" & (dtRepair.Rows.Count + 5)).Value = xlWorkSheet3.Range("A1", "I" & (dtRepair.Rows.Count + 5)).Value

            'TMO Report Tab
            xlWorkSheet2.Range("A1", "N" & (dtTMO.Rows.Count + 5)).NumberFormat = "@"
            For i = 0 To dtTMO.Rows.Count - 1
                i = 0
                ReDim arrDataTMO(dtTMO.Rows.Count, 14)
                For Each R1 In dtTMO.Rows
                    arrDataTMO(i, 0) = i + 1
                    If Not IsDBNull(R1("DateReceived")) Then
                        arrDataTMO(i, 1) = Trim(R1("DateReceived"))
                    End If
                    If Not IsDBNull(R1("PO#")) Then
                        arrDataTMO(i, 2) = Trim(R1("PO#"))
                    End If
                    If Not IsDBNull(R1("Description")) Then
                        arrDataTMO(i, 3) = Trim(R1("Description"))
                    End If
                    If Not IsDBNull(R1("Original IMEI")) Then
                        arrDataTMO(i, 4) = Trim(R1("Original IMEI"))
                    End If
                    If Not IsDBNull(R1("Account")) Then
                        arrDataTMO(i, 5) = Trim(R1("Account"))
                    End If
                    If Not IsDBNull(R1("Pretest Date")) Then
                        arrDataTMO(i, 6) = Trim(R1("Pretest Date"))
                    End If
                    If Not IsDBNull(R1("Code Failure")) Then
                        arrDataTMO(i, 7) = Trim(R1("Code Failure"))
                    End If
                    If Not IsDBNull(R1("Fail/Pass Reason")) Then
                        arrDataTMO(i, 8) = Trim(R1("Fail/Pass Reason"))
                    End If
                    If Not IsDBNull(R1("Swapped")) Then
                        arrDataTMO(i, 9) = Trim(R1("Swapped"))
                    End If
                    If Not IsDBNull(R1("New IMEI")) Then
                        arrDataTMO(i, 10) = Trim(R1("New IMEI"))
                    End If
                    If Not IsDBNull(R1("DateShipped")) Then
                        arrDataTMO(i, 11) = Trim(R1("DateShipped"))
                    End If
                    If Not IsDBNull(R1("Tracking #")) Then
                        arrDataTMO(i, 12) = Trim(R1("Tracking #"))
                    End If
                    If Not IsDBNull(R1("AgedWIP")) Then
                        If Trim(R1("AgedWIP")) = "0" Then
                            arrDataTMO(i, 13) = ""
                        Else
                            arrDataTMO(i, 13) = Trim(R1("AgedWIP"))
                        End If

                    End If
                    i += 1
                Next R1
            Next
            xlWorkSheet2.Range("A3", "N" & (dtTMO.Rows.Count + 2)).Value = arrDataTMO
            xlWorkSheet2.Range("A1", "N" & (dtTMO.Rows.Count + 5)).Value = xlWorkSheet2.Range("A1", "N" & (dtTMO.Rows.Count + 5)).Value
            xlWorkSheet2.Range("A3", "N" & (dtTMO.Rows.Count + 5)).Font.Size = 11
            xlWorkSheet2.Range("A3", "N" & (dtTMO.Rows.Count + 5)).Font.Name = "Times New Roman"
            'set title for Repair and TMO
            SetFont_Title(xlWorkSheet2, "After-sales Service Tracking Form", "A1:N1", "A2:N2", True)
            SetFont_Title(xlWorkSheet3, "Repair analysis report", "A1:I1", "A2:I2", False)
            xlWorkSheet2.SaveAs(strRptPath)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet3)
            MsgBox("You can find the file " & strRptPath)
        End Sub

        Private Sub SetFont_Title(ByRef excelSheet As Excel.Worksheet, ByVal title As String, ByVal range As String, ByVal columnFontRange As String, ByVal IsTMO As Boolean)
            With excelSheet.Range(range)
                .MergeCells = True
                .HorizontalAlignment = -4108
                .Value = title
                .Font.Bold = True
                .Font.Size = 14
                If IsTMO Then
                    .Interior.Color = RGB(255, 217, 102)
                Else
                    .Interior.Color = RGB(195, 195, 195)
                    .RowHeight = 30
                End If
                .Font.Name = "Times New Roman"
                .RowHeight = 30
                setBorders(excelSheet.Range(range))
            End With
            With excelSheet.Range(columnFontRange)
                .Font.Size = 11
                .Font.Name = "Times New Roman"
                .WrapText = True
                If IsTMO Then
                    .Interior.Color = RGB(180, 198, 231)
                Else
                    .Interior.Color = RGB(195, 195, 195)
                    .RowHeight = 30
                End If
                .HorizontalAlignment = -4108
                .Font.Bold = True
                setBorders(excelSheet.Range(columnFontRange))
            End With
        End Sub
        Private Sub setFont(ByRef objExcel As Excel.Application)
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
        End Sub
        Private Sub releaseObject(ByVal obj As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
            Finally
                GC.Collect()
            End Try
        End Sub

        Private Function GetAll_Sku() As DataTable
            Dim strSql As String
            strSql = "SELECT  distinct(warranty_desc)  FROM extendedwarranty WHERE cust_id=" & PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID & " AND warranty_desc IS NOT null" & Environment.NewLine
            Return _objDataProc.GetDataTable(strSql)
        End Function

        Private Function Get_SummaryData()

        End Function
    End Class
End Namespace