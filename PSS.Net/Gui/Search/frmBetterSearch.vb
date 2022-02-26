Public Class frmBetterSearch
    Inherits System.Windows.Forms.Form

    Private G_objBetterSearch As PSS.Data.Buisness.BetterSearch
    Private G_dtParts As DataTable
    Private G_dtQC As DataTable
    Private G_dtUser As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        G_objBetterSearch = New PSS.Data.Buisness.BetterSearch()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not IsNothing(G_dtParts) Then
                G_dtParts.Dispose()
                G_dtParts = Nothing
            End If
            If Not IsNothing(G_dtQC) Then
                G_dtQC.Dispose()
                G_dtQC = Nothing
            End If
            If Not IsNothing(G_dtUser) Then
                G_dtUser.Dispose()
                G_dtUser = Nothing
            End If
            G_objBetterSearch = Nothing

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
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents txtSearchCriteria As System.Windows.Forms.TextBox
    Friend WithEvents lblCriteria As System.Windows.Forms.Label
    Friend WithEvents cmbSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents grdDetail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents RadioParts As System.Windows.Forms.RadioButton
    Friend WithEvents RadioQC As System.Windows.Forms.RadioButton
    Friend WithEvents PanelDetailOptions As System.Windows.Forms.Panel
    Friend WithEvents grdSearchResults As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBetterSearch))
        Me.grdSearchResults = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtSearchCriteria = New System.Windows.Forms.TextBox()
        Me.cmbSearchBy = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lbl = New System.Windows.Forms.Label()
        Me.lblCriteria = New System.Windows.Forms.Label()
        Me.grdDetail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.RadioParts = New System.Windows.Forms.RadioButton()
        Me.RadioQC = New System.Windows.Forms.RadioButton()
        Me.PanelDetailOptions = New System.Windows.Forms.Panel()
        CType(Me.grdSearchResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelDetailOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdSearchResults
        '
        Me.grdSearchResults.AllowColMove = False
        Me.grdSearchResults.AllowColSelect = False
        Me.grdSearchResults.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdSearchResults.AllowSort = False
        Me.grdSearchResults.AllowUpdate = False
        Me.grdSearchResults.AllowUpdateOnBlur = False
        Me.grdSearchResults.AlternatingRows = True
        Me.grdSearchResults.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdSearchResults.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdSearchResults.FilterBar = True
        Me.grdSearchResults.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdSearchResults.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdSearchResults.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdSearchResults.Location = New System.Drawing.Point(0, 66)
        Me.grdSearchResults.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdSearchResults.Name = "grdSearchResults"
        Me.grdSearchResults.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSearchResults.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSearchResults.PreviewInfo.ZoomFactor = 75
        Me.grdSearchResults.RowHeight = 20
        Me.grdSearchResults.Size = New System.Drawing.Size(1008, 286)
        Me.grdSearchResults.TabIndex = 4
        Me.grdSearchResults.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:White;BackColor" & _
        ":SteelBlue;}Selected{ForeColor:Black;BackColor:Yellow;}Style3{}Inactive{ForeColo" & _
        "r:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{BackColor:White;}Foot" & _
        "er{}Caption{AlignHorz:Center;}Style1{}Normal{Font:Arial, 9pt, style=Bold;AlignVe" & _
        "rt:Center;BackColor:SteelBlue;}HighlightRow{ForeColor:HighlightText;BackColor:Hi" & _
        "ghlight;}Style14{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Cen" & _
        "ter;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;Al" & _
        "ignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;" & _
        "BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}St" & _
        "yle16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView A" & _
        "llowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" Alterna" & _
        "tingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeig" & _
        "ht=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17" & _
        """ DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>" & _
        "282</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Ed" & _
        "itor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle" & _
        " parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><G" & _
        "roupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style" & _
        "2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle paren" & _
        "t=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSel" & _
        "ectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selecte" & _
        "d"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 1004, 28" & _
        "2</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Wi" & _
        "n.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><S" & _
        "tyle parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style" & _
        " parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style " & _
        "parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style pare" & _
        "nt=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style par" & _
        "ent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style " & _
        "parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedSty" & _
        "les><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><De" & _
        "faultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 1004, 282</ClientArea>" & _
        "<PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" m" & _
        "e=""Style17"" /></Blob>"
        '
        'txtSearchCriteria
        '
        Me.txtSearchCriteria.Location = New System.Drawing.Point(361, 36)
        Me.txtSearchCriteria.Name = "txtSearchCriteria"
        Me.txtSearchCriteria.Size = New System.Drawing.Size(300, 20)
        Me.txtSearchCriteria.TabIndex = 5
        Me.txtSearchCriteria.Text = ""
        '
        'cmbSearchBy
        '
        Me.cmbSearchBy.Items.AddRange(New Object() {"Serial Number", "Serial Number (Old)", "Work Order", "Work Order ID", "Tray ID", "Ship Manifest ID", "Received Pallet", "Shipped Pallet", "Model", "Customer Name", "Customer ID", "Customer Location", "Customer Location ID", "Bill Code ID", "Bill Code Desc", "Part Number", "Part Description", "Machine Name"})
        Me.cmbSearchBy.Location = New System.Drawing.Point(361, 8)
        Me.cmbSearchBy.Name = "cmbSearchBy"
        Me.cmbSearchBy.Size = New System.Drawing.Size(300, 21)
        Me.cmbSearchBy.TabIndex = 98
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(270, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 99
        Me.Label1.Text = "Search by:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Black
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Yellow
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(229, 64)
        Me.lbl.TabIndex = 100
        Me.lbl.Text = "NEW SEARCH ENGINE"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCriteria
        '
        Me.lblCriteria.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCriteria.ForeColor = System.Drawing.Color.White
        Me.lblCriteria.Location = New System.Drawing.Point(236, 37)
        Me.lblCriteria.Name = "lblCriteria"
        Me.lblCriteria.Size = New System.Drawing.Size(120, 16)
        Me.lblCriteria.TabIndex = 101
        Me.lblCriteria.Text = "Search Criteria:"
        Me.lblCriteria.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdDetail
        '
        Me.grdDetail.AllowColMove = False
        Me.grdDetail.AllowColSelect = False
        Me.grdDetail.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdDetail.AllowSort = False
        Me.grdDetail.AllowUpdate = False
        Me.grdDetail.AllowUpdateOnBlur = False
        Me.grdDetail.AlternatingRows = True
        Me.grdDetail.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDetail.BackColor = System.Drawing.Color.LightSteelBlue
        Me.grdDetail.FilterBar = True
        Me.grdDetail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDetail.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdDetail.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdDetail.Location = New System.Drawing.Point(0, 360)
        Me.grdDetail.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdDetail.Name = "grdDetail"
        Me.grdDetail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDetail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDetail.PreviewInfo.ZoomFactor = 75
        Me.grdDetail.RowHeight = 20
        Me.grdDetail.Size = New System.Drawing.Size(1007, 144)
        Me.grdDetail.TabIndex = 104
        Me.grdDetail.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:HotPink;BackCol" & _
        "or:Transparent;}Selected{ForeColor:Black;BackColor:Yellow;}Style3{}Inactive{Fore" & _
        "Color:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{BackColor:White;}" & _
        "Footer{}Caption{AlignHorz:Center;}Style9{}Normal{Font:Arial, 9pt, style=Bold;Bac" & _
        "kColor:SteelBlue;AlignVert:Center;}HighlightRow{ForeColor:HighlightText;BackColo" & _
        "r:Yellow;}Style12{}OddRow{ForeColor:HotPink;BackColor:Transparent;}RecordSelecto" & _
        "r{AlignImage:Center;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25p" & _
        "t, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeC" & _
        "olor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Styl" & _
        "e14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
        "Grid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSizin" & _
        "g=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" " & _
        "ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordS" & _
        "electorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
        "oup=""1""><Height>140</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Editor" & _
        "Style parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /" & _
        "><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" " & _
        "me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""He" & _
        "ading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Ina" & _
        "ctiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Styl" & _
        "e9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle" & _
        " parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRec" & _
        "t>0, 0, 1003, 140</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bor" & _
        "derStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" " & _
        "me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""" & _
        "Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Ina" & _
        "ctive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edito" & _
        "r"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenR" & _
        "ow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSel" & _
        "ector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Gro" & _
        "up"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>" & _
        "None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 1003, " & _
        "140</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintPageFooterS" & _
        "tyle parent="""" me=""Style17"" /></Blob>"
        '
        'RadioParts
        '
        Me.RadioParts.Checked = True
        Me.RadioParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioParts.ForeColor = System.Drawing.Color.White
        Me.RadioParts.Location = New System.Drawing.Point(18, 10)
        Me.RadioParts.Name = "RadioParts"
        Me.RadioParts.Size = New System.Drawing.Size(144, 16)
        Me.RadioParts.TabIndex = 105
        Me.RadioParts.TabStop = True
        Me.RadioParts.Text = "Show Parts Information"
        '
        'RadioQC
        '
        Me.RadioQC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioQC.ForeColor = System.Drawing.Color.White
        Me.RadioQC.Location = New System.Drawing.Point(18, 34)
        Me.RadioQC.Name = "RadioQC"
        Me.RadioQC.Size = New System.Drawing.Size(144, 16)
        Me.RadioQC.TabIndex = 106
        Me.RadioQC.Text = "Show QC Information"
        '
        'PanelDetailOptions
        '
        Me.PanelDetailOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelDetailOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioQC, Me.RadioParts})
        Me.PanelDetailOptions.Location = New System.Drawing.Point(689, 0)
        Me.PanelDetailOptions.Name = "PanelDetailOptions"
        Me.PanelDetailOptions.Size = New System.Drawing.Size(184, 64)
        Me.PanelDetailOptions.TabIndex = 107
        '
        'frmBetterSearch
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(1016, 510)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelDetailOptions, Me.grdDetail, Me.lblCriteria, Me.lbl, Me.cmbSearchBy, Me.Label1, Me.txtSearchCriteria, Me.grdSearchResults})
        Me.Name = "frmBetterSearch"
        Me.Text = "Search PSS Database better and efficiently."
        CType(Me.grdSearchResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelDetailOptions.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*********************************************************************
    Private Sub frmBetterSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            G_dtUser = Me.G_objBetterSearch.GetAllUsersInfo
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form LoadEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*********************************************************************
    Private Sub Search()
        Dim dt1 As DataTable

        Try
            Me.grdSearchResults.DataSource = Nothing
            Me.grdDetail.DataSource = Nothing

            If Not IsNothing(Me.G_dtParts) Then
                Me.G_dtParts.Dispose()
                Me.G_dtParts = Nothing
            End If
            If Not IsNothing(Me.G_dtQC) Then
                Me.G_dtQC.Dispose()
                Me.G_dtQC = Nothing
            End If

            dt1 = Me.G_objBetterSearch.Search(Trim(Me.cmbSearchBy.Text), Trim(Me.txtSearchCriteria.Text), Me.G_dtUser, Me.G_dtParts, Me.G_dtQC)
            If dt1.Rows.Count > 0 Then
                Me.grdSearchResults.DataSource = dt1.DefaultView
            End If
        Catch ex As Exception
            Throw New Exception(ex.ToString)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************************
    Private Sub txtSearchCriteria_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchCriteria.KeyUp

        Me.grdSearchResults.DataSource = Nothing
        Me.grdDetail.DataSource = Nothing
        'Me.grdSearchResults.Visible = False
        'Me.grdDetail.Visible = False

        If e.KeyValue = 13 Then
            Try
                Me.Search()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Search", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    '*********************************************************************
    Private Sub cmbSearchBy_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSearchBy.SelectionChangeCommitted
        Me.grdSearchResults.DataSource = Nothing
        Me.grdDetail.DataSource = Nothing
        'Me.grdSearchResults.Visible = False
        'Me.grdDetail.Visible = False
        Me.txtSearchCriteria.Focus()
    End Sub

    '*********************************************************************
    Private Sub grdSearchResults_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdSearchResults.MouseUp
        Try
            If Not IsNothing(Me.grdSearchResults) Then
                If Me.grdSearchResults.Columns.Count = 0 Then
                    Exit Sub
                End If

                '****************
                'populate data
                '****************
                If Not IsDBNull(Me.grdSearchResults.Columns("Device_ID").Value) Then

                    If Me.RadioParts.Checked = True Then
                        '***********************************
                        'Populate Parts data
                        '***********************************
                        Me.PopulatePartsInfo(Me.grdSearchResults.Columns("Device_ID").Value)
                    Else
                        '***********************************
                        'Populate QC data
                        '***********************************
                        Me.PopulateQCInfo(Me.grdSearchResults.Columns("Device_ID").Value)
                    End If
                Else
                    Exit Sub
                End If

            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "grdSearchResults_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************************
    Private Sub PopulatePartsInfo(ByVal iDevice_ID As Integer)
        Dim i As Integer
        Dim R1() As DataRow
        Dim drNewRow As DataRow
        Dim dt1 As New DataTable()
        Dim objGen As New PSS.Data.Buisness.Generic()
        Dim decTotal As Decimal = 0

        Try
            R1 = Me.G_dtParts.Select("Device_ID = " & iDevice_ID)
            objGen.AddNewColumnToDataTable(dt1, "Desc", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "Avg Cost", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "Std Cost", "System.String", "")

            For i = 0 To R1.Length - 1
                drNewRow = dt1.NewRow
                drNewRow("Desc") = R1(i)("Desc")
                drNewRow("Avg Cost") = R1(i)("Avg Cost")
                drNewRow("Std Cost") = R1(i)("Std Cost")
                dt1.Rows.Add(drNewRow)
                dt1.AcceptChanges()

                drNewRow = Nothing
            Next i

            Me.grdDetail.DataSource = Nothing
            Me.grdDetail.DataSource = dt1.DefaultView

            If PSS.Core.ApplicationUser.GetPermission(Me.GetType.Name) < 2 Then
                Me.grdDetail.Splits(0).DisplayColumns("Avg Cost").Visible = False
                Me.grdDetail.Splits(0).AllowColMove = False
                Me.grdDetail.Splits(0).DisplayColumns("Std Cost").Visible = False
                Me.grdDetail.Splits(0).AllowColMove = False
            End If

            With Me.grdDetail
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To dt1.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                ''Set individual column data horizontal alignment
                .Splits(0).DisplayColumns("Desc").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                .Splits(0).DisplayColumns("Avg Cost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Std Cost").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns("Desc").Width = 120
                .Splits(0).DisplayColumns("Avg Cost").Width = 60
                .Splits(0).DisplayColumns("Std Cost").Width = 600
            End With

            Me.grdDetail.Refresh()

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************************
    Private Sub PopulateQCInfo(ByVal iDevice_ID As Integer)
        Dim i As Integer
        Dim R1() As DataRow
        Dim drNewRow As DataRow
        Dim dt1 As New DataTable()
        Dim objGen As New PSS.Data.Buisness.Generic()
        Dim decTotal As Decimal = 0

        Try
            R1 = Me.G_dtQC.Select("Device_ID = " & iDevice_ID)
            objGen.AddNewColumnToDataTable(dt1, "Iteration", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "QC Date", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "QC Type", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "QC Result", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "Failure Code", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "Failure Reason", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "QC Inspector", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "Tech", "System.String", "")

            For i = 0 To R1.Length - 1
                drNewRow = dt1.NewRow
                drNewRow("Iteration") = R1(i)("Iteration")
                drNewRow("QC Date") = R1(i)("QC Date")
                drNewRow("QC Type") = R1(i)("QC Type")
                drNewRow("QC Result") = R1(i)("QC Result")
                drNewRow("Failure Code") = R1(i)("Failure Code")
                drNewRow("Failure Reason") = R1(i)("Failure Reason")
                drNewRow("QC Inspector") = R1(i)("QC Inspector")
                drNewRow("Tech") = R1(i)("Tech")
                dt1.Rows.Add(drNewRow)
                dt1.AcceptChanges()

                drNewRow = Nothing
            Next i

            Me.grdDetail.DataSource = Nothing
            Me.grdDetail.DataSource = dt1.DefaultView

            With Me.grdDetail
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To dt1.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                Next i

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns("Iteration").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("QC Result").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns("Iteration").Width = 55
                .Splits(0).DisplayColumns("QC Date").Width = 140
                .Splits(0).DisplayColumns("QC Type").Width = 65
                .Splits(0).DisplayColumns("QC Result").Width = 65
                .Splits(0).DisplayColumns("Failure Code").Width = 80
                .Splits(0).DisplayColumns("Failure Reason").Width = 87
                .Splits(0).DisplayColumns("QC Inspector").Width = 210
                .Splits(0).DisplayColumns("Tech").Width = 210
            End With

            Me.grdDetail.Refresh()

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************************


End Class
