Option Explicit On 

Imports PSS.Core.[Global]
Imports PSS.Data.Buisness

Public Class frmSonitrolReceiving
    Inherits System.Windows.Forms.Form

    Private _objSonitrolRec As SonitrolReceiving

    Private _strUserName As String = ApplicationUser.User
    Private _iUserID As Integer = ApplicationUser.IDuser
    Private _iEmpNo As Integer = ApplicationUser.NumberEmp
    Private _iShiftID As Integer = ApplicationUser.IDShift
    Private _strWorkDate As String = ApplicationUser.Workdate
    'Private _iMachineGroupID As String = ApplicationUser.GroupID
    Private _strMachineGroupDesc As String = ApplicationUser.Group_Desc

    Private Const _iProd_ID As Integer = 7
    Private _iSonitrolGroupID As Integer = 77
    Private _iWO_ID As Integer = 0
    Private _iTrayID As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objSonitrolRec = New SonitrolReceiving()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            _objSonitrolRec = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbRecModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dbgRecDevices As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnRec As System.Windows.Forms.Button
    Friend WithEvents txtRMA As System.Windows.Forms.TextBox
    Friend WithEvents txtRecSN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtWorkOrder As System.Windows.Forms.TextBox
    Friend WithEvents lblScanQty As System.Windows.Forms.Label
    Friend WithEvents lblScan As System.Windows.Forms.Label
    Friend WithEvents lblWO As System.Windows.Forms.Label
    Friend WithEvents lblWO_Qty As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCustSN As System.Windows.Forms.TextBox
    Friend WithEvents btnNewWO As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
    Friend WithEvents cboPSSPO As C1.Win.C1List.C1Combo
    Friend WithEvents btnCloseWO As System.Windows.Forms.Button
    Friend WithEvents btnViewRecdUnits As System.Windows.Forms.Button
    Friend WithEvents dbgOpenWO As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnReOpenWO As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSonitrolReceiving))
        Me.btnRec = New System.Windows.Forms.Button()
        Me.dbgRecDevices = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblScanQty = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtRMA = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtRecSN = New System.Windows.Forms.TextBox()
        Me.cmbRecModel = New PSS.Gui.Controls.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtWorkOrder = New System.Windows.Forms.TextBox()
        Me.lblScan = New System.Windows.Forms.Label()
        Me.lblWO = New System.Windows.Forms.Label()
        Me.lblWO_Qty = New System.Windows.Forms.Label()
        Me.btnNewWO = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCustSN = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCustomer = New C1.Win.C1List.C1Combo()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboLocation = New C1.Win.C1List.C1Combo()
        Me.cboPSSPO = New C1.Win.C1List.C1Combo()
        Me.btnCloseWO = New System.Windows.Forms.Button()
        Me.btnViewRecdUnits = New System.Windows.Forms.Button()
        Me.dbgOpenWO = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnReOpenWO = New System.Windows.Forms.Button()
        CType(Me.dbgRecDevices, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPSSPO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgOpenWO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRec
        '
        Me.btnRec.BackColor = System.Drawing.Color.Green
        Me.btnRec.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRec.ForeColor = System.Drawing.Color.White
        Me.btnRec.Location = New System.Drawing.Point(328, 200)
        Me.btnRec.Name = "btnRec"
        Me.btnRec.Size = New System.Drawing.Size(64, 20)
        Me.btnRec.TabIndex = 7
        Me.btnRec.Text = "RECEIVE"
        '
        'dbgRecDevices
        '
        Me.dbgRecDevices.AllowColSelect = False
        Me.dbgRecDevices.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgRecDevices.AllowSort = False
        Me.dbgRecDevices.AllowUpdate = False
        Me.dbgRecDevices.AllowUpdateOnBlur = False
        Me.dbgRecDevices.AlternatingRows = True
        Me.dbgRecDevices.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dbgRecDevices.FilterBar = True
        Me.dbgRecDevices.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgRecDevices.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgRecDevices.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgRecDevices.Location = New System.Drawing.Point(8, 256)
        Me.dbgRecDevices.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgRecDevices.Name = "dbgRecDevices"
        Me.dbgRecDevices.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgRecDevices.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgRecDevices.PreviewInfo.ZoomFactor = 75
        Me.dbgRecDevices.RowHeight = 20
        Me.dbgRecDevices.Size = New System.Drawing.Size(872, 232)
        Me.dbgRecDevices.TabIndex = 145
        Me.dbgRecDevices.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt;ForeColor:White;BackColor:DarkSlateGray;}Selected{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor" & _
        ":InactiveCaption;}FilterBar{BackColor:White;}Footer{}Caption{AlignHorz:Center;}S" & _
        "tyle9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert:Cent" & _
        "er;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Fo" & _
        "reColor:White;BackColor:DarkSlateBlue;}RecordSelector{AlignImage:Center;}Style13" & _
        "{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Cent" & _
        "er;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:White;BackColor:SteelBlu" & _
        "e;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></S" & _
        "tyles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColSelect=""False"" Name="""" Allo" & _
        "wRowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHei" & _
        "ght=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder" & _
        """ RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizonta" & _
        "lScrollGroup=""1""><Height>228</Height><CaptionStyle parent=""Style2"" me=""Style10"" " & _
        "/><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""" & _
        "Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=" & _
        """Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle p" & _
        "arent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style" & _
        "7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow""" & _
        " me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Sele" & _
        "ctedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><" & _
        "ClientRect>0, 0, 868, 228</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sun" & _
        "ken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style pa" & _
        "rent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headi" & _
        "ng"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading""" & _
        " me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" m" & _
        "e=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" m" & _
        "e=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""R" & _
        "ecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption""" & _
        " me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits>" & _
        "<Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0" & _
        ", 868, 228</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPage" & _
        "FooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'lblScanQty
        '
        Me.lblScanQty.BackColor = System.Drawing.Color.Black
        Me.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScanQty.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanQty.ForeColor = System.Drawing.Color.Lime
        Me.lblScanQty.Location = New System.Drawing.Point(432, 176)
        Me.lblScanQty.Name = "lblScanQty"
        Me.lblScanQty.Size = New System.Drawing.Size(104, 48)
        Me.lblScanQty.TabIndex = 144
        Me.lblScanQty.Text = "0"
        Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(24, 146)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "RMA Number:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRMA
        '
        Me.txtRMA.BackColor = System.Drawing.Color.White
        Me.txtRMA.Location = New System.Drawing.Point(120, 146)
        Me.txtRMA.MaxLength = 30
        Me.txtRMA.Name = "txtRMA"
        Me.txtRMA.Size = New System.Drawing.Size(200, 20)
        Me.txtRMA.TabIndex = 4
        Me.txtRMA.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(40, 200)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(80, 16)
        Me.Label10.TabIndex = 141
        Me.Label10.Text = "Internal SN:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRecSN
        '
        Me.txtRecSN.BackColor = System.Drawing.Color.White
        Me.txtRecSN.Location = New System.Drawing.Point(120, 200)
        Me.txtRecSN.MaxLength = 15
        Me.txtRecSN.Name = "txtRecSN"
        Me.txtRecSN.Size = New System.Drawing.Size(200, 20)
        Me.txtRecSN.TabIndex = 6
        Me.txtRecSN.Text = ""
        '
        'cmbRecModel
        '
        Me.cmbRecModel.AutoComplete = True
        Me.cmbRecModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbRecModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbRecModel.ForeColor = System.Drawing.Color.Black
        Me.cmbRecModel.Location = New System.Drawing.Point(120, 118)
        Me.cmbRecModel.Name = "cmbRecModel"
        Me.cmbRecModel.Size = New System.Drawing.Size(200, 21)
        Me.cmbRecModel.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(64, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 16)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "Model:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(8, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 147
        Me.Label2.Text = "Work Order (PO):"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtWorkOrder
        '
        Me.txtWorkOrder.BackColor = System.Drawing.Color.White
        Me.txtWorkOrder.Location = New System.Drawing.Point(120, 88)
        Me.txtWorkOrder.MaxLength = 100
        Me.txtWorkOrder.Name = "txtWorkOrder"
        Me.txtWorkOrder.Size = New System.Drawing.Size(200, 20)
        Me.txtWorkOrder.TabIndex = 1
        Me.txtWorkOrder.Text = ""
        '
        'lblScan
        '
        Me.lblScan.BackColor = System.Drawing.Color.Black
        Me.lblScan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScan.ForeColor = System.Drawing.Color.White
        Me.lblScan.Location = New System.Drawing.Point(440, 177)
        Me.lblScan.Name = "lblScan"
        Me.lblScan.Size = New System.Drawing.Size(88, 14)
        Me.lblScan.TabIndex = 148
        Me.lblScan.Text = "Scan Qty"
        Me.lblScan.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWO
        '
        Me.lblWO.BackColor = System.Drawing.Color.Black
        Me.lblWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWO.ForeColor = System.Drawing.Color.White
        Me.lblWO.Location = New System.Drawing.Point(440, 121)
        Me.lblWO.Name = "lblWO"
        Me.lblWO.Size = New System.Drawing.Size(88, 16)
        Me.lblWO.TabIndex = 150
        Me.lblWO.Text = "WO Qty"
        Me.lblWO.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblWO_Qty
        '
        Me.lblWO_Qty.BackColor = System.Drawing.Color.Black
        Me.lblWO_Qty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblWO_Qty.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWO_Qty.ForeColor = System.Drawing.Color.Lime
        Me.lblWO_Qty.Location = New System.Drawing.Point(432, 120)
        Me.lblWO_Qty.Name = "lblWO_Qty"
        Me.lblWO_Qty.Size = New System.Drawing.Size(104, 48)
        Me.lblWO_Qty.TabIndex = 149
        Me.lblWO_Qty.Text = "0"
        Me.lblWO_Qty.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnNewWO
        '
        Me.btnNewWO.BackColor = System.Drawing.Color.SteelBlue
        Me.btnNewWO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewWO.ForeColor = System.Drawing.Color.White
        Me.btnNewWO.Location = New System.Drawing.Point(416, 8)
        Me.btnNewWO.Name = "btnNewWO"
        Me.btnNewWO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnNewWO.Size = New System.Drawing.Size(128, 20)
        Me.btnNewWO.TabIndex = 8
        Me.btnNewWO.Text = "New Workorder"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(16, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "Customer SN:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCustSN
        '
        Me.txtCustSN.BackColor = System.Drawing.Color.White
        Me.txtCustSN.Location = New System.Drawing.Point(120, 174)
        Me.txtCustSN.MaxLength = 30
        Me.txtCustSN.Name = "txtCustSN"
        Me.txtCustSN.Size = New System.Drawing.Size(200, 20)
        Me.txtCustSN.TabIndex = 5
        Me.txtCustSN.Text = ""
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(56, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 155
        Me.Label5.Text = "PSS PO:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(320, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "(Optional)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCustomer
        '
        Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCustomer.AutoCompletion = True
        Me.cboCustomer.AutoDropDown = True
        Me.cboCustomer.Caption = ""
        Me.cboCustomer.CaptionHeight = 17
        Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCustomer.ColumnCaptionHeight = 17
        Me.cboCustomer.ColumnFooterHeight = 17
        Me.cboCustomer.ContentHeight = 15
        Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomer.EditorHeight = 15
        Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboCustomer.ItemHeight = 15
        Me.cboCustomer.Location = New System.Drawing.Point(120, 5)
        Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomer.MaxDropDownItems = CType(5, Short)
        Me.cboCustomer.MaxLength = 32767
        Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomer.Name = "cboCustomer"
        Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomer.Size = New System.Drawing.Size(200, 21)
        Me.cboCustomer.TabIndex = 7
        Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(24, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 16)
        Me.Label7.TabIndex = 158
        Me.Label7.Text = "Customer:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(24, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 16)
        Me.Label8.TabIndex = 160
        Me.Label8.Text = "Location:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboLocation
        '
        Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboLocation.AutoCompletion = True
        Me.cboLocation.AutoDropDown = True
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
        Me.cboLocation.Location = New System.Drawing.Point(120, 32)
        Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
        Me.cboLocation.MaxDropDownItems = CType(5, Short)
        Me.cboLocation.MaxLength = 32767
        Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboLocation.Size = New System.Drawing.Size(200, 21)
        Me.cboLocation.TabIndex = 8
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
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'cboPSSPO
        '
        Me.cboPSSPO.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboPSSPO.AutoCompletion = True
        Me.cboPSSPO.AutoDropDown = True
        Me.cboPSSPO.Caption = ""
        Me.cboPSSPO.CaptionHeight = 17
        Me.cboPSSPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPSSPO.ColumnCaptionHeight = 17
        Me.cboPSSPO.ColumnFooterHeight = 17
        Me.cboPSSPO.ContentHeight = 15
        Me.cboPSSPO.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPSSPO.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPSSPO.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPSSPO.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPSSPO.EditorHeight = 15
        Me.cboPSSPO.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboPSSPO.ItemHeight = 15
        Me.cboPSSPO.Location = New System.Drawing.Point(120, 58)
        Me.cboPSSPO.MatchEntryTimeout = CType(2000, Long)
        Me.cboPSSPO.MaxDropDownItems = CType(5, Short)
        Me.cboPSSPO.MaxLength = 32767
        Me.cboPSSPO.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPSSPO.Name = "cboPSSPO"
        Me.cboPSSPO.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPSSPO.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPSSPO.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPSSPO.Size = New System.Drawing.Size(200, 21)
        Me.cboPSSPO.TabIndex = 9
        Me.cboPSSPO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'btnCloseWO
        '
        Me.btnCloseWO.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCloseWO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseWO.ForeColor = System.Drawing.Color.White
        Me.btnCloseWO.Location = New System.Drawing.Point(416, 32)
        Me.btnCloseWO.Name = "btnCloseWO"
        Me.btnCloseWO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCloseWO.Size = New System.Drawing.Size(128, 20)
        Me.btnCloseWO.TabIndex = 9
        Me.btnCloseWO.Text = "Close Workorder"
        '
        'btnViewRecdUnits
        '
        Me.btnViewRecdUnits.BackColor = System.Drawing.Color.SteelBlue
        Me.btnViewRecdUnits.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewRecdUnits.ForeColor = System.Drawing.Color.White
        Me.btnViewRecdUnits.Location = New System.Drawing.Point(8, 232)
        Me.btnViewRecdUnits.Name = "btnViewRecdUnits"
        Me.btnViewRecdUnits.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnViewRecdUnits.Size = New System.Drawing.Size(312, 20)
        Me.btnViewRecdUnits.TabIndex = 10
        Me.btnViewRecdUnits.Text = "View Received Units in Work Order"
        '
        'dbgOpenWO
        '
        Me.dbgOpenWO.AllowColSelect = False
        Me.dbgOpenWO.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgOpenWO.AllowSort = False
        Me.dbgOpenWO.AllowUpdate = False
        Me.dbgOpenWO.AllowUpdateOnBlur = False
        Me.dbgOpenWO.AlternatingRows = True
        Me.dbgOpenWO.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgOpenWO.Caption = "Open Work Order"
        Me.dbgOpenWO.CaptionHeight = 17
        Me.dbgOpenWO.FilterBar = True
        Me.dbgOpenWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgOpenWO.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgOpenWO.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.dbgOpenWO.Location = New System.Drawing.Point(568, 8)
        Me.dbgOpenWO.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgOpenWO.Name = "dbgOpenWO"
        Me.dbgOpenWO.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgOpenWO.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgOpenWO.PreviewInfo.ZoomFactor = 75
        Me.dbgOpenWO.RowHeight = 20
        Me.dbgOpenWO.Size = New System.Drawing.Size(312, 216)
        Me.dbgOpenWO.TabIndex = 161
        Me.dbgOpenWO.Visible = False
        Me.dbgOpenWO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt;ForeColor:White;BackColor:DarkSlateGray;}Selected{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor" & _
        ":InactiveCaption;}FilterBar{BackColor:White;}Footer{}Caption{Font:Tahoma, 8.25pt" & _
        ", style=Bold;AlignHorz:Center;BackColor:CadetBlue;}Style1{}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt;AlignVert:Center;BackColor:Control;}HighlightRow{ForeColor:H" & _
        "ighlightText;BackColor:Highlight;}Style14{}OddRow{ForeColor:White;BackColor:Dark" & _
        "SlateBlue;}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Mic" & _
        "rosoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:SteelBlue;Borde" & _
        "r:Raised,,1, 1, 1, 1;ForeColor:White;AlignVert:Center;}Style8{}Style10{AlignHorz" & _
        ":Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1True" & _
        "DBGrid.MergeView AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" Alternatin" & _
        "gRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" D" & _
        "efRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>195" & _
        "</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edito" & _
        "r"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle pa" & _
        "rent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Grou" & _
        "pStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" " & _
        "/><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""" & _
        "Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelect" & _
        "orStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" " & _
        "me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 17, 308, 195</" & _
        "ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C" & _
        "1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Styl" & _
        "e parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pa" & _
        "rent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style par" & _
        "ent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=" & _
        """Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent" & _
        "=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style par" & _
        "ent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles" & _
        "><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defau" & _
        "ltRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 308, 212</ClientArea><Pri" & _
        "ntPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""S" & _
        "tyle15"" /></Blob>"
        '
        'btnReOpenWO
        '
        Me.btnReOpenWO.BackColor = System.Drawing.Color.SteelBlue
        Me.btnReOpenWO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReOpenWO.ForeColor = System.Drawing.Color.White
        Me.btnReOpenWO.Location = New System.Drawing.Point(416, 56)
        Me.btnReOpenWO.Name = "btnReOpenWO"
        Me.btnReOpenWO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReOpenWO.Size = New System.Drawing.Size(128, 20)
        Me.btnReOpenWO.TabIndex = 162
        Me.btnReOpenWO.Text = "Re-Open Workorder"
        '
        'frmSonitrolReceiving
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(904, 509)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReOpenWO, Me.dbgOpenWO, Me.btnViewRecdUnits, Me.btnCloseWO, Me.cboPSSPO, Me.Label8, Me.cboLocation, Me.Label7, Me.cboCustomer, Me.Label6, Me.Label5, Me.Label3, Me.txtCustSN, Me.btnNewWO, Me.lblWO, Me.lblWO_Qty, Me.lblScan, Me.Label2, Me.txtWorkOrder, Me.btnRec, Me.dbgRecDevices, Me.lblScanQty, Me.Label1, Me.txtRMA, Me.Label10, Me.txtRecSN, Me.cmbRecModel, Me.Label4})
        Me.Name = "frmSonitrolReceiving"
        Me.Text = "Sonitrol Receiving"
        CType(Me.dbgRecDevices, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPSSPO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgOpenWO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**************************************************************
    Private Sub frmSonitrolReceiving_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim dt As DataTable
        Try
            cboCustomer.Focus()

            '****************************************
            'Handlers to highlight in custom colors
            '****************************************
            PSS.Core.Highlight.SetHighLight(Me)

            '********************************************
            'Load Model 
            '********************************************
            Generic.DisposeDT(dt)
            dt = SonitrolReceiving.GetReverseLogisticsCustomers(True)
            Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "cust_name1", "cust_id")
            Me.cboCustomer.SelectedValue = 0

            LoadModels()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMisc = Nothing
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadModels()
        Dim dtModels As New DataTable()

        Try
            dtModels = Me._objSonitrolRec.GetSonitrolModels()
            dtModels.LoadDataRow(New Object() {"0", "--Select--"}, False)
            With Me.cmbRecModel
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
        End Try
    End Sub

    '**************************************************************
    Private Sub GetReceivedUnits()
        Dim i As Integer
        Dim dt As DataTable

        Try
            dt = Me._objSonitrolRec.GetReceivedDevicesByWOID(Me._iWO_ID)
            With Me.dbgRecDevices
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .Visible = True
                Me.lblWO_Qty.Text = dt.Rows.Count

                If CInt(Me.lblWO_Qty.Text) > 0 Then
                    Me.btnCloseWO.Visible = True
                    Me.btnViewRecdUnits.Visible = True
                End If

                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (Me.dbgRecDevices.Columns.Count - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next i

                'Set Column Widths
                .Splits(0).DisplayColumns("Seq").Width = 40
                .Splits(0).DisplayColumns("PSS SN").Width = 130
                .Splits(0).DisplayColumns("Customer SN").Width = 100
                .Splits(0).DisplayColumns("Customer RMA").Width = 100
                .Splits(0).DisplayColumns("PSS Warranty").Width = 100
                .Splits(0).DisplayColumns("Receipt Date").Width = 100
                .Splits(0).DisplayColumns("Prod Ship Date").Width = 130
            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '**************************************************************
    Private Sub txtWorkOrder_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWorkOrder.Leave
        Dim i As Integer = 0

        Try
            If Me.txtWorkOrder.Text.Trim = "" Then
                Exit Sub
            ElseIf Me.cboLocation.SelectedValue > 0 Then
                i = Me.ProcessWorkorder(True)
                If Me.cboPSSPO.DataSource.Table.Rows.Count = 1 Then Me.cmbRecModel.Focus() Else Me.cboPSSPO.Focus()
                ''***************************
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "WorkorderLeave", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**************************************************************
    Private Function ProcessWorkorder(ByVal booCreateIfNoExist As Boolean) As Integer
        Dim dt As DataTable
        Dim strWO As String = ""
        Dim objRec As PSS.Data.Production.Receiving
        Dim iPOID As Integer = 0
        Dim iReturnVal As Integer = 0

        Try
            dt = Me._objSonitrolRec.GetWorkorderInfo(Me.txtWorkOrder.Text.Trim, Me.cboLocation.SelectedValue)
            strWO = Me.txtWorkOrder.Text.Trim.ToUpper

            If dt.Rows.Count > 0 Then
                If dt.Rows(0)("WO_Closed") = 1 Then
                    MessageBox.Show("This work order is closed. You must re-open to receive.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    Me.lblWO_Qty.Text = Me._objSonitrolRec.GetReceivedDevicesByWOID(dt.Rows(0)("WO_ID")).Rows.Count
                    Me._iWO_ID = dt.Rows(0)("WO_ID").ToString
                    Me._iTrayID = Generic.GetTrayID(Me._iWO_ID)
                    If Not IsDBNull(dt.Rows(0)("PO_ID").ToString) Then Me.cboPSSPO.SelectedValue = dt.Rows(0)("PO_ID").ToString
                    Me.txtWorkOrder.Enabled = False
                    If CInt(Me.lblWO_Qty.Text) > 0 Then
                        Me.btnCloseWO.Visible = True
                        Me.btnViewRecdUnits.Visible = True
                    End If

                    iReturnVal = 1
                End If
            ElseIf booCreateIfNoExist = True Then
                If MessageBox.Show("This Work Order does not exist. Do you want to create?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                    Me.ResetControlsAndVar()
                    Me.txtWorkOrder.Text = strWO
                    Me.txtWorkOrder.SelectAll()
                Else
                    If Me.cboLocation.SelectedValue = 0 Then
                        MessageBox.Show("Please Select Location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.cboLocation.Focus()
                    ElseIf Me.txtWorkOrder.Text.Trim.Length = 0 Then
                        MessageBox.Show("Please enter work order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        iPOID = Me.cboPSSPO.SelectedValue

                        objRec = New PSS.Data.Production.Receiving()
                        Me._iWO_ID = objRec.InsertIntoTworkorder(strWO, strWO, Me.cboLocation.SelectedValue, Me._iProd_ID, Me._iSonitrolGroupID, , , iPOID, , , )
                        If Me._iWO_ID = 0 Then Throw New Exception("System has failed to create 'Work Order'.")

                        Me.txtWorkOrder.Enabled = False

                        Me._iTrayID = objRec.InsertIntoTtray(Me._iUserID, Me._strUserName, Me._iWO_ID, )
                        If Me._iTrayID = 0 Then Throw New Exception("System has failed to create tray.")

                        iReturnVal = 1
                    End If
                End If
            End If

            Return iReturnVal
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "WorkorderKeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
            objRec = Nothing
        End Try
    End Function

    '**************************************************************
    Private Sub btnNewWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewWO.Click
        Me.ResetControlsAndVar()
        Me.txtWorkOrder.Focus()
    End Sub

    '**************************************************************
    Private Sub ResetControlsAndVar()
        Me.dbgRecDevices.DataSource = Nothing
        Me.dbgRecDevices.Visible = False
        Me.btnCloseWO.Visible = False
        Me.btnViewRecdUnits.Visible = False
        Me.txtWorkOrder.Enabled = True
        Me.txtWorkOrder.Text = ""
        Me.cmbRecModel.SelectedValue = 0
        Me.txtRMA.Text = ""
        Me.txtCustSN.Text = ""
        Me.txtRecSN.Text = ""
        Me.lblScanQty.Text = "0"
        Me.lblWO_Qty.Text = "0"

        Me._iWO_ID = 0
        Me._iTrayID = 0
    End Sub

    '**************************************************************
    Private Sub cmbRecModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRecModel.SelectionChangeCommitted
        If Me.cmbRecModel.SelectedValue > 0 Then
            Me.txtRMA.Focus()
        End If
    End Sub

    '**************************************************************
    Private Sub txtRMA_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRMA.KeyUp
        If e.KeyValue = 13 AndAlso Me.txtRMA.Text.Trim.Length > 0 Then
            Me.txtCustSN.Focus()
        End If
    End Sub

    '**************************************************************
    Private Sub txtCustSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustSN.KeyUp
        If e.KeyValue = 13 AndAlso Me.txtCustSN.Text.Trim.Length > 0 Then
            Me.txtRecSN.Focus()
        End If
    End Sub

    ''**************************************************************
    'Private Sub txtRecSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRecSN.KeyUp
    '    Dim i As Integer = 0

    '    Try
    '        If e.KeyValue = 13 Then
    '            If Me.txtRecSN.Text.Trim = "" Then
    '                Exit Sub
    '            Else
    '                i = Me.ProcessSerialNum_Receive
    '                ''***************************
    '                If i > 0 Then
    '                    Me.txtRMA.Text = ""
    '                    Me.txtCustSN.Text = ""
    '                    Me.txtRecSN.Text = ""
    '                    Me.txtRMA.Focus()
    '                End If
    '                ''***************************
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.ToString, "Scanned SN Keyup", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
    '    End Try
    'End Sub

    '**************************************************************
    Private Function ValidateRMAPattern() As Boolean
        Dim strAlphaNumericSec As String = ""
        Dim strDigitSec As String = ""
        Dim i As Integer = 0

        Try
            strDigitSec = Microsoft.VisualBasic.Right(Me.txtRMA.Text.Trim, 6)
            For i = 0 To strDigitSec.Length - 1
                If Char.IsDigit(strDigitSec.Chars(i)) = False Then
                    MessageBox.Show("RMA must start with 3 characters of alphanumeric and follow by 6 diggits number.", "ValidateRMA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return False
                End If
            Next i

            strAlphaNumericSec = Microsoft.VisualBasic.Left(Me.txtRMA.Text.Trim, 3)
            For i = 0 To strAlphaNumericSec.Length - 1
                If Char.IsLetterOrDigit(strAlphaNumericSec.Chars(i)) = False Then
                    MessageBox.Show("RMA must start with 3 characters of alphanumeric and follow by 6 diggits number.", "ValidateRMA", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return False
                End If
            Next i

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '**************************************************************
    Private Function ValidateSNPattern() As Boolean
        Dim strAlphaNumericSec As String = ""
        Dim i As Integer = 0

        Try
            If Microsoft.VisualBasic.Left(Me.txtRecSN.Text.Trim, 4).ToUpper <> "PSSI" Then
                MessageBox.Show("Internal SN must start with ""PSSI""", "ValidateSN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Return False
            Else
                strAlphaNumericSec = Microsoft.VisualBasic.Right(Me.txtRecSN.Text.Trim, 6)
                For i = 0 To strAlphaNumericSec.Length - 1
                    If Char.IsLetterOrDigit(strAlphaNumericSec.Chars(i)) = False Then
                        MessageBox.Show("Internal SN must end with 10 characters of alphanumeric.", "ValidateSN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Return False
                    End If
                Next i
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '**************************************************************
    Private Function ProcessSerialNum_Receive() As Integer
        Dim booSNExisted As Boolean = False
        Dim iDeviceID, iPOID As Integer
        Dim drNewRow As DataRow
        Dim iPSSWarranty As Integer = 0

        Try
            ProcessSerialNum_Receive = 0 : iDeviceID = 0 : iPOID = 0

            If Me.txtRecSN.Text.Trim = "" Then
                Exit Function
            ElseIf Me.cboCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cboCustomer.Focus()
            ElseIf Me.cboLocation.SelectedValue = 0 Then
                MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cboLocation.Focus()
            ElseIf Me._iWO_ID = 0 Then
                MessageBox.Show("Please enter workorder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtWorkOrder.Focus()
            ElseIf Me._iTrayID = 0 Then
                MessageBox.Show("Please enter workorder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtWorkOrder.Focus()
            ElseIf Me.cmbRecModel.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cmbRecModel.Focus()
            ElseIf Me.txtRMA.Text.Trim = "" Then
                MessageBox.Show("Please enter RMA Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtRMA.Focus()
                'ElseIf Me.txtRMA.Text.Trim.Length <> 9 Then
                '    MessageBox.Show("The length of RMA number must be 9.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                '    Me.txtRMA.SelectAll()
                '    Me.txtRMA.Focus()
                'ElseIf Me.ValidateRMAPattern() = False Then
                '    Me.txtRMA.SelectAll()
                '    Me.txtRMA.Focus()
            ElseIf Me.txtCustSN.Text.Trim = "" Then
                MessageBox.Show("Please enter Customer SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtCustSN.Focus()
            ElseIf Me.txtRecSN.Text.Trim.Length <> 10 Then
                MessageBox.Show("The length of Internal SN number must be 10.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtRecSN.SelectAll()
            ElseIf Me.ValidateSNPattern() = False Then
                Me.txtRecSN.SelectAll()
                Me.txtRecSN.Focus()
            ElseIf Generic.IsSNInWIP(Me.cboCustomer.SelectedValue, Me.txtRecSN.Text.Trim.ToUpper) = True Then
                '*********************************
                '2:: Check if device exist in WIP
                '*********************************
                MessageBox.Show("This serial number (" & Me.txtRecSN.Text.Trim & ") is already existed in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.txtRecSN.Text = ""
                Me.txtRecSN.SelectAll()
            Else
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                ''*********************************
                ''3:: Check for Warranty
                ''*********************************
                'iPSSWarranty = Me._objSonitrolRec.CheckPSSWarranty(Me._iLoc_ID, Me.txtRecSN.Text.Trim.ToUpper)

                If Not IsNothing(Me.cboPSSPO.DataSource) AndAlso Me.cboPSSPO.SelectedValue > 0 Then iPOID = Me.cboPSSPO.SelectedValue

                iDeviceID = Me._objSonitrolRec.RecDevicesIntoPSSWIP(Me.cboCustomer.SelectedValue, _
                                         Me.cboLocation.SelectedValue, _
                                         iPOID, _
                                         Me.txtWorkOrder.Text.Trim.ToUpper, _
                                         Me._iWO_ID, _
                                         Me._iTrayID, _
                                         Me.cmbRecModel.SelectedValue, _
                                         Me._strUserName, _
                                         Me._iUserID, _
                                         Me._iEmpNo, _
                                         Me._iShiftID, _
                                         Me._strWorkDate, _
                                         Me.txtRMA.Text.Trim.ToUpper, _
                                         Me.txtCustSN.Text.Trim.ToUpper, _
                                         Me.txtRecSN.Text.Trim.ToUpper, _
                                         iPSSWarranty)
                If iDeviceID > 0 Then
                    Me.BillServicesCode(iDeviceID)
                    Me.lblScanQty.Text = CInt(Me.lblScanQty.Text) + 1
                    Me.lblWO_Qty.Text = CInt(Me.lblWO_Qty.Text) + 1
                    Me.txtRMA.Text = ""
                    Me.txtCustSN.Text = ""
                    Me.txtRecSN.Text = ""

                    If CInt(Me.lblWO_Qty.Text) > 0 Then
                        Me.btnCloseWO.Visible = True
                        Me.btnViewRecdUnits.Visible = True
                    End If

                    Return iDeviceID
                End If
            End If

        Catch ex As Exception
            Throw ex
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Function

    '**************************************************************
    Private Sub btnRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRec.Click
        Dim i As Integer = 0

        Try
            If Me.txtRecSN.Text.Trim.Length > 0 Then
                i = Me.ProcessSerialNum_Receive
                If i > 0 Then
                    If CInt(Me.lblWO_Qty.Text) > 0 Then
                        Me.btnCloseWO.Visible = True
                        Me.btnViewRecdUnits.Visible = True
                    End If
                    Me.txtRMA.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnRec_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**************************************************************
    Private Sub BillServicesCode(ByVal iDeviceID As Integer)
        Const iPassBillCode As Integer = 1597
        Const iAlignmentBillcodes As Integer = 1361
        Dim objDevice As PSS.Rules.Device

        Try
            If Generic.IsBillcodeMapped(Me.cmbRecModel.SelectedValue, iAlignmentBillcodes) > 0 Then
                If Generic.IsBillcodeExisted(iDeviceID, iAlignmentBillcodes) = False Then
                    If IsNothing(objDevice) = True Then objDevice = New PSS.Rules.Device(iDeviceID)
                    objDevice.AddPart(iAlignmentBillcodes)
                End If
            ElseIf Generic.IsBillcodeMapped(Me.cmbRecModel.SelectedValue, iPassBillCode) > 0 Then
                If Generic.IsBillcodeExisted(iDeviceID, iPassBillCode) = False Then
                    If IsNothing(objDevice) = True Then objDevice = New PSS.Rules.Device(iDeviceID)
                    objDevice.AddPart(iPassBillCode)
                End If
            End If
            If Not IsNothing(objDevice) Then objDevice.Update()

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(objDevice) Then
                objDevice.Dispose()
                objDevice = Nothing
            End If
        End Try
    End Sub

    '**************************************************************
    Private Sub cboCustomer_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Enter
        Try
            Me.dbgOpenWO.DataSource = Nothing
            Me.dbgOpenWO.Visible = False
            Me.cboPSSPO.DataSource = Nothing
            Me.cboPSSPO.Text = ""
            Me.cboLocation.DataSource = Nothing
            Me.cboLocation.Text = ""
            Me.ResetControlsAndVar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCustomer_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***********************************************************************************************
    Private Sub cboCustomer_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomer.KeyUp
        Dim dt As DataTable

        Try
            If e.KeyCode = Keys.Enter Then
                If Me.cboCustomer.SelectedValue > 0 Then

                    dt = Generic.GetLocations(True, Me.cboCustomer.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboLocation, dt, "Loc_Name", "Loc_ID")
                    If dt.Rows.Count = 2 Then
                        Me.cboLocation.SelectedValue = dt.Rows(0)("Loc_ID")
                        Me.PopulateOpenWorkOrder()

                        'Populate PO
                        dt = Nothing
                        dt = Generic.GetPOs(True, Me.cboLocation.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboPSSPO, dt, "PO_Desc", "PO_ID")
                        Me.cboPSSPO.SelectedValue = 0
                        Me.cboPSSPO.Focus()
                    Else
                        Me.cboLocation.Focus()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCustomer_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '***********************************************************************************************
    Private Sub cboLocation_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.Enter
        Try
            Me.dbgOpenWO.DataSource = Nothing
            Me.dbgOpenWO.Visible = False
            Me.cboPSSPO.DataSource = Nothing
            Me.cboPSSPO.Text = ""
            Me.ResetControlsAndVar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboLocation_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***********************************************************************************************
    Private Sub cboLocation_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboLocation.Leave
        Dim dt As DataTable

        Try
            If Me.cboLocation.SelectedValue > 0 Then
                Me.PopulateOpenWorkOrder()
                'Populate PO
                Generic.DisposeDT(dt)
                dt = Generic.GetPOs(True, Me.cboLocation.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboPSSPO, dt, "PO_Desc", "PO_ID")
                Me.cboPSSPO.SelectedValue = 0
                Me.cboPSSPO.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCustomer_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '***********************************************************************************************
    Private Sub btnCloseWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseWO.Click
        Dim i As Integer = 0

        Try
            If Me._iWO_ID > 0 AndAlso CInt(Me.lblWO_Qty.Text) > 0 Then i = Generic.CloseWO(Me._iWO_ID)
            If i > 0 Then
                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.ResetControlsAndVar()
                Me.PopulateOpenWorkOrder()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCloseWO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***********************************************************************************************
    Private Sub btnViewRecdUnits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewRecdUnits.Click
        Try
            If Me._iWO_ID > 0 Then Me.GetReceivedUnits()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnViewRecdUnits_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***********************************************************************************************
    Private Sub PopulateOpenWorkOrder()
        Dim i As Integer
        Dim dt As DataTable
        Dim objRMA As CreateRMA

        Try
            If Me.cboLocation.SelectedValue > 0 Then
                objRMA = New CreateRMA()
                dt = objRMA.GetOpenRMA(Me.cboLocation.SelectedValue, Me._iProd_ID)

                With Me.dbgOpenWO
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .Visible = True

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                        If dt.Columns(i).Caption.EndsWith("Qty") Then
                            .Splits(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        End If
                    Next i

                    .Splits(0).DisplayColumns("RMA/WO").Width = 100
                    .Splits(0).DisplayColumns("RMA Date").Width = 90
                    .Splits(0).DisplayColumns("File Qty").Width = 60
                    .Splits(0).DisplayColumns("Receipt Qty").Width = 75
                    .Splits(0).DisplayColumns("PO ID").Width = 50
                    .Splits(0).DisplayColumns("Assign To Group").Width = 130
                    .Splits(0).DisplayColumns("ASN File?").Width = 80

                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '***********************************************************************************************
    Private Sub btnReOpenWO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReOpenWO.Click
        Dim dt As DataTable
        Dim strWOName, strTrayMemo As String
        Dim i As Integer = 0

        Try
            strWOName = "" : strTrayMemo = ""

            If Me.cboCustomer.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboCustomer.Focus()
            ElseIf Me.cboLocation.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboLocation.Focus()
            Else
                strWOName = InputBox("Enter Workorder Name:", "Get WO").Trim
                If strWOName.Length = 0 Then
                    Exit Sub
                Else
                    dt = Generic.GetCustWo(strWOName, Me.cboLocation.SelectedValue)
                    If dt.Rows.Count = 0 Then
                        MessageBox.Show("Workorder does not exist.", "Information", MessageBoxButtons.OK)
                    ElseIf dt.Rows.Count > 1 Then
                        MessageBox.Show("Workorder existed more than one in the system. Please Contact IT.", "Information", MessageBoxButtons.OK)
                    Else
                        i = Generic.ReOpenWO(dt.Rows(0)("WO_ID"))
                        If i > 0 Then
                            Me.txtWorkOrder.Text = dt.Rows(0)("WO_CustWo")
                            Me.ProcessWorkorder(False)
                            Me.PopulateOpenWorkOrder()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnReOpenWO_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '***********************************************************************************************

End Class


