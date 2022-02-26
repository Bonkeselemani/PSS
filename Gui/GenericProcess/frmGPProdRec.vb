Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.[Global]

Namespace Gui.GenericProcess
    Public Class frmGPProdRec
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _iTrayID As Integer = 0
        Private _objGP As Data.Buisness.GenericProcess.clsGenericProcess

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objGP = New Data.Buisness.GenericProcess.clsGenericProcess()

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
        Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboOpenRMA As C1.Win.C1List.C1Combo
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtSN1 As System.Windows.Forms.TextBox
        Friend WithEvents txtInRMA As System.Windows.Forms.TextBox
        Friend WithEvents txtInPO As System.Windows.Forms.TextBox
        Friend WithEvents txtSN2 As System.Windows.Forms.TextBox
        Friend WithEvents txtMemo As System.Windows.Forms.TextBox
        Friend WithEvents btnRec As System.Windows.Forms.Button
        Friend WithEvents pnlFileInfo As System.Windows.Forms.Panel
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblRejected As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblAccepted As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents lblFileQty As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents btnViewRecUnits As System.Windows.Forms.Button
        Friend WithEvents btnViewFileData As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cboProdID As C1.Win.C1List.C1Combo
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents lblRec As System.Windows.Forms.Label
        Friend WithEvents txtSN4 As System.Windows.Forms.TextBox
        Friend WithEvents txtSN3 As System.Windows.Forms.TextBox
        Friend WithEvents chkSN2 As System.Windows.Forms.CheckBox
        Friend WithEvents chkSN4 As System.Windows.Forms.CheckBox
        Friend WithEvents chkSN3 As System.Windows.Forms.CheckBox
        Friend WithEvents chkDeviceMemo As System.Windows.Forms.CheckBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents cboSku As C1.Win.C1List.C1Combo
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseWO As System.Windows.Forms.Button
        Friend WithEvents cboCostCenter As C1.Win.C1List.C1Combo
        Friend WithEvents Label11 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGPProdRec))
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboOpenRMA = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtSN1 = New System.Windows.Forms.TextBox()
            Me.dbgData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtInRMA = New System.Windows.Forms.TextBox()
            Me.txtInPO = New System.Windows.Forms.TextBox()
            Me.txtSN2 = New System.Windows.Forms.TextBox()
            Me.txtMemo = New System.Windows.Forms.TextBox()
            Me.txtSN4 = New System.Windows.Forms.TextBox()
            Me.txtSN3 = New System.Windows.Forms.TextBox()
            Me.btnRec = New System.Windows.Forms.Button()
            Me.pnlFileInfo = New System.Windows.Forms.Panel()
            Me.lblRec = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblRejected = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblAccepted = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.lblFileQty = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.btnViewRecUnits = New System.Windows.Forms.Button()
            Me.btnViewFileData = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cboProdID = New C1.Win.C1List.C1Combo()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.chkSN2 = New System.Windows.Forms.CheckBox()
            Me.chkSN4 = New System.Windows.Forms.CheckBox()
            Me.chkSN3 = New System.Windows.Forms.CheckBox()
            Me.chkDeviceMemo = New System.Windows.Forms.CheckBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.cboSku = New C1.Win.C1List.C1Combo()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseWO = New System.Windows.Forms.Button()
            Me.cboCostCenter = New C1.Win.C1List.C1Combo()
            Me.Label11 = New System.Windows.Forms.Label()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboOpenRMA, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlFileInfo.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboProdID, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboSku, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCostCenter, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboLocations
            '
            Me.cboLocations.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocations.Caption = ""
            Me.cboLocations.CaptionHeight = 17
            Me.cboLocations.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocations.ColumnCaptionHeight = 17
            Me.cboLocations.ColumnFooterHeight = 17
            Me.cboLocations.ContentHeight = 15
            Me.cboLocations.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocations.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocations.EditorHeight = 15
            Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboLocations.ItemHeight = 15
            Me.cboLocations.Location = New System.Drawing.Point(112, 72)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(5, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(248, 21)
            Me.cboLocations.TabIndex = 5
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomers.Caption = ""
            Me.cboCustomers.CaptionHeight = 17
            Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomers.ColumnCaptionHeight = 17
            Me.cboCustomers.ColumnFooterHeight = 17
            Me.cboCustomers.ContentHeight = 15
            Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 15
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(112, 40)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(248, 21)
            Me.cboCustomers.TabIndex = 4
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 16)
            Me.Label2.TabIndex = 17
            Me.Label2.Text = "Location:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 16)
            Me.Label1.TabIndex = 16
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboOpenRMA
            '
            Me.cboOpenRMA.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenRMA.Caption = ""
            Me.cboOpenRMA.CaptionHeight = 17
            Me.cboOpenRMA.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenRMA.ColumnCaptionHeight = 17
            Me.cboOpenRMA.ColumnFooterHeight = 17
            Me.cboOpenRMA.ContentHeight = 15
            Me.cboOpenRMA.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenRMA.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenRMA.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenRMA.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenRMA.EditorHeight = 15
            Me.cboOpenRMA.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboOpenRMA.ItemHeight = 15
            Me.cboOpenRMA.Location = New System.Drawing.Point(112, 104)
            Me.cboOpenRMA.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenRMA.MaxDropDownItems = CType(5, Short)
            Me.cboOpenRMA.MaxLength = 32767
            Me.cboOpenRMA.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenRMA.Name = "cboOpenRMA"
            Me.cboOpenRMA.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenRMA.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenRMA.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenRMA.Size = New System.Drawing.Size(248, 21)
            Me.cboOpenRMA.TabIndex = 6
            Me.cboOpenRMA.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(8, 104)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 19
            Me.Label3.Text = "RMA/WO:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(112, 168)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(152, 21)
            Me.cboModels.TabIndex = 7
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 168)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(96, 16)
            Me.Label4.TabIndex = 21
            Me.Label4.Text = "Model:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(280, 296)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(80, 16)
            Me.Label5.TabIndex = 23
            Me.Label5.Text = "Main SN: "
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN1
            '
            Me.txtSN1.Location = New System.Drawing.Point(368, 296)
            Me.txtSN1.Name = "txtSN1"
            Me.txtSN1.Size = New System.Drawing.Size(152, 20)
            Me.txtSN1.TabIndex = 1
            Me.txtSN1.Text = ""
            '
            'dbgData
            '
            Me.dbgData.AlternatingRows = True
            Me.dbgData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgData.FilterBar = True
            Me.dbgData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgData.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbgData.Location = New System.Drawing.Point(8, 344)
            Me.dbgData.Name = "dbgData"
            Me.dbgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgData.PreviewInfo.ZoomFactor = 75
            Me.dbgData.Size = New System.Drawing.Size(944, 208)
            Me.dbgData.TabIndex = 24
            Me.dbgData.Text = "C1TrueDBGrid1"
            Me.dbgData.Visible = False
            Me.dbgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt, styl" & _
            "e=Bold;ForeColor:Black;BackColor:LightGray;}Selected{ForeColor:HighlightText;Bac" & _
            "kColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:Inact" & _
            "iveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColo" & _
            "r:CadetBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;}Highl" & _
            "ightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Font:Tahoma" & _
            ", 8.25pt, style=Bold;ForeColor:White;BackColor:SteelBlue;}RecordSelector{AlignIm" & _
            "age:Center;}Style13{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1," & _
            " 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style" & _
            "11{}Style14{}Style15{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Merge" & _
            "View HBarHeight=""12"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Colum" & _
            "nCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Dotte" & _
            "dCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1" & _
            """ HorizontalScrollGroup=""1""><Height>204</Height><CaptionStyle parent=""Style2"" me" & _
            "=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""Ev" & _
            "enRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterSt" & _
            "yle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Hea" & _
            "dingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow" & _
            """ me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pare" & _
            "nt=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style" & _
            "11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""" & _
            "Style1"" /><ClientRect>0, 0, 940, 204</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 940, 204</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /" & _
            "><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'txtInRMA
            '
            Me.txtInRMA.Location = New System.Drawing.Point(112, 200)
            Me.txtInRMA.Name = "txtInRMA"
            Me.txtInRMA.Size = New System.Drawing.Size(152, 20)
            Me.txtInRMA.TabIndex = 9
            Me.txtInRMA.Text = ""
            '
            'txtInPO
            '
            Me.txtInPO.Location = New System.Drawing.Point(368, 200)
            Me.txtInPO.Name = "txtInPO"
            Me.txtInPO.Size = New System.Drawing.Size(152, 20)
            Me.txtInPO.TabIndex = 10
            Me.txtInPO.Text = ""
            '
            'txtSN2
            '
            Me.txtSN2.Enabled = False
            Me.txtSN2.Location = New System.Drawing.Point(112, 264)
            Me.txtSN2.Name = "txtSN2"
            Me.txtSN2.Size = New System.Drawing.Size(152, 20)
            Me.txtSN2.TabIndex = 14
            Me.txtSN2.Text = ""
            '
            'txtMemo
            '
            Me.txtMemo.Enabled = False
            Me.txtMemo.Location = New System.Drawing.Point(112, 232)
            Me.txtMemo.Name = "txtMemo"
            Me.txtMemo.Size = New System.Drawing.Size(408, 20)
            Me.txtMemo.TabIndex = 12
            Me.txtMemo.Text = ""
            '
            'txtSN4
            '
            Me.txtSN4.Enabled = False
            Me.txtSN4.Location = New System.Drawing.Point(112, 296)
            Me.txtSN4.Name = "txtSN4"
            Me.txtSN4.Size = New System.Drawing.Size(152, 20)
            Me.txtSN4.TabIndex = 18
            Me.txtSN4.Text = ""
            '
            'txtSN3
            '
            Me.txtSN3.Enabled = False
            Me.txtSN3.Location = New System.Drawing.Point(368, 264)
            Me.txtSN3.Name = "txtSN3"
            Me.txtSN3.Size = New System.Drawing.Size(152, 20)
            Me.txtSN3.TabIndex = 16
            Me.txtSN3.Text = ""
            '
            'btnRec
            '
            Me.btnRec.BackColor = System.Drawing.Color.Green
            Me.btnRec.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRec.ForeColor = System.Drawing.Color.White
            Me.btnRec.Location = New System.Drawing.Point(528, 296)
            Me.btnRec.Name = "btnRec"
            Me.btnRec.Size = New System.Drawing.Size(72, 20)
            Me.btnRec.TabIndex = 2
            Me.btnRec.Text = "Receive"
            '
            'pnlFileInfo
            '
            Me.pnlFileInfo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlFileInfo.BackColor = System.Drawing.Color.Black
            Me.pnlFileInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlFileInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRec, Me.Label6, Me.lblRejected, Me.Label8, Me.lblAccepted, Me.Label14, Me.lblFileQty, Me.Label15})
            Me.pnlFileInfo.Location = New System.Drawing.Point(616, 1)
            Me.pnlFileInfo.Name = "pnlFileInfo"
            Me.pnlFileInfo.Size = New System.Drawing.Size(336, 158)
            Me.pnlFileInfo.TabIndex = 0
            '
            'lblRec
            '
            Me.lblRec.BackColor = System.Drawing.Color.Transparent
            Me.lblRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRec.ForeColor = System.Drawing.Color.Lime
            Me.lblRec.Location = New System.Drawing.Point(216, 120)
            Me.lblRec.Name = "lblRec"
            Me.lblRec.Size = New System.Drawing.Size(104, 31)
            Me.lblRec.TabIndex = 90
            Me.lblRec.Text = "0"
            Me.lblRec.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Lime
            Me.Label6.Location = New System.Drawing.Point(0, 120)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(224, 31)
            Me.Label6.TabIndex = 89
            Me.Label6.Text = "Total Received :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRejected
            '
            Me.lblRejected.BackColor = System.Drawing.Color.Transparent
            Me.lblRejected.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRejected.ForeColor = System.Drawing.Color.Lime
            Me.lblRejected.Location = New System.Drawing.Point(224, 80)
            Me.lblRejected.Name = "lblRejected"
            Me.lblRejected.Size = New System.Drawing.Size(96, 31)
            Me.lblRejected.TabIndex = 88
            Me.lblRejected.Text = "0"
            Me.lblRejected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Lime
            Me.Label8.Location = New System.Drawing.Point(16, 80)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(208, 31)
            Me.Label8.TabIndex = 87
            Me.Label8.Text = "Rejected :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAccepted
            '
            Me.lblAccepted.BackColor = System.Drawing.Color.Transparent
            Me.lblAccepted.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccepted.ForeColor = System.Drawing.Color.Lime
            Me.lblAccepted.Location = New System.Drawing.Point(224, 40)
            Me.lblAccepted.Name = "lblAccepted"
            Me.lblAccepted.Size = New System.Drawing.Size(96, 31)
            Me.lblAccepted.TabIndex = 86
            Me.lblAccepted.Text = "0"
            Me.lblAccepted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Lime
            Me.Label14.Location = New System.Drawing.Point(16, 40)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(208, 31)
            Me.Label14.TabIndex = 85
            Me.Label14.Text = "Accepted :"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFileQty
            '
            Me.lblFileQty.BackColor = System.Drawing.Color.Transparent
            Me.lblFileQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFileQty.ForeColor = System.Drawing.Color.Lime
            Me.lblFileQty.Location = New System.Drawing.Point(224, 0)
            Me.lblFileQty.Name = "lblFileQty"
            Me.lblFileQty.Size = New System.Drawing.Size(96, 31)
            Me.lblFileQty.TabIndex = 84
            Me.lblFileQty.Text = "0"
            Me.lblFileQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.Lime
            Me.Label15.Location = New System.Drawing.Point(16, 0)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(208, 31)
            Me.Label15.TabIndex = 83
            Me.Label15.Text = "Devices in file :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnViewRecUnits
            '
            Me.btnViewRecUnits.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnViewRecUnits.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnViewRecUnits.ForeColor = System.Drawing.Color.Black
            Me.btnViewRecUnits.Location = New System.Drawing.Point(16, 24)
            Me.btnViewRecUnits.Name = "btnViewRecUnits"
            Me.btnViewRecUnits.Size = New System.Drawing.Size(128, 20)
            Me.btnViewRecUnits.TabIndex = 1
            Me.btnViewRecUnits.Text = "Received Units"
            '
            'btnViewFileData
            '
            Me.btnViewFileData.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnViewFileData.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnViewFileData.ForeColor = System.Drawing.Color.Black
            Me.btnViewFileData.Location = New System.Drawing.Point(16, 56)
            Me.btnViewFileData.Name = "btnViewFileData"
            Me.btnViewFileData.Size = New System.Drawing.Size(128, 20)
            Me.btnViewFileData.TabIndex = 2
            Me.btnViewFileData.Text = "File Data"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnViewRecUnits, Me.btnViewFileData})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(800, 168)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(152, 112)
            Me.GroupBox1.TabIndex = 1
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "View"
            '
            'cboProdID
            '
            Me.cboProdID.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProdID.Caption = ""
            Me.cboProdID.CaptionHeight = 17
            Me.cboProdID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProdID.ColumnCaptionHeight = 17
            Me.cboProdID.ColumnFooterHeight = 17
            Me.cboProdID.ContentHeight = 15
            Me.cboProdID.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProdID.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProdID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProdID.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProdID.EditorHeight = 15
            Me.cboProdID.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboProdID.ItemHeight = 15
            Me.cboProdID.Location = New System.Drawing.Point(112, 8)
            Me.cboProdID.MatchEntryTimeout = CType(2000, Long)
            Me.cboProdID.MaxDropDownItems = CType(5, Short)
            Me.cboProdID.MaxLength = 32767
            Me.cboProdID.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProdID.Name = "cboProdID"
            Me.cboProdID.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProdID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProdID.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProdID.Size = New System.Drawing.Size(248, 21)
            Me.cboProdID.TabIndex = 3
            Me.cboProdID.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label16
            '
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.White
            Me.Label16.Location = New System.Drawing.Point(0, 8)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(104, 16)
            Me.Label16.TabIndex = 164
            Me.Label16.Text = "Product Type:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkSN2
            '
            Me.chkSN2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSN2.ForeColor = System.Drawing.Color.White
            Me.chkSN2.Location = New System.Drawing.Point(56, 264)
            Me.chkSN2.Name = "chkSN2"
            Me.chkSN2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkSN2.Size = New System.Drawing.Size(56, 16)
            Me.chkSN2.TabIndex = 13
            Me.chkSN2.Text = "SN 2"
            '
            'chkSN4
            '
            Me.chkSN4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSN4.ForeColor = System.Drawing.Color.White
            Me.chkSN4.Location = New System.Drawing.Point(56, 296)
            Me.chkSN4.Name = "chkSN4"
            Me.chkSN4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkSN4.Size = New System.Drawing.Size(56, 16)
            Me.chkSN4.TabIndex = 17
            Me.chkSN4.Text = "SN 4"
            '
            'chkSN3
            '
            Me.chkSN3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkSN3.ForeColor = System.Drawing.Color.White
            Me.chkSN3.Location = New System.Drawing.Point(312, 264)
            Me.chkSN3.Name = "chkSN3"
            Me.chkSN3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkSN3.Size = New System.Drawing.Size(56, 16)
            Me.chkSN3.TabIndex = 15
            Me.chkSN3.Text = "SN 3"
            '
            'chkDeviceMemo
            '
            Me.chkDeviceMemo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDeviceMemo.ForeColor = System.Drawing.Color.White
            Me.chkDeviceMemo.Location = New System.Drawing.Point(48, 232)
            Me.chkDeviceMemo.Name = "chkDeviceMemo"
            Me.chkDeviceMemo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkDeviceMemo.Size = New System.Drawing.Size(64, 16)
            Me.chkDeviceMemo.TabIndex = 11
            Me.chkDeviceMemo.Text = "Memo"
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(8, 200)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(96, 16)
            Me.Label7.TabIndex = 165
            Me.Label7.Text = "Customer RMA: "
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(280, 200)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(80, 16)
            Me.Label9.TabIndex = 166
            Me.Label9.Text = "Customer PO: "
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboSku
            '
            Me.cboSku.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSku.Caption = ""
            Me.cboSku.CaptionHeight = 17
            Me.cboSku.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSku.ColumnCaptionHeight = 17
            Me.cboSku.ColumnFooterHeight = 17
            Me.cboSku.ContentHeight = 15
            Me.cboSku.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSku.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboSku.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSku.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboSku.EditorHeight = 15
            Me.cboSku.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboSku.ItemHeight = 15
            Me.cboSku.Location = New System.Drawing.Point(368, 168)
            Me.cboSku.MatchEntryTimeout = CType(2000, Long)
            Me.cboSku.MaxDropDownItems = CType(5, Short)
            Me.cboSku.MaxLength = 32767
            Me.cboSku.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSku.Name = "cboSku"
            Me.cboSku.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSku.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSku.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSku.Size = New System.Drawing.Size(152, 21)
            Me.cboSku.TabIndex = 8
            Me.cboSku.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(280, 168)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(80, 16)
            Me.Label10.TabIndex = 168
            Me.Label10.Text = "Sku:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCloseWO
            '
            Me.btnCloseWO.BackColor = System.Drawing.Color.DarkOliveGreen
            Me.btnCloseWO.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWO.ForeColor = System.Drawing.Color.White
            Me.btnCloseWO.Location = New System.Drawing.Point(368, 128)
            Me.btnCloseWO.Name = "btnCloseWO"
            Me.btnCloseWO.Size = New System.Drawing.Size(152, 20)
            Me.btnCloseWO.TabIndex = 169
            Me.btnCloseWO.Text = "Close RMA/WO"
            '
            'cboCostCenter
            '
            Me.cboCostCenter.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCostCenter.Caption = ""
            Me.cboCostCenter.CaptionHeight = 17
            Me.cboCostCenter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCostCenter.ColumnCaptionHeight = 17
            Me.cboCostCenter.ColumnFooterHeight = 17
            Me.cboCostCenter.ContentHeight = 15
            Me.cboCostCenter.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCostCenter.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCostCenter.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCostCenter.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCostCenter.EditorHeight = 15
            Me.cboCostCenter.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.cboCostCenter.ItemHeight = 15
            Me.cboCostCenter.Location = New System.Drawing.Point(112, 136)
            Me.cboCostCenter.MatchEntryTimeout = CType(2000, Long)
            Me.cboCostCenter.MaxDropDownItems = CType(5, Short)
            Me.cboCostCenter.MaxLength = 32767
            Me.cboCostCenter.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCostCenter.Name = "cboCostCenter"
            Me.cboCostCenter.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCostCenter.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCostCenter.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCostCenter.Size = New System.Drawing.Size(248, 21)
            Me.cboCostCenter.TabIndex = 170
            Me.cboCostCenter.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(8, 136)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(96, 16)
            Me.Label11.TabIndex = 171
            Me.Label11.Text = "Cost Center:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmGPProdRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(968, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCostCenter, Me.Label11, Me.btnCloseWO, Me.cboSku, Me.Label10, Me.Label9, Me.Label7, Me.chkDeviceMemo, Me.chkSN3, Me.chkSN4, Me.chkSN2, Me.cboProdID, Me.Label16, Me.GroupBox1, Me.pnlFileInfo, Me.btnRec, Me.txtSN4, Me.txtSN3, Me.txtMemo, Me.txtSN2, Me.txtInPO, Me.txtInRMA, Me.dbgData, Me.Label5, Me.txtSN1, Me.cboModels, Me.Label4, Me.cboOpenRMA, Me.Label3, Me.cboLocations, Me.cboCustomers, Me.Label2, Me.Label1})
            Me.Name = "frmGPProdRec"
            Me.Text = "frmGPProdRec"
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboOpenRMA, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlFileInfo.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboProdID, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboSku, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCostCenter, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************************
        Private Sub frmGPProdRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                'Populate product type
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProdID, dt, "Prod_Desc", "Prod_ID")
                Me.cboProdID.SelectedValue = 0

                'Populate Customer
                If _iMenuCustID > 0 Then
                    dt = Generic.GetCustomers(True, )
                    Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                    Me.cboCustomers.SelectedValue = _iMenuCustID
                    Me.cboCustomers.Enabled = False

                    'Populate Location
                    Generic.DisposeDT(dt)
                    dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                    Me.cboLocations.Enabled = True
                    If dt.Rows.Count = 2 Then
                        Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                        Me.cboLocations.Enabled = False
                    End If
                End If

                'Me.cboCustomers.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cboProdID_cboCustomers_cboLocations_cboOpenRMA_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProdID.Enter, cboCustomers.Enter, cboLocations.Enter, cboOpenRMA.Enter
            Try
                Me.txtInRMA.Text = ""
                Me.txtInPO.Text = ""
                Me.txtMemo.Text = ""
                Me.txtSN1.Text = "" : Me.txtSN2.Text = "" : Me.txtSN3.Text = "" : Me.txtSN4.Text = ""
                Dim st As String = sender.Name
                If sender.name = "cboProdID" Then
                    '********************************
                    'Reset Customer and Location
                    '********************************
                    If Me._iMenuCustID = 0 Then
                        If Not IsNothing(Me.cboCustomers.DataSource) Then
                            Me.cboCustomers.DataSource = Nothing
                            Me.cboCustomers.Text = ""
                        End If
                        If Not IsNothing(Me.cboLocations.DataSource) Then
                            Me.cboLocations.DataSource = Nothing
                            Me.cboLocations.Text = ""
                        End If
                    End If

                    '********************
                    'Reset Model
                    '********************
                    If Not IsNothing(Me.cboModels.DataSource) Then
                        Me.cboModels.DataSource = Nothing
                        Me.cboModels.Text = ""
                    End If
                    '********************
                    'Reset Sku
                    '********************
                    If Not IsNothing(Me.cboSku.DataSource) Then
                        Me.cboSku.DataSource = Nothing
                        Me.cboSku.Text = ""
                    End If
                    '********************

                    Me.cboProdID.SelectAll()
                ElseIf sender.name = "cboCustomers" Then
                    '********************
                    'Reset Location
                    '********************
                    If Not IsNothing(Me.cboLocations.DataSource) Then
                        Me.cboLocations.DataSource = Nothing
                        Me.cboLocations.Text = ""
                    End If
                    '********************
                    'Reset Sku
                    '********************
                    If Not IsNothing(Me.cboSku.DataSource) Then
                        Me.cboSku.DataSource = Nothing
                        Me.cboSku.Text = ""
                    End If
                    '********************
                    'Reset Cost Center
                    '********************
                    If Not IsNothing(Me.cboCostCenter.DataSource) Then
                        Me.cboCostCenter.DataSource = Nothing
                        Me.cboCostCenter.Text = ""
                    End If

                    Me.cboCustomers.SelectAll()
                ElseIf sender.name = "cboLocations" Then
                    Me.cboLocations.SelectAll()
                ElseIf sender.name = "cboOpenRMA" Then
                    Me.cboOpenRMA.SelectAll()
                    _iTrayID = 0
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "EnterEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cboProdID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProdID.KeyUp
            Dim dt As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboProdID.SelectedValue > 0 Then
                        If Me._iMenuCustID = 0 Then
                            '*******************************
                            'Load Customers list
                            '*******************************
                            dt = Generic.GetCustomers(True, Me.cboProdID.SelectedValue)
                            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                            Me.cboCustomers.SelectedValue = 0
                            '*******************************
                            Me.cboCustomers.SelectAll()
                            Me.cboCustomers.Focus()
                        Else
                            If Me.cboLocations.Enabled = False Then
                                Me.cboLocations.SelectAll()
                                Me.cboLocations.Focus()
                            Else
                                Me.cboOpenRMA.SelectAll()
                                Me.cboOpenRMA.Focus()
                            End If
                        End If

                        '*******************************
                        'Load Model List
                        '*******************************
                        dt = Generic.GetModels(True, Me.cboProdID.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
                        Me.cboModels.SelectedValue = 0
                        '*******************************
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProdID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
            Dim dtLoc, dtOpenRMA As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboCustomers.SelectedValue > 0 AndAlso Me.cboProdID.SelectedValue Then
                        dtLoc = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboLocations, dtLoc, "Loc_Name", "Loc_ID")
                        Me.cboLocations.Enabled = True
                        If dtLoc.Rows.Count = 2 Then
                            Me.cboLocations.SelectedValue = dtLoc.Rows(0)("Loc_ID")
                            Me.cboLocations.Enabled = False
                            '**********************************
                            'Populate PO
                            '**********************************
                            dtOpenRMA = Me._objGP.GetOpenRMA(True, Me.cboLocations.SelectedValue, Me.cboProdID.SelectedValue)
                            Misc.PopulateC1DropDownList(Me.cboOpenRMA, dtOpenRMA, "WO_CustWO", "WO_ID")
                            Me.cboOpenRMA.SelectedValue = 0
                            '**********************************

                            Me.cboOpenRMA.SelectAll()
                            Me.cboOpenRMA.Focus()
                        Else
                            Me.cboLocations.SelectedValue = 0
                            Me.cboLocations.SelectAll()
                            Me.cboLocations.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCustomers_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dtLoc)
                Generic.DisposeDT(dtOpenRMA)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cbotxt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLocations.KeyUp, cboOpenRMA.KeyUp, cboCostCenter.KeyUp, cboModels.KeyUp, cboSku.KeyUp, txtInRMA.KeyUp, txtInPO.KeyUp, txtMemo.KeyUp, txtSN1.KeyUp, txtSN2.KeyUp, txtSN3.KeyUp, txtSN4.KeyUp
            Dim dt As DataTable
            Dim objMisc As Data.Buisness.Misc

            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "cboLocations" Then
                        If Me.cboProdID.SelectedValue = 0 Then
                            MessageBox.Show("Please select Product Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboProdID.Focus()
                        ElseIf Me.cboLocations.SelectedValue > 0 Then
                            '**********************************
                            'Load Open RMA
                            '**********************************
                            dt = Me._objGP.GetOpenRMA(True, Me.cboLocations.SelectedValue, Me.cboProdID.SelectedValue)
                            Misc.PopulateC1DropDownList(Me.cboOpenRMA, dt, "WO_CustWO", "WO_ID")
                            Me.cboOpenRMA.SelectedValue = 0
                            '**********************************
                            Me.cboOpenRMA.SelectAll()
                            Me.cboOpenRMA.Focus()
                        End If
                    ElseIf sender.name = "cboOpenRMA" AndAlso Me.cboOpenRMA.SelectedValue > 0 Then
                        _iTrayID = PSS.Data.Buisness.Generic.GetTrayID(Me.cboOpenRMA.SelectedValue)
                        'Load Received Data
                        Me.PopulateReceiveQty()
                        Dim GroupID As Integer = 0
                        GroupID = CInt(Me.cboOpenRMA.DataSource.Table.Select("WO_ID = " & Me.cboOpenRMA.SelectedValue)(0)("Group_ID"))
                        Me.LoadCostCenter(GroupID)
                        Me.cboCostCenter.SelectAll()
                        Me.cboCostCenter.Focus()
                    ElseIf sender.name = "cboCostCenter" AndAlso Me.cboCostCenter.SelectedValue > 0 Then
                        Me.cboModels.SelectAll()
                        Me.cboModels.Focus()
                    ElseIf sender.name = "cboModels" AndAlso Me.cboModels.SelectedValue > 0 Then
                        '**********************************
                        'Load SKU
                        '**********************************
                        If Me.cboCustomers.SelectedValue > 0 Then
                            objMisc = New Data.Buisness.Misc()
                            dt = objMisc.GetSku(Me.cboCustomers.SelectedValue, Me.cboModels.SelectedValue, True)
                            Misc.PopulateC1DropDownList(Me.cboSku, dt, "Sku_Number", "Sku_ID")
                        End If
                        Me.cboSku.SelectedValue = 0
                        '**********************************
                        Me.cboSku.SelectAll()
                        Me.cboSku.Focus()
                    ElseIf sender.name = "cboSku" Then
                        Me.txtInRMA.SelectAll()
                        Me.txtInRMA.Focus()
                    ElseIf sender.name = "txtInRMA" Then
                        Me.txtInPO.SelectAll()
                        Me.txtInPO.Focus()
                    ElseIf sender.name = "txtInPO" Then
                        'Me.txtMemo.SelectAll()
                        'Me.txtMemo.Focus()
                        Me.SetControlFocus("txtInPO")
                    ElseIf sender.name = "txtMemo" Then
                        'Me.txtSN2.SelectAll()
                        'Me.txtSN2.Focus()
                        Me.SetControlFocus("txtMemo")
                    ElseIf sender.name = "txtSN2" Then
                        'Me.txtSN3.SelectAll()
                        'Me.txtSN3.Focus()
                        Me.SetControlFocus("txtSN2")
                    ElseIf sender.name = "txtSN3" Then
                        'Me.txtSN4.SelectAll()
                        'Me.txtSN4.Focus()
                        Me.SetControlFocus("txtSN3")
                    ElseIf sender.name = "txtSN4" Then
                        'Me.txtSN1.SelectAll()
                        'Me.txtSN1.Focus()
                        Me.SetControlFocus("txtSN4")
                    ElseIf sender.name = "txtSN1" AndAlso Me.txtSN1.Text.Trim.Length > 0 Then
                        Me.ReceiveUnit()
                    End If 'Controls name
                End If  'Enter Key pressed
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                objMisc = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub PopulateReceiveQty()
            Dim dt As DataTable

            Try
                dt = Me._objGP.GetFileAndRecQty(Me.cboOpenRMA.SelectedValue)
                If dt.Rows.Count > 0 Then
                    Me.lblAccepted.Text = dt.Rows(0)("RecQty")
                    Me.lblFileQty.Text = dt.Rows(0)("FileQty")
                    Me.lblRejected.Text = dt.Rows(0)("RejQty")
                    Me.lblRec.Text = dt.Rows(0)("RecQty") + dt.Rows(0)("RejQty")
                End If

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************
        Private Sub SetControlFocus(ByVal strCurrentCtrlName As String)
            Dim i, iNextEnableTabIndexCtrl, iCurrentTabIndex, iFoundCtrl As Integer

            Try
                iNextEnableTabIndexCtrl = 0

                '***********************************
                'Find current tab index
                '***********************************
                For i = 0 To Me.Controls.Count - 1
                    If strCurrentCtrlName = Me.Controls(i).Name Then
                        iCurrentTabIndex = Me.Controls(i).TabIndex
                        Exit For
                    End If
                Next i

                '***********************************
                For i = 0 To Me.Controls.Count - 1
                    If Me.Controls(i).Name.StartsWith("txt") Or Me.Controls(i).Name.StartsWith("cbo") Then
                        If Me.Controls(i).TabIndex > iCurrentTabIndex AndAlso Me.Controls(i).Enabled = True Then
                            If iNextEnableTabIndexCtrl = 0 Then
                                iNextEnableTabIndexCtrl = Me.Controls(i).TabIndex
                                iFoundCtrl = i
                            End If

                            If iNextEnableTabIndexCtrl > Me.Controls(i).TabIndex Then
                                iNextEnableTabIndexCtrl = Me.Controls(i).TabIndex
                                iFoundCtrl = i
                            End If
                        End If

                        If Me.Controls(i).Enabled = True Then Me.Controls(i).BackColor = Color.White
                    End If  'Textbox or C1-Combobox
                Next i

                '***********************************
                'high light control
                '***********************************
                If iNextEnableTabIndexCtrl > 0 Then
                    Me.Controls(iFoundCtrl).BackColor = Color.Yellow
                    Me.Controls(iFoundCtrl).Focus()
                End If
                '***********************************
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************
        Private Sub chkSN2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDeviceMemo.CheckedChanged, chkSN2.CheckedChanged, chkSN3.CheckedChanged, chkSN4.CheckedChanged
            Try
                Select Case sender.name
                    Case "chkDeviceMemo"
                        If Me.chkDeviceMemo.Checked = True Then Me.txtMemo.Enabled = True Else Me.txtMemo.Enabled = False
                    Case "chkSN2"
                        If Me.chkSN2.Checked = True Then Me.txtSN2.Enabled = True Else Me.txtSN2.Enabled = False
                    Case "chkSN3"
                        If Me.chkSN3.Checked = True Then Me.txtSN3.Enabled = True Else Me.txtSN3.Enabled = False
                    Case "chkSN4"
                        If Me.chkSN4.Checked = True Then Me.txtSN4.Enabled = True Else Me.txtSN4.Enabled = False
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '********************************************************************************
        Private Function ReceiveUnit() As Boolean
            Dim iCCID As Integer = 0
            Dim dt As DataTable
            Dim iDeviceID, iDiscrepancy, iASNDataID As Integer

            Try
                iDeviceID = 0 : iDiscrepancy = 0 : iASNDataID = 0

                If Me.txtSN1.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN1. This is the main SN to track in the system therefore can't be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN1.SelectAll()
                    Me.txtSN1.Focus()
                ElseIf Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf Me.cboLocations.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLocations.SelectAll()
                    Me.cboLocations.Focus()
                ElseIf Me.cboOpenRMA.SelectedValue = 0 Then
                    MessageBox.Show("Please select RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenRMA.SelectAll()
                    Me.cboOpenRMA.Focus()
                ElseIf Me.cboCostCenter.SelectedValue = 0 And Me.cboProdID.SelectedValue <> 12 Then
                    '12=Peak
                    'Ignore the CostCenter value for Peak. The CostCenter required group_id, but the 
                    'group_id in tworkorder.Group_ID = 0 when created for Peak customer
                    MessageBox.Show("Please select Cost Center.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCostCenter.SelectAll()
                    Me.cboCostCenter.Focus()
                ElseIf Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll()
                    Me.cboModels.Focus()
                ElseIf Generic.IsSNInWIP(Me.cboCustomers.SelectedValue, Me.txtSN1.Text.Trim) = True Then
                    MessageBox.Show("IMEI is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN1.SelectAll() : Me.txtSN1.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Can't define Tray ID. Please re-select RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenRMA.SelectAll() : Me.cboOpenRMA.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    'If Me.cboProdID.SelectedValue = 14 Then iCCID = 64 'Round2 Hard Drive
                    iCCID = Me.cboCostCenter.SelectedValue

                    iDeviceID = Me._objGP.ReceiveDeviceIntoWIP(Me.cboOpenRMA.SelectedValue, Me._iTrayID, Me.cboLocations.SelectedValue, Me.cboModels.SelectedValue, Me.txtInPO.Text.Trim, Me.txtInRMA.Text.Trim, Me.txtMemo.Text.Trim, Me.txtSN1.Text.Trim.ToUpper, Me.txtSN2.Text.Trim.ToUpper, Me.txtSN3.Text.Trim.ToUpper, Me.txtSN4.Text.Trim.ToUpper, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, iDiscrepancy, iASNDataID, iCCID)
                    If iDeviceID > 0 Then

                        If Me.cboProdID.SelectedValue = 14 AndAlso Me.cboCustomers.SelectedValue = 2371 AndAlso Me.cboModels.SelectedValue = 1808 Then
                            AutoBillHardriveSortedOnly(iDeviceID) 'Sort and return without test
                        ElseIf Me.cboProdID.SelectedValue = 14 AndAlso Me.cboCustomers.SelectedValue = 2371 AndAlso Me.cboModels.SelectedValue = 1824 Then
                            AutoBillDamagedOnly(iDeviceID) 'Damage Drive
                        End If

                        Me.PopulateReceiveQty()
                        Me.txtMemo.Text = "" : Me.txtSN1.Text = "" : Me.txtSN2.Text = "" : Me.txtSN2.Text = "" : Me.txtSN3.Text = ""

                        'Me.AutoBill(iDeviceID)
                        Me.Enabled = True

                        'Set focus
                        'Me.SetControlFocus("txtInPO")
                        Me.txtSN1.Focus()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************************
        Private Sub AutoBillHardriveSortedOnly(ByVal iDeviceID As Integer)
            Const iSortedOnlyBillcode As Integer = 2025
            Dim objDevice As Rules.Device

            Try
                If Generic.IsBillcodeMapped(Me.cboModels.SelectedValue, iSortedOnlyBillcode) = 0 Then
                    MessageBox.Show("Sorted Only billcode is not mapped. Please contact Material department.", "Information", MessageBoxButtons.OK)
                Else
                    objDevice = New Rules.Device(iDeviceID)
                    If Generic.IsBillcodeExisted(iDeviceID, iSortedOnlyBillcode) = False Then
                        objDevice.AddPart(iSortedOnlyBillcode)
                        objDevice.Update()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
            End Try
        End Sub

        '********************************************************************************
        Private Sub AutoBillDamagedOnly(ByVal iDeviceID As Integer)
            Const iDamagedBillcode As Integer = 2102
            Dim objDevice As Rules.Device

            Try
                If Generic.IsBillcodeMapped(Me.cboModels.SelectedValue, iDamagedBillcode) = 0 Then
                    MessageBox.Show("Damaged billcode is not mapped. Please contact Material department.", "Information", MessageBoxButtons.OK)
                Else
                    objDevice = New Rules.Device(iDeviceID)
                    If Generic.IsBillcodeExisted(iDeviceID, iDamagedBillcode) = False Then
                        objDevice.AddPart(iDamagedBillcode)
                        objDevice.Update()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose() : objDevice = Nothing
                End If
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnViewRecUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewRecUnits.Click
            Dim dt As DataTable

            Try
                If Me.cboOpenRMA.SelectedValue = 0 Then
                    MessageBox.Show("Please select RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenRMA.SelectAll()
                    Me.cboOpenRMA.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dt = Me._objGP.GetReceivedUnits(Me.cboOpenRMA.SelectedValue, False)
                    Me.SetDataGrid(dt, "Received Units")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub SetDataGrid(ByVal dt As DataTable, ByVal strGridCaption As String)
            Dim i As Integer = 0

            Try
                With Me.dbgData
                    .DataSource = Nothing
                    .Caption = strGridCaption
                    .DataSource = dt.DefaultView
                    .Visible = True

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                        .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                        'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                        If dt.Columns(i).Caption = "Cnt" Then
                            .Splits(0).DisplayColumns(i).Width = 30
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        ElseIf dt.Columns(i).Caption = "File?" Or dt.Columns(i).Caption = "Discp?" Then
                            .Splits(0).DisplayColumns(i).Width = 50
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        ElseIf dt.Columns(i).Caption = "SN1" Then
                            .Splits(0).DisplayColumns(i).Frozen = True
                            .Splits(0).DisplayColumns(i).Width = 100
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        End If
                    Next i

                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnViewFileData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewFileData.Click
            Dim dt As DataTable

            Try
                If Me.cboOpenRMA.SelectedValue = 0 Then
                    MessageBox.Show("Please select RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenRMA.SelectAll()
                    Me.cboOpenRMA.Focus()
                ElseIf Me.cboOpenRMA.DataSource.Table.Select("WO_ID = " & cboOpenRMA.SelectedValue)(0)("WO_CameWithFile") = 0 Then
                    MessageBox.Show("This RMA/WO does not come with file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenRMA.SelectAll()
                    Me.cboOpenRMA.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dt = Me._objGP.GetReceivedUnits(Me.cboOpenRMA.SelectedValue, True)
                    Me.SetDataGrid(dt, "File Units")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnCloseWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseWO.Click
            Dim strDiscrepancyConfirmMsg As String = ""
            Dim i As Integer = 0
            Dim iFileQty As Integer = 0
            Dim iScanQty As Integer = 0
            Dim iReject As Integer = 0
            Dim dt As DataTable

            Try
                If Me.cboOpenRMA.SelectedValue = 0 Then
                    MessageBox.Show("Please select RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboOpenRMA.SelectAll() : Me.cboOpenRMA.Focus()
                ElseIf Me.lblRec.Text.Trim.Length = 0 Or Me.lblRec.Text.Trim = "0" Then
                    MessageBox.Show("This RMA/WO is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    If Me.lblRec.Text.Trim.Length > 0 Then iScanQty = CInt(Me.lblRec.Text)
                    If Me.lblFileQty.Text.Trim.Length > 0 Then iFileQty = CInt(Me.lblFileQty.Text)
                    If Me.lblRejected.Text.Trim > 0 Then iReject = CInt(Me.lblRejected.Text)

                    If iFileQty > 0 AndAlso (iFileQty - iScanQty) > 0 AndAlso MessageBox.Show("There is " & (iFileQty - iScanQty) & " unit(s) left in file. Would you like set them as discrepancy?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                        Exit Sub
                    ElseIf MessageBox.Show("Are you sure you want to close order?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        'User canel on Confirm message
                        Exit Sub
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        i = Generic.CloseWO(Me.cboOpenRMA.SelectedValue)
                        If i > 0 Then

                            If iFileQty > 0 AndAlso iFileQty > CInt(Me.lblRec.Text) Then Me._objGP.SetInFileNotInLotDiscrepancy(Me.cboOpenRMA.SelectedValue)

                            MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Enabled = True
                            '**********************************
                            'Load Open RMA
                            '**********************************
                            dt = Me._objGP.GetOpenRMA(True, Me.cboLocations.SelectedValue, Me.cboProdID.SelectedValue)
                            Misc.PopulateC1DropDownList(Me.cboOpenRMA, dt, "WO_CustWO", "WO_ID")
                            Me.cboOpenRMA.SelectedValue = 0
                            Me.cboCostCenter.SelectedValue = 0
                            '**********************************
                            If Me.cboModels.SelectedValue > 0 Then Me.cboModels.SelectedValue = 0
                            If Me.cboSku.SelectedValue > 0 Then Me.cboSku.SelectedValue = 0
                            Me.txtInPO.Text = "" : Me.txtInRMA.Text = ""
                            Me.txtMemo.Text = ""
                            Me.txtSN1.Text = "" : Me.txtSN2.Text = ""
                            Me.txtSN3.Text = "" : Me.txtSN4.Text = ""
                            Me.cboOpenRMA.SelectAll()
                            Me.cboOpenRMA.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub cboOpenRMA_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenRMA.SelectedValueChanged
            Try
                If Me.cboOpenRMA.SelectedValue > 0 Then Me.btnCloseWO.Visible = True Else Me.btnCloseWO.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenRMA_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************

        Private Sub LoadCostCenter(ByVal GroupID As Integer)
            Dim dt As DataTable
            Dim objProdRec As New PSS.Data.Production.Receiving()
            Try
                'Populate cost center list

                Me.cboCostCenter.DataSource = Nothing : Me.cboCostCenter.Text = ""
                dt = objProdRec.GetCostCenterLists(True, GroupID)
                Misc.PopulateC1DropDownList(Me.cboCostCenter, dt, "cc_desc", "cc_id")
                Me.cboCostCenter.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving__LoadCostCenter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally

                Generic.DisposeDT(dt)
                If Not objProdRec Is Nothing Then objProdRec = Nothing

            End Try
        End Sub


    End Class
End Namespace