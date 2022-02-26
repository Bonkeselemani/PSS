Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System.IO

Public Class frmDisposition
    Inherits System.Windows.Forms.Form


    Private mSerialNumber As Long
    Private mDeviceID As Integer
    Private mSKUID As Long
    Private mSKU As String
    Private _device As Device = Nothing
    Private _tray As DataTable = Nothing
    Private tmpDeviceID, tmpModelID, tmpManufID, tmpTrayID, tmpCustID, tmpWO, tmpConsignedParts As Int32
    Private tmpUser As String
    Private tmpID As Long

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
    Private Const btnHeight = 30


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
    Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents txtSerial As System.Windows.Forms.TextBox
    Friend WithEvents lblTray As System.Windows.Forms.Label
    Friend WithEvents txtTray As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblDeviceSN = New System.Windows.Forms.Label()
        Me.txtSerial = New System.Windows.Forms.TextBox()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblTray = New System.Windows.Forms.Label()
        Me.txtTray = New System.Windows.Forms.TextBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblDeviceSN
        '
        Me.lblDeviceSN.Location = New System.Drawing.Point(8, 40)
        Me.lblDeviceSN.Name = "lblDeviceSN"
        Me.lblDeviceSN.Size = New System.Drawing.Size(80, 16)
        Me.lblDeviceSN.TabIndex = 0
        Me.lblDeviceSN.Text = "Serial Number:"
        Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtSerial
        '
        Me.txtSerial.Location = New System.Drawing.Point(96, 40)
        Me.txtSerial.Name = "txtSerial"
        Me.txtSerial.Size = New System.Drawing.Size(128, 20)
        Me.txtSerial.TabIndex = 1
        Me.txtSerial.Text = ""
        '
        'pnlBill
        '
        Me.pnlBill.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBill.Location = New System.Drawing.Point(16, 72)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(560, 248)
        Me.pnlBill.TabIndex = 3
        '
        'lblTray
        '
        Me.lblTray.Location = New System.Drawing.Point(240, 40)
        Me.lblTray.Name = "lblTray"
        Me.lblTray.Size = New System.Drawing.Size(32, 16)
        Me.lblTray.TabIndex = 4
        Me.lblTray.Text = "Tray:"
        Me.lblTray.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTray
        '
        Me.txtTray.Location = New System.Drawing.Point(280, 40)
        Me.txtTray.Name = "txtTray"
        Me.txtTray.Size = New System.Drawing.Size(128, 20)
        Me.txtTray.TabIndex = 5
        Me.txtTray.Text = ""
        '
        'btnClear
        '
        Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnClear.Location = New System.Drawing.Point(504, 8)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "C&lear"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 23)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "DISPOSITION SCREEN"
        '
        'frmDisposition
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 365)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnClear, Me.txtTray, Me.lblTray, Me.pnlBill, Me.txtSerial, Me.lblDeviceSN})
        Me.Name = "frmDisposition"
        Me.Text = "frmDisposition"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmDisposition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSerial.Focus()
        lblTray.Visible = False
        txtTray.Visible = False
    End Sub

    Private Sub createDispositionButtons()


        Dim colCount As Integer = 0

        pnlLeft = pnlBill.Left
        pnlWidth = pnlBill.Width
        gridLeft = pnlBill.Left
        gridWidth = pnlBill.Width

        Dim mSKUMain As String

        Dim intCheck As Integer
        intCheck = InStrRev(mSKU, "-")
        If intCheck > 0 Then
            'mSKU = Mid$(mSKU, 1, intCheck - 1)
            mSKU = Mid$(mSKU, 1, intCheck)
            mSKUMain = Mid$(mSKU, 1, intCheck - 1)
        End If

        Dim btnTop As Integer = 5
        Dim ds As PSS.Data.Production.Joins
        Dim dt As DataTable = ds.OrderEntrySelect("SELECT Sku_ID, Sku_Number FROM tsku WHERE Sku_Number Like '" & mSKU & "%' OR Sku_Number = '" & mSKUMain & "' ORDER BY Sku_Number")

        colCount = 0
        Dim cBill() As Button

        ReDim cBill(dt.Rows.Count)

        Dim x As Integer = 0
        Dim r As DataRow

        For x = 0 To dt.Rows.Count - 1
            r = dt.Rows(x)
            cBill(x) = New System.Windows.Forms.Button()
            With cBill(x)
                Dim TMPvAL = UCase(Mid$(Trim(r("Sku_Number")), Len(Trim(r("Sku_Number"))), 1))
                If TMPvAL = "U" Then
                    .Enabled = False
                End If
                .Text = r("Sku_Number")
                .Size = New Size(120, 30)
                .Location = New Point(btnLeft, btnTop)
                .Visible = True
                .Tag = r("Sku_ID")
                AddHandler .Click, AddressOf Me.displayClick
                btnTop += 5
            End With

            colCount += 1
            If colCount > 5 Then
                'If btnTop + btnHeight + 150 > pnlBill.Height Then
                btnLeft = btnLeft + btnWidth + 5
                btnTop = vBuffer
                colCount = 0
            Else
                btnTop = btnTop + btnHeight + 5
            End If

        Next

        Me.pnlBill.Controls.AddRange(cBill)

        System.Windows.Forms.Application.DoEvents()

        Dim vLoadDisp As Long = 0
        Dim tmpBtn As Button
        Dim ds1 As PSS.Data.Production.Joins
        Dim dt1 As DataTable = ds1.OrderEntrySelect("SELECT Disp_NEW FROM tdisposition WHERE device_id = " & mDeviceID & " ORDER BY Disp_id DESC")

        Dim strLoadDisp As String

        If vLoadDisp > 0 Then
            For x = 0 To pnlBill.Controls.Count - 1
                tmpBtn = CType(pnlBill.Controls(x), System.Windows.Forms.Button)
                With tmpBtn
                    If .Tag = vLoadDisp Then
                        .ForeColor = Color.Blue()
                        strLoadDisp = .Text
                    End If
                End With
            Next
        End If

        btnLeft = 5
        btnTop = 5

        System.Windows.Forms.Application.DoEvents()
        If dt1.Rows.Count < 1 Then
        Else
            vLoadDisp = dt1.Rows(0)("Disp_New")
            '//Do not allow another selection
            Dim mStrDisp As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tsku WHERE Sku_ID = " & vLoadDisp)
            Dim rStrDisp As DataRow = mStrDisp.Rows(0)
            displayNoteBoard("This device has an already defined disposition of " & rStrDisp("SKU_Number") & ". The page will now clear.")
            'Dim vNote As New Gui.NoteBoard.frmNoteBoard("This device has an already defined disposition of " & rStrDisp("SKU_Number") & ". The page will now clear.")
            System.Windows.Forms.Application.DoEvents()

            Me.pnlBill.Controls.Clear()
            txtSerial.Text = ""
            txtTray.Text = ""
            lblTray.Visible = False
            txtTray.Visible = False
            txtSerial.Focus()
            Exit Sub
        End If


    End Sub

    Private Sub displayClick(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim vDataID As Integer = sender.tag.ToString
        Dim vDataName As String = sender.text.ToString
        Dim vOldDisp As Integer

        '//Check to see if OK for assignment
        If Len(Trim(vDataID)) < 1 Or Len(Trim(vDataName)) < 1 Then
            MsgBox("Corruption to data. Exiting", MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End If

        '//Read for old value
        Dim vNow As String = Gui.Receiving.FormatDate(Now)
        Dim vNowShort As String = Gui.Receiving.FormatDateShort(Now)

        Dim ds As PSS.Data.Production.Joins
        Dim dt As DataTable = ds.OrderEntrySelect("SELECT Disp_NEW FROM tdisposition WHERE device_id = " & mDeviceID & " ORDER BY Disp_id DESC")
        Dim r As DataRow
        If dt.Rows.Count < 1 Then

            '//June 20, 2005 Get the original sku value from tdevice and set it here - START
            Dim dt1 As DataTable = ds.OrderEntrySelect("SELECT Sku_ID FROM tdevice WHERE device_id = " & mDeviceID)
            vOldDisp = dt1.Rows(0)("Sku_ID")
            '//June 20, 2005 Get the original sku value from tdevice and set it here - END
            'vOldDisp = 0
        Else
            vOldDisp = dt.Rows(0)("Disp_New")
        End If

        '//Insert record
        Dim blnInsert As Boolean = ds.OrderEntryUpdateDelete("INSERT INTO tdisposition (Disp_Date, Disp_OLD, Disp_NEW, Device_ID) VALUES ('" & vNow & "', " & vOldDisp & ", " & vDataID & ", " & mDeviceID & ")")
        'Insert into tdevice required by ASIF
        System.Windows.Forms.Application.DoEvents()
        Try
            Dim blnInsertDevice As Boolean = ds.OrderEntryUpdateDelete("UPDATE tdevice SET Sku_ID = " & vDataID & " WHERE device_id = " & mDeviceID)
        Catch ex As Exception
            MsgBox("Error updating tdevice field: sku_id")
        End Try

        '//AutoBill
        Dim dss As PSS.Data.Production.Joins
        Dim dtdss As DataTable = dss.OrderEntrySelect("SELECT * FROM tsku where Sku_ID = " & vDataID)
        Dim dssr As DataRow = dtdss.Rows(0)
        Try
            AutoBill(dssr("Billcode_ID"))
        Catch ex As Exception
            MsgBox("Item could not be billed.")
        End Try

        Dim x As Integer
        Dim tmpBtn As Button

        For x = 0 To pnlBill.Controls.Count - 1
            tmpBtn = CType(pnlBill.Controls(x), System.Windows.Forms.Button)
            With tmpBtn
                .ForeColor = Color.Black
            End With
        Next

        sender.forecolor = Color.Blue

    End Sub



    Private Sub txtSerialNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSerial.TextChanged

    End Sub


    Private Sub displayNoteBoard(ByVal vString As String)
        Dim xForm As New Gui.NoteBoard.frmNoteBoard(vString)
        xForm.ShowDialog()
    End Sub

    Private Function verifySerialNumber(ByVal mDeviceSN As String) As Long

        Try
            Dim dRec As New PSS.Data.Production.tdevice()
            Dim tRec As DataTable = dRec.GetDataTableBySNPretest(mDeviceSN)
            Dim r As DataRow

            If tRec.Rows.Count < 1 Then     'If records returned = 0 then 
                displayNoteBoard("Either the Serial Number does not exists or this device has been shipped.")
                Return 0                    'send trigger to display error message
            ElseIf tRec.Rows.Count > 1 Then 'If more than 1 record is returned then 
                Return 2                    'send trigger to display tray textbox
            Else
                r = tRec.Rows(0)
                If IsDBNull(r("Device_DateShip")) = False Then
                    displayNoteBoard("This Serial Number has been shipped.")
                    Return 0
                End If
                Dim tRun As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tdisposition WHERE device_ID = " & r("Device_ID"))
                If tRun.Rows.Count > 0 Then
                    'displayNoteBoard("THIS DEVICE ALREADY HAS A DEFINED DISPOSITION.")
                    'txtSerial.Focus()
                End If
                Return r("Device_ID")       'Send back device ID
            End If
        Catch ex As Exception
            Return 0
        End Try

    End Function

    Private Function getTrayID(ByVal mDeviceID As Long) As Long

        getTrayID = 0

        Try
            Dim dTray As New PSS.Data.Production.tdevice()
            Dim tTray As DataRow = dTray.GetRowByPK(mDeviceID)
            getTrayID = tTray("Tray_ID")
        Catch ex As Exception
            '//will return value of 0 so no coding necessary here
        End Try

    End Function


    Private Sub txtSerialNumber_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown

        If e.KeyValue = 13 Then
            txtSerial.Text = UCase(txtSerial.Text)  '//Format serial as all uppercase
            Dim val As Long = Me.verifySerialNumber(txtSerial.Text)
            If val = 0 Then
                lblTray.Visible = False
                txtTray.Visible = False
                txtSerial.Text = ""
                txtSerial.Focus()
                Exit Sub
            ElseIf val = 2 Then
                txtTray.Text = ""
                lblTray.Visible = True
                txtTray.Visible = True
                txtTray.Focus()
            Else
                mSerialNumber = val
                txtTray.Text = getTrayID(mSerialNumber)
                lblTray.Visible = True
                txtTray.Visible = True
                retreiveData()
            End If
        End If

    End Sub




    Private Sub retreiveData()


        Try
            _device = Nothing
            _tray = Nothing
        Catch ex As Exception
        End Try


        getData(Me.txtTray.Text, Me.txtSerial.Text)



    End Sub


    Private Sub getData(ByVal TrayNum As Int32, ByVal deviceSN As String)

        tmpDeviceID = 0
        tmpModelID = 0
        tmpTrayID = 0
        tmpManufID = 0
        tmpCustID = 0
        tmpWO = 0

        tmpTrayID = Me.txtTray.Text

        Dim lstTech As New PSS.Data.Production.tusers()
        Dim dtTech As DataTable = lstTech.GetCellTechList

        tmpUser = PSS.Core.Global.ApplicationUser.User
        tmpID = 0
        Dim xCount As Integer
        Dim r As DataRow

        For xCount = 0 To dtTech.Rows.Count - 1
            r = dtTech.Rows(xCount)
            If tmpUser = r("user_fullname") Then
                tmpID = r("tech_id")
                Exit For
            End If
        Next

        dtTech = Nothing


        Dim mthd As New PSS.Data.Production.tdevice()
        Dim mtDeviceID As DataTable = mthd.GetDataTableBySN(deviceSN)
        'Dim r As DataRow
        'Dim xCount As Integer = 0

        For xCount = 0 To mtDeviceID.Rows.Count - 1
            r = mtDeviceID.Rows(xCount)
            If r("Tray_ID") = TrayNum Then
                tmpDeviceID = r("Device_ID")
                tmpModelID = r("Model_ID")
                tmpWO = r("WO_ID")

                Exit For
            End If
        Next


        '//Verify that the device has been billed. If not then exit
        Dim chkBill As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("Select Count(BillCode_ID) FROM tdevicebill where device_id = " & tmpDeviceID & " GROUP BY device_id")
        'If chkBill.Rows.Count < 1 Then
        If chkBill.Rows.Count > 1 Then
            MsgBox("This device can not be assigned a disposition because it has already been billed.", MsgBoxStyle.Exclamation, "Error")

            Me.pnlBill.Controls.Clear()
            txtSerial.Text = ""
            txtTray.Text = ""
            lblTray.Visible = False
            txtTray.Visible = False
            txtSerial.Focus()
            Exit Sub
        End If


        'Craig Haney
        Dim tmpCds As PSS.Data.Production.Joins
        Dim tmpCdr As DataRow = tmpCds.GetCustomerFromDeviceID(tmpDeviceID)
        tmpCustID = tmpCdr("Cust_ID")

        Dim tmpDS2 As PSS.Data.Production.Joins
        Dim vCV As Integer = 0
        Dim tmpCount As Integer = 0

        'Craig Haney - END
        Try
            mtDeviceID.Dispose()
            mtDeviceID = Nothing
        Catch ex As Exception
        End Try

        Dim mtManuf As New PSS.Data.Production.tmodel()
        Dim mtManufID As DataRow = mtManuf.GetRowByModel(tmpModelID)
        tmpManufID = mtManufID("Manuf_ID")
        If tmpDeviceID = 0 Or tmpModelID = 0 Or tmpManufID = 0 Then
            Exit Sub
        End If

        mDeviceID = getDeviceID(txtSerial.Text, txtTray.Text)

        LoadTray()
        LoadDevice()


        createDispositionButtons()

    End Sub



    Private Function getDeviceID(ByVal mSerialNum, ByVal mTrayID)

        getDeviceID = 0
        If Len(Trim(mSerialNum)) < 1 Or Len(Trim(mTrayID)) < 1 Then Return 0
        Dim ds As PSS.Data.Production.Joins
        Dim dt As DataTable = ds.OrderEntrySelect("SELECT device_id, sku_id FROM tdevice WHERE tray_id = " & mTrayID & " AND device_sn = '" & mSerialNum & "'")
        If dt.Rows.Count > 1 Then Return 0
        getDeviceID = dt.Rows(0)("Device_ID")

        mSKUID = dt.Rows(0)("Sku_ID")
        Dim ds1 As PSS.Data.Production.tsku
        Dim dt2 As DataRow = ds1.GetValSKUID(mSKUID)
        mSKU = dt2("Sku_Number")

        Return getDeviceID

    End Function


    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

        Me.pnlBill.Controls.Clear()
        txtSerial.Text = ""
        txtTray.Text = ""
        lblTray.Visible = False
        txtTray.Visible = False
        txtSerial.Focus()

    End Sub


    Private Sub AutoBill(ByVal intBillCode As Integer)

        'Try
        '_device = Nothing
        '_tray = Nothing
        'Catch ex As Exception
        'End Try


        Dim xCount As Integer = 0
        Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tdevice WHERE device_id = " & tmpDeviceID)
        Dim r As DataRow

        For xCount = 0 To dt.Rows.Count - 1

            'r = dt.Rows(xCount)
            'Me.LoadDevice(r("Device_SN"))
            'System.Windows.Forms.Application.DoEvents()

            Try
                'Bill Part
                _device.AddPart(intBillCode)
                System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            If Len(Trim(tmpTrayID)) > 0 Then
                If Len(Trim(tmpDeviceID)) > 0 Then
                    UpdateBilling()
                End If
            End If

            Try
                _device = Nothing
                System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
            End Try

        Next

    End Sub

    Private Sub UpdateBilling()
        Try 'here in case there is not refrence to _device
            _device.Update()
            Dim d As DataRow() = _tray.Select("Device_ID = " & _device.ID)
            If _device.Parts.Rows.Count = 0 Then
                d(0)("Device_DateBill") = DBNull.Value
            Else
                d(0)("Device_DateBill") = Now
            End If
            d = Nothing
            '_device.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
        Finally
        End Try
    End Sub

    Private Sub LoadDevice()
        Try
            Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(txtSerial.Text) & "'")
            _device = New Device(__device(0)("Device_ID"))
            Dim i As Integer = 0
            For i = 0 To _tray.Rows.Count - 1
                If _tray.Rows(i)("Device_SN") = UCase(txtSerial.Text) Then
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
            _device = Nothing
        End Try
    End Sub

    Private Sub LoadTray()

        If IsNumeric(tmpTrayID) Then
            Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(tmpTrayID)
            If Source.Rows.Count = 0 Then
                MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")
                _tray = Nothing
            Else
                _tray = Source
            End If
            Source = Nothing
        Else
            MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
        End If

    End Sub

End Class
