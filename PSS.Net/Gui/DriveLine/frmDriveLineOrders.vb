Option Explicit On 

Imports PSS.Data
Imports PSS.Core.Global
Imports System.IO
Imports System.Text

Namespace Gui
    Public Class frmDriveLineOrders
        Inherits System.Windows.Forms.Form

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
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents btnBroswerFile As System.Windows.Forms.Button
        Friend WithEvents txtSourceFile As System.Windows.Forms.TextBox
        Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
        Friend WithEvents btnGetExcelData As System.Windows.Forms.Button
        Friend WithEvents btnSaveData As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblRecNo1 As System.Windows.Forms.Label
        Friend WithEvents tdgData2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblRecNo2 As System.Windows.Forms.Label
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
        Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
        Friend WithEvents DataGrid3 As System.Windows.Forms.DataGrid
        Friend WithEvents DataGrid4 As System.Windows.Forms.DataGrid
        Friend WithEvents btnConfirmData As System.Windows.Forms.Button
        Friend WithEvents btnListComponents As System.Windows.Forms.Button
        Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents ListBox_DropKeys As System.Windows.Forms.ListBox
        Friend WithEvents ListBox_AllKeys As System.Windows.Forms.ListBox
        Friend WithEvents ListBox_NoRepButProdRowIDs As System.Windows.Forms.ListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDriveLineOrders))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.btnBroswerFile = New System.Windows.Forms.Button()
            Me.txtSourceFile = New System.Windows.Forms.TextBox()
            Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnGetExcelData = New System.Windows.Forms.Button()
            Me.btnSaveData = New System.Windows.Forms.Button()
            Me.lblRecNo1 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.btnConfirmData = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.ListBox_DropKeys = New System.Windows.Forms.ListBox()
            Me.ListBox_AllKeys = New System.Windows.Forms.ListBox()
            Me.ListBox1 = New System.Windows.Forms.ListBox()
            Me.btnListComponents = New System.Windows.Forms.Button()
            Me.lblRecNo2 = New System.Windows.Forms.Label()
            Me.tdgData2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.DataGrid4 = New System.Windows.Forms.DataGrid()
            Me.DataGrid3 = New System.Windows.Forms.DataGrid()
            Me.DataGrid2 = New System.Windows.Forms.DataGrid()
            Me.TextBox3 = New System.Windows.Forms.TextBox()
            Me.TextBox2 = New System.Windows.Forms.TextBox()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.DataGrid1 = New System.Windows.Forms.DataGrid()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.ListBox_NoRepButProdRowIDs = New System.Windows.Forms.ListBox()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage3.SuspendLayout()
            CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(184, 24)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "DriveLine Data Import"
            '
            'btnBroswerFile
            '
            Me.btnBroswerFile.BackColor = System.Drawing.SystemColors.Control
            Me.btnBroswerFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBroswerFile.ForeColor = System.Drawing.Color.Blue
            Me.btnBroswerFile.Image = CType(resources.GetObject("btnBroswerFile.Image"), System.Drawing.Bitmap)
            Me.btnBroswerFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnBroswerFile.Location = New System.Drawing.Point(8, 24)
            Me.btnBroswerFile.Name = "btnBroswerFile"
            Me.btnBroswerFile.Size = New System.Drawing.Size(104, 24)
            Me.btnBroswerFile.TabIndex = 1
            Me.btnBroswerFile.Text = "Find File     "
            Me.btnBroswerFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ToolTip1.SetToolTip(Me.btnBroswerFile, "Locate an Excel file")
            '
            'txtSourceFile
            '
            Me.txtSourceFile.BackColor = System.Drawing.Color.WhiteSmoke
            Me.txtSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtSourceFile.ForeColor = System.Drawing.Color.MediumBlue
            Me.txtSourceFile.Location = New System.Drawing.Point(10, 50)
            Me.txtSourceFile.Name = "txtSourceFile"
            Me.txtSourceFile.ReadOnly = True
            Me.txtSourceFile.Size = New System.Drawing.Size(878, 13)
            Me.txtSourceFile.TabIndex = 2
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
            Me.tdgData1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgData1.Location = New System.Drawing.Point(8, 18)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.Size = New System.Drawing.Size(856, 502)
            Me.tdgData1.TabIndex = 29
            Me.tdgData1.Text = "C1TrueDBGrid1"
            Me.tdgData1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>500</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 854, 500</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 854, 500</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnGetExcelData
            '
            Me.btnGetExcelData.BackColor = System.Drawing.SystemColors.Control
            Me.btnGetExcelData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetExcelData.ForeColor = System.Drawing.Color.Blue
            Me.btnGetExcelData.Image = CType(resources.GetObject("btnGetExcelData.Image"), System.Drawing.Bitmap)
            Me.btnGetExcelData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnGetExcelData.Location = New System.Drawing.Point(120, 24)
            Me.btnGetExcelData.Name = "btnGetExcelData"
            Me.btnGetExcelData.Size = New System.Drawing.Size(104, 24)
            Me.btnGetExcelData.TabIndex = 30
            Me.btnGetExcelData.Text = "Get Data   "
            Me.btnGetExcelData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ToolTip1.SetToolTip(Me.btnGetExcelData, "Load Excel Data ")
            '
            'btnSaveData
            '
            Me.btnSaveData.BackColor = System.Drawing.SystemColors.Control
            Me.btnSaveData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSaveData.ForeColor = System.Drawing.Color.Blue
            Me.btnSaveData.Image = CType(resources.GetObject("btnSaveData.Image"), System.Drawing.Bitmap)
            Me.btnSaveData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnSaveData.Location = New System.Drawing.Point(344, 24)
            Me.btnSaveData.Name = "btnSaveData"
            Me.btnSaveData.Size = New System.Drawing.Size(88, 24)
            Me.btnSaveData.TabIndex = 31
            Me.btnSaveData.Text = "Save Data   "
            Me.btnSaveData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ToolTip1.SetToolTip(Me.btnSaveData, "Save the Data to PSSNET Database")
            '
            'lblRecNo1
            '
            Me.lblRecNo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNo1.Location = New System.Drawing.Point(8, 1)
            Me.lblRecNo1.Name = "lblRecNo1"
            Me.lblRecNo1.Size = New System.Drawing.Size(152, 16)
            Me.lblRecNo1.TabIndex = 32
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(696, 0)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(56, 24)
            Me.Button1.TabIndex = 36
            Me.Button1.Text = "Button1"
            '
            'Button2
            '
            Me.Button2.ForeColor = System.Drawing.Color.Crimson
            Me.Button2.Location = New System.Drawing.Point(760, 0)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(128, 32)
            Me.Button2.TabIndex = 37
            Me.Button2.Text = "Clear Demo Data"
            '
            'btnConfirmData
            '
            Me.btnConfirmData.BackColor = System.Drawing.SystemColors.Control
            Me.btnConfirmData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnConfirmData.ForeColor = System.Drawing.Color.Blue
            Me.btnConfirmData.Image = CType(resources.GetObject("btnConfirmData.Image"), System.Drawing.Bitmap)
            Me.btnConfirmData.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.btnConfirmData.Location = New System.Drawing.Point(232, 24)
            Me.btnConfirmData.Name = "btnConfirmData"
            Me.btnConfirmData.Size = New System.Drawing.Size(104, 24)
            Me.btnConfirmData.TabIndex = 41
            Me.btnConfirmData.Text = "Confirm Data   "
            Me.btnConfirmData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ToolTip1.SetToolTip(Me.btnConfirmData, "Corfirm Data")
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
            Me.TabControl1.Location = New System.Drawing.Point(8, 64)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(880, 552)
            Me.TabControl1.TabIndex = 40
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.Lavender
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgData1, Me.lblRecNo1})
            Me.TabPage1.ForeColor = System.Drawing.Color.DarkGreen
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(872, 526)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Rep Data"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.PeachPuff
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox_NoRepButProdRowIDs, Me.ListBox_DropKeys, Me.ListBox_AllKeys, Me.ListBox1, Me.btnListComponents, Me.lblRecNo2, Me.tdgData2})
            Me.TabPage2.ForeColor = System.Drawing.Color.DarkGreen
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(872, 526)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Comp. Data"
            '
            'ListBox_DropKeys
            '
            Me.ListBox_DropKeys.Location = New System.Drawing.Point(784, 208)
            Me.ListBox_DropKeys.Name = "ListBox_DropKeys"
            Me.ListBox_DropKeys.Size = New System.Drawing.Size(72, 108)
            Me.ListBox_DropKeys.TabIndex = 37
            '
            'ListBox_AllKeys
            '
            Me.ListBox_AllKeys.Location = New System.Drawing.Point(784, 112)
            Me.ListBox_AllKeys.Name = "ListBox_AllKeys"
            Me.ListBox_AllKeys.Size = New System.Drawing.Size(72, 95)
            Me.ListBox_AllKeys.TabIndex = 36
            '
            'ListBox1
            '
            Me.ListBox1.Location = New System.Drawing.Point(784, 24)
            Me.ListBox1.Name = "ListBox1"
            Me.ListBox1.Size = New System.Drawing.Size(72, 82)
            Me.ListBox1.TabIndex = 35
            '
            'btnListComponents
            '
            Me.btnListComponents.BackColor = System.Drawing.Color.Bisque
            Me.btnListComponents.ForeColor = System.Drawing.Color.DarkOrchid
            Me.btnListComponents.Location = New System.Drawing.Point(168, 0)
            Me.btnListComponents.Name = "btnListComponents"
            Me.btnListComponents.Size = New System.Drawing.Size(112, 24)
            Me.btnListComponents.TabIndex = 34
            Me.btnListComponents.Text = "List Components"
            '
            'lblRecNo2
            '
            Me.lblRecNo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecNo2.Location = New System.Drawing.Point(0, 8)
            Me.lblRecNo2.Name = "lblRecNo2"
            Me.lblRecNo2.Size = New System.Drawing.Size(216, 16)
            Me.lblRecNo2.TabIndex = 33
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
            Me.tdgData2.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgData2.Location = New System.Drawing.Point(0, 24)
            Me.tdgData2.Name = "tdgData2"
            Me.tdgData2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData2.PreviewInfo.ZoomFactor = 75
            Me.tdgData2.Size = New System.Drawing.Size(752, 488)
            Me.tdgData2.TabIndex = 30
            Me.tdgData2.Text = "C1TrueDBGrid1"
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
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>486</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 750, 486</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 750, 486</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'TabPage3
            '
            Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid4, Me.DataGrid3, Me.DataGrid2, Me.TextBox3, Me.TextBox2, Me.TextBox1, Me.Button4, Me.DataGrid1, Me.Button3})
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(872, 526)
            Me.TabPage3.TabIndex = 4
            Me.TabPage3.Text = "TabPage5"
            '
            'DataGrid4
            '
            Me.DataGrid4.DataMember = ""
            Me.DataGrid4.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid4.Location = New System.Drawing.Point(560, 192)
            Me.DataGrid4.Name = "DataGrid4"
            Me.DataGrid4.Size = New System.Drawing.Size(208, 144)
            Me.DataGrid4.TabIndex = 44
            '
            'DataGrid3
            '
            Me.DataGrid3.DataMember = ""
            Me.DataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid3.Location = New System.Drawing.Point(560, 88)
            Me.DataGrid3.Name = "DataGrid3"
            Me.DataGrid3.Size = New System.Drawing.Size(208, 104)
            Me.DataGrid3.TabIndex = 43
            '
            'DataGrid2
            '
            Me.DataGrid2.DataMember = ""
            Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid2.Location = New System.Drawing.Point(48, 280)
            Me.DataGrid2.Name = "DataGrid2"
            Me.DataGrid2.Size = New System.Drawing.Size(504, 192)
            Me.DataGrid2.TabIndex = 42
            '
            'TextBox3
            '
            Me.TextBox3.Location = New System.Drawing.Point(304, 24)
            Me.TextBox3.Name = "TextBox3"
            Me.TextBox3.Size = New System.Drawing.Size(104, 20)
            Me.TextBox3.TabIndex = 4
            Me.TextBox3.Text = "TextBox3"
            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(192, 24)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(96, 20)
            Me.TextBox2.TabIndex = 3
            Me.TextBox2.Text = "TextBox2"
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(64, 24)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(120, 20)
            Me.TextBox1.TabIndex = 2
            Me.TextBox1.Text = "TextBox1"
            '
            'Button4
            '
            Me.Button4.Location = New System.Drawing.Point(552, 32)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(128, 32)
            Me.Button4.TabIndex = 1
            Me.Button4.Text = "Button4"
            '
            'DataGrid1
            '
            Me.DataGrid1.DataMember = ""
            Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid1.Location = New System.Drawing.Point(48, 72)
            Me.DataGrid1.Name = "DataGrid1"
            Me.DataGrid1.Size = New System.Drawing.Size(504, 192)
            Me.DataGrid1.TabIndex = 0
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(424, 16)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(72, 32)
            Me.Button3.TabIndex = 41
            Me.Button3.Text = "Button3"
            '
            'ListBox_NoRepButProdRowIDs
            '
            Me.ListBox_NoRepButProdRowIDs.Location = New System.Drawing.Point(784, 320)
            Me.ListBox_NoRepButProdRowIDs.Name = "ListBox_NoRepButProdRowIDs"
            Me.ListBox_NoRepButProdRowIDs.Size = New System.Drawing.Size(72, 108)
            Me.ListBox_NoRepButProdRowIDs.TabIndex = 38
            '
            'frmDriveLineOrders
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.SystemColors.ControlDark
            Me.ClientSize = New System.Drawing.Size(896, 630)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnConfirmData, Me.TabControl1, Me.Button2, Me.Button1, Me.btnSaveData, Me.btnGetExcelData, Me.txtSourceFile, Me.btnBroswerFile, Me.lblTitle})
            Me.Name = "frmDriveLineOrders"
            Me.Text = "DriveLine - Import Excel Datars"
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            CType(Me.tdgData2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage3.ResumeLayout(False)
            CType(Me.DataGrid4, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
        Private _dFolder As String = "P:\Dept\Driveline\ExcelOrderFiles"
        Private _KeepGridWidth As Integer
        Private _dtRepBackupData As DataTable
        Private _dtProdBackupData As DataTable
        Private _arrProdComponentNames As New ArrayList()
        Private _strSourceFileName As String = ""
        Private _arrDistinctProjectIDs As New ArrayList()
        Private _arrDistinctRetailers As New ArrayList()

        '******************************************************************
        Private Sub btnBroswerFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBroswerFile.Click

            Dim strFileName As String = ""
            Dim _objDriveLine As PSS.Data.Buisness.DriveLine
            Dim dt As DataTable
            Dim strS As String = "", i As Integer
            Dim tmpArr As New ArrayList(), ArrRecIDs As New ArrayList()

            Try
                Me.tdgData1.Visible = False : Me.tdgData1.DataSource = Nothing
                Me.tdgData2.Visible = False : Me.tdgData2.DataSource = Nothing
                Me._dtProdBackupData = Nothing : Me._dtRepBackupData = Nothing
                Me.lblRecNo1.Visible = False : Me.lblRecNo2.Visible = False
                Me._dtRepBackupData = Nothing : Me._dtRepBackupData = Nothing
                Me.btnListComponents.Visible = False

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
        Private Sub frmDriveLineOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.tdgData1.Visible = False : Me.tdgData2.Visible = False
                Me.btnGetExcelData.Enabled = False
                Me.btnSaveData.Enabled = False
                Me.btnConfirmData.Enabled = False
                Me.lblTitle.Visible = True
                Me.lblRecNo1.Text = "" : Me.lblRecNo2.Text = ""
                Me._KeepGridWidth = Me.tdgData1.Width
                Me.ListBox1.Visible = False : Me.btnListComponents.Visible = False
                Me.ListBox_AllKeys.Visible = False : Me.ListBox_DropKeys.Visible = False
                Me.ListBox_NoRepButProdRowIDs.Visible = False
                Me.Button1.Visible = False : Me.Button2.Visible = False 'coments it when debug
                Me.TabControl1.Controls.Remove(TabPage3) 'coments it when debug

                Me.TabControl1.SelectedIndex = 0
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed


                Me.Button2.Visible = False ' True  'demo

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDriveLineOrders_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnGetExcelData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetExcelData.Click
            Dim strFileName As String = ""
            Dim _objDriveLine As PSS.Data.Buisness.DriveLine
            Dim dtSet As DataSet, dt As DataTable
            Dim strS As String = "", i As Integer, iRowID As Integer, j As Integer, maxL As Integer = 0
            Dim tmpArr As New ArrayList(), ArrRecIDs As New ArrayList()
            Dim strErrMsg_Rep As String = "", strErrMsg_Prod As String = ""

            Try
                Cursor = Cursors.WaitCursor
                Me.tdgData1.Visible = False : Me.tdgData1.DataSource = Nothing
                Me.tdgData2.Visible = False : Me.tdgData2.DataSource = Nothing
                Me.lblRecNo1.Text = "" : Me.lblRecNo2.Text = ""
                Me.tdgData1.Width = Me._KeepGridWidth
                Me.btnSaveData.Enabled = False : Me.btnConfirmData.Enabled = False
                Me.ListBox1.Items.Clear() : Me._arrProdComponentNames.Clear()
                Me.btnListComponents.Visible = False

                strFileName = Me.txtSourceFile.Text

                If File.Exists(strFileName) Then
                    '1. Handle data
                    _objDriveLine = New PSS.Data.Buisness.DriveLine()
                    dtSet = _objDriveLine.LoadExcelData(strFileName, Me._arrProdComponentNames, strErrMsg_Rep, strErrMsg_Prod)
                    If strErrMsg_Rep.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg_Rep)
                    ElseIf strErrMsg_Prod.Trim.Length > 0 Then
                        MessageBox.Show(strErrMsg_Prod)
                    ElseIf Not dtSet.Tables.Count > 0 Then
                        MessageBox.Show("No enough data tables!")
                    Else
                        For Each dt In dtSet.Tables
                            If dt.TableName = _objDriveLine.RepTableName Then
                                If Not dt.Rows.Count > 0 Then
                                    MessageBox.Show("No data for " & dt.TableName)
                                    Exit Sub : Cursor = Cursors.Default
                                End If
                                Me.tdgData1.DataSource = dt : Me._dtRepBackupData = dt.Copy
                                Me.lblRecNo1.Text = "Total Records: " & dt.Rows.Count
                                Me.tdgData1.Splits(0).DisplayColumns("RawRecID").Width = 60
                            ElseIf dt.TableName = _objDriveLine.ProdTableName Then
                                If Not dt.Rows.Count > 0 Then
                                    MessageBox.Show("No data for " & dt.TableName)
                                    Exit Sub : Cursor = Cursors.Default
                                End If
                                Me.tdgData2.DataSource = dt : Me._dtProdBackupData = dt.Copy
                                Me.lblRecNo2.Text = "Total Records: " & dt.Rows.Count
                                For i = 0 To Me._arrProdComponentNames.Count - 1
                                    Dim cName As String = "CP" & i + 1
                                    Me.ListBox1.Items.Add("CP" & i + 1 & ":   " & Me._arrProdComponentNames(i))
                                    Me.tdgData2.Splits(0).DisplayColumns(cName).Width = 30
                                Next
                                For i = 0 To Me.ListBox1.Items.Count - 1
                                    strS = Me.ListBox1.Items(i)
                                    If strS.Length > maxL Then maxL = strS.Length
                                Next
                                Me.ListBox1.Items.Clear()
                                For i = 0 To Me._arrProdComponentNames.Count - 1
                                    Dim sumObj As Object = dt.Compute("Sum(" & "CP" & i + 1 & ")", "")
                                    If sumObj Is Nothing Or sumObj.ToString.Trim.Length = 0 Then
                                        sumObj = "0"
                                    End If
                                    strS = "CP" & i + 1 & ":   " & Me._arrProdComponentNames(i)
                                    Dim b As New StringBuilder()
                                    b.Append(strS.PadRight(maxL))
                                    Me.ListBox1.Items.Add(b.ToString & " - " & sumObj.ToString & " pieces")
                                Next
                                Me.tdgData2.Splits(0).DisplayColumns("RawRecID").Width = 60
                                Me.tdgData2.Splits(0).DisplayColumns("State").Width = 40
                                Me.tdgData2.Splits(0).DisplayColumns("Zip").Width = 60
                                Me.tdgData2.Width = Me.tdgData1.Width
                                Me.TabControl1.SelectedIndex = 0
                            End If
                        Next
                        Me.tdgData1.Visible = True : Me.tdgData2.Visible = True
                        Me.lblRecNo1.Visible = True : Me.lblRecNo2.Visible = True
                        Me.btnConfirmData.Enabled = True : Me.btnListComponents.Visible = True
                    End If
                Else
                    MessageBox.Show("Can't find file: " & strFileName, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Cursor = Cursors.Default
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnGetExcelData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dt = Nothing
                _objDriveLine = Nothing
                Cursor = Cursors.Default
            End Try

        End Sub

        '******************************************************************
        Private Sub btnSaveData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveData.Click
            Dim iCust_ID, iUser_ID, iReturnBoxYesNo, iCntry_ID, iProdQty As Integer
            Dim strClaimNo, strDate, strShipTo_Name, strAddress1, strCity As String
            Dim strAddress2, strTel, strZipCode, strState_ShortName, strRetailer As String
            Dim strProjID, strRepID, strColName As String
            Dim strStoreNo, strProdAddress1, strProdCity, strProdState, strProdZip, strProd As String
            Dim iWO_ID, iEW_ID, iDLStore_ID, iDLDetail_ID, totalOrderQty As Integer

            'Dim iRowID As Integer
            'Dim strTmp As String = ""
            Dim iResult As Integer = 0
            Dim strFailedToSaveOrders As New ArrayList()
            Dim strOrdersAlreadyExist As New ArrayList()
            Dim iSavedOrderNum As Integer = 0
            Dim strMsg As String = "", StrMsgOutput As String = ""
            Dim bSaveDisrepancySuccessful As Boolean = False

            Dim Rep_DT As DataTable, Prod_DT As DataTable
            'Dim Rep_FilteredDT As DataTable, Prod_FilteredDT As DataTable, Store_ProdDT As DataTable 'Used for debug
            Dim Rep_foundRows As DataRow(), Prod_foundRows As DataRow()
            Dim row As DataRow, row2 As DataRow
            Dim i, j, k As Integer
            Dim strUniqueID As String, Rep_Expression As String, Prod_Expression As String
            Dim objDriveLine As PSS.Data.Buisness.DriveLine
            objDriveLine = New PSS.Data.Buisness.DriveLine()

            Try
                Cursor = Cursors.WaitCursor
                'Me.btnSaveData.Enabled = False

                If Not Me.ListBox_AllKeys.Items.Count > 0 Then
                    MessageBox.Show("No unique IDs!", " btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If Me.ListBox_DropKeys.Items.Count > 0 Then
                    For i = 0 To Me.ListBox_DropKeys.Items.Count - 1
                        Me.ListBox_AllKeys.Items.Remove(Me.ListBox_DropKeys.Items(i))
                    Next
                    Me.ListBox_AllKeys.Refresh()
                End If

                'Check Order Unique_ID already exist in tworkorder and extendedwarranty tables
                For i = 0 To Me.ListBox_AllKeys.Items.Count - 1 'REP: each row of unique id rows 
                    strUniqueID = Me.ListBox_AllKeys.Items(i)
                    strMsg = objDriveLine.DriveLineCheckDuplicatedOrder(strUniqueID, objDriveLine.CUSTOMERID, objDriveLine.LOCID)
                    If strMsg.Trim.Length > 0 Then
                        StrMsgOutput &= strMsg & Environment.NewLine
                    End If
                Next 'REP: each row of unique id rows 
                If StrMsgOutput.Trim.Length > 0 Then
                    MessageBox.Show("Can't save. Please see IT! " & Environment.NewLine & StrMsgOutput, "Sub btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If


                'Ready to save now-------------------------------------------------------------------------------------------------
                iCust_ID = objDriveLine.CUSTOMERID : strDate = Format(Now, "yyyy-MM-dd hh:mm:ss")
                iUser_ID = PSS.Core.ApplicationUser.IDuser : iCntry_ID = 161 'USA
                iReturnBoxYesNo = 1

                Rep_DT = Me.tdgData1.DataSource : Prod_DT = Me.tdgData2.DataSource
                'Rep_FilteredDT = Rep_DT.Clone : Prod_FilteredDT = Prod_DT.Clone
                'Store_ProdDT = objDriveLine.StoreComponentsTableDefinition

                For i = 0 To Me.ListBox_AllKeys.Items.Count - 1 'REP: each row of unique id (OrderName) rows -
                    strUniqueID = Me.ListBox_AllKeys.Items(i)
                    Rep_Expression = "Unique_ID = '" & strUniqueID & "'" 'OrderName
                    Rep_foundRows = Rep_DT.Select(Rep_Expression)
                    'Rep_FilteredDT.Clear()
                    iWO_ID = 0 : iEW_ID = 0 : j = 0 : totalOrderQty = 0
                    For Each row In Rep_foundRows 'Rep: each row (Unique_ID) of filteredRows--
                        'Rep_FilteredDT.ImportRow(row)
                        If j = 0 Then
                            strClaimNo = row("Unique_ID")
                            strShipTo_Name = CorrectStr(row("REP FIRST NAME")) & " " & CorrectStr(row("REP LAST NAME"))
                            strAddress1 = CorrectStr(row("REP ADDRESS"))
                            If row.IsNull("REP ADDRESS 2") Then
                                strAddress2 = ""
                            Else
                                strAddress2 = CorrectStr(row("REP ADDRESS 2"))
                            End If
                            strCity = CorrectStr(row("REP CITY")) : strZipCode = CorrectStr(row("REP ZIP"))
                            strState_ShortName = CorrectStr(row("REP STATE")) : strTel = CorrectStr(row("REP PHONE"))
                            strRetailer = CorrectStr(row("RETAILER ID"))
                            strProjID = CorrectStr(row("PROJECT")) : strRepID = CorrectStr(row("REPI"))
                            iWO_ID = objDriveLine.CreateAndGetWorkOrder(strClaimNo, objDriveLine.LOCID, objDriveLine.GROUPID, 0, 0)
                            If Not iWO_ID > 0 Then
                                MessageBox.Show("Not a valid Workorder ID or failed to create.. See IT.", "btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                            iEW_ID = objDriveLine.InsertDriveLineOrderData(iCust_ID, strClaimNo, strDate, strDate, strShipTo_Name, _
                                                                           strAddress1, strAddress2, strCity, strTel, strZipCode, _
                                                                           strState_ShortName, strRetailer, strProjID, strRepID, CorrectStr(Me._strSourceFileName), _
                                                                           iCntry_ID, iUser_ID, iReturnBoxYesNo, iWO_ID)
                        End If
                        j += 1
                        If Not iEW_ID > 0 Then
                            MessageBox.Show("Not a valid EW_ID or failed to create. See IT.", "btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                        Prod_Expression = "RETAILER='" & row("RETAILER ID") & "' AND [STORE NO] ='" & row("STORE NO") & "'"
                        Prod_foundRows = Prod_DT.Select(Prod_Expression)
                        'Prod_FilteredDT.Clear()

                        For Each row2 In Prod_foundRows 'Prod: each row (StoreNo) of filteredRows---
                            'Prod_FilteredDT.ImportRow(row2)
                            strStoreNo = row2("STORE NO") : strProdAddress1 = CorrectStr(row2("ADDRESS 1"))
                            strProdCity = CorrectStr(row2("CITY")) : strProdState = CorrectStr(row2("STATE"))
                            strProdZip = CorrectStr(row2("ZIP")) : strRetailer = CorrectStr(row2("Retailer"))
                            iDLStore_ID = 0
                            iDLStore_ID = objDriveLine.InsertDriveLineStoreData(iEW_ID, strStoreNo, strProdAddress1, "", strProdCity, strProdState, strProdZip, strRetailer)
                            If Not iDLStore_ID > 0 Then
                                MessageBox.Show("Not a valid DLStore_ID or failed to create. See IT.", "btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If

                            'Store_ProdDT.Clear()
                            For k = 0 To Me._arrProdComponentNames.Count - 1 '----
                                strColName = "CP" & k + 1 : strProd = Me._arrProdComponentNames(k) : iDLDetail_ID = 0
                                If row2.IsNull(strColName) Then
                                    iProdQty = 0
                                Else
                                    iProdQty = row2(strColName)
                                End If
                                'Dim row3 As DataRow = Store_ProdDT.NewRow
                                'row3("ColName") = strColName : row3("ProdName") = strProd : row3("ProdQty") = iProdQty
                                'Store_ProdDT.Rows.Add(row3)

                                If iProdQty > 0 Then
                                    iDLDetail_ID = objDriveLine.InsertDriveLineProdComponentData(iEW_ID, iDLStore_ID, strProd, iProdQty, "Pieces")
                                    If Not iDLDetail_ID > 0 Then
                                        MessageBox.Show("Not a valid iDLDetail_ID or failed to create. See IT.", "btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        Exit Sub
                                    End If
                                    totalOrderQty += iProdQty
                                End If
                            Next '----
                        Next 'Prod: each row (StoreNo) of filteredRows---
                    Next 'Rep: each row (Unique_ID) of filteredRows--
                    iSavedOrderNum += 1
                    iResult = objDriveLine.UpdateDriveLineWorkOrderQty(iWO_ID, totalOrderQty)
                Next 'REP: each row of unique id (OrderName) rows -

                'Me.DataGrid1.DataSource = Rep_FilteredDT
                'Me.DataGrid2.DataSource = Prod_FilteredDT
                'Me.DataGrid3.DataSource = Store_ProdDT

                'Process discrepancy data if any---------------------------------------------------------------------------
                SaveDiscrepancyData(strDate, bSaveDisrepancySuccessful)
                'bSaveDisrepancySuccessful = True

                'Final task notice------------------------------------------------------------------------------------------
                If iSavedOrderNum = Me.ListBox_AllKeys.Items.Count _
                   AndAlso Me.ListBox_DropKeys.Items.Count = 0 _
                   AndAlso Me.ListBox_NoRepButProdRowIDs.Items.Count = 0 Then
                    MessageBox.Show(iSavedOrderNum & IIf(iSavedOrderNum > 1, " orders are", " order is") & " successfully saved! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim myS As String
                    myS = iSavedOrderNum & IIf(iSavedOrderNum > 1, " orders are", " order is") & " saved!" & Environment.NewLine
                    If Me.ListBox_DropKeys.Items.Count > 0 Then
                        myS &= Environment.NewLine & Me.ListBox_DropKeys.Items.Count & IIf((Me.ListBox_DropKeys.Items.Count) > 1, " orders are", " order is") & " not matched! "
                    End If
                    If Me.ListBox_NoRepButProdRowIDs.Items.Count > 0 Then
                        myS &= Environment.NewLine & Me.ListBox_NoRepButProdRowIDs.Items.Count & IIf((Me.ListBox_NoRepButProdRowIDs.Items.Count) > 1, " store-component records have", " store-component record has") & " no Rep data matched! "
                    End If
                    If bSaveDisrepancySuccessful Then
                        MessageBox.Show(myS & Environment.NewLine & "Discrepancy data are saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show(myS & Environment.NewLine & "Failed to save discrepancy data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnSaveData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objDriveLine = Nothing
                Me.btnSaveData.Enabled = True
                Cursor = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Sub SaveDiscrepancyData(ByVal strDateTime As String, ByRef bSaveDisrepancySuccessful As Boolean)
            Dim i, j, k, iCust_ID, iUser_ID, iDR_ID, iDRStore_ID, iDLDetail_ID, iProdQty, iRowIdx As Integer
            Dim strUniqueID, Rep_Expression, Prod_Expression, strOrderName, strShipTo_Name, strAddress1, strAddress2 As String
            Dim strCity, strZipCode, strTel, strStateName, strRetailer, strProjID, strRepID As String
            Dim strStoreNo, strProdAddress1, strProdCity, strProdState, strProdZip As String
            Dim strColName, strProd As String
            Dim Rep_DT, Prod_DT As DataTable
            Dim Rep_foundRows, Prod_foundRows As DataRow()
            Dim row, row2 As DataRow
            Dim arrFilteredStores As New ArrayList()
            Dim objDriveLine As PSS.Data.Buisness.DriveLine

            Try
                Cursor = Cursors.WaitCursor
                objDriveLine = New PSS.Data.Buisness.DriveLine()
                iCust_ID = objDriveLine.CUSTOMERID
                iUser_ID = PSS.Core.ApplicationUser.IDuser

                Rep_DT = Me.tdgData1.DataSource : Prod_DT = Me.tdgData2.DataSource

                'Have rep data and component data, but not matched perfectly----------------------------------------------------------------------------------------------------------------------------
                If Me.ListBox_DropKeys.Items.Count > 0 Then
                    For i = 0 To Me.ListBox_DropKeys.Items.Count - 1 'REP: each row of dropped unique id (OrderName) 
                        strUniqueID = Me.ListBox_DropKeys.Items(i)
                        Rep_Expression = "Unique_ID = '" & strUniqueID & "'" 'OrderName
                        Rep_foundRows = Rep_DT.Select(Rep_Expression)
                        For Each row In Rep_foundRows  'Rep: each row (Unique_ID) of filteredRows--
                            If j = 0 Then
                                strOrderName = row("Unique_ID")
                                strShipTo_Name = CorrectStr(row("REP FIRST NAME")) & " " & CorrectStr(row("REP LAST NAME"))
                                strAddress1 = CorrectStr(row("REP ADDRESS"))
                                If row.IsNull("REP ADDRESS 2") Then
                                    strAddress2 = ""
                                Else
                                    strAddress2 = CorrectStr(row("REP ADDRESS 2"))
                                End If
                                strCity = CorrectStr(row("REP CITY")) : strZipCode = CorrectStr(row("REP ZIP"))
                                strStateName = CorrectStr(row("REP STATE")) : strTel = CorrectStr(row("REP PHONE"))
                                'strRetailer = CorrectStr(row("RETAILER ID"))
                                strProjID = CorrectStr(row("PROJECT")) : strRepID = CorrectStr(row("REPI"))
                                iDR_ID = objDriveLine.InsertDriveLineOrderData_Discrepancy(iCust_ID, strOrderName, strProjID, strRepID, strShipTo_Name, _
                                                                                           strAddress1, strAddress2, strCity, strStateName, strZipCode, strTel, _
                                                                                           CorrectStr(Me._strSourceFileName), strDateTime, iUser_ID, 0)
                            End If
                            j += 1
                            If Not iDR_ID > 0 Then
                                MessageBox.Show("Not a valid iDR_ID or failed to save discrepancy data. See IT.", "SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                            Prod_Expression = "RETAILER='" & row("RETAILER ID") & "' AND [STORE NO] ='" & row("STORE NO") & "'"
                            Prod_foundRows = Prod_DT.Select(Prod_Expression)
                            For Each row2 In Prod_foundRows 'Prod: each row (StoreNo) of filteredRows--- It should be one row
                                strStoreNo = row2("STORE NO") : strProdAddress1 = CorrectStr(row2("ADDRESS 1"))
                                strProdCity = CorrectStr(row2("CITY")) : strProdState = CorrectStr(row2("STATE"))
                                strProdZip = CorrectStr(row2("ZIP")) : strRetailer = CorrectStr(row("RETAILER ID"))
                                iDRStore_ID = 0
                                iDRStore_ID = objDriveLine.InsertDriveLineStoreData_Discrepancy(iDR_ID, strStoreNo, strProdAddress1, "", strProdCity, strProdState, strProdZip, strRetailer)
                                If Not iDRStore_ID > 0 Then
                                    MessageBox.Show("Not a valid DRStore_ID or failed to save discrepancy data. See IT.", "SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                                For k = 0 To Me._arrProdComponentNames.Count - 1 '---- 
                                    strColName = "CP" & k + 1 : strProd = Me._arrProdComponentNames(k) : iDLDetail_ID = 0
                                    If row2.IsNull(strColName) Then
                                        iProdQty = 0
                                    Else
                                        iProdQty = row2(strColName)
                                    End If
                                    If iProdQty > 0 Then
                                        iDLDetail_ID = objDriveLine.InsertDriveLineProdComponentData_Discrepancy(iDR_ID, iDRStore_ID, strProd, iProdQty, strDateTime)
                                        If Not iDLDetail_ID > 0 Then
                                            MessageBox.Show("Not a valid iDLDetail_ID or failed to save discrepancy data.. See IT.", "SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                            Exit Sub
                                        End If
                                    End If
                                Next '----
                            Next 'Prod: each row (StoreNo) of filteredRows---
                            If Prod_foundRows.Length = 0 Then 'not found
                                iDRStore_ID = 0 : iDLDetail_ID = 0
                                iDRStore_ID = objDriveLine.InsertDriveLineStoreData_Discrepancy(iDR_ID, strStoreNo, "", "", "", "", "", "")
                                If Not iDRStore_ID > 0 Then
                                    MessageBox.Show("Not a valid DRStore_ID or failed to save discrepancy data. See IT.", "SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                                iDLDetail_ID = objDriveLine.InsertDriveLineProdComponentData_Discrepancy(iDR_ID, iDRStore_ID, "", 0, strDateTime)
                                If Not iDLDetail_ID > 0 Then
                                    MessageBox.Show("Not a valid DRStore_ID or failed to save discrepancy data. See IT.", "SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub
                                End If
                            End If
                        Next 'Rep: each row (Unique_ID) of filteredRows--
                    Next 'REP: each row of dropped unique id (OrderName) 

                End If

                'No rep data but only component data----------------------------------------------------------------------------------------------------------------------------
                If Me.ListBox_NoRepButProdRowIDs.Items.Count > 0 Then
                    strOrderName = "No Rep data matched" : strProjID = "" : strRetailer = ""
                    iDR_ID = 0 : iDRStore_ID = 0 : iDLDetail_ID = 0
                    For i = 0 To Me._arrDistinctRetailers.Count - 1
                        If i = 0 Then strRetailer = CorrectStr(Me._arrDistinctRetailers(i))
                        If i > 0 Then strRetailer &= "," & CorrectStr(Me._arrDistinctRetailers(i))
                    Next
                    For i = 0 To Me._arrDistinctProjectIDs.Count - 1
                        If i = 0 Then strProjID = CorrectStr(Me._arrDistinctProjectIDs(i))
                        If i > 0 Then strProjID &= "," & CorrectStr(Me._arrDistinctProjectIDs(i))
                    Next
                    iDR_ID = objDriveLine.InsertDriveLineOrderData_Discrepancy(iCust_ID, strOrderName, strProjID, "", "", "", "", "", "", "", "", _
                                                                               CorrectStr(Me._strSourceFileName), strDateTime, iUser_ID, 0)
                    If Not iDR_ID > 0 Then
                        MessageBox.Show("Not a valid DRStore_ID or failed to save discrepancy data. See IT.", "SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    For j = 0 To Me.ListBox_NoRepButProdRowIDs.Items.Count - 1
                        Prod_foundRows = Nothing
                        iRowIdx = Me.ListBox_NoRepButProdRowIDs.Items(j)
                        Prod_Expression = "RawRecID=" & iRowIdx
                        Prod_foundRows = Prod_DT.Select(Prod_Expression) 'should be one row
                        For Each row2 In Prod_foundRows 'Prod: each row (StoreNo) of filteredRows
                            strStoreNo = row2("STORE NO") : strProdAddress1 = CorrectStr(row2("ADDRESS 1"))
                            strProdCity = CorrectStr(row2("CITY")) : strProdState = CorrectStr(row2("STATE"))
                            strProdZip = CorrectStr(row2("ZIP")) : strRetailer = CorrectStr(row2("RETAILER"))
                            iDRStore_ID = 0
                            iDRStore_ID = objDriveLine.InsertDriveLineStoreData_Discrepancy(iDR_ID, strStoreNo, strProdAddress1, "", strProdCity, strProdState, strProdZip, strRetailer)
                            If Not iDRStore_ID > 0 Then
                                MessageBox.Show("Not a valid DRStore_ID or failed to save discrepancy data. See IT.", "SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Exit Sub
                            End If
                            For k = 0 To Me._arrProdComponentNames.Count - 1 '---- 
                                strColName = "CP" & k + 1 : strProd = Me._arrProdComponentNames(k) : iDLDetail_ID = 0
                                If row2.IsNull(strColName) Then
                                    iProdQty = 0
                                Else
                                    iProdQty = row2(strColName)
                                End If
                                If iProdQty > 0 Then
                                    iDLDetail_ID = objDriveLine.InsertDriveLineProdComponentData_Discrepancy(iDR_ID, iDRStore_ID, strProd, iProdQty, strDateTime)
                                    If Not iDLDetail_ID > 0 Then
                                        MessageBox.Show("Not a valid iDLDetail_ID or failed to save discrepancy data.. See IT.", "SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        Exit Sub
                                    End If
                                End If
                            Next '----
                        Next 'Prod: each row (StoreNo) of filteredRows---
                    Next
                End If

                bSaveDisrepancySuccessful = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub SaveDiscrepancyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objDriveLine = Nothing
                Rep_DT = Nothing : Prod_DT = Nothing
                Cursor = Cursors.Default
            End Try
        End Sub

        '******************************************************************
        Private Function CorrectStr(ByVal s As String) As String
            Dim tmpS As String = ""
            Try
                If s.Trim.Length > 0 Then
                    tmpS = s.Replace("'", "''")
                End If
                Return tmpS
            Catch ex As Exception
                Return s
            End Try
        End Function

        '******************************************************************
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            'SetListBoxes(1)
            'Me.ListBox1.Visible = True

            'Dim fm As New frmAddRetailer("MyTest")
            '' Show fm as a modal dialog and determine if DialogResult = OK.
            'If fm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            '    ' Read the contents of fm's TextBox.
            '    MessageBox.Show("yes")
            'Else
            '    MessageBox.Show("no")
            'End If
            'fm.Dispose()

            MessageBox.Show(Me.ListBox_AllKeys.Items.Count)
            MessageBox.Show(Me.ListBox_DropKeys.Items.Count)
        End Sub

        '******************************************************************
        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            'SetListBoxes(2)
            'Me.ListBox1.Visible = True : Me.ListBox2.Visible = True
            'Dim i As Integer

            'For i = 1 To 10
            '    Me.ListBox1.Items.Add("My test1 " & i)
            'Next

            'For i = 1 To 5
            '    Me.ListBox2.Items.Add("My test2 " & i)
            'Next

            'Me.tdgData1.Splits(0).DisplayColumns("RawRecID").DataColumn.FilterText = 2
            'MessageBox.Show(Me.tdgData1.RowCount())
            Dim objDriveLine As PSS.Data.Buisness.DriveLine
            objDriveLine = New PSS.Data.Buisness.DriveLine()
            Dim iRet As Integer = objDriveLine.ClearUpDemoData
            ' If iRet = 4 Then
            MessageBox.Show("Demo data are removed successfully!")
            'Else
            '   MessageBox.Show("Failed to remove demo data!")
            'End If
        End Sub


        '******************************************************************
        Private Sub CreateFormattedData()
            Dim obj As PSS.Data.Buisness.TracFone.Admin
            Dim objDriveLine As PSS.Data.Buisness.DriveLine
            Dim dt As DataTable, dt2 As DataTable, dtRepRetailers As DataTable
            Dim dtProdRetailers As DataTable
            Dim arrRepRetailers As New ArrayList(), arrProdRetailers As New ArrayList()
            Dim arrFinalRetailers As New ArrayList(), tmpArrList As New ArrayList()
            Dim arrNotFound As New ArrayList(), arrNotFoundUniqueIDs As New ArrayList() ', arrUniqueIDs As New ArrayList()
            Dim dtFormatted As DataTable, dtFinalRetailers As DataTable
            Dim row As DataRow, row2 As DataRow, strRetailerName As String = ""
            Dim i As Integer, RepRowsNum As Integer
            Dim S1, S2, strShortName As String

            Try

                Cursor = Cursors.WaitCursor
                Me.btnSaveData.Enabled = False
                Me.ListBox_AllKeys.Items.Clear() : Me.ListBox_DropKeys.Items.Clear()
                Me.ListBox_NoRepButProdRowIDs.Items.Clear()
                Me._arrDistinctProjectIDs.Clear() : Me._arrDistinctRetailers.Clear()

                obj = New PSS.Data.Buisness.TracFone.Admin()

                Me.tdgData1.DataSource = Me._dtRepBackupData 'refresh
                Me.tdgData2.DataSource = Me._dtProdBackupData 'refresh

                'get unique retailers (Based on rep retailers only)---------------------------------
                dt = Me.tdgData1.DataSource 'Rep data
                RepRowsNum = dt.Rows.Count

                dtRepRetailers = obj.SelectDistinct("Retailers", dt, "RETAILER ID")
                'dt = Me.tdgData2.DataSource 'Prod Data
                'dtProdRetailers = obj.SelectDistinct("Retailers", dt, "RETAILER")

                'debug
                'Me.DataGrid3.DataSource = dtRepRetailers : Me.DataGrid4.DataSource = dtProdRetailers

                For Each row In dtRepRetailers.Rows
                    strRetailerName = row("RETAILER ID")
                    arrRepRetailers.Add(strRetailerName.Trim)
                    Me._arrDistinctRetailers.Add(strRetailerName.Trim)
                Next
                'For Each row In dtProdRetailers.Rows
                '    strRetailerName = row("RETAILER")
                '    arrProdRetailers.Add(strRetailerName.Trim)
                'Next

                For Each row In obj.SelectDistinct("ProjectIDs", dt, "PROJECT").Rows
                    Me._arrDistinctProjectIDs.Add(row("PROJECT"))
                Next

                'Get retailer shortname and create it if it is new retailer---------------------------------
                'No need 2013-08-05---------
                'objDriveLine = New PSS.Data.Buisness.DriveLine()
                'dtFinalRetailers = objDriveLine.RetailersTableDefinition
                'For i = 0 To arrRepRetailers.Count - 1
                '    strRetailerName = arrRepRetailers(i)
                '    arrFinalRetailers = objDriveLine.FoundDriveLineRetailerShortName(strRetailerName)
                '    If arrFinalRetailers.Count = 0 Then
                '        Dim fm As New frmAddRetailer(strRetailerName)
                '        If fm.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                '            row = dtFinalRetailers.NewRow
                '            row("RetailerShortName") = fm.lblDefinedShortName.Text
                '            row("RetailerFullName") = strRetailerName
                '            dtFinalRetailers.Rows.Add(row)
                '            fm.Dispose()
                '        Else
                '            MessageBox.Show("Retailer Short Name is not defined!. Plese try again.", "CreateFormattedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '            Exit Sub
                '        End If
                '    ElseIf arrFinalRetailers.Count = 1 Then
                '        row = dtFinalRetailers.NewRow
                '        row("RetailerShortName") = arrFinalRetailers(0) 'first one
                '        row("RetailerFullName") = strRetailerName
                '        dtFinalRetailers.Rows.Add(row)
                '    Else
                '        MessageBox.Show("Found duplicatedr retailer names! See IT. ", "CreateFormattedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Exit Sub
                '    End If
                'Next
                '----------------------------

                ' Me.DataGrid4.DataSource = dtFinalRetailers 'debug

                'Add new column to datatable ---------------------------------
                dtFormatted = AddColumnToRepDatatable(dt)
                If Not dtFormatted.Rows.Count = RepRowsNum Then
                    MessageBox.Show("Raw data and and formatted data are not the same count of rows! See IT. ", "CreateFormattedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'Rebind data---------------------------------
                Me.tdgData1.DataSource = dtFormatted
                Me.tdgData1.Splits(0).DisplayColumns("RawRecID").Width = 60
                Me.tdgData1.Splits(0).DisplayColumns("Unique_ID").Width = 130
                Me.lblRecNo1.Text = "Total Records: " & dtFormatted.Rows.Count

                ''Fill Unique_IDs---------------------------------
                'No need 2013-08-05
                'For Each row In dtFormatted.Rows
                '    For Each row2 In dtFinalRetailers.Rows
                '        S1 = row2("RetailerFullName") : S2 = row("RETAILER ID")
                '        If S1.Trim.ToUpper = S2.Trim.ToUpper Then
                '            strShortName = row2("RetailerShortName")
                '            Exit For
                '        End If
                '    Next
                '    If Not strShortName.Trim.Length > 0 Then
                '        MessageBox.Show("Can't find retailer short name! See IT. ", "CreateFormattedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Exit Sub
                '    End If

                '    row("Unique_ID") = strShortName & row("PROJECT") & "-" & row("REPI")
                'Next
                'Changed to this 2013-08-05-----------
                For Each row In dtFormatted.Rows
                    row("Unique_ID") = row("PROJECT") & "-" & row("REPI")
                Next

                'Validate data: Rep Data---------------------------------
                dt2 = Me.tdgData2.DataSource
                For Each row In dt2.Rows 'for each row in Prod data
                    S1 = row("RETAILER") : S2 = row("STORE NO")
                    tmpArrList.Add(S1.Trim.ToUpper & S2.Trim.ToUpper)
                Next
                For Each row In dtFormatted.Rows 'for each row in Rep data
                    S1 = row("RETAILER ID") : S2 = row("STORE NO")
                    If Not tmpArrList.Contains(S1.Trim.ToUpper & S2.Trim.ToUpper) Then
                        arrNotFound.Add(row("RawRecID")) 'keep rawRecID
                        If Not arrNotFoundUniqueIDs.Contains(row("Unique_ID")) Then
                            arrNotFoundUniqueIDs.Add(row("Unique_ID"))
                            Me.ListBox_DropKeys.Items.Add(row("Unique_ID"))
                        End If
                    End If
                Next
                If arrNotFound.Count > 0 Then
                    For i = 0 To arrNotFound.Count - 1
                        If i = 0 Then S1 = arrNotFound(i) Else S1 &= "," & arrNotFound(i)
                        Me.tdgData1.SelectedRows.Add(arrNotFound(i) - 1) 'select row
                    Next
                    For i = 0 To arrNotFoundUniqueIDs.Count - 1
                        If i = 0 Then S2 = arrNotFoundUniqueIDs(i) Else S2 &= "," & arrNotFoundUniqueIDs(i)
                    Next
                    S1 &= ". No Component Data matching" & Environment.NewLine & "Data for " & S2 & " will be stored in discrepancy tables while saving!"
                    MessageBox.Show("Rep Data rows (highlighted): " & S1, "CreateFormattedData", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                'Validate data: Prod Data (Component data)---------------------------------
                tmpArrList.Clear() : arrNotFound.Clear() : arrNotFoundUniqueIDs.Clear()
                For Each row In dtFormatted.Rows 'for each row in Rep data
                    S1 = row("RETAILER ID") : S2 = row("STORE NO")
                    tmpArrList.Add(S1.Trim.ToUpper & S2.Trim.ToUpper)
                Next
                For Each row In dt2.Rows 'for each row in Prod data
                    S1 = row("RETAILER") : S2 = row("STORE NO")
                    If Not tmpArrList.Contains(S1.Trim.ToUpper & S2.Trim.ToUpper) Then
                        arrNotFound.Add(row("RawRecID")) 'keep rawRecID
                    End If
                Next
                If arrNotFound.Count > 0 Then
                    For i = 0 To arrNotFound.Count - 1
                        If i = 0 Then S1 = arrNotFound(i) Else S1 &= "," & arrNotFound(i)
                        Me.tdgData2.SelectedRows.Add(arrNotFound(i) - 1) 'select row
                        Me.ListBox_NoRepButProdRowIDs.Items.Add(arrNotFound(i))
                    Next
                    S1 &= ". No Rep Data matching!" & Environment.NewLine & "These component data will be stored in discrepancy tables while saving!"
                    MessageBox.Show("Component Data rows (highlighted): " & S1, "CreateFormattedData", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                'Get unique id list---------------------------------
                For Each row In obj.SelectDistinct("UniqueIDs", dtFormatted, "Unique_ID").Rows
                    'arrUniqueIDs.Add(row("Unique_ID"))
                    Me.ListBox_AllKeys.Items.Add(row("Unique_ID"))
                Next

                'debug
                'For i = 0 To arrUniqueIDs.Count - 1
                'Me.DataGrid1.DataSource = obj.SelectDistinct("UniqueIDs", dtFormatted, "Unique_ID")
                ' Next

                Me.btnSaveData.Enabled = True

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " CreateFormattedData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                obj = Nothing : objDriveLine = Nothing
                dt = Nothing : dt2 = Nothing
                Cursor = Cursors.Default
            End Try

        End Sub

        Private Function AddColumnToRepDatatable(ByVal repDataTable As DataTable) As DataTable
            Dim columnOrder() As Integer, i As Integer
            Dim objDriveLine As PSS.Data.Buisness.DriveLine
            Dim local_dt As DataTable

            Try
                objDriveLine = New PSS.Data.Buisness.DriveLine()

                local_dt = repDataTable.Copy
                'Add a column
                Dim newColumn As New DataColumn("Unique_ID", GetType(System.String))
                ' newColumn.DefaultValue = "Your DropDownList value"
                local_dt.Columns.Add(newColumn)

                'Reorder columns: move the last one to the first
                ReDim columnOrder(local_dt.Columns.Count - 1)
                For i = 0 To local_dt.Columns.Count - 1
                    If i = 0 Then
                        columnOrder(i) = local_dt.Columns.Count - 1
                    Else
                        columnOrder(i) = i - 1
                    End If
                Next

                Return objDriveLine.ReOrderTable(local_dt, columnOrder)

                'i = dt.Columns("Unique_ID").Ordinal() 'get ordinal 
            Catch ex As Exception
                Return Nothing
                MessageBox.Show(ex.ToString, " CreateFormatedRepDatatable", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objDriveLine = Nothing
            End Try
        End Function

        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
            Dim dt As DataTable = Me.tdgData1.DataSource
            Dim Rep_FilteredDT As DataTable, Prod_FilteredDT As DataTable
            Dim Rep_foundRows As DataRow(), Prod_foundRows As DataRow()
            Dim row As DataRow, row2 As DataRow
            Dim strStoreNo As String = ""

            Dim strRetailer As String = "", strRep As String = "", strProj As String = ""

            Try

                strRetailer = Me.TextBox1.Text : strProj = Me.TextBox2.Text : strRep = Me.TextBox3.Text

                Me.tdgData1.Splits(0).DisplayColumns("RETAILER ID").DataColumn.FilterText = strRetailer
                Me.tdgData1.Splits(0).DisplayColumns("PROJECT").DataColumn.FilterText = strProj
                Me.tdgData1.Splits(0).DisplayColumns("REPI").DataColumn.FilterText = strRep
                Dim Rep_Expression As String = "[RETAILER ID] = '" & strRetailer & _
                                            "' And PROJECT = '" & strProj & _
                                            "' And REPI = '" & strRep & "'"
                Rep_foundRows = dt.Select(Rep_Expression)
                Rep_FilteredDT = dt.Clone
                For Each row In Rep_foundRows
                    Rep_FilteredDT.ImportRow(row)
                Next
                Me.DataGrid1.DataSource = Rep_FilteredDT


                dt = Me.tdgData2.DataSource
                Prod_FilteredDT = dt.Clone
                For Each row In Rep_FilteredDT.Rows
                    strStoreNo = row("STORE NO")
                    Dim Prod_Expression As String = "[STORE NO] = '" & strStoreNo & "'"
                    Prod_foundRows = dt.Select(Prod_Expression)
                    For Each row2 In Prod_foundRows
                        Prod_FilteredDT.ImportRow(row2)
                    Next
                Next
                Me.DataGrid2.DataSource = Prod_FilteredDT

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Button3_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
            CreateFormattedData()
        End Sub


        Private Sub btnConfirmData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirmData.Click
            CreateFormattedData()
        End Sub


        Private Sub btnListComponents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListComponents.Click
            Try
                Dim strList As String = "Product Component List:"
                Dim i As Integer
                For i = 0 To Me.ListBox1.Items.Count - 1
                    strList &= Environment.NewLine & Me.ListBox1.Items(i)
                Next
                MessageBox.Show(strList, "Product Component List", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnListComponents_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        'Function AppendFixed(ByVal b As StringBuilder, ByVal s As String, ByVal width As Integer) As StringBuilder
        '    If s.Length >= width Then
        '        b.Append(s, 0, width)
        '    Else
        '        b.Append(s)
        '        b.Append(" ", width - s.Length)
        '    End If
        '    Return b
        'End Function

    End Class
End Namespace
