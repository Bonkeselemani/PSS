Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.ReportViewer
    Public Class frmGenRptCriteria
        Inherits System.Windows.Forms.Form

        Public Enum InputValType As Integer
            Invisible = 0
            VisibleRequired = 1
            VisibleOptional = 2
        End Enum

        Private _strRptName As String = ""

#Region " Windows Form Designer generated code "

        Public Sub New(Optional ByVal strRptName As String = "", _
                       Optional ByVal iSelectDate As InputValType = InputValType.Invisible, _
                       Optional ByVal iSelectCustomer As InputValType = InputValType.Invisible, _
                       Optional ByVal iEnterComputerName As InputValType = InputValType.Invisible, _
                       Optional ByVal iSelectMonth As InputValType = InputValType.Invisible, _
                       Optional ByVal iEnterReceivingWO As InputValType = InputValType.Invisible)
            'Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            If strRptName.Trim.Length > 0 Then
                Me._strRptName = strRptName
                Me.btnRunRpt.Text = Me._strRptName
                Me.gbReportName.Visible = False
            End If

            Me.gbDate.Tag = iSelectDate
            Me.gbCustomer.Tag = iSelectCustomer
            Me.gbComputers.Tag = iEnterComputerName
            Me.gbMonth.Tag = iSelectMonth
            Me.gbInboundWO.Tag = iEnterReceivingWO

            If iSelectDate > 0 Then Me.gbDate.Visible = True Else Me.gbDate.Visible = False
            If iSelectCustomer > 0 Then Me.gbCustomer.Visible = True Else Me.gbCustomer.Visible = False
            If iEnterComputerName > 0 Then Me.gbComputers.Visible = True Else Me.gbComputers.Visible = False
            If iSelectMonth > 0 Then Me.gbMonth.Visible = True Else Me.gbMonth.Visible = False
            If iEnterReceivingWO > 0 Then Me.gbInboundWO.Visible = True Else Me.gbInboundWO.Visible = False
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
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents gbDate As System.Windows.Forms.GroupBox
        Friend WithEvents gbCustomer As System.Windows.Forms.GroupBox
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
        Friend WithEvents btnRunRpt As System.Windows.Forms.Button
        Friend WithEvents gbComputers As System.Windows.Forms.GroupBox
        Friend WithEvents txtComputerName As System.Windows.Forms.TextBox
        Friend WithEvents gbMonth As System.Windows.Forms.GroupBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents cboEndYear As C1.Win.C1List.C1Combo
        Friend WithEvents cboEndMonth As C1.Win.C1List.C1Combo
        Friend WithEvents cboStartYear As C1.Win.C1List.C1Combo
        Friend WithEvents cboStartMonth As C1.Win.C1List.C1Combo
        Friend WithEvents gbInboundWO As System.Windows.Forms.GroupBox
        Friend WithEvents txtReceivingWO As System.Windows.Forms.TextBox
        Friend WithEvents gbReportName As System.Windows.Forms.GroupBox
        Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmGenRptCriteria))
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.gbDate = New System.Windows.Forms.GroupBox()
            Me.gbCustomer = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboLocations = New C1.Win.C1List.C1Combo()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.btnRunRpt = New System.Windows.Forms.Button()
            Me.gbComputers = New System.Windows.Forms.GroupBox()
            Me.txtComputerName = New System.Windows.Forms.TextBox()
            Me.gbMonth = New System.Windows.Forms.GroupBox()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.cboEndYear = New C1.Win.C1List.C1Combo()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.cboEndMonth = New C1.Win.C1List.C1Combo()
            Me.cboStartYear = New C1.Win.C1List.C1Combo()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboStartMonth = New C1.Win.C1List.C1Combo()
            Me.gbInboundWO = New System.Windows.Forms.GroupBox()
            Me.txtReceivingWO = New System.Windows.Forms.TextBox()
            Me.gbReportName = New System.Windows.Forms.GroupBox()
            Me.cboReportName = New System.Windows.Forms.ComboBox()
            Me.gbDate.SuspendLayout()
            Me.gbCustomer.SuspendLayout()
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbComputers.SuspendLayout()
            Me.gbMonth.SuspendLayout()
            CType(Me.cboEndYear, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboEndMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboStartYear, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboStartMonth, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbInboundWO.SuspendLayout()
            Me.gbReportName.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStartDate.ForeColor = System.Drawing.Color.Green
            Me.lblStartDate.Location = New System.Drawing.Point(24, 16)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(80, 16)
            Me.lblStartDate.TabIndex = 103
            Me.lblStartDate.Text = "Start:"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate.Location = New System.Drawing.Point(112, 16)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpStartDate.TabIndex = 0
            Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndDate.ForeColor = System.Drawing.Color.Green
            Me.lblEndDate.Location = New System.Drawing.Point(24, 48)
            Me.lblEndDate.Name = "lblEndDate"
            Me.lblEndDate.Size = New System.Drawing.Size(80, 16)
            Me.lblEndDate.TabIndex = 105
            Me.lblEndDate.Text = "End:"
            Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpEndDate
            '
            Me.dtpEndDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpEndDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpEndDate.Location = New System.Drawing.Point(112, 48)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpEndDate.TabIndex = 1
            Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'gbDate
            '
            Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.lblStartDate})
            Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDate.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbDate.Location = New System.Drawing.Point(16, 64)
            Me.gbDate.Name = "gbDate"
            Me.gbDate.Size = New System.Drawing.Size(400, 80)
            Me.gbDate.TabIndex = 0
            Me.gbDate.TabStop = False
            Me.gbDate.Text = "DATE"
            '
            'gbCustomer
            '
            Me.gbCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.cboLocations, Me.Label1, Me.cboCustomers})
            Me.gbCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCustomer.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbCustomer.Location = New System.Drawing.Point(16, 152)
            Me.gbCustomer.Name = "gbCustomer"
            Me.gbCustomer.Size = New System.Drawing.Size(400, 80)
            Me.gbCustomer.TabIndex = 1
            Me.gbCustomer.TabStop = False
            Me.gbCustomer.Text = "CUSTOMER"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Green
            Me.Label2.Location = New System.Drawing.Point(24, 48)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(80, 16)
            Me.Label2.TabIndex = 107
            Me.Label2.Text = "Location:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocations
            '
            Me.cboLocations.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocations.Caption = ""
            Me.cboLocations.CaptionHeight = 17
            Me.cboLocations.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocations.ColumnCaptionHeight = 17
            Me.cboLocations.ColumnFooterHeight = 17
            Me.cboLocations.ContentHeight = 15
            Me.cboLocations.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocations.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocations.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocations.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocations.EditorHeight = 15
            Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.cboLocations.ItemHeight = 15
            Me.cboLocations.Location = New System.Drawing.Point(112, 48)
            Me.cboLocations.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocations.MaxDropDownItems = CType(5, Short)
            Me.cboLocations.MaxLength = 32767
            Me.cboLocations.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocations.Name = "cboLocations"
            Me.cboLocations.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocations.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocations.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocations.Size = New System.Drawing.Size(272, 21)
            Me.cboLocations.TabIndex = 1
            Me.cboLocations.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Green
            Me.Label1.Location = New System.Drawing.Point(24, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 105
            Me.Label1.Text = "Name:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboCustomers.ItemHeight = 15
            Me.cboCustomers.Location = New System.Drawing.Point(112, 16)
            Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
            Me.cboCustomers.MaxDropDownItems = CType(5, Short)
            Me.cboCustomers.MaxLength = 32767
            Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboCustomers.Name = "cboCustomers"
            Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboCustomers.Size = New System.Drawing.Size(272, 21)
            Me.cboCustomers.TabIndex = 0
            Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'btnRunRpt
            '
            Me.btnRunRpt.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRunRpt.ForeColor = System.Drawing.Color.White
            Me.btnRunRpt.Location = New System.Drawing.Point(16, 312)
            Me.btnRunRpt.Name = "btnRunRpt"
            Me.btnRunRpt.Size = New System.Drawing.Size(400, 32)
            Me.btnRunRpt.TabIndex = 2
            '
            'gbComputers
            '
            Me.gbComputers.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtComputerName})
            Me.gbComputers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbComputers.Location = New System.Drawing.Point(432, 120)
            Me.gbComputers.Name = "gbComputers"
            Me.gbComputers.Size = New System.Drawing.Size(240, 64)
            Me.gbComputers.TabIndex = 2
            Me.gbComputers.TabStop = False
            Me.gbComputers.Text = "COMPUTER NAME"
            '
            'txtComputerName
            '
            Me.txtComputerName.Location = New System.Drawing.Point(8, 32)
            Me.txtComputerName.Name = "txtComputerName"
            Me.txtComputerName.Size = New System.Drawing.Size(216, 20)
            Me.txtComputerName.TabIndex = 1
            Me.txtComputerName.Text = ""
            '
            'gbMonth
            '
            Me.gbMonth.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8, Me.Label7, Me.cboEndYear, Me.Label6, Me.cboEndMonth, Me.cboStartYear, Me.Label3, Me.cboStartMonth})
            Me.gbMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbMonth.Location = New System.Drawing.Point(432, 8)
            Me.gbMonth.Name = "gbMonth"
            Me.gbMonth.Size = New System.Drawing.Size(240, 104)
            Me.gbMonth.TabIndex = 3
            Me.gbMonth.TabStop = False
            Me.gbMonth.Text = "MONTH RANGE"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Green
            Me.Label8.Location = New System.Drawing.Point(136, 24)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(80, 16)
            Me.Label8.TabIndex = 112
            Me.Label8.Text = "Year"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Green
            Me.Label7.Location = New System.Drawing.Point(64, 24)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(48, 16)
            Me.Label7.TabIndex = 111
            Me.Label7.Text = "Month"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
            '
            'cboEndYear
            '
            Me.cboEndYear.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboEndYear.Caption = ""
            Me.cboEndYear.CaptionHeight = 17
            Me.cboEndYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboEndYear.ColumnCaptionHeight = 17
            Me.cboEndYear.ColumnFooterHeight = 17
            Me.cboEndYear.ContentHeight = 15
            Me.cboEndYear.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboEndYear.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboEndYear.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEndYear.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboEndYear.EditorHeight = 15
            Me.cboEndYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEndYear.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboEndYear.ItemHeight = 15
            Me.cboEndYear.Location = New System.Drawing.Point(136, 72)
            Me.cboEndYear.MatchEntryTimeout = CType(2000, Long)
            Me.cboEndYear.MaxDropDownItems = CType(5, Short)
            Me.cboEndYear.MaxLength = 32767
            Me.cboEndYear.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboEndYear.Name = "cboEndYear"
            Me.cboEndYear.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboEndYear.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboEndYear.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboEndYear.Size = New System.Drawing.Size(80, 21)
            Me.cboEndYear.TabIndex = 4
            Me.cboEndYear.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Green
            Me.Label6.Location = New System.Drawing.Point(8, 72)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(40, 16)
            Me.Label6.TabIndex = 108
            Me.Label6.Text = "End:"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboEndMonth
            '
            Me.cboEndMonth.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboEndMonth.Caption = ""
            Me.cboEndMonth.CaptionHeight = 17
            Me.cboEndMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboEndMonth.ColumnCaptionHeight = 17
            Me.cboEndMonth.ColumnFooterHeight = 17
            Me.cboEndMonth.ContentHeight = 15
            Me.cboEndMonth.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboEndMonth.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboEndMonth.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEndMonth.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboEndMonth.EditorHeight = 15
            Me.cboEndMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboEndMonth.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboEndMonth.ItemHeight = 15
            Me.cboEndMonth.Location = New System.Drawing.Point(56, 72)
            Me.cboEndMonth.MatchEntryTimeout = CType(2000, Long)
            Me.cboEndMonth.MaxDropDownItems = CType(5, Short)
            Me.cboEndMonth.MaxLength = 32767
            Me.cboEndMonth.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboEndMonth.Name = "cboEndMonth"
            Me.cboEndMonth.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboEndMonth.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboEndMonth.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboEndMonth.Size = New System.Drawing.Size(64, 21)
            Me.cboEndMonth.TabIndex = 3
            Me.cboEndMonth.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'cboStartYear
            '
            Me.cboStartYear.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboStartYear.Caption = ""
            Me.cboStartYear.CaptionHeight = 17
            Me.cboStartYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboStartYear.ColumnCaptionHeight = 17
            Me.cboStartYear.ColumnFooterHeight = 17
            Me.cboStartYear.ContentHeight = 15
            Me.cboStartYear.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboStartYear.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboStartYear.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStartYear.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboStartYear.EditorHeight = 15
            Me.cboStartYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStartYear.Images.Add(CType(resources.GetObject("resource.Images4"), System.Drawing.Bitmap))
            Me.cboStartYear.ItemHeight = 15
            Me.cboStartYear.Location = New System.Drawing.Point(136, 40)
            Me.cboStartYear.MatchEntryTimeout = CType(2000, Long)
            Me.cboStartYear.MaxDropDownItems = CType(5, Short)
            Me.cboStartYear.MaxLength = 32767
            Me.cboStartYear.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboStartYear.Name = "cboStartYear"
            Me.cboStartYear.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboStartYear.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboStartYear.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboStartYear.Size = New System.Drawing.Size(80, 21)
            Me.cboStartYear.TabIndex = 2
            Me.cboStartYear.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Green
            Me.Label3.Location = New System.Drawing.Point(8, 40)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(40, 16)
            Me.Label3.TabIndex = 104
            Me.Label3.Text = "Start:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboStartMonth
            '
            Me.cboStartMonth.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboStartMonth.Caption = ""
            Me.cboStartMonth.CaptionHeight = 17
            Me.cboStartMonth.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboStartMonth.ColumnCaptionHeight = 17
            Me.cboStartMonth.ColumnFooterHeight = 17
            Me.cboStartMonth.ContentHeight = 15
            Me.cboStartMonth.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboStartMonth.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboStartMonth.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStartMonth.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboStartMonth.EditorHeight = 15
            Me.cboStartMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStartMonth.Images.Add(CType(resources.GetObject("resource.Images5"), System.Drawing.Bitmap))
            Me.cboStartMonth.ItemHeight = 15
            Me.cboStartMonth.Location = New System.Drawing.Point(56, 40)
            Me.cboStartMonth.MatchEntryTimeout = CType(2000, Long)
            Me.cboStartMonth.MaxDropDownItems = CType(5, Short)
            Me.cboStartMonth.MaxLength = 32767
            Me.cboStartMonth.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboStartMonth.Name = "cboStartMonth"
            Me.cboStartMonth.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboStartMonth.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboStartMonth.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboStartMonth.Size = New System.Drawing.Size(64, 21)
            Me.cboStartMonth.TabIndex = 1
            Me.cboStartMonth.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
            'gbInboundWO
            '
            Me.gbInboundWO.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtReceivingWO})
            Me.gbInboundWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbInboundWO.Location = New System.Drawing.Point(16, 248)
            Me.gbInboundWO.Name = "gbInboundWO"
            Me.gbInboundWO.Size = New System.Drawing.Size(400, 48)
            Me.gbInboundWO.TabIndex = 4
            Me.gbInboundWO.TabStop = False
            Me.gbInboundWO.Text = "WORK ORDER NAME:"
            '
            'txtReceivingWO
            '
            Me.txtReceivingWO.Location = New System.Drawing.Point(112, 16)
            Me.txtReceivingWO.Name = "txtReceivingWO"
            Me.txtReceivingWO.Size = New System.Drawing.Size(272, 20)
            Me.txtReceivingWO.TabIndex = 1
            Me.txtReceivingWO.Text = ""
            '
            'gbReportName
            '
            Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReportName})
            Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.gbReportName.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.gbReportName.Location = New System.Drawing.Point(16, 8)
            Me.gbReportName.Name = "gbReportName"
            Me.gbReportName.Size = New System.Drawing.Size(400, 48)
            Me.gbReportName.TabIndex = 5
            Me.gbReportName.TabStop = False
            Me.gbReportName.Text = "REPORT NAME"
            '
            'cboReportName
            '
            Me.cboReportName.ItemHeight = 13
            Me.cboReportName.Location = New System.Drawing.Point(112, 16)
            Me.cboReportName.MaxDropDownItems = 25
            Me.cboReportName.Name = "cboReportName"
            Me.cboReportName.Size = New System.Drawing.Size(272, 21)
            Me.cboReportName.TabIndex = 6
            '
            'frmGenRptCriteria
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(712, 398)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbReportName, Me.gbInboundWO, Me.gbMonth, Me.gbComputers, Me.btnRunRpt, Me.gbCustomer, Me.gbDate})
            Me.ForeColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(0, Byte), CType(64, Byte))
            Me.Name = "frmGenRptCriteria"
            Me.Text = "frmGenRptCriteria"
            Me.gbDate.ResumeLayout(False)
            Me.gbCustomer.ResumeLayout(False)
            CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbComputers.ResumeLayout(False)
            Me.gbMonth.ResumeLayout(False)
            CType(Me.cboEndYear, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboEndMonth, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboStartYear, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboStartMonth, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbInboundWO.ResumeLayout(False)
            Me.gbReportName.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmGenRptCriteria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable
            Try
                If Me._strRptName.Trim.Length = 0 Then
                    ' *************Load Report Name ***************************
                    Me.cboReportName.Items.Clear()
                    Me.cboReportName.Items.Add("Select Report Name")
                    Me.cboReportName.Items.Add("Average Parts Cost")
                    Me.cboReportName.Items.Add("Average Invoice Price")
                    Me.cboReportName.Items.Add("DriveCam Shipping Devices")
                    Me.cboReportName.Items.Add("Invoice Summary Monthly")
                    Me.cboReportName.Items.Add("Scrap Report")
                    Me.cboReportName.Items.Add("RV Saving Report")
                    Me.cboReportName.Items.Add("Receiving Report")
                    Me.cboReportName.Items.Add("Triage Fail Other")

                    Me.cboReportName.Text = "Select Report Name"

                    Me.gbDate.Visible = False
                    Me.gbCustomer.Visible = False
                    Me.gbComputers.Visible = False
                    Me.gbMonth.Visible = False
                    Me.gbInboundWO.Visible = False
                    Me.btnRunRpt.Visible = False
                End If
                '***********************************************************

                dt = Generic.GetCustomers(True, )
                Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                Me.cboCustomers.SelectedValue = 0

                Me.dtpStartDate.Value = Now()
                Me.dtpEndDate.Value = Now()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub cboReportName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.TextChanged
            Dim dt As DataTable

            Me._strRptName = ""
            Me.gbDate.Visible = False
            Me.gbCustomer.Visible = False
            Me.gbComputers.Visible = False
            Me.gbMonth.Visible = False
            Me.gbInboundWO.Visible = False
            Me.btnRunRpt.Visible = False

            Try
                If Me.cboReportName.Text <> "Select Report Name" Then
                    Me._strRptName = Me.cboReportName.Text

                    If Me._strRptName = "Average Parts Cost" Then
                        Me.gbDate.Visible = True
                        Me.gbCustomer.Visible = True
                    ElseIf Me._strRptName = "Average Invoice Price" Then
                        Me.gbDate.Visible = True
                        Me.gbCustomer.Visible = True
                    ElseIf Me._strRptName = "DriveCam Shipping Devices" Then
                        Me.gbDate.Visible = True
                    ElseIf Me._strRptName = "Invoice Summary Monthly" Then
                        Me.gbCustomer.Visible = True
                        Me.gbMonth.Visible = True
                    ElseIf Me._strRptName = "Scrap Report" Then
                        Me.gbDate.Visible = True
                        Me.gbCustomer.Visible = True
                        Me.gbComputers.Visible = True
                    ElseIf Me._strRptName = "RV Saving Report" Then
                        Me.gbDate.Visible = True
                        Me.gbCustomer.Visible = True
                    ElseIf Me._strRptName = "Receiving Report" Then
                        'Me.gbDate.Visible = True
                        Me.gbCustomer.Visible = True
                        Me.gbInboundWO.Visible = True
                    ElseIf Me._strRptName = "Triage Fail Other" Then
                        Me.gbDate.Visible = True
                    End If

                    Me.btnRunRpt.Text = "Get """ & _strRptName & """"
                    Me.btnRunRpt.Visible = True

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub cboCustomers_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.Enter
            Me.cboLocations.DataSource = Nothing
            Me.cboLocations.Text = ""
        End Sub

        '******************************************************************
        Private Sub cboCustomers_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.Leave
            Dim dt As DataTable
            Try
                If Me.cboCustomers.SelectedValue > 0 Then
                    dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                    Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                    If dt.Rows.Count = 2 Then Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
            Dim dt As DataTable
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.cboCustomers.SelectedValue > 0 Then
                        dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)
                        Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                        If dt.Rows.Count = 2 Then Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")
                        Me.cboLocations.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboCustomers_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnRunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunRpt.Click
            Dim objExcelRpt As PSS.Data.ExcelReports
            Dim strDateStart, strDateEnd As String
            Dim iCustID As Integer = 0

            Try
                '*************************************
                'Validate user input
                '*************************************
                'If Me._iDateRange > 0 AndAlso DateDiff(DateInterval.Day, Me.dtpStartDate.Value, Me.dtpEndDate.Value) < 0 Then
                '    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'ElseIf Me._iCustomer = InputValType.VisibleRequired AndAlso Me.cboCustomers.SelectedValue = 0 Then
                '    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'ElseIf Me._iComputerName = InputValType.VisibleRequired AndAlso Me.txtComputerName.Text.Trim.Length = 0 Then
                '    MessageBox.Show("Please enter computer name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'ElseIf Me._iMonthRange = InputValType.VisibleRequired AndAlso (Me.cboStartMonth.SelectedValue = 0 OrElse Me.cboStartYear.SelectedValue = 0 OrElse Me.cboEndMonth.SelectedText = 0 OrElse Me.cboEndYear.SelectedValue = 0) Then
                '    MessageBox.Show("Please select month range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                'ElseIf Me._iReceivingWO = InputValType.VisibleRequired AndAlso (Me.txtReceivingWO.Text.Trim.Length = 0) Then
                '    MessageBox.Show("Please enter Receiving workorder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)


                If Me.gbDate.Visible = True AndAlso DateDiff(DateInterval.Day, Me.dtpStartDate.Value, Me.dtpEndDate.Value) < 0 Then
                    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.gbCustomer.Visible = True AndAlso Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.gbComputers.Visible = True AndAlso Me.txtComputerName.Text.Trim.Length = 0 Then
                    MessageBox.Show("Please enter computer name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.gbMonth.Visible = True AndAlso (Me.cboStartMonth.SelectedValue = 0 OrElse Me.cboStartYear.SelectedValue = 0 OrElse Me.cboEndMonth.SelectedText = 0 OrElse Me.cboEndYear.SelectedValue = 0) Then
                    MessageBox.Show("Please select month range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.gbInboundWO.Visible = True AndAlso (Me.txtReceivingWO.Text.Trim.Length = 0) Then
                    MessageBox.Show("Please enter Receiving workorder.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    '*************************************
                    'Define user input
                    '*************************************
                    strDateStart = "" : strDateEnd = ""

                    'If Me._iDateRange = InputValType.VisibleRequired Then
                    '    strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                    '    strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                    'End If
                    'If Me._iCustomer > InputValType.Invisible Then iCustID = Me.cboCustomers.SelectedValue

                    If Me.gbDate.Visible = True Then
                        strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                        strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                    End If
                    If Me.gbCustomer.Visible = True Then iCustID = Me.cboCustomers.SelectedValue

                    '*************************************
                    'Generate Report
                    '*************************************

                    If Me._strRptName = "Average Parts Cost" Then
                        Me.RunAPCRpt()
                    ElseIf Me._strRptName = "Average Invoice Price" Then
                        objExcelRpt = New PSS.Data.ExcelReports(True)
                        objExcelRpt.RunAverageInvoiceAmt(strDateStart, strDateEnd, iCustID)
                        objExcelRpt = Nothing
                    ElseIf Me._strRptName = "DriveCam Shipping Devices" Then
                        objExcelRpt = New PSS.Data.ExcelReports(True)
                        objExcelRpt.RunDriveCamDockShipDevices(strDateStart, strDateEnd)
                        objExcelRpt = Nothing
                    ElseIf Me._strRptName = "Invoice Monthly Summary" Then
                        objExcelRpt = New PSS.Data.ExcelReports(True)
                        objExcelRpt.MessagingMonthlyInvoiceSummaryRpt(Me.cboStartMonth.SelectedValue, Me.cboStartYear.SelectedValue, Me.cboEndMonth.SelectedValue, Me.cboEndYear.SelectedValue, iCustID)
                        objExcelRpt = Nothing
                    ElseIf Me._strRptName = "Scrap Report" Then
                        objExcelRpt = New PSS.Data.ExcelReports(True)
                        objExcelRpt.RunExcelReport(Me._strRptName, strDateStart, strDateEnd, iCustID, Me.cboLocations.SelectedValue, Me.txtComputerName.Text.Trim)
                        objExcelRpt = Nothing
                    ElseIf Me._strRptName = "RV Saving Report" Then
                        objExcelRpt = New PSS.Data.ExcelReports(True)
                        objExcelRpt.RVSavingReport(strDateStart, strDateEnd, iCustID)
                        objExcelRpt = Nothing
                    ElseIf Me._strRptName = "Receiving Report" Then
                        objExcelRpt = New PSS.Data.ExcelReports(True)
                        objExcelRpt.RunReceivingReport(Me._strRptName, Me.txtReceivingWO.Text, Me.cboLocations.SelectedValue)
                        objExcelRpt = Nothing
                    ElseIf Me._strRptName = "Triage Fail Other" Then
                        objExcelRpt = New PSS.Data.ExcelReports(True)
                        objExcelRpt.RunTriageFailOtherReport(Me._strRptName, strDateStart, strDateEnd)
                        objExcelRpt = Nothing
                    ElseIf Me._strRptName = "Cogs Reports" Then
                        objExcelRpt = New PSS.Data.ExcelReports(True)
                        objExcelRpt.RunCogsReport(strDateStart, strDateEnd)
                        objExcelRpt = Nothing
                    End If
                    '*************************************
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                objExcelRpt = Nothing
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************
        Private Sub RunAPCRpt()
            Dim objRptData As RptData
            Dim objXLReports As Data.ExcelReports
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim dblTotalPC As Decimal = 0.0

            Try
                If Me.cboCustomers.SelectedValue = 0 Or IsNothing(Me.cboLocations.DataSource) Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboCustomers.Focus()
                ElseIf Me.cboLocations.SelectedValue = 0 Then
                    MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLocations.Focus()
                Else
                    objRptData = New RptData()
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    dt = objRptData.GetAPCData(Format(Me.dtpStartDate.Value, "yyyy-MM-dd"), Format(Me.dtpEndDate.Value, "yyyy-MM-dd"), Me.cboCustomers.SelectedValue, Me.cboLocations.SelectedValue, dblTotalPC)

                    If dt.Rows.Count > 0 Then
                        objXLReports = New Data.ExcelReports()

                        objXLReports.RunAPCReport(dt, dblTotalPC)
                    Else
                        MsgBox("No data found.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    End If
                End If

            Catch ex As Exception
                Throw ex
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                objRptData = Nothing
                objXLReports = Nothing
                Generic.DisposeDT(dt)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Sub

        '******************************************************************




    End Class
End Namespace