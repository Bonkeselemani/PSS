Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]
Imports System.IO

Namespace Gui.Receiving

    Public Class frm_custspecREC_CellStar
        Inherits System.Windows.Forms.Form

        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing

        Private mLaborAmount As Double

        Private ds As PSS.Data.Production.Joins
        Private mEnterpriseCode, _
                mRepairOrderNum, _
                mEnterprise, _
                mCarrier, _
                mModel, _
                mManufacturer, _
                mRejectText, _
                mWrtyDate, _
                mDeviceSn, _
                mModelDesc, _
                strSQL, _
                mHEX, _
                mSJUG, _
                mDelKey As String
        Private mItemNum, _
                iEnterprise, _
                iCarrier, _
                iModel, _
                iDeviceID, _
                iModelID, _
                iLoc, _
                billcode_id, _
                iManufacturerID, _
                iCSstatus As Long
        Private dtGridMain, _
                dataGrid, _
                dtGridMainReject, _
                dataGridReject, _
                dtPSSWrty As DataTable
        Private r As DataRow
        Private blnPSSWrty As Boolean

        'Add by Lan 11/20/2006 Assign group_id
        Private iParentGroupID As Integer = PSS.Core.[Global].ApplicationUser.GroupID

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
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblPart As System.Windows.Forms.Label
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents lblSTATUS As System.Windows.Forms.Label
        Friend WithEvents lblSTATUS_DeviceSN As System.Windows.Forms.Label
        Friend WithEvents lblSTATUS_RejectReason As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblCarrier As System.Windows.Forms.Label
        Friend WithEvents lblEnterprise As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents labelCount As System.Windows.Forms.Label
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents pnlStatus As System.Windows.Forms.Panel
        Friend WithEvents MainGridReject As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents chkOEMwrtyLabor As System.Windows.Forms.CheckBox
        Friend WithEvents chkOEMwrtyParts As System.Windows.Forms.CheckBox
        Friend WithEvents btnLoad As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnLoadDevices As System.Windows.Forms.Button
        Friend WithEvents lblVendor As System.Windows.Forms.Label
        Friend WithEvents cboVendor As System.Windows.Forms.ComboBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblModelDesc As System.Windows.Forms.Label
        Friend WithEvents lblIncoming As System.Windows.Forms.Label
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents cmdLoadXML As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frm_custspecREC_CellStar))
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblPart = New System.Windows.Forms.Label()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblCarrier = New System.Windows.Forms.Label()
            Me.lblEnterprise = New System.Windows.Forms.Label()
            Me.labelCount = New System.Windows.Forms.Label()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.pnlStatus = New System.Windows.Forms.Panel()
            Me.lblSTATUS_RejectReason = New System.Windows.Forms.Label()
            Me.lblSTATUS_DeviceSN = New System.Windows.Forms.Label()
            Me.lblSTATUS = New System.Windows.Forms.Label()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnLoadDevices = New System.Windows.Forms.Button()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.MainGridReject = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.chkOEMwrtyLabor = New System.Windows.Forms.CheckBox()
            Me.chkOEMwrtyParts = New System.Windows.Forms.CheckBox()
            Me.btnLoad = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.lblVendor = New System.Windows.Forms.Label()
            Me.cboVendor = New System.Windows.Forms.ComboBox()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblModelDesc = New System.Windows.Forms.Label()
            Me.lblIncoming = New System.Windows.Forms.Label()
            Me.Panel5 = New System.Windows.Forms.Panel()
            Me.cmdLoadXML = New System.Windows.Forms.Button()
            Me.pnlStatus.SuspendLayout()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.MainGridReject, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel5.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.ForeColor = System.Drawing.Color.White
            Me.lblCustomer.Location = New System.Drawing.Point(368, 18)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "Customer:"
            '
            'lblPart
            '
            Me.lblPart.ForeColor = System.Drawing.Color.White
            Me.lblPart.Location = New System.Drawing.Point(104, 96)
            Me.lblPart.Name = "lblPart"
            Me.lblPart.Size = New System.Drawing.Size(144, 16)
            Me.lblPart.TabIndex = 0
            Me.lblPart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblManufacturer
            '
            Me.lblManufacturer.ForeColor = System.Drawing.Color.White
            Me.lblManufacturer.Location = New System.Drawing.Point(104, 120)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(144, 16)
            Me.lblManufacturer.TabIndex = 0
            Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblModel
            '
            Me.lblModel.ForeColor = System.Drawing.Color.White
            Me.lblModel.Location = New System.Drawing.Point(104, 144)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(144, 16)
            Me.lblModel.TabIndex = 0
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCarrier
            '
            Me.lblCarrier.ForeColor = System.Drawing.Color.White
            Me.lblCarrier.Location = New System.Drawing.Point(104, 168)
            Me.lblCarrier.Name = "lblCarrier"
            Me.lblCarrier.Size = New System.Drawing.Size(144, 16)
            Me.lblCarrier.TabIndex = 0
            Me.lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblEnterprise
            '
            Me.lblEnterprise.ForeColor = System.Drawing.Color.White
            Me.lblEnterprise.Location = New System.Drawing.Point(104, 192)
            Me.lblEnterprise.Name = "lblEnterprise"
            Me.lblEnterprise.Size = New System.Drawing.Size(144, 16)
            Me.lblEnterprise.TabIndex = 0
            Me.lblEnterprise.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'labelCount
            '
            Me.labelCount.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.labelCount.ForeColor = System.Drawing.Color.White
            Me.labelCount.Location = New System.Drawing.Point(64, 384)
            Me.labelCount.Name = "labelCount"
            Me.labelCount.Size = New System.Drawing.Size(144, 16)
            Me.labelCount.TabIndex = 0
            Me.labelCount.Text = "COUNT"
            Me.labelCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCount
            '
            Me.lblCount.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.White
            Me.lblCount.Location = New System.Drawing.Point(64, 408)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(144, 40)
            Me.lblCount.TabIndex = 0
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label9
            '
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(274, 50)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(151, 16)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Device: Serial/IMEI Number:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'pnlStatus
            '
            Me.pnlStatus.BackColor = System.Drawing.Color.LightSteelBlue
            Me.pnlStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.pnlStatus.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSTATUS_RejectReason, Me.lblSTATUS_DeviceSN, Me.lblSTATUS})
            Me.pnlStatus.Location = New System.Drawing.Point(272, 128)
            Me.pnlStatus.Name = "pnlStatus"
            Me.pnlStatus.Size = New System.Drawing.Size(512, 112)
            Me.pnlStatus.TabIndex = 0
            '
            'lblSTATUS_RejectReason
            '
            Me.lblSTATUS_RejectReason.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblSTATUS_RejectReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSTATUS_RejectReason.Location = New System.Drawing.Point(16, 72)
            Me.lblSTATUS_RejectReason.Name = "lblSTATUS_RejectReason"
            Me.lblSTATUS_RejectReason.Size = New System.Drawing.Size(488, 32)
            Me.lblSTATUS_RejectReason.TabIndex = 0
            Me.lblSTATUS_RejectReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblSTATUS_DeviceSN
            '
            Me.lblSTATUS_DeviceSN.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblSTATUS_DeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSTATUS_DeviceSN.Location = New System.Drawing.Point(16, 40)
            Me.lblSTATUS_DeviceSN.Name = "lblSTATUS_DeviceSN"
            Me.lblSTATUS_DeviceSN.Size = New System.Drawing.Size(488, 24)
            Me.lblSTATUS_DeviceSN.TabIndex = 0
            Me.lblSTATUS_DeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblSTATUS
            '
            Me.lblSTATUS.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblSTATUS.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSTATUS.Location = New System.Drawing.Point(16, 8)
            Me.lblSTATUS.Name = "lblSTATUS"
            Me.lblSTATUS.Size = New System.Drawing.Size(488, 24)
            Me.lblSTATUS.TabIndex = 0
            Me.lblSTATUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'MainGrid
            '
            Me.MainGrid.AllowColMove = False
            Me.MainGrid.AllowColSelect = False
            Me.MainGrid.AllowDelete = True
            Me.MainGrid.AllowFilter = False
            Me.MainGrid.AllowSort = False
            Me.MainGrid.AlternatingRows = True
            Me.MainGrid.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.MainGrid.Location = New System.Drawing.Point(272, 264)
            Me.MainGrid.Name = "MainGrid"
            Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.MainGrid.PreviewInfo.ZoomFactor = 75
            Me.MainGrid.Size = New System.Drawing.Size(240, 264)
            Me.MainGrid.TabIndex = 0
            Me.MainGrid.TabStop = False
            Me.MainGrid.Text = "C1TrueDBGrid1"
            Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;BackColor:Co" & _
            "ntrol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}OddRow{}Foo" & _
            "ter{}Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;}Highlig" & _
            "htRow{ForeColor:HighlightText;BackColor:Highlight;}EvenRow{BackColor:Aqua;}Edito" & _
            "r{}RecordSelector{AlignImage:Center;}Style9{}Style8{}Style3{}Style2{}Style14{}St" & _
            "yle15{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Sty" & _
            "le10{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Allo" & _
            "wColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" Capti" & _
            "onHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>262</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 238, 262</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth" & _
            "><ClientArea>0, 0, 238, 262</ClientArea><PrintPageHeaderStyle parent="""" me=""Styl" & _
            "e14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnLoadDevices
            '
            Me.btnLoadDevices.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnLoadDevices.ForeColor = System.Drawing.Color.White
            Me.btnLoadDevices.Location = New System.Drawing.Point(24, 456)
            Me.btnLoadDevices.Name = "btnLoadDevices"
            Me.btnLoadDevices.Size = New System.Drawing.Size(216, 32)
            Me.btnLoadDevices.TabIndex = 0
            Me.btnLoadDevices.TabStop = False
            Me.btnLoadDevices.Text = "LOAD DEVICE(S)"
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(24, 496)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(216, 32)
            Me.btnClear.TabIndex = 0
            Me.btnClear.TabStop = False
            Me.btnClear.Text = "CLEAR DEVICE(S)"
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(424, 16)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(192, 21)
            Me.cboCustomer.TabIndex = 0
            Me.cboCustomer.TabStop = False
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.Location = New System.Drawing.Point(424, 48)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(192, 20)
            Me.txtDeviceSN.TabIndex = 1
            Me.txtDeviceSN.Text = ""
            '
            'Label1
            '
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(16, 96)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Part#:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 120)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Manufacturer:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(16, 144)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 0
            Me.Label3.Text = "Model:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(16, 168)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 16)
            Me.Label4.TabIndex = 0
            Me.Label4.Text = "Carrier:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(16, 192)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 16)
            Me.Label5.TabIndex = 0
            Me.Label5.Text = "Enterprise:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'MainGridReject
            '
            Me.MainGridReject.AllowColMove = False
            Me.MainGridReject.AllowColSelect = False
            Me.MainGridReject.AllowDelete = True
            Me.MainGridReject.AllowFilter = False
            Me.MainGridReject.AllowSort = False
            Me.MainGridReject.AllowUpdate = False
            Me.MainGridReject.AlternatingRows = True
            Me.MainGridReject.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.MainGridReject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.MainGridReject.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGridReject.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.MainGridReject.Location = New System.Drawing.Point(544, 264)
            Me.MainGridReject.Name = "MainGridReject"
            Me.MainGridReject.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.MainGridReject.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.MainGridReject.PreviewInfo.ZoomFactor = 75
            Me.MainGridReject.Size = New System.Drawing.Size(240, 264)
            Me.MainGridReject.TabIndex = 0
            Me.MainGridReject.TabStop = False
            Me.MainGridReject.Text = "C1TrueDBGrid1"
            Me.MainGridReject.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Ce" & _
            "nter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Editor{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Style10" & _
            "{AlignHorz:Near;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}EvenR" & _
            "ow{BackColor:Aqua;}OddRow{}RecordSelector{AlignImage:Center;}Style8{}Style3{}Sty" & _
            "le2{}Style14{}Style15{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;Align" & _
            "Vert:Center;}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Allo" & _
            "wColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" Capti" & _
            "onHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>262</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 238, 262</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth" & _
            "><ClientArea>0, 0, 238, 262</ClientArea><PrintPageHeaderStyle parent="""" me=""Styl" & _
            "e14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label6
            '
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(272, 248)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(224, 16)
            Me.Label6.TabIndex = 0
            Me.Label6.Text = "ACCEPTED"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(552, 248)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(224, 16)
            Me.Label7.TabIndex = 0
            Me.Label7.Text = "REJECTED"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'chkOEMwrtyLabor
            '
            Me.chkOEMwrtyLabor.ForeColor = System.Drawing.Color.White
            Me.chkOEMwrtyLabor.Location = New System.Drawing.Point(424, 80)
            Me.chkOEMwrtyLabor.Name = "chkOEMwrtyLabor"
            Me.chkOEMwrtyLabor.Size = New System.Drawing.Size(136, 16)
            Me.chkOEMwrtyLabor.TabIndex = 2
            Me.chkOEMwrtyLabor.Text = "OEM Warranty"
            '
            'chkOEMwrtyParts
            '
            Me.chkOEMwrtyParts.ForeColor = System.Drawing.Color.White
            Me.chkOEMwrtyParts.Location = New System.Drawing.Point(280, 80)
            Me.chkOEMwrtyParts.Name = "chkOEMwrtyParts"
            Me.chkOEMwrtyParts.Size = New System.Drawing.Size(136, 16)
            Me.chkOEMwrtyParts.TabIndex = 3
            Me.chkOEMwrtyParts.Text = "OEM Warranty Parts"
            Me.chkOEMwrtyParts.Visible = False
            '
            'btnLoad
            '
            Me.btnLoad.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnLoad.Location = New System.Drawing.Point(632, 48)
            Me.btnLoad.Name = "btnLoad"
            Me.btnLoad.Size = New System.Drawing.Size(72, 72)
            Me.btnLoad.TabIndex = 0
            Me.btnLoad.TabStop = False
            Me.btnLoad.Text = "ASSIGN"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCancel.Location = New System.Drawing.Point(720, 48)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(64, 72)
            Me.btnCancel.TabIndex = 0
            Me.btnCancel.TabStop = False
            Me.btnCancel.Text = "CANCEL"
            '
            'lblVendor
            '
            Me.lblVendor.BackColor = System.Drawing.Color.Transparent
            Me.lblVendor.ForeColor = System.Drawing.Color.White
            Me.lblVendor.Location = New System.Drawing.Point(372, 102)
            Me.lblVendor.Name = "lblVendor"
            Me.lblVendor.Size = New System.Drawing.Size(48, 24)
            Me.lblVendor.TabIndex = 0
            Me.lblVendor.Text = "Vendor:"
            Me.lblVendor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboVendor
            '
            Me.cboVendor.Location = New System.Drawing.Point(424, 104)
            Me.cboVendor.Name = "cboVendor"
            Me.cboVendor.Size = New System.Drawing.Size(200, 21)
            Me.cboVendor.TabIndex = 4
            '
            'lblNote
            '
            Me.lblNote.ForeColor = System.Drawing.Color.White
            Me.lblNote.Location = New System.Drawing.Point(16, 248)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(232, 64)
            Me.lblNote.TabIndex = 5
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label8
            '
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(16, 216)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(72, 16)
            Me.Label8.TabIndex = 6
            Me.Label8.Text = "Model Desc:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModelDesc
            '
            Me.lblModelDesc.ForeColor = System.Drawing.Color.White
            Me.lblModelDesc.Location = New System.Drawing.Point(104, 216)
            Me.lblModelDesc.Name = "lblModelDesc"
            Me.lblModelDesc.Size = New System.Drawing.Size(144, 16)
            Me.lblModelDesc.TabIndex = 7
            Me.lblModelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblIncoming
            '
            Me.lblIncoming.ForeColor = System.Drawing.Color.White
            Me.lblIncoming.Location = New System.Drawing.Point(8, 4)
            Me.lblIncoming.Name = "lblIncoming"
            Me.lblIncoming.Size = New System.Drawing.Size(112, 16)
            Me.lblIncoming.TabIndex = 9
            Me.lblIncoming.Text = "Incoming Procedures"
            '
            'Panel5
            '
            Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel5.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdLoadXML, Me.lblIncoming})
            Me.Panel5.Location = New System.Drawing.Point(16, 8)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(208, 56)
            Me.Panel5.TabIndex = 4
            '
            'cmdLoadXML
            '
            Me.cmdLoadXML.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdLoadXML.ForeColor = System.Drawing.Color.Black
            Me.cmdLoadXML.Location = New System.Drawing.Point(8, 21)
            Me.cmdLoadXML.Name = "cmdLoadXML"
            Me.cmdLoadXML.Size = New System.Drawing.Size(184, 23)
            Me.cmdLoadXML.TabIndex = 1
            Me.cmdLoadXML.Text = "Load XML - FTP Incoming (ALL)"
            '
            'frm_custspecREC_CellStar
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(792, 541)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblModelDesc, Me.Label8, Me.lblNote, Me.cboVendor, Me.lblVendor, Me.btnCancel, Me.btnLoad, Me.chkOEMwrtyParts, Me.chkOEMwrtyLabor, Me.Label7, Me.Label6, Me.MainGridReject, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.txtDeviceSN, Me.cboCustomer, Me.btnClear, Me.btnLoadDevices, Me.MainGrid, Me.pnlStatus, Me.Label9, Me.lblCount, Me.labelCount, Me.lblEnterprise, Me.lblCarrier, Me.lblModel, Me.lblManufacturer, Me.lblPart, Me.lblCustomer, Me.Panel5})
            Me.Name = "frm_custspecREC_CellStar"
            Me.Text = "Brightpoint Receiving"
            Me.pnlStatus.ResumeLayout(False)
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.MainGridReject, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel5.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frm_custspecREC_CellStar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            '*****************************************************************
            'Add by Lan 11/20/2006
            If iParentGroupID <> 5 And iParentGroupID <> 2 And iParentGroupID <> 11 And iParentGroupID <> 3 Then
                MessageBox.Show("This computer was not mapped to the right group. Can not continue.", "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Close()
            End If
            '*****************************************************************

            PopulateCustomer()
            PopulateVendor()
            actionClear()
            dataGrid = CreateGridDT()
            dataGridReject = CreateGridDTReject()

            lblSTATUS.Text = ""
            lblSTATUS_DeviceSN.Text = ""
            lblSTATUS_RejectReason.Text = ""
            pnlStatus.BackColor = Color.LightSteelBlue

            txtDeviceSN.Enabled = True
            txtDeviceSN.Focus()
        End Sub

#Region "Form Methods"

        Private Sub clearDataValues()
            mItemNum = 0
            iEnterprise = 0
            iCarrier = 0
            iModel = 0
            iDeviceID = 0
            iLoc = 0
            iManufacturerID = 0
            iCSstatus = 0
            billcode_id = 0
            mRepairOrderNum = ""
            mEnterpriseCode = ""
            mEnterprise = ""
            mCarrier = ""
            mModel = ""
            mManufacturer = ""
            mWrtyDate = ""
            mDeviceSn = ""
            mModelDesc = ""
            mHEX = ""
            mSJUG = ""
            mDelKey = ""
            blnPSSWrty = False
        End Sub

#End Region

#Region "Load ComboBox Data"

        Private Sub PopulateCustomer()
            Try
                strSQL = "SELECT tcustomer.cust_id, cust_name1, loc_id from tcustomer inner join tlocation on tcustomer.cust_id = tlocation.cust_id where tcustomer.cust_id in (2113) ORDER BY Cust_Name1"
                Dim dtCust As DataTable = ds.OrderEntrySelect(strSQL)

                cboCustomer.DataSource = dtCust
                cboCustomer.DisplayMember = dtCust.Columns("Cust_Name1").ToString
                cboCustomer.ValueMember = dtCust.Columns("Loc_ID").ToString
            Catch ex As Exception
            End Try
        End Sub

        Private Sub PopulateVendor()
            Try
                strSQL = "SELECT csvendor_name1, csvendor_id from cs_Vendor ORDER BY csvendor_Name1"
                Dim dtVendor As DataTable = ds.OrderEntrySelect(strSQL)

                cboVendor.DataSource = dtVendor
                cboVendor.DisplayMember = dtVendor.Columns("csvendor_Name1").ToString
                cboVendor.ValueMember = dtVendor.Columns("csvendor_ID").ToString
            Catch ex As Exception
            End Try
        End Sub




#End Region

#Region "Counter Methods"

        Private Sub incrementCounter()
            '//*********************************************************************************
            '//This will increment the counter value on the page by 1
            '//*********************************************************************************
            Dim newCount As Long = CInt(lblCount.Text)
            newCount += 1
            lblCount.Text = newCount
        End Sub

        Private Sub decrementCounter()
            '//*********************************************************************************
            '//This will decrement the counter value on the page by 1
            '//*********************************************************************************
            Dim newCount As Long = CInt(lblCount.Text)
            newCount -= 1
            lblCount.Text = newCount
        End Sub

#End Region

#Region "Display Status Methods"

        Private Sub actionAccept(ByVal mSerialNumber As String)
            '//*********************************************************************************
            '//This sets the status display to signify an accepted device
            '//*********************************************************************************
            If mLaborAmount = 4.5 Then
                lblSTATUS.Text = "ACCEPT - WIPEDOWN"
                lblSTATUS.ForeColor = Color.Yellow
            Else
                lblSTATUS.Text = "ACCEPT"
                lblSTATUS.ForeColor = Color.Black
            End If
            lblSTATUS_DeviceSN.Text = txtDeviceSN.Text
            lblSTATUS_RejectReason.Text = ""
            pnlStatus.BackColor = Color.PaleTurquoise
        End Sub

        Private Sub actionReject(ByVal mSerialNumber As String, ByVal mRejectText As String)
            '//*********************************************************************************
            '//This sets the status display to signify a rejected device
            '//*********************************************************************************
            If mLaborAmount = 4.5 Then
                lblSTATUS.Text = "REJECT - WIPEDOWN"
                lblSTATUS.ForeColor = Color.Yellow
            Else
                lblSTATUS.Text = "REJECT"
                lblSTATUS.ForeColor = Color.Black
            End If
            lblSTATUS.Text = "REJECT"
            lblSTATUS_DeviceSN.Text = txtDeviceSN.Text
            lblSTATUS_RejectReason.Text = mRejectText
            pnlStatus.BackColor = Color.Red
        End Sub

        Private Sub actionClear()
            '//*********************************************************************************
            '//This sets the default status display
            '//*********************************************************************************
            lblSTATUS.Text = ""
            lblSTATUS.ForeColor = Color.Black
            lblSTATUS_DeviceSN.Text = ""
            lblSTATUS_RejectReason.Text = ""
            pnlStatus.BackColor = Color.PaleTurquoise
        End Sub

        Private Sub actionAwaitingAssignment()
            '//*********************************************************************************
            '//This sets the status display to inform the user that the data is incomplete
            '//It will stay this way until the user clicke the button labeled ASSIGN
            '//*********************************************************************************
            If mLaborAmount = 4.5 Then
                lblSTATUS.Text = "WIPEDOWN - AWAITING ASSIGNMENT"
                lblSTATUS.ForeColor = Color.Yellow
            Else
                lblSTATUS.Text = "AWAITING ASSIGNMENT"
                lblSTATUS.ForeColor = Color.Black
            End If
            lblSTATUS_DeviceSN.Text = txtDeviceSN.Text
            lblSTATUS_RejectReason.Text = ""
            pnlStatus.BackColor = Color.PaleTurquoise
        End Sub

        Private Sub Hide_PanelStatus()
            '//*********************************************************************************
            '//This will make the status panel invisible
            '//*********************************************************************************
            pnlStatus.Visible = False
            lblSTATUS.ForeColor = Color.Black
            lblSTATUS.Visible = False
            lblSTATUS_DeviceSN.Visible = False
            lblSTATUS_RejectReason.Visible = False
        End Sub

        Private Sub Show_PanelStatus()
            '//*********************************************************************************
            '//This will make the status panel visible
            '//*********************************************************************************
            pnlStatus.Visible = True
            lblSTATUS.Visible = True
            lblSTATUS_DeviceSN.Visible = True
            lblSTATUS_RejectReason.Visible = True
        End Sub

#End Region

#Region "Grid Creation Methods"

        Private Function CreateGridDT() As DataTable

            Dim dtGrid As New DataTable("dtGridMain")

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim dcDeviceID As New DataColumn("DeviceID")
            dtGrid.Columns.Add(dcDeviceID)
            Dim dcDeviceSN As New DataColumn("DeviceSN")
            dtGrid.Columns.Add(dcDeviceSN)
            Dim dcOEMlabor As New DataColumn("OEMWrtyLabor")
            dtGrid.Columns.Add(dcOEMlabor)
            Dim dcOEMparts As New DataColumn("OEMWrtyParts")
            dtGrid.Columns.Add(dcOEMparts)
            Dim dcPSSWrty As New DataColumn("PSSWrty")
            dtGrid.Columns.Add(dcPSSWrty)
            Dim dcProdID As New DataColumn("ProdID")
            dtGrid.Columns.Add(dcProdID)
            Dim dcWO_CustWO As New DataColumn("WOname")
            dtGrid.Columns.Add(dcWO_CustWO)
            Dim dcLocID As New DataColumn("LocID")
            dtGrid.Columns.Add(dcLocID)
            Dim dcGroupID As New DataColumn("GroupID")
            dtGrid.Columns.Add(dcGroupID)
            Dim dcSKUlength As New DataColumn("SKUlength")
            dtGrid.Columns.Add(dcSKUlength)
            Dim dcSKUid As New DataColumn("SKUid")
            dtGrid.Columns.Add(dcSKUid)
            Dim dcModelID As New DataColumn("ModelID")
            dtGrid.Columns.Add(dcModelID)
            Dim dcBillcodeID As New DataColumn("BillcodeID")
            dtGrid.Columns.Add(dcBillcodeID)
            Dim dcVendorID As New DataColumn("VendorID")
            dtGrid.Columns.Add(dcVendorID)
            Dim dcHEX As New DataColumn("HEX")
            dtGrid.Columns.Add(dcHEX)
            Dim dcSJUG As New DataColumn("SJUG")
            dtGrid.Columns.Add(dcSJUG)
            Dim dcItemNum As New DataColumn("ItemNum")
            dtGrid.Columns.Add(dcItemNum)
            Dim dcLaborAmount As New DataColumn("LaborAmount")
            dtGrid.Columns.Add(dcLaborAmount)

            CreateGridDT = dtGrid

        End Function

        Private Function CreateGridDTReject() As DataTable

            Dim dtGrid As New DataTable("dtGridMain")

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim dcDeviceID As New DataColumn("DeviceID")
            dtGrid.Columns.Add(dcDeviceID)
            Dim dcDeviceSN As New DataColumn("DeviceSN")
            dtGrid.Columns.Add(dcDeviceSN)

            CreateGridDTReject = dtGrid

        End Function

#End Region

#Region "Validation Methods"

        Private Function checkDuplicates(ByVal mDeviceSN As String) As Boolean

            Dim x As Integer = 0
            Dim rCheck As DataRow
            If dataGrid.Rows.Count > 0 Then
                For x = 0 To dataGrid.Rows.Count - 1
                    rCheck = dataGrid.Rows(x)
                    If rCheck("DeviceSN") = Trim(mDeviceSN) Then
                        Return True
                    End If
                Next
            End If

            System.Windows.Forms.Application.DoEvents()
            If dataGridReject.Rows.Count > 0 Then
                For x = 0 To dataGridReject.Rows.Count - 1
                    rCheck = dataGridReject.Rows(x)
                    If rCheck("DeviceSN") = Trim(mDeviceSN) Then
                        Return True
                    End If
                Next
            End If
            Return False

        End Function

        Private Function validatePartNumberData(ByVal mItemNum As Long) As Boolean
            If mItemNum > 0 Then
                strSQL = "SELECT * FROM cs_partmap WHERE part_number = " & mItemNum
                Dim dtPartNumber As DataTable = ds.OrderEntrySelect(strSQL)
                If dtPartNumber.Rows.Count > 0 Then
                    r = dtPartNumber.Rows(0)
                    iEnterprise = r("ent_ID")
                    iCarrier = r("carrier_id")
                    iModel = r("model_id")
                    Return True
                Else
                    Return False
                End If
            End If

        End Function

#End Region

#Region "Acquire Form Data Methods"

        Private Function getEnterprise(ByVal iEnterprise As Long) As String
            strSQL = "SELECT ent_longdesc FROM cs_Enterprise WHERE ent_id = " & iEnterprise
            Dim dtGeneral As DataTable = ds.OrderEntrySelect(strSQL)
            If dtGeneral.Rows.Count > 0 Then
                r = dtGeneral.Rows(0)
                mEnterprise = r("ent_longdesc")
                System.Windows.Forms.Application.DoEvents()
                dtGeneral = Nothing
                Return mEnterprise
            End If
        End Function

        Private Function getLaborAmount(ByVal iItemNum As Long) As Double
            strSQL = "SELECT laboramount FROM cs_partmap WHERE part_number = " & iItemNum
            Dim dtGeneral As DataTable = ds.OrderEntrySelect(strSQL)
            If dtGeneral.Rows.Count > 0 Then
                r = dtGeneral.Rows(0)
                mLaborAmount = r("laboramount")
                System.Windows.Forms.Application.DoEvents()
                dtGeneral = Nothing
                Return mLaborAmount
            End If
        End Function

        Private Function getCarrier(ByVal iCarrier As Long) As String
            strSQL = "SELECT carrier_longdesc FROM cs_Carrier WHERE carrier_id = " & iCarrier
            Dim dtGeneral As DataTable = ds.OrderEntrySelect(strSQL)
            If dtGeneral.Rows.Count > 0 Then
                r = dtGeneral.Rows(0)
                mCarrier = r("carrier_longdesc")
                System.Windows.Forms.Application.DoEvents()
                dtGeneral = Nothing
                Return mCarrier
            End If
        End Function

        Private Sub getManufacturerANDModel(ByVal vModel As Long)
            strSQL = "SELECT model_desc, manuf_id FROM tmodel WHERE model_id = " & vModel
            Dim dtGeneral As DataTable = ds.OrderEntrySelect(strSQL)
            If dtGeneral.Rows.Count > 0 Then
                r = dtGeneral.Rows(0)
                mModel = r("model_desc")
                System.Windows.Forms.Application.DoEvents()
                '//Get manufacturer
                iManufacturerID = r("Manuf_ID")
                strSQL = "SELECT Manuf_Desc FROM lmanuf WHERE Manuf_ID = " & r("Manuf_ID")
                System.Windows.Forms.Application.DoEvents()
                dtGeneral = ds.OrderEntrySelect(strSQL)
                r = dtGeneral.Rows(0)
                mManufacturer = r("Manuf_Desc")
                dtGeneral = Nothing
            End If
        End Sub

#End Region

#Region "Button Functions"

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            Dim strAnswer As String = MsgBox("This will cancel the receive of all devices listed currently. Are you sure?", MsgBoxStyle.YesNo, "Are you sure?")
            Select Case strAnswer
                Case vbYes
                    '//continue as normal
                Case vbNo
                    txtDeviceSN.Enabled = True
                    txtDeviceSN.Focus()
                    Exit Sub
            End Select

            '//reset data values
            clearDataValues()
            '//clear data from screen
            lblPart.Text = ""
            lblManufacturer.Text = ""
            lblModel.Text = ""
            lblCarrier.Text = ""
            lblEnterprise.Text = ""
            lblModelDesc.Text = ""
            txtDeviceSN.Text = ""
            lblSTATUS.Text = ""
            lblSTATUS_DeviceSN.Text = ""
            lblSTATUS_RejectReason.Text = ""
            '//change panel to default color
            pnlStatus.BackColor = Color.PaleTurquoise
            '//clear datagrids
            dataGrid.Clear()
            dataGridReject.Clear()
            '//reset counter
            lblCount.Text = "0"
            '//set focus back to device sn
            txtDeviceSN.Enabled = True
            txtDeviceSN.Focus()
        End Sub

        Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click


            '//Get Vendor ID before loading
            'Dim mOEMwrty As Integer = 0
            'Dim mPSSwrty As Integer = 0
            'Dim mVendor As Integer

            'If Me.chkOEMwrtyLabor.Checked = True Then
            'mOEMwrty = 1
            'ElseIf Me.chkOEMwrtyParts.Checked = True Then
            '    mOEMwrty = 1
            'ElseIf blnPSSWrty = True Then
            '    mPSSwrty = 1
            'End If

            'strSQL = "select cs_vendor.csvendor_id from " & _
            '"cs_vendorpartassignment inner join cs_vendorloc on cs_vendorpartassignment.VP_VLocID = csvloc_id " & _
            '"inner join cs_vendor on cs_vendorloc.csVendor_ID = cs_vendor.csvendor_id " & _
            '"WHERE csin_ItemNum = '" & mItemNum & "' " & _
            '"AND VP_OEMwrty = " & mOEMwrty & " " & _
            '"and VP_PSSwrty = " & mPSSwrty

            'Dim dtVendor As DataTable = ds.OrderEntrySelect(strSQL)
            'If dtVendor.Rows.Count < 1 Then
            'MsgBox("You can not receive this item because a vendor relationship to the item number is not present.", MsgBoxStyle.Critical, "ERROR")
            'Exit Sub
            'Else
            '    '//Get value
            '    Dim rVendor As DataRow
            '    rVendor = dtVendor.Rows(0)
            '    mVendor = rVendor("csvendor_id")
            'End If
            '//Get Vendor ID before loading



            '//Display Accept
            actionAccept(txtDeviceSN.Text)

            Dim dr1 As DataRow = dataGrid.NewRow
            dr1("DeviceID") = iDeviceID
            dr1("DeviceSN") = Trim(txtDeviceSN.Text)
            If Me.chkOEMwrtyLabor.Checked = True Then
                dr1("OEMWrtyLabor") = 1
            Else
                dr1("OEMWrtyLabor") = 0
            End If
            If Me.chkOEMwrtyParts.Checked = True Then
                dr1("OEMWrtyParts") = 1
            Else
                dr1("OEMWrtyParts") = 0
            End If
            If blnPSSWrty = True Then
                dr1("PSSWrty") = 1
            Else
                dr1("PSSWrty") = 0
            End If
            dr1("ProdID") = 2
            dr1("WOname") = mRepairOrderNum
            dr1("LocID") = cboCustomer.SelectedValue
            dr1("GroupID") = 3
            dr1("SKUlength") = 1
            dr1("SKUid") = 34
            dr1("ModelID") = iModel
            dr1("BillcodeID") = billcode_id
            dr1("HEX") = Trim(mHEX)
            dr1("SJUG") = Trim(mSJUG)
            dr1("ItemNum") = Trim(mItemNum)
            dr1("LaborAmount") = Trim(mLaborAmount)
            'dr1("VendorID") = mVendor

            dataGrid.Rows.Add(dr1)
            System.Windows.Forms.Application.DoEvents()
            MainGrid.DataSource = dataGrid
            System.Windows.Forms.Application.DoEvents()
            incrementCounter()

            clearDataValues()

            lblPart.Text = ""
            lblManufacturer.Text = ""
            lblModel.Text = ""
            lblCarrier.Text = ""
            lblEnterprise.Text = ""
            lblNote.Text = ""

            chkOEMwrtyLabor.Enabled = True
            chkOEMwrtyParts.Enabled = True

            chkOEMwrtyLabor.Checked = False
            chkOEMwrtyParts.Checked = False

            txtDeviceSN.Enabled = True
            txtDeviceSN.Text = ""
            txtDeviceSN.Focus()

        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

            actionClear()

            clearDataValues()

            lblPart.Text = ""
            lblManufacturer.Text = ""
            lblModel.Text = ""
            lblCarrier.Text = ""
            lblEnterprise.Text = ""
            lblModelDesc.Text = ""

            chkOEMwrtyLabor.Enabled = True
            chkOEMwrtyParts.Enabled = True

            chkOEMwrtyLabor.Checked = False
            chkOEMwrtyParts.Checked = False

            txtDeviceSN.Enabled = True
            txtDeviceSN.Text = ""
            txtDeviceSN.Focus()

        End Sub

#End Region

#Region "Grid Actions"

        Private Sub MainGrid_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainGrid.AfterDelete
            decrementCounter()
            actionClear()

            Dim x1 As Integer
            Dim r As DataRow

            'For x1 = 0 To dataGrid.Rows.Count - 1
            'r = dataGrid.Rows(x1)
            'If r("DeviceSN").ToString = mDelKey Then
            'dataGrid.Rows(x1).Delete()
            'System.Windows.Forms.Application.DoEvents()
            'Exit For
            'End If
            'Next

            'System.Windows.Forms.Application.DoEvents()
            'MainGrid.DataSource = dataGrid
            'System.Windows.Forms.Application.DoEvents()

            txtDeviceSN.Enabled = True
            txtDeviceSN.Focus()
        End Sub

        Private Sub MainGridReject_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainGridReject.AfterDelete
            actionClear()
            txtDeviceSN.Enabled = True
            txtDeviceSN.Focus()
        End Sub

#End Region

#Region "Device Methods"

        Private Function getDeviceData(ByVal mDeviceSN As String) As Long
            If Len(Trim(mDeviceSN)) > 0 Then
                Try
                    strSQL = "SELECT csin_ID, csin_ItemNum, csin_RepairOrderNum, csin_EnterpriseCode, billcode_id, cs_status, csin_itemdesc FROM cstincomingdata WHERE csin_ESN = '" & mDeviceSN & "' AND flgReceived = 0"
                    Dim dtDeviceData As DataTable = ds.OrderEntrySelect(strSQL)
                    If dtDeviceData.Rows.Count > 0 Then
                        r = dtDeviceData.Rows(0)
                        mItemNum = r("csin_ItemNum")
                        mRepairOrderNum = r("csin_RepairOrderNum")
                        mEnterpriseCode = r("csin_EnterpriseCode")
                        iDeviceID = r("csin_ID")
                        billcode_id = r("billcode_id")
                        iCSstatus = r("cs_status")
                        mModelDesc = r("csin_ItemDesc")
                        System.Windows.Forms.Application.DoEvents()

                        '//Verify that the device is the correct wipedown type 
                        '//for this receive
                        'Dim mWD As Integer = InStr(mModelDesc, " WD ")
                        '//if the integer returned is greater than 0 then it is a wipedown
                        'If mWD > 0 Then
                        '//Verify that chkWIPEDOWN is selected
                        'If chkWipeDown.Checked = True Then
                        '    'Device Approved
                        'Else
                        ''//ERROR
                        'MsgBox("This device is a wipedown. It can not be received as refurbish.", MsgBoxStyle.Critical, "ERROR")
                        'clearDataValues()
                        ''//*********************************************************************************
                        ''//clear data from screen
                        ''//*********************************************************************************
                        'lblPart.Text = ""
                        'lblManufacturer.Text = ""
                        'lblModel.Text = ""
                        'lblCarrier.Text = ""
                        'lblEnterprise.Text = ""
                        'lblModelDesc.Text = ""
                        'txtDeviceSN.Text = ""
                        'lblSTATUS.Text = ""
                        'lblSTATUS_DeviceSN.Text = ""
                        'lblSTATUS_RejectReason.Text = ""
                        ''//*********************************************************************************
                        ''//change panel to default color
                        ''//*********************************************************************************
                        'pnlStatus.BackColor = Color.PaleTurquoise
                        ''//*********************************************************************************
                        ''//set focus back to device sn
                        ''//*********************************************************************************
                        'txtDeviceSN.Enabled = True
                        'txtDeviceSN.Focus()
                        'Return 0
                        'End If
                        'Else
                        ''//Verify that chkWIPEDOWN is NOT selected
                        'If chkWipeDown.Checked = False Then
                        'Device Approved
                        'Else
                        ''//ERROR
                        'MsgBox("This device is not a wipedown. It can not be received as refurbish.", MsgBoxStyle.Critical, "ERROR")
                        'clearDataValues()
                        ''//*********************************************************************************
                        ''//clear data from screen
                        ''//*********************************************************************************
                        'lblPart.Text = ""
                        'lblManufacturer.Text = ""
                        'lblModel.Text = ""
                        'lblCarrier.Text = ""
                        'lblEnterprise.Text = ""
                        'lblModelDesc.Text = ""
                        'txtDeviceSN.Text = ""
                        'lblSTATUS.Text = ""
                        'lblSTATUS_DeviceSN.Text = ""
                        'lblSTATUS_RejectReason.Text = ""
                        ''//*********************************************************************************
                        ''//change panel to default color
                        ''//*********************************************************************************
                        'pnlStatus.BackColor = Color.PaleTurquoise
                        ''//*********************************************************************************
                        ''//set focus back to device sn
                        ''//*********************************************************************************
                        'txtDeviceSN.Enabled = True
                        'txtDeviceSN.Focus()
                        'Return 0
                        'End If
                        'End If
                        'Return mItemNum
                    Else
                        Return 0
                    End If
                Catch ex As Exception
                    Return 0
                End Try
            End If
        End Function

        Private Sub txtDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown
            If e.KeyCode = 13 Then

                If Len(Trim(txtDeviceSN.Text)) < 1 Then
                    txtDeviceSN.Enabled = True
                    txtDeviceSN.Focus()
                    Exit Sub
                Else
                    txtDeviceSN.Enabled = False
                End If

                lblPart.Text = ""
                lblManufacturer.Text = ""
                lblModel.Text = ""
                lblCarrier.Text = ""
                lblEnterprise.Text = ""
                lblNote.Text = ""
                lblModelDesc.Text = ""

                '//Obtain the data to populate the form
                clearDataValues()

                '//Check for duplicates
                Dim blnDuplicate As Boolean = checkDuplicates(Trim(txtDeviceSN.Text))

                If blnDuplicate = True Then
                    actionReject(Trim(txtDeviceSN.Text), "This device is already selected/rejected.")
                    clearDataValues()
                    txtDeviceSN.Enabled = True
                    txtDeviceSN.Text = ""
                    txtDeviceSN.Focus()
                    Exit Sub
                End If

                getDeviceData(Trim(txtDeviceSN.Text))

                Dim mValidate As Boolean = Me.validatePartNumberData(mItemNum)

                If mValidate = True Then

                    If iDeviceID > 0 Then

                        lblPart.Text = mItemNum
                        lblEnterprise.Text = getEnterprise(iEnterprise)
                        lblCarrier.Text = getCarrier(iCarrier)
                        mLaborAmount = getLaborAmount(mItemNum)
                        getManufacturerANDModel(iModel)
                        System.Windows.Forms.Application.DoEvents()
                        lblManufacturer.Text = mManufacturer
                        lblModel.Text = mModel

                        '//Craig Haney - New January 18, 2007
                        If mLaborAmount <> 4.5 Then
                            '//Craig Haney - New January 18, 2007

                            'If iCSstatus = 9 Then
                            If iManufacturerID = 1 Then '//Motorola
                                checkOEMwrty_Motorola()
                            ElseIf iManufacturerID = 24 Then
                                CheckOEMwrty_Nokia()
                            Else
                                btnLoad.Focus()
                            End If

                            '//Craig Haney - New January 18, 2007
                        Else
                            '//Set for Wipedown
                            chkOEMwrtyLabor.Checked = False
                            chkOEMwrtyParts.Checked = False
                            btnLoad.Focus()
                        End If



                        '//Craig Haney - New January 18, 2007


                        '//Lan Nguyen
                        '//Please enter the check oem warranties for the remainder of manufacturers
                        '//Thank you very much for doing this.
                        '//I greatly appreciate you doing this for me!!!!
                        '//Lan Nguyen

                        'Else
                        'Me.chkOEMwrtyLabor.Enabled = False
                        'Me.chkOEMwrtyParts.Enabled = False
                        'Me.btnLoad.Focus()
                        'End If


                        '//Get PSSWrty Status
                        '//90 days
                        mWrtyDate = FormatDate(DateAdd(DateInterval.Day, -90, Now))
                        iLoc = cboCustomer.SelectedValue
                        mDeviceSn = Trim(txtDeviceSN.Text)
                        dtPSSWrty = ds.chkPSSwrty(mDeviceSn, iLoc, mWrtyDate)





                        If dtPSSWrty.Rows(0)("repeat") <> False Then
                            'blnPSSWrty = True
                            blnPSSWrty = False '//This is in place until the management can determine exactly the process to be used
                        Else
                            blnPSSWrty = False
                        End If
                        System.Windows.Forms.Application.DoEvents()
                        dtPSSWrty = Nothing
                        '//Get PSSWrty Status - END

                        '//January 18, 2007
                        btnLoad.Focus()
                        '//January 18, 2007

                        actionAwaitingAssignment()

                    End If
                Else
                    mRejectText = "This device is not acceptable for receiving. Either the data is missing or imcomplete."
                    actionReject(Trim(txtDeviceSN.Text), mRejectText)

                    Dim dr2 As DataRow = dataGridReject.NewRow
                    dr2("DeviceID") = iDeviceID
                    dr2("DeviceSN") = Trim(txtDeviceSN.Text)
                    dataGridReject.Rows.Add(dr2)
                    System.Windows.Forms.Application.DoEvents()
                    MainGridReject.DataSource = dataGridReject

                    txtDeviceSN.Enabled = True
                    txtDeviceSN.Text = ""
                    txtDeviceSN.Focus()

                End If


            End If
        End Sub

#End Region

        Private Sub btnLoadDevices_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadDevices.Click

            Me.Enabled = False

            Cursor.Current = Cursors.WaitCursor

            Dim arrDevices(dataGrid.Rows.Count - 1) As String
            Dim arrCount As Integer = 0
            Dim arrLimit As Integer = 0
            Dim blnDuplicate As Boolean

            Dim insWO As New PSS.Data.Production.tworkorder()
            Dim insTray As New PSS.Data.Production.ttray()
            Dim insDevice As New PSS.Data.Production.tdevice()

            Dim dtWO, _
            dtTray, _
            dtDevice As DataTable

            Dim rLoad, _
            rWO, _
            rTray, _
            rDevice As DataRow

            Dim ckItemNum As Long
            Dim ckLaborAmount As Double

            Dim ckProdID, _
            ckWOname, _
            ckLocID, _
            ckGroupID, _
            ckSKUlength, _
            ckSKUid, _
            ckDeviceSN, _
            ckModelID, _
            ckHEX, _
            ckSJUG As String

            Dim wo_id, _
            tray_id, _
            device_id, _
            ibillcode As Long

            Dim x As Integer = 0

            Dim blnDevice, _
            blnCST_Update, _
            blnLaborUpdate As Boolean

            '**********************************
            'Added by Lan 11/20/2006 Assign Group
            Dim iGroup_id As Integer = 0
            If iParentGroupID = 5 Or iParentGroupID = 2 Then
                iGroup_id = 2
            ElseIf iParentGroupID = 11 Or iParentGroupID = 3 Then
                iGroup_id = 3
            End If

            If iGroup_id = 0 Then
                MessageBox.Show("Group ID was not defined.", "Load Devices", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.Enabled = True
                Exit Sub
            End If
            '**********************************

            '//*********************************************************************************
            '//*********************************************************************************
            '//Validate Data Elements Before Loading
            Dim errMsg As String = ""

            For x = 0 To dataGrid.Rows.Count - 1
                rLoad = dataGrid.Rows(x)
                '//Validate data in rows
                If IsDBNull(rLoad("DeviceSN")) = True Then errMsg += "There is a device with no serial number." & vbCrLf
                If IsDBNull(rLoad("ProdID")) = True Then errMsg += "There is no product assignment for device: " & rLoad("DeviceSN") & vbCrLf
                If IsDBNull(rLoad("WOname")) = True Then errMsg += "There is no defined Workorder for device: " & rLoad("DeviceSN") & vbCrLf
                If IsDBNull(rLoad("LocID")) = True Then errMsg += "There is no defined location for device: " & rLoad("DeviceSN") & vbCrLf
                If IsDBNull(rLoad("GroupID")) = True Then errMsg += "There is no defined group for device: " & rLoad("DeviceSN") & vbCrLf
                If IsDBNull(rLoad("SkuLength")) = True Then errMsg += "There is no defined sku length for device: " & rLoad("DeviceSN") & vbCrLf
                If IsDBNull(rLoad("SKUid")) = True Then errMsg += "There is no defined sku id for device: " & rLoad("DeviceSN") & vbCrLf
                If IsDBNull(rLoad("ModelID")) = True Then errMsg += "There is no defined model for device: " & rLoad("DeviceSN") & vbCrLf
            Next

            If Len(Trim(errMsg)) > 0 Then
                '//Display Message
                errMsg += vbCrLf & "These devices can not be loaded...EXITING"
                MsgBox(errMsg, MsgBoxStyle.Critical, "CAN NOT CONTINUE")
                Cursor.Current = Cursors.Default
                Me.Enabled = True
                Exit Sub
            End If

            Dim dtDuplicate As DataTable
            dtDuplicate = dataGrid
            Dim arrPrimaryKey(0) As DataColumn
            Try
                arrPrimaryKey(0) = dataGrid.Columns(1)
                dataGrid.PrimaryKey = arrPrimaryKey
            Catch ex As Exception
                '//This data grid contains a duplicate
                MsgBox("Duplicates Exists")
                dtDuplicate = Nothing
                Me.Enabled = True
                Exit Sub
            End Try

            '//*********************************************************************************
            '//*********************************************************************************

            For x = 0 To dataGrid.Rows.Count - 1

                '//November 15, 2006
                '//This is a new segment to eliminate duplicates in the system.
                '//START
                blnDuplicate = False

                '//check array for duplicate
                For arrCount = 0 To x
                    If Trim(rLoad("DeviceSN")) = Trim(arrDevices(arrCount)) Then
                        '//This is the duplicate - do not load
                        '//display as duplicate
                        MsgBox(rLoad("DeviceSN") & " is a duplicate entry.", MsgBoxStyle.OKOnly, "Procedure Issue")
                        blnDuplicate = True
                        Exit For
                    End If
                Next
                '//Add record to array
                arrDevices(arrLimit) = Trim(rLoad("DeviceSN"))
                '//increase arrLimit by 1
                arrLimit += 1

                If blnDuplicate = False Then
                    '//END
                    '//November 15, 2006
                    '//This is a new segment to eliminate duplicates in the system.

                    rLoad = dataGrid.Rows(x)

                    '//*********************************************************************************
                    '//Get Row Data
                    '//*********************************************************************************
                    ckProdID = rLoad("ProdID")
                    ckWOname = rLoad("WOname")
                    ckLocID = rLoad("LocID")
                    ckGroupID = rLoad("GroupID")
                    ckSKUlength = rLoad("SKUlength")
                    ckSKUid = rLoad("SKUid")
                    ckDeviceSN = rLoad("DeviceSN")
                    ckModelID = rLoad("ModelID")
                    ckHEX = rLoad("HEX")
                    ckSJUG = rLoad("SJUG")
                    ckItemNum = rLoad("ItemNum")
                    ckLaborAmount = rLoad("LaborAmount")
                    ibillcode = rLoad("BillcodeID")

                    '//*********************************************************************************
                    '//Determine if Workorder Exists
                    '//*********************************************************************************
                    strSQL = "SELECT * FROM tworkorder WHERE WO_CustWO = '" & ckWOname & "' AND Loc_ID = " & ckLocID
                    dtWO = ds.OrderEntrySelect(strSQL)
                    System.Windows.Forms.Application.DoEvents()

                    If dtWO.Rows.Count > 0 Then
                        '//*********************************************************************************
                        '//workorder exists - get ID number
                        '//*********************************************************************************
                        rWO = dtWO.Rows(0)
                        wo_id = rWO("WO_ID")
                    Else
                        '//*********************************************************************************
                        '//new workorder - Insert record
                        '//*********************************************************************************
                        strSQL = "INSERT INTO TWORKORDER " & _
                        "(WO_CustWO, " & _
                        "WO_RecPalletName, " & _
                        "Loc_ID, " & _
                        "Group_ID, " & _
                        "WO_SkuLength, " & _
                        "Sku_ID, " & _
                        "Prod_ID)" & _
                        "VALUES " & _
                        "('" & ckWOname & "', " & _
                        "'" & ckWOname & "', " & _
                        ckLocID & ", " & _
                        iGroup_id & ", " & _
                        ckSKUlength & ", " & _
                        ckSKUid & ", " & _
                        2 & ")"
                        wo_id = insWO.idTransaction(strSQL)
                    End If
                    System.Windows.Forms.Application.DoEvents()

                    '//*********************************************************************************
                    '//insert new tray
                    '//Each device will be in its own tray for Brightpoint
                    '//*********************************************************************************
                    If wo_id > 0 Then
                        '//new tray
                        strSQL = "INSERT INTO TTRAY " & _
                        "(Tray_RecUser, " & _
                        "WO_ID) " & _
                        "VALUES " & _
                        "('" & PSS.Core.[Global].ApplicationUser.User & "', " & _
                        wo_id & ")"
                        tray_id = insWO.idTransaction(strSQL)
                    End If
                    System.Windows.Forms.Application.DoEvents()

                    '//*********************************************************************************
                    '//insert device
                    '//The qualifier to insert the device will be that the wo_id and tray_id <> 0
                    '//*********************************************************************************
                    Dim vDateBill As String = "NULL, "

                    If ibillcode > 0 Then
                        vDateBill = "'" & Gui.Receiving.FormatDate(Now) & "', "
                    End If

                    If wo_id > 0 And tray_id > 0 Then
                        '//insert device
                        strSQL = "INSERT INTO TDEVICE " & _
                        "(Device_SN, " & _
                        "Device_DateRec, " & _
                        "Device_DateBill, " & _
                        "Device_ManufWrty, " & _
                        "Device_PSSWrty, " & _
                        "Device_Cnt, " & _
                        "Device_RecWorkDate, " & _
                        "Tray_ID, " & _
                        "Loc_ID, " & _
                        "WO_ID, " & _
                        "WO_ID_Out, " & _
                        "Model_ID, " & _
                        "Sku_ID, " & _
                        "Shift_ID_Rec) " & _
                        "VALUES " & _
                        "('" & ckDeviceSN & "', " & _
                        "'" & Gui.Receiving.FormatDate(Now) & "', " & _
                        vDateBill & _
                        rLoad("OEMWrtyLabor") & ", " & _
                        rLoad("PSSWrty") & ", " & _
                        "1, " & _
                        "'" & PSS.Core.[Global].ApplicationUser.Workdate & "', " & _
                        tray_id & ", " & _
                        ckLocID & ", " & _
                        wo_id & ", " & _
                        wo_id & ", " & _
                        ckModelID & ", " & _
                        ckSKUid & ", " & _
                        PSS.Core.[Global].ApplicationUser.IDShift & ")"

                        blnDevice = ds.OrderEntryUpdateDelete(strSQL)
                        System.Windows.Forms.Application.DoEvents()

                        '//*********************************************************************************
                        '//Get the device ID in order to create the tcellopt record
                        '//You can not use the idTransaction function because it runs too slow to function
                        '//It locks up the system
                        '//*********************************************************************************
                        dtDevice = ds.OrderEntrySelect("SELECT device_id FROM tdevice WHERE Device_SN = '" & ckDeviceSN & "' AND WO_ID = " & wo_id)
                        r = dtDevice.Rows(0)
                        System.Windows.Forms.Application.DoEvents()
                        device_id = r("Device_ID")


                        '**********************************
                        'added by Lan 02/01/2007
                        'tcellop_WipOwner will be waiting part if device is in the waiting part state
                        '**********************************
                        Dim dt1 As DataTable
                        Dim iWaitingPartWIP As Integer = 0

                        Try
                            strSQL = "select WHP_RcvdFlag from twarehousepalletload WHERE WHP_BinLocation = '" & ckWOname & "' AND WHP_PieceIdentifier = '" & ckDeviceSN & "';"
                            dt1 = ds.OrderEntrySelect(strSQL)
                            System.Windows.Forms.Application.DoEvents()
                            If dt1.Rows.Count > 0 Then
                                If Not IsDBNull(dt1.Rows(0)("WHP_RcvdFlag")) Then
                                    iWaitingPartWIP = dt1.Rows(0)("WHP_RcvdFlag")
                                End If
                            End If

                        Catch ex As Exception
                        Finally
                            If Not IsNothing(dt1) Then
                                dt1.Dispose()
                                dt1 = Nothing
                            End If
                        End Try
                        '**********************************



                        '//*********************************************************************************
                        '//If the device ID is obtained, then the tcellopt record can be created
                        '//*********************************************************************************
                        '//Verify if tcellopt already has this device
                        strSQL = "SELECT device_ID FROM tcellopt WHERE Device_ID = " & device_id
                        Dim dtDup As DataTable = ds.OrderEntrySelect(strSQL)
                        If dtDup.Rows.Count < 1 Then
                            System.Windows.Forms.Application.DoEvents()
                            If device_id > 0 Then
                                '//Insert into tcellopt
                                strSQL = "INSERT INTO TCELLOPT " & _
                                "(Cellopt_IMEI, " & _
                                "Cellopt_OutIMEI, " & _
                                "Cellopt_CSN, " & _
                                "Cellopt_OutCSN, " & _
                                "Cellopt_MSN, " & _
                                "Cellopt_OutMSN, " & _
                                "Cellopt_SUGIn, " & _
                                "Cellopt_SUGOut, " & _
                                "CellOpt_Transceiver, " & _
                                "Cellopt_WIPOwner, " & _
                                "Cellopt_WIPEntryDt, " & _
                                "Device_ID)" & _
                                "VALUES " & _
                                "('" & ckDeviceSN & "', " & _
                                "'" & ckDeviceSN & "', " & _
                                "'" & ckHEX & "', " & _
                                "'" & ckHEX & "', " & _
                                "'" & ckHEX & "', " & _
                                "'" & ckHEX & "', " & _
                                "'" & ckSJUG & "', " & _
                                "'" & ckSJUG & "', " & _
                                "'" & ckSJUG & "', "

                                'Lan added condition on 02/01/2007
                                If iWaitingPartWIP = 13 Or iWaitingPartWIP = 63 Or iWaitingPartWIP = 64 Then
                                    strSQL &= iWaitingPartWIP & ", "
                                Else
                                    strSQL &= iGroup_id & ", "
                                End If

                                strSQL &= "'" & Gui.Receiving.FormatDate(Now) & "', "
                                strSQL &= device_id & ")"

                                blnDevice = ds.OrderEntryUpdateDelete(strSQL)
                                System.Windows.Forms.Application.DoEvents()
                            End If
                        End If

                        '//*********************************************************************************
                        '//The insert of the device is complete
                        '//Update flgReceived in cstIncomingData - This will prevent the device from being
                        '//received again. It is also the trigger used for the XML file to determine if the
                        '//device is in the PSS.Net system
                        '//*********************************************************************************
                        'If ckDeviceSN > 0 Then
                        If Trim(ckDeviceSN) <> "" Then
                            '//New January 4, 2007
                            strSQL = "UPDATE cstincomingdata SET flgReceived = 1, Device_ID =  " & device_id & " WHERE csin_ESN = '" & ckDeviceSN & "' AND csin_RepairOrderNum = '" & ckWOname & "' AND flgReceived = 0"
                            blnCST_Update = ds.OrderEntryUpdateDelete(strSQL)
                        End If
                    End If
                    System.Windows.Forms.Application.DoEvents()


                    '//*********************************************************************************
                    '//Determine if the billcode_id is greater than 0. If so then bill device
                    '//*********************************************************************************

                    'If device_id > 0 Then
                    'RemoveAllBillCodes(device_id)
                    'End If
                    Try
                        If ibillcode > 0 Then
                            LoadTray(tray_id)
                            System.Windows.Forms.Application.DoEvents()
                            LoadDevice(ckDeviceSN)
                            System.Windows.Forms.Application.DoEvents()
                            addBillcode(ibillcode)
                            System.Windows.Forms.Application.DoEvents()
                            HotKeysF12(tray_id, device_id)
                        End If
                    Catch ex As Exception
                        MsgBox("This device can not be billed. The billcode is not defined for this device.", MsgBoxStyle.Critical, "ERROR")
                    End Try



                    '//*********************************************************************************
                    '//Determine if the laboramount is greater than 0. If so then bill device
                    '//*********************************************************************************

                    Try
                        If ckLaborAmount > 0 Then
                            LoadTray(tray_id)
                            System.Windows.Forms.Application.DoEvents()
                            LoadDevice(ckDeviceSN)
                            System.Windows.Forms.Application.DoEvents()
                            addBillcode(1010) 'WipeDown
                            System.Windows.Forms.Application.DoEvents()
                            addBillcode(1171) 'WipeDown Lens Tape
                            System.Windows.Forms.Application.DoEvents()
                            HotKeysF12(tray_id, device_id)

                            '//December 14, 2006
                            '//This is being removed because the billcode 1010 will charge a service of 4.50
                            '//This would cause possible duplication of charge
                            'If device_id > 0 Then
                            'strSQL = "UPDATE tdevice SET Device_LaborCharge = " & ckLaborAmount & " WHERE Device_ID = " & device_id
                            'blnLaborUpdate = ds.OrderEntryUpdateDelete(strSQL)
                            'If blnLaborUpdate = False Then
                            'MsgBox("The device labor charge could NOT be updated", MsgBoxStyle.Critical, "ERROR")
                            'End If
                            'End If
                            '//Update Labor Charge

                        End If
                    Catch ex As Exception
                        MsgBox("This device can not be billed. The billcode is not defined for this device.", MsgBoxStyle.Critical, "ERROR")
                    End Try

                    '//*********************************************************************************
                    '//New December 13, 2006
                    '//Update values in twarehousepallet and twarehousepalletload
                    '//*********************************************************************************
                    Dim blnWarehouseUpdate As Boolean
                    Try
                        If Len(Trim(ckWOname)) > 0 And Len(Trim(ckDeviceSN)) > 0 Then
                            strSQL = "UPDATE twarehousepallet SET WHPalletClosed = 1, WHP_PalletRcvd = 1 WHERE WHPallet_Number = '" & ckWOname & "'"
                            blnWarehouseUpdate = ds.OrderEntryUpdateDelete(strSQL)
                            System.Windows.Forms.Application.DoEvents()
                            strSQL = "UPDATE twarehousepalletload SET WHP_RcvdFlag = " & iGroup_id & " WHERE WHP_BinLocation = '" & ckWOname & "' AND WHP_PieceIdentifier = '" & ckDeviceSN & "'"
                            blnWarehouseUpdate = ds.OrderEntryUpdateDelete(strSQL)
                            System.Windows.Forms.Application.DoEvents()
                        End If
                    Catch ex As Exception
                    End Try

                    '//*********************************************************************************
                    '//Reset data elements
                    '//*********************************************************************************
                    ckProdID = ""
                    ckWOname = ""
                    ckLocID = ""
                    ckGroupID = ""
                    ckSKUlength = ""
                    ckSKUid = ""
                    ckDeviceSN = ""
                    ckModelID = ""
                    ckItemNum = 0
                    ckLaborAmount = 0
                    wo_id = 0
                    tray_id = 0
                    device_id = 0
                    ibillcode = 0
                End If
            Next

            '//*********************************************************************************
            '//reset data values
            '//*********************************************************************************
            clearDataValues()
            '//*********************************************************************************
            '//clear data from screen
            '//*********************************************************************************
            lblPart.Text = ""
            lblManufacturer.Text = ""
            lblModel.Text = ""
            lblCarrier.Text = ""
            lblEnterprise.Text = ""
            txtDeviceSN.Text = ""
            lblSTATUS.Text = ""
            lblSTATUS_DeviceSN.Text = ""
            lblSTATUS_RejectReason.Text = ""
            '//*********************************************************************************
            '//change panel to default color
            '//*********************************************************************************
            pnlStatus.BackColor = Color.LightSteelBlue
            '//*********************************************************************************
            '//clear datagrids
            '//*********************************************************************************
            dataGrid.Clear()
            dataGridReject.Clear()
            '//*********************************************************************************
            '//reset counter
            '//*********************************************************************************
            lblCount.Text = "0"
           

            Me.Enabled = True
            '//*********************************************************************************
            '//set focus back to device sn
            '//*********************************************************************************
            txtDeviceSN.Enabled = True
            txtDeviceSN.Focus()

            Cursor.Current = Cursors.Default

        End Sub

        Private Sub txtDeviceSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged

        End Sub


        Private Function addBillcode(ByVal tBillCode As Integer) As Boolean

            addBillcode = False

            Try

                'Get Part Data Information
                _device.AddPart(tBillCode)
                System.Windows.Forms.Application.DoEvents()

                addBillcode = True
            Catch ex As Exception
                'MsgBox(ex.ToString)
                'MsgBox("This device could not be set to the billcode by this process. Please use the technician screen to RUR this device.", MsgBoxStyle.OKOnly, "ERROR")
                MsgBox("This device can not be billed. The billcode is not defined for this device.", MsgBoxStyle.Critical, "ERROR")
            End Try

        End Function


        Private Sub RemoveAllBillCodes(ByVal vDeviceID As Long)

            Dim strSQL As String
            Dim dt As PSS.Data.Production.Joins
            Dim dtSelect As DataTable
            Dim xCount As Integer = 0
            Dim rSelect As DataRow
            Dim blnPartsDelete As Boolean

            If vDeviceID > 0 Then
                strSQL = "SELECT DBill_ID FROM tdevicebill where device_id = " & vDeviceID
                dtSelect = dt.OrderEntrySelect(strSQL)

                For xCount = 0 To dtSelect.Rows.Count - 1
                    rSelect = dtSelect.Rows(xCount)
                    If rSelect("Dbill_ID") > 0 Then
                        Try
                            strSQL = "DELETE FROM tpartscodes WHERE DBill_ID = " & rSelect("DBill_ID")
                            blnPartsDelete = dt.OrderEntryUpdateDelete(strSQL)
                        Catch ex As Exception
                            MsgBox(ex.ToString)
                        End Try
                    End If
                Next

                Try
                    strSQL = "DELETE FROM tdevicebill where device_id = " & vDeviceID
                    Dim blnAction As Boolean = dt.OrderEntryUpdateDelete(strSQL)
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                '_device = Nothing
                'Me.LoadDevice()

            End If

        End Sub

        Private Sub LoadDevice(ByVal mDeviceSN As String)
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(mDeviceSN) & "'")
                _device = New Device(__device(0)("Device_ID"))
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(mDeviceSN) Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
            End Try
        End Sub

        Private Sub LoadTray(ByVal mTrayID)

            If IsNumeric(mTrayID) Then
                Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(mTrayID)
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


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End Sub


        Private Sub checkOEMwrty_Motorola()

            Dim strValue As String = InputBox("Scan the HEX Serial Number(CDMA)/ MSN (GSM)", "MSN")
            Try
                Dim mESNcheck As Long = CLng(strValue)
            Catch ex As Exception
            End Try
            '//This should automatically set the value to 0 if no entry is provided
            If Len(Trim(strValue)) < 1 Then
                strValue = "0"
            End If

            Dim strValue2 As String = "0"

            If Trim(strValue) <> "0" Then
                strValue2 = InputBox("Scan the SJUG Number", "SJUG")
                '//This should automatically set the value to 0 if no entry is provided
                If Len(Trim(strValue2)) < 1 Then
                    strValue2 = "0"
                End If
            End If

            lblNote.Text = "HEX Serial Number" & vbCrLf & strValue & vbCrLf & "SJUG Number" & vbCrLf & strValue2
            lblNote.Visible = True

            '//****************************************************************
            '//This section should never happen - RETIRED
            If Len(Trim(strValue)) < 1 Then
                strValue = InputBox("Scan the HEX Serial Number(CDMA)/ MSN (GSM)", "Request for Information")
                System.Windows.Forms.Application.DoEvents()
                lblNote.Text = "HEX Serial Number/ MSN Value" & vbCrLf & strValue & vbCrLf & "SJUG Number" & vbCrLf & strValue2
                lblNote.Visible = True
                If Len(Trim(strValue)) < 1 Then
                    MsgBox("You did not enter a valid HEX Serial Number/ MSN. Please identify the OEM Warranty manually.", MsgBoxStyle.Information, "MSN Number")
                    Exit Sub
                End If
            End If
            If Len(Trim(strValue2)) < 1 Then
                strValue = InputBox("Scan the SJUG Number", "SJUG")
                System.Windows.Forms.Application.DoEvents()
                lblNote.Text = "HEX Serial Number" & vbCrLf & strValue & vbCrLf & "SJUG Number" & strValue2
                lblNote.Visible = True
                If Len(Trim(strValue2)) < 1 Then
                    MsgBox("You did not enter a valid SJUG Number. Please identify the OEM Warranty manually.", MsgBoxStyle.Information, "SJUG Number")
                    'Exit Sub
                End If
            End If
            '//This section should never happen - RETIRED
            '//****************************************************************

            mHEX = strValue
            strValue2 = UCase(strValue2)
            mSJUG = UCase(strValue2)

            If Len(Trim(mHEX)) < 2 Then
                '//No SUG to be determined
                btnLoad.Focus()
                Exit Sub
            End If

            '//Check Data
            Dim mYear As String
            Dim vYear As String
            Dim mMonth As String
            Dim vMonth As String
            Dim mWrty As String
            Dim vWrty As String

            mYear = UCase(Mid(strValue, 9, 1))
            Select Case mYear
                Case "A"
                    vYear = "2000"
                Case "B"
                    vYear = "2001"
                Case "C"
                    vYear = "2002"
                Case "D"
                    vYear = "2003"
                Case "E"
                    vYear = "2004"
                Case "F"
                    vYear = "2005"
                Case "G"
                    vYear = "2006"
                Case "H"
                    vYear = "2007"
                Case Else
                    vYear = "1999"
            End Select



            mMonth = UCase(Mid(strValue, 10, 1))
            Select Case mMonth
                Case "A"
                    vMonth = "1"
                Case "B"
                    vMonth = "1"
                Case "C"
                    vMonth = "2"
                Case "D"
                    vMonth = "2"
                Case "E"
                    vMonth = "3"
                Case "F"
                    vMonth = "3"
                Case "G"
                    vMonth = "4"
                Case "H"
                    vMonth = "4"
                Case "J"
                    vMonth = "5"
                Case "K"
                    vMonth = "5"
                Case "L"
                    vMonth = "6"
                Case "M"
                    vMonth = "6"
                Case "N"
                    vMonth = "7"
                Case "P"
                    vMonth = "7"
                Case "Q"
                    vMonth = "8"
                Case "R"
                    vMonth = "8"
                Case "S"
                    vMonth = "9"
                Case "T"
                    vMonth = "9"
                Case "U"
                    vMonth = "10"
                Case "V"
                    vMonth = "10"
                Case "W"
                    vMonth = "11"
                Case "X"
                    vMonth = "11"
                Case "Y"
                    vMonth = "12"
                Case "Z"
                    vMonth = "12"
                Case Else
                    vMonth = "1"
            End Select

            If Len(Trim(strValue)) > 10 Then
                mWrty = UCase(Mid(strValue, 11, 1))
                Select Case mWrty
                    Case "A"
                        vWrty = "365"
                    Case "B"
                        vWrty = "1095"
                    Case "C"
                        vWrty = "1825"
                    Case "D"
                        vWrty = "1095"
                    Case "E"
                        vWrty = "0"
                    Case "F"
                        vWrty = "90"
                    Case "H"
                        vWrty = "1095"
                    Case "J"
                        vWrty = "365"
                    Case "L"
                        vWrty = "365"
                    Case "M"
                        vWrty = "365"
                    Case "N"
                        vWrty = "1825"
                    Case "P"
                        vWrty = "1825"
                    Case "Q"
                        vWrty = "1095"
                    Case "R"
                        vWrty = "1095"
                    Case "S"
                        vWrty = "1095"
                    Case "T"
                        vWrty = "0"
                    Case "U"
                        vWrty = "90"
                    Case "W"
                        vWrty = "1460"
                    Case "X"
                        vWrty = "1825"
                    Case "Y"
                        vWrty = "1095"
                    Case "Z"
                        vWrty = "1095"
                    Case Else
                        vWrty = "365"
                End Select
            Else
                vWrty = "365"
            End If


            Dim mDate As Date = vMonth & "/1/" & vYear
            Dim mDateExp As String = DateAdd(DateInterval.Day, CInt(vWrty), mDate)

            Dim mNow As Date = Gui.Receiving.FormatDateShort(Now)
            If mNow < mDateExp Then
                Me.chkOEMwrtyLabor.Checked = True
                btnLoad.Focus()
            Else
                Me.chkOEMwrtyLabor.Checked = False
                btnLoad.Focus()
            End If

        End Sub

        Private Sub HotKeysF12(ByVal mTray As Long, ByVal mDevice As Long)

            If Len(Trim(mTray)) > 0 Then
                If Len(Trim(mDevice)) > 0 Then
                    UpdateBilling()
                End If
            End If

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


        Private Sub MainGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainGrid.Click

        End Sub

        Private Sub MainGrid_BeforeDelete(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles MainGrid.BeforeDelete
            mDelKey = MainGrid.Columns(1).Value
        End Sub


        Private Sub MainGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseUp
        End Sub

        '*******************************************************Lan 11/01/2006
        Private Sub CheckOEMwrty_Nokia()
            Dim strValue As String = InputBox("Pleas scan the Nokia code:", "Scan Nokia code")
            strValue &= InputBox("Pleas add additional character if the first scan (" & strValue & ") missed:", "Scan Nokia code")

            '//This should automatically set the value to 0 if no entry is provided
            If Len(Trim(strValue)) < 1 Then
                strValue = "0"
                mHEX = strValue
                MessageBox.Show("Invalid Code!!", "Scan Nokia code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            strValue = UCase(Trim(strValue))
            mHEX = strValue

            lblNote.Text = "Nokia Code:" & vbCrLf & strValue
            lblNote.Visible = True

            If Len(Trim(mHEX)) < 2 Then
                '//No SUG to be determined
                MessageBox.Show("Invalid Code!!", "Scan Nokia code", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '//Check Data
            Dim mYear As String = ""
            Dim vYear As String = ""
            Dim mMonth As String = ""
            Dim vMonth As String = ""
            Dim mWrty As String = ""
            Dim vWrty As String = ""
            Dim i As Integer = 1
            Dim iLetterIndex As Integer = 0

            For i = 1 To strValue.Length
                If iLetterIndex = 0 Then                    '1st Letter
                    mMonth = UCase(Mid(strValue, i, 1))
                    Select Case mMonth
                        Case "A"
                            vMonth = "1"
                            iLetterIndex += 1
                        Case "B"
                            vMonth = "2"
                            iLetterIndex += 1
                        Case "C"
                            vMonth = "3"
                            iLetterIndex += 1
                        Case "D"
                            vMonth = "4"
                            iLetterIndex += 1
                        Case "E"
                            vMonth = "5"
                            iLetterIndex += 1
                        Case "F"
                            vMonth = "6"
                            iLetterIndex += 1
                        Case "G"
                            vMonth = "7"
                            iLetterIndex += 1
                        Case "H"
                            vMonth = "8"
                            iLetterIndex += 1
                        Case "I"
                            vMonth = "9"
                            iLetterIndex += 1
                        Case "J"
                            vMonth = "10"
                            iLetterIndex += 1
                        Case "K"
                            vMonth = "11"
                            iLetterIndex += 1
                        Case "L"
                            vMonth = "12"
                            iLetterIndex += 1
                    End Select
                ElseIf iLetterIndex = 1 Then                '2nd letter
                    mYear = UCase(Mid(strValue, i, 1))
                    Select Case mYear
                        Case "H"
                            vYear = "2000"
                            iLetterIndex += 1
                        Case "I"
                            vYear = "2001"
                            iLetterIndex += 1
                        Case "J"
                            vYear = "2002"
                            iLetterIndex += 1
                        Case "K"
                            vYear = "2003"
                            iLetterIndex += 1
                        Case "L"
                            vYear = "2004"
                            iLetterIndex += 1
                        Case "M"
                            vYear = "2005"
                            iLetterIndex += 1
                        Case "N"
                            vYear = "2006"
                            iLetterIndex += 1
                    End Select
                ElseIf iLetterIndex = 2 Then                '3rd letter
                    mWrty = UCase(Mid(strValue, i, 1))
                    Select Case mWrty
                        Case "A"
                            vWrty = "1095"
                            iLetterIndex += 1
                        Case "B"
                            vWrty = "365"
                            iLetterIndex += 1
                        Case "C"
                            vWrty = "90"
                            iLetterIndex += 1
                        Case "D"
                            vWrty = "0"
                            iLetterIndex += 1
                        Case "E"
                            vWrty = "730"
                            iLetterIndex += 1
                        Case "F"
                            vWrty = "1825"
                            iLetterIndex += 1
                    End Select
                End If
            Next i
            If iLetterIndex = 2 And vWrty = "" Then 'No 3rd letter
                vWrty = "365"
            End If


            Dim mDate As Date = vMonth & "/1/" & vYear
            Dim mDateExp As String = DateAdd(DateInterval.Day, CInt(vWrty), mDate)

            Dim mNow As Date = Gui.Receiving.FormatDateShort(Now)
            If mNow < mDateExp Then
                Me.chkOEMwrtyLabor.Checked = True
                btnLoad.Focus()
            Else
                Me.chkOEMwrtyLabor.Checked = False
                btnLoad.Focus()
            End If

        End Sub
        '*******************************************************Lan 11/01/2006
        Private Sub chkOEMwrtyLabor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOEMwrtyLabor.CheckedChanged

        End Sub

        '*******************************************************
        'moved from frmAdminCellstar.vb by Lan on 02/20/2007
        '*******************************************************
        Private Sub cmdLoadXML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoadXML.Click
            Dim iParentGroupID As Integer = PSS.Core.[Global].ApplicationUser.GroupID
            Dim objCS As New PSS.Data.Buisness.CellStar()
            Dim objGen As New PSS.Data.Buisness.Generic()
            Dim iResult As Integer = 0
            Dim dt1 As DataTable
            Dim strFile As String
            Dim strDir As String = "\\SVR_PSSNET\CellstarFTP\Incoming\"
            Dim strFileLoc As String = ""
            Dim strRejectRptDir As String = "P:\Dept\Cellstar\XLM Load Reject Report\"
            Dim strRejectRptFileName As String = "CS Could not Load File " & Format(Now, "yyyy-MM-dd hhmmss") & ".xls"
            Dim strNewPartNumbers As String = ""

            Try
                Me.Enabled = False
                '*****************************************
                'get 1st XML file name in given directory
                '*****************************************
                strFile = Dir(strDir & "*.xml")

                MsgBox(strFile)

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                '*****************************************
                'create datatable for reject report
                '*****************************************
                dt1 = objCS.CreateCSAdvanceRecXML_RejectRptDt()

                '*******************************
                'loop through given directory
                '*******************************
                Do Until strFile = Nothing
                    strFileLoc = strDir & strFile

                    If New FileInfo(strFileLoc).Length <> 0 Then
                        '*********************************
                        'load data in XML file into system
                        '*********************************
                        iResult += objCS.loadAdvanceShipNotice("\\SVR_PSSNET\CellstarFTP\Incoming\" & strFile, iParentGroupID, strNewPartNumbers, dt1)

                        '*********************************
                        'move XML file to archive folder
                        '*********************************
                        System.IO.File.Move(strFileLoc, strDir & "Archive\" & strFile)
                    Else
                        '****************************************************
                        'move XML file to BadFile folder if file size is zero
                        '****************************************************
                        System.IO.File.Move(strFileLoc, strDir & "BadFiles\" & strFile)

                    End If
                    strFile = Dir()
                Loop

                System.Windows.Forms.Application.DoEvents()

                If iResult > 0 Then
                    MessageBox.Show(iResult & " device(s) have been loaded.", "Load XML File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    MessageBox.Show("No device is loaded.", "Load XML File", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                System.Windows.Forms.Application.DoEvents()

                '*******************************************
                'print new part number to user
                '*******************************************
                If strNewPartNumbers <> "" Then
                    objCS.PrintCS_NewPartNumber_Rpt(strNewPartNumbers)
                    'MessageBox.Show("The following is new part number: " & Environment.NewLine & strNewPartNumbers, "New Part Number", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
                System.Windows.Forms.Application.DoEvents()

                '*******************************************
                'Create report if required field are missing
                '*******************************************
                If dt1.Rows.Count > 0 Then
                    objGen.CreateExelReport(dt1, 1, strRejectRptDir & strRejectRptFileName)
                    Me.MinimizeBox = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Load Brightpoint Receive XML File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                objCS = Nothing
                objGen = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                Me.Enabled = True

                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub
        '*******************************************************

    End Class

End Namespace
