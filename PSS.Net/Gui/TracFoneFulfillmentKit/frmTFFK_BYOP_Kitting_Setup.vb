Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_Kitting_Setup
        Inherits System.Windows.Forms.Form

        Private _objTFFK As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK
        Private _objBYOP_Kitting As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting
        Private _BaseClass As PSS.Data.BaseClasses.CollectTrackingLog

        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strComputerName As String = ""
        Private _dtModels As DataTable
        Private _dtSetupModels As DataTable
        Private _dtSetupMasterItem As DataTable
        Private _dtSetupSIM As DataTable
        Private _dtSetupAltSIM As DataTable
        Private _dtSetupCollateral As DataTable

        Private _iKMSet_ID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFK = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK()
            Me._objBYOP_Kitting = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting()
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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents tdgModel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnSetYes As System.Windows.Forms.Button
        Friend WithEvents btnSetNo As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents lblRecNum As System.Windows.Forms.Label
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents btnMasterItem As System.Windows.Forms.Button
        Friend WithEvents btnSIMCard As System.Windows.Forms.Button
        Friend WithEvents btnAltSIMCard As System.Windows.Forms.Button
        Friend WithEvents btnDelMasterItem As System.Windows.Forms.Button
        Friend WithEvents btnDelSIM As System.Windows.Forms.Button
        Friend WithEvents btnDelAltSIM As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lbllblSimQty As System.Windows.Forms.Label
        Friend WithEvents lblSimQty As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtUPC As System.Windows.Forms.TextBox
        Friend WithEvents tdgAltSIM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCollateral As System.Windows.Forms.Button
        Friend WithEvents tdgCollateral As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgSIM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgMasterItem As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgSetUpModels As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtItemUPC As System.Windows.Forms.TextBox
        Friend WithEvents txtMaxCartonQtyPerPallet As System.Windows.Forms.TextBox
        Friend WithEvents btnRefreshSetupModels As System.Windows.Forms.Button
        Friend WithEvents lblSetupRecNum As System.Windows.Forms.Label
        Friend WithEvents lblMasterItemQty As System.Windows.Forms.Label
        Friend WithEvents lblCollateralQty As System.Windows.Forms.Label
        Friend WithEvents lblAltSimQty As System.Windows.Forms.Label
        Private WithEvents btnDelCollateral As System.Windows.Forms.Button
        Friend WithEvents txtPackQtyPerCarton As System.Windows.Forms.TextBox
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents rbtLocalPC As System.Windows.Forms.RadioButton
        Friend WithEvents rbtOtherPC As System.Windows.Forms.RadioButton
        Friend WithEvents lblLocalPC As System.Windows.Forms.Label
        Friend WithEvents txtOtherPC As System.Windows.Forms.TextBox
        Friend WithEvents tdgLabelPrinters As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnSaveLabelPrinterSetup As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_BYOP_Kitting_Setup))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.btnRefreshSetupModels = New System.Windows.Forms.Button()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtMaxCartonQtyPerPallet = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtPackQtyPerCarton = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.txtItemUPC = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblMasterItemQty = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblCollateralQty = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblAltSimQty = New System.Windows.Forms.Label()
            Me.lblSimQty = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtUPC = New System.Windows.Forms.TextBox()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.btnDelCollateral = New System.Windows.Forms.Button()
            Me.btnDelAltSIM = New System.Windows.Forms.Button()
            Me.btnDelSIM = New System.Windows.Forms.Button()
            Me.btnDelMasterItem = New System.Windows.Forms.Button()
            Me.btnAltSIMCard = New System.Windows.Forms.Button()
            Me.tdgAltSIM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnCollateral = New System.Windows.Forms.Button()
            Me.btnSIMCard = New System.Windows.Forms.Button()
            Me.btnMasterItem = New System.Windows.Forms.Button()
            Me.tdgCollateral = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgSIM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgMasterItem = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgSetUpModels = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lbllblSimQty = New System.Windows.Forms.Label()
            Me.lblSetupRecNum = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.btnSetNo = New System.Windows.Forms.Button()
            Me.btnSetYes = New System.Windows.Forms.Button()
            Me.tdgModel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblRecNum = New System.Windows.Forms.Label()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.btnSaveLabelPrinterSetup = New System.Windows.Forms.Button()
            Me.tdgLabelPrinters = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtOtherPC = New System.Windows.Forms.TextBox()
            Me.lblLocalPC = New System.Windows.Forms.Label()
            Me.rbtOtherPC = New System.Windows.Forms.RadioButton()
            Me.rbtLocalPC = New System.Windows.Forms.RadioButton()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.tdgAltSIM, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgCollateral, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgSIM, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgMasterItem, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgSetUpModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            CType(Me.tdgModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage3.SuspendLayout()
            CType(Me.tdgLabelPrinters, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
            Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(8, 24)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1000, 600)
            Me.TabControl1.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.PowderBlue
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshSetupModels, Me.Label11, Me.txtMaxCartonQtyPerPallet, Me.Label10, Me.txtPackQtyPerCarton, Me.Label9, Me.txtItemUPC, Me.Label4, Me.lblMasterItemQty, Me.Label8, Me.lblCollateralQty, Me.Label6, Me.lblAltSimQty, Me.lblSimQty, Me.Label3, Me.txtUPC, Me.btnComplete, Me.btnDelCollateral, Me.btnDelAltSIM, Me.btnDelSIM, Me.btnDelMasterItem, Me.btnAltSIMCard, Me.tdgAltSIM, Me.btnCollateral, Me.btnSIMCard, Me.btnMasterItem, Me.tdgCollateral, Me.tdgSIM, Me.tdgMasterItem, Me.tdgSetUpModels, Me.lbllblSimQty, Me.lblSetupRecNum})
            Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabPage1.Location = New System.Drawing.Point(4, 25)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(992, 571)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Kitting Setup"
            '
            'btnRefreshSetupModels
            '
            Me.btnRefreshSetupModels.BackColor = System.Drawing.Color.ForestGreen
            Me.btnRefreshSetupModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshSetupModels.ForeColor = System.Drawing.Color.White
            Me.btnRefreshSetupModels.Location = New System.Drawing.Point(16, 0)
            Me.btnRefreshSetupModels.Name = "btnRefreshSetupModels"
            Me.btnRefreshSetupModels.Size = New System.Drawing.Size(80, 24)
            Me.btnRefreshSetupModels.TabIndex = 229
            Me.btnRefreshSetupModels.Text = "Refresh"
            Me.ToolTip1.SetToolTip(Me.btnRefreshSetupModels, "Reload model data")
            '
            'Label11
            '
            Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label11.Location = New System.Drawing.Point(200, 440)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(168, 16)
            Me.Label11.TabIndex = 228
            Me.Label11.Text = "Max Carton Qty Per Pallet:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtMaxCartonQtyPerPallet
            '
            Me.txtMaxCartonQtyPerPallet.Location = New System.Drawing.Point(368, 440)
            Me.txtMaxCartonQtyPerPallet.Name = "txtMaxCartonQtyPerPallet"
            Me.txtMaxCartonQtyPerPallet.Size = New System.Drawing.Size(64, 22)
            Me.txtMaxCartonQtyPerPallet.TabIndex = 227
            Me.txtMaxCartonQtyPerPallet.Text = ""
            '
            'Label10
            '
            Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label10.Location = New System.Drawing.Point(0, 440)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(144, 16)
            Me.Label10.TabIndex = 226
            Me.Label10.Text = "Pack Qty Per Carton:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtPackQtyPerCarton
            '
            Me.txtPackQtyPerCarton.Location = New System.Drawing.Point(152, 440)
            Me.txtPackQtyPerCarton.Name = "txtPackQtyPerCarton"
            Me.txtPackQtyPerCarton.Size = New System.Drawing.Size(40, 22)
            Me.txtPackQtyPerCarton.TabIndex = 225
            Me.txtPackQtyPerCarton.Text = ""
            '
            'Label9
            '
            Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label9.Location = New System.Drawing.Point(200, 408)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(120, 16)
            Me.Label9.TabIndex = 224
            Me.Label9.Text = "Item UPC(12):"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtItemUPC
            '
            Me.txtItemUPC.Location = New System.Drawing.Point(320, 408)
            Me.txtItemUPC.Name = "txtItemUPC"
            Me.txtItemUPC.Size = New System.Drawing.Size(112, 22)
            Me.txtItemUPC.TabIndex = 223
            Me.txtItemUPC.Text = ""
            '
            'Label4
            '
            Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label4.Location = New System.Drawing.Point(0, 408)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 16)
            Me.Label4.TabIndex = 222
            Me.Label4.Text = "UPC(14):"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblMasterItemQty
            '
            Me.lblMasterItemQty.BackColor = System.Drawing.Color.LightCyan
            Me.lblMasterItemQty.Location = New System.Drawing.Point(688, 408)
            Me.lblMasterItemQty.Name = "lblMasterItemQty"
            Me.lblMasterItemQty.Size = New System.Drawing.Size(32, 16)
            Me.lblMasterItemQty.TabIndex = 221
            Me.lblMasterItemQty.Text = "0"
            '
            'Label8
            '
            Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label8.Location = New System.Drawing.Point(552, 408)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(128, 16)
            Me.Label8.TabIndex = 220
            Me.Label8.Text = "Master Item Qty:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblCollateralQty
            '
            Me.lblCollateralQty.BackColor = System.Drawing.Color.LightCyan
            Me.lblCollateralQty.Location = New System.Drawing.Point(848, 432)
            Me.lblCollateralQty.Name = "lblCollateralQty"
            Me.lblCollateralQty.Size = New System.Drawing.Size(32, 16)
            Me.lblCollateralQty.TabIndex = 219
            Me.lblCollateralQty.Text = "0"
            '
            'Label6
            '
            Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label6.Location = New System.Drawing.Point(728, 432)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(112, 16)
            Me.Label6.TabIndex = 218
            Me.Label6.Text = "Collateral Qty:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblAltSimQty
            '
            Me.lblAltSimQty.BackColor = System.Drawing.Color.LightCyan
            Me.lblAltSimQty.Location = New System.Drawing.Point(688, 432)
            Me.lblAltSimQty.Name = "lblAltSimQty"
            Me.lblAltSimQty.Size = New System.Drawing.Size(32, 16)
            Me.lblAltSimQty.TabIndex = 217
            Me.lblAltSimQty.Text = "0"
            '
            'lblSimQty
            '
            Me.lblSimQty.BackColor = System.Drawing.Color.LightCyan
            Me.lblSimQty.Location = New System.Drawing.Point(848, 408)
            Me.lblSimQty.Name = "lblSimQty"
            Me.lblSimQty.Size = New System.Drawing.Size(32, 16)
            Me.lblSimQty.TabIndex = 216
            Me.lblSimQty.Text = "0"
            '
            'Label3
            '
            Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label3.Location = New System.Drawing.Point(584, 432)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 214
            Me.Label3.Text = "Alt SIM Qty:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtUPC
            '
            Me.txtUPC.Location = New System.Drawing.Point(80, 408)
            Me.txtUPC.Name = "txtUPC"
            Me.txtUPC.Size = New System.Drawing.Size(112, 22)
            Me.txtUPC.TabIndex = 207
            Me.txtUPC.Text = ""
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.MidnightBlue
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(432, 480)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(128, 48)
            Me.btnComplete.TabIndex = 203
            Me.btnComplete.Text = "Complete"
            '
            'btnDelCollateral
            '
            Me.btnDelCollateral.BackColor = System.Drawing.Color.SlateGray
            Me.btnDelCollateral.ForeColor = System.Drawing.Color.White
            Me.btnDelCollateral.Location = New System.Drawing.Point(905, 256)
            Me.btnDelCollateral.Name = "btnDelCollateral"
            Me.btnDelCollateral.Size = New System.Drawing.Size(40, 32)
            Me.btnDelCollateral.TabIndex = 202
            Me.btnDelCollateral.Text = "Del"
            '
            'btnDelAltSIM
            '
            Me.btnDelAltSIM.BackColor = System.Drawing.Color.SlateGray
            Me.btnDelAltSIM.ForeColor = System.Drawing.Color.White
            Me.btnDelAltSIM.Location = New System.Drawing.Point(905, 176)
            Me.btnDelAltSIM.Name = "btnDelAltSIM"
            Me.btnDelAltSIM.Size = New System.Drawing.Size(40, 32)
            Me.btnDelAltSIM.TabIndex = 201
            Me.btnDelAltSIM.Text = "Del"
            '
            'btnDelSIM
            '
            Me.btnDelSIM.BackColor = System.Drawing.Color.SlateGray
            Me.btnDelSIM.ForeColor = System.Drawing.Color.White
            Me.btnDelSIM.Location = New System.Drawing.Point(905, 88)
            Me.btnDelSIM.Name = "btnDelSIM"
            Me.btnDelSIM.Size = New System.Drawing.Size(40, 32)
            Me.btnDelSIM.TabIndex = 200
            Me.btnDelSIM.Text = "Del"
            '
            'btnDelMasterItem
            '
            Me.btnDelMasterItem.BackColor = System.Drawing.Color.SlateGray
            Me.btnDelMasterItem.ForeColor = System.Drawing.Color.White
            Me.btnDelMasterItem.Location = New System.Drawing.Point(905, 32)
            Me.btnDelMasterItem.Name = "btnDelMasterItem"
            Me.btnDelMasterItem.Size = New System.Drawing.Size(40, 32)
            Me.btnDelMasterItem.TabIndex = 199
            Me.btnDelMasterItem.Text = "Del"
            '
            'btnAltSIMCard
            '
            Me.btnAltSIMCard.BackColor = System.Drawing.Color.Teal
            Me.btnAltSIMCard.ForeColor = System.Drawing.Color.White
            Me.btnAltSIMCard.Location = New System.Drawing.Point(440, 176)
            Me.btnAltSIMCard.Name = "btnAltSIMCard"
            Me.btnAltSIMCard.Size = New System.Drawing.Size(120, 40)
            Me.btnAltSIMCard.TabIndex = 198
            Me.btnAltSIMCard.Text = "Alt SIM --->"
            Me.ToolTip1.SetToolTip(Me.btnAltSIMCard, "SIM Card w/ SN")
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
            Me.tdgAltSIM.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgAltSIM.Location = New System.Drawing.Point(568, 176)
            Me.tdgAltSIM.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgAltSIM.Name = "tdgAltSIM"
            Me.tdgAltSIM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgAltSIM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgAltSIM.PreviewInfo.ZoomFactor = 75
            Me.tdgAltSIM.RowHeight = 15
            Me.tdgAltSIM.Size = New System.Drawing.Size(336, 64)
            Me.tdgAltSIM.TabIndex = 197
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
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>60</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 332, 60</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 332, 60</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" />" & _
            "<PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnCollateral
            '
            Me.btnCollateral.BackColor = System.Drawing.Color.Teal
            Me.btnCollateral.ForeColor = System.Drawing.Color.White
            Me.btnCollateral.Location = New System.Drawing.Point(440, 256)
            Me.btnCollateral.Name = "btnCollateral"
            Me.btnCollateral.Size = New System.Drawing.Size(120, 40)
            Me.btnCollateral.TabIndex = 196
            Me.btnCollateral.Text = "Collateral  --->"
            Me.ToolTip1.SetToolTip(Me.btnCollateral, "Collateral (Component)")
            '
            'btnSIMCard
            '
            Me.btnSIMCard.BackColor = System.Drawing.Color.Teal
            Me.btnSIMCard.ForeColor = System.Drawing.Color.White
            Me.btnSIMCard.Location = New System.Drawing.Point(440, 88)
            Me.btnSIMCard.Name = "btnSIMCard"
            Me.btnSIMCard.Size = New System.Drawing.Size(120, 40)
            Me.btnSIMCard.TabIndex = 195
            Me.btnSIMCard.Text = "SIM --->"
            Me.ToolTip1.SetToolTip(Me.btnSIMCard, "SIM Card w/ SN")
            '
            'btnMasterItem
            '
            Me.btnMasterItem.BackColor = System.Drawing.Color.Teal
            Me.btnMasterItem.ForeColor = System.Drawing.Color.White
            Me.btnMasterItem.Location = New System.Drawing.Point(440, 32)
            Me.btnMasterItem.Name = "btnMasterItem"
            Me.btnMasterItem.Size = New System.Drawing.Size(120, 40)
            Me.btnMasterItem.TabIndex = 194
            Me.btnMasterItem.Text = "Master  Item --->"
            Me.ToolTip1.SetToolTip(Me.btnMasterItem, "Master Item (Model or Parent Item)")
            '
            'tdgCollateral
            '
            Me.tdgCollateral.AllowColMove = False
            Me.tdgCollateral.AllowColSelect = False
            Me.tdgCollateral.AllowFilter = False
            Me.tdgCollateral.AllowSort = False
            Me.tdgCollateral.AllowUpdate = False
            Me.tdgCollateral.BackColor = System.Drawing.Color.White
            Me.tdgCollateral.CaptionHeight = 17
            Me.tdgCollateral.ColumnHeaders = False
            Me.tdgCollateral.FetchRowStyles = True
            Me.tdgCollateral.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgCollateral.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgCollateral.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgCollateral.Location = New System.Drawing.Point(568, 256)
            Me.tdgCollateral.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgCollateral.Name = "tdgCollateral"
            Me.tdgCollateral.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgCollateral.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgCollateral.PreviewInfo.ZoomFactor = 75
            Me.tdgCollateral.RowHeight = 15
            Me.tdgCollateral.Size = New System.Drawing.Size(336, 136)
            Me.tdgCollateral.TabIndex = 193
            Me.tdgCollateral.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>132</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 332, 132</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 332, 132</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
            " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
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
            Me.tdgSIM.Location = New System.Drawing.Point(568, 88)
            Me.tdgSIM.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgSIM.Name = "tdgSIM"
            Me.tdgSIM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSIM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSIM.PreviewInfo.ZoomFactor = 75
            Me.tdgSIM.RowHeight = 15
            Me.tdgSIM.Size = New System.Drawing.Size(336, 88)
            Me.tdgSIM.TabIndex = 192
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
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>84</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 332, 84</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 332, 84</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" />" & _
            "<PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tdgMasterItem
            '
            Me.tdgMasterItem.AllowColMove = False
            Me.tdgMasterItem.AllowColSelect = False
            Me.tdgMasterItem.AllowFilter = False
            Me.tdgMasterItem.AllowSort = False
            Me.tdgMasterItem.AllowUpdate = False
            Me.tdgMasterItem.BackColor = System.Drawing.Color.White
            Me.tdgMasterItem.CaptionHeight = 17
            Me.tdgMasterItem.ColumnHeaders = False
            Me.tdgMasterItem.FetchRowStyles = True
            Me.tdgMasterItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgMasterItem.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgMasterItem.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgMasterItem.Location = New System.Drawing.Point(568, 32)
            Me.tdgMasterItem.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgMasterItem.Name = "tdgMasterItem"
            Me.tdgMasterItem.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgMasterItem.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgMasterItem.PreviewInfo.ZoomFactor = 75
            Me.tdgMasterItem.RowHeight = 15
            Me.tdgMasterItem.Size = New System.Drawing.Size(336, 40)
            Me.tdgMasterItem.TabIndex = 191
            Me.tdgMasterItem.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>36</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 332, 36</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 332, 36</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" />" & _
            "<PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tdgSetUpModels
            '
            Me.tdgSetUpModels.AllowUpdate = False
            Me.tdgSetUpModels.AlternatingRows = True
            Me.tdgSetUpModels.BackColor = System.Drawing.Color.White
            Me.tdgSetUpModels.FilterBar = True
            Me.tdgSetUpModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSetUpModels.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSetUpModels.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgSetUpModels.Location = New System.Drawing.Point(16, 24)
            Me.tdgSetUpModels.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgSetUpModels.Name = "tdgSetUpModels"
            Me.tdgSetUpModels.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSetUpModels.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSetUpModels.PreviewInfo.ZoomFactor = 75
            Me.tdgSetUpModels.Size = New System.Drawing.Size(416, 368)
            Me.tdgSetUpModels.TabIndex = 190
            Me.tdgSetUpModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
            "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
            "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
            "le11{}OddRow{BackColor:Lavender;}Style13{}Style12{}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}" & _
            "Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenR" & _
            "ow{BackColor:AntiqueWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, " & _
            "1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans S" & _
            "erif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}" & _
            "Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}St" & _
            "yle7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBor" & _
            "der"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizo" & _
            "ntalScrollGroup=""1""><Height>364</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
            "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
            "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
            "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
            "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
            "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
            "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
            "/><ClientRect>0, 0, 412, 364</ClientRect><BorderSide>0</BorderSide><BorderStyle>" & _
            "Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style" & _
            " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
            "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
            "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
            """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
            """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
            "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0" & _
            ", 0, 412, 364</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintP" & _
            "ageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'lbllblSimQty
            '
            Me.lbllblSimQty.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lbllblSimQty.Location = New System.Drawing.Point(752, 408)
            Me.lbllblSimQty.Name = "lbllblSimQty"
            Me.lbllblSimQty.Size = New System.Drawing.Size(88, 16)
            Me.lbllblSimQty.TabIndex = 213
            Me.lbllblSimQty.Text = "SIM Qty:"
            Me.lbllblSimQty.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblSetupRecNum
            '
            Me.lblSetupRecNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSetupRecNum.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblSetupRecNum.Location = New System.Drawing.Point(104, 4)
            Me.lblSetupRecNum.Name = "lblSetupRecNum"
            Me.lblSetupRecNum.Size = New System.Drawing.Size(272, 24)
            Me.lblSetupRecNum.TabIndex = 230
            Me.lblSetupRecNum.Text = "Model Count: 0"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.Honeydew
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.btnSetNo, Me.btnSetYes, Me.tdgModel, Me.lblRecNum})
            Me.TabPage2.Location = New System.Drawing.Point(4, 25)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(992, 571)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Model Mgmt."
            '
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.Color.SeaGreen
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.White
            Me.btnRefresh.Location = New System.Drawing.Point(776, 16)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(128, 32)
            Me.btnRefresh.TabIndex = 0
            Me.btnRefresh.Text = "Refresh Data"
            '
            'btnSetNo
            '
            Me.btnSetNo.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnSetNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSetNo.ForeColor = System.Drawing.Color.Red
            Me.btnSetNo.Location = New System.Drawing.Point(776, 128)
            Me.btnSetNo.Name = "btnSetNo"
            Me.btnSetNo.Size = New System.Drawing.Size(128, 56)
            Me.btnSetNo.TabIndex = 191
            Me.btnSetNo.Text = "No"
            Me.ToolTip1.SetToolTip(Me.btnSetNo, "Set as non-BYOP model (item)")
            '
            'btnSetYes
            '
            Me.btnSetYes.BackColor = System.Drawing.Color.DarkSeaGreen
            Me.btnSetYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSetYes.ForeColor = System.Drawing.Color.Blue
            Me.btnSetYes.Location = New System.Drawing.Point(776, 64)
            Me.btnSetYes.Name = "btnSetYes"
            Me.btnSetYes.Size = New System.Drawing.Size(128, 56)
            Me.btnSetYes.TabIndex = 190
            Me.btnSetYes.Text = "Yes"
            Me.ToolTip1.SetToolTip(Me.btnSetYes, "Set as BYOP model (item)")
            '
            'tdgModel
            '
            Me.tdgModel.AllowUpdate = False
            Me.tdgModel.AlternatingRows = True
            Me.tdgModel.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.tdgModel.FilterBar = True
            Me.tdgModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgModel.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgModel.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.tdgModel.Location = New System.Drawing.Point(16, 21)
            Me.tdgModel.Name = "tdgModel"
            Me.tdgModel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgModel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgModel.PreviewInfo.ZoomFactor = 75
            Me.tdgModel.Size = New System.Drawing.Size(750, 539)
            Me.tdgModel.TabIndex = 189
            Me.tdgModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
            "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
            "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
            "le11{}OddRow{BackColor:Lavender;}Style13{}Style12{}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}" & _
            "Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenR" & _
            "ow{BackColor:AntiqueWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1," & _
            " 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans S" & _
            "erif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}" & _
            "Style5{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}St" & _
            "yle7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBor" & _
            "der"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizo" & _
            "ntalScrollGroup=""1""><Height>535</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
            "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
            "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
            "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
            "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
            "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
            "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
            "/><ClientRect>0, 0, 746, 535</ClientRect><BorderSide>0</BorderSide><BorderStyle>" & _
            "Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style" & _
            " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
            "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
            "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
            """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
            """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
            "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0" & _
            ", 0, 746, 535</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintP" & _
            "ageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'lblRecNum
            '
            Me.lblRecNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNum.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblRecNum.Location = New System.Drawing.Point(16, 4)
            Me.lblRecNum.Name = "lblRecNum"
            Me.lblRecNum.Size = New System.Drawing.Size(272, 24)
            Me.lblRecNum.TabIndex = 192
            Me.lblRecNum.Text = "Model Count: 0"
            '
            'TabPage3
            '
            Me.TabPage3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSaveLabelPrinterSetup, Me.tdgLabelPrinters, Me.txtOtherPC, Me.lblLocalPC, Me.rbtOtherPC, Me.rbtLocalPC})
            Me.TabPage3.Location = New System.Drawing.Point(4, 25)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(992, 571)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Set Printers"
            '
            'btnSaveLabelPrinterSetup
            '
            Me.btnSaveLabelPrinterSetup.Location = New System.Drawing.Point(600, 64)
            Me.btnSaveLabelPrinterSetup.Name = "btnSaveLabelPrinterSetup"
            Me.btnSaveLabelPrinterSetup.Size = New System.Drawing.Size(152, 48)
            Me.btnSaveLabelPrinterSetup.TabIndex = 98
            Me.btnSaveLabelPrinterSetup.Text = "Save Changes"
            '
            'tdgLabelPrinters
            '
            Me.tdgLabelPrinters.AlternatingRows = True
            Me.tdgLabelPrinters.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.tdgLabelPrinters.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tdgLabelPrinters.FilterBar = True
            Me.tdgLabelPrinters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgLabelPrinters.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgLabelPrinters.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.tdgLabelPrinters.Location = New System.Drawing.Point(24, 72)
            Me.tdgLabelPrinters.Name = "tdgLabelPrinters"
            Me.tdgLabelPrinters.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgLabelPrinters.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgLabelPrinters.PreviewInfo.ZoomFactor = 75
            Me.tdgLabelPrinters.Size = New System.Drawing.Size(568, 464)
            Me.tdgLabelPrinters.TabIndex = 3
            Me.tdgLabelPrinters.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
            "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
            "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
            "le11{}OddRow{BackColor:Lavender;}Style13{}Style12{}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}" & _
            "Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenR" & _
            "ow{BackColor:AntiqueWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, " & _
            "1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans S" & _
            "erif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}" & _
            "Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}St" & _
            "yle7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBor" & _
            "der"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizo" & _
            "ntalScrollGroup=""1""><Height>464</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
            "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
            "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
            "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
            "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
            "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
            "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
            "/><ClientRect>0, 0, 568, 464</ClientRect><BorderSide>0</BorderSide><BorderStyle>" & _
            "Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style" & _
            " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
            "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
            "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
            """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
            """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
            "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0" & _
            ", 0, 568, 464</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintP" & _
            "ageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'txtOtherPC
            '
            Me.txtOtherPC.Location = New System.Drawing.Point(368, 40)
            Me.txtOtherPC.Name = "txtOtherPC"
            Me.txtOtherPC.Size = New System.Drawing.Size(224, 22)
            Me.txtOtherPC.TabIndex = 1
            Me.txtOtherPC.Text = ""
            '
            'lblLocalPC
            '
            Me.lblLocalPC.Location = New System.Drawing.Point(368, 16)
            Me.lblLocalPC.Name = "lblLocalPC"
            Me.lblLocalPC.Size = New System.Drawing.Size(224, 24)
            Me.lblLocalPC.TabIndex = 97
            Me.lblLocalPC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'rbtOtherPC
            '
            Me.rbtOtherPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtOtherPC.Location = New System.Drawing.Point(32, 40)
            Me.rbtOtherPC.Name = "rbtOtherPC"
            Me.rbtOtherPC.Size = New System.Drawing.Size(344, 24)
            Me.rbtOtherPC.TabIndex = 2
            Me.rbtOtherPC.Text = "Set Label Printers for Other Workstation (Computer)"
            '
            'rbtLocalPC
            '
            Me.rbtLocalPC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtLocalPC.Location = New System.Drawing.Point(32, 16)
            Me.rbtLocalPC.Name = "rbtLocalPC"
            Me.rbtLocalPC.Size = New System.Drawing.Size(344, 24)
            Me.rbtLocalPC.TabIndex = 0
            Me.rbtLocalPC.Text = "Set Label Printers for Local Workstation (Computer)"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
            Me.Label1.Location = New System.Drawing.Point(8, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(288, 24)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "BYOP Kitting Setup"
            '
            'frmTFFK_BYOP_Kitting_Setup
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1024, 630)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.TabControl1})
            Me.Name = "frmTFFK_BYOP_Kitting_Setup"
            Me.Text = "frmTFFK_BYOP_Kitting_Setup"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.tdgAltSIM, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgCollateral, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgSIM, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgMasterItem, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgSetUpModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.tdgModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage3.ResumeLayout(False)
            CType(Me.tdgLabelPrinters, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

      

        Private Sub frmTFFK_BYOP_Kitting_Setup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
                Me.tdgModel.FetchRowStyles = True     'for fetchrowevent to fire

                Me.lblLocalPC.Text = Me._strComputerName.Trim
                Me.TabControl1.SelectedIndex = 0


                Me.txtPackQtyPerCarton.ReadOnly = True : Me.txtPackQtyPerCarton.BackColor = System.Drawing.Color.LightCyan 'Cornsilk
                Me.txtPackQtyPerCarton.Text = Me._objTFFK._iKittedPackQtyPerCarton.ToString
                Me.txtMaxCartonQtyPerPallet.Text = Me._objTFFK._iMaxCartonQtyPerPallet.ToString

                Me.BindSetupModels()

                Me.ActiveControl = Me.btnRefresh : Me.btnRefresh.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_BYOP_Kitting_Setup_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

        Private Sub BindModels()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'Row, Model_ID, Model, IsBYOP_Model, Model_Desc, Class, Subclass, Techology, UPC, Weight, Height, Width, Length, UPC_DCode_ID, 
            'Class_DCode_ID, SubClass_DCode_ID, Tech_Dcode_ID, Prod_ID, Has_BC, User_ID, UpdateDate

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                Me._dtModels = Me._objBYOP_Kitting.getAllFulfillmentKittingModels(False)

                Me.tdgModel.DataSource = Nothing : Me.lblRecNum.Text = "Model Count: 0"

                If Me._dtModels.Rows.Count > 0 Then
                    With Me.tdgModel
                        .DataSource = Me._dtModels.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Row", "Model_ID", "Model", "Model_Desc", "IsBYOP_Model", "Class", "Subclass", "Techology"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("Model_Desc").Width = 350
                        .Splits(0).DisplayColumns("IsBYOP_Model").FetchStyle = True 'for fetchcellevent to fire
                        .Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End With
                    Me.lblRecNum.Text = "Model Count: " & Me.tdgModel.RowCount
                    'Else
                    '    MessageBox.Show("No SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                'With Me.tdgModelCriteria
                '    .DataSource = dt.DefaultView
                '    For i = 0 To .Columns.Count - 1
                '        .Splits(0).DisplayColumns("Active").FetchStyle = True       'for fetchcellevent to fire
                '        .Splits(0).DisplayColumns(i).AutoSize()
                '        .Splits(0).DisplayColumns("Active").Width = 100
                '        .Splits(0).DisplayColumns("Active").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '        .Splits(0).DisplayColumns("Active").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '        .Splits(0).DisplayColumns("Key Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '        .Splits(0).DisplayColumns("Key Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '        .Splits(0).DisplayColumns("Equip Type").Width = 70
                '        .Splits(0).DisplayColumns("Equip Type").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '        .Splits(0).DisplayColumns("Equip Type").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                '        .Splits(0).DisplayColumns("Active").HeadingStyle.ForeColor = Color.MediumBlue
                '        .Splits(0).DisplayColumns("Model").HeadingStyle.ForeColor = Color.Black
                '        .Splits(0).DisplayColumns("Model").Style.ForeColor = Color.Black
                '        .Splits(0).DisplayColumns("Key Model").Style.ForeColor = Color.DimGray
                '        .Splits(0).DisplayColumns("User").Style.ForeColor = Color.DarkGray
                '        .Splits(0).DisplayColumns("Rec_Date").Style.ForeColor = Color.DarkGray
                '        .Splits(0).DisplayColumns("Product").Style.ForeColor = Color.DarkGray
                '        If i > 6 Then .Splits(0).DisplayColumns(i).Visible = False
                '    Next
                'End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub tdgModel_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgModel.AfterFilter
            Me.lblRecNum.Text = "Model Count: " & Me.tdgModel.RowCount
        End Sub

        Private Sub tdgModel_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgModel.AfterSort
            Me.lblRecNum.Text = "Model Count: " & Me.tdgModel.RowCount
        End Sub

        Private Sub tdgModel_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdgModel.FetchCellStyle
            Dim strYes As String
            ' Dim v
            Try
                strYes = Me.tdgModel.Columns("IsBYOP_Model").CellText(e.Row).ToString
                Select Case strYes.Trim.ToUpper
                    Case "Yes".ToUpper
                        e.CellStyle.ForeColor = Color.Blue
                        'v = Me.tdgModelCriteria.Item(e.Row, e.Col - 1)
                        'e.CellStyle.ForeColor = Color.MediumBlue
                    Case "No".ToUpper
                        e.CellStyle.ForeColor = Color.Red
                        'v = Me.tdgModelCriteria.Item(e.Row, e.Col - 1)
                        'e.CellStyle.ForeColor = Color.Black
                    Case Else
                        e.CellStyle.BackColor = Color.Black
                End Select

                'Dim N As Integer
                ' N = Val(Me.C1TrueDBGrid1(e.Row, e.Col))
                'If N > 1000 Then
                '    e.CellStyle.ForeColor = System.Drawing.Color.Blue
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgModel_FetchCellStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSetYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetYes.Click
            Dim iRow As Integer
            Dim iModel_ID As Integer = 0

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If Me.tdgModel.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgModel.SelectedRows
                        iModel_ID = Convert.ToInt32(Me.tdgModel.Columns("Model_ID").CellText(iRow))
                        Me._objBYOP_Kitting.UpdateModelIsBYOP(iModel_ID, 1)
                    Next
                    Me.BindModels()
                Else
                    MessageBox.Show("Please select a row or rows in the model list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Sub btnSetYes_Click(", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnSetNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSetNo.Click
            Dim iRow As Integer
            Dim iModel_ID As Integer = 0

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If Me.tdgModel.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgModel.SelectedRows
                        iModel_ID = Convert.ToInt32(Me.tdgModel.Columns("Model_ID").CellText(iRow))
                        Me._objBYOP_Kitting.UpdateModelIsBYOP(iModel_ID, 0)
                    Next
                    Me.BindModels()
                Else
                    MessageBox.Show("Please select a row or rows in the model list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Sub btnSetNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Me.BindModels()
        End Sub

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
            Try
                If Me.TabControl1.SelectedIndex = 1 AndAlso Me.tdgModel.RowCount = 0 Then Me.BindModels()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtUPC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUPC.KeyPress
            Try
                If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                    e.Handled = True
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtItemUPC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemUPC.KeyPress
            Try
                If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                    e.Handled = True
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtMaxCartonQtyPerPallet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaxCartonQtyPerPallet.KeyPress
            Try
                If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                    e.Handled = True
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub Buttons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                      Handles btnMasterItem.Click, btnSIMCard.Click, btnAltSIMCard.Click, btnCollateral.Click
            Dim dt As DataTable
            Dim row As DataRow
            Dim iRow As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim strMsg As String = ""

            'Row, Model_ID, Model, Qty, IsBYOP_Model, Model_Desc, Class, Subclass, Techology, UPC, Weight, Height, Width, Length, 
            'UPC_DCode_ID, Class_DCode_ID, SubClass_DCode_ID, Tech_Dcode_ID, Prod_ID, Has_BC, User_ID, UpdateDate, Parent_Model, IsKeySIM, Parent_Model_ID

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If Not Me.tdgSetUpModels.RowCount > 0 Then Exit Sub
                If Not Me.tdgSetUpModels.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row in the model list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgSetUpModels.SelectedRows 'for one selected row
                    iModel_ID = Convert.ToInt32(Me.tdgSetUpModels.Columns("Model_ID").CellText(iRow))

                    If Not IsValidToAdd(strMsg, iModel_ID) Then
                        MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Select Case Convert.ToString(sender.name).Trim.ToUpper
                        Case "btnMasterItem".ToUpper
                            If Me._dtSetupMasterItem.Rows.Count >= 1 Then
                                MessageBox.Show("Already has 1 master item (Only 1 master item is allowed)!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Exit Sub
                            End If
                            For Each row In Me._dtSetupModels.Rows
                                If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                                    Me._dtSetupMasterItem.ImportRow(row) : Exit For
                                End If
                            Next
                            Me.BindSetupSelectedModels(Me._dtSetupMasterItem, Me.tdgMasterItem, Me.lblMasterItemQty, False)
                            Me.tdgSetUpModels.SelectedRows.Clear()
                        Case "btnSIMCard".ToUpper
                                For Each row In Me._dtSetupModels.Rows
                                    If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                                        Dim bIsKeySIM As Boolean = False
                                        Dim SIM_Row As DataRow
                                        If Me._dtSetupSIM.Rows.Count > 0 Then
                                            For Each SIM_Row In Me._dtSetupSIM.Rows
                                                If Convert.ToInt32(SIM_Row("IsKeySIM")) = 1 Then
                                                    bIsKeySIM = True : Exit For
                                                End If
                                            Next
                                        End If
                                        If Not bIsKeySIM Then
                                            Dim result As Integer = MessageBox.Show("Is this a key SIM card?", "Select", MessageBoxButtons.YesNoCancel)
                                            If result = DialogResult.Cancel Then
                                                Exit Sub 'give up to add 
                                            ElseIf result = DialogResult.No Then
                                                'do nothing:IsKeySIM=0 as default
                                                Me._dtSetupSIM.ImportRow(row)
                                            ElseIf result = DialogResult.Yes Then
                                                Me._dtSetupSIM.ImportRow(row)
                                                Me._dtSetupSIM.Rows(Me._dtSetupSIM.Rows.Count - 1).BeginEdit()
                                                Me._dtSetupSIM.Rows(Me._dtSetupSIM.Rows.Count - 1).Item("IsKeySIM") = 1
                                                Me._dtSetupSIM.Rows(Me._dtSetupSIM.Rows.Count - 1).AcceptChanges()
                                            End If
                                        Else
                                            Me._dtSetupSIM.ImportRow(row)
                                        End If
                                        Exit For
                                    End If
                                Next

                                Me.BindSetupSelectedModels(Me._dtSetupSIM, Me.tdgSIM, Me.lblSimQty, False)
                                Me.tdgSetUpModels.SelectedRows.Clear()
                        Case "btnAltSIMCard".ToUpper
                                If Not Me._dtSetupSIM.Rows.Count > 0 Then
                                    MessageBox.Show("Can't add Alt SIM card if SIM card list has nothing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Exit Sub
                                End If

                            For Each row In Me._dtSetupModels.Rows
                                If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                                    Dim strSelectedParentSIM_Model As String = ""
                                    Dim iSelectedParentSIM_Model_ID As Integer = 0
                                    Dim iIsKeySIM As Integer = 0
                                    Dim strSelectedAltSIM_Model As String = Convert.ToString(row("Model"))
                                    Dim fmSelectParentSIM As New frmTFFK_BYOP_Kitting_Setup_AltSIM(Me._dtSetupSIM, strSelectedAltSIM_Model)
                                    fmSelectParentSIM.ShowDialog()
                                    If fmSelectParentSIM.bIsCancelled Then
                                        'MessageBox.Show("You cancelled!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        fmSelectParentSIM.Dispose()
                                        Exit Sub
                                    Else
                                        strSelectedParentSIM_Model = fmSelectParentSIM.getSelectedModel
                                        iSelectedParentSIM_Model_ID = fmSelectParentSIM.getSelectedModel_ID
                                        iIsKeySIM = fmSelectParentSIM.getSelectedIsKeySIM
                                        fmSelectParentSIM.Dispose()
                                    End If

                                    Me._dtSetupAltSIM.ImportRow(row)
                                    Me._dtSetupAltSIM.Rows(Me._dtSetupAltSIM.Rows.Count - 1).BeginEdit()
                                    Me._dtSetupAltSIM.Rows(Me._dtSetupAltSIM.Rows.Count - 1).Item("Parent_Model") &= strSelectedParentSIM_Model
                                    Me._dtSetupAltSIM.Rows(Me._dtSetupAltSIM.Rows.Count - 1).Item("Parent_Model_ID") = iSelectedParentSIM_Model_ID
                                    Me._dtSetupAltSIM.Rows(Me._dtSetupAltSIM.Rows.Count - 1).Item("IsKeySIM") = iIsKeySIM
                                    Me._dtSetupAltSIM.Rows(Me._dtSetupAltSIM.Rows.Count - 1).AcceptChanges()
                                    Exit For
                                End If
                            Next
                            Me.BindSetupSelectedModels(Me._dtSetupAltSIM, Me.tdgAltSIM, Me.lblAltSimQty, True)
                            Me.tdgSetUpModels.SelectedRows.Clear()
                        Case "btnCollateral".ToUpper
                                For Each row In Me._dtSetupModels.Rows
                                    If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                                        'Me._dtSetupCollateral.ImportRow(row)
                                        Dim fmSelectQty As New frmTFFK_BYOP_Kitting_Setup_Qty()
                                        fmSelectQty.ShowDialog()
                                        Dim iQty As Integer = fmSelectQty.getQtyNeeded
                                        fmSelectQty.Dispose()

                                        If iQty > 1 Then
                                            'Dim newRow As DataRow = getModifiedRow(row, iQty)
                                            'Me._dtSetupCollateral.ImportRow(newRow)
                                            Me._dtSetupCollateral.ImportRow(row)
                                            Me._dtSetupCollateral.Rows(Me._dtSetupCollateral.Rows.Count - 1).BeginEdit()
                                            Me._dtSetupCollateral.Rows(Me._dtSetupCollateral.Rows.Count - 1).Item("Qty") = iQty
                                            Me._dtSetupCollateral.Rows(Me._dtSetupCollateral.Rows.Count - 1).AcceptChanges()
                                            'Dim dtTmp As DataTable = Me._dtSetupCollateral.Clone
                                            'dtTmp.ImportRow(row)
                                            'Dim newRow As DataRow = dtTmp.Rows(0)
                                            'newRow.BeginEdit() : newRow("Qty") = iQty : newRow.AcceptChanges()
                                            'Me._dtSetupCollateral.ImportRow(newRow)
                                        Else
                                            Me._dtSetupCollateral.ImportRow(row)
                                        End If
                                        Exit For
                                    End If
                                Next
                                Me.BindSetupSelectedModels(Me._dtSetupCollateral, Me.tdgCollateral, Me.lblCollateralQty, False)
                                Me.tdgSetUpModels.SelectedRows.Clear()
                    End Select

                    Exit For 'for one selected row
                Next 'for one selected row

                ' Me.tdgSetUpModels.SelectedRows.Clear() 'deselect rows
                'Me.tdgSetUpModels.SelectedRows.Add(l) 'select row 1

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Sub Buttons_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Function getModifiedRow(ByVal row As DataRow, ByVal iQty As Integer) As DataRow
            Dim newRow As DataRow = row

            newRow.BeginEdit() : newRow("Qty") = iQty : newRow.AcceptChanges()
            Return newRow

        End Function

        Private Function IsValidToAdd(ByRef strMsg As String, ByVal iModel_ID As Integer) As Boolean
            Dim iModel_ID_Local As Integer = 0
            Dim row As DataRow
            Dim bRet As Boolean = True

            Try
                strMsg = ""
                For Each row In Me._dtSetupMasterItem.Rows
                    iModel_ID_Local = Convert.ToInt32(row("Model_ID"))
                    If iModel_ID = iModel_ID_Local Then
                        strMsg = "Already added in master item list."
                        bRet = False : Exit For
                    End If
                Next
                For Each row In Me._dtSetupSIM.Rows
                    iModel_ID_Local = Convert.ToInt32(row("Model_ID"))
                    If iModel_ID = iModel_ID_Local Then
                        strMsg = "Already added in SIM card list."
                        bRet = False : Exit For
                    End If
                Next
                For Each row In Me._dtSetupAltSIM.Rows
                    iModel_ID_Local = Convert.ToInt32(row("Model_ID"))
                    If iModel_ID = iModel_ID_Local Then
                        strMsg = "Already added in Alt SIM card list."
                        bRet = False : Exit For
                    End If
                Next
                For Each row In Me._dtSetupCollateral.Rows
                    iModel_ID_Local = Convert.ToInt32(row("Model_ID"))
                    If iModel_ID = iModel_ID_Local Then
                        strMsg = "Already added in collateral list."
                        bRet = False : Exit For
                    End If
                Next

                Return bRet

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Function IsValidToAdd", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Sub BindSetupModels()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'Row, Model_ID, Model, IsBYOP_Model, Model_Desc, Class, Subclass, Techology, UPC, Weight, Height, Width, Length, UPC_DCode_ID, 
            'Class_DCode_ID, SubClass_DCode_ID, Tech_Dcode_ID, Prod_ID, Has_BC, User_ID, UpdateDate, AltSIM_Model, IsKeySIM, AltSIM_Model_ID

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                Me._dtSetupModels = Me._objBYOP_Kitting.getAllFulfillmentKittingModels(True)
                Me._dtSetupMasterItem = Me._dtSetupModels.Clone
                Me._dtSetupSIM = Me._dtSetupModels.Clone
                Me._dtSetupAltSIM = Me._dtSetupModels.Clone
                Me._dtSetupCollateral = Me._dtSetupModels.Clone

                Me.tdgSetUpModels.DataSource = Nothing : Me.lblSetupRecNum.Text = "Model Count: 0"

                If Me._dtSetupModels.Rows.Count > 0 Then
                    With Me.tdgSetUpModels
                        .DataSource = Me._dtSetupModels.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Row", "Model_ID", "Model", "Model_Desc"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("Model_Desc").Width = 300
                        '.Splits(0).DisplayColumns("IsBYOP_Model").FetchStyle = True 'for fetchcellevent to fire
                        '.Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '.Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End With
                    Me.lblSetupRecNum.Text = "Model Count: " & Me.tdgSetUpModels.RowCount
                    'Else
                    '    MessageBox.Show("No SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindSetupModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub BindSetupSelectedModels(ByVal dtSelected As DataTable, ByVal tdgSelected As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal lblQty As Label, ByVal bIsAltSIM As Boolean)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'Row, Model_ID, Model, Qty, IsBYOP_Model, Model_Desc, Class, Subclass, Techology, UPC, Weight, Height, Width, Length, 
            'UPC_DCode_ID, Class_DCode_ID, SubClass_DCode_ID, Tech_Dcode_ID, Prod_ID, Has_BC, User_ID, UpdateDate, Parent_Model, IsKeySIM, Parent_Model_ID

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                tdgSelected.DataSource = Nothing : lblQty.Text = "0"

                If dtSelected.Rows.Count > 0 Then
                    With tdgSelected
                        .DataSource = dtSelected.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            If bIsAltSIM Then
                                Select Case dbgc.Name
                                    Case "Model", "Qty", "Parent_Model"
                                        dbgc.Visible = True
                                    Case Else
                                        dbgc.Visible = False
                                End Select
                            Else
                                Select Case dbgc.Name
                                    Case "Model", "Qty", "Model_Desc"
                                        dbgc.Visible = True
                                    Case Else
                                        dbgc.Visible = False
                                End Select
                            End If
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("Model_Desc").Width = 200
                        '.Splits(0).DisplayColumns("IsKeySIM").FetchStyle = True 'for fetchcellevent to fire
                        '.Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '.Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End With
                    lblQty.Text = tdgSelected.RowCount
                    'Else
                    '    MessageBox.Show("No SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindSetupModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnRefreshSetupModels_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefreshSetupModels.Click
            Me.BindSetupModels()
        End Sub

        Private Sub tdgSIM_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgSIM.FetchRowStyle
            Dim iKeySIM As Integer = 0

            Try
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

            Try
                iKeySIM = CInt(Me.tdgAltSIM.Columns("IsKeySIM").CellText(e.Row))
                If iKeySIM = 1 Then
                    e.CellStyle.BackColor = Color.Khaki
                Else
                    e.CellStyle.BackColor = Color.White
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgAltSIM_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelMasterItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelMasterItem.Click
            Dim iModel_ID As Integer = 0
            Dim iRow As Integer = 0
            Dim row As DataRow

            Try
                If Not Me.tdgMasterItem.RowCount > 0 Then Exit Sub
                If Not Me.tdgMasterItem.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row in the master item list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgMasterItem.SelectedRows  'for one selected row
                    iModel_ID = Convert.ToInt32(Me.tdgMasterItem.Columns("Model_ID").CellText(iRow))
                    For Each row In Me._dtSetupMasterItem.Rows
                        If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                            row.Delete() : Exit For
                        End If
                    Next
                    Me._dtSetupMasterItem.AcceptChanges()
                    Me.BindSetupSelectedModels(Me._dtSetupMasterItem, Me.tdgMasterItem, Me.lblMasterItemQty, False)
                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnDelMasterItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelSIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelSIM.Click
            Dim iModel_ID As Integer = 0
            Dim iRow As Integer = 0
            Dim row As DataRow
            Dim bFound As Boolean = False

            Try
                If Not Me.tdgSIM.RowCount > 0 Then Exit Sub
                If Not Me.tdgSIM.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row in the SIM list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgSIM.SelectedRows  'for one selected row
                    iModel_ID = Convert.ToInt32(Me.tdgSIM.Columns("Model_ID").CellText(iRow))

                    'Check if this model has any Alt SIM
                    If Me._dtSetupAltSIM.Rows.Count > 0 Then
                        For Each row In Me._dtSetupAltSIM.Rows
                            If iModel_ID = Convert.ToInt32(row("Parent_Model_ID")) Then
                                bFound = True : Exit For
                            End If
                        Next
                    End If

                    If bFound Then
                        Dim strMyMsg As String = "This SIM model has Alt SIM model(s)." & Environment.NewLine
                        strMyMsg &= "This SIM model will be deleted, and related Alt SIM model(s) also will be deleted!" & Environment.NewLine
                        strMyMsg &= "Do you want to continue?"
                        Dim result = MessageBox.Show(strMyMsg, "Select", MessageBoxButtons.YesNo)
                       If result = DialogResult.No Then
                            Exit Sub
                        ElseIf result = DialogResult.Yes Then
                            'delete SIM model
                            For Each row In Me._dtSetupSIM.Rows
                                If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                                    row.Delete() : Exit For
                                End If
                            Next
                            Me._dtSetupSIM.AcceptChanges()
                            Me.BindSetupSelectedModels(Me._dtSetupSIM, Me.tdgSIM, Me.lblSimQty, False)

                            'delete Alt SIM model(s )
                            Dim iIdx As Integer = 0
                            For iIdx = (Me._dtSetupAltSIM.Rows.Count - 1) To 0 Step -1
                                If iModel_ID = Convert.ToInt32(Me._dtSetupAltSIM.Rows(iIdx).Item("Parent_Model_ID")) Then
                                    Me._dtSetupAltSIM.Rows(iIdx).Delete()
                                End If
                            Next
                            Me._dtSetupAltSIM.AcceptChanges()
                            Me.BindSetupSelectedModels(Me._dtSetupAltSIM, Me.tdgAltSIM, Me.lblAltSimQty, True)
                        End If
                    Else
                        'delete SIM model
                        For Each row In Me._dtSetupSIM.Rows
                            If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                                row.Delete() : Exit For
                            End If
                        Next
                        Me._dtSetupSIM.AcceptChanges()
                        Me.BindSetupSelectedModels(Me._dtSetupSIM, Me.tdgSIM, Me.lblSimQty, False)
                    End If

                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnDelSIM_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelAltSIM_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelAltSIM.Click
            Dim iModel_ID As Integer = 0
            Dim iRow As Integer = 0
            Dim row As DataRow

            Try
                If Not Me.tdgAltSIM.RowCount > 0 Then Exit Sub
                If Not Me.tdgAltSIM.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row in the Alt SIM list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgAltSIM.SelectedRows  'for one selected row
                    iModel_ID = Convert.ToInt32(Me.tdgAltSIM.Columns("Model_ID").CellText(iRow))
                    For Each row In Me._dtSetupAltSIM.Rows
                        If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                            row.Delete() : Exit For
                        End If
                    Next
                    Me._dtSetupAltSIM.AcceptChanges()
                    Me.BindSetupSelectedModels(Me._dtSetupAltSIM, Me.tdgAltSIM, Me.lblAltSimQty, True)
                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnDelAltSIM_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelCollateral_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelCollateral.Click
            Dim iModel_ID As Integer = 0
            Dim iRow As Integer = 0
            Dim row As DataRow

            Try
                If Not Me.tdgCollateral.RowCount > 0 Then Exit Sub
                If Not Me.tdgCollateral.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row in the collateral list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgCollateral.SelectedRows  'for one selected row
                    iModel_ID = Convert.ToInt32(Me.tdgCollateral.Columns("Model_ID").CellText(iRow))
                    For Each row In Me._dtSetupCollateral.Rows
                        If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                            row.Delete() : Exit For
                        End If
                    Next
                    Me._dtSetupCollateral.AcceptChanges()
                    Me.BindSetupSelectedModels(Me._dtSetupCollateral, Me.tdgCollateral, Me.lblCollateralQty, False)
                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnDelCollateral_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtPackQtyPerCarton_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPackQtyPerCarton.Leave
            Try
                Me.txtPackQtyPerCarton.BackColor = System.Drawing.Color.LightCyan
            Catch ex As Exception
            End Try
        End Sub

        Private Sub txtPackQtyPerCarton_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPackQtyPerCarton.Enter
            Try
                Me.txtPackQtyPerCarton.BackColor = System.Drawing.Color.LightCyan
            Catch ex As Exception
            End Try
        End Sub

        Private Sub btnComplete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim iHasItemUPC12 As Integer = 1
            Dim strProfileName As String = ""
            Dim strProfileName_New As String = ""
            Dim strPostFix As String = ""
            Dim i As Integer = 0

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If Not Me._dtSetupMasterItem.Rows.Count > 0 OrElse Not Me.tdgMasterItem.RowCount > 0  Then
                    MessageBox.Show("Master item has no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Me._dtSetupMasterItem.Rows.Count = 1  OrElse Not Me.tdgMasterItem.RowCount = 1 Then
                    MessageBox.Show("More than 1 master item is not allowed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Me._dtSetupSIM.Rows.Count > 0 OrElse Not Me.tdgSIM.RowCount > 0 Then
                    MessageBox.Show("No SIM data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Me._dtSetupCollateral.Rows.Count > 0 OrElse Not Me.tdgCollateral.RowCount > 0 Then
                    Dim result0 = MessageBox.Show("No collateral data. Does this kitting profile require any collateral item? ", "Confirm", MessageBoxButtons.YesNo)
                    If result0 = DialogResult.Yes Then Exit Sub
                End If

                If Me.txtUPC.Text.Trim.Length = 0 Then
                    MessageBox.Show("UPC(14) has no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtUPC.SelectAll() : Me.txtUPC.Focus() : Exit Sub
                ElseIf Not Me.txtUPC.Text.Trim.Length = 14 Then
                    MessageBox.Show("Invalid UPC(14). It is not 14 in UPC length.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtUPC.SelectAll() : Me.txtUPC.Focus() : Exit Sub
                ElseIf Me.txtItemUPC.Text.Trim.Length > 0 AndAlso Not Me.txtItemUPC.Text.Trim.Length = 12 Then
                    MessageBox.Show("Invalid item UPC. It is not 12 in item UPC length.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtUPC.SelectAll() : Me.txtUPC.Focus() : Exit Sub
                ElseIf Not Convert.ToInt32(Me.txtPackQtyPerCarton.Text) = Me._objTFFK._iKittedPackQtyPerCarton Then
                    MessageBox.Show("Invalid Pack Qty Per Carton. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not IsNumeric(Me.txtMaxCartonQtyPerPallet.Text) AndAlso Not Convert.ToInt32(Me.txtMaxCartonQtyPerPallet.Text) > 0 Then
                    MessageBox.Show("Invalid Max Carton Qty Per Pallet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtMaxCartonQtyPerPallet.SelectAll() : Me.txtMaxCartonQtyPerPallet.Focus() : Exit Sub
                ElseIf Me.txtItemUPC.Text.Trim.Length = 0 Then
                    Dim result = MessageBox.Show("No Item UPC(12) data. Does this kitting profile need item UPC(12)? ", "Select", MessageBoxButtons.YesNo)
                    If result = DialogResult.No Then
                        iHasItemUPC12 = 0
                    ElseIf result = DialogResult.Yes Then
                        Me.txtItemUPC.SelectAll() : Me.txtItemUPC.Focus() : Exit Sub
                    End If
                End If

                'Ready to save 
                If Me._iKMSet_ID = 0 Then
                    Me._iKMSet_ID = Me._objBYOP_Kitting.CreateKittingSetupProfileID(Convert.ToString(Me._dtSetupMasterItem.Rows(0).Item("Model")), 0, _
                                                                                    strProfileName, strPostFix, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                Else
                    MessageBox.Show("Failed to complete this setup profile. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                Dim fmProfileName As New frmTFFK_BYOP_Kitting_Setup_ProfName(strProfileName, strPostFix)
                fmProfileName.ShowDialog()
                strProfileName_New = fmProfileName.getSetupProfileName_Final 'for debug to check

                i = Me._objBYOP_Kitting.SaveKittingSetupProfileData(Me._iKMSet_ID, 1, Me._dtSetupMasterItem, Me._dtSetupSIM, Me._dtSetupAltSIM, Me._dtSetupCollateral, _
                                                                    Me.txtUPC.Text.Trim, Me.txtItemUPC.Text.Trim, iHasItemUPC12, Convert.ToInt32(Me.txtPackQtyPerCarton.Text), _
                                                                    Convert.ToInt32(Me.txtMaxCartonQtyPerPallet.Text), Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))

                If i >= 1 Then
                    MessageBox.Show("Successed!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    'clean up
                    Me._iKMSet_ID = 0 : Me.txtUPC.Text = "" : Me.txtItemUPC.Text = ""
                    Me.lblMasterItemQty.Text = 0 : Me.lblSimQty.Text = 0 : Me.lblAltSimQty.Text = 0 : Me.lblCollateralQty.Text = 0
                    Me.txtPackQtyPerCarton.ReadOnly = True : Me.txtPackQtyPerCarton.BackColor = System.Drawing.Color.LightCyan 'Cornsilk
                    Me.txtPackQtyPerCarton.Text = Me._objTFFK._iKittedPackQtyPerCarton.ToString
                    Me.txtMaxCartonQtyPerPallet.Text = Me._objTFFK._iMaxCartonQtyPerPallet.ToString
                    Me.tdgMasterItem.DataSource = Nothing : Me.tdgSIM.DataSource = Nothing
                    Me.tdgAltSIM.DataSource = Nothing : Me.tdgCollateral.DataSource = Nothing
                    Me.BindSetupModels()
                Else
                    MessageBox.Show("Failed to save setup profile data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub rbtLocalPC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtLocalPC.CheckedChanged

            Try
                If Me.rbtLocalPC.Checked Then
                    Me.tdgLabelPrinters.DataSource = Nothing
                    Me.txtOtherPC.Text = "" : Me.txtOtherPC.Enabled = False
                    Me.lblLocalPC.Text = Me._strComputerName.Trim
                    Dim dt As DataTable = Me._objBYOP_Kitting.getLabelPrinterSetupData(Me._strComputerName.Trim)

                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show("No label printer setup data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Me.BindLabelPrinterData(dt)

                        dt = Nothing
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub rbtLocalPC_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub rbtOtherPC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtOtherPC.CheckedChanged
            Try
                If Me.rbtOtherPC.Checked Then
                    Me.tdgLabelPrinters.DataSource = Nothing
                    Me.txtOtherPC.Enabled = True
                    Me.txtOtherPC.SelectAll() : Me.txtOtherPC.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub rbtOtherPC_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtOtherPC_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOtherPC.KeyUp
            Try
                Me.tdgLabelPrinters.DataSource = Nothing
                If e.KeyCode = Keys.Enter AndAlso Me.txtOtherPC.Text.Trim.Length > 0 Then
                    Dim dt As DataTable = Me._objBYOP_Kitting.getLabelPrinterSetupData(Me.txtOtherPC.Text.Trim)
                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show("No label printer setup data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        Me.BindLabelPrinterData(dt)
                        dt = Nothing
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub txtOtherPC_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindLabelPrinterData(ByVal dtLabelPrinterData As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'Row, Process_Type, Label_Desc, Workstation, Printer_Name,Printer_Name_Old, Klb_ID, KLPRT_ID, OrderBy

            Try

                If dtLabelPrinterData.Rows.Count > 0 Then
                    With Me.tdgLabelPrinters
                        .DataSource = dtLabelPrinterData.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            Select Case dbgc.Name
                                Case "Printer_Name"
                                    dbgc.Locked = False
                                Case Else
                                    dbgc.Locked = True
                            End Select
                            Select Case dbgc.Name
                                Case "Row", "Process_Type", "Label_Desc", "Workstation", "Printer_Name"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("Printer_Name").Width = 200
                        .Splits(0).DisplayColumns("Printer_Name").FetchStyle = True 'for fetchcellevent to fire
                        '.Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '.Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindLabelPrinterData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub tdgLabelPrinters_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdgLabelPrinters.FetchCellStyle
            Dim strPrinterName As String = ""
            Dim strPrinterNameOld As String = ""

            Try
                strPrinterName = Me.tdgLabelPrinters.Columns("Printer_Name").CellText(e.Row)
                strPrinterNameOld = Me.tdgLabelPrinters.Columns("Printer_Name_Old").CellText(e.Row)
                If strPrinterName.Trim.ToUpper <> strPrinterNameOld.Trim.ToUpper Then
                    e.CellStyle.ForeColor = Color.Red
                Else
                    e.CellStyle.ForeColor = Color.MediumBlue
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgLabelPrinters_FetchCellStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnSaveLabelPrinterSetup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveLabelPrinterSetup.Click
            Dim iRow As Integer = 0
            Dim strPrinterName As String = ""
            Dim strPrinterNameOld As String = ""
            Dim strWorkstationName As String = ""
            Dim iKlb_ID As Integer = 0
            Dim bUpdated As Boolean = False

            Try
                For iRow = 0 To Me.tdgLabelPrinters.RowCount - 1
                    strPrinterName = Me.tdgLabelPrinters.Columns("Printer_Name").CellText(iRow)
                    strPrinterNameOld = Me.tdgLabelPrinters.Columns("Printer_Name_Old").CellText(iRow)
                    strWorkstationName = Me.tdgLabelPrinters.Columns("WorkStation").CellText(iRow)
                    iKlb_ID = Convert.ToInt32(Me.tdgLabelPrinters.Columns("klb_id").CellText(iRow))
                    If strPrinterName.Trim.ToUpper <> strPrinterNameOld.Trim.ToUpper Then
                        'MessageBox.Show("strPrinterName = " & strPrinterName & "strPrinterNameOld = " & strPrinterNameOld, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me._objBYOP_Kitting.SaveLabelPrinterData(strWorkstationName, strPrinterName, iKlb_ID, Me._UserID, Format(Now, "yyyy-MM-dd HH:mm:ss"))
                        bUpdated = True
                    End If
                Next

                If bUpdated Then
                    Dim dt As DataTable = Me._objBYOP_Kitting.getLabelPrinterSetupData(strWorkstationName.Trim)
                    Me.BindLabelPrinterData(dt)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnSaveLabelPrinterSetup_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

    End Class
End Namespace