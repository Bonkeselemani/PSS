Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.TracFoneFulfillmentKit
    Public Class frmTFFK_BYOP_Kitting_Setup_Qty
        Inherits System.Windows.Forms.Form

        Private _iQtyNeeded As Integer = 0
        Private _bCancelled As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call

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
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'btnOK
            '
            Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOK.ForeColor = System.Drawing.Color.White
            Me.btnOK.Location = New System.Drawing.Point(32, 64)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(160, 40)
            Me.btnOK.TabIndex = 0
            Me.btnOK.Text = "OK"
            '
            'lblQty
            '
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.ForeColor = System.Drawing.Color.White
            Me.lblQty.Location = New System.Drawing.Point(32, 24)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(88, 24)
            Me.lblQty.TabIndex = 1
            Me.lblQty.Text = "Qty Needed:"
            '
            'txtQty
            '
            Me.txtQty.Location = New System.Drawing.Point(120, 24)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(72, 22)
            Me.txtQty.TabIndex = 2
            Me.txtQty.Text = "1"
            '
            'btnCancel
            '
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(8, 64)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(24, 16)
            Me.btnCancel.TabIndex = 3
            Me.btnCancel.Text = "Cancel"
            '
            'frmTFFK_BYOP_Kitting_Setup_Qty
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
            Me.BackColor = System.Drawing.Color.DarkKhaki
            Me.ClientSize = New System.Drawing.Size(224, 126)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.txtQty, Me.lblQty, Me.btnOK})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmTFFK_BYOP_Kitting_Setup_Qty"
            Me.Text = "Enter Qty"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public ReadOnly Property getQtyNeeded() As Integer
            Get
                Return Me._iQtyNeeded
            End Get
        End Property

        Public ReadOnly Property bIsCancelled() As Boolean
            Get
                Return Me._bCancelled
            End Get
        End Property

        Private Sub frmTFFK_BYOP_Kitting_Setup_Qty_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.CenterToScreen()
                PSS.Core.Highlight.SetHighLight(Me)

                Me.btnCancel.Visible = False

                Me.ActiveControl = Me.btnOK : Me.btnOK.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub frmTFFK_BYOP_Kitting_Setup_Qty_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me._bCancelled = True
            Me.Close()
        End Sub

        Private Sub btnOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnOK.Click

            Try
                If Me.txtQty.Text.Trim.Length = 0 OrElse Not IsNumeric(Me.txtQty.Text.Trim) OrElse Not Convert.ToInt32(Me.txtQty.Text) > 0 Then
                    MessageBox.Show("Please enter a valid number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Me._iQtyNeeded = Convert.ToInt32(Me.txtQty.Text)
                    Me._bCancelled = False
                    Me.Close()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace