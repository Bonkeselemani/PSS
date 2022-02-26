Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Data.Buisness
Imports PSS.Core.[Global]

Namespace Rules

    Public Class Device
        Inherits Object
        Implements IDisposable

#Region "Internals"
        '// Device ID
        Private _ID As Integer = Nothing
        '// Device Info
        Private _device As DataRow = Nothing
        '// Parts already billed
        Private WithEvents _parts As DataTable = Nothing
        '// Labor information for billing
        Private _labor As DataTable = Nothing
        '// Parts information for billing
        Private _billable As DataTable = Nothing
        '// Our calculating Labor Level
        Private _laborlevel As Integer = Nothing
        '// Are we a dbr 
        Private _dbr As Boolean = False
        '// Are we a ntf
        Private _ntf As Boolean = False
        '// Are we a No Part
        Private _noparts As Boolean = False
        '// Are we a RTM
        Private _RTM As Boolean = False
        Private _NER As Boolean = False
        '// Store Customer Name for information
        Private _cust As String = Nothing
        '// Tell us if we have an end user or not.
        Private _CreditUser As Boolean = False
        '// Cust_ID     'Added by Asif
        Private _CustID As Integer = 0
        '// Model_ID     'Added by Lan
        Private _iModelID As Integer = 0

        Private vFailureCode As Int32 = 0
        Private vckManufWrty As Integer = 0

        'Warranty Claim required Failcode, Repaircode
        Private _iFailID As Integer = 0
        Private _iRepairID As Integer = 0
        Private _iComplainID As Integer = 0
        Private _iScreenID As Integer = 0

#End Region

#Region "Constructors / Destructors"

        Private Sub New()
        End Sub

        Public Sub New(ByVal Device As Integer)
            InternalConstruct(Device)
        End Sub

        Private Sub InternalConstruct(ByVal Device As Integer)
            Dim iMaxBillRule As Integer = 0

            Try
                _ID = Device
                _device = DeviceBilling.GetDeviceData(Device)

                _parts = DeviceBilling.GetBilledData(Device)

                _labor = DeviceBilling.GetLaborData(_device("PricingGroup"), _device("PoductGroup"))
                _billable = DeviceBilling.GetPartData(_device("Model_ID"))
                _laborlevel = _device("Device_LaborLevel")

                If _device("Pay_ID") = 2 Then Me._CreditUser = True

                If Me._CreditUser = False Then _cust = _device("Loc_Name") Else _cust = _device("Cust_Name1") & " " & _device("Cust_Name2")

                '//Added by Asif
                _CustID = _device("Cust_ID")
                '//Added by Lan on 02/29/2008
                _iModelID = _device("Model_ID")

                Me.DefineDeviceStatus()
            Catch ex As Exception
                'MsgBox(e.ToString)
                Me.Dispose()
                'MsgBox("There is not enough data to bill this device.", MsgBoxStyle.Information, "Error")
                'Exit Sub
                Throw ex
            End Try
        End Sub

        Public Sub Open(ByVal Device As Integer)
            InternalConstruct(Device)
        End Sub

        Public Sub Close()
            InteralDestruct()
        End Sub

        Public Sub Dispose()
            InteralDestruct()
        End Sub

        Private Sub InteralDestruct() Implements IDisposable.Dispose
            _device = Nothing
            _parts = Nothing
            _labor = Nothing
            _billable = Nothing
            _laborlevel = Nothing
            _dbr = False
            _noparts = False
            _NER = False
            _cust = Nothing
            Me._CreditUser = False
            _CustID = Nothing
            _iModelID = Nothing

            'HTC Require data
            Me._iFailID = 0
            Me._iRepairID = 0
        End Sub

#End Region

#Region "Methods"
        Private Sub CheckForFlatRate(ByVal BillCode As Integer, ByVal CustID As Integer)
            MsgBox(_device("Model_ID"))
            MsgBox(_device("Cust_ID"))
            MsgBox(BillCode)
        End Sub

        Public Sub AddPart(ByVal BillCode As Integer)
            Try
                '*************************************************
                'Added by Lan on 02/29/2008
                'contingent billing
                '*************************************************
                If (Me._CustID = 14 And (Me._iModelID = 2 Or Me._iModelID = 7)) Or (Me._CustID = 1545 And Me._iModelID = 14) Or (Me._CustID = 2507 And Me._iModelID = 14) Or (Me._CustID = 2508 And Me._iModelID = 14) Then
                    If BillCode = 20 Then     'Recrystaled(service)
                        InternalAddPart(21)
                    ElseIf BillCode = 21 Then 'Crystal Used(part)
                        InternalAddPart(20)
                    End If
                End If
                '*************************************************
                InternalAddPart(BillCode) '//second parameter removed(0)
                Me._parts = DeviceBilling.GetBilledData(Me._ID)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        'Public Sub AddPartCELL(ByVal BillCode As Integer, ByVal FailureCode As Integer, ByVal vMW As Integer)
        '    vFailureCode = 0
        '    vFailureCode = FailureCode

        '    '******************************************************
        '    'THIS IS VERY CONFUSE....... COMMMENT BY LAN 08/27/09
        '    'Why reset the manuf warranty flag???????????????????
        '    '******************************************************
        '    'If vMW = 1 Then
        '    '    '//Invalidate Manufacturer Warranty
        '    '    _device("Device_ManufWrty") = 0
        '    'End If
        '    '******************************************************

        '    InternalAddPart(BillCode) '//second parameter removed(0)

        '    '*************************************************
        '    'Added by Lan on 02/29/2008
        '    'contingent billing
        '    '*************************************************
        '    If (Me._CustID = 14 And (Me._iModelID = 2 Or Me._iModelID = 7)) Or (Me._CustID = 1545 And Me._iModelID = 14) Then
        '        If BillCode = 20 Then     'Recrystaled(service)
        '            InternalAddPart(21)
        '        ElseIf BillCode = 21 Then 'Crystal Used(part)
        '            InternalAddPart(20)
        '        End If
        '    End If
        '    '*************************************************
        'End Sub

        '*****************************************************************************************************************
        '// Modify on 06/09/2011 Add Regular part cost (Dbill_RegPartCost) for RV Part
        '*****************************************************************************************************************
        Private Sub InternalAddPart(ByVal BillCode As Integer)
            Dim iBillcodeRule, iBillcodeTypeID As Integer
            Dim pPrice, dbExceptionItems As Double
            Dim dr As DataRow()
            Dim drNewPart As DataRow
            Dim booDeviceHasParts As Boolean = False

            Try
                iBillcodeRule = 0 : iBillcodeTypeID = 0
                pPrice = 0 : dbExceptionItems = 0
                If IsNumeric(BillCode) = False Then Exit Sub

                iBillcodeRule = Me.GetPartRule(BillCode)
                iBillcodeTypeID = Me.GetPartTypeID(BillCode)
                booDeviceHasParts = Generic.IsDeviceHadParts(Me.ID)

                If Me._device("Prod_ID") <> 9 AndAlso Me._device("Prod_ID") <> 7 AndAlso (iBillcodeRule = 1 OrElse iBillcodeRule = 2 OrElse iBillcodeRule = 3 OrElse iBillcodeRule >= 8) AndAlso (booDeviceHasParts = True OrElse Me._laborlevel > 1) Then
                    'Can't RUR/BER/Scrap when device has parts.
                    Throw New Exception("Please remove all parts and repair service before select this.")
                ElseIf (BillCode = 255 OrElse BillCode = 1174) AndAlso booDeviceHasParts = True Then
                    Throw New Exception("Please remove all parts before select no parts.")
                ElseIf iBillcodeRule = 6 AndAlso booDeviceHasParts = True Then
                    Throw New Exception("Please remove all parts before select NTF.")
                ElseIf iBillcodeRule = 6 AndAlso Me._laborlevel > 1 Then
                    Throw New Exception("Please remove all repair services before select NTF.")
                ElseIf iBillcodeRule = 6 AndAlso (_dbr OrElse Me._RTM OrElse _noparts OrElse Me._NER) Then
                    Throw New Exception("Please remove RUR/DBR/RTM before select NTF.")
                ElseIf Me._device("Prod_ID") <> 9 AndAlso Me._device("Prod_ID") <> 7 AndAlso (_dbr OrElse Me._RTM OrElse _noparts OrElse _ntf OrElse _NER) AndAlso iBillcodeTypeID = 2 Then
                    'Can't Add part to RUR/BER/Scrap device.
                    Throw New Exception("Not allowed to add part into RUR/DBR/NTF or No Parts device.")
                ElseIf (_dbr OrElse Me._RTM OrElse _NER) AndAlso (BillCode = 255 OrElse BillCode = 1174) Then
                    'Can't add no part or NTF service to RUR/DBR/RTM device.
                    Throw New Exception("This service is not available for RUR/DBR device.")
                ElseIf (_noparts OrElse _ntf) AndAlso (iBillcodeRule = 1 OrElse iBillcodeRule = 2 OrElse iBillcodeRule = 3 OrElse iBillcodeRule >= 8) Then
                    'Can't RUR/BER/Scrap no part/NTF device.
                    Throw New Exception("Remove all services before RUR or BER.")
                ElseIf _parts.Select("BillCode_ID = " & BillCode).Length > 0 Then
                    Throw New Exception("This part has ALREADY been added to this device.")
                ElseIf _billable.Select("BillCode_ID = " & BillCode).Length > 1 Then
                    Throw New Exception("Multiple part maps occur for this part.")
                ElseIf _billable.Select("BillCode_ID = " & BillCode).Length = 0 Then
                    Throw New Exception("Part is not listed in billable table.")
                ElseIf Me._labor.Rows.Count = 0 Then
                    Throw New Exception("There is not enough information to bill this device. " & vbCrLf & _
                                                    "There is no mapping between this product group and pricing." & vbCrLf & vbCrLf & _
                                                    "Please CONTACT CUSTOMER SERVICE.")
                Else
                    '**********************************
                    'Check labor price set up
                    '**********************************
                    Dim iMaxLaborLevelID As Integer = Me._billable.Select("BillCode_ID = " & BillCode)(0)("LaborLvl_ID")
                    Dim drPrice() As DataRow
                    If Not (_dbr OrElse Me._RTM OrElse _NER OrElse iBillcodeRule = 1 OrElse iBillcodeRule = 2 OrElse iBillcodeRule = 3 OrElse iBillcodeRule >= 8) Then
                        If Me._device("PrcType_ID").ToString = "1" Then 'Tier
                            drPrice = _labor.Select("LaborLvl_ID = " & Me._billable.Select("BillCode_ID = " & BillCode)(0)("LaborLvl_ID"))
                        Else 'Flat
                            drPrice = _labor.Select("LaborLvl_ID = 0")
                        End If

                        If drPrice.Length = 0 Then
                            Throw New Exception("No labor price set up for " & IIf(Me._device("PrcType_ID").ToString = "1", "labor level " & DeviceBilling.GetLaborLevelDescription(iMaxLaborLevelID) & ".", "flat rate."))
                        ElseIf drPrice.Length > 1 Then
                            Throw New Exception("No labor price set up for " & IIf(Me._device("PrcType_ID").ToString = "1", "labor level " & DeviceBilling.GetLaborLevelDescription(iMaxLaborLevelID) & ".", " flat rate."))
                        End If
                    End If

                    '**********************************

                    dr = _billable.Select("BillCode_ID = " & BillCode)

                    If (_dbr OrElse _NER OrElse _noparts OrElse _ntf) AndAlso iBillcodeTypeID = 1 AndAlso Convert.ToInt16(dr(0)("LaborLevel")) > 1 Then
                        'Can't Add repair service 
                        Throw New Exception("Not allowed to add repair services into RUR/DBR/NTF/No Part device.")
                    ElseIf Me._device("Prod_ID") <> 9 AndAlso Me._device("Prod_ID") <> 7 AndAlso (iBillcodeRule = 1 OrElse iBillcodeRule = 2 OrElse iBillcodeRule = 3 OrElse iBillcodeRule >= 8) AndAlso Convert.ToInt16(dr(0)("LaborLevel")) > 1 Then
                        'Can't RUR/BER/Scrap when device has parts.
                        Throw New Exception("Please remove all repair service.")
                    ElseIf Me._laborlevel > 1 AndAlso iBillcodeRule = 6 Then
                        Throw New Exception("Please remove all repair service.")
                    End If

                    If _device("Device_PSSWrty").ToString.Equals("0") = False Then 'PSS Warranty
                        pPrice = pPSSPrice(dr(0))
                    Else
                        pPrice = pRegPrice(dr(0))
                    End If

                    '*********************************************************************
                    'Added by Lan on 11/21/2007
                    'For AMS customer (cust_ID = 14) 
                    'If AE & AG model (model_id = 3 & 2) and billcode ID = 13(LCD) or 1284 or 1288
                    ' then Charge $10 for 
                    'If ALPE-Alpha Elite & ALPG-Alpha Gold and billcode ID = 13(LCD) 
                    ' then Charge $14.95
                    'I hate to hard code but no other way to do for now.
                    'ADD RECRYSTAL LOGIC TO SKYTEL EG-Eagle 1 MODEL
                    'Lan Added on 06/30/2009. If ParentCompany is DriveCam and Billcode is Compact Flash or Shipping & handling then charge.
                    '*********************************************************************
                    If Me._CustID = 14 OrElse Me._CustID = 2507 OrElse Me._CustID = 2508 Then
                        If (_device("model_id") = 3 Or _device("model_id") = 2) And (BillCode = 13 Or BillCode = 1284 Or BillCode = 1288) Then
                            pPrice = 10.0   'Magic number
                        ElseIf (_device("model_id") = 786 Or _device("model_id") = 807 Or _device("model_id") = 2066) And (BillCode = 13 Or BillCode = 1284 Or BillCode = 1288) Then
                            'pPrice = 14.95   'Magic number
                            pPrice = dr(0)("PSPrice_StndCost")
                        ElseIf (_device("model_id") = 2 Or _device("model_id") = 7) And BillCode = 21 Then
                            pPrice = 1.5    'Magic number
                        End If
                    ElseIf (Me._CustID = 1545 OrElse Me._CustID = 2507 OrElse Me._CustID = 2508) And _device("model_id") = 14 And BillCode = 21 Then
                        pPrice = 1.5    'Magic number
                    ElseIf (_device("PCo_ID") = 734 Or _device("PCo_ID") = 737) And (BillCode = 1590 Or BillCode = 1591) Then
                        pPrice = dr(0)("PSPrice_StndCost")
                    End If
                    '*********************************************************************

                    'SET DEVICE TYPE
                    If BillCode = 255 Or BillCode = 1174 Then _noparts = True
                    If iBillcodeRule = 1 OrElse iBillcodeRule = 8 OrElse iBillcodeRule = 9 Then _dbr = True
                    If iBillcodeRule = 2 Then Me._NER = True
                    If iBillcodeRule = 6 Then _ntf = True

                    'GET EXCEPTION
                    dbExceptionItems = PSS.Data.Buisness.DeviceBilling.GetPartBillExceptionItem(_CustID, _device("wo_id"), _device("model_id"), BillCode)
                    If dbExceptionItems = 0 Then PSS.Data.Buisness.DeviceBilling.GetPartBillExceptionItem(_CustID, 0, _device("model_id"), BillCode)
                    If dbExceptionItems > 0 Then pPrice = dbExceptionItems

                    'This will be update when customer approve for repair ( END USER )
                    If Me.CustID = 2453 AndAlso Me._device("Device_ManufWrty").ToString = "0" Then pPrice = 0

                    '*********************************************************************
                    '2011-09-13 HARD CODE PRICE FOR THE FOLLOWING CONDITION
                    '1) Billcode(86): Battery -Backup
                    '2) Part #: mc621am
                    '3) Customer: 14 and 444 ( AMS and AQUIS )
                    '*********************************************************************
                    If dr(0)("PSPrice_Number").ToString.Trim.ToLower = "mc621am" AndAlso BillCode = 86 Then
                        If Me._CustID = 14 OrElse Me._CustID = 1545 OrElse Me._CustID = 2507 OrElse Me._CustID = 2508 Then    'AMS and Skytel
                            pPrice = 1.05
                        ElseIf Me._CustID = 444 Then    'Aquis customer
                            If Me._device("PoductGroup").ToString = "2" OrElse Me._device("PoductGroup").ToString = "81" OrElse Me._device("PoductGroup").ToString = "82" OrElse Me._device("PoductGroup").ToString = "83" OrElse Me._device("PoductGroup").ToString = "85" Then
                                pPrice = 1.15 'Alpha-Numeric pagers
                            ElseIf Me._device("PoductGroup").ToString = "27" OrElse Me._device("PoductGroup").ToString = "76" OrElse Me._device("PoductGroup").ToString = "79" OrElse Me._device("PoductGroup").ToString = "80" Then
                                'Numeric pager
                                Throw New Exception("Not allowed to bill this part for numeric pager.")
                            ElseIf Me._device("PoductGroup").ToString = "27" OrElse Me._device("PoductGroup").ToString = "76" OrElse Me._device("PoductGroup").ToString = "79" OrElse Me._device("PoductGroup").ToString = "80" Then
                                pPrice = 5.5  'Two way pagers
                            Else
                                'Page does not belong to any defined product group
                                Throw New Exception("Can not define price for this model.")
                            End If
                        End If
                    End If

                    '*********************************************************************

                    drNewPart = _parts.NewRow
                    drNewPart("DBill_RegPartPrice") = GetRegularPartPice(BillCode)
                    drNewPart("DBill_AvgCost") = dr(0)("PSPrice_AvgCost")
                    drNewPart("DBill_StdCost") = dr(0)("PSPrice_StndCost")
                    drNewPart("DBill_InvoiceAmt") = pPrice
                    drNewPart("Device_ID") = _ID
                    drNewPart("BillCode_ID") = BillCode
                    drNewPart("Fail_ID") = 0
                    drNewPart("Repair_ID") = 0
                    drNewPart("Comp_ID") = 0

                    If Me._device("Device_ManufWrty") = 1 AndAlso Me._device("Claimable") = 1 AndAlso (Me._iFailID > 0 Or Me._iRepairID > 0) Then
                        drNewPart("Fail_ID") = Me._iFailID
                        drNewPart("Repair_ID") = Me._iRepairID
                        drNewPart("Comp_ID") = Me._iComplainID
                    Else
                        If Not IsDBNull(dr(0)("Fail_ID")) Then drNewPart("Fail_ID") = dr(0)("Fail_ID")
                        If Not IsDBNull(dr(0)("Repair_ID")) Then drNewPart("Repair_ID") = dr(0)("Repair_ID")
                    End If
                    drNewPart("Part_Number") = dr(0)("PSPrice_Number")
                    drNewPart("User_ID") = PSS.Core.[Global].ApplicationUser.IDuser

                    DeviceBilling.UpdateParts(_ID, drNewPart)
                    _parts.Rows.Add(drNewPart)

                    '//Add the part transaction entry here
                    If addPartTransaction(BillCode, dr(0)("PSPrice_Number")) = False Then MsgBox("The ADD transaction for this billcode could not be processed.", MsgBoxStyle.Critical, "ERROR")
                    '//Add the part transaction entry here
                End If
            Catch ex As Exception
                Throw ex
            Finally
                dr = Nothing : drNewPart = Nothing
            End Try
        End Sub

        '*****************************************************************************************************************
        Private Function GetRegularPartPice(ByVal iBillcodeID As Integer) As Double
            Dim strRVPartNo, strRegPartNo As String
            Dim dbRegPartCost As Double = 0.0

            Try
                GetRegularPartPice = 0.0

                If Convert.ToInt32(Me._billable.Select("Billcode_ID = " & iBillcodeID)(0)("BillType_ID")) <> 2 Or Convert.ToInt32(Me._billable.Select("Billcode_ID = " & iBillcodeID)(0)("RVFlag")) = 0 Then
                    Return 0.0
                Else
                    strRVPartNo = "" : strRegPartNo = ""
                    strRVPartNo = Me._billable.Select("Billcode_ID = " & iBillcodeID)(0)("PSPrice_Number").ToString()
                    strRegPartNo = strRVPartNo.Trim.ToUpper.Replace("_RV", "")

                    If Me._CustID = 2258 AndAlso Me._billable.Select("PSPrice_Number = '" & strRegPartNo & "'").Length = 0 Then
                        Throw New Exception("Regular part does not map for this model.")
                    ElseIf Me._billable.Select("PSPrice_Number = '" & strRegPartNo & "'").Length > 0 Then
                        dbRegPartCost = Me._billable.Select("PSPrice_Number = '" & strRegPartNo & "'")(0)("PSPrice_StndCost")
                        'mark up
                        dbRegPartCost = Price(dbRegPartCost, Convert.ToInt32(Me._billable.Select("Billcode_ID = " & iBillcodeID)(0)("BillType_ID")))
                    End If
                End If

                Return dbRegPartCost
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************

        Public Sub DeletePart(ByVal BillCode As Integer)
            Dim blnTrans As Boolean = False
            Dim strMainBillcode_PN As String = ""
            Dim strAddInBillcode_PN As String = ""

            Try
                'Get PartNumber
                strMainBillcode_PN = PSS.Data.Buisness.Generic.GetPartNumberFrTdevicebill(BillCode, Me._ID)

                '*************************************************
                'Added by Lan on 02/29/2008
                'contingent billing
                '*************************************************
                If (Me._CustID = 14 And (Me._iModelID = 2 Or Me._iModelID = 7)) Or ((Me._CustID = 1545 OrElse Me._CustID = 2507 OrElse Me._CustID = 2508) And Me._iModelID = 14) Then
                    If BillCode = 20 Then     'Recrystaled(service)
                        strAddInBillcode_PN = PSS.Data.Buisness.Generic.GetPartNumberFrTdevicebill(21, Me._ID)
                        DeviceBilling.DeletePart(_ID, 21)
                        _parts.Rows.Remove(_parts.Select("BillCode_ID = 21")(0))
                        blnTrans = removePartTransaction(BillCode, strAddInBillcode_PN)
                        If blnTrans = False Then MsgBox("The REMOVE transaction for this billcode could not be processed.", MsgBoxStyle.Critical, "ERROR")
                    ElseIf BillCode = 21 Then 'Crystal Used(part)
                        strAddInBillcode_PN = PSS.Data.Buisness.Generic.GetPartNumberFrTdevicebill(20, Me._ID)
                        DeviceBilling.DeletePart(_ID, 20)
                        _parts.Rows.Remove(_parts.Select("BillCode_ID = 20")(0))
                        blnTrans = removePartTransaction(BillCode, strAddInBillcode_PN)
                    End If
                End If
                '*************************************************

                DeviceBilling.DeletePart(_ID, BillCode)
                _parts.Rows.Remove(_parts.Select("BillCode_ID = " & BillCode)(0))
                blnTrans = removePartTransaction(BillCode, strMainBillcode_PN)
                If blnTrans = False Then MsgBox("The REMOVE transaction for this billcode could not be processed.", MsgBoxStyle.Critical, "ERROR")
            Catch
                Throw New Exception("Unable to delete part.")
            End Try
        End Sub

        '*****************************************************************************************************************
        Public Function GetPartRule(ByVal iBillCodeID As Integer) As Integer '1 = DBR, 2 = NER, 3 = PhysDam, 4 = LCD
            Try
                Dim part As DataRow() = _billable.Select("BillCode_ID = " & iBillCodeID)
                If part.Length = 0 Then Throw New Exception("Billcode is missing in billable list.") Else Return part(0)("BillCode_Rule")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************
        Public Function GetPartTypeID(ByVal iBillCodeID As Integer) As Integer '1 = Service, 2 = Part
            Try
                Dim part As DataRow() = _billable.Select("BillCode_ID = " & iBillCodeID)
                If part.Length = 0 Then Throw New Exception("Billcode is missing in billable list.") Else Return part(0)("BillType_ID")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Shared Sub Print(ByVal Tray As Integer)
            InternalPrint("{tdevice.Tray_ID} = " & Tray)
        End Sub

        Public Sub Print()
            InternalPrint("{tdevice.Device_ID} = " & Trim(_ID))
        End Sub

        Private Shared Sub InternalPrint(ByVal SelectionFormula As String)
            'Dim rptApp As New CRAXDRT.Application()
            'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Bill_CreditCard.rpt")
            Dim objRpt As ReportDocument

            objRpt = New ReportDocument()

            With objRpt
                .Load(PSS.Core.[Global].ReportPath & "Bill_CreditCard.rpt")
                .RecordSelectionFormula = SelectionFormula
                .PrintToPrinter(2, True, 0, 0)
            End With

            'rpt.RecordSelectionFormula = SelectionFormula
            'rpt.PrintOut(False, 2)
            'rpt = Nothing
        End Sub

        Public Sub Clear()
            '    Try
            '        DeviceBilling.DeleteAllParts(_ID)

            '        Dim arrlstBillCodes As New ArrayList()
            '        Dim rowBillCodes As DataRow() = _parts.Select("Device_ID = " & Trim(_ID))
            '        Dim iIndex As Integer
            '        Dim strTemp As String

            '        For iIndex = 0 To rowBillCodes.Length - 1
            '            arrlstBillCodes.Add(rowBillCodes(iIndex)("BillCode_ID"))
            '        Next iIndex

            '        For iIndex = 0 To arrlstBillCodes.Count - 1
            '            strTemp = "Device_ID = " & Trim(_ID) & " AND BillCode_ID = " & CStr(arrlstBillCodes(iIndex))
            '            _parts.Rows.Remove(_parts.Select("Device_ID = " & Trim(_ID) & " AND BillCode_ID = " & CStr(arrlstBillCodes(iIndex)))(0))
            '        Next iIndex
            '    Finally
            '        _laborlevel = 0
            '        _dbr = False
            '        _ntf = False
            '        _noparts = False
            '    End Try
        End Sub

        '**************************************************************************************************
        Private Function DefineMaxLaborLevel() As Integer
            Dim R1, drArr() As DataRow
            Dim iMaxLaborLevel, iMaxLaborLevelID, iBillcodeLaborLevel As Integer

            Try
                iMaxLaborLevel = 0 : iMaxLaborLevelID = 13

                If Me._parts.Rows.Count > 0 Then
                    For Each R1 In _parts.Rows
                        drArr = _billable.Select("BillCode_ID = " & R1("BillCode_ID"))
                        iBillcodeLaborLevel = Convert.ToInt32(drArr(0)("LaborLevel"))

                        'Override labor level ( billcode : Recrystaled , Customer : Aquis)
                        If Me._CustID = 444 AndAlso R1("BillCode_ID").ToString.Trim = "20" Then iBillcodeLaborLevel = 0

                        If iBillcodeLaborLevel > iMaxLaborLevel Then
                            iMaxLaborLevel = CInt(drArr(0)("LaborLevel"))
                            iMaxLaborLevelID = CInt(drArr(0)("LaborLvl_ID"))
                        End If
                    Next R1
                End If

                Me._laborlevel = iMaxLaborLevel

                Return iMaxLaborLevelID
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : drArr = Nothing
            End Try
        End Function

        '**************************************************************************************************
        Public Function GetPartRepairLevel(ByVal iBillcodeID As Integer) As Integer
            Dim drArr() As DataRow
            Dim iRepairLevel As Integer = -1

            Try
                drArr = _billable.Select("BillCode_ID = " & iBillcodeID)
                If drArr.Length > 0 Then
                    iRepairLevel = CInt(drArr(0)("LaborLevel"))
                Else
                    Throw New Exception("Labor level is missing for billcode ID " & iBillcodeID)
                End If

                'Override labor level ( billcode : Recrystaled , Customer : Aquis)
                If Me._CustID = 444 AndAlso iBillcodeID.ToString.Trim = "20" Then iRepairLevel = 0

                Return iRepairLevel
            Catch ex As Exception
                Throw ex
            Finally
                drArr = Nothing
            End Try
        End Function

        '**************************************************************************************************
        Public Sub Update()
            Dim iMaxLaborLevelID As Integer
            Dim booNoPart As Boolean = True
            Dim drLabor As DataRow
            Dim dbRegLabor, dbManufClaimLabor As Double

            Try
                dbRegLabor = 0 : dbManufClaimLabor = 0
                Me.DefineDeviceStatus() : iMaxLaborLevelID = DefineMaxLaborLevel()
                '**********************************
                'added by Lan on 02/18/2009
                'RUR/NER/RTM price exception by customer and model
                '**********************************
                If _parts.Rows.Count > 0 Then
                    If Me._dbr = True OrElse _NER OrElse Me._ntf = True OrElse Me._RTM = True Then
                        Me.GetRURPriceException()
                    Else
                        If Me._labor.Rows.Count = 0 Then
                            Throw New Exception("There is not enough information to bill this device. " & vbCrLf & _
                                                            "There is no mapping between this product group and pricing." & vbCrLf & vbCrLf & _
                                                            "Please CONTACT CUSTOMER SERVICE.")
                        Else
                            Dim drLaborArr As DataRow()
                            If Me._device("PrcType_ID").ToString = "1" Then 'Tier
                                drLaborArr = _labor.Select("LaborLvl_ID = " & iMaxLaborLevelID)
                            Else 'Flat
                                drLaborArr = _labor.Select("LaborLvl_ID = 0")
                            End If

                            If drLaborArr.Length = 0 Then
                                Throw New Exception("No labor price set up for " & IIf(Me._device("PrcType_ID").ToString = "1", "labor level " & DeviceBilling.GetLaborLevelDescription(iMaxLaborLevelID) & ".", "flat rate."))
                            ElseIf drLaborArr.Length > 1 Then
                                Throw New Exception("No labor price set up for " & IIf(Me._device("PrcType_ID").ToString = "1", "labor level " & DeviceBilling.GetLaborLevelDescription(iMaxLaborLevelID) & ".", " flat rate."))
                            End If

                            drLabor = drLaborArr(0)
                        End If
                    End If

                    If _device("Device_PSSWrty") > 0 Then
                        dbRegLabor = lPSSPrice(drLabor)
                    ElseIf _device("PO_ID") > 0 Then
                        dbRegLabor = lCustomPrice(drLabor, dbManufClaimLabor)
                    ElseIf _device("Claimable").ToString = "1" AndAlso _device("Device_ManufWrty").ToString = "1" Then
                        dbManufClaimLabor = lManufPrice(drLabor, dbRegLabor)
                    Else
                        dbRegLabor = lRegPrice(drLabor)
                    End If
                End If

                '********************************************************************************************
                'Added by Lan on 02/29/2008
                'Add $3 to labor for any AMS AG & BF AND SkyTel: EG-Eagle 1 model with Recrystaled billcode
                '********************************************************************************************
                If (Me._CustID = 14 AndAlso (Me._iModelID = 2 Or Me._iModelID = 7)) Or ((Me._CustID = 1545 OrElse Me._CustID = 2507 OrElse Me._CustID = 2508) And Me._iModelID = 14) Then
                    Dim drArr() As DataRow = _parts.Select("BillCode_ID = 20")
                    If drArr.Length > 0 Then dbRegLabor += Convert.ToDouble(drArr(0)("DBill_StdCost"))
                End If
                '********************************************************************************************

                UpdatePrice(dbRegLabor, dbManufClaimLabor, _device("Device_PSSWrty"), _device("Device_ManufWrty"))
                DeviceBilling.SetBiller(PSS.Core.ApplicationUser.User, _device("Tray_ID"))

            Catch ex As Exception
                Throw ex
            Finally
                drLabor = Nothing
            End Try
        End Sub

        '*****************************************************************
        'Added by Lan on 06/29/2009
        'Move AggBilling billing logic into a separate function. 
        'Current code is messy.
        '*****************************************************************
        Public Function AggBilling() As Decimal
            Dim dsAB As PSS.Data.Production.Joins
            Dim dtAB, dtAggDefaultVal, dtPO As DataTable
            Dim abLabor As Decimal = 0
            Dim blnZero As Boolean
            Dim R1, R2 As DataRow
            Dim strAggBillCodeIDs As String = ""
            Dim retInt, ruleInt As Integer

            Try
                If _device("PO_ID") > 0 Then
                    dtPO = dsAB.OrderEntrySelect("SELECT * FROM tpurchaseorder WHERE PO_ID = " & _device("PO_ID"))

                    If dtPO.Rows.Count > 0 Then
                        If dtPO.Rows(0)("PO_Aggregate") = 1 Then
                            dtAB = dsAB.OrderEntrySelect("SELECT * FROM tpoaggregatebilling WHERE PO_ID = " & _device("PO_ID"))

                            If dtAB.Rows.Count > 0 Then
                                abLabor = 0.0

                                For Each R1 In _parts.Rows
                                    For Each R2 In dtAB.Rows
                                        If R1("BillCode_ID") = R2("BillCode_ID") Then
                                            abLabor += R2("tpab_Amount")
                                            If strAggBillCodeIDs.Length > 0 Then strAggBillCodeIDs &= ", "
                                            strAggBillCodeIDs &= R2("BillCode_ID")
                                        End If
                                    Next R2
                                Next R1

                                'UpdatePrice(abLabor, False, _device("Device_ManufWrty"))
                                If strAggBillCodeIDs.Trim.Length > 0 Then blnZero = dsAB.OrderEntryUpdateDelete("UPDATE tdevicebill set dbill_invoiceamt = 0.00 WHERE device_id = " & _ID & " AND billcode_ID in ( " & strAggBillCodeIDs & " )")
                            End If  'dtAB.Rows.Count > 0
                        End If
                    End If 'dtPO.Rows.Count > 0

                ElseIf _device("Cust_AggBilling") = 1 Then
                    dtAggDefaultVal = dsAB.OrderEntrySelect("SELECT * FROM tcust_model_aggbilling_default WHERE cust_id = " & _CustID & " AND model_id = " & Me._iModelID & ";")

                    'End user will use parent company
                    If Me._CreditUser = True Then
                        dtAB = dsAB.OrderEntrySelect("SELECT * FROM tpcoaggregatebilling WHERE PCo_ID = " & _device("PCo_ID"))
                    Else
                        dtAB = dsAB.OrderEntrySelect("SELECT * FROM tcustaggregatebilling WHERE Cust_ID = " & _device("Cust_ID"))
                    End If

                    If dtAB.Rows.Count > 0 Then
                        '****************************
                        'Added by Lan on 10/31/2007
                        'exception occur by Model ID
                        '****************************
                        For Each R1 In dtAggDefaultVal.Rows
                            For Each R2 In dtAB.Rows
                                If R1("billcode_id") = R2("BillCode_ID") Then
                                    R2.BeginEdit()
                                    R2("tcab_Amount") = R1("labor_charge")
                                    R2.EndEdit()
                                End If
                            Next R2
                        Next R1
                        dtAB.AcceptChanges()
                        '****************************

                        abLabor = 0.0
                        For Each R1 In _parts.Rows
                            For Each R2 In dtAB.Rows
                                If R1("BillCode_ID") = R2("BillCode_ID") Then
                                    abLabor += R2("tcab_Amount")
                                    If strAggBillCodeIDs.Length > 0 Then strAggBillCodeIDs &= ", "
                                    strAggBillCodeIDs &= R2("BillCode_ID")
                                End If
                            Next R2
                        Next R1

                        'UpdatePrice(abLabor, False, _device("Device_ManufWrty"))
                        If strAggBillCodeIDs.Trim.Length > 0 Then blnZero = dsAB.OrderEntryUpdateDelete("UPDATE tdevicebill set dbill_invoiceamt = 0.00 WHERE device_id = " & _ID & " AND billcode_ID in ( " & strAggBillCodeIDs & " )")
                    End If
                End If

                Return abLabor
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtAggDefaultVal)
                Generic.DisposeDT(dtAB)
                Generic.DisposeDT(dtPO)
                dsAB = Nothing
                R1 = Nothing : R2 = Nothing
            End Try
        End Function

        '*****************************************************************
        'Added by Lan on 02/182009
        'Normally all customer will have same RUR/NER/RTM/NTF.. price for all models
        'but some are not. In that case this function will get those exception
        ''*****************************************************************
        Private Sub GetRURPriceException()
            Dim dt As DataTable

            Try
                dt = Generic.GetRURPriceException(Me._CustID, Me._iModelID)
                If dt.Rows.Count > 0 Then
                    Me._device.BeginEdit()
                    Me._device("RUR_Price") = dt.Rows(0)("RP_RUR")
                    Me._device("NER_Price") = dt.Rows(0)("RP_NER")
                    Me._device("NTF_Price") = dt.Rows(0)("RP_NTF")
                    Me._device("RTM_Price") = dt.Rows(0)("RP_RTM")
                    Me._device.EndEdit()
                    Me._device.AcceptChanges()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GetRURPriceException", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*****************************************************************
        'Added by Lan on 02/12/2010 : Normalize function Update()
        ''*****************************************************************
        Private Function GetMaxBillRule() As Integer
            Dim i, iBillRule, iMaxBillRule As Integer

            Try
                i = 0 : iBillRule = 0 : iMaxBillRule = 0
                For i = 0 To _parts.Rows.Count - 1
                    iBillRule = Me.GetPartRule(_parts.Rows(i)("Billcode_ID"))
                    If iBillRule > iMaxBillRule Then iMaxBillRule = iBillRule
                Next i

                Return iMaxBillRule
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GetMaxBillRule", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        '*****************************************************************
        'Chec to see if device is no part. This definition only apply to ATCLE customer
        '*****************************************************************
        Private Function IsATCLE_NoPart_Definition() As Boolean
            Try
                If Me._parts.Select("Billcode_ID <> 447 AND Billcode_ID <> 448 AND Billcode_ID <> 255").Length = 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************
        'Flag unit either RUR, RTM, NTF, No parts.....
        '*****************************************************************
        Private Sub DefineDeviceStatus()
            Dim iMaxBillRule As Integer = 0

            Try
                If Me._CustID = 2019 AndAlso Me.IsATCLE_NoPart_Definition() = True Then
                    Me._noparts = True
                ElseIf _parts.Select("BillCode_ID = 255").Length > 0 Then
                    _noparts = True
                ElseIf _parts.Select("BillCode_ID = 1174").Length > 0 Then
                    _noparts = True
                Else
                    Me._noparts = False
                End If

                iMaxBillRule = Me.GetMaxBillRule()
                If iMaxBillRule = 1 OrElse iMaxBillRule = 3 OrElse iMaxBillRule = 8 Then
                    _dbr = True
                ElseIf iMaxBillRule = 2 Then
                    _NER = True
                ElseIf Me._CustID = 2019 AndAlso iMaxBillRule = 9 Then
                    Me._RTM = True
                ElseIf iMaxBillRule = 6 Then
                    Me._ntf = True
                Else
                    _dbr = False : _NER = False : _RTM = False : _ntf = False
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*****************************************************************

        'Private Sub ManufWrty()
        '    DeviceBilling.InsertWarranty(_ID, _billable.Rows(0)("ASCPrice_Price"), _billable.Rows(0)("ASCPrice_ID"), _
        '                                            _billable.Rows(0)("Prod_ID"), _billable.Rows(0)("Manuf_ID"))
        'End Sub

        '***********************************************************************************************************
        Private Function addPartTransaction(ByVal iBillcode As Integer, ByVal strPartNumber As String) As Boolean
            Const iTransactionAmount As Integer = 1
            Dim blnInsert As Boolean = False
            Dim i As Integer = 0

            Try
                i = DeviceBilling.InsertPartTransaction(Me._ID, iBillcode, ApplicationUser.IDuser, ApplicationUser.NumberEmp, ApplicationUser.IDShift, strPartNumber, iTransactionAmount, Me._iScreenID)
                If i > 0 Then blnInsert = True

                Return blnInsert
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************************
        Private Function removePartTransaction(ByVal iBillcode As Integer, _
                                               ByVal strPartNumber As String) As Boolean
            Const iTransactionAmount As Integer = -1
            Dim blnInsert As Boolean = False
            Dim i As Integer = 0

            Try
                i = DeviceBilling.InsertPartTransaction(Me._ID, iBillcode, ApplicationUser.IDuser, ApplicationUser.NumberEmp, ApplicationUser.IDShift, strPartNumber, iTransactionAmount, Me._iScreenID)
                If i > 0 Then blnInsert = True

                Return blnInsert
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************
        'Added by Lan on 06/30/2009
        Public Function GetParentCompID() As Integer
            Try
                If IsNothing(Me._device) Then Return 0 Else Return Me._device("PCo_ID")
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************
        Public Sub ReFreshPartMapBOM()
            Try
                _billable = DeviceBilling.GetPartData(_device("Model_ID"))
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************

#End Region

#Region "Parts"
        Private Function Price(ByVal StandardPrice As Object, ByVal Type As Integer) As Double
            If IsDBNull(StandardPrice) Then
                Return 0.0
            ElseIf Type = 1 Then 'Service
                Return StandardPrice
            ElseIf Type = 2 Then 'Part
                Return Math.Round((StandardPrice * (_device("Cust_Markup") + 1) + 0.00499), 2)
            Else 'Everything else
                Return Math.Round((StandardPrice * (_device("Cust_Markup") + 1) + 0.00499), 2)
            End If

        End Function

        Private Function Zero() As Double
            Return 0.0
        End Function

        'Private Function pCustomPrice(ByVal datarow As DataRow) As Double
        '    If _device("PlusParts").ToString = "1" Then
        '        Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
        '    Else
        '        Return Zero()
        '    End If
        'End Function

        Private Function pPSSPrice(ByVal datarow As DataRow) As Double
            If _device("PSSWrtyParts_ID") = 1 Then  'No Warranty
                Return pRegPrice(datarow)
            ElseIf _device("PSSWrtyParts_ID") = 2 Then 'No Charge
                Return Zero()
            ElseIf _device("PSSWrtyParts_ID") = 3 Then 'Charge Parts
                ' Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
                pRegPrice(datarow)
            End If
        End Function

        '*****************************************************************************************************************
        'Private Function pManufPrice(ByVal datarow As DataRow) As Double
        '    If datarow("BillCode_Rule") = 3 And _device("Device_ManufWrty") <> 2 Then
        '        If _device("Cust_RepairNonWrty") Then
        '            Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
        '        Else
        '            Return Zero()
        '        End If
        '    Else
        '        'If _device("PlusParts") Then
        '        'Return pRegPrice(datarow)
        '        'Else
        '        '    Return Zero()
        '        'End If

        '        ''**********************************************
        '        ''LAN COMMENT ON 11/07/2009
        '        ''WHY NO PART CHARGE FOR CELLULAR PRODUCT??????
        '        ''**********************************************
        '        ''If _device("Prod_ID") = 2 Then
        '        ''    Return Zero()
        '        ''Else
        '        If _device("PlusParts") Then
        '            '//New Craig Haney May 19, 2004
        '            If _device("Device_ManufWrty") > 0 Then
        '                Return Zero()
        '            Else
        '                Return pRegPrice(datarow)
        '            End If
        '            '//New Craig Haney May 19, 2004
        '        Else
        '            Return Zero()
        '        End If
        '        ''End If

        '        ''**********************************************
        '    End If
        'End Function

        '*****************************************************************************************************************
        Private Function pRegPrice(ByVal datarow As DataRow) As Double
            Dim iBillExpepTypeID As Integer = 0

            Try
                If _device("Cust_RepairNonWrty").ToString = "1" OrElse (_device("Cust_RepairNonWrty").ToString = "0" AndAlso _device("Device_ManufWrty").ToString = "1") Then
                    If _device("PlusParts").ToString = "0" Then 'No Charge (Flat Rate part)
                        iBillExpepTypeID = DeviceBilling.GetExcepCode(datarow("BillCode_ID"), _device("PoductGroup"), _device("PricingGroup"))
                        If iBillExpepTypeID > 0 Then
                            Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
                        ElseIf Me.GetPartRule(datarow("BillCode_ID")) = 4 AndAlso Me._device("Cust_ReplaceLCD").ToString.Equals("1") Then
                            'Flat rate part but allow replace LCD 
                            Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
                        Else
                            Return Zero()
                        End If
                    ElseIf _device("PlusParts").ToString = "1" Then 'Charge Part for All Level
                        Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
                    ElseIf _device("PlusParts").ToString = "2" Then 'Charge part if repair level is 2 and Up
                        If Convert.ToInt32(datarow("LaborLevel")) >= 2 Then Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID")) Else Return Zero()
                    Else
                        Throw New Exception("System can't define part rate.")
                    End If
                Else
                    Throw New Exception("Not allowed to repair out of warranty product.")
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************************************************

#End Region

#Region "Labor"
        '***********************************************************************************************
        Private Sub UpdatePrice(ByVal dbRegLabor As Double, ByVal dbManufWrtyLabor As Double, ByVal iPSSWrty As Integer, ByVal iManufWrty As Integer)
            Dim aship As Boolean = False
            Dim decServiceCharge As Decimal = 0.0
            Dim decPartCostMarkup As Decimal = 0.0
            Dim decAggCharge As Decimal = 0.0
            Dim dbOWRepPartCharge, dbIWRepPartCharge As Double

            Try
                dbOWRepPartCharge = 0 : dbIWRepPartCharge = 0
                If _device("Cust_AutoShip") = 1 AndAlso Me._dbr = True Then aship = True

                If _parts.Rows.Count = 0 Then
                    DeviceBilling.SetLaborData(_ID, dbRegLabor, dbManufWrtyLabor, dbOWRepPartCharge, dbIWRepPartCharge, iPSSWrty, iManufWrty, 0, "NULL", aship, _device("Loc_Id"), ApplicationUser.IDShift)
                Else
                    '********************************************************************
                    'Get part charge
                    '********************************************************************
                    If _device("Claimable").ToString = "1" AndAlso iManufWrty = 1 Then
                        dbOWRepPartCharge = DeviceBilling.GetOWRepPartsCharge(_ID)
                        dbIWRepPartCharge = DeviceBilling.GetIWRepPartsCharge(_ID)
                    Else
                        dbOWRepPartCharge = DeviceBilling.GetTotalPartsCharge(_ID)
                    End If
                    '********************************************************************
                    decAggCharge = AggBilling()
                    decServiceCharge = DeviceBilling.GetServiceCharge(Me._ID, Me._CustID)
                    If Me._CustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then decPartCostMarkup = DeviceBilling.GetNonWrtyPartCostMarkUp(Me._ID, Me._CustID, Me._iModelID, Me._device("Device_ManufWrty"))

                    dbRegLabor += decServiceCharge + decPartCostMarkup + decAggCharge
                    dbRegLabor = Math.Round((dbRegLabor * Convert.ToInt16(Me._device("Device_Qty"))) + 0.00499, 2)

                    DeviceBilling.SetLaborData(_ID, dbRegLabor, dbManufWrtyLabor, dbOWRepPartCharge, dbIWRepPartCharge, iPSSWrty, iManufWrty, _laborlevel, PSS.Gui.Receiving.FormatDate(Now), aship, _device("Loc_Id"), ApplicationUser.IDShift)
                End If
                aship = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***********************************************************************************************
        Private Function lCustomPrice(ByVal drLabor As DataRow, ByRef dbManufClaimLabor As Double) As Double
            Dim dbPOLaborPrice As Double = 0

            Try
                If _dbr Then
                    If IsDBNull(_device("PO_RUR")) Then Throw New Exception("RUR/DBR price is missing for PO # " & _device("PO_ID")) Else dbPOLaborPrice = _device("PO_RUR")
                    If _device("Claimable").ToString = "1" AndAlso _device("Device_ManufWrty").ToString = "1" _
                        AndAlso _device("PO_ChgWrty").ToString = "1" AndAlso Convert.ToDouble(_device("Claimable_RURCharge")) > 0 Then
                        dbManufClaimLabor = Convert.ToDouble(_device("Claimable_RURCharge"))
                    End If
                ElseIf _NER Then
                    If IsDBNull(_device("PO_NER")) Then Throw New Exception("NER price is missing for PO # " & _device("PO_ID")) Else dbPOLaborPrice = Convert.ToDouble(_device("PO_NER"))
                ElseIf _RTM Then
                    If IsDBNull(_device("PO_RTM")) Then Throw New Exception("RTM price is missing for PO # " & _device("PO_ID")) Else dbPOLaborPrice = Convert.ToDouble(_device("PO_RTM"))
                ElseIf _device("Claimable").ToString = "1" AndAlso _device("Device_ManufWrty").ToString = "1" Then
                    dbManufClaimLabor = Me.lManufPrice(drLabor, dbPOLaborPrice)
                Else
                    dbPOLaborPrice = Me.lRegPrice(drLabor)
                End If
                Return dbPOLaborPrice
            Catch ex As Exception
                Throw ex
            Finally
                drLabor = Nothing
            End Try
        End Function

        '***********************************************************************************************
        Private Function lPSSPrice(ByVal drLabor As DataRow) As Double
            Dim dbPSSWtyLaborPrice As Double = 0
            Try
                If _dbr Then
                    dbPSSWtyLaborPrice = Convert.ToDouble(_device("RUR_Price"))
                ElseIf _NER Then
                    dbPSSWtyLaborPrice = Convert.ToDouble(_device("NER_Price"))
                ElseIf _ntf Then
                    dbPSSWtyLaborPrice = Convert.ToDouble(_device("NTF_Price"))
                ElseIf Me._RTM Then
                    dbPSSWtyLaborPrice = Convert.ToDouble(_device("RTM_Price"))
                Else
                    If _device("PSSWrtyLabor_ID") = 1 Then 'No Warranty
                        dbPSSWtyLaborPrice = lRegPrice(drLabor)
                    ElseIf _device("PSSWrtyLabor_ID") = 2 Then  'No Charge
                        dbPSSWtyLaborPrice = 0
                    ElseIf _device("PSSWrtyLabor_ID") = 4 Then 'Level 3 No Charge
                        If Me._laborlevel < 3 Then
                            dbPSSWtyLaborPrice = lRegPrice(drLabor)
                        Else
                            dbPSSWtyLaborPrice = 0
                        End If
                    End If
                End If

                Return dbPSSWtyLaborPrice
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************
        Private Function lManufPrice(ByVal drLabor As DataRow, ByRef dbRegLabor As Double) As Double
            Dim dbManufClaimLabor As Double = 0

            Try
                If _dbr Then
                    dbRegLabor = Convert.ToDouble(_device("RUR_Price"))
                    If _device("Claimable").ToString = "1" AndAlso _device("Device_ManufWrty").ToString = "1" AndAlso Convert.ToDouble(_device("Claimable_RURCharge")) > 0 Then
                        dbManufClaimLabor = Convert.ToDouble(_device("Claimable_RURCharge"))
                    End If
                ElseIf _NER Then
                    dbRegLabor = Convert.ToDouble(_device("NER_Price"))
                ElseIf _ntf Then
                    'Throw New Exception("Not allowed to bill NTF for warranty device.")
                    dbRegLabor = Convert.ToDouble(_device("NTF_Price"))
                ElseIf Me._RTM Then
                    dbRegLabor = Convert.ToDouble(_device("RTM_Price"))
                Else
                    dbManufClaimLabor = Convert.ToDouble(drLabor("LaborPrc_WrtyPrc"))
                    If _device("markup_PlusRepl").ToString = "1" Then
                        Dim dbReplaceCharge As Double = DeviceBilling.GetReplaceItemCharge(_ID)
                        dbManufClaimLabor += dbReplaceCharge
                    End If
                End If

                Return dbManufClaimLabor
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************
        Private Function lRegPrice(ByVal drLabor As DataRow) As Double
            Dim dbRegLabor As Double = 0

            Try
                If _device("Cust_RepairNonWrty").ToString = "1" OrElse (_device("Cust_RepairNonWrty").ToString = "0" AndAlso _device("Device_ManufWrty").ToString = "1") Then
                    If _dbr Then
                        dbRegLabor = Convert.ToDouble(_device("RUR_Price"))
                    ElseIf _NER Then
                        dbRegLabor = Convert.ToDouble(_device("NER_Price"))
                    ElseIf Me._RTM Then
                        dbRegLabor = Convert.ToDouble(_device("RTM_Price"))
                    ElseIf _ntf Then
                        dbRegLabor = Convert.ToDouble(_device("NTF_Price"))
                    Else
                        dbRegLabor = Convert.ToDouble(drLabor("LaborPrc_RegPrc"))
                    End If
                Else
                    Throw New Exception("Not allowed to repair out of warranty product.")
                End If

                Return dbRegLabor
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***********************************************************************************************

#End Region

#Region "Properties"
        Public ReadOnly Property DefaultView() As DataView
            Get
                Return _parts.DefaultView
            End Get
        End Property

        Public ReadOnly Property Billed() As Boolean
            Get
                If IsDate(_device("Device_DateBill")) Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Public ReadOnly Property ID() As Integer
            Get
                Return _ID
            End Get
        End Property

        Public ReadOnly Property Parts() As DataTable
            Get
                Return _parts
            End Get
        End Property

        Public ReadOnly Property EndUser() As Boolean
            Get
                Return Me._CreditUser
            End Get
        End Property

        Public ReadOnly Property Customer() As String
            Get
                Return Me._cust
            End Get
        End Property

        'Added by Asif
        Public ReadOnly Property CustID() As String
            Get
                Return Me._CustID
            End Get
        End Property

        '*******************************************
        Public WriteOnly Property FailID() As Integer
            Set(ByVal Value As Integer)
                Me._iFailID = Value
            End Set
        End Property

        Public WriteOnly Property RepairID() As Integer
            Set(ByVal Value As Integer)
                Me._iRepairID = Value
            End Set
        End Property
        Public WriteOnly Property ComplainID() As Integer
            Set(ByVal Value As Integer)
                Me._iComplainID = Value
            End Set
        End Property

        Public ReadOnly Property ManufWarantyClaimable() As Integer
            Get
                Return Me._device("Claimable")
            End Get
        End Property
        Public ReadOnly Property CustRepNonWrty() As Integer
            Get
                Return Me._device("Cust_RepairNonWrty")
            End Get
        End Property
        Public ReadOnly Property CustReplaceLCD() As Integer
            Get
                Return Me._device("Cust_ReplaceLCD")
            End Get
        End Property
        Public ReadOnly Property ManufWarranty() As Integer
            Get
                Return Me._device("Device_ManufWrty")
            End Get
        End Property
        Public ReadOnly Property PSSWarrantyID() As Integer
            Get
                Return Me._device("PSSWrtyParts_ID")
            End Get
        End Property
        Public ReadOnly Property CustMarkUp() As Decimal
            Get
                Return Me._device("Cust_Markup")
            End Get
        End Property

        '*******************************************
        'Added by Lan 06/26/2009
        Public ReadOnly Property RUR_DBR() As Boolean
            Get
                Return Me._dbr
            End Get
        End Property
        '*******************************************
        'Added by Lan 08/07/2012
        Public ReadOnly Property NEr() As Boolean
            Get
                Return Me._NER
            End Get
        End Property

        '*******************************************
        'Added by Lan 06/26/2009
        Public ReadOnly Property BillableBillcodes() As DataTable
            Get
                Return Me._billable
            End Get
        End Property

        '*******************************************
        Public WriteOnly Property ScreenID()
            Set(ByVal Value)
                Me._iScreenID = Value
            End Set
        End Property

        '*******************************************
        Public ReadOnly Property NTF() As Boolean
            Get
                Return _ntf
            End Get
        End Property

        '*******************************************

#End Region

    End Class
End Namespace