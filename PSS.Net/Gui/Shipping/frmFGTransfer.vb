Public Class frmFGTransfer
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMisc = New PSS.Data.Buisness.Misc()
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents radioShipId As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSN As System.Windows.Forms.RadioButton
    Friend WithEvents RadioOverpack As System.Windows.Forms.RadioButton
    Friend WithEvents RadioPallett As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lstItems As System.Windows.Forms.ListBox
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents btnClearOne As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnUnTransfer As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioPallett = New System.Windows.Forms.RadioButton()
        Me.RadioOverpack = New System.Windows.Forms.RadioButton()
        Me.radioShipId = New System.Windows.Forms.RadioButton()
        Me.RadioSN = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstItems = New System.Windows.Forms.ListBox()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClearOne = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnUnTransfer = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioPallett, Me.RadioOverpack, Me.radioShipId, Me.RadioSN})
        Me.Panel1.Location = New System.Drawing.Point(40, 89)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(256, 256)
        Me.Panel1.TabIndex = 4
        '
        'RadioPallett
        '
        Me.RadioPallett.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioPallett.Location = New System.Drawing.Point(13, 151)
        Me.RadioPallett.Name = "RadioPallett"
        Me.RadioPallett.Size = New System.Drawing.Size(226, 24)
        Me.RadioPallett.TabIndex = 4
        Me.RadioPallett.Text = "Pallett ID"
        '
        'RadioOverpack
        '
        Me.RadioOverpack.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioOverpack.Location = New System.Drawing.Point(13, 108)
        Me.RadioOverpack.Name = "RadioOverpack"
        Me.RadioOverpack.Size = New System.Drawing.Size(226, 24)
        Me.RadioOverpack.TabIndex = 3
        Me.RadioOverpack.Text = "Overpack ID"
        '
        'radioShipId
        '
        Me.radioShipId.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radioShipId.Location = New System.Drawing.Point(13, 66)
        Me.radioShipId.Name = "radioShipId"
        Me.radioShipId.Size = New System.Drawing.Size(227, 24)
        Me.radioShipId.TabIndex = 2
        Me.radioShipId.Text = "Ship ID (Master Pack No.)"
        '
        'RadioSN
        '
        Me.RadioSN.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioSN.Location = New System.Drawing.Point(13, 24)
        Me.RadioSN.Name = "RadioSN"
        Me.RadioSN.Size = New System.Drawing.Size(165, 24)
        Me.RadioSN.TabIndex = 1
        Me.RadioSN.Text = "Serial Number"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(38, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select an option below"
        '
        'lstItems
        '
        Me.lstItems.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lstItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstItems.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItems.ForeColor = System.Drawing.Color.Black
        Me.lstItems.Location = New System.Drawing.Point(314, 120)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(157, 171)
        Me.lstItems.TabIndex = 38
        '
        'txtItem
        '
        Me.txtItem.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtItem.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItem.ForeColor = System.Drawing.Color.Black
        Me.txtItem.Location = New System.Drawing.Point(314, 89)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(157, 21)
        Me.txtItem.TabIndex = 37
        Me.txtItem.Text = ""
        '
        'btnTransfer
        '
        Me.btnTransfer.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnTransfer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
        Me.btnTransfer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTransfer.Location = New System.Drawing.Point(314, 301)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(157, 44)
        Me.btnTransfer.TabIndex = 36
        Me.btnTransfer.Text = "Transfer to Finished Goods"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(312, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(232, 16)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Scan in the Number"
        '
        'btnClearOne
        '
        Me.btnClearOne.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnClearOne.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearOne.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClearOne.Location = New System.Drawing.Point(488, 216)
        Me.btnClearOne.Name = "btnClearOne"
        Me.btnClearOne.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearOne.Size = New System.Drawing.Size(96, 24)
        Me.btnClearOne.TabIndex = 54
        Me.btnClearOne.Text = "Clear One"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnClear.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnClear.Location = New System.Drawing.Point(488, 161)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(96, 24)
        Me.btnClear.TabIndex = 53
        Me.btnClear.Text = "Clear All"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Yellow
        Me.Label3.Location = New System.Drawing.Point(40, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(272, 23)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "Transfer to Finished Goods"
        '
        'btnUnTransfer
        '
        Me.btnUnTransfer.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnUnTransfer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnUnTransfer.ForeColor = System.Drawing.Color.Red
        Me.btnUnTransfer.Location = New System.Drawing.Point(568, 328)
        Me.btnUnTransfer.Name = "btnUnTransfer"
        Me.btnUnTransfer.Size = New System.Drawing.Size(88, 83)
        Me.btnUnTransfer.TabIndex = 56
        Me.btnUnTransfer.Text = "Move from Finished Goods back to Floor"
        '
        'frmFGTransfer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(686, 434)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUnTransfer, Me.Label3, Me.btnClearOne, Me.btnClear, Me.Label2, Me.lstItems, Me.txtItem, Me.btnTransfer, Me.Label1, Me.Panel1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "frmFGTransfer"
        Me.Text = "Transfer to Finished Goods"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private iFlg As Integer = 0
    Private objMisc As PSS.Data.Buisness.Misc
    ''****************************************************************************
    ''CheckChange event handler all both option buttons.
    ''****************************************************************************
    Private Sub radioOptionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSN.CheckedChanged, radioShipId.CheckedChanged, RadioOverpack.CheckedChanged, RadioPallett.CheckedChanged

        If Me.RadioSN.Checked Then
            iFlg = 1
        ElseIf Me.radioShipId.Checked Then
            iFlg = 2
        ElseIf Me.RadioOverpack.Checked Then
            iFlg = 3
        ElseIf Me.RadioPallett.Checked Then
            iFlg = 4
        End If

        Me.txtItem.Focus()
    End Sub

    '***************************************************************************
    'This event fires when an item is scanned in
    '***************************************************************************
    Private Sub txtItem_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItem.KeyUp
        Try
            If e.KeyValue = 13 Then
                Me.lstItems.Items.Add(Me.txtItem.Text)
                Me.txtItem.Text = ""
                Me.txtItem.Focus()
            End If
        Catch ex As Exception
            MsgBox("frmFGTransfer.txtItem_KeyUp: " & ex.Message.ToString, MsgBoxStyle.Critical, "Scan in the Items")
        End Try
    End Sub
    '**********************************************************
    Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
        Dim i As Integer = 0
        Dim j As Integer = 0

        Me.btnTransfer.Enabled = False
        Cursor.Current = Cursors.WaitCursor

        If iFlg = 0 Then
            MsgBox("Please select an option.", MsgBoxStyle.Information, "Transfer to Finished Goods")
            Me.btnTransfer.Enabled = True
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        If Me.lstItems.Items.Count = 0 Then
            MsgBox("Please scan in items to ship.", MsgBoxStyle.Information, "Transfer to Finished Goods")
            Me.btnTransfer.Enabled = True
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        try
            For j = 0 To Me.lstItems.Items.Count - 1
                'Update the tdevice table
                i = objMisc.UpdateDevice(iFlg, Me.lstItems.Items(j))
            Next j

            If i > 0 Then
                MsgBox("Items have been successfully transferred to finished goods status.", MsgBoxStyle.Information, "Transfer to Finished Goods")
            Else
                MsgBox("Transfer unsuccessful.", MsgBoxStyle.Information, "Transfer to Finished Goods")
            End If

            Me.lstItems.Items.Clear()
            Me.lstItems.Refresh()

        Catch ex As Exception
            MsgBox("frmFGTransfer.btnTransfer_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Transfer to Finished Goods")
        Finally
            Me.btnTransfer.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    '**********************************************************
    Protected Overrides Sub Finalize()
        objMisc = Nothing
        MyBase.Finalize()
    End Sub
    '**********************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If Me.lstItems.Items.Count > 0 Then
            Me.lstItems.Items.Clear()
            Me.lstItems.Refresh()
        End If
    End Sub
    '**********************************************************
    Private Sub btnClearOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearOne.Click
        If Me.lstItems.SelectedIndex <> -1 Then    'If nothing is selected
            Me.lstItems.Items.RemoveAt(Me.lstItems.SelectedIndex)
            Me.lstItems.Refresh()
        End If
    End Sub
    '**********************************************************

    Private Sub btnUnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnTransfer.Click
        Dim i As Integer = 0
        Dim j As Integer = 0

        Me.btnUnTransfer.Enabled = False
        Cursor.Current = Cursors.WaitCursor

        If iFlg = 0 Then
            MsgBox("Please select an option.", MsgBoxStyle.Information, "Move from Finished Goods Back to Floor")
            Me.btnUnTransfer.Enabled = True
            Cursor.Current = Cursors.Default
            Exit Sub
        End If
        If Me.lstItems.Items.Count = 0 Then
            MsgBox("Please scan in items to ship.", MsgBoxStyle.Information, "Move from Finished Goods Back to Floor")
            Me.btnUnTransfer.Enabled = True
            Cursor.Current = Cursors.Default
            Exit Sub
        End If

        Try
            For j = 0 To Me.lstItems.Items.Count - 1
                'Update the tdevice table
                i = objMisc.UpdateDevice(iFlg, Me.lstItems.Items(j), 1)
            Next j
            If i > 0 Then
                MsgBox("Move successful.", MsgBoxStyle.Information, "Move from Finished Goods Back to Floor")
            Else
                MsgBox("Move unsuccessful.", MsgBoxStyle.Information, "Move from Finished Goods Back to Floor")
            End If
            Me.lstItems.Items.Clear()
            Me.lstItems.Refresh()

        Catch ex As Exception
            MsgBox("frmFGTransfer.btnUnTransfer_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Move from Finished Goods Back to Floor")
        Finally
            Me.btnUnTransfer.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub frmFGTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.RadioPallett.Checked = True
    End Sub
End Class
