Public Class frmProductivityTracker
    Inherits System.Windows.Forms.Form
    Private objProdTracker As PSS.Data.Buisness.clsProdTracker

    'Private alarmCounter As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objProdTracker = New PSS.Data.Buisness.clsProdTracker()
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDailyGoal As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDailyGoal = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDailyGoal, Me.Label1})
        Me.Panel1.Location = New System.Drawing.Point(304, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 64)
        Me.Panel1.TabIndex = 0
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Black
        Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(304, 64)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "Line Refurb Productivity Numbers"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Daily Goal:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDailyGoal
        '
        Me.txtDailyGoal.Location = New System.Drawing.Point(100, 6)
        Me.txtDailyGoal.Name = "txtDailyGoal"
        Me.txtDailyGoal.Size = New System.Drawing.Size(80, 20)
        Me.txtDailyGoal.TabIndex = 1
        Me.txtDailyGoal.Text = ""
        '
        'frmProductivityTracker
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(696, 476)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblHeader, Me.Panel1})
        Me.Name = "frmProductivityTracker"
        Me.Text = "Line Refurb Numbers"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        objProdTracker = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub TimerEventProcessor(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
        
        Try
            Me.Timer1.Stop()
            MsgBox("Test")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Timer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Timer1.Enabled = True
        End Try

    End Sub


    Private Sub frmProductivityTracker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim exitFlag As Boolean = False

        AddHandler Timer1.Tick, AddressOf TimerEventProcessor

        ' Sets the timer interval to 5 seconds.
        Timer1.Interval = 20000
        Timer1.Start()

        ' Runs the timer, and raises the event.
        While exitFlag = False
            ' Processes all the events in the queue.
            Application.DoEvents()
        End While

    End Sub
End Class
