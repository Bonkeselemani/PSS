Option Explicit On 

Imports PSS.Data

Namespace Gui.TracFone
    Public Class TFBilling
        Private _objTFBillingData As PSS.Data.Buisness.TracFone.TFBillingData
        Private Const _strEnterprise As String = ""

#Region "Constructor/Destructor"
        '****************************************************************************************
        Public Sub New()
            Try
                _objTFBillingData = New Buisness.TracFone.TFBillingData()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '****************************************************************************************
        Protected Overrides Sub Finalize()
            Me._objTFBillingData = Nothing
            MyBase.Finalize()
        End Sub

#End Region

#Region "Reg Billing"


        '****************************************************************************************
        Public Function BillServices(ByVal drDeviceInfo As DataRow, _
                                     ByVal iShipType As Integer, _
                                     ByVal iCustID As Integer, ByVal booFlatRate As Boolean, ByVal iInvoiceYrMonth As Integer) As Boolean
            Dim objDevice As PSS.Rules.Device
            Dim dt1, dtPSBCID, dtDefaultNTFParts, dtMaxClaimablePartLevel As DataTable
            Dim R1, drWipWO, drPSBCID As DataRow
            Dim iMaxPartLevel As Integer = 0
            Dim iWrtyClaimableFlg As Integer = 0

            Try
                objDevice = New PSS.Rules.Device(drDeviceInfo("Device_ID"))
                ''******************************************************
                ''GET DEFAULT PART FOR NTF UNIT
                ''******************************************************
                'If iShipType = 0 Then dtDefaultNTFParts = Buisness.Generic.GetDefaultPartsForNTFDevice(iCustID, drDeviceInfo("Model_ID"))

                '******************************************************
                _objTFBillingData = New Buisness.TracFone.TFBillingData()
                If iShipType > 0 Then dtPSBCID = _objTFBillingData.GetBilledPartsServicesBillcodeID(drDeviceInfo("Device_ID"))

                '******************************************
                If iShipType = 0 Then
                    If booFlatRate = False Then
                        iMaxPartLevel = _objTFBillingData.GetMaxPartsAndServicesRepLevel(drDeviceInfo("Device_ID"))
                        '******************************************
                        'Bill Receiving service 
                        '******************************************
                        If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1608) > 0 Then
                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1608) = False Then objDevice.AddPart(1608)
                        Else
                            Throw New Exception("Receiving service code is not map. Please contact Material department.")
                        End If
                        '******************************************
                        'Bill Packing Bulk service code
                        '******************************************
                        If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1615) > 0 Then
                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1615) = False Then objDevice.AddPart(1615)
                        Else
                            Throw New Exception("Receiving service code is not map. Please contact Material department.")
                        End If
                        '******************************************
                        'Bill Cosmetic Inspection service code 
                        '******************************************
                        If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1609) > 0 Then
                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1609) = False Then objDevice.AddPart(1609)
                        Else
                            Throw New Exception("Cosmetic Inspection service code is not map. Please contact Material department.")
                        End If

                        ''****************************************
                        'Separate In and Out of Warranty 
                        ''****************************************
                        If drDeviceInfo("Device_ManufWrty") = 0 Then
                            ''******************************************************************************************
                            'Repair Type: Cosmetic Fluff-Buff, Cosmetic Refurbished, Functional Repair,Functional Repair
                            ''******************************************************************************************
                            Select Case iMaxPartLevel
                                Case 0  'Cosmetic Fluff-Buff
                                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1611) > 0 Then
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = False Then objDevice.AddPart(1611)
                                    Else
                                        Throw New Exception("Cosmetic Fluff-Buff service code is not map. Please contact Material department.")
                                    End If
                                    'Remove Cosmetic Refurbished, Functional Repair,Mechanical Repair
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = True Then objDevice.DeletePart(1612)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = True Then objDevice.DeletePart(1618)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = True Then objDevice.DeletePart(1619)
                                Case 1  'Cosmetic Refurbished
                                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1612) > 0 Then
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = False Then objDevice.AddPart(1612)
                                    Else
                                        Throw New Exception("Refurbish service code is not map. Please contact Material department.")
                                    End If
                                    'Remove Cosmetic Fluff-Buff, Functional Repair,Mechanical Repair
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = True Then objDevice.DeletePart(1611)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = True Then objDevice.DeletePart(1618)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = True Then objDevice.DeletePart(1619)
                                Case 2  'Functional Repair
                                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1618) > 0 Then
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = False Then objDevice.AddPart(1618)
                                    Else
                                        Throw New Exception("Functional Repair (Level PlugIn) service code is not map. Please contact Material department.")
                                    End If
                                    'Remove Cosmetic Fluff-Buff, Cosmetic Refurbished,Mechanical Repair
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = True Then objDevice.DeletePart(1611)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = True Then objDevice.DeletePart(1612)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = True Then objDevice.DeletePart(1619)
                                Case 3, 4 'Mechanical Repair
                                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1619) > 0 Then
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = False Then objDevice.AddPart(1619)
                                    Else
                                        Throw New Exception("Functional Repair (Level Solder) service code is not map. Please contact Material department.")
                                    End If
                                    'Remove Cosmetic Fluff-Buff, Cosmetic Refurbished, Functional Repair
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = True Then objDevice.DeletePart(1611)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = True Then objDevice.DeletePart(1612)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = True Then objDevice.DeletePart(1618)
                                Case Else
                                    Throw New Exception("System can't define labor for out of warranty unit. Please contact IT.")
                            End Select
                        Else    'In Warranty
                            ''******************************************************************************************
                            'Repair Type: Cosmetic Fluff-Buff, Cosmetic Refurbished, Functional Repair,Functional Repair
                            ''******************************************************************************************
                            Select Case iMaxPartLevel
                                Case 0  'Cosmetic Fluff-Buff
                                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1611) > 0 Then
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = False Then objDevice.AddPart(1611)
                                    Else
                                        Throw New Exception("Refurbish service code is not map. Please contact Material department.")
                                    End If
                                    'Remove Cosmetic Refurbished, Functional Repair,Mechanical Repair
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = True Then objDevice.DeletePart(1612)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = True Then objDevice.DeletePart(1618)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = True Then objDevice.DeletePart(1619)
                                Case 1  'Cosmetic Refurbished
                                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1612) > 0 Then
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = False Then objDevice.AddPart(1612)
                                    Else
                                        Throw New Exception("Refurbish service code is not map. Please contact Material department.")
                                    End If
                                    'Remove Cosmetic Fluff-Buff, Functional Repair,Mechanical Repair
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = True Then objDevice.DeletePart(1611)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = True Then objDevice.DeletePart(1618)
                                    If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = True Then objDevice.DeletePart(1619)
                                Case 2, 3, 4  'Functional Repair &  'Mechanical Repair
                                    '****************************************
                                    'Get maximum claimable parts repair level
                                    '****************************************
                                    dtMaxClaimablePartLevel = _objTFBillingData.GetMaxClaimablePartsAndReflowTuningLevel(drDeviceInfo("Device_ID"), drDeviceInfo("Manuf_ID"))

                                    'Has no claimable part
                                    If dtMaxClaimablePartLevel.Rows.Count = 0 OrElse dtMaxClaimablePartLevel.Rows(0)("LaborLevel") < 2 Then
                                        'Remove Cosmetic Fluff-Buff, Cosmetic Refurbished                                    
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = True Then objDevice.DeletePart(1611)
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = True Then objDevice.DeletePart(1612)

                                        If iMaxPartLevel = 2 Then 'Functional Repair
                                            If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1618) > 0 Then
                                                If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = False Then objDevice.AddPart(1618)
                                            Else
                                                Throw New Exception("Functional Repair (Level PlugIn) service code is not map. Please contact Material department.")
                                            End If
                                            'remove Mechanical Repair
                                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = True Then objDevice.DeletePart(1619)
                                        ElseIf iMaxPartLevel = 3 Or iMaxPartLevel = 4 Then   'Mechanical Repair
                                            If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1619) > 0 Then
                                                If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = False Then objDevice.AddPart(1619)
                                            Else
                                                Throw New Exception("Functional Repair (Level Solder) service code is not map. Please contact Material department.")
                                            End If
                                            'Functional Repair
                                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = True Then objDevice.DeletePart(1618)
                                        End If
                                    Else    'Has claimable parts
                                        iWrtyClaimableFlg = 1
                                        'Bill - Cosmetic Refurbished
                                        If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1612) > 0 Then
                                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = False Then objDevice.AddPart(1612)
                                        Else
                                            Throw New Exception("Refurbish service code is not map. Please contact Material department.")
                                        End If
                                        'Remove Cosmetic Fluff-Buff, Functional Repair,Mechanical Repair
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = True Then objDevice.DeletePart(1611)
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = True Then objDevice.DeletePart(1618)
                                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = True Then objDevice.DeletePart(1619)
                                    End If
                                Case Else
                                    Throw New Exception("System can't define labor for warranty unit. Please contact IT.")
                            End Select
                        End If

                        ''******************************************************************************************
                        'Bill Final Func Insp: Cosmetic Refurbished, Functional Repair,Mechanical Repair
                        ''******************************************************************************************
                        If iMaxPartLevel > 0 Then
                            If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1614) > 0 Then
                                If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1614) = False Then objDevice.AddPart(1614)
                            Else
                                Throw New Exception("Final Func Insp service code is not map. Please contact Material department.")
                            End If
                        ElseIf Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1614) = True Then
                            objDevice.DeletePart(1614)
                        End If
                        ''******************************************************************************************
                        'Bill AQL: Cosmetic Fluff-Buff, Cosmetic Refurbished, Functional Repair,Mechanical Repair
                        ''******************************************************************************************
                        If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1616) > 0 Then
                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1616) = False Then objDevice.AddPart(1616)
                        Else
                            Throw New Exception("AQL service code is not map. Please contact Material department.")
                        End If
                        '**************************************************************
                        'Bill Functional Triage service code 
                        '**************************************************************
                        If drDeviceInfo("FuncRep") = 1 OrElse iMaxPartLevel > 1 OrElse PSS.Data.Buisness.Generic.HasPrestestRecord(drDeviceInfo("Device_ID")) = True Then
                            If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1610) > 0 Then
                                If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1610) = False Then objDevice.AddPart(1610)
                            Else
                                Throw New Exception("Functional Triage service code is not map. Please contact Material department.")
                            End If
                        ElseIf Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1610) = True Then
                            objDevice.DeletePart(1610)
                        End If

                        '**************************************************************
                        'RF1 and RF2 Charge
                        '**************************************************************
                        If iWrtyClaimableFlg = 0 AndAlso iMaxPartLevel > 2 Then
                            '************************************
                            'Bill RF2: No claim & labor level > 2
                            '************************************
                            If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1620) > 0 Then
                                If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1620) = False Then objDevice.AddPart(1620)
                            Else
                                Throw New Exception("RF2 service code is not map. Please contact Material department.")
                            End If
                        Else
                            '************************************
                            'Remove RF1 & RF2: Charged to OEM
                            '************************************
                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1617) = True Then objDevice.DeletePart(1617)
                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1620) = True Then objDevice.DeletePart(1620)
                        End If
                    Else 'Flat Rate
                        '******************************************
                        'Remove Receiving service 
                        '******************************************
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1608) = True Then objDevice.DeletePart(1608)

                        '******************************************
                        'Remove Packing Bulk service code
                        '******************************************
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1615) = True Then objDevice.DeletePart(1615)
                        '******************************************
                        'Remove Cosmetic Inspection service code 
                        '******************************************
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1609) = True Then objDevice.DeletePart(1609)

                        ''******************************************************************************************
                        'Remove Cosmetic Fluff-Buff,Cosmetic Refurbished, Functional Repair, Mechanical Repair
                        ''******************************************************************************************
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1611) = True Then objDevice.DeletePart(1611)
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1612) = True Then objDevice.DeletePart(1612)
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1618) = True Then objDevice.DeletePart(1618)
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1619) = True Then objDevice.DeletePart(1619)

                        ''******************************************************************************************
                        'Remove Final Func Insp: Cosmetic Refurbished, Functional Repair, Mechanical Repair
                        ''******************************************************************************************
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1614) = True Then objDevice.DeletePart(1614)

                        ''******************************************************************************************
                        'Remove AQL: Cosmetic Fluff-Buff, Cosmetic Refurbished, Functional Repair, Mechanical Repair
                        ''******************************************************************************************
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1616) = True Then objDevice.DeletePart(1616)

                        '**************************************************************
                        'Remove Functional Triage service code 
                        '**************************************************************
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1610) = True Then objDevice.DeletePart(1610)
                        '************************************
                        'Remove RF1 & RF2: Charged to OEM
                        '************************************
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1617) = True Then objDevice.DeletePart(1617)
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1620) = True Then objDevice.DeletePart(1620)

                        '***************************************
                        'Reset invoice amt to zero for all part
                        '***************************************
                        _objTFBillingData.SetFlatRatePartCharge(CInt(drDeviceInfo("Device_ID")))
                        '***************************************
                    End If 'Flat Rate

                    '************************************
                    'Bill PSD: Any Pass result 
                    '************************************
                    If _objTFBillingData.HasPSDPassed(drDeviceInfo("Device_ID")) = True Then
                        If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1742) > 0 Then
                            If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1742) = False Then objDevice.AddPart(1742)
                        Else
                            Throw New Exception("PSD service code is not map. Please contact Material department.")
                        End If
                    ElseIf Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1742) = True Then
                        objDevice.DeletePart(1742)
                    End If
                    '************************************

                ElseIf iShipType = 1 Then 'BER...
                    '****************************
                    '1608 :  TF Receiving
                    '1610 :  TF Functional Triage
                    '1615 :  TF Packing Bulk

                    '******************************************
                    'Unbill not allow service code and parts
                    '******************************************
                    For Each drPSBCID In dtPSBCID.Rows
                        If CInt(drPSBCID("Billcode_ID")) <> 1608 AndAlso CInt(drPSBCID("Billcode_ID")) <> 1610 AndAlso CInt(drPSBCID("Billcode_ID")) <> 1615 AndAlso CInt(drPSBCID("BillCode_Rule")) <> 1 Then objDevice.DeletePart(drPSBCID("Billcode_ID"))
                    Next drPSBCID
                    '******************************************
                    'Bill Receiving service 
                    '******************************************
                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1608) > 0 Then
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1608) = False Then objDevice.AddPart(1608)
                    Else
                        Throw New Exception("Receiving service code is not map. Please contact Material department.")
                    End If
                    '**************************************************************
                    'Bill Functional Triage service code 
                    '**************************************************************
                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1610) > 0 Then
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1610) = False Then objDevice.AddPart(1610)
                    Else
                        Throw New Exception("Receiving service code is not map. Please contact Material department.")
                    End If
                    '******************************************
                    'Bill Packing Bulk service code
                    '******************************************
                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1615) > 0 Then
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1615) = False Then objDevice.AddPart(1615)
                    Else
                        Throw New Exception("Receiving service code is not map. Please contact Material department.")
                    End If
                ElseIf iShipType = 10 Then
                    '******************************************
                    'Unbill not allow service code and parts
                    '******************************************
                    For Each drPSBCID In dtPSBCID.Rows
                        If drPSBCID("Billcode_ID") <> 1702 Then objDevice.DeletePart(drPSBCID("Billcode_ID"))
                    Next drPSBCID

                    '*****************************************
                    'Bill TF Funtional Failure BS service code 
                    '*****************************************
                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1702) > 0 Then
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1702) = False Then objDevice.AddPart(1702)
                    Else
                        Throw New Exception("Funtional Failure BS service code is not map. Please contact Material department.")
                    End If
                ElseIf iShipType = 11 Then
                    '******************************************
                    'Unbill not allow service code and parts
                    '******************************************
                    For Each drPSBCID In dtPSBCID.Rows
                        If drPSBCID("Billcode_ID") <> 1703 Then objDevice.DeletePart(drPSBCID("Billcode_ID"))
                    Next drPSBCID
                    '*****************************************
                    'Bill TF Funtional Failure CG service code 
                    '*****************************************
                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1703) > 0 Then
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1703) = False Then objDevice.AddPart(1703)
                    Else
                        Throw New Exception("Funtional Failure CP service code is not map. Please contact Material department.")
                    End If
                ElseIf iShipType = 12 Then
                    '******************************************
                    'Unbill not allow service code and parts
                    '******************************************
                    For Each drPSBCID In dtPSBCID.Rows
                        If drPSBCID("Billcode_ID") <> 991 Then objDevice.DeletePart(drPSBCID("Billcode_ID"))
                    Next drPSBCID

                    '*****************************************
                    'Bill TF Out To Repair service code 
                    '*****************************************
                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 991) > 0 Then
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 991) = False Then objDevice.AddPart(991)
                    Else
                        Throw New Exception("TF Forward To Repair service code is not map. Please contact Material department.")
                    End If
                End If

                '*********************************************************
                'Check : Nokia claimable device must have verification ID 
                '*********************************************************
                If drDeviceInfo("Manuf_ID") = 24 AndAlso iWrtyClaimableFlg = 1 AndAlso drDeviceInfo("CellOpt_VerificationID").ToString.Trim.Length <> 4 Then
                    Throw New Exception("This IMEI " & drDeviceInfo("IMEI") & " does not have a valid Nokia Verification ID.")
                End If

                'THIS MUST HAPPEN FIRST FOR -- tdevice.Device_ManufWrtyLaborCharge & tdevice.Device_ManufWrtyPartCharge TO UPDATE CORRECTLY
                '***** LG, Nokia, Motorola & Samsung using lpsprice.PSPrice_StndCost while objDevice.Update(iInvoiceYrMonth) using tdevicebill.DBill_InvoiceAmt
                objDevice.Update(iInvoiceYrMonth)

                If iShipType <> 1 Then _objTFBillingData.SetWrtyClaimableFlag(drDeviceInfo("Device_ID"), drDeviceInfo("Manuf_ID"), iWrtyClaimableFlg, dtMaxClaimablePartLevel)

                Return True
            Catch ex As Exception
                BillServices = False
                Throw ex
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
                Buisness.Generic.DisposeDT(dt1)
                Buisness.Generic.DisposeDT(dtDefaultNTFParts)
                Buisness.Generic.DisposeDT(dtPSBCID)
                R1 = Nothing : drWipWO = Nothing : drPSBCID = Nothing
            End Try
        End Function

        '****************************************************************************************
        Public Sub FixLGSSReceiptDate(ByVal iPalletID As Integer, ByVal booFlatRate As Boolean)
            Dim dtClaimableUnits, dtReplaceFFNWithOEM As DataTable
            Dim R1, R2 As DataRow
            Dim dteRcptDate, dteRepDate As DateTime
            Dim booUpdRecptDate, booUpdRepDate As Boolean
            Dim strToday As String = ""
            Dim objDevice As PSS.Rules.Device

            Try
                strToday = PSS.Data.Buisness.Generic.MySQLServerDateTime()
                dtClaimableUnits = Me._objTFBillingData.GetClaimableDevices(iPalletID)

                For Each R1 In dtClaimableUnits.Rows
                    booUpdRecptDate = False : booUpdRepDate = False
                    dteRcptDate = CDate(R1("WrtyClaimReceiptDt"))
                    dteRepDate = CDate(R1("CellOpt_RefurbCompleteDt"))

                    'Receipt date
                    If DateDiff(DateInterval.Day, dteRcptDate, CDate(strToday)) > 27 Then
                        dteRcptDate = DateAdd(DateInterval.Day, DateDiff(DateInterval.Day, dteRcptDate, CDate(strToday)) - 27, dteRcptDate)
                        booUpdRecptDate = True
                    ElseIf DateDiff(DateInterval.Day, dteRcptDate, CDate(strToday)) < 1 Then
                        dteRcptDate = CDate(DateAdd(DateInterval.Day, -1, CDate(strToday)).ToString("yyyy-MM-dd") & " " & dteRcptDate.ToString("HH:mm:ss"))
                        booUpdRecptDate = True
                    End If
                    If dteRcptDate.ToString("yyyyMMddhhmmss") = CDate(R1("WrtyClaimReceiptDt")).ToString("yyyyMMddhhmmss") Then
                        booUpdRecptDate = False
                    End If

                    'Repair Date
                    If (DateDiff(DateInterval.Day, dteRcptDate, dteRepDate)) < 0 Then
                        dteRepDate = DateAdd(DateInterval.Day, (DateDiff(DateInterval.Day, dteRcptDate, dteRepDate) * -1) + 1, dteRepDate)
                        booUpdRepDate = True
                    End If
                    If DateDiff(DateInterval.Day, dteRcptDate, dteRepDate) = 0 AndAlso DateDiff(DateInterval.Hour, dteRcptDate, dteRepDate) < 2 Then
                        dteRepDate = CDate(DateAdd(DateInterval.Hour, 2, dteRcptDate).ToString("yyyy-MM-dd HH:") & " " & CDate(R1("CellOpt_RefurbCompleteDt")).ToString("mm:ss"))
                        booUpdRepDate = True
                    ElseIf DateDiff(DateInterval.Day, dteRepDate, CDate(strToday)) = 0 AndAlso DateDiff(DateInterval.Hour, dteRepDate, CDate(strToday)) < 2 Then
                        dteRepDate = CDate(DateAdd(DateInterval.Hour, -2, CDate(strToday)).ToString("yyyy-MM-dd HH:") & " " & CDate(R1("CellOpt_RefurbCompleteDt")).ToString("mm:ss"))
                        booUpdRepDate = True
                    End If

                    If DateDiff(DateInterval.Day, dteRcptDate, CDate(R1("LastDateInWrty"))) < 0 Then
                        '****************************************************************
                        'Samsung assigned consigned part for use with FFN fail code
                        'To reset device to OW need to unbill consigned part with EOM part
                        '****************************************************************
                        If R1("Manuf_ID") = 21 Then
                            dtReplaceFFNWithOEM = _objTFBillingData.GetEOMBillcodeANDConsignedPartBillcode(R1("Device_ID"))
                            If dtReplaceFFNWithOEM.Rows.Count > 0 Then
                                objDevice = New PSS.Rules.Device(R1("Device_ID"))
                                For Each R2 In dtReplaceFFNWithOEM.Rows
                                    objDevice.DeletePart(R2("FFNBillcode"))
                                    objDevice.AddPart(R2("EOMBillcode"))
                                Next R2
                                objDevice.Dispose()
                                objDevice = Nothing
                            End If
                        End If

                        '****************************************************************
                        _objTFBillingData.SetDeviceManufOutOfWarranty(R1("Device_ID"))
                        _objTFBillingData.SetDataToOW(CInt(R1("Device_ID")))
                        R1.BeginEdit() : R1("Device_ManufWrty") = 0 : R1.EndEdit()

                        Me.BillServices(R1, CInt(R1("Pallet_ShipType")), CInt(R1("Cust_ID")), booFlatRate, CInt(CDate(strToday).Year & CDate(strToday).Month.ToString("00")))
                    End If

                    If (booUpdRepDate Or booUpdRecptDate) Then
                        _objTFBillingData.UpdateRecptRepDate(booUpdRecptDate, booUpdRepDate, dteRcptDate, dteRepDate, CInt(R1("Device_ID")))
                    End If
                Next R1

                'If strOWDevices.Trim.Length > 0 Then
                '    SendMail.SendMail.SendMail(ConstantData.ExcptEmailFrom, ConstantData.ExcptEmailTo, "", "", "Reset Wrty Status to OW", strOWDevices, "", Nothing)
                'End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtClaimableUnits)
            End Try
        End Sub

        '****************************************************************************************
#End Region

#Region "Auto-Bill"

        '****************************************************************************************
        Public Function SpecialBilling_ByDateRange(ByVal booDockShipDate As Boolean, ByVal iCustID As Integer, _
                                       ByVal strStarDate As String, ByVal strEndDate As String) As Integer
            Dim dtPallets, dtNoBerTargetModels As DataTable
            Dim R1 As DataRow
            Dim i, iDockShipYrMonth, iTodayYrMonth As Integer
            Dim objSpecialBilling As Data.Buisness.SpecialBilling
            Dim strNoBerCapModels As String = ""

            Try
                objSpecialBilling = New Data.Buisness.SpecialBilling()
                '****************************************************
                dtNoBerTargetModels = objSpecialBilling.GetNoBerCapModelList(booDockShipDate, strStarDate, strEndDate, _strEnterprise)
                For Each R1 In dtNoBerTargetModels.Rows
                    If strNoBerCapModels.Trim.Length = 0 Then strNoBerCapModels &= vbCrLf
                    strNoBerCapModels &= R1("Model_Desc")
                Next R1

                If strNoBerCapModels.Trim.Length > 0 Then
                    Throw New Exception("No BER cap set up for the following model(s):" & vbCrLf & strNoBerCapModels)
                End If
                '****************************************************

                iTodayYrMonth = objSpecialBilling.GetTodayYrMonth()
                dtPallets = _objTFBillingData.GetShipBoxes(booDockShipDate, strStarDate, strEndDate, )

                If dtPallets.Rows.Count > 0 Then
                    For Each R1 In dtPallets.Rows
                        'iDockShipYrMonth = 0

                        'If Not IsDBNull(R1("Pkslip_ID")) AndAlso Convert.ToInt32(R1("Pkslip_ID")) > 0 Then
                        '    iDockShipYrMonth = objSpecialBilling.GetDockShipYrMonth(R1("Pkslip_ID"))
                        'End If

                        'If iDockShipYrMonth > 0 AndAlso iDockShipYrMonth < iTodayYrMonth Then
                        '    If MessageBox.Show("This pallet " & R1("Pallett_Name").ToString & " has been shipped before this month. Do you want to skip this pallet and continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                        '        Exit Function
                        '    End If
                        'Else
                            i = SpecialBilling_ByPallet(CInt(R1("Pallett_ID")))
                        'End If

                    Next R1 'loop of pallet
                End If 'Has pallet

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objSpecialBilling = Nothing : Buisness.Generic.DisposeDT(dtPallets)
            End Try
        End Function

        '****************************************************************************************
        Private Function SpecialBilling_ByPallet(ByVal iPalletID As Integer) As Integer
            Dim objSpecialBilling As New Data.Buisness.SpecialBilling()
            Dim objBillGrpAdmin As New Buisness.BillGroupsAdmin()
            Dim dtDevInPallet, dtBillGroup, dtLabor, dtService As DataTable
            Dim R1 As DataRow
            Dim iBillConditionID, iBillGroupCnt, iAutoBillFlag As Integer
            Dim strRandomPickBillGrp, strSvrDateTime As String
            Dim decCustMarkup As Decimal = 0
            Dim i As Integer = 0

            Try
                iBillConditionID = 0 : strRandomPickBillGrp = "" : strSvrDateTime = ""

                strSvrDateTime = Buisness.Generic.MySQLServerDateTime(1)
                dtDevInPallet = objSpecialBilling.GetDeviceShipInBox(iPalletID, _strEnterprise)

                If dtDevInPallet.Rows.Count > 0 Then
                    decCustMarkup = objBillGrpAdmin.GetMarkup(CInt(dtDevInPallet.Rows(0)("Cust_ID")))

                    For Each R1 In dtDevInPallet.Rows
                        iBillGroupCnt = 0 : iAutoBillFlag = 0 : iBillConditionID = 0

                        If objSpecialBilling.IsBillingSpecialExisted(CInt(R1("Device_ID"))) = False Then
                            'IF model is AB then get 
                            If R1("AutoBill").ToString.Trim = "1" Then iBillGroupCnt = objSpecialBilling.GetBillGroupsCnt(CInt(R1("Cust_ID")), CInt(R1("Model_ID")), _strEnterprise)

                            If R1("Pallet_ShipType").ToString.Trim <> "0" Then
                                iBillConditionID = 2 'Device is RUR, Salvage
                                i += objSpecialBilling.CopyConsumedPartToSpecial(R1("Device_ID"), iBillGroupCnt, iBillConditionID, )
                                i += objSpecialBilling.UpdateLabor_AB(CInt(R1("Device_ID")), strSvrDateTime, Convert.ToDouble(R1("Device_LaborLevel")), Convert.ToDouble(R1("Device_LaborCharge")), Convert.ToDouble(R1("Device_PartCharge")), iAutoBillFlag)
                                i += objSpecialBilling.SaveSpecialBillingLog(CInt(R1("Device_ID")), strSvrDateTime, PSS.Core.ApplicationUser.IDuser, strRandomPickBillGrp, iBillConditionID)
                            ElseIf R1("AutoBill").ToString.Trim = "0" Then
                                iBillConditionID = 1 'Model  is Not Auto-Bill
                                i += objSpecialBilling.CopyConsumedPartToSpecial(R1("Device_ID"), iBillGroupCnt, iBillConditionID, )
                                i += objSpecialBilling.UpdateLabor_AB(CInt(R1("Device_ID")), strSvrDateTime, Convert.ToDouble(R1("Device_LaborLevel")), Convert.ToDouble(R1("Device_LaborCharge")), Convert.ToDouble(R1("Device_PartCharge")), iAutoBillFlag)
                                i += objSpecialBilling.SaveSpecialBillingLog(CInt(R1("Device_ID")), strSvrDateTime, PSS.Core.ApplicationUser.IDuser, strRandomPickBillGrp, iBillConditionID)
                            ElseIf iBillGroupCnt = 0 Then
                                iBillConditionID = 4 'No Billgroup, Target or Bill Level created for Device
                                i += objSpecialBilling.CopyConsumedPartToSpecial(R1("Device_ID"), iBillGroupCnt, iBillConditionID, )
                                i += objSpecialBilling.UpdateLabor_AB(CInt(R1("Device_ID")), strSvrDateTime, Convert.ToDouble(R1("Device_LaborLevel")), Convert.ToDouble(R1("Device_LaborCharge")), Convert.ToDouble(R1("Device_PartCharge")), iAutoBillFlag)
                                i += objSpecialBilling.SaveSpecialBillingLog(CInt(R1("Device_ID")), strSvrDateTime, PSS.Core.ApplicationUser.IDuser, strRandomPickBillGrp, iBillConditionID)
                            Else
                                strRandomPickBillGrp = objSpecialBilling.GetRandomBillGroup(CInt(R1("Device_ID")), CInt(R1("Cust_ID")), CInt(R1("Model_ID")), _strEnterprise)
                                If strRandomPickBillGrp.Trim.Length = 0 Then
                                    iBillConditionID = 4 'No Billgroup, Target or Bill Level created for Device
                                    i += objSpecialBilling.CopyConsumedPartToSpecial(CInt(R1("Device_ID")), iBillGroupCnt, iBillConditionID, )
                                    i += objSpecialBilling.UpdateLabor_AB(CInt(R1("Device_ID")), strSvrDateTime, Convert.ToDouble(R1("Device_LaborLevel")), Convert.ToDouble(R1("Device_LaborCharge")), Convert.ToDouble(R1("Device_PartCharge")), iAutoBillFlag)
                                    i += objSpecialBilling.SaveSpecialBillingLog(CInt(R1("Device_ID")), strSvrDateTime, PSS.Core.ApplicationUser.IDuser, strRandomPickBillGrp, iBillConditionID)
                                Else
                                    '-- Part 
                                    dtBillGroup = objSpecialBilling.GetActiveBillGroupInfo(CInt(R1("Cust_ID")), CInt(R1("Model_ID")), _strEnterprise, strRandomPickBillGrp)
                                    If dtBillGroup.Rows.Count = 0 Then
                                        '### SHOULD NEVER HAPPEN
                                        iBillConditionID = 4 'No Billgroup, Target or Bill Level created for Device
                                        i += objSpecialBilling.CopyConsumedPartToSpecial(CInt(R1("Device_ID")), iBillGroupCnt, iBillConditionID, )
                                        i += objSpecialBilling.UpdateLabor_AB(CInt(R1("Device_ID")), strSvrDateTime, Convert.ToDouble(R1("Device_LaborLevel")), Convert.ToDouble(R1("Device_LaborCharge")), Convert.ToDouble(R1("Device_PartCharge")), iAutoBillFlag)
                                        i += objSpecialBilling.SaveSpecialBillingLog(CInt(R1("Device_ID")), strSvrDateTime, PSS.Core.ApplicationUser.IDuser, strRandomPickBillGrp, iBillConditionID)
                                    Else
                                        dtLabor = Me._objTFBillingData.CalcTFLabor(CInt(R1("Cust_ID")), CInt(R1("Model_ID")), _strEnterprise, decCustMarkup, strRandomPickBillGrp)
                                        If dtLabor.Rows.Count = 0 Then
                                            MessageBox.Show("System can't determine labor for special billing of Device ID '" & R1("Device_ID").ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        Else
                                            dtService = Me._objTFBillingData.GetBillcodePartAndPrice(CInt(R1("Model_ID")), dtLabor.Rows(0)("ServiiceBillcodes").ToString)

                                            If dtBillGroup.Select("PSMap_ID = 0").Length > 0 Then
                                                MessageBox.Show("tpsmap of bill group is missing. Device ID: " & R1("Device_ID").ToString & " Bill Group :" & strRandomPickBillGrp, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                            ElseIf dtBillGroup.Select("PsPrice_ID = 0").Length > 0 Then
                                                MessageBox.Show("lpsprice of bill group is missing. Device ID: " & R1("Device_ID").ToString & " Bill Group :" & strRandomPickBillGrp, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                            ElseIf dtService.Select("PSMap_ID = 0").Length > 0 Then
                                                MessageBox.Show("tpsmap of service is missing. Device ID: " & R1("Device_ID").ToString & " Bill Group :" & strRandomPickBillGrp, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                            ElseIf dtBillGroup.Select("PsPrice_ID = 0").Length > 0 Then
                                                MessageBox.Show("lpsprice of service is missing. Device ID: " & R1("Device_ID").ToString & " Bill Group :" & strRandomPickBillGrp, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                            Else
                                                iBillConditionID = 0 : iAutoBillFlag = 1 'Auto-Bill
                                                '-- Labor
                                                i += objSpecialBilling.SpecialBilling_BillGroup(strSvrDateTime, CInt(R1("Device_ID")), decCustMarkup, iBillConditionID, dtBillGroup, PSS.Core.ApplicationUser.IDuser)

                                                i += objSpecialBilling.SpecialBilling_Service(strSvrDateTime, CInt(R1("Device_ID")), iBillConditionID, dtService, PSS.Core.ApplicationUser.IDuser)

                                                Dim dbLabor As Double = (Convert.ToDouble(dtLabor.Rows(0)("Labor")) + Convert.ToDouble(dtLabor.Rows(0)("PartFee")))
                                                Dim dbTotalPartCharge As Double = objSpecialBilling.GetSpecialBillTotalPartCharge(CInt(R1("Device_ID")))
                                                i += objSpecialBilling.UpdateLabor_AB(CInt(R1("Device_ID")), strSvrDateTime, CInt(dtLabor.Rows(0)("MaxLaborLevel")), dbLabor, dbTotalPartCharge, iAutoBillFlag)

                                                i += objSpecialBilling.SaveSpecialBillingLog(CInt(R1("Device_ID")), strSvrDateTime, PSS.Core.ApplicationUser.IDuser, strRandomPickBillGrp, iBillConditionID)
                                            End If  'billcode existing in mapping
                                        End If 'If labor exist
                                    End If 'if billgroup have record & labor exist
                                End If 'has bill group
                            End If 'Auto-bill vs reg bill
                        End If 'AB Existed
                    Next R1 'loop of device
                End If 'has pallet

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objSpecialBilling = Nothing : objBillGrpAdmin = Nothing
                Buisness.Generic.DisposeDT(dtDevInPallet) : Buisness.Generic.DisposeDT(dtBillGroup)
            End Try
        End Function

        '****************************************************************************************
        Public Function RemoveSpecialBilling(ByVal bDockShipDate As Boolean, ByVal strDateStart As String, ByVal strDateEnd As String, _
                                             ByVal iModelID As Integer) As Integer

            Dim dtPallets As DataTable
            Dim R1 As DataRow
            Dim iDockShipYrMonth, iTodayYrMonth As Integer
            Dim objSpecialBilling As Data.Buisness.SpecialBilling
            Dim i As Integer

            Try
                objSpecialBilling = New Data.Buisness.SpecialBilling()

                iTodayYrMonth = objSpecialBilling.GetTodayYrMonth()
                dtPallets = _objTFBillingData.GetShipBoxes(bDockShipDate, strDateStart, strDateEnd, iModelID)
                If dtPallets.Rows.Count > 0 Then
                    For Each R1 In dtPallets.Rows
                        'iDockShipYrMonth = 0

                        'If Not IsDBNull(R1("Pkslip_ID")) AndAlso Convert.ToInt32(R1("Pkslip_ID")) > 0 Then
                        '    iDockShipYrMonth = objSpecialBilling.GetDockShipYrMonth(R1("Pkslip_ID"))
                        'End If

                        'If iDockShipYrMonth > 0 AndAlso iDockShipYrMonth < iTodayYrMonth Then
                        '    If MessageBox.Show("This pallet " & R1("Pallett_Name").ToString & " has been shipped before this month. Do you want to skip this pallet and continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                        '        Exit Function
                        '    End If
                        'Else
                        i += RemoveSpecialBilling_ByPallet(CInt(R1("Pallett_ID")))
                        'End If
                    Next R1 'loop of pallet
                End If 'Has pallet

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objSpecialBilling = Nothing : Buisness.Generic.DisposeDT(dtPallets)
            End Try
        End Function

        '****************************************************************************************
        Private Function RemoveSpecialBilling_ByPallet(ByVal iPalletID As Integer) As Integer
            Dim objSpecialBilling As Data.Buisness.SpecialBilling
            Dim dtDevInPallet, dtSBLog As DataTable
            Dim R1, R2 As DataRow
            Dim strSvrDateTime, strBillcodeIDs, strSBCompletedDate, strSB_BillGroup As String
            Dim i, iSBUserID, iBillConditionID As Integer

            Try
                objSpecialBilling = New Data.Buisness.SpecialBilling()
                strSvrDateTime = Buisness.Generic.MySQLServerDateTime(1)
                dtDevInPallet = objSpecialBilling.GetDeviceShipInBox(iPalletID, _strEnterprise)

                strBillcodeIDs = "" : strSBCompletedDate = "" : strSB_BillGroup = ""

                If dtDevInPallet.Rows.Count > 0 Then
                    For Each R1 In dtDevInPallet.Rows
                        dtSBLog = objSpecialBilling.GetSpecialBillingBillcodes(CInt(R1("Device_ID")))
                        If dtSBLog.Rows.Count > 0 Then
                            For Each R2 In dtSBLog.Rows
                                If strBillcodeIDs.Trim.Length > 0 Then strBillcodeIDs &= ", "
                                strBillcodeIDs &= R2("Billcode_ID").ToString
                            Next R2

                            If Not IsDBNull(dtSBLog.Rows(0)("SpecialBillCompletedDate")) Then
                                strSBCompletedDate = Convert.ToDateTime(dtSBLog.Rows(0)("SpecialBillCompletedDate")).ToString("yyyy-MM-dd hh:mm:ss")
                            Else
                                strSBCompletedDate = Convert.ToDateTime(dtSBLog.Rows(0)("TransDate")).ToString("yyyy-MM-dd hh:mm:ss")
                            End If
                            If Not IsDBNull(dtSBLog.Rows(0)("User_ID")) Then
                                iSBUserID = Convert.ToInt32(dtSBLog.Rows(0)("User_ID"))
                            Else
                                iSBUserID = Convert.ToInt32(dtSBLog.Rows(0)("TransUserID"))
                            End If

                            If Not IsDBNull(dtSBLog.Rows(0)("BG_Bill_Group")) Then strSB_BillGroup = dtSBLog.Rows(0)("BG_Bill_Group").ToString
                            If Not IsDBNull(dtSBLog.Rows(0)("DBill_Condition")) Then
                                iBillConditionID = Convert.ToInt32(dtSBLog.Rows(0)("DBill_Condition"))
                            Else
                                iBillConditionID = Convert.ToInt32(dtSBLog.Rows(0)("TransBillConditionID"))
                            End If

                            i += objSpecialBilling.RemoveSpecialBilling(CInt(R1("Device_ID")))
                            i += objSpecialBilling.SaveSpecialBillingDeletion(CInt(R1("Device_ID")), strSBCompletedDate, iSBUserID, strSB_BillGroup, iBillConditionID, strBillcodeIDs, PSS.Core.ApplicationUser.IDuser)
                        End If 'AB Existed

                        strBillcodeIDs = "" : strSBCompletedDate = "" : strSB_BillGroup = ""
                    Next R1 'loop of device
                End If 'has pallet

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                objSpecialBilling = Nothing : Buisness.Generic.DisposeDT(dtDevInPallet)
            End Try
        End Function

        '****************************************************************************************

#End Region

#Region "Flat-Rate Billing"

        '****************************************************************************************
        Public Function UpdateFlatRateBilling_ByDailyDockShipDate(ByVal iCustID As Integer, ByVal strDateStart As String, ByVal strDateEnd As String) As String
            Dim strSql, strMsg As String
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objDevice As Rules.Device
            Dim iInvoiceYrMonth As Integer = 0

            Try
                dt = _objTFBillingData.GetDockShipFinishedGoodDevices(iCustID, strDateStart, strDateEnd)
                For Each R1 In dt.Rows
                    iInvoiceYrMonth = CInt(CDate(R1("ShipDate")).Year & CDate(R1("ShipDate")).Month.ToString("00"))
                    objDevice = New Rules.Device(R1("Device_ID"))

                    objDevice.Update(iInvoiceYrMonth)
                    If Not IsNothing(objDevice) Then
                        objDevice.Dispose() : objDevice = Nothing
                    End If
                Next R1

                If dt.Rows.Count = 0 Then
                    strMsg = "No data"
                Else
                    strMsg = "Successfully update billing for " & dt.Rows.Count & " record(s)."
                End If

                Return strMsg
            Catch ex As Exception
                Throw ex
            Finally
                Data.Buisness.Generic.DisposeDT(dt)
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
            End Try
        End Function

        '****************************************************************************************

#End Region

    End Class
End Namespace

