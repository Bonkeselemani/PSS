Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.VV
    Public Class frmVivint_FulfillOrder
        Inherits System.Windows.Forms.Form

        Private _iCust_ID As Integer = 0
        Private _iEDI_TransSet As Integer = 0
        Private _strScreenName As String = ""
        Private _dtSelectedOrder As DataTable
        Private _dtSelectedOrderDetail As DataTable
        Private _dtFilledManifestData As DataTable

        Private _objVivint As PSS.Data.Buisness.VV.Vivint
        Private _objVivint_FulFillOrder As PSS.Data.Buisness.VV.Vivint_FulfillOrder

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
            Me._objVivint_FulFillorder = New PSS.Data.Buisness.VV.Vivint_FulfillOrder()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVivint = Nothing
                    Me._objVivint_FulFillorder = Nothing
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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnRefreshList As System.Windows.Forms.Button
        Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
        Friend WithEvents btnCopyAll As System.Windows.Forms.Button
        Friend WithEvents dbgAvailableBoxes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents lblShipToAddr As System.Windows.Forms.Label
        Friend WithEvents btnReprintBoxLabelTal As System.Windows.Forms.Button
        Friend WithEvents btnReprintPackingList As System.Windows.Forms.Button
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents lblTotalQty As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtBoxWeight As System.Windows.Forms.TextBox
        Friend WithEvents cboOpenOrderTobeFilled As C1.Win.C1List.C1Combo
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnFillOrder As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dbgDetail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents txtManifest As System.Windows.Forms.TextBox
        Friend WithEvents txtTrackingNo As System.Windows.Forms.TextBox
        Friend WithEvents btnASNMsg As System.Windows.Forms.Button
        Friend WithEvents txtCarrier As System.Windows.Forms.TextBox
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents btnCopyManifestNo As System.Windows.Forms.Button
        Friend WithEvents lstManifest As System.Windows.Forms.ListBox
        Friend WithEvents btnRemoveAllManifest As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOneManifest As System.Windows.Forms.Button
        Friend WithEvents btnPrinterInfo As System.Windows.Forms.Button
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtBOL As System.Windows.Forms.TextBox
        Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
        Friend WithEvents cboPOForInvoiceNo As C1.Win.C1List.C1Combo
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceNo As System.Windows.Forms.TextBox
        Friend WithEvents btnRefreshPOForInvoiceNo As System.Windows.Forms.Button
        Friend WithEvents btnAddInvoiceNo As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVivint_FulfillOrder))
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnCopyManifestNo = New System.Windows.Forms.Button()
            Me.btnRefreshList = New System.Windows.Forms.Button()
            Me.btnCopySelectedRows = New System.Windows.Forms.Button()
            Me.btnCopyAll = New System.Windows.Forms.Button()
            Me.dbgAvailableBoxes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.txtBOL = New System.Windows.Forms.TextBox()
            Me.btnPrinterInfo = New System.Windows.Forms.Button()
            Me.btnASNMsg = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtCarrier = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtTrackingNo = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.dbgDetail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblShipToAddr = New System.Windows.Forms.Label()
            Me.btnReprintBoxLabelTal = New System.Windows.Forms.Button()
            Me.btnReprintPackingList = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.btnRemoveAllManifest = New System.Windows.Forms.Button()
            Me.btnRemoveOneManifest = New System.Windows.Forms.Button()
            Me.lblTotalQty = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtBoxWeight = New System.Windows.Forms.TextBox()
            Me.cboOpenOrderTobeFilled = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnFillOrder = New System.Windows.Forms.Button()
            Me.lstManifest = New System.Windows.Forms.ListBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtManifest = New System.Windows.Forms.TextBox()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.TabPage3 = New System.Windows.Forms.TabPage()
            Me.btnAddInvoiceNo = New System.Windows.Forms.Button()
            Me.btnRefreshPOForInvoiceNo = New System.Windows.Forms.Button()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtInvoiceNo = New System.Windows.Forms.TextBox()
            Me.cboPOForInvoiceNo = New C1.Win.C1List.C1Combo()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.GroupBox1.SuspendLayout()
            CType(Me.dbgAvailableBoxes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox2.SuspendLayout()
            CType(Me.dbgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboOpenOrderTobeFilled, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            Me.TabPage2.SuspendLayout()
            Me.TabPage3.SuspendLayout()
            CType(Me.cboPOForInvoiceNo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopyManifestNo, Me.btnRefreshList, Me.btnCopySelectedRows, Me.btnCopyAll, Me.dbgAvailableBoxes})
            Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(24, 16)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(968, 512)
            Me.GroupBox1.TabIndex = 2
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Available Manifest"
            '
            'btnCopyManifestNo
            '
            Me.btnCopyManifestNo.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCopyManifestNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyManifestNo.ForeColor = System.Drawing.Color.Black
            Me.btnCopyManifestNo.Location = New System.Drawing.Point(128, 24)
            Me.btnCopyManifestNo.Name = "btnCopyManifestNo"
            Me.btnCopyManifestNo.Size = New System.Drawing.Size(208, 24)
            Me.btnCopyManifestNo.TabIndex = 118
            Me.btnCopyManifestNo.Text = "Copy Selected Manifest Number"
            '
            'btnRefreshList
            '
            Me.btnRefreshList.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnRefreshList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshList.ForeColor = System.Drawing.Color.Black
            Me.btnRefreshList.Location = New System.Drawing.Point(8, 24)
            Me.btnRefreshList.Name = "btnRefreshList"
            Me.btnRefreshList.Size = New System.Drawing.Size(104, 24)
            Me.btnRefreshList.TabIndex = 117
            Me.btnRefreshList.Text = "Refresh List"
            '
            'btnCopySelectedRows
            '
            Me.btnCopySelectedRows.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCopySelectedRows.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Black
            Me.btnCopySelectedRows.Location = New System.Drawing.Point(440, 24)
            Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
            Me.btnCopySelectedRows.Size = New System.Drawing.Size(152, 24)
            Me.btnCopySelectedRows.TabIndex = 116
            Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
            '
            'btnCopyAll
            '
            Me.btnCopyAll.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyAll.ForeColor = System.Drawing.Color.Black
            Me.btnCopyAll.Location = New System.Drawing.Point(360, 24)
            Me.btnCopyAll.Name = "btnCopyAll"
            Me.btnCopyAll.Size = New System.Drawing.Size(72, 24)
            Me.btnCopyAll.TabIndex = 115
            Me.btnCopyAll.Text = "Copy All"
            '
            'dbgAvailableBoxes
            '
            Me.dbgAvailableBoxes.AllowUpdate = False
            Me.dbgAvailableBoxes.AlternatingRows = True
            Me.dbgAvailableBoxes.BackColor = System.Drawing.Color.White
            Me.dbgAvailableBoxes.FilterBar = True
            Me.dbgAvailableBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgAvailableBoxes.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgAvailableBoxes.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgAvailableBoxes.Location = New System.Drawing.Point(16, 56)
            Me.dbgAvailableBoxes.Name = "dbgAvailableBoxes"
            Me.dbgAvailableBoxes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgAvailableBoxes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgAvailableBoxes.PreviewInfo.ZoomFactor = 75
            Me.dbgAvailableBoxes.RowHeight = 15
            Me.dbgAvailableBoxes.Size = New System.Drawing.Size(944, 432)
            Me.dbgAvailableBoxes.TabIndex = 4
            Me.dbgAvailableBoxes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 9pt;BackCol" & _
            "or:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}Styl" & _
            "e18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Style1" & _
            "1{}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Style2" & _
            "1{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}Ev" & _
            "enRow{BackColor:NavajoWhite;}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt" & _
            ", style=Bold;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;A" & _
            "lignVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeCol" & _
            "or:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;B" & _
            "order:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}St" & _
            "yle2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""24"" Nam" & _
            "e="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colu" & _
            "mnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelec" & _
            "torWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=" & _
            """1""><Height>428</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyl" & _
            "e parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fi" & _
            "lterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""" & _
            "Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headin" & _
            "g"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactiv" & _
            "eStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" " & _
            "/><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle par" & _
            "ent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0," & _
            " 0, 940, 428</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSt" & _
            "yle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""N" & _
            "ormal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foote" & _
            "r"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive" & _
            """ /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" />" & _
            "<Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /" & _
            "><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector" & _
            """ /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /" & _
            "></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None<" & _
            "/Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 940, 428</C" & _
            "lientArea><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle p" & _
            "arent="""" me=""Style21"" /></Blob>"
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.Color.SteelBlue
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.txtBOL, Me.btnPrinterInfo, Me.btnASNMsg, Me.Label5, Me.txtCarrier, Me.Label4, Me.txtTrackingNo, Me.Label2, Me.dbgDetail, Me.Label9, Me.lblShipToAddr, Me.btnReprintBoxLabelTal, Me.btnReprintPackingList, Me.btnReprintBoxLabel, Me.btnRemoveAllManifest, Me.btnRemoveOneManifest, Me.lblTotalQty, Me.Label10, Me.lblBoxQty, Me.Label7, Me.Label6, Me.txtBoxWeight, Me.cboOpenOrderTobeFilled, Me.Label3, Me.btnFillOrder, Me.lstManifest, Me.Label1, Me.txtManifest})
            Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox2.ForeColor = System.Drawing.Color.White
            Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(800, 520)
            Me.GroupBox2.TabIndex = 5
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Fill Orders"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(0, 400)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(120, 19)
            Me.Label8.TabIndex = 127
            Me.Label8.Text = "Bill of Lading No:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBOL
            '
            Me.txtBOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBOL.Location = New System.Drawing.Point(120, 400)
            Me.txtBOL.Name = "txtBOL"
            Me.txtBOL.Size = New System.Drawing.Size(224, 21)
            Me.txtBOL.TabIndex = 126
            Me.txtBOL.Text = ""
            '
            'btnPrinterInfo
            '
            Me.btnPrinterInfo.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPrinterInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPrinterInfo.ForeColor = System.Drawing.Color.Yellow
            Me.btnPrinterInfo.Location = New System.Drawing.Point(592, 330)
            Me.btnPrinterInfo.Name = "btnPrinterInfo"
            Me.btnPrinterInfo.Size = New System.Drawing.Size(24, 24)
            Me.btnPrinterInfo.TabIndex = 125
            Me.btnPrinterInfo.Text = "?"
            '
            'btnASNMsg
            '
            Me.btnASNMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnASNMsg.ForeColor = System.Drawing.Color.Gold
            Me.btnASNMsg.Location = New System.Drawing.Point(14, 88)
            Me.btnASNMsg.Name = "btnASNMsg"
            Me.btnASNMsg.Size = New System.Drawing.Size(104, 24)
            Me.btnASNMsg.TabIndex = 124
            Me.btnASNMsg.Text = "See ASN Msg"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(24, 352)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(96, 19)
            Me.Label5.TabIndex = 123
            Me.Label5.Text = "Ship Carrier:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCarrier
            '
            Me.txtCarrier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtCarrier.Location = New System.Drawing.Point(120, 352)
            Me.txtCarrier.Name = "txtCarrier"
            Me.txtCarrier.Size = New System.Drawing.Size(224, 21)
            Me.txtCarrier.TabIndex = 122
            Me.txtCarrier.Text = ""
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(24, 328)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(96, 19)
            Me.Label4.TabIndex = 121
            Me.Label4.Text = "Tracking No:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTrackingNo
            '
            Me.txtTrackingNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtTrackingNo.Location = New System.Drawing.Point(120, 328)
            Me.txtTrackingNo.Name = "txtTrackingNo"
            Me.txtTrackingNo.Size = New System.Drawing.Size(224, 21)
            Me.txtTrackingNo.TabIndex = 120
            Me.txtTrackingNo.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(16, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 19)
            Me.Label2.TabIndex = 119
            Me.Label2.Text = "Order Detail:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dbgDetail
            '
            Me.dbgDetail.AllowColMove = False
            Me.dbgDetail.AllowColSelect = False
            Me.dbgDetail.AllowFilter = False
            Me.dbgDetail.AllowSort = False
            Me.dbgDetail.AllowUpdate = False
            Me.dbgDetail.AlternatingRows = True
            Me.dbgDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dbgDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgDetail.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgDetail.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.dbgDetail.Location = New System.Drawing.Point(120, 72)
            Me.dbgDetail.Name = "dbgDetail"
            Me.dbgDetail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgDetail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgDetail.PreviewInfo.ZoomFactor = 75
            Me.dbgDetail.Size = New System.Drawing.Size(664, 104)
            Me.dbgDetail.TabIndex = 118
            Me.dbgDetail.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{Font:Microsoft Sans Serif, 8.25pt;Back" & _
            "Color:SteelBlue;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Editor{}S" & _
            "tyle18{}Style19{}Style14{}Style15{}Style16{}Style17{}Style10{AlignHorz:Near;}Sty" & _
            "le11{}OddRow{BackColor:LightSteelBlue;}Style13{}Style12{}HighlightRow{ForeColor:" & _
            "HighlightText;BackColor:Highlight;}RecordSelector{AlignImage:Center;}Footer{}Sty" & _
            "le21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;" & _
            "}EvenRow{BackColor:NavajoWhite;}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.2" & _
            "5pt, style=Bold;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText" & _
            ";BackColor:Control;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;Fore" & _
            "Color:Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{BackColor:Contr" & _
            "olDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style7{}Style6{}Style1{}Style3{" & _
            "}Style2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""12"" " & _
            "AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" C" & _
            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=" & _
            """DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGr" & _
            "oup=""1"" HorizontalScrollGroup=""1""><Height>102</Height><CaptionStyle parent=""Styl" & _
            "e2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle pare" & _
            "nt=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><Fo" & _
            "oterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" " & _
            "/><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Highli" & _
            "ghtRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyl" & _
            "e parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=" & _
            """Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal" & _
            """ me=""Style1"" /><ClientRect>0, 0, 662, 102</ClientRect><BorderSide>0</BorderSide" & _
            "><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><Name" & _
            "dStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><St" & _
            "yle parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style" & _
            " parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style " & _
            "parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style " & _
            "parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style paren" & _
            "t=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style" & _
            " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
            "ts>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth" & _
            "><ClientArea>0, 0, 662, 102</ClientArea><PrintPageHeaderStyle parent="""" me=""Styl" & _
            "e20"" /><PrintPageFooterStyle parent="""" me=""Style21"" /></Blob>"
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(8, 43)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(112, 19)
            Me.Label9.TabIndex = 117
            Me.Label9.Text = "Ship To Address:"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblShipToAddr
            '
            Me.lblShipToAddr.BackColor = System.Drawing.Color.Transparent
            Me.lblShipToAddr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShipToAddr.ForeColor = System.Drawing.Color.Black
            Me.lblShipToAddr.Location = New System.Drawing.Point(128, 48)
            Me.lblShipToAddr.Name = "lblShipToAddr"
            Me.lblShipToAddr.Size = New System.Drawing.Size(528, 24)
            Me.lblShipToAddr.TabIndex = 116
            '
            'btnReprintBoxLabelTal
            '
            Me.btnReprintBoxLabelTal.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabelTal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabelTal.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabelTal.Location = New System.Drawing.Point(432, 440)
            Me.btnReprintBoxLabelTal.Name = "btnReprintBoxLabelTal"
            Me.btnReprintBoxLabelTal.Size = New System.Drawing.Size(72, 32)
            Me.btnReprintBoxLabelTal.TabIndex = 115
            Me.btnReprintBoxLabelTal.Text = "REPRINT BOX LABEL (TAL)"
            Me.btnReprintBoxLabelTal.Visible = False
            '
            'btnReprintPackingList
            '
            Me.btnReprintPackingList.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintPackingList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintPackingList.ForeColor = System.Drawing.Color.Black
            Me.btnReprintPackingList.Location = New System.Drawing.Point(368, 300)
            Me.btnReprintPackingList.Name = "btnReprintPackingList"
            Me.btnReprintPackingList.Size = New System.Drawing.Size(224, 32)
            Me.btnReprintPackingList.TabIndex = 114
            Me.btnReprintPackingList.Text = "REPRINT PACKING LIST"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(368, 264)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(224, 32)
            Me.btnReprintBoxLabel.TabIndex = 113
            Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
            '
            'btnRemoveAllManifest
            '
            Me.btnRemoveAllManifest.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllManifest.ForeColor = System.Drawing.Color.Black
            Me.btnRemoveAllManifest.Location = New System.Drawing.Point(368, 220)
            Me.btnRemoveAllManifest.Name = "btnRemoveAllManifest"
            Me.btnRemoveAllManifest.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllManifest.Size = New System.Drawing.Size(224, 32)
            Me.btnRemoveAllManifest.TabIndex = 9
            Me.btnRemoveAllManifest.Text = "Remove All"
            '
            'btnRemoveOneManifest
            '
            Me.btnRemoveOneManifest.BackColor = System.Drawing.Color.Red
            Me.btnRemoveOneManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveOneManifest.ForeColor = System.Drawing.Color.Black
            Me.btnRemoveOneManifest.Location = New System.Drawing.Point(368, 184)
            Me.btnRemoveOneManifest.Name = "btnRemoveOneManifest"
            Me.btnRemoveOneManifest.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveOneManifest.Size = New System.Drawing.Size(224, 32)
            Me.btnRemoveOneManifest.TabIndex = 8
            Me.btnRemoveOneManifest.Text = "Remove One Manifest"
            '
            'lblTotalQty
            '
            Me.lblTotalQty.BackColor = System.Drawing.Color.Black
            Me.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalQty.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalQty.Location = New System.Drawing.Point(648, 456)
            Me.lblTotalQty.Name = "lblTotalQty"
            Me.lblTotalQty.Size = New System.Drawing.Size(110, 41)
            Me.lblTotalQty.TabIndex = 111
            Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.lblTotalQty.Visible = False
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Lime
            Me.Label10.Location = New System.Drawing.Point(656, 440)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(89, 16)
            Me.Label10.TabIndex = 112
            Me.Label10.Text = "TOTAL"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.Label10.Visible = False
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.Color.Black
            Me.lblBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxQty.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxQty.Location = New System.Drawing.Point(536, 456)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(106, 41)
            Me.lblBoxQty.TabIndex = 109
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.lblBoxQty.Visible = False
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Lime
            Me.Label7.Location = New System.Drawing.Point(544, 440)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(89, 16)
            Me.Label7.TabIndex = 110
            Me.Label7.Text = "BOX QTY"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.Label7.Visible = False
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(24, 376)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 19)
            Me.Label6.TabIndex = 108
            Me.Label6.Text = "Weight (LBs):"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBoxWeight
            '
            Me.txtBoxWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxWeight.Location = New System.Drawing.Point(120, 376)
            Me.txtBoxWeight.Name = "txtBoxWeight"
            Me.txtBoxWeight.Size = New System.Drawing.Size(224, 21)
            Me.txtBoxWeight.TabIndex = 4
            Me.txtBoxWeight.Text = ""
            '
            'cboOpenOrderTobeFilled
            '
            Me.cboOpenOrderTobeFilled.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenOrderTobeFilled.AutoCompletion = True
            Me.cboOpenOrderTobeFilled.AutoDropDown = True
            Me.cboOpenOrderTobeFilled.AutoSelect = True
            Me.cboOpenOrderTobeFilled.Caption = ""
            Me.cboOpenOrderTobeFilled.CaptionHeight = 17
            Me.cboOpenOrderTobeFilled.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenOrderTobeFilled.ColumnCaptionHeight = 17
            Me.cboOpenOrderTobeFilled.ColumnFooterHeight = 17
            Me.cboOpenOrderTobeFilled.ColumnHeaders = False
            Me.cboOpenOrderTobeFilled.ContentHeight = 15
            Me.cboOpenOrderTobeFilled.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenOrderTobeFilled.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenOrderTobeFilled.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrderTobeFilled.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenOrderTobeFilled.EditorHeight = 15
            Me.cboOpenOrderTobeFilled.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenOrderTobeFilled.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboOpenOrderTobeFilled.ItemHeight = 15
            Me.cboOpenOrderTobeFilled.Location = New System.Drawing.Point(120, 18)
            Me.cboOpenOrderTobeFilled.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenOrderTobeFilled.MaxDropDownItems = CType(10, Short)
            Me.cboOpenOrderTobeFilled.MaxLength = 32767
            Me.cboOpenOrderTobeFilled.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenOrderTobeFilled.Name = "cboOpenOrderTobeFilled"
            Me.cboOpenOrderTobeFilled.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenOrderTobeFilled.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenOrderTobeFilled.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenOrderTobeFilled.Size = New System.Drawing.Size(224, 21)
            Me.cboOpenOrderTobeFilled.TabIndex = 1
            Me.cboOpenOrderTobeFilled.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(16, 20)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(104, 19)
            Me.Label3.TabIndex = 105
            Me.Label3.Text = "Order Number :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnFillOrder
            '
            Me.btnFillOrder.BackColor = System.Drawing.Color.Green
            Me.btnFillOrder.Enabled = False
            Me.btnFillOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFillOrder.ForeColor = System.Drawing.Color.White
            Me.btnFillOrder.Location = New System.Drawing.Point(368, 344)
            Me.btnFillOrder.Name = "btnFillOrder"
            Me.btnFillOrder.Size = New System.Drawing.Size(224, 56)
            Me.btnFillOrder.TabIndex = 7
            Me.btnFillOrder.Text = "Fill Order with Selected Box"
            '
            'lstManifest
            '
            Me.lstManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstManifest.ItemHeight = 15
            Me.lstManifest.Location = New System.Drawing.Point(120, 208)
            Me.lstManifest.Name = "lstManifest"
            Me.lstManifest.Size = New System.Drawing.Size(224, 109)
            Me.lstManifest.TabIndex = 6
            Me.lstManifest.TabStop = False
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(16, 184)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 18)
            Me.Label1.TabIndex = 101
            Me.Label1.Text = "Manifest No:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtManifest
            '
            Me.txtManifest.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtManifest.Location = New System.Drawing.Point(120, 184)
            Me.txtManifest.Name = "txtManifest"
            Me.txtManifest.Size = New System.Drawing.Size(224, 22)
            Me.txtManifest.TabIndex = 0
            Me.txtManifest.Text = ""
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2, Me.TabPage3})
            Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1008, 584)
            Me.TabControl1.TabIndex = 6
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.SteelBlue
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2})
            Me.TabPage1.Location = New System.Drawing.Point(4, 24)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(1000, 556)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Filll Order"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.CadetBlue
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1})
            Me.TabPage2.Location = New System.Drawing.Point(4, 24)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(1000, 556)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Open Manifest"
            '
            'TabPage3
            '
            Me.TabPage3.BackColor = System.Drawing.Color.Gainsboro
            Me.TabPage3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAddInvoiceNo, Me.btnRefreshPOForInvoiceNo, Me.Label12, Me.txtInvoiceNo, Me.cboPOForInvoiceNo, Me.Label11})
            Me.TabPage3.Location = New System.Drawing.Point(4, 24)
            Me.TabPage3.Name = "TabPage3"
            Me.TabPage3.Size = New System.Drawing.Size(1000, 556)
            Me.TabPage3.TabIndex = 2
            Me.TabPage3.Text = "Add Invoice No"
            '
            'btnAddInvoiceNo
            '
            Me.btnAddInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddInvoiceNo.Location = New System.Drawing.Point(304, 104)
            Me.btnAddInvoiceNo.Name = "btnAddInvoiceNo"
            Me.btnAddInvoiceNo.Size = New System.Drawing.Size(128, 40)
            Me.btnAddInvoiceNo.TabIndex = 131
            Me.btnAddInvoiceNo.Text = "Add Invoice No"
            '
            'btnRefreshPOForInvoiceNo
            '
            Me.btnRefreshPOForInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshPOForInvoiceNo.Location = New System.Drawing.Point(304, 40)
            Me.btnRefreshPOForInvoiceNo.Name = "btnRefreshPOForInvoiceNo"
            Me.btnRefreshPOForInvoiceNo.Size = New System.Drawing.Size(128, 40)
            Me.btnRefreshPOForInvoiceNo.TabIndex = 130
            Me.btnRefreshPOForInvoiceNo.Text = "Refresh"
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(48, 88)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(120, 19)
            Me.Label12.TabIndex = 129
            Me.Label12.Text = "Invoice No:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtInvoiceNo
            '
            Me.txtInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtInvoiceNo.Location = New System.Drawing.Point(48, 112)
            Me.txtInvoiceNo.Name = "txtInvoiceNo"
            Me.txtInvoiceNo.Size = New System.Drawing.Size(248, 21)
            Me.txtInvoiceNo.TabIndex = 128
            Me.txtInvoiceNo.Text = ""
            '
            'cboPOForInvoiceNo
            '
            Me.cboPOForInvoiceNo.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPOForInvoiceNo.AutoCompletion = True
            Me.cboPOForInvoiceNo.AutoDropDown = True
            Me.cboPOForInvoiceNo.AutoSelect = True
            Me.cboPOForInvoiceNo.Caption = ""
            Me.cboPOForInvoiceNo.CaptionHeight = 17
            Me.cboPOForInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPOForInvoiceNo.ColumnCaptionHeight = 17
            Me.cboPOForInvoiceNo.ColumnFooterHeight = 17
            Me.cboPOForInvoiceNo.ColumnHeaders = False
            Me.cboPOForInvoiceNo.ContentHeight = 15
            Me.cboPOForInvoiceNo.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPOForInvoiceNo.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPOForInvoiceNo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPOForInvoiceNo.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPOForInvoiceNo.EditorHeight = 15
            Me.cboPOForInvoiceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPOForInvoiceNo.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboPOForInvoiceNo.ItemHeight = 15
            Me.cboPOForInvoiceNo.Location = New System.Drawing.Point(48, 48)
            Me.cboPOForInvoiceNo.MatchEntryTimeout = CType(2000, Long)
            Me.cboPOForInvoiceNo.MaxDropDownItems = CType(10, Short)
            Me.cboPOForInvoiceNo.MaxLength = 32767
            Me.cboPOForInvoiceNo.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPOForInvoiceNo.Name = "cboPOForInvoiceNo"
            Me.cboPOForInvoiceNo.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPOForInvoiceNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPOForInvoiceNo.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPOForInvoiceNo.Size = New System.Drawing.Size(248, 21)
            Me.cboPOForInvoiceNo.TabIndex = 106
            Me.cboPOForInvoiceNo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Black
            Me.Label11.Location = New System.Drawing.Point(48, 24)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(320, 19)
            Me.Label11.TabIndex = 107
            Me.Label11.Text = "Order Number (EDI 810 Not Sent Out Yet): "
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmVivint_FulfillOrder
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(1024, 606)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmVivint_FulfillOrder"
            Me.Text = "frmVivint_FulfillOrder"
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.dbgAvailableBoxes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.dbgDetail, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboOpenOrderTobeFilled, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            Me.TabPage2.ResumeLayout(False)
            Me.TabPage3.ResumeLayout(False)
            CType(Me.cboPOForInvoiceNo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmVivint_FulfillOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed
                Me.txtManifest.Enabled = False

                If Me._iCust_ID = PSS.Data.Buisness.VV.Vivint.Vivint_CUSTOMER_ID Then
                    'Me.GroupBox1.Text = "Vivint: " & Me.GroupBox1.Text
                    'Me.GroupBox2.Text = "Vivint: " & Me.GroupBox2.Text

                    Me._iEDI_TransSet = 850

                    Me.ReceivingNewOrders()

                End If

                Me.PopulateOpenOrder() : PopulateOpenOrderForInvoiceNo()
                Me.LoadAvailableManifestData()

                Me.cboOpenOrderTobeFilled.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmWHFillingOrder_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ReceivingNewOrders()
            Dim dtPO, dtPO_Tmp As DataTable
            Dim dtMsg As DataTable
            Dim dtItem As DataTable
            Dim row, row2 As DataRow
            Dim strMsg As String = ""
            Dim ArrLst_UniquePOs As New ArrayList()
            Dim ArrLst_DupPOs As New ArrayList()
            Dim iExt_Msg_ID As Integer = 0

            Dim strDupPOs As String = ""

            Dim i As Integer = 0, j As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iSoHeaderID As Integer = 0
            Dim iOrderQty As Integer = 0
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

            Try
                'Ext_Msg_ID, Sender_EDI_ID, Receiver_EDI_ID, EDI_Datetime, TransSetCode, EDI_Version, ISAControlNo, GSControlNo, 
                'GSTransType(, TransSetControlNo, PO, PO_Code, PO_Type, PO_Date, PO_BuyParty, PO_Currency, InternalVendorNo, 
                'InternalVendorNo_ID, FOB_ShipPayMethod, FOB_ZZ, FOB_Desc, FOB_TTQ_ID, FOB_TT_Code, ITD_PayType, ITD_Desc, TD5_ShipRoutDesc, ZZ_MD, 
                'ZZ_Desc, Bill_Code, Bill_Name, Bill_Address, Bill_City, Bill_State, Bill_Zip, Bill_Country, PER1_ContactCode, PER1_Contact, 
                'PER1_EmailCode, PER1_EMail, PER1_TelCode, PER1_Tel, PER1_FaxCode, PER1_Fax, Ship_Code, Ship_Name, Ship_Address, Ship_City, Ship_State,
                ' Ship_Zip, Ship_Country, PER2_ContactCode, PER2_Contact, PER2_EmailCode, PER2_EMail, PER2_TelCode, PER2_Tel, PER2_FaxCode, PER2_Fax,
                ' CTT_TotalLineItemNo, SE_TotalSegmentCount, Order_Type, Rec_DateTime, SourceFile, SoHeaderID, Cust_ID)
                dtPO_Tmp = Me._objVivint_FulFillOrder.getNewOrders(Me._iCust_ID, Me._iEDI_TransSet)

                If Not dtPO_Tmp.Rows.Count > 0 Then Exit Sub

                dtPO = dtPO_Tmp.Clone

                'Dup POs
                For Each row In dtPO_Tmp.Rows
                    If Not ArrLst_UniquePOs.Contains(row("PO")) Then
                        ArrLst_UniquePOs.Add(row("PO"))
                    Else
                        i += 1
                        ArrLst_DupPOs.Add(row("PO"))
                        If strDupPOs.Trim.Length = 0 Then strDupPOs = row("PO") Else strDupPOs = "," & row("PO")
                    End If
                Next
                If i = 1 Then
                    strMsg &= "Found 1 duplicate PO (" & strDupPOs & ") in the ASN order data. See IT!" & Environment.NewLine
                ElseIf i > 1 Then
                    strMsg &= "Found " & i.ToString & " duplicate POs (" & strDupPOs & ") in the ASN order data. See IT!" & Environment.NewLine
                End If

                'Remove dup POs if any, get un-duplicate PO data
                For Each row In dtPO_Tmp.Rows
                    If Not ArrLst_DupPOs.Contains(row("PO")) Then
                        dtPO.ImportRow(row)
                    End If
                Next

                'Process each PO (receive it into sale order place
                i = 0
                For Each row In dtPO.Rows
                    i += 1
                    iExt_Msg_ID = Convert.ToInt32(row("Ext_Msg_ID"))
                    dtItem = Me._objVivint_FulFillOrder.getPOItemData(iExt_Msg_ID)
                    'Tei_ID, Ext_Msg_ID, PO_ID, PO_Qty, PO_UnitCode, PO_UnitPrice, PO_UnitPriceCode, PO_BuyerItemID, PO_BuyerItem, 
                    'PO_VendorItemID, PO_VendorItem, PID_ItemDescType, PID_ItemCode, PID_ItemDesc, DTM_DeliveryID, DTM_DeliveryRequestedDate

                    If dtItem.Rows.Count > 0 Then
                        iOrderQty = 0
                        For Each row2 In dtItem.Rows
                            iOrderQty += Convert.ToInt32(row2("PO_Qty"))
                        Next
                        iWO_ID = Me._objVivint_FulFillOrder.CreateAndGetWO_ID(row("PO"), PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID, iOrderQty, _
                                                                              PSS.Data.Buisness.VV.Vivint.Vivint_Product_ID, strDateTime)
                        iSoHeaderID = Me._objVivint_FulFillOrder.CreateAndGetSoHeader_ID(iExt_Msg_ID, iWO_ID)
                        j = Me._objVivint_FulFillOrder.SaveItemData(iExt_Msg_ID, iSoHeaderID)
                    Else
                        strMsg &= "No item data for PO " & row("PO") & ". See IT!" & Environment.NewLine
                    End If
                Next

                If strMsg.Trim.Length > 0 Then
                    MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub ReceivingNewOrders", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PopulateOpenOrder()
            Dim dt As DataTable

            Try
                dt = Me._objVivint_FulFillOrder.getOpenOrders(Me._iCust_ID)
                Misc.PopulateC1DropDownList(Me.cboOpenOrderTobeFilled, dt, "PONumber", "SoHeaderID")
                Me.cboOpenOrderTobeFilled.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub PopulateOpenOrder", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PopulateOpenOrderForInvoiceNo()
            Dim dt As DataTable

            Try
                dt = Me._objVivint_FulFillOrder.getEDI810NotSentOrders(Me._iCust_ID)
                Misc.PopulateC1DropDownList(Me.cboPOForInvoiceNo, dt, "PONumber", "SoHeaderID")
                Me.cboOpenOrderTobeFilled.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub PopulateOpenOrderForInvoiceNo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub cboOpenOrderTobeFilled_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboOpenOrderTobeFilled.SelectedValueChanged
            ' Dim dtPO As DataTable
            Dim strAddress As String = ""
            'SoHeaderID, Cust_ID, PONumber, CustomerOrderNumber, WorkOrderID, PODate, CustomerFirstName, CustomerAddress1, CustomerCity, CustomerState, 
            'CustomerPostalCode, CustomerCountry, CustomerPhone
            'Line, Shipped_Model, Qty, DeliveryDate, ProductName, PSS_Model, SoHeaderID, Model_ID, SoDetailsID
            Try
                Me.dbgDetail.Visible = False : Me.lblShipToAddr.Text = "" : Me.btnASNMsg.Visible = False

                If Not Me.cboOpenOrderTobeFilled.SelectedValue > 0 Then
                    Me.dbgDetail.DataSource = Nothing
                    Exit Sub
                End If

                If Me.lstManifest.Items.Count > 0 Then
                    MessageBox.Show("You must close the current PO before you can select another PO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                End If

                'PO data
                Me._dtSelectedOrder = Me._objVivint_FulFillOrder.getSelectedOrderData(Me.cboOpenOrderTobeFilled.SelectedValue)
                If Not Me._dtSelectedOrder.Rows.Count > 0 Then
                    MessageBox.Show("No PO data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                ElseIf Me._dtSelectedOrder.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate POs. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                ElseIf Not Me._dtSelectedOrder.Rows(0).IsNull("ShipDate") Then
                    MessageBox.Show("This PO ship date is not null, which may be fulfilled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                End If
                strAddress = Me._dtSelectedOrder.Rows(0).Item("CustomerFirstName") & ", " & Me._dtSelectedOrder.Rows(0).Item("CustomerAddress1") & _
                             ", " & Me._dtSelectedOrder.Rows(0).Item("CustomerCity") & ", " & Me._dtSelectedOrder.Rows(0).Item("CustomerState") & _
                             " " & Me._dtSelectedOrder.Rows(0).Item("CustomerPostalCode")

                'PO Detail data
                Me._dtSelectedOrderDetail = Me._objVivint_FulFillOrder.getSelectedOrderDetailData(Me.cboOpenOrderTobeFilled.SelectedValue)
                If Not Me._dtSelectedOrderDetail.Rows.Count > 0 Then
                    MessageBox.Show("No detail data for this PO. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                End If

                'Now ready
                Me.BindDetailData(Me._dtSelectedOrderDetail)
                Me.lblShipToAddr.Text = strAddress
                Me.dbgDetail.Visible = True : Me.btnASNMsg.Visible = True

                Me.txtManifest.Enabled = True
                Me.txtManifest.Text = "" : Me.txtManifest.SelectAll() : Me.txtManifest.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub cboOpenOrderTobeFilled_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindDetailData(ByVal dt As DataTable)
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                With Me.dbgDetail
                    .DataSource = dt.DefaultView
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                    .Splits(0).DisplayColumns("SoHeaderID").Width = 0
                    .Splits(0).DisplayColumns("SoDetailsID").Width = 0
                    .Splits(0).DisplayColumns("Model_ID").Width = 0
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub BindDetailData", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub


        Private Sub btnASNMsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnASNMsg.Click
            Dim strASN_Msg As String = ""

            Try
                strASN_Msg = Me._objVivint_FulFillOrder.getSelectedOrder_ASN_Msg(Me.cboOpenOrderTobeFilled.SelectedValue)

                If strASN_Msg.Trim.Length = 0 Then strASN_Msg = "No ASN message!"
                MessageBox.Show(strASN_Msg, "ASN Msg", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnASNMsg_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub LoadAvailableManifestData()
            Dim dt As DataTable
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

            Try
                dt = Me._objVivint_FulFillOrder.getAvailableManifestData(Me._iCust_ID, PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID, "")
                With Me.dbgAvailableBoxes
                    .DataSource = dt.DefaultView
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                    .Splits(0).DisplayColumns("Pallett_ReadyToShipFlg").Width = 0
                    .Splits(0).DisplayColumns("Pallet_ShipType").Width = 0
                    .Splits(0).DisplayColumns("Model_ID").Width = 0
                    .Splits(0).DisplayColumns("PkSlip_ID").Width = 0
                    .Splits(0).DisplayColumns("Cust_ID").Width = 0
                    .Splits(0).DisplayColumns("Loc_ID").Width = 0
                    .Splits(0).DisplayColumns("Pallett_ID").Width = 0
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub LoadAvailableManifestData", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRefreshList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRefreshList.Click
            Try
                Me.LoadAvailableManifestData()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub  btnRefreshList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click, btnCopySelectedRows.Click, btnCopyManifestNo.Click
            Try
                If sender.name = "btnCopyAll" Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Misc.CopyAllData(Me.dbgAvailableBoxes)
                ElseIf sender.name = "btnCopySelectedRows" Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Misc.CopySelectedRowsData(Me.dbgAvailableBoxes)
                ElseIf sender.name = "btnCopyManifestNo" Then
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Dim strData As String = ""
                    Dim iRow As Integer
                    Dim booCompleteHeader As Boolean = False
                    Dim col As C1.Win.C1TrueDBGrid.C1DataColumn

                    If Me.dbgAvailableBoxes.SelectedRows.Count = 1 Then
                        'one row, first col
                        For Each iRow In Me.dbgAvailableBoxes.SelectedRows
                            'loop through each selected column
                            For Each col In Me.dbgAvailableBoxes.Columns
                                'data
                                strData = strData & col.CellText(iRow) ' & vbTab
                                Exit For
                            Next col
                            Exit For
                        Next iRow

                        'Copy Data to Clipboard
                        System.Windows.Forms.Clipboard.SetDataObject(strData, False)
                    Else
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Please select a row to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    col = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCopyAll_btnCopySelectedRows_Click.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub txtManifest_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtManifest.KeyUp
            Try

                If e.KeyCode = Keys.Enter Then
                    If Me.txtManifest.Text.Trim.Length > 0 AndAlso Me._dtSelectedOrderDetail.Rows.Count > 0 Then
                        Me.ProcessManifest()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtManifest_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessManifest()
            Dim strManifestNo As String = Me.txtManifest.Text.Trim
            Dim dt, dtDevice As DataTable
            Dim row, row2 As DataRow
            Dim iMP_Qty As Integer = 0
            Dim iCountEq As Integer = 0, iCountGt As Integer = 0

            Try
                Me.txtManifest.Enabled = True

                'Check if PO model_ID is valid
                For Each row In Me._dtSelectedOrderDetail.Rows
                    If Not Convert.ToInt32(row("Model_ID")) > 0 Then
                        MessageBox.Show("This PO has invalid Model_ID. Item (model) may be not defined in the system. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtManifest.Text = "" : Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                    End If
                Next

                'If no manifest added, then Shipped_Qty must be 0 but Order_qty >0 for all items for the PO. Otherwise, invalid
                If Not Me.lstManifest.Items.Count > 0 Then
                    For Each row In Me._dtSelectedOrderDetail.Rows
                        If Convert.ToInt32(row("Shipped_Qty")) > 0 Then
                            MessageBox.Show("PO shipped_qty must be 0 before fill it. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                        End If
                        If Not Convert.ToInt32(row("Order_Qty")) > 0 Then
                            MessageBox.Show("PO order_qty can't be 0. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtManifest.Text = "" : Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                        End If
                    Next
                Else 'check if PO has been fulfilled completely
                    iCountEq = 0 : iCountGt = 0
                    For Each row In Me._dtSelectedOrderDetail.Rows
                        If Convert.ToInt32(row("Shipped_Qty")) = Convert.ToInt32(row("Order_Qty")) Then
                            iCountEq += 1
                        ElseIf Convert.ToInt32(row("Shipped_Qty")) > Convert.ToInt32(row("Order_Qty")) Then
                            iCountGt += 1
                        End If
                    Next

                    If iCountGt > 0 Then
                        MessageBox.Show("PO order_qty are over filled. See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManifest.Text = "" : Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                    ElseIf iCountEq = Me._dtSelectedOrderDetail.Rows.Count Then
                        MessageBox.Show("PO has been fulfilled. Ready to complete it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManifest.Enabled = False
                        Me.btnFillOrder.Enabled = True : Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus() : Exit Sub
                    End If
                End If

                'PO must have distinct Model_IDs, not dup items
                If Not Me.lstManifest.Items.Count > 0 Then
                    Dim arrLst_tmp As New ArrayList()
                    For Each row In Me._dtSelectedOrderDetail.Rows
                        If Not arrLst_tmp.Contains(row("Model_ID")) Then arrLst_tmp.Add(row("Model_ID"))
                    Next
                    If Not arrLst_tmp.Count = Me._dtSelectedOrderDetail.Rows.Count Then 'has dup model_ID
                        MessageBox.Show("PO has duplicate items. Can't fill it. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtManifest.Text = "" : Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                    End If
                End If

                'Check if Manifest Numner already exist in the list box (already filled)
                If Me.lstManifest.Items.Count > 0 Then
                    Dim kStep As Integer = 0, strTmpManifestNo As String = ""
                    For kStep = 0 To Me.lstManifest.Items.Count - 1
                        strTmpManifestNo = Me.lstManifest.Items(kStep)
                        If strTmpManifestNo.Trim.ToUpper = strManifestNo.Trim.ToUpper Then
                            MessageBox.Show("This manifest is already in the list. Can't use it again.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                        End If
                    Next
                End If

                'Get available manifest data
                dt = Me._objVivint_FulFillOrder.getAvailableManifestData(Me._iCust_ID, PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID, strManifestNo)

                If Not dt.Rows.Count > 0 Then
                    MessageBox.Show("No data for this manifest.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                End If

                'Check device qty and model_ID and pallet qty and model_ID each box for the manifest
                For Each row2 In dt.Rows
                    dtDevice = Me._objVivint_FulFillOrder.getDeviceData(row2("Pallett_ID"))
                    If Not dtDevice.Rows.Count = row2("Pallett_Qty") Then
                        MessageBox.Show("Pallet (Pallett_ID=" & row2("Pallett_ID") & ") item Qty doesn't match the device Qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                    End If
                    For Each row In dtDevice.Rows
                        If Not row("Model_ID") = row2("Model_ID") Then
                            MessageBox.Show("Pallet (Pallett_ID=" & row2("Pallett_ID") & ") model_ID doesn't match the device model_ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                        End If
                    Next
                Next

                'check model,qty--------------------------------------------------------------------------------------------------------------------------
                'Need this only if manifest fill the PO exactly. 
                'If Not Me._dtSelectedOrderDetail.Rows.Count = dt.Rows.Count Then
                '    MessageBox.Show("Manifest item count doesn't match the PO item count.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '    Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                'End If
                'For Each row In Me._dtSelectedOrderDetail.Rows
                '    For Each row2 In dt.Rows
                '        If Not row("Model_ID") = row2("Model_ID") Then
                '            MessageBox.Show("Manifest item (model) doesn't match the PO item (model).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '            Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                '        End If
                '        If Not row("Order_Qty") = row2("Pallett_Qty") Then
                '            MessageBox.Show("Manifest item Qty doesn't match the PO item Qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                '            Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                '        Else
                '            row.BeginEdit() : row("Shipped_Qty") = row2("Pallett_Qty") : row.EndEdit()
                '        End If
                '    Next
                'Next

                'Now allow to fill PO (either single item or multiple items) by multiple manifest=======================================================
                For Each row2 In dt.Rows 'each pallet for the manifest, same model in the manifest, so just use one model
                    Dim bFoundModel As Boolean = False
                    For Each row In Me._dtSelectedOrderDetail.Rows
                        If row("Model_ID") = row2("Model_ID") Then
                            bFoundModel = True : Exit For
                        End If
                    Next
                    If Not bFoundModel Then
                        MessageBox.Show("The manifest item doesn't match any item of the PO. Can't fill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                    End If
                    Exit For
                Next

                iMP_Qty = Convert.ToInt32(dt.Compute("SUM(Pallett_Qty)", String.Empty)) 'qty of all pallets (same model) of the manifest
                For Each row2 In dt.Rows
                    Dim bOk2Fill As Boolean = False
                    For Each row In Me._dtSelectedOrderDetail.Rows
                        If row("Model_ID") = row2("Model_ID") Then 'found model
                            If iMP_Qty <= Convert.ToInt32(row("Order_Qty")) - Convert.ToInt32(row("Shipped_Qty")) Then
                                bOk2Fill = True
                                row.BeginEdit() : row("Shipped_Qty") = Convert.ToInt32(row("Shipped_Qty")) + iMP_Qty : row.EndEdit()
                                Exit For
                            End If
                        End If
                    Next
                    If Not bOk2Fill Then
                        MessageBox.Show("Qty of the manifest is greater than order item qty. Can't fill. Try another one.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtManifest.SelectAll() : Me.txtManifest.Focus() : Exit Sub
                    End If
                    Exit For
                Next

                'Ready to add
                If Not Me.lstManifest.Items.Count > 0 Then Me._dtFilledManifestData = dt.Clone 'clone columns
                For Each row In dt.Rows 'add pallet(s) of the manifest
                    Me._dtFilledManifestData.ImportRow(row)
                Next
                Me.lstManifest.Items.Add(strManifestNo)

                Me.txtManifest.Text = ""
                Me.cboOpenOrderTobeFilled.Enabled = False

                'Check if fulfilled PO
                If Me.lstManifest.Items.Count > 0 Then
                    iCountEq = 0 : iCountGt = 0
                    For Each row In Me._dtSelectedOrderDetail.Rows
                        If Convert.ToInt32(row("Shipped_Qty")) = Convert.ToInt32(row("Order_Qty")) Then
                            iCountEq += 1
                        ElseIf Convert.ToInt32(row("Shipped_Qty")) > Convert.ToInt32(row("Order_Qty")) Then
                            iCountGt += 1
                        End If
                    Next

                    If iCountGt > 0 Then
                        MessageBox.Show("PO order_qty are over filled. See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManifest.Text = "" : Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                    ElseIf iCountEq = Me._dtSelectedOrderDetail.Rows.Count Then
                        MessageBox.Show("PO has been fulfilled. Ready to complete it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManifest.Enabled = False
                        Me.btnFillOrder.Enabled = True : Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcecssManifest", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnFillOrder_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFillOrder.Click
            Dim i As Integer = 0
            Dim strDate = Format(Now, "yyyy-MM-dd")
            Dim iWO_ID As Integer = 0
            Dim strPackSlip_IDs As String = ""
            Dim iWeight As Integer = 0
            Dim iCountEq As Integer = 0
            Dim iCountGt As Integer = 0
            Dim iCountLs As Integer = 0
            Dim row As DataRow
            'Dim i As Integer = 0

            Try
                If Me.lstManifest.Items.Count > 0 Then
                    iCountEq = 0 : iCountGt = 0
                    If Not Me.lstManifest.Items.Count = UniqueManifestCount(Me._dtFilledManifestData) Then
                        MessageBox.Show("Invalid manifest data. See IT", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManifest.Text = "" : Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                    End If

                    For Each row In Me._dtSelectedOrderDetail.Rows
                        If Convert.ToInt32(row("Shipped_Qty")) = Convert.ToInt32(row("Order_Qty")) Then
                            iCountEq += 1
                        ElseIf Convert.ToInt32(row("Shipped_Qty")) > Convert.ToInt32(row("Order_Qty")) Then
                            iCountGt += 1
                        Else
                            iCountLs += 1
                        End If
                    Next

                    If iCountGt > 0 Then
                        MessageBox.Show("PO order_qty are over filled. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManifest.Text = "" : Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                    ElseIf iCountEq = Me._dtSelectedOrderDetail.Rows.Count Then
                        '  MessageBox.Show("PO has been fulfilled. Ready to complete it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManifest.Enabled = False
                    ElseIf iCountLs > 0 Then
                        MessageBox.Show("PO hasn't been fulfilled completely.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtManifest.Enabled = True : Me.txtManifest.SelectAll() : Me.txtManifest.Focus()
                        Me.btnFillOrder.Enabled = False : Exit Sub
                    End If
                Else
                    MessageBox.Show("PO hasn't been fulfilled yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtManifest.Text = "" : Me.cboOpenOrderTobeFilled.Focus() : Exit Sub
                End If

                If Not Me.txtTrackingNo.Text.Trim.Length > 0 Then
                    MessageBox.Show("Please enter a tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtTrackingNo.SelectAll() : Me.txtTrackingNo.Focus()
                    Me.btnFillOrder.Enabled = True : Exit Sub
                End If
                If Not Me.txtBOL.Text.Trim.Length > 0 Then
                    MessageBox.Show("Please enter a BOL number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtBOL.SelectAll() : Me.txtBOL.Focus()
                    Me.btnFillOrder.Enabled = True : Exit Sub
                End If


                'READY
                If IsNumeric(Me.txtBoxWeight.Text) Then
                    iWeight = Convert.ToInt32(Me.txtBoxWeight.Text)
                Else
                    MessageBox.Show("Invalid weight.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Me.txtBoxWeight.SelectAll() : Me.txtBoxWeight.Focus() : Exit Sub
                End If

                iWO_ID = Me.cboOpenOrderTobeFilled.DataSource.Table.Select("SoHeaderID = " & Me.cboOpenOrderTobeFilled.SelectedValue)(0)("WorkOrderID")

                'For i = 0 To Me.lstManifest.Items.Count - 1
                '    If i = 0 Then
                '        strPackSlip_IDs = Me.lstManifest.Items(i)
                '    Else
                '        strPackSlip_IDs &= "," & Me.lstManifest.Items(i)
                '    End If
                'Next
                For Each row In Me._dtFilledManifestData.Rows
                    If strPackSlip_IDs.Trim.Length = 0 Then
                        strPackSlip_IDs = Convert.ToString(row("PkSlip_ID"))
                    Else
                        strPackSlip_IDs &= "," & Convert.ToString(row("PkSlip_ID"))
                    End If
                Next

                'fill order
                i = Me._objVivint_FulFillOrder.CompletePO_Fulfillment(iWO_ID, Me.cboOpenOrderTobeFilled.SelectedValue, strDate, Me._iUserID, Me._dtSelectedOrderDetail, strPackSlip_IDs, _
                                                                     Me.txtTrackingNo.Text.Trim, Me.txtCarrier.Text.Trim, iWeight, Me.txtBOL.Text.Trim)

                'Print lables and packing slip report
                i = Me._objVivint_FulFillOrder.PrintShipLabelAndPackSlip(strDate, Me._dtSelectedOrder, Me._dtFilledManifestData, True, True)


                'Reset new
                Me.cboOpenOrderTobeFilled.Enabled = True
                Me.dbgDetail.DataSource = Nothing

                Me._dtSelectedOrder.Clear()
                Me._dtSelectedOrderDetail.Clear()
                Me._dtFilledManifestData.Clear()

                Me.btnFillOrder.Enabled = False
                Me.txtBoxWeight.Text = "" : Me.txtCarrier.Text = "" : Me.txtTrackingNo.Text = ""
                Me.txtManifest.Text = ""
                Me.lstManifest.Items.Clear()
                Me.LoadAvailableManifestData()
                Me.PopulateOpenOrder()
                Me.cboOpenOrderTobeFilled.SelectedValue = 0

                Me.cboOpenOrderTobeFilled.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnFillOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnRemoveOneManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOneManifest.Click
            Dim strManifestNo As String = ""
            Dim strS As String = ""
            Dim i As Integer = 0
            Dim row As DataRow
            Dim bFound As Boolean = False
            Dim iItemQty_Removed As Integer = 0
            Dim iModel_ID_Manifest As Integer = 0
            Dim iModel_ID_Order As Integer = 0
            Dim bRemoved As Boolean = False
            Dim arrLstUniqueManifestNo As New ArrayList()

            Try
                If Not Me.lstManifest.Items.Count > 0 Then Exit Sub

                strManifestNo = InputBox("Enter Manifest No:", "Manifest No", "")

                If Not strManifestNo.Trim.Length > 0 Then Exit Sub

                For i = 0 To Me.lstManifest.Items.Count - 1
                    strS = Me.lstManifest.Items(i)
                    If strManifestNo.Trim.ToUpper = strS.Trim.ToUpper Then
                        bFound = True : Exit For
                    End If
                Next

                If bFound Then
                    If MsgBox("Do you want to delete this manifest " & strManifestNo & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        For i = Me._dtFilledManifestData.Rows.Count - 1 To 0 Step -1
                            strS = Me._dtFilledManifestData.Rows(i).Item("Manifest_No")
                            If strManifestNo.Trim.ToUpper = strS.Trim.ToUpper Then
                                iModel_ID_Manifest = Convert.ToInt32(Me._dtFilledManifestData.Rows(i).Item("Model_ID")) 'Model_ID is the same winthin the same manifest
                                iItemQty_Removed += Convert.ToInt32(Me._dtFilledManifestData.Rows(i).Item("Pallett_Qty"))
                                Me._dtFilledManifestData.Rows.RemoveAt(i) : Me._dtFilledManifestData.AcceptChanges()
                                bRemoved = True
                            End If
                        Next

                        If bRemoved Then
                            Me.lstManifest.Items.Clear()
                            For Each row In Me._dtFilledManifestData.Rows
                                strS = row("Manifest_No")
                                If Not Me.lstManifest.Items.Contains(strS) Then Me.lstManifest.Items.Add(strS)
                            Next

                            'Adjust Ship Qty in the orderdetail data
                            For Each row In Me._dtSelectedOrderDetail.Rows
                                iModel_ID_Order = Convert.ToInt32(row("Model_ID"))
                                If iModel_ID_Order = iModel_ID_Manifest Then ' found it, update shipped_qty
                                    row.BeginEdit() : row("Shipped_Qty") = row("Shipped_Qty") - iItemQty_Removed : row.AcceptChanges()
                                    Exit For
                                End If
                            Next

                            Me.txtManifest.Text = "" : Me.txtManifest.Enabled = True : Me.txtManifest.Focus()
                        Else
                            MessageBox.Show("Not successfully removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                Else
                    MessageBox.Show("Can't find this manifest in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnRemoveOneMnifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnRemoveAllManifest_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRemoveAllManifest.Click
            Dim row As DataRow

            Try
                If Not Me.lstManifest.Items.Count > 0 Then Exit Sub

                If MsgBox("Do you want to delete all manifest?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Me._dtFilledManifestData.Clear()
                    Me.lstManifest.Items.Clear()
                    'Adjust Shipped_qty =0  in the orderdetail data
                    For Each row In Me._dtSelectedOrderDetail.Rows
                        row.BeginEdit() : row("Shipped_Qty") = 0 : row.AcceptChanges()
                    Next

                    Me.txtManifest.Text = "" : Me.txtManifest.Enabled = True : Me.txtManifest.Focus()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllManifest_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnReprintBoxLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Try
                Me.ReprintLabelAndPackSlip(True, False)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnReprintPackingList_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintPackingList.Click
            Try
                Me.ReprintLabelAndPackSlip(False, True)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintPackingList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ReprintLabelAndPackSlip(ByVal bPrintLabel As Boolean, ByVal bPrintPackingSlip As Boolean)
            Dim strPO As String = ""
            Dim dtPO As DataTable
            Dim dtPoDetail As DataTable
            Dim dtManifest As DataTable
            Dim iSoHeaderID As Integer = 0
            Dim strShippedDate As String = ""
            Dim i As Integer = 0

            Try
                strPO = InputBox("Enter PO:", "PO", "")

                If Not strPO.Trim.Length > 0 Then Exit Sub

                'SoHeaderID, Cust_ID, PONumber, CustomerOrderNumber, WorkOrderID, PODate, CustomerFirstName, CustomerAddress1, CustomerCity, CustomerState
                ', CustomerPostalCode, CustomerCountry, CustomerPhone, ShipDate, BillTo_Name, BillTo_Address1, BillTo_City, BillTo_State, BillTo_PostalCode
                ', BillTo_Country, BillTo_Phone, WO_ID, WO_CustWO, WO_Date, WO_Quantity, WO_RAQnty, Loc_ID, WO_Closed
                dtPO = Me._objVivint_FulFillOrder.getSelectedOrderData(0, Me._iCust_ID, strPO)

                If Not dtPO.Rows.Count > 0 Then
                    MessageBox.Show("No data for this PO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                ElseIf dtPO.Rows.Count > 1 Then
                    MessageBox.Show("Found duplicate PO. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf dtPO.Rows(0).IsNull("ShipDate") OrElse Convert.ToString(dtPO.Rows(0).Item("ShipDate")).Trim.Length = 0 OrElse Not IsDate(dtPO.Rows(0).Item("ShipDate")) Then
                    MessageBox.Show("Po has no shipped date or invalid shipped date. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                iSoHeaderID = Convert.ToInt32(dtPO.Rows(0).Item("SoHeaderID"))
                strShippedDate = Format(CDate(Convert.ToString(dtPO.Rows(0).Item("ShipDate")).Trim), "yyyy-MM-dd")

                dtPoDetail = Me._objVivint_FulFillOrder.getSelectedOrderDetailData(iSoHeaderID)
                If Not dtPoDetail.Rows.Count > 0 Then
                    MessageBox.Show("This fulfilled PO has PO data, but detail order data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                'Manifest_No, pkslip_Date, Pallett_Name, Pallett_ShipDate, PSS_Model, ShippedModel, ShippedModel_Desc, Pallett_Qty, Pallett_ReadyToShipFlg
                ', Pallet_ShipType, Model_ID, PkSlip_ID, Cust_ID, Loc_ID, Pallett_ID, pkslip_ID
                dtManifest = Me._objVivint_FulFillOrder.getAvailableManifestData(Me._iCust_ID, PSS.Data.Buisness.VV.Vivint.Vivint_VRQA_Loc_ID, "", iSoHeaderID)
                If Not dtManifest.Rows.Count > 0 Then
                    MessageBox.Show("This fulfilled PO has PO data, but manifest data. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                i = Me._objVivint_FulFillOrder.PrintShipLabelAndPackSlip(strShippedDate, dtPO, dtManifest, bPrintLabel, bPrintPackingSlip)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, " btnReprintPackingList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnPrinterInfo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrinterInfo.Click
            Dim strMsg As String = ""

            Try
                strMsg = "Pallet Label(s) (Size 6x4) requires a label printer and the label printer name must be ""LabelPrinter""" & Environment.NewLine
                strMsg &= "Manifest Slip requires a regular printer and set it as default printer."

                MessageBox.Show(strMsg, "About Printers", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprintPackingList_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Function UniqueManifestCount(ByVal dtManifest As DataTable) As Integer
            Dim arrLst As New ArrayList()
            Dim row As DataRow

            Try
                For Each row In dtManifest.Rows
                    If Not arrLst.Contains(row("Manifest_No")) Then arrLst.Add(row("Manifest_No"))
                Next
                Return arrLst.Count
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Function UniqueManifestCount", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        Private Sub btnRefreshPOForInvoiceNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshPOForInvoiceNo.Click
            Try
                Me.PopulateOpenOrderForInvoiceNo()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnRefreshPOForInvoiceNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub cboPOForInvoiceNo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPOForInvoiceNo.SelectedValueChanged
            Try
                If Me.cboPOForInvoiceNo.SelectedValue > 0 Then
                    Me.txtInvoiceNo.Enabled = True
                    Me.txtInvoiceNo.SelectAll() : Me.txtInvoiceNo.Text = "" : Me.txtInvoiceNo.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub cboPOForInvoiceNo_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub btnAddInvoiceNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddInvoiceNo.Click
            Dim strInvoiceNo As String = ""
            Dim strOldInvoiceNo As String = ""

            Try
                If Me.cboPOForInvoiceNo.SelectedValue > 0 Then
                    strInvoiceNo = Me.txtInvoiceNo.Text.Trim
                    If strInvoiceNo.Length > 0 Then
                        strOldInvoiceNo = Me._objVivint_FulFillOrder.getInvoiceNumber(Me.cboPOForInvoiceNo.SelectedValue)
                        If strOldInvoiceNo.Trim.Length > 0 AndAlso MsgBox("This PO already has invoice number: " & strOldInvoiceNo & ". Do you want to update it?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            Me._objVivint_FulFillOrder.AddInvoiceNumber(Me.cboPOForInvoiceNo.SelectedValue, strInvoiceNo)
                        ElseIf strOldInvoiceNo.Trim.Length = 0 Then
                            Me._objVivint_FulFillOrder.AddInvoiceNumber(Me.cboPOForInvoiceNo.SelectedValue, strInvoiceNo)
                        End If
                        Me.txtInvoiceNo.SelectAll() : Me.txtInvoiceNo.Text = ""
                        Me.cboPOForInvoiceNo.SelectedValue = 0
                    Else
                        MessageBox.Show("Entter invoice number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Me.txtInvoiceNo.SelectAll() : Me.txtInvoiceNo.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Sub btnAddInvoiceNo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub


#Region "Tab ControlDrawItem and selected"
        '***************************************************************************************************************
        Private Sub TabControl1_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles TabControl1.DrawItem
            Try
                Dim g As Graphics = e.Graphics
                Dim tp As TabPage = TabControl1.TabPages(e.Index)
                Dim br As Brush
                Dim sf As New StringFormat()
                Dim r As New RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2)
                Dim xFont As Font
                sf.Alignment = StringAlignment.Center
                Dim strTitle As String = tp.Text
                'If the current index is the Selected Index, change the color
                If TabControl1.SelectedIndex = e.Index Then
                    'this is the background color of the tabpage
                    'you could make this a stndard color for the selected page
                    br = New SolidBrush(tp.BackColor)
                    'this is the background color of the tab page
                    g.FillRectangle(br, e.Bounds)
                    'this is the background color of the tab page
                    'you could make this a stndard color for the selected page
                    br = New SolidBrush(tp.ForeColor)
                    'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                    xFont = New Font(TabControl1.Font, FontStyle.Bold)
                    g.DrawString(strTitle, xFont, br, r, sf)
                Else
                    'these are the standard colors for the unselected tab pages
                    br = New SolidBrush(Color.WhiteSmoke)
                    g.FillRectangle(br, e.Bounds)
                    br = New SolidBrush(Color.Black)
                    'g.DrawString(strTitle, TabControl1.Font, br, r, sf)

                    xFont = New Font(TabControl1.Font, FontStyle.Regular)
                    g.DrawString(strTitle, xFont, br, r, sf)
                End If
            Catch ex As Exception
            End Try
        End Sub

        'Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        '    If TabControl1.SelectedTab Is Me.tabPrekit Then
        '        If Me.txtPrekitCardSN.Enabled AndAlso Me.txtPrekitInsertPN.Text.Trim.Length = 0 Then
        '            Me.txtPrekitCardSN.SelectAll() : Me.txtPrekitCardSN.Focus()
        '            Me.txtPrekitInsertPN.Enabled = False
        '        End If
        '    ElseIf TabControl1.SelectedTab Is Me.tabOrder Then
        '        If Me.txtSIMCardSN.Enabled AndAlso Me.txtInsertPartNo.Text.Trim.Length = 0 Then
        '            Me.txtSIMCardSN.SelectAll() : Me.txtSIMCardSN.Focus()
        '            Me.txtInsertPartNo.Enabled = False
        '        End If
        '    End If
        'End Sub
#End Region



    End Class
End Namespace
