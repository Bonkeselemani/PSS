Option Explicit On 
Imports System.ComponentModel

Namespace Gui
    Public Class frmAIGReports
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCust_ID As Integer = 0
        Private _strRptName As String = ""

        Private _objAIGReports As PSS.Data.Buisness.AIGReports

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._strScreenName = strScreenName
            Me._iMenuCust_ID = iCustID
            Me._objAIGReports = New PSS.Data.Buisness.AIGReports()
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
        Friend WithEvents gbReportName As System.Windows.Forms.GroupBox
        Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
        Friend WithEvents grpDates As System.Windows.Forms.GroupBox
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents grpReportList As System.Windows.Forms.GroupBox
        Friend WithEvents btnStatusReport As System.Windows.Forms.Button
        Friend WithEvents lblStatusReports As System.Windows.Forms.Label
        Friend WithEvents btnRunRpt As System.Windows.Forms.Button
        Friend WithEvents tcMain As System.Windows.Forms.TabControl
        Friend WithEvents tpReports As System.Windows.Forms.TabPage
        Friend WithEvents tpWipData As System.Windows.Forms.TabPage
        Friend WithEvents dgWipData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tpDataView As System.Windows.Forms.TabPage
        Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
        Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
        Friend WithEvents DataGrid3 As System.Windows.Forms.DataGrid
        Friend WithEvents btnRefresh As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAIGReports))
            Me.gbReportName = New System.Windows.Forms.GroupBox()
            Me.btnRunRpt = New System.Windows.Forms.Button()
            Me.cboReportName = New System.Windows.Forms.ComboBox()
            Me.grpReportList = New System.Windows.Forms.GroupBox()
            Me.lblStatusReports = New System.Windows.Forms.Label()
            Me.btnStatusReport = New System.Windows.Forms.Button()
            Me.grpDates = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.tcMain = New System.Windows.Forms.TabControl()
            Me.tpReports = New System.Windows.Forms.TabPage()
            Me.tpWipData = New System.Windows.Forms.TabPage()
            Me.btnRefresh = New System.Windows.Forms.Button()
            Me.dgWipData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpDataView = New System.Windows.Forms.TabPage()
            Me.DataGrid3 = New System.Windows.Forms.DataGrid()
            Me.DataGrid2 = New System.Windows.Forms.DataGrid()
            Me.DataGrid1 = New System.Windows.Forms.DataGrid()
            Me.gbReportName.SuspendLayout()
            Me.grpReportList.SuspendLayout()
            Me.grpDates.SuspendLayout()
            Me.tcMain.SuspendLayout()
            Me.tpReports.SuspendLayout()
            Me.tpWipData.SuspendLayout()
            CType(Me.dgWipData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpDataView.SuspendLayout()
            CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'gbReportName
            '
            Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRunRpt, Me.cboReportName})
            Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbReportName.ForeColor = System.Drawing.Color.Green
            Me.gbReportName.Location = New System.Drawing.Point(88, 160)
            Me.gbReportName.Name = "gbReportName"
            Me.gbReportName.Size = New System.Drawing.Size(400, 96)
            Me.gbReportName.TabIndex = 20
            Me.gbReportName.TabStop = False
            Me.gbReportName.Text = "REPORT NAME"
            '
            'btnRunRpt
            '
            Me.btnRunRpt.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnRunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRunRpt.ForeColor = System.Drawing.Color.White
            Me.btnRunRpt.Location = New System.Drawing.Point(32, 48)
            Me.btnRunRpt.Name = "btnRunRpt"
            Me.btnRunRpt.Size = New System.Drawing.Size(352, 32)
            Me.btnRunRpt.TabIndex = 7
            '
            'cboReportName
            '
            Me.cboReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboReportName.ItemHeight = 16
            Me.cboReportName.Location = New System.Drawing.Point(32, 16)
            Me.cboReportName.MaxDropDownItems = 25
            Me.cboReportName.Name = "cboReportName"
            Me.cboReportName.Size = New System.Drawing.Size(352, 24)
            Me.cboReportName.TabIndex = 6
            '
            'grpReportList
            '
            Me.grpReportList.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblStatusReports, Me.btnStatusReport})
            Me.grpReportList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpReportList.ForeColor = System.Drawing.Color.Green
            Me.grpReportList.Location = New System.Drawing.Point(88, 264)
            Me.grpReportList.Name = "grpReportList"
            Me.grpReportList.Size = New System.Drawing.Size(400, 152)
            Me.grpReportList.TabIndex = 19
            Me.grpReportList.TabStop = False
            Me.grpReportList.Text = "STATUS REPORTS"
            '
            'lblStatusReports
            '
            Me.lblStatusReports.ForeColor = System.Drawing.Color.DarkGray
            Me.lblStatusReports.Location = New System.Drawing.Point(32, 18)
            Me.lblStatusReports.Name = "lblStatusReports"
            Me.lblStatusReports.Size = New System.Drawing.Size(336, 80)
            Me.lblStatusReports.TabIndex = 9
            Me.lblStatusReports.Text = "Reports"
            '
            'btnStatusReport
            '
            Me.btnStatusReport.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnStatusReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnStatusReport.ForeColor = System.Drawing.Color.White
            Me.btnStatusReport.Location = New System.Drawing.Point(24, 104)
            Me.btnStatusReport.Name = "btnStatusReport"
            Me.btnStatusReport.Size = New System.Drawing.Size(352, 32)
            Me.btnStatusReport.TabIndex = 8
            Me.btnStatusReport.Text = "Get All Status Reports (One Excel File)"
            '
            'grpDates
            '
            Me.grpDates.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
            Me.grpDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpDates.ForeColor = System.Drawing.Color.Green
            Me.grpDates.Location = New System.Drawing.Point(88, 72)
            Me.grpDates.Name = "grpDates"
            Me.grpDates.Size = New System.Drawing.Size(400, 80)
            Me.grpDates.TabIndex = 17
            Me.grpDates.TabStop = False
            Me.grpDates.Text = "DATE RANGE"
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndDate.ForeColor = System.Drawing.Color.Black
            Me.lblEndDate.Location = New System.Drawing.Point(32, 50)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(80, 16)
            Me.lblEndDate.TabIndex = 105
            Me.lblEndDate.Text = "End  Date:"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpEndDate.Location = New System.Drawing.Point(112, 48)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.Size = New System.Drawing.Size(272, 23)
            Me.dtpEndDate.TabIndex = 1
            Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate.Location = New System.Drawing.Point(112, 16)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(272, 23)
            Me.dtpStartDate.TabIndex = 0
            Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStartDate.ForeColor = System.Drawing.Color.Black
            Me.lblStartDate.Location = New System.Drawing.Point(32, 18)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
            Me.lblStartDate.TabIndex = 103
            Me.lblStartDate.Text = "Start Date:"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Arial Black", 20.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Green
            Me.lblTitle.Location = New System.Drawing.Point(24, 24)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(520, 48)
            Me.lblTitle.TabIndex = 21
            Me.lblTitle.Text = "REPORTS"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tcMain
            '
            Me.tcMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tcMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpReports, Me.tpWipData, Me.tpDataView})
            Me.tcMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tcMain.Location = New System.Drawing.Point(32, 24)
            Me.tcMain.Name = "tcMain"
            Me.tcMain.SelectedIndex = 0
            Me.tcMain.Size = New System.Drawing.Size(624, 512)
            Me.tcMain.TabIndex = 22
            '
            'tpReports
            '
            Me.tpReports.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDates, Me.gbReportName, Me.lblTitle, Me.grpReportList})
            Me.tpReports.Location = New System.Drawing.Point(4, 29)
            Me.tpReports.Name = "tpReports"
            Me.tpReports.Size = New System.Drawing.Size(616, 479)
            Me.tpReports.TabIndex = 0
            Me.tpReports.Text = "Reports"
            '
            'tpWipData
            '
            Me.tpWipData.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRefresh, Me.dgWipData})
            Me.tpWipData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tpWipData.Location = New System.Drawing.Point(4, 29)
            Me.tpWipData.Name = "tpWipData"
            Me.tpWipData.Size = New System.Drawing.Size(616, 479)
            Me.tpWipData.TabIndex = 1
            Me.tpWipData.Text = "Wip Data"
            '
            'btnRefresh
            '
            Me.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRefresh.Location = New System.Drawing.Point(520, 16)
            Me.btnRefresh.Name = "btnRefresh"
            Me.btnRefresh.TabIndex = 8
            Me.btnRefresh.Text = "Refresh"
            '
            'dgWipData
            '
            Me.dgWipData.AllowUpdate = False
            Me.dgWipData.AlternatingRows = True
            Me.dgWipData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgWipData.CaptionHeight = 17
            Me.dgWipData.FilterBar = True
            Me.dgWipData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgWipData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgWipData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgWipData.Location = New System.Drawing.Point(32, 40)
            Me.dgWipData.Name = "dgWipData"
            Me.dgWipData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgWipData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgWipData.PreviewInfo.ZoomFactor = 75
            Me.dgWipData.RowHeight = 15
            Me.dgWipData.Size = New System.Drawing.Size(560, 381)
            Me.dgWipData.TabIndex = 7
            Me.dgWipData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8.25pt;BackColor:SteelBlu" & _
            "e;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style1" & _
            "9{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{B" & _
            "ackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;" & _
            "BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{" & _
            "}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackC" & _
            "olor:NavajoWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;" & _
            "ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.7" & _
            "5pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}G" & _
            "roup{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Sty" & _
            "le6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeV" & _
            "iew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""1" & _
            "7"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Reco" & _
            "rdSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrol" & _
            "lGroup=""1""><Height>377</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edi" & _
            "torStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8" & _
            """ /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Foote" & _
            "r"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=" & _
            """Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><" & _
            "InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""S" & _
            "tyle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSt" & _
            "yle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><Client" & _
            "Rect>0, 0, 556, 377</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</B" & _
            "orderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=""" & _
            """ me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me" & _
            "=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""I" & _
            "nactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edi" & _
            "tor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Eve" & _
            "nRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordS" & _
            "elector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""G" & _
            "roup"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layou" & _
            "t>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 556," & _
            " 377</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooter" & _
            "Style parent="""" me=""Style21"" /></Blob>"
            '
            'tpDataView
            '
            Me.tpDataView.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid3, Me.DataGrid2, Me.DataGrid1})
            Me.tpDataView.Location = New System.Drawing.Point(4, 29)
            Me.tpDataView.Name = "tpDataView"
            Me.tpDataView.Size = New System.Drawing.Size(616, 479)
            Me.tpDataView.TabIndex = 2
            Me.tpDataView.Text = "DataView"
            '
            'DataGrid3
            '
            Me.DataGrid3.CaptionVisible = False
            Me.DataGrid3.DataMember = ""
            Me.DataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid3.Location = New System.Drawing.Point(8, 280)
            Me.DataGrid3.Name = "DataGrid3"
            Me.DataGrid3.Size = New System.Drawing.Size(584, 128)
            Me.DataGrid3.TabIndex = 2
            '
            'DataGrid2
            '
            Me.DataGrid2.CaptionVisible = False
            Me.DataGrid2.DataMember = ""
            Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid2.Location = New System.Drawing.Point(8, 144)
            Me.DataGrid2.Name = "DataGrid2"
            Me.DataGrid2.Size = New System.Drawing.Size(584, 129)
            Me.DataGrid2.TabIndex = 1
            '
            'DataGrid1
            '
            Me.DataGrid1.CaptionVisible = False
            Me.DataGrid1.DataMember = ""
            Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
            Me.DataGrid1.Name = "DataGrid1"
            Me.DataGrid1.Size = New System.Drawing.Size(584, 128)
            Me.DataGrid1.TabIndex = 0
            '
            'frmAIGReports
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(11, 24)
            Me.BackColor = System.Drawing.Color.Gainsboro
            Me.ClientSize = New System.Drawing.Size(696, 598)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tcMain})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ForeColor = System.Drawing.Color.Black
            Me.Name = "frmAIGReports"
            Me.Text = "frmAIGReports"
            Me.gbReportName.ResumeLayout(False)
            Me.grpReportList.ResumeLayout(False)
            Me.grpDates.ResumeLayout(False)
            Me.tcMain.ResumeLayout(False)
            Me.tpReports.ResumeLayout(False)
            Me.tpWipData.ResumeLayout(False)
            CType(Me.dgWipData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpDataView.ResumeLayout(False)
            CType(Me.DataGrid3, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Reports"

        '***********************************************************************************************
        Private Sub frmAIGReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                Dim i As Integer

                Me.tcMain.Controls.Remove(tpDataView) 'coments it when debug

                Me.cboReportName.Items.Clear() : Me.lblStatusReports.Text = ""
                Me.cboReportName.Items.Add("Select a Report")
                Me.cboReportName.ValueMember = 0

                Dim myES As New PSS.Data.Buisness.AIGReports.EnumStatusReports()
                For Each myES In [Enum].GetValues(GetType(PSS.Data.Buisness.AIGReports.EnumStatusReports))
                    Me.cboReportName.Items.Add(Me._objAIGReports.EnumDescription(myES))
                    Dim k As Integer = myES
                    Me.cboReportName.ValueMember = k
                Next
                Dim myES2 As New PSS.Data.Buisness.AIGReports.EnumOtherReports()
                For Each myES2 In [Enum].GetValues(GetType(PSS.Data.Buisness.AIGReports.EnumOtherReports))
                    Me.cboReportName.Items.Add(Me._objAIGReports.EnumDescription(myES2))
                    Dim k As Integer = myES2
                    Me.cboReportName.ValueMember = k
                Next
                Me.cboReportName.SelectedIndex = 0

                ' Me._objAIGReports.EnumDescription(Me._objAIGReports.EnumStatusReports.ReceivedBoxShipped) 'give up to use decription

                For Each myES In [Enum].GetValues(GetType(PSS.Data.Buisness.AIGReports.EnumStatusReports))
                    Me.lblStatusReports.Text &= Me._objAIGReports.EnumDescription(myES) & Environment.NewLine
                Next

                Me.grpDates.Visible = False : Me.gbReportName.Visible = False
                Me.grpReportList.Top = Me.grpDates.Top

                LoadWipData()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************
        Private Sub cboReportName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReportName.SelectedIndexChanged
            Try
                If Not Me.cboReportName.SelectedIndex > 0 Then
                    Me.btnRunRpt.Text = ""
                    Me.btnRunRpt.Enabled = False
                Else
                    Me.btnRunRpt.Text = "Get """ & Me.cboReportName.Text & """"
                    Me.btnRunRpt.Enabled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboReportName_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************
        Private Sub btnRunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunRpt.Click

            Me._strRptName = ""
            'Dim iSelectedItem As Integer

            'Me.gbDate.Visible = False
            'Me.gbWorkOrder.Visible = False
            'Me.btnRunRpt.Visible = False
            Me.btnRunRpt.Enabled = True

            'MessageBox.Show("Me.cboReportName.SelectedIndex = " & Me.cboReportName.SelectedIndex)
            'MessageBox.Show("Me.cboReportName.SelectedText = " & Me.cboReportName.SelectedText)
            'MessageBox.Show("Me.cboReportName.Text = " & Me.cboReportName.Text)
            'MessageBox.Show("Me.cboReportName.SelectedValue = " & Me.cboReportName.SelectedValue)
            'MessageBox.Show("Me.cboReportName.SelectedItem = " & Me.cboReportName.SelectedItem)

            Try

                If Me.cboReportName.SelectedIndex > 0 Then
                    Me._strRptName = Me.cboReportName.Text
                    'iSelectedItem = Me.cboReportName.SelectedItem
                    Select Case Me.cboReportName.Text
                        Case Me._objAIGReports.EnumDescription(Me._objAIGReports.EnumStatusReports.CanceledClaims)

                        Case Me._objAIGReports.EnumDescription(Me._objAIGReports.EnumStatusReports.NonReturnedBoxClaims)
                            MessageBox.Show("6:" & Me._strRptName)
                        Case Me._objAIGReports.EnumDescription(Me._objAIGReports.EnumStatusReports.ReceivedBoxShipped)
                            MessageBox.Show("1:" & Me._strRptName)
                        Case Me._objAIGReports.EnumDescription(Me._objAIGReports.EnumStatusReports.ReturnShipped)
                            MessageBox.Show("3:" & Me._strRptName)
                        Case Me._objAIGReports.EnumDescription(Me._objAIGReports.EnumStatusReports.SendToSNSalvage)

                        Case Me._objAIGReports.EnumDescription(Me._objAIGReports.EnumStatusReports.SendToSNSalvage.UnitReceived)

                    End Select
                End If



            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnStatusReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatusReport.Click
            Dim dt, dt1, dt2, dt3, dt4, dt5, dt6 As DataTable
            Dim ds As New DataSet()
            Dim row As DataRow, tmpRows As DataRow()
            Dim iDevice_ID, i, j, colNum As Integer
            Dim strExpression As String = ""

            Try
                Me._strRptName = "AIG Status Report"

                dt = Me._objAIGReports.GetReportData_1To6(Me._iMenuCust_ID)
                'MessageBox.Show("dt.Rows.Count = " & dt.Rows.Count)
                'Update BER or Canceled
                For Each row In dt.Rows
                    If Not row.IsNull("Device_ID") Then
                        If IsNumeric(row("Device_ID")) Then
                            iDevice_ID = row("Device_ID")
                            If Me._objAIGReports.IsBillCodeID_BER(iDevice_ID) Then
                                row.BeginEdit()
                                row("SEND TO SN_SALVAGE (BER)") = 1
                                row.AcceptChanges()
                            End If
                            If Me._objAIGReports.IsBillCodeID_Canceled(iDevice_ID) Then
                                row.BeginEdit()
                                row("CANCELED") = 1
                                row.AcceptChanges()
                            End If
                        End If
                    End If
                Next
                'Me.DataGrid1.DataSource = dt

                'RECEIVED_BOX SHIPPED (WIP Only) (All but not shipped). S_ID<>7 and <>8, SEND TO SN_SALVAGE (BER)<>1,CANCELED<>1
                strExpression = "S_ID <> 7 AND S_ID <> 8 AND [SEND TO SN_SALVAGE (BER)] <> 1 AND CANCELED <> 1"
                dt1 = dt.Clone
                dt1.TableName = "RECEIVED_BOX SHIPPED"
                tmpRows = dt.Select(strExpression)
                For Each row In tmpRows
                    dt1.ImportRow(row)
                Next
                colNum = dt1.Columns.Count
                For j = colNum - 1 To 8 Step -1
                    dt1.Columns.RemoveAt(j)
                Next
                ds.Tables.Add(dt1)
                tmpRows = Nothing
                'MessageBox.Show("dt1.Rows.Count = " & dt1.Rows.Count)

                'UNIT RECEIVED (All Received).  Device_DateRec is not Null (DATE UNIT RECEIVED is not null) or isdate
                dt2 = dt.Clone
                dt2.TableName = "UNIT RECEIVED"
                For Each row In dt.Rows
                    If Not row.IsNull("DATE UNIT RECEIVED") Then
                        dt2.ImportRow(row)
                    End If
                Next
                colNum = dt2.Columns.Count
                For j = colNum - 1 To 8 Step -1
                    dt2.Columns.RemoveAt(j)
                Next
                ds.Tables.Add(dt2)


                'RETURN SHIPPED (WIP plus Shipped) All
                dt3 = dt.Copy
                dt3.TableName = "RETURN SHIPPED"
                colNum = dt3.Columns.Count
                For j = colNum - 1 To 11 Step -1
                    dt3.Columns.RemoveAt(j)
                Next
                ds.Tables.Add(dt3)

                'SEND TO SN_SALVAGE, Billcode_ID=2533, SEND TO SN_SALVAGE (BER)=1
                strExpression = " [SEND TO SN_SALVAGE (BER)] = 1"
                dt4 = dt.Clone
                dt4.TableName = "SEND TO SN_SALVAGE"
                tmpRows = dt.Select(strExpression)
                For Each row In tmpRows
                    dt4.ImportRow(row)
                Next
                colNum = dt4.Columns.Count
                For j = colNum - 1 To 11 Step -1
                    dt4.Columns.RemoveAt(j)
                Next
                ds.Tables.Add(dt4)
                tmpRows = Nothing

                'CANCELED,  Billcode_ID=2534, CANCELED=1
                strExpression = "CANCELED = 1"
                dt5 = dt.Clone
                dt5.TableName = "CANCELED"
                tmpRows = dt.Select(strExpression)
                For Each row In tmpRows
                    dt5.ImportRow(row)
                Next
                colNum = dt5.Columns.Count
                For j = colNum - 1 To 0 Step -1
                    Select Case j
                        Case 0 To 2, 13
                        Case Else
                            dt5.Columns.RemoveAt(j)
                    End Select
                Next
                ds.Tables.Add(dt5)
                tmpRows = Nothing

                'NON RETURNED BOX CLAIMS, S_ID=8
                strExpression = "S_ID = 8"
                dt6 = dt.Clone
                dt6.TableName = "NON RETURNED BOX CLAIMS"
                tmpRows = dt.Select(strExpression)
                For Each row In tmpRows
                    dt6.ImportRow(row)
                Next
                colNum = dt6.Columns.Count
                For j = colNum - 1 To 0 Step -1
                    Select Case j
                        Case 0 To 5, 14 To 16
                        Case Else
                            dt6.Columns.RemoveAt(j)
                    End Select
                Next
                ds.Tables.Add(dt6)
                tmpRows = Nothing

                'MessageBox.Show("dt2.Rows.Count = " & dt2.Rows.Count)
                'Me.DataGrid2.DataSource = ds.Tables(0)
                'Me.DataGrid3.DataSource = ds.Tables(1)

                If Not ds.Tables.Count > 0 Or (dt1.Rows.Count + dt2.Rows.Count + dt3.Rows.Count + dt4.Rows.Count + dt5.Rows.Count + dt6.Rows.Count) = 0 Then
                    MessageBox.Show("No Data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me._objAIGReports.CreateExcelReport(ds, Me._strRptName)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnStatusReport_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

#End Region


#Region "Wip Data"

        '*******************************************************************
        Private Sub LoadWipData()
            Dim dt As DataTable
            Dim row As DataRow
            Dim iWO_ID As Integer
            Dim strTechName As String = ""

            Try
                dt = Me._objAIGReports.GetWipData(Data.Buisness.AIG.CUSTOMERID)

                For Each row In dt.Rows
                    If Not IsDBNull(row("PSS Workorder")) Then
                        iWO_ID = row("PSS Workorder")
                        strTechName = Me._objAIGReports.GetTechName(iWO_ID)
                        row.BeginEdit()
                        row("Tech Name") = strTechName
                        row("Part Need") = Me._objAIGReports.GetPartNeedYesNo(iWO_ID)
                        row("Part Arrived") = Me._objAIGReports.GetPartArrivedYesNo(iWO_ID)
                        row.AcceptChanges()
                    End If
                Next

                With Me.dgWipData
                    .DataSource = dt.DefaultView
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************
        Private Sub dgWipData_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgWipData.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    objCopyAll.Text = "Copy all"
                    objCopySelected.Text = "Copy selected rows"

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "grdDevice_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dgWipData)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dgWipData)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************
        Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
            Try
                LoadWipData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*******************************************************************

#End Region


       
    End Class
End Namespace