Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmSkyTelRec
    Inherits System.Windows.Forms.Form

    Private _objSkyTel As SkyTel
    Private _iLocID As Integer = 0
    Private _iWOID As Integer = 0
    Private _iTrayID As Integer = 0
    Private _iCameWithFile As Integer = 0
    Private _booDiscrepancy As Boolean
    Private _iMenuCustID As Integer = 0
    Private _strTabPageTitle As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strTabPageTitle As String, ByVal iCustID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objSkyTel = New SkyTel()
        _strTabPageTitle = strTabPageTitle
        _iMenuCustID = iCustID
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            _objSkyTel = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRMA As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblPO As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboFreqs As C1.Win.C1List.C1Combo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblFileQtyLabel As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblFileQtyVal As System.Windows.Forms.Label
    Friend WithEvents lblScanQtyVal As System.Windows.Forms.Label
    Friend WithEvents dbgRecData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCap As System.Windows.Forms.TextBox
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblLoc As System.Windows.Forms.Label
    Friend WithEvents cboBauds As C1.Win.C1List.C1Combo
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents lblMissingFreq As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblMissingCap As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblMissingBaud As System.Windows.Forms.Label
    Friend WithEvents lblDuplicateSN As System.Windows.Forms.Label
    Friend WithEvents lblMissingSN As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents pnlDiscrep As System.Windows.Forms.Panel
    Friend WithEvents btnCloseWO As System.Windows.Forms.Button
    Friend WithEvents btnViewDiscUnits As System.Windows.Forms.Button
    Friend WithEvents dbgDiscUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnViewRecvdUnits As System.Windows.Forms.Button
    Friend WithEvents lblTask As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSkyTelRec))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtRMA = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblLoc = New System.Windows.Forms.Label()
        Me.lblPO = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboFreqs = New C1.Win.C1List.C1Combo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCap = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblFileQtyLabel = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblFileQtyVal = New System.Windows.Forms.Label()
        Me.lblScanQtyVal = New System.Windows.Forms.Label()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.btnViewDiscUnits = New System.Windows.Forms.Button()
        Me.dbgRecData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cboBauds = New C1.Win.C1List.C1Combo()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.pnlDiscrep = New System.Windows.Forms.Panel()
        Me.lblMissingFreq = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblMissingCap = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblMissingBaud = New System.Windows.Forms.Label()
        Me.lblDuplicateSN = New System.Windows.Forms.Label()
        Me.lblMissingSN = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.btnCloseWO = New System.Windows.Forms.Button()
        Me.dbgDiscUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnViewRecvdUnits = New System.Windows.Forms.Button()
        Me.lblTask = New System.Windows.Forms.Label()
        CType(Me.cboFreqs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgRecData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboBauds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDiscrep.SuspendLayout()
        CType(Me.dbgDiscUnits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "RMA/WO: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRMA
        '
        Me.txtRMA.Location = New System.Drawing.Point(96, 32)
        Me.txtRMA.Name = "txtRMA"
        Me.txtRMA.Size = New System.Drawing.Size(256, 20)
        Me.txtRMA.TabIndex = 0
        Me.txtRMA.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Cust-Loc:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLoc
        '
        Me.lblLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoc.ForeColor = System.Drawing.Color.Blue
        Me.lblLoc.Location = New System.Drawing.Point(96, 56)
        Me.lblLoc.Name = "lblLoc"
        Me.lblLoc.Size = New System.Drawing.Size(256, 32)
        Me.lblLoc.TabIndex = 17
        Me.lblLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPO
        '
        Me.lblPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPO.ForeColor = System.Drawing.Color.Blue
        Me.lblPO.Location = New System.Drawing.Point(96, 96)
        Me.lblPO.Name = "lblPO"
        Me.lblPO.Size = New System.Drawing.Size(256, 16)
        Me.lblPO.TabIndex = 19
        Me.lblPO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 96)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "PO#:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFreqs
        '
        Me.cboFreqs.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboFreqs.Caption = ""
        Me.cboFreqs.CaptionHeight = 17
        Me.cboFreqs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFreqs.ColumnCaptionHeight = 17
        Me.cboFreqs.ColumnFooterHeight = 17
        Me.cboFreqs.ContentHeight = 15
        Me.cboFreqs.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFreqs.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFreqs.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFreqs.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFreqs.EditorHeight = 15
        Me.cboFreqs.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboFreqs.ItemHeight = 15
        Me.cboFreqs.Location = New System.Drawing.Point(96, 144)
        Me.cboFreqs.MatchEntryTimeout = CType(2000, Long)
        Me.cboFreqs.MaxDropDownItems = CType(5, Short)
        Me.cboFreqs.MaxLength = 32767
        Me.cboFreqs.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFreqs.Name = "cboFreqs"
        Me.cboFreqs.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFreqs.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFreqs.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFreqs.Size = New System.Drawing.Size(256, 21)
        Me.cboFreqs.TabIndex = 2
        Me.cboFreqs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
        "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
        "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
        "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Freq#:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboModels
        '
        Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboModels.Caption = ""
        Me.cboModels.CaptionHeight = 17
        Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModels.ColumnCaptionHeight = 17
        Me.cboModels.ColumnFooterHeight = 17
        Me.cboModels.ContentHeight = 15
        Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModels.EditorHeight = 15
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(96, 120)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(5, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(256, 21)
        Me.cboModels.TabIndex = 1
        Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
        "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
        "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
        "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Model:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 192)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Capcode : "
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCap
        '
        Me.txtCap.Location = New System.Drawing.Point(96, 192)
        Me.txtCap.Name = "txtCap"
        Me.txtCap.Size = New System.Drawing.Size(256, 20)
        Me.txtCap.TabIndex = 4
        Me.txtCap.Text = ""
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 224)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "S/N: "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(96, 224)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(168, 20)
        Me.txtSN.TabIndex = 5
        Me.txtSN.Text = ""
        '
        'lblFileQtyLabel
        '
        Me.lblFileQtyLabel.BackColor = System.Drawing.Color.SteelBlue
        Me.lblFileQtyLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileQtyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileQtyLabel.ForeColor = System.Drawing.Color.White
        Me.lblFileQtyLabel.Location = New System.Drawing.Point(368, 32)
        Me.lblFileQtyLabel.Name = "lblFileQtyLabel"
        Me.lblFileQtyLabel.Size = New System.Drawing.Size(144, 24)
        Me.lblFileQtyLabel.TabIndex = 26
        Me.lblFileQtyLabel.Text = "File Qty:"
        Me.lblFileQtyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(368, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(144, 24)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Received Qty:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblFileQtyVal
        '
        Me.lblFileQtyVal.BackColor = System.Drawing.Color.SteelBlue
        Me.lblFileQtyVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFileQtyVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFileQtyVal.ForeColor = System.Drawing.Color.White
        Me.lblFileQtyVal.Location = New System.Drawing.Point(512, 32)
        Me.lblFileQtyVal.Name = "lblFileQtyVal"
        Me.lblFileQtyVal.Size = New System.Drawing.Size(80, 24)
        Me.lblFileQtyVal.TabIndex = 28
        Me.lblFileQtyVal.Text = "0"
        Me.lblFileQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblScanQtyVal
        '
        Me.lblScanQtyVal.BackColor = System.Drawing.Color.SteelBlue
        Me.lblScanQtyVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblScanQtyVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanQtyVal.ForeColor = System.Drawing.Color.White
        Me.lblScanQtyVal.Location = New System.Drawing.Point(512, 56)
        Me.lblScanQtyVal.Name = "lblScanQtyVal"
        Me.lblScanQtyVal.Size = New System.Drawing.Size(80, 24)
        Me.lblScanQtyVal.TabIndex = 29
        Me.lblScanQtyVal.Text = "0"
        Me.lblScanQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnGo
        '
        Me.btnGo.BackColor = System.Drawing.Color.Green
        Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.ForeColor = System.Drawing.Color.White
        Me.btnGo.Location = New System.Drawing.Point(272, 224)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(32, 20)
        Me.btnGo.TabIndex = 6
        Me.btnGo.Text = "Go"
        '
        'btnViewDiscUnits
        '
        Me.btnViewDiscUnits.BackColor = System.Drawing.Color.SteelBlue
        Me.btnViewDiscUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewDiscUnits.ForeColor = System.Drawing.Color.White
        Me.btnViewDiscUnits.Location = New System.Drawing.Point(600, 224)
        Me.btnViewDiscUnits.Name = "btnViewDiscUnits"
        Me.btnViewDiscUnits.Size = New System.Drawing.Size(200, 20)
        Me.btnViewDiscUnits.TabIndex = 7
        Me.btnViewDiscUnits.Text = "View Discrepancy Units"
        '
        'dbgRecData
        '
        Me.dbgRecData.AllowUpdate = False
        Me.dbgRecData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgRecData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgRecData.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.dbgRecData.Location = New System.Drawing.Point(8, 248)
        Me.dbgRecData.Name = "dbgRecData"
        Me.dbgRecData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgRecData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgRecData.PreviewInfo.ZoomFactor = 75
        Me.dbgRecData.Size = New System.Drawing.Size(792, 240)
        Me.dbgRecData.TabIndex = 8
        Me.dbgRecData.Text = "C1TrueDBGrid1"
        Me.dbgRecData.Visible = False
        Me.dbgRecData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style9{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
        "yle14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Alig" & _
        "nVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}" & _
        "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styl" & _
        "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
        "ctorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
        "=""1""><Height>236</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
        "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
        "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
        """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
        "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
        "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
        " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
        "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
        ", 0, 788, 236</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
        "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
        "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
        "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
        "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
        "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
        "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
        "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
        "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
        "</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 788, 236</" & _
        "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
        "parent="""" me=""Style15"" /></Blob>"
        '
        'cboBauds
        '
        Me.cboBauds.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboBauds.Caption = ""
        Me.cboBauds.CaptionHeight = 17
        Me.cboBauds.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboBauds.ColumnCaptionHeight = 17
        Me.cboBauds.ColumnFooterHeight = 17
        Me.cboBauds.ContentHeight = 15
        Me.cboBauds.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboBauds.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboBauds.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBauds.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboBauds.EditorHeight = 15
        Me.cboBauds.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboBauds.ItemHeight = 15
        Me.cboBauds.Location = New System.Drawing.Point(96, 168)
        Me.cboBauds.MatchEntryTimeout = CType(2000, Long)
        Me.cboBauds.MaxDropDownItems = CType(5, Short)
        Me.cboBauds.MaxLength = 32767
        Me.cboBauds.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboBauds.Name = "cboBauds"
        Me.cboBauds.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboBauds.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboBauds.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboBauds.Size = New System.Drawing.Size(256, 21)
        Me.cboBauds.TabIndex = 3
        Me.cboBauds.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
        "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
        "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
        "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
        "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
        "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
        "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
        "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
        "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
        "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
        "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
        "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
        "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
        """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
        "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
        "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
        "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
        "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
        "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 176)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Baud Rate:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SlateGray
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(312, 224)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(40, 20)
        Me.btnClear.TabIndex = 32
        Me.btnClear.Text = "Clear"
        '
        'pnlDiscrep
        '
        Me.pnlDiscrep.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlDiscrep.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMissingFreq, Me.Label11, Me.lblMissingCap, Me.Label10, Me.lblMissingBaud, Me.lblDuplicateSN, Me.lblMissingSN, Me.Label12, Me.Label13, Me.Label14})
        Me.pnlDiscrep.Location = New System.Drawing.Point(368, 80)
        Me.pnlDiscrep.Name = "pnlDiscrep"
        Me.pnlDiscrep.Size = New System.Drawing.Size(224, 136)
        Me.pnlDiscrep.TabIndex = 33
        Me.pnlDiscrep.Visible = False
        '
        'lblMissingFreq
        '
        Me.lblMissingFreq.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingFreq.Location = New System.Drawing.Point(152, 104)
        Me.lblMissingFreq.Name = "lblMissingFreq"
        Me.lblMissingFreq.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingFreq.TabIndex = 23
        Me.lblMissingFreq.Text = "0"
        Me.lblMissingFreq.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.Location = New System.Drawing.Point(24, 104)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 16)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Missing Frequency:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMissingCap
        '
        Me.lblMissingCap.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingCap.Location = New System.Drawing.Point(152, 80)
        Me.lblMissingCap.Name = "lblMissingCap"
        Me.lblMissingCap.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingCap.TabIndex = 21
        Me.lblMissingCap.Text = "0"
        Me.lblMissingCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(24, 80)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 16)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Missing Capcode:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMissingBaud
        '
        Me.lblMissingBaud.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingBaud.Location = New System.Drawing.Point(152, 56)
        Me.lblMissingBaud.Name = "lblMissingBaud"
        Me.lblMissingBaud.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingBaud.TabIndex = 19
        Me.lblMissingBaud.Text = "0"
        Me.lblMissingBaud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDuplicateSN
        '
        Me.lblDuplicateSN.ForeColor = System.Drawing.Color.Blue
        Me.lblDuplicateSN.Location = New System.Drawing.Point(152, 32)
        Me.lblDuplicateSN.Name = "lblDuplicateSN"
        Me.lblDuplicateSN.Size = New System.Drawing.Size(48, 16)
        Me.lblDuplicateSN.TabIndex = 18
        Me.lblDuplicateSN.Text = "0"
        Me.lblDuplicateSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMissingSN
        '
        Me.lblMissingSN.ForeColor = System.Drawing.Color.Blue
        Me.lblMissingSN.Location = New System.Drawing.Point(152, 8)
        Me.lblMissingSN.Name = "lblMissingSN"
        Me.lblMissingSN.Size = New System.Drawing.Size(48, 16)
        Me.lblMissingSN.TabIndex = 17
        Me.lblMissingSN.Text = "0"
        Me.lblMissingSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.Location = New System.Drawing.Point(24, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 16)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Missing Baud Rate:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(24, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(120, 16)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Duplicate S/N:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.Location = New System.Drawing.Point(24, 8)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Missing S/N:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCloseWO
        '
        Me.btnCloseWO.BackColor = System.Drawing.Color.Green
        Me.btnCloseWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseWO.ForeColor = System.Drawing.Color.White
        Me.btnCloseWO.Location = New System.Drawing.Point(368, 224)
        Me.btnCloseWO.Name = "btnCloseWO"
        Me.btnCloseWO.Size = New System.Drawing.Size(80, 20)
        Me.btnCloseWO.TabIndex = 34
        Me.btnCloseWO.Text = "Close WO"
        '
        'dbgDiscUnits
        '
        Me.dbgDiscUnits.AllowUpdate = False
        Me.dbgDiscUnits.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgDiscUnits.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgDiscUnits.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.dbgDiscUnits.Location = New System.Drawing.Point(600, 32)
        Me.dbgDiscUnits.Name = "dbgDiscUnits"
        Me.dbgDiscUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgDiscUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgDiscUnits.PreviewInfo.ZoomFactor = 75
        Me.dbgDiscUnits.Size = New System.Drawing.Size(200, 184)
        Me.dbgDiscUnits.TabIndex = 35
        Me.dbgDiscUnits.Text = "C1TrueDBGrid1"
        Me.dbgDiscUnits.Visible = False
        Me.dbgDiscUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
        "yle12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Back" & _
        "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
        "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styl" & _
        "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
        "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
        "ctorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
        "=""1""><Height>180</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
        "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
        "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
        """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
        "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
        "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
        " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
        "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
        ", 0, 196, 180</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
        "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
        "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
        "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
        "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
        "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
        "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
        "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
        "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
        "</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 196, 180</" & _
        "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
        "parent="""" me=""Style15"" /></Blob>"
        '
        'btnViewRecvdUnits
        '
        Me.btnViewRecvdUnits.BackColor = System.Drawing.Color.SteelBlue
        Me.btnViewRecvdUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewRecvdUnits.ForeColor = System.Drawing.Color.White
        Me.btnViewRecvdUnits.Location = New System.Drawing.Point(456, 224)
        Me.btnViewRecvdUnits.Name = "btnViewRecvdUnits"
        Me.btnViewRecvdUnits.Size = New System.Drawing.Size(136, 20)
        Me.btnViewRecvdUnits.TabIndex = 36
        Me.btnViewRecvdUnits.Text = "View Received Units"
        '
        'lblTask
        '
        Me.lblTask.Font = New System.Drawing.Font("Arial Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTask.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.lblTask.Name = "lblTask"
        Me.lblTask.Size = New System.Drawing.Size(360, 24)
        Me.lblTask.TabIndex = 37
        Me.lblTask.Text = "Task Label"
        '
        'frmSkyTelRec
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(808, 494)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.txtRMA, Me.lblTask, Me.btnViewRecvdUnits, Me.dbgDiscUnits, Me.btnCloseWO, Me.pnlDiscrep, Me.btnClear, Me.cboBauds, Me.Label9, Me.dbgRecData, Me.btnViewDiscUnits, Me.btnGo, Me.lblScanQtyVal, Me.lblFileQtyVal, Me.Label8, Me.lblFileQtyLabel, Me.Label7, Me.txtSN, Me.Label5, Me.txtCap, Me.cboModels, Me.Label1, Me.lblPO, Me.Label6, Me.lblLoc, Me.cboFreqs, Me.Label4, Me.Label2})
        Me.Name = "frmSkyTelRec"
        Me.Text = "frmSkyTelRec"
        CType(Me.cboFreqs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgRecData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboBauds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDiscrep.ResumeLayout(False)
        CType(Me.dbgDiscUnits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    Private Sub frmSkyTelRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable

        Try
            Generic.DisposeDT(dt)
            dt = Generic.GetFreqs(True)
            Misc.PopulateC1DropDownList(Me.cboFreqs, dt, "freq_Number", "freq_id")
            Me.cboFreqs.SelectedValue = 0

            Generic.DisposeDT(dt)
            dt = Generic.GetBauds(True)
            Misc.PopulateC1DropDownList(Me.cboBauds, dt, "baud_Number", "baud_id")
            Me.cboBauds.SelectedValue = 0

            Me.lblTask.Text = _strTabPageTitle
            Me.lblTask.Width = Me.Width

            Me.txtRMA.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)

        End Try
    End Sub

    '********************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.ClearContrlsAndVars()
        Me.txtRMA.Focus()
    End Sub

    '********************************************************************
    Private Sub txtCap_txtRMA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCap.KeyPress, txtRMA.KeyPress
        If e.KeyChar.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar.IsControl(e.KeyChar) = False Then
            e.Handled = True
        End If
    End Sub

    '********************************************************************
    Private Sub txtRMA_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRMA.KeyUp
        Dim dt, dtModels, dtFileData As DataTable
        Dim strRMA As String = ""
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtRMA.Text.Trim.Length = 0 Then Exit Sub

                strRMA = Me.txtRMA.Text.Trim.ToString

                '************************************
                'clear controls and global variables
                '************************************
                Me.ClearContrlsAndVars()
                Me.pnlDiscrep.Visible = False
                Me.lblDuplicateSN.Text = "0"
                Me.lblMissingSN.Text = "0"
                Me.lblMissingBaud.Text = "0"
                Me.lblMissingCap.Text = "0"
                Me.lblMissingFreq.Text = "0"
                '************************************
                Me.txtRMA.Text = strRMA
                'MessageBox.Show("_iMenuCustID=" & _iMenuCustID & "   strRMA=" & strRMA)
                dt = Me._objSkyTel.GetSkyTelRMA(_iMenuCustID, strRMA)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("RMA/WO does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll()
                Else
                    _iTrayID = Generic.GetTrayID(dt.Rows(0)("WO_ID"))
                    If Me._iTrayID = 0 Then
                        MessageBox.Show("Tray ID is missing for this RMA. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtRMA.SelectAll()
                    Else
                        Me.txtRMA.Enabled = False
                        Me.lblLoc.Text = dt.Rows(0)("Cust_Name1") & "-" & dt.Rows(0)("Loc_Name")
                        If IsDBNull(dt.Rows(0)("PO_ID")) OrElse dt.Rows(0)("PO_ID") = 0 Then Me.lblPO.Text = "N/A" Else Me.lblPO.Text = dt.Rows(0)("PO_ID")
                        Me.lblFileQtyVal.Text = dt.Rows(0)("WO_Quantity")
                        'Me.lblScanQtyVal.Text = Generic.GetRecQty(dt.Rows(0)("WO_ID"))
                        Me.lblScanQtyVal.Text = Generic.GetRecQty(dt.Rows(0)("WO_ID"))
                        Me._iLocID = dt.Rows(0)("Loc_ID")
                        Me._iWOID = dt.Rows(0)("WO_ID")
                        Me._iCameWithFile = dt.Rows(0)("WO_CameWithFile")

                        '***********************************
                        'populate data
                        '***********************************
                        Me.PopulateRecData()
                        '***********************************
                        dtModels = Generic.GetModels(True, dt.Rows(0)("Prod_ID"))
                        Misc.PopulateC1DropDownList(Me.cboModels, dtModels, "Model_desc", "Model_id")
                        Me.cboModels.SelectedValue = 0
                        Me.cboModels.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtRMA_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
            Generic.DisposeDT(dtFileData)
        End Try
    End Sub

    '********************************************************************
    Private Sub ClearContrlsAndVars()
        Me.txtRMA.Enabled = True
        Me.txtRMA.Text = ""
        Me.lblLoc.Text = ""
        Me.lblPO.Text = "N/A"
        Me.cboModels.Text = ""
        Me.cboModels.DataSource = Nothing
        Me.cboFreqs.SelectedValue = 0
        Me.cboBauds.SelectedValue = 0
        Me.txtCap.Text = ""
        Me.txtSN.Text = ""
        Me.lblFileQtyVal.Text = 0
        Me.lblScanQtyVal.Text = 0
        Me.dbgRecData.DataSource = Nothing
        Me.dbgRecData.Visible = False
        Me.pnlDiscrep.Visible = False
        Me.lblDuplicateSN.Text = "0"
        Me.lblMissingSN.Text = "0"
        Me.lblMissingBaud.Text = "0"
        Me.lblMissingCap.Text = "0"
        Me.lblMissingFreq.Text = "0"
        Me.dbgDiscUnits.DataSource = Nothing
        Me.dbgDiscUnits.Visible = False

        'Global Varialble
        Me._iLocID = 0
        Me._iTrayID = 0
        Me._iWOID = 0
        Me._iCameWithFile = 0
        Me._booDiscrepancy = False
    End Sub

    '********************************************************************
    Private Sub cbos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModels.KeyUp, cboFreqs.KeyUp, cboBauds.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.txtRMA.Text.Trim.Length = 0 Or Me._iWOID = 0 Then Exit Sub

                If sender.name().ToString.Trim = "cboModels" Then
                    If Me.cboModels.SelectedValue > 0 And Me._iCameWithFile > 0 Then Me.txtSN.Focus() Else Me.cboFreqs.Focus()
                ElseIf sender.name().ToString.Trim = "cboFreqs" Then
                    If Me.cboFreqs.SelectedValue > 0 Then Me.cboBauds.Focus()
                ElseIf sender.name().ToString.Trim = "cboBauds" Then
                    If Me.cboBauds.SelectedValue > 0 Then
                        Me.txtCap.SelectAll()
                        Me.txtCap.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboModels_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub txtCap_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCap.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Me.txtCap.Text.Trim.Length > 0 Then
                Me.txtSN.SelectAll()
                Me.txtSN.Focus()
            End If
        End If
    End Sub

    '********************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                Me.ProcessSN()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessSN()
        Dim i As Integer = 0
        Dim dtFileData As DataTable
        Dim R1 As DataRow
        Dim iSDID As Integer = 0

        Try
            If Me.txtRMA.Text.Trim.Length = 0 Or Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO and press enter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtRMA.SelectAll()
                Me.txtRMA.Focus()
            ElseIf IsNothing(Me.cboModels.DataSource) = True OrElse Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboModels.Focus()
            Else
                '******************************
                'Get File data and check for discrepancy
                '******************************
                If Me._iCameWithFile = 1 Then
                    dtFileData = Me._objSkyTel.GetFileData(Me.txtRMA.Text.Trim, Me.txtSN.Text.Trim)

                    If dtFileData.Rows.Count = 0 Then
                        MessageBox.Show("S/N is not listed in the file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll()
                        Me.txtSN.Focus()
                        Exit Sub
                    ElseIf dtFileData.Rows(0)("sd_BlankSN") > 0 Or dtFileData.Rows(0)("sd_DuplSN") > 0 Or dtFileData.Rows(0)("sd_NoBaud") > 0 Or dtFileData.Rows(0)("sd_NoCapcode") > 0 Or dtFileData.Rows(0)("sd_NoFreq") > 0 Then
                        MessageBox.Show("S/N is an discrepancy. You are not allow to receive any discrepant units.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll()
                        Me.txtSN.Focus()
                        Exit Sub
                    ElseIf Not IsDBNull(dtFileData.Rows(0)("Device_ID")) AndAlso dtFileData.Rows(0)("Device_ID") > 0 Then
                        MessageBox.Show("S/N has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll()
                        Me.txtSN.Focus()
                        Exit Sub
                    Else
                        Me.cboBauds.SelectedValue = dtFileData.Rows(0)("baud_id")
                        Me.cboFreqs.SelectedValue = dtFileData.Rows(0)("freq_id")
                        Me.txtCap.Text = dtFileData.Rows(0)("sd_CapCode")
                        iSDID = dtFileData.Rows(0)("sd_id")
                        Application.DoEvents()
                    End If
                End If
                '******************************

                If Me.txtCap.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter capcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCap.Focus()
                ElseIf Me.txtSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.Focus()
                    Exit Sub
                ElseIf Me.cboFreqs.SelectedValue = 0 Then
                    MessageBox.Show("Please select frequency.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboFreqs.Focus()
                ElseIf Me.cboBauds.SelectedValue = 0 Then
                    MessageBox.Show("Please select baud rate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBauds.Focus()
                Else
                    '**************************
                    'check for format                'Disabled by 05-02-2012 , requested by Thomson Moralez
                    '**************************
                    'For i = 1 To Me.txtSN.Text.Trim.Length
                    '    If Char.IsLetterOrDigit(Mid(Me.txtSN.Text.Trim, i, 1)) = False Then
                    '        MessageBox.Show("Invalid format of S/N." & Environment.NewLine & "S/N format can only be leter or number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '        Me.txtSN.Focus()
                    '        Exit Sub
                    '    End If
                    'Next i

                    '**************************
                    'check duplicate (open WIP)
                    '**************************
                    'If Generic.IsSNInWIP(SkyTel.SKYTEL_CUSTOMER_ID, Me.txtSN.Text.Trim.ToUpper) = True Then
                    If Generic.IsSNInWIP(_iMenuCustID, Me.txtSN.Text.Trim.ToUpper) = True Then
                        MessageBox.Show("S/N is existed in WIP." & Environment.NewLine & "S/N format can only be leter or number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboBauds.SelectedValue = 0
                        Me.cboFreqs.SelectedValue = 0
                        Me.txtCap.Text = ""
                        Me.txtSN.SelectAll()
                        Me.txtSN.Focus()
                        Exit Sub
                    End If

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = 0

                    i = Me._objSkyTel.ReceiveDevice(Me._iLocID, Me.txtRMA.Text.Trim.ToUpper, Me._iWOID, Me._iTrayID, Me.cboModels.SelectedValue, Me.cboFreqs.Text.Trim, Me.cboFreqs.SelectedValue, Me.cboBauds.Text.Trim, Me.cboBauds.SelectedValue, Me.txtCap.Text.Trim.ToUpper, Me.txtSN.Text.Trim.ToUpper, Me._iCameWithFile, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, iSDID)

                    If i > 0 Then
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        Me.lblScanQtyVal.Text = Generic.GetRecQty(Me._iWOID)
                        Me.txtSN.Text = ""
                        Me.txtCap.Text = ""

                        'Me.PopulateRecData()
                        Application.DoEvents()
                        If Me._iCameWithFile = 0 Then
                            Me.txtCap.Focus()
                        Else
                            Me.cboBauds.SelectedValue = 0
                            Me.cboFreqs.SelectedValue = 0
                            Me.txtSN.Focus()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            If Me._iCameWithFile = 1 Then
                Me.txtSN.Text = ""
                Me.txtCap.Text = ""
                Me.cboBauds.SelectedValue = 0
                Me.cboFreqs.SelectedValue = 0
            End If
            Throw ex
        Finally
            Generic.DisposeDT(dtFileData)
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '********************************************************************
    Private Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Try
            Me.ProcessSN()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnGo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.txtCap.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub btnViewDiscUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewDiscUnits.Click
        Try
            If Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.PopulateDiscrepancyUnits()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnViewRecData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.txtCap.Text = ""
            Me.txtSN.Text = ""
            If Me._iCameWithFile = 1 Then Me.txtSN.Focus() Else Me.txtCap.Focus()
        End Try
    End Sub

    '***************************************************************
    Private Sub PopulateDiscrepancyUnits()
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim styYes As C1.Win.C1TrueDBGrid.Style
        Dim fntYes As Font

        Try
            If Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                dt = Me._objSkyTel.GetDiscrepancyUnits(Me.txtRMA.Text.Trim)

                With Me.dbgDiscUnits
                    .DataSource = dt.DefaultView
                    .Visible = True
                    .AllowFilter = True
                    .FilterBar = True

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                        .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                        'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink


                        styYes = New C1.Win.C1TrueDBGrid.Style()
                        fntYes = New Font(styYes.Font, FontStyle.Bold)
                        styYes.Font = fntYes
                        styYes.ForeColor = Color.Red
                        .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "YES")

                        If dt.Columns(i).Caption = "SN" Then
                            .Splits(0).DisplayColumns(i).Frozen = True
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption = "Rcv Date" Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        ElseIf dt.Columns(i).Caption = "Capcode" Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Else
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        End If

                        If dt.Columns(i).Caption = "SN" Then
                            .Splits(0).DisplayColumns(i).Width = 90
                        ElseIf dt.Columns(i).Caption = "Rcv Date" Then
                            .Splits(0).DisplayColumns(i).Width = 80
                        ElseIf dt.Columns(i).Caption = "Frequency" Or dt.Columns(i).Caption = "Capcode" Or dt.Columns(i).Caption = "Baud" Then
                            .Splits(0).DisplayColumns(i).Width = 70
                        Else
                            .Splits(0).DisplayColumns(i).Width = 60
                        End If
                    Next i

                    .Splits(0).DisplayColumns("sd_id").Visible = False

                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '***************************************************************
    Private Sub PopulateRecData()
        Dim dt As DataTable
        Dim i As Integer = 0
        Dim styYes As C1.Win.C1TrueDBGrid.Style
        Dim fntYes As Font
        Dim drArrDiscUnit() As DataRow

        Try
            If Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                dt = Me._objSkyTel.GetDevRcvdByWO(Me._iWOID, Me.txtRMA.Text.Trim, Me._iCameWithFile)

                With Me.dbgRecData
                    .DataSource = dt.DefaultView
                    .Visible = True
                    .AllowFilter = True
                    .FilterBar = True


                    styYes = New C1.Win.C1TrueDBGrid.Style()
                    fntYes = New Font(styYes.Font, FontStyle.Bold)
                    styYes.Font = fntYes
                    styYes.ForeColor = Color.Red
                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "YES")

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                        .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                        'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                        If dt.Columns(i).Caption = "SN" Then
                            .Splits(0).DisplayColumns(i).Frozen = True
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption = "Rcvg Date" Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        ElseIf dt.Columns(i).Caption = "Capcode" Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Else
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        End If

                        If dt.Columns(i).Caption = "SN" Then
                            .Splits(0).DisplayColumns(i).Width = 120
                        Else
                            .Splits(0).DisplayColumns(i).Width = 75
                        End If

                        'If dt.Columns(i).Caption = "No SN" Or dt.Columns(i).Caption = "Dupl SN" Or dt.Columns(i).Caption = "No Baud" Or dt.Columns(i).Caption = "Dupl Cap" Or dt.Columns(i).Caption = "No Freq" Then
                        '    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "YES")
                        'End If
                    Next i

                    If Me._iCameWithFile = 1 Then
                        Me.txtCap.Enabled = False
                        Me.cboBauds.Enabled = False
                        Me.cboFreqs.Enabled = False
                        '***********************************
                        'Discrepancy 
                        '***********************************
                        Me.pnlDiscrep.Visible = True
                        Me.lblDuplicateSN.Text = dt.Select("[Dupl SN] = 'YES'").Length
                        Me.lblMissingSN.Text = dt.Select("[No SN] = 'YES'").Length
                        Me.lblMissingBaud.Text = dt.Select("[No Baud] = 'YES'").Length
                        Me.lblMissingCap.Text = dt.Select("[No Cap] = 'YES'").Length
                        Me.lblMissingFreq.Text = dt.Select("[No Freq] = 'YES'").Length

                        drArrDiscUnit = dt.Select("[Dupl SN] = 'YES' OR [No SN] = 'YES' OR [No Baud] = 'YES' OR [No Cap] = 'YES' OR [No Freq] = 'YES' ", "")

                        For i = 0 To drArrDiscUnit.Length - 1
                            .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, drArrDiscUnit(i)("SN"))
                        Next i
                    Else
                        Me.txtCap.Enabled = True
                        Me.cboBauds.Enabled = True
                        Me.cboFreqs.Enabled = True
                    End If
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '********************************************************************
    Private Sub btnCloseWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseWO.Click
        Dim i As Integer = 0
        Dim dtWo As DataTable

        Try
            If Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtRMA.Focus()
            Else
                If CInt(Me.lblFileQtyVal.Text) <> CInt(Me.lblScanQtyVal.Text) Then
                    If MessageBox.Show("There is discrepancy in quantity(" & Me.lblFileQtyLabel.Text & " vs " & Me.lblScanQtyVal.Text & "). Would you like to proceed?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Me.txtSN.Focus()
                        Exit Sub
                    End If
                End If

                dtWo = Me._objSkyTel.GetSkyTelRMA(_iMenuCustID, Me.txtRMA.Text.Trim)

                If MessageBox.Show("Are you sure you want to close this WO?", "Informtion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

                i = Generic.CloseWO(Me._iWOID)
                Me.ClearContrlsAndVars()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCloseWO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dtWo)
            Me.txtRMA.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub btnViewRecvdUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewRecvdUnits.Click
        Try
            If Me._iWOID = 0 Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtRMA.Focus()
            Else
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                Me.PopulateRecData()
                Application.DoEvents()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnViewRecvdUnits_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtSN.Focus()
        End Try
    End Sub

    '********************************************************************

    Private Sub txtSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSN.TextChanged

    End Sub
End Class
