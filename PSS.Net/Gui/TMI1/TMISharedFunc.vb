Option Explicit On 

Namespace Gui
    Public Class TMISharedFunc

        Public Shared _strRequiredBillcodes() = New String() {"Depot Repaired", "Exception Repairs", "Exception Repairs Quote Rejected", "Scrap", "PSS Warranty No Fault Found", "Repaired PSS Warranty"}

        '*************************************************************************************************************
        Public Shared Function BillExceptionRepairs(ByVal iDeviceID As Integer, ByVal decMarkUp As Decimal, _
                                                    ByVal dtBilledBillCode As DataTable, _
                                                    Optional ByVal booCheckTechHrAndEstPartCost As Boolean = False) As Integer
            Dim i As Integer = 0

            Try
                Dim objTMIShip As New PSS.Data.Buisness.TMIRecShip()
                'Dim objBillRule As New Rules.Device(iDeviceID)
                'Dim dbAggCharge As Double = objBillRule.AggBilling()

                If dtBilledBillCode.Select("Billcode_Desc = 'Depot Repaired'").Length > 0 Then
                    objTMIShip.UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Exception Repairs'").Length > 0 Then
                    objTMIShip.UpdateExcptRepPartCharge(iDeviceID, decMarkUp, booCheckTechHrAndEstPartCost)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Exception Repairs Quote Rejected'").Length > 0 Then
                    objTMIShip.UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Scrap'").Length > 0 Then
                    objTMIShip.UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'PSS Warranty No Fault Found'").Length > 0 Then
                    objTMIShip.UpdatePartChargeToZero(iDeviceID)
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Repaired PSS Warranty'").Length > 0 Then
                    objTMIShip.UpdatePartChargeToZero(iDeviceID)
                End If

                'If objTMIShip.IsDeviceHasExceptionRepairs(iDeviceID) = True Then
                '    i = objTMIShip.UpdateExcptRepPartCharge(iDeviceID, decMarkUp)
                'ElseIf objTMIShip.IsDeviceHasPSSWrtyService(iDeviceID) = True Then
                '    i = objTMIShip.UpdatePSSWrtyLaborAndPartCharge(iDeviceID, dbAggCharge)
                'Else
                '    i = objTMIShip.UpdatePartChargeToZero(iDeviceID)
                'End If

                'objBillRule.Dispose()
                'objBillRule = Nothing

                objTMIShip = Nothing

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************
        Public Shared Function ValidateServices(ByVal strAddingBillcode As String, ByVal dtBilledBillCode As DataTable) As Boolean
            Dim booReturnVal As Boolean = True

            Try
                If dtBilledBillCode.Select("Billcode_Desc = 'Depot Repaired'").Length > 0 Then
                    If strAddingBillcode = "Ship Back Hard Drive" Then
                        MessageBox.Show("Can't have combination of ""Depot repair"" and ""Ship Back Hard Drive"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False
                    End If
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Exception Repairs'").Length > 0 Then
                    If strAddingBillcode = "Ship Back Hard Drive" Then
                        MessageBox.Show("Can't have combination of ""Exception Repairs"" and ""Ship Back Hard Drive"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False
                    End If
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Exception Repairs Quote Rejected'").Length > 0 Then
                    'Accept all other services...
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Scrap'").Length > 0 Then
                    If strAddingBillcode = "Ship Back Hard Drive With Unit" Then
                        MessageBox.Show("Can't have combination of ""Scrap"" and ""Ship Back Hard Drive With Unit"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False
                    End If
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'PSS Warranty No Fault Found'").Length > 0 Then
                    If strAddingBillcode = "Ship Back Hard Drive" OrElse strAddingBillcode = "Ship Back Hard Drive With Unit" Then
                        MessageBox.Show("Can't have combination of ""PSS Warranty No Fault Found"" and ""Ship Back Hard Drive"" or ""Ship Back Hard Drive With Unit"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False
                    End If
                ElseIf dtBilledBillCode.Select("Billcode_Desc = 'Repaired PSS Warranty'").Length > 0 Then
                    If strAddingBillcode = "Ship Back Hard Drive" Then
                        MessageBox.Show("Can't have combination of ""Repaired PSS Warranty"" and ""Ship Back Hard Drive"".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False
                    End If
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtBilledBillCode)
            End Try
        End Function

        '*************************************************************************************************************
        Public Shared Function IsDeviceHasMainService(ByVal dtBilledBillCode As DataTable) As Boolean
            Dim booReturnVal As Boolean = False
            Dim i As Integer

            Try
                For i = 0 To _strRequiredBillcodes.Length - 1
                    If dtBilledBillCode.Select("Billcode_Desc = '" & _strRequiredBillcodes(i) & "'").Length > 0 Then
                        booReturnVal = True : Exit For
                    End If
                Next i

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtBilledBillCode)
            End Try
        End Function

        '*************************************************************************************************************
        Public Shared Function IsMainService(ByVal strBillcodeDesc As String) As Boolean
            Dim i As Integer
            Dim booReturnVal As Boolean = False

            Try
                For i = 0 To _strRequiredBillcodes.Length - 1
                    If strBillcodeDesc = _strRequiredBillcodes(i) Then
                        booReturnVal = True : Exit For
                    End If
                Next i

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************
        Public Shared Function GetMainService(ByVal dtBilledBillCode As DataTable) As String
            Dim i As Integer
            Dim strMainService As String = ""

            Try
                For i = 0 To _strRequiredBillcodes.Length - 1
                    If dtBilledBillCode.Select("Billcode_Desc = '" & _strRequiredBillcodes(i) & "'").Length > 0 Then
                        strMainService = _strRequiredBillcodes(i) : Exit For
                    End If
                Next i

                Return strMainService
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtBilledBillCode)
            End Try
        End Function

        '*************************************************************************************************************

    End Class
End Namespace