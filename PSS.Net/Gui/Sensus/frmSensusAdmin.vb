Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmSensusAdmin
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
    Friend WithEvents btnTodayRMAShipmentRpt As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnTodayRMAShipmentRpt = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTodayRMAShipmentRpt
        '
        Me.btnTodayRMAShipmentRpt.BackColor = System.Drawing.Color.SteelBlue
        Me.btnTodayRMAShipmentRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTodayRMAShipmentRpt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.btnTodayRMAShipmentRpt.Location = New System.Drawing.Point(16, 24)
        Me.btnTodayRMAShipmentRpt.Name = "btnTodayRMAShipmentRpt"
        Me.btnTodayRMAShipmentRpt.Size = New System.Drawing.Size(192, 48)
        Me.btnTodayRMAShipmentRpt.TabIndex = 0
        Me.btnTodayRMAShipmentRpt.Text = "Today RMA Shipment Report"
        '
        'frmSensusAdmin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(384, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnTodayRMAShipmentRpt})
        Me.Name = "frmSensusAdmin"
        Me.Text = "frmSensusAdmin"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '******************************************************************
    Private Sub btnTodayRMAShipmentRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTodayRMAShipmentRpt.Click
        Dim i As Integer = 0
        Dim objSensus As Sensus

        Try
            objSensus = New Sensus()

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            i = objSensus.CreateTodayRMAShipmentRpt().Rows.Count

            Me.Enabled = True
            Cursor.Current = Cursors.Default

            If i > 0 Then
                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create RMA Shipment Rpt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            objSensus = Nothing
            'GC.Collect()
            'GC.WaitForPendingFinalizers()
            'GC.Collect()
            'GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '******************************************************************

End Class
