Option Explicit On 

Imports C1.Win.C1TrueDBGrid

Public Class frmRefurbAudit
    Inherits System.Windows.Forms.Form
    Private GobjRefurbAuditor As PSS.Data.Buisness.RefurbAuditor

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GobjRefurbAuditor = New PSS.Data.Buisness.RefurbAuditor()
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
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdStopTimer As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpStartDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbUser As PSS.Gui.Controls.ComboBox
    Friend WithEvents dtpEndDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdModels As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdGO As System.Windows.Forms.Button
    Friend WithEvents grdpartSummary As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCellLine As PSS.Gui.Controls.ComboBox
    Friend WithEvents cmbGroup As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRefurbAudit))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbCellLine = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbGroup = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpEndDt = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpStartDt = New System.Windows.Forms.DateTimePicker()
        Me.cmdGO = New System.Windows.Forms.Button()
        Me.cmbUser = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdStopTimer = New System.Windows.Forms.Button()
        Me.grdModels = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdpartSummary = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.grdModels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdpartSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeader.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(280, 40)
        Me.lblHeader.TabIndex = 2
        Me.lblHeader.Text = "REFURB AUDITOR"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbCellLine, Me.Label5, Me.cmbGroup, Me.Label2, Me.Label1, Me.dtpEndDt, Me.Label4, Me.dtpStartDt, Me.cmdGO, Me.cmbUser, Me.Label3, Me.cmdStopTimer})
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(280, 456)
        Me.Panel1.TabIndex = 3
        '
        'cmbCellLine
        '
        Me.cmbCellLine.AutoComplete = True
        Me.cmbCellLine.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCellLine.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCellLine.ForeColor = System.Drawing.Color.Black
        Me.cmbCellLine.Location = New System.Drawing.Point(72, 40)
        Me.cmbCellLine.Name = "cmbCellLine"
        Me.cmbCellLine.Size = New System.Drawing.Size(191, 22)
        Me.cmbCellLine.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Lime
        Me.Label5.Location = New System.Drawing.Point(5, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Cell Line:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbGroup
        '
        Me.cmbGroup.AutoComplete = True
        Me.cmbGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cmbGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGroup.ForeColor = System.Drawing.Color.Black
        Me.cmbGroup.Location = New System.Drawing.Point(72, 8)
        Me.cmbGroup.Name = "cmbGroup"
        Me.cmbGroup.Size = New System.Drawing.Size(191, 22)
        Me.cmbGroup.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Lime
        Me.Label2.Location = New System.Drawing.Point(6, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 99
        Me.Label2.Text = "Group:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(8, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "To Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpEndDt
        '
        Me.dtpEndDt.CustomFormat = "yyyy-MM-dd"
        Me.dtpEndDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpEndDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDt.Location = New System.Drawing.Point(72, 136)
        Me.dtpEndDt.Name = "dtpEndDt"
        Me.dtpEndDt.Size = New System.Drawing.Size(96, 20)
        Me.dtpEndDt.TabIndex = 5
        Me.dtpEndDt.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Lime
        Me.Label4.Location = New System.Drawing.Point(-8, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "From Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpStartDt
        '
        Me.dtpStartDt.CustomFormat = "yyyy-MM-dd"
        Me.dtpStartDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStartDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDt.Location = New System.Drawing.Point(72, 104)
        Me.dtpStartDt.Name = "dtpStartDt"
        Me.dtpStartDt.Size = New System.Drawing.Size(96, 20)
        Me.dtpStartDt.TabIndex = 4
        Me.dtpStartDt.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
        '
        'cmdGO
        '
        Me.cmdGO.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdGO.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGO.ForeColor = System.Drawing.Color.White
        Me.cmdGO.Location = New System.Drawing.Point(184, 112)
        Me.cmdGO.Name = "cmdGO"
        Me.cmdGO.Size = New System.Drawing.Size(80, 40)
        Me.cmdGO.TabIndex = 6
        Me.cmdGO.Text = "GO"
        '
        'cmbUser
        '
        Me.cmbUser.AutoComplete = True
        Me.cmbUser.BackColor = System.Drawing.SystemColors.Window
        Me.cmbUser.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUser.ForeColor = System.Drawing.Color.Black
        Me.cmbUser.Location = New System.Drawing.Point(72, 72)
        Me.cmbUser.Name = "cmbUser"
        Me.cmbUser.Size = New System.Drawing.Size(191, 22)
        Me.cmbUser.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Lime
        Me.Label3.Location = New System.Drawing.Point(6, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Refurber:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdStopTimer
        '
        Me.cmdStopTimer.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdStopTimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStopTimer.ForeColor = System.Drawing.Color.White
        Me.cmdStopTimer.Location = New System.Drawing.Point(184, 176)
        Me.cmdStopTimer.Name = "cmdStopTimer"
        Me.cmdStopTimer.Size = New System.Drawing.Size(80, 40)
        Me.cmdStopTimer.TabIndex = 6
        Me.cmdStopTimer.Text = "STOP TIMER"
        Me.cmdStopTimer.Visible = False
        '
        'grdModels
        '
        Me.grdModels.AllowColMove = False
        Me.grdModels.AllowColSelect = False
        Me.grdModels.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdModels.AllowSort = False
        Me.grdModels.AllowUpdate = False
        Me.grdModels.AllowUpdateOnBlur = False
        Me.grdModels.AlternatingRows = True
        Me.grdModels.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdModels.BackColor = System.Drawing.SystemColors.Control
        Me.grdModels.FilterBar = True
        Me.grdModels.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdModels.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdModels.Location = New System.Drawing.Point(280, 0)
        Me.grdModels.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdModels.Name = "grdModels"
        Me.grdModels.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdModels.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdModels.PreviewInfo.ZoomFactor = 75
        Me.grdModels.RowHeight = 17
        Me.grdModels.Size = New System.Drawing.Size(456, 264)
        Me.grdModels.TabIndex = 4
        Me.grdModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Arial, 8.25pt, style" & _
        "=Bold;ForeColor:White;BackColor:LightSlateGray;}Selected{ForeColor:HighlightText" & _
        ";BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:I" & _
        "nactiveCaption;}FilterBar{BackColor:White;}Footer{}Caption{AlignHorz:Center;}Sty" & _
        "le9{}Normal{Font:Arial, 9pt, style=Bold;BackColor:SteelBlue;AlignVert:Center;}Hi" & _
        "ghlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Font:Ari" & _
        "al, 8.25pt, style=Bold;ForeColor:White;BackColor:SteelBlue;}RecordSelector{Align" & _
        "Image:Center;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, styl" & _
        "e=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Co" & _
        "ntrolText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}St" & _
        "yle15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Me" & _
        "rgeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None" & _
        """ AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnF" & _
        "ooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelector" & _
        "Width=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""" & _
        "><Height>260</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle p" & _
        "arent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Filte" & _
        "rBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Sty" & _
        "le3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" " & _
        "me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveSt" & _
        "yle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><" & _
        "RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent" & _
        "=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0," & _
        " 452, 260</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle" & _
        "></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Norm" & _
        "al"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" " & _
        "/><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /" & _
        "><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><St" & _
        "yle parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><S" & _
        "tyle parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /" & _
        "><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></" & _
        "NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</La" & _
        "yout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 452, 260</Clie" & _
        "ntArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle pare" & _
        "nt="""" me=""Style17"" /></Blob>"
        '
        'grdpartSummary
        '
        Me.grdpartSummary.AllowColMove = False
        Me.grdpartSummary.AllowColSelect = False
        Me.grdpartSummary.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdpartSummary.AllowSort = False
        Me.grdpartSummary.AllowUpdate = False
        Me.grdpartSummary.AllowUpdateOnBlur = False
        Me.grdpartSummary.AlternatingRows = True
        Me.grdpartSummary.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdpartSummary.BackColor = System.Drawing.SystemColors.Control
        Me.grdpartSummary.FilterBar = True
        Me.grdpartSummary.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdpartSummary.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdpartSummary.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdpartSummary.Location = New System.Drawing.Point(280, 272)
        Me.grdpartSummary.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdpartSummary.Name = "grdpartSummary"
        Me.grdpartSummary.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdpartSummary.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdpartSummary.PreviewInfo.ZoomFactor = 75
        Me.grdpartSummary.RowHeight = 17
        Me.grdpartSummary.Size = New System.Drawing.Size(456, 224)
        Me.grdpartSummary.TabIndex = 7
        Me.grdpartSummary.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Arial, 8.25pt, style" & _
        "=Bold;ForeColor:Black;BackColor:Control;}Selected{ForeColor:HighlightText;BackCo" & _
        "lor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:Inactive" & _
        "Caption;}FilterBar{BackColor:White;}Footer{}Caption{AlignHorz:Center;}Style1{}No" & _
        "rmal{Font:Arial, 9pt, style=Bold;AlignVert:Center;BackColor:SteelBlue;}Highlight" & _
        "Row{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{Font:Arial, 8.2" & _
        "5pt, style=Bold;BackColor:Wheat;}RecordSelector{AlignImage:Center;}Style15{}Head" & _
        "ing{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;Ali" & _
        "gnVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;" & _
        "}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}St" & _
        "yle9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False" & _
        """ AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True" & _
        """ CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=" & _
        """True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""" & _
        "16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>220</Height><Capti" & _
        "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
        "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
        """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
        "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
        "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
        "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
        """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
        "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 452, 220</ClientRect><Bord" & _
        "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
        "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
        """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
        "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
        """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
        "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
        "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
        """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
        "vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16" & _
        "</DefaultRecSelWidth><ClientArea>0, 0, 452, 220</ClientArea><PrintPageHeaderStyl" & _
        "e parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob" & _
        ">"
        '
        'frmRefurbAudit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(752, 517)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdpartSummary, Me.grdModels, Me.Panel1, Me.lblHeader})
        Me.Name = "frmRefurbAudit"
        Me.Text = "Refurb Auditor"
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdModels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdpartSummary, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        GobjRefurbAuditor = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub frmRefurbAudit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.dtpStartDt.Value = Now
            Me.dtpEndDt.Value = Now
            Me.LoadUsers()
            Me.LoadGroups()
            Me.cmbGroup.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUsers()
        Dim dtUsers As New DataTable()
        Try
            dtUsers = GobjRefurbAuditor.LoadUsers()
            With Me.cmbUser
                .DataSource = dtUsers.DefaultView
                .DisplayMember = dtUsers.Columns("user_fullname").ToString
                .ValueMember = dtUsers.Columns("user_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtUsers) Then
                dtUsers.Dispose()
                dtUsers = Nothing
            End If
        End Try
    End Sub

    Private Sub LoadGroups()
        Dim dt As New DataTable()
        Try
            dt = GobjRefurbAuditor.LoadGroups()
            With Me.cmbGroup
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("Group_Desc").ToString
                .ValueMember = dt.Columns("Group_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    Private Sub cmbGroup_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbGroup.SelectionChangeCommitted
        Try
            If Me.cmbGroup.SelectedValue <> 0 Then
                LoadCellLines()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Group Selection Change Committed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCellLines()
        Dim dt As New DataTable()
        Try
            dt = GobjRefurbAuditor.LoadCellLines(Me.cmbGroup.SelectedValue)
            With Me.cmbCellLine
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("cc_desc").ToString
                .ValueMember = dt.Columns("cc_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    Private Sub cmdGO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGO.Click
        Try
            If Me.cmbGroup.SelectedValue = 0 Then
                MessageBox.Show("Please select a Refurber.", "Click GO Button", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Len(Trim(Me.dtpStartDt.Value)) = 0 Then
                MessageBox.Show("Please select a ""From"" date.", "Click GO Button", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Len(Trim(Me.dtpEndDt.Value)) = 0 Then
                MessageBox.Show("Please select an ""To"" date.", "Click GO Button", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            If Me.dtpStartDt.Value > Me.dtpEndDt.Value Then
                MessageBox.Show("""From"" date can not be after ""To"" date.", "Click GO Button", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            'Me.LoadRefurbedModelsForUser()
            Me.LoadModelQty()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Click GO Button", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub LoadRefurbedModelsForUser()
        Dim dt1 As DataTable
        Try
            dt1 = GobjRefurbAuditor.GetInfoOnModelsRefurbedByUser(Me.cmbUser.SelectedValue, Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), Format(Me.dtpEndDt.Value, "yyyy-MM-dd"))
            Me.grdModels.ClearFields()
            Me.grdModels.DataSource = dt1.DefaultView
            SetgrdModelsGridProperties_TabSummary()

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub LoadModelQty()
        Dim dt1 As DataTable
        Dim i As Integer
        Dim iDayTotal, iWeekTotal As Integer
        Dim decDayTotalCost, decWeekTotalCost As Decimal
        Try
            dt1 = GobjRefurbAuditor.GetBillingModelsQty(Me.cmbGroup.SelectedValue, Me.cmbCellLine.SelectedValue, Me.cmbUser.SelectedValue, Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), Format(Me.dtpEndDt.Value, "yyyy-MM-dd"), iDayTotal, iWeekTotal, decDayTotalCost, decWeekTotalCost)

            With Me.grdModels
                .ClearFields()
                .DataSource = dt1.DefaultView

                'Heading style (Horizontal Alignment to Center)
                For i = 0 To Me.grdModels.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                'Set Column Widths
                .Splits(0).DisplayColumns("Model").Width = 170
                .Splits(0).DisplayColumns("Qty").Width = 50
                .Splits(0).DisplayColumns("Avg Parts Cost(Fr Date)").Width = 170
                .Splits(0).DisplayColumns("Avg Parts Cost(Week of Fr)").Width = 170

                .Splits(0).DisplayColumns("Model_ID").Visible = False

                'Total
                .ColumnFooters = True
                .Splits(0).FooterStyle.HorizontalAlignment = AlignHorzEnum.Far
                .FooterStyle.BackColor = Color.Black
                .FooterStyle.ForeColor = Color.Lime
                .Columns("Model").FooterText = "Total"
                .Columns("Qty").FooterText = dt1.Compute("Sum([Qty])", "").ToString
                .Columns("Avg Parts Cost(Fr Date)").FooterText = "$" & Format((decDayTotalCost / CDec(iDayTotal)), "###,0.00")
                .Columns("Avg Parts Cost(Week of Fr)").FooterText = "$" & Format((decWeekTotalCost / CDec(iWeekTotal)), "###,0.00")

                .Columns("Avg Parts Cost(Fr Date)").NumberFormat = "$ ###,0.00"
                .Columns("Avg Parts Cost(Week of Fr)").NumberFormat = "$ ###,0.00"
            End With

            'SetgrdModelsGridProperties_TabSummary()

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub SetgrdModelsGridProperties_TabSummary()
        Dim iNumOfColumns As Integer = Me.grdModels.Columns.Count
        Dim i As Integer

        With Me.grdModels
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 134
            .Splits(0).DisplayColumns(3).Width = 72

            'Make some columns invisible  134, 72
            .Splits(0).DisplayColumns(0).Visible = False
            .Splits(0).DisplayColumns(2).Visible = False
            .Splits(0).DisplayColumns(4).Visible = False
        End With
    End Sub

    Private Sub SetgrdPartsGridProperties_TabSummary()
        Dim iNumOfColumns As Integer = Me.grdpartSummary.Columns.Count
        Dim i As Integer

        With Me.grdpartSummary
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 134
            .Splits(0).DisplayColumns(3).Width = 113
            .Splits(0).DisplayColumns(4).Width = 210
            .Splits(0).DisplayColumns(5).Width = 71
            .Splits(0).DisplayColumns(6).Width = 46

            'Make some columns invisible  134, 72
            .Splits(0).DisplayColumns(0).Visible = False
            .Splits(0).DisplayColumns(2).Visible = False
        End With
    End Sub

    Private Sub cmbGroup_cmbCellLine_cmbUser_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGroup.SelectionChangeCommitted, cmbCellLine.SelectionChangeCommitted, cmbUser.SelectionChangeCommitted
        grdpartSummary.DataSource = Nothing
        grdModels.DataSource = Nothing
    End Sub

    Private Sub dtpStartDt_dtpEndDt_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStartDt.ValueChanged, dtpEndDt.ValueChanged
        grdpartSummary.DataSource = Nothing
        grdModels.DataSource = Nothing
    End Sub

    Private Sub grdModels_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdModels.RowColChange
        Dim dt1 As DataTable
        'Dim strGrpTogether As String = ""
        Dim i As Integer

        Try
            If Me.grdModels.Columns.Count = 0 Then
                Exit Sub
            End If

            Me.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            grdpartSummary.DataSource = Nothing

            'If Not IsDBNull(Me.grdModels.Columns("GroupTogether").Value) Then
            '    strGrpTogether = Me.grdModels.Columns("GroupTogether").Value
            'Else
            '    strGrpTogether = ""
            'End If

            'dt1 = Me.GobjRefurbAuditor.GetPartsInfo(Me.grdModels.Columns("model_id").Value, _
            '                                        Me.cmbUser.SelectedValue, _
            '                                        Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), _
            '                                        Format(Me.dtpEndDt.Value, "yyyy-MM-dd"), _
            '                                        Me.grdModels.Columns("CustomModelGroup").Value, _
            '                                        strGrpTogether)

            'Me.grdpartSummary.DataSource = dt1.DefaultView
            'SetgrdPartsGridProperties_TabSummary()

            dt1 = Me.GobjRefurbAuditor.GetPartsConsumption(Me.grdModels.Columns("model_id").Value, _
                                                           Me.cmbGroup.SelectedValue, _
                                                           Me.cmbCellLine.SelectedValue, _
                                                           Me.cmbUser.SelectedValue, _
                                                           Format(Me.dtpStartDt.Value, "yyyy-MM-dd"), _
                                                           Format(Me.dtpEndDt.Value, "yyyy-MM-dd"))

            With Me.grdpartSummary
                .DataSource = dt1.DefaultView

                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (Me.grdpartSummary.Columns.Count - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                'Set Column Widths
                .Splits(0).DisplayColumns("Model").Width = 134
                .Splits(0).DisplayColumns("Part #").Width = 113
                .Splits(0).DisplayColumns("Part").Width = 210
                .Splits(0).DisplayColumns("Consumed").Width = 71
                .Splits(0).DisplayColumns("Scrap").Width = 46

                'Make some columns invisible  
                .Splits(0).DisplayColumns("model_id").Visible = False
                .Splits(0).DisplayColumns("PSPrice_ID").Visible = False

            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Model Selection Changed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If

            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub



End Class
