Public Class frmUserSelection
    Inherits System.Windows.Forms.Form

    Private booReturnFlg As Boolean = False
    Private iSelectedID As Integer = 0
    Private strSelectedDesc As String = ""
    Private strSql As String = ""
    Private strSelectionName As String = ""
    Public colorBGColor As Color = Color.SteelBlue


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strQuery As String, _
                   ByVal strName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.strSql = strQuery
        Me.strSelectionName = strName

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
    Friend WithEvents cmbSelection As PSS.Gui.Controls.ComboBox
    Friend WithEvents lblSelection As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmbSelection = New PSS.Gui.Controls.ComboBox()
        Me.lblSelection = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbSelection
        '
        Me.cmbSelection.Items.AddRange(New Object() {"", "Company Name", "Customer Last Name", "Customer Work Order", "PSS Work Order", "Tray Number", "Serial Number", "Ship Manifest", "Old Serial", "IMEI Number", "Pallet ID"})
        Me.cmbSelection.Location = New System.Drawing.Point(8, 23)
        Me.cmbSelection.Name = "cmbSelection"
        Me.cmbSelection.Size = New System.Drawing.Size(232, 21)
        Me.cmbSelection.TabIndex = 1
        '
        'lblSelection
        '
        Me.lblSelection.BackColor = System.Drawing.Color.Transparent
        Me.lblSelection.ForeColor = System.Drawing.Color.White
        Me.lblSelection.Location = New System.Drawing.Point(8, 6)
        Me.lblSelection.Name = "lblSelection"
        Me.lblSelection.Size = New System.Drawing.Size(232, 16)
        Me.lblSelection.TabIndex = 2
        Me.lblSelection.Text = "Label1"
        Me.lblSelection.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.SteelBlue
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(176, 50)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(48, 24)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "OK"
        '
        'frmUserSelection
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.DarkKhaki
        Me.ClientSize = New System.Drawing.Size(248, 78)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnOK, Me.lblSelection, Me.cmbSelection})
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserSelection"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Selection"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************
    'Read only property
    '********************************
    Public ReadOnly Property ReturnFlg() As Boolean
        Get
            Return Me.booReturnFlg
        End Get
    End Property
    Public ReadOnly Property ID() As Integer
        Get
            Return Me.iSelectedID
        End Get
    End Property
    Public ReadOnly Property Desc() As String
        Get
            Return Me.strSelectedDesc
        End Get
    End Property

    '************************************************************************
    Private Sub frmUserSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt1 As DataTable
        Dim objDataMisc As New PSS.Data.production.Misc()

        Try
            objDataMisc._SQL = Me.strSql
            dt1 = objDataMisc.GetDataTable
            dt1.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
            With Me.cmbSelection
                .DataSource = dt1.DefaultView
                .ValueMember = dt1.Columns(0).ToString
                .DisplayMember = dt1.Columns(1).ToString
                .SelectedValue = 0
            End With

            Me.lblSelection.Text = strSelectionName
            Me.Text = strSelectionName
            Me.BackColor = Me.colorBGColor
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form LoadEven", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objDataMisc = Nothing
        End Try
    End Sub

    ''************************************************************************
    'Private Sub cmbSelection_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSelection.SelectionChangeCommitted
    '    Try
    '        If Me.cmbSelection.SelectedValue > 0 Then
    '            Me.iSelectedID = Me.cmbSelection.SelectedValue
    '            Me.strSelectedDesc = Me.cmbSelection.SelectedItem(Me.cmbSelection.DisplayMember)
    '            Me.booReturnFlg = True
    '            Me.Close()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString, "ComboSelection_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '    End Try
    'End Sub

    '************************************************************************
    Private Sub cmbSelection_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSelection.KeyUp

        Try
            If e.KeyValue = 13 Then
                If Me.cmbSelection.Text <> "-- SELECT --" Then
                    If Me.cmbSelection.SelectedValue > 0 Then
                        Me.iSelectedID = Me.cmbSelection.SelectedValue
                        Me.strSelectedDesc = Me.cmbSelection.SelectedItem(Me.cmbSelection.DisplayMember)
                        Me.booReturnFlg = True
                        Me.Close()
                    End If
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ComboSelection_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '************************************************************************
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim R1 As DataRow
        Dim i As Integer = 0

        Try
            If Me.cmbSelection.Text <> "-- SELECT --" Then
                If Me.cmbSelection.SelectedValue > 0 Then
                    Me.iSelectedID = Me.cmbSelection.SelectedValue
                    Me.strSelectedDesc = Me.cmbSelection.SelectedItem(Me.cmbSelection.DisplayMember)
                    Me.booReturnFlg = True
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ComboSelection_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            R1 = Nothing
        End Try
    End Sub

    '************************************************************************
End Class
