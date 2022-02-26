Public Class frmCreateARFiles
    Inherits System.Windows.Forms.Form
    Private objBiz As PSS.Data.Buisness.clsBiz
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Cursor.Current = Cursors.WaitCursor
        objBiz = New PSS.Data.Buisness.clsBiz()
        Cursor.Current = Cursors.Default
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCreate As System.Windows.Forms.Button
    Friend WithEvents lblMsg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCreate = New System.Windows.Forms.Button()
        Me.lblMsg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(16, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 32)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Create AR/RL Files"
        '
        'cmdCreate
        '
        Me.cmdCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreate.Location = New System.Drawing.Point(64, 64)
        Me.cmdCreate.Name = "cmdCreate"
        Me.cmdCreate.Size = New System.Drawing.Size(112, 48)
        Me.cmdCreate.TabIndex = 1
        Me.cmdCreate.Text = "Create Files"
        '
        'lblMsg
        '
        Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMsg.ForeColor = System.Drawing.Color.Blue
        Me.lblMsg.Location = New System.Drawing.Point(8, 137)
        Me.lblMsg.Name = "lblMsg"
        Me.lblMsg.Size = New System.Drawing.Size(416, 16)
        Me.lblMsg.TabIndex = 2
        '
        'frmCreateARFiles
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(432, 272)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMsg, Me.cmdCreate, Me.Label1})
        Me.Name = "frmCreateARFiles"
        Me.Text = "frmCreateARFiles"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub cmdCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreate.Click
        'Dim objBiz As New clsBiz()
        Dim i As Integer = 0
        Dim strMsg As String = ""

        Me.cmdCreate.Enabled = False
        Cursor.Current = Cursors.WaitCursor

        Try
            'Step 1     (Lock the Set of finished goods being moved to Navision)    Send 9 for Locking
            i = 0
            lblMsg.Text = "Locking items..."
            System.Windows.Forms.Application.DoEvents()
            i = objBiz.LockUnlockFinishedGoods(9)

            'Step 2      'Create a Depleted SKU file
            i = 0
            lblMsg.Text = "Creating files for consumed SKUs for Asset Recovery..."
            System.Windows.Forms.Application.DoEvents()
            i = objBiz.DecrementedSKUs_AssetRecovery

            'Step 3
            i = 0
            lblMsg.Text = "Creating files for consumed SKUs for Reverse Logistics..."
            System.Windows.Forms.Application.DoEvents()
            i = objBiz.DecrementedSKUs_ReverseLogistics

            'Step 4     'Create an Incremented SKU file for Reverse Logistics stuff  'IncremmentedSKUs_ReverseLogistics
            i = 0
            lblMsg.Text = "Creating files for Finished Good SKUs for Reverse Logistics..."
            System.Windows.Forms.Application.DoEvents()
            i = objBiz.IncremmentedSKUs_ReverseLogistics

            'Step 5     'Create an Incremented SKU file for Asset Recovery stuff
            i = 0
            lblMsg.Text = "Creating files for Finished Good SKUs for Asset Recovery..."
            System.Windows.Forms.Application.DoEvents()
            i = objBiz.IncremmentedSKUs_AssetRecovery

            'Step 6     'Create a Parts Consumption
            i = 0
            lblMsg.Text = "Creating files for parts consumed..."
            System.Windows.Forms.Application.DoEvents()
            i = objBiz.PartsConsumption

            'Step 7     'Time stamps the Moved devices
            If objBiz.Ex = 0 Then       'That means there are no exceptions.
                lblMsg.Text = "Time stamping the items to be moved to navision..."
                System.Windows.Forms.Application.DoEvents()
                i = objBiz.UpdateNavisionTransferredDevices()
            End If

            'Step 8     (unlock the Set of finished goods being moved to Navision)    Send 1 for unlocking
            lblMsg.Text = "Unlocking items..."
            System.Windows.Forms.Application.DoEvents()
            i = objBiz.LockUnlockFinishedGoods(1)

            'Step 9
            lblMsg.Text = "Backing up files..."
            System.Windows.Forms.Application.DoEvents()
            i = objBiz.BackupFiles()

            'Step 10     'Generate log message
            lblMsg.Text = "Completed..."
            System.Windows.Forms.Application.DoEvents()
            strMsg = ""
            strMsg = Now() & Space(10) & "Files have been created successfully."
            Cursor.Current = Cursors.Default
            MsgBox(strMsg)

            'Step 11
            If objBiz.Ex = 1 Then       'That means there are exceptions.
                lblMsg.Text = "Sending email if there are exceptions..."
                System.Windows.Forms.Application.DoEvents()
                i = objBiz.SendMail()
            End If

            lblMsg.Text = ""
            System.Windows.Forms.Application.DoEvents()

        Catch ex As Exception
            'Write to a log file (Job messed up message)
            
            strMsg = ""
            strMsg = Now() & Space(10) & "Errors occured in creating files. " & ex.Message.ToString
            Cursor.Current = Cursors.Default
            MsgBox(strMsg)
            
        Finally
            'Write the messages to the log file
            objBiz.WriteToLogFile(strMsg)
            'objBiz = Nothing
            objBiz.Ex = 0
            lblMsg.Text = ""
            Me.cmdCreate.Enabled = True
            Cursor.Current = Cursors.Default
            System.Windows.Forms.Application.DoEvents()
        End Try

    End Sub

    Protected Overrides Sub Finalize()
        objBiz = Nothing
        MyBase.Finalize()
    End Sub
End Class
