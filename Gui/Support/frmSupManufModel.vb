
Namespace Gui.support


    Public Class frmSupManufModel
        Inherits System.Windows.Forms.Form

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
        Friend WithEvents grpManuf As System.Windows.Forms.GroupBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboManufacturer As System.Windows.Forms.ComboBox
        Friend WithEvents lblManufSel As System.Windows.Forms.Label
        Friend WithEvents btnNewManuf As System.Windows.Forms.Button
        Friend WithEvents btnAddNewMI As System.Windows.Forms.Button
        Friend WithEvents btnCancelMI As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grpManuf = New System.Windows.Forms.GroupBox()
            Me.btnCancelMI = New System.Windows.Forms.Button()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnAddNewMI = New System.Windows.Forms.Button()
            Me.cboManufacturer = New System.Windows.Forms.ComboBox()
            Me.lblManufSel = New System.Windows.Forms.Label()
            Me.btnNewManuf = New System.Windows.Forms.Button()
            Me.grpManuf.SuspendLayout()
            Me.SuspendLayout()
            '
            'grpManuf
            '
            Me.grpManuf.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelMI, Me.TextBox1, Me.Label1, Me.btnAddNewMI})
            Me.grpManuf.Location = New System.Drawing.Point(32, 248)
            Me.grpManuf.Name = "grpManuf"
            Me.grpManuf.Size = New System.Drawing.Size(320, 80)
            Me.grpManuf.TabIndex = 2
            Me.grpManuf.TabStop = False
            Me.grpManuf.Text = "Manufacturer"
            '
            'btnCancelMI
            '
            Me.btnCancelMI.Location = New System.Drawing.Point(144, 48)
            Me.btnCancelMI.Name = "btnCancelMI"
            Me.btnCancelMI.TabIndex = 7
            Me.btnCancelMI.Text = "Cancel"
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(72, 24)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(232, 20)
            Me.TextBox1.TabIndex = 3
            Me.TextBox1.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Description:"
            '
            'btnAddNewMI
            '
            Me.btnAddNewMI.Location = New System.Drawing.Point(232, 48)
            Me.btnAddNewMI.Name = "btnAddNewMI"
            Me.btnAddNewMI.TabIndex = 4
            Me.btnAddNewMI.Text = "Add New"
            '
            'cboManufacturer
            '
            Me.cboManufacturer.Location = New System.Drawing.Point(104, 24)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(152, 21)
            Me.cboManufacturer.TabIndex = 3
            '
            'lblManufSel
            '
            Me.lblManufSel.Location = New System.Drawing.Point(24, 24)
            Me.lblManufSel.Name = "lblManufSel"
            Me.lblManufSel.Size = New System.Drawing.Size(80, 16)
            Me.lblManufSel.TabIndex = 4
            Me.lblManufSel.Text = "Manufacturer:"
            '
            'btnNewManuf
            '
            Me.btnNewManuf.Location = New System.Drawing.Point(280, 24)
            Me.btnNewManuf.Name = "btnNewManuf"
            Me.btnNewManuf.Size = New System.Drawing.Size(48, 23)
            Me.btnNewManuf.TabIndex = 5
            Me.btnNewManuf.Text = "New"
            '
            'frmSupManufModel
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(376, 381)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnNewManuf, Me.lblManufSel, Me.cboManufacturer, Me.grpManuf})
            Me.Name = "frmSupManufModel"
            Me.Text = "Manufacturer / Model"
            Me.grpManuf.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnNewManuf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewManuf.Click

            '//Move grpManufacturer to top and make visible
            grpManuf.Left = 24
            grpManuf.Top = 16
            ShowManufInput()
            HideManufSelect()

        End Sub

        Private Sub btnAddNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddNewMI.Click

            '//Move grpManufacturer back to original position
            grpManuf.Left = 32
            grpManuf.Top = 248
            HideManufInput()
            ShowManufSelect()

        End Sub

        Private Sub btnCancelMI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelMI.Click

            '//Move grpManufacturer back to original position
            grpManuf.Left = 32
            grpManuf.Top = 248
            HideManufInput()
            ShowManufSelect()

        End Sub

        Private Sub frmSupManufModel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            HideManufInput()
            ShowManufSelect()

        End Sub

        Private Sub HideManufSelect()
            lblManufSel.Visible = False
            cboManufacturer.Visible = False
            btnNewManuf.Visible = False
        End Sub

        Private Sub ShowManufSelect()
            lblManufSel.Visible = True
            cboManufacturer.Visible = True
            btnNewManuf.Visible = True
        End Sub

        Private Sub HideManufInput()
            grpManuf.Visible = False
        End Sub

        Private Sub ShowManufInput()
            grpManuf.Visible = True
        End Sub

    End Class

End Namespace
