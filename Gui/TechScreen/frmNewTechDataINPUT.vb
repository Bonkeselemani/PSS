Public Class frmNewTechDataINPUT
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
    Friend WithEvents grpSave As System.Windows.Forms.GroupBox
    Friend WithEvents rbBoth As System.Windows.Forms.RadioButton
    Friend WithEvents rbWarranty As System.Windows.Forms.RadioButton
    Friend WithEvents rbCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents txtNumber As System.Windows.Forms.TextBox
    Friend WithEvents cboFailure As System.Windows.Forms.ComboBox
    Friend WithEvents cboReferenceDesignator As System.Windows.Forms.ComboBox
    Friend WithEvents cboRepairAction As System.Windows.Forms.ComboBox
    Friend WithEvents cboProblemFound As System.Windows.Forms.ComboBox
    Friend WithEvents lblFailure As System.Windows.Forms.Label
    Friend WithEvents lblNumber As System.Windows.Forms.Label
    Friend WithEvents lblRefDes As System.Windows.Forms.Label
    Friend WithEvents lblRepairAction As System.Windows.Forms.Label
    Friend WithEvents lblProblemFound As System.Windows.Forms.Label
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblBillCode As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.grpSave = New System.Windows.Forms.GroupBox()
        Me.rbBoth = New System.Windows.Forms.RadioButton()
        Me.rbWarranty = New System.Windows.Forms.RadioButton()
        Me.rbCustomer = New System.Windows.Forms.RadioButton()
        Me.txtNumber = New System.Windows.Forms.TextBox()
        Me.cboFailure = New System.Windows.Forms.ComboBox()
        Me.cboReferenceDesignator = New System.Windows.Forms.ComboBox()
        Me.cboRepairAction = New System.Windows.Forms.ComboBox()
        Me.cboProblemFound = New System.Windows.Forms.ComboBox()
        Me.lblFailure = New System.Windows.Forms.Label()
        Me.lblNumber = New System.Windows.Forms.Label()
        Me.lblRefDes = New System.Windows.Forms.Label()
        Me.lblRepairAction = New System.Windows.Forms.Label()
        Me.lblProblemFound = New System.Windows.Forms.Label()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.lblBillCode = New System.Windows.Forms.Label()
        Me.grpSave.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpSave
        '
        Me.grpSave.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbBoth, Me.rbWarranty, Me.rbCustomer})
        Me.grpSave.Location = New System.Drawing.Point(232, 168)
        Me.grpSave.Name = "grpSave"
        Me.grpSave.Size = New System.Drawing.Size(272, 48)
        Me.grpSave.TabIndex = 18
        Me.grpSave.TabStop = False
        Me.grpSave.Text = "Save To"
        '
        'rbBoth
        '
        Me.rbBoth.Location = New System.Drawing.Point(208, 16)
        Me.rbBoth.Name = "rbBoth"
        Me.rbBoth.Size = New System.Drawing.Size(56, 24)
        Me.rbBoth.TabIndex = 2
        Me.rbBoth.Text = "Both"
        '
        'rbWarranty
        '
        Me.rbWarranty.Location = New System.Drawing.Point(128, 16)
        Me.rbWarranty.Name = "rbWarranty"
        Me.rbWarranty.Size = New System.Drawing.Size(72, 24)
        Me.rbWarranty.TabIndex = 1
        Me.rbWarranty.Text = "Warranty"
        '
        'rbCustomer
        '
        Me.rbCustomer.Location = New System.Drawing.Point(48, 16)
        Me.rbCustomer.Name = "rbCustomer"
        Me.rbCustomer.Size = New System.Drawing.Size(72, 24)
        Me.rbCustomer.TabIndex = 0
        Me.rbCustomer.Text = "Customer"
        '
        'txtNumber
        '
        Me.txtNumber.Location = New System.Drawing.Point(336, 120)
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.TabIndex = 30
        Me.txtNumber.Text = ""
        '
        'cboFailure
        '
        Me.cboFailure.Location = New System.Drawing.Point(336, 144)
        Me.cboFailure.Name = "cboFailure"
        Me.cboFailure.Size = New System.Drawing.Size(168, 21)
        Me.cboFailure.TabIndex = 29
        '
        'cboReferenceDesignator
        '
        Me.cboReferenceDesignator.Location = New System.Drawing.Point(336, 96)
        Me.cboReferenceDesignator.Name = "cboReferenceDesignator"
        Me.cboReferenceDesignator.Size = New System.Drawing.Size(168, 21)
        Me.cboReferenceDesignator.TabIndex = 28
        '
        'cboRepairAction
        '
        Me.cboRepairAction.Location = New System.Drawing.Point(336, 72)
        Me.cboRepairAction.Name = "cboRepairAction"
        Me.cboRepairAction.Size = New System.Drawing.Size(168, 21)
        Me.cboRepairAction.TabIndex = 27
        '
        'cboProblemFound
        '
        Me.cboProblemFound.Location = New System.Drawing.Point(336, 48)
        Me.cboProblemFound.Name = "cboProblemFound"
        Me.cboProblemFound.Size = New System.Drawing.Size(168, 21)
        Me.cboProblemFound.TabIndex = 26
        '
        'lblFailure
        '
        Me.lblFailure.Location = New System.Drawing.Point(216, 144)
        Me.lblFailure.Name = "lblFailure"
        Me.lblFailure.Size = New System.Drawing.Size(120, 16)
        Me.lblFailure.TabIndex = 25
        Me.lblFailure.Text = "Failure"
        Me.lblFailure.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumber
        '
        Me.lblNumber.Location = New System.Drawing.Point(216, 120)
        Me.lblNumber.Name = "lblNumber"
        Me.lblNumber.Size = New System.Drawing.Size(120, 16)
        Me.lblNumber.TabIndex = 24
        Me.lblNumber.Text = "Number"
        Me.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRefDes
        '
        Me.lblRefDes.Location = New System.Drawing.Point(216, 96)
        Me.lblRefDes.Name = "lblRefDes"
        Me.lblRefDes.Size = New System.Drawing.Size(120, 16)
        Me.lblRefDes.TabIndex = 23
        Me.lblRefDes.Text = "Reference Designator"
        Me.lblRefDes.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRepairAction
        '
        Me.lblRepairAction.Location = New System.Drawing.Point(216, 72)
        Me.lblRepairAction.Name = "lblRepairAction"
        Me.lblRepairAction.Size = New System.Drawing.Size(120, 16)
        Me.lblRepairAction.TabIndex = 22
        Me.lblRepairAction.Text = "Repair Action"
        Me.lblRepairAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProblemFound
        '
        Me.lblProblemFound.Location = New System.Drawing.Point(216, 48)
        Me.lblProblemFound.Name = "lblProblemFound"
        Me.lblProblemFound.Size = New System.Drawing.Size(120, 16)
        Me.lblProblemFound.TabIndex = 21
        Me.lblProblemFound.Text = "Problem Found"
        Me.lblProblemFound.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.Location = New System.Drawing.Point(16, 40)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(192, 334)
        Me.CheckedListBox1.TabIndex = 20
        '
        'lblBillCode
        '
        Me.lblBillCode.Location = New System.Drawing.Point(16, 24)
        Me.lblBillCode.Name = "lblBillCode"
        Me.lblBillCode.Size = New System.Drawing.Size(192, 16)
        Me.lblBillCode.TabIndex = 19
        Me.lblBillCode.Text = "BillCode"
        Me.lblBillCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmNewTechDataINPUT
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(592, 429)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtNumber, Me.cboFailure, Me.cboReferenceDesignator, Me.cboRepairAction, Me.cboProblemFound, Me.lblFailure, Me.lblNumber, Me.lblRefDes, Me.lblRepairAction, Me.lblProblemFound, Me.CheckedListBox1, Me.lblBillCode, Me.grpSave})
        Me.Name = "frmNewTechDataINPUT"
        Me.Text = "frmNewTechDataINPUT"
        Me.grpSave.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
