Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Core
Imports PSS.Data
Imports PSS.Rules
Imports PSS.Core.Global

Namespace Gui.Receiving


    Public Class frmCSrec
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
        Friend WithEvents btnDecimal As System.Windows.Forms.Button
        Friend WithEvents cboDateCode As PSS.Gui.Controls.ComboBox
        Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        Friend WithEvents tvMain As System.Windows.Forms.TreeView
        Friend WithEvents btnGetRMA As System.Windows.Forms.Button
        Friend WithEvents lblTray As System.Windows.Forms.Label
        Friend WithEvents lblPOPexplain As System.Windows.Forms.Label
        Friend WithEvents lblPOP As System.Windows.Forms.Label
        Friend WithEvents grpMotorola As System.Windows.Forms.GroupBox
        Friend WithEvents lblAir As System.Windows.Forms.Label
        Friend WithEvents txtSoftVerIN As System.Windows.Forms.TextBox
        Friend WithEvents lblSoftVerIN As System.Windows.Forms.Label
        Friend WithEvents txtAirtime As System.Windows.Forms.TextBox
        Friend WithEvents lblAirtime As System.Windows.Forms.Label
        Friend WithEvents cboReturn As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboComplaint As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboTransaction As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboCarrier As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboAPC As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblReturn As System.Windows.Forms.Label
        Friend WithEvents lblCustomerReason As System.Windows.Forms.Label
        Friend WithEvents txtMIN As System.Windows.Forms.TextBox
        Friend WithEvents lblMIN As System.Windows.Forms.Label
        Friend WithEvents txtCarrModelCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCarrModelCode As System.Windows.Forms.Label
        Friend WithEvents txtRMANum As System.Windows.Forms.TextBox
        Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
        Friend WithEvents dteExpShipDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtIncIMEI As System.Windows.Forms.TextBox
        Friend WithEvents txtPicassoNum As System.Windows.Forms.TextBox
        Friend WithEvents txtCarModelCode As System.Windows.Forms.TextBox
        Friend WithEvents txtTransceiver As System.Windows.Forms.TextBox
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
        Friend WithEvents lblCarrier As System.Windows.Forms.Label
        Friend WithEvents lblCustomerReference As System.Windows.Forms.Label
        Friend WithEvents lblCourierTrackingIn As System.Windows.Forms.Label
        Friend WithEvents txtModel As System.Windows.Forms.TextBox
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents txtProduct As System.Windows.Forms.TextBox
        Friend WithEvents lblProductCode As System.Windows.Forms.Label
        Friend WithEvents btnContinue As System.Windows.Forms.Button
        Friend WithEvents lblExp As System.Windows.Forms.Label
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents txtRMA As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblTrayVAL As System.Windows.Forms.Label
        Friend WithEvents lblCustomerVAL As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents lblPOPformat As System.Windows.Forms.Label
        Friend WithEvents txtPOP As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents lblCountVAL As System.Windows.Forms.Label
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents chkManufWrty As System.Windows.Forms.CheckBox
        Friend WithEvents lblBrightpoint As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCSrec))
            Me.btnDecimal = New System.Windows.Forms.Button()
            Me.cboDateCode = New PSS.Gui.Controls.ComboBox()
            Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.tvMain = New System.Windows.Forms.TreeView()
            Me.btnGetRMA = New System.Windows.Forms.Button()
            Me.lblTray = New System.Windows.Forms.Label()
            Me.lblPOPexplain = New System.Windows.Forms.Label()
            Me.lblPOP = New System.Windows.Forms.Label()
            Me.grpMotorola = New System.Windows.Forms.GroupBox()
            Me.chkManufWrty = New System.Windows.Forms.CheckBox()
            Me.lblAir = New System.Windows.Forms.Label()
            Me.txtSoftVerIN = New System.Windows.Forms.TextBox()
            Me.lblSoftVerIN = New System.Windows.Forms.Label()
            Me.txtAirtime = New System.Windows.Forms.TextBox()
            Me.lblAirtime = New System.Windows.Forms.Label()
            Me.cboReturn = New PSS.Gui.Controls.ComboBox()
            Me.cboComplaint = New PSS.Gui.Controls.ComboBox()
            Me.cboTransaction = New PSS.Gui.Controls.ComboBox()
            Me.cboCarrier = New PSS.Gui.Controls.ComboBox()
            Me.cboAPC = New PSS.Gui.Controls.ComboBox()
            Me.lblReturn = New System.Windows.Forms.Label()
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
            Me.lblCarrier = New System.Windows.Forms.Label()
            Me.lblCustomerReference = New System.Windows.Forms.Label()
            Me.lblCourierTrackingIn = New System.Windows.Forms.Label()
            Me.txtModel = New System.Windows.Forms.TextBox()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.txtProduct = New System.Windows.Forms.TextBox()
            Me.lblProductCode = New System.Windows.Forms.Label()
            Me.btnContinue = New System.Windows.Forms.Button()
            Me.lblExp = New System.Windows.Forms.Label()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.txtRMA = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblTrayVAL = New System.Windows.Forms.Label()
            Me.lblCustomerVAL = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.lblPOPformat = New System.Windows.Forms.Label()
            Me.txtPOP = New System.Windows.Forms.TextBox()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.lblCountVAL = New System.Windows.Forms.Label()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.lblBrightpoint = New System.Windows.Forms.Label()
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpMotorola.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnDecimal
            '
            Me.btnDecimal.Location = New System.Drawing.Point(364, 66)
            Me.btnDecimal.Name = "btnDecimal"
            Me.btnDecimal.Size = New System.Drawing.Size(56, 16)
            Me.btnDecimal.TabIndex = 129
            Me.btnDecimal.TabStop = False
            Me.btnDecimal.Text = "decimal"
            '
            'cboDateCode
            '
            Me.cboDateCode.AutoComplete = True
            Me.cboDateCode.Location = New System.Drawing.Point(260, 107)
            Me.cboDateCode.Name = "cboDateCode"
            Me.cboDateCode.Size = New System.Drawing.Size(64, 21)
            Me.cboDateCode.TabIndex = 136
            '
            'MainGrid
            '
            Me.MainGrid.AllowColMove = False
            Me.MainGrid.AllowColSelect = False
            Me.MainGrid.AllowDelete = True
            Me.MainGrid.AllowFilter = False
            Me.MainGrid.AllowSort = False
            Me.MainGrid.AllowUpdate = False
            Me.MainGrid.AlternatingRows = True
            Me.MainGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.MainGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.MainGrid.CaptionHeight = 17
            Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.MainGrid.Location = New System.Drawing.Point(192, 88)
            Me.MainGrid.Name = "MainGrid"
            Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.MainGrid.PreviewInfo.ZoomFactor = 75
            Me.MainGrid.RowHeight = 15
            Me.MainGrid.Size = New System.Drawing.Size(560, 432)
            Me.MainGrid.TabIndex = 139
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
            """ RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizonta" & _
            "lScrollGroup=""1""><Height>430</Height><CaptionStyle parent=""Style2"" me=""Style10"" " & _
            "/><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""" & _
            "Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=" & _
            """Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle p" & _
            "arent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style" & _
            "7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow""" & _
            " me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Sele" & _
            "ctedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><" & _
            "ClientRect>0, 0, 558, 430</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sun" & _
            "ken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" m" & _
            "e=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""R" & _
            "ecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption""" & _
            " me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits>" & _
            "<Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>" & _
            "0, 0, 558, 430</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Print" & _
            "PageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lblDateCode
            '
            Me.lblDateCode.Location = New System.Drawing.Point(196, 112)
            Me.lblDateCode.Name = "lblDateCode"
            Me.lblDateCode.Size = New System.Drawing.Size(64, 16)
            Me.lblDateCode.TabIndex = 130
            Me.lblDateCode.Text = "Date Code"
            '
            'tvMain
            '
            Me.tvMain.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.tvMain.ImageIndex = -1
            Me.tvMain.Location = New System.Drawing.Point(0, 40)
            Me.tvMain.Name = "tvMain"
            Me.tvMain.SelectedImageIndex = -1
            Me.tvMain.Size = New System.Drawing.Size(184, 416)
            Me.tvMain.TabIndex = 127
            Me.tvMain.TabStop = False
            '
            'btnGetRMA
            '
            Me.btnGetRMA.Location = New System.Drawing.Point(460, 11)
            Me.btnGetRMA.Name = "btnGetRMA"
            Me.btnGetRMA.Size = New System.Drawing.Size(96, 23)
            Me.btnGetRMA.TabIndex = 134
            Me.btnGetRMA.Text = "Get Data"
            '
            'lblTray
            '
            Me.lblTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTray.Location = New System.Drawing.Point(468, 66)
            Me.lblTray.Name = "lblTray"
            Me.lblTray.Size = New System.Drawing.Size(24, 16)
            Me.lblTray.TabIndex = 128
            Me.lblTray.Text = "Tray"
            '
            'lblPOPexplain
            '
            Me.lblPOPexplain.ForeColor = System.Drawing.Color.Blue
            Me.lblPOPexplain.Location = New System.Drawing.Point(332, 107)
            Me.lblPOPexplain.Name = "lblPOPexplain"
            Me.lblPOPexplain.Size = New System.Drawing.Size(8, 8)
            Me.lblPOPexplain.TabIndex = 132
            Me.lblPOPexplain.Text = " Please enter a proof of purchase date."
            Me.lblPOPexplain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblPOPexplain.Visible = False
            '
            'lblPOP
            '
            Me.lblPOP.Location = New System.Drawing.Point(364, 112)
            Me.lblPOP.Name = "lblPOP"
            Me.lblPOP.Size = New System.Drawing.Size(100, 16)
            Me.lblPOP.TabIndex = 131
            Me.lblPOP.Text = "Proof of Purchase:"
            '
            'grpMotorola
            '
            Me.grpMotorola.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkManufWrty, Me.lblAir, Me.txtSoftVerIN, Me.lblSoftVerIN, Me.txtAirtime, Me.lblAirtime, Me.cboReturn, Me.cboComplaint, Me.cboTransaction, Me.cboCarrier, Me.cboAPC, Me.lblReturn, Me.lblCustomerReason, Me.txtMIN, Me.lblMIN, Me.txtCarrModelCode, Me.lblCarrModelCode, Me.txtRMANum, Me.DateTimePicker1, Me.dteExpShipDate, Me.txtIncIMEI, Me.txtPicassoNum, Me.txtCarModelCode, Me.txtTransceiver, Me.txtCustRef, Me.txtCourierTrackIN, Me.lblRMANumber, Me.lblExpectedShipTime, Me.lblExpectedShipDate, Me.lblIncomingIMEI, Me.lblPicassoNumber, Me.lblCarrierModelCode, Me.lblTransceiverCode, Me.lblProductAPCCode, Me.lblTransactionCode, Me.lblCarrier, Me.lblCustomerReference, Me.lblCourierTrackingIn, Me.txtModel, Me.lblModel, Me.txtProduct, Me.lblProductCode, Me.btnContinue, Me.lblExp})
            Me.grpMotorola.Location = New System.Drawing.Point(196, 131)
            Me.grpMotorola.Name = "grpMotorola"
            Me.grpMotorola.Size = New System.Drawing.Size(488, 293)
            Me.grpMotorola.TabIndex = 137
            Me.grpMotorola.TabStop = False
            Me.grpMotorola.Text = "Motorola"
            '
            'chkManufWrty
            '
            Me.chkManufWrty.Location = New System.Drawing.Point(152, 24)
            Me.chkManufWrty.Name = "chkManufWrty"
            Me.chkManufWrty.Size = New System.Drawing.Size(176, 16)
            Me.chkManufWrty.TabIndex = 129
            Me.chkManufWrty.Text = "Manufacturer Warranty"
            '
            'lblAir
            '
            Me.lblAir.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAir.Location = New System.Drawing.Point(304, 216)
            Me.lblAir.Name = "lblAir"
            Me.lblAir.Size = New System.Drawing.Size(64, 16)
            Me.lblAir.TabIndex = 127
            Me.lblAir.Text = "(HH-MM-SS)"
            Me.lblAir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtSoftVerIN
            '
            Me.txtSoftVerIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSoftVerIN.Location = New System.Drawing.Point(368, 192)
            Me.txtSoftVerIN.Name = "txtSoftVerIN"
            Me.txtSoftVerIN.TabIndex = 15
            Me.txtSoftVerIN.Text = ""
            '
            'lblSoftVerIN
            '
            Me.lblSoftVerIN.Location = New System.Drawing.Point(256, 192)
            Me.lblSoftVerIN.Name = "lblSoftVerIN"
            Me.lblSoftVerIN.Size = New System.Drawing.Size(112, 16)
            Me.lblSoftVerIN.TabIndex = 126
            Me.lblSoftVerIN.Text = "Software Version IN:"
            Me.lblSoftVerIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAirtime
            '
            Me.txtAirtime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAirtime.Location = New System.Drawing.Point(368, 216)
            Me.txtAirtime.Name = "txtAirtime"
            Me.txtAirtime.TabIndex = 16
            Me.txtAirtime.Text = ""
            '
            'lblAirtime
            '
            Me.lblAirtime.Location = New System.Drawing.Point(256, 216)
            Me.lblAirtime.Name = "lblAirtime"
            Me.lblAirtime.Size = New System.Drawing.Size(48, 16)
            Me.lblAirtime.TabIndex = 125
            Me.lblAirtime.Text = "Airtime:"
            Me.lblAirtime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboReturn
            '
            Me.cboReturn.AutoComplete = True
            Me.cboReturn.Location = New System.Drawing.Point(152, 264)
            Me.cboReturn.Name = "cboReturn"
            Me.cboReturn.Size = New System.Drawing.Size(184, 21)
            Me.cboReturn.TabIndex = 18
            '
            'cboComplaint
            '
            Me.cboComplaint.AutoComplete = True
            Me.cboComplaint.Location = New System.Drawing.Point(152, 240)
            Me.cboComplaint.Name = "cboComplaint"
            Me.cboComplaint.Size = New System.Drawing.Size(184, 21)
            Me.cboComplaint.TabIndex = 17
            '
            'cboTransaction
            '
            Me.cboTransaction.AutoComplete = True
            Me.cboTransaction.Location = New System.Drawing.Point(152, 144)
            Me.cboTransaction.Name = "cboTransaction"
            Me.cboTransaction.Size = New System.Drawing.Size(184, 21)
            Me.cboTransaction.TabIndex = 10
            '
            'cboCarrier
            '
            Me.cboCarrier.AutoComplete = True
            Me.cboCarrier.Location = New System.Drawing.Point(152, 120)
            Me.cboCarrier.Name = "cboCarrier"
            Me.cboCarrier.Size = New System.Drawing.Size(184, 21)
            Me.cboCarrier.TabIndex = 9
            '
            'cboAPC
            '
            Me.cboAPC.AutoComplete = True
            Me.cboAPC.Location = New System.Drawing.Point(152, 48)
            Me.cboAPC.Name = "cboAPC"
            Me.cboAPC.Size = New System.Drawing.Size(64, 21)
            Me.cboAPC.TabIndex = 6
            '
            'lblReturn
            '
            Me.lblReturn.Location = New System.Drawing.Point(56, 264)
            Me.lblReturn.Name = "lblReturn"
            Me.lblReturn.Size = New System.Drawing.Size(96, 16)
            Me.lblReturn.TabIndex = 0
            Me.lblReturn.Text = "Return:"
            Me.lblReturn.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'lblCustomerReason
            '
            Me.lblCustomerReason.Location = New System.Drawing.Point(56, 240)
            Me.lblCustomerReason.Name = "lblCustomerReason"
            Me.lblCustomerReason.Size = New System.Drawing.Size(96, 16)
            Me.lblCustomerReason.TabIndex = 0
            Me.lblCustomerReason.Text = "Complaint:"
            Me.lblCustomerReason.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtMIN
            '
            Me.txtMIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMIN.Location = New System.Drawing.Point(152, 216)
            Me.txtMIN.Name = "txtMIN"
            Me.txtMIN.TabIndex = 13
            Me.txtMIN.Text = ""
            '
            'lblMIN
            '
            Me.lblMIN.Location = New System.Drawing.Point(16, 216)
            Me.lblMIN.Name = "lblMIN"
            Me.lblMIN.Size = New System.Drawing.Size(136, 16)
            Me.lblMIN.TabIndex = 0
            Me.lblMIN.Text = "MIN Number:"
            Me.lblMIN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCarrModelCode
            '
            Me.txtCarrModelCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCarrModelCode.Location = New System.Drawing.Point(152, 192)
            Me.txtCarrModelCode.Name = "txtCarrModelCode"
            Me.txtCarrModelCode.TabIndex = 12
            Me.txtCarrModelCode.Text = ""
            '
            'lblCarrModelCode
            '
            Me.lblCarrModelCode.Location = New System.Drawing.Point(16, 192)
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
            Me.txtIncIMEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtIncIMEI.Location = New System.Drawing.Point(152, 72)
            Me.txtIncIMEI.Name = "txtIncIMEI"
            Me.txtIncIMEI.TabIndex = 7
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
            Me.txtTransceiver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTransceiver.Location = New System.Drawing.Point(152, 168)
            Me.txtTransceiver.Name = "txtTransceiver"
            Me.txtTransceiver.TabIndex = 11
            Me.txtTransceiver.Text = ""
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
            Me.txtCourierTrackIN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCourierTrackIN.Location = New System.Drawing.Point(152, 96)
            Me.txtCourierTrackIN.Name = "txtCourierTrackIN"
            Me.txtCourierTrackIN.TabIndex = 8
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
            Me.lblIncomingIMEI.Location = New System.Drawing.Point(16, 72)
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
            Me.lblTransceiverCode.Location = New System.Drawing.Point(16, 168)
            Me.lblTransceiverCode.Name = "lblTransceiverCode"
            Me.lblTransceiverCode.Size = New System.Drawing.Size(136, 16)
            Me.lblTransceiverCode.TabIndex = 0
            Me.lblTransceiverCode.Text = "Transceiver Code:"
            Me.lblTransceiverCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProductAPCCode
            '
            Me.lblProductAPCCode.Location = New System.Drawing.Point(16, 48)
            Me.lblProductAPCCode.Name = "lblProductAPCCode"
            Me.lblProductAPCCode.Size = New System.Drawing.Size(136, 16)
            Me.lblProductAPCCode.TabIndex = 0
            Me.lblProductAPCCode.Text = "Product/ APC Code:"
            Me.lblProductAPCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTransactionCode
            '
            Me.lblTransactionCode.Location = New System.Drawing.Point(16, 144)
            Me.lblTransactionCode.Name = "lblTransactionCode"
            Me.lblTransactionCode.Size = New System.Drawing.Size(136, 16)
            Me.lblTransactionCode.TabIndex = 0
            Me.lblTransactionCode.Text = "Transaction Code:"
            Me.lblTransactionCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCarrier
            '
            Me.lblCarrier.Location = New System.Drawing.Point(16, 120)
            Me.lblCarrier.Name = "lblCarrier"
            Me.lblCarrier.Size = New System.Drawing.Size(136, 18)
            Me.lblCarrier.TabIndex = 0
            Me.lblCarrier.Text = "Airtime Carrier Code:"
            Me.lblCarrier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.lblCourierTrackingIn.Location = New System.Drawing.Point(16, 96)
            Me.lblCourierTrackingIn.Name = "lblCourierTrackingIn"
            Me.lblCourierTrackingIn.Size = New System.Drawing.Size(136, 16)
            Me.lblCourierTrackingIn.TabIndex = 0
            Me.lblCourierTrackingIn.Text = "Courier Tracking IN:"
            Me.lblCourierTrackingIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtModel
            '
            Me.txtModel.BackColor = System.Drawing.SystemColors.Control
            Me.txtModel.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtModel.Location = New System.Drawing.Point(280, 48)
            Me.txtModel.Name = "txtModel"
            Me.txtModel.TabIndex = 0
            Me.txtModel.TabStop = False
            Me.txtModel.Text = ""
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(240, 48)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(40, 16)
            Me.lblModel.TabIndex = 0
            Me.lblModel.Text = "Model:"
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtProduct
            '
            Me.txtProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtProduct.Location = New System.Drawing.Point(368, 168)
            Me.txtProduct.Name = "txtProduct"
            Me.txtProduct.TabIndex = 14
            Me.txtProduct.Text = ""
            '
            'lblProductCode
            '
            Me.lblProductCode.Location = New System.Drawing.Point(288, 168)
            Me.lblProductCode.Name = "lblProductCode"
            Me.lblProductCode.Size = New System.Drawing.Size(80, 16)
            Me.lblProductCode.TabIndex = 0
            Me.lblProductCode.Text = "Product Code:"
            Me.lblProductCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnContinue
            '
            Me.btnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnContinue.Location = New System.Drawing.Point(368, 240)
            Me.btnContinue.Name = "btnContinue"
            Me.btnContinue.Size = New System.Drawing.Size(104, 48)
            Me.btnContinue.TabIndex = 19
            Me.btnContinue.Text = "Continue"
            '
            'lblExp
            '
            Me.lblExp.Location = New System.Drawing.Point(408, 48)
            Me.lblExp.Name = "lblExp"
            Me.lblExp.Size = New System.Drawing.Size(56, 16)
            Me.lblExp.TabIndex = 124
            '
            'btnReprint
            '
            Me.btnReprint.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnReprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnReprint.Location = New System.Drawing.Point(0, 496)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(184, 23)
            Me.btnReprint.TabIndex = 120
            Me.btnReprint.TabStop = False
            Me.btnReprint.Text = "REPRINT"
            '
            'btnPrint
            '
            Me.btnPrint.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPrint.Location = New System.Drawing.Point(0, 464)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(184, 23)
            Me.btnPrint.TabIndex = 121
            Me.btnPrint.TabStop = False
            Me.btnPrint.Text = "PRINT"
            '
            'txtRMA
            '
            Me.txtRMA.Location = New System.Drawing.Point(292, 11)
            Me.txtRMA.Name = "txtRMA"
            Me.txtRMA.Size = New System.Drawing.Size(160, 20)
            Me.txtRMA.TabIndex = 133
            Me.txtRMA.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(188, 11)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(100, 16)
            Me.Label1.TabIndex = 119
            Me.Label1.Text = "RMA/ Workorder:"
            '
            'lblTrayVAL
            '
            Me.lblTrayVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblTrayVAL.Location = New System.Drawing.Point(500, 59)
            Me.lblTrayVAL.Name = "lblTrayVAL"
            Me.lblTrayVAL.Size = New System.Drawing.Size(88, 23)
            Me.lblTrayVAL.TabIndex = 117
            Me.lblTrayVAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCustomerVAL
            '
            Me.lblCustomerVAL.Location = New System.Drawing.Point(404, 43)
            Me.lblCustomerVAL.Name = "lblCustomerVAL"
            Me.lblCustomerVAL.Size = New System.Drawing.Size(152, 16)
            Me.lblCustomerVAL.TabIndex = 118
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(348, 43)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(56, 16)
            Me.lblCustomer.TabIndex = 125
            Me.lblCustomer.Text = "Customer"
            '
            'lblPOPformat
            '
            Me.lblPOPformat.Location = New System.Drawing.Point(572, 112)
            Me.lblPOPformat.Name = "lblPOPformat"
            Me.lblPOPformat.Size = New System.Drawing.Size(80, 16)
            Me.lblPOPformat.TabIndex = 126
            Me.lblPOPformat.Text = "(yyyy-mm-dd)"
            '
            'txtPOP
            '
            Me.txtPOP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPOP.Location = New System.Drawing.Point(468, 108)
            Me.txtPOP.Name = "txtPOP"
            Me.txtPOP.Size = New System.Drawing.Size(96, 20)
            Me.txtPOP.TabIndex = 138
            Me.txtPOP.Text = ""
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.Location = New System.Drawing.Point(188, 66)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(64, 16)
            Me.lblDeviceSN.TabIndex = 124
            Me.lblDeviceSN.Text = "Device SN"
            '
            'lblCountVAL
            '
            Me.lblCountVAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCountVAL.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCountVAL.Location = New System.Drawing.Point(604, 11)
            Me.lblCountVAL.Name = "lblCountVAL"
            Me.lblCountVAL.Size = New System.Drawing.Size(80, 48)
            Me.lblCountVAL.TabIndex = 122
            Me.lblCountVAL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCount
            '
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.Location = New System.Drawing.Point(572, 11)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(40, 16)
            Me.lblCount.TabIndex = 123
            Me.lblCount.Text = "Count"
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDeviceSN.Location = New System.Drawing.Point(252, 62)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(104, 20)
            Me.txtDeviceSN.TabIndex = 135
            Me.txtDeviceSN.Text = ""
            '
            'lblBrightpoint
            '
            Me.lblBrightpoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBrightpoint.Location = New System.Drawing.Point(8, 8)
            Me.lblBrightpoint.Name = "lblBrightpoint"
            Me.lblBrightpoint.Size = New System.Drawing.Size(144, 23)
            Me.lblBrightpoint.TabIndex = 140
            Me.lblBrightpoint.Text = "Brightpoint"
            '
            'frmCSrec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(760, 525)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBrightpoint, Me.MainGrid, Me.btnDecimal, Me.cboDateCode, Me.lblDateCode, Me.tvMain, Me.btnGetRMA, Me.lblTray, Me.lblPOPexplain, Me.lblPOP, Me.grpMotorola, Me.btnReprint, Me.btnPrint, Me.txtRMA, Me.Label1, Me.lblTrayVAL, Me.lblCustomerVAL, Me.lblCustomer, Me.lblPOPformat, Me.txtPOP, Me.lblDeviceSN, Me.lblCountVAL, Me.lblCount, Me.txtDeviceSN})
            Me.Name = "frmCSrec"
            Me.Text = "Brightpoint Receiving"
            CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpMotorola.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private mWorkOrder As Int32
        Private mTray As Int32
        Private mCustomer As Int32
        Private mManufacturer As Int32
        Private mModel As Int32
        Private mLocation As Int32
        Private mSKU As Int32
        Private mCarrier As Int32
        Private mTransaction As Int32
        Private mAPC As Int32

        Private mComplaint As Int32
        Private mReturn As Int32
        Private mDecimalType As String
        Private mDecimal As String
        Private mPSSwrty As Boolean
        Private mManufWrty As String

        Private mSoftVerIN As String
        Private mSoftVerOUT As String
        Private mSUG As String
        Private mAirtime As String
        Private mMSN As String


        Private vSKU As String
        Private dtGridMain, dataGrid As DataTable
        Private DeviceType As Integer = 2
        Private RecType As Integer = 1
        Private GridHeight As Int32
        Private blnRecover As Boolean = False
        Private recUser As String = PSS.Core.Global.ApplicationUser.User
        Private rSku As DataRow
        Private CustPSSwrtyParts, CustPSSwrtyLabor, CustPSSwrtyRejectDays, CustPSSwrtyRejectTimes, CustPSSwrtyDaysInWrty As Integer

        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing
        Private blnAutoBill As Boolean
        Private intBillCode As Int32

        Private mPSSwrtyParts As Integer
        Private mPSSwrtyLabor As Integer
        Private mPSSwrtyDays As Integer
        Private mPSSwrtyRejectDays As Integer
        Private mPSSwrtyRejectTimes As Integer


        Private mProdID As Integer

        Private Sub NEW_CellReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            dataGrid = CreateGridDT()
            MainGrid.DataSource = dataGrid
            lblCountVAL.Text = "0"
            lblTrayVAL.Text = ""
            mTray = 0
            hideDeviceElements()
            txtRMA.Focus()
            intBillCode = 0

        End Sub

#Region "Grid Methods"

        Private Function CreateGridDT() As DataTable

            Dim dtGrid As New DataTable("dtGridMain")

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim dcDeviceID As New DataColumn("CountID")
            dtGrid.Columns.Add(dcDeviceID)
            Dim dcDeviceSN As New DataColumn("DeviceSN")
            dtGrid.Columns.Add(dcDeviceSN)
            Dim dcDeviceOLDsn As New DataColumn("DeviceOLDsn")
            dtGrid.Columns.Add(dcDeviceOLDsn)
            Dim dcDeviceModelType As New DataColumn("DeviceModelType")
            dtGrid.Columns.Add(dcDeviceModelType)
            Dim dcDeviceDateEntered As New DataColumn("DeviceDateEntered")
            dtGrid.Columns.Add(dcDeviceDateEntered)
            Dim dcDeviceDateBilled As New DataColumn("DeviceDateBilled")
            dtGrid.Columns.Add(dcDeviceDateBilled)
            Dim dcDeviceDateShipped As New DataColumn("DeviceDateShipped")
            dtGrid.Columns.Add(dcDeviceDateShipped)
            Dim dcDeviceManufWrty As New DataColumn("DeviceManufWrty")
            dtGrid.Columns.Add(dcDeviceManufWrty)
            Dim dcDeviceOEMWrty As New DataColumn("DeviceOEMWrty")
            dtGrid.Columns.Add(dcDeviceOEMWrty)
            Dim dcDevicePSSwrty As New DataColumn("DevicePSSwrty")
            dtGrid.Columns.Add(dcDevicePSSwrty)
            Dim dcDeviceCAPcode As New DataColumn("DeviceCAPcode")
            dtGrid.Columns.Add(dcDeviceCAPcode)
            Dim dcDeviceBAUD As New DataColumn("DeviceBAUD")
            dtGrid.Columns.Add(dcDeviceBAUD)
            Dim dcDeviceFrequency As New DataColumn("DeviceFrequency")
            dtGrid.Columns.Add(dcDeviceFrequency)
            Dim dcDeviceFOlot As New DataColumn("DeviceFOlot")
            dtGrid.Columns.Add(dcDeviceFOlot)
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
            Dim dcLaborLevel As New DataColumn("DeviceLaborLevel")
            dtGrid.Columns.Add(dcLaborLevel)
            Dim dcLaborCharge As New DataColumn("DeviceLaborCharge")
            dtGrid.Columns.Add(dcLaborCharge)
            Dim dcReconcileID As New DataColumn("ReconcileID")
            dtGrid.Columns.Add(dcReconcileID)
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

                Dim dcSoftVerIN As New DataColumn("SoftVerIN")
                dtGrid.Columns.Add(dcSoftVerIN)
                Dim dcSoftVerOUT As New DataColumn("SoftVerOUT")
                dtGrid.Columns.Add(dcSoftVerOUT)
                Dim dcAirtimeAmt As New DataColumn("AirtimeAmt")
                dtGrid.Columns.Add(dcAirtimeAmt)
                Dim dcSUG As New DataColumn("SUG")
                dtGrid.Columns.Add(dcSUG)

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

        Private Function getDecimalValue(ByVal vHex As String) As String

            If Len(Trim(vHex)) > 7 Then
                'Make hex code conversion here
                Dim valHex As String = Mid$(Trim(txtDeviceSN.Text), 1, 8)
                Dim vals1 As String = Mid$(Trim(txtDeviceSN.Text), 1, 2)
                Dim vals2 As String = Mid$(Trim(txtDeviceSN.Text), 3, 6)
                Dim valDec1 As System.UInt32
                valDec1 = System.UInt32.Parse(vals1, Globalization.NumberStyles.HexNumber)
                Dim valDec2 As System.UInt32
                valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)

                Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
                Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
                getDecimalValue = v1 & v2
            End If

        End Function


        Private Function InsertDevice() As Int32

            If mProdID < 3 Then
                '//Determine decimal value
                If mDecimalType <> "GSM/PCS" Then
                    If Len(Trim(txtDeviceSN.Text)) > 7 Then
                        'Make hex code conversion here
                        Dim valHex As String = Mid$(Trim(txtDeviceSN.Text), 1, 8)
                        Dim vals1 As String = Mid$(Trim(txtDeviceSN.Text), 1, 2)
                        Dim vals2 As String = Mid$(Trim(txtDeviceSN.Text), 3, 6)
                        Dim valDec1 As System.UInt32
                        valDec1 = System.UInt32.Parse(vals1, Globalization.NumberStyles.HexNumber)
                        Dim valDec2 As System.UInt32
                        valDec2 = System.UInt32.Parse(vals2, Globalization.NumberStyles.HexNumber)

                        Dim v1 As String = valDec1.ToString.PadLeft(3, "0")
                        Dim v2 As String = valDec2.ToString.PadLeft(8, "0")
                        mDecimal = v1 & v2
                    End If
                End If
            End If


            '//Determine Warranty Manufacturer
            'Dim tMW As DataTable = PSS.Data.Production.lmanufwrty.GetManufWrtyData(cboDateCode.Text, mManufacturer)
            'Dim rMW As DataRow = tMW.Rows(0)
            'If rMW("ManufWrty_Exp") >= Now() Then
            'mManufWrty = "S"
            'Else
            '    'mManufWrty = ""
            'End If
            'tMW.Dispose()
            'tMW = Nothing

            '//BEGIN
            '//This section has been removed becaus the manufacturer warranty should not be set for these entries
            '//Performed June 16, 2004
            mManufWrty = ""

            '//New Code August 22, 2006
            If chkManufWrty.Checked = True Then
                mManufWrty = "S"
            Else
                mManufWrty = ""
            End If
            '//New Code August 22, 2006


            '//END
            '//This section has been removed becaus the manufacturer warranty should not be set for these entries
            '//Performed June 16, 2004


            '//Determine Warranty Manufacturer

            '//Determine PSS Warranty
            'DIm tPSSwrty as DataTable = pss.Data.Production.Joins.chkPSSwrty(txtdevicesn.Text,mlocation,


            Try
                InsertDevice = 0
                '//Insert device into grid
                Dim dr1 As DataRow = dataGrid.NewRow
                dr1("CountID") = CInt(lblCountVAL.Text) + 1
                dr1("DeviceSN") = UCase(txtDeviceSN.Text)
                dr1("DeviceManufWrty") = mManufWrty
                dr1("DeviceOEMWrty") = mManufWrty
                'dr1("DevicePSSWrty") = mPSSwrty

                If mPSSwrty = True Then
                    dr1("DevicePSSwrty") = "S"
                Else
                    dr1("DevicePSSwrty") = ""
                End If

                dr1("DeviceDateEntered") = PSS.Gui.Receiving.FormatDate(Now)
                dr1("DeviceTrayID") = lblTrayVAL.Text
                dr1("DeviceWOID") = mWorkOrder
                dr1("DeviceModelID") = mModel
                dr1("DeviceLocationID") = mLocation
                dr1("DeviceDBR") = "0" '//Not required
                dr1("CSNnumber") = UCase(txtDeviceSN.Text)
                dr1("CourTrackIN") = UCase(Me.txtCourierTrackIN.Text)
                dr1("AirTimeCarrierCode") = mCarrier
                dr1("TransactionCode") = mTransaction
                dr1("APCcode") = mAPC
                dr1("TransceiverCode") = UCase(Me.txtTransceiver.Text)
                dr1("IncomingIMEI") = UCase(Me.txtIncIMEI.Text)
                dr1("DeviceDateCode") = UCase(Me.cboDateCode.Text)
                dr1("DeviceCustFName") = lblCustomerVAL.Text
                dr1("DeviceCustLName") = "" '//Not required
                dr1("DeviceModelNum") = "0"
                If Len(Trim(txtPOP.Text)) > 0 Then
                    dr1("DevicePOPdate") = txtPOP.Text
                End If
                dr1("DeviceComplaint") = mComplaint

                '                dr1("SoftVerIN") = mSoftVerIN
                dr1("SoftVerIN") = UCase(Me.txtSoftVerIN.Text)
                dr1("SoftVerOUT") = mSoftVerOUT
                'dr1("AirTimeAmt") = mAirtime
                dr1("AirTimeAmt") = UCase(Me.txtAirtime.Text)
                dr1("SUG") = mSUG

                dr1("DeviceMIN") = UCase(Me.txtMIN.Text)
                dr1("DeviceCarrModelCode") = UCase(Me.txtCarrModelCode.Text)
                dr1("Decimal") = mDecimal
                dr1("DeviceMSN") = mMSN
                'If mMSN > 0 Then
                'dr1("DeviceSN") = ""
                'End If
                rSku = PSS.Data.Production.tsku.GetValSKU(vSKU)
                mSKU = rSku("Sku_ID")
                dr1("SKU") = mSKU
                dr1("DeviceProdCode") = UCase(Me.txtProduct.Text)
                If mReturn > 0 Then dr1("ReturnCode") = mReturn
                dataGrid.Rows.Add(dr1)
            Catch ex As Exception
                MsgBox("Could not add record.", MsgBoxStyle.OKOnly, "ERROR")
            Finally
                clearFields()
                increaseCount()
                InsertDevice = 1
            End Try

        End Function

#End Region

#Region "Grid Interaction Methods"

        Private Sub recoverData()

            txtDeviceSN.Text = MainGrid.Columns("DeviceSN").ToString
            txtCourierTrackIN.Text = MainGrid.Columns("CourTrackIN").ToString
            cboCarrier.Text = MainGrid.Columns("AirTimeCarrierCode").ToString
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

#End Region

#Region "Device Serial Number Methods"

        Private Sub txtDeviceSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown

            If e.KeyCode = 13 Then


                '//Verify that record is in cstincomingdata
                '//Uppercase the serial number for uniformity
                If Len(Trim(txtDeviceSN.Text)) > 0 Then txtDeviceSN.Text = UCase(txtDeviceSN.Text)
                Dim blnValid As Boolean = verifyIncomingCS_ESN(txtDeviceSN.Text)
                If blnValid = False Then
                    MsgBox("This ESN could not be reconciled with the data from Brightpoint. Please report this to your supervisor.")
                    Exit Sub
                End If
                '//Verify that record is in cstincomingdata

                If mProdID = 3 Then cboDateCode.Enabled = False
                If mProdID = 4 Then cboDateCode.Enabled = False

                If mCustomer <> 2019 And mManufacturer = 1 Then
                    '//New code to enhance validation entry
                    Dim mLenValid As Boolean = False
                    Dim x As Integer
                    If mDecimalType = "GSM/PCS" Then
                        '//Test GSM Phone
                        If Len(Trim(txtDeviceSN.Text)) = 10 Then
                            'txtDeviceSN.Text = txtDeviceSN.Text & "J"
                            mLenValid = True
                        ElseIf Len(Trim(txtDeviceSN.Text)) = 11 Then
                            mLenValid = True
                        ElseIf Len(Trim(txtDeviceSN.Text)) = 15 Then
                            mLenValid = True
                        End If
                        '//Add display of IMEI here
                        txtIncIMEI.Visible = True
                        Me.lblIncomingIMEI.Visible = True
                    Else
                        '//Test Normal Length
                        If Len(Trim(txtDeviceSN.Text)) = 11 Then
                            mLenValid = True
                            '//Test for valid HEX data
                            For x = 1 To 8
                                If IsNumeric(Mid$(txtDeviceSN.Text, x, 1)) = True Then
                                ElseIf Mid$(txtDeviceSN.Text, x, 1) < "G" Then
                                Else
                                    MsgBox("Invalid decimal value conversion", MsgBoxStyle.OKOnly)
                                    txtDeviceSN.Focus()
                                    Exit Sub
                                End If
                            Next
                        Else
                        End If

                        '//Add hide of IMEI here
                        txtIncIMEI.Visible = False
                        Me.lblIncomingIMEI.Visible = False
                    End If
                    If mLenValid = False Then
                        For x = 1 To 5
                            Beep()
                        Next
                        MsgBox("The serial number is invalid! Please re-enter value.", MsgBoxStyle.OKOnly)
                        txtDeviceSN.Focus()
                        Exit Sub
                    End If
                    '//New code to enhance validation entry
                ElseIf mManufacturer = 16 Then 'LG phones 'CDH March 7, 2005
                    Dim y As Integer
                    If Len(Trim(txtDeviceSN.Text)) < 8 Then
                        For y = 1 To 5
                            Beep()
                        Next
                        MsgBox("The serial number is invalid! Please re-enter value.", MsgBoxStyle.OKOnly)
                        txtDeviceSN.Focus()
                        Exit Sub
                    End If
                End If

                '//Uppercase the serial number for uniformity
                If Len(Trim(txtDeviceSN.Text)) > 0 Then txtDeviceSN.Text = UCase(txtDeviceSN.Text)


                If mManufacturer = 1 Then '//Test for Motorola based number
                    Dim vLength As Integer = Len(txtDeviceSN.Text)
                    'get string for datecode
                    Dim vDC As String = Mid$(txtDeviceSN.Text, vLength - 3, 3)




                End If

                txtPOP.Text = ""
                hidePOP()

                '//Checking for duplication of serial number in workorder
                If Len(Trim(txtDeviceSN.Text)) > 0 Then
                    Dim checkDup As Boolean = Me.checkDuplicateSNgrid
                    If checkDup = False Then
                        MsgBox("This Serial Number is already in this tray, connot continue.", MsgBoxStyle.OKOnly)
                        txtDeviceSN.Text = ""
                        txtDeviceSN.Focus()
                        Exit Sub
                    End If
                    Dim checkDupWO As Boolean = Me.checkDuplicateSNworkorder
                    If checkDupWO = False Then
                        MsgBox("This Serial Number is already in this workorder, connot continue.", MsgBoxStyle.OKOnly)
                        txtDeviceSN.Text = ""
                        txtDeviceSN.Focus()
                        Exit Sub
                    End If
                End If


                '//Define PSS Warranty Here
                '//February 22, 2005
                'Dim wrtydays As Integer = -1 * mPSSwrtyDays
                'Dim pssdate As Date
                'pssdate = DateAdd(DateInterval.Day, wrtydays, Now)

                'Dim pssdatemonth As String
                'Dim pssDateDay As String
                'Dim pssDateYear As String
                'Dim pssNewDate As String

                'pssNewDate = DatePart(DateInterval.Year, pssdate) & "-" & DatePart(DateInterval.Month, pssdate) & "-" & DatePart(DateInterval.Day, pssdate)

                'mPSSwrty = False

                'If mPSSwrtyParts = 1 And mPSSwrtyLabor = 1 Then
                ''//Ignore does not apply
                'Else
                'Dim dtPSSwrty As DataTable
                'dtPSSwrty = PSS.Data.Production.Joins.chkPSSwrty(Me.txtDeviceSN.Text, mLocation, pssNewDate)
                'If dtPSSwrty.Rows(0)("repeat") <> False Then
                'mPSSwrty = True
                'End If
                'End If
                '//Define PSS Warranty Here - END



                '//Setting grid height to return gfrid to
                GridHeight = MainGrid.Height
                MainGrid.Height = 0

                '//Insert tray if none defined
                If mTray = 0 Then
                    lblTrayVAL.Text = InsertTray(mWorkOrder)
                Else
                    lblTrayVAL.Text = mTray
                End If

                If Len(Trim(txtDeviceSN.Text)) > 10 Then
                    '//trim value and set datecode
                    Try
                        cboDateCode.SelectedValue = Mid$(Trim(txtDeviceSN.Text), 9, 3)
                        cboDateCode.Text = Mid$(Trim(txtDeviceSN.Text), 9, 3)
                        cboDateCode.Enabled = False
                        'checkManufWrty()
                        txtDeviceSN.Focus()
                    Catch ex As Exception
                        'NextElement()
                    End Try
                End If


                '//GSM Date Code
                If mDecimalType = "GSM/PCS" Then
                    If mCustomer <> 1653 And mCustomer <> 2019 Then
                        Dim vStr As String
                        If Len(Trim(txtDeviceSN.Text)) = 11 Then
                            cboDateCode.Text = (Mid$(Trim(txtDeviceSN.Text), 5, 2) & Mid$(txtDeviceSN.Text, 11, 1))
                            vStr = (Mid$(Trim(txtDeviceSN.Text), 5, 2) & Mid$(txtDeviceSN.Text, 11, 1))
                            cboDateCode.SelectedValue = vStr
                            cboDateCode.Text = (Mid$(Trim(txtDeviceSN.Text), 5, 2) & Mid$(txtDeviceSN.Text, 11, 1))
                            cboDateCode.Enabled = False
                            txtDeviceSN.Focus()
                        Else
                            cboDateCode.Text = (Mid$(Trim(txtDeviceSN.Text), 5, 2) & "J")
                            vStr = (Mid$(Trim(txtDeviceSN.Text), 5, 2) & "J")
                            cboDateCode.SelectedValue = vStr
                            cboDateCode.Text = (Mid$(Trim(txtDeviceSN.Text), 5, 2) & "J")
                            cboDateCode.Enabled = False
                            txtDeviceSN.Focus()
                        End If
                    End If
                End If



                If mManufacturer = 16 Then 'NEW CDH March 7, 2005
                    cboDateCode.Enabled = False
                End If



                '//Determine PSS Warranty status
                determinePSSwrty()

                '//Move to next available field
                NextElement()

            End If

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

        Private Function checkDuplicateSNworkorder() As Boolean

            checkDuplicateSNworkorder = True

            Dim xCount As Integer = 0
            Dim tDup As New PSS.Data.Production.Joins()
            Dim dtDup As DataTable = tDup.OrderEntrySelect("SELECT * FROM tdevice where wo_id = " & mWorkOrder & " AND device_sn = '" & Trim(txtDeviceSN.Text) & "'")
            If dtDup.Rows.Count > 0 Then checkDuplicateSNworkorder = False
            dtDup.Dispose()
            dtDup = Nothing

        End Function

#End Region

#Region "Page Element Methods"

        Private Sub clearFields()
            chkManufWrty.Checked = False
            If txtDeviceSN.Enabled = True Then txtDeviceSN.Text = ""
            If cboDateCode.Enabled = True Then cboDateCode.Text = ""
            If txtPOP.Enabled = True Then txtPOP.Text = ""
            If cboAPC.Enabled = True Then cboAPC.Text = ""
            If txtIncIMEI.Enabled = True Then txtIncIMEI.Text = ""
            If txtModel.Enabled = True Then txtModel.Text = ""
            If txtCourierTrackIN.Enabled = True Then txtCourierTrackIN.Text = ""
            If cboCarrier.Enabled = True Then cboCarrier.Text = ""
            If cboTransaction.Enabled = True Then cboTransaction.Text = ""
            If txtTransceiver.Enabled = True Then txtTransceiver.Text = ""
            If txtCarrModelCode.Enabled = True Then txtCarrModelCode.Text = ""
            If txtMIN.Enabled = True Then txtMIN.Text = ""
            If txtProduct.Enabled = True Then txtProduct.Text = ""
            If cboComplaint.Enabled = True Then cboComplaint.Text = ""
            If txtSoftVerIN.Enabled = True Then txtSoftVerIN.Text = ""
            If txtAirtime.Enabled = True Then txtAirtime.Text = ""
        End Sub

        Private Sub increaseCount()
            lblCountVAL.Text = CInt(lblCountVAL.Text) + 1
        End Sub

        Private Sub decreaseCount()
            lblCountVAL.Text = CInt(lblCountVAL.Text) - 1
        End Sub

        Private Sub getCustomerName()

            Dim tCust As New PSS.Data.Production.tcustomer()
            Dim dtCust As DataRow = tCust.GetRowByPK(mCustomer)

            lblCustomerVAL.Text = dtCust("Cust_Name1")

        End Sub

        Private Sub hideDeviceElements()
            lblCount.Visible = False
            lblCountVAL.Visible = False
            lblDeviceSN.Visible = False
            txtDeviceSN.Visible = False
            btnDecimal.Visible = False
            lblCustomer.Visible = False
            lblCustomerVAL.Visible = False
            lblTray.Visible = False
            lblTrayVAL.Visible = False
            MainGrid.Visible = False
            lblDateCode.Visible = False
            cboDateCode.Visible = False
            lblPOPexplain.Visible = False
            lblPOP.Visible = False
            txtPOP.Visible = False
            lblPOPformat.Visible = False
            grpMotorola.Visible = False
            btnPrint.Visible = False
            btnReprint.Visible = False
        End Sub

        Private Sub showDeviceElements()
            lblCount.Visible = True
            lblCountVAL.Visible = True
            lblDeviceSN.Visible = True
            txtDeviceSN.Visible = True
            btnDecimal.Visible = True
            lblCustomer.Visible = True
            lblCustomerVAL.Visible = True
            lblTray.Visible = True
            lblTrayVAL.Visible = True
            MainGrid.Visible = True
            lblDateCode.Visible = True
            cboDateCode.Visible = True
            lblPOPexplain.Visible = True
            lblPOP.Visible = True
            txtPOP.Visible = True
            lblPOPformat.Visible = True
            grpMotorola.Visible = True
            btnPrint.Visible = True
            btnReprint.Visible = True
        End Sub

#End Region

#Region "Database Load Methods"

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

#End Region

#Region "Button Methods"

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

        Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click

            Dim blnEnter As Boolean = InsertDevice()

            If GridHeight < 100 Then GridHeight = 376
            MainGrid.Height = GridHeight

            cboDateCode.Enabled = True
            cboDateCode.Text = ""

            txtDeviceSN.Text = ""
            txtDeviceSN.Focus()

        End Sub

        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            '//Wrtite data into database
            mTray = 0
            lblTrayVAL.Text = ""
        End Sub

        Private Sub btnGetRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRMA.Click

            If Len(Trim(txtRMA.Text)) > 0 Then txtRMA.Text = UCase(txtRMA.Text)

            If Len(Trim(txtRMA.Text)) Then
                showDeviceElements()
                '//Get the workorder id from tworkorder
                Dim tWO As New PSS.Data.Production.tworkorder()
                Dim dtWO As DataTable = tWO.GetCustWObyName(txtRMA.Text)
                If dtWO.Rows.Count < 1 Then
                    Exit Sub
                    txtRMA.Focus()
                End If
                Dim r As DataRow = dtWO.Rows(0)
                If r("WO_ID") > 0 Then mWorkOrder = r("WO_ID")
                dtWO.Dispose()
                dtWO = Nothing

                '//Get data for grid
                Dim tTree As New PSS.Data.Production.Joins()
                Dim dtTree As DataTable = tTree.OrderEntrySelect(" select " & _
                "tworkorder.*, tcustomer.cust_name1, " & _
                "tlocation.loc_name, lmanuf.manuf_desc, tmodel.model_desc from " & _
                "((((((tworkorder inner join tlocation on tworkorder.loc_id = tlocation.loc_id) " & _
                "inner join tcustomer on tlocation.cust_id = tcustomer.cust_id) " & _
                "inner join tpreloadwodata on tworkorder.wo_id = tpreloadwodata.wo_id) " & _
                "inner join tmodel on tpreloadwodata.model_id = tmodel.model_id) " & _
                "inner join lmanuf on tpreloadwodata.manuf_id = lmanuf.manuf_id) " & _
                "left outer join tshipto on tworkorder.shipto_id = tshipto.shipto_id) " & _
                "where tworkorder.wo_id= " & mWorkOrder)
                Dim rTree As DataRow
                rTree = dtTree.Rows(0)
                Try
                    tvMain.Nodes.Add("Customer: " & UCase(rTree("Cust_Name1")))
                Catch EX As Exception
                End Try
                Try
                    tvMain.Nodes.Add("Workorder: " & UCase(rTree("WO_CustWO")))
                Catch EX As Exception
                End Try

                Try
                    tvMain.Nodes.Add("PRL: " & UCase(rTree("WO_PRL")))
                Catch EX As Exception
                End Try
                Try
                    tvMain.Nodes.Add("IP: " & UCase(rTree("WO_IP")))
                Catch EX As Exception
                End Try

                Try
                    tvMain.Nodes.Add("Quantity: " & UCase(rTree("WO_Quantity")))
                Catch EX As Exception
                End Try

                Try
                    tvMain.Nodes.Add("RA Quantity: " & UCase(rTree("WO_RAQnty")))
                Catch EX As Exception
                End Try

                Try
                    tvMain.Nodes.Add("Memo: " & rTree("WO_Memo"))
                Catch EX As Exception
                End Try

                Try
                    tvMain.Nodes.Add("Manufacturer: " & UCase(rTree("Manuf_Desc")))
                Catch EX As Exception
                End Try

                Try
                    tvMain.Nodes.Add("Model: " & UCase(rTree("Model_Desc")))
                Catch EX As Exception
                End Try


                mLocation = rTree("Loc_ID")

                dtTree.Dispose()
                dtTree = Nothing

                'Get data for workorder
                Dim tplCust As New PSS.Data.Production.tpreloadcust()
                Dim tplWO As New PSS.Data.Production.tpreloadwo()
                Dim tplWOdata As New PSS.Data.Production.tpreloadwodata()
                Dim dtPLCust, dtPLWO, dtPLWOdata As DataTable

                dtPLWO = tplWO.GetWOpreloadWO(mWorkOrder)
                r = dtPLWO.Rows(0)
                mCustomer = r("Cust_ID")

                dtPLCust = tplCust.GetCustSelection(mCustomer)
                dtPLWO = tplWO.GetWOpreload(mCustomer, mWorkOrder)
                dtPLWOdata = tplWOdata.GetWOpreloaddata(mCustomer, mWorkOrder)

                '//Data has now been acquired, present to form

                Dim dr, drData As DataRow

                dr = dtPLWO.Rows(0)
                drData = dtPLWOdata.Rows(0)

                vSKU = drData("plwodata_Sku")
                rSku = PSS.Data.Production.tsku.GetValSKU(vSKU)
                mSKU = rSku("Sku_ID")


                Try
                    If drData("plwodata_AutoBill") = 1 Then
                        blnAutoBill = True
                    Else
                        blnAutoBill = False
                    End If
                Catch ex As Exception
                End Try

                Try
                    intBillCode = drData("plwodata_Billcode")
                Catch ex As Exception
                    intBillCode = 0
                End Try

                Try
                    mManufacturer = drData("Manuf_ID")
                Catch ex As Exception
                    mManufacturer = 0
                End Try
                Try
                    mModel = drData("Model_ID")
                    Dim drModel As DataRow = PSS.Data.Production.tmodel.GetRowByModel(mModel)
                    mProdID = drModel("Prod_ID")
                    Me.txtModel.Text = drModel("Model_Desc")
                    txtModel.Enabled = False
                    drModel = Nothing
                Catch ex As Exception
                    mModel = 0
                End Try

                '//New populate Dropdownboxes
                PopulateDateCode()
                PopulateAPC()
                PopulateCarrier()
                PopulateTransaction()
                populateComplaints()
                populateReturn()
                '//New populate Dropdownboxes

                If dr("plwo_DateCode") = 1 Then
                    'cboDateCode.Enabled = False
                    cboDateCode.Text = UCase(drData("plwodata_DateCode"))
                Else
                    'cboDateCode.Visible = False
                    'lblDateCode.Visible = False
                    cboDateCode.Enabled = False
                End If
                If dr("plwo_POP") = 1 Then
                    'txtPOP.Enabled = False
                    txtPOP.Text = drData("plwodata_POP")
                Else
                    hidePOP()
                End If
                If dr("plwo_APC") = 1 Then
                    cboAPC.Enabled = False
                    cboAPC.Text = UCase(drData("plwodata_APC"))
                Else
                    '//derive APC value from model
                    If mCustomer <> 1653 And mCustomer <> 2019 Then
                        Dim rModel As DataRow = PSS.Data.Production.tmodel.GetRowByModel(mModel)
                        mProdID = rModel("Prod_ID")
                        If rModel("Dcode_ID") > 0 Then
                            mAPC = rModel("Dcode_ID")
                            Dim rAPC As DataRow = PSS.Data.Production.lcodesdetail.GetRowByDCode(rModel("Dcode_ID"))
                            cboAPC.Text = UCase(rAPC("Dcode_Sdesc"))
                            mDecimalType = rAPC("Dcode_L2Desc")
                            cboAPC.Enabled = False
                        End If
                    End If
                End If

                If mManufacturer = 16 Then 'NEW CDH March 7, 2005
                    cboAPC.Enabled = False
                End If

                If mManufacturer <> 1 Then 'NEW CDH November 7, 2005
                    cboAPC.Enabled = False
                End If


                If dr("plwo_IncIMEI") = 1 Then
                    'txtIncIMEI.Enabled = False
                    'txtIncIMEI.Text = drData("plwodata_IncIMEI")
                Else
                    txtIncIMEI.Visible = False
                    Me.lblIncomingIMEI.Visible = False
                End If
                If dr("plwo_CourierTrackIN") = 1 Then
                    txtCourierTrackIN.Enabled = False
                    txtCourierTrackIN.Text = drData("plwodata_CourierTrackIN")
                Else
                    txtCourierTrackIN.Visible = False
                    Me.lblCourierTrackingIn.Visible = False
                End If
                If dr("plwo_Carrier") = 1 Then
                    cboCarrier.Enabled = False
                    mCarrier = drData("plwodata_Carrier")
                    Dim rCarrier As DataRow = PSS.Data.Production.lcodesdetail.GetvString(drData("plwodata_carrier"))
                    cboCarrier.Text = rCarrier("Dcode_LDesc")
                Else
                    cboCarrier.Visible = False
                    Me.lblCarrier.Visible = False
                    cboCarrier.Text = ""
                End If
                If dr("plwo_Transaction") = 1 Then
                    cboTransaction.Enabled = False
                    Dim rTransaction As DataRow = PSS.Data.Production.lcodesdetail.GetvID(drData("plwodata_Transaction"), 8)
                    mTransaction = rTransaction("Dcode_ID")
                    cboTransaction.Text = drData("plwodata_Transaction")
                Else
                    cboTransaction.Visible = False
                    Me.lblTransactionCode.Visible = False
                    cboTransaction.Text = ""
                End If
                If dr("plwo_Transceiver") = 1 Then
                    If Len(Trim(drData("plwodata_Transceiver"))) > 0 Then
                        txtTransceiver.Enabled = False
                        txtTransceiver.Text = UCase(drData("plwodata_Transceiver"))
                    Else
                        txtTransceiver.Enabled = True
                    End If
                Else
                    txtTransceiver.Visible = False
                    Me.lblTransceiverCode.Visible = False
                End If
                If dr("plwo_CarrierCode") = 1 Then
                    txtCarrModelCode.Enabled = False
                    txtCarrModelCode.Text = drData("plwodata_CarrierCode")
                Else
                    txtCarrModelCode.Visible = False
                    Me.lblCarrModelCode.Visible = False
                End If
                If dr("plwo_MIN") = 1 Then
                    txtMIN.Enabled = False
                    txtMIN.Text = drData("plwodata_MIN")
                Else
                    txtMIN.Visible = False
                    lblMIN.Visible = False
                End If
                If dr("plwo_Product") = 1 Then
                    txtProduct.Enabled = False
                    txtProduct.Text = drData("plwodata_Product")
                Else
                    txtProduct.Visible = False
                    Me.lblProductCode.Visible = False
                End If
                If dr("plwo_Complaint") = 1 Then
                    cboComplaint.Enabled = False
                    mComplaint = drData("plwodata_Complaint")
                    Dim rComplaint As DataRow = PSS.Data.Production.lcodesdetail.GetvString(drData("plwodata_Complaint"))
                    cboComplaint.Text = rComplaint("Dcode_LDesc")
                Else
                    cboComplaint.Visible = False
                    Me.lblCustomerReason.Visible = False
                    cboComplaint.Text = ""
                End If
                If dr("plwo_Return") = 1 Then
                    cboReturn.Enabled = True
                    cboReturn.Visible = True
                    Try
                        mReturn = drData("plwodata_Return")
                        Dim rReturn As DataRow = PSS.Data.Production.lcodesdetail.GetvString(drData("plwodata_Return"))
                        cboReturn.Text = rReturn("Dcode_LDesc")
                    Catch ex As Exception
                    End Try
                Else
                    cboReturn.Visible = False
                    Me.lblReturn.Visible = False
                    cboReturn.Text = ""
                End If

                If dr("plwo_SVIN") = 1 Then
                    txtSoftVerIN.Enabled = True
                    Try
                        txtSoftVerIN.Text = drData("plwodata_SoftVerIN")
                    Catch ex As Exception
                        txtSoftVerIN.Text = ""
                    End Try
                Else
                    txtSoftVerIN.Visible = False
                    Me.lblSoftVerIN.Visible = False
                End If

                Try
                    If Len(Trim(drData("plwodata_SoftVerIN"))) > 0 Then
                        mSoftVerIN = drData("plwodata_SoftVerIN")
                        txtSoftVerIN.Enabled = False
                    Else
                        mSoftVerIN = 0
                        txtSoftVerIN.Enabled = False
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Len(Trim(drData("plwodata_SoftVerOUT"))) > 0 Then
                        mSoftVerOUT = drData("plwodata_SoftVerOUT")
                    Else
                        mSoftVerOUT = 0
                    End If
                Catch ex As Exception
                End Try

                txtAirtime.Enabled = False
                If dr("plwo_AirTime") = 1 Then
                    txtAirtime.Enabled = True
                    Try
                        txtAirtime.Text = drData("plwodata_AirTimeCode")
                    Catch ex As Exception
                        'txtAirtime.Enabled = False
                        txtAirtime.Text = ""
                    End Try
                Else
                    txtAirtime.Enabled = False
                    txtAirtime.Visible = False
                    Me.lblAirtime.Visible = False
                End If

                If Len(Trim(drData("plwodata_AirTimeCode"))) > 0 Then
                    If drData("plwodata_AirTimeCode") > 0 Then
                        txtAirtime.Enabled = False
                    End If
                    mAirtime = drData("plwodata_AirTimeCode")
                Else
                    mAirtime = 0
                End If

                If Len(Trim(drData("plwodata_Sug"))) > 0 Then
                    mSUG = drData("plwodata_Sug")
                Else
                    mSUG = ""
                End If

                dtPLCust.Dispose()
                dtPLCust = Nothing
                dtPLWO.Dispose()
                dtPLWO = Nothing
                dtPLWOdata.Dispose()
                dtPLWOdata = Nothing

            End If

            '//Verify required fields are loaded
            Dim strCheck As String = ""
            If mWorkOrder < 1 Then strCheck += "Workorder" & vbCrLf
            If mManufacturer < 1 Then strCheck += "Manufacturer" & vbCrLf
            If mModel < 1 Then strCheck += "Model" & vbCrLf
            If mSKU < 1 Then strCheck += "SKU" & vbCrLf
            '                If mCarrier < 1 Then strCheck += "Carrier" & vbCrLf
            '                If mTransaction < 1 Then strCheck += "Transaction" & vbCrLf
            If mManufacturer = 1 Then 'NEW CDH March 7, 2005
                If mCustomer <> 1653 And mCustomer <> 2019 Then
                    If mAPC < 1 Then strCheck += "APC" & vbCrLf
                End If
            End If 'NEW CDH March 7, 2005

            '                If cboComplaint.Visible = True Then
            '                   If mComplaint < 1 Then strCheck += "Complaint" & vbCrLf
            '               End If
            'If cboReturn.Visible = True Then
            'If mReturn < 1 Then strCheck += "Return" & vbCrLf
            'End If
            If Len(Trim(strCheck)) > 0 Then
                MsgBox("This workorder is incomplete. Contact Customer Service before continuing." & vbCrLf & strCheck, MsgBoxStyle.OKOnly)
                Exit Sub
            End If


            txtRMA.Enabled = False
            btnGetRMA.Enabled = False
            txtDeviceSN.Focus()
            getCustomerName()



            '//Setup PSS warranty values
            Try
                Dim tblCustomer As PSS.Data.Production.tcustomer
                Dim drCustomer As DataRow = tblCustomer.GetRowByPK(mCustomer)

                mPSSwrtyRejectDays = drCustomer("Cust_RejectDays")
                mPSSwrtyRejectTimes = drCustomer("Cust_RejectTimes")
            Catch ex As Exception
            End Try

            Try
                Dim tblCustWrty As PSS.Data.Production.tcustwrty
                Dim drCustWrty As DataRow = tblCustWrty.GetRowByCustID(mCustomer)

                mPSSwrtyParts = drCustWrty("PSSWrtyParts_ID")
                mPSSwrtyLabor = drCustWrty("PSSWrtyLabor_ID")
                mPSSwrtyDays = drCustWrty("CustWrty_DaysInWrty")
            Catch ex As Exception
            End Try
            '//Setup PSS warranty values - END

        End Sub

        Private Sub NextElement()

            If ActiveControl.Name = "txtDeviceSN" Then
                If cboDateCode.Enabled = True And cboDateCode.Visible = True Then
                    cboDateCode.Focus()
                    Exit Sub
                End If
                If txtPOP.Enabled = True And txtPOP.Visible = True Then
                    txtPOP.Focus()
                    Exit Sub
                End If
                chkManufWrty.Focus()
                Exit Sub
                If cboAPC.Enabled = True And cboAPC.Visible = True Then
                    cboAPC.Focus()
                    Exit Sub
                End If
                If txtIncIMEI.Enabled = True And txtIncIMEI.Visible = True Then
                    txtIncIMEI.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Enabled = True And txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboCarrier.Enabled = True And cboCarrier.Visible = True Then
                    cboCarrier.Focus()
                    Exit Sub
                End If
                If cboTransaction.Enabled = True And cboTransaction.Visible = True Then
                    cboTransaction.Focus()
                    Exit Sub
                End If
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "cboDateCode" Then
                If txtPOP.Enabled = True And txtPOP.Visible = True Then
                    txtPOP.Focus()
                    Exit Sub
                End If
                chkManufWrty.Focus()
                Exit Sub
                If cboAPC.Enabled = True And cboAPC.Visible = True Then
                    cboAPC.Focus()
                    Exit Sub
                End If
                If txtIncIMEI.Enabled = True And txtIncIMEI.Visible = True Then
                    txtIncIMEI.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Enabled = True And txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboCarrier.Enabled = True And cboCarrier.Visible = True Then
                    cboCarrier.Focus()
                    Exit Sub
                End If
                If cboTransaction.Enabled = True And cboTransaction.Visible = True Then
                    cboTransaction.Focus()
                    Exit Sub
                End If
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "txtPOP" Then
                chkManufWrty.Focus()
                Exit Sub
                If cboAPC.Enabled = True And cboAPC.Visible = True Then
                    cboAPC.Focus()
                    Exit Sub
                End If
                If txtIncIMEI.Enabled = True And txtIncIMEI.Visible = True Then
                    txtIncIMEI.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Enabled = True And txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboCarrier.Enabled = True And cboCarrier.Visible = True Then
                    cboCarrier.Focus()
                    Exit Sub
                End If
                If cboTransaction.Enabled = True And cboTransaction.Visible = True Then
                    cboTransaction.Focus()
                    Exit Sub
                End If
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "chkManufWrty" Then
                If cboAPC.Enabled = True And cboAPC.Visible = True Then
                    cboAPC.Focus()
                    Exit Sub
                End If
                If txtIncIMEI.Enabled = True And txtIncIMEI.Visible = True Then
                    txtIncIMEI.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Enabled = True And txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboCarrier.Enabled = True And cboCarrier.Visible = True Then
                    cboCarrier.Focus()
                    Exit Sub
                End If
                If cboTransaction.Enabled = True And cboTransaction.Visible = True Then
                    cboTransaction.Focus()
                    Exit Sub
                End If
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "cboAPC" Then
                If txtIncIMEI.Enabled = True And txtIncIMEI.Visible = True Then
                    txtIncIMEI.Focus()
                    Exit Sub
                End If
                If txtCourierTrackIN.Enabled = True And txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboCarrier.Enabled = True And cboCarrier.Visible = True Then
                    cboCarrier.Focus()
                    Exit Sub
                End If
                If cboTransaction.Enabled = True And cboTransaction.Visible = True Then
                    cboTransaction.Focus()
                    Exit Sub
                End If
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "txtIncIMEI" Then
                If txtCourierTrackIN.Enabled = True And txtCourierTrackIN.Visible = True Then
                    txtCourierTrackIN.Focus()
                    Exit Sub
                End If
                If cboCarrier.Enabled = True And cboCarrier.Visible = True Then
                    cboCarrier.Focus()
                    Exit Sub
                End If
                If cboTransaction.Enabled = True And cboTransaction.Visible = True Then
                    cboTransaction.Focus()
                    Exit Sub
                End If
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "txtCourierTrackIN" Then
                If cboCarrier.Enabled = True And cboCarrier.Visible = True Then
                    cboCarrier.Focus()
                    Exit Sub
                End If
                If cboTransaction.Enabled = True And cboTransaction.Visible = True Then
                    cboTransaction.Focus()
                    Exit Sub
                End If
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "cboCarrier" Then
                If cboTransaction.Enabled = True And cboTransaction.Visible = True Then
                    cboTransaction.Focus()
                    Exit Sub
                End If
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "cboTransaction" Then
                If txtTransceiver.Enabled = True And txtTransceiver.Visible = True Then
                    txtTransceiver.Focus()
                    Exit Sub
                End If
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "txtTransceiver" Then
                If txtCarrModelCode.Enabled = True And txtCarrModelCode.Visible = True Then
                    txtCarrModelCode.Focus()
                    Exit Sub
                End If
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "txtCarrModelCode" Then
                If txtMIN.Enabled = True And txtMIN.Visible = True Then
                    txtMIN.Focus()
                    Exit Sub
                End If
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "txtMIN" Then
                If txtProduct.Enabled = True And txtProduct.Visible = True Then
                    txtProduct.Focus()
                    Exit Sub
                End If
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If


            'If ActiveControl.Name = "txtProduct" Then
            'If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
            '    cboComplaint.Focus()
            '    Exit Sub
            'End If
            'If cboReturn.Enabled = True And cboReturn.Visible = True Then
            'cboReturn.Focus()
            'Exit Sub
            'End If
            'If btnContinue.Enabled = True And btnContinue.Visible = True Then
            'btnContinue.Focus()
            'Exit Sub
            'End If
            'End If

            If ActiveControl.Name = "txtProduct" Then
                If txtSoftVerIN.Enabled = True And txtSoftVerIN.Visible = True Then
                    txtSoftVerIN.Focus()
                    Exit Sub
                End If
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If

            If ActiveControl.Name = "txtSoftVerIN" Then
                If txtAirtime.Enabled = True And txtAirtime.Visible = True Then
                    txtAirtime.Focus()
                    Exit Sub
                End If
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If

            If ActiveControl.Name = "txtAirtime" Then
                If cboComplaint.Enabled = True And cboComplaint.Visible = True Then
                    cboComplaint.Focus()
                    Exit Sub
                End If
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If



            If ActiveControl.Name = "cboComplaint" Then
                If cboReturn.Enabled = True And cboReturn.Visible = True Then
                    cboReturn.Focus()
                    Exit Sub
                End If
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If
            If ActiveControl.Name = "cboReturn" Then
                If btnContinue.Enabled = True And btnContinue.Visible = True Then
                    btnContinue.Focus()
                    Exit Sub
                End If
            End If

        End Sub



#End Region

        Private Sub PopulateDateCode()

            Dim tblManufWrty As New PSS.Data.Production.lmanufwrty()
            'Dim dtManufWrty As DataTable = tblManufWrty.getDateCodeListByDeviceType(mManufacturer, 2)
            Dim dtManufWrty As DataTable = tblManufWrty.getDateCodeListByDeviceType(mManufacturer, mProdID)

            If dtManufWrty.Rows.Count > 0 Then
                cboDateCode.DataSource = dtManufWrty
                cboDateCode.DisplayMember = dtManufWrty.Columns("ManufWrty_Code").ToString
                cboDateCode.ValueMember = dtManufWrty.Columns("ManufWrty_Code").ToString
                cboDateCode.Text = ""
            End If

            'dtManufWrty.Dispose()
            'dtManufWrty = Nothing

        End Sub
        Private Sub PopulateAPC()

            Dim tblJoins As New PSS.Data.Production.Joins()
            Dim dtAPC As DataTable
            'dtAPC = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='APC' and lcodesdetail.manuf_id=" & mManufacturer & " and lcodesdetail.prod_id=2 order by Dcode_SDesc")
            dtAPC = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='APC' and lcodesdetail.manuf_id=" & mManufacturer & " and lcodesdetail.prod_id= " & mProdID & " order by Dcode_SDesc")

            If dtAPC.Rows.Count > 0 Then
                cboAPC.DataSource = dtAPC.DefaultView   '".Defaultview" added by Asif on 06/15/2004
                cboAPC.DisplayMember = dtAPC.Columns("Dcode_Sdesc").ToString
                cboAPC.ValueMember = dtAPC.Columns("Dcode_ID").ToString     'added by Asif on 06/15/2004
                cboAPC.Text = ""
            End If

            dtAPC.Dispose()
            dtAPC = Nothing

        End Sub
        Private Sub PopulateCarrier()

            Try
                cboCarrier.Items.Clear()
            Catch ex As Exception
            End Try

            Try
                Dim xCount As Integer = 0
                Dim tblJoins As New PSS.Data.Production.Joins()
                Dim dtCarrier As DataTable
                'dtCarrier = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='carrier' and lcodesdetail.manuf_id=" & mManufacturer & " and lcodesdetail.prod_id=2 AND lcodesdetail.Dcode_Inactive = 0")
                dtCarrier = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='carrier' and lcodesdetail.manuf_id=" & mManufacturer & " and lcodesdetail.prod_id= " & mProdID & " AND lcodesdetail.Dcode_Inactive = 0")
                Me.cboCarrier.DataSource = dtCarrier
                Me.cboCarrier.DisplayMember = dtCarrier.Columns("Dcode_Ldesc").ToString
                Me.cboCarrier.SelectedValue = dtCarrier.Columns("Dcode_ID").ToString

                dtCarrier.Dispose()
                dtCarrier = Nothing
            Catch ex As Exception
            End Try

        End Sub
        Private Sub PopulateTransaction()

            Try
                cboTransaction.Items.Clear()
            Catch ex As Exception
            End Try

            Try
                Dim tblJoins As New PSS.Data.Production.Joins()
                Dim dtTransaction As DataTable
                'dtTransaction = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='transaction' and lcodesdetail.manuf_id=" & mManufacturer & " and lcodesdetail.prod_id=2 AND lcodesdetail.Dcode_Inactive = 0")
                dtTransaction = tblJoins.GenericSelect("SELECT lcodesdetail.* from (lcodesmaster INNER JOIN lcodesdetail ON lcodesmaster.mcode_id = lcodesdetail.mcode_id) Where lcodesmaster.mcode_desc='transaction' and lcodesdetail.manuf_id=" & mManufacturer & " and lcodesdetail.prod_id=" & mProdID & " AND lcodesdetail.Dcode_Inactive = 0")
                cboTransaction.DataSource = dtTransaction
                cboTransaction.DisplayMember = dtTransaction.Columns("Dcode_LDesc").ToString
                cboTransaction.SelectedValue = dtTransaction.Columns("Dcode_ID").ToString

                dtTransaction.Dispose()
                dtTransaction = Nothing
            Catch ex As Exception
            End Try

        End Sub
        Private Sub populateComplaints()
            Try
                Dim tblComplaints As New PSS.Data.Production.lcodesdetail()
                Dim dtComplaint As DataTable = tblComplaints.GetCodesCELL(5, mManufacturer)
                cboComplaint.DataSource = dtComplaint
                cboComplaint.DisplayMember = dtComplaint.Columns("Dcode_ldesc").ToString
                cboComplaint.SelectedValue = dtComplaint.Columns("Dcode_ID").ToString

                dtComplaint.Dispose()
                dtComplaint = Nothing
            Catch ex As Exception
            End Try
        End Sub
        Private Sub populateReturn()
            Try
                If mCustomer = 1653 Then
                    Dim tblReturns As New PSS.Data.Production.lcodesdetail()
                    Dim dtReturn As DataTable = tblReturns.GetCodesCELL(19, 0)
                    cboReturn.DataSource = dtReturn
                    cboReturn.DisplayMember = dtReturn.Columns("Dcode_ldesc").ToString
                    cboReturn.SelectedValue = dtReturn.Columns("Dcode_ID").ToString

                    dtreturn.Dispose()
                    dtreturn = Nothing
                Else
                    cboReturn.DataSource = Nothing
                    Dim tblReturns As New PSS.Data.Production.lcodesdetail()
                    Dim dtReturn As DataTable = tblReturns.GetCodesCELL(19, 1)
                    cboReturn.DataSource = dtReturn
                    cboReturn.DisplayMember = dtReturn.Columns("Dcode_ldesc").ToString
                    cboReturn.SelectedValue = dtReturn.Columns("Dcode_ID").ToString

                    dtreturn.Dispose()
                    dtreturn = Nothing
                End If
            Catch ex As Exception
            End Try
        End Sub

        Private Sub cboDateCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDateCode.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtPOP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPOP.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub cboAPC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAPC.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtIncIMEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIncIMEI.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtCourierTrackIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCourierTrackIN.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub cboCarrier_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCarrier.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub cboTransaction_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboTransaction.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtTransceiver_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTransceiver.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtCarrModelCode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCarrModelCode.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtMIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMIN.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtProduct_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtProduct.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub cboComplaint_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboComplaint.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub cboReturn_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboReturn.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtSoftVerIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSoftVerIN.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub
        Private Sub txtAirtime_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAirtime.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub




        Private Sub hidePOP()
            lblPOP.Visible = False
            'lblPOPexplain.Visible = False
            lblPOPformat.Visible = False
            txtPOP.Visible = False
        End Sub
        Private Sub showPOP()
            lblPOP.Visible = True
            'lblPOPexplain.Visible = True
            lblPOPformat.Visible = True
            txtPOP.Visible = True
            txtPOP.Focus()
        End Sub

        Private Sub MainGrid_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainGrid.AfterDelete
            Me.decreaseCount()
            txtDeviceSN.Focus()
        End Sub

        Private Sub runPrint()

            Dim tmpShift As Integer
            tmpShift = PSS.Core.Global.ApplicationUser.IDShift


            Dim numCopies As Integer = 2

            If mCustomer = 1403 Then numCopies = 10
            If mCustomer = 2069 Then numCopies = 10

            btnPrint.Enabled = False

            Dim strReportLoc As String = PSS.Core.ReportPath
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '//Write records from grid to database
            'MainWin.StatusBar.SetStatusText("Writing Devices to the Database")

            Dim tmpWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
            If Len(Trim(tmpWorkDate)) < 1 Then
                MsgBox("Your user configuration is incorrect/incomplete. Please contact your direct lead to resolve this problem. Your login will not function until this is resolved.", MsgBoxStyle.Critical, "User Setup Error")
                End
            End If

            Dim blnRecDevice As Boolean '= tReceiving.ReceivingTransmitDeviceData(dataGrid)
            blnRecDevice = PSS.Data.Production.tdevice.ReceivingTransmitDeviceData(dataGrid, DeviceType, RecType, tmpShift, tmpWorkDate)

            If blnRecDevice = False Then
                MsgBox("An error occurred while writing the devices to the database. No devices were entered.", MsgBoxStyle.OKOnly)
                btnPrint.Enabled = True
                Exit Sub
            End If

            Dim valStage As Integer
            valStage = 0

            If valStage = 0 Then
                '//Report to Print
                'MainWin.StatusBar.SetStatusText("Sending Worksheet to Printer")
                Try
                    'Dim rptApp As New CRAXDRT.Application()
                    'Dim rpt As New CRAXDRT.Report()
                    Dim objRpt As ReportDocument

                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Core.Global.ReportPath & "Rec_Worksheet_Cell.rpt")
                        .RecordSelectionFormula = "{ttray.Tray_ID} = " & Me.lblTrayVAL.Text.Trim
                        .PrintToPrinter(numCopies, True, 0, 0)
                    End With

                    'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet_Cell.rpt")
                    ''rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet_TEST.rpt")
                    'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(Me.lblTrayVAL.Text)
                    'rpt.PrintOut(False, numCopies)

                    'rpt = Nothing
                    'rptApp = Nothing

                Catch exp As Exception
                    MsgBox(exp.ToString)
                    Cursor.Current = System.Windows.Forms.Cursors.Default
                End Try

                If blnAutoBill = True Then
                    If intBillCode > 0 Then
                        mTray = Trim(Me.lblTrayVAL.Text)
                        AutoBill(intBillCode)
                    End If
                End If

            End If
            'releaseControls()
            If cboDateCode.Enabled = True Then cboDateCode.Text = ""
            If txtPOP.Enabled = True Then txtPOP.Text = ""
            If cboAPC.Enabled = True Then cboAPC.Text = ""
            If txtIncIMEI.Enabled = True Then txtIncIMEI.Text = ""
            If txtCourierTrackIN.Enabled = True Then txtCourierTrackIN.Text = ""
            If cboCarrier.Enabled = True Then cboCarrier.Text = ""
            If cboTransaction.Enabled = True Then cboTransaction.Text = ""
            If txtTransceiver.Enabled = True Then txtTransceiver.Text = ""
            If txtCarrModelCode.Enabled = True Then txtCarrModelCode.Text = ""
            If txtMIN.Enabled = True Then txtMIN.Text = ""
            If txtProduct.Enabled = True Then txtProduct.Text = ""
            If cboComplaint.Enabled = True Then cboComplaint.Text = ""
            If cboReturn.Enabled = True Then cboReturn.Text = ""


            txtRMA.Focus()
            dataGrid.Clear()
            lblTrayVAL.Text = ""
            mTray = 0
            lblCountVAL.Text = 0

            Cursor.Current = System.Windows.Forms.Cursors.Default
            'MainWin.StatusBar.SetStatusText("")

            txtDeviceSN.Focus()

            btnPrint.Enabled = True

        End Sub
        Private Sub btnPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            runPrint()
        End Sub
        Private Sub lblTransceiverCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblTransceiverCode.Leave
            txtTransceiver.Text = UCase(txtTransceiver.Text)
        End Sub
        Private Sub btnContinue_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContinue.Enter

            Dim blnEnter As Boolean = InsertDevice()

            If GridHeight < 100 Then GridHeight = 385 '376
            MainGrid.Height = GridHeight

            cboDateCode.Enabled = True
            cboDateCode.Text = ""

            txtDeviceSN.Text = ""
            txtDeviceSN.Focus()

        End Sub
        Private Sub cboDateCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDateCode.Leave
            'checkManufWrty()
        End Sub

        Private Sub checkManufWrty()
            If Len(Trim(cboDateCode.Text)) > 0 Then
                Try
                    Dim tMWrty As DataTable = PSS.Data.Production.lmanufwrty.GetManufWrtyData(Trim(cboDateCode.Text), mManufacturer)
                    Dim r As DataRow = tMWrty.Rows(0)
                    If CDate(r("ManufWrty_Exp")) < Now Then
                        mManufWrty = "-"
                        showPOP()
                    Else
                        mManufWrty = "S"
                    End If
                    tMWrty.Dispose()
                    tMWrty = Nothing
                Catch ex As Exception
                End Try
            End If
        End Sub

        Private Sub PopulatePSSwrtyFields()

            '//Assign values for PSS warranty selection
            Dim xCount As Integer = 0
            Dim tblCustomer As New PSS.Data.Production.tcustomer()
            Dim drCustomer As DataRow = tblCustomer.GetRowByPK(mCustomer)

            Try
                CustPSSwrtyRejectDays = drCustomer("Cust_RejectDays")
            Catch exp As Exception
                CustPSSwrtyRejectDays = 0
            End Try

            Try
                CustPSSwrtyRejectTimes = drCustomer("Cust_RejectTimes")
            Catch exp As Exception
                CustPSSwrtyRejectTimes = 0
            End Try

            Try
                Dim tblCustWrty As New PSS.Data.Production.tcustwrty()
                Dim drCustWrty As DataRow = tblCustWrty.GetRowByCustID(mCustomer)

                CustPSSwrtyParts = drCustWrty("PSSwrtyParts_ID")
                CustPSSwrtyLabor = drCustWrty("PSSwrtyLabor_ID")
                CustPSSwrtyDaysInWrty = drCustWrty("CustWrty_DaysInWrty")

                drCustWrty = Nothing
                tblCustWrty = Nothing

            Catch exp As Exception
            End Try

            drCustomer = Nothing
            tblCustomer = Nothing

        End Sub

        Private Sub determinePSSwrty()

            '//PSS Warranty secition here
            Dim valDBR As Boolean = False
            Dim BillDeviceID As Int32
            Dim xCount As Integer = 0
            Dim pssDate As Date

            PopulatePSSwrtyFields()
            Dim wrtyDays As Integer = -1 * CustPSSwrtyDaysInWrty
            pssDate = DateAdd(DateInterval.Day, wrtyDays, Now)

            Dim pssDateMonth As String
            Dim pssDateDay As String
            Dim pssDateYear As String
            Dim pssNewDate As String

            pssNewDate = DatePart(DateInterval.Year, pssDate) & "-" & DatePart(DateInterval.Month, pssDate) & "-" & DatePart(DateInterval.Day, pssDate)
            mPSSwrty = False

            'Try

            Dim dtPSSwrty As DataTable

            If mManufacturer = 1 Then
                dtPSSwrty = PSS.Data.Production.Joins.chkPSSwrtyMotorola(txtDeviceSN.Text, pssNewDate)
            Else
                dtPSSwrty = PSS.Data.Production.Joins.chkPSSwrty(txtDeviceSN.Text, mLocation, pssNewDate)
            End If

            Dim r As DataRow

            '//If there is no data record then the PSS warranty should be false
            If dtPSSwrty.Rows(0)("repeat") <> False Then
                mPSSwrty = True
                '//Warranty is not valid if device has been DBR d
                For xCount = 0 To dtPSSwrty.Rows.Count - 1
                    BillDeviceID = dtPSSwrty.Rows(0)("repeat")
                    'Dim tblPSSwrtyBILL As New PSS.Data.Production.Joins()
                    Dim dtPSSbill As DataTable = PSS.Data.Production.Joins.chkPSSwrtyBILL(BillDeviceID)
                    If dtPSSbill.Rows.Count > 0 Then
                        mPSSwrty = False
                        valDBR = True
                    End If
                Next
            End If

            dtPSSwrty.Dispose()
            dtPSSwrty = Nothing
        End Sub

        Private Sub HotKeysF12(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtDeviceSN.KeyDown
            If e.KeyCode = Keys.F12 Then
                runPrint()
            End If
        End Sub

        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click

            Dim strReportLoc As String = PSS.Core.ReportPath

            Try
                Dim TmptrayVal As Int32
                TmptrayVal = InputBox("Enter tray value for reprint", "Reprint")

                'Dim rptApp As New CRAXDRT.Application()
                'Dim rpt As New CRAXDRT.Report()
                Dim objRpt As ReportDocument

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")
                    .RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(TmptrayVal)
                    .PrintToPrinter(2, True, 0, 0)
                End With

                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Rec_Worksheet.rpt")
                'rpt.RecordSelectionFormula = "{ttray.Tray_ID} = " & Trim(TmptrayVal)
                'rpt.PrintOut(False, 2)
                'rpt = Nothing
                'rptApp = Nothing
            Catch exp As Exception
            End Try
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub

        Private Sub btnDecimal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecimal.Click

            Dim vDecimal As String
            vDecimal = InputBox("Enter decimal value for device", "HEX from Decimal")

            If mDecimalType <> "GSM/PCS" Then

                Try
                    If Len(Trim(vDecimal)) = 11 Then
                        'Make hex code conversion here
                        Dim valDec As String = Mid$(Trim(vDecimal), 1, 11)
                        Dim vals1 As String = Mid$(Trim(vDecimal), 1, 3)
                        Dim vals2 As String = Mid$(Trim(vDecimal), 4, 8)
                        Dim valHex1 As System.String
                        valHex1 = Hex(vals1)
                        Dim valHex2 As System.String
                        valHex2 = Hex(vals2)
                        txtDeviceSN.Text = Trim(valHex1) & Trim(valHex2)

                        Dim vDC As String
                        vDC = InputBox("Enter date code for device", "Date Code")

                        If Len(Trim(vDC)) < 4 And Len(Trim(vDC)) > 0 Then
                            txtDeviceSN.Text = txtDeviceSN.Text & UCase(vDC)
                        End If
                        txtDeviceSN.Focus()
                    Else
                        MsgBox("Can NOT convert over decimal value to hex. Please enter serial number manually.", MsgBoxStyle.OKOnly)
                        txtDeviceSN.Focus()
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox("Can NOT convert over decimal value to hex. Please enter serial number manually.", MsgBoxStyle.OKOnly)
                    txtDeviceSN.Focus()
                End Try

            End If

        End Sub

        Private Sub txtIncIMEI_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIncIMEI.Leave

            Dim x As Integer

            If txtIncIMEI.Visible = True Then
                If Len(Trim(txtIncIMEI.Text)) < 13 Or Len(Trim(txtIncIMEI.Text)) > 15 Then
                    MsgBox("Enter a valid (13 to 15 character) Incoming IMEI value before continuing.", MsgBoxStyle.OKOnly)
                    txtIncIMEI.Focus()
                    Exit Sub
                Else
                    For x = 1 To Len(Trim(txtIncIMEI.Text))
                        If IsNumeric(Mid$(txtIncIMEI.Text, x, 1)) = True Then
                        Else
                            MsgBox("Invalid Incoming IMEI", MsgBoxStyle.OKOnly)
                            txtIncIMEI.Focus()
                            Exit Sub
                        End If
                    Next
                End If
            End If

            Try
                mMSN = txtDeviceSN.Text
            Catch ex As Exception
            End Try

        End Sub

        Private Sub txtTransceiver_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransceiver.Leave
            If Len(Trim(txtTransceiver.Text)) > 0 Then
                If Len(Trim(txtTransceiver.Text)) > 15 Then
                    txtTransceiver.Focus()
                End If
            End If
        End Sub

        Private Sub txtDeviceSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged

        End Sub

        Private Sub txtIncIMEI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIncIMEI.TextChanged

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


        Private Sub AutoBill(ByVal intBillCode As Integer)

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


        Private Sub txtAirtime_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAirtime.Leave
            If IsNumeric(txtAirtime.Text) = False Then
                txtAirtime.Text = PSS.Gui.Receiving.General.convertAirTime(txtAirtime.Text)
            End If
        End Sub

        Private Function verifyIncomingCS_ESN(ByVal mESN As String) As Boolean
            Try
                Dim mRMA As String = Trim(txtRMA.Text)
                If Len(Trim(mESN)) > 0 And Len(Trim(mRMA)) > 0 Then

                    Dim strSQL As String = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & mRMA & "' AND csin_ESN = '" & mESN & "'"
                    Dim mDS As PSS.Data.Production.Joins
                    Dim dt As DataTable = mDS.OrderEntrySelect(strSQL)

                    If dt.Rows.Count > 0 Then
                        dt.Dispose()
                        dt = Nothing
                        Return True
                    Else
                        Return False
                    End If
                End If
            Catch ex As Exception
                Return False
            End Try



        End Function



        Private Sub chkManufWrty_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles chkManufWrty.KeyDown
            If e.KeyCode = 13 Then NextElement()
        End Sub

    End Class

End Namespace


