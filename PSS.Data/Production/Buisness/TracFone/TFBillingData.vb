Option Explicit On 

Namespace Buisness.TracFone
    Public Class TFBillingData
        Private _objDataProc As DBQuery.DataProc
        Public Const TF_NoBatteryCover_BillCodeID As Integer = 3940
        Public Const TF_SoftwareScreen_BillCodeID As Integer = 3955
        Public Const TF_KillSwitchRemove_BillCodeID As Integer = 3057
        Public Const TF_SoftwareScreen_PartNumber As String = "Software Screen"
        Public Const TF_KillSwitchRemove_PartNumber As String = "Kill Switch Removed"

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

#Region "Reg Billing"

        '******************************************************************
        Public Function GetBilledPartsServicesBillcodeID(ByVal iDeviceID As Integer) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevicebill.Billcode_ID, BillCode_Rule " & Environment.NewLine
                strSql &= "FROM tdevicebill " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.Billcode_ID = lbillcodes.billcode_ID " & Environment.NewLine
                strSql += "WHERE tdevicebill.Device_ID = " & iDeviceID & " " & Environment.NewLine
                'strSql += "AND BillType_ID = 1 " & Environment.NewLine
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function GetMaxPartsAndServicesRepLevel(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim iMaxLaborLevel As Integer = 0

            Try
                '2010-09-21: Set labor level to 1 if unit is IW , Samsung product and has FFN(269) fail code
                strSql = "SELECT tdevicebill.Billcode_ID, tdevicebill.Fail_ID " & Environment.NewLine
                strSql &= ", If((tdevice.Device_ManufWrty = 1 AND tmodel.Manuf_ID = 21 AND tdevicebill.Fail_ID = 269), 1, LaborLevel) as LaborLevel" & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "ORDER BY LaborLevel DESC"
                dt = Me._objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    iMaxLaborLevel = dt.Rows(0)("LaborLevel")
                End If

                Return iMaxLaborLevel
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************
        Public Function GetMaxClaimablePartsAndReflowTuningLevel(ByVal iDeviceID As Integer, _
                                                                 ByVal iManufID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dtPartLevel As DataTable

            Try
                '************************************************
                '311(User Abuse) Fail ID use by all manufacture
                '269(FFN) use only by Samsung
                '************************************************

                If iManufID = 1 Then 'MOTOROLA
                    strSql = "SELECT tdevicebill.Fail_ID, LaborLevel , 0 as 'Reflow' FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= "AND BillType_ID = 2 " & Environment.NewLine
                    strSql &= "AND tdevicebill.Fail_ID NOT IN ( 0, 311 ) " & Environment.NewLine
                    strSql &= "UNION" & Environment.NewLine
                    strSql &= "SELECT treflowpart.Fail_ID, 2 as 'LaborLevel', 1 as 'Reflow' FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN treflowpart ON tdevice.Device_ID = treflowpart.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND treflowpart.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= "AND treflowpart.Fail_ID NOT IN ( 0, 311 ) " & Environment.NewLine
                    strSql &= "ORDER BY LaborLevel DESC"
                    dtPartLevel = Me._objDataProc.GetDataTable(strSql)
                Else
                    '2010-09-12: Exclude FFN (269) Fail Code. Samsung provide part.
                    strSql = "SELECT tdevicebill.Fail_ID, LaborLevel FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= "AND ( BillType_ID = 2 or (Manuf_ID = 24 and tdevicebill.Billcode_ID = 1898 ) ) " & Environment.NewLine
                    strSql &= "AND tdevicebill.Fail_ID NOT IN (0, 311, 269 ) " & Environment.NewLine
                    strSql &= "UNION" & Environment.NewLine
                    strSql &= "SELECT treflowpart.Fail_ID, LaborLevel FROM tdevice " & Environment.NewLine
                    strSql &= "INNER JOIN treflowpart ON tdevice.Device_ID = treflowpart.Device_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND treflowpart.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                    strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= "AND treflowpart.Fail_ID NOT IN (0, 311, 269 ) " & Environment.NewLine
                    strSql &= "ORDER BY LaborLevel DESC "
                    dtPartLevel = Me._objDataProc.GetDataTable(strSql)
                End If

                Return dtPartLevel
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtPartLevel)
            End Try
        End Function

        '****************************************************************************************
        Public Function HasRF1Test(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) as 'RF1Count' FROM ttestdata " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Test_ID = 2" & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function HasRF2Passed(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) as 'RF2PassedCount' FROM ttestdata " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Test_ID = 10" & Environment.NewLine
                strSql &= "AND QCResult_ID = 1" & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function HasPSDPassed(ByVal iDeviceID As Integer) As Boolean
            Dim strSql As String = ""
            Try
                strSql = "SELECT count(*) as 'PSDPassedCount' FROM ttestdata " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND Test_ID = 11" & Environment.NewLine
                strSql &= "AND QCResult_ID = 1" & Environment.NewLine
                If Me._objDataProc.GetIntValue(strSql) > 0 Then Return True Else Return False

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function SetWrtyClaimableFlag(ByVal iDeviceID As Integer, _
                                             ByVal iManufID As Integer, _
                                             ByVal iWrtyClaimableFlg As Integer, _
                                             ByVal dtMaxClaimablePartLevel As DataTable) As Integer
            Dim strSql As String = ""
            Dim decWrtLabor As Decimal = 0.0
            Dim decWrtPartCost As Decimal = 0.0

            Try
                If iWrtyClaimableFlg = 1 Then
                    If iManufID = 16 Then
                        decWrtLabor = Me.GetLGWrtyClaimLabor(iDeviceID, decWrtPartCost)
                    ElseIf iManufID = 21 Then
                        decWrtLabor = Me.GetSamSungWrtyClaimLabor(iDeviceID, decWrtPartCost)
                    ElseIf iManufID = 1 Then
                        decWrtLabor = Me.GetMotoWrtyClaimLabor(iDeviceID, dtMaxClaimablePartLevel, decWrtPartCost)
                    ElseIf iManufID = 24 Then
                        decWrtLabor = Me.GetNokiaWrtyClaimLabor(iDeviceID, decWrtPartCost)
                    End If
                End If

                strSql = "UPDATE edi.titem, production.tdevice SET WrtyClaimableFlg = " & iWrtyClaimableFlg & Environment.NewLine
                strSql &= ", wrty_labor = " & decWrtLabor & ", wrty_partcost = " & decWrtPartCost & Environment.NewLine
                strSql &= ", Device_ManufWrtyLaborCharge = " & decWrtLabor & ", Device_ManufWrtyPartCharge = " & decWrtPartCost & Environment.NewLine
                strSql &= "WHERE edi.titem.Device_ID = production.tdevice.Device_ID AND edi.titem.Device_ID = " & iDeviceID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtMaxClaimablePartLevel)
            End Try
        End Function

        '****************************************************************************************
        Public Function SetWrtyClaimableFlagForBERShipBox(ByVal iPalletID As Integer) As Integer
            Dim strSql As String = ""
            Try
                strSql = "UPDATE edi.titem, tdevice " & Environment.NewLine
                strSql &= "SET WrtyClaimableFlg = 0, wrty_labor = 0, wrty_partcost = 0 " & Environment.NewLine
                strSql &= ", Device_ManufWrtyLaborCharge = 0, Device_ManufWrtyPartCharge = 0" & Environment.NewLine
                strSql &= "WHERE edi.titem.Device_ID = production.tdevice.Device_ID " & Environment.NewLine
                strSql &= "AND tdevice.Pallett_ID = " & iPalletID & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function GetSamSungWrtyClaimLabor(ByVal iDeviceID As Integer, _
                                                 ByRef decPartCost As Decimal) As Decimal
            Dim strSql As String
            Dim dt As DataTable
            Dim decLabor As Decimal = 0.0

            Try
                decPartCost = 0.0

                'Set labor charge to 0.00 for FFN Failcode:269
                '2010-09-21: Now Samsung give us part for FFN fail code. Remove charge. 
                strSql = "SELECT F.PC_Amt as 'Labor Amount' " & Environment.NewLine
                strSql &= ", C.Billcode_ID, D.PSPrice_Number, PSPrice_StndCost " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON B.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap C ON B.Billcode_ID= C.Billcode_ID AND A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice D ON C.PSPrice_ID = D.PSPrice_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tsamsungwrtymap E ON B.Repair_ID = E.Repair_ID AND D.MatGrp_WrtyClaim = E.MatGrp_WrtyClaim " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lmanufpaymentcodes F ON E.PC_ID = F.PC_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND C.LaborLevel > 1 " & Environment.NewLine
                strSql &= "AND lbillcodes.BillType_ID = 2 " & Environment.NewLine
                strSql &= "AND B.Fail_ID NOT IN ( 0, 311, 269 ) " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT F.PC_Amt as 'Labor Amount'" & Environment.NewLine
                strSql &= ", C.Billcode_ID, D.PSPrice_Number, 0 as 'PSPrice_StndCost' " & Environment.NewLine
                strSql &= "FROM tdevice A  " & Environment.NewLine
                strSql &= "INNER JOIN treflowpart B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap C ON B.Billcode_ID= C.Billcode_ID AND A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice D ON C.PSPrice_ID = D.PSPrice_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tsamsungwrtymap E ON B.Repair_ID = E.Repair_ID AND D.MatGrp_WrtyClaim = E.MatGrp_WrtyClaim " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lmanufpaymentcodes F ON E.PC_ID = F.PC_ID " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND C.LaborLevel > 1 " & Environment.NewLine
                strSql &= "AND B.Fail_ID  NOT IN ( 0, 311, 269 ) " & Environment.NewLine
                strSql &= "ORDER BY 'Labor Amount' DESC " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    If dt.Select("[Labor Amount] is null").Length > 0 Then Throw New Exception("Payment code is missing for part # " & dt.Select("[Labor Amount] is null")(0)("PSPrice_Number") & ".")

                    If Not IsDBNull(dt.Compute("Max([Labor Amount])", "")) Then decLabor = dt.Compute("Max([Labor Amount])", "")
                    If Not IsDBNull(dt.Compute("Sum(PSPrice_StndCost)", "")) Then decPartCost = dt.Compute("Sum(PSPrice_StndCost)", "")
                End If

                Return decLabor
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************
        Public Function GetLGWrtyClaimLabor(ByVal iDeviceID As Integer, _
                                            ByRef decPartCost As Decimal) As Decimal
            Dim strSql As String
            Dim dtRep, dtReflow As DataTable
            Dim decLabor As Decimal = 0.0

            Try
                decPartCost = 0.0

                strSql = "SELECT E.Labor as 'Labor Amount', C.Billcode_ID, D.PSPrice_Number, PSPrice_StndCost " & Environment.NewLine
                strSql &= "FROM tdevice A  " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON B.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap C ON B.Billcode_ID= C.Billcode_ID AND A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice D ON C.PSPrice_ID = D.PSPrice_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN llgdefectcodes E ON D.MatGrp_WrtyClaim = E.DC_SDesc" & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND C.LaborLevel > 1 " & Environment.NewLine
                strSql &= "AND lbillcodes.BillType_ID = 2 " & Environment.NewLine
                strSql &= "AND B.Fail_ID > 0 AND B.Fail_ID <> 311 " & Environment.NewLine
                strSql &= "ORDER BY 'Labor Amount' DESC " & Environment.NewLine
                dtRep = Me._objDataProc.GetDataTable(strSql)

                If dtRep.Rows.Count > 0 Then
                    If dtRep.Select("[Labor Amount] is null").Length > 0 Then Throw New Exception("Payment code is missing for part # " & dtRep.Select("[Labor Amount] is null")(0)("PSPrice_Number") & ".")
                    decLabor = dtRep.Compute("Max([Labor Amount])", "")
                    If Not IsDBNull(dtRep.Compute("Sum(PSPrice_StndCost)", "")) Then decPartCost = dtRep.Compute("Sum(PSPrice_StndCost)", "")
                Else
                    strSql = "SELECT C.Labor as 'Labor Amount', B.Billcode_ID" & Environment.NewLine
                    strSql &= "FROM tdevice A  " & Environment.NewLine
                    strSql &= "INNER JOIN treflowpart B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN llgdefectcodes C ON C.DC_SDesc = 'MGCR'" & Environment.NewLine
                    strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                    strSql &= "AND B.Fail_ID > 0 AND B.Fail_ID <> 311 " & Environment.NewLine
                    strSql &= "ORDER BY 'Labor Amount' DESC " & Environment.NewLine
                    dtReflow = Me._objDataProc.GetDataTable(strSql)
                    If dtReflow.Select("[Labor Amount] is null").Length > 0 Then Throw New Exception("Missing defective code 'MGCR' use by reflow.")
                    decLabor = dtReflow.Compute("Max([Labor Amount])", "")
                    decPartCost = 0.0
                End If

                Return decLabor
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtRep)
                Generic.DisposeDT(dtReflow)
            End Try
        End Function

        '****************************************************************************************
        Public Function GetMotoWrtyClaimLabor(ByVal iDeviceID As Integer, _
                                              ByVal dtMaxClaimablePartLevel As DataTable, _
                                              ByRef decPartCost As Decimal) As Decimal
            Dim strSql As String
            Dim dt As DataTable
            Dim decLabor As Decimal = 0.0

            Try
                decPartCost = 0.0

                If Not IsNothing(dtMaxClaimablePartLevel.Rows.Count) AndAlso dtMaxClaimablePartLevel.Rows.Count > 0 Then
                    strSql = "SELECT cellopt_APC, B.*  " & Environment.NewLine
                    strSql &= "FROM tcellopt A  " & Environment.NewLine
                    strSql &= "LEFT OUTER JOIN motorolareimbursement B ON A.CellOpt_APC = B.APC" & Environment.NewLine
                    strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                    dt = Me._objDataProc.GetDataTable(strSql)

                    If dt.Rows.Count > 1 Then
                        Throw New Exception("Payment code existed more than one for APC code " & dt.Rows(0)("cellopt_APC") & ".")
                    ElseIf dt.Rows.Count = 0 Then
                        Throw New Exception("Device ID (" & iDeviceID & ") does not exist in tcellopt.")
                    Else
                        If dt.Select("[APC] is null").Length > 0 Then Throw New Exception("Payment code is missing for APC code " & dt.Rows(0)("cellopt_APC") & ".")

                        'Level 3 and up
                        If dtMaxClaimablePartLevel.Select("LaborLevel > 2").Length > 0 Then
                            decLabor = CDec(dt.Rows(0)("L3VA"))
                            decPartCost = CDec(dt.Rows(0)("L3Material"))
                        End If

                        'Level 2 existed
                        If dtMaxClaimablePartLevel.Select("LaborLevel = 2").Length > 0 Then
                            If CDec(dt.Rows(0)("L1L2VA")) > decLabor Then decLabor = CDec(dt.Rows(0)("L1L2VA"))
                            If CDec(dt.Rows(0)("L1L2Material")) > decPartCost Then decPartCost = CDec(dt.Rows(0)("L1L2Material"))
                        End If
                    End If
                End If

                Return decLabor
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtMaxClaimablePartLevel)
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************
        Public Function GetNokiaWrtyClaimLabor(ByVal iDeviceID As Integer, _
                                               ByRef decPartCost As Decimal) As Decimal
            Dim strSql As String
            Dim dt As DataTable
            Dim decLabor As Decimal = 0.0

            Try
                decPartCost = 0.0

                strSql = "SELECT F.PC_Amt as 'Labor Amount' " & Environment.NewLine
                strSql &= ", C.Billcode_ID, D.PSPrice_Number, PSPrice_StndCost " & Environment.NewLine
                strSql &= "FROM tdevice A " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON B.Billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap C ON B.Billcode_ID= C.Billcode_ID AND A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice D ON C.PSPrice_ID = D.PSPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN lrepaircodes E ON B.Repair_ID = E.Repair_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lmanufpaymentcodes F ON E.Repair_SDesc = F.PC_Code " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND C.LaborLevel > 1 " & Environment.NewLine
                strSql &= "AND ( lbillcodes.BillType_ID = 2 or lbillcodes.Billcode_ID = 1898 ) " & Environment.NewLine
                strSql &= "AND B.Fail_ID NOT IN ( 0, 311 ) " & Environment.NewLine
                strSql &= "UNION " & Environment.NewLine
                strSql &= "SELECT F.PC_Amt as 'Labor Amount'" & Environment.NewLine
                strSql &= ", C.Billcode_ID, D.PSPrice_Number, 0 as 'PSPrice_StndCost' " & Environment.NewLine
                strSql &= "FROM tdevice A  " & Environment.NewLine
                strSql &= "INNER JOIN treflowpart B ON A.Device_ID = B.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap C ON B.Billcode_ID= C.Billcode_ID AND A.Model_ID = C.Model_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice D ON C.PSPrice_ID = D.PSPrice_ID " & Environment.NewLine
                strSql &= "INNER JOIN lrepaircodes E ON B.Repair_ID = E.Repair_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lmanufpaymentcodes F ON E.Repair_SDesc = F.PC_Code " & Environment.NewLine
                strSql &= "WHERE A.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND C.LaborLevel > 1 " & Environment.NewLine
                strSql &= "AND B.Fail_ID  NOT IN ( 0, 311 ) " & Environment.NewLine
                strSql &= "ORDER BY 'Labor Amount' DESC " & Environment.NewLine
                dt = Me._objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    If dt.Select("[Labor Amount] is null").Length > 0 Then Throw New Exception("Payment code is missing for part # " & dt.Select("[Labor Amount] is null")(0)("PSPrice_Number") & ".")

                    If Not IsDBNull(dt.Compute("Max([Labor Amount])", "")) Then decLabor = dt.Compute("Max([Labor Amount])", "")
                    If Not IsDBNull(dt.Compute("Sum(PSPrice_StndCost)", "")) Then decPartCost = dt.Compute("Sum(PSPrice_StndCost)", "")
                End If

                Return decLabor
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '****************************************************************************************
        Public Function SetDataToOW(ByVal iDeviceID As Integer) As Integer
            Dim strSql, strIDs As String
            Dim dtRepPart, dtRefPart As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                '*********************************
                'REPLACMENT
                '*********************************
                strSql = "" : strIDs = ""
                strSql = "SELECT tdevicebill.DBill_ID, tdevicebill.Fail_ID, LaborLevel, tdevicebill.billcode_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.Device_ID = tdevicebill.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN lbillcodes ON tdevicebill.billcode_ID = lbillcodes.Billcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND BillType_ID = 2  " & Environment.NewLine
                strSql &= "AND tdevicebill.Fail_ID > 0 AND tdevicebill.Fail_ID NOT IN (311 ) " & Environment.NewLine
                dtRepPart = Me._objDataProc.GetDataTable(strSql)

                For Each R1 In dtRepPart.Rows
                    If strIDs.Length > 0 Then strIDs &= ", "
                    strIDs &= R1("DBill_ID").ToString()
                    strSql = "INSERT INTO tracfoneresetwrtytoow ( Device_ID, Billcode_ID, Fail_ID, DBill_ID, InsertDateTime " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iDeviceID.ToString() & ", " & R1("Billcode_ID").ToString() & ", " & R1("Fail_ID").ToString() & ", " & R1("DBill_ID").ToString() & ", now() " & Environment.NewLine
                    strSql &= ")"
                    i = Me._objDataProc.ExecuteNonQuery(strSql)
                Next R1

                If strIDs.Length > 0 Then
                    strSql = "UPDATE tdevicebill SET Fail_ID = 0 , Repair_ID = 0 " & Environment.NewLine
                    strSql &= "WHERE DBill_ID in ( " & strIDs & ") " & Environment.NewLine
                    i = _objDataProc.ExecuteNonQuery(strSql)
                End If

                '*********************************
                'REFLOW
                '*********************************
                strSql = "" : strIDs = ""
                strSql &= "SELECT treflowpart.rp_id, treflowpart.Fail_ID, LaborLevel, treflowpart.Billcode_ID " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN treflowpart ON tdevice.Device_ID = treflowpart.Device_ID " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND treflowpart.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                strSql &= "AND treflowpart.Fail_ID > 0 AND treflowpart.Fail_ID NOT IN ( 311 ) " & Environment.NewLine
                dtRefPart = _objDataProc.GetDataTable(strSql)

                For Each R1 In dtRefPart.Rows
                    If strIDs.Length > 0 Then strIDs &= ", "
                    strIDs &= R1("rp_id").ToString()
                    strSql = "INSERT INTO tracfoneresetwrtytoow ( Device_ID, Billcode_ID, Fail_ID, rp_id, InsertDateTime " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= iDeviceID.ToString() & ", " & R1("Billcode_ID").ToString() & ", " & R1("Fail_ID").ToString() & ", " & R1("rp_id").ToString() & ", now() " & Environment.NewLine
                    strSql &= ")"
                    i = _objDataProc.ExecuteNonQuery(strSql)
                Next R1

                If strIDs.Length > 0 Then
                    strSql = "UPDATE tdevicebill SET Fail_ID = 0 , Repair_ID = 0 " & Environment.NewLine
                    strSql &= "WHERE DBill_ID in ( " & strIDs & ") " & Environment.NewLine
                    i = _objDataProc.ExecuteNonQuery(strSql)
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtRepPart)
                Generic.DisposeDT(dtRefPart)
            End Try
        End Function

        '****************************************************************************************
        Public Function SetDeviceManufOutOfWarranty(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String = ""

            Try
                '*********************************
                'SET Manuf wrty flag to OW
                '*********************************
                strSql = "UPDATE tdevice SET Device_ManufWrty = 0 " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine & Environment.NewLine
                Return Me._objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function GetEOMBillcodeANDConsignedPartBillcode(ByVal iDeviceID As Integer) As DataTable
            Dim strSql, strEOMPart As String
            Dim dt1, dt2 As DataTable
            Dim R1 As DataRow

            Try
                strSql = "SELECT tdevice.Model_ID, tdevicebill.Billcode_ID as 'FFNBillcode', PSPrice_Number as 'FFNPartNo' , 0 as 'EOMBillcode' " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill ON tdevice.device_ID = tdevicebill.device_ID AND tdevicebill.Fail_ID = 269" & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON tdevice.Model_ID = tpsmap.Model_ID AND tdevicebill.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.PSprice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine & Environment.NewLine
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        If R1("FFNPartNo").ToString.Trim.ToLower.EndsWith("_tt") = False Then Throw New Exception("This part # has FFN fail code but does not ending with _TT. Please contact IT.")
                        strEOMPart = Mid(R1("FFNPartNo").ToString.Trim, 1, R1("FFNPartNo").ToString.Trim.Length - 3)
                        strSql = "SELECT Billcode_ID as 'EOMBillcode'" & Environment.NewLine
                        strSql &= "FROM tpsmap " & Environment.NewLine
                        strSql &= "INNER JOIN lpsprice ON tpsmap.PSprice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                        strSql &= "WHERE Model_ID = " & R1("Model_ID") & " AND lpsprice.PSPrice_Number = '" & strEOMPart & "'" & Environment.NewLine & Environment.NewLine
                        dt2 = Me._objDataProc.GetDataTable(strSql)
                        If dt2.Rows.Count = 0 Then
                            Throw New Exception("No OEM part # map for model_id " & dt1.Rows(0)("Model_ID") & " and part # " & strEOMPart & ".")
                        Else
                            R1.BeginEdit() : R1("EOMBillcode") = dt2.Rows(0)("EOMBillcode") : R1.EndEdit()
                        End If
                        Generic.DisposeDT(dt2)
                    Next R1

                    dt1.AcceptChanges()
                End If
                Return dt1
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function GetClaimableDevices(ByVal iPalletID As Integer) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT D.LastDateInWrty, D.WrtyClaimReceiptDt, H.CellOpt_RefurbCompleteDt" & Environment.NewLine
                strSql &= ", Device_DateShip, C.Device_ID, C.Model_ID, C.Device_ManufWrty, E.Manuf_ID, D.FuncRep, B.Pallet_ShipType, B.Cust_ID  " & Environment.NewLine
                strSql &= "FROM  tpallett B" & Environment.NewLine
                strSql &= "INNER JOIN tdevice C ON B.pallett_id = C.pallett_id" & Environment.NewLine
                strSql &= "INNER JOIN edi.titem D ON C.Device_ID = D.Device_ID" & Environment.NewLine
                strSql &= "INNER JOIN tmodel E ON C.Model_ID = E.Model_ID" & Environment.NewLine
                strSql &= "INNER JOIN tcellopt H ON C.Device_ID = H.Device_ID" & Environment.NewLine
                strSql &= "WHERE B.Pallett_ID = " & iPalletID & " AND B.Cust_ID = 2258 " & Environment.NewLine
                strSql &= "AND D.WrtyClaimableFlg = 1" & Environment.NewLine
                strSql &= "AND C.Device_SendClaim = 0 " & Environment.NewLine
                strSql &= "AND D.FSN_ID is null " & Environment.NewLine
                Return _objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function UpdateRecptRepDate(ByVal booUpdRecptDate As Boolean, _
                                                           ByVal booUpdRepDate As Boolean, _
                                                           ByVal dteRcptDate As DateTime, _
                                                           ByVal dteRepDate As DateTime, _
                                                           ByVal iDeviceID As Integer) As Integer
            Dim strSql, strSetClause As String

            Try
                strSql = "" : strSetClause = ""
                If booUpdRecptDate Then
                    strSetClause = "SET WrtyClaimReceiptDt = '" & dteRcptDate.ToString("yyyy-MM-dd HH:mm:ss") & "'" & Environment.NewLine
                End If

                If booUpdRepDate Then
                    If strSetClause.Trim.Length = 0 Then
                        strSetClause &= "SET CellOpt_RefurbCompleteDt = '" & dteRepDate.ToString("yyyy-MM-dd HH:mm:ss") & "'" & Environment.NewLine
                    Else
                        strSetClause &= ", CellOpt_RefurbCompleteDt = '" & dteRepDate.ToString("yyyy-MM-dd HH:mm:ss") & "'" & Environment.NewLine
                    End If
                End If

                strSql = "UPDATE edi.titem, tcellopt" & Environment.NewLine
                strSql &= strSetClause
                strSql &= "WHERE edi.titem.Device_ID = tcellopt.Device_ID " & Environment.NewLine
                strSql &= "AND edi.titem.Device_ID = " & iDeviceID.ToString() & Environment.NewLine
                strSql &= "AND FSN_ID is null " & Environment.NewLine

                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function SetFlatRatePartCharge(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tdevicebill SET DBill_InvoiceAmt = 0 " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDeviceID & Environment.NewLine
                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function GetManufWrtyByTFRecDate(ByVal iDeviceID As Integer) As Integer
            Dim strSql As String
            Dim dt As DataTable
            Dim iWrtyStatus As Integer = 0

            Try
                strSql = "SELECT date_format(device_daterec,'%Y-%m-%d') as RecDate, LastDateInWrty, WrtyStatus_ByWHRecDate " & Environment.NewLine
                strSql &= "FROM tdevice INNER JOIN edi.titem ON tdevice.Device_ID = edi.titem.Device_ID " & Environment.NewLine
                strSql &= "WHERE tdevice.Device_ID = " & iDeviceID & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("GetManufWrtyByTFRecDate: Can't find device ID '" & iDeviceID & "'.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("GetManufWrtyByTFRecDate: Duplicate device ID '" & iDeviceID & "'.")
                ElseIf IsDBNull(dt.Rows(0)("LastDateInWrty")) Then
                    Throw New Exception("GetManufWrtyByTFRecDate: Last date in warranty is missing for device ID '" & iDeviceID & "'.")
                Else
                    If CDate(dt.Rows(0)("RecDate")) <= CDate(dt.Rows(0)("LastDateInWrty")) Then iWrtyStatus = 1 Else iWrtyStatus = 0

                    If iWrtyStatus <> CInt(dt.Rows(0)("WrtyStatus_ByWHRecDate")) Then
                        strSql = "UPDATE edi.titem SET WrtyStatus_ByWHRecDate = " & iWrtyStatus & " WHERE Device_ID = " & iDeviceID
                        Me._objDataProc.ExecuteNonQuery(strSql)
                    End If
                End If

                Return iWrtyStatus
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************

#End Region

#Region "Special Billing"

        '****************************************************************************************
        Public Function GetShipBoxes(ByVal booDockShipDate As Boolean, ByVal strStartDate As String, ByVal strEndDate As String, _
                                     Optional ByVal iModelID As Integer = 0) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT Distinct tpallett.Pallett_ID, Pallett_Name, Pallet_ShipType, tpallett.Cust_ID, tpallett.Pkslip_ID " & Environment.NewLine
                strSql &= "FROM tpallett " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpallett.Model_ID = tmodel.Model_ID " & Environment.NewLine
                If booDockShipDate Then
                    strSql &= "INNER JOIN tpackingslip ON tpallett.Pkslip_ID = tpackingslip.Pkslip_ID " & Environment.NewLine
                Else
                    strSql &= "INNER JOIN tdevice ON tdevice.Pallett_ID = tpallett.Pallett_ID "
                End If
                strSql &= "WHERE tpallett.Cust_ID = " & TracFone.BuildShipPallet.TracFone_CUSTOMER_ID & Environment.NewLine
                If booDockShipDate Then
                    strSql &= "AND pkslip_createDt Between '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                Else
                    strSql &= "AND Device_Dateship Between '" & strStartDate & " 00:00:00' AND '" & strEndDate & " 23:59:59'" & Environment.NewLine
                End If
                If iModelID > 0 Then strSql &= "AND tpallett.Model_ID = " & iModelID & Environment.NewLine
                ' strSql &= "AND tmodel.Model_ID IN ( 2535, 2536 ) "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function CalcTFLabor(ByVal iCust_ID As Long, ByVal iModel_ID As Integer, ByVal strEnterprise As String, _
                                    ByVal dbCust_Markup As Double, ByVal strBillGrpName As String) As DataTable
            Dim strSql, strBillcodeID As String
            Dim dt1, dtServices As DataTable
            Dim R1, R2 As DataRow
            Dim dbTotal, dbLabor, dbPartFee As Double
            Dim arlstServiceBillcodes As New ArrayList()
            Dim objMisc As New TracFone.clsMisc()

            Try
                'Add any initialization after the InitializeComponent() call
                strSql = "SELECT tbillgroup.bg_bill_group as BG, sum( ( lpsprice.psprice_stndcost * " & (1 + dbCust_Markup) & ") + 0.00499) as PartPrice " & Environment.NewLine
                strSql &= ", max(LaborLevel) as MaxLaborLevel, 0.0 as Labor, 0.0 as PartFee, 0.0 as Total  " & Environment.NewLine
                strSql &= ", Model_Desc, tmodel.Model_ID, '' as ServiceBillcodesWithAggBilling, '' as ServiiceBillcodes " & Environment.NewLine
                strSql &= "FROM tbillgroup " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap ON (tbillgroup.bg_model_id = tpsmap.model_id AND tbillgroup.billcode_id = tpsmap.billcode_id) " & Environment.NewLine
                strSql &= "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & Environment.NewLine
                strSql &= "INNER JOIN tmodel ON tpsmap.Model_ID = tmodel.Model_ID " & Environment.NewLine
                strSql &= "WHERE bg_cust_id = " & iCust_ID & " AND bg_model_id = " & iModel_ID & Environment.NewLine
                strSql &= "AND bg_enterprise = '" & strEnterprise & "' AND bg_inactive = 0" & Environment.NewLine
                If strBillGrpName.Trim.Length > 0 Then strSql &= "AND bg_bill_group = '" & strBillGrpName & "' " & Environment.NewLine
                strSql &= "GROUP BY tbillgroup.bg_bill_group;"
                dt1 = Me._objDataProc.GetDataTable(strSql)

                If dt1.Rows.Count > 0 Then
                    For Each R1 In dt1.Rows
                        R1.BeginEdit()

                        'Bill Receiving service 
                        arlstServiceBillcodes.Add(1608)

                        'Bill Packing Bulk service code
                        arlstServiceBillcodes.Add(1615)

                        'Bill Cosmetic Inspection service code 
                        arlstServiceBillcodes.Add(1609)

                        Select Case R1("MaxLaborLevel")
                            Case 0  'Cosmetic Fluff-Buff
                                arlstServiceBillcodes.Add(1611)
                            Case 1  'Cosmetic Refurbished
                                arlstServiceBillcodes.Add(1612)
                            Case 2  'Functional Repair
                                arlstServiceBillcodes.Add(1618)
                            Case 3, 4 'Mechanical Repair
                                arlstServiceBillcodes.Add(1619)
                            Case Else
                                Throw New Exception("System can't define labor level. Please contact IT.")
                        End Select

                        'Bill Final Func Insp; This service apply to all labor level > 0
                        If CInt(R1("MaxLaborLevel")) > 0 Then arlstServiceBillcodes.Add(1614)

                        'Bill AQL ; This service apply to all labor level
                        arlstServiceBillcodes.Add(1616)

                        'Bill Functional Triage
                        If R1("Model_Desc").ToString.Trim.ToUpper.EndsWith("_FUN") OrElse CInt(R1("MaxLaborLevel")) > 1 Then arlstServiceBillcodes.Add(1610)

                        'Bill RF2
                        If CInt(R1("MaxLaborLevel")) > 2 Then arlstServiceBillcodes.Add(1620)
                        'Need PSD
                        If objMisc.IsNoPSDNeeded(R1("Model_ID")) = False Then arlstServiceBillcodes.Add(1742)

                        Dim i As Integer = 0 : strBillcodeID = "" : dbLabor = 0
                        For i = 0 To arlstServiceBillcodes.Count - 1
                            If strBillcodeID.Trim.Length > 0 Then strBillcodeID &= ", "
                            strBillcodeID &= arlstServiceBillcodes(i)
                        Next i

                        If strBillcodeID.Trim.Length > 0 Then
                            R1("ServiiceBillcodes") = strBillcodeID

                            strSql = "SELECT B.Billcode_Desc, A.tcab_Amount as Labor " & Environment.NewLine
                            strSql &= "FROM tcustaggregatebilling A " & Environment.NewLine
                            strSql &= "INNER JOIN lbillcodes B ON A.Billcode_ID = B.BillCode_ID " & Environment.NewLine
                            strSql &= "WHERE A.cust_ID = " & iCust_ID & " AND A.Billcode_ID in ( " & strBillcodeID & " );"
                            dtServices = Me._objDataProc.GetDataTable(strSql)
                            'dbLabor = Me._objDataProc.GetDoubleValue(strSql)
                            If Not IsDBNull(dtServices.Compute("Sum(Labor)", "")) Then dbLabor = dtServices.Compute("Sum(Labor)", "") Else dbLabor = 0
                            For Each R2 In dtServices.Rows
                                R1("ServiceBillcodesWithAggBilling") &= R2("Billcode_Desc") & " = " & R2("Labor") & Environment.NewLine
                            Next R2
                        End If

                        dbPartFee = 0
                        dbPartFee = DeviceBilling.GetNonWrtyPartCostMarkUp(0, iCust_ID, iModel_ID, 0, Convert.ToDouble(R1("PartPrice")))

                        R1("Labor") = dbLabor : R1("PartFee") = dbPartFee : R1("Total") = Format((dbLabor + dbPartFee + Convert.ToDouble(R1("PartPrice"))), "#,###.00")
                        R1("PartPrice") = Format(R1("PartPrice"), "#,###.00")
                        R1.EndEdit()

                    Next R1
                End If

                Return dt1
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1) : Generic.DisposeDT(dtServices)
            End Try
        End Function

        '****************************************************************************************
        Public Function GetBillcodePartAndPrice(ByVal iModelID As Integer, ByVal strBillcodeIDs As String) As DataTable
            Dim strSql As String = ""
            Try
                strSql = "SELECT lbillcodes.Billcode_ID, lbillcodes.Billcode_Desc, tpsmap.LaborLevel, lbillcodes.BillType_ID" & Environment.NewLine
                strSql &= ", if(tpsmap.PSMap_ID is null, 0, tpsmap.PSMap_ID) as PSMap_ID" & Environment.NewLine
                strSql &= ", if(lpsprice.PsPrice_ID is null, 0, lpsprice.PsPrice_ID) as PsPrice_ID  " & Environment.NewLine
                strSql &= ", lpsprice.PSPrice_Number, lpsprice.PSPrice_Desc, lpsprice.PSPrice_AvgCost, lpsprice.PSPrice_StndCost " & Environment.NewLine
                strSql &= "FROM lbillcodes " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN tpsmap ON lbillcodes.Billcode_ID = tpsmap.Billcode_ID " & Environment.NewLine
                strSql &= "LEFT OUTER JOIN lpsprice ON tpsmap.PsPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                strSql &= "WHERE tpsmap.model_id = " & iModelID & Environment.NewLine
                strSql &= "AND tpsmap.Billcode_ID IN ( " & strBillcodeIDs & " ) "
                Return Me._objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function


        '*****************************************************************************
        Public Function AddSoftwareScreenKillSwitchRemovalCharge(ByVal iDevice_ID As Integer, _
                                                                 ByVal iBillCode_ID As Integer, _
                                                                 ByVal strPart_Number As String, _
                                                                 ByVal ServiceLaborCharge As Decimal, _
                                                                 ByVal iUser_ID As Integer, _
                                                                 ByVal strDate As String) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim objDataProc As DBQuery.DataProc
            Dim iRet As Integer = 0

            'Update tdevice and tdevicebill
            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT * FROM tdevice WHERE Device_ID = " & iDevice_ID & ";" & Environment.NewLine
                dt = objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then  'It must be 1 record if exist
                    strSql = "INSERT INTO tdevicebill (DBill_RegPartPrice,DBill_AvgCost,DBill_StdCost,DBill_InvoiceAmt,Device_ID,BillCode_ID,Part_Number,Fail_ID,Repair_ID,User_ID,Date_Rec)" & _
                             " VALUES (0.00,0.00,0.00,0.00," & iDevice_ID & "," & iBillCode_ID & ",'" & strPart_Number & "',0,0," & iUser_ID & ",'" & strDate & "');"
                    iRet = objDataProc.ExecuteNonQuery(strSql)

                    If IsNumeric(dt.Rows(0).Item("Device_LaborCharge")) Then
                        strSql = "UPDATE tdevice SET Device_LaborCharge = Device_LaborCharge + " & ServiceLaborCharge & Environment.NewLine
                        strSql &= " WHERE Device_ID = " & iDevice_ID & ";"
                        iRet += objDataProc.ExecuteNonQuery(strSql)
                    Else
                        strSql = "UPDATE tdevice SET Device_LaborCharge = " & ServiceLaborCharge & Environment.NewLine
                        strSql &= " WHERE Device_ID = " & iDevice_ID & ";"
                        iRet += objDataProc.ExecuteNonQuery(strSql)
                    End If

                End If

                Return iRet

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************
        Public Function GetSoftwareScreenKillSwitchRemovalData(ByVal iCust_ID As Integer, _
                                                               ByVal iDevice_ID As Integer, _
                                                               ByRef iBillCode_ID As Integer, _
                                                               ByRef strPartNumber As String, _
                                                               ByRef vCharges As Decimal, _
                                                               ByRef strMsg As String) As Boolean
            Dim strSql As String = ""
            Dim objDataProc As DBQuery.DataProc
            Dim dt1, dt2, dtTmp As DataTable
            Dim vSoftwareScreenBillCodeID As Integer

            Try
                objDataProc = New DBQuery.DataProc(ConfigFile.GetConnectionInfo)

                strSql = "SELECT A.Device_ID,A.Device_SN,A.Model_ID,B.Model_Desc,B.sw_Process,B.ks_capable" & Environment.NewLine
                strSql &= " ,if((B.sw_process=1 and B.ks_capable=1) or (B.sw_process=0 and B.ks_capable=1),1,0) as 'NeedCharge'" & Environment.NewLine
                strSql &= " FROM tdevice A" & Environment.NewLine
                strSql &= " INNER JOIN tmodel B ON A.model_ID=B.model_ID" & Environment.NewLine
                strSql &= " WHERE A.Device_ID=" & iDevice_ID & ";" & Environment.NewLine
                dtTmp = objDataProc.GetDataTable(strSql)

                If dtTmp.Rows(0).Item("NeedCharge") = 1 Then 'Need charge (The first criteria)
                    strSql = "SELECT * FROM  tdevice_question where q_id = 6 and device_id =  " & iDevice_ID & ";" & Environment.NewLine
                    dt1 = objDataProc.GetDataTable(strSql)

                    If dt1.Rows.Count = 1 Then 'found it, so need to bill
                        strSql = "SELECT A.Device_ID,A.Device_SN,B.BillCode_ID,C.BillCode_Desc" & Environment.NewLine
                        strSql &= " FROM tdevice A" & Environment.NewLine
                        strSql &= " INNER JOIN tdevicebill B ON A.Device_ID=B.Device_ID" & Environment.NewLine
                        strSql &= " INNER JOIN lbillcodes C ON B.BillCode_ID=C.BillCode_ID" & Environment.NewLine
                        strSql &= " WHERE B.BillCode_ID in (" & Me.TF_KillSwitchRemove_BillCodeID & "," & Me.TF_SoftwareScreen_BillCodeID & ")" & Environment.NewLine
                        strSql &= " AND A.Device_ID=" & iDevice_ID & ";" & Environment.NewLine
                        dtTmp = objDataProc.GetDataTable(strSql)

                        If Not dtTmp.Rows.Count > 0 Then 'not yet billed
                            If dt1.Rows(0).Item("Answer") = True Then
                                iBillCode_ID = Me.TF_KillSwitchRemove_BillCodeID
                                strPartNumber = Me.TF_KillSwitchRemove_PartNumber
                            Else
                                iBillCode_ID = Me.TF_SoftwareScreen_BillCodeID
                                strPartNumber = Me.TF_SoftwareScreen_PartNumber
                            End If

                            strSql = "SELECT * FROM tcustaggregatebilling A" & Environment.NewLine
                            strSql &= " INNER JOIN lbillcodes  B ON A.Billcode_ID=B.BillCode_ID" & Environment.NewLine
                            strSql &= " WHERE cust_ID=" & iCust_ID & " AND A.BillCode_ID = " & iBillCode_ID & ";"
                            dt2 = objDataProc.GetDataTable(strSql)
                            If dt2.Rows.Count > 0 Then
                                vCharges = dt2.Rows(0).Item("tcab_Amount")
                                strMsg = ""
                                Return True
                            Else
                                strMsg = "Can't find charge for " & strPartNumber & " in table tcustaggregatebilling. See IT."
                                Return False
                            End If
                        Else 'already billed
                            strMsg = "At least one of devices in the shipping box has the billcode for 'software screen' or 'kill switch removed'. Can't process it. See IT."
                            Return False
                        End If

                    ElseIf dt1.Rows.Count > 1 Then 'dup device
                        strMsg = "Duplicated device in table tdevice_question. See IT."
                        Return False
                    Else
                        strMsg = ""
                        Return False 'no software screen or no KS removed
                    End If
                Else
                    strMsg = ""
                    Return False 'No need charge: Not meet the first criteria
                End If
            Catch ex As Exception
                Throw ex
            Finally
                dt1 = Nothing : dt2 = Nothing : dttmp = Nothing
            End Try
        End Function

        '****************************************************************************************

#End Region

#Region "Flat Rate Billing"

        '****************************************************************************************
        Public Function SaveStatusOfUpdTFFlatRateBilling(ByVal strErrMsg As String, ByVal iRptInfoID As Integer, ByVal strTaskName As String _
                                                        , ByVal iErrFlag As Integer, ByVal strDataDateStart As String, ByVal strDataDateEnd As String _
                                                        , ByVal strDataDateType As String) As Integer
            Dim strSql As String = ""

            Try
                strSql = "INSERT INTO reports.tdailyTaskResult ( RunDate, RunDateTime, ReportInfoID, ReportInfoName, Result, ErrFlag " & Environment.NewLine
                strSql &= ", DataDateStart, DataDateEnd, DataDateType " & Environment.NewLine
                strSql &= ") VALUES ( " & Environment.NewLine
                strSql &= " now(), now(), " & iRptInfoID & ", '" & strTaskName & "', '" & strErrMsg & "', " & iErrFlag & Environment.NewLine
                strSql &= ", '" & strDataDateStart & "', '" & strDataDateEnd & "', '" & strDataDateType & "' " & Environment.NewLine
                strSql &= ") "
                Return _objDataProc.ExecuteNonQuery(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function GetDockShipFinishedGoodDevices(ByVal iCustID As Integer, ByVal strDateStart As String, ByVal strDateEnd As String) As DataTable
            Dim strSql As String = ""

            Try
                strSql = "SELECT tdevice.Device_ID, pkslip_createDt as 'ShipDate'  " & Environment.NewLine
                strSql &= " FROM tdevice INNER JOIN tpallett on tdevice.pallett_id = tpallett.pallett_ID" & Environment.NewLine
                strSql &= " INNER JOIN tpackingslip on tpallett.pkslip_ID = tpackingslip.pkslip_ID " & Environment.NewLine
                strSql &= " WHERE tpallett.Cust_ID = " & iCustID & " AND Pallet_ShipType = 0  " & Environment.NewLine
                strSql &= " AND pkslip_createDt between '" & strDateStart & " 00:00:00' and '" & strDateEnd & " 23:59:59' "
                Return _objDataProc.GetDataTable(strSql)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function IsOnHold2(ByVal iCustID As Integer, ByVal iModel_ID As Integer) As Boolean
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM tmodeltarget WHERE MT_Cust_ID= " & iCustID & " AND IsOnHold2=1 AND MT_Model_ID=" & iModel_ID & ";" & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)

                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************
        Public Function getBillCode(ByVal iBillCodeID As Integer) As DataTable
            Dim strSql As String = ""
            Dim dt As DataTable

            Try
                strSql = "SELECT * FROM lBillCodes WHERE BillCode_ID=" & iBillCodeID & ";" & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)

                Return dt

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '****************************************************************************************

#End Region

#Region "Additional Billing"
        Public Function getAdditionalLaborCharge(ByVal iCust_ID As Integer, ByVal iBillCode_ID As Integer) As Single
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim vLaborCharge As Single = 0.0

            Try
                strSql = "SELECT * FROM tcustaggregatebilling where cust_ID =" & iCust_ID & " and  billcode_ID =" & iBillCode_ID & ";"
                dt = _objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then
                    vLaborCharge = dt.Rows(0).Item("tcab_Amount")
                End If

                Return vLaborCharge
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function InsertUpdateAddionalCharges(ByVal iDevice_ID As Integer, ByVal iBillCode_ID As Integer, _
                                                    ByVal vCharges As Single, ByVal strPartNum As String, _
                                                    ByVal strDateTime As String, ByVal iUserID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                strSql = "select * from tdevicebill_additional" & Environment.NewLine
                strSql &= " where Device_ID = " & iDevice_ID & " and BillCode_ID = " & iBillCode_ID & Environment.NewLine
                dt = _objDataProc.GetDataTable(strSql)
                If dt.Rows.Count > 0 Then 'update
                    strSql = "update tdevicebill_additional set DBill_InvoiceAmt = " & vCharges
                    strSql &= ",Part_Number='" & strPartNum & "', Date_Rec='" & strDateTime & "', User_ID=" & iUserID
                    strSql &= " where Device_ID = " & iDevice_ID & " and BillCode_ID = " & iBillCode_ID & Environment.NewLine
                    i = _objDataProc.ExecuteNonQuery(strSql)
                Else 'insert new
                    strSql = "insert into tdevicebill_additional (DBill_InvoiceAmt,Device_ID,BillCode_ID,Part_Number,User_ID,Date_Rec)" & Environment.NewLine
                    strSql &= " values (" & vCharges & "," & iDevice_ID & "," & iBillCode_ID & ",'" & strPartNum & "'," & iUserID & ",'" & strDateTime & "')"
                    i = _objDataProc.ExecuteNonQuery(strSql)
                End If

                Return i

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

    End Class
End Namespace