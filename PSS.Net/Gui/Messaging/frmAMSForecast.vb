
Option Explicit On 

Imports System.IO
Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmAMSForecast
        Inherits System.Windows.Forms.Form

        Private _objAMS As Data.Buisness.MessMisc
        Private _bReadyToUpdateSPQtyGrid As Boolean = False
        Private _iLocID As Integer = 0
        Private _iLocN As Integer = PSS.Data.Buisness.SkyTel.CriticalAlertNorth_LOC_ID
        Private _iLocS As Integer = PSS.Data.Buisness.SkyTel.CriticalAlertSouth_LOC_ID

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objAMS = New Data.Buisness.MessMisc()

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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents txtSourceFile As System.Windows.Forms.TextBox
        Friend WithEvents btnSaveData As System.Windows.Forms.Button
        Friend WithEvents btnGetExcelData As System.Windows.Forms.Button
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents dtpWeekStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtWeekQty As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnClearAll As System.Windows.Forms.Button
        Friend WithEvents dbgExcelData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgExistedData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tpgUploadingData As System.Windows.Forms.TabPage
        Friend WithEvents tpgExistingData As System.Windows.Forms.TabPage
        Friend WithEvents pnlHeader As System.Windows.Forms.Panel
        Friend WithEvents tpgFCShipments As System.Windows.Forms.TabPage
        Friend WithEvents btnGetFCShipments As System.Windows.Forms.Button
        Friend WithEvents dbgView As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCopyAll_FC As System.Windows.Forms.Button
        Friend WithEvents btnTest As System.Windows.Forms.Button
        Friend WithEvents txtTestDate As System.Windows.Forms.TextBox
        Friend WithEvents tpgExistingDataSpecial As System.Windows.Forms.TabPage
        Friend WithEvents lblWeekStartDate As System.Windows.Forms.Label
        Friend WithEvents btnCopySelectedRows2 As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll2 As System.Windows.Forms.Button
        Friend WithEvents btnRefresh2 As System.Windows.Forms.Button
        Friend WithEvents dbgExistedData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents chkHistory As System.Windows.Forms.CheckBox
        Friend WithEvents btnCloseSpecial As System.Windows.Forms.Button
        Friend WithEvents gbType As System.Windows.Forms.GroupBox
        Friend WithEvents rbtnSpQtyUpload As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnRegQtyUpload As System.Windows.Forms.RadioButton
        Friend WithEvents gbLocation As System.Windows.Forms.GroupBox
        Friend WithEvents rbtnNorth As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnSouth As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAMSForecast))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpgUploadingData = New System.Windows.Forms.TabPage()
            Me.gbType = New System.Windows.Forms.GroupBox()
            Me.rbtnSpQtyUpload = New System.Windows.Forms.RadioButton()
            Me.rbtnRegQtyUpload = New System.Windows.Forms.RadioButton()
            Me.gbLocation = New System.Windows.Forms.GroupBox()
            Me.rbtnNorth = New System.Windows.Forms.RadioButton()
            Me.rbtnSouth = New System.Windows.Forms.RadioButton()
            Me.btnClearAll = New System.Windows.Forms.Button()
            Me.txtSourceFile = New System.Windows.Forms.TextBox()
            Me.dbgExcelData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnSaveData = New System.Windows.Forms.Button()
            Me.btnGetExcelData = New System.Windows.Forms.Button()
            Me.tpgExistingData = New System.Windows.Forms.TabPage()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.dbgExistedData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgExistingDataSpecial = New System.Windows.Forms.TabPage()
            Me.btnCloseSpecial = New System.Windows.Forms.Button()
            Me.chkHistory = New System.Windows.Forms.CheckBox()
            Me.btnCopySelectedRows2 = New System.Windows.Forms.Button()
            Me.btnCopyAll2 = New System.Windows.Forms.Button()
            Me.btnRefresh2 = New System.Windows.Forms.Button()
            Me.dbgExistedData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgFCShipments = New System.Windows.Forms.TabPage()
            Me.txtTestDate = New System.Windows.Forms.TextBox()
            Me.btnTest = New System.Windows.Forms.Button()
            Me.btnCopyAll_FC = New System.Windows.Forms.Button()
            Me.dbgView = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnGetFCShipments = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtWeekQty = New System.Windows.Forms.TextBox()
            Me.lblWeekStartDate = New System.Windows.Forms.Label()
            Me.dtpWeekStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.pnlHeader = New System.Windows.Forms.Panel()
            Me.TabControl1.SuspendLayout()
            Me.tpgUploadingData.SuspendLayout()
            Me.gbType.SuspendLayout()
            Me.gbLocation.SuspendLayout()
            CType(Me.dbgExcelData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgExistingData.SuspendLayout()
            CType(Me.dbgExistedData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgExistingDataSpecial.SuspendLayout()
            CType(Me.dbgExistedData2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgFCShipments.SuspendLayout()
            CType(Me.dbgView, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlHeader.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgUploadingData, Me.tpgExistingData, Me.tpgExistingDataSpecial, Me.tpgFCShipments})
            Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(24, 48)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(832, 544)
            Me.TabControl1.TabIndex = 2
            '
            'tpgUploadingData
            '
            Me.tpgUploadingData.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgUploadingData.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbType, Me.gbLocation, Me.btnClearAll, Me.txtSourceFile, Me.dbgExcelData, Me.btnSaveData, Me.btnGetExcelData})
            Me.tpgUploadingData.Location = New System.Drawing.Point(4, 23)
            Me.tpgUploadingData.Name = "tpgUploadingData"
            Me.tpgUploadingData.Size = New System.Drawing.Size(824, 517)
            Me.tpgUploadingData.TabIndex = 0
            Me.tpgUploadingData.Text = "Upload Data"
            '
            'gbType
            '
            Me.gbType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnSpQtyUpload, Me.rbtnRegQtyUpload})
            Me.gbType.Location = New System.Drawing.Point(16, 0)
            Me.gbType.Name = "gbType"
            Me.gbType.Size = New System.Drawing.Size(224, 48)
            Me.gbType.TabIndex = 118
            Me.gbType.TabStop = False
            Me.gbType.Text = "Type"
            '
            'rbtnSpQtyUpload
            '
            Me.rbtnSpQtyUpload.Location = New System.Drawing.Point(88, 16)
            Me.rbtnSpQtyUpload.Name = "rbtnSpQtyUpload"
            Me.rbtnSpQtyUpload.Size = New System.Drawing.Size(128, 24)
            Me.rbtnSpQtyUpload.TabIndex = 111
            Me.rbtnSpQtyUpload.Text = "Special Requested"
            '
            'rbtnRegQtyUpload
            '
            Me.rbtnRegQtyUpload.Location = New System.Drawing.Point(8, 16)
            Me.rbtnRegQtyUpload.Name = "rbtnRegQtyUpload"
            Me.rbtnRegQtyUpload.Size = New System.Drawing.Size(80, 24)
            Me.rbtnRegQtyUpload.TabIndex = 112
            Me.rbtnRegQtyUpload.Text = "Regular"
            '
            'gbLocation
            '
            Me.gbLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnNorth, Me.rbtnSouth})
            Me.gbLocation.Location = New System.Drawing.Point(288, 0)
            Me.gbLocation.Name = "gbLocation"
            Me.gbLocation.Size = New System.Drawing.Size(136, 48)
            Me.gbLocation.TabIndex = 117
            Me.gbLocation.TabStop = False
            Me.gbLocation.Text = "Location"
            '
            'rbtnNorth
            '
            Me.rbtnNorth.Location = New System.Drawing.Point(8, 16)
            Me.rbtnNorth.Name = "rbtnNorth"
            Me.rbtnNorth.Size = New System.Drawing.Size(64, 24)
            Me.rbtnNorth.TabIndex = 113
            Me.rbtnNorth.Text = "North"
            '
            'rbtnSouth
            '
            Me.rbtnSouth.Location = New System.Drawing.Point(72, 16)
            Me.rbtnSouth.Name = "rbtnSouth"
            Me.rbtnSouth.Size = New System.Drawing.Size(56, 24)
            Me.rbtnSouth.TabIndex = 114
            Me.rbtnSouth.Text = "South"
            '
            'btnClearAll
            '
            Me.btnClearAll.BackColor = System.Drawing.SystemColors.Control
            Me.btnClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearAll.ForeColor = System.Drawing.Color.Blue
            Me.btnClearAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnClearAll.Location = New System.Drawing.Point(496, 8)
            Me.btnClearAll.Name = "btnClearAll"
            Me.btnClearAll.Size = New System.Drawing.Size(104, 26)
            Me.btnClearAll.TabIndex = 106
            Me.btnClearAll.TabStop = False
            Me.btnClearAll.Text = "Clear All"
            '
            'txtSourceFile
            '
            Me.txtSourceFile.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtSourceFile.ForeColor = System.Drawing.Color.MediumBlue
            Me.txtSourceFile.Location = New System.Drawing.Point(24, 48)
            Me.txtSourceFile.Name = "txtSourceFile"
            Me.txtSourceFile.ReadOnly = True
            Me.txtSourceFile.Size = New System.Drawing.Size(792, 13)
            Me.txtSourceFile.TabIndex = 47
            Me.txtSourceFile.Text = ""
            Me.txtSourceFile.Visible = False
            '
            'dbgExcelData
            '
            Me.dbgExcelData.AllowUpdate = False
            Me.dbgExcelData.AlternatingRows = True
            Me.dbgExcelData.BackColor = System.Drawing.Color.GhostWhite
            Me.dbgExcelData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgExcelData.FetchRowStyles = True
            Me.dbgExcelData.FilterBar = True
            Me.dbgExcelData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgExcelData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgExcelData.Location = New System.Drawing.Point(32, 72)
            Me.dbgExcelData.Name = "dbgExcelData"
            Me.dbgExcelData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgExcelData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgExcelData.PreviewInfo.ZoomFactor = 75
            Me.dbgExcelData.Size = New System.Drawing.Size(792, 440)
            Me.dbgExcelData.TabIndex = 46
            Me.dbgExcelData.TabStop = False
            Me.dbgExcelData.Text = "C1TrueDBGrid1"
            Me.dbgExcelData.Visible = False
            Me.dbgExcelData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:C" & _
            "enter;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
            "Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" C" & _
            "olumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dott" & _
            "edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
            "1"" HorizontalScrollGroup=""1""><Height>438</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 790, 438</ClientRect><BorderSide>0</BorderSide><Bor" & _
            "derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 790, 438</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" " & _
            "/><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnSaveData
            '
            Me.btnSaveData.BackColor = System.Drawing.SystemColors.Control
            Me.btnSaveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveData.ForeColor = System.Drawing.Color.Blue
            Me.btnSaveData.Image = CType(resources.GetObject("btnSaveData.Image"), System.Drawing.Bitmap)
            Me.btnSaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnSaveData.Location = New System.Drawing.Point(728, 8)
            Me.btnSaveData.Name = "btnSaveData"
            Me.btnSaveData.Size = New System.Drawing.Size(88, 26)
            Me.btnSaveData.TabIndex = 44
            Me.btnSaveData.TabStop = False
            Me.btnSaveData.Text = "Save Data   "
            Me.btnSaveData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnGetExcelData
            '
            Me.btnGetExcelData.BackColor = System.Drawing.SystemColors.Control
            Me.btnGetExcelData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetExcelData.ForeColor = System.Drawing.Color.Blue
            Me.btnGetExcelData.Image = CType(resources.GetObject("btnGetExcelData.Image"), System.Drawing.Bitmap)
            Me.btnGetExcelData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnGetExcelData.Location = New System.Drawing.Point(616, 8)
            Me.btnGetExcelData.Name = "btnGetExcelData"
            Me.btnGetExcelData.Size = New System.Drawing.Size(104, 26)
            Me.btnGetExcelData.TabIndex = 43
            Me.btnGetExcelData.TabStop = False
            Me.btnGetExcelData.Text = "Get Data   "
            Me.btnGetExcelData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tpgExistingData
            '
            Me.tpgExistingData.BackColor = System.Drawing.Color.Lavender
            Me.tpgExistingData.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelectedRows, Me.btnCopyAll, Me.btnRefresh, Me.dbgExistedData})
            Me.tpgExistingData.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tpgExistingData.Location = New System.Drawing.Point(4, 23)
            Me.tpgExistingData.Name = "tpgExistingData"
            Me.tpgExistingData.Size = New System.Drawing.Size(824, 517)
            Me.tpgExistingData.TabIndex = 1
            Me.tpgExistingData.Text = "View Regular"
            Me.tpgExistingData.Visible = False
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.BackColor = System.Drawing.SystemColors.Control
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Black
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(640, 8)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(160, 23)
            Me.btnCopySelectedRows.TabIndex = 98
            Me.btnCopySelectedRows.TabStop = False
            Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.SystemColors.Control
            Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.Black
            Me.btnCopyAll.Location = New System.Drawing.Point(528, 8)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll.TabIndex = 97
            Me.btnCopyAll.TabStop = False
            Me.btnCopyAll.Text = "Copy All Rows"
            '
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.SystemColors.Control
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.Black
            Me.btnRefresh.Location = New System.Drawing.Point(392, 8)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(96, 24)
            Me.btnRefresh.TabIndex = 50
            Me.btnRefresh.TabStop = False
            Me.btnRefresh.Text = "Refresh"
            '
            'dbgExistedData
            '
            Me.dbgExistedData.AllowUpdate = False
            Me.dbgExistedData.AlternatingRows = True
            Me.dbgExistedData.BackColor = System.Drawing.Color.GhostWhite
            Me.dbgExistedData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgExistedData.CaptionHeight = 17
            Me.dbgExistedData.FetchRowStyles = True
            Me.dbgExistedData.FilterBar = True
            Me.dbgExistedData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgExistedData.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgExistedData.Location = New System.Drawing.Point(16, 40)
            Me.dbgExistedData.Name = "dbgExistedData"
            Me.dbgExistedData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgExistedData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgExistedData.PreviewInfo.ZoomFactor = 75
            Me.dbgExistedData.RowHeight = 15
            Me.dbgExistedData.Size = New System.Drawing.Size(784, 456)
            Me.dbgExistedData.TabIndex = 47
            Me.dbgExistedData.TabStop = False
            Me.dbgExistedData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Calibri, 8.25pt;}HighlightRow{ForeCol" & _
            "or:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage" & _
            ":Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;" & _
            "ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{" & _
            "}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeVie" & _
            "w Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17""" & _
            " ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Do" & _
            "ttedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup" & _
            "=""1"" HorizontalScrollGroup=""1""><Height>454</Height><CaptionStyle parent=""Style2""" & _
            " me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=" & _
            """EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foote" & _
            "rStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><" & _
            "HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highlight" & _
            "Row"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle p" & _
            "arent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""St" & _
            "yle11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" m" & _
            "e=""Style1"" /><ClientRect>0, 0, 782, 454</ClientRect><BorderSide>0</BorderSide><B" & _
            "orderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSt" & _
            "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
            " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
            "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
            "ent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style par" & _
            "ent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""" & _
            "Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pa" & _
            "rent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>" & _
            "1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><C" & _
            "lientArea>0, 0, 782, 454</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14" & _
            """ /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tpgExistingDataSpecial
            '
            Me.tpgExistingDataSpecial.BackColor = System.Drawing.Color.AliceBlue
            Me.tpgExistingDataSpecial.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCloseSpecial, Me.chkHistory, Me.btnCopySelectedRows2, Me.btnCopyAll2, Me.btnRefresh2, Me.dbgExistedData2})
            Me.tpgExistingDataSpecial.Location = New System.Drawing.Point(4, 23)
            Me.tpgExistingDataSpecial.Name = "tpgExistingDataSpecial"
            Me.tpgExistingDataSpecial.Size = New System.Drawing.Size(824, 517)
            Me.tpgExistingDataSpecial.TabIndex = 3
            Me.tpgExistingDataSpecial.Text = "View Special"
            '
            'btnCloseSpecial
            '
            Me.btnCloseSpecial.BackColor = System.Drawing.SystemColors.Control
            Me.btnCloseSpecial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseSpecial.ForeColor = System.Drawing.Color.Black
            Me.btnCloseSpecial.Location = New System.Drawing.Point(16, 8)
            Me.btnCloseSpecial.Name = "btnCloseSpecial"
            Me.btnCloseSpecial.Size = New System.Drawing.Size(152, 24)
            Me.btnCloseSpecial.TabIndex = 104
            Me.btnCloseSpecial.TabStop = False
            Me.btnCloseSpecial.Text = "Close Requested Qty"
            '
            'chkHistory
            '
            Me.chkHistory.Location = New System.Drawing.Point(232, 14)
            Me.chkHistory.Name = "chkHistory"
            Me.chkHistory.Size = New System.Drawing.Size(152, 16)
            Me.chkHistory.TabIndex = 103
            Me.chkHistory.Text = "Including closed data"
            '
            'btnCopySelectedRows2
            '
            Me.btnCopySelectedRows2.BackColor = System.Drawing.SystemColors.Control
            Me.btnCopySelectedRows2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows2.ForeColor = System.Drawing.Color.Black
            Me.btnCopySelectedRows2.Location = New System.Drawing.Point(640, 8)
            Me.btnCopySelectedRows2.Name = "btnCopySelectedRows2"
            Me.btnCopySelectedRows2.Size = New System.Drawing.Size(160, 23)
            Me.btnCopySelectedRows2.TabIndex = 102
            Me.btnCopySelectedRows2.TabStop = False
            Me.btnCopySelectedRows2.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll2
            '
            Me.btnCopyAll2.BackColor = System.Drawing.SystemColors.Control
            Me.btnCopyAll2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll2.ForeColor = System.Drawing.Color.Black
            Me.btnCopyAll2.Location = New System.Drawing.Point(528, 8)
            Me.btnCopyAll2.Name = "btnCopyAll2"
            Me.btnCopyAll2.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll2.TabIndex = 101
            Me.btnCopyAll2.TabStop = False
            Me.btnCopyAll2.Text = "Copy All Rows"
            '
            'btnRefresh2
            '
            Me.btnRefresh2.BackColor = System.Drawing.SystemColors.Control
            Me.btnRefresh2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh2.ForeColor = System.Drawing.Color.Black
            Me.btnRefresh2.Location = New System.Drawing.Point(392, 8)
            Me.btnRefresh2.Name = "btnRefresh2"
            Me.btnRefresh2.Size = New System.Drawing.Size(96, 24)
            Me.btnRefresh2.TabIndex = 100
            Me.btnRefresh2.TabStop = False
            Me.btnRefresh2.Text = "Refresh"
            '
            'dbgExistedData2
            '
            Me.dbgExistedData2.AlternatingRows = True
            Me.dbgExistedData2.BackColor = System.Drawing.Color.GhostWhite
            Me.dbgExistedData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgExistedData2.FetchRowStyles = True
            Me.dbgExistedData2.FilterBar = True
            Me.dbgExistedData2.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgExistedData2.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgExistedData2.Location = New System.Drawing.Point(16, 40)
            Me.dbgExistedData2.Name = "dbgExistedData2"
            Me.dbgExistedData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgExistedData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgExistedData2.PreviewInfo.ZoomFactor = 75
            Me.dbgExistedData2.Size = New System.Drawing.Size(784, 464)
            Me.dbgExistedData2.TabIndex = 99
            Me.dbgExistedData2.TabStop = False
            Me.dbgExistedData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:C" & _
            "enter;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
            "Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" C" & _
            "olumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dott" & _
            "edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
            "1"" HorizontalScrollGroup=""1""><Height>462</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 782, 462</ClientRect><BorderSide>0</BorderSide><Bor" & _
            "derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 782, 462</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" " & _
            "/><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tpgFCShipments
            '
            Me.tpgFCShipments.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTestDate, Me.btnTest, Me.btnCopyAll_FC, Me.dbgView, Me.btnGetFCShipments})
            Me.tpgFCShipments.Location = New System.Drawing.Point(4, 23)
            Me.tpgFCShipments.Name = "tpgFCShipments"
            Me.tpgFCShipments.Size = New System.Drawing.Size(824, 517)
            Me.tpgFCShipments.TabIndex = 2
            Me.tpgFCShipments.Text = "Forecasted vs. Shipments"
            '
            'txtTestDate
            '
            Me.txtTestDate.Location = New System.Drawing.Point(448, 16)
            Me.txtTestDate.Name = "txtTestDate"
            Me.txtTestDate.Size = New System.Drawing.Size(128, 20)
            Me.txtTestDate.TabIndex = 100
            Me.txtTestDate.Text = ""
            '
            'btnTest
            '
            Me.btnTest.Location = New System.Drawing.Point(296, 8)
            Me.btnTest.Name = "btnTest"
            Me.btnTest.Size = New System.Drawing.Size(144, 32)
            Me.btnTest.TabIndex = 99
            Me.btnTest.Text = "MonthForecated_Test(One Function)"
            '
            'btnCopyAll_FC
            '
            Me.btnCopyAll_FC.BackColor = System.Drawing.SystemColors.Control
            Me.btnCopyAll_FC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll_FC.ForeColor = System.Drawing.Color.Black
            Me.btnCopyAll_FC.Location = New System.Drawing.Point(712, 32)
            Me.btnCopyAll_FC.Name = "btnCopyAll_FC"
            Me.btnCopyAll_FC.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll_FC.TabIndex = 98
            Me.btnCopyAll_FC.TabStop = False
            Me.btnCopyAll_FC.Text = "Copy All Rows"
            '
            'dbgView
            '
            Me.dbgView.AllowUpdate = False
            Me.dbgView.AlternatingRows = True
            Me.dbgView.BackColor = System.Drawing.Color.GhostWhite
            Me.dbgView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgView.FetchRowStyles = True
            Me.dbgView.FilterBar = True
            Me.dbgView.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgView.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgView.Location = New System.Drawing.Point(32, 55)
            Me.dbgView.Name = "dbgView"
            Me.dbgView.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgView.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgView.PreviewInfo.ZoomFactor = 75
            Me.dbgView.Size = New System.Drawing.Size(784, 408)
            Me.dbgView.TabIndex = 48
            Me.dbgView.TabStop = False
            Me.dbgView.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:C" & _
            "enter;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
            "Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" C" & _
            "olumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dott" & _
            "edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
            "1"" HorizontalScrollGroup=""1""><Height>406</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 782, 406</ClientRect><BorderSide>0</BorderSide><Bor" & _
            "derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 782, 406</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" " & _
            "/><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnGetFCShipments
            '
            Me.btnGetFCShipments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetFCShipments.ForeColor = System.Drawing.Color.DarkGreen
            Me.btnGetFCShipments.Location = New System.Drawing.Point(16, 8)
            Me.btnGetFCShipments.Name = "btnGetFCShipments"
            Me.btnGetFCShipments.Size = New System.Drawing.Size(248, 32)
            Me.btnGetFCShipments.TabIndex = 0
            Me.btnGetFCShipments.Text = "Get Forecasted/Shipments Data"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(816, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(2, 8)
            Me.Label3.TabIndex = 105
            Me.Label3.Text = "Week Qty :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label3.Visible = False
            '
            'txtWeekQty
            '
            Me.txtWeekQty.Location = New System.Drawing.Point(848, 0)
            Me.txtWeekQty.Name = "txtWeekQty"
            Me.txtWeekQty.Size = New System.Drawing.Size(2, 20)
            Me.txtWeekQty.TabIndex = 2
            Me.txtWeekQty.Text = ""
            Me.txtWeekQty.Visible = False
            '
            'lblWeekStartDate
            '
            Me.lblWeekStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWeekStartDate.ForeColor = System.Drawing.Color.White
            Me.lblWeekStartDate.Location = New System.Drawing.Point(320, 16)
            Me.lblWeekStartDate.Name = "lblWeekStartDate"
            Me.lblWeekStartDate.Size = New System.Drawing.Size(112, 16)
            Me.lblWeekStartDate.TabIndex = 103
            Me.lblWeekStartDate.Text = "Week Start Date:"
            Me.lblWeekStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpWeekStartDate
            '
            Me.dtpWeekStartDate.Location = New System.Drawing.Point(440, 16)
            Me.dtpWeekStartDate.Name = "dtpWeekStartDate"
            Me.dtpWeekStartDate.Size = New System.Drawing.Size(192, 20)
            Me.dtpWeekStartDate.TabIndex = 1
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.White
            Me.lblCustomer.Location = New System.Drawing.Point(0, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(80, 16)
            Me.lblCustomer.TabIndex = 101
            Me.lblCustomer.Text = "Customer :"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboCustomer.ColumnHeaders = False
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(80, 16)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(224, 21)
            Me.cboCustomer.TabIndex = 0
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
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
            'pnlHeader
            '
            Me.pnlHeader.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCustomer, Me.cboCustomer, Me.Label3, Me.txtWeekQty, Me.dtpWeekStartDate, Me.lblWeekStartDate})
            Me.pnlHeader.Location = New System.Drawing.Point(32, 2)
            Me.pnlHeader.Name = "pnlHeader"
            Me.pnlHeader.Size = New System.Drawing.Size(848, 54)
            Me.pnlHeader.TabIndex = 106
            '
            'frmAMSForecast
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(872, 614)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.pnlHeader})
            Me.Name = "frmAMSForecast"
            Me.Text = "frmAMSForecast"
            Me.TabControl1.ResumeLayout(False)
            Me.tpgUploadingData.ResumeLayout(False)
            Me.gbType.ResumeLayout(False)
            Me.gbLocation.ResumeLayout(False)
            CType(Me.dbgExcelData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgExistingData.ResumeLayout(False)
            CType(Me.dbgExistedData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgExistingDataSpecial.ResumeLayout(False)
            CType(Me.dbgExistedData2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgFCShipments.ResumeLayout(False)
            CType(Me.dbgView, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlHeader.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***************************************************************************************************************
        Private Sub frmAMSForecast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Me.gbLocation.Visible = False
                Me.rbtnNorth.Visible = False
                Me.rbtnSouth.Visible = False
                Me.btnTest.Visible = False : Me.txtTestDate.Visible = False
                Me.btnGetFCShipments.Visible = False
                Me.TabControl1.Controls.Remove(tpgFCShipments)
                Me.TabControl1.SelectedIndex = 0
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

                dt = Generic.GetCustomers(True, 1, , , 10)
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = 0

                Me.rbtnRegQtyUpload.Checked = True
                Me.chkHistory.Checked = False

                Me.dtpWeekStartDate.Value = Now()
                Me.txtWeekQty.Text = ""

                Me.cboCustomer.SelectAll() : Me.cboCustomer.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmAMSForecast_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
            Try
                Me.cboCustomer.SelectedValue = 0

                Me.dtpWeekStartDate.Value = Now()
                Me.txtWeekQty.Text = ""
                Me.txtSourceFile.Text = ""
                Me.dbgExcelData.DataSource = Nothing
                Me.dbgExcelData.Visible = False
                Me.txtSourceFile.Visible = False

                Me.rbtnRegQtyUpload.Enabled = True
                Me.rbtnSpQtyUpload.Enabled = True
                Me.rbtnRegQtyUpload.Checked = True
                Me.gbLocation.Visible = False
                Me.rbtnNorth.Visible = False
                Me.rbtnNorth.Checked = False
                Me.rbtnNorth.ForeColor = Color.Black
                Me.rbtnSouth.Visible = False
                Me.rbtnSouth.Checked = False
                Me.rbtnSouth.ForeColor = Color.Black

                Me.btnSaveData.Enabled = False

                Me.cboCustomer.SelectAll() : Me.cboCustomer.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClearAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub btnGetExcelData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetExcelData.Click
            Dim strFileName As String = ""
            Dim dt As DataTable
            Dim OpenFileDialog1 As New Windows.Forms.OpenFileDialog()

            Try
                Me.btnSaveData.Enabled = False

                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.SelectAll() : Me.cboCustomer.Focus() : Exit Sub
                    'ElseIf Me.txtWeekQty.Text.Trim.Length = 0 OrElse Not IsNumeric(Me.txtWeekQty.Text.Trim) Then
                    '    MessageBox.Show("Invalid week quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtWeekQty.SelectAll() : Me.txtWeekQty.Focus() : Exit Sub
                End If

                If Not Me.rbtnRegQtyUpload.Checked AndAlso Not Me.rbtnSpQtyUpload.Checked Then
                    MessageBox.Show("Please select either Regular or Special.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                If cboCustomer.SelectedValue = 2599 Then
                    If Not Me.rbtnNorth.Checked AndAlso Not Me.rbtnSouth.Checked Then
                        MessageBox.Show("Please select either Location North or South.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

                Me.txtSourceFile.Text = "" : Me.dbgExcelData.DataSource = Nothing

                OpenFileDialog1.Filter = "Excel Files (*.xls; *.xlsx)|*.xls;*.xlsx"

                If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
                    strFileName = OpenFileDialog1.FileName
                    Me.txtSourceFile.Text = strFileName : Me.txtSourceFile.Visible = True
                    'Me.txtSourceFile.Text = Path.GetFileName(strFileName)

                    Me.Enabled = False : Cursor = Cursors.WaitCursor
                    If cboCustomer.SelectedValue = 2599 Then
                        If Me.rbtnRegQtyUpload.Checked AndAlso Me.rbtnNorth.Checked Or Me.rbtnRegQtyUpload.Checked AndAlso rbtnSouth.Checked Then
                            dt = Me._objAMS.LoadForecastExcelData(Me.cboCustomer.SelectedValue, Me._iLocID, Me.txtSourceFile.Text.Trim, False)
                        ElseIf Me.rbtnSpQtyUpload.Checked AndAlso Me.rbtnNorth.Checked Or Me.rbtnSpQtyUpload.Checked AndAlso rbtnSouth.Checked Then
                            dt = Me._objAMS.LoadForecastExcelData(Me.cboCustomer.SelectedValue, Me._iLocID, Me.txtSourceFile.Text.Trim, True)
                        Else
                            MessageBox.Show("Please select either Regular or Special.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    Else
                        If Me.rbtnRegQtyUpload.Checked Then
                            dt = Me._objAMS.LoadForecastExcelData(Me.cboCustomer.SelectedValue, Me._iLocID, Me.txtSourceFile.Text.Trim, False)
                        ElseIf Me.rbtnSpQtyUpload.Checked Then
                            dt = Me._objAMS.LoadForecastExcelData(Me.cboCustomer.SelectedValue, Me._iLocID, Me.txtSourceFile.Text.Trim, True)
                        End If
                    End If

                    With Me.dbgExcelData
                        .DataSource = dt.DefaultView

                        .Splits(0).DisplayColumns("Freq_ID").Visible = False
                        .Splits(0).DisplayColumns("Baud_ID").Visible = False
                        .Splits(0).DisplayColumns("HasFreq").Visible = False
                        .Splits(0).DisplayColumns("Model_ID").Visible = False

                        .Splits(0).DisplayColumns("LineNo").Width = 50
                        .Splits(0).DisplayColumns("Eq Type").Width = 200
                        .Splits(0).DisplayColumns("Format").Width = 120
                        .Splits(0).DisplayColumns(3).Width = 100
                        'If Me.rbtnSpQtyUpload.Checked Then
                        '    .Splits(0).DisplayColumns("Special Qty Needed").Width = 120
                        'Else
                        '    .Splits(0).DisplayColumns("Qty Needed Per Wk").Width = 120
                        'End If
                        .Splits(0).DisplayColumns("HasModel").Width = 60
                        .Visible = True
                    End With
                    If Not Me.rbtnRegQtyUpload.Checked Then Me.rbtnRegQtyUpload.Enabled = False
                    If Not Me.rbtnSpQtyUpload.Checked Then Me.rbtnSpQtyUpload.Enabled = False
                    If Not Me.rbtnNorth.Checked Then Me.rbtnNorth.Enabled = False
                    If Not Me.rbtnSouth.Checked Then Me.rbtnSouth.Enabled = False

                    Me.btnSaveData.Enabled = True
                Else
                    MsgBox("You did not select a file!")
                    Me.txtSourceFile.Text = ""
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnClearAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor = Cursors.Default
                OpenFileDialog1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub btnSaveData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveData.Click
            Dim dt As DataTable
            Dim dtStartDateOfWeek As Date
            Dim iWeekQty As Integer, i As Integer

            Try
                If Me.dbgExcelData.RowCount = 0 OrElse Me.dbgExcelData.Columns.Count = 0 Then Exit Sub

                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.SelectAll() : Me.cboCustomer.Focus() : Exit Sub
                    'ElseIf Me.txtWeekQty.Text.Trim.Length = 0 OrElse Not IsNumeric(Me.txtWeekQty.Text.Trim) Then
                    '    MessageBox.Show("Invalid format of week quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtWeekQty.SelectAll() : Me.txtWeekQty.Focus() : Exit Sub
                    'ElseIf CInt(Me.txtWeekQty.Text) = 0 Then
                    '    MessageBox.Show("Week quantity can't be zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtWeekQty.SelectAll() : Me.txtWeekQty.Focus() : Exit Sub
                Else
                    dt = Me.dbgExcelData.DataSource.Table
                    If dt.Select("Freq_ID = 0").Length > 0 Then Throw New Exception("No Frequency ID found for fequency/freq code at line # " & dt.Select("Freq_ID = 0")(0)("LineNo"))
                    If dt.Select("Baud_ID = 0").Length > 0 Then Throw New Exception("No Baud ID found for line # " & dt.Select("Baud_ID = 0")(0)("LineNo"))
                    If dt.Select("Model_ID = 0").Length > 0 Then Throw New Exception("No Model set up for line # " & dt.Select("Model_ID = 0")(0)("LineNo"))

                    dtStartDateOfWeek = DefineMondayOfWeek(Me.dtpWeekStartDate.Value)
                    'iWeekQty = CInt(Me.txtWeekQty.Text)

                    If Me.rbtnRegQtyUpload.Checked Then
                        'Delete and reset if any
                        i = Me._objAMS.DeleteAMSForcast_UnwantedData(Me.cboCustomer.SelectedValue, Me._iLocID, dtStartDateOfWeek.ToString("yyyy-MM-dd") & " 00:00:00")

                        'Update regular Qty data
                        'i = Me._objAMS.AMSFC_UploadingWeeklyForecast(Me.cboCustomer.SelectedValue, dtStartDateOfWeek.ToString("yyyy-MM-dd"), iWeekQty, dt, Me.chkSpecialRequest.Checked, Core.ApplicationUser.IDuser)
                        i = Me._objAMS.AMSFC_UploadingWeeklyForecast(Me.cboCustomer.SelectedValue, Me._iLocID, dtStartDateOfWeek.ToString("yyyy-MM-dd"), dt, Core.ApplicationUser.IDuser)
                    ElseIf Me.rbtnSpQtyUpload.Checked Then
                        'Insert special Qty data
                        i = Me._objAMS.AMSFC_InsertForecastSpecialQty(Me.cboCustomer.SelectedValue, Me._iLocID, dt, Core.ApplicationUser.IDuser)
                    Else
                        Throw New Exception("Either Regular or Special option isn't selected.")
                    End If

                    ''Update
                    ''i = Me._objAMS.AMSFC_UploadingWeeklyForecast(Me.cboCustomer.SelectedValue, dtStartDateOfWeek.ToString("yyyy-MM-dd"), iWeekQty, dt, Me.chkSpecialRequest.Checked, Core.ApplicationUser.IDuser)
                    'i = Me._objAMS.AMSFC_UploadingWeeklyForecast(Me.cboCustomer.SelectedValue, dtStartDateOfWeek.ToString("yyyy-MM-dd"), dt, Me.chkSpecialRequest.Checked, Core.ApplicationUser.IDuser)
                    If i > 0 Then
                        Me.dbgExcelData.DataSource = Nothing : Me.dbgExcelData.Visible = False
                        Me.btnSaveData.Enabled = False
                        Me.txtSourceFile.Text = ""
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.rbtnRegQtyUpload.Enabled = True
                Me.rbtnSpQtyUpload.Enabled = True
                Me.rbtnNorth.Enabled = True
                Me.rbtnSouth.Enabled = True
                Me.rbtnRegQtyUpload.Checked = True
                Me.rbtnSpQtyUpload.Checked = False
                Me.rbtnNorth.Checked = False
                Me.rbtnSouth.Checked = False
            End Try
        End Sub

        '***************************************************************************************************************
        Private Function DefineMondayOfWeek(ByVal dteDate As Date) As Date
            Dim dteRetVal As Date

            Try
                If Weekday(dteDate, FirstDayOfWeek.Monday) <> DayOfWeek.Monday Then
                    While Weekday(dteDate, FirstDayOfWeek.Monday) <> DayOfWeek.Monday
                        dteDate = DateAdd(DateInterval.Day, -1, dteDate)
                    End While
                End If

                dteRetVal = dteDate

                Return dteRetVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '***************************************************************************************************************
        Private Sub tpgExistingData_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgExistingData.VisibleChanged
            Try
                If tpgExistingData.Visible = True AndAlso Me.cboCustomer.SelectedValue > 0 AndAlso Me.txtWeekQty.Text.Trim.Length > 0 Then
                    Me.btnRefresh_Click(Nothing, Nothing)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tpgExistingData_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Dim dt As DataTable
            Dim dteStartDateOfWeek As Date
            Dim iWeekQty As Integer
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.SelectAll() : Me.cboCustomer.Focus() : Exit Sub
                    'ElseIf Me.txtWeekQty.Text.Trim.Length = 0 OrElse Not IsNumeric(Me.txtWeekQty.Text.Trim) Then
                    '    MessageBox.Show("Invalid format of week quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtWeekQty.SelectAll() : Me.txtWeekQty.Focus() : Exit Sub
                    'ElseIf CInt(Me.txtWeekQty.Text) = 0 Then
                    '    MessageBox.Show("Week quantity can't be zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    dteStartDateOfWeek = DefineMondayOfWeek(Me.dtpWeekStartDate.Value)
                    'iWeekQty = CInt(Me.txtWeekQty.Text)
                    'dt = Me._objAMS.AMSFC_GetAMSForcast(Me.cboCustomer.SelectedValue, dteStartDateOfWeek, iWeekQty)
                    dt = Me._objAMS.AMSFC_GetAMSForcast(Me.cboCustomer.SelectedValue, Me._iLocID, Format(dteStartDateOfWeek, "yyyy-MM-dd") & " 00:00:00")
                    With Me.dbgExistedData
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc
                    End With
                    Me.dbgExistedData.Visible = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub btnCopies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                    Handles btnCopyAll.Click, btnCopySelectedRows.Click, _
                     btnCopyAll2.Click, btnCopySelectedRows2.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Select Case sender.name
                    Case "btnCopyAll"
                        Misc.CopyAllData(Me.dbgExistedData)
                    Case "btnCopySelectedRows"
                        Misc.CopySelectedRowsData(Me.dbgExistedData)
                    Case "btnCopyAll2"
                        Misc.CopyAllData(Me.dbgExistedData2)
                    Case "btnCopySelectedRows2"
                        Misc.CopySelectedRowsData(Me.dbgExistedData2)
                End Select
                'If sender.name = "btnCopyAll" Then
                '    Misc.CopyAllData(Me.dbgExistedData)
                'ElseIf sender.name = "btnCopySelectedRows" Then
                '    Misc.CopySelectedRowsData(Me.dbgExistedData)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
            Try
                Select Case TabControl1.SelectedIndex
                    Case 0
                        Me.pnlHeader.Visible = True
                        If Me.rbtnSpQtyUpload.Checked Then
                            Me.lblWeekStartDate.Visible = False
                            Me.dtpWeekStartDate.Visible = False
                        Else
                            Me.lblWeekStartDate.Visible = True
                            Me.dtpWeekStartDate.Visible = True
                        End If
                        Me.dbgExistedData2.Visible = False
                        Me.dbgView.Visible = False : btnCopyAll_FC.Visible = False

                    Case 2
                        Me.pnlHeader.Visible = True
                        Me.lblWeekStartDate.Visible = False
                        Me.dtpWeekStartDate.Visible = False
                        Me.dbgExistedData2.Visible = False : btnCopyAll_FC.Visible = False
                    Case 3
                        Me.pnlHeader.Visible = False
                    Case Else
                        Me.pnlHeader.Visible = True
                        Me.lblWeekStartDate.Visible = True
                        Me.dtpWeekStartDate.Visible = True
                        Me.dbgView.Visible = False : btnCopyAll_FC.Visible = False
                        Me.dbgExistedData.Visible = False
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.Message, "TabControl1_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************************************

        Private Sub btnGetFCShipments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetFCShipments.Click
            'Dim currDate As Date = Now.Date
            'Dim wkBeginDate, wkEndDate, MonthWeeksBeginDate, MonthWeeksEndDate As Date
            'Dim mnBeginDate, mnEndDate, tmpDate, wkStartDate, mnBeginYrWkStartDate, mnEndYrWkStartDate As Date
            'Dim dayOfWeek As DayOfWeek
            'Dim dTB, dtDockShipped, dtCurrentWkDockShipped, dtProducedNotDockShipped, dtForecasted, dtFinal As DataTable
            'Dim dtMonthWeeksDays_Forecasted, dtTmp, dtWIPWithAQLPassed, dtAllWeekOfMonth_ForecastedNeed As DataTable
            'Dim row, row2 As DataRow
            'Dim i, iWeekIdx, iWeekCount As Integer
            'Dim strCustIDs As String
            'Dim ArrListCustIDs As New ArrayList()
            'Dim iCurrentWkForecast As Integer = 0, iCurrentMonthForecast As Integer = 0, bFoundVal As Boolean = False
            'Dim iCurrentWkSpecialQty As Integer = 0, iCurrentMonthSpecialQty As Integer = 0, bFoundVal2 As Boolean = False
            'Dim bAllColumns As Boolean = False

            'Me.Cursor = Cursors.WaitCursor

            ''currDate = currDate.AddDays(-5) 'for debug
            '' Me.dbgView.Visible = True : btnCopyAll_FC.Visible = True

            ' Try
            ''Generate month dates
            'mnBeginDate = currDate.AddDays(1 - currDate.Day)
            'mnEndDate = GetLastDayOfMonth2(currDate)

            ''Determine week begin and end day for the month, and Current week begin and end dates
            'Dim thisCulture = Globalization.CultureInfo.CurrentCulture
            'dayOfWeek = thisCulture.Calendar.GetDayOfWeek(mnBeginDate)
            'If Not dayOfWeek = System.DayOfWeek.Monday Then
            '    If dayOfWeek = System.DayOfWeek.Sunday Then
            '        MonthWeeksBeginDate = Generic.DateOfPreviousWeek(mnBeginDate, dayOfWeek.Monday, 1)
            '    Else
            '        MonthWeeksBeginDate = Generic.DateOfPreviousWeek(mnBeginDate, dayOfWeek.Monday, 0)
            '    End If
            'Else
            '    MonthWeeksBeginDate = mnBeginDate
            'End If
            'dayOfWeek = thisCulture.Calendar.GetDayOfWeek(mnEndDate)
            'If Not dayOfWeek = System.DayOfWeek.Sunday Then
            '    MonthWeeksEndDate = Generic.DateOfPreviousWeek(mnEndDate, dayOfWeek.Monday, 0)
            '    MonthWeeksEndDate = MonthWeeksEndDate.AddDays(6)
            'Else
            '    MonthWeeksEndDate = mnEndDate
            'End If

            'dayOfWeek = thisCulture.Calendar.GetDayOfWeek(currDate)
            'If dayOfWeek = System.DayOfWeek.Sunday Then
            '    wkBeginDate = Generic.DateOfPreviousWeek(currDate, dayOfWeek.Monday, 1)
            'Else
            '    wkBeginDate = Generic.DateOfPreviousWeek(currDate, dayOfWeek.Monday, 0)
            'End If
            'wkEndDate = wkBeginDate.AddDays(6)

            ''Build days of the month which includes all full weeks
            'dtMonthWeeksDays_Forecasted = Me._objAMS.MonthWeeksDays_TableDefinition
            'tmpDate = MonthWeeksBeginDate : i = 0
            'Do While tmpDate <= MonthWeeksEndDate
            '    i += 1
            '    Dim rowNew As DataRow = dtMonthWeeksDays_Forecasted.NewRow
            '    rowNew("ID") = i : rowNew("Year") = Year(tmpDate) : rowNew("Month") = Month(tmpDate)
            '    rowNew("WeekDay") = thisCulture.Calendar.GetDayOfWeek(tmpDate) : rowNew("Date") = tmpDate
            '    If i = 1 Then
            '        iWeekIdx = 1 : wkStartDate = tmpDate : mnBeginYrWkStartDate = tmpDate
            '    Else
            '        If rowNew("WeekDay") = "Monday" Then iWeekIdx += 1 : wkStartDate = tmpDate : mnEndYrWkStartDate = tmpDate
            '    End If
            '    rowNew("WeekIdx") = iWeekIdx
            '    rowNew("WeekStartDate") = wkStartDate
            '    dtMonthWeeksDays_Forecasted.Rows.Add(rowNew)
            '    tmpDate = tmpDate.AddDays(1)
            'Loop
            'iWeekCount = iWeekIdx
            ''Me.dbgView.DataSource = dtMonthWeeksDays_Forecasted


            ''Set Up the Required Customer IDs
            ''ArrListCustIDs.Add(PSS.Data.Buisness.SkyTel.AMS_CUSTOMER_ID) : ArrListCustIDs.Add(PSS.Data.Buisness.Messaging.Aquis_Cust_ID)
            ''ArrListCustIDs.Add(PSS.Data.Buisness.SkyTel.MorrisCom_CUSTOMER_ID) : ArrListCustIDs.Add(PSS.Data.Buisness.SkyTel.Propage_CUSTOMER_ID)
            ''ArrListCustIDs.Add(PSS.Data.Buisness.SkyTel.CookPager_CUSTOMER_ID)
            ''For i = 0 To ArrListCustIDs.Count - 1
            ''    If i = 0 Then strCustIDs = ArrListCustIDs(i) Else strCustIDs &= "," & ArrListCustIDs(i)
            ''Next
            'dtTmp = Me.cboCustomer.DataSource.Table : i = 0 : strCustIDs = ""
            'For Each row In dtTmp.Rows
            '    If row("Cust_ID") > 0 AndAlso row("Cust_ID") <> 2562 AndAlso row("Cust_ID") <> 2234 Then
            '        If i = 0 Then strCustIDs = row("Cust_ID") Else strCustIDs &= "," & row("Cust_ID")
            '        ArrListCustIDs.Add(row("Cust_ID"))
            '        i += 1
            '    End If
            'Next
            'If Not strCustIDs.Replace(",", "").Trim.Length > 0 Then
            '    MessageBox.Show("No customers!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            '    Exit Sub
            'End If

            ''Current month dock shpped data - Master --------------------------
            'dtDockShipped = Me._objAMS.getDockShippedData(strCustIDs, Format(mnBeginDate, "yyyy-MM-dd"), Format(currDate, "yyyy-MM-dd"))
            '    'Me.dbgView.DataSource = dtDockShipped
            '    'Exit Sub

            ''Add forecasted rows if Dockshiped don't have ---------------------
            'dtAllWeekOfMonth_ForecastedNeed = Me._objAMS.getAllWeeksOfMonth_ForecatedNeedData(strCustIDs, Format(mnBeginYrWkStartDate, "yyyy-MM-dd"), Format(mnEndYrWkStartDate, "yyyy-MM-dd"))
            'Me._objAMS.AddForecastedNotIncludedInDockShip(dtDockShipped, dtAllWeekOfMonth_ForecastedNeed)
            '    'Me.dbgView.DataSource = dtDockShipped
            '    'Exit Sub

            ''Cuurent week dock shpped data-------------------------------------
            'dtCurrentWkDockShipped = Me._objAMS.getDockShippedData(strCustIDs, Format(wkBeginDate, "yyyy-MM-dd"), Format(wkEndDate, "yyyy-MM-dd"))
            ''Me.dbgView.DataSource = dtCurrentWkDockShipped

            ''Update current week actual---------------------------------------
            'UpdateCurrentWeekActualValue(dtCurrentWkDockShipped, dtDockShipped)
            '    'Me.dbgView.DataSource = dtDockShipped
            '    'Exit Sub

            '    'Get existing producted but not shipped so far -----------------------
            '    'dtProducedNotDockShipped = Me._objAMS.getProducedButNotYetShippedData(strCustIDs, Format(mnBeginDate, "yyyy-MM-dd"), Format(currDate, "yyyy-MM-dd"))
            '    dtProducedNotDockShipped = Me._objAMS.getProducedButNotYetShippedData(strCustIDs)
            '    'Me.dbgView.DataSource = dtProducedNotDockShipped

            '    'Update producted but not shipped so far -------------------
            '    If dtProducedNotDockShipped.Rows.Count > 0 Then
            '        UpdateMonthProducedNotYetShipped(dtProducedNotDockShipped, dtDockShipped)
            '    End If
            '    'Me.dbgView.DataSource = dtDockShipped
            '    'Exit Sub

            '    'Get WIP with AQL passed data-----------------------
            '    'dtWIPWithAQLPassed = Me._objAMS.getWIPWithAQLPassedData(strCustIDs, Format(mnBeginDate, "yyyy-MM-dd"), Format(currDate, "yyyy-MM-dd"))
            '    dtWIPWithAQLPassed = Me._objAMS.getWIPWithAQLPassedData(strCustIDs)
            '    'Me.dbgView.DataSource = dtWIPWithAQLPassed

            '    'Update WIP with AQL passed -------------------
            '    If dtWIPWithAQLPassed.Rows.Count > 0 Then
            '        UpdateMonthWIPWithAQLPassed(dtWIPWithAQLPassed, dtDockShipped)
            '    End If
            '    'Me.dbgView.DataSource = dtDockShipped
            '    'Exit Sub

            '    'Update week and month forecasted and SpecialRequestedQty
            '    For Each row In dtDockShipped.Rows 'each row in  dtDockShipped.Rows
            '        If Trim(row("NewUniqueID")).Length > 0 Then  'valid ids
            '            'initial 
            '            For Each row2 In dtMonthWeeksDays_Forecasted.Rows 'reset
            '                row2("WeekForecast") = DBNull.Value : row2("SpecialQty") = DBNull.Value : row2.AcceptChanges()
            '            Next

            '            'Week forecast
            '            For Each row2 In dtMonthWeeksDays_Forecasted.Rows 'each day 
            '                'dtForecasted = Me._objAMS.getForecastedData(row("Cust_ID"), Format(row2("WeekStartDate"), "yyyy-MM-dd"), row("Model"), row("Freq_ID"), row("Baud_ID"))
            '                dtForecasted = Me._objAMS.getForecastedData(row("NewUniqueID"), Format(row2("WeekStartDate"), "yyyy-MM-dd"))
            '                If dtForecasted.Rows.Count > 0 Then
            '                    row2("WeekForecast") = dtForecasted.Rows(0).Item("Forecast") : row2.AcceptChanges() 'forecast
            '                    row2("SpecialQty") = dtForecasted.Rows(0).Item("SpecialRequestedQty") : row2.AcceptChanges() 'SpecialRequestedQty
            '                    row("Freq_code") = dtForecasted.Rows(0).Item("Freq_Code") : row.AcceptChanges() 'Freq code from AMS company
            '                End If
            '            Next
            '            'Me.dbgView.DataSource = dtMonthWeeksDays_Forecasted : Exit Sub

            '            'Current week forecast and SpecialQty
            '            bFoundVal = False : iCurrentWkForecast = 0 : bFoundVal2 = False : iCurrentWkSpecialQty = 0
            '            getCurrentWeekForecastValue(wkBeginDate, wkEndDate, dtMonthWeeksDays_Forecasted, bFoundVal, iCurrentWkForecast, bFoundVal2, iCurrentWkSpecialQty)
            '            If bFoundVal Then
            '                row("wkForecast") = iCurrentWkForecast : row.AcceptChanges()
            '            End If
            '            If bFoundVal Then
            '                row("wkSpecialQty") = iCurrentWkSpecialQty : row.AcceptChanges()
            '            End If

            '            'Current month forecast and specialQty
            '            bFoundVal = False : iCurrentMonthForecast = 0 : bFoundVal2 = False : iCurrentMonthSpecialQty = 0
            '            getCurrentMonthForecastValue(mnBeginDate, mnEndDate, dtMonthWeeksDays_Forecasted, iWeekCount, bFoundVal, iCurrentMonthForecast, bFoundVal2, iCurrentMonthSpecialQty)
            '            If bFoundVal Then
            '                row("mnForecast") = iCurrentMonthForecast : row.AcceptChanges()
            '            End If
            '            If bFoundVal2 Then
            '                row("mnSpecialQty") = iCurrentMonthSpecialQty : row.AcceptChanges()
            '            End If
            '            'ResultDB = dtMonthWeeksDays_Forecasted
            '            'Exit Sub
            '        End If 'valid ids
            '    Next 'each row in  dtDockShipped.Rows
            '    'Me.dbgView.DataSource = dtDockShipped
            '    'Exit Sub

            '    Me.dbgView.DataSource = dtDockShipped

            '    'Re-sort it
            '    Dim dView As DataView = dtDockShipped.DefaultView 'New DataView(dtDockShipped)
            '    Dim rowView
            '    dView.Sort = "NewUniqueID" ',Column3 Asc" 'Desc
            '    dtFinal = dtDockShipped.Clone
            '    For Each rowView In dView
            '        row = rowView.Row
            '        dtFinal.ImportRow(row)
            '    Next
            '    dtDockShipped = Nothing

            '    'Remove unwanted columns 
            '    If Not bAllColumns Then
            '        dtFinal.Columns.Remove("Cust_ID") : dtFinal.Columns.Remove("Model_ID")
            '        dtFinal.Columns.Remove("Freq_ID") : dtFinal.Columns.Remove("Baud_ID")
            '        dtFinal.Columns.Remove("NewUniqueID") ' : dtFinal.Columns.Remove("Model_IDs")
            '        ' dtFinal.Columns.Remove("mnActuals_Grp") : dtFinal.Columns.Remove("Count_Grp")
            '    End If

            '    'Do excel report
            '    Me._objAMS.CreateExcelReport(dtFinal, currDate)


            'Catch ex As Exception
            '    MessageBox.Show(ex.Message, "btnGetFCShipments_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Finally
            '    Me.Cursor = Cursors.Default
            'End Try
        End Sub

        '***************************************************************************************************************
        Private Function GetLastDayOfMonth2(ByVal aDate As DateTime) As Date
            Return New DateTime(aDate.Year, aDate.Month, DateTime.DaysInMonth(aDate.Year, aDate.Month))
        End Function

        '***************************************************************************************************************
        Private Sub btnCopyAll_FC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll_FC.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Misc.CopyAllData(Me.dbgView)
            Catch ex As Exception
                MessageBox.Show(ex.Message(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub UpdateCurrentWeekActualValue(ByVal dtCurrentWeek As DataTable, _
                                                 ByRef dtCurrentMonth As DataTable)

            Dim filteredRows() As DataRow
            Dim strExpress As String
            Dim row, row2 As DataRow
            Dim iCount As Integer = 0

            Try
                For Each row In dtCurrentMonth.Rows
                    strExpress = "NewUniqueID = '" & row("NewUniqueID") & "'"
                    filteredRows = dtCurrentWeek.Select(strExpress)
                    For Each row2 In filteredRows 'should be one row  
                        row("wkActuals") = row2("mnActuals") : row.AcceptChanges()
                        iCount += 1
                    Next
                Next

                'Monthly dock shipped data should include weekly dock shipped data, so this should never happen: iCount <> dtCurrentWeek.Rows.Count
                'if happens, something isn't correct,for example, after we qury Monthly, new shipments happened and it resuts in dicrepancy
                'It is rare case in fact.
                If iCount <> dtCurrentWeek.Rows.Count Then
                    MessageBox.Show("Reminder: Week data didn't fully updated into month data.", "UpdateCurrentWeekActualValue", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "UpdateCurrentWeekActualValue", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub UpdateMonthProducedNotYetShipped(ByVal dtCurrentMonthProducedNotShipped As DataTable, _
                                                     ByRef dtCurrentMonthMaster As DataTable)

            Dim filteredRows() As DataRow
            Dim strExpress As String
            Dim row, row2, row3, rowNew As DataRow
            ' Dim iCount As Integer = 0

            Try
                For Each row In dtCurrentMonthMaster.Rows 'each row in master 
                    strExpress = "NewUniqueID = '" & row("NewUniqueID") & "'"
                    filteredRows = dtCurrentMonthProducedNotShipped.Select(strExpress)
                    For Each row2 In filteredRows 'should be one row
                        row("Produced_NotYetShipped") = row2("Produced_NotYetShipped") : row.AcceptChanges()
                        For Each row3 In dtCurrentMonthProducedNotShipped.Rows
                            If row3("NewUniqueID") = row2("NewUniqueID") Then
                                row3("UpdatedIntoMaster") = 1 : row3.AcceptChanges() 'update flag UpdatedIntoMaster
                                Exit For
                            End If
                        Next
                        'iCount += 1
                    Next
                Next 'each row in master 

                filteredRows = dtCurrentMonthProducedNotShipped.Select("UpdatedIntoMaster=0")
                For Each row In filteredRows ' Add it as a new row into master
                    rowNew = dtCurrentMonthMaster.NewRow
                    rowNew("Customer") = row("Customer") : rowNew("Freq_Code") = row("Freq_Code") : rowNew("Model") = row("Model")
                    rowNew("Frequency") = row("Frequency") : rowNew("Baud_Rate") = row("Baud_Rate") : rowNew("Space1") = ""
                    rowNew("wkForecast") = 0 : rowNew("wkSpecialQty") = 0 : rowNew("wkActuals") = 0
                    rowNew("wkVariance") = 0 : rowNew("Space2") = "" : rowNew("mnForecast") = 0
                    rowNew("mnActuals") = 0 : rowNew("mnSpecialQty") = 0 : rowNew("mnVariance") = 0
                    rowNew("Space3") = "" : rowNew("Produced_NotYetShipped") = row("Produced_NotYetShipped") : rowNew("WIP_AQL_Passed") = 0
                    rowNew("Net_Variance") = 0 : rowNew("Cust_ID") = row("Cust_ID") : rowNew("Model_ID") = row("Model_ID")
                    rowNew("Freq_ID") = row("Freq_ID") : rowNew("baud_ID") = row("baud_ID") : rowNew("NewUniqueID") = row("NewUniqueID")
                    ' rowNew("Model_IDs") = row("Model_IDs") : rowNew("mnActuals_Grp") = row("mnActuals_Grp")
                    'rowNew("Count_Grp") = row("Count_Grp")
                    dtCurrentMonthMaster.Rows.Add(rowNew)
                Next
                dtCurrentMonthMaster.AcceptChanges()

                'If iCount <> dtCurrentMonthProducedNotShipped.Rows.Count Then
                '    MessageBox.Show("CurrentMonthProducedNotShipped data didn't fully updated into month data.", "UpdateCurrentWeekActualValue", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "UpdateMonthProducedNotYetShipped", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub UpdateMonthWIPWithAQLPassed(ByVal dtCurrentMonthWIPWithAQLPassed As DataTable, _
                                                     ByRef dtCurrentMonthMaster As DataTable)

            Dim filteredRows() As DataRow
            Dim strExpress As String
            Dim row, row2, row3, rowNew As DataRow
            'Dim iCount As Integer = 0
            Dim dtCurrentMonthWIPWithAQLPassed_Grouped As DataTable
            Dim arrLstUniqueIDs As New ArrayList()
            Dim i As Integer = 0, j As Integer = 0, iSum As Integer = 0

            Try
                'Get unique IDs
                For Each row In dtCurrentMonthWIPWithAQLPassed.Rows
                    If Not arrLstUniqueIDs.Contains(row("NewUniqueID")) Then
                        arrLstUniqueIDs.Add(row("NewUniqueID"))
                    End If
                Next

                'Group by NewUniqueID
                dtCurrentMonthWIPWithAQLPassed_Grouped = dtCurrentMonthWIPWithAQLPassed.Clone
                For i = 0 To arrLstUniqueIDs.Count - 1 'each unique ID
                    strExpress = "NewUniqueID = '" & arrLstUniqueIDs(i) & "'"
                    filteredRows = dtCurrentMonthWIPWithAQLPassed.Select(strExpress)
                    j = 0 : iSum = 0
                    For Each row2 In filteredRows 'should be one row or more than one
                        j += 1
                        If Not row2.IsNull("WIP_AQL_Passed") Then
                            iSum += row2("WIP_AQL_Passed")
                        End If
                        If j = filteredRows.Length Then
                            row2("WIP_AQL_Passed") = iSum : row.AcceptChanges()
                            dtCurrentMonthWIPWithAQLPassed_Grouped.ImportRow(row2)
                        End If
                    Next 'should be one row or more than one
                Next 'each unique ID


                For Each row In dtCurrentMonthMaster.Rows 'each row in master 
                    strExpress = "NewUniqueID = '" & row("NewUniqueID") & "'"
                    filteredRows = dtCurrentMonthWIPWithAQLPassed_Grouped.Select(strExpress)
                    For Each row2 In filteredRows 'should be one row 
                        row("WIP_AQL_Passed") = row2("WIP_AQL_Passed") : row.AcceptChanges() 'updated master
                        For Each row3 In dtCurrentMonthWIPWithAQLPassed_Grouped.Rows
                            If row3("NewUniqueID") = row2("NewUniqueID") Then
                                row3("UpdatedIntoMaster") = 1 : row3.AcceptChanges() 'update flag UpdatedIntoMaster
                                Exit For
                            End If
                        Next
                        'iCount += 1
                    Next
                Next 'each row in master 

                filteredRows = dtCurrentMonthWIPWithAQLPassed_Grouped.Select("UpdatedIntoMaster=0")
                For Each row In filteredRows ' Add it as a new row into master
                    rowNew = dtCurrentMonthMaster.NewRow

                    rowNew("Customer") = row("Customer") : rowNew("Freq_Code") = row("Freq_Code") : rowNew("Model") = row("Model")
                    rowNew("Frequency") = row("Frequency") : rowNew("Baud_Rate") = row("Baud_Rate") : rowNew("Space1") = ""
                    rowNew("wkForecast") = 0 : rowNew("wkSpecialQty") = 0 : rowNew("wkActuals") = 0
                    rowNew("wkVariance") = 0 : rowNew("Space2") = "" : rowNew("mnForecast") = 0
                    rowNew("mnActuals") = 0 : rowNew("mnSpecialQty") = 0 : rowNew("mnVariance") = 0
                    rowNew("Space3") = "" : rowNew("Produced_NotYetShipped") = 0 : rowNew("WIP_AQL_Passed") = row("WIP_AQL_Passed")
                    rowNew("Net_Variance") = 0 : rowNew("Cust_ID") = row("Cust_ID") : rowNew("Model_ID") = row("Model_ID")
                    rowNew("Freq_ID") = row("Freq_ID") : rowNew("baud_ID") = row("baud_ID") : rowNew("NewUniqueID") = row("NewUniqueID")
                    'rowNew("Model_IDs") = row("Model_IDs") : rowNew("mnActuals_Grp") = row("mnActuals_Grp")
                    'rowNew("Count_Grp") = row("Count_Grp")
                    dtCurrentMonthMaster.Rows.Add(rowNew)
                Next
                dtCurrentMonthMaster.AcceptChanges()

                'If iCount <> dtCurrentMonthWIPWithAQLPassed.Rows.Count Then
                '    MessageBox.Show("dtCurrentMonthWIPWithAQLPassed data didn't fully updated into month data.", "UpdateCurrentWeekActualValue", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "UpdateMonthWIPWithAQLPassed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub getCurrentWeekForecastValue(ByVal wkBegdate As Date, ByVal wkEndDate As Date, _
                                                  ByVal dtMonthWeeksDaysForecasted As DataTable, _
                                                  ByRef bFound As Boolean, ByRef iVal As Integer, _
                                                  ByRef bFound2 As Boolean, ByRef iVal2 As Integer)

            Dim v As Integer = 0, n As Integer = 0
            Dim v2 As Integer = 0, n2 As Integer = 0
            Dim row As DataRow

            Try
                Dim dtFilteredRows() As DataRow = dtMonthWeeksDaysForecasted.Select("[date] >= #" & wkBegdate & "# and [Date]<=#" & wkEndDate & "#")
                Dim arrListWeekDays As ArrayList = Me._objAMS.getRequiredWorkingWeekDays
                bFound = False

                If dtFilteredRows.Length = 7 Then
                    For Each row In dtFilteredRows
                        If arrListWeekDays.Contains(row("WeekDay")) Then
                            If Not row.IsNull("WeekForecast") Then
                                v += row("WeekForecast") : n += 1
                            End If
                        End If
                        If arrListWeekDays.Contains(row("WeekDay")) Then
                            If Not row.IsNull("SpecialQty") Then
                                v2 += row("SpecialQty") : n2 += 1
                            End If
                        End If
                    Next
                    If n > 0 Then
                        bFound = True
                        iVal = Math.Ceiling((v / n))
                    End If
                    If n2 > 0 Then
                        bFound2 = True
                        iVal2 = Math.Ceiling((v2 / n2))
                    End If
                Else
                    MessageBox.Show("Invalid week length does not equal to 7 in getCurrentWeekForecastValue.", "getCurrentWeekForecastValue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "getCurrentWeekForecastValue", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '***************************************************************************************************************
        Private Sub getCurrentMonthForecastValue(ByVal mnBeginDate As Date, ByVal mnEndDate As Date, _
                                                ByVal dtMonthWeeksDaysForecasted As DataTable, ByVal iWeekCount As Integer, _
                                                ByRef bFound As Boolean, ByRef iVal As Integer, _
                                                ByRef bFound2 As Boolean, ByRef iVal2 As Integer)

            Dim v As Integer = 0, n As Integer = 0, iCnt As Integer = 0, m As Integer = 0
            Dim vWeekResult As Integer = 0, iMonthTotal As Integer = 0, vDailyAvgOfWeek As Double = 0
            Dim v2 As Integer = 0, n2 As Integer = 0, iCnt2 As Integer = 0, m2 As Integer = 0
            Dim vWeekResult2 As Integer = 0, iMonthTotal2 As Integer = 0, vDailyAvgOfWeek2 As Double = 0
            Dim dtFilteredRows() As DataRow
            Dim dtMonthFilteredRows() As DataRow
            Dim row As DataRow
            Dim k As Integer

            Try
                Dim arrListWeekDays As ArrayList = Me._objAMS.getRequiredWorkingWeekDays
                bFound = False : bFound2 = False

                For k = 1 To iWeekCount 'every week
                    vWeekResult = 0 : n = 0 : m = 0 : v = 0 : vDailyAvgOfWeek = 0
                    vWeekResult2 = 0 : n2 = 0 : m2 = 0 : v2 = 0 : vDailyAvgOfWeek2 = 0
                    dtFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k)
                    If dtFilteredRows.Length = 7 Then
                        For Each row In dtFilteredRows 'every full week averaged
                            If arrListWeekDays.Contains(row("WeekDay")) Then
                                If Not row.IsNull("WeekForecast") Then
                                    v += row("WeekForecast") : n += 1
                                End If
                                If Not row.IsNull("SpecialQty") Then
                                    v2 += row("SpecialQty") : n2 += 1
                                End If
                            End If
                        Next
                        If n > 0 Then
                            iCnt += 1
                            vWeekResult = Math.Ceiling((v / n)) : vDailyAvgOfWeek = vWeekResult / arrListWeekDays.Count
                            'Get averaged within the month (maybe some partial week for the month), recompute
                            If k = iWeekCount Then 'last week
                                dtMonthFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k & " and [Date]<=#" & mnEndDate & "#")
                            Else
                                dtMonthFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k & " and [Date]>=#" & mnBeginDate & "#")
                            End If
                            v = 0
                            For Each row In dtMonthFilteredRows
                                ' For i As Integer = 0 To arrListWeekDays.Count - 1
                                If arrListWeekDays.Contains(row("WeekDay")) Then
                                    If Not row.IsNull("WeekForecast") Then
                                        v += row("WeekForecast") : m += 1
                                    End If
                                End If
                                'Next
                            Next
                            If m = 0 Then 'nothing for this partial week 
                                iCnt = iCnt - 1
                            ElseIf m <> n Then 'recompute
                                vWeekResult = Math.Ceiling(vDailyAvgOfWeek * m) '(v / m)
                            End If
                        End If
                        iMonthTotal += vWeekResult

                        If n2 > 0 Then
                            iCnt2 += 1
                            vWeekResult2 = Math.Ceiling((v2 / n2)) : vDailyAvgOfWeek2 = vWeekResult2 / arrListWeekDays.Count
                            'Get averaged within the month (maybe some partial week for the month), recompute
                            If k = iWeekCount Then 'last week
                                dtMonthFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k & " and [Date]<=#" & mnEndDate & "#")
                            Else
                                dtMonthFilteredRows = dtMonthWeeksDaysForecasted.Select("[WeekIdx]=" & k & " and [Date]>=#" & mnBeginDate & "#")
                            End If
                            v2 = 0
                            For Each row In dtMonthFilteredRows
                                If arrListWeekDays.Contains(row("WeekDay")) Then
                                    If Not row.IsNull("SpecialQty") Then
                                        v2 += row("SpecialQty") : m2 += 1
                                    End If
                                End If

                            Next
                            If m2 = 0 Then 'nothing for this partial week 
                                iCnt2 = iCnt2 - 1
                            ElseIf m2 <> n2 Then 'recompute
                                vWeekResult2 = Math.Ceiling(vDailyAvgOfWeek2 * m2) '(v2 / m2)
                            End If
                        End If
                        iMonthTotal2 += vWeekResult2
                    Else
                        MessageBox.Show("Invalid week length: it does not equal to 7 in getCurrentMonthForecastValue", "getCurrentMonthForecastValue", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                Next
                If iCnt > 0 Then
                    iVal = iMonthTotal : bFound = True
                End If
                If iCnt2 > 0 Then
                    iVal2 = iMonthTotal2 : bFound2 = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "getCurrentMonthForecastValue", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '***************************************************************************************************************
        Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
            Dim dt As DataTable
            Dim myDate As Date

            If IsDate(Me.txtTestDate.Text) Then

                myDate = CDate(Me.txtTestDate.Text)
                dt = Me._objAMS.CalMonthlyForecated(myDate)

                Me.dbgView.DataSource = dt
                Me.dbgView.Visible = True
                btnCopyAll_FC.Visible = True
            End If

        End Sub

        '***************************************************************************************************************
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

        '***************************************************************************************************************
        Private Sub rbtnRegQtyUpload_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

            If rbtnRegQtyUpload.Checked Then
                rbtnRegQtyUpload.ForeColor = Color.Blue
                dtpWeekStartDate.Visible = True : lblWeekStartDate.Visible = True
            Else
                rbtnRegQtyUpload.ForeColor = Color.Black
            End If

        End Sub

        '***************************************************************************************************************
        Private Sub rbtnSpQtyUpload_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If rbtnSpQtyUpload.Checked Then
                rbtnSpQtyUpload.ForeColor = Color.Blue
                dtpWeekStartDate.Visible = False : lblWeekStartDate.Visible = False
            Else
                rbtnSpQtyUpload.ForeColor = Color.Black
            End If
        End Sub

        '***************************************************************************************************************
        Private Sub btnRefresh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh2.Click
            RefreshSpecialQtyData()
        End Sub

        '***************************************************************************************************************
        Private Sub RefreshSpecialQtyData()
            Dim dt As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0

            Try

                If Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.SelectAll() : Me.cboCustomer.Focus() : Exit Sub
                Else
                    dt = Me._objAMS.AMSFC_GetAMSSpecialRequested(Me.cboCustomer.SelectedValue, Me._iLocID, Me.chkHistory.Checked)
                    Me._bReadyToUpdateSPQtyGrid = False

                    With Me.dbgExistedData2
                        .DataSource = dt.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                            .Splits(0).DisplayColumns("SpecialRequestedQty_Old").Visible = False
                            .Splits(0).DisplayColumns("SpecialRequestedQty").Locked = False
                            If i > 8 Then .Splits(0).DisplayColumns(i).Width = 30
                            i += 1
                        Next dbgc

                        If dt.Rows.Count > 0 Then Me._bReadyToUpdateSPQtyGrid = True
                    End With
                End If
                Me.dbgExistedData2.Visible = True
            Catch ex As Exception
                MessageBox.Show(ex.Message, " RefreshSpecialQtyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub dbgExistedData2_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles dbgExistedData2.FetchRowStyle
            Dim iQty As Integer = 0
            Dim iQtyOld As Integer = 0
            Dim iAFSPQTYID As Integer = 0
            Dim iShippedQty As Integer = 0
            Dim strSpecialQtyCompleted As String = ""
            Dim i As Integer = 0
            Dim strDateTime As String
            Dim strComment As String = ""
            Dim iUserID As Integer = Core.ApplicationUser.IDuser

            Try
                If Me._bReadyToUpdateSPQtyGrid Then
                    ' iDeviceID = CInt(Me.tdgData03.Columns("Device_ID").Text)
                    iQty = CInt(Me.dbgExistedData2.Columns("SpecialRequestedQty").CellText(e.Row))
                    iQtyOld = CInt(Me.dbgExistedData2.Columns("SpecialRequestedQty_Old").CellText(e.Row))
                    iAFSPQTYID = CInt(Me.dbgExistedData2.Columns("AFSPQTY_ID").CellText(e.Row))
                    iShippedQty = CInt(Me.dbgExistedData2.Columns("SpecialShippedQty").CellText(e.Row))
                    strSpecialQtyCompleted = Me.dbgExistedData2.Columns("SpecialQtyCompleted").CellText(e.Row)

                    If Not iQty > 1 Then
                        'MessageBox.Show("Value must be greater than 1.", "Change Qty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    If iQtyOld <> iQty Then
                        'If MessageBox.Show("Do you want to change this SpecialRequestedQty (from " & iQtyOld & " to " & iQty & ")?", "Confirm Change", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        '  MessageBox.Show("iQtyOld= " & iQtyOld & "  iQty=" & iQty & " iAFSPQTYID= " & iAFSPQTYID & "   iShippedQty=" & iShippedQty)
                        If strSpecialQtyCompleted.ToUpper = "Yes".ToUpper Then
                            MessageBox.Show("Can't change it. The qty has been closed.", "Change Qty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            RefreshSpecialQtyData()
                        Else
                            If iQty > iShippedQty Then
                                strComment = InputBox("Enter comment.", "Comment Entry")
                                If strComment.Trim.Length = 0 Then
                                    MessageBox.Show("Please enter comment.", "Change Qty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    RefreshSpecialQtyData()
                                ElseIf strComment.Trim.Length > 200 Then
                                    MessageBox.Show("Maxiumn length of comment text is 200. Please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    RefreshSpecialQtyData()
                                Else
                                    strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
                                    i = Me._objAMS.UpdateAMSForcast_SpecialRequestQty(Me.cboCustomer.SelectedValue, Me._iLocID, iQty, iAFSPQTYID, strComment.Trim, strDateTime, iUserID)
                                    MessageBox.Show("Changed.", "Change Qty", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    RefreshSpecialQtyData()
                                End If
                            Else
                                MessageBox.Show("Can't change it. SpecialRequestedQty must be greater than SpecialShippedQty.", "Change Qty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                RefreshSpecialQtyData()
                            End If
                        End If
                        'End If
                    End If
                    'e.CellStyle.BackColor = Color.Red
                    ' MessageBox.Show("iQtyOld= " & iQtyOld & "  iQty=" & iQty & " iAFSPQTYID= " & iAFSPQTYID & "   iShippedQty=" & iShippedQty)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, " Change Qty", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***************************************************************************************************************

        Private Sub dbgExistedData2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgExistedData2.TextChanged
            Dim iQty As Integer = 0
            Dim iQtyOld As Integer = 0
            Dim iAFSPQTYID As Integer = 0
            Dim iShippedQty As Integer = 0

            'If Me._bReadyToUpdateSPQtyGrid Then

            '    ' iDeviceID = CInt(Me.tdgData03.Columns("Device_ID").Text)
            '    iQty = CInt(Me.dbgExistedData2.Columns("SpecialRequestedQty").CellText(e.Row))
            '    iAFSPQTYID = CInt(Me.dbgExistedData2.Columns("AFSPQTY_ID").CellText(e.Row))
            '    iShippedQty = CInt(Me.dbgExistedData2.Columns("SpecialShippedQty").CellText(e.Row))

            '    MessageBox.Show("Test")

            '    '  MessageBox.Show("  iQty " & iQty & " iAFSPQTYID= " & iAFSPQTYID & "   iShippedQty=" & iShippedQty)
            'End If
        End Sub

        '***************************************************************************************************************
        Private Sub chkHistory_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkHistory.CheckedChanged
            Try
                If TypeOf sender Is CheckBox Then
                    If CType(sender, CheckBox).Checked = True Then
                        CType(sender, CheckBox).Font = New Font(CType(sender, CheckBox).Font, FontStyle.Bold)
                    Else
                        CType(sender, CheckBox).Font = New Font(CType(sender, CheckBox).Font, FontStyle.Regular)
                    End If
                End If
            Catch ex As Exception
            End Try
        End Sub

        '***************************************************************************************************************
        Private Sub btnCloseSpecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseSpecial.Click
            Dim iPrimaryKey As Integer = 0
            Dim iRow As Integer = 0
            Dim objMessMisc As New PSS.Data.Buisness.MessMisc()
            Dim strDateTime As String
            Dim iUserID As Integer = Core.ApplicationUser.IDuser
            Dim i As Integer = 0
            Dim strComment As String = ""

            Try
                strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")

                'Close one each time
                If Me.dbgExistedData2.SelectedRows.Count = 1 Then
                    For Each iRow In Me.dbgExistedData2.SelectedRows
                        If Me.dbgExistedData2.Columns("SpecialQtyCompleted").CellText(iRow).ToString.ToUpper = "Yes".ToUpper Then
                            MessageBox.Show("Already closed. Can't change.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            strComment = InputBox("Enter comment.", "Comment Entry")
                            If strComment.Trim.Length = 0 Then
                                MessageBox.Show("Please entry comment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf strComment.Trim.Length > 200 Then
                                MessageBox.Show("Maxiumn length of comment text is 200. Please try again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else
                                iPrimaryKey = CInt(Me.dbgExistedData2.Columns("AFSPQTY_ID").CellText(iRow))
                                i = objMessMisc.AMSFC_EarlyCloseAMSSpecialRequested(iPrimaryKey, strComment.Trim, iUserID, strDateTime)
                                RefreshSpecialQtyData()
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("Please select a row to close.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, " btnCloseSpecial_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objMessMisc = Nothing
            End Try
        End Sub

        '***************************************************************************************************************

        Private Sub rbtnRegQtyUpload_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnRegQtyUpload.CheckedChanged
            If rbtnRegQtyUpload.Checked Then
                rbtnRegQtyUpload.ForeColor = Color.Blue
                dtpWeekStartDate.Visible = True : lblWeekStartDate.Visible = True
            Else
                rbtnRegQtyUpload.ForeColor = Color.Black
            End If
        End Sub

        Private Sub rbtnSpQtyUpload_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSpQtyUpload.CheckedChanged
            If rbtnSpQtyUpload.Checked Then
                rbtnSpQtyUpload.ForeColor = Color.Blue
                dtpWeekStartDate.Visible = False : lblWeekStartDate.Visible = False
            Else
                rbtnSpQtyUpload.ForeColor = Color.Black
            End If
        End Sub

        Private Sub rbtnNorth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnNorth.CheckedChanged
            If rbtnNorth.Checked Then
                rbtnNorth.ForeColor = Color.Blue
                Me._iLocID = Me._iLocN
            Else
                rbtnNorth.ForeColor = Color.Black
            End If
        End Sub

        Private Sub rbtnSouth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSouth.CheckedChanged
            If rbtnSouth.Checked Then
                rbtnSouth.ForeColor = Color.Blue
                Me._iLocID = Me._iLocS
            Else
                rbtnSouth.ForeColor = Color.Black
            End If
        End Sub

        Private Sub cboCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.TextChanged
            Dim objNI As PSS.Data.Buisness.NIDataManagement

            Try
                If cboCustomer.SelectedValue = 2599 Then
                    Me.gbLocation.Visible = True
                    Me.rbtnNorth.Visible = True
                    Me.rbtnSouth.Visible = True
                Else
                    Me.gbLocation.Visible = False
                    Me.rbtnNorth.Visible = False
                    Me.rbtnSouth.Visible = False
                    Me.rbtnNorth.Checked = False
                    Me.rbtnNorth.ForeColor = Color.Black
                    Me.rbtnSouth.Checked = False
                    Me.rbtnSouth.ForeColor = Color.Black

                    objNI = New PSS.Data.Buisness.NIDataManagement()
                    Me._iLocID = objNI.getLocationID(cboCustomer.SelectedValue)
                    objNI = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, " cboCustomer_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace