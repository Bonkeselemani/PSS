Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.[Global]

Namespace Gui.Production
    Public Class frmWSProductivityTracker
        Inherits System.Windows.Forms.Form

        Private _Timer As Timer

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _Timer = New Timer()
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
        Friend WithEvents dbgridTrackingData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents btnCopyData As System.Windows.Forms.Button
        Friend WithEvents btnRefreshData As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents dtpWorkDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents cboStations As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboGroups As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtDailyGoal As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWSProductivityTracker))
            Me.dbgridTrackingData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.btnCopyData = New System.Windows.Forms.Button()
            Me.btnRefreshData = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.dtpWorkDate = New System.Windows.Forms.DateTimePicker()
            Me.cboStations = New PSS.Gui.Controls.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboGroups = New PSS.Gui.Controls.ComboBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtDailyGoal = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            CType(Me.dbgridTrackingData, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'dbgridTrackingData
            '
            Me.dbgridTrackingData.AllowUpdate = False
            Me.dbgridTrackingData.AllowUpdateOnBlur = False
            Me.dbgridTrackingData.AlternatingRows = True
            Me.dbgridTrackingData.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.dbgridTrackingData.BackColor = System.Drawing.Color.LightSteelBlue
            Me.dbgridTrackingData.CaptionHeight = 17
            Me.dbgridTrackingData.FilterBar = True
            Me.dbgridTrackingData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgridTrackingData.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgridTrackingData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgridTrackingData.Location = New System.Drawing.Point(1, 73)
            Me.dbgridTrackingData.Name = "dbgridTrackingData"
            Me.dbgridTrackingData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgridTrackingData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgridTrackingData.PreviewInfo.ZoomFactor = 75
            Me.dbgridTrackingData.RowHeight = 20
            Me.dbgridTrackingData.Size = New System.Drawing.Size(759, 192)
            Me.dbgridTrackingData.TabIndex = 107
            Me.dbgridTrackingData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Arial, 6.75pt, style" & _
            "=Bold;ForeColor:White;BackColor:SteelBlue;}Selected{ForeColor:Black;BackColor:Wh" & _
            "ite;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}F" & _
            "ilterBar{Font:Arial, 8.25pt, style=Bold;BackColor:White;}Footer{Font:Tahoma, 8.2" & _
            "5pt, style=Bold;AlignHorz:Far;ForeColor:White;BackColor:SteelBlue;}Caption{Align" & _
            "Horz:Center;}Style9{}Normal{Font:Arial, 9pt, style=Bold;BackColor:SteelBlue;Alig" & _
            "nVert:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{" & _
            "}OddRow{Font:Arial, 6.75pt, style=Bold;ForeColor:White;BackColor:SlateGray;}Reco" & _
            "rdSelector{AlignImage:Center;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Ser" & _
            "if, 6.75pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, 1" & _
            ", 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}St" & _
            "yle14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1True" & _
            "DBGrid.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCap" & _
            "tionHeight=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCel" & _
            "lBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Ho" & _
            "rizontalScrollGroup=""1""><Height>188</Height><CaptionStyle parent=""Style2"" me=""St" & _
            "yle10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRo" & _
            "w"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle " & _
            "parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><Heading" & _
            "Style parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me" & _
            "=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""" & _
            "OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" " & _
            "/><SelectedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Styl" & _
            "e1"" /><ClientRect>0, 0, 755, 188</ClientRect><BorderSide>0</BorderSide><BorderSt" & _
            "yle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><S" & _
            "tyle parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent" & _
            "=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""H" & _
            "eading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""No" & _
            "rmal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""No" & _
            "rmal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading" & _
            """ me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""C" & _
            "aption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horz" & _
            "Splits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientAr" & _
            "ea>0, 0, 755, 188</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><Pr" & _
            "intPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'lblTitle
            '
            Me.lblTitle.BackColor = System.Drawing.Color.Black
            Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
            Me.lblTitle.Location = New System.Drawing.Point(1, 1)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(183, 64)
            Me.lblTitle.TabIndex = 105
            Me.lblTitle.Text = "Productivity Tracking"
            Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel1
            '
            Me.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.Panel1.BackColor = System.Drawing.Color.Black
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCopyData, Me.btnRefreshData, Me.Label4, Me.dtpWorkDate, Me.cboStations, Me.Label2, Me.cboGroups, Me.Label3, Me.txtDailyGoal, Me.Label1})
            Me.Panel1.Location = New System.Drawing.Point(185, 1)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(575, 64)
            Me.Panel1.TabIndex = 106
            '
            'btnCopyData
            '
            Me.btnCopyData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCopyData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCopyData.ForeColor = System.Drawing.Color.White
            Me.btnCopyData.Location = New System.Drawing.Point(464, 32)
            Me.btnCopyData.Name = "btnCopyData"
            Me.btnCopyData.Size = New System.Drawing.Size(88, 24)
            Me.btnCopyData.TabIndex = 5
            Me.btnCopyData.Text = "Copy Data"
            '
            'btnRefreshData
            '
            Me.btnRefreshData.BackColor = System.Drawing.Color.SteelBlue
            Me.btnRefreshData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRefreshData.ForeColor = System.Drawing.Color.White
            Me.btnRefreshData.Location = New System.Drawing.Point(464, 2)
            Me.btnRefreshData.Name = "btnRefreshData"
            Me.btnRefreshData.Size = New System.Drawing.Size(88, 24)
            Me.btnRefreshData.TabIndex = 4
            Me.btnRefreshData.Text = "Refresh Data"
            '
            'Label4
            '
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.Lime
            Me.Label4.Location = New System.Drawing.Point(256, 9)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(80, 16)
            Me.Label4.TabIndex = 104
            Me.Label4.Text = "Work Date:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpWorkDate
            '
            Me.dtpWorkDate.CustomFormat = "yyyy-MM-dd"
            Me.dtpWorkDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dtpWorkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpWorkDate.Location = New System.Drawing.Point(336, 6)
            Me.dtpWorkDate.Name = "dtpWorkDate"
            Me.dtpWorkDate.Size = New System.Drawing.Size(104, 21)
            Me.dtpWorkDate.TabIndex = 2
            Me.dtpWorkDate.Value = New Date(2006, 1, 1, 0, 0, 0, 0)
            '
            'cboStations
            '
            Me.cboStations.AutoComplete = True
            Me.cboStations.BackColor = System.Drawing.SystemColors.Window
            Me.cboStations.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboStations.ForeColor = System.Drawing.Color.Black
            Me.cboStations.Location = New System.Drawing.Point(64, 33)
            Me.cboStations.Name = "cboStations"
            Me.cboStations.Size = New System.Drawing.Size(184, 21)
            Me.cboStations.TabIndex = 1
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Lime
            Me.Label2.Location = New System.Drawing.Point(0, 35)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(64, 16)
            Me.Label2.TabIndex = 103
            Me.Label2.Text = "Station:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboGroups
            '
            Me.cboGroups.AutoComplete = True
            Me.cboGroups.BackColor = System.Drawing.SystemColors.Window
            Me.cboGroups.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboGroups.ForeColor = System.Drawing.Color.Black
            Me.cboGroups.Location = New System.Drawing.Point(64, 6)
            Me.cboGroups.Name = "cboGroups"
            Me.cboGroups.Size = New System.Drawing.Size(184, 21)
            Me.cboGroups.TabIndex = 0
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.Lime
            Me.Label3.Location = New System.Drawing.Point(0, 8)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(64, 16)
            Me.Label3.TabIndex = 100
            Me.Label3.Text = "Group:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDailyGoal
            '
            Me.txtDailyGoal.Location = New System.Drawing.Point(336, 33)
            Me.txtDailyGoal.Name = "txtDailyGoal"
            Me.txtDailyGoal.Size = New System.Drawing.Size(55, 20)
            Me.txtDailyGoal.TabIndex = 3
            Me.txtDailyGoal.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Lime
            Me.Label1.Location = New System.Drawing.Point(256, 35)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 16)
            Me.Label1.TabIndex = 98
            Me.Label1.Text = "Daily Goal:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmWSProductivityTracker
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(784, 309)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgridTrackingData, Me.lblTitle, Me.Panel1})
            Me.Name = "frmWSProductivityTracker"
            Me.Text = "frmWSProductivityTracker"
            CType(Me.dbgridTrackingData, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '******************************************************************
        Private Sub frmWSProductivityTracker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.dtpWorkDate.Value = Now
                Me.LoadMasterGroups()
                Me.LoadProdStations()

                AddHandler _Timer.Tick, AddressOf TimerEventProcessor

                '''Sets the timer interval to 60 seconds.
                _Timer.Interval = 60000

            Catch ex As Exception
                Me._Timer.Stop()
                MessageBox.Show(ex.ToString, "frmHTCProdTracking_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub LoadMasterGroups()
            Dim dt As DataTable
            Dim objQC As New PSS.Data.Buisness.QC()

            Try
                dt = objQC.LoadGroups(1)
                With Me.cboGroups
                    .DataSource = Nothing
                    .DataSource = dt.DefaultView
                    .DisplayMember = dt.Columns("Group_Desc").ToString
                    .ValueMember = dt.Columns("Group_ID").ToString
                    If dt.Rows.Count = 2 Then .SelectedValue = dt.Rows(0)("Group_ID") Else .SelectedValue = 0
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub LoadProdStations()
            Dim dt As DataTable

            Try
                dt = Generic.GetTestTypesList(True)
                With Me.cboStations
                    .DataSource = dt.DefaultView
                    .DisplayMember = dt.Columns("Test_Desc2").ToString
                    .ValueMember = dt.Columns("Test_ID").ToString
                    .SelectedValue = 7
                End With

            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        '******************************************************************
        Private Sub TimerEventProcessor(ByVal myObject As Object, ByVal myEventArgs As EventArgs)
            Try
                Me._Timer.Stop()
                LoadTrackingData()
                Me._Timer.Start()
            Catch ex As Exception
                Me._Timer.Stop()
                MessageBox.Show(ex.ToString, "TimerEventProcessor", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub btnRefreshData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefreshData.Click
            Try
                Me._Timer.Stop()
                If Me.cboGroups.SelectedValue = 0 Then Exit Sub
                If Me.cboStations.SelectedValue = 0 Then Exit Sub
                LoadTrackingData()
                Me._Timer.Start()
            Catch ex As Exception
                Me._Timer.Stop()
                MessageBox.Show(ex.ToString, "btnRefreshData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************
        Private Sub LoadTrackingData()
            Try
                Me.dbgridTrackingData.ClearFields()
                Me.dbgridTrackingData.DataSource = Nothing

                If Me.cboGroups.SelectedValue = 0 Then Exit Sub
                If Me.cboStations.SelectedValue = 0 Then Exit Sub

                Me.Enabled = False
                Application.DoEvents()

                Me.PopulateTestData()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "LoadTrackingData", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Application.DoEvents()
                Me.Enabled = True
            End Try
        End Sub

        '******************************************************************
        Private Sub PopulateTestData()
            Dim objPT As clsProdTracker
            Dim iGroupTarget As Integer = 0
            Dim dt As DataTable
            Dim i As Integer = 0

            Try
                objPT = New clsProdTracker()

                If Me.txtDailyGoal.Text.Trim.Length > 0 Then iGroupTarget = CInt(Me.txtDailyGoal.Text)
                dt = objPT.GetProductivityNumber(Format(Me.dtpWorkDate.Value, "yyyy-MM-dd"), Me.cboGroups.SelectedValue, Me.cboStations.SelectedValue)

                With Me.dbgridTrackingData
                    .DataSource = dt.DefaultView
                    .ColumnFooters = True

                    For i = 0 To dt.Columns.Count - 1
                        .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                        If dt.Columns(i).Caption = "Inspector" Then
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                            .Splits(0).DisplayColumns(i).Width = 100
                            .Splits(0).DisplayColumns(i).Frozen = True
                        Else
                            .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
                        End If

                        If dt.Columns(i).Caption = "Total" Then .Splits(0).DisplayColumns(i).Width = 35

                        If dt.Columns(i).Caption = "Inspector" Then
                            .Columns(i).FooterText = "TOTAL"
                        Else
                            .Columns(i).FooterText = dt.Compute("Sum([" & dt.Columns(i).Caption & "])", "").ToString
                        End If
                    Next i
                End With
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt)
                objPT = Nothing
            End Try
        End Sub

        '******************************************************************
        Private Sub btnCopyData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopyData.Click
            Dim strData As String
            Dim iRow As Integer
            Dim booCompleteHeader As Boolean = False
            Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
            Dim strHeader As String = ""

            Try
                If Me.dbgridTrackingData.SelectedRows.Count > 0 And Me.dbgridTrackingData.SelectedCols.Count Then
                    Me._Timer.Stop()
                    Me.Enabled = False

                    'loop through each selected row
                    For Each iRow In Me.dbgridTrackingData.SelectedRows

                        'loop through each selected column
                        For Each col In Me.dbgridTrackingData.SelectedCols
                            'header
                            If booCompleteHeader = False Then
                                strHeader = strHeader & col.Caption & vbTab
                            End If
                            'data
                            strData = strData & col.CellText(iRow) & vbTab
                        Next col

                        'add new line to data
                        strData = strData & vbCrLf

                        'Stop collect header
                        booCompleteHeader = True
                    Next iRow

                    'combine header and data
                    strData = strHeader & vbCrLf & strData

                    'Copy Data to Clipboard
                    System.Windows.Forms.Clipboard.SetDataObject(strData, False)
                    Me._Timer.Start()
                    Me.Enabled = True
                Else
                    MessageBox.Show("Please select a range of cells to copy.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                Me._Timer.Stop()
                MessageBox.Show(ex.ToString, "btnCopyData_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
            End Try
        End Sub

        '******************************************************************
        Private Sub cboStations_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboStations.SelectionChangeCommitted
            Try
                Me._Timer.Stop()
                Me.dbgridTrackingData.DataSource = Nothing

                If Me.cboGroups.SelectedValue = 0 Then Exit Sub
                If Me.cboStations.SelectedValue = 0 Then Exit Sub
            Catch ex As Exception
                Me._Timer.Stop()
                MessageBox.Show(ex.ToString, "cboStations_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '******************************************************************

    End Class
End Namespace