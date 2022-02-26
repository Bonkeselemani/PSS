Public Class frmLocOptInfo
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblMain As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQtyCoffin As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyMaster As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyOverpack As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyPallett As System.Windows.Forms.TextBox
    Friend WithEvents cbCoffin As System.Windows.Forms.CheckBox
    Friend WithEvents cbMaster As System.Windows.Forms.CheckBox
    Friend WithEvents cbOverpack As System.Windows.Forms.CheckBox
    Friend WithEvents cbPallett As System.Windows.Forms.CheckBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cboPrinterCoffin As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboPrinterMaster As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboPrinterPallett As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboPrinterOverpack As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tbStandard As System.Windows.Forms.TabPage
    Friend WithEvents tbRUR As System.Windows.Forms.TabPage
    Friend WithEvents tbNER As System.Windows.Forms.TabPage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboPrinterPallett1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtQtyCoffin1 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtQtyMaster1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtQtyOverpack1 As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyPallett1 As System.Windows.Forms.TextBox
    Friend WithEvents cboPrinterCoffin1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cbCoffin1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbMaster1 As System.Windows.Forms.CheckBox
    Friend WithEvents cboPrinterMaster1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cbOverpack1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cboPrinterOverpack1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cbPallett1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cboPrinterPallett2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtQtyCoffin2 As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents txtQtyMaster2 As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtQtyOverpack2 As System.Windows.Forms.TextBox
    Friend WithEvents txtQtyPallett2 As System.Windows.Forms.TextBox
    Friend WithEvents cboPrinterCoffin2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents cbCoffin2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbMaster2 As System.Windows.Forms.CheckBox
    Friend WithEvents cboPrinterMaster2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cbOverpack2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents cboPrinterOverpack2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cbPallett2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cbManMaster1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbManOverpack1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbManPallett1 As System.Windows.Forms.CheckBox
    Friend WithEvents cbManMaster2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbManOverpack2 As System.Windows.Forms.CheckBox
    Friend WithEvents cbManPallett2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cbManMaster As System.Windows.Forms.CheckBox
    Friend WithEvents cbManOverpack As System.Windows.Forms.CheckBox
    Friend WithEvents cbManPallett As System.Windows.Forms.CheckBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents cboManifestMaster1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManifestMaster2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManifestMaster As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManifestOverpack As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManifestOverpack1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManifestOverpack2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManifestPallett As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManifestPallett1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboManifestPallett2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelCoffin2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelMaster2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelOverpack2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelPallett2 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelCoffin1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelMaster1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelOverpack1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelPallett1 As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelCoffin As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelMaster As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelOverpack As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboLabelPallett As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblMain = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtQtyCoffin = New System.Windows.Forms.TextBox()
        Me.txtQtyMaster = New System.Windows.Forms.TextBox()
        Me.txtQtyOverpack = New System.Windows.Forms.TextBox()
        Me.txtQtyPallett = New System.Windows.Forms.TextBox()
        Me.cbCoffin = New System.Windows.Forms.CheckBox()
        Me.cbMaster = New System.Windows.Forms.CheckBox()
        Me.cbOverpack = New System.Windows.Forms.CheckBox()
        Me.cbPallett = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cboPrinterCoffin = New PSS.Gui.Controls.ComboBox()
        Me.cboPrinterMaster = New PSS.Gui.Controls.ComboBox()
        Me.cboPrinterOverpack = New PSS.Gui.Controls.ComboBox()
        Me.cboPrinterPallett = New PSS.Gui.Controls.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tbStandard = New System.Windows.Forms.TabPage()
        Me.cboManifestMaster = New PSS.Gui.Controls.ComboBox()
        Me.cbManMaster = New System.Windows.Forms.CheckBox()
        Me.cbManOverpack = New System.Windows.Forms.CheckBox()
        Me.cbManPallett = New System.Windows.Forms.CheckBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.tbRUR = New System.Windows.Forms.TabPage()
        Me.cboManifestMaster1 = New PSS.Gui.Controls.ComboBox()
        Me.cbManMaster1 = New System.Windows.Forms.CheckBox()
        Me.cbManOverpack1 = New System.Windows.Forms.CheckBox()
        Me.cbManPallett1 = New System.Windows.Forms.CheckBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboPrinterPallett1 = New PSS.Gui.Controls.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtQtyCoffin1 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtQtyMaster1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtQtyOverpack1 = New System.Windows.Forms.TextBox()
        Me.txtQtyPallett1 = New System.Windows.Forms.TextBox()
        Me.cboPrinterCoffin1 = New PSS.Gui.Controls.ComboBox()
        Me.cbCoffin1 = New System.Windows.Forms.CheckBox()
        Me.cbMaster1 = New System.Windows.Forms.CheckBox()
        Me.cboPrinterMaster1 = New PSS.Gui.Controls.ComboBox()
        Me.cbOverpack1 = New System.Windows.Forms.CheckBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cboPrinterOverpack1 = New PSS.Gui.Controls.ComboBox()
        Me.cbPallett1 = New System.Windows.Forms.CheckBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.tbNER = New System.Windows.Forms.TabPage()
        Me.cboManifestMaster2 = New PSS.Gui.Controls.ComboBox()
        Me.cbManMaster2 = New System.Windows.Forms.CheckBox()
        Me.cbManOverpack2 = New System.Windows.Forms.CheckBox()
        Me.cbManPallett2 = New System.Windows.Forms.CheckBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cboPrinterPallett2 = New PSS.Gui.Controls.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtQtyCoffin2 = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtQtyMaster2 = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtQtyOverpack2 = New System.Windows.Forms.TextBox()
        Me.txtQtyPallett2 = New System.Windows.Forms.TextBox()
        Me.cboPrinterCoffin2 = New PSS.Gui.Controls.ComboBox()
        Me.cbCoffin2 = New System.Windows.Forms.CheckBox()
        Me.cbMaster2 = New System.Windows.Forms.CheckBox()
        Me.cboPrinterMaster2 = New PSS.Gui.Controls.ComboBox()
        Me.cbOverpack2 = New System.Windows.Forms.CheckBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.cboPrinterOverpack2 = New PSS.Gui.Controls.ComboBox()
        Me.cbPallett2 = New System.Windows.Forms.CheckBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cboManifestOverpack = New PSS.Gui.Controls.ComboBox()
        Me.cboManifestOverpack1 = New PSS.Gui.Controls.ComboBox()
        Me.cboManifestOverpack2 = New PSS.Gui.Controls.ComboBox()
        Me.cboManifestPallett = New PSS.Gui.Controls.ComboBox()
        Me.cboManifestPallett1 = New PSS.Gui.Controls.ComboBox()
        Me.cboManifestPallett2 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelCoffin2 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelMaster2 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelOverpack2 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelPallett2 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelCoffin1 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelMaster1 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelOverpack1 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelPallett1 = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelCoffin = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelMaster = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelOverpack = New PSS.Gui.Controls.ComboBox()
        Me.cboLabelPallett = New PSS.Gui.Controls.ComboBox()
        Me.TabControl1.SuspendLayout()
        Me.tbStandard.SuspendLayout()
        Me.tbRUR.SuspendLayout()
        Me.tbNER.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(616, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 66
        Me.Button1.Text = "&SAVE"
        '
        'lblMain
        '
        Me.lblMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMain.Location = New System.Drawing.Point(8, 8)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(280, 24)
        Me.lblMain.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(320, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 16)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "LABEL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(480, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "QTY"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(528, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 100
        Me.Label3.Text = "PRINT"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(576, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "PRINTER NAME"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(24, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "COFFIN"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(24, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "MASTER"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(24, 184)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 100
        Me.Label7.Text = "OVERPACK"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(24, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "PALLETT"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQtyCoffin
        '
        Me.txtQtyCoffin.Location = New System.Drawing.Point(480, 88)
        Me.txtQtyCoffin.Name = "txtQtyCoffin"
        Me.txtQtyCoffin.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyCoffin.TabIndex = 1
        Me.txtQtyCoffin.Text = ""
        '
        'txtQtyMaster
        '
        Me.txtQtyMaster.Location = New System.Drawing.Point(480, 136)
        Me.txtQtyMaster.Name = "txtQtyMaster"
        Me.txtQtyMaster.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyMaster.TabIndex = 7
        Me.txtQtyMaster.Text = ""
        '
        'txtQtyOverpack
        '
        Me.txtQtyOverpack.Location = New System.Drawing.Point(480, 184)
        Me.txtQtyOverpack.Name = "txtQtyOverpack"
        Me.txtQtyOverpack.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyOverpack.TabIndex = 13
        Me.txtQtyOverpack.Text = ""
        '
        'txtQtyPallett
        '
        Me.txtQtyPallett.Location = New System.Drawing.Point(480, 232)
        Me.txtQtyPallett.Name = "txtQtyPallett"
        Me.txtQtyPallett.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyPallett.TabIndex = 19
        Me.txtQtyPallett.Text = ""
        '
        'cbCoffin
        '
        Me.cbCoffin.BackColor = System.Drawing.Color.SteelBlue
        Me.cbCoffin.Location = New System.Drawing.Point(544, 88)
        Me.cbCoffin.Name = "cbCoffin"
        Me.cbCoffin.Size = New System.Drawing.Size(24, 24)
        Me.cbCoffin.TabIndex = 2
        '
        'cbMaster
        '
        Me.cbMaster.BackColor = System.Drawing.Color.SteelBlue
        Me.cbMaster.Location = New System.Drawing.Point(544, 136)
        Me.cbMaster.Name = "cbMaster"
        Me.cbMaster.Size = New System.Drawing.Size(24, 24)
        Me.cbMaster.TabIndex = 8
        '
        'cbOverpack
        '
        Me.cbOverpack.BackColor = System.Drawing.Color.SteelBlue
        Me.cbOverpack.Location = New System.Drawing.Point(544, 184)
        Me.cbOverpack.Name = "cbOverpack"
        Me.cbOverpack.Size = New System.Drawing.Size(24, 24)
        Me.cbOverpack.TabIndex = 14
        '
        'cbPallett
        '
        Me.cbPallett.BackColor = System.Drawing.Color.SteelBlue
        Me.cbPallett.Location = New System.Drawing.Point(544, 232)
        Me.cbPallett.Name = "cbPallett"
        Me.cbPallett.Size = New System.Drawing.Size(24, 24)
        Me.cbPallett.TabIndex = 20
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(712, 368)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 67
        Me.Button2.Text = "CLOSE"
        '
        'cboPrinterCoffin
        '
        Me.cboPrinterCoffin.AutoComplete = True
        Me.cboPrinterCoffin.Location = New System.Drawing.Point(576, 88)
        Me.cboPrinterCoffin.Name = "cboPrinterCoffin"
        Me.cboPrinterCoffin.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterCoffin.TabIndex = 3
        '
        'cboPrinterMaster
        '
        Me.cboPrinterMaster.AutoComplete = True
        Me.cboPrinterMaster.Location = New System.Drawing.Point(576, 136)
        Me.cboPrinterMaster.Name = "cboPrinterMaster"
        Me.cboPrinterMaster.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterMaster.TabIndex = 9
        '
        'cboPrinterOverpack
        '
        Me.cboPrinterOverpack.AutoComplete = True
        Me.cboPrinterOverpack.Location = New System.Drawing.Point(576, 184)
        Me.cboPrinterOverpack.Name = "cboPrinterOverpack"
        Me.cboPrinterOverpack.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterOverpack.TabIndex = 15
        '
        'cboPrinterPallett
        '
        Me.cboPrinterPallett.AutoComplete = True
        Me.cboPrinterPallett.Location = New System.Drawing.Point(576, 232)
        Me.cboPrinterPallett.Name = "cboPrinterPallett"
        Me.cboPrinterPallett.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterPallett.TabIndex = 21
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.SteelBlue
        Me.Label11.Location = New System.Drawing.Point(16, 80)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(736, 40)
        Me.Label11.TabIndex = 107
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.Location = New System.Drawing.Point(16, 128)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(736, 40)
        Me.Label12.TabIndex = 108
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.SteelBlue
        Me.Label13.Location = New System.Drawing.Point(16, 176)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(736, 40)
        Me.Label13.TabIndex = 109
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.Location = New System.Drawing.Point(16, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(736, 40)
        Me.Label14.TabIndex = 110
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(112, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(144, 16)
        Me.Label17.TabIndex = 113
        Me.Label17.Text = "MANIFEST"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabControl1
        '
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbStandard, Me.tbRUR, Me.tbNER})
        Me.TabControl1.Location = New System.Drawing.Point(8, 48)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(776, 304)
        Me.TabControl1.TabIndex = 3
        '
        'tbStandard
        '
        Me.tbStandard.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLabelPallett, Me.cboLabelOverpack, Me.cboLabelMaster, Me.cboLabelCoffin, Me.cboManifestPallett, Me.cboManifestOverpack, Me.cboManifestMaster, Me.cbManMaster, Me.cbManOverpack, Me.cbManPallett, Me.Label44, Me.lblName, Me.Label7, Me.cboPrinterPallett, Me.Label4, Me.Label17, Me.Label5, Me.txtQtyCoffin, Me.Label6, Me.txtQtyMaster, Me.Label1, Me.Label8, Me.txtQtyOverpack, Me.txtQtyPallett, Me.cboPrinterCoffin, Me.cbCoffin, Me.cbMaster, Me.cboPrinterMaster, Me.cbOverpack, Me.Label2, Me.cboPrinterOverpack, Me.cbPallett, Me.Label3, Me.Label11, Me.Label12, Me.Label13, Me.Label14})
        Me.tbStandard.Location = New System.Drawing.Point(4, 22)
        Me.tbStandard.Name = "tbStandard"
        Me.tbStandard.Size = New System.Drawing.Size(768, 278)
        Me.tbStandard.TabIndex = 0
        Me.tbStandard.Text = "Standard"
        '
        'cboManifestMaster
        '
        Me.cboManifestMaster.AutoComplete = True
        Me.cboManifestMaster.Location = New System.Drawing.Point(104, 136)
        Me.cboManifestMaster.Name = "cboManifestMaster"
        Me.cboManifestMaster.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestMaster.TabIndex = 4
        '
        'cbManMaster
        '
        Me.cbManMaster.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManMaster.Location = New System.Drawing.Point(280, 136)
        Me.cbManMaster.Name = "cbManMaster"
        Me.cbManMaster.Size = New System.Drawing.Size(24, 24)
        Me.cbManMaster.TabIndex = 5
        '
        'cbManOverpack
        '
        Me.cbManOverpack.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManOverpack.Location = New System.Drawing.Point(280, 184)
        Me.cbManOverpack.Name = "cbManOverpack"
        Me.cbManOverpack.Size = New System.Drawing.Size(24, 24)
        Me.cbManOverpack.TabIndex = 11
        '
        'cbManPallett
        '
        Me.cbManPallett.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManPallett.Location = New System.Drawing.Point(280, 232)
        Me.cbManPallett.Name = "cbManPallett"
        Me.cbManPallett.Size = New System.Drawing.Size(24, 24)
        Me.cbManPallett.TabIndex = 17
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(264, 64)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(48, 16)
        Me.Label44.TabIndex = 156
        Me.Label44.Text = "PRINT"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(16, 24)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(120, 24)
        Me.lblName.TabIndex = 118
        Me.lblName.Text = "STANDARD"
        '
        'tbRUR
        '
        Me.tbRUR.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLabelPallett1, Me.cboLabelOverpack1, Me.cboLabelMaster1, Me.cboLabelCoffin1, Me.cboManifestPallett1, Me.cboManifestOverpack1, Me.cboManifestMaster1, Me.cbManMaster1, Me.cbManOverpack1, Me.cbManPallett1, Me.Label42, Me.Label40, Me.Label9, Me.cboPrinterPallett1, Me.Label10, Me.Label15, Me.Label16, Me.txtQtyCoffin1, Me.Label18, Me.txtQtyMaster1, Me.Label20, Me.Label21, Me.txtQtyOverpack1, Me.txtQtyPallett1, Me.cboPrinterCoffin1, Me.cbCoffin1, Me.cbMaster1, Me.cboPrinterMaster1, Me.cbOverpack1, Me.Label25, Me.cboPrinterOverpack1, Me.cbPallett1, Me.Label26, Me.Label19, Me.Label22, Me.Label24, Me.Label23})
        Me.tbRUR.Location = New System.Drawing.Point(4, 22)
        Me.tbRUR.Name = "tbRUR"
        Me.tbRUR.Size = New System.Drawing.Size(768, 278)
        Me.tbRUR.TabIndex = 1
        Me.tbRUR.Text = "RUR"
        '
        'cboManifestMaster1
        '
        Me.cboManifestMaster1.AutoComplete = True
        Me.cboManifestMaster1.Location = New System.Drawing.Point(104, 136)
        Me.cboManifestMaster1.Name = "cboManifestMaster1"
        Me.cboManifestMaster1.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestMaster1.TabIndex = 26
        '
        'cbManMaster1
        '
        Me.cbManMaster1.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManMaster1.Location = New System.Drawing.Point(280, 136)
        Me.cbManMaster1.Name = "cbManMaster1"
        Me.cbManMaster1.Size = New System.Drawing.Size(24, 24)
        Me.cbManMaster1.TabIndex = 27
        '
        'cbManOverpack1
        '
        Me.cbManOverpack1.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManOverpack1.Location = New System.Drawing.Point(280, 184)
        Me.cbManOverpack1.Name = "cbManOverpack1"
        Me.cbManOverpack1.Size = New System.Drawing.Size(24, 24)
        Me.cbManOverpack1.TabIndex = 33
        '
        'cbManPallett1
        '
        Me.cbManPallett1.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManPallett1.Location = New System.Drawing.Point(280, 232)
        Me.cbManPallett1.Name = "cbManPallett1"
        Me.cbManPallett1.Size = New System.Drawing.Size(24, 24)
        Me.cbManPallett1.TabIndex = 39
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(264, 64)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(48, 16)
        Me.Label42.TabIndex = 151
        Me.Label42.Text = "PRINT"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label40
        '
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(16, 24)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(120, 24)
        Me.Label40.TabIndex = 150
        Me.Label40.Text = "RUR"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(24, 184)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 137
        Me.Label9.Text = "OVERPACK"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPrinterPallett1
        '
        Me.cboPrinterPallett1.AutoComplete = True
        Me.cboPrinterPallett1.Location = New System.Drawing.Point(576, 232)
        Me.cboPrinterPallett1.Name = "cboPrinterPallett1"
        Me.cboPrinterPallett1.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterPallett1.TabIndex = 43
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(576, 64)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 16)
        Me.Label10.TabIndex = 134
        Me.Label10.Text = "PRINTER NAME"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(112, 64)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(144, 16)
        Me.Label15.TabIndex = 146
        Me.Label15.Text = "MANIFEST"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.SteelBlue
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(24, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 16)
        Me.Label16.TabIndex = 132
        Me.Label16.Text = "COFFIN"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQtyCoffin1
        '
        Me.txtQtyCoffin1.Location = New System.Drawing.Point(480, 88)
        Me.txtQtyCoffin1.Name = "txtQtyCoffin1"
        Me.txtQtyCoffin1.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyCoffin1.TabIndex = 23
        Me.txtQtyCoffin1.Text = ""
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.SteelBlue
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(24, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 16)
        Me.Label18.TabIndex = 133
        Me.Label18.Text = "MASTER"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQtyMaster1
        '
        Me.txtQtyMaster1.Location = New System.Drawing.Point(480, 136)
        Me.txtQtyMaster1.Name = "txtQtyMaster1"
        Me.txtQtyMaster1.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyMaster1.TabIndex = 29
        Me.txtQtyMaster1.Text = ""
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(320, 64)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(152, 16)
        Me.Label20.TabIndex = 136
        Me.Label20.Text = "LABEL"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.SteelBlue
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(24, 232)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(72, 16)
        Me.Label21.TabIndex = 135
        Me.Label21.Text = "PALLETT"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQtyOverpack1
        '
        Me.txtQtyOverpack1.Location = New System.Drawing.Point(480, 184)
        Me.txtQtyOverpack1.Name = "txtQtyOverpack1"
        Me.txtQtyOverpack1.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyOverpack1.TabIndex = 35
        Me.txtQtyOverpack1.Text = ""
        '
        'txtQtyPallett1
        '
        Me.txtQtyPallett1.Location = New System.Drawing.Point(480, 232)
        Me.txtQtyPallett1.Name = "txtQtyPallett1"
        Me.txtQtyPallett1.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyPallett1.TabIndex = 41
        Me.txtQtyPallett1.Text = ""
        '
        'cboPrinterCoffin1
        '
        Me.cboPrinterCoffin1.AutoComplete = True
        Me.cboPrinterCoffin1.Location = New System.Drawing.Point(576, 88)
        Me.cboPrinterCoffin1.Name = "cboPrinterCoffin1"
        Me.cboPrinterCoffin1.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterCoffin1.TabIndex = 25
        '
        'cbCoffin1
        '
        Me.cbCoffin1.BackColor = System.Drawing.Color.SteelBlue
        Me.cbCoffin1.Location = New System.Drawing.Point(544, 88)
        Me.cbCoffin1.Name = "cbCoffin1"
        Me.cbCoffin1.Size = New System.Drawing.Size(24, 24)
        Me.cbCoffin1.TabIndex = 24
        '
        'cbMaster1
        '
        Me.cbMaster1.BackColor = System.Drawing.Color.SteelBlue
        Me.cbMaster1.Location = New System.Drawing.Point(544, 136)
        Me.cbMaster1.Name = "cbMaster1"
        Me.cbMaster1.Size = New System.Drawing.Size(24, 24)
        Me.cbMaster1.TabIndex = 30
        '
        'cboPrinterMaster1
        '
        Me.cboPrinterMaster1.AutoComplete = True
        Me.cboPrinterMaster1.Location = New System.Drawing.Point(576, 136)
        Me.cboPrinterMaster1.Name = "cboPrinterMaster1"
        Me.cboPrinterMaster1.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterMaster1.TabIndex = 31
        '
        'cbOverpack1
        '
        Me.cbOverpack1.BackColor = System.Drawing.Color.SteelBlue
        Me.cbOverpack1.Location = New System.Drawing.Point(544, 184)
        Me.cbOverpack1.Name = "cbOverpack1"
        Me.cbOverpack1.Size = New System.Drawing.Size(24, 24)
        Me.cbOverpack1.TabIndex = 36
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(480, 64)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 16)
        Me.Label25.TabIndex = 130
        Me.Label25.Text = "QTY"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPrinterOverpack1
        '
        Me.cboPrinterOverpack1.AutoComplete = True
        Me.cboPrinterOverpack1.Location = New System.Drawing.Point(576, 184)
        Me.cboPrinterOverpack1.Name = "cboPrinterOverpack1"
        Me.cboPrinterOverpack1.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterOverpack1.TabIndex = 37
        '
        'cbPallett1
        '
        Me.cbPallett1.BackColor = System.Drawing.Color.SteelBlue
        Me.cbPallett1.Location = New System.Drawing.Point(544, 232)
        Me.cbPallett1.Name = "cbPallett1"
        Me.cbPallett1.Size = New System.Drawing.Size(24, 24)
        Me.cbPallett1.TabIndex = 42
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(528, 64)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(48, 16)
        Me.Label26.TabIndex = 131
        Me.Label26.Text = "PRINT"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.SteelBlue
        Me.Label19.Location = New System.Drawing.Point(16, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(736, 40)
        Me.Label19.TabIndex = 142
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.SteelBlue
        Me.Label22.Location = New System.Drawing.Point(16, 128)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(736, 40)
        Me.Label22.TabIndex = 143
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.SteelBlue
        Me.Label24.Location = New System.Drawing.Point(16, 176)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(736, 40)
        Me.Label24.TabIndex = 144
        '
        'Label23
        '
        Me.Label23.BackColor = System.Drawing.Color.SteelBlue
        Me.Label23.Location = New System.Drawing.Point(16, 224)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(736, 40)
        Me.Label23.TabIndex = 145
        '
        'tbNER
        '
        Me.tbNER.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLabelPallett2, Me.cboLabelOverpack2, Me.cboLabelMaster2, Me.cboLabelCoffin2, Me.cboManifestPallett2, Me.cboManifestOverpack2, Me.cboManifestMaster2, Me.cbManMaster2, Me.cbManOverpack2, Me.cbManPallett2, Me.Label43, Me.Label41, Me.Label27, Me.cboPrinterPallett2, Me.Label28, Me.Label29, Me.Label30, Me.txtQtyCoffin2, Me.Label31, Me.txtQtyMaster2, Me.Label33, Me.Label34, Me.txtQtyOverpack2, Me.txtQtyPallett2, Me.cboPrinterCoffin2, Me.cbCoffin2, Me.cbMaster2, Me.cboPrinterMaster2, Me.cbOverpack2, Me.Label38, Me.cboPrinterOverpack2, Me.cbPallett2, Me.Label39, Me.Label32, Me.Label35, Me.Label37, Me.Label36})
        Me.tbNER.Location = New System.Drawing.Point(4, 22)
        Me.tbNER.Name = "tbNER"
        Me.tbNER.Size = New System.Drawing.Size(768, 278)
        Me.tbNER.TabIndex = 2
        Me.tbNER.Text = "NER"
        '
        'cboManifestMaster2
        '
        Me.cboManifestMaster2.AutoComplete = True
        Me.cboManifestMaster2.Location = New System.Drawing.Point(104, 136)
        Me.cboManifestMaster2.Name = "cboManifestMaster2"
        Me.cboManifestMaster2.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestMaster2.TabIndex = 48
        '
        'cbManMaster2
        '
        Me.cbManMaster2.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManMaster2.Location = New System.Drawing.Point(280, 136)
        Me.cbManMaster2.Name = "cbManMaster2"
        Me.cbManMaster2.Size = New System.Drawing.Size(24, 24)
        Me.cbManMaster2.TabIndex = 49
        '
        'cbManOverpack2
        '
        Me.cbManOverpack2.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManOverpack2.Location = New System.Drawing.Point(280, 184)
        Me.cbManOverpack2.Name = "cbManOverpack2"
        Me.cbManOverpack2.Size = New System.Drawing.Size(24, 24)
        Me.cbManOverpack2.TabIndex = 55
        '
        'cbManPallett2
        '
        Me.cbManPallett2.BackColor = System.Drawing.Color.SteelBlue
        Me.cbManPallett2.Location = New System.Drawing.Point(280, 232)
        Me.cbManPallett2.Name = "cbManPallett2"
        Me.cbManPallett2.Size = New System.Drawing.Size(24, 24)
        Me.cbManPallett2.TabIndex = 61
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(264, 64)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(48, 16)
        Me.Label43.TabIndex = 156
        Me.Label43.Text = "PRINT"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label41
        '
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(16, 24)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(120, 24)
        Me.Label41.TabIndex = 151
        Me.Label41.Text = "NER"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.SteelBlue
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(24, 184)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(72, 16)
        Me.Label27.TabIndex = 137
        Me.Label27.Text = "OVERPACK"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPrinterPallett2
        '
        Me.cboPrinterPallett2.AutoComplete = True
        Me.cboPrinterPallett2.Location = New System.Drawing.Point(576, 232)
        Me.cboPrinterPallett2.Name = "cboPrinterPallett2"
        Me.cboPrinterPallett2.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterPallett2.TabIndex = 65
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(576, 64)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(120, 16)
        Me.Label28.TabIndex = 134
        Me.Label28.Text = "PRINTER NAME"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(104, 64)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(160, 16)
        Me.Label29.TabIndex = 146
        Me.Label29.Text = "MANIFEST"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label30
        '
        Me.Label30.BackColor = System.Drawing.Color.SteelBlue
        Me.Label30.ForeColor = System.Drawing.Color.White
        Me.Label30.Location = New System.Drawing.Point(24, 88)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(72, 16)
        Me.Label30.TabIndex = 132
        Me.Label30.Text = "COFFIN"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQtyCoffin2
        '
        Me.txtQtyCoffin2.Location = New System.Drawing.Point(480, 88)
        Me.txtQtyCoffin2.Name = "txtQtyCoffin2"
        Me.txtQtyCoffin2.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyCoffin2.TabIndex = 45
        Me.txtQtyCoffin2.Text = ""
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.SteelBlue
        Me.Label31.ForeColor = System.Drawing.Color.White
        Me.Label31.Location = New System.Drawing.Point(24, 136)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(72, 16)
        Me.Label31.TabIndex = 133
        Me.Label31.Text = "MASTER"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQtyMaster2
        '
        Me.txtQtyMaster2.Location = New System.Drawing.Point(480, 136)
        Me.txtQtyMaster2.Name = "txtQtyMaster2"
        Me.txtQtyMaster2.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyMaster2.TabIndex = 51
        Me.txtQtyMaster2.Text = ""
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(320, 64)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(152, 16)
        Me.Label33.TabIndex = 136
        Me.Label33.Text = "LABEL"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.SteelBlue
        Me.Label34.ForeColor = System.Drawing.Color.White
        Me.Label34.Location = New System.Drawing.Point(24, 232)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(72, 16)
        Me.Label34.TabIndex = 135
        Me.Label34.Text = "PALLETT"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtQtyOverpack2
        '
        Me.txtQtyOverpack2.Location = New System.Drawing.Point(480, 184)
        Me.txtQtyOverpack2.Name = "txtQtyOverpack2"
        Me.txtQtyOverpack2.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyOverpack2.TabIndex = 57
        Me.txtQtyOverpack2.Text = ""
        '
        'txtQtyPallett2
        '
        Me.txtQtyPallett2.Location = New System.Drawing.Point(480, 232)
        Me.txtQtyPallett2.Name = "txtQtyPallett2"
        Me.txtQtyPallett2.Size = New System.Drawing.Size(40, 20)
        Me.txtQtyPallett2.TabIndex = 63
        Me.txtQtyPallett2.Text = ""
        '
        'cboPrinterCoffin2
        '
        Me.cboPrinterCoffin2.AutoComplete = True
        Me.cboPrinterCoffin2.Location = New System.Drawing.Point(576, 88)
        Me.cboPrinterCoffin2.Name = "cboPrinterCoffin2"
        Me.cboPrinterCoffin2.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterCoffin2.TabIndex = 47
        '
        'cbCoffin2
        '
        Me.cbCoffin2.BackColor = System.Drawing.Color.SteelBlue
        Me.cbCoffin2.Location = New System.Drawing.Point(544, 88)
        Me.cbCoffin2.Name = "cbCoffin2"
        Me.cbCoffin2.Size = New System.Drawing.Size(24, 24)
        Me.cbCoffin2.TabIndex = 46
        '
        'cbMaster2
        '
        Me.cbMaster2.BackColor = System.Drawing.Color.SteelBlue
        Me.cbMaster2.Location = New System.Drawing.Point(544, 136)
        Me.cbMaster2.Name = "cbMaster2"
        Me.cbMaster2.Size = New System.Drawing.Size(24, 24)
        Me.cbMaster2.TabIndex = 52
        '
        'cboPrinterMaster2
        '
        Me.cboPrinterMaster2.AutoComplete = True
        Me.cboPrinterMaster2.Location = New System.Drawing.Point(576, 136)
        Me.cboPrinterMaster2.Name = "cboPrinterMaster2"
        Me.cboPrinterMaster2.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterMaster2.TabIndex = 53
        '
        'cbOverpack2
        '
        Me.cbOverpack2.BackColor = System.Drawing.Color.SteelBlue
        Me.cbOverpack2.Location = New System.Drawing.Point(544, 184)
        Me.cbOverpack2.Name = "cbOverpack2"
        Me.cbOverpack2.Size = New System.Drawing.Size(24, 24)
        Me.cbOverpack2.TabIndex = 58
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(480, 64)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(40, 16)
        Me.Label38.TabIndex = 130
        Me.Label38.Text = "QTY"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboPrinterOverpack2
        '
        Me.cboPrinterOverpack2.AutoComplete = True
        Me.cboPrinterOverpack2.Location = New System.Drawing.Point(576, 184)
        Me.cboPrinterOverpack2.Name = "cboPrinterOverpack2"
        Me.cboPrinterOverpack2.Size = New System.Drawing.Size(168, 21)
        Me.cboPrinterOverpack2.TabIndex = 59
        '
        'cbPallett2
        '
        Me.cbPallett2.BackColor = System.Drawing.Color.SteelBlue
        Me.cbPallett2.Location = New System.Drawing.Point(544, 232)
        Me.cbPallett2.Name = "cbPallett2"
        Me.cbPallett2.Size = New System.Drawing.Size(24, 24)
        Me.cbPallett2.TabIndex = 64
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(528, 64)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(48, 16)
        Me.Label39.TabIndex = 131
        Me.Label39.Text = "PRINT"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label32
        '
        Me.Label32.BackColor = System.Drawing.Color.SteelBlue
        Me.Label32.Location = New System.Drawing.Point(16, 80)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(736, 40)
        Me.Label32.TabIndex = 142
        '
        'Label35
        '
        Me.Label35.BackColor = System.Drawing.Color.SteelBlue
        Me.Label35.Location = New System.Drawing.Point(16, 128)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(736, 40)
        Me.Label35.TabIndex = 143
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.SteelBlue
        Me.Label37.Location = New System.Drawing.Point(16, 176)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(736, 40)
        Me.Label37.TabIndex = 144
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.SteelBlue
        Me.Label36.Location = New System.Drawing.Point(16, 224)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(736, 40)
        Me.Label36.TabIndex = 145
        '
        'cboManifestOverpack
        '
        Me.cboManifestOverpack.AutoComplete = True
        Me.cboManifestOverpack.Location = New System.Drawing.Point(104, 184)
        Me.cboManifestOverpack.Name = "cboManifestOverpack"
        Me.cboManifestOverpack.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestOverpack.TabIndex = 10
        '
        'cboManifestOverpack1
        '
        Me.cboManifestOverpack1.AutoComplete = True
        Me.cboManifestOverpack1.Location = New System.Drawing.Point(104, 184)
        Me.cboManifestOverpack1.Name = "cboManifestOverpack1"
        Me.cboManifestOverpack1.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestOverpack1.TabIndex = 32
        '
        'cboManifestOverpack2
        '
        Me.cboManifestOverpack2.AutoComplete = True
        Me.cboManifestOverpack2.Location = New System.Drawing.Point(104, 184)
        Me.cboManifestOverpack2.Name = "cboManifestOverpack2"
        Me.cboManifestOverpack2.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestOverpack2.TabIndex = 54
        '
        'cboManifestPallett
        '
        Me.cboManifestPallett.AutoComplete = True
        Me.cboManifestPallett.Location = New System.Drawing.Point(104, 232)
        Me.cboManifestPallett.Name = "cboManifestPallett"
        Me.cboManifestPallett.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestPallett.TabIndex = 16
        '
        'cboManifestPallett1
        '
        Me.cboManifestPallett1.AutoComplete = True
        Me.cboManifestPallett1.Location = New System.Drawing.Point(104, 232)
        Me.cboManifestPallett1.Name = "cboManifestPallett1"
        Me.cboManifestPallett1.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestPallett1.TabIndex = 38
        '
        'cboManifestPallett2
        '
        Me.cboManifestPallett2.AutoComplete = True
        Me.cboManifestPallett2.Location = New System.Drawing.Point(104, 232)
        Me.cboManifestPallett2.Name = "cboManifestPallett2"
        Me.cboManifestPallett2.Size = New System.Drawing.Size(160, 21)
        Me.cboManifestPallett2.TabIndex = 60
        '
        'cboLabelCoffin2
        '
        Me.cboLabelCoffin2.AutoComplete = True
        Me.cboLabelCoffin2.Location = New System.Drawing.Point(312, 88)
        Me.cboLabelCoffin2.Name = "cboLabelCoffin2"
        Me.cboLabelCoffin2.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelCoffin2.TabIndex = 44
        '
        'cboLabelMaster2
        '
        Me.cboLabelMaster2.AutoComplete = True
        Me.cboLabelMaster2.Location = New System.Drawing.Point(312, 136)
        Me.cboLabelMaster2.Name = "cboLabelMaster2"
        Me.cboLabelMaster2.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelMaster2.TabIndex = 50
        '
        'cboLabelOverpack2
        '
        Me.cboLabelOverpack2.AutoComplete = True
        Me.cboLabelOverpack2.Location = New System.Drawing.Point(312, 184)
        Me.cboLabelOverpack2.Name = "cboLabelOverpack2"
        Me.cboLabelOverpack2.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelOverpack2.TabIndex = 56
        '
        'cboLabelPallett2
        '
        Me.cboLabelPallett2.AutoComplete = True
        Me.cboLabelPallett2.Location = New System.Drawing.Point(312, 232)
        Me.cboLabelPallett2.Name = "cboLabelPallett2"
        Me.cboLabelPallett2.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelPallett2.TabIndex = 62
        '
        'cboLabelCoffin1
        '
        Me.cboLabelCoffin1.AutoComplete = True
        Me.cboLabelCoffin1.Location = New System.Drawing.Point(312, 88)
        Me.cboLabelCoffin1.Name = "cboLabelCoffin1"
        Me.cboLabelCoffin1.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelCoffin1.TabIndex = 22
        '
        'cboLabelMaster1
        '
        Me.cboLabelMaster1.AutoComplete = True
        Me.cboLabelMaster1.Location = New System.Drawing.Point(312, 136)
        Me.cboLabelMaster1.Name = "cboLabelMaster1"
        Me.cboLabelMaster1.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelMaster1.TabIndex = 28
        '
        'cboLabelOverpack1
        '
        Me.cboLabelOverpack1.AutoComplete = True
        Me.cboLabelOverpack1.Location = New System.Drawing.Point(312, 184)
        Me.cboLabelOverpack1.Name = "cboLabelOverpack1"
        Me.cboLabelOverpack1.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelOverpack1.TabIndex = 34
        '
        'cboLabelPallett1
        '
        Me.cboLabelPallett1.AutoComplete = True
        Me.cboLabelPallett1.Location = New System.Drawing.Point(312, 232)
        Me.cboLabelPallett1.Name = "cboLabelPallett1"
        Me.cboLabelPallett1.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelPallett1.TabIndex = 40
        '
        'cboLabelCoffin
        '
        Me.cboLabelCoffin.AutoComplete = True
        Me.cboLabelCoffin.Location = New System.Drawing.Point(312, 88)
        Me.cboLabelCoffin.Name = "cboLabelCoffin"
        Me.cboLabelCoffin.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelCoffin.TabIndex = 0
        '
        'cboLabelMaster
        '
        Me.cboLabelMaster.AutoComplete = True
        Me.cboLabelMaster.Location = New System.Drawing.Point(312, 136)
        Me.cboLabelMaster.Name = "cboLabelMaster"
        Me.cboLabelMaster.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelMaster.TabIndex = 6
        '
        'cboLabelOverpack
        '
        Me.cboLabelOverpack.AutoComplete = True
        Me.cboLabelOverpack.Location = New System.Drawing.Point(312, 184)
        Me.cboLabelOverpack.Name = "cboLabelOverpack"
        Me.cboLabelOverpack.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelOverpack.TabIndex = 12
        '
        'cboLabelPallett
        '
        Me.cboLabelPallett.AutoComplete = True
        Me.cboLabelPallett.Location = New System.Drawing.Point(312, 232)
        Me.cboLabelPallett.Name = "cboLabelPallett"
        Me.cboLabelPallett.Size = New System.Drawing.Size(160, 21)
        Me.cboLabelPallett.TabIndex = 18
        '
        'frmLocOptInfo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.Button2, Me.lblMain, Me.Button1})
        Me.Name = "frmLocOptInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Optional Information"
        Me.TabControl1.ResumeLayout(False)
        Me.tbStandard.ResumeLayout(False)
        Me.tbRUR.ResumeLayout(False)
        Me.tbNER.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public intLocOptions As Int32
    Public strLocOptions As String

    Private strSQL As String
    Private blnUpdate As Boolean = False

    Dim dtPrinterCoffin As DataTable
    Dim dtPrinterMaster As DataTable
    Dim dtPrinterOverpack As DataTable
    Dim dtPrinterPallett As DataTable

    Dim dtPrinterCoffin1 As DataTable
    Dim dtPrinterMaster1 As DataTable
    Dim dtPrinterOverpack1 As DataTable
    Dim dtPrinterPallett1 As DataTable

    Dim dtPrinterCoffin2 As DataTable
    Dim dtPrinterMaster2 As DataTable
    Dim dtPrinterOverpack2 As DataTable
    Dim dtPrinterPallett2 As DataTable

    Dim arrLabel(100) As String
    Dim arrManifest(100) As String

    Private Sub frmLocOptInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'MsgBox(intLocOptions & "    " & strLocOptions)
        Me.txtQtyCoffin.Text = "1"  '//default value
        Me.txtQtyCoffin1.Text = "1"  '//default value
        Me.txtQtyCoffin2.Text = "1"  '//default value
        populatePrinters()
        GetData()

        populateLabelArray()
        populateManifestArray()

    End Sub

    Private Sub SaveData()

        If intLocOptions > 0 Then

            Dim strError As String = verifyData()
            If Len(Trim(strError)) > 0 Then
                MsgBox(strError & vbCrLf & vbCrLf & "Data has not been saved.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim strValField, strValData As String
            Dim blnInsert As Boolean

            strValField = ""
            strValData = ""
            strValField += "LocMap_ProcType, "
            strValData += "0, "
            If Len(Trim(cboManifestMaster.Text)) > 0 Then
                strValField += "LocMap_MasterManifest, "
                strValData += "'" & Trim(cboManifestMaster.Text) & "', "
            End If
            If Len(Trim(cboManifestOverpack.Text)) > 0 Then
                strValField += "LocMap_OverManifest, "
                strValData += "'" & Trim(cboManifestOverpack.Text) & "', "
            End If
            If Len(Trim(cboManifestPallett.Text)) > 0 Then
                strValField += "LocMap_PallettManifest, "
                strValData += "'" & Trim(cboManifestPallett.Text) & "', "
            End If
            If Len(Trim(cboLabelCoffin.Text)) > 0 Then
                strValField += "LocMap_CoffinLabel, "
                strValData += "'" & Trim(cboLabelCoffin.Text) & "', "
            End If
            If Len(Trim(cboLabelMaster.Text)) > 0 Then
                strValField += "LocMap_MasterLabel, "
                strValData += "'" & Trim(cboLabelMaster.Text) & "', "
            End If
            If Len(Trim(cboLabelOverpack.Text)) > 0 Then
                strValField += "LocMap_OverLabel, "
                strValData += "'" & Trim(cboLabelOverpack.Text) & "', "
            End If
            If Len(Trim(cboLabelPallett.Text)) > 0 Then
                strValField += "LocMap_PallettLabel, "
                strValData += "'" & Trim(cboLabelPallett.Text) & "', "
            End If
            If Len(Trim(txtQtyCoffin.Text)) > 0 Then
                strValField += "LocMap_CoffinQnt, "
                strValData += "'" & Trim(txtQtyCoffin.Text) & "', "
            End If
            If Len(Trim(txtQtyMaster.Text)) > 0 Then
                strValField += "LocMap_MasterQnt, "
                strValData += "'" & Trim(txtQtyMaster.Text) & "', "
            End If
            If Len(Trim(txtQtyOverpack.Text)) > 0 Then
                strValField += "LocMap_OverQnt, "
                strValData += "'" & Trim(txtQtyOverpack.Text) & "', "
            End If
            If Len(Trim(txtQtyPallett.Text)) > 0 Then
                strValField += "LocMap_PallettQnt, "
                strValData += "'" & Trim(txtQtyPallett.Text) & "', "
            End If
            If cbCoffin.Checked = True Then
                strValField += "LocMap_CoffinPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_CoffinPrt, "
                strValData += "0, "
            End If
            If cbMaster.Checked = True Then
                strValField += "LocMap_MasterLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_MasterLblPrt, "
                strValData += "0, "
            End If
            If cbOverpack.Checked = True Then
                strValField += "LocMap_OverLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_OverLblPrt, "
                strValData += "0, "
            End If
            If cbPallett.Checked = True Then
                strValField += "LocMap_PallettLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_PallettLblPrt, "
                strValData += "0, "
            End If

            If cbManMaster.Checked = True Then
                strValField += "LocMap_MasterManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_MasterManPrt, "
                strValData += "0, "
            End If
            If cbManOverpack.Checked = True Then
                strValField += "LocMap_OverManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_OverManPrt, "
                strValData += "0, "
            End If
            If cbManPallett.Checked = True Then
                strValField += "LocMap_PallettManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_PallettManPrt, "
                strValData += "0, "
            End If




            If Len(Trim(cboPrinterCoffin.Text)) > 0 Then
                strValField += "LocMap_CoffinPrinter_ID, "
                strValData += "'" & Trim(cboPrinterCoffin.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterMaster.Text)) > 0 Then
                strValField += "LocMap_MasterLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterMaster.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterOverpack.Text)) > 0 Then
                strValField += "LocMap_OverLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterOverpack.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterPallett.Text)) > 0 Then
                strValField += "LocMap_PallettLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterPallett.SelectedValue) & "', "
            End If

            '//ADD LOCATION ID
            strValField += "Loc_ID"
            strValData += CStr(intLocOptions)

            blnInsert = PSS.Data.Production.Joins.OrderEntryUpdateDelete("INSERT INTO tlocmap (" & strValField & ") VALUES (" & strValData & ")")

            Windows.Forms.Application.DoEvents()
            '********************************************************************************
            '********************************************************************************
            strValField = ""
            strValData = ""
            strValField += "LocMap_ProcType, "
            strValData += "1, "
            If Len(Trim(cboManifestMaster1.Text)) > 0 Then
                strValField += "LocMap_MasterManifest, "
                strValData += "'" & Trim(cboManifestMaster1.Text) & "', "
            End If
            If Len(Trim(cboManifestOverpack1.Text)) > 0 Then
                strValField += "LocMap_OverManifest, "
                strValData += "'" & Trim(cboManifestOverpack1.Text) & "', "
            End If
            If Len(Trim(cboManifestPallett1.Text)) > 0 Then
                strValField += "LocMap_PallettManifest, "
                strValData += "'" & Trim(cboManifestPallett1.Text) & "', "
            End If
            If Len(Trim(cboLabelCoffin1.Text)) > 0 Then
                strValField += "LocMap_CoffinLabel, "
                strValData += "'" & Trim(cboLabelCoffin1.Text) & "', "
            End If
            If Len(Trim(cboLabelMaster1.Text)) > 0 Then
                strValField += "LocMap_MasterLabel, "
                strValData += "'" & Trim(cboLabelMaster1.Text) & "', "
            End If
            If Len(Trim(cboLabelOverpack1.Text)) > 0 Then
                strValField += "LocMap_OverLabel, "
                strValData += "'" & Trim(cboLabelOverpack1.Text) & "', "
            End If
            If Len(Trim(cboLabelPallett1.Text)) > 0 Then
                strValField += "LocMap_PallettLabel, "
                strValData += "'" & Trim(cboLabelPallett1.Text) & "', "
            End If
            If Len(Trim(txtQtyCoffin1.Text)) > 0 Then
                strValField += "LocMap_CoffinQnt, "
                strValData += "'" & Trim(txtQtyCoffin1.Text) & "', "
            End If
            If Len(Trim(txtQtyMaster1.Text)) > 0 Then
                strValField += "LocMap_MasterQnt, "
                strValData += "'" & Trim(txtQtyMaster1.Text) & "', "
            End If
            If Len(Trim(txtQtyOverpack1.Text)) > 0 Then
                strValField += "LocMap_OverQnt, "
                strValData += "'" & Trim(txtQtyOverpack1.Text) & "', "
            End If
            If Len(Trim(txtQtyPallett1.Text)) > 0 Then
                strValField += "LocMap_PallettQnt, "
                strValData += "'" & Trim(txtQtyPallett1.Text) & "', "
            End If
            If cbCoffin1.Checked = True Then
                strValField += "LocMap_CoffinPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_CoffinPrt, "
                strValData += "0, "
            End If
            If cbMaster1.Checked = True Then
                strValField += "LocMap_MasterLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_MasterLblPrt, "
                strValData += "0, "
            End If
            If cbOverpack1.Checked = True Then
                strValField += "LocMap_OverLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_OverLblPrt, "
                strValData += "0, "
            End If
            If cbPallett1.Checked = True Then
                strValField += "LocMap_PallettLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_PallettLblPrt, "
                strValData += "0, "
            End If


            If cbManMaster1.Checked = True Then
                strValField += "LocMap_MasterManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_MasterManPrt, "
                strValData += "0, "
            End If
            If cbManOverpack1.Checked = True Then
                strValField += "LocMap_OverManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_OverManPrt, "
                strValData += "0, "
            End If
            If cbManPallett1.Checked = True Then
                strValField += "LocMap_PallettManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_PallettManPrt, "
                strValData += "0, "
            End If



            If Len(Trim(cboPrinterCoffin1.Text)) > 0 Then
                strValField += "LocMap_CoffinPrinter_ID, "
                strValData += "'" & Trim(cboPrinterCoffin1.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterMaster1.Text)) > 0 Then
                strValField += "LocMap_MasterLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterMaster1.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterOverpack1.Text)) > 0 Then
                strValField += "LocMap_OverLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterOverpack1.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterPallett1.Text)) > 0 Then
                strValField += "LocMap_PallettLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterPallett1.SelectedValue) & "', "
            End If

            '//ADD LOCATION ID
            strValField += "Loc_ID"
            strValData += CStr(intLocOptions)

            blnInsert = PSS.Data.Production.Joins.OrderEntryUpdateDelete("INSERT INTO tlocmap (" & strValField & ") VALUES (" & strValData & ")")

            Windows.Forms.Application.DoEvents()

            '********************************************************************************
            '********************************************************************************
            strValField = ""
            strValData = ""
            strValField += "LocMap_ProcType, "
            strValData += "2, "
            If Len(Trim(cboManifestMaster2.Text)) > 0 Then
                strValField += "LocMap_MasterManifest, "
                strValData += "'" & Trim(cboManifestMaster2.Text) & "', "
            End If
            If Len(Trim(cboManifestOverpack2.Text)) > 0 Then
                strValField += "LocMap_OverManifest, "
                strValData += "'" & Trim(cboManifestOverpack2.Text) & "', "
            End If
            If Len(Trim(cboManifestPallett2.Text)) > 0 Then
                strValField += "LocMap_PallettManifest, "
                strValData += "'" & Trim(cboManifestPallett2.Text) & "', "
            End If
            If Len(Trim(cboLabelCoffin2.Text)) > 0 Then
                strValField += "LocMap_CoffinLabel, "
                strValData += "'" & Trim(cboLabelCoffin2.Text) & "', "
            End If
            If Len(Trim(cboLabelMaster2.Text)) > 0 Then
                strValField += "LocMap_MasterLabel, "
                strValData += "'" & Trim(cboLabelMaster2.Text) & "', "
            End If
            If Len(Trim(cboLabelOverpack2.Text)) > 0 Then
                strValField += "LocMap_OverLabel, "
                strValData += "'" & Trim(cboLabelOverpack2.Text) & "', "
            End If
            If Len(Trim(cboLabelPallett2.Text)) > 0 Then
                strValField += "LocMap_PallettLabel, "
                strValData += "'" & Trim(cboLabelPallett2.Text) & "', "
            End If
            If Len(Trim(txtQtyCoffin2.Text)) > 0 Then
                strValField += "LocMap_CoffinQnt, "
                strValData += "'" & Trim(txtQtyCoffin2.Text) & "', "
            End If
            If Len(Trim(txtQtyMaster2.Text)) > 0 Then
                strValField += "LocMap_MasterQnt, "
                strValData += "'" & Trim(txtQtyMaster2.Text) & "', "
            End If
            If Len(Trim(txtQtyOverpack2.Text)) > 0 Then
                strValField += "LocMap_OverQnt, "
                strValData += "'" & Trim(txtQtyOverpack2.Text) & "', "
            End If
            If Len(Trim(txtQtyPallett2.Text)) > 0 Then
                strValField += "LocMap_PallettQnt, "
                strValData += "'" & Trim(txtQtyPallett2.Text) & "', "
            End If
            If cbCoffin2.Checked = True Then
                strValField += "LocMap_CoffinPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_CoffinPrt, "
                strValData += "0, "
            End If
            If cbMaster2.Checked = True Then
                strValField += "LocMap_MasterLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_MasterLblPrt, "
                strValData += "0, "
            End If
            If cbOverpack2.Checked = True Then
                strValField += "LocMap_OverLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_OverLblPrt, "
                strValData += "0, "
            End If
            If cbPallett2.Checked = True Then
                strValField += "LocMap_PallettLblPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_PallettLblPrt, "
                strValData += "0, "
            End If

            If cbManMaster2.Checked = True Then
                strValField += "LocMap_MasterManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_MasterManPrt, "
                strValData += "0, "
            End If
            If cbManOverpack2.Checked = True Then
                strValField += "LocMap_OverManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_OverManPrt, "
                strValData += "0, "
            End If
            If cbManPallett2.Checked = True Then
                strValField += "LocMap_PallettManPrt, "
                strValData += "1, "
            Else
                strValField += "LocMap_PallettManPrt, "
                strValData += "0, "
            End If


            If Len(Trim(cboPrinterCoffin2.Text)) > 0 Then
                strValField += "LocMap_CoffinPrinter_ID, "
                strValData += "'" & Trim(cboPrinterCoffin2.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterMaster2.Text)) > 0 Then
                strValField += "LocMap_MasterLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterMaster2.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterOverpack2.Text)) > 0 Then
                strValField += "LocMap_OverLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterOverpack2.SelectedValue) & "', "
            End If
            If Len(Trim(cboPrinterPallett2.Text)) > 0 Then
                strValField += "LocMap_PallettLblPrinter_ID, "
                strValData += "'" & Trim(cboPrinterPallett2.SelectedValue) & "', "
            End If

            '//ADD LOCATION ID
            strValField += "Loc_ID"
            strValData += CStr(intLocOptions)

            blnInsert = PSS.Data.Production.Joins.OrderEntryUpdateDelete("INSERT INTO tlocmap (" & strValField & ") VALUES (" & strValData & ")")

            Windows.Forms.Application.DoEvents()

            MsgBox("Update Complete", MsgBoxStyle.OKOnly, "Save Data")

        End If

    End Sub
    Private Sub UpdateData()

        If intLocOptions > 0 Then

            Dim strError As String = verifyData()
            If Len(Trim(strError)) > 0 Then
                MsgBox(strError & vbCrLf & vbCrLf & "Data has not been saved.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim strVal As String

            strVal = ""
            If Len(Trim(cboManifestMaster.Text)) > 0 Then
                strVal += "LocMap_MasterManifest = '" & Trim(cboManifestMaster.Text) & "', "
            End If
            If Len(Trim(cboManifestOverpack.Text)) > 0 Then
                strVal += "LocMap_OverManifest = '" & Trim(cboManifestOverpack.Text) & "', "
            End If
            If Len(Trim(cboManifestPallett.Text)) > 0 Then
                strVal += "LocMap_PallettManifest = '" & Trim(cboManifestPallett.Text) & "', "
            End If
            If Len(Trim(cboLabelCoffin.Text)) > 0 Then
                strVal += "LocMap_CoffinLabel = '" & Trim(cboLabelCoffin.Text) & "', "
            Else
                strVal += "LocMap_CoffinLabel = Null,"
            End If
            If Len(Trim(cboLabelMaster.Text)) > 0 Then
                strVal += "LocMap_MasterLabel = '" & Trim(cboLabelMaster.Text) & "', "
            Else
                strVal += "LocMap_MasterLabel = Null,"
            End If
            If Len(Trim(cboLabelOverpack.Text)) > 0 Then
                strVal += "LocMap_OverLabel = '" & Trim(cboLabelOverpack.Text) & "', "
            Else
                strVal += "LocMap_OverLabel = Null,"
            End If
            If Len(Trim(cboLabelPallett.Text)) > 0 Then
                strVal += "LocMap_PallettLabel = '" & Trim(cboLabelPallett.Text) & "', "
            Else
                strVal += "LocMap_PallettLabel = Null,"
            End If

            If Len(Trim(txtQtyCoffin.Text)) > 0 Then
                strVal += "LocMap_CoffinQnt = '" & Trim(txtQtyCoffin.Text) & "', "
            Else
                strVal += "LocMap_CoffinQnt = Null,"
            End If
            If Len(Trim(txtQtyMaster.Text)) > 0 Then
                strVal += "LocMap_MasterQnt = '" & Trim(txtQtyMaster.Text) & "', "
            Else
                strVal += "LocMap_MasterQnt = Null,"
            End If
            If Len(Trim(txtQtyOverpack.Text)) > 0 Then
                strVal += "LocMap_OverQnt = '" & Trim(txtQtyOverpack.Text) & "', "
            Else
                strVal += "LocMap_OverQnt = Null,"
            End If
            If Len(Trim(txtQtyPallett.Text)) > 0 Then
                strVal += "LocMap_PallettQnt = '" & Trim(txtQtyPallett.Text) & "', "
            Else
                strVal += "LocMap_PallettQnt = Null,"
            End If

            If Len(Trim(cboPrinterCoffin.Text)) > 0 Then
                strVal += "LocMap_CoffinPrinter_ID = '" & Trim(cboPrinterCoffin.SelectedValue) & "', "
            Else
                strVal += "LocMap_CoffinPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterMaster.Text)) > 0 Then
                strVal += "LocMap_MasterLblPrinter_ID = '" & Trim(cboPrinterMaster.SelectedValue) & "', "
            Else
                strVal += "LocMap_MasterLblPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterOverpack.Text)) > 0 Then
                strVal += "LocMap_OverLblPrinter_ID = '" & Trim(cboPrinterOverpack.SelectedValue) & "', "
            Else
                strVal += "LocMap_OverLblPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterPallett.Text)) > 0 Then
                strVal += "LocMap_PallettLblPrinter_ID = '" & Trim(cboPrinterPallett.SelectedValue) & "', "
            Else
                strVal += "LocMap_PallettLblPrinter_ID = Null,"
            End If

            If cbCoffin.Checked = True Then
                strVal += "LocMap_CoffinPrt = 1, "
            Else
                strVal += "LocMap_CoffinPrt = 0, "
            End If
            If cbMaster.Checked = True Then
                strVal += "LocMap_MasterLblPrt = 1, "
            Else
                strVal += "LocMap_MasterLblPrt = 0, "
            End If
            If cbOverpack.Checked = True Then
                strVal += "LocMap_OverLblPrt = 1, "
            Else
                strVal += "LocMap_OverLblPrt = 0, "
            End If
            If cbPallett.Checked = True Then
                strVal += "LocMap_PallettLblPrt = 1, "
            Else
                strVal += "LocMap_PallettLblPrt = 0, "
            End If


            If cbManMaster.Checked = True Then
                strVal += "LocMap_MasterManPrt = 1, "
            Else
                strVal += "LocMap_MasterManPrt = 0, "
            End If
            If cbManOverpack.Checked = True Then
                strVal += "LocMap_OverManPrt = 1, "
            Else
                strVal += "LocMap_OverManPrt = 0, "
            End If
            If cbManPallett.Checked = True Then
                strVal += "LocMap_PallettManPrt = 1 "
            Else
                strVal += "LocMap_PallettManPrt = 0 "
            End If



            '//Include Selection Parameter
            strVal += " WHERE Loc_ID = " & CStr(intLocOptions) & " AND LocMap_ProcType = 0"

            Dim blnInsert As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete("UPDATE tlocmap SET " & strVal)

            Windows.Forms.Application.DoEvents()
            '******************************************************************************
            '******************************************************************************

            strVal = ""
            If Len(Trim(cboManifestMaster1.Text)) > 0 Then
                strVal += "LocMap_MasterManifest = '" & Trim(cboManifestMaster1.Text) & "', "
            End If
            If Len(Trim(cboManifestOverpack1.Text)) > 0 Then
                strVal += "LocMap_OverManifest = '" & Trim(cboManifestOverpack1.Text) & "', "
            End If
            If Len(Trim(cboManifestPallett1.Text)) > 0 Then
                strVal += "LocMap_PallettManifest = '" & Trim(cboManifestPallett1.Text) & "', "
            End If
            If Len(Trim(cboLabelCoffin1.Text)) > 0 Then
                strVal += "LocMap_CoffinLabel = '" & Trim(cboLabelCoffin1.Text) & "', "
            Else
                strVal += "LocMap_CoffinLabel = Null,"
            End If
            If Len(Trim(cboLabelMaster1.Text)) > 0 Then
                strVal += "LocMap_MasterLabel = '" & Trim(cboLabelMaster1.Text) & "', "
            Else
                strVal += "LocMap_MasterLabel = Null,"
            End If
            If Len(Trim(cboLabelOverpack1.Text)) > 0 Then
                strVal += "LocMap_OverLabel = '" & Trim(cboLabelOverpack1.Text) & "', "
            Else
                strVal += "LocMap_OverLabel = Null,"
            End If
            If Len(Trim(cboLabelPallett1.Text)) > 0 Then
                strVal += "LocMap_PallettLabel = '" & Trim(cboLabelPallett1.Text) & "', "
            Else
                strVal += "LocMap_PallettLabel = Null,"
            End If

            If Len(Trim(txtQtyCoffin1.Text)) > 0 Then
                strVal += "LocMap_CoffinQnt = '" & Trim(txtQtyCoffin1.Text) & "', "
            Else
                strVal += "LocMap_CoffinQnt = Null,"
            End If
            If Len(Trim(txtQtyMaster1.Text)) > 0 Then
                strVal += "LocMap_MasterQnt = '" & Trim(txtQtyMaster1.Text) & "', "
            Else
                strVal += "LocMap_MasterQnt = Null,"
            End If
            If Len(Trim(txtQtyOverpack1.Text)) > 0 Then
                strVal += "LocMap_OverQnt = '" & Trim(txtQtyOverpack1.Text) & "', "
            Else
                strVal += "LocMap_OverQnt = Null,"
            End If
            If Len(Trim(txtQtyPallett1.Text)) > 0 Then
                strVal += "LocMap_PallettQnt = '" & Trim(txtQtyPallett1.Text) & "', "
            Else
                strVal += "LocMap_PallettQnt = Null,"
            End If

            If Len(Trim(cboPrinterCoffin1.Text)) > 0 Then
                strVal += "LocMap_CoffinPrinter_ID = '" & Trim(cboPrinterCoffin1.SelectedValue) & "', "
            Else
                strVal += "LocMap_CoffinPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterMaster1.Text)) > 0 Then
                strVal += "LocMap_MasterLblPrinter_ID = '" & Trim(cboPrinterMaster1.SelectedValue) & "', "
            Else
                strVal += "LocMap_MasterLblPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterOverpack1.Text)) > 0 Then
                strVal += "LocMap_OverLblPrinter_ID = '" & Trim(cboPrinterOverpack1.SelectedValue) & "', "
            Else
                strVal += "LocMap_OverLblPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterPallett1.Text)) > 0 Then
                strVal += "LocMap_PallettLblPrinter_ID = '" & Trim(cboPrinterPallett1.SelectedValue) & "', "
            Else
                strVal += "LocMap_PallettLblPrinter_ID = Null,"
            End If

            If cbCoffin1.Checked = True Then
                strVal += "LocMap_CoffinPrt = 1, "
            Else
                strVal += "LocMap_CoffinPrt = 0, "
            End If
            If cbMaster1.Checked = True Then
                strVal += "LocMap_MasterLblPrt = 1, "
            Else
                strVal += "LocMap_MasterLblPrt = 0, "
            End If
            If cbOverpack1.Checked = True Then
                strVal += "LocMap_OverLblPrt = 1, "
            Else
                strVal += "LocMap_OverLblPrt = 0, "
            End If
            If cbPallett1.Checked = True Then
                strVal += "LocMap_PallettLblPrt = 1, "
            Else
                strVal += "LocMap_PallettLblPrt = 0, "
            End If

            If cbManMaster1.Checked = True Then
                strVal += "LocMap_MasterManPrt = 1, "
            Else
                strVal += "LocMap_MasterManPrt = 0, "
            End If
            If cbManOverpack1.Checked = True Then
                strVal += "LocMap_OverManPrt = 1, "
            Else
                strVal += "LocMap_OverManPrt = 0, "
            End If
            If cbManPallett1.Checked = True Then
                strVal += "LocMap_PallettManPrt = 1 "
            Else
                strVal += "LocMap_PallettManPrt = 0 "
            End If


            '//Include Selection Parameter
            strVal += " WHERE Loc_ID = " & CStr(intLocOptions) & " AND LocMap_ProcType = 1"

            blnInsert = PSS.Data.Production.Joins.OrderEntryUpdateDelete("UPDATE tlocmap SET " & strVal)

            Windows.Forms.Application.DoEvents()

            '******************************************************************************
            '******************************************************************************

            strVal = ""
            If Len(Trim(cboManifestMaster2.Text)) > 0 Then
                strVal += "LocMap_MasterManifest = '" & Trim(cboManifestMaster2.Text) & "', "
            End If
            If Len(Trim(cboManifestOverpack2.Text)) > 0 Then
                strVal += "LocMap_OverManifest = '" & Trim(cboManifestOverpack2.Text) & "', "
            End If
            If Len(Trim(cboManifestPallett2.Text)) > 0 Then
                strVal += "LocMap_PallettManifest = '" & Trim(cboManifestPallett2.Text) & "', "
            End If
            If Len(Trim(cboLabelCoffin2.Text)) > 0 Then
                strVal += "LocMap_CoffinLabel = '" & Trim(cboLabelCoffin2.Text) & "', "
            Else
                strVal += "LocMap_CoffinLabel = Null,"
            End If
            If Len(Trim(cboLabelMaster2.Text)) > 0 Then
                strVal += "LocMap_MasterLabel = '" & Trim(cboLabelMaster2.Text) & "', "
            Else
                strVal += "LocMap_MasterLabel = Null,"
            End If
            If Len(Trim(cboLabelOverpack2.Text)) > 0 Then
                strVal += "LocMap_OverLabel = '" & Trim(cboLabelOverpack2.Text) & "', "
            Else
                strVal += "LocMap_OverLabel = Null,"
            End If
            If Len(Trim(cboLabelPallett2.Text)) > 0 Then
                strVal += "LocMap_PallettLabel = '" & Trim(cboLabelPallett2.Text) & "', "
            Else
                strVal += "LocMap_PallettLabel = Null,"
            End If

            If Len(Trim(txtQtyCoffin2.Text)) > 0 Then
                strVal += "LocMap_CoffinQnt = '" & Trim(txtQtyCoffin2.Text) & "', "
            Else
                strVal += "LocMap_CoffinQnt = Null,"
            End If
            If Len(Trim(txtQtyMaster2.Text)) > 0 Then
                strVal += "LocMap_MasterQnt = '" & Trim(txtQtyMaster2.Text) & "', "
            Else
                strVal += "LocMap_MasterQnt = Null,"
            End If
            If Len(Trim(txtQtyOverpack2.Text)) > 0 Then
                strVal += "LocMap_OverQnt = '" & Trim(txtQtyOverpack2.Text) & "', "
            Else
                strVal += "LocMap_OverQnt = Null,"
            End If
            If Len(Trim(txtQtyPallett2.Text)) > 0 Then
                strVal += "LocMap_PallettQnt = '" & Trim(txtQtyPallett2.Text) & "', "
            Else
                strVal += "LocMap_PallettQnt = Null,"
            End If

            If Len(Trim(cboPrinterCoffin2.Text)) > 0 Then
                strVal += "LocMap_CoffinPrinter_ID = '" & Trim(cboPrinterCoffin2.SelectedValue) & "', "
            Else
                strVal += "LocMap_CoffinPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterMaster2.Text)) > 0 Then
                strVal += "LocMap_MasterLblPrinter_ID = '" & Trim(cboPrinterMaster2.SelectedValue) & "', "
            Else
                strVal += "LocMap_MasterLblPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterOverpack2.Text)) > 0 Then
                strVal += "LocMap_OverLblPrinter_ID = '" & Trim(cboPrinterOverpack2.SelectedValue) & "', "
            Else
                strVal += "LocMap_OverLblPrinter_ID = Null,"
            End If
            If Len(Trim(cboPrinterPallett2.Text)) > 0 Then
                strVal += "LocMap_PallettLblPrinter_ID = '" & Trim(cboPrinterPallett2.SelectedValue) & "', "
            Else
                strVal += "LocMap_PallettLblPrinter_ID = Null,"
            End If

            If cbCoffin2.Checked = True Then
                strVal += "LocMap_CoffinPrt = 1, "
            Else
                strVal += "LocMap_CoffinPrt = 0, "
            End If
            If cbMaster2.Checked = True Then
                strVal += "LocMap_MasterLblPrt = 1, "
            Else
                strVal += "LocMap_MasterLblPrt = 0, "
            End If
            If cbOverpack2.Checked = True Then
                strVal += "LocMap_OverLblPrt = 1, "
            Else
                strVal += "LocMap_OverLblPrt = 0, "
            End If
            If cbPallett2.Checked = True Then
                strVal += "LocMap_PallettLblPrt = 1, "
            Else
                strVal += "LocMap_PallettLblPrt = 0, "
            End If

            If cbManMaster2.Checked = True Then
                strVal += "LocMap_MasterManPrt = 1, "
            Else
                strVal += "LocMap_MasterManPrt = 0, "
            End If
            If cbManOverpack2.Checked = True Then
                strVal += "LocMap_OverManPrt = 1, "
            Else
                strVal += "LocMap_OverManPrt = 0, "
            End If
            If cbManPallett2.Checked = True Then
                strVal += "LocMap_PallettManPrt = 1 "
            Else
                strVal += "LocMap_PallettManPrt = 0 "
            End If

            '//Include Selection Parameter
            strVal += " WHERE Loc_ID = " & CStr(intLocOptions) & " AND LocMap_ProcType = 2"

            blnInsert = PSS.Data.Production.Joins.OrderEntryUpdateDelete("UPDATE tlocmap SET " & strVal)

            Windows.Forms.Application.DoEvents()

            MsgBox("Update Complete", MsgBoxStyle.OKOnly, "Save Data")

        End If

    End Sub
    Private Sub GetData()

        If intLocOptions > 0 Then
            Dim objConn As PSS.Data.Production.Joins
            Dim r As DataRow
            Dim x As Integer

            strSQL = "SELECT * FROM tlocmap WHERE loc_ID = " & intLocOptions
            Dim dt As DataTable = objConn.OrderEntrySelect(strSQL)

            If dt.Rows.Count > 0 Then
                blnUpdate = True
            Else
                blnUpdate = False

                cboPrinterCoffin.Text = ""
                cboPrinterMaster.Text = ""
                cboPrinterOverpack.Text = ""
                cboPrinterPallett.Text = ""

                cboPrinterCoffin1.Text = ""
                cboPrinterMaster1.Text = ""
                cboPrinterOverpack1.Text = ""
                cboPrinterPallett1.Text = ""

            End If

            For x = 0 To dt.Rows.Count - 1

                r = dt.Rows(x)

                If r("LocMap_ProcType") = 0 Then


                    If IsDBNull(r("LocMap_MasterManifest")) = False Then cboManifestMaster.Text = r("LocMap_MasterManifest")
                    If IsDBNull(r("LocMap_OverManifest")) = False Then cboManifestOverpack.Text = r("LocMap_OverManifest")
                    Try
                        If IsDBNull(r("LocMap_PallettManifest")) = False Then cboManifestPallett.Text = r("LocMap_MasterManifest")
                    Catch ex As Exception
                    End Try

                    If IsDBNull(r("LocMap_CoffinLabel")) = False Then cboLabelCoffin.Text = r("LocMap_CoffinLabel")
                    If IsDBNull(r("LocMap_MasterLabel")) = False Then cboLabelMaster.Text = r("LocMap_MasterLabel")
                    If IsDBNull(r("LocMap_OverLabel")) = False Then cboLabelOverpack.Text = r("LocMap_OverLabel")
                    If IsDBNull(r("LocMap_PallettLabel")) = False Then cboLabelPallett.Text = r("LocMap_PallettLabel")
                    If IsDBNull(r("LocMap_CoffinQnt")) = False Then txtQtyCoffin.Text = r("LocMap_CoffinQnt")
                    If IsDBNull(r("LocMap_MasterQnt")) = False Then txtQtyMaster.Text = r("LocMap_MasterQnt")
                    If IsDBNull(r("LocMap_OverQnt")) = False Then txtQtyOverpack.Text = r("LocMap_OverQnt")
                    If IsDBNull(r("LocMap_PallettQnt")) = False Then txtQtyPallett.Text = r("LocMap_PallettQnt")
                    If IsDBNull(r("LocMap_CoffinPrt")) = False Then
                        If r("LocMap_CoffinPrt") = 1 Then
                            cbCoffin.Checked = True
                        Else
                            cbCoffin.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_MasterLblPrt")) = False Then
                        If r("LocMap_MasterLblPrt") = 1 Then
                            cbMaster.Checked = True
                        Else
                            cbMaster.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_OverLblPrt")) = False Then
                        If r("LocMap_OverLblPrt") = 1 Then
                            cbOverpack.Checked = True
                        Else
                            cbOverpack.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_PallettLblPrt")) = False Then
                        If r("LocMap_PallettLblPrt") = 1 Then
                            cbPallett.Checked = True
                        Else
                            cbPallett.Checked = False
                        End If
                    End If


                    If IsDBNull(r("LocMap_MasterManPrt")) = False Then
                        If r("LocMap_MasterManPrt") = 1 Then
                            cbManMaster.Checked = True
                        Else
                            cbManMaster.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_OverManPrt")) = False Then
                        If r("LocMap_OverManPrt") = 1 Then
                            cbManOverpack.Checked = True
                        Else
                            cbManOverpack.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_PallettManPrt")) = False Then
                        If r("LocMap_PallettManPrt") = 1 Then
                            cbManPallett.Checked = True
                        Else
                            cbManPallett.Checked = False
                        End If
                    End If



                    If IsDBNull(r("LocMap_CoffinPrinter_ID")) = False Then cboPrinterCoffin.SelectedValue = r("LocMap_CoffinPrinter_ID")
                    If IsDBNull(r("LocMap_MasterLblPrinter_ID")) = False Then cboPrinterMaster.SelectedValue = r("LocMap_MasterLblPrinter_ID")
                    If IsDBNull(r("LocMap_OverLblPrinter_ID")) = False Then cboPrinterOverpack.SelectedValue = r("LocMap_OverLblPrinter_ID")
                    If IsDBNull(r("LocMap_PallettLblPrinter_ID")) = False Then cboPrinterPallett.SelectedValue = r("LocMap_PallettLblPrinter_ID")

                ElseIf r("LocMap_ProcType") = 1 Then

                        If IsDBNull(r("LocMap_MasterManifest")) = False Then cboManifestMaster1.Text = r("LocMap_MasterManifest")
                    If IsDBNull(r("LocMap_OverManifest")) = False Then cboManifestOverpack1.Text = r("LocMap_OverManifest")
                    Try
                        If IsDBNull(r("LocMap_PallettManifest")) = False Then cboManifestPallett1.Text = r("LocMap_MasterManifest")
                    Catch ex As Exception
                    End Try

                    If IsDBNull(r("LocMap_CoffinLabel")) = False Then cboLabelCoffin1.Text = r("LocMap_CoffinLabel")
                    If IsDBNull(r("LocMap_MasterLabel")) = False Then cboLabelMaster1.Text = r("LocMap_MasterLabel")
                    If IsDBNull(r("LocMap_OverLabel")) = False Then cboLabelOverpack1.Text = r("LocMap_OverLabel")
                    If IsDBNull(r("LocMap_PallettLabel")) = False Then cboLabelPallett1.Text = r("LocMap_PallettLabel")
                    If IsDBNull(r("LocMap_CoffinQnt")) = False Then txtQtyCoffin1.Text = r("LocMap_CoffinQnt")
                    If IsDBNull(r("LocMap_MasterQnt")) = False Then txtQtyMaster1.Text = r("LocMap_MasterQnt")
                    If IsDBNull(r("LocMap_OverQnt")) = False Then txtQtyOverpack1.Text = r("LocMap_OverQnt")
                    If IsDBNull(r("LocMap_PallettQnt")) = False Then txtQtyPallett1.Text = r("LocMap_PallettQnt")
                    If IsDBNull(r("LocMap_CoffinPrt")) = False Then
                        If r("LocMap_CoffinPrt") = 1 Then
                            cbCoffin1.Checked = True
                        Else
                            cbCoffin1.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_MasterLblPrt")) = False Then
                        If r("LocMap_MasterLblPrt") = 1 Then
                            cbMaster1.Checked = True
                        Else
                            cbMaster1.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_OverLblPrt")) = False Then
                        If r("LocMap_OverLblPrt") = 1 Then
                            cbOverpack1.Checked = True
                        Else
                            cbOverpack1.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_PallettLblPrt")) = False Then
                        If r("LocMap_PallettLblPrt") = 1 Then
                            cbPallett1.Checked = True
                        Else
                            cbPallett1.Checked = False
                        End If
                    End If


                    If IsDBNull(r("LocMap_MasterManPrt")) = False Then
                        If r("LocMap_MasterManPrt") = 1 Then
                            cbManMaster1.Checked = True
                        Else
                            cbManMaster1.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_OverManPrt")) = False Then
                        If r("LocMap_OverManPrt") = 1 Then
                            cbManOverpack1.Checked = True
                        Else
                            cbManOverpack1.Checked = False
                        End If
                    End If
                    If IsDBNull(r("LocMap_PallettManPrt")) = False Then
                        If r("LocMap_PallettManPrt") = 1 Then
                            cbManPallett1.Checked = True
                        Else
                            cbManPallett1.Checked = False
                        End If
                    End If


                    If IsDBNull(r("LocMap_CoffinPrinter_ID")) = False Then cboPrinterCoffin1.SelectedValue = r("LocMap_CoffinPrinter_ID")
                    If IsDBNull(r("LocMap_MasterLblPrinter_ID")) = False Then cboPrinterMaster1.SelectedValue = r("LocMap_MasterLblPrinter_ID")
                    If IsDBNull(r("LocMap_OverLblPrinter_ID")) = False Then cboPrinterOverpack1.SelectedValue = r("LocMap_OverLblPrinter_ID")
                    If IsDBNull(r("LocMap_PallettLblPrinter_ID")) = False Then cboPrinterPallett1.SelectedValue = r("LocMap_PallettLblPrinter_ID")

                ElseIf r("LocMap_ProcType") = 2 Then

                        If IsDBNull(r("LocMap_MasterManifest")) = False Then cboManifestMaster2.Text = r("LocMap_MasterManifest")
                        If IsDBNull(r("LocMap_OverManifest")) = False Then cboManifestOverpack2.Text = r("LocMap_OverManifest")
                        If IsDBNull(r("LocMap_PallettManifest")) = False Then cboManifestPallett2.Text = r("LocMap_MasterManifest")

                        If IsDBNull(r("LocMap_CoffinLabel")) = False Then cboLabelCoffin2.Text = r("LocMap_CoffinLabel")
                        If IsDBNull(r("LocMap_MasterLabel")) = False Then cboLabelMaster2.Text = r("LocMap_MasterLabel")
                        If IsDBNull(r("LocMap_OverLabel")) = False Then cboLabelOverpack2.Text = r("LocMap_OverLabel")
                        If IsDBNull(r("LocMap_PallettLabel")) = False Then cboLabelPallett2.Text = r("LocMap_PallettLabel")
                        If IsDBNull(r("LocMap_CoffinQnt")) = False Then txtQtyCoffin2.Text = r("LocMap_CoffinQnt")
                        If IsDBNull(r("LocMap_MasterQnt")) = False Then txtQtyMaster2.Text = r("LocMap_MasterQnt")
                        If IsDBNull(r("LocMap_OverQnt")) = False Then txtQtyOverpack2.Text = r("LocMap_OverQnt")
                        If IsDBNull(r("LocMap_PallettQnt")) = False Then txtQtyPallett2.Text = r("LocMap_PallettQnt")
                        If IsDBNull(r("LocMap_CoffinPrt")) = False Then
                            If r("LocMap_CoffinPrt") = 1 Then
                                cbCoffin2.Checked = True
                            Else
                                cbCoffin2.Checked = False
                            End If
                        End If
                        If IsDBNull(r("LocMap_MasterLblPrt")) = False Then
                            If r("LocMap_MasterLblPrt") = 1 Then
                                cbMaster2.Checked = True
                            Else
                                cbMaster2.Checked = False
                            End If
                        End If
                        If IsDBNull(r("LocMap_OverLblPrt")) = False Then
                            If r("LocMap_OverLblPrt") = 1 Then
                                cbOverpack2.Checked = True
                            Else
                                cbOverpack2.Checked = False
                            End If
                        End If
                        If IsDBNull(r("LocMap_PallettLblPrt")) = False Then
                            If r("LocMap_PallettLblPrt") = 1 Then
                                cbPallett2.Checked = True
                            Else
                                cbPallett2.Checked = False
                            End If
                        End If

                        If IsDBNull(r("LocMap_MasterManPrt")) = False Then
                            If r("LocMap_MasterManPrt") = 1 Then
                                cbManMaster2.Checked = True
                            Else
                                cbManMaster2.Checked = False
                            End If
                        End If
                        If IsDBNull(r("LocMap_OverManPrt")) = False Then
                            If r("LocMap_OverManPrt") = 1 Then
                                cbManOverpack2.Checked = True
                            Else
                                cbManOverpack2.Checked = False
                            End If
                        End If
                        If IsDBNull(r("LocMap_PallettManPrt")) = False Then
                            If r("LocMap_PallettManPrt") = 1 Then
                                cbManPallett2.Checked = True
                            Else
                                cbManPallett2.Checked = False
                            End If
                        End If

                        If IsDBNull(r("LocMap_CoffinPrinter_ID")) = False Then cboPrinterCoffin2.SelectedValue = r("LocMap_CoffinPrinter_ID")
                        If IsDBNull(r("LocMap_MasterLblPrinter_ID")) = False Then cboPrinterMaster2.SelectedValue = r("LocMap_MasterLblPrinter_ID")
                        If IsDBNull(r("LocMap_OverLblPrinter_ID")) = False Then cboPrinterOverpack2.SelectedValue = r("LocMap_OverLblPrinter_ID")
                        If IsDBNull(r("LocMap_PallettLblPrinter_ID")) = False Then cboPrinterPallett2.SelectedValue = r("LocMap_PallettLblPrinter_ID")

                End If

            Next


        End If

    End Sub
    Private Function verifyData() As String

        verifyData = ""
        If Len(Trim(txtQtyCoffin.Text)) > 0 Then
            Try
                If CInt(txtQtyCoffin.Text) Then
                End If
            Catch ex As Exception
                verifyData += "Coffin Quantity is not numeric." & vbCrLf
            End Try
        End If

        If Len(Trim(txtQtyMaster.Text)) > 0 Then
            Try
                If CInt(txtQtyMaster.Text) Then
                End If
            Catch ex As Exception
                verifyData += "Master Quantity is not numeric." & vbCrLf
            End Try
        End If

        If Len(Trim(txtQtyOverpack.Text)) > 0 Then
            Try
                If CInt(txtQtyOverpack.Text) Then
                End If
            Catch ex As Exception
                verifyData += "Overpack Quantity is not numeric." & vbCrLf
            End Try
        End If

        If Len(Trim(txtQtyPallett.Text)) > 0 Then
            Try
                If CInt(txtQtyPallett.Text) Then
                End If
            Catch ex As Exception
                verifyData += "Pallett Quantity is not numeric." & vbCrLf
            End Try
        End If
        '*****************************************************************************
        If Len(Trim(txtQtyCoffin1.Text)) > 0 Then
            Try
                If CInt(txtQtyCoffin1.Text) Then
                End If
            Catch ex As Exception
                verifyData += "RUR Coffin Quantity is not numeric." & vbCrLf
            End Try
        End If
        If Len(Trim(txtQtyMaster1.Text)) > 0 Then
            Try
                If CInt(txtQtyMaster1.Text) Then
                End If
            Catch ex As Exception
                verifyData += "RUR Master Quantity is not numeric." & vbCrLf
            End Try
        End If

        If Len(Trim(txtQtyOverpack1.Text)) > 0 Then
            Try
                If CInt(txtQtyOverpack1.Text) Then
                End If
            Catch ex As Exception
                verifyData += "RUR Overpack Quantity is not numeric." & vbCrLf
            End Try
        End If

        If Len(Trim(txtQtyPallett1.Text)) > 0 Then
            Try
                If CInt(txtQtyPallett1.Text) Then
                End If
            Catch ex As Exception
                verifyData += "RUR Pallett Quantity is not numeric." & vbCrLf
            End Try
        End If
        '**************************************************************************************
        If Len(Trim(txtQtyCoffin2.Text)) > 0 Then
            Try
                If CInt(txtQtyCoffin2.Text) Then
                End If
            Catch ex As Exception
                verifyData += "NER Coffin Quantity is not numeric." & vbCrLf
            End Try
        End If
        If Len(Trim(txtQtyMaster2.Text)) > 0 Then
            Try
                If CInt(txtQtyMaster2.Text) Then
                End If
            Catch ex As Exception
                verifyData += "NER Master Quantity is not numeric." & vbCrLf
            End Try
        End If

        If Len(Trim(txtQtyOverpack2.Text)) > 0 Then
            Try
                If CInt(txtQtyOverpack2.Text) Then
                End If
            Catch ex As Exception
                verifyData += "NER Overpack Quantity is not numeric." & vbCrLf
            End Try
        End If

        If Len(Trim(txtQtyPallett2.Text)) > 0 Then
            Try
                If CInt(txtQtyPallett2.Text) Then
                End If
            Catch ex As Exception
                verifyData += "NER Pallett Quantity is not numeric." & vbCrLf
            End Try
        End If



        '**********************************************************************

        If Me.cbCoffin.Checked = True Then
            If Len(Trim(Me.cboPrinterCoffin.Text)) < 1 Then
                verifyData += "Coffin - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbMaster.Checked = True Then
            If Len(Trim(Me.cboPrinterMaster.Text)) < 1 Then
                verifyData += "Master - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbOverpack.Checked = True Then
            If Len(Trim(Me.cboPrinterOverpack.Text)) < 1 Then
                verifyData += "Overpack - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbPallett.Checked = True Then
            If Len(Trim(Me.cboPrinterPallett.Text)) < 1 Then
                verifyData += "Pallett - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If


        If Me.cbCoffin1.Checked = True Then
            If Len(Trim(Me.cboPrinterCoffin1.Text)) < 1 Then
                verifyData += "RUR Coffin - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbMaster1.Checked = True Then
            If Len(Trim(Me.cboPrinterMaster1.Text)) < 1 Then
                verifyData += "RUR Master - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbOverpack1.Checked = True Then
            If Len(Trim(Me.cboPrinterOverpack1.Text)) < 1 Then
                verifyData += "RUR Overpack - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbPallett1.Checked = True Then
            If Len(Trim(Me.cboPrinterPallett1.Text)) < 1 Then
                verifyData += "RUR Pallett - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If


        If Me.cbCoffin2.Checked = True Then
            If Len(Trim(Me.cboPrinterCoffin2.Text)) < 1 Then
                verifyData += "NER Coffin - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbMaster2.Checked = True Then
            If Len(Trim(Me.cboPrinterMaster2.Text)) < 1 Then
                verifyData += "NER Master - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbOverpack2.Checked = True Then
            If Len(Trim(Me.cboPrinterOverpack2.Text)) < 1 Then
                verifyData += "NER Overpack - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If

        If Me.cbPallett2.Checked = True Then
            If Len(Trim(Me.cboPrinterPallett2.Text)) < 1 Then
                verifyData += "NER Pallett - Print is selected but no Printer_ID is defined." & vbCrLf
            End If
        End If


    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim objConn As PSS.Data.Production.Joins
        strSQL = "SELECT * FROM tlocmap WHERE loc_ID = " & intLocOptions
        Dim dt As DataTable = objConn.OrderEntrySelect(strSQL)

        If dt.Rows.Count > 0 Then
            UpdateData()
        Else
            SaveData()
        End If

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Me.Close()

    End Sub


    Private Sub populatePrinters()

        Dim objCOnn As PSS.Data.Production.Joins
        strSQL = "SELECT * FROM tprinter"
        dtPrinterCoffin = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterMaster = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterOverpack = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterPallett = objCOnn.OrderEntrySelect(strSQL)

        dtPrinterCoffin1 = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterMaster1 = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterOverpack1 = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterPallett1 = objCOnn.OrderEntrySelect(strSQL)

        dtPrinterCoffin2 = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterMaster2 = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterOverpack2 = objCOnn.OrderEntrySelect(strSQL)
        dtPrinterPallett2 = objCOnn.OrderEntrySelect(strSQL)

        cboPrinterCoffin.DataSource = dtPrinterCoffin
        cboPrinterCoffin.DisplayMember = dtPrinterCoffin.Columns("Printer_Desc").ToString
        cboPrinterCoffin.ValueMember = dtPrinterCoffin.Columns("Printer_ID").ToString

        cboPrinterCoffin1.DataSource = dtPrinterCoffin1
        cboPrinterCoffin1.DisplayMember = dtPrinterCoffin1.Columns("Printer_Desc").ToString
        cboPrinterCoffin1.ValueMember = dtPrinterCoffin1.Columns("Printer_ID").ToString
        cboPrinterCoffin1.Text = ""

        cboPrinterCoffin2.DataSource = dtPrinterCoffin2
        cboPrinterCoffin2.DisplayMember = dtPrinterCoffin2.Columns("Printer_Desc").ToString
        cboPrinterCoffin2.ValueMember = dtPrinterCoffin2.Columns("Printer_ID").ToString
        cboPrinterCoffin2.Text = ""

        cboPrinterMaster.DataSource = dtPrinterMaster
        cboPrinterMaster.DisplayMember = dtPrinterMaster.Columns("Printer_Desc").ToString
        cboPrinterMaster.ValueMember = dtPrinterMaster.Columns("Printer_ID").ToString
        cboPrinterMaster.Text = ""

        cboPrinterMaster1.DataSource = dtPrinterMaster1
        cboPrinterMaster1.DisplayMember = dtPrinterMaster1.Columns("Printer_Desc").ToString
        cboPrinterMaster1.ValueMember = dtPrinterMaster1.Columns("Printer_ID").ToString
        cboPrinterMaster1.Text = ""

        cboPrinterMaster2.DataSource = dtPrinterMaster2
        cboPrinterMaster2.DisplayMember = dtPrinterMaster2.Columns("Printer_Desc").ToString
        cboPrinterMaster2.ValueMember = dtPrinterMaster2.Columns("Printer_ID").ToString
        cboPrinterMaster2.Text = ""

        cboPrinterOverpack.DataSource = dtPrinterOverpack
        cboPrinterOverpack.DisplayMember = dtPrinterOverpack.Columns("Printer_Desc").ToString
        cboPrinterOverpack.ValueMember = dtPrinterOverpack.Columns("Printer_ID").ToString
        cboPrinterOverpack.Text = ""

        cboPrinterOverpack1.DataSource = dtPrinterOverpack1
        cboPrinterOverpack1.DisplayMember = dtPrinterOverpack1.Columns("Printer_Desc").ToString
        cboPrinterOverpack1.ValueMember = dtPrinterOverpack1.Columns("Printer_ID").ToString
        cboPrinterOverpack1.Text = ""

        cboPrinterOverpack2.DataSource = dtPrinterOverpack2
        cboPrinterOverpack2.DisplayMember = dtPrinterOverpack2.Columns("Printer_Desc").ToString
        cboPrinterOverpack2.ValueMember = dtPrinterOverpack2.Columns("Printer_ID").ToString
        cboPrinterOverpack2.Text = ""

        cboPrinterPallett.DataSource = dtPrinterPallett
        cboPrinterPallett.DisplayMember = dtPrinterPallett.Columns("Printer_Desc").ToString
        cboPrinterPallett.ValueMember = dtPrinterPallett.Columns("Printer_ID").ToString
        cboPrinterPallett.Text = ""

        cboPrinterPallett1.DataSource = dtPrinterPallett1
        cboPrinterPallett1.DisplayMember = dtPrinterPallett1.Columns("Printer_Desc").ToString
        cboPrinterPallett1.ValueMember = dtPrinterPallett1.Columns("Printer_ID").ToString
        cboPrinterPallett1.Text = ""

        cboPrinterPallett2.DataSource = dtPrinterPallett2
        cboPrinterPallett2.DisplayMember = dtPrinterPallett2.Columns("Printer_Desc").ToString
        cboPrinterPallett2.ValueMember = dtPrinterPallett2.Columns("Printer_ID").ToString
        cboPrinterPallett2.Text = ""

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        If cbCoffin.Checked = False Then cboPrinterCoffin.Text = ""
        If cbMaster.Checked = False Then cboPrinterMaster.Text = ""
        If cbOverpack.Checked = False Then cboPrinterOverpack.Text = ""
        If cbPallett.Checked = False Then cboPrinterPallett.Text = ""

        If cbCoffin1.Checked = False Then cboPrinterCoffin1.Text = ""
        If cbMaster1.Checked = False Then cboPrinterMaster1.Text = ""
        If cbOverpack1.Checked = False Then cboPrinterOverpack1.Text = ""
        If cbPallett1.Checked = False Then cboPrinterPallett1.Text = ""

        If cbCoffin2.Checked = False Then cboPrinterCoffin2.Text = ""
        If cbMaster2.Checked = False Then cboPrinterMaster2.Text = ""
        If cbOverpack2.Checked = False Then cboPrinterOverpack2.Text = ""
        If cbPallett2.Checked = False Then cboPrinterPallett2.Text = ""

    End Sub

    Private Sub setLabelArray()

        Dim tmpString As String
        Dim tmpInt As Integer
        Dim tmpShipInt As Integer
        Dim xCount As Integer = 0

        tmpString = Dir("R:\")
        tmpShipInt = InStr(UCase(tmpString), "SHIP")
        tmpInt = InStr(UCase(tmpString), "LABEL")
        If tmpInt > 0 And tmpShipInt = 1 Then
            xCount += 1
        End If

        Do Until tmpString = Nothing
            tmpString = Dir()
            tmpShipInt = InStr(UCase(tmpString), "SHIP")
            tmpInt = InStr(UCase(tmpString), "LABEL")
            If tmpInt > 0 And tmpShipInt = 1 Then
                xCount += 1
            End If
        Loop

        ReDim arrLabel(xCount)

    End Sub

    Private Sub populateLabelArray()


        Dim tmpString As String
        Dim tmpInt As Integer
        Dim tmpShipInt As Integer
        Dim xCount As Integer = 0

        setLabelArray()

        tmpString = Dir("R:\")
        tmpShipInt = InStr(UCase(tmpString), "SHIP")
        tmpInt = InStr(UCase(tmpString), "LABEL")
        If tmpInt > 0 And tmpShipInt = 1 Then
            arrLabel(xCount) = tmpString
            xCount += 1
        End If

        Do Until tmpString = Nothing
            tmpString = Dir()
            tmpShipInt = InStr(UCase(tmpString), "SHIP")
            tmpInt = InStr(UCase(tmpString), "LABEL")
            If tmpInt > 0 And tmpShipInt = 1 Then
                arrLabel(xCount) = tmpString
                xCount += 1
            End If
        Loop

        Dim x As Integer = 0
        For x = 0 To UBound(arrLabel) - 1
            cboLabelCoffin.Items.Add(arrLabel(x))
            cboLabelCoffin1.Items.Add(arrLabel(x))
            cboLabelCoffin2.Items.Add(arrLabel(x))
            cboLabelMaster.Items.Add(arrLabel(x))
            cboLabelMaster1.Items.Add(arrLabel(x))
            cboLabelMaster2.Items.Add(arrLabel(x))
            cboLabelOverpack.Items.Add(arrLabel(x))
            cboLabelOverpack1.Items.Add(arrLabel(x))
            cboLabelOverpack2.Items.Add(arrLabel(x))
            cboLabelPallett.Items.Add(arrLabel(x))
            cboLabelPallett1.Items.Add(arrLabel(x))
            cboLabelPallett2.Items.Add(arrLabel(x))
        Next

    End Sub


    Private Sub setManifestArray()

        Dim tmpString As String
        Dim tmpInt As Integer
        Dim tmpShipInt As Integer
        Dim xCount As Integer = 0

        tmpString = Dir("R:\")
        tmpShipInt = InStr(UCase(tmpString), "SHIP")
        tmpInt = InStr(UCase(tmpString), "MANIFEST")
        If tmpInt > 0 And tmpShipInt = 1 Then
            xCount += 1
        End If

        Do Until tmpString = Nothing
            tmpString = Dir()
            tmpShipInt = InStr(UCase(tmpString), "SHIP")
            tmpInt = InStr(UCase(tmpString), "MANIFEST")
            If tmpInt > 0 And tmpShipInt = 1 Then
                xCount += 1
            End If
        Loop

        ReDim arrManifest(xCount)

    End Sub

    Private Sub populateManifestArray()


        Dim tmpString As String
        Dim tmpInt As Integer
        Dim tmpShipInt As Integer
        Dim xCount As Integer = 0

        setManifestArray()

        tmpString = Dir("R:\")
        tmpShipInt = InStr(UCase(tmpString), "SHIP")
        tmpInt = InStr(UCase(tmpString), "MANIFEST")
        If tmpInt > 0 And tmpShipInt = 1 Then
            arrManifest(xCount) = tmpString
            xCount += 1
        End If

        Do Until tmpString = Nothing
            tmpString = Dir()
            tmpShipInt = InStr(UCase(tmpString), "SHIP")
            tmpInt = InStr(UCase(tmpString), "MANIFEST")
            If tmpInt > 0 And tmpShipInt = 1 Then
                arrManifest(xCount) = tmpString
                xCount += 1
            End If
        Loop

        Dim x As Integer = 0
        For x = 0 To UBound(arrManifest) - 1
            cboManifestMaster.Items.Add(arrManifest(x))
            cboManifestMaster1.Items.Add(arrManifest(x))
            cboManifestMaster2.Items.Add(arrManifest(x))
            cboManifestOverpack.Items.Add(arrManifest(x))
            cboManifestOverpack1.Items.Add(arrManifest(x))
            cboManifestOverpack2.Items.Add(arrManifest(x))
            cboManifestPallett.Items.Add(arrManifest(x))
            cboManifestPallett1.Items.Add(arrManifest(x))
            cboManifestPallett2.Items.Add(arrManifest(x))
        Next

    End Sub

End Class
