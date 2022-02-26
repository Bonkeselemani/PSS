Option Explicit On 

Imports PSS.Data
Imports PSS.Core

Namespace Gui.Pantech
    Public Class frmReceiving_1
        Inherits System.Windows.Forms.Form

        Private _objPantechRec As PSS.Data.Buisness.Pantech
        Private _objProdRec As PSS.Data.Production.Receiving
        Private _iWOID As Integer = 0
        Private _iTrayID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objPantechRec = New PSS.Data.Buisness.Pantech()
            _objProdRec = New PSS.Data.Production.Receiving()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
                _objPantechRec = Nothing
                _objProdRec = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents gbShipTo As System.Windows.Forms.GroupBox
        Friend WithEvents txtEmailAddress As System.Windows.Forms.TextBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents cboStates As C1.Win.C1List.C1Combo
        Friend WithEvents txtFaxNumber As System.Windows.Forms.TextBox
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtPhoneNumber As System.Windows.Forms.TextBox
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
        Friend WithEvents cboCountries As C1.Win.C1List.C1Combo
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents btnManuallyRecFrExcelFile As System.Windows.Forms.Button
        Friend WithEvents btnRePrintManifest As System.Windows.Forms.Button
        Friend WithEvents rbtnOW As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnIW As System.Windows.Forms.RadioButton
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblRecQty As System.Windows.Forms.Label
        Friend WithEvents dgReceivedUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtMechanicalSN As System.Windows.Forms.TextBox
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents lblWarrantyStatus As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnReOpenRMA As System.Windows.Forms.Button
        Friend WithEvents btnCloseRMA As System.Windows.Forms.Button
        Friend WithEvents txtRMA As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dgOpenRMA As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblMachanicalSNLabel As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtCompany As System.Windows.Forms.TextBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents btClearRMA As System.Windows.Forms.Button
        Friend WithEvents btnCreateRMA As System.Windows.Forms.Button
        Friend WithEvents dbgShipToAddress As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnSelectShipToAddress As System.Windows.Forms.Button
        Friend WithEvents btnUpdateShipToInfo As System.Windows.Forms.Button
        Friend WithEvents btnEditShipToInfo As System.Windows.Forms.Button
        Friend WithEvents btnClearShipToCtrls As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReceiving_1))
            Me.gbShipTo = New System.Windows.Forms.GroupBox()
            Me.btnClearShipToCtrls = New System.Windows.Forms.Button()
            Me.btnEditShipToInfo = New System.Windows.Forms.Button()
            Me.txtCompany = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtEmailAddress = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboStates = New C1.Win.C1List.C1Combo()
            Me.txtFaxNumber = New System.Windows.Forms.TextBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtPhoneNumber = New System.Windows.Forms.TextBox()
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
            Me.btnUpdateShipToInfo = New System.Windows.Forms.Button()
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.btnManuallyRecFrExcelFile = New System.Windows.Forms.Button()
            Me.btnRePrintManifest = New System.Windows.Forms.Button()
            Me.rbtnOW = New System.Windows.Forms.RadioButton()
            Me.rbtnIW = New System.Windows.Forms.RadioButton()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblRecQty = New System.Windows.Forms.Label()
            Me.dgReceivedUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblMachanicalSNLabel = New System.Windows.Forms.Label()
            Me.txtMechanicalSN = New System.Windows.Forms.TextBox()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.lblWarrantyStatus = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnCreateRMA = New System.Windows.Forms.Button()
            Me.btnReOpenRMA = New System.Windows.Forms.Button()
            Me.btnCloseRMA = New System.Windows.Forms.Button()
            Me.txtRMA = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btClearRMA = New System.Windows.Forms.Button()
            Me.dgOpenRMA = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgShipToAddress = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.btnSelectShipToAddress = New System.Windows.Forms.Button()
            Me.gbShipTo.SuspendLayout()
            CType(Me.cboStates, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCountries, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgReceivedUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.dgOpenRMA, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgShipToAddress, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'gbShipTo
            '
            Me.gbShipTo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbShipTo.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClearShipToCtrls, Me.btnEditShipToInfo, Me.txtCompany, Me.Label4, Me.txtEmailAddress, Me.Label7, Me.cboStates, Me.txtFaxNumber, Me.Label8, Me.txtPhoneNumber, Me.lblPhoneNumber, Me.txtZipCode, Me.txtCity, Me.txtAddress2, Me.txtAddress1, Me.txtLastName, Me.txtFirstName, Me.lblZipCode, Me.lblState, Me.lblCity, Me.lblAddress2, Me.lblAddress1, Me.lblLastName, Me.lblFirstName, Me.lblCountry, Me.cboCountries, Me.btnUpdateShipToInfo})
            Me.gbShipTo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbShipTo.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.gbShipTo.Location = New System.Drawing.Point(480, 48)
            Me.gbShipTo.Name = "gbShipTo"
            Me.gbShipTo.Size = New System.Drawing.Size(440, 250)
            Me.gbShipTo.TabIndex = 131
            Me.gbShipTo.TabStop = False
            Me.gbShipTo.Tag = "0"
            Me.gbShipTo.Text = "Ship To"
            '
            'btnClearShipToCtrls
            '
            Me.btnClearShipToCtrls.BackColor = System.Drawing.Color.CadetBlue
            Me.btnClearShipToCtrls.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearShipToCtrls.ForeColor = System.Drawing.Color.White
            Me.btnClearShipToCtrls.Location = New System.Drawing.Point(112, 221)
            Me.btnClearShipToCtrls.Name = "btnClearShipToCtrls"
            Me.btnClearShipToCtrls.Size = New System.Drawing.Size(96, 20)
            Me.btnClearShipToCtrls.TabIndex = 36
            Me.btnClearShipToCtrls.Text = "Clear"
            '
            'btnEditShipToInfo
            '
            Me.btnEditShipToInfo.BackColor = System.Drawing.Color.CadetBlue
            Me.btnEditShipToInfo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnEditShipToInfo.ForeColor = System.Drawing.Color.White
            Me.btnEditShipToInfo.Location = New System.Drawing.Point(224, 221)
            Me.btnEditShipToInfo.Name = "btnEditShipToInfo"
            Me.btnEditShipToInfo.Size = New System.Drawing.Size(96, 20)
            Me.btnEditShipToInfo.TabIndex = 35
            Me.btnEditShipToInfo.Text = "Edit"
            '
            'txtCompany
            '
            Me.txtCompany.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCompany.Location = New System.Drawing.Point(104, 21)
            Me.txtCompany.Name = "txtCompany"
            Me.txtCompany.Size = New System.Drawing.Size(328, 21)
            Me.txtCompany.TabIndex = 1
            Me.txtCompany.Text = ""
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(8, 21)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(88, 16)
            Me.Label4.TabIndex = 34
            Me.Label4.Text = "Company:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEmailAddress
            '
            Me.txtEmailAddress.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtEmailAddress.Location = New System.Drawing.Point(104, 189)
            Me.txtEmailAddress.MaxLength = 50
            Me.txtEmailAddress.Name = "txtEmailAddress"
            Me.txtEmailAddress.Size = New System.Drawing.Size(328, 21)
            Me.txtEmailAddress.TabIndex = 12
            Me.txtEmailAddress.Text = ""
            '
            'Label7
            '
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.Location = New System.Drawing.Point(8, 189)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 16)
            Me.Label7.TabIndex = 32
            Me.Label7.Text = "Email Address:"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboStates.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStates.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboStates.ItemHeight = 15
            Me.cboStates.Location = New System.Drawing.Point(312, 117)
            Me.cboStates.MatchEntryTimeout = CType(2000, Long)
            Me.cboStates.MaxDropDownItems = CType(5, Short)
            Me.cboStates.MaxLength = 2
            Me.cboStates.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboStates.Name = "cboStates"
            Me.cboStates.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboStates.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboStates.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboStates.Size = New System.Drawing.Size(120, 21)
            Me.cboStates.TabIndex = 7
            Me.cboStates.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'txtFaxNumber
            '
            Me.txtFaxNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFaxNumber.Location = New System.Drawing.Point(312, 165)
            Me.txtFaxNumber.MaxLength = 12
            Me.txtFaxNumber.Name = "txtFaxNumber"
            Me.txtFaxNumber.Size = New System.Drawing.Size(120, 21)
            Me.txtFaxNumber.TabIndex = 11
            Me.txtFaxNumber.Text = ""
            '
            'Label8
            '
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.Location = New System.Drawing.Point(256, 165)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(56, 16)
            Me.Label8.TabIndex = 30
            Me.Label8.Text = "Fax #:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPhoneNumber
            '
            Me.txtPhoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPhoneNumber.Location = New System.Drawing.Point(104, 165)
            Me.txtPhoneNumber.MaxLength = 12
            Me.txtPhoneNumber.Name = "txtPhoneNumber"
            Me.txtPhoneNumber.Size = New System.Drawing.Size(125, 21)
            Me.txtPhoneNumber.TabIndex = 10
            Me.txtPhoneNumber.Text = ""
            '
            'lblPhoneNumber
            '
            Me.lblPhoneNumber.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPhoneNumber.Location = New System.Drawing.Point(8, 165)
            Me.lblPhoneNumber.Name = "lblPhoneNumber"
            Me.lblPhoneNumber.Size = New System.Drawing.Size(88, 16)
            Me.lblPhoneNumber.TabIndex = 27
            Me.lblPhoneNumber.Text = "Phone #:"
            Me.lblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtZipCode
            '
            Me.txtZipCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtZipCode.Location = New System.Drawing.Point(104, 141)
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.Size = New System.Drawing.Size(125, 21)
            Me.txtZipCode.TabIndex = 8
            Me.txtZipCode.Text = ""
            '
            'txtCity
            '
            Me.txtCity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCity.Location = New System.Drawing.Point(104, 117)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(125, 21)
            Me.txtCity.TabIndex = 6
            Me.txtCity.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress2.Location = New System.Drawing.Point(104, 93)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.Size = New System.Drawing.Size(328, 21)
            Me.txtAddress2.TabIndex = 5
            Me.txtAddress2.Text = ""
            '
            'txtAddress1
            '
            Me.txtAddress1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtAddress1.Location = New System.Drawing.Point(104, 69)
            Me.txtAddress1.Name = "txtAddress1"
            Me.txtAddress1.Size = New System.Drawing.Size(328, 21)
            Me.txtAddress1.TabIndex = 4
            Me.txtAddress1.Text = ""
            '
            'txtLastName
            '
            Me.txtLastName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtLastName.Location = New System.Drawing.Point(312, 45)
            Me.txtLastName.Name = "txtLastName"
            Me.txtLastName.Size = New System.Drawing.Size(120, 21)
            Me.txtLastName.TabIndex = 3
            Me.txtLastName.Text = ""
            '
            'txtFirstName
            '
            Me.txtFirstName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtFirstName.Location = New System.Drawing.Point(104, 45)
            Me.txtFirstName.Name = "txtFirstName"
            Me.txtFirstName.Size = New System.Drawing.Size(125, 21)
            Me.txtFirstName.TabIndex = 2
            Me.txtFirstName.Text = ""
            '
            'lblZipCode
            '
            Me.lblZipCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblZipCode.Location = New System.Drawing.Point(24, 141)
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Size = New System.Drawing.Size(72, 16)
            Me.lblZipCode.TabIndex = 13
            Me.lblZipCode.Text = "Zip Code:"
            Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblState
            '
            Me.lblState.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblState.Location = New System.Drawing.Point(263, 117)
            Me.lblState.Name = "lblState"
            Me.lblState.Size = New System.Drawing.Size(48, 16)
            Me.lblState.TabIndex = 10
            Me.lblState.Text = "State:"
            Me.lblState.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblCity
            '
            Me.lblCity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCity.Location = New System.Drawing.Point(8, 117)
            Me.lblCity.Name = "lblCity"
            Me.lblCity.Size = New System.Drawing.Size(88, 16)
            Me.lblCity.TabIndex = 11
            Me.lblCity.Text = "City:"
            Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress2
            '
            Me.lblAddress2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAddress2.Location = New System.Drawing.Point(8, 93)
            Me.lblAddress2.Name = "lblAddress2"
            Me.lblAddress2.Size = New System.Drawing.Size(88, 16)
            Me.lblAddress2.TabIndex = 16
            Me.lblAddress2.Text = "Address(2):"
            Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress1
            '
            Me.lblAddress1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAddress1.Location = New System.Drawing.Point(8, 69)
            Me.lblAddress1.Name = "lblAddress1"
            Me.lblAddress1.Size = New System.Drawing.Size(88, 16)
            Me.lblAddress1.TabIndex = 17
            Me.lblAddress1.Text = "Address(1):"
            Me.lblAddress1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLastName
            '
            Me.lblLastName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLastName.Location = New System.Drawing.Point(224, 45)
            Me.lblLastName.Name = "lblLastName"
            Me.lblLastName.Size = New System.Drawing.Size(88, 16)
            Me.lblLastName.TabIndex = 14
            Me.lblLastName.Text = "Last Name:"
            Me.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFirstName
            '
            Me.lblFirstName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFirstName.Location = New System.Drawing.Point(8, 45)
            Me.lblFirstName.Name = "lblFirstName"
            Me.lblFirstName.Size = New System.Drawing.Size(88, 16)
            Me.lblFirstName.TabIndex = 15
            Me.lblFirstName.Text = "First Name:"
            Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCountry
            '
            Me.lblCountry.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCountry.Location = New System.Drawing.Point(248, 141)
            Me.lblCountry.Name = "lblCountry"
            Me.lblCountry.Size = New System.Drawing.Size(64, 16)
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
            Me.cboCountries.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCountries.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCountries.ItemHeight = 15
            Me.cboCountries.Location = New System.Drawing.Point(312, 141)
            Me.cboCountries.MatchEntryTimeout = CType(2000, Long)
            Me.cboCountries.MaxDropDownItems = CType(5, Short)
            Me.cboCountries.MaxLength = 32767
            Me.cboCountries.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCountries.Name = "cboCountries"
            Me.cboCountries.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCountries.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCountries.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCountries.Size = New System.Drawing.Size(120, 21)
            Me.cboCountries.TabIndex = 9
            Me.cboCountries.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnUpdateShipToInfo
            '
            Me.btnUpdateShipToInfo.BackColor = System.Drawing.Color.CadetBlue
            Me.btnUpdateShipToInfo.Enabled = False
            Me.btnUpdateShipToInfo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateShipToInfo.ForeColor = System.Drawing.Color.White
            Me.btnUpdateShipToInfo.Location = New System.Drawing.Point(336, 221)
            Me.btnUpdateShipToInfo.Name = "btnUpdateShipToInfo"
            Me.btnUpdateShipToInfo.Size = New System.Drawing.Size(96, 20)
            Me.btnUpdateShipToInfo.TabIndex = 13
            Me.btnUpdateShipToInfo.Text = "Update"
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Black
            Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(328, 48)
            Me.lblHeader.TabIndex = 133
            Me.lblHeader.Text = "PANTECH RECEIVING"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnManuallyRecFrExcelFile
            '
            Me.btnManuallyRecFrExcelFile.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnManuallyRecFrExcelFile.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnManuallyRecFrExcelFile.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnManuallyRecFrExcelFile.ForeColor = System.Drawing.Color.White
            Me.btnManuallyRecFrExcelFile.Location = New System.Drawing.Point(8, 4)
            Me.btnManuallyRecFrExcelFile.Name = "btnManuallyRecFrExcelFile"
            Me.btnManuallyRecFrExcelFile.Size = New System.Drawing.Size(80, 20)
            Me.btnManuallyRecFrExcelFile.TabIndex = 136
            Me.btnManuallyRecFrExcelFile.Text = "Manually Receive From Excel File"
            Me.btnManuallyRecFrExcelFile.Visible = False
            '
            'btnRePrintManifest
            '
            Me.btnRePrintManifest.BackColor = System.Drawing.Color.DarkSlateGray
            Me.btnRePrintManifest.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRePrintManifest.ForeColor = System.Drawing.Color.White
            Me.btnRePrintManifest.Location = New System.Drawing.Point(400, 57)
            Me.btnRePrintManifest.Name = "btnRePrintManifest"
            Me.btnRePrintManifest.Size = New System.Drawing.Size(72, 35)
            Me.btnRePrintManifest.TabIndex = 128
            Me.btnRePrintManifest.Text = "Re-Print Manifest"
            '
            'rbtnOW
            '
            Me.rbtnOW.Checked = True
            Me.rbtnOW.ForeColor = System.Drawing.Color.Red
            Me.rbtnOW.Location = New System.Drawing.Point(8, 72)
            Me.rbtnOW.Name = "rbtnOW"
            Me.rbtnOW.Size = New System.Drawing.Size(136, 24)
            Me.rbtnOW.TabIndex = 3
            Me.rbtnOW.TabStop = True
            Me.rbtnOW.Text = "Out of Warranty"
            '
            'rbtnIW
            '
            Me.rbtnIW.ForeColor = System.Drawing.Color.White
            Me.rbtnIW.Location = New System.Drawing.Point(8, 48)
            Me.rbtnIW.Name = "rbtnIW"
            Me.rbtnIW.Size = New System.Drawing.Size(112, 24)
            Me.rbtnIW.TabIndex = 2
            Me.rbtnIW.Text = "In Warranty"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Black
            Me.Label5.ForeColor = System.Drawing.Color.Green
            Me.Label5.Location = New System.Drawing.Point(400, 6)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 16)
            Me.Label5.TabIndex = 127
            Me.Label5.Text = "Qty"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblRecQty
            '
            Me.lblRecQty.BackColor = System.Drawing.Color.Black
            Me.lblRecQty.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecQty.ForeColor = System.Drawing.Color.Green
            Me.lblRecQty.Location = New System.Drawing.Point(400, 22)
            Me.lblRecQty.Name = "lblRecQty"
            Me.lblRecQty.Size = New System.Drawing.Size(72, 32)
            Me.lblRecQty.TabIndex = 126
            Me.lblRecQty.Text = "100"
            Me.lblRecQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'dgReceivedUnits
            '
            Me.dgReceivedUnits.AllowUpdate = False
            Me.dgReceivedUnits.AlternatingRows = True
            Me.dgReceivedUnits.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dgReceivedUnits.FilterBar = True
            Me.dgReceivedUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgReceivedUnits.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dgReceivedUnits.Location = New System.Drawing.Point(8, 96)
            Me.dgReceivedUnits.Name = "dgReceivedUnits"
            Me.dgReceivedUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgReceivedUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgReceivedUnits.PreviewInfo.ZoomFactor = 75
            Me.dgReceivedUnits.Size = New System.Drawing.Size(464, 132)
            Me.dgReceivedUnits.TabIndex = 9
            Me.dgReceivedUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;BackColor:SteelBlue;}Normal{Font:Microsoft San" & _
            "s Serif, 8.25pt;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10" & _
            "{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}Hig" & _
            "hlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelector{AlignImage" & _
            ":Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackCo" & _
            "lor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:True;AlignVert:" & _
            "Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Filter" & _
            "Bar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;" & _
            "}Style4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, " & _
            "0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><" & _
            "Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" Caption" & _
            "Height=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Ma" & _
            "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Verti" & _
            "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>128</Height><CaptionStyle p" & _
            "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
            "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
            "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
            "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
            "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
            "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
            "ent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 460, 128</ClientRect><BorderSide>0<" & _
            "/BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></S" & _
            "plits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Hea" & _
            "ding"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Captio" & _
            "n"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected" & _
            """ /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow" & _
            """ /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><" & _
            "Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBa" & _
            "r"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplit" & _
            "s><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Default" & _
            "RecSelWidth><ClientArea>0, 0, 460, 128</ClientArea><PrintPageHeaderStyle parent=" & _
            """"" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'lblMachanicalSNLabel
            '
            Me.lblMachanicalSNLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachanicalSNLabel.ForeColor = System.Drawing.Color.White
            Me.lblMachanicalSNLabel.Location = New System.Drawing.Point(208, 8)
            Me.lblMachanicalSNLabel.Name = "lblMachanicalSNLabel"
            Me.lblMachanicalSNLabel.Size = New System.Drawing.Size(40, 16)
            Me.lblMachanicalSNLabel.TabIndex = 125
            Me.lblMachanicalSNLabel.Text = "S/N:"
            Me.lblMachanicalSNLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight
            '
            'txtMechanicalSN
            '
            Me.txtMechanicalSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMechanicalSN.Location = New System.Drawing.Point(224, 24)
            Me.txtMechanicalSN.Name = "txtMechanicalSN"
            Me.txtMechanicalSN.Size = New System.Drawing.Size(160, 21)
            Me.txtMechanicalSN.TabIndex = 4
            Me.txtMechanicalSN.Text = ""
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(8, 24)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(192, 21)
            Me.cboModel.TabIndex = 1
            Me.cboModel.Text = "C1Combo1"
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(8, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(48, 16)
            Me.Label3.TabIndex = 123
            Me.Label3.Text = "Model:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(224, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 16)
            Me.Label2.TabIndex = 121
            Me.Label2.Text = "IMEI:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtIMEI
            '
            Me.txtIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.Location = New System.Drawing.Point(224, 64)
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(160, 21)
            Me.txtIMEI.TabIndex = 5
            Me.txtIMEI.Text = ""
            '
            'lblWarrantyStatus
            '
            Me.lblWarrantyStatus.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblWarrantyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWarrantyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWarrantyStatus.ForeColor = System.Drawing.Color.White
            Me.lblWarrantyStatus.Location = New System.Drawing.Point(328, 0)
            Me.lblWarrantyStatus.Name = "lblWarrantyStatus"
            Me.lblWarrantyStatus.Size = New System.Drawing.Size(592, 48)
            Me.lblWarrantyStatus.TabIndex = 134
            Me.lblWarrantyStatus.Text = "OUT OF WARRANTY"
            Me.lblWarrantyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel1
            '
            Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreateRMA, Me.btnReOpenRMA, Me.btnCloseRMA, Me.txtRMA, Me.Label1, Me.btClearRMA, Me.btnManuallyRecFrExcelFile})
            Me.Panel1.Location = New System.Drawing.Point(0, 300)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(920, 32)
            Me.Panel1.TabIndex = 130
            '
            'btnCreateRMA
            '
            Me.btnCreateRMA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCreateRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btnCreateRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateRMA.ForeColor = System.Drawing.Color.White
            Me.btnCreateRMA.Location = New System.Drawing.Point(616, 4)
            Me.btnCreateRMA.Name = "btnCreateRMA"
            Me.btnCreateRMA.Size = New System.Drawing.Size(64, 20)
            Me.btnCreateRMA.TabIndex = 2
            Me.btnCreateRMA.Text = "Create"
            '
            'btnReOpenRMA
            '
            Me.btnReOpenRMA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnReOpenRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btnReOpenRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenRMA.ForeColor = System.Drawing.Color.White
            Me.btnReOpenRMA.Location = New System.Drawing.Point(768, 4)
            Me.btnReOpenRMA.Name = "btnReOpenRMA"
            Me.btnReOpenRMA.Size = New System.Drawing.Size(72, 20)
            Me.btnReOpenRMA.TabIndex = 4
            Me.btnReOpenRMA.Text = "Re-Open"
            '
            'btnCloseRMA
            '
            Me.btnCloseRMA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnCloseRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btnCloseRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseRMA.ForeColor = System.Drawing.Color.White
            Me.btnCloseRMA.Location = New System.Drawing.Point(696, 4)
            Me.btnCloseRMA.Name = "btnCloseRMA"
            Me.btnCloseRMA.Size = New System.Drawing.Size(56, 20)
            Me.btnCloseRMA.TabIndex = 3
            Me.btnCloseRMA.Text = "Close"
            '
            'txtRMA
            '
            Me.txtRMA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.txtRMA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRMA.Location = New System.Drawing.Point(432, 4)
            Me.txtRMA.Name = "txtRMA"
            Me.txtRMA.Size = New System.Drawing.Size(168, 21)
            Me.txtRMA.TabIndex = 1
            Me.txtRMA.Text = ""
            '
            'Label1
            '
            Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(368, 5)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 117
            Me.Label1.Text = "RMA # :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btClearRMA
            '
            Me.btClearRMA.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btClearRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btClearRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btClearRMA.ForeColor = System.Drawing.Color.White
            Me.btClearRMA.Location = New System.Drawing.Point(856, 4)
            Me.btClearRMA.Name = "btClearRMA"
            Me.btClearRMA.Size = New System.Drawing.Size(56, 20)
            Me.btClearRMA.TabIndex = 5
            Me.btClearRMA.Text = "Clear"
            '
            'dgOpenRMA
            '
            Me.dgOpenRMA.AllowUpdate = False
            Me.dgOpenRMA.AlternatingRows = True
            Me.dgOpenRMA.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgOpenRMA.Caption = "Open RMA"
            Me.dgOpenRMA.CaptionHeight = 17
            Me.dgOpenRMA.FilterBar = True
            Me.dgOpenRMA.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgOpenRMA.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dgOpenRMA.Location = New System.Drawing.Point(0, 332)
            Me.dgOpenRMA.Name = "dgOpenRMA"
            Me.dgOpenRMA.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgOpenRMA.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgOpenRMA.PreviewInfo.ZoomFactor = 75
            Me.dgOpenRMA.Size = New System.Drawing.Size(432, 256)
            Me.dgOpenRMA.TabIndex = 135
            Me.dgOpenRMA.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;BackColor:SteelBlue;}Normal{Font:Microsoft San" & _
            "s Serif, 8.25pt;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10" & _
            "{AlignHorz:Near;}Style11{}OddRow{ForeColor:White;BackColor:CadetBlue;}Style13{}S" & _
            "tyle12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelector" & _
            "{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaption" & _
            "Text;BackColor:InactiveCaption;}EvenRow{ForeColor:White;BackColor:SteelBlue;}Hea" & _
            "ding{Wrap:True;Font:Tahoma, 8.25pt, style=Bold;BackColor:SteelBlue;Border:Raised" & _
            ",,1, 1, 1, 1;ForeColor:White;AlignVert:Center;}FilterBar{Font:Microsoft Sans Ser" & _
            "if, 8.25pt;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{" & _
            "AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}" & _
            "Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView N" & _
            "ame="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Co" & _
            "lumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSel" & _
            "ectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGrou" & _
            "p=""1""><Height>235</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSt" & _
            "yle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><" & _
            "FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>" & _
            "0, 17, 428, 235</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Borde" & _
            "rStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me" & _
            "=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Fo" & _
            "oter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inact" & _
            "ive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor""" & _
            " /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow" & _
            """ /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelec" & _
            "tor"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group" & _
            """ /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>No" & _
            "ne</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 428, 252" & _
            "</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyl" & _
            "e parent="""" me=""Style21"" /></Blob>"
            '
            'dbgShipToAddress
            '
            Me.dbgShipToAddress.AllowUpdate = False
            Me.dbgShipToAddress.AlternatingRows = True
            Me.dbgShipToAddress.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgShipToAddress.Caption = "Ship To Address"
            Me.dbgShipToAddress.CaptionHeight = 17
            Me.dbgShipToAddress.FilterBar = True
            Me.dbgShipToAddress.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgShipToAddress.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.dbgShipToAddress.Location = New System.Drawing.Point(0, 48)
            Me.dbgShipToAddress.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.dbgShipToAddress.Name = "dbgShipToAddress"
            Me.dbgShipToAddress.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgShipToAddress.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgShipToAddress.PreviewInfo.ZoomFactor = 75
            Me.dbgShipToAddress.Size = New System.Drawing.Size(432, 250)
            Me.dbgShipToAddress.TabIndex = 137
            Me.dbgShipToAddress.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Stee" & _
            "lBlue;}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:SteelBlue;}Selected{Fo" & _
            "reColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}St" & _
            "yle15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{ForeColor:Black" & _
            ";BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style2" & _
            "0{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{For" & _
            "eColor:White;BackColor:SteelBlue;}Heading{Wrap:True;Font:Tahoma, 8.25pt;AlignVer" & _
            "t:Center;Border:Raised,,1, 1, 1, 1;ForeColor:White;BackColor:Teal;}FilterBar{Fon" & _
            "t:Microsoft Sans Serif, 6pt;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style" & _
            "8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;" & _
            "}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueD" & _
            "BGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapt" & _
            "ionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCell" & _
            "Border"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Hor" & _
            "izontalScrollGroup=""1""><Height>229</Height><CaptionStyle parent=""Style2"" me=""Sty" & _
            "le10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle p" & _
            "arent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingS" & _
            "tyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=" & _
            """Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""O" & _
            "ddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /" & _
            "><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style" & _
            "1"" /><ClientRect>0, 17, 428, 229</ClientRect><BorderSide>0</BorderSide><BorderSt" & _
            "yle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><S" & _
            "tyle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent" & _
            "=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""H" & _
            "eading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""No" & _
            "rmal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""No" & _
            "rmal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading" & _
            """ me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""C" & _
            "aption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horz" & _
            "Splits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientAr" & _
            "ea>0, 0, 428, 246</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><Pr" & _
            "intPageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'Panel2
            '
            Me.Panel2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMachanicalSNLabel, Me.txtIMEI, Me.dgReceivedUnits, Me.Label3, Me.rbtnOW, Me.Label2, Me.rbtnIW, Me.txtMechanicalSN, Me.cboModel, Me.btnRePrintManifest, Me.Label5, Me.lblRecQty})
            Me.Panel2.Location = New System.Drawing.Point(432, 332)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(488, 256)
            Me.Panel2.TabIndex = 138
            '
            'btnSelectShipToAddress
            '
            Me.btnSelectShipToAddress.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnSelectShipToAddress.BackColor = System.Drawing.Color.Blue
            Me.btnSelectShipToAddress.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectShipToAddress.ForeColor = System.Drawing.Color.White
            Me.btnSelectShipToAddress.Location = New System.Drawing.Point(436, 152)
            Me.btnSelectShipToAddress.Name = "btnSelectShipToAddress"
            Me.btnSelectShipToAddress.Size = New System.Drawing.Size(40, 20)
            Me.btnSelectShipToAddress.TabIndex = 139
            Me.btnSelectShipToAddress.Text = "=>"
            '
            'frmReceiving_1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(928, 606)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSelectShipToAddress, Me.Panel2, Me.dbgShipToAddress, Me.gbShipTo, Me.lblHeader, Me.lblWarrantyStatus, Me.Panel1, Me.dgOpenRMA})
            Me.Name = "frmReceiving_1"
            Me.Text = "frmReceiving_1"
            Me.gbShipTo.ResumeLayout(False)
            CType(Me.cboStates, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCountries, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgReceivedUnits, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgOpenRMA, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgShipToAddress, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************************************************
        Private Sub frmReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Dim objDC As PSS.Data.Buisness.DriveCam

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                '*********************************
                'Load Open Order & Box Type
                '*********************************
                Me.LoadOpenWorkOrder()
                Me.LoadPantechShipToInfo()

                objDC = New PSS.Data.Buisness.DriveCam()
                dt = objDC.GetState(True, False)
                Misc.PopulateC1DropDownList(Me.cboStates, dt, "State_Desc", "State_ID")
                Me.cboStates.SelectedValue = 0

                Buisness.Generic.DisposeDT(dt)
                dt = objDC.GetCountry(True)
                Misc.PopulateC1DropDownList(Me.cboCountries, dt, "Cntry_Name", "Cntry_ID")
                Me.cboCountries.SelectedValue = 161

                Buisness.Generic.DisposeDT(dt)
                dt = Me._objProdRec.GetModelList(True, Buisness.Pantech.Pantech_PRODID, Buisness.Pantech.ManufID)
                Misc.PopulateC1DropDownList(Me.cboModel, dt, "Model_Desc", "Model_ID")
                Me.cboModel.SelectedValue = 0

                '*********************************
                Me.txtRMA.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmReceiving_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                objDC = Nothing
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function LoadOpenWorkOrder()
            Dim dt As DataTable

            Try
                dt = Me._objProdRec.GetOpenWorkordersList(Buisness.Pantech.Pantech_LOC_ID, True)
                dt.Columns("WO_CustWO").ColumnName = "RMA #"
                dt.AcceptChanges()

                With Me.dgOpenRMA
                    .DataSource = dt.DefaultView

                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("WO Received Qty").Visible = False
                    .Splits(0).DisplayColumns("Loc_ID").Visible = False
                    .Splits(0).DisplayColumns("Group_ID").Visible = False
                    .Splits(0).DisplayColumns("State_ID").Visible = False
                    .Splits(0).DisplayColumns("Cntry_ID").Visible = False
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************
        Private Function LoadPantechShipToInfo(Optional ByVal iShipToID As Integer = 0)
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                dt = Me._objProdRec.GetWorkorderShipToInfoList(Buisness.Pantech.Pantech_LOC_ID, False)

                With Me.dbgShipToAddress
                    .DataSource = dt.DefaultView

                    .Splits(0).DisplayColumns("ShipTo_ID").Visible = False
                    .Splits(0).DisplayColumns("State_ID").Visible = False
                    .Splits(0).DisplayColumns("Cntry_ID").Visible = False

                    If iShipToID > 0 Then
                        For i = 0 To .RowCount - 1
                            If .Columns("ShipTo_ID").CellValue(i) = iShipToID Then Exit Function
                            .MoveNext()
                        Next i
                    End If
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*************************************************************************************************************
        Private Sub ClearRMAControlsAndVars()
            Try
                _iWOID = 0 : _iTrayID = 0

                Me.lblWarrantyStatus.Text = "" : Me.lblWarrantyStatus.BackColor = Color.SteelBlue

                'Ship to 
                ClearShipToControls()

                'Device
                Me.cboModel.SelectedValue = 0
                Me.txtMechanicalSN.Text = ""
                Me.txtIMEI.Text = ""

                Me.dgReceivedUnits.DataSource = Nothing
                Me.lblRecQty.Text = "0"

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btClearRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClearRMA.Click
            Try
                Me.txtRMA.Text = "" : Me.txtRMA.Enabled = True
                ClearRMAControlsAndVars()
                Me.txtRMA.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnNewRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnCloseRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseRMA.Click
            Dim R1 As DataRow
            Dim i, iRecUnitCnt As Integer

            Try
                If Me._iTrayID = 0 Then
                    MessageBox.Show("Tray ID is missing for this RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                R1 = Me._objProdRec.GetWorkorderInfo(Me.txtRMA.Text.Trim, , Buisness.Pantech.Pantech_LOC_ID)
                i = 0 : iRecUnitCnt = 0

                If IsNothing(R1) Then
                    MessageBox.Show("This RMA # '" & Me.txtRMA.Text.Trim & "' does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("WO_Closed") = 1 Then
                    MessageBox.Show("This RMA # '" & Me.txtRMA.Text.Trim & "' is already closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("WO_Shipped") = 1 Then
                    MessageBox.Show("This RMA # '" & Me.txtRMA.Text.Trim & "' has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iRecUnitCnt = PSS.Data.Buisness.Generic.GetRecQty(R1("WO_ID"))
                    If iRecUnitCnt = 0 Then
                        MessageBox.Show("This RMA # '" & Me.txtRMA.Text.Trim & "' is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.CloseWO(R1("WO_ID"))
                        If i > 0 Then
                            PSS.Data.Buisness.MessReceive.PrintRecReport(Me._iTrayID, 1)
                            Me.ClearRMAControlsAndVars() : Me.LoadOpenWorkOrder()
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            Me.txtRMA.Enabled = True : Me.txtRMA.Text = "" : Me.txtRMA.Focus()
                            MessageBox.Show("RMA is closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnReOpenRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReOpenRMA.Click
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strRMA As String = ""

            Try
                strRMA = InputBox("Enter RMA #:").Trim.ToUpper
                If strRMA.Trim.Length > 0 Then
                    Me.txtRMA.Text = "" : Me.ClearRMAControlsAndVars()

                    R1 = Me._objProdRec.GetWorkorderInfo(strRMA, , Buisness.Pantech.Pantech_LOC_ID)

                    If IsNothing(R1) Then
                        MessageBox.Show("This RMA # " & Me.txtRMA.Text.Trim & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf R1("WO_Closed") = 0 Then
                        MessageBox.Show("This RMA # " & Me.txtRMA.Text.Trim & " is open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (Not IsDBNull(R1("WO_DateShip")) AndAlso R1("WO_DateShip").ToString.Trim.Length > 0) OrElse R1("WO_Shipped") = 1 Then
                        MessageBox.Show("This RMA # " & Me.txtRMA.Text.Trim & " has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.ReOpenWO(R1("WO_ID"))
                        If i > 0 Then
                            Me.LoadOpenWorkOrder() : Me.txtRMA.Text = strRMA : Me.ProcessRMA(strRMA)
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            MessageBox.Show("RMA is now open for receiving.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReOpenRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub Contrls_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCompany.KeyUp, txtFirstName.KeyUp, txtLastName.KeyUp, txtAddress1.KeyUp, txtAddress2.KeyUp, txtCity.KeyUp, cboStates.KeyUp, txtZipCode.KeyUp, cboCountries.KeyUp, txtPhoneNumber.KeyUp, txtFaxNumber.KeyUp, txtEmailAddress.KeyUp, cboModel.KeyUp, txtIMEI.KeyUp, txtMechanicalSN.KeyUp, txtRMA.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "txtCompany" Then
                        If Me.txtCompany.Text.Trim.Length > 0 Then
                            Me.txtFirstName.SelectAll() : Me.txtFirstName.Focus()
                        End If
                    ElseIf sender.name = "txtFirstName" Then
                        If Me.txtFirstName.Text.Trim.Length > 0 Then
                            Me.txtLastName.SelectAll() : Me.txtLastName.Focus()
                        End If
                    ElseIf sender.name = "txtLastName" Then
                        If Me.txtLastName.Text.Trim.Length > 0 Then
                            Me.txtAddress1.SelectAll() : Me.txtAddress1.Focus()
                        End If
                    ElseIf sender.name = "txtAddress1" Then
                        If Me.txtAddress1.Text.Trim.Length > 0 Then
                            Me.txtAddress2.SelectAll() : Me.txtAddress2.Focus()
                        End If
                    ElseIf sender.name = "txtAddress2" Then
                        If Me.txtAddress2.Text.Trim.Length > 0 Then
                            Me.txtCity.SelectAll() : Me.txtCity.Focus()
                        End If
                    ElseIf sender.name = "txtCity" Then
                        If Me.txtCity.Text.Trim.Length > 0 Then
                            Me.cboStates.SelectAll() : Me.cboStates.Focus()
                        End If
                    ElseIf sender.name = "cboStates" Then
                        If Me.cboStates.SelectedValue > 0 Then
                            Me.txtZipCode.SelectAll() : Me.txtZipCode.Focus()
                        End If
                    ElseIf sender.name = "txtZipCode" Then
                        If Me.txtZipCode.Text.Trim.Length > 0 Then
                            Me.cboCountries.SelectAll() : Me.cboCountries.Focus()
                        End If
                    ElseIf sender.name = "cboCountries" Then
                        If Me.cboCountries.SelectedValue > 0 Then
                            Me.txtPhoneNumber.SelectAll() : Me.txtPhoneNumber.Focus()
                        End If
                    ElseIf sender.name = "txtPhoneNumber" Then
                        If Me.txtPhoneNumber.Text.Trim.Length > 0 Then
                            Me.txtFaxNumber.SelectAll() : Me.txtFaxNumber.Focus()
                        End If
                    ElseIf sender.name = "txtFaxNumber" Then
                        If Me.txtFaxNumber.Text.Trim.Length > 0 Then
                            Me.txtEmailAddress.SelectAll() : Me.txtEmailAddress.Focus()
                        End If
                    ElseIf sender.name = "txtMechanicalSN" Then
                        If Me.txtMechanicalSN.Text.Trim.Length > 0 Then
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                        End If
                    ElseIf sender.name = "txtIMEI" Then
                        If Me.txtIMEI.Text.Trim.Length > 0 Then Me.ProcessIMEI()
                    ElseIf sender.name = "txtRMA" Then
                        If Me.txtRMA.Text.Trim.Length > 0 Then Me.ProcessRMA(Me.txtRMA.Text.Trim.ToUpper)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Contrls_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub Contrls_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFirstName.KeyPress, txtLastName.KeyPress, txtEmailAddress.KeyPress, txtPhoneNumber.KeyPress, txtFaxNumber.KeyPress, txtZipCode.KeyPress, txtAddress1.KeyPress, txtAddress2.KeyPress, txtCity.KeyPress, txtMechanicalSN.KeyPress, txtIMEI.KeyPress
            Try
                If sender.name = "txtFirstName" Or sender.name = "txtLastName" Then
                    If Not Char.IsLetter(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
                ElseIf sender.name = "txtEmailAddress" Then
                    If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> "@" AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
                ElseIf sender.name = "txtPhoneNumber" OrElse sender.name = "txtFaxNumber" Then
                    If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "-" AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
                ElseIf sender.name = "txtCity" Then
                    If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
                ElseIf sender.name = "txtZipCode" Then
                    If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
                ElseIf sender.name = "txtAddress1" OrElse sender.name = "txtAddress2" Then
                    If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsWhiteSpace(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
                ElseIf sender.name = "txtMechanicalSN" OrElse sender.name = "txtIMEI" Then
                    If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Contrls_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function ProcessRMA(ByVal strRMANo As String) As Boolean
            Dim R1 As DataRow

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                R1 = Me._objProdRec.GetWorkorderInfo(Me.txtRMA.Text.Trim.ToUpper, , Buisness.Pantech.Pantech_LOC_ID)

                If Not IsNothing(R1) Then
                    If R1("WO_Closed") = 1 Then
                        MessageBox.Show("This RMA has been closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.Enabled = True : Cursor.Current = Cursors.Default
                        Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                        Exit Function
                    Else
                        Me.PopulateShipToInfo(R1("ShipTo_ID"))
                        Me._iWOID = R1("WO_ID")
                        Me._iTrayID = Me._objProdRec.GetTrayID(Me._iWOID)
                        Me.txtRMA.Enabled = False
                        Me.PopulateReceivedUnits(Me._iWOID)
                    End If
                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    Me.cboModel.SelectAll() : Me.cboModel.Focus()
                Else
                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    Me.txtCompany.SelectAll() : Me.txtCompany.Focus()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Function

        '*************************************************************************************************************
        Private Sub PopulateShipToInfo(ByVal iShipToID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objProdRec.GetShipToAddress(iShipToID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("No ship to information.")
                Else
                    Me.txtFirstName.Text = dt.Rows(0)("ShipTo_Name").ToString.Split(" ")(0)
                    Me.txtLastName.Text = dt.Rows(0)("ShipTo_Name").ToString.Split(" ")(1)
                    Me.txtAddress1.Text = dt.Rows(0)("ShipTo_Address1")
                    Me.txtAddress2.Text = dt.Rows(0)("ShipTo_Address2")
                    Me.txtCity.Text = dt.Rows(0)("ShipTo_City")
                    Me.txtZipCode.Text = dt.Rows(0)("ShipTo_Zip")
                    Me.cboStates.SelectedValue = dt.Rows(0)("State_ID")
                    Me.cboStates.SelectedValue = dt.Rows(0)("Cntry_ID")
                    Me.txtPhoneNumber.Text = dt.Rows(0)("Tel")
                    Me.txtFaxNumber.Text = dt.Rows(0)("Fax")
                    Me.txtEmailAddress.Text = dt.Rows(0)("Email")
                    Me.gbShipTo.Tag = dt.Rows(0)("ShipTo_ID")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub PopulateReceivedUnits(ByVal iWOID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objProdRec.GetReceivedDeviceInWO(iWOID, True, False)
                dt.Columns("Device_SN").ColumnName = "IMEI"
                dt.Columns("Cellopt_MSN").ColumnName = "S/N"
                dt.AcceptChanges()

                With Me.dgReceivedUnits
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("IMEI").Width = 100
                    .Splits(0).DisplayColumns("S/N").Width = 100
                End With

                Me.lblRecQty.Text = dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnCreateRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateRMA.Click
            Dim iWOID, iTrayID As Integer

            Try
                If Me.txtRMA.Text.Trim.Length > 0 Then
                    Me._iTrayID = 0 : Me._iWOID = 0 : Me.cboModel.SelectedValue = 0
                    Me.txtMechanicalSN.Text = "" : Me.txtIMEI.Text = "" : Me.dgReceivedUnits.DataSource = Nothing : Me.lblRecQty.Text = "0"
                    iWOID = 0 : iTrayID = 0

                    If CInt(Me.gbShipTo.Tag) > 0 Then
                        If MessageBox.Show("Are you sure you want to create new RMA with the above ship to address?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                    Else
                        If Me.txtFirstName.Text.Trim.Length = 0 Then
                            MessageBox.Show("Please enter first name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtFirstName.SelectAll() : Me.txtFirstName.Focus() : Exit Sub
                        ElseIf Me.txtLastName.Text.Trim.Length = 0 Then
                            MessageBox.Show("Please enter last name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtLastName.SelectAll() : Me.txtLastName.Focus() : Exit Sub
                        ElseIf Me.txtAddress1.Text.Trim.Length = 0 Then
                            MessageBox.Show("Please enter shipping adress.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtAddress1.SelectAll() : Me.txtAddress1.Focus() : Exit Sub
                        ElseIf Me.txtCity.Text.Trim.Length = 0 Then
                            MessageBox.Show("Please enter city.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtCity.SelectAll() : Me.txtCity.Focus() : Exit Sub
                        ElseIf Me.cboStates.SelectedValue = 0 Then
                            MessageBox.Show("Please select state.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboStates.SelectAll() : Me.cboStates.Focus() : Exit Sub
                        ElseIf Me.txtZipCode.Text.Trim.Length = 0 Then
                            MessageBox.Show("Please enter zip code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtZipCode.SelectAll() : Me.txtZipCode.Focus() : Exit Sub
                        ElseIf Me.cboCountries.SelectedValue = 0 Then
                            MessageBox.Show("Please select country.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.cboCountries.SelectAll() : Me.cboCountries.Focus() : Exit Sub
                        End If
                    End If

                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    iWOID = Me._objPantechRec.CreateNewRMA(Me.txtRMA.Text.Trim.ToUpper, CInt(Me.gbShipTo.Tag), Me.txtCompany.Text.Trim, _
                                                   Me.txtFirstName.Text.Trim, Me.txtLastName.Text.Trim, Me.txtAddress1.Text.Trim, _
                                                   Me.txtAddress2.Text.Trim, Me.txtCity.Text.Trim, Me.cboStates.SelectedValue, _
                                                   Me.txtZipCode.Text.Trim, Me.cboCountries.SelectedValue, Me.txtPhoneNumber.Text.Trim, _
                                                   Me.txtFaxNumber.Text.Trim, Me.txtEmailAddress.Text.Trim, iTrayID, ApplicationUser.IDuser, ApplicationUser.IDuser)

                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    If iWOID > 0 Then
                        Me._iWOID = iWOID : Me._iTrayID = iTrayID
                        Me.LoadOpenWorkOrder()
                        Me.gbShipTo.Enabled = False : Me.txtRMA.Enabled = False
                        Me.PopulateReceivedUnits(Me._iWOID)
                        Me.cboModel.SelectAll() : Me.cboModel.Focus()
                    Else
                        Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnAddRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '************************************************************************************************************
        Private Sub btnUpdateShipToInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateShipToInfo.Click
            Dim i As Integer

            Try
                If Me.gbShipTo.Tag.ToString.Trim.Length = 0 OrElse CInt(Me.gbShipTo.Tag) = 0 Then
                    MessageBox.Show("This is a new address. System will add them when new RMA is created.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.txtFirstName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter first name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtFirstName.SelectAll() : Me.txtFirstName.Focus()
                ElseIf Me.txtLastName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter last name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtLastName.SelectAll() : Me.txtLastName.Focus()
                ElseIf Me.txtAddress1.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter shipping adress.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtAddress1.SelectAll() : Me.txtAddress1.Focus()
                ElseIf Me.txtCity.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter city.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCity.SelectAll() : Me.txtCity.Focus()
                ElseIf Me.cboStates.SelectedValue = 0 Then
                    MessageBox.Show("Please select state.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboStates.SelectAll() : Me.cboStates.Focus()
                ElseIf Me.txtZipCode.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter zip code.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtZipCode.SelectAll() : Me.txtZipCode.Focus()
                ElseIf Me.cboCountries.SelectedValue = 0 Then
                    MessageBox.Show("Please select country.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCountries.SelectAll() : Me.cboCountries.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                    i = Me._objProdRec.UpdateTShipToInfo(CInt(Me.gbShipTo.Tag), Me.txtCompany.Text.Trim, _
                                                   Me.txtFirstName.Text.Trim & " " & Me.txtLastName.Text.Trim, Me.txtAddress1.Text.Trim, _
                                                   Me.txtAddress2.Text.Trim, Me.txtCity.Text.Trim, Me.cboStates.SelectedValue, _
                                                   Me.txtZipCode.Text.Trim, Me.cboCountries.SelectedValue, Me.txtPhoneNumber.Text.Trim, _
                                                   Me.txtFaxNumber.Text.Trim, Me.txtEmailAddress.Text.Trim)

                    Me.Enabled = True : Cursor.Current = Cursors.Default
                    If i > 0 Then
                        Me.LoadPantechShipToInfo(Convert.ToInt32(Me.gbShipTo.Tag))
                        Me.SetEnablePropertiesToShipToControls(False) : Me.btnUpdateShipToInfo.Enabled = False
                        Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnUpdateShipToInfo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function ProcessIMEI() As Boolean
            Dim dtASN, dtDevice As DataTable
            Dim iDeviceID, iManufWtry, iPASN_ID As Integer

            Try
                If Me.txtRMA.Text.Trim.Length = 0 Then
                    Exit Function
                ElseIf Me._iWOID = 0 Then
                    MessageBox.Show("Order ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Tray ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                ElseIf Me.cboModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModel.SelectAll() : Me.cboModel.Focus()
                ElseIf Me.txtIMEI.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter in IMEI number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.txtIMEI.Text.Trim.Length < 10 Then
                    MessageBox.Show("Invalid IMEI number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.txtMechanicalSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMechanicalSN.SelectAll() : Me.txtMechanicalSN.Focus()
                ElseIf Me.txtMechanicalSN.Text.Trim.Length < 9 Then
                    MessageBox.Show("Invalid S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMechanicalSN.SelectAll() : Me.txtMechanicalSN.Focus()
                ElseIf Me.txtIMEI.Text.Trim.ToLower = Me.txtMechanicalSN.Text.Trim.ToLower Then
                    MessageBox.Show("S/N can't be the same with IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMechanicalSN.SelectAll() : Me.txtMechanicalSN.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    iDeviceID = 0 : iPASN_ID = 0

                    '**************************************
                    'Check for duplicate
                    '**************************************
                    dtDevice = Buisness.Generic.GetDeviceInfoInWIP(Me.txtIMEI.Text.Trim.ToUpper, Buisness.Pantech.Pantech_CUSTOMER_ID, Buisness.Pantech.Pantech_LOC_ID)
                    If dtDevice.Rows.Count > 0 Then
                        MessageBox.Show("Device is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Else
                        If Me.rbtnIW.Checked = True Then iManufWtry = 1 Else iManufWtry = 0

                        dtASN = Me._objPantechRec.GetPantechASN(Me.txtRMA.Text.Trim, Me.txtIMEI.Text.Trim)
                        If dtASN.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate record in asn file. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                        Else
                            If dtASN.Rows.Count > 0 Then iPASN_ID = Convert.ToInt32(dtASN.Rows(0)("PA_ID"))

                            If Me.txtIMEI.Text.Trim.Length > 0 Then
                                Dim frmAccessories As New Accessories(Me.txtIMEI.Text.Trim, True, Accessories.ShipType.PANTECH)

                                frmAccessories.StartPosition = FormStartPosition.CenterScreen
                                frmAccessories.ShowDialog()
                            End If

                            iDeviceID = Me._objPantechRec.ReceiveUnit(Me._iWOID, Me._iTrayID, Me.cboModel.SelectedValue, _
                                                                      Me.txtIMEI.Text.Trim.ToUpper, Me.txtMechanicalSN.Text.Trim.ToUpper, _
                                                                      PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.IDShift, _
                                                                      iManufWtry, iPASN_ID, Me.txtRMA.Text.Trim.ToUpper)

                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            If iDeviceID > 0 Then
                                Me.PopulateReceivedUnits(Me._iWOID)

                                Me.txtIMEI.Text = "" : Me.txtMechanicalSN.Text = ""
                                Me.cboModel.SelectAll() : Me.cboModel.Focus()
                            Else
                                Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                            End If
                        End If
                    End If 'Check device in wip
                End If 'check user input
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dtASN) : Buisness.Generic.DisposeDT(dtDevice)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Function

        '*************************************************************************************************************
        Private Sub rbtnIWOW_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnIW.CheckedChanged, rbtnOW.CheckedChanged
            Try
                If Me.rbtnIW.Checked = True Then
                    Me.lblWarrantyStatus.Text = "IN WARRANTY"
                    Me.lblWarrantyStatus.BackColor = Color.SteelBlue

                ElseIf Me.rbtnOW.Checked = True Then
                    Me.lblWarrantyStatus.Text = "OUT OF WARRANTY"
                    Me.lblWarrantyStatus.BackColor = Color.Purple
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                End If

                Me.txtMechanicalSN.SelectAll() : Me.txtMechanicalSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "rbtnIWOW_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnRePrintManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRePrintManifest.Click
            Dim strTray_id As String = ""

            Try
                '*******************
                'Get Tray ID
                '*******************
                strTray_id = InputBox("Please Scan Tray ID:", "Reprint Receceipt Manifest").Trim

                '********************
                'Validate user input
                '********************
                If strTray_id.Length = 0 Then Exit Sub

                If Not IsNumeric(strTray_id) Then
                    MessageBox.Show("Invalid Tray ID please retry.", "Validate Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
                '***********************
                'Print Report
                '***********************
                PSS.Data.Buisness.MessReceive.PrintRecReport(CInt(strTray_id), 1)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Receipt Manifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnSelectShipToAddress_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectShipToAddress.Click
            Try
                If Me.dbgShipToAddress.RowCount > 0 Then
                    Me.gbShipTo.Tag = Me.dbgShipToAddress.Columns("ShipTo_ID").CellValue(Me.dbgShipToAddress.Row)
                    Me.txtCompany.Text = Me.dbgShipToAddress.Columns("CompanyName").CellValue(Me.dbgShipToAddress.Row)
                    Me.txtFirstName.Text = Me.dbgShipToAddress.Columns("ShipTo_Name").CellValue(Me.dbgShipToAddress.Row).ToString.Split(" ")(0)
                    Me.txtLastName.Text = Me.dbgShipToAddress.Columns("ShipTo_Name").CellValue(Me.dbgShipToAddress.Row).ToString.Split(" ")(1)
                    Me.txtAddress1.Text = Me.dbgShipToAddress.Columns("ShipTo_Address1").CellValue(Me.dbgShipToAddress.Row).ToString
                    Me.txtAddress2.Text = Me.dbgShipToAddress.Columns("ShipTo_Address2").CellValue(Me.dbgShipToAddress.Row).ToString
                    Me.txtCity.Text = Me.dbgShipToAddress.Columns("ShipTo_City").CellValue(Me.dbgShipToAddress.Row).ToString
                    Me.cboStates.SelectedValue = Me.dbgShipToAddress.Columns("State_ID").CellValue(Me.dbgShipToAddress.Row)
                    Me.txtZipCode.Text = Me.dbgShipToAddress.Columns("ShipTo_Zip").CellValue(Me.dbgShipToAddress.Row).ToString
                    Me.cboCountries.SelectedValue = Me.dbgShipToAddress.Columns("Cntry_ID").CellValue(Me.dbgShipToAddress.Row)
                    Me.txtPhoneNumber.Text = Me.dbgShipToAddress.Columns("Tel").CellValue(Me.dbgShipToAddress.Row).ToString
                    Me.txtFaxNumber.Text = Me.dbgShipToAddress.Columns("Fax").CellValue(Me.dbgShipToAddress.Row).ToString
                    Me.txtEmailAddress.Text = Me.dbgShipToAddress.Columns("Email").CellValue(Me.dbgShipToAddress.Row).ToString
                    Me.SetEnablePropertiesToShipToControls(False)
                Else
                    ClearShipToControls()
                    Me.SetEnablePropertiesToShipToControls(True)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgShipToAddress_SelChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnClearShipToCtrls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearShipToCtrls.Click
            Try
                ClearShipToControls()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearShipToCtrls_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnEditShipToInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditShipToInfo.Click
            Try
                If Me.gbShipTo.Tag.ToString <> "" AndAlso Convert.ToInt32(Me.gbShipTo.Tag) > 0 Then
                    Me.btnUpdateShipToInfo.Enabled = True
                    Me.SetEnablePropertiesToShipToControls(True)
                Else
                    Me.btnUpdateShipToInfo.Enabled = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnClearShipToCtrls_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ClearShipToControls()
            Try
                Me.gbShipTo.Tag = 0
                Me.txtCompany.Text = ""
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
                Me.txtEmailAddress.Text = ""
                Me.SetEnablePropertiesToShipToControls(True)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub SetEnablePropertiesToShipToControls(ByVal booEnable As Boolean)
            Try
                Me.txtCompany.Enabled = booEnable
                Me.txtFirstName.Enabled = booEnable
                Me.txtLastName.Enabled = booEnable
                Me.txtAddress1.Enabled = booEnable
                Me.txtAddress2.Enabled = booEnable
                Me.txtCity.Enabled = booEnable
                Me.cboStates.Enabled = booEnable
                Me.txtZipCode.Enabled = booEnable
                Me.cboCountries.Enabled = booEnable
                Me.txtPhoneNumber.Enabled = booEnable
                Me.txtFaxNumber.Enabled = booEnable
                Me.txtEmailAddress.Enabled = booEnable
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnManuallyRecFrExcelFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManuallyRecFrExcelFile.Click
            'Dim objExcel As Excel.Application    ' Excel application
            'Dim objBook As Excel.Workbook     ' Excel workbook
            'Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            'Dim strFilePatth As String = ""
            'Dim i, j, iModelID As Integer
            'Dim strExistingRMANo, strRMANo, strSN, strWrtyStatus, strIMEI, strModelDesc, strCustName, strCompany, strAddress, strCity, strState, strZip, strPhoneNo As String
            'Dim dt1 As DataTable
            'Dim objOFD As New Windows.Forms.OpenFileDialog()
            'Dim booNewRMA As Boolean = True

            'Try
            '    objOFD.FilterIndex = 1
            '    objOFD.ShowDialog()
            '    strFilePatth = Trim(objOFD.FileName)

            '    objExcel = New Excel.Application()
            '    objBook = objExcel.Workbooks.Open(strFilePatth)
            '    objSheet = objExcel.Worksheets(1)
            '    objExcel.Visible = True

            '    i = 103 : j = 0 : iModelID = 0
            '    strRMANo = "" : strSN = "" : strWrtyStatus = "" : strIMEI = "" : strModelDesc = "" : strCustName = "" : strCompany = ""
            '    strAddress = "" : strCity = "" : strState = "" : strZip = "" : strPhoneNo = "" : strExistingRMANo = ""
            '    strSN = objSheet.range("B" & i).value.ToString.Trim
            '    strWrtyStatus = objSheet.range("E" & i).value.ToString.Trim
            '    strIMEI = objSheet.range("F" & i).value.ToString.Trim
            '    strModelDesc = objSheet.range("G" & i).value.ToString.Trim
            '    strCustName = objSheet.range("H" & i).value.ToString.Trim
            '    If Not IsNothing(objSheet.range("I" & i).value) Then strCompany = objSheet.range("I" & i).value.ToString.Trim Else strCompany = ""
            '    strAddress = objSheet.range("J" & i).value.ToString.Trim
            '    strCity = objSheet.range("K" & i).value.ToString.Trim
            '    strState = objSheet.range("L" & i).value.ToString.Trim
            '    strZip = objSheet.range("M" & i).value.ToString.Trim
            '    strPhoneNo = objSheet.range("N" & i).value.ToString.Trim
            '    If Not IsNothing(objSheet.range("Q" & i).value) Then strExistingRMANo = objSheet.range("Q" & i).value

            '    While strSN.Length > 0 AndAlso strWrtyStatus.Length > 0 AndAlso strIMEI.Length > 0
            '        If strExistingRMANo.Trim.Length > 0 Then
            '            Me.ProcessRMA(strExistingRMANo)
            '            strExistingRMANo = ""
            '        ElseIf booNewRMA = True Then
            '            Me.btnNewRMA_Click(Nothing, Nothing)

            '            strRMANo = "PT" & Now().ToString("yyyyMMddHHmm")
            '            Me.txtRMA.Text = strRMANo

            '            Me.txtFirstName.Text = strCustName.Trim.Split(" ")(0).Trim.ToUpper
            '            Me.txtLastName.Text = strCustName.Trim.Split(" ")(0).Trim.ToUpper
            '            Me.txtAddress1.Text = strAddress.Trim.ToUpper
            '            Me.txtAddress2.Text = strCompany.Trim.ToUpper
            '            Me.txtCity.Text = strCity.Trim.ToUpper
            '            If Me.cboStates.DataSource.Table.Select("State_Desc = '" & strState & "'").length = 0 Then Throw New Exception("State ID is missing for line # " & i)
            '            Me.cboStates.SelectedValue = Me.cboStates.DataSource.Table.Select("State_Desc = '" & strState & "'")(0)("State_ID")
            '            Me.txtZipCode.Text = strZip.Trim.ToUpper
            '            Me.cboCountries.SelectedValue = 161
            '            Me.btnAddRMA_Click(Nothing, Nothing)
            '            objSheet.Range("Q" & i).FormulaR1C1 = strRMANo
            '        End If

            '        '****************************************************************
            '        If Me.cboModel.DataSource.Table.Select("Model_Desc = '" & strModelDesc & "'").length = 0 Then
            '            MessageBox.Show("Model ID is missing for line # " & i)
            '            objSheet.Range("R" & i).FormulaR1C1 = "No Model"
            '        Else
            '            iModelID = Me.cboModel.DataSource.Table.Select("Model_Desc = '" & strModelDesc & "'")(0)("Model_ID")
            '            Me.cboModel.SelectedValue = iModelID
            '            Me.txtMechanicalSN.Text = strSN.Trim.ToUpper
            '            Me.txtIMEI.Text = strIMEI.Trim.ToString

            '            If strWrtyStatus.Trim.ToUpper = "IW" Then Me.rbtnIW.Checked = True Else Me.rbtnIW.Checked = False

            '            Try
            '                Me.ProcessIMEI()
            '                objSheet.Range("R" & i).FormulaR1C1 = "Loaded"
            '            Catch ex As Exception
            '                objSheet.Range("R" & i).FormulaR1C1 = ex.Message
            '            End Try
            '        End If

            '        '****************************************************************

            '        booNewRMA = False : i += 1
            '        strSN = objSheet.range("B" & i).value.ToString.Trim
            '        strWrtyStatus = objSheet.range("E" & i).value.ToString.Trim
            '        strIMEI = objSheet.range("F" & i).value.ToString.Trim
            '        strModelDesc = objSheet.range("G" & i).value.ToString.Trim

            '        If Not IsNothing(objSheet.range("Q" & i).value) Then strExistingRMANo = objSheet.range("Q" & i).value

            '        If Not IsDBNull(objSheet.range("H" & i).value) AndAlso Not IsNothing(objSheet.range("H" & i).value) AndAlso objSheet.range("H" & i).value.ToString.Trim.Length > 0 Then
            '            booNewRMA = True
            '            strCustName = objSheet.range("H" & i).value.ToString.Trim
            '            If Not IsNothing(objSheet.range("I" & i).value) Then strCompany = objSheet.range("I" & i).value.ToString.Trim Else strCompany = ""
            '            strAddress = objSheet.range("J" & i).value.ToString.Trim
            '            strCity = objSheet.range("K" & i).value.ToString.Trim
            '            strState = objSheet.range("L" & i).value.ToString.Trim
            '            strZip = objSheet.range("M" & i).value.ToString.Trim
            '            If Not IsNothing(objSheet.range("N" & i).value) Then strPhoneNo = objSheet.range("N" & i).value.ToString.Trim Else strPhoneNo = ""
            '        End If
            '    End While

            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, "btnManuallyRecFrExcelFile_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            'Finally
            '    If Not IsNothing(objOFD) Then
            '        objOFD.Dispose()
            '        objOFD = Nothing
            '    End If
            '    PSS.Data.Buisness.Generic.DisposeDT(dt1)
            '    If Not IsNothing(objSheet) Then
            '        objSheet = Nothing
            '        System.Runtime.InteropServices.Marshal.ReleaseComObject(objSheet)
            '    End If
            '    If Not IsNothing(objBook) Then
            '        objBook.Close()
            '        objBook = Nothing
            '        System.Runtime.InteropServices.Marshal.ReleaseComObject(objBook)
            '    End If
            '    If Not IsNothing(objExcel) Then
            '        objExcel.Quit()
            '        objExcel = Nothing
            '        System.Runtime.InteropServices.Marshal.ReleaseComObject(objExcel)
            '    End If

            '    GC.Collect()
            '    GC.WaitForPendingFinalizers()
            '    GC.Collect()
            '    GC.WaitForPendingFinalizers()
            'End Try
        End Sub

        '*************************************************************************************************************

    End Class
End Namespace