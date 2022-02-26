Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.CP
    Public Class frmCoolPad_FulfillOrder
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _objCoolPad As PSS.Data.Buisness.CP.CoolPad
        Private _objCoolPad_FulfillOrder As PSS.Data.Buisness.CP.CoolPad_FulfillOrder

        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objCoolPad = New PSS.Data.Buisness.CP.CoolPad()
            Me._objCoolPad_FulfillOrder = New PSS.Data.Buisness.CP.CoolPad_FulfillOrder()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objCoolPad = Nothing
                    Me._objCoolPad_FulfillOrder = Nothing
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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
            Me.TabControl1.Location = New System.Drawing.Point(8, 16)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1000, 560)
            Me.TabControl1.TabIndex = 0
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(992, 534)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Fill Order"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(992, 534)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Open Manifest"
            '
            'TabPage3
            '
            Me.TabPage3.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage3.Location = New System.Drawing.Point(4, 22)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(992, 534)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Add Invoice No"
            '
            'GroupBox1
            '
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(16, 16)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(856, 496)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Fill Orders"
            '
            'frmCoolPad_FulfillOrder
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(1024, 598)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmCoolPad_FulfillOrder"
            Me.Text = "frmCoolPad_FulfillOrder"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


    End Class
End Namespace