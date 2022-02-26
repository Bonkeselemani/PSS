Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.WingTechATT

    Public Class frmWingTechATT_REF2Seed
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _strScreenName As String = ""
        Private _strUserName As String = PSS.Core.Global.ApplicationUser.User
        Private _iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private _strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
        Private _objWingTechATT As PSS.Data.Buisness.WingTechATT.WingTechATT
        Private _objWingTechATT_REF2Seed As PSS.Data.Buisness.WingTechATT.WingTechATT_REF2Seed
        Private _objWingTechATT_Recv As PSS.Data.Buisness.WingTechATT.WingTechATT_Receiving
        Private _objWingTechATT_BoxShip As PSS.Data.Buisness.WingTechATT.WingTechATT_ProduceBox
        Private _objCoolPad_Receiving As PSS.Data.Buisness.CP.CoolPad_Receiving

        Private _dt As DataTable

        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCust_ID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCust_ID
            Me._strScreenName = strScreenName

            Me._objWingTechATT = New PSS.Data.Buisness.WingTechATT.WingTechATT()
            Me._objWingTechATT_REF2Seed = New PSS.Data.Buisness.WingTechATT.WingTechATT_REF2Seed()
            Me._objWingTechATT_Recv = New PSS.Data.Buisness.WingTechATT.WingTechATT_Receiving()
            Me._objWingTechATT_BoxShip = New PSS.Data.Buisness.WingTechATT.WingTechATT_ProduceBox()
            Me._objCoolPad_Receiving = New PSS.Data.Buisness.CP.CoolPad_Receiving()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objWingTechATT = Nothing
                    Me._objWingTechATT_REF2Seed = Nothing
                    Me._objWingTechATT_Recv = Nothing
                    Me._objWingTechATT_BoxShip = Nothing
                    Me._objCoolPad_Receiving = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents pnlCoolPadModel As System.Windows.Forms.Panel
        Friend WithEvents cboASN_In_Sku As C1.Win.C1List.C1Combo
        Friend WithEvents lbllblPSSModel As System.Windows.Forms.Label
        Friend WithEvents lblPSSModel As System.Windows.Forms.Label
        Friend WithEvents lblASN_In_Sku As System.Windows.Forms.Label
        Friend WithEvents btnMoveREF2Seed As System.Windows.Forms.Button
        Friend WithEvents btnLoadData As System.Windows.Forms.Button
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents lblRecNum As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWingTechATT_REF2Seed))
            Me.pnlCoolPadModel = New System.Windows.Forms.Panel()
            Me.cboASN_In_Sku = New C1.Win.C1List.C1Combo()
            Me.lbllblPSSModel = New System.Windows.Forms.Label()
            Me.lblPSSModel = New System.Windows.Forms.Label()
            Me.lblASN_In_Sku = New System.Windows.Forms.Label()
            Me.btnMoveREF2Seed = New System.Windows.Forms.Button()
            Me.btnLoadData = New System.Windows.Forms.Button()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.lblRecNum = New System.Windows.Forms.Label()
            Me.pnlCoolPadModel.SuspendLayout()
            CType(Me.cboASN_In_Sku, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pnlCoolPadModel
            '
            Me.pnlCoolPadModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboASN_In_Sku, Me.lbllblPSSModel, Me.lblPSSModel, Me.lblASN_In_Sku})
            Me.pnlCoolPadModel.Location = New System.Drawing.Point(368, 7)
            Me.pnlCoolPadModel.Name = "pnlCoolPadModel"
            Me.pnlCoolPadModel.Size = New System.Drawing.Size(384, 80)
            Me.pnlCoolPadModel.TabIndex = 197
            '
            'cboASN_In_Sku
            '
            Me.cboASN_In_Sku.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboASN_In_Sku.Caption = ""
            Me.cboASN_In_Sku.CaptionHeight = 17
            Me.cboASN_In_Sku.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboASN_In_Sku.ColumnCaptionHeight = 17
            Me.cboASN_In_Sku.ColumnFooterHeight = 17
            Me.cboASN_In_Sku.ContentHeight = 15
            Me.cboASN_In_Sku.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboASN_In_Sku.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboASN_In_Sku.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboASN_In_Sku.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboASN_In_Sku.EditorHeight = 15
            Me.cboASN_In_Sku.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboASN_In_Sku.ItemHeight = 15
            Me.cboASN_In_Sku.Location = New System.Drawing.Point(120, 16)
            Me.cboASN_In_Sku.MatchEntryTimeout = CType(2000, Long)
            Me.cboASN_In_Sku.MaxDropDownItems = CType(5, Short)
            Me.cboASN_In_Sku.MaxLength = 32767
            Me.cboASN_In_Sku.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboASN_In_Sku.Name = "cboASN_In_Sku"
            Me.cboASN_In_Sku.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboASN_In_Sku.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboASN_In_Sku.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboASN_In_Sku.Size = New System.Drawing.Size(240, 21)
            Me.cboASN_In_Sku.TabIndex = 182
            Me.cboASN_In_Sku.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lbllblPSSModel
            '
            Me.lbllblPSSModel.BackColor = System.Drawing.Color.Transparent
            Me.lbllblPSSModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblPSSModel.ForeColor = System.Drawing.Color.Black
            Me.lbllblPSSModel.Location = New System.Drawing.Point(24, 48)
            Me.lbllblPSSModel.Name = "lbllblPSSModel"
            Me.lbllblPSSModel.Size = New System.Drawing.Size(88, 21)
            Me.lbllblPSSModel.TabIndex = 184
            Me.lbllblPSSModel.Text = "PSS Model:"
            Me.lbllblPSSModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPSSModel
            '
            Me.lblPSSModel.BackColor = System.Drawing.Color.Transparent
            Me.lblPSSModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPSSModel.ForeColor = System.Drawing.Color.Black
            Me.lblPSSModel.Location = New System.Drawing.Point(120, 48)
            Me.lblPSSModel.Name = "lblPSSModel"
            Me.lblPSSModel.Size = New System.Drawing.Size(232, 21)
            Me.lblPSSModel.TabIndex = 185
            Me.lblPSSModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblASN_In_Sku
            '
            Me.lblASN_In_Sku.BackColor = System.Drawing.Color.Transparent
            Me.lblASN_In_Sku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblASN_In_Sku.ForeColor = System.Drawing.Color.Black
            Me.lblASN_In_Sku.Location = New System.Drawing.Point(16, 16)
            Me.lblASN_In_Sku.Name = "lblASN_In_Sku"
            Me.lblASN_In_Sku.Size = New System.Drawing.Size(96, 21)
            Me.lblASN_In_Sku.TabIndex = 183
            Me.lblASN_In_Sku.Text = "ASN-In-Sku:"
            Me.lblASN_In_Sku.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnMoveREF2Seed
            '
            Me.btnMoveREF2Seed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMoveREF2Seed.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnMoveREF2Seed.Location = New System.Drawing.Point(168, 111)
            Me.btnMoveREF2Seed.Name = "btnMoveREF2Seed"
            Me.btnMoveREF2Seed.Size = New System.Drawing.Size(232, 32)
            Me.btnMoveREF2Seed.TabIndex = 196
            Me.btnMoveREF2Seed.Text = "Move REF Devices to Seedstock"
            '
            'btnLoadData
            '
            Me.btnLoadData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoadData.ForeColor = System.Drawing.Color.Green
            Me.btnLoadData.Location = New System.Drawing.Point(48, 111)
            Me.btnLoadData.Name = "btnLoadData"
            Me.btnLoadData.Size = New System.Drawing.Size(112, 32)
            Me.btnLoadData.TabIndex = 195
            Me.btnLoadData.Text = "Load Data"
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.Transparent
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(56, 79)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(56, 21)
            Me.lblModel.TabIndex = 194
            Me.lblModel.Text = "Model:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(120, 79)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(240, 21)
            Me.cboModel.TabIndex = 193
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'tdgData1
            '
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.CaptionHeight = 17
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(48, 151)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(800, 536)
            Me.tdgData1.TabIndex = 192
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
            "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
            "ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>534</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 798, 534</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 798, 534</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
            " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.Black
            Me.lblCustomer.Location = New System.Drawing.Point(40, 23)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(72, 21)
            Me.lblCustomer.TabIndex = 191
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(120, 23)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(5, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(240, 21)
            Me.cboCustomer.TabIndex = 190
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
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(40, 47)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation.TabIndex = 189
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation
            '
            Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocation.Caption = ""
            Me.cboLocation.CaptionHeight = 17
            Me.cboLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocation.ColumnCaptionHeight = 17
            Me.cboLocation.ColumnFooterHeight = 17
            Me.cboLocation.ContentHeight = 15
            Me.cboLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocation.EditorHeight = 15
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(120, 47)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboLocation.TabIndex = 188
            Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblRecNum
            '
            Me.lblRecNum.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNum.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecNum.Location = New System.Drawing.Point(48, 687)
            Me.lblRecNum.Name = "lblRecNum"
            Me.lblRecNum.Size = New System.Drawing.Size(224, 24)
            Me.lblRecNum.TabIndex = 198
            Me.lblRecNum.Text = "0"
            '
            'frmWingTechATT_REF2Seed
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(888, 718)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlCoolPadModel, Me.btnMoveREF2Seed, Me.btnLoadData, Me.lblModel, Me.cboModel, Me.tdgData1, Me.lblCustomer, Me.cboCustomer, Me.lblLocation, Me.cboLocation, Me.lblRecNum})
            Me.Name = "frmWingTechATT_REF2Seed"
            Me.Text = "frmWingTechATT_REF2Seed"
            Me.pnlCoolPadModel.ResumeLayout(False)
            CType(Me.cboASN_In_Sku, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWingTechATT_REF2Seed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dtModel As DataTable
            Dim dtLoc As DataTable
            Dim dt As DataTable
            Dim dtSKU As DataTable
            Dim iLoc_ID As Integer = 0

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.lblModel.Visible = False : Me.cboModel.Visible = False
                Me.pnlCoolPadModel.Visible = False
                Me.btnMoveREF2Seed.Enabled = False
                Me.tdgData1.Visible = False
                Me.lblRecNum.Text = ""

                'Populate customer
                dt = Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = Me._iMenuCustID
                If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False

                If Me._iMenuCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                    Me.lblModel.Visible = True : Me.cboModel.Visible = True

                    'Loc info
                    dtLoc = Me._objWingTechATT_BoxShip.GetWingTechATTLocations(Me._iMenuCustID, True)
                    Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
                    If dtLoc.Rows.Count = 2 Then
                        iLoc_ID = dtLoc.Rows(0).Item("Loc_ID")
                        Me.cboLocation.SelectedValue = iLoc_ID
                    Else
                        Me.cboLocation.SelectedValue = 0
                    End If

                    'Model
                    dtModel = Me._objWingTechATT.getWingTechATTModels(Me._iMenuCustID, True)
                    Misc.PopulateC1DropDownList(Me.cboModel, dtModel, "Model_Desc", "Model_ID")
                    Me.cboModel.SelectedValue = 0

                

                Else
                    MessageBox.Show("Undefined customer for this screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub cboLocation_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.SelectedValueChanged
            Dim dtModel As DataTable

            Try
                If Me._iMenuCustID <> PSS.Data.Buisness.CP.CoolPad.CoolPad_CUSTOMER_ID Then Exit Sub

                If Me.cboLocation.SelectedValue > 0 Then
                    dtModel = Me._objCoolPad_Receiving.getModelData(PSS.Data.Buisness.CP.CoolPad.CoolPad_Product_ID, Me._iMenuCustID, Me.cboLocation.SelectedValue)

                    Misc.PopulateC1DropDownList(Me.cboASN_In_Sku, dtModel, "ASN_IN_SKU", "Model_ID")
                    'Me.cboASN_In_Sku.SelectedIndex = 0
                Else
                    MessageBox.Show("Please selet a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboLocation_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub

        Private Sub cboASN_In_Sku_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboASN_In_Sku.SelectedValueChanged
            Try

                If Me.cboASN_In_Sku.SelectedValue > 0 Then
                    Me.lblPSSModel.Text = Me.cboASN_In_Sku.DataSource.Table.Select("Model_ID = " & Me.cboASN_In_Sku.SelectedValue)(0)("Model_Desc")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboASN_In_Sku_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub

        Private Sub BindGridData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Try
                Me.tdgData1.DataSource = dt.DefaultView

                With Me.tdgData1
                    .DataSource = dt.DefaultView
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc

                    .Splits(0).DisplayColumns("BillCode_IDs").Width = 50
                    .Splits(0).DisplayColumns("BillCodes").Width = 50
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnLoadData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadData.Click
            Dim dt As DataTable

            Try
                Me.tdgData1.Visible = False : Me.btnMoveREF2Seed.Enabled = False

                If Me._iMenuCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                    Me._dt = Me._objWingTechATT_REF2Seed.GetREF2SeedstockData(Me._iMenuCustID, Me.cboLocation.SelectedValue, Me.cboModel.SelectedValue)
                Else
                    Exit Sub
                End If

                If Not Me._dt.Rows.Count > 0 Then MessageBox.Show("No data for your selection.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                Me.BindGridData(Me._dt)

                Me.tdgData1.Visible = True : Me.btnMoveREF2Seed.Enabled = True
                Me.lblRecNum.Text = "Count: " & Me._dt.Rows.Count


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLoadData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnMoveREF2Seed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMoveREF2Seed.Click

            Dim iRow As Integer = 0
            Dim iValidRecNum As Integer = 0

            Dim strDevice_IDs As String = ""
            Dim strDevice_SNs As String = ""
            Dim iLoc_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim strMsg As String = ""

            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "WingTechATT REF2Seed Receiving"
            Dim strRecvMsg As String = ""
            Dim strDTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iWB_ID As Integer = 0
            Dim iEW_ID As Integer = 0
            Dim iWrtyFlag As Integer = 0 ' seedstocl always In-Wrranty
            Dim strRecvBoxName As String = ""
            Dim bReceived As Boolean = False
            Dim iDevice_ID As Integer = 0
            Dim strSN As String = ""
            Dim strManufDate As String = ""

            Dim dt As DataTable
            Dim row As DataRow

            Try
                If Not Me.tdgData1.RowCount > 0 Then Exit Sub

                If Not Me.tdgData1.SelectedRows.Count > 0 Then MessageBox.Show("Please select a row or rows.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

                'Rec_Num, Location, Device_SN, Model, Bill_Date, Recv_Date, Recv_Box, PO, In_Pallet_ID, 
                'BillCode_IDs, BillCodes, Dup_SN, Loc_ID, Cust_ID, EW_ID, Device_ID, Model_ID, wb_ID, BulkOrderType_ID
                With Me.tdgData1
                    For Each iRow In .SelectedRows
                        If IsDBNull(.Columns("Device_ID").CellText(iRow)) OrElse .Columns("Device_ID").CellText(iRow).ToString.Trim.Length = 0 Then
                            MessageBox.Show("No device_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If Not Me._objWingTechATT_REF2Seed.IsAlreadyUnusedSeedstockDevice(Me._iMenuCustID, .Columns("SN").CellText(iRow).ToString.Trim) Then
                                If strDevice_IDs.Trim.Length = 0 Then
                                    strDevice_IDs = .Columns("Device_ID").CellText(iRow).ToString.Trim
                                    strDevice_SNs = "'" & .Columns("SN").CellText(iRow).ToString.Trim & "'"
                                    iLoc_ID = .Columns("Loc_ID").CellText(iRow).ToString.Trim
                                    iModel_ID = .Columns("Model_ID").CellText(iRow).ToString.Trim
                                Else
                                    strDevice_IDs &= "," & .Columns("Device_ID").CellText(iRow).ToString.Trim
                                    strDevice_SNs &= ",'" & .Columns("SN").CellText(iRow).ToString.Trim & "'"
                                End If
                                iValidRecNum += 1
                            Else
                                If strMsg.Trim.Length = 0 Then
                                    strMsg = "Can't move unused seedstock device(s): " & .Columns("SN").CellText(iRow).ToString.Trim
                                Else
                                    strMsg &= ", " & .Columns("SN").CellText(iRow).ToString.Trim
                                End If
                            End If
                        End If
                    Next
                End With

                If strMsg.Trim.Length > 0 Then strMsg &= Environment.NewLine

                If strDevice_IDs.Trim.Length > 0 Then
                    'getWorkOrderID
                    iWO_ID = Me._objWingTechATT_REF2Seed.GetWorkOrderID(Me._iMenuCustID, iLoc_ID)

                    If Not iWO_ID > 0 Then MessageBox.Show("Invalid WO_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub

                    dt = Me._objWingTechATT_REF2Seed.ProcessREF2Seedstock(Me._iMenuCustID, iLoc_ID, iWO_ID, strDevice_IDs, strDevice_SNs)

                    If Not dt.Rows.Count = iValidRecNum Then MessageBox.Show("Invalid data processed. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub

                    iTray_ID = Me._objWingTechATT_Recv.getTayID(Me._iUserID, Me._strUser, iWO_ID, strTrayMemo)
                    strRecvBoxName = Me._objCoolPad_Receiving.CreateWarehouseBoxName(iModel_ID, iWrtyFlag, iWB_ID, "WK")

                    For Each row In dt.Rows
                        strSN = row("SerialNo") : iEW_ID = row("EW_ID")
                        strManufDate = Me._objWingTechATT_REF2Seed.GetManufDate(strSN, strDevice_IDs)

                        If Me._iMenuCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_CUSTOMER_ID Then
                            bReceived = Me._objWingTechATT_Recv.ReceiveDataIntoSystem(iLoc_ID, iWO_ID, iModel_ID, strSN, strManufDate, _
                                                                               strDTime, strWorkDate, iEW_ID, iShift_ID, iTray_ID, _
                                                                               iDevice_ID, iWB_ID, iWrtyFlag, True)

                        End If

                        If Not bReceived Then
                            If strMsg.Trim.Length = 0 Then
                                strMsg = "Failed to receive " & strSN
                            Else
                                strMsg &= ", " & strSN
                            End If
                        End If
                    Next

                    Me.tdgData1.Visible = False : Me.tdgData1.DataSource = Nothing : Me.btnLoadData.Focus()
                End If

                If strMsg.Trim.Length > 0 Then MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnMoveREF2Seed_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


    End Class
End Namespace