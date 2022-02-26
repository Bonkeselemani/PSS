Option Explicit On 

Public Class frmCustModPSSModMap
    Inherits System.Windows.Forms.Form

    Private GiProd_id As Integer = 0
    Private GiCust_id As Integer = 0
    Private GiCustModPssModMap_ID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New(Optional ByVal iProd_id As Integer = 0, _
                   Optional ByVal iCust_id As Integer = 0)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        If iProd_id <> 0 Then
            GiProd_id = iProd_id
        End If
        If iCust_id <> 0 Then
            GiCust_id = iCust_id
        End If

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents txtCustMod As System.Windows.Forms.TextBox
    Friend WithEvents cmbPSSMod As PSS.Gui.Controls.ComboBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents CheckInactiveFlg As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustMod = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbPSSMod = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.CheckInactiveFlg = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(32, 56)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(196, 21)
        Me.cmbCustomer.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(32, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCustMod
        '
        Me.txtCustMod.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtCustMod.Location = New System.Drawing.Point(32, 96)
        Me.txtCustMod.Name = "txtCustMod"
        Me.txtCustMod.Size = New System.Drawing.Size(192, 21)
        Me.txtCustMod.TabIndex = 2
        Me.txtCustMod.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(32, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Customer Model:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPSSMod
        '
        Me.cmbPSSMod.AutoComplete = True
        Me.cmbPSSMod.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPSSMod.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPSSMod.ForeColor = System.Drawing.Color.Black
        Me.cmbPSSMod.Location = New System.Drawing.Point(32, 138)
        Me.cmbPSSMod.Name = "cmbPSSMod"
        Me.cmbPSSMod.Size = New System.Drawing.Size(196, 21)
        Me.cmbPSSMod.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(32, 122)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "PSS Model:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdSave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.Color.Blue
        Me.cmdSave.Location = New System.Drawing.Point(32, 203)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(96, 32)
        Me.cmdSave.TabIndex = 4
        Me.cmdSave.Text = "SAVE"
        Me.cmdSave.Visible = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.Black
        Me.cmdExit.Location = New System.Drawing.Point(224, 224)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(48, 24)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        '
        'CheckInactiveFlg
        '
        Me.CheckInactiveFlg.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.CheckInactiveFlg.ForeColor = System.Drawing.Color.White
        Me.CheckInactiveFlg.Location = New System.Drawing.Point(32, 165)
        Me.CheckInactiveFlg.Name = "CheckInactiveFlg"
        Me.CheckInactiveFlg.Size = New System.Drawing.Size(136, 24)
        Me.CheckInactiveFlg.TabIndex = 24
        Me.CheckInactiveFlg.Text = "Inactive Model"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(280, 39)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Map Customer Model to PSS Model"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCustModPSSModMap
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(280, 253)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.CheckInactiveFlg, Me.cmdExit, Me.cmdSave, Me.cmbPSSMod, Me.Label3, Me.Label2, Me.txtCustMod, Me.cmbCustomer, Me.Label1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCustModPSSModMap"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Map Customer Model to PSS Model"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    '*******************************************************************************
    Private Sub frmCustModPSSModMap_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim dtCust As DataTable
        Dim dtMod As DataTable

        Try
            dtCust = objMisc.GetCustomers(Me.GiProd_id)
            dtMod = objMisc.GetModels(Me.GiProd_id)

            With Me.cmbCustomer
                .DataSource = dtCust.DefaultView
                .DisplayMember = dtCust.Columns("cust_name1").ToString
                .ValueMember = dtCust.Columns("Cust_ID").ToString
                .SelectedValue = Me.GiCust_id
            End With
            With Me.cmbPSSMod
                .DataSource = dtMod.DefaultView
                .DisplayMember = dtMod.Columns("model_desc").ToString
                .ValueMember = dtMod.Columns("Model_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            If Not IsNothing(dtCust) Then
                dtCust.Dispose()
                dtCust = Nothing
            End If
            If Not IsNothing(dtMod) Then
                dtMod.Dispose()
                dtMod = Nothing
            End If
        End Try
    End Sub

    Private Sub txtCustMod_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustMod.KeyUp
        If e.KeyValue = 13 Then
            CustomerModelEvent()
        End If
    End Sub
    Private Sub txtCustMod_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustMod.Leave
        CustomerModelEvent()
    End Sub

    Private Sub CustomerModelEvent()
        Dim objMessAdmin As New PSS.Data.Buisness.MessAdmin()
        Dim dt1 As DataTable

        Try
            If Trim(Me.txtCustMod.Text) = "" Then
                Exit Sub
            End If
            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Get Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCustomer.Focus()
                Exit Sub
            End If

            dt1 = objMessAdmin.GetCustModPssModMap(Me.cmbCustomer.SelectedValue, UCase(Trim(Me.txtCustMod.Text)))
            If dt1.Rows.Count > 0 Then
                Me.GiCustModPssModMap_ID = dt1.Rows(0)("cm_id")
                Me.cmbPSSMod.SelectedValue = dt1.Rows(0)("model_id")
                If (dt1.Rows(0)("cm_inactive") = 1) Then
                    Me.CheckInactiveFlg.Checked = True
                Else
                    Me.CheckInactiveFlg.Checked = False
                End If
                Me.cmdSave.Visible = True
                Me.cmdSave.Text = "UPDATE"
            Else
                Me.cmdSave.Text = "INSERT"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Customer Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMessAdmin = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    Private Sub cmbPSSMod_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPSSMod.SelectionChangeCommitted
        Try
            If Me.cmbPSSMod.SelectedValue > 0 Then
                If Trim(Me.txtCustMod.Text) = "" Then
                    MessageBox.Show("Please enter 'Customer Model'.", "Get Customer Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtCustMod.Focus()
                    Exit Sub
                End If
                Me.cmdSave.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select PSS Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Dim iInactiveFlg As Integer = 0
        Dim i As Integer = 0
        Dim objMessAdmin As New PSS.Data.Buisness.MessAdmin()

        Try
            If Me.CheckInactiveFlg.Checked = True Then
                iInactiveFlg = 1
            Else
                iInactiveFlg = 0
            End If

            i = objMessAdmin.SaveCustModPssModMap(Me.cmbCustomer.SelectedValue, _
                                                  UCase(Trim(Me.txtCustMod.Text)), _
                                                  Me.cmbPSSMod.SelectedValue, _
                                                  iInactiveFlg, _
                                                  Me.GiCustModPssModMap_ID)
            If i > 0 Then
                MessageBox.Show(Me.cmdSave.Text & " completed.", "Save Mapping Data", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            Me.txtCustMod.Text = ""
            Me.cmbPSSMod.SelectedValue = 0
            Me.CheckInactiveFlg.Checked = False
            Me.cmdSave.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Save Mapping Data", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMessAdmin = Nothing
        End Try
    End Sub

    Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted
        Me.txtCustMod.Text = ""
        Me.cmbPSSMod.SelectedValue = 0

        If Me.cmbCustomer.SelectedValue > 0 Then
            Me.txtCustMod.Focus()
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        GC.Collect()
        GC.WaitForPendingFinalizers()
    End Sub
End Class
