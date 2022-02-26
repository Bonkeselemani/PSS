Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.NativeInstruments
    Public Class frmNIShipProduct
        Inherits System.Windows.Forms.Form
        Public _strScreenName As String = ""
        Private _objShip As PSS.Data.Production.Shipping
        Private _objNIShip As NIRecShip
        Private _objNIRec As NIRec
        Private _objNI As NI
        Private _isRepairThisUnit As Boolean = False
        Private _isRefurb As Boolean = False
        Private _isScrap As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _objShip = New PSS.Data.Production.Shipping()
            _objNIShip = New NIRecShip()

            Me.lblTitle.Text = "NI - " & _strScreenName
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
        Friend WithEvents panelPallet As System.Windows.Forms.Panel
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblRMANo As System.Windows.Forms.Label
        Friend WithEvents lblShippedCount As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents btnReprintManifest As System.Windows.Forms.Button
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseAndShipBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblRMACount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblBoxCount As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblRepairType As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents pnlShipTracking As System.Windows.Forms.Panel
        Friend WithEvents txtFreightage As System.Windows.Forms.TextBox
        Friend WithEvents txtWeight As System.Windows.Forms.TextBox
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents lblInTrackNo As System.Windows.Forms.Label
        Friend WithEvents txtTrackNo As System.Windows.Forms.TextBox
        Friend WithEvents cboCarrier As C1.Win.C1List.C1Combo
        Friend WithEvents lblCarrier As System.Windows.Forms.Label
        Friend WithEvents lblPalletID As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblCosmeticGrade As System.Windows.Forms.Label
        Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmNIShipProduct))
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.chkPrint = New System.Windows.Forms.CheckBox()
            Me.lblCosmeticGrade = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblPalletID = New System.Windows.Forms.Label()
            Me.pnlShipTracking = New System.Windows.Forms.Panel()
            Me.txtFreightage = New System.Windows.Forms.TextBox()
            Me.txtWeight = New System.Windows.Forms.TextBox()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.lblInTrackNo = New System.Windows.Forms.Label()
            Me.txtTrackNo = New System.Windows.Forms.TextBox()
            Me.cboCarrier = New C1.Win.C1List.C1Combo()
            Me.lblCarrier = New System.Windows.Forms.Label()
            Me.lblRepairType = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblRMANo = New System.Windows.Forms.Label()
            Me.lblShippedCount = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnReprintManifest = New System.Windows.Forms.Button()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.lblBoxCount = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseAndShipBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblRMACount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.panelPallet.SuspendLayout()
            Me.pnlShipTracking.SuspendLayout()
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrint, Me.lblCosmeticGrade, Me.Label8, Me.lblPalletID, Me.pnlShipTracking, Me.lblRepairType, Me.Label7, Me.btnClear, Me.Label4, Me.Label1, Me.lblRMANo, Me.lblShippedCount, Me.Label5, Me.btnReprintManifest, Me.lblBoxName, Me.lblBoxCount, Me.Label2, Me.txtDevSN, Me.Label10, Me.btnCloseAndShipBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblRMACount, Me.Label3})
            Me.panelPallet.Location = New System.Drawing.Point(16, 24)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(656, 440)
            Me.panelPallet.TabIndex = 125
            '
            'chkPrint
            '
            Me.chkPrint.Location = New System.Drawing.Point(320, 376)
            Me.chkPrint.Name = "chkPrint"
            Me.chkPrint.Size = New System.Drawing.Size(120, 16)
            Me.chkPrint.TabIndex = 226
            Me.chkPrint.Text = "Print Label"
            '
            'lblCosmeticGrade
            '
            Me.lblCosmeticGrade.BackColor = System.Drawing.SystemColors.ActiveBorder
            Me.lblCosmeticGrade.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCosmeticGrade.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCosmeticGrade.ForeColor = System.Drawing.Color.Black
            Me.lblCosmeticGrade.Location = New System.Drawing.Point(560, 147)
            Me.lblCosmeticGrade.Name = "lblCosmeticGrade"
            Me.lblCosmeticGrade.Size = New System.Drawing.Size(48, 32)
            Me.lblCosmeticGrade.TabIndex = 225
            Me.lblCosmeticGrade.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(536, 131)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(96, 16)
            Me.Label8.TabIndex = 224
            Me.Label8.Text = "Cosm. Grade"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPalletID
            '
            Me.lblPalletID.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPalletID.ForeColor = System.Drawing.SystemColors.Info
            Me.lblPalletID.Location = New System.Drawing.Point(524, 80)
            Me.lblPalletID.Name = "lblPalletID"
            Me.lblPalletID.Size = New System.Drawing.Size(112, 11)
            Me.lblPalletID.TabIndex = 223
            Me.lblPalletID.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'pnlShipTracking
            '
            Me.pnlShipTracking.BackColor = System.Drawing.Color.DarkSlateGray
            Me.pnlShipTracking.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFreightage, Me.txtWeight, Me.Label20, Me.Label18, Me.lblInTrackNo, Me.txtTrackNo, Me.cboCarrier, Me.lblCarrier})
            Me.pnlShipTracking.Location = New System.Drawing.Point(312, 232)
            Me.pnlShipTracking.Name = "pnlShipTracking"
            Me.pnlShipTracking.Size = New System.Drawing.Size(328, 136)
            Me.pnlShipTracking.TabIndex = 222
            '
            'txtFreightage
            '
            Me.txtFreightage.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.txtFreightage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFreightage.Enabled = False
            Me.txtFreightage.Location = New System.Drawing.Point(272, 110)
            Me.txtFreightage.Name = "txtFreightage"
            Me.txtFreightage.Size = New System.Drawing.Size(50, 20)
            Me.txtFreightage.TabIndex = 227
            Me.txtFreightage.Text = "0"
            Me.txtFreightage.Visible = False
            '
            'txtWeight
            '
            Me.txtWeight.Location = New System.Drawing.Point(104, 110)
            Me.txtWeight.Name = "txtWeight"
            Me.txtWeight.Size = New System.Drawing.Size(40, 20)
            Me.txtWeight.TabIndex = 226
            Me.txtWeight.Text = ""
            Me.txtWeight.Visible = False
            '
            'Label20
            '
            Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.White
            Me.Label20.Location = New System.Drawing.Point(152, 110)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(112, 16)
            Me.Label20.TabIndex = 225
            Me.Label20.Text = "Cal. Freightage($):"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label20.Visible = False
            '
            'Label18
            '
            Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.White
            Me.Label18.Location = New System.Drawing.Point(8, 110)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(96, 16)
            Me.Label18.TabIndex = 224
            Me.Label18.Text = "Box Weight (lb) :"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label18.Visible = False
            '
            'lblInTrackNo
            '
            Me.lblInTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInTrackNo.ForeColor = System.Drawing.Color.White
            Me.lblInTrackNo.Location = New System.Drawing.Point(8, 62)
            Me.lblInTrackNo.Name = "lblInTrackNo"
            Me.lblInTrackNo.Size = New System.Drawing.Size(208, 16)
            Me.lblInTrackNo.TabIndex = 223
            Me.lblInTrackNo.Text = "Track No:"
            Me.lblInTrackNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtTrackNo
            '
            Me.txtTrackNo.BackColor = System.Drawing.Color.White
            Me.txtTrackNo.Location = New System.Drawing.Point(8, 78)
            Me.txtTrackNo.Name = "txtTrackNo"
            Me.txtTrackNo.Size = New System.Drawing.Size(312, 20)
            Me.txtTrackNo.TabIndex = 222
            Me.txtTrackNo.Text = ""
            '
            'cboCarrier
            '
            Me.cboCarrier.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCarrier.AutoCompletion = True
            Me.cboCarrier.AutoDropDown = True
            Me.cboCarrier.AutoSelect = True
            Me.cboCarrier.Caption = ""
            Me.cboCarrier.CaptionHeight = 17
            Me.cboCarrier.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCarrier.ColumnCaptionHeight = 17
            Me.cboCarrier.ColumnFooterHeight = 17
            Me.cboCarrier.ColumnHeaders = False
            Me.cboCarrier.ContentHeight = 15
            Me.cboCarrier.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCarrier.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCarrier.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCarrier.EditorHeight = 15
            Me.cboCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCarrier.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCarrier.ItemHeight = 15
            Me.cboCarrier.Location = New System.Drawing.Point(8, 30)
            Me.cboCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboCarrier.MaxDropDownItems = CType(10, Short)
            Me.cboCarrier.MaxLength = 32767
            Me.cboCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCarrier.Name = "cboCarrier"
            Me.cboCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCarrier.Size = New System.Drawing.Size(312, 21)
            Me.cboCarrier.TabIndex = 221
            Me.cboCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblCarrier
            '
            Me.lblCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCarrier.ForeColor = System.Drawing.Color.White
            Me.lblCarrier.Location = New System.Drawing.Point(8, 14)
            Me.lblCarrier.Name = "lblCarrier"
            Me.lblCarrier.Size = New System.Drawing.Size(208, 16)
            Me.lblCarrier.TabIndex = 220
            Me.lblCarrier.Text = "Shipment Carrier:"
            Me.lblCarrier.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'lblRepairType
            '
            Me.lblRepairType.BackColor = System.Drawing.SystemColors.ActiveBorder
            Me.lblRepairType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblRepairType.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRepairType.ForeColor = System.Drawing.Color.Black
            Me.lblRepairType.Location = New System.Drawing.Point(432, 147)
            Me.lblRepairType.Name = "lblRepairType"
            Me.lblRepairType.Size = New System.Drawing.Size(104, 32)
            Me.lblRepairType.TabIndex = 221
            Me.lblRepairType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(432, 131)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(80, 16)
            Me.Label7.TabIndex = 220
            Me.Label7.Text = "Repair Type"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.Green
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(544, 24)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClear.Size = New System.Drawing.Size(96, 32)
            Me.btnClear.TabIndex = 110
            Me.btnClear.Text = "Clear/Reset"
            Me.btnClear.Visible = False
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(320, 75)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(157, 16)
            Me.Label4.TabIndex = 109
            Me.Label4.Text = "Box Name"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(157, 16)
            Me.Label1.TabIndex = 108
            Me.Label1.Text = "Work Order/Claim #"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRMANo
            '
            Me.lblRMANo.BackColor = System.Drawing.Color.Purple
            Me.lblRMANo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblRMANo.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRMANo.ForeColor = System.Drawing.Color.White
            Me.lblRMANo.Location = New System.Drawing.Point(8, 24)
            Me.lblRMANo.Name = "lblRMANo"
            Me.lblRMANo.Size = New System.Drawing.Size(288, 32)
            Me.lblRMANo.TabIndex = 107
            Me.lblRMANo.Tag = "0"
            Me.lblRMANo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblShippedCount
            '
            Me.lblShippedCount.BackColor = System.Drawing.Color.Purple
            Me.lblShippedCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblShippedCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShippedCount.ForeColor = System.Drawing.Color.White
            Me.lblShippedCount.Location = New System.Drawing.Point(440, 24)
            Me.lblShippedCount.Name = "lblShippedCount"
            Me.lblShippedCount.Size = New System.Drawing.Size(80, 32)
            Me.lblShippedCount.TabIndex = 106
            Me.lblShippedCount.Text = "0"
            Me.lblShippedCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(424, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 16)
            Me.Label5.TabIndex = 105
            Me.Label5.Text = "Shipped Count"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReprintManifest
            '
            Me.btnReprintManifest.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnReprintManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintManifest.ForeColor = System.Drawing.Color.White
            Me.btnReprintManifest.Location = New System.Drawing.Point(496, 400)
            Me.btnReprintManifest.Name = "btnReprintManifest"
            Me.btnReprintManifest.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReprintManifest.Size = New System.Drawing.Size(136, 24)
            Me.btnReprintManifest.TabIndex = 104
            Me.btnReprintManifest.Text = "Reprint Ship Label"
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Black
            Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxName.Location = New System.Drawing.Point(320, 91)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(320, 32)
            Me.lblBoxName.TabIndex = 102
            Me.lblBoxName.Tag = "0"
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBoxCount
            '
            Me.lblBoxCount.BackColor = System.Drawing.Color.Black
            Me.lblBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxCount.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxCount.Location = New System.Drawing.Point(320, 147)
            Me.lblBoxCount.Name = "lblBoxCount"
            Me.lblBoxCount.Size = New System.Drawing.Size(80, 32)
            Me.lblBoxCount.TabIndex = 101
            Me.lblBoxCount.Text = "0"
            Me.lblBoxCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(320, 131)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 100
            Me.Label2.Text = "Box Count"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(11, 80)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(285, 20)
            Me.txtDevSN.TabIndex = 2
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(11, 64)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(157, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseAndShipBox
            '
            Me.btnCloseAndShipBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseAndShipBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseAndShipBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseAndShipBox.Location = New System.Drawing.Point(320, 400)
            Me.btnCloseAndShipBox.Name = "btnCloseAndShipBox"
            Me.btnCloseAndShipBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseAndShipBox.Size = New System.Drawing.Size(144, 24)
            Me.btnCloseAndShipBox.TabIndex = 4
            Me.btnCloseAndShipBox.Text = "Close && Ship Box"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(488, 200)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(144, 24)
            Me.btnRemoveAllSNs.TabIndex = 6
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            Me.btnRemoveAllSNs.Visible = False
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(320, 200)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(144, 24)
            Me.btnRemoveSN.TabIndex = 5
            Me.btnRemoveSN.Text = "REMOVE SN"
            Me.btnRemoveSN.Visible = False
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(11, 104)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(285, 316)
            Me.lstDevices.TabIndex = 3
            '
            'lblRMACount
            '
            Me.lblRMACount.BackColor = System.Drawing.Color.Purple
            Me.lblRMACount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblRMACount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRMACount.ForeColor = System.Drawing.Color.White
            Me.lblRMACount.Location = New System.Drawing.Point(320, 24)
            Me.lblRMACount.Name = "lblRMACount"
            Me.lblRMACount.Size = New System.Drawing.Size(80, 32)
            Me.lblRMACount.TabIndex = 97
            Me.lblRMACount.Text = "0"
            Me.lblRMACount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(320, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "WO Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(368, 24)
            Me.lblTitle.TabIndex = 126
            '
            'frmNIShipProduct
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(688, 478)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panelPallet, Me.lblTitle})
            Me.Name = "frmNIShipProduct"
            Me.Text = "frmNIShipProduct"
            Me.panelPallet.ResumeLayout(False)
            Me.pnlShipTracking.ResumeLayout(False)
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmNIShipProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.chkPrint.Checked = True
                PSS.Core.Highlight.SetHighLight(Me)
                PopulateShipmentCarrier()

                '*********************************
                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub PopulateShipmentCarrier()
            Dim row As DataRow
            Dim i As Integer
            Dim dTB As DataTable
            Dim objTMI As PSS.Data.Buisness.TMI

            Try
                Me.cboCarrier.ClearItems()

                objTMI = New PSS.Data.Buisness.TMI()
                dTB = objTMI.GetShipCarriers

                If dTB.Rows.Count > 0 Then
                    Misc.PopulateC1DropDownList(Me.cboCarrier, dTB, "SC_Desc", "SC_ID")
                    Me.cboCarrier.SelectedValue = 2 'FedEx Ground
                End If

                dTB = Nothing
                objTMI = Nothing

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateShipmentCarrier", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dTB) : objTMI = Nothing
            End Try
        End Sub

        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim dt, dtApprovedData As DataTable
            Dim iPalletID, iMaxBillRule As Integer
            Dim booNewScan, booQuoteReject As Boolean
            Dim objNewTech As New PSS.Data.Buisness.NewTech()
            Dim strRepairType As String = ""

            Try
                If e.KeyCode = Keys.Enter Then 'enter key--------------------------------------------
                    If Me.txtDevSN.Text.Trim.Length = 0 Then  'check user input----------------------
                        Exit Sub
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        dt = Generic.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, NI.CUSTOMERID, NI.LOCID, True)
                        Me.Enabled = True : Cursor.Current = Cursors.Default
                        booNewScan = False : booQuoteReject = False

                        If dt.Rows.Count = 0 Then 'check device data----------------------------------
                            MessageBox.Show("Device " & Me.txtDevSN.Text.Trim & " does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Device " & Me.txtDevSN.Text.Trim & " existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf IsDBNull(dt.Rows(0)("Device_DateBill")) Then
                            MessageBox.Show("This device " & Me.txtDevSN.Text.Trim & " has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf Me.lblRMANo.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) > 0 _
                               AndAlso Convert.ToInt32(Me.lblRMANo.Tag) <> dt.Rows(0)("WO_ID") Then
                            MessageBox.Show("This device " & Me.txtDevSN.Text.Trim & " does not belong to above work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt32(dt.Rows(0)("Pallett_ID")) > 0 _
                               AndAlso Me.lblBoxName.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) > 0 _
                               AndAlso Convert.ToInt32(Me.lblBoxName.Tag) <> dt.Rows(0)("Pallett_ID") Then
                            MessageBox.Show("Device " & Me.txtDevSN.Text.Trim & " is assigned to box ID " & dt.Rows(0)("Pallett_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf dt.Rows(0)("WorkStation").ToString.Trim.ToUpper = "WAREHOUSE" Then
                            MessageBox.Show("Can't process any unit at Warehouse station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        Else 'New scan, process it
                            _objNIShip = New NIRecShip()
                            strRepairType = _objNIShip.NIRepairType4DeviceID(dt.Rows(0)("Device_ID"))
                            If strRepairType.Trim.ToUpper = "RepairThisUnit".ToUpper Then _isRepairThisUnit = True
                            '*****************************************************
                            'Creat Pallett for "Repair This Unit
                            '*****************************************************
                            If _isRepairThisUnit Then
                                If Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 Then
                                    Me.ProcessWorkorder(dt.Rows(0)("WO_ID")) ': booNewScan = True
                                End If
                            End If
                            '*****************************************************

                            If _isRepairThisUnit And (Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 _
                               OrElse Me.lblRMANo.Tag.ToString.Trim.Length = 0 OrElse Me.lblBoxName.Tag.ToString.Trim.Length = 0 _
                               OrElse Convert.ToInt32(Me.lblRMANo.Tag) = 0 _
                               OrElse Convert.ToInt32(Me.lblBoxName.Tag) = 0) Then 'check device's order and pallett-----------------------------
                                MessageBox.Show("System has failed to process work order. Please re-enter S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Me.lblRMANo.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) <> dt.Rows(0)("WO_ID") Then
                                MessageBox.Show("This device does not belong to above work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt32(dt.Rows(0)("Pallett_ID")) > 0 AndAlso Me.lblBoxName.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) <> dt.Rows(0)("Pallett_ID") Then
                                MessageBox.Show("This device is assigned to box ID " & dt.Rows(0)("Pallett_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Me._objNIShip.IsDeviceHasServiceBillcode(Convert.ToInt32(dt.Rows(0)("Device_ID"))) = False Then
                                MessageBox.Show("Must select at least one service code in tech billing screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Me._objNIShip.IsDeviceHasTechCompletedRecord(Convert.ToInt32(dt.Rows(0)("Device_ID"))) = False Then
                                MessageBox.Show("Please complete repair with work performance in tech screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf objNewTech.GetTechNotesString(Convert.ToInt32(dt.Rows(0)("Device_ID"))).Trim.Length = 0 Then
                                MessageBox.Show("Work performance is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Not IsNothing(Me.lstDevices.DataSource) AndAlso Me.lstDevices.Items.Count > 0 AndAlso Me.lstDevices.DataSource.Table.Select("device_sn = '" & Me.txtDevSN.Text.Trim.ToUpper & "'").Length > 0 Then
                                ''***************************************************
                                ''Check if the Device is already scanned in
                                ''***************************************************
                                'If booNewScan = False Then
                                MsgBox("This device is already scanned in.", MsgBoxStyle.Information, "Information") : Me.txtDevSN.SelectAll()
                                'Else
                                '    Me.txtDevSN.Text = ""
                                'End If
                                'Me.txtDevSN.Focus()
                            ElseIf Me.IsDeviceHasRequiredServiceBillcode(Convert.ToInt32(dt.Rows(0)("Device_ID"))) = False Then
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            Else
                                'get maxium bill rule
                                iMaxBillRule = Generic.GetMaxBillRule(Convert.ToInt32(dt.Rows(0)("Device_ID")))
                                booQuoteReject = Generic.IsBillcodeExisted(Convert.ToInt32(dt.Rows(0)("Device_ID")), "Exception Repairs Quote Rejected")

                                '*****************************************************
                                'Check QC
                                '*****************************************************
                                If iMaxBillRule <> 1 AndAlso iMaxBillRule <> 2 AndAlso booQuoteReject = False Then
                                    If Generic.IsValidQCResults(dt.Rows(0)("Device_ID"), 4, "AQL", True, True) = False Then
                                        Exit Sub : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                                    End If
                                End If

                                If _isRepairThisUnit Then 'need to check OBA: QCType_ID=5
                                    If Generic.IsValidQCResults(dt.Rows(0)("Device_ID"), 5, "OBA", False, True) = False Then
                                        Exit Sub : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                                    End If
                                End If

                                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                                _objNI = New NI()
                                If _isRepairThisUnit Then
                                    iPalletID = CInt(Me.lblBoxName.Tag)
                                    Me.lblRepairType.Text = "Repaired"
                                    Me.chkPrint.Visible = True
                                ElseIf iMaxBillRule = 0 Then 'Good refurb
                                    iPalletID = _objNI.PalletID_Refurb : _isRefurb = True
                                    Me.lblRepairType.Text = "Refurb"
                                    Me.chkPrint.Visible = True
                                ElseIf iMaxBillRule > 0 Then 'scrap
                                    iPalletID = _objNI.PalletID_Scrap : _isScrap = True
                                    Me.lblRepairType.Text = "Scrap"
                                    Me.chkPrint.Visible = False
                                Else
                                    MessageBox.Show("Can't define Pallet Type!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Exit Sub : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                                End If

                                If iPalletID = 0 Then 'check pallet=0
                                    Throw New Exception("System has failed to create box: Pallet ID =0.")
                                    Exit Sub : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                                End If

                                If _isRepairThisUnit Then 'It already Created standard pallet. Otherwise it uses harcoded pallet (no need to validate it) 
                                    If Generic.IsPalletClosed(iPalletID) = True Then
                                        MsgBox("Box had been closed by another machine. Please refresh your screen.", MsgBoxStyle.Information, "Device Scan")
                                        Exit Sub : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                                    End If
                                Else 'Process WO and Pallet data
                                    ProcessWorkorderForNonRepaired(dt.Rows(0)("WO_ID"), iPalletID)
                                End If ' 

                                'Update pallet_ID in tdevice table, wait for close
                                PSS.Data.Production.Shipping.AssignDeviceToPallet(dt.Rows(0)("Device_ID"), iPalletID)
                                RefreshDeviceList(iPalletID, dt.Rows(0)("Device_ID"))
                                Me.txtDevSN.Text = "" : Me.Enabled = True : Me.txtDevSN.Focus()
                                If Me._isRepairThisUnit Then
                                    Me.pnlShipTracking.Visible = True
                                Else
                                    Me.pnlShipTracking.Visible = False
                                End If
                                Me.lblPalletID.Text = iPalletID

                                lblCosmeticGrade.Text = Me._objNIShip.NICosmeticGrade4DeviceID(dt.Rows(0)("Device_ID"))

                                ' RefreshDeviceList(iPalletID) : Me.txtDevSN.Text = "" : Me.Enabled = True : Me.txtDevSN.Focus()

                                If _isRepairThisUnit Then 'Manually close it
                                    Me.btnCloseAndShipBox.Visible = True
                                Else 'Automatically close it
                                    Me.btnCloseAndShipBox.Visible = False
                                    Me.btnCloseAndShipBox_Click(sender, e)
                                End If

                            End If 'check device's order and pallett
                        End If 'check device data----------------------------------------------------
                    End If  'check user input--------------------------------------------------------
            End If 'enter key--------------------------------------------------------------------
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


        '*************************************************************************************************************
        Private Sub ProcessWorkorder(ByVal iWOID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objShip.GetWorkorderInfo(iWOID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Work order/Claim# is missing.")
                Else
                    Me.lblRMACount.Text = dt.Rows(0)("WO_RAQnty") ' & Me.cboRMANo.SelectedValue)(0)("WO_RAQnty")
                    Me.lblRMANo.Tag = iWOID
                    Me.lblRMANo.Text = dt.Rows(0)("WO_CustWo")
                    ProcessPallet(iWOID)
                    Me.lblShippedCount.Text = Me._objShip.GetShippedCountByWO(iWOID)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub
        '*************************************************************************************************************
        Private Sub ProcessPallet(ByVal iWOID As Integer)
            Dim dt As DataTable
            Dim iPalletID As Integer = 0

            Try
                dt = Me._objShip.GetUnshipPalletByWO(iWOID)
                If dt.Rows.Count > 1 Then
                    Throw New Exception("Multiple open box existed for this RMA. Please contact IT.")
                ElseIf dt.Rows.Count = 0 Then
                    'Create new box
                    iPalletID = Me._objNIShip.CreateBoxID(NI.CUSTOMERID, NI.LOCID, iWOID)
                    If iPalletID = 0 Then Throw New Exception("System has failed to create box.")
                    Me.lblBoxName.Text = Me._objShip.GetPalletName(iPalletID) : Me.lblBoxName.Tag = iPalletID
                    ' Me.RefreshDeviceList(iPalletID)
                Else
                    Me.lblBoxName.Text = dt.Rows(0)("Pallett_Name") : Me.lblBoxName.Tag = dt.Rows(0)("Pallett_ID")
                    ' Me.RefreshDeviceList(dt.Rows(0)("Pallett_ID"))
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ProcessWorkorderForNonRepaired(ByVal iWOID As Integer, ByVal iPalletID As Integer)
            Dim dt As DataTable
            Dim strPalletName As String = ""

            Try
                dt = Me._objShip.GetWorkorderInfo(iWOID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Work order/Claim# is missing.")
                Else
                    Me.lblRMACount.Text = dt.Rows(0)("WO_RAQnty") ' & Me.cboRMANo.SelectedValue)(0)("WO_RAQnty")
                    Me.lblRMANo.Tag = iWOID
                    Me.lblRMANo.Text = dt.Rows(0)("WO_CustWo")
                    Me.lblShippedCount.Text = Me._objShip.GetShippedCountByWO(iWOID)

                    strPalletName = Me._objShip.GetPalletName(iPalletID)
                    If strPalletName.Trim.Length > 0 Then
                        Me.lblBoxName.Text = strPalletName.Trim : Me.lblBoxName.Tag = iPalletID
                    Else
                        Throw New Exception("Sub ProcessWorkorderForNonRepaired: No pallet name found. Please contact IT.")
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function IsDeviceHasRequiredServiceBillcode(ByVal iDeviceID As Integer) As Boolean
            Dim j As Integer
            Dim booHasRequiredBillingService As Boolean = False
            Dim strReqServiceBillcodes As String = ""
            Dim dtBilledBillCode As DataTable

            Try
                dtBilledBillCode = PSS.Data.Buisness.DeviceBilling.GetBilledData(iDeviceID)

                booHasRequiredBillingService = IsDeviceHasMainService(dtBilledBillCode) 'TMISharedFunc.IsDeviceHasMainService(dtBilledBillCode)

                If booHasRequiredBillingService = False Then
                    For j = 0 To TMISharedFunc._strRequiredBillcodes.Length - 1
                        If strReqServiceBillcodes.Trim.Length > 0 Then strReqServiceBillcodes &= vbCrLf
                        strReqServiceBillcodes &= TMISharedFunc._strRequiredBillcodes(j)
                    Next j

                    MessageBox.Show("Please bill one of the following services:" & vbCrLf & strReqServiceBillcodes, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

                Return booHasRequiredBillingService
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtBilledBillCode)
            End Try
        End Function

        '*************************************************************************************************************
        Private Sub RefreshDeviceList(ByVal iPallet_ID As Integer, ByVal iDeviceID As Integer)
            Dim dt1 As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                If iPallet_ID > 0 Then
                    Me.lblBoxCount.Text = "0" : Me.lstDevices.DataSource = Nothing : Me.lstDevices.Items.Clear() : Me.lstDevices.Refresh()

                    'objMisc = New PSS.Data.Buisness.Misc()
                    Me._objNIShip = New NIRecShip()
                    dt1 = Me._objNIShip.GetAllSNsForPallet(iPallet_ID, iDeviceID)    'objMisc.GetAllSNsForPallet(iPallet_ID)
                    Me.lstDevices.DataSource = dt1.DefaultView
                    Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
                    Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString

                    Me.lblBoxCount.Text = Me.lstDevices.Items.Count
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
                objMisc = Nothing
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function IsDeviceHasMainService(ByVal dtBilledBillCode As DataTable) As Boolean
            Dim booReturnVal As Boolean = False
            Dim i As Integer
            Dim strReqBillCodes() As String

            Try
                _objNI = New NI()
                strReqBillCodes = _objNI._strRequiredBillcodes
                For i = 0 To strReqBillCodes.Length - 1
                    If dtBilledBillCode.Select("Billcode_Desc = '" & strReqBillCodes(i) & "'").Length > 0 Then
                        booReturnVal = True : Exit For
                    End If
                Next i

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dtBilledBillCode)
            End Try
        End Function

        '*************************************************************************************************************
        Private Sub btnCloseAndShipBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAndShipBox.Click
            Dim i As Integer = 0, j As Integer = 0
            Dim dt As DataTable, dt2 As DataTable, dt3 As DataTable
            Dim strRepairLetterName As String = ""
            Dim iWOID As Integer
            Dim iWeight As Integer, iCarrierID As Integer, iFreightRate As Double
            Dim isSuccessfullyClosed As Boolean = False

            Try
                If Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf Me._isRepairThisUnit = True AndAlso MessageBox.Show("Are you sure you want to close and ship this RMA", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                ElseIf Not Me.lstDevices.Items.Count = 1 Then 'One device one box for NI
                    MessageBox.Show("No device in the device listbox.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf Me.cboCarrier.SelectedValue = 0 AndAlso Me._isRepairThisUnit = True Then
                    MessageBox.Show("Please select ship carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtTrackNo.Text.Trim.Length = 0 AndAlso Me._isRepairThisUnit = True Then
                    MessageBox.Show("Please enter tracking #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lblRMANo.Tag.ToString.Trim.Length = 0 OrElse Convert.ToInt32(Me.lblRMANo.Tag) = 0 Then
                    MessageBox.Show("RMA is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Box ID is missing for this RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf IsNothing(Me.lstDevices.DataSource) OrElse Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("RMA is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Box ID is missing. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    'Get Pallet Data now
                    dt = Me._objNIShip.NIGetPalletData(Me.lblBoxName.Text.Trim, PSS.Data.Buisness.NI.CUSTOMERID)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("This box " & Me.lblBoxName.Text & " is not in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Multiple boxes existed. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows(0)("Pallett_ID").ToString <> Me.lblBoxName.Tag.ToString Then
                        MessageBox.Show("Box name and ID does not match. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf Me._objNIShip.IsDeviceShipped(CType(Me.lstDevices.SelectedValue, Integer), dt.Rows(0)("Pallett_ID"), Me._isRepairThisUnit) = True Then
                        MessageBox.Show("This box has already shipped. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Dim iRcvdQty As Integer = Generic.GetRecQty(Convert.ToInt32(Me.lblRMANo.Tag))
                        If Me._isRepairThisUnit = True AndAlso iRcvdQty <> Me.lstDevices.Items.Count Then
                            MessageBox.Show("Can't ship partial RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        'ZF Disable: Dim strNextStation As String = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, NI.CUSTOMERID, , )
                        'Add this tentively
                        Dim strNextStation As String = "IN-TRANSIT"
                        Dim strDateReceived As String = CDate(Generic.MySQLServerDateTime(i)).ToString("yyyy-MM-dd")

                        iWOID = Convert.ToInt32(Me.lblRMANo.Tag)
                        'iCarrierID = Me.cboCarrier.SelectedValue
                        If Me._isRepairThisUnit = True Then '  'Close it and print shipping label, ship to end user
                            iCarrierID = Me.cboCarrier.SelectedValue
                            i = Me._objNIShip.CloseAndShipBox(CInt(Me.lblBoxName.Tag), Convert.ToInt32(Me.lblRMANo.Tag), _
                                                            PSS.Core.ApplicationUser.IDShift, Me.lstDevices.Items.Count, _
                                                            strNextStation, Me._objShip, iCarrierID, _
                                                            Me.txtTrackNo.Text.Trim, True)

                            If i = 0 Then
                                MessageBox.Show("System has failed to ship (end user).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Else
                                If Me.chkPrint.Checked Then
                                    Me._objNIShip.PrintShippingBoxLabel(Me.lstDevices.SelectedValue, Me.lblCosmeticGrade.Text, 1)
                                End If
                                isSuccessfullyClosed = True
                            End If
                        ElseIf Me._isRefurb = True Then ''Close it, ship to warehouse, and print shipping label
                            iCarrierID = 0
                            i = Me._objNIShip.CloseAndShipBox_Refurb(CInt(Me.lblBoxName.Tag), Convert.ToInt32(Me.lblRMANo.Tag), _
                                                              Me.lstDevices.SelectedValue, _
                                                            PSS.Core.ApplicationUser.IDShift, Me.lstDevices.Items.Count, _
                                                            strNextStation, Me._objShip, iCarrierID, _
                                                            "Shipped to Warehouse", False)

                            dt2 = Me._objNIShip.NIModelData4DeviceID(Me.lstDevices.SelectedValue) 'Device_SN, model_desc,model_ID, device_DateShip
                            dt3 = Me._objNIShip.NICosmeticCodeData4Grade(Me.lblCosmeticGrade.Text) 'DCode_ID,DCode_SDesc,DCode_Ldesc,DCode_L2Desc 
                            Dim dSN As String = dt2.Rows(0).Item("Device_SN")
                            Dim mID As Integer = dt2.Rows(0).Item("model_ID")
                            Dim dCodeID As Integer = dt3.Rows(0).Item("DCode_ID")

                            Me._objNIRec = New NIRec()
                            j = Me._objNIRec.ReceiveDeviceIntoWH(Me._objNI.CUSTOMERID, Me._objNI.LOCID, Convert.ToInt32(Me.lblRMANo.Tag), Me.lblRMANo.Text, _
                                                                 dSN, Me._objNI.RefurbDevConditionID, dCodeID, mID, 0, 0, PSS.Core.ApplicationUser.IDuser, _
                                                                 False, "", strDateReceived)

                            If i = 0 Or j = 0 Then
                                MessageBox.Show("System has failed to ship (refurbish).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Else
                                If Me.chkPrint.Checked Then
                                    Me._objNIShip.PrintShippingBoxLabel(Me.lstDevices.SelectedValue, Me.lblCosmeticGrade.Text, 1)
                                End If
                                isSuccessfullyClosed = True
                            End If

                        ElseIf Me._isScrap = True Then 'Simply close it
                            iCarrierID = 0
                            i = Me._objNIShip.CloseAndShipBox_Refurb(CInt(Me.lblBoxName.Tag), Convert.ToInt32(Me.lblRMANo.Tag), _
                                                              Me.lstDevices.SelectedValue, _
                                                            PSS.Core.ApplicationUser.IDShift, Me.lstDevices.Items.Count, _
                                                            strNextStation, Me._objShip, iCarrierID, _
                                                            "Shipped to Warehouse", False)

                            If i = 0 Or j = 0 Then
                                MessageBox.Show("System has failed to ship (scrap).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Else
                                'No need label: Me._objNIShip.PrintShippingBoxLabel(Me.lstDevices.SelectedValue, Me.lblCosmeticGrade.Text, 1)
                                isSuccessfullyClosed = True
                            End If
                        End If

                        If isSuccessfullyClosed Then
                            Me.lblRMANo.Text = "" : Me.lblRMANo.Tag = 0 : Me.lblRMACount.Text = "0"
                            Me.lblBoxName.Text = "" : Me.lblBoxName.Tag = "0"
                            Me.txtDevSN.Text = "" : Me.lblBoxCount.Text = "0"
                            Me.lblCosmeticGrade.Text = "" : Me.lblRepairType.Text = ""
                            Me.lstDevices.DataSource = Nothing : Me.lstDevices.Items.Clear() : Me.lstDevices.Refresh()
                            Me.txtTrackNo.Text = "" : Me.txtFreightage.Text = 0 : Me.txtWeight.Text = ""
                            Me.Enabled = True : Cursor.Current = Cursors.Default : Me.txtDevSN.Focus()
                        End If

                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseAndShipBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnReprintManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintManifest.Click
            Dim strSN As String = ""
            ' Dim dtPallettInfo As DataTable, dt2 As DataTable
                Dim objMisc As PSS.Data.Buisness.Misc
                Dim strRepairLetterName As String = ""
                Dim iPalletID As Integer = 0
                Dim dt, dt2 As DataTable
                Dim strCosmetic As String = ""

                Try

                    strSN = InputBox("Enter NI Device SN:", "Serial Name").Trim
                    If strSN = "" Then
                        Exit Sub
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                        dt = Me._objNIShip.getNIDevice_BySN(Me._objNI.LOCID, strSN)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Can't find this device.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Duplicated device.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        ElseIf dt.Rows(0).IsNull("Device_DateShip") OrElse Trim(dt.Rows(0).Item("Device_DateShip")).Length = 0 Then
                            MessageBox.Show("Device is not shipped (tDevice).", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else
                            dt2 = Me._objNIShip.getWarehouseRepairedData(Me._objNI.CUSTOMERID, strSN)
                            If dt2.Rows.Count = 0 Then
                                MessageBox.Show("Can't find this repaired device in warehouse. See IT.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Else
                                strCosmetic = Me._objNIShip.NICosmeticGrade4DeviceID(dt.Rows(0).Item("Device_ID"))

                                Me._objNIShip.PrintShippingBoxLabel(dt.Rows(0).Item("Device_ID"), strCosmetic, 1)
                            End If
                        End If
                    End If

                    'If strPalletName = "" Then
                    '    Exit Sub
                    'Else
                    'objMisc = New PSS.Data.Buisness.Misc()
                    'dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(strPalletName)
                    'If dtPallettInfo.Rows.Count = 0 Then
                    '    MessageBox.Show("Box Name was not defined in system.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    'ElseIf dtPallettInfo.Rows.Count > 1 Then
                    '    MessageBox.Show("Box Name existed twice in the system.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    'ElseIf Convert.ToInt32(dtPallettInfo.Rows(0)("Cust_ID")) <> TMI.CUSTOMERID Then
                    '    MessageBox.Show("Box Name does not belong to TMI.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    'ElseIf IsDBNull(dtPallettInfo.Rows(0)("Pallett_ShipDate")) Then
                    '    MessageBox.Show("Box Name has not shipped.", "Reprint Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    'Else

                    'Me._objTMIShip.PrintManifestLabel(Convert.ToInt32(dtPallettInfo.Rows(0)("Pallett_ID")))

                    'Print Repair Letter-----------------------------------------------------------------------------------
                    'dt2 = Me._objTMIShip.GetDataTableForPrintRepairLetter(CInt(Me.lblBoxName.Tag))
                    'If dt2.Rows.Count = 1 Then
                    '    If dt2.Rows(0).Item("TMIServiceClient") = "CenturyLink" Then
                    '        strRepairLetterName = "TMI Shipping Letter CTL Push.rpt"
                    '        Me._objTMIShip.PrintTMIRepairLetter(strRepairLetterName)
                    '    ElseIf dt2.Rows(0).Item("TMIServiceClient") = "Windstream" Then
                    '        strRepairLetterName = "TMI Shipping Letter WS Push.rpt"
                    '        Me._objTMIShip.PrintTMIRepairLetter(strRepairLetterName)
                    '    Else
                    '        MessageBox.Show("Failed to print. TMIServiceClient is nothing or incorrect. Please see IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    '    End If
                    'Else
                    '    MessageBox.Show("Failed to print. Duplicates or no records. Please see IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    'End If
                    'End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "btnReprintManifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Finally
                    objMisc = Nothing ': Generic.DisposeDT(dtPallettInfo)
                    dt = Nothing
                    Me.Enabled = True : Cursor.Current = Cursors.Default
                End Try
        End Sub


        Private Sub chkPrint_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkPrint.CheckedChanged
            If chkPrint.Checked Then
                Me.chkPrint.Text = "Print Label"
            Else
                Me.chkPrint.Text = "No Label Print"
            End If
        End Sub
    End Class

End Namespace

