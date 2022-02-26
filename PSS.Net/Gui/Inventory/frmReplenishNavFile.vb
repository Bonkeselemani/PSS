Namespace Inventory
    Public Class frmReplenishNavFile
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
        Friend WithEvents cmdCreateFile As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cmdCreateFile = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'cmdCreateFile
            '
            Me.cmdCreateFile.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdCreateFile.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCreateFile.ForeColor = System.Drawing.Color.Blue
            Me.cmdCreateFile.Location = New System.Drawing.Point(24, 24)
            Me.cmdCreateFile.Name = "cmdCreateFile"
            Me.cmdCreateFile.Size = New System.Drawing.Size(256, 128)
            Me.cmdCreateFile.TabIndex = 66
            Me.cmdCreateFile.Text = "Create File to Move Replenished Parts in Navision"
            '
            'frmReplenishNavFile
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(952, 557)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCreateFile})
            Me.Name = "frmReplenishNavFile"
            Me.Text = "Excel Reports"
            Me.ResumeLayout(False)

        End Sub

#End Region
        '*********************************************************
        Private Sub cmdCreateFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateFile.Click
            Dim i As Integer = 0
            Cursor.Current = Cursors.WaitCursor

            Try
                i = objInventory.CreateReplenishedPartsFile()
                If i > 0 Then
                    DisplayNoteBoard("File has been successfully created at 'R:\InventoryData\ReplenishParts'.", 7000)
                End If
            Catch ex As Exception
                MsgBox("frmReplenishNavFile.cmdCreateFile_Click:: " & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        '*********************************************************
        Protected Overrides Sub Finalize()
            objInventory = Nothing
            MyBase.Finalize()
        End Sub
        '*********************************************************
        Private Sub frmReplenishNavFile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Me.dtpWorkdate.Text = Now
        End Sub
        '*********************************************************
        Private Sub DisplayNoteBoard(ByVal vString As String, ByVal iMilliSecs As Integer)
            Dim frm As New Gui.NoteBoard.frmNoteBoard(vString, iMilliSecs)
            frm.ShowDialog()
            If Not IsNothing(frm) Then
                frm = Nothing
            End If
        End Sub
        '*********************************************************
    End Class
End Namespace