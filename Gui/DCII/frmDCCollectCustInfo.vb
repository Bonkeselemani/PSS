Option Explicit On
Imports System.Windows.Forms
Imports PSS.Data.Buisness

Namespace Gui.DriveCam

    Public Class frmDCCollectCustInfo
        Inherits System.Windows.Forms.Form

        Private _objDC As PSS.Data.Buisness.DriveCam
        Private _iPCoID As Integer
        Public _iCustID As Integer
        Public _iLocID As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iParentCompanyID As Integer, ByRef objDC As PSS.Data.Buisness.DriveCam)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iPCoID = iParentCompanyID
            _objDC = objDC
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
        Friend WithEvents cboNonWrtyRepair As C1.Win.C1List.C1Combo
        Friend WithEvents txtFaxNumber As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
        Friend WithEvents lblNonWrtyRepair As System.Windows.Forms.Label
        Friend WithEvents lblPhoneNumber As System.Windows.Forms.Label
        Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
        Friend WithEvents txtCity As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
        Friend WithEvents txtLastName As System.Windows.Forms.TextBox
        Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
        Friend WithEvents lblZipCode As System.Windows.Forms.Label
        Friend WithEvents lblState As System.Windows.Forms.Label
        Friend WithEvents lblCity As System.Windows.Forms.Label
        Friend WithEvents lblAddress2 As System.Windows.Forms.Label
        Friend WithEvents lblAddress1 As System.Windows.Forms.Label
        Friend WithEvents lblLastName As System.Windows.Forms.Label
        Friend WithEvents lblFirstName As System.Windows.Forms.Label
        Friend WithEvents lblCountry As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtAddressSearch As System.Windows.Forms.TextBox
        Friend WithEvents btnAddressSearch As System.Windows.Forms.Button
        Friend WithEvents btnNewCustomer As System.Windows.Forms.Button
        Friend WithEvents cboStates As C1.Win.C1List.C1Combo
        Friend WithEvents cboCountries As C1.Win.C1List.C1Combo
        Friend WithEvents cboExistingCusts As C1.Win.C1List.C1Combo
        Friend WithEvents btnAddCust As System.Windows.Forms.Button
        Friend WithEvents btnGetExistingCust As System.Windows.Forms.Button
        Friend WithEvents btnSetCust As System.Windows.Forms.Button
        Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents gbCustInfo As System.Windows.Forms.GroupBox
        Friend WithEvents gbCreditCard As System.Windows.Forms.GroupBox
        Friend WithEvents cboCCExpYear As C1.Win.C1List.C1Combo
        Friend WithEvents cboCCExpMonth As C1.Win.C1List.C1Combo
        Friend WithEvents cboCCType As C1.Win.C1List.C1Combo
        Friend WithEvents txtCCSecurityCode As System.Windows.Forms.TextBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents txtCCNumber As System.Windows.Forms.TextBox
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents pnlCreditCard As System.Windows.Forms.Panel
        Friend WithEvents btnEditCC As System.Windows.Forms.Button
        Friend WithEvents chkEditCC As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDCCollectCustInfo))
            Me.gbCustInfo = New System.Windows.Forms.GroupBox()
            Me.txtEmailAddress = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboNonWrtyRepair = New C1.Win.C1List.C1Combo()
            Me.cboStates = New C1.Win.C1List.C1Combo()
            Me.txtFaxNumber = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
            Me.lblNonWrtyRepair = New System.Windows.Forms.Label()
            Me.lblPhoneNumber = New System.Windows.Forms.Label()
            Me.txtZipCode = New System.Windows.Forms.TextBox()
            Me.txtCity = New System.Windows.Forms.TextBox()
            Me.txtAddress2 = New System.Windows.Forms.TextBox()
            Me.txtAddress1 = New System.Windows.Forms.TextBox()
            Me.txtLastName = New System.Windows.Forms.TextBox()
            Me.txtFirstName = New System.Windows.Forms.TextBox()
            Me.lblZipCode = New System.Windows.Forms.Label()
            Me.lblState = New System.Windows.Forms.Label()
            Me.lblCity = New System.Windows.Forms.Label()
            Me.lblAddress2 = New System.Windows.Forms.Label()
            Me.lblAddress1 = New System.Windows.Forms.Label()
            Me.lblLastName = New System.Windows.Forms.Label()
            Me.lblFirstName = New System.Windows.Forms.Label()
            Me.lblCountry = New System.Windows.Forms.Label()
            Me.cboCountries = New C1.Win.C1List.C1Combo()
            Me.btnAddCust = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboExistingCusts = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtAddressSearch = New System.Windows.Forms.TextBox()
            Me.btnAddressSearch = New System.Windows.Forms.Button()
            Me.btnNewCustomer = New System.Windows.Forms.Button()
            Me.btnGetExistingCust = New System.Windows.Forms.Button()
            Me.btnSetCust = New System.Windows.Forms.Button()
            Me.gbCreditCard = New System.Windows.Forms.GroupBox()
            Me.chkEditCC = New System.Windows.Forms.CheckBox()
            Me.pnlCreditCard = New System.Windows.Forms.Panel()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.txtCCSecurityCode = New System.Windows.Forms.TextBox()
            Me.txtCCNumber = New System.Windows.Forms.TextBox()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.cboCCExpMonth = New C1.Win.C1List.C1Combo()
            Me.cboCCExpYear = New C1.Win.C1List.C1Combo()
            Me.cboCCType = New C1.Win.C1List.C1Combo()
            Me.btnEditCC = New System.Windows.Forms.Button()
            Me.gbCustInfo.SuspendLayout()
            CType(Me.cboNonWrtyRepair, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboStates, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCountries, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboExistingCusts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbCreditCard.SuspendLayout()
            Me.pnlCreditCard.SuspendLayout()
            CType(Me.cboCCExpMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCCExpYear, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCCType, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'gbCustInfo
            '
            Me.gbCustInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEmailAddress, Me.Label4, Me.cboNonWrtyRepair, Me.cboStates, Me.txtFaxNumber, Me.Label2, Me.txtPhoneNumber, Me.lblNonWrtyRepair, Me.lblPhoneNumber, Me.txtZipCode, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.txtLastName, Me.txtFirstName, Me.lblZipCode, Me.lblState, Me.lblCity, Me.lblAddress2, Me.lblAddress1, Me.lblLastName, Me.lblFirstName, Me.lblCountry, Me.cboCountries})
            Me.gbCustInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCustInfo.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.gbCustInfo.Location = New System.Drawing.Point(16, 96)
            Me.gbCustInfo.Name = "gbCustInfo"
            Me.gbCustInfo.Size = New System.Drawing.Size(472, 232)
            Me.gbCustInfo.TabIndex = 2
            Me.gbCustInfo.TabStop = False
            Me.gbCustInfo.Text = "Customer"
            '
            'txtEmailAddress
            '
            Me.txtEmailAddress.Location = New System.Drawing.Point(136, 170)
            Me.txtEmailAddress.MaxLength = 50
            Me.txtEmailAddress.Name = "txtEmailAddress"
            Me.txtEmailAddress.Size = New System.Drawing.Size(320, 20)
            Me.txtEmailAddress.TabIndex = 11
            Me.txtEmailAddress.Text = ""
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(32, 170)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(96, 16)
            Me.Label4.TabIndex = 32
            Me.Label4.Text = "Email Address:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboNonWrtyRepair
            '
            Me.cboNonWrtyRepair.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboNonWrtyRepair.Caption = ""
            Me.cboNonWrtyRepair.CaptionHeight = 17
            Me.cboNonWrtyRepair.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboNonWrtyRepair.ColumnCaptionHeight = 17
            Me.cboNonWrtyRepair.ColumnFooterHeight = 17
            Me.cboNonWrtyRepair.ContentHeight = 15
            Me.cboNonWrtyRepair.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboNonWrtyRepair.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboNonWrtyRepair.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboNonWrtyRepair.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboNonWrtyRepair.EditorHeight = 15
            Me.cboNonWrtyRepair.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboNonWrtyRepair.ItemHeight = 15
            Me.cboNonWrtyRepair.Location = New System.Drawing.Point(136, 197)
            Me.cboNonWrtyRepair.MatchEntryTimeout = CType(2000, Long)
            Me.cboNonWrtyRepair.MaxDropDownItems = CType(5, Short)
            Me.cboNonWrtyRepair.MaxLength = 32767
            Me.cboNonWrtyRepair.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboNonWrtyRepair.Name = "cboNonWrtyRepair"
            Me.cboNonWrtyRepair.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboNonWrtyRepair.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboNonWrtyRepair.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboNonWrtyRepair.Size = New System.Drawing.Size(104, 21)
            Me.cboNonWrtyRepair.TabIndex = 12
            Me.cboNonWrtyRepair.Text = "C1Combo1"
            Me.cboNonWrtyRepair.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboStates
            '
            Me.cboStates.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboStates.Caption = ""
            Me.cboStates.CaptionHeight = 17
            Me.cboStates.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboStates.ColumnCaptionHeight = 17
            Me.cboStates.ColumnFooterHeight = 17
            Me.cboStates.ContentHeight = 15
            Me.cboStates.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboStates.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboStates.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStates.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboStates.EditorHeight = 15
            Me.cboStates.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboStates.ItemHeight = 15
            Me.cboStates.Location = New System.Drawing.Point(336, 94)
            Me.cboStates.MatchEntryTimeout = CType(2000, Long)
            Me.cboStates.MaxDropDownItems = CType(5, Short)
            Me.cboStates.MaxLength = 2
            Me.cboStates.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboStates.Name = "cboStates"
            Me.cboStates.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboStates.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboStates.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboStates.Size = New System.Drawing.Size(120, 21)
            Me.cboStates.TabIndex = 6
            Me.cboStates.Text = "TX"
            Me.cboStates.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'txtFaxNumber
            '
            Me.txtFaxNumber.Location = New System.Drawing.Point(355, 144)
            Me.txtFaxNumber.MaxLength = 12
            Me.txtFaxNumber.Name = "txtFaxNumber"
            Me.txtFaxNumber.TabIndex = 10
            Me.txtFaxNumber.Text = ""
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(267, 144)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 30
            Me.Label2.Text = "Fax Number:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPhoneNumber
            '
            Me.txtPhoneNumber.Location = New System.Drawing.Point(136, 144)
            Me.txtPhoneNumber.MaxLength = 12
            Me.txtPhoneNumber.Name = "txtPhoneNumber"
            Me.txtPhoneNumber.Size = New System.Drawing.Size(104, 20)
            Me.txtPhoneNumber.TabIndex = 9
            Me.txtPhoneNumber.Text = ""
            '
            'lblNonWrtyRepair
            '
            Me.lblNonWrtyRepair.Location = New System.Drawing.Point(8, 197)
            Me.lblNonWrtyRepair.Name = "lblNonWrtyRepair"
            Me.lblNonWrtyRepair.Size = New System.Drawing.Size(120, 16)
            Me.lblNonWrtyRepair.TabIndex = 26
            Me.lblNonWrtyRepair.Text = "Non-Warranty Repair:"
            Me.lblNonWrtyRepair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPhoneNumber
            '
            Me.lblPhoneNumber.Location = New System.Drawing.Point(32, 144)
            Me.lblPhoneNumber.Name = "lblPhoneNumber"
            Me.lblPhoneNumber.Size = New System.Drawing.Size(96, 16)
            Me.lblPhoneNumber.TabIndex = 27
            Me.lblPhoneNumber.Text = "Phone Number:"
            Me.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtZipCode
            '
            Me.txtZipCode.Location = New System.Drawing.Point(136, 120)
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.Size = New System.Drawing.Size(72, 20)
            Me.txtZipCode.TabIndex = 7
            Me.txtZipCode.Text = ""
            '
            'txtCity
            '
            Me.txtCity.Location = New System.Drawing.Point(136, 94)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(128, 20)
            Me.txtCity.TabIndex = 5
            Me.txtCity.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.Location = New System.Drawing.Point(136, 70)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.Size = New System.Drawing.Size(320, 20)
            Me.txtAddress2.TabIndex = 4
            Me.txtAddress2.Text = ""
            '
            'txtAddress1
            '
            Me.txtAddress1.Location = New System.Drawing.Point(136, 46)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.Size = New System.Drawing.Size(320, 20)
            Me.txtAddress1.TabIndex = 3
            Me.txtAddress1.Text = ""
            '
            'txtLastName
            '
            Me.txtLastName.Location = New System.Drawing.Point(360, 22)
            Me.txtLastName.Name = "txtLastName"
            Me.txtLastName.Size = New System.Drawing.Size(96, 20)
            Me.txtLastName.TabIndex = 2
            Me.txtLastName.Text = ""
            '
            'txtFirstName
            '
            Me.txtFirstName.Location = New System.Drawing.Point(136, 22)
            Me.txtFirstName.Name = "txtFirstName"
            Me.txtFirstName.TabIndex = 1
            Me.txtFirstName.Text = ""
            '
            'lblZipCode
            '
            Me.lblZipCode.Location = New System.Drawing.Point(72, 120)
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Size = New System.Drawing.Size(56, 16)
            Me.lblZipCode.TabIndex = 13
            Me.lblZipCode.Text = "Zip Code:"
            Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblState
            '
            Me.lblState.Location = New System.Drawing.Point(296, 97)
            Me.lblState.Name = "lblState"
            Me.lblState.Size = New System.Drawing.Size(40, 16)
            Me.lblState.TabIndex = 10
            Me.lblState.Text = "State:"
            Me.lblState.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblCity
            '
            Me.lblCity.Location = New System.Drawing.Point(56, 94)
            Me.lblCity.Name = "lblCity"
            Me.lblCity.Size = New System.Drawing.Size(72, 16)
            Me.lblCity.TabIndex = 11
            Me.lblCity.Text = "City:"
            Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress2
            '
            Me.lblAddress2.Location = New System.Drawing.Point(56, 70)
            Me.lblAddress2.Name = "lblAddress2"
            Me.lblAddress2.Size = New System.Drawing.Size(72, 16)
            Me.lblAddress2.TabIndex = 16
            Me.lblAddress2.Text = "Address(2):"
            Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress1
            '
            Me.lblAddress1.Location = New System.Drawing.Point(56, 46)
            Me.lblAddress1.Name = "lblAddress1"
            Me.lblAddress1.Size = New System.Drawing.Size(72, 16)
            Me.lblAddress1.TabIndex = 17
            Me.lblAddress1.Text = "Address(1):"
            Me.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLastName
            '
            Me.lblLastName.Location = New System.Drawing.Point(296, 22)
            Me.lblLastName.Name = "lblLastName"
            Me.lblLastName.Size = New System.Drawing.Size(64, 16)
            Me.lblLastName.TabIndex = 14
            Me.lblLastName.Text = "Last Name:"
            Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFirstName
            '
            Me.lblFirstName.Location = New System.Drawing.Point(56, 22)
            Me.lblFirstName.Name = "lblFirstName"
            Me.lblFirstName.Size = New System.Drawing.Size(72, 16)
            Me.lblFirstName.TabIndex = 15
            Me.lblFirstName.Text = "First Name:"
            Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCountry
            '
            Me.lblCountry.Location = New System.Drawing.Point(212, 122)
            Me.lblCountry.Name = "lblCountry"
            Me.lblCountry.Size = New System.Drawing.Size(56, 16)
            Me.lblCountry.TabIndex = 12
            Me.lblCountry.Text = "Country:"
            Me.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCountries
            '
            Me.cboCountries.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCountries.Caption = ""
            Me.cboCountries.CaptionHeight = 17
            Me.cboCountries.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCountries.ColumnCaptionHeight = 17
            Me.cboCountries.ColumnFooterHeight = 17
            Me.cboCountries.ContentHeight = 15
            Me.cboCountries.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCountries.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCountries.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCountries.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCountries.EditorHeight = 15
            Me.cboCountries.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboCountries.ItemHeight = 15
            Me.cboCountries.Location = New System.Drawing.Point(272, 120)
            Me.cboCountries.MatchEntryTimeout = CType(2000, Long)
            Me.cboCountries.MaxDropDownItems = CType(5, Short)
            Me.cboCountries.MaxLength = 32767
            Me.cboCountries.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCountries.Name = "cboCountries"
            Me.cboCountries.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCountries.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCountries.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCountries.Size = New System.Drawing.Size(184, 21)
            Me.cboCountries.TabIndex = 8
            Me.cboCountries.Text = "C1Combo1"
            Me.cboCountries.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'btnAddCust
            '
            Me.btnAddCust.BackColor = System.Drawing.Color.Blue
            Me.btnAddCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddCust.ForeColor = System.Drawing.Color.White
            Me.btnAddCust.Location = New System.Drawing.Point(496, 336)
            Me.btnAddCust.Name = "btnAddCust"
            Me.btnAddCust.Size = New System.Drawing.Size(192, 20)
            Me.btnAddCust.TabIndex = 4
            Me.btnAddCust.Text = "Add Customer"
            Me.btnAddCust.Visible = False
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.Label1.Location = New System.Drawing.Point(8, 74)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 16)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Existing Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboExistingCusts
            '
            Me.cboExistingCusts.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboExistingCusts.Caption = ""
            Me.cboExistingCusts.CaptionHeight = 17
            Me.cboExistingCusts.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboExistingCusts.ColumnCaptionHeight = 17
            Me.cboExistingCusts.ColumnFooterHeight = 17
            Me.cboExistingCusts.ContentHeight = 15
            Me.cboExistingCusts.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboExistingCusts.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboExistingCusts.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboExistingCusts.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboExistingCusts.EditorHeight = 15
            Me.cboExistingCusts.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboExistingCusts.ItemHeight = 15
            Me.cboExistingCusts.Location = New System.Drawing.Point(128, 72)
            Me.cboExistingCusts.MatchEntryTimeout = CType(2000, Long)
            Me.cboExistingCusts.MaxDropDownItems = CType(5, Short)
            Me.cboExistingCusts.MaxLength = 32767
            Me.cboExistingCusts.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboExistingCusts.Name = "cboExistingCusts"
            Me.cboExistingCusts.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboExistingCusts.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboExistingCusts.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboExistingCusts.Size = New System.Drawing.Size(360, 21)
            Me.cboExistingCusts.TabIndex = 1
            Me.cboExistingCusts.Text = "C1Combo1"
            Me.cboExistingCusts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.Label3.Location = New System.Drawing.Point(48, 6)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 18
            Me.Label3.Text = "Address(1):"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAddressSearch
            '
            Me.txtAddressSearch.Location = New System.Drawing.Point(128, 6)
            Me.txtAddressSearch.Name = "txtAddressSearch"
            Me.txtAddressSearch.Size = New System.Drawing.Size(296, 20)
            Me.txtAddressSearch.TabIndex = 6
            Me.txtAddressSearch.Text = ""
            '
            'btnAddressSearch
            '
            Me.btnAddressSearch.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnAddressSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddressSearch.ForeColor = System.Drawing.Color.Black
            Me.btnAddressSearch.Location = New System.Drawing.Point(432, 6)
            Me.btnAddressSearch.Name = "btnAddressSearch"
            Me.btnAddressSearch.Size = New System.Drawing.Size(56, 20)
            Me.btnAddressSearch.TabIndex = 7
            Me.btnAddressSearch.Text = "Search"
            '
            'btnNewCustomer
            '
            Me.btnNewCustomer.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnNewCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNewCustomer.ForeColor = System.Drawing.Color.Black
            Me.btnNewCustomer.Location = New System.Drawing.Point(392, 40)
            Me.btnNewCustomer.Name = "btnNewCustomer"
            Me.btnNewCustomer.Size = New System.Drawing.Size(96, 20)
            Me.btnNewCustomer.TabIndex = 9
            Me.btnNewCustomer.Text = "New Customer"
            '
            'btnGetExistingCust
            '
            Me.btnGetExistingCust.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnGetExistingCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnGetExistingCust.ForeColor = System.Drawing.Color.Black
            Me.btnGetExistingCust.Location = New System.Drawing.Point(128, 40)
            Me.btnGetExistingCust.Name = "btnGetExistingCust"
            Me.btnGetExistingCust.Size = New System.Drawing.Size(152, 20)
            Me.btnGetExistingCust.TabIndex = 8
            Me.btnGetExistingCust.Text = "Get Existing Customer(s)"
            '
            'btnSetCust
            '
            Me.btnSetCust.BackColor = System.Drawing.Color.Blue
            Me.btnSetCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSetCust.ForeColor = System.Drawing.Color.White
            Me.btnSetCust.Location = New System.Drawing.Point(16, 336)
            Me.btnSetCust.Name = "btnSetCust"
            Me.btnSetCust.Size = New System.Drawing.Size(472, 20)
            Me.btnSetCust.TabIndex = 5
            Me.btnSetCust.Text = "Select This Customer for Receving"
            Me.btnSetCust.Visible = False
            '
            'gbCreditCard
            '
            Me.gbCreditCard.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkEditCC, Me.pnlCreditCard, Me.btnEditCC})
            Me.gbCreditCard.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCreditCard.ForeColor = System.Drawing.Color.White
            Me.gbCreditCard.Location = New System.Drawing.Point(496, 96)
            Me.gbCreditCard.Name = "gbCreditCard"
            Me.gbCreditCard.Size = New System.Drawing.Size(192, 232)
            Me.gbCreditCard.TabIndex = 3
            Me.gbCreditCard.TabStop = False
            Me.gbCreditCard.Text = "Credit Card"
            '
            'chkEditCC
            '
            Me.chkEditCC.Location = New System.Drawing.Point(16, 208)
            Me.chkEditCC.Name = "chkEditCC"
            Me.chkEditCC.Size = New System.Drawing.Size(80, 16)
            Me.chkEditCC.TabIndex = 6
            Me.chkEditCC.Text = "Edit"
            '
            'pnlCreditCard
            '
            Me.pnlCreditCard.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label16, Me.txtCCSecurityCode, Me.txtCCNumber, Me.Label15, Me.Label14, Me.Label13, Me.cboCCExpMonth, Me.cboCCExpYear, Me.cboCCType})
            Me.pnlCreditCard.Location = New System.Drawing.Point(8, 16)
            Me.pnlCreditCard.Name = "pnlCreditCard"
            Me.pnlCreditCard.Size = New System.Drawing.Size(176, 184)
            Me.pnlCreditCard.TabIndex = 1
            '
            'Label16
            '
            Me.Label16.Location = New System.Drawing.Point(8, 144)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(96, 16)
            Me.Label16.TabIndex = 26
            Me.Label16.Text = "Expiration Date:"
            Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtCCSecurityCode
            '
            Me.txtCCSecurityCode.Location = New System.Drawing.Point(8, 120)
            Me.txtCCSecurityCode.MaxLength = 4
            Me.txtCCSecurityCode.Name = "txtCCSecurityCode"
            Me.txtCCSecurityCode.Size = New System.Drawing.Size(88, 20)
            Me.txtCCSecurityCode.TabIndex = 3
            Me.txtCCSecurityCode.Text = ""
            '
            'txtCCNumber
            '
            Me.txtCCNumber.Location = New System.Drawing.Point(8, 72)
            Me.txtCCNumber.MaxLength = 20
            Me.txtCCNumber.Name = "txtCCNumber"
            Me.txtCCNumber.Size = New System.Drawing.Size(160, 20)
            Me.txtCCNumber.TabIndex = 2
            Me.txtCCNumber.Text = ""
            '
            'Label15
            '
            Me.Label15.Location = New System.Drawing.Point(8, 104)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(96, 16)
            Me.Label15.TabIndex = 31
            Me.Label15.Text = "Security Code:"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(8, 56)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(80, 16)
            Me.Label14.TabIndex = 24
            Me.Label14.Text = "Card Number:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(8, 8)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(72, 16)
            Me.Label13.TabIndex = 25
            Me.Label13.Text = "Card Type:"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboCCExpMonth
            '
            Me.cboCCExpMonth.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCCExpMonth.Caption = ""
            Me.cboCCExpMonth.CaptionHeight = 17
            Me.cboCCExpMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCCExpMonth.ColumnCaptionHeight = 17
            Me.cboCCExpMonth.ColumnFooterHeight = 17
            Me.cboCCExpMonth.ContentHeight = 15
            Me.cboCCExpMonth.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCCExpMonth.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCCExpMonth.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCCExpMonth.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCCExpMonth.EditorHeight = 15
            Me.cboCCExpMonth.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboCCExpMonth.ItemHeight = 15
            Me.cboCCExpMonth.Location = New System.Drawing.Point(8, 160)
            Me.cboCCExpMonth.MatchEntryTimeout = CType(2000, Long)
            Me.cboCCExpMonth.MaxDropDownItems = CType(5, Short)
            Me.cboCCExpMonth.MaxLength = 32767
            Me.cboCCExpMonth.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCCExpMonth.Name = "cboCCExpMonth"
            Me.cboCCExpMonth.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCCExpMonth.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCCExpMonth.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCCExpMonth.Size = New System.Drawing.Size(56, 21)
            Me.cboCCExpMonth.TabIndex = 4
            Me.cboCCExpMonth.Text = "06"
            Me.cboCCExpMonth.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboCCExpYear
            '
            Me.cboCCExpYear.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCCExpYear.Caption = ""
            Me.cboCCExpYear.CaptionHeight = 17
            Me.cboCCExpYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCCExpYear.ColumnCaptionHeight = 17
            Me.cboCCExpYear.ColumnFooterHeight = 17
            Me.cboCCExpYear.ContentHeight = 15
            Me.cboCCExpYear.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCCExpYear.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCCExpYear.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCCExpYear.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCCExpYear.EditorHeight = 15
            Me.cboCCExpYear.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboCCExpYear.ItemHeight = 15
            Me.cboCCExpYear.Location = New System.Drawing.Point(72, 160)
            Me.cboCCExpYear.MatchEntryTimeout = CType(2000, Long)
            Me.cboCCExpYear.MaxDropDownItems = CType(5, Short)
            Me.cboCCExpYear.MaxLength = 32767
            Me.cboCCExpYear.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCCExpYear.Name = "cboCCExpYear"
            Me.cboCCExpYear.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCCExpYear.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCCExpYear.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCCExpYear.Size = New System.Drawing.Size(88, 21)
            Me.cboCCExpYear.TabIndex = 5
            Me.cboCCExpYear.Text = "2009"
            Me.cboCCExpYear.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'cboCCType
            '
            Me.cboCCType.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCCType.Caption = ""
            Me.cboCCType.CaptionHeight = 17
            Me.cboCCType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCCType.ColumnCaptionHeight = 17
            Me.cboCCType.ColumnFooterHeight = 17
            Me.cboCCType.ContentHeight = 15
            Me.cboCCType.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCCType.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCCType.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCCType.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCCType.EditorHeight = 15
            Me.cboCCType.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboCCType.ItemHeight = 15
            Me.cboCCType.Location = New System.Drawing.Point(8, 24)
            Me.cboCCType.MatchEntryTimeout = CType(2000, Long)
            Me.cboCCType.MaxDropDownItems = CType(5, Short)
            Me.cboCCType.MaxLength = 32767
            Me.cboCCType.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCCType.Name = "cboCCType"
            Me.cboCCType.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCCType.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCCType.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCCType.Size = New System.Drawing.Size(160, 21)
            Me.cboCCType.TabIndex = 1
            Me.cboCCType.Text = "C1Combo1"
            Me.cboCCType.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'btnEditCC
            '
            Me.btnEditCC.BackColor = System.Drawing.Color.Blue
            Me.btnEditCC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEditCC.ForeColor = System.Drawing.Color.White
            Me.btnEditCC.Location = New System.Drawing.Point(120, 204)
            Me.btnEditCC.Name = "btnEditCC"
            Me.btnEditCC.Size = New System.Drawing.Size(64, 20)
            Me.btnEditCC.TabIndex = 7
            Me.btnEditCC.Text = "Edit"
            Me.btnEditCC.Visible = False
            '
            'frmDCCollectCustInfo
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(694, 363)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbCreditCard, Me.btnSetCust, Me.btnGetExistingCust, Me.btnNewCustomer, Me.btnAddressSearch, Me.txtAddressSearch, Me.Label3, Me.Label1, Me.cboExistingCusts, Me.gbCustInfo, Me.btnAddCust})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmDCCollectCustInfo"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Customer Informatin"
            Me.gbCustInfo.ResumeLayout(False)
            CType(Me.cboNonWrtyRepair, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboStates, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCountries, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboExistingCusts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbCreditCard.ResumeLayout(False)
            Me.pnlCreditCard.ResumeLayout(False)
            CType(Me.cboCCExpMonth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCCExpYear, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCCType, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************
        Private Sub frmDCCollectCustInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                Generic.DisposeDT(dt)
                dt = Me._objDC.GetCustomersByPCo(Me._iPCoID)
                Misc.PopulateC1DropDownList(Me.cboExistingCusts, dt, "Name", "Cust_ID")
                If dt.Rows.Count = 1 Then Me.cboExistingCusts.SelectedValue = dt.Rows(0)("Cust_ID")

                Generic.DisposeDT(dt)
                dt = Me._objDC.GetState(True, False)
                Misc.PopulateC1DropDownList(Me.cboStates, dt, "State_Desc", "State_ID")
                Me.cboStates.SelectedValue = 0

                Generic.DisposeDT(dt)
                dt = Me._objDC.GetCountry(True)
                Misc.PopulateC1DropDownList(Me.cboCountries, dt, "Cntry_Name", "Cntry_ID")
                Me.cboCountries.SelectedValue = 161

                Generic.DisposeDT(dt)
                dt = Me._objDC.CreateYesNoDataTable()
                Misc.PopulateC1DropDownList(Me.cboNonWrtyRepair, dt, "Desc", "ID")
                'Me.cboNonWrtyRepair.Text = ""
                Me.cboNonWrtyRepair.SelectedValue = 1
                Me.cboNonWrtyRepair.Enabled = False

                Generic.DisposeDT(dt)
                dt = Me._objDC.GetCreditCardType(True)
                Misc.PopulateC1DropDownList(Me.cboCCType, dt, "CCType_Desc", "CCType_ID")
                Me.cboCCType.SelectedValue = 0

                Generic.DisposeDT(dt)
                dt = Me._objDC.GetCCExpMonths()
                Misc.PopulateC1DropDownList(Me.cboCCExpMonth, dt, "Month", "ID")
                Me.cboCCExpMonth.Text = ""

                Generic.DisposeDT(dt)
                dt = Me._objDC.GetCCExpYears()
                Misc.PopulateC1DropDownList(Me.cboCCExpYear, dt, "Year", "ID")
                Me.cboCCExpYear.Text = ""

                Me.btnAddCust.Visible = True
                Me.cboExistingCusts.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************
        Private Sub btnAddressSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddressSearch.Click
            Dim dt As DataTable

            Try
                Me.ProcessAddressSearch()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnGetExistingCust_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************
        Private Sub ProcessAddressSearch()
            Dim dt As DataTable

            Try
                ClearCustomerInfo()

                dt = Me._objDC.SearchCustByAddress(Me._iPCoID, Me.txtAddressSearch.Text.Trim)
                Misc.PopulateC1DropDownList(Me.cboExistingCusts, dt, "Name", "Cust_ID")
                If dt.Rows.Count = 1 Then Me.cboExistingCusts.SelectedValue = dt.Rows(0)("Cust_ID")

                Me.cboExistingCusts.Focus()
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************
        Private Sub btnGetExistingCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetExistingCust.Click
            Dim dt As DataTable

            Try
                ClearCustomerInfo()
                dt = Me._objDC.GetCustomersByPCo(Me._iPCoID)
                Misc.PopulateC1DropDownList(Me.cboExistingCusts, dt, "Name", "Cust_ID")
                If dt.Rows.Count = 1 Then Me.cboExistingCusts.SelectedValue = dt.Rows(0)("Cust_ID")

                Me.cboExistingCusts.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnGetExistingCust_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************
        Private Sub btnNewCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCustomer.Click
            Me.txtAddressSearch.Text = ""
            Me.cboExistingCusts.DataSource = Nothing
            Me.cboExistingCusts.Text = ""

            ClearCustomerInfo()
            Me.btnAddCust.Visible = True
            Me.btnSetCust.Visible = False
            Me.txtFirstName.Focus()
        End Sub

        '**************************************************************
        Private Sub ClearCustomerInfo()
            'Customer
            Me.txtFirstName.Text = ""
            Me.txtLastName.Text = ""
            Me.txtAddress1.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtCity.Text = ""
            Me.cboStates.SelectedValue = 0
            Me.txtZipCode.Text = ""
            Me.cboCountries.SelectedValue = 161
            Me.txtPhoneNumber.Text = ""
            Me.txtFaxNumber.Text = ""
            'Me.cboNonWrtyRepair.Text = ""
            Me.gbCustInfo.Enabled = True
            Me._iLocID = 0
            Me._iCustID = 0

            'Credit card
            Me.cboCCType.SelectedValue = 0
            Me.txtCCNumber.Text = ""
            Me.txtCCSecurityCode.Text = ""
            Me.cboCCExpMonth.SelectedValue = 0
            Me.cboCCExpMonth.Text = ""
            Me.cboCCExpYear.SelectedValue = 0
            Me.cboCCExpYear.Text = ""
            Me.pnlCreditCard.Enabled = True
            Me.chkEditCC.Visible = False
            Me.chkEditCC.Checked = False
            Me.btnEditCC.Visible = False

            Me.btnAddCust.Visible = True
        End Sub

        '**************************************************************
        Private Sub cbos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboNonWrtyRepair.KeyUp, cboStates.KeyUp, cboCountries.KeyUp, cboExistingCusts.KeyUp, cboCCType.KeyUp, cboCCExpMonth.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name().ToString.Trim = "cboExistingCusts" AndAlso Not IsNothing(Me.cboExistingCusts.SelectedValue) AndAlso Me.cboExistingCusts.SelectedValue > 0 Then
                        Me.PopulateCustInfo(Me.cboExistingCusts.SelectedValue)
                    ElseIf sender.name().ToString.Trim = "cboCountries" Then
                        If Me.cboCountries.SelectedValue > 0 Then
                            Me.txtPhoneNumber.SelectAll()
                            Me.txtPhoneNumber.Focus()
                        End If
                    ElseIf sender.name().ToString.Trim = "cboStates" Then
                        If Me.cboStates.SelectedValue > 0 Then
                            Me.txtZipCode.SelectAll()
                            Me.txtZipCode.Focus()
                        End If
                        'ElseIf sender.name().ToString.Trim = "cboNonWrtyRepair" Then
                        '    If Me.cboNonWrtyRepair.Text.Trim.Length > 0 AndAlso (Me.cboNonWrtyRepair.Text.Trim.ToUpper = "YES" Or Me.cboNonWrtyRepair.Text.Trim.ToUpper = "NO") Then Me.cboCCType.Focus()
                    ElseIf sender.name().ToString.Trim = "cboCCType" Then
                        If Me.cboCCType.Text.Trim.Length > 0 AndAlso (Not IsNothing(Me.cboCCType.SelectedValue) And Me.cboCCType.SelectedValue > 0) Then Me.txtCCNumber.Focus()
                    ElseIf sender.name().ToString.Trim = "cboCCExpMonth" Then
                        If Me.cboCCExpMonth.Text.Trim.Length > 0 AndAlso (Not IsNothing(Me.cboCCExpMonth.SelectedValue) And Me.cboCCExpMonth.SelectedValue > 0) Then Me.cboCCExpYear.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name().ToString.Trim & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************
        Private Sub PopulateCustInfo(ByVal iCustID As Integer)
            Dim dt, dtCC As DataTable
            Dim R1 As DataRow
            Try
                dt = Me._objDC.GetCustLocation(iCustID)
                If dt.Rows.Count > 0 Then
                    Me.ClearCustomerInfo()

                    R1 = Me.cboExistingCusts.DataSource.Table.Select("Cust_ID = " & iCustID)(0)
                    Me.txtFirstName.Text = R1("Cust_Name1")
                    If Not IsDBNull(R1("Cust_ID")) Then Me.txtFirstName.Text = R1("Cust_ID")
                    Me.txtAddress1.Text = dt.Rows(0)("Loc_Address1")
                    If Not IsDBNull(dt.Rows(0)("Loc_Address2")) Then Me.txtAddress2.Text = dt.Rows(0)("Loc_Address2")
                    Me.txtCity.Text = dt.Rows(0)("Loc_City")
                    Me.cboStates.SelectedValue = dt.Rows(0)("State_ID")
                    Me.cboCountries.SelectedValue = dt.Rows(0)("Cntry_ID")
                    If Not IsDBNull(dt.Rows(0)("Loc_Phone")) Then Me.txtPhoneNumber.Text = dt.Rows(0)("Loc_Phone")
                    If Not IsDBNull(dt.Rows(0)("Loc_Fax")) Then Me.txtFaxNumber.Text = dt.Rows(0)("Loc_Fax")
                    If Not IsDBNull(dt.Rows(0)("Loc_Email")) Then Me.txtEmailAddress.Text = dt.Rows(0)("Loc_Email")
                    Me.cboNonWrtyRepair.SelectedValue = R1("Cust_RepairNonWrty")
                    Me._iLocID = dt.Rows(0)("Loc_ID")
                    'Me._iCustID = iCustID
                    Me.gbCustInfo.Enabled = False

                    dtCC = Me._objDC.GetLastCreditCardInfo(iCustID)
                    If dtCC.Rows.Count > 0 Then
                        Me.cboCCType.SelectedValue = dtCC.Rows(0)("CCardType_ID")
                        Me.txtCCNumber.Text = dtCC.Rows(0)("CreditCard_Num")
                        Me.txtCCSecurityCode.Text = dtCC.Rows(0)("CreditCard_AuthCode")
                        Me.cboCCExpMonth.SelectedValue = Microsoft.VisualBasic.Left(dtCC.Rows(0)("CreditCard_ExpDate").ToString.Trim, 2)
                        Me.cboCCExpYear.SelectedValue = Microsoft.VisualBasic.Right(dtCC.Rows(0)("CreditCard_ExpDate").ToString.Trim, 2)
                        Me.pnlCreditCard.Enabled = False
                        Me.chkEditCC.Visible = True
                    End If

                    Me.btnAddCust.Visible = False
                    Me.btnSetCust.Visible = True
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                Generic.DisposeDT(dtCC)
            End Try
        End Sub

        '**************************************************************
        Private Sub txts_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAddressSearch.KeyUp, txtFirstName.KeyUp, txtLastName.KeyUp, txtAddress1.KeyUp, txtAddress2.KeyUp, txtCity.KeyUp, txtZipCode.KeyUp, txtPhoneNumber.KeyUp, txtFaxNumber.KeyUp, txtEmailAddress.KeyUp, txtCCNumber.KeyUp, txtCCSecurityCode.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name().ToString.Trim = "txtAddressSearch" AndAlso Me.txtAddressSearch.Text.Trim.Length > 0 Then
                        Me.ProcessAddressSearch()
                    ElseIf sender.name().ToString.Trim = "txtFirstName" AndAlso Me.txtFirstName.Text.Trim.Length > 0 Then
                        Me.txtLastName.SelectAll()
                        Me.txtLastName.Focus()
                    ElseIf sender.name().ToString.Trim = "txtLastName" AndAlso Me.txtLastName.Text.Trim.Length > 0 Then
                        Me.txtAddress1.SelectAll()
                        Me.txtAddress1.Focus()
                    ElseIf sender.name().ToString.Trim = "txtAddress1" AndAlso Me.txtAddress1.Text.Trim.Length > 0 Then
                        Me.txtAddress2.SelectAll()
                        Me.txtAddress2.Focus()
                    ElseIf sender.name().ToString.Trim = "txtAddress2" Then
                        Me.txtCity.SelectAll()
                        Me.txtCity.Focus()
                    ElseIf sender.name().ToString.Trim = "txtCity" Then
                        Me.cboStates.SelectAll()
                        Me.cboStates.Focus()
                    ElseIf sender.name().ToString.Trim = "txtZipCode" Then
                        Me.cboCountries.SelectAll()
                        Me.cboCountries.Focus()
                    ElseIf sender.name().ToString.Trim = "txtPhoneNumber" Then
                        Me.txtFaxNumber.SelectAll()
                        Me.txtFaxNumber.Focus()
                    ElseIf sender.name().ToString.Trim = "txtFaxNumber" Then
                        Me.txtEmailAddress.SelectAll()
                        Me.txtEmailAddress.Focus()
                    ElseIf sender.name().ToString.Trim = "txtEmailAddress" Then
                        'Me.cboNonWrtyRepair.SelectAll()
                        'Me.cboNonWrtyRepair.Focus()
                        Me.cboCCType.SelectAll()
                        Me.cboCCType.Focus()
                    ElseIf sender.name().ToString.Trim = "txtCCNumber" Then
                        Me.txtCCSecurityCode.SelectAll()
                        Me.txtCCSecurityCode.Focus()
                    ElseIf sender.name().ToString.Trim = "txtCCSecurityCode" Then
                        Me.cboCCExpMonth.SelectAll()
                        Me.cboCCExpMonth.SelectedValue = 0
                        Me.cboCCExpMonth.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, sender.name().ToString.Trim & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************
        Private Sub btnSetCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetCust.Click
            If Me.cboExistingCusts.SelectedValue > 0 Then
                If Me._iLocID = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtCCNumber.Text.Trim.Length = 0 Then
                    MessageBox.Show("Credit card number is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtCCSecurityCode.Text.Trim.Length = 0 Then
                    MessageBox.Show("Security code is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf MessageBox.Show("Are you sure you want select customer """ & Me.cboExistingCusts.Text & """?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    Me._iCustID = Me.cboExistingCusts.SelectedValue
                    Me.Close()
                End If
            End If
        End Sub

        '**************************************************************
        Private Sub cboExistingCusts_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboExistingCusts.Enter
            ClearCustomerInfo()
        End Sub

        '**************************************************************
        Private Sub btnAddCust_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCust.Click
            Try
                If Me.txtAddress1.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtAddress1.Focus()
                ElseIf Me.txtCity.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter City.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCity.Focus()
                ElseIf Me.cboStates.SelectedValue = 0 Then
                    MessageBox.Show("Please select State.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboStates.Focus()
                ElseIf Me.txtZipCode.Text.Trim.Length = 0 Or Me.txtZipCode.Text.Trim.Length < 5 Or Me.IsNumberic(Me.txtZipCode.Text.Trim) = False Then
                    MessageBox.Show("Incorrect Zipcode number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtZipCode.SelectAll()
                    Me.txtZipCode.Focus()
                ElseIf Me.cboCountries.SelectedValue = 0 Then
                    MessageBox.Show("Please select Country.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCountries.Focus()
                ElseIf Me.txtPhoneNumber.Text.Trim.Length <> 12 Then
                    MessageBox.Show("Incorrect phone number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPhoneNumber.Focus()
                ElseIf Me.IsValidPhoneFaxNo(Me.txtPhoneNumber.Text.Trim) = False Then
                    MessageBox.Show("Incorrect phone number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPhoneNumber.Focus()
                ElseIf Me.txtFaxNumber.Text.Trim.Length > 0 AndAlso Me.txtFaxNumber.Text.Trim.Length <> 12 Then
                    MessageBox.Show("Incorrect fax number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtPhoneNumber.Focus()
                ElseIf Me.txtFaxNumber.Text.Trim.Length > 0 AndAlso Me.IsValidPhoneFaxNo(Me.txtFaxNumber.Text.Trim) = False Then
                    MessageBox.Show("Incorrect fax number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtFaxNumber.Focus()
                ElseIf IsNothing(Me.cboCCType.SelectedValue) OrElse Me.cboCCType.SelectedValue = 0 Then
                    MessageBox.Show("Please select Credit Card Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCCType.Focus()
                ElseIf Me._objDC.IsValidCreditCardNo(Me.txtCCNumber.Text.Trim, Me.cboCCType.DataSource.Table.Select("CCType_ID = " & Me.cboCCType.SelectedValue)(0)) = False Then
                    'MessageBox.Show("Credit Card number must be " & Me.cboCCType.Columns("CCType_Length").CellValue(Me.cboCCType.Row) & " digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCCNumber.SelectAll()
                    Me.txtCCNumber.Focus()
                ElseIf Me.txtCCSecurityCode.Text.Trim.Length <> Me.cboCCType.Columns("CCType_SCLength").CellValue(Me.cboCCType.Row) Then
                    MessageBox.Show("Security Code must be " & Me.cboCCType.Columns("CCType_SCLength").CellValue(Me.cboCCType.Row) & " digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCCSecurityCode.SelectAll()
                    Me.txtCCSecurityCode.Focus()
                ElseIf IsNothing(Me.cboCCExpMonth.SelectedValue) OrElse Me.cboCCExpMonth.SelectedValue = 0 Then
                    MessageBox.Show("Please select Credit Card Expiration Month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCCExpMonth.Focus()
                ElseIf IsNothing(Me.cboCCExpYear.SelectedValue) OrElse Me.cboCCExpYear.SelectedValue = 0 Then
                    MessageBox.Show("Please select Credit Card Expiration Year.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCCExpYear.Focus()
                ElseIf CInt(Me.cboCCExpYear.Text) = CInt(Generic.GetThisYear) And CInt(Me.cboCCExpMonth.SelectedValue) < CInt(Generic.GetThisMonth()) Then
                    MessageBox.Show("Invalid Expiration Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCCExpMonth.Focus()
                Else
                    Me._objDC.CreateNewCustomer(Me._iCustID, Me._iLocID, Me.txtFirstName.Text.Trim.ToUpper, Me.txtLastName.Text.Trim.ToUpper, Me.txtAddress1.Text.Trim, Me.txtAddress2.Text.Trim, Me.txtCity.Text.Trim.ToUpper, Me.cboStates.SelectedValue, Me.txtZipCode.Text.Trim, Me.cboCountries.SelectedValue, Me.txtPhoneNumber.Text.Trim, Me.txtFaxNumber.Text.Trim, Me.cboNonWrtyRepair.SelectedValue, Me.txtEmailAddress.Text.Trim, Me.cboCCType.SelectedValue, Me.txtCCNumber.Text.Trim, Me.txtCCSecurityCode.Text.Trim, Me.cboCCExpMonth.SelectedValue & "/" & Me.cboCCExpYear.SelectedValue)
                    If Me._iCustID > 0 And Me._iLocID > 0 Then
                        Me.Close()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddCust_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************
        Private Function IsNumberic(ByVal strVal As String) As Boolean
            Dim cStringChar As Char
            Dim i As Integer = 0

            Try
                For i = 1 To strVal.Length
                    cStringChar = CChar(Mid(strVal, i, 1))
                    If Char.IsDigit(cStringChar) = False Then
                        Return False
                    End If
                Next i

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Private Function IsValidPhoneFaxNo(ByVal strVal As String) As Boolean
            Dim cStringChar As Char
            Dim i As Integer = 0

            Try
                strVal = strVal.Replace("-", "").Trim
                strVal = strVal.Replace("-", "").Trim
                If strVal.Length <> 10 Then
                    Return False
                Else
                    For i = 1 To strVal.Length
                        cStringChar = CChar(Mid(strVal, i, 1))
                        If Char.IsDigit(cStringChar) = False Then
                            Return False
                        End If
                    Next i
                End If

                Return True
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Private Sub FormatPhoneFaxNo(ByRef ctrTextbox As TextBox)
            If ctrTextbox.Text.Trim.Length >= 10 Then
                ctrTextbox.Text = ctrTextbox.Text.Trim.Replace("-", "")
                ctrTextbox.Text = ctrTextbox.Text.Trim.Replace(".", "")
                If ctrTextbox.Text.Trim.Length > 3 Then ctrTextbox.Text = ctrTextbox.Text.Trim.Insert(3, "-")
                If ctrTextbox.Text.Trim.Length > 7 Then ctrTextbox.Text = ctrTextbox.Text.Trim.Insert(7, "-")
            End If
        End Sub

        '**************************************************************
        Private Sub txtPhoneFaxNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPhoneNumber.Leave, txtFaxNumber.Leave
            If sender.name() = "txtPhoneNumber" Then
                FormatPhoneFaxNo(Me.txtPhoneNumber)
            ElseIf sender.name() = "txtFaxNumber" Then
                FormatPhoneFaxNo(Me.txtFaxNumber)
            End If
        End Sub

        '**************************************************************
        Private Sub txtPhoneFaxZipcodeNumber_CCNoSC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPhoneNumber.KeyPress, txtFaxNumber.KeyPress, txtZipCode.KeyPress, txtCCNumber.KeyPress, txtCCSecurityCode.KeyPress
            If (sender.name.ToString = "txtPhoneNumber" Or sender.name.ToString = "txtFaxNumber") AndAlso Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = "-" Or e.KeyChar = "." Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            ElseIf (sender.name.ToString = "txtZipCode" Or sender.name.ToString = "txtCCSecurityCode" Or sender.name.ToString = "txtCCNumber") AndAlso Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End Sub

        '*************************************************************
        Private Sub chkEditCC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkEditCC.CheckedChanged
            If Me.chkEditCC.Checked = True Then
                Me.pnlCreditCard.Enabled = True
                Me.btnEditCC.Visible = True
            Else
                If Me._iCustID > 0 And Me._iLocID > 0 Then Me.pnlCreditCard.Enabled = False
                Me.btnEditCC.Visible = False
            End If
        End Sub

        '*************************************************************
        Private Sub btnEditCC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditCC.Click
            Dim i As Integer
            Try
                If IsNothing(Me.cboExistingCusts) AndAlso Me.cboExistingCusts.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer and press enter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboExistingCusts.Focus()
                ElseIf IsNothing(Me.cboCCType.SelectedValue) OrElse Me.cboCCType.SelectedValue = 0 Then
                    MessageBox.Show("Please select Credit Card Type.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCCType.Focus()
                ElseIf Me._objDC.IsValidCreditCardNo(Me.txtCCNumber.Text.Trim, Me.cboCCType.DataSource.Table.Select("CCType_ID = " & Me.cboCCType.SelectedValue)(0)) = False Then
                    'MessageBox.Show("Credit Card number must be " & Me.cboCCType.Columns("CCType_Length").CellValue(Me.cboCCType.Row) & " digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCCNumber.SelectAll()
                    Me.txtCCNumber.Focus()
                ElseIf Me.txtCCSecurityCode.Text.Trim.Length <> Me.cboCCType.Columns("CCType_SCLength").CellValue(Me.cboCCType.Row) Then
                    MessageBox.Show("Credit Card number must be " & Me.cboCCType.Columns("CCType_SCLength").CellValue(Me.cboCCType.Row) & " digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCCSecurityCode.SelectAll()
                    Me.txtCCSecurityCode.Focus()
                ElseIf IsNothing(Me.cboCCExpMonth.SelectedValue) OrElse Me.cboCCExpMonth.SelectedValue = 0 Then
                    MessageBox.Show("Please select Credit Card Expiration Month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCCExpMonth.Focus()
                ElseIf IsNothing(Me.cboCCExpYear.SelectedValue) OrElse Me.cboCCExpYear.SelectedValue = 0 Then
                    MessageBox.Show("Please select Credit Card Expiration Year.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCCExpYear.Focus()
                ElseIf CInt(Me.cboCCExpYear.Text) = CInt(Generic.GetThisYear) And CInt(Me.cboCCExpMonth.SelectedValue) < CInt(Generic.GetThisMonth()) Then
                    MessageBox.Show("Invalid Expiration Date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCCExpMonth.Focus()
                Else
                    i = Me._objDC.InsertUpdateCreditCard(Me.cboExistingCusts.SelectedValue, Me.cboCCType.SelectedValue, Me.txtCCNumber.Text.Trim, Me.txtCCSecurityCode.Text.Trim, Me.cboCCExpMonth.SelectedValue & "/" & Me.cboCCExpYear.SelectedValue)
                    'If i > 0 Then
                    MessageBox.Show("Update is completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnEditCC.Visible = False
                    Me.pnlCreditCard.Enabled = False
                    'End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnEditCC_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************

    End Class
End Namespace