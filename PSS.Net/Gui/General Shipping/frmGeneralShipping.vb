Public Class frmGeneralShipping
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
    Friend WithEvents PanelLocation As System.Windows.Forms.Panel
    Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboLocation As PSS.Gui.Controls.ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboProdType As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkPrintLables As System.Windows.Forms.CheckBox
    Friend WithEvents chkClosePallett As System.Windows.Forms.CheckBox
    Friend WithEvents btnClearOne As System.Windows.Forms.Button
    Friend WithEvents chkCloseOverPack As System.Windows.Forms.CheckBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents txtDevice As System.Windows.Forms.TextBox
    Friend WithEvents btnReprint As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.PanelLocation = New System.Windows.Forms.Panel()
        Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboLocation = New PSS.Gui.Controls.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cboProdType = New PSS.Gui.Controls.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkPrintLables = New System.Windows.Forms.CheckBox()
        Me.chkClosePallett = New System.Windows.Forms.CheckBox()
        Me.btnClearOne = New System.Windows.Forms.Button()
        Me.chkCloseOverPack = New System.Windows.Forms.CheckBox()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.txtDevice = New System.Windows.Forms.TextBox()
        Me.btnReprint = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PanelLocation.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelLocation
        '
        Me.PanelLocation.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCustomer, Me.Label1, Me.Label5, Me.cboLocation})
        Me.PanelLocation.Location = New System.Drawing.Point(24, 64)
        Me.PanelLocation.Name = "PanelLocation"
        Me.PanelLocation.Size = New System.Drawing.Size(312, 88)
        Me.PanelLocation.TabIndex = 54
        '
        'cboCustomer
        '
        Me.cboCustomer.AutoComplete = True
        Me.cboCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cboCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomer.ForeColor = System.Drawing.Color.Black
        Me.cboCustomer.Location = New System.Drawing.Point(92, 16)
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.Size = New System.Drawing.Size(204, 21)
        Me.cboCustomer.TabIndex = 56
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(14, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(18, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 55
        Me.Label5.Text = "Location:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboLocation
        '
        Me.cboLocation.AutoComplete = True
        Me.cboLocation.BackColor = System.Drawing.SystemColors.Window
        Me.cboLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLocation.ForeColor = System.Drawing.Color.Black
        Me.cboLocation.Location = New System.Drawing.Point(92, 47)
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.Size = New System.Drawing.Size(204, 21)
        Me.cboLocation.TabIndex = 54
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProdType, Me.Label3})
        Me.Panel1.Location = New System.Drawing.Point(24, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(312, 48)
        Me.Panel1.TabIndex = 55
        '
        'cboProdType
        '
        Me.cboProdType.AutoComplete = True
        Me.cboProdType.BackColor = System.Drawing.SystemColors.Window
        Me.cboProdType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProdType.ForeColor = System.Drawing.Color.Black
        Me.cboProdType.Location = New System.Drawing.Point(117, 14)
        Me.cboProdType.Name = "cboProdType"
        Me.cboProdType.Size = New System.Drawing.Size(179, 21)
        Me.cboProdType.TabIndex = 56
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(14, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 16)
        Me.Label3.TabIndex = 57
        Me.Label3.Text = "Product Type:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDate.Location = New System.Drawing.Point(414, 10)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(123, 16)
        Me.lblDate.TabIndex = 57
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(360, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkPrintLables
        '
        Me.chkPrintLables.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkPrintLables.BackColor = System.Drawing.Color.Transparent
        Me.chkPrintLables.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPrintLables.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkPrintLables.Location = New System.Drawing.Point(704, 376)
        Me.chkPrintLables.Name = "chkPrintLables"
        Me.chkPrintLables.Size = New System.Drawing.Size(152, 24)
        Me.chkPrintLables.TabIndex = 68
        Me.chkPrintLables.Text = "Do not Print Labels"
        '
        'chkClosePallett
        '
        Me.chkClosePallett.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkClosePallett.BackColor = System.Drawing.Color.Transparent
        Me.chkClosePallett.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkClosePallett.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkClosePallett.Location = New System.Drawing.Point(704, 352)
        Me.chkClosePallett.Name = "chkClosePallett"
        Me.chkClosePallett.Size = New System.Drawing.Size(130, 24)
        Me.chkClosePallett.TabIndex = 67
        Me.chkClosePallett.Text = "Close Pallett"
        '
        'btnClearOne
        '
        Me.btnClearOne.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnClearOne.BackColor = System.Drawing.Color.Transparent
        Me.btnClearOne.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearOne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClearOne.Location = New System.Drawing.Point(704, 284)
        Me.btnClearOne.Name = "btnClearOne"
        Me.btnClearOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearOne.Size = New System.Drawing.Size(102, 32)
        Me.btnClearOne.TabIndex = 66
        Me.btnClearOne.Text = "Clear One"
        '
        'chkCloseOverPack
        '
        Me.chkCloseOverPack.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.chkCloseOverPack.BackColor = System.Drawing.Color.Transparent
        Me.chkCloseOverPack.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCloseOverPack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.chkCloseOverPack.Location = New System.Drawing.Point(704, 328)
        Me.chkCloseOverPack.Name = "chkCloseOverPack"
        Me.chkCloseOverPack.Size = New System.Drawing.Size(130, 24)
        Me.chkCloseOverPack.TabIndex = 65
        Me.chkCloseOverPack.Text = "Close Overpack"
        '
        'btnClear
        '
        Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(703, 241)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(102, 32)
        Me.btnClear.TabIndex = 64
        Me.btnClear.Text = "Clear All"
        '
        'lstDevices
        '
        Me.lstDevices.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lstDevices.BackColor = System.Drawing.SystemColors.Window
        Me.lstDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstDevices.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDevices.ForeColor = System.Drawing.Color.Black
        Me.lstDevices.Location = New System.Drawing.Point(537, 170)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(157, 223)
        Me.lstDevices.TabIndex = 63
        '
        'txtDevice
        '
        Me.txtDevice.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.txtDevice.BackColor = System.Drawing.SystemColors.Window
        Me.txtDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDevice.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDevice.ForeColor = System.Drawing.Color.Black
        Me.txtDevice.Location = New System.Drawing.Point(537, 148)
        Me.txtDevice.Name = "txtDevice"
        Me.txtDevice.Size = New System.Drawing.Size(157, 21)
        Me.txtDevice.TabIndex = 62
        Me.txtDevice.Text = ""
        '
        'btnReprint
        '
        Me.btnReprint.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnReprint.BackColor = System.Drawing.Color.Transparent
        Me.btnReprint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnReprint.Location = New System.Drawing.Point(59, 406)
        Me.btnReprint.Name = "btnReprint"
        Me.btnReprint.Size = New System.Drawing.Size(184, 32)
        Me.btnReprint.TabIndex = 61
        Me.btnReprint.Text = "Reprint"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnPrint.BackColor = System.Drawing.Color.Transparent
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrint.Location = New System.Drawing.Point(537, 406)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(157, 32)
        Me.btnPrint.TabIndex = 60
        Me.btnPrint.Text = "Ship"
        '
        'lblCount
        '
        Me.lblCount.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblCount.BackColor = System.Drawing.Color.Transparent
        Me.lblCount.Font = New System.Drawing.Font("Verdana", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCount.Location = New System.Drawing.Point(705, 166)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(111, 47)
        Me.lblCount.TabIndex = 59
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(712, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 58
        Me.Label4.Text = "Count"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(200, 200)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(168, 112)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'frmGeneralShipping
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(864, 540)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.chkPrintLables, Me.chkClosePallett, Me.btnClearOne, Me.chkCloseOverPack, Me.btnClear, Me.lstDevices, Me.txtDevice, Me.btnReprint, Me.btnPrint, Me.lblCount, Me.Label4, Me.lblDate, Me.Label2, Me.Panel1, Me.PanelLocation})
        Me.Name = "frmGeneralShipping"
        Me.Text = "General Shipping"
        Me.PanelLocation.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
