Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone

    Public Class frmProduceBERObsoleteUnits
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _strScreenName As String = ""

        Private _objTFBuildShipPallet As PSS.Data.Buisness.TracFone.BuildShipPallet

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objTFBuildShipPallet = New PSS.Data.Buisness.TracFone.BuildShipPallet()

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
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnCreatePalletID As System.Windows.Forms.Button
        Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
        Friend WithEvents btnDeleteEmptyPallet As System.Windows.Forms.Button
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnReopenPallet As System.Windows.Forms.Button
        Friend WithEvents btnReprintPalletLabel As System.Windows.Forms.Button
        Friend WithEvents panelPallet As System.Windows.Forms.Panel
        Friend WithEvents txtBoxID As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnClosePallet As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllBoxes As System.Windows.Forms.Button
        Friend WithEvents btnRemoveBox As System.Windows.Forms.Button
        Friend WithEvents lstBoxIDs As System.Windows.Forms.ListBox
        Friend WithEvents lblBoxCnt As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblPalletName As System.Windows.Forms.Label
        Friend WithEvents lblDeviceCnt As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProduceBERObsoleteUnits))
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnCreatePalletID = New System.Windows.Forms.Button()
            Me.PanelPalletList = New System.Windows.Forms.Panel()
            Me.btnDeleteEmptyPallet = New System.Windows.Forms.Button()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReopenPallet = New System.Windows.Forms.Button()
            Me.btnReprintPalletLabel = New System.Windows.Forms.Button()
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.txtBoxID = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnClosePallet = New System.Windows.Forms.Button()
            Me.btnRemoveAllBoxes = New System.Windows.Forms.Button()
            Me.btnRemoveBox = New System.Windows.Forms.Button()
            Me.lstBoxIDs = New System.Windows.Forms.ListBox()
            Me.lblBoxCnt = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblPalletName = New System.Windows.Forms.Label()
            Me.lblDeviceCnt = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelPalletList.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelPallet.SuspendLayout()
            Me.SuspendLayout()
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
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(120, 40)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(240, 21)
            Me.cboModels.TabIndex = 86
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
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(40, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 21)
            Me.Label1.TabIndex = 87
            Me.Label1.Text = "Model:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCreatePalletID
            '
            Me.btnCreatePalletID.BackColor = System.Drawing.Color.Green
            Me.btnCreatePalletID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreatePalletID.ForeColor = System.Drawing.Color.White
            Me.btnCreatePalletID.Location = New System.Drawing.Point(120, 80)
            Me.btnCreatePalletID.Name = "btnCreatePalletID"
            Me.btnCreatePalletID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreatePalletID.Size = New System.Drawing.Size(240, 32)
            Me.btnCreatePalletID.TabIndex = 88
            Me.btnCreatePalletID.Text = "CREATE BOX ID"
            Me.btnCreatePalletID.Visible = False
            '
            'PanelPalletList
            '
            Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteEmptyPallet, Me.dbgPallets, Me.btnReopenPallet, Me.btnReprintPalletLabel})
            Me.PanelPalletList.Location = New System.Drawing.Point(8, 128)
            Me.PanelPalletList.Name = "PanelPalletList"
            Me.PanelPalletList.Size = New System.Drawing.Size(421, 344)
            Me.PanelPalletList.TabIndex = 120
            '
            'btnDeleteEmptyPallet
            '
            Me.btnDeleteEmptyPallet.BackColor = System.Drawing.Color.Red
            Me.btnDeleteEmptyPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteEmptyPallet.ForeColor = System.Drawing.Color.White
            Me.btnDeleteEmptyPallet.Location = New System.Drawing.Point(240, 240)
            Me.btnDeleteEmptyPallet.Name = "btnDeleteEmptyPallet"
            Me.btnDeleteEmptyPallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeleteEmptyPallet.Size = New System.Drawing.Size(168, 32)
            Me.btnDeleteEmptyPallet.TabIndex = 2
            Me.btnDeleteEmptyPallet.Text = "DELETE EMPTY PALLETT"
            '
            'dbgPallets
            '
            Me.dbgPallets.AllowColMove = False
            Me.dbgPallets.AllowColSelect = False
            Me.dbgPallets.AllowFilter = False
            Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgPallets.AllowSort = False
            Me.dbgPallets.AllowUpdate = False
            Me.dbgPallets.AllowUpdateOnBlur = False
            Me.dbgPallets.CaptionHeight = 19
            Me.dbgPallets.CollapseColor = System.Drawing.Color.White
            Me.dbgPallets.ExpandColor = System.Drawing.Color.White
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.ForeColor = System.Drawing.Color.White
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(8, 9)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(400, 223)
            Me.dbgPallets.TabIndex = 0
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
            "lor:White;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVer" & _
            "t:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}Style14{}OddRow{BackColor:Teal;}RecordSelector{Fore" & _
            "Color:White;AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
            "rif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, " & _
            "1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1Tru" & _
            "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
            "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
            "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Ver" & _
            "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>219</Height><CaptionStyle" & _
            " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
            "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
            "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
            "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
            "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
            "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
            "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 396, 219</ClientRect><BorderSide>" & _
            "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 396, 219</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnReopenPallet
            '
            Me.btnReopenPallet.BackColor = System.Drawing.Color.Green
            Me.btnReopenPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenPallet.ForeColor = System.Drawing.Color.White
            Me.btnReopenPallet.Location = New System.Drawing.Point(8, 240)
            Me.btnReopenPallet.Name = "btnReopenPallet"
            Me.btnReopenPallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenPallet.Size = New System.Drawing.Size(168, 32)
            Me.btnReopenPallet.TabIndex = 1
            Me.btnReopenPallet.Text = "REOPEN  PALLET"
            '
            'btnReprintPalletLabel
            '
            Me.btnReprintPalletLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintPalletLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintPalletLabel.Location = New System.Drawing.Point(8, 288)
            Me.btnReprintPalletLabel.Name = "btnReprintPalletLabel"
            Me.btnReprintPalletLabel.Size = New System.Drawing.Size(168, 31)
            Me.btnReprintPalletLabel.TabIndex = 3
            Me.btnReprintPalletLabel.Text = "REPRINT PALLET LABEL"
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDeviceCnt, Me.Label4, Me.txtBoxID, Me.Label10, Me.btnClosePallet, Me.btnRemoveAllBoxes, Me.btnRemoveBox, Me.lstBoxIDs, Me.lblBoxCnt, Me.Label3, Me.lblPalletName})
            Me.panelPallet.Location = New System.Drawing.Point(432, 24)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(504, 448)
            Me.panelPallet.TabIndex = 121
            Me.panelPallet.Visible = False
            '
            'txtBoxID
            '
            Me.txtBoxID.Location = New System.Drawing.Point(8, 64)
            Me.txtBoxID.Name = "txtBoxID"
            Me.txtBoxID.Size = New System.Drawing.Size(224, 20)
            Me.txtBoxID.TabIndex = 0
            Me.txtBoxID.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 48)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(224, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Receiving Box "
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnClosePallet
            '
            Me.btnClosePallet.BackColor = System.Drawing.Color.Green
            Me.btnClosePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClosePallet.ForeColor = System.Drawing.Color.White
            Me.btnClosePallet.Location = New System.Drawing.Point(256, 392)
            Me.btnClosePallet.Name = "btnClosePallet"
            Me.btnClosePallet.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClosePallet.Size = New System.Drawing.Size(152, 30)
            Me.btnClosePallet.TabIndex = 2
            Me.btnClosePallet.Text = "CLOSE PALLET"
            '
            'btnRemoveAllBoxes
            '
            Me.btnRemoveAllBoxes.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllBoxes.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllBoxes.Location = New System.Drawing.Point(256, 264)
            Me.btnRemoveAllBoxes.Name = "btnRemoveAllBoxes"
            Me.btnRemoveAllBoxes.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllBoxes.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveAllBoxes.TabIndex = 4
            Me.btnRemoveAllBoxes.Text = "REMOVE ALL BOXES"
            '
            'btnRemoveBox
            '
            Me.btnRemoveBox.BackColor = System.Drawing.Color.Red
            Me.btnRemoveBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveBox.ForeColor = System.Drawing.Color.White
            Me.btnRemoveBox.Location = New System.Drawing.Point(256, 208)
            Me.btnRemoveBox.Name = "btnRemoveBox"
            Me.btnRemoveBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveBox.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveBox.TabIndex = 3
            Me.btnRemoveBox.Text = "REMOVE BOX"
            '
            'lstBoxIDs
            '
            Me.lstBoxIDs.Location = New System.Drawing.Point(8, 88)
            Me.lstBoxIDs.Name = "lstBoxIDs"
            Me.lstBoxIDs.Size = New System.Drawing.Size(224, 342)
            Me.lstBoxIDs.TabIndex = 1
            '
            'lblBoxCnt
            '
            Me.lblBoxCnt.BackColor = System.Drawing.Color.Black
            Me.lblBoxCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxCnt.Location = New System.Drawing.Point(264, 136)
            Me.lblBoxCnt.Name = "lblBoxCnt"
            Me.lblBoxCnt.Size = New System.Drawing.Size(96, 43)
            Me.lblBoxCnt.TabIndex = 97
            Me.lblBoxCnt.Text = "0"
            Me.lblBoxCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(264, 120)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "Box Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPalletName
            '
            Me.lblPalletName.BackColor = System.Drawing.Color.Black
            Me.lblPalletName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblPalletName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletName.ForeColor = System.Drawing.Color.Lime
            Me.lblPalletName.Location = New System.Drawing.Point(8, 7)
            Me.lblPalletName.Name = "lblPalletName"
            Me.lblPalletName.Size = New System.Drawing.Size(384, 33)
            Me.lblPalletName.TabIndex = 98
            Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDeviceCnt
            '
            Me.lblDeviceCnt.BackColor = System.Drawing.Color.Black
            Me.lblDeviceCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblDeviceCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceCnt.ForeColor = System.Drawing.Color.Lime
            Me.lblDeviceCnt.Location = New System.Drawing.Point(384, 136)
            Me.lblDeviceCnt.Name = "lblDeviceCnt"
            Me.lblDeviceCnt.Size = New System.Drawing.Size(96, 43)
            Me.lblDeviceCnt.TabIndex = 102
            Me.lblDeviceCnt.Text = "0"
            Me.lblDeviceCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(384, 120)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(96, 16)
            Me.Label4.TabIndex = 101
            Me.Label4.Text = "Box Count"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmProduceBERObsoleteUnits
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1008, 542)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelPalletList, Me.panelPallet, Me.btnCreatePalletID, Me.cboModels, Me.Label1})
            Me.Name = "frmProduceBERObsoleteUnits"
            Me.Text = "frmProduceBERObsoleteUnits"
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelPalletList.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelPallet.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region



    End Class
End Namespace