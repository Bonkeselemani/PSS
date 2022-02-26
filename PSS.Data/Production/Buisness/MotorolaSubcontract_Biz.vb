'Imports PSS.Data.Production
'Imports eInfoDesigns.dbProvider.MySqlClient
Imports System.Text

Namespace Buisness
    Public Class MotorolaSubcontract_Biz

        Private objMotoSubcontract_Data As PSS.Data.Production.MotorolaSubcontract_Data
        Private objMyLib As MyLib.Utility
        '****************************************************************************
        'Create Pallet Report
        '****************************************************************************
        Public Function CreatePalletReport(ByVal iPalletID As Integer) As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                dt1 = objMotoSubcontract_Data.CreatePalletReport(iPalletID)

                For Each R1 In dt1.Rows

                Next R1

            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.CreatePalletReport: " & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    If Not IsDBNull(dt1) Then
                        dt1.Dispose()
                    End If
                    dt1 = Nothing
                End If
            End Try

        End Function

        '****************************************************************************
        'Get DeviceInfo by Device_ID
        '****************************************************************************
        Public Function GetDeviceInfo(ByVal iDevice_ID As Integer) As DataTable
            Dim dt As New DataTable()
            'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
            Try
                dt = objMotoSubcontract_Data.GetDeviceInfo(iDevice_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetDeviceInfo: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '****************************************************************************
        'Checks if the device is being RTMd
        '****************************************************************************
        Public Function IsDeviceRTM(ByVal iDevice_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.IsDeviceRTM(iDevice_ID)

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.IsDeviceRTM: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '****************************************************************************
        'Load Reconciliation Parts data
        '****************************************************************************
        Public Function LoadClaimReconciliationPartData(ByVal iBatchNumber As Integer, _
                                                        ByVal iQnty As Integer, _
                                                        ByVal strPrtNum As String) As Integer

            Dim i As Integer = 0

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.LoadClaimReconciliationPartData(iBatchNumber, iQnty, strPrtNum)
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.LoadClaimReconciliationPartData: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try

        End Function

        '****************************************************************************
        'Checks if the batch already exists for parts
        '****************************************************************************
        Public Function CheckifBatchExistsForParts(ByVal iBatchNumber As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.CheckifBatchExistsForParts(iBatchNumber)

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.CheckifBatchExistsForParts: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '****************************************************************************
        'Update Reconciliation Ststus in tcellopt table
        '****************************************************************************
        Public Function UpdateReconciliationStatus(ByVal iClaimNo As Integer, _
                                                    ByVal iAccptedRejectedClaims As Integer) As Integer

            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Dim iCurrentReconStatus As Integer

            Dim i As Integer = 0

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()

                If iAccptedRejectedClaims = 2 Then
                    dt1 = objMotoSubcontract_Data.GetReconciliationStatus(iClaimNo)

                    For Each R1 In dt1.Rows
                        iCurrentReconStatus = R1("Cellopt_ReconStatus")
                    Next R1

                    If iCurrentReconStatus = 1 Then         'Once accepted always accepted and no matter how many times it is rejected after that it will stay accepted
                        iAccptedRejectedClaims = 1
                    ElseIf iCurrentReconStatus = 2 Then     'Means Claim got rejected twice
                        iAccptedRejectedClaims = 3          'Set the device ready to be written off
                    ElseIf iCurrentReconStatus = 3 Then     'If it is set to write off i.e value 3 then it stays the same until it is set to 4 by Accounting/Finance
                        iAccptedRejectedClaims = 3
                    End If
                End If

                i = objMotoSubcontract_Data.UpdateReconciliationStatus(iClaimNo, iAccptedRejectedClaims)
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.UpdateReconciliationStatus: " & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    If Not IsDBNull(dt1) Then
                        dt1.Dispose()
                    End If
                    dt1 = Nothing
                End If
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '****************************************************************************
        'Loads the Claim Reconciliation Data
        '****************************************************************************
        Public Function LoadClaimReconciliationData(ByVal strBatchDate As String, _
                                                    ByVal iBatchNumber As Integer, _
                                                    ByVal iAccptedRejectedClaims As Integer, _
                                                    ByVal strWrty As String, _
                                                    ByVal decFixedRate As Decimal, _
                                                    ByVal decPartPrice As Decimal, _
                                                    ByVal decClaimDiscAmt As Decimal, _
                                                    ByVal decConsDiscAmt As Decimal, _
                                                    ByVal decTotalPaid As Decimal, _
                                                    ByVal strRejectMsg As String, _
                                                    ByVal iClaimNo As Integer) As Integer

            Dim i As Integer = 0

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.LoadClaimReconciliationData(strBatchDate, _
                                                                        iBatchNumber, _
                                                                        iAccptedRejectedClaims, _
                                                                        strWrty, decFixedRate, _
                                                                        decPartPrice, _
                                                                        decClaimDiscAmt, _
                                                                        decConsDiscAmt, _
                                                                        decTotalPaid, _
                                                                        strRejectMsg, _
                                                                        iClaimNo)
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.LoadClaimReconciliationData: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try


        End Function



        '****************************************************************************
        'Checks if the batch already exists
        '****************************************************************************
        Public Function CheckifBatchExists(ByVal iBatchNumber As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.CheckifBatchExists(iBatchNumber)

                Return dt
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.CheckifBatchExists: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '****************************************************************************
        'Retrieves Label info for a given location of a customer.
        '****************************************************************************
        Public Function GetLabelInfo(ByVal iLoc_ID As Integer, _
                                    ByVal iProcessType As Integer) As DataTable
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt1 = objMotoSubcontract_Data.GetLabelInfo(iLoc_ID, iProcessType)

                For Each R1 In dt1.Rows
                    R1.BeginEdit()

                    'Get Coffin Label Printer Name
                    If Not IsDBNull(R1("LocMap_CoffinPrinter_ID")) Then
                        If R1("LocMap_CoffinPrinter_ID") <> 0 Then
                            R1("CoffinLabelPrinter") = Me.GetPrinterName(R1("LocMap_CoffinPrinter_ID"))
                        End If
                    End If
                    'Get Masterpack Label Printer Name
                    If Not IsDBNull(R1("LocMap_MasterLblPrinter_ID")) Then
                        If R1("LocMap_MasterLblPrinter_ID") <> 0 Then
                            R1("MasterLabelPrinter") = Me.GetPrinterName(R1("LocMap_MasterLblPrinter_ID"))
                        End If
                    End If


                    'Get Overpack Label Printer Name
                    If Not IsDBNull(R1("LocMap_OverLblPrinter_ID")) Then
                        If R1("LocMap_OverLblPrinter_ID") <> 0 Then
                            R1("OverpackLabelPrinter") = Me.GetPrinterName(R1("LocMap_OverLblPrinter_ID"))
                        End If
                    End If


                    'Get Pallett Label Printer Name
                    If Not IsDBNull(R1("LocMap_PallettLblPrinter_ID")) Then
                        If R1("LocMap_PallettLblPrinter_ID") <> 0 Then
                            R1("PallettLabelPrinter") = Me.GetPrinterName(R1("LocMap_PallettLblPrinter_ID"))
                        End If
                    End If

                    R1.EndEdit()
                Next R1

                Return dt1
            Catch ex As Exception
                If Not IsNothing(dt1) Then
                    If Not IsDBNull(dt1) Then
                        dt1.Dispose()
                    End If
                    dt1 = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetLabelInfo: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '****************************************************************************
        'Gets Printer Name
        '****************************************************************************
        Public Function GetPrinterName(ByVal iPrinter_ID As Integer) As String
            Dim dt2 As DataTable
            Dim R2 As DataRow
            Dim strPrinterName As String

            Try
                dt2 = objMotoSubcontract_Data.GetPrinterName(iPrinter_ID)

                For Each R2 In dt2.Rows
                    strPrinterName = Trim(R2("Printer_Desc"))
                Next R2

                Return strPrinterName
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.GetPrinterName: " & ex.Message.ToString)
            Finally
                R2 = Nothing
                If Not IsNothing(dt2) Then
                    If Not IsDBNull(dt2) Then
                        dt2.Dispose()
                    End If
                    dt2 = Nothing
                End If
            End Try
        End Function

        '****************************************************************************
        'Get Device_SN by cellopt_OutIMEI
        '****************************************************************************
        Public Function GetDeviceSNByIMEINo(ByVal strIMEIOut As String) As DataTable

            Dim dt As DataTable
            'Dim myDataRow As DataRow
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetDeviceSNByIMEINo(strIMEIOut)

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetDeviceSNByIMEINo: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '****************************************************************************
        'Get Locations For Customer
        '****************************************************************************
        Public Function GetLocationsForCustomer(ByVal iCust_ID As Integer) As DataTable
            Dim dt As DataTable
            Dim myDataRow As DataRow
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetLocationsForCustomer(iCust_ID)

                'Insert an empty row into the datatable
                myDataRow = dt.NewRow
                myDataRow("Loc_ID") = 0
                myDataRow("Loc_Name") = ""
                dt.Rows.Add(myDataRow)
                myDataRow = Nothing

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetLocationsForCustomer: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function



        '***************************************************
        'Update Device table
        'Note: This method is not being used anywhere as of 07/29/2004
        '***************************************************
        Public Function SetDeviceSendClaimFlag(ByVal strDeviceIDs As String) As Integer
            Dim i As Integer = 0

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.SetDeviceSendClaimFlag(strDeviceIDs)    'update device table
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.SetDeviceSendClaimFlag: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '*********************************************************************************
        Public Function GetMotorolaWIPDetailInfo(ByVal strDeviceIDs As String, _
                                                ByVal strMascCode As String) As DataTable

            Dim dt1 As DataTable
            Dim dt2 As DataTable

            '****************************************************************************************************
            'Claim Detail
            '********************************************************************

            Try
                'Part 1
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt1 = objMotoSubcontract_Data.GetMotorolaWIPDetail1(strDeviceIDs, strMascCode)

                'Part 2
                dt2 = objMotoSubcontract_Data.GetMotorolaWIPDetail2(strDeviceIDs)
                Return ConsolidateWIPDetailInfo(dt1, dt2)

            Catch ex As Exception

                Throw ex
            Finally

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                End If
                dt1 = Nothing

                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                End If
                dt2 = Nothing

                'objMotoSubcontract_Data = Nothing
            End Try

        End Function

        '*********************************************************************************

        Public Function GetMotorolaWIPInfo(ByVal strDeviceIDs As String) As DataTable

            Dim dt1 As DataTable
            Dim dt2 As DataTable

            '******************************************************************
            'Claim Information
            '******************************************************************
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()

                'Part 1
                dt1 = objMotoSubcontract_Data.GetMotorolaWIPInfo1(strDeviceIDs)
                'Part 2
                dt2 = objMotoSubcontract_Data.GetMotorolaWIPInfo2(strDeviceIDs)

                Return ConsolidateWIPInfo(dt1, dt2)

            Catch ex As Exception

                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                End If
                dt1 = Nothing

                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                End If
                dt2 = Nothing

                'objMotoSubcontract_Data = Nothing
            End Try

            '****************************************************************************************************
        End Function

        '****************************************************************************
        'This method consolidates the two data tables in to one final table to output
        '****************************************************************************
        Private Function ConsolidateWIPInfo(ByVal T1 As DataTable, ByVal T2 As DataTable) As DataTable
            Dim R1, R2, R3, R4 As DataRow
            Dim iFlagCarrier As Integer = 0
            Dim iFlagTansaction As Integer = 0
            Dim iFlagAPC As Integer = 0
            Dim iFlagComplaint As Integer = 0
            Dim iFlagProblemFound As Integer = 0
            Dim iFlagRepair As Integer = 0
            Dim iFlagRepairStatus As Integer = 0
            Dim dtRMANum As DataTable
            Dim dt, dt1, dt2 As DataTable
            Dim strHigh_Level_PF As String = ""
            Dim strHigh_Level_RA As String = ""
            'Dim iDevIDASIF As Integer

            Try
                'objMyLib = New MyLib.Utility()

                For Each R1 In T1.Rows
                    'iDevIDASIF = R1("WarrantyClaim")
                    'If iDevIDASIF = 4278415 Then
                    '    MsgBox(iDevIDASIF)
                    'End If

                    '*****************************************************************
                    'Get the Highest Labor level Rep Action and Prob Found
                    '*****************************************************************
                    Try
                        dt = objMotoSubcontract_Data.HighestLevel_ProbFound_RepAction(R1("WarrantyClaim"))

                        For Each R3 In dt.Rows
                            '***************************
                            'Problem Found
                            If Not IsDBNull(R3("wmap_problemfound")) Then
                                dt1 = objMotoSubcontract_Data.GetCodeDescription(R3("wmap_problemfound"))
                                For Each R4 In dt1.Rows
                                    If Not IsDBNull(R4("Dcode_SDesc")) Then
                                        strHigh_Level_PF = Trim(R4("Dcode_SDesc"))
                                    End If
                                Next R4
                                R4 = Nothing
                                If Not IsNothing(dt1) Then
                                    dt1.Dispose()
                                    dt1 = Nothing
                                End If
                            End If
                            '***************************
                            'Repair Action
                            If Not IsDBNull(R3("wmap_repairaction")) Then
                                dt2 = objMotoSubcontract_Data.GetCodeDescription(R3("wmap_repairaction"))
                                For Each R4 In dt2.Rows
                                    If Not IsDBNull(R4("Dcode_SDesc")) Then
                                        strHigh_Level_RA = Trim(R4("Dcode_SDesc"))
                                    End If
                                Next R4
                                R4 = Nothing
                                If Not IsNothing(dt2) Then
                                    dt2.Dispose()
                                    dt2 = Nothing
                                End If
                            End If
                            '***************************
                            Exit For
                        Next R3

                    Catch ex As Exception
                        'MsgBox(iDevIDASIF & "::::::" & ex.Message)
                        Throw ex
                    Finally
                        R3 = Nothing
                        R4 = Nothing
                        If Not IsNothing(dt) Then
                            dt.Dispose()
                            dt = Nothing
                        End If
                        If Not IsNothing(dt1) Then
                            dt1.Dispose()
                            dt1 = Nothing
                        End If
                        If Not IsNothing(dt2) Then
                            dt2.Dispose()
                            dt2 = Nothing
                        End If
                    End Try
                    '*****************************************************************

                    R1.BeginEdit()

                    'Calculate RepairTime and RepairCycleTime
                    If Not IsDBNull(R1("DateReceived")) And Not IsDBNull(R1("DateShipped")) Then
                        If (R1("DateReceived") <> "") And (R1("DateShipped") <> "") Then
                            R1("RepairTime") = objMyLib.MinsToDaysHoursMins(DateDiff(DateInterval.Minute, R1("DateReceived"), R1("DateShipped")))
                            R1("RepairCycleTime") = R1("RepairTime")
                        End If
                    End If

                    'Update the "Date Received"
                    If Not IsDBNull(R1("DateReceived")) Then
                        If R1("DateReceived") <> "" Then
                            R1("DateReceived") = objMyLib.FormatDate_DDMMYYYY(R1("DateReceived"))
                        End If
                    End If

                    'Calculate the "TimeShipped" from "DateShipped"
                    If Not IsDBNull(R1("DateShipped")) Then
                        If R1("DateShipped") <> "" Then
                            R1("TimeShipped") = FormatDateTime(R1("DateShipped"), DateFormat.ShortTime)
                            R1("DateShipped") = objMyLib.FormatDate_DDMMYYYY(R1("DateShipped"))
                        End If
                    End If

                    'Update the "Date Repaired"
                    If Not IsDBNull(R1("ReapairDate")) Then
                        If R1("ReapairDate") <> "" Then
                            R1("ReapairDate") = objMyLib.FormatDate_DDMMYYYY(R1("ReapairDate"))
                        End If
                    End If

                    'Update "POPWarrantyClaim" field of T1, 'Update "Date of Purchase"
                    If Not IsDBNull(R1("DateofPurchase")) Then
                        If R1("DateofPurchase") <> "" Then
                            R1("DateofPurchase") = objMyLib.FormatDate_DDMMYYYY(R1("DateofPurchase"))
                            R1("POPWarrantyClaim") = "Y"
                        Else
                            R1("POPWarrantyClaim") = "N"
                        End If
                    End If

                    'Update the Airtime
                    If R1("Airtime") <> "" Then
                        R1("Airtime") = objMyLib.JustifyAndPadString(R1("Airtime"), "0", 1, 20)
                    End If

                    'Update IncomingESNorCSN
                    If R1("IncomingESNorCSN") = "" Then
                        If R1("DeviceSerialNumber") <> "" Then
                            R1("IncomingESNorCSN") = R1("DeviceSerialNumber")
                        End If
                    End If

                    'Update OutgoingESNorCSN
                    If R1("OutgoingESNorCSN") = "" Then
                        If R1("DeviceSerialNumber") <> "" Then
                            R1("OutgoingESNorCSN") = R1("DeviceSerialNumber")
                        End If
                    End If

                    'Check if it is an IMEI phone
                    If R1("IncomingIMEI") <> "" Then
                        R1("IncomingESNorCSN") = ""
                        R1("OutgoingESNorCSN") = ""
                    Else
                        R1("OutgoingIMEI") = ""
                        R1("OutgoingMSN") = ""
                        R1("IncomingMSN") = ""
                    End If

                    '********************************************
                    'Get the Customer Reference Number
                    '********************************************
                    Try
                        dtRMANum = objMotoSubcontract_Data.GetOutgoingRMANumber(R1("WO_ID_Out"))

                        'WO_CustWO
                        For Each R3 In dtRMANum.Rows    'There is only one row
                            R1("CustRefNum") = R3("WO_CustWO")
                            Exit For
                        Next
                    Catch ex As Exception
                        Throw ex
                    Finally
                        If Not IsNothing(dtRMANum) Then
                            dtRMANum.Dispose()
                        End If
                        dtRMANum = Nothing
                    End Try




                    '********************************************
                    For Each R2 In T2.Rows

                        If R2("Device_ID") = R1("WarrantyClaim") Then

                            Select Case Trim(R2("Mcode_Desc"))
                                Case "Carrier"
                                    If iFlagCarrier = 0 Then
                                        R1("AirtimeCarCode") = Left(R2("Dcode_Sdesc"), 6)
                                        iFlagCarrier = 1
                                    End If
                                Case "Transaction"
                                    If iFlagTansaction = 0 Then
                                        R1("TransactionCode") = Left(R2("Dcode_Sdesc"), 3)
                                        iFlagTansaction = 1
                                    End If
                                Case "APC"
                                    If iFlagAPC = 0 Then
                                        R1("Product_APCcode") = Left(R2("Dcode_Sdesc"), 4)
                                        iFlagAPC = 1
                                    End If
                                Case "Complaint"
                                    If iFlagComplaint = 0 Then
                                        R1("CustomerComplaint") = Left(R2("Dcode_Sdesc"), 8)
                                        iFlagComplaint = 1
                                    End If
                                Case "Problem Found"
                                    'If iFlagProblemFound = 0 Then
                                    '    R1("PrimaryProbFoundCode") = Left(R2("Dcode_Sdesc"), 8)
                                    '    iFlagProblemFound = 1
                                    'End If

                                    If iFlagProblemFound = 0 Then

                                        If strHigh_Level_PF = "" Then
                                            R1("PrimaryProbFoundCode") = Left(R2("Dcode_Sdesc"), 8)
                                        Else
                                            R1("PrimaryProbFoundCode") = strHigh_Level_PF
                                        End If

                                        iFlagProblemFound = 1
                                    End If

                                Case "Repair"
                                    'If iFlagRepair = 0 Then
                                    '    R1("PrimaryRepairAction") = Left(R2("Dcode_Sdesc"), 8)
                                    '    iFlagRepair = 1
                                    'End If

                                    If iFlagRepair = 0 Then

                                        If strHigh_Level_RA = "" Then
                                            R1("PrimaryRepairAction") = Left(R2("Dcode_Sdesc"), 8)
                                        Else
                                            R1("PrimaryRepairAction") = strHigh_Level_RA
                                        End If

                                        iFlagRepair = 1
                                    End If

                                Case "Repair Status"
                                    If iFlagRepairStatus = 0 Then
                                        R1("RepairStatus") = Left(R2("Dcode_Sdesc"), 8)
                                        iFlagRepairStatus = 1
                                    End If

                            End Select
                        End If

                    Next R2

                    R1.EndEdit()
                    iFlagCarrier = 0
                    iFlagTansaction = 0
                    iFlagAPC = 0
                    iFlagComplaint = 0
                    iFlagProblemFound = 0
                    iFlagRepair = 0
                    iFlagRepairStatus = 0

                Next R1

            Catch ex As Exception
                MsgBox(R2("Device_ID") & "     " & ex.Message.ToString)
                'ex.
                R1.CancelEdit()
                If Not IsNothing(T1) Then
                    T1.Dispose()
                End If
                T1 = Nothing
                Throw ex

            Finally
                If Not IsNothing(T2) Then
                    T2.Dispose()
                End If
                T2 = Nothing

                If Not IsNothing(dtRMANum) Then
                    dtRMANum.Dispose()
                End If
                dtRMANum = Nothing
            End Try

            Return T1

        End Function

        '****************************************************************************
        'This method consolidates the two data tables in to one final table to output
        '****************************************************************************
        Private Shared Function ConsolidateWIPDetailInfo(ByVal T1 As DataTable, ByVal T2 As DataTable) As DataTable

            Dim R1 As DataRow
            Dim R2 As DataRow
            'Dim i As Integer
            Dim iRefDesignatorFlag As Integer = 0
            Dim iFailureCodeFlag As Integer = 0

            Try

                For Each R1 In T1.Rows
                    R1.BeginEdit()
                    '********************************************
                    For Each R2 In T2.Rows
                        If R2("Device_ID") = R1("WarrantyClaim") Then

                            If R1("MotoPartNumber") = R2("MotoPartNumber") Then

                                Select Case Trim(R2("Mcode_Desc"))
                                    Case "Reference Designator"
                                        If iRefDesignatorFlag = 0 Then
                                            R1("RefDesignator") = Left(R2("Dcode_Sdesc"), 6)
                                            iRefDesignatorFlag = 1
                                        End If

                                    Case "Failure"
                                        If iFailureCodeFlag = 0 Then
                                            R1("PartFailureCode") = Left(R2("Dcode_Sdesc"), 3)
                                            iFailureCodeFlag = 1
                                        End If
                                End Select
                            End If
                        End If
                    Next

                    R1.EndEdit()
                    iRefDesignatorFlag = 0
                    iFailureCodeFlag = 0
                Next

            Catch ex As Exception
                R1.CancelEdit()
                If Not IsNothing(T1) Then
                    T1.Dispose()
                End If
                T1 = Nothing
                Throw ex
            Finally
                If Not IsNothing(T2) Then
                    T2.Dispose()
                End If
                T2 = Nothing
            End Try
            Return T1
        End Function

        '****************************************************************************
        'This gets the model info by Device_ID
        '****************************************************************************
        Public Function GetModelInfo(ByVal iModel_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetModelInfo(iModel_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetModelInfo: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function


        '****************************************************************************
        'Executes the SQL passed to it
        '****************************************************************************
        Public Function ExecuteNonQueries(ByVal strsql As String) As Integer

            Dim i As Integer
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.ExecuteNonQueries(strsql)   'update tdevice table
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.ExecuteNonQueries: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '****************************************************************************
        'This checks if the Claim belongs to the Customer they have chosen in the menu
        '****************************************************************************
        Public Function DeviceBlongsToClaimType(ByVal iDevice_ID As Integer, _
                                                ByVal iClaimType As Integer) As DataTable
            Dim dt As DataTable
            Dim iCustID As Integer

            Select Case iClaimType
                Case 0
                    iCustID = 0         'Means Cust_ID <> 1403 and 1844 
                Case 1
                    iCustID = 1403      'Means Cust_ID = 1403 (NSC)
                Case 2
                    iCustID = 1844      'Means Cust_ID = 1844 (RL)
            End Select

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.DeviceBlongsToClaimType(iDevice_ID, iCustID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.DeviceBlongsToClaimType: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function




        '***************************************************
        'This gets the parts codes
        '***************************************************
        Public Function GetPartsCodesByDeviceID(ByVal iDevice_ID As Integer, _
                                                ByVal iClaimType As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetPartsCodesByDeviceID(iDevice_ID, iClaimType)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetPartsCodesByDeviceID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'Get codes by Device_ID
        '***************************************************
        Public Function GetCodesByDeviceID(ByVal iDevice_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetCodesByDeviceID(iDevice_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetCodesByDeviceID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This gets the Codes for a Manuf, Prod and Mcode_ID
        '***************************************************
        Public Function GetCodes(ByVal iManuf_ID As Integer, _
                                        ByVal iProd_ID As Integer, _
                                        ByVal iMcode_ID As Integer) As DataTable
            Dim dt As DataTable
            Dim myDataRow As DataRow

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetCodes(iManuf_ID, iProd_ID, iMcode_ID)

                'Insert an empty row into the datatable
                myDataRow = dt.NewRow
                myDataRow("Dcode_ID") = 0
                myDataRow("Dcode_Sdesc") = ""
                myDataRow("Dcode_Ldesc") = ""
                dt.Rows.Add(myDataRow)
                myDataRow = Nothing

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetCarrierCodes: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try

        End Function

        '***************************************************
        'This gets the Device info from tcellopt table
        '***************************************************
        Public Function GetDeviceInfoFromCellOptByDeviceID(ByVal iDevice_ID As Integer) As DataTable

            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetDeviceInfoFromCellOptByDeviceID(iDevice_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetDeviceInfoFromCellOptByDeviceID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try

        End Function
        '***************************************************
        'Gets WO, device Info with device_id
        '***************************************************
        Public Function GetWOInfoByDeviceID(ByVal iDevice_ID As Integer, _
                                            ByVal iClaimType As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetWOInfoByDeviceID(iDevice_ID, iClaimType)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetWOInfoByDeviceID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This converts HEX serial number to decimal serial number for motorola
        '***************************************************
        Public Function ConvertHexToDecimalForMotorola(ByVal strDeviceSN As String) As String
            Dim strDtCode As String
            strDtCode = Mid$(Trim(strDeviceSN), 9, 3)
            'Make hex code conversion here
            Dim valHex As String = Mid$(Trim(strDeviceSN), 1, 8)
            Dim vals1 As String = Mid$(Trim(strDeviceSN), 1, 2)
            Dim vals2 As String = Mid$(Trim(strDeviceSN), 3, 6)

            Dim valDec1 As System.UInt32
            valDec1 = System.UInt32.Parse(vals1, Globalization.NumberStyles.HexNumber)
            Dim valDec2 As System.UInt32
            valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)

            Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
            Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
            Return v1 & v2

        End Function

        '***************************************************
        'This method gets all the device_sns that are yet to be shipped
        '***************************************************
        'Public Function GetSeviceSNsToBeShippedForWO(ByVal iCust_ID As Integer, ByVal iWO_ID As Integer) As DataTable
        '    Dim dt As DataTable

        '    Try
        '        objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
        '        dt = objMotoSubcontract_Data.GetDeviceSNsToBeShippedForWO(iCust_ID, iWO_ID)
        '        Return dt
        '    Catch ex As Exception
        '        If Not IsNothing(dt) Then
        '            If Not IsDBNull(dt) Then
        '                dt.Dispose()
        '            End If
        '            dt = Nothing
        '        End If
        '        Throw New Exception("MotorolaSubcontract_Biz.GetSeviceSNsToBeShippedForWO: " & ex.Message.ToString)
        '    Finally
        '        objMotoSubcontract_Data = Nothing
        '    End Try
        'End Function

        '***************************************************
        'Gets Num Of Devices In Pallett
        '***************************************************
        Public Function UpdateBillingSummary(ByVal strDeviceIDs As String) As Integer
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim iRUR As Integer = 0
            Dim iBER As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetBillingSummaryPerDevice(strDeviceIDs)

                For Each R1 In dt.Rows      'There will be only one row.

                    If R1("billcode_rule") = 1 Then     'RUR
                        iRUR = 1
                        iBER = 0
                    ElseIf R1("billcode_rule") = 2 Then     'BER/NER
                        iRUR = 0
                        iBER = 1
                    Else
                        iRUR = 0
                        iBER = 0
                    End If

                    i = objMotoSubcontract_Data.UpdateBillingSummary(R1("Device_id"), R1("AvgCost"), R1("StdCost"), R1("InvoiceAmt"), iRUR, iBER)
                    j = j + i
                Next

                Return j
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.UpdateBillingSummary: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function
        '***************************************************
        'Gets Num Of Devices In Pallett
        '***************************************************
        '''Public Function GetNumOfDevicesInPallett(ByVal iPallett_ID As Integer) As DataTable
        '''    Dim dt As DataTable

        '''    Try
        '''        'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
        '''        dt = objMotoSubcontract_Data.GetNumOfDevicesInPallett(iPallett_ID)
        '''        Return dt
        '''    Catch ex As Exception
        '''        If Not IsNothing(dt) Then
        '''            If Not IsDBNull(dt) Then
        '''                dt.Dispose()
        '''            End If
        '''            dt = Nothing
        '''        End If
        '''        Throw New Exception("MotorolaSubcontract_Biz.GetNumOfDevicesInPallett: " & ex.Message.ToString)
        '''        'Finally
        '''        'objMotoSubcontract_Data = Nothing
        '''    End Try
        '''End Function

        '***************************************************
        'This retrieves all devices_ids for a given Pallett
        '***************************************************
        Public Function GetAllDeviceIDsForPallettID(ByVal iPallett_ID As Integer) As DataTable
            Dim dtab1 As DataTable
            'Dim dtab2 As DataTable
            Dim R1 As DataRow
            Dim strVar As String
            Dim sb As New StringBuilder()
            Dim i As Integer = 1
            Dim iErr As Integer = 0

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()

                'We are doing this in steps because joining some giant tables
                'is taking for ever to bring the data back
                '******************************************
                'Step 1
                '******************************************
                Try
                    dtab1 = objMotoSubcontract_Data.GetAllShipIDsForPallett(iPallett_ID)
                    sb = sb.Append("(")
                    For Each R1 In dtab1.Rows
                        If i < dtab1.Rows.Count Then
                            sb = sb.Append(R1("Ship_ID")).Append(",")
                            i += 1
                        Else
                            sb = sb.Append(R1("Ship_ID")).Append(")")
                        End If
                    Next
                Catch ex As Exception
                    iErr = 1
                    Throw ex
                Finally
                    If Not IsNothing(dtab1) Then
                        If Not IsDBNull(dtab1) Then
                            dtab1.Dispose()
                        End If
                        dtab1 = Nothing
                    End If
                End Try
                '******************************************
                'Step 2
                '******************************************
                If iErr = 0 Then
                    dtab1 = objMotoSubcontract_Data.GetAllDeviceIDsForShipIDs(sb.ToString())
                End If

                '******************************************

                Return dtab1
            Catch ex As Exception
                If Not IsNothing(dtab1) Then
                    If Not IsDBNull(dtab1) Then
                        dtab1.Dispose()
                    End If
                    dtab1 = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetAllDeviceIDsForPallettID: " & ex.Message.ToString)
            Finally
                sb = Nothing
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function


        '***************************************************
        'This updates the repair status based on PallettShipDate
        '***************************************************
        '1, iPallett_ID, 
        Public Function UpdateRepairStatusBasedOnPallettShipDate(ByVal iFlag As Integer, _
                                                                Optional ByVal iPallett_ID As Integer = 0, _
                                                                Optional ByVal iShip_ID As Integer = 0) As Integer
            'iFlag = 0 (APS)
            'iFlag = 1 (SHP)

            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                If iPallett_ID > 0 Then

                    'Get all devices for the ship_id
                    dt1 = GetAllDeviceIDsForPallettID(iPallett_ID)

                    For Each R1 In dt1.Rows
                        i = UpdateRepairStatus(R1("Device_ID"), iFlag)
                    Next

                ElseIf iShip_ID > 0 Then   'Means Pallett doesn't have a ship date

                    'Get all devices for the ship_id
                    dt1 = GetAllDeviceIDsForShipID(iShip_ID)
                    For Each R1 In dt1.Rows
                        i = UpdateRepairStatus(R1("Device_ID"), iFlag)
                    Next

                End If
            Catch ex As Exception
                Return 0
                Throw ex
            Finally
                If Not IsDBNull(dt1) Then
                    dt1.Dispose()
                End If
                dt1 = Nothing
            End Try
            Return i
        End Function
        '***************************************************
        'This unassigns a pallett when shipping partial palletts
        '***************************************************
        Public Function DeleteDevice(ByVal iDevice_ID As String) As Integer
            Dim i As Integer = 0
            Dim dt1 As New DataTable()
            Dim R1 As DataRow
            Try

                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()

                '***************************************
                'Check if the device is billed
                dt1 = objMotoSubcontract_Data.IsDeviceBilled(iDevice_ID)

                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    If Not IsDBNull(R1("Device_Datebill")) Then
                        Throw New Exception("This device has been billed. Unbill it before you delete it.")
                    End If
                Else
                    Throw New Exception("Device does not exist in the database.")
                End If
                '***************************************
                i = objMotoSubcontract_Data.DeleteDevice(iDevice_ID)
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.DeleteDevice: " & ex.Message.ToString)
            Finally
                R1 = Nothing
                dt1 = Nothing
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'Retrieves the WO info
        '***************************************************
        Public Function GetWOInfo(ByVal iWO_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetWOInfo(iWO_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetWOInfo: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function
        '***************************************************
        'Retrieves the overpack info
        '***************************************************
        Public Function GetOverpackInfo(ByVal iOverpack_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetOverpackInfo(iOverpack_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetOverpackInfo: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function
        '***************************************************
        'This assigns a pallett when shipping partial palletts
        '***************************************************
        Public Function AssignPallett(ByVal iPallett_ID As Integer, _
                                        ByVal strOverpackIDs As String) As Integer
            Dim i As Integer = 0
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.AssignPallett(iPallett_ID, strOverpackIDs)
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.AssignPallett: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This unassigns a pallett when shipping partial palletts
        '***************************************************
        Public Function UnassignPallett(ByVal strOverpackIDs As String) As Integer
            Dim i As Integer = 0
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.UnassignPallett(strOverpackIDs)
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.UnassignPallett: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This assigns the pallett a ship date
        '***************************************************
        Public Function UnshipMasterpack(ByVal iWO_ID As Integer, _
                                         ByVal iShip_ID As Integer) As Integer
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iOverpack_ID As Integer
            Dim iPallett_ID As Integer

            Dim strDevice_IDs As String = ""
            Dim iCounter As Integer = 0
            Dim iRowCnt As Integer = 0

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                '*************************
                'Step 1:: (Check if the devices are invoiced)
                'Step (A): Get all the Device_ID, Device_Invoice for this masterpack
                Try
                    dt = objMotoSubcontract_Data.GetDeviceInfoForMasterpack(iShip_ID)

                    iRowCnt = dt.Rows.Count

                    For Each R1 In dt.Rows      'There will be only one row.
                        If R1("Device_Invoice") <> 0 Then
                            MsgBox("There are devices that have been invoiced in this Masterpack. Can not be unshipped.", MsgBoxStyle.Critical)
                            Exit Function
                        End If

                        iCounter += 1
                        If iRowCnt = iCounter Then
                            If strDevice_IDs = "" Then
                                strDevice_IDs = "(" & CStr(R1("Device_ID")) & ")"
                            Else
                                strDevice_IDs += CStr(R1("Device_ID")) & ")"
                            End If

                        Else
                            If strDevice_IDs = "" Then
                                strDevice_IDs = "(" & CStr(R1("Device_ID")) & ", "
                            Else
                                strDevice_IDs += CStr(R1("Device_ID")) & ", "
                            End If
                        End If

                    Next R1

                Catch ex As Exception
                    Throw New Exception("MotorolaSubcontract_Biz.UnshipMasterpack.GetDeviceInfoForMasterpack: " & ex.Message.ToString)
                    'Finally
                    'objMotoSubcontract_Data = Nothing
                End Try

                '*************************
                'Step 2::       'Update the tdevicecodes table with Repair Status as 'ARP'

                For Each R1 In dt.Rows      'There will be only one row.
                    i = Me.UpdateRepairStatus(R1("Device_ID"), 2)
                    i = 0
                Next

                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '*************************
                'Step 3::   (Update device table)
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.ResetDeviceTable(iWO_ID, iShip_ID)     'update tdevice table

                '*************************
                'Step 4::   (Get the overpack_id for the ship_id)
                dt = objMotoSubcontract_Data.GetOverPackIDForShipID(iShip_ID)

                For Each R1 In dt.Rows      'There will be only one row.
                    iOverpack_ID = CInt(R1("Overpack_ID"))
                    Exit For
                Next

                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '*************************
                'Step 5:: Delete the ship_id from tship table
                i = objMotoSubcontract_Data.DeleteShipId(iShip_ID)

                '*************************
                'Step 6::       (Set the over pack shipdate to NULL)
                i = objMotoSubcontract_Data.UnassignOverpackShipDate(iOverpack_ID)

                '*************************
                'Step 7         (Get the pallett_ID)
                dt = objMotoSubcontract_Data.GetPallettIDforOverPack(iOverpack_ID)

                For Each R1 In dt.Rows      'There will be only one row.
                    iPallett_ID = CInt(R1("Pallett_ID"))
                    Exit For
                Next

                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '*************************
                'Step 8::   Unassign PallettShipDate
                i = objMotoSubcontract_Data.UnassignPallettShipDate(iPallett_ID)
                '*************************
                'Step 9::   
                i = objMotoSubcontract_Data.ResetWOShipStatus(iWO_ID)
                '*************************
                'Step 10::
                i = objMotoSubcontract_Data.DeleteBillingSummary(strDevice_IDs)
                '*************************
                'Step 11:: 
                'Find out if there are any Masterpacks left in this overpack.
                dt = objMotoSubcontract_Data.GetNumOfMasterPacksForOverPack(iOverpack_ID)

                i = 0
                iCounter = 0
                For Each R1 In dt.Rows      'There will be only one row.
                    iCounter = CInt(R1("NumOfMasterPacks"))
                    Exit For
                Next
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                'If there are no masterpacks left in this overpack delete this overpack
                If iCounter = 0 Then
                    i = objMotoSubcontract_Data.DeleteOverpack(iOverpack_ID)
                End If

                '*************************
                'Step 12::

                'Find out if there any overpacks in a Pallett
                dt = objMotoSubcontract_Data.GetNumOfOverPacksForPallett(iPallett_ID)

                iCounter = 0
                For Each R1 In dt.Rows      'There will be only one row.
                    iCounter = CInt(R1("NumOfOverPacks"))
                    Exit For
                Next
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                'Find out if there are any Devices for Pallett
                dt = objMotoSubcontract_Data.GetNumOfDevicesForPallett(iPallett_ID)

                i = 0
                For Each R1 In dt.Rows      'There will be only one row.
                    i = CInt(R1("NumOfDevices"))
                    Exit For
                Next

                'Delete the Pallett if both num of Devices = 0 and num of overpacks = 0
                If i = 0 And iCounter = 0 Then
                    i = objMotoSubcontract_Data.DeletePallett(iPallett_ID)
                End If
                '*************************

                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.UnshipMasterpack: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'Get Device_ID for a Device_SN amd WO_ID
        '***************************************************
        Public Function Get_DeviceID_For_Device_SN_and_Ship_ID(ByVal iShip_ID As Integer, _
                                                            ByVal strDeviceSN As String) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.Get_DeviceID_For_Device_SN_and_Ship_ID(iShip_ID, strDeviceSN)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.Get_DeviceID_For_Device_SN_and_WO_ID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'Get all devices for a Workorder
        '***************************************************
        Public Function GetAllDeviceIDsForShipID(ByVal iShip_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetAllDeviceIDsForShipID(iShip_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetAllDeviceIDsForShipID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function


        '***************************************************
        'Get all devices for a Workorder
        '***************************************************
        'Public Function GetAllDevicesForWO(ByVal iWO_ID As Integer) As DataTable
        '    Dim dt As DataTable

        '    Try
        '        objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
        '        dt = objMotoSubcontract_Data.GetAllDevicesForWO(iWO_ID)
        '        Return dt
        '    Catch ex As Exception
        '        If Not IsNothing(dt) Then
        '            If Not IsDBNull(dt) Then
        '                dt.Dispose()
        '            End If
        '            dt = Nothing
        '        End If
        '        Throw New Exception("MotorolaSubcontract_Biz.GetAllDevicesForWO: " & ex.Message.ToString)
        '    Finally
        '        objMotoSubcontract_Data = Nothing
        '    End Try
        'End Function



        '***************************************************
        'This updates the repair status
        '***************************************************
        Public Function UpdateRepairStatus(ByVal iDevice_ID As Integer, _
                                            ByVal i As String) As Integer
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iDeviceCode_ID As Integer
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                'Get DeveiceCode_ID
                dt = objMotoSubcontract_Data.GetDeviceCodeID(iDevice_ID)

                If Not IsDBNull(dt) Then
                    For Each R1 In dt.Rows      'There will be only one row.
                        iDeviceCode_ID = CInt(R1("DeviceCode_ID"))
                        Exit For
                    Next
                Else
                    iDeviceCode_ID = 0      'if There is no RepairStatus code existing in tdevicecodes table
                End If

                'Determine what the Repair Status is
                If i = 0 Then
                    i = 579     'APS    'AWAITING PACKING/SHIPMENT
                ElseIf i = 1 Then
                    i = 587     'SHP    'SHIPPED
                Else
                    i = 580     'ARP    'Awaiting Repair
                End If

                If Not IsDBNull(iDeviceCode_ID) Then
                    i = objMotoSubcontract_Data.UpdateRepairStatus(iDevice_ID, iDeviceCode_ID, i)   'update tdevicecodes table
                End If

                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.UpdateRepairStatus: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This assigns the pallett a ship date
        '***************************************************
        Public Function AssignShipDateToPallett(ByVal iPallett_ID As Integer, _
                                                ByVal strShipDate As String) As Integer
            Dim i As Integer = 0
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.AssignShipDateToPallett(iPallett_ID, strShipDate)    'update tworkorder table
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.AssignShipDateToPallett: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function


        '***************************************************
        'This flags the WO ready to be shipped
        '***************************************************
        Public Function SetWOReadyToBeShipped(ByVal iWO_ID As Integer, ByVal strShipDt As String) As Integer
            Dim i As Integer = 0
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.SetWOReadyToBeShipped(iWO_ID, strShipDt)    'update tworkorder table
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.SetWOReadyToBeShipped: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        Public Function GetNumOfDevicetobeShippedWithRMA(ByVal iWO_ID As Integer, _
                                                Optional ByVal iNumRcvd As Integer = 0) As Integer
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim iNumShipped As Integer = 0
            Dim iNumToShip As Integer = 0

            Try
                dt = objMotoSubcontract_Data.GetNumOfDevicesShippedForWO(iWO_ID)
                For Each R1 In dt.Rows
                    iNumShipped = R1("DevicesShipped")
                Next R1
                '*************************
                R1 = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                '*************************
                If iNumRcvd = 0 Then
                    'Get Devices received for WO
                    dt = objMotoSubcontract_Data.GetNumOfDevicesReceivedForWO(iWO_ID)
                    For Each R1 In dt.Rows
                        iNumRcvd = R1("DevicesReceived")
                    Next R1
                End If
                '*************************
                'Get devices to be shipped
                iNumToShip = iNumRcvd - iNumShipped
                '*************************
                Return iNumToShip

            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.GetNumOfDevicetobeShippedWithRMA: " & ex.Message.ToString)
            Finally
                R1 = Nothing
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
            End Try
        End Function
        '***************************************************

        '***************************************************
        'This gets the Number of devices to be shipped in a work order
        '***************************************************
        '''Public Function GetNumOfDevicesToBeShippedForWO(ByVal iWO_ID As Integer) As DataTable
        '''    Dim dt As DataTable

        '''    Try
        '''        'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
        '''        dt = objMotoSubcontract_Data.GetNumOfDevicesToBeShippedForWO(iWO_ID)
        '''        Return dt
        '''    Catch ex As Exception
        '''        If Not IsNothing(dt) Then
        '''            If Not IsDBNull(dt) Then
        '''                dt.Dispose()
        '''            End If
        '''            dt = Nothing
        '''        End If
        '''        Throw New Exception("MotorolaSubcontract_Biz.GetNumOfDevicesToBeShippedForWO: " & ex.Message.ToString)
        '''        'Finally
        '''        'objMotoSubcontract_Data = Nothing
        '''    End Try
        '''End Function
        '***************************************************
        'This assigns the overpack a ship date
        '***************************************************
        Public Function AssignShipDateToOverPack(ByVal iOverPack_ID As Integer, _
                                                ByVal strShipDate As String) As Integer
            Dim i As Integer = 0
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.AssignShipDateToOverPack(iOverPack_ID, strShipDate)    'update device table
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.AssignShipDateToOverPack: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This gets the no of Masterpacks for an Overpack
        '***************************************************
        Public Function GetNumOfMasterPacksForOverPack(ByVal iOverPack_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetNumOfMasterPacksForOverPack(iOverPack_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetNumOfMasterPacksForOverPack: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'Update Device table
        '***************************************************
        Public Function UpdateDeviceTable(ByVal iDevice_ID As Integer, _
                                            ByVal iWO_ID As Integer, _
                                            ByVal iShip_ID As Integer, _
                                            ByVal strShipDate As String, _
                                            ByVal iPallett_ID As Integer, _
                                            ByVal iShiftID As Integer, _
                                            ByVal strWorkDate As String) As Integer
            Dim i As Integer = 0

            Try
                i = objMotoSubcontract_Data.UpdateDeviceTable(iDevice_ID, iWO_ID, iShip_ID, strShipDate, iPallett_ID, iShiftID, strWorkDate)    'update device table
                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.UpdateDeviceTable: " & ex.Message.ToString)
            End Try
        End Function

        ''Public Function UpdateDeviceTable(ByVal strDevice_SN As String, _
        ''                                    ByVal iWO_ID As Integer, _
        ''                                    ByVal iSKU_ID As Integer, _
        ''                                    ByVal iShip_ID As Integer, _
        ''                                    ByVal strShipDate As String, _
        ''                                    ByVal iPallett_ID As Integer) As Integer

        'Public Function UpdateDeviceTable(ByVal iDevice_ID As Integer, _
        '                                    ByVal iWO_ID As Integer, _
        '                                    ByVal iSKU_ID As Integer, _
        '                                    ByVal iShip_ID As Integer, _
        '                                    ByVal strShipDate As String, _
        '                                    ByVal iPallett_ID As Integer, _
        '                                    ByVal iShiftID As Integer, _
        '                                    ByVal strWorkDate As String) As Integer
        '    Dim i As Integer = 0

        '    Try
        '        'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
        '        i = objMotoSubcontract_Data.UpdateDeviceTable(iDevice_ID, iWO_ID, iSKU_ID, iShip_ID, strShipDate, iPallett_ID, iShiftID, strWorkDate)    'update device table
        '        Return i
        '    Catch ex As Exception
        '        Throw New Exception("MotorolaSubcontract_Biz.UpdateDeviceTable: " & ex.Message.ToString)
        '        'Finally
        '        'objMotoSubcontract_Data = Nothing
        '    End Try
        'End Function
        '***************************************************
        'Create a new Ship_ID (Master Pack)
        '***************************************************
        Public Function CreateNewMasterPack(ByVal strShipDate As String, _
                                            ByVal strUser As String, _
                                            ByVal iProd_ID As Integer, _
                                            ByVal iOverPack_ID As Integer, _
                                            ByVal iShipTo_ID As Integer) As Integer
            Dim i As Integer = 0
            Dim iShip_ID As Integer
            'Dim dt As DataTable
            'Dim R1 As DataRow
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()

                'i = objMotoSubcontract_Data.CreateNewMasterPack(strUser, iProd_ID, iOverPack_ID)    'Call to create a new master pack
                iShip_ID = objMotoSubcontract_Data.CreateNewMasterPack(strUser, iProd_ID, iOverPack_ID, iShipTo_ID)    'Call to create a new master pack

                'If i = 1 Then
                '    dt = objMotoSubcontract_Data.GetMasterPackID(iOverPack_ID)
                '    For Each R1 In dt.Rows      'There will be only one row.
                '        iShip_ID = CInt(R1("Ship_ID"))
                '        Exit For
                '    Next
                'End If

                'Step 3: Update tship table with Ship_Date field
                i = objMotoSubcontract_Data.UpdateShipDate(iShip_ID, strShipDate)

                Return iShip_ID
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.CreateNewMasterPack: " & ex.Message.ToString)
                'Finally
                'If Not IsNothing(dt) Then
                '    If Not IsDBNull(dt) Then
                '        dt.Dispose()
                '    End If
                '    dt = Nothing
                'End If
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function
        '***************************************************
        'This creates new OverPack
        '***************************************************
        Public Function CreateNewOverPack(ByVal iPallett_ID As Integer, ByVal iOverpack_Process As Integer) As Integer
            Dim i As Integer = 0
            'Dim dt As DataTable
            'Dim R1 As DataRow
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.CreateNewOverPack(iPallett_ID, iOverpack_Process)    'Call to create a new over pack
                'If i = 1 Then
                '    dt = objMotoSubcontract_Data.GetOverPackID(iPallett_ID, iOverpack_Process)
                '    For Each R1 In dt.Rows      'There will be only one row.
                '        i = CInt(R1("OverPack_ID"))
                '        Exit For
                '    Next
                'End If

                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.CreateNewOverPack: " & ex.Message.ToString)
                'Finally
                'If Not IsNothing(dt) Then
                '    If Not IsDBNull(dt) Then
                '        dt.Dispose()
                '    End If
                '    dt = Nothing
                'End If
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This create new Pallett
        '***************************************************
        Public Function CreateNewPallett(ByVal iWO_ID As Integer, ByVal iLOC_ID As Integer) As Integer
            Dim i As Integer = 0
            'Dim dt As DataTable
            'Dim R1 As DataRow
            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                i = objMotoSubcontract_Data.CreateNewPallett(iWO_ID, iLOC_ID)    'Call to create a new Pallett

                'If i = 1 Then
                '    dt = objMotoSubcontract_Data.GetPallettID(iWO_ID)
                '    For Each R1 In dt.Rows      'There will be only one row.
                '        i = CInt(R1("Pallett_ID"))
                '        Exit For
                '    Next
                'End If

                Return i
            Catch ex As Exception
                Throw New Exception("MotorolaSubcontract_Biz.CreateNewPallett: " & ex.Message.ToString)
                'Finally
                'If Not IsNothing(dt) Then
                '    If Not IsDBNull(dt) Then
                '        dt.Dispose()
                '    End If
                '    dt = Nothing
                'End If
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This gets the LOC_ID
        '***************************************************
        Public Function GetLOCID(ByVal iWO_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetLOCID(iWO_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetLOCID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function
        '***************************************************
        'This gets the OverPack_ID
        '***************************************************
        Public Function GetOverPackID(ByVal iPallett_ID As Integer, ByVal iOverpack_Process As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetOverPackID(iPallett_ID, iOverpack_Process)

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetOverPackID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This retrieves Pallett_ID
        '***************************************************
        Public Function GetPallettID(ByVal iWO_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetPallettID(iWO_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetPallettID: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This retrieves some shipping data
        '***************************************************
        'Public Function GetShipingInfo(ByVal iWO_ID As Integer) As DataTable
        '    Dim dt As DataTable

        '    Try
        '        objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
        '        dt = objMotoSubcontract_Data.GetShipingInfo(iWO_ID)
        '        Return dt
        '    Catch ex As Exception
        '        If Not IsDBNull(dt) Then
        '            dt.Dispose()
        '        End If
        '        If Not IsNothing(dt) Then
        '            dt = Nothing
        '        End If
        '        Throw ex
        '    Finally
        '        objMotoSubcontract_Data = Nothing
        '    End Try
        'End Function
        '***************************************************
        'This calls the data layer to get the RMA Grid data
        '***************************************************
        Public Function GetRMAGridData(ByVal iCust_ID As Integer, _
                                        Optional ByVal iLoc_ID As Integer = 0, _
                                        Optional ByVal iGroup_ID As Integer = 0) As DataTable
            Dim dt As DataTable
            Dim dt1 As DataTable
            Dim R As DataRow
            Dim R1 As DataRow

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                ''''If iLoc_ID = 0 Then
                ''''    dt = objMotoSubcontract_Data.GetRMAGridData(iCust_ID, )
                ''''Else
                ''''    dt = objMotoSubcontract_Data.GetRMAGridData(iCust_ID, iLoc_ID)
                ''''End If

                'Commented by Asif on 01/19/2006
                '''''''''''Select Case iCust_ID
                '''''''''''    Case 2106       'PSSI Cellular Sales
                '''''''''''        dt = objMotoSubcontract_Data.GetRMAGridData_ATCLE(iCust_ID, iLoc_ID)
                '''''''''''    Case 2127       'GSM
                '''''''''''        dt = objMotoSubcontract_Data.GetRMAGridData(iCust_ID, iLoc_ID)
                '''''''''''    Case 2069       'AWS, Inc.
                '''''''''''        dt = objMotoSubcontract_Data.GetRMAGridData_ATCLE(iCust_ID, iLoc_ID)
                '''''''''''    Case 2019       'ATCLE_AWS      
                '''''''''''        dt = objMotoSubcontract_Data.GetRMAGridData_ATCLE(iCust_ID, iLoc_ID)
                '''''''''''    Case 2058           'ATCLE_ZM
                '''''''''''        dt = objMotoSubcontract_Data.GetRMAGridData_ATCLE(iCust_ID, iLoc_ID)
                '''''''''''    Case 1403       'Motorola NSC - Cellular
                '''''''''''        dt = objMotoSubcontract_Data.GetRMAGridData_MotorolaNSC(iCust_ID, iLoc_ID)
                '''''''''''    Case 1844       'Motorola RL - Cellular
                '''''''''''        dt = objMotoSubcontract_Data.GetRMAGridData(iCust_ID, iLoc_ID)
                '''''''''''    Case Else
                '''''''''''        dt = objMotoSubcontract_Data.GetRMAGridData(iCust_ID, iLoc_ID)
                '''''''''''End Select

                dt = objMotoSubcontract_Data.GetRMAGridData(iCust_ID, iLoc_ID, iGroup_ID)

                For Each R In dt.Rows
                    Try
                        '**********************************************************************
                        'Get total number of devices received for WO
                        '**********************************************************************
                        dt1 = objMotoSubcontract_Data.GetNumOfDevicesReceivedForWO(R("WO_ID"))

                        For Each R1 In dt1.Rows  'There will be only one row
                            R("DevicesReceived") = R1("DevicesReceived")
                            R("DevicesToBeShipped") = Me.GetNumOfDevicetobeShippedWithRMA(R("WO_ID"), R1("DevicesReceived"))
                            Exit For
                        Next R1
                        '**********************************************************************
                        'Get Devices to be shipped for WO
                        '**********************************************************************
                        '''dt1 = objMotoSubcontract_Data.GetNumOfDevicesShippedForWO(R("WO_ID"))

                        '''For Each R1 In dt1.Rows  'There will be only one row
                        '''    'R("DevicesToBeShipped") = R("WO_Quantity") - R1("DevicesShipped")
                        '''    R("DevicesToBeShipped") = R("RMA_Quantity") - R1("DevicesShipped")
                        '''    Exit For
                        '''Next R1

                        '''If Not IsNothing(dt1) Then
                        '''    If Not IsDBNull(dt1) Then
                        '''        dt1.Dispose()
                        '''    End If
                        '''    dt1 = Nothing
                        '''End If

                        '**********************************************************************

                    Catch ex As Exception
                        Throw
                    Finally
                        If Not IsNothing(dt1) Then
                            If Not IsDBNull(dt1) Then
                                dt1.Dispose()
                            End If
                            dt1 = Nothing
                        End If
                    End Try
                Next R
                dt.AcceptChanges()
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetRMAGridData: " & ex.Message.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    If Not IsDBNull(dt1) Then
                        dt1.Dispose()
                    End If
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************
        'This calls the data layer to get the customers
        '***************************************************
        Public Function GetAllLocations() As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetAllLocations
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetAllLocations: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This calls the data layer to get the customers
        '***************************************************
        Public Function GetAllCustomers() As DataTable
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetAllCustomers

                'Insert an empty row into the datatable
                R1 = dt.NewRow
                R1("Cust_ID") = 0
                R1("Cust_Name1") = ""
                dt.Rows.Add(R1)

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetAllCustomers: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This gets the customer info for a given customer
        '***************************************************
        Public Function GetCustInfo(ByVal iCust_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                dt = objMotoSubcontract_Data.GetCustInfo(iCust_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetCustInfo: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This gets all groups
        '***************************************************
        Public Function GetGroups() As DataTable
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                dt = objMotoSubcontract_Data.GetGroups

                'Insert an empty row into the datatable
                R1 = dt.NewRow
                R1("Group_ID") = 0
                R1("Group_Desc") = ""
                dt.Rows.Add(R1)

                Return dt
            Catch ex As Exception
                R1 = Nothing
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetGroups: " & ex.Message.ToString)
            End Try
        End Function


        '***************************************************
        'This calls the data layer to get the customers
        '***************************************************
        'Public Function GetCustomers(Optional ByVal iCust_ID As Integer = 0) As DataTable
        Public Function GetCustomers() As DataTable
            Dim dt As DataTable
            Dim R1 As DataRow

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                'If iCust_ID = 0 Then
                '    dt = objMotoSubcontract_Data.GetCustomers   'Motorola NSC and ATCLE
                'Else
                '    dt = objMotoSubcontract_Data.GetCustomers(iCust_ID)   'Motorola RL
                'End If

                dt = objMotoSubcontract_Data.GetCustomers   'Motorola NSC and ATCLE

                'Insert an empty row into the datatable
                R1 = dt.NewRow
                R1("Cust_ID") = 0
                R1("Cust_Name1") = ""
                dt.Rows.Add(R1)

                Return dt
            Catch ex As Exception
                R1 = Nothing
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetCustomers: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'GetDeviceSNsForWO
        '***************************************************
        Public Function GetSNsForWOBasedShipping(ByVal iWO_ID As Integer, _
                                                ByVal iGroup_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                'dt = objMotoSubcontract_Data.GetDeviceSNsForWO(iWO_ID)
                dt = objMotoSubcontract_Data.GetSNsForWOBasedShipping(iWO_ID, iGroup_ID)

                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetSNsForWOBasedShipping: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'Get Device SNs For ATCLE Shipping
        '***************************************************
        Public Function GetSNsForModelBasedShipping(ByVal iLoc_ID As Integer, _
                                                    ByVal iModel_ID As Integer, _
                                                    ByVal iGroup_ID As Integer, _
                                                    Optional ByVal strShortLongFlg As String = "") _
                                                    As DataTable
            Dim dt As DataTable
            Dim R1 As DataRow
            'Dim iModel_ID As Integer = 0

            Try

                '*********************************
                'dt = objMotoSubcontract_Data.GetDeviceSNsForATCLEShipping(iCust_ID, iModel_ID)
                dt = objMotoSubcontract_Data.GetSNsForModelBasedShipping(iLoc_ID, iModel_ID, iGroup_ID, strShortLongFlg)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetSNsForModelBasedShipping: " & ex.Message.ToString)
            Finally
                R1 = Nothing
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'Get DeviceSNs For SKU
        '***************************************************
        Public Function GetSNsForSKUBasedShipping(ByVal iSKU_ID As Integer, _
                                                    ByVal iGroup_ID As Integer) As DataTable
            Dim dt As DataTable

            Try
                'objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
                'dt = objMotoSubcontract_Data.GetDeviceSNsForSKU(iSKU_ID)
                dt = objMotoSubcontract_Data.GetSNsForSKUBasedShipping(iSKU_ID, iGroup_ID)
                Return dt
            Catch ex As Exception
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                Throw New Exception("MotorolaSubcontract_Biz.GetSNsForSKUBasedShipping: " & ex.Message.ToString)
                'Finally
                'objMotoSubcontract_Data = Nothing
            End Try
        End Function

        '***************************************************
        'This gets the Device Serial Numbers for a given WO
        '***************************************************
        'Public Function GetDeviceSNsForWO(ByVal iWO_ID As Integer) As DataTable
        '    Dim dt As DataTable

        '    Try
        '        objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
        '        dt = objMotoSubcontract_Data.GetDeviceSNsForWO(iWO_ID)
        '        Return dt
        '    Catch ex As Exception
        '        If Not IsNothing(dt) Then
        '            If Not IsDBNull(dt) Then
        '                dt.Dispose()
        '            End If
        '            dt = Nothing
        '        End If
        '        Throw New Exception("MotorolaSubcontract_Biz.GetDeviceSNsForWO: " & ex.Message.ToString)
        '    Finally
        '        objMotoSubcontract_Data = Nothing
        '    End Try
        'End Function

        '***************************************************

        Public Sub New()
            objMotoSubcontract_Data = New PSS.Data.Production.MotorolaSubcontract_Data()
            objMyLib = New MyLib.Utility()
        End Sub

        Protected Overrides Sub Finalize()
            objMotoSubcontract_Data = Nothing
            objMyLib = Nothing
            MyBase.Finalize()
        End Sub
    End Class
End Namespace
