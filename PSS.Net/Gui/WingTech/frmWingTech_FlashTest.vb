Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.WingTech
    Public Class frmWingTech_FlashTest
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _objRfFlahTests As PSS.Data.Buisness.WingTech.WingTech_RfFlashTests
        Private _iDevice_ID As Integer = 0
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
        Private _iWCLocation_ID As Integer = 0
        Private _iGrpLineMap_ID As Integer = 0
        Private _iRFResult As Integer = 0
        Private _strGroup As String
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._objRfFlahTests = New PSS.Data.Buisness.WingTech.WingTech_RfFlashTests()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objRfFlahTests = Nothing
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
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents grdHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents lblWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents lblDevRepType As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblMainInputName As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblCostCenterDesc As System.Windows.Forms.Label
        Friend WithEvents btnPass As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblPretestTotal As System.Windows.Forms.Label
        Friend WithEvents lblTotalFailed As System.Windows.Forms.Label
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents lblWorkDate As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents lblMachine As System.Windows.Forms.Label
        Friend WithEvents lblLineSide As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents lblTotalPassed As System.Windows.Forms.Label
        Friend WithEvents btnFail As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWingTech_FlashTest))
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.lblWrtyStatus = New System.Windows.Forms.Label()
            Me.lblDevRepType = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblMainInputName = New System.Windows.Forms.Label()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblCostCenterDesc = New System.Windows.Forms.Label()
            Me.btnPass = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblPretestTotal = New System.Windows.Forms.Label()
            Me.lblTotalFailed = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.lblWorkDate = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.lblMachine = New System.Windows.Forms.Label()
            Me.lblLineSide = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.lblTotalPassed = New System.Windows.Forms.Label()
            Me.btnFail = New System.Windows.Forms.Button()
            Me.Panel3.SuspendLayout()
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblDateCode
            '
            Me.lblDateCode.BackColor = System.Drawing.Color.Black
            Me.lblDateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDateCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateCode.ForeColor = System.Drawing.Color.Lime
            Me.lblDateCode.Location = New System.Drawing.Point(688, 152)
            Me.lblDateCode.Name = "lblDateCode"
            Me.lblDateCode.Size = New System.Drawing.Size(104, 32)
            Me.lblDateCode.TabIndex = 145
            Me.lblDateCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblDateCode.Visible = False
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdHistory, Me.Label8, Me.lblSN})
            Me.Panel3.Location = New System.Drawing.Point(0, 184)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(799, 432)
            Me.Panel3.TabIndex = 141
            '
            'grdHistory
            '
            Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
            'Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdHistory.Location = New System.Drawing.Point(7, 37)
            Me.grdHistory.Name = "grdHistory"
            Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdHistory.PreviewInfo.ZoomFactor = 75
            Me.grdHistory.Size = New System.Drawing.Size(777, 141)
            Me.grdHistory.TabIndex = 14
            Me.grdHistory.Text = "C1TrueDBGrid1"
            Me.grdHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
            "5{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Contr" & _
            "olText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style" & _
            "13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""2" & _
            "4"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" M" & _
            "arqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vert" & _
            "icalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>137</Height><CaptionStyle " & _
            "parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenR" & _
            "owStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""St" & _
            "yle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" m" & _
            "e=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pa" & _
            "rent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /" & _
            "><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordS" & _
            "elector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pa" & _
            "rent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 773, 137</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 773, 137</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(4, 7)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(137, 19)
            Me.Label8.TabIndex = 74
            Me.Label8.Text = "FLASH History for "
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Red
            Me.lblSN.Location = New System.Drawing.Point(150, 7)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(218, 19)
            Me.lblSN.TabIndex = 76
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWrtyStatus
            '
            Me.lblWrtyStatus.BackColor = System.Drawing.Color.Black
            Me.lblWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWrtyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyStatus.ForeColor = System.Drawing.Color.Lime
            Me.lblWrtyStatus.Location = New System.Drawing.Point(504, 152)
            Me.lblWrtyStatus.Name = "lblWrtyStatus"
            Me.lblWrtyStatus.Size = New System.Drawing.Size(168, 32)
            Me.lblWrtyStatus.TabIndex = 144
            Me.lblWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblWrtyStatus.Visible = False
            '
            'lblDevRepType
            '
            Me.lblDevRepType.BackColor = System.Drawing.Color.Black
            Me.lblDevRepType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDevRepType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevRepType.ForeColor = System.Drawing.Color.Lime
            Me.lblDevRepType.Location = New System.Drawing.Point(336, 152)
            Me.lblDevRepType.Name = "lblDevRepType"
            Me.lblDevRepType.Size = New System.Drawing.Size(152, 32)
            Me.lblDevRepType.TabIndex = 146
            Me.lblDevRepType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblDevRepType.Visible = False
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(688, 80)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(104, 63)
            Me.btnClear.TabIndex = 138
            Me.btnClear.Text = "CLEAR     (ESC)"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProduct, Me.cboCustomers, Me.Label1, Me.lblMainInputName, Me.txtDeviceSN, Me.Label2, Me.lblCostCenterDesc})
            Me.Panel1.Location = New System.Drawing.Point(0, 72)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(335, 113)
            Me.Panel1.TabIndex = 135
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
            Me.cboProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(104, 56)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(5, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(224, 21)
            Me.cboProduct.TabIndex = 2
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
            "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
            "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
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
            Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(104, 28)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(224, 21)
            Me.cboCustomers.TabIndex = 1
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
            " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
            "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
            "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
            "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
            "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
            "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
            "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
            "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
            "idth></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(0, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 16)
            Me.Label1.TabIndex = 123
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMainInputName
            '
            Me.lblMainInputName.BackColor = System.Drawing.Color.Transparent
            Me.lblMainInputName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMainInputName.ForeColor = System.Drawing.Color.Black
            Me.lblMainInputName.Location = New System.Drawing.Point(0, 84)
            Me.lblMainInputName.Name = "lblMainInputName"
            Me.lblMainInputName.Size = New System.Drawing.Size(93, 19)
            Me.lblMainInputName.TabIndex = 114
            Me.lblMainInputName.Text = "Device SN:"
            Me.lblMainInputName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BackColor = System.Drawing.Color.Khaki
            Me.txtDeviceSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSN.Location = New System.Drawing.Point(104, 84)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(224, 20)
            Me.txtDeviceSN.TabIndex = 0
            Me.txtDeviceSN.Tag = ""
            Me.txtDeviceSN.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(0, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 16)
            Me.Label2.TabIndex = 122
            Me.Label2.Text = "Product Type:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCostCenterDesc
            '
            Me.lblCostCenterDesc.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenterDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCostCenterDesc.ForeColor = System.Drawing.Color.Blue
            Me.lblCostCenterDesc.Location = New System.Drawing.Point(8, 2)
            Me.lblCostCenterDesc.Name = "lblCostCenterDesc"
            Me.lblCostCenterDesc.Size = New System.Drawing.Size(320, 22)
            Me.lblCostCenterDesc.TabIndex = 122
            Me.lblCostCenterDesc.Text = "Cost Center H"
            Me.lblCostCenterDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnPass
            '
            Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPass.ForeColor = System.Drawing.Color.White
            Me.btnPass.Location = New System.Drawing.Point(336, 80)
            Me.btnPass.Name = "btnPass"
            Me.btnPass.Size = New System.Drawing.Size(152, 63)
            Me.btnPass.TabIndex = 136
            Me.btnPass.Tag = "2515"
            Me.btnPass.Text = "PASS      (F9)"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Black
            Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Yellow
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(159, 71)
            Me.Label3.TabIndex = 142
            Me.Label3.Text = "FLASH"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPretestTotal, Me.lblTotalFailed, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.Button2, Me.lblTotalPassed})
            Me.Panel2.Location = New System.Drawing.Point(152, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(640, 71)
            Me.Panel2.TabIndex = 143
            '
            'lblPretestTotal
            '
            Me.lblPretestTotal.BackColor = System.Drawing.Color.Black
            Me.lblPretestTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPretestTotal.ForeColor = System.Drawing.Color.Lime
            Me.lblPretestTotal.Location = New System.Drawing.Point(408, 41)
            Me.lblPretestTotal.Name = "lblPretestTotal"
            Me.lblPretestTotal.Size = New System.Drawing.Size(224, 19)
            Me.lblPretestTotal.TabIndex = 102
            Me.lblPretestTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTotalFailed
            '
            Me.lblTotalFailed.BackColor = System.Drawing.Color.Black
            Me.lblTotalFailed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalFailed.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalFailed.Location = New System.Drawing.Point(408, 24)
            Me.lblTotalFailed.Name = "lblTotalFailed"
            Me.lblTotalFailed.Size = New System.Drawing.Size(224, 18)
            Me.lblTotalFailed.TabIndex = 101
            Me.lblTotalFailed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.Lime
            Me.lblUserName.Location = New System.Drawing.Point(208, 6)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(190, 19)
            Me.lblUserName.TabIndex = 100
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWorkDate
            '
            Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
            Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
            Me.lblWorkDate.Location = New System.Drawing.Point(208, 24)
            Me.lblWorkDate.Name = "lblWorkDate"
            Me.lblWorkDate.Size = New System.Drawing.Size(190, 18)
            Me.lblWorkDate.TabIndex = 99
            Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.Lime
            Me.lblShift.Location = New System.Drawing.Point(208, 41)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(190, 19)
            Me.lblShift.TabIndex = 98
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMachine
            '
            Me.lblMachine.BackColor = System.Drawing.Color.Transparent
            Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachine.ForeColor = System.Drawing.Color.Lime
            Me.lblMachine.Location = New System.Drawing.Point(3, 41)
            Me.lblMachine.Name = "lblMachine"
            Me.lblMachine.Size = New System.Drawing.Size(191, 19)
            Me.lblMachine.TabIndex = 97
            Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLineSide
            '
            Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
            Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
            Me.lblLineSide.Location = New System.Drawing.Point(59, 24)
            Me.lblLineSide.Name = "lblLineSide"
            Me.lblLineSide.Size = New System.Drawing.Size(65, 18)
            Me.lblLineSide.TabIndex = 96
            Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Lime
            Me.lblGroup.Location = New System.Drawing.Point(3, 6)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(191, 19)
            Me.lblGroup.TabIndex = 95
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLine
            '
            Me.lblLine.BackColor = System.Drawing.Color.Transparent
            Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLine.ForeColor = System.Drawing.Color.Lime
            Me.lblLine.Location = New System.Drawing.Point(3, 24)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(66, 18)
            Me.lblLine.TabIndex = 94
            Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(168, 286)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(234, 37)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'lblTotalPassed
            '
            Me.lblTotalPassed.BackColor = System.Drawing.Color.Black
            Me.lblTotalPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalPassed.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalPassed.Location = New System.Drawing.Point(408, 6)
            Me.lblTotalPassed.Name = "lblTotalPassed"
            Me.lblTotalPassed.Size = New System.Drawing.Size(224, 19)
            Me.lblTotalPassed.TabIndex = 84
            Me.lblTotalPassed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnFail
            '
            Me.btnFail.BackColor = System.Drawing.Color.Red
            Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFail.ForeColor = System.Drawing.Color.White
            Me.btnFail.Location = New System.Drawing.Point(504, 80)
            Me.btnFail.Name = "btnFail"
            Me.btnFail.Size = New System.Drawing.Size(168, 63)
            Me.btnFail.TabIndex = 137
            Me.btnFail.Text = "FAIL(F12)"
            '
            'frmWingTech_FlashTest
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(800, 606)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDateCode, Me.Panel3, Me.lblWrtyStatus, Me.lblDevRepType, Me.btnClear, Me.Panel1, Me.btnPass, Me.Label3, Me.Panel2, Me.btnFail})
            Me.Name = "frmWingTech_FlashTest"
            Me.Text = "frmWingTech_FlashTest"
            Me.Panel3.ResumeLayout(False)
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWingTech_FlashTest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim i As Integer = 0
            Dim iCustID As Integer = 0
            Dim dt As DataTable
            Dim objPreTest As New PSS.Data.Buisness.PreTest()

            Try
                i = CheckIfMachineTiedToLine()

                If i = 0 Then
                    MessageBox.Show("Machine is not associated with any 'Line'. Can't continue.", "Check Machine Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If

                '****************************************
                'Load Customer
                '***************************************
                iCustID = Generic.GetCustIDByMachine()
                Me.cboCustomers.DataSource = Nothing
                dt = Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = iCustID
                Me.cboCustomers.Enabled = False
                '********************
                'Load Product type
                '********************
                If Generic.GetCustIDByMachine = _iCust_ID Then
                    GoTo loadproduct
                ElseIf Generic.GetCustIDByMachine() = _iCust_ID Then
                    GoTo loadproduct
                ElseIf Generic.GetCustIDByMachine() = _iCust_ID Then
                    GoTo loadproduct
                Else
                    MessageBox.Show("Please select PRETEST submenu from " & _strGroup.ToUpper & "  Menu ", "Check " & _strGroup.ToUpper & "Menu", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.Enabled = False
                    Exit Sub
                End If
loadproduct:    dt = Generic.GetProductByCustID(True, Me._iCust_ID)
                Me.cboProduct.DataSource = Nothing
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboProduct.SelectedValue = dt.Rows(0)("Prod_ID")
                    Me.cboProduct.Enabled = False
                End If

                '***************************
                'Define Fail code datatable
                '***************************

                'Me.Label3.Text = _strScreenName
                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in FormLoad")
            Finally
                objPreTest = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub AllControlsKeyupEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProduct.KeyUp, grdHistory.KeyUp, btnPass.KeyUp, btnFail.KeyUp, btnClear.KeyUp, txtDeviceSN.KeyUp
            If e.KeyValue = 13 AndAlso sender.name = "txtDeviceSN" Then
                Me.ProcessSN()
            ElseIf e.KeyValue = Keys.Escape Then
                Me.Clear(False)
                Me.txtDeviceSN.Focus()
            ElseIf Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.Focus()
            ElseIf e.KeyValue = Keys.F9 Then    'Pass
                PassTest()
            ElseIf e.KeyValue = Keys.F12 Then   'Fail
                FailTest()
            End If

        End Sub

        Private Sub ProcessSN()
            Dim objQC As New PSS.Data.Buisness.QC()
            Dim strSN As String = ""
            Dim strDevice_ccDesc As String = ""
            Dim dt1 As DataTable
            Dim strWorkStation As String = ""
            Dim iLoc_id As Integer
            Try
                strSN = Me.txtDeviceSN.Text.Trim
                If Me.txtDeviceSN.Text.Trim.Length = 0 Then
                    Exit Sub
                End If

                If Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.cboCustomers.Focus()
                    Exit Sub
                End If

                Me.Clear(False)

                If Me.cboProduct.SelectedValue = 0 Then
                    MessageBox.Show("Please select Product.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                ElseIf Me._iGrpLineMap_ID = 0 Or Me._iWCLocation_ID = 0 Then
                    MessageBox.Show("Group ID missing. This machine is not mapped to any Group.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                End If

                'Check if this device is actually of the product type selected.
                If Me.cboProduct.SelectedValue <> objQC.GetDeviceProductType(strSN, Me.cboCustomers.SelectedValue) Then
                    MessageBox.Show("The device scanned in is not of the Product type selected on the screen.", "RF", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtDeviceSN.Text = strSN
                    Exit Sub
                End If

                ' SKIP FOR WIKO SPECIAL project 
                dt1 = Generic.GetDeviceInfoInWIP(strSN, Me.cboCustomers.SelectedValue)
                If dt1.Rows.Count = 1 Then
                    iLoc_id = dt1.Rows(0)("Loc_id")
                End If
                If Not iLoc_id = PSS.Data.Buisness.WIKO.WIKO.WIKO_Special_LOC_ID Then
                    ' Check FQA Result FOR WIKO AND WINGTECH 
                    If _iCust_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Or _iCust_ID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID Then
                        Dim dtFQA As New DataTable()
                        dtFQA = Me._objRfFlahTests.GetDeviceFqaData(strSN)
                        If Not dtFQA.Rows.Count > 0 Then
                            MessageBox.Show("The device has no FQA test data. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDeviceSN.SelectAll()
                            Exit Sub
                        ElseIf dtFQA.Rows(0).IsNull("QCResult_ID") OrElse Not dtFQA.Rows(0).Item("QCResult_ID") = 1 Then
                            MessageBox.Show("The device didn't pass FQA test. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDeviceSN.SelectAll()
                            Exit Sub
                        End If
                    End If
                    'check for RF TEST 
                    If _iCust_ID = PSS.Data.Buisness.WIKO.WIKO.WIKO_CUSTOMER_ID Or _iCust_ID = PSS.Data.Buisness.WingTech.WingTech.WingTech_CUSTOMER_ID Then
                        Dim dtRF As New DataTable()
                        dtRF = Me._objRfFlahTests.GetDeviceRFData(strSN)
                        If dtRF.Rows.Count = 0 Then
                            MessageBox.Show("The device has no RF test data or failed .Can't Flash it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDeviceSN.SelectAll()
                            Exit Sub
                        End If
                    End If
                End If

                '******************************************
                'Get Device info and model type(Wip down/Non-WipeDown)
                ''******************************************
                dt1 = Generic.GetDeviceInfoInWIP(strSN, Me.cboCustomers.SelectedValue)
                If dt1.Rows.Count = 1 Then
                    If dt1.Rows(0)("ManufDate").ToString.Trim.Length > 0 Then
                        Me.lblWrtyStatus.Visible = True
                        Me.lblDateCode.Visible = True
                        Me.lblDateCode.Text = dt1.Rows(0)("ManufDate")
                        If dt1.Rows(0)("Device_ManufWrty") Then Me.lblWrtyStatus.Text = "In Warranty" Else Me.lblWrtyStatus.Text = "Out of Warranty"
                    End If
                    '****************************************************************
                    Me._iDevice_ID = dt1.Rows(0)("Device_ID")
                    lblSN.Text = strSN
                    Me.LoadTestHistory(Me._iDevice_ID)

                ElseIf dt1.Rows.Count = 0 Then
                    MessageBox.Show("Can't define Device SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    MessageBox.Show("Device exist more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in ProcessSN")
                Me.Clear(False)
            Finally
                objQC = Nothing
            End Try
        End Sub

        Private Sub Clear(ByVal booKeepDeviceInfoData As Boolean)
            Me.txtDeviceSN.Text = ""
            Me.btnPass.BackColor = Color.SteelBlue
            Me.btnFail.BackColor = Color.SteelBlue
            Me.btnClear.BackColor = Color.SteelBlue

            If booKeepDeviceInfoData = False Then
                Me.lblSN.Text = ""
                Me.lblDateCode.Text = ""
                Me.lblWrtyStatus.Text = ""
                Me.lblDevRepType.Text = ""
                Me.lblDateCode.Visible = False
                Me.lblWrtyStatus.Visible = False
                Me.lblDevRepType.Visible = False
                Me.grdHistory.DataSource = Nothing
            End If


        End Sub

        Private Function CheckIfMachineTiedToLine() As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try
                dt1 = objMisc.CheckIfMachineTiedToLine(System.Net.Dns.GetHostName)
                If dt1.Rows.Count = 0 Then
                    Return 0
                End If

                'Me.lblGroup.Text = "Group: " & dt1.Rows(0)("Group_Desc")
                'Me.lblGroup.Tag = dt1.Rows(0)("Group_ID")
                Me.lblGroup.Text = "Group: " & dt1.Rows(0)("CC_Group_Desc")
                _strGroup = dt1.Rows(0)("CC_Group_Desc")
                Me.lblGroup.Tag = dt1.Rows(0)("CC_Group_ID")
                Me.lblLine.Text = dt1.Rows(0)("Line_Number")
                Me.lblLine.Tag = dt1.Rows(0)("Line_ID")
                Me.lblLineSide.Text = dt1.Rows(0)("LineSide_Desc")
                Me._iWCLocation_ID = dt1.Rows(0)("WCLocation_ID")
                Me._iGrpLineMap_ID = dt1.Rows(0)("GrpLineMap_ID")
                Me.lblMachine.Text = "Machine: " & System.Net.Dns.GetHostName
                Me.lblUserName.Text = "User: " & PSS.Core.Global.ApplicationUser.User
                Me.lblUserName.Tag = PSS.Core.Global.ApplicationUser.IDuser
                Me.lblShift.Text = "Shift: " & PSS.Core.Global.ApplicationUser.IDShift
                Me.lblWorkDate.Tag = PSS.Core.Global.ApplicationUser.Workdate
                Me.lblWorkDate.Text = "Work Date: " & Format(CDate(Me.lblWorkDate.Tag), "MM/dd/yyyy")
                Me.lblCostCenterDesc.Text = "Cost Center " & dt1.Rows(0)("CostCenter")
                'Me._icc_id = dt1.Rows(0)("cc_id")

                If dt1.Rows(0)("Group_ID") = 0 Then
                    MessageBox.Show("Machine does not map to any group, line and side.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf dt1.Rows(0)("CC_Group_ID") = 0 Then
                    MessageBox.Show("Machine does not map to any cost center.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf dt1.Rows(0)("Group_ID") <> dt1.Rows(0)("CC_Group_ID") Then
                    MessageBox.Show("Group of line and group of cost center are not the same. Please correct the mapping.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                        MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                    Else
                        MainWin.MainWin.wrkArea.TabPages.Clear()
                    End If
                ElseIf Me._iCust_ID > 0 AndAlso Not IsDBNull(dt1.Rows(0)("CCG_CustID")) Then
                    If Me._iCust_ID <> dt1.Rows(0)("CCG_CustID") Then
                        MessageBox.Show("This screen is not designed to work for the current mapped group.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        If MainWin.MainWin.wrkArea.TabPages.Count > 0 Then
                            MainWin.MainWin.wrkArea.TabPages.RemoveAt(MainWin.MainWin.wrkArea.SelectedIndex)
                        Else
                            MainWin.MainWin.wrkArea.TabPages.Clear()
                        End If
                    End If
                End If

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                objMisc = Nothing
            End Try
        End Function

        Private Sub LoadTestHistory(ByVal iDevice_ID As Integer)
            Dim dt1 As New DataTable()
            Dim i As Integer
            Dim R1 As DataRow
            Dim strTestType As String
            Dim strSN As String
            Try
                '**********************************************
                'Get history data and populate data to controls and variable
                '**********************************************
                strSN = lblSN.Text.Trim
                strTestType = "Flash"
                dt1 = Me._objRfFlahTests.GetTestData(strSN, strTestType)
                'If dt1.Rows.Count > 0 Then
                Me.grdHistory.DataSource = Nothing
                Me.grdHistory.DataSource = dt1
                'End If


            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub
        Private Sub SetHistoryGridLayout(ByRef grdCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
                                            ByVal clrHeaderForeColor As Color, _
                                            ByVal iArrColSize() As Integer, _
                                            ByVal iHeaderAlignment As Integer, _
                                            ByVal iArrColAlignment() As Integer, _
                                            ByVal strArrHideCol() As String, _
                                            Optional ByVal iGrandTotal As Integer = 0)
            Dim iNumOfColumns As Integer = grdCtrl.Columns.Count
            Dim i As Integer

            With grdCtrl
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To iArrColSize.Length - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iArrColAlignment(i) 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Width = iArrColSize(i)
                Next i
                For i = 0 To strArrHideCol.Length - 1
                    .Splits(0).DisplayColumns(strArrHideCol(i)).Visible = False
                Next i
            End With
        End Sub

        Private Sub btnPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click
            Me.PassTest()
        End Sub
        Private Sub PassTest()
            Dim dt As New DataTable()
            Dim strSN As String = String.Empty
            Dim strRFResult As String
            If Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.SelectAll()
                Me.txtDeviceSN.Focus()
                Exit Sub
            End If
            Me._iRFResult = 1
            btnPass.BackColor = System.Drawing.Color.Red
            btnFail.BackColor = System.Drawing.Color.SteelBlue
            strSN = lblSN.Text.Trim
            'check if there ii Record fir RF Test 
                strRFResult = "Pass"
            If Me._objRfFlahTests.checkFLashResult(strSN, strRFResult) = 0 Then
                SaveTestInfoWingTech()
            Else
                MsgBox("The Device has been successfully scanned and Passed", MsgBoxStyle.Information, "RF TEST RESULT")
                lblSN.Text = ""
                Me.grdHistory.DataSource = Nothing

            End If
        End Sub
        Private Sub btnFail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFail.Click
            Me.FailTest()
        End Sub

        Private Sub FailTest()
            Dim strSN As String
            Dim strRFResultPass, strRFResultFail As String
            If Me._iDevice_ID = 0 Then
                Me.txtDeviceSN.SelectAll()
                Me.txtDeviceSN.Focus()
                Exit Sub
            End If
            Me._iRFResult = 2
            btnPass.BackColor = System.Drawing.Color.SteelBlue
            btnFail.BackColor = System.Drawing.Color.Red

            strSN = lblSN.Text.Trim
            'check if there ii Record fir RF Test 
                strRFResultPass = "Pass"
                strRFResultFail = "Fail"
            If Me._objRfFlahTests.checkFLashResult(strSN, strRFResultPass) = 0 Then
                If Me._objRfFlahTests.checkFLashResult(strSN, strRFResultFail) = 0 Then
                    SaveTestInfoWingTech()
                Else
                    MsgBox("The Device has been successfully scanned and Failed", MsgBoxStyle.Information, "RF TEST RESULT")
                    lblSN.Text = ""
                    Me.grdHistory.DataSource = Nothing
                End If
            Else
                MsgBox("The Device has been successfully scannedand Passed", MsgBoxStyle.Information, "RF TEST RESULT")
                lblSN.Text = ""
                Me.grdHistory.DataSource = Nothing
            End If

        End Sub


        Private Sub SaveTestInfoWingTech()
            Dim strSN As String
            strSN = Me.lblSN.Text.Trim
            Try
                If Me.cboProduct.SelectedValue = 0 Then
                    MsgBox("Please select product.", MsgBoxStyle.Critical, "Load Pretest Codes")
                ElseIf Me._iDevice_ID = 0 Then
                    MsgBox("You must enter a device serial number.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.txtDeviceSN.Focus()
                Else

                    If Me._iRFResult <> 0 Then
                        If Me._objRfFlahTests.InsertRFlashWingTech(PSS.Core.Global.ApplicationUser.IDuser, strSN, _iRFResult) Then
                            Me.LoadTestHistory(Me._iDevice_ID)
                        Else
                        End If
                        Me.txtDeviceSN.SelectAll()


                    Else
                        MsgBox("Please select either pass or fail.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    End If
                End If
                Me.txtDeviceSN.Focus()
            Catch
            End Try
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Try
                Me.Clear(False)
                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error in btnClear_Click")
            End Try
        End Sub
    End Class
End Namespace