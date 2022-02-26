
Namespace Gui.BCconsume_IND

    Public Class frmBillcodeConsumption
        Inherits System.Windows.Forms.Form

        Private ds As PSS.Data.Production.Joins
        Private dt As DataTable
        Private strSQL As String

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
        Friend WithEvents lblBillcode As System.Windows.Forms.Label
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboBillcode As System.Windows.Forms.ComboBox
        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnGetData As System.Windows.Forms.Button
        Friend WithEvents lblDC As System.Windows.Forms.Label
        Friend WithEvents lblDCdetail As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboModel As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnGetDataCustomer As System.Windows.Forms.Button
        Friend WithEvents btnGetDataModel As System.Windows.Forms.Button
        Friend WithEvents btnGetDataCustomerModel As System.Windows.Forms.Button
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents gbDeviceType As System.Windows.Forms.GroupBox
        Friend WithEvents rbMSG As System.Windows.Forms.RadioButton
        Friend WithEvents rbCell As System.Windows.Forms.RadioButton
        Friend WithEvents rbGPS As System.Windows.Forms.RadioButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBillcodeConsumption))
            Me.lblBillcode = New System.Windows.Forms.Label()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
            Me.cboBillcode = New System.Windows.Forms.ComboBox()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnGetData = New System.Windows.Forms.Button()
            Me.lblDC = New System.Windows.Forms.Label()
            Me.lblDCdetail = New System.Windows.Forms.Label()
            Me.btnGetDataCustomer = New System.Windows.Forms.Button()
            Me.btnGetDataModel = New System.Windows.Forms.Button()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboModel = New System.Windows.Forms.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnGetDataCustomerModel = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.gbDeviceType = New System.Windows.Forms.GroupBox()
            Me.rbGPS = New System.Windows.Forms.RadioButton()
            Me.rbCell = New System.Windows.Forms.RadioButton()
            Me.rbMSG = New System.Windows.Forms.RadioButton()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbDeviceType.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblBillcode
            '
            Me.lblBillcode.BackColor = System.Drawing.Color.Transparent
            Me.lblBillcode.Location = New System.Drawing.Point(24, 16)
            Me.lblBillcode.Name = "lblBillcode"
            Me.lblBillcode.Size = New System.Drawing.Size(64, 16)
            Me.lblBillcode.TabIndex = 0
            Me.lblBillcode.Text = "BILLCODE:"
            Me.lblBillcode.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.Location = New System.Drawing.Point(8, 40)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
            Me.lblStartDate.TabIndex = 1
            Me.lblStartDate.Text = "START DATE:"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Location = New System.Drawing.Point(24, 64)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(64, 16)
            Me.lblEndDate.TabIndex = 2
            Me.lblEndDate.Text = "END DATE:"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'dtpStart
            '
            Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpStart.Location = New System.Drawing.Point(96, 32)
            Me.dtpStart.Name = "dtpStart"
            Me.dtpStart.Size = New System.Drawing.Size(144, 20)
            Me.dtpStart.TabIndex = 2
            '
            'dtpEnd
            '
            Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpEnd.Location = New System.Drawing.Point(96, 56)
            Me.dtpEnd.Name = "dtpEnd"
            Me.dtpEnd.Size = New System.Drawing.Size(144, 20)
            Me.dtpEnd.TabIndex = 3
            '
            'cboBillcode
            '
            Me.cboBillcode.Location = New System.Drawing.Point(96, 8)
            Me.cboBillcode.Name = "cboBillcode"
            Me.cboBillcode.Size = New System.Drawing.Size(144, 21)
            Me.cboBillcode.TabIndex = 1
            '
            'MainGrid
            '
            Me.MainGrid.AllowColMove = False
            Me.MainGrid.AllowColSelect = False
            Me.MainGrid.AllowDelete = True
            Me.MainGrid.AllowFilter = False
            Me.MainGrid.AllowUpdate = False
            Me.MainGrid.AlternatingRows = True
            Me.MainGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.MainGrid.BackColor = System.Drawing.Color.Ivory
            Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.MainGrid.CaptionHeight = 17
            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.MainGrid.Location = New System.Drawing.Point(248, 8)
            Me.MainGrid.Name = "MainGrid"
            Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.MainGrid.PreviewInfo.ZoomFactor = 75
            Me.MainGrid.RowHeight = 15
            Me.MainGrid.Size = New System.Drawing.Size(424, 280)
            Me.MainGrid.TabIndex = 0
            Me.MainGrid.TabStop = False
            Me.MainGrid.Text = "C1TrueDBGrid1"
            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;BackColor:Co" & _
            "ntrol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}OddRow{}Foo" & _
            "ter{}Caption{AlignHorz:Center;}Normal{Font:Verdana, 8.25pt;}HighlightRow{ForeCol" & _
            "or:HighlightText;BackColor:Highlight;}EvenRow{BackColor:Aqua;}Editor{}RecordSele" & _
            "ctor{AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Style14{}Style15{}Group{" & _
            "AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style10{AlignHor" & _
            "z:Near;}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fal" & _
            "se"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17""" & _
            " ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder" & _
            """ RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizonta" & _
            "lScrollGroup=""1""><Height>278</Height><CaptionStyle parent=""Style2"" me=""Style10"" " & _
            "/><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""" & _
            "Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=" & _
            """Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle p" & _
            "arent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style" & _
            "7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow""" & _
            " me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Sele" & _
            "ctedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><" & _
            "ClientRect>0, 0, 422, 278</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sun" & _
            "ken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" m" & _
            "e=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""R" & _
            "ecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption""" & _
            " me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits>" & _
            "<Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>" & _
            "0, 0, 422, 278</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Print" & _
            "PageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnGetData
            '
            Me.btnGetData.BackgroundImage = CType(resources.GetObject("btnGetData.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnGetData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGetData.Location = New System.Drawing.Point(8, 80)
            Me.btnGetData.Name = "btnGetData"
            Me.btnGetData.Size = New System.Drawing.Size(232, 24)
            Me.btnGetData.TabIndex = 4
            Me.btnGetData.Text = "GET DATA"
            '
            'lblDC
            '
            Me.lblDC.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.lblDC.BackColor = System.Drawing.Color.Transparent
            Me.lblDC.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDC.Location = New System.Drawing.Point(240, 296)
            Me.lblDC.Name = "lblDC"
            Me.lblDC.Size = New System.Drawing.Size(208, 23)
            Me.lblDC.TabIndex = 0
            Me.lblDC.Text = "TOTAL COUNT"
            Me.lblDC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDCdetail
            '
            Me.lblDCdetail.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.lblDCdetail.BackColor = System.Drawing.Color.Ivory
            Me.lblDCdetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDCdetail.Location = New System.Drawing.Point(456, 296)
            Me.lblDCdetail.Name = "lblDCdetail"
            Me.lblDCdetail.Size = New System.Drawing.Size(136, 24)
            Me.lblDCdetail.TabIndex = 0
            Me.lblDCdetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnGetDataCustomer
            '
            Me.btnGetDataCustomer.BackgroundImage = CType(resources.GetObject("btnGetDataCustomer.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnGetDataCustomer.Enabled = False
            Me.btnGetDataCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGetDataCustomer.Location = New System.Drawing.Point(608, 296)
            Me.btnGetDataCustomer.Name = "btnGetDataCustomer"
            Me.btnGetDataCustomer.Size = New System.Drawing.Size(64, 24)
            Me.btnGetDataCustomer.TabIndex = 6
            Me.btnGetDataCustomer.Text = "GET DATA BY CUSTOMER"
            Me.btnGetDataCustomer.Visible = False
            '
            'btnGetDataModel
            '
            Me.btnGetDataModel.BackgroundImage = CType(resources.GetObject("btnGetDataModel.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnGetDataModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGetDataModel.Location = New System.Drawing.Point(8, 232)
            Me.btnGetDataModel.Name = "btnGetDataModel"
            Me.btnGetDataModel.Size = New System.Drawing.Size(232, 24)
            Me.btnGetDataModel.TabIndex = 9
            Me.btnGetDataModel.Text = "GET DATA BY MODEL"
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(96, 112)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(144, 21)
            Me.cboCustomer.TabIndex = 5
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Location = New System.Drawing.Point(16, 117)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 43
            Me.Label1.Text = "CUSTOMER:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboModel
            '
            Me.cboModel.Location = New System.Drawing.Point(96, 136)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(144, 21)
            Me.cboModel.TabIndex = 7
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Location = New System.Drawing.Point(16, 136)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 16)
            Me.Label2.TabIndex = 45
            Me.Label2.Text = "MODEL:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnGetDataCustomerModel
            '
            Me.btnGetDataCustomerModel.BackgroundImage = CType(resources.GetObject("btnGetDataCustomerModel.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnGetDataCustomerModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGetDataCustomerModel.Location = New System.Drawing.Point(8, 264)
            Me.btnGetDataCustomerModel.Name = "btnGetDataCustomerModel"
            Me.btnGetDataCustomerModel.Size = New System.Drawing.Size(232, 24)
            Me.btnGetDataCustomerModel.TabIndex = 10
            Me.btnGetDataCustomerModel.Text = "GET DATA BY CUSTOMER AND MODEL"
            '
            'btnClear
            '
            Me.btnClear.BackgroundImage = CType(resources.GetObject("btnClear.BackgroundImage"), System.Drawing.Bitmap)
            Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnClear.Location = New System.Drawing.Point(8, 296)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(232, 24)
            Me.btnClear.TabIndex = 0
            Me.btnClear.Text = "CLEAR DATA"
            '
            'gbDeviceType
            '
            Me.gbDeviceType.BackColor = System.Drawing.Color.Transparent
            Me.gbDeviceType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbGPS, Me.rbCell, Me.rbMSG})
            Me.gbDeviceType.Location = New System.Drawing.Point(8, 176)
            Me.gbDeviceType.Name = "gbDeviceType"
            Me.gbDeviceType.Size = New System.Drawing.Size(232, 48)
            Me.gbDeviceType.TabIndex = 8
            Me.gbDeviceType.TabStop = False
            Me.gbDeviceType.Text = "DEVICE TYPE"
            '
            'rbGPS
            '
            Me.rbGPS.Location = New System.Drawing.Point(176, 24)
            Me.rbGPS.Name = "rbGPS"
            Me.rbGPS.Size = New System.Drawing.Size(46, 16)
            Me.rbGPS.TabIndex = 2
            Me.rbGPS.Text = "GPS"
            '
            'rbCell
            '
            Me.rbCell.Location = New System.Drawing.Point(96, 24)
            Me.rbCell.Name = "rbCell"
            Me.rbCell.Size = New System.Drawing.Size(84, 16)
            Me.rbCell.TabIndex = 1
            Me.rbCell.Text = "CELLULAR"
            '
            'rbMSG
            '
            Me.rbMSG.Location = New System.Drawing.Point(8, 24)
            Me.rbMSG.Name = "rbMSG"
            Me.rbMSG.Size = New System.Drawing.Size(96, 16)
            Me.rbMSG.TabIndex = 0
            Me.rbMSG.Text = "MESSAGING"
            '
            'frmBillcodeConsumption
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
            Me.ClientSize = New System.Drawing.Size(680, 333)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbDeviceType, Me.btnClear, Me.cboModel, Me.Label2, Me.cboCustomer, Me.Label1, Me.btnGetDataModel, Me.btnGetDataCustomer, Me.lblDCdetail, Me.lblDC, Me.btnGetData, Me.MainGrid, Me.cboBillcode, Me.dtpEnd, Me.dtpStart, Me.lblEndDate, Me.lblStartDate, Me.lblBillcode, Me.btnGetDataCustomerModel})
            Me.Name = "frmBillcodeConsumption"
            Me.Text = "INDIVIDUAL BILLCODE ANALYSIS"
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbDeviceType.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmBillcodeConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            rbCell.Checked = True
            loadBillcodes()
            loadCustomers()
            loadModels()
            Me.dtpStart.Value = Now
            Me.dtpEnd.Value = Now
            cboBillcode.Focus()
            System.Windows.Forms.Application.DoEvents()
            hideDC()
            cboBillcode.SelectedValue = -1
            cboCustomer.SelectedValue = -1
            cboModel.SelectedValue = -1
        End Sub

        Private Sub loadBillcodes()

            Dim iProd As Integer
            If rbMSG.Checked = True Then iProd = 1
            If rbCell.Checked = True Then iProd = 2
            If rbGPS.Checked = True Then iProd = 6

            'strSQL = "SELECT Billcode_ID, Billcode_Desc FROM lbillcodes WHERE Billcode_Rule = 0 and Device_ID = " & iProd & " ORDER BY lbillcodes.billcode_Desc"
            strSQL = "SELECT Billcode_ID, Billcode_Desc FROM lbillcodes WHERE Device_ID = " & iProd & " ORDER BY lbillcodes.billcode_Desc"
            dt = ds.OrderEntrySelect(strSQL)
            cboBillcode.DataSource = dt
            cboBillcode.DisplayMember = dt.Columns("Billcode_Desc").ToString
            cboBillcode.ValueMember = dt.Columns("Billcode_ID").ToString
            cboBillcode.Text = ""
        End Sub

        Private Sub loadCustomers()
            strSQL = "SELECT Cust_ID, Cust_Name1 FROM tcustomer WHERE cust_name2 is null and cust_inactive = 0 ORDER BY Cust_Name1"
            dt = ds.OrderEntrySelect(strSQL)
            cboCustomer.DataSource = dt
            cboCustomer.DisplayMember = dt.Columns("Cust_Name1").ToString
            cboCustomer.ValueMember = dt.Columns("Cust_ID").ToString
            cboCustomer.Text = ""
        End Sub

        Private Sub loadModels()

            Dim iProd As Integer
            If rbMSG.Checked = True Then iProd = 1
            If rbCell.Checked = True Then iProd = 2
            If rbGPS.Checked = True Then iProd = 6

            strSQL = "SELECT Model_ID, Model_Desc FROM tmodel WHERE prod_id = " & iProd & " ORDER BY Model_Desc"
            dt = ds.OrderEntrySelect(strSQL)
            cboModel.DataSource = dt
            cboModel.DisplayMember = dt.Columns("Model_Desc").ToString
            cboModel.ValueMember = dt.Columns("Model_ID").ToString
            cboModel.Text = ""
        End Sub

        Private Sub getData()

            If Len(Trim(cboBillcode.Text)) < 1 Or Len(Trim(dtpStart.Text)) < 1 Or Len(Trim(dtpEnd.Text)) < 1 Then
                MsgBox("There must be data selected for Billcode, Start Date, and End Date.", MsgBoxStyle.OKOnly, "NEED DATA")
                Exit Sub
            End If

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim dStart, dEND As String
            dStart = Format(dtpStart.Value, "yyyy-MM-dd")
            dEND = Format(dtpEnd.Value, "yyyy-MM-dd")

            strSQL = "SELECT workdate as DATE, SUM(Trans_Amount) as COUNT FROM tparttransaction WHERE workdate >= '" & dStart & "' AND workdate <= '" & dEND & "' AND billcode_ID = " & cboBillcode.SelectedValue & " AND New in (1,2) GROUP BY workdate ORDER BY workdate"
            dt = ds.OrderEntrySelect(strSQL)
            MainGrid.DataSource = dt

            Dim mTotal As Long = 0
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                mTotal += r("COUNT")
            Next
            lblDCdetail.Text = mTotal
            showDC()
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub getDataByCustomerModel()

            If Len(Trim(cboBillcode.Text)) < 1 Or Len(Trim(dtpStart.Text)) < 1 Or Len(Trim(dtpEnd.Text)) < 1 Then
                MsgBox("There must be data selected for Billcode, Start Date, and End Date.", MsgBoxStyle.OKOnly, "NEED DATA")
                Exit Sub
            End If

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim dStart, dEND As String
            dStart = Format(dtpStart.Value, "yyyy-MM-dd") & " 06:00:00'"
            dEND = Format(DateAdd(DateInterval.Day, 1, dtpEnd.Value), "yyyy-MM-dd") & " 05:59:59"

            If cboModel.Text = "" And cboCustomer.Text <> "" Then
                strSQL = "SELECT workdate as DATE, tcustomer.Cust_Name1 as CUSTOMER, tmodel.Model_Desc as MODEL, SUM(Trans_Amount) as COUNT FROM tparttransaction INNER JOIN tdevice ON tparttransaction.Device_ID = tdevice.Device_ID INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID WHERE Date_Server >= '" & dStart & "' AND Date_Server <= '" & dEND & "' AND billcode_ID = " & cboBillcode.SelectedValue & " AND tcustomer.Cust_ID = " & cboCustomer.SelectedValue & "  AND New in (1,2) GROUP BY workdate, tcustomer.Cust_ID, tmodel.model_id ORDER BY workdate, tcustomer.cust_name1, tmodel.model_desc"
            ElseIf cboCustomer.Text = "" And cboModel.Text <> "" Then
                strSQL = "SELECT workdate as DATE, tcustomer.Cust_Name1 as CUSTOMER, tmodel.Model_Desc as MODEL, SUM(Trans_Amount) as COUNT FROM tparttransaction INNER JOIN tdevice ON tparttransaction.Device_ID = tdevice.Device_ID INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID WHERE Date_Server >= '" & dStart & "' AND Date_Server <= '" & dEND & "' AND billcode_ID = " & cboBillcode.SelectedValue & " AND tdevice.model_ID = " & cboModel.SelectedValue & " AND New in (1,2)  GROUP BY workdate, tcustomer.Cust_ID, tmodel.model_id ORDER BY workdate, tcustomer.cust_name1, tmodel.model_desc"
            ElseIf cboCustomer.Text = "" And cboModel.Text = "" Then
                strSQL = "SELECT workdate as DATE, tcustomer.Cust_Name1 as CUSTOMER, tmodel.Model_Desc as MODEL, SUM(Trans_Amount) as COUNT FROM tparttransaction INNER JOIN tdevice ON tparttransaction.Device_ID = tdevice.Device_ID INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID WHERE Date_Server >= '" & dStart & "' AND Date_Server <= '" & dEND & "' AND billcode_ID = " & cboBillcode.SelectedValue & " AND New in (1,2) GROUP BY workdate, tcustomer.Cust_ID, tmodel.model_id ORDER BY tcustomer.cust_name1, tmodel.model_desc"
            Else
                strSQL = "SELECT workdate as DATE, tcustomer.Cust_Name1 as CUSTOMER, tmodel.Model_Desc as MODEL, SUM(Trans_Amount) as COUNT FROM tparttransaction INNER JOIN tdevice ON tparttransaction.Device_ID = tdevice.Device_ID INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID INNER JOIN tmodel ON tdevice.Model_ID = tmodel.Model_ID WHERE Date_Server >= '" & dStart & "' AND Date_Server <= '" & dEND & "' AND billcode_ID = " & cboBillcode.SelectedValue & " AND tcustomer.Cust_ID = " & cboCustomer.SelectedValue & " AND tdevice.model_ID = " & cboModel.SelectedValue & " AND New in (1,2) GROUP BY workdate, tcustomer.Cust_ID, tmodel.model_id ORDER BY workdate, tcustomer.cust_name1, tmodel.model_desc"
            End If
            dt = ds.OrderEntrySelect(strSQL)
            MainGrid.DataSource = dt

            Dim mTotal As Long = 0
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                mTotal += r("COUNT")
            Next
            lblDCdetail.Text = mTotal
            showDC()
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub getDataByCustomer()

            If Len(Trim(cboBillcode.Text)) < 1 Or Len(Trim(dtpStart.Text)) < 1 Or Len(Trim(dtpEnd.Text)) < 1 Then
                MsgBox("There must be data selected for Billcode, Start Date, and End Date.", MsgBoxStyle.OKOnly, "NEED DATA")
                Exit Sub
            End If

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim dStart, dEND As String
            dStart = Format(dtpStart.Value, "yyyy-MM-dd")
            dEND = Format(dtpEnd.Value, "yyyy-MM-dd")

            If cboCustomer.Text = "" Then
                MsgBox("Please select a customer to run this function.", MsgBoxStyle.OKOnly, "Need Data")
                cboCustomer.Focus()
                Exit Sub
            Else
                strSQL = "SELECT workdate as DATE, tcustomer.Cust_Name1 as CUSTOMER, SUM(Trans_Amount) as COUNT FROM tparttransaction INNER JOIN tdevice ON tparttransaction.Device_ID = tdevice.Device_ID INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id INNER JOIN tcustomer ON tlocation.Cust_ID = tcustomer.Cust_ID WHERE Date_Server >= '" & dStart & "' AND Date_Server <= '" & dEND & "' AND billcode_ID = " & cboBillcode.SelectedValue & " AND tcustomer.Cust_ID = " & cboCustomer.SelectedValue & " AND New in (1,2) GROUP BY workdate, tcustomer.Cust_ID ORDER BY workdate, cust_name1"
            End If
            dt = ds.OrderEntrySelect(strSQL)
            MainGrid.DataSource = dt

            Dim mTotal As Long = 0
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                mTotal += r("COUNT")
            Next
            lblDCdetail.Text = mTotal
            showDC()
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub getDataByModel()

            If Len(Trim(cboBillcode.Text)) < 1 Or Len(Trim(dtpStart.Text)) < 1 Or Len(Trim(dtpEnd.Text)) < 1 Then
                MsgBox("There must be data selected for Billcode, Start Date, and End Date.", MsgBoxStyle.OKOnly, "NEED DATA")
                Exit Sub
            End If

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim dStart, dEND As String
            dStart = Format(dtpStart.Value, "yyyy-MM-dd")
            dEND = Format(dtpEnd.Value, "yyyy-MM-dd")
            If cboModel.Text = "" Then
                MsgBox("Please select a model to run this function.", MsgBoxStyle.OKOnly, "Need Data")
                cboModel.Focus()
                Exit Sub
            Else
                strSQL = "SELECT workdate as DATE, tmodel.Model_Desc as MODEL, SUM(Trans_Amount) as COUNT FROM tparttransaction INNER JOIN tdevice ON tparttransaction.Device_ID = tdevice.Device_ID INNER JOIN tmodel ON tdevice.model_id = tmodel.model_id WHERE Date_Server >= '" & dStart & "' AND Date_Server <= '" & dEND & "' AND billcode_ID = " & cboBillcode.SelectedValue & " AND tdevice.model_id = " & cboModel.SelectedValue & " AND New in (1,2) GROUP BY workdate, tmodel.Model_ID ORDER BY workdate, Model_Desc"
            End If
            dt = ds.OrderEntrySelect(strSQL)
            MainGrid.DataSource = dt

            Dim mTotal As Long = 0
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(xCount)
                mTotal += r("COUNT")
            Next
            lblDCdetail.Text = mTotal
            showDC()
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub btnGetData_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetData.Click
            getData()
        End Sub

        Private Sub clearValues()
            cboBillcode.Text = ""
            cboBillcode.SelectedValue = -1
            cboCustomer.Text = ""
            cboCustomer.SelectedValue = -1
            cboModel.Text = ""
            cboModel.SelectedValue = -1
            hideDC()
        End Sub

        Private Sub hideDC()
            lblDC.Visible = False
            lblDCdetail.Visible = False
            MainGrid.ClearFields()
        End Sub

        Private Sub showDC()
            lblDC.Visible = True
            lblDCdetail.Visible = True
        End Sub

        Private Sub dtpStart_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpStart.ValueChanged
            hideDC()
        End Sub

        Private Sub dtpEnd_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpEnd.ValueChanged
            hideDC()
        End Sub

        Private Sub cboModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted
            hideDC()
        End Sub

        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted
            hideDC()
        End Sub

        Private Sub btnGetDataCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDataCustomer.Click
            getDataByCustomer()
        End Sub

        Private Sub btnGetDataModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDataModel.Click
            getDataByModel()
        End Sub

        Private Sub btnGetDataCustomerModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetDataCustomerModel.Click
            getDataByCustomerModel()
        End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            Me.clearValues()
            cboBillcode.Focus()
        End Sub

        Private Sub cboBillcode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillcode.Leave
            cboCustomer.Text = ""
            cboCustomer.SelectedValue = -1
            cboModel.Text = ""
            cboModel.SelectedValue = -1
            hideDC()
        End Sub

        Private Sub rbMSG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMSG.CheckedChanged
            loadModels()
            loadBillcodes()
        End Sub

        Private Sub rbCell_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCell.CheckedChanged
            loadModels()
            loadBillcodes()
        End Sub

        Private Sub rbGPS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGPS.CheckedChanged
            loadModels()
            loadBillcodes()
        End Sub

    End Class

End Namespace
