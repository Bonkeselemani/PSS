Option Explicit On 

Namespace Gui.ReportViewer

    Public Class frmOPsInventoryRpt
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
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents cmbTATProd As PSS.Gui.Controls.ComboBox
        Friend WithEvents cmbTATCust As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cmdSummaryRpt As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtDaysInWIP_Lowerbound As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtDaysInWIP_Upperbound As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.cmbTATProd = New PSS.Gui.Controls.ComboBox()
            Me.cmbTATCust = New PSS.Gui.Controls.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cmdSummaryRpt = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtDaysInWIP_Lowerbound = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtDaysInWIP_Upperbound = New System.Windows.Forms.TextBox()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.txtDaysInWIP_Upperbound, Me.Label1, Me.txtDaysInWIP_Lowerbound, Me.cmbTATProd, Me.cmbTATCust, Me.Label7, Me.cmdSummaryRpt, Me.Label8})
            Me.Panel2.Location = New System.Drawing.Point(16, 16)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(464, 176)
            Me.Panel2.TabIndex = 68
            '
            'cmbTATProd
            '
            Me.cmbTATProd.AutoComplete = True
            Me.cmbTATProd.BackColor = System.Drawing.SystemColors.Window
            Me.cmbTATProd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbTATProd.ForeColor = System.Drawing.Color.Black
            Me.cmbTATProd.Location = New System.Drawing.Point(184, 39)
            Me.cmbTATProd.Name = "cmbTATProd"
            Me.cmbTATProd.Size = New System.Drawing.Size(256, 21)
            Me.cmbTATProd.TabIndex = 2
            '
            'cmbTATCust
            '
            Me.cmbTATCust.AutoComplete = True
            Me.cmbTATCust.BackColor = System.Drawing.SystemColors.Window
            Me.cmbTATCust.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbTATCust.ForeColor = System.Drawing.Color.Black
            Me.cmbTATCust.Location = New System.Drawing.Point(184, 8)
            Me.cmbTATCust.Name = "cmbTATCust"
            Me.cmbTATCust.Size = New System.Drawing.Size(256, 21)
            Me.cmbTATCust.TabIndex = 1
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label7.Location = New System.Drawing.Point(72, 40)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(104, 16)
            Me.Label7.TabIndex = 65
            Me.Label7.Text = "Product Type:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmdSummaryRpt
            '
            Me.cmdSummaryRpt.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdSummaryRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdSummaryRpt.ForeColor = System.Drawing.Color.White
            Me.cmdSummaryRpt.Location = New System.Drawing.Point(40, 120)
            Me.cmdSummaryRpt.Name = "cmdSummaryRpt"
            Me.cmdSummaryRpt.Size = New System.Drawing.Size(400, 31)
            Me.cmdSummaryRpt.TabIndex = 5
            Me.cmdSummaryRpt.Text = "Operation Inventory Summary Report"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label8.Location = New System.Drawing.Point(96, 8)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(80, 16)
            Me.Label8.TabIndex = 63
            Me.Label8.Text = "Customer:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDaysInWIP_Lowerbound
            '
            Me.txtDaysInWIP_Lowerbound.Location = New System.Drawing.Point(184, 72)
            Me.txtDaysInWIP_Lowerbound.Name = "txtDaysInWIP_Lowerbound"
            Me.txtDaysInWIP_Lowerbound.Size = New System.Drawing.Size(56, 20)
            Me.txtDaysInWIP_Lowerbound.TabIndex = 3
            Me.txtDaysInWIP_Lowerbound.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(8, 72)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(168, 16)
            Me.Label1.TabIndex = 70
            Me.Label1.Text = "Day In WIP  Less Than:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(246, 75)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(128, 16)
            Me.Label2.TabIndex = 72
            Me.Label2.Text = "And Greater Than:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDaysInWIP_Upperbound
            '
            Me.txtDaysInWIP_Upperbound.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDaysInWIP_Upperbound.Location = New System.Drawing.Point(382, 72)
            Me.txtDaysInWIP_Upperbound.Name = "txtDaysInWIP_Upperbound"
            Me.txtDaysInWIP_Upperbound.Size = New System.Drawing.Size(56, 21)
            Me.txtDaysInWIP_Upperbound.TabIndex = 4
            Me.txtDaysInWIP_Upperbound.Text = ""
            '
            'frmOPsInventoryRpt
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(664, 398)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2})
            Me.Name = "frmOPsInventoryRpt"
            Me.Text = "Operations Inventory Report"
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************
        Private Sub frmOPsInventoryRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        '****************************************************************
        Private Sub txtDaysInWIP_Lowerbound_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDaysInWIP_Lowerbound.KeyPress
            If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End Sub

        '****************************************************************
        Private Sub txtDaysInWIP_Upperbound_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDaysInWIP_Upperbound.KeyPress
            If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End Sub

        '****************************************************************

    End Class
End Namespace