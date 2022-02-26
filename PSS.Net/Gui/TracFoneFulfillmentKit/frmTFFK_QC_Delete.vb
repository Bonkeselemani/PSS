Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_QC_Delete
        Inherits System.Windows.Forms.Form

        Private _objTFFK_QC As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_QC

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objTFFK_QC = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_QC()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objTFFK_QC = Nothing
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
        Friend WithEvents lblJobNo As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents txtJobNo As System.Windows.Forms.TextBox
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnClose As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblJobNo = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.txtJobNo = New System.Windows.Forms.TextBox()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblJobNo
            '
            Me.lblJobNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblJobNo.Location = New System.Drawing.Point(56, 40)
            Me.lblJobNo.Name = "lblJobNo"
            Me.lblJobNo.Size = New System.Drawing.Size(176, 23)
            Me.lblJobNo.TabIndex = 161
            Me.lblJobNo.Text = "Job Number"
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(56, 120)
            Me.txtSN.MaxLength = 50
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(200, 22)
            Me.txtSN.TabIndex = 1
            Me.txtSN.Text = ""
            '
            'lblSN
            '
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.Location = New System.Drawing.Point(56, 104)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(176, 23)
            Me.lblSN.TabIndex = 162
            Me.lblSN.Text = "Serial Number"
            '
            'txtJobNo
            '
            Me.txtJobNo.Location = New System.Drawing.Point(56, 64)
            Me.txtJobNo.MaxLength = 50
            Me.txtJobNo.Name = "txtJobNo"
            Me.txtJobNo.Size = New System.Drawing.Size(200, 22)
            Me.txtJobNo.TabIndex = 0
            Me.txtJobNo.Text = ""
            '
            'btnDelete
            '
            Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelete.Location = New System.Drawing.Point(48, 176)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(104, 40)
            Me.btnDelete.TabIndex = 2
            Me.btnDelete.Text = "Remove"
            '
            'btnClose
            '
            Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClose.Location = New System.Drawing.Point(160, 176)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(104, 40)
            Me.btnClose.TabIndex = 3
            Me.btnClose.Text = "Close"
            '
            'frmTFFK_QC_Delete
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
            Me.BackColor = System.Drawing.Color.Lavender
            Me.ClientSize = New System.Drawing.Size(336, 286)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClose, Me.btnDelete, Me.lblJobNo, Me.txtSN, Me.lblSN, Me.txtJobNo})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmTFFK_QC_Delete"
            Me.Text = "Remove Serial Number within Job"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmTFFK_QC_Delete_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.CenterToParent()
                PSS.Core.Highlight.SetHighLight(Me)

                Me.txtJobNo.Text = "" : Me.txtSN.Text = ""
                Me.txtJobNo.SelectAll() : Me.txtJobNo.Focus()


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_QC_Delete_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim strJobNo As String = ""
            Dim strSN As String = ""
            Dim iJob_ID As Integer = 0
            Dim strQC_SN_IDs As String = ""

            Try
                strJobNo = Me.txtJobNo.Text.Trim
                strSN = Me.txtSN.Text.Trim

                If strJobNo.Length = 0 Then
                    MessageBox.Show("Enter a Job Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtJobNo.SelectAll() : Me.txtJobNo.Focus()
                ElseIf strSN.Length = 0 Then
                    MessageBox.Show("Enter a Serial Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                Else
                    iJob_ID = Me._objTFFK_QC.GetTFFK_QC_JobID(strJobNo)
                    If Not iJob_ID > 0 Then
                        MessageBox.Show("Can't find this job number '" & strJobNo & ".'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.txtJobNo.SelectAll() : Me.txtJobNo.Focus()
                    Else
                        strQC_SN_IDs = Me._objTFFK_QC.GetTFFK_QC_SN_IDs(iJob_ID, strSN)
                        If strQC_SN_IDs.Trim.Length = 0 Then
                            MessageBox.Show("Can't find the SN '" & strSN & ".'", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        Else
                            Me._objTFFK_QC.RemoveTFFK_QC_SN(strQC_SN_IDs)
                            Me.txtJobNo.Text = "" : Me.txtSN.Text = ""
                            Me.Close() 'close after removed
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmTFFK_QC_Delete_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
            Me.Close()
        End Sub
    End Class
End Namespace
