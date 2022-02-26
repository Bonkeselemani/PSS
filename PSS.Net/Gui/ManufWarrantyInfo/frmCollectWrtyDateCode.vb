Option Explicit On 

Namespace Gui.ManufWarrantyInfo
    Public Class frmCollectWrtyDateCode
        Inherits System.Windows.Forms.Form

        Private booReturnFlg As Boolean = False
        Private _iManufWrty As Integer = -1
        Private _strLastDateInWarranty As String = ""
        Private _iManufCountryID As Integer = 0
        Private _strDateCode As String = ""
        Private _strInputCode As String = ""
        Private _iManufID As Integer = 0
        Private _dteReceiptDate As Date = Nothing
        Private _iModelID As Integer

#Region "Properties"
        '********************************
        'Read only property
        '********************************
        Public ReadOnly Property ReturnFlg() As Boolean
            Get
                Return Me.booReturnFlg
            End Get
        End Property
        Public ReadOnly Property ManufWrty() As Integer
            Get
                Return Me._iManufWrty
            End Get
        End Property
        Public ReadOnly Property LastDateInWarranty() As String
            Get
                Return Me._strLastDateInWarranty
            End Get
        End Property
        Public ReadOnly Property ManufacturingCountryID() As Integer
            Get
                Return Me._iManufCountryID
            End Get
        End Property
        Public ReadOnly Property DateCode() As String
            Get
                Return Me._strDateCode
            End Get
        End Property
        Public ReadOnly Property Code() As String
            Get
                Return Me._strInputCode
            End Get
        End Property
        ''*******************************************
        'Public WriteOnly Property ReceiptDate() As Date
        '    Set(ByVal Value As Date)
        '        Me._dteReceiptDate = Value
        '    End Set
        'End Property
#End Region

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iModelID As Integer, ByVal iManufID As Integer, ByVal dteReceiptDate As Date)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iManufID = iManufID
            Me._dteReceiptDate = dteReceiptDate
            _iModelID = iModelID

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
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents txtDateCode As System.Windows.Forms.TextBox
        Friend WithEvents pnlMSN As System.Windows.Forms.Panel
        Friend WithEvents pnlManfDate As System.Windows.Forms.Panel
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboMonth As C1.Win.C1List.C1Combo
        Friend WithEvents cboDay As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboYear As C1.Win.C1List.C1Combo
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCollectWrtyDateCode))
            Me.txtDateCode = New System.Windows.Forms.TextBox()
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.pnlMSN = New System.Windows.Forms.Panel()
            Me.pnlManfDate = New System.Windows.Forms.Panel()
            Me.cboYear = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboDay = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboMonth = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.pnlMSN.SuspendLayout()
            Me.pnlManfDate.SuspendLayout()
            CType(Me.cboYear, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboDay, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtDateCode
            '
            Me.txtDateCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDateCode.Location = New System.Drawing.Point(96, 16)
            Me.txtDateCode.MaxLength = 25
            Me.txtDateCode.Name = "txtDateCode"
            Me.txtDateCode.Size = New System.Drawing.Size(152, 23)
            Me.txtDateCode.TabIndex = 1
            Me.txtDateCode.Text = ""
            '
            'lblDateCode
            '
            Me.lblDateCode.BackColor = System.Drawing.Color.Transparent
            Me.lblDateCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateCode.ForeColor = System.Drawing.SystemColors.ControlText
            Me.lblDateCode.Location = New System.Drawing.Point(0, 16)
            Me.lblDateCode.Name = "lblDateCode"
            Me.lblDateCode.Size = New System.Drawing.Size(88, 16)
            Me.lblDateCode.TabIndex = 71
            Me.lblDateCode.Text = "Date Code:"
            Me.lblDateCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.SteelBlue
            Me.btnOK.ForeColor = System.Drawing.Color.White
            Me.btnOK.Location = New System.Drawing.Point(192, 120)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(72, 24)
            Me.btnOK.TabIndex = 3
            Me.btnOK.Text = "OK"
            '
            'pnlMSN
            '
            Me.pnlMSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDateCode, Me.lblDateCode})
            Me.pnlMSN.Location = New System.Drawing.Point(8, 8)
            Me.pnlMSN.Name = "pnlMSN"
            Me.pnlMSN.Size = New System.Drawing.Size(440, 48)
            Me.pnlMSN.TabIndex = 1
            '
            'pnlManfDate
            '
            Me.pnlManfDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboYear, Me.Label3, Me.cboDay, Me.Label2, Me.cboMonth, Me.Label1})
            Me.pnlManfDate.Location = New System.Drawing.Point(8, 56)
            Me.pnlManfDate.Name = "pnlManfDate"
            Me.pnlManfDate.Size = New System.Drawing.Size(440, 48)
            Me.pnlManfDate.TabIndex = 2
            '
            'cboYear
            '
            Me.cboYear.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboYear.AutoCompletion = True
            Me.cboYear.AutoDropDown = True
            Me.cboYear.AutoSelect = True
            Me.cboYear.Caption = ""
            Me.cboYear.CaptionHeight = 17
            Me.cboYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboYear.ColumnCaptionHeight = 17
            Me.cboYear.ColumnFooterHeight = 17
            Me.cboYear.ColumnHeaders = False
            Me.cboYear.ContentHeight = 15
            Me.cboYear.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboYear.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboYear.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboYear.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboYear.EditorHeight = 15
            Me.cboYear.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboYear.ItemHeight = 15
            Me.cboYear.Location = New System.Drawing.Point(352, 13)
            Me.cboYear.MatchEntryTimeout = CType(2000, Long)
            Me.cboYear.MaxDropDownItems = CType(10, Short)
            Me.cboYear.MaxLength = 32767
            Me.cboYear.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboYear.Name = "cboYear"
            Me.cboYear.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboYear.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboYear.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboYear.Size = New System.Drawing.Size(80, 21)
            Me.cboYear.TabIndex = 3
            Me.cboYear.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(304, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(48, 16)
            Me.Label3.TabIndex = 76
            Me.Label3.Text = "Year :"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboDay
            '
            Me.cboDay.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboDay.AutoCompletion = True
            Me.cboDay.AutoDropDown = True
            Me.cboDay.AutoSelect = True
            Me.cboDay.Caption = ""
            Me.cboDay.CaptionHeight = 17
            Me.cboDay.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboDay.ColumnCaptionHeight = 17
            Me.cboDay.ColumnFooterHeight = 17
            Me.cboDay.ColumnHeaders = False
            Me.cboDay.ContentHeight = 15
            Me.cboDay.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboDay.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboDay.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboDay.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboDay.EditorHeight = 15
            Me.cboDay.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboDay.ItemHeight = 15
            Me.cboDay.Location = New System.Drawing.Point(208, 14)
            Me.cboDay.MatchEntryTimeout = CType(2000, Long)
            Me.cboDay.MaxDropDownItems = CType(10, Short)
            Me.cboDay.MaxLength = 32767
            Me.cboDay.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboDay.Name = "cboDay"
            Me.cboDay.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboDay.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboDay.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboDay.Size = New System.Drawing.Size(80, 21)
            Me.cboDay.TabIndex = 2
            Me.cboDay.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(168, 16)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(40, 16)
            Me.Label2.TabIndex = 74
            Me.Label2.Text = "Day :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboMonth
            '
            Me.cboMonth.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboMonth.AutoCompletion = True
            Me.cboMonth.AutoDropDown = True
            Me.cboMonth.AutoSelect = True
            Me.cboMonth.Caption = ""
            Me.cboMonth.CaptionHeight = 17
            Me.cboMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboMonth.ColumnCaptionHeight = 17
            Me.cboMonth.ColumnFooterHeight = 17
            Me.cboMonth.ColumnHeaders = False
            Me.cboMonth.ContentHeight = 15
            Me.cboMonth.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboMonth.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboMonth.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboMonth.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboMonth.EditorHeight = 15
            Me.cboMonth.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboMonth.ItemHeight = 15
            Me.cboMonth.Location = New System.Drawing.Point(72, 14)
            Me.cboMonth.MatchEntryTimeout = CType(2000, Long)
            Me.cboMonth.MaxDropDownItems = CType(10, Short)
            Me.cboMonth.MaxLength = 32767
            Me.cboMonth.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboMonth.Name = "cboMonth"
            Me.cboMonth.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboMonth.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboMonth.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboMonth.Size = New System.Drawing.Size(80, 21)
            Me.cboMonth.TabIndex = 1
            Me.cboMonth.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(8, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(64, 16)
            Me.Label1.TabIndex = 72
            Me.Label1.Text = "Month :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmCollectWrtyDateCode
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(458, 168)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlManfDate, Me.pnlMSN, Me.btnOK})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmCollectWrtyDateCode"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Warranty Data Collection"
            Me.pnlMSN.ResumeLayout(False)
            Me.pnlManfDate.ResumeLayout(False)
            CType(Me.cboYear, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboDay, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboMonth, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************
        Private Sub frmCollectWrtyDateCode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.PopulateDateSelection()
                If _iManufID = 48 Then 'Huawei
                    lblDateCode.Text = "SN/MSN:"
                    Me.pnlMSN.Visible = True
                    Me.pnlManfDate.Visible = True
                    Me.cboMonth.SelectAll() : Me.cboMonth.SelectAll()
                Else
                    Me.pnlManfDate.Visible = False
                    Me.pnlMSN.Visible = True : Me.txtDateCode.SelectAll() : Me.txtDateCode.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmCollectWrtyDateCode_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************
        Private Sub PopulateDateSelection()
            Dim dt As DataTable
            Dim R1 As DataRow
            Dim i As Integer
            Dim dteToday As Date

            Try
                dteToday = CDate(Data.Buisness.Generic.MySQLServerDateTime(1))

                '*****************************************
                'Populate month
                '*****************************************
                dt = New DataTable()
                dt.Columns.Add("ID", GetType(Integer)) 'seq no
                dt.Columns.Add("Val", GetType(String)) 'Val
                For i = 0 To 12
                    R1 = dt.NewRow
                    R1("ID") = i
                    If i = 0 Then R1("Val") = "--Select--" Else R1("Val") = i
                    dt.Rows.Add(R1)
                Next i
                dt.AcceptChanges()
                Misc.PopulateC1DropDownList(Me.cboMonth, dt, "Val", "ID")
                Me.cboMonth.SelectedValue = 0

                '*****************************************
                'Populate day
                '*****************************************
                dt = Nothing : dt = New DataTable()
                dt.Columns.Add("ID", GetType(Integer)) 'seq no
                dt.Columns.Add("Val", GetType(String)) 'Val
                For i = 0 To 31
                    R1 = dt.NewRow
                    R1("ID") = i
                    If i = 0 Then R1("Val") = "--Select--" Else R1("Val") = i
                    dt.Rows.Add(R1)
                Next i
                dt.AcceptChanges()
                Misc.PopulateC1DropDownList(Me.cboDay, dt, "Val", "ID")
                Me.cboDay.SelectedValue = 0

                '*****************************************
                'Populate Year
                '*****************************************
                dt = New DataTable()
                dt.Columns.Add("ID", GetType(Integer)) 'seq no
                dt.Columns.Add("Val", GetType(String)) 'Val
                For i = dteToday.Year - 4 To dteToday.Year
                    R1 = dt.NewRow : R1("ID") = i : R1("Val") = i : dt.Rows.Add(R1)
                Next i
                dt.LoadDataRow(New Object() {0, "--select--"}, True)
                dt.AcceptChanges()
                Misc.PopulateC1DropDownList(Me.cboYear, dt, "Val", "ID")
                Me.cboYear.SelectedValue = 0
            Catch ex As Exception
                Throw ex
            Finally
                Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************
        Private Sub cboTrls_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboMonth.KeyUp, cboDay.KeyUp, cboYear.KeyUp
            Try
                If e.KeyValue = 13 Then
                    If sender.name = "cboMonth" Then
                        If Me.cboMonth.SelectedValue > 0 Then
                            Me.cboDay.SelectAll() : Me.cboDay.Focus()
                        End If
                    ElseIf sender.name = "cboDay" Then
                        If Me.cboDay.SelectedValue > 0 Then
                            Me.cboYear.SelectAll() : Me.cboYear.Focus()
                        End If
                    ElseIf sender.name = "cboYear" Then
                        'Do nothing
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboTrls_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**************************************************************************
        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Try
                If Me._iManufID = 24 Then
                    If ProcessWarrantyCode_Nokia() Then
                        Me.booReturnFlg = True : Me.Close()
                    End If
                ElseIf _iManufID = 48 Then
                    If ProcessWarrantyCode_Huawei() Then
                        Me.booReturnFlg = True : Me.Close()
                    End If
                ElseIf _iManufID = 201 Then
                    Dim bFound As Boolean = False
                    Dim row As DataRow
                    Dim dt = PSS.Data.Buisness.ModManuf.ParseExceptionCriteria("TF_ZTE_WARRANTY_DATE_CODE_ALPHA", "ModelIDs", ",")
                    For Each row In dt.rows
                        If row("Model_ID") = Me._iModelID Then
                            bFound = True : Exit For
                        End If
                    Next
                    If bFound Then
                        If ProcessWarrantyCode_ZTE(True) Then
                            Me.booReturnFlg = True : Me.Close()
                        End If
                    Else
                        If ProcessWarrantyCode_ZTE() Then
                            Me.booReturnFlg = True : Me.Close()
                        End If
                    End If
                ElseIf _iManufID = 202 Then
                    If ProcessWarrantyCode_Alcatel() Then
                        Me.booReturnFlg = True : Me.Close()
                    End If
                ElseIf _iManufID = 203 Then
                    If ProcessWarrantyCode_Unimax() Then
                        Me.booReturnFlg = True : Me.Close()
                    End If
                Else
                    MessageBox.Show("This function is not availble for selected manufacture.....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub txtDateCode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDateCode.KeyUp
            Try
                If e.KeyValue = 13 Then
                    If Me._iManufID = 24 Then
                        If ProcessWarrantyCode_Nokia() Then
                            Me.booReturnFlg = True : Me.Close()
                        End If
                    ElseIf _iManufID = 48 Then 'Huawei
                        'If ProcessWarrantyCode_Huawei() Then
                        '    Me.booReturnFlg = True : Me.Close()
                        'End If
                        Me.cboMonth.SelectAll() : Me.cboMonth.Focus()
                    ElseIf _iManufID = 201 Then 'ZTE
                        Dim bFound As Boolean = False
                        Dim row As DataRow
                        Dim dt = PSS.Data.Buisness.ModManuf.ParseExceptionCriteria("TF_ZTE_WARRANTY_DATE_CODE_ALPHA", "ModelIDs", ",")
                        For Each row In dt.rows
                            If row("Model_ID") = Me._iModelID Then
                                bFound = True : Exit For
                            End If
                        Next
                        If bFound Then
                            If ProcessWarrantyCode_ZTE(True) Then
                                Me.booReturnFlg = True : Me.Close()
                            End If
                        Else
                            If ProcessWarrantyCode_ZTE() Then
                                Me.booReturnFlg = True : Me.Close()
                            End If
                        End If
                        'If ProcessWarrantyCode_ZTE() Then
                        '    Me.booReturnFlg = True : Me.Close()
                        'End If
                    ElseIf _iManufID = 202 Then 'Alcatel
                        If ProcessWarrantyCode_Alcatel() Then
                            Me.booReturnFlg = True : Me.Close()
                        End If
                    ElseIf _iManufID = 203 Then 'Alcatel
                        If ProcessWarrantyCode_Unimax() Then
                            Me.booReturnFlg = True : Me.Close()
                        End If
                    Else
                        MessageBox.Show("This function is not availble for selected manufacture.....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDateCode_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Function ProcessWarrantyCode_Nokia() As Boolean
            Dim strDateCode, strManufCountryChar As String
            Dim R1 As DataRow
            Dim iManufacturingCountryID As Integer = 0

            Try
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Nokia = False

                If Me.txtDateCode.Text.Trim.Length = 0 Then
                    Return False
                ElseIf Me.txtDateCode.Text.Trim.Length < 13 Then
                    MessageBox.Show("Date code must be at least 13 character.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return False
                Else
                    strDateCode = "" : strManufCountryChar = ""

                    If Char.IsLetter(Me.txtDateCode.Text.Trim.Substring(7, 1), 0) = False Then
                        strDateCode = Me.txtDateCode.Text.Trim.Substring(7, 6)
                    Else
                        strDateCode = Me.txtDateCode.Text.Trim.Substring(7, 4)
                    End If
                    'strManufCountryChar = Me.txtDateCode.Text.Trim.Substring(13, 1)

                    R1 = PSS.Data.Buisness.WarrantyClaim.Nokia.GetWrtyStatusAndLastDateInWrty(strDateCode)
                    Me._iManufWrty = R1("WarrantyStatus")
                    Me._strLastDateInWarranty = CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd")
                    Me._iManufCountryID = 0 'PSS.Data.Buisness.WarrantyClaim.Nokia.GetManufacturingCountryID(strManufCountryChar)
                    Me._strDateCode = strDateCode
                    Me._strInputCode = Me.txtDateCode.Text.Trim
                    Me.booReturnFlg = True

                    ProcessWarrantyCode_Nokia = True
                    Return True
                End If

            Catch ex As Exception
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Nokia = False
                MessageBox.Show(ex.ToString, "ProcessWarrantyCode_Nokia()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessWarrantyCode_Huawei() As Boolean
            Dim strDateCode As String
            Dim R1 As DataRow
            Dim dteNow, dteRecDate As Date

            Try
                If Me.txtDateCode.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter SN/MSN.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtDateCode.SelectAll() : Me.txtDateCode.Focus()
                    Return False
                ElseIf Me.cboMonth.SelectedValue = 0 Then
                    MessageBox.Show("Please month.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboMonth.SelectAll() : Me.cboMonth.Focus()
                    Return False
                ElseIf Me.cboDay.SelectedValue = 0 Then
                    MessageBox.Show("Please select day.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboDay.SelectAll() : Me.cboDay.Focus()
                    Return False
                ElseIf Me.cboYear.SelectedValue = 0 Then
                    MessageBox.Show("Please select year.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboYear.SelectAll() : Me.cboYear.Focus()
                    Return False
                End If

                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Huawei = False

                If Not IsNothing(_dteReceiptDate) Then
                    dteRecDate = New Date(_dteReceiptDate.Year, _dteReceiptDate.Month, _dteReceiptDate.Day, 23, 59, 59)
                Else
                    dteNow = CDate(CDate(Data.Buisness.Generic.MySQLServerDateTime(1)).ToString("yyyy-MM-dd"))
                    dteRecDate = New Date(dteNow.Year, dteNow.Month, dteNow.Day, 23, 59, 59)
                End If

                If Me.txtDateCode.Text.Trim.Length = 0 OrElse Me.cboMonth.SelectedValue = 0 OrElse Me.cboDay.SelectedValue = 0 OrElse Me.cboYear.SelectedValue = 0 Then
                    Return False
                Else
                    '  R1 = PSS.Data.Buisness.WarrantyClaim.Huawei.GetWrtyStatusAndLastDateInWrty(Me.txtDateCode.Text.Trim.ToUpper)
                    R1 = PSS.Data.Buisness.WarrantyClaim.Huawei.GetWrtyStatusAndLastDateInWrty(Me.cboMonth.SelectedValue, Me.cboDay.SelectedValue, Me.cboYear.SelectedValue, dteRecDate)
                    Me._iManufWrty = R1("WarrantyStatus")
                    Me._strLastDateInWarranty = CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd")
                    Me._iManufCountryID = 0
                    Me._strInputCode = Me.txtDateCode.Text.Trim.ToUpper
                    Me._strDateCode = Me.cboMonth.SelectedValue & Me.cboDay.SelectedValue & Me.cboYear.SelectedValue
                    Me.booReturnFlg = True

                    ProcessWarrantyCode_Huawei = True
                    Return True
                End If

            Catch ex As Exception
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Huawei = False
                MessageBox.Show(ex.ToString, "ProcessWarrantyCode_Huawei()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessWarrantyCode_ZTE(Optional ByVal bAlphaMethod As Boolean = False) As Boolean
            Dim strDateCode As String
            Dim R1 As DataRow
            Dim iAltDateCode As Integer = 0

            Try
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_ZTE = False

                If _iModelID = 0 Then Throw New Exception("Model is missing.")

                iAltDateCode = Data.Buisness.WarrantyClaim.ZTE.GetAltWrtyDateCodeFlag(_iModelID)

                If Me.txtDateCode.Text.Trim.Length = 0 Then
                    Return False
                Else
                    If bAlphaMethod Then
                        R1 = PSS.Data.Buisness.WarrantyClaim.ZTE.GetWrtyStatusAndLastDateInWrty(iAltDateCode, Me.txtDateCode.Text.Trim.ToUpper, bAlphaMethod)
                    Else
                        R1 = PSS.Data.Buisness.WarrantyClaim.ZTE.GetWrtyStatusAndLastDateInWrty(iAltDateCode, Me.txtDateCode.Text.Trim.ToUpper)
                    End If

                    Me._iManufWrty = R1("WarrantyStatus")
                    Me._strLastDateInWarranty = CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd")
                    Me._iManufCountryID = 0
                    Me._strInputCode = Me.txtDateCode.Text.Trim.ToUpper
                    Me._strDateCode = R1("WarrantyDateCode")
                    Me.booReturnFlg = True

                    ProcessWarrantyCode_ZTE = True
                    Return True
                End If

            Catch ex As Exception
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_ZTE = False
                MessageBox.Show(ex.ToString, "ProcessWarrantyCode_ZTE()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessWarrantyCode_Alcatel() As Boolean
            Dim strDateCode As String
            Dim R1 As DataRow

            Try
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Alcatel = False

                If Me.txtDateCode.Text.Trim.Length = 0 Then
                    Return False
                Else
                    R1 = PSS.Data.Buisness.WarrantyClaim.Generic.Alcatel_GetWrtyStatusAndLastDateInWrty(Me.txtDateCode.Text.Trim.ToUpper)
                    Me._iManufWrty = R1("WarrantyStatus")
                    Me._strLastDateInWarranty = CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd")
                    Me._iManufCountryID = 0
                    'Me._strInputCode = Me.txtDateCode.Text.Trim.ToUpper
                    Me._strDateCode = Me.txtDateCode.Text.Trim.ToUpper
                    Me.booReturnFlg = True

                    ProcessWarrantyCode_Alcatel = True
                    Return True
                End If

            Catch ex As Exception
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Alcatel = False
                MessageBox.Show(ex.ToString, "ProcessWarrantyCode_Alcatel()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessWarrantyCode_Unimax() As Boolean
            Dim strDateCode As String
            Dim R1 As DataRow

            Try
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Unimax = False

                If Me.txtDateCode.Text.Trim.Length = 0 Then
                    Return False
                Else
                    R1 = PSS.Data.Buisness.WarrantyClaim.Generic.Unimax_GetWrtyStatusAndLastDateInWrty(Me.txtDateCode.Text.Trim.ToUpper)
                    Me._iManufWrty = R1("WarrantyStatus")
                    Me._strLastDateInWarranty = CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd")
                    Me._iManufCountryID = 0
                    'Me._strInputCode = Me.txtDateCode.Text.Trim.ToUpper
                    Me._strDateCode = Me.txtDateCode.Text.Trim.ToUpper
                    Me.booReturnFlg = True

                    ProcessWarrantyCode_Unimax = True
                    Return True
                End If

            Catch ex As Exception
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Unimax = False
                MessageBox.Show(ex.ToString, "ProcessWarrantyCode_Unimax()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '**************************************************************************

    End Class
End Namespace