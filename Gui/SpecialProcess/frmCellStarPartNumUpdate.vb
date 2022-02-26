Public Class frmCellStarPartNumUpdate
    Inherits System.Windows.Forms.Form

    Private objCellStarBER As PSS.Data.Buisness.CellStarBER
    Private dtPartNum As DataTable
    Private iPart_ID As Integer = 0

    Private Shared ctl As Control
    Private Shared HighLightColor As Color = Color.Yellow
    Private Shared WindowColor As Color = Color.White
    Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
    Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objCellStarBER = New PSS.Data.Buisness.CellStarBER()

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEnterprise As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCarrier As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPartNum As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLaborAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBer As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PanelDesc As System.Windows.Forms.Panel
    Friend WithEvents TxtLongDesc As System.Windows.Forms.TextBox
    Friend WithEvents txtShortDesc As System.Windows.Forms.TextBox
    Friend WithEvents CheckCarrier As System.Windows.Forms.CheckBox
    Friend WithEvents CheckEnterprise As System.Windows.Forms.CheckBox
    Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnUpdtABStockUPC As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkInactive = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLaborAmt = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCarrier = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbEnterprise = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPartNum = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PanelDesc = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TxtLongDesc = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtShortDesc = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckEnterprise = New System.Windows.Forms.CheckBox()
        Me.CheckCarrier = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnUpdtABStockUPC = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelDesc.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkInactive, Me.Label7, Me.txtBer, Me.Label5, Me.txtLaborAmt, Me.cmdCancel, Me.cmdUpdate, Me.cmbModel, Me.Label4, Me.cmbCarrier, Me.Label3, Me.cmbEnterprise, Me.Label2, Me.Label1, Me.txtPartNum, Me.Panel2})
        Me.Panel1.Location = New System.Drawing.Point(4, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(356, 418)
        Me.Panel1.TabIndex = 0
        '
        'chkInactive
        '
        Me.chkInactive.BackColor = System.Drawing.Color.LightSteelBlue
        Me.chkInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInactive.ForeColor = System.Drawing.Color.Black
        Me.chkInactive.Location = New System.Drawing.Point(54, 168)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkInactive.TabIndex = 15
        Me.chkInactive.Text = "Inactive"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(48, 328)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "BER Cap :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtBer
        '
        Me.txtBer.Enabled = False
        Me.txtBer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBer.Location = New System.Drawing.Point(144, 328)
        Me.txtBer.MaxLength = 10
        Me.txtBer.Name = "txtBer"
        Me.txtBer.Size = New System.Drawing.Size(160, 22)
        Me.txtBer.TabIndex = 9
        Me.txtBer.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(32, 296)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Labor Amount :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLaborAmt
        '
        Me.txtLaborAmt.Enabled = False
        Me.txtLaborAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaborAmt.Location = New System.Drawing.Point(144, 296)
        Me.txtLaborAmt.MaxLength = 10
        Me.txtLaborAmt.Name = "txtLaborAmt"
        Me.txtLaborAmt.Size = New System.Drawing.Size(160, 22)
        Me.txtLaborAmt.TabIndex = 7
        Me.txtLaborAmt.Text = ""
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(48, 368)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(104, 32)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "CANCEL"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.Color.White
        Me.cmdUpdate.Location = New System.Drawing.Point(200, 368)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(104, 32)
        Me.cmdUpdate.TabIndex = 5
        Me.cmdUpdate.Text = "UPDATE"
        '
        'cmbModel
        '
        Me.cmbModel.Enabled = False
        Me.cmbModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.Location = New System.Drawing.Point(144, 264)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(160, 24)
        Me.cmbModel.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label4.Location = New System.Drawing.Point(80, 264)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Model :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbCarrier
        '
        Me.cmbCarrier.Enabled = False
        Me.cmbCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCarrier.Location = New System.Drawing.Point(144, 232)
        Me.cmbCarrier.Name = "cmbCarrier"
        Me.cmbCarrier.Size = New System.Drawing.Size(160, 24)
        Me.cmbCarrier.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label3.Location = New System.Drawing.Point(80, 232)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Carrier :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbEnterprise
        '
        Me.cmbEnterprise.Enabled = False
        Me.cmbEnterprise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEnterprise.Location = New System.Drawing.Point(144, 200)
        Me.cmbEnterprise.Name = "cmbEnterprise"
        Me.cmbEnterprise.Size = New System.Drawing.Size(160, 24)
        Me.cmbEnterprise.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label2.Location = New System.Drawing.Point(48, 200)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Enterprise :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Part Number :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPartNum
        '
        Me.txtPartNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNum.Location = New System.Drawing.Point(144, 8)
        Me.txtPartNum.MaxLength = 15
        Me.txtPartNum.Name = "txtPartNum"
        Me.txtPartNum.Size = New System.Drawing.Size(160, 22)
        Me.txtPartNum.TabIndex = 0
        Me.txtPartNum.Text = ""
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelDesc, Me.Panel3})
        Me.Panel2.Location = New System.Drawing.Point(8, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(336, 123)
        Me.Panel2.TabIndex = 11
        '
        'PanelDesc
        '
        Me.PanelDesc.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelDesc.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.TxtLongDesc, Me.Label9, Me.txtShortDesc})
        Me.PanelDesc.Location = New System.Drawing.Point(6, 8)
        Me.PanelDesc.Name = "PanelDesc"
        Me.PanelDesc.Size = New System.Drawing.Size(316, 64)
        Me.PanelDesc.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(12, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Long Description :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtLongDesc
        '
        Me.TxtLongDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLongDesc.Location = New System.Drawing.Point(124, 32)
        Me.TxtLongDesc.MaxLength = 10
        Me.TxtLongDesc.Name = "TxtLongDesc"
        Me.TxtLongDesc.Size = New System.Drawing.Size(176, 22)
        Me.TxtLongDesc.TabIndex = 9
        Me.TxtLongDesc.Text = ""
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(12, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(104, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Short Description :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtShortDesc
        '
        Me.txtShortDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtShortDesc.Location = New System.Drawing.Point(124, 8)
        Me.txtShortDesc.MaxLength = 10
        Me.txtShortDesc.Name = "txtShortDesc"
        Me.txtShortDesc.Size = New System.Drawing.Size(176, 22)
        Me.txtShortDesc.TabIndex = 7
        Me.txtShortDesc.Text = ""
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckEnterprise, Me.CheckCarrier})
        Me.Panel3.Location = New System.Drawing.Point(7, 80)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(315, 32)
        Me.Panel3.TabIndex = 12
        '
        'CheckEnterprise
        '
        Me.CheckEnterprise.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CheckEnterprise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckEnterprise.ForeColor = System.Drawing.Color.Black
        Me.CheckEnterprise.Location = New System.Drawing.Point(32, 4)
        Me.CheckEnterprise.Name = "CheckEnterprise"
        Me.CheckEnterprise.Size = New System.Drawing.Size(120, 24)
        Me.CheckEnterprise.TabIndex = 13
        Me.CheckEnterprise.Text = "Add Enterprise"
        '
        'CheckCarrier
        '
        Me.CheckCarrier.BackColor = System.Drawing.Color.LightSteelBlue
        Me.CheckCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckCarrier.ForeColor = System.Drawing.Color.Black
        Me.CheckCarrier.Location = New System.Drawing.Point(192, 4)
        Me.CheckCarrier.Name = "CheckCarrier"
        Me.CheckCarrier.TabIndex = 14
        Me.CheckCarrier.Text = "Add Carrier"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(5, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(355, 39)
        Me.Label6.TabIndex = 10
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnUpdtABStockUPC
        '
        Me.btnUpdtABStockUPC.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnUpdtABStockUPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdtABStockUPC.ForeColor = System.Drawing.Color.Black
        Me.btnUpdtABStockUPC.Location = New System.Drawing.Point(408, 80)
        Me.btnUpdtABStockUPC.Name = "btnUpdtABStockUPC"
        Me.btnUpdtABStockUPC.Size = New System.Drawing.Size(328, 32)
        Me.btnUpdtABStockUPC.TabIndex = 11
        Me.btnUpdtABStockUPC.Text = "Updating DOB A to B Stock UPC Cross Reference"
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Yellow
        Me.Label11.Location = New System.Drawing.Point(408, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(328, 48)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Required Items in Excel File: (1)No blank line before header (2) Header of column" & _
        " A must be ""A-Stock UPC"" (3) Header of column B must be ""B-Stock UPC"""
        '
        'frmCellStarPartNumUpdate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(752, 486)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label11, Me.btnUpdtABStockUPC, Me.Label6, Me.Panel1})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCellStarPartNumUpdate"
        Me.Text = "Cell Star Part Number Update"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.PanelDesc.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        If Not IsNothing(dtPartNum) Then
            dtPartNum.Dispose()
            dtPartNum = Nothing
        End If
        objCellStarBER = Nothing
        MyBase.Finalize()
    End Sub
    '******************************************************************************
    Private Sub frmCellStarPartNumUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Handlers to highlight in custom colors
        SetHandler(Me.cmbEnterprise)
        SetHandler(Me.cmbCarrier)
        SetHandler(Me.cmbModel)
        SetHandler(Me.txtPartNum)
        SetHandler(Me.txtLaborAmt)
        SetHandler(Me.txtBer)
        SetHandler(Me.txtShortDesc)
        SetHandler(Me.TxtLongDesc)

        'populate combox
        Dim strSQL As String = ""
        strSQL = "SELECT ent_id, ent_shortdesc FROM cs_enterprise order by ent_shortdesc;"
        PopulateComboBox(strSQL, Me.cmbEnterprise, "cs_enterprise")
        strSQL = "SELECT carrier_id, carrier_shortdesc FROM cs_carrier order by carrier_shortdesc;"
        PopulateComboBox(strSQL, Me.cmbCarrier, "cs_carrier")
        strSQL = "SELECT model_id, model_desc " & Environment.NewLine
        strSQL &= "FROM tmodel " & Environment.NewLine
        strSQL &= "WHERE Prod_ID in (2,6) order by model_desc;"
        PopulateComboBox(strSQL, Me.cmbModel, "tmodel")
        Me.txtPartNum.Focus()
    End Sub
    '******************************************************************************
    Private Shared Sub SetHandler(ByVal ctl As Control)
        AddHandler ctl.Enter, EnterHandler
        AddHandler ctl.Leave, LeaveHandler
        AddHandler ctl.Click, EnterHandler
    End Sub

    '******************************************************************************
    Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, HighLightColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, WindowColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
        Dim Type As String = sender.GetType.Name.ToString

        Select Case Type
            Case "ComboBox"
                CType(sender, ComboBox).BackColor = color
            Case "TextBox"
                CType(sender, TextBox).BackColor = color
            Case "CheckBox"
                CType(sender, CheckBox).BackColor = color
            Case Else
                'no other types should be hightlighted.
        End Select
    End Sub

    '******************************************************************************
    Private Sub txtPartNum_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartNum.KeyUp

        Try
            If e.KeyValue = 13 Then

                '*************************************
                'validate input
                '*************************************
                If Trim(Me.txtPartNum.Text) = "" Then
                    Exit Sub
                End If
                If Trim(Me.txtPartNum.Text).Length < 6 Then
                    Throw New Exception("Part number must contain 6 digit number.")
                ElseIf Not IsNumeric(Trim(Me.txtPartNum.Text)) Then
                    Throw New Exception("Part number must be numeric.")
                End If

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                '*************************************
                'Get all part number's related inf
                '*************************************
                Dim strSQL As String = ""

                dtPartNum = objCellStarBER.GetPartNumEntry(Trim(Me.txtPartNum.Text))
                If dtPartNum.Rows.Count > 0 Then
                    Me.cmbEnterprise.SelectedValue = dtPartNum.Rows(0)("ent_id")
                    Me.cmbCarrier.SelectedValue = dtPartNum.Rows(0)("carrier_id")
                    Me.cmbModel.SelectedValue = dtPartNum.Rows(0)("model_id")
                    Me.txtLaborAmt.Text = dtPartNum.Rows(0)("laboramount")
                    Me.txtBer.Text = dtPartNum.Rows(0)("BERrate")
                    If dtPartNum.Rows(0)("inactive") = 1 Then
                        Me.chkInactive.Checked = True
                    End If
                    iPart_ID = dtPartNum.Rows(0)("Part_ID")    '1:Update
                    Me.cmbCarrier.Enabled = True
                    Me.cmbEnterprise.Enabled = True
                    Me.cmbModel.Enabled = True
                    Me.txtLaborAmt.Enabled = True
                    Me.txtBer.Enabled = True
                Else
                    iPart_ID = 0  '2:Insert

                    '*************************************
                    'by default set new part#(part have 12 digit) to be inactive
                    '*************************************
                    If Len(Trim(Me.txtPartNum.Text)) = 12 Then
                        Me.chkInactive.Checked = True
                    End If
                End If

                '*************************************
                'enable controls
                '*************************************
                Me.txtPartNum.Enabled = False
                Me.cmbEnterprise.Enabled = True
                Me.cmbCarrier.Enabled = True
                Me.cmbModel.Enabled = True
                Me.txtLaborAmt.Enabled = True
                Me.txtBer.Enabled = True
                Me.cmbModel.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("txtPartNum_KeyUp():" & ex.ToString, "Get Part Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtPartNum.Text = ""
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '******************************************************************************
    Private Sub PopulateComboBox(ByVal strSql As String, _
                                 ByRef cmbox As System.Windows.Forms.ComboBox, _
                                 ByVal strCmbName As String)
        Dim dt As DataTable
        Try
            dt = objCellStarBER.GetCmbDisplayData(strSql, strCmbName)
            cmbox.DataSource = dt.DefaultView
            cmbox.ValueMember = dt.Columns(0).ToString
            cmbox.DisplayMember = dt.Columns(1).ToString
            If cmbox.Name = Me.cmbCarrier.Name Then
                cmbox.SelectedValue = 19  'DOB
            ElseIf cmbox.Name = Me.cmbEnterprise.Name Then
                cmbox.SelectedValue = 5   'DOB
            Else
                cmbox.SelectedValue = 0
            End If

        Catch ex As Exception
            Throw New Exception("PopulateComboBox():" & ex.ToString)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try

    End Sub

    '******************************************************************************
    Private Sub cmbEnterprise_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEnterprise.SelectionChangeCommitted
        If Me.cmbEnterprise.SelectedValue > 0 Then
            Me.cmbCarrier.Enabled = True
            Me.cmbCarrier.Focus()
        End If
    End Sub

    '******************************************************************************
    Private Sub cmbCarrier_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCarrier.SelectionChangeCommitted
        If Me.cmbCarrier.SelectedValue > 0 Then
            Me.cmbModel.Enabled = True
            Me.cmbModel.Focus()
        End If
    End Sub

    '******************************************************************************
    Private Sub cmbModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModel.SelectionChangeCommitted
        If Me.cmbModel.SelectedValue > 0 Then
            Me.txtLaborAmt.Enabled = True
            Me.txtBer.Enabled = True
            Me.txtLaborAmt.Focus()
        End If
    End Sub

    '******************************************************************************
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim strPartNum As String = Trim(Me.txtPartNum.Text)
        Dim i As Integer = 0
        Dim dt As DataTable
        Dim iEnterpriseID As Integer = 0
        Dim iCarrier As Integer = 0
        Dim imodel As Integer = 0
        Dim dLaborAmt As Double = 0
        Dim dBerRate As Double = 0
        Dim iInActiveFlg As Integer = 0

        Try
            '***************************
            'validate input
            '***************************
            If strPartNum = "" Or strPartNum.Length < 6 Or Not IsNumeric(strPartNum) Then
                Throw New Exception("Part Number is not defined.")
            End If
            If Me.cmbEnterprise.SelectedValue = 0 Then
                Throw New Exception("Enterprise is not defined.")
            End If
            If Me.cmbCarrier.SelectedValue = 0 Then
                Throw New Exception("Carrier is not defined.")
            End If
            If Me.cmbModel.SelectedValue = 0 Then
                Throw New Exception("Model is not defined.")
            End If
            If Me.txtLaborAmt.Text = "" Or Not IsNumeric(Trim(Me.txtLaborAmt.Text)) Then
                Throw New Exception("Labor amount is not defined.")
            End If
            If Me.txtBer.Text = "" Or Not IsNumeric(Trim(Me.txtBer.Text)) Then
                Throw New Exception("Labor amount is not defined.")
            End If
            '***************************
            'Get input data
            '**************************
            iEnterpriseID = CInt(Me.cmbEnterprise.SelectedValue)
            iCarrier = CInt(Me.cmbCarrier.SelectedValue)
            imodel = CInt(Me.cmbModel.SelectedValue)
            dLaborAmt = Trim(Me.txtLaborAmt.Text)
            dBerRate = Trim(Me.txtBer.Text)
            If Me.chkInactive.Checked = True Then
                iInActiveFlg = 1
            End If
            '***************************
            'existing record
            '**************************
            If iPart_ID > 0 Then
                'nothing changed
                If strPartNum = Trim(dtPartNum.Rows(0)("part_number")) And _
                             iEnterpriseID = dtPartNum.Rows(0)("ent_id") And _
                             iCarrier = dtPartNum.Rows(0)("carrier_id") And _
                             imodel = dtPartNum.Rows(0)("model_id") And _
                             dLaborAmt = dtPartNum.Rows(0)("laboramount") And _
                             dBerRate = dtPartNum.Rows(0)("BERrate") And _
                             iInActiveFlg = dtPartNum.Rows(0)("inactive") Then
                    MessageBox.Show("No change has made for part number '" & strPartNum & "' therefore update have been canceled.", "Cell Start Part Number Update ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            '***************************
            'update part number
            '**************************
            i = objCellStarBER.UpdtCSPartNum(iPart_ID, _
                                             strPartNum, _
                                             Me.cmbEnterprise.SelectedValue, _
                                             Me.cmbCarrier.SelectedValue, _
                                             Me.cmbModel.SelectedValue, _
                                             dLaborAmt, _
                                             dBerRate, _
                                             iInActiveFlg)
            If i > 0 Then
                MessageBox.Show("Part Number '" & strPartNum & "' has been successfully update.", "Update Cell Star Part Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Fail to update.", "Update CS Part Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

            '***************************
            'clear all global variable and control
            '***************************
            ClearAll()
        Catch ex As Exception
            MessageBox.Show("cmdUpdate_Click(): " & ex.ToString, "Cell Star Part Number Update", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try

    End Sub

    '******************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ClearAll()
    End Sub

    '******************************************************************************
    Private Sub ClearAll()
        'Me.cmbEnterprise.SelectedValue = 0
        'Me.cmbCarrier.SelectedValue = 0
        Me.cmbModel.SelectedValue = 0
        Me.cmbEnterprise.Enabled = False
        Me.cmbCarrier.Enabled = False
        Me.cmbModel.Enabled = False
        Me.txtPartNum.Enabled = True
        Me.txtPartNum.Text = ""
        Me.txtPartNum.Focus()
        dtPartNum = Nothing
        iPart_ID = 0

        Me.txtLaborAmt.Text = ""
        Me.txtLaborAmt.Enabled = False
        Me.txtBer.Text = ""
        Me.txtBer.Enabled = False
        Me.chkInactive.Checked = False
    End Sub

    '******************************************************************************
    Private Sub txtLaborAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLaborAmt.KeyUp
        If e.KeyValue = 13 Then
            Me.txtBer.Focus()
        End If
    End Sub

    '******************************************************************************
    Private Sub CheckEnterprise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckEnterprise.CheckedChanged
        Dim i As Integer = 0
        Dim strShortDesc As String = UCase(Trim(Me.txtShortDesc.Text))
        Dim strLongDesc As String = UCase(Trim(Me.TxtLongDesc.Text))
        Dim strSQL As String = ""
        Dim dt As DataTable
        
        If Me.CheckEnterprise.Checked = True Then

            Try
                '************************************
                'validate input
                '************************************
                If strShortDesc = "" Then
                    Me.txtShortDesc.Focus()
                    Throw New Exception("Enterprise's short description is not defined.")
                End If
                If strLongDesc = "" Then
                    Me.TxtLongDesc.Focus()
                    Throw New Exception("Enterprise's long description is not defined.")
                End If
                '************************************
                'check if enterprise exist
                '************************************
                strSQL = "select * from cs_enterprise where ent_shortdesc = '" & strShortDesc & "' and ent_longdesc = '" & strLongDesc & "';"
                dt = Me.objCellStarBER.GetSelectedDt(strSQL)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("The same enterprise description already exist in the system. Update was canceled.", "Add Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Me.cmbEnterprise.Focus()
                    Exit Sub
                End If
                '************************************
                'disable check box
                '************************************
                Me.CheckCarrier.Enabled = False
                Me.CheckEnterprise.Enabled = False

                '************************************
                'insert new entry into cs_enterprise table
                '************************************
                i = Me.objCellStarBER.UpdtDelInsert("insert into cs_enterprise set ent_shortdesc = '" & strShortDesc & "', ent_longdesc = '" & strLongDesc & "';")
                If i = 0 Then
                    Throw New Exception("Unable to add a new enterprise.")
                Else
                    MessageBox.Show("Sucessfully add a new enterprise.", "Add Enterpise", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                '************************************
                'refresh enterprise combo box(drop down list)
                '************************************
                strSQL = "SELECT ent_id, ent_shortdesc FROM cs_enterprise order by ent_shortdesc;"
                PopulateComboBox(strSQL, Me.cmbEnterprise, "cs_enterprise")
                Me.cmbEnterprise.Focus()
                '************************************
                Me.txtShortDesc.Text = ""
                Me.TxtLongDesc.Text = ""
            Catch ex As Exception
                Me.txtShortDesc.Focus()
                MessageBox.Show("CheckEnterprise_CheckedChanged()::" & ex.ToString, "Add Enterprise", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                Me.CheckEnterprise.Checked = False
                Me.CheckCarrier.Enabled = True
                Me.CheckEnterprise.Enabled = True
            End Try
        End If
    End Sub

    '******************************************************************************
    Private Sub CheckCarrier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckCarrier.CheckedChanged
        Dim i As Integer = 0
        Dim strShortDesc As String = Trim(Me.txtShortDesc.Text)
        Dim strLongDesc As String = Trim(Me.TxtLongDesc.Text)
        Dim strSQL As String = ""
        Dim dt As DataTable

        If Me.CheckCarrier.Checked = True Then
            Try
                '************************************
                'validate input
                '************************************
                If strShortDesc = "" Then
                    Me.txtShortDesc.Focus()
                    Throw New Exception("Enterprise's short description is not defined.")
                End If
                If strLongDesc = "" Then
                    Me.TxtLongDesc.Focus()
                    Throw New Exception("Enterprise's long description is not defined.")
                End If
                '************************************
                'check if carrier exist
                '************************************
                strSQL = "select * from cs_carrier where carrier_shortdesc = '" & strShortDesc & "' and carrier_longdesc = '" & strLongDesc & "';"
                dt = Me.objCellStarBER.GetSelectedDt(strSQL)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("The same carrier description already exist in the system. Update was canceled.", "Add Carrier", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                    Me.cmbEnterprise.Focus()
                    Exit Sub
                End If
                '************************************
                'disable check box
                '************************************
                Me.CheckCarrier.Enabled = False
                Me.CheckEnterprise.Enabled = False
                '************************************
                'insert new entry into cs_enterprise table
                '************************************
                i = Me.objCellStarBER.UpdtDelInsert("insert into cs_carrier set carrier_shortdesc = '" & strShortDesc & "', carrier_longdesc = '" & strLongDesc & "';")
                If i = 0 Then
                    Throw New Exception("Unable to add a new carrier.")
                Else
                    MessageBox.Show("Sucessfully add a new carrier.", "Add Carrier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                '************************************
                'refresh enterprise combo box(drop down list)
                '************************************
                strSQL = "SELECT carrier_id, carrier_shortdesc FROM cs_carrier order by carrier_shortdesc;"
                PopulateComboBox(strSQL, Me.cmbCarrier, "cs_carrier")
                Me.cmbCarrier.Focus()
                '************************************
                Me.txtShortDesc.Text = ""
                Me.TxtLongDesc.Text = ""
            Catch ex As Exception
                MessageBox.Show("CheckCarrier_CheckedChanged()::" & ex.ToString, "Add Carrier", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                Me.CheckCarrier.Checked = False
                Me.CheckCarrier.Enabled = True
                Me.CheckEnterprise.Enabled = True
            End Try
        End If
    End Sub

    '******************************************************************************
    Private Sub chkActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInactive.CheckedChanged
        Me.cmbModel.Focus()
    End Sub

    '******************************************************************************

    Private Sub btnUpdtABStockUPC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdtABStockUPC.Click
        Dim i As Integer = 0
        Dim strFilePath As String = ""

        Try
            '****************************************************************
            'Get the file name and path
            '****************************************************************
            Me.OpenFileDialog1.DefaultExt = "xls"
            Me.OpenFileDialog1.FilterIndex = 1
            Me.OpenFileDialog1.ShowDialog()
            If Len(Trim(Me.OpenFileDialog1.FileName)) > 0 Then
                If LCase(Microsoft.VisualBasic.Right(Trim(Me.OpenFileDialog1.FileName), 3)) <> "xls" Then
                    MessageBox.Show("Incorrect file extension. It must be ""XLS"".", "File Extension", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                strFilePath = Trim(Me.OpenFileDialog1.FileName)
                '*****************************
                'Load File
                '*****************************
                i = Me.objCellStarBER.UpdtABStock_UPC_CrossRef(strFilePath)

                If i > 0 Then
                    MessageBox.Show("This file has been loaded successfully in to PSS database.", "Update UPC Cross Ref Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                '*****************************
            Else
                MessageBox.Show("Please select a file.", "Select File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '****************************************************************

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Load Hours Clicked", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub
End Class
