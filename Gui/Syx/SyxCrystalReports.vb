Option Explicit On 
Imports PSS.Data.Buisness

Namespace Gui


    Public Class SyxCrystalReports
        Inherits System.Windows.Forms.Form
        Private _strRptName As String = ""
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
        Friend WithEvents lblTittle As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblTittle = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblTittle
            '
            Me.lblTittle.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTittle.ForeColor = System.Drawing.Color.Red
            Me.lblTittle.Location = New System.Drawing.Point(24, 48)
            Me.lblTittle.Name = "lblTittle"
            Me.lblTittle.Size = New System.Drawing.Size(672, 280)
            Me.lblTittle.TabIndex = 0
            Me.lblTittle.Text = "Under Construction "
            Me.lblTittle.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'SyxCrystalReports
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
            Me.ClientSize = New System.Drawing.Size(712, 366)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTittle})
            Me.Name = "SyxCrystalReports"
            Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.Text = "SyxCrystalReports"
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Loading"

        Private Sub SyxCrystalReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.lblTittle.Text = "This page is still under construction." & vbCrLf & "Please come back ...."
        End Sub
#End Region

       
    End Class

End Namespace
