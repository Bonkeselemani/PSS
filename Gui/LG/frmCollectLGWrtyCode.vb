Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.LG
    Public Class frmCollectLGWrtyCode
        Inherits System.Windows.Forms.Form

        Public _booCancel As Boolean = True
        Public _strSN As String = ""
        Public _strDateCode As String = ""
        Public _strLastDateInWarranty As String = Nothing
        Public _iWrty As Integer = -1
        Private _strIMEI As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal strIMEI As String = "")
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

            Me._strIMEI = strIMEI
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
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents grbWrtyData As System.Windows.Forms.GroupBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents txtLGWrtyDateCode As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.grbWrtyData = New System.Windows.Forms.GroupBox()
            Me.txtLGWrtyDateCode = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.grbWrtyData.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(328, 50)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(56, 20)
            Me.btnCancel.TabIndex = 2
            Me.btnCancel.Text = "Cancel"
            '
            'grbWrtyData
            '
            Me.grbWrtyData.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtLGWrtyDateCode, Me.Label10, Me.btnCancel})
            Me.grbWrtyData.Location = New System.Drawing.Point(8, 0)
            Me.grbWrtyData.Name = "grbWrtyData"
            Me.grbWrtyData.Size = New System.Drawing.Size(392, 80)
            Me.grbWrtyData.TabIndex = 1
            Me.grbWrtyData.TabStop = False
            '
            'txtLGWrtyDateCode
            '
            Me.txtLGWrtyDateCode.BackColor = System.Drawing.Color.Yellow
            Me.txtLGWrtyDateCode.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtLGWrtyDateCode.Location = New System.Drawing.Point(144, 16)
            Me.txtLGWrtyDateCode.MaxLength = 16
            Me.txtLGWrtyDateCode.Name = "txtLGWrtyDateCode"
            Me.txtLGWrtyDateCode.Size = New System.Drawing.Size(240, 27)
            Me.txtLGWrtyDateCode.TabIndex = 1
            Me.txtLGWrtyDateCode.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 19)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(128, 16)
            Me.Label10.TabIndex = 87
            Me.Label10.Text = "LG SN/Date Code :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmCollectLGWrtyCode
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(410, 87)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grbWrtyData})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmCollectLGWrtyCode"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Calculate LG Warranty"
            Me.grbWrtyData.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************************
        Private Sub frmCollectLGWrtyCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.txtLGWrtyDateCode.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmCollectLGWrtyCode_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me._booCancel = True
                Me._strSN = "" : Me._strDateCode = "" : Me._iWrty = -1 : Me._strLastDateInWarranty = Nothing

                Me.Close()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancel_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '*************************************************************************************
        Private Sub txtLGWrtyDateCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLGWrtyDateCode.KeyUp
            Dim i As Integer
            Dim objLGWrty As WarrantyClaim.LG
            Dim strDateCode As String = ""

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtLGWrtyDateCode.Text.Trim.Length = 0 Then
                        '// DO NOTHING
                    ElseIf Me.txtLGWrtyDateCode.Text.Trim.Length < 3 Then
                        MessageBox.Show("SN's length must be longer than 2 characters.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtLGWrtyDateCode.SelectAll()
                        Me.txtLGWrtyDateCode.Focus()
                    ElseIf Me._strIMEI.Trim.Length > 0 AndAlso Me.txtLGWrtyDateCode.Text.Trim = Me._strIMEI.Trim Then
                        MessageBox.Show("SN and IMEI must be different.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtLGWrtyDateCode.SelectAll()
                        Me.txtLGWrtyDateCode.Focus()
                    Else
                        strDateCode = Mid(Me.txtLGWrtyDateCode.Text.Trim, 1, 3)

                        For i = 1 To strDateCode.Trim.Length
                            If IsNumeric(Mid(strDateCode, i, 1)) = False Then
                                MessageBox.Show("The first 3 characters of SN must be numeric.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtLGWrtyDateCode.SelectAll()
                                Me.txtLGWrtyDateCode.Focus()
                                Exit Sub
                            End If
                        Next

                        'Last 2 digits is month code therefore must be in range of 1-12
                        If CInt(Mid(strDateCode, 2, 2)) < 1 Or CInt(Mid(strDateCode, 2, 2)) > 12 Then
                            MessageBox.Show("The second and third character must me in range of 1 and 12.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtLGWrtyDateCode.SelectAll()
                            Me.txtLGWrtyDateCode.Focus()
                            Exit Sub
                        End If

                        objLGWrty = New WarrantyClaim.LG()
                        Me._iWrty = objLGWrty.CalWarrantyStatus(strDateCode)

                        If Me._iWrty < 0 Then
                            MessageBox.Show("Invalid warranty result please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtLGWrtyDateCode.SelectAll()
                            Me.txtLGWrtyDateCode.Focus()
                        Else
                            Me._booCancel = False
                            Me._strSN = Me.txtLGWrtyDateCode.Text.Trim.ToUpper
                            Me._strDateCode = strDateCode
                            Me._strLastDateInWarranty = objLGWrty._strLastDateInWarranty
                            Me.Close()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtLGWrtyDateCode_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                objLGWrty = Nothing
            End Try
        End Sub

        '*************************************************************************************

    End Class
End Namespace