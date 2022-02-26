Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.WingTechATT
    Public Class frmWingTechATT_LabelInfoRemove
        Inherits System.Windows.Forms.Form


        Private _objWingTechATTLabel As PSS.Data.Buisness.WingTechATT.WingTechATT_Label
        Private _strIMEI As String = ""

#Region " Windows Form Designer generated code "
        Public Sub New(ByVal strIMEI As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objWingTechATTLabel = New PSS.Data.Buisness.WingTechATT.WingTechATT_Label()
            Me._strIMEI = strIMEI
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objWingTechATTLabel = Nothing
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
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'btnClose
            '
            Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.ForeColor = System.Drawing.Color.MediumBlue
            Me.btnClose.Location = New System.Drawing.Point(168, 59)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(120, 40)
            Me.btnClose.TabIndex = 5
            Me.btnClose.Text = "Close"
            '
            'txtIMEI
            '
            Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.Location = New System.Drawing.Point(112, 19)
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(256, 22)
            Me.txtIMEI.TabIndex = 4
            Me.txtIMEI.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(32, 19)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 24)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "IMEI:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmWingTech_LabelInfoRemove
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(400, 118)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.txtIMEI, Me.Label1})
            Me.Name = "frmWingTech_LabelInfoRemove"
            Me.Text = "frmWingTech_LabelInfoRemove"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
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
                    dt = Me._objWingTechATTLabel.getUnshippedDeviceData(strIMEI)

                    If Not dt.Rows.Count > 0 Then
                        MessageBox.Show("Not find or the device has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Found duplicate device records. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Else '=1
                        iDevice_ID = dt.Rows(0).Item("Device_ID")
                        Me._objWingTechATTLabel.RemoveLabelInfo(iDevice_ID)
                        Me.txtIMEI.Text = ""
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtIMEI_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub frmWingTechATT_LabelInfoRemove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.CenterToParent()
                PSS.Core.Highlight.SetHighLight(Me)

                Me.txtIMEI.Text = Me._strIMEI
                Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmLabeInfoRemove_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace
