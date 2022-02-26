Imports System.Threading
Imports System.Drawing.Printing.PrintDocument
Imports System.Windows.Forms.DataGrid
Imports PSS.Data
Imports System.IO

Namespace Gui.Warehouse
	Public Class frmWhToStaging
		Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

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
		Friend WithEvents lblRecCnt As System.Windows.Forms.Label
		Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
		Friend WithEvents lblBoxCntText As System.Windows.Forms.Label
		Friend WithEvents Label5 As System.Windows.Forms.Label
		Friend WithEvents dgBoxes As System.Windows.Forms.DataGrid
		Friend WithEvents cboDisposition As System.Windows.Forms.ComboBox
		Friend WithEvents cboLobLoc As System.Windows.Forms.ComboBox
		Friend WithEvents txtBox As System.Windows.Forms.TextBox
		Friend WithEvents btnTransfer As System.Windows.Forms.Button
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents pnlBody As System.Windows.Forms.Panel
		Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
		Friend WithEvents Panel1 As System.Windows.Forms.Panel
		Friend WithEvents lblDup As System.Windows.Forms.Label
		Friend WithEvents Label3 As System.Windows.Forms.Label
		Friend WithEvents lblFromLoc As System.Windows.Forms.Label
		Friend WithEvents lblProduct As System.Windows.Forms.Label
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents lblDisposition As System.Windows.Forms.Label
		Friend WithEvents lblToLoc As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.lblDisposition = New System.Windows.Forms.Label()
			Me.cboDisposition = New System.Windows.Forms.ComboBox()
			Me.Label4 = New System.Windows.Forms.Label()
			Me.cboLobLoc = New System.Windows.Forms.ComboBox()
			Me.lblRecCnt = New System.Windows.Forms.Label()
			Me.StatusBar1 = New System.Windows.Forms.StatusBar()
			Me.lblBoxCntText = New System.Windows.Forms.Label()
			Me.Label5 = New System.Windows.Forms.Label()
			Me.txtBox = New System.Windows.Forms.TextBox()
			Me.dgBoxes = New System.Windows.Forms.DataGrid()
			Me.btnTransfer = New System.Windows.Forms.Button()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.pnlBody = New System.Windows.Forms.Panel()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.lblDup = New System.Windows.Forms.Label()
			Me.cboCustomer = New System.Windows.Forms.ComboBox()
			Me.Panel1 = New System.Windows.Forms.Panel()
			Me.lblProduct = New System.Windows.Forms.Label()
			Me.lblFromLoc = New System.Windows.Forms.Label()
			Me.Label3 = New System.Windows.Forms.Label()
			Me.lblToLoc = New System.Windows.Forms.Label()
			CType(Me.dgBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.pnlBody.SuspendLayout()
			Me.Panel1.SuspendLayout()
			Me.SuspendLayout()
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(32, 40)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(64, 23)
			Me.Label1.TabIndex = 0
			Me.Label1.Text = "Customer:"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'lblDisposition
			'
			Me.lblDisposition.Location = New System.Drawing.Point(424, 40)
			Me.lblDisposition.Name = "lblDisposition"
			Me.lblDisposition.Size = New System.Drawing.Size(72, 23)
			Me.lblDisposition.TabIndex = 5
			Me.lblDisposition.Text = "Disposition:"
			Me.lblDisposition.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'cboDisposition
			'
			Me.cboDisposition.Location = New System.Drawing.Point(512, 40)
			Me.cboDisposition.Name = "cboDisposition"
			Me.cboDisposition.Size = New System.Drawing.Size(240, 21)
			Me.cboDisposition.TabIndex = 6
			'
			'Label4
			'
			Me.Label4.Location = New System.Drawing.Point(424, 8)
			Me.Label4.Name = "Label4"
			Me.Label4.Size = New System.Drawing.Size(72, 23)
			Me.Label4.TabIndex = 7
			Me.Label4.Text = "To Location:"
			Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'cboLobLoc
			'
			Me.cboLobLoc.Location = New System.Drawing.Point(728, 8)
			Me.cboLobLoc.Name = "cboLobLoc"
			Me.cboLobLoc.Size = New System.Drawing.Size(24, 21)
			Me.cboLobLoc.TabIndex = 8
			Me.cboLobLoc.Visible = False
			'
			'lblRecCnt
			'
			Me.lblRecCnt.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
			Me.lblRecCnt.BackColor = System.Drawing.Color.DeepSkyBlue
			Me.lblRecCnt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblRecCnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblRecCnt.ForeColor = System.Drawing.Color.Black
			Me.lblRecCnt.Location = New System.Drawing.Point(672, 8)
			Me.lblRecCnt.Name = "lblRecCnt"
			Me.lblRecCnt.Size = New System.Drawing.Size(104, 24)
			Me.lblRecCnt.TabIndex = 5
			Me.lblRecCnt.Text = "0"
			Me.lblRecCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'StatusBar1
			'
			Me.StatusBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.StatusBar1.Location = New System.Drawing.Point(0, 426)
			Me.StatusBar1.Name = "StatusBar1"
			Me.StatusBar1.Size = New System.Drawing.Size(802, 22)
			Me.StatusBar1.TabIndex = 2
			Me.StatusBar1.Text = "   This screen is used to transfer boxes from one location to another."
			'
			'lblBoxCntText
			'
			Me.lblBoxCntText.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
			Me.lblBoxCntText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblBoxCntText.ForeColor = System.Drawing.Color.Black
			Me.lblBoxCntText.Location = New System.Drawing.Point(576, 8)
			Me.lblBoxCntText.Name = "lblBoxCntText"
			Me.lblBoxCntText.Size = New System.Drawing.Size(80, 24)
			Me.lblBoxCntText.TabIndex = 4
			Me.lblBoxCntText.Text = "Box Count"
			Me.lblBoxCntText.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'Label5
			'
			Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label5.Location = New System.Drawing.Point(24, 8)
			Me.Label5.Name = "Label5"
			Me.Label5.Size = New System.Drawing.Size(72, 23)
			Me.Label5.TabIndex = 0
			Me.Label5.Text = "Box to Add:"
			Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'txtBox
			'
			Me.txtBox.AutoSize = False
			Me.txtBox.BackColor = System.Drawing.Color.DeepSkyBlue
			Me.txtBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtBox.Location = New System.Drawing.Point(112, 8)
			Me.txtBox.Name = "txtBox"
			Me.txtBox.Size = New System.Drawing.Size(240, 24)
			Me.txtBox.TabIndex = 1
			Me.txtBox.Text = ""
			'
			'dgBoxes
			'
			Me.dgBoxes.AllowNavigation = False
			Me.dgBoxes.AlternatingBackColor = System.Drawing.Color.PowderBlue
			Me.dgBoxes.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.dgBoxes.BackColor = System.Drawing.Color.Gainsboro
			Me.dgBoxes.CaptionForeColor = System.Drawing.Color.White
			Me.dgBoxes.CaptionVisible = False
			Me.dgBoxes.DataMember = ""
			Me.dgBoxes.ForeColor = System.Drawing.Color.Black
			Me.dgBoxes.HeaderForeColor = System.Drawing.Color.Black
			Me.dgBoxes.Location = New System.Drawing.Point(8, 40)
			Me.dgBoxes.Name = "dgBoxes"
			Me.dgBoxes.SelectionForeColor = System.Drawing.Color.White
			Me.dgBoxes.Size = New System.Drawing.Size(770, 272)
			Me.dgBoxes.TabIndex = 6
			'
			'btnTransfer
			'
			Me.btnTransfer.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
			Me.btnTransfer.Location = New System.Drawing.Point(608, 320)
			Me.btnTransfer.Name = "btnTransfer"
			Me.btnTransfer.Size = New System.Drawing.Size(168, 24)
			Me.btnTransfer.TabIndex = 0
			Me.btnTransfer.Text = "Transfer Boxes"
			'
			'btnClear
			'
			Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
			Me.btnClear.Location = New System.Drawing.Point(488, 320)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(96, 24)
			Me.btnClear.TabIndex = 7
			Me.btnClear.Text = "Clear All"
			'
			'pnlBody
			'
			Me.pnlBody.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left) _
						Or System.Windows.Forms.AnchorStyles.Right)
			Me.pnlBody.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMsg, Me.lblDup, Me.Label5, Me.dgBoxes, Me.txtBox, Me.lblBoxCntText, Me.lblRecCnt, Me.btnClear, Me.btnTransfer})
			Me.pnlBody.Location = New System.Drawing.Point(8, 72)
			Me.pnlBody.Name = "pnlBody"
			Me.pnlBody.Size = New System.Drawing.Size(784, 352)
			Me.pnlBody.TabIndex = 1
			'
			'lblMsg
			'
			Me.lblMsg.ForeColor = System.Drawing.Color.Blue
			Me.lblMsg.Location = New System.Drawing.Point(16, 312)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(424, 16)
			Me.lblMsg.TabIndex = 8
			Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			Me.lblMsg.Visible = False
			'
			'lblDup
			'
			Me.lblDup.BackColor = System.Drawing.Color.Brown
			Me.lblDup.ForeColor = System.Drawing.Color.White
			Me.lblDup.Location = New System.Drawing.Point(376, 12)
			Me.lblDup.Name = "lblDup"
			Me.lblDup.Size = New System.Drawing.Size(88, 16)
			Me.lblDup.TabIndex = 3
			Me.lblDup.Text = "Duplicate"
			Me.lblDup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			Me.lblDup.Visible = False
			'
			'cboCustomer
			'
			Me.cboCustomer.DisplayMember = "cust_name1"
			Me.cboCustomer.Enabled = False
			Me.cboCustomer.Location = New System.Drawing.Point(112, 40)
			Me.cboCustomer.MaxDropDownItems = 20
			Me.cboCustomer.Name = "cboCustomer"
			Me.cboCustomer.Size = New System.Drawing.Size(240, 21)
			Me.cboCustomer.TabIndex = 1
			Me.cboCustomer.ValueMember = "cust_id"
			'
			'Panel1
			'
			Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblToLoc, Me.lblFromLoc, Me.Label3, Me.Label1, Me.Label4, Me.cboCustomer, Me.cboDisposition, Me.cboLobLoc, Me.lblDisposition, Me.lblProduct})
			Me.Panel1.Location = New System.Drawing.Point(8, 0)
			Me.Panel1.Name = "Panel1"
			Me.Panel1.Size = New System.Drawing.Size(784, 72)
			Me.Panel1.TabIndex = 0
			'
			'lblProduct
			'
			Me.lblProduct.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblProduct.ForeColor = System.Drawing.Color.RoyalBlue
			Me.lblProduct.Location = New System.Drawing.Point(288, 8)
			Me.lblProduct.Name = "lblProduct"
			Me.lblProduct.Size = New System.Drawing.Size(112, 24)
			Me.lblProduct.TabIndex = 4
			Me.lblProduct.Visible = False
			'
			'lblFromLoc
			'
			Me.lblFromLoc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblFromLoc.ForeColor = System.Drawing.Color.RoyalBlue
			Me.lblFromLoc.Location = New System.Drawing.Point(112, 8)
			Me.lblFromLoc.Name = "lblFromLoc"
			Me.lblFromLoc.Size = New System.Drawing.Size(168, 24)
			Me.lblFromLoc.TabIndex = 3
			'
			'Label3
			'
			Me.Label3.Location = New System.Drawing.Point(16, 8)
			Me.Label3.Name = "Label3"
			Me.Label3.Size = New System.Drawing.Size(80, 23)
			Me.Label3.TabIndex = 2
			Me.Label3.Text = "From Location:"
			Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
			'
			'lblToLoc
			'
			Me.lblToLoc.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblToLoc.ForeColor = System.Drawing.Color.RoyalBlue
			Me.lblToLoc.Location = New System.Drawing.Point(512, 8)
			Me.lblToLoc.Name = "lblToLoc"
			Me.lblToLoc.Size = New System.Drawing.Size(208, 24)
			Me.lblToLoc.TabIndex = 9
			'
			'frmWhToStaging
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(802, 448)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.pnlBody, Me.StatusBar1})
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.Name = "frmWhToStaging"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.Text = "Warehouse to Staging Transfer"
			CType(Me.dgBoxes, System.ComponentModel.ISupportInitialize).EndInit()
			Me.pnlBody.ResumeLayout(False)
			Me.Panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"
		Private _cust_id As Integer
		Private _prod_id As Integer
		Private _cpl_id As Integer
		Private _use_disp As Boolean = False
		Private _dtBoxes As New DataTable()
		Private _user_id As Integer
#End Region
#Region "CONTRUCTORS"

		Private Sub New()
			MyBase.New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal cust_id As Integer, ByVal prod_id As Integer, ByVal cpl_id As Integer, ByVal use_disp As Boolean)
			MyBase.New()
			InitializeComponent()
			_cust_id = cust_id
			_prod_id = prod_id
			_cpl_id = cpl_id
			_use_disp = use_disp
			_user_id = PSS.Core.ApplicationUser.IDuser
		End Sub
#End Region
#Region "FORM EVENTS"
		Private Sub frmWhToStaging_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			GetFromLocation()
			GetProduct()
			PopulateCustomerCombo()
			BuildTable()
			dgBoxes.ReadOnly = True
			dgBoxes.AllowNavigation = False
			dgBoxes.DataSource = _dtBoxes
			CreateTableStyles()
			EnableControls()
			'txtBoxID.Focus()
		End Sub
#End Region
#Region "CONTROL EVENTS"
		Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged
			_dtBoxes.Rows.Clear()
			dgBoxes.Refresh()
			SetRecordCount()
			Try
				If cboCustomer.SelectedValue > 0 Then
					PopulateDispositionCombo()
				Else
					cboDisposition.DataSource = Nothing
				End If
				EnableControls()
			Catch ex As Exception
			End Try
		End Sub
		Private Sub cboDisposition_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDisposition.SelectedIndexChanged
			_dtBoxes.Rows.Clear()
			dgBoxes.Refresh()
			SetRecordCount()
			Try
				If cboDisposition.SelectedValue >= 0 Then
					PopulateLobLocCombo()
				Else
					cboLobLoc.DataSource = Nothing
				End If
				EnableControls()
			Catch ex As Exception
			End Try
		End Sub
		Private Sub cboLobLoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLobLoc.SelectedIndexChanged
			_dtBoxes.Rows.Clear()
			dgBoxes.Refresh()
			SetRecordCount()
			lblToLoc.Text = cboLobLoc.Text
			EnableControls()
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			If MessageBox.Show("Clear the screen?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
				ClearTheScreen()
			End If
		End Sub
		Private Sub txtBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBox.KeyUp
			If e.KeyValue = Keys.Enter Then
				AddBoxIDToList()
				SetRecordCount()
			End If
		End Sub
		Private Sub btnTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer.Click
			If Me.lblRecCnt.Text = "0" Then
				MessageBox.Show("No boxes have been entered.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			ElseIf MessageBox.Show("Transfer the boxes now?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
				Dim x As Integer = 0
				Me.Cursor = Cursors.WaitCursor
				x = TransferBoxes()
				MessageBox.Show(x.ToString() & " Boxes have transfered successfully.", Me.Text, MessageBoxButtons.OK)
				Me.Cursor = Cursors.Default
			End If
		End Sub
#End Region
#Region "PROPERTIES"
#End Region
#Region "METHODS"
		Private Sub GetFromLocation()
			Dim _fl As New BOL.tcustomer_prod_locations(_cpl_id)
			lblFromLoc.Text = _fl.loc_na
			_fl = Nothing
		End Sub
		Private Sub GetProduct()
			Dim _prod As New BOL.lproduct(_prod_id)
			If _prod.Prod_ID > 0 Then
				lblProduct.Text = _prod.Prod_Desc
			End If
			_prod = Nothing
		End Sub
		Private Sub PopulateCustomerCombo()
			' POPULATES THE CUSTOMER COMBO BOX.
			Dim _dt As New DataTable()
			Dim _nr As DataRow
			Dim _col As New Data.BOL.tcustomerFilteredCollection()
			_dt = _col.tcustomerDataTable.Copy
			_nr = _dt.NewRow()
			_nr(0) = 0
			_nr(1) = "-- Select --"
			_dt.Rows.InsertAt(_nr, 0)
			_dt.AcceptChanges()
			cboCustomer.DataSource = _dt
			cboCustomer.ValueMember = "Cust_ID"
			cboCustomer.DisplayMember = "Cust_Name1"
			cboCustomer.Refresh()
			_col = Nothing
			cboCustomer.SelectedIndex = 1
		End Sub
		Private Sub PopulateDispositionCombo()
			' POPULATES THE CUSTOMER COMBO BOX.
			Dim _dt As New DataTable()
			Dim _nr As DataRow
			Dim _col As New Data.BOL.tcustomer_dispositionsCollection(_cust_id, False)
			_dt = _col.tcustomer_dispositionsDataTable.Copy
			_nr = _dt.NewRow()
			_nr("disp_id") = 0
			_nr("disp_cd") = "-- All --"
			_dt.Rows.InsertAt(_nr, 0)
			_dt.AcceptChanges()
			cboDisposition.DataSource = _dt
			cboDisposition.ValueMember = "disp_id"
			cboDisposition.DisplayMember = "disp_cd"
			cboDisposition.Refresh()
			_col = Nothing
			'cboDisposition.SelectedValue = 0
		End Sub
		Private Sub PopulateLobLocCombo()
			' POPULATES THE LOCATION COMBO BOX.
			Dim _dt As New DataTable()
			Dim _nr As DataRow
			Dim _col As New BOL.tcustomer_prod_WfByLocAndDispCol(_cpl_id, cboDisposition.SelectedValue)
			_dt = _col.tcustomer_prod_workflowDataTable.Copy
			_nr = _dt.NewRow()
			_nr("cpl_id_to") = 0
			_nr("loc_na") = "-- Select --"
			_dt.Rows.InsertAt(_nr, 0)
			_dt.AcceptChanges()
			cboLobLoc.DataSource = _dt
			cboLobLoc.ValueMember = "cpl_id_to"
			cboLobLoc.DisplayMember = "loc_na"
			cboLobLoc.Refresh()
			_col = Nothing
			If _dt.Rows.Count = 2 Then
				cboLobLoc.SelectedIndex = 1
			End If
		End Sub
		Private Sub EnableControls()
			Me.cboDisposition.Enabled = Me.cboCustomer.SelectedValue > 0
			If cboDisposition.Enabled AndAlso cboDisposition.ValueMember <> "" Then
				cboLobLoc.Enabled = cboDisposition.SelectedValue >= 0
			Else
				cboLobLoc.Enabled = False
			End If

			' override
			'cboLobLoc.Enabled = False

			If cboLobLoc.Enabled AndAlso cboLobLoc.ValueMember <> "" Then
				pnlBody.Enabled = cboLobLoc.SelectedValue > 0
			Else
				pnlBody.Enabled = False
			End If
			cboDisposition.Visible = _use_disp
			lblDisposition.Visible = _use_disp
		End Sub
		Private Sub ClearTheScreen()
			txtBox.Text = ""
			lblMsg.Text = ""
			_dtBoxes.Rows.Clear()
			dgBoxes.Refresh()
			SetRecordCount()
		End Sub
		Private Sub SetRecordCount()
			lblRecCnt.Text = _dtBoxes.Rows.Count.ToString()
		End Sub
		Private Sub AddBoxIDToList()
			If txtBox.Text.Trim() <> "" Then
				Dim _box_na As String = txtBox.Text
				Dim _box As New BOL.wh_box(_box_na)
				Dim _errMsg As String = ""
				If _box.whb_id < 1 Then
					_errMsg = "Box not found"
				ElseIf _box.cust_id <> _cust_id Then
					_errMsg = "Box belongs to incorrect customer."
				ElseIf _box.cpl_id <> _cpl_id Then
					_errMsg = "The box is not in this location."
				ElseIf _box.disp_id > 0 AndAlso cboDisposition.SelectedValue <> 0 Then
					If _box.disp_id <> cboDisposition.SelectedValue Then
						_errMsg = "The box is not valid for this move due to its disposition."
					End If
				End If
				If _errMsg <> "" Then
					txtBox.Text = ""
					MessageBox.Show(_errMsg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
					Exit Sub
				End If
				Try
					Dim _boxRo As New BOL.wh_box_readonly(_box_na)
					Dim _dr As DataRow = _dtBoxes.NewRow()
					_dr("whb_id") = _boxRo.whb_id
					_dr("Box") = _boxRo.box_na
					_dr("Customer") = cboCustomer.Text
					_dr("Product") = lblProduct.Text
					_dr("Model") = _boxRo.model_desc
					_dr("Disposition") = _boxRo.disp_na
					_dr("Quantity") = _boxRo.quantity
					_dr("Bin") = _boxRo.bin_na
					_dr("ValidationResults") = ""
					_dtBoxes.Rows.Add(_dr)
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
					txtBox.Text = ""
				End Try
			End If
		End Sub
		Private Function GetBoxQty(ByVal BoxNr As String) As Int16
			Try
				'Return Misc.GetBoxQty(BoxNr)
			Catch
				Return 0
			End Try
		End Function
		Private Sub BuildTable()
			_dtBoxes.TableName = "Boxes"
			_dtBoxes.Columns.Add("Box")
			_dtBoxes.Columns.Add("whb_id")
			_dtBoxes.Columns.Add("Customer")
			_dtBoxes.Columns.Add("Product")
			_dtBoxes.Columns.Add("Model")
			_dtBoxes.Columns.Add("Disposition")
			_dtBoxes.Columns.Add("Quantity")
			_dtBoxes.Columns.Add("Bin")
			_dtBoxes.Columns.Add("ValidationResults")
			Dim unqCol As UniqueConstraint = _
			 New UniqueConstraint(New DataColumn() {_dtBoxes.Columns("Box")})
			_dtBoxes.Constraints.Add(unqCol)
		End Sub
		Friend Sub CreateTableStyles()
			' Create a new DataGridTableStyle and set
			' its MappingName to the TableName of a DataTable. 
			Dim ts1 As New DataGridTableStyle()
			ts1.MappingName = "Boxes"
			' Add a GridColumnStyle and set its MappingName
			' to the name of a DataColumn in the DataTable.
			' Set the HeaderText and Width properties. 
			Dim ColBoxID As New DataGridTextBoxColumn()
			ColBoxID.MappingName = "whb_id"
			ColBoxID.HeaderText = "whb_id"
			ColBoxID.Width = 0
			ColBoxID.ReadOnly = True
			ts1.GridColumnStyles.Add(ColBoxID)
			'
			Dim ColBox As New DataGridTextBoxColumn()
			ColBox.MappingName = "Box"
			ColBox.HeaderText = "Box"
			ColBox.Width = 180
			ColBox.ReadOnly = True
			ts1.GridColumnStyles.Add(ColBox)
			'
			Dim ColCust As New DataGridTextBoxColumn()
			ColCust.MappingName = "Customer"
			ColCust.HeaderText = "Customer"
			ColCust.Width = 180
			ColCust.ReadOnly = True
			ts1.GridColumnStyles.Add(ColCust)
			'
			Dim ColProd As New DataGridTextBoxColumn()
			ColProd.MappingName = "Product"
			ColProd.HeaderText = "Product"
			ColProd.Width = 120
			ColProd.ReadOnly = True
			ts1.GridColumnStyles.Add(ColProd)
			'
			Dim ColMod As New DataGridTextBoxColumn()
			ColMod.MappingName = "Model"
			ColMod.HeaderText = "Model"
			ColMod.Width = 120
			ColMod.ReadOnly = True
			ts1.GridColumnStyles.Add(ColMod)
			'
			Dim ColDisp As New DataGridTextBoxColumn()
			ColDisp.MappingName = "Disposition"
			ColDisp.HeaderText = "Disposition"
			ColDisp.Width = 120
			ColDisp.ReadOnly = True
			ts1.GridColumnStyles.Add(ColDisp)
			'
			Dim ColBin As New DataGridTextBoxColumn()
			ColBin.MappingName = "Bin"
			ColBin.HeaderText = "Bin"
			ColBin.Width = 75
			ColBin.ReadOnly = True
			ts1.GridColumnStyles.Add(ColBin)
			'
			Dim ColBoxQty As New DataGridTextBoxColumn()
			ColBoxQty.MappingName = "Quantity"
			ColBoxQty.HeaderText = "Box Qty"
			ColBoxQty.Width = 180
			ColBoxQty.ReadOnly = True
			ts1.GridColumnStyles.Add(ColBoxQty)
			'
			Dim ColValidation As New DataGridTextBoxColumn()
			ColValidation.MappingName = "ValidationResults"
			ColValidation.HeaderText = "Validation Results"
			ColValidation.Width = 500
			ColValidation.ReadOnly = True
			ts1.GridColumnStyles.Add(ColValidation)
			' Add the DataGridTableStyle objects to the collection.
			dgBoxes.TableStyles.Add(ts1)
		End Sub
		Private Function TransferBoxes() As Integer
			' VALIDATE
			Dim dr As DataRow
			Dim _xfrCnt As Integer = 0
			Dim _whb_id As Integer
			For Each dr In _dtBoxes.Rows()
				lblMsg.Text = "Validating boxes ..."
				_whb_id = dr("whb_id").ToString()
				Dim _validation As String = ValidateBox(_whb_id)
				Dim _col As DataColumn
				For Each _col In _dtBoxes.Columns
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
			For Each dr In _dtBoxes.Rows()
				lblMsg.Text = "Transfering boxes ..."
				_whb_id = dr("whb_id")
				Dim _validation As String = ValidateBox(_whb_id)
				Dim _col As DataColumn
				If dr("ValidationResults") = "" Then
					Dim _wbm As New BLL.WHBoxMovement(dr("whb_id"), _cust_id, _prod_id, cboDisposition.SelectedValue, _cpl_id, cboLobLoc.SelectedValue, _user_id)
					If _wbm.PerformTransfer() Then
						For Each _col In _dtBoxes.Columns
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
						_wbm = Nothing
					End If
				End If
			Next
			If MessageBox.Show("Would you like to create a transfer receipt?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
				PrintTransferReceipt()
			End If
			' CLEAN UP
			RemoveTransferBoxes()
			lblMsg.Text = ""
			SetRecordCount()
			Return _xfrCnt
		End Function
		Private Function ValidateBox(ByVal whb_id As Integer) As String
			Dim _whbm As New BLL.WHBoxMovement(whb_id, _cust_id, _prod_id, cboDisposition.SelectedValue, _cpl_id, cboLobLoc.SelectedValue, _user_id)
			Dim _validation As String
			_validation = _whbm.ValidateBoxTransfer()
			Return _validation
		End Function
		Private Sub RemoveTransferBoxes()
			Dim _dt2 As New DataTable()
			_dt2 = _dtBoxes.Clone()
			Dim dr As DataRow
			For Each dr In _dtBoxes.Rows()
				Dim _box = dr("box").ToString()
				Dim _result = dr("ValidationResults").ToString()
				If _result <> "Transfered" Then
					_dt2.LoadDataRow(dr.ItemArray, True)
				End If
			Next
			_dt2.AcceptChanges()
			_dtBoxes = _dt2.Copy()
			dgBoxes.DataSource = _dtBoxes
			_dt2.Dispose()
		End Sub
		Private Sub PrintTransferReceipt()
			Dim _xl As New Data.ExcelReports()
			_xl.RunSimpleExcelFormat(_dtBoxes, "Transfer Receipt - " & lblFromLoc.Text & " To " & cboLobLoc.Text)
		End Sub
#End Region
	End Class
End Namespace
