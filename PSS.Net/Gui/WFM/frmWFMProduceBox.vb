Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Data.Interfaces

Public Class frmWFMProduceBox
    Inherits System.Windows.Forms.Form

    Private _iCustID As Integer = 0
    Private _iLocID As Integer = 0
    Private _strFormTitle As String = ""
    Private _objWFMProduce As WFMProduce
    Private _dt As DataTable
    Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strScreenName As String)
        MyBase.New()


        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._iCustID = iCust_ID
        Me._iLocID = iLoc_ID
        Me._strFormTitle = strScreenName
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
    Friend WithEvents txtBoxNo As System.Windows.Forms.TextBox
    Friend WithEvents lblBoxNo As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents grpBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents btnProduce As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblWorkstation As System.Windows.Forms.Label
    Friend WithEvents lblModelVal As System.Windows.Forms.Label
    Friend WithEvents lblQtyVal As System.Windows.Forms.Label
    Friend WithEvents lblWorkstationVal As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtBoxNo = New System.Windows.Forms.TextBox()
        Me.lblBoxNo = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.grpBox1 = New System.Windows.Forms.GroupBox()
        Me.lblWorkstationVal = New System.Windows.Forms.Label()
        Me.lblQtyVal = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.lblWorkstation = New System.Windows.Forms.Label()
        Me.lblModelVal = New System.Windows.Forms.Label()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.btnProduce = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grpBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBoxNo
        '
        Me.txtBoxNo.BackColor = System.Drawing.Color.White
        Me.txtBoxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBoxNo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxNo.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtBoxNo.Location = New System.Drawing.Point(136, 72)
        Me.txtBoxNo.Name = "txtBoxNo"
        Me.txtBoxNo.Size = New System.Drawing.Size(272, 21)
        Me.txtBoxNo.TabIndex = 0
        Me.txtBoxNo.Text = ""
        '
        'lblBoxNo
        '
        Me.lblBoxNo.BackColor = System.Drawing.Color.Transparent
        Me.lblBoxNo.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxNo.ForeColor = System.Drawing.Color.Black
        Me.lblBoxNo.Location = New System.Drawing.Point(136, 48)
        Me.lblBoxNo.Name = "lblBoxNo"
        Me.lblBoxNo.Size = New System.Drawing.Size(184, 21)
        Me.lblBoxNo.TabIndex = 161
        Me.lblBoxNo.Text = "Box Number:"
        Me.lblBoxNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(360, 24)
        Me.lblTitle.TabIndex = 162
        '
        'lblModel
        '
        Me.lblModel.BackColor = System.Drawing.Color.Transparent
        Me.lblModel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.ForeColor = System.Drawing.Color.Black
        Me.lblModel.Location = New System.Drawing.Point(16, 24)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(56, 21)
        Me.lblModel.TabIndex = 164
        Me.lblModel.Text = "Model:"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpBox1
        '
        Me.grpBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWorkstationVal, Me.lblQtyVal, Me.lblQty, Me.lblModel, Me.lblWorkstation, Me.lblModelVal})
        Me.grpBox1.Location = New System.Drawing.Point(24, 8)
        Me.grpBox1.Name = "grpBox1"
        Me.grpBox1.Size = New System.Drawing.Size(272, 120)
        Me.grpBox1.TabIndex = 165
        Me.grpBox1.TabStop = False
        '
        'lblWorkstationVal
        '
        Me.lblWorkstationVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblWorkstationVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWorkstationVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkstationVal.Location = New System.Drawing.Point(112, 88)
        Me.lblWorkstationVal.Name = "lblWorkstationVal"
        Me.lblWorkstationVal.Size = New System.Drawing.Size(120, 24)
        Me.lblWorkstationVal.TabIndex = 173
        Me.lblWorkstationVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQtyVal
        '
        Me.lblQtyVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblQtyVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblQtyVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQtyVal.Location = New System.Drawing.Point(72, 56)
        Me.lblQtyVal.Name = "lblQtyVal"
        Me.lblQtyVal.Size = New System.Drawing.Size(160, 24)
        Me.lblQtyVal.TabIndex = 172
        Me.lblQtyVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblQty
        '
        Me.lblQty.BackColor = System.Drawing.Color.Transparent
        Me.lblQty.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.ForeColor = System.Drawing.Color.Black
        Me.lblQty.Location = New System.Drawing.Point(16, 56)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(48, 21)
        Me.lblQty.TabIndex = 166
        Me.lblQty.Text = "Qty:"
        Me.lblQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkstation
        '
        Me.lblWorkstation.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkstation.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkstation.ForeColor = System.Drawing.Color.Black
        Me.lblWorkstation.Location = New System.Drawing.Point(16, 88)
        Me.lblWorkstation.Name = "lblWorkstation"
        Me.lblWorkstation.Size = New System.Drawing.Size(104, 21)
        Me.lblWorkstation.TabIndex = 168
        Me.lblWorkstation.Text = "Disposition:"
        Me.lblWorkstation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblModelVal
        '
        Me.lblModelVal.BackColor = System.Drawing.SystemColors.Info
        Me.lblModelVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblModelVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelVal.Location = New System.Drawing.Point(72, 24)
        Me.lblModelVal.Name = "lblModelVal"
        Me.lblModelVal.Size = New System.Drawing.Size(160, 24)
        Me.lblModelVal.TabIndex = 171
        Me.lblModelVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtSN
        '
        Me.txtSN.BackColor = System.Drawing.Color.White
        Me.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSN.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtSN.Location = New System.Drawing.Point(24, 168)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(272, 21)
        Me.txtSN.TabIndex = 1
        Me.txtSN.Text = ""
        '
        'lblSN
        '
        Me.lblSN.BackColor = System.Drawing.Color.Transparent
        Me.lblSN.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.ForeColor = System.Drawing.Color.Black
        Me.lblSN.Location = New System.Drawing.Point(24, 144)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(184, 21)
        Me.lblSN.TabIndex = 167
        Me.lblSN.Text = "Check a SN in the Box:"
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnProduce
        '
        Me.btnProduce.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProduce.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnProduce.Location = New System.Drawing.Point(248, 304)
        Me.btnProduce.Name = "btnProduce"
        Me.btnProduce.Size = New System.Drawing.Size(160, 40)
        Me.btnProduce.TabIndex = 5
        Me.btnProduce.Text = "PRODUCE"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(136, 304)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(88, 40)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "Clear"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSN, Me.txtSN, Me.grpBox1})
        Me.Panel1.Location = New System.Drawing.Point(112, 96)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(304, 208)
        Me.Panel1.TabIndex = 170
        '
        'frmWFMProduceBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(680, 478)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.btnClear, Me.btnProduce, Me.lblTitle, Me.txtBoxNo, Me.lblBoxNo})
        Me.Name = "frmWFMProduceBox"
        Me.Text = "frmWFMProduceBox"
        Me.grpBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmWFMProduceBox_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Dim ctrl As Control
        'For Each ctrl In Me.Controls
        '    ctrl.Visible = False
        'Next
        'Exit Sub

        Try
            PSS.Core.Highlight.SetHighLight(Me)
            Me.lblTitle.Text = Me._strFormTitle

            Me.Panel1.Enabled = False : Me.btnProduce.Enabled = False : Me.btnClear.Enabled = False

            Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtBoxNo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxNo.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtBoxNo.Text.Trim.Length > 0 Then
                Me.ProcessBox()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtBoxNo_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub ProcessBox()
        Dim strBoxNo As String = Me.txtBoxNo.Text.Trim
        Dim row As DataRow

        Try
            Me._objWFMProduce = New WFMProduce()

            If strBoxNo.Length = 0 Then
                MessageBox.Show("Please enter a box number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus() : Exit Sub
            End If

            Me._dt = Me._objWFMProduce.GetDeviceNTFDataByBoxName(Me._iLocID, strBoxNo)

            If Me._dt.Rows.Count = 0 Then
                MessageBox.Show("Can't find the box. Enter a valid box number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            ElseIf Not Me.IsAQLPassedAndCompleted(Me._dt) Then
                MessageBox.Show("Box is not AQL passed or not AQL completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            ElseIf Me._dt.Rows(0).IsNull("quantity") OrElse Trim(Me._dt.Rows(0).Item("quantity")).ToString.Length = 0 Then
                MessageBox.Show("Device quantity in the box has no value.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            ElseIf Me._dt.Rows(0).IsNull("workstation") OrElse Trim(Me._dt.Rows(0).Item("workstation")).Length = 0 _
                   OrElse Not Trim(Me._dt.Rows(0).Item("workstation")).ToUpper = "Produce".ToUpper _
                   OrElse Not Me._dt.Rows(0).Item("Cellopt_WIPOwner") = 4 Then
                MessageBox.Show("Invalid box workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            ElseIf Not Me.MultipleWipOwnerIDsInBox(Me._dt) Then
                MessageBox.Show("Multiple WIP owner IDs in the box. Can't process it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            ElseIf Not Me.MultipleWorkStationsInBox(Me._dt) Then
                MessageBox.Show("Multiple workstations in the box. Can't process it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            ElseIf Not Trim(Me._dt.Rows(0).Item("Disposition")).ToUpper = "ntf".ToUpper Then
                MessageBox.Show("Not a NTF box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            ElseIf Trim(Me._dt.Rows(0).Item("Disposition")).ToUpper = "ntf".ToUpper AndAlso Not Me._dt.Rows(0).Item("disp_id") = 5 Then
                MessageBox.Show("Invalid box workstation (Disposition is NTF, but Disposition ID is not 5).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            ElseIf Not Me._dt.Rows(0).Item("quantity") = Me._dt.Rows.Count Then
                MessageBox.Show("Box Qty (" & Me._dt.Rows(0).Item("quantity") & ") does not match the total numbers (" & Me._dt.Rows.Count.ToString & ") of devices.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
            Else
                For Each row In Me._dt.Rows
                    If Trim(row("HasBillcode")).ToUpper = "Yes".ToUpper Then
                        MessageBox.Show("Some device(s) in the box has billcode. Can't process the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus() : Exit Sub
                    End If
                Next

                Me.lblModelVal.Text = Me._dt.Rows(0).Item("Model_Desc")
                Me.lblQtyVal.Text = Me._dt.Rows(0).Item("quantity")
                Me.lblWorkstationVal.Text = Me._dt.Rows(0).Item("Disposition")

                Me.Panel1.Enabled = True
                Me.txtBoxNo.Enabled = False
                Me.btnClear.Enabled = True
                Me.txtSN.SelectAll() : Me.txtSN.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me._objWFMProduce = Nothing
        End Try
    End Sub

    Private Function IsAQLPassedAndCompleted(ByVal dt As DataTable) As Boolean
        Dim row As DataRow
        Dim bPassed As Boolean = False

        Try
            For Each row In dt.Rows
                If Not row.IsNull("pallet_qc_passed") AndAlso row("pallet_qc_passed") = 1 Then
                    bPassed = True
                Else
                    bPassed = False : Exit For
                End If
            Next
			Return bPassed
		Catch ex As Exception
			MessageBox.Show(ex.ToString, "IsAQLPassedAndCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
    End Function

    Private Function MultipleWorkStationsInBox(ByVal dt As DataTable) As Boolean
        Dim row As DataRow
        Dim bPassed As Boolean = False
		Try
			For Each row In dt.Rows
				If Not row.IsNull("Workstation") AndAlso Trim(row("Workstation")).ToUpper = "Produce".ToUpper Then
					bPassed = True
				Else
					bPassed = False : Exit For
				End If
			Next
			Return bPassed

		Catch ex As Exception
			MessageBox.Show(ex.ToString, "MultipleWorkStations", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
		End Try
    End Function

    Private Function MultipleWipOwnerIDsInBox(ByVal dt As DataTable) As Boolean
        Dim row As DataRow
        Dim bPassed As Boolean = False

        Try
            For Each row In dt.Rows
                If Not row.IsNull("Cellopt_WIPOwner") AndAlso row("Cellopt_WIPOwner") = 4 Then
                    bPassed = True
                Else
                    bPassed = False : Exit For
                End If
            Next

            Return bPassed

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "MultipleWipOwnerIDsInBox", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Function

    Private Sub ResetAndClear()
        Try
            Me._dt = Nothing
            Me.txtBoxNo.Text = ""
            Me.txtSN.Text = ""
            Me.lblModelVal.Text = ""
            Me.lblQtyVal.Text = ""
            Me.lblWorkstationVal.Text = ""
            Me.Panel1.Enabled = False
            Me.btnClear.Enabled = False
            Me.btnProduce.Enabled = False
            Me.txtBoxNo.Enabled = True
            Me.txtBoxNo.SelectAll() : Me.txtBoxNo.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "ResetAndClear", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        Try
            If e.KeyCode = Keys.Enter AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                Dim row As DataRow
                Dim arrLst As New ArrayList()
                Dim strSN As String = Me.txtSN.Text.Trim
                For Each row In Me._dt.Rows
                    arrLst.Add(row("Device_SN"))
                Next
                If Not arrLst.Contains(strSN) Then
                    MessageBox.Show("SN is not in the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    Exit Sub
                End If

                Me.btnProduce.Enabled = True : Me.btnProduce.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.ResetAndClear()
    End Sub

    Private Sub btnProduce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProduce.Click
        Dim _tdb As New Data.BLL.WFMBilling(Me._UserID)
        Dim iDevice_ID As Integer = 0, iDisp_ID As Integer = 0
        Dim row As DataRow
        Dim iNextWipOwnerID As Integer = 5
        Dim strNextWorkStation As String = "WH-FLOOR"
		Dim strDatetime As String = Format(Now(), "yyyy-MM-dd HH:mm:ss")
        Dim _pallet_id As Integer = 0 ' _dt.Rows(0).Item("pallett_id")
        Dim vCarrierUnlockLaborCharge As Single = 0.0
        Dim iCarrierUnlockBillCode_ID As Integer = 0
        Dim dtCarrierUnlock As DataTable
        Dim arrList_CarrierUnlockChargeModelIDs As New ArrayList()
        Dim bCarrierUnluckCharge As Boolean = False

        Try
            If Me._dt.Rows.Count > 0 AndAlso Me.txtBoxNo.Text.Trim.Length > 0 AndAlso Me.txtSN.Text.Trim.Length > 0 Then

                Me._objWFMProduce = New WFMProduce()
                _pallet_id = _dt.Rows(0).Item("pallett_id")
                arrList_CarrierUnlockChargeModelIDs = Me._objWFMProduce.getWFMCarrierUnlockModels

                If arrList_CarrierUnlockChargeModelIDs.Contains(Trim(_dt.Rows(0).Item("model_id")).ToString) Then
                    dtCarrierUnlock = Me._objWFMProduce.getCarrierUnlockCharge
                    If dtCarrierUnlock.Rows.Count = 0 Then
                        Throw New Exception("Can't find carrier unluck labor charge data.") : Exit Sub
                    ElseIf dtCarrierUnlock.Rows.Count > 1 Then
                        Throw New Exception("Invalid carrier unluck labor charge data.") : Exit Sub
                    Else
                        vCarrierUnlockLaborCharge = dtCarrierUnlock.Rows(0).Item("tcab_Amount")
                        iCarrierUnlockBillCode_ID = dtCarrierUnlock.Rows(0).Item("Billcode_ID")
                    End If
                    bCarrierUnluckCharge = True
                End If

                For Each row In Me._dt.Rows
                    iDevice_ID = row("Device_ID") : iDisp_ID = row("disp_id")
                    If Not _tdb.AddLaborCharges(PSS.Data.Interfaces.BILLING_POINT.PRODUCED, iDevice_ID, iDisp_ID) Then
                        Throw New Exception("Unable to apply Labor Charges one or more devices.") : Exit Sub
                    End If

                    If bCarrierUnluckCharge Then
                        Me._objWFMProduce.AddCarrierUnlockCharge(vCarrierUnlockLaborCharge, iDevice_ID, iCarrierUnlockBillCode_ID, Me._UserID, strDatetime, False)
                    End If

                    Me._objWFMProduce.UpdateWorkStation(iDevice_ID, iNextWipOwnerID, strNextWorkStation, strDatetime)
                Next
                _objWFMProduce.PalletShippedUpdate(_pallet_id)
                Me.ResetAndClear()
            Else
                MessageBox.Show("Enter valid data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnProduce_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            _tdb = Nothing
            Me._objWFMProduce = Nothing
        End Try
    End Sub
End Class
