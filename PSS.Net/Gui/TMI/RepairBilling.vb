Option Explicit On 

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System.IO

Namespace Gui

    Public Class RepairBilling
        Inherits System.Windows.Forms.Form
        Private _strScreenName As String = "REPAIR"
        Private _iScreenID As Integer = 3414
        Private Const vBuffer As Integer = 5
        Private Const hBuffer As Integer = 5
        Private Const btnWidth = 120
        Private Const btnHeight = 50

        Private btnLeft As Int32 = 5
        Private btnTop As Int32 = 5

        Private pnlLeft As Integer
        Private pnlWidth As Integer
        Private origFrmWidth As Integer
        Private formDiffWidth As Integer
        Private colCount As Integer

        Private _objNewTech As PSS.Data.Buisness.NewTech

        Private _device As Device = Nothing
        Private tmpDeviceID, tmpModelID, tmpManufID, tmpProdID, tmpLoc, tmpCustID, tmpWO, tmpDeviceType, tmpConsignedParts, tmpCustCRbill As Integer

        Private dtCustomerSet, _dtAWAP As DataTable

        Private vManufWrty As Integer = 0
        Private _iPSSWrty As Integer = 0

        Dim zCount As Integer
        Dim rPresent As DataRow

        Private _drPreBillData, _drCelloptData As DataRow
        Private _iMachineGrpID As Integer = 0
        Private _iDeviceWipOwner As Integer = 0

        'WARRANTY CLAIM
        Private _iFailID As Integer = 0
        Private _iRepairID As Integer = 0
        Private _iBillType As Integer = 0
        Private _booPopulatingReflowCheckListFlg As Boolean = False

        'This customer ID send from the menu selection
        Private _iSCustID As Integer = 0
        Private _booStationCheck As Boolean = True

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal iBillType As Integer = 2, _
                       Optional ByVal iCustID As Integer = 0, _
                       Optional ByVal strScreenName As String = "", _
                       Optional ByVal iCheckDeviceStation As Integer = -1, _
                       Optional ByVal iScreenID As Integer = 0)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iBillType = iBillType   'Magic number 1: Pre-Bill, 2:Tech  3:Pre-Bill Lot

            If iCustID > 0 Then
                Me._iSCustID = iCustID
                Me.lblCustName.Text = PSS.Data.Buisness.Generic.GetCustomerName(iCustID)
            End If

            If strScreenName.Trim.Length > 0 Then Me._strScreenName = strScreenName
            If iCheckDeviceStation >= 0 Then
                If iCheckDeviceStation = 0 Then Me._booStationCheck = False Else Me._booStationCheck = True
            End If
            Me._iScreenID = iScreenID
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
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceSN As System.Windows.Forms.Label
        Friend WithEvents tabMain As System.Windows.Forms.TabControl
        Friend WithEvents tbParts As System.Windows.Forms.TabPage
        Friend WithEvents tbServices As System.Windows.Forms.TabPage
        Friend WithEvents pnlBill As System.Windows.Forms.Panel
        Friend WithEvents pnlService As System.Windows.Forms.Panel
        Friend WithEvents gridBilling As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents tbScrap As System.Windows.Forms.TabPage
        Friend WithEvents pnlScrap As System.Windows.Forms.Panel
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents lblCustName As System.Windows.Forms.Label
        Friend WithEvents tbRVParts As System.Windows.Forms.TabPage
        Friend WithEvents pnlRVParts As System.Windows.Forms.Panel
        Friend WithEvents lblWarrantyStatus As System.Windows.Forms.Label
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents tbTestResults As System.Windows.Forms.TabPage
        Friend WithEvents pnlTestResults As System.Windows.Forms.Panel
        Friend WithEvents lblTestResult_QC As System.Windows.Forms.Label
        Friend WithEvents _LabelTestResult_QC As System.Windows.Forms.Label
        Friend WithEvents tpAccessories As System.Windows.Forms.TabPage
        Friend WithEvents pnlAccessories As System.Windows.Forms.Panel
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblManufSN As System.Windows.Forms.Label
        Friend WithEvents lblSelected As System.Windows.Forms.Label
        Friend WithEvents txtTestResult_Triage As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents pnlNeededParts As System.Windows.Forms.Panel
        Friend WithEvents pnlNeededAccessories As System.Windows.Forms.Panel
        Friend WithEvents tbNeedPart As System.Windows.Forms.TabPage
        Friend WithEvents tbNeedAccessories As System.Windows.Forms.TabPage
        Friend WithEvents lblManufModelNumber As System.Windows.Forms.Label
        Friend WithEvents grdTechHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents lblWipLoc As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblClaimNotes As System.Windows.Forms.Label
        Friend WithEvents _LabelTestResult_Triage As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblClaimReason As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RepairBilling))
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.lblDeviceSN = New System.Windows.Forms.Label()
            Me.tabMain = New System.Windows.Forms.TabControl()
            Me.tbParts = New System.Windows.Forms.TabPage()
            Me.pnlBill = New System.Windows.Forms.Panel()
            Me.tbNeedPart = New System.Windows.Forms.TabPage()
            Me.pnlNeededParts = New System.Windows.Forms.Panel()
            Me.tbServices = New System.Windows.Forms.TabPage()
            Me.pnlService = New System.Windows.Forms.Panel()
            Me.tpAccessories = New System.Windows.Forms.TabPage()
            Me.pnlAccessories = New System.Windows.Forms.Panel()
            Me.tbNeedAccessories = New System.Windows.Forms.TabPage()
            Me.pnlNeededAccessories = New System.Windows.Forms.Panel()
            Me.tbTestResults = New System.Windows.Forms.TabPage()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.grdTechHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnlTestResults = New System.Windows.Forms.Panel()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblClaimReason = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblClaimNotes = New System.Windows.Forms.Label()
            Me.txtTestResult_Triage = New System.Windows.Forms.TextBox()
            Me._LabelTestResult_QC = New System.Windows.Forms.Label()
            Me.lblTestResult_QC = New System.Windows.Forms.Label()
            Me._LabelTestResult_Triage = New System.Windows.Forms.Label()
            Me.tbScrap = New System.Windows.Forms.TabPage()
            Me.pnlScrap = New System.Windows.Forms.Panel()
            Me.tbRVParts = New System.Windows.Forms.TabPage()
            Me.pnlRVParts = New System.Windows.Forms.Panel()
            Me.gridBilling = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.lblCustName = New System.Windows.Forms.Label()
            Me.lblWarrantyStatus = New System.Windows.Forms.Label()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblManufSN = New System.Windows.Forms.Label()
            Me.lblWipLoc = New System.Windows.Forms.Label()
            Me.lblSelected = New System.Windows.Forms.Label()
            Me.lblManufModelNumber = New System.Windows.Forms.Label()
            Me.tabMain.SuspendLayout()
            Me.tbParts.SuspendLayout()
            Me.tbNeedPart.SuspendLayout()
            Me.tbServices.SuspendLayout()
            Me.tpAccessories.SuspendLayout()
            Me.tbNeedAccessories.SuspendLayout()
            Me.tbTestResults.SuspendLayout()
            CType(Me.grdTechHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlTestResults.SuspendLayout()
            Me.tbScrap.SuspendLayout()
            Me.tbRVParts.SuspendLayout()
            CType(Me.gridBilling, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtSerial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSerial.Location = New System.Drawing.Point(104, 33)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(136, 20)
            Me.txtSerial.TabIndex = 1
            Me.txtSerial.Text = ""
            '
            'lblDeviceSN
            '
            Me.lblDeviceSN.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(192, Byte))
            Me.lblDeviceSN.Location = New System.Drawing.Point(-16, 33)
            Me.lblDeviceSN.Name = "lblDeviceSN"
            Me.lblDeviceSN.Size = New System.Drawing.Size(120, 16)
            Me.lblDeviceSN.TabIndex = 104
            Me.lblDeviceSN.Text = "PSS Serial Number:"
            Me.lblDeviceSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tabMain
            '
            Me.tabMain.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.tabMain.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbParts, Me.tbNeedPart, Me.tbServices, Me.tpAccessories, Me.tbNeedAccessories, Me.tbTestResults, Me.tbScrap, Me.tbRVParts})
            Me.tabMain.Location = New System.Drawing.Point(8, 64)
            Me.tabMain.Name = "tabMain"
            Me.tabMain.SelectedIndex = 0
            Me.tabMain.Size = New System.Drawing.Size(976, 488)
            Me.tabMain.TabIndex = 108
            '
            'tbParts
            '
            Me.tbParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlBill})
            Me.tbParts.Location = New System.Drawing.Point(4, 22)
            Me.tbParts.Name = "tbParts"
            Me.tbParts.Size = New System.Drawing.Size(968, 462)
            Me.tbParts.TabIndex = 0
            Me.tbParts.Text = "PARTS"
            '
            'pnlBill
            '
            Me.pnlBill.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlBill.AutoScroll = True
            Me.pnlBill.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlBill.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlBill.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlBill.Location = New System.Drawing.Point(8, 8)
            Me.pnlBill.Name = "pnlBill"
            Me.pnlBill.Size = New System.Drawing.Size(952, 440)
            Me.pnlBill.TabIndex = 108
            '
            'tbNeedPart
            '
            Me.tbNeedPart.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlNeededParts})
            Me.tbNeedPart.Location = New System.Drawing.Point(4, 22)
            Me.tbNeedPart.Name = "tbNeedPart"
            Me.tbNeedPart.Size = New System.Drawing.Size(968, 462)
            Me.tbNeedPart.TabIndex = 3
            Me.tbNeedPart.Text = "Need Part(s)"
            '
            'pnlNeededParts
            '
            Me.pnlNeededParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlNeededParts.AutoScroll = True
            Me.pnlNeededParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlNeededParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlNeededParts.Name = "pnlNeededParts"
            Me.pnlNeededParts.Size = New System.Drawing.Size(952, 440)
            Me.pnlNeededParts.TabIndex = 110
            '
            'tbServices
            '
            Me.tbServices.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlService})
            Me.tbServices.Location = New System.Drawing.Point(4, 22)
            Me.tbServices.Name = "tbServices"
            Me.tbServices.Size = New System.Drawing.Size(968, 462)
            Me.tbServices.TabIndex = 1
            Me.tbServices.Text = "SERVICES"
            '
            'pnlService
            '
            Me.pnlService.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlService.AutoScroll = True
            Me.pnlService.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlService.Location = New System.Drawing.Point(8, 8)
            Me.pnlService.Name = "pnlService"
            Me.pnlService.Size = New System.Drawing.Size(952, 440)
            Me.pnlService.TabIndex = 109
            '
            'tpAccessories
            '
            Me.tpAccessories.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlAccessories})
            Me.tpAccessories.Location = New System.Drawing.Point(4, 22)
            Me.tpAccessories.Name = "tpAccessories"
            Me.tpAccessories.Size = New System.Drawing.Size(968, 462)
            Me.tpAccessories.TabIndex = 9
            Me.tpAccessories.Text = "ACCESSORIES"
            '
            'pnlAccessories
            '
            Me.pnlAccessories.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlAccessories.AutoScroll = True
            Me.pnlAccessories.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlAccessories.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlAccessories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlAccessories.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlAccessories.Location = New System.Drawing.Point(8, 11)
            Me.pnlAccessories.Name = "pnlAccessories"
            Me.pnlAccessories.Size = New System.Drawing.Size(952, 440)
            Me.pnlAccessories.TabIndex = 109
            '
            'tbNeedAccessories
            '
            Me.tbNeedAccessories.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlNeededAccessories})
            Me.tbNeedAccessories.Location = New System.Drawing.Point(4, 22)
            Me.tbNeedAccessories.Name = "tbNeedAccessories"
            Me.tbNeedAccessories.Size = New System.Drawing.Size(968, 462)
            Me.tbNeedAccessories.TabIndex = 10
            Me.tbNeedAccessories.Text = "Need Accessories"
            '
            'pnlNeededAccessories
            '
            Me.pnlNeededAccessories.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlNeededAccessories.AutoScroll = True
            Me.pnlNeededAccessories.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlNeededAccessories.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlNeededAccessories.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlNeededAccessories.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlNeededAccessories.Location = New System.Drawing.Point(8, 11)
            Me.pnlNeededAccessories.Name = "pnlNeededAccessories"
            Me.pnlNeededAccessories.Size = New System.Drawing.Size(952, 440)
            Me.pnlNeededAccessories.TabIndex = 110
            '
            'tbTestResults
            '
            Me.tbTestResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.grdTechHistory, Me.txtNote, Me.Label1, Me.pnlTestResults})
            Me.tbTestResults.Location = New System.Drawing.Point(4, 22)
            Me.tbTestResults.Name = "tbTestResults"
            Me.tbTestResults.Size = New System.Drawing.Size(968, 462)
            Me.tbTestResults.TabIndex = 8
            Me.tbTestResults.Text = "TEST RESULTS"
            '
            'Button1
            '
            Me.Button1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.Button1.Location = New System.Drawing.Point(8, 128)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(88, 22)
            Me.Button1.TabIndex = 124
            Me.Button1.Text = "Save"
            Me.Button1.Visible = False
            '
            'grdTechHistory
            '
            Me.grdTechHistory.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.grdTechHistory.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdTechHistory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdTechHistory.Location = New System.Drawing.Point(120, 72)
            Me.grdTechHistory.Name = "grdTechHistory"
            Me.grdTechHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdTechHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdTechHistory.PreviewInfo.ZoomFactor = 75
            Me.grdTechHistory.RowHeight = 30
            Me.grdTechHistory.Size = New System.Drawing.Size(832, 184)
            Me.grdTechHistory.TabIndex = 15
            Me.grdTechHistory.Text = "C1TrueDBGrid1"
            Me.grdTechHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Wrap:True;AlignHorz:Near;" & _
            "BackColor:Aqua;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}In" & _
            "active{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Foote" & _
            "r{}Caption{AlignHorz:Center;}Style9{}Normal{BackColor:LightSteelBlue;}HighlightR" & _
            "ow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Wrap:True;AlignH" & _
            "orz:Near;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;AlignVert" & _
            ":Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style" & _
            "8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><S" & _
            "plits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" Name="""" CaptionHeight=""17"" " & _
            "ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder""" & _
            " RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horizontal" & _
            "ScrollGroup=""1""><Height>180</Height><CaptionStyle parent=""Style2"" me=""Style10"" /" & _
            "><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""S" & _
            "tyle8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""" & _
            "Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle pa" & _
            "rent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7" & _
            """ /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" " & _
            "me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Selec" & _
            "tedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><C" & _
            "lientRect>0, 0, 828, 180</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunk" & _
            "en</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style par" & _
            "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
            "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
            "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
            "=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me" & _
            "=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Re" & _
            "cordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" " & _
            "me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><" & _
            "Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0," & _
            " 828, 180</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageF" & _
            "ooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'txtNote
            '
            Me.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtNote.ForeColor = System.Drawing.Color.Black
            Me.txtNote.Location = New System.Drawing.Point(120, 8)
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.txtNote.Size = New System.Drawing.Size(832, 56)
            Me.txtNote.TabIndex = 1
            Me.txtNote.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(16, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 24)
            Me.Label1.TabIndex = 10
            Me.Label1.Text = "Tech Notes:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'pnlTestResults
            '
            Me.pnlTestResults.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlTestResults.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.lblClaimReason, Me.Label2, Me.lblClaimNotes, Me.txtTestResult_Triage, Me._LabelTestResult_QC, Me.lblTestResult_QC, Me._LabelTestResult_Triage})
            Me.pnlTestResults.Location = New System.Drawing.Point(16, 272)
            Me.pnlTestResults.Name = "pnlTestResults"
            Me.pnlTestResults.Size = New System.Drawing.Size(944, 176)
            Me.pnlTestResults.TabIndex = 0
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(-40, 128)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(144, 23)
            Me.Label3.TabIndex = 20
            Me.Label3.Text = "Claim Reason : "
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblClaimReason
            '
            Me.lblClaimReason.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblClaimReason.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimReason.ForeColor = System.Drawing.Color.White
            Me.lblClaimReason.Location = New System.Drawing.Point(104, 128)
            Me.lblClaimReason.Name = "lblClaimReason"
            Me.lblClaimReason.Size = New System.Drawing.Size(832, 32)
            Me.lblClaimReason.TabIndex = 19
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(-40, 88)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(144, 23)
            Me.Label2.TabIndex = 18
            Me.Label2.Text = "Claim Notes : "
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblClaimNotes
            '
            Me.lblClaimNotes.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblClaimNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblClaimNotes.ForeColor = System.Drawing.Color.White
            Me.lblClaimNotes.Location = New System.Drawing.Point(104, 88)
            Me.lblClaimNotes.Name = "lblClaimNotes"
            Me.lblClaimNotes.Size = New System.Drawing.Size(832, 32)
            Me.lblClaimNotes.TabIndex = 17
            '
            'txtTestResult_Triage
            '
            Me.txtTestResult_Triage.BackColor = System.Drawing.SystemColors.WindowText
            Me.txtTestResult_Triage.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.txtTestResult_Triage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTestResult_Triage.ForeColor = System.Drawing.Color.White
            Me.txtTestResult_Triage.Location = New System.Drawing.Point(104, 8)
            Me.txtTestResult_Triage.Multiline = True
            Me.txtTestResult_Triage.Name = "txtTestResult_Triage"
            Me.txtTestResult_Triage.Size = New System.Drawing.Size(832, 32)
            Me.txtTestResult_Triage.TabIndex = 16
            Me.txtTestResult_Triage.Text = ""
            '
            '_LabelTestResult_QC
            '
            Me._LabelTestResult_QC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_QC.Location = New System.Drawing.Point(40, 48)
            Me._LabelTestResult_QC.Name = "_LabelTestResult_QC"
            Me._LabelTestResult_QC.Size = New System.Drawing.Size(64, 23)
            Me._LabelTestResult_QC.TabIndex = 15
            Me._LabelTestResult_QC.Text = "QC:"
            Me._LabelTestResult_QC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTestResult_QC
            '
            Me.lblTestResult_QC.BackColor = System.Drawing.SystemColors.ControlText
            Me.lblTestResult_QC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTestResult_QC.ForeColor = System.Drawing.Color.White
            Me.lblTestResult_QC.Location = New System.Drawing.Point(104, 48)
            Me.lblTestResult_QC.Name = "lblTestResult_QC"
            Me.lblTestResult_QC.Size = New System.Drawing.Size(832, 32)
            Me.lblTestResult_QC.TabIndex = 14
            '
            '_LabelTestResult_Triage
            '
            Me._LabelTestResult_Triage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me._LabelTestResult_Triage.Location = New System.Drawing.Point(32, 16)
            Me._LabelTestResult_Triage.Name = "_LabelTestResult_Triage"
            Me._LabelTestResult_Triage.Size = New System.Drawing.Size(72, 23)
            Me._LabelTestResult_Triage.TabIndex = 9
            Me._LabelTestResult_Triage.Text = "TRIAGE:"
            Me._LabelTestResult_Triage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tbScrap
            '
            Me.tbScrap.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlScrap})
            Me.tbScrap.Location = New System.Drawing.Point(4, 22)
            Me.tbScrap.Name = "tbScrap"
            Me.tbScrap.Size = New System.Drawing.Size(968, 462)
            Me.tbScrap.TabIndex = 2
            Me.tbScrap.Text = "SCRAP"
            '
            'pnlScrap
            '
            Me.pnlScrap.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlScrap.AutoScroll = True
            Me.pnlScrap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlScrap.Location = New System.Drawing.Point(8, 8)
            Me.pnlScrap.Name = "pnlScrap"
            Me.pnlScrap.Size = New System.Drawing.Size(952, 440)
            Me.pnlScrap.TabIndex = 0
            '
            'tbRVParts
            '
            Me.tbRVParts.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlRVParts})
            Me.tbRVParts.Location = New System.Drawing.Point(4, 22)
            Me.tbRVParts.Name = "tbRVParts"
            Me.tbRVParts.Size = New System.Drawing.Size(968, 462)
            Me.tbRVParts.TabIndex = 5
            Me.tbRVParts.Text = "RV PARTS"
            '
            'pnlRVParts
            '
            Me.pnlRVParts.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.pnlRVParts.AutoScroll = True
            Me.pnlRVParts.AutoScrollMargin = New System.Drawing.Size(10, 10)
            Me.pnlRVParts.AutoScrollMinSize = New System.Drawing.Size(10, 10)
            Me.pnlRVParts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlRVParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.pnlRVParts.Location = New System.Drawing.Point(8, 11)
            Me.pnlRVParts.Name = "pnlRVParts"
            Me.pnlRVParts.Size = New System.Drawing.Size(952, 440)
            Me.pnlRVParts.TabIndex = 109
            '
            'gridBilling
            '
            Me.gridBilling.AlternatingRows = True
            Me.gridBilling.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.gridBilling.BackColor = System.Drawing.SystemColors.Control
            Me.gridBilling.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
            Me.gridBilling.GroupByCaption = "Drag a column header here to group by that column"
            Me.gridBilling.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.gridBilling.Location = New System.Drawing.Point(8, 104)
            Me.gridBilling.Name = "gridBilling"
            Me.gridBilling.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.gridBilling.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.gridBilling.PreviewInfo.ZoomFactor = 75
            Me.gridBilling.Size = New System.Drawing.Size(960, 441)
            Me.gridBilling.TabIndex = 118
            Me.gridBilling.TabStop = False
            Me.gridBilling.Text = "C1TrueDBGrid1"
            Me.gridBilling.PropBag = "<?xml version=""1.0""?><Blob><DataCols><C1DataColumn Caption=""Bill Code"" DataField=" & _
            """""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""Description""" & _
            " DataField=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Caption=""R" & _
            "ef Des"" DataField=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColumn Cap" & _
            "tion=""Number"" DataField=""""><ValueItems /><GroupInfo /></C1DataColumn><C1DataColu" & _
            "mn Caption=""Failure"" DataField=""""><ValueItems /><GroupInfo /></C1DataColumn><C1D" & _
            "ataColumn Caption=""Transaction"" DataField=""""><ValueItems /><GroupInfo /></C1Data" & _
            "Column></DataCols><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrapper""><Data" & _
            ">RecordSelector{AlignImage:Center;}Style50{}Style51{}Caption{AlignHorz:Center;}N" & _
            "ormal{}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Style31{Ali" & _
            "gnHorz:Near;}Style18{AlignHorz:Near;}Style19{AlignHorz:Near;}Style14{AlignHorz:N" & _
            "ear;}Style15{AlignHorz:Near;}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}" & _
            "Style12{}Style13{}Style46{}FilterBar{}Style2{}Style37{}Style32{}Style33{}Style4{" & _
            "}OddRow{}Style29{}Style28{}Style27{AlignHorz:Near;}Style26{AlignHorz:Near;}Style" & _
            "25{}Footer{}Style23{AlignHorz:Near;}Style22{AlignHorz:Near;}Style21{}Style20{}Gr" & _
            "oup{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Inactive{For" & _
            "eColor:InactiveCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:Aqua;}He" & _
            "ading{Wrap:True;AlignVert:Center;Border:Flat,ControlDark,0, 1, 0, 1;ForeColor:Co" & _
            "ntrolText;BackColor:Control;}Style49{}Style48{}Style24{}Style7{}Style8{}Style41{" & _
            "}Style40{}Style43{}Style42{}Style45{}Style44{}Style47{}Style9{}Style38{}Style39{" & _
            "}Style36{}Style5{}Style34{AlignHorz:Near;}Style35{AlignHorz:Near;}Style6{}Style1" & _
            "{}Style30{AlignHorz:Near;}Style3{}HighlightRow{ForeColor:HighlightText;BackColor" & _
            ":Highlight;}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" Alter" & _
            "natingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHe" & _
            "ight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidt" & _
            "h=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>437</Height><Ca" & _
            "ptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style" & _
            "5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Filter" & _
            "Bar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle paren" & _
            "t=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLight" & _
            "RowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me" & _
            "=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle pare" & _
            "nt=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" " & _
            "/><Style parent=""Normal"" me=""Style1"" /><internalCols><C1DisplayColumn><HeadingSt" & _
            "yle parent=""Style2"" me=""Style34"" /><Style parent=""Style1"" me=""Style35"" /><Footer" & _
            "Style parent=""Style3"" me=""Style36"" /><EditorStyle parent=""Style5"" me=""Style37"" /" & _
            "><GroupHeaderStyle parent=""Style1"" me=""Style41"" /><GroupFooterStyle parent=""Styl" & _
            "e1"" me=""Style40"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single</Column" & _
            "Divider><Height>15</Height><DCIdx>0</DCIdx></C1DisplayColumn><C1DisplayColumn><H" & _
            "eadingStyle parent=""Style2"" me=""Style14"" /><Style parent=""Style1"" me=""Style15"" /" & _
            "><FooterStyle parent=""Style3"" me=""Style16"" /><EditorStyle parent=""Style5"" me=""St" & _
            "yle17"" /><GroupHeaderStyle parent=""Style1"" me=""Style43"" /><GroupFooterStyle pare" & _
            "nt=""Style1"" me=""Style42"" /><Visible>True</Visible><ColumnDivider>DarkGray,Single" & _
            "</ColumnDivider><Height>15</Height><DCIdx>2</DCIdx></C1DisplayColumn><C1DisplayC" & _
            "olumn><HeadingStyle parent=""Style2"" me=""Style18"" /><Style parent=""Style1"" me=""St" & _
            "yle19"" /><FooterStyle parent=""Style3"" me=""Style20"" /><EditorStyle parent=""Style5" & _
            """ me=""Style21"" /><GroupHeaderStyle parent=""Style1"" me=""Style45"" /><GroupFooterSt" & _
            "yle parent=""Style1"" me=""Style44"" /><Visible>True</Visible><ColumnDivider>DarkGra" & _
            "y,Single</ColumnDivider><Height>15</Height><DCIdx>3</DCIdx></C1DisplayColumn><C1" & _
            "DisplayColumn><HeadingStyle parent=""Style2"" me=""Style26"" /><Style parent=""Style1" & _
            """ me=""Style27"" /><FooterStyle parent=""Style3"" me=""Style28"" /><EditorStyle parent" & _
            "=""Style5"" me=""Style29"" /><GroupHeaderStyle parent=""Style1"" me=""Style47"" /><Group" & _
            "FooterStyle parent=""Style1"" me=""Style46"" /><Visible>True</Visible><ColumnDivider" & _
            ">DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>4</DCIdx></C1DisplayCo" & _
            "lumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style22"" /><Style parent" & _
            "=""Style1"" me=""Style23"" /><FooterStyle parent=""Style3"" me=""Style24"" /><EditorStyl" & _
            "e parent=""Style5"" me=""Style25"" /><GroupHeaderStyle parent=""Style1"" me=""Style49"" " & _
            "/><GroupFooterStyle parent=""Style1"" me=""Style48"" /><Visible>True</Visible><Colum" & _
            "nDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>1</DCIdx></C1D" & _
            "isplayColumn><C1DisplayColumn><HeadingStyle parent=""Style2"" me=""Style30"" /><Styl" & _
            "e parent=""Style1"" me=""Style31"" /><FooterStyle parent=""Style3"" me=""Style32"" /><Ed" & _
            "itorStyle parent=""Style5"" me=""Style33"" /><GroupHeaderStyle parent=""Style1"" me=""S" & _
            "tyle51"" /><GroupFooterStyle parent=""Style1"" me=""Style50"" /><Visible>True</Visibl" & _
            "e><ColumnDivider>DarkGray,Single</ColumnDivider><Height>15</Height><DCIdx>5</DCI" & _
            "dx></C1DisplayColumn></internalCols><ClientRect>0, 0, 956, 437</ClientRect><Bord" & _
            "erSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merg" & _
            "eView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal" & _
            """ me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" m" & _
            "e=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=" & _
            """Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Hig" & _
            "hlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Od" & _
            "dRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=" & _
            """FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</" & _
            "vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidt" & _
            "h>17</DefaultRecSelWidth><ClientArea>0, 0, 956, 437</ClientArea><PrintPageHeader" & _
            "Style parent="""" me=""Style38"" /><PrintPageFooterStyle parent="""" me=""Style39"" /></" & _
            "Blob>"
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnClear.Location = New System.Drawing.Point(920, 1)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 22)
            Me.btnClear.TabIndex = 120
            Me.btnClear.Text = "&Clear"
            '
            'btnComplete
            '
            Me.btnComplete.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnComplete.Location = New System.Drawing.Point(792, 1)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(124, 22)
            Me.btnComplete.TabIndex = 123
            Me.btnComplete.Text = "Complete This Device"
            '
            'lblCustName
            '
            Me.lblCustName.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustName.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblCustName.Location = New System.Drawing.Point(8, 8)
            Me.lblCustName.Name = "lblCustName"
            Me.lblCustName.Size = New System.Drawing.Size(128, 16)
            Me.lblCustName.TabIndex = 135
            Me.lblCustName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWarrantyStatus
            '
            Me.lblWarrantyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWarrantyStatus.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWarrantyStatus.ForeColor = System.Drawing.Color.Red
            Me.lblWarrantyStatus.Location = New System.Drawing.Point(248, 33)
            Me.lblWarrantyStatus.Name = "lblWarrantyStatus"
            Me.lblWarrantyStatus.Size = New System.Drawing.Size(48, 20)
            Me.lblWarrantyStatus.TabIndex = 137
            Me.lblWarrantyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblScreenName
            '
            Me.lblScreenName.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblScreenName.Location = New System.Drawing.Point(152, 8)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(136, 16)
            Me.lblScreenName.TabIndex = 138
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblModel
            '
            Me.lblModel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblModel.Location = New System.Drawing.Point(312, 8)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(168, 16)
            Me.lblModel.TabIndex = 139
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblManufSN
            '
            Me.lblManufSN.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManufSN.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblManufSN.Location = New System.Drawing.Point(312, 33)
            Me.lblManufSN.Name = "lblManufSN"
            Me.lblManufSN.Size = New System.Drawing.Size(168, 20)
            Me.lblManufSN.TabIndex = 140
            Me.lblManufSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWipLoc
            '
            Me.lblWipLoc.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWipLoc.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblWipLoc.Location = New System.Drawing.Point(488, 33)
            Me.lblWipLoc.Name = "lblWipLoc"
            Me.lblWipLoc.Size = New System.Drawing.Size(360, 20)
            Me.lblWipLoc.TabIndex = 141
            Me.lblWipLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSelected
            '
            Me.lblSelected.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblSelected.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSelected.ForeColor = System.Drawing.Color.Blue
            Me.lblSelected.Location = New System.Drawing.Point(856, 32)
            Me.lblSelected.Name = "lblSelected"
            Me.lblSelected.Size = New System.Drawing.Size(128, 16)
            Me.lblSelected.TabIndex = 142
            Me.lblSelected.Text = "SHOW SELECTED"
            Me.lblSelected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblSelected.Visible = False
            '
            'lblManufModelNumber
            '
            Me.lblManufModelNumber.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManufModelNumber.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblManufModelNumber.Location = New System.Drawing.Point(488, 8)
            Me.lblManufModelNumber.Name = "lblManufModelNumber"
            Me.lblManufModelNumber.Size = New System.Drawing.Size(296, 16)
            Me.lblManufModelNumber.TabIndex = 143
            Me.lblManufModelNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'RepairBilling
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(992, 558)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblManufModelNumber, Me.lblSelected, Me.lblWipLoc, Me.lblManufSN, Me.lblModel, Me.lblScreenName, Me.lblWarrantyStatus, Me.lblCustName, Me.btnComplete, Me.btnClear, Me.tabMain, Me.txtSerial, Me.lblDeviceSN, Me.gridBilling})
            Me.Name = "RepairBilling"
            Me.Text = "frmNewTech"
            Me.tabMain.ResumeLayout(False)
            Me.tbParts.ResumeLayout(False)
            Me.tbNeedPart.ResumeLayout(False)
            Me.tbServices.ResumeLayout(False)
            Me.tpAccessories.ResumeLayout(False)
            Me.tbNeedAccessories.ResumeLayout(False)
            Me.tbTestResults.ResumeLayout(False)
            CType(Me.grdTechHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlTestResults.ResumeLayout(False)
            Me.tbScrap.ResumeLayout(False)
            Me.tbRVParts.ResumeLayout(False)
            CType(Me.gridBilling, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Generate Dynamic Buttons"

        '*****************************************************************
        Private Sub createScrapButtons(ByVal dt As DataTable)
            Dim btnWidthScrap As Integer = 225
            Dim btnHeightScrap As Integer = 30
            Dim NSCbtnWidthScrap As Integer = 220
            Dim NSCbtnHeightScrap As Integer = 5

            Dim r As DataRow
            'Dim dtScrap As DataTable
            Dim cBill() As Button
            Dim heightPanelSCRAP As Integer
            Dim widthPanelSCRAP As Integer
            Dim colLengthScrap As Integer = 16
            Dim x As Integer = 0
            Dim iCount As Integer = 0
            Dim objScrap As PSS.Data.Buisness.ScrapParts

            Try
                'dtScrap = Me._objNewTech.GetScrapParts(Me.tmpDeviceID)
                objScrap = New PSS.Data.Buisness.ScrapParts()

                colCount = 0
                pnlScrap.BackColor = Color.LightYellow
                pnlLeft = pnlScrap.Left
                pnlWidth = tabMain.Width - 48
                'gridLeft = gridBilling.Left
                'gridWidth = gridBilling.Width

                ReDim cBill(dt.Rows.Count)

                heightPanelSCRAP = pnlScrap.Height - 20
                widthPanelSCRAP = pnlScrap.Width

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()

                    With cBill(x)
                        iCount = 0
                        '********************************************
                        If Not IsDBNull(r("BillCode_ID")) Then
                            iCount = objScrap.GetScrapCount(tmpDeviceID, tmpModelID, r("BillCode_ID"))
                        End If

                        If iCount > 0 Then
                            .BackColor = Color.LightGreen
                            .ForeColor = Color.Black
                        Else
                            .BackColor = Color.LightCoral
                            .ForeColor = Color.Black
                        End If
                        '********************************************

                        .Text = r("BillCode_DESC") & " " & Trim("(" & Trim(iCount) & ")")
                        .Size = New Size(btnWidthScrap, btnHeightScrap)
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True
                        colCount += 1
                        '.BackColor = Color.LightCoral
                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.ScrapClick
                    End With

                    colLengthScrap = 16

                    If colCount > colLengthScrap Then
                        If tmpCustID = 1403 Then
                            btnLeft = btnLeft + NSCbtnWidthScrap
                        Else
                            btnLeft = btnLeft + btnWidthScrap + 5
                        End If
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        If tmpCustID = 1403 Then
                            btnTop = btnTop + NSCbtnHeightScrap
                        Else
                            btnTop = btnTop + btnHeightScrap + 2
                        End If
                    End If
                Next
                Me.pnlScrap.Controls.AddRange(cBill)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateScrapButtons", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                r = Nothing
                cBill = Nothing
                'PSS.Data.Buisness.Generic.DisposeDT(dtScrap)
            End Try
        End Sub

        '*****************************************************************
        Private Sub createBillingButtons(ByVal dt As DataTable)
            Dim r As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0

            Try
                '*************************************
                'Create consumption buttons
                '*************************************
                colCount = 0
                pnlLeft = pnlBill.Left
                pnlWidth = tabMain.Width - 48

                gridBilling.Visible = False

                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()
                    With cBill(x)
                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True

                        .BackColor = Color.LightGray
                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick
                    End With

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next

                Me.pnlBill.Controls.AddRange(cBill)

                '*************************************
                'Create need buttons
                '*************************************
                colCount = 0
                pnlLeft = Me.pnlNeededParts.Left
                pnlWidth = tabMain.Width - 48

                gridBilling.Visible = False

                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    cBill(x) = New System.Windows.Forms.Button()
                    With cBill(x)
                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True

                        '*********************************************
                        'High light Consigned parts
                        '*********************************************
                        If r("PSPrice_ConsignedPart").ToString() = "1" Then
                            .BackColor = Color.Orange
                        Else
                            .BackColor = Color.LightSteelBlue
                        End If
                        '*********************************************

                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick_AWAP
                    End With

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next

                Me.pnlNeededParts.Controls.AddRange(cBill)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                r = Nothing
                cBill = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Sub createServiceButtons(ByVal dt As DataTable)
            Dim cService() As Button
            Dim heightPanelSERVICE As Integer
            Dim widthPanelSERVICE As Integer
            Dim x As Integer = 0
            Dim r As DataRow

            Try
                colCount = 0
                pnlLeft = pnlService.Left
                pnlWidth = tabMain.Width - 48

                pnlService.Width = pnlService.Width

                ReDim cService(dt.Rows.Count)

                heightPanelSERVICE = pnlService.Height
                widthPanelSERVICE = pnlService.Width

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)

                    cService(x) = New System.Windows.Forms.Button()
                    With cService(x)
                        .Text = r("BillCode_DESC")
                        .Size = New Size(btnWidth, btnHeight)
                        .Location = New Point(btnLeft, btnTop)
                        .BackColor = Color.LightGray
                        .Visible = True
                        colCount += 1
                        .Tag = r("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.billingClick
                    End With


                    'colCount += 1
                    If colCount > 6 Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next
                Me.pnlService.Controls.AddRange(cService)

            Catch ex As Exception
                Throw ex
            Finally
                cService = Nothing
                r = Nothing
            End Try
        End Sub

        '*****************************************************************
        Private Function CreateRVBillCodesButtons() As Boolean
            Dim booResult As Boolean = True
            Dim r, drNewRow As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim x As Integer = 0
            Dim myBillColumn As DataColumn
            Dim dt, dtReflow As DataTable
            Dim objBD As New Buisness.Billing.BillingData()

            Try
                '***************************************
                'RV Parts
                '***************************************
                dt = objBD.GetPartBillcodes(Me.tmpCustID, Me.tmpModelID, , , 1)

                colCount = 0
                pnlLeft = Me.pnlRVParts.Left
                pnlWidth = tabMain.Width - 48

                gridBilling.Visible = False
                ReDim cBill(dt.Rows.Count)

                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To dt.Rows.Count - 1
                    r = dt.Rows(x)
                    If r("ReflowTypeID") <> 4 Then
                        cBill(x) = New System.Windows.Forms.Button()
                        With cBill(x)
                            .Text = r("BillCode_DESC")
                            .Size = New Size(btnWidth, btnHeight)

                            colCount += 1
                            .Location = New Point(btnLeft, btnTop)
                            .Visible = True

                            .Tag = r("BillCode_ID")
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                            AddHandler .Click, AddressOf Me.billingClick
                        End With

                        If colCount > colLength Then
                            btnLeft = btnLeft + btnWidth + 5
                            btnTop = vBuffer
                            colCount = 0
                        Else
                            btnTop = btnTop + btnHeight + 5
                        End If
                    End If
                Next x

                Me.pnlRVParts.Controls.AddRange(cBill)

                Return booResult
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateRVBillingButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                r = Nothing : drNewRow = Nothing
                cBill = Nothing
                If Not IsNothing(myBillColumn) Then
                    myBillColumn.Dispose() : myBillColumn = Nothing
                End If
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                PSS.Data.Buisness.Generic.DisposeDT(dtReflow)
            End Try
        End Function

        '*****************************************************************
        Private Function CreateAccessoryButtons() As Boolean
            Dim booResult As Boolean = True
            Dim R1, drAccessories() As DataRow
            Dim colLength As Integer = 6
            Dim cBill() As Button
            Dim i As Integer = 0

            Try
                drAccessories = Me._device.BillableBillcodes.Select("BillType_ID = 3")

                '****************************************
                'Create consumption buttons
                '****************************************
                colCount = 0
                pnlLeft = Me.pnlAccessories.Left
                pnlWidth = tabMain.Width - 48

                ReDim cBill(drAccessories.Length)

                btnLeft = hBuffer
                btnTop = vBuffer

                For i = 0 To drAccessories.Length - 1
                    R1 = drAccessories(i)
                    cBill(i) = New System.Windows.Forms.Button()
                    With cBill(i)
                        .Text = R1("BillCode_Desc")
                        .Name = R1("PSPrice_Number")
                        .Size = New Size(btnWidth, btnHeight)

                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True

                        .Tag = R1("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        'AddHandler .Click, AddressOf Me.AccessoryClick
                        AddHandler .Click, AddressOf Me.billingClick
                    End With

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next i

                Me.pnlAccessories.Controls.AddRange(cBill)

                '****************************************
                'Create AWAP button
                '****************************************
                colCount = 0
                pnlLeft = Me.pnlNeededAccessories.Left
                pnlWidth = tabMain.Width - 48

                ReDim cBill(drAccessories.Length)

                btnLeft = hBuffer
                btnTop = vBuffer

                For i = 0 To drAccessories.Length - 1
                    R1 = drAccessories(i)
                    cBill(i) = New System.Windows.Forms.Button()
                    With cBill(i)
                        .Text = R1("BillCode_Desc")
                        .Name = R1("PSPrice_Number")
                        .Size = New Size(btnWidth, btnHeight)

                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True
                        .BackColor = Color.LightSteelBlue

                        .Tag = R1("BillCode_ID")
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        'AddHandler .Click, AddressOf Me.AccessoryClick
                        AddHandler .Click, AddressOf Me.billingClick_AWAP
                    End With

                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If
                Next i

                Me.pnlNeededAccessories.Controls.AddRange(cBill)

                '****************************************

                Return booResult
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateAccessoryButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                cBill = Nothing
            End Try
        End Function

#End Region

        '*******************************************************************
        Private Sub txtSerial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            End If
        End Sub

        '*******************************************************************
        Private Sub ProcessSN()
            Dim ProdGrpCheck As New PSS.Data.Buisness.ProdGrpCheck()
            Dim objPretest As PSS.Data.Buisness.PreTest
            Dim val As Long = 0
            Dim bIsGSdevice, booCorrectStation As Boolean
            Dim strGSLotNum As String
            Dim strOriginalDeviceSN As String
            Dim dtPretestData As DataTable
            Dim strDevCurrWrkStation As String = ""
            Dim iDeviceCCID, iMachineCCID As Integer

            Try
                If PSS.Data.Buisness.Generic.GetMachineCostCenterID() = 0 Then
                    MessageBox.Show("This computer does not map to any cost center. Please contact your supervisor for advises.", "Computer Mapping", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                booCorrectStation = False
                '******************************
                'Clear controls and variables
                '******************************
                strOriginalDeviceSN = Me.txtSerial.Text.Trim.ToUpper
                ButtonClear_ClickEvent()
                Me.txtSerial.Text = strOriginalDeviceSN
                '******************************

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                txtSerial.Text = txtSerial.Text.Trim.ToUpper  '//Format serial as all uppercase
                val = Me.verifySerialNumber(txtSerial.Text)

                If val = 0 Then
                    MessageBox.Show("SN/IMEI does not exist in the system or already has a pallet assigned to it.", "information", MessageBoxButtons.OK)
                    Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                ElseIf val = 2 Then
                    MessageBox.Show("SN/IMEI existed more than one in the system. Please contact your lead or supervisor.", "information", MessageBoxButtons.OK)
                    Me.txtSerial.Text = ""
                    Me.txtSerial.Focus()
                Else
                    Me.tmpDeviceID = val

                    '******************************************************************
                    ' Added by Yuri on 21-Jun-2007.
                    ' Check ProdGrp_ID for NULL value.
                    If Not ProdGrpCheck.CheckProdGrpID(strOriginalDeviceSN) Then Exit Sub
                    '******************************************************************

                    If retreiveData() = False Then Exit Sub

                    '*************************************
                    'Added by Lan on 11/14/2007
                    'Device must be pretest before refurbish. ATCLE and SYX Customer only
                    '*************************************
                    If Me.tmpDeviceID > 0 Then
                        'objPretest = New PSS.Data.Buisness.PreTest()
                        'dtPretestData = objPretest.GetPretestStatus_ByDeviceID(Me.tmpDeviceID)
                        'If dtPretestData.Rows.Count = 0 Then
                        '    MessageBox.Show("Please pretest/Triage device.", "PreTest Validation", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Me.ButtonClear_ClickEvent() : Me.txtSerial.SelectAll() : Me.txtSerial.Focus() : Exit Sub
                        'End If

                        ''****************************************************
                        ''Validate screen name and device workstation
                        ''****************************************************
                        'strDevCurrWrkStation = PSS.Data.Buisness.Generic.GetDeviceCurrentWorkStation(Me.tmpDeviceID).Trim.ToUpper
                        'If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, strDevCurrWrkStation, Me.tmpCustID, 0) = False Then
                        '    Me.ButtonClear_ClickEvent()
                        '    Me.txtSerial.SelectAll()
                        '    Me.txtSerial.Focus()
                        '    Exit Sub
                        'End If

                        '****************************************************
                        'Validate cost center
                        '****************************************************

                        iDeviceCCID = PSS.Data.Buisness.Generic.GetCostCenterIDOfDevice(Me.tmpDeviceID)
                        iMachineCCID = PSS.Data.Buisness.Generic.GetMachineCostCenterID()
                        'If iDeviceCCID = 0 Then
                        '    MessageBox.Show("This Device has not received into cell.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.ButtonClear_ClickEvent()
                        '    Me.txtSerial.SelectAll()
                        '    Me.txtSerial.Focus()
                        '    Exit Sub
                        'elseIf PSS.Data.Buisness.Generic.GetNextSeqNoInTtestdata(tmpDeviceID, 7) > 1 Then
                        ''//This is rework unit. Don't validate cost center
                        'ElseIf IsNothing(Me._drCelloptData) = True AndAlso PSS.Data.Buisness.Generic.GetNextSeqNoInTtestdata(tmpDeviceID, 7) = 1 AndAlso iDeviceCCID <> iMachineCCID Then
                        '    MessageBox.Show("This Device does not belong to your cell. Please receive into your cell.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.ButtonClear_ClickEvent()
                        '    Me.txtSerial.SelectAll()
                        '    Me.txtSerial.Focus()
                        '    Exit Sub
                        'ElseIf Not IsNothing(Me._drCelloptData) AndAlso CInt(Me._drCelloptData("CellOpt_QCReject")) = 0 AndAlso iDeviceCCID <> iMachineCCID Then
                        '    MessageBox.Show("This Device belongs to cell " & PSS.Data.Buisness.Generic.GetCostCenterDescOfDevice(Me.tmpDeviceID) & "." & Environment.NewLine & "Please send it to the right work station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    Me.ButtonClear_ClickEvent()
                        '    Me.txtSerial.SelectAll()
                        '    Me.txtSerial.Focus()
                        '    Exit Sub
                        '    'ElseIf Not IsNothing(Me._drCelloptData) AndAlso CInt(Me._drCelloptData("CellOpt_QCReject")) = 0 AndAlso Not IsDBNull(Me._drCelloptData("User_Fullname")) AndAlso CInt(Me._drCelloptData("CellOpt_TechAssigned")) <> PSS.Core.ApplicationUser.IDuser Then
                        '    '    MessageBox.Show("This Device belongs to technician " & Me._drCelloptData("User_Fullname") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '    '    Me.ButtonClear_ClickEvent()
                        '    '    Me.txtSerial.SelectAll()
                        '    '    Me.txtSerial.Focus()
                        '    '    Exit Sub
                        'End If

                        '***********************************************
                        Me.txtSerial.Enabled = False
                        loadTestResults()
                        '***********************************************
                    End If 'Device ID > 0
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SN KeyDownEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.ButtonClear_ClickEvent()
            Finally
                Cursor.Current = Cursors.Default : Me.Enabled = True
                ProdGrpCheck = Nothing : objPretest = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dtPretestData)
            End Try
        End Sub

        '*******************************************************************
        Private Function verifySerialNumber(ByVal mDeviceSN As String) As Long
            Dim dt As DataTable
            Try
                dt = Me._objNewTech.GetDeviceInWip(mDeviceSN, Me._iSCustID)
                If dt.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf dt.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    Return dt.Rows(0)("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            Finally
                Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*******************************************************************
        Private Function retreiveData() As Boolean
            Dim xr As DataRow
            Dim blnNER As Boolean = False
            Dim iWC_ActiveConsume As Integer = 0
            Dim booReturnVal As Boolean = False

            Try
                If Not IsNothing(Me._device) Then Me._device = Nothing

                If getData() = False Then Return False

                If Me.tmpDeviceID > 0 And Me.tmpCustID > 0 Then
                    Me.PopulateBillingSelectionGrid(Me.tmpDeviceID, Me.tmpCustID)
                End If

                'get machine group
                Me._iMachineGrpID = Me._objNewTech.GetGroupID(System.Net.Dns.GetHostName)

                If Me.tmpDeviceID > 0 Then
                    _drCelloptData = Me._objNewTech.GetCellOptAndTechData(Me.tmpDeviceID)
                    '//Identify status of device
                    If Not IsNothing(_drCelloptData) Then
                        Me._iDeviceWipOwner = _drCelloptData("cellopt_WipOwner")
                        If Not IsDBNull(_drCelloptData("Workstation")) Then Me.lblWipLoc.Text = _drCelloptData("Workstation") Else Me.lblWipLoc.Text = ""
                        If _drCelloptData("WIL_SDESC").ToString.Trim.Length > 0 Then Me.lblWipLoc.Text &= " - " & _drCelloptData("WIL_SDESC").ToString.Trim

                        '******************************************
                        'Validate current location
                        '******************************************
                        If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, _drCelloptData("Workstation").ToString.Trim, Me.tmpCustID, 0, True) = False Then
                            Me.btnClear_Click(Nothing, Nothing)
                        End If
                        '******************************************
                    End If
                End If

                '//****************************************************************
                Me.LoadDevice()
                loadBillCodes()
                loadServiceCodes()
                CreateRVBillCodesButtons()
                Me.CreateAccessoryButtons()

                populateParts()

                Return True
            Catch ex As Exception
                Throw ex
            Finally
                xr = Nothing
            End Try
        End Function

        '***************************************************************************************************
        Private Function getData() As Boolean
            Dim booResult As Boolean = True
            Dim xCount As Integer
            Dim r As DataRow
            Dim dt, dtSyxData As DataTable

            Try
                tmpModelID = 0 : tmpManufID = 0 : tmpProdID = 0 : tmpWO = 0 : tmpCustID = 0

                tmpCustCRbill = 0 : tmpDeviceType = 0 : vManufWrty = 0 : _iPSSWrty = 0
                tmpConsignedParts = 0
                _dtAWAP = New DataTable()

                If Me.tmpDeviceID = 0 Then Throw New Exception("Device ID is missing.")

                dt = Me._objNewTech.GetDeviceInfo(Me.tmpDeviceID)
                If dt.Rows.Count = 0 Then
                    Throw New Exception("Can't define device's model.")
                ElseIf dt.Rows.Count > 1 Then
                    Throw New Exception("Device ID existed more than one in the system.")
                Else
                    tmpModelID = dt.Rows(0)("Model_ID")
                    tmpManufID = dt.Rows(0)("Manuf_ID")
                    tmpProdID = dt.Rows(0)("Prod_ID")
                    tmpWO = dt.Rows(0)("WO_ID")
                    tmpLoc = dt.Rows(0)("Loc_ID")
                    tmpCustID = dt.Rows(0)("Cust_ID")
                    tmpCustCRbill = dt.Rows(0)("Cust_CRBilling")
                    vManufWrty = dt.Rows(0)("Device_ManufWrty")
                    tmpConsignedParts = dt.Rows(0)("cust_consignedparts")
                    _iPSSWrty = dt.Rows(0)("Device_PSSWrty")
                    Me.lblModel.Text = dt.Rows(0)("Model_Desc")
                    Me.lblManufModelNumber.Text = dt.Rows(0)("ManufModelNumber")

                    If tmpDeviceID = 0 Or tmpModelID = 0 Or tmpManufID = 0 Then
                        Throw New Exception("Can not define Device ID/ Model ID/ Manufacturer ID of this device.")
                    End If

                    If vManufWrty = 1 Then Me.lblWarrantyStatus.Text = "IW" Else Me.lblWarrantyStatus.Text = "OW"
                    Me.lblWarrantyStatus.Visible = True

                    dtSyxData = Me._objNewTech.GetSyxDeviceInfo(tmpDeviceID)
                    If dtSyxData.Rows.Count > 0 Then Me.lblManufSN.Text = dtSyxData.Rows(0)("Manuf_SN")

                    createCustDataTable(tmpCustID, tmpModelID)
                    _dtAWAP = Me._objNewTech.GetSelectedAWAP(tmpDeviceID)
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt) : PSS.Data.Buisness.Generic.DisposeDT(dtSyxData)
            End Try
        End Function

        '*********************************************************************************************
        Private Sub LoadDevice()
            Try
                _device = Nothing
                _device = New Device(Me.tmpDeviceID)
                _device.ScreenID = Me._iScreenID
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub loadBillCodes()
            Dim mthd As New PSS.Data.Production.Joins()
            Dim mthdGrp As DataTable
            Dim mthdScrap As DataTable
            Dim objBD As Buisness.Billing.BillingData
            Dim dtFuncParts As DataTable

            Try
                If tmpConsignedParts = 1 Then
                    'mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=1 ORDER BY BillCode_Desc")
                    mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_consignedpart=1 AND tpsmap.Inactive = 0 ORDER BY BillCode_Desc")
                Else
                    objBD = New Buisness.Billing.BillingData()
                    mthdGrp = objBD.GetPartBillcodes(tmpCustID, tmpModelID, 5, , 0)
                End If

                '//New code to get scrap button datatable
                mthdScrap = mthd.OrderEntrySelect("SELECT lbillcodes.*, lpsprice.psprice_number, lpsprice.PSPrice_ConsignedPart FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 2 AND lpsprice.psprice_flgCountScrap = 1 AND tpsmap.Inactive = 0 ORDER BY lpsprice.psprice_ordergroup desc, BillCode_Desc asc")
                '//New code to get scrap button datatable

                createBillingButtons(mthdGrp)
                System.Windows.Forms.Application.DoEvents()
                createScrapButtons(mthdScrap)
                System.Windows.Forms.Application.DoEvents()

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objBD) Then objBD = Nothing
                Buisness.Generic.DisposeDT(mthdGrp)
                Buisness.Generic.DisposeDT(mthdScrap)
            End Try
        End Sub

        '******************************************************************
        Private Sub loadServiceCodes()
            Dim mthd As New PSS.Data.Production.Joins()
            'Dim mthdGrp As DataTable = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM ((lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id)INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id) WHERE tpsmap.model_id = " & tmpModelID & " AND billtype_id = 1 AND lbillcodes.billcode_id <> 278 ORDER BY BillCode_Desc")
            Dim mthdGrp As DataTable

            Try
                'February 26, 2007
                '//This new code allows for the inclusion of a table which will allow for the 
                '//hiding of specific billcodes on models for specific customers.
                mthdGrp = mthd.GenericSelect("SELECT lbillcodes.*, lpsprice.psprice_number FROM " & _
                "lbillcodes INNER JOIN tpsmap ON lbillcodes.billcode_id = tpsmap.billcode_id " & _
                "INNER JOIN lpsprice ON tpsmap.psprice_id = lpsprice.psprice_id " & _
                "LEFT OUTER JOIN tbilldisplayexceptions ON tpsmap.model_id = tbilldisplayexceptions.model_id AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id " & _
                "AND tbilldisplayexceptions.cust_id = " & tmpCustID & " " & _
                "WHERE tpsmap.model_id = " & tmpModelID & " " & _
                " AND billtype_id = 1 " & _
                "AND lpsprice.psprice_consignedpart = 0 " & _
                "AND tpsmap.Inactive = 0 " & _
                "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & tmpCustID & ") " & _
                "AND (tbilldisplayexceptions.display_type is null or tbilldisplayexceptions.tech = 0) " & _
                "ORDER BY BillCode_Desc")
                '//End of new code segment
                'February 26, 2007

                createServiceButtons(mthdGrp)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "loadServiceCodes", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                mthd = Nothing
                If Not IsNothing(mthdGrp) Then
                    mthdGrp.Dispose()
                    mthdGrp = Nothing
                End If
            End Try
        End Sub

        '******************************************************************
        Private Sub populateParts()
            Dim x As Integer = 0
            Dim R1 As DataRow
            Dim tmpBtn As Button

            Try
                'Highlight button that are selected
                For Each R1 In Me._device.Parts.Rows
                    'Bill panel
                    For x = 0 To pnlBill.Controls.Count - 1
                        tmpBtn = CType(pnlBill.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    'Service panel
                    For x = 0 To pnlService.Controls.Count - 1
                        tmpBtn = CType(pnlService.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    'RV part panel
                    For x = 0 To Me.pnlRVParts.Controls.Count - 1
                        tmpBtn = CType(pnlRVParts.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    'Accessories panel
                    For x = 0 To Me.pnlAccessories.Controls.Count - 1
                        tmpBtn = CType(pnlAccessories.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                Next R1

                'Highlight needed parts
                For Each R1 In Me._dtAWAP.Rows
                    For x = 0 To Me.pnlNeededParts.Controls.Count - 1
                        tmpBtn = CType(pnlNeededParts.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x

                    For x = 0 To Me.pnlNeededAccessories.Controls.Count - 1
                        tmpBtn = CType(pnlNeededAccessories.Controls(x), System.Windows.Forms.Button)
                        If R1("BillCode_ID") = tmpBtn.Tag Then
                            tmpBtn.ForeColor = Color.Blue : Exit For
                        End If
                    Next x
                Next R1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Sub

        '*******************************************************************
        Private Sub PopulateBillingSelectionGrid(ByVal iDeviceID As Integer, ByVal iCustID As Integer)
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                If iDeviceID = 0 Or iCustID = 0 Then
                    Me.gridBilling.DataSource = Nothing
                    Me.gridBilling.Visible = False
                Else
                    If iCustID = 2258 Then dt = Me._objNewTech.GetBillingSelectionInformation(iDeviceID, iCustID, True) Else dt = Me._objNewTech.GetBillingSelectionInformation(iDeviceID, iCustID, )

                    With Me.gridBilling
                        .DataSource = Nothing
                        .DataSource = dt.DefaultView
                        .Visible = True

                        .Splits(0).Style.WrapText = True
                        .FilterBar = True
                        .RowHeight = 28
                        .AlternatingRows = True

                        For i = 0 To .Columns.Count - 1
                            .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        Next i

                        .Splits(0).DisplayColumns("Complain Description").Width = 120
                        .Splits(0).DisplayColumns("Main Category").Width = 100
                        .Splits(0).DisplayColumns("Fail Code").Width = 120

                        .Splits(0).DisplayColumns("Fail At").Width = 80
                        .Splits(0).DisplayColumns("Failed Inspector").Width = 80
                        .Splits(0).DisplayColumns("Repair Code").Width = 120
                        .Splits(0).DisplayColumns("Part Desc").Width = 65
                        .Splits(0).DisplayColumns("Part Number").Width = 70
                        .Splits(0).DisplayColumns("Part SN").Width = 65
                        .Splits(0).DisplayColumns("Part IMEI").Width = 65
                        .Splits(0).DisplayColumns("Tech").Width = 100
                        .Splits(0).DisplayColumns("Completed").Width = 62
                        .Splits(0).DisplayColumns("Completed Tech").Width = 80
                        .Splits(0).DisplayColumns("Completed Date").Width = 100
                        .Splits(0).DisplayColumns("Seq").Width = 40

                        .Columns("Completed Date").NumberFormat = "MM/dd/yyyy hh:mm tt"

                        If iCustID <> PSS.Data.Buisness.HTC.HTC_CUSTOMER_ID Then
                            .Splits(0).DisplayColumns("Complain Description").Visible = False
                            .Splits(0).DisplayColumns("Main Category").Visible = False
                            .Splits(0).DisplayColumns("Completed").Visible = False
                            .Splits(0).DisplayColumns("Part SN").Visible = False
                            .Splits(0).DisplayColumns("Part IMEI").Visible = False
                            .Splits(0).DisplayColumns("Completed Date").Visible = False
                            .Splits(0).DisplayColumns("Seq").Visible = False
                            .Splits(0).DisplayColumns("Fail At").Visible = False
                        End If

                        .Splits(0).DisplayColumns("BillCode_ID").Visible = False
                        .Splits(0).DisplayColumns("Fail_ID").Visible = False
                        .Splits(0).DisplayColumns("Repair_ID").Visible = False
                        .Splits(0).DisplayColumns("MC_ID").Visible = False
                        .Splits(0).DisplayColumns("RI_ID").Visible = False
                        .Splits(0).DisplayColumns("Device_ID").Visible = False
                        .Splits(0).DisplayColumns("FailDetails").Visible = False
                        .Splits(0).DisplayColumns("PSPrice_ID").Visible = False
                    End With
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '*******************************************************************
        Private Sub ScrapClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim i As Integer = 0
            Dim objScrap As New PSS.Data.Buisness.ScrapParts()
            Dim iEmpNo As Integer = PSS.Core.Global.ApplicationUser.NumberEmp
            Dim strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
            Dim iBillcode_ID As Integer = 0
            Dim DlgRslt As DialogResult
            Dim iCount As Integer = 0
            Dim stroldText As String = Trim(sender.text.ToString)
            Dim strnewText As String = ""

            If Trim(sender.tag.ToString) <> "" Then
                iBillcode_ID = CInt(Trim(sender.tag.ToString))
            Else
                Throw New Exception("BillcodeID could not be determined.")
            End If

            Try
                '*********************
                DlgRslt = MessageBox.Show("To Scrap: Click 'YES'." & Environment.NewLine & "To Unscrap: Click 'NO'." & Environment.NewLine & "To Cancel without changing anything: Click 'CANCEL'.", "Add to Scrap or Remove from Scrap", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)

                Select Case DlgRslt
                    Case DialogResult.Yes
                        iCount = 1
                    Case DialogResult.No
                        iCount = -1
                    Case DialogResult.Cancel
                        iCount = 0
                        Exit Sub
                    Case Else
                        Throw New Exception("Unable to determine if the part is being scrapped or removed from the scrap.")
                End Select
                '*********************
                i = objScrap.ScrapParts(tmpDeviceID, tmpModelID, iBillcode_ID, tmpProdID, iEmpNo, strWorkDate, iCount, PSS.Core.ApplicationUser.IDuser)
                '*********************
                If i > 0 Then
                    iCount = objScrap.GetScrapCount(tmpDeviceID, tmpModelID, iBillcode_ID)
                    strnewText = Mid(stroldText, 1, InStr(stroldText, "(") - 1) & "(" & iCount & ")"
                    sender.text = strnewText
                    If iCount > 0 Then
                        sender.backcolor = Color.LightGreen
                        sender.forecolor = Color.Black
                    Else
                        sender.backcolor = Color.LightCoral
                        sender.forecolor = Color.Black
                    End If
                End If
                '*********************

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Scrap Part Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objScrap = Nothing
            End Try
        End Sub

        '********************************************************************************
        Private Sub billingClick(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim iFailID, iRepairID, iComplainID, iRVPart, iConsignedPart As Integer
            Dim dr1, drAddingBillcode As DataRow
            Dim x As Integer
            Dim action As String
            Dim strAddPartNo, strBilledPartNo As String
            Dim dtContingent As DataTable
            Dim booIsRVPart As Boolean = False

            Try
                strAddPartNo = "" : strBilledPartNo = "" : iFailID = 0 : iRepairID = 0 : iComplainID = 0 : iRVPart = 0 : iConsignedPart = 0

                '//Determine action to be performed
                action = "add"
                If Me._device.Parts.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then action = "remove"

                '*********************************
                'Define Adding Part #
                '*********************************
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length = 0 Then
                    MessageBox.Show("Billcode ID is missing in billable list. Please refresh the screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    strAddPartNo = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_Number").ToString.ToLower
                    iRVPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("RVFlag")
                    If iRVPart = 1 Then booIsRVPart = True
                    iConsignedPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_ConsignedPart")
                End If

                'If action = "add" AndAlso strAddPartNo.Trim.ToLower <> "temppart" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillType_ID") = 2 Then
                '    'Technician has to confirm corret part # in BOM
                '    If MessageBox.Show("Please confirm the following part number is correct by click on OK otherwise click Cancel and contact your suppervisor. " & Environment.NewLine & strAddPartNo, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then Exit Sub
                'End If

                'Must remove all needed part before scrap 
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillCode_Rule") <> 0 AndAlso Me._dtAWAP.Rows.Count > 0 Then
                    MessageBox.Show("Please remove all need part(s) before select this bill code " & sender.text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                '*********************************
                If action = "add" AndAlso Me.ValidateRVOEMAndConsighnedPartSelection(strAddPartNo, CInt(Trim(sender.tag.ToString)), iRVPart, iConsignedPart) = False Then
                    '***************************************************
                    'RV, EOM and Consigned Parts validation 05/05/2011
                    '***************************************************
                    Exit Sub
                End If

                '*************************************************
                'Get Failcode and Repair code for warranty device
                '*************************************************
                If action = "add" AndAlso Me.vManufWrty = 1 AndAlso Me._device.ManufWarantyClaimable = 1 AndAlso (Me._iPSSWrty = 0 Or (Me._iPSSWrty = 1 AndAlso Me._device.PSSWarrantyID <> 2)) Then
                    Dim iPartRepLevel As Integer = Me._device.GetPartRepairLevel(CInt(sender.tag.ToString))
                    If (Me.tmpManufID <> 64 AndAlso iPartRepLevel > 1) OrElse (Me.tmpManufID = 64 AndAlso iPartRepLevel > 2) Then
                        'Get Fail and Repair code if existing in map table
                        If Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then
                            If Not IsDBNull(Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")) Then iFailID = Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")
                            If Not IsDBNull(Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Repair_ID")) Then iRepairID = Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Repair_ID")
                        End If

                        If iFailID = 0 AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then iFailID = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")

                        'collect Fail and Repair code
                        If iFailID = 0 Or (iRepairID = 0 AndAlso iFailID <> 311) Then If Me.CollectFailRepairCode(iFailID, iRepairID, iComplainID, sender.parent.name.ToString, CInt(sender.tag.ToString), iConsignedPart) = False Then Exit Sub

                        Me._device.FailID = iFailID
                        Me._device.RepairID = iRepairID
                        Me._device.ComplainID = iComplainID
                    End If
                    '*******************************************
                End If

                ''**********************************************
                ''Max cap($ ) :WILL IMPLEMENT THIS IN FUTURE
                ''**********************************************
                'If action = "add" Then
                '    If Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then drAddingBillcode = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0) Else Throw New Exception("Billcode ID is missing in billable table.")
                '    Dim dbTotalPartsCharge As Double = 0
                '    If Not IsDBNull(Me._device.Parts.Compute("Sum(DBill_InvoiceAmt)", "")) Then dbTotalPartsCharge = Me._device.Parts.Compute("Sum(DBill_InvoiceAmt)", "")
                '    dbTotalPartsCharge = dbTotalPartsCharge + (Convert.ToDouble(drAddingBillcode("PSPrice_StndCost")) * (Convert.ToDouble(Me._device.CustMarkUp) + 1))
                '    If dbTotalPartsCharge > 85 Then
                '        MessageBox.Show("Parts cost has exceed the maximum limit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                '        Exit Sub
                '    End If
                'End If

                '***************************************************
                'Syx: Collect real part and repalce with temporay part
                '***************************************************
                If action = "add" AndAlso (strAddPartNo.Trim.ToLower.Equals("temppart") = True OrElse strAddPartNo.Trim.ToLower.Equals("temppart_rv") = True) AndAlso Me.CollectPartAndReplaceTempPartInBOM(sender.tag.ToString.Trim, booIsRVPart) = False Then
                    Exit Sub
                End If
                '***************************************************
                'Syx: Collect manuf model number
                '***************************************************
                If action = "add" AndAlso Me.CollectManufModelNumber(sender.tag.ToString.Trim) = False Then Exit Sub
                '***************************************************

                '//March 24, 2006
                Me.Enabled = False

                dtContingent = Me._objNewTech.GetContingentBillcodes(Trim(sender.tag.ToString), tmpModelID, tmpLoc)
                If action = "remove" Then   '//turn off
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, dr1("cbill_contBillcode")) Then Me._device.DeletePart(dr1("cbill_contBillcode"))
                    Next dr1

                    deleteComponent(Trim(sender.tag.ToString))
                Else    '//turn on
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeMapped(tmpModelID, dr1("cbill_contBillcode")) > 0 AndAlso PSS.Data.Buisness.Generic.IsBillcodeExisted(Me.tmpDeviceID, dr1("cbill_contBillcode")) = False Then Me._device.AddPart(dr1("cbill_contBillcode"))
                    Next dr1
                    addComponent(Trim(sender.tag.ToString))
                End If

                '*******************************
                Me.HighLightSelectedButtons()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "BillingButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                dr1 = Nothing : Buisness.Generic.DisposeDT(dtContingent)
                '********************************
                'Reset fail and repair code ID
                '********************************
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                '********************************
            End Try
        End Sub

        '********************************************************************************
        Public Function CollectManufModelNumber(ByVal iBillcodeID As Integer) As Boolean
            Dim strManufModel As String = ""
            Dim i As Integer = 0

            Try
                If Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID).Length > 0 Then
                    If Me.lblManufModelNumber.Text.Trim = "" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID)(0)("BillType_ID") = 2 Then
                        strManufModel = InputBox("Manufacture Model:", "Get Manuf Model").Trim
                        If strManufModel.Trim.Length = 0 Then
                            Return False
                        Else
                            i = Me._objNewTech.UpdateManufModel(Me.tmpModelID, strManufModel)
                            If i > 0 Then Return True Else  : Return False
                        End If
                    Else
                        Return True
                    End If
                Else
                    Throw New Exception("Bill code does not exist in billable list.")
                End If
            Catch ex As Exception
                CollectManufModelNumber = False
                Throw ex
            End Try
        End Function

        '********************************************************************************
        Private Sub billingClick_AWAP(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim iFailID, iRepairID, iComplainID, iRVPart, iConsignedPart As Integer
            Dim dr1, drAddingBillcode As DataRow
            Dim x As Integer
            Dim action As String
            Dim strAddPartNo, strBilledPartNo As String
            Dim dtContingent As DataTable
            Dim booRVPart As Boolean = False

            Try
                strAddPartNo = "" : strBilledPartNo = "" : iFailID = 0 : iRepairID = 0 : iComplainID = 0 : iRVPart = 0 : iConsignedPart = 0

                '//Determine action to be performed
                action = "add"
                If Me._dtAWAP.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then action = "remove"

                '*********************************
                'Define Adding Part #
                '*********************************
                If action = "add" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length = 0 Then
                    MessageBox.Show("Billcode ID is missing in billable list. Please refresh the screen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                Else
                    strAddPartNo = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_Number").ToString.ToLower
                    iRVPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("RVFlag")
                    If iRVPart = 1 Then booRVPart = True
                    iConsignedPart = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_ConsignedPart")
                End If

                If iRVPart > 0 Then
                    MessageBox.Show("RV part should not listed in this tab. Please contact your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                ElseIf iConsignedPart > 0 Then
                    MessageBox.Show("Consigned part should not listed in this tab. Please contact your suppervisor.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                'If Me.tmpCustID = PSS.Data.Buisness.Syx.CUSTOMERID AndAlso action = "add" AndAlso strAddPartNo.Trim.ToLower <> "temppart" AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillType_ID") = 2 Then
                '    'Technician has to confirm corret part # in BOM
                '    If MessageBox.Show("Please confirm the following part number is correct by click on OK otherwise click Cancel and contact your suppervisor. " & Environment.NewLine & strAddPartNo, "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Cancel Then Exit Sub
                'End If

                '*********************************
                If action = "add" AndAlso Me.ValidateRVOEMAndConsighnedPartSelection(strAddPartNo, CInt(Trim(sender.tag.ToString)), iRVPart, iConsignedPart) = False Then
                    '***************************************************
                    'RV, EOM and Consigned Parts validation 05/05/2011
                    '***************************************************
                    Exit Sub
                End If

                '*************************************************
                'Get Failcode and Repair code for warranty device
                '*************************************************
                If action = "add" AndAlso Me.vManufWrty = 1 AndAlso Me._device.ManufWarantyClaimable = 1 AndAlso (Me._iPSSWrty = 0 Or (Me._iPSSWrty = 1 AndAlso Me._device.PSSWarrantyID <> 2)) Then
                    Dim iPartRepLevel As Integer = Me._device.GetPartRepairLevel(CInt(sender.tag.ToString))
                    If (Me.tmpManufID <> 64 AndAlso iPartRepLevel > 1) OrElse (Me.tmpManufID = 64 AndAlso iPartRepLevel > 2) Then
                        'Get Fail and Repair code if existing in map table
                        If Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then
                            If Not IsDBNull(Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")) Then iFailID = Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")
                            If Not IsDBNull(Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Repair_ID")) Then iRepairID = Me.dtCustomerSet.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Repair_ID")
                        End If

                        If iFailID = 0 AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString)).Length > 0 Then iFailID = Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("Fail_ID")

                        'For Tracfone, Authorize to claim and part level > 1 then Set RV part to Abuse
                        If Me.tmpCustID = 2258 AndAlso Me._device.ManufWarantyClaimable = 1 And Me._device.GetPartRepairLevel(CInt(sender.tag.ToString)) > 1 AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)("PSPrice_Number").ToString.Trim.ToLower.EndsWith("_rv") Then iFailID = 311

                        'collect Fail and Repair code
                        If iFailID = 0 Or (iRepairID = 0 AndAlso iFailID <> 311) Then If Me.CollectFailRepairCode(iFailID, iRepairID, iComplainID, sender.parent.name.ToString, CInt(sender.tag.ToString), iConsignedPart) = False Then Exit Sub

                        Me._device.FailID = iFailID
                        Me._device.RepairID = iRepairID
                        Me._device.ComplainID = iComplainID
                    ElseIf Me.tmpManufID = 64 Then 'PANTECH
                        If CInt(sender.tag.ToString) = 267 Then 'RUR - Liquid Damage
                            Me._device.FailID = 550 : Me._device.RepairID = 146 : Me._device.ComplainID = 205
                        ElseIf CInt(sender.tag.ToString) = 276 Then 'RUR - Physical Damage
                            Me._device.FailID = 549 : Me._device.RepairID = 145 : Me._device.ComplainID = 188
                        ElseIf CInt(sender.tag.ToString) = 255 Then 'No Parts
                            Me._device.FailID = 551 : Me._device.RepairID = 150 : Me._device.ComplainID = 198
                        ElseIf iPartRepLevel < 3 AndAlso Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)("BillType_ID") = 2 Then 'Cosmetic parts 
                            Me._device.FailID = 526 : Me._device.RepairID = 138 : Me._device.ComplainID = 11
                        End If
                    End If
                    '*******************************************
                End If

                '***************************************************
                'Syx: Collect real part and repalce with temporay part
                '***************************************************
                If action = "add" AndAlso (strAddPartNo.Trim.ToLower.Equals("temppart") = True OrElse strAddPartNo.Trim.ToLower.Equals("temppart_rv") = True) AndAlso Me.CollectPartAndReplaceTempPartInBOM(sender.tag.ToString.Trim, booRVPart) = False Then
                    Exit Sub
                End If
                '***************************************************
                'Syx: Collect manuf model number
                '***************************************************
                If action = "add" AndAlso Me.CollectManufModelNumber(sender.tag.ToString.Trim) = False Then Exit Sub
                '***************************************************

                '//March 24, 2006
                Me.Enabled = False

                dtContingent = Me._objNewTech.GetContingentBillcodes(Trim(sender.tag.ToString), tmpModelID, tmpLoc)
                If action = "remove" Then   '//turn off
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeExistedInAWAP(Me.tmpDeviceID, dr1("cbill_contBillcode")) Then
                            Me._objNewTech.DeleteDeviceBillAWAP(Me.tmpDeviceID, dr1("cbill_contBillcode"), Core.ApplicationUser.IDuser)
                        End If
                    Next dr1

                    Me._objNewTech.DeleteDeviceBillAWAP(Me.tmpDeviceID, Trim(sender.tag.ToString), Core.ApplicationUser.IDuser)
                Else    '//turn on
                    Dim R1 As DataRow
                    '**************************************
                    'Contigent
                    '**************************************
                    For Each dr1 In dtContingent.Rows
                        If PSS.Data.Buisness.Generic.IsBillcodeMapped(tmpModelID, dr1("cbill_contBillcode")) > 0 AndAlso PSS.Data.Buisness.Generic.IsBillcodeExistedInAWAP(Me.tmpDeviceID, dr1("cbill_contBillcode")) = False Then
                            If Me._device.BillableBillcodes.Select("Billcode_ID = " & dr1("cbill_contBillcode")).Length > 0 Then
                                R1 = Me._device.BillableBillcodes.Select(dr1("cbill_contBillcode"))(0)

                                Me._objNewTech.InsertIntoDeviceBillAWAP(Me.tmpDeviceID, R1("PSPrice_StndCost"), R1("PSPrice_AvgCost"), _
                                R1("PSPrice_StndCost"), (R1("PSPrice_StndCost") * 1.15), R1("Billcode_ID"), R1("PSPrice_Number"), _
                                1, Core.ApplicationUser.IDuser, Me._iFailID, Me._iRepairID, 0)
                            End If
                        End If
                    Next dr1
                    '**************************************
                    R1 = Me._device.BillableBillcodes.Select("Billcode_ID = " & sender.tag.ToString)(0)
                    Me._objNewTech.InsertIntoDeviceBillAWAP(Me.tmpDeviceID, R1("PSPrice_StndCost"), R1("PSPrice_AvgCost"), _
                    R1("PSPrice_StndCost"), (R1("PSPrice_StndCost") * 1.15), R1("Billcode_ID"), R1("PSPrice_Number"), _
                    1, Core.ApplicationUser.IDuser, Me._iFailID, Me._iRepairID, 0)
                End If

                '*******************************
                Me._dtAWAP = Me._objNewTech.GetSelectedAWAP(tmpDeviceID)
                Me.HighLightSelectedButtons()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "billingClick_AWAP", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                dr1 = Nothing : Buisness.Generic.DisposeDT(dtContingent)
                '********************************
                'Reset fail and repair code ID
                '********************************
                If Not IsNothing(Me._device) Then
                    Me._device.FailID = 0 : Me._device.RepairID = 0 : Me._device.ComplainID = 0
                End If
                '********************************
            End Try
        End Sub

        '**************************************************************
        Private Function ValidateRVOEMAndConsighnedPartSelection(ByVal strAddingPartNo As String, _
                                                                 ByVal iBillcodeID As Integer, _
                                                                 ByVal iRVPart As Integer, _
                                                                 ByVal iConsignedPart As Integer) As Boolean
            Dim booReturnVal As Boolean = True
            Dim R1 As DataRow

            Try
                'No need to check if part list is empty or adding part is a services
                If Me._device.Parts.Rows.Count = 0 OrElse Me._device.GetPartTypeID(iBillcodeID) = 1 Then Return True

                ValidateRVOEMAndConsighnedPartSelection = True

                For Each R1 In Me._device.Parts.Rows
                    If iRVPart = 1 AndAlso (R1("Part_Number").ToString.Trim & "_RV").ToUpper.Equals(strAddingPartNo.Trim.ToUpper) Then
                        MessageBox.Show("An OEM part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf iConsignedPart = 1 AndAlso (R1("Part_Number").ToString.Trim & "_TT").ToUpper.Equals(strAddingPartNo.Trim.ToUpper) Then
                        MessageBox.Show("An OEM part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf (strAddingPartNo.Trim & "_RV").ToUpper.Equals(R1("Part_Number").ToString.Trim.ToUpper) Then
                        MessageBox.Show("RV part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    ElseIf (strAddingPartNo.Trim & "_TT").ToUpper.Equals(R1("Part_Number").ToString.Trim.ToUpper) Then
                        MessageBox.Show("Consigned part is already selected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        booReturnVal = False : Exit For
                    End If
                Next R1
                Return booReturnVal
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************
        Private Sub HighLightSelectedButtons()
            Dim i As Integer = 0

            Try
                'Panel Bill
                For i = 0 To Me.pnlBill.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlBill.Controls(i).Tag).Length > 0 Then
                        Me.pnlBill.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlBill.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                'Panel Services
                For i = 0 To Me.pnlService.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlService.Controls(i).Tag).Length > 0 Then
                        Me.pnlService.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlService.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                'pnlRVParts
                For i = 0 To Me.pnlRVParts.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlRVParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlRVParts.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlRVParts.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                'pnlAccessories
                For i = 0 To Me.pnlAccessories.Controls.Count - 1
                    If Me._device.Parts.Select("Billcode_ID = " & Me.pnlAccessories.Controls(i).Tag).Length > 0 Then
                        Me.pnlAccessories.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlAccessories.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                'pnlNeededAccessories
                For i = 0 To Me.pnlNeededAccessories.Controls.Count - 1
                    If Me._dtAWAP.Select("Billcode_ID = " & Me.pnlNeededAccessories.Controls(i).Tag).Length > 0 Then
                        Me.pnlNeededAccessories.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlNeededAccessories.Controls(i).ForeColor = Color.Black
                    End If
                Next i

                'pnlNeededParts
                For i = 0 To Me.pnlNeededParts.Controls.Count - 1
                    If Me._dtAWAP.Select("Billcode_ID = " & Me.pnlNeededParts.Controls(i).Tag).Length > 0 Then
                        Me.pnlNeededParts.Controls(i).ForeColor = Color.Blue
                    Else
                        Me.pnlNeededParts.Controls(i).ForeColor = Color.Black
                    End If
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**************************************************************
        Private Sub frmNewTech_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me._objNewTech = New PSS.Data.Buisness.NewTech()
                origFrmWidth = Me.Width
                txtSerial.Focus()
                Me.lblScreenName.Text = Me._strScreenName

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmNewTech_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub frmNewTech_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize

            colCount = 0

            btnLeft = hBuffer
            btnTop = vBuffer

            formDiffWidth += Me.Width - origFrmWidth

            Dim x As Integer
            Dim tmpBtn As System.Windows.Forms.Button
            For x = 0 To pnlBill.Controls.Count - 1
                tmpBtn = CType(pnlBill.Controls(x), System.Windows.Forms.Button)
                With tmpBtn
                    .Location = New Point(btnLeft, btnTop)
                End With

                colCount += 1
                If colCount > 6 Then
                    'If btnTop + btnHeight + 120 > pnlBill.Height Then
                    btnLeft = btnLeft + btnWidth + 5
                    btnTop = vBuffer
                    colCount = 0
                Else
                    btnTop = btnTop + btnHeight + 5
                End If

            Next

            btnLeft = hBuffer
            btnTop = vBuffer

            For x = 0 To pnlService.Controls.Count - 1
                tmpBtn = CType(pnlService.Controls(x), System.Windows.Forms.Button)
                With tmpBtn
                    .Location = New Point(btnLeft, btnTop)
                End With

                colCount += 1
                If colCount > 6 Then
                    'If btnTop + btnHeight + 120 > pnlService.Height Then
                    btnLeft = btnLeft + btnWidth + 5
                    btnTop = vBuffer
                    colCount = 0
                Else
                    btnTop = btnTop + btnHeight + 5
                End If
            Next
        End Sub

        '*********************************************************************************************
        Private Sub gridBilling_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles gridBilling.RowColChange
        End Sub

        '*********************************************************************************************
        Private Sub addComponent(ByVal valBillCode As Integer)
            Dim iUpdateDBRCode As Integer = 0

            Try
                '*************************************************
                'Get Part Data Information
                '*************************************************
                If valBillCode > 0 Then
                    _device.AddPart(valBillCode)
                    _device.Update()
                End If
                '*************************************************
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub deleteComponent(ByVal valBillCode As Integer)
            Try
                '*************************************************
                '//Added by Asif
                If (tmpCustID = 1 Or tmpCustID = 14) And CInt(Trim(valBillCode)) = 25 Then  'Metrocall DBR devices
                    Dim objDeviceBilling As New PSS.Data.Buisness.DeviceBilling()
                    objDeviceBilling.UnShipMessDBR(tmpDeviceID)
                    objDeviceBilling.DeleteDBRCode(tmpDeviceID)
                    objDeviceBilling = Nothing
                End If

                If valBillCode > 0 Then
                    _device.DeletePart(valBillCode)
                    _device.Update()
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub createCustDataTable(ByVal vCustomer As Integer, ByVal vModel As Integer)
            Try
                If Not IsNothing(Me.dtCustomerSet) Then Me.dtCustomerSet.Clear()
                dtCustomerSet = PSS.Data.Production.tbillmap.GetCustomerSet(vCustomer, vModel)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            '*************************************
            ' Added by Lan on 10/19/2007.
            ' Get Prebill data.
            '*************************************
            Dim iIsDevHaspart As Integer = 0
            Dim booUpdateTechInfo As Boolean = True

            If Trim(Me.txtSerial.Text) <> "" And Me.tmpDeviceID > 0 Then
                Try
                    If Me.tmpCustID <> 2253 AndAlso Not (Me.tmpProdID = 9 AndAlso Me._device.Parts.Select("[Billcode_ID] = 1590").Length > 0) Then
                        If Me.tmpCustID = 2258 Then booUpdateTechInfo = False 'don't update tech data for Tracfone Customer
                        Me._objNewTech.UpdateWipOwnerID(tmpDeviceID, Me.tmpProdID, PSS.Core.ApplicationUser.IDuser, Me._iDeviceWipOwner, booUpdateTechInfo)
                    End If
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "Send Device to WaitingPart", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End Try
            End If
            '*************************************

            Me.ButtonClear_ClickEvent()
            Me.txtSerial.Focus()
        End Sub

        '*********************************************************************************************
        Private Sub ButtonClear_ClickEvent()
            Me.txtSerial.Enabled = True
            Me.pnlBill.BackColor = Me.BackColor
            Me.pnlService.Controls.Clear()
            Me.pnlBill.Controls.Clear()
            Me.pnlScrap.Controls.Clear()
            Me.pnlNeededParts.Controls.Clear()
            Me.pnlNeededAccessories.Controls.Clear()
            Me.pnlRVParts.Controls.Clear()

            Me.pnlAccessories.Controls.Clear()
            txtSerial.Text = ""

            Me.gridBilling.DataSource = Nothing
            Me.gridBilling.Visible = False

            Me.tmpDeviceID = 0 : Me.tmpModelID = 0 : Me.tmpManufID = 0 : Me.tmpProdID = 0
            Me.tmpWO = 0 : Me._iDeviceWipOwner = 0

            '//reset the bill tray feature

            tabMain.Visible = True
            lblSelected.Text = "SHOW SELECTED"
            Me.lblManufSN.Text = "" : Me.lblWipLoc.Text = "" : Me.lblModel.Text = ""

            Me.txtNote.Text = "" : Me.txtTestResult_Triage.Text = "" : Me.lblTestResult_QC.Text = ""
            Me.lblManufModelNumber.Text = ""

            'Clear global variable
            If Not IsNothing(Me._device) Then
                Me._device.Dispose() : Me._device = Nothing
            End If

            'data table
            PSS.Data.Buisness.Generic.DisposeDT(Me.dtCustomerSet)
            PSS.Data.Buisness.Generic.DisposeDT(Me._dtAWAP)

            rPresent = Nothing
            _drPreBillData = Nothing
            _drCelloptData = Nothing

            Me.lblWarrantyStatus.Text = "" : Me.lblWarrantyStatus.Visible = False

            txtSerial.Focus()
        End Sub

        Private Function verifySerialNumberTray(ByVal mDeviceSN As String, ByVal mTray As String) As Long
            Try
                Dim dRec As New PSS.Data.Production.tdevice()
                Dim tRec As DataTable = dRec.GetDataTableBySNTray(mDeviceSN, mTray)
                Dim r As DataRow

                If tRec.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf tRec.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    r = tRec.Rows(0)
                    Return r("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            End Try
        End Function

        '**************************************************************
        Private Function ShowDBRReasonScreen() As Integer
            Dim objDBR As New Billing.frmDBRReason()
            Dim i As Integer = 0
            Try
                With objDBR
                    .CustID = tmpCustID
                    .DeviceID = tmpDeviceID
                    .ShowDialog()
                    'Update the DB with the selected DBR reason
                    If objDBR.DBRCode > 0 Then i = .UPD
                End With

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objDBR) Then
                    objDBR.Dispose() : objDBR = Nothing
                End If
            End Try
        End Function

        '*********************************************************************************************
        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim iTestTypeID As Integer = 7
            Dim iRework As Integer = 1
            Dim objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
            Dim dialogMsg As Windows.Forms.DialogResult
            Dim strFrStation, strToStation As String

            Try
                If Me.txtSerial.Text.Trim.Length = 0 Then
                    Exit Sub
                ElseIf tmpDeviceID = 0 Then
                    MsgBox("This device can not be identified. Can NOT complete.", MsgBoxStyle.Exclamation, "ERROR")
                    Me.txtSerial.SelectAll()
                    Me.txtSerial.Focus()
                    Exit Sub
                    'ElseIf Me._device.Parts.Rows.Count = 0 Then
                    '    MessageBox.Show("Can not complete this unit without billing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtSerial.Focus()
                    '    Exit Sub
                Else
                    Me.pnlBill.BackColor = Me.BackColor
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    strFrStation = PSS.Data.Buisness.Generic.GetCurrentWorkstaion(Me.tmpDeviceID) : strToStation = ""

                    If SetDeviceWipStation(strToStation) = True Then
                        '***********************************************
                        'Write Refurbished completed record
                        '***********************************************
                        If iTestTypeID > 0 Then
                            objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
                            objTFMisc.WriteTestResult(Me.tmpDeviceID, iTestTypeID, PSS.Core.Global.ApplicationUser.IDuser, 0, iRework, , , , , , , PSS.Data.Buisness.Generic.GetMachineCostCenterID(), Me.txtNote.Text.Trim, strFrStation, strToStation)
                        End If
                        Me.Enabled = False : Cursor.Current = Cursors.Default
                        '***********************************************
                        Me.ButtonClear_ClickEvent()
                        txtSerial.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default : objTFMisc = Nothing : Me.txtSerial.Focus()
            End Try
        End Sub

        '*********************************************************************************************
        Private Function SetDeviceWipStation(ByRef strNextWrkStation As String) As Boolean
            Dim i, iMaxBillcodeRule, iWipOwner As Integer
            Dim strBillcodeIDs As String
            Dim booNeedAccessory, booNeedPart As Boolean
            Dim R1 As DataRow
            Dim dt As DataTable
            Dim objSyx As New PSS.Data.Buisness.Syx()
            Dim iSetAWAPFlag As Integer = 0

            Try
                i = 0 : iMaxBillcodeRule = 0 : iWipOwner = 9 'Out-Cell
                strNextWrkStation = "" : strBillcodeIDs = ""
                booNeedAccessory = False : booNeedPart = False

                ''Hung 11/23/2011 update Syxdata status 
                'iMaxBillcodeRule = PSS.Data.Buisness.Generic.GetMaxBillRule(tmpDeviceID)
                'If iMaxBillcodeRule = 1 Then
                '    objSyx.UpdateSyxStatus(Me.tmpDeviceID, "Scrap")
                'Else
                '    Dim frmSyxDataStatus As New Gui.SyxDataStatus(2, False)
                '    frmSyxDataStatus.ShowDialog()
                '    objSyx.UpdateSyxStatus(Me.tmpDeviceID, frmSyxDataStatus._strStatus)
                'End If
                '***********************************************
                'Get and assign unit to workstation 
                '***********************************************
                iMaxBillcodeRule = PSS.Data.Buisness.Generic.GetMaxBillRule(tmpDeviceID)
                If Me._device.Parts.Rows.Count > 0 AndAlso iMaxBillcodeRule < 0 Then
                    MessageBox.Show("Bill rule is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtSerial.Focus()
                    Return False
                ElseIf Me._device.Parts.Rows.Count > 0 AndAlso iMaxBillcodeRule = 1 Then
                    strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 1)
                Else
                    If Me._dtAWAP.Rows.Count > 0 Then
                        For Each R1 In Me._dtAWAP.Rows
                            If strBillcodeIDs.Trim.Length > 0 Then strBillcodeIDs &= ", "
                            strBillcodeIDs &= R1("Billcode_ID")
                        Next R1

                        dt = Me._objNewTech.GetBillcodeTypes(strBillcodeIDs)
                        For Each R1 In dt.Rows
                            If Me._device.Parts.Select("Billcode_ID = " & R1("Billcode_ID")).Length > 0 Then
                                R1.BeginEdit() : R1("Consumed") = 1 : R1.EndEdit()
                            End If
                        Next R1

                        If dt.Select("Consumed = 0 AND BillType_ID = 2").Length > 0 Then booNeedPart = True
                        If dt.Select("Consumed = 0 AND BillType_ID = 3").Length > 0 Then booNeedAccessory = True
                    End If

                    If booNeedPart = False AndAlso booNeedAccessory = False Then
                        strNextWrkStation = PSS.Data.Buisness.Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me.tmpCustID, 0, )
                    Else
                        strNextWrkStation = "AWAP 2"
                        iWipOwner = 8 'AWAP
                        iSetAWAPFlag = 1
                    End If
                End If

                If strNextWrkStation.Trim.Length > 0 Then
                    PSS.Data.Buisness.Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, tmpDeviceID, iWipOwner, , , )
                    MessageBox.Show("This unit now belongs to " & strNextWrkStation & " work station.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                'strNextWrkStation
                If iSetAWAPFlag > 0 Then objSyx.SetAWAPFlag(Me.tmpDeviceID)
                Return True
            Catch ex As Exception
                Throw ex
            Finally
                objSyx = Nothing : PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '*********************************************************************************************
        Private Sub CollectMotorolaClaimInfo()
            '*******************************************************************
            'Check if the Motorola MCliam data needs to be collected.
            'Added by LAN on 1/1/2007 11:28 AM
            '*******************************************************************
            Dim objMClaims As New PSS.Data.Buisness.WarrantyClaim.MClaim()
            Dim iSendMClaimFlg As Integer = 0
            Dim iBillcodeFlag As Integer = 0
            Dim booVar As Boolean = False

            Try
                iSendMClaimFlg = objMClaims.GetSendMotorolaClaimFlg
                If iSendMClaimFlg = 1 Then
                    booVar = objMClaims.CheckIfMotorolaMClaimDataNeeded(tmpDeviceID, Trim(Me.txtSerial.Text))

                    If booVar = True Then
                        iBillcodeFlag = objMClaims.BillcodeFlag
                        Dim frmMClaimData As New frmCollectMClaimData(tmpDeviceID, iBillcodeFlag)
                        frmMClaimData.ShowDialog()
                        booVar = frmMClaimData.ReturnFlag
                        If booVar = False Then
                            MessageBox.Show("This device is not COMPLETED because Motorola MClaim Data was not input.", "MClaim Data Collection", MessageBoxButtons.OK)
                            frmMClaimData.Dispose()
                            frmMClaimData = Nothing
                            Exit Sub
                        End If
                        If Not IsNothing(frmMClaimData) Then
                            frmMClaimData.Dispose()
                            frmMClaimData = Nothing
                        End If
                    End If
                End If
                '*******************************************************************
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
                Exit Sub
            Finally
                objMClaims = Nothing
            End Try
        End Sub

        '*********************************************************************************************
        Private Function makeCelloptJournalEntry(ByVal mEmpNum As String, ByVal mLine As String, ByVal strEntryText As String, ByVal mQCReject As Integer, ByVal mDeviceID As Long) As Boolean
            Dim ds As PSS.Data.Production.Joins
            Dim blnInsert As Boolean = False
            Dim strSQL As String = ""

            If Len(Trim(mEmpNum)) > 0 And Len(Trim(strEntryText)) > 0 And mDeviceID > 0 Then
                Try
                    strSQL = "INSERT INTO tcellopt_techjournal " & _
                    "(EntryDate, " & _
                    "EmpNum, " & _
                    "Line_ID, " & _
                    "Entry, " & _
                    "QCReject, " & _
                    "Device_ID) " & _
                    "VALUES " & _
                    "(now(), " & _
                    mEmpNum & ", " & _
                    mLine & ", " & _
                    "'" & strEntryText & "', " & _
                    mQCReject & ", " & _
                    mDeviceID & ")"

                    blnInsert = ds.OrderEntryUpdateDelete(strSQL)

                    Return blnInsert
                Catch ex As Exception
                    Return blnInsert
                Finally
                    ds = Nothing
                End Try
            End If
        End Function

        '*********************************************************************************************
        Private Sub txtLotNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
            ' Since the lot number text box is enabled, make sure no one can edit the lot number value.
            e.Handled = True
        End Sub

        '*********************************************************************************************
        Public Function CollectFailRepairCode(ByRef iFailID As Integer, _
                                              ByRef iRepID As Integer, _
                                              ByRef iSymCodeID As Integer, _
                                              ByVal strPanel As String, _
                                              ByVal iBillcodeID As Integer, _
                                              ByVal iConsignedPart As Integer) As Boolean
            Const iUserAbuseFailCode As Integer = 311
            Dim booResult As Boolean = False
            Dim objfrmCSSFailRepCode As Gui.Technician.frmCollectRepairFailCodes
            Dim booReplacePart, booReflow As Boolean
            Dim objMsgboxResult As DialogResult = DialogResult.No  'set defaul value to no ( no user abuse )
            Dim iRepairLevel As Integer = 0

            Try
                iSymCodeID = 0

                '*****************************************
                'NO USER ABUSE FOR PANTECH MANUFACTURER
                ' If unit in warranty: Pantech pay.....
                '*****************************************
                If Me.tmpManufID <> 64 Then objMsgboxResult = MessageBox.Show("Is this physical/liquid damaged?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If objMsgboxResult = DialogResult.Cancel Then
                    booResult = False
                ElseIf objMsgboxResult = DialogResult.Yes Then
                    If Me.tmpManufID = 16 Then   'LG
                        iRepID = 88
                    ElseIf Me.tmpManufID = 21 Then   'SamSung
                        If iConsignedPart = 1 Then
                            MessageBox.Show("Can not use this part for physical/liquid damaged.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Return False
                        Else
                            iRepID = 83
                        End If
                    ElseIf Me.tmpManufID = 1 Then   'Motorola
                        iRepID = 90
                    ElseIf Me.tmpManufID = 24 Then   'Nokia
                        iRepID = 96
                    End If

                    '******************************************************
                    'This failcode use to identify who will pay for part 
                    ' and service (Manufacturer/Customer)
                    '******************************************************
                    iFailID = iUserAbuseFailCode
                    booResult = True
                Else
                    '********************************
                    'Motorola : find repair level
                    '********************************
                    If Me.tmpManufID = 1 Then
                        iRepairLevel = Me._device.GetPartRepairLevel(iBillcodeID)
                        If iRepairLevel < 0 Then
                            MessageBox.Show("System can't define repair level for part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            booResult = True
                            Exit Function
                        End If
                    End If
                    '********************************
                    booReplacePart = True : booReflow = False
                    objfrmCSSFailRepCode = New Gui.Technician.frmCollectRepairFailCodes(Me.tmpManufID, Me.tmpModelID, Me.tmpProdID, iBillcodeID, booReplacePart, booReflow, Me.tmpDeviceID, Me.txtSerial.Text.Trim, iRepairLevel)
                    objfrmCSSFailRepCode._iFailcodeID = iFailID
                    objfrmCSSFailRepCode._iRepCodeID = iRepID
                    objfrmCSSFailRepCode.ShowDialog()

                    If objfrmCSSFailRepCode._booCancel = False Then
                        iFailID = objfrmCSSFailRepCode._iFailcodeID
                        iRepID = objfrmCSSFailRepCode._iRepCodeID
                        iSymCodeID = objfrmCSSFailRepCode._iSymCodeID
                        booResult = True
                    End If
                End If

                Return booResult
            Catch ex As Exception
                Throw ex
                CollectFailRepairCode = False
            Finally
                If Not IsNothing(objfrmCSSFailRepCode) Then
                    objfrmCSSFailRepCode.Dispose()
                    objfrmCSSFailRepCode = Nothing
                End If
            End Try
        End Function

        '******************************************************************
        Private Function CollectPartAndReplaceTempPartInBOM(ByVal iBillcodeID As Integer, ByVal booIsRVPart As Boolean) As Boolean
            Dim objColPartAndMapBOM As Gui.frmCollectPartAndRemapBOM
            Dim booResult As Boolean = False
            Dim iPspriceID As Integer = 0

            Try
                iPspriceID = Me._device.BillableBillcodes.Select("Billcode_ID = " & iBillcodeID)(0)("PSPrice_ID")
                objColPartAndMapBOM = New Gui.frmCollectPartAndRemapBOM(Me.tmpModelID, iBillcodeID, iPspriceID, booIsRVPart, Me.tmpProdID)
                objColPartAndMapBOM.ShowDialog()

                If objColPartAndMapBOM._booCancel = False Then
                    booResult = True
                    If objColPartAndMapBOM._booRefreshBOM = True Then Me._device.ReFreshPartMapBOM()
                End If
                Return booResult
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(objColPartAndMapBOM) Then
                    objColPartAndMapBOM.Dispose() : objColPartAndMapBOM = Nothing
                End If
            End Try
        End Function

        '******************************************************************

#Region "Test Results"

        '******************************************************************
        Private Sub loadTestResults()
            Dim dt As DataTable
            Dim drNoteAndReason As DataRow

            Try
                Me.txtTestResult_Triage.Text = ""
                Me.lblTestResult_QC.Text = ""

                dt = Me._objNewTech.GetRepairHistories(Me.tmpDeviceID)
                With Me.grdTechHistory
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .Splits(0).DisplayColumns("Date").Width = 100
                    .Splits(0).DisplayColumns("Iteration").Width = 80
                    .Splits(0).DisplayColumns("User/Tech").Width = 120
                    .Splits(0).DisplayColumns("Notes").Width = 300
                End With

                Me.txtTestResult_Triage.Text = Me._objNewTech.GetTestResult_Triage(Me.tmpDeviceID)
                Me.lblTestResult_QC.Text = Me._objNewTech.GetTestResult_QC(Me.tmpDeviceID)
                drNoteAndReason = Me._objNewTech.GetTMINoteAndReason(Me.tmpWO)
                If Not IsNothing(drNoteAndReason) Then
                    Me.lblClaimNotes.Text = drNoteAndReason("Note")
                    Me.lblClaimReason.Text = drNoteAndReason("Reason")
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "loadTestResults", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
#End Region

        '******************************************************************
        Private Sub AccessoryClick(ByVal sender As Object, ByVal e As System.EventArgs)

            'Accessory Status '3411=Pass ;3412=Fail ;3413=Missing
            Dim btName, BillCode_ID, Part_Number As String
            Dim user_ID As Integer = PSS.Core.ApplicationUser.IDuser
            Dim objAccessoryStatusWind As Gui.AccessoryStatus
            Dim strAction, strFailReason As String
            Dim iStatusID As Integer
            Dim objSyx As New PSS.Data.Buisness.Syx()

            Try

                Me.Enabled = False
                Part_Number = Trim(sender.name.ToString)
                btName = Trim(sender.text.ToString)
                BillCode_ID = Trim(sender.tag.ToString)

                If CType(sender, Button).BackColor.ToString() = "Color [Orange]" Then
                    'Failed or Remove Accessories
                    objAccessoryStatusWind = New Gui.AccessoryStatus()
                    objAccessoryStatusWind.ShowDialog()
                    If objAccessoryStatusWind._booCancel = True Then
                        Exit Sub
                    Else
                        iStatusID = objAccessoryStatusWind._iStatusDCodeID
                        strFailReason = objAccessoryStatusWind._strFailReason
                        objSyx.InsertRemoveAccessories(Me.tmpDeviceID, BillCode_ID, Part_Number, objSyx.ScreenID_Billing, user_ID, iStatusID, strFailReason)
                        CType(sender, Button).BackColor = Color.LightGray
                    End If
                Else
                    'Add New Accessory 
                    'If MessageBox.Show("The " & btName.ToUpper & " accessory is not available or missing during receiving. Are you sure you want to add the " & btName.ToUpper & " accessory ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                    iStatusID = 3411
                    objSyx.InsertRemoveAccessories(Me.tmpDeviceID, BillCode_ID, Part_Number, objSyx.ScreenID_Billing, user_ID, iStatusID)
                    CType(sender, Button).BackColor = Color.Orange
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAccessories_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                If Not IsNothing(objAccessoryStatusWind) Then
                    objAccessoryStatusWind.Dispose() : objAccessoryStatusWind = Nothing
                    objSyx = Nothing
                End If
            End Try
        End Sub

        '***************************************************************************
        Private Sub lblSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSelected.Click
            If lblSelected.Text = "SHOW SELECTED" Then
                tabMain.Visible = False
                gridBilling.Visible = True
                lblSelected.Text = "RETURN"
                PopulateBillingSelectionGrid(Me.tmpDeviceID, Me.tmpCustID)
            Else
                tabMain.Visible = True
                gridBilling.Visible = False
                lblSelected.Text = "SHOW SELECTED"
                Me.txtSerial.Focus()
            End If
        End Sub

        '***************************************************************************

    End Class
End Namespace