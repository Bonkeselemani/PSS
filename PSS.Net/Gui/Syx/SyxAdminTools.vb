Option Explicit On 
Imports PSS.Data.Buisness

Namespace Gui

    Public Class SyxAdminTools
        Inherits System.Windows.Forms.Form
        Private _objSyx As PSS.Data.Buisness.Syx
        Private _objSyxRec As PSS.Data.Buisness.SyxReceivingShipping
        'Private _objProdRec As PSS.Data.Production.Receiving
        Private _booLoadData As Boolean = False
        Private _oriProductID As Integer
        Private _oriMfgID As Integer

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._objSyx = New PSS.Data.Buisness.Syx()
            Me._objSyxRec = New PSS.Data.Buisness.SyxReceivingShipping()

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
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tpUpdateModel As System.Windows.Forms.TabPage
        Friend WithEvents Label_Model As System.Windows.Forms.Label
        Friend WithEvents Label_Product As System.Windows.Forms.Label
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents Label_Mfg As System.Windows.Forms.Label
        Friend WithEvents cboMfg As C1.Win.C1List.C1Combo
        Friend WithEvents Label_UpdateModelDesc As System.Windows.Forms.Label
        Friend WithEvents btnUpdateModelDesc As System.Windows.Forms.Button
        Friend WithEvents Label_UpdateModelQty As System.Windows.Forms.Label
        Friend WithEvents btnUpdateModelQty As System.Windows.Forms.Button
        Friend WithEvents cboModelsDesc As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label_OpenPallet As System.Windows.Forms.Label
        Friend WithEvents cboOpenPallets As C1.Win.C1List.C1Combo
        Friend WithEvents Label_PalletModel As System.Windows.Forms.Label
        Friend WithEvents Label_PalletModelNewQty As System.Windows.Forms.Label
        Friend WithEvents cboPalletModel As C1.Win.C1List.C1Combo
        Friend WithEvents txtNewQuantity As System.Windows.Forms.TextBox
        Friend WithEvents Panel_UpdateQty As System.Windows.Forms.Panel
        Friend WithEvents Panel_UpdateModelDesc As System.Windows.Forms.Panel
        Friend WithEvents lblCurrentValue As System.Windows.Forms.Label
        Friend WithEvents LabelPalletModelCurrentValue As System.Windows.Forms.Label
        Friend WithEvents lblCurrentQty As System.Windows.Forms.Label
        Friend WithEvents Label_PalletModelCurrentQty As System.Windows.Forms.Label
        Friend WithEvents tpChangeModel As System.Windows.Forms.TabPage
        Friend WithEvents Panel_ChangeModel As System.Windows.Forms.Panel
        Friend WithEvents Label_ChangeModel As System.Windows.Forms.Label
        Friend WithEvents Label_ChangeModelSerial As System.Windows.Forms.Label
        Friend WithEvents Label_ChangeModelModel As System.Windows.Forms.Label
        Friend WithEvents Label_ChangeModelPallet As System.Windows.Forms.Label
        Friend WithEvents cboChangeModelPallet As C1.Win.C1List.C1Combo
        Friend WithEvents cboChangeModelModel As C1.Win.C1List.C1Combo
        Friend WithEvents btnChangeModelSerial As System.Windows.Forms.Button
        Friend WithEvents txtChangeModelSerial As System.Windows.Forms.TextBox
        Friend WithEvents tpChangeUnderValue As System.Windows.Forms.TabPage
        Friend WithEvents Panel_ChangeUnderValue As System.Windows.Forms.Panel
        Friend WithEvents Label_ChangeUnderValue As System.Windows.Forms.Label
        Friend WithEvents Label_UnderValue As System.Windows.Forms.Label
        Friend WithEvents txtNewUnderValue As System.Windows.Forms.TextBox
        Friend WithEvents Label_NewUnderValue As System.Windows.Forms.Label
        Friend WithEvents lblCurrentUnderValue As System.Windows.Forms.Label
        Friend WithEvents btnChangeUnderValue As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SyxAdminTools))
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tpUpdateModel = New System.Windows.Forms.TabPage()
            Me.Panel_UpdateQty = New System.Windows.Forms.Panel()
            Me.lblCurrentValue = New System.Windows.Forms.Label()
            Me.LabelPalletModelCurrentValue = New System.Windows.Forms.Label()
            Me.Label_OpenPallet = New System.Windows.Forms.Label()
            Me.cboOpenPallets = New C1.Win.C1List.C1Combo()
            Me.lblCurrentQty = New System.Windows.Forms.Label()
            Me.txtNewQuantity = New System.Windows.Forms.TextBox()
            Me.btnUpdateModelQty = New System.Windows.Forms.Button()
            Me.Label_PalletModel = New System.Windows.Forms.Label()
            Me.Label_PalletModelNewQty = New System.Windows.Forms.Label()
            Me.Label_PalletModelCurrentQty = New System.Windows.Forms.Label()
            Me.cboPalletModel = New C1.Win.C1List.C1Combo()
            Me.Label_UpdateModelQty = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.Panel_UpdateModelDesc = New System.Windows.Forms.Panel()
            Me.btnUpdateModelDesc = New System.Windows.Forms.Button()
            Me.Label_Model = New System.Windows.Forms.Label()
            Me.Label_Mfg = New System.Windows.Forms.Label()
            Me.Label_Product = New System.Windows.Forms.Label()
            Me.cboModelsDesc = New C1.Win.C1List.C1Combo()
            Me.cboMfg = New C1.Win.C1List.C1Combo()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.Label_UpdateModelDesc = New System.Windows.Forms.Label()
            Me.tpChangeModel = New System.Windows.Forms.TabPage()
            Me.Panel_ChangeModel = New System.Windows.Forms.Panel()
            Me.cboChangeModelModel = New C1.Win.C1List.C1Combo()
            Me.Label_ChangeModel = New System.Windows.Forms.Label()
            Me.Label_ChangeModelSerial = New System.Windows.Forms.Label()
            Me.txtChangeModelSerial = New System.Windows.Forms.TextBox()
            Me.Label_ChangeModelModel = New System.Windows.Forms.Label()
            Me.Label_ChangeModelPallet = New System.Windows.Forms.Label()
            Me.cboChangeModelPallet = New C1.Win.C1List.C1Combo()
            Me.btnChangeModelSerial = New System.Windows.Forms.Button()
            Me.tpChangeUnderValue = New System.Windows.Forms.TabPage()
            Me.Panel_ChangeUnderValue = New System.Windows.Forms.Panel()
            Me.Label_NewUnderValue = New System.Windows.Forms.Label()
            Me.lblCurrentUnderValue = New System.Windows.Forms.Label()
            Me.Label_ChangeUnderValue = New System.Windows.Forms.Label()
            Me.Label_UnderValue = New System.Windows.Forms.Label()
            Me.txtNewUnderValue = New System.Windows.Forms.TextBox()
            Me.btnChangeUnderValue = New System.Windows.Forms.Button()
            Me.TabControl1.SuspendLayout()
            Me.tpUpdateModel.SuspendLayout()
            Me.Panel_UpdateQty.SuspendLayout()
            CType(Me.cboOpenPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboPalletModel, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel_UpdateModelDesc.SuspendLayout()
            CType(Me.cboModelsDesc, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboMfg, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpChangeModel.SuspendLayout()
            Me.Panel_ChangeModel.SuspendLayout()
            CType(Me.cboChangeModelModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboChangeModelPallet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tpChangeUnderValue.SuspendLayout()
            Me.Panel_ChangeUnderValue.SuspendLayout()
            Me.SuspendLayout()
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpUpdateModel, Me.tpChangeModel, Me.tpChangeUnderValue})
            Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TabControl1.Location = New System.Drawing.Point(8, 8)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(720, 424)
            Me.TabControl1.TabIndex = 0
            '
            'tpUpdateModel
            '
            Me.tpUpdateModel.BackColor = System.Drawing.Color.SteelBlue
            Me.tpUpdateModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel_UpdateQty, Me.Panel_UpdateModelDesc})
            Me.tpUpdateModel.ForeColor = System.Drawing.Color.Black
            Me.tpUpdateModel.Location = New System.Drawing.Point(4, 22)
            Me.tpUpdateModel.Name = "tpUpdateModel"
            Me.tpUpdateModel.Size = New System.Drawing.Size(712, 398)
            Me.tpUpdateModel.TabIndex = 0
            Me.tpUpdateModel.Text = "Update Model"
            '
            'Panel_UpdateQty
            '
            Me.Panel_UpdateQty.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.Panel_UpdateQty.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCurrentValue, Me.LabelPalletModelCurrentValue, Me.Label_OpenPallet, Me.cboOpenPallets, Me.lblCurrentQty, Me.txtNewQuantity, Me.btnUpdateModelQty, Me.Label_PalletModel, Me.Label_PalletModelNewQty, Me.Label_PalletModelCurrentQty, Me.cboPalletModel, Me.Label_UpdateModelQty, Me.Label1})
            Me.Panel_UpdateQty.Location = New System.Drawing.Point(8, 184)
            Me.Panel_UpdateQty.Name = "Panel_UpdateQty"
            Me.Panel_UpdateQty.Size = New System.Drawing.Size(696, 208)
            Me.Panel_UpdateQty.TabIndex = 178
            '
            'lblCurrentValue
            '
            Me.lblCurrentValue.BackColor = System.Drawing.Color.White
            Me.lblCurrentValue.Location = New System.Drawing.Point(616, 64)
            Me.lblCurrentValue.Name = "lblCurrentValue"
            Me.lblCurrentValue.Size = New System.Drawing.Size(64, 20)
            Me.lblCurrentValue.TabIndex = 183
            '
            'LabelPalletModelCurrentValue
            '
            Me.LabelPalletModelCurrentValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPalletModelCurrentValue.ForeColor = System.Drawing.Color.White
            Me.LabelPalletModelCurrentValue.Location = New System.Drawing.Point(560, 64)
            Me.LabelPalletModelCurrentValue.Name = "LabelPalletModelCurrentValue"
            Me.LabelPalletModelCurrentValue.Size = New System.Drawing.Size(56, 21)
            Me.LabelPalletModelCurrentValue.TabIndex = 182
            Me.LabelPalletModelCurrentValue.Text = "Value $ :"
            Me.LabelPalletModelCurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label_OpenPallet
            '
            Me.Label_OpenPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_OpenPallet.ForeColor = System.Drawing.Color.White
            Me.Label_OpenPallet.Location = New System.Drawing.Point(16, 64)
            Me.Label_OpenPallet.Name = "Label_OpenPallet"
            Me.Label_OpenPallet.Size = New System.Drawing.Size(48, 21)
            Me.Label_OpenPallet.TabIndex = 181
            Me.Label_OpenPallet.Text = "Pallet :"
            Me.Label_OpenPallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboOpenPallets
            '
            Me.cboOpenPallets.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboOpenPallets.Caption = ""
            Me.cboOpenPallets.CaptionHeight = 17
            Me.cboOpenPallets.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboOpenPallets.ColumnCaptionHeight = 17
            Me.cboOpenPallets.ColumnFooterHeight = 17
            Me.cboOpenPallets.ContentHeight = 15
            Me.cboOpenPallets.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboOpenPallets.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboOpenPallets.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboOpenPallets.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboOpenPallets.EditorHeight = 15
            Me.cboOpenPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboOpenPallets.ItemHeight = 15
            Me.cboOpenPallets.Location = New System.Drawing.Point(64, 64)
            Me.cboOpenPallets.MatchEntryTimeout = CType(2000, Long)
            Me.cboOpenPallets.MaxDropDownItems = CType(5, Short)
            Me.cboOpenPallets.MaxLength = 32767
            Me.cboOpenPallets.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboOpenPallets.Name = "cboOpenPallets"
            Me.cboOpenPallets.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboOpenPallets.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboOpenPallets.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboOpenPallets.Size = New System.Drawing.Size(128, 21)
            Me.cboOpenPallets.TabIndex = 180
            Me.cboOpenPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'lblCurrentQty
            '
            Me.lblCurrentQty.BackColor = System.Drawing.Color.White
            Me.lblCurrentQty.Location = New System.Drawing.Point(496, 64)
            Me.lblCurrentQty.Name = "lblCurrentQty"
            Me.lblCurrentQty.Size = New System.Drawing.Size(48, 20)
            Me.lblCurrentQty.TabIndex = 179
            '
            'txtNewQuantity
            '
            Me.txtNewQuantity.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtNewQuantity.Location = New System.Drawing.Point(344, 112)
            Me.txtNewQuantity.Name = "txtNewQuantity"
            Me.txtNewQuantity.TabIndex = 178
            Me.txtNewQuantity.Text = ""
            '
            'btnUpdateModelQty
            '
            Me.btnUpdateModelQty.BackColor = System.Drawing.Color.Green
            Me.btnUpdateModelQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateModelQty.ForeColor = System.Drawing.Color.White
            Me.btnUpdateModelQty.Location = New System.Drawing.Point(312, 160)
            Me.btnUpdateModelQty.Name = "btnUpdateModelQty"
            Me.btnUpdateModelQty.Size = New System.Drawing.Size(128, 32)
            Me.btnUpdateModelQty.TabIndex = 177
            Me.btnUpdateModelQty.Text = "Update Quantity"
            '
            'Label_PalletModel
            '
            Me.Label_PalletModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PalletModel.ForeColor = System.Drawing.Color.White
            Me.Label_PalletModel.Location = New System.Drawing.Point(200, 64)
            Me.Label_PalletModel.Name = "Label_PalletModel"
            Me.Label_PalletModel.Size = New System.Drawing.Size(48, 21)
            Me.Label_PalletModel.TabIndex = 171
            Me.Label_PalletModel.Text = "Model :"
            Me.Label_PalletModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label_PalletModelNewQty
            '
            Me.Label_PalletModelNewQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PalletModelNewQty.ForeColor = System.Drawing.Color.White
            Me.Label_PalletModelNewQty.Location = New System.Drawing.Point(248, 112)
            Me.Label_PalletModelNewQty.Name = "Label_PalletModelNewQty"
            Me.Label_PalletModelNewQty.Size = New System.Drawing.Size(96, 21)
            Me.Label_PalletModelNewQty.TabIndex = 175
            Me.Label_PalletModelNewQty.Text = "New Quantity :"
            Me.Label_PalletModelNewQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label_PalletModelCurrentQty
            '
            Me.Label_PalletModelCurrentQty.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.Label_PalletModelCurrentQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PalletModelCurrentQty.ForeColor = System.Drawing.Color.White
            Me.Label_PalletModelCurrentQty.Location = New System.Drawing.Point(464, 64)
            Me.Label_PalletModelCurrentQty.Name = "Label_PalletModelCurrentQty"
            Me.Label_PalletModelCurrentQty.Size = New System.Drawing.Size(32, 21)
            Me.Label_PalletModelCurrentQty.TabIndex = 173
            Me.Label_PalletModelCurrentQty.Text = "Qty :"
            Me.Label_PalletModelCurrentQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboPalletModel
            '
            Me.cboPalletModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboPalletModel.Caption = ""
            Me.cboPalletModel.CaptionHeight = 17
            Me.cboPalletModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboPalletModel.ColumnCaptionHeight = 17
            Me.cboPalletModel.ColumnFooterHeight = 17
            Me.cboPalletModel.ContentHeight = 15
            Me.cboPalletModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboPalletModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboPalletModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboPalletModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboPalletModel.EditorHeight = 15
            Me.cboPalletModel.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboPalletModel.ItemHeight = 15
            Me.cboPalletModel.Location = New System.Drawing.Point(248, 64)
            Me.cboPalletModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboPalletModel.MaxDropDownItems = CType(5, Short)
            Me.cboPalletModel.MaxLength = 32767
            Me.cboPalletModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboPalletModel.Name = "cboPalletModel"
            Me.cboPalletModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboPalletModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboPalletModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboPalletModel.Size = New System.Drawing.Size(192, 21)
            Me.cboPalletModel.TabIndex = 5
            Me.cboPalletModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label_UpdateModelQty
            '
            Me.Label_UpdateModelQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_UpdateModelQty.ForeColor = System.Drawing.Color.White
            Me.Label_UpdateModelQty.Location = New System.Drawing.Point(200, 16)
            Me.Label_UpdateModelQty.Name = "Label_UpdateModelQty"
            Me.Label_UpdateModelQty.Size = New System.Drawing.Size(352, 24)
            Me.Label_UpdateModelQty.TabIndex = 176
            Me.Label_UpdateModelQty.Text = "Update Received Quantity"
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(200, 64)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 21)
            Me.Label1.TabIndex = 171
            Me.Label1.Text = "Model :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel_UpdateModelDesc
            '
            Me.Panel_UpdateModelDesc.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.Panel_UpdateModelDesc.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnUpdateModelDesc, Me.Label_Model, Me.Label_Mfg, Me.Label_Product, Me.cboModelsDesc, Me.cboMfg, Me.cboProduct, Me.Label_UpdateModelDesc})
            Me.Panel_UpdateModelDesc.Location = New System.Drawing.Point(8, 8)
            Me.Panel_UpdateModelDesc.Name = "Panel_UpdateModelDesc"
            Me.Panel_UpdateModelDesc.Size = New System.Drawing.Size(696, 160)
            Me.Panel_UpdateModelDesc.TabIndex = 177
            '
            'btnUpdateModelDesc
            '
            Me.btnUpdateModelDesc.BackColor = System.Drawing.Color.Green
            Me.btnUpdateModelDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdateModelDesc.ForeColor = System.Drawing.Color.White
            Me.btnUpdateModelDesc.Location = New System.Drawing.Point(312, 112)
            Me.btnUpdateModelDesc.Name = "btnUpdateModelDesc"
            Me.btnUpdateModelDesc.Size = New System.Drawing.Size(136, 32)
            Me.btnUpdateModelDesc.TabIndex = 177
            Me.btnUpdateModelDesc.Text = "Update Model"
            '
            'Label_Model
            '
            Me.Label_Model.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Model.ForeColor = System.Drawing.Color.White
            Me.Label_Model.Location = New System.Drawing.Point(8, 64)
            Me.Label_Model.Name = "Label_Model"
            Me.Label_Model.Size = New System.Drawing.Size(48, 21)
            Me.Label_Model.TabIndex = 171
            Me.Label_Model.Text = "Model :"
            Me.Label_Model.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label_Mfg
            '
            Me.Label_Mfg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Mfg.ForeColor = System.Drawing.Color.White
            Me.Label_Mfg.Location = New System.Drawing.Point(488, 64)
            Me.Label_Mfg.Name = "Label_Mfg"
            Me.Label_Mfg.Size = New System.Drawing.Size(32, 21)
            Me.Label_Mfg.TabIndex = 175
            Me.Label_Mfg.Text = "Mfg :"
            Me.Label_Mfg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label_Product
            '
            Me.Label_Product.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Product.ForeColor = System.Drawing.Color.White
            Me.Label_Product.Location = New System.Drawing.Point(232, 64)
            Me.Label_Product.Name = "Label_Product"
            Me.Label_Product.Size = New System.Drawing.Size(64, 21)
            Me.Label_Product.TabIndex = 173
            Me.Label_Product.Text = "Product :"
            Me.Label_Product.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboModelsDesc
            '
            Me.cboModelsDesc.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModelsDesc.Caption = ""
            Me.cboModelsDesc.CaptionHeight = 17
            Me.cboModelsDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModelsDesc.ColumnCaptionHeight = 17
            Me.cboModelsDesc.ColumnFooterHeight = 17
            Me.cboModelsDesc.ContentHeight = 15
            Me.cboModelsDesc.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModelsDesc.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModelsDesc.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModelsDesc.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModelsDesc.EditorHeight = 15
            Me.cboModelsDesc.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboModelsDesc.ItemHeight = 15
            Me.cboModelsDesc.Location = New System.Drawing.Point(56, 64)
            Me.cboModelsDesc.MatchEntryTimeout = CType(2000, Long)
            Me.cboModelsDesc.MaxDropDownItems = CType(5, Short)
            Me.cboModelsDesc.MaxLength = 32767
            Me.cboModelsDesc.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModelsDesc.Name = "cboModelsDesc"
            Me.cboModelsDesc.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModelsDesc.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModelsDesc.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModelsDesc.Size = New System.Drawing.Size(165, 21)
            Me.cboModelsDesc.TabIndex = 5
            Me.cboModelsDesc.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboMfg
            '
            Me.cboMfg.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboMfg.Caption = ""
            Me.cboMfg.CaptionHeight = 17
            Me.cboMfg.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboMfg.ColumnCaptionHeight = 17
            Me.cboMfg.ColumnFooterHeight = 17
            Me.cboMfg.ContentHeight = 15
            Me.cboMfg.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboMfg.EditorBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.cboMfg.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMfg.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboMfg.EditorHeight = 15
            Me.cboMfg.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboMfg.ItemHeight = 15
            Me.cboMfg.Location = New System.Drawing.Point(520, 64)
            Me.cboMfg.MatchEntryTimeout = CType(2000, Long)
            Me.cboMfg.MaxDropDownItems = CType(5, Short)
            Me.cboMfg.MaxLength = 32767
            Me.cboMfg.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboMfg.Name = "cboMfg"
            Me.cboMfg.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboMfg.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboMfg.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboMfg.Size = New System.Drawing.Size(165, 21)
            Me.cboMfg.TabIndex = 174
            Me.cboMfg.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboProduct
            '
            Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProduct.Caption = ""
            Me.cboProduct.CaptionHeight = 17
            Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProduct.ColumnCaptionHeight = 17
            Me.cboProduct.ColumnFooterHeight = 17
            Me.cboProduct.ContentHeight = 15
            Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProduct.EditorBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.cboProduct.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProduct.EditorHeight = 15
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(296, 64)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(5, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(165, 21)
            Me.cboProduct.TabIndex = 172
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label_UpdateModelDesc
            '
            Me.Label_UpdateModelDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_UpdateModelDesc.ForeColor = System.Drawing.Color.White
            Me.Label_UpdateModelDesc.Location = New System.Drawing.Point(24, 16)
            Me.Label_UpdateModelDesc.Name = "Label_UpdateModelDesc"
            Me.Label_UpdateModelDesc.Size = New System.Drawing.Size(648, 24)
            Me.Label_UpdateModelDesc.TabIndex = 176
            Me.Label_UpdateModelDesc.Text = "Change product type and manufacturing"
            Me.Label_UpdateModelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tpChangeModel
            '
            Me.tpChangeModel.BackColor = System.Drawing.Color.SteelBlue
            Me.tpChangeModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel_ChangeModel})
            Me.tpChangeModel.Location = New System.Drawing.Point(4, 22)
            Me.tpChangeModel.Name = "tpChangeModel"
            Me.tpChangeModel.Size = New System.Drawing.Size(712, 398)
            Me.tpChangeModel.TabIndex = 2
            Me.tpChangeModel.Text = "Change Model"
            '
            'Panel_ChangeModel
            '
            Me.Panel_ChangeModel.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.Panel_ChangeModel.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboChangeModelModel, Me.Label_ChangeModel, Me.Label_ChangeModelSerial, Me.txtChangeModelSerial, Me.Label_ChangeModelModel, Me.Label_ChangeModelPallet, Me.cboChangeModelPallet, Me.btnChangeModelSerial})
            Me.Panel_ChangeModel.Location = New System.Drawing.Point(8, 7)
            Me.Panel_ChangeModel.Name = "Panel_ChangeModel"
            Me.Panel_ChangeModel.Size = New System.Drawing.Size(696, 384)
            Me.Panel_ChangeModel.TabIndex = 1
            '
            'cboChangeModelModel
            '
            Me.cboChangeModelModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboChangeModelModel.Caption = ""
            Me.cboChangeModelModel.CaptionHeight = 17
            Me.cboChangeModelModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboChangeModelModel.ColumnCaptionHeight = 17
            Me.cboChangeModelModel.ColumnFooterHeight = 17
            Me.cboChangeModelModel.ContentHeight = 15
            Me.cboChangeModelModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboChangeModelModel.EditorBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.cboChangeModelModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboChangeModelModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboChangeModelModel.EditorHeight = 15
            Me.cboChangeModelModel.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboChangeModelModel.ItemHeight = 15
            Me.cboChangeModelModel.Location = New System.Drawing.Point(184, 152)
            Me.cboChangeModelModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboChangeModelModel.MaxDropDownItems = CType(5, Short)
            Me.cboChangeModelModel.MaxLength = 32767
            Me.cboChangeModelModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboChangeModelModel.Name = "cboChangeModelModel"
            Me.cboChangeModelModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboChangeModelModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboChangeModelModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboChangeModelModel.Size = New System.Drawing.Size(224, 21)
            Me.cboChangeModelModel.TabIndex = 195
            Me.cboChangeModelModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label_ChangeModel
            '
            Me.Label_ChangeModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ChangeModel.ForeColor = System.Drawing.Color.White
            Me.Label_ChangeModel.Location = New System.Drawing.Point(24, 16)
            Me.Label_ChangeModel.Name = "Label_ChangeModel"
            Me.Label_ChangeModel.Size = New System.Drawing.Size(648, 32)
            Me.Label_ChangeModel.TabIndex = 194
            Me.Label_ChangeModel.Text = "Change model"
            Me.Label_ChangeModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label_ChangeModelSerial
            '
            Me.Label_ChangeModelSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ChangeModelSerial.ForeColor = System.Drawing.Color.White
            Me.Label_ChangeModelSerial.Location = New System.Drawing.Point(56, 72)
            Me.Label_ChangeModelSerial.Name = "Label_ChangeModelSerial"
            Me.Label_ChangeModelSerial.Size = New System.Drawing.Size(128, 21)
            Me.Label_ChangeModelSerial.TabIndex = 193
            Me.Label_ChangeModelSerial.Text = "PSS Serial :"
            Me.Label_ChangeModelSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtChangeModelSerial
            '
            Me.txtChangeModelSerial.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtChangeModelSerial.Location = New System.Drawing.Point(184, 72)
            Me.txtChangeModelSerial.Name = "txtChangeModelSerial"
            Me.txtChangeModelSerial.Size = New System.Drawing.Size(224, 20)
            Me.txtChangeModelSerial.TabIndex = 192
            Me.txtChangeModelSerial.Text = ""
            '
            'Label_ChangeModelModel
            '
            Me.Label_ChangeModelModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ChangeModelModel.ForeColor = System.Drawing.Color.White
            Me.Label_ChangeModelModel.Location = New System.Drawing.Point(56, 152)
            Me.Label_ChangeModelModel.Name = "Label_ChangeModelModel"
            Me.Label_ChangeModelModel.Size = New System.Drawing.Size(128, 21)
            Me.Label_ChangeModelModel.TabIndex = 185
            Me.Label_ChangeModelModel.Text = "Item / Model :"
            Me.Label_ChangeModelModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label_ChangeModelPallet
            '
            Me.Label_ChangeModelPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ChangeModelPallet.ForeColor = System.Drawing.Color.White
            Me.Label_ChangeModelPallet.Location = New System.Drawing.Point(136, 112)
            Me.Label_ChangeModelPallet.Name = "Label_ChangeModelPallet"
            Me.Label_ChangeModelPallet.Size = New System.Drawing.Size(48, 21)
            Me.Label_ChangeModelPallet.TabIndex = 183
            Me.Label_ChangeModelPallet.Text = "Pallet :"
            Me.Label_ChangeModelPallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboChangeModelPallet
            '
            Me.cboChangeModelPallet.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboChangeModelPallet.Caption = ""
            Me.cboChangeModelPallet.CaptionHeight = 17
            Me.cboChangeModelPallet.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboChangeModelPallet.ColumnCaptionHeight = 17
            Me.cboChangeModelPallet.ColumnFooterHeight = 17
            Me.cboChangeModelPallet.ContentHeight = 15
            Me.cboChangeModelPallet.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboChangeModelPallet.EditorBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.cboChangeModelPallet.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboChangeModelPallet.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboChangeModelPallet.EditorHeight = 15
            Me.cboChangeModelPallet.Images.Add(CType(resources.GetObject("resource.Images6"), System.Drawing.Bitmap))
            Me.cboChangeModelPallet.ItemHeight = 15
            Me.cboChangeModelPallet.Location = New System.Drawing.Point(184, 112)
            Me.cboChangeModelPallet.MatchEntryTimeout = CType(2000, Long)
            Me.cboChangeModelPallet.MaxDropDownItems = CType(5, Short)
            Me.cboChangeModelPallet.MaxLength = 32767
            Me.cboChangeModelPallet.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboChangeModelPallet.Name = "cboChangeModelPallet"
            Me.cboChangeModelPallet.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboChangeModelPallet.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboChangeModelPallet.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboChangeModelPallet.Size = New System.Drawing.Size(224, 21)
            Me.cboChangeModelPallet.TabIndex = 182
            Me.cboChangeModelPallet.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnChangeModelSerial
            '
            Me.btnChangeModelSerial.BackColor = System.Drawing.Color.Green
            Me.btnChangeModelSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnChangeModelSerial.ForeColor = System.Drawing.Color.White
            Me.btnChangeModelSerial.Location = New System.Drawing.Point(224, 192)
            Me.btnChangeModelSerial.Name = "btnChangeModelSerial"
            Me.btnChangeModelSerial.Size = New System.Drawing.Size(136, 32)
            Me.btnChangeModelSerial.TabIndex = 178
            Me.btnChangeModelSerial.Text = "Change Model"
            '
            'tpChangeUnderValue
            '
            Me.tpChangeUnderValue.BackColor = System.Drawing.Color.SteelBlue
            Me.tpChangeUnderValue.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel_ChangeUnderValue})
            Me.tpChangeUnderValue.Location = New System.Drawing.Point(4, 22)
            Me.tpChangeUnderValue.Name = "tpChangeUnderValue"
            Me.tpChangeUnderValue.Size = New System.Drawing.Size(712, 398)
            Me.tpChangeUnderValue.TabIndex = 3
            Me.tpChangeUnderValue.Text = "Change Under Value"
            '
            'Panel_ChangeUnderValue
            '
            Me.Panel_ChangeUnderValue.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.Panel_ChangeUnderValue.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label_NewUnderValue, Me.lblCurrentUnderValue, Me.Label_ChangeUnderValue, Me.Label_UnderValue, Me.txtNewUnderValue, Me.btnChangeUnderValue})
            Me.Panel_ChangeUnderValue.Location = New System.Drawing.Point(8, 7)
            Me.Panel_ChangeUnderValue.Name = "Panel_ChangeUnderValue"
            Me.Panel_ChangeUnderValue.Size = New System.Drawing.Size(696, 377)
            Me.Panel_ChangeUnderValue.TabIndex = 2
            '
            'Label_NewUnderValue
            '
            Me.Label_NewUnderValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_NewUnderValue.ForeColor = System.Drawing.Color.White
            Me.Label_NewUnderValue.Location = New System.Drawing.Point(56, 168)
            Me.Label_NewUnderValue.Name = "Label_NewUnderValue"
            Me.Label_NewUnderValue.Size = New System.Drawing.Size(128, 21)
            Me.Label_NewUnderValue.TabIndex = 196
            Me.Label_NewUnderValue.Text = "New Under Value $ :"
            Me.Label_NewUnderValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCurrentUnderValue
            '
            Me.lblCurrentUnderValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCurrentUnderValue.ForeColor = System.Drawing.Color.Lime
            Me.lblCurrentUnderValue.Location = New System.Drawing.Point(200, 88)
            Me.lblCurrentUnderValue.Name = "lblCurrentUnderValue"
            Me.lblCurrentUnderValue.Size = New System.Drawing.Size(216, 23)
            Me.lblCurrentUnderValue.TabIndex = 195
            '
            'Label_ChangeUnderValue
            '
            Me.Label_ChangeUnderValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ChangeUnderValue.ForeColor = System.Drawing.Color.White
            Me.Label_ChangeUnderValue.Location = New System.Drawing.Point(24, 16)
            Me.Label_ChangeUnderValue.Name = "Label_ChangeUnderValue"
            Me.Label_ChangeUnderValue.Size = New System.Drawing.Size(648, 32)
            Me.Label_ChangeUnderValue.TabIndex = 194
            Me.Label_ChangeUnderValue.Text = "Change Under Value"
            Me.Label_ChangeUnderValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label_UnderValue
            '
            Me.Label_UnderValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_UnderValue.ForeColor = System.Drawing.Color.White
            Me.Label_UnderValue.Location = New System.Drawing.Point(56, 88)
            Me.Label_UnderValue.Name = "Label_UnderValue"
            Me.Label_UnderValue.Size = New System.Drawing.Size(128, 21)
            Me.Label_UnderValue.TabIndex = 193
            Me.Label_UnderValue.Text = "Current Under Value $ :"
            Me.Label_UnderValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNewUnderValue
            '
            Me.txtNewUnderValue.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
            Me.txtNewUnderValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtNewUnderValue.Location = New System.Drawing.Point(192, 160)
            Me.txtNewUnderValue.Name = "txtNewUnderValue"
            Me.txtNewUnderValue.Size = New System.Drawing.Size(224, 29)
            Me.txtNewUnderValue.TabIndex = 192
            Me.txtNewUnderValue.Text = ""
            '
            'btnChangeUnderValue
            '
            Me.btnChangeUnderValue.BackColor = System.Drawing.Color.Green
            Me.btnChangeUnderValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnChangeUnderValue.ForeColor = System.Drawing.Color.White
            Me.btnChangeUnderValue.Location = New System.Drawing.Point(224, 224)
            Me.btnChangeUnderValue.Name = "btnChangeUnderValue"
            Me.btnChangeUnderValue.Size = New System.Drawing.Size(160, 32)
            Me.btnChangeUnderValue.TabIndex = 178
            Me.btnChangeUnderValue.Text = "Change Under Value"
            '
            'SyxAdminTools
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(736, 446)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1})
            Me.Name = "SyxAdminTools"
            Me.Text = "SyxAdminTools"
            Me.TabControl1.ResumeLayout(False)
            Me.tpUpdateModel.ResumeLayout(False)
            Me.Panel_UpdateQty.ResumeLayout(False)
            CType(Me.cboOpenPallets, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboPalletModel, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel_UpdateModelDesc.ResumeLayout(False)
            CType(Me.cboModelsDesc, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboMfg, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpChangeModel.ResumeLayout(False)
            Me.Panel_ChangeModel.ResumeLayout(False)
            CType(Me.cboChangeModelModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboChangeModelPallet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tpChangeUnderValue.ResumeLayout(False)
            Me.Panel_ChangeUnderValue.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Loading"
        '****************************************************************************************************
        Private Sub SyxAdminTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                PSS.Core.Highlight.SetHighLight(Me)

                Me._booLoadData = True

                'Update Model Tab
                Me.LoadModelsDesc()
                Me.LoadProduct()
                Me.LoadMfg()
                Me.LoadOpenPallets()
                Me.btnUpdateModelDesc.Enabled = False
                Me.btnUpdateModelQty.Enabled = False
                Me.lblCurrentQty.Text = ""
                Me.txtNewQuantity.Text = ""
               
                'Change Model Tab
                Me.btnChangeModelSerial.Enabled = False

                'Change Under Value Tab
                Me.lblCurrentUnderValue.Text = Me._objSyxRec.GetUnderValueCost()
                Me.btnChangeUnderValue.Enabled = False

            Catch ex As Exception
                MessageBox.Show(ex.ToString(), "frmSyxRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub LoadModelsDesc()
            Dim dt As DataTable

            Try
                Me._booLoadData = True
                dt = Generic.GetModels(True)
                Misc.PopulateC1DropDownList(Me.cboModelsDesc, dt, "Model_Desc", "Model_ID")
                Me.cboModelsDesc.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadModelsDesc", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub LoadProduct()
            Dim dt As DataTable

            Try
                Me._booLoadData = True
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                Me.cboProduct.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadModelsDesc", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        '****************************************************************************************************
        Private Sub LoadMfg()
            Dim dt As DataTable

            Try
                Me._booLoadData = True
                dt = Generic.GetManufactures(True)
                Misc.PopulateC1DropDownList(Me.cboMfg, dt, "Manuf_Desc", "Manuf_ID")
                Me.cboMfg.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadModelsDesc", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
        '****************************************************************************************************
        Private Sub LoadOpenPallets()
            Dim dt As DataTable

            Try
                Me._booLoadData = True
                dt = Me._objSyxRec.GetOpenPallets(True)
                Misc.PopulateC1DropDownList(Me.cboOpenPallets, dt, "PalletID", "RP_ID")
                Me.cboOpenPallets.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadOpenPallets", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub LoadPalletModels()
            Dim dt As DataTable
            Try
                Me._booLoadData = True
                dt = Me._objSyx.GetPalletModelsList(Me.cboOpenPallets.Text, True)
                Misc.PopulateC1DropDownList(Me.cboPalletModel, dt, "ItemNumber", "PD_ID")
                Me.cboPalletModel.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadModelsDesc", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try

        End Sub

        '****************************************************************************************************
        Private Sub LoadChangeModelModels()
            'Get the list of defined models only 
            Dim dt As DataTable

            Try
                Me._booLoadData = True
                dt = Me._objSyx.GetPalletDefinedModelsList(Me.cboChangeModelPallet.Text, True)
                Misc.PopulateC1DropDownList(Me.cboChangeModelModel, dt, "ItemNumber", "PD_ID")
                Me.cboChangeModelModel.SelectedValue = 0

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadChangeModelModels", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me._booLoadData = False
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub
#End Region

#Region "Update Model Tab"
        '****************************************************************************************************
        ' ******************************** Update Model Type ********************************************************
        '****************************************************************************************************
        Private Sub cboModelsDesc_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModelsDesc.RowChange
            Try
                If Me._booLoadData = True Then Exit Sub
                If Me.cboModelsDesc.SelectedValue > 0 Then
                    Me._oriProductID = Me.cboModelsDesc.Columns("Prod_ID").CellValue(Me.cboModelsDesc.SelectedIndex)
                    Me._oriMfgID = Me.cboModelsDesc.Columns("Manuf_ID").CellValue(Me.cboModelsDesc.SelectedIndex)
                    Me.cboProduct.SelectedValue = Me._oriProductID
                    Me.cboMfg.SelectedValue = Me._oriMfgID
                Else
                    Me.cboProduct.SelectedValue = 0
                    Me.cboMfg.SelectedValue = 0
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboModelsDesc_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '****************************************************************************************************
        Private Sub cboProduct_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.RowChange
            Try
                If Me._booLoadData = True Then Exit Sub
                Me.btnUpdateModelDesc.Enabled = False
                If Me.cboProduct.SelectedValue > 0 Then
                    If Me._oriProductID <> Me.cboProduct.SelectedValue Then
                        Me.btnUpdateModelDesc.Enabled = True
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboProduct_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '****************************************************************************************************
        Private Sub cboMfg_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMfg.RowChange
            Try
                If Me._booLoadData = True Then Exit Sub
                Me.btnUpdateModelDesc.Enabled = False
                If Me.cboMfg.SelectedValue > 0 Then
                    If Me._oriMfgID <> Me.cboMfg.SelectedValue Then
                        Me.btnUpdateModelDesc.Enabled = True
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboMfg_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '****************************************************************************************************
        Private Sub btnUpdateModelDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateModelDesc.Click
            Dim i, iModel_ID As Integer
            Try
                If Me._oriProductID <> Me.cboProduct.SelectedValue Or Me._oriMfgID <> Me.cboMfg.SelectedValue Then
                    iModel_ID = Me.cboModelsDesc.SelectedValue
                    i = Me._objSyx.UpdateModel(Me.cboModelsDesc.SelectedValue, Me.cboProduct.SelectedValue, Me.cboMfg.SelectedValue)
                    Me.LoadModelsDesc()
                    Me.cboModelsDesc.SelectedValue = iModel_ID
                    Me.btnUpdateModelDesc.Enabled = False
                    MessageBox.Show("Model# " & Me.cboModelsDesc.Text & " has been upddated...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdateModelDesc_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '****************************************************************************************************
        '******************************** Update Quantity ********************************************************
        '****************************************************************************************************
        Private Sub cboOpenPallets_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpenPallets.RowChange

            Try
                If Me._booLoadData = True Then Exit Sub
                If cboOpenPallets.SelectedValue > 0 Then
                    LoadPalletModels()
                Else

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboOpenPallets_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '****************************************************************************************************
        Private Sub cboPalletModels_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPalletModel.RowChange
            Try
                btnUpdateModelQty.Enabled = False
                If Me._booLoadData = True Then Exit Sub
                If Me.cboPalletModel.SelectedValue > 0 Then
                    Me.lblCurrentQty.Text = Me.cboPalletModel.Columns("OnHandQty").CellValue(Me.cboPalletModel.SelectedIndex)
                    Me.txtNewQuantity.Text = Me.lblCurrentQty.Text
                    Me.lblCurrentValue.Text = Me.cboPalletModel.Columns("LastUpdateValue").CellValue(Me.cboPalletModel.SelectedIndex)

                Else
                    Me.lblCurrentQty.Text = ""
                    Me.txtNewQuantity.Text = ""

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboPalletModels_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        '****************************************************************************************************
        Private Sub txtNewQuantity_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNewQuantity.KeyUp
            Try
                Me.btnUpdateModelQty.Enabled = False
                If IsNumeric(Me.txtNewQuantity.Text) = True Then
                    If Me.lblCurrentQty.Text <> Me.txtNewQuantity.Text Then
                        Me.btnUpdateModelQty.Enabled = True
                    End If
                Else
                    MessageBox.Show("The quantity entered: " & Me.txtNewQuantity.Text & " is invalid ! Please enter a number..." & Me.cboPalletModel.Text & "...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtNewQuantity_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
         '****************************************************************************************************

        Private Sub btnUpdateModelQty_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateModelQty.Click
            Dim i, PD_ID As Integer
            Dim LastUpdateValue, OriginalLastUpdateValue As Decimal
            Dim PalletID As String = Me.cboOpenPallets.Text
            Dim DescrepacyDesc As String = ""
            Try
                If Me.lblCurrentQty.Text <> Me.txtNewQuantity.Text Then
                    OriginalLastUpdateValue = Me.lblCurrentValue.Text
                    If OriginalLastUpdateValue > 0.0 Then
                        LastUpdateValue = (OriginalLastUpdateValue / Me.lblCurrentQty.Text) * Me.txtNewQuantity.Text
                    Else
                        LastUpdateValue = 0.0
                    End If
                    If CInt(Me.txtNewQuantity.Text) > CInt(Me.lblCurrentQty.Text) Then
                        DescrepacyDesc = "Admin add quantity"
                    Else
                        DescrepacyDesc = "Admin remove quantity"
                    End If
                    LastUpdateValue = (OriginalLastUpdateValue / Me.lblCurrentQty.Text) * Me.txtNewQuantity.Text
                    PD_ID = Me.cboPalletModel.Columns("PD_ID").CellValue(Me.cboPalletModel.SelectedIndex)
                    i = Me._objSyx.UpdateItemNumberQty(PD_ID, Me.txtNewQuantity.Text, Me.lblCurrentQty.Text, LastUpdateValue, OriginalLastUpdateValue, DescrepacyDesc)
                    Me.LoadOpenPallets()
                    Me.cboOpenPallets.SelectedText = PalletID
                    Me.lblCurrentQty.Text = Me.txtNewQuantity.Text
                    Me.lblCurrentValue.Text = LastUpdateValue
                    Me.btnUpdateModelQty.Enabled = False
                    MessageBox.Show(Me.txtNewQuantity.Text & " quantity has been updated for model#" & Me.cboPalletModel.Text & "...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)


                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnUpdateModelDesc_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
      
#End Region

#Region "Change Model Tab"
        '****************************************************************************************************
        '******************************** Change Model ********************************************************
        '****************************************************************************************************
        Private Sub cboChangeModelPallet_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboChangeModelPallet.RowChange

            Try
                Me.btnChangeModelSerial.Enabled = False
                If Me._booLoadData = True Then Exit Sub
                If cboChangeModelPallet.SelectedValue > 0 Then
                    Me.LoadChangeModelModels()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboChangeModelPallet_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Sub
        '****************************************************************************************************
        Private Sub cboChangeModelModel_RowChange(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboChangeModelModel.RowChange
            Dim iAvailableItem, iReceivedItem As Integer
            Dim strModel, strPallet As String

            Try

                If Me._booLoadData = True Then Exit Sub
                Me.btnChangeModelSerial.Enabled = False
                If Me.cboChangeModelModel.SelectedValue > 0 Then
                    strModel = Me.cboChangeModelModel.Columns("ItemNumber").CellValue(Me.cboChangeModelModel.SelectedIndex)
                    strPallet = Me.cboChangeModelModel.Columns("PalletID").CellValue(Me.cboChangeModelModel.SelectedIndex)
                    iAvailableItem = Me._objSyxRec.GetAvailableItemQty(strPallet, strModel)
                    iReceivedItem = Me._objSyxRec.GetReceivedItemQty(strPallet, strModel)
                    If iAvailableItem = 0 Then
                        MessageBox.Show("No more item available for this Model# " & strModel & ". Please select other model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    ElseIf iReceivedItem = iAvailableItem Then
                        MessageBox.Show(iReceivedItem & " item(s) already received for Model# " & strModel & " in Pallet# " & strPallet & ". You can not change to this model#" & strModel & " item(s). Please select another model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    Me.btnChangeModelSerial.Enabled = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cboChangeModelModel_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally

            End Try
        End Sub
        '****************************************************************************************************

        Private Sub btnChangeModelSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeModelSerial.Click
            Dim i, iPD_ID, iModel_ID, iDevice_ID, iProd_ID, iManuf_ID, iOnHandQty As Integer
            Dim strModel, strPallet, strItemDescription As String
            Dim dtDevice, dtModel As DataTable

            Try
                'Check PSS serial number
                Me.txtChangeModelSerial.Text = Trim(Me.txtChangeModelSerial.Text.ToUpper)
                If Len(Me.txtChangeModelSerial.Text) = 0 Then
                    MessageBox.Show("Please enter PSS serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtChangeModelSerial.SelectAll() : Me.txtChangeModelSerial.Focus()
                    Exit Sub
                End If
                dtDevice = Me._objSyx.GetDeviceInfo(Me.txtChangeModelSerial.Text, True)
                If dtDevice.Rows.Count = 0 Then
                    MessageBox.Show("This Serial number#" & Me.txtChangeModelSerial.Text & " is not found in the system or has been shipped. Please enter another serial number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtChangeModelSerial.SelectAll() : Me.txtChangeModelSerial.Focus()
                    Exit Sub
                ElseIf dtDevice.Rows.Count > 1 Then
                    MessageBox.Show("There is more than one instance of this Serial number#" & Me.txtChangeModelSerial.Text & " found in the system. Please contact IT immediatly.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtChangeModelSerial.SelectAll() : Me.txtChangeModelSerial.Focus()
                    Exit Sub
                Else
                    iDevice_ID = dtDevice.Rows(0)("Device_ID")
                End If

                'Check Model
                iPD_ID = Me.cboChangeModelModel.Columns("PD_ID").CellValue(Me.cboChangeModelModel.SelectedIndex)
                strModel = Me.cboChangeModelModel.Columns("ItemNumber").CellValue(Me.cboChangeModelModel.SelectedIndex)
                strItemDescription = Me.cboChangeModelModel.Columns("ItemDescription").CellValue(Me.cboChangeModelModel.SelectedIndex)
                iOnHandQty = Me.cboChangeModelModel.Columns("OnHandQty").CellValue(Me.cboChangeModelModel.SelectedIndex)
                strPallet = Me.cboChangeModelModel.Columns("PalletID").CellValue(Me.cboChangeModelModel.SelectedIndex)
                dtModel = Me._objSyxRec.GetModelInfo(strModel)
                If dtModel.Rows.Count = 0 Then
                    MessageBox.Show("This Model# " & strModel & " has not been defined. You can not change to this model#" & strModel & ". Please select another model or goto Receiving Screen to receive this model", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If
                iModel_ID = dtModel.Rows(0)("Model_ID")
                iProd_ID = dtModel.Rows(0)("Prod_ID")
                iManuf_ID = dtModel.Rows(0)("Manuf_ID")

                'Change Model
                i = Me._objSyxRec.ChangeModel(iDevice_ID, iModel_ID, strModel, iPD_ID, iProd_ID, iManuf_ID, strPallet)
                If i > 0 Then
                    MessageBox.Show("PSS serial number: " & Me.txtChangeModelSerial.Text & " has been changed to model: " & strModel & " successfully ...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtChangeModelSerial.Text = ""
                    cboChangeModelPallet.SelectedValue = 0
                    cboChangeModelModel.SelectedValue = 0
                    btnChangeModelSerial.Enabled = False
                    Me.txtChangeModelSerial.SelectAll() : Me.txtChangeModelSerial.Focus()
                Else
                    MessageBox.Show("An error occurred during changing model. Please try again or contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnChangeModelSerial_RowChange", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dtModel) : Generic.DisposeDT(dtDevice)
            End Try

        End Sub
        '****************************************************************************************************


#End Region

#Region "Change Under Value Tab"

        '****************************************************************************************************
        Private Sub txtNewUnderValue_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNewUnderValue.KeyUp

            Try
                Me.btnChangeUnderValue.Enabled = False
                If e.KeyCode = Keys.Enter Then

                    If txtNewUnderValue.Text = Me.lblCurrentUnderValue.Text Then
                        MessageBox.Show("The new under value enterd: " & Me.txtNewUnderValue.Text & " is identical to the old value ! Please re-enter new under value...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf IsNumeric(txtNewUnderValue.Text) = False Then
                        MessageBox.Show("The under value enterd: " & Me.txtNewUnderValue.Text & " is invalid ! Please enter a number ...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf CInt(txtNewUnderValue.Text) < 1 Then
                        MessageBox.Show("The under value enterd: " & Me.txtNewUnderValue.Text & " is invalid ! Please enter a number greater than zero...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    ElseIf IsNumeric(txtNewUnderValue.Text) = True AndAlso CInt(txtNewUnderValue.Text) > 0 Then
                        Me.btnChangeUnderValue.Enabled = True : Me.btnChangeUnderValue.Focus()
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtNewUnderValue_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        End Sub
        '****************************************************************************************************

        Private Sub btnChangeUnderValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeUnderValue.Click
            Dim i As Integer
            Try

                If IsNumeric(txtNewUnderValue.Text) = True AndAlso CInt(txtNewUnderValue.Text) > 0 Then

                    i = Me._objSyxRec.UpdateUnderValueCost(txtNewUnderValue.Text, Core.ApplicationUser.IDuser)
                    If i > 0 Then
                        MessageBox.Show("New Under Value $" & Me.txtNewUnderValue.Text & " has been updated ....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.lblCurrentUnderValue.Text = Me.txtNewUnderValue.Text
                        Me.txtNewUnderValue.Text = ""
                        Me.txtNewUnderValue.SelectAll() : Me.txtNewUnderValue.Focus()
                    Else
                        MessageBox.Show("Unable to update the New Under Value....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtNewUnderValue.SelectAll() : Me.txtNewUnderValue.Focus()
                    End If

                Else
                    MessageBox.Show("The under value enterd: " & Me.txtNewUnderValue.Text & " is invalid ! Please enter a number greater than zero...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAddPalletItems_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Finally

            End Try

        End Sub
        '****************************************************************************************************

#End Region





    End Class

End Namespace
