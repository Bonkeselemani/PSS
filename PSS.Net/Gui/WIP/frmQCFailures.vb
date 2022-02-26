Public Class frmQCFailures
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
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lstPushTo As System.Windows.Forms.ListBox
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lstPushTo = New System.Windows.Forms.ListBox()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Blue
        Me.cmdCancel.Location = New System.Drawing.Point(5, 316)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 28)
        Me.cmdCancel.TabIndex = 122
        Me.cmdCancel.Text = "Cancel"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(5, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 16)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "If Failed Push to:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstPushTo
        '
        Me.lstPushTo.Location = New System.Drawing.Point(5, 28)
        Me.lstPushTo.Name = "lstPushTo"
        Me.lstPushTo.Size = New System.Drawing.Size(220, 277)
        Me.lstPushTo.TabIndex = 121
        '
        'cmdSave
        '
        Me.cmdSave.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.ForeColor = System.Drawing.Color.Blue
        Me.cmdSave.Location = New System.Drawing.Point(141, 316)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(72, 28)
        Me.cmdSave.TabIndex = 123
        Me.cmdSave.Text = "Save"
        '
        'frmQCFailures
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(232, 357)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.Label7, Me.lstPushTo, Me.cmdSave})
        Me.Name = "frmQCFailures"
        Me.Text = "frmQCFailures"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
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

End Class
