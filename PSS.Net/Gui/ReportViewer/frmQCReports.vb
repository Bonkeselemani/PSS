Option Explicit On 

Imports System.IO

Namespace Gui.ReportViewer
    Public Class frmQCReports
        Inherits System.Windows.Forms.Form

        Private objQC As PSS.Data.Buisness.QC
        Private _strReportName As String = ""
        Private _ds As New DataSet()

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strRptName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._strReportName = strRptName
            objQC = New PSS.Data.Buisness.QC()

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
        Friend WithEvents btnRawRpt As System.Windows.Forms.Button
        Friend WithEvents lblRptTitle As System.Windows.Forms.Label
        Friend WithEvents btnSummary As System.Windows.Forms.Button
        Friend WithEvents btnQR As System.Windows.Forms.Button
        Friend WithEvents radCustomer As System.Windows.Forms.RadioButton
        Friend WithEvents radGroup As System.Windows.Forms.RadioButton
        Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cmbCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents grpCustomersAndGroups As System.Windows.Forms.GroupBox
        Friend WithEvents radManufacturer As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnRawRpt = New System.Windows.Forms.Button()
            Me.lblRptTitle = New System.Windows.Forms.Label()
            Me.btnSummary = New System.Windows.Forms.Button()
            Me.btnQR = New System.Windows.Forms.Button()
            Me.grpCustomersAndGroups = New System.Windows.Forms.GroupBox()
            Me.radManufacturer = New System.Windows.Forms.RadioButton()
            Me.radGroup = New System.Windows.Forms.RadioButton()
            Me.radCustomer = New System.Windows.Forms.RadioButton()
            Me.cmbCustomer = New System.Windows.Forms.ComboBox()
            Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.grpCustomersAndGroups.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnRawRpt
            '
            Me.btnRawRpt.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnRawRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRawRpt.ForeColor = System.Drawing.Color.White
            Me.btnRawRpt.Location = New System.Drawing.Point(184, 280)
            Me.btnRawRpt.Name = "btnRawRpt"
            Me.btnRawRpt.Size = New System.Drawing.Size(264, 25)
            Me.btnRawRpt.TabIndex = 70
            Me.btnRawRpt.Text = "QC Raw Data Report"
            '
            'lblRptTitle
            '
            Me.lblRptTitle.BackColor = System.Drawing.Color.Transparent
            Me.lblRptTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRptTitle.ForeColor = System.Drawing.Color.Yellow
            Me.lblRptTitle.Location = New System.Drawing.Point(8, 4)
            Me.lblRptTitle.Name = "lblRptTitle"
            Me.lblRptTitle.Size = New System.Drawing.Size(448, 28)
            Me.lblRptTitle.TabIndex = 77
            Me.lblRptTitle.Text = "QC Reports"
            Me.lblRptTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnSummary
            '
            Me.btnSummary.BackColor = System.Drawing.Color.SteelBlue
            Me.btnSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSummary.ForeColor = System.Drawing.Color.Black
            Me.btnSummary.Location = New System.Drawing.Point(184, 352)
            Me.btnSummary.Name = "btnSummary"
            Me.btnSummary.Size = New System.Drawing.Size(264, 25)
            Me.btnSummary.TabIndex = 78
            Me.btnSummary.Text = "Summary Report"
            Me.btnSummary.Visible = False
            '
            'btnQR
            '
            Me.btnQR.BackColor = System.Drawing.Color.SteelBlue
            Me.btnQR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnQR.ForeColor = System.Drawing.Color.Black
            Me.btnQR.Location = New System.Drawing.Point(184, 392)
            Me.btnQR.Name = "btnQR"
            Me.btnQR.Size = New System.Drawing.Size(264, 25)
            Me.btnQR.TabIndex = 79
            Me.btnQR.Text = "QR Report"
            Me.btnQR.Visible = False
            '
            'grpCustomersAndGroups
            '
            Me.grpCustomersAndGroups.Controls.AddRange(New System.Windows.Forms.Control() {Me.radManufacturer, Me.radGroup, Me.radCustomer, Me.cmbCustomer})
            Me.grpCustomersAndGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpCustomersAndGroups.ForeColor = System.Drawing.Color.White
            Me.grpCustomersAndGroups.Location = New System.Drawing.Point(16, 56)
            Me.grpCustomersAndGroups.Name = "grpCustomersAndGroups"
            Me.grpCustomersAndGroups.Size = New System.Drawing.Size(296, 120)
            Me.grpCustomersAndGroups.TabIndex = 74
            Me.grpCustomersAndGroups.TabStop = False
            Me.grpCustomersAndGroups.Text = "Select Group, Customer or Manufacturer"
            '
            'radManufacturer
            '
            Me.radManufacturer.Location = New System.Drawing.Point(192, 32)
            Me.radManufacturer.Name = "radManufacturer"
            Me.radManufacturer.Size = New System.Drawing.Size(96, 24)
            Me.radManufacturer.TabIndex = 78
            Me.radManufacturer.Text = "Manufacturer"
            '
            'radGroup
            '
            Me.radGroup.Location = New System.Drawing.Point(8, 32)
            Me.radGroup.Name = "radGroup"
            Me.radGroup.Size = New System.Drawing.Size(56, 24)
            Me.radGroup.TabIndex = 75
            Me.radGroup.Text = "Group"
            '
            'radCustomer
            '
            Me.radCustomer.Location = New System.Drawing.Point(88, 32)
            Me.radCustomer.Name = "radCustomer"
            Me.radCustomer.Size = New System.Drawing.Size(80, 24)
            Me.radCustomer.TabIndex = 74
            Me.radCustomer.Text = "Customer"
            '
            'cmbCustomer
            '
            Me.cmbCustomer.ForeColor = System.Drawing.Color.Blue
            Me.cmbCustomer.Location = New System.Drawing.Point(8, 72)
            Me.cmbCustomer.Name = "cmbCustomer"
            Me.cmbCustomer.Size = New System.Drawing.Size(280, 21)
            Me.cmbCustomer.TabIndex = 73
            '
            'dtpFromDate
            '
            Me.dtpFromDate.CalendarForeColor = System.Drawing.Color.Green
            Me.dtpFromDate.CalendarTitleBackColor = System.Drawing.Color.Navy
            Me.dtpFromDate.CalendarTitleForeColor = System.Drawing.Color.Yellow
            Me.dtpFromDate.CustomFormat = "ddd, MMM d, yyyy"
            Me.dtpFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpFromDate.Location = New System.Drawing.Point(480, 64)
            Me.dtpFromDate.Name = "dtpFromDate"
            Me.dtpFromDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpFromDate.TabIndex = 80
            Me.dtpFromDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(336, 64)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(126, 16)
            Me.Label4.TabIndex = 81
            Me.Label4.Text = "From Work Date:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpToDate
            '
            Me.dtpToDate.CalendarForeColor = System.Drawing.Color.Green
            Me.dtpToDate.CalendarTitleBackColor = System.Drawing.Color.Navy
            Me.dtpToDate.CalendarTitleForeColor = System.Drawing.Color.Yellow
            Me.dtpToDate.CustomFormat = "ddd, MMM d, yyyy"
            Me.dtpToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpToDate.Location = New System.Drawing.Point(480, 112)
            Me.dtpToDate.Name = "dtpToDate"
            Me.dtpToDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpToDate.TabIndex = 83
            Me.dtpToDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(352, 112)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(112, 16)
            Me.Label5.TabIndex = 82
            Me.Label5.Text = "To Work Date:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmQCReports
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(640, 438)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpToDate, Me.Label5, Me.dtpFromDate, Me.Label4, Me.btnQR, Me.btnSummary, Me.lblRptTitle, Me.btnRawRpt, Me.grpCustomersAndGroups})
            Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmQCReports"
            Me.Text = "QC Reports"
            Me.grpCustomersAndGroups.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Protected Overrides Sub Finalize()
            objQC = Nothing
            MyBase.Finalize()
        End Sub

        '*************************************************************
        Private Sub LoadDates()
            Me.dtpFromDate.Value = objQC.GetCurrentWeekMonday
            Me.dtpToDate.Value = objQC.GetCurrentWeekFriday
        End Sub

        '*************************************************************
        Private Sub frmQCReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Dim bManufVisible As Boolean = False
                Dim bCustomerVisible As Boolean = False
                Dim bQRReport As Boolean = False

                LoadDates()
                LoadGroups()
                LoadCustomers()
                LoadManufacturers()
                SetupCustomerGroupManufSelection()
                Me.radGroup.Checked = True

                Me.lblRptTitle.Text = Me._strReportName
                Me.Text = Me._strReportName
                Select Case Me._strReportName
                    Case "QC Report"
                        Me.btnRawRpt.Text = "QC Raw Data Report"
                        bCustomerVisible = True
                        bManufVisible = True
                    Case "Pretest Report"
                        Me.btnRawRpt.Text = "Pretest Raw Data Report"
                        Me.btnSummary.Visible = True
                        Me.btnSummary.Text = "Pretest Dash Board Report"
                    Case "Cost Center Report"
                        Me.btnRawRpt.Visible = False
                        Me.btnSummary.Visible = True
                        Me.btnSummary.Text = "Cost Center Dash Board Report"
                    Case "QR Report"
                        Me.btnRawRpt.Visible = False
                        Me.btnSummary.Visible = False
                        Me.btnQR.Visible = True
                        bQRReport = True
                    Case "Repair/Refurbish/RUR Report"
                        Me.btnRawRpt.Text = "Repair/Refurbish/RUR Report"
                    Case "RF Report"
                        Me.btnRawRpt.Text = "RF Report"
                    Case "Software Refurbish Report"
                        Me.btnRawRpt.Text = "Software Refurbish Report"
                    Case Else
                        PSS.Gui.MainWin.MainWin.wrkArea.TabPages.Clear()
                        Me.Close()
                End Select

                Me.radManufacturer.Visible = bManufVisible
                Me.radManufacturer.Enabled = bManufVisible

                Me.radCustomer.Visible = bCustomerVisible
                Me.radCustomer.Enabled = bCustomerVisible

                Me.grpCustomersAndGroups.Visible = Not bQRReport
                Me.Label4.Visible = Not bQRReport
                Me.Label5.Visible = Not bQRReport
                Me.dtpFromDate.Visible = Not bQRReport
                Me.dtpToDate.Visible = Not bQRReport
                Me.dtpFromDate.Enabled = Not bQRReport
                Me.dtpToDate.Enabled = Not bQRReport
            Catch ex As Exception
                MessageBox.Show("frmReports_Load : " & ex.Message.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************
        Private Sub LoadGroups()
            Dim dtTemp As DataTable, dtGroups As DataTable

            Try
                If Me._strReportName = "Cost Center Reports" Then dtGroups = objQC.LoadGroups(1) Else dtGroups = objQC.LoadGroups()
                dtGroups.TableName = "Groups"
                Me._ds.Tables.Add(dtGroups)
            Catch ex As Exception
                MsgBox("Error in frmQCReports.LoadGroups:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objQC.DisposeDT(dtGroups)
            End Try
        End Sub

        '*************************************************************
        Private Sub LoadCustomers()
            Dim dtCustomers As DataTable

            Try
                dtCustomers = objQC.LoadCustomers()
                dtCustomers.TableName = "Customers"
                Me._ds.Tables.Add(dtCustomers)
            Catch ex As Exception
                MsgBox("Error in frmQCReports.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objQC.DisposeDT(dtCustomers)
            End Try
        End Sub

        '*************************************************************
        Private Sub LoadManufacturers()
            Dim dtManufacturers As DataTable

            Try
                dtManufacturers = objQC.LoadManufacturers()
                dtManufacturers.TableName = "Manufacturers"
                Me._ds.Tables.Add(dtManufacturers)
            Catch ex As Exception
                MsgBox("Error in frmQCReports.LoadManufacturers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                objQC.DisposeDT(dtManufacturers)
            End Try
        End Sub

        '*************************************************************
        Private Sub SetupCustomerGroupManufSelection()
            Dim dtSource As DataTable
            Dim strDisplayMember As String = String.Empty
            Dim strValueMember As String = String.Empty

            Try
                If Me.radCustomer.Checked Then
                    dtSource = Me._ds.Tables("Customers")
                    strDisplayMember = "Customer"
                    strValueMember = "cust_id"
                ElseIf Me.radGroup.Checked Then
                    dtSource = Me._ds.Tables("Groups")
                    strDisplayMember = "Group_Desc"
                    strValueMember = "Group_ID"
                Else
                    dtSource = Me._ds.Tables("Manufacturers")
                    strDisplayMember = "Manufacturer"
                    strValueMember = "manuf_id"
                End If

                With Me.cmbCustomer
                    .DataSource = Nothing
                    .DataSource = dtSource.DefaultView
                    .DisplayMember = strDisplayMember
                    .ValueMember = strValueMember
                    .SelectedValue = 0
                    .Visible = True
                End With
            Catch ex As Exception
                Throw ex
            Finally
                objQC.DisposeDT(dtSource)
            End Try
        End Sub

        '*************************************************************
        Private Sub btnRawRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRawRpt.Click
            Dim i As Integer = 0, iGroupID As Integer = 0, iCustID As Integer = 0, iManufID = 0
            Dim strFrom, strTo As String
            Dim objPretest As PSS.Data.Buisness.PreTest
            Dim objDB As PSS.Data.Buisness.DashBoardRpt
            Dim strRptPath As String = ""

            ''''strFrom = CStr(Format(Me.dtpFromDate.Value, "yyyy-MM-dd")) & " 03:10:00"
            '''''strTo = CStr(Format(Me.dtpToDate.Value, "yyyy-MM-dd")) & " 23:59:59"
            '''''//Craig Haney - modified this to set end date at 3:05 a.m. the following morning - to include all of second shift
            ''''strTo = CStr(Format(DateAdd(DateInterval.Day, 1, Me.dtpToDate.Value), "yyyy-MM-dd")) & " 03:05:00"
            '''''//Craig Haney - modified this to set end date at 3:05 a.m. the following morning - to include all of second shift

            strFrom = CStr(Format(Me.dtpFromDate.Value, "yyyy-MM-dd"))
            strTo = CStr(Format(Me.dtpToDate.Value, "yyyy-MM-dd"))

            If Me.radGroup.Checked Then
                iGroupID = Me.cmbCustomer.SelectedValue
            ElseIf Me.radCustomer.Checked Then
                iCustID = Me.cmbCustomer.SelectedValue
            Else
                iManufID = Me.cmbCustomer.SelectedValue
            End If

            Try
                Me.btnRawRpt.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                If iGroupID = 0 And iCustID = 0 And iManufID = 0 And Me.radCustomer.Visible Then
                    MessageBox.Show(String.Format("Please select a {0}.", IIf(Me.radCustomer.Checked, "customer", IIf(Me.radGroup.Checked, "group", "manufacturer"))), "Make a Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                    Exit Sub
                End If

                Select Case Me._strReportName
                    Case "QC Report"
                        'i = objQC.CreateQCRawDataRpt(strFrom, strTo, Me.cmbCustomer.SelectedValue)
                        i = objQC.CreateQCRawDataRpt(strFrom, strTo, iGroupID, iCustID, iManufID)
                        strRptPath = objQC.strRptPath
                    Case "Pretest Report"
                        objPretest = New PSS.Data.Buisness.PreTest()
                        i = objPretest.CreatePretestRawDataRpt(strFrom, strTo, strRptPath, Me.cmbCustomer.SelectedValue)
                    Case "Repair/Refurbish/RUR Report"
                        objPretest = New PSS.Data.Buisness.PreTest()
                        i = objPretest.CreateRepairRefurbishRURRawDataRpt(strFrom, strTo, Me.cmbCustomer.SelectedValue)
                    Case "RF Report"
                        objPretest = New PSS.Data.Buisness.PreTest()
                        i = objPretest.CreateRFTestRawDataRpt(strFrom, strTo, Me.cmbCustomer.SelectedValue)
                    Case "Software Refurbish Report"
                        objPretest = New PSS.Data.Buisness.PreTest()
                        i = objPretest.CreateSoftwareRefTestRawDataRpt(strFrom, strTo, Me.cmbCustomer.SelectedValue)
                    Case Else
                        Exit Sub
                End Select

                If i = 1 And Not (Me._strReportName.Equals("QC Report") And (Me.radCustomer.Checked Or Me.radManufacturer.Checked)) Then
                    MessageBox.Show("Report has been created successfully and saved at '" & strRptPath & "'", Me._strReportName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show("btnRawRpt_Click:: " & ex.Message)
            Finally
                Me.btnRawRpt.Enabled = True
                Cursor.Current = Cursors.Default
                objDB = Nothing
                objPretest = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '*************************************************************
        Private Sub btnSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSummary.Click
            Dim i As Integer = 0
            Dim strFrom, strTo As String
            Dim objPretest As PSS.Data.Buisness.PreTest
            Dim objDB As PSS.Data.Buisness.DashBoardRpt
            Dim strRptPath As String = ""

            strFrom = CStr(Format(Me.dtpFromDate.Value, "yyyy-MM-dd"))
            strTo = CStr(Format(Me.dtpToDate.Value, "yyyy-MM-dd"))

            Try
                Me.btnRawRpt.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                Select Case Me._strReportName
                    Case "QC Report"
                        'No summary for QC Reports
                    Case "Pretest Report"
                        objPretest = New PSS.Data.Buisness.PreTest()
                        i = objPretest.CreatePretestSummaryRpt(strFrom, strTo, strRptPath, Me.cmbCustomer.SelectedValue, Me.cmbCustomer.Text)
                    Case "Cost Center Report"
                        objDB = New PSS.Data.Buisness.DashBoardRpt()
                        i = objDB.CreateDashBoardRpt(strFrom, strTo, Me.cmbCustomer.SelectedValue, Me.cmbCustomer.Text)
                    Case Else
                        Exit Sub
                End Select

                If i = 1 Then
                    MessageBox.Show("Report has been created successfully and saved at '" & strRptPath & "'", Me._strReportName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show("btnSummaryRpt_Click:: " & ex.Message)
            Finally
                Me.btnRawRpt.Enabled = True
                Cursor.Current = Cursors.Default
                objDB = Nothing
                objPretest = Nothing
            End Try
        End Sub

        '*************************************************************
        Private Sub btnQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQR.Click
            Dim dtWo As DataTable
            Dim strWoName As String = ""
            Dim iWOID, i, iLocID As Integer
            Dim strSql As String = ""
            Dim objfrmSelectValue As frmSelectedValue
            Dim fdOpenFile As OpenFileDialog
            Dim strFilePath As String = ""
            Dim dt As DataTable

            Try
                strWoName = InputBox("Enter RMA/WO:", "Get WO").Trim
                If strWoName.Trim.Length = 0 Then Exit Sub

                'Get WO ID
                dtWo = PSS.Data.Buisness.Generic.GetCustWo(strWoName.Trim)
                If dtWo.Rows.Count = 0 Then
                    MessageBox.Show("RMR/WO is not existed in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dtWo.Rows.Count > 1 Then
                    strSql = "SELECT tworkorder.Loc_ID as ID, concat(Cust_Name1, ' Location ', tlocation.Loc_Name) as 'Desc' " & Environment.NewLine
                    strSql &= "FROM tworkorder " & Environment.NewLine
                    strSql &= "INNER JOIN tlocation ON tworkorder.Loc_ID = tlocation.Loc_ID " & Environment.NewLine
                    strSql &= "INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID " & Environment.NewLine
                    strSql &= "WHERE tworkorder.WO_CustWO = '" & strWoName & "' " & Environment.NewLine

                    objfrmSelectValue = New frmSelectedValue(strSql, "Please select customer location", "ID", "Desc")
                    objfrmSelectValue.ShowDialog()
                    If objfrmSelectValue._iSelectedVal > 0 Then
                        If dtWo.Select("Loc_ID = " & objfrmSelectValue._iSelectedVal).Length = 0 Then
                            MessageBox.Show("No RMA/WO found for selected customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf dtWo.Select("Loc_ID = " & objfrmSelectValue._iSelectedVal).Length > 1 Then
                            MessageBox.Show("More than one RMA/WO found for selected customer. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iWOID = dtWo.Select("Loc_ID = " & objfrmSelectValue._iSelectedVal)(0)("WO_ID")
                            iLocID = objfrmSelectValue._iSelectedVal
                        End If
                    End If
                Else
                    iWOID = dtWo.Rows(0)("WO_ID")
                    iLocID = dtWo.Rows(0)("Loc_ID")
                End If

                'Create Report
                If iWOID > 0 Then
                    fdOpenFile = New OpenFileDialog()
                    fdOpenFile.DefaultExt = ".*"
                    fdOpenFile.ShowDialog()
                    strFilePath = fdOpenFile.FileName

                    If File.Exists(strFilePath) = False Then
                        If MessageBox.Show("File does not exit. Would you like to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then strFilePath = "" Else Exit Sub
                    ElseIf strFilePath.EndsWith(".xls") = False Then
                        If MessageBox.Show("The selected file is not of type Excel. Would you like to continue without file?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then strFilePath = "" Else Exit Sub
                    End If

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    If strFilePath.Trim.Length > 0 Then dt = Me.objQC.GetCustFailReason(strFilePath)

                    i = Me.objQC.CreateQR_Rpt(iWOID, iLocID, strFilePath, dt)

                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnQR_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                PSS.Data.Buisness.Generic.DisposeDT(dtWo)
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                If Not IsNothing(objfrmSelectValue) Then
                    objfrmSelectValue.Dispose()
                    objfrmSelectValue = Nothing
                End If
            End Try
        End Sub

        '*************************************************************
        Private Sub radCustomer_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radCustomer.CheckedChanged
            Try
                Dim rad As RadioButton = DirectCast(sender, RadioButton)

                If rad.Checked Then SetupCustomerGroupManufSelection()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "radCustomer_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*************************************************************
        Private Sub radGroup_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radGroup.CheckedChanged
            Try
                Dim rad As RadioButton = DirectCast(sender, RadioButton)

                If rad.Checked Then SetupCustomerGroupManufSelection()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "radGroup_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub radManufacturer_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radManufacturer.CheckedChanged
            Try
                Dim rad As RadioButton = DirectCast(sender, RadioButton)

                If rad.Checked Then SetupCustomerGroupManufSelection()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "radManufacturer_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
    End Class
End Namespace