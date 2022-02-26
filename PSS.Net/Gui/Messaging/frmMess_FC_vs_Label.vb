Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmMess_FC_vs_Label
        Inherits System.Windows.Forms.Form

        Dim objExcelRpt As New PSS.Data.Buisness.MessReports()


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
        Friend WithEvents tpFCVsLQP As System.Windows.Forms.TabPage
        Friend WithEvents tpMain As System.Windows.Forms.TabControl
        Friend WithEvents tpFCvsLabelQCProduce As System.Windows.Forms.TabPage
        Friend WithEvents btnFCvsLQP_CopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnFCvsLQP_CopyAll As System.Windows.Forms.Button
        Friend WithEvents dbgFCvsLQP_Data As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnFCvsLQPSum_CopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnFCvsLQPSum_CopyAll As System.Windows.Forms.Button
        Friend WithEvents btnFCvsLQPSum_Refresh As System.Windows.Forms.Button
        Friend WithEvents dbgFCvsLQPSum_Data As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnFCvsLQP_Refresh As System.Windows.Forms.Button
        Friend WithEvents tpgFCvsDShip As System.Windows.Forms.TabPage
        Friend WithEvents btnFCvsDShip_CopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnFCvsDShip_CopyAll As System.Windows.Forms.Button
        Friend WithEvents btnFCvsDShip_Refresh As System.Windows.Forms.Button
        Friend WithEvents dbgFCvsDShip_Data As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents chkFCvsLQP_IncProduceWip As System.Windows.Forms.CheckBox
        Friend WithEvents chkFCvsDShip_IncMonthData As System.Windows.Forms.CheckBox
        Friend WithEvents chkFCvsDShip_IncProduceWip As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMess_FC_vs_Label))
            Me.tpMain = New System.Windows.Forms.TabControl()
            Me.tpFCvsLabelQCProduce = New System.Windows.Forms.TabPage()
            Me.chkFCvsLQP_IncProduceWip = New System.Windows.Forms.CheckBox()
            Me.btnFCvsLQP_CopySelectedRows = New System.Windows.Forms.Button()
            Me.btnFCvsLQP_CopyAll = New System.Windows.Forms.Button()
            Me.btnFCvsLQP_Refresh = New System.Windows.Forms.Button()
            Me.dbgFCvsLQP_Data = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpFCVsLQP = New System.Windows.Forms.TabPage()
            Me.btnFCvsLQPSum_CopySelectedRows = New System.Windows.Forms.Button()
            Me.btnFCvsLQPSum_CopyAll = New System.Windows.Forms.Button()
            Me.btnFCvsLQPSum_Refresh = New System.Windows.Forms.Button()
            Me.dbgFCvsLQPSum_Data = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgFCvsDShip = New System.Windows.Forms.TabPage()
            Me.chkFCvsDShip_IncProduceWip = New System.Windows.Forms.CheckBox()
            Me.chkFCvsDShip_IncMonthData = New System.Windows.Forms.CheckBox()
            Me.btnFCvsDShip_CopySelectedRows = New System.Windows.Forms.Button()
            Me.btnFCvsDShip_CopyAll = New System.Windows.Forms.Button()
            Me.btnFCvsDShip_Refresh = New System.Windows.Forms.Button()
            Me.dbgFCvsDShip_Data = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpMain.SuspendLayout()
            Me.tpFCvsLabelQCProduce.SuspendLayout()
            CType(Me.dbgFCvsLQP_Data, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpFCVsLQP.SuspendLayout()
            CType(Me.dbgFCvsLQPSum_Data, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgFCvsDShip.SuspendLayout()
            CType(Me.dbgFCvsDShip_Data, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'tpMain
            '
            Me.tpMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tpMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpFCvsLabelQCProduce, Me.tpFCVsLQP, Me.tpgFCvsDShip})
            Me.tpMain.Location = New System.Drawing.Point(16, 8)
            Me.tpMain.Name = "tpMain"
            Me.tpMain.SelectedIndex = 0
            Me.tpMain.Size = New System.Drawing.Size(840, 504)
            Me.tpMain.TabIndex = 0
            '
            'tpFCvsLabelQCProduce
            '
            Me.tpFCvsLabelQCProduce.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkFCvsLQP_IncProduceWip, Me.btnFCvsLQP_CopySelectedRows, Me.btnFCvsLQP_CopyAll, Me.btnFCvsLQP_Refresh, Me.dbgFCvsLQP_Data})
            Me.tpFCvsLabelQCProduce.Location = New System.Drawing.Point(4, 22)
            Me.tpFCvsLabelQCProduce.Name = "tpFCvsLabelQCProduce"
            Me.tpFCvsLabelQCProduce.Size = New System.Drawing.Size(832, 478)
            Me.tpFCvsLabelQCProduce.TabIndex = 2
            Me.tpFCvsLabelQCProduce.Text = "FC vs Label QC Produce"
            '
            'chkFCvsLQP_IncProduceWip
            '
            Me.chkFCvsLQP_IncProduceWip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkFCvsLQP_IncProduceWip.Location = New System.Drawing.Point(216, 21)
            Me.chkFCvsLQP_IncProduceWip.Name = "chkFCvsLQP_IncProduceWip"
            Me.chkFCvsLQP_IncProduceWip.Size = New System.Drawing.Size(160, 16)
            Me.chkFCvsLQP_IncProduceWip.TabIndex = 110
            Me.chkFCvsLQP_IncProduceWip.Text = "Include Produce Wip"
            '
            'btnFCvsLQP_CopySelectedRows
            '
            Me.btnFCvsLQP_CopySelectedRows.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsLQP_CopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsLQP_CopySelectedRows.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsLQP_CopySelectedRows.Location = New System.Drawing.Point(640, 16)
            Me.btnFCvsLQP_CopySelectedRows.Name = "btnFCvsLQP_CopySelectedRows"
            Me.btnFCvsLQP_CopySelectedRows.Size = New System.Drawing.Size(160, 23)
            Me.btnFCvsLQP_CopySelectedRows.TabIndex = 109
            Me.btnFCvsLQP_CopySelectedRows.TabStop = False
            Me.btnFCvsLQP_CopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnFCvsLQP_CopyAll
            '
            Me.btnFCvsLQP_CopyAll.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsLQP_CopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsLQP_CopyAll.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsLQP_CopyAll.Location = New System.Drawing.Point(528, 16)
            Me.btnFCvsLQP_CopyAll.Name = "btnFCvsLQP_CopyAll"
            Me.btnFCvsLQP_CopyAll.Size = New System.Drawing.Size(104, 23)
            Me.btnFCvsLQP_CopyAll.TabIndex = 108
            Me.btnFCvsLQP_CopyAll.TabStop = False
            Me.btnFCvsLQP_CopyAll.Text = "Copy All Rows"
            '
            'btnFCvsLQP_Refresh
            '
            Me.btnFCvsLQP_Refresh.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsLQP_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsLQP_Refresh.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsLQP_Refresh.Location = New System.Drawing.Point(392, 16)
            Me.btnFCvsLQP_Refresh.Name = "btnFCvsLQP_Refresh"
            Me.btnFCvsLQP_Refresh.Size = New System.Drawing.Size(96, 24)
            Me.btnFCvsLQP_Refresh.TabIndex = 107
            Me.btnFCvsLQP_Refresh.TabStop = False
            Me.btnFCvsLQP_Refresh.Text = "Refresh"
            '
            'dbgFCvsLQP_Data
            '
            Me.dbgFCvsLQP_Data.AllowUpdate = False
            Me.dbgFCvsLQP_Data.AlternatingRows = True
            Me.dbgFCvsLQP_Data.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgFCvsLQP_Data.BackColor = System.Drawing.Color.GhostWhite
            Me.dbgFCvsLQP_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgFCvsLQP_Data.FetchRowStyles = True
            Me.dbgFCvsLQP_Data.FilterBar = True
            Me.dbgFCvsLQP_Data.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgFCvsLQP_Data.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgFCvsLQP_Data.Location = New System.Drawing.Point(24, 48)
            Me.dbgFCvsLQP_Data.Name = "dbgFCvsLQP_Data"
            Me.dbgFCvsLQP_Data.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgFCvsLQP_Data.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgFCvsLQP_Data.PreviewInfo.ZoomFactor = 75
            Me.dbgFCvsLQP_Data.Size = New System.Drawing.Size(784, 352)
            Me.dbgFCvsLQP_Data.TabIndex = 106
            Me.dbgFCvsLQP_Data.TabStop = False
            Me.dbgFCvsLQP_Data.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>350</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 782, 350</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 782, 350</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tpFCVsLQP
            '
            Me.tpFCVsLQP.BackColor = System.Drawing.Color.SteelBlue
            Me.tpFCVsLQP.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnFCvsLQPSum_CopySelectedRows, Me.btnFCvsLQPSum_CopyAll, Me.btnFCvsLQPSum_Refresh, Me.dbgFCvsLQPSum_Data})
            Me.tpFCVsLQP.Location = New System.Drawing.Point(4, 22)
            Me.tpFCVsLQP.Name = "tpFCVsLQP"
            Me.tpFCVsLQP.Size = New System.Drawing.Size(832, 478)
            Me.tpFCVsLQP.TabIndex = 1
            Me.tpFCVsLQP.Text = "FC vs LQP"
            '
            'btnFCvsLQPSum_CopySelectedRows
            '
            Me.btnFCvsLQPSum_CopySelectedRows.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsLQPSum_CopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsLQPSum_CopySelectedRows.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsLQPSum_CopySelectedRows.Location = New System.Drawing.Point(640, 16)
            Me.btnFCvsLQPSum_CopySelectedRows.Name = "btnFCvsLQPSum_CopySelectedRows"
            Me.btnFCvsLQPSum_CopySelectedRows.Size = New System.Drawing.Size(160, 23)
            Me.btnFCvsLQPSum_CopySelectedRows.TabIndex = 105
            Me.btnFCvsLQPSum_CopySelectedRows.TabStop = False
            Me.btnFCvsLQPSum_CopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnFCvsLQPSum_CopyAll
            '
            Me.btnFCvsLQPSum_CopyAll.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsLQPSum_CopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsLQPSum_CopyAll.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsLQPSum_CopyAll.Location = New System.Drawing.Point(528, 16)
            Me.btnFCvsLQPSum_CopyAll.Name = "btnFCvsLQPSum_CopyAll"
            Me.btnFCvsLQPSum_CopyAll.Size = New System.Drawing.Size(104, 23)
            Me.btnFCvsLQPSum_CopyAll.TabIndex = 104
            Me.btnFCvsLQPSum_CopyAll.TabStop = False
            Me.btnFCvsLQPSum_CopyAll.Text = "Copy All Rows"
            '
            'btnFCvsLQPSum_Refresh
            '
            Me.btnFCvsLQPSum_Refresh.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsLQPSum_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsLQPSum_Refresh.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsLQPSum_Refresh.Location = New System.Drawing.Point(392, 16)
            Me.btnFCvsLQPSum_Refresh.Name = "btnFCvsLQPSum_Refresh"
            Me.btnFCvsLQPSum_Refresh.Size = New System.Drawing.Size(96, 24)
            Me.btnFCvsLQPSum_Refresh.TabIndex = 103
            Me.btnFCvsLQPSum_Refresh.TabStop = False
            Me.btnFCvsLQPSum_Refresh.Text = "Refresh"
            '
            'dbgFCvsLQPSum_Data
            '
            Me.dbgFCvsLQPSum_Data.AllowUpdate = False
            Me.dbgFCvsLQPSum_Data.AlternatingRows = True
            Me.dbgFCvsLQPSum_Data.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgFCvsLQPSum_Data.BackColor = System.Drawing.Color.GhostWhite
            Me.dbgFCvsLQPSum_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgFCvsLQPSum_Data.FetchRowStyles = True
            Me.dbgFCvsLQPSum_Data.FilterBar = True
            Me.dbgFCvsLQPSum_Data.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgFCvsLQPSum_Data.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgFCvsLQPSum_Data.Location = New System.Drawing.Point(24, 48)
            Me.dbgFCvsLQPSum_Data.Name = "dbgFCvsLQPSum_Data"
            Me.dbgFCvsLQPSum_Data.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgFCvsLQPSum_Data.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgFCvsLQPSum_Data.PreviewInfo.ZoomFactor = 75
            Me.dbgFCvsLQPSum_Data.Size = New System.Drawing.Size(784, 376)
            Me.dbgFCvsLQPSum_Data.TabIndex = 102
            Me.dbgFCvsLQPSum_Data.TabStop = False
            Me.dbgFCvsLQPSum_Data.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>374</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 782, 374</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 782, 374</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tpgFCvsDShip
            '
            Me.tpgFCvsDShip.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgFCvsDShip.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkFCvsDShip_IncProduceWip, Me.chkFCvsDShip_IncMonthData, Me.btnFCvsDShip_CopySelectedRows, Me.btnFCvsDShip_CopyAll, Me.btnFCvsDShip_Refresh, Me.dbgFCvsDShip_Data})
            Me.tpgFCvsDShip.Location = New System.Drawing.Point(4, 22)
            Me.tpgFCvsDShip.Name = "tpgFCvsDShip"
            Me.tpgFCvsDShip.Size = New System.Drawing.Size(832, 478)
            Me.tpgFCvsDShip.TabIndex = 0
            Me.tpgFCvsDShip.Text = "FC vs Dock Ship"
            '
            'chkFCvsDShip_IncProduceWip
            '
            Me.chkFCvsDShip_IncProduceWip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkFCvsDShip_IncProduceWip.Location = New System.Drawing.Point(88, 21)
            Me.chkFCvsDShip_IncProduceWip.Name = "chkFCvsDShip_IncProduceWip"
            Me.chkFCvsDShip_IncProduceWip.Size = New System.Drawing.Size(136, 16)
            Me.chkFCvsDShip_IncProduceWip.TabIndex = 112
            Me.chkFCvsDShip_IncProduceWip.Text = "Include Produce Wip"
            '
            'chkFCvsDShip_IncMonthData
            '
            Me.chkFCvsDShip_IncMonthData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkFCvsDShip_IncMonthData.Location = New System.Drawing.Point(240, 21)
            Me.chkFCvsDShip_IncMonthData.Name = "chkFCvsDShip_IncMonthData"
            Me.chkFCvsDShip_IncMonthData.Size = New System.Drawing.Size(136, 16)
            Me.chkFCvsDShip_IncMonthData.TabIndex = 111
            Me.chkFCvsDShip_IncMonthData.Text = "Include Month Data"
            '
            'btnFCvsDShip_CopySelectedRows
            '
            Me.btnFCvsDShip_CopySelectedRows.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsDShip_CopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsDShip_CopySelectedRows.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsDShip_CopySelectedRows.Location = New System.Drawing.Point(640, 16)
            Me.btnFCvsDShip_CopySelectedRows.Name = "btnFCvsDShip_CopySelectedRows"
            Me.btnFCvsDShip_CopySelectedRows.Size = New System.Drawing.Size(160, 23)
            Me.btnFCvsDShip_CopySelectedRows.TabIndex = 101
            Me.btnFCvsDShip_CopySelectedRows.TabStop = False
            Me.btnFCvsDShip_CopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnFCvsDShip_CopyAll
            '
            Me.btnFCvsDShip_CopyAll.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsDShip_CopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsDShip_CopyAll.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsDShip_CopyAll.Location = New System.Drawing.Point(528, 16)
            Me.btnFCvsDShip_CopyAll.Name = "btnFCvsDShip_CopyAll"
            Me.btnFCvsDShip_CopyAll.Size = New System.Drawing.Size(104, 23)
            Me.btnFCvsDShip_CopyAll.TabIndex = 100
            Me.btnFCvsDShip_CopyAll.TabStop = False
            Me.btnFCvsDShip_CopyAll.Text = "Copy All Rows"
            '
            'btnFCvsDShip_Refresh
            '
            Me.btnFCvsDShip_Refresh.BackColor = System.Drawing.SystemColors.Control
            Me.btnFCvsDShip_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFCvsDShip_Refresh.ForeColor = System.Drawing.Color.Black
            Me.btnFCvsDShip_Refresh.Location = New System.Drawing.Point(392, 16)
            Me.btnFCvsDShip_Refresh.Name = "btnFCvsDShip_Refresh"
            Me.btnFCvsDShip_Refresh.Size = New System.Drawing.Size(96, 24)
            Me.btnFCvsDShip_Refresh.TabIndex = 99
            Me.btnFCvsDShip_Refresh.TabStop = False
            Me.btnFCvsDShip_Refresh.Text = "Refresh"
            '
            'dbgFCvsDShip_Data
            '
            Me.dbgFCvsDShip_Data.AllowUpdate = False
            Me.dbgFCvsDShip_Data.AlternatingRows = True
            Me.dbgFCvsDShip_Data.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgFCvsDShip_Data.BackColor = System.Drawing.Color.GhostWhite
            Me.dbgFCvsDShip_Data.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgFCvsDShip_Data.FetchRowStyles = True
            Me.dbgFCvsDShip_Data.FilterBar = True
            Me.dbgFCvsDShip_Data.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgFCvsDShip_Data.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgFCvsDShip_Data.Location = New System.Drawing.Point(24, 48)
            Me.dbgFCvsDShip_Data.Name = "dbgFCvsDShip_Data"
            Me.dbgFCvsDShip_Data.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgFCvsDShip_Data.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgFCvsDShip_Data.PreviewInfo.ZoomFactor = 75
            Me.dbgFCvsDShip_Data.Size = New System.Drawing.Size(784, 376)
            Me.dbgFCvsDShip_Data.TabIndex = 48
            Me.dbgFCvsDShip_Data.TabStop = False
            Me.dbgFCvsDShip_Data.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>374</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 782, 374</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 782, 374</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmMess_FC_vs_Label
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(888, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpMain})
            Me.Name = "frmMess_FC_vs_Label"
            Me.Text = "frmMess_FC_vs_Label"
            Me.tpMain.ResumeLayout(False)
            Me.tpFCvsLabelQCProduce.ResumeLayout(False)
            CType(Me.dbgFCvsLQP_Data, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpFCVsLQP.ResumeLayout(False)
            CType(Me.dbgFCvsLQPSum_Data, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgFCvsDShip.ResumeLayout(False)
            CType(Me.dbgFCvsDShip_Data, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


#Region "FC vs LQP Sum"

        '****************************************************************************************************************************
        Private Sub LoadForecastVsLQP_sum()
            Dim dt As DataTable
            Dim dv As DataView
            Dim row As DataRow
            Dim dtPrep As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dtPrep = objExcelRpt.RunMessWkMonthlyFCVersusLQP_Sum(True)
                dv = dtPrep.DefaultView
                dv.Sort = "Customer,Location,Model,Frequency,[Baud Rate]"
                dt = dtPrep.Clone
                Dim rowView
                For Each rowView In dv
                    row = rowView.Row
                    dt.ImportRow(row)
                Next

                With Me.dbgFCvsLQPSum_Data
                    'Record filter
                    R1 = dt.NewRow
                    For i = 0 To .Columns.Count - 1
                        If .Columns(i).FilterText.Trim.Length > 0 Then R1(.Columns(i).Caption) = .Columns(i).FilterText
                    Next i

                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                        'add filter back to datagrid
                        If Not IsDBNull(R1(dbgc.Name)) Then .Columns(dbgc.Name).FilterText = R1(dbgc.Name)
                    Next dbgc

                    .Splits(0).DisplayColumns("UniqueID").Visible = False

                End With
            Catch ex As Exception
                Throw ex
            Finally
                dv = Nothing
                Generic.DisposeDT(dtPrep)
                Generic.DisposeDT(dt) : dbgc = Nothing
            End Try
        End Sub

        '****************************************************************************************************************************
        Private Sub btnFCvsLQPSum_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCvsLQPSum_Refresh.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                LoadForecastVsLQP_sum()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************************
        Private Sub btnFCvsLQPSum_Copies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCvsLQPSum_CopySelectedRows.Click, btnFCvsLQPSum_CopyAll.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If sender.name = "btnFCvsLQPSum_CopyAll" Then
                    Misc.CopyAllData(Me.dbgFCvsLQPSum_Data)
                ElseIf sender.name = "btnFCvsLQPSum_CopySelectedRows" Then
                    Misc.CopySelectedRowsData(Me.dbgFCvsLQPSum_Data)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************************

#End Region

#Region "FC vs LQP"

        '****************************************************************************************************************************
        Private Sub LoadForecastVsLQP()
            Dim dt As DataTable
            Dim dv As DataView
            Dim row As DataRow
            Dim dtPrep As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dtPrep = objExcelRpt.RunMessWkMonthlyFCVersusLQP(True, chkFCvsLQP_IncProduceWip.Checked)
                dv = dtPrep.DefaultView
                dv.Sort = "Customer,Location,Model,Frequency,[Baud Rate]"
                dt = dtPrep.Clone
                Dim rowView
                For Each rowView In dv
                    row = rowView.Row
                    dt.ImportRow(row)
                Next

                With Me.dbgFCvsLQP_Data
                    'Record filter
                    R1 = dt.NewRow
                    For i = 0 To .Columns.Count - 1
                        If .Columns(i).FilterText.Trim.Length > 0 Then R1(.Columns(i).Caption) = .Columns(i).FilterText
                    Next i

                    .DataSource = Nothing
                    .DataSource = dt.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()


                        'add filter back to datagrid
                        If Not IsDBNull(R1(dbgc.Name)) Then .Columns(dbgc.Name).FilterText = R1(dbgc.Name)
                    Next dbgc

                    .Splits(0).DisplayColumns("UniqueID").Visible = False
                    .Splits(0).DisplayColumns("Produce Wip").Visible = Me.chkFCvsLQP_IncProduceWip.Checked
                End With
            Catch ex As Exception
                Throw ex
            Finally
                dv = Nothing
                Generic.DisposeDT(dtPrep)
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************************
        Private Sub btnFCvsLQP_Refresh_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCvsLQP_Refresh.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                LoadForecastVsLQP()
                Me.chkFCvsLQP_IncProduceWip.Checked = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************************
        Private Sub btnFCvsLQP_Copies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCvsLQP_CopySelectedRows.Click, btnFCvsLQP_CopyAll.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If sender.name = "btnFCvsLQP_CopyAll" Then
                    Misc.CopyAllData(Me.dbgFCvsLQP_Data)
                ElseIf sender.name = "btnFCVsLblQcProd_CopySelectedRows" Then
                    Misc.CopySelectedRowsData(Me.dbgFCvsLQP_Data)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************************

#End Region

#Region "FC vs Dock Ship"

        '****************************************************************************************************************************
        Private Sub LoadForecastVsDShip()
            Dim dt As DataTable
            Dim dv As DataView
            Dim row As DataRow
            Dim dtPrep As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dtPrep = objExcelRpt.RunMessForcastVersusDockShip(True, Me.chkFCvsDShip_IncProduceWip.Checked, Me.chkFCvsDShip_IncMonthData.Checked)
                dv = dtPrep.DefaultView
                dv.Sort = "Customer,Location,Model,Frequency,[Baud Rate]"
                dt = dtPrep.Clone
                Dim rowView
                For Each rowView In dv
                    row = rowView.Row
                    dt.ImportRow(row)
                Next

                With Me.dbgFCvsDShip_Data
                    'Record filter
                    R1 = dt.NewRow
                    For i = 0 To .Columns.Count - 1
                        If .Columns(i).FilterText.Trim.Length > 0 Then R1(.Columns(i).Caption) = .Columns(i).FilterText
                    Next i

                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                        'add filter back to datagrid
                        If Not IsDBNull(R1(dbgc.Name)) Then .Columns(dbgc.Name).FilterText = R1(dbgc.Name)
                    Next dbgc

                    .Splits(0).DisplayColumns("UniqueID").Visible = False
                    .Splits(0).DisplayColumns("Produce Wip").Visible = Me.chkFCvsDShip_IncProduceWip.Checked
                    .Splits(0).DisplayColumns("Produce Wip").Visible = Me.chkFCvsDShip_IncMonthData.Checked
                End With
            Catch ex As Exception
                Throw ex
            Finally
                dv = Nothing
                Generic.DisposeDT(dtPrep)
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************************
        Private Sub btnFCvsDShip_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCvsDShip_Refresh.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                LoadForecastVsDShip()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************************
        Private Sub btnFCvsDShip_CopyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFCvsDShip_CopySelectedRows.Click, btnFCvsDShip_CopyAll.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If sender.name = "btnFCvsDShip_CopyAll" Then
                    Misc.CopyAllData(Me.dbgFCvsDShip_Data)
                ElseIf sender.name = "btnFCvsDShip_CopySelectedRows" Then
                    Misc.CopySelectedRowsData(Me.dbgFCvsDShip_Data)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, sender.name & "_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************************************

#End Region

    End Class
End Namespace