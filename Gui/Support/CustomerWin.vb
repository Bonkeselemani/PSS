Imports PSS.Core
Imports PSS.Data


Namespace Gui.CustomerService

    Public Class CustomerWin
        Inherits System.Windows.Forms.Form

#Region "Dims"
        Friend WithEvents dbgCustomers As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cbCompany As System.Windows.Forms.ComboBox
        Friend WithEvents lblCompanies As System.Windows.Forms.Label
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cbCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cbLocation As System.Windows.Forms.ComboBox
        Friend WithEvents btnRenCo As System.Windows.Forms.Button
        Friend WithEvents btnDelCo As System.Windows.Forms.Button
        Friend WithEvents btnDelCust As System.Windows.Forms.Button
        Friend WithEvents btnViewEditCust As System.Windows.Forms.Button
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents btnAddCo As System.Windows.Forms.Button

        Protected dt As DataTable
        Protected r As System.Data.DataRow
#End Region

#Region "Setup Document"""

        Public Sub New()
            MyBase.New()

            InitializeComponent()
        End Sub
        Friend WithEvents btnAddCust As System.Windows.Forms.Button
        Friend WithEvents btnAddLoc As System.Windows.Forms.Button

        Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CustomerWin))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.dbgCustomers = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cbCompany = New System.Windows.Forms.ComboBox()
            Me.lblCompanies = New System.Windows.Forms.Label()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cbCustomer = New System.Windows.Forms.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cbLocation = New System.Windows.Forms.ComboBox()
            Me.btnRenCo = New System.Windows.Forms.Button()
            Me.btnDelCo = New System.Windows.Forms.Button()
            Me.btnDelCust = New System.Windows.Forms.Button()
            Me.btnViewEditCust = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.btnAddCo = New System.Windows.Forms.Button()
            Me.btnAddCust = New System.Windows.Forms.Button()
            Me.btnAddLoc = New System.Windows.Forms.Button()
            CType(Me.dbgCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dbgCustomers
            '
            Me.dbgCustomers.AllowFilter = True
            Me.dbgCustomers.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.dbgCustomers.AllowSort = True
            Me.dbgCustomers.AllowUpdate = False
            Me.dbgCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgCustomers.CaptionHeight = 17
            Me.dbgCustomers.CollapseColor = System.Drawing.Color.Black
            Me.dbgCustomers.DataChanged = False
            Me.dbgCustomers.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.dbgCustomers.BackColor = System.Drawing.Color.Empty
            Me.dbgCustomers.Dock = System.Windows.Forms.DockStyle.Right
            Me.dbgCustomers.ExpandColor = System.Drawing.Color.Black
            Me.dbgCustomers.FilterBar = True
            Me.dbgCustomers.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgCustomers.Location = New System.Drawing.Point(342, 0)
            Me.dbgCustomers.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.dbgCustomers.Name = "dbgCustomers"
            Me.dbgCustomers.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgCustomers.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgCustomers.PreviewInfo.ZoomFactor = 75
            Me.dbgCustomers.PrintInfo.ShowOptionsDialog = False
            Me.dbgCustomers.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.dbgCustomers.RowDivider = GridLines1
            Me.dbgCustomers.RowHeight = 15
            Me.dbgCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.dbgCustomers.ScrollTips = False
            Me.dbgCustomers.Size = New System.Drawing.Size(440, 493)
            Me.dbgCustomers.TabIndex = 0
            Me.dbgCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:LightBlue;}Selected{ForeColor:HighlightText;Ba" & _
            "ckColor:Highlight;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;" & _
            "ForeColor:ControlText;BackColor:Control;}Inactive{ForeColor:InactiveCaptionText;" & _
            "BackColor:InactiveCaption;}FilterBar{}OddRow{}Footer{}Caption{AlignHorz:Center;}" & _
            "Style25{}Normal{Font:Verdana, 8.25pt;}Style26{}HighlightRow{ForeColor:HighlightT" & _
            "ext;BackColor:Highlight;}Style24{}Style23{AlignHorz:Near;}Style22{}Style21{}Styl" & _
            "e20{}RecordSelector{AlignImage:Center;}Style18{}Style19{}Style14{}Style15{}Style" & _
            "16{}Style17{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.GroupByView Name="""" Ca" & _
            "ptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""Tru" & _
            "e"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 438, 491</ClientRect><DefRecSelW" & _
            "idth>16</DefRecSelWidth><CaptionStyle parent=""Heading"" me=""Style23"" /><EditorSty" & _
            "le parent=""Editor"" me=""Style15"" /><EvenRowStyle parent=""EvenRow"" me=""Style21"" />" & _
            "<FilterBarStyle parent=""FilterBar"" me=""Style26"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style17"" /><GroupStyle parent=""Group"" me=""Style25"" /><HeadingStyle parent=""He" & _
            "ading"" me=""Style16"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style20"" /><I" & _
            "nactiveStyle parent=""Inactive"" me=""Style19"" /><OddRowStyle parent=""OddRow"" me=""S" & _
            "tyle22"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style24"" /><SelectedS" & _
            "tyle parent=""Selected"" me=""Style18"" /><Style parent=""Normal"" me=""Style14"" /></C1" & _
            ".Win.C1TrueDBGrid.GroupByView></Splits><NamedStyles><Style parent="""" me=""Normal""" & _
            " /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><" & _
            "Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><S" & _
            "tyle parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style" & _
            " parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Styl" & _
            "e parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><S" & _
            "tyle parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Nam" & _
            "edStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layou" & _
            "t><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 438, 491</ClientA" & _
            "rea></Blob>"
            '
            'cbCompany
            '
            Me.cbCompany.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbCompany.Location = New System.Drawing.Point(24, 32)
            Me.cbCompany.Name = "cbCompany"
            Me.cbCompany.Size = New System.Drawing.Size(296, 21)
            Me.cbCompany.TabIndex = 0
            '
            'lblCompanies
            '
            Me.lblCompanies.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.lblCompanies.BackColor = System.Drawing.Color.Transparent
            Me.lblCompanies.Location = New System.Drawing.Point(24, 16)
            Me.lblCompanies.Name = "lblCompanies"
            Me.lblCompanies.Size = New System.Drawing.Size(288, 16)
            Me.lblCompanies.TabIndex = 3
            Me.lblCompanies.Text = "Company:"
            '
            'lblCustomer
            '
            Me.lblCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.Location = New System.Drawing.Point(24, 64)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(288, 16)
            Me.lblCustomer.TabIndex = 5
            Me.lblCustomer.Text = "Customer:"
            '
            'cbCustomer
            '
            Me.cbCustomer.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.cbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbCustomer.Location = New System.Drawing.Point(24, 80)
            Me.cbCustomer.Name = "cbCustomer"
            Me.cbCustomer.Size = New System.Drawing.Size(296, 21)
            Me.cbCustomer.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Location = New System.Drawing.Point(24, 112)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(288, 16)
            Me.Label1.TabIndex = 7
            Me.Label1.Text = "Location:"
            '
            'cbLocation
            '
            Me.cbLocation.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cbLocation.Location = New System.Drawing.Point(24, 128)
            Me.cbLocation.Name = "cbLocation"
            Me.cbLocation.Size = New System.Drawing.Size(296, 21)
            Me.cbLocation.TabIndex = 2
            '
            'btnRenCo
            '
            Me.btnRenCo.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnRenCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnRenCo.Location = New System.Drawing.Point(224, 168)
            Me.btnRenCo.Name = "btnRenCo"
            Me.btnRenCo.Size = New System.Drawing.Size(96, 48)
            Me.btnRenCo.TabIndex = 5
            Me.btnRenCo.Text = "Rename Company"
            '
            'btnDelCo
            '
            Me.btnDelCo.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnDelCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDelCo.Location = New System.Drawing.Point(128, 168)
            Me.btnDelCo.Name = "btnDelCo"
            Me.btnDelCo.Size = New System.Drawing.Size(88, 48)
            Me.btnDelCo.TabIndex = 4
            Me.btnDelCo.Text = "Delete Company"
            '
            'btnDelCust
            '
            Me.btnDelCust.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnDelCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnDelCust.Location = New System.Drawing.Point(128, 224)
            Me.btnDelCust.Name = "btnDelCust"
            Me.btnDelCust.Size = New System.Drawing.Size(88, 48)
            Me.btnDelCust.TabIndex = 7
            Me.btnDelCust.Text = "Delete Customer"
            '
            'btnViewEditCust
            '
            Me.btnViewEditCust.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnViewEditCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnViewEditCust.Location = New System.Drawing.Point(224, 224)
            Me.btnViewEditCust.Name = "btnViewEditCust"
            Me.btnViewEditCust.Size = New System.Drawing.Size(96, 48)
            Me.btnViewEditCust.TabIndex = 8
            Me.btnViewEditCust.Text = "View / Edit Customer"
            '
            'Button3
            '
            Me.Button3.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button3.Location = New System.Drawing.Point(128, 280)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(88, 48)
            Me.Button3.TabIndex = 10
            Me.Button3.Text = "Delete Location"
            '
            'Button4
            '
            Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button4.Location = New System.Drawing.Point(224, 280)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(96, 48)
            Me.Button4.TabIndex = 11
            Me.Button4.Text = "View / Edit Location"
            '
            'btnAddCo
            '
            Me.btnAddCo.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnAddCo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddCo.Location = New System.Drawing.Point(24, 168)
            Me.btnAddCo.Name = "btnAddCo"
            Me.btnAddCo.Size = New System.Drawing.Size(96, 48)
            Me.btnAddCo.TabIndex = 3
            Me.btnAddCo.Text = "Add Company"
            '
            'btnAddCust
            '
            Me.btnAddCust.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnAddCust.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddCust.Location = New System.Drawing.Point(24, 224)
            Me.btnAddCust.Name = "btnAddCust"
            Me.btnAddCust.Size = New System.Drawing.Size(96, 48)
            Me.btnAddCust.TabIndex = 6
            Me.btnAddCust.Text = "Add Customer"
            '
            'btnAddLoc
            '
            Me.btnAddLoc.Anchor = System.Windows.Forms.AnchorStyles.Top
            Me.btnAddLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnAddLoc.Location = New System.Drawing.Point(24, 280)
            Me.btnAddLoc.Name = "btnAddLoc"
            Me.btnAddLoc.Size = New System.Drawing.Size(96, 48)
            Me.btnAddLoc.TabIndex = 9
            Me.btnAddLoc.Text = "Add Location"
            '
            'CustomerWin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.ClientSize = New System.Drawing.Size(782, 493)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddLoc, Me.btnAddCust, Me.btnAddCo, Me.Button3, Me.Button4, Me.btnDelCust, Me.btnViewEditCust, Me.btnDelCo, Me.btnRenCo, Me.Label1, Me.cbLocation, Me.lblCustomer, Me.cbCustomer, Me.lblCompanies, Me.cbCompany, Me.dbgCustomers})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "CustomerWin"
            Me.Text = "Customers"
            CType(Me.dbgCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Private Sub CustomerWin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            RefreshDBGrid()
            RefreshCombos()
        End Sub

#End Region

#Region "Functions"

#Region "Combo DBG Functions"
        Private Sub RefreshDBGrid()
            '            dt = New DataTable(SQL.strCompCustLocSql, Connections.Production)
            '           dbgCustomers.DataSource = dt.DefaultView
            '          dt.Dispose()
            '         dbgCustomers.Splits(0).DisplayColumns(0).Visible = False
        End Sub

        Private Sub RefreshCombos()
            '        Dim dr As System.Data.DataRow
            '       dt = New DataTable(SQL.strCompaniesSql, Connections.Production)
            '      For Each dr In dt.Rows
            '         cbCompany.Items.Add(dr(1))
            '    Next
            '   dt.Dispose()
            '  cbCompany.SelectedIndex = 0
            ' cbCustomer.SelectedIndex = 0
            'cbLocation.SelectedIndex = 0
        End Sub

        Private Sub ChangeCompany(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCompany.SelectedValueChanged
            cbCustomer.Items.Clear()
            cbLocation.Items.Clear()
            cbCustomer.Text = ""
            cbLocation.Text = ""

            Try
                '                dt = New DataTable(SQL.GetCompanyID(cbCompany.Text), Connections.Production)
                '               Dim cid As Integer = dt.Rows(0).Item(0)
                '              dt = New DataTable(SQL.GetCustByComp(cid), Connections.Production)
                '             Dim dr As System.Data.DataRow
                '            For Each dr In dt.Rows
                '               cbCustomer.Items.Add(dr(1))
                '          Next
                '         dt.Dispose()
            Catch
                '// here in case there is not data. which should never happen but in case.
            End Try
        End Sub

        Private Sub ChangeCustomer(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCustomer.SelectedValueChanged
            cbLocation.Items.Clear()
            cbLocation.Text = ""

            Try
                '                dt = New DataTable(SQL.GetCustID(cbCustomer.Text), Connections.Production)
                '               Dim cid As Integer = dt.Rows(0).Item(0)
                '              dt = New DataTable(SQL.GetLocByCust(cid), Connections.Production)
                '             Dim dr As System.Data.DataRow
                '            For Each dr In dt.Rows
                '               cbLocation.Items.Add(dr(1))
                '          Next
                '         dt.Dispose()
            Catch
                '// here in case there is not data. which should never happen but in case.
            End Try
        End Sub

        Private Sub dbgCustomers_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgCustomers.RowColChange
            Me.cbCompany.Text = dbgCustomers.Columns(1).Text
            Me.cbCustomer.SelectedItem = dbgCustomers.Columns(2).Text
            Me.cbLocation.Text = dbgCustomers.Columns(3).Text
        End Sub
#End Region

        Private Sub btnAddCo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCo.Click
            Dim response As String = InputBox("Please type the name of the company you wish to add.", "Add Company")
            If response <> "" Then
                Dim dtParentCo As New PSS.Data.Production.lparentco()
                dt = New DataTable()
                dt = dtParentCo.GetCustomerByName(Trim(response))
                If dt.Rows.Count = 0 Then
                    dt.Dispose()
                    If MsgBox("Are you sure you want to add the company: " & response & "?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        MainWin.StatusBar.SetStatusText("Executing Command")
                        response = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(response)
                        '                        Dim c As New Command("INSERT INTO lparentco (PCo_Name) VALUES ('" & SQL.FixUpString(response) & "');", Connections.Production)
                        Dim valResponse As Int32
                        Dim actInsert As New PSS.Data.Production.lparentco()
                        valResponse = actInsert.idTransaction("INSERT INTO lparentco (PCo_Name) VALUES ('" & Trim(response) & "');")

                        RefreshCombos()
                        RefreshDBGrid()
                        MainWin.StatusBar.SetStatusText("Ready")
                        MsgBox("The company was succesfully added to the list.", , "Complete")
                    End If
                Else
                    dt.Dispose()
                    MsgBox("This company is already in the system.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        End Sub

        Private Sub btnDelCo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelCo.Click

            Dim dtParentCo As New PSS.Data.Production.lparentco()
            Dim dtJoins As New PSS.Data.Production.Joins()
            Dim dtCustomer As New PSS.Data.Production.tcustomer()
            Dim dtLocation As New PSS.Data.Production.tlocation()

            dt = New DataTable()
            dt = dtParentCo.GetIDByCustomerName(cbCompany.Text)
            Dim companyid As String = dt.Rows(0).Item(0)
            '            dt = New DataTable("SELECT tdevice.Device_ID FROM ((lparentco INNER JOIN tcustomer ON lparentco.PCo_ID = tcustomer.PCo_ID) INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID) INNER JOIN tdevice ON tlocation.Loc_ID = tdevice.Loc_ID WHERE lparentco.PCo_ID = " & companyid & ";", Connections.Production)
            dt = dtJoins.CompanyDeleteDeviceSelection(companyid)
            If dt.Rows.Count = 0 Then
                dt.Dispose()
                If MsgBox("Are you sure you want to delete this company it will also delete all customers and locations tied to it.", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                    MainWin.StatusBar.SetStatusText("Executing Command")

                    'Dim c As New Command("DELETE FROM lparentco WHERE PCo_ID = " & companyid & ";", Connections.Production)
                    Dim cBln As Boolean = dtParentCo.RemoveDataRowByCompID(companyid)
                    'dt = New DataTable("SELECT Cust_ID FROM tcustomer WHERE PCo_ID = " & companyid & ";", Connections.Production)
                    dt = New DataTable()
                    dt = dtCustomer.GetIDByParentCompany(companyid)

                    For Each r In dt.Rows
                        'c = New Command("DELETE FROM tcustomer WHERE Cust_ID = " & r(0) & ";", Connections.Production)
                        cBln = dtCustomer.RemoveDataRowByCustID(r(0))
                        'c = New Command("DELETE FROM tlocation WHERE Cust_ID = " & r(0) & ";", Connections.Production)
                        cBln = dtLocation.RemoveDataRowByCustID(r(0))
                    Next
                    dt.Dispose()
                    RefreshCombos()
                    RefreshDBGrid()
                    cbCompany.SelectedIndex = 0
                    MainWin.StatusBar.SetStatusText("Ready")
                    MsgBox("The company has succesfully been deleted.", MsgBoxStyle.Information, "Complete")
                End If
            Else
                dt.Dispose()
                MsgBox("You cannot delete a company that has devices asigned to it.", MsgBoxStyle.Critical, "Error")
            End If

        End Sub

        Private Sub btnRenCo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRenCo.Click
            Dim response As String = InputBox("Please enter the new name of the company.", "Rename Company")
            If response <> "" Then
                Dim dtParentCo As New PSS.Data.Production.lparentco()
                '                dt = New DataTable(SQL.GetCompanyID(response), Connections.Production)
                dt = dtParentCo.GetCustomerByName(Trim(response))
                If dt.Rows.Count = 0 Then
                    dt.Dispose()
                    If MsgBox("Are you sure you want rename the company: " & response & "?", MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                        MainWin.StatusBar.SetStatusText("Executing Command")
                        response = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(response)
                        'Dim c As New Command("UPDATE lparentco SET PCo_Name = '" & SQL.FixUpString(response) & "' WHERE PCo_Name = '" & SQL.FixUpString(cbCompany.Text) & "';", Connections.Production)
                        Dim cBln As Boolean
                        cBln = dtParentCo.UpdateDataRowByCompName(cbCompany.Text, response)
                        RefreshDBGrid()
                        RefreshCombos()
                        MainWin.StatusBar.SetStatusText("Ready")
                        MsgBox("The company was succesfully renamed.", , "Complete")
                    End If
                Else
                    dt.Dispose()
                    MsgBox("This company is already in the system.", MsgBoxStyle.Critical, "Error")
                End If
            End If
        End Sub
#End Region

        Private Sub btnAddCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCust.Click

        End Sub
    End Class


End Namespace
