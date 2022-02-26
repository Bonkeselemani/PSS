Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmMobilio_Reports
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _objMRpt As Mobilio_Reports
        Private _objMobilio As Mobilio
        Private _strRptName As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _objMRpt = New Mobilio_Reports()
            _objMobilio = New Mobilio()
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
        Friend WithEvents gbReportName As System.Windows.Forms.GroupBox
        Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
        Friend WithEvents btnRunRpt As System.Windows.Forms.Button
        Friend WithEvents gbDate As System.Windows.Forms.GroupBox
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.gbReportName = New System.Windows.Forms.GroupBox()
            Me.cboReportName = New System.Windows.Forms.ComboBox()
            Me.btnRunRpt = New System.Windows.Forms.Button()
            Me.gbDate = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.gbReportName.SuspendLayout()
            Me.gbDate.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Arial Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(312, 32)
            Me.lblTitle.TabIndex = 10
            Me.lblTitle.Tag = ""
            '
            'gbReportName
            '
            Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReportName})
            Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbReportName.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbReportName.Location = New System.Drawing.Point(32, 56)
            Me.gbReportName.Name = "gbReportName"
            Me.gbReportName.Size = New System.Drawing.Size(400, 48)
            Me.gbReportName.TabIndex = 6
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
            Me.cboReportName.TabIndex = 0
            '
            'btnRunRpt
            '
            Me.btnRunRpt.BackColor = System.Drawing.Color.CadetBlue
            Me.btnRunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRunRpt.ForeColor = System.Drawing.Color.White
            Me.btnRunRpt.Location = New System.Drawing.Point(32, 256)
            Me.btnRunRpt.Name = "btnRunRpt"
            Me.btnRunRpt.Size = New System.Drawing.Size(400, 48)
            Me.btnRunRpt.TabIndex = 9
            '
            'gbDate
            '
            Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
            Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDate.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbDate.Location = New System.Drawing.Point(32, 128)
            Me.gbDate.Name = "gbDate"
            Me.gbDate.Size = New System.Drawing.Size(400, 80)
            Me.gbDate.TabIndex = 8
            Me.gbDate.TabStop = False
            Me.gbDate.Text = "DATE"
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndDate.ForeColor = System.Drawing.Color.White
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
            Me.lblStartDate.ForeColor = System.Drawing.Color.White
            Me.lblStartDate.Location = New System.Drawing.Point(24, 16)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
            Me.lblStartDate.TabIndex = 103
            Me.lblStartDate.Text = "Start:"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmMobilio_Reports
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(888, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitle, Me.gbReportName, Me.btnRunRpt, Me.gbDate})
            Me.Name = "frmMobilio_Reports"
            Me.Text = "frmMobilio_Reports"
            Me.gbReportName.ResumeLayout(False)
            Me.gbDate.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '***********************************************************************************************************************************
        Private Sub frmMobilio_Reports_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.cboReportName.Items.Clear()
                Me.cboReportName.Items.Add("Select Report Name")

                Select Case Me._iMenuCustID
                    Case Me._objMobilio.CUSTOMERID
                        Me.cboReportName.Items.Add("WIP Report")
                        Me.cboReportName.Items.Add("Finished Goods Report")
                        Me.cboReportName.Items.Add("Open Order Report")
                        Me.cboReportName.Items.Add("Shipping Report")
                End Select
                Me.cboReportName.SelectedIndex = 0

                Me.gbDate.Visible = False
                Me.btnRunRpt.Visible = False
                Me.dtpStartDate.Value = Now()
                Me.dtpEndDate.Value = Now()

            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmMobilio_Reports_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '***********************************************************************************************************************************
        Private Sub cboReportName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboReportName.TextChanged
            Dim dt As DataTable

            Try
                Me.gbDate.Visible = False : Me.btnRunRpt.Visible = False : Me.btnRunRpt.Text = ""

                If Me.cboReportName.Text <> "Select Report Name" Then
                    Me._strRptName = Me.cboReportName.Text

                    Select Case Me._iMenuCustID
                        Case Me._objMobilio.CUSTOMERID
                            If Me._strRptName = "WIP Report" Then
                                Me.gbDate.Visible = False
                            ElseIf Me._strRptName = "Finished Goods Report" Then
                                Me.gbDate.Visible = True
                            ElseIf Me._strRptName = "Open Order Report" Then
                                Me.gbDate.Visible = False
                            ElseIf Me._strRptName = "Shipping Report" Then
                                Me.gbDate.Visible = True
                            End If
                    End Select

                    Me.btnRunRpt.Text = "Get """ & Me._strRptName & """" : Me.btnRunRpt.Visible = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboReportName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub


        '***********************************************************************************************
        Private Sub btnRunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunRpt.Click
        
            Dim strDateStart, strDateEnd As String
            Dim i As Integer = 0
            Dim dt As DataTable

            Try
                If Me.gbDate.Visible = True AndAlso DateDiff(DateInterval.Day, Me.dtpStartDate.Value, Me.dtpEndDate.Value) < 0 Then
                    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.dtpStartDate.Value > Me.dtpEndDate.Value Then
                    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    strDateStart = "" : strDateEnd = ""

                    If Me.gbDate.Visible = True Then
                        strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                        strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                    End If

                    '*************************************
                    'Generate Report
                    '*************************************

                    Select Case Me._iMenuCustID
                        Case Me._objMobilio.CUSTOMERID
                            If Me._strRptName = "WIP Report" Then
                                dt = Me._objMRpt.GetWIPData(Me._iMenuCustID)
                                If dt.Rows.Count > 0 Then
                                    i = Me._objMRpt.Create_ExcelRpt(dt, Me._strRptName & "_" & Format(Now(), "yyyyMMdd"))
                                Else
                                    MessageBox.Show("No data for " & Me._strRptName & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            ElseIf Me._strRptName = "Finished Goods Report" Then
                                dt = Me._objMRpt.GetFinishedGoodsData(Me._iMenuCustID, strDateStart & " 00:00:00", strDateEnd & " 23:59:59")
                                If dt.Rows.Count > 0 Then
                                    i = Me._objMRpt.Create_ExcelRpt(dt, Me._strRptName & "_" & strDateStart.Replace("-", "") & "-" & strDateEnd.Replace("-", ""))
                                Else
                                    MessageBox.Show("No data for " & Me._strRptName & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            ElseIf Me._strRptName = "Open Order Report" Then
                                dt = Me._objMRpt.GetOpenOrderData(Me._iMenuCustID)
                                If dt.Rows.Count > 0 Then
                                    i = Me._objMRpt.Create_ExcelRpt(dt, Me._strRptName & "_" & Format(Now(), "yyyyMMdd"))
                                Else
                                    MessageBox.Show("No data for " & Me._strRptName & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            ElseIf Me._strRptName = "Shipping Report" Then
                                dt = Me._objMRpt.GetShippingData(Me._iMenuCustID, strDateStart & " 00:00:00", strDateEnd & " 23:59:59")
                                If dt.Rows.Count > 0 Then
                                    i = Me._objMRpt.Create_ExcelRpt(dt, Me._strRptName & "_" & strDateStart.Replace("-", "") & "-" & strDateEnd.Replace("-", ""))
                                Else
                                    MessageBox.Show("No data for " & Me._strRptName & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End If
                            Else
                                MessageBox.Show("The " & Me._strRptName & " report is not found. Please contact IT Dept.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If

                    End Select

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                dt = Nothing
                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '***********************************************************************************************************************************



        '***********************************************************************************************************************************

    End Class
End Namespace