
Public Class frmAssignBERValue
    Inherits System.Windows.Forms.Form

    Private objCellStarBER As PSS.Data.Buisness.CellStarBER
    Private iCustID As Integer = 2113       'Cust_ID of CellStar
    Private iManufID As Integer = 0
    Private iModelID As Integer = 0
    Private decBERVal As Decimal = 0.0

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
    Friend WithEvents cmbCust As System.Windows.Forms.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbModel As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbManuf As System.Windows.Forms.ComboBox
    Friend WithEvents txtBER As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents cmdClear As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmbCust = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.cmdClear = New System.Windows.Forms.Button()
        Me.txtBER = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbModel = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbManuf = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbCust
        '
        Me.cmbCust.Enabled = False
        Me.cmbCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCust.Location = New System.Drawing.Point(104, 12)
        Me.cmbCust.Name = "cmbCust"
        Me.cmbCust.Size = New System.Drawing.Size(176, 24)
        Me.cmbCust.TabIndex = 0
        Me.cmbCust.Text = "Cell Star"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdUpdate, Me.cmdClear, Me.txtBER, Me.Label4, Me.Label3, Me.cmbModel, Me.Label2, Me.cmbManuf, Me.Label1, Me.cmbCust})
        Me.Panel1.Location = New System.Drawing.Point(3, 51)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(301, 208)
        Me.Panel1.TabIndex = 1
        '
        'cmdUpdate
        '
        Me.cmdUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.cmdUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Location = New System.Drawing.Point(184, 168)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(72, 24)
        Me.cmdUpdate.TabIndex = 5
        Me.cmdUpdate.Text = "Update  "
        '
        'cmdClear
        '
        Me.cmdClear.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClear.Location = New System.Drawing.Point(32, 168)
        Me.cmdClear.Name = "cmdClear"
        Me.cmdClear.Size = New System.Drawing.Size(80, 24)
        Me.cmdClear.TabIndex = 4
        Me.cmdClear.Text = "Clear"
        '
        'txtBER
        '
        Me.txtBER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBER.Location = New System.Drawing.Point(104, 124)
        Me.txtBER.MaxLength = 6
        Me.txtBER.Name = "txtBER"
        Me.txtBER.Size = New System.Drawing.Size(176, 22)
        Me.txtBER.TabIndex = 3
        Me.txtBER.Text = ""
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(48, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 16)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "BER : "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Model : "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbModel
        '
        Me.cmbModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.Location = New System.Drawing.Point(104, 83)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(176, 24)
        Me.cmbModel.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Manufacturer : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbManuf
        '
        Me.cmbManuf.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbManuf.Location = New System.Drawing.Point(104, 48)
        Me.cmbManuf.Name = "cmbManuf"
        Me.cmbManuf.Size = New System.Drawing.Size(176, 24)
        Me.cmbManuf.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Black
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Yellow
        Me.Label5.Location = New System.Drawing.Point(3, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(301, 48)
        Me.Label5.TabIndex = 4
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGrid1
        '
        Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(305, 51)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(360, 208)
        Me.DataGrid1.TabIndex = 5
        Me.DataGrid1.Visible = False
        '
        'frmAssignBERValue
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(688, 461)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1, Me.Label5, Me.Panel1})
        Me.Name = "frmAssignBERValue"
        Me.Text = "Assign BER Value"
        Me.Panel1.ResumeLayout(False)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    '******************************** lan ******************************
    Protected Overrides Sub Finalize()
        objCellStarBER = Nothing
        MyBase.Finalize()
    End Sub


    '******************************** lan ******************************
    Private Sub frmAssignBERValue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dt1 As DataTable

        'Handlers to highlight in custom colors
        SetHandler(Me.cmbManuf)
        SetHandler(Me.cmbModel)
        SetHandler(Me.txtBER)

        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            dt1 = objCellStarBER.GetManuf
            dt1.DefaultView.Sort = "Manuf_Desc"
            dt1.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)

            Me.cmbManuf.DataSource = dt1.DefaultView
            Me.cmbManuf.DisplayMember = dt1.Columns("Manuf_Desc").ToString
            Me.cmbManuf.ValueMember = dt1.Columns("Manuf_ID").ToString
            Me.cmbManuf.SelectedValue = 0
            Me.cmbManuf.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Populate Manufacturer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try

    End Sub


    '******************************** lan ******************************
    Private Sub cmbManuf_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbManuf.SelectionChangeCommitted
        Dim dt1 As DataTable

        If Me.cmbManuf.SelectedValue > 0 Then
            'reset 
            Me.cmbModel.SelectedValue = 0
            Me.txtBER.Text = ""
            iModelID = 0
            decBERVal = 0.0

            iManufID = Me.cmbManuf.SelectedValue
            Me.cmbModel.Focus()

            'populate model
            '------------------------------------------------------
            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                'populate model
                dt1 = objCellStarBER.GetModelByManufID(iManufID, Me.cmbManuf.Text)

                dt1.DefaultView.Sort = "Model_Desc"
                dt1.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)

                Me.cmbModel.DataSource = dt1.DefaultView
                Me.cmbModel.DisplayMember = dt1.Columns("Model_Desc").ToString
                Me.cmbModel.ValueMember = dt1.Columns("Model_ID").ToString
                Me.cmbModel.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Populate Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
            '----------------------------------------------------------
        End If
    End Sub

    '******************************** lan ******************************
    Private Sub cmbModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModel.SelectionChangeCommitted

        If Me.cmbModel.SelectedValue > 0 Then
            'reset 
            Me.txtBER.Text = ""
            decBERVal = 0.0

            iModelID = Me.cmbModel.SelectedValue
            Me.txtBER.Focus()
            Me.Label5.Text = iModelID & Environment.NewLine & Me.cmbModel.Text
        End If
    End Sub

    '******************************** lan ******************************
    Private Sub cmdClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        iCustID = 2113       'Cust_ID of CellStar
        iManufID = 0
        iModelID = 0
        decBERVal = 0.0

        Me.txtBER.Text = ""
        Me.cmbManuf.SelectedValue = 0
        Me.cmbModel.SelectedValue = 0
        Me.cmbManuf.Focus()
    End Sub

    '******************************** lan ******************************
    Private Sub cmdUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Dim strBER As String = Trim(Me.txtBER.Text)
        Dim dbBER As Double = 0.0
        Dim iresult As Integer = 0

        If iManufID = 0 Then
            MessageBox.Show("Please select Manufacturer.", "Assign BER Value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If iModelID = 0 Then
            MessageBox.Show("Please select Model.", "Assign BER Value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If strBER = "" Then
            MessageBox.Show("Please enter BER value.", "Assign BER Value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Exit Sub
        Else
            If Not IsNumeric(strBER) Then
                MessageBox.Show("BER value must be numeric.", "Assign BER Value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtBER.SelectAll()
                Exit Sub
            Else
                dbBER = strBER
                Label5.Text = dbBER
                If dbBER >= 3.0 Then
                    decBERVal = dbBER
                ElseIf dbBER < 3.0 Then
                    MessageBox.Show("BER value can not lesser than 3.00", "Assign BER Value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBER.SelectAll()
                    Exit Sub
                End If
            End If
        End If

        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim dt1 As DataTable
            dt1 = objCellStarBER.UpdateBERVal(iCustID, iManufID, iModelID, decBERVal)

            If dt1.Rows.Count > 0 Then
                Me.DataGrid1.DataSource = dt1
                Me.DataGrid1.Visible = True
            Else
                Throw New Exception("Unable to update.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Assign BER Value", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*********************************** LAN *******************************
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

    '******************************** lan *************************************

End Class


