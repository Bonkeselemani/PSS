Imports PSS.Core
Imports PSS.Data
Imports Microsoft.Data.Odbc

Namespace Gui.Receiving

    Module General

        Public FieldCollection As Control.ControlCollection()
        Private dsState, dsCountry As DataSet

#Region "Date Formats"

        Public Function FormatDate(ByVal valStartDate As Date) As String

            FormatDate = ""

            Dim vMnth As String
            Dim vDay As String
            Dim vYear As String

            Dim vHour As String
            Dim vMinute As String
            Dim vSecond As String

            Dim valDate As Date
            valDate = valStartDate

            vMnth = DatePart(DateInterval.Month, valDate)
            vDay = DatePart(DateInterval.Day, valDate)
            If Len(vDay) < 2 Then vDay = "0" & vDay
            If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            vYear = DatePart(DateInterval.Year, valDate)

            vHour = DatePart(DateInterval.Hour, valDate)
            vMinute = DatePart(DateInterval.Minute, valDate)
            vSecond = DatePart(DateInterval.Second, valDate)

            FormatDate = vYear & "-" & vMnth & "-" & vDay & " " & vHour & ":" & vMinute & ":" & vSecond

        End Function

        Public Function FormatDateShort(ByVal valStartDate As Date) As String

            FormatDateShort = ""

            Dim vMnth As String
            Dim vDay As String
            Dim vYear As String


            Dim valDate As Date
            valDate = valStartDate

            vMnth = DatePart(DateInterval.Month, valDate)
            vDay = DatePart(DateInterval.Day, valDate)
            If Len(vDay) < 2 Then vDay = "0" & vDay
            If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            vYear = DatePart(DateInterval.Year, valDate)


            FormatDateShort = vYear & "-" & vMnth & "-" & vDay

        End Function

#End Region

#Region "Auditing Methods"

        Public Sub AuditCall(ByVal strCall As String, ByVal ID As Int32, ByVal colControls As System.Windows.Forms.Control.ControlCollection)

            Dim xCount, AuditID As Integer
            Dim tAuditConn As New PSS.Data.Production.Generic()
            Dim dtAudit As DataTable = readAudit(strCall, tAuditConn)
            Dim r As DataRow
            Dim rOld As DataRow
            Dim recUser As String

            Dim tmpUser As String = PSS.Core.[Global].ApplicationUser.User
            recUser = tmpUser

            Dim AuditOldSource, AuditOLDID As String

            For xCount = 0 To dtAudit.Rows.Count - 1
                r = dtAudit.Rows(xCount)
                AuditID = r("Audit_ID")
                AuditOldSource = r("Audit_OLDsource")
                AuditOLDID = r("Audit_OLDID")
            Next

            If AuditID < 1 Then
                MsgBox("AuditID could not be determined. Exiting...")
                Exit Sub
            End If

            '//Get the datarow of old information that is about to be modified
            Dim tbOldSource As New PSS.Data.Production.Joins()
            Dim dtOLD As DataTable = tbOldSource.GenericSelect("SELECT * from " & AuditOldSource & " WHERE " & AuditOLDID & " = " & ID)

            Dim fieldVal, fieldValOLD, fieldValOLDID As String
            '//Get a listing of fields for audit type
            Dim dtfields As DataTable = readFields(AuditID, tAuditConn)
            Dim tmpCount As Integer

            Dim auditProc As Int32 = tAuditConn.idTrans("INSERT INTO audit.tauditproc(audit_Name, audit_User, audit_Date) VALUES ('" & strCall & "', '" & recUser & "','" & FormatDate(Now) & "')", "audit.tauditproc")

            For xCount = 0 To dtfields.Rows.Count - 1
                r = dtfields.Rows(xCount)
                '//Get the Field Name
                If IsDBNull(readCollection(ID, r("Field_Name"), colControls)) = False Then
                    fieldVal = CStr(readCollection(ID, r("Field_Name"), colControls))
                Else
                    fieldVal = ""
                End If
                '//Read old values
                For tmpCount = 0 To dtOLD.Rows.Count - 1
                    rOld = dtOLD.Rows(tmpCount)
                    Try
                        If IsDBNull(rOld(r("Field_NameOLD"))) = False Then
                            fieldValOLD = CStr(rOld(r("Field_NameOLD")))
                        Else
                            fieldValOLD = ""
                        End If
                    Catch exp As Exception
                        MsgBox(exp.ToString)
                    End Try
                    fieldValOLDID = CStr(rOld(AuditOLDID))
                Next
                '//Insert Detail Record
                If Trim(fieldVal) <> Trim(fieldValOLD) Then
                    Dim auditProcDetail As Boolean = tAuditConn.GenericInsert("INSERT INTO audit.tauditprocdetail(auditproc_field, auditproc_old, auditproc_new, auditproc_Date, auditproc_Table, audit_procID, audit_oldIDName, audit_oldIDValue) VALUES ('" & r("Field_NameOLD") & "', '" & fieldValOLD & "','" & fieldVal & "', '" & FormatDate(Now) & "','" & AuditOldSource & "', " & auditProc & ", '" & AuditOLDID & "', '" & fieldValOLDID & "')")
                    If auditProcDetail = False Then MsgBox("ERROR")
                End If
            Next

        End Sub

        Public Sub AuditCall(ByVal strCall As String, ByVal ID As Int32, ByVal ID2 As Int32, ByVal colControls As System.Windows.Forms.Control.ControlCollection)

            Dim xCount, AuditID As Integer
            Dim tAuditConn As New PSS.Data.Production.Generic()
            Dim dtAudit As DataTable = readAudit(strCall, tAuditConn)
            Dim r As DataRow
            Dim rOld As DataRow
            Dim recUser As String

            Dim tmpUser As String = PSS.Core.[Global].ApplicationUser.User
            recUser = tmpUser

            Dim AuditOldSource, AuditOLDID, AuditOLDID2 As String

            For xCount = 0 To dtAudit.Rows.Count - 1
                r = dtAudit.Rows(xCount)
                AuditID = r("Audit_ID")
                AuditOldSource = r("Audit_OLDsource")
                AuditOLDID = r("Audit_OLDID")
                AuditOLDID2 = r("Audit_OLDIDsecond")
            Next

            If AuditID < 1 Then
                MsgBox("AuditID could not be determined. Exiting...")
                Exit Sub
            End If

            '//Get the datarow of old information that is about to be modified
            Dim tbOldSource As New PSS.Data.Production.Joins()
            Dim dtOLD As DataTable = tbOldSource.GenericSelect("SELECT * from " & AuditOldSource & " WHERE " & AuditOLDID & " = " & ID & " And " & AuditOLDID2 & " = " & ID2)
            Dim fieldVal, fieldValOLD, fieldValOLD2, fieldValOLDID, fieldValOLDID2 As String
            '//Get a listing of fields for audit type
            Dim dtfields As DataTable = readFields(AuditID, tAuditConn)
            Dim tmpCount As Integer

            Dim auditProc As Int32 = tAuditConn.idTrans("INSERT INTO audit.tauditproc(audit_Name, audit_User, audit_Date) VALUES ('" & strCall & "', '" & recUser & "','" & FormatDate(Now) & "')", "tauditproc")

            For xCount = 0 To dtfields.Rows.Count - 1
                r = dtfields.Rows(xCount)
                '//Get the Field Name
                If IsDBNull(readCollection(ID, r("Field_Name"), colControls)) = False Then
                    fieldVal = CStr(readCollection(ID, r("Field_Name"), colControls))
                Else
                    fieldVal = ""
                End If
                '//Read old values
                For tmpCount = 0 To dtOLD.Rows.Count - 1
                    rOld = dtOLD.Rows(tmpCount)
                    Try
                        If IsDBNull(rOld(r("Field_NameOLD"))) = False Then
                            fieldValOLD = CStr(rOld(r("Field_NameOLD")))
                        Else
                            fieldValOLD = ""
                        End If
                        'If IsDBNull(rOld(r("Field_NameOLD2"))) = False Then
                        'fieldValOLD2 = CStr(rOld(r("Field_NameOLD2")))
                        'Else
                        '    fieldValOLD2 = ""
                        'End If
                    Catch exp As Exception
                        MsgBox(exp.ToString)
                    End Try
                    fieldValOLDID = CStr(rOld(AuditOLDID))
                    'fieldValOLDID2 = CStr(rOld(AuditOLDID2))
                Next
                '//Insert Detail Record
                If Trim(fieldVal) <> Trim(fieldValOLD) Then
                    Dim auditProcDetail As Boolean = tAuditConn.GenericInsert("INSERT INTO audit.tauditprocdetail(auditproc_field, auditproc_old, auditproc_new, auditproc_Date, auditproc_Table, audit_procID, audit_oldIDName, audit_oldIDValue) VALUES ('" & r("Field_NameOLD") & "', '" & fieldValOLD & "','" & fieldVal & "', '" & FormatDate(Now) & "','" & AuditOldSource & "', " & auditProc & ", '" & AuditOLDID & "', '" & fieldValOLDID & "')")
                    If auditProcDetail = False Then MsgBox("ERROR")
                End If
            Next

        End Sub

        Public Function readFields(ByVal AuditID As Integer, ByVal tAuditConn As PSS.Data.Production.Generic) As DataTable

            Dim dtFields As DataTable = tAuditConn.GenericSelect("SELECT * FROM audit.tfield WHERE Audit_ID = " & AuditID)
            readFields = dtFields

            dtFields.Dispose()

        End Function

        Public Function readAudit(ByVal strCall As String, ByVal tAuditConn As PSS.Data.Production.Generic) As DataTable

            Dim dtFields As DataTable = tAuditConn.GenericSelect("SELECT * FROM audit.tauditname WHERE Audit_Name = '" & strCall & "'")
            readAudit = dtFields

            dtFields.Dispose()

        End Function

        Public Function readCollection(ByVal ID As Int32, ByVal strField As String, ByVal colControls As System.Windows.Forms.Control.ControlCollection) As String

            Dim x As Integer

            For x = 0 To colControls.Count - 1

                If colControls(x).GetType.ToString = "System.Windows.Forms.GroupBox" Then
                    Dim tValue As String = ""
                    tValue = readCollection(ID, strField, CType(colControls(x), GroupBox).Controls)
                    readCollection = tValue
                    If Len(tValue) > 0 Then Exit Function
                ElseIf colControls(x).GetType.ToString = "System.Windows.Forms.TabControl" Then
                    Dim tValue As String = ""
                    tValue = readCollection(ID, strField, CType(colControls(x), TabControl).Controls)
                    readCollection = tValue
                    If Len(tValue) > 0 Then Exit Function
                ElseIf colControls(x).GetType.ToString = "System.Windows.Forms.TabPage" Then
                    Dim tValue As String = ""
                    tValue = readCollection(ID, strField, CType(colControls(x), TabPage).Controls)
                    readCollection = tValue
                    If Len(tValue) > 0 Then Exit Function
                End If


                If colControls(x).Name.ToString = "CUST_txtLName" Then
                    'MsgBox(colControls(x).Name.ToString)
                End If

                If Trim(colControls(x).Name.ToString) = Trim(strField) Then
                    readCollection = colControls(x).Text.ToString
                End If

            Next

        End Function

#End Region

#Region "FedEx Methods"

        Public Function writeFedEx(ByVal recShip As Long) As Boolean

            writeFedEx = False
fedex:

            '//write data to fedex database
            Dim fxCustName, fCustContact, fxAddress1, fxAddress2, fxCity, fxState As String
            Dim fxZip, fxCountry, fxDateEntered, fxCustPhone As String
            Dim strFedExSQL As String
            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim valLoc As String
            Dim valContact As String
            Dim dtFedex As DataTable
            Dim strcon As String = "DRIVER={Microsoft Access Driver (*.mdb)};dbq=g:\fedextrack.mdb"
            Dim conn As New OdbcConnection(strcon)

            Try
                
                Dim valShipTo As Int32 = 0
                Dim valCust As Int32 = 0
                Dim dtship As New PSS.Data.Production.Joins()
                Dim dtrs As DataTable = dtship.OrderEntrySelect("SELECT * from tship where Ship_ID = " & recShip)
                For xCount = 0 To dtrs.Rows.Count
                    r = dtrs.Rows(xCount)
                    If IsDBNull(r("ShipTo_ID")) = True Then
                        Exit For
                    End If
                    If Trim(r("ShipTo_ID")) > 0 Then
                        valShipTo = Trim(r("ShipTo_ID"))
                        Exit For
                    End If
                Next
                If valShipTo = 0 Then
                    Dim dtLoc As New PSS.Data.Production.Joins()
                    Dim dtLocRS As DataTable
                    dtLocRS = dtLoc.OrderEntrySelect("SELECT * from tdevice where Ship_ID = " & recShip)
                    For xCount = 0 To dtLocRS.Rows.Count
                        r = dtLocRS.Rows(xCount)
                        If Trim(r("Loc_ID")) > 0 Then
                            valLoc = Trim(r("Loc_ID"))
                            'valCust = Trim(r("Cust_ID"))
                            Exit For
                        End If
                    Next
                End If

                Dim valCustName As String

                Dim tblCustomerList As New PSS.Data.Production.Joins()
                Dim dtCustomer As DataTable
                dtCustomer = tblCustomerList.Shipping_CustomerListEndUser

                'If valCust > 0 Then
                Dim drCustomer As DataRow
                For xCount = 0 To dtCustomer.Rows.Count - 1
                    drCustomer = dtCustomer.Rows(xCount)
                    If Trim(drCustomer("Loc_ID")) = valLoc Then
                        valCustName = Trim(drCustomer("Cust_Name1"))
                        If IsDBNull((drCustomer("Cust_Name2"))) = False Then
                            valCustName += " " & Trim(drCustomer("Cust_Name2"))
                        End If
                        Exit For
                    End If
                Next
                'End If


                Dim txtState, txtcountry, strFieldNames, strField As String
                Dim yCount As Integer = 0
                Dim x As DataRow

                '//Get data to be written
                If valShipTo > 0 Then
                    'dtrs = dtship.OrderEntrySelect("SELECT * from tshipto where ShipTo_ID = " & recShip)'July 15, 2003
                    dtrs = dtship.OrderEntrySelect("SELECT * from tshipto where ShipTo_ID = " & valShipTo)
                    For xCount = 0 To dtrs.Rows.Count - 1
                        r = dtrs.Rows(xCount)

                        valCustName = r("ShipTo_Name")
                        valContact = "'Null'"
                        dtrs = dtship.OrderEntrySelect("SELECT * from tlocation where Loc_ID = " & recShip)
                        For yCount = 0 To dtrs.Rows.Count - 1
                            x = dtrs.Rows(yCount)
                            valContact = "'" & x("Loc_Contact") & "'"
                        Next

                        '//Get State
                        txtState = Get_StateText(Trim(r("State_ID")))
                        '//Get Country
                        txtcountry = Get_CountryText(Trim(r("Cntry_ID")))
                        'If Trim(txtcountry) = "United States" Then txtcountry = "US"
                        If Trim(txtcountry) = "USA" Then txtcountry = "US"
                        If Trim(txtcountry) = "Canada" Then txtcountry = "CN"
                        strFieldNames = "(Shipping_ID, Cust_Name, Cust_Address1, Cust_Address2, Cust_City, Cust_State_Prov, Cust_Zip, Cust_Country, Date_Entered, Cust_Contact)"
                        strField = "(" & recShip & ", '" & valCustName & "', '" & r("ShipTo_Address1") & "', '" & r("ShipTo_Address2") & "', '" & r("ShipTo_City") & "', '" & txtState & "', '" & r("ShipTo_Zip") & "', '" & txtcountry & "', '" & Now & "', " & valContact & ")"
                    Next
                End If
                If valLoc > 0 Then
                    dtrs = dtship.OrderEntrySelect("SELECT * from tlocation where Loc_ID = " & valLoc)
                    For xCount = 0 To dtrs.Rows.Count
                        r = dtrs.Rows(xCount)
                        '//Get State
                        txtState = Get_StateText(Trim(r("State_ID")))
                        '//Get Country
                        txtcountry = Get_CountryText(Trim(r("Cntry_ID")))
                        If Trim(txtcountry) = "United States" Then txtcountry = "US"
                        If Trim(txtcountry) = "Canada" Then txtcountry = "CN"
                        strFieldNames = "(Shipping_ID, Cust_Name, Cust_Address1, Cust_Address2, Cust_City, Cust_State_Prov, Cust_Zip, Cust_Country, Date_Entered, Cust_Contact, Cust_Phone)"
                        'Dim valContact As String
                        If IsDBNull(r("Loc_Contact")) = False Then
                            valContact = r("Loc_Contact")
                        Else
                            valContact = valCustName
                        End If
                        Dim valPhone As String
                        If IsDBNull(r("Loc_Phone")) = False Then
                            valPhone = r("Loc_Phone")
                        Else
                            valPhone = "none"
                        End If
                        strField = "(" & recShip & ", '" & valCustName & "', '" & r("Loc_Address1") & "', '" & r("Loc_Address2") & "', '" & r("Loc_City") & "', '" & txtState & "', '" & r("Loc_Zip") & "', '" & txtcountry & "', '" & Now & "', '" & valContact & "', '" & valPhone & "')"
                        Exit For
                    Next
                End If


                Dim cmd As New OdbcCommand("insert into Customer_Info " & strFieldNames & " VALUES " & strField, conn)
                conn.Open()
                cmd.ExecuteNonQuery()

                
                'dtFedex.Dispose()
                'dtrs.Dispose()

            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
                conn.Close()
                conn.Dispose()
            End Try
            '//end write to fedex database

        End Function

#End Region

#Region "State/Country Methods"

        Private Function Get_StateText(ByVal addState As String) As String

            Get_StateText = ""

            '//Get State Value
            Dim tmpCount As Integer = 0
            Dim rState As DataRow

            For tmpCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                rState = dsState.Tables("lstate").Rows(tmpCount)
                If Trim(rState("State_ID")) = addState Then
                    Get_StateText = rState("State_Short")
                    Exit For
                End If
            Next

        End Function

        Private Function Get_CountryText(ByVal addCountry As String) As String

            Get_CountryText = ""

            '//Get Country Value
            Dim tmpCount As Integer = 0
            Dim rCountry As DataRow

            For tmpCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                rCountry = dsCountry.Tables("lcountry").Rows(tmpCount)
                If Trim(rCountry("Cntry_ID")) = addCountry Then
                    Get_CountryText = rCountry("Cntry_Name")
                    Exit For
                End If
            Next

        End Function

#End Region

#Region "SLI Verification Methods"

        Public Function verEntry_SLI(ByVal mDeviceID As Long) As String

            If mDeviceID < 1 Then
                verEntry_SLI = "ERROR: No Device ID"            'If there is no device Id passed in then
                Exit Function                                   'send error back
            End If

            verEntry_SLI = ""

            Dim x As Integer = 0
            Dim r As DataRow
            Dim r1 As DataRow
            Dim tmpAPC As Int32 = 0
            Dim tData As New PSS.Data.Production.Joins()
            Dim tSLI As DataTable
            Dim m1, m3, m4, m5, m6, m9, m10, m11 As Boolean
            Dim vTech As String

            m1 = False
            m3 = False
            m4 = False
            m5 = False
            m6 = False
            m9 = False
            m10 = False
            m11 = False

            verEntry_SLI = ""

            tSLI = tData.GetSLIdata(mDeviceID)

            If tSLI.Rows.Count < 1 Then
                verEntry_SLI = ""   'If there is no device Id passed in then
                Exit Function                                   'send error back
            End If

            r = tSLI.Rows(0)                                    'Get first row data (TCELLOPT)

            If IsDBNull(r("cellopt_CSN")) = True And IsDBNull(r("cellopt_IMEI")) = True Then verEntry_SLI = verEntry_SLI & "No Serial Number Defined." & vbCrLf
            If IsDBNull(r("cellopt_CSN_Dec")) = True Then verEntry_SLI = verEntry_SLI & "No Serial Number Decimal Equivalent Defined." & vbCrLf
            If IsDBNull(r("cellopt_AirCarrCode")) = True Then verEntry_SLI = verEntry_SLI & "No Airtime Carrier Code Defined." & vbCrLf
            If IsDBNull(r("cellopt_AirTime")) = True Then verEntry_SLI = verEntry_SLI & "No AirTime Amount Defined." & vbCrLf

            If IsDBNull(r("cellopt_TechID")) = False Then vTech = r("cellopt_TechID")
            If Len(Trim(vTech)) > 0 Then

                Dim lstTech As New PSS.Data.Production.tusers()
                Dim tmpTech As DataTable = lstTech.GetCellTechList
                Dim rTech As DataRow
                Dim xCount As Integer = 0

                For xCount = 0 To tmpTech.Rows.Count - 1

                    'r = tmpTech.Rows(xCount)   'Commented by Asif
                    r1 = tmpTech.Rows(xCount)    'Added by Asif

                    'Commented by Asif
                    'If vTech = r("tech_id") Then
                    '    vTech = r("user_fullname")
                    '    Exit For
                    'End If

                    'Added by Asif
                    If vTech = r1("tech_id") Then
                        vTech = r1("user_fullname")
                        Exit For
                    End If
                Next
            Else
                vTech = "???"
            End If


            If IsDBNull(r("cellopt_AirTime")) = False Then
                Try
                    Dim tAirtime As Long = CLng(r("cellopt_AirTime"))
                Catch ex As Exception
                    verEntry_SLI = verEntry_SLI & "AirTime Must be Integer Value (Time in Minutes)." & vbCrLf
                End Try
            End If

            If IsDBNull(r("cellopt_Complaint")) = True Then verEntry_SLI = verEntry_SLI & "No Complaint Defined." & vbCrLf
            If IsDBNull(r("cellopt_SoftVerIN")) = True Then verEntry_SLI = verEntry_SLI & "No Software Version IN Defined." & vbCrLf
            If IsDBNull(r("cellopt_SoftVerOUT")) = True Then verEntry_SLI = verEntry_SLI & "No Software Version OUT Defined." & vbCrLf
            If IsDBNull(r("cellopt_DateCode")) = True Then verEntry_SLI = verEntry_SLI & "No Date Code Defined." & vbCrLf
            If IsDBNull(r("cellopt_Transceiver")) = True Then verEntry_SLI = verEntry_SLI & "No Transceiver Defined." & vbCrLf

            For x = 0 To tSLI.Rows.Count - 1                    'Get remaining data (TDEVICECODES)
                'r = tSLI.Rows(x)
                'If (r("dcode_id")) > 0 Then
                '    If r("mcode_id") = 1 Then m1 = True
                '    If r("mcode_id") = 3 Then m3 = True
                '    If r("mcode_id") = 4 Then m4 = True
                '    If r("mcode_id") = 5 Then m5 = True
                '    If r("mcode_id") = 6 Then
                '        m6 = True
                '        tmpAPC = r("dcode_id")
                '    End If
                '    If r("mcode_id") = 9 Then m9 = True
                '    If r("mcode_id") = 10 Then m10 = True
                '    If r("mcode_id") = 11 Then m11 = True
                'End If

                r1 = tSLI.Rows(x)
                If (r1("dcode_id")) > 0 Then
                    If r1("mcode_id") = 1 Then m1 = True
                    If r1("mcode_id") = 3 Then m3 = True
                    If r1("mcode_id") = 4 Then m4 = True
                    If r1("mcode_id") = 5 Then m5 = True
                    If r1("mcode_id") = 6 Then
                        m6 = True
                        tmpAPC = r1("dcode_id")
                    End If
                    If r1("mcode_id") = 9 Then m9 = True
                    If r1("mcode_id") = 10 Then m10 = True
                    If r1("mcode_id") = 11 Then m11 = True
                End If
            Next

            '//Get APC Type
            Try
                If tmpAPC > 0 Then
                    Dim rAPC As DataRow = PSS.Data.Production.lcodesdetail.GetAPCvalue(tmpAPC)
                    If Trim(rAPC("Dcode_L2desc")) = "GSM/PCS" Then
                        If IsDBNull(r("cellopt_MSN")) = True Then verEntry_SLI = verEntry_SLI & "No MSN Defined." & vbCrLf
                    End If
                End If
            Catch ex As Exception
            End Try

            Dim dtBill As DataTable = PSS.Data.Production.Joins.GetSLIdataBILL(mDeviceID)

            For x = 0 To dtBill.Rows.Count - 1                    'Get remaining data (TDEVICECODES)
                'Commented by Asif
                'r = dtBill.Rows(x)
                'If (r("dcode_id")) > 0 Then
                '    If r("mcode_id") = 1 Then m1 = True
                '    If r("mcode_id") = 3 Then m3 = True
                '    If r("mcode_id") = 4 Then m4 = True
                '    If r("mcode_id") = 5 Then m5 = True
                '    If r("mcode_id") = 6 Then m6 = True
                '    If r("mcode_id") = 9 Then m9 = True
                '    If r("mcode_id") = 10 Then m10 = True
                '    If r("mcode_id") = 11 Then m11 = True
                'End If

                'Added by Asif
                r1 = dtBill.Rows(x)
                If (r1("dcode_id")) > 0 Then
                    If r1("mcode_id") = 1 Then m1 = True
                    If r1("mcode_id") = 3 Then m3 = True
                    If r1("mcode_id") = 4 Then m4 = True
                    If r1("mcode_id") = 5 Then m5 = True
                    If r1("mcode_id") = 6 Then m6 = True
                    If r1("mcode_id") = 9 Then m9 = True
                    If r1("mcode_id") = 10 Then m10 = True
                    If r1("mcode_id") = 11 Then m11 = True
                End If
            Next


            If m1 = False Then verEntry_SLI = verEntry_SLI & "No Carrier Code Defined." & vbCrLf
            If m3 = False Then verEntry_SLI = verEntry_SLI & "No Repair Action Defined." & vbCrLf
            If m4 = False Then verEntry_SLI = verEntry_SLI & "No Failure Code Defined." & vbCrLf
            If m5 = False Then verEntry_SLI = verEntry_SLI & "No Complaint Code Defined." & vbCrLf
            If m6 = False Then verEntry_SLI = verEntry_SLI & "No APC Code Defined." & vbCrLf
            If m9 = False Then verEntry_SLI = verEntry_SLI & "No Problem Found Code Defined." & vbCrLf
            If m10 = False Then verEntry_SLI = verEntry_SLI & "No Repair Status." & vbCrLf
            If m11 = False Then verEntry_SLI = verEntry_SLI & "No Reference Designator Code Defined." & vbCrLf

            tSLI.Dispose()
            tData = Nothing

            If Len(verEntry_SLI) > 0 Then verEntry_SLI = "Technician " & vTech & " has not completed screen processing." & vbCrLf & "The following field(s) need to be addressed." & vbCrLf & vbCrLf & verEntry_SLI

            Return verEntry_SLI

        End Function

        Public Function convertAirTime(ByVal vAirTime As String) As String

            convertAirTime = ""
            
            Try
                '/Convert over time to minutes
                Dim vHour As Integer
                Dim vMinute As Integer
                Dim tmpStr As String
                Dim intH, intM, ttlM As Integer
                intH = InStr(vAirTime, "-")
                vHour = Mid$(vAirTime, 1, intH - 1)
                intM = InStr(Mid$(vAirTime, intH + 1), "-")
                vMinute = Mid$(Mid$(vAirTime, intH + 1), 1, intM - 1)
                If vMinute > 59 Then vMinute = 59
                convertAirTime = (vHour * 60) + vMinute
            Catch ex As Exception
            End Try

        End Function



#End Region

    End Module

End Namespace
