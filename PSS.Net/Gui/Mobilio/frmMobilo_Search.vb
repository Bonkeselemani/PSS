Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui

    Public Class frmMobilo_Search
        Inherits System.Windows.Forms.Form

        Private _iSearchID As Integer
        Private _objMSearch As Mobilio_Reports
        Private dtGrid, grid As DataTable


#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iSearchID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objMSearch = New Mobilio_Reports()
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
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents cboSearchType As System.Windows.Forms.ComboBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dbgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtSearhValue As System.Windows.Forms.TextBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents dbgMain As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dbgDetail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMobilo_Search))
            Me.dbgData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.txtSearhValue = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cboSearchType = New System.Windows.Forms.ComboBox()
            Me.dbgMain = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.dbgDetail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.dbgData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.dbgMain, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dbgData
            '
            Me.dbgData.AllowUpdate = False
            Me.dbgData.AlternatingRows = True
            Me.dbgData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgData.FilterBar = True
            Me.dbgData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgData.Location = New System.Drawing.Point(208, 8)
            Me.dbgData.Name = "dbgData"
            Me.dbgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgData.PreviewInfo.ZoomFactor = 75
            Me.dbgData.Size = New System.Drawing.Size(648, 424)
            Me.dbgData.TabIndex = 7
            Me.dbgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>4" & _
            "20</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 644, 420<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 644, 420</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'Panel1
            '
            Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSearch, Me.txtSearhValue, Me.Label1, Me.Label5, Me.cboSearchType})
            Me.Panel1.Location = New System.Drawing.Point(8, 8)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(200, 424)
            Me.Panel1.TabIndex = 8
            '
            'btnSearch
            '
            Me.btnSearch.ForeColor = System.Drawing.SystemColors.ControlLight
            Me.btnSearch.Location = New System.Drawing.Point(56, 152)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 89
            Me.btnSearch.Text = "Search"
            '
            'txtSearhValue
            '
            Me.txtSearhValue.BackColor = System.Drawing.Color.White
            Me.txtSearhValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSearhValue.Location = New System.Drawing.Point(8, 96)
            Me.txtSearhValue.MaxLength = 25
            Me.txtSearhValue.Name = "txtSearhValue"
            Me.txtSearhValue.Size = New System.Drawing.Size(176, 21)
            Me.txtSearhValue.TabIndex = 88
            Me.txtSearhValue.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 72)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(192, 21)
            Me.Label1.TabIndex = 87
            Me.Label1.Text = "Search Value"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(8, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(192, 21)
            Me.Label5.TabIndex = 86
            Me.Label5.Text = "Search Type"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'cboSearchType
            '
            Me.cboSearchType.ItemHeight = 13
            Me.cboSearchType.Items.AddRange(New Object() {"Device ID", "EsnImei", "Master Pack ID", "Order#/PO", "Tote ID", "Discrepancy Template"})
            Me.cboSearchType.Location = New System.Drawing.Point(8, 32)
            Me.cboSearchType.MaxDropDownItems = 25
            Me.cboSearchType.Name = "cboSearchType"
            Me.cboSearchType.Size = New System.Drawing.Size(176, 21)
            Me.cboSearchType.TabIndex = 1
            '
            'dbgMain
            '
            Me.dbgMain.AlternatingRows = True
            Me.dbgMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgMain.CaptionHeight = 17
            Me.dbgMain.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.dbgMain.DirectionAfterEnter = C1.Win.C1TrueDBGrid.DirectionAfterEnterEnum.MoveDown
            Me.dbgMain.FilterBar = True
            Me.dbgMain.GroupByCaption = ""
            Me.dbgMain.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgMain.Location = New System.Drawing.Point(216, 8)
            Me.dbgMain.Name = "dbgMain"
            Me.dbgMain.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgMain.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgMain.PreviewInfo.ZoomFactor = 75
            Me.dbgMain.RowHeight = 15
            Me.dbgMain.Size = New System.Drawing.Size(632, 408)
            Me.dbgMain.SpringMode = True
            Me.dbgMain.TabIndex = 9
            Me.dbgMain.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:LightSkyBlue;}Selected{ForeColor:HighlightText" & _
            ";BackColor:Highlight;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1" & _
            ", 1;ForeColor:ControlText;AlignVert:Center;}Inactive{ForeColor:InactiveCaptionTe" & _
            "xt;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;}Style" & _
            "20{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Normal{Font:Verdan" & _
            "a, 8.25pt;}Style26{}Style25{}Style24{}Style23{AlignHorz:Near;}Style22{}Style21{}" & _
            "OddRow{}RecordSelector{AlignImage:Center;}Style18{}Style19{}Style2{}Style14{}Sty" & _
            "le15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Gro" & _
            "upByView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder""" & _
            " RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizontal" & _
            "ScrollGroup=""1"" SpringMode=""True""><Height>360</Height><CaptionStyle parent=""Head" & _
            "ing"" me=""Style23"" /><EditorStyle parent=""Editor"" me=""Style15"" /><EvenRowStyle pa" & _
            "rent=""EvenRow"" me=""Style21"" /><FilterBarStyle parent=""FilterBar"" me=""Style26"" />" & _
            "<FooterStyle parent=""Footer"" me=""Style17"" /><GroupStyle parent=""Group"" me=""Style" & _
            "25"" /><HeadingStyle parent=""Heading"" me=""Style16"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style20"" /><InactiveStyle parent=""Inactive"" me=""Style19"" /><Odd" & _
            "RowStyle parent=""OddRow"" me=""Style22"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style24"" /><SelectedStyle parent=""Selected"" me=""Style18"" /><Style paren" & _
            "t=""Normal"" me=""Style14"" /><ClientRect>0, 29, 630, 360</ClientRect><BorderSide>0<" & _
            "/BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.GroupByView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 630, 406</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style1"" /><PrintPageFooterStyle parent="""" me=""Style2"" /></Blob>"
            '
            'dbgDetail
            '
            Me.dbgDetail.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgDetail.Caption = "Device Information"
            Me.dbgDetail.CaptionHeight = 17
            Me.dbgDetail.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDetail.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dbgDetail.Location = New System.Drawing.Point(8, 440)
            Me.dbgDetail.Name = "dbgDetail"
            Me.dbgDetail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDetail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDetail.PreviewInfo.ZoomFactor = 75
            Me.dbgDetail.RowHeight = 15
            Me.dbgDetail.Size = New System.Drawing.Size(856, 104)
            Me.dbgDetail.TabIndex = 10
            Me.dbgDetail.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Verdana, 8.25pt;}HighlightRow{ForeColor:HighlightText;Ba" & _
            "ckColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center;}Style15{}H" & _
            "eading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}" & _
            "Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHe" & _
            "ight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedC" & _
            "ellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" " & _
            "HorizontalScrollGroup=""1""><Height>85</Height><CaptionStyle parent=""Style2"" me=""S" & _
            "tyle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenR" & _
            "ow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle" & _
            " parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Headin" & _
            "gStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" m" & _
            "e=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=" & _
            """OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11""" & _
            " /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Sty" & _
            "le1"" /><ClientRect>0, 17, 854, 85</ClientRect><BorderSide>0</BorderSide><BorderS" & _
            "tyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><" & _
            "Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style paren" & _
            "t=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""" & _
            "Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""N" & _
            "ormal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""N" & _
            "ormal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headin" & _
            "g"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""" & _
            "Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</hor" & _
            "zSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientA" & _
            "rea>0, 0, 854, 102</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><P" & _
            "rintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'frmMobilo_Search
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(896, 558)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgDetail, Me.dbgMain, Me.Panel1, Me.dbgData})
            Me.Name = "frmMobilo_Search"
            Me.Text = "frmMobilo_Search"
            CType(Me.dbgData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.dbgMain, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgDetail, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        
            MainWin.StatusBar.SetStatusText("Searching...")

            Dim _searchType As String
            Dim _searchValue As String
            Me.dbgDetail.DataSource = Nothing

            Try
                'If cboSearchType.SelectionLength = 0 Then
                '    MsgBox("You must select a search type", MsgBoxStyle.Exclamation, "Search Error")

                '    Exit Sub
                'End If

                If txtSearhValue.Text = "" Then
                    MsgBox("You must enter a search value.", MsgBoxStyle.Exclamation, "Search Error")
                    Me.txtSearhValue.Text = ""
                    Me.txtSearhValue.Focus()
                    Exit Sub
                End If

                LoadSearchResult()


            Catch ex As Exception
                MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadSearchResult()
            Dim dt As DataTable
            Dim _searchType As String
            Dim index As Long = 0

            Try

                Select Case Me.cboSearchType.SelectedIndex

                    Case 0
                        _searchType = "Device ID"
                        Me.dbgMain.DataSource = Me._objMSearch.Get_Device_ID(Me.txtSearhValue.Text)

                    Case 1
                        _searchType = "EsnImei"
                        Me.dbgMain.DataSource = Me._objMSearch.Get_EsnImei(Me.txtSearhValue.Text)

                    Case 2
                        _searchType = "Master Pack ID"
                        Me.dbgMain.DataSource = Me._objMSearch.Get_Master_Pack(Me.txtSearhValue.Text)

                    Case 3
                        _searchType = "Order#/PO"
                        Me.dbgMain.DataSource = Me._objMSearch.Get_OrderPO(Me.txtSearhValue.Text)

                    Case 4
                        _searchType = "Tote ID"
                        Me.dbgMain.DataSource = Me._objMSearch.Get_Tote_ID(Me.txtSearhValue.Text)

                    Case 5
                        _searchType = "Discrepancy Template"
                        Me.dbgMain.DataSource = Me._objMSearch.Get_Discrepant_Template_ID(Me.txtSearhValue.Text)

                    Case Else
                        MsgBox("You must select a search type", MsgBoxStyle.Exclamation, "Search Error")
                        Exit Select
                End Select

                MainWin.StatusBar.SetStatusText("Ready")

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub txtSearhValue_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearhValue.KeyDown
            Me.dbgDetail.DataSource = Nothing
            Me.dbgMain.DataSource = Nothing
            If e.KeyCode = Keys.Enter Then
                If txtSearhValue.Text.Length > 0 Then
                    Me.btnSearch_Click(Me, EventArgs.Empty)
                End If
            End If
        End Sub

        Private Sub txtSearhValue_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSearhValue.MouseUp
            Me.dbgDetail.DataSource = Nothing
            Me.dbgMain.DataSource = Nothing

        End Sub

        Private Sub cboSearchType_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboSearchType.KeyDown
            Me.dbgDetail.DataSource = Nothing
            Me.dbgMain.DataSource = Nothing

        End Sub

        Private Sub cboSearchType_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboSearchType.MouseUp
            Me.dbgDetail.DataSource = Nothing
            Me.dbgMain.DataSource = Nothing

        End Sub

        Private Sub dbgMain_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgMain.RowColChange
            Dim i As Integer = 0

            Try
                'For i = 0 To Me.dbgMain.Columns.Count - 1
                '    'check if Device ID existed then continue else exit sub
                '    'if 
                'Next

                'Me.dbgDetail.DataSource = PSS.Rules.Search.GetDevice(Trim(Me.dbgMain.Columns("Device_ID").Text))
                'If PSS.Core.ApplicationUser.GetPermission(Me.GetType.Name) < 2 Then
                '    'Me.dbgDetail.Splits(0).DisplayColumns(4).Visible = False
                '    Me.dbgDetail.Splits(0).AllowColMove = False
                'End If

            Catch ex As Exception
                Me.dbgDetail.DataSource = Nothing

            End Try
        End Sub

        'Private Sub dbgMain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgMain.Click

        '    Dim _searchType As String
        '    Dim strSelectRow As String = ""
        '    Dim strSelectRow1 As String = ""
        '  

        '    Try
        '   
        '            Select Case Me.cboSearchType.SelectedIndex

        '                Case 0
        '                    _searchType = "Device ID"
        '                    'strSelectRow = Me.dbgMain.Columns("DeviceID").Value.ToString 'CellValue(Me.dbgMain.Row)
        '                    Me.dbgDetail.DataSource = Me._objMSearch.Get_Device_ASNID(Me.txtSearhValue.Text)
        '               

        '                Case 1
        '                    _searchType = "EsnImei"
        '                    'strSelectRow = Me.dbgMain.Columns("Device ID").CellValue(Me.dbgMain.Row)
        '                    Me.dbgDetail.DataSource = Me._objMSearch.Get_EsnImei_ASN(Me.txtSearhValue.Text)
        '                 
        '                Case 2
        '                    _searchType = "Master Pack ID"
        '                    strSelectRow = Me.dbgMain.Columns("ESN/IMEI").CellValue(Me.dbgMain.Row)
        '                    Me.dbgDetail.DataSource = Me._objMSearch.Get_Master_Pack_ASN(Me.txtSearhValue.Text, strSelectRow)
        '           

        '                Case 3
        '                    _searchType = "Order#/PO"
        '                    strSelectRow = Me.dbgMain.Columns("Device ID").CellValue(Me.dbgMain.Row)
        '                    Me.dbgDetail.DataSource = Me._objMSearch.Get_Order_ASNID(strSelectRow)
        '                  

        '                Case 4
        '                    _searchType = "Tote ID"
        '                    strSelectRow = Me.dbgMain.Columns("Device ID").CellValue(Me.dbgMain.Row)
        '                    Me.dbgDetail.DataSource = Me._objMSearch.Get_Tote_ASNID(Me.txtSearhValue.Text, strSelectRow)
        '                  
        '                Case 5
        '                    _searchType = "Discrepancy Template"
        '                    strSelectRow = Me.dbgMain.Columns("mb_DeviceID").CellValue(Me.dbgMain.Row)
        '                    strSelectRow1 = Me.dbgMain.Columns("DCP_Detail_ID").CellValue(Me.dbgMain.Row)

        '                    Me.dbgDetail.DataSource = Me._objMSearch.Get_Discrepant_Template_ASNID(strSelectRow, strSelectRow1)
        '                   

        '                Case Else
        '                    MsgBox("You must select a search type", MsgBoxStyle.Exclamation, "Search Error")
        '                    Exit Select
        '            End Select
        '      

        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message, "dbgMain_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    Finally
        '        Me.Enabled = True : Cursor.Current = Cursors.Default
        '    End Try
        'End Sub

        Private Sub dbgMain_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgMain.MouseUp
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return
                LoadSearchDeviceResult()


                If e.Button = MouseButtons.Right Then
                    Dim ctmCopyData As New ContextMenu()
                    'Dim objCopyAll As New MenuItem()
                    Dim objCopySelected As New MenuItem()

                    'objCopyAll.Text = "Copy all grid data to the clipboard."
                    objCopySelected.Text = "Copy selected rows to the clipboard."

                    'ctmCopyData.MenuItems.Add(objCopyAll)
                    ctmCopyData.MenuItems.Add(objCopySelected)

                    'RemoveHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    'AddHandler objCopyAll.Click, AddressOf CMenuCopyAllData
                    RemoveHandler objCopySelected.Click, AddressOf CMenuCopySelectedData
                    AddHandler objCopySelected.Click, AddressOf CMenuCopySelectedData

                    dbg.ContextMenu = ctmCopyData
                    dbg.ContextMenu.Show(dbg, New Point(e.X, e.Y))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgMain_MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        '    Private Sub CMenuCopyAllData(ByVal sender As Object, ByVal e As System.EventArgs)
        '        Try
        '            Misc.CopyAllData(Me.dbgMain)
        '        Catch ex As Exception
        '            MessageBox.Show(ex.ToString, "CMenuCopyData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        '        End Try
        '    End Sub

        Private Sub CMenuCopySelectedData(ByVal sender As Object, ByVal e As System.EventArgs)
            Try
                Misc.CopySelectedRowsData(Me.dbgMain)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CMenuCopySelectedData", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub

        Private Sub dbgMain_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dbgMain.KeyUp
            Try
                Dim dbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = DirectCast(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)

                If dbg.RowCount = 0 Then Return
                LoadSearchDeviceResult()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgMain_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        End Sub
        Private Sub LoadSearchDeviceResult()
            Dim dt As DataTable
            Dim _searchType As String
            Dim strSelectRow As String = ""

            Try
                Select Case Me.cboSearchType.SelectedIndex

                    Case 0
                        _searchType = "Device ID"
                        strSelectRow = Me.dbgMain.Columns("Device ID").CellValue(Me.dbgMain.Row)
                        Me.dbgDetail.DataSource = Me._objMSearch.Get_Device_ASNID(strSelectRow)

                    Case 1
                        _searchType = "EsnImei"
                        strSelectRow = Me.dbgMain.Columns("Device ID").CellValue(Me.dbgMain.Row)
                        Me.dbgDetail.DataSource = Me._objMSearch.Get_EsnImei_ASN(strSelectRow)

                    Case 2
                        _searchType = "Master Pack ID"
                        strSelectRow = Me.dbgMain.Columns("Device ID").CellValue(Me.dbgMain.Row)
                        Me.dbgDetail.DataSource = Me._objMSearch.Get_Master_Pack_ASN(strSelectRow)

                    Case 3
                        _searchType = "Order#/PO"
                        strSelectRow = Me.dbgMain.Columns("Device ID").CellValue(Me.dbgMain.Row)
                        If strSelectRow > 0 Then
                            Me.dbgDetail.DataSource = Me._objMSearch.Get_OrderPO_Device_ASN(strSelectRow)
                        Else
                            strSelectRow = Me.dbgMain.Columns("PO Number").CellValue(Me.dbgMain.Row)
                            Me.dbgDetail.DataSource = Me._objMSearch.Get_OrderPO_ASN(strSelectRow)
                        End If

                    Case 4
                            _searchType = "Tote ID"
                            strSelectRow = Me.dbgMain.Columns("Device ID").CellValue(Me.dbgMain.Row)
                        If strSelectRow > 0 Then
                            Me.dbgDetail.DataSource = Me._objMSearch.Get_Tote_Device_ASNID(strSelectRow)
                        Else
                            strSelectRow = Me.dbgMain.Columns("Tote ID").CellValue(Me.dbgMain.Row)
                            Me.dbgDetail.DataSource = Me._objMSearch.Get_Tote_ASNID(strSelectRow)
                        End If


                    Case 5
                            _searchType = "Discrepancy Template"
                            'strSelectRow = Me.dbgMain.Columns("mb_DeviceID").CellValue(Me.dbgMain.Row)
                            strSelectRow = Me.dbgMain.Columns("DCP_Detail_ID").CellValue(Me.dbgMain.Row)

                            Me.dbgDetail.DataSource = Me._objMSearch.Get_Discrepant_Template_ASNID(strSelectRow)

                    Case Else
                            MsgBox("You must select a search type", MsgBoxStyle.Exclamation, "Search Error")
                            Exit Select
                End Select
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub
    End Class

End Namespace