Imports PSS.Core
Imports PSS.Data

Namespace Gui.Receiving

    Public Class frmEndUserInput
        Inherits System.Windows.Forms.Form

        Public valCust As Int32
        Public valLoc As Int32
        Public valCC As Int32
        Public valDevice As Integer
        Private vProd, vRec As Integer

        Public valModel As Int32
        Public valManuf As Int32
        Public valMemo As String

        Private tcustFname, tcustLname, tAddress1, tAddress2, tCity, tStateID As String
        Private tZip, tCntryID, tContactName, tPhone, tFax, tEmail As String
        Private tCCtypeID, tCCnumber, tDateExp, tMemo, tPrice, tWrtyPrice As String
        Private tManufID, tModelID, tCCVnumber As String




#Region " Windows Form Designer generated code "

        Public Sub New(ByVal intprod As Integer, ByVal intRec As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            vProd = intprod
            vRec = intRec
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
        Friend WithEvents cboParentCompany As System.Windows.Forms.ComboBox
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
        Friend WithEvents txtCCAuthCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCCAuthCode As System.Windows.Forms.Label
        Friend WithEvents chkFlatRate As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblParentCompany = New System.Windows.Forms.Label()
            Me.cboParentCompany = New System.Windows.Forms.ComboBox()
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
            Me.chkFlatRate = New System.Windows.Forms.CheckBox()
            Me.grpCCInfo.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblParentCompany
            '
            Me.lblParentCompany.Location = New System.Drawing.Point(128, 72)
            Me.lblParentCompany.Name = "lblParentCompany"
            Me.lblParentCompany.Size = New System.Drawing.Size(100, 16)
            Me.lblParentCompany.TabIndex = 0
            Me.lblParentCompany.Text = "Parent Company:"
            Me.lblParentCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboParentCompany
            '
            Me.cboParentCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboParentCompany.Location = New System.Drawing.Point(232, 72)
            Me.cboParentCompany.Name = "cboParentCompany"
            Me.cboParentCompany.Size = New System.Drawing.Size(280, 21)
            Me.cboParentCompany.TabIndex = 1
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
            Me.txtCCAuthCode.TabIndex = 17
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
            Me.cboCCType.TabIndex = 15
            '
            'txtExpirationDate
            '
            Me.txtExpirationDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtExpirationDate.Location = New System.Drawing.Point(128, 88)
            Me.txtExpirationDate.Name = "txtExpirationDate"
            Me.txtExpirationDate.Size = New System.Drawing.Size(64, 20)
            Me.txtExpirationDate.TabIndex = 18
            Me.txtExpirationDate.Text = ""
            '
            'txtCCNumber
            '
            Me.txtCCNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtCCNumber.Location = New System.Drawing.Point(128, 40)
            Me.txtCCNumber.Name = "txtCCNumber"
            Me.txtCCNumber.Size = New System.Drawing.Size(120, 20)
            Me.txtCCNumber.TabIndex = 16
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
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMemo, Me.cboLCDFlipReplaced, Me.cboNonWrtyRepair, Me.txtPhoneNumber, Me.lblMemo, Me.lblLCDFlipReplaced, Me.lblNonWrtyRepair, Me.lblPhoneNumber, Me.chkFlatRate})
            Me.GroupBox1.Location = New System.Drawing.Point(136, 264)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(264, 144)
            Me.GroupBox1.TabIndex = 3
            Me.GroupBox1.TabStop = False
            '
            'txtMemo
            '
            Me.txtMemo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMemo.Location = New System.Drawing.Point(64, 112)
            Me.txtMemo.Multiline = True
            Me.txtMemo.Name = "txtMemo"
            Me.txtMemo.Size = New System.Drawing.Size(184, 24)
            Me.txtMemo.TabIndex = 14
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
            Me.lblMemo.Location = New System.Drawing.Point(16, 112)
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
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCountry, Me.txtZipCode, Me.cboState, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.txtLastName, Me.txtFirstName, Me.lblCountry, Me.lblZipCode, Me.lblState, Me.lblCity, Me.lblAddress2, Me.lblAddress1, Me.lblLastName, Me.lblFirstName})
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
            Me.txtAddress2.Size = New System.Drawing.Size(280, 20)
            Me.txtAddress2.TabIndex = 5
            Me.txtAddress2.Text = ""
            '
            'txtAddress1
            '
            Me.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtAddress1.Location = New System.Drawing.Point(96, 40)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.Size = New System.Drawing.Size(280, 20)
            Me.txtAddress1.TabIndex = 4
            Me.txtAddress1.Text = ""
            '
            'txtLastName
            '
            Me.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtLastName.Location = New System.Drawing.Point(280, 16)
            Me.txtLastName.Name = "txtLastName"
            Me.txtLastName.Size = New System.Drawing.Size(96, 20)
            Me.txtLastName.TabIndex = 3
            Me.txtLastName.Text = ""
            '
            'txtFirstName
            '
            Me.txtFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFirstName.Location = New System.Drawing.Point(96, 16)
            Me.txtFirstName.Name = "txtFirstName"
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
            Me.lblLastName.Location = New System.Drawing.Point(216, 16)
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
            Me.btnReturn.Text = "Return"
            '
            'chkFlatRate
            '
            Me.chkFlatRate.Location = New System.Drawing.Point(144, 88)
            Me.chkFlatRate.Name = "chkFlatRate"
            Me.chkFlatRate.Size = New System.Drawing.Size(72, 24)
            Me.chkFlatRate.TabIndex = 13
            Me.chkFlatRate.Text = "Flat Rate"
            '
            'frmEndUserInput
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(792, 493)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReturn, Me.GroupBox2, Me.GroupBox1, Me.grpCCInfo, Me.cboParentCompany, Me.lblParentCompany})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.Name = "frmEndUserInput"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "EndUserInput"
            Me.grpCCInfo.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private arrParentCo(5000, 8) As String
        Private arrState(200, 1) As String
        Private arrCountry(200, 1) As String
        Private arrCCType(50, 1) As String
        Public arrPageData(17, 1) As String

        Private Sub gatherData2Array()

            valCust = InsertCustomer()
            valLoc = InsertLocation(valCust)
            valCC = InsertCreditCard(valCust)

        End Sub

        Private Sub gatherData2ArrayWEB()

            valCust = InsertCustomerWEB()
            valLoc = InsertLocationWEB(valCust)
            valCC = InsertCreditCardWEB(valCust)




        End Sub

        Private Sub EndUserInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            '            'MsgBox(vProd)
            '            valManuf = 0
            '            valModel = 0

            '            PopulateParentCo()
            '            PopulateState()
            '            PopulateCountry()
            '            PopulateCreditCardType()
            '            PopulateNonWarrantyRepair()
            '            PopulateLCDFlipReplaced()
            '            Highlight.SetHighLight(Me)

            '            If vRec = 4 Then

            '                'message box for input of po number
            '                Dim WEBuserID As Integer
            '                Dim valWebUser As Integer

            'enterWEBuser:
            '                WEBuserID = InputBox("Please enter or scan the WEB USER Number:", "Enter WEB USER Number")
            '                If IsNumeric(WEBuserID) = False Then
            '                    MsgBox("Please enter a numberic value for the WEB USER Number.", MsgBoxStyle.OKOnly)
            '                    GoTo enterWEBuser
            '                Else
            '                    valWebUser = WEBuserID
            '                End If

            '                'Get data and write to database
            '                Dim dWebInfo As New PSS.Data.Production.webcustinfo()
            '                Dim dtWebInfo As DataTable = dWebInfo.GenericSelect("SELECT * FROM webcustinfo WHERE Cust_ID = " & valWebUser)


            '                Dim xCount As Integer = 0
            '                Dim yCount As Integer = 0
            '                Dim r As DataRow


            '                For xCount = 0 To dtWebInfo.Rows.Count - 1
            '                    r = dtWebInfo.Rows(xCount)
            '                    If IsDBNull(r("cust_fname")) = False Then
            '                        tcustFname = r("cust_fname")
            '                        Me.txtFirstName.Text = r("cust_fname")
            '                    End If
            '                    If IsDBNull(r("cust_lname")) = False Then
            '                        tcustLname = r("cust_lname")
            '                        Me.txtLastName.Text = r("cust_lname")
            '                    End If
            '                    If IsDBNull(r("cust_address1")) = False Then
            '                        tAddress1 = r("cust_address1")
            '                        Me.txtAddress1.Text = r("cust_address1")
            '                    End If
            '                    If IsDBNull(r("cust_address2")) = False Then
            '                        tAddress2 = r("cust_address2")
            '                        Me.txtAddress2.Text = r("cust_address2")
            '                    End If
            '                    If IsDBNull(r("cust_city")) = False Then
            '                        tCity = r("cust_city")
            '                        Me.txtCity.Text = r("cust_city")
            '                    End If
            '                    If IsDBNull(r("state_id")) = False Then
            '                        tStateID = r("state_id")
            '                        For yCount = 0 To UBound(arrState)
            '                            If arrState(yCount, 0) = tStateID Then
            '                                Me.cboState.SelectedIndex = yCount
            '                                Exit For
            '                            End If
            '                        Next
            '                    End If
            '                    If IsDBNull(r("cust_zip")) = False Then
            '                        tZip = r("cust_zip")
            '                        Me.txtZipCode.Text = r("cust_zip")
            '                    End If
            '                    If IsDBNull(r("cntry_id")) = False Then
            '                        tCntryID = r("cntry_id")
            '                        For yCount = 0 To UBound(arrCountry)
            '                            If arrCountry(yCount, 0) = tCntryID Then
            '                                Me.cboCountry.SelectedIndex = yCount
            '                                Exit For
            '                            End If
            '                        Next
            '                    End If
            '                    If IsDBNull(r("cust_contactname")) = False Then
            '                        tContactName = r("cust_contactname")
            '                    End If
            '                    If IsDBNull(r("cust_phone")) = False Then
            '                        tPhone = r("cust_phone")
            '                        Me.txtPhoneNumber.Text = r("cust_phone")
            '                    End If
            '                    If IsDBNull(r("cust_fax")) = False Then
            '                        tFax = r("cust_fax")
            '                    End If
            '                    If IsDBNull(r("cust_email")) = False Then
            '                        tEmail = r("cust_email")
            '                    End If
            '                    If IsDBNull(r("cctype_id")) = False Then
            '                        tCCtypeID = r("cctype_id")
            '                        For yCount = 0 To UBound(arrCCType)
            '                            If arrCCType(yCount, 0) = tCCtypeID Then
            '                                Me.cboCCType.SelectedIndex = yCount
            '                                Exit For
            '                            End If
            '                        Next
            '                    End If
            '                    If IsDBNull(r("cust_ccnumber")) = False Then
            '                        tCCnumber = r("cust_ccnumber")
            '                        Me.txtCCNumber.Text = r("cust_ccnumber")
            '                    End If
            '                    If IsDBNull(r("cust_dateexp")) = False Then
            '                        tDateExp = r("cust_dateexp")
            '                        Me.txtExpirationDate.Text = r("cust_dateexp")
            '                    End If
            '                    If IsDBNull(r("cust_memo")) = False Then
            '                        tMemo = r("cust_memo")
            '                        Me.txtMemo.Text = r("cust_memo")
            '                    End If
            '                    If IsDBNull(r("cust_price")) = False Then
            '                        tPrice = r("cust_price")
            '                    End If
            '                    If IsDBNull(r("cust_wrtyprice")) = False Then
            '                        tWrtyPrice = r("cust_wrtyprice")
            '                    End If
            '                    If IsDBNull(r("manuf_id")) = False Then
            '                        tManufID = r("manuf_id")
            '                        valManuf = r("manuf_id")
            '                    End If
            '                    If IsDBNull(r("model_id")) = False Then
            '                        tModelID = r("model_id")
            '                        valModel = r("model_id")
            '                    End If
            '                    If IsDBNull(r("cust_ccvnumber")) = False Then
            '                        tCCVnumber = r("cust_ccvnumber")
            '                        Me.txtCCAuthCode.Text = r("cust_ccvnumber")
            '                    End If
            '                    Exit For
            '                Next

            '                If Len(Trim(txtMemo.Text)) < 1 Then txtMemo.Text = "0"
            '                If Len(Trim(txtAddress2.Text)) < 1 Then txtAddress2.Text = "0"

            '                'gatherData2ArrayWEB()
            '                'Me.Dispose()
            '                'Me.Close()

            '            End If


        End Sub

        Private Sub PopulateParentCo()

            'This will generate the data for the cboParentCo control.
            'It will also create a two dimensional array that holds the ParentCo IDs
            'and Names

            Dim xCount As Integer = 0
            Dim arrCount As Integer = 0
            '            Dim tblPco As New PSS.Data.Production.lparentco()
            '            Dim dsPco As DataSet = tblPco.GetData

            Dim tblPCo As New PSS.Data.Production.Joins()
            Dim dtPco As DataTable = tblPCo.CustomerListPagerEndUser()


            Dim drPco As DataRow

            '            For xCount = 0 To dsPco.Tables("lparentco").Rows.Count - 1
            '                drPco = dsPco.Tables("lparentco").Rows(xCount)
            For xCount = 0 To dtPco.Rows.Count - 1
                drPco = dtPco.Rows(xCount)
                '                If drPco("PCo_ID") = 349 Or drPco("PCo_ID") = 409 Then
                cboParentCompany.Items.Add(drPco("PCo_Name"))
                arrParentCo(arrCount, 0) = drPco("PCo_ID")
                If Not IsDBNull(drPco("PCo_Name")) Then
                    arrParentCo(arrCount, 1) = drPco("PCo_Name")
                    arrParentCo(arrCount, 2) = drPco("PCo_DefMarkUP")
                    arrParentCo(arrCount, 3) = drPco("PCo_DefRUR")
                    arrParentCo(arrCount, 4) = drPco("PCo_DefNER")
                    arrParentCo(arrCount, 5) = drPco("PCo_DefWrtyDays")
                    arrParentCo(arrCount, 6) = drPco("PSSWrtyParts_ID")
                    arrParentCo(arrCount, 7) = drPco("PSSWrtyLabor_ID")
                    arrParentCo(arrCount, 8) = drPco("PrcGroup_ID")
                End If
                arrCount += 1
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

            Try
                cboCountry.Text = "USA"
            Catch ex As Exception
            End Try

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

            If Len(cboParentCompany.Text) < 1 Then msg += "Parent company not selected." & vbCrLf
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

            Dim required As String = checkRequiredFields()
            If Len(required) > 0 Then
                MsgBox(required, MsgBoxStyle.OKOnly, "Errors")
                Exit Sub
            Else
                'set values if field is null

                'If Len(Trim(txtMemo.Text)) < 1 Then txtMemo.Text = "0"
                'If Len(Trim(txtAddress2.Text)) < 1 Then txtAddress2.Text = "0"

                If Len(Trim(txtMemo.Text)) < 1 Then txtMemo.Text = "0"
                If Len(Trim(txtAddress2.Text)) < 1 Then txtAddress2.Text = "0"

                gatherData2Array()
                Me.Dispose()
                Me.Close()
            End If

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

            Dim valCustFlatRate As Integer

            Dim xCount As Integer = 0

            arrUB = UBound(arrParentCo, 1)

            For xCount = 0 To arrUB
                If arrParentCo(xCount, 1) = cboParentCompany.Text Then
                    valParentID = arrParentCo(xCount, 0)
                    valMarkup = arrParentCo(xCount, 2)
                    valDefRUR = arrParentCo(xCount, 3)
                    valDefNER = arrParentCo(xCount, 4)
                    valDefWrtyDays = arrParentCo(xCount, 5)
                    valWrtyParts = arrParentCo(xCount, 6)
                    valWrtyLabor = arrParentCo(xCount, 7)
                    valPrc = arrParentCo(xCount, 8)
                    Exit For
                End If
            Next

            If chkFlatRate.Checked = True Then
                valCustFlatRate = 1
            Else
                valCustFlatRate = 0
            End If

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
                        txtFirstName.Text & "', '" & txtLastName.Text & "', " & valNWR & ", " & valFR & ", " & valParentID & ",0,0,0,1,1," & valColSalesTax & ",2 );"

            Dim valCustID As Int32 = tblCustomer.idTransaction(strSQL)

            InsertCustomer = valCustID

            If vProd = 2 Then
                strSQL = "INSERT INTO tcustmarkup(Markup_RUR, Markup_NER, Markup_Cust, Cust_ID, Prod_ID, Invtrymthd_ID, Markup_PlusParts) VALUES (" & valDefRUR & ", " & valDefNER & ", " & valMarkup & ", " & valCustID & ", 2,1,0)"
            Else
                strSQL = "INSERT INTO tcustmarkup(Markup_RUR, Markup_NER, Markup_Cust, Cust_ID, Prod_ID, Invtrymthd_ID, Markup_PlusParts) VALUES (" & valDefRUR & ", " & valDefNER & ", " & valMarkup & ", " & valCustID & ", 1,1,0)"
            End If
            Dim valMKvalue As Int32 = tblCustomer.idTransaction(strSQL)

            If vProd = 2 Then
                strSQL = "INSERT INTO tcustwrty (CustWrty_DaysinWrty, PSSWrtyParts_ID, PSSWrtyLabor_ID, Prod_ID, Cust_ID) VALUES (" & valDefWrtyDays & ", " & valWrtyParts & ", " & valWrtyLabor & ",2," & valCustID & ")"
            Else
                strSQL = "INSERT INTO tcustwrty (CustWrty_DaysinWrty, PSSWrtyParts_ID, PSSWrtyLabor_ID, Prod_ID, Cust_ID) VALUES (" & valDefWrtyDays & ", " & valWrtyParts & ", " & valWrtyLabor & ",1," & valCustID & ")"
            End If
            Dim valCustWrty As Int32 = tblCustomer.idTransaction(strSQL)

            If vProd = 2 Then
                strSQL = "INSERT INTO tcusttoprice (Cust_ID, PrcGroup_ID, prod_ID) VALUES (" & valCustID & ", " & valPrc & ",2)"
            Else
                strSQL = "INSERT INTO tcusttoprice (Cust_ID, PrcGroup_ID, prod_ID) VALUES (" & valCustID & ", " & valPrc & ",1)"
            End If
            Dim valPrcGroups As Int32 = tblCustomer.idTransaction(strSQL)

        End Function


        Public Function InsertCustomerWEB() As Int32

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

            arrUB = UBound(arrParentCo, 1)

            For xCount = 0 To arrUB
                If arrParentCo(xCount, 0) = 664 Then
                    valParentID = arrParentCo(xCount, 0)
                    valMarkup = arrParentCo(xCount, 2)
                    valDefRUR = arrParentCo(xCount, 3)
                    valDefNER = arrParentCo(xCount, 4)
                    valDefWrtyDays = arrParentCo(xCount, 5)
                    valWrtyParts = arrParentCo(xCount, 6)
                    valWrtyLabor = arrParentCo(xCount, 7)
                    valPrc = arrParentCo(xCount, 8)
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
            tcustFname & "', '" & tcustLname & "', " & valNWR & ", " & valFR & ", " & valParentID & ",0,0,0,1,1," & valColSalesTax & ",2);"

            Dim valCustID As Int32 = tblCustomer.idTransaction(strSQL)

            InsertCustomerWEB = valCustID

            If vProd = 2 Then
                strSQL = "INSERT INTO tcustmarkup(Markup_RUR, Markup_NER, Markup_Cust, Cust_ID, Prod_ID, Invtrymthd_ID, Markup_PlusParts) VALUES (" & valDefRUR & ", " & valDefNER & ", " & valMarkup & ", " & valCustID & ", 2,1,0)"
            Else
                strSQL = "INSERT INTO tcustmarkup(Markup_RUR, Markup_NER, Markup_Cust, Cust_ID, Prod_ID, Invtrymthd_ID, Markup_PlusParts) VALUES (" & valDefRUR & ", " & valDefNER & ", " & valMarkup & ", " & valCustID & ", 1,1,0)"
            End If
            Dim valMKvalue As Int32 = tblCustomer.idTransaction(strSQL)

            If vProd = 2 Then
                strSQL = "INSERT INTO tcustwrty (CustWrty_DaysinWrty, PSSWrtyParts_ID, PSSWrtyLabor_ID, Prod_ID, Cust_ID) VALUES (" & valDefWrtyDays & ", " & valWrtyParts & ", " & valWrtyLabor & ",2," & valCustID & ")"
            Else
                strSQL = "INSERT INTO tcustwrty (CustWrty_DaysinWrty, PSSWrtyParts_ID, PSSWrtyLabor_ID, Prod_ID, Cust_ID) VALUES (" & valDefWrtyDays & ", " & valWrtyParts & ", " & valWrtyLabor & ",1," & valCustID & ")"
            End If
            Dim valCustWrty As Int32 = tblCustomer.idTransaction(strSQL)

            If vProd = 2 Then
                strSQL = "INSERT INTO tcusttoprice (Cust_ID, PrcGroup_ID, prod_ID) VALUES (" & valCustID & ", " & valPrc & ",2)"
            Else
                strSQL = "INSERT INTO tcusttoprice (Cust_ID, PrcGroup_ID, prod_ID) VALUES (" & valCustID & ", " & valPrc & ",1)"
            End If
            Dim valPrcGroups As Int32 = tblCustomer.idTransaction(strSQL)

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


        Public Function InsertLocationWEB(ByVal valCustID As Int32) As Int32


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

            Dim txtAdd2 As String = ",'" & tAddress2 & "'"
            Dim txtMemo2 As String = ",'" & tMemo & "'"
            Dim txtAddLbl As String = ", Loc_Address2"
            Dim txtMemoLbl As String = ", Loc_Memo"
            If Len(Trim(tAddress2)) < 1 Then txtAddLbl = ""
            If Len(Trim(tMemo)) < 1 Then txtMemoLbl = ""

            If Len(Trim(tAddress2)) < 1 Then txtAdd2 = ""
            If Len(Trim(tMemo)) < 1 Then txtMemo2 = ""

            Dim strSQL As String = "INSERT INTO tlocation (Loc_Address1 " & txtAddLbl & ", Loc_City, Loc_Zip, Loc_Phone" & txtMemoLbl & ", State_ID, Cntry_ID, Cust_ID, Loc_AfterMarket, Loc_ManifestDetail) VALUES ('" & _
            tAddress1 & "'" & txtAdd2 & ", '" & tCity & "', '" & tZip & "', '" & tPhone & "'" & txtMemo2 & ", " & tStateID & ", " & tCntryID & ", " & valCustID & ",1,1);"

            Dim valLocID As Int32 = tblLocation.idTransaction(strSQL)

            InsertLocationWEB = valLocID

        End Function


        Public Function InsertCreditCardWEB(ByVal valCustID As Int32) As Int32

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
            tCCnumber & "', '" & tCCVnumber & "', " & tCCtypeID & ", '" & tDateExp & "', " & valCustID & ");"

            Dim valCCiD As Int32 = tblCreditCard.idTransaction(strSQL)

            InsertCreditCardWEB = valCCiD

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


        Private Sub txtCCNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCCNumber.TextChanged

        End Sub

    End Class

End Namespace
