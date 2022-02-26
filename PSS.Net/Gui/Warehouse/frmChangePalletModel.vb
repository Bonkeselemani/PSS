Public Class frmChangePalletModel
    Inherits System.Windows.Forms.Form

    Private objWarehouse As PSS.Data.Buisness.Warehouse
    Private iCust_id As Integer = 0
    Private dtWHPalletInfo As DataTable

    Private Shared HighLightColor As Color = Color.Yellow
    Private Shared WindowColor As Color = Color.White
    Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
    Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iValue As Integer)
        MyBase.New()

        Me.iCust_id = iValue

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.objWarehouse = New PSS.Data.Buisness.Warehouse()
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtPallet As System.Windows.Forms.TextBox
    Friend WithEvents cmdChangeModel As System.Windows.Forms.Button
    Friend WithEvents cmbNewModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblPalletModel As System.Windows.Forms.Label
    Friend WithEvents cmdGo As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbNewModel = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdChangeModel = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.txtPallet = New System.Windows.Forms.TextBox()
        Me.lblPalletModel = New System.Windows.Forms.Label()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Pallet Number:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNewModel
        '
        Me.cmbNewModel.AutoComplete = True
        Me.cmbNewModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbNewModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNewModel.ForeColor = System.Drawing.Color.Black
        Me.cmbNewModel.Location = New System.Drawing.Point(8, 96)
        Me.cmbNewModel.Name = "cmbNewModel"
        Me.cmbNewModel.Size = New System.Drawing.Size(160, 21)
        Me.cmbNewModel.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 87
        Me.Label1.Text = "New Model:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdChangeModel
        '
        Me.cmdChangeModel.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdChangeModel.Enabled = False
        Me.cmdChangeModel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeModel.ForeColor = System.Drawing.Color.White
        Me.cmdChangeModel.Location = New System.Drawing.Point(24, 136)
        Me.cmdChangeModel.Name = "cmdChangeModel"
        Me.cmdChangeModel.Size = New System.Drawing.Size(112, 24)
        Me.cmdChangeModel.TabIndex = 4
        Me.cmdChangeModel.Text = "CHANGE"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.Color.White
        Me.cmdExit.Location = New System.Drawing.Point(199, 181)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(64, 24)
        Me.cmdExit.TabIndex = 5
        Me.cmdExit.Text = "Exit"
        '
        'txtPallet
        '
        Me.txtPallet.Location = New System.Drawing.Point(8, 24)
        Me.txtPallet.Name = "txtPallet"
        Me.txtPallet.Size = New System.Drawing.Size(160, 20)
        Me.txtPallet.TabIndex = 1
        Me.txtPallet.Text = ""
        '
        'lblPalletModel
        '
        Me.lblPalletModel.BackColor = System.Drawing.Color.Transparent
        Me.lblPalletModel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletModel.ForeColor = System.Drawing.Color.Blue
        Me.lblPalletModel.Location = New System.Drawing.Point(8, 55)
        Me.lblPalletModel.Name = "lblPalletModel"
        Me.lblPalletModel.Size = New System.Drawing.Size(240, 16)
        Me.lblPalletModel.TabIndex = 91
        Me.lblPalletModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdGo
        '
        Me.cmdGo.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdGo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGo.ForeColor = System.Drawing.Color.White
        Me.cmdGo.Location = New System.Drawing.Point(176, 22)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.Size = New System.Drawing.Size(40, 24)
        Me.cmdGo.TabIndex = 2
        Me.cmdGo.Text = "Go"
        '
        'frmChangePalletModel
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(264, 205)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdGo, Me.lblPalletModel, Me.txtPallet, Me.cmdExit, Me.cmdChangeModel, Me.cmbNewModel, Me.Label1, Me.Label5})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangePalletModel"
        Me.Text = "Change Pallet Model"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Shared Sub SetHandler(ByVal ctl As Control)
        AddHandler ctl.Enter, EnterHandler
        AddHandler ctl.Leave, LeaveHandler
        AddHandler ctl.Click, EnterHandler
    End Sub

    '******************************************************************************
    Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, HighLightColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
        Change_Color(sender, WindowColor)
    End Sub

    '******************************************************************************
    Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
        Dim Type As String = sender.GetType.Name.ToString

        Select Case Type
            Case "ComboBox"
                CType(sender, ComboBox).BackColor = color
            Case "TextBox"
                CType(sender, TextBox).BackColor = color
            Case Else
                'no other types should be hightlighted.
        End Select
    End Sub

    '**********************************************************************
    Private Sub frmChangePalletModel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            'Handlers to highlight in custom colors
            SetHandler(Me.txtPallet)
            SetHandler(Me.cmbNewModel)

            LoadModels()
            Me.txtPallet.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**********************************************************************
    Private Sub LoadModels()
        Dim dtModels As New DataTable()
        Dim objMisc As New PSS.Data.Buisness.Misc()

        Try
            dtModels = objMisc.GetModels()
            With Me.cmbNewModel
                .DataSource = dtModels.DefaultView
                .DisplayMember = dtModels.Columns("Model_Desc").ToString
                .ValueMember = dtModels.Columns("Model_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dtModels) Then
                dtModels.Dispose()
                dtModels = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    Private Sub cmbNewModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNewModel.SelectionChangeCommitted
        Try
            If Me.cmbNewModel.SelectedValue > 0 Then
                If Trim(Me.txtPallet.Text) = "" Then
                    MessageBox.Show("Please enter Pallet Number.", "Select Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtPallet.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtPallet_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPallet.TextChanged
        Try
            If Trim(Me.txtPallet.Text) <> "" Then
                Me.cmdChangeModel.Enabled = True
            Else
                Me.cmdChangeModel.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtPallet_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPallet.Leave
        Try
            If Trim(Me.txtPallet.Text) = "" Then
                Exit Sub
            End If

            ProcessPallet()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtPallet_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPallet.KeyUp

        Try
            If Trim(Me.txtPallet.Text) = "" Then
                Exit Sub
            End If

            If e.KeyValue = 13 Then
                ProcessPallet()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cmdGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGo.Click
        Try
            If Trim(Me.txtPallet.Text) = "" Then
                Exit Sub
            End If

            ProcessPallet()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ProcessPallet()
        Try
            If Trim(Me.txtPallet.Text) = "" Then
                Exit Sub
            End If

            If Me.iCust_id = 0 Then
                MessageBox.Show("Customer ID is not defined.", "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.Close()
            End If

            If Not IsNothing(Me.dtWHPalletInfo) Then
                Me.dtWHPalletInfo.Dispose()
                Me.dtWHPalletInfo = Nothing
            End If

            'Get warehousepallet information
            Me.dtWHPalletInfo = Me.objWarehouse.GetWHPalletInfo(Me.iCust_id, _
                                                  Trim(Me.txtPallet.Text))
            If dtWHPalletInfo.Rows.Count = 0 Then
                MessageBox.Show("Pallet Number does not exist.", "Get Pallet Info", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.lblPalletModel.Text = ""
                Me.txtPallet.SelectAll()
                Exit Sub
            Else
                Me.lblPalletModel.Text = "Pallet Model: " & dtWHPalletInfo.Rows(0)("Model_Desc")
                Me.cmbNewModel.Focus()
            End If
        Catch ex As Exception
            Me.lblPalletModel.Text = ""
            Me.cmbNewModel.SelectedValue = 0
            Me.txtPallet.SelectAll()
            Me.txtPallet.Focus()

            Throw ex
        End Try
    End Sub

    Private Sub cmdChangeModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeModel.Click
        Dim i As Integer = 0

        Try
            If IsNothing(Me.dtWHPalletInfo) Then
                Me.txtPallet.Focus()
                Exit Sub
            End If

            If Me.cmbNewModel.SelectedValue = 0 Then
                MessageBox.Show("Please select New Model for the Pallet.", "Change Pallet Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cmbNewModel.Focus()
                Exit Sub
            End If

            If Me.dtWHPalletInfo.Rows.Count = 0 Then
                MessageBox.Show("There is no information for the pallet.", "Change Pallet Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cmbNewModel.SelectedValue = 0
                Me.txtPallet.SelectAll()
                Me.txtPallet.Focus()
                Exit Sub
            Else
                'update model in twarehousepallet
                i = Me.objWarehouse.ChangePalletModel(Me.iCust_id, _
                                                    Me.cmbNewModel.SelectedValue, _
                                                    Trim(Me.txtPallet.Text), _
                                                    Me.dtWHPalletInfo)

                'confirm message
                If i > 0 Then
                    MessageBox.Show("Model is changed.", "Change Model", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Change Pallet Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Me.Close()
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Me.objWarehouse = Nothing
        If Not IsNothing(dtWHPalletInfo) Then
            dtWHPalletInfo.Dispose()
            dtWHPalletInfo = Nothing
        End If
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.txtPallet.Text = ""
        Me.Close()
    End Sub


End Class
