Option Explicit On 

Imports System
Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_SimplePackProcess
        Inherits System.Windows.Forms.Form

        Private Declare Function IDAutomation_Universal_C128 _
                 Lib "IDAutomationNativeFontEncoder.dll" _
                (ByVal D2E As String, ByRef tilde As Long, _
                 ByVal out As String, _
                 ByRef iSize As Long) As Long

        Private _strComputerName As String = ""
        Private _iProcess_Type_ID As Integer = 0
        Private _strDelimiter As String = ","
        Private _iSessionBoxID As Integer = 0
        Private _iSessionSN_Total As Integer = 0
        Private _dtSessionLog As DataTable
        Private _dtSNs As DataTable
        Private _iMasterItem_Model_ID As Integer = 0
        Private _iSIM_Model_ID As Integer = 0
        Private _iKMSet_ID As Integer = 0
        Private _iIsKeySIM As Integer = 0

        'Inner Carton
        Private _strInnerCartonLabel_PrinterName As String = ""
        Private _iInnerCarton_ID As Integer = 0
        Private _dtInnerCarton As DataTable
        Private _iPackQtyPerInnerCarton As Integer = 0
        Private _iInnerCartonSIMCard_Model_ID As Integer = 0
        Private _strGTIN_InnerCarton_UPC_Barcode As String = ""
        Private _strInnerCartonMasterItem_Desc As String = ""
        Private _HasExpirationDate As Boolean = False

        'Master Carton
        Private _strMasterCartonLabel_PrinterName As String = ""
        Private _iMasterCarton_ID As Integer = 0
        Private _dtMasterCarton As DataTable
        Private _dtMasterCartonDetails As DataTable
        Private _iPackQtyPerMasterCarton As Integer = 0
        Private _iPackQtyPerInnerCarton4MC_Calc As Integer = 0
        Private _iTotalSNQtyPerPerMasterCarton As Integer = 0
        Private _iMasterCartonSIMCard_Model_ID As Integer = 0
        Private _iMasterCartonMasterItem_Model_ID As Integer = 0
        Private _strGTIN_MasterCarton_UPC_Barcode As String = ""
        Private _strMasterCartonMasterItem_Desc As String = ""
        Private _HasExpirationDate4MasterCarton As Boolean = False

        'Pallet
        Private _iMaxQtyPerPallet As Integer = 0
        Private _strPalletLabel_PrinterName As String = ""
        Private _iPallet_ID As Integer = 0
        Private _dtPallet As DataTable
        Private _iPalletSIMCard_Model_ID As Integer = 0
        Private _iPalletMasterItem_Model_ID As Integer = 0
        Private _strPalletMasterItem_Desc As String = ""

        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser

        Private _objTFFK As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK
        Private _objBYOP_Kitting As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting
        Private _objBYOP_SPP As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_SimplePackProcess
        Private _BaseClass As PSS.Data.BaseClasses.CollectTrackingLog

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFK = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK()
            Me._objBYOP_SPP = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_SimplePackProcess()
            Me._objBYOP_Kitting = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting()
            Me._BaseClass = New PSS.Data.BaseClasses.CollectTrackingLog()
            Me._strComputerName = Me._BaseClass.GetComputerName
            Me._dtSNs = Me._objBYOP_SPP.getSN_DataTableDef()
            Me._dtSessionLog = Me._objBYOP_SPP.getProcessedBox_DataTableDef
            Me._iProcess_Type_ID = Me._objTFFK.ProcessTypeIDs.Simple_Packing
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFK = Nothing
                    Me._objBYOP_Kitting = Nothing
                    Me._objBYOP_SPP = Nothing
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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents cboKittingSetup As C1.Win.C1List.C1Combo
        Friend WithEvents btnLoadProfile As System.Windows.Forms.Button
        Friend WithEvents tdgSessionLog As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents chkAutoSave As System.Windows.Forms.CheckBox
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lbllblItemUPC As System.Windows.Forms.Label
        Friend WithEvents lblItemUPC As System.Windows.Forms.Label
        Friend WithEvents lbllblDesc As System.Windows.Forms.Label
        Friend WithEvents lblItemDesc As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents tdgSNs As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtSNs As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblWorkStation As System.Windows.Forms.Label
        Friend WithEvents pnlMaster As System.Windows.Forms.Panel
        Friend WithEvents lbllblUPC As System.Windows.Forms.Label
        Friend WithEvents lblUPC As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents lblCarton As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents pnlPallet As System.Windows.Forms.Panel
        Friend WithEvents Label21 As System.Windows.Forms.Label
        Friend WithEvents Label22 As System.Windows.Forms.Label
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents txtPalletName As System.Windows.Forms.TextBox
        Friend WithEvents tdgPallet As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label23 As System.Windows.Forms.Label
        Friend WithEvents chkPrintInnerCartonLabel As System.Windows.Forms.CheckBox
        Friend WithEvents btnInnerCartonRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnInnerCartonReprintLabel As System.Windows.Forms.Button
        Friend WithEvents btnInnerCartonRemoveOne As System.Windows.Forms.Button
        Friend WithEvents txtInnerCarton As System.Windows.Forms.TextBox
        Friend WithEvents lblInnerCartonUPC As System.Windows.Forms.Label
        Friend WithEvents lblInnerCartonItem As System.Windows.Forms.Label
        Friend WithEvents txtInnerCartonQty As System.Windows.Forms.TextBox
        Friend WithEvents btnInnerCartonComplete As System.Windows.Forms.Button
        Friend WithEvents tdgInnerCartonSNs As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtInnerCartonSN As System.Windows.Forms.TextBox
        Friend WithEvents chkPrintMasterCartonLabel As System.Windows.Forms.CheckBox
        Friend WithEvents btnMasterCartonRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnMasterCartonReprintLabel As System.Windows.Forms.Button
        Friend WithEvents btnMasterCartonRemoveOne As System.Windows.Forms.Button
        Friend WithEvents txtMasterCarton As System.Windows.Forms.TextBox
        Friend WithEvents lblMasterCartonUPC As System.Windows.Forms.Label
        Friend WithEvents lblMasterCartonItem As System.Windows.Forms.Label
        Friend WithEvents txtMasterCartonQty As System.Windows.Forms.TextBox
        Friend WithEvents btnMasterCartonComplete As System.Windows.Forms.Button
        Friend WithEvents tdgInnerCartonNumbers As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtInnerCartonNumber As System.Windows.Forms.TextBox
        Friend WithEvents pnlInnerCarton As System.Windows.Forms.Panel
        Friend WithEvents pnlMasterCarton As System.Windows.Forms.Panel
        Friend WithEvents txtPalletQty As System.Windows.Forms.TextBox
        Friend WithEvents btnResetInnerCarton As System.Windows.Forms.Button
        Friend WithEvents lblInnerCartonSIMItem As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblMasterCartonSIMItem As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents btnResetMasterCarton As System.Windows.Forms.Button
        Friend WithEvents chkPrintPalletLabel As System.Windows.Forms.CheckBox
        Friend WithEvents btnPalletRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnPalletReprintLabel As System.Windows.Forms.Button
        Friend WithEvents btnPalletRemoveOne As System.Windows.Forms.Button
        Friend WithEvents lblPalletItem As System.Windows.Forms.Label
        Friend WithEvents btnPalletComplete As System.Windows.Forms.Button
        Friend WithEvents txtMasterCartonNo As System.Windows.Forms.TextBox
        Friend WithEvents btnResetPallet As System.Windows.Forms.Button
        Friend WithEvents lblPalletSIMItem As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblExpirationDate As System.Windows.Forms.Label
        Friend WithEvents lbllblExpirationDate As System.Windows.Forms.Label
        Friend WithEvents btnExpirationDate As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_BYOP_SimplePackProcess))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.btnLoadProfile = New System.Windows.Forms.Button()
            Me.cboKittingSetup = New C1.Win.C1List.C1Combo()
            Me.pnlMaster = New System.Windows.Forms.Panel()
            Me.lbllblUPC = New System.Windows.Forms.Label()
            Me.lblUPC = New System.Windows.Forms.Label()
            Me.tdgSessionLog = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.chkAutoSave = New System.Windows.Forms.CheckBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.lbllblItemUPC = New System.Windows.Forms.Label()
            Me.lblItemUPC = New System.Windows.Forms.Label()
            Me.lbllblDesc = New System.Windows.Forms.Label()
            Me.lblItemDesc = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblItem = New System.Windows.Forms.Label()
            Me.tdgSNs = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtSNs = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.btnExpirationDate = New System.Windows.Forms.Button()
            Me.lbllblExpirationDate = New System.Windows.Forms.Label()
            Me.lblExpirationDate = New System.Windows.Forms.Label()
            Me.btnResetInnerCarton = New System.Windows.Forms.Button()
            Me.pnlInnerCarton = New System.Windows.Forms.Panel()
            Me.lblInnerCartonSIMItem = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtInnerCarton = New System.Windows.Forms.TextBox()
            Me.lblInnerCartonUPC = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblInnerCartonItem = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.txtInnerCartonQty = New System.Windows.Forms.TextBox()
            Me.lblCarton = New System.Windows.Forms.Label()
            Me.chkPrintInnerCartonLabel = New System.Windows.Forms.CheckBox()
            Me.btnInnerCartonRemoveAll = New System.Windows.Forms.Button()
            Me.btnInnerCartonReprintLabel = New System.Windows.Forms.Button()
            Me.btnInnerCartonRemoveOne = New System.Windows.Forms.Button()
            Me.btnInnerCartonComplete = New System.Windows.Forms.Button()
            Me.tdgInnerCartonSNs = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtInnerCartonSN = New System.Windows.Forms.TextBox()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.btnResetMasterCarton = New System.Windows.Forms.Button()
            Me.chkPrintMasterCartonLabel = New System.Windows.Forms.CheckBox()
            Me.btnMasterCartonRemoveAll = New System.Windows.Forms.Button()
            Me.btnMasterCartonReprintLabel = New System.Windows.Forms.Button()
            Me.btnMasterCartonRemoveOne = New System.Windows.Forms.Button()
            Me.pnlMasterCarton = New System.Windows.Forms.Panel()
            Me.lblMasterCartonSIMItem = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtMasterCarton = New System.Windows.Forms.TextBox()
            Me.lblMasterCartonUPC = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.lblMasterCartonItem = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.txtMasterCartonQty = New System.Windows.Forms.TextBox()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.btnMasterCartonComplete = New System.Windows.Forms.Button()
            Me.tdgInnerCartonNumbers = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.txtInnerCartonNumber = New System.Windows.Forms.TextBox()
            Me.TabPage4 = New System.Windows.Forms.TabPage()
            Me.btnResetPallet = New System.Windows.Forms.Button()
            Me.chkPrintPalletLabel = New System.Windows.Forms.CheckBox()
            Me.btnPalletRemoveAll = New System.Windows.Forms.Button()
            Me.btnPalletReprintLabel = New System.Windows.Forms.Button()
            Me.btnPalletRemoveOne = New System.Windows.Forms.Button()
            Me.pnlPallet = New System.Windows.Forms.Panel()
            Me.lblPalletSIMItem = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblPalletItem = New System.Windows.Forms.Label()
            Me.Label21 = New System.Windows.Forms.Label()
            Me.Label22 = New System.Windows.Forms.Label()
            Me.txtPalletQty = New System.Windows.Forms.TextBox()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.txtPalletName = New System.Windows.Forms.TextBox()
            Me.btnPalletComplete = New System.Windows.Forms.Button()
            Me.tdgPallet = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label23 = New System.Windows.Forms.Label()
            Me.txtMasterCartonNo = New System.Windows.Forms.TextBox()
            Me.lblWorkStation = New System.Windows.Forms.Label()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.cboKittingSetup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlMaster.SuspendLayout()
            CType(Me.tdgSessionLog, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgSNs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            Me.pnlInnerCarton.SuspendLayout()
            CType(Me.tdgInnerCartonSNs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage3.SuspendLayout()
            Me.pnlMasterCarton.SuspendLayout()
            CType(Me.tdgInnerCartonNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage4.SuspendLayout()
            Me.pnlPallet.SuspendLayout()
            CType(Me.tdgPallet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3, Me.TabPage4})
            Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(32, 24)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1152, 688)
            Me.TabControl1.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLoadProfile, Me.cboKittingSetup, Me.pnlMaster})
            Me.TabPage1.Location = New System.Drawing.Point(4, 25)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(1144, 659)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Open Box"
            '
            'btnLoadProfile
            '
            Me.btnLoadProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoadProfile.ForeColor = System.Drawing.Color.Navy
            Me.btnLoadProfile.Location = New System.Drawing.Point(312, 12)
            Me.btnLoadProfile.Name = "btnLoadProfile"
            Me.btnLoadProfile.Size = New System.Drawing.Size(112, 32)
            Me.btnLoadProfile.TabIndex = 209
            Me.btnLoadProfile.Text = "Start"
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
            Me.cboKittingSetup.Location = New System.Drawing.Point(16, 16)
            Me.cboKittingSetup.MatchEntryTimeout = CType(2000, Long)
            Me.cboKittingSetup.MaxDropDownItems = CType(10, Short)
            Me.cboKittingSetup.MaxLength = 32767
            Me.cboKittingSetup.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboKittingSetup.Name = "cboKittingSetup"
            Me.cboKittingSetup.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboKittingSetup.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboKittingSetup.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboKittingSetup.Size = New System.Drawing.Size(288, 23)
            Me.cboKittingSetup.TabIndex = 145
            Me.cboKittingSetup.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft " & _
            "Sans Serif, 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True" & _
            ";AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Cont" & _
            "rol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Li" & _
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
            'pnlMaster
            '
            Me.pnlMaster.Controls.AddRange(New System.Windows.Forms.Control() {Me.lbllblUPC, Me.lblUPC, Me.tdgSessionLog, Me.chkAutoSave, Me.btnSave, Me.lbllblItemUPC, Me.lblItemUPC, Me.lbllblDesc, Me.lblItemDesc, Me.Label1, Me.lblItem, Me.tdgSNs, Me.txtSNs, Me.Label3})
            Me.pnlMaster.Location = New System.Drawing.Point(0, 40)
            Me.pnlMaster.Name = "pnlMaster"
            Me.pnlMaster.Size = New System.Drawing.Size(1128, 600)
            Me.pnlMaster.TabIndex = 210
            '
            'lbllblUPC
            '
            Me.lbllblUPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblUPC.ForeColor = System.Drawing.Color.Navy
            Me.lbllblUPC.Location = New System.Drawing.Point(728, 8)
            Me.lbllblUPC.Name = "lbllblUPC"
            Me.lbllblUPC.Size = New System.Drawing.Size(72, 24)
            Me.lbllblUPC.TabIndex = 214
            Me.lbllblUPC.Text = "UPC:"
            Me.lbllblUPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUPC
            '
            Me.lblUPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUPC.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblUPC.Location = New System.Drawing.Point(808, 8)
            Me.lblUPC.Name = "lblUPC"
            Me.lblUPC.Size = New System.Drawing.Size(208, 24)
            Me.lblUPC.TabIndex = 215
            Me.lblUPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tdgSessionLog
            '
            Me.tdgSessionLog.AllowColMove = False
            Me.tdgSessionLog.AllowColSelect = False
            Me.tdgSessionLog.AllowFilter = False
            Me.tdgSessionLog.AllowSort = False
            Me.tdgSessionLog.AllowUpdate = False
            Me.tdgSessionLog.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tdgSessionLog.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tdgSessionLog.Caption = "Total Box: 0, Total SNs: 0"
            Me.tdgSessionLog.CaptionHeight = 15
            Me.tdgSessionLog.FetchRowStyles = True
            Me.tdgSessionLog.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.tdgSessionLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSessionLog.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSessionLog.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgSessionLog.Location = New System.Drawing.Point(72, 224)
            Me.tdgSessionLog.Name = "tdgSessionLog"
            Me.tdgSessionLog.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSessionLog.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSessionLog.PreviewInfo.ZoomFactor = 75
            Me.tdgSessionLog.RecordSelectors = False
            Me.tdgSessionLog.RowHeight = 15
            Me.tdgSessionLog.Size = New System.Drawing.Size(264, 368)
            Me.tdgSessionLog.TabIndex = 213
            Me.tdgSessionLog.Text = "C1TrueDBGrid1"
            Me.tdgSessionLog.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:General;Border:None,,0, 0, 0, 0;ForeColor:DarkSlateGray;BackColor" & _
            ":LightSteelBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 9pt;}HighlightRow{For" & _
            "eColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignI" & _
            "mage:Center;}Style15{}Heading{Wrap:True;BackColor:LightSteelBlue;Border:Flat,Con" & _
            "trolDark,0, 1, 0, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{Alig" & _
            "nHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C" & _
            "1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" Captio" & _
            "nHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""Tr" & _
            "ue"" FilterBorderStyle=""Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth" & _
            "=""17"" DefRecSelWidth=""17"" RecordSelectors=""False"" VerticalScrollGroup=""1"" Horizo" & _
            "ntalScrollGroup=""1""><Height>353</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
            "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
            "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
            "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
            "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
            "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
            "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
            "/><ClientRect>0, 15, 264, 353</ClientRect><BorderSide>0</BorderSide><BorderStyle" & _
            ">Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Styl" & _
            "e parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""H" & _
            "eading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Head" & _
            "ing"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Norma" & _
            "l"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Norma" & _
            "l"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" m" & _
            "e=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capt" & _
            "ion"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpl" & _
            "its><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>" & _
            "0, 0, 264, 368</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Print" & _
            "PageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'chkAutoSave
            '
            Me.chkAutoSave.Location = New System.Drawing.Point(72, 64)
            Me.chkAutoSave.Name = "chkAutoSave"
            Me.chkAutoSave.TabIndex = 212
            Me.chkAutoSave.Text = "Auto Save"
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(504, 88)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(120, 48)
            Me.btnSave.TabIndex = 211
            Me.btnSave.Text = "Save"
            '
            'lbllblItemUPC
            '
            Me.lbllblItemUPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblItemUPC.ForeColor = System.Drawing.Color.Navy
            Me.lbllblItemUPC.Location = New System.Drawing.Point(432, 6)
            Me.lbllblItemUPC.Name = "lbllblItemUPC"
            Me.lbllblItemUPC.Size = New System.Drawing.Size(72, 24)
            Me.lbllblItemUPC.TabIndex = 209
            Me.lbllblItemUPC.Text = "Item UPC:"
            Me.lbllblItemUPC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemUPC
            '
            Me.lblItemUPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblItemUPC.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblItemUPC.Location = New System.Drawing.Point(512, 6)
            Me.lblItemUPC.Name = "lblItemUPC"
            Me.lblItemUPC.Size = New System.Drawing.Size(208, 24)
            Me.lblItemUPC.TabIndex = 210
            Me.lblItemUPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblDesc
            '
            Me.lbllblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblDesc.ForeColor = System.Drawing.Color.Navy
            Me.lbllblDesc.Location = New System.Drawing.Point(32, 28)
            Me.lbllblDesc.Name = "lbllblDesc"
            Me.lbllblDesc.Size = New System.Drawing.Size(48, 24)
            Me.lbllblDesc.TabIndex = 207
            Me.lbllblDesc.Text = "Desc:"
            Me.lbllblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItemDesc
            '
            Me.lblItemDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblItemDesc.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblItemDesc.Location = New System.Drawing.Point(80, 28)
            Me.lblItemDesc.Name = "lblItemDesc"
            Me.lblItemDesc.Size = New System.Drawing.Size(1016, 24)
            Me.lblItemDesc.TabIndex = 208
            Me.lblItemDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Navy
            Me.Label1.Location = New System.Drawing.Point(32, 6)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 24)
            Me.Label1.TabIndex = 205
            Me.Label1.Text = "Item:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblItem.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblItem.Location = New System.Drawing.Point(80, 6)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(384, 24)
            Me.lblItem.TabIndex = 206
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tdgSNs
            '
            Me.tdgSNs.AllowColMove = False
            Me.tdgSNs.AllowColSelect = False
            Me.tdgSNs.AllowFilter = False
            Me.tdgSNs.AllowSort = False
            Me.tdgSNs.AllowUpdate = False
            Me.tdgSNs.BackColor = System.Drawing.Color.White
            Me.tdgSNs.CaptionHeight = 17
            Me.tdgSNs.ColumnHeaders = False
            Me.tdgSNs.FetchRowStyles = True
            Me.tdgSNs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSNs.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSNs.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgSNs.Location = New System.Drawing.Point(72, 112)
            Me.tdgSNs.Name = "tdgSNs"
            Me.tdgSNs.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSNs.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSNs.PreviewInfo.ZoomFactor = 75
            Me.tdgSNs.RecordSelectors = False
            Me.tdgSNs.RowHeight = 15
            Me.tdgSNs.Size = New System.Drawing.Size(424, 104)
            Me.tdgSNs.TabIndex = 204
            Me.tdgSNs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>100</Height><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 420, 100</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17" & _
            "</DefaultRecSelWidth><ClientArea>0, 0, 420, 100</ClientArea><PrintPageHeaderStyl" & _
            "e parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob" & _
            ">"
            '
            'txtSNs
            '
            Me.txtSNs.BackColor = System.Drawing.Color.White
            Me.txtSNs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSNs.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSNs.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSNs.Location = New System.Drawing.Point(72, 88)
            Me.txtSNs.Name = "txtSNs"
            Me.txtSNs.Size = New System.Drawing.Size(424, 23)
            Me.txtSNs.TabIndex = 202
            Me.txtSNs.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Navy
            Me.Label3.Location = New System.Drawing.Point(24, 88)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(48, 21)
            Me.Label3.TabIndex = 203
            Me.Label3.Text = "SNs:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.Beige
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExpirationDate, Me.lbllblExpirationDate, Me.lblExpirationDate, Me.btnResetInnerCarton, Me.pnlInnerCarton, Me.chkPrintInnerCartonLabel, Me.btnInnerCartonRemoveAll, Me.btnInnerCartonReprintLabel, Me.btnInnerCartonRemoveOne, Me.btnInnerCartonComplete, Me.tdgInnerCartonSNs, Me.Label6, Me.txtInnerCartonSN})
            Me.TabPage2.Location = New System.Drawing.Point(4, 25)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(1144, 659)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Inner Carton"
            '
            'btnExpirationDate
            '
            Me.btnExpirationDate.BackColor = System.Drawing.Color.DarkKhaki
            Me.btnExpirationDate.Location = New System.Drawing.Point(312, 336)
            Me.btnExpirationDate.Name = "btnExpirationDate"
            Me.btnExpirationDate.Size = New System.Drawing.Size(96, 40)
            Me.btnExpirationDate.TabIndex = 220
            Me.btnExpirationDate.Text = "Select Date"
            '
            'lbllblExpirationDate
            '
            Me.lbllblExpirationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblExpirationDate.ForeColor = System.Drawing.Color.Navy
            Me.lbllblExpirationDate.Location = New System.Drawing.Point(24, 344)
            Me.lbllblExpirationDate.Name = "lbllblExpirationDate"
            Me.lbllblExpirationDate.Size = New System.Drawing.Size(112, 32)
            Me.lbllblExpirationDate.TabIndex = 219
            Me.lbllblExpirationDate.Text = " Expiration Date:"
            Me.lbllblExpirationDate.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblExpirationDate
            '
            Me.lblExpirationDate.BackColor = System.Drawing.Color.White
            Me.lblExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblExpirationDate.Location = New System.Drawing.Point(136, 344)
            Me.lblExpirationDate.Name = "lblExpirationDate"
            Me.lblExpirationDate.Size = New System.Drawing.Size(168, 24)
            Me.lblExpirationDate.TabIndex = 218
            '
            'btnResetInnerCarton
            '
            Me.btnResetInnerCarton.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.btnResetInnerCarton.ForeColor = System.Drawing.Color.Green
            Me.btnResetInnerCarton.Location = New System.Drawing.Point(432, 136)
            Me.btnResetInnerCarton.Name = "btnResetInnerCarton"
            Me.btnResetInnerCarton.Size = New System.Drawing.Size(208, 32)
            Me.btnResetInnerCarton.TabIndex = 217
            Me.btnResetInnerCarton.Text = "Reset"
            '
            'pnlInnerCarton
            '
            Me.pnlInnerCarton.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblInnerCartonSIMItem, Me.Label4, Me.txtInnerCarton, Me.lblInnerCartonUPC, Me.Label11, Me.lblInnerCartonItem, Me.Label5, Me.lblQty, Me.txtInnerCartonQty, Me.lblCarton})
            Me.pnlInnerCarton.Location = New System.Drawing.Point(8, 16)
            Me.pnlInnerCarton.Name = "pnlInnerCarton"
            Me.pnlInnerCarton.Size = New System.Drawing.Size(576, 112)
            Me.pnlInnerCarton.TabIndex = 210
            '
            'lblInnerCartonSIMItem
            '
            Me.lblInnerCartonSIMItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInnerCartonSIMItem.Location = New System.Drawing.Point(128, 64)
            Me.lblInnerCartonSIMItem.Name = "lblInnerCartonSIMItem"
            Me.lblInnerCartonSIMItem.Size = New System.Drawing.Size(296, 24)
            Me.lblInnerCartonSIMItem.TabIndex = 207
            Me.lblInnerCartonSIMItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Navy
            Me.Label4.Location = New System.Drawing.Point(32, 64)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(96, 24)
            Me.Label4.TabIndex = 206
            Me.Label4.Text = "SIM Item:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInnerCarton
            '
            Me.txtInnerCarton.BackColor = System.Drawing.Color.White
            Me.txtInnerCarton.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtInnerCarton.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtInnerCarton.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtInnerCarton.Location = New System.Drawing.Point(128, 14)
            Me.txtInnerCarton.Name = "txtInnerCarton"
            Me.txtInnerCarton.Size = New System.Drawing.Size(272, 23)
            Me.txtInnerCarton.TabIndex = 193
            Me.txtInnerCarton.Text = ""
            '
            'lblInnerCartonUPC
            '
            Me.lblInnerCartonUPC.Location = New System.Drawing.Point(128, 88)
            Me.lblInnerCartonUPC.Name = "lblInnerCartonUPC"
            Me.lblInnerCartonUPC.Size = New System.Drawing.Size(272, 24)
            Me.lblInnerCartonUPC.TabIndex = 205
            Me.lblInnerCartonUPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Navy
            Me.Label11.Location = New System.Drawing.Point(48, 88)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 24)
            Me.Label11.TabIndex = 204
            Me.Label11.Text = "UPC(14):"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInnerCartonItem
            '
            Me.lblInnerCartonItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInnerCartonItem.Location = New System.Drawing.Point(128, 40)
            Me.lblInnerCartonItem.Name = "lblInnerCartonItem"
            Me.lblInnerCartonItem.Size = New System.Drawing.Size(296, 24)
            Me.lblInnerCartonItem.TabIndex = 203
            Me.lblInnerCartonItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Navy
            Me.Label5.Location = New System.Drawing.Point(32, 40)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(96, 24)
            Me.Label5.TabIndex = 202
            Me.Label5.Text = "Item:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblQty
            '
            Me.lblQty.BackColor = System.Drawing.Color.Transparent
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.ForeColor = System.Drawing.Color.Navy
            Me.lblQty.Location = New System.Drawing.Point(424, 16)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(64, 21)
            Me.lblQty.TabIndex = 198
            Me.lblQty.Text = "Qty:"
            Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInnerCartonQty
            '
            Me.txtInnerCartonQty.BackColor = System.Drawing.Color.White
            Me.txtInnerCartonQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInnerCartonQty.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtInnerCartonQty.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtInnerCartonQty.Location = New System.Drawing.Point(488, 14)
            Me.txtInnerCartonQty.Name = "txtInnerCartonQty"
            Me.txtInnerCartonQty.Size = New System.Drawing.Size(68, 33)
            Me.txtInnerCartonQty.TabIndex = 197
            Me.txtInnerCartonQty.Text = ""
            '
            'lblCarton
            '
            Me.lblCarton.BackColor = System.Drawing.Color.Transparent
            Me.lblCarton.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCarton.ForeColor = System.Drawing.Color.Navy
            Me.lblCarton.Location = New System.Drawing.Point(8, 16)
            Me.lblCarton.Name = "lblCarton"
            Me.lblCarton.Size = New System.Drawing.Size(120, 21)
            Me.lblCarton.TabIndex = 194
            Me.lblCarton.Text = "Inner Carton:"
            Me.lblCarton.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkPrintInnerCartonLabel
            '
            Me.chkPrintInnerCartonLabel.ForeColor = System.Drawing.Color.Black
            Me.chkPrintInnerCartonLabel.Location = New System.Drawing.Point(432, 328)
            Me.chkPrintInnerCartonLabel.Name = "chkPrintInnerCartonLabel"
            Me.chkPrintInnerCartonLabel.Size = New System.Drawing.Size(208, 16)
            Me.chkPrintInnerCartonLabel.TabIndex = 216
            Me.chkPrintInnerCartonLabel.Text = "Print Inner Carton  Label"
            '
            'btnInnerCartonRemoveAll
            '
            Me.btnInnerCartonRemoveAll.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.btnInnerCartonRemoveAll.Location = New System.Drawing.Point(536, 176)
            Me.btnInnerCartonRemoveAll.Name = "btnInnerCartonRemoveAll"
            Me.btnInnerCartonRemoveAll.Size = New System.Drawing.Size(104, 40)
            Me.btnInnerCartonRemoveAll.TabIndex = 213
            Me.btnInnerCartonRemoveAll.Text = "Remove All SNs"
            '
            'btnInnerCartonReprintLabel
            '
            Me.btnInnerCartonReprintLabel.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.btnInnerCartonReprintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnInnerCartonReprintLabel.ForeColor = System.Drawing.Color.DarkRed
            Me.btnInnerCartonReprintLabel.Location = New System.Drawing.Point(432, 224)
            Me.btnInnerCartonReprintLabel.Name = "btnInnerCartonReprintLabel"
            Me.btnInnerCartonReprintLabel.Size = New System.Drawing.Size(208, 40)
            Me.btnInnerCartonReprintLabel.TabIndex = 212
            Me.btnInnerCartonReprintLabel.Text = "Reprint Inner Carton Label"
            '
            'btnInnerCartonRemoveOne
            '
            Me.btnInnerCartonRemoveOne.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.btnInnerCartonRemoveOne.Location = New System.Drawing.Point(432, 176)
            Me.btnInnerCartonRemoveOne.Name = "btnInnerCartonRemoveOne"
            Me.btnInnerCartonRemoveOne.Size = New System.Drawing.Size(104, 40)
            Me.btnInnerCartonRemoveOne.TabIndex = 211
            Me.btnInnerCartonRemoveOne.Text = "Remove One SN"
            '
            'btnInnerCartonComplete
            '
            Me.btnInnerCartonComplete.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.btnInnerCartonComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnInnerCartonComplete.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnInnerCartonComplete.Location = New System.Drawing.Point(432, 272)
            Me.btnInnerCartonComplete.Name = "btnInnerCartonComplete"
            Me.btnInnerCartonComplete.Size = New System.Drawing.Size(208, 56)
            Me.btnInnerCartonComplete.TabIndex = 209
            Me.btnInnerCartonComplete.Text = "Complete Inner Carton"
            '
            'tdgInnerCartonSNs
            '
            Me.tdgInnerCartonSNs.AllowColMove = False
            Me.tdgInnerCartonSNs.AllowColSelect = False
            Me.tdgInnerCartonSNs.AllowFilter = False
            Me.tdgInnerCartonSNs.AllowSort = False
            Me.tdgInnerCartonSNs.AllowUpdate = False
            Me.tdgInnerCartonSNs.BackColor = System.Drawing.Color.White
            Me.tdgInnerCartonSNs.CaptionHeight = 17
            Me.tdgInnerCartonSNs.ColumnHeaders = False
            Me.tdgInnerCartonSNs.FetchRowStyles = True
            Me.tdgInnerCartonSNs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgInnerCartonSNs.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgInnerCartonSNs.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgInnerCartonSNs.Location = New System.Drawing.Point(136, 160)
            Me.tdgInnerCartonSNs.Name = "tdgInnerCartonSNs"
            Me.tdgInnerCartonSNs.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgInnerCartonSNs.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgInnerCartonSNs.PreviewInfo.ZoomFactor = 75
            Me.tdgInnerCartonSNs.RecordSelectors = False
            Me.tdgInnerCartonSNs.RowHeight = 15
            Me.tdgInnerCartonSNs.Size = New System.Drawing.Size(272, 168)
            Me.tdgInnerCartonSNs.TabIndex = 208
            Me.tdgInnerCartonSNs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>164</Height><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 268, 164</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17" & _
            "</DefaultRecSelWidth><ClientArea>0, 0, 268, 164</ClientArea><PrintPageHeaderStyl" & _
            "e parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob" & _
            ">"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Navy
            Me.Label6.Location = New System.Drawing.Point(8, 136)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(128, 21)
            Me.Label6.TabIndex = 207
            Me.Label6.Text = "SN:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInnerCartonSN
            '
            Me.txtInnerCartonSN.BackColor = System.Drawing.Color.White
            Me.txtInnerCartonSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInnerCartonSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtInnerCartonSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtInnerCartonSN.Location = New System.Drawing.Point(136, 136)
            Me.txtInnerCartonSN.Name = "txtInnerCartonSN"
            Me.txtInnerCartonSN.Size = New System.Drawing.Size(272, 23)
            Me.txtInnerCartonSN.TabIndex = 206
            Me.txtInnerCartonSN.Text = ""
            '
            'TabPage3
            '
            Me.TabPage3.BackColor = System.Drawing.Color.Wheat
            Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnResetMasterCarton, Me.chkPrintMasterCartonLabel, Me.btnMasterCartonRemoveAll, Me.btnMasterCartonReprintLabel, Me.btnMasterCartonRemoveOne, Me.pnlMasterCarton, Me.btnMasterCartonComplete, Me.tdgInnerCartonNumbers, Me.Label17, Me.txtInnerCartonNumber})
            Me.TabPage3.Location = New System.Drawing.Point(4, 25)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(1144, 659)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Master Carton"
            '
            'btnResetMasterCarton
            '
            Me.btnResetMasterCarton.BackColor = System.Drawing.Color.BurlyWood
            Me.btnResetMasterCarton.ForeColor = System.Drawing.Color.Green
            Me.btnResetMasterCarton.Location = New System.Drawing.Point(432, 136)
            Me.btnResetMasterCarton.Name = "btnResetMasterCarton"
            Me.btnResetMasterCarton.Size = New System.Drawing.Size(208, 32)
            Me.btnResetMasterCarton.TabIndex = 218
            Me.btnResetMasterCarton.Text = "Reset"
            '
            'chkPrintMasterCartonLabel
            '
            Me.chkPrintMasterCartonLabel.ForeColor = System.Drawing.Color.Black
            Me.chkPrintMasterCartonLabel.Location = New System.Drawing.Point(432, 336)
            Me.chkPrintMasterCartonLabel.Name = "chkPrintMasterCartonLabel"
            Me.chkPrintMasterCartonLabel.Size = New System.Drawing.Size(160, 16)
            Me.chkPrintMasterCartonLabel.TabIndex = 216
            Me.chkPrintMasterCartonLabel.Text = "Print Carton  Label"
            '
            'btnMasterCartonRemoveAll
            '
            Me.btnMasterCartonRemoveAll.BackColor = System.Drawing.Color.BurlyWood
            Me.btnMasterCartonRemoveAll.Location = New System.Drawing.Point(536, 176)
            Me.btnMasterCartonRemoveAll.Name = "btnMasterCartonRemoveAll"
            Me.btnMasterCartonRemoveAll.Size = New System.Drawing.Size(104, 40)
            Me.btnMasterCartonRemoveAll.TabIndex = 213
            Me.btnMasterCartonRemoveAll.Text = "Remove All"
            '
            'btnMasterCartonReprintLabel
            '
            Me.btnMasterCartonReprintLabel.BackColor = System.Drawing.Color.BurlyWood
            Me.btnMasterCartonReprintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMasterCartonReprintLabel.ForeColor = System.Drawing.Color.DarkRed
            Me.btnMasterCartonReprintLabel.Location = New System.Drawing.Point(432, 224)
            Me.btnMasterCartonReprintLabel.Name = "btnMasterCartonReprintLabel"
            Me.btnMasterCartonReprintLabel.Size = New System.Drawing.Size(208, 40)
            Me.btnMasterCartonReprintLabel.TabIndex = 212
            Me.btnMasterCartonReprintLabel.Text = "Reprint Master Carton Label"
            '
            'btnMasterCartonRemoveOne
            '
            Me.btnMasterCartonRemoveOne.BackColor = System.Drawing.Color.BurlyWood
            Me.btnMasterCartonRemoveOne.Location = New System.Drawing.Point(432, 176)
            Me.btnMasterCartonRemoveOne.Name = "btnMasterCartonRemoveOne"
            Me.btnMasterCartonRemoveOne.Size = New System.Drawing.Size(104, 40)
            Me.btnMasterCartonRemoveOne.TabIndex = 211
            Me.btnMasterCartonRemoveOne.Text = "Remove One"
            '
            'pnlMasterCarton
            '
            Me.pnlMasterCarton.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMasterCartonSIMItem, Me.Label7, Me.txtMasterCarton, Me.lblMasterCartonUPC, Me.Label12, Me.lblMasterCartonItem, Me.Label14, Me.Label15, Me.txtMasterCartonQty, Me.Label16})
            Me.pnlMasterCarton.Location = New System.Drawing.Point(8, 16)
            Me.pnlMasterCarton.Name = "pnlMasterCarton"
            Me.pnlMasterCarton.Size = New System.Drawing.Size(648, 112)
            Me.pnlMasterCarton.TabIndex = 210
            '
            'lblMasterCartonSIMItem
            '
            Me.lblMasterCartonSIMItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMasterCartonSIMItem.Location = New System.Drawing.Point(128, 64)
            Me.lblMasterCartonSIMItem.Name = "lblMasterCartonSIMItem"
            Me.lblMasterCartonSIMItem.Size = New System.Drawing.Size(296, 24)
            Me.lblMasterCartonSIMItem.TabIndex = 209
            Me.lblMasterCartonSIMItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Navy
            Me.Label7.Location = New System.Drawing.Point(32, 64)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(96, 24)
            Me.Label7.TabIndex = 208
            Me.Label7.Text = "SIM Item:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMasterCarton
            '
            Me.txtMasterCarton.BackColor = System.Drawing.Color.White
            Me.txtMasterCarton.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtMasterCarton.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMasterCarton.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtMasterCarton.Location = New System.Drawing.Point(128, 14)
            Me.txtMasterCarton.Name = "txtMasterCarton"
            Me.txtMasterCarton.Size = New System.Drawing.Size(272, 23)
            Me.txtMasterCarton.TabIndex = 193
            Me.txtMasterCarton.Text = ""
            '
            'lblMasterCartonUPC
            '
            Me.lblMasterCartonUPC.Location = New System.Drawing.Point(128, 88)
            Me.lblMasterCartonUPC.Name = "lblMasterCartonUPC"
            Me.lblMasterCartonUPC.Size = New System.Drawing.Size(264, 24)
            Me.lblMasterCartonUPC.TabIndex = 205
            Me.lblMasterCartonUPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label12
            '
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Navy
            Me.Label12.Location = New System.Drawing.Point(48, 88)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(80, 24)
            Me.Label12.TabIndex = 204
            Me.Label12.Text = "UPC(14):"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMasterCartonItem
            '
            Me.lblMasterCartonItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMasterCartonItem.Location = New System.Drawing.Point(128, 40)
            Me.lblMasterCartonItem.Name = "lblMasterCartonItem"
            Me.lblMasterCartonItem.Size = New System.Drawing.Size(296, 24)
            Me.lblMasterCartonItem.TabIndex = 203
            Me.lblMasterCartonItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label14
            '
            Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.Navy
            Me.Label14.Location = New System.Drawing.Point(32, 40)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(96, 24)
            Me.Label14.TabIndex = 202
            Me.Label14.Text = "Item:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.Navy
            Me.Label15.Location = New System.Drawing.Point(424, 16)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(64, 21)
            Me.Label15.TabIndex = 198
            Me.Label15.Text = "Qty:"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMasterCartonQty
            '
            Me.txtMasterCartonQty.BackColor = System.Drawing.Color.White
            Me.txtMasterCartonQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMasterCartonQty.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMasterCartonQty.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtMasterCartonQty.Location = New System.Drawing.Point(488, 14)
            Me.txtMasterCartonQty.Name = "txtMasterCartonQty"
            Me.txtMasterCartonQty.Size = New System.Drawing.Size(68, 33)
            Me.txtMasterCartonQty.TabIndex = 197
            Me.txtMasterCartonQty.Text = ""
            '
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.Transparent
            Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.Navy
            Me.Label16.Location = New System.Drawing.Point(8, 16)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(120, 21)
            Me.Label16.TabIndex = 194
            Me.Label16.Text = "Master Carton:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnMasterCartonComplete
            '
            Me.btnMasterCartonComplete.BackColor = System.Drawing.Color.BurlyWood
            Me.btnMasterCartonComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnMasterCartonComplete.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnMasterCartonComplete.Location = New System.Drawing.Point(432, 272)
            Me.btnMasterCartonComplete.Name = "btnMasterCartonComplete"
            Me.btnMasterCartonComplete.Size = New System.Drawing.Size(208, 56)
            Me.btnMasterCartonComplete.TabIndex = 209
            Me.btnMasterCartonComplete.Text = "Complete Master Carton"
            '
            'tdgInnerCartonNumbers
            '
            Me.tdgInnerCartonNumbers.AllowColMove = False
            Me.tdgInnerCartonNumbers.AllowColSelect = False
            Me.tdgInnerCartonNumbers.AllowFilter = False
            Me.tdgInnerCartonNumbers.AllowSort = False
            Me.tdgInnerCartonNumbers.AllowUpdate = False
            Me.tdgInnerCartonNumbers.BackColor = System.Drawing.Color.White
            Me.tdgInnerCartonNumbers.CaptionHeight = 17
            Me.tdgInnerCartonNumbers.ColumnHeaders = False
            Me.tdgInnerCartonNumbers.FetchRowStyles = True
            Me.tdgInnerCartonNumbers.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgInnerCartonNumbers.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgInnerCartonNumbers.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgInnerCartonNumbers.Location = New System.Drawing.Point(136, 160)
            Me.tdgInnerCartonNumbers.Name = "tdgInnerCartonNumbers"
            Me.tdgInnerCartonNumbers.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgInnerCartonNumbers.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgInnerCartonNumbers.PreviewInfo.ZoomFactor = 75
            Me.tdgInnerCartonNumbers.RecordSelectors = False
            Me.tdgInnerCartonNumbers.RowHeight = 15
            Me.tdgInnerCartonNumbers.Size = New System.Drawing.Size(272, 168)
            Me.tdgInnerCartonNumbers.TabIndex = 208
            Me.tdgInnerCartonNumbers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>164</Height><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 268, 164</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17" & _
            "</DefaultRecSelWidth><ClientArea>0, 0, 268, 164</ClientArea><PrintPageHeaderStyl" & _
            "e parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob" & _
            ">"
            '
            'Label17
            '
            Me.Label17.BackColor = System.Drawing.Color.Transparent
            Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.Navy
            Me.Label17.Location = New System.Drawing.Point(8, 136)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(128, 21)
            Me.Label17.TabIndex = 207
            Me.Label17.Text = "Inner Carton:"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtInnerCartonNumber
            '
            Me.txtInnerCartonNumber.BackColor = System.Drawing.Color.White
            Me.txtInnerCartonNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInnerCartonNumber.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtInnerCartonNumber.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtInnerCartonNumber.Location = New System.Drawing.Point(136, 136)
            Me.txtInnerCartonNumber.Name = "txtInnerCartonNumber"
            Me.txtInnerCartonNumber.Size = New System.Drawing.Size(272, 23)
            Me.txtInnerCartonNumber.TabIndex = 206
            Me.txtInnerCartonNumber.Text = ""
            '
            'TabPage4
            '
            Me.TabPage4.BackColor = System.Drawing.Color.LightGray
            Me.TabPage4.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnResetPallet, Me.chkPrintPalletLabel, Me.btnPalletRemoveAll, Me.btnPalletReprintLabel, Me.btnPalletRemoveOne, Me.pnlPallet, Me.btnPalletComplete, Me.tdgPallet, Me.Label23, Me.txtMasterCartonNo})
            Me.TabPage4.Location = New System.Drawing.Point(4, 25)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Size = New System.Drawing.Size(1144, 659)
            Me.TabPage4.TabIndex = 3
            Me.TabPage4.Text = "Build Pallet"
            '
            'btnResetPallet
            '
            Me.btnResetPallet.BackColor = System.Drawing.Color.DarkGray
            Me.btnResetPallet.ForeColor = System.Drawing.Color.Green
            Me.btnResetPallet.Location = New System.Drawing.Point(432, 112)
            Me.btnResetPallet.Name = "btnResetPallet"
            Me.btnResetPallet.Size = New System.Drawing.Size(176, 32)
            Me.btnResetPallet.TabIndex = 228
            Me.btnResetPallet.Text = "Reset"
            '
            'chkPrintPalletLabel
            '
            Me.chkPrintPalletLabel.ForeColor = System.Drawing.Color.Black
            Me.chkPrintPalletLabel.Location = New System.Drawing.Point(432, 368)
            Me.chkPrintPalletLabel.Name = "chkPrintPalletLabel"
            Me.chkPrintPalletLabel.Size = New System.Drawing.Size(160, 16)
            Me.chkPrintPalletLabel.TabIndex = 227
            Me.chkPrintPalletLabel.Text = "Print Pallet Label"
            '
            'btnPalletRemoveAll
            '
            Me.btnPalletRemoveAll.BackColor = System.Drawing.Color.DarkGray
            Me.btnPalletRemoveAll.ForeColor = System.Drawing.Color.Black
            Me.btnPalletRemoveAll.Location = New System.Drawing.Point(432, 200)
            Me.btnPalletRemoveAll.Name = "btnPalletRemoveAll"
            Me.btnPalletRemoveAll.Size = New System.Drawing.Size(176, 40)
            Me.btnPalletRemoveAll.TabIndex = 224
            Me.btnPalletRemoveAll.Text = "Remove All Cartons"
            '
            'btnPalletReprintLabel
            '
            Me.btnPalletReprintLabel.BackColor = System.Drawing.Color.DarkGray
            Me.btnPalletReprintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPalletReprintLabel.ForeColor = System.Drawing.Color.DarkRed
            Me.btnPalletReprintLabel.Location = New System.Drawing.Point(432, 256)
            Me.btnPalletReprintLabel.Name = "btnPalletReprintLabel"
            Me.btnPalletReprintLabel.Size = New System.Drawing.Size(176, 40)
            Me.btnPalletReprintLabel.TabIndex = 223
            Me.btnPalletReprintLabel.Text = "Reprint Pallet Label"
            '
            'btnPalletRemoveOne
            '
            Me.btnPalletRemoveOne.BackColor = System.Drawing.Color.DarkGray
            Me.btnPalletRemoveOne.ForeColor = System.Drawing.Color.Black
            Me.btnPalletRemoveOne.Location = New System.Drawing.Point(432, 152)
            Me.btnPalletRemoveOne.Name = "btnPalletRemoveOne"
            Me.btnPalletRemoveOne.Size = New System.Drawing.Size(176, 40)
            Me.btnPalletRemoveOne.TabIndex = 222
            Me.btnPalletRemoveOne.Text = "Remove One Carton"
            '
            'pnlPallet
            '
            Me.pnlPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPalletSIMItem, Me.Label8, Me.lblPalletItem, Me.Label21, Me.Label22, Me.txtPalletQty, Me.lblPallet, Me.txtPalletName})
            Me.pnlPallet.Location = New System.Drawing.Point(8, 16)
            Me.pnlPallet.Name = "pnlPallet"
            Me.pnlPallet.Size = New System.Drawing.Size(592, 96)
            Me.pnlPallet.TabIndex = 221
            '
            'lblPalletSIMItem
            '
            Me.lblPalletSIMItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletSIMItem.Location = New System.Drawing.Point(128, 64)
            Me.lblPalletSIMItem.Name = "lblPalletSIMItem"
            Me.lblPalletSIMItem.Size = New System.Drawing.Size(296, 24)
            Me.lblPalletSIMItem.TabIndex = 211
            Me.lblPalletSIMItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblPalletSIMItem.Visible = False
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Navy
            Me.Label8.Location = New System.Drawing.Point(32, 64)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(96, 24)
            Me.Label8.TabIndex = 210
            Me.Label8.Text = "SIM Item:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label8.Visible = False
            '
            'lblPalletItem
            '
            Me.lblPalletItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletItem.Location = New System.Drawing.Point(128, 40)
            Me.lblPalletItem.Name = "lblPalletItem"
            Me.lblPalletItem.Size = New System.Drawing.Size(296, 24)
            Me.lblPalletItem.TabIndex = 205
            Me.lblPalletItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label21
            '
            Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label21.ForeColor = System.Drawing.Color.Navy
            Me.Label21.Location = New System.Drawing.Point(16, 40)
            Me.Label21.Name = "Label21"
            Me.Label21.Size = New System.Drawing.Size(112, 24)
            Me.Label21.TabIndex = 204
            Me.Label21.Text = "Item:"
            Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label22
            '
            Me.Label22.BackColor = System.Drawing.Color.Transparent
            Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label22.ForeColor = System.Drawing.Color.Navy
            Me.Label22.Location = New System.Drawing.Point(424, 16)
            Me.Label22.Name = "Label22"
            Me.Label22.Size = New System.Drawing.Size(64, 21)
            Me.Label22.TabIndex = 198
            Me.Label22.Text = "Qty:"
            Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPalletQty
            '
            Me.txtPalletQty.BackColor = System.Drawing.Color.White
            Me.txtPalletQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPalletQty.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPalletQty.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtPalletQty.Location = New System.Drawing.Point(488, 8)
            Me.txtPalletQty.Name = "txtPalletQty"
            Me.txtPalletQty.Size = New System.Drawing.Size(68, 33)
            Me.txtPalletQty.TabIndex = 197
            Me.txtPalletQty.Text = ""
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.Transparent
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.Navy
            Me.lblPallet.Location = New System.Drawing.Point(24, 16)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(104, 21)
            Me.lblPallet.TabIndex = 194
            Me.lblPallet.Text = "Pallet Name:"
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPalletName
            '
            Me.txtPalletName.BackColor = System.Drawing.Color.White
            Me.txtPalletName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPalletName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPalletName.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtPalletName.Location = New System.Drawing.Point(128, 16)
            Me.txtPalletName.Name = "txtPalletName"
            Me.txtPalletName.Size = New System.Drawing.Size(272, 23)
            Me.txtPalletName.TabIndex = 193
            Me.txtPalletName.Text = ""
            '
            'btnPalletComplete
            '
            Me.btnPalletComplete.BackColor = System.Drawing.Color.DarkGray
            Me.btnPalletComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPalletComplete.ForeColor = System.Drawing.Color.DarkBlue
            Me.btnPalletComplete.Location = New System.Drawing.Point(432, 304)
            Me.btnPalletComplete.Name = "btnPalletComplete"
            Me.btnPalletComplete.Size = New System.Drawing.Size(176, 56)
            Me.btnPalletComplete.TabIndex = 220
            Me.btnPalletComplete.Text = "Complete Pallet"
            '
            'tdgPallet
            '
            Me.tdgPallet.AllowColMove = False
            Me.tdgPallet.AllowColSelect = False
            Me.tdgPallet.AllowFilter = False
            Me.tdgPallet.AllowSort = False
            Me.tdgPallet.AllowUpdate = False
            Me.tdgPallet.BackColor = System.Drawing.Color.White
            Me.tdgPallet.CaptionHeight = 17
            Me.tdgPallet.ColumnHeaders = False
            Me.tdgPallet.FetchRowStyles = True
            Me.tdgPallet.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgPallet.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgPallet.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.tdgPallet.Location = New System.Drawing.Point(136, 136)
            Me.tdgPallet.Name = "tdgPallet"
            Me.tdgPallet.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgPallet.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgPallet.PreviewInfo.ZoomFactor = 75
            Me.tdgPallet.RecordSelectors = False
            Me.tdgPallet.RowHeight = 15
            Me.tdgPallet.Size = New System.Drawing.Size(272, 456)
            Me.tdgPallet.TabIndex = 219
            Me.tdgPallet.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "se"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>452</Height><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 268, 452</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17" & _
            "</DefaultRecSelWidth><ClientArea>0, 0, 268, 452</ClientArea><PrintPageHeaderStyl" & _
            "e parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob" & _
            ">"
            '
            'Label23
            '
            Me.Label23.BackColor = System.Drawing.Color.Transparent
            Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label23.ForeColor = System.Drawing.Color.Navy
            Me.Label23.Location = New System.Drawing.Point(8, 112)
            Me.Label23.Name = "Label23"
            Me.Label23.Size = New System.Drawing.Size(128, 21)
            Me.Label23.TabIndex = 218
            Me.Label23.Text = "Master Carton No:"
            Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMasterCartonNo
            '
            Me.txtMasterCartonNo.BackColor = System.Drawing.Color.White
            Me.txtMasterCartonNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMasterCartonNo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMasterCartonNo.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtMasterCartonNo.Location = New System.Drawing.Point(136, 112)
            Me.txtMasterCartonNo.Name = "txtMasterCartonNo"
            Me.txtMasterCartonNo.Size = New System.Drawing.Size(272, 23)
            Me.txtMasterCartonNo.TabIndex = 217
            Me.txtMasterCartonNo.Text = ""
            '
            'lblWorkStation
            '
            Me.lblWorkStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkStation.ForeColor = System.Drawing.Color.MidnightBlue
            Me.lblWorkStation.Name = "lblWorkStation"
            Me.lblWorkStation.Size = New System.Drawing.Size(328, 24)
            Me.lblWorkStation.TabIndex = 211
            '
            'frmTFFK_BYOP_SimplePackProcess
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1240, 750)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWorkStation, Me.TabControl1})
            Me.Name = "frmTFFK_BYOP_SimplePackProcess"
            Me.Text = "frmTFFK_BYOP_SimplePackProcess"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.cboKittingSetup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlMaster.ResumeLayout(False)
            CType(Me.tdgSessionLog, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgSNs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            Me.pnlInnerCarton.ResumeLayout(False)
            CType(Me.tdgInnerCartonSNs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage3.ResumeLayout(False)
            Me.pnlMasterCarton.ResumeLayout(False)
            CType(Me.tdgInnerCartonNumbers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage4.ResumeLayout(False)
            Me.pnlPallet.ResumeLayout(False)
            CType(Me.tdgPallet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

      
        Private Sub frmTFFK_BYOP_SimplePackProcess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

                'HOLD THIS. So make these controls invisible-------------------------------------------------------------------------
                Me.lbllblExpirationDate.Visible = False : Me.lblExpirationDate.Visible = False : Me.btnExpirationDate.Visible = False
                '--------------------------------------------------------------------------------------------------------------------

                Me.pnlMaster.Visible = False
                Me.chkPrintInnerCartonLabel.Checked = True
                Me.chkPrintMasterCartonLabel.Checked = True
                Me.chkPrintPalletLabel.Checked = True

                If Me._strComputerName.Trim.Length = 0 Then
                    MessageBox.Show("No computer name (workstation). See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                Me.lblWorkStation.Text = "Workstation: " & Me._strComputerName

                'Populate Setup info
                dt = Me._objBYOP_Kitting.getActiveKittingSetUp(True, Me._objTFFK.ProcessTypeIDs.Simple_Packing, True)
                Misc.PopulateC1DropDownList(Me.cboKittingSetup, dt, "Kitting_SetUp", "KMSet_ID")
                Me.cboKittingSetup.SelectedValue = 0

                Me.cboKittingSetup.Focus()

                'Inner Carton
                Me.txtInnerCartonQty.Text = 0
                Me.txtInnerCarton.Text = ""
                Me.txtInnerCarton.ReadOnly = True : Me.txtInnerCarton.BackColor = System.Drawing.Color.Cornsilk
                Me.txtInnerCartonQty.ReadOnly = True : Me.txtInnerCartonQty.BackColor = System.Drawing.Color.Cornsilk
                Me.pnlInnerCarton.Visible = False

                'Master Carton
                Me.txtMasterCartonQty.Text = 0
                Me.txtMasterCarton.Text = ""
                Me.txtMasterCarton.ReadOnly = True : Me.txtMasterCarton.BackColor = System.Drawing.Color.Cornsilk
                Me.txtMasterCartonQty.ReadOnly = True : Me.txtMasterCartonQty.BackColor = System.Drawing.Color.Cornsilk
                Me.pnlMasterCarton.Visible = False

                'Pallet
                Me.txtPalletQty.Text = 0
                Me.txtPalletName.Text = ""
                Me.txtPalletName.ReadOnly = True : Me.txtPalletName.BackColor = System.Drawing.Color.Cornsilk
                Me.txtPalletQty.ReadOnly = True : Me.txtPalletQty.BackColor = System.Drawing.Color.Cornsilk
                Me.pnlPallet.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub frmTFFK_BYOP_SimplePackProcess_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)

                Me.ActiveControl = Me.cboKittingSetup
                Me.cboKittingSetup.Focus()
            End Try
        End Sub

        Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
            Try
                Dim g As Graphics = e.Graphics
                Dim tp As TabPage = TabControl1.TabPages(e.Index)
                Dim br As Brush
                Dim sf As New StringFormat()
                Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)
                Dim xFont As Font

                sf.Alignment = StringAlignment.Center

                Dim strTitle As String = tp.Text

                'If the current index is the Selected Index, change the color
                If TabControl1.SelectedIndex = e.Index Then
                    'this is the background color of the tabpage
                    'you could make this a stndard color for the selected page
                    br = New SolidBrush(tp.BackColor)
                    'this is the background color of the tab page
                    g.FillRectangle(br, e.Bounds)
                    'this is the background color of the tab page
                    'you could make this a stndard color for the selected page
                    br = New SolidBrush(tp.ForeColor)
                    'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                    xFont = New Font(TabControl1.Font, FontStyle.Bold)
                    g.DrawString(strTitle, xFont, br, r, sf)
                Else
                    'these are the standard colors for the unselected tab pages
                    br = New SolidBrush(Color.WhiteSmoke)
                    g.FillRectangle(br, e.Bounds)
                    br = New SolidBrush(Color.Black)
                    'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                    xFont = New Font(TabControl1.Font, FontStyle.Regular)
                    g.DrawString(strTitle, xFont, br, r, sf)
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub btnLoadProfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadProfile.Click
            Try
                Me.LoadSelectedSetupProfile()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnLoadProfile_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadSelectedSetupProfile()
            Dim dt As DataTable

            Try
                Me.cboKittingSetup.Enabled = True

                If Not Me.cboKittingSetup.SelectedValue > 0 OrElse Me.cboKittingSetup.SelectedValue = Nothing Then
                    MessageBox.Show("Please select a valid kitting setup profile.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cboKittingSetup.Focus() : Exit Sub
                End If

                'KDSet_ID, KMSet_ID, Component_Model_ID, Qty, Component_Type, OrderBy, IsKeySIM, UserID, UpdateDateTime, SIM, SIM_Desc
                Me._iKMSet_ID = Me.cboKittingSetup.SelectedValue
                dt = Me._objBYOP_SPP.getSetUpSIM_CardData(Me._iKMSet_ID)
                If Not dt.Rows.Count = 1 Then
                    MessageBox.Show("Invalid setup data (no data or dup data. See IT.).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cboKittingSetup.Focus() : Exit Sub
                End If

                'Clear
                Me.tdgSNs.DataSource = Nothing : Me.tdgSessionLog.DataSource = Nothing
                Me.txtSNs.Text = "" : Me.lblItem.Text = "" : Me.lblItemDesc.Text = "" : Me.lblItemUPC.Text = ""
                Me.chkAutoSave.Checked = True : Me.btnSave.Visible = False

                'KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton
                ', MaxCartonQtyPerPallet, PackQtyPerInnerCarton, Process_Type_ID, UserID, UpdateDateTime, IsActive, Model_Desc,Model_LDesc
                'Me.cboNPOrders.DataSource.Table.select("EW_ID = " & Me.cboNPOrders.SelectedValue)(0)("Brand")

                Me.lblItem.Text = Me.cboKittingSetup.DataSource.Table.select("KMSet_ID = " & Me.cboKittingSetup.SelectedValue)(0)("Model_Desc")
                Me.lblItemDesc.Text = Me.cboKittingSetup.DataSource.Table.select("KMSet_ID = " & Me.cboKittingSetup.SelectedValue)(0)("Model_LDesc")
                Me.lblItemUPC.Text = Me.cboKittingSetup.DataSource.Table.select("KMSet_ID = " & Me.cboKittingSetup.SelectedValue)(0)("ItemUPC")
                Me.lblUPC.Text = Me.cboKittingSetup.DataSource.Table.select("KMSet_ID = " & Me.cboKittingSetup.SelectedValue)(0)("UPC")
                Me.pnlMaster.Visible = True : Me.btnLoadProfile.Visible = False : Me.cboKittingSetup.Enabled = False
                Me._iMasterItem_Model_ID = Convert.ToInt32(Me.cboKittingSetup.DataSource.Table.select("KMSet_ID = " & Me.cboKittingSetup.SelectedValue)(0)("Master_Model_ID"))
                Me._iSIM_Model_ID = Convert.ToInt32(dt.Rows(0).Item("Component_Model_ID"))
                Me._iIsKeySIM = Convert.ToInt32(dt.Rows(0).Item("IsKeySIM"))

                Me.txtSNs.SelectAll() : Me.txtSNs.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  LoadSelectedSetupProfile", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
            End Try
        End Sub

        Private Sub chkAutoSave_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAutoSave.CheckedChanged
            Try
                If Me.chkAutoSave.Checked Then
                    Me.chkAutoSave.ForeColor = Color.Blue : Me.chkAutoSave.Font = New Font(Me.chkAutoSave.Font, FontStyle.Bold)
                    Me.btnSave.Visible = False
                Else
                    Me.chkAutoSave.ForeColor = Color.Black : Me.chkAutoSave.Font = New Font(Me.chkAutoSave.Font, FontStyle.Regular)
                    Me.btnSave.Visible = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub chkAutoSave_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtSNs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSNs.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtSNs.Text.Trim.Length > 0 Then
                    Me.ProcessSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSNs_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessSN()
            Dim strSNs As String = ""
            Dim strSNsFilter As String = ""
            Dim arrS() As String
            Dim s As String = ""
            Dim iSN_Count As Integer = 0
            Dim rowNew As DataRow, row As DataRow
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim bHasNewSN As Boolean = False

            Try
                strSNs = Me.txtSNs.Text.Trim
                If strSNs.Length = 0 Then Exit Sub

                If Not Me.IsValidSNs(strSNs) Then
                    MessageBox.Show("Invalid serial number(s)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSNs.SelectAll() : Me.txtSNs.Focus() : Exit Sub
                ElseIf Not Me.SNsAreScannedInTheList(strSNs) Then
                    MessageBox.Show("Already scanned!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSNs.SelectAll() : Me.txtSNs.Focus() : Exit Sub
                End If

                Me._dtSNs.Clear() : Me.tdgSNs.DataSource = Nothing

                'Get SNs
                iSN_Count = 0
                arrS = strSNs.Split(Me._strDelimiter)
                For Each s In arrS
                    rowNew = Me._dtSNs.NewRow
                    If s.Trim.Length > 0 Then
                        iSN_Count += 1
                        rowNew("Row") = iSN_Count : rowNew("SN") = s.Trim : rowNew("Status") = "Not Saved" : Me._dtSNs.Rows.Add(rowNew)
                        bHasNewSN = True
                    End If
                Next
                Me.tdgSNs.DataSource = Me._dtSNs.DefaultView
                For Each dbgc In Me.tdgSNs.Splits(0).DisplayColumns
                    dbgc.Locked = True : dbgc.AutoSize()
                    'If dbgc.Name = "SN" Then dbgc.Width = 200
                Next dbgc

                For Each row In Me._dtSNs.Rows
                    If strSNsFilter.Trim.Length = 0 Then
                        strSNsFilter = "'" & row("SN") & "'"
                    Else
                        strSNsFilter &= ",'" & row("SN") & "'"
                    End If
                Next
                If Me._objBYOP_SPP.AreSNsAlreadySaved(strSNsFilter) Then
                    MessageBox.Show("SNs are already saved! Can't save again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnSave.Enabled = False
                    Me.txtSNs.Text = "" : Me.txtSNs.Focus() : Exit Sub
                End If

                If bHasNewSN Then 'Keep Box log data
                    rowNew = Me._dtSessionLog.NewRow
                    Me._iSessionBoxID += 1 : Me._iSessionSN_Total += iSN_Count
                    rowNew("Box") = "Box " & Me._iSessionBoxID : rowNew("Qty of SN") = iSN_Count : Me._dtSessionLog.Rows.Add(rowNew)
                    Me.tdgSessionLog.Caption = "Total Box: " & Me._dtSessionLog.Rows.Count.ToString & ", Total SNs: " & Me._iSessionSN_Total.ToString
                    Me.tdgSessionLog.DataSource = Me._dtSessionLog.DefaultView
                    For Each dbgc In Me.tdgSessionLog.Splits(0).DisplayColumns
                        dbgc.Locked = True : dbgc.AutoSize()
                    Next dbgc

                    'Update box info
                    For Each row In Me._dtSNs.Rows
                        row.BeginEdit() : row("Box") = "Box " & Me._iSessionBoxID : row.AcceptChanges()
                    Next
                    For Each dbgc In Me.tdgSNs.Splits(0).DisplayColumns
                        dbgc.Locked = True : dbgc.AutoSize()
                    Next dbgc
                Else
                    MessageBox.Show("Failed to process SNs!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnSave.Enabled = False : Me.txtSNs.SelectAll() : Me.txtSNs.Focus() : Exit Sub
                End If

                If Not Me._dtSNs.Rows.Count > 0 Then
                    MessageBox.Show("No SN data!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnSave.Enabled = False : Exit Sub
                End If

                'Save data
                If Me.chkAutoSave.Checked Then
                    If Me.SaveSNs(Me._dtSNs) Then
                        For Each row In Me._dtSNs.Rows
                            row.BeginEdit() : row("Status") = "Saved" : row.AcceptChanges()
                        Next
                        For Each dbgc In Me.tdgSNs.Splits(0).DisplayColumns
                            dbgc.Locked = True : dbgc.AutoSize()
                        Next dbgc
                    Else
                        MessageBox.Show("Failed to save SNs!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    Me.txtSNs.Text = "" : Me.txtSNs.Focus()
                Else
                    Me.txtSNs.Text = "" : Me.btnSave.Focus()
                End If

                Me.btnSave.Enabled = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally

            End Try
        End Sub

        Private Function IsValidSNs(ByVal strSNs As String) As Boolean
            Dim i As Integer
            Dim c As Char
            Dim bRet As Boolean = True

            Try
                For Each c In strSNs
                    Select Case c
                        Case Me._strDelimiter, "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
                            bRet = True
                        Case Else
                            bRet = False : Exit For
                    End Select
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsValidSNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

            Return bRet
        End Function

        Private Function SNsAreScannedInTheList(ByVal strSNs As String) As Boolean
            Dim i As Integer
            Dim arrS() As String
            Dim s As String = ""
            Dim arrLstSNs As New ArrayList()
            Dim bRet As Boolean = True

            Try
                If Me.tdgSNs.RowCount > 0 Then
                    For i = 0 To Me.tdgSNs.RowCount - 1
                        arrLstSNs.Add(Me.tdgSNs.Columns("SN").CellText(i).ToString.Trim)
                    Next
                    If arrLstSNs.Count > 0 Then
                        arrS = strSNs.Split(Me._strDelimiter)
                        For Each s In arrS
                            If s.Trim.Length > 0 AndAlso arrLstSNs.Contains(s.Trim) Then
                                bRet = False : Exit For
                            End If
                        Next
                    End If
                End If

                Return bRet

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsValidSNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

        End Function

        Private Function SaveSNs(ByVal dtSNs As DataTable) As Boolean
            Dim i As Integer
            Try
                Return Me._objBYOP_SPP.SaveOpenBoxData(Me._strComputerName, Me._iKMSet_ID, dtSNs, Me.lblUPC.Text.Trim, Me.lblItemUPC.Text.Trim, Me._iMasterItem_Model_ID, Me._iSIM_Model_ID, Me._iIsKeySIM, Me._iUserID)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Function SaveSNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Dim row As DataRow
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim strSNsFilter As String = ""

            Try
                If Not Me._dtSNs.Rows.Count > 0 Then
                    MessageBox.Show("No SN data!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each row In Me._dtSNs.Rows
                    If strSNsFilter.Trim.Length = 0 Then
                        strSNsFilter = "'" & row("SN") & "'"
                    Else
                        strSNsFilter &= ",'" & row("SN") & "'"
                    End If
                Next

                If Me._objBYOP_SPP.AreSNsAlreadySaved(strSNsFilter) Then
                    MessageBox.Show("SNs are already saved! Can't save again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSNs.Text = "" : Me.txtSNs.Focus() : Exit Sub
                End If

                If Me.SaveSNs(Me._dtSNs) Then
                    For Each row In Me._dtSNs.Rows
                        row.BeginEdit() : row("Status") = "Saved" : row.AcceptChanges()
                    Next
                    For Each dbgc In Me.tdgSNs.Splits(0).DisplayColumns
                        dbgc.Locked = True : dbgc.AutoSize()
                    Next dbgc
                Else
                    MessageBox.Show("Failed to save SNs!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        '----------------------------------------------------------------------------------------------------------------------------------------------------------------
        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
            Try
                If Me.TabControl1.SelectedIndex = 1 Then
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus()
                ElseIf Me.TabControl1.SelectedIndex = 2 Then
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus()
                ElseIf Me.TabControl1.SelectedIndex = 3 Then
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub

        'Inner Carton----------------------------------------------------------------------------------------------------------------------------------------------------
        Private Sub ResetInnerCarton()
            Try
                Me._strInnerCartonLabel_PrinterName = ""
                Me._iInnerCarton_ID = 0
                If Not IsNothing(Me._dtInnerCarton) OrElse Me._dtInnerCarton.Rows.Count > 0 Then Me._dtInnerCarton.Clear()
                Me.tdgInnerCartonSNs.DataSource = Nothing
                Me._iPackQtyPerInnerCarton = 0
                Me._iInnerCartonSIMCard_Model_ID = 0
                Me._strGTIN_InnerCarton_UPC_Barcode = ""
                Me._strInnerCartonMasterItem_Desc = ""
                Me.txtInnerCartonQty.Text = 0
                Me.txtInnerCarton.Text = ""
                Me.txtInnerCarton.ReadOnly = True : Me.txtInnerCarton.BackColor = System.Drawing.Color.Cornsilk
                Me.txtInnerCartonQty.ReadOnly = True : Me.txtInnerCartonQty.BackColor = System.Drawing.Color.Cornsilk
                Me.lblInnerCartonItem.Text = ""
                Me.lblInnerCartonSIMItem.Text = ""
                Me.lblInnerCartonUPC.Text = ""
                Me.pnlInnerCarton.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub ResetInnerCarton", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtInnerCartonSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInnerCartonSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtInnerCartonSN.Text.Trim.Length > 0 Then
                    Me.ProcessInnerCartonSN()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtInnerCartonSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessInnerCartonSN()
            Dim strSN As String = ""
            Dim strInnerCartonName As String = ""

            Dim dt As DataTable
            Dim row As DataRow
            Dim iIdx As Integer = 0

            Try
                'Get  data
                strSN = Me.txtInnerCartonSN.Text.Trim
                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus()
                    Exit Sub
                ElseIf Me._iPackQtyPerInnerCarton > 0 AndAlso Convert.ToInt32(Me.txtInnerCartonQty.Text) >= Me._iPackQtyPerInnerCarton Then
                    MessageBox.Show("The inner carton is fulfilled (qty of per inner carton is " & Me._iPackQtyPerInnerCarton.ToString & "). " & Environment.NewLine & "Ready to complete the inner carton now.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus()
                    Exit Sub
                End If

                'Row, KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet
                ', PackQtyPerInnerCarton, GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate,HasExpirationDate, Process_Type_ID, UserID, UpdateDateTime
                ', IsActive, Pack_WO_ID, KP_ID, KPD_ID, SIM_Model_ID, SN, Master_Item, Master_Item_Desc, SIM_Item, SIM_Item_Desc
                dt = Me._objBYOP_SPP.getInnerCartonAvailableItemData(strSN)
                If Me._iInnerCarton_ID = 0 Then Me._dtInnerCarton = dt.Clone

                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate SNs. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus() : Exit Sub
                ElseIf Not dt.Rows.Count > 0 Then
                    MessageBox.Show("Can't find this SN '" & strSN & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus() : Exit Sub
                ElseIf Me._dtInnerCarton.Rows.Count > 0 Then 'i.e., =1
                    'HOLD THIS
                    'Me._HasExpirationDate = False
                    'If Me._iInnerCarton_ID = 0 Then
                    '    If Convert.ToInt32(Me._dtInnerCarton.Rows(0).Item("HasExpirationDate")) = 1 Then Me._HasExpirationDate = True
                    'Else
                    '    If Convert.ToInt32(Me._dtInnerCarton.Rows(0).Item("HasExpirationDate")) = 1 AndAlso Me._HasExpirationDate = False Then
                    '        MessageBox.Show("Invalid HasExpirationDate for this SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus()
                    '        Exit Sub
                    '    End If
                    '    If Convert.ToInt32(Me._dtInnerCarton.Rows(0).Item("HasExpirationDate")) = 0 AndAlso Me._HasExpirationDate = True Then
                    '        MessageBox.Show("Invalid HasExpirationDate for this SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus()
                    '        Exit Sub
                    '    End If
                    'End If

                    For Each row In Me._dtInnerCarton.Rows
                        If Convert.ToString(row("SN")).Trim.ToUpper = strSN.Trim.ToUpper Then
                            MessageBox.Show("SN '" & strSN & "' already in the list. Can't add it again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus() : Exit Sub
                        End If
                    Next
                    If Me._iInnerCartonSIMCard_Model_ID > 0 AndAlso Not Convert.ToInt32(Me._dtInnerCarton.Rows(0).Item("SIM_Model_ID")) = Me._iInnerCartonSIMCard_Model_ID Then
                        MessageBox.Show("Not the same model item. Can't add it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus() : Exit Sub
                    End If
                End If

                If Me._iInnerCarton_ID = 0 Then 'create inner carton name at the first SN
                    strInnerCartonName = Me._objBYOP_SPP.CreateInnerCartonName(Me._strComputerName, Me._iInnerCarton_ID)
                    Me.lblInnerCartonItem.Text = Convert.ToString(dt.Rows(0).Item("Master_Item"))
                    Me._strInnerCartonMasterItem_Desc = Convert.ToString(dt.Rows(0).Item("Master_Item_Desc"))
                    Me.lblInnerCartonSIMItem.Text = Convert.ToString(dt.Rows(0).Item("SIM_Item"))
                    Me.txtInnerCarton.Text = strInnerCartonName
                    Me._iInnerCartonSIMCard_Model_ID = Convert.ToInt32(dt.Rows(0).Item("SIM_Model_ID"))
                    Me.lblInnerCartonUPC.Text = Convert.ToString(dt.Rows(0).Item("GTIN_InnerCarton_UPC"))
                    Me._strGTIN_InnerCarton_UPC_Barcode = Me.lblInnerCartonUPC.Text.Replace("-", "")
                    Me._iPackQtyPerInnerCarton = Convert.ToInt32(dt.Rows(0).Item("PackQtyPerInnerCarton"))
                    If Not Me._iInnerCarton_ID > 0 Then
                        MessageBox.Show("Failed to create inner carton name. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus() : Exit Sub
                    End If
                    Me.pnlInnerCarton.Visible = True
                End If

                'Ready
                For Each row In dt.Rows 'must be 1 row 
                    iIdx = Me._dtInnerCarton.Rows.Count + 1
                    row.BeginEdit() : row("Row") = iIdx : row.AcceptChanges()
                    Me._dtInnerCarton.ImportRow(row)
                Next

                Me.BindInnerCartonSNsData(Me._dtInnerCarton)

                If Me._HasExpirationDate Then
                    Me.btnExpirationDate.Enabled = True
                Else
                    Me.lblExpirationDate.Text = "" : Me.btnExpirationDate.Enabled = False
                End If

                If Convert.ToInt32(Me.txtInnerCartonQty.Text) = Me._iPackQtyPerInnerCarton Then
                    Me.txtInnerCartonSN.Text = "" : Me.btnInnerCartonComplete.Focus()
                Else
                    Me.txtInnerCartonSN.Text = "" : Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ProcessInnerCartonSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                dt = Nothing
            End Try
        End Sub

        Private Sub BindInnerCartonSNsData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0

            Try
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    With Me.tdgInnerCartonSNs
                        .DataSource = dt.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Row", "SN"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                            'If dbgc.Name = "SN" Then dbgc.Width = 200
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                    End With
                End If

                Me.txtInnerCartonQty.Text = Me._dtInnerCarton.Rows.Count.ToString

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindInnerCartonSNsData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnInnerCartonRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInnerCartonRemoveOne.Click
            Dim strSN As String = ""
            Dim row As DataRow
            Dim dtTmp As DataTable
            Dim bFound As Boolean = False
            Dim i As Integer = 0

            Try
                If IsNothing(Me._dtInnerCarton) Then Exit Sub

                strSN = InputBox("Enter Item SN:", "Enter SN", "")

                If strSN.Trim.Length > 0 Then
                    If Me._dtInnerCarton.Rows.Count = 1 AndAlso strSN.Trim.ToUpper = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("SN")).ToUpper Then
                        If strSN.Trim.ToUpper = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("SN")).ToUpper Then
                            Me._dtInnerCarton.Clear()
                            Me.BindInnerCartonSNsData(Me._dtInnerCarton)
                        Else
                            MessageBox.Show("SN '" & strSN & "' not in the list.")
                        End If
                    Else
                        dtTmp = Me._dtInnerCarton.Clone
                        For Each row In Me._dtInnerCarton.Rows
                            If strSN.Trim.ToUpper = Convert.ToString(row("SN")).ToUpper Then
                                bFound = True
                            Else
                                i += 1
                                row.BeginEdit() : row("Row") = i : row.AcceptChanges()
                                dtTmp.ImportRow(row)
                            End If
                        Next
                        If bFound Then
                            Me._dtInnerCarton = dtTmp.Copy
                            Me.BindInnerCartonSNsData(Me._dtInnerCarton)
                        Else
                            MessageBox.Show("SN '" & strSN & "' not in the list.")
                        End If
                    End If
                Else
                    MessageBox.Show("You must enter an item SN.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnInnerCartonRemoveOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtInnerCartonSN.Text = "" : Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus()
            End Try
        End Sub

        Private Sub btnInnerCartonRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInnerCartonRemoveAll.Click
            Try
                If IsNothing(Me._dtInnerCarton) Then Exit Sub

                Me._dtInnerCarton.Clear()
                Me.BindInnerCartonSNsData(Me._dtInnerCarton)
                ' Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnInnerCartonRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtInnerCartonSN.Text = "" : Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus()
            End Try
        End Sub

        Private Sub btnResetInnerCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetInnerCarton.Click
            Try
                Dim result As Integer = MessageBox.Show("Do you want to reset all?", "Select", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Me.ResetInnerCarton()
                    Me.txtInnerCartonSN.Text = "" : Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnResetInnerCarton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnInnerCartonComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInnerCartonComplete.Click
            Dim strKP_IDs As String = ""
            Dim row As DataRow
            Dim i As Integer = 0
            Dim strPrinterName As String = ""

            Try
                Me.Cursor = Cursors.WaitCursor

                If IsNothing(Me._dtInnerCarton) Then
                    MessageBox.Show("Empty inner carton data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus() : Exit Sub
                ElseIf Not Me._iPackQtyPerInnerCarton > 0 Then
                    MessageBox.Show("Pack Qty Per Inner Carton must be >0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus() : Exit Sub
                End If

                If Me._HasExpirationDate AndAlso Me.lblExpirationDate.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please select a expiration date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.btnExpirationDate.Focus() : Exit Sub
                End If

                If Not Convert.ToInt32(Me.txtInnerCartonQty.Text) = Me._iPackQtyPerInnerCarton Then
                    MessageBox.Show("Not fulfilled the carton yet (need " & Me._iPackQtyPerInnerCarton.ToString & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus() : Exit Sub
                End If
                If Not Me._dtInnerCarton.Rows.Count = Convert.ToInt32(Me.txtInnerCartonQty.Text) Then
                    MessageBox.Show("The carton data rows don't match the qty. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus() : Exit Sub
                End If
                If Not Me._iInnerCarton_ID > 0 Then
                    MessageBox.Show("No Inner Carton ID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus() : Exit Sub
                End If
                If Me._objBYOP_SPP.IsInnerCartonClosed(Me._iInnerCarton_ID) Then
                    MessageBox.Show("The carton " & Me.txtInnerCarton.Text & " is closed or can't find it. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus() : Exit Sub
                End If

                'ready 
                'Row, KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet
                ', PackQtyPerInnerCarton, GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate, Process_Type_ID, UserID, UpdateDateTime
                ', IsActive, Pack_WO_ID, KP_ID, KPD_ID, SIM_Model_ID, SN, Master_Item, Master_Item_Desc, SIM_Item, SIM_Item_Desc
                For Each row In Me._dtInnerCarton.Rows
                    If strKP_IDs.Trim.Length = 0 Then
                        strKP_IDs = Convert.ToString(row("KP_ID"))
                    Else
                        strKP_IDs &= "," & Convert.ToString(row("KP_ID"))
                    End If
                Next

                'save data
                If Me._HasExpirationDate Then
                    i = Me._objBYOP_SPP.SaveInnerCartonData(Me._iInnerCarton_ID, Convert.ToInt32(Me.txtInnerCartonQty.Text), Convert.ToInt32(Me._dtInnerCarton.Rows(0).Item("SIM_Model_ID")), 1, Me._iUserID, strKP_IDs, Me.lblExpirationDate.Text.Trim)
                Else
                    i = Me._objBYOP_SPP.SaveInnerCartonData(Me._iInnerCarton_ID, Convert.ToInt32(Me.txtInnerCartonQty.Text), Convert.ToInt32(Me._dtInnerCarton.Rows(0).Item("SIM_Model_ID")), 1, Me._iUserID, strKP_IDs, "")
                End If

                If i = 0 Then
                    MessageBox.Show("Failed to save. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus() : Exit Sub
                End If

                'printmaster carton label
                If Me.chkPrintInnerCartonLabel.Checked Then
                    Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

                    Dim strItemDesc As String = ""
                    Dim strItem As String = "" : Dim strItem_BarCode As String = ""
                    Dim strUPC As String = "" : Dim strUPC_BarCode As String = ""
                    Dim strUPC_Desc As String = "" : Dim strUPC_Desc_BarCode As String = ""
                    Dim strMinSN As String = "" : Dim strMaxSN As String = ""
                    Dim strCartonNo As String = "" : Dim strCartonNo_BarCode As String = ""
                    Dim strCartonNo_Desc As String = "" : Dim strCartonNo_Desc_BarCode As String = ""
                    Dim strQty_Str As String = "" : Dim strQty_Str_BarCode As String = "" : Dim strVerControlNo As String = ""
                    Dim strCountry As String = "" : Dim strExpDate As String = ""
                    Dim strQR_Data As String = "" : Dim strQR_Data_BarCode As String = ""
                    Dim strPDF417_Data As String = "" : Dim strPDF417_Data_BarCode As String = ""
                    Dim strSep As String = "@"
                    Dim strLfCr As String = "\r" '\r = Carriage Return 

                    strItemDesc = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("Master_Item_Desc")).Trim
                    strItem = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("Master_Item")).Trim
                    strItem_BarCode = FontEncoder.Code128a(strItem)

                    strUPC = Me._strGTIN_InnerCarton_UPC_Barcode
                    strUPC_BarCode = FontEncoder.Code128a(Me._strGTIN_InnerCarton_UPC_Barcode)
                    strUPC_Desc = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("GTIN_InnerCarton_UPC"))
                    strUPC_Desc_BarCode = FontEncoder.Code128a(Me._dtInnerCarton.Rows(0).Item("GTIN_InnerCarton_UPC"))

                    strCartonNo = Me.txtInnerCarton.Text.Trim
                    strCartonNo_BarCode = FontEncoder.Code128a(Me.txtInnerCarton.Text.Trim)
                    strCartonNo_Desc = Me.txtInnerCarton.Text.Trim
                    strCartonNo_Desc_BarCode = FontEncoder.Code128a(Me.txtInnerCarton.Text.Trim)

                    strQty_Str = Me._dtInnerCarton.Rows.Count.ToString
                    strQty_Str_BarCode = FontEncoder.Code128a(strQty_Str)

                    strVerControlNo = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("VersionControl"))
                    strCountry = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("CountryOfOrigin"))
                    strExpDate = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("ExpirationDate"))
                    strPDF417_Data = strItem & strSep & strQty_Str & strSep & strCartonNo_Desc

                    Dim rowView As DataRowView
                    Dim v As DataView = Me._dtInnerCarton.DefaultView
                    Dim strTmp As String = ""
                    Dim p As Integer = 0

                    v.Sort = "SN Asc"
                    For Each rowView In v
                        p += 1
                        strTmp = rowView.Row("SN")
                        If p = 1 Then
                            strQR_Data = strTmp.Trim : strMinSN = strTmp
                            strPDF417_Data &= strSep & strTmp
                        Else
                            strQR_Data &= strSep & strTmp.Trim
                        End If
                        If p >= v.Table.Rows.Count Then strMaxSN = strTmp : strPDF417_Data &= strSep & strTmp & strSep & strSep & strExpDate
                    Next
                    strQR_Data_BarCode = Me.IDAutomation_QRFontEncoder(strQR_Data)
                    strPDF417_Data_BarCode = Me.IDAutomation_PDF417(strPDF417_Data)
                    strQR_Data_BarCode = strQR_Data_BarCode.Replace(Environment.NewLine, "\r\n")
                    strPDF417_Data_BarCode = strPDF417_Data_BarCode.Replace(Environment.NewLine, "\r\n")

                    FontEncoder = Nothing
                    strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Simple_Packing, Me._strComputerName, Me._objTFFK.SimplePackingLabels.Inner_Carton_Label)
                    Me._objBYOP_SPP.Print_SP_InnerCarton_Label(strItemDesc, strItem, strItem_BarCode, strUPC, strUPC_BarCode, strUPC_Desc, _
                                                               strUPC_Desc_BarCode, strMinSN, strMaxSN, strCartonNo, strCartonNo_BarCode, strCartonNo_Desc, strCartonNo_Desc_BarCode, _
                                                               strQty_Str, strQty_Str_BarCode, strVerControlNo, strCountry, strQR_Data, strQR_Data_BarCode, _
                                                               strPDF417_Data, strPDF417_Data_BarCode, strPrinterName, 1)
                End If

                Me.ResetInnerCarton()
                Me.txtInnerCartonSN.Text = "" : Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus()


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnInnerCartonComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Function IDAutomation_QRFontEncoder(ByVal DataToEncode As String) As String
            Dim ProcTilde As Integer
            ProcTilde = 1 'If = 1 the Tilde will be processed | http://www.idautomation.com/barcode-faq/2d/qr-code/#Control_Characters
            Dim EncMode As Integer
            EncMode = 0 '0=Binary | 1=0nly numbers and uppercase letters | 2=Numbers only
            Dim ErrorCorrectionLevel As Integer
            ErrorCorrectionLevel = 0 '0=15% | 1=30% | 2=7% | 3-25% | http://www.idautomation.com/barcode-faq/2d/qr-code/#Encoding_Modes
            Dim Version As Integer
            Version = 0 '0=Automatic | http://www.idautomation.com/barcode-faq/2d/qr-code/#Symbol_Version
            'Format the data to the QRCode Font by calling the Com DLL:
            Dim QRFontEncoder As QRCODELib.QRCode ' QRCode
            QRFontEncoder = New QRCODELib.QRCode() ' QRCode()
            QRFontEncoder.FontEncode(DataToEncode, ProcTilde, EncMode, Version, ErrorCorrectionLevel, IDAutomation_QRFontEncoder)
            QRFontEncoder = Nothing
        End Function

        Private Function IDAutomation_PDF417(ByVal DataToEncode As String, Optional ByVal EcLevel As Integer = 0, Optional ByVal TotalColumns As Integer = 0, Optional ByVal TotalRows As Integer = 0, Optional ByVal Truncated As Integer = 0, Optional ByVal PDFMode As Integer = 0, Optional ByVal ApplyTilde As Integer = 0) As String
            ' NOTE: Before this function will work you may have to add the
            ' DLL reference by choosing Tools - References and choose
            ' "IDAutomation PDF417 Barcode"
            Dim PDF417FontEncoder As PDF417Lib.PDF
            PDF417FontEncoder = New PDF417Lib.PDF()
            PDF417FontEncoder.FontEncode(DataToEncode, EcLevel, TotalColumns, TotalRows, Truncated, PDFMode, ApplyTilde, IDAutomation_PDF417)
            PDF417FontEncoder = Nothing
        End Function

        Private Sub btnInnerCartonReprintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInnerCartonReprintLabel.Click
            Dim dt As DataTable
            Dim strInnerCartonName As String = ""
            Dim strPrinterName As String = ""

            Dim strItemDesc As String = ""
            Dim strItem As String = "" : Dim strItem_BarCode As String = ""
            Dim strUPC As String = "" : Dim strUPC_BarCode As String = ""
            Dim strUPC_Desc As String = "" : Dim strUPC_Desc_BarCode As String = ""
            Dim strMinSN As String = "" : Dim strMaxSN As String = ""
            Dim strCartonNo As String = "" : Dim strCartonNo_BarCode As String = ""
            Dim strCartonNo_Desc As String = "" : Dim strCartonNo_Desc_BarCode As String = ""
            Dim strQty_Str As String = "" : Dim strQty_Str_BarCode As String = "" : Dim strVerControlNo As String = ""
            Dim strCountry As String = "" : Dim strExpDate As String = ""
            Dim strQR_Data As String = "" : Dim strQR_Data_BarCode As String = ""
            Dim strPDF417_Data As String = "" : Dim strPDF417_Data_BarCode As String = ""
            Dim strSep As String = "@"
            Dim strLfCr As String = "\r" '\r = Carriage Return 

            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try
                strInnerCartonName = InputBox("Enter an inner carton name:", "Input", "")

                If strInnerCartonName.Trim.Length < 13 Then 'IC00000000011
                    MessageBox.Show("You must enter a valid inner carton name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not strInnerCartonName.Trim.Substring(0, 2).ToUpper = Me._objTFFK._strBYOP_SP_InnerCartonName_PreFix.ToUpper Then
                    MessageBox.Show("Not a valid inner carton name for this process..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                dt = Me._objBYOP_SPP.getInnerCarton_ReprintLabelData(strInnerCartonName)
                'Row, KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet
                ', PackQtyPerInnerCarton, GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate, Process_Type_ID, UserID, UpdateDateTime
                ', IsActive, Pack_WO_ID, KP_ID, KPD_ID, SIM_Model_ID, SN, Master_Item, Master_Item_Desc, SIM_Item, SIM_Item_Desc, Carton_Name

                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No data for this inner carton '" & strInnerCartonName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                strItemDesc = Convert.ToString(dt.Rows(0).Item("Master_Item_Desc")).Trim
                strItem = Convert.ToString(dt.Rows(0).Item("Master_Item")).Trim
                strItem_BarCode = FontEncoder.Code128a(strItem)

                strUPC_Desc = Convert.ToString(dt.Rows(0).Item("GTIN_InnerCarton_UPC"))
                strUPC_Desc_BarCode = FontEncoder.Code128a(strUPC_Desc)
                strUPC = strUPC_Desc.Replace("-", "")
                strUPC_BarCode = FontEncoder.Code128a(strUPC)
               
                strCartonNo = Convert.ToString(dt.Rows(0).Item("Carton_Name"))
                strCartonNo_BarCode = FontEncoder.Code128a(strCartonNo)
                strCartonNo_Desc = strCartonNo
                strCartonNo_Desc_BarCode = FontEncoder.Code128a(strCartonNo_Desc)

                strQty_Str = Convert.ToString(dt.Rows(0).Item("PackQtyPerInnerCarton")).Trim
                strQty_Str_BarCode = FontEncoder.Code128a(strQty_Str)

                strVerControlNo = Convert.ToString(dt.Rows(0).Item("VersionControl"))
                strCountry = Convert.ToString(dt.Rows(0).Item("CountryOfOrigin"))
                strExpDate = Convert.ToString(dt.Rows(0).Item("ExpirationDate"))
                strPDF417_Data = strItem & strSep & strQty_Str & strSep & strCartonNo_Desc

                Dim rowView As DataRowView
                Dim v As DataView = dt.DefaultView
                Dim strTmp As String = ""
                Dim p As Integer = 0

                v.Sort = "SN Asc"
                For Each rowView In v
                    p += 1
                    strTmp = rowView.Row("SN")
                    If p = 1 Then
                        strQR_Data = strTmp.Trim : strMinSN = strTmp
                        strPDF417_Data &= strSep & strTmp
                    Else
                        strQR_Data &= strSep & strTmp.Trim
                    End If
                    If p >= v.Table.Rows.Count Then strMaxSN = strTmp : strPDF417_Data &= strSep & strTmp & strSep & strSep & strExpDate
                Next
                strQR_Data_BarCode = Me.IDAutomation_QRFontEncoder(strQR_Data)
                strPDF417_Data_BarCode = Me.IDAutomation_PDF417(strPDF417_Data)
                strQR_Data_BarCode = strQR_Data_BarCode.Replace(Environment.NewLine, "\r\n")
                strPDF417_Data_BarCode = strPDF417_Data_BarCode.Replace(Environment.NewLine, "\r\n")

                FontEncoder = Nothing
                strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Simple_Packing, Me._strComputerName, Me._objTFFK.SimplePackingLabels.Inner_Carton_Label)
                Me._objBYOP_SPP.Print_SP_InnerCarton_Label(strItemDesc, strItem, strItem_BarCode, strUPC, strUPC_BarCode, strUPC_Desc, _
                                                           strUPC_Desc_BarCode, strMinSN, strMaxSN, strCartonNo, strCartonNo_BarCode, strCartonNo_Desc, strCartonNo_Desc_BarCode, _
                                                           strQty_Str, strQty_Str_BarCode, strVerControlNo, strCountry, strQR_Data, strQR_Data_BarCode, _
                                                           strPDF417_Data, strPDF417_Data_BarCode, strPrinterName, 1)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnInnerCartonReprintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        'Master Carton =============================================================================================================================================
        Private Sub ResetMasterCarton()
            Try
                Me._strMasterCartonLabel_PrinterName = ""
                Me._iMasterCarton_ID = 0
                If Not IsNothing(Me._dtMasterCarton) OrElse Me._dtMasterCarton.Rows.Count > 0 Then Me._dtMasterCarton.Clear()
                If Not IsNothing(Me._dtMasterCartonDetails) OrElse Me._dtMasterCartonDetails.Rows.Count > 0 Then Me._dtMasterCartonDetails.Clear()
                Me.tdgInnerCartonNumbers.DataSource = Nothing
                Me._iPackQtyPerMasterCarton = 0
                Me._iPackQtyPerInnerCarton4MC_Calc = 0
                Me._iTotalSNQtyPerPerMasterCarton = 0
                Me._iMasterCartonSIMCard_Model_ID = 0
                Me._iMasterCartonMasterItem_Model_ID = 0
                Me._strGTIN_MasterCarton_UPC_Barcode = ""
                Me._strMasterCartonMasterItem_Desc = ""
                Me.txtMasterCartonQty.Text = 0
                Me.txtMasterCarton.Text = ""
                Me.txtMasterCarton.ReadOnly = True : Me.txtMasterCarton.BackColor = System.Drawing.Color.Cornsilk
                Me.txtMasterCartonQty.ReadOnly = True : Me.txtMasterCartonQty.BackColor = System.Drawing.Color.Cornsilk
                Me.lblMasterCartonItem.Text = ""
                Me.lblMasterCartonSIMItem.Text = ""
                Me.lblMasterCartonUPC.Text = ""
                Me.pnlMasterCarton.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub ResetMasterCarton", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtInnerCartonNumber_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtInnerCartonNumber.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtInnerCartonNumber.Text.Trim.Length > 0 Then
                    Me.ProcessInnerCartonForMasterCarton()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtInnerCartonNumber_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessInnerCartonForMasterCarton()
            Dim strInnerCartonNumber As String = ""
            Dim strMasterCartonName As String = ""
            'Dim strMasterCartonName_PreFix As String = "MC"

            Dim dt As DataTable
            Dim row As DataRow
            Dim iIdx As Integer = 0
            Dim i As Integer = 0

            Try
                'Get  data
                strInnerCartonNumber = Me.txtInnerCartonNumber.Text.Trim
                If strInnerCartonNumber.Length = 0 Then
                    MessageBox.Show("Please enter an inner carton.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus()
                    Exit Sub
                ElseIf Me._iPackQtyPerMasterCarton > 0 AndAlso Convert.ToInt32(Me.txtMasterCartonQty.Text) >= Me._iPackQtyPerMasterCarton Then
                    MessageBox.Show("The master carton is fulfilled (qty of per carton is " & Me._iPackQtyPerMasterCarton.ToString & "). " & Environment.NewLine & "Ready to complete the carton now.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.Text = "" : Me.btnMasterCartonComplete.Focus()
                    Exit Sub
                End If

                dt = Me._objBYOP_SPP.getMasterCarton_AvailableInnerCartonData(strInnerCartonNumber)
                If Me._iMasterCarton_ID = 0 Then Me._dtMasterCarton = dt.Clone : Me._dtMasterCartonDetails = dt.Clone

                'If dt.Rows.Count > 1 Then
                '    MessageBox.Show("Duplicate inner carton number See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                'Else
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Can't find this inner carton '" & strInnerCartonNumber & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                ElseIf Me._dtMasterCarton.Rows.Count > 0 Then
                    For Each row In Me._dtMasterCarton.Rows
                        If Convert.ToString(row("InnerCarton_Name")).Trim.ToUpper = strInnerCartonNumber.Trim.ToUpper Then
                            MessageBox.Show("Inner carton '" & strInnerCartonNumber & "' already in the list. Can't add it again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                        End If
                    Next

                    'Hold this
                    'Me._HasExpirationDate4MasterCarton = False

                End If

                'GID,Row, KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet
                ', PackQtyPerInnerCarton, GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate, Process_Type_ID, UserID, UpdateDateTime
                ', IsActive, Pack_WO_ID, KP_ID, KPD_ID, SIM_Model_ID, SN, Master_Item, Master_Item_Desc, SIM_Item, SIM_Item_Desc, InnerCarton_Name, InnerCarton_Qty,InnerCartonExpirationDate
                'Ready: dt.Rows.Count=1
                If Me._iMasterCarton_ID = 0 Then 'create carton name at the first SN
                    strMasterCartonName = Me._objBYOP_Kitting.CreateMasterCartonName(Me._strComputerName, Me._iMasterCarton_ID, Me._objTFFK._strBYOP_SP_MasterCartonName_PreFix)
                    Me.lblMasterCartonItem.Text = Convert.ToString(dt.Rows(0).Item("Master_Item"))
                    Me.txtMasterCarton.Text = strMasterCartonName
                    Me._strMasterCartonMasterItem_Desc = Convert.ToString(dt.Rows(0).Item("Master_Item_Desc"))
                    Me._iMasterCartonSIMCard_Model_ID = Convert.ToInt32(dt.Rows(0).Item("SIM_Model_ID"))
                    Me._iMasterCartonMasterItem_Model_ID = Convert.ToInt32(dt.Rows(0).Item("Master_Model_ID"))
                    Me.lblMasterCartonUPC.Text = Convert.ToString(dt.Rows(0).Item("GTIN_MasterCarton_UPC"))
                    Me._strGTIN_MasterCarton_UPC_Barcode = Me.lblMasterCartonUPC.Text.Replace("-", "")
                    Me._iPackQtyPerMasterCarton = Convert.ToInt32(dt.Rows(0).Item("PackQtyPerCarton"))
                    Me._iPackQtyPerInnerCarton4MC_Calc = Convert.ToInt32(dt.Rows(0).Item("PackQtyPerInnerCarton"))
                    Me._iTotalSNQtyPerPerMasterCarton = Me._iPackQtyPerMasterCarton * Me._iPackQtyPerInnerCarton4MC_Calc
                    If Not Me._iMasterCarton_ID > 0 Then
                        MessageBox.Show("Failed to create master carton name. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                    End If
                    Me.pnlMasterCarton.Visible = True
                End If

                'Ready
                i = 0
                For Each row In dt.Rows 'Details of Inner Carton
                    If i = 0 Then iIdx = Me._dtMasterCarton.Rows.Count + 1
                    row.BeginEdit() : row("GID") = iIdx : row.AcceptChanges()
                    If i = 0 Then
                        ' row.BeginEdit() : row("Row") = iIdx : row.AcceptChanges()
                        Me._dtMasterCarton.ImportRow(row)
                    End If
                    Me._dtMasterCartonDetails.ImportRow(row)
                    i += 1
                Next

                Me.BindMasterCartonData(Me._dtMasterCarton)

                If Convert.ToInt32(Me.txtMasterCartonQty.Text) = Me._iPackQtyPerMasterCarton Then
                    Me.txtInnerCartonNumber.Text = "" : Me.btnMasterCartonComplete.Focus()
                Else
                    Me.txtInnerCartonNumber.Text = "" : Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus()
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub ProcessInnerCartonForMasterCarton", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                dt = Nothing
            End Try
        End Sub

        Private Sub BindMasterCartonData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0

            Try
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    With Me.tdgInnerCartonNumbers
                        .DataSource = dt.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "GID", "InnerCarton_Name", "InnerCarton_Qty"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                            'If dbgc.Name = "SN" Then dbgc.Width = 200
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                        .Splits(0).DisplayColumns("InnerCarton_Qty").Button = True
                        .Splits(0).DisplayColumns("InnerCarton_Qty").ButtonAlways = True
                    End With
                End If

                Me.txtMasterCartonQty.Text = dt.Rows.Count.ToString

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  BindMasterCartonData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub tdgInnerCartonNumbers_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgInnerCartonNumbers.ButtonClick
            Dim iGID As Integer = 0
            Dim iRowIdx As Integer = 0
            Dim i As Integer = 0
            Dim row As DataRow
            Dim strInnerCartonName As String = ""
            Dim strMsg As String = "SNs are: " & Environment.NewLine

            Try
                iRowIdx = Me.tdgInnerCartonNumbers.Row
                iGID = Convert.ToInt32(Me.tdgInnerCartonNumbers.Columns("GID").CellText(iRowIdx))  'e.Column.DataColumn.CellText(iRowIdx)
                For Each row In Me._dtMasterCartonDetails.Rows
                    If i = 0 Then
                        strInnerCartonName = Convert.ToString(Me.tdgInnerCartonNumbers.Columns("InnerCarton_Name").CellText(iRowIdx))
                        strMsg = "This inner carton '" & strInnerCartonName & "' has SNs: " & Environment.NewLine
                    End If

                    If iGID = Convert.ToInt32(row("GID")) Then strMsg &= row("SN") & Environment.NewLine
                    i += 1
                Next
                MessageBox.Show(strMsg)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgInnerCartonNumbers_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnResetMasterCarton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetMasterCarton.Click
            Try
                Dim result As Integer = MessageBox.Show("Do you want to reset all?", "Select", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Me.ResetMasterCarton()
                    Me.txtInnerCartonNumber.Text = "" : Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnResetMasterCarton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnMasterCartonRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasterCartonRemoveOne.Click
            Dim strInnerCartonNo As String = ""
            Dim row, row2 As DataRow
            Dim dtTmp As DataTable
            Dim dtTmp_Details As DataTable
            Dim bFound As Boolean = False
            Dim i As Integer = 0
            Dim iOldGID As Integer = 0

            Try
                'GID,Row, KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet
                ', PackQtyPerInnerCarton, GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate, Process_Type_ID, UserID, UpdateDateTime
                ', IsActive, Pack_WO_ID, KP_ID, KPD_ID, SIM_Model_ID, SN, Master_Item, Master_Item_Desc, SIM_Item, SIM_Item_Desc, InnerCarton_Name, InnerCarton_Qty

                If IsNothing(Me._dtMasterCarton) Then Exit Sub

                strInnerCartonNo = InputBox("Enter an inner carton number:", "Enter", "")

                If strInnerCartonNo.Trim.Length > 0 Then
                    If Me._dtMasterCarton.Rows.Count = 1 AndAlso strInnerCartonNo.Trim.ToUpper = Convert.ToString(Me._dtMasterCarton.Rows(0).Item("InnerCarton_Name")).ToUpper Then
                        If strInnerCartonNo.Trim.ToUpper = Convert.ToString(Me._dtInnerCarton.Rows(0).Item("InnerCarton_Name")).ToUpper Then
                            Me._dtMasterCarton.Clear()
                            Me.BindMasterCartonData(Me._dtMasterCarton)
                        Else
                            MessageBox.Show("The inner carton  '" & strInnerCartonNo & "' is not in the list.")
                        End If
                    Else
                        dtTmp = Me._dtMasterCarton.Clone : dtTmp_Details = Me._dtMasterCartonDetails.Clone
                        For Each row In Me._dtMasterCarton.Rows
                            If strInnerCartonNo.Trim.ToUpper = Convert.ToString(row("InnerCarton_Name")).ToUpper Then 'skip found row
                                bFound = True
                            Else 'keep rest of rows
                                iOldGID = Convert.ToInt32(row("GID"))
                                i += 1
                                row.BeginEdit() : row("GID") = i : row.AcceptChanges()
                                dtTmp.ImportRow(row)

                                'Handle details datatable
                                For Each row2 In Me._dtMasterCartonDetails.Rows
                                    If Convert.ToInt32(row2("GID")) = iOldGID Then
                                        row2.BeginEdit() : row2("GID") = i : row2.AcceptChanges()
                                        dtTmp_Details.ImportRow(row2)
                                    End If
                                Next
                            End If
                        Next
                        If bFound Then
                            Me._dtMasterCarton = dtTmp.Copy : Me._dtMasterCartonDetails = dtTmp_Details.Copy
                            Me.BindMasterCartonData(Me._dtMasterCarton)
                        Else
                            MessageBox.Show("The inner carton  '" & strInnerCartonNo & "' is not in the list.")
                        End If
                    End If
                Else
                    MessageBox.Show("You must enter an inner carton number.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnMasterCartonRemoveOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtInnerCartonNumber.Text = "" : Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus()
            End Try
        End Sub

        Private Sub btnMasterCartonRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasterCartonRemoveAll.Click
            Try
                If IsNothing(Me._dtMasterCarton) Then Exit Sub

                Me._dtMasterCarton.Clear() : Me._dtMasterCartonDetails.Clear()
                Me.BindMasterCartonData(Me._dtMasterCarton)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnInnerCartonRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtInnerCartonNumber.Text = "" : Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus()
            End Try
        End Sub

        Private Sub btnMasterCartonComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasterCartonComplete.Click
            Dim strKP_IDs As String = ""
            Dim row As DataRow
            Dim i As Integer = 0
            Dim strPrinterName As String = ""

            Try
                Me.Cursor = Cursors.WaitCursor

                If IsNothing(Me._dtMasterCarton) Then
                    MessageBox.Show("Empty inner carton data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                ElseIf Not Me._iPackQtyPerMasterCarton > 0 Then
                    MessageBox.Show("Pack Qty Per Master Carton must be >0.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                End If

                If Not Convert.ToInt32(Me.txtMasterCartonQty.Text) = Me._iPackQtyPerMasterCarton Then
                    MessageBox.Show("Not fulfilled the master carton yet (need " & Me._iPackQtyPerMasterCarton.ToString & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                End If
                If Not Me._dtMasterCarton.Rows.Count = Convert.ToInt32(Me.txtMasterCartonQty.Text) Then
                    MessageBox.Show("The master carton data rows don't match the qty. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                End If
                If Not Me._iMasterCarton_ID > 0 Then
                    MessageBox.Show("No Master Carton ID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                End If
                If Me._objBYOP_Kitting.IsCartonClosed(Me._iMasterCarton_ID) Then
                    MessageBox.Show("The master carton " & Me.txtInnerCarton.Text & " is closed or can't find it. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                End If
                If Not Me._dtMasterCartonDetails.Rows.Count = Me._iTotalSNQtyPerPerMasterCarton Then
                    MessageBox.Show("The master carton detail data doesn't match the required qty. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus() : Exit Sub
                End If

                'ready 
                'GID,Row, KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet
                ', PackQtyPerInnerCarton, GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate, Process_Type_ID, UserID, UpdateDateTime
                ', IsActive, Pack_WO_ID, KP_ID, KPD_ID, SIM_Model_ID, SN, Master_Item, Master_Item_Desc, SIM_Item, SIM_Item_Desc, InnerCarton_Name, InnerCarton_Qty
                For Each row In Me._dtMasterCartonDetails.Rows
                    If strKP_IDs.Trim.Length = 0 Then
                        strKP_IDs = Convert.ToString(row("KP_ID"))
                    Else
                        strKP_IDs &= "," & Convert.ToString(row("KP_ID"))
                    End If
                Next
                'save data
                i = Me._objBYOP_Kitting.SaveMasterCartonData(Me._iMasterCarton_ID, Me._iTotalSNQtyPerPerMasterCarton, Convert.ToInt32(Me._dtMasterCarton.Rows(0).Item("Master_Model_ID")), 1, Me._iUserID, strKP_IDs, Convert.ToInt32(Me.txtMasterCartonQty.Text))

                If i = 0 Then
                    MessageBox.Show("Failed to save. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtInnerCartonSN.SelectAll() : Me.txtInnerCartonSN.Focus() : Exit Sub
                End If

                'printmaster carton label
                If Me.chkPrintMasterCartonLabel.Checked Then
                    Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

                    Dim strItemDesc As String = ""
                    Dim strItem As String = "" : Dim strItem_BarCode As String = ""
                    Dim strUPC As String = "" : Dim strUPC_BarCode As String = ""
                    Dim strUPC_Desc As String = "" : Dim strUPC_Desc_BarCode As String = ""
                    Dim strMinSN As String = "" : Dim strMaxSN As String = ""
                    Dim strCartonNo As String = "" : Dim strCartonNo_BarCode As String = ""
                    Dim strCartonNo_Desc As String = "" : Dim strCartonNo_Desc_BarCode As String = ""
                    Dim strQty_Str As String = "" : Dim strQty_Str_BarCode As String = ""
                    Dim strCaseQty_Str As String = "" : Dim strCaseQty_Str_BarCode As String = ""
                    Dim strVerControlNo As String = ""
                    Dim strCountry As String = "" : Dim strExpDate As String = ""
                    Dim strQR_Data As String = "" : Dim strQR_Data_BarCode As String = ""
                    Dim strPDF417_Data As String = "" : Dim strPDF417_Data_BarCode As String = ""
                    Dim strSep As String = "@"
                    Dim strLfCr As String = "\r" '\r = Carriage Return 

                    strItemDesc = Convert.ToString(Me._dtMasterCarton.Rows(0).Item("Master_Item_Desc")).Trim
                    strItem = Convert.ToString(Me._dtMasterCarton.Rows(0).Item("Master_Item")).Trim
                    strItem_BarCode = FontEncoder.Code128a(strItem)

                    strUPC = Me._strGTIN_MasterCarton_UPC_Barcode
                    strUPC_BarCode = FontEncoder.Code128a(Me._strGTIN_MasterCarton_UPC_Barcode)
                    strUPC_Desc = Convert.ToString(Me._dtMasterCarton.Rows(0).Item("GTIN_MasterCarton_UPC"))
                    strUPC_Desc_BarCode = FontEncoder.Code128a(Me._dtMasterCarton.Rows(0).Item("GTIN_MasterCarton_UPC"))

                    strCartonNo = Me.txtMasterCarton.Text.Trim
                    strCartonNo_BarCode = FontEncoder.Code128a(Me.txtMasterCarton.Text.Trim)
                    strCartonNo_Desc = Me.txtMasterCarton.Text.Trim
                    strCartonNo_Desc_BarCode = FontEncoder.Code128a(Me.txtMasterCarton.Text.Trim)

                    strQty_Str = Convert.ToInt32(Me._dtMasterCarton.Rows(0).Item("PackQtyPerInnerCarton")) ' Me._dtMasterCarton.Rows.Count.ToString
                    strQty_Str_BarCode = FontEncoder.Code128a(strQty_Str)
                    strCaseQty_Str = Me._iTotalSNQtyPerPerMasterCarton.ToString
                    strCaseQty_Str_BarCode = FontEncoder.Code128a(strCaseQty_Str)

                    strVerControlNo = Convert.ToString(Me._dtMasterCarton.Rows(0).Item("VersionControl"))
                    strCountry = Convert.ToString(Me._dtMasterCarton.Rows(0).Item("CountryOfOrigin"))
                    strExpDate = Convert.ToString(Me._dtMasterCarton.Rows(0).Item("ExpirationDate"))
                    strPDF417_Data = strItem & strSep & strQty_Str & strSep & strCartonNo_Desc

                    Dim rowView As DataRowView
                    Dim v As DataView = Me._dtMasterCartonDetails.DefaultView
                    Dim strTmp As String = ""
                    Dim p As Integer = 0

                    v.Sort = "SN Asc"
                    For Each rowView In v
                        p += 1
                        strTmp = rowView.Row("SN")
                        If p = 1 Then
                            strQR_Data = strTmp.Trim : strMinSN = strTmp
                            strPDF417_Data &= strSep & strTmp
                        Else
                            strQR_Data &= strSep & strTmp.Trim
                        End If
                        If p >= v.Table.Rows.Count Then strMaxSN = strTmp : strPDF417_Data &= strSep & strTmp & strSep & strSep & strExpDate
                    Next
                    strQR_Data_BarCode = Me.IDAutomation_QRFontEncoder(strQR_Data)
                    strPDF417_Data_BarCode = Me.IDAutomation_PDF417(strPDF417_Data)
                    strQR_Data_BarCode = strQR_Data_BarCode.Replace(Environment.NewLine, "\r\n")
                    strPDF417_Data_BarCode = strPDF417_Data_BarCode.Replace(Environment.NewLine, "\r\n")

                    FontEncoder = Nothing
                    strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Simple_Packing, Me._strComputerName, Me._objTFFK.SimplePackingLabels.Master_Carton_Label)
                    Me._objBYOP_SPP.Print_SP_MasterCarton_Label(strItemDesc, strItem, strItem_BarCode, strUPC, strUPC_BarCode, strUPC_Desc, _
                                                               strUPC_Desc_BarCode, strMinSN, strMaxSN, strCartonNo, strCartonNo_BarCode, strCartonNo_Desc, strCartonNo_Desc_BarCode, _
                                                               strQty_Str, strQty_Str_BarCode, strCaseQty_Str, strCaseQty_Str_BarCode, strVerControlNo, strCountry, strQR_Data, strQR_Data_BarCode, _
                                                               strPDF417_Data, strPDF417_Data_BarCode, strPrinterName, 1)
                End If

                Me.ResetMasterCarton()
                Me.txtInnerCartonNumber.Text = "" : Me.txtInnerCartonNumber.SelectAll() : Me.txtInnerCartonNumber.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnMasterCartonComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub btnMasterCartonReprintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasterCartonReprintLabel.Click
            Dim dt As DataTable
            Dim strMasterCartonName As String = ""
            Dim strPrinterName As String = ""

            Dim strItemDesc As String = ""
            Dim strItem As String = "" : Dim strItem_BarCode As String = ""
            Dim strUPC As String = "" : Dim strUPC_BarCode As String = ""
            Dim strUPC_Desc As String = "" : Dim strUPC_Desc_BarCode As String = ""
            Dim strMinSN As String = "" : Dim strMaxSN As String = ""
            Dim strCartonNo As String = "" : Dim strCartonNo_BarCode As String = ""
            Dim strCartonNo_Desc As String = "" : Dim strCartonNo_Desc_BarCode As String = ""
            Dim strQty_Str As String = "" : Dim strQty_Str_BarCode As String = ""
            Dim strCaseQty_Str As String = "" : Dim strCaseQty_Str_BarCode As String = ""
            Dim strVerControlNo As String = ""
            Dim strCountry As String = "" : Dim strExpDate As String = ""
            Dim strQR_Data As String = "" : Dim strQR_Data_BarCode As String = ""
            Dim strPDF417_Data As String = "" : Dim strPDF417_Data_BarCode As String = ""
            Dim strSep As String = "@"
            Dim strLfCr As String = "\r" '\r = Carriage Return 

            Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

            Try
                strMasterCartonName = InputBox("Enter a master carton name:", "Input", "")

                If strMasterCartonName.Trim.Length < 12 Then
                    MessageBox.Show("You must enter a valid master carton name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not strMasterCartonName.Trim.Substring(0, 2).ToUpper = Me._objTFFK._strBYOP_SP_MasterCartonName_PreFix.ToUpper Then
                    MessageBox.Show("Not a valid master carton name for this process..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                'Row, KMSet_ID, Kitting_Setup, Master_Model_ID, UPC, ItemUPC, SIM_Qty, Collateral_Qty, Alt_SIM_Qty, HasItemUPC, PackQtyPerCarton, MaxCartonQtyPerPallet
                ', PackQtyPerInnerCarton, GTIN_InnerCarton_UPC, GTIN_MasterCarton_UPC, VersionControl, CountryOfOrigin, ExpirationDate, Process_Type_ID, UserID, UpdateDateTime
                ', IsActive, Pack_WO_ID, KP_ID, KPD_ID, SIM_Model_ID, SN, Master_Item, Master_Item_Desc, SIM_Item, SIM_Item_Desc, MasterCarton_Name
                dt = Me._objBYOP_SPP.getMasterCarton_ReprintLabelData(strMasterCartonName)

                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No data for this master carton '" & strMasterCartonName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                strItemDesc = Convert.ToString(dt.Rows(0).Item("Master_Item_Desc")).Trim
                strItem = Convert.ToString(dt.Rows(0).Item("Master_Item")).Trim
                strItem_BarCode = FontEncoder.Code128a(strItem)

                strUPC_Desc = Convert.ToString(dt.Rows(0).Item("GTIN_MasterCarton_UPC"))
                strUPC_Desc_BarCode = FontEncoder.Code128a(strUPC_Desc)
                strUPC = strUPC_Desc.Replace("-", "")
                strUPC_BarCode = FontEncoder.Code128a(strUPC)


                strCartonNo = strMasterCartonName.Trim.ToUpper
                strCartonNo_BarCode = FontEncoder.Code128a(strCartonNo)
                strCartonNo_Desc = strMasterCartonName.Trim.ToUpper
                strCartonNo_Desc_BarCode = FontEncoder.Code128a(strCartonNo_Desc)

                strQty_Str = Convert.ToString(dt.Rows(0).Item("PackQtyPerInnerCarton")) 'Convert.ToString(dt.Rows(0).Item("PackQtyPerCarton"))
                strQty_Str_BarCode = FontEncoder.Code128a(strQty_Str)
                strCaseQty_Str = dt.Rows.Count.ToString
                strCaseQty_Str_BarCode = FontEncoder.Code128a(strCaseQty_Str)

                strVerControlNo = Convert.ToString(dt.Rows(0).Item("VersionControl"))
                strCountry = Convert.ToString(dt.Rows(0).Item("CountryOfOrigin"))
                strExpDate = Convert.ToString(dt.Rows(0).Item("ExpirationDate"))
                strPDF417_Data = strItem & strSep & strQty_Str & strSep & strCartonNo_Desc

                Dim rowView As DataRowView
                Dim v As DataView = dt.DefaultView
                Dim strTmp As String = ""
                Dim p As Integer = 0

                v.Sort = "SN Asc"
                For Each rowView In v
                    p += 1
                    strTmp = rowView.Row("SN")
                    If p = 1 Then
                        strQR_Data = strTmp.Trim : strMinSN = strTmp
                        strPDF417_Data &= strSep & strTmp
                    Else
                        strQR_Data &= strSep & strTmp.Trim
                    End If
                    If p >= v.Table.Rows.Count Then strMaxSN = strTmp : strPDF417_Data &= strSep & strTmp & strSep & strSep & strExpDate
                Next
                strQR_Data_BarCode = Me.IDAutomation_QRFontEncoder(strQR_Data)
                strPDF417_Data_BarCode = Me.IDAutomation_PDF417(strPDF417_Data)
                strQR_Data_BarCode = strQR_Data_BarCode.Replace(Environment.NewLine, "\r\n")
                strPDF417_Data_BarCode = strPDF417_Data_BarCode.Replace(Environment.NewLine, "\r\n")

                FontEncoder = Nothing
                strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Simple_Packing, Me._strComputerName, Me._objTFFK.SimplePackingLabels.Master_Carton_Label)
                Me._objBYOP_SPP.Print_SP_MasterCarton_Label(strItemDesc, strItem, strItem_BarCode, strUPC, strUPC_BarCode, strUPC_Desc, _
                                                           strUPC_Desc_BarCode, strMinSN, strMaxSN, strCartonNo, strCartonNo_BarCode, strCartonNo_Desc, strCartonNo_Desc_BarCode, _
                                                           strQty_Str, strQty_Str_BarCode, strCaseQty_Str, strCaseQty_Str_BarCode, strVerControlNo, strCountry, strQR_Data, strQR_Data_BarCode, _
                                                           strPDF417_Data, strPDF417_Data_BarCode, strPrinterName, 1)


                dt = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnMasterCartonReprintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        'Pallet ===========================================================================================================================================================
        Private Sub ResetPallet()
            Try
                Me._strPalletLabel_PrinterName = ""
                Me._iPallet_ID = 0
                If Not IsNothing(Me._dtPallet) OrElse Me._dtPallet.Rows.Count > 0 Then Me._dtPallet.Clear()
                Me.tdgPallet.DataSource = Nothing
                Me._iMaxQtyPerPallet = 0
                Me._iPalletSIMCard_Model_ID = 0
                Me._iPalletMasterItem_Model_ID = 0
                Me._strGTIN_MasterCarton_UPC_Barcode = ""
                Me._strPalletMasterItem_Desc = ""
                Me.txtPalletQty.Text = 0
                Me.txtPalletName.Text = ""
                Me.txtPalletName.ReadOnly = True : Me.txtPalletName.BackColor = System.Drawing.Color.Cornsilk
                Me.txtPalletQty.ReadOnly = True : Me.txtPalletQty.BackColor = System.Drawing.Color.Cornsilk
                Me.lblPalletItem.Text = ""
                Me.lblPalletSIMItem.Text = ""
                Me.pnlPallet.Visible = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub ResetPallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtMasterCartonNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMasterCartonNo.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtMasterCartonNo.Text.Trim.Length > 0 Then
                    Me.ProcessMasterCartonForPallet()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtMasterCartonNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessMasterCartonForPallet()
            Dim strCartonName As String = ""
            Dim strPalletName As String = ""
            'Dim strPalletName_PreFix As String = "SP"

            Dim dt As DataTable
            Dim row As DataRow
            Dim iIdx As Integer = 0

            Try
                'Get  data
                strCartonName = Me.txtMasterCartonNo.Text.Trim
                If strCartonName.Trim.Length = 0 Then
                    MessageBox.Show("Please enter master carton name (carton tag).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                ElseIf Me._objBYOP_Kitting.IsCartonBuiltInPallet(strCartonName) Then
                    MessageBox.Show("This master carton '" & strCartonName & "' already in a pallet. Can't add.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                ElseIf Convert.ToInt32(Me.txtPalletQty.Text) >= Me._objTFFK._iMaxCartonQtyPerPallet Then
                    MessageBox.Show("The pallet is fulfilled (maximum qty of per pallet is " & Me._objTFFK._iMaxCartonQtyPerPallet.ToString & "). " & Environment.NewLine & "Ready to complete the pallet now.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Me.btnMasterCartonComplete.Focus() : Exit Sub
                End If

                dt = Me._objBYOP_Kitting.getPalletAvailableCartonData(strCartonName)
                If Me._iPallet_ID = 0 Then Me._dtPallet = dt.Clone

                If dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate master carton name '" & strCartonName & "'. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                ElseIf dt.Rows.Count = 0 Then
                    MessageBox.Show("Can't find this master carton '" & strCartonName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                ElseIf Not Convert.ToInt32(dt.Rows(0).Item("Process_Type_ID")) = Me._iProcess_Type_ID Then
                    MessageBox.Show("This master carton '" & strCartonName & "' does not belong to this process.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                ElseIf Me._dtPallet.Rows.Count > 0 Then
                    For Each row In Me._dtPallet.Rows
                        If Convert.ToString(row("Carton_Name")).Trim.ToUpper = strCartonName.Trim.ToUpper Then
                            MessageBox.Show("Carton '" & strCartonName & "' already in the list. Can't add it again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                        End If
                    Next
                End If


                'Ready: dt.Rows.Count=1
                If Me._iPallet_ID = 0 Then 'create pallet name at the first carton
                    strPalletName = Me._objBYOP_Kitting.CreatePalletName(Me._strComputerName, Me._iPallet_ID, Me._objTFFK._strBYOP_SP_PalletName_PreFix)
                    Me.lblPalletItem.Text = Convert.ToString(dt.Rows(0).Item("Master_Item"))
                    Me.txtPalletName.Text = strPalletName
                    Me._iMaxQtyPerPallet = Convert.ToInt32(dt.Rows(0).Item("MaxCartonQtyPerPallet"))
                    If Not Me._iPallet_ID > 0 Then
                        MessageBox.Show("Failed to create pallet name. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                    End If
                    Me.pnlPallet.Visible = True
                End If

                'Ready
                For Each row In dt.Rows 'must be 1 row 
                    iIdx = Me._dtPallet.Rows.Count + 1
                    row.BeginEdit() : row("Row") = iIdx : row.AcceptChanges()
                    Me._dtPallet.ImportRow(row)
                Next

                Me.BindMasterCartonDataForPallet(Me._dtPallet)

                Me.txtMasterCartonNo.Text = "" : Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                dt = Nothing
            End Try
        End Sub

        Private Sub BindMasterCartonDataForPallet(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0
            Dim iKeySIM As Integer = 0

            Try
                If Not IsNothing(dt) AndAlso dt.Rows.Count > 0 Then
                    With Me.tdgPallet
                        .DataSource = dt.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Row", "Carton_Name", "ItemQty"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                            'If dbgc.Name = "SN" Then dbgc.Width = 200
                        Next dbgc
                        '.Splits(0).DisplayColumns("SoDetailsID").Width = 0
                    End With
                End If

                Me.txtPalletQty.Text = Me._dtPallet.Rows.Count.ToString

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindSNsData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnResetPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPallet.Click
            Try
                Dim result As Integer = MessageBox.Show("Do you want to reset all?", "Select", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Me.ResetMasterCarton()
                    Me.txtMasterCartonNo.Text = "" : Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnResetPallet_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnPalletRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPalletRemoveOne.Click
            Dim strCartonNo As String = ""
            Dim row As DataRow
            Dim dtTmp As DataTable
            Dim bFound As Boolean = False
            Dim i As Integer = 0

            Try
                If IsNothing(Me._dtPallet) Then Exit Sub

                strCartonNo = InputBox("Enter carton name (carton tag):", "Enter carton name", "")

                If strCartonNo.Trim.Length > 0 Then
                    If Me._dtPallet.Rows.Count = 1 AndAlso strCartonNo.Trim.ToUpper = Convert.ToString(Me._dtPallet.Rows(0).Item("Carton_Name")).ToUpper Then
                        If strCartonNo.Trim.ToUpper = Convert.ToString(Me._dtPallet.Rows(0).Item("Carton_Name")).ToUpper Then
                            Me._dtPallet.Clear()
                            Me.txtPalletQty.Text = 0 : Me.tdgPallet.DataSource = Nothing
                        Else
                            MessageBox.Show("Carton '" & strCartonNo & "' not in the list.")
                        End If
                    Else
                        dtTmp = Me._dtPallet.Clone
                        For Each row In Me._dtPallet.Rows
                            If strCartonNo.Trim.ToUpper = Convert.ToString(row("Carton_Name")).ToUpper Then
                                bFound = True
                            Else
                                i += 1
                                row.BeginEdit() : row("Row") = i : row.AcceptChanges()
                                dtTmp.ImportRow(row)
                            End If
                        Next
                        If bFound Then
                            Me._dtPallet = dtTmp.Copy
                            Me.BindMasterCartonDataForPallet(Me._dtPallet)
                        Else
                            MessageBox.Show("Carton '" & strCartonNo & "' not in the list.")
                        End If
                    End If
                Else
                    MessageBox.Show("You must enter an item SN.")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPalletRemoveOne_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtMasterCartonNo.Text = "" : Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus()
            End Try
        End Sub

        Private Sub btnPalletRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPalletRemoveAll.Click
            Try
                If IsNothing(Me._dtPallet) Then Exit Sub

                Dim result As Integer = MessageBox.Show("Do you want to remove all cartons from the list?", "Select Y/N", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    Me._dtPallet.Clear()
                    Me.txtPalletQty.Text = 0 : Me.tdgPallet.DataSource = Nothing
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPalletRemoveAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtMasterCartonNo.Text = "" : Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus()
            End Try
        End Sub

        Private Sub btnPalletReprintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPalletReprintLabel.Click
            Dim dt As DataTable
            Dim strPalletName As String = ""
            Dim strPrinterName As String = ""
            Dim strDatePallet As String = ""
            Dim strPalletNameCode As String = ""
            Dim iQty As Integer = 0
            Dim strQtyCode As String = ""
            Dim strMasterItem As String = ""
            Dim strMasterItemCode As String = ""

            'Pallet_ID, Pallet_Name, Carton_Qty, Model_ID, Closed, UserID, DateTime_Pallet, WorkStation, Master_Item, Cumputed_Carton_Qty, DateTime_Pallet, Pallet_Date

            Try
                strPalletName = InputBox("Enter pallet name (Lot No):", "Enter pallet", "")

                If strPalletName.Trim.Length < 12 Then 'SP0000000006
                    MessageBox.Show("You must enter a valid pallet name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not strPalletName.Trim.Substring(0, 2).ToUpper = Me._objTFFK._strBYOP_SP_PalletName_PreFix.ToUpper Then
                    MessageBox.Show("Not a valid pallet name for this process..", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                dt = Me._objBYOP_Kitting.getPalletLabelData(strPalletName)
                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No data for this pallet '" & strPalletName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate pallet name '" & strPalletName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Convert.ToInt32(dt.Rows(0).Item("Carton_Qty")) = Convert.ToInt32(dt.Rows(0).Item("Cumputed_Carton_Qty")) Then
                    MessageBox.Show("Invalid carton qty (miss match) in the pallet '" & strPalletName & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

                strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Standard_Kitting, Me._strComputerName, Me._objTFFK.StandardKittingLabels.Pallet_Label)
                strPalletName = Convert.ToString(dt.Rows(0).Item("Pallet_Name")).Trim : strPalletNameCode = FontEncoder.Code128a(strPalletName)
                iQty = Convert.ToInt32(dt.Rows(0).Item("Carton_Qty")) : strQtyCode = FontEncoder.Code128a(iQty.ToString)
                strMasterItem = Convert.ToString(dt.Rows(0).Item("Master_Item")) : strMasterItemCode = FontEncoder.Code128a(strMasterItem)
                FontEncoder = Nothing
                strDatePallet = Convert.ToString(dt.Rows(0).Item("Pallet_Date"))

                Me._objBYOP_SPP.PrintPallet_Label(strPalletName, strPalletNameCode, iQty, strQtyCode, strMasterItem, strMasterItemCode, strDatePallet, strPrinterName, 1)

                dt = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnPalletReprintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnPalletComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPalletComplete.Click
            Dim strCarton_IDs As String = ""
            Dim row As DataRow
            Dim i As Integer = 0
            Dim strPrinterName As String = ""
            Dim strPalletName As String = ""
            Dim strPalletNameCode As String = ""
            Dim iQty As Integer = 0
            Dim strQtyCode As String = ""
            Dim strMasterItem As String = ""
            Dim strMasterItemCode As String = ""

            Try
                Me.Cursor = Cursors.WaitCursor

                If IsNothing(Me._dtPallet) OrElse Not Me._dtPallet.Rows.Count > 0 Then
                    MessageBox.Show("No pallet data yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                End If

                If Convert.ToInt32(Me.txtPalletQty.Text) > Me._iMaxQtyPerPallet Then
                    MessageBox.Show("qty of cartons in this pallet is greater than maximum qty per pallet(" & Me._iMaxQtyPerPallet.ToString & ").", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                End If
                If Not Me._dtPallet.Rows.Count = Convert.ToInt32(Me.txtPalletQty.Text) Then
                    MessageBox.Show("The pallet rows don't match the qty. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                End If
                If Not Me._iPallet_ID > 0 Then
                    MessageBox.Show("No Pallet_ID. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                End If
                If Me._objBYOP_Kitting.IsPalletClosed(Me._iPallet_ID) Then
                    MessageBox.Show("The pallet (lot no) " & Me.txtPalletName.Text & " is closed or can't find it. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                End If

                'ready 
                For Each row In Me._dtPallet.Rows
                    If strCarton_IDs.Trim.Length = 0 Then
                        strCarton_IDs = Convert.ToString(row("Carton_ID"))
                    Else
                        strCarton_IDs &= "," & Convert.ToString(row("Carton_ID"))
                    End If
                Next

                'save data
                i = Me._objBYOP_Kitting.SavePalletData(Me._iPallet_ID, Convert.ToInt32(Me.txtPalletQty.Text), Convert.ToInt32(Me._dtPallet.Rows(0).Item("Model_ID")), 1, Me._iUserID, strCarton_IDs)

                If i = 0 Then
                    MessageBox.Show("Failed to save. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus() : Exit Sub
                End If

                'print pallet label
                If Me.chkPrintPalletLabel.Checked Then
                    Dim FontEncoder As New IDAutomation.NetAssembly.FontEncoder()

                    strPrinterName = Me._objBYOP_Kitting.getTFFK_LabelPrinterName(Me._objTFFK.ProcessTypeIDs.Simple_Packing, Me._strComputerName, Me._objTFFK.SimplePackingLabels.Pallet_Label)
                    strPalletName = Me.txtPalletName.Text.Trim : strPalletNameCode = FontEncoder.Code128a(strPalletName)
                    iQty = Convert.ToInt32(Me.txtPalletQty.Text) : strQtyCode = FontEncoder.Code128a(iQty.ToString)
                    strMasterItem = Me.lblPalletItem.Text : strMasterItemCode = FontEncoder.Code128a(strMasterItem)
                    FontEncoder = Nothing
                    Me._objBYOP_SPP.PrintPallet_Label(strPalletName, strPalletNameCode, iQty, strQtyCode, strMasterItem, strMasterItemCode, Format(Now, "dd/MM/yyyy"), strPrinterName, 1)
                End If

                'clear/reset for a new pallet
                Me.ResetPallet()
                Me.txtMasterCartonNo.Text = "" : Me.txtMasterCartonNo.SelectAll() : Me.txtMasterCartonNo.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnPalletComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub btnExpirationDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExpirationDate.Click
            Try
                'HOLD THIS
                'If Not Me._HasExpirationDate Then Exit Sub

                'Dim strDate As String = Me.lblExpirationDate.Text.Trim
                'Dim strSelectedDate As String = ""
                'Dim frmSelectExpirationDate As New frmTFFK_BYOP_SimplePackProcessXD(strDate)

                'frmSelectExpirationDate.ShowDialog()
                'If frmSelectExpirationDate.bIsCancelled Then
                '    MessageBox.Show("Cancelled! No date change.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    frmSelectExpirationDate.Dispose()
                '    Exit Sub
                'Else
                '    Me.lblExpirationDate.Text = frmSelectExpirationDate.SelectedDate
                '    frmSelectExpirationDate.Dispose()
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnExpirationDate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
