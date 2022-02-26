Public Class frmReturnCode
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
    Friend WithEvents lblReturnCode As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents cboReturnCode As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblReturnCode = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cboReturnCode = New PSS.Gui.Controls.ComboBox()
        Me.SuspendLayout()
        '
        'lblReturnCode
        '
        Me.lblReturnCode.Location = New System.Drawing.Point(16, 16)
        Me.lblReturnCode.Name = "lblReturnCode"
        Me.lblReturnCode.Size = New System.Drawing.Size(80, 16)
        Me.lblReturnCode.TabIndex = 0
        Me.lblReturnCode.Text = "Return Code:"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(104, 56)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(288, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Continue"
        '
        'cboReturnCode
        '
        Me.cboReturnCode.AutoComplete = True
        Me.cboReturnCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReturnCode.Location = New System.Drawing.Point(104, 16)
        Me.cboReturnCode.Name = "cboReturnCode"
        Me.cboReturnCode.Size = New System.Drawing.Size(288, 32)
        Me.cboReturnCode.TabIndex = 1
        '
        'frmReturnCode
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(408, 85)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReturnCode, Me.btnOK, Me.lblReturnCode})
        Me.Name = "frmReturnCode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmReturnCode"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmReturnCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dtReturn As DataTable = PSS.Data.Production.Joins.GetSpecialCodeATCreturn(19)
        cboReturnCode.DataSource = dtReturn
        cboReturnCode.DisplayMember = dtReturn.Columns("Dcode_SDesc").ToString
        cboReturnCode.ValueMember = dtReturn.Columns("Dcode_ID").ToString
        cboReturnCode.Focus()

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If cboReturnCode.SelectedValue > 0 Then
            Gui.pretest.frmPreTest.mReturnCode = cboReturnCode.SelectedValue
        End If

        Gui.pretest.frmPreTest.returnWaitState = 1
        Me.Close()

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)
        Gui.pretest.frmPreTest.returnWaitState = 1
    End Sub

End Class
