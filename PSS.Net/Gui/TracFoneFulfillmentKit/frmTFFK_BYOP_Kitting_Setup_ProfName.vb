
Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_Kitting_Setup_ProfName
        Inherits System.Windows.Forms.Form

        Private _objBYOP_Kitting As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting

        Private _strSetupProfileName As String = ""
        Private _strPostFix As String = ""
        Private _strSetupProfileName_Final As String = ""
        Private _bCancelled As Boolean = False
        Private _iMaxNameLength As Integer = 50


#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strSetupProfileName As String, ByVal strPostFix As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objBYOP_Kitting = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_BYOP_Kitting()
            Me._strSetupProfileName = strSetupProfileName
            Me._strPostFix = strPostFix
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objBYOP_Kitting = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents lbllblSystemDefaultName As System.Windows.Forms.Label
        Friend WithEvents lblSystemDefaultName As System.Windows.Forms.Label
        Friend WithEvents lblFinal As System.Windows.Forms.Label
        Friend WithEvents lbllblFinal As System.Windows.Forms.Label
        Friend WithEvents lblUserDefined As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents txtUserDefined As System.Windows.Forms.TextBox
        Friend WithEvents lblPostFix As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lbllblSystemDefaultName = New System.Windows.Forms.Label()
            Me.lblSystemDefaultName = New System.Windows.Forms.Label()
            Me.lblFinal = New System.Windows.Forms.Label()
            Me.lbllblFinal = New System.Windows.Forms.Label()
            Me.lblUserDefined = New System.Windows.Forms.Label()
            Me.txtUserDefined = New System.Windows.Forms.TextBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnOk = New System.Windows.Forms.Button()
            Me.lblPostFix = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lbllblSystemDefaultName
            '
            Me.lbllblSystemDefaultName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblSystemDefaultName.Location = New System.Drawing.Point(16, 8)
            Me.lbllblSystemDefaultName.Name = "lbllblSystemDefaultName"
            Me.lbllblSystemDefaultName.Size = New System.Drawing.Size(160, 32)
            Me.lbllblSystemDefaultName.TabIndex = 0
            Me.lbllblSystemDefaultName.Text = "Profile Name:"
            Me.lbllblSystemDefaultName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSystemDefaultName
            '
            Me.lblSystemDefaultName.ForeColor = System.Drawing.Color.MediumBlue
            Me.lblSystemDefaultName.Location = New System.Drawing.Point(184, 8)
            Me.lblSystemDefaultName.Name = "lblSystemDefaultName"
            Me.lblSystemDefaultName.Size = New System.Drawing.Size(376, 32)
            Me.lblSystemDefaultName.TabIndex = 1
            Me.lblSystemDefaultName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFinal
            '
            Me.lblFinal.ForeColor = System.Drawing.Color.Red
            Me.lblFinal.Location = New System.Drawing.Point(184, 80)
            Me.lblFinal.Name = "lblFinal"
            Me.lblFinal.Size = New System.Drawing.Size(376, 32)
            Me.lblFinal.TabIndex = 3
            Me.lblFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lbllblFinal
            '
            Me.lbllblFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lbllblFinal.Location = New System.Drawing.Point(16, 80)
            Me.lbllblFinal.Name = "lbllblFinal"
            Me.lbllblFinal.Size = New System.Drawing.Size(160, 32)
            Me.lbllblFinal.TabIndex = 2
            Me.lbllblFinal.Text = "Profile Name (Final):"
            Me.lbllblFinal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblUserDefined
            '
            Me.lblUserDefined.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserDefined.Location = New System.Drawing.Point(16, 40)
            Me.lblUserDefined.Name = "lblUserDefined"
            Me.lblUserDefined.Size = New System.Drawing.Size(160, 32)
            Me.lblUserDefined.TabIndex = 4
            Me.lblUserDefined.Text = "Profile Name (Reset):"
            Me.lblUserDefined.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtUserDefined
            '
            Me.txtUserDefined.Location = New System.Drawing.Point(184, 48)
            Me.txtUserDefined.MaxLength = 50
            Me.txtUserDefined.Name = "txtUserDefined"
            Me.txtUserDefined.Size = New System.Drawing.Size(336, 23)
            Me.txtUserDefined.TabIndex = 5
            Me.txtUserDefined.Text = ""
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.Location = New System.Drawing.Point(248, 120)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(112, 48)
            Me.btnCancel.TabIndex = 197
            Me.btnCancel.Text = "Cancel"
            '
            'btnOk
            '
            Me.btnOk.BackColor = System.Drawing.Color.SteelBlue
            Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOk.Location = New System.Drawing.Point(376, 120)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(160, 48)
            Me.btnOk.TabIndex = 196
            Me.btnOk.Text = "OK"
            '
            'lblPostFix
            '
            Me.lblPostFix.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPostFix.Location = New System.Drawing.Point(520, 48)
            Me.lblPostFix.Name = "lblPostFix"
            Me.lblPostFix.Size = New System.Drawing.Size(88, 24)
            Me.lblPostFix.TabIndex = 198
            Me.lblPostFix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmTFFK_BYOP_Kitting_Setup_ProfName
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 16)
            Me.ClientSize = New System.Drawing.Size(608, 182)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPostFix, Me.btnCancel, Me.btnOk, Me.txtUserDefined, Me.lblUserDefined, Me.lblFinal, Me.lbllblFinal, Me.lblSystemDefaultName, Me.lbllblSystemDefaultName})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmTFFK_BYOP_Kitting_Setup_ProfName"
            Me.Text = "Define Setup Profile Name"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public ReadOnly Property getSetupProfileName_Final() As String
            Get
                Return Me._strSetupProfileName_Final
            End Get
        End Property

        Public ReadOnly Property bIsCancelled() As Boolean
            Get
                Return Me._bCancelled
            End Get
        End Property

        Private Sub frmTFFK_BYOP_Kitting_Setup_ProfName_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.CenterToScreen()
                PSS.Core.Highlight.SetHighLight(Me)

                Me.btnCancel.Visible = False 'no need this button

                Me.lblPostFix.Text = Me._strPostFix
                Me.lblFinal.Text = Me._strSetupProfileName.Trim
                Me.lblSystemDefaultName.Text = Me._strSetupProfileName.Trim

                Me.txtUserDefined.MaxLength = Me._iMaxNameLength - Me._strPostFix.Length

                Me.txtUserDefined.Text = ""
                Me.ActiveControl = Me.txtUserDefined : Me.txtUserDefined.SelectAll() : Me.txtUserDefined.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  frmTFFK_BYOP_Kitting_Setup_ProfName_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtUserDefined_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUserDefined.KeyUp
            Me.lblFinal.Text = Me.txtUserDefined.Text & Me.lblPostFix.Text
            If Me.txtUserDefined.Text.Trim.Length = 0 Then Me.lblFinal.Text = Me.lblSystemDefaultName.text
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me._bCancelled = True
            Me.Close()
        End Sub

        Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOk.Click
            Try
                Dim regText As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9_\- ]+$")

                If Me.txtUserDefined.Text.Trim.Length > 0 AndAlso Not regText.IsMatch(Me.txtUserDefined.Text) Then
                    MessageBox.Show("Invalid character(s) in Profile Name (Reset).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If Me.lblFinal.Text.Trim.Length = 0 Then Me.lblFinal.Text = Me.lblSystemDefaultName.Text
                    Me._strSetupProfileName_Final = Me.lblFinal.Text.Trim
                    Me.Close()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnOk_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
