Option Explicit On 

Imports PSS.Data.Buisness
Imports System.IO
Imports System.Text

Namespace Gui
    Public Class frmFacilityLocationManagement
        Inherits System.Windows.Forms.Form
        Private _iMenuCustID As Integer
        Private _objFacilityLocMgmt As PSS.Data.Buisness.FacilityLocationManagement
        Private _dFolder As String = "P:\Dept\FacilityLocationManagement"
        Private _strSourceFileName As String = ""
        Private _strCustLocTableName As String = ""
        Private _strCustLocTableNameRequiredColumnName As String = "Location"

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCustID
            Me._objFacilityLocMgmt = New PSS.Data.Buisness.FacilityLocationManagement()
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
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents cboLocationType As C1.Win.C1List.C1Combo
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblLocationType As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnCopySelectedRows2 As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll2 As System.Windows.Forms.Button
        Friend WithEvents lblRecNo1 As System.Windows.Forms.Label
        Friend WithEvents txtSourceFile As System.Windows.Forms.TextBox
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnSaveData As System.Windows.Forms.Button
        Friend WithEvents btnGetExcelData As System.Windows.Forms.Button
        Friend WithEvents btnBroswerFile As System.Windows.Forms.Button
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents lblRec2 As System.Windows.Forms.Label
        Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnActiveDeactive As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFacilityLocationManagement))
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.lblRec2 = New System.Windows.Forms.Label()
            Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnCopySelectedRows2 = New System.Windows.Forms.Button()
            Me.btnCopyAll2 = New System.Windows.Forms.Button()
            Me.lblRecNo1 = New System.Windows.Forms.Label()
            Me.txtSourceFile = New System.Windows.Forms.TextBox()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnSaveData = New System.Windows.Forms.Button()
            Me.btnGetExcelData = New System.Windows.Forms.Button()
            Me.btnBroswerFile = New System.Windows.Forms.Button()
            Me.lblLocationType = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboLocationType = New C1.Win.C1List.C1Combo()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.btnActiveDeactive = New System.Windows.Forms.Button()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocationType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(856, 600)
            Me.TabControl1.TabIndex = 1
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.Lavender
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnActiveDeactive, Me.Panel2, Me.Panel1, Me.lblLocationType, Me.lblCustomer, Me.cboLocationType, Me.cboCustomer, Me.btnRefresh})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(848, 574)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Upload or View Location Data"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Gainsboro
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelectedRows, Me.btnCopyAll, Me.lblRec2, Me.tdgData2})
            Me.Panel2.Location = New System.Drawing.Point(8, 136)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(248, 432)
            Me.Panel2.TabIndex = 102
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.BackColor = System.Drawing.Color.LightGray
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.DarkCyan
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(112, 0)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(128, 23)
            Me.btnCopySelectedRows.TabIndex = 103
            Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.LightGray
            Me.btnCopyAll.Font = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.DarkCyan
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(80, 23)
            Me.btnCopyAll.TabIndex = 102
            Me.btnCopyAll.Text = "Copy All Rows"
            '
            'lblRec2
            '
            Me.lblRec2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRec2.Location = New System.Drawing.Point(8, 408)
            Me.lblRec2.Name = "lblRec2"
            Me.lblRec2.Size = New System.Drawing.Size(136, 16)
            Me.lblRec2.TabIndex = 100
            '
            'tdgData2
            '
            Me.tdgData2.AllowUpdate = False
            Me.tdgData2.AlternatingRows = True
            Me.tdgData2.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData2.FetchRowStyles = True
            Me.tdgData2.FilterBar = True
            Me.tdgData2.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData2.Location = New System.Drawing.Point(8, 24)
            Me.tdgData2.Name = "tdgData2"
            Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData2.PreviewInfo.ZoomFactor = 75
            Me.tdgData2.Size = New System.Drawing.Size(232, 384)
            Me.tdgData2.TabIndex = 99
            Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised," & _
            ",1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Mar" & _
            "queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>382</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 230, 382</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 230, 382</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelectedRows2, Me.btnCopyAll2, Me.lblRecNo1, Me.txtSourceFile, Me.tdgData1, Me.btnSaveData, Me.btnGetExcelData, Me.btnBroswerFile})
            Me.Panel1.Location = New System.Drawing.Point(264, 8)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(576, 560)
            Me.Panel1.TabIndex = 101
            '
            'btnCopySelectedRows2
            '
            Me.btnCopySelectedRows2.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopySelectedRows2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows2.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopySelectedRows2.Location = New System.Drawing.Point(448, 8)
            Me.btnCopySelectedRows2.Name = "btnCopySelectedRows2"
            Me.btnCopySelectedRows2.Size = New System.Drawing.Size(128, 23)
            Me.btnCopySelectedRows2.TabIndex = 104
            Me.btnCopySelectedRows2.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll2
            '
            Me.btnCopyAll2.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyAll2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll2.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopyAll2.Location = New System.Drawing.Point(336, 8)
            Me.btnCopyAll2.Name = "btnCopyAll2"
            Me.btnCopyAll2.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll2.TabIndex = 103
            Me.btnCopyAll2.Text = "Copy All Rows"
            '
            'lblRecNo1
            '
            Me.lblRecNo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNo1.Location = New System.Drawing.Point(24, 544)
            Me.lblRecNo1.Name = "lblRecNo1"
            Me.lblRecNo1.Size = New System.Drawing.Size(152, 16)
            Me.lblRecNo1.TabIndex = 102
            '
            'txtSourceFile
            '
            Me.txtSourceFile.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtSourceFile.ForeColor = System.Drawing.Color.MediumBlue
            Me.txtSourceFile.Location = New System.Drawing.Point(16, 40)
            Me.txtSourceFile.Name = "txtSourceFile"
            Me.txtSourceFile.ReadOnly = True
            Me.txtSourceFile.Size = New System.Drawing.Size(544, 13)
            Me.txtSourceFile.TabIndex = 101
            Me.txtSourceFile.Text = ""
            '
            'tdgData1
            '
            Me.tdgData1.AllowUpdate = False
            Me.tdgData1.AlternatingRows = True
            Me.tdgData1.BackColor = System.Drawing.Color.GhostWhite
            Me.tdgData1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgData1.FetchRowStyles = True
            Me.tdgData1.FilterBar = True
            Me.tdgData1.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(16, 56)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.Size = New System.Drawing.Size(544, 488)
            Me.tdgData1.TabIndex = 100
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised," & _
            ",1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
            "Grid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" Mar" & _
            "queeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertic" & _
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>486</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 542, 486</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 542, 486</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnSaveData
            '
            Me.btnSaveData.BackColor = System.Drawing.SystemColors.Control
            Me.btnSaveData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveData.ForeColor = System.Drawing.Color.Blue
            Me.btnSaveData.Image = CType(resources.GetObject("btnSaveData.Image"), System.Drawing.Bitmap)
            Me.btnSaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnSaveData.Location = New System.Drawing.Point(224, 8)
            Me.btnSaveData.Name = "btnSaveData"
            Me.btnSaveData.Size = New System.Drawing.Size(82, 24)
            Me.btnSaveData.TabIndex = 99
            Me.btnSaveData.Text = "Save Data   "
            Me.btnSaveData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnGetExcelData
            '
            Me.btnGetExcelData.BackColor = System.Drawing.SystemColors.Control
            Me.btnGetExcelData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetExcelData.ForeColor = System.Drawing.Color.Blue
            Me.btnGetExcelData.Image = CType(resources.GetObject("btnGetExcelData.Image"), System.Drawing.Bitmap)
            Me.btnGetExcelData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnGetExcelData.Location = New System.Drawing.Point(120, 8)
            Me.btnGetExcelData.Name = "btnGetExcelData"
            Me.btnGetExcelData.Size = New System.Drawing.Size(98, 24)
            Me.btnGetExcelData.TabIndex = 98
            Me.btnGetExcelData.Text = "Get Data   "
            Me.btnGetExcelData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnBroswerFile
            '
            Me.btnBroswerFile.BackColor = System.Drawing.SystemColors.Control
            Me.btnBroswerFile.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBroswerFile.ForeColor = System.Drawing.Color.Blue
            Me.btnBroswerFile.Image = CType(resources.GetObject("btnBroswerFile.Image"), System.Drawing.Bitmap)
            Me.btnBroswerFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnBroswerFile.Location = New System.Drawing.Point(16, 8)
            Me.btnBroswerFile.Name = "btnBroswerFile"
            Me.btnBroswerFile.Size = New System.Drawing.Size(98, 24)
            Me.btnBroswerFile.TabIndex = 97
            Me.btnBroswerFile.Text = "Find File     "
            Me.btnBroswerFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLocationType
            '
            Me.lblLocationType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocationType.Location = New System.Drawing.Point(8, 56)
            Me.lblLocationType.Name = "lblLocationType"
            Me.lblLocationType.Size = New System.Drawing.Size(128, 16)
            Me.lblLocationType.TabIndex = 100
            Me.lblLocationType.Text = "Location Type:"
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(8, 8)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(96, 16)
            Me.lblCustomer.TabIndex = 99
            Me.lblCustomer.Text = "Customer:"
            '
            'cboLocationType
            '
            Me.cboLocationType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocationType.AutoCompletion = True
            Me.cboLocationType.AutoDropDown = True
            Me.cboLocationType.AutoSelect = True
            Me.cboLocationType.Caption = ""
            Me.cboLocationType.CaptionHeight = 17
            Me.cboLocationType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocationType.ColumnCaptionHeight = 17
            Me.cboLocationType.ColumnFooterHeight = 17
            Me.cboLocationType.ColumnHeaders = False
            Me.cboLocationType.ContentHeight = 15
            Me.cboLocationType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocationType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocationType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocationType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocationType.EditorHeight = 15
            Me.cboLocationType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocationType.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboLocationType.ItemHeight = 15
            Me.cboLocationType.Location = New System.Drawing.Point(8, 72)
            Me.cboLocationType.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocationType.MaxDropDownItems = CType(10, Short)
            Me.cboLocationType.MaxLength = 32767
            Me.cboLocationType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocationType.Name = "cboLocationType"
            Me.cboLocationType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocationType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocationType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocationType.Size = New System.Drawing.Size(224, 21)
            Me.cboLocationType.TabIndex = 98
            Me.cboLocationType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(8, 24)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(224, 21)
            Me.cboCustomer.TabIndex = 97
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnRefresh
            '
            Me.btnRefresh.BackColor = System.Drawing.Color.DarkGray
            Me.btnRefresh.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.Blue
            Me.btnRefresh.Location = New System.Drawing.Point(8, 104)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(120, 24)
            Me.btnRefresh.TabIndex = 101
            Me.btnRefresh.Text = "View Existing  Data"
            '
            'btnActiveDeactive
            '
            Me.btnActiveDeactive.BackColor = System.Drawing.Color.DarkGray
            Me.btnActiveDeactive.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnActiveDeactive.ForeColor = System.Drawing.Color.Red
            Me.btnActiveDeactive.Location = New System.Drawing.Point(136, 104)
            Me.btnActiveDeactive.Name = "btnActiveDeactive"
            Me.btnActiveDeactive.Size = New System.Drawing.Size(120, 24)
            Me.btnActiveDeactive.TabIndex = 103
            Me.btnActiveDeactive.Text = "Activate/Deactivate"
            Me.ToolTip1.SetToolTip(Me.btnActiveDeactive, "Activate or deactivate the selected rows")
            '
            'frmFacilityLocationManagement
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(872, 614)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmFacilityLocationManagement"
            Me.Text = "frmFacilityLocationManagement"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocationType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
        '******************************************************************
        Private Sub frmFacilityLocationManagement_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            PSS.Core.Highlight.SetHighLight(Me)
            Me.Panel1.Visible = False

            'Load customer
            dt = Me._objFacilityLocMgmt.GetCustomer(_iMenuCustID)
            If dt.Rows.Count > 0 Then
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_name1", "cust_ID")
                Me.cboCustomer.SelectedValue = Me._iMenuCustID
                Me.cboCustomer.Enabled = False
            Else
                MessageBox.Show("No customer!") : Exit Sub
            End If

            'Load Type
            dt = Me._objFacilityLocMgmt.GetFacilityLocationType
            If dt.Rows.Count > 0 Then
                Misc.PopulateC1DropDownList(Me.cboLocationType, dt, "Loc_Type_Desc", "Loc_Type_ID")
                Me.cboCustomer.SelectedIndex = 0
            Else
                MessageBox.Show("No Facility Location!") : Exit Sub
            End If

        End Sub

        '******************************************************************
        Private Sub cboLocationType_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocationType.SelectedValueChanged
            Dim dt As DataTable

            Try
                Me.Panel1.Visible = False : Me.Panel2.Visible = False : Me.btnRefresh.Enabled = False
                Me._strCustLocTableName = "" : Me.btnActiveDeactive.Enabled = False

                If Me._iMenuCustID > 0 AndAlso Me.cboLocationType.SelectedValue > 0 Then
                    dt = Me._objFacilityLocMgmt.GetFacilityLocationCustomerTypeMap(Me._iMenuCustID, Me.cboLocationType.SelectedValue)
                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show("No location tablename is defined for '" & _
                                         Me.cboLocationType.Text & "', '" & Me.cboCustomer.Text & _
                                         "' (Table: lFacilityLocationMap)!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count = 1 Then 'OK
                        Me.Panel1.Visible = True : Me.Panel2.Visible = True : Me.btnRefresh.Enabled = True
                        Me._strCustLocTableName = dt.Rows(0).Item("TableName") : Me.btnActiveDeactive.Enabled = True
                    Else
                        MessageBox.Show("More than 1 tablename are defined for '" & _
                                         Me.cboLocationType.Text & "', '" & Me.cboCustomer.Text & _
                                         "' (Table: lFacilityLocationMap)!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    Me.btnBroswerFile.Enabled = True
                    Me.tdgData1.DataSource = Nothing
                    Me.btnGetExcelData.Enabled = False
                    Me.btnSaveData.Enabled = False
                    Me.btnCopyAll2.Enabled = False
                    Me.btnCopySelectedRows2.Enabled = False
                    Me.lblRecNo1.Text = ""
                    Me.txtSourceFile.Text = ""
                    Me._strSourceFileName = ""
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub cboLocationType_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnBroswerFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBroswerFile.Click

            Dim strFileName As String = ""
            Dim _objDriveLine As PSS.Data.Buisness.DriveLine
            Dim dt As DataTable
            Dim strS As String = "", i As Integer
            Dim tmpArr As New ArrayList(), ArrRecIDs As New ArrayList()

            Try
                Me.tdgData1.Visible = False : Me.tdgData1.DataSource = Nothing
                Me.lblRecNo1.Visible = False


                If Directory.Exists(Me._dFolder) Then
                    Me.OpenFileDialog1.InitialDirectory = Me._dFolder
                Else
                    Me.OpenFileDialog1.InitialDirectory = System.Environment.CurrentDirectory
                End If

                Me.OpenFileDialog1.Filter = "Excel Files (*.xls; *.xlsx)|*.xls;*.xlsx"

                If (Me.OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
                    strFileName = Me.OpenFileDialog1.FileName
                    Me.txtSourceFile.Text = strFileName
                    Me._strSourceFileName = Path.GetFileName(strFileName)
                    Me.btnGetExcelData.Enabled = True
                    Me.btnSaveData.Enabled = False
                    Me.ToolTip1.SetToolTip(Me.btnGetExcelData, "Load Data from Excel File: " & strFileName)
                Else
                    MsgBox("You did not select a file!")
                    Me.btnGetExcelData.Enabled = False
                    Me.btnSaveData.Enabled = False
                    Me.txtSourceFile.Text = ""
                    Me._strSourceFileName = ""
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnBroswerFile_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.btnGetExcelData.Enabled = False
                Me.btnSaveData.Enabled = False
            End Try
        End Sub

        '******************************************************************
        Private Sub btnGetExcelData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetExcelData.Click
            Dim strFileName As String = ""
            Dim _objSkullcandy2 As PSS.Data.Buisness.Skullcandy2
            Dim dt As DataTable
            Dim strS As String = "", i As Integer, iRowID As Integer, j As Integer, maxL As Integer = 0
            Dim tmpArr As New ArrayList(), ArrRecIDs As New ArrayList()
            Dim strErrMsg As String = ""
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iInvalidCount As Integer = 0

            Try
                Cursor = Cursors.WaitCursor
                Me.tdgData1.Visible = False : Me.tdgData1.DataSource = Nothing
                Me.lblRecNo1.Text = ""
                Me.btnSaveData.Enabled = False

                strFileName = Me.txtSourceFile.Text

                If File.Exists(strFileName) Then
                    'get data
                    dt = Me._objFacilityLocMgmt.LoadExcelData_FastWay(strFileName, strDateTime, strErrMsg) 'fast way

                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg)
                    ElseIf Not dt.Rows.Count > 0 Then
                        MessageBox.Show("No enough data tables!")
                    Else
                        'Validate
                        RemovedBeginAndEndSpacesAndReplaceSingleQuotation(dt)
                        Dim dtResult As DataTable = ResultDataAfterValidations(dt)

                        'Bind final data
                        Me.tdgData1.DataSource = dtResult
                        Me.lblRecNo1.Text = "Total Records: " & dt.Rows.Count
                        Me.tdgData1.Visible = True : Me.lblRecNo1.Visible = True

                        'set width
                        Me.tdgData1.Splits(0).DisplayColumns("RowID").Width = 40
                        Me.tdgData1.Splits(0).DisplayColumns("LocationName").Width = 80
                        Me.tdgData1.Splits(0).DisplayColumns("Status").Width = 100
                        Me.tdgData1.Splits(0).DisplayColumns("UpdateDatetime").Width = 120

                        'set alignment
                        Me.tdgData1.Splits(0).DisplayColumns("LocationName").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                        'Check total invalid count
                        iInvalidCount = dtResult.Compute("COUNT(Status)", "Status='" & _objSkullcandy2.strInvalid & "'")
                        If iInvalidCount > 0 Then
                            MessageBox.Show(iInvalidCount.ToString & " rows have invalid data (either nulls or duplicate LocationName)." & Environment.NewLine & _
                                            "These invalid rows will be skipped when to save data.")
                        End If

                        Me.btnSaveData.Enabled = True : Me.btnCopyAll2.Enabled = True : Me.btnCopySelectedRows2.Enabled = True
                    End If
                Else
                    MessageBox.Show("Can't find file: " & strFileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Cursor = Cursors.Default
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnGetExcelData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
                _objSkullcandy2 = Nothing
                Cursor = Cursors.Default
            End Try

        End Sub

        '******************************************************************
        Private Sub RemovedBeginAndEndSpacesAndReplaceSingleQuotation(ByRef dt As DataTable)
            Dim row As DataRow
            Dim strS As String

            Try
                For Each row In dt.Rows
                    If Not row.IsNull("LocationName") Then
                        strS = row("LocationName") : row("LocationName") = strS.Trim.Replace("'", "")
                    End If
                Next
                dt.AcceptChanges()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub RemovedPreAndTailSpaces", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Function ResultDataAfterValidations(ByVal dt As DataTable) As DataTable

            Dim row As DataRow
            Dim filteredRows() As DataRow
            Dim i As Integer = 0, j As Integer = 0
            Dim strTemp As String = ""
            Dim idx As Integer = 0
            Dim bFound As Boolean = False
            Dim iInvalidCount As Integer = 0

            Dim arrUniqueLocationNames As New ArrayList()
            Dim arrInvalidDeplicateRowRecIdxs As New ArrayList()

            Try
                ' Cursor = Cursors.WaitCursor
                Me.btnSaveData.Enabled = False


                'Find rows which have null 
                i = 0
                For Each row In dt.Rows
                    bFound = False : strTemp = ""
                    For j = 0 To dt.Columns.Count - 1
                        If row.IsNull(j) Then
                            idx = i : bFound = True : Exit For 'j
                        Else
                            strTemp = row(j)
                            If Not strTemp.Trim.Length > 0 Then
                                idx = i : bFound = True : Exit For 'j
                            End If
                        End If
                    Next
                    i += 1
                    If bFound Then
                        'Me.tdgData1.SelectedRows.Add(idx) 'select row
                        row("Status") = PSS.Data.Buisness.Skullcandy2.strInvalid
                    End If
                    If Not row.IsNull("LocationName") Then
                        strTemp = row("LocationName")
                        row("LocationName") = strTemp.Trim 'reset after trimming pre-space and tail-space
                        dt.AcceptChanges()
                    End If
                Next

                'Check unique LocationName (as primary key)
                For Each row In dt.Rows 'get unique LocationName
                    If Not row.IsNull("LocationName") Then
                        strTemp = row("LocationName")
                        If Not arrUniqueLocationNames.Contains(strTemp.Trim) Then
                            arrUniqueLocationNames.Add(strTemp)
                        End If
                    End If
                Next
                For i = 0 To arrUniqueLocationNames.Count - 1
                    strTemp = arrUniqueLocationNames(i)
                    filteredRows = dt.Select("LocationName='" & strTemp & "'")
                    If filteredRows.Length > 1 Then
                        For Each row In filteredRows
                            idx = row("RowID") - 1
                            arrInvalidDeplicateRowRecIdxs.Add(row("RowID"))
                            Me.tdgData1.SelectedRows.Add(idx) 'select row
                        Next
                    End If
                Next
                If arrInvalidDeplicateRowRecIdxs.Count > 0 Then
                    For Each row In dt.Rows 'flag invalid for dup 
                        If arrInvalidDeplicateRowRecIdxs.Contains(row("RowID")) Then
                            row("Status") = PSS.Data.Buisness.Skullcandy2.strInvalid
                        End If
                    Next
                End If
                dt.AcceptChanges()


                Return dt
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Function  ResultDataAfterValidations", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Function

        '******************************************************************
        Private Sub tdgData1_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgData1.FetchRowStyle
            Dim strStatus As String
            Try
                ' iDeviceID = CInt(Me.tdgData03.Columns("Device_ID").Text)
                'iInvalidID = CInt(Me.tdgData1.Columns("Status").CellText(e.Row))
                strStatus = Me.tdgData1.Columns("Status").CellText(e.Row)
                Select Case strStatus
                    Case PSS.Data.Buisness.Skullcandy2.strInserted
                        e.CellStyle.BackColor = Color.LightGreen
                    Case PSS.Data.Buisness.Skullcandy2.strUpdated
                        e.CellStyle.BackColor = Color.LightSteelBlue
                    Case PSS.Data.Buisness.Skullcandy2.strNoChange
                        e.CellStyle.BackColor = Color.White
                    Case PSS.Data.Buisness.Skullcandy2.strSQLFailed
                        e.CellStyle.BackColor = Color.Coral
                    Case PSS.Data.Buisness.Skullcandy2.strInvalid
                        e.CellStyle.BackColor = Color.Yellow
                        'Case Else
                        '       e.CellStyle.BackColor = Color.Pink
                End Select

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgData1_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnSaveData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveData.Click
            Dim dt, dtSQLResult As DataTable
            Dim row As DataRow
            Dim strMsg As String = ""
            Dim i As Integer = 0, iRowID As Integer = 0
            Dim iUserID As Integer

            Try
                Me.btnSaveData.Enabled = True

                iUserID = PSS.Core.ApplicationUser.IDuser
                dt = Me.tdgData1.DataSource

                'validate
                If Not dt.Rows.Count > 0 Then MessageBox.Show("No data to save.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                If Not Trim(Me.txtSourceFile.Text).Length > 0 Then MessageBox.Show("No file name.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                If Not Trim(Me._strCustLocTableName).Length > 0 Then
                    MessageBox.Show("No table name.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                Else
                    If Not Me._objFacilityLocMgmt.IsTableExist(Me._strCustLocTableName) Then
                        MessageBox.Show("Not a valid table name.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                    End If
                End If
                If Not Me.cboLocationType.SelectedValue > 0 Then MessageBox.Show("Not a valid Loc_Type_ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop) : Exit Sub
                If Not Me._objFacilityLocMgmt.IsColumnExist(Me._strCustLocTableName, Me._strCustLocTableNameRequiredColumnName) Then
                    MessageBox.Show("Can't find column '" & Me._strCustLocTableNameRequiredColumnName & "' in Table '" & Me._strCustLocTableName & "'.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Ready to save
                dtSQLResult = Me._objFacilityLocMgmt.SaveFacilityLocationData(Me._strCustLocTableName, Me._strCustLocTableNameRequiredColumnName, _
                                                dt, Me.txtSourceFile.Text, Me.cboLocationType.SelectedValue, Me._iMenuCustID, iUserID)

                'Update status
                For Each row In dtSQLResult.Rows
                    For i = 0 To dt.Rows.Count - 1
                        iRowID = dt.Rows(i).Item("RowID") 'Me.tdgData1.Columns("RowID").CellText(i)
                        If iRowID = row("RowID") Then
                            Me.tdgData1(i, 2) = row("Status") : Exit For
                        End If
                    Next
                Next

                Me.tdgData1.Refresh() : Me.lblRecNo1.Text = "Total Records: " & dt.Rows.Count

                Me.btnSaveData.Enabled = False

            Catch ex As Exception
                Me.btnSaveData.Enabled = True
                MessageBox.Show(ex.ToString, "Sub btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        '******************************************************************
        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            RefreshExistingData()
        End Sub

        '*********************************************************************************************************************
        Private Sub RefreshExistingData()
            Dim dt As DataTable
            ' MessageBox.Show(Me.cboCustomer.Text & "  " & Me.cboLocationType.Text & "  " & Me._strCustLocTableName)

            Try
                Me.lblRec2.Text = "" : Me.tdgData2.DataSource = Nothing

                If Trim(Me._strCustLocTableName).Length > 0 Then
                    If Me._objFacilityLocMgmt.IsTableExist(Me._strCustLocTableName) Then
                        If Me._objFacilityLocMgmt.IsColumnExist(Me._strCustLocTableName, Me._strCustLocTableNameRequiredColumnName) _
                           AndAlso Me._objFacilityLocMgmt.IsColumnExist(Me._strCustLocTableName, "Active") Then
                            dt = Me._objFacilityLocMgmt.GetLocatuionfData(Me._strCustLocTableName, Me._strCustLocTableNameRequiredColumnName)
                            Me.tdgData2.DataSource = dt
                            Me.tdgData2.Splits(0).DisplayColumns("Active").Width = 50
                            Me.lblRec2.Text = "Count: " & dt.Rows.Count
                        Else
                            MessageBox.Show("Can't find column '" & Me._strCustLocTableNameRequiredColumnName & "' in Table '" & Me._strCustLocTableName & "'.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    Else
                        MessageBox.Show("Table '" & Me._strCustLocTableName & "' does not exist.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                Else
                    MessageBox.Show("No valid table name.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RefreshExistingData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                   Handles btnCopyAll.Click, btnCopySelectedRows.Click, btnCopyAll2.Click, btnCopySelectedRows2.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If sender.name = "btnCopyAll" Then
                    Misc.CopyAllData(Me.tdgData2)
                ElseIf sender.name = "btnCopySelectedRows" Then
                    Misc.CopySelectedRowsData(Me.tdgData2)
                ElseIf sender.name = "btnCopyAll2" Then
                    Misc.CopyAllData(Me.tdgData1)
                ElseIf sender.name = "btnCopySelectedRows2" Then
                    Misc.CopySelectedRowsData(Me.tdgData1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '******************************************************************
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

        '******************************************************************
        Private Sub btnActiveDeactive_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnActiveDeactive.Click
            Dim arrListYesNo As New ArrayList()
            Dim arrListBeingUsed As New ArrayList()
            Dim arrListNotBeingUsed As New ArrayList()
            Dim iRow, i, j As Integer
            Dim strS As String = ""
            Dim strSelectedLocations As String = ""
            Dim objSkullcandy As Skullcandy
            Dim dt As DataTable

            Try
                If Me.tdgData2.SelectedRows.Count > 0 Then
                    For Each iRow In Me.tdgData2.SelectedRows
                        strS = Me.tdgData2.Columns(1).CellText(iRow)
                        If Not arrListYesNo.Contains(strS) Then arrListYesNo.Add(strS)
                    Next

                    If arrListYesNo.Count = 0 Then
                        MessageBox.Show("Can't determine if 'Yes' or 'No'.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf arrListYesNo.Count > 1 Then
                        MessageBox.Show("Selected rows have both 'Yes' and 'No'. You must select rows with either active 'Yes' or 'No'.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf arrListYesNo.Count = 1 Then

                        If Me._iMenuCustID = objSkullcandy.Retail_CUSTOMERID Then 'Skullcandy Retail
                            objSkullcandy = New Skullcandy()
                            For Each iRow In Me.tdgData2.SelectedRows 'Each selected row to check locaion being used
                                If objSkullcandy.IsLocationBeingUsed(Me.tdgData2.Columns(0).CellText(iRow).ToString) Then
                                    arrListBeingUsed.Add(Me.tdgData2.Columns(0).CellText(iRow).ToString)
                                Else
                                    arrListNotBeingUsed.Add(Me.tdgData2.Columns(0).CellText(iRow).ToString)
                                End If
                            Next 'Each selected row
                            objSkullcandy = Nothing

                            For i = 0 To arrListNotBeingUsed.Count - 1 'Each selected row
                                If i = 0 Then
                                    strSelectedLocations = "'" & arrListNotBeingUsed(i) & "'"
                                Else
                                    strSelectedLocations &= ",'" & arrListNotBeingUsed(i) & "'"
                                End If
                            Next 'Each selected row

                            If arrListBeingUsed.Count > 0 Then
                                Dim strTmp As String = ""
                                Dim strP As String = IIf(arrListBeingUsed.Count > 1, "s", "")
                                For j = 0 To arrListBeingUsed.Count - 1
                                    If j = 0 Then strTmp = "'" & arrListBeingUsed(j) & "'" Else strTmp &= ", '" & arrListBeingUsed(j) & "'"
                                Next
                                MessageBox.Show("Reminder: Can't reset the being-used location" & strP & ": " & strTmp & ", which will be skipped.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        Else
                            i = 0
                            For Each iRow In Me.tdgData2.SelectedRows 'Each selected row
                                If i = 0 Then
                                    strSelectedLocations = "'" & Me.tdgData2.Columns(0).CellText(iRow) & "'"
                                Else
                                    strSelectedLocations &= ",'" & Me.tdgData2.Columns(0).CellText(iRow) & "'"
                                End If
                                i += 1
                            Next 'Each selected row

                        End If

                        If strSelectedLocations.Trim.Length > 0 Then
                            strS = arrListYesNo(0) : i = 0
                            If strS.Trim.ToUpper = "YES" Then
                                i = Me._objFacilityLocMgmt.UpdateLocationData(Me._strCustLocTableName, Me._strCustLocTableNameRequiredColumnName, strSelectedLocations, True)
                                If Not i > 0 Then MessageBox.Show("Failed to update.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ElseIf strS.Trim.ToUpper = "NO" Then
                                i = Me._objFacilityLocMgmt.UpdateLocationData(Me._strCustLocTableName, Me._strCustLocTableNameRequiredColumnName, strSelectedLocations, False)
                                If Not i > 0 Then MessageBox.Show("Failed to update.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("Not defined!", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                            RefreshExistingData()
                        End If
                    End If
                Else
                    MessageBox.Show("Please select location row(s) to activate or deactivate.", "", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "btnActiveDeactive_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '******************************************************************



    End Class
End Namespace
