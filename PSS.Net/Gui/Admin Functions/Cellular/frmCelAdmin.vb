

Namespace AdminFunctions
    Public Class frmCelAdmin
        Inherits System.Windows.Forms.Form
        Private objMotoSubcontract_Biz As PSS.Data.Buisness.MotorolaSubcontract_Biz
        Private dt As DataTable
        Private R1 As DataRow

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
        Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnUnship As System.Windows.Forms.Button
        Friend WithEvents txtWorkOrder As System.Windows.Forms.TextBox
        Friend WithEvents btnShip As System.Windows.Forms.Button
        Friend WithEvents btnReprint As System.Windows.Forms.Button
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCelAdmin))
            Me.GroupBox3 = New System.Windows.Forms.GroupBox()
            Me.txtWorkOrder = New System.Windows.Forms.TextBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnUnship = New System.Windows.Forms.Button()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.btnShip = New System.Windows.Forms.Button()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.btnDelete = New System.Windows.Forms.Button()
            Me.GroupBox3.SuspendLayout()
            Me.GroupBox1.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox3
            '
            Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtWorkOrder, Me.Label2, Me.btnUnship, Me.btnReprint, Me.btnShip})
            Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox3.ForeColor = System.Drawing.Color.White
            Me.GroupBox3.Location = New System.Drawing.Point(384, 96)
            Me.GroupBox3.Name = "GroupBox3"
            Me.GroupBox3.Size = New System.Drawing.Size(312, 256)
            Me.GroupBox3.TabIndex = 20
            Me.GroupBox3.TabStop = False
            Me.GroupBox3.Text = " Motorola NSC Cellular Related Tasks"
            '
            'txtWorkOrder
            '
            Me.txtWorkOrder.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWorkOrder.Location = New System.Drawing.Point(134, 32)
            Me.txtWorkOrder.Name = "txtWorkOrder"
            Me.txtWorkOrder.Size = New System.Drawing.Size(150, 23)
            Me.txtWorkOrder.TabIndex = 23
            Me.txtWorkOrder.Text = ""
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(24, 38)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(108, 16)
            Me.Label2.TabIndex = 22
            Me.Label2.Text = "Work Order #"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnUnship
            '
            Me.btnUnship.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUnship.ForeColor = System.Drawing.Color.White
            Me.btnUnship.Location = New System.Drawing.Point(36, 104)
            Me.btnUnship.Name = "btnUnship"
            Me.btnUnship.Size = New System.Drawing.Size(244, 23)
            Me.btnUnship.TabIndex = 21
            Me.btnUnship.Text = "Unship Masterpack"
            '
            'btnReprint
            '
            Me.btnReprint.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprint.ForeColor = System.Drawing.Color.White
            Me.btnReprint.Location = New System.Drawing.Point(36, 168)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(244, 23)
            Me.btnReprint.TabIndex = 19
            Me.btnReprint.Text = "Reprint Manifests/Labels"
            '
            'btnShip
            '
            Me.btnShip.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnShip.ForeColor = System.Drawing.Color.White
            Me.btnShip.Location = New System.Drawing.Point(36, 136)
            Me.btnShip.Name = "btnShip"
            Me.btnShip.Size = New System.Drawing.Size(244, 23)
            Me.btnShip.TabIndex = 20
            Me.btnShip.Text = "Ship Partial Palletts"
            '
            'GroupBox1
            '
            Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDelete})
            Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GroupBox1.ForeColor = System.Drawing.Color.White
            Me.GroupBox1.Location = New System.Drawing.Point(96, 96)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(280, 255)
            Me.GroupBox1.TabIndex = 25
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "General Tasks"
            '
            'btnDelete
            '
            Me.btnDelete.BackColor = System.Drawing.Color.Transparent
            Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDelete.ForeColor = System.Drawing.Color.White
            Me.btnDelete.Location = New System.Drawing.Point(19, 103)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(244, 23)
            Me.btnDelete.TabIndex = 25
            Me.btnDelete.Text = "Delete  Device"
            '
            'frmCelAdmin
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
            Me.ClientSize = New System.Drawing.Size(792, 445)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox1, Me.GroupBox3})
            Me.Name = "frmCelAdmin"
            Me.Text = "Cell Administration"
            Me.GroupBox3.ResumeLayout(False)
            Me.GroupBox1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmCelAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub


        Private Sub btnUnship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnship.Click
            Me.btnUnship.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            If Not IsNumeric(Me.txtWorkOrder.Text) Then
                MsgBox("Please enter a numeric value for Work Order.", MsgBoxStyle.Information, "Cell Administration")
                Me.btnUnship.Enabled = True
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            Dim message, title, defaultValue As String
            Dim strMasterPackNo As String = ""

            message = "Enter Masterpack No."                ' Set prompt.
            title = "Unship Masterpack"                     ' Set title.
            defaultValue = ""                               ' Set default value.

            strMasterPackNo = InputBox(message, title, defaultValue)      'INput Masterpack No which is also Ship_id

            If Not IsNumeric(strMasterPackNo) Then
                MsgBox("Please enter a numeric value for Masterpack Number", MsgBoxStyle.Information, "Cell Administration")
                Me.btnUnship.Enabled = True
                Cursor.Current = Cursors.Default
                Exit Sub
            End If

            '*******************************************************
            'unship
            '*******************************************************
            Dim i As Integer
            Try
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
                i = objMotoSubcontract_Biz.UnshipMasterpack(CInt(Me.txtWorkOrder.Text), CInt(strMasterPackNo))

                If i <> 0 Then
                    MsgBox("Masterpack successfully unshipped.", MsgBoxStyle.Information, "Cell Administration")
                End If

            Catch ex As Exception
                MsgBox("Error occured in btnUnship_Click:: " & ex.Message.ToString, MsgBoxStyle.Critical, "Cell Administration")
            Finally
                If Not IsNothing(objMotoSubcontract_Biz) Then
                    objMotoSubcontract_Biz = Nothing
                End If

                Me.btnUnship.Enabled = True
                Cursor.Current = Cursors.Default

            End Try

            '*******************************************************

        End Sub

        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click

            'If Not IsNumeric(Me.txtWorkOrder.Text) Then
            '    MsgBox("Please enter a numeric value for Work Order.", MsgBoxStyle.Information, "Cell Administration")
            '    Exit Sub
            'End If
            Dim myfrmObj As New PSS.Gui.MotorolaSubcontract.frmReprint()
            myfrmObj.ShowDialog()
            myfrmObj = Nothing
        End Sub

        Private Sub btnShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShip.Click

            If Not IsNumeric(Me.txtWorkOrder.Text) Then
                MsgBox("Please enter a numeric value for Work Order.", MsgBoxStyle.Information, "Cell Administration")
                Exit Sub
            End If
            Dim myfrmObj As New PSS.Gui.MotorolaSubcontract.frmShipPartialPalletts(CInt(Me.txtWorkOrder.Text))
            myfrmObj.ShowDialog()
            myfrmObj = Nothing

        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            Dim message, title, defaultValue As String
            Dim strDeviceID As String = ""

            message = "Enter Device Id."                ' Set prompt.
            title = "Delete Device"                     ' Set title.
            defaultValue = ""                               ' Set default value.

            strDeviceID = InputBox(message, title, defaultValue)      'INput Masterpack No which is also Ship_id

            If Not IsNumeric(strDeviceID) Then
                MsgBox("Please enter a numeric value for Device ID.", MsgBoxStyle.Information, "Cell Administration")
                'Me.btnUnship.Enabled = True
                'Cursor.Current = Cursors.Default
                Exit Sub
            End If

            Dim i As Integer

            Try
                objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()

                'Step 1:   (Update the tdevice table)
                i = objMotoSubcontract_Biz.DeleteDevice(CInt(strDeviceID))

                If i <> 0 Then
                    MsgBox("Device is deleted successfully.", MsgBoxStyle.Information, "Cell Administration")
                Else
                    MsgBox("Device not deleted.", MsgBoxStyle.Information, "Cell Administration")
                End If

            Catch ex As Exception
                MsgBox("Error occured in btnDelete_Click:: " & ex.Message.ToString, MsgBoxStyle.Critical, "Cell Administration")
            Finally
                If Not IsNothing(objMotoSubcontract_Biz) Then
                    objMotoSubcontract_Biz = Nothing
                End If

                'Me.btnUnship.Enabled = True
                'Cursor.Current = Cursors.Default

            End Try




        End Sub


    End Class
End Namespace
