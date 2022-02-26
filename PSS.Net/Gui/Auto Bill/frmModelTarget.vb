Option Explicit On 

Public Class frmModelTarget
    Inherits System.Windows.Forms.Form

    Private GobjModelTarget As PSS.Data.Buisness.ModelTarget
    Private GiUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private GdtCellstarEnterprise As DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GobjModelTarget = New PSS.Data.Buisness.ModelTarget()

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
    Friend WithEvents lblModel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grdModelTarget As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdAddUpdateTarget As System.Windows.Forms.Button
    Friend WithEvents txtBERCap As System.Windows.Forms.TextBox
    Friend WithEvents txtTarget As System.Windows.Forms.TextBox
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    Friend WithEvents cboEnterprises As System.Windows.Forms.ComboBox
    Friend WithEvents chkAutoBill As System.Windows.Forms.CheckBox
    Friend WithEvents chkActive As System.Windows.Forms.CheckBox
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents chkFlatRate As System.Windows.Forms.CheckBox
    Friend WithEvents gbFlatRateCharges As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIWLaborCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtIWPartCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtDevSaving As System.Windows.Forms.TextBox
    Friend WithEvents dtpRequestedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpApprovedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpgSaveModelTartget As System.Windows.Forms.TabPage
    Friend WithEvents tpgViewFRData As System.Windows.Forms.TabPage
    Friend WithEvents cboInvYear As C1.Win.C1List.C1Combo
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cboInvMonth As C1.Win.C1List.C1Combo
    Friend WithEvents btnView_Refresh As System.Windows.Forms.Button
    Friend WithEvents btnView_CopyAll As System.Windows.Forms.Button
    Friend WithEvents btnCopyAll As System.Windows.Forms.Button
    Friend WithEvents dbgViewFlatRateData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents chkOnHold2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOWLaborCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtOWPartCharge As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtOnHold2Part As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtOnHold2Labor As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtOWBCCost As System.Windows.Forms.TextBox
    Friend WithEvents txtIWBCCost As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmModelTarget))
        Me.grdModelTarget = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblModel = New System.Windows.Forms.Label()
        Me.cmdAddUpdateTarget = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBERCap = New System.Windows.Forms.TextBox()
        Me.txtTarget = New System.Windows.Forms.TextBox()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.cboEnterprises = New System.Windows.Forms.ComboBox()
        Me.chkAutoBill = New System.Windows.Forms.CheckBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.chkFlatRate = New System.Windows.Forms.CheckBox()
        Me.gbFlatRateCharges = New System.Windows.Forms.GroupBox()
        Me.txtOnHold2Part = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtOnHold2Labor = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cboInvMonth = New C1.Win.C1List.C1Combo()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboInvYear = New C1.Win.C1List.C1Combo()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpApprovedDate = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpRequestedDate = New System.Windows.Forms.DateTimePicker()
        Me.txtDevSaving = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtOWPartCharge = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtOWLaborCharge = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtIWPartCharge = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtIWLaborCharge = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpgSaveModelTartget = New System.Windows.Forms.TabPage()
        Me.chkOnHold2 = New System.Windows.Forms.CheckBox()
        Me.btnCopyAll = New System.Windows.Forms.Button()
        Me.tpgViewFRData = New System.Windows.Forms.TabPage()
        Me.btnView_CopyAll = New System.Windows.Forms.Button()
        Me.btnView_Refresh = New System.Windows.Forms.Button()
        Me.dbgViewFlatRateData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.txtOWBCCost = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtIWBCCost = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        CType(Me.grdModelTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbFlatRateCharges.SuspendLayout()
        CType(Me.cboInvMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboInvYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpgSaveModelTartget.SuspendLayout()
        Me.tpgViewFRData.SuspendLayout()
        CType(Me.dbgViewFlatRateData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdModelTarget
        '
        Me.grdModelTarget.AllowColMove = False
        Me.grdModelTarget.AllowColSelect = False
        Me.grdModelTarget.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdModelTarget.AllowUpdate = False
        Me.grdModelTarget.AlternatingRows = True
        Me.grdModelTarget.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdModelTarget.FilterBar = True
        Me.grdModelTarget.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdModelTarget.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdModelTarget.Location = New System.Drawing.Point(370, 40)
        Me.grdModelTarget.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdModelTarget.Name = "grdModelTarget"
        Me.grdModelTarget.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdModelTarget.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdModelTarget.PreviewInfo.ZoomFactor = 75
        Me.grdModelTarget.RowHeight = 20
        Me.grdModelTarget.Size = New System.Drawing.Size(576, 472)
        Me.grdModelTarget.TabIndex = 130
        Me.grdModelTarget.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style14{}Normal{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}S" & _
        "tyle9{}OddRow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style15{}Head" & _
        "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
        "ackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Sty" & _
        "le1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False""" & _
        " AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""True""" & _
        " CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""" & _
        "True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""1" & _
        "7"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>468</Height><Captio" & _
        "nStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /" & _
        "><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar""" & _
        " me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 572, 468</ClientRect><Borde" & _
        "rSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Merge" & _
        "View></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal""" & _
        " me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me" & _
        "=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""" & _
        "Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""High" & _
        "lightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""Odd" & _
        "Row"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""" & _
        "FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</v" & _
        "ertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17<" & _
        "/DefaultRecSelWidth><ClientArea>0, 0, 572, 468</ClientArea><PrintPageHeaderStyle" & _
        " parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>" & _
        ""
        '
        'lblModel
        '
        Me.lblModel.BackColor = System.Drawing.Color.Transparent
        Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModel.ForeColor = System.Drawing.Color.White
        Me.lblModel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblModel.Location = New System.Drawing.Point(8, 72)
        Me.lblModel.Name = "lblModel"
        Me.lblModel.Size = New System.Drawing.Size(88, 16)
        Me.lblModel.TabIndex = 117
        Me.lblModel.Text = "Model : "
        Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAddUpdateTarget
        '
        Me.cmdAddUpdateTarget.BackColor = System.Drawing.Color.Green
        Me.cmdAddUpdateTarget.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddUpdateTarget.ForeColor = System.Drawing.Color.White
        Me.cmdAddUpdateTarget.Location = New System.Drawing.Point(104, 472)
        Me.cmdAddUpdateTarget.Name = "cmdAddUpdateTarget"
        Me.cmdAddUpdateTarget.Size = New System.Drawing.Size(160, 40)
        Me.cmdAddUpdateTarget.TabIndex = 9
        Me.cmdAddUpdateTarget.Text = "Add/Update Target"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(8, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 16)
        Me.Label10.TabIndex = 114
        Me.Label10.Text = "BER Cap:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(200, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 121
        Me.Label1.Text = "Target:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(8, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Customer : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(8, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Enterprise : "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBERCap
        '
        Me.txtBERCap.Location = New System.Drawing.Point(104, 136)
        Me.txtBERCap.Name = "txtBERCap"
        Me.txtBERCap.Size = New System.Drawing.Size(72, 20)
        Me.txtBERCap.TabIndex = 5
        Me.txtBERCap.Text = "0"
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(272, 136)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(72, 20)
        Me.txtTarget.TabIndex = 6
        Me.txtTarget.Text = "0"
        '
        'cboCustomers
        '
        Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCustomers.Caption = ""
        Me.cboCustomers.CaptionHeight = 17
        Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCustomers.ColumnCaptionHeight = 17
        Me.cboCustomers.ColumnFooterHeight = 17
        Me.cboCustomers.ContentHeight = 15
        Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomers.EditorHeight = 15
        Me.cboCustomers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(104, 8)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(240, 21)
        Me.cboCustomers.TabIndex = 0
        Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
        "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
        "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'cboModels
        '
        Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboModels.Caption = ""
        Me.cboModels.CaptionHeight = 17
        Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboModels.ColumnCaptionHeight = 17
        Me.cboModels.ColumnFooterHeight = 17
        Me.cboModels.ContentHeight = 15
        Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboModels.EditorHeight = 15
        Me.cboModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(104, 72)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(5, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(240, 21)
        Me.cboModels.TabIndex = 2
        Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
        "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
        "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'cboEnterprises
        '
        Me.cboEnterprises.Location = New System.Drawing.Point(104, 40)
        Me.cboEnterprises.Name = "cboEnterprises"
        Me.cboEnterprises.Size = New System.Drawing.Size(240, 21)
        Me.cboEnterprises.TabIndex = 1
        '
        'chkAutoBill
        '
        Me.chkAutoBill.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAutoBill.ForeColor = System.Drawing.Color.White
        Me.chkAutoBill.Location = New System.Drawing.Point(240, 104)
        Me.chkAutoBill.Name = "chkAutoBill"
        Me.chkAutoBill.Size = New System.Drawing.Size(112, 24)
        Me.chkAutoBill.TabIndex = 4
        Me.chkAutoBill.Text = "Special Billing"
        '
        'chkActive
        '
        Me.chkActive.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActive.ForeColor = System.Drawing.Color.White
        Me.chkActive.Location = New System.Drawing.Point(104, 104)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(88, 24)
        Me.chkActive.TabIndex = 3
        Me.chkActive.Text = "Active"
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnRefresh.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(767, 8)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(160, 24)
        Me.btnRefresh.TabIndex = 125
        Me.btnRefresh.Text = "Refresh List"
        '
        'chkFlatRate
        '
        Me.chkFlatRate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFlatRate.ForeColor = System.Drawing.Color.White
        Me.chkFlatRate.Location = New System.Drawing.Point(104, 168)
        Me.chkFlatRate.Name = "chkFlatRate"
        Me.chkFlatRate.Size = New System.Drawing.Size(88, 24)
        Me.chkFlatRate.TabIndex = 7
        Me.chkFlatRate.Text = "Flat Rate"
        '
        'gbFlatRateCharges
        '
        Me.gbFlatRateCharges.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtOWBCCost, Me.Label17, Me.txtIWBCCost, Me.Label18, Me.txtOnHold2Part, Me.Label15, Me.txtOnHold2Labor, Me.Label16, Me.Label14, Me.cboInvMonth, Me.Label13, Me.cboInvYear, Me.Label12, Me.Label11, Me.dtpApprovedDate, Me.Label9, Me.dtpRequestedDate, Me.txtDevSaving, Me.Label8, Me.txtOWPartCharge, Me.Label6, Me.txtOWLaborCharge, Me.Label7, Me.txtIWPartCharge, Me.Label5, Me.txtIWLaborCharge, Me.Label4})
        Me.gbFlatRateCharges.Enabled = False
        Me.gbFlatRateCharges.Location = New System.Drawing.Point(0, 192)
        Me.gbFlatRateCharges.Name = "gbFlatRateCharges"
        Me.gbFlatRateCharges.Size = New System.Drawing.Size(368, 272)
        Me.gbFlatRateCharges.TabIndex = 8
        Me.gbFlatRateCharges.TabStop = False
        '
        'txtOnHold2Part
        '
        Me.txtOnHold2Part.Location = New System.Drawing.Point(200, 104)
        Me.txtOnHold2Part.Name = "txtOnHold2Part"
        Me.txtOnHold2Part.Size = New System.Drawing.Size(40, 20)
        Me.txtOnHold2Part.TabIndex = 141
        Me.txtOnHold2Part.Text = "0"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(128, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 16)
        Me.Label15.TabIndex = 143
        Me.Label15.Text = "OH2 Part :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOnHold2Labor
        '
        Me.txtOnHold2Labor.Location = New System.Drawing.Point(88, 104)
        Me.txtOnHold2Labor.Name = "txtOnHold2Labor"
        Me.txtOnHold2Labor.Size = New System.Drawing.Size(40, 20)
        Me.txtOnHold2Labor.TabIndex = 140
        Me.txtOnHold2Labor.Text = "0"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(8, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 16)
        Me.Label16.TabIndex = 142
        Me.Label16.Text = "OH2 Labor :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(8, 224)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(144, 16)
        Me.Label14.TabIndex = 139
        Me.Label14.Text = "Invoice Effective On :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboInvMonth
        '
        Me.cboInvMonth.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboInvMonth.Caption = ""
        Me.cboInvMonth.CaptionHeight = 17
        Me.cboInvMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboInvMonth.ColumnCaptionHeight = 17
        Me.cboInvMonth.ColumnFooterHeight = 17
        Me.cboInvMonth.ContentHeight = 15
        Me.cboInvMonth.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboInvMonth.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboInvMonth.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInvMonth.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboInvMonth.EditorHeight = 15
        Me.cboInvMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInvMonth.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
        Me.cboInvMonth.ItemHeight = 15
        Me.cboInvMonth.Location = New System.Drawing.Point(264, 224)
        Me.cboInvMonth.MatchEntryTimeout = CType(2000, Long)
        Me.cboInvMonth.MaxDropDownItems = CType(5, Short)
        Me.cboInvMonth.MaxLength = 32767
        Me.cboInvMonth.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboInvMonth.Name = "cboInvMonth"
        Me.cboInvMonth.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboInvMonth.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboInvMonth.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboInvMonth.Size = New System.Drawing.Size(96, 21)
        Me.cboInvMonth.TabIndex = 138
        Me.cboInvMonth.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style9{AlignHorz:Near;}OddRow{}RecordSelector{AlignImage:Center;}Head" & _
        "ing{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;B" & _
        "ackColor:Control;}Style8{}Style10{}Style11{}Style1{}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(264, 208)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 137
        Me.Label13.Text = "Month"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'cboInvYear
        '
        Me.cboInvYear.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboInvYear.Caption = ""
        Me.cboInvYear.CaptionHeight = 17
        Me.cboInvYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboInvYear.ColumnCaptionHeight = 17
        Me.cboInvYear.ColumnFooterHeight = 17
        Me.cboInvYear.ContentHeight = 15
        Me.cboInvYear.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboInvYear.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboInvYear.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInvYear.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboInvYear.EditorHeight = 15
        Me.cboInvYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboInvYear.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
        Me.cboInvYear.ItemHeight = 15
        Me.cboInvYear.Location = New System.Drawing.Point(152, 224)
        Me.cboInvYear.MatchEntryTimeout = CType(2000, Long)
        Me.cboInvYear.MaxDropDownItems = CType(5, Short)
        Me.cboInvYear.MaxLength = 32767
        Me.cboInvYear.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboInvYear.Name = "cboInvYear"
        Me.cboInvYear.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboInvYear.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboInvYear.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboInvYear.Size = New System.Drawing.Size(96, 21)
        Me.cboInvYear.TabIndex = 136
        Me.cboInvYear.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
        "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
        "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
        "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
        "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{Font:Microsoft" & _
        " Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:" & _
        "Highlight;}Style1{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:True;B" & _
        "ackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Cente" & _
        "r;}Style8{}Style10{}Style11{}Style9{AlignHorz:Near;}</Data></Styles><Splits><C1." & _
        "Win.C1List.ListBoxView AllowColSelect=""False"" Name=""Split[0,0]"" CaptionHeight=""1" & _
        "7"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" VerticalScrollGroup=""1"" Hori" & _
        "zontalScrollGroup=""1""><ClientRect>0, 0, 116, 156</ClientRect><Height>156</Height" & _
        "><VScrollBar><Width>16</Width></VScrollBar><HScrollBar><Height>16</Height></HScr" & _
        "ollBar><CaptionStyle parent=""Style2"" me=""Style9"" /><EvenRowStyle parent=""EvenRow" & _
        """ me=""Style7"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""G" & _
        "roup"" me=""Style11"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowS" & _
        "tyle parent=""HighlightRow"" me=""Style6"" /><InactiveStyle parent=""Inactive"" me=""St" & _
        "yle4"" /><OddRowStyle parent=""OddRow"" me=""Style8"" /><RecordSelectorStyle parent=""" & _
        "RecordSelector"" me=""Style10"" /><SelectedStyle parent=""Selected"" me=""Style5"" /><S" & _
        "tyle parent=""Normal"" me=""Style1"" /></C1.Win.C1List.ListBoxView></Splits><NamedSt" & _
        "yles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style" & _
        " parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style pa" & _
        "rent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style par" & _
        "ent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style pa" & _
        "rent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style" & _
        " parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSpli" & _
        "ts>1</horzSplits><Layout>Modified</Layout><DefaultRecSelWidth>17</DefaultRecSelW" & _
        "idth></Blob>"
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(152, 208)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 16)
        Me.Label12.TabIndex = 135
        Me.Label12.Text = "Year "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(8, 176)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 16)
        Me.Label11.TabIndex = 133
        Me.Label11.Text = "Approved :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpApprovedDate
        '
        Me.dtpApprovedDate.Location = New System.Drawing.Point(88, 176)
        Me.dtpApprovedDate.Name = "dtpApprovedDate"
        Me.dtpApprovedDate.Size = New System.Drawing.Size(272, 20)
        Me.dtpApprovedDate.TabIndex = 132
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(8, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 16)
        Me.Label9.TabIndex = 131
        Me.Label9.Text = "Requested :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpRequestedDate
        '
        Me.dtpRequestedDate.Location = New System.Drawing.Point(88, 144)
        Me.dtpRequestedDate.Name = "dtpRequestedDate"
        Me.dtpRequestedDate.Size = New System.Drawing.Size(272, 20)
        Me.dtpRequestedDate.TabIndex = 130
        '
        'txtDevSaving
        '
        Me.txtDevSaving.Location = New System.Drawing.Point(88, 72)
        Me.txtDevSaving.Name = "txtDevSaving"
        Me.txtDevSaving.Size = New System.Drawing.Size(40, 20)
        Me.txtDevSaving.TabIndex = 5
        Me.txtDevSaving.Text = "0"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(8, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 16)
        Me.Label8.TabIndex = 129
        Me.Label8.Text = "Saving :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOWPartCharge
        '
        Me.txtOWPartCharge.Location = New System.Drawing.Point(200, 48)
        Me.txtOWPartCharge.Name = "txtOWPartCharge"
        Me.txtOWPartCharge.Size = New System.Drawing.Size(40, 20)
        Me.txtOWPartCharge.TabIndex = 3
        Me.txtOWPartCharge.Text = "0"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(136, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "OW Part :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOWLaborCharge
        '
        Me.txtOWLaborCharge.Location = New System.Drawing.Point(88, 48)
        Me.txtOWLaborCharge.Name = "txtOWLaborCharge"
        Me.txtOWLaborCharge.Size = New System.Drawing.Size(40, 20)
        Me.txtOWLaborCharge.TabIndex = 2
        Me.txtOWLaborCharge.Text = "0"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(8, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 16)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "OW Labor :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIWPartCharge
        '
        Me.txtIWPartCharge.Location = New System.Drawing.Point(200, 24)
        Me.txtIWPartCharge.Name = "txtIWPartCharge"
        Me.txtIWPartCharge.Size = New System.Drawing.Size(40, 20)
        Me.txtIWPartCharge.TabIndex = 1
        Me.txtIWPartCharge.Text = "0"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(136, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "IW Part :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIWLaborCharge
        '
        Me.txtIWLaborCharge.Location = New System.Drawing.Point(88, 24)
        Me.txtIWLaborCharge.Name = "txtIWLaborCharge"
        Me.txtIWLaborCharge.Size = New System.Drawing.Size(40, 20)
        Me.txtIWLaborCharge.TabIndex = 0
        Me.txtIWLaborCharge.Text = "0"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 16)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "IW Labor :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpgSaveModelTartget, Me.tpgViewFRData})
        Me.TabControl1.Location = New System.Drawing.Point(1, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(959, 568)
        Me.TabControl1.TabIndex = 126
        '
        'tpgSaveModelTartget
        '
        Me.tpgSaveModelTartget.BackColor = System.Drawing.Color.SteelBlue
        Me.tpgSaveModelTartget.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkOnHold2, Me.btnCopyAll, Me.chkAutoBill, Me.Label3, Me.txtTarget, Me.txtBERCap, Me.gbFlatRateCharges, Me.grdModelTarget, Me.btnRefresh, Me.chkActive, Me.Label10, Me.cboCustomers, Me.Label1, Me.cboModels, Me.Label2, Me.chkFlatRate, Me.cboEnterprises, Me.lblModel, Me.cmdAddUpdateTarget})
        Me.tpgSaveModelTartget.Location = New System.Drawing.Point(4, 22)
        Me.tpgSaveModelTartget.Name = "tpgSaveModelTartget"
        Me.tpgSaveModelTartget.Size = New System.Drawing.Size(951, 542)
        Me.tpgSaveModelTartget.TabIndex = 0
        Me.tpgSaveModelTartget.Text = "Add/Update"
        '
        'chkOnHold2
        '
        Me.chkOnHold2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkOnHold2.ForeColor = System.Drawing.Color.White
        Me.chkOnHold2.Location = New System.Drawing.Point(240, 168)
        Me.chkOnHold2.Name = "chkOnHold2"
        Me.chkOnHold2.Size = New System.Drawing.Size(88, 24)
        Me.chkOnHold2.TabIndex = 129
        Me.chkOnHold2.Text = "On-Hold 2"
        '
        'btnCopyAll
        '
        Me.btnCopyAll.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCopyAll.BackColor = System.Drawing.Color.SlateGray
        Me.btnCopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopyAll.ForeColor = System.Drawing.Color.White
        Me.btnCopyAll.Location = New System.Drawing.Point(639, 8)
        Me.btnCopyAll.Name = "btnCopyAll"
        Me.btnCopyAll.Size = New System.Drawing.Size(120, 24)
        Me.btnCopyAll.TabIndex = 128
        Me.btnCopyAll.Text = "Copy All"
        '
        'tpgViewFRData
        '
        Me.tpgViewFRData.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnView_CopyAll, Me.btnView_Refresh, Me.dbgViewFlatRateData})
        Me.tpgViewFRData.Location = New System.Drawing.Point(4, 22)
        Me.tpgViewFRData.Name = "tpgViewFRData"
        Me.tpgViewFRData.Size = New System.Drawing.Size(951, 542)
        Me.tpgViewFRData.TabIndex = 1
        Me.tpgViewFRData.Text = "View Flat Rate Data"
        '
        'btnView_CopyAll
        '
        Me.btnView_CopyAll.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnView_CopyAll.BackColor = System.Drawing.Color.SlateGray
        Me.btnView_CopyAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView_CopyAll.ForeColor = System.Drawing.Color.White
        Me.btnView_CopyAll.Location = New System.Drawing.Point(615, 8)
        Me.btnView_CopyAll.Name = "btnView_CopyAll"
        Me.btnView_CopyAll.Size = New System.Drawing.Size(120, 24)
        Me.btnView_CopyAll.TabIndex = 127
        Me.btnView_CopyAll.Text = "Copy All"
        '
        'btnView_Refresh
        '
        Me.btnView_Refresh.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnView_Refresh.BackColor = System.Drawing.Color.SteelBlue
        Me.btnView_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnView_Refresh.ForeColor = System.Drawing.Color.White
        Me.btnView_Refresh.Location = New System.Drawing.Point(807, 8)
        Me.btnView_Refresh.Name = "btnView_Refresh"
        Me.btnView_Refresh.Size = New System.Drawing.Size(112, 24)
        Me.btnView_Refresh.TabIndex = 126
        Me.btnView_Refresh.Text = "Refresh List"
        '
        'dbgViewFlatRateData
        '
        Me.dbgViewFlatRateData.AllowColMove = False
        Me.dbgViewFlatRateData.AllowColSelect = False
        Me.dbgViewFlatRateData.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.dbgViewFlatRateData.AllowUpdate = False
        Me.dbgViewFlatRateData.AlternatingRows = True
        Me.dbgViewFlatRateData.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.dbgViewFlatRateData.FilterBar = True
        Me.dbgViewFlatRateData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgViewFlatRateData.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgViewFlatRateData.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
        Me.dbgViewFlatRateData.Location = New System.Drawing.Point(24, 48)
        Me.dbgViewFlatRateData.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.dbgViewFlatRateData.Name = "dbgViewFlatRateData"
        Me.dbgViewFlatRateData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgViewFlatRateData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgViewFlatRateData.PreviewInfo.ZoomFactor = 75
        Me.dbgViewFlatRateData.RowHeight = 20
        Me.dbgViewFlatRateData.Size = New System.Drawing.Size(895, 456)
        Me.dbgViewFlatRateData.TabIndex = 9
        Me.dbgViewFlatRateData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;BackColor:Transpa" & _
        "rent;}Footer{}Caption{AlignHorz:Center;}Style9{}Normal{Font:Microsoft Sans Serif" & _
        ", 8.25pt;BackColor:Control;AlignVert:Center;}HighlightRow{ForeColor:HighlightTex" & _
        "t;BackColor:Highlight;}Style12{}OddRow{BackColor:Control;}RecordSelector{AlignIm" & _
        "age:Center;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=" & _
        "Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Cont" & _
        "rolText;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Styl" & _
        "e15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove" & _
        "=""False"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyl" & _
        "e=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" Fil" & _
        "terBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSel" & _
        "Width=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>452</Height" & _
        "><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""S" & _
        "tyle5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""Fi" & _
        "lterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle p" & _
        "arent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighL" & _
        "ightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive" & _
        """ me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle " & _
        "parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Styl" & _
        "e6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 891, 452</ClientRec" & _
        "t><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGr" & _
        "id.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=" & _
        """Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Hea" & _
        "ding"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Norm" & _
        "al"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" " & _
        "me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal""" & _
        " me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Norm" & _
        "al"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSpl" & _
        "its>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelW" & _
        "idth>17</DefaultRecSelWidth><ClientArea>0, 0, 891, 452</ClientArea><PrintPageHea" & _
        "derStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /" & _
        "></Blob>"
        '
        'txtOWBCCost
        '
        Me.txtOWBCCost.Location = New System.Drawing.Point(328, 48)
        Me.txtOWBCCost.Name = "txtOWBCCost"
        Me.txtOWBCCost.Size = New System.Drawing.Size(36, 20)
        Me.txtOWBCCost.TabIndex = 145
        Me.txtOWBCCost.Text = "0"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(241, 48)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 16)
        Me.Label17.TabIndex = 147
        Me.Label17.Text = "OW BC Cost:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtIWBCCost
        '
        Me.txtIWBCCost.Location = New System.Drawing.Point(328, 24)
        Me.txtIWBCCost.Name = "txtIWBCCost"
        Me.txtIWBCCost.Size = New System.Drawing.Size(36, 20)
        Me.txtIWBCCost.TabIndex = 144
        Me.txtIWBCCost.Text = "0"
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(248, 24)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 16)
        Me.Label18.TabIndex = 146
        Me.Label18.Text = "IW BC Cost:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmModelTarget
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(976, 630)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
        Me.Name = "frmModelTarget"
        Me.Text = "Set Model Target"
        CType(Me.grdModelTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbFlatRateCharges.ResumeLayout(False)
        CType(Me.cboInvMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboInvYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpgSaveModelTartget.ResumeLayout(False)
        Me.tpgViewFRData.ResumeLayout(False)
        CType(Me.dbgViewFlatRateData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        Me.GobjModelTarget = Nothing
        If Not IsNothing(Me.GdtCellstarEnterprise) Then
            Me.GdtCellstarEnterprise.Dispose()
            Me.GdtCellstarEnterprise = Nothing
        End If
    End Sub

    '*********************************************************
    Private Sub frmModelTarget_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim objGen As New PSS.Data.Buisness.Generic()
        Dim dt1 As DataTable

        Try
            '*********************************************
            'Load customer of cell product only
            '*********************************************
            dt1 = PSS.Data.Buisness.Generic.GetCustomers(True, 2, )
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt1, "Cust_Name1", "Cust_ID")
            Me.cboCustomers.SelectedValue = 0
            '*********************************************
            'Load auto-bill model of cell product only
            '*********************************************
            dt1 = Data.Buisness.Generic.GetModels(True, 2, , )
            Misc.PopulateC1DropDownList(Me.cboModels, dt1, "Model_desc", "Model_id")
            Me.cboModels.SelectedValue = 0
            '*********************************************
            'Load Model Target
            '*********************************************
            dt1 = Me.GobjModelTarget.GetAllModelTarget()
            Me.SetDataGrid_ModelTarger(dt1)
            '*********************************************
            'Load all Brightpoint Enterprise
            '*********************************************
            Me.GdtCellstarEnterprise = Me.GobjModelTarget.GetAllCellstarEnterpriseCode()
            '*******************************************
            'set default value to Enterprise combobox
            '*******************************************
            Me.cboEnterprises.Items.Clear()
            Me.cboEnterprises.Items.Add("-- Select --")

            '*******************************************
            'Load Invoice Effective Year and Month
            '*******************************************
            Me.LoadInvoiceEffectiveYearMonthSelection()
            '*******************************************

            'Me.chkOnHold2.Visible = False
            'Me.txtOnHold2Labor.Visible = False
            'Me.txtOnHold2Part.Visible = False
            'Me.Label15.Visible = False
            'Me.Label16.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objGen = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*********************************************************
    Private Sub SetDataGrid_ModelTarger(ByVal dt1 As DataTable)

        Dim iNumOfColumns As Integer = Me.grdModelTarget.Columns.Count
        Dim i As Integer
        Dim drNewRow As DataRow
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn

        Try
            If dt1.Rows.Count = 0 Then
                Me.grdModelTarget.DataSource = Nothing
                Me.grdModelTarget.Refresh()
            Else
                With Me.grdModelTarget
                    'Record current filter
                    If Not IsNothing(.DataSource) Then
                        drNewRow = dt1.NewRow
                        For i = 0 To dt1.Columns.Count - 1
                            If Me.grdModelTarget.Columns(i).FilterText.Trim.Length > 0 Then drNewRow(i) = Me.grdModelTarget.Columns(i).FilterText
                        Next i
                    End If

                    .DataSource = Nothing
                    .DataSource = dt1.DefaultView
                    .Refresh()

                    'Heading style (Horizontal Alignment to Center)
                    For i = 0 To (iNumOfColumns - 1)
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    Next i

                    ''Set individual column data horizontal alignment
                    '.Splits(0).DisplayColumns("BER Cap").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    '.Splits(0).DisplayColumns("Target").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    '.Splits(0).DisplayColumns("Enterprise").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                    ''Set Column Widths
                    '.Splits(0).DisplayColumns("Customer").Width = 100
                    '.Splits(0).DisplayColumns("Model").Width = 141
                    '.Splits(0).DisplayColumns("Enterprise").Width = 83
                    '.Splits(0).DisplayColumns("BER Cap").Width = 60
                    '.Splits(0).DisplayColumns("Target").Width = 60
                    '.Splits(0).DisplayColumns("Special Billing?").Width = 90
                    '.Splits(0).DisplayColumns("FlatRate?").Width = 60
                    '.Splits(0).DisplayColumns("Flat IW Labor").Width = 80
                    '.Splits(0).DisplayColumns("Flat IW Part").Width = 80
                    '.Splits(0).DisplayColumns("Flat OW Labor").Width = 80
                    '.Splits(0).DisplayColumns("Flat OW Part").Width = 80
                    '.Splits(0).DisplayColumns("Flat-Saving").Width = 60
                    '.Splits(0).DisplayColumns("Active?").Width = 60

                    'Auto col widths
                    For Each dbgc In .Splits(0).DisplayColumns
                        dbgc.Locked = True
                        dbgc.AutoSize()
                    Next dbgc

                    'Make some columns invisible
                    .Splits(0).DisplayColumns("MT_ID").Visible = False
                    .Splits(0).DisplayColumns("MT_Cust_ID").Visible = False
                    .Splits(0).DisplayColumns("MT_Model_ID").Visible = False
                    .Splits(0).DisplayColumns("AutoBill").Visible = False
                    .Splits(0).DisplayColumns("Active").Visible = False
                    .Splits(0).DisplayColumns("FlatRate").Visible = False
                    .Splits(0).DisplayColumns("FlatRate_ID").Visible = False

                    '.Splits(0).DisplayColumns("OnHold2?").Visible = False
                    .Splits(0).DisplayColumns("IsOnHold2").Visible = False
                    '.Splits(0).DisplayColumns("OnHold2_Labor").Visible = False
                    '.Splits(0).DisplayColumns("OnHold2_Labor").Visible = False

                    'set filter
                    If Not IsNothing(drNewRow) Then
                        For i = 0 To dt1.Columns.Count - 1
                            If Not IsDBNull(drNewRow(i)) Then .Columns(i).FilterText = drNewRow(i)
                        Next i
                    End If

                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*********************************************************
    Private Sub PopulateEnterprise(ByVal iCust_ID As Integer)
        Dim R1 As DataRow
        Dim i As Integer = 0

        Try
            Me.cboEnterprises.Items.Clear()
            Me.cboEnterprises.Items.Add("-- Select --")

            Select Case iCust_ID
                Case 2113, 2629, 2630, 2631 'Brightpoint,wingtechATT,wingtech T-Mobi, vinsmart
                    For Each R1 In Me.GdtCellstarEnterprise.Rows
                        Me.cboEnterprises.Items.Add(R1("Enterprise"))
                        i += 1
                    Next R1
                Case 2019   'ATCLE
                    Me.cboEnterprises.Items.Add("ATCLE")
                Case Else
                    Me.cboEnterprises.Items.Add("")
            End Select

            Me.cboEnterprises.SelectedIndex = 0
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            Me.cboEnterprises.Refresh()
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadInvoiceEffectiveYearMonthSelection()
        Dim dteToday As DateTime = Nothing
        Dim i, iYr As Integer
        Dim dt, dt2 As DataTable
        Dim R1 As DataRow

        Try
            dteToday = CDate(Data.Buisness.Generic.MySQLServerDateTime(1))
            iYr = dteToday.Year + 1

            dt = New DataTable()
            dt.Columns.Add(New DataColumn("ID", System.Type.GetType("System.Int32")))
            dt.Columns.Add(New DataColumn("Val", System.Type.GetType("System.String")))

            For i = 0 To 12
                R1 = dt.NewRow
                R1("ID") = i
                If i = 0 Then R1("Val") = "--Select--" Else R1("Val") = i.ToString("00")
                dt.Rows.Add(R1)
            Next i
            dt.AcceptChanges()
            Misc.PopulateC1DropDownList(Me.cboInvMonth, dt, "Val", "ID")

            dt2 = New DataTable() : dt2 = dt.Clone
            For i = 0 To 5
                If i = 0 Then
                    R1 = dt2.NewRow
                    R1("ID") = i : R1("Val") = "--Select--"
                    dt2.Rows.Add(R1)
                End If

                R1 = dt2.NewRow
                R1("ID") = iYr - i : R1("Val") = iYr - i
                dt2.Rows.Add(R1)
            Next i
            dt2.AcceptChanges()
            Misc.PopulateC1DropDownList(Me.cboInvYear, dt2, "Val", "ID")

        Catch ex As Exception
            Throw ex
        Finally
            Data.Buisness.Generic.DisposeDT(dt) : Data.Buisness.Generic.DisposeDT(dt2)
        End Try
    End Sub

    '*********************************************************
    Private Sub cboCustomers_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.SelectedValueChanged
        If Me.cboCustomers.SelectedValue > 0 Then
            Me.cboModels.SelectedValue = 0 : Me.txtBERCap.Text = "0" : Me.txtTarget.Text = "0"
            Me.chkFlatRate.Checked = False
            Me.txtIWLaborCharge.Text = 0 : Me.txtIWPartCharge.Text = 0
            Me.txtOWLaborCharge.Text = 0 : Me.txtOWPartCharge.Text = 0
            Me.txtDevSaving.Text = 0
            Me.PopulateEnterprise(Me.cboCustomers.SelectedValue)
        End If
    End Sub

    '*********************************************************
    Private Sub txts_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBERCap.KeyUp, txtTarget.KeyUp, txtIWLaborCharge.KeyUp, txtIWPartCharge.KeyUp, txtDevSaving.KeyUp, dtpRequestedDate.KeyUp, dtpApprovedDate.KeyUp, cboInvYear.KeyUp, txtOWLaborCharge.KeyUp, txtOWPartCharge.KeyUp
        Try
            If e.KeyCode = 13 Then
                If sender.name = "txtBERCap" Then
                    Me.txtTarget.SelectAll() : Me.txtTarget.Focus()
                ElseIf sender.name = "txtTarget" Then
                    Me.chkFlatRate.Focus()
                ElseIf sender.name = "txtIWLaborCharge" Then
                    Me.txtIWPartCharge.SelectAll() : Me.txtIWPartCharge.Focus()
                ElseIf sender.name = "txtIWPartCharge" Then
                    Me.txtOWLaborCharge.SelectAll() : Me.txtOWLaborCharge.Focus()
                ElseIf sender.name = "txtOWLaborCharge" Then
                    Me.txtOWPartCharge.SelectAll() : Me.txtOWPartCharge.Focus()
                ElseIf sender.name = "txtOWPartCharge" Then
                    Me.txtDevSaving.SelectAll() : Me.txtDevSaving.Focus()
                ElseIf sender.name = "txtDevSaving" Then
                    Me.dtpRequestedDate.Focus()
                ElseIf sender.name = "dtpRequestedDate" Then
                    Me.dtpApprovedDate.Focus()
                ElseIf sender.name = "dtpApprovedDate" Then
                    Me.cboInvYear.SelectAll() : Me.cboInvYear.Focus()
                ElseIf sender.name = "cboInvYear" Then
                    Me.cboInvMonth.SelectAll() : Me.cboInvMonth.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, sender.name & "_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*********************************************************
    Private Sub cmdAddUpdateTarget_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddUpdateTarget.Click
        Dim i, iAutoBill, iActive, iFlatRate, iFlatRate_InvoiceEffMonth, iFlatRate_InvoiceEffYr, iFlatRateID, iDateDiffByMonth As Integer
        Dim decBERCap, decTarget, decIWLabor, decIWPart, decOWLabor, decOWPart, decSaving As Decimal
        Dim dt1 As DataTable
        Dim strFlatRate_RequestedDT, strFlatRate_ApprovedDate As String
        Dim dteThisMonth, dteInvEffMonthYr As DateTime
        Dim iOnHold2 As Integer
        Dim decOnHold2Labor, decOnHold2Part, decIWBCCost, decOWBCCost As Decimal

        Try
            'Validation
            If Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select Customer.", "Validate User Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboCustomers.SelectAll() : Me.cboCustomers.Focus() : Exit Sub
            ElseIf Me.cboModels.SelectedValue = 0 Then
                MessageBox.Show("Please select Model.", "Validate User Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboModels.SelectAll() : Me.cboModels.Focus() : Exit Sub
            ElseIf Me.cboEnterprises.SelectedIndex <= 0 Then
                MessageBox.Show("Please select Enterprise.", "Validate User Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboEnterprises.SelectAll() : Me.cboEnterprises.Focus() : Exit Sub
            ElseIf Me.chkFlatRate.Checked = True AndAlso Me.cboInvMonth.SelectedValue = 0 AndAlso Me.cboInvYear.SelectedValue = 0 Then
                'ElseIf Me.chkFlatRate.Checked = True AndAlso Me.cboInvMonth.SelectedValue = 0 OrElse Me.cboInvYear.SelectedValue = 0 Then
                MessageBox.Show("Please select Invoice Effective Month .", "Validate User Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboInvMonth.SelectAll() : Me.cboInvMonth.Focus() : Exit Sub
            ElseIf Me.chkFlatRate.Checked = True AndAlso Me.cboInvYear.SelectedValue = 0 Then
                MessageBox.Show("Please select Invoice Effective Year.", "Validate User Selection", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cboInvYear.SelectAll() : Me.cboInvYear.Focus() : Exit Sub
            End If

            If Me.chkFlatRate.Checked = True Then
                dteThisMonth = CDate(Data.Buisness.Generic.MySQLServerDateTime(1))
                dteThisMonth = New DateTime(dteThisMonth.Year, dteThisMonth.Month, 1)
                dteInvEffMonthYr = New DateTime(Me.cboInvYear.SelectedValue, Me.cboInvMonth.SelectedValue, 1)

                'NOTE :If Date1 represents a later date and time than Date2, DateDiff returns a negative number.
                iDateDiffByMonth = DateDiff(DateInterval.Month, dteThisMonth, dteInvEffMonthYr)

                If Me.txtIWLaborCharge.Text.Trim.Length = 0 OrElse CDec(Me.txtIWLaborCharge.Text) = 0 Then
                    MessageBox.Show("Warranty Labor charge can't be zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtIWLaborCharge.SelectAll() : Me.txtIWLaborCharge.Focus() : Exit Sub
                    'ElseIf Me.txtIWPartCharge.Text.Trim.Length = 0 OrElse CDec(Me.txtIWPartCharge.Text) = 0 Then
                    '    MessageBox.Show("Warranty part charge can't be zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    '    Me.txtIWPartCharge.SelectAll() : Me.txtOWLaborCharge.Focus() : Exit Sub
                    'ElseIf Me.txtOWLaborCharge.Text.Trim.Length = 0 OrElse CDec(Me.txtOWPartCharge.Text) = 0 Then
                ElseIf Me.txtOWLaborCharge.Text.Trim.Length = 0 OrElse CDec(Me.txtOWLaborCharge.Text) = 0 Then
                    MessageBox.Show("Out of Warranty labor charge can't be zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtOWLaborCharge.SelectAll() : Me.txtOWLaborCharge.Focus() : Exit Sub
                    'ElseIf Me.txtOWPartCharge.Text.Trim.Length = 0 OrElse CDec(Me.txtOWPartCharge.Text) = 0 Then
                    '    MessageBox.Show("Out of Warranty part charge can't be zero.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    '    Me.txtOWPartCharge.SelectAll() : Me.txtOWPartCharge.Focus() : Exit Sub
                ElseIf iDateDiffByMonth <= -2 Then
                    MessageBox.Show("Can't edit any flat rate data that is 2 months older than current month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOWPartCharge.SelectAll() : Me.txtOWPartCharge.Focus() : Exit Sub
                ElseIf iDateDiffByMonth >= 2 Then
                    MessageBox.Show("You can only edit/add flat rate data for this month or next month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtOWPartCharge.SelectAll() : Me.txtOWPartCharge.Focus() : Exit Sub
                End If
            End If

            'Ask user for confirm message
            If MessageBox.Show("Are you sure you want to ""Add/Update"" the Target?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            If Me.chkAutoBill.Checked = True Then iAutoBill = 1 Else iAutoBill = 0
            If Me.chkActive.Checked = True Then iActive = 1 Else iActive = 0
            If Me.chkFlatRate.Checked = True Then
                iFlatRate = 1
                decIWLabor = CDec(Me.txtIWLaborCharge.Text)
                decIWPart = CDec(Me.txtIWPartCharge.Text)
                decOWLabor = CDec(Me.txtOWLaborCharge.Text)
                decOWPart = CDec(Me.txtOWPartCharge.Text)
                decSaving = CDec(Me.txtDevSaving.Text)
                decIWBCCost = CDec(Me.txtIWBCCost.Text)
                decOWBCCost = CDec(Me.txtOWBCCost.Text)
                strFlatRate_RequestedDT = Me.dtpRequestedDate.Value.ToString("yyyy-MM-dd")
                strFlatRate_ApprovedDate = Me.dtpApprovedDate.Value.ToString("yyyy-MM-dd")
            Else
                iFlatRate = 0
                decIWLabor = 0 : decIWPart = 0
                decOWLabor = 0 : decOWPart = 0
                decIWBCCost = 0
                decOWBCCost = 0
                decSaving = 0
                strFlatRate_RequestedDT = "NULL" : strFlatRate_ApprovedDate = "NULL"
            End If

            decBERCap = CDec(Me.txtBERCap.Text)
            decTarget = CDec(Me.txtTarget.Text)

            'OnHold2
            If Me.chkOnHold2.Checked Then
                iOnHold2 = 1 : decOnHold2Labor = CDec(Me.txtOnHold2Labor.Text) : decOnHold2Part = CDec(Me.txtOnHold2Part.Text)
            Else
                iOnHold2 = 0 : decOnHold2Labor = 0 : decOnHold2Part = 0
            End If
            '**********************
            'Update Model Target
            '**********************
            i = Me.GobjModelTarget.AddUpdateModelTarget(Me.GiUserID, Me.cboCustomers.SelectedValue, Me.cboModels.SelectedValue, _
                                                        UCase(Me.cboEnterprises.Items.Item(Me.cboEnterprises.SelectedIndex)).Trim, _
                                                        decBERCap, decTarget, iAutoBill, iActive, iFlatRate, decIWLabor, decIWPart, decOWLabor, decOWPart, decSaving, _
                                                        strFlatRate_RequestedDT, strFlatRate_ApprovedDate, dteInvEffMonthYr, Me.cboModels.Text, _
                                                        iOnHold2, decOnHold2Labor, decOnHold2Part, decIWBCCost, decOWBCCost)
            If i > 0 Then
                '****************
                'Reset Data
                '****************
                Me.cboModels.SelectedValue = 0
                Me.txtBERCap.Text = "0" : Me.txtTarget.Text = "0"
                Me.chkAutoBill.Checked = False
                Me.chkFlatRate.Checked = False
                Me.txtIWLaborCharge.Text = 0 : Me.txtIWPartCharge.Text = 0
                Me.txtOWLaborCharge.Text = 0 : Me.txtOWPartCharge.Text = 0
                Me.txtIWBCCost.Text = 0 : Me.txtOWBCCost.Text = 0
                Me.txtDevSaving.Text = 0
                Me.chkOnHold2.Checked = False
                Me.txtOnHold2Labor.Text = 0 : Me.txtOnHold2Part.Text = 0
                Me.Enabled = True : Me.cboModels.SelectAll() : Me.cboModels.Focus()
                MessageBox.Show("Completed.", "Add/Update Target", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.Enabled = True : Me.cboModels.SelectAll() : Me.cboModels.Focus()
            End If
            '**********************
            'Refresh DataGrid
            '**********************
            dt1 = Me.GobjModelTarget.GetAllModelTarget()
            Me.SetDataGrid_ModelTarger(dt1)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Add/Update Target Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Data.Buisness.Generic.DisposeDT(dt1)
            Me.Enabled = True : Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*********************************************************
    Private Sub txts_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBERCap.KeyPress, txtTarget.KeyPress, txtIWLaborCharge.KeyPress, txtIWPartCharge.KeyPress, txtDevSaving.KeyPress, txtOWLaborCharge.KeyPress, txtOWPartCharge.KeyPress
        If Not (e.KeyChar.IsDigit(e.KeyChar) OrElse e.KeyChar.IsControl(e.KeyChar) OrElse e.KeyChar.ToString = ".") Then
            e.Handled = True
        End If
    End Sub

    '*********************************************************
    Private Sub grdModelTarget_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdModelTarget.DoubleClick
        Dim i As Integer = 0

        Try
            If IsNothing(Me.grdModelTarget.DataSource) OrElse Me.grdModelTarget.RowCount = 0 OrElse Me.grdModelTarget.Columns.Count = 0 Then Exit Sub

            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            '****************
            'Reset Data
            '****************
            Me.cboCustomers.SelectedValue = 0
            Me.cboModels.SelectedValue = 0
            Me.cboEnterprises.SelectedIndex = 0
            Me.txtBERCap.Text = "0"
            Me.txtTarget.Text = "0"
            Me.chkAutoBill.Checked = False
            Me.chkActive.Checked = False
            Me.chkFlatRate.Checked = False
            Me.txtIWLaborCharge.Text = 0 : Me.txtIWPartCharge.Text = 0
            Me.txtOWLaborCharge.Text = 0 : Me.txtOWPartCharge.Text = 0
            Me.txtDevSaving.Text = 0
            Me.dtpRequestedDate.Value = Now : Me.dtpApprovedDate.Value = Now
            Me.cboInvMonth.SelectedValue = 0 : Me.cboInvYear.SelectedValue = 0
            '****************
            'populate data
            '****************
            'Customer
            If Not IsDBNull(Me.grdModelTarget.Columns("MT_Cust_ID").Value) Then
                Me.cboCustomers.SelectedValue = Me.grdModelTarget.Columns("MT_Cust_ID").Value
                Me.PopulateEnterprise(Me.cboCustomers.SelectedValue)
            Else
                Exit Sub
            End If

            'Model
            If Not IsDBNull(Me.grdModelTarget.Columns("MT_Model_ID").Value) Then
                Me.cboModels.SelectedValue = Me.grdModelTarget.Columns("MT_Model_ID").Value
            Else
                Exit Sub
            End If

            'Enterprise
            If Not IsDBNull(Me.grdModelTarget.Columns("Enterprise").Value) Then
                For i = 0 To Me.cboEnterprises.Items.Count - 1
                    If UCase(Trim(Me.cboEnterprises.Items.Item(i))) = UCase(Trim(Me.grdModelTarget.Columns("Enterprise").Value)) Then
                        Me.cboEnterprises.SelectedIndex = i
                        Exit For
                    End If
                Next i
            End If

            'BER Cap
            If Not IsDBNull(Me.grdModelTarget.Columns("BER Cap").Value) Then
                Me.txtBERCap.Text = CDec(Me.grdModelTarget.Columns("BER Cap").Value)
            End If

            'Target
            If Not IsDBNull(Me.grdModelTarget.Columns("Target").Value) Then
                Me.txtTarget.Text = CDec(Me.grdModelTarget.Columns("Target").Value)
            End If

            If Not IsDBNull(Me.grdModelTarget.Columns("AutoBill").Value) Then
                If Me.grdModelTarget.Columns("AutoBill").Value.ToString.Trim = "1" Then Me.chkAutoBill.Checked = True Else Me.chkAutoBill.Checked = False
            End If
            If Not IsDBNull(Me.grdModelTarget.Columns("Active").Value) Then
                If Me.grdModelTarget.Columns("Active").Value.ToString.Trim = "1" Then Me.chkActive.Checked = True Else Me.chkActive.Checked = False
            End If

            'Flat Rate data, and On-Hold 2
            If Not IsDBNull(Me.grdModelTarget.Columns("FlatRate").Value) AndAlso Me.grdModelTarget.Columns("FlatRate").Value.ToString.Trim = "1" Then
                Me.chkFlatRate.Checked = True
                Me.gbFlatRateCharges.Enabled = True
                Me.chkOnHold2.Enabled = True
            Else
                Me.chkFlatRate.Checked = False
                Me.gbFlatRateCharges.Enabled = False
                Me.chkOnHold2.Enabled = False
            End If

            If CInt(Me.grdModelTarget.Columns("FlatRate_ID").Value) > 0 Then
                If Not IsDBNull(Me.grdModelTarget.Columns("Flat IW Labor").Value) Then
                    Me.txtIWLaborCharge.Text = CDec(Me.grdModelTarget.Columns("Flat IW Labor").Value)
                Else
                    Me.txtIWLaborCharge.Text = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("Flat IW Part").Value) Then
                    Me.txtIWPartCharge.Text = CDec(Me.grdModelTarget.Columns("Flat IW Part").Value)
                Else
                    Me.txtIWPartCharge.Text = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("Flat OW Labor").Value) Then
                    Me.txtOWLaborCharge.Text = CDec(Me.grdModelTarget.Columns("Flat OW Labor").Value)
                Else
                    Me.txtOWLaborCharge.Text = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("Flat OW Part").Value) Then
                    Me.txtOWPartCharge.Text = CDec(Me.grdModelTarget.Columns("Flat OW Part").Value)
                Else
                    Me.txtOWPartCharge.Text = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("IW Battery Cover").Value) Then
                    Me.txtIWBCCost.Text = CDec(Me.grdModelTarget.Columns("IW Battery Cover").Value)
                Else
                    Me.txtIWBCCost.Text = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("OW Battery Cover").Value) Then
                    Me.txtOWBCCost.Text = CDec(Me.grdModelTarget.Columns("OW Battery Cover").Value)
                Else
                    Me.txtOWBCCost.Text = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("Flat-Saving").Value) Then
                    Me.txtDevSaving.Text = CDec(Me.grdModelTarget.Columns("Flat-Saving").Value)
                Else
                    Me.txtDevSaving.Text = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("OnHold2_Labor").Value) Then
                    Me.txtOnHold2Labor.Text = CDec(Me.grdModelTarget.Columns("OnHold2_Labor").Value)
                Else
                    Me.txtOnHold2Labor.Text = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("OnHold2_Part").Value) Then
                    Me.txtOnHold2Part.Text = CDec(Me.grdModelTarget.Columns("OnHold2_Part").Value)
                Else
                    Me.txtOnHold2Part.Text = 0
                End If
                If CInt(Me.grdModelTarget.Columns("IsOnHold2").Value) > 0 Then
                    Me.chkOnHold2.Checked = True
                Else
                    Me.chkOnHold2.Checked = False
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("Requested Date").Value) Then
                    Me.dtpRequestedDate.Value = CDate(Me.grdModelTarget.Columns("Requested Date").Value)
                Else
                    Me.dtpRequestedDate.Value = Now
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("Approved Date").Value) Then
                    Me.dtpApprovedDate.Value = CDate(Me.grdModelTarget.Columns("Approved Date").Value)
                Else
                    Me.dtpApprovedDate.Value = Now
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("Invoice Effective Month").Value) Then
                    Me.cboInvMonth.SelectedValue = CInt(Me.grdModelTarget.Columns("Invoice Effective Month").Value)
                Else
                    Me.cboInvMonth.SelectedValue = 0
                End If
                If Not IsDBNull(Me.grdModelTarget.Columns("Invoice Effective Year").Value) Then
                    Me.cboInvYear.Text = CInt(Me.grdModelTarget.Columns("Invoice Effective Year").Value)
                Else
                    Me.cboInvYear.Text = 0
                End If
            Else
                Me.txtIWLaborCharge.Text = 0 : Me.txtIWPartCharge.Text = 0
                Me.txtOWLaborCharge.Text = 0 : Me.txtOWPartCharge.Text = 0
                Me.txtIWBCCost.Text = 0 : Me.txtOWBCCost.Text = 0
                Me.txtDevSaving.Text = 0
                Me.dtpRequestedDate.Value = Now : Me.dtpApprovedDate.Value = Now
                Me.cboInvMonth.SelectedValue = 0 : Me.cboInvYear.SelectedValue = 0
                Me.txtOnHold2Labor.Text = 0 : Me.txtOnHold2Part.Text = 0
            End If

            Me.Enabled = True : Me.txtBERCap.SelectAll() : Me.txtBERCap.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "DataGrid KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************************************************************
    Private Sub chkFlatRate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkFlatRate.CheckedChanged
        If Me.chkFlatRate.Checked = True Then
            Me.gbFlatRateCharges.Enabled = True
            Me.chkOnHold2.Enabled = True
        Else
            Me.gbFlatRateCharges.Enabled = False
            Me.chkOnHold2.Enabled = False
            Me.txtIWLaborCharge.Text = 0 : Me.txtIWPartCharge.Text = 0
            Me.txtOWLaborCharge.Text = 0 : Me.txtOWPartCharge.Text = 0
            Me.txtDevSaving.Text = 0
            Me.cboInvYear.SelectedValue = 0 : Me.cboInvMonth.SelectedValue = 0
        End If

        Me.txtIWLaborCharge.SelectAll() : Me.txtIWLaborCharge.Focus()
    End Sub

    '******************************************************************************************************************
    Private Sub btns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click, btnView_CopyAll.Click, btnView_Refresh.Click, btnRefresh.Click
        Dim dt1 As DataTable
        Try
            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
            If sender.name = "btnCopyAll" Then
                Misc.CopyAllData(Me.grdModelTarget)
            ElseIf sender.name = "btnRefresh" Then
                dt1 = Me.GobjModelTarget.GetAllModelTarget()
                Me.SetDataGrid_ModelTarger(dt1)
            ElseIf sender.name = "btnView_CopyAll" Then
                Misc.CopyAllData(Me.dbgViewFlatRateData)
            ElseIf sender.name = "btnView_Refresh" Then
                dbgViewFlatRateData_VisibleChanged(Nothing, Nothing)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, sender.name & "_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Data.Buisness.Generic.DisposeDT(dt1)
            Me.Enabled = True : Cursor.Current = Cursors.Default
        End Try
    End Sub

    '******************************************************************************************************************
    Private Sub dbgViewFlatRateData_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgViewFlatRateData.VisibleChanged
        Dim dt As DataTable
        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
        Try
            If Me.tpgViewFRData.Visible = True Then
                dt = Me.GobjModelTarget.GetFlatRateData()
                Me.dbgViewFlatRateData.DataSource = dt.DefaultView
                For Each dbgc In Me.dbgViewFlatRateData.Splits(0).DisplayColumns
                    dbgc.Locked = True
                    dbgc.AutoSize()
                Next dbgc
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "dbgViewFlatRateData_VisibleChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************************************************************

End Class
