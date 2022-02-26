Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.WingTechATT

    Public Class frmWingTechATT_SpecialReceiving
        Inherits System.Windows.Forms.Form

        Private _iWB_ID As Integer = 0
        Private _strRecvBoxName As String = ""
        Private _iRecID_Seed As Integer = 0
        Private _iMenuCustID As Integer = 0
        Private _iMenuLocID As Integer = 0
        Private _strScreenName As String = ""
        Private _strUserName As String = PSS.Core.Global.ApplicationUser.User
        Private _iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private _strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
        Private _objWingTechATT As PSS.Data.Buisness.WingTechATT.WingTechATT
        Private _objWingTechATT_Receiving As PSS.Data.Buisness.WingTechATT.WingTechATT_Receiving
        Private _RecvWingTechATTDT As DataTable
        Private _objWingTechATT_SP As PSS.Data.Buisness.WingTechATT.WingTechATT_SpecialProject
        Private _iRecID As Integer = 0
        Private _iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
        Private _strUser As String = PSS.Core.Global.ApplicationUser.User
#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCust_ID As Integer, ByVal iLoc_ID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCust_ID
            Me._iMenuLocID = iLoc_ID
            Me._strScreenName = strScreenName

            Me._objWingTechATT = New PSS.Data.Buisness.WingTechATT.WingTechATT()
            Me._objWingTechATT_Receiving = New PSS.Data.Buisness.WingTechATT.WingTechATT_Receiving()
            Me._objWingTechATT_SP = New PSS.Data.Buisness.WingTechATT.WingTechATT_SpecialProject()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objWingTechATT = Nothing
                    Me._objWingTechATT_Receiving = Nothing
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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents rtIMEI As System.Windows.Forms.RichTextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents listDevices As System.Windows.Forms.ListBox
        Friend WithEvents rd2Dbarcode As System.Windows.Forms.RadioButton
        Friend WithEvents rd1dBarcode As System.Windows.Forms.RadioButton
        Friend WithEvents txtListSN As System.Windows.Forms.TextBox
        Friend WithEvents txtPallett_Id As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents lblLocation As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWingTechATT_SpecialReceiving))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.TabPage1 = New System.Windows.Forms.TabPage()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.rtIMEI = New System.Windows.Forms.RichTextBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.listDevices = New System.Windows.Forms.ListBox()
            Me.rd2Dbarcode = New System.Windows.Forms.RadioButton()
            Me.rd1dBarcode = New System.Windows.Forms.RadioButton()
            Me.txtListSN = New System.Windows.Forms.TextBox()
            Me.txtPallett_Id = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
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
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.lblLocation = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.TabControl1.SuspendLayout()
            Me.TabPage1.SuspendLayout()
            CType(Me.tdgDeviceData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBox1.SuspendLayout()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1})
            Me.TabControl1.Location = New System.Drawing.Point(8, 7)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(1152, 584)
            Me.TabControl1.TabIndex = 169
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.Gainsboro
            Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.Button2, Me.rtIMEI, Me.Button1, Me.listDevices, Me.rd2Dbarcode, Me.rd1dBarcode, Me.txtListSN, Me.txtPallett_Id, Me.Label2, Me.lblBoxName, Me.txtMaxBoxQty, Me.lblMaxBoxQty, Me.txtReceivedQty, Me.lblReceivedQty, Me.tdgDeviceData, Me.btnCloseBox, Me.GroupBox1, Me.Label1, Me.cboModel, Me.lblSN, Me.txtSN, Me.lblLocation, Me.cboLocation})
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Size = New System.Drawing.Size(1144, 558)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "RMA Recv"
            '
            'Button3
            '
            Me.Button3.Location = New System.Drawing.Point(856, 112)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(120, 40)
            Me.Button3.TabIndex = 201
            Me.Button3.Text = "Button3"
            Me.Button3.Visible = False
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(856, 56)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(120, 32)
            Me.Button2.TabIndex = 200
            Me.Button2.Text = "Button2"
            Me.Button2.Visible = False
            '
            'rtIMEI
            '
            Me.rtIMEI.Location = New System.Drawing.Point(688, 56)
            Me.rtIMEI.Name = "rtIMEI"
            Me.rtIMEI.Size = New System.Drawing.Size(160, 432)
            Me.rtIMEI.TabIndex = 199
            Me.rtIMEI.Text = "RichTextBox1"
            Me.rtIMEI.Visible = False
            '
            'Button1
            '
            Me.Button1.BackColor = System.Drawing.Color.Green
            Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button1.ForeColor = System.Drawing.Color.White
            Me.Button1.Location = New System.Drawing.Point(456, 224)
            Me.Button1.Name = "Button1"
            Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.Button1.Size = New System.Drawing.Size(168, 49)
            Me.Button1.TabIndex = 198
            Me.Button1.Text = "VALIDATE                           Serial Number"
            Me.Button1.Visible = False
            '
            'listDevices
            '
            Me.listDevices.Location = New System.Drawing.Point(1056, 64)
            Me.listDevices.Name = "listDevices"
            Me.listDevices.Size = New System.Drawing.Size(96, 342)
            Me.listDevices.TabIndex = 197
            Me.listDevices.Visible = False
            '
            'rd2Dbarcode
            '
            Me.rd2Dbarcode.Location = New System.Drawing.Point(488, 80)
            Me.rd2Dbarcode.Name = "rd2Dbarcode"
            Me.rd2Dbarcode.TabIndex = 196
            Me.rd2Dbarcode.Text = "2D barcodes"
            Me.rd2Dbarcode.Visible = False
            '
            'rd1dBarcode
            '
            Me.rd1dBarcode.Checked = True
            Me.rd1dBarcode.Location = New System.Drawing.Point(376, 80)
            Me.rd1dBarcode.Name = "rd1dBarcode"
            Me.rd1dBarcode.TabIndex = 195
            Me.rd1dBarcode.TabStop = True
            Me.rd1dBarcode.Text = "1D barcode"
            Me.rd1dBarcode.Visible = False
            '
            'txtListSN
            '
            Me.txtListSN.AutoSize = False
            Me.txtListSN.Location = New System.Drawing.Point(696, 16)
            Me.txtListSN.Name = "txtListSN"
            Me.txtListSN.Size = New System.Drawing.Size(248, 22)
            Me.txtListSN.TabIndex = 194
            Me.txtListSN.Text = ""
            Me.txtListSN.Visible = False
            '
            'txtPallett_Id
            '
            Me.txtPallett_Id.BackColor = System.Drawing.Color.White
            Me.txtPallett_Id.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPallett_Id.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPallett_Id.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtPallett_Id.Location = New System.Drawing.Point(128, 88)
            Me.txtPallett_Id.Name = "txtPallett_Id"
            Me.txtPallett_Id.Size = New System.Drawing.Size(216, 22)
            Me.txtPallett_Id.TabIndex = 1
            Me.txtPallett_Id.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Black
            Me.Label2.Location = New System.Drawing.Point(16, 88)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(96, 21)
            Me.Label2.TabIndex = 192
            Me.Label2.Text = "Pallett ID"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Transparent
            Me.lblBoxName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Black
            Me.lblBoxName.Location = New System.Drawing.Point(368, 112)
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
            Me.txtMaxBoxQty.Location = New System.Drawing.Point(504, 48)
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
            Me.lblMaxBoxQty.Location = New System.Drawing.Point(376, 56)
            Me.lblMaxBoxQty.Name = "lblMaxBoxQty"
            Me.lblMaxBoxQty.Size = New System.Drawing.Size(120, 21)
            Me.lblMaxBoxQty.TabIndex = 190
            Me.lblMaxBoxQty.Text = "Max Qty:"
            Me.lblMaxBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtReceivedQty
            '
            Me.txtReceivedQty.BackColor = System.Drawing.Color.DarkGray
            Me.txtReceivedQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtReceivedQty.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtReceivedQty.ForeColor = System.Drawing.Color.DarkBlue
            Me.txtReceivedQty.Location = New System.Drawing.Point(504, 16)
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
            Me.lblReceivedQty.Location = New System.Drawing.Point(376, 24)
            Me.lblReceivedQty.Name = "lblReceivedQty"
            Me.lblReceivedQty.Size = New System.Drawing.Size(120, 21)
            Me.lblReceivedQty.TabIndex = 188
            Me.lblReceivedQty.Text = "Received Qty:"
            Me.lblReceivedQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.tdgDeviceData.Location = New System.Drawing.Point(16, 152)
            Me.tdgDeviceData.Name = "tdgDeviceData"
            Me.tdgDeviceData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDeviceData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDeviceData.PreviewInfo.ZoomFactor = 75
            Me.tdgDeviceData.Size = New System.Drawing.Size(424, 400)
            Me.tdgDeviceData.TabIndex = 185
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
            "AllowColMove=""False"" AllowColSelect=""False"" Name="""" AlternatingRowStyle=""True"" C" & _
            "aptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FetchRowStyle" & _
            "s=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>398</Height><Cap" & _
            "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
            "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
            "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
            "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
            """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
            "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
            "><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 422, 398</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 422, 398</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Bl" & _
            "ob>"
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.Location = New System.Drawing.Point(456, 176)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.Size = New System.Drawing.Size(168, 40)
            Me.btnCloseBox.TabIndex = 184
            Me.btnCloseBox.Text = "Close Box"
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.LightGray
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtByPoNumber, Me.rbtBySN, Me.rbtByBoxName, Me.btnReprintBoxLabel})
            Me.GroupBox1.Location = New System.Drawing.Point(456, 408)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(184, 136)
            Me.GroupBox1.TabIndex = 186
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Visible = False
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(16, 56)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 21)
            Me.Label1.TabIndex = 177
            Me.Label1.Text = "Model (Sku):"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboModel.Location = New System.Drawing.Point(128, 56)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(216, 21)
            Me.cboModel.TabIndex = 5
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Black
            Me.lblSN.Location = New System.Drawing.Point(16, 120)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(80, 21)
            Me.lblSN.TabIndex = 161
            Me.lblSN.Text = "SN (IMEI):"
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.White
            Me.txtSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSN.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSN.ForeColor = System.Drawing.SystemColors.Desktop
            Me.txtSN.Location = New System.Drawing.Point(128, 112)
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(216, 22)
            Me.txtSN.TabIndex = 2
            Me.txtSN.Text = ""
            '
            'lblLocation
            '
            Me.lblLocation.BackColor = System.Drawing.Color.Transparent
            Me.lblLocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLocation.ForeColor = System.Drawing.Color.Black
            Me.lblLocation.Location = New System.Drawing.Point(16, 24)
            Me.lblLocation.Name = "lblLocation"
            Me.lblLocation.Size = New System.Drawing.Size(72, 21)
            Me.lblLocation.TabIndex = 166
            Me.lblLocation.Text = "Location:"
            Me.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.cboLocation.Location = New System.Drawing.Point(128, 24)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(216, 21)
            Me.cboLocation.TabIndex = 165
            Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'frmWingTechATT_SpecialReceivingvb
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(680, 598)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "frmWingTechATT_SpecialReceivingvb"
            Me.Text = "frmWingTechATT_SpecialReceivingvb"
            Me.TabControl1.ResumeLayout(False)
            Me.TabPage1.ResumeLayout(False)
            CType(Me.tdgDeviceData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBox1.ResumeLayout(False)
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWingTechATT_SpecialReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim iCount As Integer
            Dim dtLoc As DataTable
            Dim dtModel As DataTable
            Dim dtType As DataTable
            Dim iLoc_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim iType_ID As Integer = 0

            Try
                dtLoc = Me._objWingTechATT_SP.GetWingTechATTLocations(Me._iMenuCustID, True)
                Me._RecvWingTechATTDT = Me._objWingTechATT_SP.getWingTechATTRecvTableDef
                Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
                Me.cboLocation.SelectedValue = Me._objWingTechATT.WingTechATT_Special_LOC_ID
                Me.cboLocation.Enabled = False

                dtModel = Me._objWingTechATT_SP.GetWingTechATTModels(Me._iMenuCustID, True)
                Misc.PopulateC1DropDownList(Me.cboModel, dtModel, "Model_Desc", "Model_ID")
                If dtModel.Rows.Count = 2 Then
                    iModel_ID = dtModel.Rows(0).Item("model_ID")
                    Me.cboModel.SelectedValue = iModel_ID
                Else
                    Me.cboModel.SelectedValue = 0
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        Private Sub ProcessSN()
            Dim strSN As String = ""
            Dim strManufDate As String = Now.ToString("yyyyMMdd")
            Dim dt As DataTable, dtModel As DataTable
            Dim iEW_ID As Integer = 0
            Dim iWO_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim iDevice_ID As Integer = 0
            Dim strModel_Desc As String = ""
            Dim bReceived As Boolean = False
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim iProd_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Product_ID
            Dim strCustLoc As String = ""
            ' Dim strWingTechATTCustName As String = ""
            Dim strAccountDOA As String = ""
            Dim strAccountDOA_Code As String = ""
            Dim strASN_IN_ITEM_SKU As String = ""
            Dim strASN_IN_ITEM_SKU_Desc As String = ""
            Dim strReturnType As String = ""
            Dim strPONumber As String = ""
            Dim strPallett_name As String
            Dim iShift_ID As Integer = PSS.Core.ApplicationUser.IDShift
            Dim strWorkDate As String = Generic.GetWorkDate(iShift_ID)
            Dim iTray_ID As Integer = 0
            Dim strTrayMemo As String = "WingTechATT Receiving"
            Dim iWrtyFlag As Integer = 0
            Dim iMaxQty As Integer = Me._objWingTechATT.WingTechATT_SPMaxQtyInBox

            Try
                Me.Cursor = Cursors.WaitCursor

                Me.txtReceivedQty.Text = Me._RecvWingTechATTDT.Rows.Count
                If Convert.ToInt32(Me.txtReceivedQty.Text) > 0 AndAlso Convert.ToInt32(Me.txtMaxBoxQty.Text) > 0 AndAlso Convert.ToInt32(Me.txtReceivedQty.Text) >= Convert.ToInt32(Me.txtMaxBoxQty.Text) Then
                    MessageBox.Show("Box is full. Please close it.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.btnCloseBox.Focus()
                    Exit Sub
                End If

                strSN = Me.txtSN.Text.Trim : strPallett_name = Me.txtPallett_Id.Text.Trim

                Me._iMenuLocID = Me.cboLocation.SelectedValue

                If strSN.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me._iMenuLocID > 0 Then
                    MessageBox.Show("Please select a location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Not Me.cboModel.SelectedValue > 0 Then
                    MessageBox.Show("Please select a SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf strPallett_name.Trim.Length = 0 Then
                    MessageBox.Show("Please enter the Pallett Name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    'ElseIf Not Me.IsValidManufDateCode(strManufDate) Then
                    '    MessageBox.Show("Invalid manufacture date. It should be 6 0r 8 digits.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf Me.IsReceivedUnshipped(Me._iMenuLocID, strSN) Then
                    MessageBox.Show("SN has been received.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    dt = Me._objWingTechATT_Receiving.getReceivingData(Me._iMenuCustID, Me._iMenuLocID, strSN)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Can't find the SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Duplicate SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf dt.Rows(0).IsNull("Item_SKU") OrElse Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim.Length = 0 Then
                        MessageBox.Show("No SKU.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ElseIf Not Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim.ToUpper = Convert.ToString(Me.cboModel.DataSource.Table.Select("Model_ID = " & Me.cboModel.SelectedValue)(0)("Model_Desc")).Trim.ToUpper Then
                        MessageBox.Show("Not the same SKU. This device has SKU '" & Convert.ToString(dt.Rows(0).Item("Item_SKU")).Trim & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
                                iTray_ID = Me._objWingTechATT_Receiving.getTayID(Me._iUserID, Me._strUser, iWO_ID, strTrayMemo)

                                If Not iModel_ID > 0 Then
                                    MessageBox.Show("Invalid Model_ID '" & iModel_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ElseIf Not iWO_ID > 0 Then
                                    MessageBox.Show("Invalid WO_ID '" & iWO_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                ElseIf Not iTray_ID > 0 Then
                                    MessageBox.Show("Invalid Tray_ID '" & iTray_ID.ToString & "'.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                Else 'Ready to receive 
                                    If Me._RecvWingTechATTDT.Rows.Count = 0 Then 'First device
                                        Dim objCoolPad_Recv As New PSS.Data.Buisness.CP.CoolPad_Receiving()
                                        Me._iWB_ID = 0 : Me._iRecID = 0
                                        Me._strRecvBoxName = objCoolPad_Recv.CreateWarehouseBoxName(iModel_ID, iWrtyFlag, Me._iWB_ID, "WK")
                                        Me.lblBoxName.Text = Me._strRecvBoxName
                                        Me.txtMaxBoxQty.Text = iMaxQty.ToString
                                        objCoolPad_Recv = Nothing
                                    Else 'Validate with recev data
                                        Dim strValidatedMsg As String = Me.GoValidation(Me._iMenuLocID, Me._RecvWingTechATTDT, strSN, strASN_IN_ITEM_SKU, iMaxQty).Trim
                                        If strValidatedMsg.Length > 0 Then
                                            MessageBox.Show(strValidatedMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                            Me.txtSN.SelectAll() : Me.txtSN.Focus()
                                            Exit Sub
                                        End If

                                    End If

                                    bReceived = Me._objWingTechATT_Receiving.ReceiveDataIntoSystem(Me._iMenuLocID, iWO_ID, iModel_ID, strSN, strManufDate, _
                                                                                          strDateTime, strWorkDate, iEW_ID, iShift_ID, iTray_ID, _
                                                                                          iDevice_ID, Me._iWB_ID, iWrtyFlag, False, strPallett_name)
                                    If bReceived Then
                                        'RecID, SN, ASN_SKU, ASN_SKU_Desc, PSS_Model, Manuf_Date, Return_Type, Vendor, PO, Loc, Vendor_ID
                                        'Model_ID(, Loc_ID, EW_ID, Device_ID, wb_ID)
                                        Dim rowNew As DataRow
                                        rowNew = Me._RecvWingTechATTDT.NewRow
                                        rowNew("SN") = strSN : rowNew("ASN_SKU") = strASN_IN_ITEM_SKU
                                        rowNew("PSS_Model") = strModel_Desc : rowNew("Manuf_Date") = strManufDate
                                        rowNew("PO") = strPONumber : rowNew("Loc") = strCustLoc
                                        rowNew("Model_ID") = iModel_ID : rowNew("Loc_ID") = Me._iMenuLocID
                                        rowNew("EW_ID") = iEW_ID : rowNew("Device_ID") = iDevice_ID : rowNew("wb_ID") = Me._iWB_ID
                                        Me._RecvWingTechATTDT.Rows.Add(rowNew)
                                        Me.BindReceivedData()

                                        'If Me._iLoc_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then Me.lblAccountDOA.Text = strAccountDOA Else Me.lblAccountDOA.Text = ""
                                        Me.txtReceivedQty.Text = Me._RecvWingTechATTDT.Rows.Count
                                        'Me.txtManufDate.Text = ""
                                        'Me.txtPallett_Id.Text = ""
                                        Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus() : Me.cboLocation.Enabled = False : Me.cboModel.Enabled = False : Me.txtPallett_Id.Enabled = False
                                    Else
                                        MessageBox.Show("Failed to receive. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                    End If
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
                For Each row In Me._RecvWingTechATTDT.Rows
                    i += 1
                    row.BeginEdit() : row("RecID") = i : row.AcceptChanges()
                Next

                'Bind received data
                With Me.tdgDeviceData
                    .DataSource = Me._RecvWingTechATTDT.DefaultView

                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc
                    If Me._iMenuCustID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
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
        Private Function GoValidation(ByVal iLoc_ID As Integer, ByVal RecvDT As DataTable, ByVal strSN As String, ByVal strSku As String, _
                              ByVal iMaxQty As Integer) As String

            Dim RetMsg As String = ""
            Dim row As DataRow
            Dim foundRow() As DataRow

            Try
                'RecID, SN, ASN_SKU, ASN_SKU_Desc, PSS_Model, Manuf_Date, Return_Type, Vendor, PO, Loc, Vendor_ID, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID

                strSN = strSN.Replace("'", "''") : strSku = strSku.Replace("'", "''")

                If RecvDT.Rows.Count = iMaxQty Then RetMsg &= "Box is full (max qty=" & iMaxQty.ToString & "), can't receive more." & Environment.NewLine

                foundRow = RecvDT.Select("SN='" & strSN & "'")
                If foundRow.Length > 0 Then RetMsg &= "Device '" & strSN & "' already received." & Environment.NewLine

                foundRow = RecvDT.Select("ASN_SKU='" & strSku & "'")
                If foundRow.Length = 0 Then RetMsg &= "Not the same Sku." & Environment.NewLine
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "GoValidation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RetMsg = ex.ToString
            End Try

            Return RetMsg
        End Function

        Public Function IsValidManufDateCode(ByVal strManufDate As String) As Boolean
            'All digits
            'Dim iMaxLen As Integer = 8 'yyyymmdd 8 digits
            Dim bRet As Boolean = False
            Dim regD As System.Text.RegularExpressions.Regex = New System.Text.RegularExpressions.Regex("^[0-9]*$")   '("^[0-9]*$ ")

            Try
                If regD.IsMatch(strManufDate) Then 'Check if digits
                    If strManufDate.Trim.Length = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_DeviceManufDate_MinLength _
                                    OrElse strManufDate.Trim.Length = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_DeviceManufDate_MaxLength Then
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
        Private Function IsReceivedUnshipped(ByVal iLoc_ID As Integer, ByVal strSN As String) As Boolean
            Dim dt As DataTable

            Try
                dt = Me._objWingTechATT_Receiving.getReceivedUnshipped(iLoc_ID, strSN)
                If dt.Rows.Count > 0 Then
                    Return True
                Else
                    Return False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "IsReceivedUnshipped", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Function

        Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim strBoxStage As String = "Receiving"
            Dim i As Integer = 0
            Dim strWHLocation As String = ""
            Dim strASN_SKU_Desc As String = ""
            Dim strPO As String = ""
            Dim strPoLocOther1 As String = ""

            Try
                'RecID, SN, ASN_SKU, ASN_SKU_Desc, PSS_Model, Manuf_Date, Return_Type, Vendor, PO, Loc, Vendor_ID, Model_ID, Loc_ID, EW_ID, Device_ID, wb_ID

                If Not Me._RecvWingTechATTDT.Rows.Count > 0 Then Exit Sub

                Me.txtReceivedQty.Text = Me._RecvWingTechATTDT.Rows.Count
                If Convert.ToInt32(Me.txtReceivedQty.Text) > Convert.ToInt32(Me.txtMaxBoxQty.Text) Then
                    MessageBox.Show("Received qty is greater than maximum box qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                ElseIf MsgBox("Do you want to close the box?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'Close box
                    i = Me._objWingTechATT_Receiving.ColseWarehouseBox(Me._iWB_ID, Me._RecvWingTechATTDT.Rows.Count, strBoxStage)

                    If i > 0 Then
                        'Print Label
                        'If Not Me._RecvWingTechATTDT.Rows(0).IsNull("ASN_SKU_Desc") AndAlso Convert.ToString(Me._RecvWingTechATTDT.Rows(0).Item("ASN_SKU_Desc")).Trim.Length > 0 Then
                        '    strASN_SKU_Desc = "SKU Desc: " & Convert.ToString(Me._RecvWingTechATTDT.Rows(0).Item("ASN_SKU_Desc")).Trim
                        'End If
                        strPO = Me._RecvWingTechATTDT.Rows(0).Item("PO")
                        'If Me._iMenuLocID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_Special_LOC_ID OrElse Me._iLoc_ID = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID Then
                        '    strPoLocOther1 = "PO: " & strPO
                        'Else
                        '    strPoLocOther1 = ""
                        'End If

                        Me._objWingTechATT_Receiving.PrintReceivedBoxLabel(Me._strRecvBoxName, Me._RecvWingTechATTDT.Rows.Count, Me._RecvWingTechATTDT.Rows(0).Item("ASN_SKU"), strASN_SKU_Desc, _
                                             Me._RecvWingTechATTDT.Rows(0).Item("PSS_Model"), "", "", _
                        strPO, strWHLocation, Me._RecvWingTechATTDT.Rows(0).Item("Loc"), strPoLocOther1)
                    Else
                        MessageBox.Show("Failed to Close the box. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If

                    'Reset
                    Me.tdgDeviceData.DataSource = Nothing : Me._RecvWingTechATTDT.Rows.Clear()
                    'initialoze recv datatable columns
                    Me._RecvWingTechATTDT = Me._objWingTechATT_Receiving.getWingTechATTRecvTableDef : Me.cboLocation.Enabled = True : Me.cboModel.Enabled = True : Me.txtPallett_Id.Enabled = True
                    'Me.lblblblSKU_Desc.Visible = False : Me.lblSku_Desc.Visible = False
                    Me._iRecID = 0 : Me._iWB_ID = 0 : Me._strRecvBoxName = "" : Me.txtReceivedQty.Text = 0 : Me.lblBoxName.Text = "" ': Me.txtManufDate.Text = ""
                    Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub txtSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp, txtPallett_Id.KeyUp
            Try

                If e.KeyCode = Keys.Enter Then
                    'If Me.txtSN.Text.Trim.Length > 0 OrElse Me.txtManufDate.Text.Trim.Length > 0 Then
                    'End If
                    'If Me.txtManufDate.Text.Trim.Length > 0 AndAlso 
                    If Not Me.txtSN.Text.Trim.Length > 0 Then
                        Me.txtSN.Text = "" : Me.txtSN.SelectAll() : Me.txtSN.Focus()
                        'ElseIf Not Me.txtManufDate.Text.Trim.Length > 0 AndAlso Me.txtSN.Text.Trim.Length > 0 Then
                        '    Me.txtManufDate.Text = "" : Me.txtManufDate.SelectAll() : Me.txtManufDate.Focus()
                    End If

                    If Me.txtSN.Text.Trim.Length > 0 And txtPallett_Id.Text.Trim.Length > 0 Then
                        'AndAlso Me.txtManufDate.Text.Trim.Length > 0
                        Me.ProcessSN()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try

        End Sub

        Private Sub rdScannerCheck()
            If Me.rd1dBarcode.Checked Then
                Me.txtSN.Visible = True
                Me.txtListSN.Visible = False
                Me.txtSN.Focus()
            Else
                Me.txtListSN.Visible = True
                Me.txtSN.Visible = False
                Me.txtListSN.Focus()
            End If
        End Sub
        Private Sub txtSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSN.TextChanged
            If Me.txtSN.Text.Trim <> String.Empty Then
                ProcessSN()
            End If
        End Sub

        Private Sub txtPallett_Id_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPallett_Id.KeyDown
            If e.KeyCode = Keys.Enter Then
                SendKeys.Send("{TAB}")
            End If
        End Sub

        Private Sub rdOneSN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd1dBarcode.CheckedChanged
            rdScannerCheck()
        End Sub

        Private Sub rdListSN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rd2Dbarcode.CheckedChanged
            rdScannerCheck()
        End Sub

        'Private Sub txtListSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtListSN.KeyDown
        '    If e.KeyCode = Keys.Enter Then
        '        Dim strSNList As String = String.Empty
        '        strSNList = Me.txtListSN.Text.Trim
        '        listDevices.Items.Clear()
        '        ' Split string based on comma
        '        Dim strSerialNumbers As String() = strSNList.Split(New Char() {","c})
        '        Dim strSerialNumber As String
        '        For Each strSerialNumber In strSerialNumbers
        '            If strSerialNumber.Length = 15 Then
        '                Me.listDevices.Items.Add(strSerialNumber)
        '            End If
        '        Next
        '    End If
        'End Sub

        'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '    Dim strSN As String
        '    Dim i As Integer
        '    For i = 0 To listDevices.Items.Count - 1
        '        strSN = listDevices.Items(i)
        '        Me.ProcessSN()
        '    Next i

        'End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Dim openFileIMEI As New OpenFileDialog()
            openFileIMEI.Title = "Please select a Text file"
            openFileIMEI.Filter = "Text File|*.txt"
            If openFileIMEI.ShowDialog() = DialogResult.OK Then
                Dim strPath As String = openFileIMEI.FileName
                If strPath = "" Then
                    MessageBox.Show("Select a File ", "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Me.rtIMEI.LoadFile(strPath, RichTextBoxStreamType.PlainText)
                Dim iImeiNumber = rtIMEI.Lines.Length - 1
            End If
        End Sub

        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
            Dim i As Integer
            For i = 0 To rtIMEI.Lines.Length - 1
                txtSN.Text = rtIMEI.Lines(i).ToString
            Next
        End Sub
    End Class
End Namespace