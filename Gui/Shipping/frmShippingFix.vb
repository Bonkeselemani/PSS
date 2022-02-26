Option Explicit On 

Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Core
Imports PSS.Data
Imports Microsoft.Data.Odbc

Namespace Gui.Shipping

    Public Class frmShipping
        Inherits System.Windows.Forms.Form

        Private G_objMessShip As PSS.Data.Buisness.MessShip
        Private G_objMotoWarrantyBiz As Buisness.WarrantyClaim.MotoWarrantyBiz

        Private G_dtCustomer As DataTable
        Private G_dtDevice As DataTable
        Private G_dtDupList As DataTable
        Private G_dtDuplicateInd As DataTable
        Private G_dtDupDataGrid As DataTable
        Private G_dtSelected As DataTable

        Private G_dtState As DataTable
        Private G_dtCountry As DataTable

        Private G_iCount1 As Integer = 0
        Private G_iCustID As Integer = 0
        Private G_iLocID As Integer = 0
        Private G_iCustShipLvl As Integer = 0
        Private G_iCreditShip As Integer = 0
        Private G_iFindDeviceID As Integer = 0
        Private G_iFindWOID As Integer = 0
        Private G_iFindTrayID As Integer = 0
        Private G_iShipID As Integer = 0
        Private G_iShipToID As Integer = 0
        Private G_iShipto2ID As Integer = 0
        Private G_iProdID As Integer = 0
        Private G_iManDet As Integer = 0
        Private G_iWorkorderID As Int32 = 0

        Private G_strContact As String = ""
        Private G_strMsg As String = ""
        Private G_strTitle As String = ""
        Private G_strFindSN As String = ""
        Private G_strFindDevice As String = ""
        Private G_strShipName As String = ""

        Private G_lngwoFlag As Long = 0
        Private G_RUR_NER As Boolean
        Private G_booRMA As Boolean = False 'Warehouse.Warehouse_Receipt.RMA
        Private G_WR_ID As Integer = 0      'Warehouse.Warehouse_Receipt.WR_ID
        Private G_strRMA As String          'Warehouse.Warehouse_Receipt.RMA

        Public Shared G_strFOLOT As String

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Core.Highlight.SetHighLight(Me)
            G_objMessShip = New PSS.Data.Buisness.MessShip()
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
        Friend WithEvents cmbModel As System.Windows.Forms.ComboBox
        Friend WithEvents cmbLoc As System.Windows.Forms.ComboBox
        Friend WithEvents lblNoQCPass As System.Windows.Forms.Label
        Friend WithEvents lstNoQCPass As System.Windows.Forms.ListBox
        Friend WithEvents lblAddress As System.Windows.Forms.Label
        Friend WithEvents lblWrongModel As System.Windows.Forms.Label
        Friend WithEvents lblWrongFreq As System.Windows.Forms.Label
        Friend WithEvents grpboxUnship As System.Windows.Forms.GroupBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents txtUnshipSN As System.Windows.Forms.TextBox
        Friend WithEvents txtShipQty As System.Windows.Forms.TextBox
        Friend WithEvents cmdUnship As System.Windows.Forms.Button
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtShipID As System.Windows.Forms.TextBox
        Friend WithEvents lstWrongModel As System.Windows.Forms.ListBox
        Friend WithEvents lstWrongFreq As System.Windows.Forms.ListBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblFreqLabel As System.Windows.Forms.Label
        Friend WithEvents lblFreqNum As System.Windows.Forms.Label
        Friend WithEvents btnShipSpecial As System.Windows.Forms.Button
        Friend WithEvents btnPO As System.Windows.Forms.Button
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents btnEndUser As System.Windows.Forms.Button
        Friend WithEvents btnPrint As System.Windows.Forms.Button
        Friend WithEvents TDBGrid1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblPager As System.Windows.Forms.Label
        Friend WithEvents txtPager As System.Windows.Forms.TextBox
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblCompany As System.Windows.Forms.Label
        Friend WithEvents lblDate As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmShipping))
            Me.cmbModel = New System.Windows.Forms.ComboBox()
            Me.cmbLoc = New System.Windows.Forms.ComboBox()
            Me.lblNoQCPass = New System.Windows.Forms.Label()
            Me.lstNoQCPass = New System.Windows.Forms.ListBox()
            Me.lblAddress = New System.Windows.Forms.Label()
            Me.lblWrongModel = New System.Windows.Forms.Label()
            Me.lblWrongFreq = New System.Windows.Forms.Label()
            Me.grpboxUnship = New System.Windows.Forms.GroupBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.txtUnshipSN = New System.Windows.Forms.TextBox()
            Me.txtShipQty = New System.Windows.Forms.TextBox()
            Me.cmdUnship = New System.Windows.Forms.Button()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtShipID = New System.Windows.Forms.TextBox()
            Me.lstWrongModel = New System.Windows.Forms.ListBox()
            Me.lstWrongFreq = New System.Windows.Forms.ListBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.lblFreqLabel = New System.Windows.Forms.Label()
            Me.lblFreqNum = New System.Windows.Forms.Label()
            Me.btnShipSpecial = New System.Windows.Forms.Button()
            Me.btnPO = New System.Windows.Forms.Button()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.btnEndUser = New System.Windows.Forms.Button()
            Me.btnPrint = New System.Windows.Forms.Button()
            Me.TDBGrid1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblPager = New System.Windows.Forms.Label()
            Me.txtPager = New System.Windows.Forms.TextBox()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblCompany = New System.Windows.Forms.Label()
            Me.lblDate = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.grpboxUnship.SuspendLayout()
            CType(Me.TDBGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'cmbModel
            '
            Me.cmbModel.Location = New System.Drawing.Point(8, 63)
            Me.cmbModel.Name = "cmbModel"
            Me.cmbModel.Size = New System.Drawing.Size(240, 21)
            Me.cmbModel.TabIndex = 183
            '
            'cmbLoc
            '
            Me.cmbLoc.Location = New System.Drawing.Point(8, 23)
            Me.cmbLoc.Name = "cmbLoc"
            Me.cmbLoc.Size = New System.Drawing.Size(240, 21)
            Me.cmbLoc.TabIndex = 182
            '
            'lblNoQCPass
            '
            Me.lblNoQCPass.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNoQCPass.ForeColor = System.Drawing.Color.White
            Me.lblNoQCPass.Location = New System.Drawing.Point(504, 215)
            Me.lblNoQCPass.Name = "lblNoQCPass"
            Me.lblNoQCPass.Size = New System.Drawing.Size(128, 16)
            Me.lblNoQCPass.TabIndex = 179
            Me.lblNoQCPass.Text = "No QC Pass"
            Me.lblNoQCPass.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.lblNoQCPass.Visible = False
            '
            'lstNoQCPass
            '
            Me.lstNoQCPass.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.lstNoQCPass.BackColor = System.Drawing.Color.SteelBlue
            Me.lstNoQCPass.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lstNoQCPass.ForeColor = System.Drawing.Color.Red
            Me.lstNoQCPass.Location = New System.Drawing.Point(504, 231)
            Me.lstNoQCPass.Name = "lstNoQCPass"
            Me.lstNoQCPass.Size = New System.Drawing.Size(128, 221)
            Me.lstNoQCPass.TabIndex = 178
            '
            'lblAddress
            '
            Me.lblAddress.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAddress.ForeColor = System.Drawing.Color.White
            Me.lblAddress.Location = New System.Drawing.Point(288, 39)
            Me.lblAddress.Name = "lblAddress"
            Me.lblAddress.Size = New System.Drawing.Size(272, 88)
            Me.lblAddress.TabIndex = 177
            Me.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWrongModel
            '
            Me.lblWrongModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrongModel.ForeColor = System.Drawing.Color.White
            Me.lblWrongModel.Location = New System.Drawing.Point(200, 215)
            Me.lblWrongModel.Name = "lblWrongModel"
            Me.lblWrongModel.Size = New System.Drawing.Size(120, 16)
            Me.lblWrongModel.TabIndex = 176
            Me.lblWrongModel.Text = "Wrong Model"
            Me.lblWrongModel.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.lblWrongModel.Visible = False
            '
            'lblWrongFreq
            '
            Me.lblWrongFreq.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrongFreq.ForeColor = System.Drawing.Color.White
            Me.lblWrongFreq.Location = New System.Drawing.Point(352, 215)
            Me.lblWrongFreq.Name = "lblWrongFreq"
            Me.lblWrongFreq.Size = New System.Drawing.Size(128, 16)
            Me.lblWrongFreq.TabIndex = 175
            Me.lblWrongFreq.Text = "Wrong Frequency"
            Me.lblWrongFreq.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.lblWrongFreq.Visible = False
            '
            'grpboxUnship
            '
            Me.grpboxUnship.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.txtUnshipSN, Me.txtShipQty, Me.cmdUnship, Me.Label10, Me.Label1, Me.txtShipID})
            Me.grpboxUnship.ForeColor = System.Drawing.Color.Yellow
            Me.grpboxUnship.Location = New System.Drawing.Point(560, 15)
            Me.grpboxUnship.Name = "grpboxUnship"
            Me.grpboxUnship.Size = New System.Drawing.Size(232, 136)
            Me.grpboxUnship.TabIndex = 174
            Me.grpboxUnship.TabStop = False
            Me.grpboxUnship.Text = "UN-SHIP"
            Me.grpboxUnship.Visible = False
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Lime
            Me.Label6.Location = New System.Drawing.Point(6, 66)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 16)
            Me.Label6.TabIndex = 109
            Me.Label6.Text = "SN (Optional):"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtUnshipSN
            '
            Me.txtUnshipSN.Location = New System.Drawing.Point(104, 64)
            Me.txtUnshipSN.Name = "txtUnshipSN"
            Me.txtUnshipSN.Size = New System.Drawing.Size(120, 20)
            Me.txtUnshipSN.TabIndex = 110
            Me.txtUnshipSN.Text = ""
            '
            'txtShipQty
            '
            Me.txtShipQty.Location = New System.Drawing.Point(104, 32)
            Me.txtShipQty.Name = "txtShipQty"
            Me.txtShipQty.Size = New System.Drawing.Size(72, 20)
            Me.txtShipQty.TabIndex = 108
            Me.txtShipQty.Text = ""
            '
            'cmdUnship
            '
            Me.cmdUnship.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdUnship.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me.cmdUnship.ForeColor = System.Drawing.Color.Black
            Me.cmdUnship.Location = New System.Drawing.Point(16, 104)
            Me.cmdUnship.Name = "cmdUnship"
            Me.cmdUnship.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.cmdUnship.Size = New System.Drawing.Size(208, 24)
            Me.cmdUnship.TabIndex = 104
            Me.cmdUnship.Text = "Unship"
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(112, 16)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(72, 16)
            Me.Label10.TabIndex = 107
            Me.Label10.Text = "Un-Ship Qty:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(85, 16)
            Me.Label1.TabIndex = 105
            Me.Label1.Text = "Ship ID:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtShipID
            '
            Me.txtShipID.Location = New System.Drawing.Point(8, 32)
            Me.txtShipID.Name = "txtShipID"
            Me.txtShipID.Size = New System.Drawing.Size(80, 20)
            Me.txtShipID.TabIndex = 106
            Me.txtShipID.Text = ""
            '
            'lstWrongModel
            '
            Me.lstWrongModel.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.lstWrongModel.BackColor = System.Drawing.Color.SteelBlue
            Me.lstWrongModel.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lstWrongModel.ForeColor = System.Drawing.Color.Yellow
            Me.lstWrongModel.Location = New System.Drawing.Point(200, 231)
            Me.lstWrongModel.Name = "lstWrongModel"
            Me.lstWrongModel.Size = New System.Drawing.Size(128, 221)
            Me.lstWrongModel.TabIndex = 173
            '
            'lstWrongFreq
            '
            Me.lstWrongFreq.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.lstWrongFreq.BackColor = System.Drawing.Color.SteelBlue
            Me.lstWrongFreq.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.lstWrongFreq.ForeColor = System.Drawing.Color.Green
            Me.lstWrongFreq.Location = New System.Drawing.Point(352, 231)
            Me.lstWrongFreq.Name = "lstWrongFreq"
            Me.lstWrongFreq.Size = New System.Drawing.Size(128, 221)
            Me.lstWrongFreq.TabIndex = 172
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 47)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(136, 16)
            Me.Label4.TabIndex = 171
            Me.Label4.Text = "Model:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(8, 7)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(136, 16)
            Me.Label5.TabIndex = 170
            Me.Label5.Text = "Location:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblFreqLabel
            '
            Me.lblFreqLabel.BackColor = System.Drawing.Color.Black
            Me.lblFreqLabel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFreqLabel.ForeColor = System.Drawing.Color.Green
            Me.lblFreqLabel.Location = New System.Drawing.Point(344, 151)
            Me.lblFreqLabel.Name = "lblFreqLabel"
            Me.lblFreqLabel.Size = New System.Drawing.Size(96, 16)
            Me.lblFreqLabel.TabIndex = 169
            Me.lblFreqLabel.Text = "Frequency:"
            Me.lblFreqLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.lblFreqLabel.Visible = False
            '
            'lblFreqNum
            '
            Me.lblFreqNum.BackColor = System.Drawing.Color.Black
            Me.lblFreqNum.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFreqNum.ForeColor = System.Drawing.Color.Green
            Me.lblFreqNum.Location = New System.Drawing.Point(344, 167)
            Me.lblFreqNum.Name = "lblFreqNum"
            Me.lblFreqNum.Size = New System.Drawing.Size(96, 24)
            Me.lblFreqNum.TabIndex = 168
            Me.lblFreqNum.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            Me.lblFreqNum.Visible = False
            '
            'btnShipSpecial
            '
            Me.btnShipSpecial.BackColor = System.Drawing.SystemColors.Control
            Me.btnShipSpecial.Location = New System.Drawing.Point(168, 95)
            Me.btnShipSpecial.Name = "btnShipSpecial"
            Me.btnShipSpecial.Size = New System.Drawing.Size(96, 23)
            Me.btnShipSpecial.TabIndex = 167
            Me.btnShipSpecial.Text = "Ship Special"
            '
            'btnPO
            '
            Me.btnPO.BackColor = System.Drawing.SystemColors.Control
            Me.btnPO.Location = New System.Drawing.Point(88, 95)
            Me.btnPO.Name = "btnPO"
            Me.btnPO.Size = New System.Drawing.Size(72, 23)
            Me.btnPO.TabIndex = 166
            Me.btnPO.Text = "PO"
            '
            'btnReprint
            '
            Me.btnReprint.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnReprint.BackColor = System.Drawing.SystemColors.ControlLight
            Me.btnReprint.Location = New System.Drawing.Point(712, 511)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.TabIndex = 165
            Me.btnReprint.Text = "Reprint"
            '
            'btnEndUser
            '
            Me.btnEndUser.BackColor = System.Drawing.SystemColors.Control
            Me.btnEndUser.Location = New System.Drawing.Point(8, 95)
            Me.btnEndUser.Name = "btnEndUser"
            Me.btnEndUser.Size = New System.Drawing.Size(72, 23)
            Me.btnEndUser.TabIndex = 164
            Me.btnEndUser.Text = "End User"
            '
            'btnPrint
            '
            Me.btnPrint.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight
            Me.btnPrint.Enabled = False
            Me.btnPrint.Location = New System.Drawing.Point(8, 503)
            Me.btnPrint.Name = "btnPrint"
            Me.btnPrint.Size = New System.Drawing.Size(152, 32)
            Me.btnPrint.TabIndex = 163
            Me.btnPrint.Text = "Prin&t"
            '
            'TDBGrid1
            '
            Me.TDBGrid1.AllowDelete = True
            Me.TDBGrid1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.TDBGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.TDBGrid1.Caption = "Duplicate Pagers"
            Me.TDBGrid1.CaptionHeight = 17
            Me.TDBGrid1.GroupByCaption = "Drag a column header here to group by that column"
            Me.TDBGrid1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.TDBGrid1.Location = New System.Drawing.Point(224, 463)
            Me.TDBGrid1.Name = "TDBGrid1"
            Me.TDBGrid1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.TDBGrid1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.TDBGrid1.PreviewInfo.ZoomFactor = 75
            Me.TDBGrid1.RowHeight = 15
            Me.TDBGrid1.Size = New System.Drawing.Size(288, 72)
            Me.TDBGrid1.TabIndex = 162
            Me.TDBGrid1.Text = "C1TrueDBGrid1"
            Me.TDBGrid1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Verdana, 8.25pt, style=Bold;}HighlightRow{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Center" & _
            ";}Style15{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColo" & _
            "r:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style1" & _
            "2{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name=" & _
            """"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeSt" & _
            "yle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScro" & _
            "llGroup=""1"" HorizontalScrollGroup=""1""><Height>53</Height><CaptionStyle parent=""S" & _
            "tyle2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle p" & _
            "arent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" />" & _
            "<FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style1" & _
            "2"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""Hig" & _
            "hlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowS" & _
            "tyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" " & _
            "me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Nor" & _
            "mal"" me=""Style1"" /><ClientRect>0, 17, 286, 53</ClientRect><BorderSide>0</BorderS" & _
            "ide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><N" & _
            "amedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" />" & _
            "<Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><St" & _
            "yle parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Sty" & _
            "le parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Sty" & _
            "le parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style pa" & _
            "rent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><St" & _
            "yle parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzS" & _
            "plits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWi" & _
            "dth><ClientArea>0, 0, 286, 70</ClientArea><PrintPageHeaderStyle parent="""" me=""St" & _
            "yle14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'lstDevices
            '
            Me.lstDevices.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.lstDevices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstDevices.Location = New System.Drawing.Point(8, 207)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(152, 288)
            Me.lstDevices.TabIndex = 161
            '
            'lblPager
            '
            Me.lblPager.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPager.ForeColor = System.Drawing.Color.White
            Me.lblPager.Location = New System.Drawing.Point(8, 167)
            Me.lblPager.Name = "lblPager"
            Me.lblPager.Size = New System.Drawing.Size(152, 16)
            Me.lblPager.TabIndex = 160
            Me.lblPager.Text = "Device:"
            Me.lblPager.TextAlign = System.Drawing.ContentAlignment.BottomLeft
            '
            'txtPager
            '
            Me.txtPager.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPager.Location = New System.Drawing.Point(8, 183)
            Me.txtPager.Name = "txtPager"
            Me.txtPager.Size = New System.Drawing.Size(152, 20)
            Me.txtPager.TabIndex = 159
            Me.txtPager.Text = ""
            '
            'lblCount
            '
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblCount.Font = New System.Drawing.Font("Verdana", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.White
            Me.lblCount.Location = New System.Drawing.Point(200, 151)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(88, 40)
            Me.lblCount.TabIndex = 158
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(208, 135)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(88, 16)
            Me.Label3.TabIndex = 157
            Me.Label3.Text = "Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblCompany
            '
            Me.lblCompany.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCompany.ForeColor = System.Drawing.Color.White
            Me.lblCompany.Location = New System.Drawing.Point(288, 15)
            Me.lblCompany.Name = "lblCompany"
            Me.lblCompany.Size = New System.Drawing.Size(272, 24)
            Me.lblCompany.TabIndex = 156
            Me.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDate
            '
            Me.lblDate.Location = New System.Drawing.Point(624, 159)
            Me.lblDate.Name = "lblDate"
            Me.lblDate.Size = New System.Drawing.Size(176, 23)
            Me.lblDate.TabIndex = 180
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(552, 159)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 23)
            Me.Label2.TabIndex = 181
            '
            'frmShipping
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(808, 542)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbModel, Me.cmbLoc, Me.lblNoQCPass, Me.lstNoQCPass, Me.lblAddress, Me.lblWrongModel, Me.lblWrongFreq, Me.grpboxUnship, Me.lstWrongModel, Me.lstWrongFreq, Me.Label4, Me.Label5, Me.lblFreqLabel, Me.lblFreqNum, Me.btnShipSpecial, Me.btnPO, Me.btnReprint, Me.btnEndUser, Me.btnPrint, Me.TDBGrid1, Me.lstDevices, Me.lblPager, Me.txtPager, Me.lblCount, Me.Label3, Me.lblCompany, Me.lblDate, Me.Label2})
            Me.Name = "frmShipping"
            Me.Text = "Shipping"
            Me.grpboxUnship.ResumeLayout(False)
            CType(Me.TDBGrid1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************
        Private Sub frmShipping_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                TDBGrid1.Visible = False            '//Hide the duplicate device select grid
                G_iCount1 = 0                          '//Reset Counter
                PopulateCustomerList()              '//Fill Customer List With Data
                lblDate.Text = FormatDate(Now)      '//Set The Date to Now
                GetState()                      '//This dataset holds the state names
                GetCountry()                    '//This dataset holds the country names
                G_dtDupDataGrid = Create_dtDupGrid()  '//This creates the datatable to hold duplicate information
                G_dtSelected = Create_dtSelect()      '//This creates the datatable to hold selected devices

                '//Determine ProductCode
                G_iProdID = 1
                '//Determine user
                G_strShipName = PSS.Core.ApplicationUser.User

                Me.cmbLoc.Focus()

                '**************************************
                'Lan added on 03/21/2007. 
                'Only visible if user have security access
                '**************************************
                If ApplicationUser.GetPermission("MessShipManifest_Delete") > 0 Then
                    Me.grpboxUnship.Visible = True
                Else
                    Me.grpboxUnship.Visible = False
                End If

                '**************************************
                'Lan added on 11/13/2007.
                '**************************************
                Me.LoadModels(Me.cmbModel)
                '**************************************

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form_LoadEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '*********************************************************
        Private Sub LoadModels(ByRef cmbModel As ComboBox)
            Dim dtModels As New DataTable()
            Dim objMisc As New PSS.Data.Buisness.Misc()

            Try
                dtModels = objMisc.GetModels(1, 0)
                With cmbModel
                    .DataSource = dtModels.DefaultView
                    .DisplayMember = dtModels.Columns("Model_Desc").ToString
                    .ValueMember = dtModels.Columns("Model_ID").ToString
                    .SelectedValue = 0
                End With

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtModels) Then
                    dtModels.Dispose()
                    dtModels = Nothing
                End If
                objMisc = Nothing
            End Try
        End Sub

        '*********************************************************
        Private Sub PopulateCustomerList()
            Dim rCustList As DataRow
            Dim i As Integer = 0

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                G_dtCustomer = Me.G_objMessShip.GetShipping_CustomerList

                For i = 0 To G_dtCustomer.Rows.Count - 1
                    rCustList = G_dtCustomer.Rows(i)
                    Me.cmbLoc.Items.Add(Trim(rCustList("Loc_Name")))
                Next i

            Catch ex As Exception
                Throw ex
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
                rCustList = Nothing
            End Try
        End Sub

        '*********************************************************
        Private Function PopulateAddressByCustomer() As String
            Dim iLocation As Integer = 0
            Dim drAddress As DataRow
            Dim strAddress As String = ""
            Dim strState As String = ""
            Dim strCountry As String = ""
            Dim iCount As Integer = 0

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                'Get Value from Customer DataTable
                iLocation = Get_LocationID()

                If iLocation > 0 Then
                    'Assemble Address
                    '//Get State Value
                    drAddress = Me.G_objMessShip.GetLocInfo_ByLoc_ID(iLocation)

                    strState = Get_StateShortDesc(drAddress("State_ID"))     '//Translate State to Text
                    strCountry = Get_CountryText(drAddress("Cntry_ID")) '//Translate Country to Text

                    If Not IsDBNull(drAddress("Loc_Address1")) Then
                        strAddress += drAddress("Loc_Address1") & vbCrLf
                    End If

                    If Not IsDBNull(drAddress("Loc_Address2")) Then
                        strAddress += drAddress("Loc_Address2") & vbCrLf
                    End If

                    If Not IsDBNull(drAddress("Loc_City")) Then
                        strAddress += drAddress("Loc_City") & ", "
                    End If

                    If Not IsDBNull(strState) Then
                        strAddress += strState & ", "
                    End If

                    If Not IsDBNull(drAddress("Loc_Zip")) Then
                        strAddress += drAddress("Loc_Zip") & vbCrLf
                    End If

                    If Not IsDBNull(strCountry) Then
                        strAddress += strCountry
                    End If
                End If

                Return strAddress
            Catch ex As Exception
                Throw ex
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
                drAddress = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function PopulateAddressByPO(ByVal iPO_ID As Integer) As String
            Dim R1, R2, R3 As DataRow
            Dim iShipLoc As Integer = 0
            Dim dtAddress As DataTable
            Dim strAddress As String = ""
            Dim strState As String
            Dim strCountry As String = ""
            Dim dtPOAddID As DataTable

            Try
                dtPOAddID = Me.G_objMessShip.GetShipInfo_Fr_PO(iPO_ID)

                For Each R1 In dtPOAddID.Rows

                    If IsDBNull(R1("ShipTo_ID")) = False Then
                        G_iShipToID = Trim(R1("ShipTo_ID")) '//New July 24 2003
                        G_iShipto2ID = Trim(R1("ShipTo_ID")) '//New July 24 2003
                        iShipLoc = Trim(R1("Loc_ID"))

                        dtAddress = Me.G_objMessShip.GetShipToInfo_ByShipToID(G_iShipToID)

                        '//Get the appropriate address for display
                        For Each R2 In dtAddress.Rows

                            If Not IsDBNull(R2("State_ID")) Then
                                strState = Get_StateShortDesc(R2("State_ID"))     '//Translate State to Text
                            End If

                            If Not IsDBNull(R2("Cntry_ID")) Then
                                strCountry = Get_CountryText(R2("Cntry_ID")) '//Translate Country to Text
                            End If

                            If Not IsDBNull(R2("ShipTo_Address1")) Then
                                lblCompany.Text = Trim(R2("ShipTo_Name"))
                            End If

                            If Not IsDBNull(R2("ShipTo_Address1")) Then
                                strAddress += R2("ShipTo_Address1") & vbCrLf
                            End If

                            If Not IsDBNull(R2("ShipTo_Address2")) Then
                                strAddress += R2("ShipTo_Address2") & vbCrLf
                            End If

                            If Not IsDBNull(R2("ShipTo_City")) Then
                                strAddress += R2("ShipTo_City") & ", "
                            End If

                            If Not IsDBNull(strState) Then
                                strAddress += strState & ", "
                            End If

                            If Not IsDBNull(R2("ShipTo_Zip")) Then
                                strAddress += R2("ShipTo_Zip") & vbCrLf
                            End If

                            If Not IsDBNull(strCountry) Then
                                strAddress += strCountry
                            End If
                        Next R2

                        'populate device list
                        '//This section will get a datatable of all devices for this location
                        G_dtDevice = Me.G_objMessShip.GetMessBilledDeviceInWIP_ByLocID(iShipLoc)

                        Exit For
                    Else
                        iShipLoc = Trim(R1("Loc_ID"))
                        dtAddress = Me.G_objMessShip.GetShipToInfo_ByLocID(iShipLoc)

                        '//Get the appropriate address for display
                        For Each R2 In dtAddress.Rows

                            If Not IsDBNull(R2("State_ID")) Then
                                strState = Get_StateShortDesc(R2("State_ID"))     '//Translate State to Text
                            End If

                            If Not IsDBNull(R2("Cntry_ID")) Then
                                strCountry = Get_CountryText(R2("Cntry_ID")) '//Translate Country to Text
                            End If

                            If Not IsDBNull(R2("Loc_Address1")) Then
                                strAddress += R2("Loc_Address1") & vbCrLf
                            End If

                            If Not IsDBNull(R2("Loc_Address2")) Then
                                strAddress += R2("Loc_Address2") & vbCrLf
                            End If

                            If Not IsDBNull(R2("Loc_City")) Then
                                strAddress += R2("Loc_City") & ", "
                            End If

                            If Not IsDBNull(strState) Then
                                strAddress += strState & ", "
                            End If

                            If Not IsDBNull(R2("Loc_Zip")) Then
                                strAddress += R2("Loc_Zip") & vbCrLf
                            End If

                            If Not IsDBNull(strCountry) Then
                                strAddress += strCountry
                            End If

                            '//This section of code will assign the company name to the form
                            For Each R3 In G_dtCustomer.Rows
                                If Trim(R3("Loc_ID")) = Trim(iShipLoc) Then
                                    lblCompany.Text = Trim(R3("PCo_Name"))
                                    Exit For
                                End If
                            Next

                            'populate device list
                            '//This section will get a datatable of all devices for this location
                            G_dtDevice = Me.G_objMessShip.GetMessBilledDeviceInWIP_ByLocID(iShipLoc)

                        Next R2

                        Exit For
                    End If
                Next R1

                Return strAddress
            Catch ex As Exception
                Throw ex
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
                If Not IsNothing(dtPOAddID) Then
                    dtPOAddID.Dispose()
                    dtPOAddID = Nothing
                End If
                If Not IsNothing(dtAddress) Then
                    dtAddress.Dispose()
                    dtAddress = Nothing
                End If
                R1 = Nothing
                R2 = Nothing
                R3 = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function PopulateAddressByCustomerEndUser() As String
            Dim drAddress As DataRow
            Dim strAddress As String = ""
            Dim strState As String = ""
            Dim strCountry As String = ""

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                drAddress = Me.G_objMessShip.GetLocInfo_ByLoc_ID(G_iLocID)

                If Not IsNothing(drAddress) Then

                    If Not IsDBNull(drAddress("State_ID")) Then
                        strState = Get_StateShortDesc(drAddress("State_ID"))     '//Translate State to Text
                    End If

                    If Not IsDBNull(drAddress("Cntry_ID")) Then
                        strCountry = Get_CountryText(drAddress("Cntry_ID")) '//Translate Country to Text
                    End If

                    If Not IsDBNull(drAddress("Loc_Address1")) Then
                        strAddress += drAddress("Loc_Address1") & vbCrLf
                    End If

                    If Not IsDBNull(drAddress("Loc_Address2")) Then
                        strAddress += drAddress("Loc_Address2") & vbCrLf
                    End If

                    If Not IsDBNull(drAddress("Loc_City")) Then
                        strAddress += drAddress("Loc_City") & ", "
                    End If

                    If Not IsDBNull(strState) Then
                        strAddress += strState & ", "
                    End If

                    If Not IsDBNull(drAddress("Loc_Zip")) Then
                        strAddress += drAddress("Loc_Zip") & vbCrLf
                    End If

                    If Not IsDBNull(strCountry) Then
                        strAddress += strCountry
                    End If
                End If

                Return strAddress
            Catch ex As Exception
                Throw ex
            Finally
                drAddress = Nothing
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Function

        '*********************************************************
        Private Sub GetState()
            Try
                '//This creates thae dataset to hold State Names for Translation from ID
                G_dtState = Me.G_objMessShip.GetAllState
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************
        Private Sub GetCountry()

            Try
                '//This creates thae dataset to hold Country Names for Translation from ID
                G_dtCountry = Me.G_objMessShip.GetAllCountry
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '************************************************************************
        Public Function FormatDate(ByVal datStartDate As Date) As String
            FormatDate = ""

            Dim strMnth As String
            Dim strDay As String
            Dim strYear As String

            Dim strHour As String
            Dim strMinute As String
            Dim strSecond As String

            Dim datDate As Date
            datDate = datStartDate

            strMnth = DatePart(DateInterval.Month, datDate)
            strDay = DatePart(DateInterval.Day, datDate)
            If Len(strDay) < 2 Then strDay = "0" & strDay
            If Len(strMnth) < 2 Then strMnth = "0" & strMnth
            strYear = DatePart(DateInterval.Year, datDate)

            strHour = DatePart(DateInterval.Hour, datDate)
            strMinute = DatePart(DateInterval.Minute, datDate)
            strSecond = DatePart(DateInterval.Second, datDate)

            FormatDate = strYear & "-" & strMnth & "-" & strDay & " " & strHour & ":" & strMinute & ":" & strSecond
        End Function

        '*********************************************************
        Private Sub TDBGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TDBGrid1.KeyDown

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                '//Hitting the ESC key from TDBGrid1 will close out the duplicate grid
                '//and clear out its contents. Focus will be set to txtPager
                If e.KeyValue = 27 Then
                    txtPager.Text = ""
                    txtPager.Focus()
                    TDBGrid1.Visible = False
                    G_dtDupDataGrid.Rows.Clear()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "TDBGrid1_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '*********************************************************
        Private Sub Combo_click()
            Dim dr As DataRow
            Dim R1 As DataRow
            Dim locationSTR As String
            Dim msg, title, response As String


            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                If Len(Me.cmbLoc.Text) > 0 Then

                    '//NEW CODE - CHeck to see if location is being redirected. If so then exit
                    dr = Me.G_objMessShip.GetShipChangeInfo_ByLocID(G_iLocID)
                    If Not IsNothing(dr) Then
                        If Not IsDBNull(dr("Loc_ID_To")) Then
                            If Trim(dr("Loc_ID_To")) <> Trim(G_iLocID) Then
                                If dr("Loc_ID_To") > 0 Then

                                    R1 = Me.G_objMessShip.GetLocInfo_ByLoc_ID(dr("Loc_ID_To"))
                                    If Not IsNothing(R1) Then
                                        locationSTR = R1("Loc_Name")
                                        MsgBox("This location now ships to " & locationSTR & ". Please select and continue.", MsgBoxStyle.OKOnly, "Ship Change")
                                        Me.cmbLoc.Text = locationSTR
                                        Me.cmbLoc.Focus()
                                    End If
                                End If
                            End If
                        End If
                    End If

                    '//NEW CODE - CHeck to see if location is being redirected. If so then exit-END
                    G_iCreditShip = 99  '//Failure Code

                    'Get CreditShip from Customer DataTable
                    '//This section of code will assign the company name to the form
                    R1 = Nothing
                    For Each R1 In G_dtCustomer.Rows
                        If R1("Loc_Name") = Me.cmbLoc.Text Then
                            G_iCreditShip = R1("Cust_CrApproveShip")
                            lblCompany.Text = R1("PCo_Name")
                            Exit For
                        End If
                    Next R1

                    If G_iCreditShip = 99 Then
                        '//Credit value could not be obtained throw error
                        msg = "The Credit Value could not be determined. Contact IT to verify."
                        title = "Error getting Credit Value"
                        MsgBox(msg, MsgBoxStyle.OKOnly, title)
                        Me.cmbLoc.Focus()
                        Cursor.Current = System.Windows.Forms.Cursors.Default
                        Exit Sub
                    End If

                    If G_iCreditShip <> 1 Then
                        msg = "The Customer Account is waiting credit approval. Call ext 235 for status on Credit." & vbCrLf _
                        & "Do you wish to continue"
                        title = "Error Credit Not Approved ?"
Loop_Msg:
                        response = MsgBox(msg, MsgBoxStyle.YesNo, title)
                        If response <> vbYes Then GoTo Loop_Msg
                        Me.cmbLoc.Text = ""
                        Me.cmbLoc.Focus()
                        lblCompany.Text = ""
                        lblAddress.Text = ""
                        Me.cmbLoc.Text = ""
                        Exit Sub
                    End If

                    '//This section will generate the address for the customer
                    lblAddress.Text = PopulateAddressByCustomer()

                    '//Change to Code June 25, 2003
                    'This new segment will allow any device from any customer location 
                    'to be sent to any other defined location for that customer. A trigger labeled
                    'tcustomer.cust_lvlShipCust must be set to 1
                    If G_iCustShipLvl = 1 Then
                        G_dtDevice = Me.G_objMessShip.GetMessBilledDeviceInWIP_ByShipChangeLocID(G_iLocID)
                        G_lngwoFlag = 0
                        '//This is NEW July 8, 2003
                        If G_dtDevice.Rows.Count < 1 Then
                            G_dtDevice = Me.G_objMessShip.GetMessBilledDeviceInWIP_ByLocID(G_iLocID)
                        End If
                        '//This is NEW July 8, 2003 - END
                    Else
                        G_dtDevice = Me.G_objMessShip.GetMessBilledDeviceInWIP_ByLocID(G_iLocID)
                        G_lngwoFlag = 0
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "combo_click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                dr = Nothing
                R1 = Nothing
                Me.cmbModel.DroppedDown = True
                Me.cmbModel.Focus()
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '*********************************************************
        Private Function Get_CustomerID() As Integer
            Dim iCust_id As Integer = 0  '//Initialize Return Value
            Dim drCustomer As DataRow

            Try
                For Each drCustomer In G_dtCustomer.Rows
                    If drCustomer("Loc_Name") = Me.cmbLoc.Text Then
                        iCust_id = Trim(drCustomer("Cust_ID"))
                        Exit For
                    End If
                Next drCustomer

                Return iCust_id
            Catch ex As Exception
                Throw ex
            Finally
                drCustomer = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function Get_CustomerShipLvl() As Integer
            Dim iCustomerShipLvl As Integer = 0    '//Initialize Return Value
            Dim drCustomer As DataRow
            Dim i As Integer = 0

            Try
                For i = 0 To G_dtCustomer.Rows.Count - 1
                    drCustomer = G_dtCustomer.Rows(i)
                    If drCustomer("Loc_Name") = Me.cmbLoc.Text Then
                        iCustomerShipLvl = Trim(drCustomer("Cust_lvlShipCust"))
                        Exit For
                    End If
                Next i

                Return iCustomerShipLvl
            Catch ex As Exception
                Throw ex
            Finally
                drCustomer = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function Get_ManDet() As Integer
            Dim iManDel As Integer = 0
            Dim drCustomer As DataRow
            Dim i As Integer = 0

            Try
                For i = 0 To G_dtCustomer.Rows.Count - 1
                    drCustomer = G_dtCustomer.Rows(i)
                    If Trim(drCustomer("Loc_Name")) = Me.cmbLoc.Text Then
                        iManDel = Trim(drCustomer("Loc_ManifestDetail"))
                        Exit For
                    End If
                Next i

                Return iManDel
            Catch ex As Exception
                Throw ex
            Finally
                drCustomer = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function Get_LocationID() As Integer
            Dim iLoc_ID As Integer = 0
            Dim drCustomer As DataRow
            Dim i As Integer = 0

            Try
                For i = 0 To G_dtCustomer.Rows.Count - 1
                    drCustomer = G_dtCustomer.Rows(i)
                    If drCustomer("Loc_Name") = Me.cmbLoc.Text Then
                        iLoc_ID = drCustomer("Loc_ID")
                        Exit For
                    End If
                Next i

                Return iLoc_ID
            Catch ex As Exception
                Throw ex
            Finally
                drCustomer = Nothing
            End Try
        End Function

        '*********************************************************
        Private Sub txtPager_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPager.KeyDown
            Dim iFirst_Pager As Integer = 0
            Dim strMsg As String = ""
            Dim strTitle As String = ""
            Dim strResponse As String = ""
            Dim rWO As DataRow
            Dim iFindManufID As Integer = 0
            Dim iFindProdID As Integer = 0
            Dim iFindManufWrty As Integer = 0
            Dim rDevice As DataRow
            Dim iDeviceCount As Integer = 0
            Dim i As Integer = 0
            Dim dtDuplicate As DataTable
            Dim rDupDev As DataRow
            Dim dtDBR As DataTable
            Dim strVar As String
            Dim blnDBR As Boolean = False
            Dim st_ID As Integer = 0
            Dim booCheckBilled As Boolean
            Dim strFreq As String = ""
            Dim iPOID As Integer = 0
            Dim booQCFuncResult As Boolean = False
            Dim booQCAQLResult As Boolean = False
            Dim objGeneric As PSS.Data.Buisness.Generic
            Dim imaxBill As Integer
            Dim booRUR_NER_Bill As Boolean
            Dim objMess As New Buisness.Messaging()
            Dim dtMess As DataTable

            Try
                iFirst_Pager = 0

                '*************************************************
                'User press esc key to clear all devices in list box
                '*************************************************
                If e.KeyValue = 27 Then
                    If lstDevices.Items.Count = 0 Then
                        Exit Sub
                    End If

                    strMsg = "You are about to clear all devices within the list box. " _
                    & "Click Ok to clear all devices from the list box. Click Cancel to return."
                    strTitle = "Warning Message"
                    strResponse = MsgBox(strMsg, 49, strTitle)
                    If strResponse = 1 Then
                        lstDevices.Items.Clear()
                        G_dtSelected.Rows.Clear()
                        Me.lblFreqNum.Text = ""
                        txtPager.Text = ""
                        txtPager.Focus()
                        lblCount.Text = "0"
                        G_iCount1 = 0
                        Exit Sub
                    End If
                End If

                '***********************************
                'Enter key when user scan device SN
                '***********************************
                If e.KeyValue = 13 Then
                    If Trim(Me.txtPager.Text) = "" Then
                        Exit Sub
                    End If

                    '***********************************
                    'Limit up to 25, CInt(lblCount.Text) >= 25
                    '***********************************

                    If Me.lstDevices.Items.Count >= 25 Then
                        MessageBox.Show("You have reached the limit of ""25 Devices"". Please click ""Print"" button before you continue.", "SN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtPager.Text = ""
                        Exit Sub
                    End If
                    '*********************************************
                    'Added by Lan on 11/13/2007
                    'Prevent user from mix model in Ship Manifest
                    '*********************************************
                    If Me.cmbModel.SelectedValue = 0 Then
                        MessageBox.Show("Please select model.", "Validate Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtPager.Text = ""
                        Me.cmbModel.DroppedDown = True
                        Me.cmbModel.Focus()
                        Exit Sub
                    End If
                    '*********************************************

                    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                    'Reset global variable
                    G_strFindDevice = ""
                    G_iFindDeviceID = 0
                    G_iFindWOID = 0
                    G_iFindTrayID = 0
                    G_dtDupDataGrid.Rows.Clear()

                    txtPager.Text = UCase(Trim(txtPager.Text))

                    '//Look for device serial number in dtDevice

                    G_strFindDevice = ""
                    For Each rDevice In G_dtDevice.Rows
                        If Trim(rDevice("Device_SN")) = Trim(txtPager.Text) Then
                            '*********************************************
                            'Added by Lan on 11/13/2007
                            'Prevent user from mix model in Ship Manifest
                            '*********************************************
                            If Trim(rDevice("Model_ID")) <> Me.cmbModel.SelectedValue Then
                                MessageBox.Show("WRONG MODEL.", "Validate Model", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.AddItemToListBoxControl(Me.lstWrongModel, Trim(txtPager.Text))
                                Me.SetListBoxControl(Me.lstWrongModel, Me.lblWrongModel)
                                Me.txtPager.Text = ""
                                Exit Sub
                            End If
                            '*********************************************

                            G_strFindDevice = Trim(rDevice("Device_SN"))
                            G_iFindWOID = Trim(rDevice("WO_ID"))
                            If G_lngwoFlag = 0 Then G_lngwoFlag = G_iFindWOID
                            G_strFindSN = Trim(rDevice("Device_SN"))
                            G_iFindDeviceID = Trim(rDevice("Device_ID"))
                            G_iFindTrayID = Trim(rDevice("Tray_ID"))
                            iFindManufID = Trim(rDevice("Manuf_ID"))
                            iFindProdID = Trim(rDevice("Prod_ID"))
                            iFindManufWrty = Trim(rDevice("Device_ManufWrty"))
                            iDeviceCount += 1
                        End If
                    Next rDevice

                    '//Craig D. Haney - August 8, 2005
                    If G_iLocID = 2615 Then
                        If G_iFindWOID <> G_lngwoFlag Then
                            MsgBox("This device is not part of the currently selected workorder. The device can not be added.", MsgBoxStyle.Critical, "Error in Selection")
                            txtPager.Text = ""
                            txtPager.Focus()
                            Cursor.Current = System.Windows.Forms.Cursors.Default
                            Exit Sub
                        End If
                    End If
                    '//Craig D. Haney - August 8, 2005

                    If G_iFindDeviceID = 0 Then
                        strMsg = "Can not find Device !! There are several reasons why" _
                        & vbCrLf & "   1)  Device does not belong to this Customer.  " _
                        & vbCrLf & "   2)  Device has not been Billed." _
                        & vbCrLf & "   3)  Device was never Received." _
                        & vbCrLf & "   4)  Device has already been shipped.  " _
                        & vbCrLf & "You can not add this Device.  Do you wish to continue?"
Loop_Msg1:
                        strResponse = MsgBox(strMsg, 260, "Error in Selection")
                        If strResponse <> vbYes Then GoTo Loop_Msg1
                        txtPager.Text = ""
                        txtPager.Focus()
                        Exit Sub
                    Else
                        'check for duplicate in list
                        For i = 0 To lstDevices.Items.Count - 1
                            If UCase(Trim(lstDevices.Items(i))) = UCase(Trim(txtPager.Text)) Then
                                txtPager.Text = ""
                                Exit Sub
                            End If
                        Next i

                        '//New September, 11 2003 Added valLocID to CheckDupDevice
                        dtDuplicate = Me.G_objMessShip.Ship_CheckDupDevice(G_strFindDevice, G_iLocID)
                        '//New September, 11 2003 Added valLocID to CheckDupDevice-END

                        If dtDuplicate.Rows.Count > 1 Then '//Duplicate Exists
                            rDevice = Nothing
                            TDBGrid1.Visible = True

                            For Each rDevice In dtDuplicate.Rows
                                '//Add elements to grid
                                rDupDev = G_dtDupDataGrid.NewRow
                                rDupDev("ID") = rDevice("Device_ID")
                                rDupDev("Manufacturer") = rDevice("Manuf_Desc")
                                rDupDev("Model") = rDevice("Model_Desc")
                                rDupDev("Date Rec") = rDevice("Device_DateRec")
                                rDupDev("Serial Num") = rDevice("Device_SN")
                                rDupDev("OLD Serial Num") = rDevice("Device_OldSN")
                                rDupDev("Tray") = rDevice("Tray_ID")
                                rDupDev("WorkOrder") = rDevice("WO_ID")
                                G_dtDupDataGrid.Rows.Add(rDupDev)
                                G_dtDupDataGrid.AcceptChanges()

                                rDupDev = Nothing
                            Next rDevice

                            TDBGrid1.DataSource = Nothing
                            TDBGrid1.DataSource = G_dtDupDataGrid.DefaultView
                            Exit Sub
                        ElseIf dtDuplicate.Rows.Count < 1 Then
                            '//do nothing
                        Else
                            Dim rGetVal As DataRow
                            rGetVal = dtDuplicate.Rows(0)
                            G_iWorkorderID = Trim(rGetVal("WO_ID"))
                        End If
                    End If

                    '*********************************************
                    'Added by Lan on 04/23/2008
                    'Prevent user from ship device without qc test
                    '*********************************************
                    If G_iCustID = 14 Then 'American Messaging
                        PSS.Data.Buisness.Generic.GetQCFuncAQLResults(G_iFindDeviceID, booQCFuncResult, booQCAQLResult)
                        If booQCFuncResult = False Then
                            MessageBox.Show("Device has not been QC (Functional) PASSED.", "QC Functional Check", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.AddItemToListBoxControl(Me.lstNoQCPass, Trim(txtPager.Text))
                            Me.SetListBoxControl(Me.lstNoQCPass, Me.lblNoQCPass)
                            Me.txtPager.Text = ""
                            Exit Sub
                        ElseIf booQCAQLResult = False Then
                            MessageBox.Show("Device has been failed at AQL Test.", "AQL Check", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Me.AddItemToListBoxControl(Me.lstNoQCPass, Trim(txtPager.Text))
                            Me.SetListBoxControl(Me.lstNoQCPass, Me.lblNoQCPass)
                            Me.txtPager.Text = ""
                            Exit Sub
                        End If
                        'If Me.G_objMessShip.IsQCPassed(G_iFindDeviceID) = False Then
                        '    MessageBox.Show("Device has not been QC PASSED.", "QC Check", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        '    Me.AddItemToListBoxControl(Me.lstNoQCPass, Trim(txtPager.Text))
                        '    Me.SetListBoxControl(Me.lstNoQCPass, Me.lblNoQCPass)
                        '    Me.txtPager.Text = ""
                        '    Exit Sub
                        'End If
                    End If
                    '*********************************************

                    '*******************************************************************************
                    'The following code added by Asif on 03/08/2004
                    'This piece of code checks for Missing data for each device
                    'and rejects it if any required data is missing.
                    '*******************************************************************************
                    ''//Comment 101: Call this only for motorola Manufacturer, Prod_ID = 2 that is cel phone
                    'Also it is assumed that the device is under manuf warranty
                    If iFindManufID = 1 And iFindProdID = 2 And iFindManufWrty = 1 Then
                        '//Craig Haney - check to see if device is DBR or RUR
                        dtDBR = Me.G_objMessShip.CheckDeviceDBR(G_iFindDeviceID)

                        rDevice = Nothing

                        For Each rDevice In dtDBR.Rows
                            If rDevice("billcode_rule") = 1 Or rDevice("billcode_rule") = 2 Then
                                strVar = ""
                                blnDBR = True
                                Exit For
                            End If
                        Next
                        '//Craig Haney - check to see if device is DBR or RUR - END

                        If blnDBR = False Then
                            strVar = Me.CheckForMissingDataForMotorola(G_iFindDeviceID)
                            If strVar <> "" Then
                                MsgBox(strVar + System.Environment.NewLine + vbCrLf + "Can't ship this device at this time. Take this error message to the receiver/tech who worked on it.", MsgBoxStyle.Information, "Motorola Warranty Data Missing")
                                txtPager.Text = ""
                                txtPager.Focus()
                                Cursor.Current = System.Windows.Forms.Cursors.Default
                                Exit Sub
                            End If
                        End If
                    End If
                    ''//End comment 101
                    '*******************************************************************************

                    'addrecord to list
                    If G_iCount1 = 0 Then
                        'get workorder
                        If G_iFindWOID > 0 Then
                            rWO = Me.G_objMessShip.GetWorkOrderInfo_ByWOID(G_iFindWOID)
                            If Not IsNothing(rWO) Then
                                If IsDBNull(rWO("ShipTo_ID")) Then
                                    G_iShipToID = 0
                                    st_ID = 0
                                Else
                                    G_iShipToID = Trim(rWO("ShipTo_ID"))
                                    st_ID = Trim(rWO("ShipTo_ID"))
                                End If
                            Else
                                MessageBox.Show("Can not find WO for device.", "Get Ship ID from WO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                                txtPager.Text = ""
                                txtPager.Focus()
                                Exit Sub
                            End If
                        Else
                            MessageBox.Show("Can not find WO for device.", "Get Ship ID from WO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            txtPager.Text = ""
                            txtPager.Focus()
                            Exit Sub
                        End If
                    Else
                        If G_iFindWOID > 0 Then
                            rWO = Me.G_objMessShip.GetWorkOrderInfo_ByWOID(G_iFindWOID)
                            If Not IsNothing(rWO) Then
                                If IsDBNull(rWO("ShipTo_ID")) Then
                                    st_ID = 0
                                Else
                                    st_ID = Trim(rWO("ShipTo_ID"))
                                End If
                            End If
                        Else
                            MessageBox.Show("Can not find WO for device.", "Get Ship ID from WO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            txtPager.Text = ""
                            txtPager.Focus()
                            Exit Sub
                        End If
                    End If

                    '//Before adding make sure the shipto address is the same as what is already in list
                    ''findWO = TDBGrid1.Columns(7).Value
                    If st_ID <> G_iShipToID Then
                        strMsg = "This device is being shipped to a different location. You can not mix these types of devices." _
                        & "You can not add this device."
                        strTitle = "Error in Selection"
                        strResponse = MsgBox(strMsg, MsgBoxStyle.OKOnly, strTitle)
                        txtPager.Text = ""
                        txtPager.Focus()
                        Exit Sub
                    End If

                    'Added by Lan on 05/16/2009
                    'Unit with POID = 44 must billed Crystal.
                    If Me.G_iCustID = 14 AndAlso Not IsNothing(rWO) AndAlso Not IsDBNull(rWO("PO_ID")) Then iPOID = rWO("PO_ID")

                    '//Verify that a billable element has occurred
                    booCheckBilled = checkBillPerformed(G_iFindDeviceID, iPOID)
                    If booCheckBilled = False Then
                        txtPager.Text = ""
                        txtPager.Focus()
                        TDBGrid1.Visible = False
                        G_dtDupDataGrid.Rows.Clear()
                        Exit Sub
                    End If

                    '******************************************
                    'Added by Lan on 11/11/2007
                    'Prevent user from mix Freq  Ship Manifest
                    '******************************************
                    'Only apply to American Messaging Customer of Non-2way devices
                    If Me.G_iCustID = 14 And Me.cmbModel.SelectedValue <> 87 And Me.cmbModel.SelectedValue <> 808 Then
                        strFreq = Me.G_objMessShip.GetDeviceFreq(Me.G_iFindDeviceID)

                        If strFreq = "" Then
                            MessageBox.Show("Can not define frequency for scanned device.", "Get Device's Frequency", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            If Me.lblFreqNum.Text <> "" Then
                                Me.lstWrongFreq.Items.Add(Trim(Me.txtPager.Text))
                                Me.SetListBoxControl(Me.lstWrongFreq, Me.lblWrongFreq)
                            End If
                            Me.txtPager.Text = ""
                            Exit Sub
                        End If

                        If Me.lstDevices.Items.Count = 0 Then
                            If MessageBox.Show("You are about to ship tray of devices under this frequency """ & strFreq & """" & Environment.NewLine & "Would you like to continue?", "Confirm Freq", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                                Me.lblFreqNum.Text = ""
                                Me.txtPager.Text = ""
                                Exit Sub
                            End If

                            Me.lblFreqNum.Text = Trim(strFreq)

                        Else
                            If Me.lblFreqNum.Text = "" Then
                                MessageBox.Show("No Frequency defined for tray.", "Validate Frequency", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.txtPager.Text = ""
                                Exit Sub
                            ElseIf Trim(Me.lblFreqNum.Text) <> Trim(strFreq) Then
                                MessageBox.Show("Frequency of scanned device """ & strFreq & """ does not match with frequency on the list. Can not mix frequency in the tray.", "Validate Frequency", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                                Me.AddItemToListBoxControl(Me.lstWrongFreq, Trim(Me.txtPager.Text))
                                Me.SetListBoxControl(Me.lstWrongFreq, Me.lblWrongFreq)
                                Me.txtPager.Text = ""
                                Exit Sub
                            End If
                        End If
                    End If

                    '******************************************
                    'Added by Hung on 09/27/2011
                    'Prevent user from mix RUR/NER with Repair devices 
                    ' maxbill equal 1 or 2 = RUR/NER
                    ' maxbill NOT equal  1 or 2 = REPAIR
                    ' Billrule table = SELECT * FROM lbillrule;
                    '******************************************
                    objGeneric = New PSS.Data.Buisness.Generic()

                    imaxBill = objGeneric.GetMaxBillRule(Me.G_iFindDeviceID)
                    If imaxBill = 1 Or imaxBill = 2 Then
                        booRUR_NER_Bill = True
                    Else
                        booRUR_NER_Bill = False
                    End If

                    If Me.lstDevices.Items.Count = 0 Then
                        'Set global RUR/NER for first serial entry
                        G_RUR_NER = booRUR_NER_Bill
                    Else
                        'Check RUR/NER on 2nd and rest of serial entry
                        If booRUR_NER_Bill = True And G_RUR_NER = False Then
                            MessageBox.Show("Can't mix RUR/NER to Repair devices.", "Type Mismatch !", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        ElseIf booRUR_NER_Bill = False And G_RUR_NER = True Then
                            MessageBox.Show("Can't mix Repair to RUR/NER devices.", "Type Mismatch !", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If

                    '******************************************
                    'Added by Hung on 10/20/2011
                    ' 1-Prevent user from mix none RMA with RMA 
                    ' 2-Prevent user from mix two different RMA 
                    ' Aquis Customer_ID=444 Aquis Location_ID=442
                    '******************************************
                    If Me.G_iCustID = 444 And Me.G_iLocID = 442 Then

                        Dim iWR_ID As Integer = 0
                        Dim booRMA As Boolean = False
                        Dim strRMA As String = ""

                        dtMess = objMess.getPagerInfoByDeviceID(Me.G_iCustID, Me.G_iLocID, Me.G_iFindDeviceID)
                        If dtMess.Rows.Count = 0 Then
                            MessageBox.Show("This serial#" & Me.txtPager.Text & " does not exist in the Aquis Warehouse Receipts System or hasn't transfer to production. Please contact your Supervisor/Leader immediately....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If

                        If IsDBNull(dtMess.Rows(0)("RMA")) Then
                            strRMA = "N/A"
                        Else
                            strRMA = Trim(dtMess.Rows(0)("RMA"))
                        End If
                        If Me.lstDevices.Items.Count = 0 Then
                            'Set global Warehouse Receipt ID and RMA flag for first serial entry
                            If Len(strRMA) > 0 AndAlso strRMA <> "N/A" Then
                                Me.G_WR_ID = dtMess.Rows(0)("WR_ID")
                                Me.G_booRMA = True
                                Me.G_strRMA = strRMA
                            Else
                                Me.G_WR_ID = 0
                                Me.G_booRMA = False
                            End If
                        Else
                            iWR_ID = dtMess.Rows(0)("WR_ID")
                            ' If Len(strRMA) > 0 Then booRMA = True
                            'If booRMA = True And Me.G_booRMA = False Then
                            '    MessageBox.Show("Can't mix Warehouse Receipt RMA#" & strRMA & " with none RMA....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            '    Exit Sub
                            'ElseIf booRMA = False And Me.G_booRMA = True Then
                            '    MessageBox.Show("Can't mix Warehouse Receipt none RMA with RMA#" & Me.G_strRMA & ".....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            '    Exit Sub
                            'ElseIf Me.G_booRMA = True And booRMA = True And iWR_ID <> Me.G_WR_ID Then
                            '    MessageBox.Show("Can't mix Warehouse Receipt RMA#" & strRMA & " with RMA#" & Me.G_strRMA & ".....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            '    Exit Sub
                            ' End If

                        End If

                    End If
                    '******************************************
                    'Added by Lan on 07/17/2009
                    'Pss Warranty
                    '******************************************
                    If Me.G_iCustID = 14 Then
                        If Not IsNothing(rWO) Then
                            G_objMessShip.CheckPSSWrty(Me.G_iFindDeviceID, rWO("WO_ID"), rWO("Loc_ID"), PSS.Core.ApplicationUser.IDuser, rWO("WO_CustWO"))
                        Else
                            G_objMessShip.CheckPSSWrty(Me.G_iFindDeviceID, rWO("WO_ID"), rWO("Loc_ID"), PSS.Core.ApplicationUser.IDuser, )
                        End If
                    End If
                    '******************************************

                    '//load data here
                    '//Add device to listbox
                    lstDevices.Items.Add(G_strFindSN)
                    '//Add device to dtSelected

                    rDevice = Nothing
                    rDevice = G_dtSelected.NewRow
                    rDevice("ID") = G_iFindDeviceID
                    rDevice("SNum") = G_strFindSN
                    G_dtSelected.Rows.Add(rDevice)
                    G_dtSelected.AcceptChanges()
                    txtPager.Text = ""
                    txtPager.Focus()
                    TDBGrid1.Visible = False
                    G_dtDupDataGrid.Rows.Clear()

                    G_iCount1 += 1
                    lblCount.Text = G_iCount1

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtPager_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                rWO = Nothing
                rDevice = Nothing
                rDupDev = Nothing
                objGeneric = Nothing
                objMess = Nothing
                If Not IsNothing(dtMess) Then
                    dtMess.Dispose()
                    dtMess = Nothing
                End If
                If Not IsNothing(dtDuplicate) Then
                    dtDuplicate.Dispose()
                    dtDuplicate = Nothing
                End If
                If Not IsNothing(dtDBR) Then
                    dtDBR.Dispose()
                    dtDBR = Nothing
                End If
                If Me.lstDevices.Items.Count > 0 Then
                    Me.btnPrint.Enabled = True
                Else
                    Me.btnPrint.Enabled = False
                End If
            End Try
        End Sub

        '*********************************************************
        Private Sub SetListBoxControl(ByRef ctrl_lstBox As ListBox,
                                      ByRef ctrl_lbl As Label)

            If ctrl_lstBox.Items.Count > 0 Then
                ctrl_lstBox.BackColor = Color.Black
                ctrl_lbl.Visible = True
            Else
                ctrl_lstBox.BackColor = Color.SteelBlue
                ctrl_lbl.Visible = False
            End If
        End Sub

        '*********************************************************
        Private Sub AddItemToListBoxControl(ByRef ctrl_lstBox As ListBox,
                                            ByVal strItem As String)

            Dim i As Integer
            Dim iMatch As Integer = 0

            Try
                If ctrl_lstBox.Items.Count > 0 Then
                    'Check for duplicate
                    For i = 0 To ctrl_lstBox.Items.Count - 1
                        If Trim(strItem) = ctrl_lstBox.Items.Item(i) Then
                            iMatch = 1
                        End If
                    Next i

                    If iMatch = 0 Then
                        ctrl_lstBox.Items.Add(Trim(strItem))
                    End If
                Else
                    ctrl_lstBox.Items.Add(Trim(strItem))
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************
        Private Function Create_dtDupGrid() As DataTable

            '//This will create a datatable that will hold information that will be used to populate TDBGrid1
            '//Detail information for devices with duplicate serial numbers
            Dim dtDupList As New DataTable("dtDuplicateInd")

            Try
                dtDupList.MinimumCapacity = 500
                dtDupList.CaseSensitive = False

                Dim dcID As New DataColumn("ID")
                dtDupList.Columns.Add(dcID)
                Dim dcManuf As New DataColumn("Manufacturer")
                dtDupList.Columns.Add(dcManuf)
                Dim dcModel As New DataColumn("Model")
                dtDupList.Columns.Add(dcModel)
                Dim dcReceived As New DataColumn("Date Rec")
                dtDupList.Columns.Add(dcReceived)
                Dim dcSN As New DataColumn("Serial Num")
                dtDupList.Columns.Add(dcSN)
                Dim dcOldSN As New DataColumn("OLD Serial Num")
                dtDupList.Columns.Add(dcOldSN)
                Dim dcTray As New DataColumn("Tray")
                dtDupList.Columns.Add(dcTray)
                Dim dcWO As New DataColumn("WorkOrder")
                dtDupList.Columns.Add(dcWO)

                Return dtDupList
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************
        Private Function Create_dtSelect() As DataTable

            '//This will create a datatable that will hold selected device information
            Dim dtSelList As New DataTable("dtSelect")
            Dim dcID As New DataColumn("ID")
            Dim dcSN As New DataColumn("SNum")

            Try
                dtSelList.MinimumCapacity = 500
                dtSelList.CaseSensitive = False
                dtSelList.Columns.Add(dcID)
                dtSelList.Columns.Add(dcSN)

                Return dtSelList
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************
        Private Sub TDBGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TDBGrid1.DoubleClick
            Dim iDeviceID As Integer = 0
            Dim strMsg As String = ""
            Dim strTitle As String = ""
            Dim strResponse As String
            Dim rWO As DataRow
            Dim rCheck As DataRow
            Dim st_ID As Integer
            Dim booCheckBilled As Boolean

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                iDeviceID = TDBGrid1.Columns(0).Value

                '//Check in listbox for same device
                For Each rCheck In G_dtSelected.Rows
                    If Trim(rCheck("ID")) = Trim(iDeviceID) Then
                        'This is a duplicate
                        strMsg = "This device has already been added to the shipping manifest. " _
                        & "You can not add this device again.  Do you wish to continue?"
                        strTitle = "Error in Selection"
Loop_Msg7:
                        strResponse = MsgBox(strMsg, 260, strTitle)
                        If strResponse <> vbYes Then GoTo Loop_Msg7
                        txtPager.Text = ""
                        txtPager.Focus()
                        TDBGrid1.Visible = False
                        G_dtDupDataGrid.Rows.Clear()
                        Exit Sub
                    End If
                Next rCheck

                If G_iCount1 = 0 Then
                    'get shipto value from tworkorder
                    G_iFindWOID = TDBGrid1.Columns(7).Value
                    'get workorder
                    If G_iFindWOID > 0 Then
                        rWO = Me.G_objMessShip.GetWorkOrderInfo_ByWOID(G_iFindWOID)
                        If Not IsNothing(rWO) Then
                            'set value for shipto
                            If IsDBNull(rWO("ShipTo_ID")) Then
                                G_iShipToID = 0
                                st_ID = 0
                            Else
                                G_iShipToID = rWO("ShipTo_ID")
                                st_ID = rWO("ShipTo_ID")
                            End If
                        Else
                            MessageBox.Show("Can not find WO for device.", "Get Ship ID from WO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            txtPager.Text = ""
                            txtPager.Focus()
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("Can not find WO for device.", "Get Ship ID from WO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        txtPager.Text = ""
                        txtPager.Focus()
                        Exit Sub
                    End If
                Else
                    G_iFindWOID = TDBGrid1.Columns(7).Value
                    rWO = Me.G_objMessShip.GetWorkOrderInfo_ByWOID(G_iFindWOID)
                    If Not IsNothing(rWO) Then
                        If IsDBNull(rWO("ShipTo_ID")) Then
                            st_ID = 0
                        Else
                            st_ID = rWO("ShipTo_ID")
                        End If
                    Else
                        MessageBox.Show("Can not find WO for device.", "Get Ship ID from WO", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        txtPager.Text = ""
                        txtPager.Focus()
                        Exit Sub
                    End If
                End If

                '//Before adding make sure the shipto address is the same as what is already in list
                If st_ID <> G_iShipToID Then
                    strMsg = "This device is being shipped to a different location. You can not mix these types of devices." _
                    & "You can not add this device."
                    strTitle = "Error in Selection"
                    strResponse = MsgBox(strMsg, MsgBoxStyle.OKOnly, strTitle)
                    txtPager.Text = ""
                    txtPager.Focus()
                    TDBGrid1.Visible = False
                    G_dtDupDataGrid.Rows.Clear()
                    Exit Sub
                End If

                '//Verify that a billable element has occurred

                booCheckBilled = checkBillPerformed(Trim(TDBGrid1.Columns(0).Value))
                If booCheckBilled = False Then
                    txtPager.Text = ""
                    txtPager.Focus()
                    TDBGrid1.Visible = False
                    G_dtDupDataGrid.Rows.Clear()
                    Exit Sub
                End If

                '//Add device to listbox
                lstDevices.Items.Add(TDBGrid1.Columns(4).Value)
                '//Add device to dtSelected
                rCheck = Nothing
                rCheck = G_dtSelected.NewRow
                rCheck("ID") = TDBGrid1.Columns(0).Value
                rCheck("SNum") = TDBGrid1.Columns(4).Value
                G_dtSelected.Rows.Add(rCheck)
                G_dtSelected.AcceptChanges()
                txtPager.Text = ""
                txtPager.Focus()
                TDBGrid1.Visible = False
                G_dtDupDataGrid.Rows.Clear()

                G_iCount1 += 1
                lblCount.Text = G_iCount1

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "TDBGrid1_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                rWO = Nothing
                rCheck = Nothing
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '*********************************************************
        Private Sub lstDevices_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDevices.DoubleClick
            Dim R1 As DataRow

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                '//Perform a delete sequence
                R1 = G_dtSelected.Rows(lstDevices.SelectedIndex)
                If R1("SNum") = lstDevices.SelectedItem Then
                    R1.Delete()
                    lstDevices.Items.RemoveAt(lstDevices.SelectedIndex)
                    txtPager.Focus()

                    G_iCount1 -= 1
                    lblCount.Text = G_iCount1
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "lstDevices_DoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
                R1 = Nothing
            End Try
        End Sub

        '*********************************************************
        Private Function Get_StateShortDesc(ByVal strAddState As String) As String
            Dim strStateShortDesc = ""
            Dim tmpCount As Integer = 0
            Dim R1 As DataRow

            Try
                For Each R1 In G_dtState.Rows
                    If Trim(R1("State_ID")) = strAddState Then
                        strStateShortDesc = R1("State_Short")
                        Exit For
                    End If
                Next R1

                Return strStateShortDesc
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function Get_CountryText(ByVal strAddCountry As String) As String
            Dim strCountryName = ""
            '//Get Country Value
            Dim R1 As DataRow

            Try
                For Each R1 In G_dtCountry.Rows
                    If Trim(R1("Cntry_ID")) = strAddCountry Then
                        strCountryName = R1("Cntry_Name")
                        Exit For
                    End If
                Next R1

                Return strCountryName
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function checkBillPerformed(ByVal iDevice_ID As Integer, Optional ByVal iPOID As Integer = 0) As Boolean
            Dim booReturnVal As Boolean = False
            Dim dtBill As DataTable
            Dim R1 As DataRow

            Try
                dtBill = Me.G_objMessShip.GetAllBillInfo_ByDevicceID(iDevice_ID)

                If dtBill.Rows.Count > 0 Then
                    If Me.G_iCustID = 14 And iPOID = 44 Then
                        For Each R1 In dtBill.Rows
                            If R1("Billcode_ID") = 20 Or R1("Billcode_ID") = 21 Or R1("Billcode_ID") = 25 Or R1("Billcode_ID") = 89 Then
                                booReturnVal = True
                                Exit For
                            End If
                        Next R1
                        If booReturnVal = False Then
                            G_strMsg = "This item can not be shipped because Recrystal billcode is missing."
                            G_strTitle = "Device Not Billed"
                            MsgBox(G_strMsg, MsgBoxStyle.OKOnly, G_strTitle)
                            txtPager.Text = ""
                            txtPager.Focus()
                        End If
                    Else
                        booReturnVal = True
                    End If
                Else
                    G_strMsg = "This item can not be shipped because it has not been billed."
                    G_strTitle = "Device Not Billed"
                    MsgBox(G_strMsg, MsgBoxStyle.OKOnly, G_strTitle)
                    txtPager.Text = ""
                    txtPager.Focus()
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dtBill) Then
                    dtBill.Dispose()
                    dtBill = Nothing
                End If
            End Try
        End Function

        '*********************************************************
        Private Function Insert_tshipto(ByVal iLoc_ID As Integer) As Integer
            Dim strName, strAdd1, strAdd2, strCity, strZip, strState, strCountry As String
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                strName = "Null"
                strAdd1 = "Null"
                strAdd2 = "Null"
                strCity = "Null"
                strZip = "Null"
                strState = "Null"
                strCountry = "Null"

                R1 = Me.G_objMessShip.GetLocInfo_ByLoc_ID(iLoc_ID)

                If Not IsNothing(R1) Then
                    If Trim(Me.lblCompany.Text) <> "" Then
                        strName = "'" & Trim(lblCompany.Text) & "'"
                    End If
                    If IsDBNull(R1("Loc_Address1")) = False Then
                        strAdd1 = "'" & Trim(R1("Loc_Address1")) & "'"
                    End If
                    If IsDBNull(R1("Loc_Address2")) = False Then
                        If Len(R1("Loc_Address2")) > 0 Then
                            strAdd2 = "'" & Trim(R1("Loc_Address2")) & "'"
                        End If
                    End If
                    If IsDBNull(R1("Loc_City")) = False Then
                        strCity = "'" & Trim(R1("Loc_City")) & "'"
                    End If
                    If IsDBNull(R1("Loc_Zip")) = False Then
                        strZip = "'" & Trim(R1("Loc_Zip")) & "'"
                    End If
                    If IsDBNull(R1("State_ID")) = False Then
                        strState = Trim(R1("State_ID"))
                    End If
                    If IsDBNull(R1("Cntry_ID")) = False Then
                        strCountry = Trim(R1("Cntry_ID"))
                    End If
                End If

                i = Me.G_objMessShip.InsertInto_tshipto(strName, _
                                                        strAdd1, _
                                                        strAdd2, _
                                                        strCity, _
                                                        strZip, _
                                                        strState, _
                                                        strCountry)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function Insert_tship() As Long
            Dim i As Integer = 0
            Dim strFieldList As String
            Dim strValueList As String
            Dim strSQL As String

            Try
                If Len(G_strShipName) > 0 Then
                    If G_iProdID > 0 Then
                        strFieldList = "(Ship_User, Ship_Date, Prod_ID"
                        strValueList = "('" & G_strShipName & "', '" & FormatDate(Now) & "', '" & G_iProdID & "'"

                        '//NEW October 19, 2005
                        If G_iCustID = 1 And Len(Trim(G_strFOLOT)) > 0 Then
                            strFieldList += ",Ship_FO"
                            strValueList += ",'" & G_strFOLOT & "'"
                        End If
                        '//NEW October 19, 2005

                        If G_iShipToID <> 0 Then
                            strFieldList += ",ShipTo_ID)"
                            strValueList += "," & G_iShipToID & ")"
                        ElseIf G_iShipto2ID <> 0 Then
                            strFieldList += ",ShipTo_ID)"
                            strValueList += "," & G_iShipto2ID & ")"
                        Else
                            strFieldList += ")"
                            strValueList += ")"
                        End If

                        strSQL = "INSERT INTO tship " & strFieldList & " VALUES " & strValueList & ";"

                        i = Me.G_objMessShip.ExecuteIDTransaction(strSQL, "tship")

                        G_iShipToID = 0
                        G_iShipto2ID = 0
                        Return i
                    End If
                End If

                G_strMsg = "The record could not be entered into the system."
                G_strTitle = "Error Insert Ship Record"
                MsgBox(G_strMsg, MsgBoxStyle.OKOnly, G_strTitle)

                Return i
            Catch ex As Exception
                Throw ex
            Finally
            End Try
        End Function

        '*********************************************************
        Private Function Update_Devices(ByVal iShipID As Integer) As Boolean
            Dim iShift As Integer = 0
            Dim strWorkDate As String = ""
            Dim booReturnVal As Boolean = False
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                iShift = PSS.Core.[Global].ApplicationUser.IDShift
                strWorkDate = PSS.Core.[Global].ApplicationUser.Workdate

                If Len(Trim(strWorkDate)) < 1 Then
                    MsgBox("Your user configuration is incorrect/incomplete. Please contact your direct lead to resolve this problem. Your login will not function until this is resolved.", MsgBoxStyle.Critical, "User Setup Error")
                    End
                End If

                For Each R1 In G_dtSelected.Rows
                    'execute here
                    i += Me.G_objMessShip.UpdateShipInfo(iShipID, iShift, strWorkDate, R1("ID"))
                    If i > 0 Then
                        booReturnVal = True
                    End If
                Next R1

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '*********************************************************
        Private Function Update_RepStat(ByVal valShipID As Integer) As Boolean
            Dim booReturnVal As Boolean = False
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try
                For Each R1 In G_dtSelected.Rows
                    'execute here
                    i += Me.G_objMessShip.UpdateCellopt_RepStatus(R1("ID"))

                    If i > 0 Then
                        booReturnVal = True
                    End If
                Next R1

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
            End Try
        End Function

        '*********************************************************
        Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
            Dim strReportLoc As String = PSS.Core.ReportPath
            Dim lngRecShip As Long
            Dim booShip As Boolean
            Dim booRepStat As Boolean
            Dim objRpt As ReportDocument
            Dim iLoc_ID As Integer = 0
            Dim R1, R2 As DataRow
            Dim dtLocRS As DataTable
            Dim dtrs As DataTable
            Dim strFreq As String
            Dim strWD As String = ""

            Try
                If Me.lstDevices.Items.Count = 0 Then
                    Exit Sub
                End If

                strWD = PSS.Data.Buisness.Generic.GetWorkDate(PSS.Core.[Global].ApplicationUser.IDShift)
                If PSS.Core.[Global].ApplicationUser.Workdate <> strWD Then
                    MsgBox("Unable to determine work date.", MsgBoxStyle.Critical, "Information")
                    End
                End If

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                lngRecShip = Trim(Insert_tship())
                strFreq = Me.lblFreqNum.Text

                '//Update devices
                booShip = Update_Devices(lngRecShip)
                'blnRepStat = Update_RepStat(lngRecShip)

                lstDevices.Items.Clear()
                txtPager.Text = ""
                TDBGrid1.Visible = False
                G_dtDupDataGrid.Clear()
                'DBcbo1.Focus()
                G_iCount1 = 0
                lblCount.Text = G_iCount1
                Me.lblFreqNum.Text = ""


                'Print ship manifest
                objRpt = New ReportDocument()

                With objRpt
                    '.Load(PSS.Core.Global.ReportPath & "Ship_Manifest.rpt")
                    .Load(PSS.Core.[Global].ReportPath & "Ship_Manifest_Mess.rpt")
                    .SetParameterValue("Frequency", strFreq)
                    .RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(lngRecShip)
                    .PrintToPrinter(1, True, 0, 0)
                End With

                '//SET/RESET the valManDet to 0
                '//Performed June 12, 2003
                G_iManDet = 0
                '//SET/RESET the valManDet to 0 - END

                If Len(Trim(Me.cmbLoc.Text)) < 1 Then 'This would be for end users only
                    G_iManDet = 1
                End If

                '//This is new and a possible issue
                '//Performed June 12, 2003
                If Len(Trim(Me.cmbLoc.Text)) > 0 Then 'This would be for everyone else
                    Try
                        dtLocRS = Me.G_objMessShip.GetLocInfo_ByLoc_Name(Trim(Me.cmbLoc.Text))
                        For Each R1 In dtLocRS.Rows
                            G_iManDet = Trim(R1("Loc_ManifestDetail"))
                        Next R1

                    Catch exp As Exception
                        Dim vResponse As MsgBoxResult
                        vResponse = MsgBox("There was a problem determining Manifest Detail status. Print Manifest Detail?", MsgBoxStyle.YesNo, "Manifest Detail")
                        If vResponse = MsgBoxResult.Yes Then
                            G_iManDet = 1
                        Else
                            G_iManDet = 0
                        End If
                    End Try
                End If
                '//This is new and a possible issue - END

                If G_iCustID = 1 Then
                    G_iManDet = 0
                End If

                If G_iManDet = 1 Then
                    Try
                        'Print Ship Manifest detail report
                        objRpt = Nothing
                        objRpt = New ReportDocument()

                        With objRpt
                            .Load(PSS.Core.[Global].ReportPath & "Ship_ManifestDetail.rpt")
                            .RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(lngRecShip)
                            .PrintToPrinter(1, True, 0, 0)
                        End With

                    Catch exp As Exception
                        MsgBox(exp.ToString)
                    End Try
                End If

                'Hung Nguyen Oct 19th, 2011 Remove the FedEx interface per Lan told this Access dBase no longer needed....
                'fedex:

                '                '//write data to fedex database
                '                Dim dtFedex As DataTable
                '                Dim strcon As String = "DRIVER={Microsoft Access Driver (*.mdb)};dbq=g:\fedextrack.mdb"
                '                Dim conn As New OdbcConnection(strcon)
                '                Dim iShipTo_ID As Integer = 0
                '                'Dim iCust_ID As Integer = 0
                '                Dim strCustName As String
                '                Dim strState, strCountry, strFieldNames, strField As String
                '                Dim strContact As String
                '                Dim strPhone As String

                '                Try
                '                    dtrs = Me.G_objMessShip.GetShipInfo_ByShipID(lngRecShip)

                '                    R1 = Nothing
                '                    For Each R1 In dtrs.Rows
                '                        If IsDBNull(R1("ShipTo_ID")) = True Then
                '                            Exit For
                '                        End If
                '                        If Trim(R1("ShipTo_ID")) > 0 Then
                '                            iShipTo_ID = Trim(R1("ShipTo_ID"))
                '                            Exit For
                '                        End If
                '                    Next R1

                '                    'Re-use datatable
                '                    If Not IsNothing(dtLocRS) Then
                '                        dtLocRS.Dispose()
                '                        dtLocRS = Nothing
                '                    End If

                '                    If iShipTo_ID = 0 Then
                '                        dtLocRS = Me.G_objMessShip.GetDevices_ByShipID(lngRecShip)
                '                        R1 = Nothing
                '                        For Each R1 In dtLocRS.Rows
                '                            If Trim(R1("Loc_ID")) > 0 Then
                '                                iLoc_ID = Trim(R1("Loc_ID"))
                '                                'iCust_ID = Trim(r("Cust_ID"))
                '                                Exit For
                '                            End If
                '                        Next R1
                '                    End If

                '                    'If iCust_ID > 0 Then
                '                    R1 = Nothing
                '                    For Each R1 In G_dtCustomer.Rows
                '                        If Trim(R1("Loc_ID")) = iLoc_ID Then
                '                            strCustName = Trim(R1("Cust_Name1"))
                '                            If IsDBNull((R1("Cust_Name2"))) = False Then
                '                                strCustName += " " & Trim(R1("Cust_Name2"))
                '                            End If
                '                            Exit For
                '                        End If
                '                    Next R1
                '                    'End If

                '                    '//Get data to be written
                '                    If iShipTo_ID > 0 Then
                '                        dtrs = Me.G_objMessShip.GetShipToInfo_ByShipToID(iShipTo_ID)

                '                        R1 = Nothing
                '                        For Each R1 In dtrs.Rows
                '                            strCustName = R1("ShipTo_Name")
                '                            G_strContact = "'Null'"
                '                            R2 = Me.G_objMessShip.GetLocInfo_ByLoc_ID(G_iShipID)
                '                            G_strContact = "'" & R2("Loc_Contact") & "'"

                '                            '//Get State
                '                            strState = Me.Get_StateShortDesc(Trim(R1("State_ID")))
                '                            '//Get Country
                '                            strCountry = Me.Get_CountryText(Trim(R1("Cntry_ID")))
                '                            'If Trim(txtcountry) = "United States" Then txtcountry = "US"
                '                            If Trim(strCountry) = "USA" Then strCountry = "US"
                '                            If Trim(strCountry) = "Canada" Then strCountry = "CN"
                '                            strFieldNames = "(Shipping_ID, Cust_Name, Cust_Address1, Cust_Address2, Cust_City, Cust_State_Prov, Cust_Zip, Cust_Country, Date_Entered, Cust_Contact)"
                '                            strField = "(" & lngRecShip & ", '" & strCustName & "', '" & R1("ShipTo_Address1") & "', '" & R1("ShipTo_Address2") & "', '" & R1("ShipTo_City") & "', '" & strState & "', '" & R1("ShipTo_Zip") & "', '" & strCountry & "', '" & Now & "', " & G_strContact & ")"
                '                        Next R1
                '                    End If

                '                    If iLoc_ID > 0 Then
                '                        R1 = Nothing
                '                        R1 = Me.G_objMessShip.GetLocInfo_ByLoc_ID(iLoc_ID)

                '                        '//Get State
                '                        strState = Me.Get_StateShortDesc(Trim(R1("State_ID")))
                '                        '//Get Country
                '                        strCountry = Me.Get_CountryText(Trim(R1("Cntry_ID")))
                '                        If Trim(strCountry) = "United States" Then strCountry = "US"
                '                        If Trim(strCountry) = "USA" Then strCountry = "US"
                '                        If Trim(strCountry) = "Canada" Then strCountry = "CN"

                '                        strFieldNames = "(Shipping_ID, Cust_Name, Cust_Address1, Cust_Address2, Cust_City, Cust_State_Prov, Cust_Zip, Cust_Country, Date_Entered, Cust_Contact, Cust_Phone)"

                '                        If IsDBNull(R1("Loc_Contact")) = False Then
                '                            strContact = R1("Loc_Contact")
                '                        Else
                '                            strContact = strCustName
                '                        End If

                '                        If IsDBNull(R1("Loc_Phone")) = False Then
                '                            strPhone = R1("Loc_Phone")
                '                        Else
                '                            strPhone = "none"
                '                        End If

                '                        strField = "(" & lngRecShip & ", '" & strCustName & "', '" & R1("Loc_Address1") & "', '" & R1("Loc_Address2") & "', '" & R1("Loc_City") & "', '" & strState & "', '" & R1("Loc_Zip") & "', '" & strCountry & "', '" & Now & "', '" & strContact & "', '" & strPhone & "')"
                '                    End If


                '                    Dim cmd As New OdbcCommand("insert into Customer_Info " & strFieldNames & " VALUES " & strField, conn)
                '                    conn.Open()
                '                    cmd.ExecuteNonQuery()

                '                Catch exp As Exception
                '                    MsgBox(exp.tostring)
                '                Finally
                '                    conn.Close()
                '                    conn.Dispose()
                '                End Try
                '                '//end write to fedex database

                '********************************
                'Move devices into WIP 5
                '********************************
                Try
                    G_objMessShip.UpdateWIPOwner(lngRecShip)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical)
                End Try
                '********************************

                lngRecShip = 0

                Me.RefreshForm()

                G_iShipID = 0
                G_lngwoFlag = 0
                Me.lblAddress.Text = ""
                ProcessLocation()

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPrint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objRpt) Then
                    objRpt.Dispose()
                    objRpt = Nothing
                End If
                If Not IsNothing(dtLocRS) Then
                    dtLocRS.Dispose()
                    dtLocRS = Nothing
                End If
                If Not IsNothing(dtrs) Then
                    dtrs.Dispose()
                    dtrs = Nothing
                End If
                R1 = Nothing
                R2 = Nothing
                Me.cmbModel.Focus()
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '*********************************************************
        Private Sub btnEndUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEndUser.Click
            Dim strTray_ID As String = ""
            Dim R1 As DataRow

            Try
                'G_dtCustomer = Me.G_objMessShip.GetShipping_CustomerList

                strTray_ID = Trim(InputBox("Please scan the tray number for this end user:", "Scan Tray"))

                If strTray_ID = "" Then
                    Me.cmbLoc.Text = ""
                    Me.cmbLoc.Focus()
                    Exit Sub
                ElseIf Not IsNumeric(strTray_ID) Then
                    MessageBox.Show("Tray ID must be numeric.", "Get Tray ID btnEndUser_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.cmbLoc.Text = ""
                    Me.cmbLoc.Focus()
                    Exit Sub
                End If

                If CInt(strTray_ID) > 0 Then
                    R1 = Me.G_objMessShip.GetTrayWOLocInfo_ByTrayID(CInt(strTray_ID))
                    If Not IsNothing(R1) Then
                        G_iLocID = Trim(R1("Loc_ID"))
                        G_iCustID = Trim(R1("Cust_ID"))
                    Else
                        MessageBox.Show("Invalid Tray please retry.", "Get Tray Info", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        RefreshForm()
                        Me.cmbLoc.Text = ""
                        Me.cmbLoc.Focus()
                        Exit Sub
                    End If

                    G_iManDet = 0  '//Initialize Return Value

                    'Get Value from Customer DataTable
                    R1 = Nothing
                    For Each R1 In G_dtCustomer.Rows
                        If Trim(R1("Loc_ID")) = G_iLocID Then
                            G_iManDet = Trim(R1("Loc_ManifestDetail"))
                            G_iCreditShip = Trim(R1("Cust_CrApproveShip"))
                            lblCompany.Text = Trim(R1("PCo_Name"))
                            Exit For
                        End If
                    Next R1

                    '******************************************************
                    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                    Dim msg, title, response As String

                    G_iCreditShip = 99  '//Failure Code

                    If G_iCreditShip <> 1 Then
                        '                    msg = "The Customer Account is waiting credit approval. Call ext 235 for status on Credit." & vbCrLf _
                        '                    & "Do you wish to continue"
                        '                    title = "Error Credit Not Approved ?"
Loop_Msg:
                        '                    response = MsgBox(msg, MsgBoxStyle.YesNo, title)
                        '                    If response <> vbYes Then GoTo Loop_Msg
                        '                    DBcbo1.Text = ""
                        '                    DBcbo1.Focus()
                        '                    lblCompany.Text = ""
                        '                    lblAddress.Text = ""
                        '                    DBcbo1.Text = ""
                        '                    Cursor.Current = System.Windows.Forms.Cursors.Default
                        '                    Exit Sub
                    End If

                    '//This section will generate the address for the customer
                    lblAddress.Text = PopulateAddressByCustomerEndUser()

                    'Craig Haney
                    G_dtDevice = Me.G_objMessShip.GetMessBilledDeviceInWIP_ByLocID(G_iLocID)
                    'Craig Haney - END

                    txtPager.Focus()
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnEndUser_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '*********************************************************
        Private Sub DBcbo1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoc.Leave
            Try
                If Me.cmbLoc.SelectedIndex > -1 Then
                    ProcessLocation()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "DBcbo1_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub DBcbo1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbLoc.KeyDown
            Dim R1 As DataRow

            Try
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                If e.KeyValue = 13 Then
                    ProcessLocation()
                Else
                    Me.cmbLoc.DroppedDown = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "DBcbo1_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        Private Sub ProcessLocation()
            Dim R1 As DataRow

            Try
                'G_dtCustomer = Me.G_objMessShip.GetShipping_CustomerList

                G_iCustID = Get_CustomerID()
                G_lngwoFlag = 0

                '****************************
                'Added by Lan on 11/11/2007
                '****************************
                If Me.G_iCustID = 14 Then
                    Me.lblFreqNum.Visible = True
                    Me.lblFreqLabel.Visible = True
                Else
                    Me.lblFreqNum.Visible = False
                    Me.lblFreqLabel.Visible = False
                End If
                '****************************

                '/NEW CODE- December 11, 2003
                R1 = Me.G_objMessShip.GetCCbyCustID(G_iCustID)
                If Not IsNothing(R1) Then
                    If IsDBNull(R1("CreditCard_Num")) = True Or IsDBNull(R1("CreditCard_ExpDate")) = True Then
                        MsgBox("Please forward this tray/bin to accounting dept for Credit Card processing before shipping. Thank you.", MsgBoxStyle.OKOnly)
                    End If
                End If
                '/NEW CODE- December 11, 2003

                G_iCustShipLvl = Get_CustomerShipLvl()
                G_iLocID = Get_LocationID()
                Combo_click()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '*********************************************************
        Private Sub cmbModel_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbModel.KeyDown
            Dim i As Integer
            Dim R1 As DataRowView
            Dim iFound As Integer = 0

            Try

                If e.KeyValue = 13 Then

                    If Me.cmbModel.Text = "-- Select --" Then
                        Me.cmbModel.DroppedDown = True
                        Exit Sub
                    Else
                        For i = 0 To Me.cmbModel.Items.Count - 1
                            R1 = Me.cmbModel.Items(i)
                            If Me.cmbModel.Text = R1(Me.cmbModel.DisplayMember) Then
                                iFound = 1
                                Me.txtPager.Focus()
                                Me.cmbModel.SelectedValue = R1(Me.cmbModel.ValueMember)
                            End If
                        Next i

                        If iFound = 0 Then
                            Me.cmbModel.SelectedValue = 0
                        End If
                    End If

                    Me.lstWrongFreq.Items.Clear()
                    Me.SetListBoxControl(Me.lstWrongFreq, Me.lblWrongFreq)
                    Me.lstWrongModel.Items.Clear()
                    Me.SetListBoxControl(Me.lstWrongModel, Me.lblWrongModel)
                    Me.lstNoQCPass.Items.Clear()
                    Me.SetListBoxControl(Me.lstNoQCPass, Me.lblNoQCPass)
                    Me.lblFreqNum.Text = ""
                    Me.lblCount.Text = "0"

                    G_dtSelected.Rows.Clear()
                    lstDevices.Items.Clear()
                    txtPager.Text = ""
                    txtPager.Focus()
                    G_iCount1 = 0
                Else
                    Me.cmbModel.DroppedDown = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Model_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************
        Private Sub RefreshForm()
            Try
                'Try
                '    G_dtCustomer.Rows.Clear()
                'Catch exp As Exception
                'End Try

                Try
                    G_dtDevice.Rows.Clear()
                Catch exp As Exception
                End Try

                Try
                    G_dtDupList.Rows.Clear()
                Catch exp As Exception
                End Try

                Try
                    G_dtDuplicateInd.Rows.Clear()
                Catch exp As Exception
                End Try

                Try
                    G_dtDupDataGrid.Rows.Clear()
                Catch exp As Exception
                End Try

                Try
                    G_dtSelected.Rows.Clear()
                Catch exp As Exception
                End Try

                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                TDBGrid1.Visible = False            '//Hide the duplicate device select grid
                G_iCount1 = 0                          '//Reset Counter

                'PopulateCustomerList()              '//Fill Customer List With Data
                lblDate.Text = FormatDate(Now)      '//Set The Date to Now
                G_dtDupDataGrid = Create_dtDupGrid()  '//This creates the datatable to hold duplicate information
                G_dtSelected = Create_dtSelect()      '//This creates the datatable to hold selected devices

                '//Determine ProductCode
                G_iProdID = 1

                ''//Determine user
                'G_strShipName = PSS.Core.Global.ApplicationUser.User

                'Me.cmbLoc.Text = ""
                Me.cmbModel.Focus()
                Me.cmbModel.DroppedDown = True

                '*********************************************
                'Added by Lan on 11/13/2007
                'Prevent user from mix model & freq in Ship Manifest
                '*********************************************
                Me.lstWrongFreq.Items.Clear()
                Me.SetListBoxControl(Me.lstWrongFreq, Me.lblWrongFreq)
                Me.lstWrongModel.Items.Clear()
                Me.SetListBoxControl(Me.lstWrongModel, Me.lblWrongModel)
                Me.lstNoQCPass.Items.Clear()
                Me.SetListBoxControl(Me.lstNoQCPass, Me.lblNoQCPass)
                '*********************************************

            Catch ex As Exception
                Throw ex
            Finally
                Cursor.Current = System.Windows.Forms.Cursors.Default
            End Try
        End Sub

        '*********************************************************
        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
            Dim strReportLoc As String = PSS.Core.ReportPath
            Dim objRpt As ReportDocument
            Dim strShipID As String = ""
            Dim vResponse As MsgBoxResult
            Dim strFreq As String

            Try
                strShipID = Trim(InputBox("Enter Shipping ID for reprint", "Reprint"))

                If Len(Trim(strShipID)) < 1 Then
                    MsgBox("Report print cancelled, no Shipping ID was entered.", MsgBoxStyle.OKOnly, "No Shipping ID Entered")
                    Exit Sub
                ElseIf Not IsNumeric(strShipID) Then
                    MsgBox("Ship ID must be numeric.", MsgBoxStyle.OKOnly, "Validate Ship ID Format")
                    Exit Sub
                End If

                strFreq = Me.G_objMessShip.GetFreqOfShipID(strShipID)

                objRpt = New ReportDocument()

                With objRpt
                    .Load(PSS.Core.[Global].ReportPath & "Ship_Manifest_Mess.rpt")
                    .SetParameterValue("Frequency", strFreq)
                    .RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(strShipID)
                    .PrintToPrinter(1, True, 0, 0)
                End With

                'rpt.RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(TmpshipVal)
                'rpt.PrintOut(False, 2)
                'rpt = Nothing

                vResponse = MsgBox("Print Manifest Detail?", MsgBoxStyle.YesNo, "Manifest Detail")
                If vResponse = MsgBoxResult.Yes Then

                    '                    Dim report1 As New ReportDocument()
                    '                    report1.Load(strReportLoc & "Ship_ManifestDetail.rpt", OpenReportMethod.OpenReportByTempCopy)
                    '                    report1.Refresh()
                    '                    report1.RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(TmpshipVal)
                    '                    report1.PrintToPrinter(1, False, 0, 0)

                    'Dim rptApp As New CRAXDRT.Application()
                    'Dim rpt As CRAXDRT.Report = rptApp.OpenReport(PSS.Core.Global.ReportPath & "Ship_ManifestDetail.rpt")
                    objRpt = Nothing

                    objRpt = New ReportDocument()

                    With objRpt
                        .Load(PSS.Core.[Global].ReportPath & "Ship_ManifestDetail.rpt")
                        .RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(strShipID)
                        .PrintToPrinter(1, True, 0, 0)
                    End With

                    'rpt.RecordSelectionFormula = "{tdevice.Ship_ID} = " & Trim(TmpshipVal)
                    'rpt.PrintOut(False, 2)
                    'rpt = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(objRpt) Then
                    objRpt.Dispose()
                    objRpt = Nothing
                End If
            End Try
        End Sub

        '*********************************************************
        Private Sub btnPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPO.Click
            Dim strPO_ID As String = ""

            Try
                G_iShipto2ID = 0

                Me.cmbLoc.Text = ""
                lblCompany.Text = ""
                lblAddress.Text = ""

                strPO_ID = Trim(InputBox("Please enter the Purchase Order number for this shipment:", "Enter PO"))

                If strPO_ID = "" Then
                    MessageBox.Show("No PO has been enter by the user.", "Validate PO ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf Not IsNumeric(strPO_ID) Then
                    MessageBox.Show("PO has wrong format. PO must me numeric.", "Validate PO ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If CInt(strPO_ID) > 0 Then
                    '//This section will generate the address for the customer
                    lblAddress.Text = PopulateAddressByPO(strPO_ID)
                End If

                G_iCustID = 1
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnPO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************
        Private Sub btnShipSpecial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShipSpecial.Click
            Dim i As Integer = 0
            Dim strShipLocName As String = ""
            Dim booInLocList As Boolean = False
            Dim dtAddress As DataTable
            Dim strState, strCountry As String
            Dim strAddress As String
            Dim R1, R2 As DataRow
            Dim iCust_ID As Integer = 0
            Dim blnTest As Boolean = False

            Try
                G_iShipto2ID = 0

                If Len(Trim(Me.cmbLoc.Text)) < 1 Then
                    MsgBox("You must have a location selected to use this command.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End If

                strShipLocName = Trim(InputBox("Please enter the new location for devices to be shipped to:", "Ship Location"))

                If strShipLocName = "" Then
                    MsgBox("No value entered. Redirect aborted.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                Else
                    strShipLocName = UCase(strShipLocName)

                    For i = 0 To Me.cmbLoc.Items.Count - 1
                        If Trim(strShipLocName) = Trim(Me.cmbLoc.Items(i)) Then
                            booInLocList = True
                            Exit For
                        End If
                    Next i

                    If booInLocList = False Then
                        MsgBox("The redirect location is not valid.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If
                End If

                lblCompany.Text = ""
                lblAddress.Text = ""

                dtAddress = Me.G_objMessShip.GetLocInfo_ByLoc_Name(strShipLocName)

                '//Get the appropriate address for display
                For Each R1 In dtAddress.Rows

                    G_iShipID = Trim(R1("Loc_ID"))

                    strState = Get_StateShortDesc(R1("State_ID"))     '//Translate State to Text
                    strCountry = Get_CountryText(R1("Cntry_ID")) '//Translate Country to Text

                    If Not IsDBNull(R1("Loc_Address1")) Then
                        strAddress += R1("Loc_Address1") & vbCrLf
                    End If

                    If Not IsDBNull(R1("Loc_Address2")) Then
                        strAddress += R1("Loc_Address2") & vbCrLf
                    End If

                    If Not IsDBNull(R1("Loc_City")) Then
                        strAddress += R1("Loc_City") & ", "
                    End If

                    If Not IsDBNull(strState) Then
                        strAddress += strState & ", "
                    End If

                    If Not IsDBNull(R1("Loc_Zip")) Then
                        strAddress += R1("Loc_Zip") & vbCrLf
                    End If

                    If Not IsDBNull(strCountry) Then
                        strAddress += strCountry
                    End If

                    Me.lblAddress.Text = strAddress

                    'Me.PopulateCustomerList()

                    '//This section of code will assign the company name to the form
                    For Each R2 In G_dtCustomer.Rows
                        If Trim(R2("Loc_Name")) = Trim(strShipLocName) Then
                            lblCompany.Text = Trim(R2("PCo_Name"))
                            Exit For
                        End If
                    Next R2

                    'populate device list
                    '//This section will get a datatable of all devices for this location
                    G_dtDevice = Me.G_objMessShip.GetMessBilledDeviceInWIP_ByShipChangeLocID(G_iLocID)

                    R2 = Nothing
                Next R1

                '//Get list of locations
                Dim ctlLocation As New PSS.Data.Production.tlocation()
                Dim dsLoc As DataSet = ctlLocation.GetData

                R1 = Nothing
                'Verify that both start and destination locations have the same parent company
                For Each R1 In dsLoc.Tables("tlocation").Rows
                    If IsDBNull(R1("Loc_Name")) = False Then
                        If Trim(Me.cmbLoc.Text) = Trim(R1("Loc_Name")) Then
                            iCust_ID = Trim(R1("Cust_ID"))
                            Exit For
                        End If
                    End If
                Next R1

                R1 = Nothing
                '//Compare to second value
                For Each R1 In dsLoc.Tables("tlocation").Rows
                    If IsDBNull(R1("Loc_Name")) = False Then
                        If Trim(strShipLocName) = Trim(R1("Loc_Name")) Then
                            If Trim(R1("Cust_ID")) = iCust_ID Then
                                blnTest = True
                                Exit For
                            End If
                        End If
                    End If
                Next R1

                If blnTest = False Then
                    MsgBox("You can not send devices between these locations. They do not have the same parent company.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Sub
                End If

                'Verify that the parent company for the start is eligible for redirection (flag set)
                '//Check cust ID flag
                R1 = Me.G_objMessShip.GetCustomerInfo_ByCustID(iCust_ID)
                If Not IsNothing(R1) Then
                    If R1("Cust_lvlShipCust") <> 1 Then
                        MsgBox("You can not send devices between these locations. They are not flagged to be redirected.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Sub
                    End If
                End If

                R1 = Nothing
                'reallocate the vallocid for the new location for writing on submittal(set valShipTo)
                For Each R1 In G_dtCustomer.Rows
                    If R1("Loc_Name") = strShipLocName Then
                        Exit For
                    End If
                Next R1
                G_dtCustomer.AcceptChanges()

                G_iShipto2ID = Insert_tshipto(G_iShipID)
                txtPager.Focus()

                If Not IsNothing(dsLoc) Then
                    dsLoc.Dispose()
                    dsLoc = Nothing
                End If
                If Not IsNothing(dsLoc) Then
                    ctlLocation = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ShipSpecial_ClickEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                R2 = Nothing
                If Not IsNothing(dtAddress) Then
                    dtAddress.Dispose()
                    dtAddress = Nothing
                End If
            End Try
        End Sub


        '*********************************************************
        'This function is added by Asif on 03/08/2004
        '*********************************************************
        Public Function CheckForMissingDataForMotorola(ByVal iDevice_ID As Integer, _
                                                        Optional ByVal iOverPackProcess As Integer = 0) As String

            Dim dtClaimInfo, dtComponentDetail As DataTable
            Dim strRetVar As String = ""
            Dim R1 As DataRow
            Dim i As Integer = 0

            Try

                G_objMotoWarrantyBiz = New Buisness.WarrantyClaim.MotoWarrantyBiz()
                dtClaimInfo = G_objMotoWarrantyBiz.GetMotoWarrantyClaimInfo(iDevice_ID)

                If dtClaimInfo.Rows.Count = 0 Then
                    strRetVar = "There is no valid data found for this device. Can't ship it at this point."
                    Exit Try
                End If

                '*************************************************************
                'first check for missing data in dtClaimInfo
                '*************************************************************
                For Each R1 In dtClaimInfo.Rows     'There will be only one row.
                    If iOverPackProcess = 0 Then

                        If Trim(R1("IncomingIMEI")) = "" Then      'If it is not a GSM phone
                            If Len(Trim(R1("DeviceSerialNumber"))) <> 11 Then
                                strRetVar += "'Serial Number' must be 11 character long." + vbCrLf
                            End If
                        Else    'if it is a GSM phone
                            If Len(Trim(R1("DeviceSerialNumber"))) <> 10 And Len(Trim(R1("DeviceSerialNumber"))) <> 11 Then
                                strRetVar += "'Serial Number' must be either 10 or 11 character long for a GSM phone." + vbCrLf
                            End If
                        End If

                        'TansceiverCode
                        If Len(Trim(R1("TansceiverCode"))) <> 9 Then
                            strRetVar += "Transceiver Code (SUG number) must be 9 character long." + vbCrLf
                        End If

                        'DateShipped
                        If IsDBNull(R1("DateShipped")) Then
                            strRetVar += "'0000-00-00 00:00:00' is not a valid value for date shipped." + vbCrLf
                        End If

                        'Bill date
                        If IsDBNull(R1("ReapairDate")) Then
                            strRetVar += "'0000-00-00 00:00:00' is not a valid value for date billed." + vbCrLf
                        End If

                        'Date Received
                        If IsDBNull(R1("DateReceived")) Then
                            strRetVar += "'0000-00-00 00:00:00' is not a valid value for date received." + vbCrLf
                        End If

                        'POP date
                        If IsDBNull(R1("DateofPurchase")) Then
                            strRetVar += "'0000-00-00 00:00:00' is not a valid value for date of purchase." + vbCrLf
                        End If

                        'bill date earlier than receive date
                        If Not IsDBNull(R1("ReapairDate")) And Not IsDBNull(R1("DateReceived")) Then
                            If R1("ReapairDate") <> "" And R1("DateReceived") <> "" Then
                                If CDate(R1("ReapairDate")) < CDate(R1("DateReceived")) Then
                                    'Error message
                                    'Date of Purchase can't be later than Date received.
                                    strRetVar += "'Date of Repair' can't be before 'Date Received'." + vbCrLf
                                End If
                            End If
                        End If
                        If Not IsDBNull(R1("DateofPurchase")) And Not IsDBNull(R1("DateReceived")) Then
                            If R1("DateofPurchase") <> "" And R1("DateReceived") <> "" Then
                                If CDate(R1("DateofPurchase")) > CDate(R1("DateReceived")) Then
                                    'Error message
                                    'Date of Purchase can't be later than Date received.
                                    strRetVar += "'Date of Purchase' can't be later than 'Date Received'." + vbCrLf
                                End If
                            End If
                        End If

                        If R1("AirtimeCarCode") = "" Or IsDBNull(R1("AirtimeCarCode")) Then
                            'Error message
                            'Air time carrier code is missing
                            strRetVar += "'Airtime Carrier Code' is missing." + vbCrLf
                        End If

                        If R1("TransactionCode") = "" Or IsDBNull(R1("TransactionCode")) Then
                            'Error message
                            'Transaction code is missing
                            strRetVar += "'Transaction Code' is missing." + vbCrLf
                        End If

                        If R1("Product_APCcode") = "" Or IsDBNull(R1("Product_APCcode")) Then
                            'Error message
                            'APC code is missing
                            strRetVar += "'APC Code' is missing." + vbCrLf
                        End If

                        If IsDBNull(R1("POPWarrantyClaim")) Or R1("POPWarrantyClaim") = "" Then
                            'error message
                            'DateofPurchase is either missing or in wrong format
                            strRetVar += "'Date of Purchase' is either missing or in wrong format for MySQL." + vbCrLf
                        End If

                        If IsDBNull(R1("SoftwareVersionIn")) Or R1("SoftwareVersionIn") = "" Then
                            'error message
                            'Software version in is missiing
                            strRetVar += "'Software Version In' is missing." + vbCrLf
                        End If

                        If IsDBNull(R1("SoftwareVersionOut")) Or R1("SoftwareVersionOut") = "" Then
                            'error message
                            'Software version Out is missiing
                            strRetVar += "'Software Version Out' is missing." + vbCrLf
                        End If

                        If IsDBNull(R1("TechnicianID")) Or R1("TechnicianID") = "" Then
                            'error message
                            'Technician ID missing
                            strRetVar += "'Technician ID' is missing." + vbCrLf
                        End If

                        If R1("CustomerComplaint") = "" Or IsDBNull(R1("CustomerComplaint")) Then
                            'Error message
                            'Problem Found code missing
                            strRetVar += "'Complaint Code' is missing." + vbCrLf
                        End If

                        If R1("PrimaryProbFoundCode") = "" Or IsDBNull(R1("PrimaryProbFoundCode")) Then
                            'Error message
                            'Problem Found code missing
                            strRetVar += "'Problem Found Code' is missing." + vbCrLf
                        End If

                        If R1("PrimaryRepairAction") = "" Or IsDBNull(R1("PrimaryRepairAction")) Then
                            'Error message
                            'Repair Action Code missing
                            strRetVar += "'Repair Action Code' is missing." + vbCrLf
                        End If

                        If IsDBNull(R1("Airtime")) Or R1("Airtime") = "" Or Not IsNumeric(R1("Airtime")) Then
                            'Error message
                            'Air time missing or not converted to Minutes
                            strRetVar += "'Airtime' is missing or not converted to minutes." + vbCrLf
                        End If

                        '******************
                        'IMEI and ESN/CSN Logic
                        '******************
                        If Trim(R1("IncomingIMEI")) <> "" Then
                            If Trim(R1("OutgoingIMEI")) = "" Then
                                'imei out is missing
                                strRetVar += "'IMEI Out' is missing." + vbCrLf
                                'Else
                                '    i = 1       'GSM phone
                            End If

                            'Check if the MSN IN is there
                            If Trim(R1("IncomingMSN")) = "" Then
                                'imei out is missing
                                strRetVar += "'MSN In' is missing." + vbCrLf
                            End If

                            'Check if the MSN IN is there
                            If Trim(R1("OutgoingMSN")) = "" Then
                                'imei out is missing
                                strRetVar += "'MSN Out' is missing." + vbCrLf
                            End If

                            i = 1       'GSM phone
                        Else
                            If Trim(R1("OutgoingIMEI")) <> "" Then
                                strRetVar += "'IMEI In' is missing." + vbCrLf     'If IMEI IN is not there this never should happen.
                                i = 1       'GSM phone
                            End If
                        End If
                        '******************
                        If i = 1 Then           'GSM Phone
                            If Trim(R1("IncomingESNorCSN")) <> "" Then
                                strRetVar += "'ESN/CSN In' not allowed for GSM phones." + vbCrLf     'Message can be rephrased
                            End If
                            If Trim(R1("OutgoingESNorCSN")) <> "" Then
                                strRetVar += "'ESN/CSN Out' not allowed for GSM phones." + vbCrLf     'Message can be rephrased
                            End If

                        Else                    'Non-GSM Phone
                            If Trim(R1("IncomingESNorCSN")) = "" Then
                                strRetVar += "'ESN/CSN In' is missing for a non-GSM phone." + vbCrLf
                            Else
                                '************************************
                                If Len(Trim(R1("IncomingESNorCSN"))) <> 11 Then
                                    strRetVar += "'Incoming ESN/CSN' can be 11 characters long only." + vbCrLf
                                End If
                                '************************************
                            End If

                            If Trim(R1("OutgoingESNorCSN")) = "" Then
                                strRetVar += "'ESN/CSN Out' is missing for a non-GSM phone." + vbCrLf
                            Else
                                '************************************
                                Select Case Len(Trim(R1("OutgoingESNorCSN")))
                                    Case 8
                                        'Valid length

                                    Case 11
                                        'valid length

                                    Case Else
                                        'Invalid Serial Number length, so throw an error
                                        'Error message
                                        strRetVar += "'Outgoing ESN/CSN' can either be 8 or 11 character long only." + vbCrLf
                                End Select
                                '************************************
                            End If

                            i = 2       'Non-GSM Phone
                        End If
                        '******************
                        If i = 0 Then
                            strRetVar += "Phone must either be a GSM or Non-GSM phone. Both 'IMEI' and 'ESN/CSN' values are missing." + vbCrLf
                        End If
                        '******************
                    Else        'If overpack process is not of type 0 that is if it is not regular
                        If R1("TransactionCode") <> "" Then
                            'Error message
                            If (Trim(R1("TransactionCode")) <> "RUR") Then      '1344 - RUR ;;; 1345 - SWA
                                strRetVar += "Invalid 'Transaction Code'. It can either be 'Returned Unrepaired' or 'Swapped Unit - Subcontractors'." + vbCrLf
                            End If
                        End If

                    End If
                Next R1

                '*************************************************************
                'Second off check for missing data in dtComponentDetail
                '*************************************************************
                If iOverPackProcess = 0 Then
                    dtComponentDetail = G_objMotoWarrantyBiz.GetMotoWarrantyClaimDetailInfo(iDevice_ID)
                    For Each R1 In dtComponentDetail.Rows

                        'If R1("RefDesignator") = "" Or R1("RefDesignator") = "0" Or IsDBNull(R1("RefDesignator")) Then
                        If R1("RefDesignator") = "" Then
                            strRetVar += "Parts Detail: 'Reference Designator Code' is missing for Part Number # " & R1("MotoPartNumber") + vbCrLf
                        End If
                        'If R1("PartFailureCode") = "" Or R1("PartFailureCode") = "0" Or IsDBNull(R1("PartFailureCode")) Then
                        If R1("PartFailureCode") = "" Then
                            strRetVar += "Parts Detail: 'Failure Code' is missing for Part Number # " & R1("MotoPartNumber") + vbCrLf
                        End If
                        'RefDesigNum
                        If R1("RefDesigNum") <> "" Then
                            If Not IsNumeric(R1("RefDesigNum")) Then
                                strRetVar += "Parts Detail: 'Reference Designator Number' must be a numeric value for Part Number # " & R1("MotoPartNumber") + vbCrLf
                            End If
                        End If
                    Next R1
                End If
                '*************************************************************
            Catch ex As Exception
                strRetVar = ""
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally

                '***********
                If Not IsNothing(dtClaimInfo) Then
                    dtClaimInfo.Dispose()
                End If
                dtClaimInfo = Nothing
                '***********
                If Not IsNothing(dtComponentDetail) Then
                    dtComponentDetail.Dispose()
                End If
                dtComponentDetail = Nothing
                '***********
                G_objMotoWarrantyBiz = Nothing

            End Try

            Return strRetVar
        End Function

        '*********************************************************
        'Added by Lan on 02/20/2007
        '*********************************************************
        Private Sub txtShipID_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipID.KeyUp

            If e.KeyValue = 13 Then
                If Trim(Me.txtShipID.Text) = "" Then
                    Exit Sub
                ElseIf Not IsNumeric(Trim(Me.txtShipID.Text)) Then
                    MessageBox.Show("Incorrect ship_id format.", "Get Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    Me.txtShipID.Focus()
                End If
            End If
        End Sub

        '*********************************************************
        'Added by Lan on 02/20/2007
        '*********************************************************
        Private Sub txtShipQty_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipQty.KeyUp

            If e.KeyValue = 13 Then
                If Trim(Me.txtShipQty.Text) = "" Then
                    Exit Sub
                ElseIf Not IsNumeric(Trim(Me.txtShipQty.Text)) Then
                    MessageBox.Show("Incorrect ship quantity format.", "Get Tray ID", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Else
                    Me.UnshipTray()
                End If
            End If
        End Sub

        '*********************************************************
        'Added by Lan on 02/20/2007
        '*********************************************************
        Private Sub cmdUnship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnship.Click
            Me.UnshipTray()
        End Sub

        '*********************************************************
        'Added by Lan on 02/20/2007
        '*********************************************************
        Private Sub UnshipTray()
            Dim objMessMisc As New PSS.Data.Buisness.MessMisc()
            Dim iUserShipQty As Integer = 0
            Dim iShipID As Integer = 0
            Dim i As Integer = 0

            Try
                If MessageBox.Show("Are you sure you want to unship this ship_id and all its devices?", "Unship Devices", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                Me.cmdUnship.Enabled = False

                '***********************************
                'validate user input
                '***********************************
                If Trim(Me.txtShipID.Text) = "" Then
                    Exit Sub
                ElseIf Not IsNumeric(Trim(Me.txtShipID.Text)) Then
                    Throw New Exception("Incorrect ship_id format.")
                Else
                    iShipID = CInt(Trim(Me.txtShipID.Text))
                End If

                If Trim(Me.txtShipQty.Text) = "" Then
                    Throw New Exception("Please enter un-ship quantity.")
                ElseIf Not IsNumeric(Trim(Me.txtShipQty.Text)) Then
                    Throw New Exception("Incorrect ship quantity format.")
                Else
                    iUserShipQty = CInt(Trim(Me.txtShipQty.Text))
                End If

                '***********************************
                'Unship tray
                '***********************************
                i = objMessMisc.UnshipMessgShipID(iShipID, iUserShipQty, txtUnshipSN.Text.Trim)

                If i > 0 Then
                    MsgBox("Devices have been unshipped. Please discard the old paper work promptly.")
                End If
                '***********************************

            Catch ex As Exception
                MessageBox.Show("frmShipping.vb:: " & ex.ToString, "Unship Device", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.cmdUnship.Enabled = True
                objMessMisc = Nothing
                Me.txtShipID.Text = ""
                Me.txtShipQty.Text = ""
                Me.txtUnshipSN.Text = ""
                Me.txtShipID.Focus()
            End Try
        End Sub

        '*********************************************************

    End Class

End Namespace

