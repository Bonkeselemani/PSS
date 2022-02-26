Imports PSS.Core.Global

Namespace Gui.Security

    Public Class SecurityAdmin
        Inherits System.Windows.Forms.Form

        Private dtLevel, dtGroup, dtUser, dtScreen, dtPermissions As DataTable
        Private xCount As Integer = 0
        Private yCount As Integer = 0
        Private r As DataRow
        Private valUID As Int32 = 0
        Private valSID As Int32 = 0
        Private valPID As Int32 = 0
        Private intUser, intCopyToUser As Int32
        Private _objSecAdmin As New PSS.Data.Buisness.SecurityAdmin()

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
        Friend WithEvents tdgLevel As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnADD As System.Windows.Forms.Button
        Friend WithEvents btnEdit As System.Windows.Forms.Button
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents tdgGroup As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnGROUPADD As System.Windows.Forms.Button
        Friend WithEvents btnGROUPEDIT As System.Windows.Forms.Button
        Friend WithEvents btnGROUPDELETE As System.Windows.Forms.Button
        Friend WithEvents grpUser As System.Windows.Forms.GroupBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents lblPassword As System.Windows.Forms.Label
        Friend WithEvents lblFullName As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents txtFullName As System.Windows.Forms.TextBox
        Friend WithEvents btnUSERADD As System.Windows.Forms.Button
        Friend WithEvents btnUSEREDIT As System.Windows.Forms.Button
        Friend WithEvents btnUSERDELETE As System.Windows.Forms.Button
        Friend WithEvents tdgUser As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnUSERNEW As System.Windows.Forms.Button
        Friend WithEvents grpScreen As System.Windows.Forms.GroupBox
        Friend WithEvents btnSCREENNEW As System.Windows.Forms.Button
        Friend WithEvents btnSCREENEDIT As System.Windows.Forms.Button
        Friend WithEvents btnSCREENADD As System.Windows.Forms.Button
        Friend WithEvents txtSysName As System.Windows.Forms.TextBox
        Friend WithEvents txtDescription As System.Windows.Forms.TextBox
        Friend WithEvents lblSysName As System.Windows.Forms.Label
        Friend WithEvents lblDesc As System.Windows.Forms.Label
        Friend WithEvents btnSCREENDELETE As System.Windows.Forms.Button
        Friend WithEvents tdgScreen As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tabUser As System.Windows.Forms.TabPage
        Friend WithEvents tabScreen As System.Windows.Forms.TabPage
        Friend WithEvents tabGroup As System.Windows.Forms.TabPage
        Friend WithEvents tabLevel As System.Windows.Forms.TabPage
        Friend WithEvents grpPermissions As System.Windows.Forms.GroupBox
        Friend WithEvents btnPERMNEW As System.Windows.Forms.Button
        Friend WithEvents btnPERMDELETE As System.Windows.Forms.Button
        Friend WithEvents btnPERMEDIT As System.Windows.Forms.Button
        Friend WithEvents btnPERMADD As System.Windows.Forms.Button
        Friend WithEvents lblLevel As System.Windows.Forms.Label
        Friend WithEvents lblScreen As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents tdgPermissions As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cboLevel As System.Windows.Forms.ComboBox
        Friend WithEvents cboScreen As System.Windows.Forms.ComboBox
        Friend WithEvents cboGroup As System.Windows.Forms.ComboBox
        Friend WithEvents tabPermissions As System.Windows.Forms.TabPage
        Friend WithEvents txtEmpNo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtTechID As System.Windows.Forms.TextBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtQCNo As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents cboShift As PSS.Gui.Controls.ComboBox
        Friend WithEvents chkInactive As System.Windows.Forms.CheckBox
        Friend WithEvents tabDetail As System.Windows.Forms.TabPage
        Friend WithEvents grpUserDetail As System.Windows.Forms.GroupBox
        Friend WithEvents btnUserDetailUpdate As System.Windows.Forms.Button
        Friend WithEvents lstAvailableScreens As System.Windows.Forms.ListBox
        Friend WithEvents lblDetailCurrent As System.Windows.Forms.Label
        Friend WithEvents lstScreen As System.Windows.Forms.ListBox
        Friend WithEvents lblDetailScreen As System.Windows.Forms.Label
        Friend WithEvents lblDetailGroup As System.Windows.Forms.Label
        Friend WithEvents chklstGroup As System.Windows.Forms.CheckedListBox
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents cboUserDetail As System.Windows.Forms.ComboBox
        Friend WithEvents chkExempt As System.Windows.Forms.CheckBox
        Friend WithEvents chkClearMachine As System.Windows.Forms.CheckBox
        Friend WithEvents chkOT As System.Windows.Forms.CheckBox
        Friend WithEvents chkRefurber As System.Windows.Forms.CheckBox
        Friend WithEvents lblGroupSelect As System.Windows.Forms.Label
        Friend WithEvents cboGroupSelect As PSS.Gui.Controls.ComboBox
        Friend WithEvents btnSelectAll As System.Windows.Forms.Button
        Friend WithEvents btnUnselectAll As System.Windows.Forms.Button
        Friend WithEvents lblCopyToUser As System.Windows.Forms.Label
        Friend WithEvents cboCopyToUser As System.Windows.Forms.ComboBox
        Friend WithEvents btnCopyToUser As System.Windows.Forms.Button
        Friend WithEvents btnCopy2Clipboard As System.Windows.Forms.Button
        Friend WithEvents btnCopy2Clipboard2 As System.Windows.Forms.Button
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents chkLockout As System.Windows.Forms.CheckBox
        Friend WithEvents lblPWBack As System.Windows.Forms.Label
        Friend WithEvents grpGroup As System.Windows.Forms.GroupBox
        Friend WithEvents grpLevel As System.Windows.Forms.GroupBox
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents Button6 As System.Windows.Forms.Button
        Friend WithEvents btnGroupDeleteNew As System.Windows.Forms.Button
        Friend WithEvents btnGroupEditNew As System.Windows.Forms.Button
        Friend WithEvents btnGroupAddNew As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SecurityAdmin))
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.btnEdit = New System.Windows.Forms.Button()
            Me.btnADD = New System.Windows.Forms.Button()
            Me.tdgLevel = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnGROUPDELETE = New System.Windows.Forms.Button()
            Me.btnGROUPEDIT = New System.Windows.Forms.Button()
            Me.btnGROUPADD = New System.Windows.Forms.Button()
            Me.tdgGroup = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.grpUser = New System.Windows.Forms.GroupBox()
            Me.lblPWBack = New System.Windows.Forms.Label()
            Me.chkLockout = New System.Windows.Forms.CheckBox()
            Me.cboGroupSelect = New PSS.Gui.Controls.ComboBox()
            Me.lblGroupSelect = New System.Windows.Forms.Label()
            Me.chkRefurber = New System.Windows.Forms.CheckBox()
            Me.chkOT = New System.Windows.Forms.CheckBox()
            Me.chkClearMachine = New System.Windows.Forms.CheckBox()
            Me.chkExempt = New System.Windows.Forms.CheckBox()
            Me.chkInactive = New System.Windows.Forms.CheckBox()
            Me.cboShift = New PSS.Gui.Controls.ComboBox()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtQCNo = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtTechID = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtEmpNo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnUSERNEW = New System.Windows.Forms.Button()
            Me.tdgUser = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnUSERDELETE = New System.Windows.Forms.Button()
            Me.btnUSEREDIT = New System.Windows.Forms.Button()
            Me.btnUSERADD = New System.Windows.Forms.Button()
            Me.txtFullName = New System.Windows.Forms.TextBox()
            Me.txtPassword = New System.Windows.Forms.TextBox()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.lblFullName = New System.Windows.Forms.Label()
            Me.lblPassword = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.grpScreen = New System.Windows.Forms.GroupBox()
            Me.tdgScreen = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnSCREENNEW = New System.Windows.Forms.Button()
            Me.txtSysName = New System.Windows.Forms.TextBox()
            Me.btnSCREENEDIT = New System.Windows.Forms.Button()
            Me.lblDesc = New System.Windows.Forms.Label()
            Me.lblSysName = New System.Windows.Forms.Label()
            Me.txtDescription = New System.Windows.Forms.TextBox()
            Me.btnSCREENADD = New System.Windows.Forms.Button()
            Me.btnSCREENDELETE = New System.Windows.Forms.Button()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tabUser = New System.Windows.Forms.TabPage()
            Me.tabGroup = New System.Windows.Forms.TabPage()
            Me.grpGroup = New System.Windows.Forms.GroupBox()
            Me.btnGroupDeleteNew = New System.Windows.Forms.Button()
            Me.btnGroupEditNew = New System.Windows.Forms.Button()
            Me.btnGroupAddNew = New System.Windows.Forms.Button()
            Me.tabLevel = New System.Windows.Forms.TabPage()
            Me.grpLevel = New System.Windows.Forms.GroupBox()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.Button6 = New System.Windows.Forms.Button()
            Me.tabDetail = New System.Windows.Forms.TabPage()
            Me.grpUserDetail = New System.Windows.Forms.GroupBox()
            Me.btnCopy2Clipboard2 = New System.Windows.Forms.Button()
            Me.btnCopy2Clipboard = New System.Windows.Forms.Button()
            Me.btnCopyToUser = New System.Windows.Forms.Button()
            Me.lblCopyToUser = New System.Windows.Forms.Label()
            Me.cboCopyToUser = New System.Windows.Forms.ComboBox()
            Me.btnUnselectAll = New System.Windows.Forms.Button()
            Me.btnSelectAll = New System.Windows.Forms.Button()
            Me.btnUserDetailUpdate = New System.Windows.Forms.Button()
            Me.lstAvailableScreens = New System.Windows.Forms.ListBox()
            Me.lblDetailCurrent = New System.Windows.Forms.Label()
            Me.lstScreen = New System.Windows.Forms.ListBox()
            Me.lblDetailScreen = New System.Windows.Forms.Label()
            Me.lblDetailGroup = New System.Windows.Forms.Label()
            Me.chklstGroup = New System.Windows.Forms.CheckedListBox()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.cboUserDetail = New System.Windows.Forms.ComboBox()
            Me.tabPermissions = New System.Windows.Forms.TabPage()
            Me.grpPermissions = New System.Windows.Forms.GroupBox()
            Me.tdgPermissions = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cboLevel = New System.Windows.Forms.ComboBox()
            Me.cboScreen = New System.Windows.Forms.ComboBox()
            Me.cboGroup = New System.Windows.Forms.ComboBox()
            Me.btnPERMNEW = New System.Windows.Forms.Button()
            Me.btnPERMDELETE = New System.Windows.Forms.Button()
            Me.btnPERMEDIT = New System.Windows.Forms.Button()
            Me.btnPERMADD = New System.Windows.Forms.Button()
            Me.lblLevel = New System.Windows.Forms.Label()
            Me.lblScreen = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.tabScreen = New System.Windows.Forms.TabPage()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            CType(Me.tdgLevel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tdgGroup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpUser.SuspendLayout()
            CType(Me.tdgUser, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpScreen.SuspendLayout()
            CType(Me.tdgScreen, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControl1.SuspendLayout()
            Me.tabUser.SuspendLayout()
            Me.tabGroup.SuspendLayout()
            Me.grpGroup.SuspendLayout()
            Me.tabLevel.SuspendLayout()
            Me.grpLevel.SuspendLayout()
            Me.tabDetail.SuspendLayout()
            Me.grpUserDetail.SuspendLayout()
            Me.tabPermissions.SuspendLayout()
            Me.grpPermissions.SuspendLayout()
            CType(Me.tdgPermissions, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabScreen.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnDelete
            '
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.TabIndex = 0
            '
            'btnEdit
            '
            Me.btnEdit.Name = "btnEdit"
            Me.btnEdit.TabIndex = 0
            '
            'btnADD
            '
            Me.btnADD.Name = "btnADD"
            Me.btnADD.TabIndex = 0
            '
            'tdgLevel
            '
            Me.tdgLevel.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgLevel.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgLevel.Location = New System.Drawing.Point(8, 16)
            Me.tdgLevel.Name = "tdgLevel"
            Me.tdgLevel.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgLevel.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgLevel.PreviewInfo.ZoomFactor = 75
            Me.tdgLevel.Size = New System.Drawing.Size(256, 328)
            Me.tdgLevel.TabIndex = 0
            Me.tdgLevel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}St" & _
            "yle12{}OddRow{}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Back" & _
            "Color:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}" & _
            "Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style9{}</Data></Styl" & _
            "es><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCapti" & _
            "onHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSele" & _
            "ctorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup" & _
            "=""1""><Height>324</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorSty" & _
            "le parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><F" & _
            "ilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=" & _
            """Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Headi" & _
            "ng"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inacti" & _
            "veStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9""" & _
            " /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pa" & _
            "rent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0" & _
            ", 0, 252, 324</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderS" & _
            "tyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""" & _
            "Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Foot" & _
            "er"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactiv" & _
            "e"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /" & _
            "><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" " & _
            "/><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelecto" & _
            "r"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" " & _
            "/></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None" & _
            "</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 252, 324</" & _
            "ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle " & _
            "parent="""" me=""Style15"" /></Blob>"
            '
            'btnGROUPDELETE
            '
            Me.btnGROUPDELETE.Name = "btnGROUPDELETE"
            Me.btnGROUPDELETE.TabIndex = 0
            '
            'btnGROUPEDIT
            '
            Me.btnGROUPEDIT.Name = "btnGROUPEDIT"
            Me.btnGROUPEDIT.TabIndex = 0
            '
            'btnGROUPADD
            '
            Me.btnGROUPADD.Name = "btnGROUPADD"
            Me.btnGROUPADD.TabIndex = 0
            '
            'tdgGroup
            '
            Me.tdgGroup.AlternatingRows = True
            Me.tdgGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgGroup.FilterBar = True
            Me.tdgGroup.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgGroup.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.tdgGroup.Location = New System.Drawing.Point(8, 16)
            Me.tdgGroup.Name = "tdgGroup"
            Me.tdgGroup.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgGroup.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgGroup.PreviewInfo.ZoomFactor = 75
            Me.tdgGroup.Size = New System.Drawing.Size(256, 336)
            Me.tdgGroup.TabIndex = 0
            Me.tdgGroup.Text = "C1TrueDBGrid1"
            Me.tdgGroup.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Cente" & _
            "r;}Style15{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeCol" & _
            "or:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style" & _
            "12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>334</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 254, 334</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 254, 334</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'grpUser
            '
            Me.grpUser.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPWBack, Me.chkLockout, Me.cboGroupSelect, Me.lblGroupSelect, Me.chkRefurber, Me.chkOT, Me.chkClearMachine, Me.chkExempt, Me.chkInactive, Me.cboShift, Me.lblShift, Me.Label6, Me.Label5, Me.txtQCNo, Me.Label3, Me.txtTechID, Me.Label2, Me.txtEmpNo, Me.Label1, Me.btnUSERNEW, Me.tdgUser, Me.btnUSERDELETE, Me.btnUSEREDIT, Me.btnUSERADD, Me.txtFullName, Me.txtPassword, Me.txtName, Me.lblFullName, Me.lblPassword, Me.lblName})
            Me.grpUser.Location = New System.Drawing.Point(8, 8)
            Me.grpUser.Name = "grpUser"
            Me.grpUser.Size = New System.Drawing.Size(768, 472)
            Me.grpUser.TabIndex = 2
            Me.grpUser.TabStop = False
            Me.grpUser.Text = "USER"
            '
            'lblPWBack
            '
            Me.lblPWBack.ForeColor = System.Drawing.Color.Gray
            Me.lblPWBack.Location = New System.Drawing.Point(8, 448)
            Me.lblPWBack.Name = "lblPWBack"
            Me.lblPWBack.Size = New System.Drawing.Size(8, 16)
            Me.lblPWBack.TabIndex = 28
            '
            'chkLockout
            '
            Me.chkLockout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkLockout.Location = New System.Drawing.Point(296, 440)
            Me.chkLockout.Name = "chkLockout"
            Me.chkLockout.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkLockout.Size = New System.Drawing.Size(216, 24)
            Me.chkLockout.TabIndex = 27
            Me.chkLockout.Text = "Account Locked Out"
            '
            'cboGroupSelect
            '
            Me.cboGroupSelect.AutoComplete = True
            Me.cboGroupSelect.Location = New System.Drawing.Point(347, 384)
            Me.cboGroupSelect.Name = "cboGroupSelect"
            Me.cboGroupSelect.Size = New System.Drawing.Size(160, 21)
            Me.cboGroupSelect.TabIndex = 26
            '
            'lblGroupSelect
            '
            Me.lblGroupSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroupSelect.Location = New System.Drawing.Point(296, 384)
            Me.lblGroupSelect.Name = "lblGroupSelect"
            Me.lblGroupSelect.Size = New System.Drawing.Size(48, 16)
            Me.lblGroupSelect.TabIndex = 25
            Me.lblGroupSelect.Text = "Group:"
            Me.lblGroupSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkRefurber
            '
            Me.chkRefurber.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkRefurber.Location = New System.Drawing.Point(160, 416)
            Me.chkRefurber.Name = "chkRefurber"
            Me.chkRefurber.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkRefurber.Size = New System.Drawing.Size(88, 24)
            Me.chkRefurber.TabIndex = 24
            Me.chkRefurber.Text = "Refurber"
            '
            'chkOT
            '
            Me.chkOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkOT.Location = New System.Drawing.Point(53, 416)
            Me.chkOT.Name = "chkOT"
            Me.chkOT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkOT.Size = New System.Drawing.Size(96, 24)
            Me.chkOT.TabIndex = 23
            Me.chkOT.Text = "Over Time"
            '
            'chkClearMachine
            '
            Me.chkClearMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkClearMachine.Location = New System.Drawing.Point(296, 416)
            Me.chkClearMachine.Name = "chkClearMachine"
            Me.chkClearMachine.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkClearMachine.Size = New System.Drawing.Size(216, 24)
            Me.chkClearMachine.TabIndex = 22
            Me.chkClearMachine.Text = "Clear Last Logged on Machine"
            '
            'chkExempt
            '
            Me.chkExempt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkExempt.Location = New System.Drawing.Point(77, 392)
            Me.chkExempt.Name = "chkExempt"
            Me.chkExempt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkExempt.Size = New System.Drawing.Size(72, 24)
            Me.chkExempt.TabIndex = 21
            Me.chkExempt.Text = "Exempt"
            '
            'chkInactive
            '
            Me.chkInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkInactive.Location = New System.Drawing.Point(175, 392)
            Me.chkInactive.Name = "chkInactive"
            Me.chkInactive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
            Me.chkInactive.Size = New System.Drawing.Size(72, 24)
            Me.chkInactive.TabIndex = 10
            Me.chkInactive.Text = "Inactive   "
            '
            'cboShift
            '
            Me.cboShift.AutoComplete = True
            Me.cboShift.Location = New System.Drawing.Point(347, 359)
            Me.cboShift.Name = "cboShift"
            Me.cboShift.Size = New System.Drawing.Size(160, 21)
            Me.cboShift.TabIndex = 9
            '
            'lblShift
            '
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.Location = New System.Drawing.Point(296, 361)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(48, 16)
            Me.lblShift.TabIndex = 20
            Me.lblShift.Text = "Shift:"
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(508, 337)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(64, 16)
            Me.Label6.TabIndex = 19
            Me.Label6.Text = "(Numeric)"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(508, 313)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(64, 16)
            Me.Label5.TabIndex = 18
            Me.Label5.Text = "(Numeric)"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtQCNo
            '
            Me.txtQCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtQCNo.Location = New System.Drawing.Point(347, 335)
            Me.txtQCNo.Name = "txtQCNo"
            Me.txtQCNo.Size = New System.Drawing.Size(160, 20)
            Me.txtQCNo.TabIndex = 8
            Me.txtQCNo.Text = ""
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.Location = New System.Drawing.Point(264, 337)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 16)
            Me.Label3.TabIndex = 15
            Me.Label3.Text = "QC Stamp No:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTechID
            '
            Me.txtTechID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtTechID.Location = New System.Drawing.Point(347, 311)
            Me.txtTechID.Name = "txtTechID"
            Me.txtTechID.Size = New System.Drawing.Size(160, 20)
            Me.txtTechID.TabIndex = 7
            Me.txtTechID.Text = ""
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(288, 313)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(56, 16)
            Me.Label2.TabIndex = 13
            Me.Label2.Text = "Tech ID:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtEmpNo
            '
            Me.txtEmpNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtEmpNo.Location = New System.Drawing.Point(347, 287)
            Me.txtEmpNo.Name = "txtEmpNo"
            Me.txtEmpNo.Size = New System.Drawing.Size(160, 20)
            Me.txtEmpNo.TabIndex = 6
            Me.txtEmpNo.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(264, 288)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 11
            Me.Label1.Text = "Employee No:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnUSERNEW
            '
            Me.btnUSERNEW.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUSERNEW.ForeColor = System.Drawing.Color.Blue
            Me.btnUSERNEW.Location = New System.Drawing.Point(179, 255)
            Me.btnUSERNEW.Name = "btnUSERNEW"
            Me.btnUSERNEW.Size = New System.Drawing.Size(236, 25)
            Me.btnUSERNEW.TabIndex = 10
            Me.btnUSERNEW.Text = "Clear Screen to Add New User"
            '
            'tdgUser
            '
            Me.tdgUser.AlternatingRows = True
            Me.tdgUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgUser.FilterBar = True
            Me.tdgUser.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgUser.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.tdgUser.Location = New System.Drawing.Point(10, 16)
            Me.tdgUser.Name = "tdgUser"
            Me.tdgUser.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgUser.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgUser.PreviewInfo.ZoomFactor = 75
            Me.tdgUser.Size = New System.Drawing.Size(742, 232)
            Me.tdgUser.TabIndex = 9
            Me.tdgUser.Text = "C1TrueDBGrid1"
            Me.tdgUser.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Cente" & _
            "r;}Style15{}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeCo" & _
            "lor:ControlText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style" & _
            "12{}Style13{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>230</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 740, 230</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 740, 230</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'btnUSERDELETE
            '
            Me.btnUSERDELETE.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUSERDELETE.ForeColor = System.Drawing.Color.Red
            Me.btnUSERDELETE.Location = New System.Drawing.Point(576, 350)
            Me.btnUSERDELETE.Name = "btnUSERDELETE"
            Me.btnUSERDELETE.Size = New System.Drawing.Size(176, 32)
            Me.btnUSERDELETE.TabIndex = 8
            Me.btnUSERDELETE.Text = "Delete Selected User"
            Me.btnUSERDELETE.Visible = False
            '
            'btnUSEREDIT
            '
            Me.btnUSEREDIT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUSEREDIT.ForeColor = System.Drawing.Color.ForestGreen
            Me.btnUSEREDIT.Location = New System.Drawing.Point(576, 311)
            Me.btnUSEREDIT.Name = "btnUSEREDIT"
            Me.btnUSEREDIT.Size = New System.Drawing.Size(176, 32)
            Me.btnUSEREDIT.TabIndex = 11
            Me.btnUSEREDIT.Text = "Update Selected User"
            '
            'btnUSERADD
            '
            Me.btnUSERADD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUSERADD.ForeColor = System.Drawing.Color.ForestGreen
            Me.btnUSERADD.Location = New System.Drawing.Point(576, 272)
            Me.btnUSERADD.Name = "btnUSERADD"
            Me.btnUSERADD.Size = New System.Drawing.Size(176, 32)
            Me.btnUSERADD.TabIndex = 6
            Me.btnUSERADD.Text = "Add New User"
            '
            'txtFullName
            '
            Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtFullName.Location = New System.Drawing.Point(80, 335)
            Me.txtFullName.Name = "txtFullName"
            Me.txtFullName.Size = New System.Drawing.Size(168, 20)
            Me.txtFullName.TabIndex = 5
            Me.txtFullName.Text = ""
            '
            'txtPassword
            '
            Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPassword.Location = New System.Drawing.Point(80, 311)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
            Me.txtPassword.Size = New System.Drawing.Size(168, 21)
            Me.txtPassword.TabIndex = 4
            Me.txtPassword.Text = ""
            '
            'txtName
            '
            Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtName.Location = New System.Drawing.Point(80, 287)
            Me.txtName.Name = "txtName"
            Me.txtName.Size = New System.Drawing.Size(168, 20)
            Me.txtName.TabIndex = 3
            Me.txtName.Text = ""
            '
            'lblFullName
            '
            Me.lblFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFullName.Location = New System.Drawing.Point(13, 335)
            Me.lblFullName.Name = "lblFullName"
            Me.lblFullName.Size = New System.Drawing.Size(64, 16)
            Me.lblFullName.TabIndex = 2
            Me.lblFullName.Text = "Full Name:"
            Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblPassword
            '
            Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPassword.Location = New System.Drawing.Point(13, 311)
            Me.lblPassword.Name = "lblPassword"
            Me.lblPassword.Size = New System.Drawing.Size(64, 16)
            Me.lblPassword.TabIndex = 1
            Me.lblPassword.Text = "Password:"
            Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblName.Location = New System.Drawing.Point(13, 287)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(64, 16)
            Me.lblName.TabIndex = 0
            Me.lblName.Text = "Name:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grpScreen
            '
            Me.grpScreen.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgScreen, Me.btnSCREENNEW, Me.txtSysName, Me.btnSCREENEDIT, Me.lblDesc, Me.lblSysName, Me.txtDescription, Me.btnSCREENADD, Me.btnSCREENDELETE})
            Me.grpScreen.Location = New System.Drawing.Point(8, 8)
            Me.grpScreen.Name = "grpScreen"
            Me.grpScreen.Size = New System.Drawing.Size(536, 360)
            Me.grpScreen.TabIndex = 3
            Me.grpScreen.TabStop = False
            Me.grpScreen.Text = "SCREEN"
            '
            'tdgScreen
            '
            Me.tdgScreen.AlternatingRows = True
            Me.tdgScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgScreen.FilterBar = True
            Me.tdgScreen.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgScreen.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.tdgScreen.Location = New System.Drawing.Point(8, 16)
            Me.tdgScreen.Name = "tdgScreen"
            Me.tdgScreen.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgScreen.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgScreen.PreviewInfo.ZoomFactor = 75
            Me.tdgScreen.Size = New System.Drawing.Size(520, 240)
            Me.tdgScreen.TabIndex = 10
            Me.tdgScreen.Text = "C1TrueDBGrid1"
            Me.tdgScreen.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;}HighlightRow{ForeColor:Hig" & _
            "hlightText;BackColor:Highlight;}Style14{}OddRow{}RecordSelector{AlignImage:Cente" & _
            "r;}Style15{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeCol" & _
            "or:ControlText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style" & _
            "12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name" & _
            "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
            "nFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelect" & _
            "orWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""" & _
            "1""><Height>238</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle" & _
            " parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Fil" & _
            "terBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""S" & _
            "tyle3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading" & _
            """ me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inactive" & _
            "Style parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /" & _
            "><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle pare" & _
            "nt=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, " & _
            "0, 518, 238</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderSty" & _
            "le></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""No" & _
            "rmal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer" & _
            """ /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive""" & _
            " /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><" & _
            "Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" />" & _
            "<Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector""" & _
            " /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" />" & _
            "</NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</" & _
            "Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 518, 238</Cl" & _
            "ientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle pa" & _
            "rent="""" me=""Style15"" /></Blob>"
            '
            'btnSCREENNEW
            '
            Me.btnSCREENNEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSCREENNEW.Location = New System.Drawing.Point(400, 264)
            Me.btnSCREENNEW.Name = "btnSCREENNEW"
            Me.btnSCREENNEW.Size = New System.Drawing.Size(48, 23)
            Me.btnSCREENNEW.TabIndex = 17
            Me.btnSCREENNEW.Text = "NEW"
            '
            'txtSysName
            '
            Me.txtSysName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtSysName.Location = New System.Drawing.Point(72, 296)
            Me.txtSysName.Name = "txtSysName"
            Me.txtSysName.Size = New System.Drawing.Size(304, 20)
            Me.txtSysName.TabIndex = 14
            Me.txtSysName.Text = ""
            '
            'btnSCREENEDIT
            '
            Me.btnSCREENEDIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSCREENEDIT.Location = New System.Drawing.Point(400, 296)
            Me.btnSCREENEDIT.Name = "btnSCREENEDIT"
            Me.btnSCREENEDIT.Size = New System.Drawing.Size(104, 23)
            Me.btnSCREENEDIT.TabIndex = 16
            Me.btnSCREENEDIT.Text = "EDIT"
            '
            'lblDesc
            '
            Me.lblDesc.Location = New System.Drawing.Point(8, 272)
            Me.lblDesc.Name = "lblDesc"
            Me.lblDesc.Size = New System.Drawing.Size(64, 16)
            Me.lblDesc.TabIndex = 11
            Me.lblDesc.Text = "Description:"
            Me.lblDesc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSysName
            '
            Me.lblSysName.Location = New System.Drawing.Point(8, 296)
            Me.lblSysName.Name = "lblSysName"
            Me.lblSysName.Size = New System.Drawing.Size(64, 16)
            Me.lblSysName.TabIndex = 12
            Me.lblSysName.Text = "SysName:"
            Me.lblSysName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDescription
            '
            Me.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtDescription.Location = New System.Drawing.Point(72, 272)
            Me.txtDescription.Name = "txtDescription"
            Me.txtDescription.Size = New System.Drawing.Size(304, 20)
            Me.txtDescription.TabIndex = 13
            Me.txtDescription.Text = ""
            '
            'btnSCREENADD
            '
            Me.btnSCREENADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSCREENADD.Location = New System.Drawing.Point(448, 264)
            Me.btnSCREENADD.Name = "btnSCREENADD"
            Me.btnSCREENADD.Size = New System.Drawing.Size(56, 23)
            Me.btnSCREENADD.TabIndex = 15
            Me.btnSCREENADD.Text = "ADD"
            '
            'btnSCREENDELETE
            '
            Me.btnSCREENDELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnSCREENDELETE.Location = New System.Drawing.Point(400, 328)
            Me.btnSCREENDELETE.Name = "btnSCREENDELETE"
            Me.btnSCREENDELETE.Size = New System.Drawing.Size(104, 23)
            Me.btnSCREENDELETE.TabIndex = 11
            Me.btnSCREENDELETE.Text = "DELETE"
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabUser, Me.tabGroup, Me.tabLevel, Me.tabDetail, Me.tabPermissions, Me.tabScreen})
            Me.TabControl1.Location = New System.Drawing.Point(16, 16)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(800, 512)
            Me.TabControl1.TabIndex = 4
            '
            'tabUser
            '
            Me.tabUser.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpUser})
            Me.tabUser.Location = New System.Drawing.Point(4, 22)
            Me.tabUser.Name = "tabUser"
            Me.tabUser.Size = New System.Drawing.Size(792, 486)
            Me.tabUser.TabIndex = 0
            Me.tabUser.Text = "User"
            '
            'tabGroup
            '
            Me.tabGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpGroup})
            Me.tabGroup.Location = New System.Drawing.Point(4, 22)
            Me.tabGroup.Name = "tabGroup"
            Me.tabGroup.Size = New System.Drawing.Size(792, 486)
            Me.tabGroup.TabIndex = 2
            Me.tabGroup.Text = "Group"
            '
            'grpGroup
            '
            Me.grpGroup.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGroupDeleteNew, Me.btnGroupEditNew, Me.btnGroupAddNew, Me.tdgGroup})
            Me.grpGroup.Location = New System.Drawing.Point(8, 8)
            Me.grpGroup.Name = "grpGroup"
            Me.grpGroup.Size = New System.Drawing.Size(360, 360)
            Me.grpGroup.TabIndex = 1
            Me.grpGroup.TabStop = False
            Me.grpGroup.Text = "GROUP"
            '
            'btnGroupDeleteNew
            '
            Me.btnGroupDeleteNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGroupDeleteNew.Location = New System.Drawing.Point(272, 80)
            Me.btnGroupDeleteNew.Name = "btnGroupDeleteNew"
            Me.btnGroupDeleteNew.TabIndex = 3
            Me.btnGroupDeleteNew.Text = "DELETE"
            '
            'btnGroupEditNew
            '
            Me.btnGroupEditNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGroupEditNew.Location = New System.Drawing.Point(272, 48)
            Me.btnGroupEditNew.Name = "btnGroupEditNew"
            Me.btnGroupEditNew.TabIndex = 2
            Me.btnGroupEditNew.Text = "EDIT"
            '
            'btnGroupAddNew
            '
            Me.btnGroupAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnGroupAddNew.Location = New System.Drawing.Point(272, 16)
            Me.btnGroupAddNew.Name = "btnGroupAddNew"
            Me.btnGroupAddNew.TabIndex = 1
            Me.btnGroupAddNew.Text = "ADD"
            '
            'tabLevel
            '
            Me.tabLevel.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpLevel})
            Me.tabLevel.Location = New System.Drawing.Point(4, 22)
            Me.tabLevel.Name = "tabLevel"
            Me.tabLevel.Size = New System.Drawing.Size(792, 486)
            Me.tabLevel.TabIndex = 3
            Me.tabLevel.Text = "Level"
            '
            'grpLevel
            '
            Me.grpLevel.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button4, Me.Button5, Me.Button6, Me.tdgLevel})
            Me.grpLevel.Location = New System.Drawing.Point(8, 8)
            Me.grpLevel.Name = "grpLevel"
            Me.grpLevel.Size = New System.Drawing.Size(360, 360)
            Me.grpLevel.TabIndex = 0
            Me.grpLevel.TabStop = False
            Me.grpLevel.Text = "LEVEL"
            '
            'Button4
            '
            Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button4.Location = New System.Drawing.Point(272, 80)
            Me.Button4.Name = "Button4"
            Me.Button4.TabIndex = 3
            Me.Button4.Text = "DELETE"
            '
            'Button5
            '
            Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button5.Location = New System.Drawing.Point(272, 48)
            Me.Button5.Name = "Button5"
            Me.Button5.TabIndex = 2
            Me.Button5.Text = "EDIT"
            '
            'Button6
            '
            Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.Button6.Location = New System.Drawing.Point(272, 16)
            Me.Button6.Name = "Button6"
            Me.Button6.TabIndex = 1
            Me.Button6.Text = "ADD"
            '
            'tabDetail
            '
            Me.tabDetail.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpUserDetail})
            Me.tabDetail.Location = New System.Drawing.Point(4, 22)
            Me.tabDetail.Name = "tabDetail"
            Me.tabDetail.Size = New System.Drawing.Size(792, 486)
            Me.tabDetail.TabIndex = 5
            Me.tabDetail.Text = "Detail"
            '
            'grpUserDetail
            '
            Me.grpUserDetail.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopy2Clipboard2, Me.btnCopy2Clipboard, Me.btnCopyToUser, Me.lblCopyToUser, Me.cboCopyToUser, Me.btnUnselectAll, Me.btnSelectAll, Me.btnUserDetailUpdate, Me.lstAvailableScreens, Me.lblDetailCurrent, Me.lstScreen, Me.lblDetailScreen, Me.lblDetailGroup, Me.chklstGroup, Me.lblUserName, Me.cboUserDetail})
            Me.grpUserDetail.Location = New System.Drawing.Point(8, 8)
            Me.grpUserDetail.Name = "grpUserDetail"
            Me.grpUserDetail.Size = New System.Drawing.Size(744, 421)
            Me.grpUserDetail.TabIndex = 6
            Me.grpUserDetail.TabStop = False
            Me.grpUserDetail.Text = "USER DETAIL"
            '
            'btnCopy2Clipboard2
            '
            Me.btnCopy2Clipboard2.Image = CType(resources.GetObject("btnCopy2Clipboard2.Image"), System.Drawing.Bitmap)
            Me.btnCopy2Clipboard2.Location = New System.Drawing.Point(248, 256)
            Me.btnCopy2Clipboard2.Name = "btnCopy2Clipboard2"
            Me.btnCopy2Clipboard2.Size = New System.Drawing.Size(32, 20)
            Me.btnCopy2Clipboard2.TabIndex = 15
            Me.ToolTip1.SetToolTip(Me.btnCopy2Clipboard2, "Copy the list to clipboard")
            '
            'btnCopy2Clipboard
            '
            Me.btnCopy2Clipboard.Image = CType(resources.GetObject("btnCopy2Clipboard.Image"), System.Drawing.Bitmap)
            Me.btnCopy2Clipboard.Location = New System.Drawing.Point(248, 56)
            Me.btnCopy2Clipboard.Name = "btnCopy2Clipboard"
            Me.btnCopy2Clipboard.Size = New System.Drawing.Size(32, 20)
            Me.btnCopy2Clipboard.TabIndex = 14
            Me.ToolTip1.SetToolTip(Me.btnCopy2Clipboard, "Copy the checked items to clipboard")
            '
            'btnCopyToUser
            '
            Me.btnCopyToUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyToUser.ForeColor = System.Drawing.Color.DarkOrange
            Me.btnCopyToUser.Location = New System.Drawing.Point(600, 200)
            Me.btnCopyToUser.Name = "btnCopyToUser"
            Me.btnCopyToUser.Size = New System.Drawing.Size(112, 32)
            Me.btnCopyToUser.TabIndex = 13
            Me.btnCopyToUser.Text = "Copy User"
            '
            'lblCopyToUser
            '
            Me.lblCopyToUser.Location = New System.Drawing.Point(416, 24)
            Me.lblCopyToUser.Name = "lblCopyToUser"
            Me.lblCopyToUser.Size = New System.Drawing.Size(80, 16)
            Me.lblCopyToUser.TabIndex = 12
            Me.lblCopyToUser.Text = "Copy To User:"
            '
            'cboCopyToUser
            '
            Me.cboCopyToUser.Location = New System.Drawing.Point(504, 24)
            Me.cboCopyToUser.Name = "cboCopyToUser"
            Me.cboCopyToUser.Size = New System.Drawing.Size(216, 21)
            Me.cboCopyToUser.TabIndex = 11
            '
            'btnUnselectAll
            '
            Me.btnUnselectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUnselectAll.ForeColor = System.Drawing.Color.ForestGreen
            Me.btnUnselectAll.Location = New System.Drawing.Point(600, 140)
            Me.btnUnselectAll.Name = "btnUnselectAll"
            Me.btnUnselectAll.Size = New System.Drawing.Size(112, 32)
            Me.btnUnselectAll.TabIndex = 10
            Me.btnUnselectAll.Text = "Unselect All"
            '
            'btnSelectAll
            '
            Me.btnSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSelectAll.ForeColor = System.Drawing.Color.ForestGreen
            Me.btnSelectAll.Location = New System.Drawing.Point(600, 80)
            Me.btnSelectAll.Name = "btnSelectAll"
            Me.btnSelectAll.Size = New System.Drawing.Size(112, 32)
            Me.btnSelectAll.TabIndex = 9
            Me.btnSelectAll.Text = "Select All"
            '
            'btnUserDetailUpdate
            '
            Me.btnUserDetailUpdate.Location = New System.Drawing.Point(368, 360)
            Me.btnUserDetailUpdate.Name = "btnUserDetailUpdate"
            Me.btnUserDetailUpdate.Size = New System.Drawing.Size(96, 32)
            Me.btnUserDetailUpdate.TabIndex = 8
            Me.btnUserDetailUpdate.Text = "UPDATE"
            '
            'lstAvailableScreens
            '
            Me.lstAvailableScreens.BackColor = System.Drawing.Color.LightGoldenrodYellow
            Me.lstAvailableScreens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstAvailableScreens.IntegralHeight = False
            Me.lstAvailableScreens.Location = New System.Drawing.Point(24, 280)
            Me.lstAvailableScreens.Name = "lstAvailableScreens"
            Me.lstAvailableScreens.Size = New System.Drawing.Size(256, 119)
            Me.lstAvailableScreens.TabIndex = 7
            '
            'lblDetailCurrent
            '
            Me.lblDetailCurrent.BackColor = System.Drawing.SystemColors.Control
            Me.lblDetailCurrent.Location = New System.Drawing.Point(24, 264)
            Me.lblDetailCurrent.Name = "lblDetailCurrent"
            Me.lblDetailCurrent.Size = New System.Drawing.Size(192, 16)
            Me.lblDetailCurrent.TabIndex = 6
            Me.lblDetailCurrent.Text = "SCREENS AVAILABLE FOR USER:"
            '
            'lstScreen
            '
            Me.lstScreen.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
            Me.lstScreen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lstScreen.IntegralHeight = False
            Me.lstScreen.Location = New System.Drawing.Point(312, 80)
            Me.lstScreen.Name = "lstScreen"
            Me.lstScreen.Size = New System.Drawing.Size(256, 152)
            Me.lstScreen.TabIndex = 5
            '
            'lblDetailScreen
            '
            Me.lblDetailScreen.Location = New System.Drawing.Point(312, 64)
            Me.lblDetailScreen.Name = "lblDetailScreen"
            Me.lblDetailScreen.Size = New System.Drawing.Size(200, 16)
            Me.lblDetailScreen.TabIndex = 4
            Me.lblDetailScreen.Text = "SCREENS FOR SELECTED GROUP"
            '
            'lblDetailGroup
            '
            Me.lblDetailGroup.Location = New System.Drawing.Point(24, 64)
            Me.lblDetailGroup.Name = "lblDetailGroup"
            Me.lblDetailGroup.Size = New System.Drawing.Size(100, 16)
            Me.lblDetailGroup.TabIndex = 3
            Me.lblDetailGroup.Text = "GROUP"
            '
            'chklstGroup
            '
            Me.chklstGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.chklstGroup.IntegralHeight = False
            Me.chklstGroup.Location = New System.Drawing.Point(24, 80)
            Me.chklstGroup.Name = "chklstGroup"
            Me.chklstGroup.Size = New System.Drawing.Size(256, 152)
            Me.chklstGroup.TabIndex = 2
            '
            'lblUserName
            '
            Me.lblUserName.Location = New System.Drawing.Point(24, 24)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(64, 16)
            Me.lblUserName.TabIndex = 1
            Me.lblUserName.Text = "User Name:"
            '
            'cboUserDetail
            '
            Me.cboUserDetail.Location = New System.Drawing.Point(104, 24)
            Me.cboUserDetail.Name = "cboUserDetail"
            Me.cboUserDetail.Size = New System.Drawing.Size(216, 21)
            Me.cboUserDetail.TabIndex = 0
            '
            'tabPermissions
            '
            Me.tabPermissions.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpPermissions})
            Me.tabPermissions.Location = New System.Drawing.Point(4, 22)
            Me.tabPermissions.Name = "tabPermissions"
            Me.tabPermissions.Size = New System.Drawing.Size(792, 486)
            Me.tabPermissions.TabIndex = 4
            Me.tabPermissions.Text = "Permissions"
            '
            'grpPermissions
            '
            Me.grpPermissions.Controls.AddRange(New System.Windows.Forms.Control() {Me.tdgPermissions, Me.cboLevel, Me.cboScreen, Me.cboGroup, Me.btnPERMNEW, Me.btnPERMDELETE, Me.btnPERMEDIT, Me.btnPERMADD, Me.lblLevel, Me.lblScreen, Me.lblGroup})
            Me.grpPermissions.Location = New System.Drawing.Point(8, 8)
            Me.grpPermissions.Name = "grpPermissions"
            Me.grpPermissions.Size = New System.Drawing.Size(536, 360)
            Me.grpPermissions.TabIndex = 11
            Me.grpPermissions.TabStop = False
            Me.grpPermissions.Text = "PERMISSIONS"
            '
            'tdgPermissions
            '
            Me.tdgPermissions.AlternatingRows = True
            Me.tdgPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.tdgPermissions.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
            Me.tdgPermissions.FilterBar = True
            Me.tdgPermissions.GroupByAreaVisible = False
            Me.tdgPermissions.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgPermissions.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.tdgPermissions.Location = New System.Drawing.Point(8, 16)
            Me.tdgPermissions.Name = "tdgPermissions"
            Me.tdgPermissions.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgPermissions.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgPermissions.PreviewInfo.ZoomFactor = 75
            Me.tdgPermissions.Size = New System.Drawing.Size(512, 240)
            Me.tdgPermissions.TabIndex = 14
            Me.tdgPermissions.Text = "C1TrueDBGrid1"
            Me.tdgPermissions.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style13{}EvenRow{BackColor:Aqua;}Selected{ForeColor:HighlightText;BackCol" & _
            "or:Highlight;}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeC" & _
            "olor:ControlText;BackColor:Control;}Inactive{ForeColor:InactiveCaptionText;BackC" & _
            "olor:InactiveCaption;}FilterBar{}OddRow{}Footer{}Caption{AlignHorz:Center;}Style" & _
            "25{}Normal{Font:Microsoft Sans Serif, 8.25pt;}Style26{}HighlightRow{ForeColor:Hi" & _
            "ghlightText;BackColor:Highlight;}Style24{}Style23{AlignHorz:Near;}Style22{}Style" & _
            "21{}Style20{}RecordSelector{AlignImage:Center;}Style18{}Style19{}Style2{}Style14" & _
            "{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGri" & _
            "d.GroupByView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptio" & _
            "nHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBo" & _
            "rder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" Horiz" & _
            "ontalScrollGroup=""1""><Height>238</Height><CaptionStyle parent=""Heading"" me=""Styl" & _
            "e23"" /><EditorStyle parent=""Editor"" me=""Style15"" /><EvenRowStyle parent=""EvenRow" & _
            """ me=""Style21"" /><FilterBarStyle parent=""FilterBar"" me=""Style26"" /><FooterStyle " & _
            "parent=""Footer"" me=""Style17"" /><GroupStyle parent=""Group"" me=""Style25"" /><Headin" & _
            "gStyle parent=""Heading"" me=""Style16"" /><HighLightRowStyle parent=""HighlightRow"" " & _
            "me=""Style20"" /><InactiveStyle parent=""Inactive"" me=""Style19"" /><OddRowStyle pare" & _
            "nt=""OddRow"" me=""Style22"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Styl" & _
            "e24"" /><SelectedStyle parent=""Selected"" me=""Style18"" /><Style parent=""Normal"" me" & _
            "=""Style14"" /><ClientRect>0, 0, 510, 238</ClientRect><BorderSide>0</BorderSide><B" & _
            "orderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.GroupByView></Splits><Named" & _
            "Styles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Sty" & _
            "le parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style " & _
            "parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style p" & _
            "arent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style p" & _
            "arent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent" & _
            "=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style " & _
            "parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplit" & _
            "s>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth>" & _
            "<ClientArea>0, 0, 510, 238</ClientArea><PrintPageHeaderStyle parent="""" me=""Style" & _
            "1"" /><PrintPageFooterStyle parent="""" me=""Style2"" /></Blob>"
            '
            'cboLevel
            '
            Me.cboLevel.Location = New System.Drawing.Point(72, 320)
            Me.cboLevel.Name = "cboLevel"
            Me.cboLevel.Size = New System.Drawing.Size(272, 21)
            Me.cboLevel.TabIndex = 13
            '
            'cboScreen
            '
            Me.cboScreen.Location = New System.Drawing.Point(72, 296)
            Me.cboScreen.Name = "cboScreen"
            Me.cboScreen.Size = New System.Drawing.Size(272, 21)
            Me.cboScreen.TabIndex = 12
            '
            'cboGroup
            '
            Me.cboGroup.Location = New System.Drawing.Point(72, 272)
            Me.cboGroup.Name = "cboGroup"
            Me.cboGroup.Size = New System.Drawing.Size(272, 21)
            Me.cboGroup.TabIndex = 11
            '
            'btnPERMNEW
            '
            Me.btnPERMNEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPERMNEW.Location = New System.Drawing.Point(360, 264)
            Me.btnPERMNEW.Name = "btnPERMNEW"
            Me.btnPERMNEW.Size = New System.Drawing.Size(48, 23)
            Me.btnPERMNEW.TabIndex = 10
            Me.btnPERMNEW.Text = "NEW"
            '
            'btnPERMDELETE
            '
            Me.btnPERMDELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPERMDELETE.Location = New System.Drawing.Point(360, 328)
            Me.btnPERMDELETE.Name = "btnPERMDELETE"
            Me.btnPERMDELETE.Size = New System.Drawing.Size(104, 23)
            Me.btnPERMDELETE.TabIndex = 8
            Me.btnPERMDELETE.Text = "DELETE"
            '
            'btnPERMEDIT
            '
            Me.btnPERMEDIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPERMEDIT.Location = New System.Drawing.Point(360, 296)
            Me.btnPERMEDIT.Name = "btnPERMEDIT"
            Me.btnPERMEDIT.Size = New System.Drawing.Size(104, 23)
            Me.btnPERMEDIT.TabIndex = 7
            Me.btnPERMEDIT.Text = "EDIT"
            '
            'btnPERMADD
            '
            Me.btnPERMADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnPERMADD.Location = New System.Drawing.Point(408, 264)
            Me.btnPERMADD.Name = "btnPERMADD"
            Me.btnPERMADD.Size = New System.Drawing.Size(56, 23)
            Me.btnPERMADD.TabIndex = 6
            Me.btnPERMADD.Text = "ADD"
            '
            'lblLevel
            '
            Me.lblLevel.Location = New System.Drawing.Point(8, 320)
            Me.lblLevel.Name = "lblLevel"
            Me.lblLevel.Size = New System.Drawing.Size(64, 16)
            Me.lblLevel.TabIndex = 2
            Me.lblLevel.Text = "Level:"
            Me.lblLevel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblScreen
            '
            Me.lblScreen.Location = New System.Drawing.Point(8, 296)
            Me.lblScreen.Name = "lblScreen"
            Me.lblScreen.Size = New System.Drawing.Size(64, 16)
            Me.lblScreen.TabIndex = 1
            Me.lblScreen.Text = "Screen:"
            Me.lblScreen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblGroup
            '
            Me.lblGroup.Location = New System.Drawing.Point(8, 272)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(64, 16)
            Me.lblGroup.TabIndex = 0
            Me.lblGroup.Text = "Group:"
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'tabScreen
            '
            Me.tabScreen.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpScreen})
            Me.tabScreen.Location = New System.Drawing.Point(4, 22)
            Me.tabScreen.Name = "tabScreen"
            Me.tabScreen.Size = New System.Drawing.Size(792, 486)
            Me.tabScreen.TabIndex = 1
            Me.tabScreen.Text = "Screen"
            '
            'SecurityAdmin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(848, 526)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "SecurityAdmin"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "SecurityAdmin"
            CType(Me.tdgLevel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tdgGroup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpUser.ResumeLayout(False)
            CType(Me.tdgUser, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpScreen.ResumeLayout(False)
            CType(Me.tdgScreen, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControl1.ResumeLayout(False)
            Me.tabUser.ResumeLayout(False)
            Me.tabGroup.ResumeLayout(False)
            Me.grpGroup.ResumeLayout(False)
            Me.tabLevel.ResumeLayout(False)
            Me.grpLevel.ResumeLayout(False)
            Me.tabDetail.ResumeLayout(False)
            Me.grpUserDetail.ResumeLayout(False)
            Me.tabPermissions.ResumeLayout(False)
            Me.grpPermissions.ResumeLayout(False)
            CType(Me.tdgPermissions, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabScreen.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Sub SecurityAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me._objSecAdmin = New Data.Buisness.SecurityAdmin()

            'Set Special permissions
            If ApplicationUser.GetPermission("AdminSecDelUsr") > 0 Then
                Me.btnDelete.Visible = True
            End If

            Me.btnSelectAll.Enabled = PSS.Core.Global.ApplicationUser.User.ToLower.Equals("pss admin")
            Me.btnUnselectAll.Enabled = Me.btnSelectAll.Enabled
            lblCopyToUser.Visible = Me.btnSelectAll.Enabled
            cboCopyToUser.Visible = Me.btnSelectAll.Enabled
            btnCopyToUser.Visible = Me.btnSelectAll.Enabled
            cboCopyToUser.Enabled = False
            btnCopyToUser.Enabled = False
            Me.lblPWBack.Visible = False

            loadElements()
        End Sub

        Private Sub loadElements()

            refreshUserDetail()

            Try
                tdgLevel.DataSource = Nothing
                tdgGroup.DataSource = Nothing
                tdgUser.DataSource = Nothing
                tdgScreen.DataSource = Nothing
                tdgPermissions.DataSource = Nothing
                cboUserDetail.Items.Clear()
                cboCopyToUser.Items.Clear()
                'cboShift.Text = ""
                cboShift.SelectedValue = 0
            Catch exp As Exception
                Throw exp
            End Try

            loadLevel()
            loadGroup()
            loadUser()
            loadScreen()
            loadPermissions()
            load_UserDetail()
            populateShifts()
            PopulateGroupSelects()
            'cboShift.Text = ""
            cboShift.SelectedValue = 0
            Me.cboGroupSelect.SelectedIndex = 0

            If PSS.Core.Global.ApplicationUser.NumberEmp = 57 Or PSS.Core.Global.ApplicationUser.NumberEmp = 71 Then
                TabControl1.TabPages(1).Visible = False
                TabControl1.TabPages(2).Visible = False
                TabControl1.TabPages(3).Visible = False
                TabControl1.TabPages(4).Visible = False
                TabControl1.TabPages(5).Visible = False
            End If

        End Sub

        Private Sub load_UserDetail()
            For xCount = 0 To dtUser.Rows.Count - 1
                r = dtUser.Rows(xCount)
                cboUserDetail.Items.Add(r("user_fullname"))
                cboCopyToUser.Items.Add(r("user_fullname"))
            Next
        End Sub





        Private Sub loadPermissions()

            dtPermissions = getPermissions()
            tdgPermissions.DataSource = dtPermissions
            tdgPermissions.Splits(0).DisplayColumns(0).Width = 0
            tdgPermissions.Splits(0).DisplayColumns(1).Width = tdgPermissions.Width / 3 - 44
            tdgPermissions.Splits(0).DisplayColumns(2).Width = tdgPermissions.Width / 3
            tdgPermissions.Splits(0).DisplayColumns(3).Width = tdgPermissions.Width / 3
            tdgPermissions.Splits(0).DisplayColumns(4).Width = 0
            tdgPermissions.Splits(0).DisplayColumns(5).Width = 0
            tdgPermissions.Splits(0).DisplayColumns(6).Width = 0
            tdgPermissions.Columns(1).Caption = "GROUP"
            tdgPermissions.Columns(2).Caption = "SCREEN"
            tdgPermissions.Columns(3).Caption = "LEVEL"

            LoadPermissions_cboBoxes()

        End Sub

        Private Sub LoadPermissions_cboBoxes()

            load_cboGroup()
            load_cboScreen()
            load_cboLevel()

        End Sub

        Private Sub load_cboGroup()

            Dim ctlGroup As New PSS.Data.Production.tgroup()
            'Commented out by Asif on 2/21/2006
            'Dim dtGroup As DataTable = ctlGroup.GetGroupList
            Dim dtGroup As DataTable = ctlGroup.GetGroupList(PSS.Core.Global.ApplicationUser.User)

            Try
                cboGroup.Items.Clear()
            Catch exp As Exception
            End Try
            For xCount = 0 To dtGroup.Rows.Count - 1
                r = dtGroup.Rows(xCount)
                cboGroup.Items.Add(r("group_desc"))
            Next
            dtGroup = Nothing
            ctlGroup = Nothing

        End Sub

        Private Sub load_cboScreen()

            Dim ctlScreen As New PSS.Data.Production.tscreen()
            Dim dtScreen As DataTable = ctlScreen.GetScreenList
            Try
                cboScreen.Items.Clear()
            Catch exp As Exception
            End Try
            For xCount = 0 To dtScreen.Rows.Count - 1
                r = dtScreen.Rows(xCount)
                cboScreen.Items.Add(r("screen_desc"))
            Next
            dtScreen = Nothing
            ctlScreen = Nothing

        End Sub

        Private Sub load_cboLevel()

            Dim ctlLevel As New PSS.Data.Production.llevel()
            Dim dtLevel As DataTable = ctlLevel.GetLevelList
            Try
                cboLevel.Items.Clear()
            Catch exp As Exception
            End Try
            For xCount = 0 To dtLevel.Rows.Count - 1
                r = dtLevel.Rows(xCount)
                cboLevel.Items.Add(r("level_desc"))
            Next
            dtLevel = Nothing
            ctlLevel = Nothing

        End Sub

        Private Function getPermissions() As DataTable

            Dim ctlPermissions As New PSS.Data.Production.tpermissions()
            getPermissions = ctlPermissions.GetPermissionsList

            ctlPermissions = Nothing

        End Function

        Private Sub tdgPermissions_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgPermissions.MouseUp

            LoadPermissions_cboBoxes()

            cboGroup.Text = ""
            cboScreen.Text = ""
            cboLevel.Text = ""
            valPID = tdgPermissions.Columns(0).Value()

            If IsDBNull(tdgPermissions.Columns(1).Value) = False Then
                cboGroup.Text = tdgPermissions.Columns(1).Value
            End If

            If IsDBNull(tdgPermissions.Columns(2).Value) = False Then
                cboScreen.Text = tdgPermissions.Columns(2).Value
            End If

            If IsDBNull(tdgPermissions.Columns(3).Value) = False Then
                cboLevel.Text = tdgPermissions.Columns(3).Value
            End If

        End Sub





        Private Function deletePermissions(ByVal valID) As Boolean

            deletePermissions = False

            If Len(Trim(valID)) < 1 Then
                MsgBox("please define a value for deletion. Delete cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            Else
                Dim response As String = MsgBox("You are about to delete permission : " & tdgPermissions.Columns(1).Value & ", " & tdgPermissions.Columns(2).Value & ", " & tdgPermissions.Columns(3).Value & ". Continue with delete", MsgBoxStyle.YesNo, "Continue?")
                Select Case response
                    Case vbYes
                        If Trim(valID) > 1 Then
                            Dim ctlPermissions As New PSS.Data.Production.tpermissions()
                            deletePermissions = ctlPermissions.DeletePermissions(Trim(valID))
                        End If
                    Case vbNo
                        Exit Function
                End Select
            End If

            LoadPermissions_cboBoxes()

            cboGroup.Text = ""
            cboScreen.Text = ""
            cboLevel.Text = ""

            '//Reload Level Grid
            Try
                loadPermissions()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function insertPermissions() As Boolean

            insertPermissions = False

            Dim ctlPermissions As New PSS.Data.Production.tpermissions()

            '        Dim tmpDesc As String = InputBox("Please enter a description for the new user", "Add Group")
            '//Verify that all textboxes have values
            Dim blnGroup As Boolean = False
            Dim blnScreen As Boolean = False
            Dim blnLevel As Boolean = False

            If Len(Trim(cboGroup.Text)) > 0 Then blnGroup = True
            If Len(Trim(cboScreen.Text)) > 0 Then blnScreen = True
            If Len(Trim(cboLevel.Text)) > 0 Then blnLevel = True
            If blnGroup = False Or blnScreen = False Or blnLevel = False Then
                MsgBox("Please enter values into all fields before continuing.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            End If

            '//Translate fields
            Dim intGroup As Int32 = 0
            Dim intScreen As Int32 = 0
            Dim intLevel As Int32 = 0

            For xCount = 0 To dtGroup.Rows.Count - 1
                r = dtGroup.Rows(xCount)
                If Trim(r("Group_Desc")) = Trim(cboGroup.Text) Then
                    intGroup = r("Group_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dtScreen.Rows.Count - 1
                r = dtScreen.Rows(xCount)
                If Trim(r("Screen_Desc")) = Trim(cboScreen.Text) Then
                    intScreen = r("Screen_ID")
                    Exit For
                End If
            Next

            For xCount = 0 To dtLevel.Rows.Count - 1
                r = dtLevel.Rows(xCount)
                If Trim(r("Level_Desc")) = Trim(cboLevel.Text) Then
                    intLevel = r("Level_ID")
                    Exit For
                End If
            Next

            If intGroup < 1 Or intScreen < 1 Or intLevel < 1 Then
                MsgBox("Fields could not be validated. Insert aborted.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            End If

            '//Check for duplicate
            Dim blnDup As Boolean = False

            For xCount = 0 To dtPermissions.Rows.Count - 1
                r = dtPermissions.Rows(xCount)
                If Trim(intGroup) = Trim(r("group_ID")) Then
                    If Trim(intScreen) = Trim(r("screen_ID")) Then
                        If Trim(intLevel) = Trim(r("level_ID")) Then
                            blnDup = True
                            '//Throw error because descriptions can not be duplicated
                            MsgBox("You already have a permission defined like this. Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                            Exit Function
                        End If
                    End If
                End If
            Next

            If blnDup = False Then
                '//Add record to database
                Try
                    Dim blnInsert As Boolean = ctlPermissions.InsertPermissions(intGroup, intScreen, intLevel)
                    insertPermissions = True
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            LoadPermissions_cboBoxes()

            cboGroup.Text = ""
            cboScreen.Text = ""
            cboLevel.Text = ""

            '//Reload Level Grid
            Try
                loadPermissions()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function editPermissions(ByVal valID, ByVal valGroup, ByVal valScreen, ByVal valLevel) As Boolean

            editPermissions = False

            Dim ctlPermissions As New PSS.Data.Production.tpermissions()

            '//Verify that all textboxes have values
            Dim blnGroup As Boolean = False
            Dim blnScreen As Boolean = False
            Dim blnLevel As Boolean = False

            If Len(Trim(cboGroup.Text)) > 0 Then blnGroup = True
            If Len(Trim(cboScreen.Text)) > 0 Then blnScreen = True
            If Len(Trim(cboLevel.Text)) > 0 Then blnLevel = True
            If blnGroup = False Or blnScreen = False Or blnLevel = False Then
                MsgBox("Please enter values into all fields before continuing.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            End If

            Dim blnDup As Boolean = False

            For xCount = 0 To dtPermissions.Rows.Count - 1
                r = dtPermissions.Rows(xCount)
                If Trim(cboGroup.Text) = Trim(r("group_desc")) Then
                    If Trim(cboScreen.Text) = Trim(r("screen_desc")) Then
                        If Trim(cboLevel.Text) = Trim(r("level_desc")) Then
                            blnDup = True
                            '//Throw error because descriptions can not be duplicated
                            MsgBox("You already have a permission defined like this. Edit cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                            Exit Function
                        End If
                    End If
                End If

            Next

            If blnDup = False Then
                '//Add record to database
                Try
                    Dim blnEdit As Boolean = ctlPermissions.EditPermissions(valID, Trim(cboGroup.Text), Trim(cboScreen.Text), Trim(cboLevel.Text))
                    editPermissions = True
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            LoadPermissions_cboBoxes()

            cboGroup.Text = ""
            cboScreen.Text = ""
            cboLevel.Text = ""
            valPID = 0

            '//Reload Level Grid
            Try
                loadPermissions()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function





        Private Sub btnPERMNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPERMNEW.Click

            LoadPermissions_cboBoxes()

            cboGroup.Text = ""
            cboScreen.Text = ""
            cboLevel.Text = ""
            cboGroup.Focus()

        End Sub

        Private Sub btnPERMADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPERMADD.Click

            Dim addTrans As Boolean = insertPermissions()

            If addTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnPERMEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPERMEDIT.Click

            '//Get value for edit
            Dim tmpID As Int32 = tdgPermissions.Columns(0).Value
            Dim tmpDescOLD As String = tdgPermissions.Columns(1).Value

            Dim editTrans As Boolean = editPermissions(valPID, Trim(cboGroup.Text), Trim(cboScreen.Text), Trim(cboLevel.Text))

            If editTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnPERMDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPERMDELETE.Click

            '//Get value for deletion
            Dim tmpID As Int32 = tdgPermissions.Columns(0).Value

            Dim delTrans As Boolean = deletePermissions(tmpID)

            If delTrans = False Then
                'MsgBox("An error has occurred while deleting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

        End Sub









        Private Sub loadUser()

            dtUser = getUser()
            tdgUser.DataSource = dtUser
            tdgUser.Splits(0).DisplayColumns(0).Width = 0
            tdgUser.Splits(0).DisplayColumns(1).Width = tdgUser.Width / 4 - 44
            tdgUser.Splits(0).DisplayColumns(2).Width = tdgUser.Width / 6
            tdgUser.Splits(0).DisplayColumns(3).Width = tdgUser.Width / 6

            tdgUser.Splits(0).DisplayColumns(4).Width = 75
            tdgUser.Splits(0).DisplayColumns(5).Width = 60
            tdgUser.Splits(0).DisplayColumns(6).Width = 50
            tdgUser.Splits(0).DisplayColumns(7).Width = 60
            tdgUser.Splits(0).DisplayColumns(8).Width = 60
            tdgUser.Splits(0).DisplayColumns(9).Width = 60

            tdgUser.Columns(1).Caption = "USER NAME"
            tdgUser.Columns(2).Caption = "PASSWORD"
            tdgUser.Columns(3).Caption = "FULL NAME"
            tdgUser.Columns(6).Caption = "TECH ID"
            tdgUser.Columns(7).Caption = "SHIFT"
            tdgUser.Columns(8).Caption = "REFURBER"
            tdgUser.Columns(9).Caption = "INACTIVE"

            'Hide the password column
            tdgUser.Splits(0).DisplayColumns(2).Visible = False
            tdgUser.Splits(0).DisplayColumns("TechRate").Visible = False

        End Sub

        Private Function getUser() As DataTable

            Dim ctlUser As New PSS.Data.Production.tusers()
            'getUser = ctlUser.GetUserList()    'Commented out by Asif on 02/17/2006
            getUser = ctlUser.GetUserList(PSS.Core.Global.ApplicationUser.User)

            ctlUser = Nothing

        End Function

        Private Sub tdgUser_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgUser.MouseUp
            Dim iIndex As Integer
            Dim iSelectionIndex As Integer = -1

            Try
                txtName.Text = ""
                txtPassword.Text = ""
            txtFullName.Text = ""
            'cboShift.Text = ""
            cboShift.SelectedValue = 0
            Me.cboGroupSelect.SelectedIndex = 0
            chkInactive.Checked = False
            '*****************************
            'Added by Asif on 10-26-2005
            Me.txtEmpNo.Text = ""
            Me.txtTechID.Text = ""
            Me.txtQCNo.Text = ""
            Me.chkExempt.Checked = False
            Me.chkOT.Checked = False
            Me.chkClearMachine.Checked = False
            '*****************************

            valUID = tdgUser.Columns("user_id").Value()

            If IsDBNull(tdgUser.Columns("USER NAME").Value) = False Then
                txtName.Text = tdgUser.Columns("USER NAME").Value
            End If

            If IsDBNull(tdgUser.Columns("PASSWORD").Value) = False Then
                    txtPassword.Text = tdgUser.Columns("PASSWORD").Value
                    lblPWBack.Text = txtPassword.Text
            End If

            If IsDBNull(tdgUser.Columns("FULL NAME").Value) = False Then
                txtFullName.Text = tdgUser.Columns("FULL NAME").Value
            End If

            '**************************************************
            'Added by Asif on 10-26-2005
            If IsDBNull(tdgUser.Columns("EmployeeNo").Value) = False Then
                Me.txtEmpNo.Text = tdgUser.Columns("EmployeeNo").Value
            End If

            If IsDBNull(tdgUser.Columns("QCStamp").Value) = False Then
                Me.txtQCNo.Text = tdgUser.Columns("QCStamp").Value
            End If

            If IsDBNull(tdgUser.Columns("TECH ID").Value) = False Then
                Me.txtTechID.Text = tdgUser.Columns("TECH ID").Value
            End If

            If IsDBNull(tdgUser.Columns("FULL NAME").Value) = False Then
                txtFullName.Text = tdgUser.Columns("FULL NAME").Value
            End If

            If tdgUser.Columns("ExemptFlag").Value = 1 Then
                Me.chkExempt.Checked = True
            Else
                Me.chkExempt.Checked = False
            End If

            If tdgUser.Columns("OTFlag").Value = 1 Then
                Me.chkOT.Checked = True
            Else
                Me.chkOT.Checked = False
            End If

            If tdgUser.Columns("AccountLockOut_PwAttempted_id").Value > 0 Then
                Me.chkLockout.Checked = True
            Else
                Me.chkLockout.Checked = False
            End If

            '**************************************************
            If Not IsDBNull(tdgUser.Columns("SHIFT").Value) Then
                Me.cboShift.SelectedValue = CInt(tdgUser.Columns("SHIFT").Value)
            Else
                Me.cboShift.SelectedValue = 0
            End If

            If tdgUser.Columns("INACTIVE").Value = 1 Then
                chkInactive.Checked = True
            Else
                chkInactive.Checked = False
            End If
            If tdgUser.Columns("REFURBER").Value = 1 Then
                Me.chkRefurber.Checked = True
            Else
                Me.chkRefurber.Checked = False
            End If

            If tdgUser.Columns("Group Description").Value.Trim.Length > 0 Then
                If Me.cboGroupSelect.Items.Count > 0 Then
                    For iIndex = 0 To Me.cboGroupSelect.Items.Count - 1
                        If Me.cboGroupSelect.Items(iIndex)("Group_ID") = tdgUser.Columns("group_id").Value Then
                            iSelectionIndex = iIndex

                            Exit For
                        End If
                    Next
                End If

                Me.cboGroupSelect.SelectedIndex = iSelectionIndex
            Else
                Me.cboGroupSelect.SelectedIndex = -1
            End If

            cboUserDetail.Text = tdgUser.Columns("FULL NAME").Value

            Catch ex As Exception
            End Try
        End Sub




        Private Function deleteUser(ByVal valID) As Boolean

            deleteUser = False

            If Len(Trim(valID)) < 1 Then
                MsgBox("please define a value for deletion. Delete cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            Else
                Dim response As String = MsgBox("You are about to delete user : " & tdgUser.Columns(3).Value & ". Continue with delete", MsgBoxStyle.YesNo, "Continue?")
                Select Case response
                    Case vbYes
                        If Trim(valID) > 1 Then
                            Dim ctlUser As New PSS.Data.Production.tusers()
                            deleteUser = ctlUser.DeleteUser(Trim(valID))
                        End If
                    Case vbNo
                        Exit Function
                End Select
            End If

            txtName.Text = ""
            txtPassword.Text = ""
            txtFullName.Text = ""

            '*****************************
            'Added by Asif on 10-26-2005
            Me.txtEmpNo.Text = ""
            Me.txtTechID.Text = ""
            Me.txtQCNo.Text = ""
            '*****************************
            '//Reload Level Grid
            Try
                loadUser()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function insertUser() As Boolean
            Dim objSecurity As New PSS.Data.Buisness.Security()

            insertUser = False

            Dim ctlUser As New PSS.Data.Production.tusers()

            '        Dim tmpDesc As String = InputBox("Please enter a description for the new user", "Add Group")

            Dim blnName As Boolean = False
            Dim blnPass As Boolean = False
            Dim blnFName As Boolean = False
            Dim blnShift As Boolean = False

            Try
                'Check very neccessary data
                If Trim(Me.txtName.Text).Length = 0 OrElse Trim(Me.txtFullName.Text).Length = 0 _
                   OrElse Trim(Me.txtPassword.Text).Length = 0 Then
                    MsgBox("Please enter name, password data.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Function
                End If

                'Check name exist
                If objSecurity.IsUserExist(Trim(Me.txtName.Text)) Then
                    MessageBox.Show("This user exists in the system. Can't add.", "InsertUser", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Function
                End If

                'VALIDATE PASSWORD
                If Not ValidPassword(0, Trim(Me.txtPassword.Text), False) Then
                    Exit Function
                End If


                If Len(Trim(txtName.Text)) > 0 Then blnName = True
                If Len(Trim(txtPassword.Text)) > 0 Then blnPass = True
                If Len(Trim(txtFullName.Text)) > 0 Then blnFName = True
                'If Len(Trim(cboShift.Text)) > 0 Then blnShift = True
                If Me.cboShift.SelectedValue > 0 Then blnShift = True

                'Added by Asif on 10-26-2005
                Dim blnEmpNo As Boolean = False
                Dim blnTechID As Boolean = False
                Dim blnQCStampID As Boolean = False
                If Len(Trim(Me.txtEmpNo.Text)) > 0 Then blnEmpNo = True
                If Len(Trim(Me.txtTechID.Text)) > 0 Then blnTechID = True
                If Len(Trim(Me.txtQCNo.Text)) > 0 Then blnQCStampID = True

                If blnName = False Or blnPass = False Or blnFName = False Or blnEmpNo = False Then
                    MsgBox("Please enter values into all fields before continuing.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Function
                End If

                '//Check for duplicate
                Dim blnDup As Boolean = False

                For xCount = 0 To dtUser.Rows.Count - 1
                    r = dtUser.Rows(xCount)
                    'If Trim(blnName) = Trim(r("user_name")) Then       'Commented by Asif on 10-26-2005
                    If Trim(txtName.Text) = Trim(r("user_name")) Then
                        blnDup = True
                        '//Throw error because descriptions can not be duplicated
                        MsgBox("You already have a user defined with this description. Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Function
                    End If
                    '*************************************
                    'Added by Asif on 10-26-2005
                    If Not IsDBNull(r("employeeno")) Then
                        If Trim(Me.txtEmpNo.Text) = Trim(r("employeeno")) Then
                            blnDup = True
                            '//Throw error because Employee No. can not be duplicated
                            MsgBox("This Employee No. is already assigned to " & Trim(r("user_name")) & ". Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                            Exit Function
                        End If
                    End If

                    If Not IsDBNull(r("tech_id")) Then
                        If blnTechID = True Then
                            If Trim(Me.txtTechID.Text) = r("tech_id") Then
                                blnDup = True
                                '//Throw error because Employee No. can not be duplicated
                                MsgBox("This Tech ID is already assigned to " & Trim(r("user_name")) & ". Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                                Exit Function
                            End If
                        End If
                    End If
                    If Not IsDBNull(r("QCStamp")) Then
                        If blnQCStampID = True Then
                            If Trim(Me.txtQCNo.Text) = r("QCStamp") Then
                                blnDup = True
                                '//Throw error because Employee No. can not be duplicated
                                MsgBox("This QC Stamp ID is already assigned to " & Trim(r("user_name")) & ". Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                                Exit Function
                            End If
                        End If
                    End If

                    '*************************************
                Next

                If Trim(Me.txtTechID.Text) = "" Then
                    Me.txtTechID.Text = 0
                End If

                If Trim(Me.txtQCNo.Text) = "" Then
                    Me.txtQCNo.Text = 0
                End If

                Dim mInactive As Integer
                If Me.chkInactive.Checked = True Then
                    mInactive = 1
                Else
                    mInactive = 0
                End If

                Dim iRefurber As Integer
                If Me.chkRefurber.Checked = True Then
                    iRefurber = 1
                Else
                    iRefurber = 0
                End If

                Dim iExempt As Integer = 0
                If Me.chkExempt.Checked = True Then
                    iExempt = 1
                Else
                    iExempt = 0
                End If

                Dim iOT As Integer = 0
                If Me.chkOT.Checked = True Then
                    iOT = 1
                Else
                    iOT = 0
                End If

                Dim iLockout As Integer
                If Me.chkLockout.Checked Then
                    iLockout = 1
                Else
                    iLockout = 0
                End If

                'Check if a Shift is selected for non-exempt employee
                If iExempt = 0 Then     'Non-exempt
                    If Me.cboShift.SelectedValue = 0 Then
                        MessageBox.Show("A shift must be selected for this user.", "Select Shift", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Function
                    End If
                End If

                If blnDup = False Then
                    '//Add record to database
                    Try
                        Dim iUserID As Integer = 0

                        Dim blnInsert As Boolean = ctlUser.InsertUser(Trim(txtName.Text), _
                                                    Trim(txtPassword.Text), _
                                                    Trim(txtFullName.Text), _
                                                    Trim(Me.txtEmpNo.Text), _
                                                    Trim(Me.txtTechID.Text), _
                                                    Trim(Me.txtQCNo.Text), _
                                                    Me.cboShift.SelectedValue, _
                                                    mInactive, _
                                                    iExempt, _
                                                    iOT, _
                                                    iRefurber, _
                                                    iLockout, _
                                                    iUserID)
                        insertUser = True

                        If iUserID > 0 Then
                            objSecurity.SavePasswordAndPWLog(iUserID, Trim(txtPassword.Text))
                        End If

                    Catch exp As Exception
                        MsgBox(exp.ToString)
                    End Try
                End If

                txtName.Text = ""
                txtPassword.Text = ""
                txtFullName.Text = ""
                Me.txtEmpNo.Text = ""
                Me.txtTechID.Text = ""
                Me.txtQCNo.Text = ""
                '*****************************
                '//Reload Level Grid
                Try
                    loadUser()
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try


            Catch ex As Exception
                MessageBox.Show(ex.Message, "InsertUser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objSecurity = Nothing
            End Try
        End Function

        Private Function editUser(ByVal valID As Integer, _
                                ByVal valName As String, _
                                ByVal valPass As String, _
                                ByVal valFName As String, _
                                ByVal vShift As Integer, _
                                ByVal iGroup As Integer, _
                                ByVal vInactive As Integer, _
                                ByVal iExempt As Integer, _
                                ByVal iClearMachine As Integer, _
                                ByVal iOT As Integer, _
                                ByVal iRefurber As Integer, _
                                ByVal iLockout As Integer) As Boolean

            editUser = False

            Dim ctlUser As New PSS.Data.Production.tusers()
            '        Dim tmpDesc As String = InputBox("Please modify the description for this group", "Edit Group", tmpDescOLD)

            '//Verify that all textboxes have values
            Dim blnName As Boolean = False
            Dim blnPass As Boolean = False
            Dim blnFName As Boolean = False
            Dim blnShift As Boolean = False

            Dim sf As New StackFrame(0)

            If Len(Trim(txtName.Text)) > 0 Then blnName = True
            If Len(Trim(txtPassword.Text)) > 0 Then blnPass = True
            If Len(Trim(txtFullName.Text)) > 0 Then blnFName = True
            'If Len(Trim(cboShift.Text)) > 0 Then blnShift = True
            If Me.cboShift.SelectedValue > 0 Then blnShift = True

            'Added by Asif on 10-26-2005
            Dim blnEmpNo As Boolean = False
            Dim blnTechID As Boolean = False
            Dim blnQCStampID As Boolean = False
            If Len(Trim(Me.txtEmpNo.Text)) > 0 Then blnEmpNo = True
            If Len(Trim(Me.txtTechID.Text)) > 0 Then blnTechID = True
            If Len(Trim(Me.txtQCNo.Text)) > 0 Then blnQCStampID = True

            If blnName = False Or blnPass = False Or blnFName = False Or blnEmpNo = False Then
                MsgBox("Please enter values into all fields before continuing.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            End If

            Dim blnDup As Boolean = False

            'For xCount = 0 To dtLevel.Rows.Count - 1       'commented out by Asif on 10-26-2005
            For xCount = 0 To dtUser.Rows.Count - 1
                r = dtUser.Rows(xCount)

                If valID <> r("user_id") Then


                    If Trim(txtName.Text) = Trim(r("user_name")) Then
                        blnDup = True
                        '//Throw error because descriptions can not be duplicated
                        MsgBox("You already have a user defined with this description. Edit cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Function
                    End If

                    '*************************************
                    'Added by Asif on 10-26-2005
                    If Not IsDBNull(r("employeeno")) Then
                        If Trim(Me.txtEmpNo.Text) = Trim(r("employeeno")) Then
                            blnDup = True
                            '//Throw error because Employee No. can not be duplicated
                            MsgBox("This Employee No. is already assigned to " & Trim(r("user_name")) & ". Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                            Exit Function
                        End If
                    End If

                    If Not IsDBNull(r("tech_id")) Then
                        If blnTechID = True Then
                            If Trim(Me.txtTechID.Text) = r("tech_id") Then
                                blnDup = True
                                '//Throw error because Employee No. can not be duplicated
                                MsgBox("This Tech ID is already assigned to " & Trim(r("user_name")) & ". Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                                Exit Function
                            End If
                        End If
                    End If
                    If Not IsDBNull(r("QCStamp")) Then
                        If blnQCStampID = True Then
                            If Trim(Me.txtQCNo.Text) = r("QCStamp") Then
                                blnDup = True
                                '//Throw error because Employee No. can not be duplicated
                                MsgBox("This QC Stamp No is already assigned to " & Trim(r("user_name")) & ". Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                                Exit Function
                            End If
                        End If
                    End If
                End If
            Next

            If Trim(Me.txtTechID.Text) = "" Then
                Me.txtTechID.Text = 0
            End If

            If Trim(Me.txtQCNo.Text) = "" Then
                Me.txtQCNo.Text = 0
            End If

            'Check if a Shift is selected for non-exempt employee
            If iExempt = 0 Then     'Non-exempt
                If Me.cboShift.SelectedValue = 0 Then
                    MessageBox.Show("A shift must be selected for this user.", "Select Shift", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Function
                End If
            End If

            If Me.cboGroupSelect.SelectedIndex = -1 Then
                Me._objSecAdmin.DisplayMessage(sf.GetMethod, "A group must be selected for this user.", False)

                Exit Function
            End If

            If blnDup = False Then
                '//Add record to database
                Try
                    'Dim blnEdit As Boolean = ctlUser.EditUser(valID, Trim(txtName.Text), Trim(txtPassword.Text), Trim(txtFullName.Text))
                    Dim blnEdit As Boolean = ctlUser.EditUser(valID, Trim(txtName.Text), _
                                             Trim(txtPassword.Text), Trim(txtFullName.Text), _
                                             Trim(Me.txtEmpNo.Text), Trim(Me.txtTechID.Text), _
                                             Trim(Me.txtQCNo.Text), cboShift.SelectedValue, _
                                             Me.cboGroupSelect.SelectedValue, vInactive, _
                                             iExempt, iClearMachine, iOT, iRefurber, iLockout)
                    editUser = True

                    If Trim(Me.txtPassword.Text) <> Trim(Me.lblPWBack.Text) Then
                        Dim objSecurity As New PSS.Data.Buisness.Security()
                        objSecurity.SavePasswordAndPWLog(valID, Trim(txtPassword.Text))
                        objSecurity = Nothing
                    End If

                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            txtName.Text = ""
            txtPassword.Text = ""
            txtFullName.Text = ""
            'cboShift.Text = ""
            Me.cboShift.SelectedValue = 0
            Me.cboGroupSelect.SelectedIndex = 0
            valUID = 0
            '*****************************
            'Added by Asif on 10-26-2005
            Me.txtEmpNo.Text = ""
            Me.txtTechID.Text = ""
            Me.txtQCNo.Text = ""
            Me.lblPWBack.Text = ""
            Me.chkExempt.Checked = False
            Me.chkOT.Checked = False
            Me.chkInactive.Checked = False
            Me.chkRefurber.Checked = False
            Me.chkClearMachine.Checked = False
            Me.chkLockout.Checked = False
            '*****************************

            '//Reload Level Grid
            Try
                loadUser()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function





        Private Sub btnUSERADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSERADD.Click

            Dim addTrans As Boolean = insertUser()

            If addTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnUSEREDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSEREDIT.Click

            If valUID = 0 OrElse txtName.Text.Trim.Length = 0 Then
                Exit Sub
            End If

            'Validate Passward rule
            If Trim(Me.txtPassword.Text) = Trim(Me.lblPWBack.Text) Then
                If Not ValidPassword(valUID, Trim(Me.txtPassword.Text), False) Then
                    Exit Sub
                End If
            Else
                If Not ValidPassword(valUID, Trim(Me.txtPassword.Text), True) Then
                    Exit Sub
                End If
            End If


            '//Get value for edit
            Dim tmpID As Int32 = tdgUser.Columns(0).Value
            Dim tmpDescOLD As String = tdgUser.Columns(1).Value

            Dim mInactive As Integer
            If chkInactive.Checked = True Then
                mInactive = 1
            Else
                mInactive = 0
            End If
            Dim iRefurber As Integer
            If chkRefurber.Checked = True Then
                iRefurber = 1
            Else
                iRefurber = 0
            End If

            Dim iExempt As Integer = 0
            If chkExempt.Checked = True Then
                iExempt = 1
            Else
                iExempt = 0
            End If

            Dim iOT As Integer = 0
            If Me.chkOT.Checked = True Then
                iOT = 1
            Else
                iOT = 0
            End If

            Dim iClearMachine As Integer = 0
            If chkClearMachine.Checked = True Then
                iClearMachine = 1
            Else
                iClearMachine = 0
            End If

            Dim iLockout As Integer
            If chkLockout.Checked Then
                iLockout = 1
            Else
                iLockout = 0
            End If

            Dim editTrans As Boolean = editUser(valUID, _
                                        Trim(txtName.Text), _
                                        Trim(txtPassword.Text), _
                                        Trim(txtFullName.Text), _
                                        Trim(cboShift.SelectedValue), _
                                        Me.cboGroupSelect.SelectedValue, _
                                        mInactive, _
                                        iExempt, _
                                        iClearMachine, _
                                        iOT, _
                                        iRefurber, _
                                        iLockout)

            If editTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnUSERDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSERDELETE.Click

            '//Get value for deletion
            Dim tmpID As Int32 = tdgUser.Columns(0).Value

            Dim delTrans As Boolean = deleteUser(tmpID)

            If delTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

        End Sub

        Private Sub btnUSERNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSERNEW.Click
            'MsgBox(PSS.Core.Global.ApplicationUser.User)

            txtName.Text = ""
            txtPassword.Text = ""
            txtFullName.Text = ""
            'cboShift.Text = ""
            Me.cboShift.SelectedValue = 0
            Me.cboGroupSelect.SelectedIndex = 0
            '*****************************
            'Added by Asif on 10-26-2005
            Me.txtEmpNo.Text = ""
            Me.txtTechID.Text = ""
            Me.txtQCNo.Text = ""
            Me.lblPWBack.Text = ""
            valUID = 0
            Me.chkExempt.Checked = False
            Me.chkOT.Checked = False
            Me.chkInactive.Checked = False
            Me.chkRefurber.Checked = False
            Me.chkClearMachine.Checked = False
            Me.chkLockout.Checked = False
            '*****************************
            txtName.Focus()

        End Sub






        Private Sub loadScreen()

            dtScreen = getScreen()
            tdgScreen.DataSource = dtScreen
            tdgScreen.Splits(0).DisplayColumns(0).Width = 0
            tdgScreen.Splits(0).DisplayColumns(1).Width = tdgScreen.Width / 2 - 44
            tdgScreen.Splits(0).DisplayColumns(2).Width = tdgUser.Width / 2
            tdgScreen.Columns(1).Caption = "SCREEN DESCRIPTION"
            tdgScreen.Columns(2).Caption = "SYSNAME"

        End Sub

        Private Function getScreen() As DataTable

            Dim ctlScreen As New PSS.Data.Production.tscreen()
            getScreen = ctlScreen.GetScreenList

            ctlScreen = Nothing

        End Function

        Private Sub tdgScreen_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tdgScreen.MouseUp

            txtDescription.Text = ""
            txtSysName.Text = ""
            valSID = tdgScreen.Columns(0).Value()

            If IsDBNull(tdgScreen.Columns(1).Value) = False Then
                txtDescription.Text = tdgScreen.Columns(1).Value
            End If

            If IsDBNull(tdgScreen.Columns(2).Value) = False Then
                txtSysName.Text = tdgScreen.Columns(2).Value
            End If





        End Sub


        Private Function deleteScreen(ByVal valID) As Boolean

            deleteScreen = False

            If Len(Trim(valID)) < 1 Then
                MsgBox("please define a value for deletion. Delete cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            Else
                Dim response As String = MsgBox("You are about to delete screen : " & tdgScreen.Columns(2).Value & ". Continue with delete", MsgBoxStyle.YesNo, "Continue?")
                Select Case response
                    Case vbYes
                        If Trim(valID) > 1 Then
                            Dim ctlscreen As New PSS.Data.Production.tscreen()
                            deleteScreen = ctlscreen.DeleteScreen(Trim(valSID))
                        End If
                    Case vbNo
                        Exit Function
                End Select
            End If

            txtDescription.Text = ""
            txtSysName.Text = ""

            '//Reload Level Grid
            Try
                loadScreen()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function insertScreen() As Boolean

            insertScreen = False

            Dim ctlscreen As New PSS.Data.Production.tscreen()

            '        Dim tmpDesc As String = InputBox("Please enter a description for the new user", "Add Group")
            '//Verify that all textboxes have values
            Dim blnDesc As Boolean = False
            Dim blnSysName As Boolean = False

            If Len(Trim(txtDescription.Text)) > 0 Then blnDesc = True
            If Len(Trim(txtSysName.Text)) > 0 Then blnSysName = True
            If blnDesc = False Or blnSysName = False Then
                MsgBox("Please enter values into all fields before continuing.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            End If

            '//Check for duplicate
            Dim blnDup As Boolean = False

            For xCount = 0 To dtScreen.Rows.Count - 1
                r = dtScreen.Rows(xCount)
                If Trim(blnDesc) = Trim(r("screen_desc")) Then
                    blnDup = True
                    '//Throw error because descriptions can not be duplicated
                    MsgBox("You already have a screen defined with this description. Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                    Exit Function
                End If
            Next

            If blnDup = False Then
                '//Add record to database
                Try
                    Dim blnInsert As Boolean = ctlscreen.InsertScreen(Trim(txtDescription.Text), Trim(txtSysName.Text))
                    insertScreen = True
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            txtDescription.Text = ""
            txtSysName.Text = ""

            '//Reload Level Grid
            Try
                loadScreen()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function editScreen(ByVal valID, ByVal valDesc, ByVal valSysName) As Boolean

            editScreen = False

            Dim ctlScreen As New PSS.Data.Production.tscreen()
            '        Dim tmpDesc As String = InputBox("Please modify the description for this group", "Edit Group", tmpDescOLD)

            '//Verify that all textboxes have values
            Dim blnDesc As Boolean = False
            Dim blnSysName As Boolean = False

            If Len(Trim(txtDescription.Text)) > 0 Then blnDesc = True
            If Len(Trim(txtSysName.Text)) > 0 Then blnSysName = True
            If blnDesc = False Or blnSysName = False Then
                MsgBox("Please enter values into all fields before continuing.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            End If

            Dim blnDup As Boolean = False

            '        For xCount = 0 To dtScreen.Rows.Count - 1
            '        r = dtScreen.Rows(xCount)
            '        If Trim(txtDescription.Text) = Trim(r("screen_desc")) Then
            '            blnDup = True
            '            '//Throw error because descriptions can not be duplicated
            '            MsgBox("You already have a screen defined with this description. Edit cancelled.", MsgBoxStyle.OKOnly, "ERROR")
            '            Exit Function
            '        End If
            '        Next

            If blnDup = False Then
                '//Add record to database
                Try
                    Dim blnEdit As Boolean = ctlScreen.EditScreen(valID, Trim(txtDescription.Text), Trim(txtSysName.Text))
                    editScreen = True
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            txtDescription.Text = ""
            txtSysName.Text = ""
            valSID = 0

            '//Reload Level Grid
            Try
                loadScreen()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function





        Private Sub btnSCREENNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCREENNEW.Click

            txtDescription.Text = ""
            txtSysName.Text = ""
            txtDescription.Focus()

        End Sub

        Private Sub btnSCREENADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCREENADD.Click

            Dim addTrans As Boolean = insertScreen()

            If addTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnSCREENEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCREENEDIT.Click

            '//Get value for edit
            Dim tmpID As Int32 = tdgScreen.Columns(0).Value
            Dim tmpDescOLD As String = tdgScreen.Columns(1).Value

            Dim editTrans As Boolean = editScreen(valSID, Trim(txtDescription.Text), Trim(txtSysName.Text))

            If editTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnSCREENDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSCREENDELETE.Click

            '//Get value for deletion
            Dim tmpID As Int32 = tdgScreen.Columns(0).Value

            Dim delTrans As Boolean = deleteScreen(tmpID)

            If delTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

        End Sub


        Private Sub loadGroup()

            dtGroup = getGroup()
            tdgGroup.DataSource = dtGroup
            tdgGroup.Splits(0).DisplayColumns(0).Width = 0
            tdgGroup.Splits(0).DisplayColumns(1).Width = tdgGroup.Width - 44
            tdgGroup.Columns(1).Caption = "GROUP DESCRIPTION"

        End Sub

        Private Function getGroup() As DataTable

            Dim ctlGroup As New PSS.Data.Production.tgroup()

            'Commented out by Asif on 2/21/2006
            'getGroup = ctlGroup.GetGroupList
            getGroup = ctlGroup.GetGroupList(PSS.Core.Global.ApplicationUser.User)

            ctlGroup = Nothing

        End Function


        Private Function deleteGroup(ByVal valID) As Boolean

            deleteGroup = False

            If Len(Trim(valID)) < 1 Then
                MsgBox("please define a value for deletion. Delete cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            Else
                Dim response As String = MsgBox("You are about to delete group : " & tdgGroup.Columns(1).Value & ". Continue with delete", MsgBoxStyle.YesNo, "Continue?")
                Select Case response
                    Case vbYes
                        If Trim(valID) > 1 Then
                            Dim ctlgroup As New PSS.Data.Production.tgroup()
                            deleteGroup = ctlgroup.Deletegroup(Trim(valID))
                        End If
                    Case vbNo
                        Exit Function
                End Select
            End If

            '//Reload Level Grid
            Try
                loadGroup()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function insertGroup() As Boolean

            insertGroup = False

            Dim ctlgroup As New PSS.Data.Production.tgroup()
            Dim tmpDesc As String = InputBox("Please enter a description for the new group", "Add Group")
            Dim blnDup As Boolean = False

            If Len(Trim(tmpDesc)) < 1 Then
                '//Value entered is null
                MsgBox("No value entered, add cancelled", MsgBoxStyle.OKOnly)
                Exit Function
            Else
                For xCount = 0 To dtGroup.Rows.Count - 1
                    r = dtGroup.Rows(xCount)
                    If Trim(tmpDesc) = Trim(r("group_desc")) Then
                        blnDup = True
                        '//Throw error because descriptions can not be duplicated
                        MsgBox("You already have a group defined with this description. Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Function
                    End If
                Next
            End If

            If blnDup = False Then
                '//Add record to database
                Try
                    Dim blnInsert As Boolean = ctlgroup.InsertGroup(tmpDesc)
                    insertGroup = True
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            '//Reload Level Grid
            Try
                loadGroup()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function editGroup(ByVal valID, ByVal tmpDescOLD) As Boolean

            editGroup = False

            Dim ctlgroup As New PSS.Data.Production.tgroup()
            Dim tmpDesc As String = InputBox("Please modify the description for this group", "Edit Group", tmpDescOLD)
            Dim blnDup As Boolean = False

            If Len(Trim(tmpDesc)) < 1 Then
                '//Value entered is null
                MsgBox("No value entered, edit cancelled", MsgBoxStyle.OKOnly)
                Exit Function
            Else
                For xCount = 0 To dtLevel.Rows.Count - 1
                    r = dtGroup.Rows(xCount)
                    If Trim(tmpDesc) = Trim(r("group_desc")) Then
                        blnDup = True
                        '//Throw error because descriptions can not be duplicated
                        MsgBox("You already have a group defined with this description. Edit cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Function
                    End If
                Next
            End If

            If blnDup = False Then
                '//Add record to database
                Try
                    Dim blnEdit As Boolean = ctlgroup.EditGroup(valID, tmpDesc)
                    editGroup = True
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            '//Reload Level Grid
            Try
                loadGroup()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function



        Private Sub btnGROUPEDIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGROUPEDIT.Click

            '//Get value for edit
            Dim tmpID As Int32 = tdgGroup.Columns(0).Value
            Dim tmpDescOLD As String = tdgGroup.Columns(1).Value

            Dim editTrans As Boolean = editGroup(tmpID, tmpDescOLD)

            If editTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub


        Private Sub btnGROUPEDITnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupEditNew.Click

            '//Get value for edit
            Dim tmpID As Int32 = tdgGroup.Columns(0).Value
            Dim tmpDescOLD As String = tdgGroup.Columns(1).Value

            Dim editTrans As Boolean = editGroup(tmpID, tmpDescOLD)

            If editTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnGROUPADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGROUPADD.Click

            Dim addTrans As Boolean = insertGroup()

            If addTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnGROUPADDnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupAddNew.Click

            Dim addTrans As Boolean = insertGroup()

            If addTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnGROUPDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGROUPDELETE.Click

            '//Get value for deletion
            Dim tmpID As Int32 = tdgGroup.Columns(0).Value

            Dim delVerify As Boolean = verifyGroupDelete(tmpID)
            If delVerify = False Then Exit Sub

            Dim delTrans As Boolean = deleteGroup(tmpID)

            If delTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

        End Sub

        Private Sub btnGROUPDELETEnew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupDeleteNew.Click

            '//Get value for deletion
            Dim tmpID As Int32 = tdgGroup.Columns(0).Value

            Dim delVerify As Boolean = verifyGroupDelete(tmpID)
            If delVerify = False Then Exit Sub

            Dim delTrans As Boolean = deleteGroup(tmpID)

            If delTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

        End Sub

        Private Sub btnADD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADD.Click

            Dim addTrans As Boolean = insertLevel()

            If addTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

            '//Get value for deletion
            Dim tmpID As Int32 = tdgLevel.Columns(0).Value

            Dim delVerify As Boolean = verifyLevelDelete(tmpID)
            If delVerify = False Then Exit Sub

            Dim delTrans As Boolean = deleteLevel(tmpID)

            If delTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

        End Sub

        Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

            '//Get value for edit
            Dim tmpID As Int32 = tdgLevel.Columns(0).Value
            Dim tmpDescOLD As String = tdgLevel.Columns(1).Value

            Dim editTrans As Boolean = editLevel(tmpID, tmpDescOLD)

            If editTrans = False Then
                'MsgBox("An error has occurred while inserting record.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Sub
            End If

            loadElements()

        End Sub


        Private Function deleteLevel(ByVal valID) As Boolean

            deleteLevel = False

            If Len(Trim(valID)) < 1 Then
                MsgBox("please define a value for deletion. Delete cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                Exit Function
            Else
                Dim response As String = MsgBox("You are about to delete level : " & tdgLevel.Columns(1).Value & ". Continue with delete", MsgBoxStyle.YesNo, "Continue?")
                Select Case response
                    Case vbYes
                        If Trim(valID) > 1 Then
                            Dim ctlLevel As New PSS.Data.Production.llevel()
                            deleteLevel = ctlLevel.DeleteLevel(Trim(valID))
                        End If
                    Case vbNo
                        Exit Function
                End Select
            End If

            '//Reload Level Grid
            Try
                loadLevel()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function

        Private Function insertLevel() As Boolean

            insertLevel = False

            Dim ctlLevel As New PSS.Data.Production.llevel()
            Dim tmpDesc As String = InputBox("Please enter a description for the new level", "Add Level")
            Dim blnDup As Boolean = False

            If Len(Trim(tmpDesc)) < 1 Then
                '//Value entered is null
                MsgBox("No value entered, add cancelled", MsgBoxStyle.OKOnly)
                Exit Function
            Else
                For xCount = 0 To dtLevel.Rows.Count - 1
                    r = dtLevel.Rows(xCount)
                    If Trim(tmpDesc) = Trim(r("level_desc")) Then
                        blnDup = True
                        '//Throw error because descriptions can not be duplicated
                        MsgBox("You already have a level defined with this description. Add cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Function
                    End If
                Next
            End If

            If blnDup = False Then
                '//Add record to database
                Try
                    Dim blnInsert As Boolean = ctlLevel.InsertLevel(tmpDesc)
                    insertLevel = True
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            '//Reload Level Grid
            Try
                loadLevel()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try


        End Function

        Private Function editLevel(ByVal valID, ByVal tmpDescOLD) As Boolean

            editLevel = False

            Dim ctlLevel As New PSS.Data.Production.llevel()
            Dim tmpDesc As String = InputBox("Please modify the description for this level", "Edit Level", tmpDescOLD)
            Dim blnDup As Boolean = False

            If Len(Trim(tmpDesc)) < 1 Then
                '//Value entered is null
                MsgBox("No value entered, add cancelled", MsgBoxStyle.OKOnly)
                Exit Function
            Else
                For xCount = 0 To dtLevel.Rows.Count - 1
                    r = dtLevel.Rows(xCount)
                    If Trim(tmpDesc) = Trim(r("level_desc")) Then
                        blnDup = True
                        '//Throw error because descriptions can not be duplicated
                        MsgBox("You already have a level defined with this description. Edit cancelled.", MsgBoxStyle.OKOnly, "ERROR")
                        Exit Function
                    End If
                Next
            End If

            If blnDup = False Then
                '//Add record to database
                Try
                    Dim blnEdit As Boolean = ctlLevel.EditLevel(valID, tmpDesc)
                    editLevel = True
                Catch exp As Exception
                    MsgBox(exp.ToString)
                End Try
            End If

            '//Reload Level Grid
            Try
                loadLevel()
            Catch exp As Exception
                MsgBox(exp.ToString)
            End Try

        End Function



        Private Sub loadLevel()
            Try
                dtLevel = getLevel()
                tdgLevel.DataSource = dtLevel.DefaultView
                tdgLevel.Splits(0).DisplayColumns(0).Width = 0
                tdgLevel.Splits(0).DisplayColumns(1).Width = tdgLevel.Width - 44
                tdgLevel.Columns(1).Caption = "LEVEL DESCRIPTION"
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub

        Private Function getLevel() As DataTable

            Dim ctlLevel As New PSS.Data.Production.llevel()
            getLevel = ctlLevel.GetLevelList

            ctlLevel = Nothing

        End Function



        Private Sub cboUserDetail_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

            'Dim intUser As Integer
            Dim yCount As Integer
            Dim zCount As Integer
            Dim r2 As DataRow
            Dim r3 As DataRow
            Dim tmpGroup As String
            Dim intGroup As Integer

            intUser = 0

            Try
                chklstGroup.Items.Clear()
            Catch exp As Exception
            End Try

            For xCount = 0 To dtUser.Rows.Count - 1
                r = dtUser.Rows(xCount)
                If Trim(r("user_fullname")) = Trim(cboUserDetail.Text) Then
                    intUser = r("user_ID")
                End If
            Next

            '//Get data from group
            Dim ctlRuser As New PSS.Data.Production.rusertogroup()
            Dim dtRUser As DataTable = ctlRuser.GetSingleUserGroupList(intUser)
            Dim blnSel As Boolean = False
            For xCount = 0 To dtGroup.Rows.Count - 1
                r = dtGroup.Rows(xCount)
                For yCount = 0 To dtRUser.Rows.Count - 1
                    r2 = dtRUser.Rows(yCount)
                    If r2("group_id") = r("group_id") Then
                        chklstGroup.Items.Add(r("group_desc"), True)
                        blnSel = True
                    End If
                Next
                If blnSel = False Then
                    chklstGroup.Items.Add(r("group_desc"), False)
                End If
                blnSel = False
            Next


            Try
                lstAvailableScreens.Items.Clear()
            Catch exp As Exception
            End Try

            Dim ctlPermissions As New PSS.Data.Production.tpermissions()
            Dim dtDetScreen As DataTable = ctlPermissions.GetScreenListByUser(intUser)
            For xCount = 0 To dtDetScreen.Rows.Count - 1
                r = dtDetScreen.Rows(xCount)
                Me.lstAvailableScreens.Items.Add(r("Screen_desc"))
            Next

        End Sub

        Private Sub chklstGroup_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chklstGroup.MouseUp

            Dim tmpGroup As Int32

            '//Get ID for selected item
            For xCount = 0 To dtGroup.Rows.Count - 1
                r = dtGroup.Rows(xCount)
                If r("group_desc") = chklstGroup.SelectedItem Then
                    tmpGroup = r("group_id")
                    Exit For
                End If
            Next

            '//Get Screen List

            Dim ctlScreen As New PSS.Data.Production.tpermissions()
            Dim dtScreen As DataTable = ctlScreen.GetScreenListByGroup(tmpGroup)

            Try
                lstScreen.Items.Clear()
            Catch exp As Exception
            End Try

            Dim vStatus As Integer = 0
            Dim tmpStatus As Integer = 0

            '//Verify is item is checked or not
            For xCount = 0 To chklstGroup.CheckedItems.Count - 1
                If chklstGroup.SelectedItem = chklstGroup.CheckedItems(xCount) Then
                    vStatus = 1
                    Exit For
                End If
            Next

            Try
                For xCount = 0 To dtScreen.Rows.Count - 1
                    r = dtScreen.Rows(xCount)

                    Me.lstScreen.Items.Add(r("screen_desc"))

                    If vStatus = 1 Then
                        Me.lstAvailableScreens.Items.Add(r("screen_desc"))
                    Else
                        '//Remove entry from lstAvailable
                        'For yCount = Me.lstAvailableScreens.Items.Count - 1 To 0 Step -1
                        'If Trim(lstAvailableScreens.Items(yCount)) = Trim(r("screen_desc")) Then
                        '    lstAvailableScreens.SelectedIndex = yCount
                        '    lstAvailableScreens.Items.Remove(lstAvailableScreens.SelectedItem)
                        '    yCount -= 1
                        'End If
                        'Next
                    End If
                Next
            Catch exp As Exception
            End Try

        End Sub

        Private Sub refreshUserDetail()

            Me.lstScreen.Items.Clear()
            Me.cboUserDetail.Focus()

        End Sub

        Private Function verifyLevelDelete(ByVal tmpID As Integer) As Boolean

            verifyLevelDelete = False

            Dim ctlPermissions As New PSS.Data.Production.tpermissions()
            Dim dtLevel As DataTable = ctlPermissions.VerifyLevelDelete(tmpID)

            If dtLevel.Rows.Count > 0 Then
                MsgBox("You can not delete this level, it is being used by records in the tpermissions table.", MsgBoxStyle.OKOnly, "ERROR")
            Else
                verifyLevelDelete = True
            End If

        End Function

        Private Function verifyGroupDelete(ByVal tmpID As Integer) As Boolean

            verifyGroupDelete = False

            Dim ctlPermissions As New PSS.Data.Production.tpermissions()
            Dim dtGroup As DataTable = ctlPermissions.VerifyGroupDelete(tmpID)

            If dtGroup.Rows.Count > 0 Then
                MsgBox("You can not delete this group, it is being used by records in the tpermissions table.", MsgBoxStyle.OKOnly, "ERROR")
            Else
                verifyGroupDelete = True
            End If

        End Function


        '''Private Sub btnUserDetailUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        '''    If intUser > 0 Then
        '''        '//Remove records
        '''        Dim ctlDeleteItems As New PSS.Data.Production.rusertogroup()
        '''        Dim blnDelete As Boolean = ctlDeleteItems.DeleteUserRecords(intUser)

        '''        '//Insert new record group
        '''        Dim tmpGroup As String
        '''        Dim tmpGroupID As Int32
        '''        Dim ctlInsertRecord As New PSS.Data.Production.rusertogroup()
        '''        Dim blnInsert As Boolean
        '''        For xCount = 0 To chklstGroup.CheckedItems.Count - 1
        '''            tmpGroup = chklstGroup.CheckedItems(xCount)
        '''            For yCount = 0 To dtGroup.Rows.Count - 1
        '''                r = dtGroup.Rows(yCount)
        '''                If Trim(r("group_desc")) = Trim(tmpGroup) Then
        '''                    tmpGroupID = r("group_ID")
        '''                End If
        '''            Next

        '''            '//Insert record
        '''            blnInsert = ctlInsertRecord.InsertUserRecords(intUser, tmpGroupID)
        '''            If blnInsert = False Then
        '''                MsgBox("Record Insertion Failure. Update Aborted.", MsgBoxStyle.OKOnly, "ERROR")
        '''                Exit Sub
        '''            End If
        '''            tmpGroup = ""
        '''            tmpGroupID = 0
        '''        Next
        '''    End If
        '''    MsgBox("Update Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        '''End Sub


        Private Sub txtName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtName.Leave

            Dim xx As New PSS.Data.Buisness.Generic()
            Dim xz As String = xx.GetObjectInfo(sender, e)

        End Sub

        Private Sub grpUserDetail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub populateShifts()

            Dim dsPSS As PSS.Data.Production.Joins
            'Dim dtShift As DataTable = dsPSS.OrderEntrySelect("SELECT * FROM tshift WHERE Shift_Inactive = 0")
            Dim dtShift As New DataTable()
            Dim R1 As DataRow

            Try
                dtShift = dsPSS.OrderEntrySelect("SELECT * FROM tshift WHERE Shift_Inactive = 0")
                '**********************
                R1 = dtShift.NewRow
                R1("Shift_ID") = 0
                R1("Shift_Number") = 0
                dtShift.Rows.Add(R1)
                dtShift.AcceptChanges()
                '**********************
                'cboShift.Text = ""
                Me.cboShift.SelectedValue = 0
                cboShift.DataSource = dtShift.DefaultView
                cboShift.DisplayMember = dtShift.Columns("Shift_Number").ToString
                cboShift.ValueMember = dtShift.Columns("Shift_ID").ToString
                cboShift.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dtShift) Then
                    dtShift.Dispose()
                    dtShift = Nothing
                End If
                dsPSS = Nothing
            End Try
        End Sub

        Private Sub cboUserDetail_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUserDetail.SelectedIndexChanged

            'Dim intUser As Integer
            Dim yCount As Integer
            Dim zCount As Integer
            Dim r2 As DataRow
            Dim r3 As DataRow
            Dim tmpGroup As String
            Dim intGroup As Integer

            intUser = 0

            Try
                chklstGroup.Items.Clear()
            Catch exp As Exception
            End Try

            For xCount = 0 To dtUser.Rows.Count - 1
                r = dtUser.Rows(xCount)
                If Trim(r("user_fullname")) = Trim(cboUserDetail.Text) Then
                    intUser = r("user_ID")
                    cboCopyToUser.Enabled = True
                End If
            Next

            '//Get data from group
            Dim ctlRuser As New PSS.Data.Production.rusertogroup()
            Dim dtRUser As DataTable = ctlRuser.GetSingleUserGroupList(intUser)
            Dim blnSel As Boolean = False
            For xCount = 0 To dtGroup.Rows.Count - 1
                r = dtGroup.Rows(xCount)
                For yCount = 0 To dtRUser.Rows.Count - 1
                    r2 = dtRUser.Rows(yCount)
                    If r2("group_id") = r("group_id") Then
                        chklstGroup.Items.Add(r("group_desc"), True)
                        blnSel = True
                    End If
                Next
                If blnSel = False Then
                    chklstGroup.Items.Add(r("group_desc"), False)
                End If
                blnSel = False
            Next


            Try
                lstAvailableScreens.Items.Clear()
            Catch exp As Exception
            End Try

            Dim ctlPermissions As New PSS.Data.Production.tpermissions()
            Dim dtDetScreen As DataTable = ctlPermissions.GetScreenListByUser(intUser)
            For xCount = 0 To dtDetScreen.Rows.Count - 1
                r = dtDetScreen.Rows(xCount)
                Me.lstAvailableScreens.Items.Add(r("Screen_desc"))
            Next

        End Sub

        '''Private Sub btnUserDetailUpdate_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserDetailUpdate.Click

        '''    If intUser > 0 Then
        '''        '//Remove records
        '''        Dim ctlDeleteItems As New PSS.Data.Production.rusertogroup()
        '''        Dim blnDelete As Boolean = ctlDeleteItems.DeleteUserRecords(intUser)

        '''        '//Insert new record group
        '''        Dim tmpGroup As String
        '''        Dim tmpGroupID As Int32
        '''        Dim ctlInsertRecord As New PSS.Data.Production.rusertogroup()
        '''        Dim blnInsert As Boolean
        '''        For xCount = 0 To chklstGroup.CheckedItems.Count - 1
        '''            tmpGroup = chklstGroup.CheckedItems(xCount)
        '''            For yCount = 0 To dtGroup.Rows.Count - 1
        '''                r = dtGroup.Rows(yCount)
        '''                If Trim(r("group_desc")) = Trim(tmpGroup) Then
        '''                    tmpGroupID = r("group_ID")
        '''                End If
        '''            Next

        '''            '//Insert record
        '''            blnInsert = ctlInsertRecord.InsertUserRecords(intUser, tmpGroupID)
        '''            If blnInsert = False Then
        '''                MsgBox("Record Insertion Failure. Update Aborted.", MsgBoxStyle.OKOnly, "ERROR")
        '''                Exit Sub
        '''            End If
        '''            tmpGroup = ""
        '''            tmpGroupID = 0
        '''        Next
        '''    End If
        '''    MsgBox("Update Complete!", MsgBoxStyle.OKOnly, "COMPLETE")

        '''End Sub

        Private Function CheckTabLevelPermissions(ByVal strGroup As String) As Integer
            Return ApplicationUser.GetPermission(strGroup)
        End Function

        Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
            Select Case TabControl1.SelectedTab.Name
                Case "tabUser"
                    If CheckTabLevelPermissions("SecurityAdmin_User") > 0 Then
                    Else
                        Me.Close()                          'Close the screen as they should not be here
                    End If
                Case "tabDetail"
                    If CheckTabLevelPermissions("SecurityAdmin_Detail") > 0 Then
                    Else
                        'TabControl1.Controls.Remove(TabControl1.SelectedTab)
                        TabControl1.SelectedTab = tabUser
                    End If
                Case "tabLevel"
                    If CheckTabLevelPermissions("SecurityAdmin_Level") > 0 Then
                    Else
                        'TabControl1.Controls.Remove(TabControl1.SelectedTab)
                        TabControl1.SelectedTab = tabUser
                    End If
                Case "tabScreen"
                    If CheckTabLevelPermissions("SecurityAdmin_Screen") > 0 Then
                    Else
                        'TabControl1.Controls.Remove(TabControl1.SelectedTab)
                        TabControl1.SelectedTab = tabUser
                    End If
                Case "tabGroup"
                    If CheckTabLevelPermissions("SecurityAdmin_Group") > 0 Then
                    Else
                        'TabControl1.Controls.Remove(TabControl1.SelectedTab)
                        TabControl1.SelectedTab = tabUser
                    End If
                Case "tabPermissions"
                    If CheckTabLevelPermissions("SecurityAdmin_Permis") > 0 Then
                    Else
                        'TabControl1.Controls.Remove(TabControl1.SelectedTab)
                        TabControl1.SelectedTab = tabUser
                    End If
            End Select

        End Sub


        Private Sub btnUserDetailUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUserDetailUpdate.Click
            Dim i As Integer = 0
            Dim objSecurity As New PSS.Data.Buisness.Security()

            Try
                'chklstGroup.SelectedItem
                If intUser > 0 Then
                    i = objSecurity.UpdateAccessPrevileges(intUser, Me.chklstGroup)
                End If

                If i > 0 Then
                    MessageBox.Show("Update completed.", "Upadte Access", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Upadte Access", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objSecurity = Nothing
            End Try
        End Sub


        Private Sub tabUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabUser.Click

        End Sub

        Private Sub PopulateGroupSelects()

            Dim dsPSS As PSS.Data.Production.Joins
            Dim dtGroups As DataTable = Nothing
            Dim sf As New StackFrame(0)

            Try
                dtGroups = Me._objSecAdmin.GetGroupSelects()

                If Not IsNothing(dtGroups) Then
                    If dtGroups.Rows.Count > 0 Then
                        Me.cboGroupSelect.DataSource = dtGroups.DefaultView
                        Me.cboGroupSelect.DisplayMember = dtGroups.Columns("Group_Desc").ToString
                        Me.cboGroupSelect.ValueMember = dtGroups.Columns("Group_ID").ToString
                    End If
                End If

                Me.cboGroupSelect.Text = ""
                Me.cboGroupSelect.SelectedIndex = 0
            Catch ex As Exception
                Me._objSecAdmin.DisplayMessage(sf.GetMethod, ex.Message)
            Finally
                If Not IsNothing(dtGroups) Then
                    dtGroups.Dispose()
                    dtGroups = Nothing
                End If
            End Try
        End Sub

        Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
            Dim sf As New StackFrame(0)

            Try
                SelectAllPermissions(True)
            Catch ex As Exception
                Me._objSecAdmin.DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Sub

        Private Sub btnUnselectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnselectAll.Click
            Dim sf As New StackFrame(0)

            Try
                SelectAllPermissions(False)
            Catch ex As Exception
                Me._objSecAdmin.DisplayMessage(sf.GetMethod, ex.Message)
            End Try
        End Sub

        Private Sub SelectAllPermissions(ByVal bSelectAll As Boolean)
            Dim i As Integer

            Try
                For i = 0 To Me.chklstGroup.Items.Count - 1
                    Me.chklstGroup.SetItemChecked(i, bSelectAll)
                Next i
            Catch ex As Exception
                Throw ex
            End Try
        End Sub


        Private Sub cboCopyToUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCopyToUser.SelectedIndexChanged

            intCopyToUser = 0

            For xCount = 0 To dtUser.Rows.Count - 1
                r = dtUser.Rows(xCount)
                If Trim(r("user_fullname")) = Trim(cboCopyToUser.Text) Then
                    intCopyToUser = r("user_ID")
                    btnCopyToUser.Enabled = True
                End If
            Next

        End Sub

        Private Sub btnCopyToUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyToUser.Click

            Dim i As Integer = 0
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim userFromStr As String
            Dim userToStr As String

            Try

                If intUser And intCopyToUser > 0 Then
                    userFromStr = cboUserDetail.Text
                    userToStr = cboCopyToUser.Text

                    Dim result3 As DialogResult = MessageBox.Show("Do you want to copy '" & userFromStr & "' to '" & userToStr & "'?", _
                                                                    "Your Selection", _
                                                                    MessageBoxButtons.YesNo, _
                                                                    MessageBoxIcon.Question, _
                                                                    MessageBoxDefaultButton.Button2)

                    If result3 = Windows.Forms.DialogResult.Yes Then
                        i = objSecurity.CopyUserAccessPrevileges(intUser, intCopyToUser)
                        MessageBox.Show("Copy user completed.", "Copy User", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Else
                        MessageBox.Show("Copy user cancelled.")
                    End If
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Copy User", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objSecurity = Nothing
            End Try

        End Sub

        Private Sub btnCopy2Clipboard2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy2Clipboard2.Click
            Dim s As String = "" ' "This is my Test" & vbCrLf & "Second Line"
            Dim iK As Integer

            Try
                If Me.cboUserDetail.Text.Trim.Length > 0 Then
                    s = "Available screens for user: " & Me.cboUserDetail.Text & vbCrLf & vbCrLf
                End If

                For iK = 0 To Me.lstAvailableScreens.Items.Count - 1
                    s += Me.lstAvailableScreens.Items(iK) & vbCrLf
                Next

                Clipboard.SetDataObject(s)
                'Clipboard.SetText(myStr)()

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Sub

        Private Sub btnCopy2Clipboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy2Clipboard.Click

            Dim s As String = "" ' "This is my Test" & vbCrLf & "Second Line"
            Dim iK As Integer

            Try
                If Me.cboUserDetail.Text.Trim.Length > 0 Then
                    s = "Checked screens for user: " & Me.cboUserDetail.Text & vbCrLf & vbCrLf
                End If

                ' If (Me.chklstGroup.SelectedItem <> "") Then
                Dim Entry As Object
                For Each Entry In Me.chklstGroup.CheckedItems
                    s += Entry.ToString() & vbCrLf
                Next
                'Else
                '    MessageBox.Show("You must select an item")
                'End If
                ' MessageBox.Show(s)
                Clipboard.SetDataObject(s)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End Sub

        '*****************************************************************************************
        Private Function ValidPassword(ByVal iUserID As Integer, ByVal strPassword As String, ByVal bCheckUsedPW As Boolean) As Boolean
            Dim objSecurity As New PSS.Data.Buisness.Security()
            Dim objSecurityRulePW As New PSS.Rules.SecurityPassword()

            Try

                If strPassword.Length = 0 Then
                    MessageBox.Show("Please enter a password. ", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                ElseIf objSecurityRulePW.UpperLetter AndAlso _
                       Not objSecurityRulePW.IsPsswordContainUpperLeter(strPassword) Then
                    'MessageBox.Show("Password must include at least one uppercase letter.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                ElseIf objSecurityRulePW.LowerLetter AndAlso _
                       Not objSecurityRulePW.IsPsswordContainLowerLeter(strPassword) Then
                    'MessageBox.Show("Password must include at least one lowercase letter.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                ElseIf objSecurityRulePW.SpecialCharacter AndAlso _
                       Not objSecurityRulePW.IsPsswordContainSpecialChar(strPassword) Then
                    'MessageBox.Show("Password must include at least one special character (one of these " & objSecurityRulePW.SpeicalCharacters & ").", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                ElseIf objSecurityRulePW.NumericNumber AndAlso _
                       Not objSecurityRulePW.IsPsswordContainNumber(strPassword) Then
                    'MessageBox.Show("Password must include at least one number (0-9).", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                ElseIf strPassword.Length < objSecurityRulePW.PasswordLength Then
                    'MessageBox.Show("Password length must be at least " & objSecurityRulePW.PasswordLength & ".", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    MessageBox.Show(objSecurityRulePW.PasswordRulesMsg, "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                ElseIf bCheckUsedPW AndAlso iUserID > 0 AndAlso objSecurityRulePW.IsPsswordUsedBefore(iUserID, strPassword) Then
                    MessageBox.Show("Password is already used in the last " & objSecurityRulePW.ReuseLastPWMonths & " months. It can't be reused.", "Reset Password", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                End If

                Return True

            Catch ex As Exception
                MessageBox.Show(ex.Message, "ValidPassword", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objSecurity = Nothing : objSecurityRulePW = Nothing
            End Try

        End Function

		Private Sub lblUserName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblUserName.Click

		End Sub

        Private Sub tdgUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdgUser.Click

        End Sub
    End Class
End Namespace
