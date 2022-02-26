Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmBuildAccessShipBox
        Inherits System.Windows.Forms.Form
        Private Const _iBatteryCoverBillcodeID As Integer = 154
        Private _objTFBuildAccShipPallet As PSS.Data.Buisness.TracFone.BuildShipPallet
        Private _iMachineCC_GrpID As Integer = 0
        Private strMachine As String = System.Net.Dns.GetHostName
        Private objMisc As PSS.Data.Buisness.Misc
        Private iWCLocation_ID As Integer = 0
        Private iLine_ID As Integer = 0
        Private iGroup_ID As Integer = 0
        Private strGroup As String = ""
        Private strLineNumber As String = ""
        Private iLineSide_ID As Integer = 0
        Private strLineSide As String = ""
        Private strBin As String = ""
        Private strUserName As String = PSS.Core.Global.ApplicationUser.User
        Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
        Private _dtOrders As DataTable
        Private _Cust_ID As Integer = 0
        Private _strTFCustLabel As String = "TracFone"
        Private _strWFMCustLabel As String = "WFM (TracFone)"

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal iCustID As Integer = 0)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            If iCustID > 0 Then Me._Cust_ID = iCustID
            _objTFBuildAccShipPallet = New PSS.Data.Buisness.TracFone.BuildShipPallet()
            objMisc = New PSS.Data.Buisness.Misc()
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
                _objTFBuildAccShipPallet = Nothing
                objMisc = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents cboAccModels As C1.Win.C1List.C1Combo
        Friend WithEvents txtQty As System.Windows.Forms.TextBox
        Friend WithEvents btnCreateBox As System.Windows.Forms.Button
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblCostCenter As System.Windows.Forms.Label
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents lblWorkDate As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents lblMachine As System.Windows.Forms.Label
        Friend WithEvents lblLineSide As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents txtNewItemQty As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtOrderNo As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lstOrders As System.Windows.Forms.ListBox
        Friend WithEvents btnRemoveAll As System.Windows.Forms.Button
        Friend WithEvents btnRemoveOne As System.Windows.Forms.Button
        Friend WithEvents lblTotalQty As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblOrderQty As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmBuildAccessShipBox))
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboAccModels = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtQty = New System.Windows.Forms.TextBox()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.btnCreateBox = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblCostCenter = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.lblWorkDate = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.lblMachine = New System.Windows.Forms.Label()
            Me.lblLineSide = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.txtNewItemQty = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtOrderNo = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lstOrders = New System.Windows.Forms.ListBox()
            Me.btnRemoveAll = New System.Windows.Forms.Button()
            Me.btnRemoveOne = New System.Windows.Forms.Button()
            Me.lblTotalQty = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblOrderQty = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            CType(Me.cboAccModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(24, 120)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 20)
            Me.Label1.TabIndex = 86
            Me.Label1.Text = "Model:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboAccModels
            '
            Me.cboAccModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboAccModels.Caption = ""
            Me.cboAccModels.CaptionHeight = 17
            Me.cboAccModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboAccModels.ColumnCaptionHeight = 17
            Me.cboAccModels.ColumnFooterHeight = 17
            Me.cboAccModels.ContentHeight = 15
            Me.cboAccModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboAccModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboAccModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboAccModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboAccModels.EditorHeight = 15
            Me.cboAccModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboAccModels.ItemHeight = 15
            Me.cboAccModels.Location = New System.Drawing.Point(88, 120)
            Me.cboAccModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboAccModels.MaxDropDownItems = CType(5, Short)
            Me.cboAccModels.MaxLength = 32767
            Me.cboAccModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboAccModels.Name = "cboAccModels"
            Me.cboAccModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboAccModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboAccModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboAccModels.Size = New System.Drawing.Size(230, 21)
            Me.cboAccModels.TabIndex = 1
            Me.cboAccModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(24, 152)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 21)
            Me.Label2.TabIndex = 88
            Me.Label2.Text = "Box Qty:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtQty
            '
            Me.txtQty.Location = New System.Drawing.Point(88, 152)
            Me.txtQty.Name = "txtQty"
            Me.txtQty.Size = New System.Drawing.Size(117, 20)
            Me.txtQty.TabIndex = 2
            Me.txtQty.Text = ""
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(232, 106)
            Me.lblScreenName.TabIndex = 121
            Me.lblScreenName.Text = "TRACFONE BUILD ACCESSORY SHIP BOX "
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnCreateBox
            '
            Me.btnCreateBox.BackColor = System.Drawing.Color.Green
            Me.btnCreateBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBox.ForeColor = System.Drawing.Color.White
            Me.btnCreateBox.Location = New System.Drawing.Point(27, 192)
            Me.btnCreateBox.Name = "btnCreateBox"
            Me.btnCreateBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateBox.Size = New System.Drawing.Size(179, 32)
            Me.btnCreateBox.TabIndex = 6
            Me.btnCreateBox.Text = "CREATE BOX"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(27, 248)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(179, 32)
            Me.btnReprintBoxLabel.TabIndex = 7
            Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCostCenter, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.Button2})
            Me.Panel2.Location = New System.Drawing.Point(232, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(584, 106)
            Me.Panel2.TabIndex = 125
            '
            'lblCostCenter
            '
            Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCostCenter.ForeColor = System.Drawing.Color.Lime
            Me.lblCostCenter.Location = New System.Drawing.Point(386, 6)
            Me.lblCostCenter.Name = "lblCostCenter"
            Me.lblCostCenter.Size = New System.Drawing.Size(184, 22)
            Me.lblCostCenter.TabIndex = 101
            Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.Lime
            Me.lblUserName.Location = New System.Drawing.Point(193, 7)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(190, 22)
            Me.lblUserName.TabIndex = 100
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWorkDate
            '
            Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
            Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
            Me.lblWorkDate.Location = New System.Drawing.Point(193, 28)
            Me.lblWorkDate.Name = "lblWorkDate"
            Me.lblWorkDate.Size = New System.Drawing.Size(191, 21)
            Me.lblWorkDate.TabIndex = 99
            Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.Lime
            Me.lblShift.Location = New System.Drawing.Point(193, 48)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(191, 22)
            Me.lblShift.TabIndex = 98
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMachine
            '
            Me.lblMachine.BackColor = System.Drawing.Color.Transparent
            Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachine.ForeColor = System.Drawing.Color.Lime
            Me.lblMachine.Location = New System.Drawing.Point(2, 48)
            Me.lblMachine.Name = "lblMachine"
            Me.lblMachine.Size = New System.Drawing.Size(190, 22)
            Me.lblMachine.TabIndex = 97
            Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLineSide
            '
            Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
            Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
            Me.lblLineSide.Location = New System.Drawing.Point(82, 28)
            Me.lblLineSide.Name = "lblLineSide"
            Me.lblLineSide.Size = New System.Drawing.Size(110, 21)
            Me.lblLineSide.TabIndex = 96
            Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Lime
            Me.lblGroup.Location = New System.Drawing.Point(2, 7)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(190, 22)
            Me.lblGroup.TabIndex = 95
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLine
            '
            Me.lblLine.BackColor = System.Drawing.Color.Transparent
            Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLine.ForeColor = System.Drawing.Color.Lime
            Me.lblLine.Location = New System.Drawing.Point(2, 28)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(77, 21)
            Me.lblLine.TabIndex = 94
            Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(196, 334)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(274, 44)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'txtNewItemQty
            '
            Me.txtNewItemQty.Location = New System.Drawing.Point(496, 120)
            Me.txtNewItemQty.Name = "txtNewItemQty"
            Me.txtNewItemQty.Size = New System.Drawing.Size(117, 20)
            Me.txtNewItemQty.TabIndex = 3
            Me.txtNewItemQty.Text = ""
            Me.txtNewItemQty.Visible = False
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(336, 120)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(152, 21)
            Me.Label3.TabIndex = 127
            Me.Label3.Text = "New Battery Cover Qty:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label3.Visible = False
            '
            'txtOrderNo
            '
            Me.txtOrderNo.Location = New System.Drawing.Point(496, 152)
            Me.txtOrderNo.Name = "txtOrderNo"
            Me.txtOrderNo.Size = New System.Drawing.Size(120, 20)
            Me.txtOrderNo.TabIndex = 4
            Me.txtOrderNo.Text = ""
            Me.txtOrderNo.Visible = False
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(376, 152)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 21)
            Me.Label4.TabIndex = 129
            Me.Label4.Text = "Order#:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label4.Visible = False
            '
            'lstOrders
            '
            Me.lstOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstOrders.ItemHeight = 16
            Me.lstOrders.Location = New System.Drawing.Point(496, 176)
            Me.lstOrders.Name = "lstOrders"
            Me.lstOrders.Size = New System.Drawing.Size(120, 164)
            Me.lstOrders.TabIndex = 5
            Me.lstOrders.TabStop = False
            Me.lstOrders.Visible = False
            '
            'btnRemoveAll
            '
            Me.btnRemoveAll.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAll.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAll.Location = New System.Drawing.Point(376, 264)
            Me.btnRemoveAll.Name = "btnRemoveAll"
            Me.btnRemoveAll.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAll.Size = New System.Drawing.Size(113, 30)
            Me.btnRemoveAll.TabIndex = 9
            Me.btnRemoveAll.Text = "REMOVE ALL"
            Me.btnRemoveAll.Visible = False
            '
            'btnRemoveOne
            '
            Me.btnRemoveOne.BackColor = System.Drawing.Color.Red
            Me.btnRemoveOne.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveOne.ForeColor = System.Drawing.Color.White
            Me.btnRemoveOne.Location = New System.Drawing.Point(376, 224)
            Me.btnRemoveOne.Name = "btnRemoveOne"
            Me.btnRemoveOne.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveOne.Size = New System.Drawing.Size(113, 30)
            Me.btnRemoveOne.TabIndex = 8
            Me.btnRemoveOne.Text = "REMOVE ONE"
            Me.btnRemoveOne.Visible = False
            '
            'lblTotalQty
            '
            Me.lblTotalQty.BackColor = System.Drawing.Color.Black
            Me.lblTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTotalQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTotalQty.ForeColor = System.Drawing.Color.Lime
            Me.lblTotalQty.Location = New System.Drawing.Point(640, 248)
            Me.lblTotalQty.Name = "lblTotalQty"
            Me.lblTotalQty.Size = New System.Drawing.Size(106, 41)
            Me.lblTotalQty.TabIndex = 132
            Me.lblTotalQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.lblTotalQty.Visible = False
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Black
            Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.Lime
            Me.Label10.Location = New System.Drawing.Point(640, 229)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(105, 21)
            Me.Label10.TabIndex = 133
            Me.Label10.Text = "TOTAL"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.Label10.Visible = False
            '
            'lblOrderQty
            '
            Me.lblOrderQty.BackColor = System.Drawing.Color.Black
            Me.lblOrderQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblOrderQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOrderQty.ForeColor = System.Drawing.Color.Lime
            Me.lblOrderQty.Location = New System.Drawing.Point(640, 176)
            Me.lblOrderQty.Name = "lblOrderQty"
            Me.lblOrderQty.Size = New System.Drawing.Size(106, 41)
            Me.lblOrderQty.TabIndex = 130
            Me.lblOrderQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.lblOrderQty.Visible = False
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Black
            Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Lime
            Me.Label7.Location = New System.Drawing.Point(640, 157)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(105, 21)
            Me.Label7.TabIndex = 131
            Me.Label7.Text = "ORDER QTY"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            Me.Label7.Visible = False
            '
            'frmBuildAccessShipBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(824, 405)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTotalQty, Me.Label10, Me.lblOrderQty, Me.Label7, Me.btnRemoveAll, Me.btnRemoveOne, Me.lstOrders, Me.txtOrderNo, Me.Label4, Me.txtNewItemQty, Me.Label3, Me.Panel2, Me.btnReprintBoxLabel, Me.btnCreateBox, Me.lblScreenName, Me.txtQty, Me.Label2, Me.cboAccModels, Me.Label1})
            Me.Name = "frmBuildAccessShipBox"
            Me.Text = "frmBuildAccessShipBox"
            CType(Me.cboAccModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '************************************************************************************
        Private Sub frmBuildAccessShipBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Const ProdID As Integer = 1
            Dim i As Integer = 0
            Try
                If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then Me.lblScreenName.Text = "WFM (TRACFONE) BUILD ACCESSORY SHIP BOX"

                '*****************************
                'check computer mapping
                '*****************************
                i = CheckIfMachineTiedToLine()

                Me.cboAccModels.Focus()
                Me.lblOrderQty.Text = "0"
                Me.lblTotalQty.Text = "0"
                If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    dt = Me._objTFBuildAccShipPallet.GetAccModelWithSku(True, Me._Cust_ID)
                Else
                    dt = Me._objTFBuildAccShipPallet.GetAccModelWithSku(True)
                End If
                'dt = Me._objTFBuildAccShipPallet.GetAccModelWithSku(True)
                Misc.PopulateC1DropDownList(Me.cboAccModels, dt, "Model_Desc", "Model_ID")
                Me.cboAccModels.SelectedValue = 0

                Me._dtOrders = Me._objTFBuildAccShipPallet.GetTFOrderReadyTemplate
                With Me.lstOrders
                    Me.lstOrders.DataSource = Me._dtOrders.DefaultView
                    Me.lstOrders.ValueMember = Me._dtOrders.Columns("WO_ID").ToString
                    Me.lstOrders.DisplayMember = Me._dtOrders.Columns("Order #").ToString
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmBuildAccessShipBox", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '************************************************************************************
        Private Sub btnCreateBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBox.Click
            Dim strBoxType As String = "REF"
            Dim iModelID, i, iTotalBilledQty As Integer
            Dim iBoxType As Integer = 0
            Dim strModelShortName As String = ""
            Dim iPallettID As Integer = 0
            Dim R1, drDeviceArr() As DataRow
            Dim objDevice As Rules.Device
            Dim dt As DataTable

            Try
                If IsNothing(Me.cboAccModels.SelectedValue) Or Me.cboAccModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboAccModels.Focus()
                ElseIf Me.txtQty.Text.Trim = "" Or Me.txtQty.Text.Trim.StartsWith("0") Then
                    MessageBox.Show("Please enter a positive number for Qty.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtQty.Focus()
                ElseIf Me.txtNewItemQty.Text.Trim.Length > 0 AndAlso (CInt(Me.txtNewItemQty.Text.Trim) > CInt(Me.txtQty.Text.Trim)) Then
                    MessageBox.Show("New Item Qty can't be greater than Box Qty.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtNewItemQty.Focus()
                ElseIf Me.lstOrders.Items.Count > 0 AndAlso (Me.txtNewItemQty.Text.Trim = "" Or Me.txtNewItemQty.Text.Trim.StartsWith("0")) Then
                    MessageBox.Show("Please enter New Item Qty or remove Order #.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstOrders.Items.Count = 0 AndAlso (Me.txtNewItemQty.Text.Trim <> "" Or Me.txtNewItemQty.Text.Trim.StartsWith("0")) Then
                    MessageBox.Show("Please remove New Item Qty or enter Order #.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.lstOrders.Items.Count > 0 AndAlso (Me.txtNewItemQty.Text.Trim <> "" Or Me.txtNewItemQty.Text.Trim.StartsWith("0")) AndAlso (CInt(Me.lblTotalQty.Text) < CInt(Me.txtNewItemQty.Text.Trim)) Then
                    MessageBox.Show("Please insert more order # or lower the New Item Qty.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    If _dtOrders.Rows.Count > 0 Then
                        dt = Me._objTFBuildAccShipPallet.GetDeviceIDHasNoBatteryCover(_dtOrders, Me._iBatteryCoverBillcodeID)
                        If dt.Rows.Count < CInt(Me.txtNewItemQty.Text) Then
                            MessageBox.Show("The unit(s) without part in listed order(s) less than new item quantity.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit Sub
                        End If
                    End If

                    If MessageBox.Show("Are you sure you want to close this box?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                        Exit Sub
                    End If

                    '**********************************
                    'Get, Validate, and Create Box 
                    '**********************************
                    iModelID = 0 : i = 0 : iTotalBilledQty = 0
                    strModelShortName = Me.GetModelShortName()

                    If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then strBoxType = "WACC" 'WFM Accessary

                    If strModelShortName.Trim.Length <> 0 Then
                        iModelID = Me.cboAccModels.SelectedValue
                        If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                            iPallettID = Me._objTFBuildAccShipPallet.CreateAccBoxID(iModelID, iBoxType, strModelShortName & strBoxType, CInt(Me.txtQty.Text.ToString), Me._Cust_ID)
                        Else
                            iPallettID = Me._objTFBuildAccShipPallet.CreateAccBoxID(iModelID, iBoxType, strModelShortName & strBoxType, CInt(Me.txtQty.Text.ToString))
                        End If
                        'iPallettID = Me._objTFBuildAccShipPallet.CreateAccBoxID(iModelID, iBoxType, strModelShortName & strBoxType, CInt(Me.txtQty.Text.ToString))
                        If iPallettID = 0 Then
                            Throw New Exception("Box has not closed yet due to an error. Please contact IT.")
                        End If

                        If _dtOrders.Rows.Count > 0 Then
                            For Each R1 In _dtOrders.Rows
                                '***************************************
                                'Get device has no battery cover billed
                                '***************************************
                                drDeviceArr = dt.Select("WO_ID = " & R1("WO_ID"))
                                For i = 0 To drDeviceArr.Length - 1
                                    If iTotalBilledQty < CInt(Me.txtNewItemQty.Text) Then
                                        objDevice = New Rules.Device(drDeviceArr(i)("Device_ID"))
                                        objDevice.AddPart(Me._iBatteryCoverBillcodeID)
                                        objDevice.Update()
                                        If Not IsNothing(objDevice) Then
                                            objDevice.Dispose()
                                            objDevice = Nothing
                                        End If
                                        iTotalBilledQty += 1
                                    Else
                                        Exit For
                                    End If
                                Next i
                                '***************************************
                                'Record data
                                '***************************************
                                If i > 0 Then Me._objTFBuildAccShipPallet.CreateBillAccessory(iPallettID, R1("WO_ID"), CInt(Me.txtNewItemQty.Text.Trim), i, PSS.Core.Global.ApplicationUser.IDuser)


                                drDeviceArr = Nothing
                                If iTotalBilledQty >= CInt(Me.txtNewItemQty.Text) Then Exit For
                            Next R1
                        End If

                        If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                            Me._objTFBuildAccShipPallet.PrintBoxLabel_TFWFM(iPallettID, 0, Me._Cust_ID, Me._strWFMCustLabel)
                        Else
                            Me._objTFBuildAccShipPallet.PrintBoxLabel_TFWFM(iPallettID, 0, Me._objTFBuildAccShipPallet.TracFone_CUSTOMER_ID, Me._strTFCustLabel)
                        End If

                        'Me._objTFBuildAccShipPallet.PrintBoxLabel(iPallettID, 0)

                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        Me.ClearVarsAndCtrls()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateBoxID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
                R1 = Nothing
                drDeviceArr = Nothing
                If Not IsNothing(objDevice) Then
                    objDevice.Dispose()
                    objDevice = Nothing
                End If
            End Try
        End Sub

        '************************************************************************************
        Private Function CheckIfMachineTiedToLine() As Integer
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Try
                dt1 = objMisc.CheckIfMachineTiedToLine(strMachine)
                If dt1.Rows.Count = 0 Then
                    Return 0
                End If

                For Each R1 In dt1.Rows
                    iGroup_ID = R1("Group_ID")
                    strGroup = Trim(R1("Group_Desc"))
                    iLine_ID = R1("Line_ID")
                    strLineNumber = Trim(R1("Line_Number"))
                    iLineSide_ID = R1("LineSide_ID")
                    strLineSide = Trim(R1("LineSide_Desc"))
                    'strBin = Trim(R1("WC_Location"))
                    iWCLocation_ID = R1("WCLocation_ID")
                Next R1

                Me.lblGroup.Text = "Group: " & strGroup
                Me.lblLine.Text = strLineNumber
                Me.lblLineSide.Text = strLineSide
                Me.lblMachine.Text = "Machine: " & strMachine
                Me.lblUserName.Text = "User: " & strUserName
                Me.lblShift.Text = "Shift: " & iShiftID
                Me.lblWorkDate.Text = "Work Date: " & Format(CDate(strWorkDate), "MM/dd/yyyy")
                'Me.lblBin.Text = "BIN: " & strBin

                Return 1
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
            End Try
        End Function

        '************************************************************************************
        Private Function GetModelShortName() As String
            Dim dtModels As DataTable
            Dim strModelMotoSku As String = ""

            Try
                dtModels = Me.cboAccModels.DataSource.Table
                If dtModels.Select("Model_ID = " & Me.cboAccModels.SelectedValue).Length = 0 Then
                    MessageBox.Show("Can not define model short name. Please select model again.", "Populate Box", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf IsDBNull(dtModels.Select("Model_ID = " & Me.cboAccModels.SelectedValue)(0)("Model_MotoSku")) OrElse dtModels.Select("Model_ID = " & Me.cboAccModels.SelectedValue)(0)("Model_MotoSku").ToString.Trim.Length = 0 Then
                    MessageBox.Show("Model short name is missing in the system. Please contact IT.", "Populate Box", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strModelMotoSku = dtModels.Select("Model_ID = " & Me.cboAccModels.SelectedValue)(0)("Model_MotoSku")
                End If

                Return strModelMotoSku
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                dtModels = Nothing
            End Try
        End Function

        '************************************************************************************
        Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim str_pallett As String = ""
            Dim dtPallettInfo As DataTable
            Dim strPalletType As String = ""
            Dim iPalletQty As Integer = 0
            Dim R1 As DataRow


            Try
                str_pallett = InputBox("Enter Box Name.", "Reprint Box Label")
                If str_pallett = "" Then
                    Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                    dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett, Me._Cust_ID)
                Else
                    dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett, _objTFBuildAccShipPallet.TracFone_CUSTOMER_ID)
                End If
                ' dtPallettInfo = objMisc.GetPalletInfo_ByPallettName(str_pallett)

                If dtPallettInfo.Rows.Count = 0 Then
                    MessageBox.Show("Box Name was not defined in system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf dtPallettInfo.Rows.Count > 1 Then
                    MessageBox.Show("Box Name existed twice in the system.", "Reprint Box Label", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    R1 = dtPallettInfo.Rows(0)

                    If R1("Pallett_ReadyToShipFlg") = 0 Then
                        MessageBox.Show("Box is still open.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If

                    If R1("Pallet_ShipType") = 0 Then
                        strPalletType = "REFURBISHED"
                    Else
                        MessageBox.Show("System can't define Box Type.", "Information", MessageBoxButtons.OK)
                        Exit Sub
                    End If

                    If Not IsDBNull(R1("Cust_ID")) Then
                        '_objMisc.PrintPalletDeviceCountRpt(R1("Pallett_ID"), R1("Cust_ID"), 1)
                        If Me._Cust_ID = PSS.Data.Buisness.WFM.CUSTOMER_ID Then
                            Me._objTFBuildAccShipPallet.PrintBoxLabel_TFWFM(R1("Pallett_ID"), R1("Pallet_ShipType"), Me._Cust_ID, Me._strWFMCustLabel)
                        Else
                            Me._objTFBuildAccShipPallet.PrintBoxLabel_TFWFM(R1("Pallett_ID"), R1("Pallet_ShipType"), Me._objTFBuildAccShipPallet.TracFone_CUSTOMER_ID, Me._strTFCustLabel)
                        End If
                        'Me._objTFBuildAccShipPallet.PrintBoxLabel(R1("Pallett_ID"), R1("Pallet_ShipType"))
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                If Not IsNothing(dtPallettInfo) Then
                    dtPallettInfo.Dispose()
                    dtPallettInfo = Nothing
                End If
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '************************************************************************************
        Private Sub ClearVarsAndCtrls()
            Me.cboAccModels.SelectedValue = 0
            Me.cboAccModels.Focus()
            Me.txtQty.Text = ""
            Me.txtNewItemQty.Text = ""
            Me.txtOrderNo.Text = ""
            Me.btnRemoveOne.Enabled = False
            Me.btnRemoveAll.Enabled = False
            Me.txtOrderNo.Enabled = True
            Me._dtOrders.Clear()
            Me._dtOrders.AcceptChanges()
            Me.lblOrderQty.Text = "0"
            Me.lblTotalQty.Text = "0"
        End Sub

        '************************************************************************************
        Private Sub txtNum_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress, txtNewItemQty.KeyPress, txtOrderNo.KeyPress
            Try
                If Not (e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '************************************************************************************
        Private Sub KeyUpEvent(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyUp, txtNewItemQty.KeyUp, txtOrderNo.KeyUp, cboAccModels.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    Select Case sender.Name
                        Case "cboAccModels"
                            If Me.cboAccModels.SelectedValue > 0 Then
                                Me.txtQty.Focus()
                            Else
                                Me.cboAccModels.SelectAll()
                                Me.cboAccModels.Focus()
                            End If

                        Case "txtQty"
                            If CInt(Me.txtQty.Text.Trim) > 0 Then
                                Me.txtNewItemQty.Focus()
                            Else
                                Me.txtQty.Focus()
                            End If

                        Case "txtNewItemQty"
                            If CInt(Me.txtNewItemQty.Text.Trim) >= 0 And (CInt(Me.txtQty.Text.Trim) >= CInt(Me.txtNewItemQty.Text.Trim)) Then
                                Me.txtOrderNo.Focus()
                            Else
                                Me.txtNewItemQty.Focus()
                                Me.txtNewItemQty.SelectAll()
                                MessageBox.Show("Please enter New Item Qty that has to be less than Box Qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If

                        Case "txtOrderNo"
                            If Me.txtOrderNo.Text.Trim.Length > 0 Then
                                Me.ProcessTFOrder()
                                Me.txtOrderNo.Focus()
                                Me.txtOrderNo.Text = ""
                            Else
                                Me.txtOrderNo.Focus()
                            End If

                    End Select
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "KeyUpEvent", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            End Try
        End Sub

        '************************************************************************************
        Private Function ProcessTFOrder()
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer = 0
            Try

                Me.Enabled = False

                If Me.cboAccModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select accessory model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.Text = ""
                    Me.cboAccModels.Focus()
                ElseIf (CInt(Me.txtQty.Text.Trim) = 0 Or Me.txtQty.Text.Trim.Length = 0) Then
                    MessageBox.Show("Please enter Box Qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.Text = ""
                    Me.txtQty.Focus()
                ElseIf (CInt(Me.txtNewItemQty.Text.Trim) = 0 Or Me.txtNewItemQty.Text.Trim.Length = 0) Then
                    MessageBox.Show("Please enter New Item Qty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.Text = ""
                    Me.txtQty.Focus()
                    'ElseIf CInt(Me.txtNewItemQty.Text.Trim) <= CInt(Me.lblTotalQty.Text.Trim) Then
                    '    MessageBox.Show("Please stop adding more Order #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.txtOrderNo.Text = ""
                    '    Me.txtOrderNo.Enabled = False
                ElseIf Me._dtOrders.Select("[Order #] = '" & Me.txtOrderNo.Text.Trim & "'").Length > 0 Then
                    MessageBox.Show("Order is already listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOrderNo.SelectAll()
                    Me.txtOrderNo.Focus()
                Else
                    dt = _objTFBuildAccShipPallet.GetTFOrderNoToFillAccessory(Me.txtOrderNo.Text.Trim)

                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Order number does not exist or does not meet criteria.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    ElseIf Generic.IsBillcodeMapped(dt.Rows(0)("Model_ID"), Me._iBatteryCoverBillcodeID) = 0 Then
                        MessageBox.Show("Battery cover (ID:" & Me._iBatteryCoverBillcodeID & ") is not mapped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Function
                    End If

                    'i = Me._objTFBuildAccShipPallet.GetBillAccessoryWO(dt.Rows(0)("WO_ID"))
                    'If i > 0 Then
                    'MessageBox.Show("This Order #'s existed in the accessory table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    If dt.Select("pkslip_ID > 0").Length > 0 Then
                        MessageBox.Show("This Order number has already assigned to manifest number " & dt.Select("pkslip_ID > 0")(0)("pkslip_ID") & ".", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Select("WO_Closed = 0").Length > 0 Then
                        MessageBox.Show("This Order's still open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf dt.Rows(0)("cnt") <> dt.Rows(0)("wo_raqnty") Then
                        MessageBox.Show("There's discrepancy. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Cursor.Current = Cursors.WaitCursor
                        R1 = Me._dtOrders.NewRow
                        R1("Order #") = dt.Rows(0)("WO_CustWO")
                        R1("WO_ID") = dt.Rows(0)("WO_ID")
                        R1("Qty") = dt.Rows(0)("wo_raqnty")
                        Me._dtOrders.Rows.Add(R1)
                        Me._dtOrders.AcceptChanges()
                        Me.lstOrders.Refresh()
                        Me.lblOrderQty.Text = dt.Rows(0)("wo_raqnty")
                        If Not IsDBNull(_dtOrders.Compute("Sum(Qty)", "")) Then Me.lblTotalQty.Text = _dtOrders.Compute("Sum(Qty)", "") Else Me.lblTotalQty.Text = "0"
                        Me.txtOrderNo.Text = ""
                        Me.btnRemoveOne.Enabled = True
                        Me.btnRemoveAll.Enabled = True
                        Me.txtOrderNo.Focus()
                    End If
                    End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                R1 = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '************************************************************************************
        Private Sub btnRemoveOne_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveOne.Click
            Dim strOrderNo As String = ""
            Dim R1 As DataRow

            Try
                If Me.lstOrders.Items.Count = 0 Then
                    MessageBox.Show("The list is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    strOrderNo = InputBox("Please enter Order Number:", "Get Order").Trim

                    If strOrderNo.Length = 0 Then
                        Exit Sub : Me.txtOrderNo.Focus()
                    Else
                        If Me._dtOrders.Select("[Order #] = '" & strOrderNo & "' ").Length = 0 Then
                            MessageBox.Show("Order number is not listed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            R1 = Me._dtOrders.Select("[Order #] = '" & strOrderNo & "'")(0)
                            Me._dtOrders.Rows.Remove(R1)
                            Me._dtOrders.AcceptChanges()
                            Me.lstOrders.Refresh()
                            If Me._dtOrders.Rows.Count > 0 Then

                                Me.btnRemoveOne.Enabled = True
                                Me.btnRemoveAll.Enabled = True
                                Me.lblTotalQty.Text = _dtOrders.Compute("Sum(Qty)", "")
                                If CInt(Me.lblTotalQty.Text) < CInt(Me.txtNewItemQty.Text.Trim) Then
                                    Me.txtOrderNo.Enabled = True
                                End If
                            Else
                                Me.txtOrderNo.Enabled = True
                                Me.btnRemoveOne.Enabled = False
                                Me.btnRemoveAll.Enabled = False
                                Me.lblOrderQty.Text = "0"
                                Me.lblTotalQty.Text = "0"
                            End If
                            Me.txtOrderNo.Text = ""
                            Me.txtOrderNo.Focus()
                        End If
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveOneItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                R1 = Nothing
            End Try
        End Sub

        '************************************************************************************
        Private Sub btnRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAll.Click
            Try
                If MessageBox.Show("Are you sure you want to remove all items in the list.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                    Me.txtOrderNo.Focus()
                    Exit Sub
                Else
                    Me.ClearVarsAndCtrls()
                    Me._dtOrders.Clear()
                    Me._dtOrders.AcceptChanges()
                    Me.lstOrders.Refresh()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnRemoveAllItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '************************************************************************************
        Private Sub lstOrders_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstOrders.SelectedIndexChanged
            Dim I As Integer
            I = lstOrders.SelectedIndex
            Me.lblOrderQty.Text = Me._dtOrders.Rows(I)("Qty")
        End Sub

        '************************************************************************************

    End Class
End Namespace