'Imports System.Drawing
'Imports System.Drawing.Printing
'Imports PSS.Core

''Imports PSS.Data

'Namespace Gui.MotorolaSubcontract
'    Public Class frmMoto_RL_Shipping
'        Inherits System.Windows.Forms.Form

'        Private dtDeviceSNsForWO As DataTable     '********This needs to be destroyed in the form close or terminate
'        Private iWO_ID As Integer
'        Private iSKU_ID As Integer
'        Private ObjUtilib As MyLib.Utility
'        Private objFedex As PSS.Gui.MotorolaSubcontract.Fedex
'        Private objMotoSubcontract_Biz As PSS.Data.Buisness.MotorolaSubcontract_Biz
'        Private iOverpack_Process As Integer
'        Private iNumDevicestoBeShipped As Integer
'        Private iWO_Quantity As Integer
'        Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift

'        Private Shared ctl As Control
'        Private Shared HighLightColor As Color = Color.Yellow
'        Private Shared WindowColor As Color = Color.SkyBlue
'        Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
'        Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

'#Region " Windows Form Designer generated code "


'        Public Sub New(ByVal iDeviceType As Integer)
'            MyBase.New()

'            'This call is required by the Windows Form Designer.
'            InitializeComponent()

'            'Add any initialization after the InitializeComponent() call
'            Me.OverPackProcess = iDeviceType

'        End Sub


'        'Form overrides dispose to clean up the component list.
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub

'        'Required by the Windows Form Designer
'        Private components As System.ComponentModel.IContainer

'        'NOTE: The following procedure is required by the Windows Form Designer
'        'It can be modified using the Windows Form Designer.  
'        'Do not modify it using the code editor.
'        Friend WithEvents Label1 As System.Windows.Forms.Label
'        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
'        Friend WithEvents txtDevice As System.Windows.Forms.TextBox
'        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
'        Friend WithEvents lblDate As System.Windows.Forms.Label
'        Friend WithEvents Label2 As System.Windows.Forms.Label
'        Friend WithEvents btnReprint As System.Windows.Forms.Button
'        Friend WithEvents btnPrint As System.Windows.Forms.Button
'        Friend WithEvents lblCount As System.Windows.Forms.Label
'        Friend WithEvents Label3 As System.Windows.Forms.Label
'        Friend WithEvents grdRMAInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
'        Friend WithEvents Button1 As System.Windows.Forms.Button
'        Friend WithEvents lblCompany As System.Windows.Forms.Label
'        Friend WithEvents lblAddress As System.Windows.Forms.Label
'        Friend WithEvents btnClear As System.Windows.Forms.Button
'        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
'        Friend WithEvents chkCloseOverPack As System.Windows.Forms.CheckBox
'        Friend WithEvents Label4 As System.Windows.Forms.Label
'        Friend WithEvents lblNoOfDevToShip As System.Windows.Forms.Label
'        Friend WithEvents btnRpt As System.Windows.Forms.Button
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Me.components = New System.ComponentModel.Container()
'            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMoto_RL_Shipping))
'            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
'            Me.Label1 = New System.Windows.Forms.Label()
'            Me.lstDevices = New System.Windows.Forms.ListBox()
'            Me.txtDevice = New System.Windows.Forms.TextBox()
'            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
'            Me.lblDate = New System.Windows.Forms.Label()
'            Me.Label2 = New System.Windows.Forms.Label()
'            Me.btnReprint = New System.Windows.Forms.Button()
'            Me.btnPrint = New System.Windows.Forms.Button()
'            Me.lblCount = New System.Windows.Forms.Label()
'            Me.Label3 = New System.Windows.Forms.Label()
'            Me.grdRMAInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
'            Me.Button1 = New System.Windows.Forms.Button()
'            Me.lblCompany = New System.Windows.Forms.Label()
'            Me.lblAddress = New System.Windows.Forms.Label()
'            Me.btnClear = New System.Windows.Forms.Button()
'            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
'            Me.chkCloseOverPack = New System.Windows.Forms.CheckBox()
'            Me.Label4 = New System.Windows.Forms.Label()
'            Me.lblNoOfDevToShip = New System.Windows.Forms.Label()
'            Me.btnRpt = New System.Windows.Forms.Button()
'            CType(Me.grdRMAInfo, System.ComponentModel.ISupportInitialize).BeginInit()
'            Me.SuspendLayout()
'            '
'            'Label1
'            '
'            Me.Label1.BackColor = System.Drawing.Color.Transparent
'            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label1.ForeColor = System.Drawing.Color.White
'            Me.Label1.Location = New System.Drawing.Point(15, 36)
'            Me.Label1.Name = "Label1"
'            Me.Label1.Size = New System.Drawing.Size(81, 16)
'            Me.Label1.TabIndex = 37
'            Me.Label1.Text = "Customer:"
'            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'lstDevices
'            '
'            Me.lstDevices.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lstDevices.BackColor = System.Drawing.Color.SkyBlue
'            Me.lstDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lstDevices.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lstDevices.ForeColor = System.Drawing.Color.Black
'            Me.lstDevices.Location = New System.Drawing.Point(488, 189)
'            Me.lstDevices.Name = "lstDevices"
'            Me.lstDevices.Size = New System.Drawing.Size(157, 223)
'            Me.lstDevices.TabIndex = 35
'            '
'            'txtDevice
'            '
'            Me.txtDevice.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
'                        Or System.Windows.Forms.AnchorStyles.Right)
'            Me.txtDevice.BackColor = System.Drawing.Color.SkyBlue
'            Me.txtDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtDevice.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.txtDevice.ForeColor = System.Drawing.Color.Black
'            Me.txtDevice.Location = New System.Drawing.Point(488, 167)
'            Me.txtDevice.Name = "txtDevice"
'            Me.txtDevice.Size = New System.Drawing.Size(157, 21)
'            Me.txtDevice.TabIndex = 34
'            Me.txtDevice.Text = ""
'            '
'            'cboCustomer
'            '
'            Me.cboCustomer.AutoComplete = True
'            Me.cboCustomer.BackColor = System.Drawing.Color.SkyBlue
'            Me.cboCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.cboCustomer.ForeColor = System.Drawing.Color.Black
'            Me.cboCustomer.Location = New System.Drawing.Point(99, 33)
'            Me.cboCustomer.Name = "cboCustomer"
'            Me.cboCustomer.Size = New System.Drawing.Size(307, 21)
'            Me.cboCustomer.TabIndex = 36
'            '
'            'lblDate
'            '
'            Me.lblDate.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblDate.BackColor = System.Drawing.Color.Transparent
'            Me.lblDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblDate.ForeColor = System.Drawing.Color.White
'            Me.lblDate.Location = New System.Drawing.Point(480, 35)
'            Me.lblDate.Name = "lblDate"
'            Me.lblDate.Size = New System.Drawing.Size(184, 16)
'            Me.lblDate.TabIndex = 33
'            Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'Label2
'            '
'            Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.Label2.BackColor = System.Drawing.Color.Transparent
'            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label2.ForeColor = System.Drawing.Color.White
'            Me.Label2.Location = New System.Drawing.Point(437, 35)
'            Me.Label2.Name = "Label2"
'            Me.Label2.Size = New System.Drawing.Size(46, 16)
'            Me.Label2.TabIndex = 32
'            Me.Label2.Text = "Date:"
'            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'btnReprint
'            '
'            Me.btnReprint.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.btnReprint.BackColor = System.Drawing.Color.Transparent
'            Me.btnReprint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.btnReprint.ForeColor = System.Drawing.Color.Black
'            Me.btnReprint.Location = New System.Drawing.Point(383, 452)
'            Me.btnReprint.Name = "btnReprint"
'            Me.btnReprint.Size = New System.Drawing.Size(96, 32)
'            Me.btnReprint.TabIndex = 31
'            Me.btnReprint.Text = "Reprint"
'            '
'            'btnPrint
'            '
'            Me.btnPrint.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.btnPrint.BackColor = System.Drawing.Color.Transparent
'            Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.btnPrint.ForeColor = System.Drawing.Color.Black
'            Me.btnPrint.Location = New System.Drawing.Point(488, 452)
'            Me.btnPrint.Name = "btnPrint"
'            Me.btnPrint.Size = New System.Drawing.Size(157, 32)
'            Me.btnPrint.TabIndex = 30
'            Me.btnPrint.Text = "Print"
'            '
'            'lblCount
'            '
'            Me.lblCount.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.lblCount.BackColor = System.Drawing.Color.Transparent
'            Me.lblCount.Font = New System.Drawing.Font("Verdana", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCount.ForeColor = System.Drawing.Color.White
'            Me.lblCount.Location = New System.Drawing.Point(528, 105)
'            Me.lblCount.Name = "lblCount"
'            Me.lblCount.Size = New System.Drawing.Size(80, 48)
'            Me.lblCount.TabIndex = 29
'            Me.lblCount.Text = "0"
'            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'Label3
'            '
'            Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.Label3.BackColor = System.Drawing.Color.Transparent
'            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label3.ForeColor = System.Drawing.Color.White
'            Me.Label3.Location = New System.Drawing.Point(518, 89)
'            Me.Label3.Name = "Label3"
'            Me.Label3.Size = New System.Drawing.Size(96, 16)
'            Me.Label3.TabIndex = 28
'            Me.Label3.Text = "Count"
'            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'grdRMAInfo
'            '
'            Me.grdRMAInfo.AllowColMove = False
'            Me.grdRMAInfo.AllowFilter = True
'            Me.grdRMAInfo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
'            Me.grdRMAInfo.AllowSort = True
'            Me.grdRMAInfo.AllowUpdate = False
'            Me.grdRMAInfo.AllowUpdateOnBlur = False
'            Me.grdRMAInfo.AlternatingRows = True
'            Me.grdRMAInfo.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
'                        Or System.Windows.Forms.AnchorStyles.Right)
'            Me.grdRMAInfo.BackColor = System.Drawing.Color.SkyBlue
'            Me.grdRMAInfo.CaptionHeight = 18
'            Me.grdRMAInfo.CollapseColor = System.Drawing.Color.Black
'            Me.grdRMAInfo.DataChanged = False
'            Me.grdRMAInfo.DeadAreaBackColor = System.Drawing.Color.Empty
'            Me.grdRMAInfo.ExpandColor = System.Drawing.Color.Black
'            Me.grdRMAInfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.grdRMAInfo.GroupByCaption = "Drag a column header here to group by that column"
'            Me.grdRMAInfo.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
'            Me.grdRMAInfo.Location = New System.Drawing.Point(50, 168)
'            Me.grdRMAInfo.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
'            Me.grdRMAInfo.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
'            Me.grdRMAInfo.Name = "grdRMAInfo"
'            Me.grdRMAInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
'            Me.grdRMAInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
'            Me.grdRMAInfo.PreviewInfo.ZoomFactor = 75
'            Me.grdRMAInfo.PrintInfo.ShowOptionsDialog = False
'            Me.grdRMAInfo.RecordSelectorWidth = 16
'            GridLines1.Color = System.Drawing.Color.DarkGray
'            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
'            Me.grdRMAInfo.RowDivider = GridLines1
'            Me.grdRMAInfo.RowHeight = 15
'            Me.grdRMAInfo.RowSubDividerColor = System.Drawing.Color.DarkGray
'            Me.grdRMAInfo.ScrollTips = False
'            Me.grdRMAInfo.Size = New System.Drawing.Size(428, 244)
'            Me.grdRMAInfo.TabIndex = 27
'            Me.grdRMAInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
'            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}S" & _
'            "tyle12{}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selecte" & _
'            "d{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;AlignVert:Cente" & _
'            "r;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Inactive{Fo" & _
'            "reColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}OddRow{}Footer" & _
'            "{}Caption{AlignHorz:Center;}Style27{}Style29{}Style28{}Normal{Font:Verdana, 8.25" & _
'            "pt;BackColor:Transparent;}Style26{}HighlightRow{ForeColor:HighlightText;BackColo" & _
'            "r:Highlight;}Style9{}Editor{}Style11{}RecordSelector{AlignImage:Center;}Style1{}" & _
'            "Style8{}Style3{}Style2{}Style10{AlignHorz:Near;}</Data></Styles><Splits><C1.Win." & _
'            "C1TrueDBGrid.MergeView AllowColMove=""False"" Name="""" AlternatingRowStyle=""True"" C" & _
'            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=" & _
'            """DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGr" & _
'            "oup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 424, 240</ClientRect><Border" & _
'            "Side>0</BorderSide><CaptionStyle parent=""Heading"" me=""Style10"" /><EditorStyle pa" & _
'            "rent=""Editor"" me=""Style2"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Filter" & _
'            "BarStyle parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""Styl" & _
'            "e4"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" m" & _
'            "e=""Style3"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveSty" & _
'            "le parent=""Inactive"" me=""Style6"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><R" & _
'            "ecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=" & _
'            """Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBG" & _
'            "rid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent" & _
'            "=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""He" & _
'            "ading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Nor" & _
'            "mal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal""" & _
'            " me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal" & _
'            """ me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Nor" & _
'            "mal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSp" & _
'            "lits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRe" & _
'            "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 424, 240</ClientArea></Blob>"
'            '
'            'Button1
'            '
'            Me.Button1.BackColor = System.Drawing.Color.Transparent
'            Me.Button1.Location = New System.Drawing.Point(16, 424)
'            Me.Button1.Name = "Button1"
'            Me.Button1.Size = New System.Drawing.Size(56, 40)
'            Me.Button1.TabIndex = 39
'            Me.Button1.Text = "Button1"
'            Me.Button1.Visible = False
'            '
'            'lblCompany
'            '
'            Me.lblCompany.BackColor = System.Drawing.Color.Transparent
'            Me.lblCompany.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCompany.ForeColor = System.Drawing.Color.White
'            Me.lblCompany.Location = New System.Drawing.Point(34, 63)
'            Me.lblCompany.Name = "lblCompany"
'            Me.lblCompany.Size = New System.Drawing.Size(427, 21)
'            Me.lblCompany.TabIndex = 40
'            Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'lblAddress
'            '
'            Me.lblAddress.BackColor = System.Drawing.Color.Transparent
'            Me.lblAddress.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblAddress.ForeColor = System.Drawing.Color.White
'            Me.lblAddress.Location = New System.Drawing.Point(34, 90)
'            Me.lblAddress.Name = "lblAddress"
'            Me.lblAddress.Size = New System.Drawing.Size(428, 48)
'            Me.lblAddress.TabIndex = 42
'            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.TopCenter
'            '
'            'btnClear
'            '
'            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.btnClear.BackColor = System.Drawing.Color.Transparent
'            Me.btnClear.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.btnClear.ForeColor = System.Drawing.Color.White
'            Me.btnClear.Location = New System.Drawing.Point(656, 212)
'            Me.btnClear.Name = "btnClear"
'            Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
'            Me.btnClear.Size = New System.Drawing.Size(24, 168)
'            Me.btnClear.TabIndex = 43
'            Me.btnClear.Text = "CLEAR"
'            '
'            'chkCloseOverPack
'            '
'            Me.chkCloseOverPack.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.chkCloseOverPack.BackColor = System.Drawing.Color.Transparent
'            Me.chkCloseOverPack.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.chkCloseOverPack.ForeColor = System.Drawing.Color.Black
'            Me.chkCloseOverPack.Location = New System.Drawing.Point(488, 420)
'            Me.chkCloseOverPack.Name = "chkCloseOverPack"
'            Me.chkCloseOverPack.Size = New System.Drawing.Size(168, 24)
'            Me.chkCloseOverPack.TabIndex = 44
'            Me.chkCloseOverPack.Text = "Force Close Overpack"
'            Me.ToolTip1.SetToolTip(Me.chkCloseOverPack, "Applies only to Regular phones. Check this if you want to close this Overpack. Do" & _
'            "es not apply to RUR, BER, RNR phones. ")
'            Me.chkCloseOverPack.Visible = False
'            '
'            'Label4
'            '
'            Me.Label4.BackColor = System.Drawing.Color.Transparent
'            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label4.ForeColor = System.Drawing.Color.White
'            Me.Label4.Location = New System.Drawing.Point(8, 146)
'            Me.Label4.Name = "Label4"
'            Me.Label4.Size = New System.Drawing.Size(459, 16)
'            Me.Label4.TabIndex = 45
'            Me.Label4.Text = "No. of devices billed and yet to be shipped for the selected SKU:"
'            Me.Label4.Visible = False
'            '
'            'lblNoOfDevToShip
'            '
'            Me.lblNoOfDevToShip.BackColor = System.Drawing.Color.Transparent
'            Me.lblNoOfDevToShip.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblNoOfDevToShip.ForeColor = System.Drawing.Color.Black
'            Me.lblNoOfDevToShip.Location = New System.Drawing.Point(464, 145)
'            Me.lblNoOfDevToShip.Name = "lblNoOfDevToShip"
'            Me.lblNoOfDevToShip.Size = New System.Drawing.Size(72, 16)
'            Me.lblNoOfDevToShip.TabIndex = 46
'            Me.lblNoOfDevToShip.Visible = False
'            '
'            'btnRpt
'            '
'            Me.btnRpt.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
'            Me.btnRpt.BackColor = System.Drawing.Color.Transparent
'            Me.btnRpt.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.btnRpt.Location = New System.Drawing.Point(134, 452)
'            Me.btnRpt.Name = "btnRpt"
'            Me.btnRpt.Size = New System.Drawing.Size(240, 32)
'            Me.btnRpt.TabIndex = 48
'            Me.btnRpt.Text = "Show Devices to be Shipped"
'            '
'            'frmMoto_RL_Shipping
'            '
'            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
'            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
'            Me.ClientSize = New System.Drawing.Size(696, 501)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRpt, Me.lblNoOfDevToShip, Me.Label4, Me.chkCloseOverPack, Me.btnClear, Me.lblAddress, Me.lblCompany, Me.Button1, Me.Label1, Me.lstDevices, Me.txtDevice, Me.cboCustomer, Me.lblDate, Me.Label2, Me.btnReprint, Me.btnPrint, Me.lblCount, Me.Label3, Me.grdRMAInfo})
'            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Name = "frmMoto_RL_Shipping"
'            Me.Text = "RL Shipping"
'            CType(Me.grdRMAInfo, System.ComponentModel.ISupportInitialize).EndInit()
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'        Public Property OverPackProcess()
'            Get
'                Return Me.iOverpack_Process
'            End Get
'            Set(ByVal Value)
'                Me.iOverpack_Process = Value
'            End Set
'        End Property

'        Private Sub frmMoto_RL_Shiping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            Me.lblDate.Text = Now()
'            FillCustomerComboBox()
'            FillRMAGrid()

'            'Handlers to highlight in custom colors
'            SetHandler(Me.cboCustomer)  'hadles base level controls
'            SetHandler(Me.txtDevice)

'            'Set tool tips
'            ToolTip1.SetToolTip(Me.btnReprint, "Please make sure to select the right RMA Number before Reprinting.")
'            ToolTip1.SetToolTip(Me.btnClear, "Click here to clear the list of scanned devices.")
'            ToolTip1.SetToolTip(Me.btnPrint, "Click here to print labels after finishing scanning in the devices for the current masterpack.")
'            ToolTip1.SetToolTip(Me.grdRMAInfo, "Click on the RMA Number for which you want to ship devices.")

'        End Sub

'        '*****************************************
'        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

'            Dim strDeviceIDs As String = ""

'            Me.btnPrint.Enabled = False
'            Cursor.Current = Cursors.WaitCursor

'            If IsDBNull(iWO_ID) Then
'                MsgBox("Please select an RMA Number.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                Me.btnPrint.Enabled = True
'                Cursor.Current = Cursors.Default
'                Exit Sub
'            End If
'            If Me.lstDevices.Items.Count = 0 Then
'                MsgBox("Please scan in devices to ship.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                Me.btnPrint.Enabled = True
'                Cursor.Current = Cursors.Default
'                Exit Sub
'            End If

'            Dim i As Integer
'            Dim j As Integer
'            Dim dt As DataTable
'            Dim strShipDate As String
'            Dim R1 As DataRow
'            Dim iErrFlag As Integer = 0
'            Dim iErr As Integer = 0
'            Dim R2 As DataRow
'            Dim dt2 As DataTable
'            Dim iPallett_ID As Integer = 0
'            Dim iOverPack_ID As Integer = 0
'            Dim iShip_ID As Integer
'            Dim iProd_ID As Integer = 2 ' cellular Phone
'            Dim iLOC_ID As Integer = 0
'            'Dim iWO_Quantity As Integer = 0
'            Dim iShipTo_ID As Integer = 0
'            Dim strUser As String = PSS.Core.Global.ApplicationUser.User

'            Try
'                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()

'                '****************************************************************************
'                'First get the LOC_id for WO_ID
'                '****************************************************************************
'                Try
'                    dt = objMotoSubcontract_Biz.GetLOCID(iWO_ID)
'                    For Each R1 In dt.Rows      'There will be only one row.
'                        iLOC_ID = R1("Loc_ID")
'                        'iWO_Quantity = R1("WO_Quantity")
'                        If Not IsDBNull(R1("ShipTo_ID")) Then
'                            iShipTo_ID = R1("ShipTo_ID")
'                        End If
'                        Exit For
'                    Next
'                Catch ex As Exception
'                    iErrFlag = 1
'                    MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.GetLOCID: " & ex.Message.ToString)

'                Finally
'                    '*****************************
'                    'Destroy the datatable
'                    '*****************************
'                    If Not IsNothing(dt) Then
'                        If Not IsDBNull(dt) Then
'                            dt.Dispose()
'                        End If
'                        dt = Nothing
'                    End If
'                End Try
'                '***************************************************************************
'                If iErrFlag = 1 Then
'                    iErrFlag = 0
'                    Exit Try
'                End If
'                '***************************************************************************
'                'First get the Palette_ID for WO_ID
'                '***************************************************************************
'                Try
'                    dt = objMotoSubcontract_Biz.GetPallettID(iWO_ID)

'                    For Each R1 In dt.Rows      'There will be only one row.
'                        iPallett_ID = R1("Pallett_ID")
'                        Exit For
'                    Next

'                Catch ex As Exception
'                    iErrFlag = 1
'                    MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.GetPallettID: " & ex.Message.ToString)
'                Finally
'                    '******************************
'                    'Destroy the datatable
'                    '******************************
'                    If Not IsNothing(dt) Then
'                        If Not IsDBNull(dt) Then
'                            dt.Dispose()
'                        End If
'                        dt = Nothing
'                    End If
'                End Try
'                '***************************************************************************
'                If iErrFlag = 1 Then
'                    iErrFlag = 0
'                    Exit Try
'                End If

'                '***************************************************************************
'                'Create a new Pallett if iPallett_ID is NULL
'                '***************************************************************************
'                If iPallett_ID = 0 And iOverPack_ID = 0 Then
'                    Try
'                        iPallett_ID = objMotoSubcontract_Biz.CreateNewPallett(iWO_ID, iLOC_ID)
'                    Catch ex As Exception
'                        iErrFlag = 1
'                        MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.CreateNewPallett: " & ex.Message.ToString)
'                    End Try
'                    '***************************************************************************
'                    If iErrFlag = 1 Then
'                        iErrFlag = 0
'                        Exit Try
'                    End If
'                    '***************************************************************************
'                End If

'                '***************************************************************************
'                'if There is Pallett but no OverPack then create a new over pack
'                '***************************************************************************
'                If iOverPack_ID = 0 And iPallett_ID <> 0 Then
'                    Try
'                        iOverPack_ID = objMotoSubcontract_Biz.CreateNewOverPack(iPallett_ID, Me.OverPackProcess)
'                    Catch ex As Exception
'                        iErrFlag = 1
'                        MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.CreateNewOverPack: " & ex.Message.ToString)
'                    End Try
'                    '***************************************************************************
'                    If iErrFlag = 1 Then
'                        iErrFlag = 0
'                        Exit Try
'                    End If
'                    '***************************************************************************
'                End If
'                '***************************************************************************
'                'Create Master Pack
'                'create an entry into tship table
'                '***************************************************************************
'                ObjUtilib = New MyLib.Utility()
'                Try
'                    strShipDate = ObjUtilib.FormatDate_YYYYMMDD_HHMMSS(Now())
'                    iShip_ID = objMotoSubcontract_Biz.CreateNewMasterPack(strShipDate, strUser, iProd_ID, iOverPack_ID, iShipTo_ID)
'                Catch ex As Exception
'                    iErrFlag = 1
'                    MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.CreateNewMasterPack: " & ex.Message.ToString)
'                End Try
'                '***************************************************************************
'                If iErrFlag = 1 Then
'                    iErrFlag = 0
'                    Exit Try
'                End If
'                '***************************************************************************
'                'Update the tdevice table
'                '***************************************************************************
'                Try
'                    For j = 0 To Me.lstDevices.Items.Count - 1
'                        'Update the tdevice table
'                        i = objMotoSubcontract_Biz.UpdateDeviceTable(GetDevice_ID(Me.lstDevices.Items(j)), iWO_ID, iSKU_ID, iShip_ID, strShipDate, iPallett_ID, iShiftID, "")
'                    Next j
'                Catch ex As Exception
'                    iErrFlag = 1
'                    MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.UpdateDeviceTable: " & ex.Message.ToString)
'                End Try
'                '***************************************************************************
'                If iErrFlag = 1 Then
'                    iErrFlag = 0
'                    Exit Try
'                End If

'                '***************************************************************************
'                'Assign Ship Date to Over Pack
'                '***************************************************************************
'                Try
'                    i = objMotoSubcontract_Biz.AssignShipDateToOverPack(iOverPack_ID, strShipDate)
'                Catch ex As Exception
'                    iErrFlag = 1
'                    MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.AssignShipDateToOverPack: " & ex.Message.ToString)
'                End Try

'                '***************************************************************************
'                If iErrFlag = 1 Then
'                    iErrFlag = 0
'                    Exit Try
'                End If
'                '***************************************************************************
'                'Check if there are any more devices that need to be 
'                'shipped for the WO. 
'                '********************************************************
'                Dim iNumOfDevicestoBeShipped As Integer
'                Try
'                    iNumOfDevicestoBeShipped = GetNumOfDevicetobeShippedWithRMA(iPallett_ID)
'                Catch ex As Exception
'                    iErrFlag = 1
'                    MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.GetNumOfDevicetobeShippedWithRMA: " & ex.Message.ToString)
'                End Try
'                '********************************************************
'                If iErrFlag = 1 Then
'                    iErrFlag = 0
'                    Exit Try
'                End If
'                '********************************************************
'                'If no devices to be shipped then update the tworkorder table
'                '********************************************************
'                If iNumOfDevicestoBeShipped = 0 Then   'No more devices to be shipped  'SetWOReadyToBeShipped
'                    '***************************************************************************
'                    Try
'                        i = objMotoSubcontract_Biz.SetWOReadyToBeShipped(iWO_ID, strShipDate)
'                    Catch ex As Exception
'                        iErrFlag = 1
'                        MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.SetWOReadyToBeShipped: " & ex.Message.ToString)
'                    End Try
'                    '***************************************************************************
'                    If iErrFlag = 1 Then
'                        iErrFlag = 0
'                        Exit Try
'                    End If
'                    '***************************************************************************
'                    'Update tpallett table
'                    Try
'                        i = objMotoSubcontract_Biz.AssignShipDateToPallett(iPallett_ID, strShipDate)
'                    Catch ex As Exception
'                        iErrFlag = 1
'                        MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.AssignShipDateToPallett: " & ex.Message.ToString)
'                    End Try
'                    '***************************************************************************
'                    If iErrFlag = 1 Then
'                        iErrFlag = 0
'                        Exit Try
'                    End If
'                    '***************************************************************************
'                    'Update repair status based on Pallett date
'                    Try
'                        i = objMotoSubcontract_Biz.UpdateRepairStatusBasedOnPallettShipDate(1, iPallett_ID, )   '1 - SHP
'                    Catch ex As Exception
'                        iErrFlag = 1
'                        MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.UpdateRepairStatusBasedOnPallettShipDate: " & ex.Message.ToString)
'                    End Try
'                    '***************************************************************************
'                ElseIf iNumOfDevicestoBeShipped > 0 Then    'Some devices to be shipped
'                    'Update repair status based on Pallett date
'                    Try
'                        i = objMotoSubcontract_Biz.UpdateRepairStatusBasedOnPallettShipDate(0, , iShip_ID)    '0 - APS
'                    Catch ex As Exception
'                        iErrFlag = 1
'                        MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.UpdateRepairStatusBasedOnPallettShipDate: " & ex.Message.ToString)
'                    End Try
'                Else    'Negative value
'                    iErrFlag = 1
'                    MsgBox("Number of devices to be shipped can't be a negative value. Contact IT immediately.")
'                End If
'                '***************************************************************************
'                If iErrFlag = 1 Then
'                    iErrFlag = 0
'                    Exit Try
'                End If
'                '********************************************************
'                'Write to Fedex db
'                '********************************************************
'                objFedex = New PSS.Gui.MotorolaSubcontract.Fedex()
'                i = objFedex.WriteFedEx(iShip_ID)

'                '********************************************************
'                'Update SUMBILL table (This is useful for a report and nothing else)
'                '********************************************************
'                For j = 0 To Me.lstDevices.Items.Count - 1
'                    If j = Me.lstDevices.Items.Count - 1 Then
'                        strDeviceIDs = strDeviceIDs + CStr(GetDevice_ID(Me.lstDevices.Items(j)))
'                    Else
'                        strDeviceIDs = strDeviceIDs + CStr(GetDevice_ID(Me.lstDevices.Items(j))) + ", "
'                    End If
'                Next j

'                'Update billing summary
'                i = objMotoSubcontract_Biz.UpdateBillingSummary(strDeviceIDs)

'                '********************************************************
'                'Print Stuff
'                '********************************************************
'                Me.DoPrinting(iShip_ID)

'                '***************************************************************************
'                If iErrFlag = 1 Then
'                    iErrFlag = 0
'                    Exit Try
'                End If
'                '********************************************************
'                'Destroy the object
'                '********************************************************
'                If Not IsNothing(objMotoSubcontract_Biz) Then
'                    objMotoSubcontract_Biz = Nothing
'                End If
'                '********************************************************
'                'Refresh the table
'                '********************************************************
'                FillRMAGrid()
'                'Me.RefreshTable(iWO_ID)
'                '********************************************************
'                Me.lblNoOfDevToShip.Text = dtDeviceSNsForWO.Rows.Count
'                '********************************************************

'            Catch ex As Exception
'                MsgBox("frmMoto_RL_Shiping.btnPrint_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "frmMoto_RL_Shiping")
'            Finally

'                If Not IsNothing(dt) Then
'                    If Not IsDBNull(dt) Then
'                        dt.Dispose()
'                    End If
'                    dt = Nothing
'                End If

'                If Not IsNothing(objMotoSubcontract_Biz) Then
'                    objMotoSubcontract_Biz = Nothing
'                End If
'                If Not IsNothing(ObjUtilib) Then
'                    ObjUtilib = Nothing
'                End If
'                If Not IsNothing(objFedex) Then
'                    objFedex = Nothing
'                End If

'                If iErr = 0 Then
'                    Me.lstDevices.Items.Clear()
'                    Me.lblCount.Text = "0"
'                    Me.chkCloseOverPack.Checked = False
'                End If

'                Me.grdRMAInfo.Focus()

'                Me.btnPrint.Enabled = True
'                Cursor.Current = Cursors.Default
'            End Try

'        End Sub
'        '****************************************************************
'        'Executes Print command 
'        '****************************************************************
'        Public Function Print(ByVal strPrinterName As String, _
'                                ByVal booLandscape As Boolean, _
'                                ByVal strRptName As String, _
'                                ByVal strFormula As String, _
'                                ByVal iNumOfCopies As Integer) As Integer

'            Dim ps As New PrinterSettings()
'            Dim rptApp As New CRAXDRT.Application()
'            Dim rpt As CRAXDRT.Report

'            Try
'                '*****************************************************************
'                ps.PrinterName = strPrinterName         '"Default on WCCELLULAR"
'                ps.DefaultPageSettings.Landscape = booLandscape
'                rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & strRptName)
'                rpt.RecordSelectionFormula = strFormula
'                rpt.PrintOut(False, iNumOfCopies)

'                '*****************************************************************
'                Return 1

'            Catch ex As Exception
'                MsgBox("frmMoto_RL_Shiping.Print: " & ex.Message.ToString, MsgBoxStyle.Critical, "frmMoto_RL_Shiping")
'                Return 0
'            Finally
'                If Not IsNothing(ps) Then
'                    ps = Nothing
'                End If
'                If Not IsNothing(rpt) Then
'                    rpt = Nothing
'                End If
'                If Not IsNothing(rptApp) Then
'                    rptApp = Nothing
'                End If
'            End Try

'        End Function

'        '****************************************************************
'        'This does all the printing
'        '****************************************************************
'        Private Sub DoPrinting(ByVal iShip_ID As Integer)

'            Dim R1 As DataRow
'            Dim j As Integer
'            Dim iRet As Integer
'            Dim strFormula As String

'            Try
'                '********************************************************
'                'Print         
'                '********************************************************
'                '////Shipping Manifest
'                strFormula = "{tdevice.Ship_ID} = " & iShip_ID
'                iRet = Me.Print("Default on WCCELLULAR", True, "Ship_Manifest.rpt", strFormula, 2)
'                'iRet = Me.Print("Default on WCCELLULAR", True, "Ship_Manifest_Test.rpt", strFormula, 2)
'                strFormula = ""

'                Select Case Me.OverPackProcess
'                    Case 0
'                        '*******************
'                        'Ship Master Label
'                        strFormula = "{tdevice.Ship_ID} = " & iShip_ID
'                        iRet = Me.Print("PARALLEL4 on FP10196F", False, "Ship_Master_Label.rpt", strFormula, 1)
'                        'iRet = Me.Print("PARALLEL4 on FP10196F", False, "Ship_Master_Label_Test.rpt", strFormula, 1)
'                        strFormula = ""

'                    Case Else   '1, 2, 3    RUR, BER, RNR
'                        'Ship Master Label
'                        strFormula = "{tdevice.Ship_ID} = " & iShip_ID
'                        iRet = Me.Print("PARALLEL2 on FP10196F", False, "Ship_RUR_BER_RNR_Label.rpt", strFormula, 1)
'                        'iRet = Me.Print("PARALLEL2 on FP10196F", False, "Ship_RUR_BER_RNR_Label_Test.rpt", strFormula, 1)
'                        strFormula = ""
'                End Select

'            Catch ex As Exception
'                MsgBox("frmMoto_RL_Shiping.DoPrinting: " & ex.Message.ToString, MsgBoxStyle.Critical, "frmMoto_RL_Shiping")
'            End Try
'        End Sub

'        '****************************************************************
'        'Handles the grdRMAGrid row/column change event
'        '****************************************************************
'        Private Sub grdRMAInfo_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdRMAInfo.RowColChange
'            Try
'                '**************************************************************
'                If iWO_ID <> CInt(Me.grdRMAInfo.Columns("WO_ID").Value) Then
'                    Me.lstDevices.Items.Clear()
'                End If

'                iWO_ID = CInt(Me.grdRMAInfo.Columns("WO_ID").Value)
'                iSKU_ID = CInt(Me.grdRMAInfo.Columns("SKU_ID").Value)
'                iWO_Quantity = CInt(Me.grdRMAInfo.Columns("WO_Quantity").Value)
'                iNumDevicestoBeShipped = CInt(Me.grdRMAInfo.Columns("DevicesToBeShipped").Value)

'                '**************************************************************************************
'                'Goto database and bring all device serial numbers available for the workorder selected
'                '**************************************************************************************
'                If iWO_ID <> 0 Then
'                    Me.RefreshTable(iWO_ID)
'                End If
'                Me.lblNoOfDevToShip.Text = dtDeviceSNsForWO.Rows.Count

'            Catch ex As Exception
'                MsgBox("frmMoto_RL_Shiping.grdRMAInfo_RowColChange: " & ex.Message.ToString, MsgBoxStyle.Critical, "frmMoto_RL_Shiping")
'            End Try
'        End Sub
'        '****************************************************************
'        'Refresh Datatable
'        '****************************************************************
'        Private Sub RefreshTable(ByVal iWOID As Integer)
'            Try
'                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()

'                If Not IsNothing(dtDeviceSNsForWO) Then
'                    dtDeviceSNsForWO.Dispose()
'                    dtDeviceSNsForWO = Nothing
'                End If

'                'dtDeviceSNsForWO = objMotoSubcontract_Biz.GetDeviceSNsForWO(iWOID)  'For RL
'                dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForWOBasedShipping(iWOID)  'For RL

'                'dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForModelBasedShipping(iSKU_ID)  'For NSC
'                Me.txtDevice.Focus()
'            Catch ex As Exception
'                MsgBox("frmMoto_RL_Shiping.RefreshTable: " & ex.Message.ToString, MsgBoxStyle.Critical, "frmMoto_RL_Shiping")
'            Finally
'                objMotoSubcontract_Biz = Nothing
'            End Try

'        End Sub
'        '****************************************************************
'        'This fills the RMA Grid
'        '****************************************************************
'        Private Sub FillRMAGrid()

'            Dim dt As DataTable

'            Try
'                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
'                dt = objMotoSubcontract_Biz.GetRMAGridData(Me.cboCustomer.SelectedValue)
'                Me.grdRMAInfo.ClearFields()
'                Me.grdRMAInfo.DataSource = dt.DefaultView
'            Catch ex As Exception
'                MsgBox("frmMoto_RL_Shiping.FillRMAGrid: " & ex.Message.ToString, MsgBoxStyle.Critical, "frmMoto_RL_Shiping")
'            Finally

'                If Not IsNothing(dt) Then
'                    If Not IsDBNull(dt) Then
'                        dt.Dispose()
'                    End If
'                    dt = Nothing
'                End If
'                objMotoSubcontract_Biz = Nothing
'            End Try
'        End Sub
'        '****************************************************************
'        'This fills the customer combo box
'        '****************************************************************
'        Private Sub FillCustomerComboBox()
'            Dim dt As DataTable
'            Dim R1 As DataRow

'            Try
'                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
'                'dt = objMotoSubcontract_Biz.GetCustomers(1844)  'Pass cust_id for Motorola RL
'                dt = objMotoSubcontract_Biz.GetCustomers
'                '**************************************************
'                'Fill the Customer combo box
'                '**************************************************
'                Me.cboCustomer.DataSource = dt.DefaultView
'                Me.cboCustomer.DisplayMember = dt.Columns("cust_name1").ToString
'                Me.cboCustomer.ValueMember = dt.Columns("cust_id").ToString
'                Me.cboCustomer.SelectedValue = 1844         'Hardcoded for the currect customer

'                'MsgBox("SelectedValue = " & Me.cboCustomer.SelectedValue)     '1403
'                'MsgBox("SelectedIndex = " & Me.cboCustomer.SelectedIndex)     '0 first item
'                'MsgBox(Me.cboCustomer.Text)                                   'Motorola NSC - Cellular
'                '**************************************************
'                'Fill the Customer Name and Customer address labels
'                '**************************************************
'                For Each R1 In dt.Rows
'                    'Me.cboCustomer.Items.Add(Trim(R1("cust_name1")))
'                    Select Case R1("cust_id")
'                        Case Me.cboCustomer.SelectedValue
'                            Me.lblCompany.Text = Trim(R1("cust_name1"))
'                            Me.lblAddress.Text = Trim(R1("Loc_Address1")) & ", " & Trim(R1("Loc_Address2")) & vbCrLf & Trim(R1("Loc_City")) & ", " & Trim(R1("state_short")) & " " & Trim(R1("Loc_Zip"))
'                        Case Else
'                            '//
'                    End Select
'                Next
'                '**************************************************
'            Catch ex As Exception
'                MsgBox("frmMoto_RL_Shiping.FillCustomerComboBox: " & ex.Message.ToString, MsgBoxStyle.Critical, "frmMoto_RL_Shiping")
'            Finally

'                If Not IsNothing(dt) Then
'                    If Not IsDBNull(dt) Then
'                        dt.Dispose()
'                    End If
'                    dt = Nothing
'                End If
'                objMotoSubcontract_Biz = Nothing
'            End Try
'        End Sub

'        '***************************************************************************
'        'This event fires when a device is scanned in
'        '***************************************************************************
'        Private Sub txtDevice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevice.KeyDown
'            Dim iDevId As Integer = 0
'            Dim objfrmShipping As New PSS.Gui.Shipping.frmShipping()
'            Try
'                If e.KeyValue = 13 Then

'                    Dim i As Integer = 0
'                    Dim iDeviceBelongstoWO As Integer = 0
'                    Dim R1 As DataRow
'                    Dim strOverPackProcess As String

'                    'Check if the Me.lstDevices.Items.Count is less than NumOfDevicestoBeShipped
'                    If Me.lstDevices.Items.Count < iNumDevicestoBeShipped Then

'                        'Check if the Max limit for the list box is reached
'                        If Me.lstDevices.Items.Count = 25 Then
'                            MsgBox("You have reached the maximum number of devies that can be added to a Master Pack.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                            Me.txtDevice.Text = ""
'                            Me.txtDevice.Focus()
'                            Exit Sub
'                        End If

'                        'check for duplicates in list, if exists exit sub
'                        For i = 0 To Me.lstDevices.Items.Count - 1
'                            If Me.lstDevices.Items(i) = UCase(txtDevice.Text) Then
'                                MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                                Me.txtDevice.Text = ""
'                                Me.txtDevice.Focus()
'                                Exit Sub
'                            End If
'                        Next

'                        'check if all the devices have been scanned in (Shipped)
'                        If dtDeviceSNsForWO.Rows.Count = 0 Then
'                            MsgBox("There are no more devices to scan for this RMA Number.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                            Me.txtDevice.Text = ""
'                            Me.txtDevice.Focus()
'                            Exit Sub
'                        End If

'                        'Check if this Device belongs to this WO and Process
'                        For Each R1 In dtDeviceSNsForWO.Rows
'                            If Trim(R1("Device_SN")) = UCase(Trim(Me.txtDevice.Text)) Then
'                                iDevId = R1("Device_ID")
'                                'Determine what the current phone Process is
'                                strOverPackProcess = Me.WhatIsTheOverPackProcess(CInt(R1("billcode_rule")))

'                                Select Case Me.OverPackProcess
'                                    Case 0  'Regular Phones
'                                        If strOverPackProcess <> "Regular" Then
'                                            MsgBox("You are trying to scan in a " & strOverPackProcess & " phone which is not allowed in the current process.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                                            Me.txtDevice.Text = ""
'                                            Me.txtDevice.Focus()
'                                            Exit Sub
'                                        End If
'                                    Case 1  'RUR
'                                        If strOverPackProcess <> "RUR" Then
'                                            MsgBox("You are trying to scan in a " & strOverPackProcess & " phone which is not allowed in the current process.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                                            Me.txtDevice.Text = ""
'                                            Me.txtDevice.Focus()
'                                            Exit Sub
'                                        End If
'                                    Case 2  'BER
'                                        If strOverPackProcess <> "BER" Then
'                                            MsgBox("You are trying to scan in a " & strOverPackProcess & " phone which is not allowed in the current process.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                                            Me.txtDevice.Text = ""
'                                            Me.txtDevice.Focus()
'                                            Exit Sub
'                                        End If
'                                        'Case 3  'RNR
'                                        '    If strOverPackProcess <> "RNR" Then
'                                        '        MsgBox("You are trying to scan in a " & strOverPackProcess & " phone which is not allowed in the current process.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                                        '        Me.txtDevice.Text = ""
'                                        '        Exit Sub
'                                        '    End If
'                                End Select

'                                iDeviceBelongstoWO = 1
'                                Exit For
'                            End If
'                        Next

'                        'else give a message (Can't add anymore) and empty txtDevice text box
'                        If iDeviceBelongstoWO = 0 Then
'                            MsgBox("Device can't be scanned for any of the following reasons: It does not belong to this RMA Number or it is not yet billed or it is already shipped.", MsgBoxStyle.Information, "frmMoto_RL_Shiping")
'                            Me.txtDevice.Text = ""
'                            Me.txtDevice.Focus()
'                            Exit Sub
'                        End If
'                        '**********************************************************************
'                        'Check for motorola missing data for Regular phones (Overpack process = 0)
'                        '**********************************************************************
'                        If Me.OverPackProcess = 0 Then

'                            Dim strVar As String = ""
'                            strVar = objfrmShipping.CheckForMissingDataForMotorola(iDevId)

'                            If strVar <> "" Then
'                                MsgBox(strVar + "Can't ship this device at this time. Take this error message to the receiver/tech who worked on it.", MsgBoxStyle.Information, "Motorola Data Missing")
'                                Me.txtDevice.Text = ""
'                                Me.txtDevice.Focus()
'                                Cursor.Current = System.Windows.Forms.Cursors.Default
'                                Exit Sub
'                            End If
'                        End If
'                        '**********************************************************************

'                        'If everything is fine then add this Device_SN to the list box
'                        Me.lstDevices.Items.Add(UCase(Trim(Me.txtDevice.Text)))
'                        Me.lblCount.Text = lstDevices.Items.Count
'                        Me.txtDevice.Text = ""
'                        Me.txtDevice.Focus()
'                    Else
'                        MsgBox("Maximum number of devices that can be shipped with this RMA has been reached. Can't ship any more devices with this RMA.", MsgBoxStyle.Information, "Motorola RL Shipping")
'                        Me.txtDevice.Text = ""
'                        Me.txtDevice.Focus()
'                        Exit Sub
'                        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
'                    End If
'                End If
'            Catch ex As Exception
'                MsgBox("frmMoto_RL_Shiping.txtDevice_KeyDown: " & ex.Message.ToString, MsgBoxStyle.Critical, "frmMoto_RL_Shiping")
'            Finally
'                objfrmShipping = Nothing
'            End Try
'        End Sub
'        '***************************************************************************
'        'Returns the Over Pack Process   (Bill code rules)
'        '**************************************************************************
'        Private Function WhatIsTheOverPackProcess(ByVal iBillCodeRule As Integer)
'            Select Case iBillCodeRule
'                Case 1
'                    Return "RUR"
'                Case 2
'                    Return "BER"
'                Case Else
'                    Return "Regular"

'            End Select
'        End Function
'        '***************************************************************************
'        'Disposes the class level data table
'        '*****************************************
'        Private Sub DisposeDataTable()
'            Try
'                If Not IsNothing(dtDeviceSNsForWO) Then
'                    If Not IsDBNull(dtDeviceSNsForWO) Then
'                        dtDeviceSNsForWO.Dispose()
'                    End If
'                    dtDeviceSNsForWO = Nothing
'                End If
'            Catch ex As Exception
'                Throw New Exception("frmMoto_RL_Shiping.DisposeDatatable: " + ex.Message.ToString)
'            End Try
'        End Sub

'        '****************************************************************************
'        Private Sub grdRMAInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdRMAInfo.Click
'            Me.txtDevice.Focus()
'        End Sub
'        '****************************************************************************
'        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
'            Me.lstDevices.Items.Clear()
'            Me.lblCount.Text = lstDevices.Items.Count
'        End Sub
'        '****************************************************************************
'        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
'            Dim myfrmObj As New frmReprint()
'            myfrmObj.ShowDialog()
'            myfrmObj = Nothing

'        End Sub
'        '****************************************************************************
'        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
'            Dim myfrmObj As New frmReprint()
'            myfrmObj.ShowDialog()
'            myfrmObj = Nothing
'        End Sub
'        '****************************************************************************
'        Private Shared Sub SetHandler(ByVal ctl As Control)
'            AddHandler ctl.Enter, EnterHandler
'            AddHandler ctl.Leave, LeaveHandler
'            AddHandler ctl.Click, EnterHandler
'        End Sub

'        Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
'            Change_Color(sender, HighLightColor)
'        End Sub

'        Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
'            Change_Color(sender, WindowColor)
'        End Sub

'        Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
'            Dim Type As String = sender.GetType.Name.ToString
'            Select Case Type
'                Case "ComboBox"
'                    CType(sender, ComboBox).BackColor = color
'                Case "TextBox"
'                    CType(sender, TextBox).BackColor = color
'                Case Else
'                    'no other types should be hightlighted.

'            End Select
'        End Sub
'        '******************************************************************************
'        Private Function GetNumOfDevicetobeShippedWithRMA(ByVal iPallett_ID As Integer) As Integer

'            Dim iNumDevicesInPallett As Integer = 0
'            Dim iNumOfDevicestoBeShipped As Integer
'            Dim dt As DataTable
'            Dim R1 As DataRow

'            Try
'                dt = objMotoSubcontract_Biz.GetNumOfDevicesInPallett(iPallett_ID)
'                For Each R1 In dt.Rows      'There will be only one row.
'                    iNumDevicesInPallett = R1("DevicesInPallett")
'                    Exit For
'                Next

'                iNumOfDevicestoBeShipped = (iWO_Quantity - iNumDevicesInPallett)

'                Return iNumOfDevicestoBeShipped

'            Catch ex As Exception
'                Throw
'            Finally
'                '*****************************
'                'Destroy the datatable
'                '*****************************
'                If Not IsNothing(dt) Then
'                    If Not IsDBNull(dt) Then
'                        dt.Dispose()
'                    End If
'                    dt = Nothing
'                End If
'                '*****************************
'            End Try
'        End Function
'        '******************************************************************************
'        Private Function GetDevice_ID(ByVal strDevice_SN As String) As Integer
'            Dim R1 As DataRow
'            Dim iDevId As Integer = 0
'            Try
'                For Each R1 In dtDeviceSNsForWO.Rows
'                    If Trim(R1("Device_SN")) = strDevice_SN Then
'                        iDevId = R1("Device_ID")
'                        Exit For
'                    End If
'                Next R1
'            Catch ex As Exception
'                Throw ex
'            End Try

'            Return iDevId
'        End Function
'        '******************************************************************************
'        Protected Overrides Sub Finalize()
'            MyBase.Finalize()
'            DisposeDataTable()
'            Me.Close()
'            Me.Dispose()
'        End Sub
'        '******************************************************************************
'        Private Sub btnRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRpt.Click

'            Dim myfrmObj As New frmRpt(Me.cboCustomer.SelectedValue, , iWO_ID)
'            myfrmObj.ShowDialog()
'            myfrmObj = Nothing

'        End Sub
'        '******************************************************************************
'    End Class
'End Namespace




