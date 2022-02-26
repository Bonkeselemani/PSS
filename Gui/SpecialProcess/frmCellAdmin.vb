Option Explicit On 

Public Class frmCellAdmin
    Inherits System.Windows.Forms.Form

    Private objCellAdmin As PSS.Data.Buisness.CellAdmin

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objCellAdmin = New PSS.Data.Buisness.CellAdmin()

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
    Friend WithEvents btnReOpenWHPallet As System.Windows.Forms.Button
    Friend WithEvents btnByPassQCForRWPallet As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnByPassQCForRWPallet = New System.Windows.Forms.Button()
        Me.btnReOpenWHPallet = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnByPassQCForRWPallet
        '
        Me.btnByPassQCForRWPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnByPassQCForRWPallet.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnByPassQCForRWPallet.Location = New System.Drawing.Point(8, 56)
        Me.btnByPassQCForRWPallet.Name = "btnByPassQCForRWPallet"
        Me.btnByPassQCForRWPallet.Size = New System.Drawing.Size(192, 32)
        Me.btnByPassQCForRWPallet.TabIndex = 1
        Me.btnByPassQCForRWPallet.Text = "BY PASS QC FOR RE-WORK PALLET"
        '
        'btnReOpenWHPallet
        '
        Me.btnReOpenWHPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReOpenWHPallet.ForeColor = System.Drawing.Color.Black
        Me.btnReOpenWHPallet.Location = New System.Drawing.Point(8, 8)
        Me.btnReOpenWHPallet.Name = "btnReOpenWHPallet"
        Me.btnReOpenWHPallet.Size = New System.Drawing.Size(192, 32)
        Me.btnReOpenWHPallet.TabIndex = 0
        Me.btnReOpenWHPallet.Text = "RE-OPEN WAREHOUSE PALLET"
        '
        'frmCellAdmin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(456, 266)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReOpenWHPallet, Me.btnByPassQCForRWPallet})
        Me.Name = "frmCellAdmin"
        Me.Text = "Cellular Administration"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnReOpenWHPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReOpenWHPallet.Click
        Dim i As Integer
        Dim strWHPallet_Name As String

        Try
            strWHPallet_Name = InputBox("Enter Warehouse Pallet:", "Get Warehouse Pallet Name")

            If strWHPallet_Name = "" Then
                Exit Sub
            End If

            i = Me.objCellAdmin.ReOpenWarehousepallet(strWHPallet_Name)

            If i > 0 Then
                MessageBox.Show("Pallet is now open.", "Re-Open Warehouse Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Re-Open Warehousepallet ClickEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************
    Private Sub btnByPassQCForRWPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnByPassQCForRWPallet.Click
        Dim i As Integer
        Dim strRecPallet_Name As String

        Try
            strRecPallet_Name = InputBox("Enter Received Pallet Name:", "Get Received Pallet Name")

            If strRecPallet_Name = "" Then
                Exit Sub
            End If

            If InStr(1, UCase(Trim(strRecPallet_Name)), "RW") = 0 Then
                MessageBox.Show("Pallet is not a rework pallet.", "Re-Open Warehouse Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            i = Me.objCellAdmin.ByPassQCByReWorkPallet(strRecPallet_Name)

            If i > 0 Then
                MessageBox.Show("Pallet is now ready to ship.", "By Pass QC for Rework Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "By Pass QC for Rework Pallet ClickEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************

End Class
