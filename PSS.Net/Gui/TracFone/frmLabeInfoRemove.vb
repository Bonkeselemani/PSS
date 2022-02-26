Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmLabeInfoRemove
        Inherits System.Windows.Forms.Form

        Private _objTracLabel As PSS.Data.Buisness.TracFone.Label


#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTracLabel = New PSS.Data.Buisness.TracFone.Label()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTracLabel = Nothing
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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents btnRemove As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.btnRemove = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Name = "Label1"
            Me.Label1.TabIndex = 0
            '
            'txtIMEI
            '
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.TabIndex = 0
            Me.txtIMEI.Text = ""
            '
            'btnRemove
            '
            Me.btnRemove.Name = "btnRemove"
            Me.btnRemove.TabIndex = 0
            '
            'btnClose
            '
            Me.btnClose.Name = "btnClose"
            Me.btnClose.TabIndex = 0
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(24, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 40)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Label2"
            '
            'frmLabeInfoRemove
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(472, 118)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2})
            Me.Name = "frmLabeInfoRemove"
            Me.Text = "Remove SN/Date Code"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmLabeInfoRemove_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.CenterToParent()
                PSS.Core.Highlight.SetHighLight(Me)

                Me.txtIMEI.Text = ""
                Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmLabeInfoRemove_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemove.Click
            'Dim strIMEI As String = ""
            'Dim dt As DataTable
            'Dim iDevice_ID As Integer = 0

            'Try
            '    If Not Me.txtIMEI.Text.Trim.Length > 0 Then Exit Sub

            '    strIMEI = Me.txtIMEI.Text.Trim
            '    dt = Me._objTracLabel.getUnshippedDeviceData(strIMEI)

            '    If Not dt.Rows.Count > 0 Then
            '        MessageBox.Show("Not find or the device has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
            '    ElseIf dt.Rows.Count > 1 Then
            '        MessageBox.Show("Found duplicate device records. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
            '    Else '=1
            '        iDevice_ID = dt.Rows(0).Item("Device_ID")
            '        Me._objTracLabel.RemoveLabelInfo(iDevice_ID)
            '        Me.txtIMEI.Text = ""
            '        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
            '    End If

            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, "btnRemove_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
        End Sub

        Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub

        Private Sub txtIMEI_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyUp
            Dim strIMEI As String = ""
            Dim dt As DataTable
            Dim iDevice_ID As Integer = 0

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtIMEI.Text.Trim.Length > 0 Then
                    ' Me.btnRemove.Focus()
                    strIMEI = Me.txtIMEI.Text.Trim
                    dt = Me._objTracLabel.getUnshippedDeviceData(strIMEI)

                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show("Not find or the device has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Found duplicate device records. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Else '=1
                        iDevice_ID = dt.Rows(0).Item("Device_ID")
                        Me._objTracLabel.RemoveLabelInfo(iDevice_ID)
                        Me.txtIMEI.Text = ""
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
    End Class
End Namespace
