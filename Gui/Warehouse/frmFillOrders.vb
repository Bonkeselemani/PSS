Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Warehouse
    Public Class frmFillOrders
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
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
        Friend WithEvents lblCustPONo As System.Windows.Forms.Label
        Friend WithEvents txtShippingCost As System.Windows.Forms.TextBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
        Friend WithEvents txtState As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents txtShipPhone As System.Windows.Forms.TextBox
        Friend WithEvents txtCity As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents Label12 As System.Windows.Forms.Label
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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmFillOrders))
            Me.grbShipmentInfo = New System.Windows.Forms.GroupBox()
            Me.lblCustPONo = New System.Windows.Forms.Label()
            Me.txtZipCode = New System.Windows.Forms.TextBox()
            Me.txtState = New System.Windows.Forms.TextBox()
            Me.txtAddress2 = New System.Windows.Forms.TextBox()
            Me.txtShipPhone = New System.Windows.Forms.TextBox()
            Me.txtCity = New System.Windows.Forms.TextBox()
            Me.txtAddress1 = New System.Windows.Forms.TextBox()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtShippingCost = New System.Windows.Forms.TextBox()
            Me.Label15 = New System.Windows.Forms.Label()
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
            Me.dbgOpenOrders = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grbShipmentInfo.SuspendLayout()
            CType(Me.cboShipCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboOpenOrderNo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tpgFillOrder.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dbgOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgOpenOrders.SuspendLayout()
            CType(Me.dbgOpenOrders, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grbShipmentInfo
            '
            Me.grbShipmentInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCustPONo, Me.txtZipCode, Me.txtState, Me.txtAddress2, Me.txtShipPhone, Me.txtCity, Me.txtAddress1, Me.txtName, Me.Label12})
            Me.grbShipmentInfo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grbShipmentInfo.ForeColor = System.Drawing.Color.White
            Me.grbShipmentInfo.Location = New System.Drawing.Point(8, 112)
            Me.grbShipmentInfo.Name = "grbShipmentInfo"
            Me.grbShipmentInfo.Size = New System.Drawing.Size(336, 224)
            Me.grbShipmentInfo.TabIndex = 3
            Me.grbShipmentInfo.TabStop = False
            Me.grbShipmentInfo.Text = "Shipment Information"
            '
            'lblCustPONo
            '
            Me.lblCustPONo.BackColor = System.Drawing.Color.Transparent
            Me.lblCustPONo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustPONo.ForeColor = System.Drawing.Color.Yellow
            Me.lblCustPONo.Location = New System.Drawing.Point(8, 192)
            Me.lblCustPONo.Name = "lblCustPONo"
            Me.lblCustPONo.Size = New System.Drawing.Size(320, 16)
            Me.lblCustPONo.TabIndex = 139
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
            Me.txtZipCode.TabIndex = 6
            Me.txtZipCode.Text = ""
            '
            'txtState
            '
            Me.txtState.BackColor = System.Drawing.SystemColors.Info
            Me.txtState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtState.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtState.Location = New System.Drawing.Point(184, 136)
            Me.txtState.Name = "txtState"
            Me.txtState.Size = New System.Drawing.Size(144, 23)
            Me.txtState.TabIndex = 5
            Me.txtState.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.BackColor = System.Drawing.SystemColors.Info
            Me.txtAddress2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress2.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtAddress2.Location = New System.Drawing.Point(8, 112)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.Size = New System.Drawing.Size(320, 23)
            Me.txtAddress2.TabIndex = 3
            Me.txtAddress2.Text = ""
            '
            'txtShipPhone
            '
            Me.txtShipPhone.BackColor = System.Drawing.SystemColors.Info
            Me.txtShipPhone.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipPhone.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtShipPhone.Location = New System.Drawing.Point(184, 160)
            Me.txtShipPhone.Name = "txtShipPhone"
            Me.txtShipPhone.Size = New System.Drawing.Size(144, 23)
            Me.txtShipPhone.TabIndex = 7
            Me.txtShipPhone.Text = ""
            Me.txtShipPhone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'txtCity
            '
            Me.txtCity.BackColor = System.Drawing.SystemColors.Info
            Me.txtCity.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCity.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtCity.Location = New System.Drawing.Point(8, 136)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(176, 23)
            Me.txtCity.TabIndex = 4
            Me.txtCity.Text = ""
            '
            'txtAddress1
            '
            Me.txtAddress1.BackColor = System.Drawing.SystemColors.Info
            Me.txtAddress1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress1.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtAddress1.Location = New System.Drawing.Point(8, 88)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.Size = New System.Drawing.Size(320, 23)
            Me.txtAddress1.TabIndex = 2
            Me.txtAddress1.Text = ""
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
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.White
            Me.Label12.Location = New System.Drawing.Point(1, 24)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(72, 16)
            Me.Label12.TabIndex = 135
            Me.Label12.Text = "Address :"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtShippingCost
            '
            Me.txtShippingCost.Location = New System.Drawing.Point(128, 416)
            Me.txtShippingCost.Name = "txtShippingCost"
            Me.txtShippingCost.Size = New System.Drawing.Size(56, 20)
            Me.txtShippingCost.TabIndex = 6
            Me.txtShippingCost.Text = ""
            '
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.White
            Me.Label15.Location = New System.Drawing.Point(16, 416)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(112, 16)
            Me.Label15.TabIndex = 137
            Me.Label15.Text = "Shipping Cost :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.White
            Me.Label11.Location = New System.Drawing.Point(696, 200)
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
            Me.lblFilledQty.Location = New System.Drawing.Point(704, 216)
            Me.lblFilledQty.Name = "lblFilledQty"
            Me.lblFilledQty.Size = New System.Drawing.Size(72, 32)
            Me.lblFilledQty.TabIndex = 134
            Me.lblFilledQty.Text = "0"
            Me.lblFilledQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtTrackingNo
            '
            Me.txtTrackingNo.Location = New System.Drawing.Point(128, 384)
            Me.txtTrackingNo.Name = "txtTrackingNo"
            Me.txtTrackingNo.Size = New System.Drawing.Size(168, 20)
            Me.txtTrackingNo.TabIndex = 5
            Me.txtTrackingNo.Text = ""
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(40, 384)
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
            Me.cboShipCarrier.Location = New System.Drawing.Point(128, 352)
            Me.cboShipCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipCarrier.MaxDropDownItems = CType(10, Short)
            Me.cboShipCarrier.MaxLength = 32767
            Me.cboShipCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipCarrier.Name = "cboShipCarrier"
            Me.cboShipCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipCarrier.Size = New System.Drawing.Size(168, 21)
            Me.cboShipCarrier.TabIndex = 4
            Me.cboShipCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
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
            Me.Label6.Location = New System.Drawing.Point(24, 352)
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
            Me.btnCloseOrder.Location = New System.Drawing.Point(528, 400)
            Me.btnCloseOrder.Name = "btnCloseOrder"
            Me.btnCloseOrder.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseOrder.Size = New System.Drawing.Size(144, 21)
            Me.btnCloseOrder.TabIndex = 11
            Me.btnCloseOrder.Text = "CLOSE && SHIP ORDER"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(528, 200)
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
            Me.lblOrderQty.Location = New System.Drawing.Point(528, 216)
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
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
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
            Me.cboOpenOrderNo.Size = New System.Drawing.Size(264, 21)
            Me.cboOpenOrderNo.TabIndex = 2
            Me.cboOpenOrderNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
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
            Me.TabControl1.Size = New System.Drawing.Size(792, 520)
            Me.TabControl1.TabIndex = 141
            '
            'tpgFillOrder
            '
            Me.tpgFillOrder.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgFillOrder.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLineQty, Me.Label2, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.GroupBox1, Me.dbgOrderDetails, Me.Label4, Me.cboCustomer, Me.lblHeader, Me.cboOpenOrderNo, Me.Label5, Me.grbShipmentInfo, Me.btnCloseOrder, Me.Label9, Me.Label7, Me.lblFilledQty, Me.Label15, Me.lblOrderQty, Me.cboShipCarrier, Me.txtTrackingNo, Me.Label6, Me.Label11, Me.txtShippingCost})
            Me.tpgFillOrder.Location = New System.Drawing.Point(4, 22)
            Me.tpgFillOrder.Name = "tpgFillOrder"
            Me.tpgFillOrder.Size = New System.Drawing.Size(784, 494)
            Me.tpgFillOrder.TabIndex = 0
            Me.tpgFillOrder.Text = "Fill Order"
            '
            'lblLineQty
            '
            Me.lblLineQty.BackColor = System.Drawing.Color.Black
            Me.lblLineQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblLineQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineQty.ForeColor = System.Drawing.Color.Lime
            Me.lblLineQty.Location = New System.Drawing.Point(616, 216)
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
            Me.Label2.Location = New System.Drawing.Point(608, 200)
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
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(528, 288)
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
            Me.btnRemoveSN.Location = New System.Drawing.Point(528, 328)
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
            Me.GroupBox1.Location = New System.Drawing.Point(352, 192)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(152, 280)
            Me.GroupBox1.TabIndex = 8
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
            Me.dbgOrderDetails.Size = New System.Drawing.Size(424, 176)
            Me.dbgOrderDetails.TabIndex = 7
            Me.dbgOrderDetails.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>1" & _
            "72</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 420, 172<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 420, 172</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'tpgOpenOrders
            '
            Me.tpgOpenOrders.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgOpenOrders.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgOpenOrders})
            Me.tpgOpenOrders.Location = New System.Drawing.Point(4, 22)
            Me.tpgOpenOrders.Name = "tpgOpenOrders"
            Me.tpgOpenOrders.Size = New System.Drawing.Size(784, 494)
            Me.tpgOpenOrders.TabIndex = 1
            Me.tpgOpenOrders.Text = "Open Orders"
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
            Me.dbgOpenOrders.Location = New System.Drawing.Point(8, 24)
            Me.dbgOpenOrders.Name = "dbgOpenOrders"
            Me.dbgOpenOrders.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgOpenOrders.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgOpenOrders.PreviewInfo.ZoomFactor = 75
            Me.dbgOpenOrders.Size = New System.Drawing.Size(768, 408)
            Me.dbgOpenOrders.TabIndex = 12
            Me.dbgOpenOrders.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
            "04</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 764, 404<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 764, 404</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'frmFillOrders
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(808, 566)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmFillOrders"
            Me.Text = "frmFillOrders"
            Me.grbShipmentInfo.ResumeLayout(False)
            CType(Me.cboShipCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboOpenOrderNo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tpgFillOrder.ResumeLayout(False)
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
                dt = Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomer.SelectedValue = Me._iMenuCustID
                If Me.cboCustomer.SelectedValue > 0 Then Me.cboCustomer.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************

#End Region

#Region "Open Orders"

        '********************************************************************************
        Private Sub tpgOpenOrders_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tpgOpenOrders.VisibleChanged
            Try
                If tpgFillOrder.Visible = False Then Exit Sub
                PopulateOpenOrdersDetails()
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
        Private Sub dbgOpenOrders_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgOpenOrders.MouseDown
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return

                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    objCopyAll.Text = "Copy all"
                    objCopySelected.Text = "Copy selected rows"

                    ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)

                    RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData

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
                dt = _objSO.GetOrderDetails(Me._iMenuCustID, iSOHeader)
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
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '********************************************************************************
        Private Sub ClearDeviceListCtrls()
            Try
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
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

                If Me.cboOpenOrderNo.SelectedValue > 0 Then
                    PopulateShipToInfo(Me.cboOpenOrderNo.SelectedValue)
                    Me.PopulateOrderDetails(Me.cboOpenOrderNo.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenOrderNo_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim dt As DataTable
            Dim iLineItemModelID, iLineItemDevCondID, iLineItemCosmGradeID, i, iSODetailsID As Integer

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
                    ElseIf dt.Rows(0)("Model_ID").ToString.Trim <> iLineItemModelID.ToString Then
                        MessageBox.Show("Model does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    ElseIf dt.Rows(0)("DevConditionID").ToString.Trim <> iLineItemDevCondID.ToString Then
                        MessageBox.Show("Device condition does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    ElseIf dt.Rows(0)("CosmGradeID").ToString.Trim <> iLineItemCosmGradeID.ToString Then
                        MessageBox.Show("Cosmetic grade does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    ElseIf Convert.ToInt32(Me.lblFilledQty.Text) >= Convert.ToInt32(Me.lblLineQty.Text) Then
                        MessageBox.Show("You have exceeded line item quantity. Please remove item in list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                    Else
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
                Generic.DisposeDT(dt)
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

            Try
                iSOHeaderID = Me.cboOpenOrderNo.SelectedValue

                'validate order selection
                If iSOHeaderID = 0 Then
                    MessageBox.Show("Please select order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'validate order quantity
                iFillQty = Me._objSO.GetSOFilledQty(iSOHeaderID)
                If iFillQty <> Convert.ToInt32(Me.lblOrderQty.Text) Then
                    MessageBox.Show("Not allow to ship partial order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
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
                    i = Me._objSO.CloseSO(Me._iMenuCustID, iSOHeaderID, PSS.Core.ApplicationUser.IDuser)
                    If i > 0 Then
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

#End Region

      
    End Class
End Namespace