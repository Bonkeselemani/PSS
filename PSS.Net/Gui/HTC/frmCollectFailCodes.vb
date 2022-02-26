Option Explicit On 

Public Class frmCollectFailCodes
    Inherits System.Windows.Forms.Form

    Public _booCancelCollection As Boolean = False
    Private _objHTC As PSS.Data.Buisness.HTC
    Private _strStation As String = ""
    Private _iFailCodeMainCategory As Integer = 0
    Private _dtSelectedFailRepCode As DataTable = Nothing
    Private _iDeviceID As Integer = 0
    Private _booPopulateData As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strStation As String, ByVal iFCMainCategory As Integer, ByVal dtSelectedFCRC As DataTable, ByVal iDevice_ID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._strStation = strStation
        Me._iFailCodeMainCategory = iFCMainCategory
        Me._dtSelectedFailRepCode = dtSelectedFCRC
        Me._iDeviceID = iDevice_ID

        Me._objHTC = New PSS.Data.Buisness.HTC()
        PSS.Data.Buisness.Generic.DisposeDT(dtSelectedFCRC)
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        _objHTC = Nothing
        If Not IsNothing(_dtSelectedFailRepCode) Then
            _dtSelectedFailRepCode.Dispose()
            _dtSelectedFailRepCode = Nothing
        End If

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chklstFailCodes As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlFailCodes = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chklstFailCodes = New System.Windows.Forms.CheckedListBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.pnlFailCodes.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlFailCodes
        '
        Me.pnlFailCodes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.chklstFailCodes})
        Me.pnlFailCodes.Location = New System.Drawing.Point(8, 40)
        Me.pnlFailCodes.Name = "pnlFailCodes"
        Me.pnlFailCodes.Size = New System.Drawing.Size(440, 336)
        Me.pnlFailCodes.TabIndex = 125
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Fail Codes:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chklstFailCodes
        '
        Me.chklstFailCodes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.chklstFailCodes.Location = New System.Drawing.Point(8, 24)
        Me.chklstFailCodes.Name = "chklstFailCodes"
        Me.chklstFailCodes.Size = New System.Drawing.Size(416, 289)
        Me.chklstFailCodes.TabIndex = 121
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.CadetBlue
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(16, 8)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(128, 24)
        Me.btnSave.TabIndex = 127
        Me.btnSave.Text = "SAVE"
        Me.btnSave.Visible = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(320, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(128, 24)
        Me.btnCancel.TabIndex = 128
        Me.btnCancel.Text = "CANCEL"
        '
        'frmCollectFailCodes
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(458, 391)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnSave, Me.pnlFailCodes})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmCollectFailCodes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Collect Failcodes and Repaircodes"
        Me.pnlFailCodes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmCollectFailCodesRepCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If _strStation = "DIAGNOSTIC" Then
                Me.btnSave.Visible = True
            End If

            Me.PopulateFailcodes(Me._iFailCodeMainCategory, )

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateFailcodes(Optional ByVal iFailcodeMainCategroy As Integer = 0, _
                                  Optional ByVal iRepairID As Integer = 0)
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            dt = Me._objHTC.GetFailCodes(2, , iRepairID, iFailcodeMainCategroy)
            With Me.chklstFailCodes
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .DisplayMember = "Fail_LDesc"
                .ValueMember = "Fail_ID"
                .ItemHeight = 150
                .Tag = iFailcodeMainCategroy

                '*****************************************
                'set check item from previous selection
                '*****************************************
                Me._booPopulateData = True
                For i = 0 To .Items.Count - 1
                    If Not IsNothing(Me._dtSelectedFailRepCode) AndAlso Me._dtSelectedFailRepCode.Rows.Count > 0 Then
                        If Me._dtSelectedFailRepCode.Select("Fail_ID = " & .Items.Item(i)("Fail_ID")).Length > 0 Then
                            .SetItemChecked(i, True)
                        End If
                    End If
                Next i
                Me._booPopulateData = False
                '*****************************************
            End With
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me._booCancelCollection = True
        Me.Close()
    End Sub

    '******************************************************************
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If Me.chklstFailCodes.CheckedItems.Count = 0 Then
                MessageBox.Show("Please select fail codes or click cancel button.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Me.SaveCheckedFailCode()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub SaveCheckedFailCode()
        Dim i As Integer

        Try
            For i = 0 To Me.chklstFailCodes.CheckedItems.Count - 1
                'If Me.chklstFailCodes.GetItemChecked(i) = True Then
                If Not IsNothing(Me._dtSelectedFailRepCode) AndAlso Me._dtSelectedFailRepCode.Rows.Count > 0 Then
                    If Me._dtSelectedFailRepCode.Select("Fail_ID = " & Me.chklstFailCodes.CheckedItems.Item(i)("Fail_ID")).Length = 0 Then
                        'insert if not exist
                        'Me._objHTC.InsertFailCodeToRepairTable(_iDeviceID, Me.chklstFailCodes.CheckedItems.Item(i)("Fail_ID"), PSS.Core.Global.ApplicationUser.IDuser, _strStation)
                    End If
                Else
                    'no fail code existed -> insert
                    'Me._objHTC.InsertFailCodeToRepairTable(_iDeviceID, Me.chklstFailCodes.SelectedValue, PSS.Core.Global.ApplicationUser.IDuser, _strStation)
                End If
            Next i
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstFailCodes_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chklstFailCodes.ItemCheck
        Try
            If e.NewValue = CheckState.Unchecked Then
                If Not IsNothing(Me._dtSelectedFailRepCode) AndAlso Me._dtSelectedFailRepCode.Rows.Count > 0 Then
                    If Me._dtSelectedFailRepCode.Select("Fail_ID = " & Me.chklstFailCodes.SelectedValue).Length > 0 Then
                        'Can't remove fail codes from this screen
                        e.NewValue = CheckState.Checked
                    End If
                End If
            ElseIf Me._booPopulateData = True Then
                Exit Sub
            Else
                If Me._strStation = "DIAGNOSTIC" Then
                    If Not IsNothing(Me._dtSelectedFailRepCode) AndAlso Me._dtSelectedFailRepCode.Rows.Count > 0 Then
                        If Me._dtSelectedFailRepCode.Select("Fail_ID = " & Me.chklstFailCodes.SelectedValue).Length > 0 Then
                            MessageBox.Show("This fail code was already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        End If
                    End If
                Else
                    If Not IsNothing(Me._dtSelectedFailRepCode) AndAlso Me._dtSelectedFailRepCode.Rows.Count > 0 Then
                        If Me._dtSelectedFailRepCode.Select("Fail_ID = " & Me.chklstFailCodes.SelectedValue).Length > 0 Then
                            MessageBox.Show("This fail code was already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            'does not exist then add
                            Me._objHTC.InsertFailCodeToRepairTable(_iDeviceID, Me.chklstFailCodes.Tag, Me.chklstFailCodes.SelectedValue, PSS.Core.Global.ApplicationUser.IDuser, _strStation)
                            Me.Close()
                        End If
                    Else
                        'no fail code then add
                        Me._objHTC.InsertFailCodeToRepairTable(_iDeviceID, Me.chklstFailCodes.Tag, Me.chklstFailCodes.SelectedValue, PSS.Core.Global.ApplicationUser.IDuser, _strStation)
                        Me.Close()
                    End If
                End If
            End If

            Me.chklstFailCodes.ClearSelected()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "chklstFailCodes_ItemCheck", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub chklstFailCodes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chklstFailCodes.KeyUp
        If e.KeyValue = 13 Then
            If MessageBox.Show("Are you sure you want to save checked fail code?.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                Exit Sub
            Else
                Me.SaveCheckedFailCode()
            End If
        End If
    End Sub

    '******************************************************************

End Class
