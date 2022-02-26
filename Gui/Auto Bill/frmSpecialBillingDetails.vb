Option Explicit On 

Public Class frmSpecialBillingDetails
    Inherits System.Windows.Forms.Form

    Private GobjSPBillingDetails As PSS.Data.Buisness.SpecialBillingDetails
    Private GiUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser
    Private GdsDevice As DataSet

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GobjSPBillingDetails = New PSS.Data.Buisness.SpecialBillingDetails()

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
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFrShipWkDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToShipWkDt As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdDevice As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdConsumedBillcode As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdBillGroupBillCode As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents pnlBillcodes As System.Windows.Forms.Panel
    Friend WithEvents lblConsumedTotal As System.Windows.Forms.Label
    Friend WithEvents lblBillGrpTotal As System.Windows.Forms.Label
    Friend WithEvents btnGetData As System.Windows.Forms.Button
    Friend WithEvents lblModelTarget As System.Windows.Forms.Label
    Friend WithEvents lblDeviceCnt As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSpecialBillingDetails))
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFrShipWkDt = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpToShipWkDt = New System.Windows.Forms.DateTimePicker()
        Me.grdDevice = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdConsumedBillcode = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grdBillGroupBillCode = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblConsumedTotal = New System.Windows.Forms.Label()
        Me.lblBillGrpTotal = New System.Windows.Forms.Label()
        Me.pnlBillcodes = New System.Windows.Forms.Panel()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.lblModelTarget = New System.Windows.Forms.Label()
        Me.lblDeviceCnt = New System.Windows.Forms.Label()
        CType(Me.grdDevice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdConsumedBillcode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdBillGroupBillCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBillcodes.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.Location = New System.Drawing.Point(240, 23)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(160, 21)
        Me.cmbCustomer.TabIndex = 125
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(240, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Customer : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFrShipWkDt
        '
        Me.dtpFrShipWkDt.CustomFormat = "yyyy-MM-dd"
        Me.dtpFrShipWkDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrShipWkDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrShipWkDt.Location = New System.Drawing.Point(416, 24)
        Me.dtpFrShipWkDt.Name = "dtpFrShipWkDt"
        Me.dtpFrShipWkDt.Size = New System.Drawing.Size(144, 20)
        Me.dtpFrShipWkDt.TabIndex = 127
        Me.dtpFrShipWkDt.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(416, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(152, 16)
        Me.Label4.TabIndex = 128
        Me.Label4.Text = "From Ship Work Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(584, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "To Ship Work Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpToShipWkDt
        '
        Me.dtpToShipWkDt.CustomFormat = "yyyy-MM-dd"
        Me.dtpToShipWkDt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToShipWkDt.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpToShipWkDt.Location = New System.Drawing.Point(584, 24)
        Me.dtpToShipWkDt.Name = "dtpToShipWkDt"
        Me.dtpToShipWkDt.Size = New System.Drawing.Size(144, 20)
        Me.dtpToShipWkDt.TabIndex = 129
        Me.dtpToShipWkDt.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
        '
        'grdDevice
        '
        Me.grdDevice.AllowColMove = False
        Me.grdDevice.AllowColSelect = False
        Me.grdDevice.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdDevice.AllowUpdate = False
        Me.grdDevice.AlternatingRows = True
        Me.grdDevice.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdDevice.BackColor = System.Drawing.Color.SteelBlue
        Me.grdDevice.FilterBar = True
        Me.grdDevice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDevice.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdDevice.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdDevice.Location = New System.Drawing.Point(240, 56)
        Me.grdDevice.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdDevice.Name = "grdDevice"
        Me.grdDevice.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdDevice.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdDevice.PreviewInfo.ZoomFactor = 75
        Me.grdDevice.RowHeight = 20
        Me.grdDevice.Size = New System.Drawing.Size(640, 560)
        Me.grdDevice.TabIndex = 131
        Me.grdDevice.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Transparent;}Se" & _
        "lected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:I" & _
        "nactiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:" & _
        "Transparent;}Footer{}Caption{AlignHorz:Center;}Style1{}Normal{Font:Microsoft San" & _
        "s Serif, 8.25pt;AlignVert:Center;BackColor:Control;}HighlightRow{ForeColor:Highl" & _
        "ightText;BackColor:Highlight;}Style14{}OddRow{BackColor:Transparent;}RecordSelec" & _
        "tor{AlignImage:Center;}Style15{}Heading{AlignVert:Center;Wrap:True;Font:Microsof" & _
        "t Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;Border:Raised,,1, 1, 1, 1;Fore" & _
        "Color:ControlText;BackColor:Bisque;}Style8{}Style10{AlignHorz:Near;}Style11{}Sty" & _
        "le12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HB" & _
        "arHeight=""10"" VBarHeight=""10"" AllowColMove=""False"" AllowColSelect=""False"" Name=""" & _
        """ AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCapt" & _
        "ionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCell" & _
        "Border"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Hor" & _
        "izontalScrollGroup=""1""><Height>556</Height><CaptionStyle parent=""Style2"" me=""Sty" & _
        "le10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle p" & _
        "arent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingS" & _
        "tyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=" & _
        """Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""O" & _
        "ddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /" & _
        "><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style" & _
        "1"" /><ClientRect>0, 0, 636, 556</ClientRect><BorderSide>0</BorderSide><BorderSty" & _
        "le>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><St" & _
        "yle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=" & _
        """Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""He" & _
        "ading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Nor" & _
        "mal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Nor" & _
        "mal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading""" & _
        " me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Ca" & _
        "ption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzS" & _
        "plits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientAre" & _
        "a>0, 0, 636, 556</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><Pri" & _
        "ntPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'grdConsumedBillcode
        '
        Me.grdConsumedBillcode.AllowColMove = False
        Me.grdConsumedBillcode.AllowColSelect = False
        Me.grdConsumedBillcode.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdConsumedBillcode.AllowUpdate = False
        Me.grdConsumedBillcode.AlternatingRows = True
        Me.grdConsumedBillcode.BackColor = System.Drawing.Color.Black
        Me.grdConsumedBillcode.FilterBar = True
        Me.grdConsumedBillcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdConsumedBillcode.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdConsumedBillcode.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdConsumedBillcode.Location = New System.Drawing.Point(3, 24)
        Me.grdConsumedBillcode.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdConsumedBillcode.Name = "grdConsumedBillcode"
        Me.grdConsumedBillcode.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdConsumedBillcode.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdConsumedBillcode.PreviewInfo.ZoomFactor = 75
        Me.grdConsumedBillcode.RowHeight = 20
        Me.grdConsumedBillcode.Size = New System.Drawing.Size(214, 208)
        Me.grdConsumedBillcode.TabIndex = 132
        Me.grdConsumedBillcode.Text = "Consumed"
        Me.grdConsumedBillcode.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:Yellow;BackColo" & _
        "r:Black;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{" & _
        "ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red" & _
        ";BackColor:Transparent;}Footer{}Caption{AlignHorz:Center;}Style9{}Normal{Font:Mi" & _
        "crosoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Center;}HighlightRow{Fore" & _
        "Color:HighlightText;BackColor:Highlight;}Style12{}OddRow{ForeColor:Yellow;BackCo" & _
        "lor:Black;}RecordSelector{AlignImage:Center;ForeColor:Black;BackColor:Control;}S" & _
        "tyle13{}Heading{AlignVert:Center;Wrap:True;Font:Microsoft Sans Serif, 8.25pt, st" & _
        "yle=Bold;AlignHorz:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Black;BackColor:Co" & _
        "ntrol;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data" & _
        "></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""5"" AllowColMove=""Fa" & _
        "lse"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""T" & _
        "rue"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterB" & _
        "ar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
        "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>204</Height><Ca" & _
        "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
        "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
        "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
        "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
        "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
        "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
        "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
        "/><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 210, 204</ClientRect><B" & _
        "orderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.M" & _
        "ergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Nor" & _
        "mal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading" & _
        """ me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" " & _
        "me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""" & _
        "HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=" & _
        """OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" " & _
        "me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>" & _
        "1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth" & _
        ">17</DefaultRecSelWidth><ClientArea>0, 0, 210, 204</ClientArea><PrintPageHeaderS" & _
        "tyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></B" & _
        "lob>"
        '
        'grdBillGroupBillCode
        '
        Me.grdBillGroupBillCode.AllowColMove = False
        Me.grdBillGroupBillCode.AllowColSelect = False
        Me.grdBillGroupBillCode.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdBillGroupBillCode.AllowUpdate = False
        Me.grdBillGroupBillCode.AlternatingRows = True
        Me.grdBillGroupBillCode.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.grdBillGroupBillCode.BackColor = System.Drawing.Color.Black
        Me.grdBillGroupBillCode.FilterBar = True
        Me.grdBillGroupBillCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdBillGroupBillCode.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdBillGroupBillCode.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.grdBillGroupBillCode.Location = New System.Drawing.Point(3, 280)
        Me.grdBillGroupBillCode.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdBillGroupBillCode.Name = "grdBillGroupBillCode"
        Me.grdBillGroupBillCode.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdBillGroupBillCode.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdBillGroupBillCode.PreviewInfo.ZoomFactor = 75
        Me.grdBillGroupBillCode.RowHeight = 20
        Me.grdBillGroupBillCode.Size = New System.Drawing.Size(214, 320)
        Me.grdBillGroupBillCode.TabIndex = 133
        Me.grdBillGroupBillCode.Text = "Consumed"
        Me.grdBillGroupBillCode.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{ForeColor:Lime;BackColor:" & _
        "Black;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{Fo" & _
        "reColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;B" & _
        "ackColor:Transparent;}Footer{}Caption{AlignHorz:Center;}Style1{}Normal{Font:Micr" & _
        "osoft Sans Serif, 8.25pt;AlignVert:Center;BackColor:Control;}HighlightRow{ForeCo" & _
        "lor:HighlightText;BackColor:Highlight;}Style14{}OddRow{ForeColor:Lime;BackColor:" & _
        "Black;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microso" & _
        "ft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raise" & _
        "d,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz" & _
        ":Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1True" & _
        "DBGrid.MergeView HBarHeight=""5"" AllowColMove=""False"" AllowColSelect=""False"" Name" & _
        "="""" AllowRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCa" & _
        "ptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCe" & _
        "llBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" H" & _
        "orizontalScrollGroup=""1""><Height>316</Height><CaptionStyle parent=""Style2"" me=""S" & _
        "tyle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenR" & _
        "ow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle" & _
        " parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Headin" & _
        "gStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" m" & _
        "e=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=" & _
        """OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11""" & _
        " /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Sty" & _
        "le1"" /><ClientRect>0, 0, 210, 316</ClientRect><BorderSide>0</BorderSide><BorderS" & _
        "tyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><" & _
        "Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style paren" & _
        "t=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""" & _
        "Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""N" & _
        "ormal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""N" & _
        "ormal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Headin" & _
        "g"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""" & _
        "Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</hor" & _
        "zSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientA" & _
        "rea>0, 0, 210, 316</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><P" & _
        "rintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'lblConsumedTotal
        '
        Me.lblConsumedTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblConsumedTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsumedTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblConsumedTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblConsumedTotal.Location = New System.Drawing.Point(6, 8)
        Me.lblConsumedTotal.Name = "lblConsumedTotal"
        Me.lblConsumedTotal.Size = New System.Drawing.Size(176, 16)
        Me.lblConsumedTotal.TabIndex = 134
        Me.lblConsumedTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBillGrpTotal
        '
        Me.lblBillGrpTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblBillGrpTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBillGrpTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblBillGrpTotal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBillGrpTotal.Location = New System.Drawing.Point(6, 264)
        Me.lblBillGrpTotal.Name = "lblBillGrpTotal"
        Me.lblBillGrpTotal.Size = New System.Drawing.Size(178, 16)
        Me.lblBillGrpTotal.TabIndex = 135
        Me.lblBillGrpTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlBillcodes
        '
        Me.pnlBillcodes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.pnlBillcodes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlBillcodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlBillcodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblModelTarget, Me.grdBillGroupBillCode, Me.lblBillGrpTotal, Me.grdConsumedBillcode, Me.lblConsumedTotal})
        Me.pnlBillcodes.Location = New System.Drawing.Point(8, 8)
        Me.pnlBillcodes.Name = "pnlBillcodes"
        Me.pnlBillcodes.Size = New System.Drawing.Size(224, 608)
        Me.pnlBillcodes.TabIndex = 136
        '
        'btnGetData
        '
        Me.btnGetData.BackColor = System.Drawing.Color.Green
        Me.btnGetData.ForeColor = System.Drawing.Color.White
        Me.btnGetData.Location = New System.Drawing.Point(744, 21)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(64, 24)
        Me.btnGetData.TabIndex = 137
        Me.btnGetData.Text = "Get Data"
        '
        'lblModelTarget
        '
        Me.lblModelTarget.BackColor = System.Drawing.Color.Transparent
        Me.lblModelTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModelTarget.ForeColor = System.Drawing.Color.Blue
        Me.lblModelTarget.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblModelTarget.Location = New System.Drawing.Point(6, 240)
        Me.lblModelTarget.Name = "lblModelTarget"
        Me.lblModelTarget.Size = New System.Drawing.Size(178, 16)
        Me.lblModelTarget.TabIndex = 136
        Me.lblModelTarget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDeviceCnt
        '
        Me.lblDeviceCnt.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblDeviceCnt.BackColor = System.Drawing.Color.Black
        Me.lblDeviceCnt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDeviceCnt.ForeColor = System.Drawing.Color.Lime
        Me.lblDeviceCnt.Location = New System.Drawing.Point(816, 20)
        Me.lblDeviceCnt.Name = "lblDeviceCnt"
        Me.lblDeviceCnt.Size = New System.Drawing.Size(56, 24)
        Me.lblDeviceCnt.TabIndex = 138
        Me.lblDeviceCnt.Text = "0"
        Me.lblDeviceCnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmSpecialBillingDetails
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(888, 638)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDeviceCnt, Me.btnGetData, Me.pnlBillcodes, Me.grdDevice, Me.dtpFrShipWkDt, Me.Label4, Me.Label1, Me.dtpToShipWkDt, Me.cmbCustomer, Me.Label2})
        Me.Name = "frmSpecialBillingDetails"
        Me.Text = "Special Billing Details"
        CType(Me.grdDevice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdConsumedBillcode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdBillGroupBillCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBillcodes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        GobjSPBillingDetails = Nothing
        If Not IsNothing(Me.GdsDevice) Then
            Me.GdsDevice.Dispose()
            Me.GdsDevice = Nothing
        End If
    End Sub

    '*******************************************************************
    Private Sub frmSpecialBillingDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objGen As New PSS.Data.Buisness.Generic()

        Try
            '*********************************************
            'Load customer of cell product only
            '*********************************************
            objGen.LoadCustomers(Me.cmbCustomer, 2)

            Me.dtpFrShipWkDt.Value = Now
            Me.dtpToShipWkDt.Value = Now

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGen = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetData.Click
        Try
            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbCustomer.Focus()
                Exit Sub
            End If
            If Me.dtpFrShipWkDt.Text = "" Or Me.dtpToShipWkDt.Text = "" Then
                MessageBox.Show("Please select ""From Ship Work Date"" and ""To Ship Work Date"".", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.dtpFrShipWkDt.Focus()
                Exit Sub
            End If

            If Me.dtpToShipWkDt.Value < Me.dtpFrShipWkDt.Value Then
                MessageBox.Show("""To Ship Work Date"" can't be before ""From Ship Work Date"".", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.dtpFrShipWkDt.Focus()
                Exit Sub
            End If

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Me.Enabled = False

            '******************
            'Reset Data
            '******************
            Me.grdDevice.DataSource = Nothing
            Me.grdConsumedBillcode.DataSource = Nothing
            Me.grdBillGroupBillCode.DataSource = Nothing
            Me.lblConsumedTotal.Text = ""
            Me.lblBillGrpTotal.Text = ""
            Me.lblModelTarget.Text = ""
            Me.lblDeviceCnt.Text = ""

            If Not IsNothing(Me.GdsDevice) Then
                Me.GdsDevice.Dispose()
                Me.GdsDevice = Nothing
            End If

            '******************
            'Get data info
            '******************
            GdsDevice = Me.GobjSPBillingDetails.GetBillingDataPerCustomerByShipWkDt(Me.cmbCustomer.SelectedValue, _
                                                                                    Me.dtpFrShipWkDt.Text, _
                                                                                    Me.dtpToShipWkDt.Text)

            '***********************************
            'Populate Data
            '***********************************
            If Me.GdsDevice.Tables.Count > 0 Then
                '***********************************
                'Populate Device and Labor info 
                '***********************************
                Me.PopulateDeviceLaborData(Me.GdsDevice.Tables(0))
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Data ClickEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.Enabled = True
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateDeviceLaborData(ByRef dt1 As DataTable)
        Dim iNumOfColumns As Integer = dt1.Columns.Count
        Dim i As Integer

        Try
            Me.lblDeviceCnt.Text = dt1.Rows.Count
            Me.grdDevice.DataSource = Nothing
            Me.grdDevice.DataSource = dt1.DefaultView

            With Me.grdDevice
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                ''Set individual column data horizontal alignment
                .Splits(0).DisplayColumns("Lvl").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("LaborChrg").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AB Lvl").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("AB LaborChrg").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns("Ent").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns("SN").Width = 100
                .Splits(0).DisplayColumns("Model").Width = 120
                .Splits(0).DisplayColumns("Ent").Width = 40
                .Splits(0).DisplayColumns("RecDt").Width = 70
                .Splits(0).DisplayColumns("ShipDt").Width = 70
                .Splits(0).DisplayColumns("Lvl").Width = 50
                .Splits(0).DisplayColumns("LaborChrg").Width = 70
                .Splits(0).DisplayColumns("AB Lvl").Width = 50
                .Splits(0).DisplayColumns("AB LaborChrg").Width = 70
                .Splits(0).DisplayColumns("Bill Condtion").Width = 110

                'Set individual column background color
                .Splits(0).DisplayColumns("Lvl").Style.BackColor = Color.LightGreen
                .Splits(0).DisplayColumns("LaborChrg").Style.BackColor = Color.LightGreen
                .Splits(0).DisplayColumns("AB Lvl").Style.BackColor = Color.PaleTurquoise
                .Splits(0).DisplayColumns("AB LaborChrg").Style.BackColor = Color.PaleTurquoise

                'Make some columns invisible
                .Splits(0).DisplayColumns("Device_ID").Visible = False
                .Splits(0).DisplayColumns("Model_ID").Visible = False

            End With

            Me.grdDevice.Refresh()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*******************************************************************
    Private Sub grdDevice_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles grdDevice.MouseUp
        Try
            '****************
            'populate data
            '****************
            If Not IsDBNull(Me.grdDevice.Columns("Device_ID").Value) Then
                '***********************************
                'Populate consumed data
                '***********************************
                Me.PopulateConsumedData(Me.grdDevice.Columns("Device_ID").Value)
                '***********************************
                'Populate billgroup data
                '***********************************
                Me.PopulateBillgrpData(Me.grdDevice.Columns("Device_ID").Value)
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Device Data Grid MouseUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateConsumedData(ByVal iDevice_ID As Integer)
        Dim i As Integer
        Dim R1() As DataRow
        Dim drNewRow As DataRow
        Dim dt1 As New DataTable()
        Dim objGen As New PSS.Data.Buisness.Generic()
        Dim decTotal As Decimal = 0

        Try
            R1 = Me.GdsDevice.Tables(1).Select("Device_ID = " & iDevice_ID)
            objGen.AddNewColumnToDataTable(dt1, "BillCode", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "InvAmt", "System.Decimal", "0")

            For i = 0 To R1.Length - 1
                drNewRow = dt1.NewRow
                drNewRow("BillCode") = R1(i)("BillCode")
                drNewRow("InvAmt") = R1(i)("InvAmt")
                dt1.Rows.Add(drNewRow)
                dt1.AcceptChanges()
                decTotal += R1(i)("InvAmt")

                drNewRow = Nothing
            Next i

            Me.grdConsumedBillcode.DataSource = Nothing
            Me.grdConsumedBillcode.DataSource = dt1.DefaultView

            With Me.grdConsumedBillcode
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To dt1.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                ''Set individual column data horizontal alignment
                .Splits(0).DisplayColumns("InvAmt").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near

                'Set Column Widths
                .Splits(0).DisplayColumns("BillCode").Width = 120
                .Splits(0).DisplayColumns("InvAmt").Width = 50
            End With

            Me.grdConsumedBillcode.Refresh()
            Me.lblConsumedTotal.Text = "Consumed Total = " & decTotal
        Catch ex As Exception
            Throw ex
        Finally
            objGen = Nothing
            drNewRow = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub PopulateBillgrpData(ByVal iDevice_ID As Integer)
        Dim i As Integer
        Dim R1() As DataRow
        Dim RModelTarget() As DataRow
        Dim drNewRow As DataRow
        Dim dt1 As New DataTable()
        Dim objGen As New PSS.Data.Buisness.Generic()
        Dim decTotal As Decimal = 0

        Try
            '***************************
            '1:: Bill Group Info
            '***************************
            R1 = Me.GdsDevice.Tables(2).Select("Device_ID = " & iDevice_ID)
            objGen.AddNewColumnToDataTable(dt1, "BillCode", "System.String", "")
            objGen.AddNewColumnToDataTable(dt1, "InvAmt", "System.Decimal", "0")

            For i = 0 To R1.Length - 1
                drNewRow = dt1.NewRow
                drNewRow("BillCode") = R1(i)("BillCode")
                drNewRow("InvAmt") = R1(i)("InvAmt")
                dt1.Rows.Add(drNewRow)
                dt1.AcceptChanges()
                decTotal += R1(i)("InvAmt")

                drNewRow = Nothing
            Next i

            Me.grdBillGroupBillCode.DataSource = Nothing
            Me.grdBillGroupBillCode.DataSource = dt1.DefaultView

            With Me.grdBillGroupBillCode
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To dt1.Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                ''Set individual column data horizontal alignment
                .Splits(0).DisplayColumns("InvAmt").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

                'Set Column Widths
                .Splits(0).DisplayColumns("BillCode").Width = 120
                .Splits(0).DisplayColumns("InvAmt").Width = 50
            End With

            Me.grdBillGroupBillCode.Refresh()
            Me.lblBillGrpTotal.Text = "AB Total = " & decTotal


            '***************************
            '2::Model Target Info
            '***************************
            RModelTarget = Me.GdsDevice.Tables(3).Select("MT_Model_ID = " & Me.grdDevice.Columns("Model_ID").Value & " AND MT_Cust_ID = " & Me.cmbCustomer.SelectedValue & " AND MT_Enterprise = '" & Me.grdDevice.Columns("Ent").Value & "'")

            If RModelTarget.Length > 0 Then
                Me.lblModelTarget.Text = "Model Target = " & RModelTarget(0)("MT_Target")
            Else
                Me.lblModelTarget.Text = "Model Target = 0"
            End If
            '***************************
        Catch ex As Exception
            Throw ex
        Finally
            objGen = Nothing
            drNewRow = Nothing
            R1 = Nothing
            RModelTarget = Nothing
        End Try
    End Sub

    '*******************************************************************


End Class
