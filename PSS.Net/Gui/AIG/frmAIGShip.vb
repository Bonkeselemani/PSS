Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmAIGShip
        Inherits System.Windows.Forms.Form
        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private _iLocID As Integer = 0
        Private _objShip As PSS.Data.Production.Shipping
        Private _objAIGProduceShip As PSS.Data.Buisness.AIGProduceShip
        Private _objAIG As PSS.Data.Buisness.AIG
        Private _objTMIShip As PSS.Data.Buisness.TMIRecShip

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCustID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strScreenName
            _objShip = New PSS.Data.Production.Shipping()
            _objAIGProduceShip = New PSS.Data.Buisness.AIGProduceShip()
            _objAIG = New PSS.Data.Buisness.AIG()
            _objTMIShip = New PSS.Data.Buisness.TMIRecShip()

            _iMenuCustID = iCustID
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
        Friend WithEvents txtFreightage As System.Windows.Forms.TextBox
        Friend WithEvents txtWeight As System.Windows.Forms.TextBox
        Friend WithEvents Label20 As System.Windows.Forms.Label
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents lblInTrackNo As System.Windows.Forms.Label
        Friend WithEvents txtTrackNo As System.Windows.Forms.TextBox
        Friend WithEvents cboCarrier As C1.Win.C1List.C1Combo
        Friend WithEvents lblCarrier As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblRMANo As System.Windows.Forms.Label
        Friend WithEvents lblShippedCount As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents lblBoxCount As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseAndShipBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblRMACount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblExpectedShipDate As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtNotes As System.Windows.Forms.TextBox
        Friend WithEvents chkPrintServiceLetter As System.Windows.Forms.CheckBox
        Friend WithEvents btnReprintServiceWOLetter As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAIGShip))
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.chkPrintServiceLetter = New System.Windows.Forms.CheckBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtNotes = New System.Windows.Forms.TextBox()
            Me.lblExpectedShipDate = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtFreightage = New System.Windows.Forms.TextBox()
            Me.txtWeight = New System.Windows.Forms.TextBox()
            Me.Label20 = New System.Windows.Forms.Label()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.lblInTrackNo = New System.Windows.Forms.Label()
            Me.txtTrackNo = New System.Windows.Forms.TextBox()
            Me.cboCarrier = New C1.Win.C1List.C1Combo()
            Me.lblCarrier = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblRMANo = New System.Windows.Forms.Label()
            Me.lblShippedCount = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.btnReprintServiceWOLetter = New System.Windows.Forms.Button()
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
            Me.panelPallet.SuspendLayout()
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SlateGray
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkPrintServiceLetter, Me.Label6, Me.txtNotes, Me.lblExpectedShipDate, Me.Label7, Me.txtFreightage, Me.txtWeight, Me.Label20, Me.Label18, Me.lblInTrackNo, Me.txtTrackNo, Me.cboCarrier, Me.lblCarrier, Me.btnClear, Me.Label4, Me.Label1, Me.lblRMANo, Me.lblShippedCount, Me.Label5, Me.btnReprintServiceWOLetter, Me.lblBoxName, Me.lblBoxCount, Me.Label2, Me.txtDevSN, Me.Label10, Me.btnCloseAndShipBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblRMACount, Me.Label3})
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(656, 440)
            Me.panelPallet.TabIndex = 124
            '
            'chkPrintServiceLetter
            '
            Me.chkPrintServiceLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintServiceLetter.ForeColor = System.Drawing.Color.Yellow
            Me.chkPrintServiceLetter.Location = New System.Drawing.Point(320, 344)
            Me.chkPrintServiceLetter.Name = "chkPrintServiceLetter"
            Me.chkPrintServiceLetter.Size = New System.Drawing.Size(168, 24)
            Me.chkPrintServiceLetter.TabIndex = 224
            Me.chkPrintServiceLetter.Text = "Print Service WO Letter"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(11, 344)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(157, 16)
            Me.Label6.TabIndex = 223
            Me.Label6.Text = "Notes:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtNotes
            '
            Me.txtNotes.Location = New System.Drawing.Point(11, 360)
            Me.txtNotes.Multiline = True
            Me.txtNotes.Name = "txtNotes"
            Me.txtNotes.Size = New System.Drawing.Size(285, 72)
            Me.txtNotes.TabIndex = 222
            Me.txtNotes.Text = ""
            '
            'lblExpectedShipDate
            '
            Me.lblExpectedShipDate.BackColor = System.Drawing.Color.Black
            Me.lblExpectedShipDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblExpectedShipDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblExpectedShipDate.ForeColor = System.Drawing.Color.Lime
            Me.lblExpectedShipDate.Location = New System.Drawing.Point(448, 147)
            Me.lblExpectedShipDate.Name = "lblExpectedShipDate"
            Me.lblExpectedShipDate.Size = New System.Drawing.Size(192, 32)
            Me.lblExpectedShipDate.TabIndex = 221
            Me.lblExpectedShipDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(448, 131)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(152, 16)
            Me.Label7.TabIndex = 220
            Me.Label7.Text = "Expected Ship Date"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtFreightage
            '
            Me.txtFreightage.BackColor = System.Drawing.SystemColors.InactiveCaptionText
            Me.txtFreightage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFreightage.Enabled = False
            Me.txtFreightage.Location = New System.Drawing.Point(580, 312)
            Me.txtFreightage.Name = "txtFreightage"
            Me.txtFreightage.Size = New System.Drawing.Size(50, 20)
            Me.txtFreightage.TabIndex = 219
            Me.txtFreightage.Text = "0"
            Me.txtFreightage.Visible = False
            '
            'txtWeight
            '
            Me.txtWeight.Location = New System.Drawing.Point(416, 312)
            Me.txtWeight.Name = "txtWeight"
            Me.txtWeight.Size = New System.Drawing.Size(40, 20)
            Me.txtWeight.TabIndex = 218
            Me.txtWeight.Text = ""
            Me.txtWeight.Visible = False
            '
            'Label20
            '
            Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label20.ForeColor = System.Drawing.Color.White
            Me.Label20.Location = New System.Drawing.Point(464, 312)
            Me.Label20.Name = "Label20"
            Me.Label20.Size = New System.Drawing.Size(112, 16)
            Me.Label20.TabIndex = 217
            Me.Label20.Text = "Cal. Freightage($):"
            Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label20.Visible = False
            '
            'Label18
            '
            Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label18.ForeColor = System.Drawing.Color.White
            Me.Label18.Location = New System.Drawing.Point(318, 312)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(96, 16)
            Me.Label18.TabIndex = 216
            Me.Label18.Text = "Box Weight (lb) :"
            Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label18.Visible = False
            '
            'lblInTrackNo
            '
            Me.lblInTrackNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInTrackNo.ForeColor = System.Drawing.Color.White
            Me.lblInTrackNo.Location = New System.Drawing.Point(320, 272)
            Me.lblInTrackNo.Name = "lblInTrackNo"
            Me.lblInTrackNo.Size = New System.Drawing.Size(208, 16)
            Me.lblInTrackNo.TabIndex = 114
            Me.lblInTrackNo.Text = "Track No:"
            Me.lblInTrackNo.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtTrackNo
            '
            Me.txtTrackNo.BackColor = System.Drawing.Color.White
            Me.txtTrackNo.Location = New System.Drawing.Point(320, 288)
            Me.txtTrackNo.Name = "txtTrackNo"
            Me.txtTrackNo.Size = New System.Drawing.Size(312, 20)
            Me.txtTrackNo.TabIndex = 113
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
            Me.cboCarrier.Location = New System.Drawing.Point(320, 240)
            Me.cboCarrier.MatchEntryTimeout = CType(2000, Long)
            Me.cboCarrier.MaxDropDownItems = CType(10, Short)
            Me.cboCarrier.MaxLength = 32767
            Me.cboCarrier.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCarrier.Name = "cboCarrier"
            Me.cboCarrier.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCarrier.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCarrier.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCarrier.Size = New System.Drawing.Size(312, 21)
            Me.cboCarrier.TabIndex = 112
            Me.cboCarrier.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblCarrier
            '
            Me.lblCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCarrier.ForeColor = System.Drawing.Color.White
            Me.lblCarrier.Location = New System.Drawing.Point(320, 224)
            Me.lblCarrier.Name = "lblCarrier"
            Me.lblCarrier.Size = New System.Drawing.Size(208, 16)
            Me.lblCarrier.TabIndex = 111
            Me.lblCarrier.Text = "Shipment Carrier:"
            Me.lblCarrier.TextAlign = System.Drawing.ContentAlignment.BottomLeft
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
            'btnReprintServiceWOLetter
            '
            Me.btnReprintServiceWOLetter.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnReprintServiceWOLetter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintServiceWOLetter.ForeColor = System.Drawing.Color.White
            Me.btnReprintServiceWOLetter.Location = New System.Drawing.Point(496, 368)
            Me.btnReprintServiceWOLetter.Name = "btnReprintServiceWOLetter"
            Me.btnReprintServiceWOLetter.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReprintServiceWOLetter.Size = New System.Drawing.Size(136, 32)
            Me.btnReprintServiceWOLetter.TabIndex = 104
            Me.btnReprintServiceWOLetter.Text = "Reprint Repair Letter"
            Me.btnReprintServiceWOLetter.Visible = False
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
            Me.btnCloseAndShipBox.Location = New System.Drawing.Point(320, 368)
            Me.btnCloseAndShipBox.Name = "btnCloseAndShipBox"
            Me.btnCloseAndShipBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseAndShipBox.Size = New System.Drawing.Size(144, 32)
            Me.btnCloseAndShipBox.TabIndex = 4
            Me.btnCloseAndShipBox.Text = "Close && Ship Box"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(488, 184)
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
            Me.btnRemoveSN.Location = New System.Drawing.Point(320, 184)
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
            Me.lstDevices.Size = New System.Drawing.Size(285, 238)
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
            'frmAIGShip
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SlateGray
            Me.ClientSize = New System.Drawing.Size(664, 446)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.panelPallet})
            Me.Name = "frmAIGShip"
            Me.Text = "frmAIGShip"
            Me.panelPallet.ResumeLayout(False)
            CType(Me.cboCarrier, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmAIGShip_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dtLoc As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                Me.chkPrintServiceLetter.Checked = True
                Me.btnReprintServiceWOLetter.Visible = True

                PopulateShipmentCarrier()
                _iLocID = Generic.GetLocID(Me._iMenuCustID)

                Me.txtDevSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmAIGShip_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            End Try
        End Sub

        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Dim dt, dtApprovedData As DataTable
            Dim iPalletID, iMaxBillRule As Integer
            Dim booNewScan, booQuoteReject As Boolean
            Dim objNewTech As New PSS.Data.Buisness.NewTech()
            Dim strExpectedShiPDate As String = ""

            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDevSN.Text.Trim.Length = 0 Then
                        Exit Sub
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        dt = Generic.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, Me._iMenuCustID, Me._objAIG.LOCID, True)
                        Me.Enabled = True : Cursor.Current = Cursors.Default

                        booNewScan = False : booQuoteReject = False
                        If Me._iLocID = 0 Then
                            MessageBox.Show("Location ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf dt.Rows.Count = 0 Then
                            MessageBox.Show("Device does not exist in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Device existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf IsDBNull(dt.Rows(0)("Device_DateBill")) Then
                            MessageBox.Show("This device has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf Me.lblRMANo.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) <> dt.Rows(0)("WO_ID") Then
                            MessageBox.Show("This device does not belong to above work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt32(dt.Rows(0)("Pallett_ID")) > 0 AndAlso Me.lblBoxName.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) <> dt.Rows(0)("Pallett_ID") Then
                            MessageBox.Show("Device is assigned to box ID " & dt.Rows(0)("Pallett_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                        Else
                            'New scan
                            If Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 Then
                                Me.ProcessWorkorder(dt.Rows(0)("WO_ID")) : booNewScan = True
                            End If

                            If Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 OrElse Me.lblRMANo.Tag.ToString.Trim.Length = 0 OrElse Me.lblBoxName.Tag.ToString.Trim.Length = 0 OrElse Convert.ToInt32(Me.lblRMANo.Tag) = 0 OrElse Convert.ToInt32(Me.lblBoxName.Tag) = 0 Then
                                MessageBox.Show("System has failed to process work order. Please re-enter S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Me.lblRMANo.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) > 0 AndAlso Convert.ToInt32(Me.lblRMANo.Tag) <> dt.Rows(0)("WO_ID") Then
                                MessageBox.Show("This device does not belong to above work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ID")) AndAlso Convert.ToInt32(dt.Rows(0)("Pallett_ID")) > 0 AndAlso Me.lblBoxName.Tag.ToString.Trim.Length > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) > 0 AndAlso Convert.ToInt32(Me.lblBoxName.Tag) <> dt.Rows(0)("Pallett_ID") Then
                                MessageBox.Show("This device is assigned to box ID " & dt.Rows(0)("Pallett_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Me._objAIGProduceShip.IsDeviceHasServiceBillcode(Convert.ToInt32(dt.Rows(0)("Device_ID"))) = False Then
                                MessageBox.Show("Must select at least one service code in tech billing screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf Me._objAIGProduceShip.IsDeviceHasTechCompletedRecord(Convert.ToInt32(dt.Rows(0)("Device_ID"))) = False Then
                                MessageBox.Show("Please complete repair with work performance in tech screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                            ElseIf objNewTech.GetTechNotesString(Convert.ToInt32(dt.Rows(0)("Device_ID")), Me._iMenuCustID).Trim.Length = 0 Then
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

                                'Check SN Discrepancy: if rejected, only service charge = BillCode_Desc "Cancel" BillCode_ID=2557
                                If Not Me._objAIGProduceShip.IsCorrectChargeForRejectedSNDiscrepancyDevice(Convert.ToInt32(dt.Rows(0)("Device_ID")), Me._objAIG.iCancelBillcode) Then
                                    MessageBox.Show("Non-approved (rejected) SN discrepancy device, but not charged correctly. Can't ship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                End If

                                '*****************************************************
                                'Check QC
                                '*****************************************************
                                If iMaxBillRule <> 1 AndAlso iMaxBillRule <> 2 AndAlso booQuoteReject = False Then
                                    Try
                                        If Generic.IsValidQCResults(dt.Rows(0)("Device_ID"), 5, "OBA", False, True) = False Then
                                            Exit Sub : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                                        End If
                                    Catch ex As Exception
                                        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                        Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                    End Try
                                End If
                                '*****************************************************************
                                'Simply check PSSWrty and Quote Approval again even though OBA checked them
                                '*****************************************************************
                                dtApprovedData = Me._objAIG.GetApprovedData(dt.Rows(0)("Device_ID"))
                                If dtApprovedData.Rows.Count = 0 Then
                                    MessageBox.Show("Cellopt data is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                ElseIf dtApprovedData.Rows.Count > 1 Then
                                    MessageBox.Show("Duplicate record in cellopt data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                ElseIf Convert.ToInt32(dt.Rows(0)("Cellopt_WIPOwner")) = 6 Then
                                    MessageBox.Show("Device is on hold for approval.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                End If
                                If Me._objAIG.NeedExceptionRepairsApproval(dt.Rows(0)("Device_ID"), Me._iMenuCustID) AndAlso IsDBNull("EstimatedPartCost_Date") Then
                                    MessageBox.Show("Quote is not approved!", "Quote validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                End If
                                If dt.Rows(0).Item("Device_PSSWrty") = 1 AndAlso IsDBNull(dtApprovedData.Rows(0).Item("PSS_Wrty_Approval_DT")) Then
                                    MessageBox.Show("PSS Warranty is not approved!", "PSS Wrty Approval Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                                End If
                                '*****************************************************************

                                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                                'Expected Ship Date
                                strExpectedShiPDate = Me._objAIG.GetExpectedShipDate(0, dt.Rows(0)("Device_ID"), True)
                                Me.lblExpectedShipDate.Text = Convert.ToDateTime(strExpectedShiPDate).ToString("MM/dd/yyyy")
                                'Notes 
                                Me.txtNotes.Text = Me._objAIG.GetReceivingNotes(dt.Rows(0)("WO_ID"))

                                iPalletID = CInt(Me.lblBoxName.Tag)
                                If iPalletID = 0 Then
                                    Throw New Exception("System has failed to create box.")
                                ElseIf Generic.IsPalletClosed(iPalletID) = True Then
                                    MsgBox("Box had been closed by another machine. Please refresh your screen.", MsgBoxStyle.Information, "Device Scan")
                                Else
                                    PSS.Data.Production.Shipping.AssignDeviceToPallet(dt.Rows(0)("Device_ID"), iPalletID)
                                    RefreshDeviceList(iPalletID) : Me.txtDevSN.Text = "" : Me.Enabled = True : Me.txtDevSN.Focus()
                                End If 'check pallet status
                            End If 'check device's order and pallett
                        End If 'check device data
                        End If  'check user input
                End If 'enter key
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
                Me.Enabled = True : Cursor.Current = Cursors.Default
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
                    iPalletID = Me._objAIGProduceShip.CreateBoxID(Me._iMenuCustID, Me._iLocID, iWOID)
                    If iPalletID = 0 Then Throw New Exception("System has failed to create box.")
                    Me.lblBoxName.Text = Me._objShip.GetPalletName(iPalletID) : Me.lblBoxName.Tag = iPalletID
                    Me.RefreshDeviceList(iPalletID)
                Else
                    Me.lblBoxName.Text = dt.Rows(0)("Pallett_Name") : Me.lblBoxName.Tag = dt.Rows(0)("Pallett_ID")
                    Me.RefreshDeviceList(dt.Rows(0)("Pallett_ID"))
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub RefreshDeviceList(ByVal iPallet_ID As Integer)
            Dim dt1 As DataTable
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                If iPallet_ID > 0 Then
                    Me.lblBoxCount.Text = "0" : Me.lstDevices.DataSource = Nothing : Me.lstDevices.Items.Clear() : Me.lstDevices.Refresh()

                    objMisc = New PSS.Data.Buisness.Misc()
                    dt1 = objMisc.GetAllSNsForPallet(iPallet_ID)
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
        Private Function IsDeviceHasRequiredServiceBillcode(ByVal iDeviceID As Integer) As Boolean
            Dim j As Integer
            Dim booHasRequiredBillingService As Boolean = False
            Dim strReqServiceBillcodes As String = ""
            Dim dtBilledBillCode As DataTable

            Try
                dtBilledBillCode = PSS.Data.Buisness.DeviceBilling.GetBilledData(iDeviceID)
                booHasRequiredBillingService = Me._objAIGProduceShip.IsDeviceHasMainService(dtBilledBillCode)

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

        Private Sub btnCloseAndShipBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAndShipBox.Click
            Dim i As Integer = 0
            Dim dt As DataTable, dt2 As DataTable
            Dim strRepairLetterName, strWorkstation As String
            Dim iWOID As Integer
            Dim iWeight As Integer, iCarrierID As Integer, iFreightRate As Double

            Try
                If Me.lblRMANo.Text.Trim.Length = 0 OrElse Me.lblBoxName.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf MessageBox.Show("Are you sure you want to close and ship this RMA", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                ElseIf Me.cboCarrier.SelectedValue = 0 Then
                    MessageBox.Show("Please select ship carrier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtTrackNo.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter tracking #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lblRMANo.Tag.ToString.Trim.Length = 0 OrElse Convert.ToInt32(Me.lblRMANo.Tag) = 0 Then
                    MessageBox.Show("RMA is not defined.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Box ID is missing for this RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf IsNothing(Me.lstDevices.DataSource) OrElse Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("RMA is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf CInt(Me.lblBoxName.Tag) = 0 Then
                    MessageBox.Show("Box ID is missing. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me._iLocID = 0 Then
                    MessageBox.Show("Location ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dt = Me._objShip.GetPalletInfoByName(Me.lblBoxName.Text.Trim, Me._iMenuCustID)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("This box " & Me.lblBoxName.Text & " is not in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Multiple boxes existed. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows(0)("Pallett_ID").ToString <> Me.lblBoxName.Tag.ToString Then
                        MessageBox.Show("Box name and ID does not match. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf dt.Rows(0)("Pallett_ID") = 1 Then
                        MessageBox.Show("This box has already close. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) AndAlso dt.Rows(0)("Pallett_ShipDate").ToString.Trim.Length > 0 Then
                        MessageBox.Show("This box has already shipped. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Else
                        Dim iRcvdQty As Integer = Generic.GetRecQty(Convert.ToInt32(Me.lblRMANo.Tag))
                        If iRcvdQty <> Me.lstDevices.Items.Count Then
                            MessageBox.Show("Can't ship partial RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        strWorkstation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, , )
                        If strWorkstation.Trim.Length = 0 Then
                            MessageBox.Show("Workstation is missing in workflow.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        iWOID = Convert.ToInt32(Me.lblRMANo.Tag)
                        iCarrierID = Me.cboCarrier.SelectedValue
                        'iWeight = Me.txtWeight.Text
                        'iFreightRate = (1 + Me._objTMIShip._PSSI_ShippingMargin) * Convert.ToDouble(Me.txtFreightage.Text)  'Actual Freightage + the PSSI margin
                        'iFreightRate = Math.Round(iFreightRate, 2)

                        i = Me._objTMIShip.CloseAndShipBox(CInt(Me.lblBoxName.Tag), Convert.ToInt32(Me.lblRMANo.Tag), _
                                                           PSS.Core.ApplicationUser.IDShift, Me.lstDevices.Items.Count, _
                                                           strWorkstation, Me._objShip, Me.cboCarrier.SelectedValue, _
                                                           Me.txtTrackNo.Text.Trim)
                        'i = Me._objTMIShip.CloseAndShipBox(CInt(Me.lblBoxName.Tag), iWOID, _
                        '                                   PSS.Core.ApplicationUser.IDShift, Me.lstDevices.Items.Count, _
                        '                                   strNextStation, Me._objShip, iCarrierID, _
                        '                                   Me.txtTrackNo.Text.Trim, iWeight, iFreightRate)

                        If i = 0 Then
                            MessageBox.Show("System has failed to ship.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Else

                            'Me._objTMIShip.PrintManifestLabel(CInt(Me.lblBoxName.Tag)) 'disabled this, requested by Sabir

                            'Print Repair Letter-----------------------------------------------------------------------------------
                            If Me.chkPrintServiceLetter.Checked Then
                                Dim dtDevcies As DataTable, iDevice_ID As Integer = 0, row As DataRow
                                dtDevcies = Me._objAIGProduceShip.GetDevicesByPallettID(CInt(Me.lblBoxName.Tag))
                                For Each row In dtDevcies.Rows 'AIG has one row usually
                                    Me.PrintServiceWOLetter(CInt(row("Device_ID")))
                                Next
                            End If

                            'Clear
                            Me.lblRMANo.Text = "" : Me.lblRMANo.Tag = 0 : Me.lblRMACount.Text = "0"
                            Me.lblBoxName.Text = "" : Me.lblBoxName.Tag = "0" : Me.txtNotes.Text = ""
                            Me.txtDevSN.Text = "" : Me.lblBoxCount.Text = "0"
                            Me.lstDevices.DataSource = Nothing : Me.lstDevices.Items.Clear() : Me.lstDevices.Refresh()
                            Me.txtTrackNo.Text = "" : Me.txtFreightage.Text = 0 : Me.txtWeight.Text = ""
                            Me.lblExpectedShipDate.Text = ""
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

        Private Sub btnReprintServiceWOLetter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintServiceWOLetter.Click
            Dim iDevice_ID As Integer = 0
            Dim strPalletName As String = ""
            Dim dtPallettInfo, dtDevcies As DataTable, row As DataRow
            Dim objMisc As PSS.Data.Buisness.Misc

            Try
                strPalletName = InputBox("Enter Pallet Name:", "Enter Pallet")
                If Not strPalletName.Trim.Length > 0 Then Exit Sub

                objMisc = New PSS.Data.Buisness.Misc()
                dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(strPalletName)
                If dtPallettInfo.Rows.Count = 0 Then
                    MessageBox.Show("Box Name was not defined in system.", "Reprint", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf dtPallettInfo.Rows.Count > 1 Then
                    MessageBox.Show("Box Name existed twice in the system.", "Reprint", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Convert.ToInt32(dtPallettInfo.Rows(0)("Cust_ID")) <> Me._iMenuCustID Then
                    MessageBox.Show("Box Name does not belong to TMI.", "Reprint", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf IsDBNull(dtPallettInfo.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Box Name has not shipped.", "Reprint", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    dtDevcies = Me._objAIGProduceShip.GetDevicesByPallettID(dtPallettInfo.Rows(0).Item("Pallett_ID"))
                    If dtDevcies.Rows.Count Then
                        For Each row In dtDevcies.Rows 'AIG has one row usually
                            Me.PrintServiceWOLetter(CInt(row("Device_ID")))
                        Next
                        PrintServiceWOLetter(iDevice_ID)
                    Else
                        MessageBox.Show("Can't find it.", "Reprint", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PrintServiceWOLetter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dtDevcies)
            End Try
        End Sub

        Private Sub PrintServiceWOLetter(ByVal idevice_ID As Integer)
            Dim ds As DataSet, dtFinal As DataTable
            Dim row As DataRow
            Dim strServicePerformed As String = "", strCustProblem As String = ""
            Dim strApprovedDate As String = ""
            Dim bEstimate As Boolean = False, bHaveParts As Boolean = False
            Dim strTechDiagnosis As String = "", strTechComments As String = ""
            Dim strS As String = ""
            Dim i As Integer = 0

            Try

                ds = Me._objAIGProduceShip.GetServiceWOData(Me._iMenuCustID, idevice_ID)

                If ds.Tables.Count > 0 AndAlso ds.Tables("MasterData").Rows.Count > 0 Then
                    'Form service performed
                    i = 0
                    For Each row In ds.Tables("MasterData").Rows
                        If row("BillType_ID") = 1 Then 'is Service
                            If i = 0 Then
                                strServicePerformed = row("BillCode_Desc")
                            Else
                                strServicePerformed &= ", " & row("BillCode_Desc")
                            End If
                            i += 1
                        End If
                    Next

                    For Each row In ds.Tables("MasterData").Rows
                        'Form customer problem
                        strCustProblem = row("DefectType1") & " " & row("DefectType2") & " " & row("ErrDesc_ItemSku")
                        While strCustProblem.IndexOf("  ") <> -1 'remove extra space
                            strCustProblem = strCustProblem.Replace("  ", " ")
                        End While

                        'Get Estimate Date
                        If Not row.IsNull("EstimatedPartCost_Date") Then
                            strApprovedDate = row("EstimatedPartCost_Date")
                            If strApprovedDate.Trim.Length > 0 Then
                                bEstimate = True
                            End If
                        End If

                        Exit For 'only first row, other rows are the same.
                    Next

                    'Form Tech Diagnosis
                    i = 0
                    For Each row In ds.Tables("TechDiagnosis").Rows
                        If i = 0 Then
                            strTechDiagnosis = row("Dcode_LDesc")
                        Else
                            strTechDiagnosis &= ". " & row("Dcode_LDesc")
                        End If
                        i += 1
                    Next

                    'Form Tech Comments
                    i = 0
                    For Each row In ds.Tables("TechComments").Rows
                        If i = 0 Then
                            strTechComments = row("Notes")
                        Else
                            strTechComments &= ". " & row("Notes")
                        End If
                        i += 1
                    Next

                    'update
                    i = 0
                    For Each row In ds.Tables("MasterData").Rows
                        row.BeginEdit()
                        row("CustProblem1") = strCustProblem
                        If bEstimate = True Then
                            row("RequiredEstYN") = "Yes"
                            row("DateApproved") = strApprovedDate
                        Else
                            row("RequiredEstYN") = "No"
                            row("DateApproved") = ""
                            row("DateEstimated") = ""
                        End If
                        row("TechDiagnosis1") = strTechDiagnosis
                        row("ServicePerformed1") = strServicePerformed
                        row("Comments1") = strTechComments
                        If row("BillType_ID") <> 1 Then 'Parts or Accessary (Not service)
                            i += 1
                            row("PartReplaced") = i.ToString & ". " & row("BillCode_Desc") & "(" & row("Part_Number") & ")"
                            bHaveParts = True
                        End If
                        row.AcceptChanges() : row.EndEdit()
                    Next

                    'Final dt
                    dtFinal = ds.Tables("MasterData").Clone
                    For Each row In ds.Tables("MasterData").Rows
                        If bHaveParts Then 'parts or accessory
                            If row("BillType_ID") <> 1 Then
                                dtFinal.ImportRow(row)
                            End If
                        Else 'Service only
                            dtFinal.ImportRow(row)
                        End If
                    Next
                    For i = dtFinal.Columns.Count - 1 To 0 Step -1 'keep required columns 
                        dtFinal.Columns.Remove(dtFinal.Columns(i).ColumnName)
                        If i = 37 Then Exit For
                    Next

                    'Print 
                    Me._objAIG.Print_ServiceWorkOrderLetter(dtFinal, 1)

                    'debug
                    'Dim fm As New frmDataView("My Test", ds.Tables("MasterData"), dtFinal)
                    'fm.Show()

                    'Else
                    ' MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PrintServiceWOLetter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDS(ds)
                Generic.DisposeDT(dtFinal)
            End Try
        End Sub


    End Class
End Namespace