Imports System.Threading
Imports System.Drawing.Printing.PrintDocument
Imports System.Windows.Forms.DataGrid

Namespace Gui

	Public Class frmTrnasferBoxes
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
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label4 As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents dgBoxes As System.Windows.Forms.DataGrid
		Friend WithEvents txtBoxID As System.Windows.Forms.TextBox
		Friend WithEvents lblFrom As System.Windows.Forms.Label
		Friend WithEvents lblTo As System.Windows.Forms.Label
		Friend WithEvents btnTransfer As System.Windows.Forms.Button
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
		Friend WithEvents lblRecCnt As System.Windows.Forms.Label
		Friend WithEvents lblBoxCntText As System.Windows.Forms.Label
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents lblDup As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.dgBoxes = New System.Windows.Forms.DataGrid()
			Me.txtBoxID = New System.Windows.Forms.TextBox()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.lblFrom = New System.Windows.Forms.Label()
			Me.lblTo = New System.Windows.Forms.Label()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.btnTransfer = New System.Windows.Forms.Button()
			Me.lblBoxCntText = New System.Windows.Forms.Label()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.StatusBar1 = New System.Windows.Forms.StatusBar()
			Me.lblRecCnt = New System.Windows.Forms.Label()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.lblDup = New System.Windows.Forms.Label()
			CType(Me.dgBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'dgBoxes
			'
			Me.dgBoxes.AllowNavigation = False
			Me.dgBoxes.AlternatingBackColor = System.Drawing.Color.PowderBlue
			Me.dgBoxes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.dgBoxes.DataMember = ""
			Me.dgBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.dgBoxes.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.dgBoxes.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.dgBoxes.Location = New System.Drawing.Point(16, 128)
			Me.dgBoxes.Name = "dgBoxes"
			Me.dgBoxes.Size = New System.Drawing.Size(776, 350)
			Me.dgBoxes.TabIndex = 1
			'
			'txtBoxID
			'
			Me.txtBoxID.AutoSize = False
			Me.txtBoxID.BackColor = System.Drawing.Color.Yellow
			Me.txtBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtBoxID.Location = New System.Drawing.Point(16, 96)
			Me.txtBoxID.Name = "txtBoxID"
			Me.txtBoxID.Size = New System.Drawing.Size(312, 24)
			Me.txtBoxID.TabIndex = 0
			Me.txtBoxID.Text = ""
			'
			'Label1
			'
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.Location = New System.Drawing.Point(16, 72)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(312, 23)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "Box to Add"
			'
			'lblFrom
			'
			Me.lblFrom.BackColor = System.Drawing.Color.Wheat
			Me.lblFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblFrom.Location = New System.Drawing.Point(136, 24)
			Me.lblFrom.Name = "lblFrom"
			Me.lblFrom.Size = New System.Drawing.Size(264, 23)
			Me.lblFrom.TabIndex = 3
			Me.lblFrom.Text = "WH-WIP"
			Me.lblFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblTo
			'
			Me.lblTo.BackColor = System.Drawing.Color.Wheat
			Me.lblTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.lblTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblTo.Location = New System.Drawing.Point(456, 24)
			Me.lblTo.Name = "lblTo"
			Me.lblTo.Size = New System.Drawing.Size(264, 23)
			Me.lblTo.TabIndex = 4
			Me.lblTo.Text = "PRODUCTION STAGING"
			Me.lblTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'Label4
			'
			Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label4.Location = New System.Drawing.Point(16, 24)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(96, 23)
			Me.Label4.TabIndex = 5
			Me.Label4.Text = "Transfer from "
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'Label5
			'
			Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label5.Location = New System.Drawing.Point(416, 24)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(24, 23)
			Me.Label5.TabIndex = 6
			Me.Label5.Text = "To"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'btnTransfer
			'
			Me.btnTransfer.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
			Me.btnTransfer.Location = New System.Drawing.Point(16, 496)
			Me.btnTransfer.Name = "btnTransfer"
			Me.btnTransfer.Size = New System.Drawing.Size(120, 32)
			Me.btnTransfer.TabIndex = 8
			Me.btnTransfer.Text = "Transfer"
			'
			'lblBoxCntText
			'
			Me.lblBoxCntText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBoxCntText.ForeColor = System.Drawing.Color.Blue
			Me.lblBoxCntText.Location = New System.Drawing.Point(376, 96)
			Me.lblBoxCntText.Name = "lblBoxCntText"
			Me.lblBoxCntText.Size = New System.Drawing.Size(104, 24)
			Me.lblBoxCntText.TabIndex = 10
			Me.lblBoxCntText.Text = "Box Count"
			Me.lblBoxCntText.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'btnClear
			'
			Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
			Me.btnClear.Location = New System.Drawing.Point(184, 496)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(120, 32)
			Me.btnClear.TabIndex = 11
			Me.btnClear.Text = "Clear"
			'
			'StatusBar1
			'
			Me.StatusBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.StatusBar1.Location = New System.Drawing.Point(0, 568)
			Me.StatusBar1.Name = "StatusBar1"
			Me.StatusBar1.Size = New System.Drawing.Size(808, 22)
			Me.StatusBar1.TabIndex = 12
			Me.StatusBar1.Text = "   This screen is used to transfer multiple boxes to Production Staging."
			'
			'lblRecCnt
			'
			Me.lblRecCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblRecCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblRecCnt.ForeColor = System.Drawing.Color.Blue
			Me.lblRecCnt.Location = New System.Drawing.Point(496, 96)
			Me.lblRecCnt.Name = "lblRecCnt"
			Me.lblRecCnt.Size = New System.Drawing.Size(64, 24)
			Me.lblRecCnt.TabIndex = 13
			Me.lblRecCnt.Text = "0"
			Me.lblRecCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'lblMsg
			'
			Me.lblMsg.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Blue
			Me.lblMsg.Location = New System.Drawing.Point(16, 536)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(232, 16)
			Me.lblMsg.TabIndex = 14
			'
			'lblDup
			'
			Me.lblDup.BackColor = System.Drawing.Color.Red
			Me.lblDup.ForeColor = System.Drawing.Color.White
			Me.lblDup.Location = New System.Drawing.Point(336, 96)
			Me.lblDup.Name = "lblDup"
			Me.lblDup.Size = New System.Drawing.Size(32, 16)
			Me.lblDup.TabIndex = 15
			Me.lblDup.Text = "Dup"
			Me.lblDup.Visible = False
			'
			'frmTrnasferBoxes
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
			Me.ClientSize = New System.Drawing.Size(808, 590)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDup, Me.lblMsg, Me.lblRecCnt, Me.StatusBar1, Me.btnClear, Me.lblBoxCntText, Me.btnTransfer, Me.Label5, Me.Label4, Me.lblTo, Me.lblFrom, Me.Label1, Me.txtBoxID, Me.dgBoxes})
			Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.ForeColor = System.Drawing.Color.Black
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.MinimumSize = New System.Drawing.Size(816, 600)
			Me.Name = "frmTrnasferBoxes"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Transfer Boxes"
			CType(Me.dgBoxes, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"

		Dim _dt As New DataTable()
		Dim _objTFMisc As Data.Buisness.TracFone.clsMisc

#End Region
#Region "FORM EVENTS"

		Private Sub frmTrnasferBoxes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			BuildTable()
			_dt.TableName = "Boxes"
			dgBoxes.ReadOnly = True
			dgBoxes.AllowNavigation = False
			Me.dgBoxes.DataSource = _dt
			CreateTableStyles()
			txtBoxID.Focus()
		End Sub

#End Region
#Region "CONTROL EVENTS"

		Private Sub txtBoxID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxID.KeyUp
			If e.KeyValue = Keys.Enter Then
				AddBoxIDToList()
				SetRecordCount()
			End If
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			If MessageBox.Show("Clear the screen?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
				ClearTheScreen()
			End If
		End Sub
		Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
			If Me.lblRecCnt.Text = "0" Then
				MessageBox.Show("No boxes have been entered.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			ElseIf MessageBox.Show("Transfer the validated boxes now?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
				Dim x As Integer = 0
				x = TransferBoxes()
				MessageBox.Show(x.ToString() & " Boxes have transfered successfully.", Me.Text, MessageBoxButtons.OK)
			End If
		End Sub

#End Region
#Region "METHODS"

		Private Sub BuildTable()
			_dt.Columns.Add("Box")
			_dt.Columns.Add("BoxQty", Type.GetType("System.Int16"))
			_dt.Columns.Add("ValidationResults")
			Dim unqCol As UniqueConstraint = _
			 New UniqueConstraint(New DataColumn() {_dt.Columns("Box")})
			_dt.Constraints.Add(unqCol)
		End Sub
		Private Sub AddBoxIDToList()
			Try
				If txtBoxID.Text.Trim() <> "" Then
					Dim _boxQty As Int16
					_boxQty = GetBoxQty(txtBoxID.Text.Trim)
					Dim _dr As DataRow = _dt.NewRow()
					_dr("Box") = txtBoxID.Text
					_dr("BoxQty") = _boxQty
					_dr("ValidationResults") = ""
					_dt.Rows.Add(_dr)
				End If
			Catch ex As Exception
				Beep()
				Beep()
				If ex.Message.IndexOf("unique") > 0 Then
					lblDup.Visible = True
					Me.Refresh()
					Thread.Sleep(1000)
					lblDup.Visible = False
					Me.Refresh()
				End If
			Finally
				txtBoxID.Text = ""
			End Try
		End Sub
		Private Function GetBoxQty(ByVal BoxNr As String) As Int16
			Try
				Return Misc.GetBoxQty(BoxNr)
			Catch
				Return 0
			End Try
		End Function
		Friend Sub CreateTableStyles()

			' Create a new DataGridTableStyle and set
			' its MappingName to the TableName of a DataTable. 
			Dim ts1 As New DataGridTableStyle()
			ts1.MappingName = "Boxes"

			' Add a GridColumnStyle and set its MappingName
			' to the name of a DataColumn in the DataTable.
			' Set the HeaderText and Width properties. 
			Dim ColBox As New DataGridTextBoxColumn()
			ColBox.MappingName = "Box"
			ColBox.HeaderText = "Box"
			ColBox.Width = 180
			ColBox.ReadOnly = True
			ts1.GridColumnStyles.Add(ColBox)


			Dim ColBoxQty As New DataGridTextBoxColumn()
			ColBoxQty.MappingName = "BoxQty"
			ColBoxQty.HeaderText = "Box Qty"
			ColBoxQty.Width = 180
			ColBoxQty.ReadOnly = True
			ts1.GridColumnStyles.Add(ColBoxQty)

			Dim ColValidation As New DataGridTextBoxColumn()
			ColValidation.MappingName = "ValidationResults"
			ColValidation.HeaderText = "Validation Results"
			ColValidation.Width = 500
			ColValidation.ReadOnly = True
			ts1.GridColumnStyles.Add(ColValidation)

			' Addtional Formatting.
			'ts1.ForeColor = Color.Black
			ts1.AlternatingBackColor = Color.White
			ts1.BackColor = Color.AliceBlue
			ts1.PreferredRowHeight = 20
			ts1.ReadOnly = True
			ts1.AllowSorting = True
			ts1.ResetForeColor()

			' Add the DataGridTableStyle objects to the collection.
			dgBoxes.TableStyles.Add(ts1)

		End Sub
		Private Sub ClearTheScreen()
			txtBoxID.Text = ""
			lblMsg.Text = ""
			_dt.Rows.Clear()
			dgBoxes.Refresh()
			SetRecordCount()
		End Sub
		Private Sub SetRecordCount()
			lblRecCnt.Text = _dt.Rows.Count.ToString()
		End Sub
		Private Function TransferBoxes() As Integer
			' VALIDATE
			Dim dr As DataRow
			Dim _xfrCnt As Integer = 0
			For Each dr In _dt.Rows()
				lblMsg.Text = "Validating boxes ..."
				Dim _box = dr("box").ToString()
				Dim _validation As String = ValidateBox(_box)
				Dim _col As DataColumn
				For Each _col In _dt.Columns
					Dim cname As String = _col.ColumnName
					If cname = "ValidationResults" Then
						dr.BeginEdit()
						dr("ValidationResults") = _validation
						dr.AcceptChanges()
						Thread.Sleep(500)
						dgBoxes.Refresh()
						Me.Refresh()
					End If
				Next
			Next
			' TRANSFER
			For Each dr In _dt.Rows()
				lblMsg.Text = "Transfering boxes ..."
				Dim _box = dr("box").ToString()
				Dim _validation As String = ValidateBox(_box)
				Dim _col As DataColumn
				If dr("ValidationResults") = "Valid" Then
					Dim strNextStation As String = Data.Buisness.Generic.GetNextWorkStationInWFP("TRANSFER BOXES", 0, _
	   Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
					_objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
					Dim i As Integer
					i = Me._objTFMisc.PushWBBoxToWorkArea(dr(0).ToString().Trim, strNextStation, Core.ApplicationUser.IDuser, "TRANSFER BOXES", Me.Name)
					For Each _col In _dt.Columns
						Dim cname As String = _col.ColumnName
						If cname = "ValidationResults" Then
							dr.BeginEdit()
							dr("ValidationResults") = "Transfered"
							dr.AcceptChanges()
							_xfrCnt += 1
							Thread.Sleep(500)
							dgBoxes.Refresh()
						End If
					Next
				End If
			Next
			' CLEAN UP
			RemoveTransferBoxes()
			lblMsg.Text = ""
			SetRecordCount()
			Return _xfrCnt
		End Function
		Private Function ValidateBox(ByVal box As String) As String
			Dim _validation As String
			_validation = ProcessBox_Staging_Pretest_Prebill_Obsolete_ProdHold(box, lblFrom.Text, "TRANSFER BOXES")
			Return _validation
		End Function
		Private Function ProcessBox_Staging_Pretest_Prebill_Obsolete_ProdHold(ByVal Box As String, ByVal ws As String, ByVal newWs As String) As String
			Dim dt As DataTable
			Dim _retVal As String
			Try

				Dim _clsMisc = New PSS.Data.Buisness.TracFone.clsMisc()
				dt = _clsMisc.GetBoxStationCount(Box)

				If dt.Rows.Count = 0 Then
					_retVal = "This Box ID does not exist."
				ElseIf (dt.Rows.Count > 1) Then
					_retVal = "This Box ID has units of multiple workstation or multiple model."
				ElseIf dt.Rows(0)("Closed").ToString = "0" Then
					_retVal = "Box is still open."
				Else
					If dt.Rows(0)("WorkStation").ToString.Trim.Length = 0 Then
						_retVal = "This Box does not belong to any workstation."
					Else
						_retVal = Misc.ValidateFrStationOfScreenInWorkFlow2("TRANSFER BOXES", _
						 dt.Rows(0)("WorkStation").ToString.Trim, _
						 PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, 0)
					End If
				End If
				Return _retVal

			Catch ex As Exception
				Throw ex
			Finally
				Data.Buisness.Generic.DisposeDT(dt)
			End Try
		End Function
		Private Sub RemoveTransferBoxes()
			Dim _dt2 As New DataTable()
			_dt2 = _dt.Clone()
			Dim dr As DataRow
			For Each dr In _dt.Rows()
				Dim _box = dr("box").ToString()
				Dim _result = dr("ValidationResults").ToString()
				If _result <> "Transfered" Then
					_dt2.LoadDataRow(dr.ItemArray, True)
				End If
			Next
			_dt2.AcceptChanges()
			_dt = _dt2.Copy()
			dgBoxes.DataSource = _dt
			_dt2.Dispose()
		End Sub

#End Region
	End Class

End Namespace
