Imports PSS.Core
Imports PSS.Data

Namespace Gui.Receiving

    Public Class frmEndUserUpdate
        Inherits System.Windows.Forms.Form

        Public valCust As Int32
        Public valLoc As Int32
        Public valCC As Int32
        Public valDevice As Integer

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
        Friend WithEvents lblParentCompany As System.Windows.Forms.Label
        Friend WithEvents grpCCInfo As System.Windows.Forms.GroupBox
        Friend WithEvents cboCCType As System.Windows.Forms.ComboBox
        Friend WithEvents txtExpirationDate As System.Windows.Forms.TextBox
        Friend WithEvents txtCCNumber As System.Windows.Forms.TextBox
        Friend WithEvents lblExpirationDate As System.Windows.Forms.Label
        Friend WithEvents lblCCNumber As System.Windows.Forms.Label
        Friend WithEvents lblCCType As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents txtMemo As System.Windows.Forms.TextBox
        Friend WithEvents cboLCDFlipReplaced As System.Windows.Forms.ComboBox
        Friend WithEvents cboNonWrtyRepair As System.Windows.Forms.ComboBox
        Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
        Friend WithEvents lblMemo As System.Windows.Forms.Label
        Friend WithEvents lblLCDFlipReplaced As System.Windows.Forms.Label
        Friend WithEvents lblNonWrtyRepair As System.Windows.Forms.Label
        Friend WithEvents lblPhoneNumber As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
        Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
        Friend WithEvents cboState As System.Windows.Forms.ComboBox
        Friend WithEvents txtCity As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
        Friend WithEvents txtLastName As System.Windows.Forms.TextBox
        Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
        Friend WithEvents lblCountry As System.Windows.Forms.Label
        Friend WithEvents lblZipCode As System.Windows.Forms.Label
        Friend WithEvents lblState As System.Windows.Forms.Label
        Friend WithEvents lblCity As System.Windows.Forms.Label
        Friend WithEvents lblAddress2 As System.Windows.Forms.Label
        Friend WithEvents lblAddress1 As System.Windows.Forms.Label
        Friend WithEvents lblLastName As System.Windows.Forms.Label
        Friend WithEvents lblFirstName As System.Windows.Forms.Label
        Friend WithEvents lblExpDateFormat As System.Windows.Forms.Label
        Friend WithEvents btnReturn As System.Windows.Forms.Button
        Friend WithEvents cboEndUser As System.Windows.Forms.ComboBox
        Friend WithEvents SelectEndUser As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents txtCCAuthCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCCAuthCode As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmEndUserUpdate))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblParentCompany = New System.Windows.Forms.Label()
            Me.cboEndUser = New System.Windows.Forms.ComboBox()
            Me.grpCCInfo = New System.Windows.Forms.GroupBox()
            Me.txtCCAuthCode = New System.Windows.Forms.TextBox()
            Me.lblCCAuthCode = New System.Windows.Forms.Label()
            Me.lblExpDateFormat = New System.Windows.Forms.Label()
            Me.cboCCType = New System.Windows.Forms.ComboBox()
            Me.txtExpirationDate = New System.Windows.Forms.TextBox()
            Me.txtCCNumber = New System.Windows.Forms.TextBox()
            Me.lblExpirationDate = New System.Windows.Forms.Label()
            Me.lblCCNumber = New System.Windows.Forms.Label()
            Me.lblCCType = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.txtMemo = New System.Windows.Forms.TextBox()
            Me.cboLCDFlipReplaced = New System.Windows.Forms.ComboBox()
            Me.cboNonWrtyRepair = New System.Windows.Forms.ComboBox()
            Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
            Me.lblMemo = New System.Windows.Forms.Label()
            Me.lblLCDFlipReplaced = New System.Windows.Forms.Label()
            Me.lblNonWrtyRepair = New System.Windows.Forms.Label()
            Me.lblPhoneNumber = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.cboCountry = New System.Windows.Forms.ComboBox()
            Me.txtZipCode = New System.Windows.Forms.TextBox()
            Me.cboState = New System.Windows.Forms.ComboBox()
            Me.txtCity = New System.Windows.Forms.TextBox()
            Me.txtAddress2 = New System.Windows.Forms.TextBox()
            Me.txtAddress1 = New System.Windows.Forms.TextBox()
            Me.txtLastName = New System.Windows.Forms.TextBox()
            Me.txtFirstName = New System.Windows.Forms.TextBox()
            Me.lblCountry = New System.Windows.Forms.Label()
            Me.lblZipCode = New System.Windows.Forms.Label()
            Me.lblState = New System.Windows.Forms.Label()
            Me.lblCity = New System.Windows.Forms.Label()
            Me.lblAddress2 = New System.Windows.Forms.Label()
            Me.lblAddress1 = New System.Windows.Forms.Label()
            Me.lblLastName = New System.Windows.Forms.Label()
            Me.lblFirstName = New System.Windows.Forms.Label()
            Me.btnReturn = New System.Windows.Forms.Button()
            Me.SelectEndUser = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.grpCCInfo.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.SelectEndUser, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblParentCompany
            '
            Me.lblParentCompany.Name = "lblParentCompany"
            Me.lblParentCompany.TabIndex = 24
            '
            'cboEndUser
            '
            Me.cboEndUser.Location = New System.Drawing.Point(200, 16)
            Me.cboEndUser.Name = "cboEndUser"
            Me.cboEndUser.Size = New System.Drawing.Size(464, 21)
            Me.cboEndUser.TabIndex = 1
            '
            'grpCCInfo
            '
            Me.grpCCInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCCAuthCode, Me.lblCCAuthCode, Me.lblExpDateFormat, Me.cboCCType, Me.txtExpirationDate, Me.txtCCNumber, Me.lblExpirationDate, Me.lblCCNumber, Me.lblCCType})
            Me.grpCCInfo.Location = New System.Drawing.Point(408, 264)
            Me.grpCCInfo.Name = "grpCCInfo"
            Me.grpCCInfo.Size = New System.Drawing.Size(256, 112)
            Me.grpCCInfo.TabIndex = 4
            Me.grpCCInfo.TabStop = False
            '
            'txtCCAuthCode
            '
            Me.txtCCAuthCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCCAuthCode.Location = New System.Drawing.Point(128, 64)
            Me.txtCCAuthCode.Name = "txtCCAuthCode"
            Me.txtCCAuthCode.Size = New System.Drawing.Size(64, 20)
            Me.txtCCAuthCode.TabIndex = 16
            Me.txtCCAuthCode.Text = ""
            '
            'lblCCAuthCode
            '
            Me.lblCCAuthCode.Location = New System.Drawing.Point(8, 64)
            Me.lblCCAuthCode.Name = "lblCCAuthCode"
            Me.lblCCAuthCode.Size = New System.Drawing.Size(112, 16)
            Me.lblCCAuthCode.TabIndex = 23
            Me.lblCCAuthCode.Text = "Authorization Code:"
            Me.lblCCAuthCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblExpDateFormat
            '
            Me.lblExpDateFormat.Location = New System.Drawing.Point(200, 88)
            Me.lblExpDateFormat.Name = "lblExpDateFormat"
            Me.lblExpDateFormat.Size = New System.Drawing.Size(48, 16)
            Me.lblExpDateFormat.TabIndex = 22
            Me.lblExpDateFormat.Text = "(mm/yy)"
            Me.lblExpDateFormat.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'cboCCType
            '
            Me.cboCCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCCType.Location = New System.Drawing.Point(128, 16)
            Me.cboCCType.Name = "cboCCType"
            Me.cboCCType.Size = New System.Drawing.Size(121, 21)
            Me.cboCCType.TabIndex = 14
            '
            'txtExpirationDate
            '
            Me.txtExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtExpirationDate.Location = New System.Drawing.Point(128, 88)
            Me.txtExpirationDate.Name = "txtExpirationDate"
            Me.txtExpirationDate.Size = New System.Drawing.Size(64, 20)
            Me.txtExpirationDate.TabIndex = 17
            Me.txtExpirationDate.Text = ""
            '
            'txtCCNumber
            '
            Me.txtCCNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCCNumber.Location = New System.Drawing.Point(128, 40)
            Me.txtCCNumber.Name = "txtCCNumber"
            Me.txtCCNumber.Size = New System.Drawing.Size(120, 20)
            Me.txtCCNumber.TabIndex = 15
            Me.txtCCNumber.Text = ""
            '
            'lblExpirationDate
            '
            Me.lblExpirationDate.Location = New System.Drawing.Point(8, 88)
            Me.lblExpirationDate.Name = "lblExpirationDate"
            Me.lblExpirationDate.Size = New System.Drawing.Size(112, 23)
            Me.lblExpirationDate.TabIndex = 0
            Me.lblExpirationDate.Text = "Expiration Date:"
            Me.lblExpirationDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCCNumber
            '
            Me.lblCCNumber.Location = New System.Drawing.Point(8, 40)
            Me.lblCCNumber.Name = "lblCCNumber"
            Me.lblCCNumber.Size = New System.Drawing.Size(112, 16)
            Me.lblCCNumber.TabIndex = 0
            Me.lblCCNumber.Text = "Credit Card Number:"
            Me.lblCCNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCCType
            '
            Me.lblCCType.Location = New System.Drawing.Point(8, 16)
            Me.lblCCType.Name = "lblCCType"
            Me.lblCCType.Size = New System.Drawing.Size(112, 16)
            Me.lblCCType.TabIndex = 0
            Me.lblCCType.Text = "Credit Card Type:"
            Me.lblCCType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMemo, Me.cboLCDFlipReplaced, Me.cboNonWrtyRepair, Me.txtPhoneNumber, Me.lblMemo, Me.lblLCDFlipReplaced, Me.lblNonWrtyRepair, Me.lblPhoneNumber})
            Me.GroupBox1.Location = New System.Drawing.Point(136, 264)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(264, 144)
            Me.GroupBox1.TabIndex = 3
            Me.GroupBox1.TabStop = False
            '
            'txtMemo
            '
            Me.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMemo.Location = New System.Drawing.Point(64, 88)
            Me.txtMemo.Multiline = True
            Me.txtMemo.Name = "txtMemo"
            Me.txtMemo.Size = New System.Drawing.Size(184, 48)
            Me.txtMemo.TabIndex = 13
            Me.txtMemo.Text = ""
            '
            'cboLCDFlipReplaced
            '
            Me.cboLCDFlipReplaced.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboLCDFlipReplaced.Location = New System.Drawing.Point(144, 64)
            Me.cboLCDFlipReplaced.Name = "cboLCDFlipReplaced"
            Me.cboLCDFlipReplaced.Size = New System.Drawing.Size(104, 21)
            Me.cboLCDFlipReplaced.TabIndex = 12
            '
            'cboNonWrtyRepair
            '
            Me.cboNonWrtyRepair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboNonWrtyRepair.Location = New System.Drawing.Point(144, 40)
            Me.cboNonWrtyRepair.Name = "cboNonWrtyRepair"
            Me.cboNonWrtyRepair.Size = New System.Drawing.Size(104, 21)
            Me.cboNonWrtyRepair.TabIndex = 11
            '
            'txtPhoneNumber
            '
            Me.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPhoneNumber.Location = New System.Drawing.Point(144, 16)
            Me.txtPhoneNumber.Name = "txtPhoneNumber"
            Me.txtPhoneNumber.TabIndex = 10
            Me.txtPhoneNumber.Text = ""
            '
            'lblMemo
            '
            Me.lblMemo.Location = New System.Drawing.Point(16, 88)
            Me.lblMemo.Name = "lblMemo"
            Me.lblMemo.Size = New System.Drawing.Size(40, 16)
            Me.lblMemo.TabIndex = 0
            Me.lblMemo.Text = "Memo"
            Me.lblMemo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLCDFlipReplaced
            '
            Me.lblLCDFlipReplaced.Location = New System.Drawing.Point(16, 64)
            Me.lblLCDFlipReplaced.Name = "lblLCDFlipReplaced"
            Me.lblLCDFlipReplaced.Size = New System.Drawing.Size(120, 16)
            Me.lblLCDFlipReplaced.TabIndex = 0
            Me.lblLCDFlipReplaced.Text = "LCD Flip Replaced:"
            Me.lblLCDFlipReplaced.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNonWrtyRepair
            '
            Me.lblNonWrtyRepair.Location = New System.Drawing.Point(16, 40)
            Me.lblNonWrtyRepair.Name = "lblNonWrtyRepair"
            Me.lblNonWrtyRepair.Size = New System.Drawing.Size(120, 16)
            Me.lblNonWrtyRepair.TabIndex = 0
            Me.lblNonWrtyRepair.Text = "Non-Warranty Repair:"
            Me.lblNonWrtyRepair.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPhoneNumber
            '
            Me.lblPhoneNumber.Location = New System.Drawing.Point(16, 16)
            Me.lblPhoneNumber.Name = "lblPhoneNumber"
            Me.lblPhoneNumber.Size = New System.Drawing.Size(120, 16)
            Me.lblPhoneNumber.TabIndex = 0
            Me.lblPhoneNumber.Text = "Phone Number:"
            Me.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCountry, Me.txtZipCode, Me.cboState, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.txtLastName, Me.lblCountry, Me.lblZipCode, Me.lblState, Me.lblCity, Me.lblAddress2, Me.lblAddress1, Me.lblLastName, Me.lblFirstName, Me.txtFirstName})
            Me.GroupBox2.Location = New System.Drawing.Point(136, 112)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(528, 144)
            Me.GroupBox2.TabIndex = 2
            Me.GroupBox2.TabStop = False
            '
            'cboCountry
            '
            Me.cboCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCountry.Location = New System.Drawing.Point(96, 112)
            Me.cboCountry.Name = "cboCountry"
            Me.cboCountry.Size = New System.Drawing.Size(400, 21)
            Me.cboCountry.TabIndex = 9
            '
            'txtZipCode
            '
            Me.txtZipCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtZipCode.Location = New System.Drawing.Point(400, 88)
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.Size = New System.Drawing.Size(96, 20)
            Me.txtZipCode.TabIndex = 8
            Me.txtZipCode.Text = ""
            '
            'cboState
            '
            Me.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboState.Location = New System.Drawing.Point(272, 88)
            Me.cboState.Name = "cboState"
            Me.cboState.Size = New System.Drawing.Size(56, 21)
            Me.cboState.TabIndex = 7
            '
            'txtCity
            '
            Me.txtCity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCity.Location = New System.Drawing.Point(96, 88)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(128, 20)
            Me.txtCity.TabIndex = 6
            Me.txtCity.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAddress2.Location = New System.Drawing.Point(96, 64)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.Size = New System.Drawing.Size(400, 20)
            Me.txtAddress2.TabIndex = 5
            Me.txtAddress2.Text = ""
            '
            'txtAddress1
            '
            Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAddress1.Location = New System.Drawing.Point(96, 40)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.Size = New System.Drawing.Size(400, 20)
            Me.txtAddress1.TabIndex = 4
            Me.txtAddress1.Text = ""
            '
            'txtLastName
            '
            Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLastName.Location = New System.Drawing.Point(336, 16)
            Me.txtLastName.Name = "txtLastName"
            Me.txtLastName.Size = New System.Drawing.Size(160, 20)
            Me.txtLastName.TabIndex = 3
            Me.txtLastName.Text = ""
            '
            'txtFirstName
            '
            Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFirstName.Location = New System.Drawing.Point(96, 16)
            Me.txtFirstName.Name = "txtFirstName"
            Me.txtFirstName.Size = New System.Drawing.Size(160, 20)
            Me.txtFirstName.TabIndex = 2
            Me.txtFirstName.Text = ""
            '
            'lblCountry
            '
            Me.lblCountry.Location = New System.Drawing.Point(32, 112)
            Me.lblCountry.Name = "lblCountry"
            Me.lblCountry.Size = New System.Drawing.Size(64, 16)
            Me.lblCountry.TabIndex = 0
            Me.lblCountry.Text = "Country:"
            Me.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblZipCode
            '
            Me.lblZipCode.Location = New System.Drawing.Point(336, 88)
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Size = New System.Drawing.Size(56, 16)
            Me.lblZipCode.TabIndex = 0
            Me.lblZipCode.Text = "Zip Code:"
            Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblState
            '
            Me.lblState.Location = New System.Drawing.Point(232, 88)
            Me.lblState.Name = "lblState"
            Me.lblState.Size = New System.Drawing.Size(32, 16)
            Me.lblState.TabIndex = 0
            Me.lblState.Text = "State:"
            Me.lblState.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblCity
            '
            Me.lblCity.Location = New System.Drawing.Point(32, 88)
            Me.lblCity.Name = "lblCity"
            Me.lblCity.Size = New System.Drawing.Size(64, 16)
            Me.lblCity.TabIndex = 0
            Me.lblCity.Text = "City:"
            Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress2
            '
            Me.lblAddress2.Location = New System.Drawing.Point(32, 64)
            Me.lblAddress2.Name = "lblAddress2"
            Me.lblAddress2.Size = New System.Drawing.Size(64, 16)
            Me.lblAddress2.TabIndex = 0
            Me.lblAddress2.Text = "Address(2):"
            Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress1
            '
            Me.lblAddress1.Location = New System.Drawing.Point(32, 40)
            Me.lblAddress1.Name = "lblAddress1"
            Me.lblAddress1.Size = New System.Drawing.Size(64, 16)
            Me.lblAddress1.TabIndex = 0
            Me.lblAddress1.Text = "Address(1):"
            Me.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLastName
            '
            Me.lblLastName.Location = New System.Drawing.Point(272, 16)
            Me.lblLastName.Name = "lblLastName"
            Me.lblLastName.Size = New System.Drawing.Size(64, 16)
            Me.lblLastName.TabIndex = 0
            Me.lblLastName.Text = "Last Name:"
            Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFirstName
            '
            Me.lblFirstName.Location = New System.Drawing.Point(32, 16)
            Me.lblFirstName.Name = "lblFirstName"
            Me.lblFirstName.Size = New System.Drawing.Size(64, 16)
            Me.lblFirstName.TabIndex = 0
            Me.lblFirstName.Text = "First Name:"
            Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnReturn
            '
            Me.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnReturn.Location = New System.Drawing.Point(408, 384)
            Me.btnReturn.Name = "btnReturn"
            Me.btnReturn.Size = New System.Drawing.Size(256, 24)
            Me.btnReturn.TabIndex = 20
            Me.btnReturn.Text = "Update"
            '
            'SelectEndUser
            '
            Me.SelectEndUser.AllowFilter = True
            Me.SelectEndUser.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.SelectEndUser.AllowSort = True
            Me.SelectEndUser.CaptionHeight = 17
            Me.SelectEndUser.CollapseColor = System.Drawing.Color.Black
            Me.SelectEndUser.DataChanged = False
            Me.SelectEndUser.BackColor = System.Drawing.Color.Empty
            Me.SelectEndUser.ExpandColor = System.Drawing.Color.Black
            Me.SelectEndUser.GroupByCaption = "Drag a column header here to group by that column"
            Me.SelectEndUser.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.SelectEndUser.Location = New System.Drawing.Point(136, 80)
            Me.SelectEndUser.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.SelectEndUser.Name = "SelectEndUser"
            Me.SelectEndUser.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.SelectEndUser.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.SelectEndUser.PreviewInfo.ZoomFactor = 75
            Me.SelectEndUser.PrintInfo.ShowOptionsDialog = False
            Me.SelectEndUser.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.SelectEndUser.RowDivider = GridLines1
            Me.SelectEndUser.RowHeight = 15
            Me.SelectEndUser.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.SelectEndUser.ScrollTips = False
            Me.SelectEndUser.Size = New System.Drawing.Size(192, 360)
            Me.SelectEndUser.TabIndex = 21
            Me.SelectEndUser.TabStop = False
            Me.SelectEndUser.Text = "C1TrueDBGrid1"
            Me.SelectEndUser.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}Od" & _
            "dRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Bord" & _
            "er:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{Al" & _
            "ignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colu" & _
            "mnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" Def" & _
            "RecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0" & _
            ", 0, 188, 356</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent=""Style2" & _
            """ me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent" & _
            "=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Foot" & _
            "erStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" />" & _
            "<HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highligh" & _
            "tRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle " & _
            "parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""S" & _
            "tyle11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" " & _
            "me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style paren" & _
            "t="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading""" & _
            " me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me" & _
            "=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""" & _
            "Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""" & _
            "EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Reco" & _
            "rdSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me" & _
            "=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><La" & _
            "yout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 1" & _
            "88, 356</ClientArea></Blob>"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(192, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 22
            Me.Label1.Text = "Device SN:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.Location = New System.Drawing.Point(264, 48)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(136, 20)
            Me.txtSN.TabIndex = 23
            Me.txtSN.Text = ""
            '
            'frmEndUserUpdate
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(792, 493)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtSN, Me.Label1, Me.SelectEndUser, Me.btnReturn, Me.GroupBox2, Me.GroupBox1, Me.grpCCInfo, Me.cboEndUser, Me.lblParentCompany})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmEndUserUpdate"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "EndUserUpdate"
            Me.grpCCInfo.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.SelectEndUser, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private arrEndUser(5000, 8) As String
        Private arrState(200, 1) As String
        Private arrCountry(200, 1) As String
        Private arrCCType(50, 1) As String
        Public arrPageData(17, 1) As String
        Private txtFName As String
        Private txtLName As String

        Private dtEndUser As DataTable

        Private keyCust As Int32
        Private keyLoc As Int32


        Private Sub gatherData2Array()

            valCust = InsertCustomer()
            valLoc = InsertLocation(valCust)
            valCC = InsertCreditCard(valCust)

        End Sub

        Private Sub EndUserUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            PopulateEndUser()
            PopulateState()
            PopulateCountry()
            PopulateCreditCardType()
            PopulateNonWarrantyRepair()
            PopulateLCDFlipReplaced()
            Highlight.SetHighLight(Me)
            SelectEndUser.Visible = False

        End Sub

        Private Sub PopulateEndUser()

            'This will generate the data for the cboEndUser control.
            'It will also create a two dimensional array that holds the ParentCo IDs
            'and Names

            Dim prevEndUser As String = ""
            Dim strEndUser As String

            Dim xCount As Integer = 0
            Dim arrCount As Integer = 0
            '            Dim tblPco As New PSS.Data.Production.lparentco()
            '            Dim dsPco As DataSet = tblPco.GetData

            Dim tblPCo As New PSS.Data.Production.Joins()
            Dim dtPco As DataTable = tblPCo.OrderEntrySelect("SELECT DISTINCT * from tcustomer where cust_Name2 is not null order by cust_name2")
            dtEndUser = dtPco

            Dim drPco As DataRow

            '            For xCount = 0 To dsPco.Tables("lparentco").Rows.Count - 1
            '                drPco = dsPco.Tables("lparentco").Rows(xCount)
            For xCount = 0 To dtPco.Rows.Count - 1
                drPco = dtPco.Rows(xCount)
                '                If drPco("PCo_ID") = 349 Or drPco("PCo_ID") = 409 Then
                strEndUser = drPco("Cust_Name1") & " " & drPco("Cust_Name2")
                arrEndUser(arrCount, 0) = drPco("Cust_ID")
                If strEndUser <> prevEndUser Then
                    cboEndUser.Items.Add(drPco("Cust_Name1") & " " & drPco("Cust_Name2"))
                    arrEndUser(arrCount, 1) = drPco("Cust_Name1") & " " & drPco("Cust_Name2")
                    prevEndUser = strEndUser
                    arrCount += 1
                End If
                '               End If
            Next

            dtPco = Nothing
            '            dsPco = Nothing
            tblPCo = Nothing

        End Sub

        Private Sub PopulateState()

            'This will generate the data for the cboState control.
            'It will also create a two dimensional array that holds the State IDs
            'and Names

            Dim xCount As Integer = 0
            Dim tblState As New PSS.Data.Production.lstate()
            Dim dsState As DataSet = tblState.GetData
            Dim drState As DataRow

            For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                drState = dsState.Tables("lstate").Rows(xCount)
                cboState.Items.Add(drState("State_Short"))
                arrState(xCount, 0) = drState("State_ID")
                If Not IsDBNull(drState("State_Short")) Then
                    arrState(xCount, 1) = drState("State_Short")
                End If
            Next

            dsState = Nothing
            tblState = Nothing

        End Sub

        Private Sub PopulateCountry()

            'This will generate the data for the cboCountry control.
            'It will also create a two dimensional array that holds the State IDs
            'and Names

            Dim xCount As Integer = 0

            Dim tblCountry As New PSS.Data.Production.lcountry()
            Dim dsCountry As DataSet = tblCountry.GetData
            Dim drCountry As DataRow

            For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                drCountry = dsCountry.Tables("lcountry").Rows(xCount)
                cboCountry.Items.Add(drCountry("Cntry_Name"))

                arrCountry(xCount, 0) = drCountry("Cntry_ID")
                If Not IsDBNull(drCountry("Cntry_Name")) Then
                    arrCountry(xCount, 1) = drCountry("Cntry_Name")
                End If
            Next

            dsCountry = Nothing
            tblCountry = Nothing

        End Sub

        Private Sub PopulateCreditCardType()

            'This will generate the data for the cboCCType control.
            'It will also create a two dimensional array that holds the CCType IDs
            'and Names

            Dim xCount As Integer = 0

            Dim tblCCType As New PSS.Data.Production.lcctype()
            Dim dsCCType As DataSet = tblCCType.GetData
            Dim drCCType As DataRow

            For xCount = 0 To dsCCType.Tables("lcctype").Rows.Count - 1
                drCCType = dsCCType.Tables("lcctype").Rows(xCount)
                cboCCType.Items.Add(drCCType("CCType_Desc"))

                arrCCType(xCount, 0) = drCCType("CCType_ID")
                If Not IsDBNull(drCCType("CCType_Desc")) Then
                    arrCCType(xCount, 1) = drCCType("CCType_Desc")
                End If
            Next

            dsCCType = Nothing
            tblCCType = Nothing

        End Sub

        Private Sub PopulateNonWarrantyRepair()

            cboNonWrtyRepair.Items.Add("Yes")
            cboNonWrtyRepair.Items.Add("No")

        End Sub

        Private Sub PopulateLCDFlipReplaced()

            cboLCDFlipReplaced.Items.Add("Yes")
            cboLCDFlipReplaced.Items.Add("No")

        End Sub

        Private Function ValidateExpDate(ByVal dteValue As String) As String

            Dim prtMonth As String
            Dim prtYear As String
            Dim sepLoc As Integer
            Dim valDate As Date


            sepLoc = InStr(dteValue, "/")

            If sepLoc = 0 Then
                ValidateExpDate = "The date must be in the format mm/yy using the '/' character as the separator between month and year."
                Exit Function
            End If

            If sepLoc > 0 Then
                prtMonth = Mid(dteValue, 1, sepLoc - 1)
                prtYear = Mid(dteValue, sepLoc + 1, Len(dteValue) - sepLoc)

                If IsNumeric(prtMonth) = False Then
                    ValidateExpDate = "The month value entered is not numeric."
                    Exit Function
                End If

                If CInt(prtMonth) < 1 Or CInt(prtMonth) > 12 Then
                    ValidateExpDate = "The month value entered is not valid."
                    Exit Function
                End If

                If IsNumeric(prtYear) = False Then
                    ValidateExpDate = "The year value entered is not valid."
                    Exit Function
                End If

                'Verify that the expiration date is valid.
                valDate = prtMonth & "/01/" & prtYear
                If valDate < Now Then
                    ValidateExpDate = "The card is already expired."
                    Exit Function
                End If


                ValidateExpDate = ""


            End If

        End Function

        Private Function ValidateCCNumber(ByVal ccNum As String) As String

            'Check all single values of the number and see if they are all numeric.
            Dim xCount As Integer = 0
            Dim xCountUp As Integer = 0
            Dim sngVal As String

            ValidateCCNumber = ""

            For xCount = 1 To Len(Trim(ccNum))
                If IsNumeric(Mid(Trim(ccNum), xCount, 1)) = False Then
                    If Len(Trim(Mid(Trim(ccNum), xCount, 1))) < 1 Then
                        ValidateCCNumber += "The value at point number " & xCount & " is not a number." & vbCrLf
                    End If
                Else
                    xCountUp += 1
                End If
            Next

            If xCountUp <> 16 And xCountUp <> 13 And xCountUp <> 15 Then
                ValidateCCNumber += "The string is the wrong length for a credit card number."
            End If

        End Function

        Private Sub txtExpirationDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtExpirationDate.Leave

            If Len(txtExpirationDate.Text) > 0 Then
                Dim valx As String = ValidateExpDate(txtExpirationDate.Text)
                If Len(valx) > 0 Then MsgBox(valx)
            End If

        End Sub

        Private Sub txtCCNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCCNumber.Leave

            If Len(txtCCNumber.Text) > 0 Then
                Dim valx As String = ValidateCCNumber(txtCCNumber.Text)
                If Len(valx) > 0 Then MsgBox(valx)
            End If

        End Sub

        Private Function checkRequiredFields() As String

            Dim msg As String = ""

            If Len(cboEndUser.Text) < 1 Then msg += "Parent company not selected." & vbCrLf
            If Len(txtFirstName.Text) < 1 Then msg += "First Name not entered." & vbCrLf
            If Len(txtLastName.Text) < 1 Then msg += "Last Name not entered." & vbCrLf
            If Len(txtAddress1.Text) < 1 Then msg += "Address not entered." & vbCrLf
            If Len(txtCity.Text) < 1 Then msg += "City not entered." & vbCrLf
            If Len(cboState.Text) < 1 Then msg += "State not selected." & vbCrLf
            If Len(cboCountry.Text) < 1 Then msg += "Country not selected." & vbCrLf
            If Len(txtPhoneNumber.Text) < 1 Then msg += "Phone number not entered." & vbCrLf
            If Len(cboNonWrtyRepair.Text) < 1 Then msg += "Non Warranty Repair flag not defined." & vbCrLf
            If Len(cboLCDFlipReplaced.Text) < 1 Then msg += "LCD Flip Replaced flag not defined." & vbCrLf
            If Len(cboCCType.Text) < 1 Then msg += "Credit card type not selected." & vbCrLf
            If Len(txtCCNumber.Text) < 1 Then msg += "Credit card number not entered." & vbCrLf
            If Len(txtCCAuthCode.Text) < 1 Then msg += "Credit card Authorization Code not entered." & vbCrLf
            If Len(txtCCAuthCode.Text) > 4 Then msg += "Credit card Authorization Code invalid." & vbCrLf
            If Len(txtExpirationDate.Text) < 1 Then msg += "Credit card expiration date not entered." & vbCrLf

            checkRequiredFields = msg

        End Function

        Private Sub PopulateArrayPageData()

            Dim frmReceiving As New frmReceiving()
            frmReceiving.ShowDialog()

        End Sub

        Private Sub btnReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturn.Click

            '//This is a test for the new audit system
            AuditCall("EndUserUpdate", keyCust, Controls)
            AuditCall("EndUserUpdateLocation", keyLoc, Controls)
            AuditCall("EndUserUpdateCreditCard", keyCust, Controls)
            '//End of new audit system test

            Dim required As String = checkRequiredFields()
            If Len(required) > 0 Then
                MsgBox(required, MsgBoxStyle.OKOnly, "Errors")
                Exit Sub
            Else

                If Len(Trim(txtMemo.Text)) < 1 Then txtMemo.Text = "Null"
                If Len(Trim(txtAddress2.Text)) < 1 Then txtAddress2.Text = "Null"

                '//Perform update of data here
                Dim blnCustomer As Boolean = UpdateCustomer()
                If blnCustomer = False Then
                    '//Throw error and exit sub
                    MsgBox("Customer information could not be updated. Please contact IT.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End If

                Dim blnLocation As Boolean = UpdateLocation()
                If blnLocation = False Then
                    '//Throw error and exit sub
                    MsgBox("Location information could not be updated. Please contact IT.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End If

                Dim blnCreditCard As Boolean = UpdateCreditCard()
                If blnCreditCard = False Then
                    '//Throw error and exit sub
                    MsgBox("Credit Card information could not be updated. Please contact IT.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End If

            End If

            MsgBox("Save Completed", MsgBoxStyle.OKOnly, "COMPLETE")
            SelectEndUser.Visible = True
            cboEndUser.Focus()

        End Sub

        Public Function InsertCustomer() As Int32

            Dim valNWR As Integer
            Dim valFR As Integer
            Dim valParentID As Integer
            Dim arrUB As Integer

            Dim valMarkup As Double
            Dim valDefRUR As Double
            Dim valDefNER As Double
            Dim valDefWrtyDays As Integer
            Dim valWrtyParts As Integer
            Dim valWrtyLabor As Integer
            Dim valPrc As Integer


            Dim xCount As Integer = 0

            arrUB = UBound(arrEndUser, 1)

            For xCount = 0 To arrUB
                If arrEndUser(xCount, 1) = cboEndUser.Text Then
                    valParentID = arrEndUser(xCount, 0)
                    valMarkup = arrEndUser(xCount, 2)
                    valDefRUR = arrEndUser(xCount, 3)
                    valDefNER = arrEndUser(xCount, 4)
                    valDefWrtyDays = arrEndUser(xCount, 5)
                    valWrtyParts = arrEndUser(xCount, 6)
                    valWrtyLabor = arrEndUser(xCount, 7)
                    valPrc = arrEndUser(xCount, 8)
                    Exit For
                End If
            Next

            If cboNonWrtyRepair.Text = "Yes" Then
                valNWR = 1
            Else
                valNWR = 0
            End If

            If cboLCDFlipReplaced.Text = "Yes" Then
                valFR = 1
            Else
                valFR = 0
            End If

            Dim tblCustomer As New PSS.Data.Production.tcustomer()
            Dim valColSalesTax As Integer
            If cboState.Text = "TX" Then
                valColSalesTax = 1
            Else
                valColSalesTax = 0
            End If

            Dim strSQL As String = "INSERT INTO tcustomer (Cust_Name1, Cust_Name2, Cust_RepairNonWrty, Cust_ReplaceLCD, PCo_ID, PlusParts, Cust_RejectDays, Cust_RejectTimes, Cust_CrApproveRec, Cust_CrApproveShip, Cust_CollSalesTax, Pay_ID) VALUES ('" & _
            txtFirstName.Text & "', '" & txtLastName.Text & "', " & valNWR & ", " & valFR & ", " & valParentID & ",0,0,0,1,1," & valColSalesTax & ",2);"

            Dim valCustID As Int32 = tblCustomer.idTransaction(strSQL)

            InsertCustomer = valCustID

            strSQL = "INSERT INTO tcustmarkup(Markup_RUR, Markup_NER, Markup_Cust, Cust_ID, Prod_ID, Invtrymthd_ID) VALUES (" & valDefRUR & ", " & valDefNER & ", " & valMarkup & ", " & valCustID & ", 1,1)"
            Dim valMKvalue As Int32 = tblCustomer.idTransaction(strSQL)
            strSQL = "INSERT INTO tcustwrty (CustWrty_DaysinWrty, PSSWrtyParts_ID, PSSWrtyLabor_ID, Prod_ID, Cust_ID) VALUES (" & valDefWrtyDays & ", " & valWrtyParts & ", " & valWrtyLabor & ",1," & valCustID & ")"
            Dim valCustWrty As Int32 = tblCustomer.idTransaction(strSQL)
            strSQL = "INSERT INTO tcusttoprice (Cust_ID, PrcGroup_ID) VALUES (" & valCustID & ", " & valPrc & ")"
            Dim valPrcGroups As Int32 = tblCustomer.idTransaction(strSQL)

        End Function

        Public Function UpdateCustomer() As Boolean

            UpdateCustomer = False

            Dim valNWR As Integer
            Dim valFR As Integer
            '            Dim valParentID As Integer
            '            Dim arrUB As Integer
            '            Dim valMarkup As Double
            '            Dim valDefRUR As Double
            '            Dim valDefNER As Double
            '            Dim valDefWrtyDays As Integer
            '            Dim valWrtyParts As Integer
            '            Dim valWrtyLabor As Integer
            '            Dim valPrc As Integer

            Dim xCount As Integer = 0

            '            arrUB = UBound(arrEndUser, 1)

            '            For xCount = 0 To arrUB
            '                If arrEndUser(xCount, 1) = cboEndUser.Text Then
            '                    valParentID = arrEndUser(xCount, 0)
            '                    valMarkup = arrEndUser(xCount, 2)
            '                    valDefRUR = arrEndUser(xCount, 3)
            '                    valDefNER = arrEndUser(xCount, 4)
            '                    valDefWrtyDays = arrEndUser(xCount, 5)
            '                    valWrtyParts = arrEndUser(xCount, 6)
            '                    valWrtyLabor = arrEndUser(xCount, 7)
            '                    valPrc = arrEndUser(xCount, 8)
            '                    Exit For
            '                End If
            '            Next

            If cboNonWrtyRepair.Text = "Yes" Then
                valNWR = 1
            Else
                valNWR = 0
            End If

            If cboLCDFlipReplaced.Text = "Yes" Then
                valFR = 1
            Else
                valFR = 0
            End If

            Dim tblCustomer As New PSS.Data.Production.tcustomer()
            Dim valColSalesTax As Integer
            If cboState.Text = "TX" Then
                valColSalesTax = 1
            Else
                valColSalesTax = 0
            End If

            '            Dim strSQL As String = "INSERT INTO tcustomer (Cust_Name1, Cust_Name2, Cust_RepairNonWrty, Cust_ReplaceLCD, PCo_ID, PlusParts, Cust_RejectDays, Cust_RejectTimes, Cust_CrApproveRec, Cust_CrApproveShip, Cust_CollSalesTax, Pay_ID) VALUES ('" & _
            '            txtFirstName.Text & "', '" & txtLastName.Text & "', " & valNWR & ", " & valFR & ", " & valParentID & ",0,0,0,1,1," & valColSalesTax & ",2);"

            Dim strSQL As String = "UPDATE tcustomer SET " & _
            "Cust_Name1 = '" & Me.txtFirstName.Text & "', " & _
            "Cust_Name2 = '" & Me.txtLastName.Text & "', " & _
            "Cust_RepairNonWrty = " & valNWR & ", " & _
            "Cust_ReplaceLCD = " & valFR & _
            " WHERE Cust_ID = " & keyCust


            Dim valCustExe As New PSS.Data.Production.Joins()
            Dim valCustUpdate As Boolean = valCustExe.OrderEntryUpdateDelete(strSQL)

            If valCustUpdate = True Then
                '//Continue
                UpdateCustomer = True
            Else
                '//Throw Error
            End If

            '            strSQL = "INSERT INTO tcustmarkup(Markup_RUR, Markup_NER, Markup_Cust, Cust_ID, Prod_ID, Invtrymthd_ID) VALUES (" & valDefRUR & ", " & valDefNER & ", " & valMarkup & ", " & valCustID & ", 1,1)"
            '            Dim valMKvalue As Int32 = tblCustomer.idTransaction(strSQL)
            '            strSQL = "INSERT INTO tcustwrty (CustWrty_DaysinWrty, PSSWrtyParts_ID, PSSWrtyLabor_ID, Prod_ID, Cust_ID) VALUES (" & valDefWrtyDays & ", " & valWrtyParts & ", " & valWrtyLabor & ",1," & valCustID & ")"
            '            Dim valCustWrty As Int32 = tblCustomer.idTransaction(strSQL)
            '            strSQL = "INSERT INTO tcusttoprice (Cust_ID, PrcGroup_ID) VALUES (" & valCustID & ", " & valPrc & ")"
            '            Dim valPrcGroups As Int32 = tblCustomer.idTransaction(strSQL)

        End Function

        Public Function InsertLocation(ByVal valCustID As Int32) As Int32


            Dim arrCountryUB As Integer = UBound(arrCountry, 1)
            Dim arrStateUB As Integer = UBound(arrState, 1)
            Dim valState, valCountry, xCount As Integer
            Dim valName As String

            For xCount = 0 To arrStateUB
                If arrState(xCount, 1) = cboState.Text Then
                    valState = arrState(xCount, 0)
                    Exit For
                End If
            Next
            For xCount = 0 To arrCountryUB
                If arrCountry(xCount, 1) = cboCountry.Text Then
                    valCountry = arrCountry(xCount, 0)
                    Exit For
                End If
            Next

            valName = ""
            If Len(txtFirstName.Text) > 0 Then valName += txtFirstName.Text
            If Len(txtLastName.Text) > 0 Then valName += " " & txtLastName.Text


            Dim tblLocation As New PSS.Data.Production.tlocation()

            Dim txtAdd2 As String = ",'" & txtAddress2.Text & "'"
            Dim txtMemo2 As String = ",'" & txtMemo.Text & "'"
            Dim txtAddLbl As String = ", Loc_Address2"
            Dim txtMemoLbl As String = ", Loc_Memo"
            If txtAddress2.Text = "0" Then txtAddLbl = ""
            If txtMemo.Text = "0" Then txtMemoLbl = ""

            If txtAddress2.Text = "0" Then txtAdd2 = ""
            If txtMemo.Text = "0" Then txtMemo2 = ""

            Dim strSQL As String = "INSERT INTO tlocation (Loc_Address1 " & txtAddLbl & ", Loc_City, Loc_Zip, Loc_Phone" & txtMemoLbl & ", State_ID, Cntry_ID, Cust_ID, Loc_AfterMarket, Loc_ManifestDetail) VALUES ('" & _
            txtAddress1.Text & "'" & txtAdd2 & ", '" & txtCity.Text & "', '" & txtZipCode.Text & "', '" & txtPhoneNumber.Text & "'" & txtMemo2 & ", " & valState & ", " & valCountry & ", " & valCustID & ",1,1);"

            Dim valLocID As Int32 = tblLocation.idTransaction(strSQL)

            InsertLocation = valLocID

        End Function

        Public Function UpdateLocation() As Boolean

            UpdateLocation = False

            Dim arrCountryUB As Integer = UBound(arrCountry, 1)
            Dim arrStateUB As Integer = UBound(arrState, 1)
            Dim valState, valCountry, xCount As Integer
            Dim valName As String

            For xCount = 0 To arrStateUB
                If arrState(xCount, 1) = cboState.Text Then
                    valState = arrState(xCount, 0)
                    Exit For
                End If
            Next
            For xCount = 0 To arrCountryUB
                If arrCountry(xCount, 1) = cboCountry.Text Then
                    valCountry = arrCountry(xCount, 0)
                    Exit For
                End If
            Next

            valName = ""
            If Len(txtFirstName.Text) > 0 Then valName += txtFirstName.Text
            If Len(txtLastName.Text) > 0 Then valName += " " & txtLastName.Text

            Dim tblLocation As New PSS.Data.Production.Joins()

            Dim txtAdd2 As String = txtAddress2.Text
            Dim txtMemo2 As String = txtMemo.Text
            Dim txtAddLbl As String = ", Loc_Address2"
            Dim txtMemoLbl As String = ", Loc_Memo"
            If txtAddress2.Text = "0" Then txtAddLbl = ""
            If txtMemo.Text = "0" Then txtMemoLbl = ""

            If txtAddress2.Text = "0" Then txtAdd2 = "Null"
            If Len(Trim(txtAddress2.Text)) < 1 Then txtAdd2 = "Null"
            If txtMemo.Text = "0" Then txtMemo2 = "Null"

            Dim strSQL As String = "UPDATE tlocation SET " & _
            "Loc_Address1 = '" & txtAddress1.Text & "', " & _
            "Loc_Address2 = '" & txtAdd2 & "', " & _
            "Loc_City = '" & txtCity.Text & "', " & _
            "Loc_Zip = '" & txtZipCode.Text & "', " & _
            "Loc_Phone = '" & txtPhoneNumber.Text & "', " & _
            "Loc_Memo = '" & txtMemo2 & "', " & _
            "State_ID = " & valState & ", " & _
            "Cntry_ID = " & valCountry & _
            " WHERE cust_id = " & keyCust & " AND loc_id = " & keyLoc

            UpdateLocation = tblLocation.OrderEntryUpdateDelete(strSQL)

        End Function


        Public Function InsertCreditCard(ByVal valCustID As Int32) As Int32

            Dim xCount As Integer = 0
            Dim tblCCType As New PSS.Data.Production.lcctype()
            Dim dsCCType As DataSet = tblCCType.GetData
            Dim drCCType As DataRow
            Dim valCCTypeID As Integer

            For xCount = 0 To dsCCType.Tables("lcctype").Rows.Count - 1
                drCCType = dsCCType.Tables("lcctype").Rows(xCount)
                If drCCType("cctype_desc") = cboCCType.Text Then
                    valCCTypeID = drCCType("cctype_id")
                    Exit For
                End If
            Next

            Dim tblCreditCard As New PSS.Data.Production.tcreditcard()

            Dim strSQL As String = "INSERT INTO tcreditcard (CreditCard_Num, CreditCard_AuthCode, CCardType_ID, CreditCard_ExpDate, Cust_ID) VALUES ('" & _
            txtCCNumber.Text & "', '" & txtCCAuthCode.Text & "', " & valCCTypeID & ", '" & txtExpirationDate.Text & "', " & valCustID & ");"

            Dim valCCiD As Int32 = tblCreditCard.idTransaction(strSQL)

            InsertCreditCard = valCCiD

        End Function

        Public Function UpdateCreditCard() As Boolean

            UpdateCreditCard = False

            Dim xCount As Integer = 0
            Dim tblCCType As New PSS.Data.Production.lcctype()
            Dim dsCCType As DataSet = tblCCType.GetData
            Dim drCCType As DataRow
            Dim valCCTypeID As Integer

            For xCount = 0 To dsCCType.Tables("lcctype").Rows.Count - 1
                drCCType = dsCCType.Tables("lcctype").Rows(xCount)
                If drCCType("cctype_desc") = cboCCType.Text Then
                    valCCTypeID = drCCType("cctype_id")
                    Exit For
                End If
            Next

            Dim tblCreditCard As New PSS.Data.Production.Joins()

            Dim strSQL As String = "UPDATE tcreditcard SET " & _
            "CreditCard_Num = '" & txtCCNumber.Text & "', " & _
            "CreditCard_AuthCode = '" & txtCCAuthCode.Text & "', " & _
            "CCardType_ID = " & valCCTypeID & ", " & _
            "CreditCard_ExpDate = '" & txtExpirationDate.Text & "'" & _
            " WHERE Cust_ID = " & keyCust

            '            Dim strSQL As String = "INSERT INTO tcreditcard (CreditCard_Num, CCardType_ID, CreditCard_ExpDate, Cust_ID) VALUES ('" & _
            '            txtCCNumber.Text & "', " & valCCTypeID & ", '" & txtExpirationDate.Text & "', " & valCustID & ");"

            Dim valCCiD As Boolean = tblCreditCard.OrderEntryUpdateDelete(strSQL)

            UpdateCreditCard = valCCiD

        End Function

        Private Sub txtCCNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCCNumber.TextChanged

        End Sub

        Private Sub cboEndUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEndUser.SelectedIndexChanged

            Dim xCount As Integer = 0
            Dim dtEUselect As DataTable
            Dim strEndUser As String = Trim(cboEndUser.Text)
            Dim r As DataRow
            Dim itCount As Integer = 0

            '//Hide SelectEndUser until number of iterations is determined.
            SelectEndUser.Visible = False

            For xCount = 0 To dtEndUser.Rows.Count - 1
                r = dtEndUser.Rows(xCount)
                If strEndUser = r("Cust_Name1") & " " & r("Cust_Name2") Then
                    itCount += 1
                    txtFName = Trim(r("Cust_Name1"))
                    txtLName = Trim(r("Cust_Name2"))
                End If
            Next

            If itCount > 0 Then
                SelectEndUser.Visible = True
                '//Load the entries into the grid
                Dim dtGrid As DataTable
                dtGrid = create_dataGrid()
                '//Load values into grid for selection
                Dim tblEndUserSelectedList As New PSS.Data.Production.Joins()
                Dim dtEndUserSelectedList As DataTable = tblEndUserSelectedList.OrderEntrySelect("select tcustomer.cust_id, tcustomer.cust_Name1, tcustomer.cust_Name2, tlocation.*, tdevice.device_sn, tdevice.device_DateRec, tdevice.device_DateBill, tdevice.device_DateShip from ((tcustomer INNER JOIN tlocation ON tcustomer.cust_ID = tlocation.cust_ID) INNER JOIN tdevice ON tlocation.loc_ID = tdevice.loc_ID) where cust_Name1='" & txtFName & "' and cust_Name2='" & txtLName & "' order by cust_Name1, cust_Name2")


                '//Populate the grid
                dtGrid.Clear()
                For xCount = 0 To dtEndUserSelectedList.Rows.Count - 1
                    r = dtEndUserSelectedList.Rows(xCount)
                    Dim dr1 As DataRow = dtGrid.NewRow
                    dr1("Customer Name") = txtFName & " " & txtLName
                    If IsDBNull(r("Device_SN")) = False Then
                        dr1("ID") = r("Device_SN")
                    End If
                    If IsDBNull(r("Loc_Address1")) = False Then
                        dr1("Address1") = r("Loc_Address1")
                    End If
                    If IsDBNull(r("Loc_Address2")) = False Then
                        dr1("Address2") = r("Loc_Address2")
                    End If
                    If IsDBNull(r("Loc_City")) = False Then
                        dr1("City") = r("Loc_City")
                    End If
                    If IsDBNull(r("State_ID")) = False Then
                        dr1("State") = r("State_ID")
                    End If
                    If IsDBNull(r("Loc_Zip")) = False Then
                        dr1("Zip Code") = r("Loc_Zip")
                    End If
                    If IsDBNull(r("Device_DateRec")) = False Then
                        dr1("Received") = r("Device_DateRec")
                    End If
                    If IsDBNull(r("Device_DateBill")) = False Then
                        dr1("Billed") = r("Device_DateBill")
                    End If
                    If IsDBNull(r("Device_DateShip")) = False Then
                        dr1("Shipped") = r("Device_DateShip")
                    End If
                    If IsDBNull(r("Loc_ID")) = False Then
                        dr1("Loc ID") = r("Loc_ID")
                    End If
                    If IsDBNull(r("Cust_ID")) = False Then
                        dr1("Cust ID") = r("Cust_ID")
                    End If
                    dtGrid.Rows.Add(dr1)
                Next

                SelectEndUser.DataSource = dtGrid

                Exit Sub
            ElseIf itCount = 0 Then
                '//Throw error
                MsgBox("No record can be found for this end user. No record can be recovered", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            Else
                '//Load values for form
            End If


        End Sub

        Private Function create_dataGrid() As DataTable

            Dim dtDupList As New DataTable()

            dtDupList.MinimumCapacity = 500
            dtDupList.CaseSensitive = False

            Dim dcID As New DataColumn("ID")
            dtDupList.Columns.Add(dcID)
            Dim dcCustName As New DataColumn("Customer Name")
            dtDupList.Columns.Add(dcCustName)
            Dim dcAddress1 As New DataColumn("Address1")
            dtDupList.Columns.Add(dcAddress1)
            Dim dcAddress2 As New DataColumn("Address2")
            dtDupList.Columns.Add(dcAddress2)
            Dim dcCity As New DataColumn("City")
            dtDupList.Columns.Add(dcCity)
            Dim dcState As New DataColumn("State")
            dtDupList.Columns.Add(dcState)
            Dim dcZip As New DataColumn("Zip Code")
            dtDupList.Columns.Add(dcZip)
            Dim dcDateRec As New DataColumn("Received")
            dtDupList.Columns.Add(dcDateRec)
            Dim dcDateBill As New DataColumn("Billed")
            dtDupList.Columns.Add(dcDateBill)
            Dim dcDateShip As New DataColumn("Shipped")
            dtDupList.Columns.Add(dcDateShip)
            Dim dcLocID As New DataColumn("Loc ID")
            dtDupList.Columns.Add(dcLocID)
            Dim dcCustID As New DataColumn("Cust ID")
            dtDupList.Columns.Add(dcCustID)

            create_dataGrid = dtDupList

        End Function

        Private Sub SelectEndUser_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SelectEndUser.MouseUp

            'MsgBox(SelectEndUser.Columns(10).Value)

            '//Set Keys for Update
            keyCust = SelectEndUser.Columns("Cust ID").Value
            keyLoc = SelectEndUser.Columns("Loc ID").Value

            '//Verify that values have been assigned
            If Len(Trim(keyCust)) < 1 Then
                MsgBox("Error assigning Cust ID.")
            End If

            If Len(Trim(keyLoc)) < 1 Then
                MsgBox("Error assigning Loc ID.")
            End If

            '//Load data into form

            'Clear Data From Form
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtAddress1.Text = ""
            txtAddress2.Text = ""
            txtCity.Text = ""
            txtZipCode.Text = ""
            txtPhoneNumber.Text = ""
            txtMemo.Text = ""
            txtCCNumber.Text = ""
            txtCCAuthCode.Text = ""
            txtExpirationDate.Text = ""
            'Clear Data From Form END

            Dim dsGetFormData As New PSS.Data.Production.Joins()
            Dim dtGetFormData As DataTable = dsGetFormData.OrderEntrySelect("select tcustomer.cust_Name1, tcustomer.cust_Name2, tlocation.*, tcustomer.Cust_RepairNonWrty, tcustomer.Cust_ReplaceLCD, tcreditcard.CCardType_ID, tcreditcard.CreditCard_Num, tcreditcard.CreditCard_AuthCode, tcreditcard.CreditCard_ExpDate from ((tcustomer INNER JOIN tlocation ON tcustomer.cust_id = tlocation.cust_id) LEFT OUTER JOIN tcreditcard ON tcustomer.cust_id = tcreditcard.cust_id) WHERE tcustomer.cust_id = " & keyCust)
            Dim r As DataRow
            Dim xCount As Integer = 0
            Dim tmpCount As Integer = 0

            '//Should return 1 record
            For xCount = 0 To dtGetFormData.Rows.Count - 1
                r = dtGetFormData.Rows(xCount)

                If IsDBNull(r("Cust_Name1")) = False Then
                    txtFirstName.Text = Trim(r("Cust_Name1"))
                End If

                If IsDBNull(r("Cust_Name2")) = False Then
                    txtLastName.Text = Trim(r("Cust_Name2"))
                End If

                If IsDBNull(r("Loc_Address1")) = False Then
                    txtAddress1.Text = Trim(r("Loc_Address1"))
                End If

                If IsDBNull(r("Loc_Address2")) = False Then
                    txtAddress2.Text = Trim(r("Loc_Address2"))
                End If

                If IsDBNull(r("Loc_City")) = False Then
                    txtCity.Text = Trim(r("Loc_City"))
                End If

                If IsDBNull(r("State_ID")) = False Then

                    Dim valStateText As String
                    For tmpCount = 0 To UBound(arrState) - 1
                        If arrState(tmpCount, 0) = r("State_ID") Then
                            valStateText = arrState(tmpCount, 1)
                            Exit For
                        End If
                    Next

                    For tmpCount = 0 To cboState.Items.Count - 1
                        If cboState.Items(tmpCount) = valStateText Then
                            cboState.SelectedIndex = tmpCount
                            Exit For
                        End If
                    Next
                End If

                If IsDBNull(r("Loc_Zip")) = False Then
                    txtZipCode.Text = Trim(r("Loc_Zip"))
                End If

                If IsDBNull(r("Cntry_ID")) = False Then

                    Dim valCountryText As String
                    For tmpCount = 0 To UBound(arrState) - 1
                        If arrCountry(tmpCount, 0) = r("Cntry_ID") Then
                            valCountryText = arrCountry(tmpCount, 1)
                            Exit For
                        End If
                    Next

                    For tmpCount = 0 To cboCountry.Items.Count - 1
                        If cboCountry.Items(tmpCount) = valCountryText Then
                            cboCountry.SelectedIndex = tmpCount
                            Exit For
                        End If
                    Next
                End If

                If IsDBNull(r("Loc_Phone")) = False Then
                    txtPhoneNumber.Text = Trim(r("Loc_Phone"))
                End If

                Dim valCustRepairNonWrty As String
                If IsDBNull(r("Cust_RepairNonWrty")) = False Then
                    If r("Cust_RepairNonWrty") = "0" Then
                        valCustRepairNonWrty = "No"
                    Else
                        valCustRepairNonWrty = "Yes"
                    End If

                    For tmpCount = 0 To Me.cboNonWrtyRepair.Items.Count - 1
                        If Trim(cboNonWrtyRepair.Items(tmpCount)) = valCustRepairNonWrty Then
                            cboNonWrtyRepair.SelectedIndex = tmpCount
                            Exit For
                        End If
                    Next
                End If

                Dim valReplaceLCD As String
                If IsDBNull(r("Cust_ReplaceLCD")) = False Then
                    If r("Cust_ReplaceLCD") = "0" Then
                        valReplaceLCD = "No"
                    Else
                        valReplaceLCD = "Yes"
                    End If

                    For tmpCount = 0 To Me.cboLCDFlipReplaced.Items.Count - 1
                        If Trim(cboLCDFlipReplaced.Items(tmpCount)) = valReplaceLCD Then
                            cboLCDFlipReplaced.SelectedIndex = tmpCount
                            Exit For
                        End If
                    Next
                End If

                If IsDBNull(r("Loc_Memo")) = False Then
                    txtMemo.Text = Trim(r("Loc_Memo"))
                End If

                If IsDBNull(r("CCardType_ID")) = False Then

                    Dim valCCType As String
                    For tmpCount = 0 To UBound(arrCCType) - 1
                        If arrCCType(tmpCount, 0) = r("CCardType_ID") Then
                            valCCType = arrCCType(tmpCount, 1)
                            Exit For
                        End If
                    Next

                    For tmpCount = 0 To cboCCType.Items.Count - 1
                        If cboCCType.Items(tmpCount) = valCCType Then
                            cboCCType.SelectedIndex = xCount
                            Exit For
                        End If
                    Next
                End If

                If IsDBNull(r("CreditCard_Num")) = False Then
                    txtCCNumber.Text = Trim(r("CreditCard_Num"))
                End If

                If IsDBNull(r("CreditCard_AuthCode")) = False Then
                    txtCCAuthCode.Text = Trim(r("CreditCard_AuthCode"))
                End If

                If IsDBNull(r("CreditCard_ExpDate")) = False Then
                    txtExpirationDate.Text = Trim(r("CreditCard_ExpDate"))
                End If

            Next

            SelectEndUser.Visible = False


        End Sub

        Private Sub SelectEndUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectEndUser.Click

        End Sub
    End Class

End Namespace

