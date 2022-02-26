Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Core
Imports PSS.Data

Imports System
Imports System.GC
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports PSS.Rules
Imports PSS.Core.[Global]


Namespace Gui.Receiving

    Public Class frmTrayTransfer
        Inherits System.Windows.Forms.Form


        Private valWOID As Int32
        Private valLocID As Int32
        Private valCustID As Int32
        Private valTray As Int32
        Private arrDeviceSN(1000) As String
        Private arrCount As Integer
        Private TmpDevice As DataTable
        Private valUser As String

        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing


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
        Friend WithEvents lblScanTray As System.Windows.Forms.Label
        Friend WithEvents txtScanTrayValue As System.Windows.Forms.TextBox
        Friend WithEvents grpData As System.Windows.Forms.GroupBox
        Friend WithEvents valCustomerReason As System.Windows.Forms.Label
        Friend WithEvents valModel As System.Windows.Forms.Label
        Friend WithEvents valManufacturer As System.Windows.Forms.Label
        Friend WithEvents valWorkOrder As System.Windows.Forms.Label
        Friend WithEvents valAddress As System.Windows.Forms.Label
        Friend WithEvents valCustomer As System.Windows.Forms.Label
        Friend WithEvents lblCustomerReason As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents lblWOMemo As System.Windows.Forms.Label
        Friend WithEvents lblWorkOrder As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblScanDevice As System.Windows.Forms.Label
        Friend WithEvents txtScanDevice As System.Windows.Forms.TextBox
        Friend WithEvents lblCounter As System.Windows.Forms.Label
        Friend WithEvents lblNewTrayNumber As System.Windows.Forms.Label
        Friend WithEvents NewTrayNumberVAL As System.Windows.Forms.Label
        Friend WithEvents btnReport As System.Windows.Forms.Button
        Friend WithEvents txtCounter As System.Windows.Forms.TextBox
        Friend WithEvents DeviceGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents valAddress2 As System.Windows.Forms.Label
        Friend WithEvents valCityStateZip As System.Windows.Forms.Label
        Friend WithEvents valWOMemo As System.Windows.Forms.Label
        Friend WithEvents btnClose As System.Windows.Forms.Button
        Friend WithEvents btnObsolete As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTrayTransfer))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblScanTray = New System.Windows.Forms.Label()
            Me.txtScanTrayValue = New System.Windows.Forms.TextBox()
            Me.grpData = New System.Windows.Forms.GroupBox()
            Me.valWOMemo = New System.Windows.Forms.Label()
            Me.valCityStateZip = New System.Windows.Forms.Label()
            Me.valAddress2 = New System.Windows.Forms.Label()
            Me.valCustomerReason = New System.Windows.Forms.Label()
            Me.valModel = New System.Windows.Forms.Label()
            Me.valManufacturer = New System.Windows.Forms.Label()
            Me.valWorkOrder = New System.Windows.Forms.Label()
            Me.valAddress = New System.Windows.Forms.Label()
            Me.valCustomer = New System.Windows.Forms.Label()
            Me.lblCustomerReason = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            Me.lblWOMemo = New System.Windows.Forms.Label()
            Me.lblWorkOrder = New System.Windows.Forms.Label()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblScanDevice = New System.Windows.Forms.Label()
            Me.txtScanDevice = New System.Windows.Forms.TextBox()
            Me.lblCounter = New System.Windows.Forms.Label()
            Me.lblNewTrayNumber = New System.Windows.Forms.Label()
            Me.NewTrayNumberVAL = New System.Windows.Forms.Label()
            Me.DeviceGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReport = New System.Windows.Forms.Button()
            Me.txtCounter = New System.Windows.Forms.TextBox()
            Me.btnClose = New System.Windows.Forms.Button()
            Me.btnObsolete = New System.Windows.Forms.Button()
            Me.grpData.SuspendLayout()
            CType(Me.DeviceGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblScanTray
            '
            Me.lblScanTray.Location = New System.Drawing.Point(288, 8)
            Me.lblScanTray.Name = "lblScanTray"
            Me.lblScanTray.Size = New System.Drawing.Size(96, 16)
            Me.lblScanTray.TabIndex = 0
            Me.lblScanTray.Text = "Scan Tray"
            Me.lblScanTray.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtScanTrayValue
            '
            Me.txtScanTrayValue.Location = New System.Drawing.Point(288, 24)
            Me.txtScanTrayValue.Name = "txtScanTrayValue"
            Me.txtScanTrayValue.TabIndex = 1
            Me.txtScanTrayValue.Text = ""
            Me.txtScanTrayValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'grpData
            '
            Me.grpData.Controls.AddRange(New System.Windows.Forms.Control() {Me.valWOMemo, Me.valCityStateZip, Me.valAddress2, Me.valCustomerReason, Me.valModel, Me.valManufacturer, Me.valWorkOrder, Me.valAddress, Me.valCustomer, Me.lblCustomerReason, Me.lblModel, Me.lblManufacturer, Me.lblWOMemo, Me.lblWorkOrder, Me.lblAddress, Me.lblCustomer})
            Me.grpData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.grpData.Location = New System.Drawing.Point(8, 16)
            Me.grpData.Name = "grpData"
            Me.grpData.Size = New System.Drawing.Size(272, 264)
            Me.grpData.TabIndex = 16
            Me.grpData.TabStop = False
            '
            'valWOMemo
            '
            Me.valWOMemo.Location = New System.Drawing.Point(120, 168)
            Me.valWOMemo.Name = "valWOMemo"
            Me.valWOMemo.Size = New System.Drawing.Size(144, 80)
            Me.valWOMemo.TabIndex = 33
            '
            'valCityStateZip
            '
            Me.valCityStateZip.Location = New System.Drawing.Point(120, 72)
            Me.valCityStateZip.Name = "valCityStateZip"
            Me.valCityStateZip.Size = New System.Drawing.Size(144, 16)
            Me.valCityStateZip.TabIndex = 31
            '
            'valAddress2
            '
            Me.valAddress2.Location = New System.Drawing.Point(120, 56)
            Me.valAddress2.Name = "valAddress2"
            Me.valAddress2.Size = New System.Drawing.Size(144, 16)
            Me.valAddress2.TabIndex = 30
            '
            'valCustomerReason
            '
            Me.valCustomerReason.Location = New System.Drawing.Point(120, 152)
            Me.valCustomerReason.Name = "valCustomerReason"
            Me.valCustomerReason.Size = New System.Drawing.Size(144, 16)
            Me.valCustomerReason.TabIndex = 29
            '
            'valModel
            '
            Me.valModel.Location = New System.Drawing.Point(120, 136)
            Me.valModel.Name = "valModel"
            Me.valModel.Size = New System.Drawing.Size(144, 16)
            Me.valModel.TabIndex = 28
            '
            'valManufacturer
            '
            Me.valManufacturer.Location = New System.Drawing.Point(120, 120)
            Me.valManufacturer.Name = "valManufacturer"
            Me.valManufacturer.Size = New System.Drawing.Size(144, 16)
            Me.valManufacturer.TabIndex = 27
            '
            'valWorkOrder
            '
            Me.valWorkOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.valWorkOrder.Location = New System.Drawing.Point(120, 104)
            Me.valWorkOrder.Name = "valWorkOrder"
            Me.valWorkOrder.Size = New System.Drawing.Size(144, 16)
            Me.valWorkOrder.TabIndex = 25
            '
            'valAddress
            '
            Me.valAddress.Location = New System.Drawing.Point(120, 40)
            Me.valAddress.Name = "valAddress"
            Me.valAddress.Size = New System.Drawing.Size(144, 16)
            Me.valAddress.TabIndex = 24
            '
            'valCustomer
            '
            Me.valCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.valCustomer.Location = New System.Drawing.Point(120, 16)
            Me.valCustomer.Name = "valCustomer"
            Me.valCustomer.Size = New System.Drawing.Size(144, 16)
            Me.valCustomer.TabIndex = 23
            '
            'lblCustomerReason
            '
            Me.lblCustomerReason.Location = New System.Drawing.Point(16, 152)
            Me.lblCustomerReason.Name = "lblCustomerReason"
            Me.lblCustomerReason.Size = New System.Drawing.Size(104, 16)
            Me.lblCustomerReason.TabIndex = 22
            Me.lblCustomerReason.Text = "Customer Reason:"
            Me.lblCustomerReason.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(16, 136)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(100, 16)
            Me.lblModel.TabIndex = 21
            Me.lblModel.Text = "Model:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblManufacturer
            '
            Me.lblManufacturer.Location = New System.Drawing.Point(16, 120)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(100, 16)
            Me.lblManufacturer.TabIndex = 20
            Me.lblManufacturer.Text = "Manufacturer:"
            Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWOMemo
            '
            Me.lblWOMemo.Location = New System.Drawing.Point(16, 168)
            Me.lblWOMemo.Name = "lblWOMemo"
            Me.lblWOMemo.Size = New System.Drawing.Size(104, 16)
            Me.lblWOMemo.TabIndex = 19
            Me.lblWOMemo.Text = "WorkOrder Memo:"
            Me.lblWOMemo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblWorkOrder
            '
            Me.lblWorkOrder.Location = New System.Drawing.Point(16, 104)
            Me.lblWorkOrder.Name = "lblWorkOrder"
            Me.lblWorkOrder.Size = New System.Drawing.Size(100, 16)
            Me.lblWorkOrder.TabIndex = 18
            Me.lblWorkOrder.Text = "WorkOrder:"
            Me.lblWorkOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress
            '
            Me.lblAddress.Location = New System.Drawing.Point(56, 40)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(64, 16)
            Me.lblAddress.TabIndex = 17
            Me.lblAddress.Text = "Address:"
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(24, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(100, 16)
            Me.lblCustomer.TabIndex = 16
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblScanDevice
            '
            Me.lblScanDevice.Location = New System.Drawing.Point(288, 56)
            Me.lblScanDevice.Name = "lblScanDevice"
            Me.lblScanDevice.Size = New System.Drawing.Size(96, 16)
            Me.lblScanDevice.TabIndex = 17
            Me.lblScanDevice.Text = "Scan Device"
            Me.lblScanDevice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtScanDevice
            '
            Me.txtScanDevice.Location = New System.Drawing.Point(288, 72)
            Me.txtScanDevice.Name = "txtScanDevice"
            Me.txtScanDevice.TabIndex = 18
            Me.txtScanDevice.Text = ""
            Me.txtScanDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblCounter
            '
            Me.lblCounter.Location = New System.Drawing.Point(296, 104)
            Me.lblCounter.Name = "lblCounter"
            Me.lblCounter.Size = New System.Drawing.Size(80, 16)
            Me.lblCounter.TabIndex = 19
            Me.lblCounter.Text = "Counter"
            Me.lblCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblNewTrayNumber
            '
            Me.lblNewTrayNumber.Location = New System.Drawing.Point(416, 8)
            Me.lblNewTrayNumber.Name = "lblNewTrayNumber"
            Me.lblNewTrayNumber.Size = New System.Drawing.Size(112, 16)
            Me.lblNewTrayNumber.TabIndex = 21
            Me.lblNewTrayNumber.Text = "New Tray Number:"
            Me.lblNewTrayNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'NewTrayNumberVAL
            '
            Me.NewTrayNumberVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.NewTrayNumberVAL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.NewTrayNumberVAL.Location = New System.Drawing.Point(408, 24)
            Me.NewTrayNumberVAL.Name = "NewTrayNumberVAL"
            Me.NewTrayNumberVAL.Size = New System.Drawing.Size(120, 16)
            Me.NewTrayNumberVAL.TabIndex = 22
            Me.NewTrayNumberVAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'DeviceGrid
            '
            Me.DeviceGrid.AllowDelete = True
            Me.DeviceGrid.AllowFilter = True
            Me.DeviceGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.DeviceGrid.AllowSort = True
            Me.DeviceGrid.AllowUpdate = False
            Me.DeviceGrid.Caption = "Devices"
            Me.DeviceGrid.CaptionHeight = 17
            Me.DeviceGrid.CollapseColor = System.Drawing.Color.Black
            Me.DeviceGrid.DataChanged = False
            Me.DeviceGrid.BackColor = System.Drawing.Color.Empty
            Me.DeviceGrid.ExpandColor = System.Drawing.Color.Black
            Me.DeviceGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.DeviceGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.DeviceGrid.Location = New System.Drawing.Point(408, 48)
            Me.DeviceGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.DeviceGrid.Name = "DeviceGrid"
            Me.DeviceGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.DeviceGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.DeviceGrid.PreviewInfo.ZoomFactor = 75
            Me.DeviceGrid.PrintInfo.ShowOptionsDialog = False
            Me.DeviceGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.DeviceGrid.RowDivider = GridLines1
            Me.DeviceGrid.RowHeight = 15
            Me.DeviceGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.DeviceGrid.ScrollTips = False
            Me.DeviceGrid.Size = New System.Drawing.Size(120, 232)
            Me.DeviceGrid.TabIndex = 23
            Me.DeviceGrid.Text = "C1TrueDBGrid1"
            Me.DeviceGrid.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Level=""0"" Caption=""Device Seri" & _
            "al Number"" DataField=""""><ValueItems /></C1DataColumn></DataCols><Styles type=""C1" & _
            ".Win.C1TrueDBGrid.Design.ContextWrapper""><Data>Group{BackColor:ControlDark;Borde" & _
            "r:None,,0, 0, 0, 0;AlignVert:Center;}Editor{}Style2{}Style5{}Style4{}Style7{}Sty" & _
            "le6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:HighlightText;BackColor:Highligh" & _
            "t;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}Fil" & _
            "terBar{}Footer{}Caption{AlignHorz:Center;}Style9{}Normal{}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style14{AlignHorz:Near;}OddRow{}RecordSelect" & _
            "or{AlignImage:Center;}Style15{AlignHorz:Near;}Heading{Wrap:True;AlignVert:Center" & _
            ";Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Styl" & _
            "e10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}Style1{}</Data>" & _
            "</Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" Colum" & _
            "nCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" Reco" & _
            "rdSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrol" & _
            "lGroup=""1""><ClientRect>0, 17, 116, 211</ClientRect><BorderSide>0</BorderSide><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><HeadingSt" & _
            "yle parent=""Style2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" /><Footer" & _
            "Style parent=""Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""Style17"" /" & _
            "><Visible>True</Visible><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15" & _
            "</Height><DCIdx>0</DCIdx></C1DisplayColumn></internalCols></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSel" & _
            "Width>16</DefaultRecSelWidth><ClientArea>0, 0, 116, 228</ClientArea></Blob>"
            '
            'btnReport
            '
            Me.btnReport.Location = New System.Drawing.Point(296, 224)
            Me.btnReport.Name = "btnReport"
            Me.btnReport.Size = New System.Drawing.Size(80, 24)
            Me.btnReport.TabIndex = 24
            Me.btnReport.Text = "Report"
            '
            'txtCounter
            '
            Me.txtCounter.BackColor = System.Drawing.SystemColors.Window
            Me.txtCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCounter.Location = New System.Drawing.Point(296, 120)
            Me.txtCounter.Name = "txtCounter"
            Me.txtCounter.ReadOnly = True
            Me.txtCounter.Size = New System.Drawing.Size(80, 83)
            Me.txtCounter.TabIndex = 25
            Me.txtCounter.Text = "0"
            Me.txtCounter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'btnClose
            '
            Me.btnClose.Location = New System.Drawing.Point(296, 256)
            Me.btnClose.Name = "btnClose"
            Me.btnClose.Size = New System.Drawing.Size(80, 24)
            Me.btnClose.TabIndex = 26
            Me.btnClose.Text = "Close"
            '
            'btnObsolete
            '
            Me.btnObsolete.Location = New System.Drawing.Point(536, 232)
            Me.btnObsolete.Name = "btnObsolete"
            Me.btnObsolete.Size = New System.Drawing.Size(75, 40)
            Me.btnObsolete.TabIndex = 27
            Me.btnObsolete.Text = "Obsolete new tray"
            '
            'frmTrayTransfer
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(626, 285)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnObsolete, Me.btnClose, Me.txtCounter, Me.btnReport, Me.DeviceGrid, Me.NewTrayNumberVAL, Me.lblNewTrayNumber, Me.lblCounter, Me.txtScanDevice, Me.lblScanDevice, Me.grpData, Me.txtScanTrayValue, Me.lblScanTray})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmTrayTransfer"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Transfer Device(s) to New Tray"
            Me.grpData.ResumeLayout(False)
            CType(Me.DeviceGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub incrementCounter()

            Dim valCounter As Integer

            valCounter = CInt(txtCounter.Text) + 1
            txtCounter.Text = valCounter

        End Sub

        Private Sub decrementCounter()

            Dim valCounter As Integer

            valCounter = CInt(txtCounter.Text) - 1
            txtCounter.Text = valCounter

        End Sub

        Private Sub LockUnlockForm()

            If Len(txtScanTrayValue.Text) > 0 Then
                If Len(NewTrayNumberVAL.Text) > 0 Then  'LOCK TRAY
                    txtScanTrayValue.ReadOnly = True
                    'txtScanTrayNumberVAL will be released once the report is printed.
                End If
            Else
                txtScanTrayValue.ReadOnly = False
            End If

        End Sub

        Private Sub getFormData()

            Dim drTray As DataRow
            Dim drWO As DataRow
            Dim drLoc As DataRow
            Dim drCust As DataRow

            Try
                valTray = CInt(txtScanTrayValue.Text)
                'get first record for workorder id
                Dim dtTray As DataTable = getTrayInfo(valTray)
                drTray = dtTray.Rows(0)
                valWOID = drTray("WO_ID")
                'get first record for location id
                Dim dtWO As DataTable = getWOInfo(valWOID)
                drWO = dtWO.Rows(0)
                valLocID = drWO("Loc_ID")
                'get first record for customer id
                Dim dtLoc As DataTable = getLocInfo(valLocID)
                drLoc = dtLoc.Rows(0)
                valCustID = drLoc("Cust_ID")
                Dim dtCust As DataTable = getCustInfo(valCustID)
                drCust = dtCust.Rows(0)

                'Acquire the data for the form.
                If IsDBNull(drWO("WO_ID")) = False Then valWorkOrder.Text = drWO("WO_ID")
                If IsDBNull(drWO("WO_Memo")) = False Then valWOMemo.Text = drWO("wo_Memo")
                If IsDBNull(drLoc("Loc_Address1")) = False Then valAddress.Text = drLoc("Loc_Address1")
                If IsDBNull(drLoc("Loc_Address2")) = False Then valAddress2.Text = drLoc("Loc_Address2")
                Dim valState As String = getStateName(drLoc("State_ID"))

                Dim cityStateZip As String
                If IsDBNull(drLoc("Loc_City")) = False Then
                    cityStateZip += drLoc("Loc_City") & ", "
                End If
                If Len(valState) > 0 Then
                    cityStateZip += valState & "  "
                End If
                If IsDBNull(drLoc("Loc_Zip")) = False Then
                    cityStateZip += drLoc("Loc_Zip")
                End If
                If Len(cityStateZip) > 0 Then valCityStateZip.Text = cityStateZip

                Dim custName As String
                If IsDBNull(drCust("Cust_Name1")) = False Then
                    custName += drCust("Cust_Name1") & " "
                End If
                If IsDBNull(("Cust_Name2")) = False Then
                    custName += drCust("Cust_Name2")
                End If
                If Len(custName) > 0 Then valCustomer.Text = custName

                dtTray.Dispose()
                dtTray = Nothing
                dtWO.Dispose()
                dtWO = Nothing
                dtLoc.Dispose()
                dtLoc = Nothing
                dtCust.Dispose()
                dtCust = Nothing

            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally

                drTray = Nothing
                drWO = Nothing
                drLoc = Nothing
                drCust = Nothing

            End Try

        End Sub

        Private Function getTrayInfo(ByVal valTrayID As Int32) As DataTable

            Dim dTray As New PSS.Data.Production.Joins()
            Dim strSQL As String = "Select * from ttray where tray_ID = " & valTrayID

            Try
                getTrayInfo = dTray.GenericSelect(strSQL)
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function getWOInfo(ByVal valWOID As Int32) As DataTable

            Dim dWO As New PSS.Data.Production.Joins()
            Dim strSQL As String = "Select * from tworkorder where WO_ID = " & valWOID

            Try
                getWOInfo = dWO.GenericSelect(strSQL)
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try


        End Function

        Private Function getLocInfo(ByVal valLocID As Int32) As DataTable

            Dim dLoc As New PSS.Data.Production.Joins()
            Dim strSQL As String = "Select * from tlocation where Loc_ID = " & valLocID

            Try
                getLocInfo = dLoc.GenericSelect(strSQL)
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function getCustInfo(ByVal valCustID As Int32) As DataTable

            Dim dCust As New PSS.Data.Production.Joins()
            Dim strSQL As String = "Select * from tcustomer where Cust_ID = " & valCustID

            Try
                getCustInfo = dCust.GenericSelect(strSQL)
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function getNewTrayNumber() As Boolean

            Dim newDate As String = FormatDate(Now)
            Dim tblTray As New PSS.Data.Production.ttray()
            Dim valDate As String = FormatDate(Now)
            Dim strSQL As String = "Insert into ttray (Tray_RecUser, WO_ID) VALUES ('" & valUser & "'," & valWOID & ");"
            Dim intTray As Int32 = tblTray.idTransaction(strSQL)

            NewTrayNumberVAL.Text = intTray

            getNewTrayNumber = False
            If intTray > 0 Then
                If NewTrayNumberVAL.Text = intTray Then
                    getNewTrayNumber = True
                Else
                    getNewTrayNumber = False
                End If
            End If

        End Function

        Private Function FormatDate(ByVal valDate As Date) As String

            Dim vMnth As String
            Dim vDay As String
            Dim vYear As String
            Dim startDate As Date
            startDate = valDate
            vMnth = DatePart(DateInterval.Month, startDate)
            vDay = DatePart(DateInterval.Day, startDate)
            If Len(vDay) < 2 Then vDay = "0" & vDay
            If Len(vMnth) < 2 Then vMnth = "0" & vMnth
            vYear = DatePart(DateInterval.Year, startDate)
            Dim newDate As String
            newDate = vYear & "-" & vMnth & "-" & vDay & " 01:01:01"

        End Function

        Private Function VerifyTrayHasDevices(ByVal valTrayID As Int32) As Boolean

            Dim dTrayV As New PSS.Data.Production.Joins()
            Dim strSQL As String = "Select * from tdevice where Tray_ID = " & valTrayID
            Dim dtTrayV As DataTable = dTrayV.GenericSelect(strSQL)
            Dim deviceCount As Integer = dtTrayV.Rows.Count

            If deviceCount > 0 Then
                VerifyTrayHasDevices = True

                'Create an array of valid device serial numbers
                Dim rTray As DataRow
                Dim xCount As Integer = 0
                For xCount = 0 To dtTrayV.Rows.Count - 1
                    rTray = dtTrayV.Rows(xCount)
                    arrDeviceSN(xCount) = rTray("Device_SN")
                Next
                arrCount = xCount
                TmpDevice = CreateTmpDevice()
            Else
                VerifyTrayHasDevices = False
            End If

            dtTrayV.Dispose()
            dtTrayV = Nothing
            dTrayV = Nothing

        End Function

        Private Sub ClearFormData()

            valCustomer.Text = ""
            valAddress.Text = ""
            valAddress2.Text = ""
            valCityStateZip.Text = ""
            valWorkOrder.Text = ""
            valWOMemo.Text = ""
            valManufacturer.Text = ""
            valModel.Text = ""
            valCustomerReason.Text = ""

        End Sub

        Private Function verifySNinArray(ByVal valDeviceSN As String) As Boolean

            Dim xCount As Integer = 0

            verifySNinArray = False

            If Len(valDeviceSN) < 1 Then
                MsgBox("Value can not be validated. No value passed in.")
            Else 'Continue as normal
                For xCount = 0 To arrCount - 1
                    If UCase(arrDeviceSN(xCount)) = UCase(valDeviceSN) Then
                        verifySNinArray = True
                    End If
                Next
            End If

        End Function

        Private Function getStateName(ByVal valStateID As Int32) As String

            Dim strSQL As String = "Select * from lstate where State_ID = " & valStateID
            Dim dCust As New PSS.Data.Production.Joins()

            Try
                Dim dtCust As DataTable = dCust.GenericSelect(strSQL)
                Dim rCust As DataRow
                rCust = dtCust.Rows(0)
                getStateName = rCust("State_Short")
                dtCust.Dispose()
                dtCust = Nothing
            Catch exp As Exception
                MsgBox(exp.ToString)
            Finally
            End Try

        End Function

        Private Sub txtScanTrayValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScanTrayValue.Leave

            ClearFormData()

            If Len(txtScanTrayValue.Text) < 1 Then
                txtScanTrayValue.Focus()
                Exit Sub
            End If

            Dim verTrayValid As Boolean
            verTrayValid = VerifyTrayHasDevices(txtScanTrayValue.Text)
            If verTrayValid = False Then
                MsgBox("Devices can not be transferred to new tray because there is no devices in the source tray. Please re-enter source tray.", MsgBoxStyle.OKOnly, "Error No Source Devices")
                txtScanTrayValue.Text = ""
                txtScanTrayValue.Focus()
                Exit Sub
            Else
                getFormData()
            End If

        End Sub

        Private Sub txtScanTrayValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScanTrayValue.KeyDown

            If e.KeyValue = 13 Then 'enter key has been pressed
                txtScanDevice.Focus()
            End If

        End Sub

        Private Sub frmTrayTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Highlight.SetHighLight(Me)
            Dim tmpUser As String = PSS.Core.[Global].ApplicationUser.User
            valUser = tmpUser
            txtScanTrayValue.Focus()

        End Sub

        Private Sub txtScanDevice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtScanDevice.KeyDown

            If e.KeyValue = 13 Then 'Enter key pressed

                'Verify that the device is valid for the tray
                Dim blnValidDevice As Boolean = verifySNinArray(txtScanDevice.Text)
                If blnValidDevice = True Then

                    'Check to see if device is already in datatable. If so, then do not re-input
                    Dim blnExists As Boolean
                    blnExists = False
                    If TmpDevice.Rows.Count > 0 Then
                        Dim x As Integer = 0
                        Dim drExists As DataRow
                        For x = 0 To TmpDevice.Rows.Count - 1
                            drExists = TmpDevice.Rows(x)
                            If UCase(drExists("DeviceSN")) = UCase(txtScanDevice.Text) Then
                                blnExists = True
                            End If
                        Next
                    End If
                    If blnExists = False Then

                        'Check to see if new tray value has been established if not get one
                        If Len(NewTrayNumberVAL.Text) < 1 Then 'get new tray number
                            Dim blnNewTray As Boolean = getNewTrayNumber()
                            If blnNewTray = True Then
                                'TmpDevice = CreateTmpDevice()
                                Dim dr As DataRow = TmpDevice.NewRow
                                'lock the page
                                LockUnlockForm()
                                'enter value into grid
                                dr("DeviceSN") = UCase(txtScanDevice.Text)
                                TmpDevice.Rows.Add(dr)
                                incrementCounter()
                                'move to end of DeviceGrid
                                DeviceGrid.MoveLast()

                                txtScanDevice.Text = ""
                                txtScanDevice.Focus()
                            End If
                        Else
                            'enter value into grid
                            Dim dr1 As DataRow = TmpDevice.NewRow
                            dr1("DeviceSN") = UCase(txtScanDevice.Text)
                            TmpDevice.Rows.Add(dr1)
                            incrementCounter()
                            'move to end of DeviceGrid
                            DeviceGrid.MoveLast()

                            txtScanDevice.Text = ""
                            txtScanDevice.Focus()
                        End If

                    End If

                    If blnExists = True Then
                        MsgBox("The device Serial Number has already been moved.", MsgBoxStyle.OKOnly)
                        txtScanDevice.Text = ""
                        txtScanDevice.Focus()
                    End If
                End If
                If blnValidDevice = False Then
                    MsgBox("The device Serial Number is not part of the current tray.", MsgBoxStyle.OKOnly)
                    txtScanDevice.Text = ""
                    txtScanDevice.Focus()
                End If
            End If

        End Sub

        Private Function CreateTmpDevice() As DataTable

            Dim dtDeviceTmp As New DataTable("tmpDevice")
            dtDeviceTmp.MinimumCapacity = 500
            dtDeviceTmp.CaseSensitive = False

            Dim dcDeviceSN As New DataColumn("DeviceSN")
            dtDeviceTmp.Columns.Add(dcDeviceSN)
            DeviceGrid.DataSource = dtDeviceTmp
            CreateTmpDevice = dtDeviceTmp

        End Function

        Private Sub DeviceGrid_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeviceGrid.AfterDelete

            decrementCounter()

        End Sub

        Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click

            Dim oldTrayNumber As Int32 = CInt(txtScanTrayValue.Text)
            Dim newTrayNumber As Int32 = CInt(NewTrayNumberVAL.Text)
            Dim intWOID As Int32 = CInt(valWorkOrder.Text)

            Dim strReportLoc As String = PSS.Core.ReportPath

            'Update data in database
            Dim xCount As Integer = 0
            Dim drTMP As DataRow
            Dim arrDeviceSN(100) As String

            For xCount = 0 To TmpDevice.Rows.Count - 1
                drTMP = TmpDevice.Rows(xCount)
                arrDeviceSN(xCount) = drTMP(0)
            Next

            Dim runOK As Boolean
            runOK = PSS.Data.Production.tdevice.TrayTransferUpdateData(arrDeviceSN, xCount, CInt(txtScanTrayValue.Text), CInt(NewTrayNumberVAL.Text), CInt(valWorkOrder.Text))

            If runOK = True Then
                'Clear form ALL
                ClearFormData()
                txtScanTrayValue.Text = ""
                txtScanDevice.Text = ""
                NewTrayNumberVAL.Text = ""
                TmpDevice.Clear()
                txtCounter.Text = "0"
                txtScanTrayValue.ReadOnly = False
                txtScanTrayValue.Focus()
            Else
                MsgBox("An error has occurred while updating devices to new tray.", MsgBoxStyle.OKOnly, "ERROR")
            End If

            'Perform Report
            '//Report to Print
            MainWin.StatusBar.SetStatusText("Sending Worksheet to Printer")
            Try
                '                Dim report1 As New ReportDocument()
                '                report1.Load(strReportLoc & "Rec_Worksheet.rpt", OpenReportMethod.OpenReportByTempCopy)
                '                report1.Refresh()
                '                report1.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(oldTrayNumber)
                '                report1.PrintToPrinter(2, False, 0, 0)
                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")
                Dim objRpt As ReportDocument

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Rec_Worksheet.rpt")
                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(oldTrayNumber)
                    .PrintToPrinter(2, True, 0, 0)
                    .Close()
                End With

                'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(oldTrayNumber)
                'rpt.PrintOut(False, 2)
                'rpt = Nothing

                System.Windows.Forms.Application.DoEvents()
                '                report1.Refresh()
                '                report1.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(newTrayNumber)
                '                report1.PrintToPrinter(2, False, 0, 0)
                'Dim rptApp2 As New CRAXDRT.Application()
                'Dim rpt2 As CRAXDRT.Report = rptApp2.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")

                objRpt = Nothing
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Rec_Worksheet.rpt")
                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(newTrayNumber)
                    .PrintToPrinter(2, True, 0, 0)
                    .Close()
                End With

                'rpt2.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(newTrayNumber)
                'rpt2.PrintOut(False, 2)
                'rpt2 = Nothing

                System.Windows.Forms.Application.DoEvents()
            Catch exp As Exception
                MsgBox(exp.ToString)
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
            MainWin.StatusBar.SetStatusText("")

        End Sub

        Private Sub txtScanDevice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtScanDevice.TextChanged

        End Sub

        Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click

            Dim msgResponse As Integer = 0

            Try
                If TmpDevice.Rows.Count > 0 Then
                    If Len(NewTrayNumberVAL.Text) > 0 Then
                        msgResponse = MsgBox("You have values selected for transfer. Closing now will cancel the transfer of these items. Do you want to continue?", MsgBoxStyle.YesNo, "Cancel")
                        Select Case msgResponse
                            Case 6
                                Me.Close()
                                Exit Sub
                            Case 7
                                Exit Sub
                        End Select
                    End If
                Else
                    Me.Close()
                End If
            Catch
                Me.Close()
            End Try

        End Sub


        Private Sub LoadTray(ByVal tmpTrayID As Long)

            If IsNumeric(tmpTrayID) Then
                Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(tmpTrayID)
                If Source.Rows.Count = 0 Then
                    MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")
                    _tray = Nothing
                Else
                    _tray = Source
                End If
                Source = Nothing
            Else
                MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
            End If

        End Sub
        Private Sub LoadDevice(ByVal tmpSerial As String)
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(tmpSerial) & "'")
                _device = New Device(__device(0)("Device_ID"))
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(tmpSerial) Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
            End Try
        End Sub



        Private Sub AutoBill(ByVal intBillCode As Integer)


            Dim mTray As String = Me.NewTrayNumberVAL.Text

            If Len(Trim(mTray)) < 1 Then
                Exit Sub
            End If

            Try
                _device = Nothing
                _tray = Nothing
            Catch ex As Exception
            End Try

            Me.LoadTray(mTray)

            Dim xCount As Integer = 0
            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tdevice WHERE tray_id = " & mTray)
            Dim r As DataRow

            For xCount = 0 To dt.Rows.Count - 1

                r = dt.Rows(xCount)
                Me.LoadDevice(r("Device_SN"))
                System.Windows.Forms.Application.DoEvents()

                Try
                    'Bill Part
                    _device.AddPart(intBillCode)
                    System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                If Len(Trim(mTray)) > 0 Then
                    If Len(Trim(r("Device_SN"))) > 0 Then
                        UpdateBilling()
                    End If
                End If

                Try
                    _device = Nothing
                    System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                End Try

            Next

        End Sub

        Private Sub UpdateBilling()
            Try 'here in case there is not refrence to _device
                _device.Update()
                Dim d As DataRow() = _tray.Select("Device_ID = " & _device.ID)
                If _device.Parts.Rows.Count = 0 Then
                    d(0)("Device_DateBill") = DBNull.Value
                Else
                    d(0)("Device_DateBill") = Now
                End If
                d = Nothing
                '_device.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
            Finally
            End Try
        End Sub

        Private Sub btnObsolete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObsolete.Click

            Dim oldTrayNumber As Int32 = CInt(txtScanTrayValue.Text)
            Dim newTrayNumber As Int32 = CInt(NewTrayNumberVAL.Text)
            Dim intWOID As Int32 = CInt(valWorkOrder.Text)

            Dim strReportLoc As String = PSS.Core.ReportPath

            'Update data in database
            Dim xCount As Integer = 0
            Dim drTMP As DataRow
            Dim arrDeviceSN(100) As String

            For xCount = 0 To TmpDevice.Rows.Count - 1
                drTMP = TmpDevice.Rows(xCount)
                arrDeviceSN(xCount) = drTMP(0)
            Next

            Dim runOK As Boolean
            runOK = PSS.Data.Production.tdevice.TrayTransferUpdateData(arrDeviceSN, xCount, CInt(txtScanTrayValue.Text), CInt(NewTrayNumberVAL.Text), CInt(valWorkOrder.Text))


            System.Windows.Forms.Application.DoEvents()
            '//Place the autobilling here - START
            '//This will automatically bill a DBR for all devices in the new tray.
            AutoBill(25)
            '//Place the autobilling here - END
            System.Windows.Forms.Application.DoEvents()




            If runOK = True Then
                'Clear form ALL
                ClearFormData()
                txtScanTrayValue.Text = ""
                txtScanDevice.Text = ""
                NewTrayNumberVAL.Text = ""
                TmpDevice.Clear()
                txtCounter.Text = "0"
                txtScanTrayValue.ReadOnly = False
                txtScanTrayValue.Focus()
            Else
                MsgBox("An error has occurred while updating devices to new tray.", MsgBoxStyle.OKOnly, "ERROR")
            End If

            'Perform Report
            '//Report to Print
            MainWin.StatusBar.SetStatusText("Sending Worksheet to Printer")
            Try
                '                Dim report1 As New ReportDocument()
                '                report1.Load(strReportLoc & "Rec_Worksheet.rpt", OpenReportMethod.OpenReportByTempCopy)
                '                report1.Refresh()
                '                report1.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(oldTrayNumber)
                '                report1.PrintToPrinter(2, False, 0, 0)
                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")
                Dim objRpt As ReportDocument

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Rec_Worksheet.rpt")
                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(oldTrayNumber)
                    .PrintToPrinter(2, True, 0, 0)
                    .Close()
                End With

                'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(oldTrayNumber)
                'rpt.PrintOut(False, 2)
                'rpt = Nothing

                System.Windows.Forms.Application.DoEvents()
                '                report1.Refresh()
                '                report1.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(newTrayNumber)
                '                report1.PrintToPrinter(2, False, 0, 0)
                'Dim rptApp2 As New CRAXDRT.Application()
                'Dim rpt2 As CRAXDRT.Report = rptApp2.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")

                objRpt = Nothing
                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Rec_Worksheet.rpt")
                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(newTrayNumber)
                    .PrintToPrinter(2, True, 0, 0)
                    .Close()
                End With

                'rpt2.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(newTrayNumber)
                'rpt2.PrintOut(False, 2)
                'rpt2 = Nothing

                System.Windows.Forms.Application.DoEvents()
            Catch exp As Exception
                MsgBox(exp.ToString)
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
            MainWin.StatusBar.SetStatusText("")


        End Sub
    End Class

End Namespace
