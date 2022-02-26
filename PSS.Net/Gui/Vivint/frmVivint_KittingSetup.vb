Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.VV
    Public Class frmVivint_KittingSetup
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        'Private _iLoc_ID As Integer = 0
        Private _strScreenName As String = ""
        Private _strRptName As String = ""
        Private _objVivint As PSS.Data.Buisness.VV.Vivint
        Private _objVivint_KitSetup As PSS.Data.Buisness.VV.Vivint_KittingSetup

        Private _dtSetupModels As DataTable
        Private _dtSetupParts As DataTable
        Private _dtModels As DataTable
        Private _dtParts As DataTable
        Private _dtParts_RV As DataTable
        Private _SelectedModel_ID As Integer = 0

        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            Me._strScreenName = strScreenName
            Me._objVivint = New PSS.Data.Buisness.VV.Vivint()
            Me._objVivint_KitSetup = New PSS.Data.Buisness.VV.Vivint_KittingSetup()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVivint = Nothing
                    Me._objVivint_KitSetup = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents tdgSetUpModels As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnDelPart As System.Windows.Forms.Button
        Friend WithEvents btnDeModel As System.Windows.Forms.Button
        Friend WithEvents btnPart As System.Windows.Forms.Button
        Friend WithEvents btnModel As System.Windows.Forms.Button
        Friend WithEvents lblSetupModelRecNum As System.Windows.Forms.Label
        Friend WithEvents tdgSetUpParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblSetupPartRecNum As System.Windows.Forms.Label
        Friend WithEvents tdgParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgModels As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblPartListForModel As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents lblQty As System.Windows.Forms.Label
        Friend WithEvents btnDelPart_RV As System.Windows.Forms.Button
        Friend WithEvents btnPart_RV As System.Windows.Forms.Button
        Friend WithEvents tdgParts_RV As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents txtQty_RV As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVivint_KittingSetup))
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.btnDelPart = New System.Windows.Forms.Button()
            Me.btnDelPart_RV = New System.Windows.Forms.Button()
            Me.btnDeModel = New System.Windows.Forms.Button()
            Me.btnPart_RV = New System.Windows.Forms.Button()
            Me.tdgParts_RV = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnPart = New System.Windows.Forms.Button()
            Me.btnModel = New System.Windows.Forms.Button()
            Me.tdgParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgModels = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgSetUpModels = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblSetupModelRecNum = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.tdgSetUpParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblSetupPartRecNum = New System.Windows.Forms.Label()
            Me.lblPartListForModel = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.lblQty = New System.Windows.Forms.Label()
            Me.txtQty_RV = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            CType(Me.tdgParts_RV, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgParts, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgSetUpModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgSetUpParts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.MidnightBlue
            Me.btnComplete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(456, 8)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(144, 32)
            Me.btnComplete.TabIndex = 244
            Me.btnComplete.Text = "Complete Setting"
            '
            'btnDelPart
            '
            Me.btnDelPart.BackColor = System.Drawing.Color.SlateGray
            Me.btnDelPart.ForeColor = System.Drawing.Color.White
            Me.btnDelPart.Location = New System.Drawing.Point(744, 240)
            Me.btnDelPart.Name = "btnDelPart"
            Me.btnDelPart.Size = New System.Drawing.Size(40, 32)
            Me.btnDelPart.TabIndex = 243
            Me.btnDelPart.Text = "Del"
            '
            'btnDelPart_RV
            '
            Me.btnDelPart_RV.BackColor = System.Drawing.Color.SlateGray
            Me.btnDelPart_RV.ForeColor = System.Drawing.Color.White
            Me.btnDelPart_RV.Location = New System.Drawing.Point(744, 376)
            Me.btnDelPart_RV.Name = "btnDelPart_RV"
            Me.btnDelPart_RV.Size = New System.Drawing.Size(40, 32)
            Me.btnDelPart_RV.TabIndex = 242
            Me.btnDelPart_RV.Text = "Del"
            '
            'btnDeModel
            '
            Me.btnDeModel.BackColor = System.Drawing.Color.SlateGray
            Me.btnDeModel.ForeColor = System.Drawing.Color.White
            Me.btnDeModel.Location = New System.Drawing.Point(744, 56)
            Me.btnDeModel.Name = "btnDeModel"
            Me.btnDeModel.Size = New System.Drawing.Size(40, 32)
            Me.btnDeModel.TabIndex = 240
            Me.btnDeModel.Text = "Del"
            '
            'btnPart_RV
            '
            Me.btnPart_RV.BackColor = System.Drawing.Color.Teal
            Me.btnPart_RV.ForeColor = System.Drawing.Color.White
            Me.btnPart_RV.Location = New System.Drawing.Point(344, 376)
            Me.btnPart_RV.Name = "btnPart_RV"
            Me.btnPart_RV.Size = New System.Drawing.Size(104, 40)
            Me.btnPart_RV.TabIndex = 239
            Me.btnPart_RV.Text = "Part RV --->"
            '
            'tdgParts_RV
            '
            Me.tdgParts_RV.AllowColMove = False
            Me.tdgParts_RV.AllowColSelect = False
            Me.tdgParts_RV.AllowFilter = False
            Me.tdgParts_RV.AllowSort = False
            Me.tdgParts_RV.AllowUpdate = False
            Me.tdgParts_RV.BackColor = System.Drawing.Color.White
            Me.tdgParts_RV.CaptionHeight = 17
            Me.tdgParts_RV.ColumnHeaders = False
            Me.tdgParts_RV.FetchRowStyles = True
            Me.tdgParts_RV.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgParts_RV.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgParts_RV.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgParts_RV.Location = New System.Drawing.Point(456, 376)
            Me.tdgParts_RV.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgParts_RV.Name = "tdgParts_RV"
            Me.tdgParts_RV.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgParts_RV.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgParts_RV.PreviewInfo.ZoomFactor = 75
            Me.tdgParts_RV.RowHeight = 15
            Me.tdgParts_RV.Size = New System.Drawing.Size(288, 120)
            Me.tdgParts_RV.TabIndex = 238
            Me.tdgParts_RV.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
            "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>116</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 284, 116</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 284, 116</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
            " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'btnPart
            '
            Me.btnPart.BackColor = System.Drawing.Color.Teal
            Me.btnPart.ForeColor = System.Drawing.Color.White
            Me.btnPart.Location = New System.Drawing.Point(344, 240)
            Me.btnPart.Name = "btnPart"
            Me.btnPart.Size = New System.Drawing.Size(104, 40)
            Me.btnPart.TabIndex = 237
            Me.btnPart.Text = "Part  --->"
            '
            'btnModel
            '
            Me.btnModel.BackColor = System.Drawing.Color.Teal
            Me.btnModel.ForeColor = System.Drawing.Color.White
            Me.btnModel.Location = New System.Drawing.Point(344, 56)
            Me.btnModel.Name = "btnModel"
            Me.btnModel.Size = New System.Drawing.Size(104, 40)
            Me.btnModel.TabIndex = 235
            Me.btnModel.Text = "Model --->"
            '
            'tdgParts
            '
            Me.tdgParts.AllowColMove = False
            Me.tdgParts.AllowColSelect = False
            Me.tdgParts.AllowFilter = False
            Me.tdgParts.AllowSort = False
            Me.tdgParts.AllowUpdate = False
            Me.tdgParts.BackColor = System.Drawing.Color.White
            Me.tdgParts.CaptionHeight = 17
            Me.tdgParts.ColumnHeaders = False
            Me.tdgParts.FetchRowStyles = True
            Me.tdgParts.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgParts.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgParts.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgParts.Location = New System.Drawing.Point(456, 240)
            Me.tdgParts.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgParts.Name = "tdgParts"
            Me.tdgParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgParts.PreviewInfo.ZoomFactor = 75
            Me.tdgParts.RowHeight = 15
            Me.tdgParts.Size = New System.Drawing.Size(288, 128)
            Me.tdgParts.TabIndex = 234
            Me.tdgParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>124</Height><CaptionStyle parent=""Style2"" " & _
            "me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""" & _
            "EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Footer" & _
            "Style parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><H" & _
            "eadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightR" & _
            "ow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pa" & _
            "rent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Sty" & _
            "le11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me" & _
            "=""Style1"" /><ClientRect>0, 0, 284, 124</ClientRect><BorderSide>0</BorderSide><Bo" & _
            "rderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedSty" & _
            "les><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style " & _
            "parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style par" & _
            "ent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style pare" & _
            "nt=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style pare" & _
            "nt=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""H" & _
            "eading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style par" & _
            "ent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1" & _
            "</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cl" & _
            "ientArea>0, 0, 284, 124</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14""" & _
            " /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tdgModels
            '
            Me.tdgModels.AllowColMove = False
            Me.tdgModels.AllowColSelect = False
            Me.tdgModels.AllowFilter = False
            Me.tdgModels.AllowSort = False
            Me.tdgModels.AllowUpdate = False
            Me.tdgModels.BackColor = System.Drawing.Color.White
            Me.tdgModels.CaptionHeight = 17
            Me.tdgModels.ColumnHeaders = False
            Me.tdgModels.FetchRowStyles = True
            Me.tdgModels.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgModels.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgModels.Location = New System.Drawing.Point(456, 56)
            Me.tdgModels.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgModels.Name = "tdgModels"
            Me.tdgModels.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgModels.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgModels.PreviewInfo.ZoomFactor = 75
            Me.tdgModels.RowHeight = 15
            Me.tdgModels.Size = New System.Drawing.Size(288, 40)
            Me.tdgModels.TabIndex = 232
            Me.tdgModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Tahoma, 8.25pt;}HighlightRow{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:" & _
            "Center;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;F" & _
            "oreColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView" & _
            " AllowColMove=""False"" AllowColSelect=""False"" Name="""" CaptionHeight=""17"" ColumnCa" & _
            "ptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""Dot" & _
            "tedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=" & _
            """1"" HorizontalScrollGroup=""1""><Height>36</Height><CaptionStyle parent=""Style2"" m" & _
            "e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
            "venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
            "tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
            "adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
            "w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
            "ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
            """Style1"" /><ClientRect>0, 0, 284, 36</ClientRect><BorderSide>0</BorderSide><Bord" & _
            "erStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyle" & _
            "s><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style pa" & _
            "rent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style paren" & _
            "t=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent" & _
            "=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style paren" & _
            "t=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</" & _
            "horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clie" & _
            "ntArea>0, 0, 284, 36</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" />" & _
            "<PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'tdgSetUpModels
            '
            Me.tdgSetUpModels.AllowUpdate = False
            Me.tdgSetUpModels.AlternatingRows = True
            Me.tdgSetUpModels.BackColor = System.Drawing.Color.White
            Me.tdgSetUpModels.FilterBar = True
            Me.tdgSetUpModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSetUpModels.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSetUpModels.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgSetUpModels.Location = New System.Drawing.Point(8, 56)
            Me.tdgSetUpModels.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgSetUpModels.Name = "tdgSetUpModels"
            Me.tdgSetUpModels.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSetUpModels.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSetUpModels.PreviewInfo.ZoomFactor = 75
            Me.tdgSetUpModels.Size = New System.Drawing.Size(330, 152)
            Me.tdgSetUpModels.TabIndex = 231
            Me.tdgSetUpModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
            "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
            "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
            "le11{}OddRow{BackColor:Lavender;}Style13{}Style12{}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}" & _
            "Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenR" & _
            "ow{BackColor:AntiqueWhite;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1," & _
            " 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{Font:Microsoft Sans S" & _
            "erif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}" & _
            "Style5{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}St" & _
            "yle7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBor" & _
            "der"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizo" & _
            "ntalScrollGroup=""1""><Height>148</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
            "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
            "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
            "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
            "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
            "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
            "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
            "/><ClientRect>0, 0, 326, 148</ClientRect><BorderSide>0</BorderSide><BorderStyle>" & _
            "Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style" & _
            " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
            "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
            "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
            """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
            """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
            "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0" & _
            ", 0, 326, 148</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintP" & _
            "ageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'lblSetupModelRecNum
            '
            Me.lblSetupModelRecNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSetupModelRecNum.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblSetupModelRecNum.Location = New System.Drawing.Point(72, 40)
            Me.lblSetupModelRecNum.Name = "lblSetupModelRecNum"
            Me.lblSetupModelRecNum.Size = New System.Drawing.Size(192, 24)
            Me.lblSetupModelRecNum.TabIndex = 262
            Me.lblSetupModelRecNum.Text = "0"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(288, 24)
            Me.Label1.TabIndex = 263
            Me.Label1.Text = "Vivint Kitting Setup"
            '
            'tdgSetUpParts
            '
            Me.tdgSetUpParts.AllowUpdate = False
            Me.tdgSetUpParts.AlternatingRows = True
            Me.tdgSetUpParts.BackColor = System.Drawing.Color.White
            Me.tdgSetUpParts.FilterBar = True
            Me.tdgSetUpParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgSetUpParts.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgSetUpParts.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgSetUpParts.Location = New System.Drawing.Point(8, 240)
            Me.tdgSetUpParts.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
            Me.tdgSetUpParts.Name = "tdgSetUpParts"
            Me.tdgSetUpParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgSetUpParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgSetUpParts.PreviewInfo.ZoomFactor = 75
            Me.tdgSetUpParts.Size = New System.Drawing.Size(330, 256)
            Me.tdgSetUpParts.TabIndex = 264
            Me.tdgSetUpParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
            "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
            "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
            "le11{}OddRow{BackColor:Lavender;}Style13{}Style12{}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}" & _
            "Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenR" & _
            "ow{BackColor:AntiqueWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, " & _
            "1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans S" & _
            "erif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}" & _
            "Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}St" & _
            "yle7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
            "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
            "Height=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBor" & _
            "der"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizo" & _
            "ntalScrollGroup=""1""><Height>252</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
            "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
            "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
            "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
            "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
            "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
            "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
            "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
            "/><ClientRect>0, 0, 326, 252</ClientRect><BorderSide>0</BorderSide><BorderStyle>" & _
            "Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style" & _
            " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
            "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
            "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
            """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
            """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
            "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0" & _
            ", 0, 326, 252</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintP" & _
            "ageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'lblSetupPartRecNum
            '
            Me.lblSetupPartRecNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSetupPartRecNum.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblSetupPartRecNum.Location = New System.Drawing.Point(8, 496)
            Me.lblSetupPartRecNum.Name = "lblSetupPartRecNum"
            Me.lblSetupPartRecNum.Size = New System.Drawing.Size(152, 24)
            Me.lblSetupPartRecNum.TabIndex = 266
            Me.lblSetupPartRecNum.Text = "0"
            '
            'lblPartListForModel
            '
            Me.lblPartListForModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPartListForModel.ForeColor = System.Drawing.Color.DarkBlue
            Me.lblPartListForModel.Location = New System.Drawing.Point(8, 224)
            Me.lblPartListForModel.Name = "lblPartListForModel"
            Me.lblPartListForModel.Size = New System.Drawing.Size(328, 24)
            Me.lblPartListForModel.TabIndex = 269
            Me.lblPartListForModel.Text = "Parts for Model"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
            Me.Label2.Location = New System.Drawing.Point(8, 40)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 24)
            Me.Label2.TabIndex = 270
            Me.Label2.Text = "Models"
            '
            'txtQty
            '
            Me.txtQty.BackColor = System.Drawing.Color.White
            Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQty.Location = New System.Drawing.Point(376, 288)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(40, 22)
            Me.txtQty.TabIndex = 271
            Me.txtQty.Text = "1"
            Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblQty
            '
            Me.lblQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQty.Location = New System.Drawing.Point(346, 290)
            Me.lblQty.Name = "lblQty"
            Me.lblQty.Size = New System.Drawing.Size(32, 24)
            Me.lblQty.TabIndex = 272
            Me.lblQty.Text = "Qty:"
            '
            'txtQty_RV
            '
            Me.txtQty_RV.BackColor = System.Drawing.Color.White
            Me.txtQty_RV.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtQty_RV.Location = New System.Drawing.Point(376, 424)
            Me.txtQty_RV.Name = "txtQty_RV"
            Me.txtQty_RV.Size = New System.Drawing.Size(40, 22)
            Me.txtQty_RV.TabIndex = 273
            Me.txtQty_RV.Text = "1"
            Me.txtQty_RV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(346, 424)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(32, 24)
            Me.Label3.TabIndex = 274
            Me.Label3.Text = "Qty:"
            '
            'frmVivint_KittingSetup
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.PowderBlue
            Me.ClientSize = New System.Drawing.Size(800, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtQty_RV, Me.Label3, Me.txtQty, Me.tdgSetUpParts, Me.lblSetupPartRecNum, Me.Label1, Me.btnComplete, Me.btnDelPart, Me.btnDelPart_RV, Me.btnDeModel, Me.btnPart_RV, Me.tdgParts_RV, Me.btnPart, Me.btnModel, Me.tdgParts, Me.tdgModels, Me.tdgSetUpModels, Me.lblSetupModelRecNum, Me.lblPartListForModel, Me.Label2, Me.lblQty})
            Me.Name = "frmVivint_KittingSetup"
            Me.Text = "frmVivint_KittingSetup"
            CType(Me.tdgParts_RV, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgParts, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgSetUpModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgSetUpParts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub frmVivint_KittingSetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                Me.tdgSetUpModels.FetchRowStyles = True     'for fetchrowevent to fire

                BindSetupModels()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmVivint_KittingSetup_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindSetupModels()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'RecID, Model_ID, Model_Desc, Model_Type, Model_MotoSku, Model_Tier, Model_Flat, Model_HexSN, Manuf_ID, Prod_ID, 
            'ProdGrp_ID(, ASCPrice_ID, RptGrp_ID, Conv_ID, Dcode_ID, Model_GSM, Accessory, UPC_Code, User_ID, UpdateDate, 
            'Weight_Factor, GoalHour, PiecesPerHour, PiecePoint, PointGoal, AutoBillFlg, Model_UnlockCode, CustomModelGroup, Model_Timestamp, 
            'Model_Volume, MRP_Status, MRP_Hide, MRP_Group, ManufModelNumber, ASN_IN_SKU, AltWrtyDateCode, Has_BC, cur_cust_dcode_id, sw_process, ks_capable, IsTriaged)

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                Me._dtSetupModels = Me._objVivint.getVivintModelData(PSS.Data.Buisness.VV.Vivint.Vivint_Product_ID, PSS.Data.Buisness.VV.Vivint.Vivint_ProductGroup_ID, True)
                Me._dtModels = Me._dtSetupModels.Clone

                Me.tdgSetUpModels.DataSource = Nothing : Me.lblSetupModelRecNum.Text = "0"

                If Me._dtSetupModels.Rows.Count > 0 Then
                    With Me.tdgSetUpModels
                        .DataSource = Me._dtSetupModels.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "RecID", "Model_ID", "Model_Desc"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        '.Splits(0).DisplayColumns("Model_Desc").Width = 300
                    End With
                    Me.lblSetupModelRecNum.Text = Me._dtSetupModels.Rows.Count
                    'Else
                    '    MessageBox.Show("No SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindSetupModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub BindSetupParts(ByVal iModel_ID As Integer, ByVal strModel_Desc As String)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'RecID, BillCode_Desc, Part_Number, PSPrice_ID, BillCode_ID, Qty, LaborLvl_ID, PSPrice_AvgCost, PSPrice_StndCost, BillCode_Rule, 
            'BillType_ID, Fail_ID, Repair_ID, ASCPrice_ID, ASCPrice_Price, Manuf_ID, Prod_ID, LaborLevel, RVFlag, PSPrice_ConsignedPart, MaxInventory

            Try

                Me._dtSetupParts = Me._objVivint_KitSetup.geMappedPartBillCodeData(iModel_ID)
                Me._dtParts = Me._dtSetupParts.Clone
                Me._dtParts_RV = Me._dtSetupParts.Clone

                Me.tdgSetUpParts.DataSource = Nothing : Me.lblSetupPartRecNum.Text = "0"
                Me.lblPartListForModel.Text = "Parts for Model " & strModel_Desc

                If Me._dtSetupParts.Rows.Count > 0 Then
                    With Me.tdgSetUpParts
                        .DataSource = Me._dtSetupParts.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "RecID", "BillCode_Desc", "Part_Number", "PSPrice_ID"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("PSPrice_ID").Width = 0
                    End With
                    Me.lblSetupPartRecNum.Text = Me._dtSetupParts.Rows.Count
                    'Else
                    '    MessageBox.Show("No SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindSetupParts", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        'Private Sub tdgSetUpModels_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdgSetUpModels.FetchCellStyle

        '    Try
        '        Me._SelectedModel_ID = Convert.ToInt32(Me.tdgSetUpModels.Columns("Model_ID").CellText(e.Row).ToString)
        '        e.CellStyle.ForeColor = Color.Blue
        '        Me.BindSetupParts(Me._SelectedModel_ID)

        '        'Select Case strYes.Trim.ToUpper
        '        '    Case "Yes".ToUpper
        '        '        e.CellStyle.ForeColor = Color.Blue
        '        '        'v = Me.tdgModelCriteria.Item(e.Row, e.Col - 1)
        '        '        'e.CellStyle.ForeColor = Color.MediumBlue
        '        '    Case "No".ToUpper
        '        '        e.CellStyle.ForeColor = Color.Red
        '        '        'v = Me.tdgModelCriteria.Item(e.Row, e.Col - 1)
        '        '        'e.CellStyle.ForeColor = Color.Black
        '        '    Case Else
        '        '        e.CellStyle.BackColor = Color.Black
        '        'End Select

        '        'Dim N As Integer
        '        ' N = Val(Me.C1TrueDBGrid1(e.Row, e.Col))
        '        'If N > 1000 Then
        '        '    e.CellStyle.ForeColor = System.Drawing.Color.Blue
        '        'End If
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "Sub tdgSetUpModels_FetchCellStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        Private Sub tdgSetUpModels_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgSetUpModels.FetchRowStyle
            Dim strModel_Desc As String = ""

            Try
                Me._SelectedModel_ID = Convert.ToInt32(Me.tdgSetUpModels.Columns("Model_ID").CellText(e.Row).ToString)
                strModel_Desc = Me.tdgSetUpModels.Columns("Model_Desc").CellText(e.Row).ToString

                ' e.CellStyle.ForeColor = Color.Blue
                Me.BindSetupParts(Me._SelectedModel_ID, strModel_Desc)

                'Select Case strYes.Trim.ToUpper
                '    Case "Yes".ToUpper
                '        e.CellStyle.ForeColor = Color.Blue
                '        'v = Me.tdgModelCriteria.Item(e.Row, e.Col - 1)
                '        'e.CellStyle.ForeColor = Color.MediumBlue
                '    Case "No".ToUpper
                '        e.CellStyle.ForeColor = Color.Red
                '        'v = Me.tdgModelCriteria.Item(e.Row, e.Col - 1)
                '        'e.CellStyle.ForeColor = Color.Black
                '    Case Else
                '        e.CellStyle.BackColor = Color.Black
                'End Select

                'Dim N As Integer
                ' N = Val(Me.C1TrueDBGrid1(e.Row, e.Col))
                'If N > 1000 Then
                '    e.CellStyle.ForeColor = System.Drawing.Color.Blue
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  tdgSetUpModels_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModel.Click
            Dim row As DataRow
            Dim iRow As Integer = 0
            Dim iModel_ID As Integer = 0

            Try
                Me.tdgSetUpModels.Enabled = True

                If Not Me.tdgSetUpModels.RowCount > 0 Then Exit Sub
                If Not Me.tdgSetUpModels.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row in the model list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Me._dtModels.Rows.Count >= 1 Then
                    MessageBox.Show("Already has 1 model (Only 1 model is allowed)!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgSetUpModels.SelectedRows 'for one selected row
                    iModel_ID = Convert.ToInt32(Me.tdgSetUpModels.Columns("Model_ID").CellText(iRow))
                    For Each row In Me._dtSetupModels.Rows
                        If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                            Me._dtModels.ImportRow(row) : Exit For
                        End If
                    Next

                    Me.BindSelectedModel(Me._dtModels)
                    Me.tdgSetUpModels.Enabled = False
                    Exit For
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  tdgSetUpModels_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindSelectedModel(ByVal dtSelected As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'RecID, Model_ID, Model_Desc, Model_Type, Model_MotoSku, Model_Tier, Model_Flat, Model_HexSN, Manuf_ID, Prod_ID, 
            'ProdGrp_ID(, ASCPrice_ID, RptGrp_ID, Conv_ID, Dcode_ID, Model_GSM, Accessory, UPC_Code, User_ID, UpdateDate, 
            'Weight_Factor, GoalHour, PiecesPerHour, PiecePoint, PointGoal, AutoBillFlg, Model_UnlockCode, CustomModelGroup, Model_Timestamp, 
            'Model_Volume, MRP_Status, MRP_Hide, MRP_Group, ManufModelNumber, ASN_IN_SKU, AltWrtyDateCode, Has_BC, cur_cust_dcode_id, sw_process, ks_capable, IsTriaged)

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                tdgModels.DataSource = Nothing

                If dtSelected.Rows.Count > 0 Then
                    With tdgModels
                        .DataSource = dtSelected.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "Model_ID", "Model_Desc"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        '.Splits(0).DisplayColumns("Model_Desc").Width = 200
                        '.Splits(0).DisplayColumns("IsKeySIM").FetchStyle = True 'for fetchcellevent to fire
                        '.Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '.Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End With

                    'Else
                    '    MessageBox.Show("No SIM card data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindSelectedModel", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub BindSelectedPart(ByVal dtSelected As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'RecID, BillCode_Desc, Part_Number, PSPrice_ID, BillCode_ID, Qty, LaborLvl_ID, PSPrice_AvgCost, PSPrice_StndCost, BillCode_Rule, 
            'BillType_ID, Fail_ID, Repair_ID, ASCPrice_ID, ASCPrice_Price, Manuf_ID, Prod_ID, LaborLevel, RVFlag, PSPrice_ConsignedPart, MaxInventory

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                tdgParts.DataSource = Nothing

                If dtSelected.Rows.Count > 0 Then
                    With tdgParts
                        .DataSource = dtSelected.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "BillCode_Desc", "Part_Number", "Qty", "PSPrice_ID"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("PSPrice_ID").Width = 0
                        '.Splits(0).DisplayColumns("IsKeySIM").FetchStyle = True 'for fetchcellevent to fire
                        '.Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '.Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End With

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindSelectedPart", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub BindSelectedPart_RV(ByVal dtSelected As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            'RecID, BillCode_Desc, Part_Number, PSPrice_ID, BillCode_ID, Qty, LaborLvl_ID, PSPrice_AvgCost, PSPrice_StndCost, BillCode_Rule, 
            'BillType_ID, Fail_ID, Repair_ID, ASCPrice_ID, ASCPrice_Price, Manuf_ID, Prod_ID, LaborLevel, RVFlag, PSPrice_ConsignedPart, MaxInventory

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                tdgParts_RV.DataSource = Nothing

                If dtSelected.Rows.Count > 0 Then
                    With tdgParts_RV
                        .DataSource = dtSelected.DefaultView
                        For Each dbgc In .Splits(0).DisplayColumns
                            dbgc.Locked = True
                            Select Case dbgc.Name
                                Case "BillCode_Desc", "Part_Number", "Qty", "PSPrice_ID"
                                    dbgc.Visible = True
                                Case Else
                                    dbgc.Visible = False
                            End Select
                            dbgc.AutoSize()
                        Next dbgc
                        .Splits(0).DisplayColumns("PSPrice_ID").Width = 0
                        '.Splits(0).DisplayColumns("IsKeySIM").FetchStyle = True 'for fetchcellevent to fire
                        '.Splits(0).DisplayColumns("IsBYOP_Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        '.Splits(0).DisplayColumns("IsBYOP_Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    End With

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindSelectedPart", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPart.Click
            Dim row As DataRow
            Dim iRow As Integer = 0
            Dim iPSPrice_ID As Integer = 0
            Dim iQty As Integer = 0

            Try
                'RecID, BillCode_Desc, Part_Number, PSPrice_ID, BillCode_ID, Qty,LaborLvl_ID, PSPrice_AvgCost, PSPrice_StndCost, BillCode_Rule, 
                'BillType_ID(, Fail_ID, Repair_ID, ASCPrice_ID, ASCPrice_Price, Manuf_ID, Prod_ID, LaborLevel, RVFlag, PSPrice_ConsignedPart, MaxInventory

                If Not Me.tdgSetUpParts.RowCount > 0 Then Exit Sub
                If Not Me.tdgSetUpParts.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row in the part list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Not Me._objVivint_KitSetup.IsPostiveInteger(Me.txtQty.Text.Trim) Then
                    MessageBox.Show("Enter a valid qty for part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                iQty = Convert.ToInt32(Me.txtQty.Text.Trim)
                If Not iQty > 0 Then
                    MessageBox.Show("Enter a valid part qty (qty>0).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgSetUpParts.SelectedRows 'for one selected row
                    iPSPrice_ID = Convert.ToInt32(Me.tdgSetUpParts.Columns("PSPrice_ID").CellText(iRow)) 'selected row
                    For Each row In Me._dtParts.Rows
                        If iPSPrice_ID = Convert.ToInt32(row("PSPrice_ID")) Then
                            MessageBox.Show("You already selected this part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Next
                    For Each row In Me._dtParts_RV.Rows
                        If iPSPrice_ID = Convert.ToInt32(row("PSPrice_ID")) Then
                            MessageBox.Show("You already selected this part in part RV box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Next
                    For Each row In Me._dtSetupParts.Rows
                        If iPSPrice_ID = Convert.ToInt32(row("PSPrice_ID")) Then
                            row.BeginEdit() : row("Qty") = iQty : row.AcceptChanges()
                            Me._dtParts.ImportRow(row) : Exit For
                        End If
                    Next

                    Me.BindSelectedPart(Me._dtParts)
                    Exit For
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  tdgSetUpModels_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnPart_RV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPart_RV.Click
            Dim row As DataRow
            Dim iRow As Integer = 0
            Dim iPSPrice_ID As Integer = 0
            Dim iQty As Integer = 0

            Try
                'RecID, BillCode_Desc, Part_Number, PSPrice_ID, BillCode_ID, Qty,LaborLvl_ID, PSPrice_AvgCost, PSPrice_StndCost, BillCode_Rule, 
                'BillType_ID(, Fail_ID, Repair_ID, ASCPrice_ID, ASCPrice_Price, Manuf_ID, Prod_ID, LaborLevel, RVFlag, PSPrice_ConsignedPart, MaxInventory

                If Not Me.tdgSetUpParts.RowCount > 0 Then Exit Sub
                If Not Me.tdgSetUpParts.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a row in the part list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Not Me._objVivint_KitSetup.IsPostiveInteger(Me.txtQty_RV.Text.Trim) Then
                    MessageBox.Show("Enter a valid qty for Part RV.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                iQty = Convert.ToInt32(Me.txtQty_RV.Text.Trim)
                If Not iQty > 0 Then
                    MessageBox.Show("Enter a valid part RV qty (qty>0).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgSetUpParts.SelectedRows 'for one selected row
                    iPSPrice_ID = Convert.ToInt32(Me.tdgSetUpParts.Columns("PSPrice_ID").CellText(iRow)) 'selected row
                    For Each row In Me._dtParts.Rows
                        If iPSPrice_ID = Convert.ToInt32(row("PSPrice_ID")) Then
                            MessageBox.Show("You already selected this part in part box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Next
                    For Each row In Me._dtParts_RV.Rows
                        If iPSPrice_ID = Convert.ToInt32(row("PSPrice_ID")) Then
                            MessageBox.Show("You already selected this part in part RV box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Exit Sub
                        End If
                    Next
                    For Each row In Me._dtSetupParts.Rows
                        If iPSPrice_ID = Convert.ToInt32(row("PSPrice_ID")) Then
                            row.BeginEdit() : row("Qty") = iQty : row.AcceptChanges()
                            Me._dtParts_RV.ImportRow(row) : Exit For
                        End If
                    Next

                    Me.BindSelectedPart_RV(Me._dtParts_RV)
                    Exit For
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  btnPart_RV_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDeModel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeModel.Click
            Dim iModel_ID As Integer = 0
            Dim iRow As Integer = 0
            Dim row As DataRow

            Try
                If Not Me.tdgModels.RowCount > 0 Then Exit Sub
                If Not Me.tdgModels.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a model row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgModels.SelectedRows  'for one selected row
                    iModel_ID = Convert.ToInt32(Me.tdgModels.Columns("Model_ID").CellText(iRow))
                    For Each row In Me._dtModels.Rows
                        If iModel_ID = Convert.ToInt32(row("Model_ID")) Then
                            row.Delete() : Exit For
                        End If
                    Next
                    Me._dtModels.AcceptChanges()
                    Me.BindSelectedModel(Me._dtModels)
                    Me.tdgSetUpModels.Enabled = True
                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  btnDeModel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelPart.Click
            Dim iPsPrice_ID As Integer = 0
            Dim iRow As Integer = 0
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                If Not Me.tdgParts.RowCount > 0 Then Exit Sub
                If Not Me.tdgParts.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a part row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgParts.SelectedRows  'for one selected row
                    iPsPrice_ID = Convert.ToInt32(Me.tdgParts.Columns("PsPrice_ID").CellText(iRow))
                    'delete
                    For Each row In Me._dtParts.Rows
                        If iPsPrice_ID = Convert.ToInt32(row("PsPrice_ID")) Then
                            row.Delete() : Exit For
                        End If
                    Next
                    Me._dtParts.AcceptChanges()
                    'reorder RecID after del

                    For Each row In Me._dtParts.Rows
                        i += 1
                        row.EndEdit() : row("RecID") = i : row.AcceptChanges()
                    Next

                    Me.BindSelectedPart(Me._dtParts)
                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnDelPart_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnDelPart_RV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelPart_RV.Click
            Dim iPsPrice_ID As Integer = 0
            Dim iRow As Integer = 0
            Dim row As DataRow
            Dim i As Integer = 0

            Try
                If Not Me.tdgParts_RV.RowCount > 0 Then Exit Sub
                If Not Me.tdgParts_RV.SelectedRows.Count = 1 Then
                    MessageBox.Show("Please select a part row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                For Each iRow In Me.tdgParts_RV.SelectedRows  'for one selected row
                    iPsPrice_ID = Convert.ToInt32(Me.tdgParts_RV.Columns("PsPrice_ID").CellText(iRow))
                    'delete
                    For Each row In Me._dtParts_RV.Rows
                        If iPsPrice_ID = Convert.ToInt32(row("PsPrice_ID")) Then
                            row.Delete() : Exit For
                        End If
                    Next
                    Me._dtParts_RV.AcceptChanges()
                    'reorder RecID after del

                    For Each row In Me._dtParts_RV.Rows
                        i += 1
                        row.EndEdit() : row("RecID") = i : row.AcceptChanges()
                    Next

                    Me.BindSelectedPart_RV(Me._dtParts_RV)
                    Exit For
                Next
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnDelPart_RV_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnComplete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim strKitSetName As String = "VV_KitSet_" & Format(Now, "yyyyMMddHHmmss")
            Dim i As Integer = 0

            Try

                If Not (Me.tdgParts.RowCount + Me.tdgParts_RV.RowCount) > 0 AndAlso Not Me.tdgModels.RowCount > 0 Then
                    MessageBox.Show("A model and part(s) or part RV(s) must be selected before you can complete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not Me.tdgModels.RowCount > 0 Then
                    MessageBox.Show("A model must be selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf Not (Me.tdgParts.RowCount + Me.tdgParts_RV.RowCount) > 0 Then
                    MessageBox.Show("Part(s) or part RV(s) must be selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If Not Me._dtModels.Rows.Count = 1 Then
                    MessageBox.Show("Model data must be 1 row.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Not (Me._dtParts.Rows.Count + Me._dtParts_RV.Rows.Count) > 0 Then
                    MessageBox.Show("Part or part RV data can't be nothing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                'ready to save
                i = Me._objVivint_KitSetup.SaveKittingSetData(strKitSetName, Me._dtModels.Rows(0).Item("Model_ID"), Me._iUserID, strDateTime, Me._iCust_ID, Me._dtParts, Me._dtParts_RV)

                Me._dtModels.Rows.Clear() : Me._dtParts.Rows.Clear() : Me._dtParts_RV.Rows.Clear()
                Me.tdgModels.DataSource = Nothing : Me.tdgParts.DataSource = Nothing : Me.tdgParts_RV.DataSource = Nothing
                Me.tdgSetUpModels.Enabled = True

                MessageBox.Show("Completed!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.tdgModels.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


    End Class
End Namespace