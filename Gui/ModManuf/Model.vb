Imports PSS.Rules

Namespace Gui

    Public Class Model
        Inherits System.Windows.Forms.Form

        Private model As Integer
        Private _iPssCustMapID As Integer = 0
        Public _booCancel As Boolean = True

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
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
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
        Friend WithEvents chkAutoBill As System.Windows.Forms.CheckBox
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
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Model))
            Me.lblModel = New System.Windows.Forms.Label()
            Me.txtModelDesc = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboTier = New PSS.Gui.Controls.ComboBox()
            Me.cboFlat = New PSS.Gui.Controls.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblASC = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.cboProduct = New PSS.Gui.Controls.ComboBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboRptGrp = New PSS.Gui.Controls.ComboBox()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.cmbGSM = New PSS.Gui.Controls.ComboBox()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cmbModelType = New PSS.Gui.Controls.ComboBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.chkAutoBill = New System.Windows.Forms.CheckBox()
            Me.chkmap = New System.Windows.Forms.CheckBox()
            Me.gbMapCustModel = New System.Windows.Forms.GroupBox()
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
            Me.gbMapCustModel.SuspendLayout()
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
            Me.lblModel.Location = New System.Drawing.Point(8, 106)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(112, 16)
            Me.lblModel.TabIndex = 0
            Me.lblModel.Text = "Model Description:"
            '
            'txtModelDesc
            '
            Me.txtModelDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtModelDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtModelDesc.Location = New System.Drawing.Point(8, 120)
            Me.txtModelDesc.Name = "txtModelDesc"
            Me.txtModelDesc.Size = New System.Drawing.Size(288, 21)
            Me.txtModelDesc.TabIndex = 2
            Me.txtModelDesc.Text = ""
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(8, 146)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(120, 16)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Tier Product Group:"
            '
            'cboTier
            '
            Me.cboTier.Location = New System.Drawing.Point(8, 160)
            Me.cboTier.Name = "cboTier"
            Me.cboTier.Size = New System.Drawing.Size(288, 21)
            Me.cboTier.TabIndex = 3
            '
            'cboFlat
            '
            Me.cboFlat.Location = New System.Drawing.Point(8, 200)
            Me.cboFlat.Name = "cboFlat"
            Me.cboFlat.Size = New System.Drawing.Size(288, 21)
            Me.cboFlat.TabIndex = 4
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(8, 186)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(120, 16)
            Me.Label2.TabIndex = 4
            Me.Label2.Text = "Flat Product Group:"
            '
            'lblASC
            '
            Me.lblASC.Location = New System.Drawing.Point(328, 27)
            Me.lblASC.Name = "lblASC"
            Me.lblASC.Size = New System.Drawing.Size(120, 16)
            Me.lblASC.TabIndex = 6
            Me.lblASC.Text = "ASC Code:"
            '
            'Button1
            '
            Me.Button1.BackColor = System.Drawing.Color.SteelBlue
            Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button1.ForeColor = System.Drawing.Color.White
            Me.Button1.Location = New System.Drawing.Point(160, 616)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(120, 24)
            Me.Button1.TabIndex = 13
            Me.Button1.Text = "Add / Update"
            '
            'Button2
            '
            Me.Button2.BackColor = System.Drawing.Color.SlateGray
            Me.Button2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.ForeColor = System.Drawing.Color.White
            Me.Button2.Location = New System.Drawing.Point(360, 616)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(120, 24)
            Me.Button2.TabIndex = 14
            Me.Button2.Text = "Cancel"
            '
            'cboProduct
            '
            Me.cboProduct.Location = New System.Drawing.Point(8, 80)
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.Size = New System.Drawing.Size(288, 21)
            Me.cboProduct.TabIndex = 1
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(8, 66)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(120, 16)
            Me.Label4.TabIndex = 10
            Me.Label4.Text = "Product Type:"
            '
            'cboRptGrp
            '
            Me.cboRptGrp.Location = New System.Drawing.Point(9, 240)
            Me.cboRptGrp.Name = "cboRptGrp"
            Me.cboRptGrp.Size = New System.Drawing.Size(287, 21)
            Me.cboRptGrp.TabIndex = 5
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(9, 226)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(120, 16)
            Me.Label5.TabIndex = 12
            Me.Label5.Text = "Report Group"
            '
            'cmbGSM
            '
            Me.cmbGSM.Items.AddRange(New Object() {"NON-GSM", "GSM"})
            Me.cmbGSM.Location = New System.Drawing.Point(328, 80)
            Me.cmbGSM.Name = "cmbGSM"
            Me.cmbGSM.Size = New System.Drawing.Size(288, 21)
            Me.cmbGSM.TabIndex = 7
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(328, 64)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(120, 16)
            Me.Label6.TabIndex = 21
            Me.Label6.Text = "GSM:"
            '
            'cmbModelType
            '
            Me.cmbModelType.Items.AddRange(New Object() {"Non-Wipe Down", "Wipe Down"})
            Me.cmbModelType.Location = New System.Drawing.Point(328, 120)
            Me.cmbModelType.Name = "cmbModelType"
            Me.cmbModelType.Size = New System.Drawing.Size(288, 21)
            Me.cmbModelType.TabIndex = 8
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(328, 107)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(120, 16)
            Me.Label7.TabIndex = 23
            Me.Label7.Text = "Model Type:"
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(328, 147)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(120, 16)
            Me.Label3.TabIndex = 21
            Me.Label3.Text = "APC Code:"
            '
            'chkAutoBill
            '
            Me.chkAutoBill.Location = New System.Drawing.Point(328, 288)
            Me.chkAutoBill.Name = "chkAutoBill"
            Me.chkAutoBill.Size = New System.Drawing.Size(200, 24)
            Me.chkAutoBill.TabIndex = 11
            Me.chkAutoBill.Text = "Model can be auto billed"
            Me.chkAutoBill.Visible = False
            '
            'chkmap
            '
            Me.chkmap.Location = New System.Drawing.Point(328, 320)
            Me.chkmap.Name = "chkmap"
            Me.chkmap.Size = New System.Drawing.Size(280, 16)
            Me.chkmap.TabIndex = 12
            Me.chkmap.Text = "Map Customer Model"
            '
            'gbMapCustModel
            '
            Me.gbMapCustModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtManufModelDesc, Me.lblManufModelDesc, Me.txtOutSkuDesc, Me.Label13, Me.txtOutSku, Me.Label14, Me.txtInSkuDesc, Me.Label11, Me.txtItemDesc, Me.Label12, Me.txtInSku, Me.Label10, Me.txtItemNo, Me.Label9, Me.cboCustomer, Me.Label8})
            Me.gbMapCustModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbMapCustModel.Location = New System.Drawing.Point(8, 344)
            Me.gbMapCustModel.Name = "gbMapCustModel"
            Me.gbMapCustModel.Size = New System.Drawing.Size(616, 256)
            Me.gbMapCustModel.TabIndex = 12
            Me.gbMapCustModel.TabStop = False
            Me.gbMapCustModel.Text = "Customer Item Info"
            Me.gbMapCustModel.Visible = False
            '
            'txtManufModelDesc
            '
            Me.txtManufModelDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtManufModelDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtManufModelDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtManufModelDesc.Location = New System.Drawing.Point(184, 224)
            Me.txtManufModelDesc.Name = "txtManufModelDesc"
            Me.txtManufModelDesc.Size = New System.Drawing.Size(424, 21)
            Me.txtManufModelDesc.TabIndex = 97
            Me.txtManufModelDesc.Text = ""
            '
            'lblManufModelDesc
            '
            Me.lblManufModelDesc.Location = New System.Drawing.Point(184, 208)
            Me.lblManufModelDesc.Name = "lblManufModelDesc"
            Me.lblManufModelDesc.Size = New System.Drawing.Size(232, 16)
            Me.lblManufModelDesc.TabIndex = 98
            Me.lblManufModelDesc.Text = "Manufacturer's Model Description:"
            '
            'txtOutSkuDesc
            '
            Me.txtOutSkuDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutSkuDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtOutSkuDesc.Location = New System.Drawing.Point(184, 173)
            Me.txtOutSkuDesc.Name = "txtOutSkuDesc"
            Me.txtOutSkuDesc.Size = New System.Drawing.Size(424, 21)
            Me.txtOutSkuDesc.TabIndex = 7
            Me.txtOutSkuDesc.Text = ""
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(184, 157)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(384, 16)
            Me.Label13.TabIndex = 96
            Me.Label13.Text = "Out Going Sku Description:"
            '
            'txtOutSku
            '
            Me.txtOutSku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtOutSku.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtOutSku.Location = New System.Drawing.Point(8, 173)
            Me.txtOutSku.Name = "txtOutSku"
            Me.txtOutSku.Size = New System.Drawing.Size(152, 21)
            Me.txtOutSku.TabIndex = 6
            Me.txtOutSku.Text = ""
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(8, 157)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(152, 16)
            Me.Label14.TabIndex = 94
            Me.Label14.Text = "Out Going Sku:"
            '
            'txtInSkuDesc
            '
            Me.txtInSkuDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInSkuDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtInSkuDesc.Location = New System.Drawing.Point(184, 125)
            Me.txtInSkuDesc.Name = "txtInSkuDesc"
            Me.txtInSkuDesc.Size = New System.Drawing.Size(424, 21)
            Me.txtInSkuDesc.TabIndex = 5
            Me.txtInSkuDesc.Text = ""
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(184, 109)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(424, 16)
            Me.Label11.TabIndex = 92
            Me.Label11.Text = "Incoming Sku Description:  "
            '
            'txtItemDesc
            '
            Me.txtItemDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtItemDesc.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtItemDesc.Location = New System.Drawing.Point(184, 77)
            Me.txtItemDesc.Name = "txtItemDesc"
            Me.txtItemDesc.Size = New System.Drawing.Size(424, 21)
            Me.txtItemDesc.TabIndex = 3
            Me.txtItemDesc.Text = ""
            '
            'Label12
            '
            Me.Label12.Location = New System.Drawing.Point(184, 61)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(424, 16)
            Me.Label12.TabIndex = 90
            Me.Label12.Text = "Item Description:"
            '
            'txtInSku
            '
            Me.txtInSku.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtInSku.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtInSku.Location = New System.Drawing.Point(8, 125)
            Me.txtInSku.Name = "txtInSku"
            Me.txtInSku.Size = New System.Drawing.Size(152, 21)
            Me.txtInSku.TabIndex = 4
            Me.txtInSku.Text = ""
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(8, 109)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(152, 16)
            Me.Label10.TabIndex = 88
            Me.Label10.Text = "Incoming Sku:"
            '
            'txtItemNo
            '
            Me.txtItemNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.txtItemNo.Cursor = System.Windows.Forms.Cursors.IBeam
            Me.txtItemNo.Location = New System.Drawing.Point(8, 77)
            Me.txtItemNo.Name = "txtItemNo"
            Me.txtItemNo.Size = New System.Drawing.Size(152, 21)
            Me.txtItemNo.TabIndex = 2
            Me.txtItemNo.Text = ""
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(8, 61)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(152, 16)
            Me.Label9.TabIndex = 86
            Me.Label9.Text = "Item #:"
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
            Me.cboCustomer.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboCustomer.ItemHeight = 15
            Me.cboCustomer.Location = New System.Drawing.Point(10, 36)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(598, 21)
            Me.cboCustomer.TabIndex = 1
            Me.cboCustomer.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(8, 20)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(304, 16)
            Me.Label8.TabIndex = 85
            Me.Label8.Text = "Select Customer And Press Enter :"
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
            Me.cboManuf.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboManuf.ItemHeight = 15
            Me.cboManuf.Location = New System.Drawing.Point(8, 40)
            Me.cboManuf.MatchEntryTimeout = CType(2000, Long)
            Me.cboManuf.MaxDropDownItems = CType(10, Short)
            Me.cboManuf.MaxLength = 32767
            Me.cboManuf.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboManuf.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboManuf.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboManuf.Size = New System.Drawing.Size(288, 21)
            Me.cboManuf.TabIndex = 0
            Me.cboManuf.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label15
            '
            Me.Label15.BackColor = System.Drawing.Color.Transparent
            Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label15.ForeColor = System.Drawing.Color.Black
            Me.Label15.Location = New System.Drawing.Point(8, 26)
            Me.Label15.Name = "Label15"
            Me.Label15.Size = New System.Drawing.Size(288, 16)
            Me.Label15.TabIndex = 87
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
            Me.lblInstruction.TabIndex = 88
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
            Me.cboAPCCodes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboAPCCodes.ItemHeight = 15
            Me.cboAPCCodes.Location = New System.Drawing.Point(328, 160)
            Me.cboAPCCodes.MatchEntryTimeout = CType(2000, Long)
            Me.cboAPCCodes.MaxDropDownItems = CType(10, Short)
            Me.cboAPCCodes.MaxLength = 32767
            Me.cboAPCCodes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboAPCCodes.Name = "cboAPCCodes"
            Me.cboAPCCodes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboAPCCodes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboAPCCodes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboAPCCodes.Size = New System.Drawing.Size(288, 21)
            Me.cboAPCCodes.TabIndex = 9
            Me.cboAPCCodes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.cboAsc.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboAsc.ItemHeight = 15
            Me.cboAsc.Location = New System.Drawing.Point(328, 40)
            Me.cboAsc.MatchEntryTimeout = CType(2000, Long)
            Me.cboAsc.MaxDropDownItems = CType(10, Short)
            Me.cboAsc.MaxLength = 32767
            Me.cboAsc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboAsc.Name = "cboAsc"
            Me.cboAsc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboAsc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboAsc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboAsc.Size = New System.Drawing.Size(288, 21)
            Me.cboAsc.TabIndex = 6
            Me.cboAsc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            Me.cboAccessoryCategory.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboAccessoryCategory.ItemHeight = 15
            Me.cboAccessoryCategory.Location = New System.Drawing.Point(328, 200)
            Me.cboAccessoryCategory.MatchEntryTimeout = CType(2000, Long)
            Me.cboAccessoryCategory.MaxDropDownItems = CType(10, Short)
            Me.cboAccessoryCategory.MaxLength = 32767
            Me.cboAccessoryCategory.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboAccessoryCategory.Name = "cboAccessoryCategory"
            Me.cboAccessoryCategory.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboAccessoryCategory.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboAccessoryCategory.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboAccessoryCategory.Size = New System.Drawing.Size(288, 21)
            Me.cboAccessoryCategory.TabIndex = 10
            Me.cboAccessoryCategory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label16
            '
            Me.Label16.Location = New System.Drawing.Point(328, 186)
            Me.Label16.Name = "Label16"
            Me.Label16.Size = New System.Drawing.Size(120, 16)
            Me.Label16.TabIndex = 90
            Me.Label16.Text = "Accessory Category:"
            '
            'lblModelFamily
            '
            Me.lblModelFamily.Location = New System.Drawing.Point(328, 224)
            Me.lblModelFamily.Name = "lblModelFamily"
            Me.lblModelFamily.Size = New System.Drawing.Size(120, 16)
            Me.lblModelFamily.TabIndex = 91
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
            Me.cboModelFamily.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboModelFamily.ItemHeight = 15
            Me.cboModelFamily.Location = New System.Drawing.Point(328, 240)
            Me.cboModelFamily.MatchEntryTimeout = CType(2000, Long)
            Me.cboModelFamily.MaxDropDownItems = CType(10, Short)
            Me.cboModelFamily.MaxLength = 32767
            Me.cboModelFamily.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModelFamily.Name = "cboModelFamily"
            Me.cboModelFamily.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModelFamily.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModelFamily.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModelFamily.Size = New System.Drawing.Size(288, 21)
            Me.cboModelFamily.TabIndex = 92
            Me.cboModelFamily.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Model
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 14)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(634, 656)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModelFamily, Me.lblModelFamily, Me.cboAccessoryCategory, Me.Label16, Me.cboAsc, Me.cboAPCCodes, Me.lblInstruction, Me.cboManuf, Me.Label15, Me.gbMapCustModel, Me.chkmap, Me.chkAutoBill, Me.Label3, Me.cboRptGrp, Me.Label5, Me.cboProduct, Me.Label4, Me.Button2, Me.Button1, Me.lblASC, Me.cboFlat, Me.Label2, Me.cboTier, Me.Label1, Me.txtModelDesc, Me.lblModel, Me.cmbModelType, Me.Label7, Me.Label6, Me.cmbGSM})
            Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
            Me.Name = "Model"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Model"
            Me.gbMapCustModel.ResumeLayout(False)
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboManuf, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboAPCCodes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboAsc, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboAccessoryCategory, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModelFamily, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '************************************************************************************************
        Private Sub Model_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

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

                dt = PSS.Data.Buisness.Generic.GetModelFamilies()
                Misc.PopulateC1DropDownList(Me.cboModelFamily, dt, "Model Family", "ModelFamiliesID")
                Me.cboModelFamily.SelectedValue = 0

                If model <> 0 Then
                    Me.LoadFields()
                    If Me.cboProduct.GetID > 0 Then
                        dt = PSS.Data.Buisness.Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                        Me.cboCustomer.SelectedValue = 0
                    End If

                    Dim iSelectedModelFamiliesID As Integer = PSS.Data.Buisness.Generic.GetModelFamiliesID(model)

                    If iSelectedModelFamiliesID > 0 Then Me.cboModelFamily.SelectedValue = iSelectedModelFamiliesID 'Select model in combo box 
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '************************************************************************************************
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
                If dt.Rows(0)("AutoBillFlg") = 1 Then
                    Me.chkAutoBill.Checked = True
                End If

                If Trim(Me.cboProduct.Text) = "Cellular" And Len(Trim(Me.txtModelDesc.Text)) >= 3 Then
                    If UCase(Mid(Trim(Me.txtModelDesc.Text), Len(Trim(Me.txtModelDesc.Text)) - 2, 3)) = "COE" Then
                        Me.chkAutoBill.Checked = False
                        Me.chkAutoBill.Visible = False
                    End If
                End If
                '//Added by Lan 01/22/2007
                '****************************************************
                Me.cboAccessoryCategory.SelectedValue = CInt(dt.Rows(0)("Accessory").ToString)
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            Finally
                dt.Dispose()
                dt = Nothing
            End Try
        End Sub

        '************************************************************************************************
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

        '************************************************************************************************
        'Added by Asif on 12/03/2003
        'This populates the "Report Groups" combo box
        '************************************************************************************************
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
        '************************************************************************************************
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

        '************************************************************************************************
        Private Sub PopulateAsc(ByVal iProd_ID As Integer, _
                                Optional ByVal iASCPriceID As Integer = 0)
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

        '************************************************************************************************
        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            Me.Close()
        End Sub

        '************************************************************************************************
        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim iGSM As Integer = 0
            Dim iModelType As Integer = 0
            Dim strModel_MotoSku, strModelDesc, strMaterialType, strCategory As String
            Dim objModManf As New PSS.Data.Buisness.ModManuf()
            Dim iAutoBill As Integer = 0
            Dim dt As DataTable
            Dim iModelID As Integer = 0
            Dim iDcodeID As Integer

            Try
                strModel_MotoSku = "" : strModelDesc = "" : strMaterialType = "" : strCategory = ""

                'Mandatory field validation
                If Me.cboManuf.SelectedValue = 0 Then
                    MsgBox("Please select a 'Manufactuer'.", MsgBoxStyle.Exclamation)
                    Me.cboManuf.Focus()
                    Exit Sub
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
                ElseIf Me.chkmap.Checked = True Then
                    If Me.cboCustomer.SelectedValue = 0 Then
                        MsgBox("Please select 'Customer'.", MsgBoxStyle.Exclamation)
                        Me.cboCustomer.Focus()
                        Exit Sub
                    ElseIf Me.txtItemNo.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item #'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus()
                        Exit Sub
                    ElseIf Me.txtItemDesc.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Description'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus()
                        Exit Sub
                    ElseIf Me.txtInSku.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Incoming Sku'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus()
                        Exit Sub
                    ElseIf Me.txtInSkuDesc.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Incoming Sku Description'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus()
                        Exit Sub
                    ElseIf Me.txtOutSku.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Outgoing Sku'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus()
                        Exit Sub
                    ElseIf Me.txtOutSkuDesc.Text.Trim.Length = 0 Then
                        MsgBox("Please enter 'Item Incoming Sku Description'.", MsgBoxStyle.Exclamation)
                        Me.txtItemNo.Focus()
                        Exit Sub
                    ElseIf Me.txtManufModelDesc.Text.Trim.Length = 0 Then
                        MsgBox("Please enter a manufacturer's model description.", MsgBoxStyle.Exclamation)
                        Me.txtManufModelDesc.Focus()
                        Exit Sub
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

                    '***************************
                    'Validate Wipe Down 
                    '***************************
                    If Me.cmbModelType.Text = "Wipe Down" Then
                        If Len(Trim(Me.txtModelDesc.Text)) <= 3 Then
                            MsgBox("Please check model description. Wipe Down model description must contain '-WD' at the end.", MsgBoxStyle.Exclamation)
                            Me.cmbModelType.Text = ""
                            Exit Sub
                        ElseIf UCase(Mid(Trim(Me.txtModelDesc.Text), Trim(Me.txtModelDesc.Text).Length - 2)) <> "-WD" Then
                            MsgBox("Please check model description. Wipe Down model description must contain '-WD' at the end.", MsgBoxStyle.Exclamation)
                            Me.cmbModelType.Text = ""
                            Exit Sub
                        End If

                    ElseIf Me.cmbModelType.Text = "Non-Wipe Down" Then
                        If Len(Trim(Me.txtModelDesc.Text)) >= 3 Then
                            If UCase(Mid(Trim(Me.txtModelDesc.Text), Trim(Me.txtModelDesc.Text).Length - 2)) = "-WD" Then
                                MsgBox("Please check model description. Non-Wipe Down model description can not contain '-WD' at the end.", MsgBoxStyle.Exclamation)
                                Me.cmbModelType.Text = ""
                                Exit Sub
                            End If
                        End If
                    Else
                        MsgBox("Please select Model Type", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If

                    iModelType = Me.cmbModelType.SelectedIndex
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
                        Me.PopulateAPCCodes()
                    End If
                Else
                    iDcodeID = Me.cboAPCCodes.SelectedValue
                End If
                '**********************************************************

                If Me.chkAutoBill.Checked = True Then
                    iAutoBill = 1
                End If

                If Me.model <> 0 Then       'updating an existing model
                    iModelID = Me.model
                    ModManuf.DoUpdateModel(Me.model, Me.txtModelDesc.Text, Me.cboTier.GetID, _
                                           Me.cboFlat.GetID, Me.cboManuf.SelectedValue, Me.cboProduct.GetID, _
                                           Me.cboAsc.SelectedValue, Me.cboRptGrp.GetID, iDcodeID, _
                                           iGSM, iModelType, iAutoBill, Me.cboAccessoryCategory.SelectedValue)

                    '************************************
                    'Map Pss Model and customer Model
                    '************************************
                    If Me.chkmap.Checked = True Then
                        PSS.Data.Buisness.ModManuf.MapPssCustModel(Me._iPssCustMapID, Me.cboCustomer.SelectedValue, iModelID, _
                                                  Me.txtItemNo.Text.Trim, Me.txtItemDesc.Text.Trim, _
                                                  Me.txtInSku.Text.Trim, Me.txtInSkuDesc.Text, _
                                                  Me.txtOutSku.Text.Trim, Me.txtOutSkuDesc.Text, strMaterialType, strCategory, _
                                                  Me.txtManufModelDesc.Text.Trim)

                    End If
                    '************************************

                    _booCancel = False
                    Me.Close()
                Else                        'Adding a new model
                    '**********************************************************
                    'Generate tmodel.Model_MotoSku, added by Lan on 02/23/2007
                    '**********************************************************
                    strModelDesc = UCase(Trim(Me.txtModelDesc.Text))
                    strModelDesc = Replace(strModelDesc, "-", "", 1) 'replace '-' with empty
                    strModelDesc = Replace(strModelDesc, " ", "", 1) 'replace space with empty

                    strModel_MotoSku = Microsoft.VisualBasic.Left(strModelDesc, 6)

                    strModel_MotoSku = objModManf.ValidateModel_MotoSku(strModel_MotoSku)

                    If strModel_MotoSku = "" Then
                        MsgBox("Can not define model description for shipping screen. Contact IT.", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If
                    '**********************************************************

                    iModelID = ModManuf.InsertModel(Me.txtModelDesc.Text, Me.cboTier.GetID, Me.cboFlat.GetID, _
                                         Me.cboManuf.SelectedValue, Me.cboProduct.GetID, Me.cboAsc.SelectedValue, _
                                         Me.cboRptGrp.GetID, iDcodeID, iGSM, iModelType, _
                                         strModel_MotoSku, iAutoBill, Me.cboAccessoryCategory.SelectedValue)

                    '************************************
                    'Map Pss Model and customer Model
                    '************************************
                    If Me.chkmap.Checked = True Then
                        If iModelID = 0 Then Throw New Exception("System has failed to create model.")
                        PSS.Data.Buisness.ModManuf.MapPssCustModel(Me._iPssCustMapID, Me.cboCustomer.SelectedValue, iModelID, _
                                                 Me.txtItemNo.Text.Trim, Me.txtItemDesc.Text.Trim, _
                                                 Me.txtInSku.Text.Trim, Me.txtInSkuDesc.Text, _
                                                 Me.txtOutSku.Text.Trim, Me.txtOutSkuDesc.Text, strMaterialType, strCategory, _
                                                 Me.txtManufModelDesc.Text.Trim)

                    End If
                    '************************************

                    _booCancel = False
                    Me.Close()
                End If

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
            End Try
        End Sub

        '**********************************************************************
        'Added by Asif on 12/03/2003
        'This is the change event of combo box cboProduct. 
        'Depending on the selection combo box APC is made visible or invisible.
        '**********************************************************************
        Private Sub cboProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.SelectedIndexChanged
            If Me.cboProduct.Text <> "" Then
                Dim iProd_ID As Integer = Me.cboProduct.GetID
                PopulateGroups(iProd_ID)
                PopulateRptGroups(iProd_ID)
                PopulateAsc(iProd_ID)
            End If
        End Sub

        '************************************************************************************************
        'Added by Asif on 01/22/2007
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

        '************************************************************************************************
        Private Sub cmbModelType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModelType.SelectedIndexChanged
            If Me.cmbModelType.SelectedIndex = 0 Then
                Me.chkAutoBill.Visible = True
            Else
                Me.chkAutoBill.Checked = False
                Me.chkAutoBill.Visible = False
            End If
        End Sub

        '************************************************************************************************
        Private Sub txtModelDesc_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtModelDesc.Leave
            If Trim(Me.cboProduct.Text) = "Cellular" And Len(Trim(Me.txtModelDesc.Text)) >= 3 Then
                If UCase(Mid(Trim(Me.txtModelDesc.Text), Len(Trim(Me.txtModelDesc.Text)) - 2, 3)) = "COE" Then
                    Me.chkAutoBill.Checked = False
                    Me.chkAutoBill.Visible = False
                Else
                    Me.chkAutoBill.Visible = True
                End If
            Else
                Me.chkAutoBill.Visible = True
            End If
        End Sub

        '************************************************************************************************
        Private Sub chkmap_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkmap.CheckedChanged
            Try
                Me.cboCustomer.SelectedValue = 0
                Me.txtItemNo.Text = ""
                Me.txtItemDesc.Text = ""
                Me.txtInSku.Text = ""
                Me.txtInSkuDesc.Text = ""
                Me.txtOutSku.Text = ""
                Me.txtOutSkuDesc.Text = ""

                If Me.chkmap.Checked = True Then
                    Me.gbMapCustModel.Visible = True
                    Me.cboCustomer.Focus()
                Else
                    Me.gbMapCustModel.Visible = False
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "chkmap_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '************************************************************************************************
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

        '************************************************************************************************
        Private Sub cboManuf_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboManuf.KeyUp
            If e.KeyCode = Keys.Enter AndAlso Me.cboManuf.SelectedValue > 0 And Me.cboManuf.SelectedValue = 1 Then PopulateAPCCodes()
        End Sub

        '************************************************************************************************
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
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '************************************************************************************************
        Private Sub cboCustomer_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.Leave
            Dim dt As DataTable
            Dim iModelID As Integer = 0

            Try
                If Me.model > 0 AndAlso Me.chkmap.Checked = True AndAlso Me.cboCustomer.SelectedValue > 0 Then
                    Me.PopulatePssCustModelMapData()
                ElseIf Me.cboCustomer.SelectedValue = 0 Then
                    Me._iPssCustMapID = 0
                    Me.txtItemNo.Text = ""
                    Me.txtItemDesc.Text = ""
                    Me.txtInSku.Text = ""
                    Me.txtInSkuDesc.Text = ""
                    Me.txtOutSku.Text = ""
                    Me.txtOutSkuDesc.Text = ""
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboCustomer_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '************************************************************************************************

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
    End Class

End Namespace
