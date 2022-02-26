Imports PSS.Core
Imports PSS.Data


Namespace Gui.CompanyAdmin

    Public Class CompAdmin
        Inherits System.Windows.Forms.Form

        Private dtSP As DataTable
        Private datagrid As DataTable
        Private valID, valFN, valLN, valSSN As String

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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents SPgrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents grpModification As System.Windows.Forms.GroupBox
        Friend WithEvents lblCompany As System.Windows.Forms.Label
        Friend WithEvents txtSSNum As System.Windows.Forms.TextBox
        Friend WithEvents txtLastName As System.Windows.Forms.TextBox
        Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
        Friend WithEvents lblID As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnNew As System.Windows.Forms.Button
        Friend WithEvents SPgridCompany As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CompAdmin))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Dim GridLines2 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SPgrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpModification = New System.Windows.Forms.GroupBox()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.txtSSNum = New System.Windows.Forms.TextBox()
            Me.txtLastName = New System.Windows.Forms.TextBox()
            Me.txtFirstName = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblID = New System.Windows.Forms.Label()
            Me.btnNew = New System.Windows.Forms.Button()
            Me.SPgridCompany = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblCompany = New System.Windows.Forms.Label()
            CType(Me.SPgrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpModification.SuspendLayout()
            CType(Me.SPgridCompany, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(328, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "SalesPerson(s)"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'SPgrid
            '
            Me.SPgrid.AllowColMove = False
            Me.SPgrid.AllowFilter = True
            Me.SPgrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.SPgrid.AllowSort = True
            Me.SPgrid.AllowUpdate = False
            Me.SPgrid.AllowUpdateOnBlur = False
            Me.SPgrid.AllowVerticalSplit = True
            Me.SPgrid.AlternatingRows = True
            Me.SPgrid.CaptionHeight = 17
            Me.SPgrid.CollapseColor = System.Drawing.Color.Black
            Me.SPgrid.DataChanged = False
            'Me.SPgrid.BackColor = System.Drawing.Color.Empty
            'Commented out by Asif on 10/16/2006
            Me.SPgrid.BackColor = System.Drawing.Color.Empty

            Me.SPgrid.DefColWidth = 75
            Me.SPgrid.ExpandColor = System.Drawing.Color.Black
            Me.SPgrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.SPgrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.SPgrid.Location = New System.Drawing.Point(16, 40)
            Me.SPgrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.SPgrid.Name = "SPgrid"
            Me.SPgrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.SPgrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.SPgrid.PreviewInfo.ZoomFactor = 75
            Me.SPgrid.PrintInfo.ShowOptionsDialog = False
            Me.SPgrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.SPgrid.RowDivider = GridLines1
            Me.SPgrid.RowHeight = 15
            Me.SPgrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.SPgrid.ScrollTips = False
            Me.SPgrid.Size = New System.Drawing.Size(328, 344)
            Me.SPgrid.TabIndex = 1
            Me.SPgrid.Text = "C1TrueDBGrid1"
            Me.SPgrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}S" & _
            "tyle12{}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selecte" & _
            "d{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Cente" & _
            "r;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Inactive{Fo" & _
            "reColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}OddRow{}Footer" & _
            "{}Caption{AlignHorz:Center;}Normal{}Style10{AlignHorz:Near;}HighlightRow{ForeCol" & _
            "or:HighlightText;BackColor:Highlight;}Editor{}Style11{}RecordSelector{AlignImage" & _
            ":Center;}Style9{}Style8{}Style3{}Style2{}Style1{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView AllowColMove=""False"" Name="""" AlternatingRowStyle=""True"" " & _
            "CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle" & _
            "=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollG" & _
            "roup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 324, 340</ClientRect><Borde" & _
            "rSide>0</BorderSide><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle pa" & _
            "rent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Filter" & _
            "BarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Styl" & _
            "e3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" m" & _
            "e=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveSty" & _
            "le parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><R" & _
            "ecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=" & _
            """Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBG" & _
            "rid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent" & _
            "=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""He" & _
            "ading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Nor" & _
            "mal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal""" & _
            " me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal" & _
            """ me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Nor" & _
            "mal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSp" & _
            "lits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRe" & _
            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 324, 340</ClientArea></Blob>"
            '
            'grpModification
            '
            Me.grpModification.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnSave, Me.txtSSNum, Me.txtLastName, Me.txtFirstName, Me.Label5, Me.Label4, Me.Label3, Me.lblID})
            Me.grpModification.Location = New System.Drawing.Point(352, 32)
            Me.grpModification.Name = "grpModification"
            Me.grpModification.Size = New System.Drawing.Size(432, 176)
            Me.grpModification.TabIndex = 5
            Me.grpModification.TabStop = False
            Me.grpModification.Text = "Insert/ Update Information"
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(8, 144)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.TabIndex = 9
            Me.btnCancel.TabStop = False
            Me.btnCancel.Text = "&Cancel"
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(344, 144)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.TabIndex = 5
            Me.btnSave.Text = "&Save"
            '
            'txtSSNum
            '
            Me.txtSSNum.Location = New System.Drawing.Point(144, 104)
            Me.txtSSNum.Name = "txtSSNum"
            Me.txtSSNum.Size = New System.Drawing.Size(176, 20)
            Me.txtSSNum.TabIndex = 4
            Me.txtSSNum.Text = ""
            '
            'txtLastName
            '
            Me.txtLastName.Location = New System.Drawing.Point(144, 80)
            Me.txtLastName.Name = "txtLastName"
            Me.txtLastName.Size = New System.Drawing.Size(176, 20)
            Me.txtLastName.TabIndex = 3
            Me.txtLastName.Text = ""
            '
            'txtFirstName
            '
            Me.txtFirstName.Location = New System.Drawing.Point(144, 56)
            Me.txtFirstName.Name = "txtFirstName"
            Me.txtFirstName.Size = New System.Drawing.Size(176, 20)
            Me.txtFirstName.TabIndex = 2
            Me.txtFirstName.Text = ""
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(40, 108)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(100, 16)
            Me.Label5.TabIndex = 3
            Me.Label5.Text = "SS Number:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(40, 84)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(100, 16)
            Me.Label4.TabIndex = 2
            Me.Label4.Text = "Last Name:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(40, 60)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(100, 16)
            Me.Label3.TabIndex = 1
            Me.Label3.Text = "First Name:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblID
            '
            Me.lblID.Location = New System.Drawing.Point(144, 24)
            Me.lblID.Name = "lblID"
            Me.lblID.Size = New System.Drawing.Size(168, 16)
            Me.lblID.TabIndex = 0
            Me.lblID.Text = "ID:"
            '
            'btnNew
            '
            Me.btnNew.Location = New System.Drawing.Point(16, 392)
            Me.btnNew.Name = "btnNew"
            Me.btnNew.Size = New System.Drawing.Size(328, 23)
            Me.btnNew.TabIndex = 8
            Me.btnNew.TabStop = False
            Me.btnNew.Text = "&New Entry"
            '
            'SPgridCompany
            '
            Me.SPgridCompany.AllowFilter = True
            Me.SPgridCompany.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.SPgridCompany.AllowSort = True
            Me.SPgridCompany.AlternatingRows = True
            Me.SPgridCompany.CaptionHeight = 17
            Me.SPgridCompany.CollapseColor = System.Drawing.Color.Black
            Me.SPgridCompany.DataChanged = False
            Me.SPgridCompany.BackColor = System.Drawing.Color.Empty
            Me.SPgridCompany.DefColWidth = 180
            Me.SPgridCompany.ExpandColor = System.Drawing.Color.Black
            Me.SPgridCompany.GroupByCaption = "Drag a column header here to group by that column"
            Me.SPgridCompany.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.SPgridCompany.Location = New System.Drawing.Point(352, 240)
            Me.SPgridCompany.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.SPgridCompany.Name = "SPgridCompany"
            Me.SPgridCompany.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.SPgridCompany.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.SPgridCompany.PreviewInfo.ZoomFactor = 75
            Me.SPgridCompany.PrintInfo.ShowOptionsDialog = False
            Me.SPgridCompany.RecordSelectorWidth = 16
            GridLines2.Color = System.Drawing.Color.DarkGray
            GridLines2.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.SPgridCompany.RowDivider = GridLines2
            Me.SPgridCompany.RowHeight = 15
            Me.SPgridCompany.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.SPgridCompany.ScrollTips = False
            Me.SPgridCompany.Size = New System.Drawing.Size(424, 176)
            Me.SPgridCompany.TabIndex = 6
            Me.SPgridCompany.TabStop = False
            Me.SPgridCompany.Text = "C1TrueDBGrid1"
            Me.SPgridCompany.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style9{}Od" & _
            "dRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Borde" & _
            "r:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{Al" & _
            "ignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win" & _
            ".C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Co" & _
            "lumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" R" & _
            "ecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalSc" & _
            "rollGroup=""1""><ClientRect>0, 0, 420, 172</ClientRect><BorderSide>0</BorderSide><" & _
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
            "elWidth><ClientArea>0, 0, 420, 172</ClientArea></Blob>"
            '
            'lblCompany
            '
            Me.lblCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCompany.Location = New System.Drawing.Point(352, 216)
            Me.lblCompany.Name = "lblCompany"
            Me.lblCompany.Size = New System.Drawing.Size(424, 16)
            Me.lblCompany.TabIndex = 7
            Me.lblCompany.Text = "Company Assignments"
            Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'CompAdmin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(790, 501)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCompany, Me.SPgridCompany, Me.grpModification, Me.SPgrid, Me.Label1, Me.btnNew})
            Me.Name = "CompAdmin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "SalesPerson Maintenance"
            CType(Me.SPgrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpModification.ResumeLayout(False)
            CType(Me.SPgridCompany, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmCompAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            '//Create a grid of curretn sales people for PSS, Inc.
            '//Get SalesPerson DataSet
            Dim SalesPersonDS As DataTable = getSalesPersonList()
            populateSalesPersonGrid(SalesPersonDS)

            '//Hide startup windows for form.
            hideModificationWindow()
            hideCompanyWindow()

            '//Set focus to salesperson grid.
            SPgrid.Focus()

        End Sub

#Region "Window Display Modules"

        Private Sub hideModificationWindow()
            grpModification.Visible = False
        End Sub

        Private Sub showModificationWindow()
            grpModification.Visible = True
        End Sub

        Private Sub hideCompanyWindow()
            lblCompany.Visible = False
            SPgridCompany.Visible = False
        End Sub

        Private Sub showCompanyWindow()
            lblCompany.Visible = True
            SPgridCompany.Visible = True
        End Sub

#End Region

#Region "SalesPerson Grid Mechanics"

        Private Function getSalesPersonList() As DataTable

            Try
                Dim objCustMaint As New PSS.Data.Buisness.CustMaintNew()
                getSalesPersonList = objCustMaint.GetSalePerson(False)
                objCustMaint = Nothing
            Catch exp As Exception

            End Try

        End Function

        Private Function getSalesPersonCompanyList(ByVal valSPID As Int32) As DataTable

            Try
                Dim clsSPcompanylist As New PSS.Data.Production.Joins()
                getSalesPersonCompanyList = clsSPcompanylist.OrderEntrySelect("select cust_Name1, slsp_id from tcustomer where slsp_id = " & valSPID & " Order by cust_Name1")
                clsSPcompanylist = Nothing
            Catch exp As Exception

            End Try

        End Function

        Private Sub populateSalesPersonGrid(ByVal valData As DataTable)

            SPgrid.DataSource = valData.DefaultView

            SPgrid.Columns(0).Caption = "ID"
            SPgrid.Columns(1).Caption = "First Name"
            'SPgrid.Columns(2).Caption = "Last Name"
            'SPgrid.Columns(3).Caption = "SS Number"

        End Sub

        Private Sub populateSalesPersonCompanyGrid(ByVal valData As DataTable)

            SPgridCompany.DataSource = Nothing

            SPgridCompany.DataSource = valData.DefaultView

            SPgridCompany.Columns(0).Caption = "Name(1)"
            SPgridCompany.Columns(1).Caption = "SalesPerson ID"

        End Sub

        Private Sub SPgrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SPgrid.MouseUp

            populateModificationWindow()
            populateCompanyWindow()

        End Sub

#End Region

#Region "SPgrid Locking calls"

        Private Sub lockSPgrid()

            '//Lock out SPgrid until changes are complete or cancelled.
            SPgrid.Enabled = False

        End Sub

        Private Sub unlockSPgrid()

            '//Unlock out SPgrid when changes are complete or cancelled.
            SPgrid.Enabled = True

        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            unlockSPgrid()
            saveRecord()

        End Sub

        Private Sub txtFirstName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFirstName.KeyUp
            lockSPgrid()
        End Sub

        Private Sub txtLastName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLastName.KeyUp
            lockSPgrid()
        End Sub

        Private Sub txtSSNum_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSSNum.KeyUp
            lockSPgrid()
        End Sub

#End Region

#Region "Modifcation Window Procedures"

        Private Sub populateModificationWindow()

            '//Hide window while updates are occurring
            hideModificationWindow()

            '//Assign defaultws
            valID = ""
            valFN = ""
            valLN = ""
            valSSN = ""

            '//Assign values if applicable
            If IsDBNull(SPgrid.Columns(0).Text) = False Then valID = SPgrid.Columns(0).Text
            If IsDBNull(SPgrid.Columns(1).Text) = False Then valFN = SPgrid.Columns(1).Text
            If IsDBNull(SPgrid.Columns(2).Text) = False Then valLN = SPgrid.Columns(2).Text
            If IsDBNull(SPgrid.Columns(3).Text) = False Then valSSN = SPgrid.Columns(3).Text

            '//Assign values to textboxes
            lblID.Text = "ID: " & valID
            txtFirstName.Text = valFN
            txtLastName.Text = valLN
            txtSSNum.Text = valSSN

            '//Display window once load in complete
            showModificationWindow()

        End Sub

        Private Sub clearModificationWindow()

            lblID.Text = "ID: "
            txtFirstName.Text = ""
            txtLastName.Text = ""
            txtSSNum.Text = ""

        End Sub

#End Region

#Region "Company Window procedures"

        Private Sub populateCompanyWindow()

            hideCompanyWindow()
            Dim compList As DataTable = getSalesPersonCompanyList(valID)
            populateSalesPersonCompanyGrid(compList)
            showCompanyWindow()

        End Sub

#End Region

#Region " Form Buttons "

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

            '//Verify cancellation
            Dim intResponse As String
            intResponse = MsgBox("You have decided to cancel this entry, changes will not be saved. Continue?", MsgBoxStyle.OKCancel, "Confirm Cancel")
            Select Case intResponse
                Case vbOK
                    clearModificationWindow()
                    unlockSPgrid()
                    SPgrid.Focus()
                    hideCompanyWindow()
                    grpModification.Visible = False
                Case vbCancel
                    txtFirstName.Focus()
            End Select

        End Sub

        Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

            lockSPgrid()
            showModificationWindow()
            lblID.Text = "ID: NEW ENTRY"
            valID = 0
            txtFirstName.Focus()

        End Sub

#End Region

#Region " Save/Edit Functions "

        Private Function verifyData() As Boolean

            verifyData = False

            Dim msg As String = ""

            If Len(Trim(txtFirstName.Text)) < 1 Then
                msg = msg + "No First Name Defined. " & vbCrLf
            End If

            If Len(Trim(txtLastName.Text)) < 1 Then
                msg = msg + "No Last Name Defined. " & vbCrLf
            End If

            If Len(Trim(txtSSNum.Text)) < 1 Then
                msg = msg + "No SS Number Defined. " & vbCrLf
            End If

            If Trim(msg) = "" Then
                verifyData = True
            Else
                MsgBox(msg & "Record can not be saved.", MsgBoxStyle.OKOnly, "ERROR")
            End If

        End Function

        Private Function saveRecord()

            '//Verify that data is suitable for insertion/ editing
            Dim verData As Boolean = verifyData()
            If verData = False Then Exit Function

            '//Data has been verified - continue
            Dim strSQL As String
            Dim blnInsert As Boolean = False
            '//Determine type for action
            Dim type As String = ""
            If valID = 0 Then
                type = "NEW"
                '//Proceed to place insert here
                valFN = Trim(txtFirstName.Text)
                valLN = Trim(txtLastName.Text)
                valSSN = Trim(txtSSNum.Text)
                strSQL = "INSERT INTO tslsp (slsp_FirstName, slsp_LastName, slsp_SSNum) VALUES ('" & valFN & "', '" & valLN & "', '" & valSSN & "')"
                Dim procInsert As New PSS.Data.Production.Joins()
                blnInsert = procInsert.OrderEntryUpdateDelete(strSQL)
            Else
                type = "EDIT"
                '//Proceed to place update here
                valFN = Trim(txtFirstName.Text)
                valLN = Trim(txtLastName.Text)
                valSSN = Trim(txtSSNum.Text)
                strSQL = "UPDATE tslsp SET slsp_FirstName = '" & valFN & "', slsp_LastName = '" & valLN & "', slsp_SSNum = '" & valSSN & "' WHERE slsp_ID = " & valID
                Dim procInsert As New PSS.Data.Production.Joins()
                blnInsert = procInsert.OrderEntryUpdateDelete(strSQL)
            End If

            If blnInsert = False Then
                MsgBox("An error has occured while inserting/ updating this entry.", MsgBoxStyle.OKOnly, "ERROR")
            Else
                clearModificationWindow()
            End If

        End Function

#End Region

    End Class

End Namespace
