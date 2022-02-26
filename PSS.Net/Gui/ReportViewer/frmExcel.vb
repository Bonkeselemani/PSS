Namespace Gui.ReportViewer
    Public Class frmExcel
        Inherits System.Windows.Forms.Form
        Private objMisc As PSS.Data.Buisness.Misc

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMisc = New PSS.Data.Buisness.Misc()
            objMisc._CurUser = PSS.Core.Global.ApplicationUser.User
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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboWCLoc As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cmdWCDetailRpt As System.Windows.Forms.Button
        Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cmbPSSI As PSS.Gui.Controls.ComboBox
        Friend WithEvents pnlFilter As System.Windows.Forms.Panel
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents cmdTrimbleShipRpt As System.Windows.Forms.Button
        Friend WithEvents dtpShipToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpShipFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cmdTATWIPRpt As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cmbTATCust As PSS.Gui.Controls.ComboBox
        Friend WithEvents cmbTATProd As PSS.Gui.Controls.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cmdWCDetailRpt = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboWCLoc = New PSS.Gui.Controls.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.pnlFilter = New System.Windows.Forms.Panel()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cmbPSSI = New PSS.Gui.Controls.ComboBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.cmdTrimbleShipRpt = New System.Windows.Forms.Button()
            Me.dtpShipToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpShipFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cmdTATWIPRpt = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cmbTATCust = New PSS.Gui.Controls.ComboBox()
            Me.cmbTATProd = New PSS.Gui.Controls.ComboBox()
            Me.Panel3.SuspendLayout()
            Me.pnlFilter.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.GroupBox3.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'cmdWCDetailRpt
            '
            Me.cmdWCDetailRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdWCDetailRpt.Location = New System.Drawing.Point(128, 245)
            Me.cmdWCDetailRpt.Name = "cmdWCDetailRpt"
            Me.cmdWCDetailRpt.Size = New System.Drawing.Size(200, 31)
            Me.cmdWCDetailRpt.TabIndex = 66
            Me.cmdWCDetailRpt.Text = "Generate Report"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(248, 52)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(88, 16)
            Me.Label5.TabIndex = 65
            Me.Label5.Text = "Bill Date to:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpToDate
            '
            Me.dtpToDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpToDate.Location = New System.Drawing.Point(336, 50)
            Me.dtpToDate.Name = "dtpToDate"
            Me.dtpToDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpToDate.TabIndex = 64
            Me.dtpToDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label4.Location = New System.Drawing.Point(24, 52)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 16)
            Me.Label4.TabIndex = 63
            Me.Label4.Text = "Bill Date From:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpFromDate
            '
            Me.dtpFromDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFromDate.Location = New System.Drawing.Point(136, 50)
            Me.dtpFromDate.Name = "dtpFromDate"
            Me.dtpFromDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpFromDate.TabIndex = 62
            Me.dtpFromDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.BackColor = System.Drawing.SystemColors.Window
            Me.cboModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.ForeColor = System.Drawing.Color.Black
            Me.cboModel.Location = New System.Drawing.Point(112, 88)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(235, 21)
            Me.cboModel.TabIndex = 61
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(48, 88)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(56, 16)
            Me.Label3.TabIndex = 60
            Me.Label3.Text = "Model:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.BackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.ForeColor = System.Drawing.Color.Black
            Me.cboCustomer.Location = New System.Drawing.Point(112, 56)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(235, 21)
            Me.cboCustomer.TabIndex = 59
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(24, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 58
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboWCLoc
            '
            Me.cboWCLoc.AutoComplete = True
            Me.cboWCLoc.BackColor = System.Drawing.SystemColors.Window
            Me.cboWCLoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboWCLoc.ForeColor = System.Drawing.Color.Black
            Me.cboWCLoc.Location = New System.Drawing.Point(112, 24)
            Me.cboWCLoc.Name = "cboWCLoc"
            Me.cboWCLoc.Size = New System.Drawing.Size(235, 21)
            Me.cboWCLoc.TabIndex = 57
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(8, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 16)
            Me.Label2.TabIndex = 56
            Me.Label2.Text = "WC Location:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlFilter, Me.Label6, Me.cmbPSSI, Me.Label5, Me.cmdWCDetailRpt, Me.dtpToDate, Me.dtpFromDate, Me.Label4})
            Me.Panel3.Location = New System.Drawing.Point(12, 24)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(454, 296)
            Me.Panel3.TabIndex = 67
            '
            'pnlFilter
            '
            Me.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFilter.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.cboCustomer, Me.cboModel, Me.Label2, Me.Label1, Me.cboWCLoc})
            Me.pnlFilter.Location = New System.Drawing.Point(30, 88)
            Me.pnlFilter.Name = "pnlFilter"
            Me.pnlFilter.Size = New System.Drawing.Size(378, 144)
            Me.pnlFilter.TabIndex = 69
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label6.Location = New System.Drawing.Point(8, 16)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(126, 16)
            Me.Label6.TabIndex = 67
            Me.Label6.Text = "Detail/Summary:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbPSSI
            '
            Me.cmbPSSI.AutoComplete = True
            Me.cmbPSSI.BackColor = System.Drawing.SystemColors.Window
            Me.cmbPSSI.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbPSSI.ForeColor = System.Drawing.Color.Black
            Me.cmbPSSI.Items.AddRange(New Object() {"Summary", "Detail"})
            Me.cmbPSSI.Location = New System.Drawing.Point(136, 14)
            Me.cmbPSSI.Name = "cmbPSSI"
            Me.cmbPSSI.Size = New System.Drawing.Size(104, 21)
            Me.cmbPSSI.TabIndex = 68
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel3})
            Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(16, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(480, 336)
            Me.GroupBox1.TabIndex = 68
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "WC Detail Report"
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1})
            Me.GroupBox2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(504, 8)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(276, 144)
            Me.GroupBox2.TabIndex = 69
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Trimble Report"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label11, Me.cmdTrimbleShipRpt, Me.dtpShipToDate, Me.dtpShipFromDate, Me.Label12})
            Me.Panel1.Location = New System.Drawing.Point(12, 24)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(252, 112)
            Me.Panel1.TabIndex = 67
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label11.Location = New System.Drawing.Point(24, 40)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(112, 16)
            Me.Label11.TabIndex = 65
            Me.Label11.Text = "Ship Date to:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdTrimbleShipRpt
            '
            Me.cmdTrimbleShipRpt.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdTrimbleShipRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdTrimbleShipRpt.ForeColor = System.Drawing.Color.White
            Me.cmdTrimbleShipRpt.Location = New System.Drawing.Point(24, 72)
            Me.cmdTrimbleShipRpt.Name = "cmdTrimbleShipRpt"
            Me.cmdTrimbleShipRpt.Size = New System.Drawing.Size(200, 31)
            Me.cmdTrimbleShipRpt.TabIndex = 66
            Me.cmdTrimbleShipRpt.Text = "Generate Report"
            '
            'dtpShipToDate
            '
            Me.dtpShipToDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpShipToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpShipToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpShipToDate.Location = New System.Drawing.Point(136, 40)
            Me.dtpShipToDate.Name = "dtpShipToDate"
            Me.dtpShipToDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpShipToDate.TabIndex = 64
            Me.dtpShipToDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpShipFromDate
            '
            Me.dtpShipFromDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpShipFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpShipFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpShipFromDate.Location = New System.Drawing.Point(136, 8)
            Me.dtpShipFromDate.Name = "dtpShipFromDate"
            Me.dtpShipFromDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpShipFromDate.TabIndex = 62
            Me.dtpShipFromDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label12.Location = New System.Drawing.Point(12, 8)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(128, 16)
            Me.Label12.TabIndex = 63
            Me.Label12.Text = "Ship Date From:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox3
            '
            Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2})
            Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox3.ForeColor = System.Drawing.Color.White
            Me.GroupBox3.Location = New System.Drawing.Point(16, 352)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(480, 144)
            Me.GroupBox3.TabIndex = 70
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = "TAT WIP Report"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbTATProd, Me.cmbTATCust, Me.Label7, Me.cmdTATWIPRpt, Me.Label8})
            Me.Panel2.Location = New System.Drawing.Point(12, 24)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(372, 112)
            Me.Panel2.TabIndex = 67
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label7.Location = New System.Drawing.Point(8, 40)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(104, 16)
            Me.Label7.TabIndex = 65
            Me.Label7.Text = "Product Type:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdTATWIPRpt
            '
            Me.cmdTATWIPRpt.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdTATWIPRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdTATWIPRpt.ForeColor = System.Drawing.Color.White
            Me.cmdTATWIPRpt.Location = New System.Drawing.Point(88, 72)
            Me.cmdTATWIPRpt.Name = "cmdTATWIPRpt"
            Me.cmdTATWIPRpt.Size = New System.Drawing.Size(200, 31)
            Me.cmdTATWIPRpt.TabIndex = 66
            Me.cmdTATWIPRpt.Text = "Generate Report"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label8.Location = New System.Drawing.Point(32, 8)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(80, 16)
            Me.Label8.TabIndex = 63
            Me.Label8.Text = "Customer:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbTATCust
            '
            Me.cmbTATCust.AutoComplete = True
            Me.cmbTATCust.BackColor = System.Drawing.SystemColors.Window
            Me.cmbTATCust.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbTATCust.ForeColor = System.Drawing.Color.Black
            Me.cmbTATCust.Location = New System.Drawing.Point(120, 8)
            Me.cmbTATCust.Name = "cmbTATCust"
            Me.cmbTATCust.Size = New System.Drawing.Size(232, 21)
            Me.cmbTATCust.TabIndex = 67
            '
            'cmbTATProd
            '
            Me.cmbTATProd.AutoComplete = True
            Me.cmbTATProd.BackColor = System.Drawing.SystemColors.Window
            Me.cmbTATProd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbTATProd.ForeColor = System.Drawing.Color.Black
            Me.cmbTATProd.Location = New System.Drawing.Point(119, 39)
            Me.cmbTATProd.Name = "cmbTATProd"
            Me.cmbTATProd.Size = New System.Drawing.Size(235, 21)
            Me.cmbTATProd.TabIndex = 68
            '
            'frmExcel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(792, 502)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox3, Me.GroupBox2, Me.GroupBox1})
            Me.Name = "frmExcel"
            Me.Text = "Excel Reports"
            Me.Panel3.ResumeLayout(False)
            Me.pnlFilter.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.GroupBox3.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region
        '*********************************************************
        Private Sub cmdWCDetailRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWCDetailRpt.Click
            Dim i As Integer = 0
            Cursor.Current = Cursors.WaitCursor
            'empty data Validation
            If Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MsgBox("Please select 'Bill Date From' and 'Bill Date to'.", MsgBoxStyle.Information, "WC Detail Report")
                Exit Sub
            End If

            If Me.dtpToDate.Value < Me.dtpFromDate.Value Then
                MsgBox("'Bill Date to' can't be before 'Bill Date From'.", MsgBoxStyle.Information, "WC Detail Report")
                Exit Sub
            End If

            Try
                ' GenerateWCDetailReport
                i = objMisc.GenerateWCDetailReport(Me.dtpFromDate.Text, Me.dtpToDate.Text, Me.cmbPSSI.SelectedIndex, Me.cboWCLoc.SelectedValue, Me.cboCustomer.SelectedValue, Me.cboModel.SelectedValue)
                If i <> 1 Then
                    Throw New Exception("Check the report for errors (i = 0).")
                End If
            Catch ex As Exception
                MsgBox("frmExcel.cmdWCDetailRpt_Click:: " & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        '*********************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '*********************************************************

        Private Sub frmExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objCSMisc As New PSS.Data.Buisness.CellstarMisc()

            Try
                Me.cmbPSSI.SelectedIndex = 0
                LoadWCLocations()
                LoadCustomers()
                LoadModels()
                objCSMisc.LoadProductTypes(Me.cmbTATProd)

                If Me.cmbPSSI.SelectedIndex = 0 Then        'Summary
                    Me.pnlFilter.Visible = False
                Else                                        'Detail
                    Me.pnlFilter.Visible = True
                End If

                Me.dtpFromDate.Text = Now
                Me.dtpToDate.Text = Now
                Me.dtpShipFromDate.Text = Now
                Me.dtpShipToDate.Text = Now
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objCSMisc = Nothing
            End Try
            
        End Sub
        '*********************************************************
        Private Sub LoadWCLocations()
            Dim dtWCLoc As New DataTable()
            Try
                dtWCLoc = objMisc.GetWCLocations
                With Me.cboWCLoc
                    .DataSource = dtWCLoc.DefaultView
                    .DisplayMember = dtWCLoc.Columns("WC_Location").ToString
                    .ValueMember = dtWCLoc.Columns("WCLocation_ID").ToString
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                MsgBox("Error in frmExcel.LoadWCLocations:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objMisc.DisposeDT(dtWCLoc)
            End Try
        End Sub
        '*********************************************************
        Private Sub LoadCustomers()
            Dim dtCustomers As New DataTable()
            Try
                dtCustomers = objMisc.GetCustomers
                With Me.cboCustomer
                    .DataSource = dtCustomers.DefaultView
                    .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                    .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                    .SelectedValue = 0
                End With

                '*******************************************
                'Lan added this section for TAT WIP Report
                '*******************************************
                With Me.cmbTATCust
                    .DataSource = dtCustomers.DefaultView
                    .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                    .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                    .SelectedValue = 2113
                End With
                '*******************************************

            Catch ex As Exception
                MsgBox("Error in frmExcel.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objMisc.DisposeDT(dtCustomers)
            End Try
        End Sub
        '*********************************************************
        Private Sub LoadModels()
            Dim dtModels As New DataTable()
            Try
                dtModels = objMisc.GetModels(1)         '1 For messaging, 2 for cellular)
                With Me.cboModel
                    .DataSource = dtModels.DefaultView
                    .DisplayMember = dtModels.Columns("Model_Desc").ToString
                    .ValueMember = dtModels.Columns("Model_ID").ToString
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                MsgBox("Error in frmExcel.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objMisc.DisposeDT(dtModels)
            End Try
        End Sub
        '*********************************************************
        Private Sub cmbPSSI_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPSSI.SelectedIndexChanged
            If Me.cmbPSSI.SelectedIndex = 0 Then        'Summary
                Me.pnlFilter.Visible = False
            Else                                        'Detail
                Me.pnlFilter.Visible = True
            End If
        End Sub
        '*********************************************************
        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '    MsgBox(PSS.Core.Global.ApplicationUser.User)
        'End Sub

        '*********************************************************
        Private Sub cmdTrimbleShipRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTrimbleShipRpt.Click
            Dim i As Integer = 0
            Dim objCellStarMisc As New PSS.Data.Buisness.CellstarMisc()

            Cursor.Current = Cursors.WaitCursor
            'empty data Validation
            If Me.dtpShipFromDate.Text = "" Or Me.dtpShipToDate.Text = "" Then
                MsgBox("Please select 'Ship Date From' and 'Ship Date to'.", MsgBoxStyle.Information, "WC Detail Report")
                Exit Sub
            End If

            If Me.dtpShipToDate.Value < Me.dtpShipFromDate.Value Then
                MsgBox("'Ship Date to' can't be before 'Ship Date From'.", MsgBoxStyle.Information, "WC Detail Report")
                Exit Sub
            End If

            Try
                ' Generate Trimple Ship report
                i = objCellStarMisc.GenerateTrimbleShipRpt(Me.dtpShipFromDate.Text, Me.dtpShipToDate.Text)

                If i = 0 Then
                    MessageBox.Show("No record found for this report.", "Trimble Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    Me.MinimizeBox = True
                End If

            Catch ex As Exception
                MsgBox("frmExcel.cmdcmdTrimbleShipRpt_Click:: " & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
                objCellStarMisc = Nothing
            End Try
        End Sub

        '*********************************************************
        Private Sub cmdTATWIPRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTATWIPRpt.Click
            Dim objCSMisc As New PSS.Data.Buisness.CellstarMisc()

            Try
                If Me.cmbTATCust.SelectedValue = 0 Then
                    MessageBox.Show("Please select Customer.", "Validate Customer", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                objCSMisc.GenerateTATWIPRptByCustProd(Me.cmbTATCust.SelectedValue, Me.cmbTATProd.SelectedValue)
                MessageBox.Show("Completed.", "Confirm Message", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Generate TAT WIP Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objCSMisc = Nothing
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Me.MinimizeBox = True
            End Try
        End Sub

        '*********************************************************

    End Class
End Namespace