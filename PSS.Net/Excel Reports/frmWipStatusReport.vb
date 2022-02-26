Imports PSS.Core.Global
Imports PSS.Data
Imports PSS.Data.Buisness
Imports System.Data
Imports System
Imports C1
Imports C1.Win.C1TrueDBGrid
Imports C1.Win.C1FlexGrid

Public Class frmWipStatusReport
    Inherits System.Windows.Forms.Form
    Private _iCustID As Integer = 0
    Private _iLoc_ID As Integer = 0
    Private _objWiKo As PSS.Data.Buisness.WIKO.WIKO
    Private _objWIKO_BoxShip As PSS.Data.Buisness.WIKO.WIKO_BoxShip
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        Me._objWiKo = New PSS.Data.Buisness.WIKO.WIKO()
        Me._objWIKO_BoxShip = New PSS.Data.Buisness.WIKO.WIKO_BoxShip()
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
    Friend WithEvents btnRunReport As System.Windows.Forms.Button
    Friend WithEvents grpDateRange As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnWipSummary As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnWipDetails As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWipStatusReport))
        Me.btnRunReport = New System.Windows.Forms.Button()
        Me.grpDateRange = New System.Windows.Forms.GroupBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.cboLocation = New C1.Win.C1List.C1Combo()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.rbtnWipSummary = New System.Windows.Forms.RadioButton()
        Me.rbtnWipDetails = New System.Windows.Forms.RadioButton()
        Me.grpDateRange.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRunReport
        '
        Me.btnRunReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRunReport.Location = New System.Drawing.Point(160, 160)
        Me.btnRunReport.Name = "btnRunReport"
        Me.btnRunReport.Size = New System.Drawing.Size(128, 32)
        Me.btnRunReport.TabIndex = 3
        Me.btnRunReport.Text = "Run Report"
        '
        'grpDateRange
        '
        Me.grpDateRange.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpEndDate, Me.dtpStartDate, Me.lblEndDate, Me.lblStartDate})
        Me.grpDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDateRange.Location = New System.Drawing.Point(72, 208)
        Me.grpDateRange.Name = "grpDateRange"
        Me.grpDateRange.Size = New System.Drawing.Size(320, 96)
        Me.grpDateRange.TabIndex = 2
        Me.grpDateRange.TabStop = False
        Me.grpDateRange.Text = "Date Range"
        Me.grpDateRange.Visible = False
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(88, 64)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(128, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(88, 24)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(128, 20)
        Me.dtpStartDate.TabIndex = 2
        '
        'lblEndDate
        '
        Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndDate.Location = New System.Drawing.Point(16, 64)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(64, 16)
        Me.lblEndDate.TabIndex = 1
        Me.lblEndDate.Text = "End Date:"
        '
        'lblStartDate
        '
        Me.lblStartDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartDate.Location = New System.Drawing.Point(16, 24)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(64, 16)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCustomers, Me.cboLocation, Me.Label1, Me.Label2})
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(72, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(320, 96)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Customer Details"
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
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(88, 24)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(216, 21)
        Me.cboCustomers.TabIndex = 167
        Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'cboLocation
        '
        Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
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
        Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboLocation.ItemHeight = 15
        Me.cboLocation.Location = New System.Drawing.Point(88, 64)
        Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
        Me.cboLocation.MaxDropDownItems = CType(5, Short)
        Me.cboLocation.MaxLength = 32767
        Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboLocation.Size = New System.Drawing.Size(216, 21)
        Me.cboLocation.TabIndex = 166
        Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Location"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnWipSummary, Me.rbtnWipDetails})
        Me.GroupBox3.Location = New System.Drawing.Point(80, 112)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(304, 88)
        Me.GroupBox3.TabIndex = 93
        Me.GroupBox3.TabStop = False
        '
        'rbtnWipSummary
        '
        Me.rbtnWipSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnWipSummary.ForeColor = System.Drawing.Color.White
        Me.rbtnWipSummary.Location = New System.Drawing.Point(176, 16)
        Me.rbtnWipSummary.Name = "rbtnWipSummary"
        Me.rbtnWipSummary.Size = New System.Drawing.Size(88, 24)
        Me.rbtnWipSummary.TabIndex = 2
        Me.rbtnWipSummary.Text = "Summary"
        '
        'rbtnWipDetails
        '
        Me.rbtnWipDetails.Checked = True
        Me.rbtnWipDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnWipDetails.ForeColor = System.Drawing.Color.White
        Me.rbtnWipDetails.Location = New System.Drawing.Point(48, 16)
        Me.rbtnWipDetails.Name = "rbtnWipDetails"
        Me.rbtnWipDetails.Size = New System.Drawing.Size(64, 24)
        Me.rbtnWipDetails.TabIndex = 1
        Me.rbtnWipDetails.TabStop = True
        Me.rbtnWipDetails.Text = "Details"
        '
        'frmWipStatusReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(496, 373)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnRunReport, Me.GroupBox3, Me.GroupBox1, Me.grpDateRange})
        Me.Name = "frmWipStatusReport"
        Me.Text = "frmWipStatusReport"
        Me.grpDateRange.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnRunReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunReport.Click

        Dim booDetails As Boolean = False

        Try
            Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

            If Me.rbtnWipDetails.Checked = True Then booDetails = True
            Me._iCustID = Me.cboCustomers.SelectedValue
            Me._iLoc_ID = Me.cboLocation.SelectedValue
            PSS.Data.Buisness.WIPStatusReport.LoadWIPSummary(booDetails, _iCustID, _iLoc_ID)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnWipRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try



    End Sub

    Private Sub frmWipStatusReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim strCustLoc As String = ""
            Dim dt As DataTable


            Me.cboCustomers.DataSource = Nothing
            dt = Generic.GetCustomers(True, , )
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")

            'Me.cboLocation.SelectedValue = 0

        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub cboCustomers_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomers.SelectedValueChanged
        Try
            Dim dtLoc As DataTable
            Me._iCustID = Me.cboCustomers.SelectedValue
            dtLoc = Me._objWIKO_BoxShip.GetWiKoLocations(Me._iCustID, True)
            Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
            Me.cboLocation.SelectedValue = 0
            'Me._iLoc_ID = Me.cboLocation.SelectedValue
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class
