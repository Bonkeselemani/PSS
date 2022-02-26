Option Explicit On 

Imports PSS.Data.Buisness
Imports System.IO
Imports System.Text

Namespace Gui
	Public Class frmMessEvaluation
		Inherits System.Windows.Forms.Form

#Region "DECLARATIONS"

		Private _strCust_IDs As String = PSS.Data.Buisness.Messaging.strMessCust_IDs
		Private _strLoc_IDS As String = ""
		Private _iCust_ID As Integer = 0
		Private _iLoc_ID As Integer = 0
		Private _IsDBR As Boolean = False
		Private _IsNER As Boolean = False
		Private _iDBRReasonDefaultID As Integer = 0
		Private _iNERReasonDefaultID As Integer = 0
		Private _iDBRBillCodeID As Integer = 25
		Private _iNERBillCodeID As Integer = 89
		Private _strDBRPartNumber As String = "S25"
		Private _strNERPartNumber As String = "S89"
		Private _vDBRNER_LaborCharge As Double = 1.0
		Private _iDBRNERShipID As Integer = 9999919		  ' is should be 99999 & loc_ID =19 AMS
		Private _iUserID As Integer = PSS.Core.ApplicationUser.IDuser
		Private _iShitID As Integer = PSS.Core.ApplicationUser.IDShift
		Private _iEmpNum As Integer = PSS.Core.ApplicationUser.NumberEmp
		Private _strWorkDate As String = PSS.Core.ApplicationUser.Workdate

#End Region

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
		Friend WithEvents btnPass As System.Windows.Forms.Button
		Friend WithEvents btnDBR As System.Windows.Forms.Button
		Friend WithEvents btnNER As System.Windows.Forms.Button
		Friend WithEvents lblCustomer As System.Windows.Forms.Label
		Friend WithEvents btnClearReset As System.Windows.Forms.Button
		Friend WithEvents pnlReasons As System.Windows.Forms.Panel
		Friend WithEvents btnOK As System.Windows.Forms.Button
		Friend WithEvents btnCancel As System.Windows.Forms.Button
		Friend WithEvents lblSN As System.Windows.Forms.Label
		Friend WithEvents lblDBRNER As System.Windows.Forms.Label
		Friend WithEvents cboDBRReasons As C1.Win.C1List.C1Combo
		Friend WithEvents cboNERReasons As C1.Win.C1List.C1Combo
		Friend WithEvents tdgDeviceData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents btnUnDo As System.Windows.Forms.Button
		Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
		Friend WithEvents tdgDevicesProcessed As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessEvaluation))
			Me.txtSN = New System.Windows.Forms.TextBox()
			Me.lblSN = New System.Windows.Forms.Label()
			Me.btnPass = New System.Windows.Forms.Button()
			Me.btnDBR = New System.Windows.Forms.Button()
			Me.btnNER = New System.Windows.Forms.Button()
			Me.lblCustomer = New System.Windows.Forms.Label()
			Me.btnClearReset = New System.Windows.Forms.Button()
			Me.pnlReasons = New System.Windows.Forms.Panel()
			Me.cboNERReasons = New C1.Win.C1List.C1Combo()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.cboDBRReasons = New C1.Win.C1List.C1Combo()
			Me.lblDBRNER = New System.Windows.Forms.Label()
			Me.tdgDeviceData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.btnUnDo = New System.Windows.Forms.Button()
			Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
			Me.tdgDevicesProcessed = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.pnlReasons.SuspendLayout()
			CType(Me.cboNERReasons, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.cboDBRReasons, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.tdgDeviceData, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.tdgDevicesProcessed, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'txtSN
			'
			Me.txtSN.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.txtSN.Location = New System.Drawing.Point(64, 64)
			Me.txtSN.Name = "txtSN"
			Me.txtSN.Size = New System.Drawing.Size(336, 26)
			Me.txtSN.TabIndex = 1
			Me.txtSN.Text = ""
			'
			'lblSN
			'
			Me.lblSN.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblSN.Location = New System.Drawing.Point(24, 64)
			Me.lblSN.Name = "lblSN"
			Me.lblSN.Size = New System.Drawing.Size(40, 24)
			Me.lblSN.TabIndex = 20
			Me.lblSN.Text = "SN:"
			Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'btnPass
			'
			Me.btnPass.BackColor = System.Drawing.Color.LightSteelBlue
			Me.btnPass.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnPass.ForeColor = System.Drawing.Color.SeaGreen
			Me.btnPass.Location = New System.Drawing.Point(64, 96)
			Me.btnPass.Name = "btnPass"
			Me.btnPass.Size = New System.Drawing.Size(144, 80)
			Me.btnPass.TabIndex = 2
			Me.btnPass.Text = "Process to Pre-Cell"
			'
			'btnDBR
			'
			Me.btnDBR.BackColor = System.Drawing.Color.LightSteelBlue
			Me.btnDBR.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnDBR.ForeColor = System.Drawing.Color.Crimson
			Me.btnDBR.Location = New System.Drawing.Point(216, 96)
			Me.btnDBR.Name = "btnDBR"
			Me.btnDBR.Size = New System.Drawing.Size(96, 80)
			Me.btnDBR.TabIndex = 3
			Me.btnDBR.Text = "DBR"
			'
			'btnNER
			'
			Me.btnNER.BackColor = System.Drawing.Color.LightSteelBlue
			Me.btnNER.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnNER.ForeColor = System.Drawing.Color.Crimson
			Me.btnNER.Location = New System.Drawing.Point(320, 96)
			Me.btnNER.Name = "btnNER"
			Me.btnNER.Size = New System.Drawing.Size(80, 80)
			Me.btnNER.TabIndex = 4
			Me.btnNER.Text = "NER"
			'
			'lblCustomer
			'
			Me.lblCustomer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblCustomer.ForeColor = System.Drawing.SystemColors.ControlDarkDark
			Me.lblCustomer.Location = New System.Drawing.Point(64, 32)
			Me.lblCustomer.Name = "lblCustomer"
			Me.lblCustomer.Size = New System.Drawing.Size(176, 24)
			Me.lblCustomer.TabIndex = 15
			Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'btnClearReset
			'
			Me.btnClearReset.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnClearReset.ForeColor = System.Drawing.Color.MidnightBlue
			Me.btnClearReset.Location = New System.Drawing.Point(272, 16)
			Me.btnClearReset.Name = "btnClearReset"
			Me.btnClearReset.Size = New System.Drawing.Size(128, 40)
			Me.btnClearReset.TabIndex = 16
			Me.btnClearReset.Text = "Clear/Reset"
			'
			'pnlReasons
			'
			Me.pnlReasons.BackColor = System.Drawing.Color.LightGray
			Me.pnlReasons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.pnlReasons.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboNERReasons, Me.btnCancel, Me.btnOK, Me.cboDBRReasons, Me.lblDBRNER})
			Me.pnlReasons.Location = New System.Drawing.Point(64, 184)
			Me.pnlReasons.Name = "pnlReasons"
			Me.pnlReasons.Size = New System.Drawing.Size(336, 168)
			Me.pnlReasons.TabIndex = 17
			'
			'cboNERReasons
			'
			Me.cboNERReasons.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboNERReasons.AutoCompletion = True
			Me.cboNERReasons.AutoDropDown = True
			Me.cboNERReasons.AutoSelect = True
			Me.cboNERReasons.Caption = ""
			Me.cboNERReasons.CaptionHeight = 17
			Me.cboNERReasons.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboNERReasons.ColumnCaptionHeight = 17
			Me.cboNERReasons.ColumnFooterHeight = 17
			Me.cboNERReasons.ColumnHeaders = False
			Me.cboNERReasons.ContentHeight = 15
			Me.cboNERReasons.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboNERReasons.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboNERReasons.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboNERReasons.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboNERReasons.EditorHeight = 15
			Me.cboNERReasons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboNERReasons.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboNERReasons.ItemHeight = 15
			Me.cboNERReasons.Location = New System.Drawing.Point(32, 136)
			Me.cboNERReasons.MatchEntryTimeout = CType(2000, Long)
			Me.cboNERReasons.MaxDropDownItems = CType(10, Short)
			Me.cboNERReasons.MaxLength = 32767
			Me.cboNERReasons.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboNERReasons.Name = "cboNERReasons"
			Me.cboNERReasons.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboNERReasons.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboNERReasons.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboNERReasons.Size = New System.Drawing.Size(288, 21)
			Me.cboNERReasons.TabIndex = 15
			Me.cboNERReasons.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'btnCancel
			'
			Me.btnCancel.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCancel.Location = New System.Drawing.Point(72, 80)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(72, 48)
			Me.btnCancel.TabIndex = 14
			Me.btnCancel.Text = "Cancel"
			'
			'btnOK
			'
			Me.btnOK.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnOK.Location = New System.Drawing.Point(160, 80)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(72, 48)
			Me.btnOK.TabIndex = 13
			Me.btnOK.Text = "OK"
			'
			'cboDBRReasons
			'
			Me.cboDBRReasons.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboDBRReasons.AutoCompletion = True
			Me.cboDBRReasons.AutoDropDown = True
			Me.cboDBRReasons.AutoSelect = True
			Me.cboDBRReasons.Caption = ""
			Me.cboDBRReasons.CaptionHeight = 17
			Me.cboDBRReasons.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboDBRReasons.ColumnCaptionHeight = 17
			Me.cboDBRReasons.ColumnFooterHeight = 17
			Me.cboDBRReasons.ColumnHeaders = False
			Me.cboDBRReasons.ContentHeight = 15
			Me.cboDBRReasons.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboDBRReasons.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboDBRReasons.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboDBRReasons.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboDBRReasons.EditorHeight = 15
			Me.cboDBRReasons.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboDBRReasons.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
			Me.cboDBRReasons.ItemHeight = 15
			Me.cboDBRReasons.Location = New System.Drawing.Point(32, 32)
			Me.cboDBRReasons.MatchEntryTimeout = CType(2000, Long)
			Me.cboDBRReasons.MaxDropDownItems = CType(10, Short)
			Me.cboDBRReasons.MaxLength = 32767
			Me.cboDBRReasons.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboDBRReasons.Name = "cboDBRReasons"
			Me.cboDBRReasons.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboDBRReasons.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboDBRReasons.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboDBRReasons.Size = New System.Drawing.Size(288, 21)
			Me.cboDBRReasons.TabIndex = 11
			Me.cboDBRReasons.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'lblDBRNER
			'
			Me.lblDBRNER.BackColor = System.Drawing.Color.Transparent
			Me.lblDBRNER.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblDBRNER.ForeColor = System.Drawing.SystemColors.ControlText
			Me.lblDBRNER.Location = New System.Drawing.Point(32, 16)
			Me.lblDBRNER.Name = "lblDBRNER"
			Me.lblDBRNER.Size = New System.Drawing.Size(216, 11)
			Me.lblDBRNER.TabIndex = 12
			Me.lblDBRNER.Text = "DBR Reason:"
			Me.lblDBRNER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			'
			'tdgDeviceData
			'
			Me.tdgDeviceData.AllowUpdate = False
			Me.tdgDeviceData.AlternatingRows = True
			Me.tdgDeviceData.BackColor = System.Drawing.Color.GhostWhite
			Me.tdgDeviceData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.tdgDeviceData.FetchRowStyles = True
			Me.tdgDeviceData.FilterBar = True
			Me.tdgDeviceData.GroupByCaption = "Drag a column header here to group by that column"
			Me.tdgDeviceData.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
			Me.tdgDeviceData.Location = New System.Drawing.Point(40, 440)
			Me.tdgDeviceData.Name = "tdgDeviceData"
			Me.tdgDeviceData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.tdgDeviceData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.tdgDeviceData.PreviewInfo.ZoomFactor = 75
			Me.tdgDeviceData.Size = New System.Drawing.Size(440, 88)
			Me.tdgDeviceData.TabIndex = 47
			Me.tdgDeviceData.TabStop = False
			Me.tdgDeviceData.Text = "C1TrueDBGrid1"
			Me.tdgDeviceData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
			"ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
			"wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
			"{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
			"tion{AlignHorz:Center;}Style9{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
			":HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:C" & _
			"enter;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;For" & _
			"eColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
			"tyle14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
			"Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" C" & _
			"olumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dott" & _
			"edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
			"1"" HorizontalScrollGroup=""1""><Height>86</Height><CaptionStyle parent=""Style2"" me" & _
			"=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""Ev" & _
			"enRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterSt" & _
			"yle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Hea" & _
			"dingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow" & _
			""" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle pare" & _
			"nt=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style" & _
			"11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""" & _
			"Style1"" /><ClientRect>0, 0, 438, 86</ClientRect><BorderSide>0</BorderSide><Borde" & _
			"rStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles" & _
			"><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style par" & _
			"ent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent" & _
			"=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=" & _
			"""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=" & _
			"""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Head" & _
			"ing"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent" & _
			"=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</h" & _
			"orzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Clien" & _
			"tArea>0, 0, 438, 86</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><" & _
			"PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
			'
			'btnUnDo
			'
			Me.btnUnDo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnUnDo.ForeColor = System.Drawing.Color.DodgerBlue
			Me.btnUnDo.Location = New System.Drawing.Point(416, 16)
			Me.btnUnDo.Name = "btnUnDo"
			Me.btnUnDo.Size = New System.Drawing.Size(96, 40)
			Me.btnUnDo.TabIndex = 48
			Me.btnUnDo.Text = "Undo"
			Me.ToolTip1.SetToolTip(Me.btnUnDo, "Undo unit in your session")
			'
			'tdgDevicesProcessed
			'
			Me.tdgDevicesProcessed.AllowUpdate = False
			Me.tdgDevicesProcessed.AlternatingRows = True
			Me.tdgDevicesProcessed.BackColor = System.Drawing.Color.GhostWhite
			Me.tdgDevicesProcessed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
			Me.tdgDevicesProcessed.FetchRowStyles = True
			Me.tdgDevicesProcessed.FilterBar = True
			Me.tdgDevicesProcessed.GroupByCaption = "Drag a column header here to group by that column"
			Me.tdgDevicesProcessed.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
			Me.tdgDevicesProcessed.Location = New System.Drawing.Point(416, 80)
			Me.tdgDevicesProcessed.Name = "tdgDevicesProcessed"
			Me.tdgDevicesProcessed.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.tdgDevicesProcessed.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.tdgDevicesProcessed.PreviewInfo.ZoomFactor = 75
			Me.tdgDevicesProcessed.Size = New System.Drawing.Size(176, 344)
			Me.tdgDevicesProcessed.TabIndex = 49
			Me.tdgDevicesProcessed.TabStop = False
			Me.tdgDevicesProcessed.Text = "C1TrueDBGrid1"
			Me.tdgDevicesProcessed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
			"ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
			"wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
			"{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
			"tion{AlignHorz:Center;}Style1{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
			":HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:C" & _
			"enter;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fo" & _
			"reColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
			"tyle12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
			"Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" C" & _
			"olumnFooterHeight=""17"" FetchRowStyles=""True"" FilterBar=""True"" MarqueeStyle=""Dott" & _
			"edCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""" & _
			"1"" HorizontalScrollGroup=""1""><Height>342</Height><CaptionStyle parent=""Style2"" m" & _
			"e=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""E" & _
			"venRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterS" & _
			"tyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><He" & _
			"adingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRo" & _
			"w"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle par" & _
			"ent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
			"e11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=" & _
			"""Style1"" /><ClientRect>0, 0, 174, 342</ClientRect><BorderSide>0</BorderSide><Bor" & _
			"derStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyl" & _
			"es><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style p" & _
			"arent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pare" & _
			"nt=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style paren" & _
			"t=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style paren" & _
			"t=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""He" & _
			"ading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style pare" & _
			"nt=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1<" & _
			"/horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><Cli" & _
			"entArea>0, 0, 174, 342</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" " & _
			"/><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
			'
			'frmMessEvaluation
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.Gainsboro
			Me.ClientSize = New System.Drawing.Size(608, 574)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgDevicesProcessed, Me.btnUnDo, Me.tdgDeviceData, Me.pnlReasons, Me.btnClearReset, Me.lblCustomer, Me.btnNER, Me.btnDBR, Me.btnPass, Me.lblSN, Me.txtSN})
			Me.Name = "frmMessEvaluation"
			Me.Text = "frmMessEvaluation"
			Me.pnlReasons.ResumeLayout(False)
			CType(Me.cboNERReasons, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.cboDBRReasons, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.tdgDeviceData, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.tdgDevicesProcessed, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region "FORM EVENTS"

		Private Sub frmMessEvaluation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim dt As DataTable
			Dim objMessaging As New PSS.Data.Buisness.Messaging()
			Dim row As DataRow

			Try
				PSS.Core.Highlight.SetHighLight(Me)

				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
				Me.btnPass.Text = "Pass to " & Environment.NewLine & "Pre-Cell"
				Me.pnlReasons.Visible = False
				Me.tdgDeviceData.Visible = False : Me.tdgDevicesProcessed.Visible = False

                Me._strCust_IDs &= "," & PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID.ToString
				dt = objMessaging.GetMessCustomers(Me._strCust_IDs)
				For Each row In dt.Rows
					If Me._strLoc_IDS.Trim.Length = 0 Then
						Me._strLoc_IDS = row("Loc_ID")
					Else
						Me._strLoc_IDS &= "," & row("Loc_ID")
					End If
				Next

				LoadDBRNERCodes()
				Me.cboNERReasons.Left = Me.cboDBRReasons.Left
				Me.cboNERReasons.Top = Me.cboDBRReasons.Top

				ClearReset()
				Me.ActiveControl = Me.txtSN
				Me.txtSN.Focus()

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default

				Generic.DisposeDT(dt)
				objMessaging = Nothing


			End Try
		End Sub

#End Region

#Region "CONTROL EVENTS"

		Private Sub txtSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyDown
			If e.KeyValue = 13 AndAlso Me.txtSN.Text.Trim.Length > 0 Then
				ProcessSN()
			End If
		End Sub

		Private Sub btnClearReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearReset.Click
			ClearReset()
		End Sub

		Private Sub DoEvalProcess(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
		   btnPass.Click, btnDBR.Click, btnNER.Click

			Dim iEvalBillCodeID As Integer = 3056			 'Billcode ID for eval process
			Dim vEvalBillCharge As Double
			Dim iWipOwnerID As Integer = 2			 'pre-Cell
			Dim objMess As New PSS.Data.Buisness.Messaging()
			Dim dt As DataTable
			Dim i As Integer = 0
			Dim iDeviceID As Integer = 0
			Dim _username = PSS.Core.Global.ApplicationUser.User
			Dim _dwsj As PSS.Data.BOL.tdevice_workstation_journal
			Dim _cmp_na As String = Environment.MachineName

			Try
				Dim btn As Button = CType(sender, Button)
				Me._IsDBR = False
				Me._IsNER = False
				Select Case btn.Name
					Case "btnPass"
						'MessageBox.Show("Clicked Pass", "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						dt = objMess.GetMessAggregateCharge(Me._iCust_ID, iEvalBillCodeID)

						If Not dt.Rows.Count > 0 Then
							MessageBox.Show("No billcode and charge data for eval process.", "DoEvalProcess", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Exit Sub
						Else
							iDeviceID = CInt(Me.tdgDeviceData.Columns("Device_ID").CellValue(0))
							vEvalBillCharge = dt.Rows(0).Item("tcab_Amount")
							i = objMess.UpdateMessEvalBill(iDeviceID, iEvalBillCodeID, vEvalBillCharge, _
							 iWipOwnerID, Me._iUserID, Format(Now(), "yyyy-MM-dd HH-mm-ss"))
							If Not i > 0 Then
								MessageBox.Show("Failed to update mess data for eval process.", "DoEvalProcess", MessageBoxButtons.OK, MessageBoxIcon.Stop)
								Exit Sub
							End If

							' ADD THE DEVICE JOURNAL ENTRY.
							_dwsj = New PSS.Data.BOL.tdevice_workstation_journal(iDeviceID, 1, "Pre-Eval", "", _username, _cmp_na, "Pre-Cell")
							_dwsj.ApplyChanges()

						End If

						'Update 
						UpdateDevicesProcessedList(iDeviceID, Me.tdgDeviceData.Columns("Device_SN").CellValue(0), "Process to Pre-Cell")

						'reset
						Me.lblCustomer.Text = ""
						Me.ActiveControl = Me.txtSN
						Me.txtSN.Enabled = True
						Me.txtSN.Text = ""
						Me.txtSN.Focus()
					Case "btnDBR"
						Me._IsDBR = True
						Me.btnDBR.FlatStyle = FlatStyle.Flat
						Me.cboDBRReasons.Visible = True
						Me.cboNERReasons.Visible = False
						Me.btnPass.Enabled = False
						Me.btnDBR.Enabled = False
						Me.btnNER.Enabled = False
						Me.btnClearReset.Enabled = False
						Me.pnlReasons.Visible = True
						Me.lblDBRNER.Text = "DBR Reason"
						Me.cboDBRReasons.SelectedValue = Me._iDBRReasonDefaultID
					Case "btnNER"
						Me._IsNER = True
						Me.btnNER.FlatStyle = FlatStyle.Flat
						Me.cboDBRReasons.Visible = False
						Me.cboNERReasons.Visible = True
						Me.btnPass.Enabled = False
						Me.btnDBR.Enabled = False
						Me.btnNER.Enabled = False
						Me.btnClearReset.Enabled = False
						Me.pnlReasons.Visible = True
						Me.lblDBRNER.Text = "NER Reason"
						Me.cboNERReasons.SelectedValue = Me._iNERReasonDefaultID
					Case Else
						MessageBox.Show("Wrong button.", "DoEvalProcess", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						Exit Sub
				End Select

				'Me.btnPass.Enabled = False : Me.btnDBR.Enabled = False : Me.btnNER.Enabled = False

				'Me.txtSN.Text = "" : Me.txtSN.Focus()

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "DoEvalProcess", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				objMess = Nothing
			End Try
		End Sub

		Private Sub DoDBRNER(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click, btnCancel.Click
			Dim btn As Button = CType(sender, Button)
			Dim objDeviceBill As New PSS.Data.Buisness.DeviceBilling()
			Dim objMisc As New PSS.Data.Buisness.Misc()
			Dim objMess As New PSS.Data.Buisness.Messaging()
			Dim strDate, strDateTime As String
			Dim iWipOwnerID As Integer = 5
			Dim iDeviceID As Integer = 0
			Dim i As Integer = 0
			Dim _username = PSS.Core.Global.ApplicationUser.User
			Dim _dwsj As PSS.Data.BOL.tdevice_workstation_journal
			Dim _cmp_na As String = Environment.MachineName

			Try
				Me.btnPass.Enabled = False : Me.btnDBR.Enabled = False : Me.btnNER.Enabled = False

				If btn.Name = "btnCancel" Then
					Me.btnPass.Enabled = True : Me.btnDBR.Enabled = True : Me.btnNER.Enabled = True
					Me.btnClearReset.Enabled = True
					Me.pnlReasons.Visible = False : Me.pnlReasons.Visible = False
					Me.btnDBR.FlatStyle = FlatStyle.Standard : Me.btnNER.FlatStyle = FlatStyle.Standard
				ElseIf btn.Name = "btnOK" Then
					If Me._IsDBR Then
						If Me.cboDBRReasons.SelectedValue > 0 Then
							Me.btnClearReset.Enabled = True : Me.pnlReasons.Visible = False
							iDeviceID = CInt(Me.tdgDeviceData.Columns("Device_ID").CellValue(0))

							strDate = Format(Now(), "yyyy-MM-dd")
							strDateTime = Format(Now(), "yyyy-MM-dd HH-mm-ss")

							'Save DBR reason
							objMisc.UPD(iDeviceID, Me.cboDBRReasons.SelectedValue)

							'Save devicebill
							i = objMess.InsertMessDeviceBill(0.0, 0.0, 0.0, 0.0, _
							  iDeviceID, Me._iDBRBillCodeID, Me._strDBRPartNumber, 0, 0, _
							  DBNull.Value, Me._iUserID, _
							  strDate, "")
							If Not i > 0 Then
								MessageBox.Show("Failed to update devicebill.", "Reason Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
								Exit Sub
							End If

							'Update device
							i = objMess.UpdateMessDevice(strDateTime, strDateTime, Me._strWorkDate, 0, 0, _
							 iDeviceID, 0, Me._vDBRNER_LaborCharge, 0, 0, 0, _
							 Me._iDBRNERShipID, Me._iShitID)
							If Not i > 0 Then
								MessageBox.Show("Failed to update device.", "Reason Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
								Exit Sub
							End If

							'Update WipOwnerID
							i = objMess.UpdateMessWipOwnerData(iDeviceID, iWipOwnerID, strDateTime)


							' ADD THE DEVICE JOURNAL ENTRY.
							_dwsj = New PSS.Data.BOL.tdevice_workstation_journal(iDeviceID, 1, "Ready To Ship", "", _username, _cmp_na, "Pre-Eval")
							_dwsj.ApplyChanges()

							'Save transaction
							objDeviceBill.InsertPartTransaction(iDeviceID, Me._iDBRBillCodeID, Me._iUserID, Me._iEmpNum, _
							   Me._iShitID, Me._strDBRPartNumber, 1, 0)

							'update
							UpdateDevicesProcessedList(iDeviceID, Me.tdgDeviceData.Columns("Device_SN").CellValue(0), "DBR")

							'reset
							Me.lblCustomer.Text = ""
							Me.ActiveControl = Me.txtSN
							Me.txtSN.Enabled = True : Me.txtSN.Text = "" : Me.txtSN.Focus()
							Me.btnDBR.FlatStyle = FlatStyle.Standard : Me.btnNER.FlatStyle = FlatStyle.Standard
						Else
							MessageBox.Show("Please select a DBR reason.", "Reason Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						End If
					ElseIf Me._IsNER Then
						If Me.cboNERReasons.SelectedValue > 0 Then
							Me.btnClearReset.Enabled = True : Me.pnlReasons.Visible = False
							iDeviceID = CInt(Me.tdgDeviceData.Columns("Device_ID").CellValue(0))

							strDate = Format(Now(), "yyyy-MM-dd")
							strDateTime = Format(Now(), "yyyy-MM-dd HH-mm-ss")

							'Save DBR reason
							objMisc.UPD(iDeviceID, Me.cboNERReasons.SelectedValue)

							'Save devicebill
							i = objMess.InsertMessDeviceBill(0.0, 0.0, 0.0, 0.0, _
							  iDeviceID, Me._iNERBillCodeID, Me._strNERPartNumber, 0, 0, _
							  DBNull.Value, Me._iUserID, _
							  strDate, "")
							If Not i > 0 Then
								MessageBox.Show("Failed to update devicebill.", "Reason Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
								Exit Sub
							End If

							'Update device
							i = objMess.UpdateMessDevice(strDateTime, strDateTime, Me._strWorkDate, 0, 0, _
							 iDeviceID, 0, Me._vDBRNER_LaborCharge, 0, 0, 0, _
							 Me._iDBRNERShipID, Me._iShitID)
							If Not i > 0 Then
								MessageBox.Show("Failed to update device.", "Reason Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
								Exit Sub
							End If

							'Update WipOwnerID
							i = objMess.UpdateMessWipOwnerData(iDeviceID, iWipOwnerID, strDateTime)

							' ADD THE DEVICE JOURNAL ENTRY.
							_dwsj = New PSS.Data.BOL.tdevice_workstation_journal(iDeviceID, 1, "Ready To Ship", "", _username, _cmp_na, "Pre-Eval")
							_dwsj.ApplyChanges()

							'Save transaction
							objDeviceBill.InsertPartTransaction(iDeviceID, Me._iNERBillCodeID, Me._iUserID, Me._iEmpNum, _
							   Me._iShitID, Me._strNERPartNumber, 1, 0)

							'update
							UpdateDevicesProcessedList(iDeviceID, Me.tdgDeviceData.Columns("Device_SN").CellValue(0), "NER")

							'reset
							Me.lblCustomer.Text = ""
							Me.ActiveControl = Me.txtSN
							Me.txtSN.Enabled = True : Me.txtSN.Text = "" : Me.txtSN.Focus()
							Me.btnDBR.FlatStyle = FlatStyle.Standard : Me.btnNER.FlatStyle = FlatStyle.Standard
						Else
							MessageBox.Show("Please select a NER reason.", "Reason Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
						End If
					Else
						MessageBox.Show("Can't determine DBR or NER.", "Reason Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					End If
				Else
					MessageBox.Show("Can't determine action button.", "Reason Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				End If

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "DoDBRNER", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				objDeviceBill = Nothing : objMisc = Nothing : objMess = Nothing
			End Try

		End Sub

		Private Sub btnUnDo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnDo.Click
			Dim strSN As String = ""
			Dim strAction As String = ""
			Dim iDeviceID As Integer = 0
			Dim i As Integer = 0
			Dim dt As DataTable
			Dim row As DataRow
			Dim objMess As New PSS.Data.buisness.Messaging()
			Dim _username = PSS.Core.Global.ApplicationUser.User


			Try
				strSN = Trim(InputBox("Please scan or enter a device SN:", "Enter SN", "", )).ToUpper
				If strSN = "" Then
					Exit Sub
				End If

				'get device ID
				If Me.tdgDevicesProcessed.RowCount > 0 Then
					dt = Me.tdgDevicesProcessed.DataSource.Table
					For Each row In dt.Rows
						If strSN = Trim(row("Device_SN")).ToUpper Then
							iDeviceID = CInt(row("Device_ID"))
							strAction = row("Action")
							Exit For
						End If
					Next
					If Not iDeviceID > 0 Then
						MessageBox.Show("Device '" & strSN & "' is not in your session. Can't undo.", "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
						Exit Sub
					End If
				Else
					MessageBox.Show("Device '" & strSN & "' is not in your session. Can't undo.", "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Exit Sub
				End If

				'Check valid Action
				If Not strAction.Trim.ToUpper = "Process to Pre-Cell".ToUpper _
				   AndAlso Not strAction.Trim.ToUpper = "dbr".ToUpper _
				   AndAlso Not strAction.Trim.ToUpper = "ner".ToUpper Then
					MessageBox.Show("Incorrect eval process action name.", "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Exit Sub
				End If

				'check pre-eval wiponwer_ID= 202
				dt = objMess.GetMessDataByDeviceID(iDeviceID)				'tmessdata
				If dt.Rows.Count = 0 Then
					MessageBox.Show("Can't find it in tMessData.", "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Exit Sub
				Else
					If dt.Rows(0).Item("wipowner_id") = 202 Then
						MessageBox.Show("The device is in pre-eval. Invalid to undo.", "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
						Exit Sub
					End If
				End If

				'Check if manifested
				dt = objMess.GetMessDeviceDataByDeviceID(iDeviceID)				'tdevice data
				If dt.Rows.Count = 0 Then
					MessageBox.Show("Can't find device data.", "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Exit Sub
				Else
					If Not dt.Rows(0).IsNull("Pallett_ID") Then
						MessageBox.Show("The device has been manifested. Can't undo it.", "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
						Exit Sub
					End If
				End If

				'Check if billed for Processed to Pre-Cell
				If strAction.Trim.ToUpper = "Process to Pre-Cell".ToUpper AndAlso Not dt.Rows(0).IsNull("Device_DateBill") Then
					MessageBox.Show("The eval good device has been billed in the billing screen. Can't undo it.", "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
					Exit Sub
				End If

				'Ask for confirming
				Dim result1 As DialogResult = MessageBox.Show("Do you ant to undo it?", "Confirm it", MessageBoxButtons.YesNo)
				If result1 = DialogResult.Yes Then
					'Undo it now
					If strAction.Trim.ToUpper = "DBR" OrElse strAction.Trim.ToUpper = "NER" Then
						'delete it from devicebill 
						i = objMess.UndoDBRNER_MessDeviceData(iDeviceID, _username)
					Else					  'process to pre-cell
						i = objMess.UndoProcessToPreCell_MessDeviceData(iDeviceID, _username)
					End If
				End If

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnUnDo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				dt = Nothing : objMess = Nothing
			End Try
		End Sub

#End Region

#Region "METHODS"

		Private Function ProcessedDevicesTableDef() As DataTable
			Dim dTB As New DataTable()
			Dim row As DataRow
			dTB.Columns.Add("Device_SN", GetType(String))
			dTB.Columns.Add("Action", GetType(String))
			dTB.Columns.Add("Device_ID", GetType(Integer))

			'row = dTB.NewRow()
			'row("Device_SN") = "test1"
			'row("Action") = "DBR"
			'row("Device_ID") = 1234
			'dTB.Rows.Add(row)

			Return dTB
		End Function

		Private Sub UpdateDevicesProcessedList(ByVal iDeviceID As Integer, ByVal strDeviceSN As String, ByVal strAction As String)
			Dim dt, dtTmp As DataTable
			Dim row, rowNew As DataRow
			Dim strS As String = ""
			Try
				If Not Me.tdgDevicesProcessed.RowCount > 0 Then
					dt = ProcessedDevicesTableDef()
					rowNew = dt.NewRow
					rowNew("Device_SN") = strDeviceSN
					rowNew("Action") = strAction
					rowNew("Device_ID") = iDeviceID
					dt.Rows.Add(rowNew)

					Me.tdgDevicesProcessed.DataSource = dt.DefaultView
				Else
					dtTmp = Me.tdgDevicesProcessed.DataSource.Table
					dt = dtTmp.Clone
					For Each row In dtTmp.Rows
						If Not row("Device_ID") = iDeviceID Then
							dt.ImportRow(row)
						End If
					Next

					rowNew = dt.NewRow
					rowNew("Device_SN") = strDeviceSN
					rowNew("Action") = strAction
					rowNew("Device_ID") = iDeviceID
					dt.Rows.Add(rowNew)

					Me.tdgDevicesProcessed.DataSource = dt.DefaultView
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "UpdateDevicesProcessedList", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub ProcessSN()
			Dim objMessaging As New PSS.Data.Buisness.Messaging()
			Dim dt As DataTable
			Dim strSN As String = ""
			Dim row As DataRow
			Dim iTmpCust_ID As Integer = 0
			Dim iWipOwnerID As Integer = 202			 'Pre-Eval stage
			Dim strS As String = ""
			Dim bSuccess As Boolean = False

			Try
				'Reset
				Reset()
				Me.btnPass.Enabled = False : Me.btnDBR.Enabled = False : Me.btnNER.Enabled = False
				Me.pnlReasons.Visible = False

				If Not Me.txtSN.Text.Trim.Length > 0 Then Exit Sub
				Cursor.Current = Cursors.WaitCursor : Me.Enabled = False

				'get device
				strSN = Me.txtSN.Text.Trim
				dt = objMessaging.GetMessDeviceData(Me._strLoc_IDS, strSN)

				Me.tdgDeviceData.DataSource = Nothing

				If Not dt.Rows.Count > 0 Then				'no data
					MessageBox.Show("SN does not exist in the system or already has been produced.", "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					txtSN.Text = ""
					Exit Sub
				ElseIf dt.Rows.Count > 1 Then				'dup
					iTmpCust_ID = dt.Rows(0).Item("Cust_ID")
					For Each row In dt.Rows
						If iTmpCust_ID <> row("Cust_ID") Then
							MessageBox.Show("Duplicate SN for different customers. Can't process.", "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
							Exit Sub
						End If
					Next
					MessageBox.Show("Duplicate SN. Can't process.", "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				ElseIf dt.Rows.Count = 1 Then				'ready to process
					If dt.Rows(0).IsNull("EvalFlag") OrElse Not dt.Rows(0).Item("EvalFlag") = 1 Then
						MessageBox.Show("Not a valid Eval device.", "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf dt.Rows(0).IsNull("wipowner_id") OrElse Not dt.Rows(0).Item("wipowner_id") = iWipOwnerID Then
						If Not dt.Rows(0).IsNull("wipowner_desc") AndAlso Trim(dt.Rows(0).Item("wipowner_desc")).Length > 0 Then
							strS = " It is in " & Trim(dt.Rows(0).Item("wipowner_desc")) & ". Can't process."
						End If
						MessageBox.Show("Not in Pre-Eval. " & strS, "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf Not dt.Rows(0).IsNull("Device_DateShip") AndAlso Trim(dt.Rows(0).Item("Device_DateShip")).Length > 0 Then
						MessageBox.Show("The device has been produced. Can't process.", "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf Not dt.Rows(0).IsNull("Device_DateBill") AndAlso Trim(dt.Rows(0).Item("Device_DateBill")).Length > 0 Then
						MessageBox.Show("The device has been billed. Can't process.", "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf Not dt.Rows(0).IsNull("EvalBillCode_ID") AndAlso dt.Rows(0).Item("EvalBillCode_ID") > 0 Then
						MessageBox.Show("Completed the eval process. Can't process it again.", "information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Else
						Me.tdgDeviceData.DataSource = dt

                        Me.lblCustomer.Text = dt.Rows(0).Item("Customer")
						Me._iCust_ID = dt.Rows(0).Item("Cust_ID")
						Me._iLoc_ID = dt.Rows(0).Item("Loc_ID")

						bSuccess = True : Me.txtSN.Enabled = False
						Me.btnPass.Enabled = True : Me.btnDBR.Enabled = True : Me.btnNER.Enabled = True


					End If
				End If

				' MessageBox.Show("SN/IMEI does not exist in the system or already has a pallet assigned to it.", "information", MessageBoxButtons.OK)
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				objMessaging = Nothing
				Cursor.Current = Cursors.Default : Me.Enabled = True
				If Not bSuccess AndAlso Me.txtSN.Text.Trim.Length >= 0 Then Me.txtSN.Focus() : Me.txtSN.SelectAll()

			End Try
		End Sub

		Private Sub Reset()
			'Initail Reset
			Me.lblCustomer.Text = ""
			Me.btnPass.ForeColor = Color.SeaGreen
			Me.btnDBR.ForeColor = Color.Crimson
			Me.btnNER.ForeColor = Color.Crimson
			Me.btnPass.FlatStyle = FlatStyle.Standard
			Me.btnDBR.FlatStyle = FlatStyle.Standard
			Me.btnNER.FlatStyle = FlatStyle.Standard
		End Sub

		Private Sub ClearReset()
			Try
				Me.btnPass.Enabled = False
				Me.btnDBR.Enabled = False
				Me.btnNER.Enabled = False
				Me.pnlReasons.Visible = False
				Me.lblCustomer.Text = ""
				Me.ActiveControl = Me.txtSN
				Me.txtSN.Text = ""
				Me.txtSN.Focus()
				Me.txtSN.Enabled = True
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "ClearReset", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			End Try
		End Sub

		Private Sub LoadDBRNERCodes()
			Dim objMisc As New PSS.Data.Buisness.Misc()
			Dim objDBRManifest As New Data.Buisness.DBRManifest()
			Dim dt As DataTable
			Try
				'DBR Reasons
				dt = objMisc.GetDBRCodes(True)
				Misc.PopulateC1DropDownList(Me.cboDBRReasons, dt, "DispalyDesc", "Dcode_ID")
				'Me.cboDBRReasons.SelectedValue = 0 'Empty Row 
				If dt.Rows.Count >= 1 AndAlso dt.Rows.Count <= 2 Then
					Me.cboDBRReasons.SelectedValue = dt.Rows(0).Item("Dcode_ID")
					Me._iDBRReasonDefaultID = Me.cboDBRReasons.SelectedValue
				ElseIf dt.Rows.Count > 2 Then
					Me.cboDBRReasons.SelectedValue = 0
				End If

				'NER Reasons
				dt = objDBRManifest.GetNERReasons(True, True, True)
				Misc.PopulateC1DropDownList(Me.cboNERReasons, dt, "DispalyDesc", "Dcode_ID")
				'Me.cboNERReasons.SelectedValue = 0 'Empty Row 
				If dt.Rows.Count >= 1 AndAlso dt.Rows.Count <= 2 Then
					Me.cboNERReasons.SelectedValue = dt.Rows(0).Item("Dcode_ID")
					Me._iNERReasonDefaultID = Me.cboNERReasons.SelectedValue
				ElseIf dt.Rows.Count > 2 Then
					Me.cboNERReasons.SelectedValue = 0
				End If

			Catch ex As Exception
				MessageBox.Show(ex.ToString, "LoadDBRNERCodes", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
			Finally
				dt = Nothing : objMisc = Nothing : objDBRManifest = Nothing
			End Try
		End Sub

#End Region

	End Class

End Namespace
