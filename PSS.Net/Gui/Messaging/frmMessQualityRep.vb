Imports PSS.Data

Public Class frmMessQualityRep
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
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgFQASummary As System.Windows.Forms.DataGrid
    Friend WithEvents dgAQLSummary As System.Windows.Forms.DataGrid
    Friend WithEvents dgAQLDetail As System.Windows.Forms.DataGrid
    Friend WithEvents dgFQADetail As System.Windows.Forms.DataGrid
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbIncCntWrls As System.Windows.Forms.CheckBox
    Friend WithEvents btnExpand As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgFQASummary = New System.Windows.Forms.DataGrid()
        Me.dgAQLSummary = New System.Windows.Forms.DataGrid()
        Me.dgAQLDetail = New System.Windows.Forms.DataGrid()
        Me.dgFQADetail = New System.Windows.Forms.DataGrid()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbIncCntWrls = New System.Windows.Forms.CheckBox()
        Me.btnExpand = New System.Windows.Forms.Button()
        CType(Me.dgFQASummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAQLSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAQLDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFQADetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpStart
        '
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpStart.Location = New System.Drawing.Point(80, 8)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(112, 20)
        Me.dtpStart.TabIndex = 1
        '
        'dtpEnd
        '
        Me.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpEnd.Location = New System.Drawing.Point(264, 8)
        Me.dtpEnd.Name = "dtpEnd"
        Me.dtpEnd.Size = New System.Drawing.Size(112, 20)
        Me.dtpEnd.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(552, 5)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(72, 32)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        '
        'dgFQASummary
        '
        Me.dgFQASummary.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(218, Byte), CType(233, Byte), CType(254, Byte))
        Me.dgFQASummary.CaptionText = "FQA Summary"
        Me.dgFQASummary.DataMember = ""
        Me.dgFQASummary.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgFQASummary.Location = New System.Drawing.Point(3, 40)
        Me.dgFQASummary.Name = "dgFQASummary"
        Me.dgFQASummary.ReadOnly = True
        Me.dgFQASummary.Size = New System.Drawing.Size(392, 184)
        Me.dgFQASummary.TabIndex = 8
        '
        'dgAQLSummary
        '
        Me.dgAQLSummary.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(218, Byte), CType(233, Byte), CType(254, Byte))
        Me.dgAQLSummary.CaptionText = "AQL Summary"
        Me.dgAQLSummary.DataMember = ""
        Me.dgAQLSummary.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAQLSummary.Location = New System.Drawing.Point(395, 40)
        Me.dgAQLSummary.Name = "dgAQLSummary"
        Me.dgAQLSummary.ReadOnly = True
        Me.dgAQLSummary.Size = New System.Drawing.Size(392, 184)
        Me.dgAQLSummary.TabIndex = 9
        '
        'dgAQLDetail
        '
        Me.dgAQLDetail.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(218, Byte), CType(233, Byte), CType(254, Byte))
        Me.dgAQLDetail.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dgAQLDetail.CaptionText = "AQL Details"
        Me.dgAQLDetail.DataMember = ""
        Me.dgAQLDetail.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAQLDetail.Location = New System.Drawing.Point(395, 232)
        Me.dgAQLDetail.Name = "dgAQLDetail"
        Me.dgAQLDetail.ReadOnly = True
        Me.dgAQLDetail.Size = New System.Drawing.Size(392, 112)
        Me.dgAQLDetail.TabIndex = 11
        '
        'dgFQADetail
        '
        Me.dgFQADetail.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(218, Byte), CType(233, Byte), CType(254, Byte))
        Me.dgFQADetail.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left)
        Me.dgFQADetail.CaptionText = "FQA Details"
        Me.dgFQADetail.DataMember = ""
        Me.dgFQADetail.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgFQADetail.Location = New System.Drawing.Point(3, 232)
        Me.dgFQADetail.Name = "dgFQADetail"
        Me.dgFQADetail.ReadOnly = True
        Me.dgFQADetail.Size = New System.Drawing.Size(392, 112)
        Me.dgFQADetail.TabIndex = 10
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(712, 5)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(72, 32)
        Me.btnExcel.TabIndex = 7
        Me.btnExcel.Text = "Export to Excel"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Start Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(200, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 24)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "End Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cbIncCntWrls
        '
        Me.cbIncCntWrls.Location = New System.Drawing.Point(392, 8)
        Me.cbIncCntWrls.Name = "cbIncCntWrls"
        Me.cbIncCntWrls.Size = New System.Drawing.Size(152, 24)
        Me.cbIncCntWrls.TabIndex = 4
        Me.cbIncCntWrls.Text = "Include Contact Wireless"
        '
        'btnExpand
        '
        Me.btnExpand.Location = New System.Drawing.Point(632, 5)
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Size = New System.Drawing.Size(72, 32)
        Me.btnExpand.TabIndex = 6
        Me.btnExpand.Text = "Toggle View"
        '
        'frmMessQualityRep
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 350)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExpand, Me.cbIncCntWrls, Me.Label2, Me.Label1, Me.btnExcel, Me.dgFQADetail, Me.dgAQLDetail, Me.dgAQLSummary, Me.dgFQASummary, Me.btnSearch, Me.dtpEnd, Me.dtpStart})
        Me.Name = "frmMessQualityRep"
        Me.Text = "Messaging Quality Report"
        CType(Me.dgFQASummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAQLSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAQLDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgFQADetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "DECLARATIONS"

    Protected FQA As Buisness.QA = New Buisness.QA()
    Protected AQL As Buisness.QA = New Buisness.QA()
    Private _gridState As Integer = 1

#End Region
#Region "PAGE EVENTS"
    Private Sub Form_load(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
#End Region
#Region "CONTROL EVENTS"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.Cursor = Cursors.WaitCursor
        GetData(Me.dtpStart.Value, Me.dtpEnd.Value, Me.cbIncCntWrls.Checked)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim DS As DataSet = New DataSet()
        DS.Tables.Add(FQA.DetailDT.Copy)
        DS.Tables(0).TableName = "FQA Detail"
        DS.Tables.Add(AQL.DetailDT.Copy)
        DS.Tables(1).TableName = "AQL Detail"
        UpdateSNToChar(DS.Tables(0))
        UpdateSNToChar(DS.Tables(1))
        Dim objExcelRpt As New PSS.Data.ExcelReports()
        objExcelRpt.RunExcel_PerSheetPerTableWithOpen(DS, "MQReport")
    End Sub
    Private Sub btnExpand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpand.Click
        Select Case _gridState
            Case 1 ' Summary visible Detail Not.
                dgFQASummary.Visible = True
                dgAQLSummary.Visible = True
                dgFQADetail.Visible = False
                dgAQLDetail.Visible = False
                dgFQASummary.Height = Me.Height - 100
                dgAQLSummary.Height = Me.Height - 100
                _gridState = 2
            Case 2 ' Detail Visable Summary Not.
                dgFQASummary.Visible = False
                dgAQLSummary.Visible = False
                dgFQADetail.Visible = True
                dgAQLDetail.Visible = True
                dgFQADetail.Top = dgFQASummary.Top
                dgAQLDetail.Top = dgAQLSummary.Top
                dgFQADetail.Height = Me.Height - 100
                dgAQLDetail.Height = Me.Height - 100
                _gridState = 3
            Case Else ' Summary and Detail Visible.
                dgFQASummary.Height = 184
                dgAQLSummary.Height = 184
                dgFQADetail.Top = dgFQASummary.Top + dgFQASummary.Height + 8
                dgAQLDetail.Top = dgAQLSummary.Top + dgAQLSummary.Height + 8
                dgFQADetail.Height = Me.Height - 272
                dgAQLDetail.Height = Me.Height - 272
                dgFQASummary.Visible = True
                dgFQADetail.Visible = True
                dgAQLSummary.Visible = True
                dgAQLDetail.Visible = True
                Me.dgFQADetail.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left)
                Me.dgAQLDetail.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left)
                _gridState = 1
        End Select
    End Sub
#End Region
#Region "METHODS"
    Private Sub GetData(ByVal start_dt As DateTime, ByVal end_dt As DateTime, ByVal IncludeCntWrls As Boolean)
        Me.Cursor = Cursors.WaitCursor
        dgFQASummary.DataSource = Nothing
        dgAQLSummary.DataSource = Nothing
        dgFQADetail.DataSource = Nothing
        dgAQLDetail.DataSource = Nothing
        FQA = New Buisness.QA("Functional", start_dt, end_dt, IncludeCntWrls)
        AQL = New Buisness.QA("AQL", start_dt, end_dt, IncludeCntWrls)
        dgFQASummary.DataSource = FQA.SummaryDT
        dgAQLSummary.DataSource = AQL.SummaryDT
        dgFQADetail.DataSource = FQA.DetailDT
        dgAQLDetail.DataSource = AQL.DetailDT
        Me.Cursor = Cursors.Default
    End Sub

    Protected Sub UpdateSNToChar(ByVal DT As DataTable)
        Dim _dr As DataRow
        For Each _dr In DT.Rows
            _dr.Item("S/N") = "'" + _dr.Item("S/N")
            _dr.AcceptChanges()
        Next _dr
    End Sub

#End Region
End Class

