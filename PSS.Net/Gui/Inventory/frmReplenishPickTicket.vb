Namespace Inventory
    Public Class frmReplenishPickTicket
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
        Friend WithEvents cmdCreateRpt As System.Windows.Forms.Button
        Friend WithEvents cmdRecreateRpt As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.cmdCreateRpt = New System.Windows.Forms.Button()
            Me.cmdRecreateRpt = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'cmdCreateRpt
            '
            Me.cmdCreateRpt.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdCreateRpt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdCreateRpt.ForeColor = System.Drawing.Color.Black
            Me.cmdCreateRpt.Location = New System.Drawing.Point(56, 56)
            Me.cmdCreateRpt.Name = "cmdCreateRpt"
            Me.cmdCreateRpt.Size = New System.Drawing.Size(200, 64)
            Me.cmdCreateRpt.TabIndex = 66
            Me.cmdCreateRpt.Text = "Create Replenish Parts Report"
            '
            'cmdRecreateRpt
            '
            Me.cmdRecreateRpt.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdRecreateRpt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdRecreateRpt.ForeColor = System.Drawing.Color.Red
            Me.cmdRecreateRpt.Location = New System.Drawing.Point(56, 160)
            Me.cmdRecreateRpt.Name = "cmdRecreateRpt"
            Me.cmdRecreateRpt.Size = New System.Drawing.Size(200, 80)
            Me.cmdRecreateRpt.TabIndex = 67
            Me.cmdRecreateRpt.Text = "Recreate Previously Created Report (Needs batch No.)"
            '
            'frmReplenishPickTicket
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(952, 557)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRecreateRpt, Me.cmdCreateRpt})
            Me.Name = "frmReplenishPickTicket"
            Me.Text = "Excel Reports"
            Me.ResumeLayout(False)

        End Sub

#End Region
        '*********************************************************
        Private Sub cmdCreateRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateRpt.Click
            Dim i As Integer = 0
            Cursor.Current = Cursors.WaitCursor
            Me.cmdCreateRpt.Enabled = False

            Try
                i = objInventory.TriggerPartsReplenishment()
                i = objInventory.CreateReplenishPickTicket()
                If i = 0 Then
                    Throw New Exception("There are no parts to replenish at this point.")
                End If
            Catch ex As Exception
                MsgBox("frmReplenishPickTicket.cmdCreateRpt_Click:: " & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
                Me.cmdCreateRpt.Enabled = True
            End Try
        End Sub
        '*********************************************************
        Protected Overrides Sub Finalize()
            objInventory = Nothing
            MyBase.Finalize()
        End Sub

        '*********************************************************

        Private Sub cmdRecreateRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRecreateRpt.Click


            Dim i As Integer = 0
            Dim strBatchNo As String = ""
            Cursor.Current = Cursors.WaitCursor
            Me.cmdRecreateRpt.Enabled = False

            Try

                strBatchNo = InputBox("Please enter 'Batch No.'")      'INput Masterpack No which is also Ship_id

                If Not IsNumeric(strBatchNo) Then
                    Throw New Exception("Please enter a numeric value for Batch No.")
                End If

                i = objInventory.CreateReplenishPickTicket(CInt(strBatchNo))

            Catch ex As Exception
                MsgBox("frmReplenishPickTicket.cmdCreateRpt_Click:: " & ex.Message)
            Finally
                Cursor.Current = Cursors.Default
                Me.cmdRecreateRpt.Enabled = True
            End Try


        End Sub
    End Class
End Namespace