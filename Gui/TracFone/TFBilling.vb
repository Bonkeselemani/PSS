Option Explicit On 

Imports PSS.Data

Namespace Gui.TracFone
    Public Class TFBilling
        Private _objTFBillingData As Buisness.TracFone.TFBillingData

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

        '****************************************************************************************
        Public Function BillServices(ByVal drDeviceInfo As DataRow, _
                                     ByVal iShipType As Integer, _
                                     ByVal iCustID As Integer) As Boolean
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
                    'Bill Final Func Insp: Cosmetic Refurbished, Functional Repair,Functional Repair
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
                    'Bill AQL: Cosmetic Fluff-Buff, Cosmetic Refurbished, Functional Repair,Functional Repair
                    ''******************************************************************************************
                    If Buisness.Generic.IsBillcodeMapped(drDeviceInfo("Model_ID"), 1616) > 0 Then
                        If Buisness.Generic.IsBillcodeExisted(drDeviceInfo("Device_ID"), 1616) = False Then objDevice.AddPart(1616)
                    Else
                        Throw New Exception("AQL service code is not map. Please contact Material department.")
                    End If
                    '**************************************************************
                    'Bill Functional Triage service code 
                    '**************************************************************
                    If drDeviceInfo("FuncRep") = 1 OrElse iMaxPartLevel > 1 OrElse _objTFBillingData.HasPrestestRecord(drDeviceInfo("Device_ID")) = True Then
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
                '***** LG, Nokia, Motorola & Samsung using lpsprice.PSPrice_StndCost while objDevice.Update() using tdevicebill.DBill_InvoiceAmt
                objDevice.Update()

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
        Public Sub FixLGSSReceiptDate(ByVal iPalletID As Integer)
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

                        Me.BillServices(R1, CInt(R1("Pallet_ShipType")), CInt(R1("Cust_ID")))
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

    End Class
End Namespace

