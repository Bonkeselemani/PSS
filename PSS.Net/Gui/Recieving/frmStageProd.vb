'Imports CrystalDecisions.CrystalReports.Engine
'Imports PSS.Core
'Imports PSS.Data

'Public Class frmStageProd
'    Inherits System.Windows.Forms.Form

'#Region " Windows Form Designer generated code "

'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call

'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
'    Friend WithEvents lblCustomer As System.Windows.Forms.Label
'    Friend WithEvents lblManufacturer As System.Windows.Forms.Label
'    Friend WithEvents lblModel As System.Windows.Forms.Label
'    Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
'    Friend WithEvents lblSerialSN As System.Windows.Forms.Label
'    Friend WithEvents lblCount As System.Windows.Forms.Label
'    Friend WithEvents valCount As System.Windows.Forms.Label
'    Friend WithEvents btnPrint As System.Windows.Forms.Button
'    Friend WithEvents valManuf As System.Windows.Forms.Label
'    Friend WithEvents valModel As System.Windows.Forms.Label
'    Friend WithEvents mainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmStageProd))
'        Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
'        Me.cboCustomer = New System.Windows.Forms.ComboBox()
'        Me.lblCustomer = New System.Windows.Forms.Label()
'        Me.lblManufacturer = New System.Windows.Forms.Label()
'        Me.lblModel = New System.Windows.Forms.Label()
'        Me.txtDeviceSN = New System.Windows.Forms.TextBox()
'        Me.lblSerialSN = New System.Windows.Forms.Label()
'        Me.lblCount = New System.Windows.Forms.Label()
'        Me.valCount = New System.Windows.Forms.Label()
'        Me.btnPrint = New System.Windows.Forms.Button()
'        Me.valManuf = New System.Windows.Forms.Label()
'        Me.valModel = New System.Windows.Forms.Label()
'        Me.mainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
'        CType(Me.mainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.SuspendLayout()
'        '
'        'cboCustomer
'        '
'        Me.cboCustomer.Location = New System.Drawing.Point(72, 14)
'        Me.cboCustomer.Name = "cboCustomer"
'        Me.cboCustomer.Size = New System.Drawing.Size(344, 21)
'        Me.cboCustomer.TabIndex = 0
'        '
'        'lblCustomer
'        '
'        Me.lblCustomer.Location = New System.Drawing.Point(16, 16)
'        Me.lblCustomer.Name = "lblCustomer"
'        Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
'        Me.lblCustomer.TabIndex = 1
'        Me.lblCustomer.Text = "Customer:"
'        '
'        'lblManufacturer
'        '
'        Me.lblManufacturer.Location = New System.Drawing.Point(8, 64)
'        Me.lblManufacturer.Name = "lblManufacturer"
'        Me.lblManufacturer.Size = New System.Drawing.Size(80, 16)
'        Me.lblManufacturer.TabIndex = 2
'        Me.lblManufacturer.Text = "Manufacturer:"
'        Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'lblModel
'        '
'        Me.lblModel.Location = New System.Drawing.Point(8, 80)
'        Me.lblModel.Name = "lblModel"
'        Me.lblModel.Size = New System.Drawing.Size(80, 16)
'        Me.lblModel.TabIndex = 3
'        Me.lblModel.Text = "Model:"
'        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'txtDeviceSN
'        '
'        Me.txtDeviceSN.Location = New System.Drawing.Point(104, 320)
'        Me.txtDeviceSN.Name = "txtDeviceSN"
'        Me.txtDeviceSN.TabIndex = 4
'        Me.txtDeviceSN.Text = ""
'        '
'        'lblSerialSN
'        '
'        Me.lblSerialSN.Location = New System.Drawing.Point(24, 328)
'        Me.lblSerialSN.Name = "lblSerialSN"
'        Me.lblSerialSN.Size = New System.Drawing.Size(80, 16)
'        Me.lblSerialSN.TabIndex = 5
'        Me.lblSerialSN.Text = "Serial Number:"
'        '
'        'lblCount
'        '
'        Me.lblCount.Location = New System.Drawing.Point(72, 152)
'        Me.lblCount.Name = "lblCount"
'        Me.lblCount.Size = New System.Drawing.Size(80, 16)
'        Me.lblCount.TabIndex = 7
'        Me.lblCount.Text = "Count"
'        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'valCount
'        '
'        Me.valCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.valCount.Location = New System.Drawing.Point(48, 176)
'        Me.valCount.Name = "valCount"
'        Me.valCount.Size = New System.Drawing.Size(128, 56)
'        Me.valCount.TabIndex = 8
'        Me.valCount.Text = "0"
'        Me.valCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'        '
'        'btnPrint
'        '
'        Me.btnPrint.Location = New System.Drawing.Point(24, 352)
'        Me.btnPrint.Name = "btnPrint"
'        Me.btnPrint.Size = New System.Drawing.Size(392, 23)
'        Me.btnPrint.TabIndex = 9
'        Me.btnPrint.Text = "&Print"
'        '
'        'valManuf
'        '
'        Me.valManuf.Location = New System.Drawing.Point(96, 64)
'        Me.valManuf.Name = "valManuf"
'        Me.valManuf.Size = New System.Drawing.Size(100, 16)
'        Me.valManuf.TabIndex = 10
'        '
'        'valModel
'        '
'        Me.valModel.Location = New System.Drawing.Point(96, 80)
'        Me.valModel.Name = "valModel"
'        Me.valModel.Size = New System.Drawing.Size(100, 16)
'        Me.valModel.TabIndex = 11
'        '
'        'mainGrid
'        '
'        Me.mainGrid.AllowAddNew = True
'        Me.mainGrid.AllowColMove = False
'        Me.mainGrid.AllowColSelect = False
'        Me.mainGrid.AllowDelete = True
'        Me.mainGrid.AllowFilter = True
'        Me.mainGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
'        Me.mainGrid.AllowSort = True
'        Me.mainGrid.AllowUpdate = False
'        Me.mainGrid.AlternatingRows = True
'        Me.mainGrid.CaptionHeight = 17
'        Me.mainGrid.CollapseColor = System.Drawing.Color.Black
'        Me.mainGrid.DataChanged = False
'        Me.mainGrid.BackColor = System.Drawing.Color.Empty
'        Me.mainGrid.ExpandColor = System.Drawing.Color.Black
'        Me.mainGrid.GroupByCaption = "Drag a column header here to group by that column"
'        Me.mainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
'        Me.mainGrid.Location = New System.Drawing.Point(208, 48)
'        Me.mainGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
'        Me.mainGrid.Name = "mainGrid"
'        Me.mainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
'        Me.mainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
'        Me.mainGrid.PreviewInfo.ZoomFactor = 75
'        Me.mainGrid.PrintInfo.ShowOptionsDialog = False
'        Me.mainGrid.RecordSelectorWidth = 16
'        GridLines1.Color = System.Drawing.Color.DarkGray
'        GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
'        Me.mainGrid.RowDivider = GridLines1
'        Me.mainGrid.RowHeight = 15
'        Me.mainGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
'        Me.mainGrid.ScrollTips = False
'        Me.mainGrid.Size = New System.Drawing.Size(208, 296)
'        Me.mainGrid.TabIndex = 12
'        Me.mainGrid.Text = "C1TrueDBGrid1"
'        Me.mainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
'        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
'        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
'        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
'        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
'        "er;}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}Od" & _
'        "dRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Bord" & _
'        "er:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{Al" & _
'        "ignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win" & _
'        ".C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" Alte" & _
'        "rnatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterH" & _
'        "eight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWid" & _
'        "th=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 204," & _
'        " 292</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent=""Style2"" me=""Sty" & _
'        "le10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow" & _
'        """ me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle p" & _
'        "arent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingS" & _
'        "tyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=" & _
'        """Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""O" & _
'        "ddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /" & _
'        "><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style" & _
'        "1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
'        "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
'        "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
'        "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
'        "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
'        "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
'        "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
'        "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
'        "</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 204, 292</" & _
'        "ClientArea></Blob>"
'        '
'        'frmStageProd
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.ClientSize = New System.Drawing.Size(424, 381)
'        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.mainGrid, Me.valModel, Me.valManuf, Me.btnPrint, Me.valCount, Me.lblCount, Me.lblSerialSN, Me.txtDeviceSN, Me.lblModel, Me.lblManufacturer, Me.lblCustomer, Me.cboCustomer})
'        Me.Name = "frmStageProd"
'        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
'        Me.Text = "From Staging to Production"
'        CType(Me.mainGrid, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.ResumeLayout(False)

'    End Sub

'#End Region

'    Private dtCustomer, dtDevices As DataTable
'    Private CustID As Integer
'    Private arrDevice(5000, 3) As String
'    Private dtGrid As New DataTable()
'    Private intCounter, intModel, intManuf As Integer
'    Private blnModel As Boolean
'    Private recUser As String
'    Private valWO As Integer

'    Private Sub frmStageProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

'        populateCustomers()
'        CreateGridDT()
'        intCounter = 0
'        blnModel = False
'        intModel = 0
'        valWO = 0
'        recUser = PSS.Core.Global.ApplicationUser.User

'    End Sub

'    Private Sub populateCustomers()

'        Dim tblCust As New PSS.Data.Production.Joins()
'        Dim dtCust As DataTable = tblCust.GenericSelect("SELECT DISTINCT tcustomer.cust_ID, tcustomer.cust_name1 from ((tcustomer INNER JOIN tlocation On tcustomer.cust_id = tlocation.cust_id) INNER JOIN tdevice ON tlocation.loc_id = tdevice.loc_id) WHERE tdevice.tray_id is null")

'        Dim xcount As Integer = 0
'        Dim r As DataRow
'        For xcount = 0 To dtCust.Rows.Count - 1
'            r = dtCust.Rows(xcount)
'            cboCustomer.Items.Add(r("Cust_Name1"))
'        Next

'        dtCustomer = dtCust
'        dtCust.Dispose()
'        dtCust = Nothing

'    End Sub

'    Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged

'        Dim xCount As Integer
'        Dim r As DataRow

'        For xCount = 0 To dtCustomer.Rows.Count - 1
'            r = dtCustomer.Rows(xCount)
'            If Trim(r("Cust_Name1")) = Trim(cboCustomer.SelectedItem) Then
'                CustID = r("Cust_ID")
'                Exit For
'            End If
'        Next

'        '//Build array of devices
'        Dim tblDev As New PSS.Data.Production.Joins()
'        Dim dtDev As DataTable = tblDev.GenericSelect("SELECT tdevice.Device_SN, tdevice.Model_ID, tdevice.WO_ID, tdevice.Loc_ID from ((tcustomer INNER JOIN tlocation On tcustomer.cust_id = tlocation.cust_id) INNER JOIN tdevice ON tlocation.loc_id = tdevice.loc_id) WHERE tcustomer.cust_id =" & CustID)
'        For xCount = 0 To dtDev.Rows.Count - 1
'            r = dtDev.Rows(xCount)
'            arrDevice(xCount, 0) = r("Device_SN")
'            arrDevice(xCount, 1) = r("Model_ID")
'            arrDevice(xCount, 2) = r("WO_ID")
'            arrDevice(xCount, 3) = r("Loc_ID")
'        Next

'        dtDevices = dtDev
'        dtDev.Dispose()
'        dtDev = Nothing

'        txtDeviceSN.Focus()

'    End Sub

'    Private Sub txtDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown

'        If e.KeyValue = 13 Then
'            Dim xCount, yCount As Integer
'            Dim r As DataRow

'            For xCount = 0 To dtDevices.Rows.Count - 1
'                r = dtDevices.Rows(xCount)
'                If Trim(txtDeviceSN.Text) = Trim(r("Device_SN")) Then

'                    If intModel = 0 Then
'                        intModel = Trim(r("Model_ID"))
'                        valWO = Trim(r("WO_ID"))
'                    End If

'                    If blnModel = True Then 'Validate
'                        If intModel <> CInt(Trim(r("Model_ID"))) Then
'                            MsgBox("Models are not same.", MsgBoxStyle.OKOnly)
'                            txtDeviceSN.Text = ""
'                            txtDeviceSN.Focus()
'                            Exit Sub
'                        End If
'                    End If

'                    '//add record to grid
'                    Dim dr1 As DataRow = dtGrid.NewRow
'                    dr1("Count") = intCounter + 1 'temporary not inserted into database
'                    dr1("DeviceSN") = UCase(txtDeviceSN.Text)
'                    dr1("Location") = Trim(r("Loc_ID"))
'                    dtGrid.Rows.Add(dr1)
'                    '//increase counter by 1
'                    intCounter += 1
'                    valCount.Text = intCounter
'                    '//remove from textbox
'                    txtDeviceSN.Text = ""
'                    txtDeviceSN.Focus()
'                    Exit For
'                End If
'            Next

'            If blnModel = False Then 'get Model and Manufacturer
'                Dim dtModel As New PSS.Data.Production.Joins()
'                Dim dtModelG As DataTable = dtModel.GenericSelect("SELECT * FROM tmodel WHERE model_id = " & intModel)
'                For yCount = 0 To dtModelG.Rows.Count - 1
'                    r = dtModelG.Rows(yCount)
'                    valModel.Text = r("Model_Desc")
'                    intManuf = r("Manuf_ID")
'                Next
'                Dim dtManufG As DataTable = dtModel.GenericSelect("SELECT * FROM lmanuf WHERE manuf_id = " & intManuf)
'                For yCount = 0 To dtManufG.Rows.Count - 1
'                    r = dtManufG.Rows(yCount)
'                    valManuf.Text = r("Manuf_Desc")
'                Next
'                blnModel = True
'            End If

'            If Len(Trim(txtDeviceSN.Text)) > 0 Then
'                MsgBox("Device Serial Number Not In List.", MsgBoxStyle.OKOnly)
'                txtDeviceSN.Text = ""
'                txtDeviceSN.Focus()
'            End If

'        End If

'    End Sub

'    Private Sub CreateGridDT()


'        dtGrid.MinimumCapacity = 500
'        dtGrid.CaseSensitive = False

'        Dim dcDeviceCount As New DataColumn("Count")
'        dtGrid.Columns.Add(dcDeviceCount)
'        Dim dcDeviceSN As New DataColumn("DeviceSN")
'        dtGrid.Columns.Add(dcDeviceSN)
'        Dim dcLocID As New DataColumn("Location")
'        dtGrid.Columns.Add(dcLocID)

'        mainGrid.DataSource = dtGrid
'        'CreateGridDT = dtGrid

'    End Sub

'    Private Sub mainGrid_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles mainGrid.AfterDelete

'        intCounter -= 1
'        valCount.Text = intCounter
'        Dim r As DataRow
'        Dim xCount As Integer

'        For xCount = 0 To dtGrid.Rows.Count - 1
'            r = dtGrid.Rows(xCount)
'            r("Count") = xCount + 1
'        Next

'        If valCount.Text = "0" Then
'            intModel = 0
'            intManuf = 0
'            valModel.Text = ""
'            valManuf.Text = ""
'            blnModel = False
'        End If

'        txtDeviceSN.Focus()

'    End Sub

'    Private Function InsertTray(ByVal valWO As Int32) As Int32

'        If valWO > 0 Then
'            Dim strSQL As String = "Insert into ttray (" & _
'            " Tray_RecUser, WO_ID) VALUES ('" & _
'            recUser & "', " & _
'            valWO & ")"

'            Dim tblTray As New PSS.Data.Production.ttray()
'            Dim trayID As Int32 = tblTray.idTransaction(strSQL)

'            InsertTray = trayID
'        End If

'    End Function

'    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

'        Dim valTray As Int32 = InsertTray(valWO)
'        Dim xCount As Integer
'        Dim r As DataRow

'        If valTray > 0 And CustID > 0 Then

'            For xCount = 0 To dtGrid.Rows.Count - 1
'                r = dtGrid.Rows(xCount)
'                '//Perform update of data here
'                Dim xTray As New PSS.Data.Production.Joins()
'                Dim dtTrayUpd As Boolean = xTray.OrderEntryUpdateDelete("UPDATE tdevice SET tdevice.tray_id = " & valTray & ", tdevice.Device_Cnt = " & Trim(r("Count")) & " WHERE tdevice.Loc_id = " & Trim(r("Location")) & " AND tdevice.device_sn = '" & Trim(r("DeviceSN")) & "' AND tdevice.tray_id is null")
'                If dtTrayUpd = False Then
'                    MsgBox("Not all elements were updates. Contact IT", MsgBoxStyle.OKOnly, "ERROR")
'                    Exit Sub
'                End If
'            Next

'            '//Print out traveller
'            Dim strReportLoc As String = PSS.Core.ReportPath

'            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
'            '//Report to Print
'            'MainWin.StatusBar.SetStatusText("Sending Worksheet to Printer")
'            Try
'                'Dim rptApp As New CRAXDRT.Application()
'                'Dim rpt As New CRAXDRT.Report()
'                Dim objRpt As ReportDocument

'                objRpt = New ReportDocument()

'                With objRpt
'                    .Load(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")
'                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(valTray)
'                    .PrintToPrinter(2, True, 0, 0)
'                End With

'                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")
'                'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(valTray)
'                'rpt.PrintOut(False, 2)
'                'rpt = Nothing
'                'rptApp = Nothing

'            Catch exp As Exception
'                MsgBox(exp.ToString)
'                Cursor.Current = System.Windows.Forms.Cursors.Default
'            End Try

'            '//Reset values to start new
'            Try
'                cboCustomer.Items.Clear()
'            Catch ex As Exception
'            End Try
'            populateCustomers()
'            Try
'                dtGrid.Clear()
'            Catch exp As Exception
'            End Try
'            intCounter = 0
'            blnModel = False
'            intModel = 0
'            intManuf = 0
'            valWO = 0
'            valModel.Text = ""
'            valManuf.Text = ""
'            recUser = PSS.Core.Global.ApplicationUser.User
'            cboCustomer.Focus()

'        End If

'    End Sub

'    Private Sub txtDeviceSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged

'    End Sub
'End Class
