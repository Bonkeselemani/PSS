
Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Warehouse
    Public Class frmPrintUPCLabel
        Inherits System.Windows.Forms.Form

        Private _booPopulateData As Boolean = False

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
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents txtLabelQty As System.Windows.Forms.TextBox
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtItemNo As System.Windows.Forms.TextBox
        Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtUPCCode As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtLabelQty = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.txtItemNo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtItemDesc = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtUPCCode = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'txtLabelQty
            '
            Me.txtLabelQty.Location = New System.Drawing.Point(160, 144)
            Me.txtLabelQty.Name = "txtLabelQty"
            Me.txtLabelQty.Size = New System.Drawing.Size(112, 20)
            Me.txtLabelQty.TabIndex = 4
            Me.txtLabelQty.Text = ""
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(72, 144)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 21)
            Me.Label7.TabIndex = 128
            Me.Label7.Text = "Label Qty :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnPrint
            '
            Me.btnPrint.BackColor = System.Drawing.Color.Green
            Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrint.ForeColor = System.Drawing.Color.White
            Me.btnPrint.Location = New System.Drawing.Point(160, 192)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnPrint.Size = New System.Drawing.Size(112, 30)
            Me.btnPrint.TabIndex = 5
            Me.btnPrint.Text = "PRINT"
            '
            'txtItemNo
            '
            Me.txtItemNo.Location = New System.Drawing.Point(160, 16)
            Me.txtItemNo.Name = "txtItemNo"
            Me.txtItemNo.Size = New System.Drawing.Size(264, 20)
            Me.txtItemNo.TabIndex = 1
            Me.txtItemNo.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(72, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(88, 21)
            Me.Label1.TabIndex = 130
            Me.Label1.Text = "Item# :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtItemDesc
            '
            Me.txtItemDesc.Location = New System.Drawing.Point(160, 56)
            Me.txtItemDesc.Name = "txtItemDesc"
            Me.txtItemDesc.Size = New System.Drawing.Size(264, 20)
            Me.txtItemDesc.TabIndex = 2
            Me.txtItemDesc.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(24, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(136, 21)
            Me.Label2.TabIndex = 132
            Me.Label2.Text = "Item Description :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtUPCCode
            '
            Me.txtUPCCode.Location = New System.Drawing.Point(160, 96)
            Me.txtUPCCode.Name = "txtUPCCode"
            Me.txtUPCCode.Size = New System.Drawing.Size(264, 20)
            Me.txtUPCCode.TabIndex = 3
            Me.txtUPCCode.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(72, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 21)
            Me.Label3.TabIndex = 134
            Me.Label3.Text = "UPC Code :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmPrintUPCLabel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(456, 333)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtUPCCode, Me.Label3, Me.txtItemDesc, Me.Label2, Me.txtItemNo, Me.Label1, Me.btnPrint, Me.txtLabelQty, Me.Label7})
            Me.Name = "frmPrintUPCLabel"
            Me.Text = "frmPrintUPCLabel"
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************
        Private Sub frmPrintUPCLabel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                ''Populate product type
                '_booPopulateData = True
                'dt = Generic.GetModels(True, , , True)
                'Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
                'Me.cboModels.SelectedValue = 0
                '_booPopulateData = False

                PSS.Core.Highlight.SetHighLight(Me)

                Me.txtItemDesc.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmDockShipping_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        ''*************************************************************************
        'Private Sub cboModels_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Dim dt As DataTable

        '    Try
        '        Me.cboCustomers.DataSource = Nothing
        '        If _booPopulateData = True Then Exit Sub

        '        If Me.cboModels.SelectedValue > 0 Then
        '            'Populate customers
        '            _booPopulateData = True
        '            dt = Generic.GetCustomers(True, Me.cboModels.DataSource.Table.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("Prod_ID"))
        '            Misc.PopulateC1DropDownList(Me.cboModels, dt, "Cust_Name1", "Cust_ID")
        '            Me.cboModels.SelectedValue = 0
        '            _booPopulateData = False
        '        End If

        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "cboModels_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Finally
        '        Generic.DisposeDT(dt)
        '    End Try
        'End Sub

        '*************************************************************************
        Private Sub txtLabelQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLabelQty.KeyPress
            Try
                If e.KeyChar.IsDigit(e.KeyChar) = False And e.KeyChar.IsControl(e.KeyChar) = False Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtMaxBoxQty_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************
        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Dim objWH As PSS.Data.Buisness.Warehouse

            Try
                'If Me.cboModels.SelectedValue = 0 Then
                '    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Me.cboModels.SelectAll()
                '    Me.cboModels.Focus()
                'ElseIf Me.cboCustomers.SelectedValue = 0 Then
                '    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '    Me.cboCustomers.SelectAll()
                '    Me.cboCustomers.Focus()
                If Me.txtItemNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter item #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtItemNo.SelectAll()
                    Me.txtItemNo.Focus()
                ElseIf Me.txtItemDesc.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter item description.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtItemDesc.SelectAll()
                    Me.txtItemDesc.Focus()
                ElseIf Me.txtUPCCode.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter UPC code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtUPCCode.SelectAll()
                    Me.txtUPCCode.Focus()
                ElseIf Me.txtLabelQty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtLabelQty.SelectAll()
                    Me.txtLabelQty.Focus()
                ElseIf CInt(Me.txtLabelQty.Text) <= 0 Then
                    MessageBox.Show("Please enter quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtLabelQty.SelectAll()
                    Me.txtLabelQty.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    objWH = New PSS.Data.Buisness.Warehouse()
                    'objWH.PrintUPCLabel(Me.cboModels.SelectedValue, Me.cboCustomers.SelectedValue, CInt(Me.txtLabelQty.Text))
                    objWH.PrintUPCLabel(Me.txtItemNo.Text.Trim, Me.txtItemDesc.Text.Trim, Me.txtUPCCode.Text.Trim.ToUpper, CInt(Me.txtLabelQty.Text))
                    Me.txtItemNo.Text = ""
                    Me.txtItemDesc.Text = ""
                    Me.txtUPCCode.Text = ""
                    Me.txtLabelQty.Text = ""
                    Me.txtItemNo.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                objWH = Nothing
            End Try
        End Sub

        '*************************************************************************

    End Class
End Namespace