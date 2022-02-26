Public Class frmProductList
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
		'
		'frmProductList
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(552, 326)
		Me.Name = "frmProductList"
		Me.Text = "frmProductList"

	End Sub

#End Region

#Region "METHOD OVERRIDES"
	Protected Overrides Sub GetGridData()
		Dim mobjitems As New Data.BOL.lproductCollection()
		Dim dt As New DataTable()
		dt = mobjitems.lproductDataTable
		dt.TableName = "lproduct"
		dtItems = dt
	End Sub
	Protected Overrides Sub CreateTableStyles()
		' Create a new DataGridTableStyle and set its MappingName to the TableName of a DataTable. 
		Dim ts1 As New DataGridTableStyle()
		ts1.MappingName = "tcustomer_prod_workflowDataTable"
		Dim col0 As New DataGridTextBoxColumn()
		Dim col1 As New DataGridTextBoxColumn()
		Dim col2 As New DataGridBoolColumn()
		col0.MappingName = "prod_id" : col0.HeaderText = "ID" : col0.Width = 0 : ts1.GridColumnStyles.Add(col0)
		col1.MappingName = "prod_desc" : col1.HeaderText = "cpl_id_to" : col1.Width = 0 : ts1.GridColumnStyles.Add(col1)
		col2.MappingName = "active" : col2.HeaderText = "Active" : col2.Width = 50 : ts1.GridColumnStyles.Add(col2)
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
			FormFactory.OpenProductEdit(DataGrid1.Item(DataGrid1.CurrentRowIndex, 0))
			LoadTheGrid()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "New Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try
	End Sub
	Protected Overrides Sub NewRecord()
		Try
			FormFactory.OpenProductEdit(0)
			LoadTheGrid()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "New Worflow", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		End Try
	End Sub
#End Region
End Class
