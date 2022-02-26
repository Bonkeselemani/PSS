Public Class frmListMaster
	Inherits System.Windows.Forms.Form
	Public gListRefreshArray As New ArrayList()
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
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
	Friend WithEvents cmdNew As System.Windows.Forms.Button
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.DataGrid1 = New System.Windows.Forms.DataGrid()
		Me.cmdNew = New System.Windows.Forms.Button()
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'DataGrid1
		'
		Me.DataGrid1.AllowNavigation = False
		Me.DataGrid1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
		   Or System.Windows.Forms.AnchorStyles.Left) _
		   Or System.Windows.Forms.AnchorStyles.Right)
		Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
		Me.DataGrid1.CaptionVisible = False
		Me.DataGrid1.DataMember = ""
		Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid1.Name = "DataGrid1"
		Me.DataGrid1.ReadOnly = True
		Me.DataGrid1.RowHeaderWidth = 20
		Me.DataGrid1.Size = New System.Drawing.Size(704, 360)
		Me.DataGrid1.TabIndex = 20
		'
		'cmdNew
		'
		Me.cmdNew.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
		Me.cmdNew.Location = New System.Drawing.Point(616, 368)
		Me.cmdNew.Name = "cmdNew"
		Me.cmdNew.Size = New System.Drawing.Size(80, 32)
		Me.cmdNew.TabIndex = 18
		Me.cmdNew.Text = "New"
		'
		'frmListMaster
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(704, 406)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1, Me.cmdNew})
		Me.Name = "frmListMaster"
		Me.Text = "frmListMaster"
		CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

#End Region
#Region "INITIAL DECLARATIONS"
	Friend dtItems As New DataTable()
#End Region
#Region "CONSTRUCTORS"
	Public Sub New()
		MyBase.New()
		InitializeComponent()
	End Sub
#End Region
#Region "FORM EVENTS"
	Private Sub frmListMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Try
			Me.StartPosition = FormStartPosition.Manual
			Me.Top = 0
			Me.Left = 0
			LoadTheGrid()
		Catch ex As Exception
			MessageBox.Show("An error occurred while loading the form." & vbCrLf & vbCrLf _
			 & ex.Message, "Orders", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try
		Dim a As IntPtr
		a = Me.Handle
	End Sub
	Private Sub frmOrderList_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
		If CheckListRefreshRef(Me.Handle.ToInt32) Then
			Application.DoEvents()
			RemoveListRefreshRef(Me.Handle.ToInt32)
			LoadTheGrid()
			Application.DoEvents()

		End If

	End Sub
	Private Sub frmListMaster_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
		RemoveListRefreshRef(Me.Handle.ToInt32)

	End Sub
#End Region
#Region "OVERRIDABLE PROCEDURES"
	Protected Overridable Sub CreateTableStyles()
	End Sub
	Protected Overridable Sub EditRecord()
	End Sub
	Protected Overridable Sub GetGridData()
	End Sub
	Protected Overridable Sub NewRecord()
	End Sub
#End Region
#Region "CONTROL EVENTS"
	Private Sub DataGrid1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
		' Process the current cell change of the grid.
		Dim row As Integer
		row = DataGrid1.CurrentCell.RowNumber
		DataGrid1.Select(row)
	End Sub
	Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
		' Process the selection of an item in the grid.
		Dim myGrid As DataGrid = CType(sender, DataGrid)
		Dim hti As DataGrid.HitTestInfo = myGrid.HitTest(e.X, e.Y)
		Try
			If hti.Type = DataGrid.HitTestType.Cell Then
				Me.Cursor = Cursors.WaitCursor
				DataGrid1.Select(CInt(hti.Row))
				DataGrid1.Refresh()
				EditRecord()
				Me.Cursor = Cursors.Default
			End If
		Catch ex As Exception
			MessageBox.Show("Unable to open the selected record." & vbCrLf & vbCrLf & ex.Message, "Item Group List", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try
	End Sub
	Private Sub cmdNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNew.Click
		Me.Cursor = Cursors.WaitCursor
		NewRecord()
		Me.Cursor = Cursors.Default
	End Sub
#End Region
#Region "METHODS"
	Friend Sub LoadTheGrid()
		Try
			Me.DataGrid1.DataSource = Nothing
			Me.DataGrid1.TableStyles.Clear()
			If Me.DataGrid1.TableStyles.Count = 0 Then
				CreateTableStyles()
			End If
			GetGridData()
			Me.DataGrid1.DataSource = dtItems
			Me.DataGrid1.Refresh()
			If Me.DataGrid1.DataSource.Rows().Count > 0 Then
				DataGrid1.Select(DataGrid1.CurrentCell.RowNumber)
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Loading Grid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try
	End Sub
	Friend Function CheckListRefreshRef(ByVal Handle As Integer) As Boolean
		Return gListRefreshArray.Contains(Handle)
	End Function
	Friend Sub AddListRefreshRef(ByVal Handle As Integer)
		If Not gListRefreshArray.Contains(Handle) Then
			gListRefreshArray.Add(Handle)
		End If
	End Sub
	Friend Sub RemoveListRefreshRef(ByVal Handle As Integer)
		Do Until Not gListRefreshArray.Contains(Handle)
			gListRefreshArray.Remove(Handle)
		Loop
	End Sub
#End Region
#Region " PASTE ME INTO THE DERIVED FORM."
	'Friend Overrides Sub GetGridData()
	'    Dim mobjitems As New CapSystems
	'    Dim dt As New DataTable
	'    dt = mobjitems.Load(gCnnString, False, False)
	'    dtItems = dt
	'
	'End Sub
	'Friend Overrides Sub CreateTableStyles()
	'	' CREATE A NEW TABLESTYLE FOR THE DATAGRID.
	'	' SET THE MAPPINGNAME TO THE TABLENAME OF A DATATABLE. 
	'	Dim ts1 As New DataGridTableStyle()
	'	ts1.MappingName = "tcustomer_prod_workflowDataTable"
	'	Dim col0 As New DataGridTextBoxColumn()
	'	Dim col1 As New DataGridTextBoxColumn()
	'	Dim col2 As New DataGridTextBoxColumn()
	'	Dim col3 As New DataGridBoolColumn()
	'	Dim col4 As New DataGridTextBoxColumn()
	'	Dim col5 As New DataGridTextBoxColumn()
	'	Dim col6 As New DataGridTextBoxColumn()
	'	col0.MappingName = "cpl_id" : col0.HeaderText = "ID" : col0.Width = 0 : ts1.GridColumnStyles.Add(col0)
	'	col1.MappingName = "cpl_id_to" : col1.HeaderText = "cpl_id_to" : col1.Width = 0 : ts1.GridColumnStyles.Add(col1)
	'	col2.MappingName = "disp_id" : col2.HeaderText = "disp_id" : col2.Width = 0 : ts1.GridColumnStyles.Add(col2)
	'	col3.MappingName = "active" : col3.HeaderText = "Active" : col3.Width = 50 : ts1.GridColumnStyles.Add(col3)
	'	col4.MappingName = "loc_from" : col4.HeaderText = "Location" : col4.Width = 100 : ts1.GridColumnStyles.Add(col4)
	'	col5.MappingName = "loc_to1" : col5.HeaderText = "Destination" : col5.Width = 100 : ts1.GridColumnStyles.Add(col5)
	'	col6.MappingName = "disp_na" : col6.HeaderText = "Disposition" : col6.Width = 100 : ts1.GridColumnStyles.Add(col6)
	'	' ADDTIONAL FORMATTING.
	'	ts1.ForeColor = Color.Black
	'	ts1.AlternatingBackColor = Color.White
	'	ts1.BackColor = Color.AliceBlue
	'	ts1.PreferredRowHeight = 20
	'	' ADD THE TABLESTYLE TO THE GRID.
	'	DataGrid1.TableStyles.Add(ts1)
	'End Sub
	'Friend Overrides Sub EditRecord()
	'    Try
	'        OpenCapSystemEdit(DataGrid1.Item(DataGrid1.CurrentRowIndex, 0), Me.Handle.ToInt32)
	'    Catch ex As Exception
	'        MessageBox.Show(ex.Message, "New Cap System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'    End Try
	'End Sub
	'Friend Overrides Sub NewRecord()
	'    Try
	'        OpenCapSystemEdit(0, Me.Handle.ToInt32)
	'    Catch ex As Exception
	'        MessageBox.Show(ex.Message, "New Cap System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
	'    End Try
	'End Sub
#End Region
End Class
