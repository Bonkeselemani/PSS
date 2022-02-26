Public Class frmCompare_Consumed_AutoBilled_Revenue
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdLevel_2_3 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmd563RevRep As System.Windows.Forms.Button
    Friend WithEvents btn563NoSlvg As System.Windows.Forms.Button
    Friend WithEvents btn563SlvgOnly As System.Windows.Forms.Button
    Friend WithEvents btn563PreBillInWIP As System.Windows.Forms.Button
    Friend WithEvents btnRevenueReprt_SpecialBilling As System.Windows.Forms.Button
    Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
    Friend WithEvents cboModels As C1.Win.C1List.C1Combo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCompare_Consumed_AutoBilled_Revenue))
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn563SlvgOnly = New System.Windows.Forms.Button()
        Me.btn563NoSlvg = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdLevel_2_3 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmd563RevRep = New System.Windows.Forms.Button()
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn563PreBillInWIP = New System.Windows.Forms.Button()
        Me.btnRevenueReprt_SpecialBilling = New System.Windows.Forms.Button()
        Me.cboCustomers = New C1.Win.C1List.C1Combo()
        Me.cboModels = New C1.Win.C1List.C1Combo()
        Me.Panel3.SuspendLayout()
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModels, Me.btnRevenueReprt_SpecialBilling, Me.btn563SlvgOnly, Me.btn563NoSlvg, Me.Label6, Me.cmdLevel_2_3, Me.Label2, Me.Label5, Me.cmd563RevRep, Me.dtpToDate, Me.dtpFromDate, Me.Label4, Me.Label1, Me.Label3, Me.cboCustomers})
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(504, 432)
        Me.Panel3.TabIndex = 68
        '
        'btn563SlvgOnly
        '
        Me.btn563SlvgOnly.BackColor = System.Drawing.Color.Gold
        Me.btn563SlvgOnly.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn563SlvgOnly.ForeColor = System.Drawing.Color.Black
        Me.btn563SlvgOnly.Location = New System.Drawing.Point(163, 328)
        Me.btn563SlvgOnly.Name = "btn563SlvgOnly"
        Me.btn563SlvgOnly.Size = New System.Drawing.Size(276, 31)
        Me.btn563SlvgOnly.TabIndex = 7
        Me.btn563SlvgOnly.Text = "563 Revenue Report (Salvage Only)"
        '
        'btn563NoSlvg
        '
        Me.btn563NoSlvg.BackColor = System.Drawing.Color.SteelBlue
        Me.btn563NoSlvg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn563NoSlvg.ForeColor = System.Drawing.Color.White
        Me.btn563NoSlvg.Location = New System.Drawing.Point(163, 280)
        Me.btn563NoSlvg.Name = "btn563NoSlvg"
        Me.btn563NoSlvg.Size = New System.Drawing.Size(276, 31)
        Me.btn563NoSlvg.TabIndex = 6
        Me.btn563NoSlvg.Text = "563 Revenue Report (Exclude Salvage)"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(416, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 69
        Me.Label6.Text = "(Optional)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdLevel_2_3
        '
        Me.cmdLevel_2_3.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdLevel_2_3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLevel_2_3.ForeColor = System.Drawing.Color.White
        Me.cmdLevel_2_3.Location = New System.Drawing.Point(164, 232)
        Me.cmdLevel_2_3.Name = "cmdLevel_2_3"
        Me.cmdLevel_2_3.Size = New System.Drawing.Size(276, 31)
        Me.cmdLevel_2_3.TabIndex = 5
        Me.cmdLevel_2_3.Text = "563 Revenue Report (Labor Level > 1)"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(-1, -1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(505, 33)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "563 REVENUE"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(4, 136)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 16)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "To Ship Work Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmd563RevRep
        '
        Me.cmd563RevRep.BackColor = System.Drawing.Color.SteelBlue
        Me.cmd563RevRep.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmd563RevRep.ForeColor = System.Drawing.Color.White
        Me.cmd563RevRep.Location = New System.Drawing.Point(164, 176)
        Me.cmd563RevRep.Name = "cmd563RevRep"
        Me.cmd563RevRep.Size = New System.Drawing.Size(276, 31)
        Me.cmd563RevRep.TabIndex = 4
        Me.cmd563RevRep.Text = "563 REVENUE REPORT"
        '
        'dtpToDate
        '
        Me.dtpToDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToDate.Location = New System.Drawing.Point(175, 136)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(233, 21)
        Me.dtpToDate.TabIndex = 3
        Me.dtpToDate.Value = New Date(2005, 1, 24, 0, 0, 0, 0)
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromDate.Location = New System.Drawing.Point(175, 104)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(233, 21)
        Me.dtpFromDate.TabIndex = 2
        Me.dtpFromDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(5, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 16)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "From Ship Work Date:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(84, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 58
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(108, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 16)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Model:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn563PreBillInWIP
        '
        Me.btn563PreBillInWIP.BackColor = System.Drawing.Color.SteelBlue
        Me.btn563PreBillInWIP.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn563PreBillInWIP.ForeColor = System.Drawing.Color.White
        Me.btn563PreBillInWIP.Location = New System.Drawing.Point(24, 448)
        Me.btn563PreBillInWIP.Name = "btn563PreBillInWIP"
        Me.btn563PreBillInWIP.Size = New System.Drawing.Size(416, 31)
        Me.btn563PreBillInWIP.TabIndex = 71
        Me.btn563PreBillInWIP.Text = "563 Revenue Report (Pre-bill Devices In WIP)"
        '
        'btnRevenueReprt_SpecialBilling
        '
        Me.btnRevenueReprt_SpecialBilling.BackColor = System.Drawing.Color.SteelBlue
        Me.btnRevenueReprt_SpecialBilling.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRevenueReprt_SpecialBilling.ForeColor = System.Drawing.Color.White
        Me.btnRevenueReprt_SpecialBilling.Location = New System.Drawing.Point(160, 376)
        Me.btnRevenueReprt_SpecialBilling.Name = "btnRevenueReprt_SpecialBilling"
        Me.btnRevenueReprt_SpecialBilling.Size = New System.Drawing.Size(276, 31)
        Me.btnRevenueReprt_SpecialBilling.TabIndex = 8
        Me.btnRevenueReprt_SpecialBilling.Text = "Special Billing Revenue Report"
        '
        'cboCustomers
        '
        Me.cboCustomers.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
        Me.cboCustomers.AutoCompletion = True
        Me.cboCustomers.AutoDropDown = True
        Me.cboCustomers.AutoSelect = True
        Me.cboCustomers.Caption = ""
        Me.cboCustomers.CaptionHeight = 17
        Me.cboCustomers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboCustomers.ColumnCaptionHeight = 17
        Me.cboCustomers.ColumnFooterHeight = 17
        Me.cboCustomers.ColumnHeaders = False
        Me.cboCustomers.ContentHeight = 15
        Me.cboCustomers.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboCustomers.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboCustomers.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomers.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboCustomers.EditorHeight = 15
        Me.cboCustomers.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.cboCustomers.ItemHeight = 15
        Me.cboCustomers.Location = New System.Drawing.Point(176, 40)
        Me.cboCustomers.MatchEntryTimeout = CType(2000, Long)
        Me.cboCustomers.MaxDropDownItems = CType(10, Short)
        Me.cboCustomers.MaxLength = 32767
        Me.cboCustomers.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboCustomers.Name = "cboCustomers"
        Me.cboCustomers.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboCustomers.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboCustomers.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboCustomers.Size = New System.Drawing.Size(232, 21)
        Me.cboCustomers.TabIndex = 0
        Me.cboCustomers.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
        Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.cboModels.ItemHeight = 15
        Me.cboModels.Location = New System.Drawing.Point(176, 72)
        Me.cboModels.MatchEntryTimeout = CType(2000, Long)
        Me.cboModels.MaxDropDownItems = CType(10, Short)
        Me.cboModels.MaxLength = 32767
        Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboModels.Name = "cboModels"
        Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboModels.Size = New System.Drawing.Size(232, 21)
        Me.cboModels.TabIndex = 1
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
        "ultRecSelWidth>17</DefaultRecSelWidth></Blob>"
        '
        'frmCompare_Consumed_AutoBilled_Revenue
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(552, 566)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btn563PreBillInWIP, Me.Panel3})
        Me.Name = "frmCompare_Consumed_AutoBilled_Revenue"
        Me.Text = "563 REVENUE"
        Me.Panel3.ResumeLayout(False)
        CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCompare_Consumed_AutoBilled_Revenue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dt As DataTable

        Try
            Me.dtpFromDate.Text = Now
            Me.dtpToDate.Text = Now
            dt = PSS.Data.Buisness.Generic.GetModels(True, , , )
            Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_desc", "Model_id")
            dt = PSS.Data.Buisness.Generic.GetCustomers(True, , , True)
            Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '*******************************************************************
    Private Sub cmd563RevRep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd563RevRep.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill()

        Try

            If Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MessageBox.Show("Please select dates.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dtpToDate.Text < Me.dtpFromDate.Text Then
                MessageBox.Show("'To Ship Work Date' must be greater than or equal to 'From Ship Work Date'.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                i = objAutoBill.Create563ReveueReport(Me.cboCustomers.SelectedValue, Me.cboCustomers.Text, Me.cboModels.SelectedValue, _
                                                      Me.dtpFromDate.Value.ToString("yyyy-MM-dd"), Me.dtpToDate.Value.ToString("yyyy-MM-dd"))

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub cmdLevel_2_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLevel_2_3.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill()
        Dim iNoSlvg_OR_Level2And3_Flg As Integer = 2    '2: Labor level is 2 and 3

        Try

            If Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MessageBox.Show("Please select dates.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dtpToDate.Text < Me.dtpFromDate.Text Then
                MessageBox.Show("'To Ship Work Date' must be greater than or equal to 'From Ship Work Date'.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                i = objAutoBill.Create563ReveueReportLevel2And3(Me.cboCustomers.SelectedValue, Me.cboCustomers.Text, Me.cboModels.SelectedValue, _
                                                                Me.dtpFromDate.Value.ToString("yyyy-MM-dd"), Me.dtpToDate.Value.ToString("yyyy-MM-dd"),  iNoSlvg_OR_Level2And3_Flg)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub btn563NoSlvg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn563NoSlvg.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill()
        Dim iNoSlvg_OR_Level2And3_Flg As Integer = 1    '1:NoSalvage

        Try

            If Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MessageBox.Show("Please select dates.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dtpToDate.Text < Me.dtpFromDate.Text Then
                MessageBox.Show("'To Ship Work Date' must be greater than or equal to 'From Ship Work Date'.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                i = objAutoBill.Create563ReveueReportLevel2And3(Me.cboCustomers.SelectedValue, Me.cboCustomers.Text, Me.cboModels.SelectedValue, _
                                                                Me.dtpFromDate.Text, Me.dtpToDate.Text, iNoSlvg_OR_Level2And3_Flg)

            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub btn563SlvgOnly_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn563SlvgOnly.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill()
        Dim iNoSlvg_OR_Level2And3_Flg As Integer = 0    '0:Salvage Only

        Try
            If Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
                MessageBox.Show("Please select dates.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            ElseIf Me.dtpToDate.Text < Me.dtpFromDate.Text Then
                MessageBox.Show("'To Ship Work Date' must be greater than or equal to 'From Ship Work Date'.", "Select Dates", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            Else
                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

                i = objAutoBill.Create563ReveueReportLevel2And3(Me.cboCustomers.SelectedValue, Me.cboCustomers.Text, Me.cboModels.SelectedValue, _
                                                              Me.dtpFromDate.Text, Me.dtpToDate.Text, iNoSlvg_OR_Level2And3_Flg)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True : Cursor.Current = Cursors.Default
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************
    Private Sub btn563PreBillInWIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn563PreBillInWIP.Click
        Dim i As Integer = 0
        Dim objAutoBill As New PSS.Data.Buisness.AutoBill_Prebill_InWIP()
        Dim iNoSlvg_OR_Level2And3_Flg As Integer = 3    '3:InWIP have Pre-bill Lot

        Try
            If Me.cboCustomers.SelectedValue = 0 Then
                MessageBox.Show("Please select a Customer.", "Select Customer", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If

            Me.Enabled = False

            i = objAutoBill.Create563ReveueReportLevel2And3(Me.cboCustomers.SelectedValue, Me.cboCustomers.Text, Me.cboModels.SelectedValue, _
                                                          Me.dtpFromDate.Value.ToString("yyyy-MM-dd"), Me.dtpToDate.Value.ToString("yyyy-MM-dd"), iNoSlvg_OR_Level2And3_Flg)


        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            objAutoBill = Nothing
        End Try
    End Sub

    '*******************************************************************


End Class
