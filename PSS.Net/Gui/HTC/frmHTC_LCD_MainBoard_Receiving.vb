Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Public Class frmHTC_LCD_MainBoard_Receiving
    Inherits System.Windows.Forms.Form

    Private _objHTC As HTC

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New HTC()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objHTC = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents cmbPartType As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblIMEI As System.Windows.Forms.Label
    Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmbPartType = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblIMEI = New System.Windows.Forms.Label()
        Me.txtIMEI = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cmbPartType
        '
        Me.cmbPartType.AutoComplete = True
        Me.cmbPartType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbPartType.DropDownWidth = 256
        Me.cmbPartType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPartType.ForeColor = System.Drawing.Color.Black
        Me.cmbPartType.Items.AddRange(New Object() {"LCD", "Main Board"})
        Me.cmbPartType.Location = New System.Drawing.Point(24, 32)
        Me.cmbPartType.MaxDropDownItems = 30
        Me.cmbPartType.Name = "cmbPartType"
        Me.cmbPartType.Size = New System.Drawing.Size(216, 21)
        Me.cmbPartType.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(24, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 16)
        Me.Label5.TabIndex = 85
        Me.Label5.Text = "Part Type:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSN
        '
        Me.lblSN.BackColor = System.Drawing.Color.Transparent
        Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.ForeColor = System.Drawing.Color.White
        Me.lblSN.Location = New System.Drawing.Point(24, 72)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(168, 16)
        Me.lblSN.TabIndex = 88
        Me.lblSN.Text = "SN:"
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSN
        '
        Me.txtSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.Location = New System.Drawing.Point(24, 88)
        Me.txtSN.MaxLength = 15
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(216, 22)
        Me.txtSN.TabIndex = 2
        Me.txtSN.Text = ""
        '
        'lblIMEI
        '
        Me.lblIMEI.BackColor = System.Drawing.Color.Transparent
        Me.lblIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIMEI.ForeColor = System.Drawing.Color.White
        Me.lblIMEI.Location = New System.Drawing.Point(24, 120)
        Me.lblIMEI.Name = "lblIMEI"
        Me.lblIMEI.Size = New System.Drawing.Size(168, 16)
        Me.lblIMEI.TabIndex = 90
        Me.lblIMEI.Text = "IMEI:"
        Me.lblIMEI.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'txtIMEI
        '
        Me.txtIMEI.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMEI.Location = New System.Drawing.Point(24, 136)
        Me.txtIMEI.MaxLength = 15
        Me.txtIMEI.Name = "txtIMEI"
        Me.txtIMEI.Size = New System.Drawing.Size(216, 22)
        Me.txtIMEI.TabIndex = 3
        Me.txtIMEI.Text = ""
        '
        'frmHTC_LCD_MainBoard_Receiving
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(672, 565)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblIMEI, Me.txtIMEI, Me.lblSN, Me.txtSN, Me.cmbPartType, Me.Label5})
        Me.Name = "frmHTC_LCD_MainBoard_Receiving"
        Me.Text = "frmHTC_LCD_MainBoard_Input"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmHTC_LCD_MainBoard_Input_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)
            Me.cmbPartType.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.cmbPartType.Focus()
        End Try
    End Sub

    '******************************************************************
    Private Sub cmbPartType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPartType.SelectedIndexChanged
        If Me.cmbPartType.SelectedIndex = 0 Then
            Me.txtSN.Text = ""
            Me.txtIMEI.Text = ""
            Me.txtIMEI.Visible = False
            Me.lblIMEI.Visible = False
        Else
            Me.txtSN.Text = ""
            Me.txtIMEI.Text = ""
            Me.txtIMEI.Visible = True
            Me.lblIMEI.Visible = True
        End If

        Me.txtSN.Focus()
    End Sub

    '******************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Dim dt As DataTable
        Dim i As Integer = 0
        Try
            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me.txtSN.Text.Trim.Length = 15 Then
                    MessageBox.Show("SN can not have length of 15 characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSN.SelectAll()
                Else
                    If Me.cmbPartType.SelectedIndex = 1 Then
                        Me.txtIMEI.Focus()
                    Else
                        'Check for duplicate
                        dt = Me._objHTC.GetNewSNAndIMEI(Me.txtSN.Text.Trim.ToUpper)
                        If dt.Rows.Count > 0 Then
                            MessageBox.Show("This SN is already existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtSN.SelectAll()
                        Else
                            'Insert SN into system
                            i = Me._objHTC.InsertLCD_MainBoard(ApplicationUser.IDuser, txtSN.Text.Trim.ToUpper, )
                            If i = 0 Then
                                MessageBox.Show("System have failed to receive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Else
                                Me.txtSN.Text = ""
                                Me.txtSN.Focus()
                            End If
                        End If
                    End If 'LCD or Main Board
                End If 'Textbox is not empty
            End If  'Enter key is enter
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            If e.KeyValue = 13 Then
                If Me.txtSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please scan SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.Text = ""
                    Me.txtSN.Focus()
                ElseIf Me.txtSN.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me.txtIMEI.Text.Trim.Length <> 15 Then
                    MessageBox.Show("IMEI number must be 15 digits number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll()
                Else
                    For i = 1 To Me.txtIMEI.Text.Trim.Length
                        If Char.IsLetterOrDigit(Mid(Me.txtIMEI.Text.Trim, i)) = False Then
                            MessageBox.Show("IMEI number must be 15 digits number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll()
                            Exit Sub
                        End If
                    Next i

                    'Check for duplicate
                    dt = Me._objHTC.GetNewSNAndIMEI(Me.txtSN.Text.Trim.ToUpper)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("This SN/IMEI is already existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll()
                    Else
                        Me.Enabled = False

                        'Insert SN and IMEI into system
                        i = Me._objHTC.InsertLCD_MainBoard(ApplicationUser.IDuser, txtSN.Text.Trim.ToUpper, Me.txtIMEI.Text.Trim.ToUpper)
                        If i = 0 Then
                            MessageBox.Show("System have failed to receive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Else
                            Me.txtSN.Text = ""
                            Me.txtIMEI.Text = ""
                            Me.txtSN.Focus()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Generic.DisposeDT(dt)
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************


End Class
