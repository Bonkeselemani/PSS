Option Explicit On 

Imports System.IO
Imports PSS.Data.Buisness
Imports PSS.Core.Global

Namespace Gui.GenericProcess
    Public Class frmGPProduceLot
        Inherits System.Windows.Forms.Form

        Private _iMenuProdID As Integer = 0
        Private _iMenuCustID As Integer = 0
        Private _objGP As Data.Buisness.GenericProcess.clsGenericProcess
        Private _objBulkShip As BulkShipping
        Private _strManifestFilePath As String = ""
        Private _drPalletInfo As DataRow = Nothing
        Private _iFileCheckDone As Integer = 0
        Private _booHasASNFile As Boolean = True

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal iProdID As Integer = 0, Optional ByVal iCustID As Integer = 0)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            _iMenuProdID = iProdID
            _iMenuCustID = iCustID

            'Add any initialization after the InitializeComponent() call
            _objGP = New Data.Buisness.GenericProcess.clsGenericProcess()
            _objBulkShip = New BulkShipping()
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
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents lblCnt As System.Windows.Forms.Label
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents PanelList As System.Windows.Forms.Panel
        Friend WithEvents lstBER As System.Windows.Forms.ListBox
        Friend WithEvents lstRegular As System.Windows.Forms.ListBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
        Friend WithEvents lstDetail As System.Windows.Forms.ListBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents lstBERParts As System.Windows.Forms.ListBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents btnSelectLot As System.Windows.Forms.Button
        Friend WithEvents btnReprintManifest As System.Windows.Forms.Button
        Friend WithEvents btnCreateManifest As System.Windows.Forms.Button
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents pnlCustomers As System.Windows.Forms.Panel
        Friend WithEvents btnShip As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnFileCheck As System.Windows.Forms.Button
        Friend WithEvents chkPrintReport As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGPProduceLot))
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.pnlCustomers = New System.Windows.Forms.Panel()
            Me.btnCreateManifest = New System.Windows.Forms.Button()
            Me.btnReprintManifest = New System.Windows.Forms.Button()
            Me.btnSelectLot = New System.Windows.Forms.Button()
            Me.lblCnt = New System.Windows.Forms.Label()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.PanelList = New System.Windows.Forms.Panel()
            Me.chkPrintReport = New System.Windows.Forms.CheckBox()
            Me.lstBER = New System.Windows.Forms.ListBox()
            Me.lstRegular = New System.Windows.Forms.ListBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lstWrongModel = New System.Windows.Forms.ListBox()
            Me.btnShip = New System.Windows.Forms.Button()
            Me.lstDetail = New System.Windows.Forms.ListBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lstBERParts = New System.Windows.Forms.ListBox()
            Me.btnFileCheck = New System.Windows.Forms.Button()
            Me.Label11 = New System.Windows.Forms.Label()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlCustomers.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelList.SuspendLayout()
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
            Me.cboLocations.Location = New System.Drawing.Point(80, 72)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(5, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(240, 21)
            Me.cboLocations.TabIndex = 3
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
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
            Me.cboCustomers.Location = New System.Drawing.Point(80, 40)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(240, 21)
            Me.cboCustomers.TabIndex = 2
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.SteelBlue
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(8, 72)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(64, 16)
            Me.Label5.TabIndex = 93
            Me.Label5.Text = "Location:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.SteelBlue
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(8, 42)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(64, 16)
            Me.Label6.TabIndex = 92
            Me.Label6.Text = "Customer:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.SteelBlue
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(8, 9)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(64, 16)
            Me.Label7.TabIndex = 97
            Me.Label7.Text = "Product:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProduct
            '
            Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProduct.Caption = ""
            Me.cboProduct.CaptionHeight = 17
            Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProduct.ColumnCaptionHeight = 17
            Me.cboProduct.ColumnFooterHeight = 17
            Me.cboProduct.ContentHeight = 15
            Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProduct.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProduct.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProduct.EditorHeight = 15
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(80, 7)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(5, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(240, 21)
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'pnlCustomers
            '
            Me.pnlCustomers.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlCustomers.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreateManifest, Me.btnReprintManifest, Me.cboLocations, Me.cboCustomers, Me.Label5, Me.Label6, Me.Label7, Me.cboProduct, Me.btnSelectLot})
            Me.pnlCustomers.Location = New System.Drawing.Point(1, 54)
            Me.pnlCustomers.Name = "pnlCustomers"
            Me.pnlCustomers.Size = New System.Drawing.Size(336, 170)
            Me.pnlCustomers.TabIndex = 3
            '
            'btnCreateManifest
            '
            Me.btnCreateManifest.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCreateManifest.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateManifest.ForeColor = System.Drawing.Color.Blue
            Me.btnCreateManifest.Location = New System.Drawing.Point(184, 136)
            Me.btnCreateManifest.Name = "btnCreateManifest"
            Me.btnCreateManifest.Size = New System.Drawing.Size(136, 21)
            Me.btnCreateManifest.TabIndex = 6
            Me.btnCreateManifest.Text = "Create Manifest"
            '
            'btnReprintManifest
            '
            Me.btnReprintManifest.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintManifest.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintManifest.ForeColor = System.Drawing.Color.Blue
            Me.btnReprintManifest.Location = New System.Drawing.Point(8, 136)
            Me.btnReprintManifest.Name = "btnReprintManifest"
            Me.btnReprintManifest.Size = New System.Drawing.Size(144, 21)
            Me.btnReprintManifest.TabIndex = 5
            Me.btnReprintManifest.Text = "Re-Print Manifest"
            '
            'btnSelectLot
            '
            Me.btnSelectLot.BackColor = System.Drawing.Color.Green
            Me.btnSelectLot.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectLot.ForeColor = System.Drawing.Color.White
            Me.btnSelectLot.Location = New System.Drawing.Point(8, 104)
            Me.btnSelectLot.Name = "btnSelectLot"
            Me.btnSelectLot.Size = New System.Drawing.Size(312, 24)
            Me.btnSelectLot.TabIndex = 4
            Me.btnSelectLot.Text = "SELECT LOT TO BE PRODUCE"
            '
            'lblCnt
            '
            Me.lblCnt.BackColor = System.Drawing.Color.Black
            Me.lblCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblCnt.Location = New System.Drawing.Point(728, 17)
            Me.lblCnt.Name = "lblCnt"
            Me.lblCnt.Size = New System.Drawing.Size(96, 36)
            Me.lblCnt.TabIndex = 81
            Me.lblCnt.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.Black
            Me.lblPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.Lime
            Me.lblPallet.Location = New System.Drawing.Point(336, 0)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(392, 53)
            Me.lblPallet.TabIndex = 83
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Black
            Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Lime
            Me.Label1.Location = New System.Drawing.Point(728, 1)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 18)
            Me.Label1.TabIndex = 82
            Me.Label1.Text = "COUNT"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(336, 53)
            Me.lblScreenName.TabIndex = 80
            Me.lblScreenName.Text = "PRODUCE LOTS"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'dbgPallets
            '
            Me.dbgPallets.AllowColMove = False
            Me.dbgPallets.AllowColSelect = False
            Me.dbgPallets.AllowFilter = False
            Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgPallets.AllowUpdate = False
            Me.dbgPallets.AllowUpdateOnBlur = False
            Me.dbgPallets.AlternatingRows = True
            Me.dbgPallets.Caption = "Boxes to be Produce"
            Me.dbgPallets.CaptionHeight = 17
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(336, 54)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(488, 170)
            Me.dbgPallets.TabIndex = 2
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{Font:Tahoma, 8" & _
            ".25pt, style=Bold;AlignHorz:Center;ForeColor:Green;BackColor:LightSteelBlue;}Sty" & _
            "le9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:LightSteelBlue;AlignVert" & _
            ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
            "ow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style13{}Heading{" & _
            "Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackCol" & _
            "or:SteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:White;AlignVert:Center;}Style8{" & _
            "}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Spl" & _
            "its><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" AllowColMove=""False"" AllowCol" & _
            "Select=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionH" & _
            "eight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""Dotted" & _
            "CellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1""" & _
            " HorizontalScrollGroup=""1""><Height>148</Height><CaptionStyle parent=""Style2"" me=" & _
            """Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""Eve" & _
            "nRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterSty" & _
            "le parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Head" & _
            "ingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow""" & _
            " me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle paren" & _
            "t=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style1" & _
            "1"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""S" & _
            "tyle1"" /><ClientRect>0, 17, 484, 148</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 484, 166</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /" & _
            "><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'PanelList
            '
            Me.PanelList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelList.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrintReport, Me.lstBER, Me.lstRegular, Me.Label9, Me.lstWrongModel, Me.btnShip, Me.lstDetail, Me.Label2, Me.Label3, Me.Label12, Me.btnClear, Me.lstBERParts, Me.btnFileCheck, Me.Label11})
            Me.PanelList.Location = New System.Drawing.Point(0, 224)
            Me.PanelList.Name = "PanelList"
            Me.PanelList.Size = New System.Drawing.Size(824, 296)
            Me.PanelList.TabIndex = 1
            Me.PanelList.Visible = False
            '
            'chkPrintReport
            '
            Me.chkPrintReport.Checked = True
            Me.chkPrintReport.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkPrintReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintReport.ForeColor = System.Drawing.Color.White
            Me.chkPrintReport.Location = New System.Drawing.Point(648, 230)
            Me.chkPrintReport.Name = "chkPrintReport"
            Me.chkPrintReport.Size = New System.Drawing.Size(144, 16)
            Me.chkPrintReport.TabIndex = 8
            Me.chkPrintReport.Text = "Print Manifest"
            '
            'lstBER
            '
            Me.lstBER.Location = New System.Drawing.Point(136, 32)
            Me.lstBER.Name = "lstBER"
            Me.lstBER.Size = New System.Drawing.Size(120, 212)
            Me.lstBER.TabIndex = 2
            '
            'lstRegular
            '
            Me.lstRegular.Location = New System.Drawing.Point(8, 32)
            Me.lstRegular.Name = "lstRegular"
            Me.lstRegular.Size = New System.Drawing.Size(120, 212)
            Me.lstRegular.TabIndex = 1
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Gold
            Me.Label9.Location = New System.Drawing.Point(520, 16)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(130, 16)
            Me.Label9.TabIndex = 60
            Me.Label9.Text = "DETAIL:"
            '
            'lstWrongModel
            '
            Me.lstWrongModel.Location = New System.Drawing.Point(392, 32)
            Me.lstWrongModel.Name = "lstWrongModel"
            Me.lstWrongModel.Size = New System.Drawing.Size(120, 212)
            Me.lstWrongModel.TabIndex = 4
            '
            'btnShip
            '
            Me.btnShip.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnShip.Enabled = False
            Me.btnShip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnShip.ForeColor = System.Drawing.Color.Blue
            Me.btnShip.Location = New System.Drawing.Point(600, 256)
            Me.btnShip.Name = "btnShip"
            Me.btnShip.Size = New System.Drawing.Size(200, 32)
            Me.btnShip.TabIndex = 9
            Me.btnShip.Text = "PRODUCE"
            '
            'lstDetail
            '
            Me.lstDetail.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.lstDetail.Location = New System.Drawing.Point(520, 32)
            Me.lstDetail.Name = "lstDetail"
            Me.lstDetail.Size = New System.Drawing.Size(120, 212)
            Me.lstDetail.TabIndex = 5
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(116, 18)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Regular Units:"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(136, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(108, 16)
            Me.Label3.TabIndex = 5
            Me.Label3.Text = "BER Units:"
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(264, 0)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(120, 32)
            Me.Label12.TabIndex = 55
            Me.Label12.Text = "BER Units with Parts:"
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.Black
            Me.btnClear.Location = New System.Drawing.Point(464, 256)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(120, 32)
            Me.btnClear.TabIndex = 7
            Me.btnClear.Text = "Clear"
            '
            'lstBERParts
            '
            Me.lstBERParts.Location = New System.Drawing.Point(264, 32)
            Me.lstBERParts.Name = "lstBERParts"
            Me.lstBERParts.Size = New System.Drawing.Size(120, 212)
            Me.lstBERParts.TabIndex = 3
            '
            'btnFileCheck
            '
            Me.btnFileCheck.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnFileCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFileCheck.ForeColor = System.Drawing.Color.Black
            Me.btnFileCheck.Location = New System.Drawing.Point(8, 256)
            Me.btnFileCheck.Name = "btnFileCheck"
            Me.btnFileCheck.Size = New System.Drawing.Size(440, 32)
            Me.btnFileCheck.TabIndex = 6
            Me.btnFileCheck.Text = "LOT CHECK (DO I HAVE THE RIGHT LOT AND RIGHT SNs?)"
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(392, 16)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(113, 21)
            Me.Label11.TabIndex = 53
            Me.Label11.Text = "Wrong Model:"
            '
            'frmGPProduceLot
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(856, 533)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelList, Me.dbgPallets, Me.lblCnt, Me.lblPallet, Me.Label1, Me.lblScreenName, Me.pnlCustomers})
            Me.Name = "frmGPProduceLot"
            Me.Text = "frmGPProduceLot"
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlCustomers.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelList.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************
        Private Sub frmGPProduceLot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                'Populate product type
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                If _iMenuProdID > 0 Then
                    Me.cboProduct.SelectedValue = _iMenuProdID : Me.cboProduct.Enabled = False
                Else
                    Me.cboProduct.SelectedValue = 0
                End If

                'Populate Customer
                If _iMenuCustID > 0 Then
                    dt = Generic.GetCustomers(True, )
                    Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                    Me.cboCustomers.SelectedValue = _iMenuCustID
                    _strManifestFilePath = Me._objGP.ManifestBaseDir & _iMenuCustID & "\" & Me._objGP.ManifestFolderName & "\"
                    Me.cboCustomers.Enabled = False

                    'Populate Location
                    Generic.DisposeDT(dt)
                    dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                    Me.cboLocations.Enabled = True
                    If dt.Rows.Count = 2 Then
                        Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                        Me.cboLocations.Enabled = False
                        Me.PopulateToBeShipLots()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboProduct_cboCustomers_cboLocations_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProduct.Enter, cboCustomers.Enter, cboLocations.Enter
            Try
                Me.ClearPanelPallet()
                Me.dbgPallets.DataSource = Nothing
                _drPalletInfo = Nothing
                _iFileCheckDone = 0

                If sender.name = "cboProduct" Then
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

                    Me.cboProduct.SelectAll()
                ElseIf sender.name = "cboCustomers" Then
                    Me._strManifestFilePath = ""
                    '********************
                    'Reset Location
                    '********************
                    If Not IsNothing(Me.cboLocations.DataSource) Then
                        Me.cboLocations.DataSource = Nothing
                        Me.cboLocations.Text = ""
                    End If
                    '********************
                    Me.cboCustomers.SelectAll()
                ElseIf sender.name = "cboLocations" Then
                    Me.cboLocations.SelectAll()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbo_EnterEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ClearPanelPallet()
            Try
                Me.lstRegular.Items.Clear() : Me.lstRegular.Refresh()
                Me.lstBER.Items.Clear() : Me.lstBER.Refresh()
                Me.lstBERParts.Items.Clear() : Me.lstBERParts.Refresh()
                Me.lstWrongModel.Items.Clear() : Me.lstWrongModel.Refresh()
                Me.lstDetail.Items.Clear() : Me.lstDetail.Refresh()
                Me.lblCnt.Text = ""
                Me.lblPallet.Text = ""
                Me.PanelList.Visible = False
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboProduct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProduct.KeyUp
            Dim dt As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboProduct.SelectedValue > 0 Then
                        If Me._iMenuCustID = 0 Then
                            '*******************************
                            'Load Customers list
                            '*******************************
                            dt = Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                            Me.cboCustomers.SelectedValue = 0
                            '*******************************
                            Me.cboCustomers.SelectAll()
                            Me.cboCustomers.Focus()
                        Else
                            If Me.cboLocations.Enabled = False Then
                                Me.cboLocations.SelectAll()
                                Me.cboLocations.Focus()
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProdID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
            Dim dtLoc As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboCustomers.SelectedValue > 0 Then
                        'Can't process Astro in normal Generic Process
                        If Me.cboCustomers.SelectedValue = Data.Buisness.Skullcandy.ASTRO_CUSTOMERID Then
                            MessageBox.Show("Please select Product Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboCustomers.SelectedValue = 0 : Exit Sub
                        End If

                        _strManifestFilePath = Me._objGP.ManifestBaseDir & Me.cboCustomers.SelectedValue & "\" & Me._objGP.ManifestFolderName & "\"

                        '*******************************
                        'Populate location
                        '*******************************
                        dtLoc = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboLocations, dtLoc, "Loc_Name", "Loc_ID")
                        Me.cboLocations.Enabled = True
                        If dtLoc.Rows.Count = 2 Then Me.cboLocations.SelectedValue = dtLoc.Rows(0)("Loc_ID") Else Me.cboLocations.SelectedValue = 0
                        '*******************************

                        Me.cboLocations.SelectAll()
                        Me.cboLocations.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCustomers_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dtLoc)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub cboLocations_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLocations.KeyUp
            Dim dt As DataTable

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboProduct.SelectedValue = 0 Then
                        MessageBox.Show("Please select Product Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboProduct.Focus()
                    Else
                        'Populate Ready To ship Pallet
                        Me.PopulateToBeShipLots()
                    End If
                End If  'Enter Key pressed
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboLocations_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub PopulateToBeShipLots()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                If Me.cboProduct.SelectedValue = 0 Then
                    MessageBox.Show("Please select product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboProduct.SelectAll()
                    Me.cboProduct.Focus()
                ElseIf Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf Me.cboLocations.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLocations.SelectAll()
                    Me.cboLocations.Focus()
                Else
                    dt = Me._objGP.GetReadyToBeShipPallets(Me.cboLocations.SelectedValue)

                    With Me.dbgPallets
                        .DataSource = Nothing
                        .DataSource = dt.DefaultView
                        .AlternatingRows = True

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                            If dt.Columns(i).Caption = "Lot Name" Then
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                                .Splits(0).DisplayColumns(i).Visible = True
                                .Splits(0).DisplayColumns(i).Width = 140
                            ElseIf dt.Columns(i).Caption = "Model" Then
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                                .Splits(0).DisplayColumns(i).Visible = True
                                .Splits(0).DisplayColumns(i).Width = 200
                            ElseIf dt.Columns(i).Caption = "Qty" Then
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                .Splits(0).DisplayColumns(i).Visible = True
                                .Splits(0).DisplayColumns(i).Width = 60
                            Else
                                .Splits(0).DisplayColumns(i).Visible = False
                            End If
                        Next i
                        '*******************************
                    End With
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnReprintManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintManifest.Click
            Dim strPallet As String = ""
            Dim objBulkShip As PSS.Data.Buisness.BulkShipping

            Try
                '************************
                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf Directory.Exists(_strManifestFilePath) = False Then
                    MessageBox.Show("Manifest directory is missing. Re-select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                Else
                    strPallet = InputBox("Enter Lot Number.", "Reopen Lot")
                    If strPallet = "" Then
                        MessageBox.Show("Please enter lot number to create manifest.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf File.Exists(_strManifestFilePath & strPallet & ".xls") = False Then
                        MessageBox.Show("Manifest does not exist (" & _strManifestFilePath & strPallet & ".xls" & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        objBulkShip = New PSS.Data.Buisness.BulkShipping()
                        objBulkShip.PrintExcelFile(_strManifestFilePath & strPallet & ".xls")
                    End If  'Empty input
                End If 'Customer & Location selected value
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintManifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                objBulkShip = Nothing
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnCreateManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateManifest.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim booAddSNBarcodeColumn As Boolean = False
            Dim booSetBorder As Boolean = True

            Try
                '************************
                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf IsNothing(Me.cboLocations.SelectedValue) = True Then
                    MessageBox.Show("Please select customer and press enter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                ElseIf _strManifestFilePath.Trim.Length = 0 Then
                    MessageBox.Show("Manifest directory is missing. Re-select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboCustomers.SelectAll()
                    Me.cboCustomers.Focus()
                Else
                    strPallet = InputBox("Enter Lot Number.", "Reopen Lot")
                    If strPallet = "" Then
                        MessageBox.Show("Please enter lot number to create manifest.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf File.Exists(_strManifestFilePath & strPallet & ".xls") = True Then
                        MessageBox.Show("Manifest is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        Me.Enabled = False

                        dt = PSS.Data.Production.Shipping.GetPalletInfoByName(strPallet, Me.cboCustomers.SelectedValue)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Lot does not exist in the system for selected customer or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf dt.Rows.Count > 1 AndAlso Me.cboLocations.SelectedValue = 0 Then
                            MessageBox.Show("Lot name existed more than one in the system for the selected customer. Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboCustomers.SelectAll()
                            Me.cboCustomers.Focus()
                        ElseIf dt.Rows.Count > 1 AndAlso Me.cboLocations.SelectedValue > 0 AndAlso dt.Select("Loc_ID = " & Me.cboLocations.SelectedValue).Length > 1 Then
                            MessageBox.Show("Lot name existed more than one in the system for the selected location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            '*************************
                            'Get Pallett Information
                            '*************************
                            If dt.Rows.Count = 1 Then
                                R1 = dt.Rows(0)
                            ElseIf dt.Rows.Count > 1 AndAlso dt.Select("Cust_ID = " & Me.cboCustomers.SelectedValue).Length = 1 Then
                                R1 = dt.Select("Cust_ID = " & Me.cboCustomers.SelectedValue)(0)
                            ElseIf dt.Rows.Count > 1 AndAlso dt.Select("Cust_ID = " & Me.cboCustomers.SelectedValue & " AND Loc_ID = " & Me.cboLocations.SelectedValue).Length = 1 Then
                                R1 = dt.Select("Cust_ID = " & Me.cboCustomers.SelectedValue & " AND Loc_ID = " & Me.cboLocations.SelectedValue)(0)
                            Else
                                MessageBox.Show("Unable to define lot.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If

                            '*************************
                            If R1("Pallet_Invalid") = 1 Then
                                MessageBox.Show("This lot has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                'ElseIf IsDBNull(R1("Pallett_ShipDate")) Then
                                '    MessageBox.Show("Lot has not yet produced.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf R1("Pallett_ReadyToShipFlg") = 0 Then
                                MessageBox.Show("Lot's still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                Cursor.Current = Cursors.WaitCursor

                                If MessageBox.Show("Do you want barcode SN column in manifest?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then booAddSNBarcodeColumn = True
                                If Me.cboCustomers.SelectedValue = 2543 Then booSetBorder = False

                                i = Me._objGP.CreateManifest(R1("Pallett_ID"), _strManifestFilePath, 0, booAddSNBarcodeColumn, booSetBorder)
                                If i = 0 Then
                                    MessageBox.Show("Lot is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Else
                                    MessageBox.Show("Manifest has been created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    Me.ClearPanelPallet()
                                End If 'Re-Open status 
                            End If  'validate pallet information
                        End If  'duplicate record of pallet
                    End If  'Empty input
                End If 'Customer & Location selected value
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateManifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnSelectLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectLot.Click
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strPalletName, strFilePath As String
            Dim iExcelNum, iPSSNum As Integer
            Dim dcColNew As DataColumn

            Try
                Me.ClearPanelPallet()

                If Me.dbgPallets.RowCount = 0 Or Me.dbgPallets.Columns.Count = 0 Then Exit Sub
                If Me._strManifestFilePath.Trim.Length = 0 Then Throw New Exception("Manifest file path is missing. Please re-select customer.")

                strPalletName = InputBox("Enter Lot Name:").Trim
                strFilePath = _strManifestFilePath & strPalletName & ".xls"
                Select Case Me.cboCustomers.SelectedValue
                    Case 2468, 2552
                        _booHasASNFile = False
                    Case Else
                        _booHasASNFile = True
                End Select

                If strPalletName.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me.dbgPallets.DataSource.Table.Select("[Lot Name] = '" & strPalletName & "'").length = 0 Then
                    MessageBox.Show("Lot name is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf _booHasASNFile AndAlso Not File.Exists(strFilePath) Then
                    MessageBox.Show("Excel manifest was not found in '" & strFilePath & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me._drPalletInfo = Me.dbgPallets.DataSource.Table.Select("[Lot Name] = '" & strPalletName & "'")(0)

                    Me.PanelList.Visible = True

                    '************************************************
                    Me.lblPallet.Text = strPalletName
                    '*********************
                    'objBulkShip variables
                    Me._objBulkShip.iLoc_ID = Me._drPalletInfo("Loc_ID")
                    Me._objBulkShip.iBulkShipped = 1
                    Me._objBulkShip.iShipType = Me._drPalletInfo("Pallet_ShipType")
                    Me._objBulkShip.strFilePath = strFilePath
                    Me._objBulkShip.iPallet_ID = Me._drPalletInfo("pallett_id")
                    'Me._objBulkShip.iGroup_ID = Me._drPalletInfo("group_id")
                    Me._objBulkShip.iShiftID = PSS.Core.ApplicationUser.IDShift
                    Me._objBulkShip.struser = PSS.Core.ApplicationUser.User
                    Me._objBulkShip.iCust_ID = Me._drPalletInfo("Cust_ID")
                    '*********************
                    _iFileCheckDone = 0
                    '***********************************************
                    'Add WO_ID column to dtWO datatable
                    '***********************************************
                    Generic.DisposeDT(Me._objBulkShip.dtWO)
                    Me._objBulkShip.dtWO = New DataTable() '("WO")
                    dcColNew = New DataColumn("WO_ID")
                    dcColNew.DataType = System.Type.GetType("System.Int32")
                    Me._objBulkShip.dtWO.Columns.Add(dcColNew)

                    'Bill special service for Astro customer only
                    If Me.cboCustomers.SelectedValue = Data.Buisness.Skullcandy.ASTRO_CUSTOMERID Then
                        If Me._drPalletInfo("Pallet_ShipType") = 0 Then
                            MessageBox.Show("Not allow to produce a good lot in this screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ClearPanelPallet() : Exit Sub
                        Else
                            If Me.RunAstroBilling(Me._objBulkShip.iPallet_ID) = False Then Exit Sub
                        End If
                    End If
                    '************************************************
                    'Step 1 :: Extract SN numbers from the excel file
                    '************************************************
                    Generic.DisposeDT(Me._objBulkShip.dtExcelSNs)
                    If _booHasASNFile = True Then
                        Me._objBulkShip.dtExcelSNs = Me._objGP.ExtractSNs(strFilePath, Me._drPalletInfo("pallett_id"), Me._drPalletInfo("Loc_ID"))
                    Else
                        Me._objBulkShip.dtExcelSNs = Me._objGP.ExtractSNsWithoutASNFile(Me._drPalletInfo("pallett_id"))
                    End If

                    iExcelNum = Me._objBulkShip.dtExcelSNs.Rows.Count
                    If iExcelNum > 0 Then

                        '#############################################################
                        'Step 3::
                        'write data to controls based on the business logic
                        '#############################################################

                        '*******************************************************
                        For Each R1 In _objBulkShip.dtExcelSNs.Rows

                            '*******************************************************
                            '(A) Model Validation (For all customers)
                            '*******************************************************
                            If Me._drPalletInfo("Model_ID") > 0 Then
                                If R1("Model_ID") <> Me._drPalletInfo("Model_ID") Then Me.lstWrongModel.Items.Add(Trim(R1("SN")))
                            End If

                            '*******************************************************
                            '(B) Validation Bill Rule (For all customers)
                            '*******************************************************
                            If Me._drPalletInfo("BillRule_ID") <> R1("BillCode_Rule") Then
                                Throw New Exception("Device's billrule does not match with lot (" & R1("SN") & ").")
                            End If

                            '*******************************************************
                            '(C) BILLCODERULE validation    (For all customers)
                            '*******************************************************
                            '*******************************************************
                            If R1("Billcode_rule") <> 0 Then 'RUR/DBR
                                Me.lstBER.Items.Add(Trim(R1("SN")))
                            ElseIf R1("Billcode_rule") = 0 Then  'Regular
                                Me.lstRegular.Items.Add(Trim(R1("SN")))
                            End If
                            '*******************************************************
                            'RUR/RTMs have parts
                            '*******************************************************
                            If R1("RURRTMHasParts") = "1" Then
                                Me.lstBERParts.Items.Add(Trim(R1("SN")))
                            End If

                            '*******************************************************
                            'Do Validations: Occur when extract SNs from Excel
                            '*******************************************************
                        Next R1
                        '#############################################################

                        Me.lblCnt.Text = Me._objBulkShip.dtExcelSNs.Rows.Count
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSelectLot_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
                R1 = Nothing
                If Not IsNothing(dcColNew) Then
                    dcColNew.Dispose() : dcColNew = Nothing
                End If
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnFileCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFileCheck.Click
            Dim strSN As String = ""
            Dim R1 As DataRow
            Dim iMatch As Integer = 0

            Try
                If Not IsNothing(_objBulkShip.dtExcelSNs) Then
                    strSN = InputBox("Please scan in a 'Serial Number' to make sure you have selected the right file.").Trim.ToUpper
                    If strSN = "" Then
                        Exit Sub
                    Else
                        If _objBulkShip.dtExcelSNs.Select("SN = '" & strSN & "'").Length > 0 Then iMatch = 1

                        '0 - File Check not done
                        '1 - DOne but SN not in file
                        '2 - Right file.
                        If iMatch = 1 Then
                            _iFileCheckDone = 2
                            Me.BackColor = System.Drawing.Color.SteelBlue
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("Serial Number exists in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.btnShip.Enabled = True
                        ElseIf iMatch = 0 Then
                            _iFileCheckDone = 1
                            Me.BackColor = System.Drawing.Color.Red
                            System.Windows.Forms.Application.DoEvents()
                            MessageBox.Show("STOP! Serial Number does not exist in the file.", "File Check", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.btnShip.Enabled = False
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            Finally
                R1 = Nothing
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShip.Click
            Dim i As Integer = 0
            'Dim iPrintCopies As Integer = 2
            Dim iHoldStatus As Integer = 0

            Try
                '*****************************************************
                'Make sure a file has been selected and FILE CHECK done
                Me.btnShip.Enabled = False
                If _iFileCheckDone = 0 Then
                    Throw New Exception("File check has not been done.")
                ElseIf _iFileCheckDone = 1 Then
                    Me.BackColor = System.Drawing.Color.Red
                    System.Windows.Forms.Application.DoEvents()
                    Throw New Exception("Serial Number you have scanned in to do 'File Check' did not exist in the file.")
                ElseIf Me._objBulkShip.iPallet_ID = 0 Then
                    Throw New Exception("Lot is not defined.")
                End If

                If Me._booHasASNFile = False Then Me.chkPrintReport.Checked = False

                '******************************************************
                'Bulk SHIP now.
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                i = _objBulkShip.BulkShip(Me.chkPrintReport.Checked, iHoldStatus, CInt(Me.lblCnt.Text), , 0)

                ''print license plate
                'Generic.PrintPalletLicensePlate(Me.strPalletName, Me.iModel_ID, Me.strShipTypeDesc, Me.lblCnt.Text, iPrintCopies)
                ''******************************************************

                ClearControlsVars()
                Me.PopulateToBeShipLots()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Ship Boxs", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************
        Private Sub ClearControlsVars()
            Try
                Me.ClearPanelPallet()

                Me._drPalletInfo = Nothing
                Me._iFileCheckDone = 0
                'Me._strManifestFilePath = ""

                Me.BackColor = System.Drawing.Color.SteelBlue
                System.Windows.Forms.Application.DoEvents()

                '*********************
                'objBulkShip Variables
                Me._objBulkShip.iLoc_ID = 0

                Me._objBulkShip.iBulkShipped = 0
                Me._objBulkShip.iShipType = 0
                Me._objBulkShip.strFilePath = ""
                Me._objBulkShip.iPallet_ID = 0

                If Not IsNothing(_objBulkShip.dtExcelSNs) Then
                    _objBulkShip.dtExcelSNs.Dispose()
                    _objBulkShip.dtExcelSNs = Nothing
                End If
                If Not IsNothing(_objBulkShip.dtWO) Then
                    _objBulkShip.dtWO.Dispose()
                    _objBulkShip.dtWO = Nothing
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '***************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.ClearControlsVars()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '***************************************************************************************
        Public Function RunAstroBilling(ByVal iPalletID As Integer) As Boolean
            Dim strDateCodeResult As String = ""
            Dim dt, dtBill, dtExdUpdFirmWareBillCodeModels As DataTable
            Dim R1, R2 As DataRow
            Dim objProdShip As Data.Production.Shipping
            Dim objSkullCandy As Data.Buisness.Skullcandy
            Dim bScrap, bRep, bTestOnly As Boolean
            Dim objDevice As Rules.Device

            Try
                bScrap = False : bRep = False : bTestOnly = False
                objProdShip = New Data.Production.Shipping()
                objSkullCandy = New Data.buisness.Skullcandy()
                dtExdUpdFirmWareBillCodeModels = PSS.Data.Buisness.ModManuf.ParseExceptionCriteria("ASTRO_EXCLUDE_UPD_FIRMWARE_BILLCODES", "ModelIDs", ",")

                dt = objProdShip.GetDeviceSNs(iPalletID)
                For Each R1 In dt.Rows
                    'Scrap, Repair, TestOnly, or NotDefined
                    strDateCodeResult = objSkullCandy.Astro_GetModelRepairType(R1("Device_SN")).ToUpper
                    dtBill = Data.Buisness.DeviceBilling.GetBilledData(R1("Device_ID"))

                    Select Case strDateCodeResult
                        Case "SCRAP"
                            bScrap = True
                        Case "REPAIR"
                            bRep = True
                        Case "TESTONLY"
                            bTestOnly = True
                        Case "NOTDEFINED"
                            MessageBox.Show("Can't define date code for S/N '" & R1("Device_SN") & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        Case Else
                            MessageBox.Show("Can't define date code for S/N '" & R1("Device_SN") & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                    End Select

                    objDevice = New Rules.Device(R1("Device_ID"))

                    For Each R2 In dtBill.Rows
                        If Convert.ToInt32(R2("BillCode_ID")) = Data.Buisness.Skullcandy.AstroServiceBillcode.Receiving AndAlso _
                           Convert.ToInt32(R2("BillCode_ID")) = Data.Buisness.Skullcandy.AstroServiceBillcode.Scrap Then
                            'Keep Receive & scrap billcode
                        ElseIf bScrap = False AndAlso Convert.ToInt32(R2("BillCode_ID")) = Data.Buisness.Skullcandy.AstroServiceBillcode.UpdateFirmware AndAlso dtExdUpdFirmWareBillCodeModels.Select("Model_ID = " & R1("Model_ID")).Length = 0 Then
                            'Keep Update Firmware Billcode
                        ElseIf bScrap = False AndAlso Convert.ToInt32(R2("BillCode_ID")) = Data.Buisness.Skullcandy.AstroServiceBillcode.Testing Then
                            'Keep Update Testing Billcode
                        Else
                            objDevice.DeletePart(R2("BillCode_ID"))
                        End If
                    Next R2
                    'Bill Receiving
                    If Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), Data.Buisness.Skullcandy.AstroServiceBillcode.Receiving) = False Then
                        objDevice.AddPart(Data.Buisness.Skullcandy.AstroServiceBillcode.Receiving)
                    End If
                    'Bill Scrap
                    If Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), Data.Buisness.Skullcandy.AstroServiceBillcode.Scrap) = False Then
                        objDevice.AddPart(Data.Buisness.Skullcandy.AstroServiceBillcode.Scrap)
                    End If

                    If bRep OrElse bTestOnly Then
                        'Some model can't perform update firmware
                        If dtExdUpdFirmWareBillCodeModels.Select("Model_ID = " & R1("Model_ID")).Length = 0 Then
                            If Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), Data.Buisness.Skullcandy.AstroServiceBillcode.UpdateFirmware) = False Then
                                objDevice.AddPart(Data.Buisness.Skullcandy.AstroServiceBillcode.UpdateFirmware)
                            End If
                        End If
                        If Data.Buisness.Generic.IsBillcodeExisted(R1("Device_ID"), Data.Buisness.Skullcandy.AstroServiceBillcode.Testing) = False Then
                            objDevice.AddPart(Data.Buisness.Skullcandy.AstroServiceBillcode.Testing)
                        End If
                    End If

                    objDevice.Update()
                    strDateCodeResult = "" : Data.Buisness.Generic.DisposeDT(dtBill)
                    objDevice.Dispose() : objDevice = Nothing
                Next R1

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                objSkullCandy = Nothing : objSkullCandy = Nothing
                Data.Buisness.Generic.DisposeDT(dt)
                Data.Buisness.Generic.DisposeDT(dtExdUpdFirmWareBillCodeModels)
                Data.Buisness.Generic.DisposeDT(dtBill)
            End Try
        End Function

        '***************************************************************************************

    End Class
End Namespace