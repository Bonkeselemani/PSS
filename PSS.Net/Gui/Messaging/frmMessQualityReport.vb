Option Explicit On 
Imports PSS.Data
Imports PSS.Core
Imports PSSBase


Public Class frmMessQualityReport
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgFQLDetails As System.Windows.Forms.DataGrid
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents dtpStart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEnd As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgAQLDetails As System.Windows.Forms.DataGrid
    Friend WithEvents dgFQLSummary As System.Windows.Forms.DataGrid
    Friend WithEvents dgAQLSummary As System.Windows.Forms.DataGrid
    Friend WithEvents btnViewFQLDetails As System.Windows.Forms.Button
    Friend WithEvents btnViewAQLDetails As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.dgFQLSummary = New System.Windows.Forms.DataGrid()
        Me.dgAQLSummary = New System.Windows.Forms.DataGrid()
        Me.dgFQLDetails = New System.Windows.Forms.DataGrid()
        Me.dgAQLDetails = New System.Windows.Forms.DataGrid()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnViewFQLDetails = New System.Windows.Forms.Button()
        Me.btnViewAQLDetails = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpEnd = New System.Windows.Forms.DateTimePicker()
        Me.btnExcel = New System.Windows.Forms.Button()
        CType(Me.dgFQLSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAQLSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFQLDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAQLDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "DECLARATIONS"

    Protected FQL As QA = New QA()
    Protected AQL As QA = New QA()

#End Region
#Region "PAGE EVENTS"

    Private Sub Form_load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

#End Region
#Region "CONTROL EVENTS"

    Private Sub DateTimePicker1_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpStart.Leave
        GetData(Me.dtpStart.Value, Me.dtpEnd.Value)
    End Sub
    Private Sub dtpEnd_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEnd.Leave
        GetData(Me.dtpStart.Value, Me.dtpEnd.Value)
    End Sub

    Private Sub btnViewFQLDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewFQLDetails.Click
        Me.Cursor = Cursors.WaitCursor
        dgFQLDetails.DataSource = FQL.DetailDT
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnViewAQLDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewAQLDetails.Click
        Me.Cursor = Cursors.WaitCursor
        dgAQLDetails.DataSource = AQL.DetailDT
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim DS As DataSet = New DataSet()
        DS.Tables.Add(FQL.DetailDT.Copy)
        DS.Tables(0).TableName = "FQL Detail"
        DS.Tables.Add(AQL.DetailDT.Copy)
        DS.Tables(1).TableName = "AQL Detail"
        Dim objExcelRpt As New PSS.Data.ExcelReports()

        objExcelRpt.RunSimpleExcelFormat_PerSheetPerTable(DS, "TEST", )

        'objExcelRpt.DataSetToExcel(DS, "Messaging Quality Report")
        MessageBox.Show("File has been saved to .....")
    End Sub

#End Region
#Region "METHODS"

    Private Sub GetData(ByVal start_dt As DateTime, ByVal end_dt As DateTime)
        Me.Cursor = Cursors.WaitCursor
        dgFQLSummary.DataSource = Nothing
        dgAQLSummary.DataSource = Nothing
        dgFQLDetails.DataSource = Nothing
        dgAQLDetails.DataSource = Nothing
        FQL = New PSSBase.QA("Functional", start_dt, end_dt)
        AQL = New PSSBase.QA("AQL", start_dt, end_dt)
        dgFQLSummary.DataSource = FQL.SummaryDT
        dgAQLSummary.DataSource = AQL.SummaryDT
        Me.Cursor = Cursors.Default
    End Sub

#End Region

End Class
