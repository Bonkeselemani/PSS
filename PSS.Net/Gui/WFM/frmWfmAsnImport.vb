Imports System.Text
Imports Microsoft.VisualBasic.FileSystem
Imports System.IO

Namespace Gui.WFMTracfone

	Public Class frmTmoAsnImport
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
		Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
		Friend WithEvents ofdSource As System.Windows.Forms.OpenFileDialog
		Friend WithEvents sfdTemplate As System.Windows.Forms.SaveFileDialog
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents btnGetTemplate As System.Windows.Forms.Button
		Friend WithEvents btnImport As System.Windows.Forms.Button
		Friend WithEvents btnLoadFile As System.Windows.Forms.Button
		Friend WithEvents txtFile As System.Windows.Forms.TextBox
		Friend WithEvents lblMsg As System.Windows.Forms.Label
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents btnClear As System.Windows.Forms.Button
		Friend WithEvents lblRecordCount As System.Windows.Forms.Label
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.btnGetTemplate = New System.Windows.Forms.Button()
			Me.btnImport = New System.Windows.Forms.Button()
			Me.btnLoadFile = New System.Windows.Forms.Button()
			Me.txtFile = New System.Windows.Forms.TextBox()
			Me.DataGrid1 = New System.Windows.Forms.DataGrid()
			Me.ofdSource = New System.Windows.Forms.OpenFileDialog()
			Me.sfdTemplate = New System.Windows.Forms.SaveFileDialog()
			Me.lblMsg = New System.Windows.Forms.Label()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.btnClear = New System.Windows.Forms.Button()
			Me.lblRecordCount = New System.Windows.Forms.Label()
			CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'btnGetTemplate
			'
			Me.btnGetTemplate.Location = New System.Drawing.Point(8, 360)
			Me.btnGetTemplate.Name = "btnGetTemplate"
			Me.btnGetTemplate.Size = New System.Drawing.Size(136, 23)
			Me.btnGetTemplate.TabIndex = 3
			Me.btnGetTemplate.Text = "Download Template"
			'
			'btnImport
			'
			Me.btnImport.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
			Me.btnImport.Location = New System.Drawing.Point(608, 360)
			Me.btnImport.Name = "btnImport"
			Me.btnImport.Size = New System.Drawing.Size(80, 23)
			Me.btnImport.TabIndex = 5
			Me.btnImport.Text = "Import"
			'
			'btnLoadFile
			'
			Me.btnLoadFile.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
			Me.btnLoadFile.Location = New System.Drawing.Point(544, 8)
			Me.btnLoadFile.Name = "btnLoadFile"
			Me.btnLoadFile.TabIndex = 1
			Me.btnLoadFile.Text = "Load File"
			'
			'txtFile
			'
			Me.txtFile.AutoSize = False
			Me.txtFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtFile.Location = New System.Drawing.Point(8, 8)
			Me.txtFile.Name = "txtFile"
			Me.txtFile.ReadOnly = True
			Me.txtFile.Size = New System.Drawing.Size(528, 24)
			Me.txtFile.TabIndex = 0
			Me.txtFile.Text = ""
			'
			'DataGrid1
			'
			Me.DataGrid1.CaptionText = "Data File Contents"
			Me.DataGrid1.DataMember = ""
			Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
			Me.DataGrid1.Location = New System.Drawing.Point(8, 96)
			Me.DataGrid1.Name = "DataGrid1"
			Me.DataGrid1.ReadOnly = True
			Me.DataGrid1.Size = New System.Drawing.Size(680, 248)
			Me.DataGrid1.TabIndex = 2
			'
			'lblMsg
			'
			Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblMsg.ForeColor = System.Drawing.Color.Red
			Me.lblMsg.Location = New System.Drawing.Point(56, 40)
			Me.lblMsg.Name = "lblMsg"
			Me.lblMsg.Size = New System.Drawing.Size(416, 16)
			Me.lblMsg.TabIndex = 4
			Me.lblMsg.Text = "The selected file is not a valid ASN source file and cannot be imported."
			'
			'Label2
			'
			Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label2.Location = New System.Drawing.Point(8, 392)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(672, 16)
			Me.Label2.TabIndex = 6
			Me.Label2.Text = "This screen is used to import a WFM ASN file."
			'
			'Label1
			'
			Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.Label1.ForeColor = System.Drawing.Color.Blue
			Me.Label1.Location = New System.Drawing.Point(8, 56)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(672, 32)
			Me.Label1.TabIndex = 7
			Me.Label1.Text = "Please select a CSV file to import by clicking on the Load File button.  If the f" & _
			"ile contents displayed look correct click the import button to import the data. " & _
			"Any records that fail to import will remain in the list."
			'
			'btnClear
			'
			Me.btnClear.Location = New System.Drawing.Point(632, 8)
			Me.btnClear.Name = "btnClear"
			Me.btnClear.Size = New System.Drawing.Size(56, 23)
			Me.btnClear.TabIndex = 8
			Me.btnClear.Text = "Clear"
			'
			'lblRecordCount
			'
			Me.lblRecordCount.BackColor = System.Drawing.Color.White
			Me.lblRecordCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			Me.lblRecordCount.Location = New System.Drawing.Point(448, 360)
			Me.lblRecordCount.Name = "lblRecordCount"
			Me.lblRecordCount.Size = New System.Drawing.Size(136, 23)
			Me.lblRecordCount.TabIndex = 9
			Me.lblRecordCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			'
			'frmTmoAsnImport
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(696, 414)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecordCount, Me.btnClear, Me.Label1, Me.Label2, Me.lblMsg, Me.DataGrid1, Me.txtFile, Me.btnLoadFile, Me.btnImport, Me.btnGetTemplate})
			Me.Name = "frmTmoAsnImport"
			Me.Text = "WFM ASN File Import"
			CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"

		Private fileToOpen As String		  'the file to be opened and read
		Private responseFileDialog As DialogResult		   'response from OpenFileDialog
		Private myStreamReader As StreamReader		 'the reader object to get contents of file
		Private myStreamWriter As StreamWriter		 'the writer object to save contents of textbox
		Private _dt As New DataTable()
		Private _user_id As Integer = 0

#End Region
#Region "FORM EVENTS"

		Private Sub frmTmoAsnImport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			_user_id = PSS.Core.ApplicationUser.IDuser
			ClearMsg()
			EnableControls()
			PopulateRecordCount()
		End Sub

#End Region
#Region "CONTROL EVENTS"

		Private Sub btnGetTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetTemplate.Click
			Dim _sourceFile As String = "R:\LOBTasks\Tracfone\TmoImport\Template\WFM_ASN_Template.csv"
			sfdTemplate.InitialDirectory = Environment.CurrentDirectory
			sfdTemplate.Title = "Save File As...."
			sfdTemplate.Filter = "CSV Files (*.csv)|*.csv"
			sfdTemplate.FileName = "WFM_ASN_TEMPLATE_" & Date.Now.ToString("yyyyMMdd") & ".csv"
			If Me.sfdTemplate.ShowDialog() = DialogResult.OK Then
				File.Copy(_sourceFile, sfdTemplate.FileName)
			End If
		End Sub
		Private Sub btnLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadFile.Click
			Try
				txtFile.Text = ""
				DataGrid1.DataSource = Nothing
				LoadTheFile()
				PopulateRecordCount()
				EnableControls()
			Catch ex As Exception
				MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Function BuildImportTable() As DataTable
			Dim _dt As New DataTable()
			_dt.TableName = "WFM_ASN"
			_dt.Columns.Add("CARTON", GetType(String))
			_dt.Columns.Add("LOC_DESC", GetType(String))
			_dt.Columns.Add("SUB_LOCATION", GetType(String))
			_dt.Columns.Add("SKU", GetType(String))
			_dt.Columns.Add("MAKE", GetType(String))
			_dt.Columns.Add("MODEL", GetType(String))
			_dt.Columns.Add("SERIAL_NO", GetType(String))
			_dt.AcceptChanges()
			Return _dt
		End Function
		Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
			Dim _import_count As Integer = 0
			Dim _error_count As Integer = 0
			If MessageBox.Show("Continue and import the records displayed?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
				Dim _dt As New DataTable()
				_dt = DataGrid1.DataSource
				Dim i As Integer = 0
				For i = (_dt.Rows.Count - 1) To 0 Step -1
					If ImportRow(_dt.Rows(i)) Then
						_import_count = _import_count + 1
						_dt.Rows(i).Delete()
					Else
						_dt.Rows(i)("import_info") = "Possible Duplicate"
						_error_count = _error_count + 1
					End If
				Next
				If _error_count > 0 Then
					Dim _error_msg As New StringBuilder()
					_error_msg.Append("Error(s) occurred during the import.")
					_error_msg.Append(vbCrLf)
					_error_msg.Append(vbTab)
					_error_msg.Append(_import_count.ToString & " ")
					_error_msg.Append("Record(s) Imported")
					_error_msg.Append(vbCrLf)
					_error_msg.Append(vbTab)
					_error_msg.Append(_error_count.ToString & " ")
					_error_msg.Append("Record(s) Failed to Import")
					_error_msg.Append(vbCrLf)
					_error_msg.Append(vbCrLf)
					_error_msg.Append("Please review the remaining rows and correct them if neccessary.")
					_error_msg.Append("")
					MessageBox.Show(_error_msg.ToString(), Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Else
					ResetScreen()
					MessageBox.Show("Import completed successfully with " & _import_count.ToString() & " Record(s) imported.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
				End If
				PopulateRecordCount()
			End If
		End Sub
		Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
			Dim _msg As String = "Reset the screen back to its original state?"
			If MessageBox.Show(_msg, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
				ResetScreen()
				PopulateRecordCount()
			End If
		End Sub

#End Region
#Region "METHODS"

		Private Sub LoadTheFile()
			Dim fileContentString As String			   'contents of the file
			'set the properties of the OpenFileDialog object
			ofdSource.InitialDirectory = Environment.CurrentDirectory
			ofdSource.Title = "Select File to Load...."
			ofdSource.Filter = "CSV Files (*.csv)|*.csv"
			Try
				If ofdSource.ShowDialog() = DialogResult.OK Then
					txtFile.Text = ofdSource.FileName
					'check to see if the user select OKAY, if not they selected CANCEL so don't open anything
					'make sure there isn't a file already open, if there is then close it
					If (Not myStreamReader Is Nothing) Then
						myStreamReader.Close()
						'TextBoxFileOutput.Clear()
					End If
					'open the file and read its text and display in the textbox
					fileToOpen = ofdSource.FileName
					myStreamReader = New StreamReader(ofdSource.FileName)
					_dt = BuildImportTable()
					_dt.Columns.Add("import_info", GetType(String))
					_dt.AcceptChanges()

					fileContentString = myStreamReader.ReadLine()
					'loop through the file reading its text and adding it to the textbox on the form
					Do Until myStreamReader.Peek = -1
						fileContentString = myStreamReader.ReadLine()
						Dim aaa() As String
						If fileContentString.Split(",").Length > 7 Then
							Throw New Exception("Invalid data length.")
						End If
						aaa = fileContentString.Split(",")
						Dim i As Integer
						Dim _dr As DataRow
						_dr = _dt.NewRow()
						For i = 0 To 6
							_dr(i) = aaa(i).ToString()
						Next
						_dr(7) = ""
						_dt.Rows.Add(_dr)
					Loop
					myStreamReader.Close()
					DataGrid1.DataSource = _dt
				End If
			Catch ex As Exception
				Throw New Exception("Invalid ASN File")
				DataGrid1.DataSource = Nothing
			End Try
		End Sub
		Private Sub EnableControls()
			btnImport.Enabled = (txtFile.Text <> "" AndAlso DataGrid1.VisibleRowCount > 0)
		End Sub
		Private Sub PostMsg(ByVal text As String)
			' POST A MESSAGE TO THE USER.
			lblMsg.Text = text
			Me.Refresh()
		End Sub
		Private Sub ClearMsg()
			' CLEARS MESSAGES POSTED TO THE USER.
			lblMsg.Text = ""
		End Sub
		Private Sub ResetScreen()
			_dt.Clear()
			DataGrid1.DataSource = Nothing
			txtFile.Text = ""
			ClearMsg()
			EnableControls()
			PopulateRecordCount()
		End Sub
		Private Function ImportRow(ByVal dr As DataRow) As Boolean
			Try
				Dim _rec As New Data.BOL.ttf_bx_phn_asn()
				_rec.carton = dr(0).ToString()
				_rec.loc_desc = dr(1).ToString()
				_rec.pallet = dr(2).ToString()
				_rec.sku = dr(3).ToString()
				_rec.make = dr(4).ToString()
				_rec.model = dr(5).ToString()
				_rec.serial_nr = dr(6).ToString()
				_rec.crt_user_id = _user_id
				_rec.ApplyChanges()
				Return True
			Catch ex As Exception
				Return False
			End Try
		End Function
		Private Sub PopulateRecordCount()
			lblRecordCount.Text = _dt.Rows.Count.ToString & " Record(s)"
		End Sub

#End Region

	End Class

End Namespace
