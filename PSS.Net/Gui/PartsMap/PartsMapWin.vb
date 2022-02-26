Option Explicit On 

Imports PSS.Rules.PartsMap
Imports PSS.Data.Buisness

Namespace Gui

    Public Class PartsMapWin
        Inherits System.Windows.Forms.Form

        Private _iMapID As Integer = 0
        Private _booPopulateDataToControl As Boolean = False

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
        Friend WithEvents dbgMapped As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents gbAddUpdateMap As System.Windows.Forms.GroupBox
        Friend WithEvents cboLineOfBusiness As C1.Win.C1List.C1Combo
        Friend WithEvents cboLaborLvl As C1.Win.C1List.C1Combo
        Friend WithEvents cboBillCode As C1.Win.C1List.C1Combo
        Friend WithEvents cboPartNo As C1.Win.C1List.C1Combo
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents btnSaveData As System.Windows.Forms.Button
        Friend WithEvents btnRefreshGrid As System.Windows.Forms.Button
        Friend WithEvents chkInvisible As System.Windows.Forms.CheckBox
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboCopyMapModel As C1.Win.C1List.C1Combo
        Friend WithEvents cboCopyMapProd As C1.Win.C1List.C1Combo
        Friend WithEvents btnCopyMap As System.Windows.Forms.Button
        Friend WithEvents chkDefaultPartForNTF As System.Windows.Forms.CheckBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents pnlCustomer As System.Windows.Forms.Panel
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents dbgNTFDefaultParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboReflowTypes As C1.Win.C1List.C1Combo
        Friend WithEvents btnSetSelectRowToVisible As System.Windows.Forms.Button
        Friend WithEvents btnSetSelectRowToInVisible As System.Windows.Forms.Button
        Friend WithEvents btnCopySrvsFrSelModToAllModInProd As System.Windows.Forms.Button
        Friend WithEvents btnLanUseOnly As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PartsMapWin))
            Me.dbgMapped = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnAdd = New System.Windows.Forms.Button()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.btnRefreshGrid = New System.Windows.Forms.Button()
            Me.gbAddUpdateMap = New System.Windows.Forms.GroupBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboReflowTypes = New C1.Win.C1List.C1Combo()
            Me.pnlCustomer = New System.Windows.Forms.Panel()
            Me.dbgNTFDefaultParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.chkDefaultPartForNTF = New System.Windows.Forms.CheckBox()
            Me.chkInvisible = New System.Windows.Forms.CheckBox()
            Me.btnSaveData = New System.Windows.Forms.Button()
            Me.cboLineOfBusiness = New C1.Win.C1List.C1Combo()
            Me.cboLaborLvl = New C1.Win.C1List.C1Combo()
            Me.cboBillCode = New C1.Win.C1List.C1Combo()
            Me.cboPartNo = New C1.Win.C1List.C1Combo()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnLanUseOnly = New System.Windows.Forms.Button()
            Me.btnCopySrvsFrSelModToAllModInProd = New System.Windows.Forms.Button()
            Me.cboCopyMapProd = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboCopyMapModel = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnCopyMap = New System.Windows.Forms.Button()
            Me.btnSetSelectRowToVisible = New System.Windows.Forms.Button()
            Me.btnSetSelectRowToInVisible = New System.Windows.Forms.Button()
            CType(Me.dbgMapped, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbAddUpdateMap.SuspendLayout()
            CType(Me.cboReflowTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlCustomer.SuspendLayout()
            CType(Me.dbgNTFDefaultParts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLineOfBusiness, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLaborLvl, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboBillCode, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboPartNo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboCopyMapProd, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCopyMapModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dbgMapped
            '
            Me.dbgMapped.AllowDrag = True
            Me.dbgMapped.AllowDrop = True
            Me.dbgMapped.AllowUpdate = False
            Me.dbgMapped.AllowUpdateOnBlur = False
            Me.dbgMapped.AlternatingRows = True
            Me.dbgMapped.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgMapped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgMapped.CaptionHeight = 17
            Me.dbgMapped.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.dbgMapped.FilterBar = True
            Me.dbgMapped.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgMapped.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgMapped.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgMapped.Location = New System.Drawing.Point(232, 0)
            Me.dbgMapped.Name = "dbgMapped"
            Me.dbgMapped.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgMapped.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgMapped.PreviewInfo.ZoomFactor = 75
            Me.dbgMapped.RowHeight = 15
            Me.dbgMapped.Size = New System.Drawing.Size(912, 520)
            Me.dbgMapped.TabIndex = 0
            Me.dbgMapped.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:SkyBlue;}Selected{ForeColor:HighlightText;Back" & _
            "Color:Highlight;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}FilterBar{}OddRow{}Footer{}Caption{AlignHorz:Center;}St" & _
            "yle25{}Normal{Font:Verdana, 8.25pt;}Style26{}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Style24{}Style23{AlignHorz:Near;}Style22{}Style21{}Style2" & _
            "0{}RecordSelector{AlignImage:Center;}Style18{}Style19{}Style2{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.GroupByV" & _
            "iew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
            "7"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Reco" & _
            "rdSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrol" & _
            "lGroup=""1""><Height>489</Height><CaptionStyle parent=""Heading"" me=""Style23"" /><Ed" & _
            "itorStyle parent=""Editor"" me=""Style15"" /><EvenRowStyle parent=""EvenRow"" me=""Styl" & _
            "e21"" /><FilterBarStyle parent=""FilterBar"" me=""Style26"" /><FooterStyle parent=""Fo" & _
            "oter"" me=""Style17"" /><GroupStyle parent=""Group"" me=""Style25"" /><HeadingStyle par" & _
            "ent=""Heading"" me=""Style16"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style2" & _
            "0"" /><InactiveStyle parent=""Inactive"" me=""Style19"" /><OddRowStyle parent=""OddRow" & _
            """ me=""Style22"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style24"" /><Se" & _
            "lectedStyle parent=""Selected"" me=""Style18"" /><Style parent=""Normal"" me=""Style14""" & _
            " /><ClientRect>0, 29, 910, 489</ClientRect><BorderSide>0</BorderSide><BorderStyl" & _
            "e>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.GroupByView></Splits><NamedStyles><S" & _
            "tyle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent" & _
            "=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""H" & _
            "eading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""No" & _
            "rmal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""No" & _
            "rmal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading" & _
            """ me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""C" & _
            "aption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horz" & _
            "Splits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientAr" & _
            "ea>0, 0, 910, 518</ClientArea><PrintPageHeaderStyle parent="""" me=""Style1"" /><Pri" & _
            "ntPageFooterStyle parent="""" me=""Style2"" /></Blob>"
            '
            'btnAdd
            '
            Me.btnAdd.BackColor = System.Drawing.Color.Green
            Me.btnAdd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAdd.ForeColor = System.Drawing.Color.White
            Me.btnAdd.Location = New System.Drawing.Point(8, 32)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(56, 24)
            Me.btnAdd.TabIndex = 1
            Me.btnAdd.Text = "Add"
            '
            'btnUpdate
            '
            Me.btnUpdate.BackColor = System.Drawing.Color.Green
            Me.btnUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.ForeColor = System.Drawing.Color.White
            Me.btnUpdate.Location = New System.Drawing.Point(80, 32)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(64, 24)
            Me.btnUpdate.TabIndex = 2
            Me.btnUpdate.Text = "Update"
            '
            'btnDelete
            '
            Me.btnDelete.BackColor = System.Drawing.Color.Red
            Me.btnDelete.Enabled = False
            Me.btnDelete.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelete.ForeColor = System.Drawing.Color.White
            Me.btnDelete.Location = New System.Drawing.Point(160, 32)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(56, 24)
            Me.btnDelete.TabIndex = 3
            Me.btnDelete.Text = "Delete"
            '
            'btnRefreshGrid
            '
            Me.btnRefreshGrid.BackColor = System.Drawing.Color.LightSlateGray
            Me.btnRefreshGrid.Location = New System.Drawing.Point(8, 0)
            Me.btnRefreshGrid.Name = "btnRefreshGrid"
            Me.btnRefreshGrid.Size = New System.Drawing.Size(208, 24)
            Me.btnRefreshGrid.TabIndex = 12
            Me.btnRefreshGrid.Text = "Refresh Grid"
            '
            'gbAddUpdateMap
            '
            Me.gbAddUpdateMap.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.gbAddUpdateMap.BackColor = System.Drawing.Color.LightSteelBlue
            Me.gbAddUpdateMap.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.cboReflowTypes, Me.pnlCustomer, Me.chkDefaultPartForNTF, Me.chkInvisible, Me.btnSaveData, Me.cboLineOfBusiness, Me.cboLaborLvl, Me.cboBillCode, Me.cboPartNo, Me.cboModel, Me.cboProduct, Me.Label5, Me.Label7, Me.Label8, Me.Label9, Me.Label10, Me.Label11})
            Me.gbAddUpdateMap.Location = New System.Drawing.Point(8, 56)
            Me.gbAddUpdateMap.Name = "gbAddUpdateMap"
            Me.gbAddUpdateMap.Size = New System.Drawing.Size(208, 601)
            Me.gbAddUpdateMap.TabIndex = 15
            Me.gbAddUpdateMap.TabStop = False
            Me.gbAddUpdateMap.Visible = False
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(5, 280)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(75, 16)
            Me.Label4.TabIndex = 29
            Me.Label4.Text = "Reflow Types"
            '
            'cboReflowTypes
            '
            Me.cboReflowTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboReflowTypes.AutoCompletion = True
            Me.cboReflowTypes.AutoDropDown = True
            Me.cboReflowTypes.AutoSelect = True
            Me.cboReflowTypes.Caption = ""
            Me.cboReflowTypes.CaptionHeight = 17
            Me.cboReflowTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboReflowTypes.ColumnCaptionHeight = 17
            Me.cboReflowTypes.ColumnFooterHeight = 17
            Me.cboReflowTypes.ContentHeight = 16
            Me.cboReflowTypes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboReflowTypes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboReflowTypes.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboReflowTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboReflowTypes.EditorHeight = 16
            Me.cboReflowTypes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboReflowTypes.ItemHeight = 15
            Me.cboReflowTypes.Location = New System.Drawing.Point(80, 276)
            Me.cboReflowTypes.MatchEntryTimeout = CType(2000, Long)
            Me.cboReflowTypes.MaxDropDownItems = CType(10, Short)
            Me.cboReflowTypes.MaxLength = 32767
            Me.cboReflowTypes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboReflowTypes.Name = "cboReflowTypes"
            Me.cboReflowTypes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboReflowTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboReflowTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboReflowTypes.Size = New System.Drawing.Size(120, 22)
            Me.cboReflowTypes.TabIndex = 28
            Me.cboReflowTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'pnlCustomer
            '
            Me.pnlCustomer.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.pnlCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgNTFDefaultParts, Me.cboCustomer, Me.Label3})
            Me.pnlCustomer.Location = New System.Drawing.Point(0, 331)
            Me.pnlCustomer.Name = "pnlCustomer"
            Me.pnlCustomer.Size = New System.Drawing.Size(208, 238)
            Me.pnlCustomer.TabIndex = 27
            Me.pnlCustomer.Visible = False
            '
            'dbgNTFDefaultParts
            '
            Me.dbgNTFDefaultParts.AllowUpdate = False
            Me.dbgNTFDefaultParts.AllowUpdateOnBlur = False
            Me.dbgNTFDefaultParts.AlternatingRows = True
            Me.dbgNTFDefaultParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgNTFDefaultParts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgNTFDefaultParts.CaptionHeight = 12
            Me.dbgNTFDefaultParts.ColumnHeaders = False
            Me.dbgNTFDefaultParts.Cursor = System.Windows.Forms.Cursors.Default
            Me.dbgNTFDefaultParts.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgNTFDefaultParts.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgNTFDefaultParts.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgNTFDefaultParts.Location = New System.Drawing.Point(8, 32)
            Me.dbgNTFDefaultParts.Name = "dbgNTFDefaultParts"
            Me.dbgNTFDefaultParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgNTFDefaultParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgNTFDefaultParts.PreviewInfo.ZoomFactor = 75
            Me.dbgNTFDefaultParts.RowHeight = 15
            Me.dbgNTFDefaultParts.Size = New System.Drawing.Size(192, 198)
            Me.dbgNTFDefaultParts.TabIndex = 29
            Me.dbgNTFDefaultParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}S" & _
            "tyle12{AlignHorz:Near;}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColo" & _
            "r:SkyBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:Tr" & _
            "ue;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:C" & _
            "enter;}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterB" & _
            "ar{}OddRow{}Footer{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}Style" & _
            "10{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style11{}R" & _
            "ecordSelector{AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Style14{}Style1" & _
            "5{}Style16{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name=" & _
            """"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Column" & _
            "FooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRe" & _
            "cSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>196</He" & _
            "ight><CaptionStyle parent=""Heading"" me=""Style12"" /><EditorStyle parent=""Editor"" " & _
            "me=""Style4"" /><EvenRowStyle parent=""EvenRow"" me=""Style10"" /><FilterBarStyle pare" & _
            "nt=""FilterBar"" me=""Style16"" /><FooterStyle parent=""Footer"" me=""Style6"" /><GroupS" & _
            "tyle parent=""Group"" me=""Style15"" /><HeadingStyle parent=""Heading"" me=""Style5"" />" & _
            "<HighLightRowStyle parent=""HighlightRow"" me=""Style9"" /><InactiveStyle parent=""In" & _
            "active"" me=""Style8"" /><OddRowStyle parent=""OddRow"" me=""Style11"" /><RecordSelecto" & _
            "rStyle parent=""RecordSelector"" me=""Style14"" /><SelectedStyle parent=""Selected"" m" & _
            "e=""Style7"" /><Style parent=""Normal"" me=""Style3"" /><ClientRect>0, 0, 190, 196</Cl" & _
            "ientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1T" & _
            "rueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style " & _
            "parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pare" & _
            "nt=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style paren" & _
            "t=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""N" & _
            "ormal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""" & _
            "Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style paren" & _
            "t=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Default" & _
            "RecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 190, 196</ClientArea><Print" & _
            "PageHeaderStyle parent="""" me=""Style1"" /><PrintPageFooterStyle parent="""" me=""Styl" & _
            "e2"" /></Blob>"
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.AutoCompletion = True
            Me.cboCustomer.AutoDropDown = True
            Me.cboCustomer.AutoSelect = True
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ContentHeight = 16
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 16
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(72, 4)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(120, 22)
            Me.cboCustomer.TabIndex = 27
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label3.Location = New System.Drawing.Point(8, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(64, 16)
            Me.Label3.TabIndex = 28
            Me.Label3.Text = "Customer"
            '
            'chkDefaultPartForNTF
            '
            Me.chkDefaultPartForNTF.Location = New System.Drawing.Point(9, 304)
            Me.chkDefaultPartForNTF.Name = "chkDefaultPartForNTF"
            Me.chkDefaultPartForNTF.Size = New System.Drawing.Size(184, 16)
            Me.chkDefaultPartForNTF.TabIndex = 24
            Me.chkDefaultPartForNTF.Text = "Default Part For NTF"
            Me.chkDefaultPartForNTF.Visible = False
            '
            'chkInvisible
            '
            Me.chkInvisible.Location = New System.Drawing.Point(8, 254)
            Me.chkInvisible.Name = "chkInvisible"
            Me.chkInvisible.Size = New System.Drawing.Size(72, 16)
            Me.chkInvisible.TabIndex = 7
            Me.chkInvisible.Text = "Invisible"
            '
            'btnSaveData
            '
            Me.btnSaveData.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnSaveData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnSaveData.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveData.ForeColor = System.Drawing.Color.White
            Me.btnSaveData.Location = New System.Drawing.Point(8, 568)
            Me.btnSaveData.Name = "btnSaveData"
            Me.btnSaveData.Size = New System.Drawing.Size(192, 23)
            Me.btnSaveData.TabIndex = 8
            Me.btnSaveData.Text = "Save Data"
            '
            'cboLineOfBusiness
            '
            Me.cboLineOfBusiness.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLineOfBusiness.AutoCompletion = True
            Me.cboLineOfBusiness.AutoDropDown = True
            Me.cboLineOfBusiness.AutoSelect = True
            Me.cboLineOfBusiness.Caption = ""
            Me.cboLineOfBusiness.CaptionHeight = 17
            Me.cboLineOfBusiness.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLineOfBusiness.ColumnCaptionHeight = 17
            Me.cboLineOfBusiness.ColumnFooterHeight = 17
            Me.cboLineOfBusiness.ContentHeight = 16
            Me.cboLineOfBusiness.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLineOfBusiness.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLineOfBusiness.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLineOfBusiness.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLineOfBusiness.EditorHeight = 16
            Me.cboLineOfBusiness.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboLineOfBusiness.ItemHeight = 15
            Me.cboLineOfBusiness.Location = New System.Drawing.Point(8, 224)
            Me.cboLineOfBusiness.MatchEntryTimeout = CType(2000, Long)
            Me.cboLineOfBusiness.MaxDropDownItems = CType(10, Short)
            Me.cboLineOfBusiness.MaxLength = 32767
            Me.cboLineOfBusiness.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLineOfBusiness.Name = "cboLineOfBusiness"
            Me.cboLineOfBusiness.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLineOfBusiness.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLineOfBusiness.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLineOfBusiness.Size = New System.Drawing.Size(192, 22)
            Me.cboLineOfBusiness.TabIndex = 6
            Me.cboLineOfBusiness.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboLaborLvl
            '
            Me.cboLaborLvl.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLaborLvl.AutoCompletion = True
            Me.cboLaborLvl.AutoDropDown = True
            Me.cboLaborLvl.AutoSelect = True
            Me.cboLaborLvl.Caption = ""
            Me.cboLaborLvl.CaptionHeight = 17
            Me.cboLaborLvl.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLaborLvl.ColumnCaptionHeight = 17
            Me.cboLaborLvl.ColumnFooterHeight = 17
            Me.cboLaborLvl.ContentHeight = 16
            Me.cboLaborLvl.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLaborLvl.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLaborLvl.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLaborLvl.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLaborLvl.EditorHeight = 16
            Me.cboLaborLvl.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboLaborLvl.ItemHeight = 15
            Me.cboLaborLvl.Location = New System.Drawing.Point(8, 184)
            Me.cboLaborLvl.MatchEntryTimeout = CType(2000, Long)
            Me.cboLaborLvl.MaxDropDownItems = CType(10, Short)
            Me.cboLaborLvl.MaxLength = 32767
            Me.cboLaborLvl.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLaborLvl.Name = "cboLaborLvl"
            Me.cboLaborLvl.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLaborLvl.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLaborLvl.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLaborLvl.Size = New System.Drawing.Size(192, 22)
            Me.cboLaborLvl.TabIndex = 5
            Me.cboLaborLvl.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboBillCode
            '
            Me.cboBillCode.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBillCode.AutoCompletion = True
            Me.cboBillCode.AutoDropDown = True
            Me.cboBillCode.AutoSelect = True
            Me.cboBillCode.Caption = ""
            Me.cboBillCode.CaptionHeight = 17
            Me.cboBillCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBillCode.ColumnCaptionHeight = 17
            Me.cboBillCode.ColumnFooterHeight = 17
            Me.cboBillCode.ContentHeight = 16
            Me.cboBillCode.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBillCode.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBillCode.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBillCode.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBillCode.EditorHeight = 16
            Me.cboBillCode.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboBillCode.ItemHeight = 15
            Me.cboBillCode.Location = New System.Drawing.Point(8, 144)
            Me.cboBillCode.MatchEntryTimeout = CType(2000, Long)
            Me.cboBillCode.MaxDropDownItems = CType(10, Short)
            Me.cboBillCode.MaxLength = 32767
            Me.cboBillCode.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBillCode.Name = "cboBillCode"
            Me.cboBillCode.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBillCode.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBillCode.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBillCode.Size = New System.Drawing.Size(192, 22)
            Me.cboBillCode.TabIndex = 4
            Me.cboBillCode.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboPartNo
            '
            Me.cboPartNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPartNo.AutoCompletion = True
            Me.cboPartNo.AutoDropDown = True
            Me.cboPartNo.AutoSelect = True
            Me.cboPartNo.Caption = ""
            Me.cboPartNo.CaptionHeight = 17
            Me.cboPartNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPartNo.ColumnCaptionHeight = 17
            Me.cboPartNo.ColumnFooterHeight = 17
            Me.cboPartNo.ContentHeight = 16
            Me.cboPartNo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPartNo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPartNo.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPartNo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPartNo.EditorHeight = 16
            Me.cboPartNo.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.cboPartNo.ItemHeight = 15
            Me.cboPartNo.Location = New System.Drawing.Point(8, 104)
            Me.cboPartNo.MatchEntryTimeout = CType(2000, Long)
            Me.cboPartNo.MaxDropDownItems = CType(10, Short)
            Me.cboPartNo.MaxLength = 32767
            Me.cboPartNo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPartNo.Name = "cboPartNo"
            Me.cboPartNo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPartNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPartNo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPartNo.Size = New System.Drawing.Size(192, 22)
            Me.cboPartNo.TabIndex = 3
            Me.cboPartNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.AutoCompletion = True
            Me.cboModel.AutoDropDown = True
            Me.cboModel.AutoSelect = True
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 16
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 16
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(8, 64)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(192, 22)
            Me.cboModel.TabIndex = 2
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboProduct
            '
            Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProduct.AutoCompletion = True
            Me.cboProduct.AutoDropDown = True
            Me.cboProduct.AutoSelect = True
            Me.cboProduct.Caption = ""
            Me.cboProduct.CaptionHeight = 17
            Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProduct.ColumnCaptionHeight = 17
            Me.cboProduct.ColumnFooterHeight = 17
            Me.cboProduct.ContentHeight = 16
            Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProduct.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProduct.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProduct.EditorHeight = 16
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images9"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(8, 24)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(10, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(192, 22)
            Me.cboProduct.TabIndex = 1
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(8, 208)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(112, 16)
            Me.Label5.TabIndex = 23
            Me.Label5.Text = "Line of Business"
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(8, 11)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(112, 16)
            Me.Label7.TabIndex = 22
            Me.Label7.Text = "Product Type"
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(8, 168)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(112, 16)
            Me.Label8.TabIndex = 18
            Me.Label8.Text = "Labor Level"
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(8, 131)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(112, 16)
            Me.Label9.TabIndex = 15
            Me.Label9.Text = "Bill Code"
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(8, 90)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(112, 16)
            Me.Label10.TabIndex = 14
            Me.Label10.Text = "Part Number"
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(8, 49)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(112, 15)
            Me.Label11.TabIndex = 12
            Me.Label11.Text = "Model"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLanUseOnly, Me.btnCopySrvsFrSelModToAllModInProd, Me.cboCopyMapProd, Me.Label2, Me.cboCopyMapModel, Me.Label1, Me.btnCopyMap})
            Me.GroupBox1.Location = New System.Drawing.Point(232, 560)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(912, 96)
            Me.GroupBox1.TabIndex = 16
            Me.GroupBox1.TabStop = False
            '
            'btnLanUseOnly
            '
            Me.btnLanUseOnly.BackColor = System.Drawing.Color.Red
            Me.btnLanUseOnly.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLanUseOnly.ForeColor = System.Drawing.Color.White
            Me.btnLanUseOnly.Location = New System.Drawing.Point(784, 24)
            Me.btnLanUseOnly.Name = "btnLanUseOnly"
            Me.btnLanUseOnly.Size = New System.Drawing.Size(112, 23)
            Me.btnLanUseOnly.TabIndex = 26
            Me.btnLanUseOnly.Text = "Lan Use Only"
            Me.btnLanUseOnly.Visible = False
            '
            'btnCopySrvsFrSelModToAllModInProd
            '
            Me.btnCopySrvsFrSelModToAllModInProd.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopySrvsFrSelModToAllModInProd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySrvsFrSelModToAllModInProd.Location = New System.Drawing.Point(376, 56)
            Me.btnCopySrvsFrSelModToAllModInProd.Name = "btnCopySrvsFrSelModToAllModInProd"
            Me.btnCopySrvsFrSelModToAllModInProd.Size = New System.Drawing.Size(456, 23)
            Me.btnCopySrvsFrSelModToAllModInProd.TabIndex = 25
            Me.btnCopySrvsFrSelModToAllModInProd.Text = "CopyServices From Selected Model to All Models in Selected Product"
            Me.btnCopySrvsFrSelModToAllModInProd.Visible = False
            '
            'cboCopyMapProd
            '
            Me.cboCopyMapProd.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCopyMapProd.AutoCompletion = True
            Me.cboCopyMapProd.AutoDropDown = True
            Me.cboCopyMapProd.AutoSelect = True
            Me.cboCopyMapProd.Caption = ""
            Me.cboCopyMapProd.CaptionHeight = 17
            Me.cboCopyMapProd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCopyMapProd.ColumnCaptionHeight = 17
            Me.cboCopyMapProd.ColumnFooterHeight = 17
            Me.cboCopyMapProd.ContentHeight = 16
            Me.cboCopyMapProd.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCopyMapProd.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCopyMapProd.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCopyMapProd.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCopyMapProd.EditorHeight = 16
            Me.cboCopyMapProd.Images.Add(CType(resources.GetObject("resource.Images10"), System.Drawing.Bitmap))
            Me.cboCopyMapProd.ItemHeight = 15
            Me.cboCopyMapProd.Location = New System.Drawing.Point(96, 23)
            Me.cboCopyMapProd.MatchEntryTimeout = CType(2000, Long)
            Me.cboCopyMapProd.MaxDropDownItems = CType(10, Short)
            Me.cboCopyMapProd.MaxLength = 32767
            Me.cboCopyMapProd.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCopyMapProd.Name = "cboCopyMapProd"
            Me.cboCopyMapProd.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCopyMapProd.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCopyMapProd.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCopyMapProd.Size = New System.Drawing.Size(168, 22)
            Me.cboCopyMapProd.TabIndex = 23
            Me.cboCopyMapProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(8, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(88, 16)
            Me.Label2.TabIndex = 24
            Me.Label2.Text = "Product Type:"
            '
            'cboCopyMapModel
            '
            Me.cboCopyMapModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCopyMapModel.AutoCompletion = True
            Me.cboCopyMapModel.AutoDropDown = True
            Me.cboCopyMapModel.AutoSelect = True
            Me.cboCopyMapModel.Caption = ""
            Me.cboCopyMapModel.CaptionHeight = 17
            Me.cboCopyMapModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCopyMapModel.ColumnCaptionHeight = 17
            Me.cboCopyMapModel.ColumnFooterHeight = 17
            Me.cboCopyMapModel.ContentHeight = 16
            Me.cboCopyMapModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCopyMapModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCopyMapModel.EditorFont = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCopyMapModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCopyMapModel.EditorHeight = 16
            Me.cboCopyMapModel.Images.Add(CType(resources.GetObject("resource.Images11"), System.Drawing.Bitmap))
            Me.cboCopyMapModel.ItemHeight = 15
            Me.cboCopyMapModel.Location = New System.Drawing.Point(96, 56)
            Me.cboCopyMapModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboCopyMapModel.MaxDropDownItems = CType(10, Short)
            Me.cboCopyMapModel.MaxLength = 32767
            Me.cboCopyMapModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCopyMapModel.Name = "cboCopyMapModel"
            Me.cboCopyMapModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCopyMapModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCopyMapModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCopyMapModel.Size = New System.Drawing.Size(256, 22)
            Me.cboCopyMapModel.TabIndex = 13
            Me.cboCopyMapModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label1.Location = New System.Drawing.Point(40, 62)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 15)
            Me.Label1.TabIndex = 14
            Me.Label1.Text = "Model:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnCopyMap
            '
            Me.btnCopyMap.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyMap.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyMap.Location = New System.Drawing.Point(376, 21)
            Me.btnCopyMap.Name = "btnCopyMap"
            Me.btnCopyMap.Size = New System.Drawing.Size(320, 23)
            Me.btnCopyMap.TabIndex = 0
            Me.btnCopyMap.Text = "Copy Selected Row and Map to Selected Model"
            '
            'btnSetSelectRowToVisible
            '
            Me.btnSetSelectRowToVisible.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnSetSelectRowToVisible.BackColor = System.Drawing.Color.SteelBlue
            Me.btnSetSelectRowToVisible.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSetSelectRowToVisible.ForeColor = System.Drawing.Color.White
            Me.btnSetSelectRowToVisible.Location = New System.Drawing.Point(232, 536)
            Me.btnSetSelectRowToVisible.Name = "btnSetSelectRowToVisible"
            Me.btnSetSelectRowToVisible.Size = New System.Drawing.Size(208, 23)
            Me.btnSetSelectRowToVisible.TabIndex = 17
            Me.btnSetSelectRowToVisible.Text = "Visible Selected Rows"
            '
            'btnSetSelectRowToInVisible
            '
            Me.btnSetSelectRowToInVisible.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnSetSelectRowToInVisible.BackColor = System.Drawing.Color.SlateGray
            Me.btnSetSelectRowToInVisible.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSetSelectRowToInVisible.ForeColor = System.Drawing.Color.White
            Me.btnSetSelectRowToInVisible.Location = New System.Drawing.Point(464, 536)
            Me.btnSetSelectRowToInVisible.Name = "btnSetSelectRowToInVisible"
            Me.btnSetSelectRowToInVisible.Size = New System.Drawing.Size(216, 23)
            Me.btnSetSelectRowToInVisible.TabIndex = 18
            Me.btnSetSelectRowToInVisible.Text = "Invisible Selected Rows"
            '
            'PartsMapWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(1152, 670)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSetSelectRowToInVisible, Me.btnSetSelectRowToVisible, Me.GroupBox1, Me.gbAddUpdateMap, Me.btnRefreshGrid, Me.btnDelete, Me.btnUpdate, Me.btnAdd, Me.dbgMapped})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "PartsMapWin"
            Me.Text = "Parts / Labor Mapping"
            CType(Me.dbgMapped, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbAddUpdateMap.ResumeLayout(False)
            CType(Me.cboReflowTypes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlCustomer.ResumeLayout(False)
            CType(Me.dbgNTFDefaultParts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLineOfBusiness, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLaborLvl, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboBillCode, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboPartNo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboCopyMapProd, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCopyMapModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************************************
        Private Sub PartsMapWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Me.btnLanUseOnly.Visible = True

                LoadMappedData()

                _booPopulateDataToControl = True
                '********************************************
                'populate data for add/update mapping second
                'Lan added on 08/06/2009
                '********************************************
                Me.PopulateProducts()
                'Me.PopulateModels()
                Me.PopulatePartNos()
                'Me.PopulateBillcodes()
                Me.PopulateLaborLevels()
                Me.PopulateLineOfBusiness()
                Me.PopulateReflowTypes()
                '********************************************
                If PSS.Core.ApplicationUser.GetPermission("CopyServicesMapToAllModelsInProd") > 0 Then Me.btnCopySrvsFrSelModToAllModInProd.Visible = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PartsMapWin_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _booPopulateDataToControl = False
            End Try
        End Sub

        '*********************************************************************************
        Public Sub LoadMappedData()
            Try
                With Me.dbgMapped
                    .DataSource = MappedDataView()
                    .Splits(0).DisplayColumns("PSMap_ID").Visible = False
                    .Splits(0).DisplayColumns("Prod_ID").Visible = False
                    .Splits(0).DisplayColumns("PSPrice_ID").Visible = False
                    .Splits(0).DisplayColumns("Billcode_ID").Visible = False
                    .Splits(0).DisplayColumns("LaborLvl_ID").Visible = False
                    .Splits(0).DisplayColumns("LOB_ID").Visible = False
                    .Splits(0).DisplayColumns("Inactive").Visible = False
                    .Splits(0).DisplayColumns("ReflowTypeID").Visible = False
                    .Splits(0).DisplayColumns("Visible?").Width = 50
                    .Splits(0).DisplayColumns("LaborLevel").Width = 70
                    .Splits(0).DisplayColumns("Product").Width = 60
                    .Splits(0).DisplayColumns("Billcode Type").Width = 100
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Try
                If DeleteDataMap(CInt(Me.dbgMapped.Columns("PSMap_ID").Text)) Then
                    LoadMappedData()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDelete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************
        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Try
                '*************************
                ' Lan changed on 08/06/2009
                '*************************
                'If NewDataMap() Then
                '    LoadMappedData()
                'Else ' This is new
                '    'System.Windows.Forms.Application.DoEvents()
                '    '    LoadMappedData()
                'End If
                Me.cboReflowTypes.SelectedValue = 1
                Me.gbAddUpdateMap.Visible = True
                Me.cboProduct.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAdd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************
        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Try
                '*************************
                ' Lan changed on 08/06/2009
                '*************************
                'If UpdateDataMap(CInt(Me.dbgMapped.Columns(0).Text)) Then
                '    LoadMappedData()
                'Else ' This is new
                '    'System.Windows.Forms.Application.DoEvents()
                '    'LoadMappedData()
                'End If

                Me._iMapID = CInt(Me.dbgMapped.Columns("PSMap_ID").Value)
                If Me._iMapID > 0 Then
                    Me.gbAddUpdateMap.Visible = True
                    Me.PopulateUpdateValues()
                    Me.cboProduct.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnRefreshGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshGrid.Click
            Try
                dbgMapped.DataSource = Nothing
                LoadMappedData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshGrid_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        'add/update mapping second. Lan added on 08/06/2009
        '***************************************************************************************
        Private Sub gbAddUpdateMap_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbAddUpdateMap.Leave
            Try
                Me._iMapID = 0
                Me.cboProduct.SelectedValue = 0
                Me.cboModel.Text = ""
                Me.cboModel.DataSource = Nothing
                Me.cboPartNo.SelectedValue = 0
                Me.cboBillCode.Text = ""
                Me.cboBillCode.DataSource = Nothing
                Me.cboLaborLvl.Text = ""
                Me.cboLineOfBusiness.Text = ""
                Me.gbAddUpdateMap.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "gbAddUpdateMap_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateProducts(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                Me._booPopulateDataToControl = True

                'Product
                Me.cboProduct.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                Me.cboProduct.SelectedValue = iSelectedVal

                Misc.PopulateC1DropDownList(Me.cboCopyMapProd, dt, "Prod_Desc", "Prod_ID")
                Me.cboCopyMapProd.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Me._booPopulateDataToControl = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateModels(ByVal iProdID As Integer, _
                                   ByRef ctrl As C1.Win.C1List.C1Combo, _
                                   Optional ByVal iSelectedVal As Integer = 0, _
                                   Optional ByVal booLoadCust As Boolean = False)
            Dim dt As DataTable

            Try
                'Model
                ctrl.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = Generic.GetModels(True, iProdID)
                Misc.PopulateC1DropDownList(ctrl, dt, "Model_desc", "Model_id")
                ctrl.SelectedValue = iSelectedVal

                If booLoadCust = True Then
                    Me.dbgNTFDefaultParts.DataSource = Nothing
                    Me.cboCustomer.DataSource = Nothing
                    Generic.DisposeDT(dt)
                    dt = Generic.GetCustomers(True, iProdID)
                    Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulatePartNos(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Part number
                Me.cboPartNo.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = PartsMap.Pricing()
                dt.LoadDataRow(New Object() {"0", "--SELECT--"}, False)
                Misc.PopulateC1DropDownList(Me.cboPartNo, dt, "psprice_number", "psprice_id")
                Me.cboPartNo.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateBillcodes(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Billcode
                Me.cboBillCode.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = Generic.GetBillCodes(True, Me.cboProduct.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboBillCode, dt, "Billcode_Desc", "Billcode_ID")
                Me.cboBillCode.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateLaborLevels(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Labor Level
                Me.cboLaborLvl.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = PartsMap.LaborLevels()
                Misc.PopulateC1DropDownList(Me.cboLaborLvl, dt, "laborlvl_desc", "laborlvl_id")
                Me.cboLaborLvl.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateLineOfBusiness(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Business Line
                Me.cboLineOfBusiness.DataSource = Nothing
                Generic.DisposeDT(dt)
                dt = PartsMap.LinesOfBusiness()
                Misc.PopulateC1DropDownList(Me.cboLineOfBusiness, dt, "LOB_Desc", "LOB_ID")
                Me.cboLineOfBusiness.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateReflowTypes(Optional ByVal iSelectedVal As Integer = 0)
            Dim dt As DataTable

            Try
                'Business Line
                Me.cboReflowTypes.DataSource = Nothing
                dt = PartsMap.ReflowTypes()
                Misc.PopulateC1DropDownList(Me.cboReflowTypes, dt, "ReflowType_Desc", "ReflowTypeID")
                Me.cboLineOfBusiness.SelectedValue = iSelectedVal

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateUpdateValues()
            Dim R1 As DataRow = GetMappedDataItem(Me._iMapID)

            Try
                If Not IsNothing(R1) Then
                    Me.PopulateProducts(R1("Prod_ID"))
                    Me.PopulateModels(Me.cboProduct.SelectedValue, Me.cboModel, R1("Model_ID"), True)
                    Me.PopulatePartNos(R1("PSPrice_ID"))
                    Me.PopulateBillcodes(R1("Billcode_ID"))
                    Me.PopulateLaborLevels(R1("LaborLvl_ID"))
                    Me.PopulateLineOfBusiness(R1("LOB_ID"))
                    If R1("Inactive") = 1 Then Me.chkInvisible.Checked = True Else Me.chkInvisible.Checked = False
                    If Me.cboBillCode.SelectedValue > 0 AndAlso Me.cboBillCode.DataSource.Table.Select("Billcode_ID = " & Me.cboBillCode.SelectedValue)(0)("BillType_ID") = 2 Then
                        Me.chkDefaultPartForNTF.Visible = True
                    Else
                        Me.chkDefaultPartForNTF.Visible = False
                    End If
                    Me.cboReflowTypes.SelectedValue = R1("ReflowTypeID")
                    Me.cboProduct.Focus()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cbos_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProduct.KeyUp, cboModel.KeyUp, cboPartNo.KeyUp, cboBillCode.KeyUp, cboLaborLvl.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = Me.cboProduct.Name Then
                        If Not IsNothing(Me.cboProduct.SelectedValue) AndAlso Me.cboProduct.SelectedValue > 0 Then Me.cboModel.Focus()
                    ElseIf sender.name = Me.cboModel.Name Then
                        If Not IsNothing(Me.cboModel.SelectedValue) AndAlso Me.cboModel.SelectedValue > 0 Then Me.cboPartNo.Focus()
                    ElseIf sender.name = Me.cboPartNo.Name Then
                        If Not IsNothing(Me.cboPartNo.SelectedValue) AndAlso Me.cboPartNo.SelectedValue > 0 Then Me.cboBillCode.Focus()
                    ElseIf sender.name = Me.cboBillCode.Name Then
                        If Not IsNothing(Me.cboBillCode.SelectedValue) AndAlso Me.cboBillCode.SelectedValue > 0 Then Me.cboLaborLvl.Focus()
                    ElseIf sender.name = Me.cboLaborLvl.Name Then
                        If Not IsNothing(Me.cboLaborLvl.SelectedValue) AndAlso Me.cboLaborLvl.SelectedValue >= 0 Then Me.cboLineOfBusiness.Focus()
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnSaveData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveData.Click
            Dim iReflowTypeID, iInvisible, iModelID, iBillcodeID, iRefreshNTFDefaultPartsGrid, iLaborLevel As Integer
            Dim dt As DataTable

            Try
                If IsNothing(Me.cboProduct.SelectedValue) OrElse Me.cboProduct.SelectedValue = 0 Then
                    MessageBox.Show("Please select Product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboProduct.Focus()
                ElseIf IsNothing(Me.cboModel.SelectedValue) OrElse Me.cboModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModel.Focus()
                ElseIf IsNothing(Me.cboPartNo.SelectedValue) OrElse Me.cboPartNo.SelectedValue = 0 Then
                    MessageBox.Show("Please select Product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboPartNo.Focus()
                ElseIf IsNothing(Me.cboBillCode.SelectedValue) OrElse Me.cboBillCode.SelectedValue = 0 Then
                    MessageBox.Show("Please select Billcode.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBillCode.Focus()
                ElseIf IsNothing(Me.cboLaborLvl.SelectedValue) OrElse Me.cboLaborLvl.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please select Labor Level.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLaborLvl.Focus()
                ElseIf IsNothing(Me.cboLineOfBusiness.SelectedValue) Then
                    MessageBox.Show("Please select Line of Business.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLineOfBusiness.Focus()
                ElseIf Me.chkDefaultPartForNTF.Checked = True AndAlso Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select Customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                ElseIf Me.cboLaborLvl.Text.Trim.Length = 0 OrElse Me.cboLaborLvl.DataSource.Table.Select("laborlvl_id = " & Me.cboLaborLvl.SelectedValue).length = 0 Then
                    MessageBox.Show("Please select Labor Level.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLaborLvl.SelectAll()
                    Me.cboLaborLvl.Focus()
                ElseIf Me.cboReflowTypes.SelectedValue = 0 Then
                    MessageBox.Show("Please select Reflow Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboReflowTypes.SelectAll()
                    Me.cboReflowTypes.Focus()
                Else

                    'Set up Bill Code Maping
                    If Me.cboLineOfBusiness.SelectedValue = 9 Then 'LOB_ID=9 is TracFone
                        Dim fm As New Gui.TracFone.frmBillCodeMap(Me.cboBillCode.SelectedValue)
                        '1. try open the form in panel. It works but can't open as Showdailog
                        'fm.TopLevel = False
                        'fm.FormBorderStyle = FormBorderStyle.FixedSingle
                        'fm.ControlBox = False : fm.MaximizeBox = False : fm.MinimizeBox = True
                        ''Me.Dock = DockStyle.Fill
                        'Me.pnlBillCodeMap.Controls.Add(fm)
                        'Me.pnlBillCodeMap.Visible = True
                        'Me.pnlBillCodeMap.Width = Me.Width * 2 / 3
                        'Me.pnlBillCodeMap.Height = Me.Height + 2 / 3
                        'Me.pnlBillCodeMap.Top = Me.Top
                        'Me.pnlBillCodeMap.Left = Me.Left
                        '2. Try directly open, It works but can't open as Showdailog
                        'fm.Show() '
                        'f.Show()
                        '3. try fm.ShowDialog, it doesn't work at all
                        'fm.ShowDialog()

                        '4. This works well
                        fm.ShowDialog(Me)
                        If Not fm.DialogResult = DialogResult.OK Then
                            MessageBox.Show("Stopped due to a failure of creating a mapped relationship between a billcode and a code for report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    End If


                    '*********************************************
                    iReflowTypeID = Me.cboReflowTypes.SelectedValue
                    If Me.chkInvisible.Checked = True Then iInvisible = 1 Else iInvisible = 0
                    iModelID = Me.cboModel.SelectedValue : iBillcodeID = Me.cboBillCode.SelectedValue
                    iLaborLevel = Me.cboLaborLvl.DataSource.Table.Select("laborlvl_id = " & Me.cboLaborLvl.SelectedValue)(0)("LaborLevel")

                    If Me._iMapID = 0 Then
                        If Generic.IsBillcodeMapped(Me.cboModel.SelectedValue, Me.cboBillCode.SelectedValue) > 0 Then
                            MessageBox.Show("The combination of Model and Billcode is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboModel.Focus()
                            Exit Sub
                        Else
                            If Generic.IsBillcodeMapped(Me.cboModel.SelectedValue, Me.cboBillCode.SelectedValue) > 0 Then
                                If MessageBox.Show("Billcode (" & Me.cboBillCode.Text & ") is already mapped for selected model. Do you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub
                            End If

                            InsertDataMap(Me.cboPartNo.SelectedValue, iBillcodeID, iModelID, Me.cboProduct.SelectedValue, Me.cboLaborLvl.SelectedValue, Me.cboLineOfBusiness.SelectedValue, iInvisible, iLaborLevel, iReflowTypeID)
                            'MessageBox.Show("Add completed." & Environment.NewLine & "Would you like to close the window?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                            Me._iMapID = 0 : iRefreshNTFDefaultPartsGrid = 1
                            Me.cboPartNo.SelectedValue = 0
                            Me.cboBillCode.SelectedValue = 0
                            Me.cboLaborLvl.Text = ""
                            Me.cboLineOfBusiness.Text = ""
                            Me.cboPartNo.Focus()
                        End If
                    Else
                        UpdateDataMap(Me.cboPartNo.SelectedValue, iBillcodeID, iModelID, Me.cboProduct.SelectedValue, Me.cboLaborLvl.SelectedValue, Me.cboLineOfBusiness.SelectedValue, Me._iMapID, iInvisible, iLaborLevel, iReflowTypeID)
                        'MessageBox.Show("Update completed." & Environment.NewLine & "Would you like to close the window?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        Me._iMapID = 0 : iRefreshNTFDefaultPartsGrid = 0
                        Me.cboProduct.SelectedValue = 0
                        Me.cboModel.Text = ""
                        Me.cboModel.DataSource = Nothing
                        Me.cboPartNo.SelectedValue = 0
                        Me.cboBillCode.Text = ""
                        Me.cboBillCode.DataSource = Nothing
                        Me.cboLaborLvl.Text = ""
                        Me.cboLineOfBusiness.Text = ""
                        Me.gbAddUpdateMap.Visible = False
                    End If

                    Me.chkInvisible.Checked = False

                    '*********************************************
                    'Set as default part for NTF Units
                    '*********************************************
                    If Me.chkDefaultPartForNTF.Checked = True Then
                        PartsMap.SetAsDefaultPartForNTF(Me.cboCustomer.SelectedValue, iModelID, iBillcodeID)
                        Me.chkDefaultPartForNTF.Checked = False
                        If iRefreshNTFDefaultPartsGrid = 1 Then PopulateDefaultPartsForNTF(Me.cboCustomer.SelectedValue, iModelID)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddUpdate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboProduct_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.Leave
            Try
                If Not IsNothing(Me.cboProduct.SelectedValue) AndAlso Me.cboProduct.SelectedValue > 0 AndAlso Me._iMapID = 0 Then
                    '_prod_id = Me.cboProduct.SelectedValue()
                    Me.cboPartNo.SelectedValue = 0
                    Me.cboLaborLvl.SelectedValue = 0
                    Me.cboLineOfBusiness.SelectedValue = 0
                    Me.PopulateModels(Me.cboProduct.SelectedValue, Me.cboModel, , True)
                    Me.PopulateBillcodes()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProduct_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboCopyMapProd_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCopyMapProd.Enter
            Try
                Me.cboCopyMapModel.Text = ""
                Me.cboCopyMapModel.DataSource = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCopyMapProd_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnCopyMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyMap.Click
            Dim iRow, iCol As Integer
            Dim booMapIDFound As Boolean = False
            Dim dt As New DataTable()
            Dim R1 As DataRow

            Try
                If Me.cboCopyMapProd.SelectedValue = 0 Then
                    MessageBox.Show("Please select production type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCopyMapProd.SelectAll() : Me.cboCopyMapProd.Focus()
                ElseIf Me.cboCopyMapModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCopyMapModel.SelectAll() : Me.cboCopyMapModel.Focus()
                ElseIf Me.dbgMapped.SelectedRows.Count > 0 And Me.dbgMapped.SelectedCols.Count Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    dt = Me.dbgMapped.DataSource.Table.Clone
                    'loop through each selected row
                    For Each iRow In Me.dbgMapped.SelectedRows
                        If Me.dbgMapped.Columns("Prod_ID").CellValue(iRow) = Me.cboCopyMapProd.SelectedValue Then
                            R1 = dt.NewRow
                            'loop through each selected column
                            For iCol = 0 To Me.dbgMapped.Columns.Count - 1
                                R1(iCol) = Me.dbgMapped.Columns(iCol).CellValue(iRow)
                            Next iCol
                            dt.Rows.Add(R1)
                            R1 = Nothing
                        End If
                    Next iRow
                    dt.AcceptChanges()

                    '************************************
                    'Map 
                    '************************************
                    For Each R1 In dt.Rows
                        If Generic.IsBillcodeMapped(Me.cboCopyMapModel.SelectedValue, R1("Billcode_ID")) = 0 Then
                            InsertDataMap(R1("PSPrice_ID"), R1("Billcode_ID"), Me.cboCopyMapModel.SelectedValue, Me.cboCopyMapProd.SelectedValue, R1("LaborLvl_ID"), R1("LOB_ID"), R1("Inactive"), R1("LaborLevel"), R1("ReflowTypeID"))
                        End If
                    Next R1
                    '************************************
                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    MessageBox.Show("Completed.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    : Me.cboCopyMapModel.SelectAll() : Me.cboCopyMapModel.Focus()
                Else
                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    MessageBox.Show("Please select a range of cells to duplicate mapping.", "Print Selected Row", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCopyMapModel.SelectAll() : Me.cboCopyMapModel.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCopyMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing : Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub chkDefaultPartForNTF_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDefaultPartForNTF.CheckedChanged
            If Me.chkDefaultPartForNTF.Checked = True Then
                If Me.cboProduct.SelectedValue = 0 Then
                    MessageBox.Show("Please select Product Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.chkDefaultPartForNTF.Checked = False
                    Me.cboProduct.SelectAll()
                    Me.cboProduct.Focus()
                ElseIf Me.cboModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.chkDefaultPartForNTF.Checked = False
                    Me.cboModel.SelectAll()
                    Me.cboModel.Focus()
                Else
                    Me.pnlCustomer.Visible = True
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                End If
            Else
                Me.pnlCustomer.Visible = False
                If Not IsNothing(Me.cboCustomer.DataSource) Then Me.cboCustomer.SelectedValue = 0
                Me.dbgNTFDefaultParts.DataSource = Nothing
            End If
        End Sub

        '***************************************************************************************
        Private Sub cboBillCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillCode.Leave
            Try
                If Me.cboBillCode.SelectedValue > 0 AndAlso Me.cboBillCode.DataSource.Table.Select("Billcode_ID = " & Me.cboBillCode.SelectedValue)(0)("BillType_ID") = 2 Then
                    Me.chkDefaultPartForNTF.Visible = True
                Else
                    Me.chkDefaultPartForNTF.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboBillCode_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateDefaultPartsForNTF(ByVal iCustID As Integer, ByVal iModelID As Integer)
            Dim dt As DataTable
            Try
                With Me.dbgNTFDefaultParts
                    .DataSource = Nothing
                    dt = PartsMap.GetDefaultPartForNTFUnit(iCustID, iModelID)
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns(0).Width = 135
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
            Try
                If Me.cboCustomer.SelectedValue > 0 And Me.cboModel.SelectedValue Then
                    PopulateDefaultPartsForNTF(Me.cboCustomer.SelectedValue, Me.cboModel.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboCustomer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboCopyMapProd_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCopyMapProd.RowChange
            Try
                Me.cboCopyMapModel.Text = ""
                Me.cboCopyMapModel.DataSource = Nothing

                If Me._booPopulateDataToControl = True Then Exit Sub

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                If Not IsNothing(Me.cboCopyMapProd.SelectedValue) AndAlso Me.cboCopyMapProd.SelectedValue > 0 Then
                    Me.PopulateModels(Me.cboCopyMapProd.SelectedValue, Me.cboCopyMapModel, , False)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboCopyMapProd_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnSetSelectRowToVisible_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSelectRowToVisible.Click, btnSetSelectRowToInVisible.Click
            Dim strPSMapIDs As String = ""
            Dim i As Integer = 0

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If Me.dbgMapped.SelectedRows.Count > 0 And Me.dbgMapped.SelectedCols.Count Then
                    'loop through each selected row
                    For Each i In Me.dbgMapped.SelectedRows
                        If strPSMapIDs.Trim.Length > 0 Then strPSMapIDs &= ", "
                        strPSMapIDs &= Me.dbgMapped.Columns("PSMap_ID").CellValue(i)
                    Next i

                    If sender.name = "btnSetSelectRowToVisible" Then
                        i = PSS.Data.Buisness.PartsMap.SetInvisibleField(strPSMapIDs, 0)
                    ElseIf sender.name = "btnSetSelectRowToInVisible" Then
                        i = PSS.Data.Buisness.PartsMap.SetInvisibleField(strPSMapIDs, 1)
                    End If
                    If i > 0 Then MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Please select range of rows.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnSetSelectRowToVisible_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnCopySrvsFrSelModToAllModInProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySrvsFrSelModToAllModInProd.Click
            Dim dtModels, dtServices As DataTable
            Dim R1, R2 As DataRow

            Try
                If Me.cboCopyMapProd.SelectedValue = 0 Then
                    MessageBox.Show("Please select production type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCopyMapProd.SelectAll() : Me.cboCopyMapProd.Focus()
                ElseIf Me.cboCopyMapModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCopyMapModel.SelectAll() : Me.cboCopyMapModel.Focus()
                ElseIf MessageBox.Show("Are you sure you want to copy all services from selected model to all models under selected product type?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dtModels = Generic.GetModels(False, Me.cboCopyMapProd.SelectedValue, , )
                    dtServices = PSS.Data.Buisness.PartsMap.GetMappedData(Me.cboCopyMapModel.SelectedValue, 1)

                    For Each R1 In dtModels.Rows
                        For Each R2 In dtServices.Rows
                            If Generic.IsBillcodeMapped(Convert.ToInt32(R1("Model_ID")), Convert.ToInt32(R2("Billcode_ID"))) = 0 Then
                                InsertDataMap(Convert.ToInt16(R2("PSPrice_ID")), Convert.ToInt16(R2("Billcode_ID")), Convert.ToInt32(R1("Model_ID")), Convert.ToInt32(R1("Prod_ID")), Convert.ToInt16(R2("LaborLvl_ID")), Convert.ToInt16(R2("LOB_ID")), Convert.ToInt16(R2("Inactive")), Convert.ToInt16(R2("LaborLevel")), Convert.ToInt16(R2("ReflowTypeID")))
                            End If
                        Next R2
                    Next R1
                    '************************************
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCopySrvsFrSelModToAllModInProd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                R1 = Nothing : R2 = Nothing
                Generic.DisposeDT(dtModels) : Generic.DisposeDT(dtServices)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnLanUseOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLanUseOnly.Click
            'Dim objTFRec As PSS.Data.Buisness.TracFone.Receive
            'Dim strSql As String = ""
            'Dim dtModels, dtServices As DataTable
            'Dim R1, R2 As DataRow

            'Try
            '    If Me.cboCopyMapProd.SelectedValue = 0 Then
            '        MessageBox.Show("Please select production type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Me.cboCopyMapProd.SelectAll() : Me.cboCopyMapProd.Focus()
            '    ElseIf Me.cboCopyMapModel.SelectedValue = 0 Then
            '        MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '        Me.cboCopyMapModel.SelectAll() : Me.cboCopyMapModel.Focus()
            '    Else
            '        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            '        objTFRec = New PSS.Data.Buisness.TracFone.Receive()
            '        strSql = "SELECT * FROM tmodel WHERE Manuf_ID = 212 AND Model_ID <> " & Me.cboCopyMapModel.SelectedValue
            '        dtModels = objTFRec.GetSpecialDeviceIDs(strSql)
            '        dtServices = PSS.Data.Buisness.PartsMap.GetMappedData(Me.cboCopyMapModel.SelectedValue, 1)

            '        For Each R1 In dtModels.Rows
            '            For Each R2 In dtServices.Rows
            '                If Generic.IsBillcodeMapped(Convert.ToInt32(R1("Model_ID")), Convert.ToInt32(R2("Billcode_ID"))) = 0 Then
            '                    InsertDataMap(Convert.ToInt16(R2("PSPrice_ID")), Convert.ToInt16(R2("Billcode_ID")), Convert.ToInt32(R1("Model_ID")), Convert.ToInt32(R1("Prod_ID")), Convert.ToInt16(R2("LaborLvl_ID")), Convert.ToInt16(R2("LOB_ID")), Convert.ToInt16(R2("Inactive")), Convert.ToInt16(R2("LaborLevel")), Convert.ToInt16(R2("ReflowTypeID")))
            '                End If
            '            Next R2
            '        Next R1
            '        '************************************
            '        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    End If

            'Catch ex As Exception
            '    MessageBox.Show(ex.Message, "btnCopySrvsFrSelModToAllModInProd_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Finally
            '    Me.Enabled = True : Cursor.Current = Cursors.Default
            '    objTFRec = Nothing
            '    R1 = Nothing : R2 = Nothing
            '    Generic.DisposeDT(dtModels) : Generic.DisposeDT(dtServices)
            'End Try
        End Sub

        '***************************************************************************************


    End Class

End Namespace