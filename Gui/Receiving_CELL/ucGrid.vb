Public Class ucGrid
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents lblCountVAL As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
    Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
    Friend WithEvents btnContinue As System.Windows.Forms.Button
    Friend WithEvents grpMotorola As System.Windows.Forms.GroupBox
    Friend WithEvents lblCustomerReason As System.Windows.Forms.Label
    Friend WithEvents txtMIN As System.Windows.Forms.TextBox
    Friend WithEvents lblMIN As System.Windows.Forms.Label
    Friend WithEvents txtCarrModelCode As System.Windows.Forms.TextBox
    Friend WithEvents lblCarrModelCode As System.Windows.Forms.Label
    Friend WithEvents txtRMANum As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dteExpShipDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPicassoNum As System.Windows.Forms.TextBox
    Friend WithEvents txtCarModelCode As System.Windows.Forms.TextBox
    Friend WithEvents cboAirCarrCode As System.Windows.Forms.ComboBox
    Friend WithEvents txtCustRef As System.Windows.Forms.TextBox
    Friend WithEvents txtCourierTrackIN As System.Windows.Forms.TextBox
    Friend WithEvents lblRMANumber As System.Windows.Forms.Label
    Friend WithEvents lblExpectedShipTime As System.Windows.Forms.Label
    Friend WithEvents lblExpectedShipDate As System.Windows.Forms.Label
    Friend WithEvents lblIncomingIMEI As System.Windows.Forms.Label
    Friend WithEvents lblPicassoNumber As System.Windows.Forms.Label
    Friend WithEvents lblCarrierModelCode As System.Windows.Forms.Label
    Friend WithEvents lblTransceiverCode As System.Windows.Forms.Label
    Friend WithEvents lblProductAPCCode As System.Windows.Forms.Label
    Friend WithEvents lblTransactionCode As System.Windows.Forms.Label
    Friend WithEvents lblAirtimeCarrierCode As System.Windows.Forms.Label
    Friend WithEvents lblCustomerReference As System.Windows.Forms.Label
    Friend WithEvents lblCourierTrackingIn As System.Windows.Forms.Label
    Friend WithEvents txtModel As System.Windows.Forms.TextBox
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents lblProductCode As System.Windows.Forms.Label
    Friend WithEvents lblPOPformat As System.Windows.Forms.Label
    Friend WithEvents lblExp As System.Windows.Forms.Label
    Friend WithEvents lblPOPexplain As System.Windows.Forms.Label
    Friend WithEvents txtPOP As System.Windows.Forms.TextBox
    Friend WithEvents lblPOP As System.Windows.Forms.Label
    Friend WithEvents cboDateCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblDateCode As System.Windows.Forms.Label
    Friend WithEvents lblTrayVAL As System.Windows.Forms.Label
    Friend WithEvents lblTray As System.Windows.Forms.Label
    Friend WithEvents lblCustomerVAL As System.Windows.Forms.Label
    Friend WithEvents lblCustomer As System.Windows.Forms.Label
    Friend WithEvents cboComplaint As PSS.Gui.Controls.ComboBox
    Friend WithEvents txtIncIMEI As System.Windows.Forms.TextBox
    Friend WithEvents txtTransceiver As System.Windows.Forms.TextBox
    Friend WithEvents cboTransaction As System.Windows.Forms.ComboBox
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents cboAPC As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ucGrid))
        Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Me.lblCountVAL = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtDeviceSN = New System.Windows.Forms.TextBox()
        Me.lblDeviceSN = New System.Windows.Forms.Label()
        Me.btnContinue = New System.Windows.Forms.Button()
        Me.grpMotorola = New System.Windows.Forms.GroupBox()
        Me.cboComplaint = New PSS.Gui.Controls.ComboBox()
        Me.lblCustomerReason = New System.Windows.Forms.Label()
        Me.txtMIN = New System.Windows.Forms.TextBox()
        Me.lblMIN = New System.Windows.Forms.Label()
        Me.txtCarrModelCode = New System.Windows.Forms.TextBox()
        Me.lblCarrModelCode = New System.Windows.Forms.Label()
        Me.txtRMANum = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.dteExpShipDate = New System.Windows.Forms.DateTimePicker()
        Me.txtIncIMEI = New System.Windows.Forms.TextBox()
        Me.txtPicassoNum = New System.Windows.Forms.TextBox()
        Me.txtCarModelCode = New System.Windows.Forms.TextBox()
        Me.txtTransceiver = New System.Windows.Forms.TextBox()
        Me.cboTransaction = New System.Windows.Forms.ComboBox()
        Me.cboAirCarrCode = New System.Windows.Forms.ComboBox()
        Me.txtCustRef = New System.Windows.Forms.TextBox()
        Me.txtCourierTrackIN = New System.Windows.Forms.TextBox()
        Me.lblRMANumber = New System.Windows.Forms.Label()
        Me.lblExpectedShipTime = New System.Windows.Forms.Label()
        Me.lblExpectedShipDate = New System.Windows.Forms.Label()
        Me.lblIncomingIMEI = New System.Windows.Forms.Label()
        Me.lblPicassoNumber = New System.Windows.Forms.Label()
        Me.lblCarrierModelCode = New System.Windows.Forms.Label()
        Me.lblTransceiverCode = New System.Windows.Forms.Label()
        Me.lblProductAPCCode = New System.Windows.Forms.Label()
        Me.lblTransactionCode = New System.Windows.Forms.Label()
        Me.lblAirtimeCarrierCode = New System.Windows.Forms.Label()
        Me.lblCustomerReference = New System.Windows.Forms.Label()
        Me.lblCourierTrackingIn = New System.Windows.Forms.Label()
        Me.txtModel = New System.Windows.Forms.TextBox()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.lblProductCode = New System.Windows.Forms.Label()
        Me.cboAPC = New System.Windows.Forms.ComboBox()
        Me.lblPOPformat = New System.Windows.Forms.Label()
        Me.lblExp = New System.Windows.Forms.Label()
        Me.lblPOPexplain = New System.Windows.Forms.Label()
        Me.txtPOP = New System.Windows.Forms.TextBox()
        Me.lblPOP = New System.Windows.Forms.Label()
        Me.cboDateCode = New System.Windows.Forms.ComboBox()
        Me.lblDateCode = New System.Windows.Forms.Label()
        Me.lblTrayVAL = New System.Windows.Forms.Label()
        Me.lblTray = New System.Windows.Forms.Label()
        Me.lblCustomerVAL = New System.Windows.Forms.Label()
        Me.lblCustomer = New System.Windows.Forms.Label()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMotorola.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCountVAL
        '
        Me.lblCountVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCountVAL.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountVAL.Location = New System.Drawing.Point(472, 8)
        Me.lblCountVAL.Name = "lblCountVAL"
        Me.lblCountVAL.Size = New System.Drawing.Size(64, 32)
        Me.lblCountVAL.TabIndex = 0
        Me.lblCountVAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCount
        '
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Location = New System.Drawing.Point(432, 8)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(40, 16)
        Me.lblCount.TabIndex = 0
        Me.lblCount.Text = "Count"
        '
        'MainGrid
        '
        Me.MainGrid.AllowColMove = False
        Me.MainGrid.AllowColSelect = False
        Me.MainGrid.AllowDelete = True
        Me.MainGrid.AllowFilter = False
        Me.MainGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.MainGrid.AllowSort = False
        Me.MainGrid.AllowUpdate = False
        Me.MainGrid.AlternatingRows = True
        Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MainGrid.CaptionHeight = 17
        Me.MainGrid.CollapseColor = System.Drawing.Color.Black
        Me.MainGrid.DataChanged = False
        Me.MainGrid.BackColor = System.Drawing.Color.Empty
        Me.MainGrid.ExpandColor = System.Drawing.Color.Black
        Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
        Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.MainGrid.Location = New System.Drawing.Point(8, 72)
        Me.MainGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.MainGrid.PreviewInfo.ZoomFactor = 75
        Me.MainGrid.PrintInfo.ShowOptionsDialog = False
        Me.MainGrid.RecordSelectorWidth = 16
        GridLines1.Color = System.Drawing.Color.DarkGray
        GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.MainGrid.RowDivider = GridLines1
        Me.MainGrid.RowHeight = 15
        Me.MainGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.MainGrid.ScrollTips = False
        Me.MainGrid.Size = New System.Drawing.Size(520, 376)
        Me.MainGrid.TabIndex = 0
        Me.MainGrid.Text = "C1TrueDBGrid1"
        Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Style11{}Style12{}Style13{}Style5{}Style4{}Style7{}Style6{}Style1{}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Ce" & _
        "nter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Inactive" & _
        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
        "tion{AlignHorz:Center;}Editor{}Normal{Font:Verdana, 8.25pt;}Style10{AlignHorz:Ne" & _
        "ar;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}EvenRow{BackColor:" & _
        "Aqua;}OddRow{}RecordSelector{AlignImage:Center;}Style8{}Style3{}Style2{}Group{Ba" & _
        "ckColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style9{}</Data></S" & _
        "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect" & _
        "=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
        "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
        "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
        "ClientRect>0, 0, 518, 374</ClientRect><BorderSide>0</BorderSide><CaptionStyle pa" & _
        "rent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRow" & _
        "Style parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Styl" & _
        "e13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=" & _
        """Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pare" & _
        "nt=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><" & _
        "OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSel" & _
        "ector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pare" & _
        "nt=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles>" & _
        "<Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pare" & _
        "nt=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=" & _
        """Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""" & _
        "Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""" & _
        "Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headi" & _
        "ng"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=" & _
        """Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</ho" & _
        "rzSplits><Layout>Modified</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><Cl" & _
        "ientArea>0, 0, 518, 374</ClientArea></Blob>"
        '
        'txtDeviceSN
        '
        Me.txtDeviceSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDeviceSN.Location = New System.Drawing.Point(72, 8)
        Me.txtDeviceSN.Name = "txtDeviceSN"
        Me.txtDeviceSN.Size = New System.Drawing.Size(168, 20)
        Me.txtDeviceSN.TabIndex = 1
        Me.txtDeviceSN.Text = ""
        '
        'lblDeviceSN
        '
        Me.lblDeviceSN.Location = New System.Drawing.Point(8, 8)
        Me.lblDeviceSN.Name = "lblDeviceSN"
        Me.lblDeviceSN.Size = New System.Drawing.Size(64, 16)
        Me.lblDeviceSN.TabIndex = 44
        Me.lblDeviceSN.Text = "Device SN"
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(360, 264)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(144, 23)
        Me.btnContinue.TabIndex = 15
        Me.btnContinue.Text = "Continue"
        '
        'grpMotorola
        '
        Me.grpMotorola.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboComplaint, Me.lblCustomerReason, Me.txtMIN, Me.lblMIN, Me.txtCarrModelCode, Me.lblCarrModelCode, Me.txtRMANum, Me.DateTimePicker1, Me.dteExpShipDate, Me.txtIncIMEI, Me.txtPicassoNum, Me.txtCarModelCode, Me.txtTransceiver, Me.cboTransaction, Me.cboAirCarrCode, Me.txtCustRef, Me.txtCourierTrackIN, Me.lblRMANumber, Me.lblExpectedShipTime, Me.lblExpectedShipDate, Me.lblIncomingIMEI, Me.lblPicassoNumber, Me.lblCarrierModelCode, Me.lblTransceiverCode, Me.lblProductAPCCode, Me.lblTransactionCode, Me.lblAirtimeCarrierCode, Me.lblCustomerReference, Me.lblCourierTrackingIn, Me.txtModel, Me.lblModel, Me.txtProduct, Me.lblProductCode, Me.cboAPC, Me.btnContinue})
        Me.grpMotorola.Location = New System.Drawing.Point(16, 152)
        Me.grpMotorola.Name = "grpMotorola"
        Me.grpMotorola.Size = New System.Drawing.Size(512, 296)
        Me.grpMotorola.TabIndex = 4
        Me.grpMotorola.TabStop = False
        Me.grpMotorola.Text = "Motorola"
        '
        'cboComplaint
        '
        Me.cboComplaint.Location = New System.Drawing.Point(144, 256)
        Me.cboComplaint.Name = "cboComplaint"
        Me.cboComplaint.Size = New System.Drawing.Size(152, 21)
        Me.cboComplaint.TabIndex = 14
        '
        'lblCustomerReason
        '
        Me.lblCustomerReason.Location = New System.Drawing.Point(48, 256)
        Me.lblCustomerReason.Name = "lblCustomerReason"
        Me.lblCustomerReason.Size = New System.Drawing.Size(96, 16)
        Me.lblCustomerReason.TabIndex = 0
        Me.lblCustomerReason.Text = "Complaint:"
        Me.lblCustomerReason.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'txtMIN
        '
        Me.txtMIN.Location = New System.Drawing.Point(144, 208)
        Me.txtMIN.Name = "txtMIN"
        Me.txtMIN.TabIndex = 12
        Me.txtMIN.Text = ""
        '
        'lblMIN
        '
        Me.lblMIN.Location = New System.Drawing.Point(8, 208)
        Me.lblMIN.Name = "lblMIN"
        Me.lblMIN.Size = New System.Drawing.Size(136, 16)
        Me.lblMIN.TabIndex = 0
        Me.lblMIN.Text = "MIN Number:"
        Me.lblMIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCarrModelCode
        '
        Me.txtCarrModelCode.Location = New System.Drawing.Point(144, 184)
        Me.txtCarrModelCode.Name = "txtCarrModelCode"
        Me.txtCarrModelCode.TabIndex = 11
        Me.txtCarrModelCode.Text = ""
        '
        'lblCarrModelCode
        '
        Me.lblCarrModelCode.Location = New System.Drawing.Point(8, 184)
        Me.lblCarrModelCode.Name = "lblCarrModelCode"
        Me.lblCarrModelCode.Size = New System.Drawing.Size(136, 16)
        Me.lblCarrModelCode.TabIndex = 0
        Me.lblCarrModelCode.Text = "Carrier Model Code:"
        Me.lblCarrModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRMANum
        '
        Me.txtRMANum.Location = New System.Drawing.Point(416, 480)
        Me.txtRMANum.Name = "txtRMANum"
        Me.txtRMANum.Size = New System.Drawing.Size(24, 20)
        Me.txtRMANum.TabIndex = 64
        Me.txtRMANum.Text = ""
        Me.txtRMANum.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DateTimePicker1.Location = New System.Drawing.Point(416, 456)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(24, 20)
        Me.DateTimePicker1.TabIndex = 62
        Me.DateTimePicker1.Visible = False
        '
        'dteExpShipDate
        '
        Me.dteExpShipDate.Location = New System.Drawing.Point(416, 432)
        Me.dteExpShipDate.Name = "dteExpShipDate"
        Me.dteExpShipDate.Size = New System.Drawing.Size(24, 20)
        Me.dteExpShipDate.TabIndex = 60
        Me.dteExpShipDate.Visible = False
        '
        'txtIncIMEI
        '
        Me.txtIncIMEI.Location = New System.Drawing.Point(144, 40)
        Me.txtIncIMEI.Name = "txtIncIMEI"
        Me.txtIncIMEI.TabIndex = 5
        Me.txtIncIMEI.Text = ""
        '
        'txtPicassoNum
        '
        Me.txtPicassoNum.Location = New System.Drawing.Point(248, 480)
        Me.txtPicassoNum.Name = "txtPicassoNum"
        Me.txtPicassoNum.Size = New System.Drawing.Size(24, 20)
        Me.txtPicassoNum.TabIndex = 57
        Me.txtPicassoNum.Text = ""
        Me.txtPicassoNum.Visible = False
        '
        'txtCarModelCode
        '
        Me.txtCarModelCode.Location = New System.Drawing.Point(248, 456)
        Me.txtCarModelCode.Name = "txtCarModelCode"
        Me.txtCarModelCode.Size = New System.Drawing.Size(24, 20)
        Me.txtCarModelCode.TabIndex = 56
        Me.txtCarModelCode.Text = ""
        Me.txtCarModelCode.Visible = False
        '
        'txtTransceiver
        '
        Me.txtTransceiver.Location = New System.Drawing.Point(144, 160)
        Me.txtTransceiver.Name = "txtTransceiver"
        Me.txtTransceiver.TabIndex = 10
        Me.txtTransceiver.Text = ""
        '
        'cboTransaction
        '
        Me.cboTransaction.Location = New System.Drawing.Point(144, 136)
        Me.cboTransaction.Name = "cboTransaction"
        Me.cboTransaction.Size = New System.Drawing.Size(152, 21)
        Me.cboTransaction.TabIndex = 9
        '
        'cboAirCarrCode
        '
        Me.cboAirCarrCode.Location = New System.Drawing.Point(144, 112)
        Me.cboAirCarrCode.Name = "cboAirCarrCode"
        Me.cboAirCarrCode.Size = New System.Drawing.Size(152, 21)
        Me.cboAirCarrCode.TabIndex = 8
        '
        'txtCustRef
        '
        Me.txtCustRef.Location = New System.Drawing.Point(248, 432)
        Me.txtCustRef.Name = "txtCustRef"
        Me.txtCustRef.Size = New System.Drawing.Size(24, 20)
        Me.txtCustRef.TabIndex = 50
        Me.txtCustRef.Text = ""
        Me.txtCustRef.Visible = False
        '
        'txtCourierTrackIN
        '
        Me.txtCourierTrackIN.Location = New System.Drawing.Point(144, 88)
        Me.txtCourierTrackIN.Name = "txtCourierTrackIN"
        Me.txtCourierTrackIN.TabIndex = 7
        Me.txtCourierTrackIN.Text = ""
        '
        'lblRMANumber
        '
        Me.lblRMANumber.Location = New System.Drawing.Point(280, 480)
        Me.lblRMANumber.Name = "lblRMANumber"
        Me.lblRMANumber.Size = New System.Drawing.Size(136, 16)
        Me.lblRMANumber.TabIndex = 47
        Me.lblRMANumber.Text = "RMA Number:"
        Me.lblRMANumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRMANumber.Visible = False
        '
        'lblExpectedShipTime
        '
        Me.lblExpectedShipTime.Location = New System.Drawing.Point(280, 456)
        Me.lblExpectedShipTime.Name = "lblExpectedShipTime"
        Me.lblExpectedShipTime.Size = New System.Drawing.Size(136, 16)
        Me.lblExpectedShipTime.TabIndex = 46
        Me.lblExpectedShipTime.Text = "Expected Ship Time:"
        Me.lblExpectedShipTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblExpectedShipTime.Visible = False
        '
        'lblExpectedShipDate
        '
        Me.lblExpectedShipDate.Location = New System.Drawing.Point(280, 432)
        Me.lblExpectedShipDate.Name = "lblExpectedShipDate"
        Me.lblExpectedShipDate.Size = New System.Drawing.Size(136, 16)
        Me.lblExpectedShipDate.TabIndex = 45
        Me.lblExpectedShipDate.Text = "Expected Ship Date:"
        Me.lblExpectedShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblExpectedShipDate.Visible = False
        '
        'lblIncomingIMEI
        '
        Me.lblIncomingIMEI.Location = New System.Drawing.Point(8, 40)
        Me.lblIncomingIMEI.Name = "lblIncomingIMEI"
        Me.lblIncomingIMEI.Size = New System.Drawing.Size(136, 16)
        Me.lblIncomingIMEI.TabIndex = 0
        Me.lblIncomingIMEI.Text = "Incoming IMEI:"
        Me.lblIncomingIMEI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPicassoNumber
        '
        Me.lblPicassoNumber.Location = New System.Drawing.Point(144, 480)
        Me.lblPicassoNumber.Name = "lblPicassoNumber"
        Me.lblPicassoNumber.Size = New System.Drawing.Size(104, 16)
        Me.lblPicassoNumber.TabIndex = 43
        Me.lblPicassoNumber.Text = "Picasso Number:"
        Me.lblPicassoNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblPicassoNumber.Visible = False
        '
        'lblCarrierModelCode
        '
        Me.lblCarrierModelCode.Location = New System.Drawing.Point(112, 456)
        Me.lblCarrierModelCode.Name = "lblCarrierModelCode"
        Me.lblCarrierModelCode.Size = New System.Drawing.Size(136, 16)
        Me.lblCarrierModelCode.TabIndex = 42
        Me.lblCarrierModelCode.Text = "Carrier Model Code:"
        Me.lblCarrierModelCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCarrierModelCode.Visible = False
        '
        'lblTransceiverCode
        '
        Me.lblTransceiverCode.Location = New System.Drawing.Point(8, 160)
        Me.lblTransceiverCode.Name = "lblTransceiverCode"
        Me.lblTransceiverCode.Size = New System.Drawing.Size(136, 16)
        Me.lblTransceiverCode.TabIndex = 0
        Me.lblTransceiverCode.Text = "Transceiver Code:"
        Me.lblTransceiverCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblProductAPCCode
        '
        Me.lblProductAPCCode.Location = New System.Drawing.Point(8, 16)
        Me.lblProductAPCCode.Name = "lblProductAPCCode"
        Me.lblProductAPCCode.Size = New System.Drawing.Size(136, 16)
        Me.lblProductAPCCode.TabIndex = 0
        Me.lblProductAPCCode.Text = "Product/ APC Code:"
        Me.lblProductAPCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTransactionCode
        '
        Me.lblTransactionCode.Location = New System.Drawing.Point(8, 136)
        Me.lblTransactionCode.Name = "lblTransactionCode"
        Me.lblTransactionCode.Size = New System.Drawing.Size(136, 16)
        Me.lblTransactionCode.TabIndex = 0
        Me.lblTransactionCode.Text = "Transaction Code:"
        Me.lblTransactionCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAirtimeCarrierCode
        '
        Me.lblAirtimeCarrierCode.Location = New System.Drawing.Point(8, 112)
        Me.lblAirtimeCarrierCode.Name = "lblAirtimeCarrierCode"
        Me.lblAirtimeCarrierCode.Size = New System.Drawing.Size(136, 18)
        Me.lblAirtimeCarrierCode.TabIndex = 0
        Me.lblAirtimeCarrierCode.Text = "Airtime Carrier Code:"
        Me.lblAirtimeCarrierCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCustomerReference
        '
        Me.lblCustomerReference.Location = New System.Drawing.Point(136, 432)
        Me.lblCustomerReference.Name = "lblCustomerReference"
        Me.lblCustomerReference.Size = New System.Drawing.Size(112, 16)
        Me.lblCustomerReference.TabIndex = 37
        Me.lblCustomerReference.Text = "Customer Reference:"
        Me.lblCustomerReference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblCustomerReference.Visible = False
        '
        'lblCourierTrackingIn
        '
        Me.lblCourierTrackingIn.Location = New System.Drawing.Point(8, 88)
        Me.lblCourierTrackingIn.Name = "lblCourierTrackingIn"
        Me.lblCourierTrackingIn.Size = New System.Drawing.Size(136, 16)
        Me.lblCourierTrackingIn.TabIndex = 0
        Me.lblCourierTrackingIn.Text = "Courier Tracking IN:"
        Me.lblCourierTrackingIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtModel
        '
        Me.txtModel.Location = New System.Drawing.Point(144, 64)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.TabIndex = 6
        Me.txtModel.Text = ""
        '
        'lblModel
        '
        Me.lblModel.Location = New System.Drawing.Point(8, 64)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(136, 16)
        Me.lblModel.TabIndex = 0
        Me.lblModel.Text = "Model:"
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtProduct
        '
        Me.txtProduct.Location = New System.Drawing.Point(144, 232)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(56, 20)
        Me.txtProduct.TabIndex = 13
        Me.txtProduct.Text = ""
        '
        'lblProductCode
        '
        Me.lblProductCode.Location = New System.Drawing.Point(64, 232)
        Me.lblProductCode.Name = "lblProductCode"
        Me.lblProductCode.Size = New System.Drawing.Size(80, 16)
        Me.lblProductCode.TabIndex = 0
        Me.lblProductCode.Text = "Product Code:"
        Me.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboAPC
        '
        Me.cboAPC.Location = New System.Drawing.Point(144, 16)
        Me.cboAPC.Name = "cboAPC"
        Me.cboAPC.Size = New System.Drawing.Size(64, 21)
        Me.cboAPC.TabIndex = 4
        '
        'lblPOPformat
        '
        Me.lblPOPformat.Location = New System.Drawing.Point(416, 128)
        Me.lblPOPformat.Name = "lblPOPformat"
        Me.lblPOPformat.Size = New System.Drawing.Size(100, 16)
        Me.lblPOPformat.TabIndex = 0
        Me.lblPOPformat.Text = "(yyyy-mm-dd)"
        '
        'lblExp
        '
        Me.lblExp.Location = New System.Drawing.Point(416, 128)
        Me.lblExp.Name = "lblExp"
        Me.lblExp.Size = New System.Drawing.Size(72, 16)
        Me.lblExp.TabIndex = 107
        '
        'lblPOPexplain
        '
        Me.lblPOPexplain.ForeColor = System.Drawing.Color.Blue
        Me.lblPOPexplain.Location = New System.Drawing.Point(160, 96)
        Me.lblPOPexplain.Name = "lblPOPexplain"
        Me.lblPOPexplain.Size = New System.Drawing.Size(360, 24)
        Me.lblPOPexplain.TabIndex = 0
        Me.lblPOPexplain.Text = "Date code fall out of warranty. Please enter a proof of purchase date so that war" & _
        "ranty status may be determined."
        Me.lblPOPexplain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPOP
        '
        Me.txtPOP.Location = New System.Drawing.Point(256, 128)
        Me.txtPOP.Name = "txtPOP"
        Me.txtPOP.Size = New System.Drawing.Size(152, 20)
        Me.txtPOP.TabIndex = 3
        Me.txtPOP.Text = ""
        '
        'lblPOP
        '
        Me.lblPOP.Location = New System.Drawing.Point(152, 128)
        Me.lblPOP.Name = "lblPOP"
        Me.lblPOP.Size = New System.Drawing.Size(100, 16)
        Me.lblPOP.TabIndex = 0
        Me.lblPOP.Text = "Proof of Purchase:"
        '
        'cboDateCode
        '
        Me.cboDateCode.Location = New System.Drawing.Point(72, 96)
        Me.cboDateCode.Name = "cboDateCode"
        Me.cboDateCode.Size = New System.Drawing.Size(80, 21)
        Me.cboDateCode.TabIndex = 2
        '
        'lblDateCode
        '
        Me.lblDateCode.Location = New System.Drawing.Point(8, 96)
        Me.lblDateCode.Name = "lblDateCode"
        Me.lblDateCode.Size = New System.Drawing.Size(64, 16)
        Me.lblDateCode.TabIndex = 104
        Me.lblDateCode.Text = "Date Code"
        '
        'lblTrayVAL
        '
        Me.lblTrayVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTrayVAL.Location = New System.Drawing.Point(304, 40)
        Me.lblTrayVAL.Name = "lblTrayVAL"
        Me.lblTrayVAL.Size = New System.Drawing.Size(88, 23)
        Me.lblTrayVAL.TabIndex = 0
        Me.lblTrayVAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTray
        '
        Me.lblTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTray.Location = New System.Drawing.Point(264, 48)
        Me.lblTray.Name = "lblTray"
        Me.lblTray.Size = New System.Drawing.Size(32, 16)
        Me.lblTray.TabIndex = 0
        Me.lblTray.Text = "Tray"
        '
        'lblCustomerVAL
        '
        Me.lblCustomerVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCustomerVAL.Location = New System.Drawing.Point(304, 8)
        Me.lblCustomerVAL.Name = "lblCustomerVAL"
        Me.lblCustomerVAL.Size = New System.Drawing.Size(112, 23)
        Me.lblCustomerVAL.TabIndex = 0
        '
        'lblCustomer
        '
        Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomer.Location = New System.Drawing.Point(248, 16)
        Me.lblCustomer.Name = "lblCustomer"
        Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
        Me.lblCustomer.TabIndex = 0
        Me.lblCustomer.Text = "Customer"
        '
        'ucGrid
        '
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTrayVAL, Me.lblTray, Me.lblCustomerVAL, Me.lblCustomer, Me.MainGrid, Me.lblPOPformat, Me.lblExp, Me.lblPOPexplain, Me.txtPOP, Me.lblPOP, Me.cboDateCode, Me.lblDateCode, Me.grpMotorola, Me.txtDeviceSN, Me.lblDeviceSN, Me.lblCountVAL, Me.lblCount})
        Me.Name = "ucGrid"
        Me.Size = New System.Drawing.Size(536, 488)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMotorola.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Shared mWorkOrder As Int32
    Public Shared mTray As Int32
    Public Shared mCustomer As Int32
    Public Shared mManufacturer As Int32
    Public Shared mModel As Int32
    Public Shared mSKU As Int32

    Private dtGridMain, dataGrid As DataTable
    Private DeviceType As Integer = 2
    Private GridHeight As Int32
    Private blnRecover As Boolean = False
    Private recUser As String = PSS.Core.[Global].ApplicationUser.User

    Private Sub ucGrid_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dataGrid = CreateGridDT()
        MainGrid.DataSource = dataGrid
        lblCountVAL.Text = "0"
        lblTrayVAL.Text = ""
        mTray = 0

    End Sub

    Private Function CreateGridDT() As DataTable

        Dim dtGrid As New DataTable("dtGridMain")

        dtGrid.MinimumCapacity = 500
        dtGrid.CaseSensitive = False

        Dim dcDeviceID As New DataColumn("CountID")
        dtGrid.Columns.Add(dcDeviceID)
        Dim dcDeviceSN As New DataColumn("DeviceSN")
        dtGrid.Columns.Add(dcDeviceSN)
        'Dim dcDeviceOLDsn As New DataColumn("DeviceOLDsn")
        'dtGrid.Columns.Add(dcDeviceOLDsn)
        'Dim dcDeviceModelType As New DataColumn("DeviceModelType")
        'dtGrid.Columns.Add(dcDeviceModelType)
        Dim dcDeviceDateEntered As New DataColumn("DeviceDateEntered")
        dtGrid.Columns.Add(dcDeviceDateEntered)
        'Dim dcDeviceDateBilled As New DataColumn("DeviceDateBilled")
        'dtGrid.Columns.Add(dcDeviceDateBilled)
        'Dim dcDeviceDateShipped As New DataColumn("DeviceDateShipped")
        'dtGrid.Columns.Add(dcDeviceDateShipped)
        Dim dcDeviceManufWrty As New DataColumn("DeviceManufWrty")
        dtGrid.Columns.Add(dcDeviceManufWrty)
        Dim dcDeviceOEMWrty As New DataColumn("DeviceOEMWrty")
        dtGrid.Columns.Add(dcDeviceOEMWrty)
        Dim dcDevicePSSwrty As New DataColumn("DevicePSSwrty")
        dtGrid.Columns.Add(dcDevicePSSwrty)
        'Dim dcDeviceCAPcode As New DataColumn("DeviceCAPcode")
        'dtGrid.Columns.Add(dcDeviceCAPcode)
        'Dim dcDeviceBAUD As New DataColumn("DeviceBAUD")
        'dtGrid.Columns.Add(dcDeviceBAUD)
        'Dim dcDeviceFrequency As New DataColumn("DeviceFrequency")
        'dtGrid.Columns.Add(dcDeviceFrequency)
        'Dim dcDeviceFOlot As New DataColumn("DeviceFOlot")
        'dtGrid.Columns.Add(dcDeviceFOlot)
        Dim dcDeviceTrayID As New DataColumn("DeviceTrayID")
        dtGrid.Columns.Add(dcDeviceTrayID)
        Dim dcDeviceWOID As New DataColumn("DeviceWOID")
        dtGrid.Columns.Add(dcDeviceWOID)
        Dim dcDeviceModelID As New DataColumn("DeviceModelID")
        dtGrid.Columns.Add(dcDeviceModelID)
        Dim dcLocID As New DataColumn("DeviceLocationID")
        dtGrid.Columns.Add(dcLocID)
        Dim dcDBR As New DataColumn("DeviceDBR")
        dtGrid.Columns.Add(dcDBR)
        'Dim dcLaborLevel As New DataColumn("DeviceLaborLevel")
        'dtGrid.Columns.Add(dcLaborLevel)
        'Dim dcLaborCharge As New DataColumn("DeviceLaborCharge")
        'dtGrid.Columns.Add(dcLaborCharge)
        'Dim dcReconcileID As New DataColumn("ReconcileID")
        'dtGrid.Columns.Add(dcReconcileID)
        Dim dcSKU As New DataColumn("SKU")
        dtGrid.Columns.Add(dcSKU)

        If DeviceType = "2" Then
            Dim dcCSN As New DataColumn("CSNnumber")
            dtGrid.Columns.Add(dcCSN)
            Dim dcCourTrackIN As New DataColumn("CourTrackIN")
            dtGrid.Columns.Add(dcCourTrackIN)
            Dim dcAirTimeCarrierCode As New DataColumn("AirTimeCarrierCode")
            dtGrid.Columns.Add(dcAirTimeCarrierCode)
            Dim dcTransactionCode As New DataColumn("TransactionCode")
            dtGrid.Columns.Add(dcTransactionCode)
            Dim dcAPCcode As New DataColumn("APCcode")
            dtGrid.Columns.Add(dcAPCcode)
            Dim dcTransceiverCode As New DataColumn("TransceiverCode")
            dtGrid.Columns.Add(dcTransceiverCode)
            Dim dcIncomingIMEI As New DataColumn("IncomingIMEI")
            dtGrid.Columns.Add(dcIncomingIMEI)
            Dim dcWrtyClaimNumber As New DataColumn("WrtyClaimNumber")
            dtGrid.Columns.Add(dcWrtyClaimNumber)

            Dim dcOEMwrty As New DataColumn("DeviceOEMwrty")
            dtGrid.Columns.Add(dcOEMwrty)
            Dim dcDateCode As New DataColumn("DeviceDateCode")
            dtGrid.Columns.Add(dcDateCode)
            Dim dcCustFName As New DataColumn("DeviceCustFName")
            dtGrid.Columns.Add(dcCustFName)
            Dim dcCustLName As New DataColumn("DeviceCustLName")
            dtGrid.Columns.Add(dcCustLName)
            Dim dcModelNum As New DataColumn("DeviceModelNum")
            dtGrid.Columns.Add(dcModelNum)
            Dim dcPOPdate As New DataColumn("DevicePOPdate")
            dtGrid.Columns.Add(dcPOPdate)
            Dim dcComplaint As New DataColumn("DeviceComplaint")
            dtGrid.Columns.Add(dcComplaint)
            Dim dcMIN As New DataColumn("DeviceMIN")
            dtGrid.Columns.Add(dcMIN)
            Dim dcCarrModelCode As New DataColumn("DeviceCarrModelCode")
            dtGrid.Columns.Add(dcCarrModelCode)
            Dim dcDecimal As New DataColumn("Decimal")
            dtGrid.Columns.Add(dcDecimal)
            Dim dcReturnCode As New DataColumn("ReturnCode")
            dtGrid.Columns.Add(dcReturnCode)

            'If cboManufID.Text = "Motorola" Then
            Dim dcMSN As New DataColumn("DeviceMSN")
            dtGrid.Columns.Add(dcMSN)
            'End If

            'If cboManufID.Text = "Nokia" Then
            Dim dcProdCode As New DataColumn("DeviceProdCode")
            dtGrid.Columns.Add(dcProdCode)
            'End If

        End If

        CreateGridDT = dtGrid

    End Function

    Private Function InsertDevice() As Int32

        Try
            InsertDevice = 0
            '//Insert device into grid
            Dim dr1 As DataRow = dataGrid.NewRow
            dr1("DeviceSN") = UCase(txtDeviceSN.Text)
            dr1("DeviceDateEntered") = "0"
            dr1("DeviceManufWrty") = "0"
            dr1("DeviceOEMWrty") = "0"
            dr1("DevicePSSWrty") = "0"
            dr1("DeviceTrayID") = "0"
            dr1("DeviceWOID") = "0"
            dr1("DeviceModelID") = "0"
            dr1("DeviceLocationID") = "0"
            dr1("DeviceDBR") = "0"
            dr1("CSNnumber") = UCase(txtDeviceSN.Text)
            dr1("CourTrackIN") = UCase(Me.txtCourierTrackIN.Text)
            dr1("AirTimeCarrierCode") = UCase(Me.cboAirCarrCode.Text)
            dr1("TransactionCode") = UCase(Me.cboTransaction.Text)
            dr1("APCcode") = UCase(Me.cboAPC.Text)
            dr1("TransceiverCode") = UCase(Me.txtTransceiver.Text)
            dr1("IncomingIMEI") = UCase(Me.txtIncIMEI.Text)
            dr1("DeviceOEMwrty") = "0"
            dr1("DeviceDateCode") = UCase(Me.cboDateCode.Text)
            dr1("DeviceCustFName") = "0"
            dr1("DeviceCustLName") = "0"
            dr1("DeviceModelNum") = "0"
            dr1("DevicePOPdate") = Me.txtPOP.Text
            dr1("DeviceComplaint") = Me.cboComplaint.SelectedValue
            dr1("DeviceMIN") = UCase(Me.txtMIN.Text)
            dr1("DeviceCarrModelCode") = UCase(Me.txtCarrModelCode.Text)
            dr1("Decimal") = "0"
            dr1("DeviceProdCode") = UCase(Me.txtProduct.Text)
            dataGrid.Rows.Add(dr1)
        Catch ex As Exception
            MsgBox("Could not add record.", MsgBoxStyle.OKOnly, "ERROR")
        Finally
            clearFields()
            increaseCount()
            InsertDevice = 1
        End Try

    End Function

    Private Sub txtDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown

        If e.KeyCode = 13 Then
            If Len(Trim(txtDeviceSN.Text)) > 0 Then
                Dim checkDup As Boolean = Me.checkDuplicateSNgrid
                If checkDup = False Then
                    MsgBox("This Serial Number is already in this tray, connot continue.", MsgBoxStyle.OKOnly)
                    txtDeviceSN.Text = ""
                    txtDeviceSN.Focus()
                    Exit Sub
                End If
            End If
            GridHeight = MainGrid.Height
            MainGrid.Height = 0

            '//Insert tray if none defined
            If mTray = 0 Then
                lblTrayVAL.Text = InsertTray(mWorkOrder)
            Else
                lblTrayVAL.Text = mTray
            End If

            cboDateCode.Focus()
        End If

    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

        If blnRecover = True Then
            '//Remove item from grid
            blnRecover = False
        End If

        Dim blnEnter As Boolean = InsertDevice()
        MainGrid.Height = GridHeight
        txtDeviceSN.Text = ""
        txtDeviceSN.Focus()



    End Sub

    Private Sub btnContinue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnContinue.KeyDown
        If e.KeyCode = 13 Then
            Dim blnEnter As Boolean = InsertDevice()

            'Dim tvTree As TreeView
            'tvTree = ParentForm.Controls.Item(1)
            'tvTree.Nodes(2).Nodes.Add(txtDeviceSN.Text)
            'tvTree.Nodes(2).Expand()

            MainGrid.Height = GridHeight
            txtDeviceSN.Text = ""
            txtDeviceSN.Focus()
        End If
    End Sub

    Private Sub clearFields()
        If txtDeviceSN.Enabled = True Then txtDeviceSN.Text = ""
        If cboDateCode.Enabled = True Then cboDateCode.Text = ""
        If txtPOP.Enabled = True Then txtPOP.Text = ""
        If cboAPC.Enabled = True Then cboAPC.Text = ""
        If txtIncIMEI.Enabled = True Then txtIncIMEI.Text = ""
        If txtModel.Enabled = True Then txtModel.Text = ""
        If txtCourierTrackIN.Enabled = True Then txtCourierTrackIN.Text = ""
        If cboAirCarrCode.Enabled = True Then cboAirCarrCode.Text = ""
        If cboTransaction.Enabled = True Then cboTransaction.Text = ""
        If txtTransceiver.Enabled = True Then txtTransceiver.Text = ""
        If txtCarrModelCode.Enabled = True Then txtCarrModelCode.Text = ""
        If txtMIN.Enabled = True Then txtMIN.Text = ""
        If txtProduct.Enabled = True Then txtProduct.Text = ""
        If cboComplaint.Enabled = True Then cboComplaint.Text = ""
    End Sub

    Private Sub increaseCount()
        lblCountVAL.Text = CInt(lblCountVAL.Text) + 1
    End Sub

    Private Sub decreaseCount()
        lblCountVAL.Text = CInt(lblCountVAL.Text) - 1
    End Sub

    Private Function checkDuplicateSNgrid() As Boolean

        checkDuplicateSNgrid = True

        Dim xCount As Integer = 0
        Dim r As DataRow
        If dataGrid.Rows.Count > 0 Then
            For xCount = 0 To dataGrid.Rows.Count - 1
                r = dataGrid.Rows(xCount)
                If Trim(r("DeviceSN")) = Trim(txtDeviceSN.Text) Then
                    checkDuplicateSNgrid = False
                    Exit Function
                End If
            Next
        End If

    End Function

    Private Sub recoverData()

        txtDeviceSN.Text = MainGrid.Columns("DeviceSN").ToString
        txtCourierTrackIN.Text = MainGrid.Columns("CourTrackIN").ToString
        cboAirCarrCode.Text = MainGrid.Columns("AirTimeCarrierCode").ToString
        cboTransaction.Text = MainGrid.Columns("TransactionCode").ToString
        cboAPC.Text = MainGrid.Columns("APCcode").ToString
        txtTransceiver.Text = MainGrid.Columns("TransceiverCode").ToString
        txtIncIMEI.Text = MainGrid.Columns("IncomingIMEI").ToString
        cboDateCode.Text = MainGrid.Columns("DeviceDateCode").ToString
        txtPOP.Text = MainGrid.Columns("DevicePOPdate").ToString
        cboComplaint.Text = MainGrid.Columns("DeviceComplaint").ToString
        txtMIN.Text = MainGrid.Columns("DeviceMIN").ToString
        txtCarrModelCode.Text = MainGrid.Columns("DeviceCarrModelCode").ToString
        txtProduct.Text = MainGrid.Columns("DeviceProdCode").ToString

        GridHeight = MainGrid.Height
        MainGrid.Height = 0
        cboDateCode.Focus()

    End Sub

    Private Sub MainGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseUp
        blnRecover = True
        'recoverData()
    End Sub

    Private Function SKUmake(ByVal SKUnumber As String, ByVal vModel As Int32, ByVal vCust As Int32) As Int32

        Dim tVsku As New PSS.Data.Production.tsku()
        Dim verSKU As Boolean = tVsku.GetRowBySKU(UCase(Trim(SKUnumber)))

        If verSKU = False Then
            'Insert record
            Dim strSQL As String = "INSERT INTO tsku (Sku_Number, Model_ID, Cust_ID) VALUES ('" & UCase(Trim(SKUnumber)) & "', " & vModel & "," & vCust & ")"
            SKUmake = tVsku.idTransaction(strSQL)
        Else

            Dim vSku As DataRow = tVsku.GetValSKU(SKUnumber)
            SKUmake = vSku("Sku_ID")
        End If

    End Function

    Private Function InsertTray(ByVal valWO As Int32) As Int32

        Dim strSQL As String = "Insert into ttray (" & _
        " Tray_RecUser, WO_ID) VALUES ('" & _
        recUser & "', " & _
        mWorkOrder & ")"

        Dim tblTray As New PSS.Data.Production.ttray()
        Dim trayID As Int32 = tblTray.idTransDev(strSQL)
        InsertTray = trayID
        mTray = trayID
        lblTrayVAL.Text = mTray

        'Get PSS Warranty fields
        'PopulatePSSwrtyFields(mCustomer)

        mSKU = SKUmake(mSKU, mModel, mCustomer)

    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '//Wrtite data into database
        mTray = 0
        lblTrayVAL.Text = ""
    End Sub


End Class
