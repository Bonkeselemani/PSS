Public Class frmQC_Codes
    Inherits System.Windows.Forms.Form

    Private objQC As PSS.Data.Buisness.QC
    Private iDCode_ID As Integer = 0
    Private dtCodes As DataTable
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objQC = New PSS.Data.Buisness.QC()

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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboProduct As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboMCodes As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCodeDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboCodeDesc As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboCodes As PSS.Gui.Controls.ComboBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboProduct = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboMCodes = New PSS.Gui.Controls.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboCodeDesc = New PSS.Gui.Controls.ComboBox()
        Me.txtCodeDesc = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboCodes = New PSS.Gui.Controls.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkInactive = New System.Windows.Forms.CheckBox()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(80, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Code:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboProduct
        '
        Me.cboProduct.AutoComplete = True
        Me.cboProduct.BackColor = System.Drawing.SystemColors.Window
        Me.cboProduct.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProduct.ForeColor = System.Drawing.Color.Black
        Me.cboProduct.Location = New System.Drawing.Point(140, 37)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(163, 21)
        Me.cboProduct.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(31, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 79
        Me.Label3.Text = "Product:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(128, 33)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(112, 20)
        Me.txtCode.TabIndex = 1
        Me.txtCode.Text = ""
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Yellow
        Me.btnSave.Location = New System.Drawing.Point(128, 126)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 25)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save Code"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(17, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 16)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "Master Codes:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboMCodes
        '
        Me.cboMCodes.AutoComplete = True
        Me.cboMCodes.BackColor = System.Drawing.SystemColors.Window
        Me.cboMCodes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMCodes.ForeColor = System.Drawing.Color.Black
        Me.cboMCodes.Location = New System.Drawing.Point(140, 65)
        Me.cboMCodes.Name = "cboMCodes"
        Me.cboMCodes.Size = New System.Drawing.Size(235, 21)
        Me.cboMCodes.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Code Description:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCodeDesc
        '
        Me.cboCodeDesc.AutoComplete = True
        Me.cboCodeDesc.BackColor = System.Drawing.SystemColors.Window
        Me.cboCodeDesc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodeDesc.ForeColor = System.Drawing.Color.Black
        Me.cboCodeDesc.Location = New System.Drawing.Point(140, 121)
        Me.cboCodeDesc.Name = "cboCodeDesc"
        Me.cboCodeDesc.Size = New System.Drawing.Size(312, 21)
        Me.cboCodeDesc.TabIndex = 4
        '
        'txtCodeDesc
        '
        Me.txtCodeDesc.Location = New System.Drawing.Point(128, 64)
        Me.txtCodeDesc.Name = "txtCodeDesc"
        Me.txtCodeDesc.Size = New System.Drawing.Size(312, 20)
        Me.txtCodeDesc.TabIndex = 2
        Me.txtCodeDesc.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 16)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Code Description:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkInactive, Me.btnClear, Me.Label6, Me.Label5, Me.txtCodeDesc, Me.Label2, Me.txtCode, Me.btnSave})
        Me.Panel5.Location = New System.Drawing.Point(7, 173)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(609, 179)
        Me.Panel5.TabIndex = 10
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(392, 8)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(208, 24)
        Me.btnClear.TabIndex = 8
        Me.btnClear.Text = "Clear data to Add New Code"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(137, 17)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Add/Edit Codes"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCodes, Me.Label8, Me.Label7, Me.cboCodeDesc, Me.cboProduct, Me.cboMCodes, Me.Label3, Me.Label4, Me.Label1})
        Me.Panel1.Location = New System.Drawing.Point(7, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(609, 162)
        Me.Panel1.TabIndex = 9
        '
        'cboCodes
        '
        Me.cboCodes.AutoComplete = True
        Me.cboCodes.BackColor = System.Drawing.SystemColors.Window
        Me.cboCodes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodes.ForeColor = System.Drawing.Color.Black
        Me.cboCodes.Location = New System.Drawing.Point(140, 93)
        Me.cboCodes.Name = "cboCodes"
        Me.cboCodes.Size = New System.Drawing.Size(115, 21)
        Me.cboCodes.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(34, 93)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = "Code:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Red
        Me.Label7.Location = New System.Drawing.Point(2, -2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(137, 25)
        Me.Label7.TabIndex = 88
        Me.Label7.Text = "Existing Codes"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkInactive
        '
        Me.chkInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInactive.ForeColor = System.Drawing.Color.Black
        Me.chkInactive.Location = New System.Drawing.Point(36, 94)
        Me.chkInactive.Name = "chkInactive"
        Me.chkInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkInactive.TabIndex = 3
        Me.chkInactive.Text = "Inactive"
        Me.chkInactive.Visible = False
        '
        'frmQC_Codes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(632, 381)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.Panel5})
        Me.Name = "frmQC_Codes"
        Me.Text = "frmQC_Codes"
        Me.Panel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    '*********************************************************
    Protected Overrides Sub Finalize()
        objQC = Nothing
        MyBase.Finalize()
    End Sub
    '*********************************************************
    Private Sub frmQC_Codes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            LoadProductTypes()
            Me.chkInactive.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "frmQC_Codes_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadProductTypes()
        Dim dtProd As New DataTable()
        Try
            dtProd = objQC.LoadProductTypes
            With Me.cboProduct
                .DataSource = dtProd.DefaultView
                .DisplayMember = dtProd.Columns("prod_desc").ToString
                .ValueMember = dtProd.Columns("prod_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC_Codes.LoadProductTypes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtProd)
        End Try
    End Sub
    '*********************************************************
    Private Sub LoadMasterCodes()
        Dim dtCodes As New DataTable()
        Try
            dtCodes = objQC.LoadQCMasterCodes(Me.cboProduct.SelectedValue)

            With Me.cboMCodes
                .DataSource = dtCodes.DefaultView
                .DisplayMember = dtCodes.Columns("MCode_Desc").ToString
                .ValueMember = dtCodes.Columns("MCode_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC_Codes.LoadMasterCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtCodes)
        End Try
    End Sub
    '*********************************************************
    Private Sub LoadCodes()
        Try
            If Me.cboProduct.SelectedValue = 0 Or Me.cboMCodes.SelectedValue = 0 Then Exit Sub
            dtCodes = objQC.LoadCodes(Me.cboProduct.SelectedValue, Me.cboMCodes.SelectedValue)
            With Me.cboCodes
                .DataSource = dtCodes.DefaultView
                .DisplayMember = dtCodes.Columns("DCode_sDesc").ToString
                .ValueMember = dtCodes.Columns("DCode_ID").ToString
                .SelectedValue = iDCode_ID
            End With

            With Me.cboCodeDesc
                .DataSource = dtCodes.DefaultView
                .DisplayMember = dtCodes.Columns("DCode_LDesc").ToString
                .ValueMember = dtCodes.Columns("DCode_ID").ToString
                .SelectedValue = iDCode_ID
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC_Codes.LoadCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)

        End Try
    End Sub
    '*********************************************************
    Private Sub cboProduct_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.SelectionChangeCommitted
        Try
            If Me.cboProduct.SelectedValue > 0 Then
                objQC.DisposeDT(dtCodes)
                Me.txtCode.Text = ""
                Me.txtCodeDesc.Text = ""
                Me.chkInactive.Checked = False
                iDCode_ID = 0
                LoadMasterCodes()
                LoadCodes()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboProduct_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.txtCode.Text = ""
        Me.txtCodeDesc.Text = ""
        Me.cboCodes.SelectedValue = 0
        Me.cboCodeDesc.SelectedValue = 0
        iDCode_ID = 0
        Me.chkInactive.Checked = False
    End Sub

    Private Sub cboCodeDesc_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCodeDesc.SelectionChangeCommitted
        Dim I As Integer = 0
        I = Me.cboCodeDesc.SelectedIndex
        iDCode_ID = Me.cboCodeDesc.SelectedValue
        Me.cboCodes.SelectedValue = iDCode_ID
        If iDCode_ID <> 0 Then
            System.Windows.Forms.Application.DoEvents()
            Me.txtCode.Text = Me.cboCodes.Text
            Me.txtCodeDesc.Text = Me.cboCodeDesc.Text
            If CInt(Me.dtCodes.Rows(I)("DCode_Inactive").ToString()) = 1 Then
                Me.chkInactive.Checked = True
            Else
                Me.chkInactive.Checked = False
            End If
        Else
            Me.txtCode.Text = ""
            Me.txtCodeDesc.Text = ""
            Me.chkInactive.Checked = False
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim i As Integer = 0

        Try
            If Me.cboProduct.SelectedValue = 0 Then
                MessageBox.Show("Please select Product.", "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ElseIf Me.cboMCodes.SelectedValue = 0 Then
                MessageBox.Show("Please select Master Code.", "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            ElseIf Me.txtCode.Text.Trim.Length = 0 Or Me.txtCodeDesc.Text.Trim.Length = 0 Then
                MessageBox.Show("Please enter code and code description.", "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Else
                If Me.chkInactive.Checked = True Then
                    i = 1
                End If

                iDCode_ID = objQC.SaveCode(Me.cboProduct.SelectedValue, Trim(Me.txtCode.Text), Trim(Me.txtCodeDesc.Text), Me.cboMCodes.SelectedValue, iDCode_ID, i)
                MessageBox.Show("Code is created successfully.", "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtCode.Text = ""
                Me.txtCodeDesc.Text = ""
                Me.chkInactive.Checked = False
                iDCode_ID = 0
                LoadCodes()
                Me.cboCodes.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Save Codes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


    Private Sub cboCodes_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCodes.SelectionChangeCommitted
        Dim I As Integer = 0
        I = Me.cboCodes.SelectedIndex
        iDCode_ID = Me.cboCodes.SelectedValue
        Me.cboCodeDesc.SelectedValue = iDCode_ID
        If iDCode_ID <> 0 Then
            System.Windows.Forms.Application.DoEvents()
            Me.txtCode.Text = Me.cboCodes.Text
            Me.txtCodeDesc.Text = Me.cboCodeDesc.Text
            If CInt(Me.dtCodes.Rows(I)("DCode_Inactive").ToString()) = 1 Then
                Me.chkInactive.Checked = True
            Else
                Me.chkInactive.Checked = False
            End If
        Else
            Me.txtCode.Text = ""
            Me.txtCodeDesc.Text = ""
            Me.chkInactive.Checked = False
        End If
    End Sub

    Private Sub cboMCodes_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMCodes.SelectionChangeCommitted
        Try
            Me.txtCode.Text = ""
            Me.txtCodeDesc.Text = ""
            Me.chkInactive.Checked = False
            If Me.cboMCodes.SelectedValue > 0 Then
                objQC.DisposeDT(dtCodes)
                Me.LoadCodes()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboMCodes_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cboCodes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCodes.KeyUp
        Dim i As Integer = 0
        Dim J As Integer = 0
        J = Me.cboCodes.SelectedIndex
        Try
            Me.txtCode.Text = ""
            Me.txtCodeDesc.Text = ""
            Me.chkInactive.Checked = False
            If e.KeyValue = 13 Then
                For i = 0 To Me.cboCodes.Items.Count - 1
                    If Me.cboCodes.Text = Me.cboCodes.Items.Item(i)("DCode_sDesc") Then
                        Me.cboCodes.SelectedValue = Me.cboCodes.Items.Item(i)("DCode_ID")
                        Me.cboCodeDesc.SelectedValue = Me.cboCodes.Items.Item(i)("DCode_ID")
                        Me.iDCode_ID = Me.cboCodes.Items.Item(i)("DCode_ID")
                        If iDCode_ID <> 0 Then
                            System.Windows.Forms.Application.DoEvents()
                            Me.txtCode.Text = Me.cboCodes.Text
                            Me.txtCodeDesc.Text = Me.cboCodeDesc.Text
                            If CInt(Me.dtCodes.Rows(J)("DCode_Inactive").ToString()) = 1 Then
                                Me.chkInactive.Checked = True
                            Else
                                Me.chkInactive.Checked = False
                            End If

                        Else
                            Me.txtCode.Text = ""
                            Me.txtCodeDesc.Text = ""
                            Me.chkInactive.Checked = False
                        End If
                        Exit Sub
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCodes_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub


End Class
