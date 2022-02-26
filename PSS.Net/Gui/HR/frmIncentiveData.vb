Option Explicit On 

Namespace Gui.HR
    Public Class frmIncentiveData
        Inherits System.Windows.Forms.Form

        Private _objEmpIncentive As PSS.Data.Buisness.EmployeeIncentive
        Private strStartDate As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objEmpIncentive = New PSS.Data.Buisness.EmployeeIncentive()
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
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents dgEEData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpIncentiveData As System.Windows.Forms.TabPage
        Friend WithEvents tpEEHrs As System.Windows.Forms.TabPage
        Friend WithEvents dgEEHrs As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnGo As System.Windows.Forms.Button
        Friend WithEvents dtpDateOfWeek As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnExportCSV As System.Windows.Forms.Button
        Friend WithEvents btnExportProdPay As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmIncentiveData))
            Me.dtpDateOfWeek = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.dgEEData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpIncentiveData = New System.Windows.Forms.TabPage()
            Me.tpEEHrs = New System.Windows.Forms.TabPage()
            Me.dgEEHrs = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnGo = New System.Windows.Forms.Button()
            Me.btnExportCSV = New System.Windows.Forms.Button()
            Me.btnExportProdPay = New System.Windows.Forms.Button()
            CType(Me.dgEEData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpIncentiveData.SuspendLayout()
            Me.tpEEHrs.SuspendLayout()
            CType(Me.dgEEHrs, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dtpDateOfWeek
            '
            Me.dtpDateOfWeek.CustomFormat = "yyyy-MM-dd"
            Me.dtpDateOfWeek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpDateOfWeek.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDateOfWeek.Location = New System.Drawing.Point(160, 16)
            Me.dtpDateOfWeek.Name = "dtpDateOfWeek"
            Me.dtpDateOfWeek.Size = New System.Drawing.Size(96, 20)
            Me.dtpDateOfWeek.TabIndex = 8
            '
            'lblStartDate
            '
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStartDate.ForeColor = System.Drawing.Color.Yellow
            Me.lblStartDate.Location = New System.Drawing.Point(0, 17)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(168, 16)
            Me.lblStartDate.TabIndex = 9
            Me.lblStartDate.Text = " Select any date of the week"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dgEEData
            '
            Me.dgEEData.AllowColMove = False
            Me.dgEEData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dgEEData.AllowUpdate = False
            Me.dgEEData.AllowUpdateOnBlur = False
            Me.dgEEData.AlternatingRows = True
            Me.dgEEData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgEEData.CaptionHeight = 19
            Me.dgEEData.CollapseColor = System.Drawing.Color.White
            Me.dgEEData.ExpandColor = System.Drawing.Color.White
            Me.dgEEData.FilterBar = True
            Me.dgEEData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgEEData.ForeColor = System.Drawing.Color.White
            Me.dgEEData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgEEData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dgEEData.Location = New System.Drawing.Point(8, 8)
            Me.dgEEData.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dgEEData.Name = "dgEEData"
            Me.dgEEData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgEEData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgEEData.PreviewInfo.ZoomFactor = 75
            Me.dgEEData.RowHeight = 20
            Me.dgEEData.Size = New System.Drawing.Size(808, 551)
            Me.dgEEData.TabIndex = 14
            Me.dgEEData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt;ForeC" & _
            "olor:Black;BackColor:AliceBlue;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
            "ight;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 8.25pt;ForeColor:Black;BackColor:White;}Footer{Font:Tahom" & _
            "a, 8.25pt, style=Bold, Italic;AlignHorz:Far;ForeColor:White;}Caption{AlignHorz:C" & _
            "enter;ForeColor:MidnightBlue;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, " & _
            "style=Bold;BackColor:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightR" & _
            "ow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Font:Tahoma, 8.2" & _
            "5pt;ForeColor:Black;BackColor:LightBlue;}RecordSelector{AlignImage:Center;ForeCo" & _
            "lor:White;}Style13{}Heading{Wrap:True;Font:Tahoma, 8.25pt, style=Bold;AlignHorz:" & _
            "Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:White;BackColor:Ligh" & _
            "tSlateGray;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style16{}" & _
            "Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowCol" & _
            "Move=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>547</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 804, 547</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 804, 547</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpIncentiveData, Me.tpEEHrs})
            Me.TabControl1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(24, 48)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(840, 600)
            Me.TabControl1.TabIndex = 16
            '
            'tpIncentiveData
            '
            Me.tpIncentiveData.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpIncentiveData.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgEEData})
            Me.tpIncentiveData.Location = New System.Drawing.Point(4, 23)
            Me.tpIncentiveData.Name = "tpIncentiveData"
            Me.tpIncentiveData.Size = New System.Drawing.Size(832, 573)
            Me.tpIncentiveData.TabIndex = 0
            Me.tpIncentiveData.Text = "Incentive Data"
            '
            'tpEEHrs
            '
            Me.tpEEHrs.BackColor = System.Drawing.Color.Lavender
            Me.tpEEHrs.Controls.AddRange(New System.Windows.Forms.Control() {Me.dgEEHrs})
            Me.tpEEHrs.Location = New System.Drawing.Point(4, 23)
            Me.tpEEHrs.Name = "tpEEHrs"
            Me.tpEEHrs.Size = New System.Drawing.Size(832, 573)
            Me.tpEEHrs.TabIndex = 1
            Me.tpEEHrs.Text = "EE Hours"
            '
            'dgEEHrs
            '
            Me.dgEEHrs.AllowColMove = False
            Me.dgEEHrs.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dgEEHrs.AllowUpdate = False
            Me.dgEEHrs.AllowUpdateOnBlur = False
            Me.dgEEHrs.AlternatingRows = True
            Me.dgEEHrs.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgEEHrs.BackColor = System.Drawing.Color.Lavender
            Me.dgEEHrs.CaptionHeight = 19
            Me.dgEEHrs.CollapseColor = System.Drawing.Color.White
            Me.dgEEHrs.ExpandColor = System.Drawing.Color.White
            Me.dgEEHrs.FilterBar = True
            Me.dgEEHrs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dgEEHrs.ForeColor = System.Drawing.Color.White
            Me.dgEEHrs.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgEEHrs.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgEEHrs.Location = New System.Drawing.Point(24, 8)
            Me.dgEEHrs.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dgEEHrs.Name = "dgEEHrs"
            Me.dgEEHrs.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgEEHrs.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgEEHrs.PreviewInfo.ZoomFactor = 75
            Me.dgEEHrs.RowHeight = 20
            Me.dgEEHrs.Size = New System.Drawing.Size(760, 500)
            Me.dgEEHrs.TabIndex = 15
            Me.dgEEHrs.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Tahoma, 8.25pt;ForeC" & _
            "olor:Black;BackColor:AliceBlue;}Selected{ForeColor:HighlightText;BackColor:Highl" & _
            "ight;}Style3{}Inactive{ForeColor:White;BackColor:InactiveCaption;}FilterBar{Font" & _
            ":Microsoft Sans Serif, 8.25pt;ForeColor:Black;BackColor:White;}Footer{Font:Tahom" & _
            "a, 8.25pt, style=Bold, Italic;AlignHorz:Far;ForeColor:White;}Caption{AlignHorz:C" & _
            "enter;ForeColor:MidnightBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, " & _
            "style=Bold;AlignVert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightR" & _
            "ow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{Font:Tahoma, 8.2" & _
            "5pt;ForeColor:Black;BackColor:LightBlue;}RecordSelector{ForeColor:White;AlignIma" & _
            "ge:Center;}Style15{}Heading{Wrap:True;Font:Tahoma, 8.25pt, style=Bold;AlignHorz:" & _
            "Center;BackColor:LightSlateGray;Border:Raised,,1, 1, 1, 1;ForeColor:White;AlignV" & _
            "ert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}" & _
            "Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowCol" & _
            "Move=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHei" & _
            "ght=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marqu" & _
            "eeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertical" & _
            "ScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>496</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 756, 496</ClientRect><BorderSide>0</Bo" & _
            "rderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Spli" & _
            "ts><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Headin" & _
            "g"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" " & _
            "/><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /" & _
            "><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /" & _
            "><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Sty" & _
            "le parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" " & _
            "/><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><" & _
            "horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRec" & _
            "SelWidth><ClientArea>0, 0, 756, 496</ClientArea><PrintPageHeaderStyle parent="""" " & _
            "me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnGo
            '
            Me.btnGo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGo.ForeColor = System.Drawing.Color.White
            Me.btnGo.Location = New System.Drawing.Point(272, 16)
            Me.btnGo.Name = "btnGo"
            Me.btnGo.Size = New System.Drawing.Size(48, 24)
            Me.btnGo.TabIndex = 17
            Me.btnGo.Text = "Go"
            '
            'btnExportCSV
            '
            Me.btnExportCSV.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExportCSV.ForeColor = System.Drawing.Color.White
            Me.btnExportCSV.Location = New System.Drawing.Point(344, 16)
            Me.btnExportCSV.Name = "btnExportCSV"
            Me.btnExportCSV.Size = New System.Drawing.Size(136, 24)
            Me.btnExportCSV.TabIndex = 18
            Me.btnExportCSV.Text = "Export to  .CSV File"
            '
            'btnExportProdPay
            '
            Me.btnExportProdPay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnExportProdPay.ForeColor = System.Drawing.Color.White
            Me.btnExportProdPay.Location = New System.Drawing.Point(504, 16)
            Me.btnExportProdPay.Name = "btnExportProdPay"
            Me.btnExportProdPay.Size = New System.Drawing.Size(264, 24)
            Me.btnExportProdPay.TabIndex = 19
            Me.btnExportProdPay.Text = "Export to  .CSV File (for Legiant Upload)"
            '
            'frmIncentiveData
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(888, 686)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExportProdPay, Me.btnExportCSV, Me.btnGo, Me.TabControl1, Me.dtpDateOfWeek, Me.lblStartDate})
            Me.Name = "frmIncentiveData"
            Me.Text = "frmIncentiveData"
            CType(Me.dgEEData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpIncentiveData.ResumeLayout(False)
            Me.tpEEHrs.ResumeLayout(False)
            CType(Me.dgEEHrs, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************************************************************
        Private Sub frmIncentiveData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
                Me.dtpDateOfWeek.Value = DateAdd(DateInterval.Day, -7, Now())
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************************
        Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click
            Dim dt As DataTable

            Dim strExceptionalCaseFlag As String = ""

            Try
                If Me.dtpDateOfWeek.Value.DayOfWeek() = DayOfWeek.Monday Then
                    strStartDate = Me.dtpDateOfWeek.Value.ToString("yyyy-MM-dd")
                Else
                    strStartDate = DateAdd(DateInterval.Day, (Me.dtpDateOfWeek.Value.DayOfWeek() - 1) * -1, Me.dtpDateOfWeek.Value).ToString("yyyy-MM-dd")
                End If

                strExceptionalCaseFlag = PSS.Data.Buisness.ModManuf.GetExceptionCriteria("HR_INCENTIVE_DATA_VIEW_COLUMNS", "Generic").Trim

                '********************************************
                'Incentive Payout data
                '********************************************
                dt = Me._objEmpIncentive.GetIncentivePayOutDataByWeek(strStartDate)

                If Not strExceptionalCaseFlag = "1" Then 'remove some columns
                    dt.Columns.Remove("AQL_FailNumber") : dt.Columns.Remove("AQL_TotalTestNumber")
                    dt.Columns.Remove("Group_ID") : dt.Columns.Remove("cc_id")
                    ' dt.Columns.Remove("TotalPayoutAmount_BeforeAQLFR")
                End If

                Me.dgEEData.DataSource = dt.DefaultView

                PSS.Data.Buisness.Generic.DisposeDT(dt)
                '********************************************
                'EE hours
                '********************************************
                dt = Me._objEmpIncentive.GetEmployeeHoursByWeek(strStartDate)

                If Not strExceptionalCaseFlag = "1" Then 'remove some columns
                    dt.Columns.Remove("AQL_FailNumber") : dt.Columns.Remove("AQL_TotalTestNumber")
                    dt.Columns.Remove("Group_ID") : dt.Columns.Remove("cc_id")
                    'dt.Columns.Remove("Pay Amount_BeforeAQLFR")
                End If

                Me.dgEEHrs.DataSource = dt.DefaultView

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnGo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************

        Private Sub btnExportCSV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExportCSV.Click
            Dim dt As DataTable
            Try
                If Me.TabControl1.SelectedIndex = 0 Then
                    If Not Me.dgEEData.RowCount > 0 Then Exit Sub
                    dt = Me.dgEEData.DataSource.table
                    dt.TableName = "Incentive_Data"
                    ' MessageBox.Show("Incentive Data: " & dt.Rows.Count)
                    Me._objEmpIncentive.CreateCSVFile(dt, Me.strStartDate)
                ElseIf Me.TabControl1.SelectedIndex = 1 Then
                    If Not Me.dgEEHrs.RowCount > 0 Then Exit Sub
                    dt = Me.dgEEHrs.DataSource.table
                    dt.TableName = "EE_Hour_Data"
                    'MessageBox.Show("EE Hour Data: " & dt.Rows.Count)
                    Me._objEmpIncentive.CreateCSVFile(dt, Me.strStartDate)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnExportCSV_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub


        '****************************************************************************************************************
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

        '****************************************************************************************************************
        Private Sub btnExportProdPay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportProdPay.Click
            Dim dt As DataTable
            Try

                If Me.dgEEHrs.RowCount > 0 Then
                    dt = Me.dgEEHrs.DataSource.table
                    dt.TableName = "Production_Pay"
                    Me._objEmpIncentive.CreateCSVFileProductionPay(dt, Me.strStartDate)
                Else
                    MessageBox.Show("No EE Hour Data!", "btnExportCSV_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnExportProdPay_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************************

    End Class
End Namespace