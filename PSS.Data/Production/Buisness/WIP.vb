Imports System.Data.OleDb

Namespace Buisness
    Public Class WIP
        Private objMisc As Production.Misc
        Private strDt As String = Format(DateAdd(DateInterval.Day, -7, Now), "yyyy-MM-dd")

        '**********************************************************
        Public Function GetWIPByGroup(ByVal iCust_ID As Integer, _
                                    Optional ByVal iCountOrDetail As Integer = 0, _
                                    Optional ByVal strFilePath As String = "", _
                                    Optional ByVal iModel_ID As Integer = 0, _
                                    Optional ByVal strModel As String = "") _
                                    As Integer

            Dim objMiscBiz As New PSS.Data.Buisness.Misc()

            Dim dt1, _
                dtWarehouse, _
                dtCell1Triage1, _
                dtCell1Triage2, _
                dtCell1Discrep, _
                dtCell1, _
                dtCell1DiscrepIntransit, _
                dtAQLHoldCell1, _
                dtCell2Triage1, _
                dtCell2Triage2, _
                dtCell2Discrep, _
                dtCell2, _
                dtAQLHoldCell2, _
                dtCell2DiscrepIntransit, _
                dtAWP, _
                dtWHAWP, _
                dtGameStopTriage1, _
                dtGameStop, _
                dtAQL, _
                dtIntransit, _
                dtSubCont _
                As DataTable

            Dim R1 As DataRow
            Dim i As Integer = 0

            'WIP Count Variables
            Dim iWarehouseWIP As Integer = 0

            'Cell 1 related
            Dim iCell1TriageWIP_Received As Integer = 0
            Dim iCell1TriageWIP_Unreceived As Integer = 0
            Dim iCell1WIP As Integer = 0
            Dim iCell1DiscrepWIP As Integer = 0
            Dim iCell1DiscrepIntransit As Integer = 0
            Dim iAQLHoldCell1 As Integer = 0
            'Dim iCell1AWP As Integer = 0

            'Cell 2 Related
            Dim iCell2TriageWIP_Received As Integer = 0
            Dim iCell2TriageWIP_Unreceived As Integer = 0
            Dim iCell2WIP As Integer = 0
            Dim iCell2DiscrepWIP As Integer = 0
            Dim iCell2DiscrepIntransit As Integer = 0
            Dim iAQLHoldCell2 As Integer = 0
            Dim iAWP As Integer = 0
            Dim iWHAWP As Integer = 0

            'GAMESTOP Related
            'Dim iGameStopTriageWIP_Received As Integer = 0
            Dim iGameStopTriageWIP_Unreceived As Integer = 0
            Dim iGameStopWIP As Integer = 0

            Dim iAQLWIP As Integer = 0
            Dim iSubCont As Integer = 0
            Dim iIntransitWIP As Integer = 0
            'Dim iOldWIP As Integer = 0

            Dim iTotalWIP As Integer = 0

            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Dim strGroup As String = ""
            Dim strDetailFileName As String = ""        '"PSSICellWIPDetail " & strGroup & " " & Format(Now(), "MMddyyyy hhmmss") & ".xls"
            Dim strDetailRptPath As String = ""         'strRptDir & strDetailFileName
            Dim strCustomer As String = ""

            Try
                '******************************
                If iCust_ID > 0 Then
                    dt1 = objMiscBiz.GetCustomerInfo(iCust_ID)
                    If dt1.Rows.Count > 0 Then
                        R1 = dt1.Rows(0)
                        strCustomer = Trim(R1("cust_name1"))
                    End If
                End If
                '*************************************************************
                ''Warehouse WIP
                '*************************************************************
                dtWarehouse = Me.GetWarehouseWIP(iCust_ID, iModel_ID)
                '*************************************************************
                'Cellular 1
                '*************************************************************
                'CELL 1: Get Triage WIP part 1
                dtCell1Triage1 = Me.GetTriageWIP1(iCust_ID, 5, iModel_ID)
                'CELL 1:  Get Triage WIP part 2
                dtCell1Triage2 = Me.GetWIP(iCust_ID, 5, iModel_ID)
                'CELL 1: Get Discrepancy part 2
                dtCell1Discrep = Me.GetDiscrepancyWIP(iCust_ID, 5, iModel_ID)
                'Cell 1 WIP (Production WIP)
                dtCell1 = Me.GetWIP(iCust_ID, 2, iModel_ID)
                'Cellular 1 Awaiting Parts
                'dtCell1AWP = Me.GetWIP(iCust_ID, 12, iModel_ID)
                'AQL HOLD (CEL - 1) WIP
                dtAQLHoldCell1 = Me.GetWIP(iCust_ID, 9, iModel_ID)

                '*************************************************************
                'Cellular 2
                '*************************************************************
                'CELL 2:  Get Triage WIP part 1
                dtCell2Triage1 = Me.GetTriageWIP1(iCust_ID, 11, iModel_ID)
                'CELL 2: Get Triage WIP part 2
                dtCell2Triage2 = Me.GetWIP(iCust_ID, 11, iModel_ID)
                'CELL 2: Get Discrepancy part 2
                dtCell2Discrep = Me.GetDiscrepancyWIP(iCust_ID, 11, iModel_ID)
                'Get Cell 2 WIP
                dtCell2 = Me.GetWIP(iCust_ID, 3, iModel_ID)
                ''Get Awaiting Parts
                'dtAWP = Me.GetWIP(iCust_ID, 13, iModel_ID)
                'Get AQL HOLD (CEL - 2) WIP
                dtAQLHoldCell2 = Me.GetWIP(iCust_ID, 10, iModel_ID)
                '*************************************************************
                'GameStop
                '*************************************************************
                'GameStop:  Get Triage WIP part 1
                dtGameStopTriage1 = Me.GetTriageWIP1(iCust_ID, 14, iModel_ID)
                ''''GameStop: Get Triage WIP part 2
                '''dtGameStopTriage2 = Me.GetWIP(iCust_ID, 14, iModel_ID)
                'Get GameStop WIP
                dtGameStop = Me.GetWIP(iCust_ID, 14, iModel_ID)
                '*************************************************************
                'AQL WIP
                '*************************************************************
                dtAQL = Me.GetWIP(iCust_ID, 6, iModel_ID)
                '*************************************************************
                'Subcontractor WIP
                '*************************************************************
                dtSubCont = Me.GetWIP(iCust_ID, 15, iModel_ID)
                '*************************************************************
                'Get Awaiting Parts
                '*************************************************************
                dtAWP = Me.GetWIP(iCust_ID, 13, iModel_ID)
                dtWHAWP = Me.GetWarehouseAwaitingParts(iCust_ID, iModel_ID)
                '*************************************************************
                'Intransit WIP
                '*************************************************************
                'Get In-transit WIP
                dtIntransit = Me.GetWIP(iCust_ID, 7, iModel_ID)
                'Step 14: Cell 1: Get Discrepant In-transit WIP
                dtCell1DiscrepIntransit = Me.GetDiscrepancyIntransitWIP(iCust_ID, 5, iModel_ID)
                'Step 15: Cell 2: Get Discrepant In-transit WIP
                dtCell2DiscrepIntransit = Me.GetDiscrepancyIntransitWIP(iCust_ID, 11, iModel_ID)
                '*************************************************************
                'Step 16: Old WIP
                '*************************************************************
                'dtOldWIP = Me.GetWIP(iCust_ID, 20, iModel_ID)
                '******************************

                If iCountOrDetail = 0 Then      'Counts only
                    '******************************************************************
                    'Write to Excel File
                    '******************************************************************
                    'Instantiate the excel related objects
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = True                 'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                    objSheet.Cells.Select()
                    objExcel.Selection.NumberFormat = "@"
                    '*****************************************
                    'WIP Counts
                    '*****************************************
                    'Warehouse WIP Count
                    iWarehouseWIP = dtWarehouse.Rows.Count

                    '***************************
                    'Cell 1 Triage WIP Count
                    iCell1TriageWIP_Unreceived = dtCell1Triage1.Rows.Count
                    iCell1TriageWIP_Received = dtCell1Triage2.Rows.Count

                    'Cell 1 Discrepancy WIP Count
                    For Each R1 In dtCell1Discrep.Rows
                        If R1("WHR_DupInFile") = 1 Then
                            If R1("NoOfDups") > 0 Then
                                iCell1DiscrepWIP += R1("NoOfDups")
                            Else
                                iCell1DiscrepWIP += 1    'this condition should never be met but provided for safety
                            End If
                        Else
                            iCell1DiscrepWIP += 1
                        End If
                    Next R1
                    '***************************
                    'Cell 2 Triage WIP Count
                    iCell2TriageWIP_Unreceived = dtCell2Triage1.Rows.Count
                    iCell2TriageWIP_Received = dtCell2Triage2.Rows.Count

                    'Cell 2 Discrepancy WIP Count
                    For Each R1 In dtCell2Discrep.Rows
                        If R1("WHR_DupInFile") = 1 Then
                            If R1("NoOfDups") > 0 Then
                                iCell2DiscrepWIP += R1("NoOfDups")
                            Else
                                iCell2DiscrepWIP += 1    'this condition should never be met but provided for safety
                            End If
                        Else
                            iCell2DiscrepWIP += 1
                        End If
                    Next R1
                    '***************************
                    'CELL1 WIP Count
                    iCell1WIP = dtCell1.Rows.Count

                    'CELL2 WIP Count
                    iCell2WIP = dtCell2.Rows.Count

                    'AQL WIP Count
                    iAQLWIP = dtAQL.Rows.Count

                    'Subcontractor Count 
                    iSubCont = dtSubCont.Rows.Count

                    'In-transit WIP Count
                    iIntransitWIP = dtIntransit.Rows.Count

                    'AQLHoldCell1 WIP Count
                    iAQLHoldCell1 = dtAQLHoldCell1.Rows.Count

                    'AQLHoldCell2 WIP Count
                    iAQLHoldCell2 = dtAQLHoldCell2.Rows.Count
                    '******************************
                    'Cell 1 Discrepant WIP Intransit
                    For Each R1 In dtCell1DiscrepIntransit.Rows
                        If R1("WHR_DupInFile") = 1 Then
                            If R1("NoOfDups") > 0 Then
                                iCell1DiscrepIntransit += R1("NoOfDups")
                            Else
                                iCell1DiscrepIntransit += 1    'this condition should never be met but provided for safety
                            End If
                        Else
                            iCell1DiscrepIntransit += 1
                        End If
                    Next R1
                    '******************************
                    'Cell 2 Discrepant WIP Intransit
                    For Each R1 In dtCell2DiscrepIntransit.Rows
                        If R1("WHR_DupInFile") = 1 Then
                            If R1("NoOfDups") > 0 Then
                                iCell2DiscrepIntransit += R1("NoOfDups")
                            Else
                                iCell2DiscrepIntransit += 1    'this condition should never be met but provided for safety
                            End If
                        Else
                            iCell2DiscrepIntransit += 1
                        End If
                    Next R1
                    '******************************
                    'Awaiting Parts Count
                    'iCell1AWP = dtCell1AWP.Rows.Count
                    iAWP = dtAWP.Rows.Count
                    iWHAWP = dtWHAWP.Rows.Count
                    '******************************
                    'Old WIP
                    'iOldWIP = dtOldWIP.Rows.Count
                    '******************************
                    iGameStopTriageWIP_Unreceived = dtGameStopTriage1.Rows.Count
                    'iGameStopTriageWIP_Received = dtGameStopTriage2.Rows.Count
                    iGameStopWIP = dtGameStop.Rows.Count
                    '******************************
                    'Total WIP
                    iTotalWIP = _
                    iWarehouseWIP + _
                    iCell1TriageWIP_Unreceived + iCell1TriageWIP_Received + iCell1DiscrepWIP + iAQLHoldCell1 + iCell1WIP + _
                    iCell2TriageWIP_Unreceived + iCell2TriageWIP_Received + iCell2DiscrepWIP + iAWP + iWHAWP + iAQLHoldCell2 + iCell2WIP + _
                    iGameStopTriageWIP_Unreceived + iGameStopWIP + _
                    iAQLWIP + iSubCont + _
                    iIntransitWIP + iCell1DiscrepIntransit + iCell2DiscrepIntransit '+ iOldWIP
                    '******************************
                    i = 4
                    '*****************************************
                    'Create the header
                    '*****************************************
                    objExcel.Application.Cells(i, 1).Value = "Location"
                    objExcel.Application.Cells(i, 2).Value = "WIP Count"
                    '*****************************************
                    'Set column widths
                    '*****************************************
                    objSheet.Columns("A:A").ColumnWidth = 35
                    objSheet.Columns("B:B").ColumnWidth = 15
                    '*****************************************
                    'Set alignments
                    '*****************************************
                    objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft
                    objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlRight
                    '*****************************************
                    'Format cells Data Type
                    '*****************************************
                    objSheet.Columns("A:A").Select()
                    objExcel.Selection.NumberFormat = "@"
                    objSheet.Columns("B:B").Select()
                    objExcel.Selection.NumberFormat = "@"
                    '*****************************************
                    'Set horizontal alignment for the header
                    '*****************************************
                    objSheet.Range("A4:B4").Select()
                    With objExcel.Selection
                        .WrapText = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.ColorIndex = 5
                        .Interior.ColorIndex = 37
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    i += 2
                    '*********************************************************************
                    'Warehouse
                    '*********************************************************************
                    objExcel.Application.Cells(i, 1).Value = "WAREHOUSE"
                    objExcel.Application.Cells(i, 2).Value = iWarehouseWIP

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*********************************************************************
                    i += 2
                    '*********************************************************************
                    'Cellular 1
                    '*********************************************************************
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 1 STAGE 1 (Not Production Received)"
                    objExcel.Application.Cells(i, 2).Value = iCell1TriageWIP_Unreceived
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 1 STAGE 1"
                    objExcel.Application.Cells(i, 2).Value = iCell1TriageWIP_Received
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 1 STAGE 1 (Discrepancies not Shipped)"
                    objExcel.Application.Cells(i, 2).Value = iCell1DiscrepWIP
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 1"
                    objExcel.Application.Cells(i, 2).Value = iCell1WIP
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 1 (AQL HOLD)"
                    objExcel.Application.Cells(i, 2).Value = iAQLHoldCell1
                    'i += 1
                    'objExcel.Application.Cells(i, 1).Value = "CELLULAR 1 AWAITING PARTS"
                    'objExcel.Application.Cells(i, 2).Value = iCell1AWP
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 1 TOTAL"
                    objExcel.Application.Cells(i, 2).Value = iCell1WIP + iAQLHoldCell1 + iCell1TriageWIP_Unreceived + iCell1TriageWIP_Received + iCell1DiscrepWIP

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*********************************************************************
                    i += 2
                    '*********************************************************************
                    'Cellular 2
                    '*********************************************************************
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 2 STAGE 1 (Not Production Received)"
                    objExcel.Application.Cells(i, 2).Value = iCell2TriageWIP_Unreceived
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 2 STAGE 1"
                    objExcel.Application.Cells(i, 2).Value = iCell2TriageWIP_Received
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 2 STAGE 1 (Discrepancies not Shipped)"
                    objExcel.Application.Cells(i, 2).Value = iCell2DiscrepWIP
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 2"
                    objExcel.Application.Cells(i, 2).Value = iCell2WIP
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 2 (AQL HOLD)"
                    objExcel.Application.Cells(i, 2).Value = iAQLHoldCell2
                    'i += 1
                    'objExcel.Application.Cells(i, 1).Value = "AWAITING PARTS"
                    'objExcel.Application.Cells(i, 2).Value = iAWP
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "CELLULAR 2 TOTAL"
                    objExcel.Application.Cells(i, 2).Value = iCell2WIP + iAQLHoldCell2 + iCell2TriageWIP_Unreceived + iCell2TriageWIP_Received + iCell2DiscrepWIP

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*********************************************************************
                    i += 2
                    '*********************************************************************
                    'GAMESTOP
                    '*********************************************************************
                    objExcel.Application.Cells(i, 1).Value = "GAMESTOP STAGE 1 (Not Production Received)"
                    objExcel.Application.Cells(i, 2).Value = iGameStopTriageWIP_Unreceived
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "GAMESTOP"
                    objExcel.Application.Cells(i, 2).Value = iGameStopWIP
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "GAMESTOP TOTAL"
                    objExcel.Application.Cells(i, 2).Value = iGameStopWIP + iGameStopTriageWIP_Unreceived

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*********************************************************************
                    i += 2
                    '*********************************************************************
                    'AQL
                    '*********************************************************************
                    objExcel.Application.Cells(i, 1).Value = "AQL"
                    objExcel.Application.Cells(i, 2).Value = iAQLWIP

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*********************************************************************
                    i += 2
                    '*********************************************************************
                    'Subcontractor
                    '*********************************************************************
                    objExcel.Application.Cells(i, 1).Value = "SUBCONTRACTOR"
                    objExcel.Application.Cells(i, 2).Value = iSubCont

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*********************************************************************
                    'Awaiting Parts
                    '*********************************************************************
                    i += 2
                    objExcel.Application.Cells(i, 1).Value = "AWAITING PARTS"
                    objExcel.Application.Cells(i, 2).Value = iAWP + iWHAWP

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*********************************************************************
                    i += 2
                    '*********************************************************************
                    'In-transit
                    '*********************************************************************
                    objExcel.Application.Cells(i, 1).Value = "IN-TRANSIT"
                    objExcel.Application.Cells(i, 2).Value = iIntransitWIP
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "IN-TRANSIT (Cellular 1 STAGE 1 Discrepancies)"
                    objExcel.Application.Cells(i, 2).Value = iCell1DiscrepIntransit
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "IN-TRANSIT (Cellular 2 STAGE 1 Discrepancies)"
                    objExcel.Application.Cells(i, 2).Value = iCell2DiscrepIntransit
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "IN-TRANSIT TOTAL"
                    objExcel.Application.Cells(i, 2).Value = iIntransitWIP + iCell1DiscrepIntransit + iCell2DiscrepIntransit

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Interior.ColorIndex = 15
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*********************************************************************
                    'i += 2
                    ''*********************************************************************
                    ''Old WIP
                    ''*********************************************************************
                    'objExcel.Application.Cells(i, 1).Value = "Old WIP"
                    'objExcel.Application.Cells(i, 2).Value = iOldWIP

                    'objSheet.Range("A" & i & ":B" & i).Select()
                    'With objExcel.Selection
                    '    .Interior.ColorIndex = 15
                    '    .Interior.Pattern = Excel.Constants.xlSolid
                    'End With
                    '*********************************************************************
                    i += 2
                    '*********************************************************************
                    'Total WIP for all Locations
                    '*********************************************************************
                    objExcel.Application.Cells(i, 1).Value = "Total WIP for all Locations"
                    objExcel.Application.Cells(i, 2).Value = iTotalWIP

                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .Font.ColorIndex = 5
                        .Interior.ColorIndex = 37
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With

                    '*********************************************************************
                    'Set Font name and size
                    '*****************************************
                    objSheet.Range("A1:B" & i).Select()
                    'Set Font
                    With objExcel.Selection
                        .Font.Name = "Microsoft Sans Serif"
                        .Font.Size = 11
                    End With

                    '************************************************
                    'Add report header
                    objSheet.Range("A1:B1").Select()
                    With objExcel.Selection
                        .MergeCells = True
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        '.font.bold = True
                        .Font.Size = 16
                        .Font.Name = "Verdana"
                        .Font.ColorIndex = 3        'Red
                    End With
                    objExcel.Application.Cells(1, 1).Value = "WIP Summary by Location"

                    '*************************************************
                    If iCust_ID > 0 Then
                        objExcel.Application.Cells(2, 1).Value = strCustomer
                    Else
                        objExcel.Application.Cells(2, 1).Value = "All Customers"
                    End If
                    '*************************************************
                    If iModel_ID > 0 Then
                        objExcel.Application.Cells(3, 1).Value = strModel
                    Else
                        objExcel.Application.Cells(3, 1).Value = "All Models"
                    End If
                    '*************************************************
                    objExcel.Application.Cells(1, 3).Value = Now

                    objSheet.Range("C1").Select()
                    With objExcel.Selection
                        .Font.Size = 8
                    End With
                    '*************************************************
                    objSheet.Columns("A:A").EntireColumn.AutoFit()
                    objSheet.Columns("B:B").EntireColumn.AutoFit()
                    '*************************************************
                    objExcel.Sheets("Sheet2").Delete()
                    objExcel.Sheets("Sheet3").Delete()
                    'Save the excel file
                    If Len(Dir(strFilePath)) > 0 Then
                        Kill(strFilePath)
                    End If
                    objBook.SaveAs(strFilePath)
                    '*************************************************
                    'Open Excel File
                    objXL = New Excel.Application()
                    objXL.Workbooks.Open(strFilePath)
                    objXL.Visible = True
                    '''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    '''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    '''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                Else                            'Detail
                    Dim strVar As String = ""

                    If Trim(strFilePath) = "" Then
                        Exit Function
                    End If


                    FileOpen(1, strFilePath, OpenMode.Append)   'Open TXT file
                    strVar = "Customer" & "," & _
                            "Location" & "," & _
                            "IMEI" & "," & _
                            "Rcvd Palllet" & "," & _
                            "Pallet Type" & "," & _
                            "Lot" & "," & _
                            "PSS Model" & "," & _
                            "Dock Receive Date" & "," & _
                            "No of Days in WIP" & "," & _
                            "WIP Entry Date for Location" & "," & _
                            "Subcontractor" & "," & _
                            "No of days in WIP for Location" & "," & _
                            "PSS WO" & "," & _
                            "PSS Ship Pallet" & "," & _
                            "PSS Pallet Ship Date"

                    'Write Header Line to TXT file
                    PrintLine(1, strVar)
                    Reset()     'Close TXT File

                    '''*******************************************************
                    'Warehouse WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtWarehouse, strFilePath)
                    '''*******************************************************
                    'Cell 1 - Triage WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtCell1Triage1, strFilePath)     'Not production received
                    Me.WriteToTextFile(dtCell1Triage2, strFilePath)     'Production received
                    Me.WriteToTextFile(dtCell1Discrep, strFilePath)
                    '''*******************************************************
                    'Cell 2 - Triage WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtCell2Triage1, strFilePath)     'Not production received
                    Me.WriteToTextFile(dtCell2Triage2, strFilePath)     'Production received
                    Me.WriteToTextFile(dtCell2Discrep, strFilePath)

                    '''*******************************************************
                    'CELL1 WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtCell1, strFilePath)
                    '''*******************************************************
                    'AQLHoldCell1 WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtAQLHoldCell1, strFilePath)
                    '''*******************************************************
                    'CELLULAR 1 Awaiting Parts
                    '''*******************************************************
                    'Me.WriteToTextFile(dtCell1AWP, strFilePath)
                    '''*******************************************************
                    'CELL2 WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtCell2, strFilePath)
                    '''*******************************************************
                    'AQLHoldCell2 WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtAQLHoldCell2, strFilePath)

                    '''*******************************************************
                    'AQL WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtAQL, strFilePath)
                    '''*******************************************************
                    'Subcontractor Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtSubCont, strFilePath)
                    '''*******************************************************
                    'Awaiting Parts
                    '''*******************************************************
                    Me.WriteToTextFile(dtAWP, strFilePath)
                    Me.WriteToTextFile(dtWHAWP, strFilePath)
                    '''*******************************************************
                    'In-transit WIP Count
                    '''*******************************************************
                    Me.WriteToTextFile(dtIntransit, strFilePath)
                    '''*******************************************************
                    'CELL 1 Discrepant WIP Intransit
                    '''*******************************************************
                    Me.WriteToTextFile(dtCell1DiscrepIntransit, strFilePath)
                    '''*******************************************************
                    'CELL 1 Discrepant WIP Intransit
                    '''*******************************************************
                    Me.WriteToTextFile(dtCell2DiscrepIntransit, strFilePath)
                    '*********************************************************
                    ''GAMESTOP WIP
                    '*********************************************************
                    Me.WriteToTextFile(dtGameStopTriage1, strFilePath)     'Not production received
                    Me.WriteToTextFile(dtGameStop, strFilePath)
                    '''*******************************************************
                    'Old WIP
                    '''*******************************************************
                    'Me.WriteToTextFile(dtOldWIP, strFilePath)
                    '''*******************************************************

                    ''''''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    ''''''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                    ''''''&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                End If

                '******************************************************************
                Return 1
            Catch ex As Exception
                Throw New Exception(ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(objMiscBiz) Then
                    objMiscBiz = Nothing
                End If
                '*************************************
                If Not IsNothing(dtWarehouse) Then
                    dtWarehouse.Dispose()
                    dtWarehouse = Nothing
                End If
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
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try

        End Function

        Private Sub WriteToTextFile(ByRef dt1 As DataTable, _
                            ByVal strFilePath As String)
            Dim R1 As DataRow
            Dim strVar As String = ""

            Try
                'Open the file
                FileOpen(1, strFilePath, OpenMode.Append)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Customer")) Then
                        strVar = Trim(R1("Customer")) & ","
                    Else
                        strVar = ","
                    End If
                    If Not IsDBNull(R1("Location")) Then
                        strVar &= Trim(R1("Location")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("IMEI")) Then
                        strVar &= Trim(R1("IMEI")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Rcvd Palllet")) Then
                        strVar &= Trim(R1("Rcvd Palllet")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Pallet Type")) Then
                        strVar &= Trim(R1("Pallet Type")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Lot")) Then
                        strVar &= Trim(R1("Lot")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("PSS Model")) Then
                        strVar &= Trim(R1("PSS Model")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Dock Receive Date")) Then
                        strVar &= Trim(R1("Dock Receive Date")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Dock Receive Date")) Then
                        strVar &= (DateDiff(DateInterval.Day, CDate(R1("Dock Receive Date").ToString), Now)).ToString & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("WIP Entry Date for Location")) Then
                        strVar &= Trim(R1("WIP Entry Date for Location")) & ","
                    Else
                        strVar &= ","
                    End If

                    If Not IsDBNull(R1("Subcontractor")) Then
                        strVar &= Trim(R1("Subcontractor")) & ","
                    Else
                        strVar &= ","
                    End If

                    If Not IsDBNull(R1("WIP Entry Date for Location")) Then
                        strVar &= (DateDiff(DateInterval.Day, CDate(R1("WIP Entry Date for Location").ToString), Now)).ToString & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("PSS WO")) Then
                        strVar &= Trim(R1("PSS WO")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("PSS Ship Pallet")) Then
                        strVar &= Trim(R1("PSS Ship Pallet")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("PSS Ship Date")) Then
                        strVar &= Trim(R1("PSS Ship Date"))
                    Else
                        strVar &= " "
                    End If

                    'Write Header Line to TXT file
                    PrintLine(1, strVar)
                    strVar = ""

                Next R1
            Catch ex As Exception
                Throw ex
            Finally
                Reset()     'Close TXT file
            End Try
        End Sub


        '**********************************************************
        'Warehouse
        Public Function GetWarehouseWIP(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer) As DataTable
            Dim strsql As String = ""
            Try
                strsql = "Select " & Environment.NewLine
                strsql &= "'WAREHOUSE' as Location, " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_ID, " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_Pieceidentifier as IMEI, " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number as 'Rcvd Palllet', " & Environment.NewLine
                strsql &= "twarehousepallet.wh_pallettype as 'Pallet Type', " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_Lot as 'Lot', " & Environment.NewLine
                strsql &= "tmodel.model_desc as 'PSS Model', " & Environment.NewLine
                strsql &= "tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_DateLoaded as 'WIP Entry Date for Location', " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_DateLoaded as 'Dock Receive Date', " & Environment.NewLine
                strsql &= "'' as 'PSS WO', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Pallet', " & Environment.NewLine
                strsql &= "'' as 'Subcontractor', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Date' " & Environment.NewLine
                strsql &= "from twarehousepalletload " & Environment.NewLine
                strsql &= "inner join twarehousepallet on twarehousepalletload.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "left outer join tmodel on twarehousepallet.model_ID = tmodel.model_ID " & Environment.NewLine
                strsql &= "left outer join tcustomer on twarehousepallet.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strsql &= "where whp_rcvdflag = 8 " & Environment.NewLine
                strsql &= "and WHP_PalletRcvd = 0 " & Environment.NewLine

                If iCust_ID > 0 Then
                    strsql &= " and twarehousepallet.Cust_ID = " & iCust_ID & " " & Environment.NewLine
                End If

                If iModel_ID > 0 Then
                    strsql &= " and twarehousepallet.Model_ID = " & iModel_ID & ";"
                Else
                    strsql &= ";"
                End If

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        'Warehouse
        Public Function GetWarehouseAwaitingParts(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer) As DataTable
            Dim strsql As String = ""
            Try
                strsql = "Select " & Environment.NewLine
                strsql &= "'AWAITING PARTS' as Location, " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_ID, " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_Pieceidentifier as IMEI, " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number as 'Rcvd Palllet', " & Environment.NewLine
                strsql &= "twarehousepallet.wh_pallettype as 'Pallet Type', " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_Lot as 'Lot', " & Environment.NewLine
                strsql &= "tmodel.model_desc as 'PSS Model', " & Environment.NewLine
                strsql &= "tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_DateLoaded as 'WIP Entry Date for Location', " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_DateLoaded as 'Dock Receive Date', " & Environment.NewLine
                strsql &= "'' as 'PSS WO', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Pallet', " & Environment.NewLine
                strsql &= "'' as 'Subcontractor', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Date' " & Environment.NewLine
                strsql &= "from twarehousepalletload " & Environment.NewLine
                strsql &= "inner join twarehousepallet on twarehousepalletload.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "left outer join tmodel on twarehousepallet.model_ID = tmodel.model_ID " & Environment.NewLine
                strsql &= "left outer join tcustomer on twarehousepallet.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strsql &= "where whp_rcvdflag = 13 " & Environment.NewLine

                If iCust_ID > 0 Then
                    strsql &= " and twarehousepallet.Cust_ID = " & iCust_ID & " " & Environment.NewLine
                End If

                If iModel_ID > 0 Then
                    strsql &= " and twarehousepallet.Model_ID = " & iModel_ID & ";"
                Else
                    strsql &= ";"
                End If

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '**********************************************************
        'Traige part 1
        Public Function GetTriageWIP1(ByVal iCust_ID As Integer, _
                                    ByVal iGroup_ID As Integer, _
                                    ByVal iModel_ID As Integer, _
                                    Optional ByVal strPalletType As String = "") _
                                    As DataTable
            Dim strsql As String = ""
            Dim strLocation As String = ""
            Try

                If iGroup_ID = 5 Then
                    strLocation = "CELLULAR 1 STAGE 1 (Not Production Received)"
                ElseIf iGroup_ID = 11 Then
                    strLocation = "CELLULAR 2 STAGE 1 (Not Production Received)"
                ElseIf iGroup_ID = 14 Then
                    strLocation = "GAMESTOP (Not Production Received)"
                End If

                strsql = "Select " & Environment.NewLine
                strsql &= "'" & strLocation & "' as Location, " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_ID, " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_Pieceidentifier as IMEI, " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number as 'Rcvd Palllet', " & Environment.NewLine
                strsql &= "twarehousepallet.wh_pallettype as 'Pallet Type', " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_Lot as 'Lot', " & Environment.NewLine
                strsql &= "tmodel.model_desc as 'PSS Model', " & Environment.NewLine
                strsql &= "tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_DateLoaded as 'Dock Receive Date', " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_TraigeWIPEntryDt as 'WIP Entry Date for Location', " & Environment.NewLine
                strsql &= "'' as 'PSS WO', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Pallet', " & Environment.NewLine
                strsql &= "'' as 'Subcontractor', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Date' " & Environment.NewLine
                strsql &= "from twarehousepalletload  " & Environment.NewLine
                strsql &= "inner join twarehousepallet on twarehousepalletload.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "left outer join tmodel on twarehousepallet.model_ID = tmodel.model_ID " & Environment.NewLine
                strsql &= "left outer join tcustomer on twarehousepallet.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strsql &= "where twarehousepalletload.WHP_RcvdFlag = " & iGroup_ID & " and " & Environment.NewLine

                If iCust_ID > 0 Then
                    strsql &= "twarehousepallet.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                End If

                If iModel_ID > 0 Then
                    strsql &= "twarehousepallet.Model_ID = " & iModel_ID & " and "
                End If

                If Trim(strPalletType) <> "" Then
                    strsql &= "twarehousepallet.WH_PalletType = '" & strPalletType & "' and "
                End If

                strsql &= "twarehousepallet.WHP_PalletRcvd = 0;"
                objMisc._SQL = strsql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '**********************************************************
        'Get Discrepancy In-transit WIP
        Public Function GetDiscrepancyIntransitWIP(ByVal iCust_ID As Integer, _
                                                    ByVal iGroup_ID As Integer, _
                                                    ByVal iModel_ID As Integer) _
                                                    As DataTable
            Dim strsql As String = ""
            Dim strLocation As String = ""

            Try
                If iGroup_ID = 5 Then
                    strLocation = "IN-TRANSIT (CELLULAR 1 STAGE 1 Discrepancies)"
                ElseIf iGroup_ID = 11 Then
                    strLocation = "IN-TRANSIT  (CELLULAR 2 STAGE 1 Discrepancies)"
                End If

                strsql = "Select " & Environment.NewLine
                strsql &= "'" & strLocation & "' as Location, " & Environment.NewLine
                'strsql &= "twarehousereceive.WHR_Dev_SN as IMEI, " & Environment.NewLine
                strsql &= "if(twarehousereceive.WHR_Box_SN is null,  twarehousereceive.WHR_Dev_SN, twarehousereceive.WHR_Box_SN) as IMEI, " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_ID, " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number as 'Rcvd Palllet', " & Environment.NewLine
                strsql &= "twarehousepallet.wh_pallettype as 'Pallet Type', " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_Lot as 'Lot', " & Environment.NewLine
                strsql &= "tmodel.Model_Desc as 'PSS Model', " & Environment.NewLine
                strsql &= "tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strsql &= "twarehousepallet.WHDateLoaded as 'Dock Receive Date', " & Environment.NewLine
                strsql &= "twarehousereceive.WHR_DupInFile, " & Environment.NewLine
                strsql &= "0 as NoOfDups, " & Environment.NewLine
                strsql &= "twarehousereceive.WHR_DateLoaded as 'WIP Entry Date for Location', " & Environment.NewLine
                strsql &= "'' as 'PSS WO', " & Environment.NewLine
                strsql &= "tpallett.Pallett_Name as 'PSS Ship Pallet', " & Environment.NewLine
                strsql &= "'' as 'Subcontractor', " & Environment.NewLine
                strsql &= "tpallett.Pallett_ShipDate as 'PSS Ship Date' " & Environment.NewLine
                strsql &= "from  " & Environment.NewLine
                strsql &= "twarehousereceive inner join twarehousepallet on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "left outer join tmodel on twarehousepallet.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "left outer join tcustomer on twarehousepallet.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strsql &= "inner join tpallett on twarehousereceive.pallett_id = tpallett.pallett_id " & Environment.NewLine
                strsql &= "where " & Environment.NewLine
                strsql &= "twarehousereceive.WHR_Result > 0 and " & Environment.NewLine
                strsql &= "twarehousereceive.WHR_WIPOwner = " & iGroup_ID & " and " & Environment.NewLine

                If iCust_ID > 0 Then
                    strsql &= "twarehousepallet.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                End If

                If iModel_ID > 0 Then
                    strsql &= "twarehousepallet.Model_ID = " & iModel_ID & " and "
                End If

                strsql &= "twarehousereceive.Pallett_ID is not NULL and tpallett.pallett_shipdate > '" & strDt & "';"

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '**********************************************************
        'Traige Discrepancies
        Public Function GetDiscrepancyWIP(ByVal iCust_ID As Integer, _
                                        ByVal iGroup_ID As Integer, _
                                        ByVal iModel_ID As Integer) _
                                        As DataTable
            Dim strsql As String = ""
            Dim R1, R2 As DataRow
            Dim dt1, dt2 As DataTable
            Dim i As Integer = 0
            Dim strLocation As String = ""


            Try
                If iGroup_ID = 5 Then
                    strLocation = "CELLULAR 1 STAGE 1 (Discrepancies not Shipped)"
                ElseIf iGroup_ID = 11 Then
                    strLocation = "CELLULAR 2 STAGE 1 (Discrepancies not Shipped)"
                ElseIf iGroup_ID = 14 Then
                    strLocation = "GAMESTOP (Discrepancies not Shipped)"
                End If

                strsql = "Select " & Environment.NewLine
                strsql &= "'" & strLocation & "' as Location, " & Environment.NewLine
                'strsql &= "twarehousereceive.WHR_Dev_SN as IMEI, " & Environment.NewLine
                strsql &= "if(twarehousereceive.WHR_Box_SN is null, twarehousereceive.WHR_Dev_SN, twarehousereceive.WHR_Box_SN) as IMEI, " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_ID, " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number as 'Rcvd Palllet', " & Environment.NewLine
                strsql &= "twarehousepallet.wh_pallettype as 'Pallet Type', " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_Lot as 'Lot', " & Environment.NewLine
                strsql &= "tmodel.Model_Desc as 'PSS Model', " & Environment.NewLine
                strsql &= "tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strsql &= "twarehousepallet.WHDateLoaded as 'Dock Receive Date', " & Environment.NewLine
                strsql &= "twarehousereceive.WHR_DupInFile, " & Environment.NewLine
                strsql &= "0 as NoOfDups, " & Environment.NewLine
                strsql &= "twarehousereceive.WHR_DateLoaded as 'WIP Entry Date for Location', " & Environment.NewLine
                strsql &= "'' as 'PSS WO', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Pallet', " & Environment.NewLine
                strsql &= "'' as 'Subcontractor', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Date' " & Environment.NewLine
                strsql &= "from  " & Environment.NewLine
                strsql &= "twarehousereceive inner join twarehousepallet on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "left outer join tmodel on twarehousepallet.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "left outer join tcustomer on twarehousepallet.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strsql &= "where " & Environment.NewLine
                strsql &= "twarehousereceive.WHR_Result > 0 and " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_PalletRcvd = 0 and " & Environment.NewLine
                strsql &= "twarehousereceive.WHR_WIPOwner = " & iGroup_ID & " and " & Environment.NewLine

                If iCust_ID > 0 Then
                    strsql &= " twarehousepallet.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                End If

                If iModel_ID > 0 Then
                    strsql &= " twarehousepallet.Model_ID = " & iModel_ID & " and " & Environment.NewLine
                End If

                strsql &= "Pallett_ID is NULL;"

                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                For Each R1 In dt1.Rows
                    If R1("WHR_DupInFile") = 1 Then
                        'Go get how many duplicates there are from twarehousepalletload
                        strsql = "Select count(*) as cnt " & Environment.NewLine
                        strsql &= "from twarehousereceive " & Environment.NewLine
                        strsql &= "inner join twarehousepalletload on twarehousereceive.WHR_Box_SN = twarehousepalletload.WHP_PieceIdentifier " & Environment.NewLine
                        strsql &= "where twarehousereceive.WHR_Box_SN = '" & Trim(R1("WHR_Box_SN")) & "' and " & Environment.NewLine
                        strsql &= "twarehousereceive.WHR_DupInFile = 1 and " & Environment.NewLine
                        strsql &= "twarehousereceive.WHPallet_ID = " & R1("WHPallet_ID") & " and " & Environment.NewLine
                        strsql &= "twarehousereceive.Pallett_ID is NULL;"
                        objMisc._SQL = strsql
                        dt2 = objMisc.GetDataTable

                        R2 = dt2.Rows(0)
                        R1("NoOfDups") = R2("cnt")
                        '******************************
                        R2 = Nothing
                        If Not IsNothing(dt2) Then
                            dt2.Dispose()
                            dt2 = Nothing
                        End If
                    End If
                Next R1

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function
        '**********************************************************
        'Cellular 1 
        Public Function GetWIP(ByVal iCust_ID As Integer, _
                                ByVal iGroup_ID As Integer, _
                                ByVal iModel_ID As Integer, _
                                Optional ByVal strPalletType As String = "") _
                                As DataTable
            Dim strsql As String = ""

            Try
                strsql = "Select  " & Environment.NewLine
                strsql &= "lgroups.Group_Desc as Location,  " & Environment.NewLine
                strsql &= "tdevice.device_id,  " & Environment.NewLine
                strsql &= "tdevice.device_sn as IMEI,  " & Environment.NewLine
                strsql &= "tworkorder.WO_RecPalletName  as 'Rcvd Palllet', " & Environment.NewLine
                strsql &= "twarehousepallet.WH_PalletType as 'Pallet Type', " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_Lot as 'Lot', " & Environment.NewLine
                strsql &= "tmodel.model_desc as 'PSS Model', " & Environment.NewLine
                strsql &= "tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strsql &= "twarehousepallet.WHDateLoaded as 'Dock Receive Date', " & Environment.NewLine
                strsql &= "tcellopt.Cellopt_WIPEntryDt as 'WIP Entry Date for Location', " & Environment.NewLine
                strsql &= "tworkorder.wo_custwo as 'PSS WO', " & Environment.NewLine
                strsql &= "tpallett.Pallett_Name 'PSS Ship Pallet', " & Environment.NewLine
                strsql &= "tsubcontractor.SC_Desc 'Subcontractor', " & Environment.NewLine
                strsql &= "tpallett.Pallett_shipdate 'PSS Ship Date' " & Environment.NewLine
                strsql &= "from tcellopt " & Environment.NewLine
                strsql &= "inner join tdevice on tcellopt.device_id = tdevice.device_id  " & Environment.NewLine
                strsql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strsql &= "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
                strsql &= "inner join lgroups on tcellopt.Cellopt_WIPOwner = lgroups.group_id " & Environment.NewLine
                strsql &= "left outer join twarehousepallet on tworkorder.WO_RecPalletName = twarehousepallet.WHPallet_Number " & Environment.NewLine
                strsql &= "left outer join tpallett on tdevice.pallett_id = tpallett.Pallett_ID " & Environment.NewLine
                strsql &= "left outer join tsubcontractor on tcellopt.SC_ID = tsubcontractor.sc_id " & Environment.NewLine

                strsql &= "where Cellopt_WIPOwner = " & iGroup_ID & " and " & Environment.NewLine

                If iCust_ID > 0 Then
                    strsql &= "tcustomer.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                End If

                If iModel_ID > 0 Then
                    strsql &= "tdevice.Model_ID = " & iModel_ID & " and "
                End If

                If Trim(strPalletType) <> "" Then
                    strsql &= "twarehousepallet.WH_PalletType = '" & strPalletType & "' and "
                End If

                If iGroup_ID = 7 Then        'In-transit
                    strsql &= "tcellopt.Cellopt_WIPEntryDt > '" & strDt & "' " & Environment.NewLine
                ElseIf iGroup_ID = 13 Then      'Cell 2 Awaiting parts
                    strsql &= "(tdevice.Device_DateShip is NULL or tdevice.Device_DateShip is not NULL);"
                Else
                    strsql &= "(tdevice.Device_DateShip is NULL or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '');"
                End If

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**********************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub
        '**********************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '**********************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub









        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '**********************************************************
        Public Function New_WIPReport(ByVal iCust_ID As Integer, _
                                    Optional ByVal iSummaryOrDetail As Integer = 0, _
                                    Optional ByVal strFilePath As String = "", _
                                    Optional ByVal iModel_ID As Integer = 0, _
                                    Optional ByVal strModel As String = "") _
                                    As Integer

            Dim objMiscBiz As New PSS.Data.Buisness.Misc()
            Dim strsql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1 As DataRow
            Dim strvar As String = ""
            Dim strCustomer As String = ""
            Dim i As Integer = 1

            'Excel Related variables
            Dim objXL As Excel.Application
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet

            Try
                '******************************
                If iSummaryOrDetail = 0 Then        'WIP Summary

                    '******************************************************************
                    'Get Customer name
                    '******************************************************************
                    If iCust_ID > 0 Then
                        dt1 = objMiscBiz.GetCustomerInfo(iCust_ID)
                        If dt1.Rows.Count > 0 Then
                            R1 = dt1.Rows(0)
                            strCustomer = Trim(R1("cust_name1"))
                        End If

                        R1 = Nothing
                        If Not IsNothing(dt1) Then
                            dt1.Dispose()
                            dt1 = Nothing
                        End If
                    End If

                    '******************************************************************
                    'Write to Excel File
                    '******************************************************************
                    'Instantiate the excel related objects
                    objExcel = New Excel.Application()      'Starts the Excel Session
                    objBook = objExcel.Workbooks.Add                    'Add a Workbook
                    objExcel.Application.Visible = True                 'Make this false while going live
                    objExcel.Application.DisplayAlerts = False
                    objSheet = objBook.Worksheets.Item(1)               'Select a Sheet 1 for this

                    objSheet.Cells.Select()
                    objExcel.Selection.NumberFormat = "@"

                    '************************************************
                    'Add report header
                    objSheet.Range("A" & i & ":B" & i).Select()
                    With objExcel.Selection
                        .MergeCells = True
                        .HorizontalAlignment = Excel.Constants.xlLeft
                        '.font.bold = True
                        .Font.Size = 16
                        .Font.Name = "Verdana"
                        .Font.ColorIndex = 3        'Red
                    End With
                    objExcel.Application.Cells(i, 1).Value = "WIP Summary by Location"
                    '*************************************************
                    objExcel.Application.Cells(i, 3).Value = Now
                    objSheet.Range("C" & i).Select()
                    With objExcel.Selection
                        .Font.Size = 8
                    End With
                    '*************************************************
                    i += 1
                    If iCust_ID > 0 Then
                        objExcel.Application.Cells(i, 1).Value = strCustomer
                    Else
                        objExcel.Application.Cells(i, 1).Value = "All Customers"
                    End If
                    '*************************************************
                    i += 1
                    If iModel_ID > 0 Then
                        objExcel.Application.Cells(i, 1).Value = strModel
                    Else
                        objExcel.Application.Cells(i, 1).Value = "All Models"
                    End If
                    '*****************************************
                    'Create the Colummn header
                    '*****************************************
                    i += 1
                    objExcel.Application.Cells(i, 1).Value = "Location"
                    objExcel.Application.Cells(i, 2).Value = "WIP Count"
                    '*****************************************
                    'Set column widths
                    '*****************************************
                    objSheet.Columns("A:A").ColumnWidth = 35
                    objSheet.Columns("B:B").ColumnWidth = 15
                    '*****************************************
                    'Set alignments
                    '*****************************************
                    objSheet.Columns("A:A").HorizontalAlignment = Excel.Constants.xlLeft
                    objSheet.Columns("B:B").HorizontalAlignment = Excel.Constants.xlRight
                    '*****************************************
                    'Format cells Data Type
                    '*****************************************
                    objSheet.Columns("A:A").Select()
                    objExcel.Selection.NumberFormat = "@"
                    objSheet.Columns("B:B").Select()
                    objExcel.Selection.NumberFormat = "@"
                    '*****************************************
                    'Set horizontal alignment for the header
                    '*****************************************
                    objSheet.Range("A4:B4").Select()
                    With objExcel.Selection
                        .WrapText = True
                        .HorizontalAlignment = Excel.Constants.xlCenter
                        .VerticalAlignment = Excel.Constants.xlCenter
                        .font.bold = True
                        .Font.ColorIndex = 5
                        .Interior.ColorIndex = 37
                        .Interior.Pattern = Excel.Constants.xlSolid
                    End With
                    '*****************************************
                    i += 1

                Else                    'WIP Detail
                    FileOpen(1, strFilePath, OpenMode.Append)   'Open TXT file
                    strvar = "Customer" & "," & _
                            "Location" & "," & _
                            "IMEI" & "," & _
                            "Rcvd Palllet" & "," & _
                            "Pallet Type" & "," & _
                            "Lot" & "," & _
                            "PSS Model" & "," & _
                            "Dock Receive Date" & "," & _
                            "No of Days in WIP" & "," & _
                            "WIP Entry Date for Location" & "," & _
                            "Subcontractor" & "," & _
                            "No of days in WIP for Location" & "," & _
                            "PSS WO" & "," & _
                            "PSS Ship Pallet" & "," & _
                            "PSS Pallet Ship Date"
                    'Write Header Line to TXT file
                    PrintLine(1, strvar)
                    Reset()     'Close TXT File
                End If

                '********************************************
                'Get all groups
                '********************************************
                strsql = "Select * from lgroups where ReportingSequence > 0 order by ReportingSequence, Group_Desc;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                '********************************************
                'Loop through all groups
                '********************************************
                For Each R1 In dt1.Rows
                    Select Case R1("LikeBucketGrouping")
                        Case 1
                            dt2 = New_GetWarehouseSideWIP(iCust_ID, R1("Group_ID"), iModel_ID)
                        Case 2
                            dt2 = New_ProductionSideWIP(iCust_ID, R1("Group_ID"), iModel_ID)
                        Case Else
                            Throw New Exception("Group does not have a ""Like Bucket Grouping"" assigned.")
                    End Select

                    'Create Reports
                    If iSummaryOrDetail = 0 Then        'WIP Summary
                        i += 1
                        objExcel.Application.Cells(i, 1).Value = Trim(R1("Group_Desc"))
                        objExcel.Application.Cells(i, 2).Value = dt2.Rows.Count()
                    Else                                'WIP Detail
                        New_AddToWIPDetailReport(dt2, strFilePath)
                    End If

                    '***************************************
                    'Reset Loop Variables
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If
                    '***************************************
                Next R1

                '************************************************************
                'Formatting and saving the excel file for WIP Summary
                If iSummaryOrDetail = 0 Then
                    '*************************************************
                    objSheet.Columns("A:A").EntireColumn.AutoFit()
                    objSheet.Columns("B:B").EntireColumn.AutoFit()
                    '*************************************************
                    objExcel.Sheets("Sheet2").Delete()
                    objExcel.Sheets("Sheet3").Delete()
                    'Save the excel file
                    If Len(Dir(strFilePath)) > 0 Then
                        Kill(strFilePath)
                    End If
                    objBook.SaveAs(strFilePath)
                    '*************************************************
                    'Open Excel File
                    objXL = New Excel.Application()
                    objXL.Workbooks.Open(strFilePath)
                    objXL.Visible = True
                    '*************************************************
                End If

                '******************************************************************
                Return 1
            Catch ex As Exception
                Throw New Exception(ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                If Not IsNothing(objMiscBiz) Then
                    objMiscBiz = Nothing
                End If
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

        '*******************************************************************
        'LIKE BUCKET GROUPING = 2
        '*******************************************************************
        Public Function New_ProductionSideWIP(ByVal iCust_ID As Integer, _
                                ByVal iGroup_ID As Integer, _
                                ByVal iModel_ID As Integer) _
                                As DataTable
            Dim strsql As String = ""

            Try
                strsql = "Select " & Environment.NewLine
                strsql &= "lgroups.Group_Desc as Location,  " & Environment.NewLine
                strsql &= "tdevice.device_id,  " & Environment.NewLine
                strsql &= "tdevice.device_sn as IMEI,  " & Environment.NewLine
                strsql &= "tworkorder.WO_RecPalletName  as 'Rcvd Palllet', " & Environment.NewLine
                strsql &= "twarehousepallet.WH_PalletType as 'Pallet Type', " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_Lot as 'Lot', " & Environment.NewLine
                strsql &= "tmodel.model_desc as 'PSS Model', " & Environment.NewLine
                strsql &= "tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strsql &= "twarehousepallet.WHDateLoaded as 'Dock Receive Date', " & Environment.NewLine
                strsql &= "tcellopt.Cellopt_WIPEntryDt as 'WIP Entry Date for Location', " & Environment.NewLine
                strsql &= "tworkorder.wo_custwo as 'PSS WO', " & Environment.NewLine
                strsql &= "tpallett.Pallett_Name 'PSS Ship Pallet', " & Environment.NewLine
                strsql &= "tsubcontractor.SC_Desc 'Subcontractor', " & Environment.NewLine
                strsql &= "tpallett.Pallett_shipdate 'PSS Ship Date' " & Environment.NewLine
                strsql &= "from tcellopt " & Environment.NewLine
                strsql &= "inner join tdevice on tcellopt.device_id = tdevice.device_id  " & Environment.NewLine
                strsql &= "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                strsql &= "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & Environment.NewLine
                strsql &= "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & Environment.NewLine
                strsql &= "inner join lgroups on tcellopt.Cellopt_WIPOwner = lgroups.group_id " & Environment.NewLine
                strsql &= "left outer join twarehousepallet on tworkorder.WO_RecPalletName = twarehousepallet.WHPallet_Number " & Environment.NewLine
                strsql &= "left outer join tpallett on tdevice.pallett_id = tpallett.Pallett_ID " & Environment.NewLine
                strsql &= "left outer join tsubcontractor on tcellopt.SC_ID = tsubcontractor.sc_id " & Environment.NewLine

                strsql &= "where Cellopt_WIPOwner = " & iGroup_ID & " and " & Environment.NewLine

                If iCust_ID > 0 Then
                    strsql &= "tcustomer.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                End If
                If iModel_ID > 0 Then
                    strsql &= "tdevice.Model_ID = " & iModel_ID & " and "
                End If
                If iGroup_ID = 7 Then        'In-transit
                    strsql &= "tcellopt.Cellopt_WIPEntryDt > '" & strDt & "' " & Environment.NewLine
                Else
                    strsql &= "(tdevice.Device_DateShip is NULL or Device_DateShip = '0000-00-00 00:00:00' or trim(Device_DateShip) = '');"
                End If

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*******************************************************************
        'LIKE Bucket GROUPING = 1
        'THis takes care of 
        '(1) Warehouse 
        '(2) Cell1 Stage 1
        '(3) Cell2 Stage 1
        '(4) Warehouse Awaiting Parts
        '*******************************************************************
        Private Function New_GetWarehouseSideWIP(ByVal iCust_ID As Integer, _
                                    ByVal iGroup_ID As Integer, _
                                    ByVal iModel_ID As Integer) _
                                    As DataTable
            Dim strsql As String = ""
            Dim strLocation As String = ""
            Try
                strsql = "Select " & Environment.NewLine
                strsql &= "lgroups.group_desc as Location, " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_ID, " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_Pieceidentifier as IMEI, " & Environment.NewLine
                strsql &= "twarehousepallet.WHPallet_Number as 'Rcvd Palllet', " & Environment.NewLine
                strsql &= "twarehousepallet.wh_pallettype as 'Pallet Type', " & Environment.NewLine
                strsql &= "twarehousepallet.WHP_Lot as 'Lot', " & Environment.NewLine
                strsql &= "tmodel.model_desc as 'PSS Model', " & Environment.NewLine
                strsql &= "tcustomer.cust_name1 as 'Customer', " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_DateLoaded as 'Dock Receive Date', " & Environment.NewLine
                strsql &= "twarehousepalletload.WHP_TraigeWIPEntryDt as 'WIP Entry Date for Location', " & Environment.NewLine
                strsql &= "'' as 'PSS WO', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Pallet', " & Environment.NewLine
                strsql &= "'' as 'Subcontractor', " & Environment.NewLine
                strsql &= "'' as 'PSS Ship Date' " & Environment.NewLine
                strsql &= "from twarehousepalletload " & Environment.NewLine
                strsql &= "inner join twarehousepallet on twarehousepalletload.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "left outer join lgroups on twarehousepalletload.WHP_RcvdFlag = lgroups.Group_ID " & Environment.NewLine
                strsql &= "left outer join tmodel on twarehousepallet.model_ID = tmodel.model_ID " & Environment.NewLine
                strsql &= "left outer join tcustomer on twarehousepallet.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                strsql &= "where twarehousepalletload.WHP_RcvdFlag = " & iGroup_ID & " and " & Environment.NewLine

                If iCust_ID > 0 Then
                    strsql &= "twarehousepallet.Cust_ID = " & iCust_ID & " and " & Environment.NewLine
                End If
                If iModel_ID > 0 Then
                    strsql &= "twarehousepallet.Model_ID = " & iModel_ID & " and "
                End If
                strsql &= "twarehousepallet.WHP_PalletRcvd = 0;"
                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function
        '**********************************************************
        Private Sub New_AddToWIPDetailReport(ByRef dt1 As DataTable, _
                                    ByVal strFilePath As String)
            Dim R1 As DataRow
            Dim strVar As String = ""

            Try
                'Open the file
                FileOpen(1, strFilePath, OpenMode.Append)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Customer")) Then
                        strVar = Trim(R1("Customer")) & ","
                    Else
                        strVar = ","
                    End If
                    If Not IsDBNull(R1("Location")) Then
                        strVar &= Trim(R1("Location")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("IMEI")) Then
                        strVar &= Trim(R1("IMEI")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Rcvd Palllet")) Then
                        strVar &= Trim(R1("Rcvd Palllet")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Pallet Type")) Then
                        strVar &= Trim(R1("Pallet Type")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Lot")) Then
                        strVar &= Trim(R1("Lot")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("PSS Model")) Then
                        strVar &= Trim(R1("PSS Model")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Dock Receive Date")) Then
                        strVar &= Trim(R1("Dock Receive Date")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Dock Receive Date")) Then
                        strVar &= (DateDiff(DateInterval.Day, CDate(R1("Dock Receive Date").ToString), Now)).ToString & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("WIP Entry Date for Location")) Then
                        strVar &= Trim(R1("WIP Entry Date for Location")) & ","
                    Else
                        strVar &= ","
                    End If

                    If Not IsDBNull(R1("Subcontractor")) Then
                        strVar &= Trim(R1("Subcontractor")) & ","
                    Else
                        strVar &= ","
                    End If

                    If Not IsDBNull(R1("WIP Entry Date for Location")) Then
                        strVar &= (DateDiff(DateInterval.Day, CDate(R1("WIP Entry Date for Location").ToString), Now)).ToString & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("PSS WO")) Then
                        strVar &= Trim(R1("PSS WO")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("PSS Ship Pallet")) Then
                        strVar &= Trim(R1("PSS Ship Pallet")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("PSS Ship Date")) Then
                        strVar &= Trim(R1("PSS Ship Date"))
                    Else
                        strVar &= " "
                    End If

                    'Write Header Line to TXT file
                    PrintLine(1, strVar)
                    strVar = ""

                Next R1
            Catch ex As Exception
                Throw ex
            Finally
                Reset()     'Close TXT file
            End Try
        End Sub

        '**********************************************************
        Public Function GetNextWorkFlowBucket(ByVal iLine_ID As Integer, _
                                            ByVal iCust_ID As Integer, _
                                            ByVal iModel_ID As Integer, _
                                            ByVal iMachineGroupID As Integer, _
                                            ByVal iPassFail As Integer) As Integer
            '*****************************************************************
            'This Function Returns the Next WIP Bucket in the process defined
            'Parameters:
            'Line_ID
            'Cust_ID
            'Model_id
            'Machine Group ID
            'Device Passed or Failed (1 - Pass; 2 - Fail)
            '*****************************************************************
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim iPrevBucket As Integer = 0
            Dim iNextBucket As Integer = -1
            Dim iLPF_ID As Integer = 0

            Try
                strsql = "Select * from tlineprocessflow where Line_ID = " & iLine_ID & " and tlineprocessflow.Cust_ID = " & iCust_ID & " and tlineprocessflow.Model_ID = " & iModel_ID & " order by LPF_Sequence;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Work Flow Sequence was not defined for this Line, Customer and Model.")
                End If

                For Each R1 In dt1.Rows
                    If iPrevBucket = 1 Then
                        iNextBucket = R1("LPF_Bucket")
                        Exit For
                    End If
                    If iMachineGroupID = R1("LPF_Bucket") Then
                        If iPassFail = 1 Then
                            iPrevBucket = 1
                        Else
                            iLPF_ID = R1("LPF_ID")
                            Exit For
                        End If
                    End If
                Next R1
                '*****************************************************************
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                '*****************************************************************
                If iPassFail = 2 Then   'FAIL
                    strsql = "Select * from tconditionalpush where LPF_ID = " & iLPF_ID & ";"
                    objMisc._SQL = strsql
                    dt1 = objMisc.GetDataTable

                    If dt1.Rows.Count = 0 Then
                        Throw New Exception("There is no ""FAIL Bucket"" assigned to this Bucket.")
                    Else
                        iNextBucket = dt1.Rows(0)("CP_Bucket")
                    End If
                End If
                '*****************************************************************
                If iNextBucket = 0 Then
                    Throw New Exception("Reached the end of Work Flow Sequence and Bucket did not match.")
                Else
                    Return iNextBucket
                End If
                '*****************************************************************



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

        Public Function GetPreviousWorkFlowBucket(ByVal iLine_ID As Integer, _
                                                    ByVal iCust_ID As Integer, _
                                                    ByVal iModel_ID As Integer, _
                                                    ByVal iMachineGroupID As Integer) As Integer
            '*****************************************************************
            'This Function Returns the Next WIP Bucket in the process defined
            'Parameters:
            'Line_ID
            'Cust_ID
            'Model_id
            'Machine Group ID
            'Device Passed or Failed (1 - Pass; 2 - Fail)
            '*****************************************************************
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim iMatched As Integer = 0
            Dim iBucket As Integer = 0

            Try
                strsql = "Select * from tlineprocessflow where Line_ID = " & iLine_ID & " and tlineprocessflow.Cust_ID = " & iCust_ID & " and tlineprocessflow.Model_ID = " & iModel_ID & " order by LPF_Sequence;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    Throw (New Exception("Work Flow Sequence was not defined for this Line, Customer and Model."))
                End If

                For Each R1 In dt1.Rows
                    If iMachineGroupID = R1("LPF_Bucket") Then
                        Exit For
                    End If
                    iBucket = R1("LPF_Bucket")
                Next R1
                '*****************************************************************
                Return iBucket

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



        '*******************************************************************
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


        Public Function ATCLEWIPDetailRpt()
            Dim strsql As String = ""
            Dim dt1, dt2, dt3 As DataTable
            Dim strATCFilePath As String = "C:\ATCLE WIP Detail.txt"
            Dim strVar As String = ""

            Try

                strsql = "Select Model_Desc as Model,  " & Environment.NewLine
                strsql &= "lgroups.Group_Desc as Bucket,  " & Environment.NewLine
                strsql &= "WO_RecPalletName 'Rec Pallet',  " & Environment.NewLine
                strsql &= "device_sn as SN,  " & Environment.NewLine
                strsql &= "Device_daterec 'Date Rcvd', " & Environment.NewLine
                strsql &= "device_datebill as 'Date Billed' " & Environment.NewLine
                strsql &= "from tdevice " & Environment.NewLine
                strsql &= "inner join tmodel on tdevice.model_id = tmodel.Model_ID " & Environment.NewLine
                strsql &= "inner join tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                strsql &= "inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strsql &= "inner join lgroups on tcellopt.Cellopt_WIPOwner = lgroups.Group_ID " & Environment.NewLine
                strsql &= "where tdevice.loc_id = 2540 and device_dateship is null " & Environment.NewLine
                strsql &= "order by Model_desc, Group_desc, WO_RecPalletName, device_sn;"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable


                strsql = "Select Model_Desc as Model,  " & Environment.NewLine
                strsql &= "Group_Desc as Bucket,  " & Environment.NewLine
                strsql &= "WHPallet_Number 'Rec Pallet',  " & Environment.NewLine
                strsql &= "WHP_PieceIdentifier as SN,  " & Environment.NewLine
                strsql &= "WHDateLoaded as  'Date Rcvd', " & Environment.NewLine
                strsql &= "'' as 'Date Billed' " & Environment.NewLine
                strsql &= "from twarehousepallet " & Environment.NewLine
                strsql &= "inner join tmodel on twarehousepallet.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "inner join twarehousepalletload on twarehousepalletload.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "inner join lgroups on twarehousepalletload.WHP_RcvdFlag = lgroups.Group_ID " & Environment.NewLine
                strsql &= "where twarehousepallet.WHP_PalletRcvd = 0 and " & Environment.NewLine
                strsql &= "cust_id = 2019 and twarehousepalletload.WHP_RcvdFlag = 8 " & Environment.NewLine
                strsql &= "order by Model_desc, Group_desc, WHPallet_Number, WHP_PieceIdentifier; "
                objMisc._SQL = strsql
                dt2 = objMisc.GetDataTable

                '-- Add this to the Bucket Name of the following resultset  "(Not Productin Rcvd.)"
                strsql = "Select Model_Desc as Model,  " & Environment.NewLine
                strsql &= "Group_Desc as Bucket,  " & Environment.NewLine
                strsql &= "WHPallet_Number 'Rec Pallet',  " & Environment.NewLine
                strsql &= "WHR_Box_SN as SN,  " & Environment.NewLine
                strsql &= "WHDateLoaded as 'Date Rcvd', " & Environment.NewLine
                strsql &= "'' as 'Date Billed' " & Environment.NewLine
                strsql &= "from twarehousepallet " & Environment.NewLine
                strsql &= "inner join tmodel on twarehousepallet.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strsql &= "inner join twarehousereceive on twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strsql &= "inner join lgroups on twarehousereceive.WHR_WIPOwner = lgroups.Group_ID " & Environment.NewLine
                strsql &= "where twarehousepallet.WHP_PalletRcvd = 0 and  " & Environment.NewLine
                strsql &= "cust_id = 2019 " & Environment.NewLine
                strsql &= "order by Model_desc, Group_desc, WHPallet_Number, WHR_Box_SN;"
                objMisc._SQL = strsql
                dt3 = objMisc.GetDataTable


                If Len(Dir(strATCFilePath)) > 0 Then
                    Kill(strATCFilePath)
                End If

                FileOpen(1, strATCFilePath, OpenMode.Append)   'Open TXT file
                strVar = "Model" & "," & _
                        "Bucket" & "," & _
                        "Rec Pallet" & "," & _
                        "SN" & "," & _
                        "Date Rcvd" & "," & _
                        "Date Billed"

                'Write Header Line to TXT file
                PrintLine(1, strVar)
                Reset()     'Close TXT File

                '''*******************************************************
                'Warehouse WIP Count
                '''*******************************************************
                Me.WriteToATCLETextFile(dt1, strATCFilePath)
                Me.WriteToATCLETextFile(dt2, strATCFilePath)
                Me.WriteToATCLETextFile(dt3, strATCFilePath, 1)

                Return 1

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
                If Not IsNothing(dt3) Then
                    dt3.Dispose()
                    dt3 = Nothing
                End If
            End Try
        End Function

        Private Sub WriteToATCLETextFile(ByVal dt1 As DataTable, _
                                    ByVal strFilePath As String, _
                                    Optional ByVal i As Integer = 0)
            Dim R1 As DataRow
            Dim strVar As String = ""

            Try
                'Open the file
                FileOpen(1, strFilePath, OpenMode.Append)

                For Each R1 In dt1.Rows
                    If Not IsDBNull(R1("Model")) Then
                        strVar = Trim(R1("Model")) & ","
                    Else
                        strVar = ","
                    End If
                    If Not IsDBNull(R1("Bucket")) Then

                        'If Trim(R1("Bucket")) = "2RP3041307KDIS" Then
                        '    MsgBox("stop")
                        'End If


                        If i = 0 Then
                            strVar &= Trim(R1("Bucket")) & ","
                        Else
                            strVar &= Trim(R1("Bucket")) & " (Not Productin Rcvd.) ,"
                        End If
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Rec Pallet")) Then
                        strVar &= Trim(R1("Rec Pallet")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("SN")) Then
                        strVar &= Trim(R1("SN")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Date Rcvd")) Then
                        strVar &= Trim(R1("Date Rcvd")) & ","
                    Else
                        strVar &= ","
                    End If
                    If Not IsDBNull(R1("Date Billed")) Then
                        strVar &= Trim(R1("Date Billed"))
                    Else
                        strVar &= " "
                    End If

                    'Write Header Line to TXT file
                    PrintLine(1, strVar)
                    strVar = ""

                Next R1
            Catch ex As Exception
                Throw ex
            Finally
                Reset()     'Close TXT file
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        Public Sub ATCLEWIP_VerifyExcelFileData(ByVal strFilePath As String, ByVal iNoPallet As Integer)
            Dim R1, R2 As DataRow
            Dim i As Integer = 0
            Dim iCounter As Integer = 0
            Dim strsql As String = ""
            Dim iWHPallet_ID As Integer = 0

            Dim strDtRec As String = ""
            Dim strDtShip As String = ""
            Dim strBucket As String = ""
            Dim iIsDiscrepancy As Integer = 0
            Dim iPalletRcvdinWIP As Integer = 0
            Dim strModel As String = ""
            Dim strpss_table_name As String = ""
            Dim strVar As String = ""
            Dim strOldSN As String = ""
            Dim strSN As String = ""
            Dim strRcvdPalletName As String = ""
            Dim strShipPalletName As String = ""

            Dim strFP As String = "C:\ATCLE_ExcelData_Verification.txt"
            Dim dtDevice, dtWHPLoad, dtWHRec, dtOldDevice As DataTable

            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim sConnectionstring As String = ""

            Dim DS As New DataSet()

            Try

                '****************************************************************************
                'OPen text file to append
                If Len(Dir(strFP)) > 0 Then
                    Kill(strFP)
                End If
                FileOpen(1, strFP, OpenMode.Append)   'Open TXT file

                'Create the header
                strVar = "IMEI" & "," & _
                            "Old IMEI" & "," & _
                            "Rcvd Pallet" & "," & _
                            "Model" & "," & _
                            "Date Rcvd." & "," & _
                            "Date Shipped" & "," & _
                            "Bucket" & "," & _
                            "Ship Pallet" & "," & _
                            "Is Discrepancy" & "," & _
                            "Is Pallet Rcvd." & "," & _
                            "pss_table_name"

                'Write Header Line to TXT file
                PrintLine(1, strVar)
                '********************************************************************************************************************
                'Read Excel File
                '********************************************************************************************************************
                sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strFilePath & ";Extended Properties=Excel 8.0;"
                objConn.ConnectionString = sConnectionstring
                objConn.Open()
                'objCmdSelect.CommandText = ("SELECT [Piece Identifier], [Bin Location] FROM [McHugh Export$] where [Piece Identifier] is not NULL")
                objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$]")
                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(DS)

                'AddNewColumnToDataTable(DS.Tables(0), "Old_IMEI", "System.String")
                'AddNewColumnToDataTable(DS.Tables(0), "DateRec", "System.String")
                'AddNewColumnToDataTable(DS.Tables(0), "DateShip", "System.String")
                'AddNewColumnToDataTable(DS.Tables(0), "Bucket", "System.String")
                'AddNewColumnToDataTable(DS.Tables(0), "IsDiscrepancy", "System.Int32")
                'AddNewColumnToDataTable(DS.Tables(0), "PalletRcvdinWIP", "System.Int32")
                'AddNewColumnToDataTable(DS.Tables(0), "Model", "System.String")
                'AddNewColumnToDataTable(DS.Tables(0), "pss_table_name", "System.String")

                '***************************************************************
                For Each R1 In DS.Tables(0).Rows
                    strSN = Trim(R1("Piece Identifier"))
                    'Select from tdevice
                    strsql = "Select tdevice.device_id, tdevice.device_oldsn, tdevice.Device_DateRec as DateRec, Device_DateShip as DateShip, lgroups.Group_Desc, 0 as Result, 1 as WHP_PalletRcvd, tmodel.model_desc, 'tdevice' as pss_table_name, tworkorder.WO_RecPalletName as RcvdPalletName" & Environment.NewLine
                    strsql &= ", if (Pallett_Name is null, '', Pallett_Name) as ShipPalletName " & Environment.NewLine
                    strsql &= "from tdevice inner join tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                    strsql &= "inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                    strsql &= "inner join lgroups on tcellopt.Cellopt_WIPOwner = lgroups.Group_ID " & Environment.NewLine
                    strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                    strsql &= "left outer join tpallett on tdevice.pallett_id = tpallett.pallett_id " & Environment.NewLine
                    strsql &= "where  " & Environment.NewLine
                    strsql &= "tdevice.Loc_ID = 2540 and " & Environment.NewLine

                    If iNoPallet = 0 Then
                        strsql &= "tworkorder.WO_RecPalletName = '" & Trim(R1("Bin Location")) & "' and " & Environment.NewLine
                    End If


                    strsql &= "tdevice.Device_SN = '" & Trim(R1("Piece Identifier")) & "' order by device_id desc;"
                    'dtDevice = GetDataTable(strsql)
                    objMisc._SQL = strsql
                    dtDevice = objMisc.GetDataTable

                    If dtDevice.Rows.Count = 0 Then
                        '***************************
                        'Lan added on 07-25-2007
                        'check oldSN
                        '***************************
                        'Select from tdevice
                        strsql = "Select tdevice.device_SN, tdevice.device_id, tdevice.device_oldsn, tdevice.Device_DateRec as DateRec, Device_DateShip as DateShip, lgroups.Group_Desc, 0 as Result, 1 as WHP_PalletRcvd, tmodel.model_desc, 'tdevice' as pss_table_name, tworkorder.WO_RecPalletName as RcvdPalletName" & Environment.NewLine
                        strsql &= ", if (Pallett_Name is null, '', Pallett_Name) as ShipPalletName " & Environment.NewLine
                        strsql &= "from tdevice inner join tworkorder on tdevice.WO_ID = tworkorder.WO_ID " & Environment.NewLine
                        strsql &= "inner join tcellopt on tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                        strsql &= "inner join lgroups on tcellopt.Cellopt_WIPOwner = lgroups.Group_ID " & Environment.NewLine
                        strsql &= "inner join tmodel on tdevice.model_id = tmodel.model_id " & Environment.NewLine
                        strsql &= "left outer join tpallett on tdevice.pallett_id = tpallett.pallett_id " & Environment.NewLine
                        strsql &= "where  " & Environment.NewLine
                        strsql &= "tdevice.Loc_ID = 2540 and " & Environment.NewLine
                        If iNoPallet = 0 Then
                            strsql &= "tworkorder.WO_RecPalletName = '" & Trim(R1("Bin Location")) & "' and " & Environment.NewLine
                        End If
                        strsql &= "tdevice.Device_OldSN = '" & Trim(R1("Piece Identifier")) & "' order by device_id desc;"

                        objMisc._SQL = strsql
                        dtOldDevice = objMisc.GetDataTable

                        If dtOldDevice.Rows.Count = 0 Then  'WAREHOUSE SECTION
                            '*********************************
                            'Select from twarehousereceive
                            '*********************************
                            strsql = "Select '' as device_oldsn, twarehousereceive.WHR_DateLoaded as DateRec, '' as DateShip, lgroups.Group_Desc, twarehousereceive.WHR_Result as Result, twarehousepallet.WHP_PalletRcvd, tmodel.model_desc, 'twarehousereceive' as pss_table_name, twarehousepallet.WHPallet_Number as RcvdPalletName" & Environment.NewLine
                            strsql &= ", if (Pallett_SendDt is not null, Pallett_SendDt, '') as PallettSentDate " & Environment.NewLine
                            strsql &= ", if (Pallett_Name is not null, Pallett_Name, '') as ShipPalletName " & Environment.NewLine
                            strsql &= "from twarehousepallet  " & Environment.NewLine
                            strsql &= "inner join twarehousereceive on twarehousepallet.WHPallet_ID = twarehousereceive.WHPallet_ID " & Environment.NewLine
                            strsql &= "inner join lgroups on twarehousereceive.WHR_WIPOwner = lgroups.Group_ID " & Environment.NewLine
                            strsql &= "inner join tmodel on twarehousepallet.model_id = tmodel.model_id " & Environment.NewLine
                            strsql &= "LEFT OUTER JOIN tpallett ON twarehousereceive.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine

                            If iNoPallet = 0 Then
                                strsql &= "where WHPallet_Number = '" & Trim(R1("Bin Location")) & "' and (twarehousereceive.whr_box_sn = '" & Trim(R1("Piece Identifier")) & "' or twarehousereceive.WHR_Dev_SN = '" & Trim(R1("Piece Identifier")) & "') " & Environment.NewLine
                            Else
                                strsql &= "where (twarehousereceive.whr_box_sn = '" & Trim(R1("Piece Identifier")) & "' or twarehousereceive.WHR_Dev_SN = '" & Trim(R1("Piece Identifier")) & "') " & Environment.NewLine

                            End If
                            strsql &= "order by whr_id desc;"

                            'dtWHRec = GetDataTable(strsql)
                            objMisc._SQL = strsql
                            dtWHRec = objMisc.GetDataTable

                            If dtWHRec.Rows.Count = 0 Then
                                '*********************************
                                'Select from twarehousepalletload
                                '*********************************
                                strsql = "Select '' as device_oldsn, twarehousepalletload.WHP_DateLoaded as DateRec, '' as DateShip, lgroups.Group_Desc, 0 as Result, twarehousepallet.WHP_PalletRcvd, tmodel.model_desc, 'twarehousepalletload' as pss_table_name, twarehousepallet.WHPallet_Number as RcvdPalletName" & Environment.NewLine
                                strsql &= ", '' as ShipPalletName " & Environment.NewLine
                                strsql &= "from twarehousepallet " & Environment.NewLine
                                strsql &= "inner join twarehousepalletload on twarehousepallet.WHPallet_ID = twarehousepalletload.WHPallet_ID " & Environment.NewLine
                                strsql &= "inner join lgroups on twarehousepalletload.WHP_RcvdFlag = lgroups.Group_ID " & Environment.NewLine
                                strsql &= "inner join tmodel on twarehousepallet.model_id = tmodel.model_id " & Environment.NewLine
                                If iNoPallet = 0 Then
                                    strsql &= "where WHPallet_Number = '" & Trim(R1("Bin Location")) & "' and twarehousepalletload.WHP_PieceIdentifier = '" & Trim(R1("Piece Identifier")) & "' order by whp_id desc;"
                                Else
                                    strsql &= "where twarehousepalletload.WHP_PieceIdentifier = '" & Trim(R1("Piece Identifier")) & "' order by whp_id desc;"
                                End If

                                'dtWHPLoad = GetDataTable(strsql)
                                objMisc._SQL = strsql
                                dtWHPLoad = objMisc.GetDataTable

                                If dtWHPLoad.Rows.Count > 0 Then
                                    R2 = dtWHPLoad.Rows(0)
                                    If Not IsDBNull(R2("DateRec")) Then
                                        If Trim(R2("DateRec")) <> "" Then
                                            strDtRec = Format(CDate(R2("DateRec")), "MM/dd/yyyy HH:mm:ss")
                                        End If
                                    End If
                                    If Not IsDBNull(R2("DateShip")) Then
                                        If Trim(R2("DateShip")) <> "" Then
                                            strDtShip = Format(CDate(R2("DateShip")), "MM/dd/yyyy HH:mm:ss")
                                        End If
                                    End If
                                    If Not IsDBNull(R2("Group_Desc")) Then
                                        strBucket = R2("Group_Desc")
                                    End If
                                    If Not IsDBNull(R2("Result")) Then
                                        iIsDiscrepancy = R2("Result")
                                    End If
                                    If Not IsDBNull(R2("WHP_PalletRcvd")) Then
                                        iPalletRcvdinWIP = R2("WHP_PalletRcvd")
                                    End If
                                    If Not IsDBNull(R2("model_desc")) Then
                                        strModel = R2("model_desc")
                                    End If
                                    If Not IsDBNull(R2("pss_table_name")) Then
                                        strpss_table_name = R2("pss_table_name")
                                    End If
                                    If Not IsDBNull(R2("device_oldsn")) Then
                                        strOldSN = R2("device_oldsn")
                                    End If
                                    If Not IsDBNull(R2("RcvdPalletName")) Then
                                        strRcvdPalletName = R2("RcvdPalletName")
                                    End If
                                    If Not IsDBNull(R2("ShipPalletName")) Then
                                        strShipPalletName = R2("ShipPalletName")
                                    End If
                                End If  'Warehousepalletload
                            Else
                                R2 = dtWHRec.Rows(0)
                                If Not IsDBNull(R2("DateRec")) Then
                                    If Trim(R2("DateRec")) <> "" Then
                                        strDtRec = Format(CDate(R2("DateRec")), "MM/dd/yyyy HH:mm:ss")
                                    End If
                                End If
                                If Not IsDBNull(R2("DateShip")) Then
                                    If Trim(R2("DateShip")) <> "" Then
                                        strDtShip = Format(CDate(R2("DateShip")), "MM/dd/yyyy HH:mm:ss")
                                    End If
                                End If
                                If Not IsDBNull(R2("Group_Desc")) Then
                                    strBucket = R2("Group_Desc")
                                End If
                                If Not IsDBNull(R2("Result")) Then
                                    iIsDiscrepancy = R2("Result")
                                    '***************************************************
                                    'SPECIAL SECTION ADDED FOR DISCREPANCY ON 12/28/2007
                                    '***************************************************
                                    If iIsDiscrepancy = 1 Then
                                        If Not IsDBNull(R2("ShipPalletName")) Then
                                            strShipPalletName = R2("ShipPalletName")
                                        End If
                                        If Not IsDBNull(R2("PallettSentDate")) Then
                                            strDtShip = R2("PallettSentDate")
                                        End If
                                    End If
                                    '***************************************************
                                End If
                                If Not IsDBNull(R2("WHP_PalletRcvd")) Then
                                    iPalletRcvdinWIP = R2("WHP_PalletRcvd")
                                End If
                                If Not IsDBNull(R2("model_desc")) Then
                                    strModel = R2("model_desc")
                                End If
                                If Not IsDBNull(R2("pss_table_name")) Then
                                    strpss_table_name = R2("pss_table_name")
                                End If
                                If Not IsDBNull(R2("device_oldsn")) Then
                                    strOldSN = R2("device_oldsn")
                                End If
                                If Not IsDBNull(R2("RcvdPalletName")) Then
                                    strRcvdPalletName = R2("RcvdPalletName")
                                End If
                            End If  'Warehousereceive
                        Else
                            R2 = dtOldDevice.Rows(0)
                            If Not IsDBNull(R2("device_SN")) Then
                                strSN = Trim(R2("device_sn"))
                            End If
                            If Not IsDBNull(R2("DateRec")) Then
                                If Trim(R2("DateRec")) <> "" Then
                                    strDtRec = Format(CDate(R2("DateRec")), "MM/dd/yyyy HH:mm:ss")
                                End If
                            End If
                            If Not IsDBNull(R2("DateShip")) Then
                                If Trim(R2("DateShip")) <> "" Then
                                    strDtShip = Format(CDate(R2("DateShip")), "MM/dd/yyyy HH:mm:ss")
                                End If
                            End If
                            If Not IsDBNull(R2("Group_Desc")) Then
                                strBucket = R2("Group_Desc")
                            End If
                            If Not IsDBNull(R2("Result")) Then
                                iIsDiscrepancy = R2("Result")
                            End If
                            If Not IsDBNull(R2("WHP_PalletRcvd")) Then
                                iPalletRcvdinWIP = R2("WHP_PalletRcvd")
                            End If
                            If Not IsDBNull(R2("model_desc")) Then
                                strModel = R2("model_desc")
                            End If
                            If Not IsDBNull(R2("pss_table_name")) Then
                                strpss_table_name = R2("pss_table_name")
                            End If
                            If Not IsDBNull(R2("device_oldsn")) Then
                                strOldSN = R2("device_oldsn")
                            End If
                            If Not IsDBNull(R2("RcvdPalletName")) Then
                                strRcvdPalletName = R2("RcvdPalletName")
                            End If
                            If Not IsDBNull(R2("ShipPalletName")) Then
                                strShipPalletName = R2("ShipPalletName")
                            End If
                            '***************************
                        End If  'Device_OldSN
                    Else
                        R2 = dtDevice.Rows(0)
                        If Not IsDBNull(R2("DateRec")) Then
                            If Trim(R2("DateRec")) <> "" Then
                                strDtRec = Format(CDate(R2("DateRec")), "MM/dd/yyyy HH:mm:ss")
                            End If
                        End If
                        If Not IsDBNull(R2("DateShip")) Then
                            If Trim(R2("DateShip")) <> "" Then
                                strDtShip = Format(CDate(R2("DateShip")), "MM/dd/yyyy HH:mm:ss")
                            End If
                        End If
                        If Not IsDBNull(R2("Group_Desc")) Then
                            strBucket = R2("Group_Desc")
                        End If
                        If Not IsDBNull(R2("Result")) Then
                            iIsDiscrepancy = R2("Result")
                        End If
                        If Not IsDBNull(R2("WHP_PalletRcvd")) Then
                            iPalletRcvdinWIP = R2("WHP_PalletRcvd")
                        End If
                        If Not IsDBNull(R2("model_desc")) Then
                            strModel = R2("model_desc")
                        End If
                        If Not IsDBNull(R2("pss_table_name")) Then
                            strpss_table_name = R2("pss_table_name")
                        End If
                        If Not IsDBNull(R2("device_oldsn")) Then
                            strOldSN = R2("device_oldsn")
                        End If
                        If Not IsDBNull(R2("RcvdPalletName")) Then
                            strRcvdPalletName = R2("RcvdPalletName")
                        End If
                        If Not IsDBNull(R2("ShipPalletName")) Then
                            strShipPalletName = R2("ShipPalletName")
                        End If
                    End If  'Tdevice

                    '**************************************************
                    'Write to text file
                    strVar = ""

                    strVar = strSN & "," & _
                                 strOldSN & "," & _
                                 strRcvdPalletName & "," & _
                                 strModel & "," & _
                                 strDtRec & "," & _
                                 strDtShip & "," & _
                                 strBucket & "," & _
                                 strShipPalletName & "," & _
                                 iIsDiscrepancy & "," & _
                                 iPalletRcvdinWIP & "," & _
                                 strpss_table_name

                    PrintLine(1, strVar)
                    '**************************************************
                    strVar = ""
                    strDtRec = ""
                    strDtShip = ""
                    strBucket = ""
                    iIsDiscrepancy = 0
                    iPalletRcvdinWIP = 0
                    strModel = ""
                    strpss_table_name = ""
                    strSN = ""
                    strOldSN = ""
                    strRcvdPalletName = ""
                    strShipPalletName = ""
                Next R1

                MsgBox("A comma delimited text file (C:\ATCLE_ExcelData_Verification.txt) is created. Please open it in excel as a comma delimeted file and save as excel workbook if you want it in excel format.")

                '********************************************************************************************************************

            Catch ex As Exception
                MsgBox(ex.ToString)
            Finally
                Reset()
                If Not IsNothing(DS) Then
                    DS.Dispose()
                    DS = Nothing
                End If
                'If Not IsNothing(dt1) Then
                '    dt1.Dispose()
                '    dt1 = Nothing
                'End If
                If Not IsNothing(objConn) Then
                    objConn.Close()
                    objConn.Dispose()
                    objConn = Nothing
                End If
                If Not IsNothing(objCmdSelect) Then
                    objCmdSelect.Dispose()
                    objCmdSelect = Nothing
                End If
                If Not IsNothing(objAdapter1) Then
                    objAdapter1.Dispose()
                    objAdapter1 = Nothing
                End If

                If Not IsNothing(dtDevice) Then
                    dtDevice.Dispose()
                    dtDevice = Nothing
                End If
                If Not IsNothing(dtWHRec) Then
                    dtWHRec.Dispose()
                    dtWHRec = Nothing
                End If
                If Not IsNothing(dtWHPLoad) Then
                    dtWHPLoad.Dispose()
                    dtWHPLoad = Nothing
                End If

                'Invoke Garbage Collector
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        Public Function GetWHDiscrepacyInfo(ByVal strDisIMEI As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT if (WHR_Box_SN is not null, WHR_Box_SN, '') as BoxSN, " & Environment.NewLine
                strSql &= "if (WHR_Dev_SN is not null, WHR_Dev_SN, '') as DevSN, " & Environment.NewLine
                strSql &= "if (WHPallet_Number is not null, WHPallet_Number, '') as WHPallet_Name, " & Environment.NewLine
                strSql &= "if (Pallett_Name is not null, Pallett_Name, '') as DisRptName, " & Environment.NewLine
                strSql &= "if (Pallett_SendDt is not null, Pallett_SendDt, '') as SentDate, " & Environment.NewLine
                strSql &= "if (WHR_BoxSN_Absent_in_File = 1, 'X', '') as BoxSN_Absent_in_File, " & Environment.NewLine
                strSql &= "if (WHR_DevSN_BoxSN_Different  = 1, 'X', '') as DevSN_BoxSN_Different,  " & Environment.NewLine
                strSql &= "if (WHR_DevSN_Absent_in_File = 1, 'X', '') as DevSN_Absent_in_File ,  " & Environment.NewLine
                strSql &= "if (WHR_Box_Empty = 1, 'X', '') as Box_Empty,  " & Environment.NewLine
                strSql &= "if (WHR_WrongSKU = 1, 'X', '') as WrongSKU,  " & Environment.NewLine
                strSql &= "if (WHR_InFile_NotOnPallet = 1, 'X', '')  as InFile_NotOnPallet,  " & Environment.NewLine
                strSql &= "if (WHR_DupInFile = 1, 'X', '') as DuplnFile,  " & Environment.NewLine
                strSql &= "if (WHR_Mutltiple_Phones_In_Box = 1, 'X', '') as Multiple_Phones_In_Box " & Environment.NewLine
                strSql &= "FROM twarehousereceive  " & Environment.NewLine
                strSql &= "INNER JOIN twarehousepallet ON twarehousereceive.WHPallet_ID = twarehousepallet.WHPallet_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett ON twarehousereceive.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE (WHR_Box_SN = '" & strDisIMEI & "' OR WHR_Dev_SN = '" & strDisIMEI & "' ) " & Environment.NewLine
                strSql &= "AND WHR_Result = 1;"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************
        Public Function CreateWIPSummaryRpt(ByVal iProd_ID As Integer, _
                                       ByVal iCust_ID As Integer, _
                                       ByVal iModel_ID As Integer, _
                                       ByVal dtWIPCutoffDate As Date) As Integer
            Dim strSql As String
            Dim dtWip, dtCostCenter, dtData, dtReportData As DataTable
            Dim R1, R2, R3, drArrUpdGBUnits() As DataRow
            Dim i As Integer = 0

            Try
                '*************************
                'Create Report datatable
                '*************************
                dtReportData = New DataTable()
                If iModel_ID > 0 Then Generic.AddNewColumnToDataTable(dtReportData, "Model", "System.String", "")
                Generic.AddNewColumnToDataTable(dtReportData, "Bucket", "System.String", "")
                Generic.AddNewColumnToDataTable(dtReportData, "Quantity", "System.Int32", "0")

                '*************************
                'Get Data
                '*************************
                strSql = "SELECT Distinct tdevice.Device_ID, tdevice.cc_ID, Model_Desc " & Environment.NewLine
                strSql &= ", if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as cc_desc " & Environment.NewLine
                'strSql &= ", 0 as PassFailUnit " & Environment.NewLine
                strSql &= ", if( lwipowner.wipowner_id is null or  lwipowner.wipowner_id <> 5, 0, " & Environment.NewLine
                strSql &= "(CASE WHEN tdevice.Loc_ID = 19 THEN if((ship_id is null or ship_id <> 9999919 ), 0, 1)" & Environment.NewLine
                strSql &= "WHEN (lwipowner.wipowner_id = 5 and tdevice.Loc_ID <> 19 ) THEN if((Pallet_ShipType is null or Pallet_shipType not in (1,2,8,9) ), 0, 1)" & Environment.NewLine
                strSql &= "ELSE 0 END) " & Environment.NewLine
                strSql &= ") AS 'PassFailUnit'" & Environment.NewLine
                strSql &= ", if(lwipowner.wipowner_id is null, 0, lwipowner.wipowner_id ) as wipowner_id " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                If iCust_ID <> 0 Then
                    strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                End If
                If iProd_ID = 1 Then
                    strSql &= "INNER JOIN tmessdata ON tdevice.Device_ID = tmessdata.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lwipowner ON tmessdata.wipowner_id = lwipowner.wipowner_id " & Environment.NewLine
                Else
                    strSql &= "LEFT OUTER JOIN tcellopt ON tdevice.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN lwipowner ON tcellopt.Cellopt_WIPOwner = lwipowner.wipowner_id " & Environment.NewLine
                End If
                strSql &= "LEFT OUTER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE tmodel.Prod_ID = " & iProd_ID & " " & Environment.NewLine
                strSql &= "AND tdevice.Device_DateRec <= '" & Format(dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "' " & Environment.NewLine
                If iCust_ID <> 0 Then
                    strSql &= "AND tlocation.Cust_ID = " & iCust_ID & " " & Environment.NewLine
                End If
                If iModel_ID <> 0 Then
                    strSql &= "AND tdevice.Model_ID = " & iModel_ID & " " & Environment.NewLine
                End If
                strSql &= "AND ( Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = ''  " & Environment.NewLine
                If iProd_ID = 1 Then
                    strSql &= "OR (Device_DateShip is not null and tmessdata.wipowner_id = <> 7 ) )  " & Environment.NewLine
                Else
                    strSql &= "OR (Device_DateShip is not null and tcellopt.Cellopt_WIPOwner <> 7 ) )  " & Environment.NewLine
                End If

                Me.objMisc._SQL = strSql
                dtData = Me.objMisc.GetDataTable

                If dtData.Rows.Count > 0 Then

                    '*************************
                    'Get Wipowner buckets
                    '*************************
                    strSql = "SELECT * FROM lwipowner WHERE wipowner_id <> 7 order by wipowner_id;"
                    Me.objMisc._SQL = strSql
                    dtWip = Me.objMisc.GetDataTable

                    '*************************
                    'Get distinct costcenter
                    '*************************
                    strSql = "SELECT Distinct tdevice.cc_ID, if(tcostcenter.cc_desc is null, '', tcostcenter.cc_desc ) as cc_desc " & Environment.NewLine
                    strSql &= "FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    If iCust_ID <> 0 Then
                        strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                    End If
                    strSql &= "LEFT OUTER JOIN tcostcenter ON tdevice.cc_id = tcostcenter.cc_id " & Environment.NewLine
                    strSql &= "WHERE tmodel.Prod_ID = " & iProd_ID & " " & Environment.NewLine
                    strSql &= "AND tdevice.Device_DateRec <= '" & Format(dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "' " & Environment.NewLine
                    If iCust_ID <> 0 Then
                        strSql &= "AND tlocation.Cust_ID = " & iCust_ID & " " & Environment.NewLine
                    End If
                    If iModel_ID <> 0 Then
                        strSql &= "AND tdevice.Model_ID = " & iModel_ID & " " & Environment.NewLine
                    End If
                    strSql &= "AND ( Device_DateShip is null or Device_DateShip = '0000-00-00 00:00:00' or Device_DateShip = '')  " & Environment.NewLine
                    strSql &= "ORDER BY cc_desc"
                    Me.objMisc._SQL = strSql
                    dtCostCenter = Me.objMisc.GetDataTable

                    ''**********************************
                    ''Define good and bad of units
                    ''**********************************
                    'drArrUpdGBUnits = dtData.Select("wipowner_id = 5", "")
                    'For i = 0 To drArrUpdGBUnits.Length - 1
                    '    drArrUpdGBUnits(i).BeginEdit()
                    '    strSql = "SELECT distinct if(lbillcodes.BillCode_Rule in (1,2,8,9), 1, 0) as BillCode_Rule " & Environment.NewLine
                    '    strSql &= "FROM tdevicebill " & Environment.NewLine
                    '    strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                    '    strSql &= "WHERE tdevicebill.Device_ID = " & drArrUpdGBUnits(i)("Device_ID") & " " & Environment.NewLine
                    '    drArrUpdGBUnits(i)("PassFailUnit") = Me.objMisc.GetIntValue(strSql)
                    '    drArrUpdGBUnits(i).EndEdit()
                    'Next i
                    'dtData.AcceptChanges()

                    '**********************************
                    'Summary quantity by bucket
                    '**********************************
                    For Each R1 In dtWip.Rows
                        If R1("wipowner_id") = 3 Then
                            For Each R3 In dtCostCenter.Rows
                                If dtData.Select("wipowner_id = 3 AND cc_ID = " & R3("cc_ID")).Length > 0 Then
                                    R2 = dtReportData.NewRow
                                    If iModel_ID > 0 Then R2("Model") = dtData.Rows(0)("Model_Desc")
                                    R2("Bucket") = R1("wipowner_desc") & "-" & R3("cc_desc")
                                    R2("Quantity") = dtData.Select("wipowner_id = 3 AND cc_ID = " & R3("cc_ID")).Length
                                    dtReportData.Rows.Add(R2)
                                    dtReportData.AcceptChanges()
                                    R2 = Nothing
                                End If
                            Next R3
                        ElseIf R1("wipowner_id") = 5 Then
                            R2 = dtReportData.NewRow
                            If iModel_ID > 0 Then R2("Model") = dtData.Rows(0)("Model_Desc")
                            R2("Bucket") = R1("wipowner_desc") & "- Good Units"
                            R2("Quantity") = dtData.Select("wipowner_id = 5 AND PassFailUnit = 0").Length
                            dtReportData.Rows.Add(R2)
                            dtReportData.AcceptChanges()
                            R2 = Nothing

                            R2 = dtReportData.NewRow
                            If iModel_ID > 0 Then R2("Model") = dtData.Rows(0)("Model_Desc")
                            R2("Bucket") = R1("wipowner_desc") & "- Bad Units"
                            R2("Quantity") = dtData.Select("wipowner_id = 5 AND PassFailUnit <> 0").Length
                            dtReportData.Rows.Add(R2)
                            dtReportData.AcceptChanges()
                            R2 = Nothing
                        Else
                            R2 = dtReportData.NewRow
                            If iModel_ID > 0 Then R2("Model") = dtData.Rows(0)("Model_Desc")
                            R2("Bucket") = R1("wipowner_desc")
                            R2("Quantity") = dtData.Select("wipowner_id = " & R1("wipowner_id")).Length
                            dtReportData.Rows.Add(R2)
                            dtReportData.AcceptChanges()
                            R2 = Nothing
                        End If
                    Next R1

                    'old wip
                    If dtData.Select("wipowner_id = 0").Length > 0 Then
                        R2 = dtReportData.NewRow
                        If iModel_ID > 0 Then R2("Model") = dtData.Rows(0)("Model_Desc")
                        R2("Bucket") = "Old Bucket"
                        R2("Quantity") = dtData.Select("wipowner_id = 0").Length
                        dtReportData.Rows.Add(R2)
                        dtReportData.AcceptChanges()
                        R2 = Nothing
                    End If

                    'Total
                    R2 = dtReportData.NewRow
                    R2("Bucket") = "Total"
                    R2("Quantity") = dtReportData.Compute("sum(Quantity)", "")
                    dtReportData.Rows.Add(R2)
                    dtReportData.AcceptChanges()
                    R2 = Nothing

                    '**********************************
                    'Populate report to excel
                    '**********************************
                    If dtReportData.Rows.Count > 0 Then
                        If iModel_ID > 0 Then
                            Generic.CreateExelReport(dtReportData, 1, , 1, , , , "C")
                        Else
                            Generic.CreateExelReport(dtReportData, 1, , 1, , , , "B")
                        End If
                    End If
                    '**********************************
                End If

                Return dtReportData.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                drArrUpdGBUnits = Nothing
                R1 = Nothing
                R2 = Nothing
                R3 = Nothing
                If Not IsNothing(dtWip) Then
                    dtWip.Dispose()
                    dtWip = Nothing
                End If
                If Not IsNothing(dtData) Then
                    dtData.Dispose()
                    dtData = Nothing
                End If
                If Not IsNothing(dtReportData) Then
                    dtReportData.Dispose()
                    dtReportData = Nothing
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '*********************************************************************
        Public Function GetCelloptWIPDetailData(ByVal iProd_ID As Integer, _
                                                ByVal iCust_ID As Integer, _
                                                ByVal iModel_ID As Integer, _
                                                ByVal dtWIPCutoffDate As Date) As DataTable
            Dim strSql As String

            Try
                strSql &= "SELECT E.WO_CustWO AS 'Work Order' " & Environment.NewLine
                'strSql &= ", CONCAT(if(I.wipowner_desc is null, 'Old Bucket', I.wipowner_desc), (CASE WHEN I.wipowner_id = 3 THEN CONCAT(' ', K.cc_desc) ELSE '' END)) AS 'Location' " & Environment.NewLine
                strSql &= ", CONCAT(" & Environment.NewLine
                strSql &= "if( I.wipowner_desc is null, 'Old Bucket', I.wipowner_desc) , " & Environment.NewLine
                strSql &= "(CASE WHEN I.wipowner_id = 3 THEN if(cc_desc is null, '', CONCAT(' ', cc_desc) ) " & Environment.NewLine
                strSql &= "WHEN (I.wipowner_id = 5 and A.Loc_ID = 19 ) THEN if((ship_id is null or ship_id <> 9999919 ), ' Good Unit', ' Bad Unit') " & Environment.NewLine
                strSql &= "WHEN (I.wipowner_id = 5 and A.Loc_ID <> 19 ) THEN if((Pallet_ShipType is null or Pallet_shipType not in (1,2,8,9) ), ' Good Unit', ' Bad Unit') " & Environment.NewLine
                strSql &= "Else '' END) " & Environment.NewLine
                strSql &= ") AS 'Location'" & Environment.NewLine
                strSql &= ", CAST(A.Tray_ID AS CHAR) AS 'Tray ID' " & Environment.NewLine
                strSql &= ", C.Model_Desc AS 'Model Desc' " & Environment.NewLine
                strSql &= ", A.Device_SN AS 'Device SN' " & Environment.NewLine
                strSql &= ", if(A.Device_ManufWrty = 1, 'IW', 'OW') AS 'Manuf Wrty' " & Environment.NewLine
                'strSql &= ", CONCAT('*', A.Device_SN, '*') AS 'Device SN Barcode' " & Environment.NewLine
                'strSql &= ", IFNULL(A.Device_OldSN, '') AS 'Old Device SN' " & Environment.NewLine
                strSql &= ", IF( A.Device_DateRec IS NULL , '' , A.Device_DateRec) AS 'Receive Date' " & Environment.NewLine
                strSql &= ", IF( A.Device_DateBill IS NULL , '' , A.Device_DateBill) AS 'Bill Date' " & Environment.NewLine
                strSql &= ", IF( A.Device_DateShip IS NULL , '', A.Device_DateShip) AS 'Prod Completed Date' " & Environment.NewLine
                strSql &= ", TO_DAYS(now()) - TO_DAYS(A.Device_DateRec) AS 'Days In WIP'" & Environment.NewLine
                strSql &= ", TO_DAYS(now()) - TO_DAYS(H.Cellopt_WIPEntryDt) AS 'Days In WIP For Location'" & Environment.NewLine
                strSql &= ", IF( L.Pallett_Name IS NULL , '' , L.Pallett_Name) AS 'Box/Pallet Name' " & Environment.NewLine
                strSql &= "FROM production.tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN production.tlocation B ON B.Loc_ID = A.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tmodel C ON C.Model_ID = A.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.lproduct D ON D.Prod_ID = C.Prod_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tworkorder E ON E.WO_ID = A.WO_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.tcustomer F ON F.Cust_ID = B.Cust_ID " & Environment.NewLine
                strSql &= "INNER JOIN production.lparentco G ON G.PCo_ID = F.PCo_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.tcellopt H ON A.Device_ID = H.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.lwipowner I ON H.Cellopt_WIPOwner = I.wipowner_id " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.tcostcenter K ON K.cc_id = A.cc_id" & Environment.NewLine
                strSql &= "LEFT OUTER JOIN production.tpallett L ON A.Pallett_ID = L.Pallett_ID " & Environment.NewLine
                strSql &= "WHERE C.Prod_ID = " & iProd_ID & " " & Environment.NewLine
                strSql &= "AND A.Device_DateRec <= '" & Format(dtWIPCutoffDate.AddDays(1), "yyyy-MM-dd 06:00:00") & "' " & Environment.NewLine
                If iCust_ID <> 0 Then strSql &= "AND B.Cust_ID  = " & iCust_ID & " " & Environment.NewLine
                If iModel_ID <> 0 Then strSql &= "AND A.Model_ID  = " & iModel_ID & " " & Environment.NewLine
                strSql &= "AND (A.Device_DateShip IS NULL OR (A.Device_DateShip is not null AND H.Cellopt_WIPOwner <> 7 ) ) " & Environment.NewLine
                strSql &= "ORDER BY 'Days In WIP' DESC, 'Work Order'"

                Me.objMisc._SQL = strSql
                Return Me.objMisc.GetDataTable()

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************************


    End Class
End Namespace