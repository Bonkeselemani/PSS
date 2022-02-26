Option Explicit On 

Imports PSS.Data.Production
Imports C1.Win.C1TrueDBGrid

Public Class frmCostCenterTimeTracking
    Inherits System.Windows.Forms.Form

    Private _objCCTT As CostCenterTimeTracking
    Private _iEENum As Integer = 0

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objCCTT = New CostCenterTimeTracking()
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
    Friend WithEvents txtEENumber As System.Windows.Forms.TextBox
    Friend WithEvents lblEENumber As System.Windows.Forms.Label
    Friend WithEvents cboCostCenter As System.Windows.Forms.ComboBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboGroups As System.Windows.Forms.ComboBox
    Friend WithEvents dbgEEInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnDiscrepancyRpt As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpPayPeriod As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPayPeriod As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCostCenterTimeTracking))
        Me.txtEENumber = New System.Windows.Forms.TextBox()
        Me.lblEENumber = New System.Windows.Forms.Label()
        Me.cboCostCenter = New System.Windows.Forms.ComboBox()
        Me.lblCostCenter = New System.Windows.Forms.Label()
        Me.dbgEEInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnGo = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboGroups = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblPayPeriod = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpPayPeriod = New System.Windows.Forms.DateTimePicker()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnDiscrepancyRpt = New System.Windows.Forms.Button()
        CType(Me.dbgEEInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtEENumber
        '
        Me.txtEENumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEENumber.Location = New System.Drawing.Point(616, 16)
        Me.txtEENumber.Name = "txtEENumber"
        Me.txtEENumber.Size = New System.Drawing.Size(64, 20)
        Me.txtEENumber.TabIndex = 2
        Me.txtEENumber.Text = ""
        '
        'lblEENumber
        '
        Me.lblEENumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEENumber.ForeColor = System.Drawing.Color.Black
        Me.lblEENumber.Location = New System.Drawing.Point(576, 18)
        Me.lblEENumber.Name = "lblEENumber"
        Me.lblEENumber.Size = New System.Drawing.Size(40, 16)
        Me.lblEENumber.TabIndex = 1
        Me.lblEENumber.Text = "EE #:"
        Me.lblEENumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCostCenter
        '
        Me.cboCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCostCenter.Location = New System.Drawing.Point(344, 32)
        Me.cboCostCenter.Name = "cboCostCenter"
        Me.cboCostCenter.Size = New System.Drawing.Size(216, 21)
        Me.cboCostCenter.TabIndex = 1
        '
        'lblCostCenter
        '
        Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
        Me.lblCostCenter.Location = New System.Drawing.Point(272, 33)
        Me.lblCostCenter.Name = "lblCostCenter"
        Me.lblCostCenter.Size = New System.Drawing.Size(72, 16)
        Me.lblCostCenter.TabIndex = 3
        Me.lblCostCenter.Text = "Cost Center:"
        Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dbgEEInfo
        '
        Me.dbgEEInfo.AllowColMove = False
        Me.dbgEEInfo.AllowUpdate = False
        Me.dbgEEInfo.CaptionHeight = 20
        Me.dbgEEInfo.FilterBar = True
        Me.dbgEEInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgEEInfo.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgEEInfo.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgEEInfo.Location = New System.Drawing.Point(8, 100)
        Me.dbgEEInfo.Name = "dbgEEInfo"
        Me.dbgEEInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgEEInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgEEInfo.PreviewInfo.ZoomFactor = 75
        Me.dbgEEInfo.RowHeight = 25
        Me.dbgEEInfo.Size = New System.Drawing.Size(768, 396)
        Me.dbgEEInfo.TabIndex = 4
        Me.dbgEEInfo.Text = "C1TrueDBGrid1"
        Me.dbgEEInfo.Visible = False
        Me.dbgEEInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:LightSteelBlue;" & _
        "}Selected{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColo" & _
        "r:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;}Footer" & _
        "{}Caption{AlignHorz:Center;BackColor:LightSteelBlue;}Style1{}Normal{Font:Microso" & _
        "ft Sans Serif, 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColo" & _
        "r:Highlight;}Style12{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage" & _
        ":Center;}Style13{}Heading{Wrap:True;AlignHorz:Center;BackColor:SteelBlue;Border:" & _
        "Raised,,1, 1, 1, 1;ForeColor:White;AlignVert:Center;}Style8{}Style10{AlignHorz:N" & _
        "ear;}Style11{}Style14{}Style15{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDB" & _
        "Grid.MergeView AllowColMove=""False"" Name="""" CaptionHeight=""17"" ColumnCaptionHeig" & _
        "ht=""17"" ColumnFooterHeight=""17"" FilterBar=""True"" MarqueeStyle=""DottedCellBorder""" & _
        " RecordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" Horizontal" & _
        "ScrollGroup=""1""><Height>392</Height><CaptionStyle parent=""Style2"" me=""Style10"" /" & _
        "><EditorStyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""S" & _
        "tyle8"" /><FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""" & _
        "Footer"" me=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle pa" & _
        "rent=""Heading"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7" & _
        """ /><InactiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" " & _
        "me=""Style9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><Selec" & _
        "tedStyle parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><C" & _
        "lientRect>0, 0, 764, 392</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunk" & _
        "en</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style par" & _
        "ent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Headin" & _
        "g"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" " & _
        "me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me" & _
        "=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me" & _
        "=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""Re" & _
        "cordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" " & _
        "me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><" & _
        "Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0," & _
        " 764, 392</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageF" & _
        "ooterStyle parent="""" me=""Style15"" /></Blob>"
        '
        'btnGo
        '
        Me.btnGo.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGo.ForeColor = System.Drawing.Color.White
        Me.btnGo.Location = New System.Drawing.Point(712, 14)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(40, 24)
        Me.btnGo.TabIndex = 3
        Me.btnGo.Text = "&Go"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(272, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Group:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboGroups
        '
        Me.cboGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGroups.Location = New System.Drawing.Point(344, 5)
        Me.cboGroups.Name = "cboGroups"
        Me.cboGroups.Size = New System.Drawing.Size(216, 21)
        Me.cboGroups.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblPayPeriod, Me.Label3, Me.Label2, Me.dtpPayPeriod, Me.lblEENumber, Me.cboGroups, Me.cboCostCenter, Me.txtEENumber, Me.lblCostCenter, Me.Label1, Me.btnGo})
        Me.Panel1.Location = New System.Drawing.Point(8, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(768, 60)
        Me.Panel1.TabIndex = 8
        '
        'lblPayPeriod
        '
        Me.lblPayPeriod.BackColor = System.Drawing.Color.White
        Me.lblPayPeriod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPayPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayPeriod.Location = New System.Drawing.Point(96, 33)
        Me.lblPayPeriod.Name = "lblPayPeriod"
        Me.lblPayPeriod.Size = New System.Drawing.Size(152, 18)
        Me.lblPayPeriod.TabIndex = 12
        Me.lblPayPeriod.Text = "10/20/08 To 10/26/08"
        Me.lblPayPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Week Period :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Date Select :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpPayPeriod
        '
        Me.dtpPayPeriod.CustomFormat = "MM/dd/yyyy"
        Me.dtpPayPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpPayPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPayPeriod.Location = New System.Drawing.Point(96, 6)
        Me.dtpPayPeriod.Name = "dtpPayPeriod"
        Me.dtpPayPeriod.Size = New System.Drawing.Size(152, 20)
        Me.dtpPayPeriod.TabIndex = 8
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDiscrepancyRpt})
        Me.Panel4.Location = New System.Drawing.Point(8, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(768, 36)
        Me.Panel4.TabIndex = 13
        '
        'btnDiscrepancyRpt
        '
        Me.btnDiscrepancyRpt.BackColor = System.Drawing.Color.Teal
        Me.btnDiscrepancyRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiscrepancyRpt.ForeColor = System.Drawing.Color.White
        Me.btnDiscrepancyRpt.Location = New System.Drawing.Point(0, 1)
        Me.btnDiscrepancyRpt.Name = "btnDiscrepancyRpt"
        Me.btnDiscrepancyRpt.Size = New System.Drawing.Size(120, 30)
        Me.btnDiscrepancyRpt.TabIndex = 1
        Me.btnDiscrepancyRpt.Text = "Discrepancy Rpt"
        '
        'frmCostCenterTimeTracking
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(784, 501)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel4, Me.Panel1, Me.dbgEEInfo})
        Me.Name = "frmCostCenterTimeTracking"
        Me.Text = "Cost Center Time Tracking"
        CType(Me.dbgEEInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub frmCostCenterTimeTracking_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.lblPayPeriod.Text = ""
            Me.dtpPayPeriod.Value = Now()
            LoadGroups()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "frmCostCenterTimeTracking_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadGroups()
        Dim objInventory As PSS.Data.Buisness.Inventory
        Dim dt As DataTable

        Try
            objInventory = New PSS.Data.Buisness.Inventory()
            dt = objInventory.GetGroups(1, , 1)

            With Me.cboGroups
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("Group").ToString
                .ValueMember = dt.Columns("Group_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            objInventory = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub cboGroups_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGroups.SelectionChangeCommitted
        Try
            If Not IsNothing(Me.cboCostCenter.DataSource) Then
                Me.cboCostCenter.DataSource = Nothing
                Me.cboCostCenter.Items.Clear()
                Me.cboCostCenter.Text = ""
            End If

            If Not IsNothing(Me.dbgEEInfo.DataSource) Then
                Me.dbgEEInfo.DataSource = Nothing
                Me.dbgEEInfo.Visible = False
            End If

            Me.txtEENumber.Text = ""

            If Me.cboGroups.SelectedValue > 0 Then
                LoadCostCenter()
                Me.cboCostCenter.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboGroups_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub LoadCostCenter()
        Dim dt As DataTable

        Try
            dt = Me._objCCTT.GetCCIDDesc(Me.cboGroups.SelectedValue, 1)

            With Me.cboCostCenter
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("cc_desc").ToString
                .ValueMember = dt.Columns("cc_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub cboCostCenter_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCostCenter.SelectionChangeCommitted
        Try
            Me.txtEENumber.Text = ""

            If Me.cboCostCenter.SelectedValue > 0 Then
                Me.txtEENumber.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboCostCenter_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub txtEENumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEENumber.KeyPress
        Try
            If Not (Char.IsNumber(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "txtEENumber_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click
        Try
            Me.PopulateTimeCardInfo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnGo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '******************************************************************
    Private Sub PopulateTimeCardInfo()
        Dim dt As DataTable
        Dim iEENum As Integer = 0
        Dim iCCID As Integer = 0
        Dim i As Integer = 0
        Dim col As C1DataColumn
        Dim decTotal As Decimal = 0.0

        Try
            If Me.txtEENumber.Text.Trim.Length > 0 Then
                iEENum = CInt(Me.txtEENumber.Text.Trim)
            End If
            If Me.cboGroups.SelectedValue > 0 Then
                If Me.cboCostCenter.Items.Count > 0 Then
                    iCCID = Me.cboCostCenter.SelectedValue
                End If
            End If

            dt = Me._objCCTT.GetTimeCardEEInfo(Format(Me.dtpPayPeriod.Value, "yyyy-MM-dd"), Me.cboGroups.SelectedValue, iCCID, iEENum)
            With Me.dbgEEInfo
                .DataSource = Nothing

                .DataSource = dt.DefaultView
                .Visible = True

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center
                Next i

                .Splits(0).DisplayColumns("Name").Width = 160
                .Splits(0).DisplayColumns("EE#").Width = 60
                .Splits(0).DisplayColumns("Department").Width = 150
                .Splits(0).DisplayColumns("Date Hours").Width = 100
                .Splits(0).DisplayColumns("Week Hours").Width = 100
                .Splits(0).DisplayColumns("Legiant Hours").Width = 150
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                For i = 0 To dt.Rows.Count - 1
                    If .Columns("EE#").Text.Trim = Me._iEENum Then
                        Exit For
                    Else
                        .MoveNext()
                    End If
                Next i

                .Splits(0).EvenRowStyle.BackColor = Color.White
                .Splits(0).OddRowStyle.BackColor = Color.White

                'Cals grand total
                If Not IsNothing(dt) Then
                    '  iGrandTotal = 
                    .ColumnFooters = True
                    .Columns("Department").FooterText = "Total"

                    'loop through each column
                    For Each col In .Columns
                        If col.Caption <> "Name" And col.Caption <> "EE#" And col.Caption <> "Department" Then
                            decTotal = 0.0
                            For i = 0 To dt.Rows.Count - 1
                                If dt.Rows(i)(col.Caption).ToString.Trim.Length > 0 And dt.Rows(i)(col.Caption).ToString.Trim <> "Miss Punch" Then decTotal += CDec(dt.Rows(i)(col.Caption))
                            Next i
                            .Columns(col.Caption).FooterText = decTotal
                        End If
                    Next col
                End If
            End With

            i -= 1
        Catch ex As Exception
            Throw ex
        Finally
            col = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '******************************************************************
    Private Sub dbgEEInfo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgEEInfo.DoubleClick
        Dim objFrmDBTCEdit As frmDashBoardTimeCardEdit

        Try
            Me._iEENum = CInt(sender.Columns("EE#").Text)
            objFrmDBTCEdit = New frmDashBoardTimeCardEdit(sender.Columns("EE#").Text.trim, sender.Columns("Name").Text.trim, Format(Me.dtpPayPeriod.Value, "yyyy-MM-dd"))
            objFrmDBTCEdit.ShowDialog()
            Me.PopulateTimeCardInfo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnGo_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not IsNothing(objFrmDBTCEdit) Then
                objFrmDBTCEdit.Dispose()
                objFrmDBTCEdit = Nothing
            End If
        End Try
    End Sub

    '******************************************************************
    Private Sub dtpPayPeriod_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpPayPeriod.Leave
        Dim dtimeStartWeek As Date
        Dim dtimeEndWeek As Date
        Try
            dtimeStartWeek = DateAdd(DateInterval.Day, (Weekday(Me.dtpPayPeriod.Value, FirstDayOfWeek.Monday) * -1) + 1, Me.dtpPayPeriod.Value)
            dtimeEndWeek = DateAdd(DateInterval.Day, 6 - Weekday(Me.dtpPayPeriod.Value, FirstDayOfWeek.Monday), Me.dtpPayPeriod.Value)
            Me.lblPayPeriod.Text = Format(dtimeStartWeek, "MM/dd/yyyy") & " To " & Format(dtimeEndWeek, "MM/dd/yyyy")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "dtpPayPeriod_Leave", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            dtimeStartWeek = Nothing
            dtimeEndWeek = Nothing
        End Try
    End Sub

    '******************************************************************
End Class
