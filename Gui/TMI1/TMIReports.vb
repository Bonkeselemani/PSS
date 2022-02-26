Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class TMIReports
        Inherits System.Windows.Forms.Form

        Public _strScreenName As String = ""
        Public _iMenuCust As Integer = 0
        Private _strRptName As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _iMenuCust = iCustID
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
        Friend WithEvents gbWorkOrder As System.Windows.Forms.GroupBox
        Friend WithEvents txtWorkOrder As System.Windows.Forms.TextBox
        Friend WithEvents btnRunRpt As System.Windows.Forms.Button
        Friend WithEvents gbDate As System.Windows.Forms.GroupBox
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.gbReportName = New System.Windows.Forms.GroupBox()
            Me.cboReportName = New System.Windows.Forms.ComboBox()
            Me.gbWorkOrder = New System.Windows.Forms.GroupBox()
            Me.txtWorkOrder = New System.Windows.Forms.TextBox()
            Me.btnRunRpt = New System.Windows.Forms.Button()
            Me.gbDate = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.gbReportName.SuspendLayout()
            Me.gbWorkOrder.SuspendLayout()
            Me.gbDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbReportName
            '
            Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReportName})
            Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbReportName.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbReportName.Location = New System.Drawing.Point(24, 16)
            Me.gbReportName.Name = "gbReportName"
            Me.gbReportName.Size = New System.Drawing.Size(400, 48)
            Me.gbReportName.TabIndex = 16
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
            'gbWorkOrder
            '
            Me.gbWorkOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWorkOrder})
            Me.gbWorkOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbWorkOrder.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbWorkOrder.Location = New System.Drawing.Point(24, 168)
            Me.gbWorkOrder.Name = "gbWorkOrder"
            Me.gbWorkOrder.Size = New System.Drawing.Size(400, 48)
            Me.gbWorkOrder.TabIndex = 15
            Me.gbWorkOrder.TabStop = False
            Me.gbWorkOrder.Text = "WORK ORDER NAME:"
            '
            'txtWorkOrder
            '
            Me.txtWorkOrder.Location = New System.Drawing.Point(112, 16)
            Me.txtWorkOrder.Name = "txtWorkOrder"
            Me.txtWorkOrder.Size = New System.Drawing.Size(272, 20)
            Me.txtWorkOrder.TabIndex = 1
            Me.txtWorkOrder.Text = ""
            '
            'btnRunRpt
            '
            Me.btnRunRpt.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRunRpt.ForeColor = System.Drawing.Color.White
            Me.btnRunRpt.Location = New System.Drawing.Point(24, 224)
            Me.btnRunRpt.Name = "btnRunRpt"
            Me.btnRunRpt.Size = New System.Drawing.Size(400, 32)
            Me.btnRunRpt.TabIndex = 14
            '
            'gbDate
            '
            Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
            Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDate.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbDate.Location = New System.Drawing.Point(24, 72)
            Me.gbDate.Name = "gbDate"
            Me.gbDate.Size = New System.Drawing.Size(400, 80)
            Me.gbDate.TabIndex = 13
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
            'TMIReports
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(600, 470)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbReportName, Me.gbWorkOrder, Me.btnRunRpt, Me.gbDate})
            Me.Name = "TMIReports"
            Me.Text = "TMIReports"
            Me.gbReportName.ResumeLayout(False)
            Me.gbWorkOrder.ResumeLayout(False)
            Me.gbDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***********************************************************************************************
        Private Sub TMIReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.cboReportName.Items.Clear()
                Me.cboReportName.Items.Add("Select Report Name")
               
                Me.cboReportName.Items.Add("Box Tracking")
                Me.cboReportName.Items.Add("Need Part(s)")
                Me.cboReportName.Items.Add("WIP")
                Me.cboReportName.Items.Add("Completed Units Shipped")
                Me.cboReportName.Items.Add("Invoice")
                Me.cboReportName.Items.Add("Days After Box Shipped")
                Me.cboReportName.Items.Add("Charges for 30-Day Non Return")

                Me.cboReportName.Text = "Select Report Name"

                Me.gbDate.Visible = False
                Me.gbWorkOrder.Visible = False
                Me.btnRunRpt.Visible = False

                Me.dtpStartDate.Value = Now()
                Me.dtpEndDate.Value = Now()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************
        Private Sub cboReportName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.TextChanged
            Dim dt As DataTable

            Me._strRptName = ""
            Me.gbDate.Visible = False
            Me.gbWorkOrder.Visible = False
            Me.btnRunRpt.Visible = False

            Try
                If Me.cboReportName.Text <> "Select Report Name" Then
                    Me._strRptName = Me.cboReportName.Text

                    If Me._strRptName = "Box Tracking" Then
                        Me.gbDate.Visible = True
                    ElseIf Me._strRptName = "Need Part(s)" Then
                        Me.gbDate.Visible = True
                    ElseIf Me._strRptName = "WIP" Then
                        Me.gbDate.Visible = False
                    ElseIf Me._strRptName = "Completed Units Shipped" Then
                        Me.gbDate.Visible = True
                    ElseIf Me._strRptName = "Invoice" Then
                        Me.gbDate.Visible = True
                    ElseIf Me._strRptName = "Days After Box Shipped" Then
                        Me.gbDate.Visible = False
                    ElseIf Me._strRptName = "Charges for 30-Day Non Return" Then
                        Me.gbDate.Visible = True
                        Me.dtpStartDate.Value = Now.Date.AddDays(-60)
                        Me.dtpEndDate.Value = Now.Date
                    End If

                    Me.btnRunRpt.Text = "Get """ & _strRptName & """"
                    Me.btnRunRpt.Visible = True

                Else
                    Me.btnRunRpt.Text = ""
                    Me.btnRunRpt.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboReportName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '***********************************************************************************************
        Private Sub btnRunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunRpt.Click
            Dim objTMIRpt As PSS.Data.Buisness.TMIReports
            Dim strDateStart, strDateEnd As String
            Dim i As Integer = 0

            Try
                If Me.gbDate.Visible = True AndAlso DateDiff(DateInterval.Day, Me.dtpStartDate.Value, Me.dtpEndDate.Value) < 0 Then
                    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.gbWorkOrder.Visible = True AndAlso (Me.txtWorkOrder.Text.Trim.Length = 0) Then
                    MessageBox.Show("Please select WorkOrder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    strDateStart = "" : strDateEnd = ""

                    If Me.gbDate.Visible = True Then
                        If Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                            strDateEnd = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                            strDateStart = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                        Else
                            strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                            strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                        End If

                    End If

                    '*************************************
                    'Generate Report
                    '*************************************
                    If Me._strRptName = "Box Tracking" Then
                        objTMIRpt = New PSS.Data.Buisness.TMIReports()
                        i = objTMIRpt.CreateBoxTrackingRpt(_iMenuCust, Me._strRptName, strDateStart, strDateEnd)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._strRptName = "Need Part(s)" Then
                        objTMIRpt = New PSS.Data.Buisness.TMIReports()
                        i = objTMIRpt.CreateNeedParts(PSS.Data.Buisness.TMI.LOCID, Me._strRptName, Me.dtpStartDate.Value.ToString("yyyy-MM-dd"), Me.dtpEndDate.Value.ToString("yyyy-MM-dd"))
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._strRptName = "WIP" Then
                        objTMIRpt = New PSS.Data.Buisness.TMIReports()
                        i = objTMIRpt.CreateWIPRpt(_iMenuCust, Me._strRptName)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._strRptName = "Completed Units Shipped" Then
                        objTMIRpt = New PSS.Data.Buisness.TMIReports()
                        i = objTMIRpt.CreateCompletedUnitsShippedRpt(_iMenuCust, Me._strRptName, strDateStart, strDateEnd)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._strRptName = "Invoice" Then
                        objTMIRpt = New PSS.Data.Buisness.TMIReports()
                        i = objTMIRpt.CreateInvoiceRpt(_iMenuCust, Me._strRptName, strDateStart, strDateEnd)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._strRptName = "Days After Box Shipped" Then
                        objTMIRpt = New PSS.Data.Buisness.TMIReports()
                        i = objTMIRpt.CreateBoxDaysAfterShippedRpt(_iMenuCust, Me._strRptName)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ElseIf Me._strRptName = "Charges for 30-Day Non Return" Then
                        objTMIRpt = New PSS.Data.Buisness.TMIReports()
                        i = objTMIRpt.Create30DayNonReturnChargeRpt(_iMenuCust, Me._strRptName, strDateStart, strDateEnd)
                        If i = 0 Then MessageBox.Show("No data for " & _strRptName & " Report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("The " & Me._strRptName & " report is not found. Please contact IT Dept.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                objTMIRpt = Nothing
                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '***********************************************************************************************

 
    End Class
End Namespace