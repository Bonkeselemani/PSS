Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text
Imports System.Reflection.MethodBase

Namespace Gui.Vinsmart

    Public Class frmVinsmart_Receiving
        Inherits System.Windows.Forms.Form


        Private _iCust_ID As Integer = 0
        Private _iLoc_ID As Integer = 0
        Private _iLoc_ID_Seed As Integer = 0
        Private _strScreenName As String = ""

        Private _iMachineCCID As Integer = 0
        Private _iMachineCCGroupID As Integer = 0
        Private _strMachineCCDesc As String = ""

        Private _objVinsmart As PSS.Data.Buisness.Vinsmart.Vinsmart
        Private _objVinsmart_Receiving As PSS.Data.Buisness.Vinsmart.Vinsmart_Receiving
        Private _objVinsmart_BoxShip As PSS.Data.Buisness.Vinsmart.Vinsmart_BoxShip
        Private _RecvVinsmartDT As DataTable
        Private _RecvVinsmartDT_Seed As DataTable
        Private _iRecID As Integer = 0
        Private _iWB_ID As Integer = 0
        Private _strRecvBoxName As String = ""
        Private _iRecID_Seed As Integer = 0
        Private _iWB_ID_Seed As Integer = 0
        Private _strRecvBoxName_Seed As String = ""

        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User

#Region " Windows Form Designer generated code "
        Public Sub New(ByVal strScreenName As String, ByVal iCust_ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iCust_ID = iCust_ID
            ' Me._iLoc_ID = iLoc_ID
            Me._strScreenName = strScreenName
            Me._objVinsmart = New PSS.Data.Buisness.Vinsmart.Vinsmart()
            Me._objVinsmart_Receiving = New PSS.Data.Buisness.Vinsmart.Vinsmart_Receiving()
            Me._objVinsmart_BoxShip = New PSS.Data.Buisness.Vinsmart.Vinsmart_BoxShip()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objVinsmart = Nothing
                    Me._objVinsmart_Receiving = Nothing
                    Me._objVinsmart_BoxShip = Nothing
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
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents txtMaxBoxQty As System.Windows.Forms.TextBox
        Friend WithEvents lblMaxBoxQty As System.Windows.Forms.Label
        Friend WithEvents txtReceivedQty As System.Windows.Forms.TextBox
        Friend WithEvents lblReceivedQty As System.Windows.Forms.Label
        Friend WithEvents tdgDeviceData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnCloseBox As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents rbtByPoNumber As System.Windows.Forms.RadioButton
        Friend WithEvents rbtBySN As System.Windows.Forms.RadioButton
        Friend WithEvents rbtByBoxName As System.Windows.Forms.RadioButton
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents lblSku_Desc As System.Windows.Forms.Label
        Friend WithEvents lblblblSKU_Desc As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents txtManufDate As System.Windows.Forms.TextBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents lblManufDate As System.Windows.Forms.Label
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
        Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
        Friend WithEvents btnAddData As System.Windows.Forms.Button
        Friend WithEvents lblBoxName_Seed As System.Windows.Forms.Label
        Friend WithEvents txtMaxBoxQty_Seed As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents txtReceivedQty_Seed As System.Windows.Forms.TextBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents rbtByPoNumber_Seed As System.Windows.Forms.RadioButton
        Friend WithEvents rbtBySN_Seed As System.Windows.Forms.RadioButton
        Friend WithEvents rbtByBoxName_Seed As System.Windows.Forms.RadioButton
        Friend WithEvents btnReprintBoxLabel_Seed As System.Windows.Forms.Button
        Friend WithEvents btnCloseBox_Seed As System.Windows.Forms.Button
        Friend WithEvents tdgDeviceData_Seed As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblDOA_Seed As System.Windows.Forms.Label
        Friend WithEvents cboDOA_Seed As C1.Win.C1List.C1Combo
        Friend WithEvents lblModel_Seed As System.Windows.Forms.Label
        Friend WithEvents cboModel_Seed As C1.Win.C1List.C1Combo
        Friend WithEvents pnlReceived_Seed As System.Windows.Forms.Panel
        Friend WithEvents lblAccountDOA_Seed As System.Windows.Forms.Label
        Friend WithEvents lblRecModel_Seed As System.Windows.Forms.Label
        Friend WithEvents lblRecCustLoc_Seed As System.Windows.Forms.Label
        Friend WithEvents lblRecManufDate_Seed As System.Windows.Forms.Label
        Friend WithEvents lblRecSN_Seed As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtSN_Seed As System.Windows.Forms.TextBox
        Friend WithEvents txtManufDate_Seed As System.Windows.Forms.TextBox
        Friend WithEvents lblLocation_Seed As System.Windows.Forms.Label
        Friend WithEvents cboLocation_Seed As C1.Win.C1List.C1Combo
        Friend WithEvents lblManufDate_Seed As System.Windows.Forms.Label
        Friend WithEvents lblBcCount As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmVinsmart_Receiving))
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.txtMaxBoxQty = New System.Windows.Forms.TextBox()
            Me.lblMaxBoxQty = New System.Windows.Forms.Label()
            Me.txtReceivedQty = New System.Windows.Forms.TextBox()
            Me.lblReceivedQty = New System.Windows.Forms.Label()
            Me.tdgDeviceData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.rbtByPoNumber = New System.Windows.Forms.RadioButton()
            Me.rbtBySN = New System.Windows.Forms.RadioButton()
            Me.rbtByBoxName = New System.Windows.Forms.RadioButton()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.lblSku_Desc = New System.Windows.Forms.Label()
            Me.lblblblSKU_Desc = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.txtManufDate = New System.Windows.Forms.TextBox()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.lblManufDate = New System.Windows.Forms.Label()
            Me.TabPage2 = New System.Windows.Forms.TabPage()
            Me.TextBox2 = New System.Windows.Forms.TextBox()
            Me.TextBox1 = New System.Windows.Forms.TextBox()
            Me.btnAddData = New System.Windows.Forms.Button()
            Me.lblBoxName_Seed = New System.Windows.Forms.Label()
            Me.txtMaxBoxQty_Seed = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.txtReceivedQty_Seed = New System.Windows.Forms.TextBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.rbtByPoNumber_Seed = New System.Windows.Forms.RadioButton()
            Me.rbtBySN_Seed = New System.Windows.Forms.RadioButton()
            Me.rbtByBoxName_Seed = New System.Windows.Forms.RadioButton()
            Me.btnReprintBoxLabel_Seed = New System.Windows.Forms.Button()
            Me.btnCloseBox_Seed = New System.Windows.Forms.Button()
            Me.tdgDeviceData_Seed = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblDOA_Seed = New System.Windows.Forms.Label()
            Me.cboDOA_Seed = New C1.Win.C1List.C1Combo()
            Me.lblModel_Seed = New System.Windows.Forms.Label()
            Me.cboModel_Seed = New C1.Win.C1List.C1Combo()
            Me.pnlReceived_Seed = New System.Windows.Forms.Panel()
            Me.lblAccountDOA_Seed = New System.Windows.Forms.Label()
            Me.lblRecModel_Seed = New System.Windows.Forms.Label()
            Me.lblRecCustLoc_Seed = New System.Windows.Forms.Label()
            Me.lblRecManufDate_Seed = New System.Windows.Forms.Label()
            Me.lblRecSN_Seed = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtSN_Seed = New System.Windows.Forms.TextBox()
            Me.txtManufDate_Seed = New System.Windows.Forms.TextBox()
            Me.lblLocation_Seed = New System.Windows.Forms.Label()
            Me.cboLocation_Seed = New C1.Win.C1List.C1Combo()
            Me.lblManufDate_Seed = New System.Windows.Forms.Label()
            Me.lblBcCount = New System.Windows.Forms.Label()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.tdgDeviceData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabPage2.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            CType(Me.tdgDeviceData_Seed, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboDOA_Seed, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModel_Seed, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlReceived_Seed.SuspendLayout()
            CType(Me.cboLocation_Seed, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblTitle
            '
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Navy
            Me.lblTitle.Location = New System.Drawing.Point(16, 0)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(424, 24)
            Me.lblTitle.TabIndex = 168
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
            Me.TabControl1.Location = New System.Drawing.Point(8, 27)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(776, 480)
            Me.TabControl1.TabIndex = 169
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBcCount, Me.lblBoxName, Me.txtMaxBoxQty, Me.lblMaxBoxQty, Me.txtReceivedQty, Me.lblReceivedQty, Me.tdgDeviceData, Me.btnCloseBox, Me.GroupBox1, Me.lblSku_Desc, Me.lblblblSKU_Desc, Me.Label1, Me.cboModel, Me.lblSN, Me.txtSN, Me.txtManufDate, Me.lblLocation, Me.cboLocation, Me.lblManufDate})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(768, 454)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "RMA Recv"
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Black
            Me.lblBoxName.Location = New System.Drawing.Point(488, 118)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(264, 21)
            Me.lblBoxName.TabIndex = 191
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtMaxBoxQty
            '
            Me.txtMaxBoxQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtMaxBoxQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMaxBoxQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtMaxBoxQty.Location = New System.Drawing.Point(488, 8)
            Me.txtMaxBoxQty.Name = "txtMaxBoxQty"
            Me.txtMaxBoxQty.ReadOnly = True
            Me.txtMaxBoxQty.Size = New System.Drawing.Size(80, 30)
            Me.txtMaxBoxQty.TabIndex = 189
            Me.txtMaxBoxQty.Text = "0"
            Me.txtMaxBoxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblMaxBoxQty
            '
            Me.lblMaxBoxQty.BackColor = System.Drawing.Color.Transparent
            Me.lblMaxBoxQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMaxBoxQty.ForeColor = System.Drawing.Color.Black
            Me.lblMaxBoxQty.Location = New System.Drawing.Point(368, 8)
            Me.lblMaxBoxQty.Name = "lblMaxBoxQty"
            Me.lblMaxBoxQty.Size = New System.Drawing.Size(120, 21)
            Me.lblMaxBoxQty.TabIndex = 190
            Me.lblMaxBoxQty.Text = "Max Qty:"
            Me.lblMaxBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtReceivedQty
            '
            Me.txtReceivedQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReceivedQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtReceivedQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtReceivedQty.Location = New System.Drawing.Point(488, 48)
            Me.txtReceivedQty.Name = "txtReceivedQty"
            Me.txtReceivedQty.ReadOnly = True
            Me.txtReceivedQty.Size = New System.Drawing.Size(80, 30)
            Me.txtReceivedQty.TabIndex = 187
            Me.txtReceivedQty.Text = "0"
            Me.txtReceivedQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'lblReceivedQty
            '
            Me.lblReceivedQty.BackColor = System.Drawing.Color.Transparent
            Me.lblReceivedQty.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReceivedQty.ForeColor = System.Drawing.Color.Black
            Me.lblReceivedQty.Location = New System.Drawing.Point(368, 48)
            Me.lblReceivedQty.Name = "lblReceivedQty"
            Me.lblReceivedQty.Size = New System.Drawing.Size(120, 21)
            Me.lblReceivedQty.TabIndex = 188
            Me.lblReceivedQty.Text = "Received Qty:"
            Me.lblReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tdgDeviceData
            '
            Me.tdgDeviceData.AllowColMove = False
            Me.tdgDeviceData.AllowColSelect = False
            Me.tdgDeviceData.AllowFilter = False
            Me.tdgDeviceData.AllowSort = False
            Me.tdgDeviceData.AllowUpdate = False
            Me.tdgDeviceData.AlternatingRows = True
            Me.tdgDeviceData.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tdgDeviceData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgDeviceData.FetchRowStyles = True
            Me.tdgDeviceData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgDeviceData.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDeviceData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgDeviceData.Location = New System.Drawing.Point(8, 152)
            Me.tdgDeviceData.Name = "tdgDeviceData"
            Me.tdgDeviceData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDeviceData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDeviceData.PreviewInfo.ZoomFactor = 75
            Me.tdgDeviceData.Size = New System.Drawing.Size(560, 264)
            Me.tdgDeviceData.TabIndex = 185
            Me.tdgDeviceData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style1{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:C" & _
            "enter;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;Fo" & _
            "reColor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
            "AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" C" & _
            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyle" & _
            "s=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>262</Height><Cap" & _
            "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
            "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
            "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
            "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
            """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
            "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
            "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 558, 262</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 558, 262</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Bl" & _
            "ob>"
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.Location = New System.Drawing.Point(575, 152)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.Size = New System.Drawing.Size(168, 40)
            Me.btnCloseBox.TabIndex = 184
            Me.btnCloseBox.Text = "Close Box"
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.LightGray
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtByPoNumber, Me.rbtBySN, Me.rbtByBoxName, Me.btnReprintBoxLabel})
            Me.GroupBox1.Location = New System.Drawing.Point(572, 200)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(184, 136)
            Me.GroupBox1.TabIndex = 186
            Me.GroupBox1.TabStop = False
            '
            'rbtByPoNumber
            '
            Me.rbtByPoNumber.Location = New System.Drawing.Point(12, 104)
            Me.rbtByPoNumber.Name = "rbtByPoNumber"
            Me.rbtByPoNumber.Size = New System.Drawing.Size(152, 24)
            Me.rbtByPoNumber.TabIndex = 185
            Me.rbtByPoNumber.Text = "By PO Number"
            '
            'rbtBySN
            '
            Me.rbtBySN.Location = New System.Drawing.Point(12, 80)
            Me.rbtBySN.Name = "rbtBySN"
            Me.rbtBySN.Size = New System.Drawing.Size(152, 24)
            Me.rbtBySN.TabIndex = 184
            Me.rbtBySN.Text = "By SN (IMEI)"
            '
            'rbtByBoxName
            '
            Me.rbtByBoxName.Location = New System.Drawing.Point(12, 56)
            Me.rbtByBoxName.Name = "rbtByBoxName"
            Me.rbtByBoxName.Size = New System.Drawing.Size(152, 24)
            Me.rbtByBoxName.TabIndex = 183
            Me.rbtByBoxName.Text = "By Box Name"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.SlateGray
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(4, 8)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(168, 40)
            Me.btnReprintBoxLabel.TabIndex = 180
            Me.btnReprintBoxLabel.Text = "Reprint Box Label"
            '
            'lblSku_Desc
            '
            Me.lblSku_Desc.BackColor = System.Drawing.Color.Transparent
            Me.lblSku_Desc.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSku_Desc.ForeColor = System.Drawing.Color.Black
            Me.lblSku_Desc.Location = New System.Drawing.Point(120, 72)
            Me.lblSku_Desc.Name = "lblSku_Desc"
            Me.lblSku_Desc.Size = New System.Drawing.Size(288, 21)
            Me.lblSku_Desc.TabIndex = 179
            Me.lblSku_Desc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblblblSKU_Desc
            '
            Me.lblblblSKU_Desc.BackColor = System.Drawing.Color.Transparent
            Me.lblblblSKU_Desc.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblblblSKU_Desc.ForeColor = System.Drawing.Color.Black
            Me.lblblblSKU_Desc.Location = New System.Drawing.Point(22, 72)
            Me.lblblblSKU_Desc.Name = "lblblblSKU_Desc"
            Me.lblblblSKU_Desc.Size = New System.Drawing.Size(96, 21)
            Me.lblblblSKU_Desc.TabIndex = 178
            Me.lblblblSKU_Desc.Text = "SKU Desc:"
            Me.lblblblSKU_Desc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(8, 48)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 21)
            Me.Label1.TabIndex = 177
            Me.Label1.Text = "Model (Sku):"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(120, 48)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(240, 21)
            Me.cboModel.TabIndex = 1
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Black
            Me.lblSN.Location = New System.Drawing.Point(40, 122)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(80, 21)
            Me.lblSN.TabIndex = 161
            Me.lblSN.Text = "SN (IMEI):"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.White
            Me.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSN.Location = New System.Drawing.Point(120, 121)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(232, 22)
            Me.txtSN.TabIndex = 3
            Me.txtSN.Text = ""
            '
            'txtManufDate
            '
            Me.txtManufDate.BackColor = System.Drawing.Color.White
            Me.txtManufDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtManufDate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtManufDate.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtManufDate.Location = New System.Drawing.Point(120, 94)
            Me.txtManufDate.Name = "txtManufDate"
            Me.txtManufDate.Size = New System.Drawing.Size(168, 22)
            Me.txtManufDate.TabIndex = 2
            Me.txtManufDate.Text = ""
            '
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(40, 16)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation.TabIndex = 166
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation
            '
            Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocation.Caption = ""
            Me.cboLocation.CaptionHeight = 17
            Me.cboLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocation.ColumnCaptionHeight = 17
            Me.cboLocation.ColumnFooterHeight = 17
            Me.cboLocation.ContentHeight = 15
            Me.cboLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocation.EditorHeight = 15
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(120, 16)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(240, 21)
            Me.cboLocation.TabIndex = 0
            Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblManufDate
            '
            Me.lblManufDate.BackColor = System.Drawing.Color.Transparent
            Me.lblManufDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManufDate.ForeColor = System.Drawing.Color.Black
            Me.lblManufDate.Location = New System.Drawing.Point(24, 94)
            Me.lblManufDate.Name = "lblManufDate"
            Me.lblManufDate.Size = New System.Drawing.Size(96, 21)
            Me.lblManufDate.TabIndex = 163
            Me.lblManufDate.Text = "Manuf. Date:"
            Me.lblManufDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.Lavender
            Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox2, Me.TextBox1, Me.btnAddData, Me.lblBoxName_Seed, Me.txtMaxBoxQty_Seed, Me.Label4, Me.txtReceivedQty_Seed, Me.Label5, Me.GroupBox2, Me.btnCloseBox_Seed, Me.tdgDeviceData_Seed, Me.lblDOA_Seed, Me.cboDOA_Seed, Me.lblModel_Seed, Me.cboModel_Seed, Me.pnlReceived_Seed, Me.Label3, Me.txtSN_Seed, Me.txtManufDate_Seed, Me.lblLocation_Seed, Me.cboLocation_Seed, Me.lblManufDate_Seed})
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Size = New System.Drawing.Size(768, 454)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Seedstock Recv"
            Me.TabPage2.Visible = False
            '
            'TextBox2
            '
            Me.TextBox2.Location = New System.Drawing.Point(680, 8)
            Me.TextBox2.Name = "TextBox2"
            Me.TextBox2.Size = New System.Drawing.Size(32, 20)
            Me.TextBox2.TabIndex = 199
            Me.TextBox2.Text = "0"
            Me.TextBox2.Visible = False
            '
            'TextBox1
            '
            Me.TextBox1.Location = New System.Drawing.Point(632, 8)
            Me.TextBox1.Name = "TextBox1"
            Me.TextBox1.Size = New System.Drawing.Size(32, 20)
            Me.TextBox1.TabIndex = 198
            Me.TextBox1.Text = "1"
            Me.TextBox1.Visible = False
            '
            'btnAddData
            '
            Me.btnAddData.Location = New System.Drawing.Point(640, 40)
            Me.btnAddData.Name = "btnAddData"
            Me.btnAddData.Size = New System.Drawing.Size(88, 40)
            Me.btnAddData.TabIndex = 197
            Me.btnAddData.Text = "Add Data"
            Me.btnAddData.Visible = False
            '
            'lblBoxName_Seed
            '
            Me.lblBoxName_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxName_Seed.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName_Seed.ForeColor = System.Drawing.Color.Black
            Me.lblBoxName_Seed.Location = New System.Drawing.Point(504, 112)
            Me.lblBoxName_Seed.Name = "lblBoxName_Seed"
            Me.lblBoxName_Seed.Size = New System.Drawing.Size(264, 21)
            Me.lblBoxName_Seed.TabIndex = 196
            Me.lblBoxName_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtMaxBoxQty_Seed
            '
            Me.txtMaxBoxQty_Seed.BackColor = System.Drawing.Color.DarkGray
            Me.txtMaxBoxQty_Seed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtMaxBoxQty_Seed.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMaxBoxQty_Seed.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtMaxBoxQty_Seed.Location = New System.Drawing.Point(496, 24)
            Me.txtMaxBoxQty_Seed.Name = "txtMaxBoxQty_Seed"
            Me.txtMaxBoxQty_Seed.ReadOnly = True
            Me.txtMaxBoxQty_Seed.Size = New System.Drawing.Size(80, 30)
            Me.txtMaxBoxQty_Seed.TabIndex = 194
            Me.txtMaxBoxQty_Seed.Text = "0"
            Me.txtMaxBoxQty_Seed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Black
            Me.Label4.Location = New System.Drawing.Point(416, 24)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 21)
            Me.Label4.TabIndex = 195
            Me.Label4.Text = "Max Qty:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtReceivedQty_Seed
            '
            Me.txtReceivedQty_Seed.BackColor = System.Drawing.Color.DarkGray
            Me.txtReceivedQty_Seed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReceivedQty_Seed.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtReceivedQty_Seed.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtReceivedQty_Seed.Location = New System.Drawing.Point(496, 64)
            Me.txtReceivedQty_Seed.Name = "txtReceivedQty_Seed"
            Me.txtReceivedQty_Seed.ReadOnly = True
            Me.txtReceivedQty_Seed.Size = New System.Drawing.Size(80, 30)
            Me.txtReceivedQty_Seed.TabIndex = 192
            Me.txtReceivedQty_Seed.Text = "0"
            Me.txtReceivedQty_Seed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.Black
            Me.Label5.Location = New System.Drawing.Point(376, 64)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(120, 21)
            Me.Label5.TabIndex = 193
            Me.Label5.Text = "Received Qty:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'GroupBox2
            '
            Me.GroupBox2.BackColor = System.Drawing.Color.DarkGray
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtByPoNumber_Seed, Me.rbtBySN_Seed, Me.rbtByBoxName_Seed, Me.btnReprintBoxLabel_Seed})
            Me.GroupBox2.Location = New System.Drawing.Point(576, 192)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(184, 136)
            Me.GroupBox2.TabIndex = 188
            Me.GroupBox2.TabStop = False
            '
            'rbtByPoNumber_Seed
            '
            Me.rbtByPoNumber_Seed.Location = New System.Drawing.Point(12, 104)
            Me.rbtByPoNumber_Seed.Name = "rbtByPoNumber_Seed"
            Me.rbtByPoNumber_Seed.Size = New System.Drawing.Size(152, 24)
            Me.rbtByPoNumber_Seed.TabIndex = 185
            Me.rbtByPoNumber_Seed.Text = "By PO Number"
            '
            'rbtBySN_Seed
            '
            Me.rbtBySN_Seed.Location = New System.Drawing.Point(12, 80)
            Me.rbtBySN_Seed.Name = "rbtBySN_Seed"
            Me.rbtBySN_Seed.Size = New System.Drawing.Size(152, 24)
            Me.rbtBySN_Seed.TabIndex = 184
            Me.rbtBySN_Seed.Text = "By SN (IMEI)"
            '
            'rbtByBoxName_Seed
            '
            Me.rbtByBoxName_Seed.Location = New System.Drawing.Point(12, 56)
            Me.rbtByBoxName_Seed.Name = "rbtByBoxName_Seed"
            Me.rbtByBoxName_Seed.Size = New System.Drawing.Size(152, 24)
            Me.rbtByBoxName_Seed.TabIndex = 183
            Me.rbtByBoxName_Seed.Text = "By Box Name"
            '
            'btnReprintBoxLabel_Seed
            '
            Me.btnReprintBoxLabel_Seed.BackColor = System.Drawing.Color.SlateGray
            Me.btnReprintBoxLabel_Seed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel_Seed.ForeColor = System.Drawing.Color.White
            Me.btnReprintBoxLabel_Seed.Location = New System.Drawing.Point(4, 8)
            Me.btnReprintBoxLabel_Seed.Name = "btnReprintBoxLabel_Seed"
            Me.btnReprintBoxLabel_Seed.Size = New System.Drawing.Size(168, 40)
            Me.btnReprintBoxLabel_Seed.TabIndex = 180
            Me.btnReprintBoxLabel_Seed.Text = "Reprint Box Label"
            '
            'btnCloseBox_Seed
            '
            Me.btnCloseBox_Seed.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCloseBox_Seed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox_Seed.ForeColor = System.Drawing.Color.White
            Me.btnCloseBox_Seed.Location = New System.Drawing.Point(576, 144)
            Me.btnCloseBox_Seed.Name = "btnCloseBox_Seed"
            Me.btnCloseBox_Seed.Size = New System.Drawing.Size(168, 40)
            Me.btnCloseBox_Seed.TabIndex = 187
            Me.btnCloseBox_Seed.Text = "Close Box"
            '
            'tdgDeviceData_Seed
            '
            Me.tdgDeviceData_Seed.AllowColMove = False
            Me.tdgDeviceData_Seed.AllowColSelect = False
            Me.tdgDeviceData_Seed.AllowFilter = False
            Me.tdgDeviceData_Seed.AllowSort = False
            Me.tdgDeviceData_Seed.AllowUpdate = False
            Me.tdgDeviceData_Seed.AlternatingRows = True
            Me.tdgDeviceData_Seed.BackColor = System.Drawing.Color.WhiteSmoke
            Me.tdgDeviceData_Seed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgDeviceData_Seed.FetchRowStyles = True
            Me.tdgDeviceData_Seed.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.tdgDeviceData_Seed.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDeviceData_Seed.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgDeviceData_Seed.Location = New System.Drawing.Point(8, 144)
            Me.tdgDeviceData_Seed.Name = "tdgDeviceData_Seed"
            Me.tdgDeviceData_Seed.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDeviceData_Seed.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDeviceData_Seed.PreviewInfo.ZoomFactor = 75
            Me.tdgDeviceData_Seed.Size = New System.Drawing.Size(560, 264)
            Me.tdgDeviceData_Seed.TabIndex = 186
            Me.tdgDeviceData_Seed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
            "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
            "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
            "tion{AlignHorz:Center;}Style9{}Normal{Font:Arial, 8.25pt;}HighlightRow{ForeColor" & _
            ":HighlightText;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:C" & _
            "enter;}Style13{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle14{}Style15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
            "AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" C" & _
            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyle" & _
            "s=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>262</Height><Cap" & _
            "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
            "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
            "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
            "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
            """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
            "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
            "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 558, 262</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 558, 262</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Bl" & _
            "ob>"
            '
            'lblDOA_Seed
            '
            Me.lblDOA_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblDOA_Seed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDOA_Seed.ForeColor = System.Drawing.Color.Black
            Me.lblDOA_Seed.Location = New System.Drawing.Point(256, 432)
            Me.lblDOA_Seed.Name = "lblDOA_Seed"
            Me.lblDOA_Seed.Size = New System.Drawing.Size(104, 21)
            Me.lblDOA_Seed.TabIndex = 177
            Me.lblDOA_Seed.Text = "DOA Selection:"
            Me.lblDOA_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblDOA_Seed.Visible = False
            '
            'cboDOA_Seed
            '
            Me.cboDOA_Seed.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDOA_Seed.Caption = ""
            Me.cboDOA_Seed.CaptionHeight = 17
            Me.cboDOA_Seed.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDOA_Seed.ColumnCaptionHeight = 17
            Me.cboDOA_Seed.ColumnFooterHeight = 17
            Me.cboDOA_Seed.ContentHeight = 15
            Me.cboDOA_Seed.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDOA_Seed.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDOA_Seed.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDOA_Seed.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDOA_Seed.EditorHeight = 15
            Me.cboDOA_Seed.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboDOA_Seed.ItemHeight = 15
            Me.cboDOA_Seed.Location = New System.Drawing.Point(368, 432)
            Me.cboDOA_Seed.MatchEntryTimeout = CType(2000, Long)
            Me.cboDOA_Seed.MaxDropDownItems = CType(5, Short)
            Me.cboDOA_Seed.MaxLength = 32767
            Me.cboDOA_Seed.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDOA_Seed.Name = "cboDOA_Seed"
            Me.cboDOA_Seed.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDOA_Seed.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDOA_Seed.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDOA_Seed.Size = New System.Drawing.Size(240, 21)
            Me.cboDOA_Seed.TabIndex = 176
            Me.cboDOA_Seed.Visible = False
            Me.cboDOA_Seed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblModel_Seed
            '
            Me.lblModel_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblModel_Seed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel_Seed.ForeColor = System.Drawing.Color.Black
            Me.lblModel_Seed.Location = New System.Drawing.Point(24, 56)
            Me.lblModel_Seed.Name = "lblModel_Seed"
            Me.lblModel_Seed.Size = New System.Drawing.Size(88, 21)
            Me.lblModel_Seed.TabIndex = 175
            Me.lblModel_Seed.Text = "Model (Sku):"
            Me.lblModel_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModel_Seed
            '
            Me.cboModel_Seed.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel_Seed.Caption = ""
            Me.cboModel_Seed.CaptionHeight = 17
            Me.cboModel_Seed.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel_Seed.ColumnCaptionHeight = 17
            Me.cboModel_Seed.ColumnFooterHeight = 17
            Me.cboModel_Seed.ContentHeight = 15
            Me.cboModel_Seed.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel_Seed.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel_Seed.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel_Seed.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel_Seed.EditorHeight = 15
            Me.cboModel_Seed.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboModel_Seed.ItemHeight = 15
            Me.cboModel_Seed.Location = New System.Drawing.Point(120, 56)
            Me.cboModel_Seed.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel_Seed.MaxDropDownItems = CType(5, Short)
            Me.cboModel_Seed.MaxLength = 32767
            Me.cboModel_Seed.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel_Seed.Name = "cboModel_Seed"
            Me.cboModel_Seed.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel_Seed.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel_Seed.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel_Seed.Size = New System.Drawing.Size(240, 21)
            Me.cboModel_Seed.TabIndex = 174
            Me.cboModel_Seed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'pnlReceived_Seed
            '
            Me.pnlReceived_Seed.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAccountDOA_Seed, Me.lblRecModel_Seed, Me.lblRecCustLoc_Seed, Me.lblRecManufDate_Seed, Me.lblRecSN_Seed, Me.Label12})
            Me.pnlReceived_Seed.Location = New System.Drawing.Point(688, 416)
            Me.pnlReceived_Seed.Name = "pnlReceived_Seed"
            Me.pnlReceived_Seed.Size = New System.Drawing.Size(56, 32)
            Me.pnlReceived_Seed.TabIndex = 173
            Me.pnlReceived_Seed.Visible = False
            '
            'lblAccountDOA_Seed
            '
            Me.lblAccountDOA_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblAccountDOA_Seed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccountDOA_Seed.ForeColor = System.Drawing.Color.DimGray
            Me.lblAccountDOA_Seed.Location = New System.Drawing.Point(72, 112)
            Me.lblAccountDOA_Seed.Name = "lblAccountDOA_Seed"
            Me.lblAccountDOA_Seed.Size = New System.Drawing.Size(240, 21)
            Me.lblAccountDOA_Seed.TabIndex = 167
            Me.lblAccountDOA_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecModel_Seed
            '
            Me.lblRecModel_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblRecModel_Seed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecModel_Seed.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecModel_Seed.Location = New System.Drawing.Point(72, 86)
            Me.lblRecModel_Seed.Name = "lblRecModel_Seed"
            Me.lblRecModel_Seed.Size = New System.Drawing.Size(240, 21)
            Me.lblRecModel_Seed.TabIndex = 166
            Me.lblRecModel_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecCustLoc_Seed
            '
            Me.lblRecCustLoc_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblRecCustLoc_Seed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecCustLoc_Seed.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecCustLoc_Seed.Location = New System.Drawing.Point(72, 68)
            Me.lblRecCustLoc_Seed.Name = "lblRecCustLoc_Seed"
            Me.lblRecCustLoc_Seed.Size = New System.Drawing.Size(240, 21)
            Me.lblRecCustLoc_Seed.TabIndex = 165
            Me.lblRecCustLoc_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecManufDate_Seed
            '
            Me.lblRecManufDate_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblRecManufDate_Seed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecManufDate_Seed.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecManufDate_Seed.Location = New System.Drawing.Point(72, 50)
            Me.lblRecManufDate_Seed.Name = "lblRecManufDate_Seed"
            Me.lblRecManufDate_Seed.Size = New System.Drawing.Size(232, 21)
            Me.lblRecManufDate_Seed.TabIndex = 164
            Me.lblRecManufDate_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblRecSN_Seed
            '
            Me.lblRecSN_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblRecSN_Seed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecSN_Seed.ForeColor = System.Drawing.Color.DimGray
            Me.lblRecSN_Seed.Location = New System.Drawing.Point(72, 32)
            Me.lblRecSN_Seed.Name = "lblRecSN_Seed"
            Me.lblRecSN_Seed.Size = New System.Drawing.Size(240, 21)
            Me.lblRecSN_Seed.TabIndex = 163
            Me.lblRecSN_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label12
            '
            Me.Label12.BackColor = System.Drawing.Color.Transparent
            Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label12.ForeColor = System.Drawing.Color.Black
            Me.Label12.Location = New System.Drawing.Point(56, 8)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(240, 21)
            Me.Label12.TabIndex = 162
            Me.Label12.Text = "Received Result:"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Black
            Me.Label3.Location = New System.Drawing.Point(40, 88)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 21)
            Me.Label3.TabIndex = 168
            Me.Label3.Text = "SN (IMEI):"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN_Seed
            '
            Me.txtSN_Seed.BackColor = System.Drawing.Color.White
            Me.txtSN_Seed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSN_Seed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN_Seed.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSN_Seed.Location = New System.Drawing.Point(120, 88)
            Me.txtSN_Seed.Name = "txtSN_Seed"
            Me.txtSN_Seed.Size = New System.Drawing.Size(232, 22)
            Me.txtSN_Seed.TabIndex = 167
            Me.txtSN_Seed.Text = ""
            '
            'txtManufDate_Seed
            '
            Me.txtManufDate_Seed.BackColor = System.Drawing.Color.White
            Me.txtManufDate_Seed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtManufDate_Seed.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtManufDate_Seed.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtManufDate_Seed.Location = New System.Drawing.Point(120, 112)
            Me.txtManufDate_Seed.Name = "txtManufDate_Seed"
            Me.txtManufDate_Seed.Size = New System.Drawing.Size(168, 22)
            Me.txtManufDate_Seed.TabIndex = 169
            Me.txtManufDate_Seed.Text = ""
            '
            'lblLocation_Seed
            '
            Me.lblLocation_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation_Seed.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation_Seed.ForeColor = System.Drawing.Color.Black
            Me.lblLocation_Seed.Location = New System.Drawing.Point(40, 24)
            Me.lblLocation_Seed.Name = "lblLocation_Seed"
            Me.lblLocation_Seed.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation_Seed.TabIndex = 172
            Me.lblLocation_Seed.Text = "Location:"
            Me.lblLocation_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation_Seed
            '
            Me.cboLocation_Seed.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocation_Seed.Caption = ""
            Me.cboLocation_Seed.CaptionHeight = 17
            Me.cboLocation_Seed.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocation_Seed.ColumnCaptionHeight = 17
            Me.cboLocation_Seed.ColumnFooterHeight = 17
            Me.cboLocation_Seed.ContentHeight = 15
            Me.cboLocation_Seed.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocation_Seed.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocation_Seed.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation_Seed.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocation_Seed.EditorHeight = 15
            Me.cboLocation_Seed.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboLocation_Seed.ItemHeight = 15
            Me.cboLocation_Seed.Location = New System.Drawing.Point(120, 24)
            Me.cboLocation_Seed.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation_Seed.MaxDropDownItems = CType(5, Short)
            Me.cboLocation_Seed.MaxLength = 32767
            Me.cboLocation_Seed.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation_Seed.Name = "cboLocation_Seed"
            Me.cboLocation_Seed.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation_Seed.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation_Seed.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation_Seed.Size = New System.Drawing.Size(240, 21)
            Me.cboLocation_Seed.TabIndex = 171
            Me.cboLocation_Seed.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'lblManufDate_Seed
            '
            Me.lblManufDate_Seed.BackColor = System.Drawing.Color.Transparent
            Me.lblManufDate_Seed.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManufDate_Seed.ForeColor = System.Drawing.Color.Black
            Me.lblManufDate_Seed.Location = New System.Drawing.Point(16, 112)
            Me.lblManufDate_Seed.Name = "lblManufDate_Seed"
            Me.lblManufDate_Seed.Size = New System.Drawing.Size(104, 21)
            Me.lblManufDate_Seed.TabIndex = 170
            Me.lblManufDate_Seed.Text = "Manuf. Date:"
            Me.lblManufDate_Seed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBcCount
            '
            Me.lblBcCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBcCount.Location = New System.Drawing.Point(360, 121)
            Me.lblBcCount.Name = "lblBcCount"
            Me.lblBcCount.Size = New System.Drawing.Size(120, 22)
            Me.lblBcCount.TabIndex = 192
            Me.lblBcCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'frmVinsmart_Receiving
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(792, 518)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTitle, Me.TabControl1})
            Me.Name = "frmVinsmart_Receiving"
            Me.Text = "frmVinsmart_Receiving"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.tdgDeviceData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabPage2.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            CType(Me.tdgDeviceData_Seed, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboDOA_Seed, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModel_Seed, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlReceived_Seed.ResumeLayout(False)
            CType(Me.cboLocation_Seed, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmVinsmart_Receiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim strCustLoc As String = ""
            Dim dtLoc, dtLoc_Seed As DataTable
            Dim iLoc_ID As Integer = 0
            Dim dtModel, dtModel_Seed As DataTable
            Dim dtDOA As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)
                TabControl1.DrawMode = TabDrawMode.OwnerDrawFixed

                Me.lblTitle.Text = Me._strScreenName

                'Initialize dt table
                Me._RecvVinsmartDT = Me._objVinsmart_Receiving.getVinsmartRecvTableDef
                Me._RecvVinsmartDT_Seed = Me._objVinsmart_Receiving.getVinsmartSeedStockRecvTableDef

                'Update Item SKU for ATT FexEx POS ASn data
                Me._objVinsmart_Receiving.FindUpdateAttFexExSkuPos()

                Me.lblblblSKU_Desc.Visible = False : Me.lblSku_Desc.Visible = False
                Me.rbtByPoNumber.Checked = False : Me.rbtByPoNumber.Visible = False 'Not every Vinsmart location has PO, so disabled it
                Me.rbtByBoxName.Checked = True
                Me.rbtByPoNumber_Seed.Checked = False : Me.rbtByPoNumber_Seed.Visible = False
                Me.rbtByBoxName_Seed.Checked = True


                'Loc info
                dtLoc = Me._objVinsmart_BoxShip.GetVinsmartLocations(Me._iCust_ID, True)
                Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
                Me.cboLocation.SelectedValue = 0

                dtLoc_Seed = Me._objVinsmart_BoxShip.GetVinsmartLocations(Me._iCust_ID, True)
                Misc.PopulateC1DropDownList(Me.cboLocation_Seed, dtLoc_Seed, "Loc_Name", "Loc_ID")
                Me.cboLocation_Seed.SelectedValue = 0

                'Model info
                dtModel = Me._objVinsmart.getVinsmartModels(Me._iCust_ID, True)
                dtModel_Seed = dtModel.Copy

                Misc.PopulateC1DropDownList(Me.cboModel, dtModel, "Model_Desc", "Model_ID")
                Me.cboModel.SelectedValue = 0
                Misc.PopulateC1DropDownList(Me.cboModel_Seed, dtModel_Seed, "Model_Desc", "Model_ID")
                Me.cboModel_Seed.SelectedValue = 0

                'Return Type
                dtDOA = Me._objVinsmart_Receiving.GetVinsmartCriketDOA(True)
                Misc.PopulateC1DropDownList(Me.cboDOA_Seed, dtDOA, "AccountDOA", "DOA_ID")
                Me.cboDOA_Seed.SelectedValue = 0

                '  Me.ClearValues()
                Me.ClearValues_Seed()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
            End Try
        End Sub
        Private Sub ClearValues_Seed()
            Try
                With Me
                    .txtSN_Seed.Text = ""
                    .txtSN_Seed.Enabled = True
                    .txtSN_Seed.Visible = True
                    .txtManufDate_Seed.Text = ""
                    .txtManufDate_Seed.Enabled = True
                    .txtManufDate_Seed.Visible = True
                    .lblRecSN_Seed.Text = ""
                    .lblRecManufDate_Seed.Text = ""
                    .lblRecModel_Seed.Text = ""
                    .lblRecCustLoc_Seed.Text = ""
                    .lblAccountDOA_Seed.Text = ""
                    '.lblVinsmartCustName_Seed.Text = ""
                    Me.pnlReceived_Seed.Visible = False
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ClearValues", MessageBoxButtons.OK, MessageBoxIcon.Error)

            End Try
        End Sub


        Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp, txtManufDate.KeyUp

            Try

                If e.KeyCode = Keys.Enter Then
                    'If Me.txtSN.Text.Trim.Length > 0 OrElse Me.txtManufDate.Text.Trim.Length > 0 Then
                    'End If
                    If Me.txtManufDate.Text.Trim.Length > 0 AndAlso Not Me.txtSN.Text.Trim.Length > 0 Then
                        Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                    ElseIf Not Me.txtManufDate.Text.Trim.Length > 0 AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                        Me.txtManufDate.Text = "" : Me.txtManufDate.SelectAll() : Me.txtManufDate.Focus()
                    End If

                    If Me.txtSN.Text.Trim.Length > 0 AndAlso Me.txtManufDate.Text.Trim.Length > 0 Then
                        ProcessSN()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(String.Concat("Method: ", GetCurrentMethod().Name, vbCrLf, ex.Message.ToString))
            End Try
        End Sub

       

        

        Private Sub ProcessSN()
            Dim strSN As String = ""
            Dim strManufDate As String = ""
            Dim dt As DataTable, dtModel As DataTable
            Dim iEW_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim strModel_Desc As String = ""
            Dim bReceived As Boolean = False
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iProd_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Product_ID
            Dim strCustLoc As String = ""
            ' Dim strVinsmartCustName As String = ""
            Dim strAccountDOA As String = ""
            Dim strAccountDOA_Code As String = ""
            Dim strASN_IN_ITEM_SKU As String = ""
            Dim strASN_IN_ITEM_SKU_Desc As String = ""
            Dim strReturnType As String = ""
            Dim strPONumber As String = ""

            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "Vinsmart Receiving"
            Dim iWrtyFlag As Integer = 0
            Dim iMaxQty As Integer = Me._objVinsmart.getMaxReceivingBoxQty

            Try
                Me.Cursor = Cursors.WaitCursor

                Me.txtReceivedQty.Text = Me._RecvVinsmartDT.Rows.Count
                If Convert.ToInt32(Me.txtReceivedQty.Text) > 0 AndAlso Convert.ToInt32(Me.txtMaxBoxQty.Text) > 0 AndAlso Convert.ToInt32(Me.txtReceivedQty.Text) >= Convert.ToInt32(Me.txtMaxBoxQty.Text) Then
                    MessageBox.Show("Box is full. Please close it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.btnCloseBox.Focus()
                    Exit Sub
                End If

                strSN = Me.txtSN.Text.Trim
                strManufDate = Me.txtManufDate.Text.Trim

                Me._iLoc_ID = Me.cboLocation.SelectedValue

                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me._iLoc_ID > 0 Then
                    MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me.cboModel.SelectedValue > 0 Then
                    MessageBox.Show("Please select a SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf strManufDate.Trim.Length = 0 Then
                    MessageBox.Show("Please enter manufacture date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me.IsValidManufDateCode(strManufDate) Then
                    MessageBox.Show("Invalid manufacture date. It should be 6 0r 8 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.IsReceivedUnshipped(Me._iLoc_ID, strSN) Then
                    MessageBox.Show("SN has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    dt = Me._objVinsmart_Receiving.getReceivingData(Me._iCust_ID, Me._iLoc_ID, strSN)

                    'get DOA desc and code
                    If dt.Rows.Count > 0 AndAlso Not dt.Rows(0).IsNull("DOA_Account") Then strAccountDOA = dt.Rows(0).Item("DOA_Account")
                    If dt.Rows.Count > 0 AndAlso Not dt.Rows(0).IsNull("DOA_Account_Code") Then strAccountDOA_Code = dt.Rows(0).Item("DOA_Account_Code")



                    Me.lblblblSKU_Desc.Visible = False : Me.lblSku_Desc.Visible = False
                    iWrtyFlag = 0


                End If

                'start to 
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Can't find the SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Duplicate SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf dt.Rows(0).IsNull("Item_SKU") OrElse Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim.Length = 0 Then
                    MessageBox.Show("No SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim.ToUpper = Convert.ToString(Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Model_Desc")).Trim.ToUpper Then
                    MessageBox.Show("Not the same SKU. This device has SKU '" & Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me._iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID AndAlso Not Me.IsValidCricketAccountDOAorEMS(strAccountDOA, strAccountDOA_Code, iWrtyFlag) Then
                    MessageBox.Show("Invalid DOA Info.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                Else '=1
                    strModel_Desc = Convert.ToString(dt.Rows(0).Item("Item_SKU"))
                    If dt.Rows(0).IsNull("Item_SKU") OrElse Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim.Length = 0 Then
                        MessageBox.Show("Inbound data has no SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else

                        strModel_Desc = Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Model_Desc")

                        If strModel_Desc.Trim.Length = 0 Then
                            MessageBox.Show("Can't find the model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else 'ok
                            iModel_ID = Me.cboModel.SelectedValue ' Convert.ToInt32(dtModel.Rows(0).Item("Model_ID"))
                            iWO_ID = Convert.ToInt32(dt.Rows(0).Item("WO_ID"))
                            iEW_ID = Convert.ToInt32(dt.Rows(0).Item("EW_ID"))
                            strCustLoc = Convert.ToString(dt.Rows(0).Item("Customer")).Trim
                            strASN_IN_ITEM_SKU = Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim
                            strASN_IN_ITEM_SKU_Desc = ""


                            iTray_ID = Me._objVinsmart_Receiving.getTayID(Me._iUserID, Me._strUser, iWO_ID, strTrayMemo)

                            If Not iModel_ID > 0 Then
                                MessageBox.Show("Invalid Model_ID '" & iModel_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf Not iWO_ID > 0 Then
                                MessageBox.Show("Invalid WO_ID '" & iWO_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ElseIf Not iTray_ID > 0 Then
                                MessageBox.Show("Invalid Tray_ID '" & iTray_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Else 'Ready to receive 
                                'Create WH box at start-------------------------------
                                If Me._RecvVinsmartDT.Rows.Count = 0 Then 'First device
                                    Dim objCoolPad_Recv As New PSS.Data.Buisness.CP.CoolPad_Receiving()
                                    Me._iWB_ID = 0 : Me._iRecID = 0
                                    Me._strRecvBoxName = objCoolPad_Recv.CreateWarehouseBoxName(iModel_ID, iWrtyFlag, Me._iWB_ID, "WK")
                                    Me.lblBoxName.Text = Me._strRecvBoxName
                                    Me.txtMaxBoxQty.Text = iMaxQty.ToString
                                    objCoolPad_Recv = Nothing
                                Else 'Validate with recev data
                                    Dim strValidatedMsg As String = Me.GoValidation(Me._iLoc_ID, Me._RecvVinsmartDT, strSN, strASN_IN_ITEM_SKU, strReturnType, strPONumber, iMaxQty).Trim
                                    If strValidatedMsg.Length > 0 Then
                                        MessageBox.Show(strValidatedMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                        Me.txtSN.Text = String.Empty
                                        Me.txtSN.Focus()
                                        Exit Sub
                                    End If
                                End If

                                bReceived = Me._objVinsmart_Receiving.ReceiveDataIntoSystem(Me._iLoc_ID, iWO_ID, iModel_ID, strSN, strManufDate, _
                                                                                        strDateTime, strWorkDate, iEW_ID, iShift_ID, iTray_ID, _
                                                                                        iDevice_ID, Me._iWB_ID, iWrtyFlag, False)
                                If bReceived Then
                                    'RecID, SN, ASN_SKU, ASN_SKU_Desc, PSS_Model, Manuf_Date, Return_Type, Vendor, PO, Loc, Vendor_ID
                                    'Model_ID(, Loc_ID, EW_ID, Device_ID, wb_ID)
                                    Dim rowNew As DataRow
                                    rowNew = Me._RecvVinsmartDT.NewRow
                                    rowNew("SN") = strSN : rowNew("ASN_SKU") = strASN_IN_ITEM_SKU : rowNew("ASN_SKU_Desc") = strASN_IN_ITEM_SKU_Desc
                                    rowNew("PSS_Model") = strModel_Desc : rowNew("Manuf_Date") = strManufDate : rowNew("Return_Type") = strReturnType
                                    rowNew("Vendor") = "" : rowNew("PO") = strPONumber : rowNew("Loc") = strCustLoc
                                    rowNew("Vendor_ID") = "" : rowNew("Model_ID") = iModel_ID : rowNew("Loc_ID") = Me._iLoc_ID
                                    rowNew("EW_ID") = iEW_ID : rowNew("Device_ID") = iDevice_ID : rowNew("wb_ID") = Me._iWB_ID
                                    Me._RecvVinsmartDT.Rows.Add(rowNew)
                                    Me.BindReceivedData()

                                    'If Me._iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then Me.lblAccountDOA.Text = strAccountDOA Else Me.lblAccountDOA.Text = ""
                                    Me.txtReceivedQty.Text = Me._RecvVinsmartDT.Rows.Count
                                    Me.txtManufDate.Text = ""

                                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus() : Me.cboLocation.Enabled = False : Me.cboModel.Enabled = False
                                Else
                                    MessageBox.Show("Failed to receive. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                End If
                            End If
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Cursor = Cursors.Default
                dt = Nothing : dtModel = Nothing
            End Try
        End Sub

        Private Sub BindReceivedData()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0
            Dim row As DataRow

            'RecID, SN, ASN_SKU, ASN_SKU_Desc, PSS_Model, Manuf_Date, Return_Type, Vendor, PO, Loc, Vendor_ID, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID

            Try
                'Update sequence RecID
                For Each row In Me._RecvVinsmartDT.Rows
                    i += 1
                    row.BeginEdit() : row("RecID") = i : row.AcceptChanges()
                Next

                'Bind received data
                With Me.tdgDeviceData
                    .DataSource = Me._RecvVinsmartDT.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                    If Me._iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                        .Splits(0).DisplayColumns("PO").Width = 0
                        .Splits(0).DisplayColumns("ASN_SKU_Desc").Width = 0
                        .Splits(0).DisplayColumns("Vendor").Width = 0
                        .Splits(0).DisplayColumns("Vendor_ID").Width = 0
                        .Splits(0).DisplayColumns("Loc_ID").Width = 0
                        .Splits(0).DisplayColumns("Model_ID").Width = 0
                        .Splits(0).DisplayColumns("Device_ID").Width = 0
                        .Splits(0).DisplayColumns("EW_ID").Width = 0
                        .Splits(0).DisplayColumns("wb_ID").Width = 0
                    End If
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub BindReceivedData_Seed()
            Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
            Dim i As Integer = 0
            Dim row As DataRow

            'RecID, SN, ASN_SKU, PSS_Model, Manuf_Date, PO, CustLoc, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID

            Try
                'Update sequence RecID
                For Each row In Me._RecvVinsmartDT_Seed.Rows
                    i += 1
                    row.BeginEdit() : row("RecID") = i : row.AcceptChanges()
                Next

                'Bind received data
                With Me.tdgDeviceData_Seed
                    .DataSource = Me._RecvVinsmartDT_Seed.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                    .Splits(0).DisplayColumns("Loc_ID").Width = 0
                    .Splits(0).DisplayColumns("Model_ID").Width = 0
                    .Splits(0).DisplayColumns("Device_ID").Width = 0
                    .Splits(0).DisplayColumns("EW_ID").Width = 0
                    .Splits(0).DisplayColumns("wb_ID").Width = 0
                End With
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


        Private Function GoValidation(ByVal iLoc_ID As Integer, ByVal RecvDT As DataTable, ByVal strSN As String, ByVal strSku As String, _
                              ByVal strReturnType As String, ByVal strPoNumber As String, ByVal iMaxQty As Integer) As String

            Dim RetMsg As String = ""
            Dim row As DataRow
            Dim foundRow() As DataRow

            Try
                'RecID, SN, ASN_SKU, ASN_SKU_Desc, PSS_Model, Manuf_Date, Return_Type, Vendor, PO, Loc, Vendor_ID, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID

                strSN = strSN.Replace("'", "''") : strSku = strSku.Replace("'", "''") : strReturnType = strReturnType.Replace("'", "''")
                strPoNumber = strPoNumber.Replace("'", "''")

                If RecvDT.Rows.Count = iMaxQty Then RetMsg &= "Box is full (max qty=" & iMaxQty.ToString & "), can't receive more." & Environment.NewLine

                foundRow = RecvDT.Select("SN='" & strSN & "'")
                If foundRow.Length > 0 Then RetMsg &= "Device '" & strSN & "' already received." & Environment.NewLine

                foundRow = RecvDT.Select("ASN_SKU='" & strSku & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same Sku." & Environment.NewLine

                If iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                    foundRow = RecvDT.Select("Return_Type='" & strReturnType & "'")
                    If foundRow.Length = 0 Then RetMsg &= "Not the same Return Type." & Environment.NewLine
                Else
                    foundRow = RecvDT.Select("PO='" & strPoNumber & "'")
                    If foundRow.Length = 0 Then RetMsg &= "Not the same PoNumber." & Environment.NewLine
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RetMsg = ex.ToString
            End Try

            Return RetMsg

        End Function

        Private Function GoValidation_Seed(ByVal RecvDT As DataTable, ByVal strSN As String, ByVal strSku As String, _
                          ByVal strPoNumber As String, ByVal iMaxQty As Integer) As String

            Dim RetMsg As String = ""
            Dim row As DataRow
            Dim foundRow() As DataRow

            Try
                'RecID, SN, ASN_SKU, PSS_Model, Manuf_Date, PO, CustLoc, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID

                strSN = strSN.Replace("'", "''") : strSku = strSku.Replace("'", "''")
                strPoNumber = strPoNumber.Replace("'", "''")

                If RecvDT.Rows.Count = iMaxQty Then RetMsg &= "Box is full (max qty=" & iMaxQty.ToString & "), can't receive more." & Environment.NewLine

                foundRow = RecvDT.Select("SN='" & strSN & "'")
                If foundRow.Length > 0 Then RetMsg &= "Device '" & strSN & "' already received." & Environment.NewLine

                foundRow = RecvDT.Select("ASN_SKU='" & strSku & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same Sku." & Environment.NewLine

                foundRow = RecvDT.Select("PO='" & strPoNumber & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same PoNumber." & Environment.NewLine

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RetMsg = ex.ToString
            End Try

            Return RetMsg

        End Function
        Private Function IsReceivedUnshipped(ByVal iLoc_ID As Integer, ByVal strSN As String) As Boolean
            Dim dt As DataTable

            Try
                dt = Me._objVinsmart_Receiving.getReceivedUnshipped(iLoc_ID, strSN)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsReceivedUnshipped", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Public Function IsValidManufDateCode(ByVal strManufDate As String) As Boolean
            'All digits
            'Dim iMaxLen As Integer = 8 'yyyymmdd 8 digits
            Dim bRet As Boolean = False
            Dim regD As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[0-9]*$")   '("^[0-9]*$ ")

            Try
                If regD.IsMatch(strManufDate) Then 'Check if digits
                    If strManufDate.Trim.Length = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_DeviceManufDate_MinLength _
                                    OrElse strManufDate.Trim.Length = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_DeviceManufDate_MaxLength Then
                        bRet = True
                    Else
                        bRet = False
                    End If
                Else
                    bRet = False
                End If


                Return bRet
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsValidManufDateCode", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Public Function IsValidCricketAccountDOAorEMS(ByVal strAccountDOA As String, ByVal strAccountDOA_Code As String, ByRef iWrtyFlag As Integer) As Boolean
            Dim bRet As Boolean = False

            Try
                If strAccountDOA.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Cricket_OEMCustomer_DOA.Trim.ToUpper _
                   AndAlso strAccountDOA_Code.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Cricket_OEMCustomer_DOA_AccountCode.Trim.ToUpper Then
                    iWrtyFlag = 0 'OW, DOA
                    Return True
                ElseIf strAccountDOA.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Cricket_OEMCustomer_EMS.Trim.ToUpper _
                       AndAlso strAccountDOA_Code.Trim.ToUpper = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Cricket_OEMCustomer_EMS_AccountCode.Trim.ToUpper Then
                    iWrtyFlag = 1 'IW, Warranty Exchange
                    Return True
                End If

                Return bRet
            Catch ex As Exception
                MessageBox.Show(ex.ToString, " IsValidCricketAccountDOAorEMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function


        Private Sub cboLocation_Seed_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation_Seed.SelectedValueChanged
            'Try
            '    Me.cboDOA_Seed.Visible = False : Me.lblDOA_Seed.Visible = False
            '    If Me.cboLocation_Seed.SelectedValue = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
            '        Me.cboDOA_Seed.Visible = True : Me.lblDOA_Seed.Visible = True
            '    End If

            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString, " cboLocation_Seed_SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End Try
        End Sub

        Private Sub txtSN_Seed_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN_Seed.KeyUp, txtManufDate_Seed.KeyUp

            Try

                If e.KeyCode = Keys.Enter Then
                    If Me.txtSN_Seed.Text.Trim.Length > 0 OrElse Me.txtManufDate_Seed.Text.Trim.Length > 0 Then
                        Me.pnlReceived_Seed.Visible = False
                    End If
                    If Me.txtManufDate_Seed.Text.Trim.Length > 0 AndAlso Not Me.txtSN_Seed.Text.Trim.Length > 0 Then
                        Me.txtSN_Seed.Text = "" : Me.txtSN_Seed.SelectAll() : Me.txtSN_Seed.Focus()
                    ElseIf Not Me.txtManufDate_Seed.Text.Trim.Length > 0 AndAlso Me.txtSN_Seed.Text.Trim.Length > 0 Then
                        Me.txtManufDate_Seed.Text = "" : Me.txtManufDate_Seed.SelectAll() : Me.txtManufDate_Seed.Focus()
                    End If

                    If Me.txtSN_Seed.Text.Trim.Length > 0 AndAlso Me.txtManufDate_Seed.Text.Trim.Length > 0 Then
                        Me.ProcessSN_Seed()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_Seed_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub ProcessSN_Seed()
            Dim strSN_Seed As String = ""
            Dim strManufDate_Seed As String = ""
            Dim dt As DataTable, dtModel As DataTable
            Dim iEW_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim strSKU As String = ""
            Dim strPO As String = ""
            Dim iMaxQty As Integer = Me._objVinsmart.getMaxReceivingBoxQty
            Dim strModel_Desc As String = ""
            'Dim bReceived As Boolean = False
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iProd_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_Product_ID
            Dim strCustLoc As String = ""
            'Dim strVinsmartCustName As String = ""
            'Dim strAccountDOA As String = ""
            'Dim strAccountDOA_Code As String = ""
            Dim iWrtyFlag As Integer = 1 'seedstock devices are all in IN_WARRANTY, i.e., IW=1
            Dim strSeedSourceType As String = ""
            Dim bReceived As Boolean = False

            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "Vinsmart Seedstock Receiving"
            Dim strRecvMsg As String = ""

            Try
                Me.Cursor = Cursors.WaitCursor

                Me.txtReceivedQty_Seed.Text = Me._RecvVinsmartDT_Seed.Rows.Count
                If Convert.ToInt32(Me.txtReceivedQty_Seed.Text) > 0 AndAlso Convert.ToInt32(Me.txtMaxBoxQty_Seed.Text) > 0 _
                   AndAlso Convert.ToInt32(Me.txtReceivedQty_Seed.Text) >= Convert.ToInt32(Me.txtMaxBoxQty_Seed.Text) Then
                    MessageBox.Show("Seedstock Recv Box is full. Please close it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.btnCloseBox_Seed.Focus()
                    Exit Sub
                End If

                strSN_Seed = Me.txtSN_Seed.Text.Trim : strManufDate_Seed = Me.txtManufDate_Seed.Text.Trim

                Me._iLoc_ID_Seed = Me.cboLocation_Seed.SelectedValue

                If Me._iLoc_ID_Seed = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                    strSeedSourceType = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SeedStockSourceType_Cricket.Trim
                ElseIf Me._iLoc_ID_Seed = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID _
 Or Me._iLoc_ID_Seed = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID Then
                    strSeedSourceType = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SeedStockSourceType_ATT.Trim
                Else
                    MessageBox.Show("Invalid Location! See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.cboLocation_Seed.Focus()
                    Exit Sub
                End If

                If strSN_Seed.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf strManufDate_Seed.Trim.Length = 0 Then
                    MessageBox.Show("Please enter manufacture date.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me._iLoc_ID_Seed > 0 Then
                    MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me.cboModel_Seed.SelectedValue > 0 Then
                    MessageBox.Show("Please select a model(Sku).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'ElseIf iLoc_ID_Seed = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID AndAlso Not Me.cboDOA_Seed.SelectedValue > 0 Then
                    '    MessageBox.Show("Please select DOA.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me.IsValidManufDateCode(strManufDate_Seed) Then
                    MessageBox.Show("Invalid manufacture date. It should be 6 0r 8 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.IsReceivedUnshipped(Me._iLoc_ID_Seed, strSN_Seed) Then
                    MessageBox.Show("SN has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    strCustLoc = Me._objVinsmart_Receiving.getCustomerLocation(Me._iCust_ID, Me._iLoc_ID_Seed)

                    'If iLoc_ID_Seed = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                    '    strAccountDOA = Me.cboDOA_Seed.DataSource.Table.Select("DOA_ID = " & Me.cboDOA_Seed.SelectedValue)(0)("AccountDOA")
                    '    strAccountDOA_Code = Me.cboDOA_Seed.DataSource.Table.Select("DOA_ID = " & Me.cboDOA_Seed.SelectedValue)(0)("AccountDOA_Code")
                    'End If

                    'EW_ID, Customer, SN, In_Carton_ID, RMA_No, PO, Item_SKU, SeedStock_Type, RMA_Date, Work_Order, 
                    'WorkStation(, DOA_Account_Code, SourceFile, WO_ID, Cust_ID, Loc_ID, WO_Closed)
                    dt = Me._objVinsmart_Receiving.getSeedStockReceivingData(Me._iCust_ID, _iLoc_ID_Seed, strSN_Seed, strSeedSourceType)

                    'start to 
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Can't find the SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows(0).IsNull("Item_SKU") OrElse Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim.Length = 0 Then
                        MessageBox.Show("No SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf Not Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim.ToUpper = Convert.ToString(Me.cboModel_Seed.DataSource.Table.Select("Model_ID = " & Me.cboModel_Seed.SelectedValue)(0)("Model_Desc")).Trim.ToUpper Then
                        MessageBox.Show("Not the same SKU. This device has SKU '" & Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf (dt.Rows(0).IsNull("PO") OrElse Convert.ToString(dt.Rows(0).Item("PO")).Trim.Length = 0) Then
                        MessageBox.Show("No PO number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else '=1
                        strCustLoc = Me._objVinsmart_Receiving.getCustomerLocation(Me._iCust_ID, Me._iLoc_ID_Seed)
                        iModel_ID = Me.cboModel_Seed.SelectedValue
                        strModel_Desc = Me.cboModel_Seed.DataSource.Table.Select("Model_ID = " & Me.cboModel_Seed.SelectedValue)(0)("Model_Desc")
                        strSKU = Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim
                        strPO = Convert.ToString(dt.Rows(0).Item("PO")).Trim
                        iWO_ID = Convert.ToInt32(dt.Rows(0).Item("WO_ID"))
                        iEW_ID = Convert.ToInt32(dt.Rows(0).Item("EW_ID"))

                        iTray_ID = Me._objVinsmart_Receiving.getTayID(Me._iUserID, Me._strUser, iWO_ID, strTrayMemo)

                        If Not iModel_ID > 0 Then
                            MessageBox.Show("Invalid Model_ID '" & iModel_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf Not iWO_ID > 0 Then
                            MessageBox.Show("Invalid WO_ID '" & iWO_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ElseIf Not iTray_ID > 0 Then
                            MessageBox.Show("Invalid Tray_ID '" & iTray_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else 'Ready to receive 
                            'Create WH box at start-------------------------------
                            If Me._RecvVinsmartDT_Seed.Rows.Count = 0 Then 'First device
                                Dim objCoolPad_Recv As New PSS.Data.Buisness.CP.CoolPad_Receiving()
                                Me._iWB_ID_Seed = 0 : Me._iRecID_Seed = 0
                                Me._strRecvBoxName_Seed = objCoolPad_Recv.CreateWarehouseBoxName(iModel_ID, iWrtyFlag, Me._iWB_ID_Seed, "WK")
                                Me.lblBoxName_Seed.Text = Me._strRecvBoxName_Seed
                                Me.txtMaxBoxQty_Seed.Text = iMaxQty.ToString
                                objCoolPad_Recv = Nothing
                            Else 'Validate with recev seedstock data
                                Dim strValidatedMsg As String = Me.GoValidation_Seed(Me._RecvVinsmartDT_Seed, strSN_Seed, strSKU, strPO, iMaxQty).Trim
                                If strValidatedMsg.Length > 0 Then
                                    MessageBox.Show(strValidatedMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    Me.txtSN_Seed.SelectAll() : Me.txtSN_Seed.Focus()
                                    Exit Sub
                                End If
                            End If

                            bReceived = Me._objVinsmart_Receiving.ReceiveDataIntoSystem(Me._iLoc_ID_Seed, iWO_ID, iModel_ID, strSN_Seed, strManufDate_Seed, _
                                                                                    strDateTime, strWorkDate, iEW_ID, iShift_ID, iTray_ID, _
                                                                                    iDevice_ID, Me._iWB_ID_Seed, iWrtyFlag, True)
                            If bReceived Then
                                'RecID, SN, ASN_SKU, PSS_Model, Manuf_Date, PO, CustLoc, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID
                                Dim rowNew As DataRow
                                rowNew = Me._RecvVinsmartDT_Seed.NewRow
                                rowNew("SN") = strSN_Seed : rowNew("ASN_SKU") = strSKU
                                rowNew("PSS_Model") = strModel_Desc : rowNew("Manuf_Date") = strManufDate_Seed
                                rowNew("PO") = strPO : rowNew("CustLoc") = strCustLoc
                                rowNew("Model_ID") = iModel_ID : rowNew("Loc_ID") = Me._iLoc_ID_Seed
                                rowNew("EW_ID") = iEW_ID : rowNew("Device_ID") = iDevice_ID : rowNew("wb_ID") = Me._iWB_ID_Seed
                                Me._RecvVinsmartDT_Seed.Rows.Add(rowNew)
                                Me.BindReceivedData_Seed()

                                'If Me._iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then Me.lblAccountDOA.Text = strAccountDOA Else Me.lblAccountDOA.Text = ""
                                Me.txtReceivedQty_Seed.Text = Me._RecvVinsmartDT_Seed.Rows.Count
                                Me.txtManufDate_Seed.Text = ""
                                Me.txtSN_Seed.Text = "" : Me.txtSN_Seed.SelectAll() : Me.txtSN_Seed.Focus()
                                Me.cboLocation_Seed.Enabled = False : Me.cboModel_Seed.Enabled = False
                            Else
                                MessageBox.Show("Failed to receive. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN_Seed", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally
                Me.Cursor = Cursors.Default
                dt = Nothing : dtModel = Nothing
            End Try
        End Sub


        Private Sub btnCloseBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim strBoxStage As String = "Receiving"
            Dim i As Integer = 0
            Dim strWHLocation As String = ""
            Dim strASN_SKU_Desc As String = ""
            Dim strPO As String = ""
            Dim strPoLocOther1 As String = ""

            Try
                'RecID, SN, ASN_SKU, ASN_SKU_Desc, PSS_Model, Manuf_Date, Return_Type, Vendor, PO, Loc, Vendor_ID, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID

                If Not Me._RecvVinsmartDT.Rows.Count > 0 Then Exit Sub

                Me.txtReceivedQty.Text = Me._RecvVinsmartDT.Rows.Count
                If Convert.ToInt32(Me.txtReceivedQty.Text) > Convert.ToInt32(Me.txtMaxBoxQty.Text) Then
                    MessageBox.Show("Received qty is greater than maximum box qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf MsgBox("Do you want to close the box?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Close box
                    i = Me._objVinsmart_Receiving.ColseWarehouseBox(Me._iWB_ID, Me._RecvVinsmartDT.Rows.Count, strBoxStage)

                    If i > 0 Then
                        'Print Label
                        If Not Me._RecvVinsmartDT.Rows(0).IsNull("ASN_SKU_Desc") AndAlso Convert.ToString(Me._RecvVinsmartDT.Rows(0).Item("ASN_SKU_Desc")).Trim.Length > 0 Then
                            strASN_SKU_Desc = "SKU Desc: " & Convert.ToString(Me._RecvVinsmartDT.Rows(0).Item("ASN_SKU_Desc")).Trim
                        End If
                        strPO = Me._RecvVinsmartDT.Rows(0).Item("PO")
                        strPoLocOther1 = ""


                        Me._objVinsmart_Receiving.PrintReceivedBoxLabel(Me._strRecvBoxName, Me._RecvVinsmartDT.Rows.Count, Me._RecvVinsmartDT.Rows(0).Item("ASN_SKU"), strASN_SKU_Desc, _
                                             Me._RecvVinsmartDT.Rows(0).Item("PSS_Model"), "", Me._RecvVinsmartDT.Rows(0).Item("Return_Type"), _
                                             strPO, strWHLocation, Me._RecvVinsmartDT.Rows(0).Item("Loc"), strPoLocOther1)
                    Else
                        MessageBox.Show("Failed to Close the box. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'Reset
                    Me.tdgDeviceData.DataSource = Nothing : Me._RecvVinsmartDT.Rows.Clear()
                    'initialoze recv datatable columns
                    Me._RecvVinsmartDT = Me._objVinsmart_Receiving.getVinsmartRecvTableDef : Me.cboLocation.Enabled = True : Me.cboModel.Enabled = True
                    Me.lblblblSKU_Desc.Visible = False : Me.lblSku_Desc.Visible = False
                    Me._iRecID = 0 : Me._iWB_ID = 0 : Me._strRecvBoxName = "" : Me.txtReceivedQty.Text = 0 : Me.lblBoxName.Text = "" : Me.txtManufDate.Text = ""
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCloseBox_Seed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseBox_Seed.Click
            Dim strBoxStage As String = "Receiving"
            Dim i As Integer = 0
            Dim strWHLocation As String = ""
            Dim strASN_SKU_Desc As String = ""
            Dim strPO As String = ""
            Dim strSeedSourceType As String = ""

            Try
                'RecID, SN, ASN_SKU, PSS_Model, Manuf_Date, PO, CustLoc, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID

                If Not Me._RecvVinsmartDT_Seed.Rows.Count > 0 Then Exit Sub

                Me.txtReceivedQty_Seed.Text = Me._RecvVinsmartDT_Seed.Rows.Count
                If Convert.ToInt32(Me.txtReceivedQty_Seed.Text) > Convert.ToInt32(Me.txtMaxBoxQty_Seed.Text) Then
                    MessageBox.Show("Received qty is greater than maximum box qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf MsgBox("Do you want to close the box?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Close Seedstock box
                    i = Me._objVinsmart_Receiving.ColseWarehouseBox(Me._iWB_ID_Seed, Me._RecvVinsmartDT_Seed.Rows.Count, strBoxStage)

                    If i > 0 Then
                        'Print Label
                        strPO = "PO: " & Me._RecvVinsmartDT_Seed.Rows(0).Item("PO")
                        If Me._iLoc_ID_Seed = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                            strSeedSourceType = "Seedstock Source: " & PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SeedStockSourceType_Cricket.Trim
                        ElseIf Me._iLoc_ID_Seed = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCTDI_LOC_ID _
 Or Me._iLoc_ID_Seed = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttFedEx_LOC_ID Then
                            strSeedSourceType = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_SeedStockSourceType_ATT.Trim
                        Else
                            MessageBox.Show("Invalid Location! See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If

                        Me._objVinsmart_Receiving.PrintReceivedSeedstockBoxLabel(Me._strRecvBoxName_Seed, Me._RecvVinsmartDT_Seed.Rows.Count, _
                                                                             Me._RecvVinsmartDT_Seed.Rows(0).Item("ASN_SKU"), "", _
                                                                             Me._RecvVinsmartDT_Seed.Rows(0).Item("PSS_Model"), "", _
                                                                             strSeedSourceType, strPO, strWHLocation, Me._RecvVinsmartDT_Seed.Rows(0).Item("CustLoc"), _
                                                                             "")
                    Else
                        MessageBox.Show("Failed to Close the seedstock box. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'Reset
                    Me.tdgDeviceData_Seed.DataSource = Nothing : Me._RecvVinsmartDT_Seed.Rows.Clear()
                    'initialoze recv datatable columns
                    Me._RecvVinsmartDT_Seed = Me._objVinsmart_Receiving.getVinsmartSeedStockRecvTableDef : Me.cboLocation_Seed.Enabled = True : Me.cboModel_Seed.Enabled = True
                    Me._iRecID_Seed = 0 : Me._iWB_ID_Seed = 0 : Me._strRecvBoxName_Seed = "" : Me.txtReceivedQty_Seed.Text = 0
                    Me.lblBoxName_Seed.Text = "" : Me.txtManufDate_Seed.Text = ""
                    Me.txtSN_Seed.Text = "" : Me.txtSN_Seed.SelectAll() : Me.txtSN_Seed.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseBox_Seed_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReprintBoxLabel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim strInput As String = ""
            Dim dt, dtSN, dtPO As DataTable
            Dim iLoc_ID As Integer = 0
            Dim iBoxQty As Integer = 0
            Dim arrLstBoxes As New ArrayList(), arrlstRecvDates As New ArrayList()
            Dim row As DataRow
            Dim strMsg As String = ""
            Dim i As Integer = 0
            Dim strASN_SKU_Desc As String = ""
            Dim strPO As String = ""
            Dim strPoLocOther1 As String = ""

            'EW_ID, Customer, wb_ID, BoxName, Closed, Model_ID, WarrantyFlag, Return_Type, ReturnType_Code, Recv_Qty, PSS_Model, ASN_SKU, ASN_SKU_Desc, 
            'PO, SN, Device_ID, WHLocation, Cust_ID, Loc_ID, Device_DateRec

            Try
                If Me.rbtByBoxName.Checked Then 'BY BOX NAME -1-------------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a box name:", "Box Name").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid box name.")
                    dt = Me._objVinsmart_Receiving.GetVinsmartReceivedData(Me._iCust_ID, strInput, 1) 'Get data for the Box
                    If dt.Rows.Count > 0 Then
                        iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                        If iBoxQty = dt.Rows.Count Then
                            'print Label
                            iLoc_ID = Convert.ToInt32(dt.Rows(0).Item("Loc_ID"))

                            If iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                                strPO = "" : strASN_SKU_Desc = "" : strPoLocOther1 = ""
                            Else
                                strPO = dt.Rows(0).Item("PO") : strASN_SKU_Desc = "" : strPoLocOther1 = "PO: " & dt.Rows(0).Item("PO")
                            End If

                            Me._objVinsmart_Receiving.PrintReceivedBoxLabel(dt.Rows(0).Item("BoxName"), iBoxQty, dt.Rows(0).Item("ASN_SKU"), strASN_SKU_Desc, _
                                                                        dt.Rows(0).Item("PSS_Model"), "", dt.Rows(0).Item("Return_Type"), _
                                                                        strPO, dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("Customer"), strPoLocOther1)
                        Else
                            MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf Me.rbtBySN.Checked Then 'BY SN (IMEI) -2------------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a SN (IMEI):", "SN (IMEI)").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid SN (IMEI).")
                    dtSN = Me._objVinsmart_Receiving.GetVinsmartReceivedData(Me._iCust_ID, strInput, 2)   'get data for the SN
                    If dtSN.Rows.Count > 0 Then
                        For Each row In dtSN.Rows
                            If Not arrLstBoxes.Contains(row("BoxName")) Then
                                arrLstBoxes.Add(row("BoxName")) : arrlstRecvDates.Add(row("Device_DateRec"))
                            End If
                        Next
                        If arrLstBoxes.Count = 1 Then 'one box
                            dt = Me._objVinsmart_Receiving.GetVinsmartReceivedData(Me._iCust_ID, arrLstBoxes(0), 1)   'get box data  
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                If iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                                    strPO = "" : strASN_SKU_Desc = "" : strPoLocOther1 = ""
                                Else
                                    strPO = dt.Rows(0).Item("PO") : strASN_SKU_Desc = "" : strPoLocOther1 = "PO: " & dt.Rows(0).Item("PO")
                                End If

                                Me._objVinsmart_Receiving.PrintReceivedBoxLabel(dt.Rows(0).Item("BoxName"), iBoxQty, dt.Rows(0).Item("ASN_SKU"), strASN_SKU_Desc, _
                                                                            dt.Rows(0).Item("PSS_Model"), "", dt.Rows(0).Item("Return_Type"), _
                                                                            strPO, dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("Customer"), strPoLocOther1)
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        ElseIf arrLstBoxes.Count > 1 Then 'more boxes
                            strMsg = " Found " & arrLstBoxes.Count & " boxes." & Environment.NewLine
                            strMsg &= " Please enter 1 for Box 1, 2 for Box 2, ...:" & Environment.NewLine
                            For i = 0 To arrLstBoxes.Count - 1
                                strMsg &= "Box " & (i + 1).ToString & ". " & arrLstBoxes(i) & ", recved " & arrlstRecvDates(i) & Environment.NewLine
                            Next
                            strInput = InputBox(strMsg, "Input").Trim
                            If strInput = "" OrElse Not IsNumeric(strInput) Then Throw New Exception("Invalid input.")
                            i = Convert.ToInt32(strInput)
                            If i < 1 OrElse i > arrLstBoxes.Count Then Throw New Exception("Invalid input.")
                            Dim selectedBoxName As String = arrLstBoxes(i - 1)
                            dt = Me._objVinsmart_Receiving.GetVinsmartReceivedData(Me._iCust_ID, arrLstBoxes(0), 1)   'get box data
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                iLoc_ID = Convert.ToInt32(dt.Rows(0).Item("Loc_ID"))

                                If iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then
                                    strPO = "" : strASN_SKU_Desc = "" : strPoLocOther1 = ""
                                Else
                                    strPO = dt.Rows(0).Item("PO") : strASN_SKU_Desc = "" : strPoLocOther1 = "PO: " & dt.Rows(0).Item("PO")
                                End If

                                Me._objVinsmart_Receiving.PrintReceivedBoxLabel(dt.Rows(0).Item("BoxName"), iBoxQty, dt.Rows(0).Item("ASN_SKU"), strASN_SKU_Desc, _
                                                                            dt.Rows(0).Item("PSS_Model"), "", dt.Rows(0).Item("Return_Type"), _
                                                                            strPO, dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("Customer"), strPoLocOther1)
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else 'nothing 
                            MessageBox.Show("Can't find the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box for the SN (IMEI) " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                    'ElseIf Me.rbtByPoNumber.Checked Then 'BY PO Number -3------------------------------------------------------------------------------------------------------
                    '    strInput = InputBox("Enter a PO number:", "PO").Trim
                    '    If strInput = "" Then Throw New Exception("Please enter a valid PO number.")
                    '    dtPO = Me._objVinsmart_Receiving.GetVinsmartReceivedData(Me._iCust_ID, strInput, 3) 'get data for PO
                    '    If dtPO.Rows.Count > 0 Then
                    '        For Each row In dtPO.Rows
                    '            If Not arrLstBoxes.Contains(row("BoxName")) Then
                    '                arrLstBoxes.Add(row("BoxName")) : arrlstRecvDates.Add(row("Device_DateRec"))
                    '            End If
                    '        Next
                    '        If arrLstBoxes.Count = 1 Then 'one box
                    '            dt = Me._objVinsmart_Receiving.GetVinsmartReceivedData(Me._iCust_ID, arrLstBoxes(0), 1) 'get box data  
                    '            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                    '            If iBoxQty = dt.Rows.Count Then
                    '                'print Label
                    '                Me._objVinsmart_Receiving.PrintReceivedBoxLabel(dt.Rows(0).Item("BoxName"), iBoxQty, dt.Rows(0).Item("ASN_SKU"), strASN_SKU_Desc, _
                    '                                                            dt.Rows(0).Item("PSS_Model"), "", dt.Rows(0).Item("Return_Type"), _
                    '                                                            dt.Rows(0).Item("PO"), dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("Customer"), "")
                    '            Else
                    '                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '            End If
                    '        ElseIf arrLstBoxes.Count > 1 Then 'more boxes
                    '            strMsg = " Found " & arrLstBoxes.Count & " boxes." & Environment.NewLine
                    '            strMsg &= " Please enter 1 for Box 1, 2 for Box 2, ...:" & Environment.NewLine
                    '            For i = 0 To arrLstBoxes.Count - 1
                    '                strMsg &= "Box " & (i + 1).ToString & ". " & arrLstBoxes(i) & ", rcved " & arrlstRecvDates(i) & Environment.NewLine
                    '            Next
                    '            strInput = InputBox(strMsg, "Input").Trim
                    '            If strInput = "" OrElse Not IsNumeric(strInput) Then Throw New Exception("Invalid input.")
                    '            i = Convert.ToInt32(strInput)
                    '            If i < 1 OrElse i > arrLstBoxes.Count Then Throw New Exception("Invalid input.")
                    '            Dim selectedBoxName As String = arrLstBoxes(i - 1)
                    '            dt = Me._objVinsmart_Receiving.GetVinsmartReceivedData(Me._iCust_ID, selectedBoxName, 1)   'get box data
                    '            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                    '            If iBoxQty = dt.Rows.Count Then
                    '                'print Label
                    '                iLoc_ID = Convert.ToInt32(dt.Rows(0).Item("Loc_ID"))
                    '                If iLoc_ID = PSS.Data.Buisness.Vinsmart.Vinsmart.Vinsmart_AttCricket_LOC_ID Then

                    '                End If

                    '                Me._objVinsmart_Receiving.PrintReceivedBoxLabel(dt.Rows(0).Item("BoxName"), iBoxQty, dt.Rows(0).Item("ASN_SKU"), strASN_SKU_Desc, _
                    '                                                            dt.Rows(0).Item("PSS_Model"), "", dt.Rows(0).Item("Return_Type"), _
                    '                                                            dt.Rows(0).Item("PO"), dt.Rows(0).Item("WHLocation"), dt.Rows(0).Item("Customer"), "")
                    '            Else
                    '                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '            End If
                    '        Else 'nothing 
                    '            MessageBox.Show("Can't find the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '        End If
                    '    Else
                    '        MessageBox.Show("Can't find the box for the PO " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprinterBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReprintBoxLabel_Seed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel_Seed.Click
            Dim strInput As String = ""
            Dim dt, dtSN, dtPO As DataTable
            Dim iLoc_ID As Integer = 0
            Dim iBoxQty As Integer = 0
            Dim arrLstBoxes As New ArrayList(), arrlstRecvDates As New ArrayList()
            Dim row As DataRow
            Dim strMsg As String = ""
            Dim i As Integer = 0
            Dim strASN_SKU_Desc As String = ""
            Dim strPO As String = ""
            Dim strSeedSourceType As String = ""
            Dim strWHLocation As String = ""

            'EW_ID, Customer, wb_ID, BoxName, Closed, Model_ID, WarrantyFlag, SeedSourceType, Recv_Qty, PSS_Model, ASN_SKU, 
            'PO, SN, Device_ID, WHLocation, Cust_ID, Loc_ID, Device_DateRec

            Try
                If Me.rbtByBoxName_Seed.Checked Then 'BY BOX NAME 1-------------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a box name:", "Box Name").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid box name.")
                    dt = Me._objVinsmart_Receiving.GetVinsmartReceivedSeedstockData(Me._iCust_ID, strInput, 1) 'Get data for the Box
                    If dt.Rows.Count > 0 Then
                        iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))
                        If iBoxQty = dt.Rows.Count Then
                            'print Label
                            iLoc_ID = Convert.ToInt32(dt.Rows(0).Item("Loc_ID"))
                            strPO = "PO: " & dt.Rows(0).Item("PO")
                            strSeedSourceType = "Seedstock Source: " & dt.Rows(0).Item("SeedSourceType")

                            Me._objVinsmart_Receiving.PrintReceivedSeedstockBoxLabel(strInput, iBoxQty, dt.Rows(0).Item("ASN_SKU"), "", dt.Rows(0).Item("PSS_Model"), "", _
                                                                                 strSeedSourceType, strPO, strWHLocation, dt.Rows(0).Item("Customer"), "")
                        Else
                            MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                ElseIf Me.rbtBySN_Seed.Checked Then 'BY SN (IMEI) 2------------------------------------------------------------------------------------------------------------
                    strInput = InputBox("Enter a SN (IMEI):", "SN (IMEI)").Trim
                    If strInput = "" Then Throw New Exception("Please enter a valid SN (IMEI).")
                    dtSN = Me._objVinsmart_Receiving.GetVinsmartReceivedSeedstockData(Me._iCust_ID, strInput, 2)   'get data for the SN

                    If dtSN.Rows.Count > 0 Then
                        For Each row In dtSN.Rows
                            If Not arrLstBoxes.Contains(row("BoxName")) Then
                                arrLstBoxes.Add(row("BoxName")) : arrlstRecvDates.Add(row("Device_DateRec"))
                            End If
                        Next
                        If arrLstBoxes.Count = 1 Then 'one box
                            Dim selectedBoxName As String = arrLstBoxes(0)
                            dt = Me._objVinsmart_Receiving.GetVinsmartReceivedSeedstockData(Me._iCust_ID, selectedBoxName, 1)   'Get data for the Box
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))

                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                iLoc_ID = Convert.ToInt32(dt.Rows(0).Item("Loc_ID"))
                                strPO = "PO: " & dt.Rows(0).Item("PO")
                                strSeedSourceType = "Seedstock Source: " & dt.Rows(0).Item("SeedSourceType")

                                Me._objVinsmart_Receiving.PrintReceivedSeedstockBoxLabel(strInput, iBoxQty, dt.Rows(0).Item("ASN_SKU"), "", dt.Rows(0).Item("PSS_Model"), "", _
                                                                                     strSeedSourceType, strPO, strWHLocation, dt.Rows(0).Item("Customer"), "")
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        ElseIf arrLstBoxes.Count > 1 Then 'more boxes
                            strMsg = " Found " & arrLstBoxes.Count & " boxes." & Environment.NewLine
                            strMsg &= " Please enter 1 for Box 1, 2 for Box 2, ...:" & Environment.NewLine
                            For i = 0 To arrLstBoxes.Count - 1
                                strMsg &= "Box " & (i + 1).ToString & ". " & arrLstBoxes(i) & ", recved " & arrlstRecvDates(i) & Environment.NewLine
                            Next
                            strInput = InputBox(strMsg, "Input").Trim
                            If strInput = "" OrElse Not IsNumeric(strInput) Then Throw New Exception("Invalid input.")
                            i = Convert.ToInt32(strInput)
                            If i < 1 OrElse i > arrLstBoxes.Count Then Throw New Exception("Invalid input.")
                            Dim selectedBoxName As String = arrLstBoxes(i - 1)
                            dt = Me._objVinsmart_Receiving.GetVinsmartReceivedSeedstockData(Me._iCust_ID, selectedBoxName, 1) 'Get data for the Box
                            iBoxQty = Convert.ToInt32(dt.Rows(0).Item("Recv_Qty"))

                            If iBoxQty = dt.Rows.Count Then
                                'print Label
                                iLoc_ID = Convert.ToInt32(dt.Rows(0).Item("Loc_ID"))
                                strPO = "PO: " & dt.Rows(0).Item("PO")
                                strSeedSourceType = "Seedstock Source: " & dt.Rows(0).Item("SeedSourceType")

                                Me._objVinsmart_Receiving.PrintReceivedSeedstockBoxLabel(strInput, iBoxQty, dt.Rows(0).Item("ASN_SKU"), "", dt.Rows(0).Item("PSS_Model"), "", _
                                                                                    strSeedSourceType, strPO, strWHLocation, dt.Rows(0).Item("Customer"), "")
                            Else
                                MessageBox.Show("Box received qty and device qty are not the same.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                        Else 'nothing 
                            MessageBox.Show("Can't find the box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    Else
                        MessageBox.Show("Can't find the box for the SN (IMEI) " & strInput & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprinterBoxLabel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnAddData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddData.Click
            Dim ArrLstSNs As New ArrayList()
            Dim ArrLstDateCodes As New ArrayList()
            Dim i As Integer = 0

            Dim iL As Integer = Convert.ToInt32(Me.TextBox1.Text)
            Dim iC As Integer = 0

            Try
                If Not ArrLstSNs.Count > 0 Then
                    ArrLstSNs.Add("866530041383760")
                    ArrLstSNs.Add("866530041438945")
                    ArrLstSNs.Add("866530040603358")
                    ArrLstSNs.Add("866530040584533")
                    ArrLstSNs.Add("866530040600784")
                    ArrLstSNs.Add("866530041549659")
                    ArrLstSNs.Add("866530042003615")
                    ArrLstSNs.Add("866530041483099")
                    ArrLstSNs.Add("866530040611294")
                    ArrLstSNs.Add("866530042060946")
                    ArrLstSNs.Add("866530041546028")
                    ArrLstSNs.Add("866530041019455")
                    ArrLstSNs.Add("866530041138453")
                    ArrLstSNs.Add("866530040463019")
                    ArrLstSNs.Add("866530040938275")
                    ArrLstSNs.Add("866530041390542")
                    ArrLstSNs.Add("866530041646711")
                    ArrLstSNs.Add("866530041058545")
                    ArrLstSNs.Add("866530041563056")
                    ArrLstSNs.Add("866530041326058")
                    ArrLstSNs.Add("866530041021535")
                    ArrLstSNs.Add("866530041010918")
                    ArrLstSNs.Add("866530041405654")
                    ArrLstSNs.Add("866530040952516")
                    ArrLstSNs.Add("866530040616491")
                    ArrLstSNs.Add("866530040254616")

                    ArrLstDateCodes.Add("201113")
                    ArrLstDateCodes.Add("201114")
                    ArrLstDateCodes.Add("201017")
                    ArrLstDateCodes.Add("201016")
                    ArrLstDateCodes.Add("201017")
                    ArrLstDateCodes.Add("201118")
                    ArrLstDateCodes.Add("201122")
                    ArrLstDateCodes.Add("201117")
                    ArrLstDateCodes.Add("201017")
                    ArrLstDateCodes.Add("201124")
                    ArrLstDateCodes.Add("201118")
                    ArrLstDateCodes.Add("201023")
                    ArrLstDateCodes.Add("201102")
                    ArrLstDateCodes.Add("201006")
                    ArrLstDateCodes.Add("201022")
                    ArrLstDateCodes.Add("201118")
                    ArrLstDateCodes.Add("201120")
                    ArrLstDateCodes.Add("201024")
                    ArrLstDateCodes.Add("201118")
                    ArrLstDateCodes.Add("201112")
                    ArrLstDateCodes.Add("201105")
                    ArrLstDateCodes.Add("201024")
                    ArrLstDateCodes.Add("201113")
                    ArrLstDateCodes.Add("201022")
                    ArrLstDateCodes.Add("201017")
                    ArrLstDateCodes.Add("200916")


                End If

                Me.txtSN_Seed.Text = ArrLstSNs(iL - 1)
                Me.txtManufDate_Seed.Text = ArrLstDateCodes(iL - 1)

                Me.TextBox1.Text = iL + 1
                Me.TextBox2.Text = ArrLstSNs.Count
                Me.txtSN_Seed.SelectAll() : Me.txtSN_Seed.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
