Imports System
Imports System.Data
Imports PSS.Data

Public Class frmAddRetailer
    Inherits System.Windows.Forms.Form

    Private _strRetailerName As String
    Private _dtRetailers As DataTable
    Private _objDriveLine As PSS.Data.Buisness.DriveLine


#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strRetailerName As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._strRetailerName = strRetailerName
        Me._objDriveLine = New PSS.Data.Buisness.DriveLine()

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
    Friend WithEvents btnFinished As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents grpBoxRetailer As System.Windows.Forms.GroupBox
    Friend WithEvents txtRetailerShortName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRetailerName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblRetailerName As System.Windows.Forms.Label
    Friend WithEvents rbtnDefine As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSelect As System.Windows.Forms.RadioButton
    Friend WithEvents lblChoiceMsg As System.Windows.Forms.Label
    Friend WithEvents chkLstBox_Reatilers As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblErrMsg As System.Windows.Forms.Label
    Friend WithEvents lblDefinedShortName As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnFinished = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.grpBoxRetailer = New System.Windows.Forms.GroupBox()
        Me.txtRetailerShortName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRetailerName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblRetailerName = New System.Windows.Forms.Label()
        Me.rbtnDefine = New System.Windows.Forms.RadioButton()
        Me.rbtnSelect = New System.Windows.Forms.RadioButton()
        Me.lblChoiceMsg = New System.Windows.Forms.Label()
        Me.chkLstBox_Reatilers = New System.Windows.Forms.CheckedListBox()
        Me.lblErrMsg = New System.Windows.Forms.Label()
        Me.lblDefinedShortName = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.grpBoxRetailer.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFinished
        '
        Me.btnFinished.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFinished.ForeColor = System.Drawing.Color.MediumBlue
        Me.btnFinished.Location = New System.Drawing.Point(176, 392)
        Me.btnFinished.Name = "btnFinished"
        Me.btnFinished.Size = New System.Drawing.Size(152, 40)
        Me.btnFinished.TabIndex = 32
        Me.btnFinished.Text = "Finish"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Firebrick
        Me.btnClose.Location = New System.Drawing.Point(392, 408)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(64, 40)
        Me.btnClose.TabIndex = 33
        Me.btnClose.Text = "Close"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblHeader, Me.grpBoxRetailer, Me.lblRetailerName, Me.rbtnDefine, Me.rbtnSelect, Me.lblChoiceMsg, Me.chkLstBox_Reatilers})
        Me.Panel1.Location = New System.Drawing.Point(40, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(432, 368)
        Me.Panel1.TabIndex = 34
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.White
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(32, 72)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(368, 24)
        Me.lblHeader.TabIndex = 38
        Me.lblHeader.Text = "     Retailer Short Name - Retailer Name"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'grpBoxRetailer
        '
        Me.grpBoxRetailer.BackColor = System.Drawing.Color.WhiteSmoke
        Me.grpBoxRetailer.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtRetailerShortName, Me.Label2, Me.txtRetailerName, Me.Label1})
        Me.grpBoxRetailer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpBoxRetailer.Location = New System.Drawing.Point(32, 264)
        Me.grpBoxRetailer.Name = "grpBoxRetailer"
        Me.grpBoxRetailer.Size = New System.Drawing.Size(376, 96)
        Me.grpBoxRetailer.TabIndex = 37
        Me.grpBoxRetailer.TabStop = False
        '
        'txtRetailerShortName
        '
        Me.txtRetailerShortName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetailerShortName.Location = New System.Drawing.Point(152, 56)
        Me.txtRetailerShortName.MaxLength = 4
        Me.txtRetailerShortName.Name = "txtRetailerShortName"
        Me.txtRetailerShortName.Size = New System.Drawing.Size(208, 22)
        Me.txtRetailerShortName.TabIndex = 22
        Me.txtRetailerShortName.Text = ""
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 24)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Retailer Short Name:"
        '
        'txtRetailerName
        '
        Me.txtRetailerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRetailerName.Location = New System.Drawing.Point(152, 24)
        Me.txtRetailerName.Name = "txtRetailerName"
        Me.txtRetailerName.Size = New System.Drawing.Size(208, 22)
        Me.txtRetailerName.TabIndex = 20
        Me.txtRetailerName.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 24)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Retailer Name:"
        '
        'lblRetailerName
        '
        Me.lblRetailerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRetailerName.Location = New System.Drawing.Point(224, 16)
        Me.lblRetailerName.Name = "lblRetailerName"
        Me.lblRetailerName.Size = New System.Drawing.Size(200, 24)
        Me.lblRetailerName.TabIndex = 36
        '
        'rbtnDefine
        '
        Me.rbtnDefine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnDefine.Location = New System.Drawing.Point(32, 240)
        Me.rbtnDefine.Name = "rbtnDefine"
        Me.rbtnDefine.Size = New System.Drawing.Size(328, 32)
        Me.rbtnDefine.TabIndex = 35
        Me.rbtnDefine.Text = "Check this and define a name"
        '
        'rbtnSelect
        '
        Me.rbtnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSelect.Location = New System.Drawing.Point(32, 40)
        Me.rbtnSelect.Name = "rbtnSelect"
        Me.rbtnSelect.Size = New System.Drawing.Size(328, 32)
        Me.rbtnSelect.TabIndex = 34
        Me.rbtnSelect.Text = "Check this and select a name from the list"
        '
        'lblChoiceMsg
        '
        Me.lblChoiceMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChoiceMsg.Location = New System.Drawing.Point(32, 16)
        Me.lblChoiceMsg.Name = "lblChoiceMsg"
        Me.lblChoiceMsg.Size = New System.Drawing.Size(192, 24)
        Me.lblChoiceMsg.TabIndex = 33
        Me.lblChoiceMsg.Text = "Please define retailer name: "
        '
        'chkLstBox_Reatilers
        '
        Me.chkLstBox_Reatilers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.chkLstBox_Reatilers.CheckOnClick = True
        Me.chkLstBox_Reatilers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLstBox_Reatilers.Location = New System.Drawing.Point(32, 96)
        Me.chkLstBox_Reatilers.Name = "chkLstBox_Reatilers"
        Me.chkLstBox_Reatilers.Size = New System.Drawing.Size(368, 136)
        Me.chkLstBox_Reatilers.TabIndex = 32
        '
        'lblErrMsg
        '
        Me.lblErrMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrMsg.ForeColor = System.Drawing.Color.Red
        Me.lblErrMsg.Location = New System.Drawing.Point(24, 448)
        Me.lblErrMsg.Name = "lblErrMsg"
        Me.lblErrMsg.Size = New System.Drawing.Size(512, 88)
        Me.lblErrMsg.TabIndex = 35
        Me.lblErrMsg.Text = " Error message display"
        '
        'lblDefinedShortName
        '
        Me.lblDefinedShortName.Location = New System.Drawing.Point(112, 400)
        Me.lblDefinedShortName.Name = "lblDefinedShortName"
        Me.lblDefinedShortName.Size = New System.Drawing.Size(56, 32)
        Me.lblDefinedShortName.TabIndex = 36
        Me.lblDefinedShortName.Text = " "
        '
        'frmAddRetailer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(544, 550)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDefinedShortName, Me.lblErrMsg, Me.Panel1, Me.btnClose, Me.btnFinished})
        Me.Name = "frmAddRetailer"
        Me.Text = "Driveline - Define Retailer"
        Me.Panel1.ResumeLayout(False)
        Me.grpBoxRetailer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAddRetailer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim errMsg As String = ""
            Me.Panel1.Enabled = False : Me.btnClose.Visible = True
            Me.btnFinished.Visible = False
            Me.btnClose.Height = Me.btnFinished.Height : Me.btnClose.Width = Me.btnFinished.Width
            Me.btnClose.Left = Me.btnFinished.Left : Me.btnClose.Top = Me.btnFinished.Top
            Me.lblErrMsg.Text = ""
            Me.CenterToScreen()

            If Me._strRetailerName.Trim.Length > 0 Then
                Dim myLabel1 As String = "Please define retailer name: "
                Me.lblChoiceMsg.Text = myLabel1
                Me.lblRetailerName.Text = Me._strRetailerName.Trim
                Me.lblRetailerName.ForeColor = Color.Red
                Me._dtRetailers = Me._objDriveLine.GetDriveLineRetailersData(errMsg)
                If Me._dtRetailers.Rows.Count > 0 AndAlso errMsg.Trim.Length = 0 Then
                    Me.Panel1.Enabled = True : Me.btnClose.Visible = False
                    Me.btnFinished.Visible = True
                    BindRetailersData()
                    Me.lblHeader.ForeColor = Color.DarkGray
                    Me.chkLstBox_Reatilers.Enabled = False
                    Me.grpBoxRetailer.Enabled = False
                Else
                    ' MessageBox.Show("No retailers data. See IT", "Exception occurs!")
                    Me.DialogResult = DialogResult.No
                    'Me.Close() 'dialog as modal, can't close by code
                    Me.lblErrMsg.Text = "Sub frmAddRetailer_Load: No retailers data. See IT" & Environment.NewLine & _
                                        " " & errMsg
                End If
            Else
                'MessageBox.Show("No retailer! See IT.", "Exception occurs!")
                Me.DialogResult = DialogResult.No
                Me.lblErrMsg.Text = "Sub frmAddRetailer_Load: No retailers data. See IT"
            End If

        Catch ex As Exception
            'MessageBox.Show(ex.ToString, "Sub frmAddRetailer_Load")
            Me.DialogResult = DialogResult.No
            Me.lblErrMsg.Text = "Sub frmAddRetailer_Load: " & ex.ToString & ". See IT"
            'Me.Close()
        End Try
    End Sub

    '******************************************************************
    Private Sub rbtnSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSelect.CheckedChanged
        If Me.rbtnSelect.Checked Then
            Me.rbtnSelect.ForeColor = Color.Blue
            Me.rbtnDefine.ForeColor = Color.Black
            Me.chkLstBox_Reatilers.Enabled = True
            SetSelectRetailer()
        End If
    End Sub

    '******************************************************************
    Private Sub rbtnDefine_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnDefine.CheckedChanged
        If Me.rbtnDefine.Checked Then
            Me.rbtnSelect.ForeColor = Color.Black
            Me.rbtnDefine.ForeColor = Color.Blue
            Me.chkLstBox_Reatilers.Enabled = False
            SetDefineRetailer()
        End If
    End Sub

    '******************************************************************
    Private Sub SetSelectRetailer()
        Try
            Me.lblHeader.ForeColor = Color.Black
            Me.chkLstBox_Reatilers.Enabled = True
            Me.grpBoxRetailer.Enabled = False
            Me.txtRetailerName.Text = ""
            Me.txtRetailerShortName.Text = ""
        Catch ex As Exception
        End Try
    End Sub

    '******************************************************************
    Private Sub SetDefineRetailer()
        Try
            If Me.chkLstBox_Reatilers.SelectedItems.Count > 0 Then
                'Dim objChk As Object
                'For Each objChk In chkLstBox_Reatilers.CheckedIndices
                '    chkLstBox_Reatilers.SetItemChecked(objChk, False) 'uncheck it
                'Next
                BindRetailersData() 'refresh it
            End If

            Me.lblHeader.ForeColor = Color.DarkGray
            Me.chkLstBox_Reatilers.Enabled = False
            Me.grpBoxRetailer.Enabled = True
            Me.txtRetailerName.ReadOnly = True
            Me.txtRetailerName.Text = Me._strRetailerName
            Me.txtRetailerShortName.Focus()
        Catch ex As Exception
        End Try
    End Sub

    '******************************************************************
    Private Sub BindRetailersData()
        Try
            Dim row As DataRow
            Me.chkLstBox_Reatilers.Items.Clear()
            For Each row In Me._dtRetailers.Rows
                Me.chkLstBox_Reatilers.Items.Add(row("RetailerShortName") & " - " & row("RetailerName1"))
            Next

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "BindRetailersData")
        End Try
    End Sub

    '******************************************************************
    Private Sub chkLstBox_Reatilers_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkLstBox_Reatilers.ItemCheck
        'This works well. Allow only one checkbox checked
        If e.NewValue = CheckState.Checked Then
            Dim myEnumerator As IEnumerator
            myEnumerator = Me.chkLstBox_Reatilers.CheckedIndices.GetEnumerator()
            Dim y As Integer
            While myEnumerator.MoveNext() <> False
                y = CInt(myEnumerator.Current)
                Me.chkLstBox_Reatilers.SetItemChecked(y, False)
            End While
        End If
    End Sub

    '******************************************************************
    Private Sub frmAddRetailer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'If MessageBox.Show("Form is closing", "Form Close", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) = Windows.Forms.DialogResult.No Then
        '    e.Cancel = True
        'End If

    End Sub

    '******************************************************************
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub

    '******************************************************************
    Private Sub txtRetailerShortName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRetailerShortName.KeyPress
        Try
            'If (Not Char.IsNumber(e.KeyChar)) AndAlso Not (e.KeyChar = CChar(Keys.Back)) Then
            '    e.Handled = True
            'End If

            Dim allowed As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"
            Dim curchar As Integer = Asc(e.KeyChar)

            If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub

    '******************************************************************
    Function CheckForAlphaCharacters(ByVal StringToCheck As String) As Boolean
        Try
            'this only work if whole text is not alphabet characters
            'Dim i As Integer
            'For i = 0 To StringToCheck.Length - 1
            '    If Char.IsLetter(StringToCheck.Chars(i)) Then
            '        Return True
            '    End If
            'Next
            'Return False

            'Any character is not alphabet character
            Dim i As Integer

            For i = 0 To StringToCheck.Length - 1
                If Not Char.IsLetter(StringToCheck.Chars(i)) Then
                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
        End Try
    End Function

    '******************************************************************
    Private Sub btnFinished_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinished.Click
        Dim strTmp As String = ""
        Dim strSQL As String = ""
        Dim iRet As Integer

        If Me.rbtnDefine.Checked Then
            Dim row As DataRow
            If Not Me.txtRetailerShortName.Text.Trim.Length > 0 Then
                MessageBox.Show("Retailer Short Name aloows max 4 alphabet characters! Please enter a valid name.")
                Me.txtRetailerShortName.Focus() : Exit Sub
            End If

            strTmp = Me.txtRetailerShortName.Text.Trim.ToUpper
            Me.txtRetailerShortName.Text = strTmp

            If strTmp.Length > 4 Then
                MessageBox.Show("Retailer Short Name aloows max 4 alphabet characters! Please enter a valid name.")
                Me.txtRetailerShortName.Focus() : Exit Sub
            End If

            If Not CheckForAlphaCharacters(strTmp) Then
                MessageBox.Show("Retailer Short Name must be alphabet characters! Please enter a valid name.")
                Me.txtRetailerShortName.Focus() : Exit Sub
            End If

            For Each row In Me._dtRetailers.Rows
                If strTmp = row("RetailerShortName").Trim.ToUpper Then
                    MessageBox.Show("""" & strTmp & """ is already assigned to retailer """ & row("RetailerName1") & """. Please redefine.")
                    Me.txtRetailerShortName.Focus() : Exit Sub
                End If
            Next

            strSQL = "INSERT tdriveline_retailers (RetailerShortName,RetailerName1) VALUES ('" & strTmp & "','" & Me._strRetailerName.Replace("'", "''") & "');"
            iRet = Me._objDriveLine.InsertOrUpdateDriveLineRetailersData(strSQL)
            If iRet = 0 Then
                MessageBox.Show("Failed to save!")
            Else
                Me.lblDefinedShortName.Text = strTmp
                Me.DialogResult = DialogResult.OK
                Me.Close()
            End If

        ElseIf Me.rbtnSelect.Checked Then
            If Not Me.chkLstBox_Reatilers.CheckedItems.Count > 0 Then
                MessageBox.Show("Please select a retailer from the list.")
                Exit Sub
            End If
            If Me.chkLstBox_Reatilers.CheckedItems.Count > 1 Then
                MessageBox.Show("Please select only one retailer from the list.")
                Exit Sub
            End If

            If Me.chkLstBox_Reatilers.CheckedItems.Count = 1 Then
                Dim oIdx As Object 'row index
                Dim i As Integer
                For Each oIdx In Me.chkLstBox_Reatilers.CheckedIndices
                    strTmp = Me._dtRetailers.Rows(oIdx).Item("RetailerShortName")
                Next

                If Not strTmp.Trim.Length > 0 Then
                    MessageBox.Show("Failed to get retailer short name for your selection. See IT.")
                    Exit Sub
                End If

                'Update
                If Me._dtRetailers.Columns.Count < 3 Then
                    MessageBox.Show("No available column. See IT.")
                    Exit Sub
                Else
                    strSQL = ""
                    For i = 2 To Me._dtRetailers.Columns.Count - 1 '0 is Retailer Short Name, 1 is Retailer Name
                        Dim strColName As String = "", strName As String = ""
                        If Not IsDBNull(Me._dtRetailers.Rows(oIdx).Item(i)) Then
                            strName = Me._dtRetailers.Rows(oIdx).Item(i)
                        End If
                        strColName = Me._dtRetailers.Columns(i).ColumnName
                        If strName.Trim.Length = 0 Then
                            strSQL = "UPDATE tdriveline_retailers SET " & strColName & "='" & Me._strRetailerName.Replace("'", "''") & "'" & _
                                     " WHERE RetailerShortName='" & strTmp & "';"
                            Exit For
                        End If
                    Next
                    If Not strSQL.Trim.Length > 0 Then
                        MessageBox.Show("Failed to create SQL (no additional column). See IT.") 'no additional column or something wrong
                        Exit Sub
                    End If

                    iRet = Me._objDriveLine.InsertOrUpdateDriveLineRetailersData(strSQL)
                    If iRet = 0 Then
                        MessageBox.Show("Failed to save!")
                    Else
                        Me.lblDefinedShortName.Text = strTmp
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    End If

                End If
            End If

        End If

        '******************************************************************
    End Sub
End Class
