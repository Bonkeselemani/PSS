Option Explicit On 

Imports System.IO
Imports PSS.Data.Buisness

Namespace Gui.codes
    Public Class frmManageManufCodes
        Inherits System.Windows.Forms.Form

        Private _objMMCodes As WarrantyClaim.ManageManufCodes
        Private _dsProdManufModel As DataSet
        Private _booPopulateDataToCombo As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objMMCodes = New WarrantyClaim.ManageManufCodes()
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
        Friend WithEvents tpFailcodes As System.Windows.Forms.TabPage
        Friend WithEvents tpRepairCodes As System.Windows.Forms.TabPage
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents tpBillcodeFCodeMap As System.Windows.Forms.TabPage
        Friend WithEvents cboManufs As C1.Win.C1List.C1Combo
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents tpBillcodePartMap As System.Windows.Forms.TabPage
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboProds As C1.Win.C1List.C1Combo
        Friend WithEvents btnFCActivate As System.Windows.Forms.Button
        Friend WithEvents btnInFCInactivate As System.Windows.Forms.Button
        Friend WithEvents btnCopySelectedRecord As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnFCUploadFromExcel As System.Windows.Forms.Button
        Friend WithEvents btnRCUploadFromExcel As System.Windows.Forms.Button
        Friend WithEvents btnRCInactivate As System.Windows.Forms.Button
        Friend WithEvents btnRCActivate As System.Windows.Forms.Button
        Friend WithEvents dbgRepairCodes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnUploadBCFCMap As System.Windows.Forms.Button
        Friend WithEvents btnRefreshData As System.Windows.Forms.Button
        Friend WithEvents tcBillcodeFailcodeMap As System.Windows.Forms.TabControl
        Friend WithEvents dbgBCFCMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgBCPartMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgFailCodes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnInactivateBCFCMap As System.Windows.Forms.Button
        Friend WithEvents btnActivateBCFCMap As System.Windows.Forms.Button
        Friend WithEvents tpBillCodes As System.Windows.Forms.TabPage
        Friend WithEvents dbgBillCodes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tpRefDesignator As System.Windows.Forms.TabPage
        Friend WithEvents btnRefUploadFrExcel As System.Windows.Forms.Button
        Friend WithEvents dbgRefMap As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCopyRefDesgMap As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmManageManufCodes))
            Me.tcBillcodeFailcodeMap = New System.Windows.Forms.TabControl()
            Me.tpFailcodes = New System.Windows.Forms.TabPage()
            Me.dbgFailCodes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnFCUploadFromExcel = New System.Windows.Forms.Button()
            Me.btnInFCInactivate = New System.Windows.Forms.Button()
            Me.btnFCActivate = New System.Windows.Forms.Button()
            Me.tpRepairCodes = New System.Windows.Forms.TabPage()
            Me.btnRCUploadFromExcel = New System.Windows.Forms.Button()
            Me.btnRCInactivate = New System.Windows.Forms.Button()
            Me.btnRCActivate = New System.Windows.Forms.Button()
            Me.dbgRepairCodes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpBillcodeFCodeMap = New System.Windows.Forms.TabPage()
            Me.btnUploadBCFCMap = New System.Windows.Forms.Button()
            Me.btnInactivateBCFCMap = New System.Windows.Forms.Button()
            Me.btnActivateBCFCMap = New System.Windows.Forms.Button()
            Me.dbgBCFCMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpBillcodePartMap = New System.Windows.Forms.TabPage()
            Me.dbgBCPartMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpRefDesignator = New System.Windows.Forms.TabPage()
            Me.btnRefUploadFrExcel = New System.Windows.Forms.Button()
            Me.dbgRefMap = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpBillCodes = New System.Windows.Forms.TabPage()
            Me.dbgBillCodes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboManufs = New C1.Win.C1List.C1Combo()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboProds = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnCopySelectedRecord = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.btnRefreshData = New System.Windows.Forms.Button()
            Me.btnCopyRefDesgMap = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.tcBillcodeFailcodeMap.SuspendLayout()
            Me.tpFailcodes.SuspendLayout()
            CType(Me.dbgFailCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpRepairCodes.SuspendLayout()
            CType(Me.dbgRepairCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpBillcodeFCodeMap.SuspendLayout()
            CType(Me.dbgBCFCMap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpBillcodePartMap.SuspendLayout()
            CType(Me.dbgBCPartMap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpRefDesignator.SuspendLayout()
            CType(Me.dbgRefMap, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpBillCodes.SuspendLayout()
            CType(Me.dbgBillCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboManufs, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProds, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'tcBillcodeFailcodeMap
            '
            Me.tcBillcodeFailcodeMap.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tcBillcodeFailcodeMap.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpFailcodes, Me.tpRepairCodes, Me.tpBillcodeFCodeMap, Me.tpBillcodePartMap, Me.tpRefDesignator, Me.tpBillCodes})
            Me.tcBillcodeFailcodeMap.Location = New System.Drawing.Point(8, 64)
            Me.tcBillcodeFailcodeMap.Name = "tcBillcodeFailcodeMap"
            Me.tcBillcodeFailcodeMap.SelectedIndex = 0
            Me.tcBillcodeFailcodeMap.Size = New System.Drawing.Size(1040, 448)
            Me.tcBillcodeFailcodeMap.TabIndex = 6
            '
            'tpFailcodes
            '
            Me.tpFailcodes.BackColor = System.Drawing.Color.SteelBlue
            Me.tpFailcodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgFailCodes, Me.btnFCUploadFromExcel, Me.btnInFCInactivate, Me.btnFCActivate})
            Me.tpFailcodes.Location = New System.Drawing.Point(4, 22)
            Me.tpFailcodes.Name = "tpFailcodes"
            Me.tpFailcodes.Size = New System.Drawing.Size(800, 422)
            Me.tpFailcodes.TabIndex = 0
            Me.tpFailcodes.Text = "Fail Codes"
            '
            'dbgFailCodes
            '
            Me.dbgFailCodes.AllowUpdate = False
            Me.dbgFailCodes.AlternatingRows = True
            Me.dbgFailCodes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgFailCodes.Caption = "Fail Codes"
            Me.dbgFailCodes.CaptionHeight = 17
            Me.dbgFailCodes.FilterBar = True
            Me.dbgFailCodes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgFailCodes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgFailCodes.Location = New System.Drawing.Point(24, 8)
            Me.dbgFailCodes.Name = "dbgFailCodes"
            Me.dbgFailCodes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgFailCodes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgFailCodes.PreviewInfo.ZoomFactor = 75
            Me.dbgFailCodes.Size = New System.Drawing.Size(488, 336)
            Me.dbgFailCodes.TabIndex = 9
            Me.dbgFailCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Ce" & _
            "nter;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:None," & _
            ",0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidt" & _
            "h=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>315</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 484, 315</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>16</DefaultRecSelWidth><ClientArea>0, 0, 484, 332</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></" & _
            "Blob>"
            '
            'btnFCUploadFromExcel
            '
            Me.btnFCUploadFromExcel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnFCUploadFromExcel.BackColor = System.Drawing.Color.Green
            Me.btnFCUploadFromExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCUploadFromExcel.ForeColor = System.Drawing.Color.White
            Me.btnFCUploadFromExcel.Location = New System.Drawing.Point(528, 88)
            Me.btnFCUploadFromExcel.Name = "btnFCUploadFromExcel"
            Me.btnFCUploadFromExcel.Size = New System.Drawing.Size(208, 23)
            Me.btnFCUploadFromExcel.TabIndex = 3
            Me.btnFCUploadFromExcel.Text = "Upload Fail Code From Excel File"
            '
            'btnInFCInactivate
            '
            Me.btnInFCInactivate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnInFCInactivate.BackColor = System.Drawing.Color.Green
            Me.btnInFCInactivate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnInFCInactivate.ForeColor = System.Drawing.Color.White
            Me.btnInFCInactivate.Location = New System.Drawing.Point(528, 48)
            Me.btnInFCInactivate.Name = "btnInFCInactivate"
            Me.btnInFCInactivate.Size = New System.Drawing.Size(184, 23)
            Me.btnInFCInactivate.TabIndex = 2
            Me.btnInFCInactivate.Text = "Inactivate Selected Records"
            '
            'btnFCActivate
            '
            Me.btnFCActivate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnFCActivate.BackColor = System.Drawing.Color.Green
            Me.btnFCActivate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCActivate.ForeColor = System.Drawing.Color.White
            Me.btnFCActivate.Location = New System.Drawing.Point(528, 8)
            Me.btnFCActivate.Name = "btnFCActivate"
            Me.btnFCActivate.Size = New System.Drawing.Size(184, 23)
            Me.btnFCActivate.TabIndex = 1
            Me.btnFCActivate.Text = "Activate Selected Records"
            '
            'tpRepairCodes
            '
            Me.tpRepairCodes.BackColor = System.Drawing.Color.SteelBlue
            Me.tpRepairCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRCUploadFromExcel, Me.btnRCInactivate, Me.btnRCActivate, Me.dbgRepairCodes})
            Me.tpRepairCodes.Location = New System.Drawing.Point(4, 22)
            Me.tpRepairCodes.Name = "tpRepairCodes"
            Me.tpRepairCodes.Size = New System.Drawing.Size(800, 422)
            Me.tpRepairCodes.TabIndex = 1
            Me.tpRepairCodes.Text = "Repair Codes"
            '
            'btnRCUploadFromExcel
            '
            Me.btnRCUploadFromExcel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRCUploadFromExcel.BackColor = System.Drawing.Color.Green
            Me.btnRCUploadFromExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRCUploadFromExcel.ForeColor = System.Drawing.Color.White
            Me.btnRCUploadFromExcel.Location = New System.Drawing.Point(560, 96)
            Me.btnRCUploadFromExcel.Name = "btnRCUploadFromExcel"
            Me.btnRCUploadFromExcel.Size = New System.Drawing.Size(232, 23)
            Me.btnRCUploadFromExcel.TabIndex = 7
            Me.btnRCUploadFromExcel.Text = "Upload Repair Codes From Excel File"
            '
            'btnRCInactivate
            '
            Me.btnRCInactivate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRCInactivate.BackColor = System.Drawing.Color.Green
            Me.btnRCInactivate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRCInactivate.ForeColor = System.Drawing.Color.White
            Me.btnRCInactivate.Location = New System.Drawing.Point(560, 55)
            Me.btnRCInactivate.Name = "btnRCInactivate"
            Me.btnRCInactivate.Size = New System.Drawing.Size(184, 23)
            Me.btnRCInactivate.TabIndex = 6
            Me.btnRCInactivate.Text = "Inactivate Selected Records"
            '
            'btnRCActivate
            '
            Me.btnRCActivate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRCActivate.BackColor = System.Drawing.Color.Green
            Me.btnRCActivate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRCActivate.ForeColor = System.Drawing.Color.White
            Me.btnRCActivate.Location = New System.Drawing.Point(560, 15)
            Me.btnRCActivate.Name = "btnRCActivate"
            Me.btnRCActivate.Size = New System.Drawing.Size(184, 23)
            Me.btnRCActivate.TabIndex = 5
            Me.btnRCActivate.Text = "Activate Selected Records"
            '
            'dbgRepairCodes
            '
            Me.dbgRepairCodes.AllowUpdate = False
            Me.dbgRepairCodes.AlternatingRows = True
            Me.dbgRepairCodes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgRepairCodes.Caption = "Repair Codes"
            Me.dbgRepairCodes.CaptionHeight = 17
            Me.dbgRepairCodes.FilterBar = True
            Me.dbgRepairCodes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRepairCodes.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgRepairCodes.Location = New System.Drawing.Point(8, 15)
            Me.dbgRepairCodes.Name = "dbgRepairCodes"
            Me.dbgRepairCodes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRepairCodes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRepairCodes.PreviewInfo.ZoomFactor = 75
            Me.dbgRepairCodes.Size = New System.Drawing.Size(512, 361)
            Me.dbgRepairCodes.TabIndex = 8
            Me.dbgRepairCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Con" & _
            "trol;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:" & _
            "None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidt" & _
            "h=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>340</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 508, 340</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>16</DefaultRecSelWidth><ClientArea>0, 0, 508, 357</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></" & _
            "Blob>"
            '
            'tpBillcodeFCodeMap
            '
            Me.tpBillcodeFCodeMap.BackColor = System.Drawing.Color.SteelBlue
            Me.tpBillcodeFCodeMap.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUploadBCFCMap, Me.btnInactivateBCFCMap, Me.btnActivateBCFCMap, Me.dbgBCFCMap})
            Me.tpBillcodeFCodeMap.Location = New System.Drawing.Point(4, 22)
            Me.tpBillcodeFCodeMap.Name = "tpBillcodeFCodeMap"
            Me.tpBillcodeFCodeMap.Size = New System.Drawing.Size(800, 422)
            Me.tpBillcodeFCodeMap.TabIndex = 2
            Me.tpBillcodeFCodeMap.Text = "Bill Code - Fail Code Mapping"
            '
            'btnUploadBCFCMap
            '
            Me.btnUploadBCFCMap.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnUploadBCFCMap.BackColor = System.Drawing.Color.Green
            Me.btnUploadBCFCMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUploadBCFCMap.ForeColor = System.Drawing.Color.White
            Me.btnUploadBCFCMap.Location = New System.Drawing.Point(672, 128)
            Me.btnUploadBCFCMap.Name = "btnUploadBCFCMap"
            Me.btnUploadBCFCMap.Size = New System.Drawing.Size(120, 65)
            Me.btnUploadBCFCMap.TabIndex = 7
            Me.btnUploadBCFCMap.Text = "Upload Bill Code Codes - Fail Code From Excel File"
            '
            'btnInactivateBCFCMap
            '
            Me.btnInactivateBCFCMap.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnInactivateBCFCMap.BackColor = System.Drawing.Color.Green
            Me.btnInactivateBCFCMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnInactivateBCFCMap.ForeColor = System.Drawing.Color.White
            Me.btnInactivateBCFCMap.Location = New System.Drawing.Point(672, 72)
            Me.btnInactivateBCFCMap.Name = "btnInactivateBCFCMap"
            Me.btnInactivateBCFCMap.Size = New System.Drawing.Size(120, 41)
            Me.btnInactivateBCFCMap.TabIndex = 6
            Me.btnInactivateBCFCMap.Text = "Inactivate Selected Records"
            '
            'btnActivateBCFCMap
            '
            Me.btnActivateBCFCMap.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnActivateBCFCMap.BackColor = System.Drawing.Color.Green
            Me.btnActivateBCFCMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnActivateBCFCMap.ForeColor = System.Drawing.Color.White
            Me.btnActivateBCFCMap.Location = New System.Drawing.Point(672, 15)
            Me.btnActivateBCFCMap.Name = "btnActivateBCFCMap"
            Me.btnActivateBCFCMap.Size = New System.Drawing.Size(120, 41)
            Me.btnActivateBCFCMap.TabIndex = 5
            Me.btnActivateBCFCMap.Text = "Activate Selected Records"
            '
            'dbgBCFCMap
            '
            Me.dbgBCFCMap.AllowUpdate = False
            Me.dbgBCFCMap.AlternatingRows = True
            Me.dbgBCFCMap.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgBCFCMap.Caption = "Bill Codes vs Fail Codes Map"
            Me.dbgBCFCMap.CaptionHeight = 17
            Me.dbgBCFCMap.FilterBar = True
            Me.dbgBCFCMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBCFCMap.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgBCFCMap.Location = New System.Drawing.Point(16, 15)
            Me.dbgBCFCMap.Name = "dbgBCFCMap"
            Me.dbgBCFCMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBCFCMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBCFCMap.PreviewInfo.ZoomFactor = 75
            Me.dbgBCFCMap.Size = New System.Drawing.Size(640, 353)
            Me.dbgBCFCMap.TabIndex = 8
            Me.dbgBCFCMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Con" & _
            "trol;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:" & _
            "None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidt" & _
            "h=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>332</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 636, 332</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>16</DefaultRecSelWidth><ClientArea>0, 0, 636, 349</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></" & _
            "Blob>"
            '
            'tpBillcodePartMap
            '
            Me.tpBillcodePartMap.BackColor = System.Drawing.Color.SteelBlue
            Me.tpBillcodePartMap.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgBCPartMap})
            Me.tpBillcodePartMap.Location = New System.Drawing.Point(4, 22)
            Me.tpBillcodePartMap.Name = "tpBillcodePartMap"
            Me.tpBillcodePartMap.Size = New System.Drawing.Size(800, 422)
            Me.tpBillcodePartMap.TabIndex = 3
            Me.tpBillcodePartMap.Text = "Bill Code-Part Mapping"
            '
            'dbgBCPartMap
            '
            Me.dbgBCPartMap.AllowUpdate = False
            Me.dbgBCPartMap.AlternatingRows = True
            Me.dbgBCPartMap.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgBCPartMap.Caption = "Bill Codes vs Parts Map"
            Me.dbgBCPartMap.CaptionHeight = 17
            Me.dbgBCPartMap.FilterBar = True
            Me.dbgBCPartMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBCPartMap.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgBCPartMap.Location = New System.Drawing.Point(16, 15)
            Me.dbgBCPartMap.Name = "dbgBCPartMap"
            Me.dbgBCPartMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBCPartMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBCPartMap.PreviewInfo.ZoomFactor = 75
            Me.dbgBCPartMap.Size = New System.Drawing.Size(768, 369)
            Me.dbgBCPartMap.TabIndex = 12
            Me.dbgBCPartMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Ce" & _
            "nter;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:None," & _
            ",0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidt" & _
            "h=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>348</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 764, 348</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>16</DefaultRecSelWidth><ClientArea>0, 0, 764, 365</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></" & _
            "Blob>"
            '
            'tpRefDesignator
            '
            Me.tpRefDesignator.BackColor = System.Drawing.Color.SteelBlue
            Me.tpRefDesignator.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.btnRefUploadFrExcel, Me.dbgRefMap})
            Me.tpRefDesignator.Location = New System.Drawing.Point(4, 22)
            Me.tpRefDesignator.Name = "tpRefDesignator"
            Me.tpRefDesignator.Size = New System.Drawing.Size(1032, 422)
            Me.tpRefDesignator.TabIndex = 5
            Me.tpRefDesignator.Text = "Ref Designator"
            '
            'btnRefUploadFrExcel
            '
            Me.btnRefUploadFrExcel.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRefUploadFrExcel.BackColor = System.Drawing.Color.Green
            Me.btnRefUploadFrExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefUploadFrExcel.ForeColor = System.Drawing.Color.White
            Me.btnRefUploadFrExcel.Location = New System.Drawing.Point(800, 16)
            Me.btnRefUploadFrExcel.Name = "btnRefUploadFrExcel"
            Me.btnRefUploadFrExcel.Size = New System.Drawing.Size(216, 48)
            Me.btnRefUploadFrExcel.TabIndex = 11
            Me.btnRefUploadFrExcel.Text = "Upload Ref Designator Map From Excel File"
            '
            'dbgRefMap
            '
            Me.dbgRefMap.AllowUpdate = False
            Me.dbgRefMap.AlternatingRows = True
            Me.dbgRefMap.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgRefMap.Caption = "Ref Designator Map"
            Me.dbgRefMap.CaptionHeight = 17
            Me.dbgRefMap.FilterBar = True
            Me.dbgRefMap.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRefMap.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbgRefMap.Location = New System.Drawing.Point(12, 19)
            Me.dbgRefMap.Name = "dbgRefMap"
            Me.dbgRefMap.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRefMap.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRefMap.PreviewInfo.ZoomFactor = 75
            Me.dbgRefMap.Size = New System.Drawing.Size(764, 357)
            Me.dbgRefMap.TabIndex = 12
            Me.dbgRefMap.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Ce" & _
            "nter;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:None," & _
            ",0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidt" & _
            "h=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>336</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 760, 336</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>16</DefaultRecSelWidth><ClientArea>0, 0, 760, 353</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></" & _
            "Blob>"
            '
            'tpBillCodes
            '
            Me.tpBillCodes.BackColor = System.Drawing.Color.SteelBlue
            Me.tpBillCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgBillCodes})
            Me.tpBillCodes.Location = New System.Drawing.Point(4, 22)
            Me.tpBillCodes.Name = "tpBillCodes"
            Me.tpBillCodes.Size = New System.Drawing.Size(800, 422)
            Me.tpBillCodes.TabIndex = 4
            Me.tpBillCodes.Text = "Bill Codes"
            '
            'dbgBillCodes
            '
            Me.dbgBillCodes.AllowUpdate = False
            Me.dbgBillCodes.AlternatingRows = True
            Me.dbgBillCodes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgBillCodes.Caption = "Bill Codes"
            Me.dbgBillCodes.CaptionHeight = 17
            Me.dbgBillCodes.FilterBar = True
            Me.dbgBillCodes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgBillCodes.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.dbgBillCodes.Location = New System.Drawing.Point(16, 19)
            Me.dbgBillCodes.Name = "dbgBillCodes"
            Me.dbgBillCodes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgBillCodes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgBillCodes.PreviewInfo.ZoomFactor = 75
            Me.dbgBillCodes.Size = New System.Drawing.Size(768, 357)
            Me.dbgBillCodes.TabIndex = 13
            Me.dbgBillCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 9.75pt, style=Bold;AlignHorz:Near;ForeColor:White;" & _
            "BackColor:CadetBlue;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Styl" & _
            "e17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}" & _
            "Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelecto" & _
            "r{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptio" & _
            "nText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:Tru" & _
            "e;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Con" & _
            "trol;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;Back" & _
            "Color:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:" & _
            "None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Dat" & _
            "a></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""T" & _
            "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
            "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidt" & _
            "h=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>336</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 764, 336</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>16</DefaultRecSelWidth><ClientArea>0, 0, 764, 353</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></" & _
            "Blob>"
            '
            'cboManufs
            '
            Me.cboManufs.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboManufs.AutoCompletion = True
            Me.cboManufs.AutoDropDown = True
            Me.cboManufs.AutoSelect = True
            Me.cboManufs.Caption = ""
            Me.cboManufs.CaptionHeight = 17
            Me.cboManufs.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboManufs.ColumnCaptionHeight = 17
            Me.cboManufs.ColumnFooterHeight = 17
            Me.cboManufs.ColumnHeaders = False
            Me.cboManufs.ContentHeight = 15
            Me.cboManufs.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboManufs.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboManufs.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboManufs.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboManufs.EditorHeight = 15
            Me.cboManufs.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboManufs.ItemHeight = 15
            Me.cboManufs.Location = New System.Drawing.Point(104, 8)
            Me.cboManufs.MatchEntryTimeout = CType(2000, Long)
            Me.cboManufs.MaxDropDownItems = CType(10, Short)
            Me.cboManufs.MaxLength = 32767
            Me.cboManufs.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboManufs.Name = "cboManufs"
            Me.cboManufs.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboManufs.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboManufs.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboManufs.Size = New System.Drawing.Size(232, 21)
            Me.cboManufs.TabIndex = 1
            Me.cboManufs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Black
            Me.Label9.Location = New System.Drawing.Point(8, 10)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(96, 16)
            Me.Label9.TabIndex = 121
            Me.Label9.Text = "Manufacturer :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.AutoCompletion = True
            Me.cboModels.AutoDropDown = True
            Me.cboModels.AutoSelect = True
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ColumnHeaders = False
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(8, 40)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(208, 21)
            Me.cboModels.TabIndex = 3
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 123
            Me.Label1.Text = "Model :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboProds
            '
            Me.cboProds.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProds.AutoCompletion = True
            Me.cboProds.AutoDropDown = True
            Me.cboProds.AutoSelect = True
            Me.cboProds.Caption = ""
            Me.cboProds.CaptionHeight = 17
            Me.cboProds.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProds.ColumnCaptionHeight = 17
            Me.cboProds.ColumnFooterHeight = 17
            Me.cboProds.ColumnHeaders = False
            Me.cboProds.ContentHeight = 15
            Me.cboProds.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProds.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProds.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProds.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProds.EditorHeight = 15
            Me.cboProds.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.cboProds.ItemHeight = 15
            Me.cboProds.Location = New System.Drawing.Point(104, 32)
            Me.cboProds.MatchEntryTimeout = CType(2000, Long)
            Me.cboProds.MaxDropDownItems = CType(10, Short)
            Me.cboProds.MaxLength = 32767
            Me.cboProds.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProds.Name = "cboProds"
            Me.cboProds.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProds.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProds.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProds.Size = New System.Drawing.Size(232, 21)
            Me.cboProds.TabIndex = 2
            Me.cboProds.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(40, 32)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 16)
            Me.Label2.TabIndex = 125
            Me.Label2.Text = "Product :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCopySelectedRecord
            '
            Me.btnCopySelectedRecord.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopySelectedRecord.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRecord.ForeColor = System.Drawing.Color.White
            Me.btnCopySelectedRecord.Location = New System.Drawing.Point(640, 8)
            Me.btnCopySelectedRecord.Name = "btnCopySelectedRecord"
            Me.btnCopySelectedRecord.Size = New System.Drawing.Size(144, 20)
            Me.btnCopySelectedRecord.TabIndex = 5
            Me.btnCopySelectedRecord.Text = "Copy Selected Records"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.White
            Me.btnCopyAll.Location = New System.Drawing.Point(544, 8)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(80, 20)
            Me.btnCopyAll.TabIndex = 4
            Me.btnCopyAll.Text = "Copy All"
            '
            'btnRefreshData
            '
            Me.btnRefreshData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshData.ForeColor = System.Drawing.Color.White
            Me.btnRefreshData.Location = New System.Drawing.Point(376, 8)
            Me.btnRefreshData.Name = "btnRefreshData"
            Me.btnRefreshData.Size = New System.Drawing.Size(128, 20)
            Me.btnRefreshData.TabIndex = 126
            Me.btnRefreshData.Text = "Refresh Data"
            '
            'btnCopyRefDesgMap
            '
            Me.btnCopyRefDesgMap.BackColor = System.Drawing.Color.Green
            Me.btnCopyRefDesgMap.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyRefDesgMap.ForeColor = System.Drawing.Color.White
            Me.btnCopyRefDesgMap.Location = New System.Drawing.Point(8, 80)
            Me.btnCopyRefDesgMap.Name = "btnCopyRefDesgMap"
            Me.btnCopyRefDesgMap.Size = New System.Drawing.Size(88, 24)
            Me.btnCopyRefDesgMap.TabIndex = 124
            Me.btnCopyRefDesgMap.Text = "Copy"
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.cboModels, Me.btnCopyRefDesgMap})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 8.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(800, 96)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(224, 112)
            Me.GroupBox1.TabIndex = 125
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Copy Map to Following Model"
            '
            'frmManageManufCodes
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(1056, 557)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefreshData, Me.btnCopyAll, Me.cboManufs, Me.Label9, Me.tcBillcodeFailcodeMap, Me.cboProds, Me.Label2, Me.btnCopySelectedRecord})
            Me.Name = "frmManageManufCodes"
            Me.Text = "frmManageManufCodes"
            Me.tcBillcodeFailcodeMap.ResumeLayout(False)
            Me.tpFailcodes.ResumeLayout(False)
            CType(Me.dbgFailCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpRepairCodes.ResumeLayout(False)
            CType(Me.dbgRepairCodes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpBillcodeFCodeMap.ResumeLayout(False)
            CType(Me.dbgBCFCMap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpBillcodePartMap.ResumeLayout(False)
            CType(Me.dbgBCPartMap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpRefDesignator.ResumeLayout(False)
            CType(Me.dbgRefMap, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpBillCodes.ResumeLayout(False)
            CType(Me.dbgBillCodes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboManufs, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProds, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Form"
        '******************************************************************************************
        Private Sub frmManageManufCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                _dsProdManufModel = New DataSet()

                _dsProdManufModel = Me._objMMCodes.GetProdManufModelDataSet

                _booPopulateDataToCombo = True
                'Populate Manufacture
                If Not IsNothing(Me._dsProdManufModel.Tables("Manuf")) Then
                    Misc.PopulateC1DropDownList(Me.cboManufs, Me._dsProdManufModel.Tables("Manuf"), "Manuf_Desc", "Manuf_ID")
                    Me.cboManufs.SelectAll()
                    Me.cboManufs.Focus()
                End If
                _booPopulateDataToCombo = False
                If Me.cboManufs.SelectedValue > 0 Then PopulateProducts()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmManageManufCodes_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                _booPopulateDataToCombo = False
            End Try
        End Sub

        '******************************************************************************************
        Private Sub cboManufs_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManufs.SelectedValueChanged
            Try
                Me.cboProds.DataSource = Nothing
                If _booPopulateDataToCombo = True Then Exit Sub

                'Populate Product
                If Not IsNothing(Me.cboManufs.SelectedValue) AndAlso Me.cboManufs.SelectedValue > 0 Then PopulateProducts()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboManufs_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub PopulateProducts()
            Dim dt As DataTable
            Dim R1, drArr(), drNewRow As DataRow
            Dim i, j As Integer

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                With Me.cboProds
                    .DataSource = Nothing

                    'Populate Product
                    If Me.cboManufs.SelectedValue > 0 Then

                        If Not IsNothing(Me._dsProdManufModel.Tables("Product")) Then
                            dt = New DataTable()
                            dt = Me._dsProdManufModel.Tables("Product").Clone

                            drArr = Me._dsProdManufModel.Tables("Model").Select("Manuf_ID = " & Me.cboManufs.SelectedValue)
                            For i = 0 To drArr.Length - 1
                                If Me._dsProdManufModel.Tables("Product").Select("Prod_ID = " & drArr(i)("Prod_ID")).Length > 0 Then R1 = Me._dsProdManufModel.Tables("Product").Select("Prod_ID = " & drArr(i)("Prod_ID"))(0)

                                If Not IsNothing(R1) AndAlso dt.Select("Prod_ID = " & R1("Prod_ID")).Length = 0 Then
                                    drNewRow = dt.NewRow
                                    For j = 0 To dt.Columns.Count - 1
                                        drNewRow(dt.Columns(j).Caption) = R1(dt.Columns(j).Caption)
                                    Next j
                                    dt.Rows.Add(drNewRow) : dt.AcceptChanges() : R1 = Nothing : drNewRow = Nothing
                                End If
                            Next i

                            Misc.PopulateC1DropDownList(Me.cboProds, dt, "Prod_Desc", "Prod_ID")
                        End If
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default

                Generic.DisposeDT(dt)
                R1 = Nothing : drArr = Nothing : drNewRow = Nothing
            End Try
        End Sub

        '******************************************************************************************
        Private Sub cboProds_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProds.SelectedValueChanged
            Try
                If _booPopulateDataToCombo = True Then Exit Sub

                'Populate Manufacture
                If Not IsNothing(Me.cboProds.SelectedValue) AndAlso Me.cboProds.SelectedValue > 0 Then btnRefreshData_Click(Nothing, Nothing)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProds_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshData.Click
            Try
                If Me.tpFailcodes.Visible = True Then
                    Me.PopulateFailCodes()
                ElseIf Me.tpRepairCodes.Visible = True Then
                    Me.PopulateRepairCodes()
                ElseIf Me.tpBillcodeFCodeMap.Visible = True Then
                    Me.PopulateBCFCMapRelationship()
                ElseIf Me.tpBillcodePartMap.Visible = True Then
                    Me.PopulateBCPartMapRelationship()
                ElseIf Me.tpBillCodes.Visible = True Then
                    Me.PopulateBillCodes()
                ElseIf Me.tpRefDesignator.Visible = True Then
                    Me.PopulateRefDesignatormap()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboManufs_cboProds_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub PopulateModels()
            Dim dt As DataTable
            Dim drNewRow, drArr() As DataRow
            Dim i, j As Integer

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                With Me.cboModels
                    .DataSource = Nothing

                    'Populate Product
                    If Me.cboManufs.SelectedValue > 0 Then

                        If Not IsNothing(Me._dsProdManufModel.Tables("Model")) Then
                            dt = New DataTable()
                            dt = Me._dsProdManufModel.Tables("Model").Clone

                            If Me.cboProds.SelectedValue > 0 Then
                                drArr = Me._dsProdManufModel.Tables("Model").Select("Manuf_ID = " & Me.cboManufs.SelectedValue & " AND Prod_ID = " & Me.cboProds.SelectedValue)
                            Else
                                drArr = Me._dsProdManufModel.Tables("Model").Select("Manuf_ID = " & Me.cboManufs.SelectedValue)
                            End If

                            For i = 0 To drArr.Length - 1
                                If dt.Select("Model_ID = " & drArr(i)("Model_ID")).Length = 0 Then
                                    drNewRow = dt.NewRow
                                    For j = 0 To dt.Columns.Count - 1
                                        drNewRow(dt.Columns(j).Caption) = drArr(i)(dt.Columns(j).Caption)
                                    Next j
                                    dt.Rows.Add(drNewRow) : dt.AcceptChanges() : drNewRow = Nothing
                                End If
                            Next i

                            dt.DefaultView.Sort = "Model_Desc"

                            dt.LoadDataRow(New Object() {"0", "--select--"}, False)
                            Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
                            Me.cboModels.SelectedValue = 0
                        End If
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
                drArr = Nothing
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnCopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click
            Try
                If Me.tpFailcodes.Visible = True Then
                    Me.CopyAllData(Me.dbgFailCodes)
                ElseIf Me.tpRepairCodes.Visible = True Then
                    Me.CopyAllData(Me.dbgRepairCodes)
                ElseIf Me.tpBillcodeFCodeMap.Visible = True Then
                    Me.CopyAllData(Me.dbgBCFCMap)
                ElseIf Me.tpBillcodePartMap.Visible = True Then
                    Me.CopyAllData(Me.dbgBCPartMap)
                ElseIf Me.tpBillCodes.Visible = True Then
                    Me.CopyAllData(Me.dbgBillCodes)
                ElseIf Me.tpRefDesignator.Visible = True Then
                    Me.CopyAllData(Me.dbgRefMap)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopyAll_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnCopySelectedRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopySelectedRecord.Click
            Try
                If Me.tpFailcodes.Visible = True Then
                    Me.CopySelectedRowsData(Me.dbgFailCodes)
                ElseIf Me.tpRepairCodes.Visible = True Then
                    Me.CopySelectedRowsData(Me.dbgRepairCodes)
                ElseIf Me.tpBillcodeFCodeMap.Visible = True Then
                    Me.CopySelectedRowsData(Me.dbgBCFCMap)
                ElseIf Me.tpBillcodePartMap.Visible = True Then
                    Me.CopySelectedRowsData(Me.dbgBCPartMap)
                ElseIf Me.tpBillCodes.Visible = True Then
                    Me.CopySelectedRowsData(Me.dbgBillCodes)
                ElseIf Me.tpRefDesignator.Visible = True Then
                    Me.CopySelectedRowsData(Me.dbgRefMap)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopySelectedRecord_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub CopyAllData(ByVal dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
            Dim strData, strHeader As String
            Dim iRow As Integer
            Dim booCompleteHeader As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                strData = "" : strHeader = ""

                If dbgData.RowCount > 0 And dbgData.Columns.Count > 0 Then
                    'loop through each row
                    For iRow = 0 To dbgData.RowCount - 1
                        'loop through each column
                        For Each col In dbgData.Columns
                            'header
                            If booCompleteHeader = False Then strHeader = strHeader & col.Caption & vbTab

                            'Data
                            strData = strData & col.CellText(iRow) & vbTab
                        Next col

                        'add new line to data
                        strData = strData & vbCrLf

                        'Stop collect header
                        booCompleteHeader = True
                    Next iRow

                    'combine header and data
                    strData = strHeader & vbCrLf & strData

                    'Copy Data to Clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(strData, False)
                Else
                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                    MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                dbgData = Nothing
                col = Nothing
            End Try
        End Sub

        '******************************************************************************************
        Private Sub CopySelectedRowsData(ByVal dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
            Dim strData, strHeader As String
            Dim iRow As Integer
            Dim booCompleteHeader As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                strData = "" : strHeader = ""

                If dbgData.SelectedRows.Count > 0 And dbgData.SelectedCols.Count > 0 Then
                    'loop through each selected row
                    For Each iRow In dbgData.SelectedRows

                        'loop through each selected column
                        For Each col In dbgData.Columns
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If
                            'data
                            strData = strData & col.CellText(iRow) & vbTab
                        Next col

                        'add new line to data
                        strData = strData & vbCrLf

                        'Stop collect header
                        booCompleteHeader = True
                    Next iRow

                    'combine header and data
                    strData = strHeader & vbCrLf & strData

                    'Copy Data to Clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(strData, False)
                Else
                    Cursor.Current = Cursors.Default
                    MessageBox.Show("Please select a range of cells to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                dbgData = Nothing
                col = Nothing
            End Try
        End Sub

        '******************************************************************************************

#End Region
     
#Region "Fail Codes Tabpage"

        '******************************************************************************************
        Private Sub PopulateFailCodes()
            Dim dt As DataTable
            Dim i As Integer

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                With Me.dbgFailCodes
                    .DataSource = Nothing

                    If Me.cboManufs.SelectedValue > 0 AndAlso Me.cboProds.SelectedValue > 0 Then
                        dt = Me._objMMCodes.GetFailCodeList(Me.cboManufs.SelectedValue, Me.cboProds.SelectedValue)

                        .DataSource = dt.DefaultView

                        '.Splits(0).DisplayColumns("Fail_ID").Visible = False

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                            'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                            If dt.Columns(i).Caption = "Inactive" Then
                                '.Splits(0).DisplayColumns(i).Frozen = True
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                                .Splits(0).DisplayColumns(i).Width = 50
                            End If
                        Next i

                        .Splits(0).DisplayColumns("Fault Code").Width = 80
                        .Splits(0).DisplayColumns("Fault Code Description").Width = 350
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub tpFailcodes_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpFailcodes.VisibleChanged
            Try
                If tpFailcodes.Visible = True Then
                    PopulateFailCodes()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpFailcodes_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnFCActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCActivate.Click
            Try
                Me.SetInactiveFlagForFC(0)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnFCActivate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnInFCInactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInFCInactivate.Click
            Try
                Me.SetInactiveFlagForFC(1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnInFCInactivate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub SetInactiveFlagForFC(ByVal iInactive As Integer)
            Dim strFailIDs As String = ""
            Dim iRow, i As Integer
            Dim booFailIDColSelected As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Try
                If Me.dbgFailCodes.SelectedRows.Count > 0 And dbgFailCodes.SelectedCols.Count > 0 Then

                    For Each col In Me.dbgFailCodes.Columns
                        If col.Caption = "Fail_ID" Then booFailIDColSelected = True
                    Next col

                    If booFailIDColSelected = False Then
                        MessageBox.Show("Please select all columns.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        'loop through each selected row
                        For Each iRow In dbgFailCodes.SelectedRows
                            If strFailIDs.Trim.Length > 0 Then strFailIDs &= ", "
                            strFailIDs &= dbgFailCodes.Columns("Fail_ID").CellText(iRow)
                        Next iRow

                        If strFailIDs.Trim.Length > 0 Then
                            i = Me._objMMCodes.SetFailCodeListInactiveFlag(strFailIDs, iInactive)

                            If i > 0 Then Me.PopulateFailCodes()
                            MessageBox.Show("Update completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Else
                    MessageBox.Show("Please select a range of cells.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                col = Nothing
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnFCUploadFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCUploadFromExcel.Click
            Dim objXL As Object = Nothing
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim fdOpenFile As OpenFileDialog
            Dim strFilePath, strFailCode, strFailDesc As String
            Dim i, iResult, iFailID, iInactive As Integer

            Try
                If Me.cboManufs.SelectedValue = 0 Then
                    MessageBox.Show("Please select manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.cboProds.SelectedValue = 0 Then
                    MessageBox.Show("Please select production.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                strFilePath = ""
                fdOpenFile = New OpenFileDialog()
                fdOpenFile.DefaultExt = ".xls"
                fdOpenFile.ShowDialog()
                strFilePath = fdOpenFile.FileName

                If strFilePath.Trim.Length = 0 Then
                    Exit Sub
                ElseIf strFilePath.Trim.EndsWith(".xls") = False Then
                    MessageBox.Show("Input file must be in excel format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf File.Exists(strFilePath) = False Then
                    MessageBox.Show("File does not exist """ & strFilePath & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If Me.dbgBCFCMap.Columns.Count = 0 Then Me.PopulateBCFCMapRelationship()

                    objExcel = New Excel.Application()
                    objBook = objExcel.Workbooks.Open(strFilePath)
                    objSheet = objExcel.Worksheets(1)
                    objExcel.Visible = True

                    'Validate Excel header
                    For i = 0 To Me.dbgFailCodes.Columns.Count - 1
                        If objSheet.range(Generic.CalExcelColLetter(i + 1) & 1).value.ToString().Trim.ToUpper <> Me.dbgFailCodes.Columns(i).Caption.Trim.ToUpper Then
                            Throw New Exception("Header of column " & Generic.CalExcelColLetter(i + 1) & " must be " & Me.dbgFailCodes.Columns(i).Caption & ".")
                        End If
                    Next i

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = 2

                    iFailID = 0 : iInactive = 0
                    strFailCode = "" : strFailDesc = ""

                    If Not IsNothing(objSheet.range("A" & i).value) AndAlso objSheet.range("A" & i).value.ToString().Trim.Length > 0 Then iFailID = CInt(objSheet.range("A" & i).value.ToString())
                    If Not IsNothing(objSheet.range("B" & i).value) AndAlso objSheet.range("B" & i).value.ToString().Trim.Length > 0 Then strFailCode = objSheet.range("B" & i).value.ToString().Trim.Replace("'", "")
                    If Not IsNothing(objSheet.range("C" & i).value) AndAlso objSheet.range("C" & i).value.ToString().Trim.Length > 0 Then strFailDesc = objSheet.range("C" & i).value.ToString().Trim.Replace("'", "")
                    If Not IsNothing(objSheet.range("D" & i).value) AndAlso objSheet.range("D" & i).value.ToString().Trim.Length > 0 Then iInactive = CInt(objSheet.range("D" & i).value.ToString().Trim.Replace("'", ""))

                    While (strFailCode.Length > 0 AndAlso strFailDesc.Trim.Length > 0)

                        'If strFailCode.Trim.Length > 0 Then iFailID = Me._objMMCodes.GetFailCodeID(Me.cboManufs.SelectedValue, strFailCode)

                        If strFailCode.Trim.Length = 0 Then
                            Throw New Exception("Excel line " & i & ": Fault code is missing.")
                        ElseIf strFailDesc.Trim.Length = 0 Then
                            Throw New Exception("Excel line " & i & ": Fault description is missing.")
                        End If

                        'Insert or Update
                        iResult = Me._objMMCodes.AddUpdateFailCodes(strFailCode, strFailDesc, iInactive, Me.cboManufs.SelectedValue, Me.cboProds.SelectedValue, iFailID)

                        iFailID = 0 : iInactive = 0 : i += 1
                        strFailCode = "" : strFailDesc = ""
                        If Not IsNothing(objSheet.range("A" & i).value) AndAlso objSheet.range("A" & i).value.ToString().Trim.Length > 0 Then iFailID = CInt(objSheet.range("A" & i).value.ToString())
                        If Not IsNothing(objSheet.range("B" & i).value) AndAlso objSheet.range("B" & i).value.ToString().Trim.Length > 0 Then strFailCode = objSheet.range("B" & i).value.ToString().Trim.Replace("'", "")
                        If Not IsNothing(objSheet.range("C" & i).value) AndAlso objSheet.range("C" & i).value.ToString().Trim.Length > 0 Then strFailDesc = objSheet.range("C" & i).value.ToString().Trim.Replace("'", "")
                        If Not IsNothing(objSheet.range("D" & i).value) AndAlso objSheet.range("D" & i).value.ToString().Trim.Length > 0 Then iInactive = CInt(objSheet.range("D" & i).value.ToString().Trim.Replace("'", ""))
                    End While

                    If iResult > 0 Then
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnFCUploadFromExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default

                If Not IsNothing(fdOpenFile) Then
                    fdOpenFile.Dispose()
                    fdOpenFile = Nothing
                End If

                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************************************

#End Region

#Region "Repair Codes Tabpage"

        '******************************************************************************************
        Private Sub PopulateRepairCodes()
            Dim dt As DataTable
            Dim i As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                With Me.dbgRepairCodes
                    .DataSource = Nothing

                    If Me.cboManufs.SelectedValue > 0 AndAlso Me.cboProds.SelectedValue > 0 Then
                        dt = Me._objMMCodes.GetRepairCodeList(Me.cboManufs.SelectedValue, Me.cboProds.SelectedValue)

                        .DataSource = dt.DefaultView

                        '.Splits(0).DisplayColumns("Repair_ID").Visible = False

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                            'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                            If dt.Columns(i).Caption = "Inactive" Then
                                '.Splits(0).DisplayColumns(i).Frozen = True
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                                .Splits(0).DisplayColumns(i).Width = 50
                            End If
                        Next i

                        .Splits(0).DisplayColumns("Repair Code").Width = 80
                        .Splits(0).DisplayColumns("Repair Code Description").Width = 350
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub tpRepairCodes_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpRepairCodes.VisibleChanged
            Try
                If Me.tpRepairCodes.Visible = True Then
                    Me.PopulateRepairCodes()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpRepairCodes_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnRCActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRCActivate.Click
            Try
                Me.SetInactiveFlagForRC(0)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRCActivate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnRCInactivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRCInactivate.Click
            Try
                Me.SetInactiveFlagForRC(1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRCInactivate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub SetInactiveFlagForRC(ByVal iInactive As Integer)
            Dim strRepIDs As String = ""
            Dim iRow, i As Integer
            Dim booRepIDColSelected As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Try
                If Me.dbgRepairCodes.SelectedRows.Count > 0 And dbgRepairCodes.SelectedCols.Count > 0 Then

                    For Each col In Me.dbgRepairCodes.Columns
                        If col.Caption = "Repair_ID" Then booRepIDColSelected = True
                    Next col

                    If booRepIDColSelected = False Then
                        MessageBox.Show("Please select all columns.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        'loop through each selected row
                        For Each iRow In dbgRepairCodes.SelectedRows
                            If strRepIDs.Trim.Length > 0 Then strRepIDs &= ", "
                            strRepIDs &= Me.dbgRepairCodes.Columns("Repair_ID").CellText(iRow)
                        Next iRow

                        If strRepIDs.Trim.Length > 0 Then
                            i = Me._objMMCodes.SetRepCodeListInactiveFlag(strRepIDs, iInactive)

                            If i > 0 Then Me.PopulateRepairCodes()
                            MessageBox.Show("Update completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Else
                    MessageBox.Show("Please select a range of cells.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                col = Nothing
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnRCUploadFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRCUploadFromExcel.Click
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim fdOpenFile As OpenFileDialog
            Dim strFilePath, strRepairCode, strRepairDesc As String
            Dim i, iResult, iRepairID, iInactive As Integer

            Try
                If Me.cboManufs.SelectedValue = 0 Then
                    MessageBox.Show("Please select manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.cboProds.SelectedValue = 0 Then
                    MessageBox.Show("Please select production.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                strFilePath = ""
                fdOpenFile = New OpenFileDialog()
                fdOpenFile.DefaultExt = ".xls"
                fdOpenFile.ShowDialog()
                strFilePath = fdOpenFile.FileName

                If strFilePath.Trim.Length = 0 Then
                    Exit Sub
                ElseIf strFilePath.Trim.EndsWith(".xls") = False Then
                    MessageBox.Show("Input file must be in excel format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf File.Exists(strFilePath) = False Then
                    MessageBox.Show("File does not exist """ & strFilePath & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If Me.dbgBCFCMap.Columns.Count = 0 Then Me.PopulateBCFCMapRelationship()

                    objExcel = New Excel.Application()
                    objBook = objExcel.Workbooks.Open(strFilePath)
                    objSheet = objExcel.Worksheets(1)
                    objExcel.Visible = True

                    'Validate Excel header
                    For i = 0 To Me.dbgRepairCodes.Columns.Count - 1
                        If objSheet.range(Generic.CalExcelColLetter(i + 1) & 1).value.ToString().Trim.ToUpper <> Me.dbgRepairCodes.Columns(i).Caption.Trim.ToUpper Then
                            Throw New Exception("Header of column " & Generic.CalExcelColLetter(i + 1) & " must be " & Me.dbgRepairCodes.Columns(i).Caption & ".")
                        End If
                    Next i

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = 2

                    iRepairID = 0 : iInactive = 0
                    strRepairCode = "" : strRepairDesc = ""

                    If Not IsNothing(objSheet.range("A" & i).value) AndAlso objSheet.range("A" & i).value.ToString().Trim.Length > 0 Then iRepairID = CInt(objSheet.range("A" & i).value.ToString())
                    If Not IsNothing(objSheet.range("B" & i).value) AndAlso objSheet.range("B" & i).value.ToString().Trim.Length > 0 Then strRepairCode = objSheet.range("B" & i).value.ToString().Trim.Replace("'", "")
                    If Not IsNothing(objSheet.range("C" & i).value) AndAlso objSheet.range("C" & i).value.ToString().Trim.Length > 0 Then strRepairDesc = objSheet.range("C" & i).value.ToString().Trim.Replace("'", "")
                    If Not IsNothing(objSheet.range("D" & i).value) AndAlso objSheet.range("D" & i).value.ToString().Trim.Length > 0 Then iInactive = CInt(objSheet.range("D" & i).value.ToString().Trim.Replace("'", ""))

                    While (strRepairCode.Length > 0 AndAlso strRepairDesc.Trim.Length > 0)

                        'If strFailCode.Trim.Length > 0 Then iFailID = Me._objMMCodes.GetFailCodeID(Me.cboManufs.SelectedValue, strFailCode)

                        If strRepairCode.Trim.Length = 0 Then
                            Throw New Exception("Excel line " & i & ": Fault code is missing.")
                        ElseIf strRepairDesc.Trim.Length = 0 Then
                            Throw New Exception("Excel line " & i & ": Fault description is missing.")
                        End If

                        'Insert or Update
                        iResult = Me._objMMCodes.AddUpdateRepairCodes(strRepairCode, strRepairDesc, iInactive, Me.cboManufs.SelectedValue, Me.cboProds.SelectedValue, iRepairID)

                        iRepairID = 0 : iInactive = 0 : i += 1
                        strRepairCode = "" : strRepairDesc = ""
                        If Not IsNothing(objSheet.range("A" & i).value) AndAlso objSheet.range("A" & i).value.ToString().Trim.Length > 0 Then iRepairID = CInt(objSheet.range("A" & i).value.ToString())
                        If Not IsNothing(objSheet.range("B" & i).value) AndAlso objSheet.range("B" & i).value.ToString().Trim.Length > 0 Then strRepairCode = objSheet.range("B" & i).value.ToString().Trim.Replace("'", "")
                        If Not IsNothing(objSheet.range("C" & i).value) AndAlso objSheet.range("C" & i).value.ToString().Trim.Length > 0 Then strRepairDesc = objSheet.range("C" & i).value.ToString().Trim.Replace("'", "")
                        If Not IsNothing(objSheet.range("D" & i).value) AndAlso objSheet.range("D" & i).value.ToString().Trim.Length > 0 Then iInactive = CInt(objSheet.range("D" & i).value.ToString().Trim.Replace("'", ""))
                    End While

                    If iResult > 0 Then
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRCUploadFromExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default

                If Not IsNothing(fdOpenFile) Then
                    fdOpenFile.Dispose()
                    fdOpenFile = Nothing
                End If

                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************************************

#End Region

#Region "Bill Code vs Fail Code Map Tabpage"

        '******************************************************************************************
        Private Sub PopulateBCFCMapRelationship()
            Dim dt As DataTable
            Dim i As Integer

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                With Me.dbgBCFCMap
                    .DataSource = Nothing

                    If Me.cboManufs.SelectedValue > 0 And Me.cboProds.SelectedValue > 0 Then
                        dt = Me._objMMCodes.GetBillCodeFailCodeMap(Me.cboManufs.SelectedValue, Me.cboProds.SelectedValue)

                        .DataSource = dt.DefaultView

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                            'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                            If dt.Columns(i).Caption = "Fault Code" OrElse dt.Columns(i).Caption = "Inactive" Then
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            Else
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            End If
                        Next i

                        '.Splits(0).DisplayColumns("Fault Code Description").Frozen = True

                        '.Splits(0).DisplayColumns("BFM_ID").Visible = False
                        '.Splits(0).DisplayColumns("BillCode_ID").Visible = False
                        .Splits(0).DisplayColumns("Bill Code Description").Width = 170
                        .Splits(0).DisplayColumns("Fault Code").Width = 60
                        .Splits(0).DisplayColumns("Fault Code Description").Width = 200
                        .Splits(0).DisplayColumns("Fault Code Pop-up Description").Width = 200
                        .Splits(0).DisplayColumns("Inactive").Width = 60
                        .Splits(0).DisplayColumns("BFM_ID").Width = 50
                        .Splits(0).DisplayColumns("BillCode_ID").Width = 70
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub tpBillcodeFCodeMap_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpBillcodeFCodeMap.VisibleChanged
            Try
                If Me.tpBillcodeFCodeMap.Visible = True Then
                    Me.PopulateBCFCMapRelationship()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpBillcodeFCodeMap_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnActivateBCFCMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivateBCFCMap.Click
            Try
                Me.SetInactiveFlagForBCFCMap(0)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnActivateBCFCMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnInactivateBCFCMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactivateBCFCMap.Click
            Try
                Me.SetInactiveFlagForBCFCMap(1)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnInactivateBCFCMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub SetInactiveFlagForBCFCMap(ByVal iInactive As Integer)
            Dim strBFMapIDs As String = ""
            Dim iRow, i As Integer
            Dim booMapIDColSelected As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Try
                If Me.dbgBCFCMap.SelectedRows.Count > 0 And Me.dbgBCFCMap.SelectedCols.Count > 0 Then

                    For Each col In Me.dbgBCFCMap.Columns
                        If col.Caption = "BFM_ID" Then booMapIDColSelected = True
                    Next col

                    If booMapIDColSelected = False Then
                        MessageBox.Show("Please select all columns.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        'loop through each selected row
                        For Each iRow In dbgBCFCMap.SelectedRows
                            If strBFMapIDs.Trim.Length > 0 Then strBFMapIDs &= ", "
                            strBFMapIDs &= Me.dbgBCFCMap.Columns("BFM_ID").CellText(iRow)
                        Next iRow

                        If strBFMapIDs.Trim.Length > 0 Then
                            i = Me._objMMCodes.SeBillCodeFailCodeMapInactiveFlag(strBFMapIDs, iInactive)

                            If i > 0 Then Me.PopulateBCFCMapRelationship()
                            MessageBox.Show("Update completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                Else
                    MessageBox.Show("Please select a range of cells.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                col = Nothing
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnUploadBCFCMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUploadBCFCMap.Click
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim fdOpenFile As OpenFileDialog
            Dim strFilePath, strFailCode, strDispDesc As String
            Dim i, iResult, iBillCodeID, iFailID, iBCFCMapID, iInactive As Integer

            Try
                If Me.cboManufs.SelectedValue = 0 Then
                    MessageBox.Show("Please select manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.cboProds.SelectedValue = 0 Then
                    MessageBox.Show("Please select production.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                strFilePath = ""
                fdOpenFile = New OpenFileDialog()
                fdOpenFile.DefaultExt = ".xls"
                fdOpenFile.ShowDialog()
                strFilePath = fdOpenFile.FileName

                If strFilePath.Trim.Length = 0 Then
                    Exit Sub
                ElseIf strFilePath.Trim.EndsWith(".xls") = False Then
                    MessageBox.Show("Input file must be in excel format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf File.Exists(strFilePath) = False Then
                    MessageBox.Show("File does not exist """ & strFilePath & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If Me.dbgBCFCMap.Columns.Count = 0 Then Me.PopulateBCFCMapRelationship()

                    objExcel = New Excel.Application()
                    objBook = objExcel.Workbooks.Open(strFilePath)
                    objSheet = objExcel.Worksheets(1)
                    objExcel.Visible = True

                    'Validate Excel header
                    For i = 0 To Me.dbgBCFCMap.Columns.Count - 1
                        If objSheet.range(Generic.CalExcelColLetter(i + 1) & 1).value.ToString().Trim.ToUpper <> Me.dbgBCFCMap.Columns(i).Caption.Trim.ToUpper Then
                            Throw New Exception("Header of column " & Generic.CalExcelColLetter(i + 1) & " must be " & Me.dbgBCFCMap.Columns(i).Caption & ".")
                        End If
                    Next i

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = 2

                    iBCFCMapID = 0 : iBillCodeID = 0 : iFailID = 0 : iInactive = 0
                    strFailCode = "" : strDispDesc = ""

                    If Not IsNothing(objSheet.range("A" & i).value) AndAlso objSheet.range("A" & i).value.ToString().Trim.Length > 0 Then iBCFCMapID = CInt(objSheet.range("A" & i).value.ToString())
                    If Not IsNothing(objSheet.range("B" & i).value) AndAlso objSheet.range("B" & i).value.ToString().Trim.Length > 0 Then iBillCodeID = CInt(objSheet.range("B" & i).value.ToString())
                    If Not IsNothing(objSheet.range("D" & i).value) AndAlso objSheet.range("D" & i).value.ToString().Trim.Length > 0 Then strFailCode = objSheet.range("D" & i).value.ToString().Trim.Replace("'", "")
                    If Not IsNothing(objSheet.range("F" & i).value) AndAlso objSheet.range("F" & i).value.ToString().Trim.Length > 0 Then strDispDesc = objSheet.range("F" & i).value.ToString().Trim.Replace("'", "")
                    If Not IsNothing(objSheet.range("G" & i).value) AndAlso objSheet.range("G" & i).value.ToString().Trim.Length > 0 Then iInactive = CInt(objSheet.range("G" & i).value.ToString())

                    While (iBillCodeID > 0 AndAlso strFailCode.Length > 0 AndAlso strDispDesc.Trim.Length > 0)

                        If strFailCode.Trim.Length > 0 Then iFailID = Me._objMMCodes.GetFailCodeID(Me.cboManufs.SelectedValue, strFailCode)

                        If iBillCodeID = 0 Then
                            Throw New Exception("Excel line " & i & ": Billcode ID " & iBillCodeID & " is missing.")
                        ElseIf Me._objMMCodes.IsBillcodeIDExisted(Me.cboProds.SelectedValue, iBillCodeID) = False Then
                            Throw New Exception("Excel line " & i & ": Billcode ID " & iBillCodeID & " is does not exist in the system.")
                        ElseIf iFailID = 0 Then
                            Throw New Exception("Excel line " & i & ": Fault code ID is missing for fault code " & strFailCode & ".")
                        ElseIf strDispDesc.Trim.Length = 0 Then
                            Throw New Exception("Excel line " & i & ": Internal fault description is missing.")
                        End If

                        'Insert or Update
                        iResult = Me._objMMCodes.AddUpdateBillCodeFailCodeMap(Me.cboManufs.SelectedValue, iBillCodeID, iFailID, strDispDesc, iInactive, iBCFCMapID)

                        iBCFCMapID = 0 : iBillCodeID = 0 : iFailID = 0 : iInactive = 0 : i += 1
                        strFailCode = "" : strDispDesc = ""
                        If Not IsNothing(objSheet.range("A" & i).value) AndAlso objSheet.range("A" & i).value.ToString().Trim.Length > 0 Then iBCFCMapID = CInt(objSheet.range("A" & i).value.ToString())
                        If Not IsNothing(objSheet.range("B" & i).value) AndAlso objSheet.range("B" & i).value.ToString().Trim.Length > 0 Then iBillCodeID = CInt(objSheet.range("B" & i).value.ToString())
                        If Not IsNothing(objSheet.range("D" & i).value) AndAlso objSheet.range("D" & i).value.ToString().Trim.Length > 0 Then strFailCode = objSheet.range("D" & i).value.ToString().Trim.Trim.Replace("'", "")
                        If Not IsNothing(objSheet.range("F" & i).value) AndAlso objSheet.range("F" & i).value.ToString().Trim.Length > 0 Then strDispDesc = objSheet.range("F" & i).value.ToString().Trim.Trim.Replace("'", "")
                        If Not IsNothing(objSheet.range("G" & i).value) AndAlso objSheet.range("G" & i).value.ToString().Trim.Length > 0 Then iInactive = CInt(objSheet.range("G" & i).value.ToString())

                    End While

                    If iResult > 0 Then
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUploadBCFCMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default

                If Not IsNothing(fdOpenFile) Then
                    fdOpenFile.Dispose()
                    fdOpenFile = Nothing
                End If

                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************************************

#End Region

#Region "Bill Code vs Part Map Tabpage"

        '******************************************************************************************
        Private Sub PopulateBCPartMapRelationship()
            Dim dt As DataTable
            Dim i As Integer

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                With Me.dbgBCPartMap
                    .DataSource = Nothing

                    If Me.cboManufs.SelectedValue > 0 AndAlso Me.cboProds.SelectedValue > 0 Then
                        dt = Me._objMMCodes.GetBillCodePartMap(Me.cboManufs.SelectedValue, Me.cboProds.SelectedValue)

                        .DataSource = dt.DefaultView

                        .Splits(0).DisplayColumns("Billcode_ID").Visible = False

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                            'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                            If dt.Columns(i).Caption = "Labor Level" Then
                                '.Splits(0).DisplayColumns(i).Frozen = True
                                .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                                .Splits(0).DisplayColumns(i).Width = 80
                            End If
                        Next i

                        .Splits(0).DisplayColumns("Bill Code Description").Width = 250
                        .Splits(0).DisplayColumns("Part #").Width = 120
                        .Splits(0).DisplayColumns("Bill Code Type").Width = 100
                        .Splits(0).DisplayColumns("Model").Width = 180
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub tpBillcodePartMap_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpBillcodePartMap.VisibleChanged
            Try
                If Me.tpBillcodePartMap.Visible = True Then
                    Me.PopulateBCPartMapRelationship()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpBillcodePartMap_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
#End Region

#Region "Bill Codes Tabpage"

        '******************************************************************************************
        Private Sub PopulateBillCodes()
            Dim dt As DataTable
            Dim i As Integer

            Try
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                With Me.dbgBillCodes
                    .DataSource = Nothing

                    If Me.cboProds.SelectedValue Then
                        dt = Me._objMMCodes.GetBillCodes(Me.cboProds.SelectedValue)

                        .DataSource = dt.DefaultView

                        '.Splits(0).DisplayColumns("Billcode_ID").Visible = False

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                            'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink
                        Next i

                        .Splits(0).DisplayColumns("Bill Code Description").Width = 250
                        .Splits(0).DisplayColumns("Bill Code Type").Width = 100
                    End If
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub tpBillCodes_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpBillCodes.VisibleChanged
            Try
                If Me.tpBillCodes.Visible = True Then
                    Me.PopulateBillCodes()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpBillCodes_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************

#End Region

#Region "Reference Designator Map Tabpage"

        '******************************************************************************************
        Private Sub PopulateRefDesignatormap()
            Dim dt As DataTable
            Dim i As Integer

            Try
                If Me.cboManufs.SelectedValue = 0 Then
                    MessageBox.Show("Please select manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboProds.SelectedValue = 0 Then
                    MessageBox.Show("Please select Product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    Me.PopulateModels()

                    With Me.dbgRefMap
                        .DataSource = Nothing

                        dt = Me._objMMCodes.GetRefDesignatorMap(Me.cboManufs.SelectedValue, Me.cboProds.SelectedValue)

                        .DataSource = dt.DefaultView

                        For i = 0 To dt.Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                            .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                            .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                            If dt.Columns(i).Caption = "Part #" Then
                                .Splits(0).DisplayColumns(i).Width = 100
                            ElseIf dt.Columns(i).Caption = "Part Description" OrElse dt.Columns(i).Caption = "Model Description" Then
                                .Splits(0).DisplayColumns(i).Width = 200
                            Else
                                .Splits(0).DisplayColumns(i).Width = 70
                            End If
                        Next i
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub tpRefDesignator_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpRefDesignator.VisibleChanged
            Try
                If Me.tpRefDesignator.Visible = True Then
                    Me.dbgRefMap.DataSource = Nothing

                    If Not IsNothing(Me.cboManufs.SelectedValue) AndAlso Me.cboManufs.SelectedValue > 0 AndAlso Not IsNothing(Me.cboProds.SelectedValue) AndAlso Me.cboProds.SelectedValue > 0 Then Me.PopulateRefDesignatormap()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tpRefDesignator_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnRefUploadFrExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefUploadFrExcel.Click
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim fdOpenFile As OpenFileDialog
            Dim strFilePath, strAlpha, strNumeric, strPartNumber As String
            Dim i, iResult, iPsPriceID, iRefMapID, iModelID As Integer

            Try
                If Me.cboManufs.SelectedValue = 0 Then
                    MessageBox.Show("Please select manufacturer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.cboProds.SelectedValue = 0 Then
                    MessageBox.Show("Please select production.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                strFilePath = ""
                fdOpenFile = New OpenFileDialog()
                fdOpenFile.DefaultExt = ".xls"
                fdOpenFile.ShowDialog()
                strFilePath = fdOpenFile.FileName

                If strFilePath.Trim.Length = 0 Then
                    Exit Sub
                ElseIf strFilePath.Trim.EndsWith(".xls") = False Then
                    MessageBox.Show("Input file must be in excel format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf File.Exists(strFilePath) = False Then
                    MessageBox.Show("File does not exist """ & strFilePath & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    If Me.dbgRefMap.Columns.Count = 0 Then Me.PopulateRefDesignatormap()

                    objExcel = New Excel.Application()
                    objBook = objExcel.Workbooks.Open(strFilePath)
                    objSheet = objExcel.Worksheets(1)
                    objExcel.Visible = True

                    'Validate Excel header
                    For i = 0 To Me.dbgRefMap.Columns.Count - 1
                        If objSheet.range(Generic.CalExcelColLetter(i + 1) & 1).value.ToString().Trim.ToUpper <> Me.dbgRefMap.Columns(i).Caption.Trim.ToUpper Then
                            Throw New Exception("Header of column " & Generic.CalExcelColLetter(i + 1) & " must be " & Me.dbgRefMap.Columns(i).Caption & ".")
                        End If
                    Next i

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = 2

                    iPsPriceID = 0 : iRefMapID = 0 : iModelID = 0 : strAlpha = "" : strNumeric = "" : strPartNumber = ""

                    If Not IsNothing(objSheet.range("A" & i).value) AndAlso objSheet.range("A" & i).value.ToString().Trim.Length > 0 Then iRefMapID = CInt(objSheet.range("A" & i).value.ToString())
                    If Not IsNothing(objSheet.range("B" & i).value) AndAlso objSheet.range("B" & i).value.ToString().Trim.Length > 0 Then iPsPriceID = CInt(objSheet.range("B" & i).value.ToString())
                    If Not IsNothing(objSheet.range("C" & i).value) AndAlso objSheet.range("C" & i).value.ToString().Trim.Length > 0 Then strPartNumber = objSheet.range("C" & i).value.ToString().Trim.Replace("'", "")
                    If Not IsNothing(objSheet.range("E" & i).value) AndAlso objSheet.range("E" & i).value.ToString().Trim.Length > 0 Then strAlpha = objSheet.range("E" & i).value.ToString().Trim.Replace("'", "")
                    If Not IsNothing(objSheet.range("F" & i).value) AndAlso objSheet.range("F" & i).value.ToString().Trim.Length > 0 Then strNumeric = objSheet.range("F" & i).value.ToString().PadLeft(4, "0")
                    If Not IsNothing(objSheet.range("G" & i).value) AndAlso objSheet.range("G" & i).value.ToString().Trim.Length > 0 Then iModelID = Convert.ToInt32(objSheet.range("G" & i).value.ToString())

                    While (strPartNumber.Trim.Length > 0 AndAlso strAlpha.Trim.Length > 0 AndAlso strNumeric.Trim.Length > 0)

                        iPsPriceID = Me._objMMCodes.GetPSPriceID(strPartNumber)

                        If iPsPriceID = 0 Then Throw New Exception("Excel line " & i & ": PSPrice ID is missing for this part # '" & strPartNumber & "'.")
                        If iModelID = 0 Then Throw New Exception("Excel line " & i & ": Model ID is missing for this part # '" & strPartNumber & "'.")

                        If Me._objMMCodes.IsPartMappedToModel(iModelID, iPsPriceID) = False Then
                            MessageBox.Show("Excel line # " & i & " will be skip." & Environment.NewLine & "REASON: No mapping relationship between part # '" & strPartNumber & "' and model '" & objSheet.range("H" & i).value.ToString() & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            'Insert or Update
                            iResult = Me._objMMCodes.AddUpdateRefDesignatorMap(iModelID, iRefMapID, iPsPriceID, strAlpha, strNumeric, PSS.Core.ApplicationUser.IDuser)
                        End If

                        iRefMapID = 0 : iPsPriceID = 0 : iModelID = 0 : i += 1
                        strPartNumber = "" : strAlpha = "" : strNumeric = ""

                        If Not IsNothing(objSheet.range("A" & i).value) AndAlso objSheet.range("A" & i).value.ToString().Trim.Length > 0 Then iRefMapID = CInt(objSheet.range("A" & i).value.ToString())
                        If Not IsNothing(objSheet.range("B" & i).value) AndAlso objSheet.range("B" & i).value.ToString().Trim.Length > 0 Then iPsPriceID = CInt(objSheet.range("B" & i).value.ToString())
                        If Not IsNothing(objSheet.range("C" & i).value) AndAlso objSheet.range("C" & i).value.ToString().Trim.Length > 0 Then strPartNumber = objSheet.range("C" & i).value.ToString().Trim.Replace("'", "")
                        If Not IsNothing(objSheet.range("E" & i).value) AndAlso objSheet.range("E" & i).value.ToString().Trim.Length > 0 Then strAlpha = objSheet.range("E" & i).value.ToString().Trim.Replace("'", "")
                        If Not IsNothing(objSheet.range("F" & i).value) AndAlso objSheet.range("F" & i).value.ToString().Trim.Length > 0 Then strNumeric = objSheet.range("F" & i).value.ToString().PadLeft(4, "0")
                        If Not IsNothing(objSheet.range("G" & i).value) AndAlso objSheet.range("G" & i).value.ToString().Trim.Length > 0 Then iModelID = Convert.ToInt32(objSheet.range("G" & i).value.ToString())
                    End While

                    If iResult > 0 Then
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefUploadFrExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default

                If Not IsNothing(fdOpenFile) Then
                    fdOpenFile.Dispose()
                    fdOpenFile = Nothing
                End If

                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    Generic.NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    Generic.NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    Generic.NAR(objExcel)
                End If

                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************************************
        Private Sub btnCopyRefDesgMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyRefDesgMap.Click
            Dim iRow As Integer = 0
            Dim strAlpha, strNumeric As String
            Dim iResult, iPsPriceID As Integer

            Try
                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dbgRefMap.SelectedRows.Count = 0 And dbgRefMap.SelectedCols.Count = 0 Then
                    MessageBox.Show("Please select a range of cells to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    'loop through each selected row
                    For Each iRow In dbgRefMap.SelectedRows
                        iPsPriceID = Convert.ToInt32(dbgRefMap.Columns("PSPrice_ID").CellValue(iRow))
                        strAlpha = dbgRefMap.Columns("Alpha").CellValue(iRow).ToString.Trim
                        strNumeric = dbgRefMap.Columns("Numeric").CellValue(iRow).ToString.Trim

                        If iPsPriceID = 0 Then
                            MessageBox.Show("PSPrice ID is missing for this part # '" & dbgRefMap.Columns("Part #").CellValue(iRow) & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf strAlpha.Trim.Length = 0 Then
                            MessageBox.Show("Alpha section is missing for this part # '" & dbgRefMap.Columns("Part #").CellValue(iRow) & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf strNumeric.Trim.Length = 0 Then
                            MessageBox.Show("Numeric section is missing for this part # '" & dbgRefMap.Columns("Part #").CellValue(iRow) & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf Me._objMMCodes.IsPartMappedToModel(Me.cboModels.SelectedValue, iPsPriceID) = False Then
                            MessageBox.Show("No mapping relationship between part # '" & dbgRefMap.Columns("Part #").CellValue(iRow) & "' and selected model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            'Insert or Update
                            iResult = Me._objMMCodes.AddUpdateRefDesignatorMap(Me.cboModels.SelectedValue, 0, iPsPriceID, strAlpha, strNumeric, PSS.Core.ApplicationUser.IDuser)
                        End If

                        iPsPriceID = 0 : strAlpha = "" : strNumeric = ""
                    Next iRow

                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopyRefDesgMap_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************************************

#End Region

    End Class
End Namespace