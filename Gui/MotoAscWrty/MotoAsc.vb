
Namespace Gui.MotoAscWrty
    Public Class MotoAsc
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
        Friend WithEvents mcBegin As System.Windows.Forms.MonthCalendar
        Friend WithEvents btnRun As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.mcBegin = New System.Windows.Forms.MonthCalendar()
            Me.btnRun = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'mcBegin
            '
            Me.mcBegin.Location = New System.Drawing.Point(8, 24)
            Me.mcBegin.Name = "mcBegin"
            Me.mcBegin.TabIndex = 1
            '
            'btnRun
            '
            Me.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup
            Me.btnRun.Location = New System.Drawing.Point(8, 184)
            Me.btnRun.Name = "btnRun"
            Me.btnRun.Size = New System.Drawing.Size(208, 24)
            Me.btnRun.TabIndex = 2
            Me.btnRun.Text = "Run Motorolla ASC Claim"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(208, 16)
            Me.Label1.TabIndex = 3
            Me.Label1.Text = "Select a date."
            '
            'MotoAsc
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(224, 213)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnRun, Me.mcBegin})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "MotoAsc"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Motorolla ASC"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub mcBegin_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcBegin.DateSelected
            DoSelection()
        End Sub

        Private Sub DoSelection()
            mcBegin.SelectionStart = DateAdd(DateInterval.Day, -1, mcBegin.SelectionStart)
            mcBegin.SelectionEnd = DateAdd(DateInterval.Day, 7, mcBegin.SelectionStart)
        End Sub

        Private Sub MotoAsc_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            DoSelection()
        End Sub


        Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
            '//Dim claim As New PSS.rules.MotoAscClaim(mcBegin.SelectionStart, mcBegin.SelectionEnd)
            Dim claim As New PSS.Rules.MotoAscClaim(mcBegin.SelectionStart, mcBegin.SelectionEnd)

            claim.Run()
        End Sub
    End Class
End Namespace
