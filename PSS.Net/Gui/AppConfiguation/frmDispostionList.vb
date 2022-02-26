Public Class frmDispostionList
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
		components = New System.ComponentModel.Container()
		Me.Text = "frmDispostionList"
	End Sub

#End Region
#Region "METHOD OVERRIDES"
	Protected Overrides Sub GetGridData()
		Dim mobjitems As New Data.BOL.tdispositionsCollection()
		Dim dt As New DataTable()
		dt = mobjitems.tdispositionsDataTable()
		dt.TableName = "tDispositions"
		dtItems = dt
	End Sub
	Protected Overrides Sub CreateTableStyles()
		Dim ts1 As New DataGridTableStyle()
		ts1.MappingName = "tDispositions"
		Dim ColID As New DataGridTextBoxColumn()
		Dim col1 As New DataGridTextBoxColumn()
		Dim Col2 As New DataGridTextBoxColumn()
		Dim col3 As New DataGridTextBoxColumn()
		Dim col4 As New DataGridTextBoxColumn()
		ColID.MappingName = "disp_id" : ColID.HeaderText = "ID" : ColID.Width = 0
		col1.MappingName = "disp_cd" : col1.HeaderText = "Code" : col1.Width = 75 : col1.NullText = ""
		Col2.MappingName = "disp_na" : Col2.HeaderText = "Description" : Col2.Width = 200 : Col2.NullText = ""
		col3.MappingName = "crt_ts" : col3.HeaderText = "Created" : col3.Width = 150 : col3.NullText = ""
		col4.MappingName = "crt_user_id" : col4.HeaderText = "Created By" : col4.Width = 0 : col4.NullText = ""
		ts1.GridColumnStyles.Add(ColID)
		ts1.GridColumnStyles.Add(col1)
		ts1.GridColumnStyles.Add(Col2)
		ts1.GridColumnStyles.Add(col3)
		ts1.GridColumnStyles.Add(col4)
		ts1.ForeColor = Color.Black
		ts1.AlternatingBackColor = Color.White
		ts1.BackColor = Color.AliceBlue
		ts1.PreferredRowHeight = 20
		DataGrid1.TableStyles.Add(ts1)
	End Sub
	Protected Overrides Sub EditRecord()
		Try
			FormFactory.OpenDispostionEdit(DataGrid1.Item(DataGrid1.CurrentRowIndex, 0))
			LoadTheGrid()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "New Dispostion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

		End Try

	End Sub
	Protected Overrides Sub NewRecord()
		Try
			FormFactory.OpenDispostionEdit(0)
			LoadTheGrid()
		Catch ex As Exception
			MessageBox.Show(ex.Message, "New Disposition", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

		End Try

	End Sub
#End Region
End Class
