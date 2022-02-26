Public Class frmChangeSN
    Inherits System.Windows.Forms.Form
    Private iDevice_ID As Integer = 0
    Private strSNType As String = ""
    Private objMISC As PSS.Data.Buisness.Misc
    Private iProd_ID As Integer = 0
    Private strDevice_OldSN As String = ""
    Private iCust_ID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMISC = New PSS.Data.Buisness.Misc()
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNewSN As System.Windows.Forms.TextBox
    Friend WithEvents txtOldSN As System.Windows.Forms.TextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents RadioIMEI As System.Windows.Forms.RadioButton
    Friend WithEvents RadioESN As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDecimal As System.Windows.Forms.RadioButton
    Friend WithEvents RadioMSN As System.Windows.Forms.RadioButton
    Friend WithEvents RadioNone As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdChangeSN As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioNonCellSN As System.Windows.Forms.RadioButton
    Friend WithEvents PanelNewSN As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNewSN = New System.Windows.Forms.TextBox()
        Me.txtOldSN = New System.Windows.Forms.TextBox()
        Me.cmdChangeSN = New System.Windows.Forms.Button()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.RadioIMEI = New System.Windows.Forms.RadioButton()
        Me.RadioESN = New System.Windows.Forms.RadioButton()
        Me.RadioDecimal = New System.Windows.Forms.RadioButton()
        Me.RadioMSN = New System.Windows.Forms.RadioButton()
        Me.PanelNewSN = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioNone = New System.Windows.Forms.RadioButton()
        Me.RadioNonCellSN = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelNewSN.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(416, 40)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "CHANGE SN"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Current SN:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(176, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "New SN:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNewSN
        '
        Me.txtNewSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewSN.Location = New System.Drawing.Point(177, 93)
        Me.txtNewSN.Name = "txtNewSN"
        Me.txtNewSN.Size = New System.Drawing.Size(160, 21)
        Me.txtNewSN.TabIndex = 4
        Me.txtNewSN.Text = ""
        '
        'txtOldSN
        '
        Me.txtOldSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOldSN.Location = New System.Drawing.Point(23, 73)
        Me.txtOldSN.Name = "txtOldSN"
        Me.txtOldSN.Size = New System.Drawing.Size(160, 21)
        Me.txtOldSN.TabIndex = 5
        Me.txtOldSN.Text = ""
        '
        'cmdChangeSN
        '
        Me.cmdChangeSN.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdChangeSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdChangeSN.ForeColor = System.Drawing.Color.White
        Me.cmdChangeSN.Location = New System.Drawing.Point(170, 157)
        Me.cmdChangeSN.Name = "cmdChangeSN"
        Me.cmdChangeSN.Size = New System.Drawing.Size(176, 32)
        Me.cmdChangeSN.TabIndex = 6
        Me.cmdChangeSN.Text = "CHANGE SN"
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(199, 29)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(208, 83)
        Me.lblMessage.TabIndex = 7
        '
        'RadioIMEI
        '
        Me.RadioIMEI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioIMEI.Location = New System.Drawing.Point(21, 24)
        Me.RadioIMEI.Name = "RadioIMEI"
        Me.RadioIMEI.Size = New System.Drawing.Size(81, 24)
        Me.RadioIMEI.TabIndex = 8
        Me.RadioIMEI.Text = "IMEI"
        '
        'RadioESN
        '
        Me.RadioESN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioESN.Location = New System.Drawing.Point(21, 96)
        Me.RadioESN.Name = "RadioESN"
        Me.RadioESN.Size = New System.Drawing.Size(81, 24)
        Me.RadioESN.TabIndex = 9
        Me.RadioESN.Text = "ESN/CSN"
        '
        'RadioDecimal
        '
        Me.RadioDecimal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioDecimal.Location = New System.Drawing.Point(21, 72)
        Me.RadioDecimal.Name = "RadioDecimal"
        Me.RadioDecimal.Size = New System.Drawing.Size(81, 24)
        Me.RadioDecimal.TabIndex = 10
        Me.RadioDecimal.Text = "Decimal"
        '
        'RadioMSN
        '
        Me.RadioMSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioMSN.Location = New System.Drawing.Point(21, 48)
        Me.RadioMSN.Name = "RadioMSN"
        Me.RadioMSN.Size = New System.Drawing.Size(81, 24)
        Me.RadioMSN.TabIndex = 11
        Me.RadioMSN.Text = "MSN"
        '
        'PanelNewSN
        '
        Me.PanelNewSN.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelNewSN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelNewSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.Label5, Me.txtNewSN, Me.Label4, Me.cmdChangeSN})
        Me.PanelNewSN.Location = New System.Drawing.Point(0, 160)
        Me.PanelNewSN.Name = "PanelNewSN"
        Me.PanelNewSN.Size = New System.Drawing.Size(416, 240)
        Me.PanelNewSN.TabIndex = 12
        Me.PanelNewSN.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioNone, Me.RadioMSN, Me.RadioIMEI, Me.RadioNonCellSN, Me.RadioESN, Me.RadioDecimal})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(144, 176)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SN Type"
        '
        'RadioNone
        '
        Me.RadioNone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioNone.Location = New System.Drawing.Point(21, 144)
        Me.RadioNone.Name = "RadioNone"
        Me.RadioNone.Size = New System.Drawing.Size(81, 24)
        Me.RadioNone.TabIndex = 12
        Me.RadioNone.Text = "NONE"
        '
        'RadioNonCellSN
        '
        Me.RadioNonCellSN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioNonCellSN.Location = New System.Drawing.Point(21, 120)
        Me.RadioNonCellSN.Name = "RadioNonCellSN"
        Me.RadioNonCellSN.Size = New System.Drawing.Size(115, 24)
        Me.RadioNonCellSN.TabIndex = 13
        Me.RadioNonCellSN.Text = "Non-Cellular SN"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(292, 40)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "STEP 2: Choose SN Type and scan in the New SN and Click the button to change."
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.lblMessage, Me.txtOldSN, Me.Label3})
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(416, 120)
        Me.Panel2.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(5, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(187, 33)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "STEP 1: Scan in the Current SN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmChangeSN
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(440, 422)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2, Me.PanelNewSN, Me.Label1})
        Me.Name = "frmChangeSN"
        Me.Text = "Change SN"
        Me.PanelNewSN.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    
    Private Sub txtOldSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOldSN.KeyUp

        If e.KeyValue = 13 Then
            
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Dim strModel As String = ""
            Dim strDateRec As String = ""
            Dim strMessage As String = ""
            Dim strCust As String = ""


            Try
                ClearControls()

                dt1 = objMISC.GetDeviceInfo(Trim(Me.txtOldSN.Text))
                If dt1.Rows.Count = 0 Then
                    Throw New Exception("Device not found.")
                End If

                For Each R1 In dt1.Rows
                    iDevice_ID = R1("Device_ID")
                    strModel = Trim(R1("Model_Desc"))
                    strDateRec = Trim(R1("Device_DateRec"))
                    strCust = Trim(R1("Cust_name1"))
                    iCust_ID = R1("Cust_ID")
                    iProd_ID = R1("Prod_ID")
                    If Not IsDBNull(R1("Device_OldSN")) Then
                        strDevice_OldSN = R1("Device_OldSN")
                    End If
                    Exit For
                Next R1

                strMessage = "Device_ID: " & iDevice_ID & Environment.NewLine
                strMessage &= "Customer: " & strCust & Environment.NewLine
                strMessage &= "Model: " & strModel & Environment.NewLine
                strMessage &= "Rcvd. Date: " & strDateRec & Environment.NewLine
                strMessage &= "Old SN: " & strDevice_OldSN
                Me.lblMessage.Text = strMessage

                'Set Vars
                Me.RadioNone.Checked = True
                strSNType = "NONE"

                Me.PanelNewSN.Visible = True
                Me.txtNewSN.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Current SN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End If
    End Sub

    Private Function MessageConfirmation(ByVal strSNType As String)
        Return MessageBox.Show("Are you sure the New SN is of type '" & strSNType & "'?", "Confirm New SN Type", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
    End Function

    Private Sub RadioIMEI_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioIMEI.CheckedChanged
        strSNType = "IMEI"
        Me.txtNewSN.Focus()
    End Sub

    Private Sub RadioMSN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioMSN.CheckedChanged
        strSNType = "MSN"
        Me.txtNewSN.Focus()
    End Sub

    Private Sub RadioDecimal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioDecimal.CheckedChanged
        strSNType = "Decimal"
        Me.txtNewSN.Focus()
    End Sub

    Private Sub RadioESN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioESN.CheckedChanged
        strSNType = "ESN"
        Me.txtNewSN.Focus()
    End Sub

    Private Sub RadioNonCellSN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioNonCellSN.CheckedChanged
        strSNType = "Non-Cellular SN"
        Me.txtNewSN.Focus()
    End Sub

    Private Sub RadioNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioNone.CheckedChanged
        strSNType = "NONE"
        Me.txtNewSN.Focus()
    End Sub

    Private Sub cmdChangeSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChangeSN.Click
        Dim i As Integer = 0
        Dim booNewSNExistedInWIP As Boolean = False

        Try
            Me.cmdChangeSN.Enabled = False
            If Me.iDevice_ID = 0 Then
                MessageBox.Show("Please input the 'Current SN'.", "Device_ID = 0. Device not Scanned.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtOldSN.Focus()
                Exit Sub
            End If
            If Trim(strSNType) = "" Then
                MessageBox.Show("Please choose a SN Type.", "SN Type Empty", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            ElseIf Trim(strSNType) = "NONE" Then
                MessageBox.Show("Please choose a SN Type.", "SN Type = NONE", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            If iProd_ID = 2 Then
                If Trim(strSNType) = "Non-Cellular SN" Then
                    MessageBox.Show("This is a Cell Phone. But you have selected 'Non-Cellular SN' for SN Type.", "SN Type Should not be Non-Cellular SN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            Else
                If Trim(strSNType) <> "Non-Cellular SN" Then
                    MessageBox.Show("This is not a Cell Phone. You must select 'Non-Cellular SN' for SN Type.", "SN Type Should be Non-Cellular SN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
            End If

            If Trim(Me.txtNewSN.Text) = "" Then
                MessageBox.Show("Please input the 'New SN'.", "New SN Empty", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtNewSN.Focus()
                Exit Sub
            End If
            If UCase(Trim(Me.txtOldSN.Text)) = UCase(Trim(Me.txtNewSN.Text)) Then
                MessageBox.Show("'Current SN' and 'New SN' are same.", "'Current SN' and 'New SN' are same", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtNewSN.Focus()
                Exit Sub
            End If

            If strSNType = "Decimal" Or strSNType = "IMEI" Then
                If Not IsNumeric(Trim(Me.txtNewSN.Text)) Then
                    MessageBox.Show("'New SN' must be numeric if 'SN Type' is 'IMEI' or 'Decimal'.", "'Current SN' and 'New SN' must be numeric.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtNewSN.Focus()
                    Exit Sub
                End If
                If strSNType = "IMEI" Then
                    If Len(Trim(Me.txtNewSN.Text)) <> 15 Then
                        MessageBox.Show("'New SN' must be 15 digit long becuase it is an IMEI.", "New SN must be 15 digit long for IMEI ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtNewSN.Focus()
                        Exit Sub
                    End If
                End If
            ElseIf strSNType = "MSN" Or strSNType = "ESN" Then
                If IsNumeric(Trim(Me.txtNewSN.Text)) Then
                    MessageBox.Show("'New SN' must not be numeric if 'SN Type' is 'MSN' or 'ESN'.", "New SN must be Alpha-numeric for MSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtNewSN.Focus()
                    Exit Sub
                End If
            End If

            If Len(Trim(Me.txtOldSN.Text)) <> Len(Trim(Me.txtNewSN.Text)) Then
                If MessageBox.Show("Length of 'New SN' is not same as that of 'Current SN'. Are you sure you want to continue?", "Current and New SN Length", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.txtNewSN.Focus()
                    Exit Sub
                End If
            End If
            If IsNumeric(Trim(Me.txtOldSN.Text)) And Not IsNumeric(Trim(Me.txtNewSN.Text)) Then
                If MessageBox.Show("'Current SN' is numeric and 'New SN' is not. Are you sure you want to continue?", "Current and New SN Alpha Numeric Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.txtNewSN.Focus()
                    Exit Sub
                End If
            End If
            If Not IsNumeric(Trim(Me.txtOldSN.Text)) And IsNumeric(Trim(Me.txtNewSN.Text)) Then
                If MessageBox.Show("'Current SN' is not numeric and 'New SN' is. Are you sure you want to continue?", "Current and New SN Alpha Numeric Validation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Me.txtNewSN.Focus()
                    Exit Sub
                End If
            End If

            If MessageConfirmation(strSNType) = DialogResult.Yes Then
                '***************************************************
                'Check if New SN already existed with open ship date
                '***************************************************
                booNewSNExistedInWIP = Me.objMISC.CheckOpenSN(Me.iCust_ID, Trim(Me.txtNewSN.Text))

                If booNewSNExistedInWIP = True Then
                    MessageBox.Show("'New SN' already exists in WIP.", "New SN must be Alpha-numeric for MSN", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtNewSN.Focus()
                    Exit Sub
                End If

                '**********************
                'change SN
                '**********************
                i = Me.objMISC.ChangeSN(iCust_ID, iDevice_ID, Trim(Me.txtNewSN.Text), strSNType, strDevice_OldSN)
                '**********************
                'confirm message
                '**********************
                MessageBox.Show("SN is changed successfully.", "Change SN", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '**********************
                ClearControls()
                Me.txtOldSN.Text = ""
            Else
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Change SN Button Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub ClearControls()
        'Controls
        Me.lblMessage.Text = ""
        Me.txtNewSN.Text = ""
        Me.RadioNone.Checked = True
        Me.cmdChangeSN.Enabled = False
        Me.PanelNewSN.Visible = False
        Me.txtOldSN.Focus()

        'Global Vars.
        Me.strSNType = "NONE"
        iDevice_ID = 0
        iProd_ID = 0
        strDevice_OldSN = ""
        iCust_ID = 0
    End Sub

    Protected Overrides Sub Finalize()
        objMISC = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub txtNewSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewSN.TextChanged
        If Len(Trim(Me.txtNewSN.Text)) > 0 Then
            Me.cmdChangeSN.Enabled = True
        Else
            Me.cmdChangeSN.Enabled = False
        End If
    End Sub

    Private Sub frmChangeSN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtOldSN.Focus()
    End Sub

    Private Sub txtOldSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOldSN.TextChanged
        Me.ClearControls()
    End Sub
End Class
