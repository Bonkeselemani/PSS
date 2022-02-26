Option Explicit On 

Namespace Buisness
    Public Class SpecialBilling

        Private _objDataProc As DBQuery.DataProc

#Region "Constructor/Destructor"

        '******************************************************************
        Public Sub New()
            Try
                Me._objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)
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

        '*************************************************************************************************************************
        Public Function GetRandomBillGroupOldMethod(ByVal iDevice_ID As Integer, ByVal iCust_ID As Integer, ByVal iModel_ID As Integer, _
                                                   ByVal strEnterprise As String) As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim iRndNum, iLoopCounter, iLowerBound As Integer, iUpperBound As Integer
            Dim strRndBillGroup As String
            Dim r As Random

            Try
                dt1 = Me.GetBillGroupsForCustModelEnterprise(iCust_ID, iModel_ID, strEnterprise)
                If dt1.Rows.Count = 0 Then Return ""

                iLoopCounter = 1 : iLowerBound = 1 : strRndBillGroup = ""
                iUpperBound = dt1.Rows.Count
                'iRndNum = CInt(Int((iUpperBound * Rnd()) + iLowerBound))
                r = New Random(iDevice_ID)
                iRndNum = r.Next(iLowerBound, iUpperBound)

                '*************************************************************
                '//Select the Bill group based on the random number generated.
                For Each R1 In dt1.Rows
                    If iRndNum = iLoopCounter Then
                        strRndBillGroup = Trim(R1("bg_bill_group")) : Exit For
                    End If

                    iLoopCounter += 1
                Next R1
                '*************************************************************
                Return strRndBillGroup

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)  'Reset()
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetRandomBillGroup(ByVal iDevice_ID As Integer, ByVal iCust_ID As Integer, ByVal iModel_ID As Integer, _
                                           ByVal strEnterprise As String) As String
            Dim i, iSumLast4DigitsOfDeviceID, iBillGroupNo As Integer
            Dim strLast4DigitsOfDeviceID, strSelBillGroupName As String
            Dim dt As DataTable

            Try
                strSelBillGroupName = "" : strLast4DigitsOfDeviceID = ""

                dt = Me.GetBillGroupsForCustModelEnterprise(iCust_ID, iModel_ID, strEnterprise)
                If dt.Rows.Count = 0 Then Return ""

                strLast4DigitsOfDeviceID = Right(iDevice_ID.ToString, 4)
                For i = 0 To strLast4DigitsOfDeviceID.Length - 1
                    iSumLast4DigitsOfDeviceID += CInt(Mid(strLast4DigitsOfDeviceID, i + 1, 1))
                Next i

                iBillGroupNo = CInt(Right(iSumLast4DigitsOfDeviceID.ToString, 1))

                For i = 0 To dt.Rows.Count - 1
                    If dt.Rows(i)("bg_bill_group").ToString = "BG" & iBillGroupNo Then strSelBillGroupName = "BG" & iBillGroupNo
                Next i

                Return strSelBillGroupName

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetBillGroupsForCustModelEnterprise(ByVal iCust_ID As Integer, _
                                                            ByVal iModel_ID As Integer, _
                                                            ByVal strEnterpriseCode As String) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT distinct bg_bill_group " & Environment.NewLine
                strsql &= "FROM tbillgroup " & Environment.NewLine
                strsql &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strsql &= "AND  bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strsql &= "AND  bg_enterprise = '" & strEnterpriseCode & "' " & Environment.NewLine
                strsql &= "AND bg_inactive = 0;"
                Return _objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetBillGroupsCnt(ByVal iCust_ID As Integer, ByVal iModel_ID As Integer, ByVal strEnterpriseCode As String) As Integer
            Dim strsql As String = ""

            Try
                strsql = "SELECT distinct bg_bill_group " & Environment.NewLine
                strsql &= "FROM tbillgroup " & Environment.NewLine
                strsql &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strsql &= "AND  bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strsql &= "AND  bg_enterprise = '" & strEnterpriseCode & "' " & Environment.NewLine
                strsql &= "AND bg_inactive = 0 "
                Return _objDataProc.GetDataTable(strsql).Rows.Count
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetDeviceShipInBox(ByVal iPalletID As Integer, ByVal strEnterprise As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Distinct tdevice.Device_ID, tdevice.Device_LaborCharge, tdevice.Device_PartCharge, tdevice.Device_LaborLevel" & Environment.NewLine
                strSql &= ", tmodeltarget.AutoBill, tdevice.Model_ID, tpallett.Pallet_ShipType, tpallett.Cust_ID " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpallett ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodeltarget ON tdevice.Model_ID = tmodeltarget.MT_Model_ID AND tlocation.Cust_ID = tmodeltarget.MT_Cust_ID AND MT_Enterprise = '" & strEnterprise & "'" & Environment.NewLine
                strSql &= "WHERE tdevice.Pallett_ID = " & iPalletID
                Return _objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function CopyConsumedPartToSpecial(ByVal iDeviceID As Integer, ByVal iBillGrpCnt As Integer, _
                                                  ByVal iBillConditionID As Integer, Optional ByVal iTransfer_Part_Service As Integer = 0) As Integer
            Dim strsql, strField, strValue As String
            Dim dt1, dt2 As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try

                '********************************************
                'Get stuff from tdevicebill
                '********************************************
                strsql = "SELECT tdevicebill.* FROM tdevicebill " & Environment.NewLine
                If iTransfer_Part_Service > 0 Then strsql &= "INNER JOIN lbillcodes ON tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                strsql &= "WHERE tdevicebill.device_id = " & iDeviceID & " " & Environment.NewLine
                If iTransfer_Part_Service > 0 Then strsql &= " AND lbillcodes.BillType_ID = " & iTransfer_Part_Service & Environment.NewLine
                dt1 = _objDataProc.GetDataTable(strsql)
                '********************************************
                If dt1.Rows.Count = 0 Then Return i

                '********************************************
                For Each R1 In dt1.Rows
                    '**********************************************
                    'Check if billcode already existed then skip it
                    '**********************************************
                    Generic.DisposeDT(dt2)
                    strsql = "SELECT count(*) as cnt FROM tdevicebill_special " & Environment.NewLine
                    strsql &= "WHERE device_id = " & iDeviceID & Environment.NewLine
                    strsql &= " AND billcode_id = " & R1("BillCode_ID") & ";"
                    dt2 = _objDataProc.GetDataTable(strsql)

                    If dt2.Rows(0)("cnt") = 0 Then
                        strField = "" : strValue = ""
                        '********************************************
                        'Insert into tdveicbill_563
                        '********************************************
                        strsql = "insert into tdevicebill_special (DBill_Condition, " & Environment.NewLine
                        If Not IsDBNull(R1("DBill_RegPartPrice")) Then
                            strField &= "DBill_RegPartPrice " & Environment.NewLine
                            strValue &= R1("DBill_RegPartPrice") & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("DBill_AvgCost")) Then
                            strField &= ", DBill_AvgCost " & Environment.NewLine
                            strValue &= ", " & R1("DBill_AvgCost") & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("DBill_StdCost")) Then
                            strField &= ", DBill_StdCost " & Environment.NewLine
                            strValue &= ", " & R1("DBill_StdCost") & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("DBill_InvoiceAmt")) Then
                            strField &= ", DBill_InvoiceAmt " & Environment.NewLine
                            strValue &= ", " & R1("DBill_InvoiceAmt") & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("Device_ID")) Then
                            strField &= ", Device_ID " & Environment.NewLine
                            strValue &= ", " & R1("Device_ID") & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("BillCode_ID")) Then
                            strField &= ", BillCode_ID " & Environment.NewLine
                            strValue &= ", " & R1("BillCode_ID") & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Fail_ID")) Then
                            strField &= ", Fail_ID " & Environment.NewLine
                            strValue &= ", " & R1("Fail_ID") & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Part_Number")) Then
                            strField &= ", Part_Number " & Environment.NewLine
                            strValue &= ", '" & R1("Part_Number") & "'" & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Repair_ID")) Then
                            strField &= ", Repair_ID " & Environment.NewLine
                            strValue &= ", " & R1("Repair_ID").ToString & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Comp_ID")) Then
                            strField &= ", Comp_ID " & Environment.NewLine
                            strValue &= ", " & R1("Comp_ID") & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("User_ID")) Then
                            strField &= ", User_ID " & Environment.NewLine
                            strValue &= ", " & R1("User_ID") & Environment.NewLine
                        End If

                        'Use default value
                        'strField &= ", BG_ID " & Environment.NewLine
                        'strValue &= 0

                        strField &= ", DBill_Condition " & Environment.NewLine
                        strValue &= ", " & iBillConditionID

                        If Not IsDBNull(R1("Date_Rec")) Then
                            strField &= ", Date_Rec " & Environment.NewLine
                            strValue &= ", '" & Format(R1("Date_Rec"), "yyyy-MM-dd") & "'" & Environment.NewLine
                        Else
                            strField &= ", Date_Rec " & Environment.NewLine
                            strValue &= ", '" & Format(Now, "yyyy-MM-dd") & "'" & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("ReplPartSN")) Then
                            strField &= ", ReplPartSN " & Environment.NewLine
                            strValue &= ", '" & R1("ReplPartSN") & "'" & Environment.NewLine
                        End If

                        strsql = "INSERT INTO tdevicebill_special ( " & strField & ") values (" & strValue
                        strsql &= ");"

                        i += _objDataProc.ExecuteNonQuery(strsql)
                        '********************************************
                    End If

                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            Finally
                Generic.DisposeDT(dt1) : Generic.DisposeDT(dt2)
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetActiveBillGroupInfo(ByVal iCustID As Integer, ByVal iModelID As Integer, _
                                               ByVal strEnterprise As String, ByVal strBillGroupName As String) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT tbillgroup.*, tpsmap.LaborLevel, lbillcodes.BillType_ID" & Environment.NewLine
                strsql &= ", if(tpsmap.PSMap_ID is null, 0, tpsmap.PSMap_ID) as PSMap_ID" & Environment.NewLine
                strsql &= ", if(lpsprice.PsPrice_ID is null, 0, lpsprice.PsPrice_ID) as PsPrice_ID  " & Environment.NewLine
                strsql &= ", lpsprice.PSPrice_Number, lpsprice.PSPrice_Desc, lpsprice.PSPrice_AvgCost, lpsprice.PSPrice_StndCost, tpsmap.Model_ID, lpsprice.RVFlag " & Environment.NewLine
                strsql &= "FROM tbillgroup " & Environment.NewLine
                strsql &= "INNER JOIN lbillcodes ON tbillgroup.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN tpsmap ON tbillgroup.bg_Model_ID = tpsmap.Model_ID AND tbillgroup.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                strsql &= "LEFT OUTER JOIN lpsprice ON tpsmap.PsPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strsql &= "WHERE bg_cust_id = " & iCustID & " " & Environment.NewLine
                strsql &= "AND bg_model_id = " & iModelID & " " & Environment.NewLine
                strsql &= "AND bg_enterprise = '" & strEnterprise & "' " & Environment.NewLine
                strsql &= "AND bg_bill_group = '" & strBillGroupName & "' " & Environment.NewLine
                strsql &= "AND bg_Inactive = 0 " & Environment.NewLine

                Return _objDataProc.GetDataTable(strsql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function SpecialBilling_BillGroup(ByVal strServerDateTime As String, ByVal iDeviceID As Integer, ByVal iCustMarkup As Decimal, _
                                                 ByVal iBillConditionID As Integer, ByVal dtBillGroup As DataTable, ByVal iUserID As Integer) As Integer
            Dim R1 As DataRow
            Dim decAvgcost, decStdcost, decInvcost, decRegPrice As Decimal
            Dim i As Integer
            Dim strPartNumber, strReplPartSN As String

            Try
                strPartNumber = "" : strReplPartSN = "" : decRegPrice = 0
                '**************************************************
                '1:: BILL GROUP SECTION
                '**************************************************
                For Each R1 In dtBillGroup.Rows
                    '*************************
                    'Get DeviceInvoice Amount
                    '*************************
                    If Not IsDBNull(R1("PSPrice_StndCost")) Then
                        If R1("BillType_ID") = 1 Then 'Service
                            decInvcost = R1("PSPrice_StndCost")
                        Else
                            decInvcost = Math.Round((R1("PSPrice_StndCost") * (iCustMarkup + 1) + 0.00499), 2)
                        End If
                    End If
                    '******************************
                    'Get AvgCost and StandardCost
                    '******************************
                    If Not IsDBNull(R1("PSPrice_AvgCost")) Then decAvgcost = Math.Round(R1("PSPrice_AvgCost"), 2)

                    If Not IsDBNull(R1("PSPrice_StndCost")) Then decStdcost = Math.Round(R1("PSPrice_StndCost"), 2)

                    If Not IsDBNull(R1("PSPrice_Number")) Then strPartNumber = R1("PSPrice_Number").ToString.Trim
                    If Not IsDBNull(R1("RVFlag")) AndAlso R1("RVFlag").ToString.Trim = "1" Then decRegPrice = Me.GetRegularPartPice_SpecialBilling(strPartNumber, iCustMarkup)

                    '********************************
                    'Insert in to tdevicebill_special
                    '********************************
                    i += Me.InsertIntoTdevicebill_Special(decRegPrice, decAvgcost, decStdcost, decInvcost, iDeviceID, R1("billcode_id"), strPartNumber, R1("bg_id"), iBillConditionID, strReplPartSN, strServerDateTime, iUserID)

                    '***********************
                    'Reset loop variable
                    '***********************
                    decInvcost = 0 : decAvgcost = 0 : decStdcost = 0 : decRegPrice = 0 : strPartNumber = ""
                    '***********************
                Next R1

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing : Generic.DisposeDT(dtBillGroup)
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function SpecialBilling_Service(ByVal strSvrDateTime As String, ByVal iDeviceID As Integer, ByVal iBillConditionID As Integer, _
                                               ByVal dtService As DataTable, ByVal iUserID As Integer) As Integer
            Dim R1 As DataRow
            Dim decAvgcost, decStdcost, decInvcost, decRegPrice As Decimal
            Dim i As Integer
            Dim strPartNumber, strReplPartSN As String

            Try
                strPartNumber = "" : strReplPartSN = "" : decRegPrice = 0
                '**************************************************
                '1:: BILL GROUP SECTION
                '**************************************************
                For Each R1 In dtService.Rows
                    '*************************
                    'Get DeviceInvoice Amount
                    '*************************
                    If Not IsDBNull(R1("PSPrice_StndCost")) Then decInvcost = R1("PSPrice_StndCost")
                    '******************************
                    'Get AvgCost and StandardCost
                    '******************************
                    If Not IsDBNull(R1("PSPrice_AvgCost")) Then decAvgcost = Math.Round(R1("PSPrice_AvgCost"), 2)
                    If Not IsDBNull(R1("PSPrice_StndCost")) Then decStdcost = Math.Round(R1("PSPrice_StndCost"), 2)

                    '********************************
                    'Insert in to tdevicebill_special
                    '********************************
                    i += Me.InsertIntoTdevicebill_Special(decRegPrice, decAvgcost, decStdcost, decInvcost, iDeviceID, R1("billcode_id"), strPartNumber, 0, iBillConditionID, strReplPartSN, strSvrDateTime, iUserID)

                    '***********************
                    'Reset loop variable
                    '***********************
                    decInvcost = 0 : decAvgcost = 0 : decStdcost = 0 : strPartNumber = "" : strReplPartSN = "" : decRegPrice = 0
                    '***********************
                Next R1

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtService)
            End Try
        End Function

        '*************************************************************************************************************************
        Private Function InsertIntoTdevicebill_Special(ByVal devRegPrice As Decimal, ByVal decAvgcost As Decimal, ByVal decStdcost As Decimal, ByVal decInvcost As Decimal, _
                                                   ByVal iDevice_ID As Integer, ByVal iBillCode_ID As Integer, ByVal strPartNumber As String, ByVal iBillGroup_ID As Integer, _
                                                   ByVal iBillConditionID As Integer, ByVal strReplPartSN As String, ByVal strDateTime As String, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT Dbill_ID FROM tdevicebill_special  WHERE Device_ID = " & iDevice_ID & " AND BillCode_ID = " & iBillCode_ID
                dt1 = _objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count = 0 Then
                    strSql = ""

                    strSql = "INSERT INTO tdevicebill_special ( " & Environment.NewLine
                    strSql &= "DBill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, Device_ID " & Environment.NewLine
                    strSql &= ", BillCode_ID, Fail_ID, Part_Number, Repair_ID, Comp_ID, User_ID, BG_ID " & Environment.NewLine
                    strSql &= ", DBill_Condition, ReplPartSN, Date_Rec " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= devRegPrice & ", " & decAvgcost & ", " & decStdcost & ", " & decInvcost & ", " & iDevice_ID & Environment.NewLine
                    strSql &= ", " & iBillCode_ID & ", 0, '" & strPartNumber & "', 0, 0, " & iUserID & ", " & iBillGroup_ID & Environment.NewLine
                    strSql &= ", " & iBillConditionID & ", '" & strReplPartSN & "', '" & strDateTime & "'" & Environment.NewLine
                    strSql &= " ) "

                    i = _objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function UpdateLabor_AB(ByVal iDevice_ID As Integer, ByVal strDateTime As String, ByVal iLaborLevel As Integer, _
                                      ByVal dbLaborChg As Decimal, ByVal dbPartCharge As Double, ByVal iAutoBill As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tdevice SET Device_DateBill_AutoBilled = '" & strDateTime & "', Device_LaborLevel_AutoBilled = " & iLaborLevel & Environment.NewLine
                strSql &= ", Device_LaborCharge_AutoBilled = " & dbLaborChg & ", Device_PartCharge_AutoBilled = " & dbPartCharge & ", AutoBillFlag = " & iAutoBill & Environment.NewLine
                strSql &= " WHERE Device_ID = " & iDevice_ID & ";"
                Return _objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function SaveSpecialBillingLog(ByVal iDeviceID As Integer, ByVal strSvrDateTime As String, ByVal iUserID As Integer, _
                                              ByVal strRandomPickBillGrp As String, ByVal iBillConditionID As Integer) As Integer
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT count(*) as cnt FROM tdevicebill_special_log WHERE Device_ID = " & iDeviceID & Environment.NewLine
                If _objDataProc.GetIntValue(strSql) > 0 Then
                    strSql = "UPDATE tdevicebill_special_log SET SpecialBillCompletedDate = '" & strSvrDateTime & "'" & Environment.NewLine
                    strSql &= ", User_ID = " & iUserID & " , BG_Bill_Group = '" & strRandomPickBillGrp & "'" & Environment.NewLine
                    strSql &= ", DBill_Condition = " & iBillConditionID & Environment.NewLine
                    strSql &= "WHERE Device_ID = " & iDeviceID
                    Return _objDataProc.ExecuteNonQuery(strSql)
                Else
                    strSql = "INSERT INTO tdevicebill_special_log ( Device_ID, SpecialBillCompletedDate, User_ID, BG_Bill_Group, DBill_Condition  " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iDeviceID & ", '" & strSvrDateTime & "', " & iUserID & " , '" & strRandomPickBillGrp & "', " & iBillConditionID & Environment.NewLine
                    strSql &= ") " & Environment.NewLine
                    Return _objDataProc.ExecuteNonQuery(strSql)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetSpecialBillTotalPartCharge(ByVal iDeviceID As Integer) As Double
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT sum(DBill_InvoiceAmt) as 'TotalPartCharge' FROM tdevicebill_special WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return _objDataProc.GetDoubleValue(strSql)
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function IsBillingSpecialExisted(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String
            Dim dt As DataTable

            Try
                strSql = "SELECT count(*) as cnt FROM tdevicebill_special WHERE Device_ID = " & iDeviceID & Environment.NewLine
                If _objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************************
        Private Function GetRegularPartPice_SpecialBilling(ByVal strRVPartNo As String, ByVal iCustMarkup As Decimal) As Double
            Dim strRegPartNo, strSql As String
            Dim dbRegPartPrice As Double
            Dim dt As DataTable

            Try
                GetRegularPartPice_SpecialBilling = 0.0 : dbRegPartPrice = 0

                strRegPartNo = strRVPartNo.Trim.ToUpper.Replace("_RV", "")
                strSql = "SELECT * FROM lpsprice WHERE psprice_number = '" & strRegPartNo & "'"
                dt = _objDataProc.GetDataTable(strSql)

                If dt.Rows.Count = 0 Then
                    Throw New Exception("Regular part does not map for this model.")
                Else
                    dbRegPartPrice = dt.Rows(0)("PSPrice_StndCost")
                    'mark up
                    dbRegPartPrice = Math.Round((dbRegPartPrice * (iCustMarkup + 1) + 0.00499), 2)
                End If

                Return dbRegPartPrice
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetSpecialBillingBillcodes(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String

            Try
                strSql = "SELECT A.BillCode_ID, A.Date_Rec as TransDate, A.User_ID as TransUserID" & Environment.NewLine
                strSql &= ", A.DBill_Condition as TransBillConditionID, B.* " & Environment.NewLine
                strSql &= "FROM tdevicebill_special A " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tdevicebill_special_log B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID
                Return _objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function RemoveSpecialBilling(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String
            Dim i As Integer = 0

            Try
                strSql = "DELETE FROM tdevicebill_special WHERE Device_ID = " & iDeviceID & Environment.NewLine
                i = _objDataProc.ExecuteNonQuery(strSql)
                If i = 0 Then Throw New Exception("System has failed to delete special billing for device ID " & iDeviceID)

                strSql = "UPDATE tdevice SET Device_DateBill_AutoBilled = null, Device_LaborLevel_AutoBilled = null" & Environment.NewLine
                strSql &= ", Device_LaborCharge_AutoBilled = 0, Device_PartCharge_AutoBilled = 0, AutoBillFlag = 0 " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                i = _objDataProc.ExecuteNonQuery(strSql)

                strSql = "DELETE FROM tdevicebill_special_log WHERE Device_ID = " & iDeviceID & Environment.NewLine
                i = _objDataProc.ExecuteNonQuery(strSql)

                Return i
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function SaveSpecialBillingDeletion(ByVal iDeviceID As Integer, ByVal strSBCompletedDate As String, _
                                                   ByVal iSBCompletedDUserID As Integer, ByVal strBillGroup As String, _
                                                   ByVal iBillConditionID As Integer, ByVal strBillcodeIDs As String, _
                                                   ByVal iUserID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "INSERT INTO tdevicebill_special_del (  " & Environment.NewLine
                strSql &= "Device_ID, SpecialBillCompletedDate, SpecialBillCompleted_User_ID, BG_Bill_Group" & Environment.NewLine
                strSql &= ", DBill_Condition, BG_BillcodeIDs, SpecialBillDel_User_ID, SpecialBillDel_Date " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= iDeviceID & ", '" & strSBCompletedDate & "', " & iSBCompletedDUserID & ", '" & strBillGroup & "' " & Environment.NewLine
                strSql &= ", " & iBillConditionID & ", '" & strBillcodeIDs & "', " & iUserID & ", now() " & Environment.NewLine
                strSql &= " ) "
                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetDockShipYrMonth(ByVal iPackingslipID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "SELECT concat(Year(pkslip_createdt), LPAD(month(pkslip_createdt), 2, '0') ) as DockshipYrMonth " & Environment.NewLine
                strSql &= "FROM tpackingslip WHERE pkslip_ID = " & iPackingslipID & Environment.NewLine
                Return _objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetTodayYrMonth() As Integer
            Dim strSql As String

            Try
                strSql = "SELECT concat(Year(now()), LPAD(month(now()), 2, '0') ) as TodayYrMonth " & Environment.NewLine
                Return _objDataProc.GetIntValue(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************
        Public Function GetNoBerCapModelList(ByVal booDockShipDate As Boolean, ByVal strStartDate As String, ByVal strEndDate As String, ByVal strEnterprise As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT distinct tmodel.Model_Desc " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                If booDockShipDate Then
                    strSql &= "INNER JOIN tdevice ON tpallett.Pallett_ID = tdevice.Pallett_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tpackingslip ON tpallett.Pkslip_ID = tpackingslip.Pkslip_ID " & Environment.NewLine
                Else
                    strSql &= "INNER JOIN tdevice ON tdevice.Pallett_ID = tpallett.Pallett_ID " & Environment.NewLine
                End If
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tmodeltarget ON tdevice.Model_ID = tmodeltarget.MT_Model_ID AND tpallett.Cust_ID = tmodeltarget.MT_Cust_ID AND MT_Enterprise = '" & strEnterprise & "' " & Environment.NewLine
                strSql &= "WHERE tpallett.Cust_ID = " & TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                If booDockShipDate Then
                    strSql &= "AND pkslip_createDt Between '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                Else
                    strSql &= "AND Device_Dateship Between '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                End If
                strSql &= "AND tmodeltarget.MT_ID is null"

                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************************

    End Class
End Namespace