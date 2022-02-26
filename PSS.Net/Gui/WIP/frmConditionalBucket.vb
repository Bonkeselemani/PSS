Public Class frmConditionalBucket
    Inherits System.Windows.Forms.Form

    Private iLPF_ID As Integer = 0
    Private iCP_Bucket As Integer = 0

    Private booReturnFlag As Boolean

    Public Property ReturnFlag() As Boolean
        Get
            Return booReturnFlag
        End Get
        Set(ByVal Value As Boolean)
            booReturnFlag = Value
        End Set
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iLPFID As Integer)

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        iLPF_ID = iLPFID


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
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lstPushTo As System.Windows.Forms.ListBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lstPushTo = New System.Windows.Forms.ListBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.Color.Blue
        Me.cmdSave.Location = New System.Drawing.Point(152, 312)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(72, 28)
        Me.cmdSave.TabIndex = 3
        Me.cmdSave.Text = "Save"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(16, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "If Failed Push to:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstPushTo
        '
        Me.lstPushTo.Location = New System.Drawing.Point(16, 24)
        Me.lstPushTo.Name = "lstPushTo"
        Me.lstPushTo.Size = New System.Drawing.Size(208, 277)
        Me.lstPushTo.TabIndex = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Blue
        Me.cmdCancel.Location = New System.Drawing.Point(16, 312)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 28)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        '
        'frmConditionalBucket
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(240, 349)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.Label7, Me.lstPushTo, Me.cmdSave})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConditionalBucket"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conditional Push Bucket"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    '***************************************************************************
    Private Sub frmConditionalBucket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objInventory As New PSS.Data.Buisness.Inventory()

        Try
            Me.LoadBucket()

            iCP_Bucket = objInventory.GetCP_BucketID(iLPF_ID)
            If iCP_Bucket > 0 Then
                Me.lstPushTo.SelectedValue = iCP_Bucket
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Load Form", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub LoadBucket()
        Dim dtBuckets As DataTable
        Dim R1 As DataRow
        Dim objInventory As New PSS.Data.Buisness.Inventory()

        Try
            Me.lstPushTo.DataSource = Nothing

            dtBuckets = objInventory.GetGroups(, 1)

            'lstPushTo
            Me.lstPushTo.DisplayMember = dtBuckets.Columns("Group").ToString
            Me.lstPushTo.ValueMember = dtBuckets.Columns("Group_ID").ToString
            Me.lstPushTo.DataSource = dtBuckets.DefaultView

            Me.lstPushTo.ClearSelected()
            Me.lstPushTo.Refresh()


        Catch ex As Exception
            Throw New Exception("LoadBucket:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtBuckets) Then
                dtBuckets.Dispose()
                dtBuckets = Nothing
            End If

            dtBuckets = Nothing
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        booReturnFlag = False
        Me.Close()
    End Sub

    '***************************************************************************
    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Me.ProcessSaveBucket()
    End Sub

    '***************************************************************************
    Private Sub ProcessSaveBucket()
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim i As Integer = 0

        Try
            If Me.lstPushTo.SelectedIndex < 0 Then
                MessageBox.Show("Please select one bucket.", "Save Conditional Push", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                i = objInventory.SaveConditonalPushBucket(Me.iLPF_ID, Me.lstPushTo.SelectedItem("Group_ID"))
            End If

            If i > 0 Then
                booReturnFlag = True
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Save Conditional Push", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub lstPushTo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstPushTo.DoubleClick
        Me.ProcessSaveBucket()
    End Sub

    '***************************************************************************
    Private Sub lstPushTo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstPushTo.KeyUp
        If e.KeyValue = 13 Then
            Me.ProcessSaveBucket()
        End If
    End Sub


End Class
