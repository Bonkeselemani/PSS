Imports PSS.Rules
Namespace Gui
    Public Class Model
        Inherits System.Windows.Forms.Form
#Region "DECLARATIONS"
        Private model As Integer
        Private _iPssCustMapID As Integer = 0
        Public _booCancel As Boolean = True
        Private _bHas_BC_Old As Boolean = True
#End Region
#Region " Windows Form Designer generated code "
        Public Sub New(ByVal model As Integer)
            MyBase.New()
            InitializeComponent()
            Me.model = model
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
        Friend WithEvents txtModelDesc As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboTier As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboFlat As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboProduct As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboRptGrp As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents lblASC As System.Windows.Forms.Label
        Friend WithEvents cmbGSM As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents cmbModelType As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents txtItemNo As System.Windows.Forms.TextBox
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents txtOutSkuDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtOutSku As System.Windows.Forms.TextBox
        Friend WithEvents txtInSkuDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtItemDesc As System.Windows.Forms.TextBox
        Friend WithEvents txtInSku As System.Windows.Forms.TextBox
        Friend WithEvents chkmap As System.Windows.Forms.CheckBox
        Friend WithEvents gbMapCustModel As System.Windows.Forms.GroupBox
        Friend WithEvents Label15 As System.Windows.Forms.Label
        Friend WithEvents cboManuf As C1.Win.C1List.C1Combo
        Friend WithEvents lblInstruction As System.Windows.Forms.Label
        Friend WithEvents cboAPCCodes As C1.Win.C1List.C1Combo
        Friend WithEvents cboAsc As C1.Win.C1List.C1Combo
        Friend WithEvents Label16 As System.Windows.Forms.Label
        Friend WithEvents cboAccessoryCategory As C1.Win.C1List.C1Combo
        Friend WithEvents lblModelFamily As System.Windows.Forms.Label
        Friend WithEvents cboModelFamily As C1.Win.C1List.C1Combo
        Friend WithEvents txtManufModelDesc As System.Windows.Forms.TextBox
        Friend WithEvents lblManufModelDesc As System.Windows.Forms.Label
        Friend WithEvents chkNoPSDTest As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoSWRef As System.Windows.Forms.CheckBox
        Friend WithEvents btnAddUpdate As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents Label18 As System.Windows.Forms.Label
        Friend WithEvents txtModelShortDesc As System.Windows.Forms.TextBox
        Friend WithEvents Label19 As System.Windows.Forms.Label
        Friend WithEvents cboCustMapFamily As C1.Win.C1List.C1Combo
        Friend WithEvents chkBuffable As System.Windows.Forms.CheckBox
        Friend WithEvents chkAltWrtyDateCodeLogic As System.Windows.Forms.CheckBox
        Friend WithEvents cbHasBC As System.Windows.Forms.CheckBox
        Friend WithEvents chkKSCapable As System.Windows.Forms.CheckBox
        Friend WithEvents chkSWProcess As System.Windows.Forms.CheckBox
        Friend WithEvents chkTriage As System.Windows.Forms.CheckBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Model))
            Me.lblModel = New System.Windows.Forms.Label()
            Me.txtModelDesc = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboTier = New PSS.Gui.Controls.ComboBox()
            Me.cboFlat = New PSS.Gui.Controls.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblASC = New System.Windows.Forms.Label()
            Me.btnAddUpdate = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.cboProduct = New PSS.Gui.Controls.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboRptGrp = New PSS.Gui.Controls.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cmbGSM = New PSS.Gui.Controls.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cmbModelType = New PSS.Gui.Controls.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.chkmap = New System.Windows.Forms.CheckBox()
            Me.gbMapCustModel = New System.Windows.Forms.GroupBox()
            Me.cboCustMapFamily = New C1.Win.C1List.C1Combo()
            Me.Label19 = New System.Windows.Forms.Label()
            Me.txtManufModelDesc = New System.Windows.Forms.TextBox()
            Me.lblManufModelDesc = New System.Windows.Forms.Label()
            Me.txtOutSkuDesc = New System.Windows.Forms.TextBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.txtOutSku = New System.Windows.Forms.TextBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtInSkuDesc = New System.Windows.Forms.TextBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.txtItemDesc = New System.Windows.Forms.TextBox()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.txtInSku = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.txtItemNo = New System.Windows.Forms.TextBox()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.chkNoSWRef = New System.Windows.Forms.CheckBox()
            Me.chkNoPSDTest = New System.Windows.Forms.CheckBox()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cboManuf = New C1.Win.C1List.C1Combo()
            Me.Label15 = New System.Windows.Forms.Label()
            Me.lblInstruction = New System.Windows.Forms.Label()
            Me.cboAPCCodes = New C1.Win.C1List.C1Combo()
            Me.cboAsc = New C1.Win.C1List.C1Combo()
            Me.cboAccessoryCategory = New C1.Win.C1List.C1Combo()
            Me.Label16 = New System.Windows.Forms.Label()
            Me.lblModelFamily = New System.Windows.Forms.Label()
            Me.cboModelFamily = New C1.Win.C1List.C1Combo()
            Me.txtModelShortDesc = New System.Windows.Forms.TextBox()
            Me.Label18 = New System.Windows.Forms.Label()
            Me.chkBuffable = New System.Windows.Forms.CheckBox()
            Me.chkAltWrtyDateCodeLogic = New System.Windows.Forms.CheckBox()
            Me.cbHasBC = New System.Windows.Forms.CheckBox()
            Me.chkKSCapable = New System.Windows.Forms.CheckBox()
            Me.chkSWProcess = New System.Windows.Forms.CheckBox()
            Me.chkTriage = New System.Windows.Forms.CheckBox()
            Me.gbMapCustModel.SuspendLayout()
            CType(Me.cboCustMapFamily, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboManuf, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboAPCCodes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboAsc, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboAccessoryCategory, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModelFamily, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblModel
            '
            Me.lblModel.Location = New System.Drawing.Point(32, 104)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(112, 16)
            Me.lblModel.TabIndex = 5
            Me.lblModel.Text = "Model Description:"
            '
            'txtModelDesc
            '
            Me.txtModelDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtModelDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtModelDesc.Location = New System.Drawing.Point(32, 120)
            Me.txtModelDesc.Name = "txtModelDesc"
            Me.txtModelDesc.Size = New System.Drawing.Size(288, 21)
            Me.txtModelDesc.TabIndex = 6
            Me.txtModelDesc.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(32, 184)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(120, 16)
            Me.Label1.TabIndex = 9
            Me.Label1.Text = "Tier Product Group:"
            '
            'cboTier
            '
            Me.cboTier.Location = New System.Drawing.Point(32, 200)
            Me.cboTier.Name = "cboTier"
            Me.cboTier.Size = New System.Drawing.Size(288, 21)
            Me.cboTier.TabIndex = 10
            '
            'cboFlat
            '
            Me.cboFlat.Location = New System.Drawing.Point(32, 240)
            Me.cboFlat.Name = "cboFlat"
            Me.cboFlat.Size = New System.Drawing.Size(288, 21)
            Me.cboFlat.TabIndex = 12
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(32, 224)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(120, 16)
            Me.Label2.TabIndex = 11
            Me.Label2.Text = "Flat Product Group:"
            '
            'lblASC
            '
            Me.lblASC.Location = New System.Drawing.Point(32, 304)
            Me.lblASC.Name = "lblASC"
            Me.lblASC.Size = New System.Drawing.Size(120, 16)
            Me.lblASC.TabIndex = 15
            Me.lblASC.Text = "ASC Code:"
            '
            'btnAddUpdate
            '
            Me.btnAddUpdate.BackColor = System.Drawing.Color.SteelBlue
            Me.btnAddUpdate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAddUpdate.ForeColor = System.Drawing.Color.White
            Me.btnAddUpdate.Location = New System.Drawing.Point(408, 544)
            Me.btnAddUpdate.Name = "btnAddUpdate"
            Me.btnAddUpdate.Size = New System.Drawing.Size(120, 40)
            Me.btnAddUpdate.TabIndex = 37
            Me.btnAddUpdate.Text = "Add / Update"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SlateGray
            Me.btnCancel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(608, 544)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(120, 40)
            Me.btnCancel.TabIndex = 0
            Me.btnCancel.Text = "Cancel"
            '
            'cboProduct
            '
            Me.cboProduct.Location = New System.Drawing.Point(32, 80)
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.Size = New System.Drawing.Size(288, 21)
            Me.cboProduct.TabIndex = 4
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(32, 64)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 16)
            Me.Label4.TabIndex = 3
            Me.Label4.Text = "Product Type:"
            '
            'cboRptGrp
            '
            Me.cboRptGrp.ItemHeight = 13
            Me.cboRptGrp.Location = New System.Drawing.Point(32, 280)
            Me.cboRptGrp.Name = "cboRptGrp"
            Me.cboRptGrp.Size = New System.Drawing.Size(287, 21)
            Me.cboRptGrp.TabIndex = 14
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(32, 264)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(120, 16)
            Me.Label5.TabIndex = 13
            Me.Label5.Text = "Report Group"
            '
            'cmbGSM
            '
            Me.cmbGSM.Items.AddRange(New Object() {"NON-GSM", "GSM"})
            Me.cmbGSM.Location = New System.Drawing.Point(32, 360)
            Me.cmbGSM.Name = "cmbGSM"
            Me.cmbGSM.Size = New System.Drawing.Size(288, 21)
            Me.cmbGSM.TabIndex = 18
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(32, 344)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(120, 16)
            Me.Label6.TabIndex = 17
            Me.Label6.Text = "GSM:"
            '
            'cmbModelType
            '
            Me.cmbModelType.Items.AddRange(New Object() {"Non-Wipe Down", "Wipe Down"})
            Me.cmbModelType.Location = New System.Drawing.Point(32, 400)
            Me.cmbModelType.Name = "cmbModelType"
            Me.cmbModelType.Size = New System.Drawing.Size(288, 21)
            Me.cmbModelType.TabIndex = 20
            Me.cmbModelType.Visible = False
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(32, 384)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(120, 16)
            Me.Label7.TabIndex = 19
            Me.Label7.Text = "Model Type:"
            Me.Label7.Visible = False
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(32, 424)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(120, 16)
            Me.Label3.TabIndex = 21
            Me.Label3.Text = "APC Code:"
            '
            'chkmap
            '
            Me.chkmap.Location = New System.Drawing.Point(352, 184)
            Me.chkmap.Name = "chkmap"
            Me.chkmap.Size = New System.Drawing.Size(192, 16)
            Me.chkmap.TabIndex = 33
            Me.chkmap.Text = "Map Customer Model"
            '
            'gbMapCustModel
            '
            Me.gbMapCustModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCustMapFamily, Me.Label19, Me.txtManufModelDesc, Me.lblManufModelDesc, Me.txtOutSkuDesc, Me.Label13, Me.txtOutSku, Me.Label14, Me.txtInSkuDesc, Me.Label11, Me.txtItemDesc, Me.Label12, Me.txtInSku, Me.Label10, Me.txtItemNo, Me.Label9})
            Me.gbMapCustModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbMapCustModel.Location = New System.Drawing.Point(352, 216)
            Me.gbMapCustModel.Name = "gbMapCustModel"
            Me.gbMapCustModel.Size = New System.Drawing.Size(376, 320)
            Me.gbMapCustModel.TabIndex = 35
            Me.gbMapCustModel.TabStop = False
            Me.gbMapCustModel.Text = "Customer Item Info"
            Me.gbMapCustModel.Visible = False
            '
            'cboCustMapFamily
            '
            Me.cboCustMapFamily.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustMapFamily.AutoCompletion = True
            Me.cboCustMapFamily.AutoDropDown = True
            Me.cboCustMapFamily.AutoSelect = True
            Me.cboCustMapFamily.Caption = ""
            Me.cboCustMapFamily.CaptionHeight = 17
            Me.cboCustMapFamily.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustMapFamily.ColumnCaptionHeight = 17
            Me.cboCustMapFamily.ColumnFooterHeight = 17
            Me.cboCustMapFamily.ColumnHeaders = False
            Me.cboCustMapFamily.ContentHeight = 15
            Me.cboCustMapFamily.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustMapFamily.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustMapFamily.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustMapFamily.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustMapFamily.EditorHeight = 15
            Me.cboCustMapFamily.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustMapFamily.ItemHeight = 15
            Me.cboCustMapFamily.Location = New System.Drawing.Point(176, 280)
            Me.cboCustMapFamily.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustMapFamily.MaxDropDownItems = CType(10, Short)
            Me.cboCustMapFamily.MaxLength = 32767
            Me.cboCustMapFamily.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustMapFamily.Name = "cboCustMapFamily"
            Me.cboCustMapFamily.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustMapFamily.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustMapFamily.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustMapFamily.Size = New System.Drawing.Size(184, 21)
            Me.cboCustMapFamily.TabIndex = 0
            Me.cboCustMapFamily.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label19
            '
            Me.Label19.Location = New System.Drawing.Point(176, 264)
            Me.Label19.Name = "Label19"
            Me.Label19.Size = New System.Drawing.Size(120, 16)
            Me.Label19.TabIndex = 15
            Me.Label19.Text = "Model Family"
            '
            'txtManufModelDesc
            '
            Me.txtManufModelDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtManufModelDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtManufModelDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtManufModelDesc.Location = New System.Drawing.Point(8, 280)
            Me.txtManufModelDesc.Name = "txtManufModelDesc"
            Me.txtManufModelDesc.Size = New System.Drawing.Size(152, 21)
            Me.txtManufModelDesc.TabIndex = 14
            Me.txtManufModelDesc.Text = ""
            '
            'lblManufModelDesc
            '
            Me.lblManufModelDesc.Location = New System.Drawing.Point(8, 264)
            Me.lblManufModelDesc.Name = "lblManufModelDesc"
            Me.lblManufModelDesc.Size = New System.Drawing.Size(136, 16)
            Me.lblManufModelDesc.TabIndex = 13
            Me.lblManufModelDesc.Text = "Manuf's Model Desc"
            '
            'txtOutSkuDesc
            '
            Me.txtOutSkuDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutSkuDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtOutSkuDesc.Location = New System.Drawing.Point(8, 232)
            Me.txtOutSkuDesc.Name = "txtOutSkuDesc"
            Me.txtOutSkuDesc.Size = New System.Drawing.Size(352, 21)
            Me.txtOutSkuDesc.TabIndex = 12
            Me.txtOutSkuDesc.Text = ""
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(8, 216)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(184, 16)
            Me.Label13.TabIndex = 11
            Me.Label13.Text = "Out Going Sku Description"
            '
            'txtOutSku
            '
            Me.txtOutSku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutSku.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtOutSku.Location = New System.Drawing.Point(120, 80)
            Me.txtOutSku.Name = "txtOutSku"
            Me.txtOutSku.Size = New System.Drawing.Size(152, 21)
            Me.txtOutSku.TabIndex = 5
            Me.txtOutSku.Text = ""
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(8, 80)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(104, 16)
            Me.Label14.TabIndex = 4
            Me.Label14.Text = "Out Going Sku"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtInSkuDesc
            '
            Me.txtInSkuDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInSkuDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtInSkuDesc.Location = New System.Drawing.Point(8, 184)
            Me.txtInSkuDesc.Name = "txtInSkuDesc"
            Me.txtInSkuDesc.Size = New System.Drawing.Size(352, 21)
            Me.txtInSkuDesc.TabIndex = 9
            Me.txtInSkuDesc.Text = ""
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(8, 168)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(176, 16)
            Me.Label11.TabIndex = 8
            Me.Label11.Text = "Incoming Sku Description:"
            '
            'txtItemDesc
            '
            Me.txtItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtItemDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtItemDesc.Location = New System.Drawing.Point(8, 136)
            Me.txtItemDesc.Name = "txtItemDesc"
            Me.txtItemDesc.Size = New System.Drawing.Size(352, 21)
            Me.txtItemDesc.TabIndex = 7
            Me.txtItemDesc.Text = ""
            '
            'Label12
            '
            Me.Label12.Location = New System.Drawing.Point(8, 120)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(160, 16)
            Me.Label12.TabIndex = 6
            Me.Label12.Text = "Item Description"
            '
            'txtInSku
            '
            Me.txtInSku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInSku.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtInSku.Location = New System.Drawing.Point(120, 51)
            Me.txtInSku.Name = "txtInSku"
            Me.txtInSku.Size = New System.Drawing.Size(152, 21)
            Me.txtInSku.TabIndex = 3
            Me.txtInSku.Text = ""
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(8, 53)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(104, 16)
            Me.Label10.TabIndex = 2
            Me.Label10.Text = "Incoming Sku"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'txtItemNo
            '
            Me.txtItemNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtItemNo.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtItemNo.Location = New System.Drawing.Point(120, 24)
            Me.txtItemNo.Name = "txtItemNo"
            Me.txtItemNo.Size = New System.Drawing.Size(152, 21)
            Me.txtItemNo.TabIndex = 1
            Me.txtItemNo.Text = ""
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(48, 24)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(64, 16)
            Me.Label9.TabIndex = 0
            Me.Label9.Text = "Item #"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'chkNoSWRef
            '
            Me.chkNoSWRef.Location = New System.Drawing.Point(472, 72)
            Me.chkNoSWRef.Name = "chkNoSWRef"
            Me.chkNoSWRef.Size = New System.Drawing.Size(120, 24)
            Me.chkNoSWRef.TabIndex = 30
            Me.chkNoSWRef.Text = "No Software Ref"
            Me.chkNoSWRef.Visible = False
            '
            'chkNoPSDTest
            '
            Me.chkNoPSDTest.Location = New System.Drawing.Point(352, 72)
            Me.chkNoPSDTest.Name = "chkNoPSDTest"
            Me.chkNoPSDTest.TabIndex = 29
            Me.chkNoPSDTest.Text = "No PSD Test"
            Me.chkNoPSDTest.Visible = False
            '
            'cboCustomer
            '
            Me.cboCustomer.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboCustomer.AutoCompletion = True
            Me.cboCustomer.AutoDropDown = True
            Me.cboCustomer.AutoSelect = True
            Me.cboCustomer.Caption = ""
            Me.cboCustomer.CaptionHeight = 17
            Me.cboCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboCustomer.ColumnCaptionHeight = 17
            Me.cboCustomer.ColumnFooterHeight = 17
            Me.cboCustomer.ColumnHeaders = False
            Me.cboCustomer.ContentHeight = 15
            Me.cboCustomer.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboCustomer.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboCustomer.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboCustomer.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboCustomer.EditorHeight = 15
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(352, 40)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(360, 21)
            Me.cboCustomer.TabIndex = 28
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(352, 24)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(288, 16)
            Me.Label8.TabIndex = 27
            Me.Label8.Text = "Customers:"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboManuf
            '
            Me.cboManuf.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboManuf.AutoCompletion = True
            Me.cboManuf.AutoDropDown = True
            Me.cboManuf.AutoSelect = True
            Me.cboManuf.Caption = ""
            Me.cboManuf.CaptionHeight = 17
            Me.cboManuf.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboManuf.ColumnCaptionHeight = 17
            Me.cboManuf.ColumnFooterHeight = 17
            Me.cboManuf.ColumnHeaders = False
            Me.cboManuf.ContentHeight = 15
            Me.cboManuf.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboManuf.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboManuf.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboManuf.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboManuf.EditorHeight = 15
            Me.cboManuf.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboManuf.ItemHeight = 15
            Me.cboManuf.Location = New System.Drawing.Point(32, 40)
            Me.cboManuf.MatchEntryTimeout = CType(2000, Long)
            Me.cboManuf.MaxDropDownItems = CType(10, Short)
            Me.cboManuf.MaxLength = 32767
            Me.cboManuf.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboManuf.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboManuf.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboManuf.Size = New System.Drawing.Size(288, 21)
            Me.cboManuf.TabIndex = 2
            Me.cboManuf.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.Black
            Me.Label15.Location = New System.Drawing.Point(32, 24)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(288, 16)
            Me.Label15.TabIndex = 1
            Me.Label15.Text = "Manufacture :"
            Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblInstruction
            '
            Me.lblInstruction.BackColor = System.Drawing.Color.Transparent
            Me.lblInstruction.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblInstruction.ForeColor = System.Drawing.Color.Blue
            Me.lblInstruction.Location = New System.Drawing.Point(8, 0)
            Me.lblInstruction.Name = "lblInstruction"
            Me.lblInstruction.Size = New System.Drawing.Size(600, 24)
            Me.lblInstruction.TabIndex = 0
            Me.lblInstruction.Text = "Please select the following items and press enter after each item."
            Me.lblInstruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cboAPCCodes
            '
            Me.cboAPCCodes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboAPCCodes.AutoCompletion = True
            Me.cboAPCCodes.AutoDropDown = True
            Me.cboAPCCodes.AutoSelect = True
            Me.cboAPCCodes.Caption = ""
            Me.cboAPCCodes.CaptionHeight = 17
            Me.cboAPCCodes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboAPCCodes.ColumnCaptionHeight = 17
            Me.cboAPCCodes.ColumnFooterHeight = 17
            Me.cboAPCCodes.ColumnHeaders = False
            Me.cboAPCCodes.ContentHeight = 15
            Me.cboAPCCodes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboAPCCodes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboAPCCodes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboAPCCodes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboAPCCodes.EditorHeight = 15
            Me.cboAPCCodes.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboAPCCodes.ItemHeight = 15
            Me.cboAPCCodes.Location = New System.Drawing.Point(32, 440)
            Me.cboAPCCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboAPCCodes.MaxDropDownItems = CType(10, Short)
            Me.cboAPCCodes.MaxLength = 32767
            Me.cboAPCCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboAPCCodes.Name = "cboAPCCodes"
            Me.cboAPCCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboAPCCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboAPCCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboAPCCodes.Size = New System.Drawing.Size(288, 21)
            Me.cboAPCCodes.TabIndex = 22
            Me.cboAPCCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboAsc
            '
            Me.cboAsc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboAsc.AutoCompletion = True
            Me.cboAsc.AutoDropDown = True
            Me.cboAsc.AutoSelect = True
            Me.cboAsc.Caption = ""
            Me.cboAsc.CaptionHeight = 17
            Me.cboAsc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboAsc.ColumnCaptionHeight = 17
            Me.cboAsc.ColumnFooterHeight = 17
            Me.cboAsc.ColumnHeaders = False
            Me.cboAsc.ContentHeight = 15
            Me.cboAsc.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboAsc.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboAsc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboAsc.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboAsc.EditorHeight = 15
            Me.cboAsc.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboAsc.ItemHeight = 15
            Me.cboAsc.Location = New System.Drawing.Point(32, 320)
            Me.cboAsc.MatchEntryTimeout = CType(2000, Long)
            Me.cboAsc.MaxDropDownItems = CType(10, Short)
            Me.cboAsc.MaxLength = 32767
            Me.cboAsc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboAsc.Name = "cboAsc"
            Me.cboAsc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboAsc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboAsc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboAsc.Size = New System.Drawing.Size(288, 21)
            Me.cboAsc.TabIndex = 16
            Me.cboAsc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboAccessoryCategory
            '
            Me.cboAccessoryCategory.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboAccessoryCategory.AutoCompletion = True
            Me.cboAccessoryCategory.AutoDropDown = True
            Me.cboAccessoryCategory.AutoSelect = True
            Me.cboAccessoryCategory.Caption = ""
            Me.cboAccessoryCategory.CaptionHeight = 17
            Me.cboAccessoryCategory.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboAccessoryCategory.ColumnCaptionHeight = 17
            Me.cboAccessoryCategory.ColumnFooterHeight = 17
            Me.cboAccessoryCategory.ColumnHeaders = False
            Me.cboAccessoryCategory.ContentHeight = 15
            Me.cboAccessoryCategory.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboAccessoryCategory.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboAccessoryCategory.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboAccessoryCategory.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboAccessoryCategory.EditorHeight = 15
            Me.cboAccessoryCategory.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboAccessoryCategory.ItemHeight = 15
            Me.cboAccessoryCategory.Location = New System.Drawing.Point(32, 480)
            Me.cboAccessoryCategory.MatchEntryTimeout = CType(2000, Long)
            Me.cboAccessoryCategory.MaxDropDownItems = CType(10, Short)
            Me.cboAccessoryCategory.MaxLength = 32767
            Me.cboAccessoryCategory.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboAccessoryCategory.Name = "cboAccessoryCategory"
            Me.cboAccessoryCategory.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboAccessoryCategory.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboAccessoryCategory.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboAccessoryCategory.Size = New System.Drawing.Size(288, 21)
            Me.cboAccessoryCategory.TabIndex = 24
            Me.cboAccessoryCategory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label16
            '
            Me.Label16.Location = New System.Drawing.Point(32, 464)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(120, 16)
            Me.Label16.TabIndex = 23
            Me.Label16.Text = "Accessory Category:"
            '
            'lblModelFamily
            '
            Me.lblModelFamily.Location = New System.Drawing.Point(32, 504)
            Me.lblModelFamily.Name = "lblModelFamily"
            Me.lblModelFamily.Size = New System.Drawing.Size(120, 16)
            Me.lblModelFamily.TabIndex = 25
            Me.lblModelFamily.Text = "Model Family"
            '
            'cboModelFamily
            '
            Me.cboModelFamily.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModelFamily.AutoCompletion = True
            Me.cboModelFamily.AutoDropDown = True
            Me.cboModelFamily.AutoSelect = True
            Me.cboModelFamily.Caption = ""
            Me.cboModelFamily.CaptionHeight = 17
            Me.cboModelFamily.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModelFamily.ColumnCaptionHeight = 17
            Me.cboModelFamily.ColumnFooterHeight = 17
            Me.cboModelFamily.ColumnHeaders = False
            Me.cboModelFamily.ContentHeight = 15
            Me.cboModelFamily.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModelFamily.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModelFamily.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModelFamily.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModelFamily.EditorHeight = 15
            Me.cboModelFamily.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboModelFamily.ItemHeight = 15
            Me.cboModelFamily.Location = New System.Drawing.Point(32, 520)
            Me.cboModelFamily.MatchEntryTimeout = CType(2000, Long)
            Me.cboModelFamily.MaxDropDownItems = CType(10, Short)
            Me.cboModelFamily.MaxLength = 32767
            Me.cboModelFamily.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModelFamily.Name = "cboModelFamily"
            Me.cboModelFamily.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModelFamily.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModelFamily.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModelFamily.Size = New System.Drawing.Size(288, 21)
            Me.cboModelFamily.TabIndex = 26
            Me.cboModelFamily.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'txtModelShortDesc
            '
            Me.txtModelShortDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtModelShortDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtModelShortDesc.Location = New System.Drawing.Point(176, 152)
            Me.txtModelShortDesc.MaxLength = 6
            Me.txtModelShortDesc.Name = "txtModelShortDesc"
            Me.txtModelShortDesc.Size = New System.Drawing.Size(144, 21)
            Me.txtModelShortDesc.TabIndex = 8
            Me.txtModelShortDesc.Text = ""
            '
            'Label18
            '
            Me.Label18.Location = New System.Drawing.Point(32, 152)
            Me.Label18.Name = "Label18"
            Me.Label18.Size = New System.Drawing.Size(152, 16)
            Me.Label18.TabIndex = 7
            Me.Label18.Text = "Model Short Description:"
            '
            'chkBuffable
            '
            Me.chkBuffable.Location = New System.Drawing.Point(616, 72)
            Me.chkBuffable.Name = "chkBuffable"
            Me.chkBuffable.TabIndex = 31
            Me.chkBuffable.Text = "Buffable"
            '
            'chkAltWrtyDateCodeLogic
            '
            Me.chkAltWrtyDateCodeLogic.Location = New System.Drawing.Point(56, 552)
            Me.chkAltWrtyDateCodeLogic.Name = "chkAltWrtyDateCodeLogic"
            Me.chkAltWrtyDateCodeLogic.Size = New System.Drawing.Size(192, 24)
            Me.chkAltWrtyDateCodeLogic.TabIndex = 36
            Me.chkAltWrtyDateCodeLogic.Text = "Alt Wrty Date Code Logic"
            '
            'cbHasBC
            '
            Me.cbHasBC.Location = New System.Drawing.Point(352, 96)
            Me.cbHasBC.Name = "cbHasBC"
            Me.cbHasBC.Size = New System.Drawing.Size(248, 24)
            Me.cbHasBC.TabIndex = 32
            Me.cbHasBC.Text = "This Model has a Battery Cover."
            '
            'chkKSCapable
            '
            Me.chkKSCapable.Location = New System.Drawing.Point(472, 120)
            Me.chkKSCapable.Name = "chkKSCapable"
            Me.chkKSCapable.Size = New System.Drawing.Size(152, 24)
            Me.chkKSCapable.TabIndex = 38
            Me.chkKSCapable.Text = "Kill Switch Capable"
            Me.chkKSCapable.Visible = False
            '
            'chkSWProcess
            '
            Me.chkSWProcess.Location = New System.Drawing.Point(352, 120)
            Me.chkSWProcess.Name = "chkSWProcess"
            Me.chkSWProcess.TabIndex = 39
            Me.chkSWProcess.Text = "SW Process"
            Me.chkSWProcess.Visible = False
            '
            'chkTriage
            '
            Me.chkTriage.Location = New System.Drawing.Point(352, 152)
            Me.chkTriage.Name = "chkTriage"
            Me.chkTriage.Size = New System.Drawing.Size(104, 16)
            Me.chkTriage.TabIndex = 40
            Me.chkTriage.Text = "Triaged"
            '
            'Model
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(762, 600)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkTriage, Me.chkSWProcess, Me.chkKSCapable, Me.cbHasBC, Me.chkAltWrtyDateCodeLogic, Me.chkBuffable, Me.txtModelShortDesc, Me.Label18, Me.cboModelFamily, Me.lblModelFamily, Me.cboAccessoryCategory, Me.Label16, Me.cboAsc, Me.cboAPCCodes, Me.lblInstruction, Me.cboManuf, Me.Label15, Me.gbMapCustModel, Me.chkmap, Me.Label3, Me.cboRptGrp, Me.Label5, Me.cboProduct, Me.Label4, Me.btnCancel, Me.btnAddUpdate, Me.lblASC, Me.cboFlat, Me.Label2, Me.cboTier, Me.Label1, Me.txtModelDesc, Me.lblModel, Me.cmbModelType, Me.Label7, Me.Label6, Me.cmbGSM, Me.cboCustomer, Me.Label8, Me.chkNoPSDTest, Me.chkNoSWRef})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "Model"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Model"
            Me.gbMapCustModel.ResumeLayout(False)
            CType(Me.cboCustMapFamily, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboManuf, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboAPCCodes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboAsc, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboAccessoryCategory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModelFamily, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region
#Region "FORM EVENTS"
        Private Sub Model_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt, dt2 As DataTable

            Try
                'PSS.Core.Highlight.SetHighLight(Me)
                PopulateGroups()
                PopulateProducts()
                dt = PSS.Data.Buisness.Generic.GetManufactures(True)
                Misc.PopulateC1DropDownList(Me.cboManuf, dt, "Manuf_Desc", "Manuf_ID")
                Me.cboManuf.SelectedValue = 0

                dt = Nothing
                dt = PSS.Data.Buisness.Generic.GetAccessoryCategories()
                Misc.PopulateC1DropDownList(Me.cboAccessoryCategory, dt, "AccessoryCategory", "Accessory")
                cboAccessoryCategory.SelectedValue = 0

                dt = PSS.Data.Buisness.Generic.GetModelFamilies(True)
                Misc.PopulateC1DropDownList(Me.cboModelFamily, dt, "Model Family", "ModelFamiliesID")
                Me.cboModelFamily.SelectedValue = 0

                dt2 = New DataTable() : dt2 = dt.Copy
                Misc.PopulateC1DropDownList(Me.cboCustMapFamily, dt2, "Model Family", "ModelFamiliesID")
                Me.cboCustMapFamily.SelectedValue = 0

                If model <> 0 Then
                    ' THIS IS TO EDIT AN EXISTING RECORD.
                    Me.LoadFields()
                    If Me.cboProduct.GetID > 0 Then
                        dt = PSS.Data.Buisness.Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                        Me.cboCustomer.SelectedValue = 0
                    End If
                    Dim iSelectedModelFamiliesID As Integer = PSS.Data.Buisness.Generic.GetModelFamiliesID(model)
                    If iSelectedModelFamiliesID > 0 Then
                        Me.cboModelFamily.SelectedValue = iSelectedModelFamiliesID 'Select model in combo box  
                    End If
                Else
                    ' THIS IS FOR A NEW RECORD.
                    Me.cbHasBC.Checked = True
                End If

                ' PER ZACK THIS IS TO MAKE THEM SELECT THE VALUE AGAIN 
                ' BECAUSE THE FORM VALIDATES FOR AN ENTRY.
                Me.cmbModelType.SelectedIndex = 0
                Me.cmbGSM.SelectedIndex = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt) : PSS.Data.Buisness.Generic.DisposeDT(dt2)
            End Try
        End Sub
#End Region
#Region "CONTROL EVENTS"

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub
        Private Sub btnAddUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddUpdate.Click
            Dim iProd_ID As Integer = Me.cboProduct.GetID
            If iProd_ID = 2 AndAlso Me._bHas_BC_Old = True AndAlso cbHasBC.Checked = False Then  'Changed from Has BC to Has No BC, trigered to update
                Dim strMsg As String = "This will reset the model '" & Me.txtModelDesc.Text & _
                                       "' No Battery Cover Required, and update device part charges " & _
                                       " for devices of this model in Production Completed." & Environment.NewLine & _
                                       "Would you like to submit your changes?"
                Dim result As Integer = MessageBox.Show(strMsg, "Selection", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Exit Sub
                End If
            Else
                If MessageBox.Show("Would you like to submit your changes?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) <> DialogResult.Yes Then
                    Exit Sub
                End If
            End If


            Dim iGSM, iModelType, iModelID, iDcodeID, iAltWrtyDateCode As Integer
            Dim iHasBC As Boolean = Me.cbHasBC.Checked
            Dim iSWProcess, iKSCapable, iTriageNeeded As Integer
            Dim strModel_MotoSku, strModelDesc, strMaterialType, strCategory As String
            Dim objModManf As New PSS.Data.Buisness.ModManuf()
            Dim dt As DataTable
            Try
                Me.Cursor = Cursors.WaitCursor
                iGSM = 0 : iModelType = 0 : iModelID = 0 : iDcodeID = 0 : iAltWrtyDateCode = 0
                iSWProcess = 0 : iKSCapable = 0
                strModel_MotoSku = "" : strModelDesc = "" : strMaterialType = "" : strCategory = ""

                'Mandatory field validation
                If Me.cboManuf.SelectedValue = 0 Then
                    MsgBox("Please select a 'Manufactuer'.", MsgBoxStyle.Exclamation)
                    Me.cboManuf.Focus() : Exit Sub
                ElseIf Me.cboProduct.Text = "" Then
                    MsgBox("Please select a 'Product Type'", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf Me.txtModelDesc.Text = "" Then
                    MsgBox("Please type in the 'Model Description'", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf Me.cboFlat.Text = "" Then
                    MsgBox("Please select a 'Flat Product Group'", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf Me.cboTier.Text = "" Then
                    MsgBox("Please select a 'Tier Product Group'", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf Me.cboRptGrp.Text = "" Then
                    MsgBox("Please select a 'Report Group'", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf Me.cboAsc.Text = "" Then
                    MsgBox("Please select an 'ASC Code'", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf Me.txtModelShortDesc.Text = "" Then
                    MsgBox("Please enter model short description.", MsgBoxStyle.Exclamation)
                    Exit Sub
                ElseIf Me.chkmap.Checked = True Then
                    If Me.cboCustomer.SelectedValue = 0 Then
                        MsgBox("Please select 'Customer'.", MsgBoxStyle.Exclamation)
                        Me.cboCustomer.Focus() : Exit Sub
                    ElseIf Me.txtItemNo.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item #'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus() : Exit Sub
                    ElseIf Me.txtItemDesc.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Description'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus() : Exit Sub
                    ElseIf Me.txtInSku.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Incoming Sku'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus() : Exit Sub
                    ElseIf Me.txtInSkuDesc.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Incoming Sku Description'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus() : Exit Sub
                    ElseIf Me.txtOutSku.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Outgoing Sku'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus() : Exit Sub
                    ElseIf Me.txtOutSkuDesc.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Incoming Sku Description'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus() : Exit Sub
                    ElseIf Me.txtManufModelDesc.Text.Trim.Length = 0 Then
                        MsgBox("Please enter a manufacturer's model description.", MsgBoxStyle.Exclamation)
                        Me.txtManufModelDesc.Focus() : Exit Sub
                    ElseIf Me.model > 0 AndAlso Me._iPssCustMapID = 0 Then
                        dt = PSS.Data.Buisness.ModManuf.GetPSSCustModelMap(Me.model, Me.cboCustomer.SelectedValue)
                        If dt.Rows.Count > 1 Then
                            MsgBox("More than one mapping record existed in table. Please contact IT.", MsgBoxStyle.Exclamation)
                            Exit Sub
                        ElseIf dt.Rows.Count > 0 Then
                            Me._iPssCustMapID = dt.Rows(0)("cm_id")
                        End If
                    End If

                    If Me.cboCustomer.SelectedValue = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                        strMaterialType = "FG"
                        If Me.cboManuf.SelectedValue = 53 Then strCategory = "ACCESSORY" Else strCategory = "PHONE" 'TRACFONE ACCESSORY
                    End If

                    'ElseIf Me.cboModelFamily.Text.Trim.Length = 0 Then
                    '    If MsgBox("You have not selected a model family.  Is this what you want?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question Or MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub
                End If

                '**********************************************************
                'Added by Lan 01/26/2007

                If Me.cboProduct.GetID = 2 Then
                    '***************************
                    'Validate GSM Flag
                    '***************************
                    If Me.cmbGSM.Text = "" Then
                        MsgBox("Please select 'GSM' or 'NON-GSM'", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    iGSM = Me.cmbGSM.SelectedIndex
                    ' THIS FIELD DOES NOT APPEAR TO BE USED ANYMORE.
                    ' I AM RESERVING ALL VALUES OF 1 OTHERWISE SETTING IT TO 0.
                    ' DAVID BRADLEY 09/29/2015.
                    If iModelType <> 1 Then
                        iModelType = 0
                    End If
                End If

                '***************************
                'Validate APC code
                '***************************
                If Me.cboManuf.SelectedValue = 1 And iModelType = 0 Then 'Motorola 
                    If Me.cboAPCCodes.SelectedValue = 0 Then
                        MsgBox("Please select an 'APC Code'", MsgBoxStyle.Exclamation)
                        If IsNothing(Me.cboAPCCodes.DataSource) Then Me.PopulateAPCCodes()
                        Me.cboAPCCodes.Focus()
                        Exit Sub
                    ElseIf IsNothing(Me.cboAPCCodes.SelectedValue) Then
                        Me.PopulateAPCCodes() : Exit Sub 'should never happen
                    Else
                        iDcodeID = Me.cboAPCCodes.SelectedValue
                    End If
                End If
                '**********************************************************
                If Me.chkAltWrtyDateCodeLogic.Checked = True Then iAltWrtyDateCode = 1 Else iAltWrtyDateCode = 0
                If Me.chkSWProcess.Checked Then iSWProcess = 1 Else iSWProcess = 0
                If Me.chkKSCapable.Checked Then iKSCapable = 1 Else iKSCapable = 0
                If Me.chkTriage.Checked Then iTriageNeeded = 1 Else iTriageNeeded = 0

                If Me.model <> 0 Then       'updating an existing model

                    iModelID = Me.model
                    ModManuf.DoUpdateModel(Me.model, Me.txtModelDesc.Text, Me.cboTier.GetID, _
                                           Me.cboFlat.GetID, Me.cboManuf.SelectedValue, Me.cboProduct.GetID, _
                                           Me.cboAsc.SelectedValue, Me.cboRptGrp.GetID, iDcodeID, _
                                           iGSM, iModelType, Me.cboAccessoryCategory.SelectedValue, _
                                           iAltWrtyDateCode, iHasBC, Me.txtModelShortDesc.Text, _
                                           iSWProcess, iKSCapable, iTriageNeeded)

                    '************************************
                    'Map Pss Model and customer Model
                    '************************************
                    If Me.chkmap.Checked = True Then
                        PSS.Data.Buisness.ModManuf.MapPssCustModel(Me._iPssCustMapID, Me.cboCustomer.SelectedValue, iModelID, _
                                                  Me.txtItemNo.Text.Trim, Me.txtItemDesc.Text.Trim, _
                                                  Me.txtInSku.Text.Trim, Me.txtInSkuDesc.Text, _
                                                  Me.txtOutSku.Text.Trim, Me.txtOutSkuDesc.Text, strMaterialType, strCategory, _
                                                  Me.txtManufModelDesc.Text.Trim, Me.cboCustMapFamily.SelectedValue)

                    End If
                    '***************************************

                    'Update this after model updated------------------------------
                    If iProd_ID = 2 AndAlso Me._bHas_BC_Old = True AndAlso iHasBC = False Then 'Changed from Has BC to Has No BC, trigered to update
                        'MessageBox.Show("OK")
                        Dim objDeviceBilling As New PSS.Data.Buisness.DeviceBilling()
                        Dim strErrMsg As String = ""
                        objDeviceBilling.UpdateTFPartCharge_WhenModelHasNoBatterryCover(Me.model, Me.txtModelDesc.Text, CInt(PSS.Core.ApplicationUser.IDuser), strErrMsg)
                        If strErrMsg.Trim.Length > 0 Then MessageBox.Show(strErrMsg)
                        objDeviceBilling = Nothing
                    End If

                    'Completed
                    _booCancel = False
                    Me.Close()
                Else                        'Adding a new model
                    ''**********************************************************
                    ''Generate tmodel.Model_MotoSku, added by Lan on 02/23/2007
                    ''**********************************************************
                    'strModelDesc = UCase(Trim(Me.txtModelDesc.Text))
                    'strModelDesc = Replace(strModelDesc, "-", "", 1) 'replace '-' with empty
                    'strModelDesc = Replace(strModelDesc, " ", "", 1) 'replace space with empty

                    'strModel_MotoSku = Microsoft.VisualBasic.Left(strModelDesc, 6)

                    'strModel_MotoSku = objModManf.ValidateModel_MotoSku(strModel_MotoSku)

                    'If strModel_MotoSku = "" Then
                    '    MsgBox("Can not define model description for shipping screen. Contact IT.", MsgBoxStyle.Exclamation)
                    '    Exit Sub
                    'End If
                    ''**********************************************************

                    Dim _has_bc As Integer
                    _has_bc = IIf(iHasBC, 1, 0)

                    iModelID = ModManuf.InsertModel(Me.txtModelDesc.Text, Me.cboTier.GetID, Me.cboFlat.GetID, _
                                                    Me.cboManuf.SelectedValue, Me.cboProduct.GetID, Me.cboAsc.SelectedValue, _
                                                    Me.cboRptGrp.GetID, iDcodeID, iGSM, iModelType, _
                                                    Me.cboAccessoryCategory.SelectedValue, Me.txtModelShortDesc.Text.Trim.ToUpper, _
                                                    iAltWrtyDateCode, 1, iSWProcess, iKSCapable, iTriageNeeded)

                    '************************************
                    'Map Pss Model and customer Model
                    '************************************
                    If Me.chkmap.Checked = True Then
                        If iModelID = 0 Then Throw New Exception("System has failed to create model.")
                        PSS.Data.Buisness.ModManuf.MapPssCustModel(Me._iPssCustMapID, Me.cboCustomer.SelectedValue, iModelID, _
                                                 Me.txtItemNo.Text.Trim, Me.txtItemDesc.Text.Trim, _
                                                 Me.txtInSku.Text.Trim, Me.txtInSkuDesc.Text, _
                                                 Me.txtOutSku.Text.Trim, Me.txtOutSkuDesc.Text, strMaterialType, strCategory, _
                                                 Me.txtManufModelDesc.Text.Trim, Me.cboCustMapFamily.SelectedValue)

                    End If
                    '************************************

                    _booCancel = False
                    Me.Close()
                End If

                '***************************************
                'EXCLUDE PSD Test & Software Refurbish
                '***************************************
                If iModelID = 0 Then Throw New Exception("System has failed to create/update model.")
                If Me.chkNoPSDTest.Visible = True OrElse Me.chkNoSWRef.Visible = True OrElse Me.chkBuffable.Visible = True Then
                    PSS.Data.Buisness.ModManuf.UpdateExcludePSDTestSofRef_Buffable(iModelID, Me.chkNoPSDTest.Checked, Me.chkNoSWRef.Checked, Me.chkBuffable.Checked, PSS.Core.ApplicationUser.IDuser)
                End If

                '***************************************

                Dim iCustomerID As Integer = Me.cboCustomer.SelectedValue
                Dim iModelFamilyID As Integer = Me.cboModelFamily.SelectedValue

                If iModelID <> 0 And iCustomerID <> 0 Then
                    'Update model family
                    PSS.Data.Buisness.ModManuf.UpdateModelFamily(iModelID, iCustomerID, iModelFamilyID)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Add/Update Model", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                objModManf = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
                Me.Cursor = Cursors.Default
            End Try
        End Sub
        Private Sub cboProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.SelectedIndexChanged
            If Me.cboProduct.Text <> "" Then
                Dim iProd_ID As Integer = Me.cboProduct.GetID
                PopulateGroups(iProd_ID)
                PopulateRptGroups(iProd_ID)
                PopulateAsc(iProd_ID)
            End If
        End Sub
        Private Sub chkmap_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkmap.CheckedChanged
            Try
                Me.txtItemNo.Text = ""
                Me.txtItemDesc.Text = ""
                Me.txtInSku.Text = ""
                Me.txtInSkuDesc.Text = ""
                Me.txtOutSku.Text = ""
                Me.txtOutSkuDesc.Text = ""
                Me.txtManufModelDesc.Text = ""
                Me._iPssCustMapID = 0

                If Me.chkmap.Checked = True Then
                    If Me.model > 0 AndAlso Me.cboCustomer.SelectedValue > 0 Then Me.PopulatePssCustModelMapData()

                    Me.gbMapCustModel.Visible = True
                    Me.txtItemNo.Focus()
                Else
                    Me.gbMapCustModel.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkmap_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub cboProduct_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProduct.SelectionChangeCommitted
            Dim dt As DataTable

            Try
                If Me.cboProduct.GetID > 0 Then
                    dt = PSS.Data.Buisness.Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                    Me.cboCustomer.SelectedValue = 0
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProduct_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub cboManuf_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboManuf.KeyUp
            If e.KeyCode = Keys.Enter AndAlso Me.cboManuf.SelectedValue > 0 And Me.cboManuf.SelectedValue = 1 Then PopulateAPCCodes()
        End Sub
        Private Sub cboCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
            Dim dt As DataTable
            Dim iModelID As Integer = 0

            Try
                Me.chkmap.Checked = False
                Me.chkNoPSDTest.Visible = False : Me.chkNoPSDTest.Checked = False
                Me.chkNoSWRef.Visible = False : Me.chkNoSWRef.Checked = False
                Me.chkBuffable.Visible = False : Me.chkBuffable.Checked = False
                Me.chkSWProcess.Visible = False : Me.chkKSCapable.Visible = False
                Me.chkTriage.Visible = False

                'If Me.model > 0 Then
                If Me.cboCustomer.SelectedValue = Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                    Me.chkNoPSDTest.Visible = True
                    Me.chkNoSWRef.Visible = True
                    Me.chkBuffable.Visible = True
                    Me.chkSWProcess.Visible = True
                    Me.chkKSCapable.Visible = True
                    Me.chkTriage.Visible = True
                    Dim objTFMis As New PSS.Data.Buisness.TracFone.clsMisc()
                    If objTFMis.IsNoPSDNeeded(Me.model) Then Me.chkNoPSDTest.Checked = True Else Me.chkNoPSDTest.Checked = False
                    If objTFMis.IsNoSoftwareRefNeeded(Me.model) Then Me.chkNoSWRef.Checked = True Else Me.chkNoSWRef.Checked = False
                    If objTFMis.IsBuffable(Me.model) Then Me.chkBuffable.Checked = True Else Me.chkBuffable.Checked = False
                    If objTFMis.IsTriageNeeded(Me.model) Then Me.chkTriage.Checked = True Else Me.chkTriage.Checked = False
                End If
                'End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCustomer.SelectedValueChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub txtManufModelDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManufModelDesc.KeyPress
            Try
                If Not (Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar) Or e.KeyChar.Equals("-")) Then
                    Beep()
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtManufModelDesc_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub txtModelShortDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtModelShortDesc.KeyPress
            Try
                If e.KeyChar.IsLetterOrDigit(e.KeyChar) = False AndAlso e.KeyChar.IsControl(e.KeyChar) = False AndAlso e.KeyChar.ToString.Equals(".") = False Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtMaxPriceToRep_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

#End Region
#Region "METHODS"

        Private Sub LoadFields()
            Dim dt As DataTable
            Try
                dt = ModManuf.GetModel(model)
                'Row 0 is being used because only one row is being returned at any time
                Me.cboProduct.Text = dt.Rows(0)("Product")
                Me.cboProduct.SelectedValue = dt.Rows(0)("Prod_ID")
                Me.PopulateAsc(dt.Rows(0)("Prod_ID"), dt.Rows(0)("ASCPrice_ID"))
                Me.txtModelDesc.Text = dt.Rows(0)("Description")
                Me.cboManuf.SelectedValue = dt.Rows(0)("Manuf_ID")
                If dt.Rows(0)("Manuf_ID") = 1 Then Me.PopulateAPCCodes(dt.Rows(0)("Dcode_ID"))
                If dt.Rows(0)("AltWrtyDateCode").ToString.Trim = "1" Then
                    Me.chkAltWrtyDateCodeLogic.Checked = True
                Else
                    Me.chkAltWrtyDateCodeLogic.Checked = False
                End If

                Me.cbHasBC.Checked = dt.Rows(0)("has_bc")
                If Me.cbHasBC.Checked Then
                    Me._bHas_BC_Old = True
                Else
                    Me._bHas_BC_Old = False
                End If

                If dt.Rows(0)("sw_process") = 1 Then Me.chkSWProcess.Checked = True Else Me.chkSWProcess.Checked = False
                If dt.Rows(0)("ks_capable") = 1 Then Me.chkKSCapable.Checked = True Else Me.chkKSCapable.Checked = False

                Dim item As PSS.Gui.Controls.ComboBoxItem
                '************************************************
                'Added by Asif on 12/04/2003
                '************************************************
                For Each item In Me.cboRptGrp.Items
                    If item.ID = dt.Rows(0)("Report Group") Then
                        Me.cboRptGrp.Text = item.ToString
                        Exit For
                    End If
                Next

                '************************************************
                For Each item In Me.cboFlat.Items
                    If item.ID = dt.Rows(0)("Flat Group") Then
                        Me.cboFlat.Text = item.ToString
                        Exit For                        'Added by Asif on 12/05/2003
                    End If
                Next
                For Each item In Me.cboTier.Items
                    If item.ID = dt.Rows(0)("Tier Group") Then
                        Me.cboTier.Text = item.ToString
                        Exit For                        'Added by Asif on 12/05/2003
                    End If
                Next

                '****************************************************
                '//Added by Lan 01/22/2007
                Me.cmbGSM.SelectedIndex = CInt(dt.Rows(0)("Model_GSM").ToString)
                Me.cmbModelType.SelectedIndex = CInt(dt.Rows(0)("Model_Type").ToString)
                Me.cboAPCCodes.SelectedValue = dt.Rows(0)("DCode_id")

                '//Added by Lan 01/22/2007
                '****************************************************
                Me.cboAccessoryCategory.SelectedValue = CInt(dt.Rows(0)("Accessory").ToString)

                If Not IsDBNull(dt.Rows(0)("Model_MotoSku").ToString) Then Me.txtModelShortDesc.Text = dt.Rows(0)("Model_MotoSku").ToString
                'If Me.txtModelShortDesc.Text.Trim.Length > 0 Then Me.txtModelShortDesc.Enabled = False
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub
        Private Sub PopulateProducts()
            'Me.cboProduct.Items.Clear()     'Added by Asif on 12/04/2003
            Dim dt As DataTable = ModManuf.GetProducts
            Dim r As DataRow
            For Each r In dt.Rows
                Me.cboProduct.AddItem(r(0), r(1))
            Next
            dt.Dispose()
            dt = Nothing
        End Sub
        Private Sub PopulateRptGroups(ByVal iProd_ID As Integer)
            Dim dt As DataTable
            Me.cboRptGrp.Items.Clear()
            Me.cboRptGrp.Text = ""
            Try
                dt = ModManuf.GetRptGrps(iProd_ID)
                Dim r As DataRow
                For Each r In dt.Rows
                    Me.cboRptGrp.AddItem(r(0), r(1))
                Next
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub
        Private Sub PopulateGroups(Optional ByVal iProd_ID As Integer = 0)
            Dim dt As DataTable
            Me.cboFlat.Items.Clear()
            Me.cboFlat.Text = ""
            Me.cboTier.Items.Clear()
            Me.cboTier.Text = ""
            Try
                'dt = ModManuf.GetProdGrps(Me.model)
                dt = ModManuf.GetProdGrps(iProd_ID)
                Dim r As DataRow
                For Each r In dt.Rows
                    Me.cboFlat.AddItem(r(0), r(1))
                    Me.cboTier.AddItem(r(0), r(1))
                Next
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub
        Private Sub PopulateAsc(ByVal iProd_ID As Integer, Optional ByVal iASCPriceID As Integer = 0)
            Dim dt As DataTable
            Try
                Me.cboAsc.DataSource = Nothing
                dt = ModManuf.GetASC(iProd_ID)
                Misc.PopulateC1DropDownList(Me.cboAsc, dt, "ASCPrice_Desc", "ASCPrice_ID")
                Me.cboAsc.SelectedValue = iASCPriceID
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateAsc", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        Private Sub PopulateAPCCodes(Optional ByVal iDcodeID As Integer = 0)
            Dim dt1 As DataTable
            Dim objMclaim As New PSS.Data.Buisness.WarrantyClaim.MClaim()

            Try
                Me.cboAPCCodes.DataSource = Nothing
                If Me.cboManuf.SelectedValue = 1 Then        'For motorola phones only
                    dt1 = objMclaim.GetAllMotorolaAPCCodes
                    Misc.PopulateC1DropDownList(Me.cboAPCCodes, dt1, "dcode_sdesc", "dcode_id")
                    Me.cboAPCCodes.SelectedValue = iDcodeID
                End If
            Catch ex As Exception
                Throw ex
            Finally
                objMclaim = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
            End Try
        End Sub
        Private Sub PopulatePssCustModelMapData()
            Dim dt As DataTable

            Try
                If Me.model > 0 Then
                    dt = PSS.Data.Buisness.ModManuf.GetPSSCustModelMap(Me.model, Me.cboCustomer.SelectedValue)
                    If dt.Rows.Count > 0 Then
                        Me._iPssCustMapID = dt.Rows(0)("cm_id")
                        If Not IsDBNull(dt.Rows(0)("cust_model_number")) Then Me.txtItemNo.Text = dt.Rows(0)("cust_model_number") Else Me.txtItemNo.Text = ""
                        If Not IsDBNull(dt.Rows(0)("cust_model_desc")) Then Me.txtItemDesc.Text = dt.Rows(0)("cust_model_desc") Else Me.txtItemDesc.Text = ""

                        If Not IsDBNull(dt.Rows(0)("cust_IncomingSku")) Then Me.txtInSku.Text = dt.Rows(0)("cust_IncomingSku") Else Me.txtInSku.Text = ""
                        If Not IsDBNull(dt.Rows(0)("cust_IncomingDesc")) Then Me.txtInSkuDesc.Text = dt.Rows(0)("cust_IncomingDesc") Else Me.txtInSkuDesc.Text = ""

                        If Not IsDBNull(dt.Rows(0)("cust_OutgoingSku")) Then Me.txtOutSku.Text = dt.Rows(0)("cust_OutgoingSku") Else Me.txtOutSku.Text = ""
                        If Not IsDBNull(dt.Rows(0)("cust_OutgoingDesc")) Then Me.txtOutSkuDesc.Text = dt.Rows(0)("cust_OutgoingDesc") Else Me.txtOutSkuDesc.Text = ""
                        If Not IsDBNull(dt.Rows(0)("Manuf_ModelDesc")) Then Me.txtManufModelDesc.Text = dt.Rows(0)("Manuf_ModelDesc") Else Me.txtManufModelDesc.Text = ""
                        If Not IsDBNull(dt.Rows(0)("ModelFamiliesID")) Then Me.cboCustMapFamily.SelectedValue = dt.Rows(0)("ModelFamiliesID") Else Me.cboCustMapFamily.SelectedValue = 0
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

#End Region
    End Class
End Namespace
