Option Explicit On 
Imports PSS.Data.Buisness
Imports System.IO
Imports System.Text
Namespace Gui
	Public Class frmMessActiveModels
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
		Friend WithEvents lblHeader As System.Windows.Forms.Label
		Friend WithEvents btnActive As System.Windows.Forms.Button
		Friend WithEvents tdgModelCriteria As C1.Win.C1TrueDBGrid.C1TrueDBGrid
		Friend WithEvents btnRefresh As System.Windows.Forms.Button
		Friend WithEvents lblRecNum1 As System.Windows.Forms.Label
		Friend WithEvents btnCopySelectedRows As System.Windows.Forms.Button
		Friend WithEvents btnCopyAll As System.Windows.Forms.Button
		Friend WithEvents btnUpdateKeyModels As System.Windows.Forms.Button
		Friend WithEvents btnInactive As System.Windows.Forms.Button
		<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
			Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMessActiveModels))
			Me.tdgModelCriteria = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
			Me.lblHeader = New System.Windows.Forms.Label()
			Me.btnActive = New System.Windows.Forms.Button()
			Me.btnRefresh = New System.Windows.Forms.Button()
			Me.lblRecNum1 = New System.Windows.Forms.Label()
			Me.btnCopySelectedRows = New System.Windows.Forms.Button()
			Me.btnCopyAll = New System.Windows.Forms.Button()
			Me.btnUpdateKeyModels = New System.Windows.Forms.Button()
			Me.btnInactive = New System.Windows.Forms.Button()
			CType(Me.tdgModelCriteria, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'tdgModelCriteria
			'
			Me.tdgModelCriteria.AllowUpdate = False
			Me.tdgModelCriteria.AlternatingRows = True
			Me.tdgModelCriteria.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
						Or System.Windows.Forms.AnchorStyles.Left)
			Me.tdgModelCriteria.FilterBar = True
			Me.tdgModelCriteria.GroupByCaption = "Drag a column header here to group by that column"
			Me.tdgModelCriteria.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
			Me.tdgModelCriteria.Location = New System.Drawing.Point(8, 40)
			Me.tdgModelCriteria.Name = "tdgModelCriteria"
			Me.tdgModelCriteria.PreviewInfo.Location = New System.Drawing.Point(0, 0)
			Me.tdgModelCriteria.PreviewInfo.Size = New System.Drawing.Size(0, 0)
			Me.tdgModelCriteria.PreviewInfo.ZoomFactor = 75
			Me.tdgModelCriteria.Size = New System.Drawing.Size(640, 512)
			Me.tdgModelCriteria.TabIndex = 5
			Me.tdgModelCriteria.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
			"r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
			"r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
			"}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{BackColor:Lavender;}S" & _
			"tyle13{}Style12{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Recor" & _
			"dSelector{AlignImage:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:Inacti" & _
			"veCaptionText;BackColor:InactiveCaption;}EvenRow{BackColor:AntiqueWhite;}Heading" & _
			"{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;Ali" & _
			"gnVert:Center;}FilterBar{Font:Microsoft Sans Serif, 9.75pt, style=Bold;ForeColor" & _
			":Red;BackColor:White;}Style4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Bor" & _
			"der:None,,0, 0, 0, 0;BackColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Styl" & _
			"e2{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" AlternatingRo" & _
			"wStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17" & _
			""" FilterBar=""True"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefR" & _
			"ecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>508</H" & _
			"eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
			"me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
			"t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
			"yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
			"HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
			"ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
			"tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
			"""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 636, 508</Clie" & _
			"ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
			"eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
			"rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
			"=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
			"""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
			"mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
			"rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
			"""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
			"rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
			"cSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 636, 508</ClientArea><PrintPa" & _
			"geHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent="""" me=""Style" & _
			"21"" /></Blob>"
			'
			'lblHeader
			'
			Me.lblHeader.Dock = System.Windows.Forms.DockStyle.Top
			Me.lblHeader.ForeColor = System.Drawing.Color.DimGray
			Me.lblHeader.Name = "lblHeader"
			Me.lblHeader.Size = New System.Drawing.Size(792, 16)
			Me.lblHeader.TabIndex = 6
			Me.lblHeader.Text = "Label1"
			'
			'btnActive
			'
			Me.btnActive.BackColor = System.Drawing.Color.Green
			Me.btnActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnActive.ForeColor = System.Drawing.Color.MediumBlue
			Me.btnActive.Location = New System.Drawing.Point(656, 152)
			Me.btnActive.Name = "btnActive"
			Me.btnActive.Size = New System.Drawing.Size(128, 64)
			Me.btnActive.TabIndex = 7
			Me.btnActive.Text = "Active"
			'
			'btnRefresh
			'
			Me.btnRefresh.Location = New System.Drawing.Point(656, 40)
			Me.btnRefresh.Name = "btnRefresh"
			Me.btnRefresh.Size = New System.Drawing.Size(128, 40)
			Me.btnRefresh.TabIndex = 8
			Me.btnRefresh.Text = "Refresh"
			'
			'lblRecNum1
			'
			Me.lblRecNum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.lblRecNum1.ForeColor = System.Drawing.Color.DarkBlue
			Me.lblRecNum1.Location = New System.Drawing.Point(8, 24)
			Me.lblRecNum1.Name = "lblRecNum1"
			Me.lblRecNum1.Size = New System.Drawing.Size(272, 24)
			Me.lblRecNum1.TabIndex = 9
			Me.lblRecNum1.Text = "Messaging Models: 0"
			'
			'btnCopySelectedRows
			'
			Me.btnCopySelectedRows.BackColor = System.Drawing.Color.SteelBlue
			Me.btnCopySelectedRows.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCopySelectedRows.ForeColor = System.Drawing.Color.Cyan
			Me.btnCopySelectedRows.Location = New System.Drawing.Point(512, 16)
			Me.btnCopySelectedRows.Name = "btnCopySelectedRows"
			Me.btnCopySelectedRows.Size = New System.Drawing.Size(136, 23)
			Me.btnCopySelectedRows.TabIndex = 32
			Me.btnCopySelectedRows.Text = "Copy Selected Row(s)"
			'
			'btnCopyAll
			'
			Me.btnCopyAll.BackColor = System.Drawing.Color.SteelBlue
			Me.btnCopyAll.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnCopyAll.ForeColor = System.Drawing.Color.Cyan
			Me.btnCopyAll.Location = New System.Drawing.Point(416, 16)
			Me.btnCopyAll.Name = "btnCopyAll"
			Me.btnCopyAll.Size = New System.Drawing.Size(88, 23)
			Me.btnCopyAll.TabIndex = 31
			Me.btnCopyAll.Text = "Copy All Rows"
			'
			'btnUpdateKeyModels
			'
			Me.btnUpdateKeyModels.Location = New System.Drawing.Point(656, 88)
			Me.btnUpdateKeyModels.Name = "btnUpdateKeyModels"
			Me.btnUpdateKeyModels.Size = New System.Drawing.Size(128, 40)
			Me.btnUpdateKeyModels.TabIndex = 33
			Me.btnUpdateKeyModels.Text = "Update Key Models"
			'
			'btnInactive
			'
			Me.btnInactive.BackColor = System.Drawing.Color.Green
			Me.btnInactive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.btnInactive.ForeColor = System.Drawing.Color.OrangeRed
			Me.btnInactive.Location = New System.Drawing.Point(656, 224)
			Me.btnInactive.Name = "btnInactive"
			Me.btnInactive.Size = New System.Drawing.Size(128, 64)
			Me.btnInactive.TabIndex = 34
			Me.btnInactive.Text = "Inactive"
			'
			'frmMessActiveModels
			'
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.BackColor = System.Drawing.Color.Silver
			Me.ClientSize = New System.Drawing.Size(792, 566)
			Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnInactive, Me.btnUpdateKeyModels, Me.btnCopySelectedRows, Me.btnCopyAll, Me.tdgModelCriteria, Me.lblRecNum1, Me.btnRefresh, Me.btnActive, Me.lblHeader})
			Me.Name = "frmMessActiveModels"
			Me.Text = "frmMessActiveModels"
			CType(Me.tdgModelCriteria, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

#End Region
#Region "DECLARATIONS"
        Private _strCust_IDs As String = PSS.Data.Buisness.Messaging.strMessCust_IDs    '  "14,444,2563,2507,2508"
		Private _iProd_ID As Integer = 1
		Private _strLoc_IDs As String = ""
		Private _iUserID As Integer = PSS.Core.ApplicationUser.IDuser
		Private intInputBoxCancel As Integer
#End Region
#Region "FORM EVENTS"
		Private Sub frmMessActiveModels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			Dim dt As DataTable
			Dim objMessaging As New PSS.Data.Buisness.Messaging()
			Dim row As DataRow
            Dim strHeader As String = ""
            Dim uniqCustomers As New ArrayList()
            Dim i As Integer = 0

			intInputBoxCancel = Data.BaseClasses.StringFunctions.StrPtr(String.Empty)
			Try
				Me.Enabled = False
				Cursor.Current = Cursors.WaitCursor
                Me.tdgModelCriteria.FetchRowStyles = True     'for fetchrowevent to fire

                Me._strCust_IDs &= "," & PSS.Data.Buisness.SkyTel.CriticalAlert_CUSTOMER_ID
                dt = objMessaging.GetMessCustomers(Me._strCust_IDs)
                For Each row In dt.Rows
                    If Not uniqCustomers.Contains(row("Customer").ToString) Then
                        uniqCustomers.Add(row("Customer").ToString)
                    End If
                    If i = 0 Then
                        Me._strLoc_IDs = row("Loc_ID")
                    Else
                        Me._strLoc_IDs &= "," & row("Loc_ID")
                    End If
                    i += 1
                Next
                For i = 0 To uniqCustomers.Count - 1
                    If strHeader.Trim.Length = 0 Then
                        strHeader = "Messaging Customers: " & uniqCustomers(i)
                    Else
                        strHeader &= ", " & uniqCustomers(i)
                    End If
                Next

                Me.lblHeader.Text = strHeader
                AddNewModelAsNeeded()
                RefreshMasterData()
            Catch ex As Exception
				MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
				Generic.DisposeDT(dt)
				objMessaging = Nothing
			End Try
		End Sub
#End Region
#Region "CONTROL EVENTS"
		Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
			Try
				RefreshMasterData()
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "btnRefresh_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub btnCopyAll_btnCopySelectedRows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyAll.Click, btnCopySelectedRows.Click
			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
				If sender.name = "btnCopyAll" Then
					Misc.CopyAllData(Me.tdgModelCriteria)
				ElseIf sender.name = "btnCopySelectedRows" Then
					Misc.CopySelectedRowsData(Me.tdgModelCriteria)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "CopyData", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
			End Try
		End Sub
		Private Sub btnUpdateKeyModels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateKeyModels.Click
			Dim strMsg As String = "Do you want to update key models (models processed in the past)? It may take few minutes to update!"
			Dim dt As DataTable
			Dim objMessaging As New PSS.Data.Buisness.Messaging()
			Dim row As DataRow
			Dim i As Integer = 0

			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

				If MessageBox.Show(strMsg, "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
					dt = objMessaging.GetMessUsedModels(Me._strLoc_IDs)
					For Each row In dt.Rows
						i = objMessaging.UpdateMessKeyModel(Me._iProd_ID, row("Model_ID"), 1)
					Next
					RefreshMasterData()
				End If

			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "btnUpdateKeyModels_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
				Generic.DisposeDT(dt)
				objMessaging = Nothing
			End Try
		End Sub
		Private Sub btnActive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActive.Click
			Dim dt As DataTable
			Dim objMessaging As New PSS.Data.Buisness.Messaging()
			Dim row As DataRow
			Dim iRow As Integer
			Dim iMrs_ID As Integer = 0
			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
				If Me.tdgModelCriteria.SelectedRows.Count > 0 Then
					For Each iRow In Me.tdgModelCriteria.SelectedRows
						iMrs_ID = CInt(Me.tdgModelCriteria.Columns("Mrs_ID").CellText(iRow))
						objMessaging.UpdateMesActiveInactiveModel(iMrs_ID, 0)
					Next
					RefreshMasterData()
				Else
					MessageBox.Show("Please select a row or rows in the model list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "btnUpdateKeyModels_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
				Generic.DisposeDT(dt)
				objMessaging = Nothing
			End Try
		End Sub
		Private Sub btnInactive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInactive.Click
			Dim dt As DataTable
			Dim objMessaging As New PSS.Data.Buisness.Messaging()
			Dim row As DataRow
			Dim iRow As Integer
			Dim iMrs_ID As Integer = 0

			Try
				Me.Enabled = False : Cursor.Current = Cursors.WaitCursor

				If Me.tdgModelCriteria.SelectedRows.Count > 0 Then
					For Each iRow In Me.tdgModelCriteria.SelectedRows
						iMrs_ID = CInt(Me.tdgModelCriteria.Columns("Mrs_ID").CellText(iRow))
						objMessaging.UpdateMesActiveInactiveModel(iMrs_ID, 1)
					Next
					RefreshMasterData()
				Else
					MessageBox.Show("Please select a row or rows in the model list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
				End If

			Catch ex As Exception
				MessageBox.Show(ex.ToString(), "btnUpdateKeyModels_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Me.Enabled = True : Cursor.Current = Cursors.Default
				Generic.DisposeDT(dt)
				objMessaging = Nothing
			End Try
		End Sub
		Private Sub tdgModelCriteria_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdgModelCriteria.FetchRowStyle
			'Dim strActive As String
			'Try
			'    strActive = Me.tdgModelCriteria.Columns("Active").CellText(e.Row).ToString
			'    Select Case strActive.Trim.ToUpper
			'        Case "Yes".ToUpper
			'            e.CellStyle.ForeColor = Color.MediumBlue
			'            Me.tdgModelCriteria.Columns("Active").c()
			'        Case "No".ToUpper
			'            e.CellStyle.ForeColor = Color.Black
			'            'Case Else
			'            '       e.CellStyle.BackColor = Color.Pink
			'    End Select

			'Catch ex As Exception
			'    MessageBox.Show(ex.ToString, "Sub tdgData1_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
			'End Try
		End Sub
		Private Sub tdgModelCriteria_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdgModelCriteria.FetchCellStyle
			Dim strActive As String
			' Dim v
			Try
				strActive = Me.tdgModelCriteria.Columns("Active").CellText(e.Row).ToString
				Select Case strActive.Trim.ToUpper
					Case "Yes".ToUpper
						e.CellStyle.ForeColor = Color.MediumBlue
						'v = Me.tdgModelCriteria.Item(e.Row, e.Col - 1)
						'e.CellStyle.ForeColor = Color.MediumBlue
					Case Else					  '"No".ToUpper
						e.CellStyle.ForeColor = Color.OrangeRed
						'v = Me.tdgModelCriteria.Item(e.Row, e.Col - 1)
						'e.CellStyle.ForeColor = Color.Black
						'Case Else
						'       e.CellStyle.BackColor = Color.Pink
				End Select

				'Dim N As Integer
				' N = Val(Me.C1TrueDBGrid1(e.Row, e.Col))
				'If N > 1000 Then
				'    e.CellStyle.ForeColor = System.Drawing.Color.Blue
				'End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "Sub tdgData1_FetchRowStyle", MessageBoxButtons.OK, MessageBoxIcon.Error)
			End Try
		End Sub
		Private Sub tdgModelCriteria_AfterFilter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgModelCriteria.AfterFilter
			Me.lblRecNum1.Text = "Messaging Models: " & Me.tdgModelCriteria.RowCount
		End Sub
		Private Sub tdgModelCriteria_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles tdgModelCriteria.AfterSort
			Me.lblRecNum1.Text = "Messaging Models: " & Me.tdgModelCriteria.RowCount
		End Sub
		Private Sub tdgModelCriteria_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdgModelCriteria.ButtonClick
			EditModel(tdgModelCriteria.Row)
		End Sub
#End Region
#Region "METHODS"
		Private Sub AddNewModelAsNeeded()
			Dim dt1, dt2 As DataTable
			Dim objMessaging As New PSS.Data.Buisness.Messaging()
			Dim row1, row2 As DataRow
			Dim i As Integer = 0
			Dim strDateTime = Format(Now, "yyyy-MM-dd HH:mm:ss")
			Dim arrlstIDs As New ArrayList()
			Try
				dt1 = objMessaging.GetMessModelActiveInactiveData(Me._iProd_ID)				' from tmodel_rec_status 
				dt2 = objMessaging.GetMessModelData(Me._iProd_ID)				'from tmodels
				If dt1.Rows.Count = 0 Then				' add all to tmodel_rec_status 
					For Each row2 In dt2.Rows
						i = objMessaging.AddMessNewProdModel(Me._iProd_ID, row2("Model_ID"), 0, 0, Me._iUserID, strDateTime)
					Next
				Else				' add only new to tmodel_rec_status 
					For Each row1 In dt1.Rows
						arrlstIDs.Add(row1("model_ID"))
					Next
					For Each row2 In dt2.Rows
						If Not arrlstIDs.Contains(row2("model_ID")) Then						 'find new
							i = objMessaging.AddMessNewProdModel(Me._iProd_ID, row2("Model_ID"), 0, 0, Me._iUserID, strDateTime)
						End If
					Next
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "AddNewModelAsNeeded", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Generic.DisposeDT(dt1) : Generic.DisposeDT(dt2)
				objMessaging = Nothing
			End Try
		End Sub
		Private Sub RefreshMasterData()
			Dim dt As DataTable
			Dim objMessaging As New PSS.Data.Buisness.Messaging()
			Dim row As DataRow
			Dim i As Integer = 0
			Try
				Me.tdgModelCriteria.DataSource = Nothing
				dt = objMessaging.GetMessModelActiveInactiveData(Me._iProd_ID)
				If dt.Rows.Count > 0 Then
					With Me.tdgModelCriteria
						.DataSource = dt.DefaultView
						For i = 0 To .Columns.Count - 1
							.Splits(0).DisplayColumns("Active").FetchStyle = True							'for fetchcellevent to fire
							.Splits(0).DisplayColumns(i).AutoSize()
							.Splits(0).DisplayColumns("Active").Width = 100
							.Splits(0).DisplayColumns("Active").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
							.Splits(0).DisplayColumns("Active").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
							.Splits(0).DisplayColumns("Key Model").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
							.Splits(0).DisplayColumns("Key Model").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
							.Splits(0).DisplayColumns("Equip Type").Width = 70
							.Splits(0).DisplayColumns("Equip Type").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
							.Splits(0).DisplayColumns("Equip Type").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
							.Splits(0).DisplayColumns("Active").HeadingStyle.ForeColor = Color.MediumBlue
							.Splits(0).DisplayColumns("Model").HeadingStyle.ForeColor = Color.Black
							.Splits(0).DisplayColumns("Model").Style.ForeColor = Color.Black
							.Splits(0).DisplayColumns("Key Model").Style.ForeColor = Color.DimGray
							.Splits(0).DisplayColumns("User").Style.ForeColor = Color.DarkGray
							.Splits(0).DisplayColumns("Rec_Date").Style.ForeColor = Color.DarkGray
							.Splits(0).DisplayColumns("Product").Style.ForeColor = Color.DarkGray
							If i > 6 Then .Splits(0).DisplayColumns(i).Visible = False
						Next
					End With
					Me.lblRecNum1.Text = "Messaging Models: " & dt.Rows.Count
					AddUnboundColumn()
				End If
			Catch ex As Exception
				MessageBox.Show(ex.ToString, "RefreshMasterData", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				Generic.DisposeDT(dt)
				objMessaging = Nothing
			End Try
		End Sub
		Private Sub AddUnboundColumn()
			Dim Col As New C1.Win.C1TrueDBGrid.C1DataColumn()
			Dim dc As C1.Win.C1TrueDBGrid.C1DisplayColumn
			With Me.tdgModelCriteria
				.Columns.Insert(0, Col)
				Col.Caption = "Edit E.T."
				dc = .Splits(0).DisplayColumns.Item("Edit E.T.")
				dc.ButtonText = True
				dc.ButtonAlways = True
				dc.Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				dc.HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
				dc.AllowSizing = False
				dc.Width = 50
				.Splits(0).DisplayColumns.RemoveAt(.Splits(0).DisplayColumns.IndexOf(dc))
				.Splits(0).DisplayColumns.Insert(0, dc)
				dc.Visible = True
				.Rebind(True)
			End With
		End Sub
		Private Sub EditModel(ByVal row As Integer)
			Dim _msg As String = ""
			Dim _curVal As String = ""
			Dim _val As String = ""
			Dim _mrs_id As Integer = 0
			_curVal = tdgModelCriteria(tdgModelCriteria.Row, 4).ToString()
			_mrs_id = tdgModelCriteria(tdgModelCriteria.Row, 13)
			_val = InputBox("Please enter the equipment type for this model." & vbCrLf & vbCrLf & "To clear an existing entry click the OK button with no value entered.", Me.Text, _curVal)
			If _val.Length > 5 Then
				MessageBox.Show("The maximum length is 5 characters.  Please check the value and try again.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Exit Sub
			End If
			If Data.BaseClasses.StringFunctions.StrPtr(_val) <> intInputBoxCancel Then
				SetModelEquipType(_mrs_id, _val)
				If _val = "" Then
					_msg = "The equipment type for model " & tdgModelCriteria(tdgModelCriteria.Row, 1).ToString & " has been cleared."
				Else
					_msg = "The equipment type for model " & tdgModelCriteria(tdgModelCriteria.Row, 1).ToString & " has been set to " & _val & "."
				End If
				RefreshMasterData()
				MessageBox.Show(_msg, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
			End If
		End Sub
		Private Sub SetModelEquipType(ByVal mrs_id As String, ByVal value As String)
			Dim _mrs As New Data.BOL.tmodel_rec_status(mrs_id)
			If _mrs.mrs_id > 0 Then
				_mrs.equip_type = value
				_mrs.ApplyChanges()
			End If
		End Sub
#End Region
	End Class
End Namespace
