Option Explicit On 

Imports PSS.Core.[Global]
Imports PSS.Data.Buisness

Namespace Gui.DriveCam

    Public Class frmDCRec
        Inherits System.Windows.Forms.Form

        Private Const _iProdID As Integer = 9

        Private _objDC As PSS.Data.Buisness.DriveCam
        Private _iCustID As Integer = 0
        Private _iLocID As Integer = 0
        Private _iWOID As Integer = 0
        Private _iTrayID As Integer = 0
        Private _iPcoID As Integer = 0
        Private _booPopulateData As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objDC = New PSS.Data.Buisness.DriveCam()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If

                _objDC = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents cboPco As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents lblCountry As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblCityStateZip As System.Windows.Forms.Label
        Friend WithEvents lblPhoneNo As System.Windows.Forms.Label
        Friend WithEvents lblFaxNo As System.Windows.Forms.Label
        Friend WithEvents lblRepNoWrty As System.Windows.Forms.Label
        Friend WithEvents pnlRecData As System.Windows.Forms.Panel
        Friend WithEvents btnGetCust As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents dbgRecData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents gbCust As System.Windows.Forms.GroupBox
        Friend WithEvents gbCreditCard As System.Windows.Forms.GroupBox
        Friend WithEvents btnReOpenWO As System.Windows.Forms.Button
        Friend WithEvents btnCloseWO As System.Windows.Forms.Button
        Friend WithEvents lblCCCardType As System.Windows.Forms.Label
        Friend WithEvents lblCCCardNo As System.Windows.Forms.Label
        Friend WithEvents lblCCSecurityCode As System.Windows.Forms.Label
        Friend WithEvents lblCCExpDate As System.Windows.Forms.Label
        Friend WithEvents lblWOName As System.Windows.Forms.Label
        Friend WithEvents rbtnRURReturnToCust As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnRURScrap As System.Windows.Forms.RadioButton
        Friend WithEvents gbxRURShipCriteria As System.Windows.Forms.GroupBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtTrayMemo As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents pnlLocations As System.Windows.Forms.Panel
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
        Friend WithEvents btnPrintManifest As System.Windows.Forms.Button
        Friend WithEvents lblAddress1 As System.Windows.Forms.Label
        Friend WithEvents lblAddress2 As System.Windows.Forms.Label
        Friend WithEvents chkAplyWryReworkPO As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDCRec))
            Me.cboPco = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.gbCust = New System.Windows.Forms.GroupBox()
            Me.lblAddress2 = New System.Windows.Forms.Label()
            Me.lblRepNoWrty = New System.Windows.Forms.Label()
            Me.lblFaxNo = New System.Windows.Forms.Label()
            Me.lblPhoneNo = New System.Windows.Forms.Label()
            Me.lblCityStateZip = New System.Windows.Forms.Label()
            Me.lblAddress1 = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblCountry = New System.Windows.Forms.Label()
            Me.gbCreditCard = New System.Windows.Forms.GroupBox()
            Me.lblCCExpDate = New System.Windows.Forms.Label()
            Me.lblCCSecurityCode = New System.Windows.Forms.Label()
            Me.lblCCCardNo = New System.Windows.Forms.Label()
            Me.lblCCCardType = New System.Windows.Forms.Label()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.pnlRecData = New System.Windows.Forms.Panel()
            Me.chkAplyWryReworkPO = New System.Windows.Forms.CheckBox()
            Me.btnPrintManifest = New System.Windows.Forms.Button()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtTrayMemo = New System.Windows.Forms.TextBox()
            Me.gbxRURShipCriteria = New System.Windows.Forms.GroupBox()
            Me.rbtnRURScrap = New System.Windows.Forms.RadioButton()
            Me.rbtnRURReturnToCust = New System.Windows.Forms.RadioButton()
            Me.lblWOName = New System.Windows.Forms.Label()
            Me.btnCloseWO = New System.Windows.Forms.Button()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.dbgRecData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.btnReOpenWO = New System.Windows.Forms.Button()
            Me.btnGetCust = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.pnlLocations = New System.Windows.Forms.Panel()
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me.Label11 = New System.Windows.Forms.Label()
            CType(Me.cboPco, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbCust.SuspendLayout()
            Me.gbCreditCard.SuspendLayout()
            Me.pnlRecData.SuspendLayout()
            Me.gbxRURShipCriteria.SuspendLayout()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgRecData, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlLocations.SuspendLayout()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cboPco
            '
            Me.cboPco.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPco.Caption = ""
            Me.cboPco.CaptionHeight = 17
            Me.cboPco.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPco.ColumnCaptionHeight = 17
            Me.cboPco.ColumnFooterHeight = 17
            Me.cboPco.ContentHeight = 15
            Me.cboPco.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPco.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPco.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPco.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPco.EditorHeight = 15
            Me.cboPco.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboPco.ItemHeight = 15
            Me.cboPco.Location = New System.Drawing.Point(112, 5)
            Me.cboPco.MatchEntryTimeout = CType(2000, Long)
            Me.cboPco.MaxDropDownItems = CType(5, Short)
            Me.cboPco.MaxLength = 32767
            Me.cboPco.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPco.Name = "cboPco"
            Me.cboPco.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPco.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPco.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPco.Size = New System.Drawing.Size(288, 21)
            Me.cboPco.TabIndex = 1
            Me.cboPco.Text = "C1Combo1"
            Me.cboPco.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(0, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Parent Company:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'gbCust
            '
            Me.gbCust.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAddress2, Me.lblRepNoWrty, Me.lblFaxNo, Me.lblPhoneNo, Me.lblCityStateZip, Me.lblAddress1, Me.lblName, Me.Label5, Me.Label6, Me.Label4, Me.Label3, Me.Label2, Me.lblCountry})
            Me.gbCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCust.Location = New System.Drawing.Point(8, 64)
            Me.gbCust.Name = "gbCust"
            Me.gbCust.Size = New System.Drawing.Size(464, 144)
            Me.gbCust.TabIndex = 2
            Me.gbCust.TabStop = False
            Me.gbCust.Text = "Customer"
            '
            'lblAddress2
            '
            Me.lblAddress2.BackColor = System.Drawing.Color.White
            Me.lblAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblAddress2.ForeColor = System.Drawing.Color.Black
            Me.lblAddress2.Location = New System.Drawing.Point(80, 56)
            Me.lblAddress2.Name = "lblAddress2"
            Me.lblAddress2.Size = New System.Drawing.Size(344, 16)
            Me.lblAddress2.TabIndex = 37
            Me.lblAddress2.Text = "511 South Royal Line"
            Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRepNoWrty
            '
            Me.lblRepNoWrty.BackColor = System.Drawing.Color.White
            Me.lblRepNoWrty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblRepNoWrty.Location = New System.Drawing.Point(392, 120)
            Me.lblRepNoWrty.Name = "lblRepNoWrty"
            Me.lblRepNoWrty.Size = New System.Drawing.Size(32, 16)
            Me.lblRepNoWrty.TabIndex = 36
            Me.lblRepNoWrty.Text = "YES"
            Me.lblRepNoWrty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFaxNo
            '
            Me.lblFaxNo.BackColor = System.Drawing.Color.White
            Me.lblFaxNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblFaxNo.Location = New System.Drawing.Point(208, 120)
            Me.lblFaxNo.Name = "lblFaxNo"
            Me.lblFaxNo.Size = New System.Drawing.Size(88, 16)
            Me.lblFaxNo.TabIndex = 35
            Me.lblFaxNo.Text = "972-393-7144"
            Me.lblFaxNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblPhoneNo
            '
            Me.lblPhoneNo.BackColor = System.Drawing.Color.White
            Me.lblPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblPhoneNo.Location = New System.Drawing.Point(80, 120)
            Me.lblPhoneNo.Name = "lblPhoneNo"
            Me.lblPhoneNo.Size = New System.Drawing.Size(85, 16)
            Me.lblPhoneNo.TabIndex = 34
            Me.lblPhoneNo.Text = "972-462-3970"
            Me.lblPhoneNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCityStateZip
            '
            Me.lblCityStateZip.BackColor = System.Drawing.Color.White
            Me.lblCityStateZip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCityStateZip.ForeColor = System.Drawing.Color.Black
            Me.lblCityStateZip.Location = New System.Drawing.Point(80, 75)
            Me.lblCityStateZip.Name = "lblCityStateZip"
            Me.lblCityStateZip.Size = New System.Drawing.Size(344, 16)
            Me.lblCityStateZip.TabIndex = 33
            Me.lblCityStateZip.Text = "Coppell TX, 76014"
            Me.lblCityStateZip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAddress1
            '
            Me.lblAddress1.BackColor = System.Drawing.Color.White
            Me.lblAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblAddress1.ForeColor = System.Drawing.Color.Black
            Me.lblAddress1.Location = New System.Drawing.Point(80, 37)
            Me.lblAddress1.Name = "lblAddress1"
            Me.lblAddress1.Size = New System.Drawing.Size(344, 16)
            Me.lblAddress1.TabIndex = 32
            Me.lblAddress1.Text = "511 South Royal Line"
            Me.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblName
            '
            Me.lblName.BackColor = System.Drawing.Color.White
            Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(80, 16)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(344, 16)
            Me.lblName.TabIndex = 31
            Me.lblName.Text = "Lan Nguyen"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(168, 120)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(40, 16)
            Me.Label5.TabIndex = 30
            Me.Label5.Text = "Fax #:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(296, 120)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 16)
            Me.Label6.TabIndex = 26
            Me.Label6.Text = "Warranty Repair:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(24, 120)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(56, 16)
            Me.Label4.TabIndex = 27
            Me.Label4.Text = "Phone #:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(16, 37)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(56, 16)
            Me.Label3.TabIndex = 17
            Me.Label3.Text = "Address:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(24, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(48, 16)
            Me.Label2.TabIndex = 15
            Me.Label2.Text = "Name:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCountry
            '
            Me.lblCountry.BackColor = System.Drawing.Color.White
            Me.lblCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCountry.Location = New System.Drawing.Point(80, 96)
            Me.lblCountry.Name = "lblCountry"
            Me.lblCountry.Size = New System.Drawing.Size(344, 16)
            Me.lblCountry.TabIndex = 12
            Me.lblCountry.Text = "USA"
            Me.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'gbCreditCard
            '
            Me.gbCreditCard.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCCExpDate, Me.lblCCSecurityCode, Me.lblCCCardNo, Me.lblCCCardType, Me.Label15, Me.Label16, Me.Label14, Me.Label13})
            Me.gbCreditCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCreditCard.Location = New System.Drawing.Point(472, 64)
            Me.gbCreditCard.Name = "gbCreditCard"
            Me.gbCreditCard.Size = New System.Drawing.Size(408, 144)
            Me.gbCreditCard.TabIndex = 5
            Me.gbCreditCard.TabStop = False
            Me.gbCreditCard.Text = "Credit Card"
            Me.gbCreditCard.Visible = False
            '
            'lblCCExpDate
            '
            Me.lblCCExpDate.BackColor = System.Drawing.Color.White
            Me.lblCCExpDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCCExpDate.ForeColor = System.Drawing.Color.Black
            Me.lblCCExpDate.Location = New System.Drawing.Point(112, 104)
            Me.lblCCExpDate.Name = "lblCCExpDate"
            Me.lblCCExpDate.Size = New System.Drawing.Size(104, 16)
            Me.lblCCExpDate.TabIndex = 35
            Me.lblCCExpDate.Text = "Lan Nguyen"
            Me.lblCCExpDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCCSecurityCode
            '
            Me.lblCCSecurityCode.BackColor = System.Drawing.Color.White
            Me.lblCCSecurityCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCCSecurityCode.ForeColor = System.Drawing.Color.Black
            Me.lblCCSecurityCode.Location = New System.Drawing.Point(112, 80)
            Me.lblCCSecurityCode.Name = "lblCCSecurityCode"
            Me.lblCCSecurityCode.Size = New System.Drawing.Size(104, 16)
            Me.lblCCSecurityCode.TabIndex = 34
            Me.lblCCSecurityCode.Text = "Lan Nguyen"
            Me.lblCCSecurityCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCCCardNo
            '
            Me.lblCCCardNo.BackColor = System.Drawing.Color.White
            Me.lblCCCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCCCardNo.ForeColor = System.Drawing.Color.Black
            Me.lblCCCardNo.Location = New System.Drawing.Point(112, 56)
            Me.lblCCCardNo.Name = "lblCCCardNo"
            Me.lblCCCardNo.Size = New System.Drawing.Size(176, 16)
            Me.lblCCCardNo.TabIndex = 33
            Me.lblCCCardNo.Text = "Lan Nguyen"
            Me.lblCCCardNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblCCCardType
            '
            Me.lblCCCardType.BackColor = System.Drawing.Color.White
            Me.lblCCCardType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCCCardType.ForeColor = System.Drawing.Color.Black
            Me.lblCCCardType.Location = New System.Drawing.Point(112, 32)
            Me.lblCCCardType.Name = "lblCCCardType"
            Me.lblCCCardType.Size = New System.Drawing.Size(176, 16)
            Me.lblCCCardType.TabIndex = 32
            Me.lblCCCardType.Text = "Lan Nguyen"
            Me.lblCCCardType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label15
            '
            Me.Label15.Location = New System.Drawing.Point(8, 80)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(96, 16)
            Me.Label15.TabIndex = 31
            Me.Label15.Text = "Security Code:"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label16
            '
            Me.Label16.Location = New System.Drawing.Point(8, 103)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(96, 16)
            Me.Label16.TabIndex = 26
            Me.Label16.Text = "Expiration Date:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(24, 56)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(80, 16)
            Me.Label14.TabIndex = 24
            Me.Label14.Text = "Card Number:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(32, 32)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(72, 16)
            Me.Label13.TabIndex = 25
            Me.Label13.Text = "Card Type:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlRecData
            '
            Me.pnlRecData.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlRecData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlRecData.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAplyWryReworkPO, Me.btnPrintManifest, Me.Label8, Me.txtTrayMemo, Me.gbxRURShipCriteria, Me.lblWOName, Me.btnCloseWO, Me.cboModels, Me.Label9, Me.dbgRecData, Me.Label7, Me.txtSN})
            Me.pnlRecData.Location = New System.Drawing.Point(8, 208)
            Me.pnlRecData.Name = "pnlRecData"
            Me.pnlRecData.Size = New System.Drawing.Size(872, 360)
            Me.pnlRecData.TabIndex = 5
            Me.pnlRecData.Visible = False
            '
            'chkAplyWryReworkPO
            '
            Me.chkAplyWryReworkPO.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkAplyWryReworkPO.ForeColor = System.Drawing.Color.White
            Me.chkAplyWryReworkPO.Location = New System.Drawing.Point(216, 35)
            Me.chkAplyWryReworkPO.Name = "chkAplyWryReworkPO"
            Me.chkAplyWryReworkPO.Size = New System.Drawing.Size(216, 16)
            Me.chkAplyWryReworkPO.TabIndex = 3
            Me.chkAplyWryReworkPO.Tag = "338"
            Me.chkAplyWryReworkPO.Text = "DriveCam Warranty Reworks"
            '
            'btnPrintManifest
            '
            Me.btnPrintManifest.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnPrintManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintManifest.ForeColor = System.Drawing.Color.Black
            Me.btnPrintManifest.Location = New System.Drawing.Point(744, 8)
            Me.btnPrintManifest.Name = "btnPrintManifest"
            Me.btnPrintManifest.Size = New System.Drawing.Size(112, 20)
            Me.btnPrintManifest.TabIndex = 7
            Me.btnPrintManifest.Text = "Print Manifest"
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(144, 9)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(64, 16)
            Me.Label8.TabIndex = 30
            Me.Label8.Text = "Tray Memo"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTrayMemo
            '
            Me.txtTrayMemo.Location = New System.Drawing.Point(216, 8)
            Me.txtTrayMemo.Name = "txtTrayMemo"
            Me.txtTrayMemo.Size = New System.Drawing.Size(464, 20)
            Me.txtTrayMemo.TabIndex = 2
            Me.txtTrayMemo.Text = ""
            '
            'gbxRURShipCriteria
            '
            Me.gbxRURShipCriteria.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnRURScrap, Me.rbtnRURReturnToCust})
            Me.gbxRURShipCriteria.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbxRURShipCriteria.ForeColor = System.Drawing.Color.Blue
            Me.gbxRURShipCriteria.Location = New System.Drawing.Point(8, 8)
            Me.gbxRURShipCriteria.Name = "gbxRURShipCriteria"
            Me.gbxRURShipCriteria.Size = New System.Drawing.Size(128, 72)
            Me.gbxRURShipCriteria.TabIndex = 1
            Me.gbxRURShipCriteria.TabStop = False
            Me.gbxRURShipCriteria.Text = "RUR"
            '
            'rbtnRURScrap
            '
            Me.rbtnRURScrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnRURScrap.ForeColor = System.Drawing.Color.White
            Me.rbtnRURScrap.Location = New System.Drawing.Point(16, 48)
            Me.rbtnRURScrap.Name = "rbtnRURScrap"
            Me.rbtnRURScrap.Size = New System.Drawing.Size(104, 16)
            Me.rbtnRURScrap.TabIndex = 2
            Me.rbtnRURScrap.Text = "Scrap"
            '
            'rbtnRURReturnToCust
            '
            Me.rbtnRURReturnToCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnRURReturnToCust.ForeColor = System.Drawing.Color.White
            Me.rbtnRURReturnToCust.Location = New System.Drawing.Point(16, 13)
            Me.rbtnRURReturnToCust.Name = "rbtnRURReturnToCust"
            Me.rbtnRURReturnToCust.Size = New System.Drawing.Size(96, 27)
            Me.rbtnRURReturnToCust.TabIndex = 1
            Me.rbtnRURReturnToCust.Text = "Return to Customer"
            '
            'lblWOName
            '
            Me.lblWOName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWOName.ForeColor = System.Drawing.Color.White
            Me.lblWOName.Location = New System.Drawing.Point(616, 34)
            Me.lblWOName.Name = "lblWOName"
            Me.lblWOName.Size = New System.Drawing.Size(240, 16)
            Me.lblWOName.TabIndex = 28
            Me.lblWOName.Text = "Workorder: 20090630112034"
            Me.lblWOName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCloseWO
            '
            Me.btnCloseWO.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCloseWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseWO.ForeColor = System.Drawing.Color.Black
            Me.btnCloseWO.Location = New System.Drawing.Point(744, 56)
            Me.btnCloseWO.Name = "btnCloseWO"
            Me.btnCloseWO.Size = New System.Drawing.Size(112, 20)
            Me.btnCloseWO.TabIndex = 6
            Me.btnCloseWO.Text = "Close WO"
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(216, 56)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(5, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(216, 21)
            Me.cboModels.TabIndex = 4
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label9
            '
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(168, 56)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(40, 16)
            Me.Label9.TabIndex = 27
            Me.Label9.Text = "Model:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgRecData
            '
            Me.dbgRecData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgRecData.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgRecData.Location = New System.Drawing.Point(8, 88)
            Me.dbgRecData.Name = "dbgRecData"
            Me.dbgRecData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgRecData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgRecData.PreviewInfo.ZoomFactor = 75
            Me.dbgRecData.Size = New System.Drawing.Size(832, 232)
            Me.dbgRecData.TabIndex = 17
            Me.dbgRecData.Text = "C1TrueDBGrid1"
            Me.dbgRecData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Back" & _
            "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
            "ctorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
            "=""1""><Height>228</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
            "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
            "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
            """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
            "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
            "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
            " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
            "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
            ", 0, 828, 228</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
            "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
            "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
            "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
            "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
            "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
            "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
            "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
            "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
            "</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 828, 228</" & _
            "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
            "parent="""" me=""Style15"" /></Blob>"
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(480, 40)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(40, 16)
            Me.Label7.TabIndex = 16
            Me.Label7.Text = "S/N:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(480, 56)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(200, 20)
            Me.txtSN.TabIndex = 5
            Me.txtSN.Text = ""
            '
            'btnReOpenWO
            '
            Me.btnReOpenWO.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReOpenWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenWO.ForeColor = System.Drawing.Color.White
            Me.btnReOpenWO.Location = New System.Drawing.Point(520, 6)
            Me.btnReOpenWO.Name = "btnReOpenWO"
            Me.btnReOpenWO.Size = New System.Drawing.Size(88, 20)
            Me.btnReOpenWO.TabIndex = 3
            Me.btnReOpenWO.Text = "ReOpen WO"
            '
            'btnGetCust
            '
            Me.btnGetCust.BackColor = System.Drawing.Color.SteelBlue
            Me.btnGetCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetCust.ForeColor = System.Drawing.Color.White
            Me.btnGetCust.Location = New System.Drawing.Point(408, 6)
            Me.btnGetCust.Name = "btnGetCust"
            Me.btnGetCust.Size = New System.Drawing.Size(96, 20)
            Me.btnGetCust.TabIndex = 2
            Me.btnGetCust.Text = "Get Customer"
            Me.btnGetCust.Visible = False
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(624, 6)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(88, 20)
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel"
            '
            'Label10
            '
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.Location = New System.Drawing.Point(32, 5)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(64, 16)
            Me.Label10.TabIndex = 7
            Me.Label10.Text = "Customer:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomers.EditorHeight = 15
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(104, 5)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(288, 21)
            Me.cboCustomers.TabIndex = 6
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'pnlLocations
            '
            Me.pnlLocations.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLocations, Me.Label11, Me.cboCustomers, Me.Label10})
            Me.pnlLocations.Location = New System.Drawing.Point(8, 31)
            Me.pnlLocations.Name = "pnlLocations"
            Me.pnlLocations.Size = New System.Drawing.Size(872, 33)
            Me.pnlLocations.TabIndex = 8
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
            Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocations.EditorHeight = 15
            Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboLocations.ItemHeight = 15
            Me.cboLocations.Location = New System.Drawing.Point(488, 6)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(5, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(208, 21)
            Me.cboLocations.TabIndex = 8
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label11
            '
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.Location = New System.Drawing.Point(424, 7)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(56, 16)
            Me.Label11.TabIndex = 9
            Me.Label11.Text = "Location:"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmDCRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(888, 573)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlLocations, Me.gbCreditCard, Me.btnCancel, Me.btnGetCust, Me.pnlRecData, Me.gbCust, Me.Label1, Me.cboPco, Me.btnReOpenWO})
            Me.Name = "frmDCRec"
            Me.Text = "frmDCRec"
            CType(Me.cboPco, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbCust.ResumeLayout(False)
            Me.gbCreditCard.ResumeLayout(False)
            Me.pnlRecData.ResumeLayout(False)
            Me.gbxRURShipCriteria.ResumeLayout(False)
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgRecData, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlLocations.ResumeLayout(False)
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**********************************************************************************************
        Private Sub frmDCRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim booAllowCreditCardCustomer As Boolean = False

            Try
                Me.ClearAllCtrls() : Me.ClearGlobalVariables()

                If ApplicationUser.GetPermission("DC_RecCreditCard") > 0 Then
                    booAllowCreditCardCustomer = True
                End If

                _booPopulateData = True
                Generic.DisposeDT(dt)
                dt = Me._objDC.GetParentCoListByProdID(_iProdID, booAllowCreditCardCustomer, True)
                Misc.PopulateC1DropDownList(Me.cboPco, dt, "PCo_Name", "PCo_ID")
                Me.cboPco.SelectedValue = 0
                _booPopulateData = False

                Generic.DisposeDT(dt)
                dt = Me._objDC.GetModels(True, PSS.Data.Buisness.DriveCam.PRODID)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
                If dt.Rows.Count = 2 Then Me.cboModels.SelectedValue = dt.Rows(0)("Model_ID") Else Me.cboModels.SelectedValue = 0

                Me.cboPco.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.ClearAllCtrls() : Me.ClearGlobalVariables()
            Me.cboPco.Focus()
        End Sub

        '**********************************************************************************************
        Private Sub ClearAllCtrls()
            'Customer information
            Me.gbCust.Visible = False
            Me.lblName.Text = ""
            Me.lblAddress1.Text = ""
            Me.lblAddress2.Text = ""
            Me.lblCityStateZip.Text = ""
            Me.lblCountry.Text = ""
            Me.lblPhoneNo.Text = ""
            Me.lblFaxNo.Text = ""
            Me.lblRepNoWrty.Text = ""

            'Credit card Info
            Me.gbCreditCard.Visible = False
            Me.lblCCCardType.Text = ""
            Me.lblCCCardNo.Text = ""
            Me.lblCCSecurityCode.Text = ""
            Me.lblCCExpDate.Text = ""

            'Received data
            Me.rbtnRURReturnToCust.Checked = False
            Me.rbtnRURScrap.Checked = False
            If Not IsNothing(Me.cboModels.DataSource) AndAlso Me.cboModels.DataSource.Table.Rows.Count = 2 Then Me.cboModels.SelectedValue = Me.cboModels.DataSource.Table.Rows(0)("Model_ID") Else Me.cboModels.SelectedValue = 0
            Me.txtSN.Text = ""
            Me.dbgRecData.DataSource = Nothing
            Me.lblWOName.Text = ""
            Me.txtTrayMemo.Text = ""
            Me.txtTrayMemo.Enabled = True
            Me.pnlRecData.Visible = False
            Me.gbxRURShipCriteria.Enabled = False
        End Sub

        Private Sub ClearGlobalVariables()
            'Global variables
            Me._iCustID = 0
            Me._iLocID = 0
            Me._iTrayID = 0
            Me._iWOID = 0
        End Sub

        '**********************************************************************************************
        Private Sub btnGetCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetCust.Click
            Try
                If Me.cboPco.SelectedValue > 0 Then
                    GetCustomerInfo(Me.cboPco.SelectedValue)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnGetCust_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**********************************************************************************************
        Private Function GetCustomerInfo(ByVal iPCoID As Integer) As Boolean
            Dim dt As DataTable
            Dim booCreditcardCustomer As Boolean = False

            Try
                ClearAllCtrls() : Me.ClearGlobalVariables()

                If iPCoID <> 734 Then   'NOT DriveCam
                    Me.cboCustomers.Enabled = True
                    Me.cboLocations.Enabled = True
                    Me.PopulateCustomerList()
                Else
                    Me.GetCustomerLocationID()
                    booCreditcardCustomer = True
                    Me.cboCustomers.Enabled = False
                    Me.cboLocations.Enabled = False
                End If

                If Me._iCustID > 0 And Me._iLocID > 0 Then
                    Me._iPcoID = Me.cboPco.SelectedValue

                    Me.PopulateCustInfo(Me._iCustID, Me._iLocID)

                    If Me._iCustID = 2294 Then
                        Me.rbtnRURScrap.Checked = True
                        Me.gbxRURShipCriteria.Enabled = False
                    Else
                        Me.rbtnRURScrap.Checked = False
                        Me.gbxRURShipCriteria.Enabled = True
                    End If
                    Me.pnlRecData.Visible = True
                    Me.gbxRURShipCriteria.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnGetCust_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Private Sub PopulateCustomerList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetCustomerListByParentComp(True, Me.cboPco.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboCustomers.SelectedValue = dt.Rows(0)("Cust_ID")
                    Me._iCustID = dt.Rows(0)("Cust_ID")
                    Me.PopulateLocationList()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateLocationList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                    Me._iPcoID = Me.cboPco.SelectedValue
                    Me._iLocID = Me.cboLocations.SelectedValue
                    Me._iCustID = Me.cboCustomers.SelectedValue

                    If Me._iCustID > 0 And Me._iLocID > 0 Then
                        Me.PopulateCustInfo(Me._iCustID, Me._iLocID)

                        If Me._iCustID = 2294 Then
                            Me.rbtnRURScrap.Checked = True
                            Me.gbxRURShipCriteria.Enabled = False
                        Else
                            Me.rbtnRURScrap.Checked = False
                            Me.gbxRURShipCriteria.Enabled = True
                        End If
                        Me.pnlRecData.Visible = True
                        Me.gbxRURShipCriteria.Focus()
                    End If
                Else
                    Me.cboLocations.SelectedValue = 0
                End If

            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub GetCustomerLocationID()
            Dim frmGetCust As Gui.DriveCam.frmDCCollectCustInfo
            Try
                frmGetCust = New Gui.DriveCam.frmDCCollectCustInfo(PSS.Data.Buisness.DriveCam.PARENTCOMP_ID, Me._objDC)
                frmGetCust.ShowDialog()
                Me._iCustID = frmGetCust._iCustID
                Me._iLocID = frmGetCust._iLocID
            Catch ex As Exception
                Throw ex
            Finally
                frmGetCust.Dispose()
                frmGetCust = Nothing
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub PopulateCustInfo(ByVal iCustID As Integer, ByVal iLocID As Integer)
            Dim dt As DataTable
            Try
                'Populate Customer Information
                dt = Me._objDC.GetCustInfo(iCustID, iLocID)
                If dt.Rows.Count > 0 Then
                    Me.gbCust.Visible = True
                    Me.lblName.Text = dt.Rows(0)("Name")
                    Me.lblAddress1.Text = dt.Rows(0)("Address1")
                    Me.lblAddress2.Text = dt.Rows(0)("Address2")
                    Me.lblCityStateZip.Text = dt.Rows(0)("CityStateZip")
                    Me.lblCountry.Text = dt.Rows(0)("Country")
                    Me.lblPhoneNo.Text = dt.Rows(0)("Phone")
                    Me.lblFaxNo.Text = dt.Rows(0)("Fax")
                    Me.lblRepNoWrty.Text = dt.Rows(0)("RepNonWrty")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateCustInfo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub PopulateCustCreditCardInfo(ByVal iCustID As Integer, ByVal iLocID As Integer)
            Dim dt As DataTable
            Try
                'Populate Credit Card Information
                dt = Me._objDC.GetLastCreditCardInfo(Me._iCustID)
                If dt.Rows.Count > 0 Then
                    Me.gbCreditCard.Visible = True
                    Me.lblCCCardType.Text = dt.Rows(0)("CCType_Desc")
                    Me.lblCCCardNo.Text = dt.Rows(0)("CreditCard_Num")
                    Me.lblCCSecurityCode.Text = dt.Rows(0)("CreditCard_AuthCode")
                    Me.lblCCExpDate.Text = dt.Rows(0)("CreditCard_ExpDate").ToString.Trim
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateCustCreditCardInfo", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub cbos_txts_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPco.KeyUp, cboModels.KeyUp, txtSN.KeyUp
            Dim dt As DataTable
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name().ToString.Trim = "cboPco" AndAlso Not IsNothing(Me.cboPco.SelectedValue) AndAlso Me.cboPco.SelectedValue > 0 Then
                        Me.GetCustomerInfo(Me.cboPco.SelectedValue)
                    ElseIf sender.name().ToString.Trim = "cboModels" AndAlso Me.cboModels.SelectedValue > 0 Then
                        Me.txtSN.Focus()
                    ElseIf sender.name().ToString.Trim = "txtSN" AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                        Me.ProcessSN()
                        Me.txtSN.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbo_keyup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub ProcessSN()
            Const iDiagnosticBillcodeID As Integer = 1588
            Dim iDeviceID As Integer
            Dim strWOName As String = ""
            Dim objDevice As Rules.Device
            Dim iRURReturnToCust As Integer = 0
            Dim strPOID As String = "0"

            Try
                If Me._iCustID = 0 Or Me._iLocID = 0 Then
                    Me.txtSN.SelectAll()
                    MessageBox.Show("Customer ID and Location ID are not define. Please re-select customer.", "Information", MessageBoxButtons.OK)
                ElseIf Me.rbtnRURReturnToCust.Checked = False And Me.rbtnRURScrap.Checked = False Then
                    MessageBox.Show("Please select RUR criteria.", "Information", MessageBoxButtons.OK)
                ElseIf Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK)
                ElseIf Generic.IsSNInWIP(Me._iCustID, Me.txtSN.Text.Trim) = True Then
                    Me.txtSN.SelectAll()
                    MessageBox.Show("S/N is open in WIP.", "Information", MessageBoxButtons.OK)
                Else
                    If Me.chkAplyWryReworkPO.Checked = True Then strPOID = Me.chkAplyWryReworkPO.Tag
                    If Me._iWOID = 0 Then
                        Me._iWOID = Me._objDC.CreateWO(Me._iLocID, strWOName, strPOID)
                        Me.lblWOName.Text = strWOName
                        Me._iTrayID = Me._objDC.CreateTray(PSS.Core.ApplicationUser.User, PSS.Core.ApplicationUser.IDuser, Me._iWOID, Me.txtTrayMemo.Text.Trim)
                    End If

                    If Me._iWOID = 0 Or Me._iTrayID = 0 Then
                        Me.txtSN.SelectAll()
                        MessageBox.Show("Workorder ID and Tray ID are not define.", "Information", MessageBoxButtons.OK)
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        'RUR criteria
                        If Me.rbtnRURReturnToCust.Checked = True Then iRURReturnToCust = 1

                        'Receive device
                        iDeviceID = Me._objDC.ReceiveDevice(Me._iLocID, Me._iWOID, Me._iTrayID, Me.txtSN.Text.Trim.ToUpper, Me.cboModels.SelectedValue, PSS.Core.ApplicationUser.IDShift, PSS.Core.ApplicationUser.IDuser, iRURReturnToCust)

                        If iDeviceID > 0 Then
                            'AutoBill
                            objDevice = New Rules.Device(iDeviceID)

                            If Generic.IsBillcodeExisted(iDeviceID, iDiagnosticBillcodeID) = False Then objDevice.AddPart(iDiagnosticBillcodeID)
                            objDevice.Update()

                            'Populate Receive Data
                            PopulateReceivedData()
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            Me.txtSN.Text = ""
                            If Me.chkAplyWryReworkPO.Checked = True Then Me.chkAplyWryReworkPO.Enabled = False
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub btnReOpenWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReOpenWO.Click
            Dim dt As DataTable
            Dim strWOName, strTrayMemo As String
            Dim i As Integer = 0

            Try
                strWOName = "" : strTrayMemo = ""

                If Me._iCustID = 0 Or Me._iLocID = 0 Then
                    MessageBox.Show("Please select Customer.", "Information", MessageBoxButtons.OK)
                Else
                    strWOName = InputBox("Enter Workorder Name:", "Get WO").Trim
                    If strWOName.Length = 0 Then
                        Exit Sub
                    Else
                        dt = Generic.GetCustWo(strWOName, Me._iLocID)
                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("Workorder does not exist.", "Information", MessageBoxButtons.OK)
                        ElseIf dt.Rows.Count > 1 Then
                            MessageBox.Show("Workorder existed more than one in the system. Please Contact IT.", "Information", MessageBoxButtons.OK)
                        Else
                            i = Generic.ReOpenWO(dt.Rows(0)("WO_ID"))
                            If i > 0 Then
                                Me._iWOID = dt.Rows(0)("WO_ID")
                                Me.lblWOName.Text = "Workorder: " & dt.Rows(0)("WO_CustWO")
                                Me._iTrayID = Generic.GetLastTrayIDOfWOID(dt.Rows(0)("WO_ID"), strTrayMemo)
                                Me.txtTrayMemo.Text = strTrayMemo : Me.txtTrayMemo.Enabled = False
                                If Not IsDBNull(dt.Rows(0)("PO_ID")) AndAlso dt.Rows(0)("PO_ID") > 0 Then
                                    Me.chkAplyWryReworkPO.Checked = True : Me.chkAplyWryReworkPO.Enabled = False
                                Else
                                    Me.chkAplyWryReworkPO.Checked = False : Me.chkAplyWryReworkPO.Enabled = True
                                End If
                                PopulateReceivedData()
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReOpenWO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub PopulateReceivedData()
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                dt = Me._objDC.GetReceiveDataByWOID(Me._iWOID)

                With Me.dbgRecData
                    .DataSource = dt.DefaultView
                    .Visible = True
                    .AllowFilter = True
                    .FilterBar = True

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.White
                        .Splits(0).DisplayColumns(i).HeadingStyle.BackColor = Color.SteelBlue
                        'If i = 0 Then .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = Color.Pink

                        If dt.Columns(i).Caption = "SN" Then
                            .Splits(0).DisplayColumns(i).Frozen = True
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        ElseIf dt.Columns(i).Caption.EndsWith("Date") Or dt.Columns(i).Caption.EndsWith("Cnt") Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        Else
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        End If

                        If dt.Columns(i).Caption = "SN" Then
                            .Splits(0).DisplayColumns(i).Width = 100
                        ElseIf dt.Columns(i).Caption.ToString.EndsWith("Date") Or dt.Columns(i).Caption.ToString = "WO" Then
                            .Splits(0).DisplayColumns(i).Width = 120
                        ElseIf dt.Columns(i).Caption.ToString = "Cnt" Then
                            .Splits(0).DisplayColumns(i).Width = 50
                        Else
                            .Splits(0).DisplayColumns(i).Width = 75
                        End If
                    Next i
                End With

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub btnCloseWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseWO.Click
            Dim iWOQty As Integer
            Dim i As Integer = 0

            Try
                If Me._iCustID = 0 Or Me._iLocID = 0 Then
                    MessageBox.Show("Please select Customer.", "Information", MessageBoxButtons.OK)
                ElseIf Me._iWOID = 0 Then
                    MessageBox.Show("Workorder ID is missing. Please reopen it.", "Information", MessageBoxButtons.OK)
                Else
                    iWOQty = Generic.GetRecQty(Me._iWOID)
                    If iWOQty = 0 Then
                        MessageBox.Show("This is an empty workorder.", "Information", MessageBoxButtons.OK)
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        'Close WO
                        i = Generic.CloseWO(Me._iWOID)

                        'Print Receive Manifest
                        Generic.PrintRecReport(Me._iTrayID, 2)

                        Me.Enabled = True
                        Cursor.Current = Cursors.Default

                        If i > 0 Then
                            MessageBox.Show("Workorder has been closed.", "Information", MessageBoxButtons.OK)
                            Me.ClearAllCtrls()
                            Me._iWOID = 0 : Me._iTrayID = 0 : Me.chkAplyWryReworkPO.Checked = False : Me.chkAplyWryReworkPO.Enabled = True
                            Me.cboPco.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnFinish_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub chkRURReturn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Me.cboModels.Focus()
        End Sub

        '**********************************************************************************************
        Private Sub cboPCo_Customers_Locations_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPco.RowChange, cboCustomers.RowChange, cboLocations.RowChange
            Try
                Me._iCustID = 0

                If _booPopulateData = False Then
                    If sender.name = "cboPco" Then
                        Me.ClearAllCtrls() : Me.ClearGlobalVariables()

                        If Me.cboPco.SelectedValue > 0 Then
                            Me.cboCustomers.DataSource = Nothing : Me.cboCustomers.Text = ""
                            Me.cboLocations.DataSource = Nothing : Me.cboLocations.Text = ""
                            Me.GetCustomerInfo(Me.cboPco.SelectedValue)
                        End If
                    ElseIf sender.name = "cboCustomers" Then
                        Me.ClearAllCtrls() : Me.ClearGlobalVariables()

                        Me.cboLocations.DataSource = Nothing : Me.cboLocations.Text = ""
                        If Me.cboCustomers.SelectedValue > 0 Then Me.PopulateLocationList()
                    ElseIf sender.name = "cboLocations" Then
                        Me.ClearAllCtrls() : Me._iWOID = 0 : Me._iTrayID = 0 : Me._iLocID = 0

                        If Me.cboLocations.SelectedValue > 0 Then
                            Me._iPcoID = Me.cboPco.SelectedValue
                            Me._iLocID = Me.cboLocations.SelectedValue
                            Me._iCustID = Me.cboCustomers.SelectedValue

                            If Me._iCustID > 0 And Me._iLocID > 0 Then
                                Me.PopulateCustInfo(Me._iCustID, Me._iLocID)

                                If Me._iCustID = 2294 Then
                                    Me.rbtnRURScrap.Checked = True
                                    Me.gbxRURShipCriteria.Enabled = False
                                Else
                                    Me.rbtnRURScrap.Checked = False
                                    Me.gbxRURShipCriteria.Enabled = True
                                End If
                                Me.pnlRecData.Visible = True
                                Me.gbxRURShipCriteria.Focus()
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RowChange_Event", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**********************************************************************************************
        Private Sub btnPrintManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintManifest.Click
            Dim strTray_id As String = ""

            Try
                '*******************
                'Get Tray ID
                '*******************
                strTray_id = Trim(InputBox("Please Scan Tray ID:", "Reprint Receive Manifest"))

                '********************
                'Validate user input
                '********************
                If strTray_id = "" Then
                    Exit Sub
                End If

                If Not IsNumeric(strTray_id) Then
                    MessageBox.Show("Invalid Tray ID please retry.", "Validate Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                '***********************
                'Print Report
                '***********************
                PSS.Data.Buisness.MessReceive.PrintRecReport(CInt(strTray_id), 1)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Receive Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**********************************************************************************************


    End Class
End Namespace