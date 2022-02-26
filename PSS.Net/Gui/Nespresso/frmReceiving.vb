Option Explicit On 

Imports PSS.Data
Imports PSS.Data.Buisness
Imports PSS.Core

Namespace Gui.Nespresso
    Public Class frmReceiving
        Inherits System.Windows.Forms.Form
        Private _objNespresso As New PSS.Data.Buisness.Nespresso.Nespresso()
        Private _objGP As New PSS.Data.Buisness.GenericProcess.clsGenericProcess()
        Private _objProdRec As New PSS.Data.Production.Receiving()
        Private _LocID = PSS.Data.Buisness.Nespresso.Nespresso.intLocID
        Private _MfgID = PSS.Data.Buisness.Nespresso.Nespresso.intMfgID
        Private _ProdID = PSS.Data.Buisness.Nespresso.Nespresso.intProdID
        Private _CusID = PSS.Data.Buisness.Nespresso.Nespresso.intCustID
        Private _iWOID As Integer = 0
        Private _iTrayID As Integer = 0
        Private _booPopDataToCombo As Boolean = False
        Private _booRecycle As Boolean = False

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
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents cboOpenSO As C1.Win.C1List.C1Combo
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents _Model As System.Windows.Forms.Label
        Friend WithEvents btnReOpenRMA As System.Windows.Forms.Button
        Friend WithEvents btnCloseRMA As System.Windows.Forms.Button
        Friend WithEvents _MfgSerial As System.Windows.Forms.Label
        Friend WithEvents _RMA As System.Windows.Forms.Label
        Friend WithEvents lblSerial As System.Windows.Forms.Label
        Friend WithEvents cboCostCenter As C1.Win.C1List.C1Combo
        Friend WithEvents _CostCenter As System.Windows.Forms.Label
        Friend WithEvents dgOpenRMA As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents dgReceivedUnits As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblRecQty As System.Windows.Forms.Label
        Friend WithEvents gbReceiveUnitsDetails As System.Windows.Forms.GroupBox
        Friend WithEvents btnPrintAllLabels As System.Windows.Forms.Button
        Friend WithEvents btnRePrintLabel As System.Windows.Forms.Button
        Friend WithEvents btnPrintLabel As System.Windows.Forms.Button
        Friend WithEvents _Tittle As System.Windows.Forms.Label
        Friend WithEvents pnlMain As System.Windows.Forms.Panel
        Friend WithEvents _Recycle As System.Windows.Forms.Label
        Friend WithEvents lblRecycleAlert As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmReceiving))
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me._MfgSerial = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me._Model = New System.Windows.Forms.Label()
            Me.cboOpenSO = New C1.Win.C1List.C1Combo()
            Me._RMA = New System.Windows.Forms.Label()
            Me._Tittle = New System.Windows.Forms.Label()
            Me.btnReOpenRMA = New System.Windows.Forms.Button()
            Me.btnCloseRMA = New System.Windows.Forms.Button()
            Me.dgOpenRMA = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblSerial = New System.Windows.Forms.Label()
            Me.cboCostCenter = New C1.Win.C1List.C1Combo()
            Me._CostCenter = New System.Windows.Forms.Label()
            Me.dgReceivedUnits = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblRecQty = New System.Windows.Forms.Label()
            Me.gbReceiveUnitsDetails = New System.Windows.Forms.GroupBox()
            Me.lblRecycleAlert = New System.Windows.Forms.Label()
            Me.btnPrintAllLabels = New System.Windows.Forms.Button()
            Me.btnRePrintLabel = New System.Windows.Forms.Button()
            Me.btnPrintLabel = New System.Windows.Forms.Button()
            Me.pnlMain = New System.Windows.Forms.Panel()
            Me._Recycle = New System.Windows.Forms.Label()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboOpenSO, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgOpenRMA, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCostCenter, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dgReceivedUnits, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbReceiveUnitsDetails.SuspendLayout()
            Me.pnlMain.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtSN
            '
            Me.txtSN.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.Location = New System.Drawing.Point(144, 136)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(176, 21)
            Me.txtSN.TabIndex = 108
            Me.txtSN.Text = ""
            '
            '_MfgSerial
            '
            Me._MfgSerial.BackColor = System.Drawing.Color.Transparent
            Me._MfgSerial.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._MfgSerial.ForeColor = System.Drawing.Color.White
            Me._MfgSerial.Location = New System.Drawing.Point(8, 136)
            Me._MfgSerial.Name = "_MfgSerial"
            Me._MfgSerial.Size = New System.Drawing.Size(130, 21)
            Me._MfgSerial.TabIndex = 117
            Me._MfgSerial.Text = "Mfg. Serial :"
            Me._MfgSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.AutoCompletion = True
            Me.cboModels.AutoDropDown = True
            Me.cboModels.AutoSelect = True
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ColumnHeaders = False
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(144, 88)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(176, 21)
            Me.cboModels.TabIndex = 107
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Align" & _
            "Image:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fore" & _
            "Color:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:N" & _
            "ear;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            '_Model
            '
            Me._Model.BackColor = System.Drawing.Color.Transparent
            Me._Model.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._Model.ForeColor = System.Drawing.Color.White
            Me._Model.Location = New System.Drawing.Point(8, 88)
            Me._Model.Name = "_Model"
            Me._Model.Size = New System.Drawing.Size(130, 21)
            Me._Model.TabIndex = 116
            Me._Model.Text = "Model :"
            Me._Model.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboOpenSO
            '
            Me.cboOpenSO.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenSO.AutoCompletion = True
            Me.cboOpenSO.AutoDropDown = True
            Me.cboOpenSO.AutoSelect = True
            Me.cboOpenSO.Caption = ""
            Me.cboOpenSO.CaptionHeight = 17
            Me.cboOpenSO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenSO.ColumnCaptionHeight = 17
            Me.cboOpenSO.ColumnFooterHeight = 17
            Me.cboOpenSO.ColumnHeaders = False
            Me.cboOpenSO.ContentHeight = 15
            Me.cboOpenSO.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenSO.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenSO.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenSO.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenSO.EditorHeight = 15
            Me.cboOpenSO.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboOpenSO.ItemHeight = 15
            Me.cboOpenSO.Location = New System.Drawing.Point(144, 48)
            Me.cboOpenSO.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenSO.MaxDropDownItems = CType(10, Short)
            Me.cboOpenSO.MaxLength = 32767
            Me.cboOpenSO.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenSO.Name = "cboOpenSO"
            Me.cboOpenSO.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenSO.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenSO.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenSO.Size = New System.Drawing.Size(176, 21)
            Me.cboOpenSO.TabIndex = 106
            Me.cboOpenSO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:HotTrack;}Style3{}Inactive{ForeColor:InactiveCaptionText;Bac" & _
            "kColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{F" & _
            "oreColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Recor" & _
            "dSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1" & _
            ", 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}Sty" & _
            "le1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" N" & _
            "ame=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 15" & _
            "6</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HSc" & _
            "rollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style9" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" me" & _
            "=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Head" & _
            "ing"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inact" & _
            "iveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style8" & _
            """ /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle p" & _
            "arent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1L" & _
            "ist.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
            """Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
            "ing"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><v" & _
            "ertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Defa" & _
            "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            '_RMA
            '
            Me._RMA.BackColor = System.Drawing.Color.Transparent
            Me._RMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._RMA.ForeColor = System.Drawing.Color.White
            Me._RMA.Location = New System.Drawing.Point(8, 48)
            Me._RMA.Name = "_RMA"
            Me._RMA.Size = New System.Drawing.Size(130, 21)
            Me._RMA.TabIndex = 113
            Me._RMA.Text = "RMA :"
            Me._RMA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            '_Tittle
            '
            Me._Tittle.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me._Tittle.BackColor = System.Drawing.Color.Black
            Me._Tittle.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._Tittle.ForeColor = System.Drawing.Color.Yellow
            Me._Tittle.Name = "_Tittle"
            Me._Tittle.Size = New System.Drawing.Size(944, 48)
            Me._Tittle.TabIndex = 120
            Me._Tittle.Text = "Nespresso Receiving"
            Me._Tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReOpenRMA
            '
            Me.btnReOpenRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btnReOpenRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReOpenRMA.ForeColor = System.Drawing.Color.White
            Me.btnReOpenRMA.Location = New System.Drawing.Point(224, 176)
            Me.btnReOpenRMA.Name = "btnReOpenRMA"
            Me.btnReOpenRMA.Size = New System.Drawing.Size(96, 32)
            Me.btnReOpenRMA.TabIndex = 123
            Me.btnReOpenRMA.Text = "Re-Open"
            '
            'btnCloseRMA
            '
            Me.btnCloseRMA.BackColor = System.Drawing.Color.CadetBlue
            Me.btnCloseRMA.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseRMA.ForeColor = System.Drawing.Color.White
            Me.btnCloseRMA.Location = New System.Drawing.Point(24, 176)
            Me.btnCloseRMA.Name = "btnCloseRMA"
            Me.btnCloseRMA.Size = New System.Drawing.Size(88, 32)
            Me.btnCloseRMA.TabIndex = 122
            Me.btnCloseRMA.Text = "Close"
            '
            'dgOpenRMA
            '
            Me.dgOpenRMA.AllowUpdate = False
            Me.dgOpenRMA.AlternatingRows = True
            Me.dgOpenRMA.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgOpenRMA.Caption = "Open RMA"
            Me.dgOpenRMA.CaptionHeight = 17
            Me.dgOpenRMA.FilterBar = True
            Me.dgOpenRMA.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgOpenRMA.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.dgOpenRMA.Location = New System.Drawing.Point(24, 216)
            Me.dgOpenRMA.Name = "dgOpenRMA"
            Me.dgOpenRMA.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgOpenRMA.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgOpenRMA.PreviewInfo.ZoomFactor = 75
            Me.dgOpenRMA.Size = New System.Drawing.Size(296, 288)
            Me.dgOpenRMA.TabIndex = 124
            Me.dgOpenRMA.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 8.25pt, style=Bold;AlignHorz:Center;ForeColor:Lime" & _
            "Green;BackColor:Black;}Normal{BackColor:SteelBlue;}Selected{ForeColor:HighlightT" & _
            "ext;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{}Style16{}St" & _
            "yle17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:LightSteelBlue;}Style13" & _
            "{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelec" & _
            "tor{AlignImage:Center;}Footer{ForeColor:Lime;BackColor:Black;}Style21{}Style20{}" & _
            "Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackCo" & _
            "lor:NavajoWhite;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75" & _
            "pt, style=Bold;ForeColor:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Gr" & _
            "oup{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Styl" & _
            "e6{}Style1{}Style3{}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeVi" & _
            "ew Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17" & _
            """ ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" Recor" & _
            "dSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScroll" & _
            "Group=""1""><Height>267</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><Edit" & _
            "orStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8""" & _
            " /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer" & _
            """ me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""" & _
            "Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><I" & _
            "nactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""St" & _
            "yle9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedSty" & _
            "le parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientR" & _
            "ect>0, 17, 292, 267</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</B" & _
            "orderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent=""" & _
            """ me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me" & _
            "=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""I" & _
            "nactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Edi" & _
            "tor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""Eve" & _
            "nRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordS" & _
            "elector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""G" & _
            "roup"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layou" & _
            "t>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 292," & _
            " 284</ClientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooter" & _
            "Style parent="""" me=""Style21"" /></Blob>"
            '
            'lblSerial
            '
            Me.lblSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSerial.Location = New System.Drawing.Point(8, 568)
            Me.lblSerial.Name = "lblSerial"
            Me.lblSerial.Size = New System.Drawing.Size(184, 24)
            Me.lblSerial.TabIndex = 125
            Me.lblSerial.Text = "lblSerial"
            Me.lblSerial.Visible = False
            '
            'cboCostCenter
            '
            Me.cboCostCenter.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCostCenter.AutoCompletion = True
            Me.cboCostCenter.AutoDropDown = True
            Me.cboCostCenter.AutoSelect = True
            Me.cboCostCenter.Caption = ""
            Me.cboCostCenter.CaptionHeight = 17
            Me.cboCostCenter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCostCenter.ColumnCaptionHeight = 17
            Me.cboCostCenter.ColumnFooterHeight = 17
            Me.cboCostCenter.ContentHeight = 15
            Me.cboCostCenter.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCostCenter.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCostCenter.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.cboCostCenter.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCostCenter.EditorHeight = 15
            Me.cboCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCostCenter.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboCostCenter.ItemHeight = 15
            Me.cboCostCenter.Location = New System.Drawing.Point(144, 8)
            Me.cboCostCenter.MatchEntryTimeout = CType(2000, Long)
            Me.cboCostCenter.MaxDropDownItems = CType(5, Short)
            Me.cboCostCenter.MaxLength = 32767
            Me.cboCostCenter.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCostCenter.Name = "cboCostCenter"
            Me.cboCostCenter.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCostCenter.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCostCenter.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCostCenter.Size = New System.Drawing.Size(176, 21)
            Me.cboCostCenter.TabIndex = 130
            Me.cboCostCenter.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            '_CostCenter
            '
            Me._CostCenter.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold)
            Me._CostCenter.ForeColor = System.Drawing.Color.White
            Me._CostCenter.Location = New System.Drawing.Point(16, 16)
            Me._CostCenter.Name = "_CostCenter"
            Me._CostCenter.Size = New System.Drawing.Size(120, 16)
            Me._CostCenter.TabIndex = 131
            Me._CostCenter.Text = "Cost Center:"
            Me._CostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dgReceivedUnits
            '
            Me.dgReceivedUnits.AllowUpdate = False
            Me.dgReceivedUnits.AlternatingRows = True
            Me.dgReceivedUnits.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dgReceivedUnits.Caption = "Received Units"
            Me.dgReceivedUnits.CaptionHeight = 17
            Me.dgReceivedUnits.FilterBar = True
            Me.dgReceivedUnits.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
            Me.dgReceivedUnits.GroupByCaption = "Drag a column header here to group by that column"
            Me.dgReceivedUnits.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.dgReceivedUnits.Location = New System.Drawing.Point(8, 83)
            Me.dgReceivedUnits.Name = "dgReceivedUnits"
            Me.dgReceivedUnits.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dgReceivedUnits.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dgReceivedUnits.PreviewInfo.ZoomFactor = 75
            Me.dgReceivedUnits.Size = New System.Drawing.Size(560, 397)
            Me.dgReceivedUnits.TabIndex = 132
            Me.dgReceivedUnits.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{Font:Tahoma, 8.25pt, style=Bold;AlignHorz:Center;ForeColor:Lime" & _
            "Green;BackColor:Black;}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:SteelB" & _
            "lue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style18{}Styl" & _
            "e19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow" & _
            "{BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style21{}Style2" & _
            "0{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{Bac" & _
            "kColor:NavajoWhite;}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt;BackColo" & _
            "r:Control;Border:Raised,,1, 1, 1, 1;ForeColor:64, 0, 64;AlignVert:Center;}Filter" & _
            "Bar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor:Red;BackColor:White;" & _
            "}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;" & _
            "BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><" & _
            "Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRowStyle=""True"" Caption" & _
            "Height=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" Ma" & _
            "rqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Verti" & _
            "calScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>376</Height><CaptionStyle p" & _
            "arent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRo" & _
            "wStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Sty" & _
            "le13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me" & _
            "=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle par" & _
            "ent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" />" & _
            "<OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSe" & _
            "lector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style par" & _
            "ent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 556, 376</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 556, 393</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Black
            Me.Label5.ForeColor = System.Drawing.Color.Green
            Me.Label5.Location = New System.Drawing.Point(232, 24)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(96, 16)
            Me.Label5.TabIndex = 134
            Me.Label5.Text = "Received Qty"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblRecQty
            '
            Me.lblRecQty.BackColor = System.Drawing.Color.Black
            Me.lblRecQty.Font = New System.Drawing.Font("Tahoma", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecQty.ForeColor = System.Drawing.Color.Green
            Me.lblRecQty.Location = New System.Drawing.Point(232, 40)
            Me.lblRecQty.Name = "lblRecQty"
            Me.lblRecQty.Size = New System.Drawing.Size(96, 40)
            Me.lblRecQty.TabIndex = 133
            Me.lblRecQty.Text = "0"
            Me.lblRecQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'gbReceiveUnitsDetails
            '
            Me.gbReceiveUnitsDetails.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.gbReceiveUnitsDetails.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
            Me.gbReceiveUnitsDetails.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRecycleAlert, Me.btnPrintAllLabels, Me.btnRePrintLabel, Me.lblRecQty, Me.Label5, Me.dgReceivedUnits})
            Me.gbReceiveUnitsDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbReceiveUnitsDetails.ForeColor = System.Drawing.Color.White
            Me.gbReceiveUnitsDetails.Location = New System.Drawing.Point(336, 8)
            Me.gbReceiveUnitsDetails.Name = "gbReceiveUnitsDetails"
            Me.gbReceiveUnitsDetails.Size = New System.Drawing.Size(584, 496)
            Me.gbReceiveUnitsDetails.TabIndex = 135
            Me.gbReceiveUnitsDetails.TabStop = False
            '
            'lblRecycleAlert
            '
            Me.lblRecycleAlert.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecycleAlert.ForeColor = System.Drawing.Color.Red
            Me.lblRecycleAlert.Location = New System.Drawing.Point(8, 16)
            Me.lblRecycleAlert.Name = "lblRecycleAlert"
            Me.lblRecycleAlert.Size = New System.Drawing.Size(216, 56)
            Me.lblRecycleAlert.TabIndex = 137
            Me.lblRecycleAlert.Text = "Recycle alert !"
            '
            'btnPrintAllLabels
            '
            Me.btnPrintAllLabels.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.btnPrintAllLabels.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintAllLabels.ForeColor = System.Drawing.Color.White
            Me.btnPrintAllLabels.Location = New System.Drawing.Point(376, 48)
            Me.btnPrintAllLabels.Name = "btnPrintAllLabels"
            Me.btnPrintAllLabels.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnPrintAllLabels.Size = New System.Drawing.Size(176, 30)
            Me.btnPrintAllLabels.TabIndex = 136
            Me.btnPrintAllLabels.Text = "RE-PRINT ALL LABELS"
            Me.btnPrintAllLabels.Visible = False
            '
            'btnRePrintLabel
            '
            Me.btnRePrintLabel.BackColor = System.Drawing.Color.LimeGreen
            Me.btnRePrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRePrintLabel.ForeColor = System.Drawing.Color.White
            Me.btnRePrintLabel.Location = New System.Drawing.Point(376, 16)
            Me.btnRePrintLabel.Name = "btnRePrintLabel"
            Me.btnRePrintLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRePrintLabel.Size = New System.Drawing.Size(176, 30)
            Me.btnRePrintLabel.TabIndex = 135
            Me.btnRePrintLabel.Text = "RE-PRINT LAST LABEL"
            '
            'btnPrintLabel
            '
            Me.btnPrintLabel.BackColor = System.Drawing.Color.CadetBlue
            Me.btnPrintLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrintLabel.ForeColor = System.Drawing.Color.White
            Me.btnPrintLabel.Location = New System.Drawing.Point(120, 176)
            Me.btnPrintLabel.Name = "btnPrintLabel"
            Me.btnPrintLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnPrintLabel.Size = New System.Drawing.Size(96, 32)
            Me.btnPrintLabel.TabIndex = 137
            Me.btnPrintLabel.Text = "Print Label"
            '
            'pnlMain
            '
            Me.pnlMain.Controls.AddRange(New System.Windows.Forms.Control() {Me._Recycle, Me._CostCenter, Me._RMA, Me.btnReOpenRMA, Me.cboOpenSO, Me.btnCloseRMA, Me.txtSN, Me._Model, Me.btnPrintLabel, Me._MfgSerial, Me.cboCostCenter, Me.cboModels, Me.gbReceiveUnitsDetails, Me.dgOpenRMA})
            Me.pnlMain.Location = New System.Drawing.Point(0, 48)
            Me.pnlMain.Name = "pnlMain"
            Me.pnlMain.Size = New System.Drawing.Size(936, 512)
            Me.pnlMain.TabIndex = 138
            '
            '_Recycle
            '
            Me._Recycle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._Recycle.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
            Me._Recycle.Location = New System.Drawing.Point(144, 112)
            Me._Recycle.Name = "_Recycle"
            Me._Recycle.Size = New System.Drawing.Size(168, 16)
            Me._Recycle.TabIndex = 138
            Me._Recycle.Text = "Recycle Model"
            Me._Recycle.Visible = False
            '
            'frmReceiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(936, 574)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlMain, Me._Tittle, Me.lblSerial})
            Me.Name = "frmReceiving"
            Me.Text = "frmReceiving"
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboOpenSO, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgOpenRMA, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCostCenter, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dgReceivedUnits, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbReceiveUnitsDetails.ResumeLayout(False)
            Me.pnlMain.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Loading Events"

        Private Sub frmReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                LoadDefault()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            End Try
        End Sub

        '********************************************************************************************************
        Private Sub LoadDefault()
            Try
                'Loading Default values at start up
                Me.LoadOpenRMA()
                Me.cboOpenSO.SelectedValue = 0
                Me.LoadModels()
                Me.cboModels.SelectedValue = 0
                Me.btnPrintAllLabels.Visible = False
                Me.btnRePrintLabel.Visible = False
                Me.lblRecycleAlert.Text = ""
                Me.txtSN.Text = ""
                Me.LoadCostCenter()
                Me.cboCostCenter.SelectedValue = 0
                Me.cboCostCenter.Focus()
                Me.txtSN.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_LoadDefault", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            End Try
        End Sub

        '********************************************************************************************************

        Private Sub LoadCostCenter()
            Dim dt As DataTable
            Try
                'Populate cost center list
                Me._booPopDataToCombo = True
                Me.cboCostCenter.DataSource = Nothing : Me.cboCostCenter.Text = ""
                dt = Me._objProdRec.GetCostCenterLists(True, 94)
                Misc.PopulateC1DropDownList(Me.cboCostCenter, dt, "cc_desc", "cc_id")
                Me.cboCostCenter.SelectedValue = 0
                _booPopDataToCombo = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving__LoadCostCenter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub
        '********************************************************************************************************
        Private Sub LoadOpenRMA()
            Dim dt As DataTable
            Try

                Me._booPopDataToCombo = True
                Me.cboOpenSO.DataSource = Nothing : Me.cboOpenSO.Text = ""
                dt = Me._objNespresso.GetOpenWorkOrder(True)
                Misc.PopulateC1DropDownList(Me.cboOpenSO, dt, "WO_CustWO", "WO_ID")
                Me.cboOpenSO.SelectedValue = 0

                dt = Me._objProdRec.GetOpenWorkordersList(Me._LocID, False)
                dt.Columns("WO_CustWO").ColumnName = "RMA #" : dt.AcceptChanges()

                With Me.dgOpenRMA
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("WO_ID").Visible = False
                    .Splits(0).DisplayColumns("WO Received Qty").Visible = False
                    .Splits(0).DisplayColumns("Loc_ID").Visible = False
                    .Splits(0).DisplayColumns("Group_ID").Visible = False
                    .Splits(0).DisplayColumns("Prod_ID").Visible = False
                    .Splits(0).DisplayColumns("PO_ID").Width = 40
                    .Splits(0).DisplayColumns("WO Qty").Width = 50
                    .Splits(0).DisplayColumns("RMA #").Width = 100
                End With

                Me._booPopDataToCombo = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_LoadOpenSO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub
        '********************************************************************************************************

        Private Sub LoadModels()
            Dim dt As DataTable
            Try

                Me._booPopDataToCombo = True
                Me.cboModels.DataSource = Nothing : Me.cboModels.Text = ""
                dt = Me._objNespresso.GetModelsList(True)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
                Me.cboModels.SelectedValue = 0
                _booPopDataToCombo = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_LoadModels", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                _booPopDataToCombo = False
                Generic.DisposeDT(dt)
            End Try
        End Sub
        '*************************************************************************************************************
        Private Sub LoadReceivedUnits()
            Dim dt As DataTable

            Try
                dt = Me._objNespresso.GetReceivedDeviceInWO(Me._iWOID)
                With Me.dgReceivedUnits
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Item#").Width = 40
                    .Splits(0).DisplayColumns("RMA#").Width = 100
                    .Splits(0).DisplayColumns("Model").Width = 85
                    .Splits(0).DisplayColumns("Serial").Width = 100
                    .Splits(0).DisplayColumns("Mfg. Serial").Width = 100
                    .Splits(0).DisplayColumns("Received Date").Width = 85
                End With
                Me.lblRecQty.Text = dt.Rows.Count
                If dt.Rows.Count > 0 Then
                    Me.btnPrintAllLabels.Visible = True
                Else
                    Me.btnPrintAllLabels.Visible = False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        '********************************************************************************************************

#End Region

#Region "Buttons Events"

        '********************************************************************************************************
        Private Sub btnCloseRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseRMA.Click
            Dim dr As DataRow
            Dim i, iRecUnitCnt As Integer

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                If cboOpenSO.SelectedValue = 0 Then Exit Sub

                If Me._iTrayID = 0 Then
                    MessageBox.Show("Tray ID is missing for this RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure you want to close RMA#" & cboOpenSO.Text & " ?", "Close RMA", _
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Exit Sub
                End If

                dr = Me._objProdRec.GetWorkorderInfo(Me.cboOpenSO.Text.Trim, Me._LocID)
                i = 0 : iRecUnitCnt = 0

                If IsNothing(dr) Then
                    MessageBox.Show("This RMA # '" & Me.cboOpenSO.Text.Trim & "' does not exist in the system. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dr("WO_Closed") = 1 Then
                    MessageBox.Show("This RMA # '" & Me.cboOpenSO.Text.Trim & "' is already closed. Please refresh your screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf dr("WO_Shipped") = 1 Then
                    MessageBox.Show("This RMA # '" & Me.cboOpenSO.Text.Trim & "' has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    iRecUnitCnt = PSS.Data.Buisness.Generic.GetRecQty(dr("WO_ID"))
                    If iRecUnitCnt = 0 Then
                        MessageBox.Show("This RMA # '" & Me.cboOpenSO.Text.Trim & "' is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.CloseWO(dr("WO_ID"))
                        If i > 0 Then
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            Me.LoadOpenRMA()
                            Me.cboOpenSO.Focus()
                            MessageBox.Show("RMA is closed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_btnCloseRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
        '********************************************************************************************************
        Private Sub btnReOpenRMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReOpenRMA.Click
            Dim dr As DataRow
            Dim i As Integer = 0
            Dim strRMA As String = ""

            Try

                strRMA = InputBox("Enter RMA #:").Trim.ToUpper
                If strRMA.Trim.Length > 0 Then

                    dr = Me._objProdRec.GetWorkorderInfo(strRMA, , Me._LocID)

                    If IsNothing(dr) Then
                        MessageBox.Show("This RMA # " & strRMA & " does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dr("WO_Closed") = 0 Then
                        MessageBox.Show("This RMA # " & strRMA & " is open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf (Not IsDBNull(dr("WO_DateShip")) AndAlso dr("WO_DateShip").ToString.Trim.Length > 0) OrElse dr("WO_Shipped") = 1 Then
                        MessageBox.Show("This RMA # " & strRMA & " has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                        i = PSS.Data.Buisness.Generic.ReOpenWO(dr("WO_ID"))
                        If i > 0 Then
                            Me.LoadOpenRMA()
                            Me.cboOpenSO.Text = strRMA : Me.cboOpenSO.Focus()
                            Me.Enabled = True : Cursor.Current = Cursors.Default
                            MessageBox.Show("RMA is now open for receiving.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.btnReOpenRMA_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
        '********************************************************************************************************
        Private Sub btnPrintAllLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAllLabels.Click
            Dim i, imax As Integer
            Dim strSN As String = ""

            Try
                imax = dgReceivedUnits.RowCount()

                If MessageBox.Show("Are you sure you want to reprint all " & imax & " received device labels?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                For i = 1 To imax - 1
                    strSN = Me.dgReceivedUnits.Columns(0).CellValue(i)
                    Me._objNespresso.Label_PrintReceivingLabel(strSN)
                Next

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.btnPrintAllLabels_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try



        End Sub
        '********************************************************************************************************
        Private Sub btnRePrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRePrintLabel.Click

            Try

                If lblSerial.Text.Trim.Length > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me._objNespresso.Label_PrintReceivingLabel(lblSerial.Text)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.btnRePrintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub


        '********************************************************************************************************

        Private Sub btnPrintLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLabel.Click
            Dim dt As DataTable
            Dim strSN As String = ""

            Try
                strSN = InputBox("Enter Serial #:").Trim.ToUpper

                If strSN.Trim.Length > 0 Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    dt = Me._objNespresso.GetDeviceInfo(strSN, Me._LocID)
                    If dt.Rows.Count > 0 Then
                        Me._objNespresso.Label_PrintReceivingLabel(strSN)
                    Else
                        MessageBox.Show("Serial#" & strSN & " is not found in the system.", "Serial is not found !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                Else
                    MessageBox.Show("Please enter serial number !", "Invalid Serial Number !", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.btnPrintLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try

        End Sub
        '********************************************************************************************************


#End Region

#Region "Text and Combo Box Events"

        '********************************************************************************************************
        Private Sub Contrls_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp

            Try
                If sender.name = "txtSN" And e.KeyCode = Keys.Enter Then
                    ProcessSN()
                    Me.txtSN.Text = "" : Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_Contrls_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        '********************************************************************************************************

        Private Sub cbo_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCostCenter.RowChange, cboOpenSO.RowChange, cboModels.RowChange

            Try
                If Me._booPopDataToCombo = False Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.txtSN.Enabled = False
                    Me.lblRecycleAlert.Text = ""

                    If sender.name = "cboCostCenter" Then
                        If Me.cboCostCenter.SelectedValue = 0 Then Exit Sub
                        cboOpenSO.Focus()
                    ElseIf sender.name = "cboOpenSO" Then

                        If Me.cboOpenSO.SelectedValue = 0 Then Exit Sub
                        Me._iWOID = Me.cboOpenSO.SelectedValue
                        Me._iTrayID = Me._objProdRec.GetTrayID(Me._iWOID)
                        Me.LoadReceivedUnits()
                        cboModels.Focus()
                    ElseIf sender.name = "cboModels" Then

                        If Me.cboModels.SelectedValue = 0 Then Exit Sub
                        ' Me._booRecycle = Me._objNespresso.GetRecycle(cboModels.SelectedValue)
                        Me._booRecycle = Me.cboModels.DataSource.Table.Select("Model_ID = " & Me.cboModels.SelectedValue)(0)("Recycle")
                        Me._Recycle.Visible = Me._booRecycle
                    End If


                    If Me.cboModels.SelectedValue > 0 And Me.cboCostCenter.SelectedValue > 0 And Me.cboOpenSO.SelectedValue > 0 Then
                        Me.txtSN.Enabled = True
                        Me.txtSN.SelectAll()
                        Me.txtSN.Focus()
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbo_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub
        '*************************************************************************************************************


#End Region

#Region "Functions & Subs"
        '********************************************************************************************************
        Private Function ProcessSN() As Boolean
            Dim i As Integer = 0
            Dim StrSN, StrMfgSN, strWorkDate As String
            Dim iCCID, iModel, iASNDataID, iShiftID, iCnt, iDeviceID, iPalletID As Integer
            Dim dt As DataTable
            Dim booResult As Boolean = False

            Try

                Me.txtSN.Text = Me.txtSN.Text.Trim.ToUpper()
                StrMfgSN = Me.txtSN.Text

                If StrMfgSN.Length < 1 Then
                    If MessageBox.Show("Are you sure you want to receive without Mfg. Serial Number?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Function
                Else
                    'Prevent duplicate Mfg. Serial
                    dt = Me._objNespresso.GetMfgDeviceInfo(StrMfgSN, Me._LocID)
                    If dt.Rows.Count > 0 Then
                        MessageBox.Show("Mfg. Serial#" & Me.txtSN.Text & " has been entered.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        Exit Function
                    End If
                End If

                Me.btnRePrintLabel.Visible = False

                If Me.cboCostCenter.SelectedValue = 0 Then
                    MessageBox.Show("Please select Cost Center.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me.cboOpenSO.SelectedValue = 0 Then
                    MessageBox.Show("Please select RMA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    lblSerial.Text = Me._objNespresso.GetNextSerial.ToUpper
                    StrSN = lblSerial.Text
                    If Me._iTrayID = 0 Then
                        Me._iTrayID = Me._objProdRec.InsertIntoTtray(PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, Me._iWOID, "Insert From PSSNet Nespresso Receiving")
                    End If
                    iCCID = Me.cboCostCenter.SelectedValue
                    iModel = Me.cboModels.SelectedValue
                    iShiftID = PSS.Core.ApplicationUser.IDShift
                    strWorkDate = Generic.GetWorkDate(iShiftID)
                    iCnt = Me._objProdRec.GetNextDeviceCountInTray(Me._iTrayID) + 1

                    'New Serial insertion   
                    iDeviceID = Me._objProdRec.InsertIntoTdevice(StrSN, strWorkDate, iCnt, Me._iTrayID, Me._LocID, Me._iWOID, iModel, iShiftID, , , , iCCID)
                    If iDeviceID < 1 Then
                        MessageBox.Show("System has failed to insert Serial#" & StrSN & " to tdevice. Please Try again ...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        booResult = False
                    Else
                        iASNDataID = _objGP.InsertUpdateAsnData(Me._iWOID, Me._LocID, iModel, iDeviceID, "", "", "", StrSN, StrMfgSN, "", "", "", 0, 0, PSS.Core.ApplicationUser.IDuser, )
                        If iASNDataID < 1 Then
                            MessageBox.Show("System has failed to insert Serial#" & StrSN & " to tAsnData. Please contact IT immediately...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            booResult = False
                        Else
                            Me._objNespresso.Label_PrintReceivingLabel(StrSN)
                            Me.btnRePrintLabel.Visible = True
                            Me.LoadReceivedUnits()

                            If (Me._booRecycle) Then
                                'Create billing for recycle device; BillCode_ID = 2133
                                If Generic.IsBillcodeMapped(iModel, 2133) = 0 Then
                                    MessageBox.Show("Device  serial#" & Me.txtSN.Text & " has not mapped billing recycle. Please contact Material department", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                    Exit Function
                                ElseIf Generic.IsBillcodeExisted(iDeviceID, 2133) = False Then
                                    Dim objDevice As Rules.Device
                                    objDevice = New Rules.Device(iDeviceID)
                                    objDevice.AddPart(2133)
                                    objDevice.Update()
                                    If Not objDevice Is Nothing Then objDevice = Nothing
                                End If

                                'Create/Insert recycle pallet
                                Dim StrPalletName As String
                                dt = Me._objNespresso.GetOpenRecyclePallet(Me._LocID, Me._CusID)
                                If dt.Rows.Count = 0 Then
                                    iPalletID = Me.CreateRecyclePallet()
                                    dt = Me._objNespresso.GetOpenRecyclePallet(Me._LocID, Me._CusID)
                                Else
                                    iPalletID = dt.Rows(0)("Pallett_ID")
                                End If
                                StrPalletName = dt.Rows(0)("Pallett_Name")
                                PSS.Data.Production.Shipping.AssignDeviceToPallet(iDeviceID, iPalletID)
                                lblRecycleAlert.ForeColor = Color.Red
                                lblRecycleAlert.Text = "Serial#" & StrSN & " has been assigned to Recycle Pallet#" & StrPalletName & ". Please move this device to recycle area."
                            Else
                                lblRecycleAlert.ForeColor = Color.Blue
                                lblRecycleAlert.Text = "Serial#" & StrSN & " has been generated..."
                            End If

                            Me.txtSN.Text = "" : Me.txtSN.Focus()

                            booResult = True

                        End If 'iASNDataID

                    End If 'iDeviceID

                    Return booResult

                End If 'Me.cboCostCenter.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                ProcessSN = False
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try

        End Function

        '********************************************************************************************************
        '********************************************************************************************************
        Private Function CreateRecyclePallet() As Integer

            Dim objShip As New PSS.Data.Production.Shipping()
            Dim objMisc As New PSS.Data.Buisness.Misc()
            Dim iPalletID As Integer
            Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
            Dim strdate As String = Format(CDate(strWorkDate), "MMddyy")
            Dim strPalletName, strLastAlphaInPallet As String
            Dim strShortCustDesc As String = PSS.Data.Buisness.Nespresso.Nespresso.ShortCustDesc
            Dim strShortModelName As String = Trim(objMisc.GetShortModelName(Me.cboModels.SelectedValue))
            Const iPalletTypeID As Integer = 7  '7=Recycle
            Const iPalletBillRuleID As Integer = 1  '1=Recycle
            Const SkuLen As String = ""           'SKU is not use for Recycle device

            Try

                strLastAlphaInPallet = objMisc.GetLastCharFromPalletName(strShortCustDesc & strShortModelName, strdate)
                strPalletName = "NESCYL" & strdate & strLastAlphaInPallet
                iPalletID = objShip.CreatePallet(Me._CusID, Me._LocID, Me.cboModels.SelectedValue, 0, strPalletName, iPalletBillRuleID, SkuLen, 0, 0, iPalletTypeID)
                If iPalletID = 0 Then
                    MessageBox.Show("System has failed to create Recycle Pallet. Please contact IT immediately.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    'Close Recyle Pallet to prevent operator scan other serials into this box in frmBuildShipBox screen
                    objMisc.ClosePallet(Me._CusID, iPalletID, strPalletName, 0, )
                End If

                Return iPalletID

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Gui.Nespresso.frmReceiving_CreateRecyclePallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                CreateRecyclePallet = 0

            Finally
                objMisc = Nothing
                objShip = Nothing
            End Try

        End Function

        '********************************************************************

        '********************************************************************

#End Region

    End Class
End Namespace