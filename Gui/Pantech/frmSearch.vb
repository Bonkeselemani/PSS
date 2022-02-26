Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.Pantech
    Public Class frmSearch
        Inherits System.Windows.Forms.Form

        Private _objBusSearch As New PSS.Data.Buisness.PantechSearch()
        Private _dsSearch As DataSet = Nothing

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
                Generic.DisposeDS(Me._dsSearch)

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
        Friend WithEvents dbgSearch As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgModels As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgDevicePreBill As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSearch))
            Me.dbgSearch = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgModels = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgDevicePreBill = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.dbgSearch, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgDevicePreBill, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dbgSearch
            '
            Me.dbgSearch.AllowColMove = False
            Me.dbgSearch.AllowColSelect = False
            Me.dbgSearch.AllowUpdate = False
            Me.dbgSearch.AllowUpdateOnBlur = False
            Me.dbgSearch.AlternatingRows = True
            Me.dbgSearch.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgSearch.FilterBar = True
            Me.dbgSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgSearch.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgSearch.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgSearch.Location = New System.Drawing.Point(10, 16)
            Me.dbgSearch.MaintainRowCurrency = True
            Me.dbgSearch.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.dbgSearch.Name = "dbgSearch"
            Me.dbgSearch.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgSearch.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgSearch.PreviewInfo.ZoomFactor = 75
            Me.dbgSearch.RowHeight = 20
            Me.dbgSearch.Size = New System.Drawing.Size(1022, 219)
            Me.dbgSearch.TabIndex = 141
            Me.dbgSearch.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style1{}Normal{Font:Microsoft Sans Serif, 9pt, style=Bold;AlignVert:Center;BackC" & _
            "olor:Control;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{" & _
            "}OddRow{BackColor:Transparent;}RecordSelector{AlignImage:Center;}Style15{}Headin" & _
            "g{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackC" & _
            "olor:LightSteelBlue;Border:Raised,,1, 1, 1, 1;ForeColor:Black;AlignVert:Center;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" A" & _
            "llowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Colu" & _
            "mnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Dott" & _
            "edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
            "1"" HorizontalScrollGroup=""1""><Height>215</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 1018, 215</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 1018, 215</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14" & _
            """ /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'dbgModels
            '
            Me.dbgModels.AllowColMove = False
            Me.dbgModels.AllowColSelect = False
            Me.dbgModels.AllowUpdate = False
            Me.dbgModels.AllowUpdateOnBlur = False
            Me.dbgModels.AllowVerticalSplit = True
            Me.dbgModels.AlternatingRows = True
            Me.dbgModels.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgModels.Cursor = System.Windows.Forms.Cursors.Default
            Me.dbgModels.FilterBar = True
            Me.dbgModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgModels.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgModels.Location = New System.Drawing.Point(8, 280)
            Me.dbgModels.MaintainRowCurrency = True
            Me.dbgModels.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgModels.Name = "dbgModels"
            Me.dbgModels.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgModels.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgModels.PreviewInfo.ZoomFactor = 75
            Me.dbgModels.RowHeight = 20
            Me.dbgModels.Size = New System.Drawing.Size(464, 219)
            Me.dbgModels.TabIndex = 143
            Me.dbgModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}FilterBar{ForeColor:Red;BackColor:Transparent;}Style38{AlignHorz:Near;}Ev" & _
            "enRow{BackColor:Transparent;}Selected{ForeColor:ControlText;BackColor:Yellow;}St" & _
            "yle33{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}Style39" & _
            "{}Style36{}Style37{}Style34{}Style35{}Style32{}Footer{}Caption{AlignHorz:Center;" & _
            "ForeColor:White;BackColor:Transparent;}Style31{}Style41{}Style40{}Style29{}Norma" & _
            "l{Font:Microsoft Sans Serif, 9pt, style=Bold;BackColor:Control;AlignVert:Center;" & _
            "}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}OddRow{BackColor:Tran" & _
            "sparent;}RecordSelector{AlignImage:Center;}Heading{Wrap:True;Font:Microsoft Sans" & _
            " Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1" & _
            ", 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}Style14{}Style15{}Style30{}</Da" & _
            "ta></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=" & _
            """False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=" & _
            """17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeSt" & _
            "yle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScro" & _
            "llGroup=""1"" HorizontalScrollGroup=""1""><Height>215</Height><CaptionStyle parent=""" & _
            "Heading"" me=""Style38"" /><EditorStyle parent=""Editor"" me=""Style30"" /><EvenRowStyl" & _
            "e parent=""EvenRow"" me=""Style36"" /><FilterBarStyle parent=""FilterBar"" me=""Style41" & _
            """ /><FooterStyle parent=""Footer"" me=""Style32"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle40"" /><HeadingStyle parent=""Heading"" me=""Style31"" /><HighLightRowStyle paren" & _
            "t=""HighlightRow"" me=""Style35"" /><InactiveStyle parent=""Inactive"" me=""Style34"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style37"" /><RecordSelectorStyle parent=""RecordS" & _
            "elector"" me=""Style39"" /><SelectedStyle parent=""Selected"" me=""Style33"" /><Style p" & _
            "arent=""Normal"" me=""Style29"" /><ClientRect>0, 0, 460, 215</ClientRect><BorderSide" & _
            ">0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView>" & _
            "</Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""" & _
            "Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Cap" & _
            "tion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selec" & _
            "ted"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlight" & _
            "Row"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" " & _
            "/><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filte" & _
            "rBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSp" & _
            "lits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defa" & _
            "ultRecSelWidth><ClientArea>0, 0, 460, 215</ClientArea><PrintPageHeaderStyle pare" & _
            "nt="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'dbgDevicePreBill
            '
            Me.dbgDevicePreBill.AllowColMove = False
            Me.dbgDevicePreBill.AllowColSelect = False
            Me.dbgDevicePreBill.AllowUpdate = False
            Me.dbgDevicePreBill.AllowUpdateOnBlur = False
            Me.dbgDevicePreBill.AlternatingRows = True
            Me.dbgDevicePreBill.BackColor = System.Drawing.Color.SteelBlue
            Me.dbgDevicePreBill.ColumnFooters = True
            Me.dbgDevicePreBill.FilterBar = True
            Me.dbgDevicePreBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgDevicePreBill.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDevicePreBill.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgDevicePreBill.Location = New System.Drawing.Point(568, 280)
            Me.dbgDevicePreBill.MaintainRowCurrency = True
            Me.dbgDevicePreBill.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgDevicePreBill.Name = "dbgDevicePreBill"
            Me.dbgDevicePreBill.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDevicePreBill.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDevicePreBill.PreviewInfo.ZoomFactor = 75
            Me.dbgDevicePreBill.RowHeight = 20
            Me.dbgDevicePreBill.Size = New System.Drawing.Size(464, 219)
            Me.dbgDevicePreBill.TabIndex = 144
            Me.dbgDevicePreBill.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
            "lected{ForeColor:ControlText;BackColor:Yellow;}Style3{}Inactive{ForeColor:Inacti" & _
            "veCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Trans" & _
            "parent;}Footer{}Caption{AlignHorz:Center;ForeColor:White;BackColor:Transparent;}" & _
            "Style9{}Normal{Font:Microsoft Sans Serif, 9pt, style=Bold;BackColor:Control;Alig" & _
            "nVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{" & _
            "}OddRow{BackColor:Transparent;}RecordSelector{AlignImage:Center;}Style13{}Headin" & _
            "g{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;Align" & _
            "Vert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:LightSteelBlue;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""10"" AllowColMove=""False"" A" & _
            "llowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Colu" & _
            "mnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""Dott" & _
            "edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
            "1"" HorizontalScrollGroup=""1""><Height>215</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 460, 215</ClientRect><BorderSide>0</BorderSide><Bor" & _
            "derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
            "es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
            "arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
            "nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
            "t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
            "t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
            "ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
            "nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
            "/horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cli" & _
            "entArea>0, 0, 460, 215</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" " & _
            "/><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmSearch
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1040, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgDevicePreBill, Me.dbgModels, Me.dbgSearch})
            Me.Name = "frmSearch"
            Me.Text = "Pantech Search"
            CType(Me.dbgSearch, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgDevicePreBill, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                LoadSearchGrid()

                Me.SetScrollState(ScrollableControl.ScrollStateAutoScrolling, True)
            Catch ex As Exception
                MessageBox.Show(String.Format("An error has occurred in frmSearch_Load: {0}", ex.ToString()), "Form Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub LoadSearchGrid()
            Dim dtCustomer As DataTable = Nothing
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                Me.dbgSearch.DataSource = Nothing
                Me.dbgModels.DataSource = Nothing

                Me._dsSearch = Me._objBusSearch.GetSearchData()

                dtCustomer = Me._dsSearch.Tables("Customer Info")

                If dtCustomer.Rows.Count > 0 Then
                    With Me.dbgSearch
                        .DataSource = dtCustomer.DefaultView

                        .AllowUpdate = False

                        .Caption = "Customer Data"
                        .Splits(0).DisplayColumns("shipto_id").Visible = False

                        .RowHeight = 50 'To accommodate customer info

                        .Splits(0).DisplayColumns("shipto_id").Frozen = True
                        .Splits(0).DisplayColumns("RMA").Frozen = True

                        For Each dbgc In .Splits(0).DisplayColumns : dbgc.Locked = True : dbgc.AutoSize() : Next dbgc

                        Dim styYes As New C1.Win.C1TrueDBGrid.Style()
                        Dim fntStyYes As New Font(styYes.Font, FontStyle.Bold)

                        styYes.Font = fntStyYes
                        styYes.ForeColor = Color.Green

                        .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styYes, "Yes")

                        Dim styNo As New C1.Win.C1TrueDBGrid.Style()
                        Dim fntStyNo As New Font(styNo.Font, FontStyle.Bold)

                        styNo.Font = fntStyNo
                        styNo.ForeColor = Color.Red

                        .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styNo, "No")

                        Dim styNA As New C1.Win.C1TrueDBGrid.Style()
                        Dim fntStyNA As New Font(styNA.Font, FontStyle.Bold)

                        styNA.Font = fntStyNA
                        styNA.ForeColor = Color.DarkGoldenrod

                        .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styNA, "N/A")
                    End With

                    Misc.SetGridStyles(Me.dbgSearch, False)
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dtCustomer)
            End Try
        End Sub

        Private Sub dbgSearch_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles dbgSearch.SelChange
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
                Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

                If dbg.SelectedRows.Count > 0 Then
                    If dbg.SelectedRows(0) > -1 Then
                        Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.SelectedRows(0))
                        Dim drel As DataRelation = Me._dsSearch.Relations("Customer to Device")
                        Dim drCustomer() As DataRow = Me._dsSearch.Tables("Customer Info").Select(String.Format("RMA = '{0}'", dbgr("RMA").ToString))

                        If drCustomer.Length > 0 Then
                            Dim drModels() As DataRow = drCustomer(0).GetChildRows(drel)

                            Me.dbgDevicePreBill.DataSource = Nothing
                            Me.dbgDevicePreBill.Caption = String.Empty

                            If drModels.Length > 0 Then
                                With Me.dbgModels
                                    .DataSource = Misc.InsertDataRowsIntoDataTable(drModels, Me._dsSearch.Tables("Device Info")).DefaultView

                                    .AllowUpdate = False

                                    .Caption = String.Format("Device Data for {0}/{1}", drCustomer(0)("RMA"), drCustomer(0)("Customer"))

                                    .Splits(0).DisplayColumns("RMA").Visible = False
                                    .Splits(0).DisplayColumns("device_id").Visible = False

                                    .Splits(0).DisplayColumns("SN").Frozen = True

                                    For Each dbgc In .Splits(0).DisplayColumns : dbgc.Locked = True : dbgc.AutoSize() : Next dbgc

                                    .Columns("Labor Charge").NumberFormat = "C2"
                                    .Splits(0).DisplayColumns("Labor Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                    .Columns("Parts Charge").NumberFormat = "C2"
                                    .Splits(0).DisplayColumns("Parts Charge").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                                    .Columns("Tax on Parts").NumberFormat = "C2"
                                    .Splits(0).DisplayColumns("Tax on Parts").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                                    Dim styIW As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyIW As New Font(styIW.Font, FontStyle.Bold)

                                    styIW.Font = fntStyIW
                                    styIW.ForeColor = Color.Green

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styIW, "In")

                                    Dim styOW As New C1.Win.C1TrueDBGrid.Style()
                                    Dim fntStyOW As New Font(styOW.Font, FontStyle.Bold)

                                    styOW.Font = fntStyOW
                                    styOW.ForeColor = Color.Red

                                    .AddRegexCellStyle(C1.Win.C1TrueDBGrid.CellStyleFlag.AllCells, styOW, "Out")
                                End With

                                Misc.SetGridStyles(Me.dbgModels, False)
                            Else
                                MessageBox.Show(String.Format("There are no devices associated with {0}.", dbgr("Customer")), "No Models", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(String.Format("An error has occurred in dbgSearch_SelChange: {0}", ex.ToString()), "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub dbgModels_SelChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles dbgModels.SelChange
            Try
                SetupPrebillDisplay()
            Catch ex As Exception
                MessageBox.Show(String.Format("An error has occurred in dbgModels_SelChange: {0}", ex.ToString()), "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub SetupPrebillDisplay()
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = Me.dbgModels
                Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

                If dbg.SelectedRows.Count > 0 Then
                    If dbg.SelectedRows(0) > -1 Then
                        Dim dbgr As System.Data.DataRowView = dbg.Item(dbg.SelectedRows(0))
                        Dim drel As DataRelation = Me._dsSearch.Relations("Device to Prebill")
                        Dim drDevice() As DataRow = Me._dsSearch.Tables("Device Info").Select(String.Format("device_id = {0}", dbgr("device_id")))

                        If drDevice.Length > 0 Then
                            Dim drPrebill() As DataRow = drDevice(0).GetChildRows(drel)

                            With Me.dbgDevicePreBill
                                .DataSource = Misc.InsertDataRowsIntoDataTable(drPrebill, Me._dsSearch.Tables("Prebill Info")).DefaultView

                                .AllowUpdate = True

                                .Caption = String.Format("Prebill Data for SN {0}", drDevice(0)("SN"))

                                .Splits(0).DisplayColumns("device_id").Visible = False
                                .Splits(0).DisplayColumns("billcode_id").Visible = False

                                .Splits(0).DisplayColumns("device_id").Frozen = True
                                .Splits(0).DisplayColumns("billcode_id").Frozen = True
                                .Splits(0).DisplayColumns("Part").Frozen = True

                                For Each dbgc In .Splits(0).DisplayColumns : dbgc.Locked = True : dbgc.AutoSize() : Next dbgc

                                .Columns("Part Charge").NumberFormat = "C2"

                                .FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far

                                .Columns("Part").FooterText = "Total Part Charge"
                                .Columns("Part Charge").FooterText = String.Format("{0:C2}", Misc.SumRowValues(Me.dbgDevicePreBill, "Part Charge"))

                                .Splits(0).DisplayColumns("Part").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            End With

                            Misc.SetGridStyles(Me.dbgDevicePreBill, True)
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            Generic.DisposeDS(Me._dsSearch)

            MyBase.Finalize()
        End Sub
    End Class
End Namespace