Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class SyxProduce
        Inherits System.Windows.Forms.Form
        Private _strScreenName As String = ""

        Private _objShip As PSS.Data.Production.Shipping
        Private _objSyxShip As PSS.Data.Buisness.SyxReceivingShipping
        Private _booPopulateDataToCtrl As Boolean = False
        Private _strPalletPreFix As String = ""
        Private _booUnderValueCost As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objShip = New PSS.Data.Production.Shipping()
            _objSyxShip = New PSS.Data.Buisness.SyxReceivingShipping()
            _strScreenName = strScreenName
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
        Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
        Friend WithEvents btnClearAllFilter As System.Windows.Forms.Button
        Friend WithEvents btnDeleteBox As System.Windows.Forms.Button
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnReopenBox As System.Windows.Forms.Button
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents btnRefreshOpenPallets As System.Windows.Forms.Button
        Friend WithEvents pnlShipType As System.Windows.Forms.Panel
        Friend WithEvents btnClearPalletCriteria As System.Windows.Forms.Button
        Friend WithEvents cboBoxTypes As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnCreateBoxID As System.Windows.Forms.Button
        Friend WithEvents panelPallet As System.Windows.Forms.Panel
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents btnReprintPalletManifest As System.Windows.Forms.Button
        Friend WithEvents btnCreatePalletManifest As System.Windows.Forms.Button
        Friend WithEvents lblServices As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SyxProduce))
            Me.PanelPalletList = New System.Windows.Forms.Panel()
            Me.btnCreatePalletManifest = New System.Windows.Forms.Button()
            Me.btnReprintPalletManifest = New System.Windows.Forms.Button()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.btnClearAllFilter = New System.Windows.Forms.Button()
            Me.btnDeleteBox = New System.Windows.Forms.Button()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReopenBox = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.btnRefreshOpenPallets = New System.Windows.Forms.Button()
            Me.pnlShipType = New System.Windows.Forms.Panel()
            Me.btnClearPalletCriteria = New System.Windows.Forms.Button()
            Me.cboBoxTypes = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnCreateBoxID = New System.Windows.Forms.Button()
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.lblServices = New System.Windows.Forms.Label()
            Me.PanelPalletList.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlShipType.SuspendLayout()
            CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelPallet.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelPalletList
            '
            Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreatePalletManifest, Me.btnReprintPalletManifest, Me.lblLine, Me.btnClearAllFilter, Me.btnDeleteBox, Me.dbgPallets, Me.btnReopenBox, Me.btnReprintBoxLabel, Me.btnRefreshOpenPallets})
            Me.PanelPalletList.Location = New System.Drawing.Point(3, 0)
            Me.PanelPalletList.Name = "PanelPalletList"
            Me.PanelPalletList.Size = New System.Drawing.Size(461, 488)
            Me.PanelPalletList.TabIndex = 125
            '
            'btnCreatePalletManifest
            '
            Me.btnCreatePalletManifest.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCreatePalletManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreatePalletManifest.ForeColor = System.Drawing.Color.Black
            Me.btnCreatePalletManifest.Location = New System.Drawing.Point(264, 400)
            Me.btnCreatePalletManifest.Name = "btnCreatePalletManifest"
            Me.btnCreatePalletManifest.Size = New System.Drawing.Size(112, 32)
            Me.btnCreatePalletManifest.TabIndex = 130
            Me.btnCreatePalletManifest.Text = "Create Pallet Manifest"
            '
            'btnReprintPalletManifest
            '
            Me.btnReprintPalletManifest.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintPalletManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintPalletManifest.ForeColor = System.Drawing.Color.Black
            Me.btnReprintPalletManifest.Location = New System.Drawing.Point(136, 400)
            Me.btnReprintPalletManifest.Name = "btnReprintPalletManifest"
            Me.btnReprintPalletManifest.Size = New System.Drawing.Size(112, 32)
            Me.btnReprintPalletManifest.TabIndex = 129
            Me.btnReprintPalletManifest.Text = "Re-print Pallet Manifest"
            '
            'lblLine
            '
            Me.lblLine.BackColor = System.Drawing.Color.Black
            Me.lblLine.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLine.ForeColor = System.Drawing.Color.Lime
            Me.lblLine.Location = New System.Drawing.Point(8, 16)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(432, 24)
            Me.lblLine.TabIndex = 128
            Me.lblLine.Tag = "0"
            Me.lblLine.Text = "Label1"
            '
            'btnClearAllFilter
            '
            Me.btnClearAllFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearAllFilter.ForeColor = System.Drawing.Color.White
            Me.btnClearAllFilter.Location = New System.Drawing.Point(136, 360)
            Me.btnClearAllFilter.Name = "btnClearAllFilter"
            Me.btnClearAllFilter.Size = New System.Drawing.Size(112, 32)
            Me.btnClearAllFilter.TabIndex = 127
            Me.btnClearAllFilter.Text = "CLEAR ALL FILTER"
            '
            'btnDeleteBox
            '
            Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
            Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
            Me.btnDeleteBox.Location = New System.Drawing.Point(264, 360)
            Me.btnDeleteBox.Name = "btnDeleteBox"
            Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeleteBox.Size = New System.Drawing.Size(112, 32)
            Me.btnDeleteBox.TabIndex = 2
            Me.btnDeleteBox.Text = "DELETE EMPTY PALLET"
            '
            'dbgPallets
            '
            Me.dbgPallets.AllowColMove = False
            Me.dbgPallets.AllowColSelect = False
            Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgPallets.AllowSort = False
            Me.dbgPallets.AllowUpdate = False
            Me.dbgPallets.AllowUpdateOnBlur = False
            Me.dbgPallets.AlternatingRows = True
            Me.dbgPallets.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgPallets.Caption = "Open Pallets"
            Me.dbgPallets.CaptionHeight = 19
            Me.dbgPallets.CollapseColor = System.Drawing.Color.White
            Me.dbgPallets.ExpandColor = System.Drawing.Color.White
            Me.dbgPallets.FilterBar = True
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.ForeColor = System.Drawing.Color.White
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(0, 56)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(456, 288)
            Me.dbgPallets.TabIndex = 0
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{Font:Microsoft Sans Serif, 6.75pt, style" & _
            "=Bold;ForeColor:Black;BackColor:White;}Footer{}Caption{AlignHorz:Center;ForeColo" & _
            "r:White;BackColor:SteelBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, s" & _
            "tyle=Bold;AlignVert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRo" & _
            "w{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{ForeColor:Black;B" & _
            "ackColor:LightSteelBlue;}RecordSelector{ForeColor:White;AlignImage:Center;}Style" & _
            "15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Ce" & _
            "nter;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;AlignVert:Center" & _
            ";}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}S" & _
            "tyle9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fals" & _
            "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
            "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar" & _
            "=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>265</Height><Capt" & _
            "ionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5""" & _
            " /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBa" & _
            "r"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=" & _
            """Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRo" & _
            "wStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""" & _
            "Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent" & _
            "=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" />" & _
            "<Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 19, 452, 265</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 452, 284</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Bl" & _
            "ob>"
            '
            'btnReopenBox
            '
            Me.btnReopenBox.BackColor = System.Drawing.Color.Green
            Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenBox.ForeColor = System.Drawing.Color.White
            Me.btnReopenBox.Location = New System.Drawing.Point(392, 360)
            Me.btnReopenBox.Name = "btnReopenBox"
            Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenBox.Size = New System.Drawing.Size(24, 32)
            Me.btnReopenBox.TabIndex = 1
            Me.btnReopenBox.Text = "RE-OPEN  PALLET"
            Me.btnReopenBox.Visible = False
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(8, 400)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(112, 32)
            Me.btnReprintBoxLabel.TabIndex = 3
            Me.btnReprintBoxLabel.Text = "REPRINT PALLET LABEL"
            '
            'btnRefreshOpenPallets
            '
            Me.btnRefreshOpenPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshOpenPallets.ForeColor = System.Drawing.Color.White
            Me.btnRefreshOpenPallets.Location = New System.Drawing.Point(8, 360)
            Me.btnRefreshOpenPallets.Name = "btnRefreshOpenPallets"
            Me.btnRefreshOpenPallets.Size = New System.Drawing.Size(112, 32)
            Me.btnRefreshOpenPallets.TabIndex = 126
            Me.btnRefreshOpenPallets.Text = "REFRESH LIST"
            '
            'pnlShipType
            '
            Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClearPalletCriteria, Me.cboBoxTypes, Me.Label2, Me.btnCreateBoxID})
            Me.pnlShipType.Location = New System.Drawing.Point(464, 0)
            Me.pnlShipType.Name = "pnlShipType"
            Me.pnlShipType.Size = New System.Drawing.Size(328, 88)
            Me.pnlShipType.TabIndex = 123
            '
            'btnClearPalletCriteria
            '
            Me.btnClearPalletCriteria.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnClearPalletCriteria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearPalletCriteria.ForeColor = System.Drawing.Color.Black
            Me.btnClearPalletCriteria.Location = New System.Drawing.Point(32, 48)
            Me.btnClearPalletCriteria.Name = "btnClearPalletCriteria"
            Me.btnClearPalletCriteria.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClearPalletCriteria.Size = New System.Drawing.Size(64, 24)
            Me.btnClearPalletCriteria.TabIndex = 88
            Me.btnClearPalletCriteria.Text = "CLEAR"
            '
            'cboBoxTypes
            '
            Me.cboBoxTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBoxTypes.Caption = ""
            Me.cboBoxTypes.CaptionHeight = 17
            Me.cboBoxTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBoxTypes.ColumnCaptionHeight = 17
            Me.cboBoxTypes.ColumnFooterHeight = 17
            Me.cboBoxTypes.ContentHeight = 15
            Me.cboBoxTypes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBoxTypes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBoxTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBoxTypes.EditorHeight = 15
            Me.cboBoxTypes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboBoxTypes.ItemHeight = 15
            Me.cboBoxTypes.Location = New System.Drawing.Point(96, 12)
            Me.cboBoxTypes.MatchEntryTimeout = CType(2000, Long)
            Me.cboBoxTypes.MaxDropDownItems = CType(5, Short)
            Me.cboBoxTypes.MaxLength = 32767
            Me.cboBoxTypes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBoxTypes.Name = "cboBoxTypes"
            Me.cboBoxTypes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBoxTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBoxTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBoxTypes.Size = New System.Drawing.Size(216, 21)
            Me.cboBoxTypes.TabIndex = 1
            Me.cboBoxTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(0, 12)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(88, 23)
            Me.Label2.TabIndex = 87
            Me.Label2.Text = "Pallet Type:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCreateBoxID
            '
            Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
            Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
            Me.btnCreateBoxID.Location = New System.Drawing.Point(152, 48)
            Me.btnCreateBoxID.Name = "btnCreateBoxID"
            Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateBoxID.Size = New System.Drawing.Size(160, 24)
            Me.btnCreateBoxID.TabIndex = 3
            Me.btnCreateBoxID.Text = "CREATE PALLET ID"
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblServices, Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblBoxName})
            Me.panelPallet.Location = New System.Drawing.Point(464, 88)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(328, 400)
            Me.panelPallet.TabIndex = 124
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(8, 128)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(176, 20)
            Me.txtDevSN.TabIndex = 0
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 112)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(176, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseBox.Location = New System.Drawing.Point(192, 312)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseBox.Size = New System.Drawing.Size(128, 30)
            Me.btnCloseBox.TabIndex = 2
            Me.btnCloseBox.Text = "CLOSE PALLET"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(192, 240)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(128, 30)
            Me.btnRemoveAllSNs.TabIndex = 4
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(192, 192)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(128, 30)
            Me.btnRemoveSN.TabIndex = 3
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(8, 152)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(176, 225)
            Me.lstDevices.TabIndex = 1
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(216, 128)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(96, 43)
            Me.lblCount.TabIndex = 97
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(216, 112)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "Pallet Quantity"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Black
            Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxName.Location = New System.Drawing.Point(8, 7)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(312, 33)
            Me.lblBoxName.TabIndex = 98
            Me.lblBoxName.Tag = "0"
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblServices
            '
            Me.lblServices.BackColor = System.Drawing.Color.Black
            Me.lblServices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblServices.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblServices.ForeColor = System.Drawing.Color.Lime
            Me.lblServices.Location = New System.Drawing.Point(8, 48)
            Me.lblServices.Name = "lblServices"
            Me.lblServices.Size = New System.Drawing.Size(312, 48)
            Me.lblServices.TabIndex = 100
            Me.lblServices.Tag = "0"
            '
            'SyxProduce
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(808, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelPalletList, Me.pnlShipType, Me.panelPallet})
            Me.Name = "SyxProduce"
            Me.Text = "SyxProduce"
            Me.PanelPalletList.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlShipType.ResumeLayout(False)
            CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelPallet.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************************************************
        Private Sub frmBuildShipBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim drShipType() As DataRow
            Dim objProdRec As PSS.Data.Production.Receiving
            Dim i As Integer = 0
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try
                dt = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
                If dt.Rows.Count = 0 OrElse dt.Rows(0)("Line_ID") = 0 Then
                    MessageBox.Show("Please map your computer.", "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = False : Exit Sub
                Else
                    Me.lblLine.Tag = dt.Rows(0)("Line_ID")
                    Me.lblLine.Text = dt.Rows(0)("Line_Number")
                    _strPalletPreFix = dt.Rows(0)("Line_ID").ToString.Trim.PadLeft(2, "0") & "SYX"
                End If

                Generic.DisposeDT(dt)
                _booPopulateDataToCtrl = True
                '******************************************
                'populate data to dropdown list controls
                '******************************************

                'Populate Repair Type (lprojecttype)
                dt = _objShip.GetShipPalletTypes(True, 1)

                'Remove Recycle Pallet Type, which is Syx not use.
                drShipType = dt.Select("PalletType_ID = 7")
                For i = 0 To drShipType.Length - 1
                    dt.Rows.Remove(drShipType(i))
                Next i
                dt.AcceptChanges()

                Misc.PopulateC1DropDownList(Me.cboBoxTypes, dt, "Pallettype_LDesc", "PalletType_ID")
                Me.cboBoxTypes.SelectedValue = 0

                'Populate open pallet
                Me.PopulateOpenPallets()

                '******************************************

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objMisc = Nothing
                Generic.DisposeDT(dt)
                _booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub cbos_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBoxTypes.RowChange
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.ClearPanelPallet()

                If _booPopulateDataToCtrl = False Then

                    If sender.name = "cboBoxTypes" Then
                        If Me.cboBoxTypes.SelectedValue > 0 Then
                            Me.btnCreateBoxID.Visible = True
                        Else
                            Me.btnCreateBoxID.Visible = False
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbos_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub PopulateOpenPallets(Optional ByVal iPalletID As Integer = 0)
            Dim dt As DataTable
            Dim i As Integer
            Try
                Me._booPopulateDataToCtrl = True
                dt = Me._objShip.GetOpenPallet(PSS.Data.Buisness.Syx.LOCID, PSS.Data.Buisness.Syx.CUSTOMERID, , Me._strPalletPreFix)
                dt.Columns("Pallett_Name").ColumnName = "Pallet"
                dt.Columns("Pallettype_SDesc").ColumnName = "Pallet Type" : dt.AcceptChanges()

                With Me.dbgPallets
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For i = 0 To dt.Columns.Count - 1
                        'Make some columns invisible
                        .Splits(0).DisplayColumns(i).Visible = False
                    Next i
                    .Splits(0).DisplayColumns("Pallet").Width = 150
                    .Splits(0).DisplayColumns("Pallet Type").Width = 100

                    .Splits(0).DisplayColumns("Pallet").Visible = True
                    .Splits(0).DisplayColumns("Pallet Type").Visible = True

                    If iPalletID > 0 Then
                        .MoveFirst()
                        For i = 0 To dt.Rows.Count - 1
                            If CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString) <> iPalletID Then .MoveNext() Else Exit For
                        Next i
                    End If
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt) : Me._booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ClearPanelPallet()
            Try
                Me.txtDevSN.Text = "" : Me.lblBoxName.Text = "" : Me.lblBoxName.Tag = 0 : Me.lblCount.Text = ""
                Me.lstDevices.DataSource = Nothing : Me.lstDevices.Items.Clear() : Me.lstDevices.Refresh()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub dbgPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgPallets.RowColChange
            Dim iPalletID As Integer = 0
            Dim strPalletName As String = ""

            Try
                _booPopulateDataToCtrl = True : Me.cboBoxTypes.SelectedValue = 0
                Me.btnCreateBoxID.Enabled = False : Me.ClearPanelPallet()

                If Me.dbgPallets.RowCount > 0 AndAlso Me.dbgPallets.Columns.Count > 0 Then
                    iPalletID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value)
                    strPalletName = Me.dbgPallets.Columns("Pallet").Value.ToString.Trim

                    If iPalletID = 0 Then
                        MessageBox.Show("Pallet is not selected.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf strPalletName.Trim = "" Then
                        MessageBox.Show("Pallet is not selected.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Convert.ToInt32(Me.dbgPallets.Columns("PalletType_ID").Value) = 0 Then
                        MessageBox.Show("Pallet type is missing.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.cboBoxTypes.SelectedValue = Convert.ToInt32(Me.dbgPallets.Columns("PalletType_ID").Value) : Me.cboBoxTypes.Enabled = False
                        Me.lblBoxName.Text = strPalletName : Me.lblBoxName.Tag = iPalletID
                        Me.RefreshSNList(iPalletID) : Me.txtDevSN.Focus()
                        If Me.cboBoxTypes.SelectedValue = 9 Then
                            Me._booUnderValueCost = True
                        Else
                            Me._booUnderValueCost = False
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnSelectPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnClearPalletCriteria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPalletCriteria.Click
            Try
                Me._booPopulateDataToCtrl = True
                Me.ClearPanelPallet()
                Me.cboBoxTypes.SelectedValue = 0 : Me.cboBoxTypes.Enabled = True : Me.btnCreateBoxID.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearPalletCriteria_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me._booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub RefreshSNList(ByVal iPalletID As Integer)
            Dim dt As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                '*******************************************
                'Get all devices add put them in them in list box for a pallet
                objMisc = New PSS.Data.Buisness.Misc()
                dt = objMisc.GetAllSNsForPallet(iPalletID)
                Me.lstDevices.DataSource = dt.DefaultView
                Me.lstDevices.ValueMember = dt.Columns("device_id").ToString
                Me.lstDevices.DisplayMember = dt.Columns("device_sn").ToString

                '*******************************************
                Me.lblCount.Text = dt.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                objMisc = Nothing : Generic.DisposeDT(dt) : Me.txtDevSN.Focus()
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnCreateBoxID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click
            Dim dt As DataTable
            Dim iPalletID, iPalletTypeID, iPalletShipType As Integer
            Dim strPalletTypeSDesc As String = ""

            Try
                If Me.cboBoxTypes.SelectedValue = 0 Then
                    MessageBox.Show("Please select pallet type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBoxTypes.SelectAll() : Me.cboBoxTypes.Focus()
                ElseIf IsDBNull(Me.cboBoxTypes.DataSource.Table.Select("PalletType_ID = " & Me.cboBoxTypes.SelectedValue)(0)("BillRule_ID")) Then
                    MessageBox.Show("pallet ship type is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBoxTypes.SelectAll() : Me.cboBoxTypes.Focus()
                ElseIf IsDBNull(Me.cboBoxTypes.DataSource.Table.Select("PalletType_ID = " & Me.cboBoxTypes.SelectedValue)(0)("Pallettype_SDesc")) Then
                    MessageBox.Show("pallet type short description is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBoxTypes.SelectAll() : Me.cboBoxTypes.Focus()
                Else
                    dt = Me._objShip.GetAvailablePallets(False, PSS.Data.Buisness.Syx.LOCID, PSS.Data.Buisness.Syx.CUSTOMERID, 0, 0, , , , Me.cboBoxTypes.SelectedValue, Me._strPalletPreFix)
                    If dt.Rows.Count = 0 Then
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        iPalletID = 0 : iPalletTypeID = 0 : iPalletShipType = 0
                        iPalletTypeID = Me.cboBoxTypes.SelectedValue

                        iPalletShipType = Convert.ToInt32(Me.cboBoxTypes.DataSource.Table.Select("PalletType_ID = " & iPalletTypeID)(0)("BillRule_ID"))
                        strPalletTypeSDesc = Me.cboBoxTypes.DataSource.Table.Select("PalletType_ID = " & iPalletTypeID)(0)("Pallettype_SDesc")
                        iPalletID = Me._objShip.CreatePallet(PSS.Data.Buisness.Syx.CUSTOMERID, PSS.Data.Buisness.Syx.LOCID, 0, iPalletTypeID, iPalletShipType, strPalletTypeSDesc, Me._strPalletPreFix)

                        If iPalletID = 0 Then
                            MessageBox.Show("System has failed to create pallet ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            Me.btnCreateBoxID.Enabled = False
                            Me.PopulateOpenPallets(iPalletID)
                            If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = iPalletID Then
                                Me.lblBoxName.Tag = iPalletID : Me.lblBoxName.Text = Me.dbgPallets.Columns("Pallet").Value.ToString
                                Me.RefreshSNList(iPalletID)
                                Me.cboBoxTypes.Enabled = False
                            End If
                            Me.Enabled = True : Me.txtDevSN.Focus()
                        End If
                    Else
                        MessageBox.Show("An open pallet is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.dbgPallets.Columns("Pallet").FilterText = dt.Rows(0)("Pallett_Name")
                        Me.dbgPallets.Columns("Pallet Type").FilterText = dt.Rows(0)("Pallettype_SDesc")
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim i, iDevMaxBillRule, iPretestResultID As Integer
            Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
            Dim dtDevice As DataTable
            Dim dbUnderValueCost As Double

            Try
                If e.KeyCode <> Keys.Enter Then Exit Sub
                '************************
                'Validations
                If strSN.Length = 0 Then
                    Exit Sub
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Pallet ID is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                ElseIf Me.lblBoxName.Text.ToString.Trim = "" Then
                    MessageBox.Show("Pallet Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                ElseIf Me.lstDevices.DataSource.table.select("device_sn = '" & strSN.Trim & "'").length > 0 Then
                    '***************************************************
                    'Check if the Device is already scanned in
                    '***************************************************
                    MessageBox.Show("This device is already listed. Try another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()

                ElseIf Me.cboBoxTypes.SelectedValue = 0 Then
                    MessageBox.Show("Pallet type is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                ElseIf Generic.IsPalletClosed(Me.lblBoxName.Tag) = True Then
                    '***************************************************
                    'Added by Lan on 09/16/2007
                    'Prevent the user from adding more devices to closed pallet.
                    'This happen when a pallet open at the 2 computer, computer 1 
                    '  close the pallet and refesh the screen while the other computer screen 
                    '  did not get refresh. This check will force the user to refresh the screen.
                    '***************************************************
                    MessageBox.Show("Pallet had been closed by another machine. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dtDevice = Generic.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, PSS.Data.Buisness.Syx.CUSTOMERID, PSS.Data.Buisness.Syx.LOCID, True)

                    If dtDevice.Rows.Count > 1 Then
                        MessageBox.Show("This device existed twice in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDevSN.SelectAll()
                    ElseIf dtDevice.Rows.Count = 0 Then
                        MessageBox.Show("This device does not exist in the system, already ship or belongs to a different customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDevSN.SelectAll()
                    ElseIf Convert.ToInt32(dtDevice.Rows(0)("Cellopt_WIPOwner")) = 8 Then
                        MessageBox.Show("This device is currently waiting for part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDevSN.SelectAll()
                    ElseIf Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                        MessageBox.Show("This device has assigned to Pallet ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDevSN.SelectAll()
                    ElseIf Me.cboBoxTypes.SelectedValue <> 10 AndAlso Me._booUnderValueCost = False AndAlso IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                        'Me.cboBoxTypes.SelectedValue = 10 is Syx Misc C
                        MessageBox.Show("This device has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDevSN.SelectAll()
                    ElseIf Me.cboBoxTypes.SelectedValue <> 10 AndAlso Me._booUnderValueCost = False AndAlso CInt(Me.cboBoxTypes.DataSource.Table.Select("PalletType_ID = " & Me.cboBoxTypes.SelectedValue)(0)("NoPartAllow")) = 1 AndAlso Generic.IsDeviceHadParts(dtDevice.Rows(0)("Device_ID")) = True Then
                        MessageBox.Show("Pallet type does not allow device with part. Please un-bill all parts.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDevSN.SelectAll()
                    ElseIf Me.cboBoxTypes.SelectedValue = 11 AndAlso Me._objSyxShip.IsDeviceHasCosBBillcode(dtDevice.Rows(0)("Device_ID")) = False Then
                        MessageBox.Show("Device must have Cosmetic - B service code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDevSN.SelectAll()
                    ElseIf Me.cboBoxTypes.SelectedValue <> 11 AndAlso Me._objSyxShip.IsDeviceHasCosBBillcode(dtDevice.Rows(0)("Device_ID")) = True Then
                        MessageBox.Show("This is Cosmetic - B device.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.Enabled = True : Me.txtDevSN.SelectAll()
                    Else
                        '*****************************************************
                        'VALIDATE UNDER COST VALUE
                        '*****************************************************
                        If Me._booUnderValueCost = True Then
                            dbUnderValueCost = Me._objSyxShip.GetUnderValueCost()
                            If _objSyxShip.GetDeviceCost(dtDevice.Rows(0)("Device_ID")) > dbUnderValueCost Then
                                MessageBox.Show("This is not an UNDER COST item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                            End If
                        Else
                            '******************************************
                            'Validate workstaion
                            '******************************************
                            If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, dtDevice.Rows(0)("Workstation").ToString.Trim, PSS.Data.Buisness.Syx.CUSTOMERID, 0, True) = False Then
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                            End If
                            '******************************************
                        End If
                        '*****************************************************

                        iDevMaxBillRule = Generic.GetMaxBillRule(dtDevice.Rows(0)("Device_ID"))
                        If Me.cboBoxTypes.SelectedValue <> 10 AndAlso Me._booUnderValueCost = False AndAlso CInt(Me.cboBoxTypes.DataSource.Table.Select("PalletType_ID = " & Me.cboBoxTypes.SelectedValue)(0)("BillRule_ID")) = 0 AndAlso iDevMaxBillRule > 0 Then
                            MessageBox.Show("Can't mix RUR/BER device with refurbished pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.Enabled = False : Me.txtDevSN.SelectAll()
                        ElseIf Me.cboBoxTypes.SelectedValue <> 10 AndAlso Me._booUnderValueCost = False And CInt(Me.cboBoxTypes.DataSource.Table.Select("PalletType_ID = " & Me.cboBoxTypes.SelectedValue)(0)("BillRule_ID")) > 0 AndAlso iDevMaxBillRule = 0 Then
                            MessageBox.Show("Can't mix refurbished device with RUR/BER pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.Enabled = True : Me.txtDevSN.SelectAll()
                        Else
                            '*****************************************************
                            'Check QC
                            '*****************************************************
                            If Me.cboBoxTypes.SelectedValue <> 10 AndAlso Me._booUnderValueCost = False AndAlso iDevMaxBillRule = 0 AndAlso Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 2, "FQA", True, True) = False Then
                                Me.Enabled = True : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                            ElseIf Me.cboBoxTypes.SelectedValue <> 10 AndAlso Me._booUnderValueCost = False AndAlso iDevMaxBillRule = 0 AndAlso dtDevice.Rows(0)("Prod_ID") = 11 AndAlso Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 4, "AQL", True, True) = False Then
                                Me.Enabled = True : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                            End If
                            '*****************************************************
                            'Check Pretest fail for Misc C devices
                            '*****************************************************
                            iPretestResultID = Me._objSyxShip.GetPretestResult(dtDevice.Rows(0)("Device_ID"))
                            If Me.cboBoxTypes.SelectedValue = 10 AndAlso iPretestResultID = 1 Then
                                MessageBox.Show("Device has been passed at triage.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.Enabled = True : Me.txtDevSN.SelectAll() : Exit Sub
                            ElseIf Me.cboBoxTypes.SelectedValue = 10 AndAlso iPretestResultID <> 2 Then
                                MessageBox.Show("Device has no triage record.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.Enabled = True : Me.txtDevSN.SelectAll() : Exit Sub
                            End If

                            '***************************************************
                            'if above all is fine then add it to the list and update the database
                            i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.lblBoxName.Tag))

                            '***************************************************
                            Me.RefreshSNList(CInt(Me.lblBoxName.Tag))
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                            '***************************************************
                        End If 'Bill Rule
                    End If 'Device Data
                    End If 'Input data
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Enabled = True : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
            Finally
                Generic.DisposeDT(dtDevice)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strSN As String = ""
            Dim i As Integer = 0
            Dim iDeviceID As Integer = 0

            Try
                '************************
                'Validations
                If Me.lstDevices.Items.Count = 0 Or Me.lblBoxName.Tag = 0 Or Me.lblBoxName.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Pallet name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    '************************
                    strSN = InputBox("Enter S/N #:", "SN").Trim
                    If strSN = "" Then
                        MessageBox.Show("Please enter a S/N # if you want to remove it from the selected list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Me.lstDevices.DataSource.Table.select("Device_SN = '" & strSN & "'").length = 0 Then
                        MessageBox.Show("S/N was not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        iDeviceID = Me.lstDevices.DataSource.Table.select("Device_SN = '" & strSN & "'")(0)("Device_ID")
                        If iDeviceID > 0 Then
                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                            i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.lblBoxName.Tag), iDeviceID)
                            If i = 0 Then
                                MessageBox.Show("System has failed to remove S/N # from list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                Me.RefreshSNList(CInt(Me.lblBoxName.Tag))
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveSN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Dim str_sn As String = ""
            Dim i As Integer = 0

            Try
                '************************
                'Validations
                '************************
                If Me.lstDevices.Items.Count = 0 Or Me.lblBoxName.Tag = 0 Then
                    Exit Sub
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Pallet name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf MessageBox.Show("Are you sure you want to remove all devices from this pallet (" & Me.lblBoxName.Text & ")?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    '************************
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.lblBoxName.Tag), )
                    If i = 0 Then
                        MessageBox.Show("System has failed to remove S/Ns from pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.RefreshSNList(CInt(Me.lblBoxName.Tag))
                    End If
                    '************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllSNs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRefreshOpenPallets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshOpenPallets.Click
            Dim booResetSelectedPallet As Boolean = False
            Try
                Me.PopulateOpenPallets()
                If Me.dbgPallets.RowCount = 0 OrElse (Convert.ToInt32(Me.lblBoxName.Tag) > 0 AndAlso Me.dbgPallets.DataSource.Table.Select("Pallett_ID = " & Me.lblBoxName.Tag).Length = 0) Then
                    Me._booPopulateDataToCtrl = True
                    Me.cboBoxTypes.SelectedValue = 0 : Me.cboBoxTypes.Enabled = False
                    Me.ClearPanelPallet()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshOpenPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me._booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnClearAllFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAllFilter.Click
            Dim i As Integer = 0
            Try
                With Me.dbgPallets
                    If .RowCount > 0 AndAlso .Columns.Count > 0 Then
                        For i = 0 To .Columns.Count - 1
                            .Columns(i).FilterText = ""
                        Next i
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearAllFilter_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim str_pallett As String
            Dim dt As DataTable

            Try
                str_pallett = InputBox("Enter pallet name.", "Reprint pallet Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a pallet name if you want to reprint the pallet label.")
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                dt = Me._objShip.GetPalletInfoByName(str_pallett, PSS.Data.Buisness.Syx.CUSTOMERID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("pallet is not defined in system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("pallet existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("pallet is still open.", "Information", MessageBoxButtons.OK)
                Else
                    PSS.Data.Production.Shipping.PrintPalletLicensePlate(dt.Rows(0)("Pallett_Name"), dt.Rows(0)("Model_ID"), dt.Rows(0)("Pallettype_LDesc"), dt.Rows(0)("Pallett_QTY"), 1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnDeleteBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBox.Click
            Dim i As Integer = 0
            Dim booResetSelectedPallet As Boolean = False

            Try
                If Me.dbgPallets.RowCount = 0 OrElse Me.dbgPallets.Columns.Count = 0 Then
                    Exit Sub
                ElseIf Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row)) = 0 Then
                    MessageBox.Show("Pallet ID is missing for selected row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf MessageBox.Show("Are you sure you want to delete Pallet " & Me.dbgPallets.Columns("Pallet").Value & ")?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    If Convert.ToInt32(Me.lblBoxName.Tag) > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) = Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row)) Then booResetSelectedPallet = True

                    i = PSS.Data.Production.Shipping.DeleteEmptyPallet(Convert.ToInt32(Me.dbgPallets.Columns("Pallett_ID").CellValue(Me.dbgPallets.Row)), PSS.Core.ApplicationUser.IDuser)
                    If i > 0 Then
                        If booResetSelectedPallet = True Then
                            Me.ClearPanelPallet()
                            Me.btnCreateBoxID.Enabled = True
                            Me._booPopulateDataToCtrl = True
                            Me.cboBoxTypes.SelectedValue = 0 : Me.cboBoxTypes.Enabled = True
                        End If
                        Me.PopulateOpenPallets()
                        MessageBox.Show("Pallet has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("System has failed to delete Pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnDeleteBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default : Me._booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnReopenBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenBox.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim dt, dt2 As DataTable

            Try
                '************************
                strPallet = InputBox("Enter pallet ID:", "Reopen Box")
                If strPallet = "" Then
                    MessageBox.Show("Please enter pallet ID to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    dt = PSS.Data.Production.Shipping.GetPalletInfoByName(strPallet, PSS.Data.Buisness.Syx.CUSTOMERID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Pallet does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Pallet id existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                        MessageBox.Show("Pallet has already been shipped. Not allow to re-open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows(0)("Pallet_Invalid") = 1 Then
                        MessageBox.Show("This pallet has been deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                        MessageBox.Show("Pallet is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        dt2 = Me._objShip.GetAvailablePallets(False, PSS.Data.Buisness.Syx.LOCID, PSS.Data.Buisness.Syx.CUSTOMERID, 0, dt.Rows(0)("Model_ID"), , dt.Rows(0)("Pallet_ShipType"), , dt.Rows(0)("PalletType_ID"))
                        If dt2.Rows.Count = 0 Then
                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                            i = PSS.Data.Production.Shipping.ReopenPallet(dt.Rows(0)("Pallett_ID"))
                            If i = 0 Then
                                MessageBox.Show("System has failed to re-open the pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Else
                                Me.ClearPanelPallet() : Me.PopulateOpenPallets(dt.Rows(0)("Pallett_ID"))

                                Me.cboBoxTypes.SelectedValue = Convert.ToInt32(dt.Rows(0)("PalletType_ID")) : Me.cboBoxTypes.Enabled = False
                                Me.lblBoxName.Tag = dt.Rows(0)("Pallett_ID") : Me.lblBoxName.Text = dt.Rows(0)("Pallett_Name")
                                Me.btnCreateBoxID.Enabled = False : Me.RefreshSNList(dt.Rows(0)("Pallett_ID"))

                                Me.Enabled = True : Me.txtDevSN.Focus()
                            End If 'Re-Open status 
                        ElseIf dt2.Rows.Count > 1 Then
                            MessageBox.Show("More than one open pallet is existed. Please contact IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            MessageBox.Show("An open pallet is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.dbgPallets.Columns("Box").FilterText = dt.Rows(0)("Pallett_Name")
                            If Me.dbgPallets.RowCount = 0 Then Me.PopulateOpenPallets(dt2.Rows(0)("Pallett_ID"))
                        End If 'check for open box
                    End If  'validate pallet information
                End If  'Empty input
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReopenBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim i As Integer = 0
            Dim strStatus, strNextStation As String

            Try
                '************************
                'Validations
                If CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Pallet ID is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                ElseIf Me.lblBoxName.Text.ToString.Trim = "" Then
                    MessageBox.Show("Pallet Name is not selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("Pallet is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                ElseIf Me.cboBoxTypes.SelectedValue = 0 Then
                    MessageBox.Show("System can't define status. Please re-select pallet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboBoxTypes.Columns("Pallettype_Status").CellValue(Me.cboBoxTypes.Row).ToString.Trim.Length = 0 Then
                    MessageBox.Show("Pallet's Status is missing. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf MessageBox.Show("Are you sure you want to close this Pallet (" & Me.lblBoxName.Text.ToString.Trim & ")?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.txtDevSN.Text = "" : Me.txtDevSN.Focus()
                Else
                    strStatus = "" : strNextStation = ""
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    strStatus = Me.cboBoxTypes.Columns("Pallettype_Status").CellValue(Me.cboBoxTypes.SelectedIndex)
                    strNextStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Syx.CUSTOMERID, , )
                    If strNextStation.Trim.Length = 0 Then
                        MessageBox.Show("Next location is missing in work flow. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If

                    i = Me._objSyxShip.CloseAndShipBox(CInt(Me.lblBoxName.Tag), Core.ApplicationUser.IDShift, Me.lstDevices.Items.Count, strStatus, Me._objShip, strNextStation)

                    i = Me._objSyxShip.CreateShippingManifest(Me.lblBoxName.Text, CInt(Me.lblBoxName.Tag))

                    PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.lblBoxName.Text.ToString.Trim, 0, Me.cboBoxTypes.Columns("Pallettype_LDesc").CellText(Me.cboBoxTypes.SelectedIndex), Me.lstDevices.Items.Count, 2)
                    '************************
                    If i > 0 Then
                        '******************************
                        'Reset Screen control properties.
                        '******************************
                        Me.PopulateOpenPallets() : Me._booPopulateDataToCtrl = True
                        Me.Enabled = True : Me.ClearPanelPallet()
                        Me.cboBoxTypes.SelectedValue = 0 : Me.cboBoxTypes.Enabled = True

                        '******************************
                    Else
                        MessageBox.Show("System has failed to close box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    '******************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClosePallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me._booPopulateDataToCtrl = False
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnReprint_Create_Manifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintPalletManifest.Click, btnCreatePalletManifest.Click
            Dim str_pallett As String
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                str_pallett = InputBox("Enter pallet name.", "Reprint pallet's manifest")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a pallet name if you want to reprint the pallet's manifest.")
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                dt = Me._objShip.GetPalletInfoByName(str_pallett, PSS.Data.Buisness.Syx.CUSTOMERID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("pallet is not defined in system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("pallet existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("pallet is still open.", "Information", MessageBoxButtons.OK)
                Else
                    Dim strDir As String = PSS.Data.Buisness.SyxReceivingShipping._PalletManifestDir
                    If sender.name = "btnReprintPalletManifest" Then
                        'create if it is missing
                        If System.IO.File.Exists(strDir & str_pallett & ".xls") = False Then
                            i = Me._objSyxShip.CreateShippingManifest(str_pallett, CInt(dt.Rows(0)("Pallett_ID")))
                        End If
                        'print manifest
                        Dim objBulkShip As New PSS.Data.Buisness.BulkShipping()
                        objBulkShip.PrintExcelFile(strDir & str_pallett & ".xls", 1)
                    ElseIf sender.name = "btnCreatePalletManifest" Then
                        If System.IO.File.Exists(strDir & str_pallett & ".xls") = False Then
                            i = Me._objSyxShip.CreateShippingManifest(str_pallett, CInt(dt.Rows(0)("Pallett_ID")))
                        Else
                            MessageBox.Show("File is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprint_Create_Manifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************

    End Class
End Namespace