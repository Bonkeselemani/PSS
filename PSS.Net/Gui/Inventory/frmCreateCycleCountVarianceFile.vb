Namespace Inventory
    Public Class frmCreateCycleCountVarianceFile
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
        Friend WithEvents cmdCreateVarianceFile As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cmdCreateVarianceFile = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'cmdCreateVarianceFile
            '
            Me.cmdCreateVarianceFile.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdCreateVarianceFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCreateVarianceFile.ForeColor = System.Drawing.Color.Blue
            Me.cmdCreateVarianceFile.Location = New System.Drawing.Point(16, 16)
            Me.cmdCreateVarianceFile.Name = "cmdCreateVarianceFile"
            Me.cmdCreateVarianceFile.Size = New System.Drawing.Size(224, 104)
            Me.cmdCreateVarianceFile.TabIndex = 0
            Me.cmdCreateVarianceFile.Text = "Create Bench Cycle Count Variance File for Navision Adjustments"
            '
            'frmCreateCycleCountVarianceFile
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(440, 300)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCreateVarianceFile})
            Me.Name = "frmCreateCycleCountVarianceFile"
            Me.Text = "frmCreateCycleCountVarianceFile"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub cmdCreateVarianceFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateVarianceFile.Click
            Dim i As Integer = 0
            Dim strFilePath As String = "R:\InventoryData\Bench Cycle Count Variance\BenchCycleCountVariance.txt"
            Cursor.Current = Cursors.WaitCursor

            Try
                i = objInventory.CreateBenchCycleCountVarianceFile()
                If i > 0 Then
                    DisplayNoteBoard("File has been successfully created and saved as '" & strFilePath & "'.", 7000)
                End If
            Catch ex As Exception
                MsgBox("frmReplenishNavFile.cmdCreateFile_Click:: " & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        Protected Overrides Sub Finalize()
            objInventory = Nothing
            MyBase.Finalize()
        End Sub

        Private Sub DisplayNoteBoard(ByVal vString As String, ByVal iMilliSecs As Integer)
            Dim frm As New Gui.NoteBoard.frmNoteBoard(vString, iMilliSecs)
            frm.ShowDialog()
            If Not IsNothing(frm) Then
                frm = Nothing
            End If
        End Sub
    End Class
End Namespace