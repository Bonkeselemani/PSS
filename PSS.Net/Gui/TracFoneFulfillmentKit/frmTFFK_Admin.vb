Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text
Imports PSS.Data.Buisness.Security
Imports PSS.Core.Global
Imports C1.Win.C1TrueDBGrid
Imports System.Windows.Forms
Imports System.IO
Imports System.IO.File
Imports System.Data
Imports System.Data.OleDb

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_Admin
        Inherits System.Windows.Forms.Form
        Private _dtOpenOrders As DataTable
        Private _dtOrders As DataTable
        Private _dtShip As DataTable
        Private _dtMatrix As DataTable
        Private _dtModel As DataTable
        Private _dtAllModels As DataTable
        Private _dtCompOrders As DataTable
        Private _dtOrderDetails As DataTable
        Private _dtDesc As DataTable
        Private _dtClass As DataTable
        Private _dtTech As DataTable
        Private _dtSubClass As DataTable
        Private _dtInventory As DataTable
        Private _dtInventoryWip As DataTable
        Private _dtModelItems As DataTable
        Private _dtOneModel As DataTable
        Private _objAdmin As New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_AdminFunctions()
        Private _intIndex As Integer
        Private _ModelID As Integer
        Private _keyPress As String = ""
        Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strEmpID As String = PSS.Core.Global.ApplicationUser.NumberEmp
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
        Private _objWareHouseBox As New PSS.Data.buisness.TracFoneFulfillmentKit.wareHouseBox()
        Private _dtAllBoxes As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents btnExp As System.Windows.Forms.Button
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents txtModelDesc As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents tdgMatrix1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgItem1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmbModels As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents tdgCompOrders As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgOrderDetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents tdgShip1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgOrder1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmbShip1 As System.Windows.Forms.ComboBox
        Friend WithEvents TabPage0 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
        Friend WithEvents btnExport As System.Windows.Forms.Button
        Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
        Friend WithEvents txtModDesc As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
        Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtModLongDesc As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtUpcCodeID As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents txtWeight As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtHeight As System.Windows.Forms.TextBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents txtWidth As System.Windows.Forms.TextBox
        Friend WithEvents lblWidth As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents btnModel As System.Windows.Forms.Button
        Friend WithEvents txtLength As System.Windows.Forms.TextBox
        Friend WithEvents C1CmbTechDcodeId As C1.Win.C1List.C1Combo
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents C1Class As C1.Win.C1List.C1Combo
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents C1SubClass As C1.Win.C1List.C1Combo
        Friend WithEvents Label17 As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents rdbRawMaterials As System.Windows.Forms.RadioButton
        Friend WithEvents rdbPhones As System.Windows.Forms.RadioButton
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents C1CmbModelDesc As C1.Win.C1List.C1Combo
        Friend WithEvents C1tdgViewModels As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCpySelected As System.Windows.Forms.Button
        Friend WithEvents btnCopy As System.Windows.Forms.Button
        Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_Admin))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage0 = New System.Windows.Forms.TabPage()
            Me.btnExport = New System.Windows.Forms.Button()
            Me.tdgOrder1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabPage4 = New System.Windows.Forms.TabPage()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.cmbModels = New System.Windows.Forms.ComboBox()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.tdgMatrix1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.tdgOrderDetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgCompOrders = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.cmbShip1 = New System.Windows.Forms.ComboBox()
            Me.btnExp = New System.Windows.Forms.Button()
            Me.tdgShip1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabPage5 = New System.Windows.Forms.TabPage()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.C1CmbModelDesc = New C1.Win.C1List.C1Combo()
            Me.rdbRawMaterials = New System.Windows.Forms.RadioButton()
            Me.rdbPhones = New System.Windows.Forms.RadioButton()
            Me.C1tdgViewModels = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.C1Class = New C1.Win.C1List.C1Combo()
            Me.txtModDesc = New System.Windows.Forms.TextBox()
            Me.txtUpcCodeID = New System.Windows.Forms.TextBox()
            Me.C1CmbTechDcodeId = New C1.Win.C1List.C1Combo()
            Me.C1SubClass = New C1.Win.C1List.C1Combo()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtModLongDesc = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label17 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.txtHeight = New System.Windows.Forms.TextBox()
            Me.lblWidth = New System.Windows.Forms.Label()
            Me.txtLength = New System.Windows.Forms.TextBox()
            Me.txtWeight = New System.Windows.Forms.TextBox()
            Me.txtWidth = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnModel = New System.Windows.Forms.Button()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.RadioButton3 = New System.Windows.Forms.RadioButton()
            Me.RadioButton2 = New System.Windows.Forms.RadioButton()
            Me.RadioButton1 = New System.Windows.Forms.RadioButton()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.tdgItem1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.txtModelDesc = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.TabPage6 = New System.Windows.Forms.TabPage()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
            Me.btnCpySelected = New System.Windows.Forms.Button()
            Me.btnCopy = New System.Windows.Forms.Button()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabControl1.SuspendLayout()
            Me.TabPage0.SuspendLayout()
            CType(Me.tdgOrder1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage4.SuspendLayout()
            CType(Me.tdgMatrix1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage3.SuspendLayout()
            CType(Me.tdgOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgCompOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage1.SuspendLayout()
            CType(Me.tdgShip1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage5.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.C1CmbModelDesc, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.C1tdgViewModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.C1Class, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.C1CmbTechDcodeId, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.C1SubClass, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            CType(Me.tdgItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage6.SuspendLayout()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage0, Me.TabPage4, Me.TabPage3, Me.TabPage1, Me.TabPage5, Me.TabPage2, Me.TabPage6})
            Me.TabControl1.ItemSize = New System.Drawing.Size(49, 18)
            Me.TabControl1.Location = New System.Drawing.Point(24, 23)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1016, 560)
            Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
            Me.TabControl1.TabIndex = 95
            '
            'TabPage0
            '
            Me.TabPage0.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage0.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExport, Me.tdgOrder1})
            Me.TabPage0.Location = New System.Drawing.Point(4, 22)
            Me.TabPage0.Name = "TabPage0"
            Me.TabPage0.Size = New System.Drawing.Size(1008, 534)
            Me.TabPage0.TabIndex = 5
            Me.TabPage0.Text = "Open Orders"
            '
            'btnExport
            '
            Me.btnExport.BackColor = System.Drawing.Color.Green
            Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExport.ForeColor = System.Drawing.Color.White
            Me.btnExport.Location = New System.Drawing.Point(48, 16)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(120, 32)
            Me.btnExport.TabIndex = 163
            Me.btnExport.Text = "Export"
            '
            'tdgOrder1
            '
            Me.tdgOrder1.AllowUpdate = False
            Me.tdgOrder1.AlternatingRows = True
            Me.tdgOrder1.BackColor = System.Drawing.Color.SteelBlue
            Me.tdgOrder1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgOrder1.CaptionHeight = 17
            Me.tdgOrder1.ExtendRightColumn = True
            Me.tdgOrder1.FetchRowStyles = True
            Me.tdgOrder1.FilterBar = True
            Me.tdgOrder1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgOrder1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgOrder1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgOrder1.Location = New System.Drawing.Point(48, 64)
            Me.tdgOrder1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.tdgOrder1.Name = "tdgOrder1"
            Me.tdgOrder1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgOrder1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgOrder1.PreviewInfo.ZoomFactor = 75
            Me.tdgOrder1.RowHeight = 20
            Me.tdgOrder1.Size = New System.Drawing.Size(872, 328)
            Me.tdgOrder1.TabIndex = 160
            Me.tdgOrder1.Text = "C1TrueDBGrid1"
            Me.tdgOrder1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 12pt;}Highlight" & _
            "Row{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector" & _
            "{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Nea" & _
            "r;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" ExtendRightColumn=""True"" FetchRowStyles=""Tru" & _
            "e"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" Def" & _
            "RecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>326</" & _
            "Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor""" & _
            " me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle pare" & _
            "nt=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupS" & _
            "tyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" />" & _
            "<HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""In" & _
            "active"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelector" & _
            "Style parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me" & _
            "=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 870, 326</Cli" & _
            "entRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tr" & _
            "ueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style p" & _
            "arent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style paren" & _
            "t=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent" & _
            "=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""No" & _
            "rmal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""N" & _
            "ormal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent" & _
            "=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultR" & _
            "ecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 870, 326</ClientArea><PrintP" & _
            "ageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Styl" & _
            "e15"" /></Blob>"
            '
            'TabPage4
            '
            Me.TabPage4.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage4.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDelete, Me.Label4, Me.TextBox1, Me.btnSave, Me.cmbModels, Me.btnUpdate, Me.tdgMatrix1})
            Me.TabPage4.Location = New System.Drawing.Point(4, 22)
            Me.TabPage4.Name = "TabPage4"
            Me.TabPage4.Size = New System.Drawing.Size(1008, 534)
            Me.TabPage4.TabIndex = 2
            Me.TabPage4.Text = "Pick Loc"
            '
            'btnDelete
            '
            Me.btnDelete.BackColor = System.Drawing.Color.LightCoral
            Me.btnDelete.Location = New System.Drawing.Point(392, 440)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(160, 48)
            Me.btnDelete.TabIndex = 166
            Me.btnDelete.Text = "Delete Selected Location"
            '
            'Label4
            '
            Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.Label4.Location = New System.Drawing.Point(392, 216)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(100, 16)
            Me.Label4.TabIndex = 165
            Me.Label4.Text = "Add New Location"
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(392, 232)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(160, 20)
            Me.TextBox1.TabIndex = 164
            Me.TextBox1.Text = ""
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.PaleGreen
            Me.btnSave.Location = New System.Drawing.Point(392, 256)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(160, 48)
            Me.btnSave.TabIndex = 163
            Me.btnSave.Text = "Save New Location"
            '
            'cmbModels
            '
            Me.cmbModels.Location = New System.Drawing.Point(624, 152)
            Me.cmbModels.Name = "cmbModels"
            Me.cmbModels.Size = New System.Drawing.Size(121, 21)
            Me.cmbModels.TabIndex = 162
            Me.cmbModels.Text = "cmbModels"
            '
            'btnUpdate
            '
            Me.btnUpdate.BackColor = System.Drawing.Color.PaleGreen
            Me.btnUpdate.Location = New System.Drawing.Point(392, 32)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(160, 48)
            Me.btnUpdate.TabIndex = 161
            Me.btnUpdate.Text = "Update"
            '
            'tdgMatrix1
            '
            Me.tdgMatrix1.AlternatingRows = True
            Me.tdgMatrix1.BackColor = System.Drawing.Color.SteelBlue
            Me.tdgMatrix1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgMatrix1.CaptionHeight = 17
            Me.tdgMatrix1.FetchRowStyles = True
            Me.tdgMatrix1.FilterBar = True
            Me.tdgMatrix1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgMatrix1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgMatrix1.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgMatrix1.Location = New System.Drawing.Point(32, 24)
            Me.tdgMatrix1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.tdgMatrix1.Name = "tdgMatrix1"
            Me.tdgMatrix1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgMatrix1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgMatrix1.PreviewInfo.ZoomFactor = 75
            Me.tdgMatrix1.RowHeight = 20
            Me.tdgMatrix1.Size = New System.Drawing.Size(336, 488)
            Me.tdgMatrix1.TabIndex = 160
            Me.tdgMatrix1.Text = "C1TrueDBGrid1"
            Me.tdgMatrix1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 12pt;}Highlight" & _
            "Row{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector" & _
            "{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Nea" & _
            "r;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>486</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 334, 486</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 334, 486</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'TabPage3
            '
            Me.TabPage3.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label18, Me.DateTimePicker2, Me.Label3, Me.Label2, Me.tdgOrderDetails, Me.tdgCompOrders})
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(1008, 534)
            Me.TabPage3.TabIndex = 4
            Me.TabPage3.Text = "Cmpl Orders"
            '
            'Label18
            '
            Me.Label18.BackColor = System.Drawing.Color.Transparent
            Me.Label18.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.White
            Me.Label18.Location = New System.Drawing.Point(16, 40)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(264, 16)
            Me.Label18.TabIndex = 204
            Me.Label18.Text = "Load Orders Completed after:"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'DateTimePicker2
            '
            Me.DateTimePicker2.Location = New System.Drawing.Point(296, 40)
            Me.DateTimePicker2.Name = "DateTimePicker2"
            Me.DateTimePicker2.TabIndex = 203
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label3.Location = New System.Drawing.Point(328, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(240, 20)
            Me.Label3.TabIndex = 202
            Me.Label3.Text = "List of Order Details"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlLightLight
            Me.Label2.Location = New System.Drawing.Point(32, 96)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(240, 20)
            Me.Label2.TabIndex = 201
            Me.Label2.Text = "List of Completed Orders"
            '
            'tdgOrderDetails
            '
            Me.tdgOrderDetails.AllowUpdate = False
            Me.tdgOrderDetails.AlternatingRows = True
            Me.tdgOrderDetails.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgOrderDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgOrderDetails.CaptionHeight = 17
            Me.tdgOrderDetails.FetchRowStyles = True
            Me.tdgOrderDetails.FilterBar = True
            Me.tdgOrderDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgOrderDetails.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgOrderDetails.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgOrderDetails.Location = New System.Drawing.Point(328, 120)
            Me.tdgOrderDetails.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgOrderDetails.Name = "tdgOrderDetails"
            Me.tdgOrderDetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgOrderDetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgOrderDetails.PreviewInfo.ZoomFactor = 75
            Me.tdgOrderDetails.RowHeight = 20
            Me.tdgOrderDetails.Size = New System.Drawing.Size(624, 392)
            Me.tdgOrderDetails.TabIndex = 200
            Me.tdgOrderDetails.Text = "C1TrueDBGrid2"
            Me.tdgOrderDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 12pt;}Highlight" & _
            "Row{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector" & _
            "{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Nea" & _
            "r;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>390</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 622, 390</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 622, 390</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tdgCompOrders
            '
            Me.tdgCompOrders.AllowUpdate = False
            Me.tdgCompOrders.AlternatingRows = True
            Me.tdgCompOrders.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgCompOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgCompOrders.CaptionHeight = 17
            Me.tdgCompOrders.FetchRowStyles = True
            Me.tdgCompOrders.FilterBar = True
            Me.tdgCompOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgCompOrders.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgCompOrders.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgCompOrders.Location = New System.Drawing.Point(32, 120)
            Me.tdgCompOrders.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgCompOrders.Name = "tdgCompOrders"
            Me.tdgCompOrders.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgCompOrders.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgCompOrders.PreviewInfo.ZoomFactor = 75
            Me.tdgCompOrders.RowHeight = 20
            Me.tdgCompOrders.Size = New System.Drawing.Size(216, 392)
            Me.tdgCompOrders.TabIndex = 199
            Me.tdgCompOrders.Text = "C1TrueDBGrid1"
            Me.tdgCompOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 12pt;}Highlight" & _
            "Row{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector" & _
            "{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Nea" & _
            "r;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>390</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 214, 390</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 214, 390</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbShip1, Me.btnExp, Me.tdgShip1})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(1008, 534)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Ship Method"
            '
            'cmbShip1
            '
            Me.cmbShip1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
            Me.cmbShip1.Location = New System.Drawing.Point(512, 112)
            Me.cmbShip1.Name = "cmbShip1"
            Me.cmbShip1.Size = New System.Drawing.Size(320, 104)
            Me.cmbShip1.TabIndex = 163
            Me.cmbShip1.Text = "ComboBox1"
            Me.cmbShip1.Visible = False
            '
            'btnExp
            '
            Me.btnExp.BackColor = System.Drawing.Color.Green
            Me.btnExp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExp.ForeColor = System.Drawing.Color.White
            Me.btnExp.Location = New System.Drawing.Point(720, 424)
            Me.btnExp.Name = "btnExp"
            Me.btnExp.Size = New System.Drawing.Size(128, 64)
            Me.btnExp.TabIndex = 162
            Me.btnExp.Text = " Update"
            '
            'tdgShip1
            '
            Me.tdgShip1.AllowUpdate = False
            Me.tdgShip1.AlternatingRows = True
            Me.tdgShip1.BackColor = System.Drawing.Color.SteelBlue
            Me.tdgShip1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgShip1.CaptionHeight = 17
            Me.tdgShip1.ExtendRightColumn = True
            Me.tdgShip1.FetchRowStyles = True
            Me.tdgShip1.FilterBar = True
            Me.tdgShip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgShip1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgShip1.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgShip1.Location = New System.Drawing.Point(40, 40)
            Me.tdgShip1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.tdgShip1.Name = "tdgShip1"
            Me.tdgShip1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgShip1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgShip1.PreviewInfo.ZoomFactor = 75
            Me.tdgShip1.RowHeight = 20
            Me.tdgShip1.Size = New System.Drawing.Size(928, 352)
            Me.tdgShip1.TabIndex = 159
            Me.tdgShip1.Text = "C1TrueDBGrid1"
            Me.tdgShip1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 12pt;}Highlight" & _
            "Row{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector" & _
            "{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Nea" & _
            "r;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" ExtendRightColumn=""True"" FetchRowStyles=""Tru" & _
            "e"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" Def" & _
            "RecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>350</" & _
            "Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor""" & _
            " me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle pare" & _
            "nt=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupS" & _
            "tyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" />" & _
            "<HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""In" & _
            "active"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelector" & _
            "Style parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me" & _
            "=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 926, 350</Cli" & _
            "entRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tr" & _
            "ueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style p" & _
            "arent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style paren" & _
            "t=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent" & _
            "=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""No" & _
            "rmal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""N" & _
            "ormal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent" & _
            "=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultR" & _
            "ecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 926, 350</ClientArea><PrintP" & _
            "ageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Styl" & _
            "e15"" /></Blob>"
            '
            'TabPage5
            '
            Me.TabPage5.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage5.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1, Me.Label9, Me.Label8, Me.RadioButton3, Me.RadioButton2, Me.RadioButton1})
            Me.TabPage5.Location = New System.Drawing.Point(4, 22)
            Me.TabPage5.Name = "TabPage5"
            Me.TabPage5.Size = New System.Drawing.Size(1008, 534)
            Me.TabPage5.TabIndex = 6
            Me.TabPage5.Text = "Model Mgt"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label19, Me.C1CmbModelDesc, Me.rdbRawMaterials, Me.rdbPhones, Me.C1tdgViewModels})
            Me.GroupBox2.Location = New System.Drawing.Point(32, 88)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(904, 440)
            Me.GroupBox2.TabIndex = 232
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Available Models"
            Me.GroupBox2.Visible = False
            '
            'Label19
            '
            Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label19.Location = New System.Drawing.Point(16, 112)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(144, 23)
            Me.Label19.TabIndex = 235
            Me.Label19.Text = "Model Description"
            '
            'C1CmbModelDesc
            '
            Me.C1CmbModelDesc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.C1CmbModelDesc.AutoCompletion = True
            Me.C1CmbModelDesc.AutoDropDown = True
            Me.C1CmbModelDesc.AutoSelect = True
            Me.C1CmbModelDesc.Caption = ""
            Me.C1CmbModelDesc.CaptionHeight = 17
            Me.C1CmbModelDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.C1CmbModelDesc.ColumnCaptionHeight = 17
            Me.C1CmbModelDesc.ColumnFooterHeight = 17
            Me.C1CmbModelDesc.ColumnHeaders = False
            Me.C1CmbModelDesc.ContentHeight = 15
            Me.C1CmbModelDesc.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.C1CmbModelDesc.EditorBackColor = System.Drawing.SystemColors.Window
            Me.C1CmbModelDesc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.C1CmbModelDesc.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.C1CmbModelDesc.EditorHeight = 15
            Me.C1CmbModelDesc.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.C1CmbModelDesc.ItemHeight = 15
            Me.C1CmbModelDesc.Location = New System.Drawing.Point(160, 112)
            Me.C1CmbModelDesc.MatchEntryTimeout = CType(2000, Long)
            Me.C1CmbModelDesc.MaxDropDownItems = CType(10, Short)
            Me.C1CmbModelDesc.MaxLength = 32767
            Me.C1CmbModelDesc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.C1CmbModelDesc.Name = "C1CmbModelDesc"
            Me.C1CmbModelDesc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.C1CmbModelDesc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.C1CmbModelDesc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.C1CmbModelDesc.Size = New System.Drawing.Size(264, 21)
            Me.C1CmbModelDesc.TabIndex = 234
            Me.C1CmbModelDesc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'rdbRawMaterials
            '
            Me.rdbRawMaterials.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rdbRawMaterials.Location = New System.Drawing.Point(264, 40)
            Me.rdbRawMaterials.Name = "rdbRawMaterials"
            Me.rdbRawMaterials.Size = New System.Drawing.Size(160, 24)
            Me.rdbRawMaterials.TabIndex = 206
            Me.rdbRawMaterials.Text = "Raw Materials"
            '
            'rdbPhones
            '
            Me.rdbPhones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rdbPhones.Location = New System.Drawing.Point(16, 40)
            Me.rdbPhones.Name = "rdbPhones"
            Me.rdbPhones.Size = New System.Drawing.Size(176, 24)
            Me.rdbPhones.TabIndex = 205
            Me.rdbPhones.Text = "Phones (Handset)"
            '
            'C1tdgViewModels
            '
            Me.C1tdgViewModels.AllowUpdate = False
            Me.C1tdgViewModels.AlternatingRows = True
            Me.C1tdgViewModels.BackColor = System.Drawing.Color.SteelBlue
            Me.C1tdgViewModels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.C1tdgViewModels.CaptionHeight = 17
            Me.C1tdgViewModels.ExtendRightColumn = True
            Me.C1tdgViewModels.FetchRowStyles = True
            Me.C1tdgViewModels.FilterBar = True
            Me.C1tdgViewModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.C1tdgViewModels.GroupByCaption = "Drag a column header here to group by that column"
            Me.C1tdgViewModels.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.C1tdgViewModels.Location = New System.Drawing.Point(16, 192)
            Me.C1tdgViewModels.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.C1tdgViewModels.Name = "C1tdgViewModels"
            Me.C1tdgViewModels.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.C1tdgViewModels.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.C1tdgViewModels.PreviewInfo.ZoomFactor = 75
            Me.C1tdgViewModels.RowHeight = 20
            Me.C1tdgViewModels.Size = New System.Drawing.Size(864, 136)
            Me.C1tdgViewModels.TabIndex = 161
            Me.C1tdgViewModels.Text = "C1TrueDBGrid1"
            Me.C1tdgViewModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 12pt;}Highlight" & _
            "Row{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector" & _
            "{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Nea" & _
            "r;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" ExtendRightColumn=""True"" FetchRowStyles=""Tru" & _
            "e"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" Def" & _
            "RecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>134</" & _
            "Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor""" & _
            " me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle pare" & _
            "nt=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupS" & _
            "tyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" />" & _
            "<HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""In" & _
            "active"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelector" & _
            "Style parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me" & _
            "=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 862, 134</Cli" & _
            "entRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tr" & _
            "ueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style p" & _
            "arent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style paren" & _
            "t=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent" & _
            "=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""No" & _
            "rmal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""N" & _
            "ormal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent" & _
            "=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultR" & _
            "ecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 862, 134</ClientArea><PrintP" & _
            "ageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Styl" & _
            "e15"" /></Blob>"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label11, Me.C1Class, Me.txtModDesc, Me.txtUpcCodeID, Me.C1CmbTechDcodeId, Me.C1SubClass, Me.Label15, Me.Label16, Me.txtModLongDesc, Me.Label5, Me.Label10, Me.Label17, Me.Label12, Me.Label13, Me.txtHeight, Me.lblWidth, Me.txtLength, Me.txtWeight, Me.txtWidth, Me.Label14, Me.btnClear, Me.btnModel})
            Me.GroupBox1.Location = New System.Drawing.Point(32, 88)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(904, 424)
            Me.GroupBox1.TabIndex = 231
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Model Details"
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(16, 272)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(130, 16)
            Me.Label11.TabIndex = 209
            Me.Label11.Text = "UPC"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'C1Class
            '
            Me.C1Class.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.C1Class.AutoCompletion = True
            Me.C1Class.AutoDropDown = True
            Me.C1Class.AutoSelect = True
            Me.C1Class.Caption = ""
            Me.C1Class.CaptionHeight = 17
            Me.C1Class.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.C1Class.ColumnCaptionHeight = 17
            Me.C1Class.ColumnFooterHeight = 17
            Me.C1Class.ColumnHeaders = False
            Me.C1Class.ContentHeight = 15
            Me.C1Class.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.C1Class.EditorBackColor = System.Drawing.SystemColors.Window
            Me.C1Class.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.C1Class.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.C1Class.EditorHeight = 15
            Me.C1Class.Images.Add(CType(resources.GetObject("resource.Images7"), System.Drawing.Bitmap))
            Me.C1Class.ItemHeight = 15
            Me.C1Class.Location = New System.Drawing.Point(168, 128)
            Me.C1Class.MatchEntryTimeout = CType(2000, Long)
            Me.C1Class.MaxDropDownItems = CType(10, Short)
            Me.C1Class.MaxLength = 32767
            Me.C1Class.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.C1Class.Name = "C1Class"
            Me.C1Class.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.C1Class.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.C1Class.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.C1Class.Size = New System.Drawing.Size(200, 21)
            Me.C1Class.TabIndex = 228
            Me.C1Class.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'txtModDesc
            '
            Me.txtModDesc.Location = New System.Drawing.Point(168, 32)
            Me.txtModDesc.Name = "txtModDesc"
            Me.txtModDesc.Size = New System.Drawing.Size(200, 20)
            Me.txtModDesc.TabIndex = 200
            Me.txtModDesc.Text = ""
            '
            'txtUpcCodeID
            '
            Me.txtUpcCodeID.Location = New System.Drawing.Point(168, 272)
            Me.txtUpcCodeID.Name = "txtUpcCodeID"
            Me.txtUpcCodeID.Size = New System.Drawing.Size(200, 20)
            Me.txtUpcCodeID.TabIndex = 210
            Me.txtUpcCodeID.Text = ""
            '
            'C1CmbTechDcodeId
            '
            Me.C1CmbTechDcodeId.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.C1CmbTechDcodeId.AutoCompletion = True
            Me.C1CmbTechDcodeId.AutoDropDown = True
            Me.C1CmbTechDcodeId.AutoSelect = True
            Me.C1CmbTechDcodeId.Caption = ""
            Me.C1CmbTechDcodeId.CaptionHeight = 17
            Me.C1CmbTechDcodeId.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.C1CmbTechDcodeId.ColumnCaptionHeight = 17
            Me.C1CmbTechDcodeId.ColumnFooterHeight = 17
            Me.C1CmbTechDcodeId.ColumnHeaders = False
            Me.C1CmbTechDcodeId.ContentHeight = 15
            Me.C1CmbTechDcodeId.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.C1CmbTechDcodeId.EditorBackColor = System.Drawing.SystemColors.Window
            Me.C1CmbTechDcodeId.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.C1CmbTechDcodeId.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.C1CmbTechDcodeId.EditorHeight = 15
            Me.C1CmbTechDcodeId.Images.Add(CType(resources.GetObject("resource.Images8"), System.Drawing.Bitmap))
            Me.C1CmbTechDcodeId.ItemHeight = 15
            Me.C1CmbTechDcodeId.Location = New System.Drawing.Point(168, 224)
            Me.C1CmbTechDcodeId.MatchEntryTimeout = CType(2000, Long)
            Me.C1CmbTechDcodeId.MaxDropDownItems = CType(10, Short)
            Me.C1CmbTechDcodeId.MaxLength = 32767
            Me.C1CmbTechDcodeId.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.C1CmbTechDcodeId.Name = "C1CmbTechDcodeId"
            Me.C1CmbTechDcodeId.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.C1CmbTechDcodeId.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.C1CmbTechDcodeId.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.C1CmbTechDcodeId.Size = New System.Drawing.Size(200, 21)
            Me.C1CmbTechDcodeId.TabIndex = 223
            Me.C1CmbTechDcodeId.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'C1SubClass
            '
            Me.C1SubClass.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.C1SubClass.AutoCompletion = True
            Me.C1SubClass.AutoDropDown = True
            Me.C1SubClass.AutoSelect = True
            Me.C1SubClass.Caption = ""
            Me.C1SubClass.CaptionHeight = 17
            Me.C1SubClass.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.C1SubClass.ColumnCaptionHeight = 17
            Me.C1SubClass.ColumnFooterHeight = 17
            Me.C1SubClass.ColumnHeaders = False
            Me.C1SubClass.ContentHeight = 15
            Me.C1SubClass.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.C1SubClass.EditorBackColor = System.Drawing.SystemColors.Window
            Me.C1SubClass.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.C1SubClass.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.C1SubClass.EditorHeight = 15
            Me.C1SubClass.Images.Add(CType(resources.GetObject("resource.Images9"), System.Drawing.Bitmap))
            Me.C1SubClass.ItemHeight = 15
            Me.C1SubClass.Location = New System.Drawing.Point(168, 176)
            Me.C1SubClass.MatchEntryTimeout = CType(2000, Long)
            Me.C1SubClass.MaxDropDownItems = CType(10, Short)
            Me.C1SubClass.MaxLength = 32767
            Me.C1SubClass.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.C1SubClass.Name = "C1SubClass"
            Me.C1SubClass.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.C1SubClass.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.C1SubClass.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.C1SubClass.Size = New System.Drawing.Size(200, 21)
            Me.C1SubClass.TabIndex = 230
            Me.C1SubClass.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(16, 224)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(130, 16)
            Me.Label15.TabIndex = 220
            Me.Label15.Text = "Technology"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label16
            '
            Me.Label16.BackColor = System.Drawing.Color.Transparent
            Me.Label16.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label16.ForeColor = System.Drawing.Color.White
            Me.Label16.Location = New System.Drawing.Point(16, 128)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(130, 16)
            Me.Label16.TabIndex = 227
            Me.Label16.Text = "Class"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtModLongDesc
            '
            Me.txtModLongDesc.Location = New System.Drawing.Point(168, 80)
            Me.txtModLongDesc.Name = "txtModLongDesc"
            Me.txtModLongDesc.Size = New System.Drawing.Size(200, 20)
            Me.txtModLongDesc.TabIndex = 208
            Me.txtModLongDesc.Text = ""
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(16, 32)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(130, 16)
            Me.Label5.TabIndex = 199
            Me.Label5.Text = "Model Desciription:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(16, 80)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(130, 16)
            Me.Label10.TabIndex = 207
            Me.Label10.Text = "Long Description"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label17
            '
            Me.Label17.BackColor = System.Drawing.Color.Transparent
            Me.Label17.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label17.ForeColor = System.Drawing.Color.White
            Me.Label17.Location = New System.Drawing.Point(16, 176)
            Me.Label17.Name = "Label17"
            Me.Label17.Size = New System.Drawing.Size(130, 16)
            Me.Label17.TabIndex = 229
            Me.Label17.Text = "Sub Class"
            Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(504, 40)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(130, 16)
            Me.Label12.TabIndex = 211
            Me.Label12.Text = "Weight"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label13
            '
            Me.Label13.BackColor = System.Drawing.Color.Transparent
            Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label13.ForeColor = System.Drawing.Color.White
            Me.Label13.Location = New System.Drawing.Point(504, 88)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(130, 16)
            Me.Label13.TabIndex = 213
            Me.Label13.Text = "Height"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtHeight
            '
            Me.txtHeight.Location = New System.Drawing.Point(656, 88)
            Me.txtHeight.Name = "txtHeight"
            Me.txtHeight.Size = New System.Drawing.Size(200, 20)
            Me.txtHeight.TabIndex = 214
            Me.txtHeight.Text = ""
            '
            'lblWidth
            '
            Me.lblWidth.BackColor = System.Drawing.Color.Transparent
            Me.lblWidth.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWidth.ForeColor = System.Drawing.Color.White
            Me.lblWidth.Location = New System.Drawing.Point(504, 136)
            Me.lblWidth.Name = "lblWidth"
            Me.lblWidth.Size = New System.Drawing.Size(130, 16)
            Me.lblWidth.TabIndex = 215
            Me.lblWidth.Text = "Width"
            Me.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtLength
            '
            Me.txtLength.Location = New System.Drawing.Point(656, 184)
            Me.txtLength.Name = "txtLength"
            Me.txtLength.Size = New System.Drawing.Size(200, 20)
            Me.txtLength.TabIndex = 218
            Me.txtLength.Text = ""
            '
            'txtWeight
            '
            Me.txtWeight.Location = New System.Drawing.Point(656, 40)
            Me.txtWeight.Name = "txtWeight"
            Me.txtWeight.Size = New System.Drawing.Size(200, 20)
            Me.txtWeight.TabIndex = 212
            Me.txtWeight.Text = ""
            '
            'txtWidth
            '
            Me.txtWidth.Location = New System.Drawing.Point(656, 136)
            Me.txtWidth.Name = "txtWidth"
            Me.txtWidth.Size = New System.Drawing.Size(200, 20)
            Me.txtWidth.TabIndex = 216
            Me.txtWidth.Text = ""
            '
            'Label14
            '
            Me.Label14.BackColor = System.Drawing.Color.Transparent
            Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label14.ForeColor = System.Drawing.Color.White
            Me.Label14.Location = New System.Drawing.Point(504, 184)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(130, 16)
            Me.Label14.TabIndex = 217
            Me.Label14.Text = "Length"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.PaleGreen
            Me.btnClear.Location = New System.Drawing.Point(192, 360)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(136, 40)
            Me.btnClear.TabIndex = 226
            Me.btnClear.Text = "Clear"
            '
            'btnModel
            '
            Me.btnModel.BackColor = System.Drawing.Color.PaleGreen
            Me.btnModel.Location = New System.Drawing.Point(536, 360)
            Me.btnModel.Name = "btnModel"
            Me.btnModel.Size = New System.Drawing.Size(136, 40)
            Me.btnModel.TabIndex = 219
            Me.btnModel.Text = "Save New Location"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.SkyBlue
            Me.Label9.Location = New System.Drawing.Point(24, 16)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(936, 2)
            Me.Label9.TabIndex = 206
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.SkyBlue
            Me.Label8.Location = New System.Drawing.Point(24, 64)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(936, 2)
            Me.Label8.TabIndex = 205
            '
            'RadioButton3
            '
            Me.RadioButton3.Location = New System.Drawing.Point(368, 32)
            Me.RadioButton3.Name = "RadioButton3"
            Me.RadioButton3.TabIndex = 204
            Me.RadioButton3.Text = "Edit Model"
            Me.RadioButton3.Visible = False
            '
            'RadioButton2
            '
            Me.RadioButton2.Location = New System.Drawing.Point(208, 32)
            Me.RadioButton2.Name = "RadioButton2"
            Me.RadioButton2.TabIndex = 203
            Me.RadioButton2.Text = "View Model"
            '
            'RadioButton1
            '
            Me.RadioButton1.Checked = True
            Me.RadioButton1.Location = New System.Drawing.Point(56, 32)
            Me.RadioButton1.Name = "RadioButton1"
            Me.RadioButton1.TabIndex = 202
            Me.RadioButton1.TabStop = True
            Me.RadioButton1.Text = "Add Model"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgItem1, Me.cboModel, Me.txtModelDesc, Me.Label1, Me.Label6})
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(1008, 534)
            Me.TabPage2.TabIndex = 3
            Me.TabPage2.Text = "Item History"
            '
            'tdgItem1
            '
            Me.tdgItem1.AllowUpdate = False
            Me.tdgItem1.AlternatingRows = True
            Me.tdgItem1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgItem1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgItem1.CaptionHeight = 17
            Me.tdgItem1.FetchRowStyles = True
            Me.tdgItem1.FilterBar = True
            Me.tdgItem1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgItem1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgItem1.Images.Add(CType(resources.GetObject("resource.Images10"), System.Drawing.Bitmap))
            Me.tdgItem1.Location = New System.Drawing.Point(32, 136)
            Me.tdgItem1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgItem1.Name = "tdgItem1"
            Me.tdgItem1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgItem1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgItem1.PreviewInfo.ZoomFactor = 75
            Me.tdgItem1.RowHeight = 20
            Me.tdgItem1.Size = New System.Drawing.Size(768, 320)
            Me.tdgItem1.TabIndex = 198
            Me.tdgItem1.Text = "C1TrueDBGrid1"
            Me.tdgItem1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 12pt;}Highlight" & _
            "Row{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector" & _
            "{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Nea" & _
            "r;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>318</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 766, 318</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 766, 318</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.AutoCompletion = True
            Me.cboModel.AutoDropDown = True
            Me.cboModel.AutoSelect = True
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ColumnHeaders = False
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images11"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(208, 40)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(10, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(232, 21)
            Me.cboModel.TabIndex = 197
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'txtModelDesc
            '
            Me.txtModelDesc.Location = New System.Drawing.Point(208, 72)
            Me.txtModelDesc.Name = "txtModelDesc"
            Me.txtModelDesc.ReadOnly = True
            Me.txtModelDesc.Size = New System.Drawing.Size(536, 20)
            Me.txtModelDesc.TabIndex = 196
            Me.txtModelDesc.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(40, 80)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(130, 16)
            Me.Label1.TabIndex = 195
            Me.Label1.Text = "Description :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(40, 48)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(130, 16)
            Me.Label6.TabIndex = 194
            Me.Label6.Text = "Item :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TabPage6
            '
            Me.TabPage6.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage6.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.DateTimePicker1, Me.btnCpySelected, Me.btnCopy, Me.tdgData1})
            Me.TabPage6.Location = New System.Drawing.Point(4, 22)
            Me.TabPage6.Name = "TabPage6"
            Me.TabPage6.Size = New System.Drawing.Size(1008, 534)
            Me.TabPage6.TabIndex = 7
            Me.TabPage6.Text = "WH Box"
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(16, 56)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(136, 16)
            Me.Label7.TabIndex = 195
            Me.Label7.Text = "Load Items after:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'DateTimePicker1
            '
            Me.DateTimePicker1.Location = New System.Drawing.Point(176, 48)
            Me.DateTimePicker1.Name = "DateTimePicker1"
            Me.DateTimePicker1.TabIndex = 181
            '
            'btnCpySelected
            '
            Me.btnCpySelected.Location = New System.Drawing.Point(344, 480)
            Me.btnCpySelected.Name = "btnCpySelected"
            Me.btnCpySelected.Size = New System.Drawing.Size(96, 23)
            Me.btnCpySelected.TabIndex = 180
            Me.btnCpySelected.Text = "Copy Selected"
            '
            'btnCopy
            '
            Me.btnCopy.Location = New System.Drawing.Point(200, 480)
            Me.btnCopy.Name = "btnCopy"
            Me.btnCopy.Size = New System.Drawing.Size(80, 23)
            Me.btnCopy.TabIndex = 179
            Me.btnCopy.Text = "Copy All"
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
            Me.tdgData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images12"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(24, 96)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.RowHeight = 15
            Me.tdgData1.Size = New System.Drawing.Size(584, 352)
            Me.tdgData1.TabIndex = 178
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 9pt;}HighlightR" & _
            "ow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{" & _
            "AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1," & _
            " 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near" & _
            ";}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGri" & _
            "d.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionH" & _
            "eight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Marque" & _
            "eStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalS" & _
            "crollGroup=""1"" HorizontalScrollGroup=""1""><Height>350</Height><CaptionStyle paren" & _
            "t=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSty" & _
            "le parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13" & _
            """ /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""St" & _
            "yle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=" & _
            """HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelect" & _
            "or"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=" & _
            """Normal"" me=""Style1"" /><ClientRect>0, 0, 582, 350</ClientRect><BorderSide>0</Bor" & _
            "derSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 582, 350</ClientArea><PrintPageHeaderStyle parent="""" m" & _
            "e=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmTFFK_Admin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1064, 606)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmTFFK_Admin"
            Me.Text = "frmTFFK_Admin"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage0.ResumeLayout(False)
            CType(Me.tdgOrder1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage4.ResumeLayout(False)
            CType(Me.tdgMatrix1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage3.ResumeLayout(False)
            CType(Me.tdgOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgCompOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage1.ResumeLayout(False)
            CType(Me.tdgShip1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage5.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.C1CmbModelDesc, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.C1tdgViewModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.C1Class, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.C1CmbTechDcodeId, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.C1SubClass, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.tdgItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage6.ResumeLayout(False)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_Admin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dtOrders As DataTable
            Dim dtShip As DataTable


            Try
                '*******************************
                'ORDERS TAB
                '*******************************
                'Populate Open Orders
                Me._dtOpenOrders = Me._objAdmin.getOpenOrderData
                Me.BindOrderData()

                '*******************************
                'SHIPMETHOD TAB
                '*******************************
                'Populate Orders
                Me._dtOrders = Me._objAdmin.getOrderData
                Me._dtShip = Me._objAdmin.getShipData
                Me.BindShipData()

                '*******************************
                'PICKLOCATIONSETUP TAB
                '*******************************
                'Populate Matrix
                LoadPickLocations()
                Me.getWareHouseBox(DateTime.Now)

                '*******************************
                'ITEMHISTORY TAB
                '*******************************
                'Populate Models
                Me._dtModel = Me._objAdmin.GetTFFKModel

                If Me._dtModel.Rows.Count > 0 Then
                    Me._dtDesc = Me._dtModel.Copy
                    Me._dtModel.Columns.Remove("Model_LDesc")

                    Misc.PopulateC1DropDownList(Me.cboModel, Me._dtModel, "Model_Desc", "model_id")
                    ClearUI()
                Else
                    MessageBox.Show("No models.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                '*******************************
                'COMPLETEDORDERS TAB
                '*******************************
                Me._dtCompOrders = Me._objAdmin.GetTFFKCompletedOrders(Date.Now)
                Me.BindCompOrders()

                '*******************************
                'Model Management Tab
                '*******************************
                'Bind with the combo technology
                Me._dtTech = Me._objAdmin.GetTechnology(85)
                Me._dtTech.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Misc.PopulateC1DropDownList(Me.C1CmbTechDcodeId, Me._dtTech, "Dcode_Sdesc", "Dcode_id")

                ' Bind with the combo dcode id
                Me._dtClass = Me._objAdmin.GetTechnology(82)
                Me._dtClass.LoadDataRow(New Object() {"0", "--Select--"}, True)
                Misc.PopulateC1DropDownList(Me.C1Class, Me._dtClass, "Dcode_Sdesc", "Dcode_id")

                C1CmbTechDcodeId.SelectedIndex = -1
                C1Class.SelectedIndex = -1

                '*******************************
                'Inventory Balance Tab
                '*******************************
                '_dtInventory = Me._objAdmin.loadInventoryBalance()

                'Me.InventoryData()


                '*******************************
                'Inventory Wip Tab
                '*******************************
                '_dtInventoryWip = Me._objAdmin.InventoryWIPLocation()
                'Me.WIPLocations()



            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_Admin_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub




        Private Sub getWareHouseBox(ByVal myDate As DateTime)
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                Me._dtAllBoxes = Me._objWareHouseBox.getData("TR" & myDate.ToString("yyyy") & "" & myDate.ToString("MM") & "" & myDate.ToString("dd"))

                Me.bindData(Me._dtAllBoxes)


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "getWareHouseBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        
        Sub bindData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If dt.Rows.Count > 0 Then

                    With Me.tdgData1
                        .DataSource = dt.DefaultView
                        .AllowSort = True
                        .EditActive = True
                        .AllowUpdate = True


                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = False
                            dbgc.AutoSize()
                            dbgc.AutoComplete = True
                        Next dbgc




                    End With
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "bindData getWareHouseBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try



        End Sub



#Region "View Model Radio button"
        Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
            If RadioButton2.Checked = True Then
                GroupBox1.Visible = False
                GroupBox2.Visible = True
                C1CmbModelDesc.ClearItems()
                C1CmbModelDesc.DataSource = Nothing
                C1CmbModelDesc.Text = ""
                rdbPhones.Checked = False
                rdbRawMaterials.Checked = False
                C1tdgViewModels.DataSource = Nothing
            Else

            End If



        End Sub

        Private Sub rdbPhones_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbPhones.CheckedChanged
            C1CmbModelDesc.ClearItems()
            If rdbPhones.Checked Then

                _dtModelItems = Me._objAdmin.getAvailableModels(4231)
                'C1CmbModelDesc.DataSource = _dtModelItems.DefaultView
                Misc.PopulateC1DropDownList(C1CmbModelDesc, _dtModelItems, "Model_Desc", "Model_ID")

            End If


        End Sub
        Private Sub rdbRawMaterials_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbRawMaterials.CheckedChanged

            C1CmbModelDesc.ClearItems()
            If rdbRawMaterials.Checked Then

                _dtModelItems = Me._objAdmin.getAvailableModels(50001)
                'C1CmbModelDesc.DataSource = _dtModelItems.DefaultView
                Misc.PopulateC1DropDownList(C1CmbModelDesc, _dtModelItems, "Model_Desc", "Model_ID")
            End If

        End Sub




        Private Sub C1CmbModelDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1CmbModelDesc.TextChanged
            Try
                Dim id As Integer = Me._dtModelItems.Rows(C1CmbModelDesc.SelectedIndex).Item("Model_ID")

                _dtOneModel = Me._objAdmin.getOneModel(id)

                loadDataGrid()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "View Model C1CmbModel", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        Private Sub loadDataGrid()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
            Dim dbdd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown

            Try
                If Me._dtOneModel.Rows.Count > 0 Then

                    With Me.C1tdgViewModels
                        .DataSource = Me._dtOneModel.DefaultView
                        .AllowSort = True
                        .EditActive = True

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoComplete = True
                        Next dbgc


                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "View Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

#End Region

#Region "WIP Locations"

        'Private Sub WIPLocations()
        '    Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        '    Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        '    Dim dbdd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown

        '    Try
        '        If Me._dtInventory.Rows.Count > 0 Then

        '            With Me.C1tdgWIPLocations
        '                .DataSource = Me._dtInventoryWip.DefaultView
        '                .AllowSort = True
        '                .EditActive = True

        '                For Each dbgc In .Splits(0).DisplayColumns
        '                    dbgc.Locked = True
        '                    dbgc.AutoComplete = True
        '                Next dbgc

        '                'col = .Columns("Expedite Ship Method")
        '                'col.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
        '                'col.Editor = Me.cmbShip1

        '                '.Splits(0).DisplayColumns("Expedite Ship Method").Width = 100
        '                '.Splits(0).DisplayColumns("Expedite Ship Method").Style.WrapText = True
        '            End With
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "WIP Locations", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    End Try
        'End Sub

#End Region

#Region "inventory balance"
        'Private Sub InventoryData()
        '    Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        '    Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        '    Dim dbdd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown

        '    Try
        '        If Me._dtInventory.Rows.Count > 0 Then

        '            With Me.C1tdgInventory
        '                .DataSource = Me._dtInventory.DefaultView
        '                .AllowSort = True
        '                .EditActive = True

        '                For Each dbgc In .Splits(0).DisplayColumns
        '                    dbgc.Locked = True
        '                    dbgc.AutoComplete = True
        '                Next dbgc


        '            End With
        '        End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "BindShipData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        '    End Try
        'End Sub

#End Region

#Region "Orders"
        '*****************************************************************************
        Private Sub BindOrderData()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If Me._dtOpenOrders.Rows.Count > 0 Then

                    With Me.tdgOrder1
                        .DataSource = Me._dtOpenOrders.DefaultView
                        .AllowSort = True
                        .EditActive = True

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc

                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindOrderData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
            Dim xlsApplication As Excel.Application()
            Dim xlsWorkbook As Excel.Workbook()
            Dim sb As New StringBuilder()
            Dim fileName As String
            Dim row As DataRow
            Dim sfd As New SaveFileDialog()
            Dim csvFile As String
            Dim csv As String

            fileName = "OpenOrders.csv"

            csv = String.Format("{0},{1},{2},{3},{4},{5}", "Order No", "SKU", "Req. Ship", "Ship Method", "No. Item", "Total Order Qty")
            sb.Append(csv)
            sb.Append(Environment.NewLine)

            For Each row In Me._dtOpenOrders.Rows
                csv = String.Format("{0},{1},{2},{3},{4},{5}", row.Item(0).ToString, row.Item(1).ToString, row.Item(2).ToString, row.Item(3).ToString, row.Item(4).ToString, row.Item(5).ToString)
                sb.Append(csv)
                sb.Append(Environment.NewLine)
            Next

            With sfd
                .FileName = fileName.ToString
                If sfd.ShowDialog() = DialogResult.OK Then
                    Dim sw As StreamWriter = New StreamWriter(sfd.OpenFile())
                    If Not (sw Is Nothing) Then
                        sw.WriteLine(sb.ToString)
                        sw.Close()
                    End If
                End If
            End With
        End Sub

#End Region

#Region "ShipMethod"
        '*****************************************************************************
        Private Sub BindShipData()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
            Dim dbdd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown

            Try
                If Me._dtOrders.Rows.Count > 0 And Me._dtShip.Rows.Count > 0 Then

                    With Me.tdgShip1
                        .DataSource = Me._dtOrders.DefaultView
                        .AllowSort = True
                        .EditActive = True

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                            dbgc.AutoComplete = True
                        Next dbgc

                        col = .Columns("Expedite Ship Method")
                        col.ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.ComboBox
                        col.Editor = Me.cmbShip1

                        .Splits(0).DisplayColumns("Expedite Ship Method").Width = 100
                        .Splits(0).DisplayColumns("Expedite Ship Method").Style.WrapText = True
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindShipData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub tdgShip1_ButtonClick(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgShip1.ButtonClick
            Dim dbdc As C1.Win.C1TrueDBGrid.C1DropDisplayColumn
            Dim row As DataRow
            Dim loc As String
            Dim x As Integer = 512
            Dim y As Integer = 111
            Dim i As Integer = 1

            Try
                Me._intIndex = Me.tdgShip1.Row
                y = Me._intIndex * 20 + y

                With Me.cmbShip1
                    .DataSource = Me._dtShip.DefaultView
                    .DisplayMember = "ShipMethod"
                    .ValueMember = "ShipCode"
                    .SelectedIndex = 0
                    .BringToFront()
                    .Visible = True
                    .MaxLength = 500
                    .Location = New Point(x, y)
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tgdShip1_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cmbShip1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShip1.SelectionChangeCommitted
            Try
                Me._dtOrders.Rows(Me._intIndex).Item("Expedite Ship Method") = cmbShip1.SelectedItem("ShipMethod").ToString
                Me.tdgOrder1.Refresh()
                With Me.tdgShip1
                    .Splits(0).DisplayColumns("Expedite Ship Method").AutoSize()
                End With

                cmbShip1.Visible = False
                cmbShip1.SelectedIndex = -1
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cmbShip1_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnExp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExp.Click
            Dim row As DataRow
            Dim item() As DataRow
            Dim order As String
            Dim value As Integer
            Dim method As String
            Dim exp As String
            Dim i As Integer = 0
            Dim boolUpdate As Boolean = False

            Try
                For Each row In Me._dtOrders.Rows
                    If Not row("Expedite Ship Method") = "" Then
                        order = row("OrderNo")
                        method = row("Expedite Ship Method")
                        exp = "ShipMethod = '" & method & "'"
                        item = Me._dtShip.Select(exp)

                        If item.Length > 0 Then
                            value = Convert.ToInt32(item(0)(0))
                            i = Me._objAdmin.updateShip(order, value)
                            If i > 0 Then
                                boolUpdate = True
                            Else
                                boolUpdate = False
                                MessageBox.Show("Ship method " & method & ":  Update failed. Contact IT.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                        End If
                    End If
                Next

                If boolUpdate = True Then
                    MessageBox.Show("Expedited ship method updated succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnExp_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub tdgShip1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdgShip1.Click
            cmbShip1.Visible = False
        End Sub

#End Region

#Region "ItemHistory"
        '*****************************************************************************
        Private Sub BindItemData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If dt.Rows.Count > 0 Then
                    With Me.tdgItem1
                        .DataSource = dt.DefaultView

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc
                        '.Splits(0).DisplayColumns("Trans Type").Width = 0
                        '.Splits(0).DisplayColumns("Trans Date").Width = 0
                        '.Splits(0).DisplayColumns("Trans Time").Width = 0
                        '.Splits(0).DisplayColumns("Trans Qty").Width = 0
                        '.Splits(0).DisplayColumns("End Balance").Width = 0
                        '.Splits(0).DisplayColumns("USER").Width = 0
                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindItemData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            Try
                Me.tdgItem1.DataSource = Nothing
                Me.tdgItem1.Refresh()

                If cboModel.SelectedValue > 0 Then
                    Me.txtModelDesc.Text = Me._dtDesc.Rows(cboModel.SelectedIndex).Item("Model_LDesc").ToString
                    Me._ModelID = Me._dtDesc.Rows(cboModel.SelectedIndex).Item("model_id")
                    DisplayOrderHist()
                Else
                    ClearUI()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboModel_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub DisplayOrderHist()
            Dim dt As DataTable

            Try
                dt = Me._objAdmin.GetTransData(Me._ModelID)
                BindItemData(dt)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "DisplayOrders", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub ClearUI()
            Me.tdgItem1.DataSource = Nothing
            Me.txtModelDesc.Clear()
            Me.cboModel.SelectedValue = 0
        End Sub

#End Region

#Region "CompletedOrders"

        '*****************************************************************************
        Private Sub BindCompOrders()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If Me._dtCompOrders.Rows.Count > 0 Then

                    With Me.tdgCompOrders
                        .DataSource = Me._dtCompOrders.DefaultView
                        .Splits(0).DisplayColumns("OrderID").Visible = False

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                            dbgc.AutoComplete = True
                        Next dbgc

                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindOrderData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub tdgCompOrders_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdgCompOrders.RowColChange
            Dim order As String = ""

            Try
                If Not Me._dtOrderDetails Is Nothing Then
                    Me._dtOrderDetails.Clear()
                End If

                If Not IsNothing(Me.tdgCompOrders.DataSource) AndAlso Not Me.tdgCompOrders.RowCount <= 0 AndAlso Not IsNothing(Me.tdgCompOrders.Columns("Order No").Value) Then
                    order = Me.tdgCompOrders.Columns("Order No").Value.ToString()
                    If order.Trim.Length > 0 Then Me._dtOrderDetails = Me._objAdmin.GetTFFKCompletedDetails(order)
                    Me.BindCompDetails()
                    Me.tdgOrderDetails.Refresh()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindOrderData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub BindCompDetails()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                If Me._dtOrderDetails.Rows.Count > 0 Then

                    With Me.tdgOrderDetails
                        .DataSource = Me._dtOrderDetails.DefaultView
                        '.Splits(0).DisplayColumns("OrderID").Visible = False
                        '.Splits(0).DisplayColumns("DetailsID").Visible = False

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                            dbgc.AutoComplete = True
                        Next dbgc

                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindCompDetails", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

#End Region

#Region "PickLocationSetup"

        '*****************************************************************************

        Private Sub LoadPickLocations()
            Me.cmbModels.Visible = False
            Me._dtAllModels = Me._objAdmin.GetAllModels
            Me._dtMatrix = Me._objAdmin.getPickLocationMatrix
            Me.BindMatrixData()
        End Sub

        '*****************************************************************************
        Private Sub BindMatrixData()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

            Try
                If Me._dtMatrix.Rows.Count > 0 And Me._dtAllModels.Rows.Count > 0 Then

                    With Me.tdgMatrix1
                        .DataSource = Me._dtMatrix.DefaultView
                        .AllowSort = True
                        .EditActive = True
                        .AllowUpdate = True
                        .Splits(0).DisplayColumns("Model_ID").Visible = False
                        .Splits(0).DisplayColumns("Model").AutoComplete = True

                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = False
                            dbgc.AutoSize()
                            dbgc.AutoComplete = True
                        Next dbgc

                        .Splits(0).DisplayColumns("Pick Location").Locked = True

                    End With
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindModelData", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub tdgMatrix1_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdgMatrix1.Change
            Dim item() As DataRow
            Dim items As DataRow
            Dim dt As New DataTable()
            Dim text As String
            Dim t As String = Me._keyPress.ToString
            Dim row As Integer
            Dim i As Integer
            Dim j As Integer
            Dim exp As String
            Dim index As String
            Dim ch As Char

            Try
                dt = Me._dtAllModels.Copy
                row = Me.tdgMatrix1.Row
                't = Me.tdgMatrix1.Columns("Model").Text
                exp = "Model_Desc NOT LIKE '" & t & "%'"
                item = dt.Select(exp)

                For Each items In item
                    dt.Rows.Remove(items)
                Next

                With Me.cmbModels
                    .DataSource = dt.DefaultView
                    .DisplayMember = "Model_Desc"
                    .ValueMember = "Model_ID"
                    '.SelectedIndex = 0
                End With

                Me.cmbModels.Refresh()

                'cmbModels.SelectedIndex = 0
                'index = Me.cmbModels.Text.ToString
                'i = t.Length
                'j = index.Length - i

                'If j > 0 And index.Length > 0 And i > 0 Then

                'text = t & index.Substring(i, j)
                'Me.tdgMatrix1.SelectedText = text


                'Me.tdgMatrix1.SelectedText = index.Substring(i, j)
                'Me.tdgMatrix1.Focus()
                'Me.tdgMatrix1.MarqueeStyle = Me.tdgMatrix1.MarqueeStyle.HighlightCell
                'Me.tdgMatrix1.HighLightRowStyle.ForeColor = Color.White
                'Me.tdgMatrix1.HighLightRowStyle.BackColor = Color.Blue

                'Next


                'Me.tdgMatrix1.MarqueeStyle.HighlightCell()



                'MsgBox(text)

                'Me.cmbModels.SelectedIndex(1).

                'Me.tdgMatrix1.Columns("Model").Text = Me.cmbModels.Items(0).ToString
                'Me.tdgMatrix1.MarqueeStyle.HighlightCell()
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "tdgMatrix1_Change", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub TabControl1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TabControl1.KeyPress
            If TabControl1.SelectedTab.Text = "Pick Location Setup" Then
                Me._keyPress = e.KeyChar.ToString
            End If
        End Sub

        '*****************************************************************************
        Private Sub btnUpdateMatrix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Dim row As Integer = 0
            Dim model As String = ""
            Dim modelid As Integer = 0
            Dim matrix As String = ""
            Dim model_ID() As DataRow
            Dim exp As String
            Dim cell As String
            Dim i As Integer = 0
            Dim boolUpdate As Boolean = False

            Try

                For row = 0 To tdgMatrix1.Splits(0).Rows.Count - 1
                    cell = tdgMatrix1(row, "Model").ToString

                    If cell.Length > 0 Then
                        model = tdgMatrix1(row, "Model")
                    End If

                    matrix = tdgMatrix1(row, "Pick Location")
                    exp = "Model_Desc = '" & model & "'"
                    model_ID = Me._dtAllModels.Select(exp)
                    If model_ID.Length = 1 Then
                        'MessageBox.Show(model_ID(0)(0).ToString)
                        modelid = Convert.ToInt32(model_ID(0)(0))
                    End If

                    Me._dtMatrix.Rows(row).Item("Model") = model
                    Me._dtMatrix.Rows(row).Item("Model_ID") = modelid

                    'update matrix
                    i = Me._objAdmin.updatePickLocationMatrix(matrix.ToString, modelid)
                    If i > 0 Then
                        boolUpdate = True
                        cell = "" : model = "" : matrix = "" : exp = "" : model_ID = Nothing : modelid = 0 : i = 0
                    Else
                        MessageBox.Show("Model " & model & ":  Update failed. Contact IT.", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                Next

                If boolUpdate = True Then
                    MessageBox.Show("Pick location matrix updated succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdateMatrix_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

            Dim strDeleteLocation As String
            Dim i As Integer = 0
            Dim boolUpdate As Boolean = False

            Try

                For i = 0 To tdgMatrix1.RowCount - 1
                    'if tdgMatrix1.SelectedRows(
                    strDeleteLocation = tdgMatrix1(i, "Pick Location")
                Next

                If MsgBox("Are you sure you wish to delete location: " & strDeleteLocation & "?", MsgBoxStyle.YesNo) = vbYes Then
                    'Me._objAdmin.deletePickLocationMatrix(strDeleteLocation)
                    MsgBox(strDeleteLocation & " deleted.")

                    LoadPickLocations()

                End If

                If boolUpdate = True Then
                    MessageBox.Show("Pick location matrix updated succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdateMatrix_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*****************************************************************************
#End Region

#Region "Add Model"

        'scan the combobox for duplicate entries and remove them




        Private Sub C1Class_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1Class.SelectedValueChanged
            Dim dt As DataTable
            C1SubClass.SelectedIndex = -1
            C1SubClass.ClearItems()
            Try
                If C1Class.SelectedText = "PH" Then
                    dt = Me._objAdmin.GetSubClassDcodeId(Me._dtClass.Rows(C1Class.SelectedIndex).Item("dcode_id"))
                    _dtSubClass = dt
                    dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                    C1SubClass.ClearItems()
                    Misc.PopulateC1DropDownList(C1SubClass, _dtSubClass, "Dcode_Sdesc", "Dcode_id")


                ElseIf C1Class.SelectedText = "CC" Then
                    dt = Me._objAdmin.GetSubClassDcodeId(Me._dtClass.Rows(C1Class.SelectedIndex).Item("dcode_id"))
                    _dtSubClass = dt
                    dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                    C1SubClass.ClearItems()
                    Misc.PopulateC1DropDownList(C1SubClass, _dtSubClass, "Dcode_Sdesc", "Dcode_id")
                ElseIf C1Class.SelectedText = "RC" Then
                    dt = Me._objAdmin.GetSubClassDcodeId(Me._dtClass.Rows(C1Class.SelectedIndex).Item("dcode_id"))
                    _dtSubClass = dt
                    dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                    C1SubClass.ClearItems()
                    Misc.PopulateC1DropDownList(C1SubClass, _dtSubClass, "Dcode_Sdesc", "Dcode_id")
                ElseIf C1Class.SelectedText = "RM" Then
                    dt = Me._objAdmin.GetSubClassDcodeId(Me._dtClass.Rows(C1Class.SelectedIndex).Item("dcode_id"))
                    _dtSubClass = dt
                    dt.LoadDataRow(New Object() {"0", "--Select--"}, True)
                    C1SubClass.ClearItems()
                    Misc.PopulateC1DropDownList(C1SubClass, _dtSubClass, "Dcode_Sdesc", "Dcode_id")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ModelMgt_Tab", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub




        'Name of the button is chaged according to the change of radio buttons on top
        Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

            If RadioButton1.Checked = True Then
                btnModel.Text = "Add Model"
                GroupBox2.Visible = False
                GroupBox1.Visible = True
                C1CmbModelDesc.Text = ""
            End If

        End Sub


        Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
            If RadioButton3.Checked = True Then
                btnModel.Text = "Edit Model"
            End If
        End Sub



        Private Sub btnModel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnModel.Click

            Dim iDataSet_Id As Integer = 2
            Dim datetime As DateTime = datetime.Now
            Dim dt As DataTable
            Dim dt1 As DataTable
            Dim objUPC As New frmTFFK_NEW_UPC()
            Dim productId As Integer = 2
            Dim MCodeId As Integer = 84
            Dim id As Integer
            Dim i As Integer
            Try

                If RadioButton1.Checked = True Then
                    ' Add the new Model
                    If txtWeight.Text <> "" Or txtHeight.Text <> "" Or txtWidth.Text <> "" Or txtLength.Text <> "" Or txtModDesc.Text <> "" Or txtModLongDesc.Text <> "" Or txtUpcCodeID.Text <> "" Or C1CmbTechDcodeId.SelectedIndex = -1 Then
                        dt = Me._objAdmin.GetUPC_DCODE_ID((txtUpcCodeID.Text))
                        If dt.Rows.Count = 0 Then
                            '        'if upc code id doesn't exist he has to create a new code for the item
                            'objUPC.Show()
                            'Dim answer As String = InputBox("Insert New UPC code ", "New UPC", txtUpcCodeID.Text)

                            If txtUpcCodeID.Text <> String.Empty Then


                                Dim str As String = "'" & txtUpcCodeID.Text & "','" & txtUpcCodeID.Text & "','" & productId & "','" & MCodeId & "','" & _UserID & "','" & datetime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "'"

                                id = Me._objAdmin.saveUPCDetaill(str)
                                'txtUpcCodeID.Text = id

                            End If

                        Else
                            '            'After everything is set it should be saved to the production.tmodel_items
                            'Model_Desc,Model_LDesc,Prod_ID,Class_DCode_Id,SubClass_Dcode_Id,Tech_DCode_Id,Weight,Height,Width,Length,UPC_DCode_Id,User_Id,IdataSet_Id
                            Dim str As String = "'" & txtModDesc.Text & "','" & txtModLongDesc.Text & "','" & productId & "','" & Me._dtClass.Rows(C1Class.SelectedIndex).Item("dcode_id") & "','" & Me._dtClass.Rows(C1SubClass.SelectedIndex).Item("dcode_id") & "','" & Me._dtTech.Rows(C1CmbTechDcodeId.SelectedIndex).Item("dcode_id") & "','" & txtWeight.Text & "','" & txtHeight.Text & "','" & txtWidth.Text & "','" & txtLength.Text & "','" & id & "','" & _UserID & "','" & datetime.Now.ToString("yyyy-MM-dd HH:mm:ss") & "','" & iDataSet_Id & "'"

                            Dim check As Integer = Me._objAdmin.saveNewModel(str)
                            If check <> 0 Then
                                MsgBox("Model Inserted Successfully", MsgBoxStyle.Information)
                                clearModelManagenemt()
                            End If
                            '        End If
                            '    End If
                        End If
                    Else
                        MsgBox("Fill all the boxes first", MsgBoxStyle.Information)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
        End Sub


        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            clearModelManagenemt()
        End Sub

        'Clear the form after saving successfully




        Private Sub txtWeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWeight.TextChanged
            Dim check As Boolean = IsInputNumeric(txtWeight.Text)
            If check <> True Then
                removeAndSelect(txtWeight)
            End If
        End Sub
        Private Sub txtHeight_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHeight.TextChanged
            Dim check As Boolean = IsInputNumeric(txtHeight.Text)
            If check <> True Then
                removeAndSelect(txtHeight)
            End If
        End Sub
        Private Sub txtWidth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWidth.TextChanged
            Dim check As Boolean = IsInputNumeric(txtWidth.Text)
            If check <> True Then
                removeAndSelect(txtWidth)
            End If
        End Sub
        Private Sub txtLength_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLength.TextChanged
            Dim check As Boolean = IsInputNumeric(txtLength.Text)
            If check <> True Then
                removeAndSelect(txtLength)
            End If
        End Sub
        'Private Sub C1CmbTechDcodeId_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1CmbTechDcodeId.SelectedValueChanged
        '    Dim dt As DataTable
        '    Dim rows As DataRow
        '    Dim cols As DataColumn
        '    txtSubClassDcode.Text = ""
        '    Dim i As Integer = 0
        '    Try
        '        If C1CmbTechDcodeId.SelectedText = "PH" Then

        '            dt = Me._objAdmin.GetSubClassDcodeId(Me._dtClass.Rows(C1CmbTechDcodeId.SelectedIndex).Item("dcode_id"))
        '            _dtSubClass = dt
        '            For Each rows In dt.Rows
        '                i = 0
        '                For Each cols In dt.Columns

        '                    If i = 0 Then
        '                        txtSubClassDcode.Text = rows(cols)
        '                    End If
        '                    i += 1
        '                Next
        '            Next

        '        ElseIf C1CmbTechDcodeId.SelectedText = "CC" Then

        '            dt = Me._objAdmin.GetSubClassDcodeId(Me._dtClass.Rows(C1CmbTechDcodeId.SelectedIndex).Item("dcode_id"))
        '            _dtSubClass = dt
        '            For Each rows In dt.Rows
        '                i = 0
        '                For Each cols In dt.Columns
        '                    If i <> 0 Then
        '                        txtSubClassDcode.Text = rows(cols)
        '                    End If
        '                    i += 1
        '                Next
        '            Next
        '        ElseIf C1CmbTechDcodeId.SelectedText = "RM" Then
        '        End If
        '    Catch ex As Exception
        '        MsgBox(ex.Message.ToString)
        '    End Try
        'End Sub
        Private Sub txtUpcCodeID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUpcCodeID.TextChanged

        End Sub

        'Function that checks whether you entered decimal value or not

        Private Function IsInputNumeric(ByVal input As String) As Boolean
            Try
                input = input.Trim
                If IsNumeric(input) Then Return True
                Dim parts() As String = input.Split("/"c)
                If parts.Length <> 2 Then Return False
                Return IsNumeric(parts(0)) AndAlso IsNumeric(parts(1))
            Catch ex As Exception

            End Try
        End Function
        Private Sub removeAndSelect(ByRef txt As TextBox)
            Try
                txt.Text = txt.Text.Remove(txt.Text.Length - 1, 1)
                txt.Select(txt.Text.Length, 0)
            Catch ex As Exception

            End Try
        End Sub

#End Region


#Region "Functions"
        Private Sub clearModelManagenemt()
            txtHeight.Text = String.Empty
            txtWidth.Text = String.Empty
            txtWeight.Text = String.Empty
            txtLength.Text = String.Empty
            'txtSubClassDcode.Text = String.Empty
            txtUpcCodeID.Text = String.Empty
            txtModDesc.Text = String.Empty
            txtModLongDesc.Text = String.Empty
            C1Class.SelectedIndex = -1
            C1SubClass.SelectedIndex = -1
            C1CmbTechDcodeId.SelectedIndex = -1
        End Sub

        Private Sub hideOrVisible(ByVal bol As Boolean)
            GroupBox1.Visible = bol
            GroupBox2.Visible = Not bol
        End Sub
#End Region










        Private Sub TabPage4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage4.Click

        End Sub

        Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
            Try
                With Me.tdgData1
                    .DataSource = Nothing
                End With
                Dim dtime As DateTime = Convert.ToDateTime(DateTimePicker1.Text)

                Me.getWareHouseBox(dtime)
            Catch ex As Exception

            End Try
        End Sub


        Private Sub btnCpySelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCpySelected.Click
            Dim strS As String = ""
            Dim strRes As String = ""
            Dim row As Integer
            Dim col As DataColumn
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim strSeparater As String = ";"
            Try


                For Each col In Me._dtAllBoxes.Columns
                    If strS.Trim.Length = 0 Then
                        strS = col.ColumnName
                    Else
                        strS &= strSeparater & col.ColumnName
                    End If
                Next
                strRes = strS & Environment.NewLine 'Header
                strS = ""

                For Each row In Me.tdgData1.SelectedRows
                    strS = ""

                    For j = 0 To Me.tdgData1.Columns.Count - 1
                        If strS.Trim.Length = 0 Then
                            strS = Me.tdgData1.Columns(j).CellValue(row)
                        Else

                            strS &= strSeparater & Me.tdgData1.Columns(j).CellValue(row)
                        End If
                    Next
                    strRes &= strS & Environment.NewLine
                Next


                'strRes &= strS & Environment.NewLine

                System.Windows.Forms.Clipboard.SetDataObject(strRes, False)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
            Dim strS As String = ""
            Dim strRes As String = ""
            Dim row As DataRow
            Dim col As DataColumn
            Dim i As Integer = 0
            Dim j As Integer = 0
            Dim strSeparater As String = ";"
            Try
                For Each col In Me._dtAllBoxes.Columns
                    If strS.Trim.Length = 0 Then
                        strS = col.ColumnName
                    Else
                        strS &= strSeparater & col.ColumnName
                    End If
                Next
                strRes = strS & Environment.NewLine 'Header
                strS = ""
                For i = 0 To Me._dtAllBoxes.Rows.Count - 1
                    strS = ""

                    For j = 0 To Me._dtAllBoxes.Columns.Count - 1
                        If strS.Trim.Length = 0 Then
                            strS = Me._dtAllBoxes.Rows(i).Item(j)
                        Else
                            strS &= strSeparater & Me._dtAllBoxes.Rows(i).Item(j)
                        End If
                    Next
                    strRes &= strS & Environment.NewLine
                Next
                System.Windows.Forms.Clipboard.SetDataObject(strRes, False)
            Catch ex As Exception

            End Try


        End Sub

        Private Sub tdgCompOrders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdgCompOrders.Click

        End Sub

        Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
            Me._dtCompOrders = Me._objAdmin.GetTFFKCompletedOrders(Convert.ToDateTime(DateTimePicker2.Text))
            Me.BindCompOrders()
        End Sub

        Private Sub C1tdgViewModels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1tdgViewModels.Click

        End Sub
    End Class
End Namespace
