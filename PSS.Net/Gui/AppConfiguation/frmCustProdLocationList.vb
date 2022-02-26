Public Class frmCustProdLocationList
	Inherits frmListMaster
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
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.SuspendLayout()
		'
		'frmCustProdLocationList
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(704, 406)
		Me.Name = "frmCustProdLocationList"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
		Me.Text = "Customer Product Location List"
		Me.ResumeLayout(False)

	End Sub

#End Region
#Region "METHOD OVERRIDES"
	Protected Overrides Sub GetGridData()
		Dim mobjitems As New Data.BOL.tcustomer_prod_locationsCollection()
		Dim dt As New DataTable()
		dt = mobjitems.tcustomer_prod_locationsDataTable()
		dt.TableName = "tCustProdLocations"
		dtItems = dt
	End Sub
	Protected Overrides Sub CreateTableStyles()

		'' Create a new DataGridTableStyle and set
		'' its MappingName to the TableName of a DataTable. 
		Dim ts1 As New DataGridTableStyle()
		ts1.MappingName = "tCustProdLocations"

		' Add a GridColumnStyle and set its MappingName
		' to the name of a DataColumn in the DataTable.
		' Set the HeaderText and Width properties. 

		Dim ColID As New DataGridTextBoxColumn()
		ColID.MappingName = "cpl_id"
		ColID.HeaderText = "ID"
		ColID.Width = 0
		ts1.GridColumnStyles.Add(ColID)

		' Add a GridColumnStyle.
		Dim col1 As New DataGridTextBoxColumn()
		col1.MappingName = "cust_name1"
		col1.HeaderText = "Customer"
		col1.Width = 125
		col1.NullText = False
		ts1.GridColumnStyles.Add(col1)

		' Add a GridColumnStyle.
		Dim Col2 As New DataGridTextBoxColumn()
		Col2.MappingName = "prod_desc"
		Col2.HeaderText = "Product"
		Col2.Width = 75
		Col2.NullText = ""
		ts1.GridColumnStyles.Add(Col2)

		' Add a GridColumnStyle.
		Dim col3 As New DataGridTextBoxColumn()
		col3.MappingName = "loc_na"
		col3.HeaderText = "Location"
		col3.Width = 150
		col3.NullText = ""
		ts1.GridColumnStyles.Add(col3)

		' Add a GridColumnStyle.
		Dim col4 As New DataGridTextBoxColumn()
		col4.MappingName = "crt_ts"
		col4.HeaderText = "Created"
		col4.Width = 150
		col4.NullText = ""
		ts1.GridColumnStyles.Add(col4)

		' Add a GridColumnStyle.
		Dim col5 As New DataGridTextBoxColumn()
		col5.MappingName = "crt_user_id"
		col5.HeaderText = "Created By"
		col5.Width = 0
		col5.NullText = ""
		ts1.GridColumnStyles.Add(col5)

		' Addtional Formatting.
		ts1.ForeColor = Color.Black
		ts1.AlternatingBackColor = Color.White
		ts1.BackColor = Color.AliceBlue
		ts1.PreferredRowHeight = 20

		' Add the DataGridTableStyle objects to the collection.
		DataGrid1.TableStyles.Add(ts1)

	End Sub
	Protected Overrides Sub EditRecord()
		Try
			FormFactory.OpenCustProdLocEdit(DataGrid1.Item(DataGrid1.CurrentRowIndex, 0))
			LoadTheGrid()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "New Dispostion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

		End Try

	End Sub
	Protected Overrides Sub NewRecord()
		Try
			FormFactory.OpenCustProdLocEdit(0)
			LoadTheGrid()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "New Disposition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

		End Try

	End Sub
#End Region
End Class
