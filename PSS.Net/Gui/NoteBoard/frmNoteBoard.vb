Namespace Gui.NoteBoard

    Public Class frmNoteBoard
        Inherits System.Windows.Forms.Form

        Private strText As String
        Private iMilliSecs As Integer = 0
        Private t As New System.Timers.Timer()

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal vText As String, Optional ByVal iMS As Integer = 2000)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            strText = vText
            iMilliSecs = iMS

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
        Friend WithEvents lblNoteBoard As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblNoteBoard = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblNoteBoard
            '
            Me.lblNoteBoard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNoteBoard.Location = New System.Drawing.Point(16, 16)
            Me.lblNoteBoard.Name = "lblNoteBoard"
            Me.lblNoteBoard.Size = New System.Drawing.Size(296, 96)
            Me.lblNoteBoard.TabIndex = 0
            Me.lblNoteBoard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmNoteBoard
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(328, 125)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblNoteBoard})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmNoteBoard"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "NoteBoard"
            Me.ResumeLayout(False)

        End Sub

#End Region



        Private Sub frmNoteBoard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            AddHandler t.Elapsed, AddressOf TimerFired
            lblNoteBoard.Text = strText
            t.Interval = iMilliSecs
            t.Enabled = True

        End Sub

        Public Sub TimerFired(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs)

            Me.Close()

        End Sub

    End Class

End Namespace
