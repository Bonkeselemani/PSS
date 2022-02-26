Option Explicit On 

Namespace Buisness

    Public Class ATCLESpecialBilling
        Private objMisc As Production.Misc
        Private objBilling As Production.Billing
        Private iUser_ID As Integer = 0
        Private strWork_Dt As String = ""

        '***************************************
        'Properties
        '***************************************
        Public Property UserID() As Integer
            Get
                Return iUser_ID
            End Get
            Set(ByVal Value As Integer)
                iUser_ID = Value
            End Set
        End Property
        Public Property WorkDate() As String
            Get
                Return strWork_Dt
            End Get
            Set(ByVal Value As String)
                strWork_Dt = Value
            End Set
        End Property

        '***************************************************
        Public Sub New()
            objMisc = New Production.Misc()
            objBilling = New Production.Billing()
        End Sub

        Protected Overrides Sub Finalize()
            objMisc = Nothing
            objBilling = Nothing
            MyBase.Finalize()
        End Sub
        '***************************************************

        '***************************************************************************
        Public Function IsModelHasATT(ByVal iModelID As Integer) As Boolean
            Dim strSql As String = ""
            Dim strModel_Desc As String = ""

            Try
                strSql = "SELECT Model_Desc FROM tmodel WHERE model_id = " & iModelID & ";"
                strModel_Desc = Me.objMisc.GetSingletonString(strSql)

                If InStr(1, UCase(Trim(strModel_Desc)), "ATT") <> 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MsgBox(ex.ToString, MsgBoxStyle.Critical, "Verify ATT Model")
            End Try
        End Function

        '***************************************************************************
        Public Function SpecialBilling(ByVal strBeginShipWkDt As String, _
                                       ByVal strEndShipWkDt As String, _
                                       ByVal iCust_ID As Integer) As Integer
            Dim strsql As String = ""
            Dim dt1, dt2 As DataTable
            Dim R1 As DataRow
            Dim RDevice As DataRow
            Dim boovar As Boolean = False
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim strFP As String = "C:\ATCLE Random Billgroups.txt"
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim strServerDateTime As String = ""
            Dim strRndBillGroup As String = ""
            Dim decBillGroupTotal As Decimal = 0
            Dim decConsumedTotal As Decimal = 0
            Dim decTarget As Decimal = 0
            Dim iMaxLaborLevelForDevice As Integer = 0
            Dim booTargetBillGroupsCreated As Boolean = False



            Try
                '**************************************************
                'OPen text file to append
                If Len(Dir(strFP)) > 0 Then
                    Kill(strFP)
                End If
                FileOpen(1, strFP, OpenMode.Append)   'Open TXT file
                '**************************************************
                strServerDateTime = objGen.MySQLServerDateTime(1)
                '***************************************************
                '//Step 1: Get all Brightpoint Shipped Devices today.
                '//*************************************************
                dt1 = GetATCLEDevicesShippedByLocationByWorkDt(iCust_ID, strBeginShipWkDt, strEndShipWkDt)
                '***************************************************
                '//Step 2: Loop through all devices and check if each has atleast one entry in 
                '//in the new billing table tdevicebill_560
                '//*************************************************
                'device loop
                For Each R1 In dt1.Rows

                    '//***********************************************
                    '//Check if the model can be auto billed
                    '//***********************************************
                    If R1("AutoBill") = 0 Then
                        '//*****************************************
                        'Move all parts and services for the device
                        '//*****************************************
                        i = Me.CopyBillcodesFromTdevicebillToTdevicebill_560(R1("Device_ID"), 1, )
                        '*********************************************************
                        'Copy existing regurlar tdevice field values to Auto Billed field values
                        '*********************************************************
                        i = Me.UpdateLaborInfo_AB(R1("Device_ID"), , , )
                        '*********************************************************
                    Else
                        '//************************************
                        'Check if device is repaired
                        '//************************************
                        boovar = objGen.IsDeviceRepaired(R1("Device_ID"))
                        If boovar = False Then
                            '//************************************
                            'move all parts and services for the device
                            '//************************************
                            i = Me.CopyBillcodesFromTdevicebillToTdevicebill_560(R1("Device_ID"), 2, )
                            '*********************************************************
                            'Copy existing regurlar tdevice field values to Auto Billed field values
                            '*********************************************************
                            i = Me.UpdateLaborInfo_AB(R1("Device_ID"), , , )
                            '*********************************************************
                        Else
                            '//***********************************************
                            '//Check if the device is already auto-billed
                            '//***********************************************
                            boovar = False
                            boovar = CheckIfDeviceAutoBilledAlready(R1("Device_ID"))

                            If boovar = False Then      'if the device is not auto billed
                                '//***********************************
                                '//Get Device related info
                                '//***********************************
                                dt2 = objBilling.GetDevice_BillInfo(R1("Device_ID"))

                                If dt2.Rows.Count = 0 Then
                                    MsgBox("Device info could not be pulled.")
                                    Exit Function
                                Else
                                    RDevice = dt2.Rows(0)
                                    If dt2.Rows.Count > 1 Then
                                        MsgBox("Device Info has mutiple row for Device_ID: " & R1("Device_ID"))
                                    End If
                                End If
                                '//***********************************
                                If Not IsNothing(dt2) Then
                                    dt2.Dispose()
                                    dt2 = Nothing
                                End If

                                '**********************************************
                                'Compare Max labor level in tdevice
                                ' if Max labor level = 1, transfer all parts/services
                                '  from tdevicebill to tdevicebill_560
                                '//********************************************
                                iMaxLaborLevelForDevice = Me.objBilling.GetMax_ConsumedLaborLvl_OfDev(R1("Device_ID"))

                                If iMaxLaborLevelForDevice = 1 Then     'Pass through Labor Level 1 stuff
                                    '//*****************************************
                                    'move all parts and services for the device
                                    '//*****************************************
                                    i = Me.CopyBillcodesFromTdevicebillToTdevicebill_560(R1("Device_ID"), 3, )
                                    '*********************************************************
                                    'Copy existing regurlar tdevice field values to Auto Billed field values
                                    '*********************************************************
                                    i = Me.UpdateLaborInfo_AB(R1("Device_ID"), , , )
                                    '*********************************************************
                                Else    'Labor Level > 1
                                    '**********************************************
                                    'Are Billgroups created for customer, model and enterprise 
                                    '//********************************************
                                    booTargetBillGroupsCreated = Me.AreTargetAndBillGroupsCreated(iCust_ID, R1("Model_ID"), Trim(R1("Enterprise")))

                                    If booTargetBillGroupsCreated = False Then
                                        'Throw New Exception("No 'Bill Groups' exist for '" & Trim(R1("Model_Desc")) & "' and '" & R1("csin_EnterpriseCode") & "'.")
                                        '//*****************************************
                                        'move all parts and services of the device
                                        '//*****************************************
                                        i = Me.CopyBillcodesFromTdevicebillToTdevicebill_560(R1("Device_ID"), 4, )
                                        '*********************************************************
                                        'Copy existing regurlar tdevice field values to Auto Billed field values
                                        '*********************************************************
                                        i = Me.UpdateLaborInfo_AB(R1("Device_ID"), , , )
                                        '*********************************************************
                                    Else
                                        '**********************************************
                                        'Compare consumed and target
                                        '//********************************************
                                        decConsumedTotal = Me.GetConsumedTotal(R1("Device_ID"))
                                        decTarget = Me.GetTargetAmount(iCust_ID, R1("Model_ID"), R1("Enterprise"))

                                        'If Consumed >= target then pass through
                                        If decConsumedTotal >= decTarget Then
                                            '//*****************************************
                                            'move all parts and services of the device
                                            '//*****************************************
                                            i = Me.CopyBillcodesFromTdevicebillToTdevicebill_560(R1("Device_ID"), 5, )
                                            '*********************************************************
                                            'Copy existing regurlar tdevice field values to Auto Billed field values
                                            '*********************************************************
                                            i = Me.UpdateLaborInfo_AB(R1("Device_ID"), , , )
                                            '*********************************************************
                                        Else   'If Consumed < target then Auto Bill
                                            '**********************************************
                                            'Randomly select a Bill Group
                                            '//********************************************
                                            strRndBillGroup = GetRandomBillGroup(R1("Device_ID"), iCust_ID, R1("Model_ID"), R1("Enterprise"))
                                            '**********************************************
                                            'Write Random bill group to text file
                                            '**********************************************
                                            PrintLine(1, strRndBillGroup)
                                            '**********************************************
                                            'Get Billcodes in Random Bill Group
                                            '//***********************************************
                                            dt2 = GetBillGroupInfo(iCust_ID, R1("Model_ID"), strRndBillGroup, Trim(R1("Enterprise")))

                                            '*************************************************
                                            'Get total billed amount(labor+parts) of billgroup
                                            '//***********************************************
                                            decBillGroupTotal = Me.GetBillGroupTotal(dt2, RDevice)

                                            If decConsumedTotal > decBillGroupTotal Then
                                                '//*****************************************
                                                'move all parts and services of the device
                                                ' Use the same condition as when billgroup are not created(4)
                                                '//*****************************************
                                                i = Me.CopyBillcodesFromTdevicebillToTdevicebill_560(R1("Device_ID"), 6, )
                                                '*********************************************************
                                                'Copy existing regurlar tdevice field values to Auto Billed field values
                                                '*********************************************************
                                                i = Me.UpdateLaborInfo_AB(R1("Device_ID"), , , )
                                                '*********************************************************
                                            Else    'decConsumedTotal > decBillGroupTotal
                                                '//********************************************************************
                                                '// Bill all Parts from the above selected Bill Group for the device
                                                '     and services from tdevicebill and calculate the labor charge
                                                '//********************************************************************
                                                j += Me.AutoBillParts_Services_ATCLE(strServerDateTime, RDevice, dt2)
                                                '//************************************
                                            End If      'Check if the total consumed higher than total selected billgroup
                                        End If      'Compare consumed and target
                                    End If      'Are Billgroups created for customer, model and enterprise 
                                End If      'Compare Max labor level = 1
                            End If      'if the device has been auto billed already
                        End If      'Check if device is repaired
                    End If      '//Check if model of device can be auto billed

                    '**************************
                    'Reinitialise loop variables
                    '//************************
                    boovar = False
                    booTargetBillGroupsCreated = False
                    j = 0    'return value from auto-bill (parts from billgroup)
                    i = 0    'return value from auto-bill (services from actual billing)
                    strRndBillGroup = ""
                    decBillGroupTotal = 0
                    decConsumedTotal = 0
                    decTarget = 0
                    iMaxLaborLevelForDevice = 0
                    '**************************
                Next R1
                '***************************************************

                Return dt1.Rows.Count
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            Finally
                Reset()
                objGen = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Private Function GetATCLEDevicesShippedByLocationByWorkDt(ByVal iCust_ID As Integer, _
                                                                  ByVal strBeginShipWkDt As String, _
                                                                  ByVal strEndShipWkDt As String) As DataTable
            Dim strSql As String = ""

            Try
                '//Get all ATCLE Shipped Devices today.
                strSql = "SELECT tdevice.*, tmodeltarget.AutoBill, " & Environment.NewLine
                strSql &= "'ATCLE' as Enterprise " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tlocation ON tdevice.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                strSql &= "INNER JOIN tmodeltarget ON tdevice.Model_ID = tmodeltarget.MT_Model_ID AND tlocation.Cust_ID = tmodeltarget.MT_Cust_ID AND tmodeltarget.MT_Enterprise = 'ATCLE' " & Environment.NewLine
                strSql &= "WHERE tlocation.Cust_id = " & iCust_ID & Environment.NewLine
                'strSql &= "AND Device_ShipWorkDate >= '" & strBeginShipWkDt & "' and  " & Environment.NewLine
                'strSql &= "Device_ShipWorkDate <= '" & strEndShipWkDt & "'" & Environment.NewLine
                strSql &= "AND tdevice.Device_LaborLevel_AutoBilled is null and device_id = 10336230;"

                objMisc._SQL = strSql
                Return objMisc.GetDataTable

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Private Function CopyBillcodesFromTdevicebillToTdevicebill_560(ByVal iDevice_ID As Integer, _
                                                                       ByVal iBillCondition As Integer, _
                                                                       Optional ByVal iTransfer_Part_Service As Integer = 0) As Integer
            Dim strSql As String = ""
            Dim strValue As String = ""
            Dim dt1, dt2 As DataTable
            Dim i As Integer = 0
            Dim R1 As DataRow

            Try

                '********************************************
                'Get stuff from tdevicebill
                '********************************************
                strSql = "Select tdevicebill.* from tdevicebill " & Environment.NewLine
                If iTransfer_Part_Service > 0 Then
                    strSql &= "inner join lbillcodes on tdevicebill.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                End If
                strSql &= "where tdevicebill.device_id = " & iDevice_ID & " " & Environment.NewLine
                If iTransfer_Part_Service > 0 Then
                    strSql &= " and lbillcodes.BillType_ID = " & iTransfer_Part_Service & " "    'Services or Parts
                End If
                strSql &= ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable
                '********************************************
                If dt1.Rows.Count = 0 Then
                    Exit Function
                End If
                '********************************************
                For Each R1 In dt1.Rows
                    '**********************************************
                    'Check if billcode already existed then skip it
                    '**********************************************
                    If Not IsNothing(dt2) Then
                        dt2.Dispose()
                        dt2 = Nothing
                    End If

                    strSql = "select count(*) as cnt from tdevicebill_560 " & Environment.NewLine
                    strSql &= "where device_id = " & iDevice_ID & Environment.NewLine
                    strSql &= " and billcode_id = " & R1("BillCode_ID") & ";"
                    objMisc._SQL = strSql
                    dt2 = objMisc.GetDataTable

                    If dt2.Rows(0)("cnt") = 0 Then
                        strSql = ""
                        strValue = ""
                        '********************************************
                        'Insert into tdveicbill_560
                        '********************************************
                        'MUST CHANGE BACK TO tdevicebill560
                        strSql = "insert into tdevicebill_560 (DBill_Condition, " & Environment.NewLine

                        If Not IsDBNull(R1("DBill_AvgCost")) Then
                            strSql &= "DBill_AvgCost, " & Environment.NewLine
                            strValue &= R1("DBill_AvgCost") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("DBill_StdCost")) Then
                            strSql &= "DBill_StdCost, " & Environment.NewLine
                            strValue &= R1("DBill_StdCost") & ", " & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("DBill_InvoiceAmt")) Then
                            strSql &= "DBill_InvoiceAmt, " & Environment.NewLine
                            strValue &= R1("DBill_InvoiceAmt") & ", " & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("Device_ID")) Then
                            strSql &= "Device_ID, " & Environment.NewLine
                            strValue &= R1("Device_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("BillCode_ID")) Then
                            strSql &= "BillCode_ID, " & Environment.NewLine
                            strValue &= R1("BillCode_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Fail_ID")) Then
                            strSql &= "Fail_ID, " & Environment.NewLine
                            strValue &= R1("Fail_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Repair_ID")) Then
                            strSql &= "Repair_ID, " & Environment.NewLine
                            strValue &= R1("Repair_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Comp_ID")) Then
                            strSql &= "Comp_ID, " & Environment.NewLine
                            strValue &= R1("Comp_ID") & ", " & Environment.NewLine
                        End If
                        If Not IsDBNull(R1("User_ID")) Then
                            strSql &= "User_ID, " & Environment.NewLine
                            strValue &= R1("User_ID") & ", " & Environment.NewLine
                        End If

                        If Not IsDBNull(R1("Date_Rec")) Then
                            strSql &= "Date_Rec " & Environment.NewLine
                            strValue &= "'" & Format(R1("Date_Rec"), "yyyy-MM-dd") & "'" & Environment.NewLine
                        Else
                            strSql &= "Date_Rec " & Environment.NewLine
                            strValue &= "'" & Format(Now, "yyyy-MM-dd") & "'" & Environment.NewLine
                        End If

                        strSql &= ") values (" & iBillCondition & ", " & Environment.NewLine
                        strValue &= ");"

                        strSql &= strValue
                        objMisc._SQL = strSql
                        i += objMisc.ExecuteNonQuery
                        '********************************************
                    End If
                Next R1

                Return i
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function UpdateLaborInfo_AB(ByVal iDevice_ID As Integer, _
                                                 Optional ByVal strDateTime As String = "", _
                                                 Optional ByVal iCurLaborLevel As Integer = 0, _
                                                 Optional ByVal DecCurLaborChg As Decimal = 0.0) As Integer
            Dim strSql As String

            Try
                strSql = "UPDATE tdevice " & Environment.NewLine
                If strDateTime <> "" Then
                    strSql &= "SET Device_DateBill_AutoBilled = '" & strDateTime & "', " & Environment.NewLine
                Else
                    strSql &= "SET Device_DateBill_AutoBilled = Device_DateBill, " & Environment.NewLine
                End If

                If iCurLaborLevel > 0 Then
                    strSql &= "Device_LaborLevel_AutoBilled = " & iCurLaborLevel & ", " & Environment.NewLine
                Else
                    strSql &= "Device_LaborLevel_AutoBilled = Device_LaborLevel, " & Environment.NewLine
                End If

                If DecCurLaborChg > 0 Then
                    strSql &= "Device_LaborCharge_AutoBilled = " & DecCurLaborChg & " " & Environment.NewLine
                Else
                    strSql &= "Device_LaborCharge_AutoBilled =  Device_LaborCharge " & Environment.NewLine
                End If

                strSql &= " WHERE Device_ID = " & iDevice_ID & ";"
                objMisc._SQL = strSql
                Return objMisc.ExecuteNonQuery

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Function CheckIfDeviceAutoBilledAlready(ByVal iDevice_ID As Integer) As Boolean
            Dim dt2 As DataTable
            Dim strsql As String = ""
            Dim booVar As Boolean = False

            Try
                'Check if the device is already auto-billed
                strsql = "Select * from tdevicebill_560 where device_id = " & iDevice_ID & ";"
                objMisc._SQL = strsql
                dt2 = objMisc.GetDataTable

                If dt2.Rows.Count > 0 Then
                    booVar = True
                End If

                Return booVar
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt2) Then
                    dt2.Dispose()
                    dt2 = Nothing
                End If
            End Try
        End Function



        '***************************************************************************
        Public Function AreTargetAndBillGroupsCreated(ByVal iCust_ID As Integer, _
                                                      ByVal iModel_ID As Integer, _
                                                      ByVal strEnterprise As String) As Boolean
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim booVar As Boolean = True

            Try
                'Check if target is created
                strsql = "SELECT count(*) as cnt " & Environment.NewLine
                strsql &= "FROM tmodeltarget  " & Environment.NewLine
                strsql &= "WHERE  " & Environment.NewLine
                strsql &= "tmodeltarget.MT_Cust_ID = " & iCust_ID & " " & Environment.NewLine
                strsql &= "AND tmodeltarget.MT_Model_ID = " & iModel_ID & " " & Environment.NewLine
                strsql &= "AND tmodeltarget.MT_Enterprise = '" & strEnterprise & "';"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    booVar = False
                Else
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If

                    'Check if the billgroups are created
                    dt1 = Me.GetBillGroupsForCustModelEnterprise(iCust_ID, iModel_ID, strEnterprise)

                    If dt1.Rows.Count = 0 Then
                        booVar = False
                    End If
                End If

                Return booVar
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetBillGroupsForCustModelEnterprise(ByVal iCust_ID As Integer, _
                                                            ByVal iModel_ID As Integer, _
                                                            ByVal strEnterpriseCode As String) _
                                                            As DataTable
            Dim strsql As String = ""
            Dim objMisc As New Production.Misc()

            Try
                strsql = "SELECT distinct bg_bill_group " & Environment.NewLine
                strsql &= "FROM tbillgroup_atcle " & Environment.NewLine
                strsql &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strsql &= "AND  bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strsql &= "AND  bg_enterprise = '" & strEnterpriseCode & "' " & Environment.NewLine
                strsql &= "AND bg_inactive = 0;"
                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetConsumedTotal(ByVal iDevice_ID As Integer) As Decimal
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim decLabor As Decimal = 0
            Dim decInvAmt As Decimal = 0

            Try
                '**********************************
                'Get Labor charge
                '**********************************
                strsql = "select Device_LaborCharge from tdevice where device_id = " & iDevice_ID & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("Device_LaborCharge")) Then
                        decLabor = dt1.Rows(0)("Device_LaborCharge")
                    End If
                End If

                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                '*********************************************
                'Get part and service amount (invoice amount)
                '*********************************************
                strsql = "select sum(DBill_InvoiceAmt) as InviceAmt from tdevicebill where device_id = " & iDevice_ID & ";"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable
                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("InviceAmt")) Then
                        decInvAmt = dt1.Rows(0)("InviceAmt")
                    End If
                End If

                '******************
                'Total consumed
                '******************
                Return decLabor + decInvAmt

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetTargetAmount(ByVal iCust_ID As Integer, _
                                        ByVal iModel_ID As Integer, _
                                        ByVal strEnterprise As String) As Decimal
            Dim strsql As String = ""
            Dim dt1 As DataTable
            Dim decTarget As Decimal = 0

            Try
                strsql = "SELECT * FROM tmodeltarget " & Environment.NewLine
                strsql &= "WHERE MT_Cust_ID = " & iCust_ID & Environment.NewLine
                strsql &= " and MT_Model_ID = " & iModel_ID & Environment.NewLine
                strsql &= " and MT_Enterprise = '" & Trim(strEnterprise) & "';"
                objMisc._SQL = strsql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("MT_Target")) Then
                        decTarget = dt1.Rows(0)("MT_Target")
                    End If
                End If

                Return decTarget
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetRandomBillGroup(ByVal iDevice_ID As Integer, _
                                           ByVal iCust_ID As Integer, _
                                           ByVal iModel_ID As Integer, _
                                           ByVal strEnterprise As String) As String
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strsql As String = ""
            Dim iRndNum As Integer = 0
            Dim iLoopCounter As Integer = 1
            Dim iLowerBound As Integer = 1
            Dim iUpperBound As Integer = 0
            Dim strRndBillGroup As String = ""
            Dim r As Random

            Try
                dt1 = Me.GetBillGroupsForCustModelEnterprise(iCust_ID, iModel_ID, strEnterprise)

                iUpperBound = dt1.Rows.Count
                'iRndNum = CInt(Int((iUpperBound * Rnd()) + iLowerBound))
                r = New Random(iDevice_ID)
                iRndNum = r.Next(iLowerBound, iUpperBound)

                '*************************************************************
                '//Select the Bill group based on the random number generated.
                For Each R1 In dt1.Rows
                    If iRndNum = iLoopCounter Then
                        strRndBillGroup = Trim(R1("bg_bill_group"))
                        Exit For
                    End If

                    iLoopCounter += 1
                Next R1
                '*************************************************************
                Return strRndBillGroup

            Catch ex As Exception
                Throw ex
            Finally
                'Reset()
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetBillGroupInfo(ByVal iCust_ID As Integer, _
                                         ByVal iModel_ID As Integer, _
                                         ByVal strRndBillGroup As String, _
                                         ByVal strEnterprise As String) As DataTable
            Dim strsql As String = ""

            Try
                strsql = "SELECT * from tbillgroup_atcle " & Environment.NewLine
                strsql &= "WHERE bg_cust_id = " & iCust_ID & " " & Environment.NewLine
                strsql &= "AND bg_model_id = " & iModel_ID & " " & Environment.NewLine
                strsql &= "AND bg_enterprise = '" & strEnterprise & "' " & Environment.NewLine
                strsql &= "AND bg_bill_group = '" & strRndBillGroup & "' " & Environment.NewLine
                strsql &= "AND bg_Inactive = 0;"

                objMisc._SQL = strsql
                Return objMisc.GetDataTable
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************
        Public Function GetBillGroupTotal(ByVal dtBillGroup As DataTable, _
                                          ByVal RDevice As DataRow) As Decimal
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim decLabor As Decimal = 0
            Dim decTotalSandardCost As Decimal = 0
            Dim strBillcode_IDs As String = ""
            Dim strLaborLvl_IDs As String = ""
            Dim iMaxLaborLvl_ID As Integer = 0


            Try
                '*******************************
                'get billcode_id string
                '*******************************
                For Each R1 In dtBillGroup.Rows
                    If strBillcode_IDs = "" Then
                        strBillcode_IDs &= R1("billcode_id")
                    Else
                        strBillcode_IDs &= ", " & R1("billcode_id")
                    End If
                Next R1

                If strBillcode_IDs <> "" Then
                    '***************************************
                    'get Total Standard cost for billgroup
                    '***************************************
                    strSql = "SELECT sum(PSPrice_StndCost) * 1.1 as TotalSandardCost " & Environment.NewLine
                    strSql &= "FROM tpsmap " & Environment.NewLine
                    strSql &= "INNER JOIN lpsprice ON tpsmap.PSPrice_ID = lpsprice.PSPrice_ID " & Environment.NewLine
                    strSql &= "WHERE model_id = " & RDevice("Model_ID") & Environment.NewLine
                    strSql &= "AND prod_id = " & RDevice("Prod_ID") & Environment.NewLine
                    strSql &= "AND Inactive = 0 " & Environment.NewLine
                    strSql &= "AND billcode_id in ( " & strBillcode_IDs & "); "
                    objMisc._SQL = strSql
                    dt1 = objMisc.GetDataTable
                    If dt1.Rows.Count > 0 Then
                        If Not IsDBNull(dt1.Rows(0)("TotalSandardCost")) Then
                            decTotalSandardCost = dt1.Rows(0)("TotalSandardCost")
                        End If
                    End If

                    '***************************************
                    'get highest labor level of billgroup
                    '***************************************
                    R1 = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If

                    strSql = "SELECT max(LaborLvl_ID) as MaxLaborLvl_ID " & Environment.NewLine
                    strSql &= "FROM tpsmap " & Environment.NewLine
                    strSql &= "WHERE Model_id = " & RDevice("Model_ID") & Environment.NewLine
                    strSql &= "AND Prod_ID = " & RDevice("Prod_ID") & Environment.NewLine
                    strSql &= "AND Inactive = 0 " & Environment.NewLine
                    strSql &= "AND billcode_id in ( " & strBillcode_IDs & "); " & Environment.NewLine
                    objMisc._SQL = strSql
                    dt1 = objMisc.GetDataTable
                    If dt1.Rows.Count > 0 Then
                        If Not IsDBNull(dt1.Rows(0)("MaxLaborLvl_ID")) Then
                            iMaxLaborLvl_ID = dt1.Rows(0)("MaxLaborLvl_ID")
                        End If
                    End If

                    '***************************************
                    'get highest labor charge of billgroup
                    '***************************************
                    R1 = Nothing
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If

                    dt1 = Me.DetermineATCLE_ABLaborLevel_ABLaborCharge(RDevice, iMaxLaborLvl_ID)

                    If dt1.Rows.Count > 0 Then
                        If Not IsDBNull(dt1.Rows(0)("MaxLaborCharge")) Then
                            decLabor = dt1.Rows(0)("MaxLaborCharge")
                        End If
                    End If
                End If

                Return decLabor + decTotalSandardCost

            Catch ex As Exception
                Throw ex
            Finally
                RDevice = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                If Not IsNothing(dtBillGroup) Then
                    dtBillGroup.Dispose()
                    dtBillGroup = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function AutoBillParts_Services_ATCLE(ByVal strServerDateTime As String, _
                                       ByVal RDevice As DataRow, _
                                       ByVal dtBillGroup As DataTable) As Integer
            Dim strsql As String = ""
            Dim i As Integer = 0
            Dim dt1 As DataTable
            Dim R1, RPart, RLabor As DataRow
            Dim decAvgcost As Decimal = 0
            Dim decStdcost As Decimal = 0
            Dim decInvcost As Decimal = 0
            Dim DecLaborChg As Decimal = 0
            Dim iLaborLvlID As Integer = 0
            Dim objGen As New PSS.Data.Buisness.Generic()

            Try
                '**************************************************
                '1:: PART SECTION
                '**************************************************
                For Each R1 In dtBillGroup.Rows
                    '***********************************************************
                    'Get Avg Cost and Std Cost and inv price from lpsprice table
                    '***********************************************************
                    dt1 = Me.objBilling.GetPartPriceInfo(RDevice("Model_ID"), R1("billcode_id"))

                    If dt1.Rows.Count = 0 Then
                        MsgBox("Billcode to Part mapping information could not be determined.")
                        Exit Function
                    Else
                        If dt1.Rows.Count > 1 Then
                            MsgBox("Part Info of device_ID " & RDevice("Device_ID") & " has more than 1 row.")
                        End If
                        RPart = dt1.Rows(0)
                    End If

                    '*************************
                    'Get DeviceInvoice Amount
                    '*************************
                    If Not IsDBNull(RPart("PSPrice_StndCost")) Then
                        If RPart("BillType_ID") = 1 Then 'Service
                            decInvcost = RPart("PSPrice_StndCost")
                        ElseIf RPart("BillType_ID") = 2 Then 'Part
                            decInvcost = Math.Round(RPart("PSPrice_StndCost") * (RDevice("Cust_Markup") + 1), 2)
                        Else                      'Everything else
                            decInvcost = Math.Round(RPart("PSPrice_StndCost") * (RDevice("Cust_Markup") + 1), 2)
                        End If
                    End If
                    '******************************
                    'Get AvgCost and StandardCost
                    '******************************
                    If Not IsDBNull(RPart("PSPrice_AvgCost")) Then
                        decAvgcost = Math.Round(RPart("PSPrice_AvgCost"), 2)
                    End If
                    If Not IsDBNull(RPart("PSPrice_StndCost")) Then
                        decStdcost = Math.Round(RPart("PSPrice_StndCost"), 2)
                    End If

                    '*****************************
                    'Insert in to tdevicebill_560
                    '*****************************
                    i += Me.InsertIntoTdevicebill_560(decAvgcost, decStdcost, decInvcost, RDevice("Device_ID"), R1("billcode_id"), R1("bg_id"))

                    '***********************
                    'Reset loop variable
                    '***********************
                    If Not IsNothing(dt1) Then
                        dt1.Dispose()
                        dt1 = Nothing
                    End If
                    RPart = Nothing
                    decInvcost = 0
                    decAvgcost = 0
                    decStdcost = 0
                    '***********************
                Next R1

                '**************************************************
                '2:: LABOR SECTION
                '**************************************************
                'Determine the Labor Level and Labor Charge Info of Device
                '**************************************************
                dt1 = Me.DetermineATCLE_ABLaborLevel_ABLaborCharge(RDevice)

                If dt1.Rows.Count = 0 Then
                    Throw New Exception("'Pricing Group', 'Product Group' and 'Labor Level' relationship was not established by Customer Service. Please contact the relevant department to address the issue.")
                Else
                    If dt1.Rows.Count > 1 Then
                        MsgBox("Labor Info of device_ID " & RDevice("Device_ID") & " has more than 1 row.")
                    End If

                    RLabor = dt1.Rows(0)
                    If Not IsDBNull(RLabor("LaborLvl_ID")) Then
                        iLaborLvlID = RLabor("LaborLvl_ID")
                    Else
                        Throw New Exception("Labor Level can not be NULL. Customer Service issue. Please contact the relevant department to address the issue.")
                    End If
                    If Not IsDBNull(RLabor("LaborPrc_RegPrc")) Then
                        DecLaborChg = RLabor("LaborPrc_RegPrc")
                    Else
                        Throw New Exception("Labor Charge can not be NULL. Customer Service issue. Please contact the relevant department to address the issue.")
                    End If
                End If

                '*************************************
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                '*************************************************
                'Update tdevice  AB labor level and labor charge
                '*************************************************
                i += Me.UpdateLaborInfo_AB(RDevice("Device_ID"), strServerDateTime, iLaborLvlID, DecLaborChg)
                '**************************************************

                Return i

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Private Function InsertIntoTdevicebill_560(ByVal decAvgcost As Decimal, _
                                                   ByVal decStdcost As Decimal, _
                                                   ByVal decInvcost As Decimal, _
                                                   ByVal iDevice_ID As Integer, _
                                                   ByVal iBillCode_ID As Integer, _
                                                   ByVal iBillGroup_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim i As Integer = 0

            Try
                strSql = "SELECT Dbill_ID " & Environment.NewLine
                strSql &= "FROM tdevicebill_560  " & Environment.NewLine
                strSql &= "WHERE Device_ID = " & iDevice_ID & " " & Environment.NewLine
                strSql &= "AND BillCode_ID = " & iBillCode_ID & ";"
                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count = 0 Then
                    strSql = ""

                    strSql = "INSERT INTO tdevicebill_560 ( " & Environment.NewLine
                    strSql &= "DBill_AvgCost, " & Environment.NewLine
                    strSql &= "DBill_StdCost, " & Environment.NewLine
                    strSql &= "DBill_InvoiceAmt, " & Environment.NewLine
                    strSql &= "Device_ID, " & Environment.NewLine
                    strSql &= "BillCode_ID, " & Environment.NewLine
                    strSql &= "User_ID, " & Environment.NewLine
                    strSql &= "BG_ID, " & Environment.NewLine
                    strSql &= "Date_Rec " & Environment.NewLine
                    strSql &= ") VALUES ( " & Environment.NewLine
                    strSql &= decAvgcost & ", " & Environment.NewLine
                    strSql &= decStdcost & ", " & Environment.NewLine
                    strSql &= decInvcost & ", " & Environment.NewLine
                    strSql &= iDevice_ID & ", " & Environment.NewLine
                    strSql &= iBillCode_ID & ", " & Environment.NewLine
                    strSql &= Me.iUser_ID & ", " & Environment.NewLine
                    strSql &= iBillGroup_ID & ", " & Environment.NewLine
                    strSql &= "'" & Me.strWork_Dt & "');"

                    objMisc._SQL = strSql
                    i = objMisc.ExecuteNonQuery
                End If

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function DetermineATCLE_ABLaborLevel_ABLaborCharge(ByVal RDeviceInfo As DataRow, _
                                                                  Optional ByVal iLaborLvl As Integer = 0) As DataTable
            Dim strSql As String = ""
            Dim objBilling As New PSS.Data.Production.Billing()
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim iMaxLaborLevel As Integer = 0
            Dim dtLaborInfo As DataTable
            Dim dtPO As DataTable
            Dim dtAggBillcode As DataTable
            Dim R1 As DataRow
            Dim decTotalAggLabor As Decimal = 0
            Dim iProdGrp As Integer = 0
            Dim iPrcGrp As Integer = 0
            Dim iAgg As Integer = 0
            Dim iTierFlat As Integer = 0

            Try
                If iLaborLvl <> 0 Then
                    iMaxLaborLevel = iLaborLvl
                End If

                If RDeviceInfo("PO_ID") > 0 Then
                    dtPO = objBilling.GetPOInfo(RDeviceInfo("Device_ID"))
                    If dtPO.Rows.Count > 0 Then
                        iProdGrp = dtPO.Rows(0)("ProductGroup")
                        iPrcGrp = dtPO.Rows(0)("PricingGroup")
                        iAgg = dtPO.Rows(0)("PO_Aggregate")
                        iTierFlat = dtPO.Rows(0)("PrcType_ID")
                    Else
                        Throw New Exception("PO ID " & RDeviceInfo("PO_ID") & " does not exist.")
                    End If
                Else
                    iProdGrp = RDeviceInfo("ProductGroup")
                    iPrcGrp = RDeviceInfo("PricingGroup")
                    iAgg = RDeviceInfo("Cust_AggBilling")
                    iTierFlat = RDeviceInfo("PrcType_ID")
                End If

                '**************************************************
                'Determine the Labor Level and Labor Charge Info
                '**************************************************
                If iAgg > 0 Then
                    dtAggBillcode = objBilling.GetAgg_BillInfo(RDeviceInfo("Cust_ID"), RDeviceInfo("Model_ID"))

                    'Get Max AB labor level
                    If iMaxLaborLevel = 0 Then
                        iMaxLaborLevel = Me.GetMax_ABLaborLvl_OfDevice(RDeviceInfo("Device_ID"))
                    End If

                    For Each R1 In dtAggBillcode.Rows
                        decTotalAggLabor = R1("LaborChrg")
                    Next R1

                    dtLaborInfo = New DataTable()
                    objGen.AddNewColumnToDataTable(dtLaborInfo, "MaxLaborLvl", "System.Int32", "0")
                    objGen.AddNewColumnToDataTable(dtLaborInfo, "LaborPrc_RegPrc", "System.Decimal", "0")
                    objGen.AddNewColumnToDataTable(dtLaborInfo, "LaborPrc_WrtyPrc", "System.Decimal", "0")

                    R1 = Nothing
                    R1 = dtLaborInfo.NewRow
                    R1("MaxLaborLvl") = iMaxLaborLevel
                    R1("LaborPrc_RegPrc") = decTotalAggLabor
                    R1("LaborPrc_WrtyPrc") = decTotalAggLabor
                    dtLaborInfo.Rows.Add(R1)
                Else
                    If iTierFlat = 1 Then       'Tier
                        If iMaxLaborLevel > 0 Then
                            strSql = "SELECT tlaborprc.LaborLvl_ID AS MaxLaborLvl, tlaborprc.LaborPrc_RegPrc, LaborPrc_WrtyPrc " & Environment.NewLine
                            strSql &= "FROM tpsmap " & Environment.NewLine
                            strSql &= "INNER JOIN tlaborprc ON tpsmap.LaborLvl_ID = tlaborprc.LaborLvl_ID AND PrcGroup_ID = " & RDeviceInfo("PricingGroup") & " AND ProdGrp_ID =  " & RDeviceInfo("ProductGroup") & " " & Environment.NewLine
                            strSql &= "WHERE  tpsmap.Model_ID = " & RDeviceInfo("Model_ID") & Environment.NewLine
                            strSql &= "AND tpsmap.LaborLvl_ID = " & iMaxLaborLevel & ";"
                        Else
                            strSql = "SELECT MAX(tlaborprc.LaborLvl_ID) AS MaxLaborLvl, tlaborprc.LaborPrc_RegPrc, LaborPrc_WrtyPrc " & Environment.NewLine
                            strSql &= "FROM tdevicebill_560 " & Environment.NewLine
                            strSql &= "INNER JOIN lbillcodes ON tdevicebill_560.BillCode_ID = lbillcodes.BillCode_ID " & Environment.NewLine
                            strSql &= "INNER JOIN tpsmap ON tdevicebill.billcode_id = tpsmap.billcode_id AND tpsmap.Model_ID = " & RDeviceInfo("Model_ID") & Environment.NewLine
                            strSql &= "INNER JOIN tlaborprc ON tpsmap.LaborLvl_ID = tlaborprc.LaborLvl_ID AND PrcGroup_ID = " & RDeviceInfo("PricingGroup") & " AND ProdGrp_ID =  " & RDeviceInfo("ProductGroup") & " " & Environment.NewLine
                            strSql &= "WHERE tdevicebill_560.device_id = " & RDeviceInfo("Device_ID") & " " & Environment.NewLine
                            strSql &= "AND lbillcodes.BillType_ID = 2 " & Environment.NewLine  'Part
                            strSql &= "GROUP BY tlaborprc.LaborLvl_ID;"
                        End If
                        objMisc._SQL = strSql
                        dtLaborInfo = objMisc.GetDataTable
                    Else        'Flat
                        'Get Max AB labor level
                        If iMaxLaborLevel = 0 Then
                            iMaxLaborLevel = Me.GetMax_ABLaborLvl_OfDevice(RDeviceInfo("Device_ID"))
                        End If

                        'Get labor level and labor charge for flat ProductGroup
                        strSql = "SELECT tlaborprc.LaborLvl_ID AS MaxLaborLvl, tlaborprc.LaborPrc_RegPrc, LaborPrc_WrtyPrc " & Environment.NewLine
                        strSql &= "FROM tlaborprc  " & Environment.NewLine
                        strSql &= "WHERE PrcGroup_ID = " & RDeviceInfo("PricingGroup") & " " & Environment.NewLine
                        strSql &= "AND ProdGrp_ID =  " & RDeviceInfo("ProductGroup") & " " & Environment.NewLine
                        strSql &= "ORDER BY tlaborprc.LaborLvl_ID DESC;"
                        objMisc._SQL = strSql
                        dtLaborInfo = objMisc.GetDataTable
                        If dtLaborInfo.Rows.Count > 0 Then
                            dtLaborInfo.Rows(0)("MaxLaborLvl") = iMaxLaborLevel
                            dtLaborInfo.AcceptChanges()
                        End If
                    End If  'Tier/Flat
                End If  'Aggregate

                Return dtLaborInfo
            Catch ex As Exception
                Throw ex
            Finally
                objBilling = Nothing
                objGen = Nothing
                R1 = Nothing
                If Not IsNothing(dtPO) Then
                    dtPO.Dispose()
                    dtPO = Nothing
                End If
                If Not IsNothing(dtAggBillcode) Then
                    dtAggBillcode.Dispose()
                    dtAggBillcode = Nothing
                End If
            End Try
        End Function

        '***************************************************************************
        Public Function GetMax_ABLaborLvl_OfDevice(ByVal iDevice_ID As Integer) As Integer
            Dim strSql As String = ""
            Dim dt1 As DataTable
            Dim iMaxLaborLevel As Integer = 0

            Try
                '**********************************
                'Get Maximum AB Labor Level
                '**********************************
                strSql = "SELECT max(tpsmap.LaborLvl_ID) as MaxLaborLevel " & Environment.NewLine
                strSql &= "FROM tdevice " & Environment.NewLine
                strSql &= "INNER JOIN tdevicebill_560 on tdevice.device_id = tdevicebill_560.device_id " & Environment.NewLine
                strSql &= "INNER JOIN tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill_560.billcode_id = tpsmap.billcode_id " & Environment.NewLine
                strSql &= "WHERE tdevice.device_id = " & iDevice_ID & ";"

                objMisc._SQL = strSql
                dt1 = objMisc.GetDataTable

                If dt1.Rows.Count > 0 Then
                    If Not IsDBNull(dt1.Rows(0)("MaxLaborLevel")) Then
                        iMaxLaborLevel = dt1.Rows(0)("MaxLaborLevel")
                    End If
                End If

                Return iMaxLaborLevel
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************

    End Class
End Namespace