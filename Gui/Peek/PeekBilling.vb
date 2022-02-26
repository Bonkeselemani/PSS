Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Peek
    Public Class PeekBilling

        '****************************************************************************************
        Public Function BillPartsServices(ByVal iPackingSlipID As Integer) As Integer
            Const iCustID As Integer = 2288
            Dim dsShipment As DataSet
            Dim dtHandsetLabor, dtAccessoryLabor, dtBillableBillcodes As DataTable
            Dim objPeekBiz As PSS.Data.Buisness.Peek.Biz
            Dim iDeviceQty, iAccessoriesQty, i, iLaborLevel As Integer
            Dim decLabor As Decimal
            Dim R1 As DataRow
            Dim objDevice As PSS.Rules.Device
            Dim booFirstAccessoryItem As Boolean

            Try
                iDeviceQty = 0 : iAccessoriesQty = 0 : i = 0 : iLaborLevel = 0
                decLabor = 0.0

                objPeekBiz = New PSS.Data.Buisness.Peek.Biz()
                dsShipment = objPeekBiz.GetShipmentDetail(iPackingSlipID)

                '******************************************************
                'Accessory
                '******************************************************
                If dsShipment.Tables("Accessory").Rows.Count > 0 Then
                    For Each R1 In dsShipment.Tables("Accessory").Rows : iAccessoriesQty += CInt(R1("Qty")) : Next R1
                    dtAccessoryLabor = objPeekBiz.GetAccessoryLaborByVolume(iAccessoriesQty, iCustID)

                    If dtAccessoryLabor.Rows.Count = 0 Then
                        Throw New Exception("Accessories labor is missing.")
                    ElseIf dtAccessoryLabor.Rows.Count > 1 Then
                        Throw New Exception("Accessories labor is existed more than one.")
                    Else
                        booFirstAccessoryItem = True
                        'Bill services
                        For Each R1 In dsShipment.Tables("Accessory").Rows
                            decLabor = (CInt(R1("Qty")) * CDec(dtAccessoryLabor.Rows(0)("AdditionalVolumePrice")))

                            If CInt(R1("Model_ID")) <> 1344 Then
                                If Not IsNothing(objDevice) Then
                                    objDevice.Dispose()
                                    objDevice = Nothing
                                End If
                                objDevice = New PSS.Rules.Device(R1("Device_ID"))
                                dtBillableBillcodes = objDevice.BillableBillcodes()

                                ''******************************************
                                '' Bill fulfillment service
                                ''******************************************
                                'If Generic.IsBillcodeMapped(R1("Model_ID"), 1808) > 0 Then
                                '    If Generic.IsBillcodeExisted(R1("Device_ID"), 1808) = False Then objDevice.AddPart(1808)
                                'Else
                                '    Throw New Exception("Fulfillment service code is not map. Please contact Material department.")
                                'End If

                                If CInt(R1("Accessory")) = 1 Then   'Batteries
                                    '******************************************
                                    ' Bill Tape/Staple
                                    '******************************************
                                    If Generic.IsBillcodeMapped(R1("Model_ID"), 1807) > 0 Then
                                        'If Generic.IsBillcodeExisted(R1("Device_ID"), 1807) = False Then objDevice.AddPart(1807)
                                        decLabor += CDec(dtBillableBillcodes.Select("BillCode_ID = 1807")(0)("PSPrice_StndCost")) * CInt(R1("Qty"))
                                    Else
                                        Throw New Exception("Tape/Staple bill code is not map. Please contact Material department.")
                                    End If
                                ElseIf CInt(R1("Accessory")) = 3 Then   'Carrying Cases
                                    '******************************************
                                    ' Bill Bag
                                    '******************************************
                                    If Generic.IsBillcodeMapped(R1("Model_ID"), 1806) > 0 Then
                                        'If Generic.IsBillcodeExisted(R1("Device_ID"), 1806) = False Then objDevice.AddPart(1806)
                                        decLabor += CDec(dtBillableBillcodes.Select("BillCode_ID = 1806")(0)("PSPrice_StndCost")) * CInt(R1("Qty"))
                                    Else
                                        Throw New Exception("Bag bill code is not map. Please contact Material department.")
                                    End If
                                    '******************************************
                                    ' Bill Label
                                    '******************************************
                                    If Generic.IsBillcodeMapped(R1("Model_ID"), 1805) > 0 Then
                                        'If Generic.IsBillcodeExisted(R1("Device_ID"), 1805) = False Then objDevice.AddPart(1805)
                                        decLabor += CDec(dtBillableBillcodes.Select("BillCode_ID = 1805")(0)("PSPrice_StndCost")) * CInt(R1("Qty"))
                                    Else
                                        Throw New Exception("Label bill code is not map. Please contact Material department.")
                                    End If
                                ElseIf CInt(R1("Accessory")) = 4 Then
                                    '******************************************
                                    ' Bill Label
                                    '******************************************
                                    If Generic.IsBillcodeMapped(R1("Model_ID"), 1805) > 0 Then
                                        'If Generic.IsBillcodeExisted(R1("Device_ID"), 1805) = False Then objDevice.AddPart(1805)
                                        decLabor += CDec(dtBillableBillcodes.Select("BillCode_ID = 1805")(0)("PSPrice_StndCost")) * CInt(R1("Qty"))
                                    Else
                                        Throw New Exception("Label bill code is not map. Please contact Material department.")
                                    End If
                                End If

                                'First Item will get the Base Charge
                                If booFirstAccessoryItem = True Then decLabor += CDec(dtAccessoryLabor.Rows(0)("BasePrice"))
                                booFirstAccessoryItem = False
                            Else    'Return Stamp
                                decLabor = 0.0
                            End If

                            'Update Labor
                            i += objPeekBiz.UpdateLabor(R1("Device_ID"), decLabor, iLaborLevel)
                            '******************************************
                        Next R1
                    End If
                End If

                '******************************************************
                'Handset
                '******************************************************
                If dsShipment.Tables("HandSet").Rows.Count > 0 Then
                    iDeviceQty = dsShipment.Tables("HandSet").Rows.Count
                    dtHandsetLabor = objPeekBiz.GetHandSetLaborByVolume(iDeviceQty, iCustID)

                    If dtHandsetLabor.Rows.Count = 0 Then
                        Throw New Exception("Device labor is missing.")
                    ElseIf dtHandsetLabor.Rows.Count > 1 Then
                        Throw New Exception("Device labor is existed more than one.")
                    Else
                        decLabor = CDec(dtHandsetLabor.Rows(0)("BasePrice")) + CDec(dtHandsetLabor.Rows(0)("AdditionalVolumePrice"))
                        'Bill services
                        For Each R1 In dsShipment.Tables("HandSet").Rows
                            objDevice = New PSS.Rules.Device(R1("Device_ID"))
                            ''******************************************
                            '' Bill fulfillment service
                            ''******************************************
                            'If Generic.IsBillcodeMapped(R1("Model_ID"), 1808) > 0 Then
                            '    If Generic.IsBillcodeExisted(R1("Device_ID"), 1808) = False Then objDevice.AddPart(1808)
                            'Else
                            '    Throw New Exception("Fulfillment service code is not map. Please contact Material department.")
                            'End If

                            'Update Labor
                            i += objPeekBiz.UpdateLabor(R1("Device_ID"), decLabor, iLaborLevel)
                        Next R1
                    End If
                End If

                Return iDeviceQty + iAccessoriesQty
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dsShipment) Then
                    dsShipment.Dispose()
                    dsShipment = Nothing
                End If
                objPeekBiz = Nothing
                Generic.DisposeDT(dtHandsetLabor)
                Generic.DisposeDT(dtAccessoryLabor)
                R1 = Nothing
            End Try
        End Function

        '****************************************************************************************

    End Class
End Namespace