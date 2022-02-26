Public Class frmCellLoc
    Inherits System.Windows.Forms.Form

    Private iCust As Int32
    Private dataGrid As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal vCust As Int32)
        MyBase.New()

        iCust = vCust

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
    Friend WithEvents MainGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCellLoc))
        Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Me.MainGrid = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainGrid
        '
        Me.MainGrid.AllowFilter = True
        Me.MainGrid.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.MainGrid.AllowSort = True
        Me.MainGrid.CaptionHeight = 17
        Me.MainGrid.CollapseColor = System.Drawing.Color.Black
        Me.MainGrid.DataChanged = False
        Me.MainGrid.BackColor = System.Drawing.Color.Empty
        Me.MainGrid.ExpandColor = System.Drawing.Color.Black
        Me.MainGrid.GroupByCaption = "Drag a column header here to group by that column"
        Me.MainGrid.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.MainGrid.Location = New System.Drawing.Point(8, 8)
        Me.MainGrid.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.MainGrid.PreviewInfo.ZoomFactor = 75
        Me.MainGrid.PrintInfo.ShowOptionsDialog = False
        Me.MainGrid.RecordSelectorWidth = 16
        GridLines1.Color = System.Drawing.Color.DarkGray
        GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.MainGrid.RowDivider = GridLines1
        Me.MainGrid.RowHeight = 15
        Me.MainGrid.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.MainGrid.ScrollTips = False
        Me.MainGrid.Size = New System.Drawing.Size(656, 296)
        Me.MainGrid.TabIndex = 0
        Me.MainGrid.Text = "C1TrueDBGrid1"
        Me.MainGrid.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
        ", 0, 652, 292</ClientRect><BorderSide>0</BorderSide><CaptionStyle parent=""Style2" & _
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
        "yout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 6" & _
        "52, 292</ClientArea></Blob>"
        '
        'frmCellLoc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(672, 309)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.MainGrid})
        Me.Name = "frmCellLoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choose Location..."
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCellLoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        getCustomerAddress(iCust)

    End Sub


    Private Sub getCustomerAddress(ByVal intCust As Int32)

        Dim dtAdd As New PSS.Data.Production.tlocation()
        Dim tAdd As DataTable = dtAdd.GetRowsByCustomerID(iCust)
        Dim xCount As Integer
        Dim yCount As Integer
        Dim r As DataRow


        DataGrid = CreateGridDT()
        MainGrid.DataSource = DataGrid


        'Dim dr1 As DataRow = DataGrid.NewRow
        Dim dr1 As DataRow

        Dim tblState As New PSS.Data.Production.lstate()
        Dim dsState As DataSet = tblState.GetData

        For xCount = 0 To tAdd.Rows.Count - 1
            r = tAdd.Rows(xCount)

            dr1 = dataGrid.NewRow

            '//This section will convert the State ID over to the Start Short Name
            If r("State_ID") > 0 Then
                'Get State Name for Address
                Dim rState As DataRow
                For yCount = 0 To dsState.Tables("lstate").Rows.Count - 1
                    rState = dsState.Tables("lstate").Rows(yCount)
                    If rState("State_ID") = r("State_ID") Then
                        dr1("State") = rState("State_Short")
                        Exit For
                    End If
                Next
            End If

            'dr1("ID") = r("Loc_ID")
            dr1("Location") = r("Loc_Name")
            dr1("Address1") = r("Loc_Address1")
            dr1("Address2") = r("Loc_Address2")
            dr1("City") = r("Loc_City")
            dr1("Zip") = r("Loc_Zip")
            dataGrid.Rows.Add(dr1)
        Next
        dsState.Dispose()
        dsState = Nothing
        tblState = Nothing

    End Sub


    Private Function CreateGridDT() As DataTable

        Dim dtGrid As New DataTable("dtGridMain")

        dtGrid.MinimumCapacity = 500
        dtGrid.CaseSensitive = False

        'Dim dcDeviceID As New DataColumn("ID")
        'dtGrid.Columns.Add(dcDeviceID)
        Dim dcLocation As New DataColumn("Location")
        dtGrid.Columns.Add(dcLocation)
        Dim dcAddress1 As New DataColumn("Address1")
        dtGrid.Columns.Add(dcAddress1)
        Dim dcAddress2 As New DataColumn("Address2")
        dtGrid.Columns.Add(dcAddress2)
        Dim dcCity As New DataColumn("City")
        dtGrid.Columns.Add(dcCity)
        Dim dcState As New DataColumn("State")
        dtGrid.Columns.Add(dcState)
        Dim dcZip As New DataColumn("Zip")
        dtGrid.Columns.Add(dcZip)

        CreateGridDT = dtGrid

    End Function

    Private Sub MainGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MainGrid.Click




    End Sub

    Private Sub MainGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MainGrid.MouseUp

        Try
            PSS.Gui.Receiving.frmReceiving.multiLoc = MainGrid.Columns(0).Value
            If Len(MainGrid.Columns(0).Value) > 0 Then
                Me.Close()
            End If
        Catch exp As Exception
        End Try

    End Sub

End Class
