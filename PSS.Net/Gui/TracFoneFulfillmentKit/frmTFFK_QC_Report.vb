Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_QC_Report
        Inherits System.Windows.Forms.Form

        Private _objTFFK_QC As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_QC
        Private _dtJobs As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFK_QC = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_QC()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFK_QC = Nothing
                Catch ex As Exception
                End Try

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
        Friend WithEvents gbDate As System.Windows.Forms.GroupBox
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents gbJobs As System.Windows.Forms.GroupBox
        Friend WithEvents lblExistingJobs As System.Windows.Forms.Label
        Friend WithEvents lstExistingJobs As System.Windows.Forms.ListBox
        Friend WithEvents btnReport As System.Windows.Forms.Button
        Friend WithEvents chkDate As System.Windows.Forms.CheckBox
        Friend WithEvents chkJobs As System.Windows.Forms.CheckBox
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnViewData As System.Windows.Forms.Button
        Friend WithEvents tdgData1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTFFK_QC_Report))
            Me.gbDate = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.gbJobs = New System.Windows.Forms.GroupBox()
            Me.lstExistingJobs = New System.Windows.Forms.ListBox()
            Me.lblExistingJobs = New System.Windows.Forms.Label()
            Me.btnReport = New System.Windows.Forms.Button()
            Me.chkDate = New System.Windows.Forms.CheckBox()
            Me.chkJobs = New System.Windows.Forms.CheckBox()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.btnViewData = New System.Windows.Forms.Button()
            Me.tdgData1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.gbDate.SuspendLayout()
            Me.gbJobs.SuspendLayout()
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'gbDate
            '
            Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
            Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDate.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbDate.Location = New System.Drawing.Point(8, 32)
            Me.gbDate.Name = "gbDate"
            Me.gbDate.Size = New System.Drawing.Size(400, 80)
            Me.gbDate.TabIndex = 90
            Me.gbDate.TabStop = False
            Me.gbDate.Text = "DATE"
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndDate.ForeColor = System.Drawing.Color.Green
            Me.lblEndDate.Location = New System.Drawing.Point(24, 48)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(80, 16)
            Me.lblEndDate.TabIndex = 105
            Me.lblEndDate.Text = "End:"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpEndDate.Location = New System.Drawing.Point(112, 48)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpEndDate.TabIndex = 1
            Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate.Location = New System.Drawing.Point(112, 16)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpStartDate.TabIndex = 0
            Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStartDate.ForeColor = System.Drawing.Color.Green
            Me.lblStartDate.Location = New System.Drawing.Point(24, 16)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
            Me.lblStartDate.TabIndex = 103
            Me.lblStartDate.Text = "Start:"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'gbJobs
            '
            Me.gbJobs.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstExistingJobs, Me.lblExistingJobs})
            Me.gbJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbJobs.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbJobs.Location = New System.Drawing.Point(8, 120)
            Me.gbJobs.Name = "gbJobs"
            Me.gbJobs.Size = New System.Drawing.Size(400, 184)
            Me.gbJobs.TabIndex = 91
            Me.gbJobs.TabStop = False
            Me.gbJobs.Text = "Jobs"
            '
            'lstExistingJobs
            '
            Me.lstExistingJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstExistingJobs.ForeColor = System.Drawing.Color.Navy
            Me.lstExistingJobs.HorizontalScrollbar = True
            Me.lstExistingJobs.ItemHeight = 15
            Me.lstExistingJobs.Location = New System.Drawing.Point(104, 32)
            Me.lstExistingJobs.Name = "lstExistingJobs"
            Me.lstExistingJobs.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
            Me.lstExistingJobs.Size = New System.Drawing.Size(272, 139)
            Me.lstExistingJobs.TabIndex = 89
            '
            'lblExistingJobs
            '
            Me.lblExistingJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblExistingJobs.ForeColor = System.Drawing.Color.Green
            Me.lblExistingJobs.Location = New System.Drawing.Point(104, 8)
            Me.lblExistingJobs.Name = "lblExistingJobs"
            Me.lblExistingJobs.Size = New System.Drawing.Size(176, 24)
            Me.lblExistingJobs.TabIndex = 90
            Me.lblExistingJobs.Text = "Select Job(s):"
            Me.lblExistingJobs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnReport
            '
            Me.btnReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReport.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnReport.Location = New System.Drawing.Point(432, 40)
            Me.btnReport.Name = "btnReport"
            Me.btnReport.Size = New System.Drawing.Size(136, 40)
            Me.btnReport.TabIndex = 92
            Me.btnReport.Text = "Excel Report"
            '
            'chkDate
            '
            Me.chkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDate.Location = New System.Drawing.Point(256, 0)
            Me.chkDate.Name = "chkDate"
            Me.chkDate.Size = New System.Drawing.Size(136, 24)
            Me.chkDate.TabIndex = 93
            Me.chkDate.Text = "By QC Date"
            '
            'chkJobs
            '
            Me.chkJobs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkJobs.Location = New System.Drawing.Point(24, 0)
            Me.chkJobs.Name = "chkJobs"
            Me.chkJobs.Size = New System.Drawing.Size(216, 24)
            Me.chkJobs.TabIndex = 94
            Me.chkJobs.Text = "By QC Job Number(s)"
            '
            'btnClose
            '
            Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Location = New System.Drawing.Point(432, 0)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(136, 32)
            Me.btnClose.TabIndex = 95
            Me.btnClose.Text = "Close"
            '
            'btnViewData
            '
            Me.btnViewData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnViewData.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnViewData.Location = New System.Drawing.Point(432, 88)
            Me.btnViewData.Name = "btnViewData"
            Me.btnViewData.Size = New System.Drawing.Size(136, 40)
            Me.btnViewData.TabIndex = 96
            Me.btnViewData.Text = "View Data"
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
            Me.tdgData1.Location = New System.Drawing.Point(8, 312)
            Me.tdgData1.Name = "tdgData1"
            Me.tdgData1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgData1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgData1.PreviewInfo.ZoomFactor = 75
            Me.tdgData1.Size = New System.Drawing.Size(600, 300)
            Me.tdgData1.TabIndex = 97
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
            "alScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>298</Height><CaptionStyle pa" & _
            "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
            "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
            "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
            """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
            "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
            "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
            "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
            "nt=""Normal"" me=""Style1"" /><ClientRect>0, 0, 598, 298</ClientRect><BorderSide>0</" & _
            "BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Sp" & _
            "lits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Head" & _
            "ing"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption" & _
            """ /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected""" & _
            " /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow""" & _
            " /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><S" & _
            "tyle parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar" & _
            """ /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits" & _
            "><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultR" & _
            "ecSelWidth><ClientArea>0, 0, 598, 298</ClientArea><PrintPageHeaderStyle parent=""" & _
            """ me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmTFFK_QC_Report
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(960, 606)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgData1, Me.btnViewData, Me.btnClose, Me.chkJobs, Me.chkDate, Me.btnReport, Me.gbJobs, Me.gbDate})
            Me.Name = "frmTFFK_QC_Report"
            Me.Text = "TFFK QC Report"
            Me.gbDate.ResumeLayout(False)
            Me.gbJobs.ResumeLayout(False)
            CType(Me.tdgData1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        
        Private Sub frmTFFK_QC_Report_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Me.CenterToParent()
                PSS.Core.Highlight.SetHighLight(Me)
                Me.dtpEndDate.Value = Now.Date
                Me.dtpStartDate.Value = Now.Date.AddDays(-6)
                Me.tdgData1.Visible = False

                Me.BindJobData()

                Me.chkJobs.ForeColor = Color.Blue
                Me.chkDate.ForeColor = Color.Black
                Me.chkJobs.Checked = True
                Me.chkDate.Checked = False
                Me.gbDate.Visible = False
                Me.gbJobs.Visible = True
                Me.gbJobs.Top = gbDate.Top
                'Me.btnReport.Top = Me.gbJobs.Top + Me.gbJobs.Height + 5
                Me.lstExistingJobs.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_QC_Report_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindJobData()
            Try
                Me._dtJobs = Me._objTFFK_QC.getExistingJobs

                Me.lstExistingJobs.DataSource = Me._dtJobs
                Me.lstExistingJobs.DisplayMember = "QCJobNumber"
                Me.lstExistingJobs.ValueMember = "QCJob_ID"

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BindJobData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDate.Click
            Try

                Me.chkDate.ForeColor = Color.Blue
                Me.chkJobs.ForeColor = Color.Black
                Me.chkJobs.Checked = False
                Me.chkDate.Checked = True

                Me.gbDate.Visible = True
                Me.gbJobs.Visible = False
                ' Me.btnReport.Top = Me.gbDate.Top + Me.gbDate.Height + 5
                Me.dtpStartDate.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkDate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub chkJobs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkJobs.Click
            Try
                Me.BindJobData()

                Me.chkJobs.ForeColor = Color.Blue
                Me.chkDate.ForeColor = Color.Black
                Me.chkJobs.Checked = True
                Me.chkDate.Checked = False

                Me.gbDate.Visible = False
                Me.gbJobs.Visible = True
                Me.gbJobs.Top = gbDate.Top
                'Me.btnReport.Top = Me.gbJobs.Top + Me.gbJobs.Height + 5
                Me.lstExistingJobs.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkJobs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub DoExcelReportOrViewData(ByVal bIsExcelReport As Boolean)
            Dim i As Integer = 0
            Dim iJob_ID As Integer = 0
            Dim strJob_IDs As String = ""
            Dim dt As DataTable
            Dim strDateStart As String = ""
            Dim strDateEnd As String = ""
            Dim bAllColumns As Boolean = False
            Dim strDTime As String = Format(Now, "yyyyMMddHHmmss")
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim strPath As String = "R:\Pretest Reports\"
            Try
                If Me.lstExistingJobs.Items.Count = 0 Then Exit Sub
                Me.tdgData1.Visible = False

                If Me.gbJobs.Visible = True AndAlso Me.gbDate.Visible = False Then
                    'MessageBox.Show("OK: " & Me.lstExistingJobs.GetItemText(Me.lstExistingJobs.SelectedIndex))
                    For i = 0 To Me.lstExistingJobs.SelectedIndices.Count - 1
                        'MsgBox(Me.lstExistingJobs.SelectedIndices(i))
                        'MsgBox(DataSet1.Tables(0).Rows(Me.lstExistingJobs.SelectedIndices(i)).Item(0))
                        ' MsgBox(Me._dtJobs.Rows(Me.lstExistingJobs.SelectedIndices(i)).Item("QCJob_ID"))
                        iJob_ID = Me._dtJobs.Rows(Me.lstExistingJobs.SelectedIndices(i)).Item("QCJob_ID")
                        If strJob_IDs.Length = 0 Then
                            strJob_IDs = iJob_ID.ToString
                        Else
                            strJob_IDs &= "," & iJob_ID.ToString
                        End If
                    Next
                    If strJob_IDs.Trim.Length > 0 Then
                        dt = Me._objTFFK_QC.getTFFK_QC_Report(bAllColumns, "", "", strJob_IDs)
                        If bIsExcelReport Then 'Excel rpt
                            Me._objTFFK_QC.CreateExcelReport(dt, "TFFK QC Report (QC Jobs) " & strDTime, bAllColumns)
                        Else 'View data
                            Me.tdgData1.DataSource = dt
                            For Each dbgc In Me.tdgData1.Splits(0).DisplayColumns
                                dbgc.Locked = True
                                dbgc.AutoSize()
                            Next dbgc
                            Me.tdgData1.Top = Me.gbJobs.Top + Me.gbJobs.Height
                            Me.tdgData1.Visible = True
                        End If
                    End If
                ElseIf Me.gbDate.Visible = True AndAlso Me.gbJobs.Visible = False Then
                    If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                        strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                        strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                    Else
                        strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                        strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                    End If
                    dt = Me._objTFFK_QC.getTFFK_QC_Report(bAllColumns, strDateStart, strDateEnd, "")
                    If bIsExcelReport Then 'Excel rpt
                        CreateAQL_Metrics(dt, strPath)

                        'Me._objTFFK_QC.CreateExcelReport(dt, "TFFK QC Report (Period of QC Dates) " & strDTime, bAllColumns)
                    Else 'view data
                        Me.tdgData1.DataSource = dt
                        For Each dbgc In Me.tdgData1.Splits(0).DisplayColumns
                            dbgc.Locked = True
                            dbgc.AutoSize()
                        Next dbgc
                        Me.tdgData1.Top = Me.btnViewData.Top + Me.btnViewData.Height + 3
                        Me.tdgData1.Visible = True
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReport_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
            Me.DoExcelReportOrViewData(True)
        End Sub

        Private Sub btnViewData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewData.Click
            Me.DoExcelReportOrViewData(False)
        End Sub
        Public Sub CreateAQL_Metrics(ByVal dt1 As DataTable, ByVal strRptPath As String)
            Dim i, j As Integer
            Dim arMajor_Failures() As String = {"SIM number mismatching", "IMEI number mismatching", "SIM card wrong orientation", "Missing SIM card", "Missing charger", _
                                                    "Missing battery", "Missing battery cover", "Missing USB data cable"}
            Dim xlApp As Excel.Application
            Dim dtcolumn As DataColumn
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim xlWorkSheet1 As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value
            xlApp = New Excel.ApplicationClass()
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")
            xlWorkSheet1 = xlWorkBook.Sheets("sheet2")
            xlWorkSheet.Name = "AQL Data"
            xlWorkSheet1.Name = "Summary"
            Dim strFile As String = strRptPath & "AQL Metrics" & Date.Now.ToString("MMddyyyyhhmmss") & ".xlsx"
            With xlWorkSheet.Range("A1", "J1")
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlCenter
                .RowHeight = 30
                .Interior.Color = RGB(135, 206, 250)
                .Font.Size = 12
                .Cells.Borders.LineStyle = Excel.XlLineStyle.xlContinuous
                .Cells.Borders.Color = RGB(0, 0, 0)
                .Cells.Borders.Weight = 2D
            End With

            Dim icol As Integer
            For icol = 0 To dt1.Columns.Count - 1
                xlApp.Cells(1, icol + 1).Value = dt1.Columns(icol).ColumnName
            Next
            'Format cells Data Type
            '*****************************************
            xlWorkSheet.Range("A1", "J" & (dt1.Rows.Count + 2)).NumberFormat = "@"
            For i = 0 To dt1.Rows.Count - 1
                For j = 0 To dt1.Columns.Count - 1
                    Dim strFailure As String
                    Dim stQcResult As String = dt1.Rows(i).Item("QcResult")
                    If stQcResult.Trim = "Fail" Then
                        strFailure = dt1.Rows(i).Item("Fail Details")
                        If (Array.IndexOf(arMajor_Failures, strFailure.ToUpper) <> -1) Then
                            With xlWorkSheet.Range("A" & (i + 2) & ":J" & (i + 2))
                                .Font.Color = RGB(246, 70, 91)
                            End With
                        End If
                    End If
                    xlWorkSheet.Cells(i + 2, j + 1) = dt1.Rows(i).Item(j)
                Next
            Next
            Dim xlRange2 As Excel.Range = CType(xlWorkSheet1, Excel.Worksheet).Range("B3")
            Dim xlRange As Excel.Range = xlWorkSheet.Range("A1:J" & dt1.Rows.Count + 1)
            ' Create pivot cache and table

            Dim ptCache As Excel.PivotCache = xlWorkBook.PivotCaches.Add(Excel.XlPivotTableSourceType.xlDatabase, xlRange)
            Dim ptTable As Excel.PivotTable = xlWorkSheet1.PivotTables.Add(PivotCache:=ptCache, TableDestination:=xlRange2, TableName:="Summary")
            Dim ptFilter As Excel.PivotField = ptTable.PivotFields("QC_Line")
            With ptFilter
                .Orientation = Excel.XlPivotFieldOrientation.xlPageField
                .Name = "QC_Line"
            End With

            Dim ptField As Excel.PivotField = ptTable.PivotFields("QCResult")
            With ptField
                .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                .Name = "QCResult"
            End With
            Dim ptField2 As Excel.PivotField = ptTable.PivotFields("FailCode")
            With ptField2
                .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                .Name = "Fail Code"
            End With

            Dim ptField3 As Excel.PivotField = ptTable.PivotFields("Fail Details")
            With ptField3
                .Orientation = Excel.XlPivotFieldOrientation.xlRowField
                .Orientation = Excel.XlPivotFieldOrientation.xlDataField
                .Function = Excel.XlConsolidationFunction.xlCount
                .Name = "Fail Details data"  ' this is how you create another field, in my example I don't need it so let's comment it out
            End With

            ptTable.ShowDrillIndicators = False
            xlRange.EntireColumn.AutoFit()
            xlWorkSheet.Range("A1", "J" & (dt1.Rows.Count + 1)).Value = xlWorkSheet.Range("A1", "J" & (dt1.Rows.Count + 1)).Value
            xlWorkSheet.SaveAs(strFile)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            MsgBox("You can find the file " & strFile)
        End Sub
        Private Sub releaseObject(ByVal obj As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
            Finally
                GC.Collect()
            End Try
        End Sub
    End Class
End Namespace
