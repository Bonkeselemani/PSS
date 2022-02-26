Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.WingTech

    Public Class frmWingTech_Report
        Inherits System.Windows.Forms.Form
        Private _iCust_ID As Integer = 0
        'Private _iLoc_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _strRptName As String = ""
        Private _objWingTech As PSS.Data.Buisness.WingTech.WingTech
        Private _objWingTech_Report As PSS.Data.Buisness.WingTech.WingTech_Report
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
        Private iOption As Integer = 0    'iOption equal to 0 if it's by date and 1 if it's by SN
        Private strDateStart, strDateEnd As String
        Private strImei As String
        Public Enum ReportNames As Integer
            RA_uploaded_report = 1
            Received_Report = 2
            Shipped_Report = 3
            Status_Report = 4
            Pretest_Report = 5
            Invoice = 6
            Part_Used = 7
        End Enum
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            ' Me._iLoc_ID = iLoc_ID
            Me._strScreenName = strScreenName
            Me._objWingTech = New PSS.Data.Buisness.WingTech.WingTech()
            Me._objWingTech_Report = New PSS.Data.Buisness.WingTech.WingTech_Report()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objWingTech = Nothing
                    Me._objWingTech_Report = Nothing
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
        Friend WithEvents grpRptType As System.Windows.Forms.GroupBox
        Friend WithEvents rbtOriginal As System.Windows.Forms.RadioButton
        Friend WithEvents rbtDefault As System.Windows.Forms.RadioButton
        Friend WithEvents grpSN As System.Windows.Forms.GroupBox
        Friend WithEvents rdSN As System.Windows.Forms.RadioButton
        Friend WithEvents rbDate As System.Windows.Forms.RadioButton
        Friend WithEvents grpImeiFile As System.Windows.Forms.GroupBox
        Friend WithEvents strImeiNumber As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents ImeiNumber As System.Windows.Forms.RichTextBox
        Friend WithEvents gbDate As System.Windows.Forms.GroupBox
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents gbWorkOrder As System.Windows.Forms.GroupBox
        Friend WithEvents txtWorkOrder As System.Windows.Forms.TextBox
        Friend WithEvents btnRunRpt As System.Windows.Forms.Button
        Friend WithEvents gbReportName As System.Windows.Forms.GroupBox
        Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grpRptType = New System.Windows.Forms.GroupBox()
            Me.rbtOriginal = New System.Windows.Forms.RadioButton()
            Me.rbtDefault = New System.Windows.Forms.RadioButton()
            Me.grpSN = New System.Windows.Forms.GroupBox()
            Me.rdSN = New System.Windows.Forms.RadioButton()
            Me.rbDate = New System.Windows.Forms.RadioButton()
            Me.grpImeiFile = New System.Windows.Forms.GroupBox()
            Me.strImeiNumber = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.ImeiNumber = New System.Windows.Forms.RichTextBox()
            Me.gbDate = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.gbWorkOrder = New System.Windows.Forms.GroupBox()
            Me.txtWorkOrder = New System.Windows.Forms.TextBox()
            Me.btnRunRpt = New System.Windows.Forms.Button()
            Me.gbReportName = New System.Windows.Forms.GroupBox()
            Me.cboReportName = New System.Windows.Forms.ComboBox()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.cboLocation = New System.Windows.Forms.ComboBox()
            Me.grpRptType.SuspendLayout()
            Me.grpSN.SuspendLayout()
            Me.grpImeiFile.SuspendLayout()
            Me.gbDate.SuspendLayout()
            Me.gbWorkOrder.SuspendLayout()
            Me.gbReportName.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'grpRptType
            '
            Me.grpRptType.BackColor = System.Drawing.Color.LightSkyBlue
            Me.grpRptType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtOriginal, Me.rbtDefault})
            Me.grpRptType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpRptType.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.grpRptType.Location = New System.Drawing.Point(16, 383)
            Me.grpRptType.Name = "grpRptType"
            Me.grpRptType.Size = New System.Drawing.Size(400, 48)
            Me.grpRptType.TabIndex = 127
            Me.grpRptType.TabStop = False
            '
            'rbtOriginal
            '
            Me.rbtOriginal.BackColor = System.Drawing.Color.LightSkyBlue
            Me.rbtOriginal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtOriginal.ForeColor = System.Drawing.Color.Black
            Me.rbtOriginal.Location = New System.Drawing.Point(208, 16)
            Me.rbtOriginal.Name = "rbtOriginal"
            Me.rbtOriginal.Size = New System.Drawing.Size(184, 24)
            Me.rbtOriginal.TabIndex = 1
            Me.rbtOriginal.Text = "Original Column"
            '
            'rbtDefault
            '
            Me.rbtDefault.BackColor = System.Drawing.Color.LightSkyBlue
            Me.rbtDefault.Checked = True
            Me.rbtDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtDefault.ForeColor = System.Drawing.Color.Black
            Me.rbtDefault.Location = New System.Drawing.Point(32, 16)
            Me.rbtDefault.Name = "rbtDefault"
            Me.rbtDefault.Size = New System.Drawing.Size(128, 24)
            Me.rbtDefault.TabIndex = 0
            Me.rbtDefault.TabStop = True
            Me.rbtDefault.Text = "Default Column"
            '
            'grpSN
            '
            Me.grpSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdSN, Me.rbDate})
            Me.grpSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpSN.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.grpSN.Location = New System.Drawing.Point(16, 319)
            Me.grpSN.Name = "grpSN"
            Me.grpSN.Size = New System.Drawing.Size(400, 56)
            Me.grpSN.TabIndex = 129
            Me.grpSN.TabStop = False
            '
            'rdSN
            '
            Me.rdSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rdSN.ForeColor = System.Drawing.Color.Black
            Me.rdSN.Location = New System.Drawing.Point(208, 16)
            Me.rdSN.Name = "rdSN"
            Me.rdSN.Size = New System.Drawing.Size(184, 24)
            Me.rdSN.TabIndex = 1
            Me.rdSN.Text = "By SN"
            '
            'rbDate
            '
            Me.rbDate.Checked = True
            Me.rbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbDate.ForeColor = System.Drawing.Color.Black
            Me.rbDate.Location = New System.Drawing.Point(24, 16)
            Me.rbDate.Name = "rbDate"
            Me.rbDate.Size = New System.Drawing.Size(128, 24)
            Me.rbDate.TabIndex = 0
            Me.rbDate.TabStop = True
            Me.rbDate.Text = "By Date"
            '
            'grpImeiFile
            '
            Me.grpImeiFile.Controls.AddRange(New System.Windows.Forms.Control() {Me.strImeiNumber, Me.Button1, Me.ImeiNumber})
            Me.grpImeiFile.Location = New System.Drawing.Point(440, 23)
            Me.grpImeiFile.Name = "grpImeiFile"
            Me.grpImeiFile.Size = New System.Drawing.Size(192, 496)
            Me.grpImeiFile.TabIndex = 128
            Me.grpImeiFile.TabStop = False
            '
            'strImeiNumber
            '
            Me.strImeiNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.strImeiNumber.Location = New System.Drawing.Point(16, 56)
            Me.strImeiNumber.Name = "strImeiNumber"
            Me.strImeiNumber.Size = New System.Drawing.Size(160, 16)
            Me.strImeiNumber.TabIndex = 110
            Me.strImeiNumber.Text = "0 IMEI"
            Me.strImeiNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Button1
            '
            Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button1.ForeColor = System.Drawing.Color.Black
            Me.Button1.Location = New System.Drawing.Point(8, 16)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(168, 32)
            Me.Button1.TabIndex = 109
            Me.Button1.Text = "Upload IMEIs from the File"
            '
            'ImeiNumber
            '
            Me.ImeiNumber.Location = New System.Drawing.Point(8, 80)
            Me.ImeiNumber.Name = "ImeiNumber"
            Me.ImeiNumber.ReadOnly = True
            Me.ImeiNumber.Size = New System.Drawing.Size(168, 400)
            Me.ImeiNumber.TabIndex = 108
            Me.ImeiNumber.Text = ""
            '
            'gbDate
            '
            Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
            Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDate.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbDate.Location = New System.Drawing.Point(16, 223)
            Me.gbDate.Name = "gbDate"
            Me.gbDate.Size = New System.Drawing.Size(400, 80)
            Me.gbDate.TabIndex = 121
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
            'gbWorkOrder
            '
            Me.gbWorkOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWorkOrder})
            Me.gbWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbWorkOrder.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbWorkOrder.Location = New System.Drawing.Point(16, 487)
            Me.gbWorkOrder.Name = "gbWorkOrder"
            Me.gbWorkOrder.Size = New System.Drawing.Size(400, 48)
            Me.gbWorkOrder.TabIndex = 125
            Me.gbWorkOrder.TabStop = False
            Me.gbWorkOrder.Text = "WORK ORDER NAME:"
            '
            'txtWorkOrder
            '
            Me.txtWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWorkOrder.Location = New System.Drawing.Point(112, 16)
            Me.txtWorkOrder.Name = "txtWorkOrder"
            Me.txtWorkOrder.Size = New System.Drawing.Size(272, 20)
            Me.txtWorkOrder.TabIndex = 1
            Me.txtWorkOrder.Text = ""
            '
            'btnRunRpt
            '
            Me.btnRunRpt.BackColor = System.Drawing.Color.MidnightBlue
            Me.btnRunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRunRpt.ForeColor = System.Drawing.Color.White
            Me.btnRunRpt.Location = New System.Drawing.Point(16, 439)
            Me.btnRunRpt.Name = "btnRunRpt"
            Me.btnRunRpt.Size = New System.Drawing.Size(400, 32)
            Me.btnRunRpt.TabIndex = 122
            '
            'gbReportName
            '
            Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReportName})
            Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbReportName.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbReportName.Location = New System.Drawing.Point(16, 87)
            Me.gbReportName.Name = "gbReportName"
            Me.gbReportName.Size = New System.Drawing.Size(400, 48)
            Me.gbReportName.TabIndex = 123
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
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Location = New System.Drawing.Point(128, 31)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(208, 32)
            Me.lblTitle.TabIndex = 124
            Me.lblTitle.Text = "WingTech Report"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLocation})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.GroupBox1.Location = New System.Drawing.Point(16, 159)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(400, 48)
            Me.GroupBox1.TabIndex = 126
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "LOCATION "
            '
            'cboLocation
            '
            Me.cboLocation.ItemHeight = 13
            Me.cboLocation.Location = New System.Drawing.Point(112, 16)
            Me.cboLocation.MaxDropDownItems = 25
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(272, 21)
            Me.cboLocation.TabIndex = 6
            '
            'frmWingTech_Report
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSkyBlue
            Me.ClientSize = New System.Drawing.Size(648, 558)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpRptType, Me.grpSN, Me.grpImeiFile, Me.gbDate, Me.gbWorkOrder, Me.btnRunRpt, Me.gbReportName, Me.lblTitle, Me.GroupBox1})
            Me.Name = "frmWingTech_Report"
            Me.Text = "frmWingTech_Report"
            Me.grpRptType.ResumeLayout(False)
            Me.grpSN.ResumeLayout(False)
            Me.grpImeiFile.ResumeLayout(False)
            Me.gbDate.ResumeLayout(False)
            Me.gbWorkOrder.ResumeLayout(False)
            Me.gbReportName.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWingTech_Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try

                Dim i As Integer = _objWingTech_Report.getCustomerLocation(_iCust_ID, cboLocation)
                If i = 0 Then cboLocation.Text = "Select Location"
                Me.cboReportName.Items.Clear()
                Me.cboReportName.Items.Add("Select Report Name")
                Dim item
                For Each item In [Enum].GetNames(GetType(ReportNames)) ' [Enum].GetValues(typeof(ReportNames))
                    Me.cboReportName.Items.Add(item.ToString) ' .Replace("_", " "))
                Next
                Me.cboReportName.Text = "Select Report Name"
                Me.gbDate.Visible = False
                Me.gbWorkOrder.Visible = False
                Me.btnRunRpt.Visible = False
                Me.grpSN.Visible = False
                Me.dtpStartDate.Value = Now()
                Me.dtpEndDate.Value = Now()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim openFileIMEI As New OpenFileDialog()
            openFileIMEI.Title = "Please select a Text file"
            openFileIMEI.Filter = "Text File|*.txt"

            If openFileIMEI.ShowDialog() = DialogResult.OK Then
                Dim strPath As String = openFileIMEI.FileName
                If strPath = "" Then
                    MessageBox.Show("Select a File ", "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Me.ImeiNumber.LoadFile(strPath, RichTextBoxStreamType.PlainText)
                Dim iImeiNumber = ImeiNumber.Lines.Length - 1
                strImeiNumber.Text = "0 IMEI"
                strImeiNumber.Text = iImeiNumber & " IMEIs"
            End If

        End Sub
        Private Sub btnRunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunRpt.Click

            Dim strTempname As String = ""
            Dim dStartDate As Date
            Dim i As Integer = 0
            Dim strLocation As String
            Dim colDefault As Boolean = False
            If rbtDefault.Checked Then
                colDefault = True
                strTempname &= "_Default_"
            Else
                strTempname &= "_Original_"
            End If

            Try
                If Me.gbDate.Visible = True AndAlso DateDiff(DateInterval.Day, Me.dtpStartDate.Value, Me.dtpEndDate.Value) < 0 Then
                    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.gbWorkOrder.Visible = True AndAlso (Me.txtWorkOrder.Text.Trim.Length = 0) Then
                    MessageBox.Show("Please select WorkOrder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.cboLocation.Text = "" OrElse Me.cboLocation.Text = "Select Location" Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    strDateStart = "" : strDateEnd = ""
                    strLocation = Me.cboLocation.Text
                    If Me.gbDate.Visible = True Then
                        If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                            strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd 23:59:59")
                            strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd 00:00:00")
                        Else
                            strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd 00:00:00")
                            strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd 23:59:59")
                        End If
                    End If
                    '*************************************
                    'Generate Report
                    '*************************************
                    _objWingTech_Report = New PSS.Data.Buisness.WingTech.WingTech_Report()
                    _objWingTech_Report.colDefault = colDefault

                    If iOption = 1 Then
                        Dim j As Integer
                        j = readRichTextContent()
                        If j = 0 Then
                            MessageBox.Show("NO IMEI data selected", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    End If

                    'IF Report =RA_uploaded_report
                    If Me._strRptName = Me.ReportNames.RA_uploaded_report.ToString Then
                        i = _objWingTech_Report.CreateInventoryReport(Me._iCust_ID, _strRptName & strTempname, strDateStart, strDateEnd, strLocation, 1, iOption, strImei)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'IF Report =Received_Report
                    ElseIf Me._strRptName = Me.ReportNames.Received_Report.ToString Then
                        i = _objWingTech_Report.CreateInventoryReport(Me._iCust_ID, _strRptName & strTempname, strDateStart, strDateEnd, strLocation, 2, iOption, strImei)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'IF Report =part used
                    ElseIf Me._strRptName = Me.ReportNames.Part_Used.ToString Then
                        i = _objWingTech_Report.CreateASN(Me._iCust_ID, _strRptName & strTempname, strDateStart, strDateEnd, strLocation, 7, iOption, strImei)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'IF Report =Shipped_Report
                    ElseIf Me._strRptName = Me.ReportNames.Shipped_Report.ToString Then
                        i = _objWingTech_Report.CreateASN(Me._iCust_ID, _strRptName & strTempname, strDateStart, strDateEnd, strLocation, 3, iOption, strImei)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'IF Report =Status_Report
                    ElseIf Me._strRptName = Me.ReportNames.Status_Report.ToString Then
                        i = _objWingTech_Report.CreateInventoryReport(Me._iCust_ID, _strRptName & strTempname, strDateStart, strDateEnd, strLocation, 4, iOption, strImei)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'IF Report =Pretest_Report
                    ElseIf Me._strRptName = Me.ReportNames.Pretest_Report.ToString Then
                        i = _objWingTech_Report.CreatePretestRawDataRpt(strDateStart, strDateEnd, "", strLocation, iOption, strImei)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._strRptName = Me.ReportNames.Invoice.ToString Then
                        i = _objWingTech_Report.CreateASN(Me._iCust_ID, _strRptName & strTempname, strDateStart, strDateEnd, strLocation, 6, iOption, strImei)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                'objTNRpt = Nothing
                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
                If ImeiNumber.Text <> String.Empty Then
                    ImeiNumber.Text = ""
                    strImeiNumber.Text = "0 IMEI"
                End If
            End Try
        End Sub
        Private Function readRichTextContent() As Integer
            Dim i As Integer
            Dim iIMEI As Integer
            Dim iCond As Integer = 1
            strImei = ""
            Dim iCount As Integer
            iCount = ImeiNumber.Lines.Length

            If iCount <> 0 Then
                For i = 0 To ImeiNumber.Lines.Length - 2

                    If IsNumeric(ImeiNumber.Lines(i)) Then
                        If i <> ImeiNumber.Lines.Length - 2 Then
                            strImei += "'" + (ImeiNumber.Lines(i).ToString) + "',"
                        Else
                            strImei += "'" + (ImeiNumber.Lines(i).ToString) + "'"
                        End If
                    Else
                        iCond = 0
                        Exit For
                    End If
                Next
                Return iCond
            Else
                Return 0
            End If

        End Function
        Private Sub rbDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbDate.CheckedChanged
            If rbDate.Checked = True Then
                Me.gbDate.Enabled = True
                Me.grpImeiFile.Visible = False
                iOption = 0
            End If
        End Sub

        Private Sub rdSN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdSN.CheckedChanged
            If rdSN.Checked = True Then
                Me.gbDate.Enabled = False
                Me.grpImeiFile.Visible = True
                iOption = 1
            End If
        End Sub

        Private Sub cboReportName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.SelectedIndexChanged
            Dim dt As DataTable
            Me._strRptName = ""
            Me.gbDate.Visible = False
            Me.gbWorkOrder.Visible = False
            Me.btnRunRpt.Visible = False
            Me.gbDate.Text = "DATE"
            Me.grpImeiFile.Visible = False
            Me.grpSN.Visible = False
            Me.rbDate.Checked = True
            Me.rbDate.Enabled = True

            Try
                If Me.cboReportName.Text <> "Select Report Name" Then
                    Me._strRptName = Me.cboReportName.Text

                    If Me._strRptName = Me.ReportNames.RA_uploaded_report.ToString Then
                        Me.gbDate.Visible = True
                        Me.gbDate.Text = "UPLOAD DATE"
                    ElseIf Me._strRptName = Me.ReportNames.Received_Report.ToString Then
                        Me.gbDate.Visible = True
                        Me.gbDate.Text = "RECEIVED DATE"
                    ElseIf Me._strRptName = Me.ReportNames.Part_Used.ToString Then
                        Me.gbDate.Visible = True
                        Me.gbDate.Text = "PART USED"
                    ElseIf Me._strRptName = Me.ReportNames.Shipped_Report.ToString Then
                        Me.gbDate.Visible = True
                        Me.gbDate.Text = "SHIPPED DATE"
                    ElseIf Me._strRptName = Me.ReportNames.Status_Report.ToString Then
                        Me.gbDate.Visible = True
                        Me.gbDate.Text = "STATUS DATE"
                    ElseIf Me._strRptName = Me.ReportNames.Pretest_Report.ToString Then
                        Me.gbDate.Visible = True
                        Me.gbDate.Text = "PRETEST DATE"
                    ElseIf Me._strRptName = Me.ReportNames.Invoice.ToString Then
                        Me.gbDate.Visible = True
                        Me.gbDate.Text = "INVOICE DATE"
                    End If
                    Me.grpSN.Visible = True
                    Me.grpRptType.Visible = True
                    Me.btnRunRpt.Text = "Get """ & _strRptName & """"
                    Me.btnRunRpt.Visible = True
                Else
                    Me.grpRptType.Visible = False
                    Me.btnRunRpt.Text = ""
                    Me.btnRunRpt.Visible = False
                    Me.grpSN.Visible = False
                End If
                If Me._strRptName = Me.ReportNames.Invoice.ToString Or Me._strRptName = Me.ReportNames.Pretest_Report.ToString Then
                    Me.grpRptType.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboReportName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub
    End Class
End Namespace
