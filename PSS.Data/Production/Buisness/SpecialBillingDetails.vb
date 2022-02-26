Option Explicit On 

Namespace Buisness
    Public Class SpecialBillingDetails

        Private objMisc As Production.Misc

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************

        '*****************************************************************
        Public Function GetBillingDataPerCustomerByShipWkDt(ByVal iCust_ID As Integer, _
                                                            ByVal strDateStart As String, _
                                                            ByVal strDateEnd As String) As DataSet
            Dim strSql As String = ""
            Dim dtDeviceLabor , dtConsumedBill , dtBillGrpBill, dtModelTarget As DataTable
            Dim R1 As DataRow
            Dim strDevice_IDs As String = ""
            Dim dsData As New DataSet()

            Try
                '*************************************
                'Get device and labor info
                '*************************************
                strSql = "SELECT distinct tdevice.Device_ID, tdevice.Model_ID, " & Environment.NewLine
                strSql &= "Device_SN as SN, Model_Desc as 'Model', " & Environment.NewLine
                strSql &= " CASE " & Environment.NewLine
                strSql &= "   WHEN Cust_ID = 2019 THEN 'ATCLE'" & Environment.NewLine
                strSql &= "   WHEN Cust_ID = 2113 THEN IF (csin_EnterpriseCode is null, '', csin_EnterpriseCode)" & Environment.NewLine
                strSql &= "   ELSE ''" & Environment.NewLine
                strSql &= " END AS 'Ent' " & Environment.NewLine
                strSql &= ", Device_RecWorkDate as 'RecDt', Device_dateship as 'ShipDt' " & Environment.NewLine
                strSql &= ", Device_LaborLevel as 'Lvl', Device_LaborCharge as 'LaborChrg', Device_PartCharge as 'PartChrg' " & Environment.NewLine
                strSql &= ", IF ( Device_LaborLevel_AutoBilled is null, '', Device_LaborLevel_AutoBilled) as 'AB Lvl' " & Environment.NewLine
                strSql &= ", IF ( Device_LaborCharge_AutoBilled is null, '', Device_LaborCharge_AutoBilled ) as 'AB LaborChrg' " & Environment.NewLine
                strSql &= ", IF ( Device_PartCharge_AutoBilled is null, '', Device_PartCharge_AutoBilled ) as 'AB PartChrg' " & Environment.NewLine
                strSql &= ", IF (tbillcondition.BC_Value is null, 'No special Billing', tbillcondition.BC_SDesc) as 'Bill Condtion' " & Environment.NewLine
                strSql &= ", IF (tdevicebill_special_log.BG_Bill_Group is null, '', tdevicebill_special_log.BG_Bill_Group ) as 'Bill Group' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel on tdevice.model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tlocation on tdevice.loc_id = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN cstincomingdata ON tdevice.Device_ID = cstincomingdata.Device_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill_special_log ON tdevice.Device_ID = tdevicebill_special_log.Device_ID " & Environment.NewLine
                If iCust_ID = 2019 Then
                    strSql &= "LEFT OUTER JOIN tdevicebill_560 on tdevice.Device_ID = tdevicebill_560.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tbillcondition on tdevicebill_560.DBill_Condition = tbillcondition.BC_Value " & Environment.NewLine
                ElseIf iCust_ID = 2113 Then
                    strSql &= "LEFT OUTER JOIN tdevicebill_563 on tdevice.Device_ID = tdevicebill_563.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tbillcondition on tdevicebill_563.DBill_Condition = tbillcondition.BC_Value " & Environment.NewLine
                Else
                    strSql &= "LEFT OUTER JOIN tdevicebill_special on tdevice.Device_ID = tdevicebill_special.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN tbillcondition on tdevicebill_special.DBill_Condition = tbillcondition.BC_Value " & Environment.NewLine
                End If
                strSql &= "WHERE tlocation.Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strSql &= "AND tdevice.Device_dateship Between '" & strDateStart & " 00:00:00' AND '" & strDateStart & " 23:59:59' "

                Me.objMisc._SQL = strSql : dtDeviceLabor = Me.objMisc.GetDataTable

                If dtDeviceLabor.Rows.Count > 0 Then
                    ''*************************************
                    'Build Device_ID string
                    '*************************************
                    For Each R1 In dtDeviceLabor.Rows
                        If strDevice_IDs.Trim.Length > 0 Then strDevice_IDs &= ", "
                        strDevice_IDs &= R1("Device_ID")
                    Next R1

                    '*************************************
                    'Get data from tdevicebill (consumed)
                    '*************************************
                    strSql = "SELECT tdevicebill.Device_ID, BillCode_Desc as 'BillCode', DBill_InvoiceAmt as 'InvAmt' " & Environment.NewLine
                    strSql &= "FROM tdevicebill " & Environment.NewLine
                    strSql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevicebill.device_id IN (" & strDevice_IDs & ");"
                    Me.objMisc._SQL = strSql
                    dtConsumedBill = Me.objMisc.GetDataTable

                    '*************************************
                    'Get data from special billing
                    '*************************************
                    Select Case iCust_ID
                        Case 2113
                            strSql = "SELECT tdevicebill_563.Device_ID, BillCode_Desc as 'BillCode', DBill_InvoiceAmt as 'InvAmt' " & Environment.NewLine
                            strSql &= "FROM tdevicebill_563 " & Environment.NewLine
                            strSql &= "INNER JOIN lbillcodes ON tdevicebill_563.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                            strSql &= "WHERE tdevicebill_563.device_id IN (" & strDevice_IDs & ");"
                        Case 2019
                            strSql = "SELECT tdevicebill_560.Device_ID, BillCode_Desc as 'BillCode', DBill_InvoiceAmt as 'InvAmt' " & Environment.NewLine
                            strSql &= "FROM tdevicebill_560 " & Environment.NewLine
                            strSql &= "INNER JOIN lbillcodes ON tdevicebill_560.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                            strSql &= "WHERE tdevicebill_560.device_id IN (" & strDevice_IDs & ");"
                        Case Else
                            'This will return emty set
                            strSql = "SELECT tdevicebill_special.Device_ID, BillCode_Desc as 'BillCode', DBill_InvoiceAmt as 'InvAmt' " & Environment.NewLine
                            strSql &= "FROM tdevicebill_special " & Environment.NewLine
                            strSql &= "INNER JOIN lbillcodes ON tdevicebill_special.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                            strSql &= "WHERE tdevicebill_special.device_id IN (" & strDevice_IDs & ");"
                    End Select

                    Me.objMisc._SQL = strSql : dtBillGrpBill = Me.objMisc.GetDataTable

                    '*************************************
                    'Get data from tmodeltarget
                    '*************************************
                    strSql = "SELECT * FROM tmodeltarget WHERE MT_Cust_ID = " & iCust_ID & ";"
                    Me.objMisc._SQL = strSql : dtModelTarget = Me.objMisc.GetDataTable

                    dsData.Tables.Add(dtDeviceLabor)
                    dsData.Tables.Add(dtConsumedBill)
                    dsData.Tables.Add(dtBillGrpBill)
                    dsData.Tables.Add(dtModelTarget)
                End If

                Return dsData
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : Generic.DisposeDT(dtDeviceLabor) : Generic.DisposeDT(dtConsumedBill) : Generic.DisposeDT(dtBillGrpBill)
                Generic.DisposeDT(dtModelTarget) : Generic.DisposeDS(dsData)
            End Try
        End Function

        '*****************************************************************

    End Class
End Namespace