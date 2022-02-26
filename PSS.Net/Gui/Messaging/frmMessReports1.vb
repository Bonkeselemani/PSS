Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui
    Public Class frmMessReports1
        Inherits System.Windows.Forms.Form

        Private _strRptName As String = ""

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
        Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
        Friend WithEvents lblStartDate As System.Windows.Forms.Label
        Friend WithEvents gbDate As System.Windows.Forms.GroupBox
        Friend WithEvents lblEndDate As System.Windows.Forms.Label
        Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnRunRpt As System.Windows.Forms.Button
        Friend WithEvents gbCustomer As System.Windows.Forms.GroupBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents cboCustomers As C1.Win.C1List.C1Combo
        Friend WithEvents rbtnWipSummary As System.Windows.Forms.RadioButton
        Friend WithEvents rbtnWipDetails As System.Windows.Forms.RadioButton
        Friend WithEvents gbDetailSummary As System.Windows.Forms.GroupBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessReports1))
            Me.cboReportName = New System.Windows.Forms.ComboBox()
            Me.lblStartDate = New System.Windows.Forms.Label()
            Me.gbDate = New System.Windows.Forms.GroupBox()
            Me.lblEndDate = New System.Windows.Forms.Label()
            Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
            Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnRunRpt = New System.Windows.Forms.Button()
            Me.gbCustomer = New System.Windows.Forms.GroupBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.cboCustomers = New C1.Win.C1List.C1Combo()
            Me.gbDetailSummary = New System.Windows.Forms.GroupBox()
            Me.rbtnWipSummary = New System.Windows.Forms.RadioButton()
            Me.rbtnWipDetails = New System.Windows.Forms.RadioButton()
            Me.gbDate.SuspendLayout()
            Me.gbCustomer.SuspendLayout()
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.gbDetailSummary.SuspendLayout()
            Me.SuspendLayout()
            '
            'cboReportName
            '
            Me.cboReportName.ItemHeight = 13
            Me.cboReportName.Location = New System.Drawing.Point(168, 24)
            Me.cboReportName.MaxDropDownItems = 25
            Me.cboReportName.Name = "cboReportName"
            Me.cboReportName.Size = New System.Drawing.Size(272, 21)
            Me.cboReportName.TabIndex = 0
            '
            'lblStartDate
            '
            Me.lblStartDate.BackColor = System.Drawing.Color.Transparent
            Me.lblStartDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStartDate.ForeColor = System.Drawing.Color.White
            Me.lblStartDate.Location = New System.Drawing.Point(56, 27)
            Me.lblStartDate.Name = "lblStartDate"
            Me.lblStartDate.Size = New System.Drawing.Size(104, 16)
            Me.lblStartDate.TabIndex = 104
            Me.lblStartDate.Text = "Report Name :"
            Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'gbDate
            '
            Me.gbDate.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblEndDate, Me.dtpEndDate, Me.dtpStartDate, Me.Label1})
            Me.gbDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDate.ForeColor = System.Drawing.Color.White
            Me.gbDate.Location = New System.Drawing.Point(56, 128)
            Me.gbDate.Name = "gbDate"
            Me.gbDate.Size = New System.Drawing.Size(400, 104)
            Me.gbDate.TabIndex = 2
            Me.gbDate.TabStop = False
            Me.gbDate.Text = "DATE"
            Me.gbDate.Visible = False
            '
            'lblEndDate
            '
            Me.lblEndDate.BackColor = System.Drawing.Color.Transparent
            Me.lblEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblEndDate.ForeColor = System.Drawing.Color.White
            Me.lblEndDate.Location = New System.Drawing.Point(24, 64)
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
            Me.dtpEndDate.Location = New System.Drawing.Point(112, 64)
            Me.dtpEndDate.Name = "dtpEndDate"
            Me.dtpEndDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpEndDate.TabIndex = 2
            Me.dtpEndDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'dtpStartDate
            '
            Me.dtpStartDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpStartDate.Location = New System.Drawing.Point(112, 32)
            Me.dtpStartDate.Name = "dtpStartDate"
            Me.dtpStartDate.Size = New System.Drawing.Size(272, 21)
            Me.dtpStartDate.TabIndex = 1
            Me.dtpStartDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(24, 32)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 103
            Me.Label1.Text = "Start:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRunRpt
            '
            Me.btnRunRpt.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRunRpt.ForeColor = System.Drawing.Color.White
            Me.btnRunRpt.Location = New System.Drawing.Point(56, 272)
            Me.btnRunRpt.Name = "btnRunRpt"
            Me.btnRunRpt.Size = New System.Drawing.Size(400, 32)
            Me.btnRunRpt.TabIndex = 106
            Me.btnRunRpt.TabStop = False
            Me.btnRunRpt.Visible = False
            '
            'gbCustomer
            '
            Me.gbCustomer.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label3, Me.cboCustomers})
            Me.gbCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbCustomer.ForeColor = System.Drawing.Color.White
            Me.gbCustomer.Location = New System.Drawing.Point(56, 64)
            Me.gbCustomer.Name = "gbCustomer"
            Me.gbCustomer.Size = New System.Drawing.Size(400, 48)
            Me.gbCustomer.TabIndex = 1
            Me.gbCustomer.TabStop = False
            Me.gbCustomer.Text = "CUSTOMER"
            Me.gbCustomer.Visible = False
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(24, 16)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(80, 16)
            Me.Label3.TabIndex = 105
            Me.Label3.Text = "Name:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            'gbDetailSummary
            '
            Me.gbDetailSummary.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnWipSummary, Me.rbtnWipDetails})
            Me.gbDetailSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbDetailSummary.ForeColor = System.Drawing.Color.White
            Me.gbDetailSummary.Location = New System.Drawing.Point(56, 336)
            Me.gbDetailSummary.Name = "gbDetailSummary"
            Me.gbDetailSummary.Size = New System.Drawing.Size(400, 56)
            Me.gbDetailSummary.TabIndex = 106
            Me.gbDetailSummary.TabStop = False
            Me.gbDetailSummary.Visible = False
            '
            'rbtnWipSummary
            '
            Me.rbtnWipSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnWipSummary.ForeColor = System.Drawing.Color.White
            Me.rbtnWipSummary.Location = New System.Drawing.Point(232, 24)
            Me.rbtnWipSummary.Name = "rbtnWipSummary"
            Me.rbtnWipSummary.Size = New System.Drawing.Size(112, 24)
            Me.rbtnWipSummary.TabIndex = 4
            Me.rbtnWipSummary.Text = "Summary Only"
            '
            'rbtnWipDetails
            '
            Me.rbtnWipDetails.Checked = True
            Me.rbtnWipDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbtnWipDetails.ForeColor = System.Drawing.Color.White
            Me.rbtnWipDetails.Location = New System.Drawing.Point(56, 24)
            Me.rbtnWipDetails.Name = "rbtnWipDetails"
            Me.rbtnWipDetails.Size = New System.Drawing.Size(144, 24)
            Me.rbtnWipDetails.TabIndex = 3
            Me.rbtnWipDetails.TabStop = True
            Me.rbtnWipDetails.Text = "Details and Summary"
            '
            'frmMessReports1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(528, 446)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbCustomer, Me.btnRunRpt, Me.gbDate, Me.lblStartDate, Me.cboReportName, Me.gbDetailSummary})
            Me.Name = "frmMessReports1"
            Me.Text = "frmMessReports1"
            Me.gbDate.ResumeLayout(False)
            Me.gbCustomer.ResumeLayout(False)
            CType(Me.cboCustomers, System.ComponentModel.ISupportInitialize).EndInit()
            Me.gbDetailSummary.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '********************************************************************************************************************
        Private Sub frmMessReports1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As DataTable

            Try
                If Me._strRptName.Trim.Length = 0 Then
                    ' *************Load Report Name ***************************
                    Me.cboReportName.Items.Clear()
                    Me.cboReportName.Items.Add("Select Report Name")
                    Me.cboReportName.Items.Add("Messaging WIP Report")
                    Me.cboReportName.Items.Add("Messaging WH Report")
                    Me.cboReportName.Items.Add("Receiving Report")
                    Me.cboReportName.Items.Add("Messaging Quality Report")
                    Me.cboReportName.Items.Add("Messaging Eval Charges")
                    Me.cboReportName.Items.Add("Messaging Send-To-Location Shipment")

                    'Me.cboReportName.Items.Add("AMS Forecasted vs Dock Ship")
                    'Me.cboReportName.Items.Add("AMS Forecasted vs LQP")
                    'Me.cboReportName.Items.Add("AMS Matrix Report")
                    'Me.cboReportName.Items.Add("Matrix Report")

                    Me.cboReportName.Text = "Select Report Name"

                    dt = Generic.GetCustomers(True, 1, , , )
                    Misc.PopulateC1DropDownList(Me.cboCustomers, dt, "Cust_Name1", "Cust_ID")
                    Me.cboCustomers.SelectedValue = 0

                    Me.gbDate.Visible = False
                    Me.gbCustomer.Visible = False
                    Me.btnRunRpt.Visible = False
                End If
                '***********************************************************

                Me.dtpStartDate.Value = Now()
                Me.dtpEndDate.Value = Now()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Sub cboReportName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.TextChanged
            Try

                Me._strRptName = ""
                Me.gbDate.Visible = False
                Me.gbCustomer.Visible = False
                Me.btnRunRpt.Visible = False
                Me.gbDetailSummary.Visible = False

                If Me.cboReportName.Text <> "Select Report Name" Then
                    Me._strRptName = Me.cboReportName.Text

                    If Me._strRptName = "Messaging WIP Report" Then
                        Me.gbDetailSummary.Visible = True
                        Me.gbDetailSummary.Top = Me.gbCustomer.Top
                        Me.gbDetailSummary.Left = Me.gbCustomer.Left
                        Me.rbtnWipDetails.Checked = True
                        Me.btnRunRpt.Text = "Get """ & _strRptName & """"
                        Me.btnRunRpt.Visible = True
                    ElseIf Me._strRptName = "Messaging WH Report" Then
                        Me.gbDetailSummary.Visible = True
                        Me.gbDetailSummary.Top = Me.gbCustomer.Top
                        Me.gbDetailSummary.Left = Me.gbCustomer.Left
                        Me.rbtnWipDetails.Checked = True
                        Me.btnRunRpt.Text = "Get """ & _strRptName & """"
                        Me.btnRunRpt.Visible = True
                    ElseIf Me._strRptName = "Receiving Report" Then
                        Me.gbDate.Visible = True
                        Me.btnRunRpt.Text = "Get """ & _strRptName & """"
                        Me.btnRunRpt.Visible = True
                    ElseIf Me._strRptName = "Messaging Quality Report" Then
                        OpenMQReport()
                    ElseIf Me._strRptName = "Messaging Eval Charges" Then
                        Me.gbDate.Visible = True
                    ElseIf Me._strRptName = "Messaging Send-To-Location Shipment" Then
                        Me.gbDate.Visible = True
                    End If
                    Me.btnRunRpt.Text = "Get """ & _strRptName & """"
                    Me.btnRunRpt.Visible = True

                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "cboReportName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '********************************************************************************************************************
        Private Sub btnRunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunRpt.Click
            Dim objExcelRpt As New PSS.Data.Buisness.MessReports()
            Dim objExcelRptMore As New PSS.Data.Buisness.MessagingReportMore()
            Dim objMessCust As New PSS.Data.Buisness.Messaging()
            Dim strDateStart As String = "", strDateEnd As String = ""
            Dim strCustIDs As String = "", strLocIDs As String = ""
            Dim strOtherMessCustIDs As String = ""
            Dim strOtherMessArray As New ArrayList()
            Dim bIncludeAllColumns As Boolean = False
            Dim bIncludeWIPHoldInSummaryReport As Boolean = False
            Dim dt, dtTmp As DataTable
            Dim row As DataRow

            Try
                If Me.gbDate.Visible = True AndAlso DateDiff(DateInterval.Day, Me.dtpStartDate.Value, Me.dtpEndDate.Value) < 0 Then
                    MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                ElseIf Me.gbCustomer.Visible = True AndAlso Me.cboCustomers.SelectedValue = 0 Then
                    MessageBox.Show("Please select customer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    '*************************************
                    'Define user input
                    '*************************************
                    strDateStart = "" : strDateEnd = ""

                    If Me.gbDate.Visible = True Then
                        strDateStart = Me.dtpStartDate.Value.ToString("yyyy-MM-dd")
                        strDateEnd = Me.dtpEndDate.Value.ToString("yyyy-MM-dd")
                    End If
                    If Me.gbCustomer.Visible = True Then strCustIDs = Me.cboCustomers.SelectedValue

                    '*************************************
                    'Generate Report
                    '*************************************
                    If Me._strRptName = "Messaging WIP Report" Then
                        strCustIDs = objExcelRpt.GetAMSMessCustIDs()
                        strOtherMessCustIDs = objMessCust.getOtherCustomers(strOtherMessArray)
                        If strCustIDs.Trim.Length > 0 AndAlso strOtherMessCustIDs.Trim.Length > 0 Then
                            strCustIDs &= "," & strOtherMessCustIDs
                        ElseIf strOtherMessCustIDs.Trim.Length > 0 Then
                            strCustIDs = strOtherMessCustIDs
                        ElseIf strCustIDs.Trim.Length > 0 Then
                            'Do Nothing, keep original
                        End If
                        If Me.rbtnWipSummary.Checked = True Then
                            objExcelRpt.CreateMessagingWIPReport(strCustIDs, bIncludeAllColumns, True, bIncludeWIPHoldInSummaryReport, dt)
                        Else
                            objExcelRpt.CreateMessagingWIPReport(strCustIDs, bIncludeAllColumns, False, bIncludeWIPHoldInSummaryReport, dt)
                        End If
                    ElseIf Me._strRptName = "Messaging WH Report" Then
                        strCustIDs = objExcelRpt.GetAMSMessCustIDs()
                        strOtherMessCustIDs = objMessCust.getOtherCustomers(strOtherMessArray)
                        If strCustIDs.Trim.Length > 0 AndAlso strOtherMessCustIDs.Trim.Length > 0 Then
                            strCustIDs &= "," & strOtherMessCustIDs
                        ElseIf strOtherMessCustIDs.Trim.Length > 0 Then
                            strCustIDs = strOtherMessCustIDs
                        ElseIf strCustIDs.Trim.Length > 0 Then
                            'Do Nothing, keep original
                        End If
                        If Me.rbtnWipSummary.Checked = True Then
                            objExcelRptMore.CreateMessagingWHReport(strCustIDs, bIncludeAllColumns, True, bIncludeWIPHoldInSummaryReport, dt)
                        Else
                            objExcelRptMore.CreateMessagingWHReport(strCustIDs, bIncludeAllColumns, False, bIncludeWIPHoldInSummaryReport, dt)
                        End If
                    ElseIf Me._strRptName = "Receiving Report" Then
                        strCustIDs = objExcelRpt.GetAMSMessCustIDs()
                        strOtherMessCustIDs = objMessCust.getOtherCustomers(strOtherMessArray)
                        If strCustIDs.Trim.Length > 0 AndAlso strOtherMessCustIDs.Trim.Length > 0 Then
                            strCustIDs &= "," & strOtherMessCustIDs
                        ElseIf strOtherMessCustIDs.Trim.Length > 0 Then
                            strCustIDs = strOtherMessCustIDs
                        ElseIf strCustIDs.Trim.Length > 0 Then
                            'Do Nothing, keep original
                        End If
                        dtTmp = ModManuf.GetCustomerLocationByCustIDs(strCustIDs)
                        strLocIDs = ""
                        For Each row In dtTmp.Rows
                            If strLocIDs.Trim.Length = 0 Then
                                strLocIDs = row("Loc_ID")
                            Else
                                strLocIDs &= "," & row("Loc_ID")
                            End If
                        Next
                        If strLocIDs.Trim.Length = 0 Then
                            MessageBox.Show("No customer location ID(s).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            objExcelRpt.CreateMessagingReceivingReport(strLocIDs, Me._strRptName, strDateStart, strDateEnd, False)
                        End If
                    ElseIf Me._strRptName = "Messaging Quality Report" Then
                        OpenMQReport()
                    ElseIf Me._strRptName = "Messaging Eval Charges" Then
                        objExcelRpt.CreateMessagingEvalProcessChargeReport(Me._strRptName, strDateStart, strDateEnd, False)
                    ElseIf Me._strRptName = "Messaging Send-To-Location Shipment" Then
                        objExcelRptMore.CreateMessagingSendToLocationShipment(strDateStart, strDateEnd)
                    Else
                        MessageBox.Show("No report available for this selection.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                    '*************************************
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnRunRpt_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True : Cursor.Current = Cursors.Default
                objExcelRpt = Nothing : dt = Nothing : dtTmp = Nothing
                GC.Collect() : GC.WaitForPendingFinalizers()
                GC.Collect() : GC.WaitForPendingFinalizers()
            End Try
        End Sub

        Protected Sub OpenMQReport()
            Dim strTabPageTitle As String = "Messaging Quality Report"
            Dim win As Crownwood.Magic.Controls.TabPage
            If Not Misc.CheckOpenTabs(strTabPageTitle) Then
                Misc.OpenWin(strTabPageTitle, win, New frmMessQualityRep())
            End If
        End Sub

        '********************************************************************************************************************

      
    End Class
End Namespace