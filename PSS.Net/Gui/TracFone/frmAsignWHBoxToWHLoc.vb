Option Explicit On 

Namespace Gui.TracFone
    Public Class frmAsignWHBoxToWHLoc
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objWH As PSS.Data.Buisness.TracFone.Warehouse

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objWH = New PSS.Data.Buisness.TracFone.Warehouse()
            _strScreenName = strScreenName
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
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtWHLoc As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtBoxName As System.Windows.Forms.TextBox
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents dbgWHBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents dbgWHBoxes2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblBoxWithoutLocation As System.Windows.Forms.Label
        Friend WithEvents lblBoxWithLocation As System.Windows.Forms.Label
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnCopySelectedRows2 As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll2 As System.Windows.Forms.Button
        Friend WithEvents btnRefreshData2 As System.Windows.Forms.Button
        Friend WithEvents chkDisplayMultipleWS As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAsignWHBoxToWHLoc))
            Me.dbgWHBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtWHLoc = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtBoxName = New System.Windows.Forms.TextBox()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            Me.dbgWHBoxes2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblBoxWithoutLocation = New System.Windows.Forms.Label()
            Me.lblBoxWithLocation = New System.Windows.Forms.Label()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnCopySelectedRows2 = New System.Windows.Forms.Button()
            Me.btnCopyAll2 = New System.Windows.Forms.Button()
            Me.btnRefreshData2 = New System.Windows.Forms.Button()
            Me.chkDisplayMultipleWS = New System.Windows.Forms.CheckBox()
            CType(Me.dbgWHBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dbgWHBoxes2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'dbgWHBoxes
            '
            Me.dbgWHBoxes.AllowUpdate = False
            Me.dbgWHBoxes.AlternatingRows = True
            Me.dbgWHBoxes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgWHBoxes.FilterBar = True
            Me.dbgWHBoxes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgWHBoxes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgWHBoxes.Location = New System.Drawing.Point(480, 112)
            Me.dbgWHBoxes.Name = "dbgWHBoxes"
            Me.dbgWHBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgWHBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgWHBoxes.PreviewInfo.ZoomFactor = 75
            Me.dbgWHBoxes.Size = New System.Drawing.Size(456, 400)
            Me.dbgWHBoxes.TabIndex = 6
            Me.dbgWHBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelB" & _
            "lue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;" & _
            "}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:" & _
            "InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}He" & _
            "ading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlTex" & _
            "t;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Cente" & _
            "r;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternat" & _
            "ingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeigh" & _
            "t=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17""" & _
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "96</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 452, 396<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 452, 396</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Yellow
            Me.Label3.Location = New System.Drawing.Point(16, 24)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(168, 16)
            Me.Label3.TabIndex = 87
            Me.Label3.Text = "Warehouse Location :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtWHLoc
            '
            Me.txtWHLoc.BackColor = System.Drawing.Color.White
            Me.txtWHLoc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWHLoc.Location = New System.Drawing.Point(16, 40)
            Me.txtWHLoc.MaxLength = 25
            Me.txtWHLoc.Name = "txtWHLoc"
            Me.txtWHLoc.Size = New System.Drawing.Size(168, 21)
            Me.txtWHLoc.TabIndex = 1
            Me.txtWHLoc.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Yellow
            Me.Label1.Location = New System.Drawing.Point(192, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 16)
            Me.Label1.TabIndex = 89
            Me.Label1.Text = "Box :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtBoxName
            '
            Me.txtBoxName.BackColor = System.Drawing.Color.White
            Me.txtBoxName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxName.Location = New System.Drawing.Point(192, 40)
            Me.txtBoxName.MaxLength = 25
            Me.txtBoxName.Name = "txtBoxName"
            Me.txtBoxName.Size = New System.Drawing.Size(216, 21)
            Me.txtBoxName.TabIndex = 2
            Me.txtBoxName.Text = ""
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopyAll.Location = New System.Drawing.Point(656, 88)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll.TabIndex = 4
            Me.btnCopyAll.Text = "Copy All Rows"
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(768, 88)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(160, 23)
            Me.btnCopySelectedRows.TabIndex = 5
            Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'dbgWHBoxes2
            '
            Me.dbgWHBoxes2.AllowUpdate = False
            Me.dbgWHBoxes2.AlternatingRows = True
            Me.dbgWHBoxes2.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dbgWHBoxes2.FilterBar = True
            Me.dbgWHBoxes2.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgWHBoxes2.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgWHBoxes2.Location = New System.Drawing.Point(8, 112)
            Me.dbgWHBoxes2.Name = "dbgWHBoxes2"
            Me.dbgWHBoxes2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgWHBoxes2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgWHBoxes2.PreviewInfo.ZoomFactor = 75
            Me.dbgWHBoxes2.Size = New System.Drawing.Size(456, 400)
            Me.dbgWHBoxes2.TabIndex = 90
            Me.dbgWHBoxes2.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
            " DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>3" & _
            "96</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edi" & _
            "tor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle " & _
            "parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gr" & _
            "oupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2" & _
            """ /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent" & _
            "=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSele" & _
            "ctorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected" & _
            """ me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 452, 396<" & _
            "/ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win." & _
            "C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Sty" & _
            "le parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style p" & _
            "arent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style pa" & _
            "rent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent" & _
            "=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style paren" & _
            "t=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style pa" & _
            "rent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyle" & _
            "s><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 452, 396</ClientArea><Pr" & _
            "intPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""" & _
            "Style21"" /></Blob>"
            '
            'lblBoxWithoutLocation
            '
            Me.lblBoxWithoutLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxWithoutLocation.ForeColor = System.Drawing.Color.White
            Me.lblBoxWithoutLocation.Location = New System.Drawing.Point(8, 96)
            Me.lblBoxWithoutLocation.Name = "lblBoxWithoutLocation"
            Me.lblBoxWithoutLocation.Size = New System.Drawing.Size(184, 24)
            Me.lblBoxWithoutLocation.TabIndex = 91
            Me.lblBoxWithoutLocation.Text = "Boxes w/o Location"
            '
            'lblBoxWithLocation
            '
            Me.lblBoxWithLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxWithLocation.ForeColor = System.Drawing.Color.White
            Me.lblBoxWithLocation.Location = New System.Drawing.Point(480, 96)
            Me.lblBoxWithLocation.Name = "lblBoxWithLocation"
            Me.lblBoxWithLocation.Size = New System.Drawing.Size(176, 24)
            Me.lblBoxWithLocation.TabIndex = 95
            Me.lblBoxWithLocation.Text = "Boxes w/ Location"
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBoxName, Me.txtWHLoc, Me.Label1, Me.Label3})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(416, 72)
            Me.GroupBox1.TabIndex = 96
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Assign a location to a box"
            '
            'btnCopySelectedRows2
            '
            Me.btnCopySelectedRows2.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopySelectedRows2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows2.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopySelectedRows2.Location = New System.Drawing.Point(296, 88)
            Me.btnCopySelectedRows2.Name = "btnCopySelectedRows2"
            Me.btnCopySelectedRows2.Size = New System.Drawing.Size(160, 23)
            Me.btnCopySelectedRows2.TabIndex = 94
            Me.btnCopySelectedRows2.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll2
            '
            Me.btnCopyAll2.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyAll2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll2.ForeColor = System.Drawing.Color.Cyan
            Me.btnCopyAll2.Location = New System.Drawing.Point(184, 88)
            Me.btnCopyAll2.Name = "btnCopyAll2"
            Me.btnCopyAll2.Size = New System.Drawing.Size(104, 23)
            Me.btnCopyAll2.TabIndex = 93
            Me.btnCopyAll2.Text = "Copy All Rows"
            '
            'btnRefreshData2
            '
            Me.btnRefreshData2.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshData2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshData2.ForeColor = System.Drawing.Color.LawnGreen
            Me.btnRefreshData2.Location = New System.Drawing.Point(432, 24)
            Me.btnRefreshData2.Name = "btnRefreshData2"
            Me.btnRefreshData2.Size = New System.Drawing.Size(120, 32)
            Me.btnRefreshData2.TabIndex = 92
            Me.btnRefreshData2.Text = "Refresh Data"
            '
            'chkDisplayMultipleWS
            '
            Me.chkDisplayMultipleWS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkDisplayMultipleWS.Location = New System.Drawing.Point(568, 32)
            Me.chkDisplayMultipleWS.Name = "chkDisplayMultipleWS"
            Me.chkDisplayMultipleWS.Size = New System.Drawing.Size(160, 24)
            Me.chkDisplayMultipleWS.TabIndex = 97
            Me.chkDisplayMultipleWS.Text = "Display MultipleWS"
            '
            'frmAsignWHBoxToWHLoc
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(952, 534)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkDisplayMultipleWS, Me.GroupBox1, Me.dbgWHBoxes, Me.lblBoxWithLocation, Me.btnCopySelectedRows2, Me.btnCopyAll2, Me.btnRefreshData2, Me.dbgWHBoxes2, Me.lblBoxWithoutLocation, Me.btnCopySelectedRows, Me.btnCopyAll})
            Me.Name = "frmAsignWHBoxToWHLoc"
            Me.Text = "frmAsignWHBoxToWHLoc"
            CType(Me.dbgWHBoxes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dbgWHBoxes2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************************************************************************
        Private Sub frmAsignWHBoxToWHLoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.chkDisplayMultipleWS.Checked = False
                'PopulateWHBoxes()
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "frmAsignWHBoxToWHLoc_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub PopulateWHBoxes()
            Dim dt, dt2 As DataTable
            Dim strAcceptedStation, strAcceptedStationArr(), strWorkstations As String
            Dim i As Integer = 0

            Dim objTFMisc As Data.Buisness.TracFone.clsMisc
            Dim strBoxName As String = ""
            Dim row, row2 As DataRow
            Dim foundRows() As DataRow
            Dim strWSs As String = "", strKeyWS As String = ""

            Try
                objTFMisc = New Data.Buisness.TracFone.clsMisc()

                strAcceptedStation = "" : strWorkstations = ""
                strAcceptedStation = Data.Buisness.Generic.GetAcceptedWorkStationInWorkFlow(Me._strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                strAcceptedStationArr = strAcceptedStation.Split("|")

                For i = 0 To strAcceptedStationArr.Length - 1
                    If strAcceptedStationArr(i).Trim.Length > 0 Then
                        If strWorkstations.Trim.Length > 0 Then strWorkstations &= ", "
                        strWorkstations &= "'" & strAcceptedStationArr(i).Trim & "'"
                    End If
                Next i

                If Me.chkDisplayMultipleWS.Checked Then
                    dt = Me._objWH.GetWHLocationBoxes(strWorkstations, False, True)
                    If dt.Rows.Count > 0 Then
                        For Each row In dt.Rows
                            strBoxName = row("BoxID") : strKeyWS = row("WorkStation") : strWSs = ""
                            dt2 = objTFMisc.GetBoxStationCount(strBoxName)
                            foundRows = dt2.Select("WorkStation <> '" & strKeyWS & "'")
                            For Each row2 In foundRows
                                If strWSs.Trim.Length = 0 Then
                                    strWSs = row2("WorkStation") & "(" & row2("Cnt") & ")"
                                Else
                                    strWSs &= ", " & row2("WorkStation") & "(" & row2("Cnt") & ")"
                                End If
                            Next
                            If strWSs.Trim.Length > 0 Then row("MultipleWS") = strWSs : dt.AcceptChanges()
                        Next
                    End If
                Else
                    dt = Me._objWH.GetWHLocationBoxes(strWorkstations, False, False)
                End If
                With Me.dbgWHBoxes
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("BoxID").Width = 160
                    .Splits(0).DisplayColumns("Qty").Width = 30
                    .Splits(0).DisplayColumns("WHLocation").Width = 50
                End With
                If dt.Rows.Count > 0 Then Me.lblBoxWithLocation.Text = "Boxes w/ Location (" & dt.Rows.Count & ")" Else Me.lblBoxWithLocation.Text = "Boxes w/ Location (0)"

                If Me.chkDisplayMultipleWS.Checked Then
                    dt = Me._objWH.GetWHLocationBoxes(strWorkstations, True, True)
                    If dt.Rows.Count > 0 Then
                        For Each row In dt.Rows
                            strBoxName = row("BoxID") : strKeyWS = row("WorkStation") : strWSs = ""
                            dt2 = objTFMisc.GetBoxStationCount(strBoxName)
                            foundRows = dt2.Select("WorkStation <> '" & strKeyWS & "'")
                            For Each row2 In foundRows
                                If strWSs.Trim.Length = 0 Then
                                    strWSs = row2("WorkStation") & "(" & row2("Cnt") & ")"
                                Else
                                    strWSs &= ", " & row2("WorkStation") & "(" & row2("Cnt") & ")"
                                End If
                            Next
                            If strWSs.Trim.Length > 0 Then row("MultipleWS") = strWSs : dt.AcceptChanges()
                        Next
                    End If
                Else
                    dt = Me._objWH.GetWHLocationBoxes(strWorkstations, True, False)
                End If
                With Me.dbgWHBoxes2
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("BoxID").Width = 160
                    .Splits(0).DisplayColumns("Qty").Width = 30
                    .Splits(0).DisplayColumns("WHLocation").Width = 50
                End With
                If dt.Rows.Count > 0 Then Me.lblBoxWithoutLocation.Text = "Boxes w/o Location (" & dt.Rows.Count & ")" Else Me.lblBoxWithoutLocation.Text = "Boxes w/o Location (0)"

            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt) : objTFMisc = Nothing
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub txtWHLoc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWHLoc.KeyUp
            Try
                If e.KeyCode = Keys.Enter And Me.txtWHLoc.Text.Trim.Length > 0 Then
                    Me.txtBoxName.SelectAll() : Me.txtBoxName.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "txtWHLoc_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub txtBoxName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxName.KeyUp
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim objTFMisc As Data.Buisness.TracFone.clsMisc
            Dim strAcceptedStation, strAcceptedStationArr() As String
            Dim booValidStation As Boolean = False

            Try
                If e.KeyCode = Keys.Enter And Me.txtBoxName.Text.Trim.Length > 0 Then
                    If Me.txtWHLoc.Text.Trim.Length = 0 Then
                        MessageBox.Show("Please enter warehouse location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    ElseIf Not Contains_BoxID(Me.txtBoxName.Text.Trim) Then
                        MessageBox.Show("Invalid BoxID '" & Me.txtBoxName.Text.Trim, "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtBoxName.Text = "" : Me.txtBoxName.Focus()
                    Else
                        objTFMisc = New Data.Buisness.TracFone.clsMisc()
                        dt = objTFMisc.GetBoxStationCount(Me.txtBoxName.Text.Trim)
                        If dt.Rows.Count > 1 Then
                            MessageBox.Show("This Box has multiple workstation.", "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtBoxName.Text = "" : Me.txtBoxName.Focus()
                        Else
                            strAcceptedStation = Data.Buisness.Generic.GetAcceptedWorkStationInWorkFlow(Me._strScreenName, PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID, )
                            strAcceptedStationArr = strAcceptedStation.Split("|")

                            For i = 0 To strAcceptedStationArr.Length - 1
                                If strAcceptedStationArr(i).Trim.Length > 0 AndAlso strAcceptedStationArr(i).Trim.ToUpper = dt.Rows(0)("WorkStation").ToString.Trim.ToUpper Then
                                    booValidStation = True
                                    Exit For
                                End If
                            Next i

                            If booValidStation = False Then
                                MessageBox.Show("Can't assign warehouse location for box in '" & dt.Rows(0)("WorkStation").ToString & "'.", "txtBoxName_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                Me.txtBoxName.Text = "" : Me.txtBoxName.Focus()
                            Else
                                i = Me._objWH.AssignWHLocation(Me.txtBoxName.Text.Trim, Me.txtWHLoc.Text.Trim.ToUpper)
                                If i > 0 Then Me.txtBoxName.Text = "" Else MessageBox.Show("System has failed to save data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "txtWHLoc_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                objTFMisc = Nothing
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub btnRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshData2.Click
            Try
                Me.PopulateWHBoxes()
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "btnRefreshData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                   Handles btnCopyAll.Click, btnCopySelectedRows.Click, btnCopyAll2.Click, btnCopySelectedRows2.Click
            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                If sender.name = "btnCopyAll" Then
                    Misc.CopyAllData(Me.dbgWHBoxes)
                ElseIf sender.name = "btnCopySelectedRows" Then
                    Misc.CopySelectedRowsData(Me.dbgWHBoxes)
                ElseIf sender.name = "btnCopyAll2" Then
                    Misc.CopyAllData(Me.dbgWHBoxes2)
                ElseIf sender.name = "btnCopySelectedRows2" Then
                    Misc.CopySelectedRowsData(Me.dbgWHBoxes2)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*********************************************************************************************************************
        Private Function Contains_BoxID(ByVal strBoxID As String) As Boolean

            Dim strDataBoxID As String
            Dim iRow As Integer
            Dim booCompleteHeader As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
            Try


                For iRow = 0 To Me.dbgWHBoxes2.RowCount - 1
                    For Each col In Me.dbgWHBoxes2.Columns
                        If Me.dbgWHBoxes2.Splits(0).DisplayColumns(col.Caption).ToString.Trim = "BoxID" Then
                            strDataBoxID = col.CellText(iRow)
                            If strDataBoxID.Trim.ToUpper = strBoxID.Trim.ToUpper Then
                                Return True
                            End If
                        End If
                    Next col
                Next iRow


                For iRow = 0 To Me.dbgWHBoxes.RowCount - 1
                    For Each col In Me.dbgWHBoxes.Columns
                        If Me.dbgWHBoxes.Splits(0).DisplayColumns(col.Caption).ToString.Trim = "BoxID" Then
                            strDataBoxID = col.CellText(iRow)
                            If strDataBoxID.Trim.ToUpper = strBoxID.Trim.ToUpper Then
                                Return True
                            End If
                        End If
                    Next col
                Next iRow

                Return False

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "Contains_BoxID", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function
        '*********************************************************************************************************************

        '*********************************************************************************************************************


    End Class
End Namespace