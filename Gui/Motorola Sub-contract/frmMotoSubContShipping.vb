Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing
Imports System.Drawing.Printing
Imports PSS.Core
'Imports System.String

'Imports PSS.Data

Namespace Gui.MotorolaSubcontract
    Public Class frmMotoSubContShipping
        Inherits System.Windows.Forms.Form

        Private dtDeviceSNsForWO As DataTable
        Private dtLoc As DataTable
        Private dtRMAGridData As DataTable
        Private iWO_ID As Integer = 0
        'Private iSKU_ID As Integer = 0
        Private iModel_ID As Integer = 0
        Private iLocMap_ShipType As Integer = 0
        Private ObjUtilib As MyLib.Utility
        Private objFedex As PSS.Gui.MotorolaSubcontract.Fedex
        Private objMotoSubcontract_Biz As PSS.Data.Buisness.MotorolaSubcontract_Biz
        Private objWorkDate As PSS.Data.Buisness.WorkDate
        Private objMisc As PSS.Data.Buisness.Misc
        Private iOverpack_Process As Integer
        Private iNumDevicestoBeShipped As Integer = 0
        Private iNumDevicesRcvd As Integer = 0
        Private iWO_Quantity As Integer = 0
        Private iCust_ID As Integer = 0
        Private iLoc_ID As Integer = 0
        Private iPhoneType As Integer = 0
        Private strShortLongFlg As String = ""

        Private iPrintPallettManifest As Integer = 0
        Private iPallettQty As Integer = 0
        Private iMasterPackQty As Integer = 0
        Private iOverPackQty As Integer = 0
        Private iPrintMasterManifest As Integer = 0
        Private iPrintCoffinLabel As Integer = 0
        Private iPrintMasterLabel As Integer = 0
        Private iPrintOverPackManifest As Integer = 0
        Private iPrintOverPackLbl As Integer = 0
        Private iPrintPallettLbl As Integer = 0
        Private iPrintQCReport As Integer = 0
        Private strPallettManifestName As String = ""
        Private strCoffinLabelPrinter As String = ""
        Private strCoffinLabelName As String = ""
        Private strMasterLblPrinter As String = ""
        Private strMasterManifestName As String = ""
        Private strMasterLblName As String = ""
        Private strOverPackManifestName As String = ""
        Private strOverPackLblPrinter As String = ""
        Private strPallettLabelName As String = ""
        Private strOverPackLblName As String = ""
        Private strPallettLblPrinter As String = ""
        Private iFlg As Integer = 0
        Private iShiftID As Integer = PSS.Core.[Global].ApplicationUser.IDShift
        Private strWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate

        Private Shared ctl As Control
        Private Shared HighLightColor As Color = Color.Yellow
        Private Shared WindowColor As Color = Color.PaleGoldenrod
        Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
        Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

#Region " Windows Form Designer generated code "




        Public Sub New(ByVal iDeviceType As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
            objMisc = New PSS.Data.Buisness.Misc()
            objWorkDate = New PSS.Data.Buisness.WorkDate()
            Me.OverPackProcess = iDeviceType

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
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents txtDevice As System.Windows.Forms.TextBox
        Friend WithEvents lblDate As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents grdRMAInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblCompany As System.Windows.Forms.Label
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents chkCloseOverPack As System.Windows.Forms.CheckBox
        Friend WithEvents btnRpt As System.Windows.Forms.Button
        Friend WithEvents PanelLocation As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents cboLocation As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblShipping As System.Windows.Forms.Label
        Friend WithEvents btnClearOne As System.Windows.Forms.Button
        Friend WithEvents chkClosePallett As System.Windows.Forms.CheckBox
        Friend WithEvents chkPrintLables As System.Windows.Forms.CheckBox
        Friend WithEvents cmdReprintQCRep As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboGroup As PSS.Gui.Controls.ComboBox
        Friend WithEvents chkNoQC As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMotoSubContShipping))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.txtDevice = New System.Windows.Forms.TextBox()
            Me.lblDate = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.grdRMAInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblCompany = New System.Windows.Forms.Label()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.chkCloseOverPack = New System.Windows.Forms.CheckBox()
            Me.chkClosePallett = New System.Windows.Forms.CheckBox()
            Me.chkPrintLables = New System.Windows.Forms.CheckBox()
            Me.btnRpt = New System.Windows.Forms.Button()
            Me.PanelLocation = New System.Windows.Forms.Panel()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboGroup = New PSS.Gui.Controls.ComboBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cboLocation = New PSS.Gui.Controls.ComboBox()
            Me.lblShipping = New System.Windows.Forms.Label()
            Me.btnClearOne = New System.Windows.Forms.Button()
            Me.cmdReprintQCRep = New System.Windows.Forms.Button()
            Me.chkNoQC = New System.Windows.Forms.CheckBox()
            CType(Me.grdRMAInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelLocation.SuspendLayout()
            Me.SuspendLayout()
            '
            'lstDevices
            '
            Me.lstDevices.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lstDevices.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.lstDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstDevices.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstDevices.ForeColor = System.Drawing.Color.Black
            Me.lstDevices.Location = New System.Drawing.Point(654, 212)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(157, 223)
            Me.lstDevices.TabIndex = 35
            '
            'txtDevice
            '
            Me.txtDevice.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.txtDevice.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.txtDevice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDevice.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDevice.ForeColor = System.Drawing.Color.Black
            Me.txtDevice.Location = New System.Drawing.Point(654, 190)
            Me.txtDevice.Name = "txtDevice"
            Me.txtDevice.Size = New System.Drawing.Size(157, 21)
            Me.txtDevice.TabIndex = 34
            Me.txtDevice.Text = ""
            '
            'lblDate
            '
            Me.lblDate.BackColor = System.Drawing.Color.Transparent
            Me.lblDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDate.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblDate.Location = New System.Drawing.Point(45, 56)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New System.Drawing.Size(184, 16)
            Me.lblDate.TabIndex = 33
            Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(5, 56)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(46, 16)
            Me.Label2.TabIndex = 32
            Me.Label2.Text = "Date:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnReprint
            '
            Me.btnReprint.BackColor = System.Drawing.Color.Transparent
            Me.btnReprint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprint.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnReprint.Location = New System.Drawing.Point(264, 442)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(96, 32)
            Me.btnReprint.TabIndex = 31
            Me.btnReprint.Text = "Reprint"
            '
            'btnPrint
            '
            Me.btnPrint.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnPrint.BackColor = System.Drawing.Color.Transparent
            Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrint.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnPrint.Location = New System.Drawing.Point(654, 442)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(157, 32)
            Me.btnPrint.TabIndex = 30
            Me.btnPrint.Text = "Ship"
            '
            'lblCount
            '
            Me.lblCount.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblCount.BackColor = System.Drawing.Color.Transparent
            Me.lblCount.Font = New System.Drawing.Font("Verdana", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblCount.Location = New System.Drawing.Point(822, 174)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(98, 47)
            Me.lblCount.TabIndex = 29
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(821, 158)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 28
            Me.Label3.Text = "Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'grdRMAInfo
            '
            Me.grdRMAInfo.AllowColMove = False
            Me.grdRMAInfo.AllowFilter = True
            Me.grdRMAInfo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.grdRMAInfo.AllowSort = True
            Me.grdRMAInfo.AllowUpdate = False
            Me.grdRMAInfo.AllowUpdateOnBlur = False
            Me.grdRMAInfo.AlternatingRows = True
            Me.grdRMAInfo.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grdRMAInfo.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.grdRMAInfo.CaptionHeight = 18
            Me.grdRMAInfo.CollapseColor = System.Drawing.Color.Black
            Me.grdRMAInfo.DataChanged = False
            Me.grdRMAInfo.BackColor = System.Drawing.Color.Empty
            Me.grdRMAInfo.ExpandColor = System.Drawing.Color.Black
            Me.grdRMAInfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grdRMAInfo.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdRMAInfo.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdRMAInfo.Location = New System.Drawing.Point(8, 191)
            Me.grdRMAInfo.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.grdRMAInfo.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.grdRMAInfo.Name = "grdRMAInfo"
            Me.grdRMAInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdRMAInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdRMAInfo.PreviewInfo.ZoomFactor = 75
            Me.grdRMAInfo.PrintInfo.ShowOptionsDialog = False
            Me.grdRMAInfo.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.grdRMAInfo.RowDivider = GridLines1
            Me.grdRMAInfo.RowHeight = 15
            Me.grdRMAInfo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.grdRMAInfo.ScrollTips = False
            Me.grdRMAInfo.Size = New System.Drawing.Size(632, 244)
            Me.grdRMAInfo.TabIndex = 27
            Me.grdRMAInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}S" & _
            "tyle12{}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selecte" & _
            "d{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;BackColor:Contr" & _
            "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Inactive{Fo" & _
            "reColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Captio" & _
            "n{AlignHorz:Center;}Editor{}Style10{AlignHorz:Near;}Normal{Font:Verdana, 8.25pt;" & _
            "BackColor:PaleGoldenrod;}Style29{}Style28{}Style27{}Style26{}HighlightRow{ForeCo" & _
            "lor:HighlightText;BackColor:Highlight;}Style2{}OddRow{}RecordSelector{AlignImage" & _
            ":Center;}Style1{}Style8{}Style3{}Style11{}Style9{}</Data></Styles><Splits><C1.Wi" & _
            "n.C1TrueDBGrid.MergeView AllowColMove=""False"" Name="""" AlternatingRowStyle=""True""" & _
            " CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyl" & _
            "e=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScroll" & _
            "Group=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 628, 240</ClientRect><Bord" & _
            "erSide>0</BorderSide><CaptionStyle parent=""Heading"" me=""Style10"" /><EditorStyle " & _
            "parent=""Editor"" me=""Style2"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Filt" & _
            "erBarStyle parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""St" & _
            "yle4"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading""" & _
            " me=""Style3"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveS" & _
            "tyle parent=""Inactive"" me=""Style6"" /><OddRowStyle parent=""OddRow"" me=""Style9"" />" & _
            "<RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle paren" & _
            "t=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueD" & _
            "BGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pare" & _
            "nt=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""" & _
            "Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""N" & _
            "ormal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Norma" & _
            "l"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Norm" & _
            "al"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""N" & _
            "ormal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vert" & _
            "Splits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Default" & _
            "RecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 628, 240</ClientArea></Blob" & _
            ">"
            '
            'lblCompany
            '
            Me.lblCompany.BackColor = System.Drawing.Color.Transparent
            Me.lblCompany.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCompany.ForeColor = System.Drawing.Color.MidnightBlue
            Me.lblCompany.Location = New System.Drawing.Point(448, 50)
            Me.lblCompany.Name = "lblCompany"
            Me.lblCompany.Size = New System.Drawing.Size(427, 21)
            Me.lblCompany.TabIndex = 40
            Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblAddress
            '
            Me.lblAddress.BackColor = System.Drawing.Color.Transparent
            Me.lblAddress.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAddress.ForeColor = System.Drawing.Color.MidnightBlue
            Me.lblAddress.Location = New System.Drawing.Point(448, 74)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(428, 48)
            Me.lblAddress.TabIndex = 42
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.BackColor = System.Drawing.Color.Transparent
            Me.btnClear.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnClear.Location = New System.Drawing.Point(820, 270)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClear.Size = New System.Drawing.Size(102, 32)
            Me.btnClear.TabIndex = 43
            Me.btnClear.Text = "Clear All"
            '
            'chkCloseOverPack
            '
            Me.chkCloseOverPack.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.chkCloseOverPack.BackColor = System.Drawing.Color.Transparent
            Me.chkCloseOverPack.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkCloseOverPack.ForeColor = System.Drawing.SystemColors.ControlText
            Me.chkCloseOverPack.Location = New System.Drawing.Point(654, 161)
            Me.chkCloseOverPack.Name = "chkCloseOverPack"
            Me.chkCloseOverPack.Size = New System.Drawing.Size(130, 24)
            Me.chkCloseOverPack.TabIndex = 44
            Me.chkCloseOverPack.Text = "Close Overpack"
            Me.ToolTip1.SetToolTip(Me.chkCloseOverPack, "Applies only to Regular phones. Check this if you want to close this Overpack. Do" & _
            "es not apply to RUR, BER, RNR phones. ")
            '
            'chkClosePallett
            '
            Me.chkClosePallett.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.chkClosePallett.BackColor = System.Drawing.Color.Transparent
            Me.chkClosePallett.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkClosePallett.ForeColor = System.Drawing.SystemColors.ControlText
            Me.chkClosePallett.Location = New System.Drawing.Point(654, 139)
            Me.chkClosePallett.Name = "chkClosePallett"
            Me.chkClosePallett.Size = New System.Drawing.Size(130, 24)
            Me.chkClosePallett.TabIndex = 53
            Me.chkClosePallett.Text = "Close Pallett"
            Me.ToolTip1.SetToolTip(Me.chkClosePallett, "To close a Pallett check this box.. ")
            '
            'chkPrintLables
            '
            Me.chkPrintLables.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.chkPrintLables.BackColor = System.Drawing.Color.Transparent
            Me.chkPrintLables.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkPrintLables.ForeColor = System.Drawing.SystemColors.ControlText
            Me.chkPrintLables.Location = New System.Drawing.Point(448, 138)
            Me.chkPrintLables.Name = "chkPrintLables"
            Me.chkPrintLables.Size = New System.Drawing.Size(160, 24)
            Me.chkPrintLables.TabIndex = 54
            Me.chkPrintLables.Text = "Do not Print Labels"
            Me.ToolTip1.SetToolTip(Me.chkPrintLables, "Check this box if you don't want the labels printed.")
            '
            'btnRpt
            '
            Me.btnRpt.BackColor = System.Drawing.Color.Transparent
            Me.btnRpt.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRpt.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnRpt.Location = New System.Drawing.Point(88, 480)
            Me.btnRpt.Name = "btnRpt"
            Me.btnRpt.Size = New System.Drawing.Size(240, 32)
            Me.btnRpt.TabIndex = 47
            Me.btnRpt.Text = "Show Devices to be Shipped"
            Me.btnRpt.Visible = False
            '
            'PanelLocation
            '
            Me.PanelLocation.BackColor = System.Drawing.Color.Transparent
            Me.PanelLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.cboGroup, Me.Label1, Me.cboCustomer, Me.Label5, Me.cboLocation})
            Me.PanelLocation.Location = New System.Drawing.Point(8, 91)
            Me.PanelLocation.Name = "PanelLocation"
            Me.PanelLocation.Size = New System.Drawing.Size(398, 93)
            Me.PanelLocation.TabIndex = 50
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label4.Location = New System.Drawing.Point(6, 9)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(74, 16)
            Me.Label4.TabIndex = 55
            Me.Label4.Text = "Group:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboGroup
            '
            Me.cboGroup.AutoComplete = True
            Me.cboGroup.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.cboGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboGroup.ForeColor = System.Drawing.Color.Black
            Me.cboGroup.Location = New System.Drawing.Point(80, 6)
            Me.cboGroup.Name = "cboGroup"
            Me.cboGroup.Size = New System.Drawing.Size(307, 21)
            Me.cboGroup.TabIndex = 54
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(6, 37)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(74, 16)
            Me.Label1.TabIndex = 53
            Me.Label1.Text = "Customer:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.cboCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.ForeColor = System.Drawing.Color.Black
            Me.cboCustomer.Location = New System.Drawing.Point(80, 34)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(307, 21)
            Me.cboCustomer.TabIndex = 52
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(9, 65)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(72, 16)
            Me.Label5.TabIndex = 51
            Me.Label5.Text = "Location:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboLocation
            '
            Me.cboLocation.AutoComplete = True
            Me.cboLocation.BackColor = System.Drawing.Color.PaleGoldenrod
            Me.cboLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.ForeColor = System.Drawing.Color.Black
            Me.cboLocation.Location = New System.Drawing.Point(80, 62)
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.Size = New System.Drawing.Size(307, 21)
            Me.cboLocation.TabIndex = 50
            '
            'lblShipping
            '
            Me.lblShipping.Font = New System.Drawing.Font("Comic Sans MS", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipping.ForeColor = System.Drawing.Color.Crimson
            Me.lblShipping.Location = New System.Drawing.Point(2, 2)
            Me.lblShipping.Name = "lblShipping"
            Me.lblShipping.Size = New System.Drawing.Size(400, 42)
            Me.lblShipping.TabIndex = 51
            Me.lblShipping.Text = "Customer Specific Shipping"
            '
            'btnClearOne
            '
            Me.btnClearOne.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClearOne.BackColor = System.Drawing.Color.Transparent
            Me.btnClearOne.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClearOne.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnClearOne.Location = New System.Drawing.Point(821, 313)
            Me.btnClearOne.Name = "btnClearOne"
            Me.btnClearOne.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnClearOne.Size = New System.Drawing.Size(102, 32)
            Me.btnClearOne.TabIndex = 52
            Me.btnClearOne.Text = "Clear One"
            '
            'cmdReprintQCRep
            '
            Me.cmdReprintQCRep.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdReprintQCRep.Location = New System.Drawing.Point(56, 442)
            Me.cmdReprintQCRep.Name = "cmdReprintQCRep"
            Me.cmdReprintQCRep.Size = New System.Drawing.Size(184, 32)
            Me.cmdReprintQCRep.TabIndex = 55
            Me.cmdReprintQCRep.Text = "Recreate QC Report"
            Me.cmdReprintQCRep.Visible = False
            '
            'chkNoQC
            '
            Me.chkNoQC.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.chkNoQC.BackColor = System.Drawing.Color.Transparent
            Me.chkNoQC.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkNoQC.ForeColor = System.Drawing.SystemColors.ControlText
            Me.chkNoQC.Location = New System.Drawing.Point(448, 160)
            Me.chkNoQC.Name = "chkNoQC"
            Me.chkNoQC.Size = New System.Drawing.Size(160, 24)
            Me.chkNoQC.TabIndex = 56
            Me.chkNoQC.Text = "QC not Required"
            Me.ToolTip1.SetToolTip(Me.chkNoQC, "Check this box if you don't want the labels printed.")
            '
            'frmMotoSubContShipping
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 13)
            Me.BackColor = System.Drawing.Color.DarkKhaki
            Me.ClientSize = New System.Drawing.Size(928, 524)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkNoQC, Me.cmdReprintQCRep, Me.chkPrintLables, Me.chkClosePallett, Me.btnClearOne, Me.lblShipping, Me.PanelLocation, Me.btnRpt, Me.chkCloseOverPack, Me.btnClear, Me.lblAddress, Me.lblCompany, Me.lstDevices, Me.txtDevice, Me.lblDate, Me.Label2, Me.btnReprint, Me.btnPrint, Me.lblCount, Me.Label3, Me.grdRMAInfo})
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Name = "frmMotoSubContShipping"
            Me.Text = "NSC Shipping"
            CType(Me.grdRMAInfo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelLocation.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Property OverPackProcess()
            Get
                Return Me.iOverpack_Process
            End Get
            Set(ByVal Value)
                Me.iOverpack_Process = Value
            End Set
        End Property

        

        Private Sub frmMotoSubContShipping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.lblDate.Text = Now()
            FillGroupComboBox()
            FillCustomerComboBox()

            'Handlers to highlight in custom colors
            SetHandler(Me.cboCustomer)
            SetHandler(Me.cboLocation)
            SetHandler(Me.txtDevice)

            'Set tool tips
            ToolTip1.SetToolTip(Me.btnReprint, "Please make sure to select the right RMA Number before Reprinting.")
            ToolTip1.SetToolTip(Me.btnClear, "Click here to clear the list of scanned devices.")
            ToolTip1.SetToolTip(Me.btnPrint, "Click here to print labels after finishing scanning in the devices for the current masterpack.")
            ToolTip1.SetToolTip(Me.grdRMAInfo, "Click on the RMA Number for which you want to ship devices.")
            ToolTip1.SetToolTip(Me.btnRpt, "Click on the RMA Number first for which you want to see devices to be shipped.")

        End Sub

        '*****************************************
        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

            Dim strDeviceIDs As String = ""

            Me.btnPrint.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            If iLoc_ID = 0 Then
                MsgBox("Please select a Location.", MsgBoxStyle.Information)
                Me.grdRMAInfo.ClearFields()
                Me.lstDevices.Items.Clear()
                Me.btnPrint.Enabled = True
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            If IsDBNull(iWO_ID) Then
                MsgBox("Please select a RMA Number.", MsgBoxStyle.Information, "Shipping")
                Me.btnPrint.Enabled = True
                Cursor.Current = Cursors.Default
                Exit Sub
            End If
            If Me.lstDevices.Items.Count = 0 Then
                MsgBox("Please scan in devices to ship.", MsgBoxStyle.Information, "Shipping")
                Me.btnPrint.Enabled = True
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            If Me.OverPackProcess = 0 Then   'Regular
                Dim response As MsgBoxResult
                If Me.chkClosePallett.Checked = True Then
                    response = MsgBox("Are you sure you want to close this Pallett?", MsgBoxStyle.YesNo, "Shipping")

                    If response = MsgBoxResult.No Then
                        Me.btnPrint.Enabled = True
                        Cursor.Current = Cursors.Default
                        Exit Sub
                    End If

                ElseIf Me.chkCloseOverPack.Checked = True Then

                    response = MsgBox("Are you sure you want to close this Overpack?", MsgBoxStyle.YesNo, "Shipping")

                    If response = MsgBoxResult.No Then
                        Me.btnPrint.Enabled = True
                        Cursor.Current = Cursors.Default
                        Exit Sub
                    End If

                End If
            End If

            Dim i As Integer
            Dim j As Integer
            Dim dt As DataTable
            Dim strShipDate As String
            Dim R1 As DataRow
            Dim iErrFlag As Integer = 0
            Dim iErr As Integer = 0
            Dim R2 As DataRow
            Dim dt2 As DataTable
            Dim iPallett_ID As Integer = 0
            Dim iOverPack_ID As Integer = 0
            Dim iShip_ID As Integer
            Dim iProd_ID As Integer = 2 ' cellular Phone
            Dim iShipTo_ID As Integer = 0
            Dim strUser As String = PSS.Core.[Global].ApplicationUser.User


            Try
                'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()

                '****************************************************************************
                'Get "Work Date"
                '****************************************************************************
                strWorkDate = objWorkDate.WorkDate(iShiftID, Now)
                If Len(Trim(strWorkDate)) > 0 Then
                Else
                    MsgBox("'Work Date' could not be determined. Can't ship.", MsgBoxStyle.Information, "Shipping")
                    Me.btnPrint.Enabled = True
                    Cursor.Current = Cursors.Default
                    Exit Sub
                End If

                '****************************************************************************
                'First get the LOC_id for WO_ID
                '****************************************************************************
                Try
                    'dt = objMotoSubcontract_Biz.GetShipingInfo(iWO_ID)
                    dt = objMotoSubcontract_Biz.GetLOCID(iWO_ID)
                    For Each R1 In dt.Rows      'There will be only one row.
                        iLoc_ID = R1("Loc_ID")
                        If Not IsDBNull(R1("ShipTo_ID")) Then
                            iShipTo_ID = R1("ShipTo_ID")
                        End If
                        Exit For
                    Next
                Catch ex As Exception
                    iErrFlag = 1
                    MsgBox("frmMotoSubContShipping.BtnPrint_Click.GetLOCID: " & ex.Message.ToString)

                Finally
                    '*****************************
                    'Destroy the datatable
                    '*****************************
                    If Not IsNothing(dt) Then
                        If Not IsDBNull(dt) Then
                            dt.Dispose()
                        End If
                        dt = Nothing
                    End If
                End Try
                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '***************************************************************************
                'First get the Palette_ID for WO_ID
                '***************************************************************************
                Try
                    dt = objMotoSubcontract_Biz.GetPallettID(iWO_ID)

                    Dim ObjFrm As New frmSelectPallett(dt)
                    Try
                        If dt.Rows.Count > 1 Then   'There are more than one row

                            ObjFrm.ShowDialog()
                            'Capture the selected Overpack_ID
                            iPallett_ID = ObjFrm.PallettID

                            If iPallett_ID = 0 Then    'User didn't select an Overpack
                                iErr = 1
                                iErrFlag = 1  'User must select one of many Overpacks
                            End If

                        Else
                            For Each R1 In dt.Rows      'There will be only one row.
                                iPallett_ID = R1("Pallett_ID")
                                Exit For
                            Next
                        End If
                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.ObjFrm.ShowDialog(): " & ex.Message.ToString)
                    Finally
                        ObjFrm = Nothing
                    End Try

                Catch ex As Exception
                    iErrFlag = 1
                    MsgBox("frmMotoSubContShipping.BtnPrint_Click.GetPallettID: " & ex.Message.ToString)
                Finally
                    '******************************
                    'Destroy the datatable
                    '******************************
                    If Not IsNothing(dt) Then
                        If Not IsDBNull(dt) Then
                            dt.Dispose()
                        End If
                        dt = Nothing
                    End If
                End Try
                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '***************************************************************************
                'First get the OPen overpack_id for WO_ID
                '***************************************************************************
                Dim iCounter As Integer = 0
                If iPallett_ID <> 0 Then
                    If Me.OverPackProcess = 0 Then   'Regular

                        Try
                            dt = objMotoSubcontract_Biz.GetOverPackID(iPallett_ID, Me.OverPackProcess)

                            If dt.Rows.Count > 1 Then   'There are more than one row
                                '*************************************
                                Try
                                    For Each R1 In dt.Rows
                                        R1.BeginEdit()

                                        dt2 = objMotoSubcontract_Biz.GetNumOfMasterPacksForOverPack(R1("Overpack_ID"))
                                        For Each R2 In dt2.Rows

                                            If R2("NumOfMasterPacks") >= iOverPackQty Then     'iOverPackQty
                                                'need to delete that Overpack from dt
                                                R1.Delete()
                                            Else
                                                R1("MasterPacks") = R2("NumOfMasterPacks")  'Only one row returns
                                                iCounter = iCounter + 1
                                            End If

                                        Next
                                        '**************************
                                        'Destroy the datatable
                                        '**************************
                                        If Not IsNothing(dt2) Then
                                            If Not IsDBNull(dt2) Then
                                                dt2.Dispose()
                                            End If
                                            dt2 = Nothing
                                        End If
                                        '**************************

                                        R1.EndEdit()

                                    Next

                                Catch ex As Exception
                                    iErrFlag = 1
                                    MsgBox("frmMotoSubContShipping.BtnPrint_Click.GetNumOfMasterPacksForOverPack: " & ex.Message.ToString)
                                Finally
                                    '**************************
                                    'Destroy the datatable
                                    '**************************
                                    If Not IsNothing(dt2) Then
                                        If Not IsDBNull(dt2) Then
                                            dt2.Dispose()
                                        End If
                                        dt2 = Nothing
                                    End If
                                    '**************************
                                End Try
                                '*************************************
                                Dim myfrmObj As New frmSelectOverpack(dt)
                                If iErrFlag <> 1 Then
                                    Try
                                        'show a pop-up form with a list of overpacks
                                        If iCounter > 1 Then
                                            myfrmObj.ShowDialog()
                                            'Capture the selected Overpack_ID
                                            iOverPack_ID = myfrmObj.OverPackID
                                        Else
                                            dt.AcceptChanges()
                                            For Each R1 In dt.Rows      'There should be only one row
                                                iOverPack_ID = R1("Overpack_ID")
                                                Exit For
                                            Next
                                        End If

                                        If iOverPack_ID = 0 Then    'User didn't select an Overpack
                                            iErr = 1
                                            iErrFlag = 1  'User must select a one of many Overpacks
                                        End If

                                    Catch ex As Exception
                                        iErr = 1
                                        iErrFlag = 1
                                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.myfrmObj.ShowDialog(): " & ex.Message.ToString)
                                    Finally
                                        myfrmObj = Nothing
                                    End Try
                                End If


                                '*************************************
                            Else
                                For Each R1 In dt.Rows      'There will be only one row.
                                    iOverPack_ID = R1("OverPack_ID")
                                    Exit For
                                Next
                            End If


                        Catch ex As Exception
                            iErrFlag = 1
                            MsgBox("frmMotoSubContShipping.BtnPrint_Click.GetOverPackID: " & ex.Message.ToString)

                        Finally

                            '**************************
                            'Destroy the datatable
                            '**************************
                            If Not IsNothing(dt) Then
                                If Not IsDBNull(dt) Then
                                    dt.Dispose()
                                End If
                                dt = Nothing
                            End If
                        End Try
                    End If
                End If
                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '***************************************************************************
                'Create a new Pallett if iPallett_ID is NULL
                '***************************************************************************
                'Same for all processes
                If iPallett_ID = 0 And iOverPack_ID = 0 Then
                    Try
                        iPallett_ID = objMotoSubcontract_Biz.CreateNewPallett(iWO_ID, iLoc_ID)
                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.CreateNewPallett: " & ex.Message.ToString)
                    End Try
                    '***************************************************************************
                    If iErrFlag = 1 Then
                        iErrFlag = 0
                        Exit Try
                    End If
                    '***************************************************************************
                End If

                '***************************************************************************
                'if There is Pallett but no OverPack then create a new over pack
                '***************************************************************************
                'Not same for all processes
                If iOverPack_ID = 0 And iPallett_ID <> 0 Then
                    Try
                        iOverPack_ID = objMotoSubcontract_Biz.CreateNewOverPack(iPallett_ID, Me.OverPackProcess)
                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.CreateNewOverPack: " & ex.Message.ToString)
                    End Try
                    '***************************************************************************
                    If iErrFlag = 1 Then
                        iErrFlag = 0
                        Exit Try
                    End If
                    '***************************************************************************
                End If
                '***************************************************************************
                'Create Master Pack
                'create an entry into tship table
                '***************************************************************************
                ObjUtilib = New MyLib.Utility()
                Try
                    strShipDate = ObjUtilib.FormatDate_YYYYMMDD_HHMMSS(Now())
                    iShip_ID = objMotoSubcontract_Biz.CreateNewMasterPack(strShipDate, strUser, iProd_ID, iOverPack_ID, iShipTo_ID)
                Catch ex As Exception
                    iErrFlag = 1
                    MsgBox("frmMotoSubContShipping.BtnPrint_Click.CreateNewMasterPack: " & ex.Message.ToString)
                End Try
                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '***************************************************************************
                'Update the tdevice table
                '***************************************************************************
                Try
                    For j = 0 To Me.lstDevices.Items.Count - 1
                        'Update the tdevice table
                        'i = objMotoSubcontract_Biz.UpdateDeviceTable(GetDevice_ID(Me.lstDevices.Items(j)), iWO_ID, iSKU_ID, iShip_ID, strShipDate, iPallett_ID, iShiftID, strWorkDate)
                        i = objMotoSubcontract_Biz.UpdateDeviceTable(GetDevice_ID(Me.lstDevices.Items(j)), iWO_ID, iShip_ID, strShipDate, iPallett_ID, iShiftID, strWorkDate)
                    Next j
                Catch ex As Exception
                    iErrFlag = 1
                    MsgBox("frmMotoSubContShipping.BtnPrint_Click.UpdateDeviceTable: " & ex.Message.ToString)
                End Try
                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '***************************************************************************
                'This gets the no of Masterpacks for an Overpack
                '***************************************************************************
                'Not same for all processes
                Dim iNumOfMasterPacksForOverPack As Integer

                Try
                    If Me.OverPackProcess = 0 Then      'Regular Process
                        If Me.chkCloseOverPack.Checked = False Then     'Do the following only if "Close Overpack" check box is unchecked

                            dt = objMotoSubcontract_Biz.GetNumOfMasterPacksForOverPack(iOverPack_ID)
                            For Each R1 In dt.Rows      'There will be only one row.
                                iNumOfMasterPacksForOverPack = R1("NumOfMasterPacks")
                                Exit For
                            Next

                            '***************************************************************************
                            'If iNumOfMasterPacksForOverPack in the previous block of 
                            'code is equal to iOverPackQty then assign the overpack a ship date
                            '***************************************************************************
                            'for ATCLE 1 overpack contains 1 masterpack. 
                            If iNumOfMasterPacksForOverPack = iOverPackQty Then
                                i = objMotoSubcontract_Biz.AssignShipDateToOverPack(iOverPack_ID, strShipDate)
                            End If
                            '***************************************************************************
                        Else        'If "Close Overpack" check box is checked then force close it anyway
                            i = objMotoSubcontract_Biz.AssignShipDateToOverPack(iOverPack_ID, strShipDate)
                        End If

                    Else
                        '***************************************************************************
                        ' assign the overpack a ship date (This happens in case of RUR, BER, RNR processes)
                        '***************************************************************************
                        i = objMotoSubcontract_Biz.AssignShipDateToOverPack(iOverPack_ID, strShipDate)
                        '***************************************************************************
                    End If
                Catch ex As Exception
                    iErrFlag = 1
                    MsgBox("frmMotoSubContShipping.BtnPrint_Click.GetNumOfMasterPacksForOverPack: " & ex.Message.ToString)
                Finally
                    '******************************
                    'Destroy the datatable
                    '******************************
                    If Not IsNothing(dt) Then
                        If Not IsDBNull(dt) Then
                            dt.Dispose()
                        End If
                        dt = Nothing
                    End If
                    '******************************
                End Try

                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '***************************************************************************
                'Check if there are any more devices that need to be 
                'shipped for the WO. 
                '********************************************************
                Dim iNumOfDevicestoBeShipped As Integer
                Try
                    'iNumOfDevicestoBeShipped = GetNumOfDevicetobeShippedWithRMA(iPallett_ID)
                    'iNumOfDevicestoBeShipped = GetNumOfDevicetobeShippedWithRMA(iWO_ID)
                    iNumOfDevicestoBeShipped = Me.objMotoSubcontract_Biz.GetNumOfDevicetobeShippedWithRMA(iWO_ID)
                Catch ex As Exception
                    iErrFlag = 1
                    MsgBox("frmMoto_RL_Shiping.BtnPrint_Click.GetNumOfDevicetobeShippedWithRMA: " & ex.Message.ToString)
                End Try

                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '********************************************************
                'If no devices to be shipped then update the tworkorder table
                '********************************************************
                If iNumOfDevicestoBeShipped = 0 Then   'No more devices to be shipped  'SetWOReadyToBeShipped
                    '***************************************************************************
                    Try
                        i = objMotoSubcontract_Biz.SetWOReadyToBeShipped(iWO_ID, strShipDate)
                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.SetWOReadyToBeShipped: " & ex.Message.ToString)
                    End Try
                    '***************************************************************************
                    If iErrFlag = 1 Then
                        iErrFlag = 0
                        Exit Try
                    End If
                    '***************************************************************************
                    Try
                        i = objMotoSubcontract_Biz.AssignShipDateToPallett(iPallett_ID, strShipDate)
                        ''Print the pallett Report
                        i = objMotoSubcontract_Biz.CreatePalletReport(iPallett_ID)

                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.AssignShipDateToPallett: " & ex.Message.ToString)
                    End Try
                    '***************************************************************************
                    If iErrFlag = 1 Then
                        iErrFlag = 0
                        Exit Try
                    End If
                    '***************************************************************************
                    'Update repair status based on Pallett date
                    Try
                        i = objMotoSubcontract_Biz.UpdateRepairStatusBasedOnPallettShipDate(1, iPallett_ID, )   '1 - SHP
                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.UpdateRepairStatusBasedOnPallettShipDate: " & ex.Message.ToString)
                    End Try
                    '***************************************************************************
                ElseIf iNumOfDevicestoBeShipped > 0 Then    'Some devices to be shipped
                    '***************************************************************************
                    'Update repair status based on Pallett date
                    Try
                        i = objMotoSubcontract_Biz.UpdateRepairStatusBasedOnPallettShipDate(0, , iShip_ID)    '0 - APS
                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.UpdateRepairStatusBasedOnPallettShipDate: " & ex.Message.ToString)
                    End Try

                    '***************************************************************************
                Else    'Negative value
                    iErrFlag = 1
                    MsgBox("Number of devices to be shipped can't be a negative value. Contact IT immediately.")
                End If

                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '***************************************************************************
                'This is where we force close the pallett if number of devices to be shipped 
                'is greater than 0
                '***************************************************************************
                If Me.chkClosePallett.Checked = True And iNumOfDevicestoBeShipped > 0 Then
                    '***************************************************************************
                    'Assign Ship date to Pallett
                    Try
                        i = objMotoSubcontract_Biz.AssignShipDateToPallett(iPallett_ID, strShipDate)
                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.AssignShipDateToPallett: " & ex.Message.ToString)
                    End Try
                    '***************************************************************************
                    If iErrFlag = 1 Then
                        iErrFlag = 0
                        Exit Try
                    End If
                    '***************************************************************************
                    'Update repair status based on Pallett date
                    Try
                        i = objMotoSubcontract_Biz.UpdateRepairStatusBasedOnPallettShipDate(1, iPallett_ID, )   '1 - SHP
                    Catch ex As Exception
                        iErrFlag = 1
                        MsgBox("frmMotoSubContShipping.BtnPrint_Click.UpdateRepairStatusBasedOnPallettShipDate: " & ex.Message.ToString)
                    End Try
                    '***************************************************************************
                End If

                '***************************************************************************
                If iErrFlag = 1 Then
                    iErrFlag = 0
                    Exit Try
                End If
                '********************************************************
                'Write to Fedex db
                '********************************************************
                objFedex = New PSS.Gui.MotorolaSubcontract.Fedex()
                i = objFedex.WriteFedEx(iShip_ID)

                '********************************************************
                'Update SUMBILL table (This is useful for a report and nothing else)
                '********************************************************
                For j = 0 To Me.lstDevices.Items.Count - 1
                    If j = Me.lstDevices.Items.Count - 1 Then
                        strDeviceIDs = strDeviceIDs + CStr(GetDevice_ID(Me.lstDevices.Items(j)))
                    Else
                        strDeviceIDs = strDeviceIDs + CStr(GetDevice_ID(Me.lstDevices.Items(j))) + ", "
                    End If
                Next j

                'Update billing summary
                i = objMotoSubcontract_Biz.UpdateBillingSummary(strDeviceIDs)

                '********************************************************
                'Print
                '********************************************************
                Me.DoPrinting(iShip_ID, iOverPack_ID, iPallett_ID, _
                            iNumOfMasterPacksForOverPack, iNumOfDevicestoBeShipped)

                '********************************************************
                'Destroy the object
                '********************************************************
                'If Not IsNothing(objMotoSubcontract_Biz) Then
                '    objMotoSubcontract_Biz = Nothing
                'End If
                '********************************************************
                'Refresh the table
                '********************************************************
                FillRMAGrid()
                '********************************************************
                'Me.lblNoOfDevToShip.Text = dtDeviceSNsForWO.Rows.Count
                '********************************************************

            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.btnPrint_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
            Finally

                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                'If Not IsNothing(objMotoSubcontract_Biz) Then
                '    objMotoSubcontract_Biz = Nothing
                'End If
                If Not IsNothing(ObjUtilib) Then
                    ObjUtilib = Nothing
                End If
                If Not IsNothing(objFedex) Then
                    objFedex = Nothing
                End If

                If iErr = 0 Then
                    Me.lstDevices.Items.Clear()
                    Me.lblCount.Text = "0"
                    Me.chkCloseOverPack.Checked = False
                End If

                'Me.txtDevice.Focus()
                Me.grdRMAInfo.Focus()

                Me.btnPrint.Enabled = True
                Cursor.Current = Cursors.Default
                iFlg = 0
            End Try

        End Sub
        '****************************************************************
        'Print
        '****************************************************************
        Public Function Print(ByVal strPrinterName As String, _
                                ByVal booLandscape As Boolean, _
                                ByVal strRptName As String, _
                                ByVal strFormula As String, _
                                ByVal iNumOfCopies As Integer, _
                                Optional ByVal iLOCID As Integer = 0, _
                                Optional ByVal iOP As Integer = 0, _
                                Optional ByVal iRptType As Integer = 0, _
                                Optional ByVal strHEX As String = "") As Integer
            'Optional ByVal iLocation_ID As Integer = 0, _
            'iLoc_ID

            Dim ps As New PrinterSettings()
            'Dim rptApp As New CRAXDRT.Application()
            'Dim rpt As CRAXDRT.Report
            Dim rptObj As ReportDocument

            Try

                If iLOCID = 2590 And iPhoneType = 1 And iRptType = 1 Then
                    strRptName = "AWS_Ship_Label_GSM.rpt"
                End If

                '*****************************************************************
                ps.PrinterName = strPrinterName         '"Default on WCCELLULAR"
                ps.DefaultPageSettings.Landscape = booLandscape

                rptObj = New ReportDocument()

                With rptObj
                    .Load(PSS.Core.[Global].ReportPath & strRptName)
                    .RecordSelectionFormula = strFormula

                    '*********
                    'ATCLE-AWS customer or ATCLE-ZM customer, 
                    'location id is 2540, 2579 respectively
                    If iLOCID = 2540 Or iLoc_ID = 2579 Then
                        Select Case iRptType
                            Case 1      'coffin box label
                                ''Add any parameters to the crystal report here
                                .SetParameterValue("RUR", iOP)
                            Case 2      'Master Pack Label
                                ''Add any parameters to the crystal report here
                            Case 3      'Over Pack label
                                ''Add any parameters to the crystal report here
                            Case 4      'Master Pack Manifest
                                ''Add any parameters to the crystal report here
                            Case 5      'Overpack Manifest
                                ''Add any parameters to the crystal report here
                            Case 6      'Pallett manifest
                                ''Add any parameters to the crystal report here
                        End Select
                    ElseIf iLOCID = 2590 Or iLOCID = 0 Then            'AWS, Inc. 
                        Select Case iRptType
                            Case 1      'coffin box label
                                ''Add any parameters to the crystal report here
                                .SetParameterValue("HEX", strHEX)
                            Case 2      'Master Pack Label
                                ''Add any parameters to the crystal report here
                            Case 3      'Over Pack label
                                ''Add any parameters to the crystal report here
                            Case 4      'Master Pack Manifest
                                ''Add any parameters to the crystal report here
                            Case 5      'Overpack Manifest
                                ''Add any parameters to the crystal report here
                            Case 6      'Pallett manifest
                                ''Add any parameters to the crystal report here
                        End Select
                    End If

                    '*********
                    .PrintToPrinter(iNumOfCopies, True, 0, 0)
                End With

                'rpt = rptApp.OpenReport(PSS.Core.Global.ReportPath & strRptName)
                'rpt.RecordSelectionFormula = strFormula
                ''*********
                ''ATCLE-AWS customer or ATCLE-ZM customer, 
                ''location id is 2540, 2579 respectively
                'If iLOCID = 2540 Or iLoc_ID = 2579 Then
                '    Select Case iRptType
                '        Case 1      'coffin box label
                '            ''Add any parameters to the crystal report here
                '            rpt.ParameterFields.GetItemByName("RUR").AddCurrentValue(iOP)
                '        Case 2      'Master Pack Label
                '            ''Add any parameters to the crystal report here
                '        Case 3      'Over Pack label
                '            ''Add any parameters to the crystal report here
                '        Case 4      'Master Pack Manifest
                '            ''Add any parameters to the crystal report here
                '        Case 5      'Overpack Manifest
                '            ''Add any parameters to the crystal report here
                '        Case 6      'Pallett manifest
                '            ''Add any parameters to the crystal report here
                '    End Select
                'ElseIf iLOCID = 2590 Or iLOCID = 0 Then            'AWS, Inc. 

                '    Select Case iRptType
                '        Case 1      'coffin box label
                '            ''Add any parameters to the crystal report here
                '            rpt.ParameterFields.GetItemByName("HEX").AddCurrentValue(strHEX)
                '        Case 2      'Master Pack Label
                '            ''Add any parameters to the crystal report here
                '        Case 3      'Over Pack label
                '            ''Add any parameters to the crystal report here
                '        Case 4      'Master Pack Manifest
                '            ''Add any parameters to the crystal report here
                '        Case 5      'Overpack Manifest
                '            ''Add any parameters to the crystal report here
                '        Case 6      'Pallett manifest
                '            ''Add any parameters to the crystal report here
                '    End Select
                'End If

                ''*********
                'rpt.PrintOut(False, iNumOfCopies)

                '*****************************************************************
                Return 1

            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.Print: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
                Return 0
            Finally
                If Not IsNothing(ps) Then
                    ps = Nothing
                End If
                'If Not IsNothing(rpt) Then
                '    rpt = Nothing
                'End If
                'If Not IsNothing(rptApp) Then
                '    rptApp = Nothing
                'End If
            End Try

        End Function

        '****************************************************************
        'This does all the printing
        '****************************************************************
        Private Sub DoPrinting(ByVal iShip_ID As Integer, _
                                ByVal iOverPack_ID As Integer, _
                                ByVal iPallett_ID As Integer, _
                                ByVal iNumOfMasterPacksForOverPack As Integer, _
                                ByVal iNumOfDevicestoBeShipped As Integer)

            Dim R1 As DataRow
            Dim j, i As Integer
            Dim iRet ', iOP As Integer
            Dim strFormula As String

            Try
                '********************************************************
                'Print         
                '********************************************************
                'Not same labels for for all processes

                '////Shipping Manifest
                If iPrintMasterManifest = 1 Then
                    strFormula = "{tdevice.Ship_ID} = " & iShip_ID
                    'iRet = Me.Print("Default on WCCELLULAR", True, "Ship_Manifest.rpt", strFormula, 2)
                    iRet = Me.Print("", True, strMasterManifestName, strFormula, 2, , , 4)
                    strFormula = ""
                End If

                If Me.chkPrintLables.Checked = False Then       'If labels are not turned off
                    '////Print Ship_Coffinbox_Label
                    If iPrintCoffinLabel = 1 Then
                        For j = 0 To Me.lstDevices.Items.Count - 1
                            For Each R1 In dtDeviceSNsForWO.Rows
                                If Trim(R1("Device_SN")) = Trim(Me.lstDevices.Items(j)) Then

                                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                                    'iOP = 0
                                    'iOP = GetProcessType(R1("Device_ID"))
                                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                                    strFormula = "{tdevice.Device_ID} = " & R1("Device_ID")
                                    'iRet = Me.Print("PARALLEL1 on FP10196F", False, "Ship_CoffinBox_Label.rpt", strFormula, 1)
                                    iRet = Me.Print(strCoffinLabelPrinter, False, strCoffinLabelName, strFormula, 1, iLoc_ID, Me.OverPackProcess, 1, Trim(R1("HEX")))
                                    strFormula = ""
                                    Exit For
                                End If
                            Next R1
                        Next j
                    End If

                    '////Ship Master Label
                    If iPrintMasterLabel = 1 Then
                        strFormula = "{tdevice.Ship_ID} = " & iShip_ID
                        'iRet = Me.Print("PARALLEL4 on FP10196F", False, "Ship_Master_Label.rpt", strFormula, 1)
                        iRet = Me.Print(strMasterLblPrinter, False, strMasterLblName, strFormula, 1, , , 2)
                        strFormula = ""
                    End If
                End If

                If Me.chkCloseOverPack.Checked = False Then     'If the check box is checked
                    'If iNumOfMasterPacksForOverPack = 4 Then
                    If iNumOfMasterPacksForOverPack = iOverPackQty Then     '4 - Verizon; 1 - TMobile
                        '*****************************************
                        'Print Shipping Manifest and labels here
                        '*****************************************
                        If iPrintOverPackManifest = 1 Then
                            'Ship Manifest Overpack
                            strFormula = "{toverpack.overpack_ID} = " & iOverPack_ID
                            'iRet = Me.Print("Default on WCCELLULAR", True, "Ship_Manifest_OverPack.rpt", strFormula, 2)
                            iRet = Me.Print("", True, strOverPackManifestName, strFormula, 2, , , 5)
                            strFormula = ""
                        End If
                        '*******************
                        If Me.chkPrintLables.Checked = False Then       'If labels are not turned off
                            If iPrintOverPackLbl = 1 Then
                                'Ship Over Pack Label
                                strFormula = "{tship.OverPack_ID} = " & iOverPack_ID
                                'iRet = Me.Print("PARALLEL4 on FP10196F", False, "Ship_OverPack_Label.rpt", strFormula, 1)
                                iRet = Me.Print(strOverPackLblPrinter, False, strOverPackLblName, strFormula, 1, , 3)
                                strFormula = ""
                            End If
                        End If
                        '*******************
                    End If

                Else        'If the checkbox is unchecked. Means print it even if there are less than 4 masterpacks because overpack is force closed
                    '*****************************************
                    'Print Shipping Manifest and labels here
                    '*****************************************
                    If iPrintOverPackManifest = 1 Then
                        'Ship Manifest Overpack
                        strFormula = "{toverpack.overpack_ID} = " & iOverPack_ID
                        'iRet = Me.Print("Default on WCCELLULAR", True, "Ship_Manifest_OverPack.rpt", strFormula, 2)
                        iRet = Me.Print("", True, strOverPackManifestName, strFormula, 2, , , 5)
                        strFormula = ""
                    End If
                    '*******************
                    If Me.chkPrintLables.Checked = False Then       'If labels are not turned off
                        If iPrintOverPackLbl = 1 Then
                            'Ship Over Pack Label
                            strFormula = "{tship.OverPack_ID} = " & iOverPack_ID
                            'iRet = Me.Print("PARALLEL4 on FP10196F", False, "Ship_OverPack_Label.rpt", strFormula, 1)
                            iRet = Me.Print(strOverPackLblPrinter, False, strOverPackLblName, strFormula, 1, , , 3)
                            strFormula = ""
                        End If
                    End If
                    '*******************
                End If

                '********************************************************
                'Print Pallett Manifest if no more devices to be shipped
                '********************************************************
                If iPrintPallettManifest = 1 Then
                    If iNumOfDevicestoBeShipped = 0 Or Me.chkClosePallett.Checked = True Then

                        'Ship Manifest Overpack
                        strFormula = "{tpallett.Pallett_ID} = " & iPallett_ID
                        'iRet = Me.Print("Default on WCCELLULAR", True, "Ship_Manifest_Pallett.rpt", strFormula, 3)
                        iRet = Me.Print("", True, strPallettManifestName, strFormula, 3, , , 6)

                        strFormula = ""
                    End If
                End If
                '********************************************************
                If iPrintQCReport = 1 Then
                    CreateQCRep(iPallett_ID)
                End If
                '********************************************************

            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.DoPrinting: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
            End Try
        End Sub

        '****************************************************************
        'Gets the process type for ATCLE label printing
        '****************************************************************
        'Private Function GetProcessType(ByVal iDevID As Integer) As Integer

        '    Dim dt As DataTable
        '    Dim R1 As DataRow
        '    Dim i As Integer

        '    Try
        '        'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
        '        dt = objMotoSubcontract_Biz.IsDeviceRTM(iDevID)

        '        For Each R1 In dt.Rows
        '            i = R1("iCount")
        '            Exit For
        '        Next R1

        '        Select Case iLoc_ID
        '            Case 2540   ''ATCLE-AWS customer, location id is 2540
        '                If i > 0 Then
        '                    i = 5   'Magic number!  ;-)   '5 - RTM
        '                Else
        '                    i = Me.OverPackProcess      '0 - Good, 1 - RUR
        '                End If
        '            Case 2579   ''ATCLE-ZM customer, location id is 2579
        '                If i > 0 Then
        '                    i = 5   'Magic number!  ;-)   '5 - RTM
        '                Else
        '                    i = Me.OverPackProcess      '0 - Good, 1 - RUR
        '                End If
        '            Case Else   'For Motorola-NSC which is the only other customer this screen was designed for
        '                i = Me.OverPackProcess          '0 - Good, 1 - RUR
        '        End Select

        '        Return i
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        R1 = Nothing
        '        '******************************
        '        'Destroy the datatable
        '        '******************************
        '        If Not IsNothing(dt) Then
        '            If Not IsDBNull(dt) Then
        '                dt.Dispose()
        '            End If
        '            dt = Nothing
        '        End If
        '        '******************************
        '        objMotoSubcontract_Biz = Nothing
        '    End Try

        'End Function
        '****************************************************************
        Private Function ATCLEShortOrLongSKU(ByVal strRMANumber As String) As String
            Dim j As Integer = 0
            'This is piece of code is done only for ATCLE-AWS Customer
            'To ship the SHORT and LONG SKUs seperately.
            j = InStr(strRMANumber, "{")
            If j = 0 Then
                strShortLongFlg = ""
            Else
                strShortLongFlg = strRMANumber.Substring(j, 1)
            End If
            Return strShortLongFlg
        End Function

        '****************************************************************
        'Handles the grdRMAGrid row/column change event
        '****************************************************************
        Private Sub grdRMAInfo_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdRMAInfo.RowColChange
            'Dim strRMANumber As String = ""
            'Dim j As Integer = 0
            Try

                If Me.grdRMAInfo.Columns.Count = 0 Then
                    Exit Sub
                End If

                If iCust_ID <> 2127 Then
                    If iWO_ID <> CInt(Me.grdRMAInfo.Columns("WO_ID").Value) Then
                        Me.lstDevices.Items.Clear()
                    End If
                Else
                    Me.lstDevices.Items.Clear()
                End If

                iWO_ID = CInt(Me.grdRMAInfo.Columns("WO_ID").Value)
                'iSKU_ID = CInt(Me.grdRMAInfo.Columns("SKU_ID").Value)
                iModel_ID = CInt(Me.grdRMAInfo.Columns("model_id").Value)
                iWO_Quantity = CInt(Me.grdRMAInfo.Columns("RMA_Quantity").Value)
                iNumDevicestoBeShipped = CInt(Me.grdRMAInfo.Columns("DevicesToBeShipped").Value)
                iNumDevicesRcvd = CInt(Me.grdRMAInfo.Columns("DevicesReceived").Value)

                '********************************************************
                'This is piece of code is done only for ATCLE-AWS Customer
                'To ship the SHORT and LONG SKUs seperately.
                'strRMANumber = Me.grdRMAInfo.Columns("RMANumber").Value
                'j = InStr(strRMANumber, "{")
                'If j > 0 Then
                '    strShortLongFlg = 0
                'Else
                '    strShortLongFlg = strRMANumber.Substring((j + 1), 1)
                'End If

                'ATCLEShortOrLongSKU(Me.grdRMAInfo.Columns("RMANumber").Value

                '**************************************************************************************
                'Goto database and bring all device serial numbers available for the workorder selected
                '**************************************************************************************
                '''If iWO_ID <> 0 Then
                '''    Me.RefreshTable(iWO_ID)
                '''End If
                Me.RefreshTable()
                '**************************************************************************************
                'Me.lblNoOfDevToShip.Text = dtDeviceSNsForWO.Rows.Count
                '**********************************
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.grdRMAInfo_RowColChange: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")

            End Try
        End Sub
        '****************************************************************
        'Refresh Datatable
        '****************************************************************
        Private Sub RefreshTable()
            Try
                'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                'dtDeviceSNsForWO.Rows.Clear()
                If Not IsNothing(dtDeviceSNsForWO) Then
                    dtDeviceSNsForWO.Dispose()
                    dtDeviceSNsForWO = Nothing
                End If

                'Commented by Asif on 01/19/2006
                ''''Select Case iCust_ID
                ''''    Case 2106       'PSSI Cellular Sales
                ''''        dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForModelBasedShipping(iCust_ID, iWO_ID)
                ''''    Case 2127       'GSM
                ''''        dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForSKUBasedShipping(iSKU_ID)
                ''''    Case 2069       'AWS, Inc.
                ''''        dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForModelBasedShipping(iCust_ID, iWO_ID)
                ''''    Case 1403       'Motorola-NSC
                ''''        dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForSKUBasedShipping(iSKU_ID)
                ''''    Case 2019       'ATCLE-AWS
                ''''        dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForModelBasedShipping(iCust_ID, iWO_ID)
                ''''    Case 2058       'ATCLE-ZM
                ''''        dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForModelBasedShipping(iCust_ID, iWO_ID)
                ''''    Case Else
                ''''        MsgBox("Customer not selected.", MsgBoxStyle.Information)
                ''''End Select

                Select Case iLocMap_ShipType
                    Case 1      'Model based Shipping
                        If iCust_ID = 2019 Then
                            strShortLongFlg = Me.ATCLEShortOrLongSKU(Me.grdRMAInfo.Columns("RMANumber").Value)
                            dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForModelBasedShipping(iLoc_ID, iModel_ID, Me.cboGroup.SelectedValue, strShortLongFlg)
                        Else
                            dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForModelBasedShipping(iLoc_ID, iModel_ID, Me.cboGroup.SelectedValue)
                        End If

                    Case 2      'SKU based shipping
                        'dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForSKUBasedShipping(iSKU_ID, Me.cboGroup.SelectedValue)
                        dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForModelBasedShipping(iLoc_ID, iModel_ID, Me.cboGroup.SelectedValue)
                    Case Else   'WO/RMA based shipping
                        dtDeviceSNsForWO = objMotoSubcontract_Biz.GetSNsForWOBasedShipping(iWO_ID, Me.cboGroup.SelectedValue)
                End Select

                Me.txtDevice.Focus()
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.RefreshTable: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")

            End Try

        End Sub

        '****************************************************************
        'This fills the RMA Grid
        '****************************************************************
        Private Sub FillRMAGrid()

            If iLoc_ID = 0 Then
                MsgBox("Please select a Location.", MsgBoxStyle.Information)
                Me.grdRMAInfo.ClearFields()
                Me.lstDevices.Items.Clear()
                Exit Sub
            End If
            If Me.cboGroup.SelectedValue = 0 Then
                MsgBox("Please select a Group.", MsgBoxStyle.Information)
                Me.grdRMAInfo.ClearFields()
                Me.lstDevices.Items.Clear()
                Exit Sub
            End If

            'Destroy the table before rebuilding it.
            If Not IsNothing(dtRMAGridData) Then
                If Not IsDBNull(dtRMAGridData) Then
                    dtRMAGridData.Dispose()
                End If
                dtRMAGridData = Nothing
            End If

            Try
                'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                'dtRMAGridData = objMotoSubcontract_Biz.GetRMAGridData(Me.cboCustomer.SelectedValue)
                dtRMAGridData = objMotoSubcontract_Biz.GetRMAGridData(iCust_ID, iLoc_ID, Me.cboGroup.SelectedValue)

                Me.grdRMAInfo.ClearFields()
                Me.grdRMAInfo.DataSource = dtRMAGridData.DefaultView
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.FillRMAGrid: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
                'Finally

                '    objMotoSubcontract_Biz = Nothing
            End Try
        End Sub

        '****************************************************************
        'This fills the Location combo box
        '***************************************************************************
        Private Sub FillLocationComboBox()

            Dim R1 As DataRow

            Try

                If Not IsNothing(dtLoc) Then
                    dtLoc.Dispose()
                    dtLoc = Nothing
                End If

                'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dtLoc = objMotoSubcontract_Biz.GetLocationsForCustomer(iCust_ID)

                '**************************************************
                'Fill the Customer combo box
                '**************************************************
                Me.cboLocation.DataSource = dtLoc.DefaultView
                Me.cboLocation.ValueMember = dtLoc.Columns("Loc_id").ToString
                Me.cboLocation.DisplayMember = dtLoc.Columns("Loc_Name").ToString
                Me.cboLocation.SelectedValue = 0

                '**************************************************
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.FillLocationComboBox: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
                'Finally
                '    objMotoSubcontract_Biz = Nothing
            End Try
        End Sub
        '***************************************************************************
        'This event fires when a device is scanned in
        '***************************************************************************
        Private Sub txtDevice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevice.KeyDown
            Dim iDevId As Integer = 0
            'Dim iWOIDDeviceCameInWith As Integer = 0        'Added on 02/17/2005
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim strSN As String = ""
            Dim i As Integer = 0
            Dim iDeviceBelongstoWO As Integer = 0
            Dim strOverPackProcess As String
            Dim objfrmShipping As New PSS.Gui.Shipping.frmShipping()
            Dim strDisposition As String = ""

            Dim isRUR As Integer = 0
            Dim isBER As Integer = 0
            Dim isRTM As Integer = 0

            Try
                If e.KeyValue = 13 Then
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&

                    If iLoc_ID = 0 Then
                        MsgBox("Please select a Location.", MsgBoxStyle.Information)
                        Me.grdRMAInfo.ClearFields()
                        Me.lstDevices.Items.Clear()
                        Exit Sub
                    End If
                    If iFlg = 0 Then
                        MsgBox("Please slect the right RMA to ship.", MsgBoxStyle.Information)
                        Me.txtDevice.Text = ""
                        strSN = ""
                        Exit Sub
                    End If

                    If iCust_ID <> 2127 And iCust_ID <> 2106 Then
                        If iNumDevicesRcvd <> iWO_Quantity Then
                            MsgBox("RMA Quantity and Number of devices received do not match. Hence any shipping is not allowed with this RMA.", MsgBoxStyle.Information)
                            Me.txtDevice.Text = ""
                            strSN = ""
                            Exit Sub
                        End If
                    End If


                    'Check if the Me.lstDevices.Items.Count is less than NumOfDevicestoBeShipped
                    If Me.lstDevices.Items.Count < iNumDevicestoBeShipped Then
                        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

                        'Check if the Max limit for the list box is reached
                        If Me.lstDevices.Items.Count = iMasterPackQty Then
                            MsgBox("You have reached the maximum number of devies that can be added to a Master Pack.", MsgBoxStyle.Information, "Customer Specific Shipping")
                            Me.txtDevice.Text = ""
                            strSN = ""
                            Me.txtDevice.Focus()
                            Exit Sub
                        End If

                        '*******************************************
                        'Check if the IMEI or SN scanned
                        '*******************************************    
                        If Len(Trim(Me.txtDevice.Text)) > 12 Then 'And iCust_ID <> 1653 And iCust_ID <> 2019 And iCust_ID <> 2058 Then
                            'Get the Device_SN from database for the scanned IMEI
                            'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                            dt = objMotoSubcontract_Biz.GetDeviceSNByIMEINo(Trim(Me.txtDevice.Text))

                            For Each R1 In dt.Rows      'There will be only one row.
                                strSN = Trim(R1("Device_SN"))
                                Exit For
                            Next

                            iPhoneType = 1      'GSM Phone  'Assuming that only like phones shipped together

                        Else
                            strSN = UCase(Trim(Me.txtDevice.Text))
                            iPhoneType = 0      'Non-GSM Phone  'Assuming that only like phones shipped together
                        End If

                        If strSN = "" Then
                            MsgBox("If you scanned in an IMEI number then Cellopt_OutIMEI field must have a vlaue for this phone. Can not continue.", MsgBoxStyle.Critical, "Customer Specific Shipping")
                            Me.txtDevice.Text = ""
                            Me.txtDevice.Focus()
                            Exit Sub
                        End If
                        '*******************************************
                        'Check if Device is already assigned to a pallet
                        i = objMisc.DeviceHasPallet(strSN)
                        If i > 0 Then
                            MsgBox("Device is already assigned to a Pallet. Can not ship it.", MsgBoxStyle.Critical, "Customer Specific Shipping")
                            Me.txtDevice.Text = ""
                            Me.txtDevice.Focus()
                            Exit Sub
                        End If
                        '*******************************************
                        'check for duplicates in list, if exists exit sub
                        For i = 0 To Me.lstDevices.Items.Count - 1
                            If Me.lstDevices.Items(i) = strSN Then  'UCase(txtDevice.Text) Then
                                MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                Me.txtDevice.Text = ""
                                strSN = ""
                                Me.txtDevice.Focus()
                                Exit Sub
                            End If
                        Next

                        'check if all the devices have been scanned in (Shipped)
                        If dtDeviceSNsForWO.Rows.Count = 0 Then
                            MsgBox("There are no more devices to scan for this RMA Number.", MsgBoxStyle.Information, "Customer Specific Shipping")
                            Me.txtDevice.Text = ""
                            strSN = ""
                            Me.txtDevice.Focus()
                            Exit Sub
                        End If

                        i = 0

                        'Check if this Device is RUR or BER or RTM
                        For Each R1 In dtDeviceSNsForWO.Rows
                            If Trim(R1("Device_SN")) = Trim(strSN) Then
                                iDevId = R1("Device_ID")
                                '''iWOIDDeviceCameInWith = R1("wo_id")     'Added on 02/17/2005

                                Select Case CInt(R1("billcode_rule"))
                                    Case 1  'RUR
                                        isRUR = 1
                                    Case 2  'BER
                                        isBER = 1
                                    Case 9  'RTM
                                        isRTM = 1
                                End Select

                                If R1("Model_ID") = 743 Then
                                    R1.BeginEdit()
                                    R1("HEX") = InputBox("Scan ESN HEX number.", "Customer Specific Shipping")
                                    R1.EndEdit()
                                End If
                                iDeviceBelongstoWO = 1
                                Exit For                                'Added on 02/17/2005
                            End If
                        Next R1

                        If iDevId = 0 Then
                            MsgBox("Can not ship this phone. Reasons could be 'wrong group' or 'wrong model' or 'not yet billed' or 'IMEI IN different from IMEI OUT' or just does not exist in the database.", MsgBoxStyle.Information, "Customer Specific Shipping")
                            Me.txtDevice.Text = ""
                            strSN = ""
                            Me.txtDevice.Focus()
                            Exit Sub
                        End If

                        '********************************
                        'Added on 02/17/2005

                        'The following piece of code needs 
                        'to be commented once this WO_ID(73304) 
                        'is completely shipped and closed
                        '********************************
                        '''If iWO_ID = 73304 Then
                        '''    If iWOIDDeviceCameInWith <> 73304 Then
                        '''        MsgBox("This device does not belong to this RMA.", MsgBoxStyle.Information, "Customer Specific Shipping")
                        '''        Me.txtDevice.Text = ""
                        '''        strSN = ""
                        '''        Me.txtDevice.Focus()
                        '''        Exit Sub
                        '''    End If
                        '''Else
                        '''    If iWOIDDeviceCameInWith = 73304 Then
                        '''        MsgBox("This device does not belong to this RMA.", MsgBoxStyle.Information, "Customer Specific Shipping")
                        '''        Me.txtDevice.Text = ""
                        '''        strSN = ""
                        '''        Me.txtDevice.Focus()
                        '''        Exit Sub
                        '''    End If
                        '''End If
                        '******************************************************
                        'This code creates/verifies disposition of the dveice
                        '******************************************************
                        If iCust_ID = 2106 Then
                            If isRUR = 0 And isBER = 0 And isRTM = 0 Then
                                strDisposition = objMisc.renderDisposition(iDevId, Me.OverPackProcess)
                            End If
                        End If
                        '******************************************************
                        'Check if the right phone is being scanned in for the process
                        Select Case Me.OverPackProcess
                            Case 0  'Regular Phones
                                If isRUR <> 0 Or isBER <> 0 Or isRTM <> 0 Then
                                    MsgBox("This is not a Regular phone. Can't ship it in this process.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                    Me.txtDevice.Text = ""
                                    strSN = ""
                                    Me.txtDevice.Focus()
                                    Exit Sub
                                End If
                                If iCust_ID = 2106 Then
                                    If objMisc._Disposition <> "" Then
                                        MsgBox("This phone has already been dispositioned as " & objMisc._Disposition, MsgBoxStyle.Information, "Customer Specific Shipping")
                                    Else
                                        If strDisposition = "" Then
                                            MsgBox("This device failed to be dispositioned. Can't ship it at this time.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                            Me.txtDevice.Text = ""
                                            strSN = ""
                                            Me.txtDevice.Focus()
                                            Exit Sub
                                        End If
                                    End If
                                End If

                            Case 1  'RUR
                                If isRUR <> 1 Then
                                    MsgBox("This is not an RUR phone. Can't ship it in this process.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                    Me.txtDevice.Text = ""
                                    strSN = ""
                                    Me.txtDevice.Focus()
                                    Exit Sub
                                End If
                                If iCust_ID = 2106 Then
                                    If objMisc._Disposition = "" Then
                                        MsgBox("This is a RUR phone. This should have been dispositioned by now. Can't ship this at this time. Disposition it and try to ship again.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                        Me.txtDevice.Text = ""
                                        strSN = ""
                                        Me.txtDevice.Focus()
                                        Exit Sub
                                    End If
                                End If

                            Case 2  'BER
                                If isBER <> 1 Then
                                    MsgBox("This is not a BER phone. Can't ship it in this process.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                    Me.txtDevice.Text = ""
                                    strSN = ""
                                    Me.txtDevice.Focus()
                                    Exit Sub
                                End If
                                'Case 3  'RNR
                                '    If strOverPackProcess <> "RNR" Then
                                '        MsgBox("You are trying to scan in a " & strOverPackProcess & " phone which is not allowed in the current process.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                '        Me.txtDevice.Text = ""
                                '        Exit Sub
                                '    End If
                            Case 4
                                If isRTM <> 1 Then
                                    MsgBox("This is not an RTM phone. Can't ship it in this process.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                    Me.txtDevice.Text = ""
                                    strSN = ""
                                    Me.txtDevice.Focus()
                                    Exit Sub
                                End If
                        End Select

                        'else give a message (Can't add anymore) and empty txtDevice text box
                        If iDeviceBelongstoWO = 0 Then
                            MsgBox("Device can't be scanned for any of the following reasons: It does not belong to this RMA Number or it is not yet billed or it is already shipped.", MsgBoxStyle.Information, "Customer Specific Shipping")
                            Me.txtDevice.Text = ""
                            strSN = ""
                            Me.txtDevice.Focus()
                            Exit Sub
                        End If
                        '**********************************************************************
                        'Check for motorola missing data for Regular phones (Overpack process = 0)
                        '**********************************************************************
                        ''''Dim strVar As String = ""
                        ''''If iCust_ID = 1403 Then     'For Motorola NSC
                        ''''    strVar = objfrmShipping.CheckForMissingDataForMotorola(iDevId, Me.OverPackProcess)

                        ''''    If strVar <> "" Then
                        ''''        MsgBox(strVar + "Can't ship this device at this time. Take this error message to the receiver/tech who worked on it.", MsgBoxStyle.Information, "Motorola Data Missing")
                        ''''        Me.txtDevice.Text = ""
                        ''''        strSN = ""
                        ''''        Me.txtDevice.Focus()
                        ''''        Cursor.Current = System.Windows.Forms.Cursors.Default
                        ''''        Exit Sub
                        ''''    End If
                        ''''End If

                        '**********************************************************************
                        'Check if the device has been through QC
                        '**********************************************************************
                        If Me.chkNoQC.Checked = False Then
                            If iPrintQCReport = 1 Then
                                If objMisc.IsDeviceThroughQC(iDevId) = 0 Then
                                    MsgBox("This device has not been through QC. Can't ship it.", MsgBoxStyle.Information, "Customer Specific Shipping")
                                    Me.txtDevice.Text = ""
                                    strSN = ""
                                    Me.txtDevice.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If

                        '**********************************************************************
                        'If everything is fine then add this Device_SN to the list box
                        Me.lstDevices.Items.Add(strSN)      'UCase(Trim(Me.txtDevice.Text)))
                        Me.lblCount.Text = lstDevices.Items.Count
                        Me.txtDevice.Text = ""
                        Me.txtDevice.Focus()
                    Else
                        MsgBox("Maximum number of devices that can be shipped with this RMA has been reached. Can't ship any more devices with this RMA.", MsgBoxStyle.Information, "Customer Specific Shipping")
                        Me.txtDevice.Text = ""
                        strSN = ""
                        Me.txtDevice.Focus()
                        Exit Sub
                        '%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
                    End If
                    '&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                End If
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.txtDevice_KeyDown: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
            Finally
                '*****************************
                'Destroy the datatable
                '*****************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                '*****************************
                'objMotoSubcontract_Biz = Nothing
                objfrmShipping = Nothing
                '*****************************
                objMisc._Disposition = ""
            End Try
        End Sub
        '***************************************************************************
        'Returns the Over Pack Process   (Bill code rules)
        '**************************************************************************
        Private Function WhatIsTheOverPackProcess(ByVal iBillCodeRule As Integer)
            Select Case iBillCodeRule
                Case 1
                    Return "RUR"
                Case 2
                    Return "BER"
                Case 9
                    Return "RTM"
                Case Else
                    Return "Regular"
            End Select
        End Function
        '***************************************************************************
        'Fill Group Combo Box
        '***************************************************************************
        Private Sub FillGroupComboBox()
            Dim dt As DataTable
            Dim R1 As DataRow

            Try

                'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetGroups

                Me.cboGroup.DataSource = dt.DefaultView
                Me.cboGroup.DisplayMember = dt.Columns("Group_Desc").ToString
                Me.cboGroup.ValueMember = dt.Columns("Group_id").ToString
                Me.cboGroup.SelectedValue = 0         'Hardcoded for the NSC customer
                '**************************************************
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.FillGroupComboBox: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
            Finally
                R1 = Nothing
                '*****************************
                'Destroy the datatable
                '*****************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

            End Try
        End Sub

        '***************************************************************************
        'Fill Customer Combo Box
        '***************************************************************************
        Private Sub FillCustomerComboBox()
            Dim dt As DataTable
            Dim R1 As DataRow

            Try

                'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetCustomers

                Me.cboCustomer.DataSource = dt.DefaultView
                Me.cboCustomer.DisplayMember = dt.Columns("cust_name1").ToString
                Me.cboCustomer.ValueMember = dt.Columns("cust_id").ToString
                Me.cboCustomer.SelectedValue = 0         'Hardcoded for the NSC customer
                '**************************************************
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.FillCustomerComboBox: " & ex.Message.ToString, MsgBoxStyle.Critical, "Customer Specific Shipping")
            Finally
                R1 = Nothing
                '*****************************
                'Destroy the datatable
                '*****************************
                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If
                'objMotoSubcontract_Biz = Nothing
            End Try
        End Sub

        '***************************************************************************
        'Disposes the class level data table
        '*****************************************
        Private Sub DisposeDataTable()
            Try
                If Not IsNothing(dtDeviceSNsForWO) Then
                    If Not IsDBNull(dtDeviceSNsForWO) Then
                        dtDeviceSNsForWO.Dispose()
                    End If
                    dtDeviceSNsForWO = Nothing
                End If

                If Not IsNothing(dtLoc) Then
                    If Not IsDBNull(dtLoc) Then
                        dtLoc.Dispose()
                    End If
                    dtLoc = Nothing
                End If

                If Not IsNothing(dtRMAGridData) Then
                    If Not IsDBNull(dtRMAGridData) Then
                        dtRMAGridData.Dispose()
                    End If
                    dtRMAGridData = Nothing
                End If

            Catch ex As Exception
                Throw New Exception("frmMotoSubCOntShipping.DisposeDatatable: " + ex.Message.ToString)
            End Try
        End Sub
        '*****************************************

        Protected Overrides Sub Finalize()
            objMotoSubcontract_Biz = Nothing
            objMisc = Nothing
            objWorkDate = Nothing
            DisposeDataTable()
            Me.Close()
            Me.Dispose()
            MyBase.Finalize()
        End Sub
        '*****************************************
        'Private Sub grdRMAInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdRMAInfo.Click
        '    Me.txtDevice.Focus()
        'End Sub

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            If Me.lstDevices.Items.Count > 0 Then
                Me.lstDevices.Items.Clear()
                Me.lblCount.Text = lstDevices.Items.Count
            End If
        End Sub

        '****************************************************************************

        '****************************************************************************

        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
            Dim myfrmObj As New frmReprint()
            myfrmObj.ShowDialog()
            myfrmObj = Nothing
        End Sub

        '****************************************************************************

        Private Shared Sub SetHandler(ByVal ctl As Control)
            AddHandler ctl.Enter, EnterHandler
            AddHandler ctl.Leave, LeaveHandler
            AddHandler ctl.Click, EnterHandler
        End Sub
        '******************************************************************************
        Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
            Change_Color(sender, HighLightColor)
        End Sub
        '******************************************************************************
        Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
            Change_Color(sender, WindowColor)
        End Sub
        '******************************************************************************
        Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
            Dim Type As String = sender.GetType.Name.ToString
            Select Case Type
                Case "ComboBox"
                    CType(sender, ComboBox).BackColor = color
                Case "TextBox"
                    CType(sender, TextBox).BackColor = color
                Case Else
                    'no other types should be hightlighted.

            End Select
        End Sub
        '******************************************************************************
        ''Private Function GetNumOfDevicetobeShippedWithRMA(ByVal iPallett_ID As Integer) As Integer

        ''    Dim iNumDevicesInPallett As Integer = 0
        ''    Dim iNumOfDevicestoBeShipped As Integer
        ''    Dim dt As DataTable
        ''    Dim R1 As DataRow

        ''    Try
        ''        dt = objMotoSubcontract_Biz.GetNumOfDevicesInPallett(iPallett_ID)
        ''        For Each R1 In dt.Rows      'There will be only one row.
        ''            iNumDevicesInPallett = R1("DevicesInPallett")
        ''            Exit For
        ''        Next

        ''        iNumOfDevicestoBeShipped = (iWO_Quantity - iNumDevicesInPallett)

        ''        Return iNumOfDevicestoBeShipped

        ''    Catch ex As Exception
        ''        Throw
        ''    Finally
        ''        '*****************************
        ''        'Destroy the datatable
        ''        '*****************************
        ''        If Not IsNothing(dt) Then
        ''            If Not IsDBNull(dt) Then
        ''                dt.Dispose()
        ''            End If
        ''            dt = Nothing
        ''        End If
        ''        '*****************************
        ''    End Try
        ''    '***************************************************************************
        ''End Function
        '******************************************************************************
        Private Function GetDevice_ID(ByVal strDevice_SN As String) As Integer
            Dim R1 As DataRow
            Dim iDevId As Integer = 0
            Try
                For Each R1 In dtDeviceSNsForWO.Rows
                    If Trim(R1("Device_SN")) = strDevice_SN Then
                        iDevId = R1("Device_ID")
                        Exit For
                    End If
                Next R1
            Catch ex As Exception
                Throw ex
            End Try

            Return iDevId
        End Function

        '******************************************************************************

        Private Sub btnRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRpt.Click

            'If iCust_ID = 0 Or iSKU_ID = 0 Then
            '    MsgBox("Please select Customer, Location and RMA.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ''Dim myfrmObj As New frmRpt(Me.cboCustomer.SelectedValue, iSKU_ID, )
            'Dim myfrmObj As New frmRpt(iCust_ID, iSKU_ID, )
            ''iCust_ID
            'myfrmObj.ShowDialog()
            'myfrmObj = Nothing

        End Sub
        '******************************************************************************
        Private Sub cboLocation_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLocation.SelectionChangeCommitted

            Dim R1 As DataRow
            Dim dt As DataTable

            Try
                If Me.cboGroup.SelectedValue = 0 Then
                    Throw New Exception("Please select a 'Group' to continue.")
                End If

                If Me.cboLocation.SelectedValue = 0 Then
                    Me.lblAddress.Text = ""
                    Me.txtDevice.Text = ""
                    Me.lstDevices.Items.Clear()
                    Me.grdRMAInfo.ClearFields()
                    Exit Sub
                End If

                Me.lblAddress.Text = ""
                Me.txtDevice.Text = ""
                Me.lstDevices.Items.Clear()
                Me.grdRMAInfo.ClearFields()

                iLoc_ID = Me.cboLocation.SelectedValue

                For Each R1 In dtLoc.Rows
                    If iLoc_ID = R1("Loc_ID") Then
                        Me.lblCompany.Text = Trim(R1("cust_name1"))
                        Me.lblAddress.Text = Trim(R1("Loc_Address1")) & ", " & Trim(R1("Loc_Address2")) & vbCrLf & Trim(R1("Loc_City")) & ", " & Trim(R1("state_short")) & " " & Trim(R1("Loc_Zip"))
                        Exit For
                    End If
                Next
                '**************************************************************************************
                'Fill RMA data grid
                '**************************************************************************************
                FillRMAGrid()
                '**************************************************************************************
                'This code also exists in rowcolchange event of the grid.
                'The reason I put it here is to execute it for the very first row selection
                '**************************************************************************************
                'If Me.grdRMAInfo.Columns.Count <> 0 Then
                If dtRMAGridData.Rows.Count > 0 Then

                    iWO_ID = CInt(Me.grdRMAInfo.Columns("WO_ID").Value)
                    'iSKU_ID = CInt(Me.grdRMAInfo.Columns("SKU_ID").Value)
                    iModel_ID = CInt(Me.grdRMAInfo.Columns("model_id").Value)
                    'iWO_Quantity = CInt(Me.grdRMAInfo.Columns("WO_Quantity").Value)     'AAA    RMA_Quantity
                    iWO_Quantity = CInt(Me.grdRMAInfo.Columns("RMA_Quantity").Value)
                    iNumDevicestoBeShipped = CInt(Me.grdRMAInfo.Columns("DevicesToBeShipped").Value)

                    '**************************************************************************************
                    'Goto database and bring all device serial numbers available for the workorder selected
                    '**************************************************************************************
                    'Commented by Asif on 1/19/2006
                    '''If iWO_ID <> 0 Then
                    '''    'Me.RefreshTable(iWO_ID)
                    '''    Me.RefreshTable()
                    '''End If
                    '**************************************************************************************
                Else
                    Exit Sub
                End If

                '********************************************
                'This gets the labels, reports and other 
                'Location specific information
                '********************************************

                'objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                dt = objMotoSubcontract_Biz.GetLabelInfo(iLoc_ID, Me.OverPackProcess)

                For Each R1 In dt.Rows

                    'Coffinbox related info
                    If Not IsDBNull(R1("LocMap_CoffinLabel")) Then
                        strCoffinLabelName = R1("LocMap_CoffinLabel")
                    End If
                    If Not IsDBNull(R1("CoffinLabelPrinter")) Then
                        strCoffinLabelPrinter = R1("CoffinLabelPrinter")
                    End If
                    If Not IsDBNull(R1("LocMap_CoffinPrt")) Then
                        iPrintCoffinLabel = R1("LocMap_CoffinPrt")
                    End If

                    'Master Manifest related Info
                    If Not IsDBNull(R1("LocMap_MasterManifest")) Then
                        strMasterManifestName = R1("LocMap_MasterManifest")
                    End If
                    If Not IsDBNull(R1("LocMap_MasterManPrt")) Then
                        iPrintMasterManifest = R1("LocMap_MasterManPrt")
                    End If

                    'Master Label related info
                    If Not IsDBNull(R1("LocMap_MasterLabel")) Then
                        strMasterLblName = R1("LocMap_MasterLabel")
                    End If
                    If Not IsDBNull(R1("MasterLabelPrinter")) Then
                        strMasterLblPrinter = R1("MasterLabelPrinter")
                    End If
                    If Not IsDBNull(R1("LocMap_MasterLblPrt")) Then
                        iPrintMasterLabel = R1("LocMap_MasterLblPrt")
                    End If
                    If Not IsDBNull(R1("LocMap_MasterQnt")) Then
                        iMasterPackQty = R1("LocMap_MasterQnt")
                    End If

                    'Overpack Manifest related info
                    If Not IsDBNull(R1("LocMap_OverManifest")) Then
                        strOverPackManifestName = R1("LocMap_OverManifest")
                    End If
                    If Not IsDBNull(R1("LocMap_OverManPrt")) Then
                        iPrintOverPackManifest = R1("LocMap_OverManPrt")
                    End If

                    'Overpack Label related info
                    If Not IsDBNull(R1("LocMap_OverLabel")) Then
                        strOverPackLblName = R1("LocMap_OverLabel")
                    End If
                    If Not IsDBNull(R1("OverpackLabelPrinter")) Then
                        strOverPackLblPrinter = R1("OverpackLabelPrinter")
                    End If
                    If Not IsDBNull(R1("LocMap_OverLblPrt")) Then
                        iPrintOverPackLbl = R1("LocMap_OverLblPrt")
                    End If
                    If Not IsDBNull(R1("LocMap_OverQnt")) Then
                        iOverPackQty = R1("LocMap_OverQnt")
                    End If

                    'Pallett Manifest related info
                    If Not IsDBNull(R1("LocMap_PallettManifest")) Then
                        strPallettManifestName = R1("LocMap_PallettManifest")
                    End If
                    If Not IsDBNull(R1("LocMap_PallettManPrt")) Then
                        iPrintPallettManifest = R1("LocMap_PallettManPrt")
                    End If

                    'Pallett Label related info
                    If Not IsDBNull(R1("LocMap_PallettLabel")) Then
                        strPallettLabelName = R1("LocMap_PallettLabel")
                    End If
                    If Not IsDBNull(R1("PallettLabelPrinter")) Then
                        strPallettLblPrinter = R1("PallettLabelPrinter")
                    End If
                    If Not IsDBNull(R1("LocMap_PallettLblPrt")) Then
                        iPrintPallettLbl = R1("LocMap_PallettLblPrt")
                    End If
                    If Not IsDBNull(R1("LocMap_PallettQnt")) Then
                        iPallettQty = R1("LocMap_PallettQnt")
                    End If

                    iLocMap_ShipType = R1("LocMap_ShipType")


                    'QC Report Related Info
                    iPrintQCReport = R1("LocMap_QCReportPrt")

                Next R1

                If iPrintQCReport = 1 Then
                    Me.cmdReprintQCRep.Visible = True
                Else
                    Me.cmdReprintQCRep.Visible = False
                End If

                '**************************************************************************************
                'Goto database and bring all device serial numbers available for the workorder selected
                '**************************************************************************************
                Me.RefreshTable()
                '**************************************************************************************
                '********************************************
            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.BtnPrint_Click.ObjFrm.ShowDialog(): " & ex.Message.ToString)
            Finally

                If Not IsNothing(dt) Then
                    If Not IsDBNull(dt) Then
                        dt.Dispose()
                    End If
                    dt = Nothing
                End If

                'objMotoSubcontract_Biz = Nothing
            End Try


            '********************************************


        End Sub
        '******************************************************************************
        Private Sub btnClearOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearOne.Click
            If Me.lstDevices.SelectedIndex <> -1 Then    'If nothing is selected
                Me.lstDevices.Items.RemoveAt(Me.lstDevices.SelectedIndex)
                Me.lstDevices.Refresh()
            End If
        End Sub
        '******************************************************************************
        Private Sub cboGroup_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroup.SelectionChangeCommitted
            'Clear the controls
            Me.cboCustomer.Text = ""
            Me.cboLocation.Text = ""
            Me.lblAddress.Text = ""
            Me.lblCompany.Text = ""
            Me.txtDevice.Text = ""
            Me.lstDevices.Items.Clear()
            Me.grdRMAInfo.ClearFields()

        End Sub
        '******************************************************************************
        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted

            Try
                If Me.cboGroup.SelectedValue = 0 Then
                    Throw New Exception("Please select a 'Group' to continue.")
                End If

                'Clear the controls
                Me.cboLocation.Text = ""
                Me.lblAddress.Text = ""
                Me.lblCompany.Text = ""
                Me.txtDevice.Text = ""
                Me.lstDevices.Items.Clear()
                Me.grdRMAInfo.ClearFields()

                iCust_ID = Me.cboCustomer.SelectedValue     'Set the customer
                FillLocationComboBox()          'Fill the location combo box

            Catch ex As Exception
                MsgBox("frmMotoSubContShipping.cboCustomer_SelectionChangeCommitted: " & ex.Message.ToString)
            End Try

        End Sub
        '******************************************************************************
        Private Sub chkClosePallett_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClosePallett.CheckedChanged
            If Me.chkClosePallett.Checked = True Then
                Me.chkCloseOverPack.Checked = True
            End If
        End Sub

        Private Sub chkCloseOverPack_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCloseOverPack.CheckedChanged
            If Me.chkCloseOverPack.Checked = False Then
                Me.chkClosePallett.Checked = False
            End If
        End Sub

        Private Sub grdRMAInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdRMAInfo.Click
            iFlg = 1
        End Sub

        Private Sub cmdReprintQCRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReprintQCRep.Click
            Dim iPalletID As Integer = 0
            iPalletID = InputBox("Input Pallet ID.", "Reprint QC Report")
            If Not IsNumeric(iPalletID) Then
                MessageBox.Show("Pallet ID must be numeric.", "Reprint QC Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If iPalletID > 0 Then
                CreateQCRep(iPalletID)     '101188
            End If
        End Sub

        Private Sub CreateQCRep(ByVal iPallett_ID As Integer)
            Dim i As Integer = 0
            i = objMisc.CreateQCReport(iPallett_ID)
            If i = 0 Then
                Throw New Exception("QC report failed.")
            Else
                MessageBox.Show("Report is created at R:\CELLSTAR\Cellstar QC Reports\", "Reprint QC Report", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            End If
        End Sub

    End Class
End Namespace

