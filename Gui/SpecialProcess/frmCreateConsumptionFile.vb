Imports eInfoDesigns.dbProvider.MySqlClient
Imports Microsoft.Data.Odbc

Imports PSS.Data
Imports PSS.Core
Imports PSS.rules
Imports PSS.Core.[Global]
Imports System
Imports System.Data
Imports System.GC
Imports System.IO
Imports System.Data.OleDb

Imports System.Net
Imports System.Net.Dns


Namespace Gui.SpecialProcess

    Public Class frmCreateConsumptionFile
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
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents btnCreate As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents btnNewProcessInvoiced As System.Windows.Forms.Button
        Friend WithEvents btnDevelopment As System.Windows.Forms.Button
        Friend WithEvents btnUsage As System.Windows.Forms.Button
        Friend WithEvents btnDeviceCount As System.Windows.Forms.Button
        Friend WithEvents btnGetData_07132007 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblDescription = New System.Windows.Forms.Label()
            Me.btnCreate = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.btnNewProcessInvoiced = New System.Windows.Forms.Button()
            Me.btnDevelopment = New System.Windows.Forms.Button()
            Me.btnUsage = New System.Windows.Forms.Button()
            Me.btnDeviceCount = New System.Windows.Forms.Button()
            Me.btnGetData_07132007 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblDescription
            '
            Me.lblDescription.BackColor = System.Drawing.SystemColors.Control
            Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDescription.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblDescription.Location = New System.Drawing.Point(16, 8)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(408, 128)
            Me.lblDescription.TabIndex = 0
            Me.lblDescription.Text = "This process creates the data files needed to record the consumption process. The" & _
            " process will ask you for the date to run for parts consumption. The file must b" & _
            "e loaded and posted to the Navision database. This is designed for a one day run" & _
            ". "
            Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnCreate
            '
            Me.btnCreate.Location = New System.Drawing.Point(512, 416)
            Me.btnCreate.Name = "btnCreate"
            Me.btnCreate.Size = New System.Drawing.Size(152, 48)
            Me.btnCreate.TabIndex = 1
            Me.btnCreate.Text = "Create Part Consumption File"
            Me.btnCreate.Visible = False
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.SystemColors.Control
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(32, 200)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(344, 16)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "1) Run Process For Single Date"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.SystemColors.Control
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(32, 224)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(344, 16)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "2) Start Navision System"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.SystemColors.Control
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(32, 248)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(344, 16)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "3) Use Tools - Object Designer - selection 50005 (PSSi Net)"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.SystemColors.Control
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label4.Location = New System.Drawing.Point(88, 272)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(280, 40)
            Me.Label4.TabIndex = 5
            Me.Label4.Tag = ""
            Me.Label4.Text = "Select RUN - then Options and select Date File(R:\InventoryData\[The file will be" & _
            " in the format of YYYY-MM-DDDATA, i.e. 2005-09-06DATA.txt])"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.SystemColors.Control
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(32, 320)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(344, 16)
            Me.Label5.TabIndex = 6
            Me.Label5.Text = "4) Once Data File Has Been Loaded - Then Post"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.SystemColors.Control
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label6.Location = New System.Drawing.Point(8, 144)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(408, 34)
            Me.Label6.TabIndex = 7
            Me.Label6.Text = "IMPORTANT - PLEASE RUN 1 DAY AND POST BEFORE RUNNING ANOTHER DAY."
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(512, 360)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(152, 48)
            Me.Button1.TabIndex = 8
            Me.Button1.Text = "Process"
            Me.Button1.Visible = False
            '
            'Button2
            '
            Me.Button2.ForeColor = System.Drawing.Color.Black
            Me.Button2.Location = New System.Drawing.Point(40, 352)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(328, 32)
            Me.Button2.TabIndex = 9
            Me.Button2.Text = "NEW Process"
            '
            'btnNewProcessInvoiced
            '
            Me.btnNewProcessInvoiced.ForeColor = System.Drawing.Color.Black
            Me.btnNewProcessInvoiced.Location = New System.Drawing.Point(40, 392)
            Me.btnNewProcessInvoiced.Name = "btnNewProcessInvoiced"
            Me.btnNewProcessInvoiced.Size = New System.Drawing.Size(328, 32)
            Me.btnNewProcessInvoiced.TabIndex = 10
            Me.btnNewProcessInvoiced.Text = "NEW Process Invoiced"
            '
            'btnDevelopment
            '
            Me.btnDevelopment.Location = New System.Drawing.Point(512, 472)
            Me.btnDevelopment.Name = "btnDevelopment"
            Me.btnDevelopment.Size = New System.Drawing.Size(152, 48)
            Me.btnDevelopment.TabIndex = 11
            Me.btnDevelopment.Text = "Development ONLY - DO NOT USE FOR PRODUCTION"
            Me.btnDevelopment.Visible = False
            '
            'btnUsage
            '
            Me.btnUsage.Location = New System.Drawing.Point(464, 16)
            Me.btnUsage.Name = "btnUsage"
            Me.btnUsage.Size = New System.Drawing.Size(144, 32)
            Me.btnUsage.TabIndex = 12
            Me.btnUsage.Text = "Part Usage LOAD"
            Me.btnUsage.Visible = False
            '
            'btnDeviceCount
            '
            Me.btnDeviceCount.Location = New System.Drawing.Point(464, 56)
            Me.btnDeviceCount.Name = "btnDeviceCount"
            Me.btnDeviceCount.Size = New System.Drawing.Size(144, 32)
            Me.btnDeviceCount.TabIndex = 13
            Me.btnDeviceCount.Text = "Device Count"
            Me.btnDeviceCount.Visible = False
            '
            'btnGetData_07132007
            '
            Me.btnGetData_07132007.ForeColor = System.Drawing.Color.Black
            Me.btnGetData_07132007.Location = New System.Drawing.Point(512, 280)
            Me.btnGetData_07132007.Name = "btnGetData_07132007"
            Me.btnGetData_07132007.Size = New System.Drawing.Size(152, 72)
            Me.btnGetData_07132007.TabIndex = 14
            Me.btnGetData_07132007.Text = "PROCESS TO BREAKDOWN DEPARTMENTS BY 520,560,563"
            Me.btnGetData_07132007.Visible = False
            '
            'frmCreateConsumptionFile
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(672, 525)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGetData_07132007, Me.btnDeviceCount, Me.btnUsage, Me.btnDevelopment, Me.btnNewProcessInvoiced, Me.Button2, Me.Button1, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.btnCreate, Me.lblDescription})
            Me.Name = "frmCreateConsumptionFile"
            Me.Text = "Consumption File Creation"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click


            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
            Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"""

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(dtBin)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            nda.Dispose()
            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - END

            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow
            Dim xCount, validCount As Integer
            Dim strDate, strFileDate, vDateEnd As String
            Dim strFile, strFileAdj As String
            Dim vDate As String

            Dim vDate1 As Date
            Dim blnValid As Boolean

            Dim strInvalidReason As String
            Dim step1, step2 As Boolean
            step1 = False
            step2 = False

            Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                vDate1 = InputBox("Enter date to process", "Enter Date", Format(Now, "M/d/yy"))
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Catch ex As Exception
                MsgBox("The date you entered is invalid. The process will now end. Please try again.", MsgBoxStyle.OKOnly, "ERROR")
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End Try

            vDate = Format(vDate1, "M/d/yy")

            strFileDate = vDate
            strDate = Gui.Receiving.FormatDateShort(vDate)
            vDate = Gui.Receiving.FormatDateShort(vDate) & " 00:00:00"
            vDateEnd = Gui.Receiving.FormatDateShort(vDate) & " 23:59:59"
            strFile = strDate & "DATA.txt"
            strFileAdj = strDate & "ADJ.txt"

            Dim xFileCheck As Integer = checkFile(strFile)
            If xFileCheck = 1 Then
                MsgBox("Please remove file before running.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim fs As New FileStream("R:\InventoryData\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsAdj As New FileStream("R:\InventoryData\" & strFileAdj, FileMode.Create, FileAccess.Write)
            Dim sAdj As New StreamWriter(fsAdj)
            sAdj.BaseStream.Seek(0, SeekOrigin.End)

            Dim strData As String

            '//Section 1 reclaimed
            Dim strSQL As String = "select lwclocation.wc_location as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
                                    "tparttransaction left outer join lwclocation on tparttransaction.binloc = lwclocation.wclocation_id " & _
                                    "inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                                    "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 and tparttransaction.trans_amount = -1 " & _
                                    "and lpsprice.psprice_inventorypart = 1 " & _
                                    "and tcustomer.biztype_id = 0 " & _
                                    "group by lwclocation.wc_location, lpsprice.psprice_number"


            Dim dtCellReclaim As DataTable = ds.OrderEntrySelect(strSQL)

            For xCount = 0 To dtCellReclaim.Rows.Count - 1
                r = dtCellReclaim.Rows(xCount)

                blnValid = False
                For validCount = 0 To dtBin.Rows.Count - 1
                    rBin = dtBin.Rows(validCount)

                    If Trim(rBin("BinLocation").ToString) = Trim(r("location").ToString) Then
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            blnValid = True
                            step1 = True
                            Exit For
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = ""
                    End If
                Next

                If blnValid = True Then
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Positive" & vbTab & strFileDate & vbTab & r("department")
                    s.WriteLine(strData)
                Else
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Positive" & vbTab & strFileDate & vbTab & r("department") & vbTab & strInvalidReason
                    sAdj.WriteLine(strData)
                End If
                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

            strSQL = "select lwclocation.wc_location as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
                     "tparttransaction left outer join lwclocation on tparttransaction.binloc = lwclocation.wclocation_id " & _
                     "inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                     "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                     "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                     "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                     "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 and tparttransaction.trans_amount = 1 " & _
                     "and lpsprice.psprice_inventorypart = 1 " & _
                     "and tcustomer.biztype_id = 0 " & _
                     "group by lwclocation.wc_location, lpsprice.psprice_number"

            Dim dtCellConsume As DataTable = ds.OrderEntrySelect(strSQL)

            For xCount = 0 To dtCellConsume.Rows.Count - 1
                r = dtCellConsume.Rows(xCount)

                blnValid = False
                For validCount = 0 To dtBin.Rows.Count - 1
                    rBin = dtBin.Rows(validCount)
                    If Trim(rBin("BinLocation").ToString) = Trim(r("location").ToString) Then
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            step1 = True
                            If CInt(r("count")) <= CInt(rBin("qty")) Then
                                blnValid = True
                                Exit For
                            End If
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = "Part Count Exceeds Quantity Available"""
                    End If
                Next

                If blnValid = True Then
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Negative" & vbTab & strFileDate & vbTab & r("department")
                    s.WriteLine(strData)
                Else
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Negative" & vbTab & strFileDate & vbTab & r("department") & vbTab & strInvalidReason
                    sAdj.WriteLine(strData)
                End If
                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

            strSQL = "select lwclocation.wc_altloc as location, lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                     "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                     "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                     "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                     "inner join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                     "inner join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                     "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                     "and lpsprice.psprice_inventorypart = 1 " & _
                     "and tcustomer.biztype_id = 0 " & _
                     "group by lwclocation.wc_altloc, lpsprice.psprice_number"

            Dim dtPageConsume As DataTable = ds.OrderEntrySelect(strSQL)

            For xCount = 0 To dtPageConsume.Rows.Count - 1
                r = dtPageConsume.Rows(xCount)

                blnValid = False
                For validCount = 0 To dtBin.Rows.Count - 1
                    rBin = dtBin.Rows(validCount)
                    If Trim(rBin("BinLocation").ToString) = Trim(r("location").ToString) Then
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            step1 = True
                            If CInt(r("count")) <= CInt(rBin("qty")) Then
                                blnValid = True
                                Exit For
                            End If
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = "Part Count Exceeds Quantity Available"""
                    End If
                Next

                If blnValid = True Then
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Negative" & vbTab & strFileDate & vbTab & r("department")
                    s.WriteLine(strData)
                Else
                    strData = r("location") & vbTab & r("number") & vbTab & r("count") & vbTab & "Negative" & vbTab & strFileDate & vbTab & r("department") & vbTab & strInvalidReason
                    sAdj.WriteLine(strData)
                End If

                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

            s.Close()
            sAdj.Close()
            Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("File Creation Is Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        End Sub

        Private Shared Function checkFile(ByVal mFileName As String) As Integer

        End Function

        Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

        End Sub

        Private Sub frmCreateConsumptionFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
            Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"""

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(dtBin)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            nda.Dispose()
            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - END

            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow
            Dim xCount, validCount As Integer
            Dim strDate, strFileDate, vDateEnd As String
            Dim strFile, strFileAdj As String
            Dim vDate As String

            Dim vDate1 As Date
            Dim blnValid As Boolean

            Dim strInvalidReason As String
            Dim step1, step2 As Boolean
            step1 = False
            step2 = False

            Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                vDate1 = InputBox("Enter date to process", "Enter Date", Format(Now, "M/d/yy"))
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Catch ex As Exception
                MsgBox("The date you entered is invalid. The process will now end. Please try again.", MsgBoxStyle.OKOnly, "ERROR")
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End Try

            vDate = Format(vDate1, "M/d/yy")

            strFileDate = vDate
            strDate = Gui.Receiving.FormatDateShort(vDate)
            vDate = Gui.Receiving.FormatDateShort(vDate) & " 00:00:00"
            vDateEnd = Gui.Receiving.FormatDateShort(vDate) & " 23:59:59"
            strFile = "TEST" & strDate & "DATA.txt"
            strFileAdj = "TEST" & strDate & "ADJ.txt"

            Dim xFileCheck As Integer = checkFile(strFile)
            If xFileCheck = 1 Then
                MsgBox("Please remove file before running.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim fs As New FileStream("R:\InventoryData\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsAdj As New FileStream("R:\InventoryData\" & strFileAdj, FileMode.Create, FileAccess.Write)
            Dim sAdj As New StreamWriter(fsAdj)
            sAdj.BaseStream.Seek(0, SeekOrigin.End)

            Dim strData As String

            '//This line is used to not select Asset Recovery Customers
            '"and tcustomer.biztype_id = 0 " & _
            '//This line is used to not select Asset Recovery Customers

            '//Section 1 reclaimed - SFCELL
            Dim strSQL As String
            'strSQL = "select lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count from " & _
            '                        "tparttransaction left outer join lwclocation on tparttransaction.binloc = lwclocation.wclocation_id " & _
            '                        "inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '                        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '                        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '                        "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 and tparttransaction.trans_amount = -1 " & _
            '                        "and lpsprice.psprice_inventorypart = 1 " & _
            '                        "group by lpsprice.psprice_number"'

            'Write2File(strSQL, s, sAdj, dtBin, "SFCELL", strFileDate, "560", "Positive")
            'System.Windows.Forms.Application.DoEvents()

            '            '//Section 2 consumed - SFCELL
            '            strSQL = "select lpsprice.psprice_number as number, count(tparttransaction.trans_amount) as count, lwclocation.dept_id as department  from " & _
            '                     "tparttransaction left outer join lwclocation on tparttransaction.binloc = lwclocation.wclocation_id " & _
            '                     "inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '                     "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '                     "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '                     "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '                     "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 and tparttransaction.trans_amount = 1 " & _
            '                     "and lpsprice.psprice_inventorypart = 1 " & _
            '                     "group by lpsprice.psprice_number"

            '//Section 1 and 2 consumed and reclaimed - SFCELL
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML01' or lwclocation.wc_altloc is null) " & _
                    "group by lpsprice.psprice_number"

            Write2File(strSQL, s, sAdj, dtBin, "SFCELL", strFileDate, "560", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 3 consumed - SFML01
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML01' or lwclocation.wc_altloc is null) " & _
                    "group by lpsprice.psprice_number"

            Write2File(strSQL, s, sAdj, dtBin, "SFML01", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 4 consumed - SFML03
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count from " & _
                    "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML03')" & _
                    "group by lpsprice.psprice_number"

            Write2File(strSQL, s, sAdj, dtBin, "SFML03", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            s.Close()
            sAdj.Close()
            Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("File Creation Is Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        End Sub



        Private Sub Write2File(ByVal vSQL As String, ByRef vs As StreamWriter, ByRef vsAdj As StreamWriter, ByVal vBin As DataTable, ByVal strBin As String, ByVal vstrFileDate As String, ByVal vstrDepartment As String, ByVal vType As String)

            Dim ds As PSS.Data.Production.Joins
            Dim xCount, validCount As Integer
            Dim r, rBin As DataRow
            Dim blnValid, step1 As Boolean
            Dim strInvalidReason, strData As String

            Dim intQty, intQtyPart As Long
            Dim mType, mTypeALT As String


            Dim dtPageConsume As DataTable = ds.OrderEntrySelect(vSQL)

            Dim strLocation As String = strBin
            Dim strLocationALT As String = "WIP"

            For xCount = 0 To dtPageConsume.Rows.Count - 1
                r = dtPageConsume.Rows(xCount)

                If CInt(r("count")) < 0 Then
                    intQty = r("count") * -1
                    mType = "Positive"
                    mTypeALT = "Negative"
                Else
                    intQty = CInt(r("count"))
                    mType = "Negative"
                    mTypeALT = "Positive"
                End If

                intQtyPart = 0

                blnValid = False
                For validCount = 0 To vBin.Rows.Count - 1
                    rBin = vBin.Rows(validCount)
                    If Trim(rBin("BinLocation").ToString) = strLocation Then
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            step1 = True
                            If CInt(r("count")) <= CInt(rBin("qty")) Then
                                blnValid = True
                                Exit For
                            Else
                                intQty = CInt(rBin("qty"))
                                If intQty > 0 Then
                                    blnValid = True
                                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment
                                    'vs.WriteLine(strData)
                                    strInvalidReason = "Part Count Exceeds Quantity Available"""
                                    intQtyPart = CInt(r("count")) - CInt(rBin("qty"))
                                    strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                                    vsAdj.WriteLine(strData)
                                    System.Windows.Forms.Application.DoEvents()
                                    strData = strLocationALT & vbTab & r("number") & vbTab & intQtyPart & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                                    vsAdj.WriteLine(strData)
                                    Exit For
                                Else
                                    intQty = CInt(r("count"))
                                End If
                            End If
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = "Part Count Exceeds Quantity Available"""
                    End If
                Next

                If blnValid = True Then
                    'strData = strLocation & vbTab & r("number") & vbTab & r("count") & vbTab & vType & vbTab & vstrFileDate & vbTab & vstrDepartment
                    strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment
                    vs.WriteLine(strData)
                    System.Windows.Forms.Application.DoEvents()
                    strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment
                    vs.WriteLine(strData)
                Else
                    'strData = strLocation & vbTab & r("number") & vbTab & r("count") & vbTab & vType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    'If intQtyPart = 0 Then
                    strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    vsAdj.WriteLine(strData)
                    System.Windows.Forms.Application.DoEvents()
                    strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    vsAdj.WriteLine(strData)
                    'End If
                    intQtyPart = 0
                End If

                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '//Update prod_id in tparttransaction
            Dim blnProd As Boolean
            Dim dsProd As PSS.Data.Production.Joins
            blnProd = dsProd.OrderEntryUpdateDelete("update tparttransaction, tdevice, tmodel set tparttransaction.prod_id = tmodel.prod_id where " & _
            "tparttransaction.device_id = tdevice.device_id " & _
            "and tdevice.model_id = tmodel.model_id " & _
            "and date_server > '2007-08-29 00:00:00'")
            '//Update prod_id in tparttransaction

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
            Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"""


            '//This is temporary
            'Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"" WHERE ""Bin Code"" = 'SFC11'"

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(dtBin)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '//
            'Dim x As Integer
            'Dim xr As DataRow
            'For x = 0 To dtBin.Rows.Count - 1
            'xr = dtBin.Rows(x)
            'MsgBox(xr("BinLocation") & "  " & xr("Part") & "  " & xr("qty"))
            'Next
            '//
            'Exit Sub

            nda.Dispose()
            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - END

            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow
            Dim xCount, validCount As Integer
            Dim strDate, strFileDate, vDateEnd As String
            Dim strFile, strFileAdj, strFileWIP, strFileWIPREPORT, strFileNegative As String
            Dim vDate As String

            Dim vDate1 As Date


            Dim newVDate As String

            Dim blnValid As Boolean

            Dim strInvalidReason As String
            Dim step1, step2 As Boolean
            step1 = False
            step2 = False

            Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                vDate1 = InputBox("Enter date to process", "Enter Date", Format(Now, "M/d/yy"))
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Catch ex As Exception
                MsgBox("The date you entered is invalid. The process will now end. Please try again.", MsgBoxStyle.OKOnly, "ERROR")
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End Try

            vDate = Format(vDate1, "M/d/yy")
            newVDate = "WHERE Date_Server > '" & Format(vDate1, "yyyy-MM-dd") & " 06:00:00' and Date_Server < '" & Format(DateAdd(DateInterval.Day, 1, vDate1), "yyyy-MM-dd") & " 05:59:59'"

            strFileDate = vDate
            strDate = Gui.Receiving.FormatDateShort(vDate)
            vDate = Gui.Receiving.FormatDateShort(vDate)
            vDateEnd = Gui.Receiving.FormatDateShort(vDate)

            strFile = strDate & "DTP.txt"
            strFileAdj = strDate & "DATA_ADJUSTMENT_DOCUMENT(report).txt"
            strFileWIP = strDate & "WIP_ADJUSTMENT_PROCESS(process).txt"
            strFileWIPREPORT = strDate & "WIP_ADJUSTMENT_DOCUMENT(report).txt"
            'strFileNegative = "zzzNP" & strDate & "xferNegativeDATA.txt"

            Dim xFileCheck As Integer = checkFile(strFile)
            If xFileCheck = 1 Then
                MsgBox("Please remove file before running.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim fs As New FileStream("R:\InventoryData\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsAdj As New FileStream("R:\InventoryData\" & strFileAdj, FileMode.Create, FileAccess.Write)
            Dim sAdj As New StreamWriter(fsAdj)
            sAdj.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsWIP As New FileStream("R:\InventoryData\" & strFileWIP, FileMode.Create, FileAccess.Write)
            Dim sWip As New StreamWriter(fsWIP)
            sWip.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsWIPREPORT As New FileStream("R:\InventoryData\" & strFileWIPREPORT, FileMode.Create, FileAccess.Write)
            Dim sWipREPORT As New StreamWriter(fsWIPREPORT)
            sWipREPORT.BaseStream.Seek(0, SeekOrigin.End)

            'Dim fsNegative As New FileStream("R:\InventoryData\" & strFileNegative, FileMode.Create, FileAccess.Write)
            'Dim sNegative As New StreamWriter(fsNegative)
            'sNegative.BaseStream.Seek(0, SeekOrigin.End)

            Dim strData As String

            '//This line is used to not select Asset Recovery Customers
            '"and tcustomer.biztype_id = 0 " & _
            '//This line is used to not select Asset Recovery Customers

            '//Section 1 reclaimed - SFCELL
            Dim strSQL As String

            '//Section 1 and 2 consumed and reclaimed - SFCELL
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
            '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "inner join tnav_item on lpsprice.psprice_number = tnav_item.No_ " & _
            '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '        "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and ((lwclocation.wc_altloc = 'SFCELL' or lwclocation.wc_altloc is null) " & _
            '        "or (lwclocation.wc_location <> 'SFCELL' and mid(lwclocation.wc_location,1,3)= 'SFC' and tnav_item.Shelf_No_ <> 'BENCH' ))" & _
            '        "group by lpsprice.psprice_number"
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    newVDate & " and tparttransaction.prod_id=2 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and new in (1,2) " & _
                    "and ((lwclocation.wc_altloc = 'SFCELL' or lwclocation.wc_altloc is null) " & _
                    "or (lwclocation.wc_location <> 'SFCELL' and mid(lwclocation.wc_location,1,3)= 'SFC' and tnav_item.Shelf_No_ <> 'BENCH' ))" & _
                    "group by lpsprice.psprice_number"
            '"where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _


            '//New October 5, 2006
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
            '        "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "inner join tnav_item on lpsprice.psprice_number = tnav_item.No_ " & _
            '        "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
            '        "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and tworkorder.group_id in (2,5,9,12) " & _
            '        "group by lpsprice.psprice_number"
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                     "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                     "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                     "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                     "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
                    newVDate & " and tparttransaction.prod_id=2 " & _
                     "and lpsprice.psprice_inventorypart = 1 " & _
                    "and new in (1,2) " & _
                     "and tworkorder.group_id in (2,5,9,12) " & _
                     "group by lpsprice.psprice_number"


            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFCELL", strFileDate, "560", "Negative")

            System.Windows.Forms.Application.DoEvents()
            '//***********************************************************************************
            '//***********************************************************************************
            '//***********************************************************************************
            '//***********************************************************************************
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
            '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '         "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '         "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '         "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '         "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '         "inner join tnav_item on lpsprice.psprice_number = tnav_item.No_ " & _
            '         "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
            '         "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
            '         "and lpsprice.psprice_inventorypart = 1 " & _
            '         "and tworkorder.group_id in (3,10,11,13) " & _
            '         "group by lpsprice.psprice_number"


            '//This is commented out October 19, 2007
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
            '                        "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '                        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '                        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '                        "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
            '                        newVDate & " and tparttransaction.prod_id=2 " & _
            '                        "and lpsprice.psprice_inventorypart = 1 " & _
            '                        "and new in (1,2) " & _
            '                        "and tworkorder.group_id in (3,10,11,13) " & _
            '                        "group by lpsprice.psprice_number"


            'Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFCELL2", strFileDate, "560", "Negative")
            '//This is commented out October 19, 2007

            System.Windows.Forms.Application.DoEvents()


            '//New October 5, 2006



            '//Section 1 and 2 consumed and reclaimed - by defined/active bench
            '//This will now iterate for every bin that has been assigned as active
            Dim dsLocs As PSS.Data.Production.Joins
            strSQL = "SELECT * FROM lwclocation WHERE wc_location <> 'SFCELL' and mid(wc_location,1,3) = 'SFC' and wc_ActiveConsume = 1"
            Dim dtLocs As DataTable = dsLocs.OrderEntrySelect(strSQL)
            Dim rLocs As DataRow
            Dim LocCount As Integer = 0

            For LocCount = 0 To dtLocs.Rows.Count - 1
                rLocs = dtLocs.Rows(LocCount)
                'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, lwclocation.wc_location as BIN  from " & _
                '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                '        "inner join tnav_item on lpsprice.psprice_number = tnav_item.No_ " & _
                '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                '        "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
                '        "and lpsprice.psprice_inventorypart = 1 " & _
                '        "and (tparttransaction.machinename = '" & rLocs("WC_Machine") & "' AND tnav_item.Shelf_No_ = 'BENCH') " & _
                '        "group by lpsprice.psprice_number"



                '//This is commented out October 19, 2007

                'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, lwclocation.wc_location as BIN  from " & _
                '                                                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                '                                                        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                '                                                        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                '                                                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                '                                                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                '                                                        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                '                                                        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                '                                                        newVDate & " and tparttransaction.prod_id=2 " & _
                '                                                        "and lpsprice.psprice_inventorypart = 1 " & _
                '                                                        "and new in (1,2) " & _
                '                                                        "and (tparttransaction.machinename = '" & rLocs("WC_Machine") & "' AND tnav_item.Shelf_No_ = 'BENCH') " & _
                '                                                        "group by lpsprice.psprice_number"

                'System.Windows.Forms.Application.DoEvents()
                'Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, rLocs("WC_Location"), strFileDate, "560", "Negative")
                '//This is commented out October 19, 2007

                System.Windows.Forms.Application.DoEvents()
            Next

            '//Section 3 consumed - SFML01
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
            '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '        newVDate & " and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and (lwclocation.wc_altloc = 'SFML01' or lwclocation.wc_altloc is null) " & _
            '        "group by lpsprice.psprice_number"
            '//This new code was put in August 23, 2007
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    newVDate & " and tparttransaction.prod_id= 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and new in (1,2) " & _
                    "and (lwclocation.wc_altloc = 'SFML01' or lwclocation.wc_altloc is null) " & _
                    "and tparttransaction.trans_amount = 1 " & _
                    "group by lpsprice.psprice_number"


            '//October 2, 2007
            'The trans_amount = 1 is new SocketAddress that the file has the gross number consumption.
            '//October 2, 2007



            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFML01", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 4 consumed - SFML03
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
            '        "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '        newVDate & " and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and (lwclocation.wc_altloc = 'SFML03')" & _
            '        "group by lpsprice.psprice_number"
            '//This new code was put in August 23, 2007
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                    "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    newVDate & " and tparttransaction.prod_id= 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and new in (1,2) " & _
                    "and (lwclocation.wc_altloc = 'SFML03')" & _
                    "group by lpsprice.psprice_number"

            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFML03", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 5 SFBILLING
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                    "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    newVDate & " and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and new in (1,2) " & _
                    "and (lwclocation.wc_altloc = 'SFBILLING')" & _
                    "group by lpsprice.psprice_number"

            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFBILLING", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()


            s.Close()
            sAdj.Close()
            sWip.Close()
            sWipREPORT.Close()
            'sNegative.Close()
            Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("File Creation Is Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        End Sub



        Private Sub Write2FileNEW(ByVal vSQL As String, ByRef vs As StreamWriter, ByRef vsAdj As StreamWriter, ByRef vsWIP As StreamWriter, ByRef vsWIPREPORT As StreamWriter, ByVal vBin As DataTable, ByVal strBin As String, ByVal vstrFileDate As String, ByVal vstrDepartment As String, ByVal vType As String)

            Dim ds As PSS.Data.Production.Joins
            Dim xCount, validCount As Integer
            Dim r, rBin As DataRow
            Dim blnValid, step1 As Boolean
            Dim strInvalidReason, strData As String

            Dim intQty, intQtyPart As Long
            Dim mType, mTypeALT As String

            Dim isNegative As Boolean

            Dim dtPageConsume As DataTable = ds.OrderEntrySelect(vSQL)

            Dim strLocation As String = strBin
            Dim strLocationALT As String = "WIP"

            For xCount = 0 To dtPageConsume.Rows.Count - 1
                r = dtPageConsume.Rows(xCount)

                isNegative = False

                If CInt(r("count")) < 0 Then
                    intQty = r("count") * -1
                    mType = "Positive"
                    mTypeALT = "Negative"
                    strLocation = "WIP"
                    strLocationALT = strBin
                    isNegative = True
                Else
                    intQty = CInt(r("count"))
                    mType = "Negative"
                    mTypeALT = "Positive"
                    strLocation = strBin
                    strLocationALT = "WIP"
                    isNegative = False
                End If

                intQtyPart = 0

                blnValid = False
                For validCount = 0 To vBin.Rows.Count - 1
                    rBin = vBin.Rows(validCount)
                    If Trim(rBin("BinLocation").ToString) = strLocation Then
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            step1 = True
                            If CInt(r("count")) <= CInt(rBin("qty")) Then
                                blnValid = True
                                Exit For
                            Else
                                intQty = CInt(rBin("qty"))
                                If intQty > 0 Then
                                    blnValid = True
                                    strInvalidReason = "Part Count Exceeds Quantity Available"""
                                    intQtyPart = CInt(r("count")) - CInt(rBin("qty"))

                                    strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                                    vsAdj.WriteLine(strData)
                                    System.Windows.Forms.Application.DoEvents()

                                    'strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                                    'vsAdj.WriteLine(strData)

                                    'If intQty > 0 Then '//This is new to prevent the zero values from being displayed in the source file
                                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate
                                    'vs.WriteLine(strData)
                                    'End If

                                '//write data to WIP adjustment file
                                strData = strLocationALT & vbTab & r("number") & vbTab & intQtyPart & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & "5004"
                                vsWIP.WriteLine(strData)

                                strData = strLocationALT & vbTab & r("number") & vbTab & intQtyPart & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & "5004" & vbTab & "Transfer from bin: " & rBin("qty") & vbTab & "TOTAL NEEDED: " & r("count")
                                vsWIPREPORT.WriteLine(strData)

                                '//write data to WIP adjustment file
                                Exit For
                                Else
                                intQty = CInt(r("count"))
                                '//write data to WIP adjustment file
                                System.Windows.Forms.Application.DoEvents()
                                strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & "5004"
                                vsWIP.WriteLine(strData)
                                '//write data to WIP adjustment file
                                strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & "5004" & vbTab & "Transfer from bin: " & rBin("qty") & vbTab & "TOTAL NEEDED: " & r("count")
                                vsWIPREPORT.WriteLine(strData)
                                End If
                                End If
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = "Part Count Exceeds Quantity Available"""
                    End If
                Next

                If blnValid = True Then
                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment
                    'vs.WriteLine(strData)
                    System.Windows.Forms.Application.DoEvents()
                    'strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment
                    If intQty > 0 Then '//This is new to prevent the zero values from being displayed in the source file
                        strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate
                        'strData = strLocation & vbTab & r("number") & vbTab & r("Count") & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate
                        If isNegative = False Then
                            vs.WriteLine(strData)
                        Else
                            'vsNegative.WriteLine(strData)
                            vsWIPREPORT.WriteLine(strData)
                        End If
                    End If
                Else
                    'strData = strLocation & vbTab & r("number") & vbTab & r("count") & vbTab & vType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    'If intQtyPart = 0 Then
                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    If step1 = False Then
                        '//This is No Part to Bin Relationship
                        '//Write only to adjustment file
                        If intQty > 0 Then
                            strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                            vsAdj.WriteLine(strData)
                            System.Windows.Forms.Application.DoEvents()
                        End If
                    End If
                    'strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                    'vsAdj.WriteLine(strData)
                    'End If
                    intQtyPart = 0
                    End If

                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

        End Sub



        Private Sub btnNewProcessInvoiced_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewProcessInvoiced.Click


            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
            Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"""


            '//This is temporary
            'Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"" WHERE ""Bin Code"" = 'SFC11'"

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(dtBin)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '//
            'Dim x As Integer
            'Dim xr As DataRow
            'For x = 0 To dtBin.Rows.Count - 1
            'xr = dtBin.Rows(x)
            'MsgBox(xr("BinLocation") & "  " & xr("Part") & "  " & xr("qty"))
            'Next
            '//
            'Exit Sub

            nda.Dispose()
            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - END

            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow
            Dim xCount, validCount As Integer
            Dim strDate, strDate2, strFileDate, vDateEnd As String
            Dim strFile, strFileAdj, strFileWIP, strFileWIPREPORT As String
            Dim vDate, vDate_2 As String

            Dim vDate1 As Date
            Dim vDate2 As Date
            Dim blnValid As Boolean

            Dim strInvalidReason As String
            Dim step1, step2 As Boolean
            step1 = False
            step2 = False

            Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                vDate1 = InputBox("Enter date to process", "Enter Date", Format(Now, "M/d/yy"))
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Catch ex As Exception
                MsgBox("The date you entered is invalid. The process will now end. Please try again.", MsgBoxStyle.OKOnly, "ERROR")
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End Try

            vDate = Format(vDate1, "M/d/yy")

            Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                vDate2 = InputBox("Enter date to process", "Enter Date", Format(Now, "M/d/yy"))
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Catch ex As Exception
                MsgBox("The date you entered is invalid. The process will now end. Please try again.", MsgBoxStyle.OKOnly, "ERROR")
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End Try

            vDate_2 = Format(vDate2, "M/d/yy")

            strFileDate = vDate
            strDate = Gui.Receiving.FormatDateShort(vDate)
            strDate2 = Gui.Receiving.FormatDateShort(vDate_2)
            vDate = Gui.Receiving.FormatDateShort(vDate) & " 00:00:00"
            vDateEnd = Gui.Receiving.FormatDateShort(vDate_2) & " 23:59:59"
            strFile = "NP_INVOICED" & strDate & "_to_" & strDate2 & "xferDATA.txt"
            strFileAdj = "NP_INVOICED" & strDate & "_to_" & strDate2 & "xferADJ.txt"
            strFileWIP = "NP_INVOICED" & strDate & "_to_" & strDate2 & "adjWIP.txt"
            strFileWIPREPORT = "NP_INVOICED" & strDate & "_to_" & strDate2 & "WIPREPORT.txt"

            Dim xFileCheck As Integer = checkFile(strFile)
            If xFileCheck = 1 Then
                MsgBox("Please remove file before running.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim fs As New FileStream("R:\InventoryData\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsAdj As New FileStream("R:\InventoryData\" & strFileAdj, FileMode.Create, FileAccess.Write)
            Dim sAdj As New StreamWriter(fsAdj)
            sAdj.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsWip As New FileStream("R:\InventoryData\" & strFileWIP, FileMode.Create, FileAccess.Write)
            Dim sWip As New StreamWriter(fsWip)
            sWip.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsWipREPORT As New FileStream("R:\InventoryData\" & strFileWIPREPORT, FileMode.Create, FileAccess.Write)
            Dim sWipREPORT As New StreamWriter(fsWipREPORT)
            sWipREPORT.BaseStream.Seek(0, SeekOrigin.End)

            Dim strData As String

            '//This line is used to not select Asset Recovery Customers
            '"and tcustomer.biztype_id = 0 " & _
            '//This line is used to not select Asset Recovery Customers

            '//Section 1 reclaimed - SFCELL
            Dim strSQL As String

            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
            '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '        "where tdevice.device_dateship > '" & vDate & "' and tdevice.device_dateship < '" & vDateEnd & "' and tparttransaction.prod_id=2 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and tdevice.device_Invoice = 1 " & _
            '        "group by lpsprice.psprice_number"

            'Write2FileINVOICED_NEW(strSQL, s, sAdj, sWip, dtBin, "SFCELL", strFileDate, "560", "Negative")
            'System.Windows.Forms.Application.DoEvents()



            '//Section 1 and 2 consumed and reclaimed - SFCELL
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tdevice.device_dateship > '" & vDate & "' and tdevice.device_dateship < '" & vDateEnd & "' and tparttransaction.prod_id=2 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFCELL') " & _
                    "and tparttransaction.machinename <> 'CELLTECH2' " & _
                    "and tdevice.device_Invoice = 1 " & _
                    "group by lpsprice.psprice_number"

            Write2FileINVOICED_NEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFCELL", strFileDate, "560", "Negative")
            System.Windows.Forms.Application.DoEvents()


            '//Section 1 and 2 consumed and reclaimed - celltech2
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, lwclocation.wc_location as BIN  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tdevice.device_dateship > '" & vDate & "' and tdevice.device_dateship < '" & vDateEnd & "' and tparttransaction.prod_id=2 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (tparttransaction.machinename = 'CELLTECH2') " & _
                    "and tdevice.device_Invoice = 1 " & _
                    "group by lpsprice.psprice_number"


            'Dim tmpds As PSS.Data.Production.Joins
            'Dim dt As DataTable = tmpds.OrderEntrySelect("SELECT WC_Location from lwclocation where wc_machine = 'CELLTECH2'")
            'Dim tmpr As DataRow = dt.Rows(0)

            Write2FileINVOICED_NEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "WIP", strFileDate, "560", "Negative")
            System.Windows.Forms.Application.DoEvents()



            '//Section 3 consumed - SFML01
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tdevice.device_dateship > '" & vDate & "' and tdevice.device_dateship < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and tdevice.device_Invoice = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML01') " & _
                    "group by lpsprice.psprice_number"

            Write2FileINVOICED_NEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFML01", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 4 consumed - SFML03
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                    "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tdevice.device_dateship > '" & vDate & "' and tdevice.device_dateship < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML03')" & _
                    "and tdevice.device_Invoice = 1 " & _
                    "group by lpsprice.psprice_number"

            Write2FileINVOICED_NEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFML03", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            s.Close()
            sAdj.Close()
            sWip.Close()
            sWipREPORT.Close()
            Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("File Creation for Invoiced Files Is Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        End Sub

        Private Sub Write2FileINVOICED_NEW(ByVal vSQL As String, ByRef vs As StreamWriter, ByRef vsAdj As StreamWriter, ByRef vsWIP As StreamWriter, ByRef vsWIPREPORT As StreamWriter, ByVal vBin As DataTable, ByVal strBin As String, ByVal vstrFileDate As String, ByVal vstrDepartment As String, ByVal vType As String)

            Dim ds As PSS.Data.Production.Joins
            Dim xCount, validCount As Integer
            Dim r, rBin As DataRow
            Dim blnValid, step1 As Boolean
            Dim strInvalidReason, strData As String

            Dim intQty, intQtyPart As Long
            Dim mType, mTypeALT As String


            Dim dtPageConsume As DataTable = ds.OrderEntrySelect(vSQL)

            'Dim strLocation As String = strBin
            'Dim strLocationALT As String = "WIP"
            Dim strLocationALT As String = strBin
            Dim strLocation As String = "WIP"

            For xCount = 0 To dtPageConsume.Rows.Count - 1
                r = dtPageConsume.Rows(xCount)

                If CInt(r("count")) < 0 Then
                    intQty = r("count") * -1
                    mType = "Negative"
                    mTypeALT = "Positive"
                    'mType = "Positive"
                    'mTypeALT = "Negative"
                Else
                    intQty = CInt(r("count"))
                    mType = "Positive"
                    mTypeALT = "Negative"
                    'mType = "Negative"
                    'mTypeALT = "Positive"
                End If

                intQtyPart = 0

                blnValid = False
                For validCount = 0 To vBin.Rows.Count - 1
                    rBin = vBin.Rows(validCount)
                    If Trim(rBin("BinLocation").ToString) = strLocation Then
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            step1 = True
                            If CInt(r("count")) <= CInt(rBin("qty")) Then
                                blnValid = True
                                Exit For
                            Else
                                intQty = CInt(rBin("qty"))
                                If intQty > 0 Then
                                    blnValid = True
                                    strInvalidReason = "Part Count Exceeds Quantity Available"""
                                    intQtyPart = CInt(r("count")) - CInt(rBin("qty"))

                                    strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & strLocationALT & vbTab & "Adjust From WIP" & vbTab & vstrFileDate & vbTab & strInvalidReason
                                    vsAdj.WriteLine(strData)
                                    System.Windows.Forms.Application.DoEvents()

                                    'strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                                    'vsAdj.WriteLine(strData)

                                    'If intQty > 0 Then '//This is new to prevent the zero values from being displayed in the source file
                                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate
                                    'vs.WriteLine(strData)
                                    'End If

                                    '//write data to WIP adjustment file
                                    strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & "5004"
                                    vsWIP.WriteLine(strData)
                                    strData = strLocationALT & vbTab & r("number") & vbTab & intQtyPart & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & "5004" & vbTab & "Transfer from bin: " & rBin("qty") & vbTab & "TOTAL NEEDED: " & r("count")
                                    vsWIPREPORT.WriteLine(strData)
                                    '//write data to WIP adjustment file
                                    Exit For
                                Else
                                    intQty = CInt(r("count"))
                                    '//write data to WIP adjustment file
                                    System.Windows.Forms.Application.DoEvents()
                                    strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & "5004"
                                    vsWIP.WriteLine(strData)
                                    strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & "5004" & vbTab & "Transfer from bin: " & rBin("qty") & vbTab & "TOTAL NEEDED: " & r("count")
                                    vsWIPREPORT.WriteLine(strData)
                                    '//write data to WIP adjustment file
                                End If
                            End If
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = "Part Count Exceeds Quantity Available"""
                    End If
                Next

                If blnValid = True Then
                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment
                    'vs.WriteLine(strData)
                    System.Windows.Forms.Application.DoEvents()
                    'strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment
                    If intQty > 0 Then '//This is new to prevent the zero values from being displayed in the source file
                        'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate
                        strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment
                        vs.WriteLine(strData)
                    End If
                Else
                    'strData = strLocation & vbTab & r("number") & vbTab & r("count") & vbTab & vType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    'If intQtyPart = 0 Then
                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    If step1 = False Then
                        '//This is No Part to Bin Relationship
                        '//Write only to adjustment file
                        strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Adjust From WIP" & vbTab & vstrFileDate & vbTab & strInvalidReason
                        vsAdj.WriteLine(strData)
                        System.Windows.Forms.Application.DoEvents()
                    End If
                    'strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                    'vsAdj.WriteLine(strData)
                    'End If
                    intQtyPart = 0
                End If

                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

        End Sub

        Private Sub Write2FileINVOICED_DNU(ByVal vSQL As String, ByRef vs As StreamWriter, ByRef vsAdj As StreamWriter, ByVal vBin As DataTable, ByVal strBin As String, ByVal vstrFileDate As String, ByVal vstrDepartment As String, ByVal vType As String)

            Dim ds As PSS.Data.Production.Joins
            Dim xCount, validCount As Integer
            Dim r, rBin As DataRow
            Dim blnValid, step1 As Boolean
            Dim strInvalidReason, strData As String

            Dim intQty, intQtyPart As Long
            Dim mType, mTypeALT As String


            Dim dtPageConsume As DataTable = ds.OrderEntrySelect(vSQL)

            Dim strLocation As String = strBin
            Dim strLocationALT As String = "WIP"

            For xCount = 0 To dtPageConsume.Rows.Count - 1
                r = dtPageConsume.Rows(xCount)

                If CInt(r("count")) < 0 Then
                    intQty = r("count") * -1
                    mType = "Positive"
                    mTypeALT = "Negative"
                Else
                    intQty = CInt(r("count"))
                    mType = "Negative"
                    mTypeALT = "Positive"
                End If

                intQtyPart = 0

                blnValid = False
                For validCount = 0 To vBin.Rows.Count - 1
                    rBin = vBin.Rows(validCount)
                    If Trim(rBin("BinLocation").ToString) = strLocation Then
                        If UCase(Trim(rBin("Part").ToString)) = UCase(Trim(r("number").ToString)) Then
                            step1 = True
                            If CInt(r("count")) <= CInt(rBin("qty")) Then
                                blnValid = True
                                Exit For
                            Else
                                intQty = CInt(rBin("qty"))
                                If intQty > 0 Then
                                    blnValid = True
                                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment
                                    'vs.WriteLine(strData)
                                    strInvalidReason = "Part Count Exceeds Quantity Available"""
                                    intQtyPart = CInt(r("count")) - CInt(rBin("qty"))
                                    'strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                                    strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                                    vsAdj.WriteLine(strData)
                                    System.Windows.Forms.Application.DoEvents()
                                    'strData = strLocationALT & vbTab & r("number") & vbTab & intQtyPart & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                                    strData = strLocation & vbTab & r("number") & vbTab & intQtyPart & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                                    vsAdj.WriteLine(strData)
                                    Exit For
                                Else
                                    intQty = CInt(r("count"))
                                End If
                            End If
                        End If
                    End If
                    If step1 = False Then
                        strInvalidReason = "No Part to Bin Relationship"
                    Else
                        strInvalidReason = "Part Count Exceeds Quantity Available"""
                    End If
                Next

                If blnValid = True Then
                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment
                    'vs.WriteLine(strData)
                    System.Windows.Forms.Application.DoEvents()
                    'strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment
                    If intQty > 0 Then '//This is new to prevent the zero values from being displayed in the source file
                        strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate
                        vs.WriteLine(strData)
                    End If
                Else
                    'strData = strLocation & vbTab & r("number") & vbTab & r("count") & vbTab & vType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    'If intQtyPart = 0 Then
                    'strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & mType & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                    vsAdj.WriteLine(strData)
                    System.Windows.Forms.Application.DoEvents()
                    'strData = strLocationALT & vbTab & r("number") & vbTab & intQty & vbTab & mTypeALT & vbTab & vstrFileDate & vbTab & vstrDepartment & vbTab & strInvalidReason
                    strData = strLocation & vbTab & r("number") & vbTab & intQty & vbTab & strLocationALT & vbTab & "Transfer" & vbTab & vstrFileDate & vbTab & strInvalidReason
                    vsAdj.WriteLine(strData)
                    'End If
                    intQtyPart = 0
                End If

                strData = ""
                step1 = False
                strInvalidReason = ""
            Next

        End Sub



        Private Sub old_consume()

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
            Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"""


            '//This is temporary
            'Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"" WHERE ""Bin Code"" = 'SFC11'"

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(dtBin)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '//
            'Dim x As Integer
            'Dim xr As DataRow
            'For x = 0 To dtBin.Rows.Count - 1
            'xr = dtBin.Rows(x)
            'MsgBox(xr("BinLocation") & "  " & xr("Part") & "  " & xr("qty"))
            'Next
            '//
            'Exit Sub

            nda.Dispose()
            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - END

            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow
            Dim xCount, validCount As Integer
            Dim strDate, strFileDate, vDateEnd As String
            Dim strFile, strFileAdj, strFileWIP, strFileWIPREPORT, strFileNegative As String
            Dim vDate As String

            Dim vDate1 As Date
            Dim blnValid As Boolean

            Dim strInvalidReason As String
            Dim step1, step2 As Boolean
            step1 = False
            step2 = False

            Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                vDate1 = InputBox("Enter date to process", "Enter Date", Format(Now, "M/d/yy"))
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Catch ex As Exception
                MsgBox("The date you entered is invalid. The process will now end. Please try again.", MsgBoxStyle.OKOnly, "ERROR")
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End Try

            vDate = Format(vDate1, "M/d/yy")

            strFileDate = vDate
            strDate = Gui.Receiving.FormatDateShort(vDate)
            vDate = Gui.Receiving.FormatDateShort(vDate)
            vDateEnd = Gui.Receiving.FormatDateShort(vDate)

            strFile = strDate & "DATA_TRANSFER_PROCESS(process).txt"
            strFileAdj = strDate & "DATA_ADJUSTMENT_DOCUMENT(report).txt"
            strFileWIP = strDate & "WIP_ADJUSTMENT_PROCESS(process).txt"
            strFileWIPREPORT = strDate & "WIP_ADJUSTMENT_DOCUMENT(report).txt"
            'strFileNegative = "zzzNP" & strDate & "xferNegativeDATA.txt"

            Dim xFileCheck As Integer = checkFile(strFile)
            If xFileCheck = 1 Then
                MsgBox("Please remove file before running.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim fs As New FileStream("R:\InventoryData\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsAdj As New FileStream("R:\InventoryData\" & strFileAdj, FileMode.Create, FileAccess.Write)
            Dim sAdj As New StreamWriter(fsAdj)
            sAdj.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsWIP As New FileStream("R:\InventoryData\" & strFileWIP, FileMode.Create, FileAccess.Write)
            Dim sWip As New StreamWriter(fsWIP)
            sWip.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsWIPREPORT As New FileStream("R:\InventoryData\" & strFileWIPREPORT, FileMode.Create, FileAccess.Write)
            Dim sWipREPORT As New StreamWriter(fsWIPREPORT)
            sWipREPORT.BaseStream.Seek(0, SeekOrigin.End)

            'Dim fsNegative As New FileStream("R:\InventoryData\" & strFileNegative, FileMode.Create, FileAccess.Write)
            'Dim sNegative As New StreamWriter(fsNegative)
            'sNegative.BaseStream.Seek(0, SeekOrigin.End)

            Dim strData As String

            '//This line is used to not select Asset Recovery Customers
            '"and tcustomer.biztype_id = 0 " & _
            '//This line is used to not select Asset Recovery Customers

            '//Section 1 reclaimed - SFCELL
            Dim strSQL As String

            '//Section 1 and 2 consumed and reclaimed - SFCELL
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
            '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '        "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and (lwclocation.wc_altloc = 'SFCELL' or lwclocation.wc_altloc is null) " & _
            '        "and tparttransaction.machinename <> 'CELLTECH2' " & _
            '        "group by lpsprice.psprice_number"
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "inner join tnav_item on lpsprice.psprice_number = tnav_item.No_ " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and ((lwclocation.wc_altloc = 'SFCELL' or lwclocation.wc_altloc is null) " & _
                    "or (tparttransaction.machinename = 'CELLTECH23' and tnav_item.Shelf_No_ <> 'BENCH' ))" & _
                    "group by lpsprice.psprice_number"

            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFCELL", strFileDate, "560", "Negative")

            System.Windows.Forms.Application.DoEvents()


            '//Section 1 and 2 consumed and reclaimed - celltech2
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, lwclocation.wc_location as BIN  from " & _
            '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '        "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=2 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and (tparttransaction.machinename = 'CELLTECH2') " & _
            '        "group by lpsprice.psprice_number"
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, lwclocation.wc_location as BIN  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "inner join tnav_item on lpsprice.psprice_number = tnav_item.No_ " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (tparttransaction.machinename = 'CELLTECH23') AND tnav_item.Shelf_No_ = 'BENCH'" & _
                    "group by lpsprice.psprice_number"


            Dim tmpds As PSS.Data.Production.Joins
            Dim dt As DataTable = tmpds.OrderEntrySelect("SELECT WC_Location from lwclocation where wc_machine = 'CELLTECH23'")
            Dim tmpr As DataRow = dt.Rows(0)
            'MsgBox(tmpr("WC_Location"))

            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, tmpr("WC_Location"), strFileDate, "560", "Negative")
            System.Windows.Forms.Application.DoEvents()


            '//Section 3 consumed - SFML01
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
            '         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '        "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and (lwclocation.wc_altloc = 'SFML01' or lwclocation.wc_altloc is null) " & _
            '        "group by lpsprice.psprice_number"
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML01' or lwclocation.wc_altloc is null) " & _
                    "group by lpsprice.psprice_number"

            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFML01", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 4 consumed - SFML03
            'strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
            '        "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            '        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            '        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            '        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            '        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            '        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
            '        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
            '        "where date_rec > '" & vDate & "' and date_rec < '" & vDateEnd & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
            '        "and lpsprice.psprice_inventorypart = 1 " & _
            '        "and (lwclocation.wc_altloc = 'SFML03')" & _
            '        "group by lpsprice.psprice_number"
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                    "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML03')" & _
                    "group by lpsprice.psprice_number"

            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFML03", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            s.Close()
            sAdj.Close()
            sWip.Close()
            sWipREPORT.Close()
            'sNegative.Close()
            Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("File Creation Is Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        End Sub


        Private Sub btnDevelopment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDevelopment.Click

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            Dim odbcStr As String = "SELECT * FROM ""Bin Content"""

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(dtBin)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            Dim ds As PSS.Data.Production.Joins
            Dim strSQL As String
            Dim rSource As DataRow
            Dim x As Integer
            Dim blnUpdate As Boolean

            For x = 0 To dtBin.Rows.Count - 1
                rSource = dtBin.Rows(x)

                strSQL = "INSERT INTO cogs.bin_content " & Environment.NewLine
                strSQL &= "(Location Code, Zone Code, Bin Code, Item No_, Bin Type Code, " & Environment.NewLine
                strSQL &= "Warehouse Class Code, Block Movement, Min_ Qty_, Max_ Qty_, Bin Ranking, " & Environment.NewLine
                strSQL &= "Quantity, Pick Qty_, Neg_ Adjmt_ Qty_, Put-away Qty_, Pos_ Adjmt_ Qty_, " & Environment.NewLine
                strSQL &= "Fixed, Cross-Dock Bin, Default, Variant Code, Qty_ per Unit of Measure, " & Environment.NewLine
                strSQL &= "Unit of Measure Code, Lot No_ Filter, Serial No_ Filter) " & Environment.NewLine
                strSQL &= "VALUES " & Environment.NewLine
                strSQL &= "('" & rSource("Location Code") & "', '" & rSource("Zone Code") & "', '" & rSource("Bin Code") & "', '" & rSource("Item No_") & "', '" & rSource("Bin Type Code") & "', '" & Environment.NewLine
                strSQL &= rSource("Warehouse Class Code") & "', '" & rSource("Block Movement") & "', " & rSource("Min_ Qty_") & ", " & rSource("Max_ Qty_") & ", " & rSource("Bin Ranking") & ", " & Environment.NewLine
                strSQL &= rSource("Quantity") & ", " & rSource("Pick Qty_") & ", " & rSource("Neg_ Adjmt_ Qty_") & ", " & rSource("Put-away Qty_") & ", " & rSource("Pos_ Adjmt_ Qty_") & ", " & Environment.NewLine
                strSQL &= rSource("Fixed") & ", " & rSource("Cross-Dock Bin") & ", " & rSource("Default") & ", '" & rSource("Variant Code") & "', " & rSource("Qty_ per Unit of Measure") & ", '" & Environment.NewLine
                strSQL &= rSource("Unit of Measure Code") & "', '" & rSource("Lot No_ Filter") & "', '" & rSource("Serial No_ Filter") & "') " & Environment.NewLine

                blnUpdate = ds.OrderEntryUpdateDelete(strSQL)
            Next

        End Sub

        Private Sub btnUsage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUsage.Click

            Dim ds As PSS.Data.Production.Joins
            Dim strSQL As String
            Dim dt As DataTable
            Dim r As DataRow
            Dim x As Integer
            Dim z As Integer
            Dim blnInsert As Boolean
            Dim strWorkdate As String
            Dim dSTART, dEND As Date

            dSTART = "1/28/2007"
            dEND = "1/29/2007"

            For z = 1 To 95
                strSQL = "select tcustomer.cust_name1 as customer, lpsprice.psprice_number as part, tmodel.model_desc as model, sum(trans_amount) as devUsage, tdevice.device_dateship as workdate from " & _
                "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                "inner join lbillcodes on tparttransaction.billcode_id = lbillcodes.billcode_id " & _
                "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
                "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                "inner join tcellopt on tdevice.device_id = tcellopt.device_id " & _
                "where device_dateship >= '" & Format(dSTART, "yyyy-MM-dd") & " 06:00:00'  " & _
                "and device_dateship <= '" & Format(dEND, "yyyy-MM-dd") & " 04:00:00' " & _
                "and tcellopt.SC_ID = 0 " & _
                "group by tcustomer.cust_id, tdevice.model_id, lpsprice.psprice_number " & _
                "order by tcustomer.cust_name1, tdevice.device_dateship, lpsprice.psprice_number, tmodel.model_desc "
                dt = ds.OrderEntrySelect(strSQL)

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("devusage") > 0 Then
                        strWorkdate = Format(CDate(dSTART), "yyyy-MM-dd")
                        strSQL = "INSERT INTO cogs.tconsumed_counts " & _
                        "(customer, part_number, model_name, consumed_count, workdate) " & _
                        "VALUES " & _
                        "('" & r("customer") & "', '" & r("part") & "', '" & r("model") & "', " & r("devusage") & ", '" & strWorkdate & "')"
                        blnInsert = ds.OrderEntryUpdateDelete(strSQL)
                    End If
                Next

                dSTART = DateAdd(DateInterval.Day, -1, dSTART)
                dEND = DateAdd(DateInterval.Day, -1, dEND)
            Next

            MsgBox("LOAD COMPLETE")
            dt = Nothing

        End Sub

        Private Sub btnDeviceCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeviceCount.Click

            Dim ds As PSS.Data.Production.Joins
            Dim strSQL As String
            Dim dt As DataTable
            Dim r As DataRow
            Dim x As Integer
            Dim z As Integer
            Dim blnInsert As Boolean
            Dim strWorkdate As String
            Dim dSTART, dEND As Date

            dSTART = "1/28/2007"

            For z = 1 To 95
                strSQL = "select tcustomer.cust_name1 as customer, tmodel.model_desc as modeldesc,count(tdevice.model_id) as modelcount from tdevice " & _
                "inner join tmodel on tdevice.model_id = tmodel.model_id " & _
                "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                "where device_dateship >= '" & Format(dSTART, "yyyy-MM-dd") & " 06:00:00' " & _
                "and device_dateship <= '" & Format(DateAdd(DateInterval.Day, 1, dSTART), "yyyy-MM-dd") & " 04:00:00' " & _
                "group by tcustomer.cust_id, tdevice.model_id " & _
                "order by tcustomer.cust_name1, tmodel.model_desc "
                dt = ds.OrderEntrySelect(strSQL)

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("modelcount") > 0 Then
                        strWorkdate = Format(CDate(dSTART), "yyyy-MM-dd")
                        strSQL = "INSERT INTO cogs.tmodel_counts " & _
                        "(customer, model_name, model_count, workdate) " & _
                        "VALUES " & _
                        "('" & r("customer") & "', '" & r("modeldesc") & "', '" & r("modelcount") & "', '" & strWorkdate & "')"
                        blnInsert = ds.OrderEntryUpdateDelete(strSQL)
                    End If
                Next

                dSTART = DateAdd(DateInterval.Day, -1, dSTART)
            Next

            MsgBox("LOAD COMPLETE")
            dt = Nothing

        End Sub

        Private Sub btnGetData_07132007_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData_07132007.Click


            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - START
            Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"""


            '//This is temporary
            'Dim odbcStr As String = "SELECT ""Item No_"" as Part, ""Bin Code"" as BinLocation, Quantity as qty FROM ""Bin Content"" WHERE ""Bin Code"" = 'SFC11'"

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()

            Try
                nda.Fill(dtBin)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            '//
            'Dim x As Integer
            'Dim xr As DataRow
            'For x = 0 To dtBin.Rows.Count - 1
            'xr = dtBin.Rows(x)
            'MsgBox(xr("BinLocation") & "  " & xr("Part") & "  " & xr("qty"))
            'Next
            '//
            'Exit Sub

            nda.Dispose()
            '//MAKE NEW DATATABLE TO TIE DIRECTLY TO NAVISION DATABASE - END

            Dim ds As PSS.Data.Production.Joins
            Dim r As DataRow
            Dim xCount, validCount As Integer
            Dim strDate, strFileDate, vDateEnd As String
            Dim strFile, strFileAdj, strFileWIP, strFileWIPREPORT, strFileNegative As String
            Dim vDate As String

            Dim vDate1 As Date
            Dim blnValid As Boolean

            Dim strInvalidReason As String
            Dim step1, step2 As Boolean
            step1 = False
            step2 = False

            Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                vDate1 = InputBox("Enter date to process", "Enter Date", Format(Now, "M/d/yy"))
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Catch ex As Exception
                MsgBox("The date you entered is invalid. The process will now end. Please try again.", MsgBoxStyle.OKOnly, "ERROR")
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Exit Sub
            End Try

            vDate = Format(vDate1, "M/d/yy")

            strFileDate = vDate
            strDate = Gui.Receiving.FormatDateShort(vDate)
            vDate = Gui.Receiving.FormatDateShort(vDate)
            vDateEnd = Gui.Receiving.FormatDateShort(vDate)

            strFile = strDate & "DATA_TRANSFER_PROCESS(process).txt"
            strFileAdj = strDate & "DATA_ADJUSTMENT_DOCUMENT(report).txt"
            strFileWIP = strDate & "WIP_ADJUSTMENT_PROCESS(process).txt"
            strFileWIPREPORT = strDate & "WIP_ADJUSTMENT_DOCUMENT(report).txt"

            Dim xFileCheck As Integer = checkFile(strFile)
            If xFileCheck = 1 Then
                MsgBox("Please remove file before running.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            Dim fs As New FileStream("R:\InventoryData\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsAdj As New FileStream("R:\InventoryData\" & strFileAdj, FileMode.Create, FileAccess.Write)
            Dim sAdj As New StreamWriter(fsAdj)
            sAdj.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsWIP As New FileStream("R:\InventoryData\" & strFileWIP, FileMode.Create, FileAccess.Write)
            Dim sWip As New StreamWriter(fsWIP)
            sWip.BaseStream.Seek(0, SeekOrigin.End)

            Dim fsWIPREPORT As New FileStream("R:\InventoryData\" & strFileWIPREPORT, FileMode.Create, FileAccess.Write)
            Dim sWipREPORT As New StreamWriter(fsWIPREPORT)
            sWipREPORT.BaseStream.Seek(0, SeekOrigin.End)

            Dim strData As String

            '//SFCELL
            Dim strSQL As String
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                     "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                     "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                     "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                     "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                     "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
                     "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
                     "and lpsprice.psprice_inventorypart = 1 " & _
                     "and tworkorder.group_id in (2,5,9,12) " & _
                     "group by lpsprice.psprice_number"
            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFCELL", strFileDate, "560", "Negative")
            System.Windows.Forms.Application.DoEvents()
            '//SFCELL2 - atcle parts (tie to department 560
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
            "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
            "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
            "and lpsprice.psprice_inventorypart = 1 " & _
            "and tworkorder.group_id in (3,10,11,13) " & _
            "and tdevice.loc_id = 2540 " & _
            "group by lpsprice.psprice_number"
            '//Used to be dept 561
            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFCELL2", strFileDate, "560", "Negative")
            System.Windows.Forms.Application.DoEvents()
            '//SFCELL2 - Brightpoint parts (tie to department 563)
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN  from " & _
            "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
            "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
            "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
            "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            "inner join tworkorder on tdevice.wo_id = tworkorder.wo_id " & _
            "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
            "and lpsprice.psprice_inventorypart = 1 " & _
            "and tworkorder.group_id in (3,10,11,13) " & _
            "and tdevice.loc_id = 2636 " & _
            "group by lpsprice.psprice_number"
            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFCELL2", strFileDate, "563", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 1 and 2 consumed and reclaimed - by defined/active bench
            '//This will now iterate for every bin that has been assigned as active
            Dim dsLocs As PSS.Data.Production.Joins
            strSQL = "SELECT * FROM lwclocation WHERE wc_location <> 'SFCELL' and mid(wc_location,1,3) = 'SFC' and wc_ActiveConsume = 1"
            Dim dtLocs As DataTable = dsLocs.OrderEntrySelect(strSQL)
            Dim rLocs As DataRow
            Dim LocCount As Integer = 0

            For LocCount = 0 To dtLocs.Rows.Count - 1
                rLocs = dtLocs.Rows(LocCount)
                strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, lwclocation.wc_location as BIN  from " & _
                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                        "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
                        "and lpsprice.psprice_inventorypart = 1 " & _
                        "and (tparttransaction.machinename = '" & rLocs("WC_Machine") & "' AND tnav_item.Shelf_No_ = 'BENCH') " & _
                        "and tdevice.loc_id = 2540 " & _
                        "group by lpsprice.psprice_number"

                System.Windows.Forms.Application.DoEvents()
                Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, rLocs("WC_Location"), strFileDate, "560", "Negative")
                System.Windows.Forms.Application.DoEvents()

                strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, lwclocation.wc_location as BIN  from " & _
                         "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                        "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                        "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                        "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                        "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                        "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                        "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=2 " & _
                        "and lpsprice.psprice_inventorypart = 1 " & _
                        "and (tparttransaction.machinename = '" & rLocs("WC_Machine") & "' AND tnav_item.Shelf_No_ = 'BENCH') " & _
                        "and tdevice.loc_id = 2636 " & _
                        "group by lpsprice.psprice_number"

                System.Windows.Forms.Application.DoEvents()
                Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, rLocs("WC_Location"), strFileDate, "563", "Negative")
                System.Windows.Forms.Application.DoEvents()
            Next

            '//Section 3 consumed - SFML01
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                     "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML01' or lwclocation.wc_altloc is null) " & _
                    "group by lpsprice.psprice_number"
            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFML01", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 4 consumed - SFML03
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                    "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.prod_id=1 and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFML03')" & _
                    "group by lpsprice.psprice_number"

            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFML03", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            '//Section 5 SFBILLING
            strSQL = "select lpsprice.psprice_number as number, sum(tparttransaction.trans_amount) as count, tparttransaction.binloc as BIN from " & _
                    "tparttransaction inner join tdevice on tparttransaction.device_id = tdevice.device_id " & _
                    "inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
                    "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tparttransaction.billcode_id = tpsmap.billcode_id " & _
                    "inner join lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
                    "left outer join twcdetail on tdevice.tray_id = twcdetail.tray_id " & _
                    "left outer join lwclocation on twcdetail.wclocation_id = lwclocation.wclocation_id " & _
                    "where tparttransaction.workdate = '" & vDate & "' and tparttransaction.trans_amount = 1 " & _
                    "and lpsprice.psprice_inventorypart = 1 " & _
                    "and (lwclocation.wc_altloc = 'SFBILLING')" & _
                    "group by lpsprice.psprice_number"

            Write2FileNEW(strSQL, s, sAdj, sWip, sWipREPORT, dtBin, "SFBILLING", strFileDate, "520", "Negative")
            System.Windows.Forms.Application.DoEvents()

            s.Close()
            sAdj.Close()
            sWip.Close()
            sWipREPORT.Close()
            Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("File Creation Is Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        End Sub

    End Class

End Namespace
