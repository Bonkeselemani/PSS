Namespace Inventory
    Public Class frmSHopFloorOnHandRpt
        Inherits System.Windows.Forms.Form
        Private objInventory As PSS.Data.Buisness.Inventory

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objInventory = New PSS.Data.Buisness.Inventory()
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
        Friend WithEvents cmdCreateReport As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cmdCreateReport = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'cmdCreateReport
            '
            Me.cmdCreateReport.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdCreateReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCreateReport.Location = New System.Drawing.Point(32, 32)
            Me.cmdCreateReport.Name = "cmdCreateReport"
            Me.cmdCreateReport.Size = New System.Drawing.Size(288, 72)
            Me.cmdCreateReport.TabIndex = 0
            Me.cmdCreateReport.Text = "Create Shop Floor on Hand Report"
            '
            'frmSHopFloorOnHandRpt
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(440, 326)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCreateReport})
            Me.Name = "frmSHopFloorOnHandRpt"
            Me.Text = "Shop Floor on Hand Report"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Protected Overrides Sub Finalize()
            objInventory = Nothing
            MyBase.Finalize()
        End Sub

        Private Sub cmdCreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateReport.Click
            Dim i As Integer = 0
            Cursor.Current = Cursors.WaitCursor
            Me.cmdCreateReport.Enabled = False

            Try
                i = objInventory.CreateShopFloorOnHandReport()

            Catch ex As Exception
                MsgBox("frmShopFloorOnHandRpt.cmdCreateReport_Click:: " & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
                Me.cmdCreateReport.Enabled = True
            End Try
        End Sub

    End Class
End Namespace