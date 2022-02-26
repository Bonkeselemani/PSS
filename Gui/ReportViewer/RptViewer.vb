Imports CrystalDecisions.CrystalReports.Engine
Imports PSS.Core
Imports PSS.Data

Imports System.Reflection

Public Class RptViewer
    Inherits System.Windows.Forms.Form

    Private _strReportName As String
    Private _strSubReportNames() As String

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strReport As String)
        MyBase.New()

        Me._strReportName = strReport
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        RptViewer_Load()

    End Sub

    Public Sub New(ByVal strReport As String, ByVal ds As DataSet, ByVal strSubRptnames As String())
        MyBase.New()

        Me._strReportName = strReport
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        RptViewer_Load(ds, strSubRptnames)

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
    Friend WithEvents crvReport As CrystalDecisions.Windows.Forms.CrystalReportViewer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.crvReport = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvReport
        '
        Me.crvReport.ActiveViewIndex = -1
        Me.crvReport.DisplayGroupTree = False
        Me.crvReport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReport.Name = "crvReport"
        Me.crvReport.ReportSource = Nothing
        Me.crvReport.Size = New System.Drawing.Size(864, 613)
        Me.crvReport.TabIndex = 1
        '
        'RptViewer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(864, 613)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReport})
        Me.Name = "RptViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "RptViewer"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RptViewer_Load(Optional ByVal ds As DataSet = Nothing, Optional ByVal strSubRptNames As String() = Nothing)
        Dim strReportLoc As String = ConfigFile.GetBaseReportPath()
        Dim i As Integer = 0
        Dim objRpt, objSubRpt As ReportDocument
        'Dim objPrintDate, objPrintTime As TextObject
        'Dim bFound() As Boolean = {False, False}

        Try
            Gui.MainWin.StatusBar.SetStatusText("Generating Report")

            objRpt = New ReportDocument()

            With objRpt
                .Load(strReportLoc & Me._strReportName)

                If Not IsNothing(ds) Then
                    .SetDataSource(ds.Tables(0))

                    If ds.Tables.Count > 1 Then
                        For i = 1 To ds.Tables.Count - 1
                            objSubRpt = .OpenSubreport(strSubRptNames(i - 1))
                            objSubRpt.SetDataSource(ds.Tables(i))
                        Next
                    End If
                End If

                CrystalReports.FormatCRDateTimeTextBoxes(objRpt, "Arial")
            End With

            crvReport.ReportSource = objRpt
        Catch exp As Exception
            Dim sf As New StackFrame(1)

            MsgBox(exp.ToString)
        Finally
            Gui.MainWin.StatusBar.SetStatusText("")

            '    If Not IsNothing(ds) Then
            '        ds.Clear()
            '        ds = Nothing
            '    End If
        End Try

    End Sub

    Private Sub FormatCRDateTimeTextBox(ByVal objRpt As ReportDocument, ByRef objFormat As TextObject)
        Dim strFormat As String = ""

        Try
            objFormat.ApplyFont(New Font("Arial", 6, FontStyle.Regular, GraphicsUnit.Point))

            If objFormat.Name.ToUpper.IndexOf("DATE") > -1 Then
                strFormat = PSS.Data.ConfigFile.GetCRPrintDateFormat()
            Else
                strFormat = PSS.Data.ConfigFile.GetCRPrintTimeFormat()
            End If

            objFormat.Text = Format(Now(), strFormat)
            objFormat.ObjectFormat.HorizontalAlignment = CrystalDecisions.[Shared].Alignment.RightAlign
            objFormat.ObjectFormat.EnableCanGrow = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RptViewer_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Gui.MainWin.StatusBar.SetStatusText("")

    End Sub

    Protected Overrides Sub OnClosing(ByVal e As System.ComponentModel.CancelEventArgs)

        Gui.MainWin.StatusBar.SetStatusText("")

    End Sub

    Private Sub rptView_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class

