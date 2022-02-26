Option Explicit On 

Imports PSS.Data
Imports PSS.Core.[Global]

Namespace Gui.Jabil

    Public Class frmReceiving
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _objProdRec As PSS.Data.Production.Receiving
        Private _objJabilRec As Buisness.Jabil.Receiving
        Private _iWOID, _iTrayID As Integer

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            _strScreenName = strScreenName

            'Add any initialization after the InitializeComponent() call
            _objProdRec = New PSS.Data.Production.Receiving()
            _objJabilRec = New Buisness.Jabil.Receiving()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
            _objProdRec = Nothing
            _objJabilRec = Nothing
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents gbDeviceInfo As System.Windows.Forms.GroupBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblRecQty As System.Windows.Forms.Label
        Friend WithEvents dgReceivedUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblMachanicalSNLabel As System.Windows.Forms.Label
        Friend WithEvents txtMechanicalSN As System.Windows.Forms.TextBox
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents lblWarrantyStatus As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnReOpenRMA As System.Windows.Forms.Button
        Friend WithEvents btnCloseRMA As System.Windows.Forms.Button
        Friend WithEvents txtRMA As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnNewRMA As System.Windows.Forms.Button
        Friend WithEvents dgOpenRMA As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboCostCenter As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReceiving))
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.gbDeviceInfo = New System.Windows.Forms.GroupBox()
            Me.cboCostCenter = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblRecQty = New System.Windows.Forms.Label()
            Me.dgReceivedUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblMachanicalSNLabel = New System.Windows.Forms.Label()
            Me.txtMechanicalSN = New System.Windows.Forms.TextBox()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.lblWarrantyStatus = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnReOpenRMA = New System.Windows.Forms.Button()
            Me.btnCloseRMA = New System.Windows.Forms.Button()
            Me.txtRMA = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnNewRMA = New System.Windows.Forms.Button()
            Me.dgOpenRMA = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.gbDeviceInfo.SuspendLayout()
            CType(Me.cboCostCenter, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgReceivedUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            CType(Me.dgOpenRMA, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Black
            Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
            Me.lblHeader.Location = New System.Drawing.Point(1, 1)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(266, 79)
            Me.lblHeader.TabIndex = 138
            Me.lblHeader.Text = "Jabil Receiving"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'gbDeviceInfo
            '
            Me.gbDeviceInfo.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbDeviceInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCostCenter, Me.Label4, Me.Label5, Me.lblRecQty, Me.dgReceivedUnits, Me.lblMachanicalSNLabel, Me.txtMechanicalSN, Me.cboModel, Me.Label3, Me.Label2, Me.txtIMEI})
            Me.gbDeviceInfo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDeviceInfo.ForeColor = System.Drawing.Color.WhiteSmoke
            Me.gbDeviceInfo.Location = New System.Drawing.Point(368, 120)
            Me.gbDeviceInfo.Name = "gbDeviceInfo"
            Me.gbDeviceInfo.Size = New System.Drawing.Size(408, 248)
            Me.gbDeviceInfo.TabIndex = 2
            Me.gbDeviceInfo.TabStop = False
            '
            'cboCostCenter
            '
            Me.cboCostCenter.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCostCenter.Caption = ""
            Me.cboCostCenter.CaptionHeight = 17
            Me.cboCostCenter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCostCenter.ColumnCaptionHeight = 17
            Me.cboCostCenter.ColumnFooterHeight = 17
            Me.cboCostCenter.ContentHeight = 15
            Me.cboCostCenter.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCostCenter.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCostCenter.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCostCenter.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCostCenter.EditorHeight = 15
            Me.cboCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCostCenter.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCostCenter.ItemHeight = 15
            Me.cboCostCenter.Location = New System.Drawing.Point(88, 24)
            Me.cboCostCenter.MatchEntryTimeout = CType(2000, Long)
            Me.cboCostCenter.MaxDropDownItems = CType(5, Short)
            Me.cboCostCenter.MaxLength = 32767
            Me.cboCostCenter.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCostCenter.Name = "cboCostCenter"
            Me.cboCostCenter.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCostCenter.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCostCenter.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCostCenter.Size = New System.Drawing.Size(240, 21)
            Me.cboCostCenter.TabIndex = 1
            Me.cboCostCenter.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
            ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
            "le1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;BackColor:Contr" & _
            "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
            "le10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
            "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
            "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
            "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
            "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
            "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
            "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
            """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
            "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
            "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.Location = New System.Drawing.Point(8, 24)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 16)
            Me.Label4.TabIndex = 129
            Me.Label4.Text = "Cost Center:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Black
            Me.Label5.ForeColor = System.Drawing.Color.Green
            Me.Label5.Location = New System.Drawing.Point(344, 24)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(96, 16)
            Me.Label5.TabIndex = 127
            Me.Label5.Text = "Received Qty"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblRecQty
            '
            Me.lblRecQty.BackColor = System.Drawing.Color.Black
            Me.lblRecQty.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecQty.ForeColor = System.Drawing.Color.Green
            Me.lblRecQty.Location = New System.Drawing.Point(344, 40)
            Me.lblRecQty.Name = "lblRecQty"
            Me.lblRecQty.Size = New System.Drawing.Size(96, 40)
            Me.lblRecQty.TabIndex = 126
            Me.lblRecQty.Text = "0"
            Me.lblRecQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'dgReceivedUnits
            '
            Me.dgReceivedUnits.AllowUpdate = False
            Me.dgReceivedUnits.AlternatingRows = True
            Me.dgReceivedUnits.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgReceivedUnits.CaptionHeight = 17
            Me.dgReceivedUnits.FilterBar = True
            Me.dgReceivedUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgReceivedUnits.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dgReceivedUnits.Location = New System.Drawing.Point(8, 152)
            Me.dgReceivedUnits.Name = "dgReceivedUnits"
            Me.dgReceivedUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgReceivedUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgReceivedUnits.PreviewInfo.ZoomFactor = 75
            Me.dgReceivedUnits.RowHeight = 15
            Me.dgReceivedUnits.Size = New System.Drawing.Size(392, 80)
            Me.dgReceivedUnits.TabIndex = 9
            Me.dgReceivedUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;BackColor:SteelBlue;}Normal{Font:Tahoma, 9.75p" & _
            "t, style=Bold;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Hi" & _
            "ghlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{A" & _
            "lignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}Highl" & _
            "ightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelector{AlignImage:C" & _
            "enter;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColo" & _
            "r:InactiveCaption;}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:True;AlignVert:Ce" & _
            "nter;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}FilterBa" & _
            "r{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;}S" & _
            "tyle4{}Style9{}Style8{}Style5{}Group{BackColor:ControlDark;Border:None,,0, 0, 0," & _
            " 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Sp" & _
            "lits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHe" & _
            "ight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Marq" & _
            "ueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vertica" & _
            "lScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>76</Height><CaptionStyle pare" & _
            "nt=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowSt" & _
            "yle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style1" & _
            "3"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""S" & _
            "tyle12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent" & _
            "=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><Od" & _
            "dRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelec" & _
            "tor"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent" & _
            "=""Normal"" me=""Style1"" /><ClientRect>0, 0, 388, 76</ClientRect><BorderSide>0</Bor" & _
            "derSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Split" & _
            "s><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading" & _
            """ /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /" & _
            "><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" />" & _
            "<Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" />" & _
            "<Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Styl" & _
            "e parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /" & _
            "><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><h" & _
            "orzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecS" & _
            "elWidth><ClientArea>0, 0, 388, 76</ClientArea><PrintPageHeaderStyle parent="""" me" & _
            "=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'lblMachanicalSNLabel
            '
            Me.lblMachanicalSNLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachanicalSNLabel.ForeColor = System.Drawing.Color.White
            Me.lblMachanicalSNLabel.Location = New System.Drawing.Point(48, 88)
            Me.lblMachanicalSNLabel.Name = "lblMachanicalSNLabel"
            Me.lblMachanicalSNLabel.Size = New System.Drawing.Size(40, 16)
            Me.lblMachanicalSNLabel.TabIndex = 125
            Me.lblMachanicalSNLabel.Text = "S/N:"
            Me.lblMachanicalSNLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtMechanicalSN
            '
            Me.txtMechanicalSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMechanicalSN.Location = New System.Drawing.Point(88, 88)
            Me.txtMechanicalSN.Name = "txtMechanicalSN"
            Me.txtMechanicalSN.Size = New System.Drawing.Size(240, 21)
            Me.txtMechanicalSN.TabIndex = 3
            Me.txtMechanicalSN.Text = ""
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(88, 56)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(240, 21)
            Me.cboModel.TabIndex = 2
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Tahoma, 8" & _
            ".25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Sty" & _
            "le9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;" & _
            "AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Contr" & _
            "ol;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1.Win.C1List.Lis" & _
            "tBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" HorizontalScrollGr" & _
            "oup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height><VScrollBar><" & _
            "Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScrollBar><Captio" & _
            "nStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" " & _
            "/><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Styl" & _
            "e11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""H" & _
            "ighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRo" & _
            "wStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""RecordSelector" & _
            """ me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><Style parent=""N" & _
            "ormal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedStyles><Style pa" & _
            "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
            "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
            " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
            "e=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" " & _
            "me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Capti" & _
            "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
            "ts><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(40, 56)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(48, 16)
            Me.Label3.TabIndex = 123
            Me.Label3.Text = "Model:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(16, 120)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 16)
            Me.Label2.TabIndex = 121
            Me.Label2.Text = "ESN/IMEI:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtIMEI
            '
            Me.txtIMEI.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtIMEI.Location = New System.Drawing.Point(88, 120)
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(240, 21)
            Me.txtIMEI.TabIndex = 4
            Me.txtIMEI.Text = ""
            '
            'lblWarrantyStatus
            '
            Me.lblWarrantyStatus.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblWarrantyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWarrantyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 35.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWarrantyStatus.ForeColor = System.Drawing.Color.White
            Me.lblWarrantyStatus.Location = New System.Drawing.Point(257, 1)
            Me.lblWarrantyStatus.Name = "lblWarrantyStatus"
            Me.lblWarrantyStatus.Size = New System.Drawing.Size(519, 79)
            Me.lblWarrantyStatus.TabIndex = 139
            Me.lblWarrantyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel1
            '
            Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReOpenRMA, Me.btnCloseRMA, Me.txtRMA, Me.Label1, Me.btnNewRMA})
            Me.Panel1.Location = New System.Drawing.Point(368, 81)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(408, 40)
            Me.Panel1.TabIndex = 1
            '
            'btnReOpenRMA
            '
            Me.btnReOpenRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btnReOpenRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenRMA.ForeColor = System.Drawing.Color.White
            Me.btnReOpenRMA.Location = New System.Drawing.Point(360, 8)
            Me.btnReOpenRMA.Name = "btnReOpenRMA"
            Me.btnReOpenRMA.Size = New System.Drawing.Size(72, 20)
            Me.btnReOpenRMA.TabIndex = 4
            Me.btnReOpenRMA.Text = "Re-Open"
            '
            'btnCloseRMA
            '
            Me.btnCloseRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btnCloseRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseRMA.ForeColor = System.Drawing.Color.White
            Me.btnCloseRMA.Location = New System.Drawing.Point(280, 8)
            Me.btnCloseRMA.Name = "btnCloseRMA"
            Me.btnCloseRMA.Size = New System.Drawing.Size(56, 20)
            Me.btnCloseRMA.TabIndex = 3
            Me.btnCloseRMA.Text = "Close"
            '
            'txtRMA
            '
            Me.txtRMA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtRMA.Location = New System.Drawing.Point(48, 7)
            Me.txtRMA.Name = "txtRMA"
            Me.txtRMA.Size = New System.Drawing.Size(144, 21)
            Me.txtRMA.TabIndex = 1
            Me.txtRMA.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(-16, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 117
            Me.Label1.Text = "RMA # :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnNewRMA
            '
            Me.btnNewRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btnNewRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnNewRMA.ForeColor = System.Drawing.Color.White
            Me.btnNewRMA.Location = New System.Drawing.Point(208, 8)
            Me.btnNewRMA.Name = "btnNewRMA"
            Me.btnNewRMA.Size = New System.Drawing.Size(48, 20)
            Me.btnNewRMA.TabIndex = 2
            Me.btnNewRMA.Text = "New"
            '
            'dgOpenRMA
            '
            Me.dgOpenRMA.AllowUpdate = False
            Me.dgOpenRMA.AlternatingRows = True
            Me.dgOpenRMA.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.dgOpenRMA.Caption = "Open RMA"
            Me.dgOpenRMA.CaptionHeight = 17
            Me.dgOpenRMA.FilterBar = True
            Me.dgOpenRMA.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgOpenRMA.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.dgOpenRMA.Location = New System.Drawing.Point(0, 80)
            Me.dgOpenRMA.Name = "dgOpenRMA"
            Me.dgOpenRMA.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgOpenRMA.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgOpenRMA.PreviewInfo.ZoomFactor = 75
            Me.dgOpenRMA.Size = New System.Drawing.Size(368, 288)
            Me.dgOpenRMA.TabIndex = 3
            Me.dgOpenRMA.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;BackColor:CadetBlue;}Normal{Font:Microsoft San" & _
            "s Serif, 8.25pt;BackColor:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:" & _
            "Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10" & _
            "{AlignHorz:Near;}Style11{}OddRow{ForeColor:White;BackColor:CadetBlue;}Style13{}S" & _
            "tyle12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelector" & _
            "{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaption" & _
            "Text;BackColor:InactiveCaption;}EvenRow{ForeColor:White;BackColor:SteelBlue;}Hea" & _
            "ding{Wrap:True;Font:Tahoma, 8.25pt;BackColor:Teal;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:White;AlignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 8.25pt;ForeCo" & _
            "lor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;" & _
            "Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}S" & _
            "tyle2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alternatin" & _
            "gRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" D" & _
            "efRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>267" & _
            "</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edito" & _
            "r"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle pa" & _
            "rent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Grou" & _
            "pStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" " & _
            "/><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""" & _
            "Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelect" & _
            "orStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" " & _
            "me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 364, 267</" & _
            "ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C" & _
            "1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Styl" & _
            "e parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pa" & _
            "rent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style par" & _
            "ent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=" & _
            """Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent" & _
            "=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style par" & _
            "ent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles" & _
            "><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defau" & _
            "ltRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 364, 284</ClientArea><Pri" & _
            "ntPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""S" & _
            "tyle21"" /></Blob>"
            '
            'frmReceiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(792, 390)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblHeader, Me.gbDeviceInfo, Me.lblWarrantyStatus, Me.Panel1, Me.dgOpenRMA})
            Me.Name = "frmReceiving"
            Me.Text = "frmReceiving"
            Me.gbDeviceInfo.ResumeLayout(False)
            CType(Me.cboCostCenter, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgReceivedUnits, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            CType(Me.dgOpenRMA, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*************************************************************************************************************
        Private Sub frmReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                '*********************************
                'Load Open Order & Box Type
                '*********************************
                Me.LoadOpenWorkOrder()

                Buisness.Generic.DisposeDT(dt)
                dt = Me._objProdRec.GetModelList(True, Buisness.Jabil.PRODID, Buisness.Pantech.ManufID)
                Misc.PopulateC1DropDownList(Me.cboModel, dt, "Model_Desc", "Model_ID")
                Me.cboModel.SelectedValue = 0

                '*********************************
                _iWOID = 0 : _iTrayID = 0
                Me.txtRMA.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmReceiving_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub LoadCostCenter(ByVal iGroupID As Integer)
            Dim dt As DataTable

            Try
                'Populate cost center list
                dt = Me._objProdRec.GetCostCenterLists(True, iGroupID)
                Misc.PopulateC1DropDownList(Me.cboCostCenter, dt, "cc_desc", "cc_id")
                Me.cboCostCenter.SelectedValue = 0
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadCostCenter", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub LoadOpenWorkOrder()
            Dim dt As DataTable

            Try
                dt = Me._objProdRec.GetOpenWorkordersList(Buisness.Jabil.LOC_ID, False)
                dt.Columns("WO_CustWO").ColumnName = "RMA #" : dt.AcceptChanges()

                With Me.dgOpenRMA
                    .DataSource = dt.DefaultView

                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("WO Received Qty").Visible = False
                    .Splits(0).DisplayColumns("Loc_ID").Visible = False
                    .Splits(0).DisplayColumns("Group_ID").Visible = False
                    .Splits(0).DisplayColumns("Prod_ID").Visible = False
                    .Splits(0).DisplayColumns("PO_ID").Width = 55
                    .Splits(0).DisplayColumns("WO Qty").Width = 65
                    .Splits(0).DisplayColumns("RMA #").Width = 155
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub ClearRMAControlsAndVars()
            Try
                _iWOID = 0 : _iTrayID = 0

                Me.lblWarrantyStatus.Text = "" : Me.lblWarrantyStatus.BackColor = Color.SteelBlue

                'Device
                Me.cboModel.SelectedValue = 0
                Me.txtMechanicalSN.Text = ""
                Me.txtIMEI.Text = ""

                Me.dgReceivedUnits.DataSource = Nothing
                Me.lblRecQty.Text = "0"

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnNewRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewRMA.Click
            Try
                Me.txtRMA.Text = "" : Me.txtRMA.Enabled = True
                ClearRMAControlsAndVars() : Me.LoadCostCenter(0)
                Me.txtRMA.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnNewRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnCloseRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseRMA.Click
            Dim R1 As DataRow
            Dim i, iRecUnitCnt As Integer

            Try
                If Me._iTrayID = 0 Then
                    MessageBox.Show("Tray ID is missing for this RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                R1 = Me._objProdRec.GetWorkorderInfo(Me.txtRMA.Text.Trim, , Buisness.Jabil.LOC_ID)
                i = 0 : iRecUnitCnt = 0

                If IsNothing(R1) Then
                    MessageBox.Show("This RMA # '" & Me.txtRMA.Text.Trim & "' does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("WO_Closed") = 1 Then
                    MessageBox.Show("This RMA # '" & Me.txtRMA.Text.Trim & "' is already closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf R1("WO_Shipped") = 1 Then
                    MessageBox.Show("This RMA # '" & Me.txtRMA.Text.Trim & "' has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iRecUnitCnt = PSS.Data.Buisness.Generic.GetRecQty(R1("WO_ID"))
                    If iRecUnitCnt = 0 Then
                        MessageBox.Show("This RMA # '" & Me.txtRMA.Text.Trim & "' is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.CloseWO(R1("WO_ID"))
                        If i > 0 Then
                            'PSS.Data.Buisness.MessReceive.PrintRecReport(Me._iTrayID, 1)
                            Me.ClearRMAControlsAndVars() : Me.LoadOpenWorkOrder() : Me.LoadCostCenter(0)
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            Me.txtRMA.Enabled = True : Me.txtRMA.Text = "" : Me.txtRMA.Focus()
                            MessageBox.Show("RMA is closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub btnReOpenRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReOpenRMA.Click
            Dim R1 As DataRow
            Dim i As Integer = 0
            Dim strRMA As String = ""

            Try
                strRMA = InputBox("Enter RMA #:").Trim.ToUpper
                If strRMA.Trim.Length > 0 Then
                    Me.txtRMA.Text = "" : Me.ClearRMAControlsAndVars()

                    R1 = Me._objProdRec.GetWorkorderInfo(strRMA, , Buisness.Jabil.LOC_ID)

                    If IsNothing(R1) Then
                        MessageBox.Show("This RMA # " & Me.txtRMA.Text.Trim & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf R1("WO_Closed") = 0 Then
                        MessageBox.Show("This RMA # " & Me.txtRMA.Text.Trim & " is open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (Not IsDBNull(R1("WO_DateShip")) AndAlso R1("WO_DateShip").ToString.Trim.Length > 0) OrElse R1("WO_Shipped") = 1 Then
                        MessageBox.Show("This RMA # " & Me.txtRMA.Text.Trim & " has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.ReOpenWO(R1("WO_ID"))
                        If i > 0 Then
                            Me.LoadOpenWorkOrder() : Me.txtRMA.Text = strRMA : Me.ProcessRMA(strRMA)
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            MessageBox.Show("RMA is now open for receiving.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReOpenRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub Contrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboModel.KeyUp, txtIMEI.KeyUp, txtMechanicalSN.KeyUp, txtRMA.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "cboModel" Then
                        If Me.cboModel.SelectedValue > 0 Then
                            Me.txtMechanicalSN.SelectAll() : Me.txtMechanicalSN.Focus()
                        End If
                    ElseIf sender.name = "txtMechanicalSN" Then
                        If Me.txtMechanicalSN.Text.Trim.Length > 0 Then
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                        End If
                    ElseIf sender.name = "txtIMEI" Then
                        If Me.txtIMEI.Text.Trim.Length > 0 Then Me.ProcessIMEI()
                    ElseIf sender.name = "txtRMA" Then
                        If Me.txtRMA.Text.Trim.Length > 0 Then Me.ProcessRMA(Me.txtRMA.Text.Trim.ToUpper)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Contrls_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Sub Contrls_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMechanicalSN.KeyPress, txtIMEI.KeyPress
            Try
                If sender.name = "txtMechanicalSN" OrElse sender.name = "txtIMEI" Then
                    If Not Char.IsLetterOrDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Contrls_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function ProcessRMA(ByVal strRMANo As String) As Boolean
            Dim R1 As DataRow
            Dim dt As DataTable

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                R1 = Me._objProdRec.GetWorkorderInfo(Me.txtRMA.Text.Trim.ToUpper, , Buisness.Jabil.LOC_ID)
                If Not IsNothing(R1) Then
                    If R1("WO_Closed") = 1 Then
                        MessageBox.Show("This RMA has been closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.Enabled = True : Cursor.Current = Cursors.Default
                        Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                    Else
                        Me._iWOID = R1("WO_ID")
                        Me._iTrayID = Me._objProdRec.GetTrayID(Me._iWOID)
                        PopulateReceivedUnits(Me._iWOID)
                        If Not IsDBNull(R1("Group_ID")) Then Me.LoadCostCenter(R1("Group_ID")) Else Me.LoadCostCenter(0)

                        Me.txtRMA.Enabled = False

                        Me.Enabled = False : Me.cboCostCenter.SelectAll() : Me.cboCostCenter.Focus()
                    End If
                    'ElseIf MessageBox.Show("This is a new RMA. Would you like to create?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    '    Exit Function
                    'Else
                    '    If Me.CreateRMA() = True Then
                    '        Me.LoadOpenWorkOrder()
                    '        Me.txtRMA.Enabled = False

                    '        Me.Enabled = False : Me.cboCostCenter.SelectAll() : Me.cboCostCenter.Focus()
                    '    End If
                Else
                    MessageBox.Show("This is a new RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt) : R1 = Nothing
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Function

        '************************************************************************************************************
        Private Function CreateRMA() As Boolean
            Try
                CreateRMA = False

                If Me.txtRMA.Text.Trim.Length > 0 Then
                    Me.ClearRMAControlsAndVars()

                    Me._iWOID = Me._objProdRec.InsertIntoTworkorder(Me.txtRMA.Text.Trim, Me.txtRMA.Text.Trim, Buisness.Jabil.LOC_ID, Buisness.Jabil.PRODID, Buisness.Jabil.GROUPID, , , , , , )

                    If Me._iWOID = 0 Then
                        Throw New Exception("System has failed to create RMA.")
                    Else
                        Me._iTrayID = Me._objProdRec.GetTrayID(_iWOID)
                        If Me._iTrayID = 0 Then Me._iTrayID = Me._objProdRec.InsertIntoTtray(ApplicationUser.IDuser, ApplicationUser.User, _iWOID.ToString, )
                        If Me._iTrayID = 0 Then Throw New Exception("System has failed to create RMA.")
                        Return True
                    End If
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*************************************************************************************************************
        Private Sub PopulateReceivedUnits(ByVal iWOID As Integer)
            Dim dt As DataTable

            Try
                dt = Me._objProdRec.GetReceivedDeviceInWO(iWOID, True, False)
                dt.Columns("Device_SN").ColumnName = "IMEI"
                dt.Columns("Cellopt_MSN").ColumnName = "S/N"
                dt.AcceptChanges()

                With Me.dgReceivedUnits
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Cnt").Width = 55
                    .Splits(0).DisplayColumns("IMEI").Width = 150
                    .Splits(0).DisplayColumns("Model").Width = 200
                    .Splits(0).DisplayColumns("S/N").Width = 120
                End With

                Me.lblRecQty.Text = dt.Rows.Count

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*************************************************************************************************************
        Private Function ProcessIMEI() As Boolean
            Dim dtASN, dtDevice As DataTable
            Dim iPASN_ID, iManufWrty As Integer
            Dim objPantechRec As Buisness.Pantech

            Try
                If Me.txtRMA.Text.Trim.Length = 0 Then
                    Exit Function
                ElseIf Me._iWOID = 0 Then
                    MessageBox.Show("Order ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Tray ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll() : Me.txtRMA.Focus()
                ElseIf Me.txtIMEI.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter in IMEI number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.txtIMEI.Text.Trim.Length < 10 Then
                    MessageBox.Show("Invalid IMEI number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                ElseIf Me.cboModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModel.SelectAll() : Me.cboModel.Focus()
                ElseIf Me.txtMechanicalSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMechanicalSN.SelectAll() : Me.txtMechanicalSN.Focus()
                ElseIf Me.txtMechanicalSN.Text.Trim.Length < 9 Then
                    MessageBox.Show("Invalid S/N.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMechanicalSN.SelectAll() : Me.txtMechanicalSN.Focus()
                ElseIf Me.txtIMEI.Text.Trim.ToLower = Me.txtMechanicalSN.Text.Trim.ToLower Then
                    MessageBox.Show("S/N can't be the same with IMEI.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtMechanicalSN.SelectAll() : Me.txtMechanicalSN.Focus()
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    iPASN_ID = 0 : iManufWrty = 0

                    '**************************************
                    'Check for duplicate
                    '**************************************
                    dtDevice = Buisness.Generic.GetDeviceInfoInWIP(Me.txtIMEI.Text.Trim.ToUpper, Buisness.Jabil.CUSTOMER_ID, Buisness.Jabil.LOC_ID)
                    If dtDevice.Rows.Count > 0 Then
                        MessageBox.Show("Device is already existed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                    Else
                        objPantechRec = New Buisness.Pantech()
                        dtASN = objPantechRec.GetPantechASN(Me.txtRMA.Text.Trim, Me.txtIMEI.Text.Trim)
                        If dtASN.Rows.Count > 1 Then
                            MessageBox.Show("Duplicate record in asn file. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Me.txtIMEI.SelectAll() : Me.txtIMEI.Focus()
                        Else
                            If dtASN.Rows.Count > 0 Then iPASN_ID = Convert.ToInt32(dtASN.Rows(0)("PA_ID"))
                            iManufWrty = Me._objJabilRec.ReceiveUnit(Me._iWOID, Me._iTrayID, Me.cboModel.SelectedValue, Me.cboCostCenter.SelectedValue, _
                                                                     Me.txtIMEI.Text.Trim.ToUpper, Me.txtMechanicalSN.Text.Trim.ToUpper, ApplicationUser.IDuser, _
                                                                     ApplicationUser.IDShift, iPASN_ID, Me.txtRMA.Text.Trim.ToUpper, Me._objProdRec)

                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            If iManufWrty = 1 Then
                                Me.lblWarrantyStatus.Text = "IN WARRANTY"
                                Me.lblWarrantyStatus.BackColor = Color.SteelBlue
                            Else
                                Me.lblWarrantyStatus.Text = "OUT OF WARRANTY"
                                Me.lblWarrantyStatus.BackColor = Color.Purple
                            End If
                            Me.PopulateReceivedUnits(Me._iWOID)
                            Me.Enabled = True : Me.txtMechanicalSN.Text = "" : Me.txtIMEI.Text = "" : Me.txtMechanicalSN.Focus()
                        End If
                    End If 'Check device in wip
                End If 'check user input
            Catch ex As Exception
                Throw ex
            Finally
                objPantechRec = Nothing
                Buisness.Generic.DisposeDT(dtASN) : Buisness.Generic.DisposeDT(dtDevice)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Function

        '*************************************************************************************************************


    End Class
End Namespace