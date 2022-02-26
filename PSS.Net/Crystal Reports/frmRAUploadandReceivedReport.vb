Imports PSS.Misc
Imports PSS.Data.Buisness


Public Class frmRAUploadandReceivedReport
    Inherits System.Windows.Forms.Form

    Private _objCrystalReports As PSS.Data.CrystalReports
    Private _strReportTitle As String
    Private _bUseParams() As Boolean = {False, False, False, False, False, False, False, False, False, False}
    Private _objWorkbook As Excel.Workbook
    Private iOption As Integer = 0    'iOption equal to 0 if it's by date and 1 if it's by SN
    Private strImei As String
    Private _xlRC As Data.ExcelReports.Excel_Report_Call
    Private _strRptName As String = ""
    Private strDateStart, strDateEnd As String
    Public Enum ReportNames As Integer

        RA_uploaded_report = 1
        Received_Report = 2
    End Enum
    Private iCustID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strReportTitlePlusParam As String, ByVal rc As Data.CrystalReports.Report_Call)
        MyBase.New() ' Must be first statement

        Dim bGetMainCustomers As Boolean = True

        Cursor.Current = Cursors.WaitCursor

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        If strReportTitlePlusParam.IndexOf("Parameters") > -1 Then
            Me._strReportTitle = strReportTitlePlusParam.Substring(0, strReportTitlePlusParam.IndexOf("Parameters")).Trim
        Else
            Me._strReportTitle = strReportTitlePlusParam
        End If

        Me._objCrystalReports = New PSS.Data.CrystalReports(Me._strReportTitle, rc)

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
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents gbReportName As System.Windows.Forms.GroupBox
    Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
    Friend WithEvents gbDate As System.Windows.Forms.GroupBox
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmRAUploadandReceivedReport))
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.gbReportName = New System.Windows.Forms.GroupBox()
        Me.cboReportName = New System.Windows.Forms.ComboBox()
        Me.gbDate = New System.Windows.Forms.GroupBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbReportName.SuspendLayout()
        Me.gbDate.SuspendLayout()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRunReport
        '
        Me.btnRunReport.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(176, 256)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(104, 32)
        Me.btnRunReport.TabIndex = 2
        Me.btnRunReport.Text = "Run Report"
        '
        'gbReportName
        '
        Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReportName})
        Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.gbReportName.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.gbReportName.Location = New System.Drawing.Point(16, 136)
        Me.gbReportName.Name = "gbReportName"
        Me.gbReportName.Size = New System.Drawing.Size(400, 48)
        Me.gbReportName.TabIndex = 31
        Me.gbReportName.TabStop = False
        Me.gbReportName.Text = "REPORT NAME"
        '
        'cboReportName
        '
        Me.cboReportName.ItemHeight = 13
        Me.cboReportName.Location = New System.Drawing.Point(112, 16)
        Me.cboReportName.MaxDropDownItems = 25
        Me.cboReportName.Name = "cboReportName"
        Me.cboReportName.Size = New System.Drawing.Size(272, 21)
        Me.cboReportName.TabIndex = 6
        '
        'gbDate
        '
        Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
        Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDate.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
        Me.gbDate.Location = New System.Drawing.Point(24, 24)
        Me.gbDate.Name = "gbDate"
        Me.gbDate.Size = New System.Drawing.Size(400, 80)
        Me.gbDate.TabIndex = 32
        Me.gbDate.TabStop = False
        Me.gbDate.Text = "DATE"
        '
        'lblEndDate
        '
        Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.ForeColor = System.Drawing.Color.Black
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
        Me.lblStartDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblStartDate.Location = New System.Drawing.Point(24, 16)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
        Me.lblStartDate.TabIndex = 103
        Me.lblStartDate.Text = "Start:"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCustomers
        '
        Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCustomers.Caption = ""
        Me.cboCustomers.CaptionHeight = 17
        Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCustomers.ColumnCaptionHeight = 17
        Me.cboCustomers.ColumnFooterHeight = 17
        Me.cboCustomers.ContentHeight = 15
        Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomers.EditorHeight = 15
        Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(128, 200)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(272, 21)
        Me.cboCustomers.TabIndex = 33
        Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
        "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
        "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 200)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmRAUploadandReceivedReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(912, 753)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCustomers, Me.Label1, Me.gbDate, Me.gbReportName, Me.btnRunReport})
        Me.Name = "frmRAUploadandReceivedReport"
        Me.Text = "frmRAUploadandReceivedReport"
        Me.gbReportName.ResumeLayout(False)
        Me.gbDate.ResumeLayout(False)
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmRAUploadandReceivedReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            Me.dtpStartDate.Value = Now()
            Me.dtpEndDate.Value = Now()
            Me.cboReportName.Items.Clear()
            Me.cboReportName.Items.Add("Select Report Name")
            Dim item
            For Each item In [Enum].GetNames(GetType(ReportNames)) ' [Enum].GetValues(typeof(ReportNames))
                Me.cboReportName.Items.Add(item.ToString) ' .Replace("_", " "))
            Next
            Me.cboReportName.Text = "Select Report Name"
            LoadCustomers()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click
        Try
            Dim strTempname As String = ""
            Dim strSubRptNames() As String = {"", "", ""}
            Dim i As Integer = 0
            Dim strReportNAme As String
            Dim ds As DataSet
            Dim dt As DataTable
            Dim win As Crownwood.Magic.Controls.TabPage
            strTempname &= "_Default_"

            If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd 23:59:59")
                strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd 00:00:00")
            Else
                strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd 00:00:00")
                strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd 23:59:59")
            End If


            If Me._strRptName = Me.ReportNames.RA_uploaded_report.ToString Then
                _strReportTitle = "AdminRAUpload"
                strReportNAme = Me._strReportTitle '& ".rpt"
                _objCrystalReports.ReportTitle = Me._strReportTitle
                i = _objCrystalReports.GetCrystalReportData(Me.cboCustomers.SelectedValue, _strRptName & strTempname, strDateStart, strDateEnd, 1, iOption, strImei)

                If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'IF Report =Received_Report
            ElseIf Me._strRptName = Me.ReportNames.Received_Report.ToString Then
                _strReportTitle = "AdminReceived"
                strReportNAme = Me._strReportTitle '& ".rpt"
                _objCrystalReports.ReportTitle = Me._strReportTitle
                i = _objCrystalReports.GetCrystalReportData(Me.cboCustomers.SelectedValue, _strRptName & strTempname, strDateStart, strDateEnd, 2, iOption, strImei)
            End If

            'win = New Crownwood.Magic.Controls.TabPage(Me._strReportTitle & " Report", New RptViewer(strReportNAme, ds, Me._objCrystalReports.GetSubReportNames()))

            'Gui.MainWin.MainWin.wrkArea.TabPages.Add(win)
            'win.Selected = True
            'Me._objCrystalReports.IncludeBrightpoint = False
            '_objCrystalReports.AutoBillFlag = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cboReportName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReportName.TextChanged
        Me._strRptName = ""
        Me._strRptName = Me.cboReportName.Text
    End Sub
    Private Sub LoadCustomers()
        Dim dt As DataTable

        iCustID = 0
        Try
            '****************************************
            'Load Customer
            '***************************************
            Me.cboCustomers.DataSource = Nothing
            dt = Generic.GetCustomers(True, , )
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
            Me.cboCustomers.SelectedValue = iCustID
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

End Class
