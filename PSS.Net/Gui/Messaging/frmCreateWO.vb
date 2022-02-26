Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmCreateWO
    Inherits System.Windows.Forms.Form

    Private _objCRMA As CreateRMA

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objCRMA = New CreateRMA()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objCRMA = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnCreate As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbtnFileYes As System.Windows.Forms.RadioButton
    Friend WithEvents rdbtnFileNo As System.Windows.Forms.RadioButton
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents cboLocations As C1.Win.C1List.C1Combo
    Friend WithEvents txtRMA As System.Windows.Forms.TextBox
    Friend WithEvents cboPO As C1.Win.C1List.C1Combo
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCreateWO))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRMA = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rdbtnFileNo = New System.Windows.Forms.RadioButton()
        Me.rdbtnFileYes = New System.Windows.Forms.RadioButton()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.cboLocations = New C1.Win.C1List.C1Combo()
        Me.cboPO = New C1.Win.C1List.C1Combo()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Location:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRMA
        '
        Me.txtRMA.Location = New System.Drawing.Point(112, 112)
        Me.txtRMA.Name = "txtRMA"
        Me.txtRMA.Size = New System.Drawing.Size(280, 20)
        Me.txtRMA.TabIndex = 3
        Me.txtRMA.Text = ""
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "RMA/WO: "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCreate
        '
        Me.btnCreate.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.ForeColor = System.Drawing.Color.White
        Me.btnCreate.Location = New System.Drawing.Point(112, 232)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(280, 32)
        Me.btnCreate.TabIndex = 5
        Me.btnCreate.Text = "CREATE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdbtnFileNo, Me.rdbtnFileYes})
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(112, 144)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 56)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Came With Data File?"
        '
        'rdbtnFileNo
        '
        Me.rdbtnFileNo.Checked = True
        Me.rdbtnFileNo.Location = New System.Drawing.Point(168, 24)
        Me.rdbtnFileNo.Name = "rdbtnFileNo"
        Me.rdbtnFileNo.Size = New System.Drawing.Size(80, 16)
        Me.rdbtnFileNo.TabIndex = 1
        Me.rdbtnFileNo.TabStop = True
        Me.rdbtnFileNo.Text = "NO"
        '
        'rdbtnFileYes
        '
        Me.rdbtnFileYes.Location = New System.Drawing.Point(16, 24)
        Me.rdbtnFileYes.Name = "rdbtnFileYes"
        Me.rdbtnFileYes.Size = New System.Drawing.Size(80, 16)
        Me.rdbtnFileYes.TabIndex = 0
        Me.rdbtnFileYes.Text = "YES"
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
        Me.cboCustomers.Location = New System.Drawing.Point(112, 16)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(5, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(280, 21)
        Me.cboCustomers.TabIndex = 6
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
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
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
        Me.cboLocations.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
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
        Me.cboLocations.Size = New System.Drawing.Size(280, 21)
        Me.cboLocations.TabIndex = 7
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
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'cboPO
        '
        Me.cboPO.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboPO.Caption = ""
        Me.cboPO.CaptionHeight = 17
        Me.cboPO.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboPO.ColumnCaptionHeight = 17
        Me.cboPO.ColumnFooterHeight = 17
        Me.cboPO.ContentHeight = 15
        Me.cboPO.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboPO.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboPO.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPO.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboPO.EditorHeight = 15
        Me.cboPO.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.cboPO.ItemHeight = 15
        Me.cboPO.Location = New System.Drawing.Point(112, 80)
        Me.cboPO.MatchEntryTimeout = CType(2000, Long)
        Me.cboPO.MaxDropDownItems = CType(5, Short)
        Me.cboPO.MaxLength = 32767
        Me.cboPO.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboPO.Name = "cboPO"
        Me.cboPO.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboPO.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboPO.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboPO.Size = New System.Drawing.Size(280, 21)
        Me.cboPO.TabIndex = 2
        Me.cboPO.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        "aultRecSelWidth>16</DefaultRecSelWidth></Blob>"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "PO #:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Green
        Me.Label5.Location = New System.Drawing.Point(400, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "(Optional)"
        '
        'frmCreateWO
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(528, 317)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.cboPO, Me.Label4, Me.cboLocations, Me.cboCustomers, Me.GroupBox1, Me.btnCreate, Me.Label3, Me.txtRMA, Me.Label2, Me.Label1})
        Me.Name = "frmCreateWO"
        Me.Text = "frmCreateWO"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboLocations, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '********************************************************************
    Private Sub frmCreateWO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable

        Try
            dt = Generic.GetCustomers(True, )
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")

            Me.cboCustomers.SelectedValue = 1545

            Generic.DisposeDT(dt)
            dt = Generic.GetLocations(True, 1545)
            Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
            If dt.Rows.Count = 2 Then Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")

            If dt.Rows.Count = 2 Then
                dt = Generic.GetPOs(True, dt.Rows(0)("Loc_ID"))
                Misc.PopulateC1DropDownList(Me.cboPO, dt, "PO_Desc", "PO_ID")
                Me.cboPO.SelectedValue = 0
            End If
           
            Me.cboLocations.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    ''********************************************************************
    'Private Sub PopulateDropDownList(ByRef ctrlCbo As C1.Win.C1List.C1Combo, _
    '                                 ByVal dt As DataTable, _
    '                                 ByVal strDisplayCol As String, _
    '                                 ByVal strValCol As String)
    '    Dim i As Integer = 0
    '    Try
    '        With ctrlCbo
    '            .DataSource = Nothing
    '            .DataSource = dt.DefaultView

    '            .ValueMember = strValCol
    '            .DisplayMember = strDisplayCol
    '            .Text = ""
    '            .ColumnHeaders = False
    '            .AutoCompletion = True
    '            .AutoDropDown = True
    '            .AutoSelect = True
    '            .AllowDrop = True

    '            For i = 0 To dt.Columns.Count - 1
    '                If dt.Columns(i).Caption.Trim.ToUpper = strDisplayCol.Trim.ToUpper Then
    '                    .Splits(0).DisplayColumns(i).Visible = True
    '                Else
    '                    .Splits(0).DisplayColumns(i).Visible = False
    '                End If
    '            Next i

    '            .Splits(0).DisplayColumns(strDisplayCol).Width = .Width - 5

    '        End With
    '    Catch ex As Exception
    '        Throw ex
    '    Finally
    '        If Not IsNothing(dt) Then
    '            dt.Dispose()
    '            dt = Nothing
    '        End If
    '    End Try
    'End Sub

    '********************************************************************
    Private Sub cboCustomers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCustomers.KeyUp
        Dim dt As DataTable
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.cboCustomers.SelectedValue > 0 Then
                    Me.cboLocations.DataSource = Nothing

                    Me.txtRMA.Text = ""
                    dt = Generic.GetLocations(True, Me.cboCustomers.SelectedValue)

                    Misc.PopulateC1DropDownList(Me.cboLocations, dt, "Loc_Name", "Loc_ID")
                    If dt.Rows.Count = 2 Then Me.cboLocations.SelectedValue = dt.Rows(0)("Loc_ID")

                    Me.txtRMA.Focus()
                End If
            Else
                Me.cboLocations.DataSource = Nothing
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboCustomers_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If
        End Try
    End Sub

    '********************************************************************
    Private Sub txtRMA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRMA.KeyPress
        Try
            If e.KeyChar.IsLetterOrDigit(e.KeyChar) = False And e.KeyChar.IsControl(e.KeyChar) = False Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtRMA_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************
    Private Sub txtRMA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRMA.KeyDown
        Try
            If Me.txtRMA.Text.Trim = "" Then Exit Sub

            If e.KeyCode = Keys.Enter Then ProcessRMA()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtRMA_KeyDown", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '********************************************************************
    Private Sub ProcessRMA()
        Const iGroupID As Integer = 83
        Const iProdID As Integer = 1
        Dim dt As DataTable
        Dim iHasFile As Integer = 0
        Dim iPO As Integer = 0
        Dim i As Integer = 0
        Try
            If Me.txtRMA.Text.Trim = "" Then
                MessageBox.Show("Please enter RMA/WO.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.txtRMA.Focus()
                Exit Sub
            ElseIf Me.cboCustomers.SelectedValue = 0 OrElse IsNothing(Me.cboLocations.DataSource) OrElse Me.cboLocations.SelectedValue = Nothing Then
                MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboCustomers.Focus()
            ElseIf Me.cboLocations.SelectedValue = 0 Then
                MessageBox.Show("Please select location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Me.cboLocations.Focus()
            Else
                dt = Me._objCRMA.GetRMA(Me.txtRMA.Text.Trim, Me.cboLocations.SelectedValue)
                If dt.Rows.Count > 0 Then
                    MessageBox.Show("RMS/WO is already listed in the system for the selected location.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtRMA.SelectAll()
                    Me.txtRMA.Focus()
                Else
                    If Not IsNothing(Me.cboPO.SelectedValue) Then iPO = Me.cboPO.SelectedValue

                    If MessageBox.Show("Are you sure you want to create new RMA/WO?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = Me._objCRMA.CreateNewRMA(Me.cboLocations.SelectedValue, Me.txtRMA.Text.Trim.ToUpper, iPO, iHasFile, iProdID, iGroupID, PSS.Core.Global.ApplicationUser.User, PSS.Core.Global.ApplicationUser.IDuser)

                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Enabled = True
                    Cursor.Current = Cursors.Default
                    Me.txtRMA.Text = ""
                    Me.txtRMA.Focus()
                End If
            End If
        Catch ex As Exception
            Throw ex
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Generic.DisposeDT(dt)
            Me.txtRMA.Focus()
        End Try
    End Sub

    '********************************************************************
    Private Sub cboLocations_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLocations.KeyUp
        Dim dt As DataTable
        Try
            If e.KeyCode = Keys.Enter Then
                If Me.cboLocations.SelectedValue > 0 Then
                    dt = Generic.GetPOs(True, dt.Rows(0)("Loc_ID"))
                    Misc.PopulateC1DropDownList(Me.cboPO, dt, "PO_Desc", "PO_ID")
                    Me.cboPO.SelectedValue = 0
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "cboLocations_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '********************************************************************
    Private Sub cboPO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboPO.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.txtRMA.SelectAll()
            Me.txtRMA.Focus()
        End If
    End Sub

    '********************************************************************
    Private Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Try
            ProcessRMA()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnCreate_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.txtRMA.Focus()
        End Try
    End Sub

    '********************************************************************

End Class
