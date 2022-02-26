Option Explicit On 

Imports PSS.Data.Buisness
Imports PSS.Core.Global

Public Class frmHTCProdTracking
    Inherits System.Windows.Forms.Form

    Private _objHTC As HTC
    Private _Timer As Timer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New HTC()
        _Timer = New Timer()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objHTC = Nothing
            If Not IsNothing(_Timer) Then
                Me._Timer.Enabled = False
                Me._Timer.Dispose()
                Me._Timer = Nothing
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpWorkDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboStations As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboGroups As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDailyGoal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRefreshData As System.Windows.Forms.Button
    Friend WithEvents btnCopyData As System.Windows.Forms.Button
    Friend WithEvents dbgridTrackingData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTCProdTracking))
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
        Me.dbgridTrackingData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.dbgridTrackingData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.lblTitle.TabIndex = 102
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
        Me.Panel1.Size = New System.Drawing.Size(655, 64)
        Me.Panel1.TabIndex = 103
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
        Me.dbgridTrackingData.Location = New System.Drawing.Point(1, 72)
        Me.dbgridTrackingData.Name = "dbgridTrackingData"
        Me.dbgridTrackingData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgridTrackingData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgridTrackingData.PreviewInfo.ZoomFactor = 75
        Me.dbgridTrackingData.RowHeight = 20
        Me.dbgridTrackingData.Size = New System.Drawing.Size(839, 176)
        Me.dbgridTrackingData.TabIndex = 104
        Me.dbgridTrackingData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Arial, 6.75pt, style" & _
        "=Bold;ForeColor:White;BackColor:SteelBlue;}Selected{ForeColor:Black;BackColor:Wh" & _
        "ite;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}F" & _
        "ilterBar{Font:Arial, 8.25pt, style=Bold;BackColor:White;}Footer{Font:Microsoft S" & _
        "ans Serif, 15.75pt, style=Bold;ForeColor:Lime;BackColor:Black;}Caption{AlignHorz" & _
        ":Center;}Style9{}Normal{Font:Arial, 9pt, style=Bold;BackColor:SteelBlue;AlignVer" & _
        "t:Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}Odd" & _
        "Row{Font:Arial, 6.75pt, style=Bold;ForeColor:White;BackColor:SlateGray;}RecordSe" & _
        "lector{AlignImage:Center;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Serif, " & _
        "6.75pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, 1, 1;" & _
        "ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}Style1" & _
        "4{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGr" & _
        "id.MergeView Name="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaption" & _
        "Height=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBor" & _
        "der"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizo" & _
        "ntalScrollGroup=""1""><Height>172</Height><CaptionStyle parent=""Style2"" me=""Style1" & _
        "0"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" m" & _
        "e=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle pare" & _
        "nt=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyl" & _
        "e parent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""St" & _
        "yle7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddR" & _
        "ow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><S" & _
        "electedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" " & _
        "/><ClientRect>0, 0, 835, 172</ClientRect><BorderSide>0</BorderSide><BorderStyle>" & _
        "Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style" & _
        " parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""He" & _
        "ading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Headi" & _
        "ng"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal" & _
        """ me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal" & _
        """ me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me" & _
        "=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Capti" & _
        "on"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSpli" & _
        "ts><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0" & _
        ", 0, 835, 172</ClientArea><PrintPageHeaderStyle parent="""" me=""Style16"" /><PrintP" & _
        "ageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'frmHTCProdTracking
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(848, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dbgridTrackingData, Me.Panel1, Me.lblTitle})
        Me.Name = "frmHTCProdTracking"
        Me.Text = "HTC Productivity Tracking"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dbgridTrackingData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmHTCProdTracking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            'dt = Me._objHTC.GetHTCGroups(True)
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
            dt = Me._objHTC.GetProdStation(True)
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

            Select Case Me.cboStations.SelectedValue
                Case 2, 3, 4, 5, 6 'RF
                    Me.PopulateTestData()
                    'Case 3  'Final
                    '    Me.PopulateFinalData()
                    'Case 4  'OOBA
                    '    Me.PopulateOOBAData()
                    'Case 5  'Diagnostic
                    '    Me.PopulateDiagnosticData()
                    'Case 6  'PIA
                    '    Me.PopulatePIAData()
                Case 7  'Repair/Refurbish
                    Me.PopulateRefurbishData()
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "LoadTrackingData", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Application.DoEvents()
            Me.Enabled = True
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateTestData()
        Dim iGroupTarget As Integer = 0
        Dim dt As DataTable
        Dim i As Integer = 0

        Try
            If Me.txtDailyGoal.Text.Trim.Length > 0 Then iGroupTarget = CInt(Me.txtDailyGoal.Text)
            dt = Me._objHTC.GetProdTrackingTestData(Format(Me.dtpWorkDate.Value, "yyyy-MM-dd"), Me.cboGroups.SelectedValue, Me.cboStations.SelectedValue, iGroupTarget)

            With Me.dbgridTrackingData
                .DataSource = dt.DefaultView
                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    If i > 2 Then .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    If i >= 5 Then .Splits(0).DisplayColumns(i).Width = 100
                Next i

                .Columns("Date").NumberFormat = "MM/dd/yyyy hh:mm tt"

                .Splits(0).DisplayColumns("Pass").Width = 70
                .Splits(0).DisplayColumns("Fail").Width = 70

                .Splits(0).DisplayColumns("TD_UsrID").Visible = False
            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateRefurbishData()
        Dim iGroupTarget As Integer = 0
        Dim i As Integer = 0
        Dim dt As DataTable
        Dim col As C1.Win.C1TrueDBGrid.C1DataColumn
        Dim drNewRow As DataRow

        Try
            dt = Me._objHTC.GetProdTrackingRefurbishedData(Format(Me.dtpWorkDate.Value, "yyyy-MM-dd"), Me.cboGroups.SelectedValue, Me.cboStations.SelectedValue, iGroupTarget)

            '********************************
            'ADD GRAND TOTAL ROW
            If dt.Rows.Count > 0 Then
                drNewRow = dt.NewRow
                drNewRow("TD_UsrID") = 0
                drNewRow("Tech") = ""
                drNewRow("Completed Date") = "TOTAL"
                drNewRow("Refurb Complete") = dt.Compute("Sum([Refurb Complete])", "").ToString
                drNewRow("Refurb Rework") = dt.Compute("Sum([Refurb Rework])", "").ToString
                drNewRow("PIA Pass") = dt.Compute("Sum([PIA Pass])", "").ToString
                drNewRow("PIA Fail") = dt.Compute("Sum([PIA Fail])", "").ToString
                drNewRow("RF Pass") = dt.Compute("Sum([RF Pass])", "").ToString
                drNewRow("RF Fail") = dt.Compute("Sum([RF Fail])", "").ToString
                drNewRow("Final Pass") = dt.Compute("Sum([Final Pass])", "").ToString
                drNewRow("Final Fail") = dt.Compute("Sum([Final Fail])", "").ToString
                drNewRow("OOBA Pass") = dt.Compute("Sum([OOBA Pass])", "").ToString
                drNewRow("OOBA Fail") = dt.Compute("Sum([OOBA Fail])", "").ToString
                dt.Rows.Add(drNewRow)
                dt.AcceptChanges()
            End If
            '********************************

            With Me.dbgridTrackingData
                .DataSource = dt.DefaultView

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    If i > 2 Then .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    If i >= 5 Then .Splits(0).DisplayColumns(i).Width = 60
                Next i

                .Columns("Completed Date").NumberFormat = "MM/dd/yyyy hh:mm tt"

                .Splits(0).DisplayColumns("OOBA Pass").Width = 70
                .Splits(0).DisplayColumns("OOBA Fail").Width = 70

                .Splits(0).DisplayColumns("TD_UsrID").Visible = False

                ''GRAND TOTAL
                'If Not IsNothing(dt) Then
                '    '  iGrandTotal = 
                '    .ColumnFooters = True
                '    .Columns("Completed Date").FooterText = "Total"

                '    'loop through each column
                '    For Each col In .Columns
                '        If col.Caption <> "Tech" And col.Caption <> "Completed Date" Then
                '            .Columns(col.Caption).FooterText = dt.Compute("Sum([" & col.Caption & "])", "").ToString
                '        End If
                '    Next col
                'End If
            End With
        Catch ex As Exception
            Throw ex
        Finally
            Generic.DisposeDT(dt)
            col = Nothing
            drNewRow = Nothing
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
