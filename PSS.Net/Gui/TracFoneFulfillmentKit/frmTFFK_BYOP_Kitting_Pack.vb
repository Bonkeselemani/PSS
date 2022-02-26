Option Explicit On 

Imports System
Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_Kitting_Pack
        Inherits System.Windows.Forms.Form

        Private Declare Function IDAutomation_Universal_C128 _
                                 Lib "IDAutomationNativeFontEncoder.dll" _
                                (ByVal D2E As String, ByRef tilde As Long, _
                                 ByVal out As String, _
                                 ByRef iSize As Long) As Long

        Private _strComputerName As String = ""
        Private _strItemSku_Label_PrinterName As String = ""
        Private _strUPCA_Label_PrinterName As String = ""

        Private _objTFFK As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK
        Private _objBYOP_Kitting As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting
        Private _BaseClass As PSS.Data.BaseClasses.CollectTrackingLog

        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _iSetUp_ID As Integer = 0
        Private _iPack_WO_ID As Integer = 0
        Private _iMaster_WR_ID As Integer = 0
        Private _strWIP_No As String = ""
        Private _strKitting_No As String = ""
        Private _iKittingQty As Integer = 0
        Private _dtSIM As DataTable
        Private _dtAltSIM As DataTable
        Private _dtOtherComponents As DataTable
        Private _iOpenPack_WO_ID As Integer = 0

        Private _iSIM_Qty As Integer = 0
        Private _iAlt_SIM_Qty As Integer = 0
        Private _iCollateral_Qty As Integer = 0
        Private _iPackQtyPerCarton As Integer = 0
        Private _iCartonQtyPerPallet As Integer = 0
        Private _bHasItemUPC As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFK = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK()
            Me._objBYOP_Kitting = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting()
            'Me._objBYOP_EDI = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_EDI()
            Me._BaseClass = New PSS.Data.BaseClasses.CollectTrackingLog()
            Me._strComputerName = Me._BaseClass.GetComputerName
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFK = Nothing
                    Me._objBYOP_Kitting = Nothing
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
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblMasterItem As System.Windows.Forms.Label
        Friend WithEvents txtSIMCardSN As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents btnReprintLabel As System.Windows.Forms.Button
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents tdgSIM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgAltSIM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents tdgComponents As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnClearSNs As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboKittingSetup As C1.Win.C1List.C1Combo
        Friend WithEvents cboKittingSetup2 As C1.Win.C1List.C1Combo
        Friend WithEvents txtWIPNo As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblWorkStation As System.Windows.Forms.Label
        Friend WithEvents txtKittingQty As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtKittedQty As System.Windows.Forms.TextBox
        Friend WithEvents lblUPC_A As System.Windows.Forms.Label
        Friend WithEvents lblUPC As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents chkItemSN As System.Windows.Forms.CheckBox
        Friend WithEvents chkUPC_A As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrintUPC_Label As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrintItem_Label As System.Windows.Forms.CheckBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents pnlDetails As System.Windows.Forms.Panel
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents btnLoadProfile As System.Windows.Forms.Button
        Friend WithEvents txtKittingNo As System.Windows.Forms.TextBox
        Friend WithEvents Button3 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_BYOP_Kitting_Pack))
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboKittingSetup = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblMasterItem = New System.Windows.Forms.Label()
            Me.txtSIMCardSN = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.btnReprintLabel = New System.Windows.Forms.Button()
            Me.lblUPC_A = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.cboKittingSetup2 = New C1.Win.C1List.C1Combo()
            Me.tdgSIM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgAltSIM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.tdgComponents = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnClearSNs = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtWIPNo = New System.Windows.Forms.TextBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtKittingQty = New System.Windows.Forms.TextBox()
            Me.lblWorkStation = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtKittedQty = New System.Windows.Forms.TextBox()
            Me.lblUPC = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.chkItemSN = New System.Windows.Forms.CheckBox()
            Me.chkUPC_A = New System.Windows.Forms.CheckBox()
            Me.chkPrintUPC_Label = New System.Windows.Forms.CheckBox()
            Me.chkPrintItem_Label = New System.Windows.Forms.CheckBox()
            Me.pnlDetails = New System.Windows.Forms.Panel()
            Me.txtKittingNo = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.btnLoadProfile = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            CType(Me.cboKittingSetup, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboKittingSetup2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgSIM, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgAltSIM, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.tdgComponents, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlDetails.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label4
            '
            Me.Label4.Name = "Label4"
            Me.Label4.TabIndex = 199
            '
            'cboKittingSetup
            '
            Me.cboKittingSetup.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboKittingSetup.AutoCompletion = True
            Me.cboKittingSetup.AutoDropDown = True
            Me.cboKittingSetup.AutoSelect = True
            Me.cboKittingSetup.Caption = ""
            Me.cboKittingSetup.CaptionHeight = 17
            Me.cboKittingSetup.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboKittingSetup.ColumnCaptionHeight = 17
            Me.cboKittingSetup.ColumnFooterHeight = 17
            Me.cboKittingSetup.ColumnHeaders = False
            Me.cboKittingSetup.ContentHeight = 17
            Me.cboKittingSetup.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboKittingSetup.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboKittingSetup.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboKittingSetup.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboKittingSetup.EditorHeight = 17
            Me.cboKittingSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboKittingSetup.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboKittingSetup.ItemHeight = 15
            Me.cboKittingSetup.Location = New System.Drawing.Point(125, 32)
            Me.cboKittingSetup.MatchEntryTimeout = CType(2000, Long)
            Me.cboKittingSetup.MaxDropDownItems = CType(10, Short)
            Me.cboKittingSetup.MaxLength = 32767
            Me.cboKittingSetup.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboKittingSetup.Name = "cboKittingSetup"
            Me.cboKittingSetup.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboKittingSetup.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboKittingSetup.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboKittingSetup.Size = New System.Drawing.Size(288, 23)
            Me.cboKittingSetup.TabIndex = 144
            Me.cboKittingSetup.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft " & _
            "Sans Serif, 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Cont" & _
            "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
            "yle10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Li" & _
            "stBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapt" & _
            "ionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollG" & _
            "roup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar>" & _
            "<Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Capti" & _
            "onStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7""" & _
            " /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Sty" & _
            "le11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""" & _
            "HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddR" & _
            "owStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelecto" & _
            "r"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""" & _
            "Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style p" & _
            "arent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Head" & _
            "ing"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading" & _
            """ me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" " & _
            "me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal""" & _
            " me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capt" & _
            "ion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpl" & _
            "its><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Navy
            Me.Label1.Location = New System.Drawing.Point(24, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 24)
            Me.Label1.TabIndex = 147
            Me.Label1.Text = "Master Item:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMasterItem
            '
            Me.lblMasterItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMasterItem.Location = New System.Drawing.Point(120, 8)
            Me.lblMasterItem.Name = "lblMasterItem"
            Me.lblMasterItem.Size = New System.Drawing.Size(384, 24)
            Me.lblMasterItem.TabIndex = 149
            Me.lblMasterItem.Text = "Master Item:"
            Me.lblMasterItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtSIMCardSN
            '
            Me.txtSIMCardSN.BackColor = System.Drawing.Color.White
            Me.txtSIMCardSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSIMCardSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSIMCardSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSIMCardSN.Location = New System.Drawing.Point(120, 112)
            Me.txtSIMCardSN.Name = "txtSIMCardSN"
            Me.txtSIMCardSN.Size = New System.Drawing.Size(376, 23)
            Me.txtSIMCardSN.TabIndex = 0
            Me.txtSIMCardSN.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Navy
            Me.Label3.Location = New System.Drawing.Point(24, 112)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 21)
            Me.Label3.TabIndex = 160
            Me.Label3.Text = "SIM Card SN:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Navy
            Me.Label5.Location = New System.Drawing.Point(8, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(96, 21)
            Me.Label5.TabIndex = 176
            Me.Label5.Text = "Components:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnComplete
            '
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.Navy
            Me.btnComplete.Location = New System.Drawing.Point(512, 216)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(168, 56)
            Me.btnComplete.TabIndex = 178
            Me.btnComplete.Text = " Complete Pack"
            '
            'btnReprintLabel
            '
            Me.btnReprintLabel.Location = New System.Drawing.Point(512, 160)
            Me.btnReprintLabel.Name = "btnReprintLabel"
            Me.btnReprintLabel.Size = New System.Drawing.Size(168, 48)
            Me.btnReprintLabel.TabIndex = 179
            Me.btnReprintLabel.Text = "Reprint Label(s)"
            '
            'lblUPC_A
            '
            Me.lblUPC_A.Location = New System.Drawing.Point(120, 72)
            Me.lblUPC_A.Name = "lblUPC_A"
            Me.lblUPC_A.Size = New System.Drawing.Size(152, 24)
            Me.lblUPC_A.TabIndex = 181
            Me.lblUPC_A.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Navy
            Me.Label7.Location = New System.Drawing.Point(8, 72)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(112, 24)
            Me.Label7.TabIndex = 180
            Me.Label7.Text = "UPC(12):"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(680, 448)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(40, 24)
            Me.Button1.TabIndex = 182
            Me.Button1.Text = "Button1"
            Me.Button1.Visible = False
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(600, 448)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(72, 24)
            Me.Button2.TabIndex = 183
            Me.Button2.Text = "Button2"
            Me.Button2.Visible = False
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(688, 416)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(40, 22)
            Me.TextBox1.TabIndex = 184
            Me.TextBox1.Text = ""
            Me.TextBox1.Visible = False
            '
            'cboKittingSetup2
            '
            Me.cboKittingSetup2.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboKittingSetup2.AutoCompletion = True
            Me.cboKittingSetup2.AutoDropDown = True
            Me.cboKittingSetup2.AutoSelect = True
            Me.cboKittingSetup2.Caption = ""
            Me.cboKittingSetup2.CaptionHeight = 17
            Me.cboKittingSetup2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboKittingSetup2.ColumnCaptionHeight = 17
            Me.cboKittingSetup2.ColumnFooterHeight = 17
            Me.cboKittingSetup2.ColumnHeaders = False
            Me.cboKittingSetup2.ContentHeight = 17
            Me.cboKittingSetup2.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboKittingSetup2.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboKittingSetup2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboKittingSetup2.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboKittingSetup2.EditorHeight = 17
            Me.cboKittingSetup2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboKittingSetup2.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboKittingSetup2.ItemHeight = 15
            Me.cboKittingSetup2.Location = New System.Drawing.Point(616, 416)
            Me.cboKittingSetup2.MatchEntryTimeout = CType(2000, Long)
            Me.cboKittingSetup2.MaxDropDownItems = CType(10, Short)
            Me.cboKittingSetup2.MaxLength = 32767
            Me.cboKittingSetup2.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboKittingSetup2.Name = "cboKittingSetup2"
            Me.cboKittingSetup2.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboKittingSetup2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboKittingSetup2.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboKittingSetup2.Size = New System.Drawing.Size(56, 23)
            Me.cboKittingSetup2.TabIndex = 186
            Me.cboKittingSetup2.Visible = False
            Me.cboKittingSetup2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'tdgSIM
            '
            Me.tdgSIM.AllowColMove = False
            Me.tdgSIM.AllowColSelect = False
            Me.tdgSIM.AllowFilter = False
            Me.tdgSIM.AllowSort = False
            Me.tdgSIM.AllowUpdate = False
            Me.tdgSIM.BackColor = System.Drawing.Color.White
            Me.tdgSIM.CaptionHeight = 17
            Me.tdgSIM.ColumnHeaders = False
            Me.tdgSIM.FetchRowStyles = True
            Me.tdgSIM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSIM.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSIM.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgSIM.Location = New System.Drawing.Point(120, 136)
            Me.tdgSIM.Name = "tdgSIM"
            Me.tdgSIM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSIM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSIM.PreviewInfo.ZoomFactor = 75
            Me.tdgSIM.RecordSelectors = False
            Me.tdgSIM.RowHeight = 15
            Me.tdgSIM.Size = New System.Drawing.Size(376, 72)
            Me.tdgSIM.TabIndex = 187
            Me.tdgSIM.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
            "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" RecordSelectors=""Fal" & _
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>68</Height><Captio" & _
            "nStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /" & _
            "><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar""" & _
            " me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 372, 68</ClientRect><Border" & _
            "Side>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeV" & _
            "iew></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" " & _
            "me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=" & _
            """Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""S" & _
            "elected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highl" & _
            "ightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddR" & _
            "ow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""F" & _
            "ilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</ve" & _
            "rtSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</" & _
            "DefaultRecSelWidth><ClientArea>0, 0, 372, 68</ClientArea><PrintPageHeaderStyle p" & _
            "arent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tdgAltSIM
            '
            Me.tdgAltSIM.AllowColMove = False
            Me.tdgAltSIM.AllowColSelect = False
            Me.tdgAltSIM.AllowFilter = False
            Me.tdgAltSIM.AllowSort = False
            Me.tdgAltSIM.AllowUpdate = False
            Me.tdgAltSIM.BackColor = System.Drawing.Color.White
            Me.tdgAltSIM.CaptionHeight = 17
            Me.tdgAltSIM.ColumnHeaders = False
            Me.tdgAltSIM.FetchRowStyles = True
            Me.tdgAltSIM.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgAltSIM.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgAltSIM.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgAltSIM.Location = New System.Drawing.Point(120, 208)
            Me.tdgAltSIM.Name = "tdgAltSIM"
            Me.tdgAltSIM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgAltSIM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgAltSIM.PreviewInfo.ZoomFactor = 75
            Me.tdgAltSIM.RecordSelectors = False
            Me.tdgAltSIM.RowHeight = 15
            Me.tdgAltSIM.Size = New System.Drawing.Size(376, 48)
            Me.tdgAltSIM.TabIndex = 188
            Me.tdgAltSIM.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" RecordSelectors=""Fal" & _
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>44</Height><Captio" & _
            "nStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /" & _
            "><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar""" & _
            " me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
            "roup"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
            "tyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""St" & _
            "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""" & _
            "RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><S" & _
            "tyle parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 372, 44</ClientRect><Border" & _
            "Side>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeV" & _
            "iew></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" " & _
            "me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=" & _
            """Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""S" & _
            "elected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highl" & _
            "ightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddR" & _
            "ow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""F" & _
            "ilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</ve" & _
            "rtSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</" & _
            "DefaultRecSelWidth><ClientArea>0, 0, 372, 44</ClientArea><PrintPageHeaderStyle p" & _
            "arent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgComponents, Me.Label5})
            Me.Panel1.Location = New System.Drawing.Point(16, 264)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(488, 240)
            Me.Panel1.TabIndex = 189
            '
            'tdgComponents
            '
            Me.tdgComponents.AllowColMove = False
            Me.tdgComponents.AllowColSelect = False
            Me.tdgComponents.AllowFilter = False
            Me.tdgComponents.AllowSort = False
            Me.tdgComponents.AllowUpdate = False
            Me.tdgComponents.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tdgComponents.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tdgComponents.CaptionHeight = 17
            Me.tdgComponents.FetchRowStyles = True
            Me.tdgComponents.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgComponents.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgComponents.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgComponents.Location = New System.Drawing.Point(104, 12)
            Me.tdgComponents.Name = "tdgComponents"
            Me.tdgComponents.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgComponents.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgComponents.PreviewInfo.ZoomFactor = 75
            Me.tdgComponents.RecordSelectors = False
            Me.tdgComponents.RowHeight = 15
            Me.tdgComponents.Size = New System.Drawing.Size(376, 216)
            Me.tdgComponents.TabIndex = 193
            Me.tdgComponents.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{Border:Flat,DimGray,0, 0, 0, 0;}Style2{}Style5{}Style4{}Style7{}Style6{}Ev" & _
            "enRow{Locked:False;Border:Flat,DarkGray,0, 0, 0, 0;BackColor:PowderBlue;}Selecte" & _
            "d{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:LightSteelBlue;}FilterBar{}Footer{}Caption{AlignHorz:Cen" & _
            "ter;Border:Flat,ControlDark,0, 0, 0, 0;}Style1{}Normal{Font:Tahoma, 8.25pt;BackC" & _
            "olor2:LightSteelBlue;Border:Flat,DarkGray,1, 0, 0, 0;BackColor:LightSteelBlue;}H" & _
            "ighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{Border:" & _
            "Flat,DarkGray,0, 0, 0, 0;}RecordSelector{Border:Flat,DarkGray,0, 0, 0, 0;AlignIm" & _
            "age:Center;}Style15{}Heading{Wrap:True;BackColor:LightSteelBlue;Border:Flat,Cont" & _
            "rolDark,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{Align" & _
            "Horz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1" & _
            "TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" Caption" & _
            "Height=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""Tru" & _
            "e"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" " & _
            "RecordSelectors=""False"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Heigh" & _
            "t>216</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""" & _
            "Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarSty" & _
            "le parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" />" & _
            "<GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Sty" & _
            "le2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle par" & _
            "ent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordS" & _
            "electorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selec" & _
            "ted"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 376, 2" & _
            "16</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.W" & _
            "in.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><" & _
            "Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Styl" & _
            "e parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style" & _
            " parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style par" & _
            "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
            "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
            " parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedSt" & _
            "yles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><D" & _
            "efaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 376, 216</ClientArea>" & _
            "<PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" m" & _
            "e=""Style15"" /></Blob>"
            '
            'btnClearSNs
            '
            Me.btnClearSNs.ForeColor = System.Drawing.Color.SaddleBrown
            Me.btnClearSNs.Location = New System.Drawing.Point(512, 112)
            Me.btnClearSNs.Name = "btnClearSNs"
            Me.btnClearSNs.Size = New System.Drawing.Size(168, 40)
            Me.btnClearSNs.TabIndex = 190
            Me.btnClearSNs.Text = "Clear SNs"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Navy
            Me.Label2.Location = New System.Drawing.Point(24, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 21)
            Me.Label2.TabIndex = 192
            Me.Label2.Text = "WIP No:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtWIPNo
            '
            Me.txtWIPNo.BackColor = System.Drawing.Color.White
            Me.txtWIPNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtWIPNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWIPNo.ForeColor = System.Drawing.Color.Black
            Me.txtWIPNo.Location = New System.Drawing.Point(120, 40)
            Me.txtWIPNo.Name = "txtWIPNo"
            Me.txtWIPNo.Size = New System.Drawing.Size(140, 23)
            Me.txtWIPNo.TabIndex = 191
            Me.txtWIPNo.Text = ""
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Navy
            Me.Label6.Location = New System.Drawing.Point(512, 40)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(80, 21)
            Me.Label6.TabIndex = 194
            Me.Label6.Text = "Kitting Qty:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtKittingQty
            '
            Me.txtKittingQty.BackColor = System.Drawing.Color.White
            Me.txtKittingQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtKittingQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtKittingQty.ForeColor = System.Drawing.Color.Black
            Me.txtKittingQty.Location = New System.Drawing.Point(592, 40)
            Me.txtKittingQty.Name = "txtKittingQty"
            Me.txtKittingQty.Size = New System.Drawing.Size(88, 30)
            Me.txtKittingQty.TabIndex = 193
            Me.txtKittingQty.Text = "0"
            '
            'lblWorkStation
            '
            Me.lblWorkStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkStation.ForeColor = System.Drawing.Color.Navy
            Me.lblWorkStation.Location = New System.Drawing.Point(88, 0)
            Me.lblWorkStation.Name = "lblWorkStation"
            Me.lblWorkStation.Size = New System.Drawing.Size(216, 24)
            Me.lblWorkStation.TabIndex = 196
            Me.lblWorkStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Navy
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(88, 24)
            Me.Label9.TabIndex = 195
            Me.Label9.Text = "Workstation:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Navy
            Me.Label8.Location = New System.Drawing.Point(512, 72)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(80, 21)
            Me.Label8.TabIndex = 198
            Me.Label8.Text = "Kitted Qty:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtKittedQty
            '
            Me.txtKittedQty.BackColor = System.Drawing.Color.White
            Me.txtKittedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtKittedQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtKittedQty.ForeColor = System.Drawing.Color.Black
            Me.txtKittedQty.Location = New System.Drawing.Point(592, 72)
            Me.txtKittedQty.Name = "txtKittedQty"
            Me.txtKittedQty.Size = New System.Drawing.Size(88, 30)
            Me.txtKittedQty.TabIndex = 197
            Me.txtKittedQty.Text = "0"
            '
            'lblUPC
            '
            Me.lblUPC.Location = New System.Drawing.Point(352, 72)
            Me.lblUPC.Name = "lblUPC"
            Me.lblUPC.Size = New System.Drawing.Size(140, 24)
            Me.lblUPC.TabIndex = 201
            Me.lblUPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Navy
            Me.Label11.Location = New System.Drawing.Point(272, 72)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 24)
            Me.Label11.TabIndex = 200
            Me.Label11.Text = "UPC(14):"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkItemSN
            '
            Me.chkItemSN.Location = New System.Drawing.Point(688, 160)
            Me.chkItemSN.Name = "chkItemSN"
            Me.chkItemSN.Size = New System.Drawing.Size(72, 16)
            Me.chkItemSN.TabIndex = 202
            Me.chkItemSN.Text = "Item SN"
            '
            'chkUPC_A
            '
            Me.chkUPC_A.Location = New System.Drawing.Point(688, 184)
            Me.chkUPC_A.Name = "chkUPC_A"
            Me.chkUPC_A.Size = New System.Drawing.Size(88, 16)
            Me.chkUPC_A.TabIndex = 203
            Me.chkUPC_A.Text = "UPC"
            '
            'chkPrintUPC_Label
            '
            Me.chkPrintUPC_Label.ForeColor = System.Drawing.Color.Navy
            Me.chkPrintUPC_Label.Location = New System.Drawing.Point(512, 304)
            Me.chkPrintUPC_Label.Name = "chkPrintUPC_Label"
            Me.chkPrintUPC_Label.Size = New System.Drawing.Size(160, 16)
            Me.chkPrintUPC_Label.TabIndex = 205
            Me.chkPrintUPC_Label.Text = "Print UPC Label"
            '
            'chkPrintItem_Label
            '
            Me.chkPrintItem_Label.ForeColor = System.Drawing.Color.Navy
            Me.chkPrintItem_Label.Location = New System.Drawing.Point(512, 280)
            Me.chkPrintItem_Label.Name = "chkPrintItem_Label"
            Me.chkPrintItem_Label.Size = New System.Drawing.Size(160, 16)
            Me.chkPrintItem_Label.TabIndex = 204
            Me.chkPrintItem_Label.Text = "Print Item SN Label"
            '
            'pnlDetails
            '
            Me.pnlDetails.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtKittingNo, Me.lblUPC_A, Me.txtSIMCardSN, Me.tdgSIM, Me.tdgAltSIM, Me.txtKittingQty, Me.btnReprintLabel, Me.chkUPC_A, Me.Label2, Me.Label6, Me.chkPrintUPC_Label, Me.Button2, Me.btnClearSNs, Me.Label3, Me.Label8, Me.txtKittedQty, Me.Label7, Me.cboKittingSetup2, Me.Panel1, Me.lblUPC, Me.txtWIPNo, Me.chkItemSN, Me.Label11, Me.Button1, Me.chkPrintItem_Label, Me.TextBox1, Me.Label1, Me.btnComplete, Me.lblMasterItem, Me.Label10})
            Me.pnlDetails.Location = New System.Drawing.Point(5, 56)
            Me.pnlDetails.Name = "pnlDetails"
            Me.pnlDetails.Size = New System.Drawing.Size(787, 520)
            Me.pnlDetails.TabIndex = 206
            '
            'txtKittingNo
            '
            Me.txtKittingNo.BackColor = System.Drawing.Color.White
            Me.txtKittingNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtKittingNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtKittingNo.ForeColor = System.Drawing.Color.Black
            Me.txtKittingNo.Location = New System.Drawing.Point(352, 40)
            Me.txtKittingNo.Name = "txtKittingNo"
            Me.txtKittingNo.Size = New System.Drawing.Size(140, 23)
            Me.txtKittingNo.TabIndex = 206
            Me.txtKittingNo.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Navy
            Me.Label10.Location = New System.Drawing.Point(264, 40)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(88, 21)
            Me.Label10.TabIndex = 207
            Me.Label10.Text = "Kitting No:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Navy
            Me.Label12.Location = New System.Drawing.Point(24, 32)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(96, 24)
            Me.Label12.TabIndex = 207
            Me.Label12.Text = "Kitting Profile:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnLoadProfile
            '
            Me.btnLoadProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoadProfile.ForeColor = System.Drawing.Color.Navy
            Me.btnLoadProfile.Location = New System.Drawing.Point(424, 24)
            Me.btnLoadProfile.Name = "btnLoadProfile"
            Me.btnLoadProfile.Size = New System.Drawing.Size(112, 40)
            Me.btnLoadProfile.TabIndex = 208
            Me.btnLoadProfile.Text = "Start"
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(648, 8)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(112, 40)
            Me.Button3.TabIndex = 209
            Me.Button3.Text = "Button3"
            Me.Button3.Visible = False
            '
            'frmTFFK_BYOP_Kitting_Pack
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(800, 606)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.cboKittingSetup, Me.btnLoadProfile, Me.Label12, Me.pnlDetails, Me.lblWorkStation, Me.Label9, Me.Label4})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmTFFK_BYOP_Kitting_Pack"
            Me.Text = "frmTFFK_BYOP_Kitting_Pack"
            CType(Me.cboKittingSetup, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboKittingSetup2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgSIM, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgAltSIM, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.tdgComponents, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlDetails.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_BYOP_Kitting_Pack_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                Me.pnlDetails.Visible = False
                Me.chkItemSN.Checked = True : Me.chkUPC_A.Checked = True
                Me.chkPrintItem_Label.Checked = True : Me.chkPrintUPC_Label.Checked = True

                If Me._strComputerName.Trim.Length = 0 Then
                    MessageBox.Show("No computer name (workstation). See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                Me.lblWorkStation.Text = Me._strComputerName

                If Not bLoadOpenPackWorkOrder() Then

                    Me.txtSIMCardSN.Enabled = False

                    'Populate Setup info
                    dt = Me._objBYOP_Kitting.getActiveKittingSetUp(True, Me._objTFFK.ProcessTypeIDs.Standard_Kitting)
                    Misc.PopulateC1DropDownList(Me.cboKittingSetup, dt, "Kitting_SetUp", "KMSet_ID")
                    Me.cboKittingSetup.SelectedValue = 0

                    ResetControls()

                    Me.txtKittedQty.ReadOnly = True : Me.txtKittedQty.BackColor = System.Drawing.Color.Cornsilk

                    Me.cboKittingSetup.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)

                Me.ActiveControl = Me.cboKittingSetup
                Me.cboKittingSetup.Focus()
            End Try
        End Sub

        Private Function bLoadOpenPackWorkOrder() As Boolean
            Dim dt As DataTable
            Dim dtSelectedOpenWorkOrder As DataTable
            Dim iKMSet_ID As Integer = 0
            Dim strWIP_No As String = ""
            Dim strKitting_No As String = ""
            Dim iKittingQty As Integer = 0
            Dim iKittedQty As Integer = 0

            Try
                dt = Me._objBYOP_Kitting.getOpenPackWorkOrder(Me._strComputerName)

                If dt.Rows.Count > 0 Then
                    Dim fmSelectOpenWorkOrder As New frmTFFK_BYOP_Kitting_PackOpen(dt, Me._strComputerName)

                    fmSelectOpenWorkOrder.ShowDialog()

                    If Not fmSelectOpenWorkOrder.bIsCancelled AndAlso fmSelectOpenWorkOrder.getSelectedOpenWorkOrder.Rows.Count > 0 Then
                        dtSelectedOpenWorkOrder = fmSelectOpenWorkOrder.getSelectedOpenWorkOrder
                        iKMSet_ID = Convert.ToInt32(dtSelectedOpenWorkOrder.Rows(0).Item("KMSet_ID"))
                        strWIP_No = Convert.ToString(dtSelectedOpenWorkOrder.Rows(0).Item("WIP_No"))
                        strKitting_No = Convert.ToString(dtSelectedOpenWorkOrder.Rows(0).Item("Kitting_No"))
                        iKittingQty = Convert.ToInt32(dtSelectedOpenWorkOrder.Rows(0).Item("Target_Qty"))
                        iKittedQty = Convert.ToInt32(dtSelectedOpenWorkOrder.Rows(0).Item("Qty"))
                        Me._iOpenPack_WO_ID = Convert.ToInt32(dtSelectedOpenWorkOrder.Rows(0).Item("Pack_WO_ID"))

                        'Populate Setup info
                        dt = Me._objBYOP_Kitting.getActiveKittingSetUp(True, Me._objTFFK.ProcessTypeIDs.Standard_Kitting)
                        Misc.PopulateC1DropDownList(Me.cboKittingSetup, dt, "Kitting_SetUp", "KMSet_ID")
                        Me.cboKittingSetup.SelectedValue = iKMSet_ID

                        Me.LoadSelectedSetupProfile() 'load data

                        Me.txtWIPNo.Text = strWIP_No.Trim
                        Me.txtKittingNo.Text = strKitting_No.Trim
                        Me.txtKittingQty.Text = iKittingQty.ToString
                        Me.txtKittedQty.Text = iKittedQty.ToString

                        Me.txtWIPNo.ReadOnly = True : Me.txtWIPNo.BackColor = System.Drawing.Color.Cornsilk
                        Me.txtKittingNo.ReadOnly = True : Me.txtKittingNo.BackColor = System.Drawing.Color.Cornsilk
                        Me.txtKittingQty.ReadOnly = True : Me.txtKittingQty.BackColor = System.Drawing.Color.Cornsilk
                        Me.txtKittedQty.ReadOnly = True : Me.txtKittedQty.BackColor = System.Drawing.Color.Cornsilk
                        fmSelectOpenWorkOrder.Dispose()

                        Me.txtSIMCardSN.Enabled = True
                        Me.pnlDetails.Visible = True
                        Me.cboKittingSetup.Enabled = False
                        Me.btnLoadProfile.Visible = False

                        Me.txtSIMCardSN.Text = "" : Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
                        Return True
                    Else
                        fmSelectOpenWorkOrder.Dispose()
                        Return False
                    End If
                End If

                Return False
                'Row, Kitting_Setup, Master_Items, WorkStation, WIP_No, Target_Qty, Qty, User, DateTime_Pack, Pack_WO_ID, KMSet_ID, Master_Model_ID
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dtSelectedOpenWorkOrder)
            End Try
        End Function

        Private Sub ResetControls()
            Try
                With Me
                    .lblMasterItem.Text = ""
                    .lblUPC.Text = ""
                    .lblUPC_A.Text = ""
                    .tdgSIM.DataSource = Nothing
                    .tdgAltSIM.DataSource = Nothing
                    .tdgComponents.DataSource = Nothing
                    Me._iSetUp_ID = 0

                    '.txtSIMCardSN.Text = "" : .txtSIMCardSN.SelectAll() : .txtSIMCardSN.Focus()
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ResetControls", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            MessageBox.Show(Convert.ToInt32(Me.cboKittingSetup.SelectedValue))
            MessageBox.Show(Convert.ToInt32(Me.cboKittingSetup2.SelectedValue))
        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Me.cboKittingSetup.SelectedValue = Convert.ToInt32(Me.TextBox1.Text)
            Me.cboKittingSetup2.SelectedValue = Convert.ToInt32(Me.TextBox1.Text)
        End Sub

        Private Sub btnLoadProfile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadProfile.Click
            Try
                Me.LoadSelectedSetupProfile()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnLoadProfile_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadSelectedSetupProfile()
            'Dim dt As DataTable

            Try
                Me.cboKittingSetup.Enabled = True

                If Not Me.cboKittingSetup.SelectedValue > 0 OrElse Me.cboKittingSetup.SelectedValue = Nothing Then
                    MessageBox.Show("Please select a valid kitting setup profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cboKittingSetup.Focus() : Exit Sub
                End If

                'Clear
                Me.tdgSIM.DataSource = Nothing : Me.tdgAltSIM.DataSource = Nothing : Me.tdgComponents.DataSource = Nothing
                Me.txtWIPNo.Text = "" : Me.txtKittingQty.Text = 0

                'get data for these 3 tables
                Me._iSetUp_ID = Me.cboKittingSetup.SelectedValue
                Me._objBYOP_Kitting.getActiveKittingSetData(Me._iSetUp_ID, Me._dtSIM, Me._dtAltSIM, Me._dtOtherComponents)

                If Not Me._dtSIM.Rows.Count > 0 Then
                    MessageBox.Show("No data for this kitting setup profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cboKittingSetup.Focus() : Exit Sub
                End If

                'get other data
                Me._iSIM_Qty = Convert.ToInt32(Me._dtSIM.Rows(0).Item("SIM_Qty"))
                Me._iAlt_SIM_Qty = Convert.ToInt32(Me._dtSIM.Rows(0).Item("Alt_SIM_Qty"))
                Me._iCollateral_Qty = Convert.ToInt32(Me._dtSIM.Rows(0).Item("Collateral_Qty"))
                Me._iPackQtyPerCarton = Convert.ToInt32(Me._dtSIM.Rows(0).Item("PackQtyPerCarton"))
                Me._iCartonQtyPerPallet = Convert.ToInt32(Me._dtSIM.Rows(0).Item("MaxCartonQtyPerPallet"))
                Me._bHasItemUPC = Convert.ToInt32(Me._dtSIM.Rows(0).Item("HasItemUPC"))

                If Not Me._bHasItemUPC Then
                    Me.chkUPC_A.Checked = False : Me.chkPrintUPC_Label.Checked = False
                    Me.chkUPC_A.Enabled = False : Me.chkPrintUPC_Label.Enabled = False
                End If

                'validate set up
                If Not Me._iSIM_Qty > 0 Then
                    MessageBox.Show("Qty of SIM items must be greater than 0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Me._dtSIM.Rows.Count = Me._iSIM_Qty Then
                    MessageBox.Show("Invalid SIM item qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Me._dtAltSIM.Rows.Count = Me._iAlt_SIM_Qty Then
                    MessageBox.Show("Invalid Alt SIM item qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Me._objBYOP_Kitting.IsKeySIMValid(Me._dtSIM, Me._objTFFK._iKittingRequiredSN_KeyItem) Then
                    MessageBox.Show("Invalid key SIM qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Me._iSIM_Qty > 1 AndAlso Me._objBYOP_Kitting.AreSIMDuplicate(Me._dtSIM) Then
                    MessageBox.Show("Duplicate SIM item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Me._iAlt_SIM_Qty > 1 AndAlso Me._objBYOP_Kitting.AreSIMDuplicate(Me._dtAltSIM) Then
                    MessageBox.Show("Duplicate Alt SIM item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                'Bind data
                If Me._dtSIM.Rows.Count > 0 Then Me.lblMasterItem.Text = Me._dtSIM.Rows(0).Item("Master_Item")
                Me.lblUPC.Text = Me._dtSIM.Rows(0).Item("UPC") : Me.lblUPC_A.Text = Me._dtSIM.Rows(0).Item("ItemUPC")
                Me.BindSIM(Me._dtSIM)
                Me.tdgAltSIM.Visible = False
                If Me._dtAltSIM.Rows.Count > 0 Then
                    Me.BindAltSIM(Me._dtAltSIM)
                    Me.tdgAltSIM.Visible = True
                End If
                Me.BindOtherComponents(Me._dtOtherComponents)

                Me.cboKittingSetup.Enabled = False
                Me.txtSIMCardSN.Enabled = True
                Me.pnlDetails.Visible = True
                Me.btnLoadProfile.Visible = False

                Me.ActiveControl = Me.txtWIPNo
                Me.txtWIPNo.Text = "" : Me.txtWIPNo.SelectAll() : Me.txtWIPNo.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  LoadSelectedSetupProfile", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindSIM(ByVal dtSIM As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0
            Dim iKeySIM As Integer = 0

            Try
                If dtSIM.Rows.Count > 0 Then
                    With Me.tdgSIM
                        .DataSource = dtSIM.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Component", "SN", "Qty"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                            If dbgc.Name = "SN" Then dbgc.Width = 200
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                    End With
                    'Else
                    '    MessageBox.Show("No SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindSIM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindAltSIM(ByVal dtAltSIM As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If dtAltSIM.Rows.Count > 0 Then
                    With Me.tdgAltSIM
                        .DataSource = dtAltSIM.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Component", "SN", "Qty"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                            If dbgc.Name = "SN" Then dbgc.Width = 200
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0

                    End With
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindAltSIM", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Private Sub BindOtherComponents(ByVal dtOtherComponents As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If dtOtherComponents.Rows.Count > 0 Then
                    With Me.tdgComponents
                        .DataSource = dtOtherComponents.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Component", "Qty"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                    End With
                    'Else
                    '    MessageBox.Show("No Alt_SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindOtherComponents", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub tdgSIM_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgSIM.FetchRowStyle
            Dim iKeySIM As Integer = 0

            Try
                '    strActive = Me.tdgModelCriteria.Columns("Active").CellText(e.Row).ToString
                '    Select Case strActive.Trim.ToUpper
                '        Case "Yes".ToUpper
                '            e.CellStyle.ForeColor = Color.MediumBlue
                '            Me.tdgModelCriteria.Columns("Active").c()
                '        Case "No".ToUpper
                '            e.CellStyle.ForeColor = Color.Black
                '            'Case Else
                '            '       e.CellStyle.BackColor = Color.Pink
                '    End Select

                iKeySIM = CInt(Me.tdgSIM.Columns("IsKeySIM").CellText(e.Row))
                If iKeySIM = 1 Then
                    e.CellStyle.BackColor = Color.Khaki
                Else
                    e.CellStyle.BackColor = Color.White
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgSIM_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub tdgAltSIM_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgAltSIM.FetchRowStyle
            Dim iKeySIM As Integer = 0
            Dim iKASet_ID As Integer = 0
            'Dim iAlt_KDSet_ID As Integer = 0

            Try
                'iKeySIM = CInt(Me.tdgSIM.Columns("IsKeySIM").CellText(e.Row))
                'iKASet_ID = CInt(Me.tdgSIM.Columns("KASet_ID").CellText(e.Row))
                'iAlt_KDSet_ID = CInt(Me.tdgSIM.Columns("Alt_KDSet_ID").CellText(e.Row))
                'If iKeySIM = 1 AndAlso iKASet_ID > 0 AndAlso iAlt_KDSet_ID > 0 Then
                '    e.CellStyle.BackColor = Color.Khaki
                'Else
                '    e.CellStyle.BackColor = Color.White
                'End If

                iKeySIM = CInt(Me.tdgAltSIM.Columns("IsKeySIM").CellText(e.Row))
                If iKeySIM = 1 Then
                    e.CellStyle.BackColor = Color.Khaki
                Else
                    e.CellStyle.BackColor = Color.White
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgAltSIM_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtSIMCardSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSIMCardSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSIMCardSN.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSIMCardSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessSN()
            Dim strSN As String = ""

            Dim strModel_IDs As String = ""
            Dim arrLstModelIDs As New ArrayList()
            Dim bAreDuplicateModelIDs As Boolean = False
            Dim iModel_ID As Integer = 0
            Dim iWI_ID As Integer = 0
            Dim bFound As Boolean = False
            Dim bIsSerialNoAlreadyInList As Boolean = False
            Dim bSuccessfullyFilledSN As Boolean = False

            Dim dt As DataTable
            Dim row As DataRow

            Try
                If Me._dtSIM Is Nothing OrElse Not Me._dtSIM.Rows.Count > 0 Then
                    MessageBox.Show("No SIM card Setup data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                'Get  data
                strSN = Me.txtSIMCardSN.Text.Trim : Me._strWIP_No = Me.txtWIPNo.Text : Me._strKitting_No = Me.txtKittingNo.Text
                Try
                    Me._iKittingQty = Convert.ToInt32(Me.txtKittingQty.Text)
                    Me.txtKittingQty.Text = Me._iKittingQty.ToString
                Catch ex As Exception
                    Me._iKittingQty = 0
                End Try

                If Me.getFilledSIMQty = Me._iSIM_Qty Then
                    MessageBox.Show("Ready to complete it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SIM Card SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
                    Exit Sub
                End If
                If Me._strWIP_No.Trim.Length = 0 Then
                    MessageBox.Show("Please enter WIP number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtWIPNo.SelectAll() : Me.txtWIPNo.Focus()
                    Me.txtWIPNo.ReadOnly = False : Me.txtWIPNo.BackColor = System.Drawing.Color.White
                    Exit Sub
                Else
                    Me.txtWIPNo.ReadOnly = True : Me.txtWIPNo.BackColor = System.Drawing.Color.Cornsilk
                End If
                If Me._strKitting_No.Trim.Length = 0 Then
                    MessageBox.Show("Please enter kitting number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtKittingNo.SelectAll() : Me.txtKittingNo.Focus()
                    Me.txtKittingNo.ReadOnly = False : Me.txtKittingNo.BackColor = System.Drawing.Color.White
                    Exit Sub
                Else
                    Me.txtKittingNo.ReadOnly = True : Me.txtKittingNo.BackColor = System.Drawing.Color.Cornsilk
                End If
                If Not Me._iKittingQty > 0 Then
                    MessageBox.Show("Invalid kitting qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtKittingQty.SelectAll() : Me.txtKittingQty.Focus()
                    Me.txtKittingQty.ReadOnly = False : Me.txtKittingQty.BackColor = System.Drawing.Color.White
                    Exit Sub
                Else
                    Me.txtKittingQty.ReadOnly = True : Me.txtKittingQty.BackColor = System.Drawing.Color.Cornsilk
                End If

                bIsSerialNoAlreadyInList = Me._objBYOP_Kitting.IsSerialNumberAlreadyInList(Me._dtSIM, Me._dtAltSIM, strSN)
                If bIsSerialNoAlreadyInList Then
                    MessageBox.Show("SN is already in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
                    Exit Sub
                End If

                strModel_IDs = Me._objBYOP_Kitting.getSIM_Model_IDs(Me._dtSIM, Me._dtAltSIM, arrLstModelIDs, bAreDuplicateModelIDs)


                If bAreDuplicateModelIDs Then
                    MessageBox.Show("Duplicate SIM card items (models). See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    dt = Me._objBYOP_Kitting.getAvailableSN(strSN, strModel_IDs)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Can't find this SN '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate SNs. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf Not Me._objBYOP_Kitting.AreValidToAdd_SIM_AltSIM(Me._dtSIM, Me._dtAltSIM, Convert.ToInt32(dt.Rows(0).Item("Model_ID"))) Then
                        MessageBox.Show("Already filled this item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else '=1
                        For Each row In Me._dtSIM.Rows
                            iModel_ID = Convert.ToInt32(row("Component_Model_ID"))
                            iWI_ID = Convert.ToInt32(dt.Rows(0).Item("WI_ID"))
                            If iModel_ID = Convert.ToInt32(dt.Rows(0).Item("Model_ID")) AndAlso Convert.ToString(row("SN")).Trim.Length = 0 Then
                                row.BeginEdit() : row("SN") = strSN : row("WI_ID") = iWI_ID : row.AcceptChanges()
                                bFound = True
                            End If
                        Next
                        If Not bFound Then
                            For Each row In Me._dtAltSIM.Rows
                                iModel_ID = Convert.ToInt32(row("Component_Model_ID"))
                                iWI_ID = Convert.ToInt32(dt.Rows(0).Item("WI_ID"))
                                If iModel_ID = Convert.ToInt32(dt.Rows(0).Item("Model_ID")) AndAlso Convert.ToString(row("SN")).Trim.Length = 0 Then
                                    row.BeginEdit() : row("SN") = strSN : row("WI_ID") = iWI_ID : row.AcceptChanges()
                                    bFound = True
                                End If
                            Next
                        End If

                        If Not bFound Then
                            MessageBox.Show("Can't find item to fill (it may be incorrect model?). See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            Me.BindSIM(Me._dtSIM)
                            If Me._dtAltSIM.Rows.Count > 0 Then Me.BindAltSIM(Me._dtAltSIM)
                            bSuccessfullyFilledSN = True
                        End If
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                dt = Nothing
                If Me.getFilledSIMQty = Me._iSIM_Qty Then
                    Me.txtSIMCardSN.Text = "" : Me.btnComplete.Focus()
                ElseIf bSuccessfullyFilledSN Then
                    Me.txtSIMCardSN.Text = "" : Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
                    'Else
                    '    Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
                End If
            End Try
        End Sub

        Private Function getFilledSIMQty() As Integer
            Dim row As DataRow
            Dim iQty As Integer = 0
            Dim strSN As String = ""

            Try
                For Each row In Me._dtSIM.Rows
                    strSN = Convert.ToString(row("SN")).Trim
                    If strSN.Length > 0 Then iQty += 1
                Next
                For Each row In Me._dtAltSIM.Rows
                    strSN = Convert.ToString(row("SN")).Trim
                    If strSN.Length > 0 Then iQty += 1
                Next

                Return iQty

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Function getFilledSIMQty", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Sub btnClearSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearSNs.Click
            Try
                Me.ClearSNs()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnClearSNs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ClearSNs()
            Dim row As DataRow

            Try
                For Each row In Me._dtSIM.Rows
                    row.BeginEdit() : row("SN") = "" : row.AcceptChanges()
                Next
                For Each row In Me._dtAltSIM.Rows
                    row.BeginEdit() : row("Alt_SN") = "" : row.AcceptChanges()
                Next

                Me.BindSIM(Me._dtSIM)
                If Me._dtAltSIM.Rows.Count > 0 Then Me.BindAltSIM(Me._dtAltSIM)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub ClearSNs", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim row As DataRow
            Dim iQty As Integer = 0
            Dim iKittedPack_Qty As Integer = 0
            Dim bCloseWorkOrder As Boolean = False
            Dim strMasterItem As String = ""
            Dim strUPC_A As String = ""
            Dim strKeySIM_SN As String = ""
            Dim strKeySIM_SN_BarCode As String = ""
            Dim i As Integer = 0
            Dim iKitPack_KP_ID As Integer = 0

            Try
                i = 0 : strKeySIM_SN = ""
                For Each row In Me._dtSIM.Rows
                    If i = 0 Then strMasterItem = Convert.ToString(row("Master_Item")).Trim : strUPC_A = Convert.ToString(row("ItemUPC")).Trim
                    If Convert.ToInt32(row("IsKeySIM")) = 1 AndAlso strKeySIM_SN.Trim.Length = 0 Then strKeySIM_SN = Convert.ToString(row("SN")).Trim
                    If Convert.ToString(row("SN")).Trim.Length > 0 Then iQty += 1
                    i += 1
                Next
                For Each row In Me._dtAltSIM.Rows
                    If Convert.ToInt32(row("IsKeySIM")) = 1 AndAlso strKeySIM_SN.Trim.Length = 0 Then strKeySIM_SN = Convert.ToString(row("SN")).Trim
                    If Convert.ToString(row("SN")).Trim.Length > 0 Then iQty += 1
                Next

                If iQty < Me._iSIM_Qty Then
                    MessageBox.Show("Not filled enough SNs.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf iQty > Me._objTFFK._iSimQtyPerKittingPack Then
                    MessageBox.Show("Too many SNs. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Convert.ToInt32(Me.txtKittedQty.Text) >= Convert.ToInt32(Me.txtKittingQty.Text) Then
                    MessageBox.Show("This work order has been fulfilled. " & Environment.NewLine & "You may close this screen and restart another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf strMasterItem.Trim.Length = 0 Then
                    MessageBox.Show("No master item. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me._bHasItemUPC AndAlso Not strUPC_A.Trim.Length = 12 Then
                    MessageBox.Show("No UPC code. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf strKeySIM_SN.Trim.Length = 0 Then
                    MessageBox.Show("No SIM SN for the master item. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me._strComputerName.Trim.Length > 0 Then
                    MessageBox.Show("No computer name (workstation). See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me.bValidMasterItem Then
                    Exit Sub 'message shows up in function Me.bValidMasterItem if exception happens
                ElseIf Me._dtOtherComponents.Rows.Count > 0 AndAlso Not Me.bValidOtherComponents Then
                    Exit Sub 'message shows up in function Me.bValidMasterItem if exception happens
                Else 'ready to close
                    If Me._iOpenPack_WO_ID > 0 Then Me._iPack_WO_ID = Me._iOpenPack_WO_ID 'Open work order loaaded
                    If Me._iPack_WO_ID = 0 Then
                        Me._iPack_WO_ID = Me._objBYOP_Kitting.CreateKittingPackID(Me._iSetUp_ID, Me._strComputerName, Me._strWIP_No, Me._strKitting_No, Me._iKittingQty, Me._UserID)
                    End If

                    If Not Me._iPack_WO_ID > 0 Then
                        MessageBox.Show("Failed to create pack work order or invalid pack work order info. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        iKittedPack_Qty = Convert.ToInt32(Me.txtKittedQty.Text)
                        If iKittedPack_Qty + 1 = Me._iKittingQty Then bCloseWorkOrder = True

                        If iKittedPack_Qty > Me._iKittingQty Then
                            MessageBox.Show("Overkitted pack qty. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf Not Me._objBYOP_Kitting.SaveKittedData(Me._dtSIM, Me._dtAltSIM, Me._dtOtherComponents, Me._iMaster_WR_ID, Me._iPack_WO_ID, Me._UserID, bCloseWorkOrder, iKitPack_KP_ID) Then
                            MessageBox.Show("Failed to save data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else 'saved successfully
                            Me.txtKittedQty.Text = iKittedPack_Qty + 1

                            'Generate EDI 864
                            Dim objBYOP_EDI As New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_EDI()
                            objBYOP_EDI.dtSIM = Me._dtSIM : objBYOP_EDI.dtAltSIM = Me._dtAltSIM : objBYOP_EDI.dtOtherComponents = Me._dtOtherComponents
                            objBYOP_EDI.iKP_ID = iKitPack_KP_ID
                            objBYOP_EDI.strKittingNumber = Me._strKitting_No : objBYOP_EDI.strWIP_Number = Me._strWIP_No
                            objBYOP_EDI.GenerateOutbound_EDI864()
                            objBYOP_EDI = Nothing

                            'Clean up
                            Me.ClearSNs()

                            'Print labels
                            Me._strItemSku_Label_PrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Pack_SKU_Label)
                            Me._strUPCA_Label_PrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Pack_UPC_A_Label)

                            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()
                            If Me.chkPrintItem_Label.Checked Then
                                strKeySIM_SN_BarCode = FontEncoder.Code128a(strKeySIM_SN)
                                Me._objBYOP_Kitting.PrintPackItemSKU_Label(strKeySIM_SN, strKeySIM_SN_BarCode, strMasterItem, Me._strItemSku_Label_PrinterName, 1)
                            End If
                            If Me.chkPrintUPC_Label.Checked Then
                                strUPC_A = FontEncoder.UPCa(strUPC_A)
                                Me._objBYOP_Kitting.PrintPackUPCA_Label(strMasterItem, strUPC_A, Me._strUPCA_Label_PrinterName, 1)
                            End If
                            FontEncoder = Nothing

                        End If
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnClearSNs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtSIMCardSN.Text = "" : Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
            End Try
        End Sub

        Private Function bValidMasterItem() As Boolean
            Dim iModel_ID As Integer = 0
            Dim strItem As String = ""
            Dim dt As DataTable

            Dim iQty As Integer = 0
            Dim filteredRows() As DataRow

            Try
                'Master item (model)
                iModel_ID = Convert.ToInt32(Me._dtSIM.Rows(0).Item("Master_Model_ID"))
                strItem = Convert.ToString(Me._dtSIM.Rows(0).Item("Master_Item"))

                If iModel_ID > 0 Then
                    dt = Me._objBYOP_Kitting.getAvailableOtherComponents(iModel_ID.ToString)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Can't find master item '" & strItem & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate master item '" & strItem & "'. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    ElseIf Not Convert.ToInt32(dt.Rows(0).Item("Available_Qty")) >= 1 Then
                        MessageBox.Show("No enough qty of master item '" & strItem & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    Else
                        Me._iMaster_WR_ID = Convert.ToInt32(dt.Rows(0).Item("WR_ID"))
                    End If
                Else
                    MessageBox.Show("Invalid master item '" & strItem & "' (model_ID).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                Return True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Function ValidateOtherComponents", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Function bValidOtherComponents() As Boolean
            Dim strModel_IDs As String = ""
            Dim iModel_ID As Integer = 0
            Dim strItem As String = ""
            Dim row, row2 As DataRow
            Dim dt As DataTable

            Dim bIsOk As Boolean = False
            Dim iQty As Integer = 0
            Dim filteredRows() As DataRow

            Try
                'Other components
                iModel_ID = 0 : strItem = "" : dt = Nothing
                For Each row In Me._dtOtherComponents.Rows
                    If strModel_IDs.Trim.Length = 0 Then
                        strModel_IDs = Convert.ToString(row("Component_Model_ID"))
                    Else
                        strModel_IDs &= "," & Convert.ToString(row("Component_Model_ID"))
                    End If
                Next

                If strModel_IDs.Trim.Length > 0 Then
                    dt = Me._objBYOP_Kitting.getAvailableOtherComponents(strModel_IDs)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("No available collateral components.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return False
                    Else
                        For Each row In Me._dtOtherComponents.Rows
                            iModel_ID = Convert.ToInt32(row("Component_Model_ID"))
                            iQty = Convert.ToInt32(row("Qty"))
                            strItem = Convert.ToString(row("Component"))

                            filteredRows = dt.Select("Model_ID=" & iModel_ID)
                            If filteredRows.Length = 0 Then
                                MessageBox.Show("No available collateral component '" & strItem & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return False
                            ElseIf filteredRows.Length > 1 Then
                                MessageBox.Show("Duplicate collateral component '" & strItem & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return False
                            ElseIf Not Convert.ToInt32(filteredRows(0).Item("Available_Qty")) >= iQty Then
                                MessageBox.Show("No enough collateral component '" & strItem & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Return False
                            Else '=1
                                row.BeginEdit() : row("SN") = Convert.ToString(filteredRows(0).Item("SN"))
                                row("WR_ID") = Convert.ToInt32(filteredRows(0).Item("WR_ID")) : row.AcceptChanges()
                            End If
                        Next
                    End If
                End If

                Return True 'if ok, or when no conponents are needed

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Function ValidateOtherComponents", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Sub txtKittingQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKittingQty.KeyPress
            Try
                If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                    e.Handled = True
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub btnReprintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintLabel.Click
            Dim dt As DataTable
            Dim strSN As String = ""
            Dim strMasterItem As String = ""
            Dim strUPC_A As String = ""
            Dim strKeySIM_SN As String = ""
            Dim strKeySIM_SN_BarCode As String = ""

            Try
                If Not Me.chkItemSN.Checked AndAlso Not Me.chkUPC_A.Checked Then
                    MessageBox.Show("Please select check box(s) to reprint.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                strSN = InputBox("Enter an item SN:", "Enter SN", "")

                If strSN.Trim.Length > 0 Then
                    dt = Me._objBYOP_Kitting.getReprintLabelData(strSN)
                    'PAck_WO_ID, KMSet_ID, WIP_No, Target_Qty, Qty, Closed, KP_ID, UPC, ItemUPC, Master_Item, SN, Model_ID, KPD_ID

                    If dt.Rows.Count = 1 Then
                        Me._strItemSku_Label_PrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Pack_SKU_Label)
                        Me._strUPCA_Label_PrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Pack_UPC_A_Label)

                        strMasterItem = Convert.ToString(dt.Rows(0).Item("Master_Item")).Trim
                        strUPC_A = Convert.ToString(dt.Rows(0).Item("ItemUPC")).Trim
                        strKeySIM_SN = Convert.ToString(dt.Rows(0).Item("SN")).Trim

                        If Me.chkItemSN.Checked Then
                            If strMasterItem.Length = 0 Then MessageBox.Show("Can't find master item name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
                            If strKeySIM_SN.Length = 0 Then MessageBox.Show("Can't find item SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub

                            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()
                            strKeySIM_SN_BarCode = FontEncoder.Code128a(strKeySIM_SN)
                            Me._objBYOP_Kitting.PrintPackItemSKU_Label(strKeySIM_SN, strKeySIM_SN_BarCode, strMasterItem, Me._strItemSku_Label_PrinterName, 1)
                            FontEncoder = Nothing
                        End If
                        If Me.chkUPC_A.Checked Then
                            If Not strUPC_A.Length = 12 Then MessageBox.Show("Can't find item UPC (12).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
                            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

                            strUPC_A = FontEncoder.UPCa(strUPC_A)
                            Me._objBYOP_Kitting.PrintPackUPCA_Label(strMasterItem, strUPC_A, Me._strUPCA_Label_PrinterName, 1)
                            FontEncoder = Nothing
                        End If
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate records for this SN '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        MessageBox.Show("No kitted data found for this SN '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("You must enter an item SN.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnReprintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
            Dim objEDI As New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_EDI()

            objEDI.GenerateOutbound_EDI864()
        End Sub
    End Class
End Namespace