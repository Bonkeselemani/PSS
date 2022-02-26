Option Explicit On 

Namespace Gui.TracFone

	Public Class frmExcelRpt
		Inherits System.Windows.Forms.Form

#Region " DECLARATIONS "

		Private _iMenuCustID As Integer
		Private _iMenuLocID As Integer
		Private _strRptName As String = ""
		Private _iLagEffectiveDate = 25

#End Region

#Region " Windows Form Designer generated code "

		Public Sub New(ByVal iCustID As Integer, ByVal iLocID As Integer)
			MyBase.New()

			'This call is required by the Windows Form Designer.
			InitializeComponent()

			'Add any initialization after the InitializeComponent() call
			_iMenuCustID = iCustID
			_iMenuLocID = iLocID

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
		Friend WithEvents gbReportName As System.Windows.Forms.GroupBox
		Friend WithEvents cboReportName As System.Windows.Forms.ComboBox
		Friend WithEvents gbWorkStation As System.Windows.Forms.GroupBox
		Friend WithEvents txtWorkstation As System.Windows.Forms.TextBox
		Friend WithEvents gbModels As System.Windows.Forms.GroupBox
		Friend WithEvents txtWHBox As System.Windows.Forms.TextBox
		Friend WithEvents btnRunRpt As System.Windows.Forms.Button
		Friend WithEvents gbWHBoxID As System.Windows.Forms.GroupBox
		Friend WithEvents cboModels As C1.Win.C1List.C1Combo
		Friend WithEvents gbDateRange As System.Windows.Forms.GroupBox
		Friend WithEvents Label1 As System.Windows.Forms.Label
		Friend WithEvents Label2 As System.Windows.Forms.Label
		Friend WithEvents gbDateModelSelection As System.Windows.Forms.GroupBox
		Friend WithEvents rbtnByModel As System.Windows.Forms.RadioButton
		Friend WithEvents rbtnByDateRange As System.Windows.Forms.RadioButton
		Friend WithEvents dtpDateStart As System.Windows.Forms.DateTimePicker
		Friend WithEvents dtpDateEnd As System.Windows.Forms.DateTimePicker
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmExcelRpt))
			Me.gbReportName = New System.Windows.Forms.GroupBox()
			Me.cboReportName = New System.Windows.Forms.ComboBox()
			Me.gbWorkStation = New System.Windows.Forms.GroupBox()
			Me.txtWorkstation = New System.Windows.Forms.TextBox()
			Me.gbModels = New System.Windows.Forms.GroupBox()
			Me.cboModels = New C1.Win.C1List.C1Combo()
			Me.gbWHBoxID = New System.Windows.Forms.GroupBox()
			Me.txtWHBox = New System.Windows.Forms.TextBox()
			Me.btnRunRpt = New System.Windows.Forms.Button()
			Me.gbDateRange = New System.Windows.Forms.GroupBox()
			Me.Label2 = New System.Windows.Forms.Label()
			Me.Label1 = New System.Windows.Forms.Label()
			Me.dtpDateEnd = New System.Windows.Forms.DateTimePicker()
			Me.dtpDateStart = New System.Windows.Forms.DateTimePicker()
			Me.gbDateModelSelection = New System.Windows.Forms.GroupBox()
			Me.rbtnByDateRange = New System.Windows.Forms.RadioButton()
			Me.rbtnByModel = New System.Windows.Forms.RadioButton()
			Me.gbReportName.SuspendLayout()
			Me.gbWorkStation.SuspendLayout()
			Me.gbModels.SuspendLayout()
			CType(Me.cboModels, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.gbWHBoxID.SuspendLayout()
			Me.gbDateRange.SuspendLayout()
			Me.gbDateModelSelection.SuspendLayout()
			Me.SuspendLayout()
			'
			'gbReportName
			'
			Me.gbReportName.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboReportName})
			Me.gbReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
			Me.gbReportName.ForeColor = System.Drawing.Color.Lime
			Me.gbReportName.Location = New System.Drawing.Point(16, 24)
			Me.gbReportName.Name = "gbReportName"
			Me.gbReportName.Size = New System.Drawing.Size(400, 48)
			Me.gbReportName.TabIndex = 1
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
			'gbWorkStation
			'
			Me.gbWorkStation.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWorkstation})
			Me.gbWorkStation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.gbWorkStation.ForeColor = System.Drawing.Color.White
			Me.gbWorkStation.Location = New System.Drawing.Point(16, 304)
			Me.gbWorkStation.Name = "gbWorkStation"
			Me.gbWorkStation.Size = New System.Drawing.Size(400, 48)
			Me.gbWorkStation.TabIndex = 4
			Me.gbWorkStation.TabStop = False
			Me.gbWorkStation.Text = "Work Station"
			Me.gbWorkStation.Visible = False
			'
			'txtWorkstation
			'
			Me.txtWorkstation.Location = New System.Drawing.Point(112, 16)
			Me.txtWorkstation.Name = "txtWorkstation"
			Me.txtWorkstation.Size = New System.Drawing.Size(272, 20)
			Me.txtWorkstation.TabIndex = 1
			Me.txtWorkstation.Text = ""
			'
			'gbModels
			'
			Me.gbModels.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboModels})
			Me.gbModels.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
			Me.gbModels.ForeColor = System.Drawing.Color.White
			Me.gbModels.Location = New System.Drawing.Point(16, 248)
			Me.gbModels.Name = "gbModels"
			Me.gbModels.Size = New System.Drawing.Size(400, 48)
			Me.gbModels.TabIndex = 3
			Me.gbModels.TabStop = False
			Me.gbModels.Text = "Model"
			Me.gbModels.Visible = False
			'
			'cboModels
			'
			Me.cboModels.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
			Me.cboModels.Caption = ""
			Me.cboModels.CaptionHeight = 17
			Me.cboModels.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
			Me.cboModels.ColumnCaptionHeight = 17
			Me.cboModels.ColumnFooterHeight = 17
			Me.cboModels.ContentHeight = 15
			Me.cboModels.DeadAreaBackColor = System.Drawing.Color.Empty
			Me.cboModels.EditorBackColor = System.Drawing.SystemColors.Window
			Me.cboModels.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.cboModels.EditorForeColor = System.Drawing.SystemColors.WindowText
			Me.cboModels.EditorHeight = 15
			Me.cboModels.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.cboModels.ItemHeight = 15
			Me.cboModels.Location = New System.Drawing.Point(112, 14)
			Me.cboModels.MatchEntryTimeout = CType(2000, Long)
			Me.cboModels.MaxDropDownItems = CType(5, Short)
			Me.cboModels.MaxLength = 32767
			Me.cboModels.MouseCursor = System.Windows.Forms.Cursors.Default
			Me.cboModels.Name = "cboModels"
			Me.cboModels.RowDivider.Color = System.Drawing.Color.DarkGray
			Me.cboModels.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
			Me.cboModels.RowSubDividerColor = System.Drawing.Color.DarkGray
			Me.cboModels.Size = New System.Drawing.Size(272, 21)
			Me.cboModels.TabIndex = 1
			Me.cboModels.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
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
			'gbWHBoxID
			'
			Me.gbWHBoxID.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWHBox})
			Me.gbWHBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.gbWHBoxID.ForeColor = System.Drawing.Color.White
			Me.gbWHBoxID.Location = New System.Drawing.Point(16, 184)
			Me.gbWHBoxID.Name = "gbWHBoxID"
			Me.gbWHBoxID.Size = New System.Drawing.Size(400, 48)
			Me.gbWHBoxID.TabIndex = 2
			Me.gbWHBoxID.TabStop = False
			Me.gbWHBoxID.Text = "Warehouse Box ID"
			Me.gbWHBoxID.Visible = False
			'
			'txtWHBox
			'
			Me.txtWHBox.Location = New System.Drawing.Point(112, 16)
			Me.txtWHBox.Name = "txtWHBox"
			Me.txtWHBox.Size = New System.Drawing.Size(272, 20)
			Me.txtWHBox.TabIndex = 1
			Me.txtWHBox.Text = ""
			'
			'btnRunRpt
			'
			Me.btnRunRpt.BackColor = System.Drawing.Color.SteelBlue
			Me.btnRunRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnRunRpt.ForeColor = System.Drawing.Color.White
			Me.btnRunRpt.Location = New System.Drawing.Point(16, 376)
			Me.btnRunRpt.Name = "btnRunRpt"
			Me.btnRunRpt.Size = New System.Drawing.Size(400, 40)
			Me.btnRunRpt.TabIndex = 5
			'
			'gbDateRange
			'
			Me.gbDateRange.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.dtpDateEnd, Me.dtpDateStart})
			Me.gbDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.gbDateRange.ForeColor = System.Drawing.Color.White
			Me.gbDateRange.Location = New System.Drawing.Point(16, 120)
			Me.gbDateRange.Name = "gbDateRange"
			Me.gbDateRange.Size = New System.Drawing.Size(400, 48)
			Me.gbDateRange.TabIndex = 6
			Me.gbDateRange.TabStop = False
			Me.gbDateRange.Text = "Date"
			Me.gbDateRange.Visible = False
			'
			'Label2
			'
			Me.Label2.Location = New System.Drawing.Point(208, 16)
			Me.Label2.Name = "Label2"
			Me.Label2.Size = New System.Drawing.Size(40, 23)
			Me.Label2.TabIndex = 3
			Me.Label2.Text = "End"
			Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'Label1
			'
			Me.Label1.Location = New System.Drawing.Point(16, 16)
			Me.Label1.Name = "Label1"
			Me.Label1.Size = New System.Drawing.Size(40, 23)
			Me.Label1.TabIndex = 2
			Me.Label1.Text = "Start"
			Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
			'
			'dtpDateEnd
			'
			Me.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
			Me.dtpDateEnd.Location = New System.Drawing.Point(256, 16)
			Me.dtpDateEnd.Name = "dtpDateEnd"
			Me.dtpDateEnd.Size = New System.Drawing.Size(128, 20)
			Me.dtpDateEnd.TabIndex = 1
			'
			'dtpDateStart
			'
			Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
			Me.dtpDateStart.Location = New System.Drawing.Point(64, 16)
			Me.dtpDateStart.Name = "dtpDateStart"
			Me.dtpDateStart.Size = New System.Drawing.Size(128, 20)
			Me.dtpDateStart.TabIndex = 0
			'
			'gbDateModelSelection
			'
			Me.gbDateModelSelection.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbtnByDateRange, Me.rbtnByModel})
			Me.gbDateModelSelection.Location = New System.Drawing.Point(16, 72)
			Me.gbDateModelSelection.Name = "gbDateModelSelection"
			Me.gbDateModelSelection.Size = New System.Drawing.Size(400, 40)
			Me.gbDateModelSelection.TabIndex = 7
			Me.gbDateModelSelection.TabStop = False
			Me.gbDateModelSelection.Visible = False
			'
			'rbtnByDateRange
			'
			Me.rbtnByDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.rbtnByDateRange.ForeColor = System.Drawing.Color.White
			Me.rbtnByDateRange.Location = New System.Drawing.Point(136, 16)
			Me.rbtnByDateRange.Name = "rbtnByDateRange"
			Me.rbtnByDateRange.Size = New System.Drawing.Size(104, 16)
			Me.rbtnByDateRange.TabIndex = 1
			Me.rbtnByDateRange.Text = "By Date Range"
			'
			'rbtnByModel
			'
			Me.rbtnByModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.rbtnByModel.ForeColor = System.Drawing.Color.White
			Me.rbtnByModel.Location = New System.Drawing.Point(16, 16)
			Me.rbtnByModel.Name = "rbtnByModel"
			Me.rbtnByModel.Size = New System.Drawing.Size(104, 16)
			Me.rbtnByModel.TabIndex = 0
			Me.rbtnByModel.Text = "By Model"
			'
			'frmExcelRpt
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.SteelBlue
			Me.ClientSize = New System.Drawing.Size(728, 494)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbDateModelSelection, Me.gbDateRange, Me.btnRunRpt, Me.gbWHBoxID, Me.gbModels, Me.gbWorkStation, Me.gbReportName})
			Me.Name = "frmExcelRpt"
			Me.Text = "frmExcelRpt"
			Me.gbReportName.ResumeLayout(False)
			Me.gbWorkStation.ResumeLayout(False)
			Me.gbModels.ResumeLayout(False)
			CType(Me.cboModels, System.ComponentModel.ISupportInitialize).EndInit()
			Me.gbWHBoxID.ResumeLayout(False)
			Me.gbDateRange.ResumeLayout(False)
			Me.gbDateModelSelection.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

#End Region

#Region " FORM EVENTS "

		Private Sub frmExcelRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			' LOAD THE FORM.
			Dim dt As DataTable
			Dim objTFBuildShipPallet As New Data.Buisness.TracFone.BuildShipPallet()
			Try
				PopulateReportList()
				dt = objTFBuildShipPallet.GetModelsWithMotoSku(True)
				Misc.PopulateC1DropDownList(Me.cboModels, dt, "Model_Desc", "Model_ID")
				Me.cboModels.SelectedValue = 0
				Me.dtpDateStart.Value = Now
				Me.dtpDateEnd.Value = Now
				Me.cboReportName.SelectedIndex = 0
				ClearControlValues()
				EnableControls()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				objTFBuildShipPallet = Nothing
				Data.Buisness.Generic.DisposeDT(dt)
			End Try
		End Sub

#End Region

#Region " CONTROL EVENTS "

		Private Sub cboReportName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboReportName.TextChanged
			' HANDLE REPORT NAME CHANGE.
			Dim dt As DataTable
			Try
				Me._strRptName = ""
				If Me.cboReportName.Text <> "Select Report Name" Then
					Me._strRptName = Me.cboReportName.Text
					Me.btnRunRpt.Text = "Get """ & _strRptName & """"
					Me.btnRunRpt.Visible = True
					Me.btnRunRpt.Enabled = True
				Else
					Me.btnRunRpt.Text = ""
					Me.btnRunRpt.Enabled = False
				End If
				ClearControlValues()
				EnableControls()
			Catch ex As Exception
				MessageBox.Show(ex.Message, "cboReportName_TextChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Data.Buisness.Generic.DisposeDT(dt)
			End Try
		End Sub

		Private Sub rbtns_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbtnByModel.CheckedChanged, rbtnByDateRange.CheckedChanged
			' HANDLE THE RADIO BUTTON SELECTION CHANGES.
			Try
				Select Case sender.name
					Case "rbtnByModel"
						If Me.rbtnByModel.Checked = True Then Me.gbModels.Visible = True Else Me.gbModels.Visible = False
					Case "rbtnByDateRange"
						If Me.rbtnByDateRange.Checked = True Then Me.gbDateRange.Visible = True Else Me.gbDateRange.Visible = False
				End Select
			Catch ex As Exception
				MessageBox.Show(ex.Message, sender.name & "_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub

		Private Sub btnRunRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunRpt.Click
			' RUN THE REPORT.
			Dim objTFReport As Data.Buisness.TracFone.Reports
			Dim dsOutput As New DataSet()
			Dim i As Integer
			Try
				If Me._strRptName.Trim.ToCharArray = "" Then
					Exit Sub
				End If
				Me.Enabled = False
				Me.Cursor = Cursors.WaitCursor
				objTFReport = New Data.Buisness.TracFone.Reports()
				If Me._strRptName = "Pre-Evaluate Report" Then
					Dim strCustModel As String = ""
					If Me.txtWHBox.Text.Trim.Length = 0 AndAlso Me.txtWorkstation.Text.Trim.Length = 0 AndAlso Me.cboModels.SelectedValue = 0 Then Throw New Exception("You must enter at least one criteria.")
					If Me.cboModels.SelectedValue > 0 Then strCustModel = Me.cboModels.Text.Trim
					i = objTFReport.RunPreEvalReport(Me._iMenuCustID, Me.txtWHBox.Text.Trim.ToUpper, strCustModel, Me.txtWorkstation.Text.Trim.ToUpper, dsOutput)
				ElseIf Me._strRptName = "Part Re-claim Report" Then
					If Me.rbtnByDateRange.Checked = False AndAlso Me.rbtnByModel.Checked = False Then
						MessageBox.Show("Please select report criteria ( Run by Model or Date Range).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf Me.gbDateRange.Visible = True AndAlso Me.dtpDateStart.Value > Me.dtpDateEnd.Value Then
						MessageBox.Show("Invalid date range.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf Me.gbModels.Visible = True AndAlso Me.cboModels.SelectedValue = 0 Then
						MessageBox.Show("Please select model.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					ElseIf Me.rbtnByDateRange.Checked = True Then
						i = objTFReport.RunPartReClaimRpt(Me._iMenuLocID, Me._strRptName, Me.dtpDateStart.Value.ToString("yyyy-MM-dd"), Me.dtpDateEnd.Value.ToString("yyy-MM-dd"))
					ElseIf Me.rbtnByModel.Checked = True Then
						i = objTFReport.RunPartReClaimRpt(Me._iMenuLocID, Me._strRptName, Me.cboModels.Text)
					End If
				ElseIf Me._strRptName = "Battery Cover Detail Report" Then
					i = objTFReport.RunBatteryCoverDataReport(Me._iMenuLocID, Me._strRptName & " " & Format(Me.dtpDateStart.Value, "yyyyMMdd") & "_" & Format(Me.dtpDateEnd.Value, "yyyyMMdd"), _
					   Me.dtpDateStart.Value.ToString("yyyy-MM-dd") & " 00:00:00", Me.dtpDateEnd.Value.ToString("yyy-MM-dd") & " 23:59:59")
				ElseIf Me._strRptName = "Vendor Performance Report" Then
					i = objTFReport.RunVendorPerformanceReport(Me._strRptName & " " & Format(Me.dtpDateStart.Value, "yyyyMMdd") & "_" & Format(Me.dtpDateEnd.Value, "yyyyMMdd"), _
					   Me.dtpDateStart.Value.ToString("yyyy-MM-dd") & " 00:00:00", Me.dtpDateEnd.Value.ToString("yyy-MM-dd") & " 23:59:59")
				ElseIf Me._strRptName = "Handset Inventory Report" Then
					i = objTFReport.RunHandSetInvenotryRpt(Me._iMenuCustID, Me._iMenuLocID, Me._strRptName & " " & Format(Now, "yyyyMMdd"), Me._iLagEffectiveDate)
				ElseIf Me._strRptName = "Tracfone PQC Report" Then
                    i = objTFReport.RunTFPQCRpt(Me._strRptName, Me.dtpDateStart.Value.ToString("yyyy-MM-dd") & " 00:00:00", Me.dtpDateEnd.Value.ToString("yyy-MM-dd") & " 23:59:59")
                ElseIf Me._strRptName = "TF Inventory Report" Then
                    Dim strMsg As String = "It may take a couple of minutes to run this report. Please run it off the production peak time. Do you want to run?"
                    Dim result1 As DialogResult = MessageBox.Show(strMsg, "Reminder", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                    If result1 = DialogResult.Yes Then
                        i = objTFReport.RunTFInventoryReport(Me._strRptName)
                    End If
                ElseIf Me._strRptName = "TF SW Screen Report" Then
                    i = objTFReport.RunTFSWScreenReport(Me._strRptName, Me.dtpDateStart.Value.ToString("yyy-MM-dd"), Me.dtpDateEnd.Value.ToString("yyy-MM-dd"))
				ElseIf Me._strRptName = "TF Pallet Carton Phone Receiving Report" Then
					i = objTFReport.RunTFPCPRecReport(Me._strRptName, Me.dtpDateStart.Value.ToString("yyy-MM-dd"), Me.dtpDateEnd.Value.ToString("yyy-MM-dd"))


				Else
					Exit Sub
				End If
				If i > 0 Then
					cboReportName.SelectedIndex = 0
					EnableControls()
					ClearControlValues()
					Me.cboModels.Focus()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, "Run-Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True
				Me.Cursor = Cursors.Default
				objTFReport = Nothing
				GC.Collect() : GC.WaitForPendingFinalizers()
				GC.Collect() : GC.WaitForPendingFinalizers()
			End Try
		End Sub

#End Region

#Region " METHODS "

		Private Sub PopulateReportList()
			' POPULATE THE REPORT NAME LIST.
			Me.cboReportName.Items.Clear()
			Me.cboReportName.Items.Add("Select Report Name")
			Me.cboReportName.Items.Add("Part Re-claim Report")
			Me.cboReportName.Items.Add("Pre-Evaluate Report")
			Me.cboReportName.Items.Add("Battery Cover Detail Report")
			Me.cboReportName.Items.Add("Vendor Performance Report")
			Me.cboReportName.Items.Add("Handset Inventory Report")
			Me.cboReportName.Items.Add("Tracfone PQC Report")
            Me.cboReportName.Items.Add("TF Inventory Report")
			Me.cboReportName.Items.Add("TF SW Screen Report")
			Me.cboReportName.Items.Add("TF Pallet Carton Phone Receiving Report")
		End Sub

		Protected Sub EnableControls()
			' SET THE ENABLE AND VISIBLE PROPERTIES FOR THE CONTROLS.
			gbDateModelSelection.Visible = False
			gbDateRange.Visible = False
			gbWHBoxID.Visible = False
			gbModels.Visible = False
			gbWorkStation.Visible = False
			Select Case _strRptName
				Case "Pre-Evaluate Report"
					Me.gbWHBoxID.Visible = True
					Me.gbModels.Visible = True
					Me.gbWorkStation.Visible = True
				Case "Part Re-claim Report"
					Me.gbDateModelSelection.Visible = True
				Case "Battery Cover Detail Report"
					Me.gbDateRange.Visible = True
				Case "Vendor Performance Report"
					Me.gbDateRange.Visible = True
				Case "Tracfone PQC Report"
					Me.gbDateRange.Visible = True
				Case "TF SW Screen Report"
					Me.gbDateRange.Visible = True
				Case "TF Pallet Carton Phone Receiving Report"
					Me.gbDateRange.Visible = True
			End Select
		End Sub

		Protected Sub ClearControlValues()
			' CLEAR THE CONTROL VALUES.
			rbtnByModel.Checked = False
			rbtnByDateRange.Checked = False
			dtpDateStart.Value = Date.Now()
			dtpDateEnd.Value = Date.Now()
			txtWHBox.Text = ""
			cboModels.SelectedValue = 0
			txtWorkstation.Text = ""
		End Sub

#End Region

	End Class

End Namespace