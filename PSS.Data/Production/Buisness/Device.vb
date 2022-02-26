
Namespace Buisness

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
        '// Will we submit a warranty claim
        Private _wrnty As Boolean = False
        '// Store Customer Name for information
        Private _cust As String = Nothing
        '// Tell us if we have an end user or not.
        Private _CreditUser As Boolean = False
        '// Cust_ID     'Added by Asif
        Private _CustID As Integer = 0

        Private vFailureCode As Int32 = 0
        Private vckManufWrty As Integer = 0
        Private blnFailureCode As Boolean = False

#End Region

#Region "Constructors / Destructors"

        Private Sub New()
        End Sub

        Public Sub New(ByVal Device As Integer)
            InternalConstruct(Device)
        End Sub

        '*********************************************************************
        Private Sub InternalConstruct(ByVal Device As Integer)
            Try
                _ID = Device
                _device = DeviceBilling.GetDeviceData(Device)
                _parts = DeviceBilling.GetBilledData(Device)

                'MsgBox(_device("Pricinggroup").ToString)
                'MsgBox(_device("Poductgroup").ToString)

                _labor = DeviceBilling.GetLaborData(_device("PricingGroup"), _device("PoductGroup"))
                _billable = DeviceBilling.GetPartData(_device("Model_ID"))
                _laborlevel = _device("Device_LaborLevel")

                Dim r As DataRow
                For Each r In _parts.Rows
                    If CheckPartRule(r("BillCode_ID")) = 1 Or CheckPartRule(r("BillCode_ID")) = 2 Then _dbr = True
                    If r("BillCode_ID") = 0 Then _noparts = True
                Next
                If _device("Pay_ID") = 2 Then
                    Me._CreditUser = True
                End If
                If Me._CreditUser = False Then
                    _cust = _device("Loc_Name")
                Else
                    _cust = _device("Cust_Name1") & " " & _device("Cust_Name2")
                End If

                '//Added by Asif
                _CustID = _device("Cust_ID")

            Catch e As Exception

                MsgBox(e.ToString)

                Me.Dispose()
                MsgBox("There is not enough data to bill this device.", MsgBoxStyle.Information, "Error")
                Exit Sub
            End Try
        End Sub

        '*********************************************************************
        Public Sub Open(ByVal Device As Integer)
            InternalConstruct(Device)
        End Sub

        '*********************************************************************
        Public Sub Close()
            InteralDestruct()
        End Sub

        '*********************************************************************
        Public Sub Dispose()
            InteralDestruct()
        End Sub

        '*********************************************************************
        Private Sub InteralDestruct() Implements IDisposable.Dispose
            _device = Nothing
            _parts = Nothing
            _labor = Nothing
            _billable = Nothing
            _laborlevel = Nothing
            _dbr = False
            _noparts = False
            _wrnty = False
            _cust = Nothing
            Me._CreditUser = False
        End Sub

        '*********************************************************************
#End Region


#Region "Methods"

        '*********************************************************************
        Private Sub CheckForFlatRate(ByVal BillCode As Integer, ByVal CustID As Integer)
            MsgBox(_device("Model_ID"))
            MsgBox(_device("Cust_ID"))
            MsgBox(BillCode)
        End Sub

        '*********************************************************************
        Public Sub AddPart(ByVal BillCode As Integer, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String)
            InternalAddPart(BillCode, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
        End Sub

        '*********************************************************************
        Public Sub AddPart(ByVal BillCode As Integer, ByVal Comment As Integer, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String)
            InternalAddPart(BillCode, Comment, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
        End Sub

        '*********************************************************************
        Public Sub AddPartCELL(ByVal BillCode As Integer, ByVal FailureCode As Integer, ByVal vMW As Integer, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String)
            vFailureCode = 0
            vFailureCode = FailureCode

            Try
                If vMW = 1 Then
                    '//Invalidate Manufacturer Warranty
                    _device("Device_ManufWrty") = 0
                End If

                'If vckManufWrty = 1 Then
                'If _ID > 0 Then
                '    Dim blnChange As Boolean = PSS.Data.Production.tdevice.UpdateManufWrtyOUT(_ID)
                '    _device("Device_ManufWrty") = 0
                'End If
                'End If

                blnFailureCode = False
                InternalAddPart(BillCode, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub InternalAddPart(ByVal BillCode As Integer, ByVal Comment As Integer, _
                                    ByVal iUser_ID As Integer, _
                                    ByVal iEmpNo As Integer, _
                                    ByVal iShift_ID As Integer, _
                                    ByVal strWorkDate As String)

            If IsNumeric(BillCode) = False Then Exit Sub

            If Me.CustID <> 2242 And (CheckPartRule(BillCode) = 1 Or CheckPartRule(BillCode) = 2 Or BillCode = 0) Then
                If _parts.Rows.Count > 1 Then Throw New Exception("If you wish to RUR/NER or NO PART this device first clear all other parts.") : Exit Sub
            End If

            If _dbr Then Throw New Exception("This Device is a RUR/NER you CANNOT add parts to a RUR/NER.") : Exit Sub
            If _ntf Then Throw New Exception("This Device is a NTF you CANNOT add parts to a NTF.") : Exit Sub

            If _noparts Then Throw New Exception("This Device has NO PARTS you CANNOT add parts to it.") : Exit Sub

            Dim _dr As DataRow() = _parts.Select("BillCode_ID = " & BillCode)

            If _dr.Length > 0 Then Throw New Exception("This part has ALREADY been added to this device.") : Exit Sub

            _dr = _billable.Select("BillCode_ID = " & BillCode)

            If _dr.Length <> 1 Then Throw New Exception("This part is NOT a valid part for this device.") : Exit Sub

            Dim pPrice As Double = 0.0


            'Craig Haney - This code is new it determined the Failure Code Value
            '              and will override the Manufacturer Warranty if Failure Code
            '              Dcode+ChrgCust is set to 1 (CELL ONLY)
            blnFailureCode = False
            Try
                Dim dtCCust As New PSS.Data.Production.lcodesdetail()
                Dim drCCust As DataRow = dtCCust.GetChargeCust(vFailureCode)
                If drCCust("Dcode_ChrgCust") = 1 Then blnFailureCode = True
            Catch ex As Exception
                'Failure occurs because device is not cellular. Nothing to display just continue
            End Try
            'Craig Haney - END

            Try
                If _device("PO_ID") > 0 Then
                    pPrice = pCustomPrice(_dr(0))
                ElseIf _device("Device_PSSWrty") Then
                    pPrice = pPSSPrice(_dr(0))
                ElseIf _device("Device_ManufWrty") > 0 Then
                    'Craig Haney - use blnChargeCust
                    If blnFailureCode = True Then
                        pPrice = pRegPrice(_dr(0))

                    Else

                        pPrice = pManufPrice(_dr(0))
                    End If
                    'Craig Haney - END
                Else
                    pPrice = pRegPrice(_dr(0))
                End If
            Catch ex As Exception
                Throw New Exception("There is not enough information to bill this device. Please CONTACT CUSTOMER SERVICE.")
            End Try

            If BillCode = 0 Then _noparts = True

            If CheckPartRule(BillCode) = 1 Or CheckPartRule(BillCode) = 2 Or CheckPartRule(BillCode) = 8 Or CheckPartRule(BillCode) = 9 Then _dbr = True
            If CheckPartRule(BillCode) = 6 Then _ntf = True

            '//Febraury 17, 2006
            '//This new section is to read the exception table and determine if there is an override price
            '//for a particular customer - model - billcode
            Dim dsExcept As PSS.Data.Production.Joins
            Dim dtExcept As DataTable
            Dim dsSQL As String
            Dim dsCount As Integer
            Dim dsR As DataRow
            Dim dsPrice As Double = 0
            '//See if there is a exception record under this customer/workorder
            dsSQL = "SELECT * FROM texceptionbillitems WHERE Cust_ID = " & _CustID & " AND WO_ID = " & _device("wo_id") & " AND Model_ID = " & _device("model_id")
            dtExcept = dsExcept.OrderEntrySelect(dsSQL)
            System.Windows.Forms.Application.DoEvents()
            If dtExcept.Rows.Count > 0 Then
                '//Get value if billcode is listed
                For dsCount = 0 To dtExcept.Rows.Count - 1
                    dsR = dtExcept.Rows(dsCount)
                    If dsR("Billcode_ID") = BillCode Then
                        dsPrice = dsR("Price_Amount")
                        Exit For
                    End If
                Next
            Else
                '//See if record exist for customer
                dsSQL = "SELECT * FROM texceptionbillitems WHERE Cust_ID = " & _CustID & " AND WO_ID = 0 AND Model_ID = " & _device("model_id")
                dtExcept = dsExcept.OrderEntrySelect(dsSQL)
                System.Windows.Forms.Application.DoEvents()
                If dtExcept.Rows.Count > 0 Then
                    '//Get value if billcode is listed
                    For dsCount = 0 To dtExcept.Rows.Count - 1
                        dsR = dtExcept.Rows(dsCount)
                        If dsR("Billcode_ID") = BillCode Then
                            dsPrice = dsR("Price_Amount")
                            Exit For
                        End If
                    Next
                End If
            End If

            If dsPrice > 0 Then pPrice = dsPrice
            '//END OF NEW SECTION
            '//Febraury 17, 2006

            Dim _r As DataRow = _parts.NewRow
            _r("DBill_RegPartPrice") = 0
            _r("DBill_AvgCost") = _dr(0)("PSPrice_AvgCost")
            _r("DBill_StdCost") = _dr(0)("PSPrice_StndCost")
            _r("DBill_InvoiceAmt") = pPrice
            _r("Device_ID") = _ID
            _r("BillCode_ID") = BillCode
            _r("Fail_ID") = _dr(0)("Fail_ID")
            _r("Repair_ID") = _dr(0)("Repair_ID")
            _r("Comp_ID") = 0
            _r("User_ID") = iUser_ID

            DeviceBilling.UpdateParts(_ID, _r)

            _parts.Rows.Add(_r)

            '//Add the part transaction entry here
            Dim blnTrans As Boolean = addPartTransaction(BillCode, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            If blnTrans = False Then MsgBox("The ADD transaction for this billcode could not be processed.", MsgBoxStyle.Critical, "ERROR")
            '//Add the part transaction entry here

            '//This is where to place the code to determine if dbr percentage if enough to charge a labor charge to this device
            '//START
            If _CustID = 2069 Then
                '//Customer is AWS, Inc.
                If _dbr = True Then
                    '//Device is being DBR'd
                    '//Determine percentage of dbr against total number in workorder
                    Dim ctDT As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT COUNT(Device_ID) as woTotal FROM tdevice WHERE WO_ID = " & _device("wo_id") & " GROUP BY WO_ID")
                    Dim rDT As DataRow = ctDT.Rows(0)

                    Dim dbrSQL As String = "SELECT distinct COUNT(tdevice.device_ID) as dbrTotal FROM tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevice.wo_id = " & _device("WO_ID") & " AND lbillcodes.billcode_rule in (1,2)"
                    Dim dbrDT As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(dbrSQL)
                    Dim rDBR As DataRow = dbrDT.Rows(0)

                    Dim valMargin As Integer = CInt(rDT("woTotal")) * 0.2

                    'MsgBox("Margin Value: " & valMargin & " DBR Number: " & CInt(rDBR("dbrTotal")))

                    If CInt(rDBR("dbrTotal")) > valMargin Then
                        '//Dbr margin has been exceeded
                        If _ID > 0 Then
                            '//Update the laborlevel value
                            Dim strUpdateLL As String = "UPDATE tdevice SET device_laborcharge = 6.50 WHERE Device_ID = " & _ID
                            Dim blnLLchange As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strUpdateLL)
                            System.Windows.Forms.Application.DoEvents()
                            blnLLchange = Nothing
                        End If
                    End If
                    dbrDT = Nothing
                    ctDT = Nothing
                End If
            End If
            '//END

            _dr = Nothing
        End Sub

        '*******************************************************************************
        Public Sub DeletePart(ByVal BillCode As Integer, _
                            ByVal iUser_ID As Integer, _
                            ByVal iEmpNo As Integer, _
                            ByVal iShift_ID As Integer, _
                            ByVal strWorkDate As String)
            Try
                DeviceBilling.DeletePart(_ID, BillCode)
                _parts.Rows.Remove(_parts.Select("BillCode_ID = " & BillCode)(0))
                '//Add the part transaction entry here
                Dim blnTrans As Boolean = removePartTransaction(BillCode, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                If blnTrans = False Then MsgBox("The REMOVE transaction for this billcode could not be processed.", MsgBoxStyle.Critical, "ERROR")
                '//Add the part transaction entry here
            Catch
                Throw New Exception("Unable to delete part.")
            End Try
        End Sub

        '*******************************************************************************
        Private Function CheckPartRule(ByVal BillCode As Integer) As Integer '1 = DBR, 2 = NER, 3 = PhysDam
            Try
                Dim __part As DataRow() = _billable.Select("BillCode_ID = " & BillCode)
                Return __part(0)("BillCode_Rule")
            Catch
                Throw New Exception("This part is NOT a valid part for this device.")
            End Try
        End Function

        '*******************************************************************************
        Private Sub _parts_RowDeleted(ByVal sender As Object, ByVal e As DataRowChangeEventArgs) Handles _parts.RowDeleting
            If e.Row.ItemArray(4) = 25 Then
                _dbr = False
            End If

            If e.Row.ItemArray(4) = 533 Then
                _ntf = False
            End If

            If e.Row.ItemArray(4) = 541 Then
                _ntf = False
            End If

            If e.Row.ItemArray(4) = 0 Then
                _noparts = False
            End If
        End Sub

        ''*******************************************************************************
        'Public Shared Sub Print(ByVal Tray As Integer)
        '    InternalPrint("{tdevice.Tray_ID} = " & Tray)
        'End Sub

        ''*******************************************************************************
        'Public Sub Print()
        '    InternalPrint("{tdevice.Device_ID} = " & Trim(_ID))
        'End Sub

        ''*******************************************************************************
        'Private Shared Sub InternalPrint(ByVal SelectionFormula As String)
        '    Dim rptApp As New CRAXDRT.Application()
        '    Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Bill_CreditCard.rpt")
        '    rpt.RecordSelectionFormula = SelectionFormula
        '    rpt.PrintOut(False, 2)
        '    rpt = Nothing
        'End Sub

        '*******************************************************************************
        '//This NEW Auaugst 8, 2007
        '//This method is being commented out - can not find a call to it
        'Public Sub Clear()
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
        '        _wrnty = False
        '    End Try
        'End Sub
        '//end of NEW

        '*******************************************************************************
        Private Function GetLaborLevel() As Integer
            Dim R1, drArr() As DataRow
            Dim dt As DataTable
            Dim strSql As String = ""

            Try
                Me._laborlevel = 0
                For Each R1 In _parts.Rows
                    drArr = _billable.Select("BillCode_ID = " & R1("BillCode_ID"))
                    If CInt(drArr(0)("LaborLevel")) > _laborlevel Then
                        If _device("Cust_ID") = 1 Then  'USA Mobility
                            strSql = "SELECT LaborLevel FROM tlaboroverrides " & Environment.NewLine
                            strSql &= "INNER JOIN tmodel ON tlaboroverrides.rptgrp_id = tmodel.rptgrp_id AND Cust_ID = " & _device("Cust_ID") & Environment.NewLine
                            strSql &= "AND billcode_id = " & R1("billcode_ID")
                            dt = PSS.Data.Production.Joins.OrderEntrySelect(strSql)
                            If dt.Rows.Count = 1 Then
                                _laborlevel = dt.Rows(0)("LaborLevel")
                            Else
                                _laborlevel = CInt(drArr(0)("LaborLevel"))
                            End If
                        Else                                                        'NEW June 3 2005
                            _laborlevel = CInt(drArr(0)("LaborLevel"))
                        End If
                    End If                                                          'NEW May 31 2005
                Next R1

                Return Me._laborlevel
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : drArr = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************************
        Public Sub Update(ByVal iUser_ID As Integer, _
                        ByVal strUser_Name As String, _
                        ByVal iEmpNo As Integer, _
                        ByVal iShift_ID As Integer, _
                        ByVal strWorkDate As String)

            If _parts.Rows.Count = 0 Then UpdatePrice(0.0, _device("Device_PSSWrty"), _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate) : Exit Sub
            Dim _Price As DataRow() = _labor.Select("LaborLvl_ID = " & GetLaborLevel())
            If _Price.Length <> 1 Then
                _Price = _labor.Select("LaborLvl_ID = 0")
                If _Price.Length <> 1 Then
                    Throw New Exception("There is not enough information to bill this device. " & vbCrLf & _
                                                    "There is no mapping between this product group and pricing." & vbCrLf & vbCrLf & _
                                                    "Please CONTACT CUSTOMER SERVICE.")
                    Exit Sub
                End If
            End If

            Dim dsAB As PSS.Data.Production.Joins
            '//*************************************************************************************
            '//June 16, 2006
            '//This is for ATCLE ONLY - substitute RTM/RUR Pricing
            '//Check to see if value is RTM or RUR
            Dim retInt, ruleInt As Integer
            Dim vCount As Integer = 0
            retInt = 0
            Dim rInt As DataRow

            Dim mRUR, mRTM As Double
            Dim valueDt As DataTable
            Dim rValue As DataRow

            If _CustID = 2019 Then '//ATCLE-AWS Customer

                For vCount = 0 To _parts.Rows.Count - 1
                    rInt = _parts.Rows(vCount)
                    ruleInt = CheckPartRule(rInt("Billcode_ID"))
                    If ruleInt > retInt Then retInt = ruleInt
                Next

                '//This code is to determine that is no parts are used then charge 6.85
                If ruleInt < 1 Then
                    Dim blnchargeNoPart As Boolean = True
                    Dim NoPartCount As Integer = 0
                    Dim rNoPart As DataRow
                    For NoPartCount = 0 To _parts.Rows.Count - 1
                        rNoPart = _parts.Rows(NoPartCount)
                        If rNoPart("Billcode_ID") <> 442 And rNoPart("Billcode_ID") <> 447 And rNoPart("Billcode_ID") <> 448 And rNoPart("Billcode_ID") <> 255 Then
                            blnchargeNoPart = False
                            Exit For
                        End If
                    Next
                    System.Windows.Forms.Application.DoEvents()
                    If blnchargeNoPart = True Then
                        UpdatePrice(6.85, False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                        '//July 24, 2006 Craig D. Haney
                        If _device("PO_ID") < 1 Then
                            Exit Sub
                        Else
                            GoTo aggbilling
                        End If
                        '//Exit Sub commented out 
                        '//July 24, 2006 Craig D. Haney
                    End If
                End If

                If _device("PO_ID") > 0 Then
                    valueDt = dsAB.OrderEntrySelect("SELECT * FROM tpurchaseorder WHERE PO_ID = " & _device("PO_ID"))
                    rValue = valueDt.Rows(0)
                    '//If retint = 1 or 2 then set labor to RUR
                    If retInt = 1 Or retInt = 2 Then
                        If rValue("PO_RUR") > 0 Then
                            UpdatePrice(rValue("PO_RUR"), False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                            '//July 24, 2006 Craig D. Haney
                            If _device("PO_ID") < 1 Then
                                Exit Sub
                            Else
                                GoTo aggbilling
                            End If
                            'Exit Sub
                            '//July 24, 2006 Craig D. Haney
                        End If
                    End If
                    '//If retint = 9 then set labor to RTM
                    If retInt = 9 Then
                        If rValue("PO_RTM") > 0 Then
                            UpdatePrice(rValue("PO_RTM"), False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                            '//July 24, 2006 Craig D. Haney
                            If _device("PO_ID") < 1 Then
                                Exit Sub
                            Else
                                GoTo aggbilling
                            End If
                            'Exit Sub
                            '//July 24, 2006 Craig D. Haney
                        End If
                    End If
                Else
                    '//Get values from tcustmarkup
                    valueDt = dsAB.OrderEntrySelect("SELECT * FROM tcustmarkup WHERE Cust_ID = " & _CustID)
                    rValue = valueDt.Rows(0)
                    '//If retint = 1 or 2 then set labor to RUR
                    If retInt = 1 Or retInt = 2 Then
                        If rValue("Markup_RUR") > 0 Then
                            UpdatePrice(rValue("Markup_RUR"), False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                            '//July 24, 2006 Craig D. Haney
                            If _device("PO_ID") < 1 Then
                                Exit Sub
                            Else
                                GoTo aggbilling
                            End If
                            'Exit Sub
                            '//July 24, 2006 Craig D. Haney
                        End If
                    End If
                    '//If retint = 9 then set labor to RTM
                    If retInt = 9 Then
                        If rValue("Markup_RTM") > 0 Then
                            UpdatePrice(rValue("Markup_RTM"), False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                            '//July 24, 2006 Craig D. Haney
                            If _device("PO_ID") < 1 Then
                                Exit Sub
                            Else
                                GoTo aggbilling
                            End If
                            'Exit Sub
                            '//July 24, 2006 Craig D. Haney
                        End If
                    End If
                End If
            End If
            '//This is for ATCLE ONLY - substitute RTM/RUR Pricing
            '//June 16, 2006
            '//*************************************************************************************

            Dim dtReplace As DataTable

            Try
                dtReplace = PSS.Data.Production.Joins.ReplacePhone(_ID)
            Catch EX As Exception
            End Try

            If _device("PO_ID") > 0 Then
                lCustomPrice(_Price(0), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            ElseIf _device("Device_PSSWrty") > 0 Then
                lPSSPrice(_Price(0), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            ElseIf _device("Device_ManufWrty") > 0 Then
                'Craig Haney

                Dim vLL As Integer = 0
                Try
                    Dim tLL As DataTable = PSS.Data.Production.Joins.MaxLaborLevel(_ID)
                    Dim tLLr As DataRow
                    If tLL.Rows.Count > 0 Then
                        tLLr = tLL.Rows(0)
                        vLL = tLLr("LaborLevel")
                        _laborlevel = vLL

                    End If
                Catch ex As Exception
                End Try

                If vLL > 0 Then
                    lRegPrice(_Price(0), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                    vLL = 0

                    Try
                        If dtReplace.Rows.Count > 0 Then
                            Dim rReplace As DataRow = dtReplace.Rows(0)
                            UpdatePrice(rReplace("Markup_Replacement"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                        End If
                    Catch ex As Exception
                    End Try

                Else
                    lManufPrice(_Price(0), iUser_ID, iEmpNo, iShift_ID, strWorkDate)

                    Try
                        If dtReplace.Rows.Count > 0 Then
                            Dim rReplace As DataRow = dtReplace.Rows(0)
                            UpdatePrice(rReplace("Markup_Replacement"), False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                        End If
                    Catch ex As Exception
                    End Try

                End If
                'Craig Haney - END

            Else
                lRegPrice(_Price(0), iUser_ID, iEmpNo, iShift_ID, strWorkDate)

                Try
                    If dtReplace.Rows.Count > 0 Then
                        Dim rReplace As DataRow = dtReplace.Rows(0)
                        UpdatePrice(rReplace("Markup_Replacement"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                    End If
                Catch ex As Exception
                End Try
            End If

            _Price = Nothing
            Try
                DeviceBilling.SetBiller(strUser_Name, _device("Tray_ID"))
            Catch ex As Exception
                '// here to catch if the admin is logged in
            End Try

            'Craig D Haney September 30 2004 - START
            'Craig D Haney September 30 2004 - END

            '//This is where to place the code to determine if dbr percentage if enough to charge a labor charge to this device
            '//START
            If _CustID = 2069 Then
                '//Customer is AWS, Inc.
                If _dbr = True Then
                    '//Device is being DBR'd
                    '//Determine percentage of dbr against total number in workorder
                    Dim ctDT As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT COUNT(Device_ID) as woTotal FROM tdevice WHERE WO_ID = " & _device("wo_id") & " GROUP BY WO_ID")
                    Dim rDT As DataRow = ctDT.Rows(0)

                    Dim dbrSQL As String = "SELECT distinct COUNT(tdevice.device_ID) as dbrTotal FROM tdevice inner join tdevicebill on tdevice.device_id = tdevicebill.device_id inner join lbillcodes on tdevicebill.billcode_id = lbillcodes.billcode_id WHERE tdevice.wo_id = " & _device("WO_ID") & " AND lbillcodes.billcode_rule in (1,2)"
                    Dim dbrDT As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(dbrSQL)
                    Dim rDBR As DataRow = dbrDT.Rows(0)

                    Dim valMargin As Integer = CInt(rDT("woTotal")) * 0.2

                    'MsgBox("Margin Value: " & valMargin & " DBR Number: " & CInt(rDBR("dbrTotal")))

                    If CInt(rDBR("dbrTotal")) > valMargin Then
                        '//Dbr margin has been exceeded
                        If _ID > 0 Then
                            '//Update the laborlevel value
                            Dim strUpdateLL As String = "UPDATE tdevice SET device_laborcharge = 6.50 WHERE Device_ID = " & _ID
                            Dim blnLLchange As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete(strUpdateLL)
                            System.Windows.Forms.Application.DoEvents()
                            blnLLchange = Nothing
                        End If
                    End If
                    dbrDT = Nothing
                    ctDT = Nothing
                End If
            End If
            '//END

            '//This is to perform cumulative billing - January 27, 2006
            Dim dtAB As DataTable
            Dim abSQL As String
            Dim abLabor As Double
            abLabor = 0.0
            Dim abCount, abCount1 As Integer
            abCount = 0
            abCount1 = 0

            Dim abR, abR1 As DataRow
            Dim blnZero As Boolean


AggBilling:


            If _device("PO_ID") > 0 Then

                Dim dtCheckAgg As DataTable = dsAB.OrderEntrySelect("SELECT * FROM tpurchaseorder WHERE PO_ID = " & _device("PO_ID"))
                Dim rCheckAgg As DataRow = dtCheckAgg.Rows(0)

                dtAB = dsAB.OrderEntrySelect("SELECT * FROM tpoaggregatebilling WHERE PO_ID = " & _device("PO_ID"))
                If dtAB.Rows.Count > 0 Then
                    '//Iterate through billcodes to determine proper labor charge
                    abLabor = 0.0
                    For abCount = 0 To _parts.Rows.Count - 1
                        abR = _parts.Rows(abCount)
                        For abCount1 = 0 To dtAB.Rows.Count - 1
                            abR1 = dtAB.Rows(abCount1)
                            If abR("BillCode_ID") = abR1("BillCode_ID") Then
                                abLabor += abR1("tpab_Amount")

                                Try
                                    If _ID > 0 And abR("BillCode_ID") > 0 Then
                                        blnZero = dsAB.OrderEntryUpdateDelete("UPDATE tdevicebill set dbill_invoiceamt = 0.00 WHERE device_id = " & _ID & " AND billcode_ID = " & abR("BillCode_ID"))
                                    End If
                                Catch ex As Exception
                                End Try

                                Exit For
                            End If
                        Next
                    Next
                    '//Now the total sum should be here
                    If rCheckAgg("PO_Aggregate") = 1 Then
                        UpdatePrice(abLabor, False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                    End If

                End If


                '//Check to see if value is RTM or RUR
                'Dim retInt, ruleInt As Integer
                'Dim vCount As Integer = 0
                ''//Get maximum billcode rule

                retInt = 0
                'Dim rInt As DataRow
                For vCount = 0 To _parts.Rows.Count - 1
                    rInt = _parts.Rows(vCount)
                    ruleInt = CheckPartRule(rInt("Billcode_ID"))
                    If ruleInt > retInt Then retInt = ruleInt
                Next

                'Dim mRUR, mRTM As Double
                valueDt = dsAB.OrderEntrySelect("SELECT * FROM tpurchaseorder WHERE PO_ID = " & _device("PO_ID"))
                'Dim rValue As DataRow
                rValue = valueDt.Rows(0)
                ''//If retint = 1 or 2 then set labor to RUR
                If retInt = 1 Or retInt = 2 Then
                    If rValue("PO_RUR") > 0 Then
                        UpdatePrice(rValue("PO_RUR"), False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                    End If
                End If
                ''//If retint = 9 then set labor to RTM
                If retInt = 9 Then
                    If rValue("PO_RTM") > 0 Then
                        UpdatePrice(rValue("PO_RTM"), False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                    End If
                End If

            Else
                Dim dtCheckAggCust As DataTable = dsAB.OrderEntrySelect("SELECT * FROM tcustomer WHERE Cust_ID = " & _device("Cust_ID"))
                Dim rCheckAggCust As DataRow = dtCheckAggCust.Rows(0)

                dtAB = dsAB.OrderEntrySelect("SELECT * FROM tcustaggregatebilling WHERE Cust_ID = " & _device("Cust_ID"))
                If dtAB.Rows.Count > 0 Then
                    '//Iterate through billcodes to determine proper labor charge
                    abLabor = 0.0
                    For abCount = 0 To _parts.Rows.Count - 1
                        abR = _parts.Rows(abCount)
                        For abCount1 = 0 To dtAB.Rows.Count - 1
                            abR1 = dtAB.Rows(abCount1)
                            If abR("BillCode_ID") = abR1("BillCode_ID") Then
                                abLabor += abR1("tcab_Amount")

                                Try
                                    If _ID > 0 And abR("BillCode_ID") > 0 Then
                                        blnZero = dsAB.OrderEntryUpdateDelete("UPDATE tdevicebill set dbill_invoiceamt = 0.00 WHERE device_id = " & _ID & " AND billcode_ID = " & abR("BillCode_ID"))
                                    End If
                                Catch ex As Exception
                                End Try

                                Exit For
                            End If
                        Next
                    Next
                    '//Now the total sum should be here
                    If rCheckAggCust("Cust_AggBilling") = 1 Then
                        UpdatePrice(abLabor, False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                    End If
                End If
            End If
            '//This is to perform cumulative billing - January 27, 2006
        End Sub

        ''*******************************************************************************
        'Private Sub ManufWrty()
        '    DeviceBilling.InsertWarranty(_ID, _billable.Rows(0)("ASCPrice_Price"), _billable.Rows(0)("ASCPrice_ID"), _
        '                                            _billable.Rows(0)("Prod_ID"), _billable.Rows(0)("Manuf_ID"))
        'End Sub

        '*******************************************************************************
        Private Function addPartTransaction(ByVal iBillcode As Integer, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String) As Boolean

            Dim ds As PSS.Data.Production.Joins
            Dim blnInsert As Boolean = False
            Dim strMachine As String = System.Net.Dns.GetHostName
            Dim dDateRec As String = Generic.MySQLServerDateTime(1)

            Dim strSQL As String
            Dim iCC_ID As Integer = 0
            Dim iProdID As Integer = 0

            Try
                iProdID = Generic.GetProdIDOfUnit(_ID)
                '*******************************
                'Get Cost Center ID
                '*******************************
                iCC_ID = Generic.GetMachineCostCenterID
                If iCC_ID = 31 Then     'Special Cost Center use by supervisors and leaders
                    'Use device's cost center instead of machine's cost center
                    iCC_ID = PSS.Data.Buisness.Generic.GetCostCenterIDOfDevice(_ID)
                End If
                '*******************************

                strSQL = "INSERT INTO tparttransaction " & Environment.NewLine
                strSQL &= "(Device_ID, BillCode_ID, User_ID, Date_Rec, EmployeeNo, Trans_Amount, Shift_ID_Trans, WorkDate, MachineName, New, Date_Server, cc_id, Prod_ID ) " & Environment.NewLine
                strSQL &= "VALUES (" & _ID & ", " & iBillcode & ", " & iUser_ID & ", '" & dDateRec & "', " & iEmpNo & ", 1, " & iShift_ID & ", '" & strWorkDate & "', '" & strMachine & "', 1, '" & Generic.MySQLServerDateTime(1) & "', " & iCC_ID & ", " & iProdID & ")"
                blnInsert = ds.OrderEntryUpdateDelete(strSQL)

                Return blnInsert
            Catch ex As Exception
                Throw ex
            Finally
                ds = Nothing
            End Try
        End Function

        '*******************************************************************************
        Private Function removePartTransaction(ByVal iBillcode As Integer, _
                                                ByVal iUser_ID As Integer, _
                                                ByVal iEmpNo As Integer, _
                                                ByVal iShift_ID As Integer, _
                                                ByVal strWorkDate As String) As Boolean

            Dim ds As PSS.Data.Production.Joins
            Dim blnInsert As Boolean = False
            Dim strMachine As String = System.Net.Dns.GetHostName
            Dim dDateRec As String = Generic.MySQLServerDateTime(1)
            Dim strSQL As String
            Dim iCC_ID As Integer = 0
            Dim iProdID As Integer = 0
            Dim iLastBillCCID As Integer = 0

            Try
                iProdID = Generic.GetProdIDOfUnit(_ID)

                '*******************************
                'Get Cost Center ID
                '*******************************
                iCC_ID = Generic.GetMachineCostCenterID
                If iCC_ID = 31 Or iCC_ID = 0 Then     'Special Cost Center use by supervisors and leaders
                    'Use device's cost center instead of machine's cost center
                    iCC_ID = PSS.Data.Buisness.Generic.GetCostCenterIDOfDevice(_ID)
                End If
                '*******************************
                ''Added on 06/11/2009
                ''For unbill unit, use CC ID where the part get bill
                '*******************************
                iLastBillCCID = PSS.Data.Buisness.Generic.GetLastBillCCID(_ID, iBillcode)
                If iLastBillCCID > 0 Then iCC_ID = iLastBillCCID
                '*******************************

                strSQL = "INSERT INTO tparttransaction " & Environment.NewLine
                strSQL &= "(Device_ID, BillCode_ID, User_ID, Date_Rec, EmployeeNo, Trans_Amount, Shift_ID_Trans, WorkDate, MachineName, New, Date_Server, cc_id, Prod_ID ) " & Environment.NewLine
                strSQL &= "VALUES (" & _ID & ", " & iBillcode & ", " & iUser_ID & ",'" & dDateRec & "', " & iEmpNo & ", -1, " & iShift_ID & ", '" & strWorkDate & "', '" & strMachine & "', 2, '" & Generic.MySQLServerDateTime(1) & "', " & iCC_ID & ", " & iProdID & ")"
                blnInsert = ds.OrderEntryUpdateDelete(strSQL)

                Return blnInsert
            Catch ex As Exception
                Throw New Exception()
            Finally
                ds = Nothing
            End Try
        End Function

        '*******************************************************************************
        Public Sub clear()
            '//This function currently does nothing!!!!
        End Sub

#End Region

#Region "Parts"
        '*******************************************************************************
        Private Function Price(ByVal StandardPrice As Object, ByVal Type As Integer) As Double
            If IsDBNull(StandardPrice) Then
                Return 0.0
            ElseIf Type = 1 Then 'Service
                Return StandardPrice
            ElseIf Type = 2 Then 'Part
                Return Math.Round(StandardPrice * (_device("Cust_Markup") + 1), 2)
            Else 'Everything else
                Return Math.Round(StandardPrice * (_device("Cust_Markup") + 1), 2)
            End If
        End Function

        '*******************************************************************************
        Private Function Zero() As Double
            Return 0.0
        End Function

        '*******************************************************************************
        Private Function pCustomPrice(ByVal datarow As DataRow) As Double
            If _device("PlusParts") Then
                Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
            Else
                Return Zero()
            End If
        End Function

        '*******************************************************************************
        Private Function pPSSPrice(ByVal datarow As DataRow) As Double
            If _device("PSSWrtyParts_ID") = 1 Then
                Return pRegPrice(datarow)
            ElseIf _device("PSSWrtyParts_ID") = 2 Then
                Return Zero()
            ElseIf _device("PSSWrtyParts_ID") = 3 Then
                Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
            End If
        End Function

        '*******************************************************************************
        Private Function pManufPrice(ByVal datarow As DataRow) As Double
            If datarow("BillCode_Rule") = 3 And _device("Device_ManufWrty") <> 2 Then
                If _device("Cust_RepairNonWrty") Then
                    Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
                Else
                    Return Zero()
                End If
            Else
                'If _device("PlusParts") Then
                'Return pRegPrice(datarow)
                'Else
                '    Return Zero()
                'End If
                If _device("Prod_ID") = 2 Then
                    Return Zero()
                Else
                    If _device("PlusParts") Then
                        '//New Craig Haney May 19, 2004
                        If _device("Device_ManufWrty") > 0 Then
                            Return Zero()
                        Else
                            Return pRegPrice(datarow)
                        End If
                        '//New Craig Haney May 19, 2004
                    Else
                        Return Zero()
                    End If


                End If

            End If
        End Function

        '*******************************************************************************
        Private Function pRegPrice(ByVal datarow As DataRow) As Double
            If _device("Cust_RepairNonWrty") Then
                If _device("PlusParts") = False Then
                    Dim exPart As Integer = 0
                    Try
                        exPart = DeviceBilling.GetExcepCode(datarow("BillCode_ID"), _device("PoductGroup"), _device("PricingGroup"))(0)
                        If exPart <> 0 Then
                            Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
                        Else
                            Return Zero()
                        End If
                    Catch ex As Exception
                        Return Zero()
                    End Try
                Else
                    Return Price(datarow("PSPrice_StndCost"), datarow("BillType_ID"))
                End If
            Else
                Return Zero()
            End If
        End Function
#End Region

#Region "Labor"
        Private Sub UpdatePrice(ByVal Price As Double, ByVal PSSWrty As Boolean, ByVal ManufWrty As Integer, _
                                ByVal iUser_ID As Integer, _
                                ByVal iEmpNo As Integer, _
                                ByVal iShift_ID As Integer, _
                                ByVal strWorkDate As String)
            Dim aship As Boolean = False
            Dim decServiceCharge As Decimal = 0.0

            Try
                'Piece of crap code. (If Me.blnFailureCode > True Then) what the hell is this. Programming 101.
                'Craig Haney
                'If Me.blnFailureCode > True Then
                If _device("Device_ManufWrty") > 0 Then ManufWrty = _device("Device_ManufWrty")
                'End If
                'Craig Haney - END

                If _device("Cust_AutoShip") = 1 And _dbr = True Then
                    aship = True
                End If

                If _parts.Rows.Count = 0 Then
                    DeviceBilling.SetLaborData(_ID, 0.0, PSSWrty, ManufWrty, 0, "NULL", aship, _device("Loc_Id"), iShift_ID, strWorkDate)
                Else
                    decServiceCharge = DeviceBilling.GetServiceCharge(Me._ID, Me._CustID)
                    Price += decServiceCharge
                    DeviceBilling.SetLaborData(_ID, Price, PSSWrty, ManufWrty, _laborlevel, Generic.MySQLServerDateTime(1), aship, _device("Loc_Id"), iShift_ID, strWorkDate)
                End If
                aship = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Function lCustomPrice(ByVal datarow As DataRow, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String)
            If _device("PO_ChgWrty") And _device("Device_ManufWrty") > 0 Then
                _wrnty = True
            End If
            'Since we  model our data the right way we can just call regular pricing.
            lRegPrice(datarow, iUser_ID, iEmpNo, iShift_ID, strWorkDate)

            '//RTM Code Here - This is new January 17, 2006
        End Function

        '*******************************************************************************
        Private Function lPSSPrice(ByVal datarow As DataRow, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String)
            If _dbr Then
                UpdatePrice(_device("RUR_Price"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            ElseIf _ntf Then
                UpdatePrice(_device("NTF_Price"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            Else
                If _device("PSSWrtyLabor_ID") = 1 Then
                    lRegPrice(datarow, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                ElseIf _device("PSSWrtyLabor_ID") = 2 Then
                    UpdatePrice(Zero, True, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                ElseIf _device("PSSWrtyLabor_ID") = 4 Then
                    If Me._laborlevel < 3 Then
                        lRegPrice(datarow, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                    Else
                        UpdatePrice(Zero, _device("Device_PSSWrty"), 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                    End If
                End If
            End If
        End Function

        '*******************************************************************************
        Private Function lManufPrice(ByVal datarow As DataRow, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String)
            If _dbr Then
                UpdatePrice(_device("RUR_Price"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            ElseIf _ntf Then
                UpdatePrice(_device("NTF_Price"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            Else
                _wrnty = True
                UpdatePrice(datarow("LaborPrc_WrtyPrc"), False, _device("Device_ManufWrty"), iUser_ID, iEmpNo, iShift_ID, strWorkDate)
            End If
        End Function

        '*******************************************************************************
        Private Function lRegPrice(ByVal datarow As DataRow, _
                                            ByVal iUser_ID As Integer, _
                                            ByVal iEmpNo As Integer, _
                                            ByVal iShift_ID As Integer, _
                                            ByVal strWorkDate As String)
            If _device("Cust_RepairNonWrty") Then
                If _dbr Then
                    UpdatePrice(_device("RUR_Price"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                ElseIf _ntf Then
                    UpdatePrice(_device("NTF_Price"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                Else
                    UpdatePrice(datarow("LaborPrc_RegPrc"), False, 0, iUser_ID, iEmpNo, iShift_ID, strWorkDate)
                End If
            Else
                Return Zero()
            End If
        End Function
        '*******************************************************************************
#End Region

#Region "Properties"
        '*******************************************************
        Public ReadOnly Property DefaultView() As DataView
            Get
                Return _parts.DefaultView
            End Get
        End Property

        '*******************************************************
        Public ReadOnly Property Billed() As Boolean
            Get
                If IsDate(_device("Device_DateBill")) Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        '*******************************************************
        Public ReadOnly Property ID() As Integer
            Get
                Return _ID
            End Get
        End Property

        '*******************************************************
        Public ReadOnly Property Parts() As DataTable
            Get
                Return _parts
            End Get
        End Property

        '*******************************************************
        Public ReadOnly Property EndUser() As Boolean
            Get
                Return Me._CreditUser
            End Get
        End Property

        '*******************************************************
        Public ReadOnly Property Customer() As String
            Get
                Return Me._cust
            End Get
        End Property

        '*******************************************************
        'Added by Asif
        Public ReadOnly Property CustID() As String
            Get
                Return Me._CustID
            End Get
        End Property
        '*******************************************************
#End Region

    End Class
End Namespace
