Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Warehouse
    Public Class frmFillOrders
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private _bSendSparePart As Boolean = False
        Private _objSO As OrderFulfilment
        Private _booPopulateData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            Me._iMenuCustID = iCustID
            _objSO = New OrderFulfilment()
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
        Friend WithEvents grbShipmentInfo As System.Windows.Forms.GroupBox
        Friend WithEvents txtShippingCost As System.Windows.Forms.TextBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblFilledQty As System.Windows.Forms.Label
        Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboShipCarrier As C1.Win.C1List.C1Combo
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnCloseOrder As System.Windows.Forms.Button
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboOpenOrderNo As C1.Win.C1List.C1Combo
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpgFillOrder As System.Windows.Forms.TabPage
        Friend WithEvents tpgOpenOrders As System.Windows.Forms.TabPage
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents dbgOrderDetails As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgOpenOrders As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblLineQty As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents pnlShipCarrierInfo As System.Windows.Forms.Panel
        Friend WithEvents btnRefreshWipData As System.Windows.Forms.Button
        Friend WithEvents btnRefreshOpenOrderDetail As System.Windows.Forms.Button
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtShipQty As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtCancelReason As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents btnCancelOrder As System.Windows.Forms.Button
        Friend WithEvents txtPackShipCostDesc As System.Windows.Forms.TextBox
        Friend WithEvents lblPackShipCostDesc As System.Windows.Forms.Label
        Friend WithEvents lblBillCodeID As System.Windows.Forms.Label
        Friend WithEvents lblPackShipCostAmt As System.Windows.Forms.Label
        Friend WithEvents lblShippingCost As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents txtShipPhone_1 As System.Windows.Forms.TextBox
        ' Friend WithEvents txtCity_1 As System.Windows.Forms.TextBox
        Friend WithEvents txtState As System.Windows.Forms.TextBox
        Friend WithEvents txtCity As System.Windows.Forms.TextBox
        Friend WithEvents lblCustPONo As System.Windows.Forms.Label
        Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
        Friend WithEvents txtShipPhone As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFillOrders))
            Me.grbShipmentInfo = New System.Windows.Forms.GroupBox()
            'Me.lblCustPONo_1 = New System.Windows.Forms.Label()
            'Me.txtZipCode_1 = New System.Windows.Forms.TextBox()
            'Me.txtState_1 = New System.Windows.Forms.TextBox()
            'Me.txtAddress2_2 = New System.Windows.Forms.TextBox()
            'Me.txtShipPhone_1 = New System.Windows.Forms.TextBox()
            'Me.txtCity_1 = New System.Windows.Forms.TextBox()
            'Me.txtAddress1_1 = New System.Windows.Forms.TextBox()
            'Me.txtName_1 = New System.Windows.Forms.TextBox()
            'Me.Label12_1 = New System.Windows.Forms.Label()
            Me.txtShippingCost = New System.Windows.Forms.TextBox()
            Me.lblShippingCost = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblFilledQty = New System.Windows.Forms.Label()
            Me.txtTrackingNo = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboShipCarrier = New C1.Win.C1List.C1Combo()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnCloseOrder = New System.Windows.Forms.Button()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboOpenOrderNo = New C1.Win.C1List.C1Combo()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpgFillOrder = New System.Windows.Forms.TabPage()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtShipQty = New System.Windows.Forms.TextBox()
            Me.btnRefreshWipData = New System.Windows.Forms.Button()
            Me.pnlShipCarrierInfo = New System.Windows.Forms.Panel()
            Me.lblPackShipCostDesc = New System.Windows.Forms.Label()
            Me.txtPackShipCostDesc = New System.Windows.Forms.TextBox()
            Me.lblBillCodeID = New System.Windows.Forms.Label()
            Me.lblPackShipCostAmt = New System.Windows.Forms.Label()
            Me.lblLineQty = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.dbgOrderDetails = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tpgOpenOrders = New System.Windows.Forms.TabPage()
            Me.btnCancelOrder = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtCancelReason = New System.Windows.Forms.TextBox()
            Me.btnRefreshOpenOrderDetail = New System.Windows.Forms.Button()
            Me.dbgOpenOrders = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.txtAddress1 = New System.Windows.Forms.TextBox()
            Me.txtAddress2 = New System.Windows.Forms.TextBox()
            Me.txtState = New System.Windows.Forms.TextBox()
            Me.txtCity = New System.Windows.Forms.TextBox()
            Me.lblCustPONo = New System.Windows.Forms.Label()
            Me.txtZipCode = New System.Windows.Forms.TextBox()
            Me.txtShipPhone = New System.Windows.Forms.TextBox()
            Me.grbShipmentInfo.SuspendLayout()
            CType(Me.cboShipCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboOpenOrderNo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpgFillOrder.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.pnlShipCarrierInfo.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dbgOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgOpenOrders.SuspendLayout()
            CType(Me.dbgOpenOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbShipmentInfo
            '
            Me.grbShipmentInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCustPONo, Me.txtZipCode, Me.txtShipPhone, Me.txtState, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.txtName, Me.Label12})
            Me.grbShipmentInfo.Location = New System.Drawing.Point(8, 112)
            Me.grbShipmentInfo.Name = "grbShipmentInfo"
            Me.grbShipmentInfo.Size = New System.Drawing.Size(336, 224)
            Me.grbShipmentInfo.TabIndex = 144
            Me.grbShipmentInfo.TabStop = False
            '
            ''lblCustPONo_1
            ''
            'Me.lblCustPONo_1.Name = "lblCustPONo_1"
            'Me.lblCustPONo_1.TabIndex = 0
            ''
            ''txtZipCode_1
            ''
            'Me.txtZipCode_1.Name = "txtZipCode_1"
            'Me.txtZipCode_1.TabIndex = 0
            'Me.txtZipCode_1.Text = ""
            ''
            ''txtState_1
            ''
            'Me.txtState_1.Name = "txtState_1"
            'Me.txtState_1.TabIndex = 0
            'Me.txtState_1.Text = ""
            ''
            ''txtAddress2_2
            ''
            'Me.txtAddress2_2.Name = "txtAddress2_2"
            'Me.txtAddress2_2.TabIndex = 0
            'Me.txtAddress2_2.Text = ""
            ''
            ''txtShipPhone_1
            ''
            'Me.txtShipPhone_1.Name = "txtShipPhone_1"
            'Me.txtShipPhone_1.TabIndex = 0
            'Me.txtShipPhone_1.Text = ""
            ''
            ''txtCity_1
            ''
            'Me.txtCity_1.BackColor = System.Drawing.SystemColors.Info
            'Me.txtCity_1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'Me.txtCity_1.ForeColor = System.Drawing.SystemColors.Desktop
            'Me.txtCity_1.Location = New System.Drawing.Point(8, 136)
            'Me.txtCity_1.Name = "txtCity_1"
            'Me.txtCity_1.Size = New System.Drawing.Size(176, 23)
            'Me.txtCity_1.TabIndex = 4
            'Me.txtCity_1.Text = ""
            ''
            ''txtAddress1_1
            ''
            'Me.txtAddress1_1.BackColor = System.Drawing.SystemColors.Info
            'Me.txtAddress1_1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'Me.txtAddress1_1.ForeColor = System.Drawing.SystemColors.Desktop
            'Me.txtAddress1_1.Location = New System.Drawing.Point(8, 88)
            'Me.txtAddress1_1.Name = "txtAddress1_1"
            'Me.txtAddress1_1.Size = New System.Drawing.Size(320, 23)
            'Me.txtAddress1_1.TabIndex = 2
            'Me.txtAddress1_1.Text = ""
            ''
            ''txtName_1
            ''
            'Me.txtName_1.BackColor = System.Drawing.SystemColors.Info
            'Me.txtName_1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'Me.txtName_1.ForeColor = System.Drawing.SystemColors.Desktop
            'Me.txtName_1.Location = New System.Drawing.Point(8, 40)
            'Me.txtName_1.Multiline = True
            'Me.txtName_1.Name = "txtName_1"
            'Me.txtName_1.Size = New System.Drawing.Size(320, 42)
            'Me.txtName_1.TabIndex = 1
            'Me.txtName_1.Text = ""
            ''
            ''Label12_1
            ''
            'Me.Label12_1.BackColor = System.Drawing.Color.Transparent
            'Me.Label12_1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            'Me.Label12_1.ForeColor = System.Drawing.Color.White
            'Me.Label12_1.Location = New System.Drawing.Point(1, 24)
            'Me.Label12_1.Name = "Label12_1"
            'Me.Label12_1.Size = New System.Drawing.Size(72, 16)
            'Me.Label12_1.TabIndex = 135
            'Me.Label12_1.Text = "Address :"
            'Me.Label12_1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShippingCost
            '
            Me.txtShippingCost.Location = New System.Drawing.Point(128, 80)
            Me.txtShippingCost.Name = "txtShippingCost"
            Me.txtShippingCost.Size = New System.Drawing.Size(56, 20)
            Me.txtShippingCost.TabIndex = 3
            Me.txtShippingCost.Text = ""
            '
            'lblShippingCost
            '
            Me.lblShippingCost.BackColor = System.Drawing.Color.Transparent
            Me.lblShippingCost.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShippingCost.ForeColor = System.Drawing.Color.White
            Me.lblShippingCost.Location = New System.Drawing.Point(16, 80)
            Me.lblShippingCost.Name = "lblShippingCost"
            Me.lblShippingCost.Size = New System.Drawing.Size(112, 16)
            Me.lblShippingCost.TabIndex = 137
            Me.lblShippingCost.Text = "Shipping Cost :"
            Me.lblShippingCost.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(720, 176)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(80, 16)
            Me.Label11.TabIndex = 133
            Me.Label11.Text = "Filled Qty"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblFilledQty
            '
            Me.lblFilledQty.BackColor = System.Drawing.Color.Black
            Me.lblFilledQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblFilledQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFilledQty.ForeColor = System.Drawing.Color.Lime
            Me.lblFilledQty.Location = New System.Drawing.Point(728, 192)
            Me.lblFilledQty.Name = "lblFilledQty"
            Me.lblFilledQty.Size = New System.Drawing.Size(72, 32)
            Me.lblFilledQty.TabIndex = 134
            Me.lblFilledQty.Text = "0"
            Me.lblFilledQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtTrackingNo
            '
            Me.txtTrackingNo.Location = New System.Drawing.Point(128, 48)
            Me.txtTrackingNo.Name = "txtTrackingNo"
            Me.txtTrackingNo.Size = New System.Drawing.Size(184, 20)
            Me.txtTrackingNo.TabIndex = 2
            Me.txtTrackingNo.Text = ""
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(40, 48)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 125
            Me.Label7.Text = "Tracking # :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboShipCarrier
            '
            Me.cboShipCarrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboShipCarrier.AutoCompletion = True
            Me.cboShipCarrier.AutoDropDown = True
            Me.cboShipCarrier.AutoSelect = True
            Me.cboShipCarrier.Caption = ""
            Me.cboShipCarrier.CaptionHeight = 17
            Me.cboShipCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboShipCarrier.ColumnCaptionHeight = 17
            Me.cboShipCarrier.ColumnFooterHeight = 17
            Me.cboShipCarrier.ColumnHeaders = False
            Me.cboShipCarrier.ContentHeight = 15
            Me.cboShipCarrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboShipCarrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboShipCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboShipCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboShipCarrier.EditorHeight = 15
            Me.cboShipCarrier.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboShipCarrier.ItemHeight = 15
            Me.cboShipCarrier.Location = New System.Drawing.Point(128, 16)
            Me.cboShipCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipCarrier.MaxDropDownItems = CType(10, Short)
            Me.cboShipCarrier.MaxLength = 32767
            Me.cboShipCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipCarrier.Name = "cboShipCarrier"
            Me.cboShipCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipCarrier.Size = New System.Drawing.Size(184, 21)
            Me.cboShipCarrier.TabIndex = 1
            Me.cboShipCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(24, 16)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(104, 21)
            Me.Label6.TabIndex = 124
            Me.Label6.Text = "Ship Carrier :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCloseOrder
            '
            Me.btnCloseOrder.BackColor = System.Drawing.Color.Green
            Me.btnCloseOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseOrder.ForeColor = System.Drawing.Color.White
            Me.btnCloseOrder.Location = New System.Drawing.Point(552, 376)
            Me.btnCloseOrder.Name = "btnCloseOrder"
            Me.btnCloseOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseOrder.Size = New System.Drawing.Size(144, 21)
            Me.btnCloseOrder.TabIndex = 8
            Me.btnCloseOrder.Text = "CLOSE && SHIP ORDER"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(552, 176)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(72, 16)
            Me.Label9.TabIndex = 131
            Me.Label9.Text = "Order Qty"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.Black
            Me.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.Lime
            Me.lblOrderQty.Location = New System.Drawing.Point(552, 192)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(72, 32)
            Me.lblOrderQty.TabIndex = 132
            Me.lblOrderQty.Text = "0"
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.AutoCompletion = True
            Me.cboCustomer.AutoDropDown = True
            Me.cboCustomer.AutoSelect = True
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ColumnHeaders = False
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(80, 40)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(264, 21)
            Me.cboCustomer.TabIndex = 1
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(0, 40)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 21)
            Me.Label4.TabIndex = 138
            Me.Label4.Text = "Customer :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboOpenOrderNo
            '
            Me.cboOpenOrderNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenOrderNo.AutoCompletion = True
            Me.cboOpenOrderNo.AutoDropDown = True
            Me.cboOpenOrderNo.AutoSelect = True
            Me.cboOpenOrderNo.Caption = ""
            Me.cboOpenOrderNo.CaptionHeight = 17
            Me.cboOpenOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenOrderNo.ColumnCaptionHeight = 17
            Me.cboOpenOrderNo.ColumnFooterHeight = 17
            Me.cboOpenOrderNo.ColumnHeaders = False
            Me.cboOpenOrderNo.ContentHeight = 15
            Me.cboOpenOrderNo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenOrderNo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenOrderNo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrderNo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenOrderNo.EditorHeight = 15
            Me.cboOpenOrderNo.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboOpenOrderNo.ItemHeight = 15
            Me.cboOpenOrderNo.Location = New System.Drawing.Point(80, 72)
            Me.cboOpenOrderNo.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenOrderNo.MaxDropDownItems = CType(10, Short)
            Me.cboOpenOrderNo.MaxLength = 32767
            Me.cboOpenOrderNo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenOrderNo.Name = "cboOpenOrderNo"
            Me.cboOpenOrderNo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenOrderNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenOrderNo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenOrderNo.Size = New System.Drawing.Size(192, 21)
            Me.cboOpenOrderNo.TabIndex = 2
            Me.cboOpenOrderNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(8, 72)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 21)
            Me.Label5.TabIndex = 136
            Me.Label5.Text = "Order # :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Black
            Me.lblHeader.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
            Me.lblHeader.Location = New System.Drawing.Point(8, 0)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(336, 32)
            Me.lblHeader.TabIndex = 140
            Me.lblHeader.Text = "Fill Order"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'TabControl1
            '
            Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgFillOrder, Me.tpgOpenOrders})
            Me.TabControl1.Location = New System.Drawing.Point(0, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1072, 496)
            Me.TabControl1.TabIndex = 141
            '
            'tpgFillOrder
            '
            Me.tpgFillOrder.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgFillOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.btnRefreshWipData, Me.pnlShipCarrierInfo, Me.lblLineQty, Me.Label2, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.GroupBox1, Me.dbgOrderDetails, Me.Label4, Me.cboCustomer, Me.lblHeader, Me.cboOpenOrderNo, Me.Label5, Me.grbShipmentInfo, Me.btnCloseOrder, Me.Label9, Me.lblFilledQty, Me.lblOrderQty, Me.Label11})
            Me.tpgFillOrder.Location = New System.Drawing.Point(4, 22)
            Me.tpgFillOrder.Name = "tpgFillOrder"
            Me.tpgFillOrder.Size = New System.Drawing.Size(1064, 470)
            Me.tpgFillOrder.TabIndex = 0
            Me.tpgFillOrder.Text = "Fill Order"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.txtShipQty})
            Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(816, 168)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(152, 288)
            Me.GroupBox2.TabIndex = 143
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Parts"
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(8, 32)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(128, 24)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "Ship Quantity:"
            '
            'txtShipQty
            '
            Me.txtShipQty.Location = New System.Drawing.Point(8, 56)
            Me.txtShipQty.Name = "txtShipQty"
            Me.txtShipQty.Size = New System.Drawing.Size(128, 27)
            Me.txtShipQty.TabIndex = 0
            Me.txtShipQty.Text = ""
            '
            'btnRefreshWipData
            '
            Me.btnRefreshWipData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshWipData.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshWipData.ForeColor = System.Drawing.Color.White
            Me.btnRefreshWipData.Location = New System.Drawing.Point(280, 72)
            Me.btnRefreshWipData.Name = "btnRefreshWipData"
            Me.btnRefreshWipData.Size = New System.Drawing.Size(64, 23)
            Me.btnRefreshWipData.TabIndex = 3
            Me.btnRefreshWipData.Text = "Refresh"
            '
            'pnlShipCarrierInfo
            '
            Me.pnlShipCarrierInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtShippingCost, Me.lblShippingCost, Me.txtTrackingNo, Me.cboShipCarrier, Me.Label6, Me.Label7, Me.lblPackShipCostDesc, Me.txtPackShipCostDesc, Me.lblBillCodeID, Me.lblPackShipCostAmt})
            Me.pnlShipCarrierInfo.Location = New System.Drawing.Point(8, 336)
            Me.pnlShipCarrierInfo.Name = "pnlShipCarrierInfo"
            Me.pnlShipCarrierInfo.Size = New System.Drawing.Size(336, 112)
            Me.pnlShipCarrierInfo.TabIndex = 5
            '
            'lblPackShipCostDesc
            '
            Me.lblPackShipCostDesc.BackColor = System.Drawing.Color.Transparent
            Me.lblPackShipCostDesc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPackShipCostDesc.ForeColor = System.Drawing.Color.White
            Me.lblPackShipCostDesc.Location = New System.Drawing.Point(152, 80)
            Me.lblPackShipCostDesc.Name = "lblPackShipCostDesc"
            Me.lblPackShipCostDesc.Size = New System.Drawing.Size(136, 16)
            Me.lblPackShipCostDesc.TabIndex = 139
            Me.lblPackShipCostDesc.Text = "Pack && Ship Cost :"
            Me.lblPackShipCostDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPackShipCostDesc
            '
            Me.txtPackShipCostDesc.BackColor = System.Drawing.SystemColors.Info
            Me.txtPackShipCostDesc.Location = New System.Drawing.Point(288, 80)
            Me.txtPackShipCostDesc.Name = "txtPackShipCostDesc"
            Me.txtPackShipCostDesc.Size = New System.Drawing.Size(40, 20)
            Me.txtPackShipCostDesc.TabIndex = 138
            Me.txtPackShipCostDesc.Text = ""
            '
            'lblBillCodeID
            '
            Me.lblBillCodeID.Location = New System.Drawing.Point(320, 48)
            Me.lblBillCodeID.Name = "lblBillCodeID"
            Me.lblBillCodeID.Size = New System.Drawing.Size(24, 32)
            Me.lblBillCodeID.TabIndex = 144
            '
            'lblPackShipCostAmt
            '
            Me.lblPackShipCostAmt.Location = New System.Drawing.Point(320, 8)
            Me.lblPackShipCostAmt.Name = "lblPackShipCostAmt"
            Me.lblPackShipCostAmt.Size = New System.Drawing.Size(40, 32)
            Me.lblPackShipCostAmt.TabIndex = 145
            Me.lblPackShipCostAmt.Text = "0.0"
            '
            'lblLineQty
            '
            Me.lblLineQty.BackColor = System.Drawing.Color.Black
            Me.lblLineQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblLineQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineQty.ForeColor = System.Drawing.Color.Lime
            Me.lblLineQty.Location = New System.Drawing.Point(640, 192)
            Me.lblLineQty.Name = "lblLineQty"
            Me.lblLineQty.Size = New System.Drawing.Size(72, 32)
            Me.lblLineQty.TabIndex = 142
            Me.lblLineQty.Text = "0"
            Me.lblLineQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(632, 176)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 141
            Me.Label2.Text = "Line Qty"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(552, 264)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(144, 30)
            Me.btnRemoveAllSNs.TabIndex = 9
            Me.btnRemoveAllSNs.Text = "REMOVE ALL ITEMS"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(552, 304)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(144, 30)
            Me.btnRemoveSN.TabIndex = 10
            Me.btnRemoveSN.Text = "REMOVE ITEM"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lstDevices, Me.txtDevSN, Me.Label10})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(352, 160)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(152, 288)
            Me.GroupBox1.TabIndex = 7
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Devices"
            '
            'lstDevices
            '
            Me.lstDevices.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstDevices.Location = New System.Drawing.Point(8, 72)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(136, 199)
            Me.lstDevices.TabIndex = 2
            '
            'txtDevSN
            '
            Me.txtDevSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDevSN.Location = New System.Drawing.Point(8, 48)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(136, 21)
            Me.txtDevSN.TabIndex = 1
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 32)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(136, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "S/N :"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'dbgOrderDetails
            '
            Me.dbgOrderDetails.AllowUpdate = False
            Me.dbgOrderDetails.AlternatingRows = True
            Me.dbgOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgOrderDetails.FilterBar = True
            Me.dbgOrderDetails.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgOrderDetails.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dbgOrderDetails.Location = New System.Drawing.Point(352, 2)
            Me.dbgOrderDetails.Name = "dbgOrderDetails"
            Me.dbgOrderDetails.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgOrderDetails.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgOrderDetails.PreviewInfo.ZoomFactor = 75
            Me.dbgOrderDetails.Size = New System.Drawing.Size(704, 150)
            Me.dbgOrderDetails.TabIndex = 6
            Me.dbgOrderDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>1" & _
            "46</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 700, 146<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 700, 146</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'tpgOpenOrders
            '
            Me.tpgOpenOrders.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgOpenOrders.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelOrder, Me.Label8, Me.txtCancelReason, Me.btnRefreshOpenOrderDetail, Me.dbgOpenOrders})
            Me.tpgOpenOrders.Location = New System.Drawing.Point(4, 22)
            Me.tpgOpenOrders.Name = "tpgOpenOrders"
            Me.tpgOpenOrders.Size = New System.Drawing.Size(1064, 470)
            Me.tpgOpenOrders.TabIndex = 1
            Me.tpgOpenOrders.Text = "Open Orders"
            '
            'btnCancelOrder
            '
            Me.btnCancelOrder.BackColor = System.Drawing.Color.Red
            Me.btnCancelOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancelOrder.ForeColor = System.Drawing.Color.White
            Me.btnCancelOrder.Location = New System.Drawing.Point(800, 8)
            Me.btnCancelOrder.Name = "btnCancelOrder"
            Me.btnCancelOrder.Size = New System.Drawing.Size(96, 23)
            Me.btnCancelOrder.TabIndex = 2
            Me.btnCancelOrder.Text = "Cancel Order"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(8, 12)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(100, 16)
            Me.Label8.TabIndex = 15
            Me.Label8.Text = "Cancel Reason :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCancelReason
            '
            Me.txtCancelReason.BackColor = System.Drawing.Color.White
            Me.txtCancelReason.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCancelReason.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtCancelReason.Location = New System.Drawing.Point(112, 8)
            Me.txtCancelReason.Name = "txtCancelReason"
            Me.txtCancelReason.Size = New System.Drawing.Size(672, 21)
            Me.txtCancelReason.TabIndex = 1
            Me.txtCancelReason.Text = ""
            '
            'btnRefreshOpenOrderDetail
            '
            Me.btnRefreshOpenOrderDetail.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnRefreshOpenOrderDetail.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshOpenOrderDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshOpenOrderDetail.ForeColor = System.Drawing.Color.White
            Me.btnRefreshOpenOrderDetail.Location = New System.Drawing.Point(992, 8)
            Me.btnRefreshOpenOrderDetail.Name = "btnRefreshOpenOrderDetail"
            Me.btnRefreshOpenOrderDetail.Size = New System.Drawing.Size(64, 23)
            Me.btnRefreshOpenOrderDetail.TabIndex = 3
            Me.btnRefreshOpenOrderDetail.Text = "Refresh"
            '
            'dbgOpenOrders
            '
            Me.dbgOpenOrders.AllowUpdate = False
            Me.dbgOpenOrders.AlternatingRows = True
            Me.dbgOpenOrders.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgOpenOrders.FilterBar = True
            Me.dbgOpenOrders.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgOpenOrders.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dbgOpenOrders.Location = New System.Drawing.Point(8, 48)
            Me.dbgOpenOrders.Name = "dbgOpenOrders"
            Me.dbgOpenOrders.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgOpenOrders.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgOpenOrders.PreviewInfo.ZoomFactor = 75
            Me.dbgOpenOrders.Size = New System.Drawing.Size(1048, 408)
            Me.dbgOpenOrders.TabIndex = 12
            Me.dbgOpenOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
            "04</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 1044, 404" & _
            "</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win" & _
            ".C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><St" & _
            "yle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style " & _
            "parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style p" & _
            "arent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style paren" & _
            "t=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pare" & _
            "nt=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style p" & _
            "arent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyl" & _
            "es><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 1044, 404</ClientArea><" & _
            "PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me" & _
            "=""Style21"" /></Blob>"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(136, 16)
            Me.Label1.TabIndex = 99
            Me.Label1.Text = "Ship Quantity :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(1, 24)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(72, 16)
            Me.Label12.TabIndex = 136
            Me.Label12.Text = "Address :"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtName
            '
            Me.txtName.BackColor = System.Drawing.SystemColors.Info
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtName.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtName.Location = New System.Drawing.Point(8, 40)
            Me.txtName.Multiline = True
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(320, 42)
            Me.txtName.TabIndex = 137
            Me.txtName.Text = ""
            '
            'txtAddress1
            '
            Me.txtAddress1.BackColor = System.Drawing.SystemColors.Info
            Me.txtAddress1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress1.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtAddress1.Location = New System.Drawing.Point(8, 88)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.Size = New System.Drawing.Size(320, 23)
            Me.txtAddress1.TabIndex = 138
            Me.txtAddress1.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.BackColor = System.Drawing.SystemColors.Info
            Me.txtAddress2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress2.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtAddress2.Location = New System.Drawing.Point(8, 112)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.Size = New System.Drawing.Size(320, 23)
            Me.txtAddress2.TabIndex = 139
            Me.txtAddress2.Text = ""
            '
            'txtState
            '
            Me.txtState.BackColor = System.Drawing.SystemColors.Info
            Me.txtState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtState.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtState.Location = New System.Drawing.Point(184, 136)
            Me.txtState.Name = "txtState"
            Me.txtState.Size = New System.Drawing.Size(144, 23)
            Me.txtState.TabIndex = 141
            Me.txtState.Text = ""
            '
            'txtCity
            '
            Me.txtCity.BackColor = System.Drawing.SystemColors.Info
            Me.txtCity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCity.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtCity.Location = New System.Drawing.Point(8, 136)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(176, 23)
            Me.txtCity.TabIndex = 140
            Me.txtCity.Text = ""
            '
            'lblCustPONo
            '
            Me.lblCustPONo.BackColor = System.Drawing.Color.Transparent
            Me.lblCustPONo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustPONo.ForeColor = System.Drawing.Color.Yellow
            Me.lblCustPONo.Location = New System.Drawing.Point(8, 192)
            Me.lblCustPONo.Name = "lblCustPONo"
            Me.lblCustPONo.Size = New System.Drawing.Size(320, 16)
            Me.lblCustPONo.TabIndex = 144
            Me.lblCustPONo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtZipCode
            '
            Me.txtZipCode.BackColor = System.Drawing.SystemColors.Info
            Me.txtZipCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtZipCode.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtZipCode.Location = New System.Drawing.Point(8, 160)
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.Size = New System.Drawing.Size(176, 23)
            Me.txtZipCode.TabIndex = 142
            Me.txtZipCode.Text = ""
            '
            'txtShipPhone
            '
            Me.txtShipPhone.BackColor = System.Drawing.SystemColors.Info
            Me.txtShipPhone.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipPhone.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtShipPhone.Location = New System.Drawing.Point(184, 160)
            Me.txtShipPhone.Name = "txtShipPhone"
            Me.txtShipPhone.Size = New System.Drawing.Size(144, 23)
            Me.txtShipPhone.TabIndex = 143
            Me.txtShipPhone.Text = ""
            Me.txtShipPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'frmFillOrders
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1088, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmFillOrders"
            Me.Text = "frmFillOrders"
            Me.grbShipmentInfo.ResumeLayout(False)
            CType(Me.cboShipCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboOpenOrderNo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpgFillOrder.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.pnlShipCarrierInfo.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.dbgOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgOpenOrders.ResumeLayout(False)
            CType(Me.dbgOpenOrders, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Form"

        '********************************************************************************
        Private Sub frmFillOrders_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Me.GroupBox2.Visible = False
                If Me._iMenuCustID = NI.CUSTOMERID Then
                    Me.lblShippingCost.Visible = False : Me.txtShippingCost.Visible = False
                    Me.lblBillCodeID.Visible = False : Me.lblPackShipCostAmt.Visible = False
                    Me.lblPackShipCostDesc.Visible = True : Me.txtPackShipCostDesc.Visible = True
                    Me.txtPackShipCostDesc.Top = Me.txtShippingCost.Top
                    Me.txtPackShipCostDesc.Left = Me.txtShippingCost.Left
                    Me.lblPackShipCostDesc.Top = Me.lblShippingCost.Top
                    Me.lblPackShipCostDesc.Left = Me.txtPackShipCostDesc.Left - Me.lblPackShipCostDesc.Width - 2
                    Me.txtPackShipCostDesc.Width = txtTrackingNo.Width
                    Me.txtPackShipCostDesc.ReadOnly = True
                Else
                    Me.lblShippingCost.Visible = True : Me.txtShippingCost.Visible = True
                    Me.lblBillCodeID.Visible = False : Me.lblPackShipCostAmt.Visible = False
                    Me.lblPackShipCostDesc.Visible = False : Me.txtPackShipCostDesc.Visible = False
                End If

                dt = Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = Me._iMenuCustID
                If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False

                PopulateShipmentCarrier()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub PopulateShipmentCarrier()
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable
            Dim objTMI As PSS.Data.Buisness.TMI

            Try
                objTMI = New PSS.Data.Buisness.TMI()
                dTB = objTMI.GetShipCarriers

                dTB.LoadDataRow(New Object() {"0", "--Select--"}, True)

                Misc.PopulateC1DropDownList(Me.cboShipCarrier, dTB, "SC_Desc", "SC_ID")
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateShipmentCarrier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dTB) : objTMI = Nothing
            End Try
        End Sub

        '********************************************************************************

#End Region

#Region "Open Orders"

        '********************************************************************************
        Private Sub tpgOpenOrders_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgOpenOrders.VisibleChanged
            Try
                If tpgFillOrder.Visible = True AndAlso Me.dbgOrderDetails.Columns.Count = 0 Then PopulateOpenOrdersDetails()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub PopulateOpenOrdersDetails()
            Dim dt As DataTable

            Try
                dt = _objSO.GetOpenSaleOrdersDetails(Me._iMenuCustID)
                With Me.dbgOpenOrders
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("SOHeaderID").Visible = False
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnRefreshOpenOrderDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshOpenOrderDetail.Click
            Try
                PopulateOpenOrdersDetails()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub dbgOpenOrders_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgOpenOrders.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()
                    Dim objExportToExcel As New MenuItem()

                    objCopyAll.Text = "Copy all"
                    objCopySelected.Text = "Copy selected rows"
                    objExportToExcel.Text = "Export data to Excel."

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)
                    ctmCopyData.MenuItems.Add(objExportToExcel)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    RemoveHandler objExportToExcel.Click, AddressOf CMenuExportToExcel
                    AddHandler objExportToExcel.Click, AddressOf CMenuExportToExcel

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception

                MessageBox.Show(ex.ToString, "dbgOpenOrders_MouseDown", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************
        Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopyAllData(Me.dbgOpenOrders)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '********************************************************************************
        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dbgOpenOrders)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '************************************************************************
        Private Sub CMenuExportToExcel(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim objFD As New SaveFileDialog()
            Dim strFileName As String = ""
            Try
                objFD.ShowDialog()
                strFileName = objFD.FileName()
                If strFileName.Trim.Length = 0 Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.dbgOpenOrders.ExportToExcel(strFileName & ".xls")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuExportToExcel", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                objFD = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnCancelOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelOrder.Click
            Dim iSOHeaderID, i As Integer
            Dim strPONumber As String = ""
            Dim dt As DataTable
           
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                With dbgOpenOrders
                    If .RowCount > 0 AndAlso .Columns.Count > 0 Then
                        If .Row < 0 Then
                            MessageBox.Show("Please select any row to continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf Me.txtCancelReason.Text.Trim.Length = 0 Then
                            MessageBox.Show("Please enter reason for cancelation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            iSOHeaderID = .Columns("SOHeaderID").CellValue(.Row)
                            strPONumber = .Columns("PO #").CellValue(.Row)

                            If MessageBox.Show("Are you sure you want to cancel order # '" & strPONumber & "'?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

                            dt = Me._objSO.GetSaleOrderBySOHeaderID(Me.cboCustomer.SelectedValue, iSOHeaderID)
                            If dt.Rows.Count = 0 Then
                                MessageBox.Show("Order is no longer existed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf dt.Rows.Count > 1 Then
                                MessageBox.Show("Order existed more than one. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf dt.Rows(0)("InvalidOrder") Then
                                MessageBox.Show("Order is no longer valid. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf Not IsDBNull(dt.Rows(0)("ShipDate")) Then
                                MessageBox.Show("Order is closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            ElseIf Me._objSO.GetFilledDevicesInSO(iSOHeaderID).Rows.Count > 0 Then
                                MessageBox.Show("Some device(s) has been added to the order. Please remove all before continue.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Else
                                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                                i = Me._objSO.CancelOrder(iSOHeaderID, Core.ApplicationUser.IDuser, Me.txtCancelReason.Text.Trim)
                                If i > 0 Then
                                    PopulateOpenOrdersDetails() : Me.txtCancelReason.Text = ""
                                Else
                                    MessageBox.Show("System has failed to update data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                End If

                            End If 'Database data
                        End If 'has select row
                    End If 'has row and column
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCancelOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtCancelReason_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCancelReason.KeyPress
            If (e.KeyChar.ToString = "'") Then
                e.Handled = True
            End If
        End Sub

        '********************************************************************************

#End Region

#Region "Fill Order"

        '********************************************************************************
        Private Sub tpgFillOrder_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgFillOrder.VisibleChanged
            Dim iSOHeader As Integer = 0
            Try
                If tpgFillOrder.Visible = False Then Exit Sub
                If Not IsNothing(Me.cboOpenOrderNo.DataSource) AndAlso Me.cboOpenOrderNo.SelectedValue > 0 Then iSOHeader = Me.cboOpenOrderNo.SelectedValue
                PopulateOpenOrdersHeader(iSOHeader)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub PopulateOpenOrdersHeader(ByVal iSOHeader As Integer)
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = _objSO.GetOpenSaleOrdersHeader(Me._iMenuCustID, True)
                Misc.PopulateC1DropDownList(Me.cboOpenOrderNo, dt, "PONumber", "SOHeaderID")
                Me.cboOpenOrderNo.SelectedValue = iSOHeader
                If iSOHeader > 0 Then
                    PopulateShipToInfo(iSOHeader)
                    Me.PopulateOrderDetails(iSOHeader)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************
        Private Sub PopulateShipToInfo(ByVal iSOHeaderID As Integer)
            Dim R1 As DataRow

            Try
                R1 = Me.cboOpenOrderNo.DataSource.Table.select("SOHeaderID = " & iSOHeaderID)(0)

                Me.txtName.Text = R1("Ship to Name").ToString
                Me.txtAddress1.Text = R1("Address1").ToString
                Me.txtAddress2.Text = R1("Address2").ToString
                Me.txtCity.Text = R1("City").ToString
                Me.txtState.Text = R1("State").ToString
                Me.txtZipCode.Text = R1("Postal Code").ToString
                Me.txtShipPhone.Text = R1("Phone").ToString
                lblCustPONo.Text = R1("PONumber").ToString

                Me.lblOrderQty.Text = R1("Quantiy").ToString
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************
        Private Function PopulateOrderDetails(ByVal iSOHeader As Integer) As Integer
            Dim dt As DataTable

            Try
                dt = _objSO.GetOpenOrderDetails(Me._iMenuCustID, iSOHeader)
                dt.Columns("Cosmetic Grade").Caption = "Inbound Cosm Grade"
                With Me.dbgOrderDetails
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("SOHeaderID").Visible = False
                    .Splits(0).DisplayColumns("SODetailsID").Visible = False
                    .Splits(0).DisplayColumns("Model_ID").Visible = False
                    .Splits(0).DisplayColumns("DevConditionID").Visible = False
                    .Splits(0).DisplayColumns("CosmGradeID").Visible = False

                    .Splits(0).DisplayColumns("Line #").Width = 40
                    .Splits(0).DisplayColumns("Line Qty").Width = 50
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************************
        Private Sub ClearShipToCtrls()
            Try
                Me.txtName.Text = ""
                Me.txtAddress1.Text = ""
                Me.txtAddress2.Text = ""
                Me.txtCity.Text = ""
                Me.txtState.Text = ""
                Me.txtZipCode.Text = ""
                Me.txtShipPhone.Text = ""
                lblCustPONo.Text = ""

                Me.lblOrderQty.Text = "0"

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************
        Private Sub ClearShippingCtrls()
            Try
                cboShipCarrier.SelectedValue = 0
                Me.txtTrackingNo.Text = ""
                Me.txtShippingCost.Text = 0
                Me.txtShipQty.Text = ""
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************
        Private Sub ClearDeviceListCtrls()
            Try
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.lstDevices.Items.Clear()
                Me.lblFilledQty.Text = "0"
                Me.lblLineQty.Text = "0"
                Me.lstDevices.Refresh()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*******************************************************************************
        Private Sub cboOpenOrderNo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenOrderNo.SelectedValueChanged

            Try
                If Me._booPopulateData = True Then Exit Sub

                ClearShipToCtrls()
                ClearShippingCtrls()
                ClearDeviceListCtrls()
                Me.dbgOrderDetails.DataSource = Nothing

                If Me._iMenuCustID = NI.CUSTOMERID Then Me.cboShipCarrier.SelectedValue = 2

                If Me.cboOpenOrderNo.SelectedValue > 0 Then 'selected SoHeaderID
                    PopulateShipToInfo(Me.cboOpenOrderNo.SelectedValue)
                    Me.PopulateOrderDetails(Me.cboOpenOrderNo.SelectedValue)
                    HandlePartOrder(Me.cboOpenOrderNo.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenOrderNo_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        '*******************************************************************************
        Private Sub HandlePartOrder(ByVal iSoHeaderID As Integer)
            Dim R1 As DataRow
            Dim strOrderType As String = ""
            Dim dtPackShipCost As DataTable
            Dim objNIRec As New NIRec()

            Try
                R1 = Me.cboOpenOrderNo.DataSource.Table.select("SOHeaderID = " & iSoHeaderID)(0)
                strOrderType = R1("OrderType").ToString

                If Me._iMenuCustID = NI.CUSTOMERID And strOrderType.Trim.ToUpper = "SENDSPAREPART" Then

                    dtPackShipCost = objNIRec.GetNIAggregateCharge(Me._iMenuCustID, NI.PackShipBillCodeID)

                    If dtPackShipCost.Rows.Count > 0 Then
                        Me.txtPackShipCostDesc.Text = dtPackShipCost.Rows(0).Item("BillCode_Desc") & ": $" & dtPackShipCost.Rows(0).Item("tCab_Amount")
                        Me.lblBillCodeID.Text = dtPackShipCost.Rows(0).Item("BillCode_ID")
                        Me.lblPackShipCostAmt.Text = dtPackShipCost.Rows(0).Item("tCab_Amount")
                    Else
                        MessageBox.Show("Can't find data for pack and ship charge. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If

                    Me.GroupBox2.Top = Me.dbgOrderDetails.Top + Me.dbgOrderDetails.Height + 8
                    Me.GroupBox2.Left = Me.dbgOrderDetails.Left
                    Me.txtShipQty.Text = ""
                    Me.btnRemoveAllSNs.Visible = False
                    Me.btnRemoveSN.Visible = False
                    Me.GroupBox1.Visible = False
                    Me.GroupBox2.Visible = True
                    Me._bSendSparePart = True
                Else
                    Me.btnRemoveAllSNs.Visible = True
                    Me.btnRemoveSN.Visible = True
                    Me.GroupBox2.Visible = False
                    Me.GroupBox1.Visible = True
                    Me._bSendSparePart = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub HandlePartOrder", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dtPackShipCost = Nothing : objNIRec = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub dbgOrderDetails_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgOrderDetails.RowColChange
            Try
                ClearDeviceListCtrls()

                If Me.dbgOrderDetails.RowCount > 0 Then
                    PopulateDevicesList(Me.dbgOrderDetails.Columns("SODetailsID").CellValue(Me.dbgOrderDetails.Row))
                    Me.lblLineQty.Text = Me.dbgOrderDetails.Columns("Line Qty").CellValue(Me.dbgOrderDetails.Row)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgOrderDetails_RowColChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Function PopulateDevicesList(ByVal iSODetailID As Integer) As Boolean
            Dim dt As DataTable

            Try
                dt = Me._objSO.GetAllDevicesInSOLine(iSODetailID)
                Me.lblFilledQty.Text = dt.Rows.Count
                Me.lstDevices.DataSource = dt.DefaultView
                Me.lstDevices.ValueMember = dt.Columns("WI_ID").ToString
                Me.lstDevices.DisplayMember = dt.Columns("Serial").ToString
                Me.lstDevices.Refresh()

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '********************************************************************************
        Private Sub txtShipQty_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipQty.KeyUp
            Try

                If e.KeyCode = Keys.Enter AndAlso Me.txtShipQty.Text.Trim.Length > 0 Then

                    'Avoiding paste text into to the textbox or number with 0 at starting position
                    'Validate again
                    If IsNumeric(Me.txtShipQty.Text) Then
                        Dim iNum As Integer = Me.txtShipQty.Text
                        If iNum > 0 Then
                            Me.txtShipQty.Text = iNum
                            If Not Convert.ToInt32(Me.txtShipQty.Text) = Convert.ToInt32(Me.lblLineQty.Text) Then
                                MessageBox.Show("Please enter a valid ship quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtShipQty.SelectAll() : Me.txtShipQty.Focus()
                            Else
                                Me.lblFilledQty.Text = Me.txtShipQty.Text
                            End If
                        Else
                            MessageBox.Show("Not a valid ship quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtShipQty.Text = "" : Me.txtShipQty.Focus()
                        End If
                    Else
                        MessageBox.Show("Not a valid ship quantity.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtShipQty.Text = "" : Me.txtShipQty.Focus()
                    End If

                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "sub txtShipQty_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub

        '****************************** Only positive integer allowed in the textbox **************************************************
        Private Sub txtShipQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShipQty.KeyPress
            Try
                Dim allowed As String = "0123456789"
                Dim curchar As Integer = Asc(e.KeyChar)

                If (allowed.IndexOf(e.KeyChar) = -1) And (curchar <> 8) Then
                    e.Handled = True
                End If

            Catch ex As Exception
            End Try

        End Sub

        '********************************************************************************
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim dt, dtKeyboard, dtPackShipCost As DataTable
            Dim iLineItemModelID, iLineItemDevCondID, iLineItemCosmGradeID, i, iSODetailsID As Integer
            Dim objNIRec As New NIRec(), objNI As New NI()
            Dim bIsSPKeyboard As Boolean = False
            Dim bIsSPGoodKeyboard As Boolean = False
            Dim iSPKeyBoardPackShipBillCodeID As Integer = 0
            Dim iM As Integer = 1 'Special Project Kyboard price method

            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtDevSN.Text.Trim.Length > 0 Then

                    If Me.lstDevices.Items.Count > 0 AndAlso Me.lstDevices.DataSource.Table.Select("Serial = '" & Me.txtDevSN.Text.Trim & "'").length > 0 Then
                        MessageBox.Show("Serial has already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                    End If

                    iLineItemModelID = Convert.ToInt32(Me.dbgOrderDetails.Columns("Model_ID").CellValue(Me.dbgOrderDetails.Row))
                    'strDeviceCond = Me.dbgOrderDetails.Columns("Device Condition").CellValue(Me.dbgOrderDetails.Row)
                    iLineItemDevCondID = Me.dbgOrderDetails.Columns("DevConditionID").CellValue(Me.dbgOrderDetails.Row)
                    iLineItemCosmGradeID = Me.dbgOrderDetails.Columns("CosmGradeID").CellValue(Me.dbgOrderDetails.Row)
                    iSODetailsID = Me.dbgOrderDetails.Columns("SODetailsID").CellValue(Me.dbgOrderDetails.Row)

                    dt = Me._objSO.GetOpenGoodWHItem(Me._iMenuCustID, Me.txtDevSN.Text.Trim)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Serial does not existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate serial. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    ElseIf (dt.Rows(0)("DevConditionID").ToString.Trim <> "3856" AndAlso dt.Rows(0)("Model_ID").ToString.Trim <> iLineItemModelID.ToString) Then
                        MessageBox.Show("Model does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    ElseIf (dt.Rows(0)("DevConditionID").ToString.Trim = "3856" AndAlso dt.Rows(0)("Model_ID").ToString.Trim <> iLineItemModelID.ToString AndAlso MessageBox.Show("Are you sure you want to swap unit with different model?.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No) Then
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    ElseIf Convert.ToInt32(Me.lblFilledQty.Text) >= Convert.ToInt32(Me.lblLineQty.Text) Then
                        MessageBox.Show("You have exceeded line item quantity. Please remove item in list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    Else
                        'Get special project keyboard data
                        bIsSPKeyboard = False
                        If Me._iMenuCustID = NI.CUSTOMERID Then
                            dtKeyboard = objNIRec.GetKeyboardSpecialProject_DeviceData(0, Me.txtDevSN.Text.Trim)
                            If dtKeyboard.Rows.Count > 0 AndAlso dtKeyboard.Rows(0).Item("QCResult_ID") = 1 Then
                                bIsSPKeyboard = True
                                iSPKeyBoardPackShipBillCodeID = objNI.GetKeyboardSpecialProject_PackShipBillCodeID(iM, dt.Rows(0)("Model_ID"))
                            ElseIf dtKeyboard.Rows.Count > 0 AndAlso dtKeyboard.Rows(0).Item("QCResult_ID") <> 1 Then
                                MessageBox.Show("Isn't a good unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                            End If
                        End If

                        If Not bIsSPKeyboard Then
                            'Check for different cosmetic grade
                            If dt.Rows(0)("CosmGradeID").ToString.Trim <> iLineItemCosmGradeID.ToString _
                               OrElse dt.Rows(0)("DevConditionID").ToString.Trim <> iLineItemDevCondID.ToString Then
                                If PSS.Core.ApplicationUser.GetPermission("NIFillOrder_DiffCosmGrade") > 0 Then
                                    If MessageBox.Show("Cosmetic grade does not match. Are you sure you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Cosmetic grade does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                End If
                            End If

                            If dt.Rows(0)("DevConditionID").ToString.Trim <> iLineItemDevCondID.ToString Then
                                If PSS.Core.ApplicationUser.GetPermission("NIFillOrder_DiffCosmGrade") > 0 Then
                                    If MessageBox.Show("Device condition(new/ref) does not match. Are you sure you want to continue?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                    End If
                                Else
                                    MessageBox.Show("Device condition does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                End If
                            End If
                        End If

                        'Get Pack and Ship charges
                        If Me._iMenuCustID = NI.CUSTOMERID Then

                            If bIsSPKeyboard Then
                                dtPackShipCost = objNIRec.GetNIAggregateCharge(Me._iMenuCustID, iSPKeyBoardPackShipBillCodeID)
                            Else
                                dtPackShipCost = objNIRec.GetNIAggregateCharge(Me._iMenuCustID, NI.PackShipBillCodeID)
                            End If

                            If dtPackShipCost.Rows.Count > 0 Then
                                Me.txtPackShipCostDesc.Text = dtPackShipCost.Rows(0).Item("BillCode_Desc") & ": $" & dtPackShipCost.Rows(0).Item("tCab_Amount")
                                Me.lblBillCodeID.Text = dtPackShipCost.Rows(0).Item("BillCode_ID")
                                Me.lblPackShipCostAmt.Text = dtPackShipCost.Rows(0).Item("tCab_Amount")
                            Else
                                MessageBox.Show("Can't find data for pack and ship charge. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            dtPackShipCost = Nothing : objNIRec = Nothing
                        End If

                        'Assign Sale Order
                        i = Me._objSO.AssignItemToSaleOrder(dt.Rows(0)("WI_ID"), iSODetailsID)
                        If i > 0 Then
                            Me.PopulateDevicesList(iSODetailsID)
                            Me.txtDevSN.Text = "" : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        Else
                            MessageBox.Show("System has failed to fill this unit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        End If
                        End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt) : Generic.DisposeDT(dtKeyboard)
                Generic.DisposeDT(dtPackShipCost) : objNIRec = Nothing : objNI = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtDevSN_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDevSN.Enter
            Try
                If Me.dbgOrderDetails.RowCount > 0 Then Me.lblLineQty.Text = Me.dbgOrderDetails.Columns("Line Qty").CellValue(Me.dbgOrderDetails.Row)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub txtShipQty_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShipQty.Enter
            Try
                If Me.dbgOrderDetails.RowCount > 0 Then Me.lblLineQty.Text = Me.dbgOrderDetails.Columns("Line Qty").CellValue(Me.dbgOrderDetails.Row)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtShipQty_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Dim dt As DataTable
            Dim iSODetailsID, i As Integer

            Try
                If Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("List is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.cboOpenOrderNo.SelectedValue = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.dbgOrderDetails.RowCount = 0 Then
                    MessageBox.Show("Order does not have any line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                iSODetailsID = Me.dbgOrderDetails.Columns("SODetailsID").CellValue(Me.dbgOrderDetails.Row)
                If Me.dbgOrderDetails.RowCount = 0 Then
                    MessageBox.Show("System can't define line item ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                dt = Me._objSO.GetSaleOrderBySOHeaderID(Me._iMenuCustID, Me.cboOpenOrderNo.SelectedValue)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Order does not exist. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate order. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("ShipDate")) AndAlso dt.Rows(0)("ShipDate").ToString.Length > 0 Then
                    MessageBox.Show("Order has been closed. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("InvalidOrder").ToString = "1" OrElse dt.Rows(0)("OrderStatusID").ToString <> "1" Then
                    MessageBox.Show("This is an invalid order. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf MessageBox.Show("Are you sure you want to remove all serial # in the list?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = DialogResult.No Then
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = Me._objSO.RemoveDevicesFromSODetails(iSODetailsID, )
                    If i > 0 Then
                        Me.PopulateDevicesList(iSODetailsID)
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllSNs_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnRemoveSN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim dt As DataTable
            Dim iSODetailsID, i As Integer
            Dim strSN As String = ""

            Try
                If Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("List is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.cboOpenOrderNo.SelectedValue = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.dbgOrderDetails.RowCount = 0 Then
                    MessageBox.Show("Order does not have any line item.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                iSODetailsID = Me.dbgOrderDetails.Columns("SODetailsID").CellValue(Me.dbgOrderDetails.Row)
                If Me.dbgOrderDetails.RowCount = 0 Then
                    MessageBox.Show("System can't define line item ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                strSN = InputBox("Enter serial #:", "Get S/N").Trim
                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("You must enter the Serial #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf MessageBox.Show("Are you sure you want to remove serial # (" & strSN & ") from the list?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) = DialogResult.No Then
                    Exit Sub
                Else
                    dt = Me._objSO.GetSaleOrderBySOHeaderID(Me._iMenuCustID, Me.cboOpenOrderNo.SelectedValue)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Order does not exist. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate order. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(dt.Rows(0)("ShipDate")) AndAlso dt.Rows(0)("ShipDate").ToString.Length > 0 Then
                        MessageBox.Show("Order has been closed. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows(0)("InvalidOrder").ToString = "1" OrElse dt.Rows(0)("OrderStatusID").ToString <> "1" Then
                        MessageBox.Show("This is an invalid order. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else

                        dt = Me._objSO.GetWarehouseItem(Me._iMenuCustID, strSN)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Serial # does not exist.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate serial #. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf Convert.ToInt32(dt.Rows(0)("SODetailsID")) = 0 Then
                            MessageBox.Show("Serial # does not belong to any order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf Convert.ToInt32(dt.Rows(0)("SODetailsID")) <> iSODetailsID Then
                            MessageBox.Show("Serial # belongs to a different order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        Else
                            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                            i = Me._objSO.RemoveDevicesFromSODetails(iSODetailsID, )
                            If i > 0 Then
                                Me.PopulateDevicesList(iSODetailsID)
                                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Else
                                MessageBox.Show("System has failed to remove serial #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If

                        End If 'verify input s/n 
                    End If 'check order
                End If 'check input
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveSN_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnCloseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseOrder.Click
            Dim dt As DataTable
            Dim iSOHeaderID, iFillQty, i As Integer
            Dim decShippingCost As Decimal = 0
            Dim objNIRecShip As NIRecShip
            Dim vPackShip As Double = 0


            Try
                iSOHeaderID = Me.cboOpenOrderNo.SelectedValue

                'validate order selection
                If iSOHeaderID = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.cboShipCarrier.SelectedValue = 0 Then
                    MessageBox.Show("Please select ship carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.txtTrackingNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                    'ElseIf Me.txtShippingCost.Text.Trim.Length = 0 Then
                    '    MessageBox.Show("Please enter shipping cost.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Exit Sub
                ElseIf Me.txtShippingCost.Text.Trim.Length = 0 AndAlso Me._iMenuCustID <> NI.CUSTOMERID Then
                    MessageBox.Show("Please enter shipping cost.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                'decShippingCost = Convert.ToDecimal(Me.txtShippingCost.Text)
                If Me._iMenuCustID = NI.CUSTOMERID Then
                    decShippingCost = Convert.ToDecimal(Me.lblPackShipCostAmt.Text)
                Else
                    decShippingCost = Convert.ToDecimal(Me.txtShippingCost.Text)
                End If

                'validate order quantity
                If Me._bSendSparePart Then
                    If Not Convert.ToInt32(lblFilledQty.Text) > 0 Then
                        MessageBox.Show("Please confirm the ship quantity!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                Else
                    iFillQty = Me._objSO.GetSOFilledQty(iSOHeaderID)
                    If iFillQty <> Convert.ToInt32(Me.lblOrderQty.Text) Then
                        MessageBox.Show("Not allow to ship partial order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                End If

                'check order status
                dt = Me._objSO.GetSaleOrderBySOHeaderID(Me._iMenuCustID, iSOHeaderID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Order does not exist. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate order. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Not IsDBNull(dt.Rows(0)("ShipDate")) AndAlso dt.Rows(0)("ShipDate").ToString.Length > 0 Then
                    MessageBox.Show("Order has been closed. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dt.Rows(0)("InvalidOrder").ToString = "1" OrElse dt.Rows(0)("OrderStatusID").ToString <> "1" Then
                    MessageBox.Show("This is an invalid order. Please re-fresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    If Me._bSendSparePart AndAlso Me._iMenuCustID = NI.CUSTOMERID Then
                        objNIRecShip = New NIRecShip()
                        i = objNIRecShip.NICloseSO_SendSparePart(Me._iMenuCustID, iSOHeaderID, PSS.Core.ApplicationUser.IDuser, Me.cboShipCarrier.Text, Me.txtTrackingNo.Text.Trim.ToUpper, decShippingCost, Me.lblBillCodeID.Text)
                    Else
                        i = Me._objSO.CloseSO(Me._iMenuCustID, iSOHeaderID, PSS.Core.ApplicationUser.IDuser, Me.cboShipCarrier.Text, Me.txtTrackingNo.Text.Trim.ToUpper, decShippingCost, Me.lblBillCodeID.Text)
                    End If

                    If i > 0 Then
                        If Me.cboCustomer.SelectedValue = NI.CUSTOMERID Then
                            SetLaborCharge_NI(iSOHeaderID)
                        End If

                        'Print labe and manifest if neccessary
                        '---------------------------------------
                        Me.ClearShippingCtrls() : Me.ClearShipToCtrls() : Me.ClearDeviceListCtrls()
                        Me.dbgOrderDetails.DataSource = Nothing
                        Me.PopulateOpenOrdersHeader(0)

                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("System has failed to close order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If 'verify input s/n 
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************
        Private Sub SetLaborCharge_NI(ByVal iSOHeaderID As Integer)
            Dim dtOrderDetails As DataTable
            Dim R1 As DataRow
            Dim dbTotalLineLaborCharge, dbLineLaborCharge As Double

            Try
                dbTotalLineLaborCharge = 0 : dbLineLaborCharge = 0
                dtOrderDetails = Me._objSO.GetOrderDetails(iSOHeaderID)
                For Each R1 In dtOrderDetails.Rows
                    If Me._bSendSparePart Then
                        dbLineLaborCharge = 1 * NI.SOSparePartLaborChargePerLine
                    Else
                        dbLineLaborCharge = Convert.ToInt16(R1("ShipQuantity")) * NI.SOLaborChargePerUnit
                    End If
                    Me._objSO.SetLineLaborCharge(Convert.ToInt32(R1("SODetailsID")), dbLineLaborCharge)
                Next R1

                dbTotalLineLaborCharge = Me._objSO.GetTotalLineLaborCharge(iSOHeaderID)

                Me._objSO.SetSOTotalLaborCharge(iSOHeaderID, dbTotalLineLaborCharge)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SetLaborCharge_NI", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************
        Private Sub btnRefreshWipData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshWipData.Click
            Try
                Me.ClearShippingCtrls() : Me.ClearShipToCtrls() : Me.ClearDeviceListCtrls()
                Me.dbgOrderDetails.DataSource = Nothing
                Me.PopulateOpenOrdersHeader(0)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRefreshWipData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '********************************************************************************
#End Region

        
        
    End Class
End Namespace