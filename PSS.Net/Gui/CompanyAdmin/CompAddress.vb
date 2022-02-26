Imports PSS.Core
Imports PSS.Data

Namespace Gui.CompanyAdmin


    Public Class CompAddress
        Inherits System.Windows.Forms.Form

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
        Friend WithEvents lblCompany As System.Windows.Forms.Label
        Friend WithEvents CompanyGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents grpModification As System.Windows.Forms.GroupBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents lblAddress2 As System.Windows.Forms.Label
        Friend WithEvents lblCity As System.Windows.Forms.Label
        Friend WithEvents lblState As System.Windows.Forms.Label
        Friend WithEvents lblZipCode As System.Windows.Forms.Label
        Friend WithEvents lblCountry As System.Windows.Forms.Label
        Friend WithEvents lblPhone As System.Windows.Forms.Label
        Friend WithEvents lblFax As System.Windows.Forms.Label
        Friend WithEvents lblEmail As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress As System.Windows.Forms.TextBox
        Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
        Friend WithEvents txtCity As System.Windows.Forms.TextBox
        Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
        Friend WithEvents cboState As System.Windows.Forms.ComboBox
        Friend WithEvents cboCountry As System.Windows.Forms.ComboBox
        Friend WithEvents txtPhone As System.Windows.Forms.TextBox
        Friend WithEvents txtFax As System.Windows.Forms.TextBox
        Friend WithEvents txtEmail As System.Windows.Forms.TextBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents lblID As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CompAddress))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lblCompany = New System.Windows.Forms.Label()
            Me.CompanyGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpModification = New System.Windows.Forms.GroupBox()
            Me.lblID = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.txtEmail = New System.Windows.Forms.TextBox()
            Me.txtFax = New System.Windows.Forms.TextBox()
            Me.txtPhone = New System.Windows.Forms.TextBox()
            Me.cboCountry = New System.Windows.Forms.ComboBox()
            Me.cboState = New System.Windows.Forms.ComboBox()
            Me.txtZipCode = New System.Windows.Forms.TextBox()
            Me.txtCity = New System.Windows.Forms.TextBox()
            Me.txtAddress2 = New System.Windows.Forms.TextBox()
            Me.txtAddress = New System.Windows.Forms.TextBox()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.lblEmail = New System.Windows.Forms.Label()
            Me.lblFax = New System.Windows.Forms.Label()
            Me.lblPhone = New System.Windows.Forms.Label()
            Me.lblCountry = New System.Windows.Forms.Label()
            Me.lblZipCode = New System.Windows.Forms.Label()
            Me.lblState = New System.Windows.Forms.Label()
            Me.lblCity = New System.Windows.Forms.Label()
            Me.lblAddress2 = New System.Windows.Forms.Label()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.btnNew = New System.Windows.Forms.Button()
            CType(Me.CompanyGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpModification.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCompany
            '
            Me.lblCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCompany.Location = New System.Drawing.Point(16, 24)
            Me.lblCompany.Name = "lblCompany"
            Me.lblCompany.Size = New System.Drawing.Size(208, 16)
            Me.lblCompany.TabIndex = 0
            Me.lblCompany.Text = "COMPANY"
            Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'CompanyGrid
            '
            Me.CompanyGrid.AllowFilter = True
            Me.CompanyGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.CompanyGrid.AllowSort = True
            Me.CompanyGrid.AlternatingRows = True
            Me.CompanyGrid.CaptionHeight = 17
            Me.CompanyGrid.CollapseColor = System.Drawing.Color.Black
            Me.CompanyGrid.DataChanged = False
            'Me.CompanyGrid.DeadAreaBackColor = System.Drawing.Color.Empty
            'Commented out by Asif on 10/16/2006
            Me.CompanyGrid.BackColor = System.Drawing.Color.Empty

            Me.CompanyGrid.DefColWidth = 190
            Me.CompanyGrid.ExpandColor = System.Drawing.Color.Black
            Me.CompanyGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.CompanyGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.CompanyGrid.Location = New System.Drawing.Point(8, 48)
            Me.CompanyGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.CompanyGrid.Name = "CompanyGrid"
            Me.CompanyGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.CompanyGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.CompanyGrid.PreviewInfo.ZoomFactor = 75
            Me.CompanyGrid.PrintInfo.ShowOptionsDialog = False
            Me.CompanyGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.CompanyGrid.RowDivider = GridLines1
            Me.CompanyGrid.RowHeight = 15
            Me.CompanyGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.CompanyGrid.ScrollTips = False
            Me.CompanyGrid.Size = New System.Drawing.Size(216, 336)
            Me.CompanyGrid.TabIndex = 1
            Me.CompanyGrid.Text = "C1TrueDBGrid1"
            Me.CompanyGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style1{}Od" & _
            "dRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Control;Bord" & _
            "er:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Style10{Al" & _
            "ignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Co" & _
            "lumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" R" & _
            "ecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalSc" & _
            "rollGroup=""1""><ClientRect>0, 0, 212, 332</ClientRect><BorderSide>0</BorderSide><" & _
            "CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Sty" & _
            "le5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filt" & _
            "erBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle par" & _
            "ent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLig" & _
            "htRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" " & _
            "me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pa" & _
            "rent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6" & _
            """ /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 212, 332</ClientArea></Blob>"
            '
            'grpModification
            '
            Me.grpModification.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblID, Me.btnSave, Me.btnCancel, Me.txtEmail, Me.txtFax, Me.txtPhone, Me.cboCountry, Me.cboState, Me.txtZipCode, Me.txtCity, Me.txtAddress2, Me.txtAddress, Me.txtName, Me.lblEmail, Me.lblFax, Me.lblPhone, Me.lblCountry, Me.lblZipCode, Me.lblState, Me.lblCity, Me.lblAddress2, Me.lblAddress, Me.lblName})
            Me.grpModification.Location = New System.Drawing.Point(232, 40)
            Me.grpModification.Name = "grpModification"
            Me.grpModification.Size = New System.Drawing.Size(496, 376)
            Me.grpModification.TabIndex = 2
            Me.grpModification.TabStop = False
            Me.grpModification.Text = "Insert/ Update Information"
            '
            'lblID
            '
            Me.lblID.Location = New System.Drawing.Point(120, 24)
            Me.lblID.Name = "lblID"
            Me.lblID.Size = New System.Drawing.Size(100, 16)
            Me.lblID.TabIndex = 13
            Me.lblID.Text = "ID:"
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(408, 344)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.TabIndex = 11
            Me.btnSave.Text = "&Save"
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(16, 344)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.TabIndex = 12
            Me.btnCancel.Text = "&Cancel"
            '
            'txtEmail
            '
            Me.txtEmail.Location = New System.Drawing.Point(120, 262)
            Me.txtEmail.Name = "txtEmail"
            Me.txtEmail.Size = New System.Drawing.Size(328, 20)
            Me.txtEmail.TabIndex = 10
            Me.txtEmail.Text = ""
            '
            'txtFax
            '
            Me.txtFax.Location = New System.Drawing.Point(120, 238)
            Me.txtFax.Name = "txtFax"
            Me.txtFax.Size = New System.Drawing.Size(152, 20)
            Me.txtFax.TabIndex = 9
            Me.txtFax.Text = ""
            '
            'txtPhone
            '
            Me.txtPhone.Location = New System.Drawing.Point(120, 216)
            Me.txtPhone.Name = "txtPhone"
            Me.txtPhone.Size = New System.Drawing.Size(152, 20)
            Me.txtPhone.TabIndex = 8
            Me.txtPhone.Text = ""
            '
            'cboCountry
            '
            Me.cboCountry.Location = New System.Drawing.Point(120, 166)
            Me.cboCountry.Name = "cboCountry"
            Me.cboCountry.Size = New System.Drawing.Size(328, 21)
            Me.cboCountry.TabIndex = 7
            '
            'cboState
            '
            Me.cboState.Location = New System.Drawing.Point(232, 136)
            Me.cboState.Name = "cboState"
            Me.cboState.Size = New System.Drawing.Size(72, 21)
            Me.cboState.TabIndex = 5
            '
            'txtZipCode
            '
            Me.txtZipCode.Location = New System.Drawing.Point(376, 136)
            Me.txtZipCode.Name = "txtZipCode"
            Me.txtZipCode.Size = New System.Drawing.Size(72, 20)
            Me.txtZipCode.TabIndex = 6
            Me.txtZipCode.Text = ""
            '
            'txtCity
            '
            Me.txtCity.Location = New System.Drawing.Point(120, 136)
            Me.txtCity.Name = "txtCity"
            Me.txtCity.Size = New System.Drawing.Size(56, 20)
            Me.txtCity.TabIndex = 4
            Me.txtCity.Text = ""
            '
            'txtAddress2
            '
            Me.txtAddress2.Location = New System.Drawing.Point(120, 110)
            Me.txtAddress2.Name = "txtAddress2"
            Me.txtAddress2.Size = New System.Drawing.Size(328, 20)
            Me.txtAddress2.TabIndex = 3
            Me.txtAddress2.Text = ""
            '
            'txtAddress
            '
            Me.txtAddress.Location = New System.Drawing.Point(120, 86)
            Me.txtAddress.Name = "txtAddress"
            Me.txtAddress.Size = New System.Drawing.Size(328, 20)
            Me.txtAddress.TabIndex = 2
            Me.txtAddress.Text = ""
            '
            'txtName
            '
            Me.txtName.Location = New System.Drawing.Point(120, 54)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(328, 20)
            Me.txtName.TabIndex = 1
            Me.txtName.Text = ""
            '
            'lblEmail
            '
            Me.lblEmail.Location = New System.Drawing.Point(56, 264)
            Me.lblEmail.Name = "lblEmail"
            Me.lblEmail.Size = New System.Drawing.Size(56, 16)
            Me.lblEmail.TabIndex = 9
            Me.lblEmail.Text = "Email:"
            Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFax
            '
            Me.lblFax.Location = New System.Drawing.Point(56, 240)
            Me.lblFax.Name = "lblFax"
            Me.lblFax.Size = New System.Drawing.Size(56, 16)
            Me.lblFax.TabIndex = 8
            Me.lblFax.Text = "Fax:"
            Me.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPhone
            '
            Me.lblPhone.Location = New System.Drawing.Point(56, 218)
            Me.lblPhone.Name = "lblPhone"
            Me.lblPhone.Size = New System.Drawing.Size(56, 16)
            Me.lblPhone.TabIndex = 7
            Me.lblPhone.Text = "Phone:"
            Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCountry
            '
            Me.lblCountry.Location = New System.Drawing.Point(56, 168)
            Me.lblCountry.Name = "lblCountry"
            Me.lblCountry.Size = New System.Drawing.Size(56, 16)
            Me.lblCountry.TabIndex = 6
            Me.lblCountry.Text = "Country:"
            Me.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblZipCode
            '
            Me.lblZipCode.Location = New System.Drawing.Point(312, 138)
            Me.lblZipCode.Name = "lblZipCode"
            Me.lblZipCode.Size = New System.Drawing.Size(56, 16)
            Me.lblZipCode.TabIndex = 5
            Me.lblZipCode.Text = "Zip Code:"
            Me.lblZipCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblState
            '
            Me.lblState.Location = New System.Drawing.Point(184, 138)
            Me.lblState.Name = "lblState"
            Me.lblState.Size = New System.Drawing.Size(40, 16)
            Me.lblState.TabIndex = 4
            Me.lblState.Text = "State:"
            Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCity
            '
            Me.lblCity.Location = New System.Drawing.Point(56, 138)
            Me.lblCity.Name = "lblCity"
            Me.lblCity.Size = New System.Drawing.Size(56, 16)
            Me.lblCity.TabIndex = 3
            Me.lblCity.Text = "City:"
            Me.lblCity.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress2
            '
            Me.lblAddress2.Location = New System.Drawing.Point(32, 112)
            Me.lblAddress2.Name = "lblAddress2"
            Me.lblAddress2.Size = New System.Drawing.Size(80, 16)
            Me.lblAddress2.TabIndex = 2
            Me.lblAddress2.Text = "Address(2):"
            Me.lblAddress2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAddress
            '
            Me.lblAddress.Location = New System.Drawing.Point(56, 88)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(56, 16)
            Me.lblAddress.TabIndex = 1
            Me.lblAddress.Text = "Address:"
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Location = New System.Drawing.Point(56, 56)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(56, 16)
            Me.lblName.TabIndex = 0
            Me.lblName.Text = "Name:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnNew
            '
            Me.btnNew.Location = New System.Drawing.Point(8, 392)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(216, 23)
            Me.btnNew.TabIndex = 3
            Me.btnNew.TabStop = False
            Me.btnNew.Text = "&New"
            '
            'CompAddress
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(790, 501)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnNew, Me.grpModification, Me.CompanyGrid, Me.lblCompany})
            Me.Name = "CompAddress"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "CompAddress"
            CType(Me.CompanyGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpModification.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private valName, valAddress, valAddress2, valCity, valZipCode, valPhone, valFax, valEmail As String
        Private intState, intCountry, intStatus, intID As Integer
        Private dsState, dsCountry As DataSet

        Private Sub CompAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            '//Create a grid of current companies for PSS, Inc.
            Dim CompanyDT As DataTable = getCompanyList()
            populateCompanyGrid(CompanyDT)
            populateStateList()
            populateCountryList()
            intStatus = 0
            intID = 0

        End Sub

#Region " Company Grid Mechanics "

        Private Function getCompanyList() As DataTable

            Try
                Dim clsCompanyList As New PSS.Data.Production.lcoinfo()
                getCompanyList = clsCompanyList.GetDataOrderByName
                clsCompanyList = Nothing
            Catch exp As Exception

            End Try
        End Function

        Private Sub populateCompanyGrid(ByVal valData As DataTable)

            CompanyGrid.DataSource = valData.DefaultView
            CompanyGrid.Columns(0).Caption = "Name"

        End Sub

#End Region

        Private Sub lockCompanyGrid()

            CompanyGrid.Enabled = False

        End Sub

        Private Sub unlockCompanyGrid()

            CompanyGrid.Enabled = True

        End Sub

        Private Sub clearModificationWindow()

            Me.txtName.Text = ""
            Me.txtAddress.Text = ""
            Me.txtAddress2.Text = ""
            Me.txtCity.Text = ""
            Me.txtZipCode.Text = ""
            Me.txtPhone.Text = ""
            Me.txtFax.Text = ""
            Me.txtEmail.Text = ""
            Me.cboState.Text = ""
            Me.cboCountry.Text = ""
            lblID.Text = "ID:"

        End Sub

        Private Sub populateModificationWindow()

            clearModificationWindow()

            Dim clsCompanyData As New PSS.Data.Production.lcoinfo()
            Dim CompanyDataDT As DataTable = clsCompanyData.GetDataTable
            Dim xCount As Integer = 0
            Dim r As DataRow

            For xCount = 0 To CompanyDataDT.Rows.Count - 1
                r = CompanyDataDT.Rows(xCount)

                If Trim(r("CoInfo_Name")) = Trim(CompanyGrid.Columns(0).Text) Then
                    '//Load elements to Modification Window
                    intStatus = 2
                    If IsDBNull(Trim(r("CoInfo_ID"))) = False Then Me.lblID.Text = "ID: " & Trim(r("CoInfo_ID"))
                    intID = Trim(r("CoInfo_ID"))
                    If IsDBNull(Trim(r("CoInfo_Name"))) = False Then Me.txtName.Text = Trim(r("CoInfo_Name"))
                    If IsDBNull(Trim(r("CoInfo_Address1"))) = False Then Me.txtAddress.Text = Trim(r("CoInfo_Address1"))
                    If IsDBNull(Trim(r("CoInfo_Address2"))) = False Then Me.txtAddress2.Text = Trim(r("CoInfo_Address2"))
                    If IsDBNull(Trim(r("CoInfo_City"))) = False Then Me.txtCity.Text = Trim(r("CoInfo_City"))
                    If IsDBNull(Trim(r("CoInfo_Zip"))) = False Then Me.txtZipCode.Text = Trim(r("CoInfo_Zip"))
                    If IsDBNull(Trim(r("CoInfo_Phone"))) = False Then Me.txtPhone.Text = Trim(r("CoInfo_Phone"))
                    If IsDBNull(Trim(r("CoInfo_Fax"))) = False Then Me.txtFax.Text = Trim(r("CoInfo_Fax"))
                    If IsDBNull(Trim(r("CoInfo_Email"))) = False Then Me.txtEmail.Text = Trim(r("CoInfo_Email"))
                    If IsDBNull(Trim(r("CoInfo_Cntry"))) = False Then intCountry = Trim(r("CoInfo_Cntry"))
                    If IsDBNull(Trim(r("State_ID"))) = False Then intState = Trim(r("State_ID"))
                    Exit For
                End If

            Next

            '//Select state from list
            cboState.Text = ""
            For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                r = dsState.Tables("lstate").Rows(xCount)
                If Trim(r("State_ID")) = Trim(intState) Then
                    cboState.SelectedText = Trim(r("State_Short"))
                End If
            Next

            '//Select country from list
            cboCountry.Text = ""
            For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                r = dsCountry.Tables("lcountry").Rows(xCount)
                If Trim(r("Cntry_ID")) = Trim(intCountry) Then
                    cboCountry.SelectedText = Trim(r("Cntry_Name"))
                End If
            Next

        End Sub

        Private Function getStateList() As DataSet

            Dim clsStateList As New PSS.Data.Production.lstate()
            getStateList = clsStateList.GetData
            dsState = getStateList

        End Function

        Private Function getCountryList() As DataSet

            Dim clsCountryList As New PSS.Data.Production.lcountry()
            getCountryList = clsCountryList.GetData
            dsCountry = getCountryList

        End Function

        Private Sub populateStateList()

            Dim dsState As DataSet = getStateList()
            Dim xCount As Integer = 0
            Dim r As DataRow

            For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                r = dsState.Tables("lstate").Rows(xCount)
                Me.cboState.Items.Add(r("State_Short"))
            Next

        End Sub

        Private Sub populateCountryList()

            Dim dsCountry As DataSet = getCountryList()
            Dim xCount As Integer = 0
            Dim r As DataRow

            For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                r = dsCountry.Tables("lcountry").Rows(xCount)
                Me.cboCountry.Items.Add(r("Cntry_Name"))
            Next

        End Sub

        Private Sub CompanyGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyGrid.Click

        End Sub

        Private Sub CompanyGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CompanyGrid.MouseUp

            populateModificationWindow()

        End Sub

        Private Sub txtName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtName.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub txtAddress_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAddress.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub txtAddress2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAddress2.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub txtCity_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCity.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub txtZipCode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtZipCode.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub txtPhone_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPhone.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub txtFax_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFax.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub txtEmail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEmail.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub cboState_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboState.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub cboCountry_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCountry.KeyUp
            lockCompanyGrid()
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

            '//Verify Cancellation
            Dim intResponse As String
            intResponse = MsgBox("You have decided to cancel this entry, changes will not be saved. Continue?", MsgBoxStyle.OKCancel, "Confirm Cancel")
            Select Case intResponse
                Case vbOK
                    intStatus = 0
                    intID = 0
                    clearModificationWindow()
                    unlockCompanyGrid()
                Case vbCancel
                    txtName.Focus()
            End Select

        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

            saveRecord()

        End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

            intStatus = 1
            intID = 0
            clearModificationWindow()
            txtName.Focus()

        End Sub

        Private Function verifyData() As Boolean

            verifyData = False

            Dim msg As String = ""

            If Len(Trim(txtName.Text)) < 1 Then
                msg += "No Name Defined. " & vbCrLf
            End If

            If Len(Trim(txtAddress.Text)) < 1 Then
                msg += "No Address Defined. " & vbCrLf
            End If

            If Len(Trim(txtCity.Text)) < 1 Then
                msg += "No City Defined. " & vbCrLf
            End If

            If Len(Trim(txtZipCode.Text)) < 1 Then
                msg += "No Zip Code Defined. " & vbCrLf
            End If

            If Len(Trim(cboState.Text)) < 1 Then
                msg += "No State Defined. " & vbCrLf
            End If

            If Trim(msg) = "" Then
                verifyData = True
            Else
                MsgBox(msg & "Record can not be saved.", MsgBoxStyle.OKOnly, "ERROR")
            End If

        End Function

        Private Function saveRecord()

            Dim verData As Boolean = verifyData()
            Dim xCount As Integer = 0
            Dim r As DataRow

            If verData = False Then Exit Function

            '//Data has been verified - continue
            Dim strSQL As String
            Dim blnInsert As Boolean = False
            '//Determine type for action
            Dim type As String = ""
            If intStatus = 1 Then
                type = "NEW"
                '//Proceed to place insert here
                initVariables()

                If IsDBNull(Trim(txtName.Text)) = False Then valName = Trim(txtName.Text)
                If IsDBNull(Trim(txtAddress.Text)) = False Then valAddress = Trim(txtAddress.Text)
                If IsDBNull(Trim(txtAddress2.Text)) = False Then valAddress2 = Trim(txtAddress2.Text)
                If IsDBNull(Trim(txtCity.Text)) = False Then valCity = Trim(txtCity.Text)
                If IsDBNull(Trim(txtZipCode.Text)) = False Then valZipCode = Trim(txtZipCode.Text)
                If IsDBNull(Trim(txtPhone.Text)) = False Then valPhone = Trim(txtPhone.Text)
                If IsDBNull(Trim(txtFax.Text)) = False Then valFax = Trim(txtFax.Text)
                If IsDBNull(Trim(txtEmail.Text)) = False Then valEmail = Trim(txtEmail.Text)
                intState = 0
                intCountry = 0

                If IsDBNull(Trim(cboState.Text)) = False Then
                    '//Select state ID from list
                    For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                        r = dsState.Tables("lstate").Rows(xCount)
                        If Trim(r("State_Short")) = Trim(cboState.Text) Then
                            intState = Trim(r("State_ID"))
                        End If
                    Next
                End If

                If IsDBNull(Trim(cboCountry.Text)) = False Then
                    '//Select country ID from list
                    For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                        r = dsCountry.Tables("lcountry").Rows(xCount)
                        If Trim(r("Cntry_Name")) = Trim(cboCountry.Text) Then
                            intCountry = Trim(r("Cntry_ID"))
                        End If
                    Next
                End If

                '//Insert goes here
                strSQL = "INSERT INTO lcoinfo (CoInfo_Name, CoInfo_Address1, CoInfo_Address2, CoInfo_City, CoInfo_Cntry, CoInfo_Zip, CoInfo_Phone, CoInfo_Fax, CoInfo_Email, State_ID) " & _
                "VALUES ('" & valName & "', '" & valAddress & "', '" & valAddress2 & "', '" & valCity & "', " & intCountry & ", '" & valZipCode & "', '" & valPhone & "', '" & valFax & "', '" & valEmail & "', " & intState & ")"
                Dim procInsert As New PSS.Data.Production.Joins()
                blnInsert = procInsert.OrderEntryUpdateDelete(strSQL)
            Else
                type = "EDIT"
                '//Proceed to place update here
                initVariables()

                If IsDBNull(Trim(txtName.Text)) = False Then valName = Trim(txtName.Text)
                If IsDBNull(Trim(txtAddress.Text)) = False Then valAddress = Trim(txtAddress.Text)
                If IsDBNull(Trim(txtAddress2.Text)) = False Then valAddress2 = Trim(txtAddress2.Text)
                If IsDBNull(Trim(txtCity.Text)) = False Then valCity = Trim(txtCity.Text)
                If IsDBNull(Trim(txtZipCode.Text)) = False Then valZipCode = Trim(txtZipCode.Text)
                If IsDBNull(Trim(txtPhone.Text)) = False Then valPhone = Trim(txtPhone.Text)
                If IsDBNull(Trim(txtFax.Text)) = False Then valFax = Trim(txtFax.Text)
                If IsDBNull(Trim(txtEmail.Text)) = False Then valEmail = Trim(txtEmail.Text)
                intState = 0
                intCountry = 0

                If IsDBNull(Trim(cboState.Text)) = False Then
                    '//Select state ID from list
                    For xCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                        r = dsState.Tables("lstate").Rows(xCount)
                        If Trim(r("State_Short")) = Trim(cboState.Text) Then
                            intState = Trim(r("State_ID"))
                        End If
                    Next
                End If

                If IsDBNull(Trim(cboCountry.Text)) = False Then
                    '//Select country ID from list
                    For xCount = 0 To dsCountry.Tables("lcountry").Rows.Count - 1
                        r = dsCountry.Tables("lcountry").Rows(xCount)
                        If Trim(r("Cntry_Name")) = Trim(cboCountry.Text) Then
                            intCountry = Trim(r("Cntry_ID"))
                        End If
                    Next
                End If

                '//Update goes here
                strSQL = "UPDATE lcoinfo SET " & _
               "CoInfo_Name = '" & valName & "', " & _
               "CoInfo_Address1 = '" & valAddress & "', " & _
               "CoInfo_Address2 = '" & valAddress2 & "', " & _
               "CoInfo_City = '" & valCity & "', " & _
               "CoInfo_Cntry = " & intCountry & ", " & _
               "CoInfo_Zip = '" & valZipCode & "', " & _
               "CoInfo_Phone = '" & valPhone & "', " & _
               "CoInfo_Fax = '" & valFax & "', " & _
               "CoInfo_Email = '" & valEmail & "' " & _
               "WHERE CoInfo_ID = " & intID

                Dim procInsert As New PSS.Data.Production.Joins()
                blnInsert = procInsert.OrderEntryUpdateDelete(strSQL)
            End If

            If blnInsert = False Then
                MsgBox("An error has occurred while inserting/ updating this entry.", MsgBoxStyle.OKOnly, "ERROR")
            Else
                clearModificationWindow()
                unlockCompanyGrid()
                intID = 0
                Dim CompanyDT As DataTable = getCompanyList()
                populateCompanyGrid(CompanyDT)
            End If


        End Function

        Private Sub initVariables()

            valName = "Null"
            valAddress = "Null"
            valAddress2 = "Null"
            valCity = "Null"
            valZipCode = "Null"
            valPhone = "Null"
            valFax = "Null"
            valEmail = "Null"
            intState = 0
            intCountry = 0

        End Sub


        Private Sub txtCity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCity.TextChanged

        End Sub
    End Class

End Namespace
