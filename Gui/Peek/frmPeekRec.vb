Option Explicit On 

Imports System.IO
Imports PSS.Data.Buisness

Namespace Gui.Peek
    Public Class frmPeekRec
        Inherits System.Windows.Forms.Form

        Private _objPeekBiz As PSS.Data.Buisness.Peek.Biz
        Private _booPopulateData As Boolean = False
        Private _iWOID As Integer = 0
        Private _iTrayID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objPeekBiz = New PSS.Data.Buisness.Peek.Biz()
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
        Friend WithEvents btnLoadDataFrExcel As System.Windows.Forms.Button
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboProduct As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents chkReturnOrder As System.Windows.Forms.CheckBox
        Friend WithEvents chkHasDataFile As System.Windows.Forms.CheckBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents txtCustWO As System.Windows.Forms.TextBox
        Friend WithEvents txtWOMemo As System.Windows.Forms.TextBox
        Friend WithEvents txtReturnTrackingNo As System.Windows.Forms.TextBox
        Friend WithEvents cboModels As C1.Win.C1List.C1Combo
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents lblScanQty As System.Windows.Forms.Label
        Friend WithEvents lblRecdQty As System.Windows.Forms.Label
        Friend WithEvents btnBillPeekOrder As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPeekRec))
            Me.btnLoadDataFrExcel = New System.Windows.Forms.Button()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.cboCustomer = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboProduct = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.txtCustWO = New System.Windows.Forms.TextBox()
            Me.chkReturnOrder = New System.Windows.Forms.CheckBox()
            Me.chkHasDataFile = New System.Windows.Forms.CheckBox()
            Me.txtWOMemo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtReturnTrackingNo = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblRecdQty = New System.Windows.Forms.Label()
            Me.cboModels = New C1.Win.C1List.C1Combo()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.lblScanQty = New System.Windows.Forms.Label()
            Me.btnBillPeekOrder = New System.Windows.Forms.Button()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnLoadDataFrExcel
            '
            Me.btnLoadDataFrExcel.BackColor = System.Drawing.Color.CadetBlue
            Me.btnLoadDataFrExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnLoadDataFrExcel.ForeColor = System.Drawing.Color.White
            Me.btnLoadDataFrExcel.Location = New System.Drawing.Point(576, 408)
            Me.btnLoadDataFrExcel.Name = "btnLoadDataFrExcel"
            Me.btnLoadDataFrExcel.Size = New System.Drawing.Size(144, 23)
            Me.btnLoadDataFrExcel.TabIndex = 0
            Me.btnLoadDataFrExcel.Text = "Load Data From Excel"
            Me.btnLoadDataFrExcel.Visible = False
            '
            'cboLocation
            '
            Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocation.AutoCompletion = True
            Me.cboLocation.AutoDropDown = True
            Me.cboLocation.AutoSelect = True
            Me.cboLocation.Caption = ""
            Me.cboLocation.CaptionHeight = 17
            Me.cboLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocation.ColumnCaptionHeight = 17
            Me.cboLocation.ColumnFooterHeight = 17
            Me.cboLocation.ColumnHeaders = False
            Me.cboLocation.ContentHeight = 15
            Me.cboLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocation.EditorHeight = 15
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(144, 75)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(10, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(224, 21)
            Me.cboLocation.TabIndex = 3
            Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.White
            Me.Label8.Location = New System.Drawing.Point(64, 75)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(80, 21)
            Me.Label8.TabIndex = 136
            Me.Label8.Text = "Location :"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboCustomer.Location = New System.Drawing.Point(144, 45)
            Me.cboCustomer.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomer.MaxDropDownItems = CType(10, Short)
            Me.cboCustomer.MaxLength = 32767
            Me.cboCustomer.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomer.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomer.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomer.Size = New System.Drawing.Size(224, 21)
            Me.cboCustomer.TabIndex = 2
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(64, 45)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 21)
            Me.Label4.TabIndex = 135
            Me.Label4.Text = "Customer :"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboProduct
            '
            Me.cboProduct.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboProduct.AutoCompletion = True
            Me.cboProduct.AutoDropDown = True
            Me.cboProduct.AutoSelect = True
            Me.cboProduct.Caption = ""
            Me.cboProduct.CaptionHeight = 17
            Me.cboProduct.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboProduct.ColumnCaptionHeight = 17
            Me.cboProduct.ColumnFooterHeight = 17
            Me.cboProduct.ColumnHeaders = False
            Me.cboProduct.ContentHeight = 15
            Me.cboProduct.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboProduct.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboProduct.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboProduct.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboProduct.EditorHeight = 15
            Me.cboProduct.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboProduct.ItemHeight = 15
            Me.cboProduct.Location = New System.Drawing.Point(144, 16)
            Me.cboProduct.MatchEntryTimeout = CType(2000, Long)
            Me.cboProduct.MaxDropDownItems = CType(10, Short)
            Me.cboProduct.MaxLength = 32767
            Me.cboProduct.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboProduct.Name = "cboProduct"
            Me.cboProduct.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboProduct.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboProduct.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboProduct.Size = New System.Drawing.Size(224, 21)
            Me.cboProduct.TabIndex = 1
            Me.cboProduct.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(72, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 21)
            Me.Label2.TabIndex = 134
            Me.Label2.Text = "Product :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.Color.White
            Me.Label5.Location = New System.Drawing.Point(40, 40)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(120, 21)
            Me.Label5.TabIndex = 138
            Me.Label5.Text = "Work Order # :"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.Location = New System.Drawing.Point(144, 272)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(224, 20)
            Me.txtDeviceSN.TabIndex = 7
            Me.txtDeviceSN.Text = ""
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.White
            Me.Label7.Location = New System.Drawing.Point(56, 272)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(88, 21)
            Me.Label7.TabIndex = 140
            Me.Label7.Text = "S/N :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustWO
            '
            Me.txtCustWO.Location = New System.Drawing.Point(160, 40)
            Me.txtCustWO.Name = "txtCustWO"
            Me.txtCustWO.Size = New System.Drawing.Size(224, 20)
            Me.txtCustWO.TabIndex = 2
            Me.txtCustWO.Text = ""
            '
            'chkReturnOrder
            '
            Me.chkReturnOrder.Enabled = False
            Me.chkReturnOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkReturnOrder.ForeColor = System.Drawing.Color.White
            Me.chkReturnOrder.Location = New System.Drawing.Point(144, 107)
            Me.chkReturnOrder.Name = "chkReturnOrder"
            Me.chkReturnOrder.TabIndex = 4
            Me.chkReturnOrder.Text = "Return Order"
            '
            'chkHasDataFile
            '
            Me.chkHasDataFile.Checked = True
            Me.chkHasDataFile.CheckState = System.Windows.Forms.CheckState.Checked
            Me.chkHasDataFile.Enabled = False
            Me.chkHasDataFile.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkHasDataFile.ForeColor = System.Drawing.Color.White
            Me.chkHasDataFile.Location = New System.Drawing.Point(264, 107)
            Me.chkHasDataFile.Name = "chkHasDataFile"
            Me.chkHasDataFile.TabIndex = 5
            Me.chkHasDataFile.Text = "Has ASN"
            '
            'txtWOMemo
            '
            Me.txtWOMemo.Location = New System.Drawing.Point(160, 72)
            Me.txtWOMemo.Name = "txtWOMemo"
            Me.txtWOMemo.Size = New System.Drawing.Size(224, 20)
            Me.txtWOMemo.TabIndex = 3
            Me.txtWOMemo.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(16, 72)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(144, 21)
            Me.Label1.TabIndex = 142
            Me.Label1.Text = "Work Order Memo :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtReturnTrackingNo
            '
            Me.txtReturnTrackingNo.Enabled = False
            Me.txtReturnTrackingNo.Location = New System.Drawing.Point(160, 8)
            Me.txtReturnTrackingNo.Name = "txtReturnTrackingNo"
            Me.txtReturnTrackingNo.Size = New System.Drawing.Size(224, 20)
            Me.txtReturnTrackingNo.TabIndex = 1
            Me.txtReturnTrackingNo.Text = ""
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(16, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(144, 21)
            Me.Label3.TabIndex = 144
            Me.Label3.Text = "Return Tracking # :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.White
            Me.Label9.Location = New System.Drawing.Point(432, 8)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(288, 40)
            Me.Label9.TabIndex = 145
            Me.Label9.Text = "Received Qty"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblRecdQty
            '
            Me.lblRecdQty.BackColor = System.Drawing.Color.Black
            Me.lblRecdQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblRecdQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 80.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRecdQty.ForeColor = System.Drawing.Color.Lime
            Me.lblRecdQty.Location = New System.Drawing.Point(424, 48)
            Me.lblRecdQty.Name = "lblRecdQty"
            Me.lblRecdQty.Size = New System.Drawing.Size(296, 104)
            Me.lblRecdQty.TabIndex = 146
            Me.lblRecdQty.Text = "0"
            Me.lblRecdQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboModels
            '
            Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModels.AutoCompletion = True
            Me.cboModels.AutoDropDown = True
            Me.cboModels.AutoSelect = True
            Me.cboModels.Caption = ""
            Me.cboModels.CaptionHeight = 17
            Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModels.ColumnCaptionHeight = 17
            Me.cboModels.ColumnFooterHeight = 17
            Me.cboModels.ColumnHeaders = False
            Me.cboModels.ContentHeight = 15
            Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModels.EditorHeight = 15
            Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboModels.ItemHeight = 15
            Me.cboModels.Location = New System.Drawing.Point(160, 104)
            Me.cboModels.MatchEntryTimeout = CType(2000, Long)
            Me.cboModels.MaxDropDownItems = CType(10, Short)
            Me.cboModels.MaxLength = 32767
            Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModels.Name = "cboModels"
            Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModels.Size = New System.Drawing.Size(224, 21)
            Me.cboModels.TabIndex = 4
            Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            "ultRecSelWidth>16</DefaultRecSelWidth></Blob>"
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.White
            Me.Label6.Location = New System.Drawing.Point(80, 104)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(80, 21)
            Me.Label6.TabIndex = 148
            Me.Label6.Text = "Model :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Panel1
            '
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtReturnTrackingNo, Me.txtWOMemo, Me.Label1, Me.txtCustWO, Me.Label3, Me.Label5, Me.cboModels, Me.Label6})
            Me.Panel1.Location = New System.Drawing.Point(-16, 128)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(392, 128)
            Me.Panel1.TabIndex = 6
            Me.Panel1.Visible = False
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(440, 184)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(272, 40)
            Me.Label10.TabIndex = 147
            Me.Label10.Text = "Scan Qty"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblScanQty
            '
            Me.lblScanQty.BackColor = System.Drawing.Color.Black
            Me.lblScanQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScanQty.Font = New System.Drawing.Font("Tahoma", 80.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScanQty.ForeColor = System.Drawing.Color.White
            Me.lblScanQty.Location = New System.Drawing.Point(424, 224)
            Me.lblScanQty.Name = "lblScanQty"
            Me.lblScanQty.Size = New System.Drawing.Size(296, 104)
            Me.lblScanQty.TabIndex = 148
            Me.lblScanQty.Text = "0"
            Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnBillPeekOrder
            '
            Me.btnBillPeekOrder.BackColor = System.Drawing.Color.CadetBlue
            Me.btnBillPeekOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnBillPeekOrder.ForeColor = System.Drawing.Color.White
            Me.btnBillPeekOrder.Location = New System.Drawing.Point(576, 376)
            Me.btnBillPeekOrder.Name = "btnBillPeekOrder"
            Me.btnBillPeekOrder.Size = New System.Drawing.Size(144, 23)
            Me.btnBillPeekOrder.TabIndex = 149
            Me.btnBillPeekOrder.Text = "Bill Peek Order"
            Me.btnBillPeekOrder.Visible = False
            '
            'frmPeekRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(752, 445)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBillPeekOrder, Me.Label10, Me.lblScanQty, Me.Panel1, Me.Label9, Me.lblRecdQty, Me.chkHasDataFile, Me.chkReturnOrder, Me.txtDeviceSN, Me.Label7, Me.cboLocation, Me.Label8, Me.cboCustomer, Me.Label4, Me.cboProduct, Me.Label2, Me.btnLoadDataFrExcel})
            Me.Name = "frmPeekRec"
            Me.Text = "frmPeekRec"
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomer, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboProduct, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************
        Private Sub frmPeekRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If PSS.Core.ApplicationUser.GetPermission("PeekLoadASNFile") > 0 Then
                    Me.btnLoadDataFrExcel.Visible = True
                    Me.btnBillPeekOrder.Visible = True
                End If

                'Populate Products
                PopulateProductsList()

                PSS.Core.Highlight.SetHighLight(Me)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmPeekRec_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnLoadDataFrExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadDataFrExcel.Click
            Dim fdOpenFile As OpenFileDialog
            Dim i As Integer = 0
            Dim strFilePath As String = ""

            Try
                fdOpenFile = New OpenFileDialog()
                fdOpenFile.DefaultExt = ".xls"
                fdOpenFile.ShowDialog()
                strFilePath = fdOpenFile.FileName

                If strFilePath.Trim.Length = 0 Then
                    Exit Sub
                ElseIf strFilePath.Trim.EndsWith(".xls") = False Then
                    MessageBox.Show("Input file must be in excel format.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf File.Exists(strFilePath) = False Then
                    MessageBox.Show("File does not exist """ & strFilePath & """.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = Me._objPeekBiz.LoadDevices(strFilePath, PSS.Core.[Global].ApplicationUser.IDShift)

                    If i > 0 Then
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnLoadDataFrExcel_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If Not IsNothing(fdOpenFile) Then
                    fdOpenFile.Dispose()
                    fdOpenFile = Nothing
                End If
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateProductsList()
            Dim dt As DataTable

            Try
                'Populate product type
                _booPopulateData = True
                dt = Generic.GetProducts(True)
                Misc.PopulateC1DropDownList(Me.cboProduct, dt, "Prod_Desc", "Prod_ID")
                Me.cboProduct.SelectedValue = 0

            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub cbo_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboProduct.RowChange, cboCustomer.RowChange, cboLocation.RowChange
            Dim dt As DataTable

            Try
                If _booPopulateData = False Then
                    Me.txtDeviceSN.Text = ""
                    Me.lblRecdQty.Text = "0"
                    Me.txtReturnTrackingNo.Text = "" : Me.txtCustWO.Text = "" : Me.txtWOMemo.Text = ""

                    If sender.name = "cboProduct" Then
                        Me.cboCustomer.DataSource = Nothing : Me.cboCustomer.Text = ""
                        Me.cboLocation.DataSource = Nothing : Me.cboLocation.Text = ""
                        Me.cboModels.DataSource = Nothing : Me.cboModels.Text = ""

                        If Me.cboProduct.SelectedValue > 0 Then
                            'Populate Customer
                            Me.PopulateCustomerList()
                            Me.populateModelList()
                        End If
                    ElseIf sender.name = "cboCustomer" Then
                        Me.cboLocation.DataSource = Nothing : Me.cboLocation.Text = ""
                        If Me.cboCustomer.SelectedValue > 0 Then Me.PopulateLocationList()
                    ElseIf sender.name = "cboLocation" Then
                        If Me.cboLocation.SelectedValue > 0 Then
                            If Me.chkReturnOrder.Checked = True Then
                                Me.ProcessWorkOrder()
                                If Me._iWOID > 0 Then Me.cboModels.Focus()
                            Else
                                Me.txtDeviceSN.Focus()
                            End If
                        End If
                    ElseIf sender.name = "cboModels" Then
                        If Me.cboModels.SelectedValue > 0 Then
                            Me.txtCustWO.Focus()
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "RowChange_Event", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateCustomerList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetCustomers(True, Me.cboProduct.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Cust_Name1", "Cust_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboCustomer.SelectedValue = dt.Rows(0)("Cust_ID")
                    Me.PopulateLocationList()
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateModelList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                '*******************************
                'Load Model List
                '*******************************
                dt = Generic.GetModels(True, Me.cboProduct.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
                Me.cboModels.SelectedValue = 0
                '*******************************
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateLocationList()
            Dim dt As DataTable

            Try
                _booPopulateData = True
                dt = Generic.GetLocations(True, Me.cboCustomer.SelectedValue)
                Misc.PopulateC1DropDownList(Me.cboLocation, dt, "Loc_Name", "Loc_ID")
                If dt.Rows.Count = 2 Then
                    Me.cboLocation.SelectedValue = dt.Rows(0)("Loc_ID")
                End If
            Catch ex As Exception
                Throw ex
            Finally
                _booPopulateData = False
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub txt_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtReturnTrackingNo.KeyUp, txtCustWO.KeyUp, txtWOMemo.KeyUp, txtDeviceSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If sender.name = "txtReturnTrackingNo" Then
                        If Me.txtReturnTrackingNo.Text.Trim.Length > 0 Then Me.txtCustWO.Focus()
                    ElseIf sender.name = "txtCustWO" Then
                        If Me.txtCustWO.Text.Trim.Length > 0 Then Me.txtWOMemo.Focus() 'Me.ProcessWorkOrder()
                    ElseIf sender.name = "txtWOMemo" Then
                        If Me.txtWOMemo.Text.Trim.Length > 0 Then Me.txtDeviceSN.Focus()
                    ElseIf sender.name = "txtDeviceSN" Then
                        If Me.txtDeviceSN.Text.Trim.Length > 0 Then Me.ProcessSN()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txts_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************
        Private Function ProcessWorkOrder() As Boolean
            Dim dt As DataTable

            Try
                If Me.cboLocation.SelectedValue = 0 Then Exit Function

                If Me.cboProduct.SelectedValue = 0 Then
                    MessageBox.Show("Please select product.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboProduct.SelectAll()
                    Me.cboProduct.Focus()
                ElseIf Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                ElseIf Me.cboLocation.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.cboLocation.SelectAll()
                    Me.cboLocation.Focus()
                ElseIf Me.txtCustWO.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter Work Order #.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtCustWO.SelectAll()
                    Me.txtCustWO.Focus()
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dt = _objPeekBiz.GetReturnOpenWorkOrder(Me.txtCustWO.Text.Trim, Me.cboProduct.SelectedValue, Me.cboLocation.SelectedValue)

                    If dt.Rows.Count > 0 Then
                        Me._iWOID = dt.Rows(0)("WO_ID")
                        Me._iTrayID = dt.Rows(0)("Tray_ID")
                        Me.txtCustWO.Text = dt.Rows(0)("WO_CustWO") : Me.txtCustWO.Enabled = False
                        If Not IsDBNull(dt.Rows(0)("WO_Memo")) Then
                            Me.txtWOMemo.Text = dt.Rows(0)("WO_Memo")
                            Me.txtWOMemo.Enabled = False
                        End If
                    Else
                        Cursor.Current = Cursors.Default
                        MessageBox.Show("Please create return order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtCustWO.SelectAll()
                        Me.txtCustWO.Focus()
                    End If
                End If 'Validation
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txts_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessSN() As Boolean
            Dim booResult As Boolean = False

            Try
                If Me.txtDeviceSN.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll()
                    Me.txtDeviceSN.Focus()
                ElseIf Me.cboCustomer.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomer.SelectAll()
                    Me.cboCustomer.Focus()
                ElseIf Me.cboLocation.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLocation.SelectAll()
                    Me.cboLocation.Focus()
                Else
                    If Me.chkReturnOrder.Checked = True Then
                        booResult = Me.ProcessReturnWOSN()
                    Else
                        booResult = Me.ProcessRegWOSN()
                    End If 'Return order
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessRegWOSN() As Boolean
            Dim dt As DataTable
            Dim i As Integer = 0
            Dim drDevices() As DataRow

            Try
                If Me.txtDeviceSN.Text.Trim.Length = 0 Then Exit Function

                dt = Me._objPeekBiz.GetPeekDevice(Me.cboLocation.SelectedValue, Me.txtDeviceSN.Text)

                If dt.Rows.Count = 0 Then
                    MessageBox.Show("S/N does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll()
                    Me.txtDeviceSN.Focus()
                ElseIf dt.Rows.Count = 1 AndAlso dt.Rows(0)("Device_FinishedGoods") = 1 Then
                    MessageBox.Show("S/N has already scan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll()
                    Me.txtDeviceSN.Focus()
                ElseIf dt.Rows.Count = 1 AndAlso dt.Rows(0)("CustomerReturn") = 1 Then
                    MessageBox.Show("S/N belong to customer return order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll()
                    Me.txtDeviceSN.Focus()
                Else
                    drDevices = dt.Select("Device_FinishedGoods = 0 AND CustomerReturn = 0")

                    If drDevices.Length = 0 Then
                        MessageBox.Show("S/N does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDeviceSN.SelectAll()
                        Me.txtDeviceSN.Focus()
                    ElseIf drDevices.Length > 1 Then
                        MessageBox.Show("S/N existed more than one in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDeviceSN.SelectAll()
                        Me.txtDeviceSN.Focus()
                    ElseIf drDevices(0)("Device_FinishedGoods") = 1 Then
                        MessageBox.Show("S/N has already scan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDeviceSN.SelectAll()
                        Me.txtDeviceSN.Focus()
                    ElseIf drDevices(0)("CustomerReturn") = 1 Then
                        MessageBox.Show("S/N belong to customer return order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDeviceSN.SelectAll()
                        Me.txtDeviceSN.Focus()
                    Else
                        i = Me._objPeekBiz.ReceiveDevice(drDevices(0)("Device_ID"), PSS.Core.ApplicationUser.Workdate)
                        If i > 0 Then
                            Me.lblScanQty.Text = CInt(Me.lblScanQty.Text) + 1
                            Me.lblRecdQty.Text = Me._objPeekBiz.GetRecQty(drDevices(0)("WO_ID"))
                            Me.txtDeviceSN.Text = ""
                            Me.Enabled = True
                            Return True
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessReturnWOSN() As Boolean
            Try
                'Return Order. ADD ON LATER
                If Me.cboModels.SelectedValue = 0 Then
                    MessageBox.Show("Please select Model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModels.SelectAll()
                    Me.cboModels.Focus()
                ElseIf Me.txtCustWO.Text.Trim.Length = 0 Then
                    MessageBox.Show("Work Order is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtCustWO.SelectAll()
                    Me.txtCustWO.Focus()
                ElseIf Me._iWOID = 0 Then
                    MessageBox.Show("Work Order ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll()
                    Me.txtDeviceSN.Focus()
                ElseIf Me._iTrayID = 0 Then
                    MessageBox.Show("Tray ID is missing.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDeviceSN.SelectAll()
                    Me.txtDeviceSN.Focus()
                Else
                    'ADD ON LATER
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '**************************************************************************
        Private Sub btnBillPeekOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBillPeekOrder.Click
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim objPeekBilling As Peek.PeekBilling
            Dim i As Integer = 0

            Try
                dt = _objPeekBiz.GetNoneBillingPeekManifests()
                If dt.Rows.Count > 0 Then
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor
                    objPeekBilling = New Peek.PeekBilling()

                    For Each R1 In dt.Rows
                        i += objPeekBilling.BillPartsServices(R1("pkslip_ID"))
                    Next R1

                    If i > 0 Then MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("No data to bill.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnBillPeekOrder_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                objPeekBilling = Nothing : R1 = Nothing
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************

    End Class
End Namespace