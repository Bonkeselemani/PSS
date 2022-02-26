Option Explicit On 

Imports PSS.Data.Buisness
Imports System.IO
Imports System.Text

Namespace Gui
    Public Class frmCustomerFreqCodeMap
        Inherits System.Windows.Forms.Form

        Private _dFolder As String = "P:\Dept\Messaging\FreqCodeMapData"
        Private _strSourceFileName As String = ""

        Private Const _strReadyToSave As String = "Ready to save"
        Private Const _strInvalid As String = "Invalid"
        Private Const _strExist As String = "Already exist"
        Private Const _strInserted As String = "Inserted"
        Private Const _strUpdated As String = "Updated"
        Private Const _strNoChange As String = "No change"
        Private Const _strSQLFailed As String = "SQL failed"

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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents btnCopySelectedRows2 As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll2 As System.Windows.Forms.Button
        Friend WithEvents lblRecNo1 As System.Windows.Forms.Label
        Friend WithEvents txtSourceFile As System.Windows.Forms.TextBox
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnConfirmData As System.Windows.Forms.Button
        Friend WithEvents btnSaveData As System.Windows.Forms.Button
        Friend WithEvents btnGetExcelData As System.Windows.Forms.Button
        Friend WithEvents btnBroswerFile As System.Windows.Forms.Button
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        Friend WithEvents lblRec2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents btnReset As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCustomerFreqCodeMap))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.btnCopySelectedRows2 = New System.Windows.Forms.Button()
            Me.btnCopyAll2 = New System.Windows.Forms.Button()
            Me.lblRecNo1 = New System.Windows.Forms.Label()
            Me.txtSourceFile = New System.Windows.Forms.TextBox()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnConfirmData = New System.Windows.Forms.Button()
            Me.btnSaveData = New System.Windows.Forms.Button()
            Me.btnGetExcelData = New System.Windows.Forms.Button()
            Me.btnBroswerFile = New System.Windows.Forms.Button()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.lblRec2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
            Me.TabControl1.Location = New System.Drawing.Point(8, 11)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(856, 616)
            Me.TabControl1.TabIndex = 1
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.Lavender
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReset, Me.lblCustomer, Me.cboCustomer, Me.btnCopySelectedRows2, Me.btnCopyAll2, Me.lblRecNo1, Me.txtSourceFile, Me.tdgData1, Me.btnConfirmData, Me.btnSaveData, Me.btnGetExcelData, Me.btnBroswerFile, Me.lblTitle})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(848, 590)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Upload Data"
            '
            'btnReset
            '
            Me.btnReset.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReset.ForeColor = System.Drawing.Color.Firebrick
            Me.btnReset.Location = New System.Drawing.Point(144, 2)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(80, 22)
            Me.btnReset.TabIndex = 102
            Me.btnReset.Text = "Reset"
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(16, 8)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(96, 16)
            Me.lblCustomer.TabIndex = 101
            Me.lblCustomer.Text = "Customer:"
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
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(16, 24)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(208, 21)
            Me.cboCustomer.TabIndex = 100
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
            'btnCopySelectedRows2
            '
            Me.btnCopySelectedRows2.BackColor = System.Drawing.Color.SlateGray
            Me.btnCopySelectedRows2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows2.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopySelectedRows2.Location = New System.Drawing.Point(696, 32)
            Me.btnCopySelectedRows2.Name = "btnCopySelectedRows2"
            Me.btnCopySelectedRows2.Size = New System.Drawing.Size(136, 23)
            Me.btnCopySelectedRows2.TabIndex = 96
            Me.btnCopySelectedRows2.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll2
            '
            Me.btnCopyAll2.BackColor = System.Drawing.Color.SlateGray
            Me.btnCopyAll2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll2.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopyAll2.Location = New System.Drawing.Point(592, 32)
            Me.btnCopyAll2.Name = "btnCopyAll2"
            Me.btnCopyAll2.Size = New System.Drawing.Size(96, 23)
            Me.btnCopyAll2.TabIndex = 95
            Me.btnCopyAll2.Text = "Copy All Rows"
            '
            'lblRecNo1
            '
            Me.lblRecNo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNo1.Location = New System.Drawing.Point(16, 560)
            Me.lblRecNo1.Name = "lblRecNo1"
            Me.lblRecNo1.Size = New System.Drawing.Size(152, 16)
            Me.lblRecNo1.TabIndex = 48
            '
            'txtSourceFile
            '
            Me.txtSourceFile.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtSourceFile.ForeColor = System.Drawing.Color.MediumBlue
            Me.txtSourceFile.Location = New System.Drawing.Point(16, 56)
            Me.txtSourceFile.Name = "txtSourceFile"
            Me.txtSourceFile.ReadOnly = True
            Me.txtSourceFile.Size = New System.Drawing.Size(816, 13)
            Me.txtSourceFile.TabIndex = 47
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
            Me.tdgData1.Location = New System.Drawing.Point(16, 72)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.Size = New System.Drawing.Size(816, 488)
            Me.tdgData1.TabIndex = 46
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
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 814, 486</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 814, 486</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnConfirmData
            '
            Me.btnConfirmData.BackColor = System.Drawing.SystemColors.Control
            Me.btnConfirmData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnConfirmData.ForeColor = System.Drawing.Color.Blue
            Me.btnConfirmData.Image = CType(resources.GetObject("btnConfirmData.Image"), System.Drawing.Bitmap)
            Me.btnConfirmData.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.btnConfirmData.Location = New System.Drawing.Point(760, 8)
            Me.btnConfirmData.Name = "btnConfirmData"
            Me.btnConfirmData.Size = New System.Drawing.Size(40, 16)
            Me.btnConfirmData.TabIndex = 45
            Me.btnConfirmData.Text = "Confirm Data   "
            Me.btnConfirmData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSaveData
            '
            Me.btnSaveData.BackColor = System.Drawing.SystemColors.Control
            Me.btnSaveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveData.ForeColor = System.Drawing.Color.Blue
            Me.btnSaveData.Image = CType(resources.GetObject("btnSaveData.Image"), System.Drawing.Bitmap)
            Me.btnSaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnSaveData.Location = New System.Drawing.Point(464, 24)
            Me.btnSaveData.Name = "btnSaveData"
            Me.btnSaveData.Size = New System.Drawing.Size(88, 26)
            Me.btnSaveData.TabIndex = 44
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
            Me.btnGetExcelData.Location = New System.Drawing.Point(352, 24)
            Me.btnGetExcelData.Name = "btnGetExcelData"
            Me.btnGetExcelData.Size = New System.Drawing.Size(104, 26)
            Me.btnGetExcelData.TabIndex = 43
            Me.btnGetExcelData.Text = "Get Data   "
            Me.btnGetExcelData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnBroswerFile
            '
            Me.btnBroswerFile.BackColor = System.Drawing.SystemColors.Control
            Me.btnBroswerFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBroswerFile.ForeColor = System.Drawing.Color.Blue
            Me.btnBroswerFile.Image = CType(resources.GetObject("btnBroswerFile.Image"), System.Drawing.Bitmap)
            Me.btnBroswerFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnBroswerFile.Location = New System.Drawing.Point(240, 24)
            Me.btnBroswerFile.Name = "btnBroswerFile"
            Me.btnBroswerFile.Size = New System.Drawing.Size(104, 24)
            Me.btnBroswerFile.TabIndex = 42
            Me.btnBroswerFile.Text = "Find File     "
            Me.btnBroswerFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Location = New System.Drawing.Point(328, 2)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(192, 24)
            Me.lblTitle.TabIndex = 1
            Me.lblTitle.Text = "Upload Freq Code Map Data"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.AntiqueWhite
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopySelectedRows, Me.btnCopyAll, Me.btnRefresh, Me.lblRec2, Me.Label1, Me.tdgData2})
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(848, 590)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "View Data"
            Me.TabPage2.Visible = False
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.BackColor = System.Drawing.Color.Transparent
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.LightSeaGreen
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(640, 8)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(160, 23)
            Me.btnCopySelectedRows.TabIndex = 98
            Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.Transparent
            Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.LightSeaGreen
            Me.btnCopyAll.Location = New System.Drawing.Point(528, 8)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll.TabIndex = 97
            Me.btnCopyAll.Text = "Copy All Rows"
            '
            'btnRefresh
            '
            Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefresh.ForeColor = System.Drawing.Color.Green
            Me.btnRefresh.Location = New System.Drawing.Point(224, 0)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.Size = New System.Drawing.Size(96, 32)
            Me.btnRefresh.TabIndex = 50
            Me.btnRefresh.Text = "Refresh"
            '
            'lblRec2
            '
            Me.lblRec2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRec2.Location = New System.Drawing.Point(16, 520)
            Me.lblRec2.Name = "lblRec2"
            Me.lblRec2.Size = New System.Drawing.Size(152, 16)
            Me.lblRec2.TabIndex = 49
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Navy
            Me.Label1.Location = New System.Drawing.Point(0, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(216, 24)
            Me.Label1.TabIndex = 48
            Me.Label1.Text = "Existing Freq Code Mapping Data"
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
            Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgData2.Location = New System.Drawing.Point(16, 32)
            Me.tdgData2.Name = "tdgData2"
            Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData2.PreviewInfo.ZoomFactor = 75
            Me.tdgData2.Size = New System.Drawing.Size(784, 488)
            Me.tdgData2.TabIndex = 47
            Me.tdgData2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised" & _
            ",,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
            "ear;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
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
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 782, 486</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 782, 486</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmCustomerFreqCodeMap
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(888, 638)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmCustomerFreqCodeMap"
            Me.Text = "frmCustomerFreqCodeMap"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmCustomerFreqCodeMap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me.btnConfirmData.Visible = False
                Me.btnGetExcelData.Enabled = False
                Me.btnSaveData.Enabled = False
                Me.btnBroswerFile.Enabled = False

                Me.TabControl1.SelectedIndex = 0
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

                LoadCustomers()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub frmCustomerFreqCodeMap_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
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


        '*********************************************************
        Private Sub LoadCustomers()
            Dim dt As New DataTable()
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try
                dt = objMisc.GetCustomers(1)
                If dt.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_name1", "cust_ID")
                    Me.cboCustomer.SelectedValue = 0
                    ' Me.cboCustomer.Enabled = False
                Else
                    MessageBox.Show("No customer!") : Exit Sub
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objMisc = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Sub cboCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
            Try
                If Me.cboCustomer.SelectedValue > 0 Then
                    Me.btnGetExcelData.Enabled = False
                    Me.btnSaveData.Enabled = False
                    Me.btnBroswerFile.Enabled = True
                    Me.txtSourceFile.Text = ""
                Else
                    Me.btnGetExcelData.Enabled = False
                    Me.btnSaveData.Enabled = False
                    Me.btnBroswerFile.Enabled = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub cboCustomer_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    Me.btnConfirmData.Enabled = False
                    Me.ToolTip1.SetToolTip(Me.btnGetExcelData, "Load Data from Excel File: " & strFileName)
                Else
                    MsgBox("You did not select a file!")
                    Me.btnGetExcelData.Enabled = False
                    Me.btnSaveData.Enabled = False
                    Me.btnConfirmData.Enabled = False
                    Me.txtSourceFile.Text = ""
                    Me._strSourceFileName = ""
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnBroswerFile_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.btnGetExcelData.Enabled = False
                Me.btnSaveData.Enabled = False
                Me.btnConfirmData.Enabled = False
            End Try
        End Sub

        '******************************************************************
        Private Sub btnGetExcelData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetExcelData.Click
            Dim strFileName As String = ""
            Dim objMessaging As PSS.Data.Buisness.Messaging
            Dim dt As DataTable, row As DataRow
            Dim strS As String = "", i As Integer, iRowID As Integer, j As Integer, maxL As Integer = 0
            Dim tmpArr As New ArrayList(), ArrRecIDs As New ArrayList()
            Dim strErrMsg As String = ""
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iInvalidCount As Integer = 0, idx As Integer

            Try
                Cursor = Cursors.WaitCursor
                Me.tdgData1.Visible = False : Me.tdgData1.DataSource = Nothing
                Me.lblRecNo1.Text = ""
                Me.btnSaveData.Enabled = False : Me.btnConfirmData.Enabled = False

                strFileName = Me.txtSourceFile.Text

                If File.Exists(strFileName) Then
                    '1. Handle data
                    objMessaging = New PSS.Data.Buisness.Messaging()
                    dt = objMessaging.LoadExcelFreqCodeMappingData(strFileName, strErrMsg)

                    If strErrMsg.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg)
                    ElseIf Not dt.Rows.Count > 0 Then
                        MessageBox.Show("No enough data tables!")
                    Else
                        'Bind data
                        RemovedBeginAndEndSpacesAndReplaceSingleQuotation(dt)
                        Dim dtResult As DataTable = ResultDataAfterValidations(dt)
                        Me.tdgData1.DataSource = dtResult
                        Me.lblRecNo1.Text = "Total Records: " & dt.Rows.Count
                        Me.tdgData1.Visible = True : Me.lblRecNo1.Visible = True
                        Me.tdgData1.Splits(0).DisplayColumns("RowID").Width = 30
                        Me.tdgData1.Splits(0).DisplayColumns("Status").Width = 90

                        'Check total invalid count,Flag invalid if any (Select invalid rows)
                        iInvalidCount = dtResult.Compute("COUNT(Status)", "Status='" & Me._strInvalid & "'")
                        If iInvalidCount > 0 Then
                            MessageBox.Show(iInvalidCount.ToString & " rows have invalid data (either invalid or duplicate Freq_Number/Freq_Code)." & Environment.NewLine & _
                                                        "These invalid rows will be skipped when to save data.")
                        End If

                        'Me.btnConfirmData.Enabled = True
                        Me.btnSaveData.Enabled = True
                        Me.cboCustomer.Enabled = False
                    End If
                Else
                    MessageBox.Show("Can't find file: " & strFileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Cursor = Cursors.Default
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnGetExcelData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
                objMessaging = Nothing
                Cursor = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub RemovedBeginAndEndSpacesAndReplaceSingleQuotation(ByRef dt As DataTable)
            Dim row As DataRow
            Dim strS As String

            Try
                For Each row In dt.Rows
                    If Not row.IsNull("Freq_Number") Then
                        strS = row("Freq_Number") : row("Freq_Number") = strS.Trim.Replace("'", "")
                    End If
                    If Not row.IsNull("Freq_Code") Then
                        strS = row("Freq_Code") : row("Freq_Code") = strS.Trim.Replace("'", "")
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

            Dim arrUnique1 As New ArrayList(), arrUnique2 As New ArrayList()
            Dim arrInvalidDuplicateRowRecIdxs As New ArrayList()
            Dim objMessaging As PSS.Data.Buisness.Messaging

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
                        row("Status") = Me._strInvalid
                    End If
                Next

                'Check valid Freq_Number: ###.####
                For Each row In dt.Rows
                    strTemp = row("Freq_Number")
                    If strTemp.Trim.Length <> 8 Then
                        row("Status") = Me._strInvalid
                    Else
                        Dim s() As String = Split(strTemp, ".")
                        If s.Length = 2 Then
                            If s(0).Length = 3 AndAlso s(1).Length = 4 Then
                                Dim regD As RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[0-9]*$")
                                If regD.IsMatch(s(0)) AndAlso regD.IsMatch(s(1)) Then
                                    'passed, do nothing
                                Else
                                    row("Status") = Me._strInvalid
                                End If
                            Else
                                row("Status") = Me._strInvalid
                            End If
                        Else
                            row("Status") = Me._strInvalid
                        End If
                    End If
                Next

                'Check unique freq_number
                For Each row In dt.Rows
                    If Not row.IsNull("Freq_Number") Then
                        strTemp = row("Freq_Number")
                        If Not arrUnique1.Contains(strTemp.Trim) Then
                            arrUnique1.Add(strTemp)
                        End If
                    End If
                Next
                For i = 0 To arrUnique1.Count - 1 'Check dup Freq_number
                    strTemp = arrUnique1(i)
                    filteredRows = dt.Select("Freq_Number='" & strTemp & "'")
                    If filteredRows.Length > 1 Then
                        For Each row In filteredRows
                            row("Status") = Me._strInvalid
                        Next
                    End If
                Next

                'Check unique freq_code
                For Each row In dt.Rows
                    If Not row.IsNull("Freq_Code") Then
                        strTemp = row("Freq_Code")
                        If Not arrUnique2.Contains(strTemp.Trim) Then
                            arrUnique2.Add(strTemp)
                        End If
                    End If
                Next
                For i = 0 To arrUnique2.Count - 1 'Check dup Freq_Code
                    strTemp = arrUnique2(i)
                    filteredRows = dt.Select("Freq_Code='" & strTemp & "'")
                    If filteredRows.Length > 1 Then
                        For Each row In filteredRows
                            row("Status") = Me._strInvalid
                        Next
                    End If
                Next

                'Get freq_ID 
                objMessaging = New PSS.Data.Buisness.Messaging()
                For Each row In dt.Rows
                    Dim iFreqID As Integer
                    iFreqID = objMessaging.GetFreqID(row("Freq_Number").ToString)
                    row("Freq_ID") = iFreqID
                    If row("Status") <> Me._strInvalid AndAlso Not iFreqID > 0 Then
                        row("Status") = Me._strInvalid
                    End If
                Next

                dt.AcceptChanges()
                objMessaging = Nothing

                Return dt
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Function  ResultDataAfterValidations", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Function

        '******************************************************************
        Private Sub tdgData1_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgData1.FetchRowStyle
            Dim strStatus As String
            Try
                strStatus = Me.tdgData1.Columns("Status").CellText(e.Row)
                Select Case strStatus
                    Case Me._strInserted
                        e.CellStyle.BackColor = Color.LightGreen
                    Case Me._strUpdated
                        e.CellStyle.BackColor = Color.LightSteelBlue
                    Case Me._strNoChange
                        e.CellStyle.BackColor = Color.White
                    Case Me._strSQLFailed
                        e.CellStyle.BackColor = Color.Coral
                    Case Me._strInvalid
                        e.CellStyle.BackColor = Color.Yellow
                    Case Me._strExist
                        e.CellStyle.BackColor = Color.LightPink
                        'Case Else
                        '       e.CellStyle.BackColor = Color.Pink
                End Select

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub tdgData1_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Try
                Me.cboCustomer.SelectedValue = 0
                Me.cboCustomer.Enabled = True
                Me.tdgData1.DataSource = Nothing
                Me.btnBroswerFile.Enabled = False
                Me.btnGetExcelData.Enabled = False
                Me.btnSaveData.Enabled = False
                Me.txtSourceFile.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnReset_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnSaveData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSaveData.Click
            Dim iCustID, iFreqID, iUserID As Integer
            Dim strFreqCode, strDateTime As String
            Dim row As DataRow
            Dim dt As DataTable
            Dim objMessaging As PSS.Data.Buisness.Messaging
            Dim i As Integer = 0

            Try
                iCustID = Me.cboCustomer.SelectedValue()
                strDateTime = Format(Now, "yyyy-MM-dd hh:mm:ss")
                iUserID = PSS.Core.ApplicationUser.IDuser

                If Not iCustID > 0 Then
                    MessageBox.Show("Invalid Customer ID.", "sub btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                dt = Me.tdgData1.DataSource

                objMessaging = New PSS.Data.Buisness.Messaging()

                For Each row In dt.Rows
                    If row("Status") <> Me._strInvalid Then
                        iFreqID = row("Freq_ID") : strFreqCode = row("Freq_Code")

                        If objMessaging.FreqIDCodeExist(iCustID, iFreqID, strFreqCode) Then 'already exist (mapped) either greq_ID or Freq_Code
                            row("Status") = Me._strExist
                        Else 'Insert new
                            i = objMessaging.SaveGreqIDFreqCodeMapData(iCustID, iFreqID, strFreqCode, iUserID, strDateTime)
                            If Not i > 0 Then
                                row("Status") = Me._strSQLFailed
                            Else
                                row("Status") = Me._strInserted
                            End If
                        End If
                    End If
                Next
                objMessaging = Nothing

                Me.tdgData1.DataSource = dt
                Me.btnSaveData.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Dim iCustID As Integer
            Dim dt As DataTable
            Dim objMessaging As PSS.Data.Buisness.Messaging
            Dim i As Integer = 0

            Try
                iCustID = Me.cboCustomer.SelectedValue()

                If Not iCustID > 0 Then
                    MessageBox.Show("Invalid Customer ID.", "Sub btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                objMessaging = New PSS.Data.Buisness.Messaging()
                dt = objMessaging.GetFreqIDFreqCodeMappingData(iCustID)
                'if dt.Rows.Count >0 then
                Me.tdgData2.DataSource = dt
                'Else
                '    Me.tdgData2.DataSource = Nothing
                'End If

                objMessaging = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    End Class
End Namespace