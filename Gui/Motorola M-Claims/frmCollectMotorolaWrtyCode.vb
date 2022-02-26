Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Motorola

    Public Class frmCollectMotorolaWrtyCode
        Inherits System.Windows.Forms.Form

        Public _booCancel As Boolean = True
        Public _strDateCode As String = ""
        Public _strMSN As String = ""
        Public _strAPC As String = ""
        Public _strLastDateInWarranty As String = Nothing
        Public _iWrty As Integer = -1
        Private _strIMEICSNDec As String = ""
        Private _iModelID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strIMEICSNDec As String, ByVal iModelID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strIMEICSNDec = strIMEICSNDec
            _iModelID = iModelID
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
        Friend WithEvents grbWrtyData As System.Windows.Forms.GroupBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents txtMSN As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grbWrtyData = New System.Windows.Forms.GroupBox()
            Me.txtMSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.grbWrtyData.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbWrtyData
            '
            Me.grbWrtyData.BackColor = System.Drawing.Color.SteelBlue
            Me.grbWrtyData.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMSN, Me.Label10, Me.btnCancel})
            Me.grbWrtyData.Location = New System.Drawing.Point(16, 8)
            Me.grbWrtyData.Name = "grbWrtyData"
            Me.grbWrtyData.Size = New System.Drawing.Size(368, 80)
            Me.grbWrtyData.TabIndex = 2
            Me.grbWrtyData.TabStop = False
            '
            'txtMSN
            '
            Me.txtMSN.BackColor = System.Drawing.Color.Yellow
            Me.txtMSN.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMSN.Location = New System.Drawing.Point(120, 16)
            Me.txtMSN.MaxLength = 16
            Me.txtMSN.Name = "txtMSN"
            Me.txtMSN.Size = New System.Drawing.Size(240, 27)
            Me.txtMSN.TabIndex = 1
            Me.txtMSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 19)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(104, 16)
            Me.Label10.TabIndex = 87
            Me.Label10.Text = "Motorola MSN :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(304, 50)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(56, 20)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            '
            'frmCollectMotorolaWrtyCode
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(392, 101)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grbWrtyData})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmCollectMotorolaWrtyCode"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Calculate Motorola Warranty"
            Me.grbWrtyData.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************************
        Private Sub frmCollectMotorolaWrtyCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim objMClaim As PSS.Data.Buisness.WarrantyClaim.MClaim

            Try
                objMClaim = New PSS.Data.Buisness.WarrantyClaim.MClaim()
                '_strAPC = objMClaim.GetAPCCode(Me._iModelID)

                Me.txtMSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmCollectMotorolaWrtyCode_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me._booCancel = True
                Me._strMSN = "" : Me._iWrty = -1 : Me._strLastDateInWarranty = Nothing

                Me.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*************************************************************************************
        Private Sub txtMSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMSN.KeyUp
            Dim i As Integer
            Dim objMClaim As PSS.Data.Buisness.WarrantyClaim.MClaim

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtMSN.Text.Trim.Length = 0 Then
                        '// DO NOTHING
                    ElseIf Me.txtMSN.Text.Trim.Length <> 10 AndAlso Me.txtMSN.Text.Trim.Length <> 11 Then
                        MessageBox.Show("Length of MSN must be longer than 10 or 11 characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtMSN.SelectAll()
                        Me.txtMSN.Focus()
                    ElseIf Me._strIMEICSNDec.Trim.Length > 0 AndAlso Me.txtMSN.Text.Trim = Me._strIMEICSNDec.Trim Then
                        MessageBox.Show("MSN and IMEI must be different.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtMSN.SelectAll()
                        Me.txtMSN.Focus()
                        'ElseIf Me._strAPC.Trim.Length = 0 Then
                        '    MessageBox.Show("APC code is not define for this model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.txtMSN.SelectAll()
                        '    Me.txtMSN.Focus()
                        'ElseIf Me._strAPC.Trim.ToLower <> Microsoft.VisualBasic.Left(Me.txtMSN.Text.Trim, 3).ToLower Then
                        '    MessageBox.Show("Invalid MSN. First 3 characters must match APC code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.txtMSN.SelectAll()
                        '    Me.txtMSN.Focus()
                    ElseIf Char.IsLetter(Mid(Me.txtMSN.Text.Trim, 1, 1)) = False Then
                        MessageBox.Show("Invalid MSN. First character must be leter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtMSN.SelectAll()
                        Me.txtMSN.Focus()
                    ElseIf Char.IsNumber(Mid(Me.txtMSN.Text.Trim, 2, 1)) = False Or Char.IsNumber(Mid(Me.txtMSN.Text.Trim, 3, 1)) = False Then
                        MessageBox.Show("Invalid MSN. Second and third character must be digit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtMSN.SelectAll()
                        Me.txtMSN.Focus()
                    ElseIf Char.IsLetter(Mid(Me.txtMSN.Text.Trim, 5, 1)) = False Or Char.IsLetter(Mid(Me.txtMSN.Text.Trim, 6, 1)) = False Then
                        MessageBox.Show("Invalid MSN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtMSN.SelectAll()
                        Me.txtMSN.Focus()
                    ElseIf Me.txtMSN.Text.Trim.Length = 11 AndAlso Char.IsLetter(Mid(Me.txtMSN.Text.Trim, 11, 1)) = False Then
                        MessageBox.Show("Invalid MSN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtMSN.SelectAll()
                        Me.txtMSN.Focus()
                    Else
                        objMClaim = New PSS.Data.Buisness.WarrantyClaim.MClaim()
                        Me._iWrty = objMClaim.CalWarrantyStatus(Me.txtMSN.Text.Trim.ToUpper, _strLastDateInWarranty)

                        If Me._iWrty < 0 Then
                            MessageBox.Show("Invalid warranty result please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtMSN.SelectAll()
                            Me.txtMSN.Focus()
                        Else
                            Me._booCancel = False
                            Me._strMSN = Me.txtMSN.Text.Trim.ToUpper
                            _strDateCode = Mid(Me.txtMSN.Text.Trim, 5, 1) & Mid(Me.txtMSN.Text.Trim, 6, 1).ToUpper
                            If Me.txtMSN.Text.Trim.Length > 10 Then _strDateCode &= Mid(Me.txtMSN.Text.Trim, 11, 1).ToUpper
                            _strAPC = Microsoft.VisualBasic.Left(Me.txtMSN.Text.Trim.ToUpper, 3).ToUpper
                            Me.Close()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtMotorolaWrtyDateCode_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                objMClaim = Nothing
            End Try
        End Sub

        '*************************************************************************************


    End Class
End Namespace