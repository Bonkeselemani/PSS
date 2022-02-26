Namespace Gui.ReportViewer
    Public Class frmExcelRpt
        Inherits System.Windows.Forms.Form

        Private objMisc As PSS.Data.Buisness.Misc


#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMisc = New PSS.Data.Buisness.Misc()

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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents lblCustomer1 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboPartNum As PSS.Gui.Controls.ComboBox
        Friend WithEvents cmdGenlRpt As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cboPartNum = New PSS.Gui.Controls.ComboBox()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cmdGenlRpt = New System.Windows.Forms.Button()
            Me.lblCustomer1 = New System.Windows.Forms.Label()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboPartNum
            '
            Me.cboPartNum.AutoComplete = True
            Me.cboPartNum.BackColor = System.Drawing.SystemColors.Window
            Me.cboPartNum.Font = New System.Drawing.Font("Verdana", 8.25!)
            Me.cboPartNum.ForeColor = System.Drawing.Color.Black
            Me.cboPartNum.Location = New System.Drawing.Point(128, 33)
            Me.cboPartNum.Name = "cboPartNum"
            Me.cboPartNum.Size = New System.Drawing.Size(136, 21)
            Me.cboPartNum.TabIndex = 2
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.dtpToDate, Me.dtpFromDate, Me.Label4, Me.cmdGenlRpt, Me.lblCustomer1, Me.cboPartNum})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
            Me.GroupBox1.ForeColor = System.Drawing.Color.Black
            Me.GroupBox1.Location = New System.Drawing.Point(16, 18)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(536, 160)
            Me.GroupBox1.TabIndex = 3
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Part Consumption Report"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(280, 72)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(96, 16)
            Me.Label5.TabIndex = 71
            Me.Label5.Text = "Work Date to: "
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpToDate
            '
            Me.dtpToDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpToDate.Location = New System.Drawing.Point(384, 72)
            Me.dtpToDate.Name = "dtpToDate"
            Me.dtpToDate.Size = New System.Drawing.Size(136, 21)
            Me.dtpToDate.TabIndex = 70
            Me.dtpToDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
            '
            'dtpFromDate
            '
            Me.dtpFromDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFromDate.Location = New System.Drawing.Point(128, 72)
            Me.dtpFromDate.Name = "dtpFromDate"
            Me.dtpFromDate.Size = New System.Drawing.Size(136, 21)
            Me.dtpFromDate.TabIndex = 68
            Me.dtpFromDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label4.Location = New System.Drawing.Point(8, 72)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 16)
            Me.Label4.TabIndex = 69
            Me.Label4.Text = "Work Date From:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdGenlRpt
            '
            Me.cmdGenlRpt.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdGenlRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdGenlRpt.ForeColor = System.Drawing.Color.White
            Me.cmdGenlRpt.Location = New System.Drawing.Point(160, 112)
            Me.cmdGenlRpt.Name = "cmdGenlRpt"
            Me.cmdGenlRpt.Size = New System.Drawing.Size(200, 31)
            Me.cmdGenlRpt.TabIndex = 67
            Me.cmdGenlRpt.Text = "Generate Report"
            '
            'lblCustomer1
            '
            Me.lblCustomer1.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
            Me.lblCustomer1.ForeColor = System.Drawing.Color.Black
            Me.lblCustomer1.Location = New System.Drawing.Point(24, 35)
            Me.lblCustomer1.Name = "lblCustomer1"
            Me.lblCustomer1.Size = New System.Drawing.Size(104, 16)
            Me.lblCustomer1.TabIndex = 14
            Me.lblCustomer1.Text = "Part Number:"
            Me.lblCustomer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmExcelRpt
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(616, 501)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1})
            Me.Name = "frmExcelRpt"
            Me.Text = "frmExcelRpt"
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************
        Protected Overrides Sub Finalize()
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '*********************************************************
        Private Sub LoadPartNumber()
            Dim dt As DataTable
            Dim objCSBER As PSS.Data.Buisness.CellStarBER
            objCSBER = New PSS.Data.Buisness.CellStarBER()

            Try
                dt = objCSBER.GetSelectedDt("select *  from lpsprice")
                dt.LoadDataRow(New Object() {"0", "-- select --"}, False)
                Me.cboPartNum.DataSource = dt.DefaultView
                Me.cboPartNum.DisplayMember = dt.Columns("PSPrice_Number").ToString
                Me.cboPartNum.ValueMember = dt.Columns("PSPrice_ID").ToString
                Me.cboPartNum.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Load Part Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
                objCSBER = Nothing
            End Try
        End Sub
        '*********************************************************
        Private Sub frmExcelRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            LoadPartNumber()
        End Sub
        '*********************************************************
        'Private Sub cmdGenlRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGenlRpt.Click
        '    Dim i As Integer = 0

        '    Cursor.Current = Cursors.WaitCursor

        '    If Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
        '        MsgBox("Please select 'Work Date From' and 'Work Date to'.", MsgBoxStyle.Information, "Part Consumption Report")
        '        Exit Sub
        '    End If

        '    If Me.dtpToDate.Value < Me.dtpFromDate.Value Then
        '        MsgBox("'Work Date to' can't be before 'Work Date From'.", MsgBoxStyle.Information, "Part Consumption Report")
        '        Exit Sub
        '    End If

        '    Try
        '        Me.cmdGenlRpt.Enabled = False

        '        ' Generate Part Consumption Rpt
        '        i = objMisc.GeneratePartConsumptionRpt(Me.dtpFromDate.Text, Me.dtpToDate.Text, Me.cboPartNum.SelectedValue)
        '        If i = 0 Then
        '            Throw New Exception("Check the report for errors (i = 0).")
        '        End If
        '    Catch ex As Exception
        '        MsgBox("frmExcelRpt.cmdGenlRpt_Click:: " & ex.Message)
        '    Finally
        '        Cursor.Current = Cursors.Default
        '        Me.cmdGenlRpt.Enabled = True
        '    End Try
        'End Sub
        '*********************************************************
    End Class
End Namespace