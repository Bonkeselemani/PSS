Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmSelectedValue
    Inherits System.Windows.Forms.Form

    Public _iSelectedVal As Integer = 0
    Public _strSelectedDesc As String = ""
    Private _strSql As String = ""
    Private _strValColName As String = ""
    Private _strDisplayColname As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strSql As String, _
                   ByVal strSelectMsg As String, _
                   ByVal strSelectedValColName As String, _
                   ByVal strSelectedDescColName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.lblSelectMsg.Text = strSelectMsg
        Me._strSql = strSql
        _strValColName = strSelectedValColName
        _strDisplayColname = strSelectedDescColName
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
    Friend WithEvents lblSelectMsg As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cboSelect As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblSelectMsg = New System.Windows.Forms.Label()
        Me.cboSelect = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblSelectMsg
        '
        Me.lblSelectMsg.BackColor = System.Drawing.Color.Transparent
        Me.lblSelectMsg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectMsg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblSelectMsg.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.lblSelectMsg.Location = New System.Drawing.Point(8, 8)
        Me.lblSelectMsg.Name = "lblSelectMsg"
        Me.lblSelectMsg.Size = New System.Drawing.Size(280, 16)
        Me.lblSelectMsg.TabIndex = 75
        Me.lblSelectMsg.Text = "Select:"
        Me.lblSelectMsg.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cboSelect
        '
        Me.cboSelect.Location = New System.Drawing.Point(8, 24)
        Me.cboSelect.Name = "cboSelect"
        Me.cboSelect.Size = New System.Drawing.Size(280, 21)
        Me.cboSelect.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.SteelBlue
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(48, 56)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(80, 32)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(176, 56)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 32)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        '
        'frmSelectedValue
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(292, 101)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnOK, Me.lblSelectMsg, Me.cboSelect})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmSelectedValue"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSelectedValue"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmSelectedValue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            Me.PopulateSelectData()
            
            Me.cboSelect.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmSelectedValue_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateSelectData()
        Dim dt As DataTable
        Dim drNewRow As DataRow
        Dim dc As DataColumn
        Dim booIDColExist As Boolean = False
        Dim booDescColExist As Boolean = False

        Try
            dt = Generic.GetDataTable(Me._strSql)

            For Each dc In dt.Columns
                If dc.ColumnName.Trim = _strValColName Then booIDColExist = True
                If dc.ColumnName.Trim = _strDisplayColname Then booDescColExist = True
            Next dc

            If booIDColExist = True And booDescColExist = True Then

                drNewRow = dt.NewRow
                drNewRow(Me._strValColName) = 0
                drNewRow(Me._strDisplayColname) = "--Select--"
                dt.Rows.Add(drNewRow)
                dt.AcceptChanges()

                With Me.cboSelect
                    .DataSource = dt.DefaultView
                    .ValueMember = _strValColName
                    .DisplayMember = Me._strDisplayColname
                    .SelectedValue = 0
                End With
            End If

            Me.cboSelect.Focus()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me._iSelectedVal = 0
        Me._strSelectedDesc = ""
        Me.Close()
    End Sub

    '******************************************************************
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try
            Me.ProcessSelectedData()
            If Me._iSelectedVal > 0 And Me._strSelectedDesc.Trim.Length > 0 Then Me.Close() Else MessageBox.Show("Please select a value in drop down list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '******************************************************************
    Private Sub ProcessSelectedData()
        Try
            If Not IsNothing(Me.cboSelect.DataSource) Then
                If Me.cboSelect.Items.Count > 0 Then
                    If Me.cboSelect.SelectedValue = 0 Then
                        Me._iSelectedVal = 0
                        Me._strSelectedDesc = ""
                    Else
                        Me._iSelectedVal = Me.cboSelect.SelectedValue
                        Me._strSelectedDesc = Me.cboSelect.Text
                    End If
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '******************************************************************
    Private Sub cboSelect_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSelect.KeyUp
        Try
            If e.KeyValue = 13 Then 'enter key
                Me.ProcessSelectedData()
                If Me._iSelectedVal > 0 And Me._strSelectedDesc.Trim.Length > 0 Then Me.Close() Else MessageBox.Show("Please select a value in drop down list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboSelect_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '******************************************************************
End Class
