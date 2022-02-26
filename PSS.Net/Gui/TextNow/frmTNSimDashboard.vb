Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TextNow

	Public Class frmTNSimDashboard
		Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = TN.CUSTOMERID
        Private _objTN As TN
        Private _dtInventoryDetails As New DataTable()
        Private _dsAllFilledOpenDetails As New DataSet()
        Private _strDataSnapshotDateTime As String = ""

#Region " Windows Form Designer generated code "

		Public Sub New()
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
            Me._objTN = New TN()
            Me.lblResult.Text = ""
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
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents dtp_start_date As System.Windows.Forms.DateTimePicker
		Friend WithEvents dtp_end_date As System.Windows.Forms.DateTimePicker
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents tdgInventory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblResult As System.Windows.Forms.Label
        Friend WithEvents tdgAllOrder As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgOpenOrder As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents tdgFilledOrder As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTNSimDashboard))
            Me.dtp_start_date = New System.Windows.Forms.DateTimePicker()
            Me.dtp_end_date = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.tdgInventory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblResult = New System.Windows.Forms.Label()
            Me.tdgAllOrder = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgOpenOrder = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.tdgFilledOrder = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            CType(Me.tdgInventory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgAllOrder, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgOpenOrder, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgFilledOrder, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'dtp_start_date
            '
            Me.dtp_start_date.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtp_start_date.Location = New System.Drawing.Point(112, 56)
            Me.dtp_start_date.Name = "dtp_start_date"
            Me.dtp_start_date.Size = New System.Drawing.Size(104, 20)
            Me.dtp_start_date.TabIndex = 0
            '
            'dtp_end_date
            '
            Me.dtp_end_date.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtp_end_date.Location = New System.Drawing.Point(112, 96)
            Me.dtp_end_date.Name = "dtp_end_date"
            Me.dtp_end_date.Size = New System.Drawing.Size(104, 20)
            Me.dtp_end_date.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(16, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 23)
            Me.Label1.TabIndex = 8
            Me.Label1.Text = "Starting Date:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(16, 96)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 23)
            Me.Label2.TabIndex = 9
            Me.Label2.Text = "Ending Date:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'btnSearch
            '
            Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSearch.Location = New System.Drawing.Point(112, 128)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(104, 40)
            Me.btnSearch.TabIndex = 22
            Me.btnSearch.Text = "Get Data"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Blue
            Me.Label4.Location = New System.Drawing.Point(16, 16)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(224, 40)
            Me.Label4.TabIndex = 25
            Me.Label4.Text = "Select Order Received Dates"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tdgInventory
            '
            Me.tdgInventory.AllowArrows = False
            Me.tdgInventory.AllowColMove = False
            Me.tdgInventory.AllowColSelect = False
            Me.tdgInventory.AllowFilter = False
            Me.tdgInventory.AllowRowSelect = False
            Me.tdgInventory.AllowSort = False
            Me.tdgInventory.AllowUpdate = False
            Me.tdgInventory.AlternatingRows = True
            Me.tdgInventory.BackColor = System.Drawing.Color.White
            Me.tdgInventory.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tdgInventory.Caption = "SIM Card Inventory"
            Me.tdgInventory.FetchRowStyles = True
            Me.tdgInventory.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.tdgInventory.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgInventory.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgInventory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgInventory.Location = New System.Drawing.Point(248, 8)
            Me.tdgInventory.Name = "tdgInventory"
            Me.tdgInventory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgInventory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgInventory.PreviewInfo.ZoomFactor = 75
            Me.tdgInventory.RowSubDividerColor = System.Drawing.Color.LightBlue
            Me.tdgInventory.Size = New System.Drawing.Size(368, 184)
            Me.tdgInventory.TabIndex = 178
            Me.tdgInventory.Text = "C1TrueDBGrid1"
            Me.tdgInventory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
            "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
            "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{Font:" & _
            "Arial, 8.25pt, style=Bold;}Caption{Font:Arial, 8.25pt, style=Bold;AlignHorz:Cent" & _
            "er;ForeColor:White;BackColor:Sienna;}Style9{}Normal{Font:Arial, 8.25pt;}Highligh" & _
            "tRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelecto" & _
            "r{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Flat,Con" & _
            "trolDark,1, 1, 1, 1;ForeColor:ControlText;BackColor:LightSteelBlue;}Style8{}Styl" & _
            "e10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits><" & _
            "C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" AllowR" & _
            "owSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCap" & _
            "tionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBorderStyle=" & _
            """Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""" & _
            "17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>167</Height><Capti" & _
            "onStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" " & _
            "/><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar" & _
            """ me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""" & _
            "Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRow" & _
            "Style parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""S" & _
            "tyle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=" & _
            """RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><" & _
            "Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 368, 167</ClientRect><Bor" & _
            "derSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Mer" & _
            "geView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norma" & _
            "l"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" " & _
            "me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me" & _
            "=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hi" & _
            "ghlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""O" & _
            "ddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me" & _
            "=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1<" & _
            "/vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>1" & _
            "7</DefaultRecSelWidth><ClientArea>0, 0, 368, 184</ClientArea><PrintPageHeaderSty" & _
            "le parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blo" & _
            "b>"
            '
            'lblResult
            '
            Me.lblResult.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblResult.Location = New System.Drawing.Point(32, 204)
            Me.lblResult.Name = "lblResult"
            Me.lblResult.Size = New System.Drawing.Size(584, 16)
            Me.lblResult.TabIndex = 179
            Me.lblResult.Text = "SIM Card Result for date range: "
            Me.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'tdgAllOrder
            '
            Me.tdgAllOrder.AllowArrows = False
            Me.tdgAllOrder.AllowColMove = False
            Me.tdgAllOrder.AllowColSelect = False
            Me.tdgAllOrder.AllowFilter = False
            Me.tdgAllOrder.AllowRowSelect = False
            Me.tdgAllOrder.AllowSort = False
            Me.tdgAllOrder.AllowUpdate = False
            Me.tdgAllOrder.AlternatingRows = True
            Me.tdgAllOrder.BackColor = System.Drawing.Color.White
            Me.tdgAllOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tdgAllOrder.Caption = "All Orders"
            Me.tdgAllOrder.FetchRowStyles = True
            Me.tdgAllOrder.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.tdgAllOrder.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgAllOrder.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgAllOrder.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgAllOrder.Location = New System.Drawing.Point(24, 224)
            Me.tdgAllOrder.Name = "tdgAllOrder"
            Me.tdgAllOrder.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgAllOrder.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgAllOrder.PreviewInfo.ZoomFactor = 75
            Me.tdgAllOrder.RowSubDividerColor = System.Drawing.Color.LightBlue
            Me.tdgAllOrder.Size = New System.Drawing.Size(192, 184)
            Me.tdgAllOrder.TabIndex = 180
            Me.tdgAllOrder.Text = "C1TrueDBGrid1"
            Me.tdgAllOrder.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
            "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
            "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{Font:" & _
            "Arial, 8.25pt, style=Bold;}Caption{Font:Arial, 8.25pt, style=Bold;AlignHorz:Cent" & _
            "er;ForeColor:White;BackColor:SteelBlue;}Style1{}Normal{Font:Arial, 8.25pt;}Highl" & _
            "ightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSele" & _
            "ctor{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:LightSteelBlue;Bord" & _
            "er:Flat,ControlDark,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" All" & _
            "owRowSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Column" & _
            "CaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBorderSty" & _
            "le=""Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>167</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 192, 167</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>17</DefaultRecSelWidth><ClientArea>0, 0, 192, 184</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></" & _
            "Blob>"
            '
            'tdgOpenOrder
            '
            Me.tdgOpenOrder.AllowArrows = False
            Me.tdgOpenOrder.AllowColMove = False
            Me.tdgOpenOrder.AllowColSelect = False
            Me.tdgOpenOrder.AllowFilter = False
            Me.tdgOpenOrder.AllowRowSelect = False
            Me.tdgOpenOrder.AllowSort = False
            Me.tdgOpenOrder.AllowUpdate = False
            Me.tdgOpenOrder.AlternatingRows = True
            Me.tdgOpenOrder.BackColor = System.Drawing.Color.White
            Me.tdgOpenOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tdgOpenOrder.Caption = "Open Orders"
            Me.tdgOpenOrder.FetchRowStyles = True
            Me.tdgOpenOrder.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.tdgOpenOrder.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgOpenOrder.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgOpenOrder.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgOpenOrder.Location = New System.Drawing.Point(224, 224)
            Me.tdgOpenOrder.Name = "tdgOpenOrder"
            Me.tdgOpenOrder.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgOpenOrder.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgOpenOrder.PreviewInfo.ZoomFactor = 75
            Me.tdgOpenOrder.RowSubDividerColor = System.Drawing.Color.LightBlue
            Me.tdgOpenOrder.Size = New System.Drawing.Size(192, 184)
            Me.tdgOpenOrder.TabIndex = 181
            Me.tdgOpenOrder.Text = "C1TrueDBGrid1"
            Me.tdgOpenOrder.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
            "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
            "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{Font:" & _
            "Arial, 8.25pt, style=Bold;}Caption{Font:Arial, 8.25pt, style=Bold;AlignHorz:Cent" & _
            "er;ForeColor:White;BackColor:SteelBlue;}Style9{}Normal{Font:Arial, 8.25pt;}Highl" & _
            "ightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSele" & _
            "ctor{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Flat," & _
            "ControlDark,1, 1, 1, 1;ForeColor:ControlText;BackColor:LightSteelBlue;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" All" & _
            "owRowSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Column" & _
            "CaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBorderSty" & _
            "le=""Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>167</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 192, 167</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>17</DefaultRecSelWidth><ClientArea>0, 0, 192, 184</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></" & _
            "Blob>"
            '
            'tdgFilledOrder
            '
            Me.tdgFilledOrder.AllowArrows = False
            Me.tdgFilledOrder.AllowColMove = False
            Me.tdgFilledOrder.AllowColSelect = False
            Me.tdgFilledOrder.AllowFilter = False
            Me.tdgFilledOrder.AllowRowSelect = False
            Me.tdgFilledOrder.AllowSort = False
            Me.tdgFilledOrder.AllowUpdate = False
            Me.tdgFilledOrder.AlternatingRows = True
            Me.tdgFilledOrder.BackColor = System.Drawing.Color.White
            Me.tdgFilledOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.tdgFilledOrder.Caption = "Filled Orders"
            Me.tdgFilledOrder.FetchRowStyles = True
            Me.tdgFilledOrder.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.tdgFilledOrder.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgFilledOrder.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgFilledOrder.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgFilledOrder.Location = New System.Drawing.Point(424, 224)
            Me.tdgFilledOrder.Name = "tdgFilledOrder"
            Me.tdgFilledOrder.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgFilledOrder.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgFilledOrder.PreviewInfo.ZoomFactor = 75
            Me.tdgFilledOrder.RowSubDividerColor = System.Drawing.Color.LightBlue
            Me.tdgFilledOrder.Size = New System.Drawing.Size(192, 184)
            Me.tdgFilledOrder.TabIndex = 182
            Me.tdgFilledOrder.Text = "C1TrueDBGrid1"
            Me.tdgFilledOrder.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Al" & _
            "iceBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive{" & _
            "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{Font:" & _
            "Arial, 8.25pt, style=Bold;}Caption{Font:Arial, 8.25pt, style=Bold;AlignHorz:Cent" & _
            "er;ForeColor:White;BackColor:SteelBlue;}Style9{}Normal{Font:Arial, 8.25pt;}Highl" & _
            "ightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSele" & _
            "ctor{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Flat," & _
            "ControlDark,1, 1, 1, 1;ForeColor:ControlText;BackColor:LightSteelBlue;}Style8{}S" & _
            "tyle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Split" & _
            "s><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" All" & _
            "owRowSelect=""False"" Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" Column" & _
            "CaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBorderSty" & _
            "le=""Flat"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>167</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 192, 167</ClientRect><" & _
            "BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid." & _
            "MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""No" & _
            "rmal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Headin" & _
            "g"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal""" & _
            " me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=" & _
            """HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me" & _
            "=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal""" & _
            " me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits" & _
            ">1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidt" & _
            "h>17</DefaultRecSelWidth><ClientArea>0, 0, 192, 184</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></" & _
            "Blob>"
            '
            'frmTNSimDashboard
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightGray
            Me.ClientSize = New System.Drawing.Size(632, 454)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgFilledOrder, Me.tdgOpenOrder, Me.tdgAllOrder, Me.lblResult, Me.tdgInventory, Me.Label4, Me.btnSearch, Me.Label2, Me.Label1, Me.dtp_end_date, Me.dtp_start_date})
            Me.Name = "frmTNSimDashboard"
            Me.Text = "TextNow SIM Dasboard"
            CType(Me.tdgInventory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgAllOrder, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgOpenOrder, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgFilledOrder, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
        Private Sub frmTNSimDashboard_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim currDate As Date = Now.Date

            Try
                dtp_start_date.Value = Generic.GetFirstDayOfMonth(currDate)
                dtp_end_date.Value = currDate
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tdgInventory_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
            GetData()
        End Sub

        Private Sub dtp_start_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_start_date.ValueChanged
            If dtp_end_date.Value < dtp_start_date.Value Then
                dtp_end_date.Value = dtp_start_date.Value
            End If
        End Sub

        Private Sub dtp_end_date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_end_date.ValueChanged
            If dtp_start_date.Value > dtp_end_date.Value Then
                dtp_start_date.Value = dtp_end_date.Value
            End If
        End Sub

        Private Sub tdgInventory_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgInventory.ButtonClick
            Dim rIdx As Integer = 0, cIdx As Integer = 0
            Dim iSku_ID As Integer = 0
            Dim filledRows() As DataRow
            Dim strStatus As String = ""
            Dim dt As DataTable
            Dim row As DataRow

            Try
                rIdx = Me.tdgInventory.Row : cIdx = e.ColIndex
                'MessageBox.Show("Current row: " & rIdx & "   Current col: " & cIdx & "    It's value is: " & Me.tdgInventory.Columns(cIdx).CellText(rIdx))
                'MessageBox.Show("Current row: " & rIdx & "   Current col: " & cIdx & "    Sku_ID is: " & Me.tdgInventory.Columns("Sku_ID").CellText(rIdx))

                iSku_ID = Me.tdgInventory.Columns("Sku_ID").CellText(rIdx)
                If cIdx = 1 Then
                    strStatus = "Pre-Kitted"
                ElseIf cIdx = 2 Then
                    strStatus = "Non-Kitted"
                End If

                If Me._dtInventoryDetails.Rows.Count > 0 Then
                    dt = Me._dtInventoryDetails.Clone
                    filledRows = Me._dtInventoryDetails.Select("Status='" & strStatus & "' And Sku_ID=" & iSku_ID)
                    For Each row In filledRows
                        dt.ImportRow(row)
                    Next
                    Dim fm As New frmSIMDataDetails(dt, "SIM Card Inventory (Data snapshot at " & Me._strDataSnapshotDateTime & ")" & " for " & Me.tdgInventory.Columns("Sku").CellText(rIdx) & "_" & strStatus, True)
                    fm.ShowDialog()
                Else
                    MessageBox.Show("No inventory detail data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "tdgInventory_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub tdgAllOrder_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgAllOrder.ButtonClick
            Dim rIdx As Integer = 0, cIdx As Integer = 0
            Dim strSku As String = ""
            Dim filledRows() As DataRow
            Dim dt, dtDetails As DataTable
            Dim row As DataRow

            Try
                rIdx = Me.tdgAllOrder.Row : cIdx = e.ColIndex
                strSku = Me.tdgAllOrder.Columns("Sku").CellText(rIdx)

                dtDetails = Me._dsAllFilledOpenDetails.Tables("AllDetails")

                If dtDetails.Rows.Count > 0 Then
                    dt = dtDetails.Clone
                    filledRows = dtDetails.Select("sku_part_nr='" & strSku & "'")
                    For Each row In filledRows
                        dt.ImportRow(row)
                    Next
                    Dim fm As New frmSIMDataDetails(dt, "All Orders (Data snapshot at " & Me._strDataSnapshotDateTime & ")" & " for " & strSku, False)
                    fm.ShowDialog()
                Else
                    MessageBox.Show("No data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, " tdgAllOrder_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub tdgOpenOrder_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgOpenOrder.ButtonClick
            Dim rIdx As Integer = 0, cIdx As Integer = 0
            Dim strSku As String = ""
            Dim filledRows() As DataRow
            Dim dt, dtDetails As DataTable
            Dim row As DataRow

            Try
                rIdx = Me.tdgOpenOrder.Row : cIdx = e.ColIndex
                strSku = Me.tdgOpenOrder.Columns("Sku").CellText(rIdx)

                dtDetails = Me._dsAllFilledOpenDetails.Tables("AllDetails")

                If dtDetails.Rows.Count > 0 Then
                    dt = dtDetails.Clone
                    filledRows = dtDetails.Select("sku_part_nr='" & strSku & "' And Status ='Open'")
                    For Each row In filledRows
                        dt.ImportRow(row)
                    Next
                    Dim fm As New frmSIMDataDetails(dt, "Open Orders (Data snapshot at " & Me._strDataSnapshotDateTime & ")" & " for " & strSku, False)
                    fm.ShowDialog()
                Else
                    MessageBox.Show("No open order data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tdgOpenOrder_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Private Sub tdgFilledOrder_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgFilledOrder.ButtonClick
            Dim rIdx As Integer = 0, cIdx As Integer = 0
            Dim strSku As String = ""
            Dim filledRows() As DataRow
            Dim dt, dtDetails As DataTable
            Dim row As DataRow

            Try
                rIdx = Me.tdgFilledOrder.Row : cIdx = e.ColIndex
                strSku = Me.tdgFilledOrder.Columns("Sku").CellText(rIdx)

                dtDetails = Me._dsAllFilledOpenDetails.Tables("AllDetails")

                If dtDetails.Rows.Count > 0 Then
                    dt = dtDetails.Clone
                    filledRows = dtDetails.Select("sku_part_nr='" & strSku & "' And Not Status ='Open'")
                    For Each row In filledRows
                        dt.ImportRow(row)
                    Next
                    Dim fm As New frmSIMDataDetails(dt, "Filled Orders (Data snapshot at " & Me._strDataSnapshotDateTime & ")" & " for " & strSku, False)
                    fm.ShowDialog()
                Else
                    MessageBox.Show("No filled order data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "tdgFilledOrder_ButtonClick", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

#Region "METHODS"
        Private Sub GetData()
            Me.Cursor = Cursors.WaitCursor
            Me._strDataSnapshotDateTime = Format(Now, "yyyyMMdd_HHmmss")
            GetSIMCardInventory()
            GetSIMCardAllFilledOpenOrders()

            Me.Cursor = Cursors.Default
        End Sub

        Private Sub GetSIMCardInventory()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim dt As DataTable

            Try
                Me._dtInventoryDetails = Nothing
                Me.tdgInventory.DataSource = Nothing

                dt = Me._objTN.getSIMCardInventorySummary(Me._iMenuCustID, Me._dtInventoryDetails)
                With Me.tdgInventory
                    .DataSource = dt.DefaultView

                    '.Columns("Details1").Caption = ""
                    '.Columns("Details2").Caption = ""
                    ' .Splits(0).DisplayColumns("Details1").Button = True  'ok: .Splits(0).DisplayColumns(2).Button = True
                    '.Splits(0).DisplayColumns("Details1").ButtonAlways = True
                    '.Splits(0).DisplayColumns("Pre-Kitted").ButtonText = True 'ok:  .Splits(0).DisplayColumns(1).ButtonText = True
                    '.Splits(0).DisplayColumns("Pre-Kitted").ButtonAlways = True
                    .Splits(0).DisplayColumns("Pre-Kitted").Button = True 'ok:  .Splits(0).DisplayColumns(1).ButtonText = True
                    .Splits(0).DisplayColumns("Pre-Kitted").ButtonAlways = True
                    .Splits(0).DisplayColumns("Non-Kitted").Button = True 'ok:  .Splits(0).DisplayColumns(2).ButtonText = True
                    .Splits(0).DisplayColumns("Non-Kitted").ButtonAlways = True

                    .ColumnFooters = True
                    .Columns("Sku").FooterText = "Total" '.Columns(0).FooterText = "Total" 
                    .Splits(0).DisplayColumns("Sku").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    CalculateFooter()

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                    .Splits(0).DisplayColumns("Sku_ID").Width = 0

                    .Caption = "SIM Card Inventory (Data snapshot at " & Me._strDataSnapshotDateTime & ")"
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " GetSIMCardInventory", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub GetSIMCardAllFilledOpenOrders()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim dt As DataTable
            Dim strBegDate As String = Format(dtp_start_date.Value, "yyyy-MM-dd")
            Dim strEndDate As String = Format(dtp_end_date.Value, "yyyy-MM-dd")
            Dim iOrderCountAll As Integer = 0
            Dim iOrderCountFilled As Integer = 0
            Dim iOrderCountOpen As Integer = 0

            Try
                Me._dsAllFilledOpenDetails.Tables.Clear()
                Me.tdgAllOrder.DataSource = Nothing : Me.tdgFilledOrder.DataSource = Nothing : Me.tdgOpenOrder.DataSource = Nothing
                Me.lblResult.Text = ""

                Me._dsAllFilledOpenDetails = Me._objTN.getSIMCardAllFilledOpenData(Me._iMenuCustID, strBegDate, strEndDate, iOrderCountAll, iOrderCountFilled, iOrderCountOpen)

                With Me.tdgAllOrder
                    .DataSource = Me._dsAllFilledOpenDetails.Tables("All").DefaultView
                    .Splits(0).DisplayColumns("Card Count").Button = True
                    .Splits(0).DisplayColumns("Card Count").ButtonAlways = True
                    .ColumnFooters = True
                    .Columns("Sku").FooterText = "Total"
                    .Splits(0).DisplayColumns("Sku").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    CalculateOrderFooter(Me.tdgAllOrder)
                    If iOrderCountAll > 0 Then .Caption = "All Orders" & " (" & iOrderCountAll & ")"
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                End With
                With Me.tdgOpenOrder
                    .DataSource = Me._dsAllFilledOpenDetails.Tables("Open").DefaultView
                    .Splits(0).DisplayColumns("Card Count").Button = True
                    .Splits(0).DisplayColumns("Card Count").ButtonAlways = True
                    .ColumnFooters = True
                    .Columns("Sku").FooterText = "Total"
                    .Splits(0).DisplayColumns("Sku").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    CalculateOrderFooter(Me.tdgOpenOrder)
                    If iOrderCountOpen > 0 Then .Caption = "Open Orders" & " (" & iOrderCountOpen & ")"
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                End With
                With Me.tdgFilledOrder
                    .DataSource = Me._dsAllFilledOpenDetails.Tables("Filled").DefaultView
                    .Splits(0).DisplayColumns("Card Count").Button = True
                    .Splits(0).DisplayColumns("Card Count").ButtonAlways = True
                    .ColumnFooters = True
                    .Columns("Sku").FooterText = "Total"
                    .Splits(0).DisplayColumns("Sku").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                    CalculateOrderFooter(Me.tdgFilledOrder)
                    If iOrderCountFilled > 0 Then .Caption = "Filled Orders" & " (" & iOrderCountFilled & ")"
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                End With

                Me.lblResult.Text = "SIM Card Result for date range: " & Format(dtp_start_date.Value, "MM/dd/yyyy") & " to " & _
                                    Format(dtp_end_date.Value, "MM/dd/yyyy") & " (Data snapshot at " & Me._strDataSnapshotDateTime & ")"
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " GetSIMCardInventory", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub CalculateFooter()
            Dim i As Integer
            Dim sum1, sum2, sum3 As Double
            Try
                For i = 0 To Me.tdgInventory.Splits(0).Rows.Count - 1
                    sum1 += Me.tdgInventory.Columns("Pre-Kitted").CellValue(i)
                    sum2 += Me.tdgInventory.Columns("Non-Kitted").CellValue(i)
                    sum3 += Me.tdgInventory.Columns("Total").CellValue(i)
                Next
                Me.tdgInventory.Columns("Pre-Kitted").FooterText = sum1
                Me.tdgInventory.Columns("Non-Kitted").FooterText = sum2
                Me.tdgInventory.Columns("Total").FooterText = sum3
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " CalculateFooter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub CalculateOrderFooter(ByRef tdgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
            Dim i As Integer
            Dim sum1 As Double
            Try
                For i = 0 To tdgData.Splits(0).Rows.Count - 1
                    sum1 += tdgData.Columns("Card Count").CellValue(i)
                Next
                tdgData.Columns("Card Count").FooterText = sum1

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " CalculateOrderFooter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


#End Region




    End Class

End Namespace
