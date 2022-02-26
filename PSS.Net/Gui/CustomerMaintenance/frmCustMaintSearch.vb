Imports PSS.Core.Global

Namespace Gui.CustomerMaint

    Public Class frmCustMaintSearch
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
        Friend WithEvents searchGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCustMaintSearch))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.searchGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.searchGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'searchGrid
            '
            Me.searchGrid.AllowFilter = True
            Me.searchGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.searchGrid.AllowSort = True
            Me.searchGrid.AlternatingRows = True
            Me.searchGrid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.searchGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.searchGrid.CaptionHeight = 17
            Me.searchGrid.CollapseColor = System.Drawing.Color.Black
            Me.searchGrid.DataChanged = False
            Me.searchGrid.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.searchGrid.BackColor = System.Drawing.Color.Empty
            Me.searchGrid.ExpandColor = System.Drawing.Color.Black
            Me.searchGrid.FilterBar = True
            Me.searchGrid.GroupByCaption = "Drag a column header here to group by that column"
            Me.searchGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.searchGrid.Location = New System.Drawing.Point(16, 40)
            Me.searchGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.searchGrid.Name = "searchGrid"
            Me.searchGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.searchGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.searchGrid.PreviewInfo.ZoomFactor = 75
            Me.searchGrid.PrintInfo.ShowOptionsDialog = False
            Me.searchGrid.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.searchGrid.RowDivider = GridLines1
            Me.searchGrid.RowHeight = 15
            Me.searchGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.searchGrid.ScrollTips = False
            Me.searchGrid.Size = New System.Drawing.Size(584, 400)
            Me.searchGrid.TabIndex = 1
            Me.searchGrid.Text = "C1TrueDBGrid1"
            Me.searchGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:Aqua;}Selected{ForeColor:HighlightText;BackCol" & _
            "or:Highlight;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Inactive{ForeColor:InactiveCaptionText;BackC" & _
            "olor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;}Style20{}High" & _
            "lightRow{ForeColor:HighlightText;BackColor:Highlight;}Normal{}Style26{}Style25{}" & _
            "Style24{}Style23{AlignHorz:Near;}Style22{}Style21{}OddRow{}RecordSelector{AlignI" & _
            "mage:Center;}Style18{}Style19{}Style14{}Style15{}Style16{}Style17{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.GroupByView Name="""" AlternatingRowStyle=""True"" C" & _
            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""Tr" & _
            "ue"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" VerticalScrollGroup" & _
            "=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 582, 398</ClientRect><DefRecSel" & _
            "Width>16</DefRecSelWidth><CaptionStyle parent=""Heading"" me=""Style23"" /><EditorSt" & _
            "yle parent=""Editor"" me=""Style15"" /><EvenRowStyle parent=""EvenRow"" me=""Style21"" /" & _
            "><FilterBarStyle parent=""FilterBar"" me=""Style26"" /><FooterStyle parent=""Footer"" " & _
            "me=""Style17"" /><GroupStyle parent=""Group"" me=""Style25"" /><HeadingStyle parent=""H" & _
            "eading"" me=""Style16"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style20"" /><" & _
            "InactiveStyle parent=""Inactive"" me=""Style19"" /><OddRowStyle parent=""OddRow"" me=""" & _
            "Style22"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style24"" /><Selected" & _
            "Style parent=""Selected"" me=""Style18"" /><Style parent=""Normal"" me=""Style14"" /></C" & _
            "1.Win.C1TrueDBGrid.GroupByView></Splits><NamedStyles><Style parent="""" me=""Normal" & _
            """ /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" />" & _
            "<Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><" & _
            "Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Styl" & _
            "e parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Sty" & _
            "le parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><" & _
            "Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Na" & _
            "medStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layo" & _
            "ut><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 582, 398</Client" & _
            "Area></Blob>"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(16, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(592, 23)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Customer Information - GENERAL"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmCustMaintSearch
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(616, 461)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.searchGrid})
            Me.Name = "frmCustMaintSearch"
            Me.Text = "frmCustMaintSearch"
            CType(Me.searchGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmCustMaintSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            populateSearchGrid()

        End Sub

        Private Sub populateSearchGrid()

            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("Select lparentco.PCo_Name, tcustomer.Cust_Name1, tcustomer.Cust_Name2, tlocation.Loc_Name, tlocation.Loc_Address1, tlocation.Loc_Address2, tlocation.Loc_City, lstate.State_Short, tlocation.Loc_Zip, tlocation.Loc_Contact, tlocation.Loc_Phone, tlocation.Loc_Fax, tlocation.Loc_Email, tcreditcard.creditcard_num from ((((lparentco INNER JOIN tcustomer ON lparentco.PCo_ID = tcustomer.PCo_ID) INNER JOIN tlocation ON tcustomer.Cust_ID = tlocation.Cust_ID) INNER JOIN lstate ON tlocation.State_ID = lstate.State_ID) LEFT JOIN tcreditcard ON tcustomer.cust_id = tcreditcard.cust_id) ORDER BY lparentco.PCo_Name, tcustomer.Cust_Name1, tcustomer.Cust_Name2, tlocation.Loc_Name")
            searchGrid.DataSource = dt.DefaultView

            searchGrid.Columns(0).Caption = "Parent Company"
            searchGrid.Columns(1).Caption = "Customer"
            searchGrid.Columns(2).Caption = "Last Name"
            searchGrid.Columns(3).Caption = "Location"
            searchGrid.Columns(4).Caption = "Address"
            searchGrid.Columns(5).Caption = "Address 2"
            searchGrid.Columns(6).Caption = "City"
            searchGrid.Columns(7).Caption = "State"
            searchGrid.Columns(8).Caption = "Zip"
            searchGrid.Columns(9).Caption = "Contact"
            searchGrid.Columns(10).Caption = "Phone"
            searchGrid.Columns(11).Caption = "Fax"
            searchGrid.Columns(12).Caption = "Email"
            searchGrid.Columns(13).Caption = "Credit Card"

        End Sub

    End Class

End Namespace
