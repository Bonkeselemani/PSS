Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.WIP
    Public Class frmWIPReports_1
        Inherits System.Windows.Forms.Form

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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cmdWIPCount As System.Windows.Forms.Button
        Friend WithEvents btnWIPDetail As System.Windows.Forms.Button
        Friend WithEvents cmbProd As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dtpWIPCutoffDate As System.Windows.Forms.DateTimePicker
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cmbModel = New PSS.Gui.Controls.ComboBox()
            Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cmdWIPCount = New System.Windows.Forms.Button()
            Me.btnWIPDetail = New System.Windows.Forms.Button()
            Me.cmbProd = New PSS.Gui.Controls.ComboBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.dtpWIPCutoffDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(72, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 16)
            Me.Label2.TabIndex = 93
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbModel
            '
            Me.cmbModel.AutoComplete = True
            Me.cmbModel.BackColor = System.Drawing.SystemColors.Window
            Me.cmbModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbModel.ForeColor = System.Drawing.Color.Black
            Me.cmbModel.Location = New System.Drawing.Point(144, 72)
            Me.cmbModel.Name = "cmbModel"
            Me.cmbModel.Size = New System.Drawing.Size(272, 21)
            Me.cmbModel.TabIndex = 92
            '
            'cmbCustomer
            '
            Me.cmbCustomer.AutoComplete = True
            Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
            Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
            Me.cmbCustomer.Location = New System.Drawing.Point(144, 40)
            Me.cmbCustomer.Name = "cmbCustomer"
            Me.cmbCustomer.Size = New System.Drawing.Size(272, 21)
            Me.cmbCustomer.TabIndex = 94
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(64, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 95
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdWIPCount
            '
            Me.cmdWIPCount.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdWIPCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdWIPCount.Location = New System.Drawing.Point(144, 152)
            Me.cmdWIPCount.Name = "cmdWIPCount"
            Me.cmdWIPCount.Size = New System.Drawing.Size(272, 24)
            Me.cmdWIPCount.TabIndex = 96
            Me.cmdWIPCount.Text = "WIP Summary"
            '
            'btnWIPDetail
            '
            Me.btnWIPDetail.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnWIPDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnWIPDetail.Location = New System.Drawing.Point(144, 192)
            Me.btnWIPDetail.Name = "btnWIPDetail"
            Me.btnWIPDetail.Size = New System.Drawing.Size(272, 24)
            Me.btnWIPDetail.TabIndex = 97
            Me.btnWIPDetail.Text = "WIP Detail"
            '
            'cmbProd
            '
            Me.cmbProd.AutoComplete = True
            Me.cmbProd.BackColor = System.Drawing.SystemColors.Window
            Me.cmbProd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbProd.ForeColor = System.Drawing.Color.Black
            Me.cmbProd.Location = New System.Drawing.Point(144, 8)
            Me.cmbProd.Name = "cmbProd"
            Me.cmbProd.Size = New System.Drawing.Size(272, 21)
            Me.cmbProd.TabIndex = 98
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(64, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 99
            Me.Label3.Text = "Product:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpWIPCutoffDate
            '
            Me.dtpWIPCutoffDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpWIPCutoffDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpWIPCutoffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpWIPCutoffDate.Location = New System.Drawing.Point(144, 104)
            Me.dtpWIPCutoffDate.Name = "dtpWIPCutoffDate"
            Me.dtpWIPCutoffDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpWIPCutoffDate.TabIndex = 100
            Me.dtpWIPCutoffDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(16, 104)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 16)
            Me.Label4.TabIndex = 101
            Me.Label4.Text = "WIP Cutoff Date"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmWIPReports_1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(632, 485)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.dtpWIPCutoffDate, Me.cmbProd, Me.Label3, Me.btnWIPDetail, Me.cmdWIPCount, Me.Label2, Me.cmbModel, Me.cmbCustomer, Me.Label1})
            Me.Name = "frmWIPReports_1"
            Me.Text = "Wip Report"
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**********************************************************************
        Private Sub frmWIPReports_1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'Handlers to highlight in custom colors
                PSS.Core.Highlight.SetHighLight(Me)
                LoadProd()
                Me.dtpWIPCutoffDate.Value = Now()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        '**********************************************************************
        Private Sub LoadProd()
            Try
                Generic.LoadProduct(Me.cmbProd, )
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************
        Private Sub LoadCustomers()
            Dim dtCustomers As New DataTable()
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try
                dtCustomers = objMisc.GetCustomers(Me.cmbProd.SelectedValue, "")
                With Me.cmbCustomer
                    .DataSource = dtCustomers.DefaultView
                    .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                    .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                    .SelectedValue = 0
                End With
            Catch ex As Exception
                Throw ex
            Finally
                objMisc = Nothing
                If Not IsNothing(dtCustomers) Then
                    dtCustomers.Dispose()
                    dtCustomers = Nothing
                End If
            End Try
        End Sub

        '**********************************************************************
        Private Sub LoadModels()
            Dim objGeneric As New PSS.Data.Buisness.Generic()
            Try
                objGeneric.LoadModels(cmbModel, Me.cmbProd.SelectedValue)
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objGeneric) Then
                    objGeneric = Nothing
                End If
            End Try
        End Sub

        '**********************************************************************
        Private Sub cmbProd_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProd.SelectionChangeCommitted
            Try
                Me.LoadModels()
                Me.LoadCustomers()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        '**********************************************************************
        Private Sub cmdWIPCount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWIPCount.Click
            Dim objWIP As New PSS.Data.Buisness.WIP()
            Dim i As Integer = 0
            Try
                If Me.cmbProd.SelectedValue = 0 Then
                    MsgBox("Please select product.", MsgBoxStyle.Critical, "Information")
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = objWIP.CreateWIPSummaryRpt(Me.cmbProd.SelectedValue, Me.cmbCustomer.SelectedValue, Me.cmbModel.SelectedValue, Me.dtpWIPCutoffDate.Value)
                If i = 0 Then
                    MessageBox.Show("No data to generate the report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                Cursor.Current = Cursors.Default
                Me.Enabled = True
                objWIP = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '**********************************************************************
        Private Sub btnWIPDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWIPDetail.Click
            Dim objWIP As New PSS.Data.Buisness.WIP()
            Dim dt As DataTable
            Dim objXLReports As Data.ExcelReports
            Dim objMessReports As MessReports

            Try
                If Me.cmbProd.SelectedValue = 0 Then
                    MsgBox("Please select product.", MsgBoxStyle.Critical, "Information")
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                If Me.cmbProd.SelectedValue = 1 Then
                    objMessReports = New MessReports()
                    dt = objMessReports.GetMessWIPDetailData(Me.dtpWIPCutoffDate.Value, Me.cmbCustomer.SelectedValue)
                Else
                    dt = objWIP.GetCelloptWIPDetailData(Me.cmbProd.SelectedValue, Me.cmbCustomer.SelectedValue, Me.cmbModel.SelectedValue, Me.dtpWIPCutoffDate.Value)
                End If

                If dt.Rows.Count > 0 Then
                    objXLReports = New Data.ExcelReports()

                    objXLReports.RunAmericanMsgWIPDetailReport(dt, Me.dtpWIPCutoffDate.Value)
                Else
                    MsgBox("No data found.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                Cursor.Current = Cursors.Default
                Me.Enabled = True
                objMessReports = Nothing
                objXLReports = Nothing
                objWIP = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '**********************************************************************

    End Class
End Namespace


