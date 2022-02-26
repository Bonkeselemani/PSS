Public Class frmCellStarPartNumUpdate
    Inherits System.Windows.Forms.Form

    Private objCellStarBER As PSS.Data.Buisness.CellStarBER
    Private dtPartNum As DataTable
    Private iUpdtFlg As Integer = 0

    Private Shared ctl As Control
    Private Shared HighLightColor As Color = Color.Yellow
    Private Shared WindowColor As Color = Color.White
    Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
    Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objCellStarBER = New PSS.Data.Buisness.CellStarBER()

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbEnterprise As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCarrier As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPartNum As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtLaborAmt As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtBer As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBer = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtLaborAmt = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCarrier = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbEnterprise = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPartNum = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.txtBer, Me.Label5, Me.txtLaborAmt, Me.cmdCancel, Me.cmdUpdate, Me.cmbModel, Me.Label4, Me.cmbCarrier, Me.Label3, Me.cmbEnterprise, Me.Label2, Me.Label1, Me.txtPartNum})
        Me.Panel1.Location = New System.Drawing.Point(4, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(302, 228)
        Me.Panel1.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(24, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "BER Rate :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtBer
        '
        Me.txtBer.Enabled = False
        Me.txtBer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBer.Location = New System.Drawing.Point(120, 146)
        Me.txtBer.MaxLength = 10
        Me.txtBer.Name = "txtBer"
        Me.txtBer.Size = New System.Drawing.Size(160, 22)
        Me.txtBer.TabIndex = 9
        Me.txtBer.Text = ""
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Labor Amount :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLaborAmt
        '
        Me.txtLaborAmt.Enabled = False
        Me.txtLaborAmt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLaborAmt.Location = New System.Drawing.Point(120, 120)
        Me.txtLaborAmt.MaxLength = 10
        Me.txtLaborAmt.Name = "txtLaborAmt"
        Me.txtLaborAmt.Size = New System.Drawing.Size(160, 22)
        Me.txtLaborAmt.TabIndex = 7
        Me.txtLaborAmt.Text = ""
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.White
        Me.cmdCancel.Location = New System.Drawing.Point(32, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(104, 32)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "CANCEL"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.ForeColor = System.Drawing.Color.White
        Me.cmdUpdate.Location = New System.Drawing.Point(160, 184)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(104, 32)
        Me.cmdUpdate.TabIndex = 5
        Me.cmdUpdate.Text = "UPDATE"
        '
        'cmbModel
        '
        Me.cmbModel.Enabled = False
        Me.cmbModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.Location = New System.Drawing.Point(120, 92)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(160, 24)
        Me.cmbModel.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label4.Location = New System.Drawing.Point(56, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Model :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbCarrier
        '
        Me.cmbCarrier.Enabled = False
        Me.cmbCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCarrier.Location = New System.Drawing.Point(120, 66)
        Me.cmbCarrier.Name = "cmbCarrier"
        Me.cmbCarrier.Size = New System.Drawing.Size(160, 24)
        Me.cmbCarrier.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label3.Location = New System.Drawing.Point(56, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Carrier :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbEnterprise
        '
        Me.cmbEnterprise.Enabled = False
        Me.cmbEnterprise.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEnterprise.Location = New System.Drawing.Point(120, 40)
        Me.cmbEnterprise.Name = "cmbEnterprise"
        Me.cmbEnterprise.Size = New System.Drawing.Size(160, 24)
        Me.cmbEnterprise.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.TopRight
        Me.Label2.Location = New System.Drawing.Point(24, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Enterprise :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Part Number :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtPartNum
        '
        Me.txtPartNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPartNum.Location = New System.Drawing.Point(120, 8)
        Me.txtPartNum.MaxLength = 8
        Me.txtPartNum.Name = "txtPartNum"
        Me.txtPartNum.Size = New System.Drawing.Size(160, 22)
        Me.txtPartNum.TabIndex = 0
        Me.txtPartNum.Text = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.Location = New System.Drawing.Point(5, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(300, 39)
        Me.Label6.TabIndex = 10
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCellStarPartNumUpdate
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(720, 509)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.Panel1})
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCellStarPartNumUpdate"
        Me.Text = "Cell Star Part Number Update"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        If Not IsNothing(dtPartNum) Then
            dtPartNum.Dispose()
            dtPartNum = Nothing
        End If
        objCellStarBER = Nothing
        MyBase.Finalize()
    End Sub
    '******************************************************************************
    Private Sub frmCellStarPartNumUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Handlers to highlight in custom colors
        SetHandler(Me.cmbEnterprise)
        SetHandler(Me.cmbCarrier)
        SetHandler(Me.cmbModel)
        SetHandler(Me.txtPartNum)
        SetHandler(Me.txtLaborAmt)
        SetHandler(Me.txtBer)

        'populate combox
        Dim strSQL As String = ""
        strSQL = "SELECT ent_id, ent_shortdesc FROM cs_enterprise order by ent_shortdesc;"
        PopulateComboBox(strSQL, Me.cmbEnterprise, "cs_enterprise")
        strSQL = "SELECT carrier_id, carrier_shortdesc FROM cs_carrier order by carrier_shortdesc;"
        PopulateComboBox(strSQL, Me.cmbCarrier, "cs_carrier")
        strSQL = "SELECT model_id, model_desc " & Environment.NewLine
        strSQL &= "FROM tmodel " & Environment.NewLine
        strSQL &= "WHERE Prod_ID = 2 order by model_desc;"
        PopulateComboBox(strSQL, Me.cmbModel, "tmodel")
        Me.txtPartNum.Focus()
    End Sub
    '******************************************************************************
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

    '******************************************************************************
    Private Sub txtPartNum_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPartNum.KeyUp

        Try
            If e.KeyValue = 13 Then

                If Trim(Me.txtPartNum.Text) = "" Then
                    Exit Sub
                End If
                If Trim(Me.txtPartNum.Text).Length < 6 Then
                    Throw New Exception("Part number must contain 6 digit number.")
                ElseIf Not IsNumeric(Trim(Me.txtPartNum.Text)) Then
                    Throw New Exception("Part number must be numeric.")
                End If

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                Dim strSQL As String = ""

                dtPartNum = objCellStarBER.GetPartNumEntry(CInt(Trim(Me.txtPartNum.Text)))
                If dtPartNum.Rows.Count > 0 Then
                    Me.cmbEnterprise.SelectedValue = dtPartNum.Rows(0)("ent_id")
                    Me.cmbCarrier.SelectedValue = dtPartNum.Rows(0)("carrier_id")
                    Me.cmbModel.SelectedValue = dtPartNum.Rows(0)("model_id")
                    Me.txtLaborAmt.Text = dtPartNum.Rows(0)("laboramount")
                    Me.txtBer.Text = dtPartNum.Rows(0)("BERrate")
                    iUpdtFlg = 1    '1:Update
                    Me.cmbCarrier.Enabled = True
                    Me.cmbEnterprise.Enabled = True
                    Me.cmbModel.Enabled = True
                    Me.txtLaborAmt.Enabled = True
                    Me.txtBer.Enabled = True
                Else
                    iUpdtFlg = 2  '2:Insert
                End If

                Me.txtPartNum.Enabled = False
                Me.cmbEnterprise.Enabled = True
                Me.cmbEnterprise.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("txtPartNum_KeyUp():" & ex.ToString, "Get Part Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtPartNum.Text = ""
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '******************************************************************************
    Private Sub PopulateComboBox(ByVal strSql As String, _
                                 ByRef cmbox As System.Windows.Forms.ComboBox, _
                                 ByVal strCmbName As String)
        Dim dt As DataTable
        Try
            dt = objCellStarBER.GetCmbDisplayData(strSql, strCmbName)
            cmbox.DataSource = dt.DefaultView
            cmbox.ValueMember = dt.Columns(0).ToString
            cmbox.DisplayMember = dt.Columns(1).ToString
            cmbox.SelectedValue = 0
        Catch ex As Exception
            Throw New Exception("PopulateComboBox():" & ex.ToString)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try

    End Sub

    '******************************************************************************
    Private Sub cmbEnterprise_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbEnterprise.SelectionChangeCommitted
        If Me.cmbEnterprise.SelectedValue > 0 Then
            Me.cmbCarrier.Enabled = True
            Me.cmbCarrier.Focus()
        End If
    End Sub

    '******************************************************************************
    Private Sub cmbCarrier_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCarrier.SelectionChangeCommitted
        If Me.cmbCarrier.SelectedValue > 0 Then
            Me.cmbModel.Enabled = True
            Me.cmbModel.Focus()
        End If
    End Sub

    '******************************************************************************
    Private Sub cmbModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModel.SelectionChangeCommitted
        If Me.cmbModel.SelectedValue > 0 Then
            Me.txtLaborAmt.Enabled = True
            Me.txtBer.Enabled = True
            Me.txtLaborAmt.Focus()
        End If
    End Sub

    '******************************************************************************
    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim strPartNum As String = Trim(Me.txtPartNum.Text)
        Dim i As Integer = 0
        Dim dt As DataTable
        Dim iPartNum As Integer = 0
        Dim iEnterpriseID As Integer = 0
        Dim iCarrier As Integer = 0
        Dim imodel As Integer = 0
        Dim dLaborAmt As Double = 0
        Dim dBerRate As Double = 0

        Try
            '***************************
            'validate input
            If strPartNum = "" Or strPartNum.Length < 6 Or Not IsNumeric(strPartNum) Then
                Throw New Exception("Part Number must be 6 digits.")
            End If
            If Me.cmbEnterprise.SelectedValue = 0 Then
                Throw New Exception("Enterprise is not defined.")
            End If
            If Me.cmbCarrier.SelectedValue = 0 Then
                Throw New Exception("Carrier is not defined.")
            End If
            If Me.cmbModel.SelectedValue = 0 Then
                Throw New Exception("Model is not defined.")
            End If
            If Me.txtLaborAmt.Text = "" Or Not IsNumeric(Trim(Me.txtLaborAmt.Text)) Then
                Throw New Exception("Labor amount is not defined.")
            End If
            If Me.txtBer.Text = "" Or Not IsNumeric(Trim(Me.txtBer.Text)) Then
                Throw New Exception("Labor amount is not defined.")
            End If
            '***************************
            'Get input data
            iPartNum = CInt(strPartNum)
            iEnterpriseID = CInt(Me.cmbEnterprise.SelectedValue)
            iCarrier = CInt(Me.cmbCarrier.SelectedValue)
            imodel = CInt(Me.cmbModel.SelectedValue)
            dLaborAmt = Trim(Me.txtLaborAmt.Text)
            dBerRate = Trim(Me.txtBer.Text)
            '***************************
            'existing record
            If iUpdtFlg = 1 Then
                'nothing changed
                If iPartNum = dtPartNum.Rows(0)("part_number") And _
                             iEnterpriseID = dtPartNum.Rows(0)("ent_id") And _
                             iCarrier = dtPartNum.Rows(0)("carrier_id") And _
                             imodel = dtPartNum.Rows(0)("model_id") And _
                             dLaborAmt = dtPartNum.Rows(0)("laboramount") And _
                             dBerRate = dtPartNum.Rows(0)("BERrate") Then
                    MessageBox.Show("No change has made for part number '" & iPartNum & "' therefore update have been canceled.", "Cell Start Part Number Update ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If
            '***************************

            i = objCellStarBER.UpdtCSPartNum(iPartNum, _
                                             Me.cmbEnterprise.SelectedValue, _
                                             Me.cmbCarrier.SelectedValue, _
                                             Me.cmbModel.SelectedValue, _
                                             dLaborAmt, _
                                             dBerRate, _
                                             iUpdtFlg)
            If i > 0 Then
                MessageBox.Show("Part Number '" & strPartNum & "' has been successfully update.", "Update Cell Star Part Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("Fail to update.", "Update Cell Star Part Number", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

            'clear all global variable and control
            ClearAll()
        Catch ex As Exception
            MessageBox.Show("cmdUpdate_Click(): " & ex.ToString, "Cell Star Part Number Update", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try

    End Sub

    '******************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        ClearAll()
    End Sub

    '******************************************************************************
    Private Sub ClearAll()
        Me.cmbEnterprise.SelectedValue = 0
        Me.cmbCarrier.SelectedValue = 0
        Me.cmbModel.SelectedValue = 0
        Me.cmbEnterprise.Enabled = False
        Me.cmbCarrier.Enabled = False
        Me.cmbModel.Enabled = False
        Me.txtPartNum.Enabled = True
        Me.txtPartNum.Text = ""
        Me.txtPartNum.Focus()
        dtPartNum = Nothing
        iUpdtFlg = 0

        Me.txtLaborAmt.Text = ""
        Me.txtLaborAmt.Enabled = False
        Me.txtBer.Text = ""
        Me.txtBer.Enabled = False
    End Sub

    '******************************************************************************
    Private Sub txtLaborAmt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLaborAmt.KeyUp
        If e.KeyValue = 13 Then
            Me.txtBer.Focus()
        End If
    End Sub
    '******************************************************************************

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
