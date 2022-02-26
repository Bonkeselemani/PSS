Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Pantech

    Public Class frmAdmin
        Inherits System.Windows.Forms.Form

        Private Const _iCustID As Integer = 2453

        Private _objPartRelated As PartRelated
        Private _booLoadDataToCombo As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objPartRelated = New PartRelated()
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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpgManagePreBillLot As System.Windows.Forms.TabPage
        Friend WithEvents lblAdminLotName As System.Windows.Forms.Label
        Friend WithEvents txtAdminPreBillSN As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnAdminReprintPreBillLot As System.Windows.Forms.Button
        Friend WithEvents btnAdminCloseTodaysPreBill As System.Windows.Forms.Button
        Friend WithEvents txtCollectSN As System.Windows.Forms.TextBox
        Friend WithEvents lblWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
        Friend WithEvents gbPreBillLot As System.Windows.Forms.GroupBox
        Friend WithEvents gbSearchPreBillLot As System.Windows.Forms.GroupBox
        Friend WithEvents gbChangeWrtyStatus As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtDateCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCurrentStatus As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnChangeToIW As System.Windows.Forms.Button
        Friend WithEvents txtWrtyOverrideSN As System.Windows.Forms.TextBox
        Friend WithEvents tpgManufWrtyOverride As System.Windows.Forms.TabPage
        Friend WithEvents tpgChangeShipTypeTrackingNumber As System.Windows.Forms.TabPage
        Friend WithEvents txtShipID As System.Windows.Forms.TextBox
        Friend WithEvents lblShipID As System.Windows.Forms.Label
        Friend WithEvents lstShipIDsToChange As System.Windows.Forms.ListBox
        Friend WithEvents lblShipIDsToChange As System.Windows.Forms.Label
        Friend WithEvents lblShipType As System.Windows.Forms.Label
        Friend WithEvents cboShipType As C1.Win.C1List.C1Combo
        Friend WithEvents lblTrackingNumber As System.Windows.Forms.Label
        Friend WithEvents txtTrackingNumber As System.Windows.Forms.TextBox
        Friend WithEvents txtShippingCost As System.Windows.Forms.TextBox
        Friend WithEvents lblShippingCost As System.Windows.Forms.Label
        Friend WithEvents btnUpdateSTTN As System.Windows.Forms.Button
        Friend WithEvents lblSelectCustomer As System.Windows.Forms.Label
        Friend WithEvents cboSelectCustomer As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAdmin))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpgManagePreBillLot = New System.Windows.Forms.TabPage()
            Me.gbSearchPreBillLot = New System.Windows.Forms.GroupBox()
            Me.txtAdminPreBillSN = New System.Windows.Forms.TextBox()
            Me.btnAdminReprintPreBillLot = New System.Windows.Forms.Button()
            Me.lblAdminLotName = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.gbPreBillLot = New System.Windows.Forms.GroupBox()
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me.btnAdminCloseTodaysPreBill = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.lblWrtyStatus = New System.Windows.Forms.Label()
            Me.txtCollectSN = New System.Windows.Forms.TextBox()
            Me.tpgManufWrtyOverride = New System.Windows.Forms.TabPage()
            Me.gbChangeWrtyStatus = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtDateCode = New System.Windows.Forms.TextBox()
            Me.lblCurrentStatus = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnChangeToIW = New System.Windows.Forms.Button()
            Me.txtWrtyOverrideSN = New System.Windows.Forms.TextBox()
            Me.tpgChangeShipTypeTrackingNumber = New System.Windows.Forms.TabPage()
            Me.btnUpdateSTTN = New System.Windows.Forms.Button()
            Me.txtShippingCost = New System.Windows.Forms.TextBox()
            Me.lblShippingCost = New System.Windows.Forms.Label()
            Me.txtTrackingNumber = New System.Windows.Forms.TextBox()
            Me.lblTrackingNumber = New System.Windows.Forms.Label()
            Me.cboShipType = New C1.Win.C1List.C1Combo()
            Me.lblShipType = New System.Windows.Forms.Label()
            Me.lblShipIDsToChange = New System.Windows.Forms.Label()
            Me.lstShipIDsToChange = New System.Windows.Forms.ListBox()
            Me.txtShipID = New System.Windows.Forms.TextBox()
            Me.lblShipID = New System.Windows.Forms.Label()
            Me.lblSelectCustomer = New System.Windows.Forms.Label()
            Me.cboSelectCustomer = New C1.Win.C1List.C1Combo()
            Me.TabControl1.SuspendLayout()
            Me.tpgManagePreBillLot.SuspendLayout()
            Me.gbSearchPreBillLot.SuspendLayout()
            Me.gbPreBillLot.SuspendLayout()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpgManufWrtyOverride.SuspendLayout()
            Me.gbChangeWrtyStatus.SuspendLayout()
            Me.tpgChangeShipTypeTrackingNumber.SuspendLayout()
            CType(Me.cboShipType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboSelectCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgManagePreBillLot, Me.tpgManufWrtyOverride, Me.tpgChangeShipTypeTrackingNumber})
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(784, 512)
            Me.TabControl1.TabIndex = 0
            '
            'tpgManagePreBillLot
            '
            Me.tpgManagePreBillLot.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgManagePreBillLot.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbSearchPreBillLot, Me.gbPreBillLot, Me.lblSN, Me.lblWrtyStatus, Me.txtCollectSN})
            Me.tpgManagePreBillLot.Location = New System.Drawing.Point(4, 22)
            Me.tpgManagePreBillLot.Name = "tpgManagePreBillLot"
            Me.tpgManagePreBillLot.Size = New System.Drawing.Size(776, 486)
            Me.tpgManagePreBillLot.TabIndex = 0
            Me.tpgManagePreBillLot.Text = "Pre-Bill Lot"
            '
            'gbSearchPreBillLot
            '
            Me.gbSearchPreBillLot.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtAdminPreBillSN, Me.btnAdminReprintPreBillLot, Me.lblAdminLotName, Me.Label4})
            Me.gbSearchPreBillLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbSearchPreBillLot.Location = New System.Drawing.Point(8, 192)
            Me.gbSearchPreBillLot.Name = "gbSearchPreBillLot"
            Me.gbSearchPreBillLot.Size = New System.Drawing.Size(256, 168)
            Me.gbSearchPreBillLot.TabIndex = 127
            Me.gbSearchPreBillLot.TabStop = False
            Me.gbSearchPreBillLot.Text = "Search Pre-Bill Lot"
            '
            'txtAdminPreBillSN
            '
            Me.txtAdminPreBillSN.Location = New System.Drawing.Point(16, 56)
            Me.txtAdminPreBillSN.Name = "txtAdminPreBillSN"
            Me.txtAdminPreBillSN.Size = New System.Drawing.Size(216, 20)
            Me.txtAdminPreBillSN.TabIndex = 76
            Me.txtAdminPreBillSN.Text = ""
            '
            'btnAdminReprintPreBillLot
            '
            Me.btnAdminReprintPreBillLot.BackColor = System.Drawing.Color.SteelBlue
            Me.btnAdminReprintPreBillLot.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAdminReprintPreBillLot.ForeColor = System.Drawing.Color.White
            Me.btnAdminReprintPreBillLot.Location = New System.Drawing.Point(16, 120)
            Me.btnAdminReprintPreBillLot.Name = "btnAdminReprintPreBillLot"
            Me.btnAdminReprintPreBillLot.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnAdminReprintPreBillLot.Size = New System.Drawing.Size(216, 24)
            Me.btnAdminReprintPreBillLot.TabIndex = 6
            Me.btnAdminReprintPreBillLot.Text = "Reprint Lot"
            '
            'lblAdminLotName
            '
            Me.lblAdminLotName.BackColor = System.Drawing.Color.Transparent
            Me.lblAdminLotName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAdminLotName.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.lblAdminLotName.Location = New System.Drawing.Point(16, 88)
            Me.lblAdminLotName.Name = "lblAdminLotName"
            Me.lblAdminLotName.Size = New System.Drawing.Size(232, 16)
            Me.lblAdminLotName.TabIndex = 77
            Me.lblAdminLotName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label4.Location = New System.Drawing.Point(16, 32)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(232, 16)
            Me.Label4.TabIndex = 75
            Me.Label4.Text = "Scan SN/IMEI"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'gbPreBillLot
            '
            Me.gbPreBillLot.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLocations, Me.btnAdminCloseTodaysPreBill, Me.Label3, Me.Label1, Me.cboCustomers})
            Me.gbPreBillLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbPreBillLot.Location = New System.Drawing.Point(8, 16)
            Me.gbPreBillLot.Name = "gbPreBillLot"
            Me.gbPreBillLot.Size = New System.Drawing.Size(256, 168)
            Me.gbPreBillLot.TabIndex = 126
            Me.gbPreBillLot.TabStop = False
            Me.gbPreBillLot.Text = "Pre-Bill Lot"
            '
            'cboLocations
            '
            Me.cboLocations.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocations.Caption = ""
            Me.cboLocations.CaptionHeight = 17
            Me.cboLocations.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocations.ColumnCaptionHeight = 17
            Me.cboLocations.ColumnFooterHeight = 17
            Me.cboLocations.ContentHeight = 15
            Me.cboLocations.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocations.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocations.EditorHeight = 15
            Me.cboLocations.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboLocations.ItemHeight = 15
            Me.cboLocations.Location = New System.Drawing.Point(24, 86)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(5, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(216, 21)
            Me.cboLocations.TabIndex = 124
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
            ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
            "le9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
            "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
            "ol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
            "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
            "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
            "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
            "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
            "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
            "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
            """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
            "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
            "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'btnAdminCloseTodaysPreBill
            '
            Me.btnAdminCloseTodaysPreBill.BackColor = System.Drawing.Color.SteelBlue
            Me.btnAdminCloseTodaysPreBill.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAdminCloseTodaysPreBill.ForeColor = System.Drawing.Color.White
            Me.btnAdminCloseTodaysPreBill.Location = New System.Drawing.Point(24, 118)
            Me.btnAdminCloseTodaysPreBill.Name = "btnAdminCloseTodaysPreBill"
            Me.btnAdminCloseTodaysPreBill.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnAdminCloseTodaysPreBill.Size = New System.Drawing.Size(216, 32)
            Me.btnAdminCloseTodaysPreBill.TabIndex = 2
            Me.btnAdminCloseTodaysPreBill.Text = "CLOSE TODAY'S PRE-BILL"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(24, 22)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 123
            Me.Label3.Text = "Customer "
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(24, 70)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(88, 16)
            Me.Label1.TabIndex = 125
            Me.Label1.Text = "Location "
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboCustomers
            '
            Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomers.Caption = ""
            Me.cboCustomers.CaptionHeight = 17
            Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomers.ColumnCaptionHeight = 17
            Me.cboCustomers.ColumnFooterHeight = 17
            Me.cboCustomers.ContentHeight = 15
            Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 15
            Me.cboCustomers.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(24, 38)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(216, 21)
            Me.cboCustomers.TabIndex = 1
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
            ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
            "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
            "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
            "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
            "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
            "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
            "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
            "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
            "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
            "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
            """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
            "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
            "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.lblSN.Location = New System.Drawing.Point(416, 96)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(216, 16)
            Me.lblSN.TabIndex = 80
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblSN.Visible = False
            '
            'lblWrtyStatus
            '
            Me.lblWrtyStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblWrtyStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyStatus.ForeColor = System.Drawing.SystemColors.ActiveCaption
            Me.lblWrtyStatus.Location = New System.Drawing.Point(416, 72)
            Me.lblWrtyStatus.Name = "lblWrtyStatus"
            Me.lblWrtyStatus.Size = New System.Drawing.Size(216, 16)
            Me.lblWrtyStatus.TabIndex = 79
            Me.lblWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblWrtyStatus.Visible = False
            '
            'txtCollectSN
            '
            Me.txtCollectSN.Location = New System.Drawing.Point(416, 40)
            Me.txtCollectSN.Name = "txtCollectSN"
            Me.txtCollectSN.Size = New System.Drawing.Size(216, 20)
            Me.txtCollectSN.TabIndex = 78
            Me.txtCollectSN.Text = ""
            Me.txtCollectSN.Visible = False
            '
            'tpgManufWrtyOverride
            '
            Me.tpgManufWrtyOverride.BackColor = System.Drawing.Color.SteelBlue
            Me.tpgManufWrtyOverride.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbChangeWrtyStatus})
            Me.tpgManufWrtyOverride.Location = New System.Drawing.Point(4, 22)
            Me.tpgManufWrtyOverride.Name = "tpgManufWrtyOverride"
            Me.tpgManufWrtyOverride.Size = New System.Drawing.Size(776, 486)
            Me.tpgManufWrtyOverride.TabIndex = 1
            Me.tpgManufWrtyOverride.Text = "Pantech OOW Override"
            '
            'gbChangeWrtyStatus
            '
            Me.gbChangeWrtyStatus.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.txtDateCode, Me.lblCurrentStatus, Me.Label5, Me.btnChangeToIW, Me.txtWrtyOverrideSN})
            Me.gbChangeWrtyStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbChangeWrtyStatus.ForeColor = System.Drawing.Color.White
            Me.gbChangeWrtyStatus.Location = New System.Drawing.Point(16, 16)
            Me.gbChangeWrtyStatus.Name = "gbChangeWrtyStatus"
            Me.gbChangeWrtyStatus.Size = New System.Drawing.Size(440, 224)
            Me.gbChangeWrtyStatus.TabIndex = 1
            Me.gbChangeWrtyStatus.TabStop = False
            Me.gbChangeWrtyStatus.Text = "Change Warranty Status"
            Me.gbChangeWrtyStatus.Visible = False
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(32, 101)
            Me.Label2.Name = "Label2"
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "SN/MSN:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDateCode
            '
            Me.txtDateCode.Location = New System.Drawing.Point(136, 102)
            Me.txtDateCode.Name = "txtDateCode"
            Me.txtDateCode.Size = New System.Drawing.Size(264, 21)
            Me.txtDateCode.TabIndex = 4
            Me.txtDateCode.Text = ""
            '
            'lblCurrentStatus
            '
            Me.lblCurrentStatus.Location = New System.Drawing.Point(136, 64)
            Me.lblCurrentStatus.Name = "lblCurrentStatus"
            Me.lblCurrentStatus.Size = New System.Drawing.Size(264, 23)
            Me.lblCurrentStatus.TabIndex = 3
            Me.lblCurrentStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(32, 32)
            Me.Label5.Name = "Label5"
            Me.Label5.TabIndex = 2
            Me.Label5.Text = "IMEI:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnChangeToIW
            '
            Me.btnChangeToIW.Location = New System.Drawing.Point(144, 152)
            Me.btnChangeToIW.Name = "btnChangeToIW"
            Me.btnChangeToIW.Size = New System.Drawing.Size(264, 23)
            Me.btnChangeToIW.TabIndex = 1
            Me.btnChangeToIW.Text = "Change to IW"
            '
            'txtWrtyOverrideSN
            '
            Me.txtWrtyOverrideSN.Location = New System.Drawing.Point(136, 32)
            Me.txtWrtyOverrideSN.Name = "txtWrtyOverrideSN"
            Me.txtWrtyOverrideSN.Size = New System.Drawing.Size(264, 21)
            Me.txtWrtyOverrideSN.TabIndex = 0
            Me.txtWrtyOverrideSN.Text = ""
            '
            'tpgChangeShipTypeTrackingNumber
            '
            Me.tpgChangeShipTypeTrackingNumber.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tpgChangeShipTypeTrackingNumber.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboSelectCustomer, Me.lblSelectCustomer, Me.btnUpdateSTTN, Me.txtShippingCost, Me.lblShippingCost, Me.txtTrackingNumber, Me.lblTrackingNumber, Me.cboShipType, Me.lblShipType, Me.lblShipIDsToChange, Me.lstShipIDsToChange, Me.txtShipID, Me.lblShipID})
            Me.tpgChangeShipTypeTrackingNumber.Location = New System.Drawing.Point(4, 22)
            Me.tpgChangeShipTypeTrackingNumber.Name = "tpgChangeShipTypeTrackingNumber"
            Me.tpgChangeShipTypeTrackingNumber.Size = New System.Drawing.Size(776, 486)
            Me.tpgChangeShipTypeTrackingNumber.TabIndex = 2
            Me.tpgChangeShipTypeTrackingNumber.Text = "Change Ship Type or Tracking Number"
            '
            'btnUpdateSTTN
            '
            Me.btnUpdateSTTN.BackColor = System.Drawing.Color.SteelBlue
            Me.btnUpdateSTTN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateSTTN.ForeColor = System.Drawing.Color.White
            Me.btnUpdateSTTN.Location = New System.Drawing.Point(592, 216)
            Me.btnUpdateSTTN.Name = "btnUpdateSTTN"
            Me.btnUpdateSTTN.Size = New System.Drawing.Size(136, 40)
            Me.btnUpdateSTTN.TabIndex = 88
            Me.btnUpdateSTTN.Text = "&Update"
            '
            'txtShippingCost
            '
            Me.txtShippingCost.BackColor = System.Drawing.Color.FloralWhite
            Me.txtShippingCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShippingCost.ForeColor = System.Drawing.Color.Blue
            Me.txtShippingCost.Location = New System.Drawing.Point(584, 160)
            Me.txtShippingCost.Name = "txtShippingCost"
            Me.txtShippingCost.Size = New System.Drawing.Size(152, 22)
            Me.txtShippingCost.TabIndex = 87
            Me.txtShippingCost.Text = ""
            '
            'lblShippingCost
            '
            Me.lblShippingCost.BackColor = System.Drawing.Color.Transparent
            Me.lblShippingCost.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShippingCost.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblShippingCost.Location = New System.Drawing.Point(448, 160)
            Me.lblShippingCost.Name = "lblShippingCost"
            Me.lblShippingCost.Size = New System.Drawing.Size(128, 16)
            Me.lblShippingCost.TabIndex = 86
            Me.lblShippingCost.Text = "Shipping Cost"
            Me.lblShippingCost.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtTrackingNumber
            '
            Me.txtTrackingNumber.BackColor = System.Drawing.Color.FloralWhite
            Me.txtTrackingNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtTrackingNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTrackingNumber.ForeColor = System.Drawing.Color.Blue
            Me.txtTrackingNumber.Location = New System.Drawing.Point(584, 88)
            Me.txtTrackingNumber.Name = "txtTrackingNumber"
            Me.txtTrackingNumber.Size = New System.Drawing.Size(152, 22)
            Me.txtTrackingNumber.TabIndex = 85
            Me.txtTrackingNumber.Text = ""
            '
            'lblTrackingNumber
            '
            Me.lblTrackingNumber.BackColor = System.Drawing.Color.Transparent
            Me.lblTrackingNumber.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTrackingNumber.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblTrackingNumber.Location = New System.Drawing.Point(448, 88)
            Me.lblTrackingNumber.Name = "lblTrackingNumber"
            Me.lblTrackingNumber.Size = New System.Drawing.Size(128, 16)
            Me.lblTrackingNumber.TabIndex = 84
            Me.lblTrackingNumber.Text = "Tracking Number"
            Me.lblTrackingNumber.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'cboShipType
            '
            Me.cboShipType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboShipType.Caption = ""
            Me.cboShipType.CaptionHeight = 17
            Me.cboShipType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboShipType.ColumnCaptionHeight = 17
            Me.cboShipType.ColumnFooterHeight = 17
            Me.cboShipType.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
            Me.cboShipType.ContentHeight = 17
            Me.cboShipType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboShipType.EditorBackColor = System.Drawing.Color.FloralWhite
            Me.cboShipType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboShipType.EditorForeColor = System.Drawing.Color.Blue
            Me.cboShipType.EditorHeight = 17
            Me.cboShipType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboShipType.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboShipType.ItemHeight = 15
            Me.cboShipType.Location = New System.Drawing.Point(584, 24)
            Me.cboShipType.MatchEntryTimeout = CType(2000, Long)
            Me.cboShipType.MaxDropDownItems = CType(5, Short)
            Me.cboShipType.MaxLength = 32767
            Me.cboShipType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboShipType.Name = "cboShipType"
            Me.cboShipType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboShipType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboShipType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboShipType.Size = New System.Drawing.Size(152, 23)
            Me.cboShipType.TabIndex = 83
            Me.cboShipType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 9" & _
            ".75pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
            "le9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
            "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
            "ol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
            "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
            "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
            "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
            "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
            "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
            "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
            """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
            "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
            "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblShipType
            '
            Me.lblShipType.BackColor = System.Drawing.Color.Transparent
            Me.lblShipType.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipType.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblShipType.Location = New System.Drawing.Point(448, 24)
            Me.lblShipType.Name = "lblShipType"
            Me.lblShipType.Size = New System.Drawing.Size(128, 16)
            Me.lblShipType.TabIndex = 81
            Me.lblShipType.Text = "Ship Type"
            Me.lblShipType.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'lblShipIDsToChange
            '
            Me.lblShipIDsToChange.BackColor = System.Drawing.Color.Transparent
            Me.lblShipIDsToChange.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipIDsToChange.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblShipIDsToChange.Location = New System.Drawing.Point(16, 152)
            Me.lblShipIDsToChange.Name = "lblShipIDsToChange"
            Me.lblShipIDsToChange.Size = New System.Drawing.Size(64, 16)
            Me.lblShipIDsToChange.TabIndex = 80
            Me.lblShipIDsToChange.Text = "Ship IDs"
            Me.lblShipIDsToChange.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lstShipIDsToChange
            '
            Me.lstShipIDsToChange.BackColor = System.Drawing.Color.FloralWhite
            Me.lstShipIDsToChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstShipIDsToChange.ForeColor = System.Drawing.Color.Blue
            Me.lstShipIDsToChange.ItemHeight = 16
            Me.lstShipIDsToChange.Location = New System.Drawing.Point(16, 176)
            Me.lstShipIDsToChange.Name = "lstShipIDsToChange"
            Me.lstShipIDsToChange.Size = New System.Drawing.Size(176, 292)
            Me.lstShipIDsToChange.TabIndex = 79
            '
            'txtShipID
            '
            Me.txtShipID.BackColor = System.Drawing.Color.FloralWhite
            Me.txtShipID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtShipID.ForeColor = System.Drawing.Color.Blue
            Me.txtShipID.Location = New System.Drawing.Point(136, 88)
            Me.txtShipID.Name = "txtShipID"
            Me.txtShipID.Size = New System.Drawing.Size(112, 22)
            Me.txtShipID.TabIndex = 78
            Me.txtShipID.Text = ""
            '
            'lblShipID
            '
            Me.lblShipID.BackColor = System.Drawing.Color.Transparent
            Me.lblShipID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipID.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblShipID.Location = New System.Drawing.Point(72, 88)
            Me.lblShipID.Name = "lblShipID"
            Me.lblShipID.Size = New System.Drawing.Size(64, 16)
            Me.lblShipID.TabIndex = 77
            Me.lblShipID.Text = "Ship ID"
            Me.lblShipID.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblSelectCustomer
            '
            Me.lblSelectCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblSelectCustomer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelectCustomer.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblSelectCustomer.Location = New System.Drawing.Point(16, 24)
            Me.lblSelectCustomer.Name = "lblSelectCustomer"
            Me.lblSelectCustomer.Size = New System.Drawing.Size(120, 16)
            Me.lblSelectCustomer.TabIndex = 89
            Me.lblSelectCustomer.Text = "Select Customer"
            Me.lblSelectCustomer.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboSelectCustomer
            '
            Me.cboSelectCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboSelectCustomer.Caption = ""
            Me.cboSelectCustomer.CaptionHeight = 17
            Me.cboSelectCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboSelectCustomer.ColumnCaptionHeight = 17
            Me.cboSelectCustomer.ColumnFooterHeight = 17
            Me.cboSelectCustomer.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
            Me.cboSelectCustomer.ContentHeight = 17
            Me.cboSelectCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboSelectCustomer.EditorBackColor = System.Drawing.Color.FloralWhite
            Me.cboSelectCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSelectCustomer.EditorForeColor = System.Drawing.Color.Blue
            Me.cboSelectCustomer.EditorHeight = 17
            Me.cboSelectCustomer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboSelectCustomer.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboSelectCustomer.ItemHeight = 15
            Me.cboSelectCustomer.Location = New System.Drawing.Point(136, 24)
            Me.cboSelectCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboSelectCustomer.MaxDropDownItems = CType(5, Short)
            Me.cboSelectCustomer.MaxLength = 32767
            Me.cboSelectCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboSelectCustomer.Name = "cboSelectCustomer"
            Me.cboSelectCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboSelectCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboSelectCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboSelectCustomer.Size = New System.Drawing.Size(288, 23)
            Me.cboSelectCustomer.TabIndex = 90
            Me.cboSelectCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 9" & _
            ".75pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
            "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
            "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
            "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
            "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
            "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
            "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
            "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
            "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
            "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
            """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
            "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
            "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'frmAdmin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(824, 542)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmAdmin"
            Me.Text = "frmAdmin"
            Me.TabControl1.ResumeLayout(False)
            Me.tpgManagePreBillLot.ResumeLayout(False)
            Me.gbSearchPreBillLot.ResumeLayout(False)
            Me.gbPreBillLot.ResumeLayout(False)
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpgManufWrtyOverride.ResumeLayout(False)
            Me.gbChangeWrtyStatus.ResumeLayout(False)
            Me.tpgChangeShipTypeTrackingNumber.ResumeLayout(False)
            CType(Me.cboShipType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboSelectCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************************************************
        Private Sub frmAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim objPantech As New PSS.Data.Buisness.Pantech()

            Try
                If PSS.Core.ApplicationUser.GetPermission("PantechOOWOverride") > 0 Then
                    Me.gbChangeWrtyStatus.Visible = True
                Else
                    Me.gbChangeWrtyStatus.Visible = False
                End If

                dt = objPantech.GetPantechCustomers(True)
                _booLoadDataToCombo = True
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = 0
                Me.cboCustomers.SelectAll() : Me.cboCustomers.Focus()

                LoadCustomers()
                SetupShipTypes()
                SelectPantech()
                EnableTrackingNumberTabControls(IIf(Me.cboCustomers.SelectedIndex > 0, True, False))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmAdmin_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt) : objPantech = Nothing
                _booLoadDataToCombo = False
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub cboCustomers_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.RowChange
            Dim dt As DataTable
            Dim objPantech As New PSS.Data.Buisness.Pantech()

            Try
                If Me._booLoadDataToCombo = False AndAlso Me.cboCustomers.SelectedValue > 0 Then
                    'Populate Location
                    dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                    Me.cboLocations.Enabled = True
                    If dt.Rows.Count = 2 Then Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCustomers_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt) : _booLoadDataToCombo = False
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnAdminCloseTodaysPreBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminCloseTodaysPreBill.Click
            Dim i As Integer = 0

            Try
                If Me.cboCustomers.SelectedValue = 0 OrElse IsNothing(Me.cboLocations.DataSource) Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboCustomers.SelectAll() : Me.cboCustomers.Focus()
                ElseIf Not IsNothing(Me.cboLocations.DataSource) AndAlso Me.cboLocations.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.cboLocations.SelectAll() : Me.cboLocations.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    i = Me._objPartRelated.CloseTodaysPreBill(Me.cboLocations.SelectedValue, PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.IDShift)

                    If i > 0 Then
                        MessageBox.Show("Close completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        MessageBox.Show("There is no pre-bill data to close for selected location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub txtAdminPreBillSN_cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAdminPreBillSN.KeyUp, cboCustomers.KeyUp
            Dim dt1 As DataTable

            Try
                If e.KeyValue = 13 Then
                    If sender.name = "txtAdminPreBillSN" Then
                        'Clear Pre-Bill Lot Name
                        Me.lblAdminLotName.Text = ""

                        If Trim(Me.txtAdminPreBillSN.Text) = "" Then
                            Exit Sub
                        ElseIf Me.cboLocations.SelectedValue = 0 Then
                            MessageBox.Show("Please select location", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else
                            'Get Lot Name by SN
                            dt1 = Me._objPartRelated.GetPreBillLotBySN(Me.txtAdminPreBillSN.Text.Trim, Me.cboLocations.SelectedValue)

                            If dt1.Rows.Count = 0 Then
                                MessageBox.Show("Device SN either does not exist in the system or does not belong to any of 'Pre-Bill Lot'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Else
                                Me.lblAdminLotName.Text = dt1.Rows(0)("PreBillLot_Name")
                            End If
                        End If
                    ElseIf sender.name = "cboCustomers" Then
                        If Me.cboCustomers.SelectedValue > 0 Then
                            Me.cboLocations.SelectAll() : Me.cboLocations.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnAdminReprintPreBillLot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdminReprintPreBillLot.Click
            Try
                If Trim(Me.lblAdminLotName.Text) <> "" Then
                    If MessageBox.Show("Are you sure you want print a report for this Pre-Bill Lot?", "Print Pre-Bill Lot", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor : Me.Enabled = False
                        Me._objPartRelated.PrintPreBillLotDetailsRpt(Trim(Me.lblAdminLotName.Text))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub txtCollectSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCollectSN.KeyUp
            'Dim dt As DataTable
            'Dim strSN, strSql, strCelloptSN As String
            'Dim i As Integer = 0
            'Dim objPantech As New PSS.Data.Buisness.Pantech()

            'Try
            '    If e.KeyCode = Keys.Enter Then
            '        strSN = "" : strSql = "" : strCelloptSN = ""

            '        If Me.txtCollectSN.Text.Trim.Length > 0 Then
            '            dt = PSS.Data.Buisness.Generic.GetDeviceInfoInWIP(Me.txtCollectSN.Text.Trim, PSS.Data.Buisness.Pantech.Pantech_CUSTOMER_ID, PSS.Data.Buisness.Pantech.Pantech_LOC_ID)

            '            If dt.Rows.Count > 0 Then
            '                Me.lblWrtyStatus.Text = IIf(dt.Rows(0)("Device_ManufWrty").ToString = "1", "IW", "OW")
            '                If dt.Rows(0)("Device_ManufWrty").ToString = "1" Then
            '                    strCelloptSN = objPantech.GetCelloptSN(dt.Rows(0)("Device_ID"))
            '                    Me.lblSN.Text = strCelloptSN

            '                    strSN = InputBox("Enter SN: ", "SN").Trim

            '                    If strCelloptSN.Trim.ToLower <> strSN.Trim.ToLower Then
            '                        If MessageBox.Show("SN not the same. Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
            '                    End If

            '                    If strSN.Trim.Length < 10 Then
            '                        MessageBox.Show("Invalid S/N", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            '                    Else
            '                        i = objPantech.UpdateCelloptSN(strSN, dt.Rows(0)("Device_ID"))
            '                        If i > 0 Then Me.txtCollectSN.Text = ""
            '                    End If
            '                End If
            '            End If
            '        End If
            '    End If
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Finally
            '    PSS.Data.Buisness.Generic.DisposeDT(dt)
            'End Try
        End Sub

        '*************************************************************************************************************


#Region "OOW Override"

        '*************************************************************************************************************
        Private Sub txtWrtyOverrideSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWrtyOverrideSN.KeyUp
            Dim dt As DataTable
            Dim objPT As PSS.Data.Buisness.Pantech

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtWrtyOverrideSN.Text.Trim.Length > 0 Then
                        objPT = New PSS.Data.Buisness.Pantech()
                        dt = objPT.GetPantechSNInfoInWIP(Me.txtWrtyOverrideSN.Text.Trim)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("IMEI does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate IMEI. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt64(dt.Rows(0)("Pallett_ID")) > 0 Then
                            MessageBox.Show("Device has already assigned to a shipping box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            If dt.Rows(0)("Device_ManufWrty").ToString = "1" Then Me.lblCurrentStatus.Text = "In Warranty" Else Me.lblCurrentStatus.Text = "Out of Warranty"

                            If Not IsDBNull(dt.Rows(0)("CellOpt_MSN")) Then Me.txtDateCode.Text = dt.Rows(0)("CellOpt_MSN").ToString.Trim Else Me.txtDateCode.Text = ""
                            If Me.txtDateCode.Text.Trim.Length > 0 Then Me.txtDateCode.Enabled = False Else Me.txtDateCode.Enabled = True
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                objPT = Nothing
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnChangeToIW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeToIW.Click
            Dim dt As DataTable
            Dim strCelloptMSN As String = ""
            Dim i As Integer = 0
            Dim objPT As PSS.Data.Buisness.Pantech

            Try
                If Me.txtWrtyOverrideSN.Text.Trim.Length > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    objPT = New PSS.Data.Buisness.Pantech()
                    dt = objPT.GetPantechSNInfoInWIP(Me.txtWrtyOverrideSN.Text.Trim)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("IMEI does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate IMEI. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt64(dt.Rows(0)("Pallett_ID")) > 0 Then
                        MessageBox.Show("Device has already assigned to a shipping box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows(0)("Device_ManufWrty").ToString = "1" Then
                        MessageBox.Show("No update needed. Device is in warranty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDateCode.Text = "" : Me.txtDateCode.Enabled = True : Me.lblCurrentStatus.Text = ""
                        Me.Enabled = True : Me.txtWrtyOverrideSN.SelectAll() : Me.txtWrtyOverrideSN.Focus()
                    ElseIf Me.txtDateCode.Text.Trim.Length = 0 Then
                        MessageBox.Show("Please enter device's SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        If Me.txtDateCode.Text.Trim.ToLower.Equals(dt.Rows(0)("CellOpt_MSN").ToString.Trim.ToLower) = False Then strCelloptMSN = Me.txtDateCode.Text.Trim
                        i = objPT.UpdateWrtyStatus(dt.Rows(0)("Device_ID"), strCelloptMSN, 1, PSS.Core.ApplicationUser.IDuser)
                        If i > 0 Then
                            MessageBox.Show("Update is completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.lblCurrentStatus.Text = ""
                            Me.txtDateCode.Text = "" : Me.txtDateCode.Enabled = True
                            Me.Enabled = True : Me.txtWrtyOverrideSN.Text = "" : Me.txtWrtyOverrideSN.Focus()
                        Else
                            MessageBox.Show("Update failed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.Enabled = True : Me.txtWrtyOverrideSN.SelectAll() : Me.txtWrtyOverrideSN.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt) : objPT = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************

#End Region

        '*************************************************************************************************************
        Private Sub SetupShipTypes()
            Dim dtShipTypes As DataTable = Nothing
            Dim objPantech As New PSS.Data.Buisness.Pantech()

            Try
                dtShipTypes = objPantech.GetShipTypes()

                Misc.PopulateC1DropDownList(Me.cboShipType, dtShipTypes, "ShipType", "ShipTypeID")
                Me.cboShipType.SelectedIndex = 0
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtShipTypes)
            End Try
        End Sub

        Private Sub txtShippingCost_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShippingCost.KeyPress
            Try
                If Not (Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar) Or e.KeyChar.ToString().Equals(".")) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub txtShipID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipID.KeyDown
            Try
                If e.KeyCode = Keys.Enter Then
                    AddShipID()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub AddShipID()
            Try
                Dim strShipID As String = Me.txtShipID.Text.Trim

                If strShipID.Length > 0 Then
                    Dim objPantech As New PSS.Data.Buisness.Pantech()
                    Dim iShipID As Integer = Convert.ToInt32(strShipID)
                    Dim iCustomerID As Integer = Convert.ToInt32(cboSelectCustomer.SelectedValue)

                    If objPantech.IsValidShipID(iShipID) Then
                        If Not objPantech.HasTrackingNumber(iShipID) Then
                            If objPantech.CheckShipIDToCustomerID(iShipID, iCustomerID) Then
                                If Me.lstShipIDsToChange.Items.Count > 0 Then
                                    Dim i As Integer

                                    For i = 0 To Me.lstShipIDsToChange.Items.Count - 1
                                        Dim iShipIDTemp As Integer = Me.lstShipIDsToChange.Items(i)

                                        If iShipIDTemp = iShipID Then
                                            MessageBox.Show("This ship ID has already been entered.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                            Me.txtShipID.Text = String.Empty
                                            Me.txtShipID.Focus()

                                            Return
                                        End If
                                    Next i
                                End If

                                Me.lstShipIDsToChange.Items.Add(iShipID)
                            Else
                                MessageBox.Show("This ship ID is not associated with the selected customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            End If
                        Else
                            MessageBox.Show("This ship ID already has an associated tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        End If
                    Else
                        MessageBox.Show("This is not a valid ship ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If

                    Me.btnUpdateSTTN.Enabled = True
                    Me.txtShipID.Text = String.Empty
                    Me.txtShipID.Focus()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub txtShipID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtShipID.KeyPress
            Try
                If Not (Char.IsControl(e.KeyChar) Or Char.IsDigit(e.KeyChar)) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub lstShipIDsToChange_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstShipIDsToChange.MouseHover
            Try
                Dim lst As ListBox = DirectCast(sender, ListBox)

                If lst.Items.Count > 0 Then
                    Dim tt As New ToolTip()

                    tt.AutomaticDelay = 1000
                    tt.AutoPopDelay = 1000
                    tt.ReshowDelay = 1000
                    tt.SetToolTip(DirectCast(sender, ListBox), "Right click on a selected ship ID to delete it.")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub lstShipIDsToChange_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstShipIDsToChange.MouseDown
            Try
                If e.Button = MouseButtons.Right And Me.lstShipIDsToChange.SelectedItems.Count > 0 Then
                    Dim lst As ListBox = DirectCast(sender, ListBox)
                    Dim ctm As New ContextMenu()
                    Dim objMenuItem As New MenuItem()

                    objMenuItem.Text = String.Format("Remove ship ID {0}.", lst.SelectedItem)
                    objMenuItem.Enabled = True

                    RemoveHandler objMenuItem.Click, AddressOf _lstShipIDsToChangeDelete_Click
                    AddHandler objMenuItem.Click, AddressOf _lstShipIDsToChangeDelete_Click

                    ctm.MenuItems.Add(objMenuItem)

                    lst.ContextMenu = ctm
                    lst.ContextMenu.Show(lst, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub _lstShipIDsToChangeDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                If Me.lstShipIDsToChange.SelectedIndex > -1 Then
                    Me.lstShipIDsToChange.Items.RemoveAt(Me.lstShipIDsToChange.SelectedIndex)
                    Me.btnUpdateSTTN.Enabled = IIf(Me.lstShipIDsToChange.Items.Count > 0, True, False)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnUpdateSTTN_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateSTTN.Click
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                If Me.cboShipType.SelectedIndex <= 0 Then
                    MessageBox.Show("You must select a ship type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ElseIf Me.txtShippingCost.Text.Trim.Length = 0 Or Me.txtShippingCost.Text.Trim().Equals(".") Then
                    MessageBox.Show("You must enter a shipping cost.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                ElseIf Me.txtTrackingNumber.Text.Trim.Length = 0 Then
                    MessageBox.Show("You must enter a tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Else
                    Dim iShipTypeID As Integer = Me.cboShipType.SelectedValue
                    Dim iShipIDs(Me.lstShipIDsToChange.Items.Count - 1) As Integer
                    Dim i As Integer
                    Dim objPantech As New PSS.Data.Buisness.Pantech()

                    For i = 0 To Me.lstShipIDsToChange.Items.Count - 1 : iShipIDs(i) = Me.lstShipIDsToChange.Items(i) : Next i

                    objPantech.UpdateShipTypeTrackingNumber(iShipIDs, iShipTypeID, Convert.ToDecimal(Me.txtShippingCost.Text.Trim), Me.txtTrackingNumber.Text.Trim, PSS.Core.Global.ApplicationUser.IDuser)
                    MessageBox.Show("Update complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

                    Me.txtShipID.Text = String.Empty
                    Me.lstShipIDsToChange.Items.Clear()
                    Me.cboShipType.SelectedIndex = 0
                    Me.txtTrackingNumber.Text = String.Empty
                    Me.txtShippingCost.Text = String.Empty
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub lstShipIDsToChange_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstShipIDsToChange.MouseUp
            Try
                Dim lst As ListBox = DirectCast(sender, ListBox)

                lst.ContextMenu = Nothing
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub LoadCustomers()
            Dim dtCustomers As DataTable = Nothing

            Try
                Dim objPantech As New PSS.Data.Buisness.Pantech()

                dtCustomers = objPantech.GetCustomers()
                Misc.PopulateC1DropDownList(Me.cboSelectCustomer, dtCustomers, "Customer", "Cust_ID")
                Me.cboSelectCustomer.SelectedIndex = 0
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtCustomers)
            End Try
        End Sub

        Private Sub EnableTrackingNumberTabControls(ByVal bEnable As Boolean)
            Try
                Dim ctl As Control

                For Each ctl In Me.tpgChangeShipTypeTrackingNumber.Controls
                    If Not (ctl.Name.Equals("cboSelectCustomer") Or ctl.Name.Equals("lblSelectCustomer")) Then ctl.Enabled = bEnable
                Next ctl

                Me.btnUpdateSTTN.Enabled = bEnable And IIf(Me.lstShipIDsToChange.Items.Count > 0, True, False)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub cboSelectCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSelectCustomer.SelectedValueChanged
            Try
                Dim cbo As C1.Win.C1List.C1Combo = DirectCast(sender, C1.Win.C1List.C1Combo)

                EnableTrackingNumberTabControls(IIf(cbo.SelectedIndex > 0, True, False))
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub SelectPantech()
            Try
                Dim i As Integer

                For i = 0 To cboSelectCustomer.ListCount - 1
                    If Me.cboSelectCustomer.GetItemText(i, "Cust_ID").Equals(Me._iCustID.ToString()) Then
                        Me.cboSelectCustomer.SelectedIndex = i

                        Exit For
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace