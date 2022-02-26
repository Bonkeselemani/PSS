'Option Explicit On 

'Imports System.Data.OleDb
'Imports PSS.Data.Buisness
'Imports PSS.Core.Global

'Public Class frmDyscernAdmin
'    Inherits System.Windows.Forms.Form

'    Private _objDyscern As Dyscern

'#Region " Windows Form Designer generated code "

'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call
'        _objDyscern = New Dyscern()
'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'            _objDyscern = Nothing
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Friend WithEvents btnLoadASNFile As System.Windows.Forms.Button
'    Friend WithEvents btnRecRptByWO As System.Windows.Forms.Button
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Me.btnLoadASNFile = New System.Windows.Forms.Button()
'        Me.btnRecRptByWO = New System.Windows.Forms.Button()
'        Me.SuspendLayout()
'        '
'        'btnLoadASNFile
'        '
'        Me.btnLoadASNFile.BackColor = System.Drawing.Color.LightSteelBlue
'        Me.btnLoadASNFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.btnLoadASNFile.ForeColor = System.Drawing.Color.Black
'        Me.btnLoadASNFile.Location = New System.Drawing.Point(16, 8)
'        Me.btnLoadASNFile.Name = "btnLoadASNFile"
'        Me.btnLoadASNFile.Size = New System.Drawing.Size(160, 48)
'        Me.btnLoadASNFile.TabIndex = 0
'        Me.btnLoadASNFile.Text = "Load ASN File"
'        Me.btnLoadASNFile.Visible = False
'        '
'        'btnRecRptByWO
'        '
'        Me.btnRecRptByWO.BackColor = System.Drawing.Color.LightSteelBlue
'        Me.btnRecRptByWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.btnRecRptByWO.ForeColor = System.Drawing.Color.Black
'        Me.btnRecRptByWO.Location = New System.Drawing.Point(16, 72)
'        Me.btnRecRptByWO.Name = "btnRecRptByWO"
'        Me.btnRecRptByWO.Size = New System.Drawing.Size(160, 48)
'        Me.btnRecRptByWO.TabIndex = 1
'        Me.btnRecRptByWO.Text = "Receiving Report By Workorder"
'        '
'        'frmDyscernAdmin
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.BackColor = System.Drawing.Color.SteelBlue
'        Me.ClientSize = New System.Drawing.Size(292, 273)
'        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRecRptByWO, Me.btnLoadASNFile})
'        Me.Name = "frmDyscernAdmin"
'        Me.Text = "frmAdmin"
'        Me.ResumeLayout(False)

'    End Sub

'#End Region

'    '**************************************************************
'    Private Sub frmDyscernAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Try
'            If ApplicationUser.GetPermission("Dyscern_LoadFile") > 0 Then Me.btnLoadASNFile.Visible = True
'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "frmDyscernAdmin_Load", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'        End Try
'    End Sub

'    '**************************************************************
'    Private Sub btnLoadASNFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadASNFile.Click
'        Dim fdOpenFile As OpenFileDialog
'        Dim strFilePath As String = ""
'        Dim i As Integer = 0
'        Dim arrTemp() As String
'        Dim strWoName As String = ""
'        Dim dt As DataTable
'        Dim iTotalDupUnits As Integer = 0

'        Try
'            fdOpenFile = New OpenFileDialog()
'            fdOpenFile.DefaultExt = ".*"
'            fdOpenFile.ShowDialog()
'            strFilePath = fdOpenFile.FileName
'            arrTemp = strFilePath.Split("\")
'            strWoName = arrTemp(arrTemp.Length - 1).ToString.Replace(".xls", "")

'            If strFilePath.Trim.Length = 0 Then
'                Exit Sub
'            Else
'                If Me._objDyscern.IsWorkorderExisted(strWoName) = True Then
'                    MessageBox.Show("Workorder """ & strWoName.ToUpper & """ already existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'                Else
'                    dt = Me.GetDataFrExcel(strFilePath)
'                    If dt.Rows.Count = 0 Then
'                        MessageBox.Show("No record found in the data file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'                    Else
'                        If MessageBox.Show("Workorder: " & strWoName.ToUpper & Environment.NewLine & "Quantity:" & dt.Rows.Count & Environment.NewLine & "Would you like to load into system?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then Exit Sub

'                        Me.Enabled = False
'                        Cursor.Current = Cursors.WaitCursor

'                        i = Me._objDyscern.LoadASNFile(strWoName, ApplicationUser.IDuser, ApplicationUser.User, dt, iTotalDupUnits)
'                        If i > 0 Then
'                            MessageBox.Show(dt.Rows.Count & " unit(s) has been loaded into system with " & iTotalDupUnits & " duplicate.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
'                        End If
'                    End If
'                End If
'            End If
'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "btnLoadASNFile_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'        Finally
'            If Not IsNothing(fdOpenFile) Then
'                fdOpenFile.Dispose()
'                fdOpenFile = Nothing
'            End If
'            Me.Enabled = True
'            Cursor.Current = Cursors.Default
'        End Try
'    End Sub

'    '**************************************************************
'    Private Function GetDataFrExcel(ByVal FilePath As String) As DataTable
'        Dim objExcel As Object = Nothing    ' Excel application
'        Dim objBook As Object = Nothing     ' Excel workbook
'        Dim objSheet As Object = Nothing    ' Excel Worksheet
'        Dim sConnectionstring As String
'        Dim objConn As New OleDbConnection()
'        Dim objCmdSelect As New OleDbCommand()
'        Dim objAdapter1 As New OleDbDataAdapter()
'        Dim objDataset1 As New DataSet()
'        Dim dt As New DataTable()
'        Dim strSql As String = ""
'        Dim i As Integer = 0

'        Try
'            '//Create a datatable of all values from the assigned file
'            sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FilePath & ";Extended Properties=Excel 8.0;"
'            objConn.ConnectionString = sConnectionstring
'            objConn.Open()

'            strSql = "SELECT [DID] as DID " & Environment.NewLine
'            strSql &= ", '" & Core.ApplicationUser.User & "' as Name " & Environment.NewLine
'            strSql &= ", " & Core.ApplicationUser.IDuser & " as UsrID " & Environment.NewLine
'            strSql &= ", 2 as GroupID " & Environment.NewLine
'            strSql &= "FROM [Sheet1$] WHERE [DID] is not null ORDER BY [DID]"
'            objCmdSelect.CommandText = (strSql)

'            objCmdSelect.Connection = objConn
'            objAdapter1.SelectCommand = objCmdSelect
'            objAdapter1.Fill(dt)
'            objAdapter1.Fill(objDataset1, "XLData")
'            'objConn.Close()

'            Return dt
'        Catch ex As Exception
'            Throw ex
'        Finally
'            Generic.DisposeDT(dt)
'            '*************************************
'            'Excel clean up
'            If Not IsNothing(objSheet) Then
'                objSheet = Nothing
'                Generic.NAR(objSheet)
'            End If
'            If Not IsNothing(objBook) Then
'                objBook.Close(False)
'                Generic.NAR(objBook)
'            End If
'            If Not IsNothing(objExcel) Then
'                objExcel.Quit()
'                objExcel = Nothing
'                Generic.NAR(objExcel)
'            End If

'            If Not IsNothing(objConn) Then
'                objConn.Close()
'                objConn.Dispose()
'                objConn = Nothing
'            End If
'            If Not IsNothing(objCmdSelect) Then
'                objCmdSelect.Dispose()
'                objCmdSelect = Nothing
'            End If
'            If Not IsNothing(objAdapter1) Then
'                objAdapter1.Dispose()
'                objAdapter1 = Nothing
'            End If
'            If Not IsNothing(objDataset1) Then
'                objDataset1.Dispose()
'                objDataset1 = Nothing
'            End If
'            GC.Collect()
'            GC.WaitForPendingFinalizers()
'            GC.Collect()
'            GC.WaitForPendingFinalizers()
'        End Try
'    End Function

'    '**************************************************************
'    Private Sub btnRecRptByWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecRptByWO.Click
'        Dim strWOName As String = ""
'        Dim i As Integer = 0

'        Try
'            strWOName = InputBox("Enter Workorder Name:").Trim
'            If strWOName.Trim.Length = 0 Then Exit Sub
'            i = Me._objDyscern.ReceivingDetailRptByWO(strWOName)
'            If i = 0 Then MessageBox.Show("No data found for this workorder name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
'        Catch ex As Exception
'            MessageBox.Show(ex.ToString, "btnLoadASNFile_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
'        End Try
'    End Sub

'    '**************************************************************

'End Class
