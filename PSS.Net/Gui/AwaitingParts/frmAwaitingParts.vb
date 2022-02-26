Public Class frmAwaitingParts
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lblTray As System.Windows.Forms.Label
    Friend WithEvents txtTray As System.Windows.Forms.TextBox
    Friend WithEvents lblRef As System.Windows.Forms.Label
    Friend WithEvents btnRecall As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblTray = New System.Windows.Forms.Label()
        Me.txtTray = New System.Windows.Forms.TextBox()
        Me.lblRef = New System.Windows.Forms.Label()
        Me.btnRecall = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(168, 8)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(208, 32)
        Me.lblModel.TabIndex = 0
        Me.lblModel.Text = "Model:"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pnlBill
        '
        Me.pnlBill.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlBill.AutoScroll = True
        Me.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBill.Location = New System.Drawing.Point(16, 64)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(608, 208)
        Me.pnlBill.TabIndex = 0
        '
        'btnClear
        '
        Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnClear.Location = New System.Drawing.Point(552, 8)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Clear"
        '
        'lblTray
        '
        Me.lblTray.Location = New System.Drawing.Point(8, 8)
        Me.lblTray.Name = "lblTray"
        Me.lblTray.Size = New System.Drawing.Size(40, 16)
        Me.lblTray.TabIndex = 15
        Me.lblTray.Text = "Tray:"
        Me.lblTray.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTray
        '
        Me.txtTray.Location = New System.Drawing.Point(56, 4)
        Me.txtTray.Name = "txtTray"
        Me.txtTray.TabIndex = 1
        Me.txtTray.Text = ""
        '
        'lblRef
        '
        Me.lblRef.Location = New System.Drawing.Point(384, 8)
        Me.lblRef.Name = "lblRef"
        Me.lblRef.Size = New System.Drawing.Size(112, 16)
        Me.lblRef.TabIndex = 0
        Me.lblRef.Text = "Ref:"
        Me.lblRef.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnRecall
        '
        Me.btnRecall.Location = New System.Drawing.Point(56, 32)
        Me.btnRecall.Name = "btnRecall"
        Me.btnRecall.Size = New System.Drawing.Size(104, 23)
        Me.btnRecall.TabIndex = 16
        Me.btnRecall.Text = "Reference"
        '
        'frmAwaitingParts
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(632, 277)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRecall, Me.lblRef, Me.txtTray, Me.lblTray, Me.btnClear, Me.pnlBill, Me.lblModel})
        Me.Name = "frmAwaitingParts"
        Me.Text = "frmAwaitingParts"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private pnlLeft As Integer
    Private pnlWidthTMP As Integer
    Private pnlWidth As Integer
    Private gridLeft As Integer
    Private gridWidth As Integer
    Private btnLeft As Int32 = 5
    Private btnTop As Int32 = 5
    Private Const vBuffer As Integer = 5
    Private Const hBuffer As Integer = 20
    Private Const btnWidth = 120
    Private Const btnHeight = 50

    Private dtElem As PSS.Data.Production.Joins
    Private mTrayID As Long
    Private mTrayID_OLD As Long

    Private mModelID_OLD As Long = 0
    Private mReference As String
    Private mModelID As Long

    Private flagNewRef As Boolean = False
    Private flagMultiTrayChange As Boolean = False
    Private flagCanDelete As Boolean = False

    Private dtMulti As DataTable = Nothing


    Private Sub frmAwaitingParts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtTray.Text = ""
        txtTray.Focus()

    End Sub

    Private Sub CleanForm()
        Me.pnlBill.Controls.Clear()
        lblModel.Visible = False
        lblModel.Text = ""
        lblRef.Visible = False
        lblRef.Text = ""
        txtTray.Text = ""
        txtTray.Focus()
        flagNewRef = False
        flagMultiTrayChange = False
        flagCanDelete = False

        '//Move modelID to old
        If mModelID > 0 Then
            mModelID_OLD = mModelID
            mModelID = 0
        Else
            '//Do not get rid of last valid model id
        End If

        If mTrayID > 0 Then
            mTrayID_OLD = mTrayID
            mTrayID = 0
        Else
            '//Do not get rid of last valid tray id
        End If

    End Sub

    Private Function GetModelID(ByVal mTrayID As Long) As Long
        Try
            Dim strSQL As String = "SELECT * FROM tdevice WHERE Tray_ID = " & mTrayID
            Dim dt As DataTable = dtElem.OrderEntrySelect(strSQL)
            Dim r As DataRow = dt.Rows(0)
            Return r("Model_ID")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function GetModelDesc(ByVal mModelID As Long) As String
        Dim strSQL As String = "SELECT * FROM tmodel WHERE Model_ID = " & mModelID
        Dim dt As DataTable = dtElem.OrderEntrySelect(strSQL)
        Dim r As DataRow = dt.Rows(0)
        Return r("Model_Desc")
    End Function

    Private Sub createPartButtons(ByVal mModelID As Long)

        System.Windows.Forms.Application.DoEvents()

        Dim colCount As Integer = 0

        pnlLeft = pnlBill.Left
        pnlWidth = pnlBill.Width
        gridLeft = pnlBill.Left
        gridWidth = pnlBill.Width

        Dim btnTop As Integer = 5
        Dim ds As PSS.Data.Production.Joins

        System.Windows.Forms.Application.DoEvents()
        '//August 22, 2005 - Added BillType_ID = 2 to strSQL listed below
        Dim strSQL As String = "SELECT distinct lpsprice.psprice_id, lpsprice.psprice_number, lpsprice.psprice_desc, tpsmap.model_id from tpsmap INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id inner join lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id WHERE tpsmap.model_ID = " & mModelID & " AND lbillcodes.billcode_rule < 1 AND BillType_ID = 2 ORDER BY lpsprice.psprice_number"
        Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
        System.Windows.Forms.Application.DoEvents()

        colCount = 0
        Dim cBill() As Button

        ReDim cBill(dt.Rows.Count)

        '//This will get already selected values to be made blue
        Dim ds1 As PSS.Data.Production.Joins
        Dim dt1 As DataTable = ds1.OrderEntrySelect("SELECT PSPrice_ID FROM tawaitingparts WHERE Tray_ID = " & mTrayID & " ORDER BY PSPrice_id DESC")
        '//This will get already selected values to be made blue

        Dim x As Integer = 0
        Dim y As Integer = 0

        Dim r, ry As DataRow

        For x = 0 To dt.Rows.Count - 1
            r = dt.Rows(x)
            cBill(x) = New System.Windows.Forms.Button()
            With cBill(x)

                For y = 0 To dt1.Rows.Count - 1
                    ry = dt1.Rows(y)
                    If ry("PSPrice_ID") = r("PSPrice_ID") Then
                        .ForeColor = Color.Blue()
                    End If
                Next

                .Text = r("PSPrice_Number") & vbCrLf & r("PSPrice_Desc")
                .Size = New Size(120, 50)
                .Location = New Point(btnLeft, btnTop)
                .Visible = True
                .Tag = r("PSPrice_ID")
                AddHandler .Click, AddressOf displayClick
                btnTop += 5
            End With

            colCount += 1
            If colCount > 5 Then
                btnLeft = btnLeft + btnWidth + 5
                btnTop = vBuffer
                colCount = 0
            Else
                btnTop = btnTop + btnHeight + 5
            End If

        Next

        Me.pnlBill.Controls.AddRange(cBill)

        System.Windows.Forms.Application.DoEvents()

        btnLeft = 5
        btnTop = 5

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        CleanForm()
    End Sub

    Private Sub txtTray_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTray.KeyDown
        If e.KeyValue = 13 Then

            '//Acquire data for form
            mTrayID = (Trim(txtTray.Text))
            mModelID = GetModelID(mTrayID)
            System.Windows.Forms.Application.DoEvents() '//Pause until ModelID is assigned

            '//Check to see if model id was same as old. If so then place buffered elements onto page
            If mModelID = mModelID_OLD Then


                '//ReUse Elements
                flagNewRef = False
                flagMultiTrayChange = False
                '//Remove original elements
                If mTrayID <> mTrayID_OLD Then
                    Dim blnReset As Boolean = dtElem.OrderEntryUpdateDelete("DELETE FROM tawaitingparts WHERE tray_id = " & mTrayID)
                    '//Remove original elements

                    Dim dtPSPrice As DataTable = dtElem.OrderEntrySelect("SELECT PSPrice_ID FROM tawaitingparts WHERE tray_id = " & mTrayID_OLD)
                    Dim dtCount As Integer = 0
                    Dim dtr As DataRow


                    For dtCount = 0 To dtPSPrice.Rows.Count - 1
                        dtr = dtPSPrice.Rows(dtCount)
                        Dim blnRep As Boolean = dtElem.OrderEntryUpdateDelete("REPLACE INTO tawaitingparts(Tray_ID, PSPRice_ID, AP_RefNo, AP_EntryDate) VALUES (" & mTrayID & ", " & dtr("PSPRice_ID") & ", '" & Trim(UCase(mReference)) & "', '" & Gui.Receiving.FormatDate(Now) & "')")
                    Next
                    System.Windows.Forms.Application.DoEvents()
                End If

            Else

                '//Remove Elements
                '//See if reference exists for existing tray
                Dim dtRef As DataTable = dtElem.OrderEntrySelect("SELECT AP_RefNo FROM tawaitingparts WHERE Tray_ID = " & mTrayID)
                Dim rRef As DataRow
                If dtRef.Rows.Count > 0 Then


                    '//August 18 commented out to prevent reuse of refnumber
                    rRef = dtRef.Rows(0)
                    mReference = Trim(UCase(rRef("AP_RefNo")))
                    lblRef.Text = mReference
                    If mModelID_OLD > 0 Then
                        MsgBox("This reference can not be used because it is reserved by other tray(s). Please use a different reference number.", MsgBoxStyle.Information, "INVALID REF NUMBER")
                        mReference = getReference()
                    End If
                    '//August 18 commented out to prevent reuse of refnumber


                    '//Get data for form
                Else
getRefNum:
                    mReference = ""
                    mReference = getReference()
                    Dim blnGood As Boolean = Me.checkGoodReferenceNumber(mReference)
                    flagNewRef = True
                    If blnGood = False Then
                        '//Get Model number for original reference
                        Dim refDT As DataTable = dtElem.OrderEntrySelect("SELECT distinct model_id from tdevice WHERE tray_id = " & mTrayID)
                        Dim refRow As DataRow = refDT.Rows(0)
                        If Trim(mModelID) <> Trim(refRow("Model_ID")) Then
                            MsgBox("This Reference Number is being used by another model. Please try again.", MsgBoxStyle.Critical)
                            flagNewRef = False
                            GoTo getRefNum
                        End If
                    End If
                End If
                End If
            '//**************************************************

            If mModelID = 0 Then
                MsgBox("The tray/model could not be obtained. Please contact IT.", MsgBoxStyle.Critical, "ERROR")
                CleanForm()
                Exit Sub
            End If
            Dim mModelDesc As String = GetModelDesc(mModelID)
            System.Windows.Forms.Application.DoEvents() '//Pause until ModelID is assigned
            lblModel.Visible = True
            lblModel.Text = "Model: " & UCase(mModelDesc)
            lblRef.Visible = True
            lblRef.Text = "Ref: " & UCase(mReference)
            System.Windows.Forms.Application.DoEvents()

            Dim xForm As New Gui.NoteBoard.frmNoteBoard("Compiling Information")
            xForm.ShowDialog()


            createPartButtons(mModelID)
        End If
    End Sub

    Private Sub displayClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If flagNewRef = False Then
            Dim intResponse As Integer = AlterState()
            If intResponse = 3 Then Exit Sub
            'If intResponse = 1 Then MsgBox("Update all past data")
            'If intResponse = 2 Then MsgBox("Get new Reference number")
        End If

        Dim xCount As Integer = 0
        Dim rMulti As DataRow

        Dim vDataID As Integer = sender.tag.ToString
        Dim vDataName As String = sender.text.ToString

        '//Check to see if OK for assignment
        If Len(Trim(vDataID)) < 1 Or Len(Trim(vDataName)) < 1 Then
            MsgBox("Corruption to data. Exiting", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        '//Read for old value
        Dim vNow As String = Gui.Receiving.FormatDate(Now)

        Dim ds As PSS.Data.Production.Joins
        Dim dt As DataTable = ds.OrderEntrySelect("SELECT PSPrice_ID FROM tawaitingparts WHERE tray_id = " & mTrayID & " AND PSPrice_ID = " & vDataID & " ORDER BY PSPrice_id DESC")
        Dim r As DataRow
        If dt.Rows.Count < 1 Then
            '//Insert record

            If flagNewRef = False Then
                Dim strNewRef As String
                strNewRef = InputBox("Insert New Reference Number", "Change", Trim(UCase(mReference)))
                If Trim(UCase(strNewRef)) = Trim(UCase(mReference)) Then
                    Dim strRes As String
                    strRes = MsgBox("You will be replacing all items referenced " & mReference & " to a new grouping, continue?", MsgBoxStyle.YesNo)
                    If strRes = "Yes" Then
                        '//Continue and reassign
                    Else
                        '//Error out
                    End If
                End If

            End If



            If flagMultiTrayChange = True Then
                For xCount = 0 To dtMulti.Rows.Count - 1
                    rMulti = dtMulti.Rows(xCount)
                    Dim blnInsert As Boolean = ds.OrderEntryUpdateDelete("INSERT INTO tawaitingparts (Tray_ID, PSPrice_ID, AP_EntryDate, AP_RefNo) VALUES (" & rMulti("Tray_ID") & ", " & vDataID & ", '" & vNow & "', '" & Trim(UCase(mReference)) & "')")
                    System.Windows.Forms.Application.DoEvents()
                    sender.forecolor = Color.Blue
                Next
                Exit Sub
            Else
                Dim blnInsert As Boolean = ds.OrderEntryUpdateDelete("INSERT INTO tawaitingparts (Tray_ID, PSPrice_ID, AP_EntryDate, AP_RefNo) VALUES (" & mTrayID & ", " & vDataID & ", '" & vNow & "', '" & Trim(UCase(mReference)) & "')")
                System.Windows.Forms.Application.DoEvents()
                sender.forecolor = Color.Blue
                Exit Sub
            End If
        Else
            '//Delete Record

            If flagCanDelete = False Then
                checkDelete()
                System.Windows.Forms.Application.DoEvents()
            End If

            If flagCanDelete = False Then
                MsgBox("Password Incorrect! You do not have access to delete items from this screen.")
                Exit Sub
            End If

            If flagMultiTrayChange = True Then
                For xCount = 0 To dtMulti.Rows.Count - 1
                    rMulti = dtMulti.Rows(xCount)
                    Dim blnDelete As Boolean = ds.OrderEntryUpdateDelete("DELETE FROM tawaitingparts WHERE Tray_ID = " & rMulti("Tray_ID") & " AND PSPrice_ID = " & vDataID)
                    System.Windows.Forms.Application.DoEvents()
                    sender.forecolor = Color.Black
                Next
                Exit Sub
            Else
                Dim blnDelete As Boolean = ds.OrderEntryUpdateDelete("DELETE FROM tawaitingparts WHERE Tray_ID = " & mTrayID & " AND PSPrice_ID = " & vDataID)
                System.Windows.Forms.Application.DoEvents()
                Dim x As Integer = 0
                sender.forecolor = Color.Black
            End If
        End If

    End Sub

    Private Function getReference() As String
ReRunReference:
        Dim strReturn As String
        strReturn = InputBox("Enter Reference Value", "INPUT")
        If Trim(strReturn) = "" Then
            GoTo rerunreference
        Else
            Return Trim(UCase(strReturn))
        End If
    End Function





    Private Function checkGoodReferenceNumber(ByVal mRef As String) As Boolean
        Dim strSQL As String
        strSQL = "SELECT * FROM tawaitingparts WHERE AP_RefNo = '" & Trim(mRef) & "'"
        Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect(strSQL)
        If dt.Rows.Count > 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Private Function getMultiDT() As DataTable
        getMultiDT = dtElem.OrderEntrySelect("SELECT distinct Tray_ID FROM tawaitingparts WHERE AP_RefNo = '" & mReference & "'")
        System.Windows.Forms.Application.DoEvents()
        flagMultiTrayChange = True
        flagNewRef = True
        Return getMultiDT
    End Function

    Private Function AlterState() As Integer
        Dim strAnswer, strAnswer2 As String
        strAnswer = MsgBox("Do you want to change all trays with the reference to the new definition?", MsgBoxStyle.YesNo)
        Select Case strAnswer
            Case vbYes
                dtMulti = getMultiDT()
                'MsgBox(dtMulti.Rows.Count)
                Return 1
            Case vbNo
                strAnswer2 = MsgBox("Do you want to assign a new reference number?", MsgBoxStyle.YesNo)
                Select Case strAnswer2
                    Case vbYes
                        setNewReference()
                        flagCanDelete = True
                        Return 2
                    Case vbNo
                        MsgBox("User Cancelled")
                        Return 3
                End Select
        End Select


    End Function







    Private Function setNewReference() As Boolean

        setNewReference = False

        Dim strRef As String
ReEnterRef:
        strRef = getReference()
        System.Windows.Forms.Application.DoEvents()
        Dim dt As DataTable = dtElem.OrderEntrySelect("SELECT * FROM tawaitingparts WHERE AP_RefNo = '" & strRef & "'")
        System.Windows.Forms.Application.DoEvents()

        If dt.Rows.Count > 0 Then
            MsgBox("This reference is not valid. It is already being used. Please try again", MsgBoxStyle.OKOnly)
            GoTo reenterref
        End If

        Dim strSQL As String
        '//Update tawaitingparts to reflect change
        If mTrayID > 0 Then
            strSQL = "UPDATE tawaitingparts SET AP_RefNo = '" & Trim(UCase(strRef)) & "' WHERE Tray_ID = " & mTrayID
            Dim blnDT As Boolean = dtElem.OrderEntryUpdateDelete(strSQL)
        Else
            MsgBox("the tray can not be determined. Please contact IT.", MsgBoxStyle.Critical, "ERROR")
            Exit Function
        End If

        mReference = Trim(UCase(strRef))
        lblRef.Text = Trim(UCase(strRef))

        flagNewRef = True

        Return True

    End Function

    Private Sub lblRef_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblRef.Click
        Exit Sub
        MsgBox("All items will be deselected for this tray.")
    End Sub

    Private Sub checkDelete()
        Dim strVal As String
        strVal = InputBox("Delete function is password protected. Enter password:", "PASSWORD")
        If UCase(strVal) = "MIAMI" Then
            flagCanDelete = True
        Else
            flagCanDelete = False
        End If
    End Sub

    Private Sub txtTray_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTray.TextChanged

    End Sub

    Private Sub HotKeysF12(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtTray.KeyDown, txtTray.KeyDown, btnClear.KeyDown
        If e.KeyCode = Keys.F12 Or e.KeyCode = Keys.F2 Then
            CleanForm()
        End If

    End Sub

    Private Sub btnRecall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecall.Click


        Dim vRef As String = InputBox("Enter Ref No ", "Get Reference")

        If Len(Trim(vRef)) > 0 Then

            vRef = Trim(UCase(vRef))
            Dim ds As PSS.Data.Production.Joins
            Dim strSQL As String = "SELECT Tray_ID FROM tawaitingparts WHERE AP_RefNo = '" & vRef & "' ORDER BY Tray_ID"
            Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
            Dim r As DataRow

            If dt.Rows.Count < 1 Then
                MsgBox("No Tray can be determined.Exiting.", MsgBoxStyle.OKOnly, "ERROR")
                Me.txtTray.Focus()
                Exit Sub
            Else
                '//get record and populate into tray id
                r = dt.Rows(0)
                txtTray.Text = r("Tray_ID")
                txtTray.Focus()
                'txtTray_KeyDown(sender as object, e as system.windows.forms.keyeventargs)
            End If



        End If

    End Sub

End Class
