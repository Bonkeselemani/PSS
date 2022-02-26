Option Explicit On 

Imports PSS.Data
Imports PSS.Data.Buisness
Imports PSS.Core

Namespace Gui

    Public Class SyxPartsConsumption
        Inherits System.Windows.Forms.Form

        Private _objSyxRec As PSS.Data.Buisness.SyxReceivingShipping
        Private _objSyx As PSS.Data.Buisness.Syx
        Private _Device_ID As Integer
        Private _Model_ID As Integer
        Private _Part_ID As Integer
        Private _removePart_ID As Integer
        Private _booLoadData As Boolean = False


#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objSyxRec = New PSS.Data.Buisness.SyxReceivingShipping()
            _objSyx = New PSS.Data.Buisness.Syx()
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
        Friend WithEvents Panel_PartConsumtion As System.Windows.Forms.Panel
        Friend WithEvents tpPartConsumption As System.Windows.Forms.TabPage
        Friend WithEvents LabelSerial As System.Windows.Forms.Label
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents LabelModel As System.Windows.Forms.Label
        Friend WithEvents LabelMfg As System.Windows.Forms.Label
        Friend WithEvents lblMfg As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents LabelProduct As System.Windows.Forms.Label
        Friend WithEvents lblProduct As System.Windows.Forms.Label
        Friend WithEvents Label_Status As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnAWAP As System.Windows.Forms.Button
        Friend WithEvents btnCONSUME As System.Windows.Forms.Button
        Friend WithEvents Status As System.Windows.Forms.Label
        Friend WithEvents txtPart As System.Windows.Forms.TextBox
        Friend WithEvents Label_Part As System.Windows.Forms.Label
        Friend WithEvents tcPartConsumption As System.Windows.Forms.TabControl
        Friend WithEvents dbgConsumedParts As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblDeviceStatus As System.Windows.Forms.Label
        Friend WithEvents btnRemovePart As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllParts As System.Windows.Forms.Button
        Friend WithEvents lblRemovePart As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SyxPartsConsumption))
            Me.Panel_PartConsumtion = New System.Windows.Forms.Panel()
            Me.lblRemovePart = New System.Windows.Forms.Label()
            Me.btnRemoveAllParts = New System.Windows.Forms.Button()
            Me.btnRemovePart = New System.Windows.Forms.Button()
            Me.dbgConsumedParts = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label_Part = New System.Windows.Forms.Label()
            Me.txtPart = New System.Windows.Forms.TextBox()
            Me.btnCONSUME = New System.Windows.Forms.Button()
            Me.btnAWAP = New System.Windows.Forms.Button()
            Me.Status = New System.Windows.Forms.Label()
            Me.tcPartConsumption = New System.Windows.Forms.TabControl()
            Me.tpPartConsumption = New System.Windows.Forms.TabPage()
            Me.LabelSerial = New System.Windows.Forms.Label()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.LabelModel = New System.Windows.Forms.Label()
            Me.LabelMfg = New System.Windows.Forms.Label()
            Me.lblMfg = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.LabelProduct = New System.Windows.Forms.Label()
            Me.lblProduct = New System.Windows.Forms.Label()
            Me.lblDeviceStatus = New System.Windows.Forms.Label()
            Me.Label_Status = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.Panel_PartConsumtion.SuspendLayout()
            CType(Me.dbgConsumedParts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tcPartConsumption.SuspendLayout()
            Me.tpPartConsumption.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel_PartConsumtion
            '
            Me.Panel_PartConsumtion.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.Panel_PartConsumtion.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRemovePart, Me.btnRemoveAllParts, Me.btnRemovePart, Me.dbgConsumedParts, Me.Label_Part, Me.txtPart, Me.btnCONSUME, Me.btnAWAP, Me.Status})
            Me.Panel_PartConsumtion.ForeColor = System.Drawing.Color.Green
            Me.Panel_PartConsumtion.Location = New System.Drawing.Point(8, 16)
            Me.Panel_PartConsumtion.Name = "Panel_PartConsumtion"
            Me.Panel_PartConsumtion.Size = New System.Drawing.Size(720, 368)
            Me.Panel_PartConsumtion.TabIndex = 1
            '
            'lblRemovePart
            '
            Me.lblRemovePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRemovePart.ForeColor = System.Drawing.Color.Lime
            Me.lblRemovePart.Location = New System.Drawing.Point(248, 328)
            Me.lblRemovePart.Name = "lblRemovePart"
            Me.lblRemovePart.Size = New System.Drawing.Size(216, 24)
            Me.lblRemovePart.TabIndex = 29
            Me.lblRemovePart.Text = "Part to remove"
            Me.lblRemovePart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnRemoveAllParts
            '
            Me.btnRemoveAllParts.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllParts.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllParts.Location = New System.Drawing.Point(584, 328)
            Me.btnRemoveAllParts.Name = "btnRemoveAllParts"
            Me.btnRemoveAllParts.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllParts.Size = New System.Drawing.Size(120, 30)
            Me.btnRemoveAllParts.TabIndex = 28
            Me.btnRemoveAllParts.Text = "Remove All Parts"
            '
            'btnRemovePart
            '
            Me.btnRemovePart.BackColor = System.Drawing.Color.Tomato
            Me.btnRemovePart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemovePart.ForeColor = System.Drawing.Color.White
            Me.btnRemovePart.Location = New System.Drawing.Point(472, 328)
            Me.btnRemovePart.Name = "btnRemovePart"
            Me.btnRemovePart.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemovePart.Size = New System.Drawing.Size(96, 30)
            Me.btnRemovePart.TabIndex = 27
            Me.btnRemovePart.Text = "Remove Part"
            '
            'dbgConsumedParts
            '
            Me.dbgConsumedParts.AllowColMove = False
            Me.dbgConsumedParts.AllowColSelect = False
            Me.dbgConsumedParts.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgConsumedParts.AllowSort = False
            Me.dbgConsumedParts.AllowUpdate = False
            Me.dbgConsumedParts.AllowUpdateOnBlur = False
            Me.dbgConsumedParts.AlternatingRows = True
            Me.dbgConsumedParts.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgConsumedParts.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.dbgConsumedParts.Caption = "Parts History"
            Me.dbgConsumedParts.CaptionHeight = 19
            Me.dbgConsumedParts.CollapseColor = System.Drawing.Color.White
            Me.dbgConsumedParts.ExpandColor = System.Drawing.Color.White
            Me.dbgConsumedParts.FilterBar = True
            Me.dbgConsumedParts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgConsumedParts.ForeColor = System.Drawing.Color.White
            Me.dbgConsumedParts.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgConsumedParts.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgConsumedParts.Location = New System.Drawing.Point(248, 40)
            Me.dbgConsumedParts.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgConsumedParts.Name = "dbgConsumedParts"
            Me.dbgConsumedParts.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgConsumedParts.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgConsumedParts.PreviewInfo.ZoomFactor = 75
            Me.dbgConsumedParts.RowHeight = 20
            Me.dbgConsumedParts.Size = New System.Drawing.Size(456, 280)
            Me.dbgConsumedParts.TabIndex = 25
            Me.dbgConsumedParts.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{Font:Microsoft Sans Serif, 6.75pt, style" & _
            "=Bold;ForeColor:Black;BackColor:White;}Footer{}Caption{AlignHorz:Center;ForeColo" & _
            "r:White;BackColor:SteelBlue;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, s" & _
            "tyle=Bold;AlignVert:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRo" & _
            "w{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddRow{ForeColor:Black;B" & _
            "ackColor:LightSteelBlue;}RecordSelector{ForeColor:White;AlignImage:Center;}Style" & _
            "15{}Heading{Wrap:True;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Ce" & _
            "nter;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:Blue;AlignVert:Center" & _
            ";}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style16{}Style17{}S" & _
            "tyle9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""Fals" & _
            "e"" AllowColSelect=""False"" Name="""" AllowRowSizing=""None"" AlternatingRowStyle=""Tru" & _
            "e"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" FilterBar" & _
            "=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=" & _
            """17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>257</Height><Capt" & _
            "ionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5""" & _
            " /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBa" & _
            "r"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=" & _
            """Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRo" & _
            "wStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""" & _
            "Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent" & _
            "=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" />" & _
            "<Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 19, 452, 257</ClientRect><Bo" & _
            "rderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.Me" & _
            "rgeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Norm" & _
            "al"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading""" & _
            " me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" m" & _
            "e=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""H" & _
            "ighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""" & _
            "OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" m" & _
            "e=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1" & _
            "</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>" & _
            "17</DefaultRecSelWidth><ClientArea>0, 0, 452, 276</ClientArea><PrintPageHeaderSt" & _
            "yle parent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Bl" & _
            "ob>"
            '
            'Label_Part
            '
            Me.Label_Part.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Part.ForeColor = System.Drawing.Color.White
            Me.Label_Part.Location = New System.Drawing.Point(8, 48)
            Me.Label_Part.Name = "Label_Part"
            Me.Label_Part.Size = New System.Drawing.Size(40, 23)
            Me.Label_Part.TabIndex = 12
            Me.Label_Part.Text = "Part:"
            Me.Label_Part.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPart
            '
            Me.txtPart.Location = New System.Drawing.Point(56, 48)
            Me.txtPart.Name = "txtPart"
            Me.txtPart.Size = New System.Drawing.Size(176, 20)
            Me.txtPart.TabIndex = 11
            Me.txtPart.Text = ""
            '
            'btnCONSUME
            '
            Me.btnCONSUME.BackColor = System.Drawing.Color.Green
            Me.btnCONSUME.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCONSUME.ForeColor = System.Drawing.Color.White
            Me.btnCONSUME.Location = New System.Drawing.Point(128, 88)
            Me.btnCONSUME.Name = "btnCONSUME"
            Me.btnCONSUME.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCONSUME.Size = New System.Drawing.Size(100, 30)
            Me.btnCONSUME.TabIndex = 10
            Me.btnCONSUME.Text = "CONSUME"
            '
            'btnAWAP
            '
            Me.btnAWAP.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(128, Byte))
            Me.btnAWAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnAWAP.ForeColor = System.Drawing.Color.Indigo
            Me.btnAWAP.Location = New System.Drawing.Point(16, 88)
            Me.btnAWAP.Name = "btnAWAP"
            Me.btnAWAP.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnAWAP.Size = New System.Drawing.Size(100, 30)
            Me.btnAWAP.TabIndex = 9
            Me.btnAWAP.Text = "AWAP"
            '
            'Status
            '
            Me.Status.BackColor = System.Drawing.Color.Black
            Me.Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Status.ForeColor = System.Drawing.Color.Lime
            Me.Status.Name = "Status"
            Me.Status.Size = New System.Drawing.Size(712, 40)
            Me.Status.TabIndex = 2
            Me.Status.Text = "Syx Parts Consumption"
            Me.Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'tcPartConsumption
            '
            Me.tcPartConsumption.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpPartConsumption})
            Me.tcPartConsumption.Location = New System.Drawing.Point(8, 80)
            Me.tcPartConsumption.Name = "tcPartConsumption"
            Me.tcPartConsumption.SelectedIndex = 0
            Me.tcPartConsumption.Size = New System.Drawing.Size(744, 416)
            Me.tcPartConsumption.TabIndex = 2
            '
            'tpPartConsumption
            '
            Me.tpPartConsumption.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel_PartConsumtion})
            Me.tpPartConsumption.Location = New System.Drawing.Point(4, 22)
            Me.tpPartConsumption.Name = "tpPartConsumption"
            Me.tpPartConsumption.Size = New System.Drawing.Size(736, 390)
            Me.tpPartConsumption.TabIndex = 0
            Me.tpPartConsumption.Text = "Part Consumption"
            '
            'LabelSerial
            '
            Me.LabelSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSerial.ForeColor = System.Drawing.Color.White
            Me.LabelSerial.Location = New System.Drawing.Point(16, 16)
            Me.LabelSerial.Name = "LabelSerial"
            Me.LabelSerial.Size = New System.Drawing.Size(48, 23)
            Me.LabelSerial.TabIndex = 8
            Me.LabelSerial.Text = "Serial:"
            Me.LabelSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.Aqua
            Me.txtSerial.Location = New System.Drawing.Point(72, 16)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(184, 20)
            Me.txtSerial.TabIndex = 7
            Me.txtSerial.Text = ""
            '
            'LabelModel
            '
            Me.LabelModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelModel.ForeColor = System.Drawing.Color.White
            Me.LabelModel.Location = New System.Drawing.Point(512, 48)
            Me.LabelModel.Name = "LabelModel"
            Me.LabelModel.Size = New System.Drawing.Size(48, 23)
            Me.LabelModel.TabIndex = 12
            Me.LabelModel.Text = "Model:"
            Me.LabelModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'LabelMfg
            '
            Me.LabelMfg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelMfg.ForeColor = System.Drawing.Color.White
            Me.LabelMfg.Location = New System.Drawing.Point(264, 48)
            Me.LabelMfg.Name = "LabelMfg"
            Me.LabelMfg.Size = New System.Drawing.Size(40, 23)
            Me.LabelMfg.TabIndex = 10
            Me.LabelMfg.Text = "Mfg:"
            Me.LabelMfg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMfg
            '
            Me.lblMfg.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.lblMfg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMfg.Location = New System.Drawing.Point(304, 48)
            Me.lblMfg.Name = "lblMfg"
            Me.lblMfg.Size = New System.Drawing.Size(184, 23)
            Me.lblMfg.TabIndex = 11
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.Location = New System.Drawing.Point(560, 48)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(184, 23)
            Me.lblModel.TabIndex = 13
            '
            'LabelProduct
            '
            Me.LabelProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelProduct.ForeColor = System.Drawing.Color.White
            Me.LabelProduct.Location = New System.Drawing.Point(8, 48)
            Me.LabelProduct.Name = "LabelProduct"
            Me.LabelProduct.Size = New System.Drawing.Size(64, 23)
            Me.LabelProduct.TabIndex = 6
            Me.LabelProduct.Text = "Product:"
            Me.LabelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProduct
            '
            Me.lblProduct.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProduct.Location = New System.Drawing.Point(72, 48)
            Me.lblProduct.Name = "lblProduct"
            Me.lblProduct.Size = New System.Drawing.Size(184, 23)
            Me.lblProduct.TabIndex = 9
            '
            'lblDeviceStatus
            '
            Me.lblDeviceStatus.BackColor = System.Drawing.Color.Aqua
            Me.lblDeviceStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceStatus.Location = New System.Drawing.Point(560, 16)
            Me.lblDeviceStatus.Name = "lblDeviceStatus"
            Me.lblDeviceStatus.Size = New System.Drawing.Size(184, 20)
            Me.lblDeviceStatus.TabIndex = 14
            '
            'Label_Status
            '
            Me.Label_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Status.ForeColor = System.Drawing.Color.White
            Me.Label_Status.Location = New System.Drawing.Point(448, 16)
            Me.Label_Status.Name = "Label_Status"
            Me.Label_Status.Size = New System.Drawing.Size(112, 23)
            Me.Label_Status.TabIndex = 15
            Me.Label_Status.Text = "Device Status:"
            Me.Label_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.Blue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnClear.Location = New System.Drawing.Point(352, 16)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 24)
            Me.btnClear.TabIndex = 152
            Me.btnClear.Text = "&Clear"
            '
            'SyxPartsConsumption
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(768, 502)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnClear, Me.LabelSerial, Me.txtSerial, Me.LabelModel, Me.LabelMfg, Me.lblMfg, Me.lblModel, Me.LabelProduct, Me.lblProduct, Me.tcPartConsumption, Me.lblDeviceStatus, Me.Label_Status})
            Me.Name = "SyxPartsConsumption"
            Me.Text = "Syx Parts Consumption"
            Me.Panel_PartConsumtion.ResumeLayout(False)
            CType(Me.dbgConsumedParts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tcPartConsumption.ResumeLayout(False)
            Me.tpPartConsumption.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " Loading "
        '*******************************************************************

        Private Sub SyxPartsConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Me.ResetGlobals()

        End Sub


        '*************************************************************************************************************
        Private Sub LoadConsumedParts(ByVal Device_ID As Integer)
            Dim dt As DataTable
            Dim i As Integer
            Try

                dt = Me._objSyx.GetPartsConsumptionInfo(Device_ID)
                If dt.Rows.Count > 0 Then
                    With Me.dbgConsumedParts
                        .DataSource = Nothing
                        .DataSource = dt.DefaultView

                        For i = 0 To dt.Columns.Count - 1
                            'Make some columns invisible
                            .Splits(0).DisplayColumns(i).Visible = False
                        Next i
                        .Splits(0).DisplayColumns("Part_Name").Width = 200
                        .Splits(0).DisplayColumns("Transaction").Width = 75
                        .Splits(0).DisplayColumns("Consumption").Width = 75

                        .Splits(0).DisplayColumns("Part_Name").Visible = True
                        .Splits(0).DisplayColumns("Transaction").Visible = True
                        .Splits(0).DisplayColumns("Consumption").Visible = True

                    End With
                    Me.btnRemoveAllParts.Visible = True
                    Me.dbgConsumedParts.Visible = True
                Else
                    Me.btnRemoveAllParts.Visible = False
                    Me.dbgConsumedParts.Visible = False
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "LoadConsumedParts", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

#End Region

#Region " Button and TextBox Events "

        '*******************************************************************
        Private Sub TextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyUp, txtPart.KeyUp


            If e.KeyCode = Keys.Enter And sender.name = "txtSerial" AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            ElseIf e.KeyCode = Keys.Enter And sender.name = "txtPart" AndAlso Me.txtPart.Text.Trim.Length > 0 Then
                Me.ProcessPart()
            End If
        End Sub
        '*******************************************************************

        Private Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click, btnAWAP.Click, btnCONSUME.Click, btnRemovePart.Click, btnRemoveAllParts.Click
            'PC_Flag: 1=AWAP; 0= Consume
            'Trans_Amount: 1=add; -1=remove

            Dim user_id As Integer = ApplicationUser.IDuser

            If sender.name = "btnClear" Then
                Me.ResetGlobals()
            ElseIf sender.name = "btnAWAP" Then
                Me._objSyx.InsertSyxPartsConsumption(Me._Device_ID, Me._Part_ID, 1, ApplicationUser.IDuser, 1)
                Me.Status.Text = "This part#" & Me.txtPart.Text & " has been add for AWAP."
            ElseIf sender.name = "btnCONSUME" Then
                Me._objSyx.InsertSyxPartsConsumption(Me._Device_ID, Me._Part_ID, 1, ApplicationUser.IDuser, 0)
                Me.Status.Text = "This part#" & Me.txtPart.Text & " has been add for CONSUME."
            ElseIf sender.name = "btnRemovePart" Then
                Me._objSyx.InsertSyxPartsConsumption(Me._Device_ID, Me.lblRemovePart.Text, -1, ApplicationUser.IDuser, 0)
                Me.Status.Text = "This part#" & Me.lblRemovePart.Text & " has been removed."
            ElseIf sender.name = "btnRemoveAllParts" Then
                Dim i, Part_ID As Integer
                Dim Part_Name As String
                For i = 0 To Me.dbgConsumedParts.RowCount - 1
                    Me.dbgConsumedParts.Row = i
                    Part_ID = Me.dbgConsumedParts.Columns("Part_ID").Value
                    Part_Name = Me.dbgConsumedParts.Columns("Part_Name").Value
                    Me._objSyx.InsertSyxPartsConsumption(Me._Device_ID, Part_ID, -1, ApplicationUser.IDuser, 0)
                Next
                Me.Status.Text = "All parts for serial#" & Me.txtSerial.Text & " has been removed."
            End If

            Me.LoadConsumedParts(Me._Device_ID)
        End Sub

        '*************************************************************************************************************

#End Region


        Private Sub ProcessSN()

            Dim dtDevice As DataTable
            Dim dr As DataRow

            Try

                Me.txtSerial.Text = Me.txtSerial.Text.Trim.ToUpper
                Me.tcPartConsumption.Visible = False
                dtDevice = Me._objSyx.GetDeviceInfo(txtSerial.Text, True)

                If dtDevice.Rows.Count > 1 Then
                    MessageBox.Show("This serial#" & Me.txtSerial.Text & " existed twice in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                ElseIf dtDevice.Rows.Count = 0 Then
                    MessageBox.Show("The Serial#" & Me.txtSerial.Text & " is not found or has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                    'ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                    '    MessageBox.Show("This serial#" & Me.txtSerial.Text & " has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    '    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    '    Exit Sub
                    'ElseIf Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 1, "Functional", True, True) = False Then
                    '    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    '    Exit Sub
                    'ElseIf Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 2, "FQA", False, True) = False Then
                    '    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    '    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me._Device_ID = dtDevice.Rows(0)("Device_ID")
                    Me._Model_ID = dtDevice.Rows(0)("Model_ID")
                    Me.lblProduct.Text = dtDevice.Rows(0)("Prod_Desc")
                    Me.lblMfg.Text = dtDevice.Rows(0)("Manuf_Desc")
                    Me.lblModel.Text = dtDevice.Rows(0)("Model_Desc")
                    Me.lblDeviceStatus.Text = dtDevice.Rows(0)("Status")
                    'Me.txtSerial.Enabled = False
                    Me.LoadConsumedParts(Me._Device_ID)
                    Me.tcPartConsumption.Visible = True

                End If 'dtDevice
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Finally

                Buisness.Generic.DisposeDT(dtDevice)
                Me.Enabled = True : Cursor.Current = Cursors.Default

            End Try
        End Sub

        '*******************************************************************

        Private Sub ProcessPart()

            Dim dtPart As DataTable
            Dim dr As DataRow

            Try
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                Me.txtPart.Text = Me.txtPart.Text.Trim.ToUpper
                dtPart = Me._objSyx.GetPartsInfo(txtPart.Text)

                If dtPart.Rows.Count = 0 Then
                    Me.Status.ForeColor = Color.Red
                    Me.Status.Text = "This part#" & Me.txtPart.Text & " is NOT found in the Part Inventory. Please try again..."
                    Me._Part_ID = 0
                    Me.btnAWAP.Visible = False
                    Me.btnCONSUME.Visible = False
                Else
                    Me._Part_ID = dtPart.Rows(0)("Part_ID")
                    Me.Status.ForeColor = Color.Lime
                    Me.Status.Text = "Click on the 'AWAP' or 'CONSUME' button to assign this part..."
                    Me.btnAWAP.Visible = True
                    Me.btnCONSUME.Visible = True

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessPart", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Finally

                Buisness.Generic.DisposeDT(dtPart)
                Me.Enabled = True : Cursor.Current = Cursors.Default

            End Try
        End Sub

        '*****************************************************************

        Private Sub ResetGlobals()

            'Clear global variable


            'Update Area
            Me._removePart_ID = 0
            Me.lblRemovePart.Text = ""
            Me.btnRemovePart.Visible = False
            Me.btnRemoveAllParts.Visible = False
            Me.dbgConsumedParts.Visible = False

            Me.tcPartConsumption.Visible = False
            Me.txtPart.Text = ""
            Me._Device_ID = 0
            Me.lblProduct.Text = ""
            Me.lblMfg.Text = ""
            Me.lblModel.Text = ""
            Me.lblDeviceStatus.Text = ""
            Me.Status.ForeColor = Color.Lime
            Me.Status.Text = "Scan or enter part name then press enter ...."
            Me.btnAWAP.Visible = False
            Me.btnCONSUME.Visible = False
            Me.txtSerial.Enabled = True
            Me.txtSerial.Text = ""
            Me.txtSerial.Focus()

        End Sub


        '*****************************************************************


        Private Sub dbgConsumedParts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dbgConsumedParts.Click

            Try
                If Me.dbgConsumedParts.RowCount > 0 AndAlso Me.dbgConsumedParts.Columns.Count > 0 Then

                    Me._removePart_ID = CInt(Me.dbgConsumedParts.Columns("PC_ID").Value)
                    Me.lblRemovePart.Text = Me.dbgConsumedParts.Columns("Part_Name").Value
                    Me.btnRemovePart.Visible = True
                Else
                    Me.btnRemovePart.Visible = False
                    Me._removePart_ID = 0
                    Me.lblRemovePart.Text = ""
                End If


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgConsumedParts_Click", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End Try

        End Sub
    End Class
End Namespace