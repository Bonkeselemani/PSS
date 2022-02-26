Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmBERScreen
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer
        Private _strScreenName As String = ""
        Private _objTFMisc As PSS.Data.Buisness.TracFone.clsMisc
        Private _iOrderID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iCustID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iMenuCustID = iCustID
            _strScreenName = strScreenName
            Me.lblScreenName.Text = Me._strScreenName

            _objTFMisc = New PSS.Data.Buisness.TracFone.clsMisc()
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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblBoxQty As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents txtBoxID As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnVerifyBox As System.Windows.Forms.Button
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnCompleted As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.lblBoxQty = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.txtBoxID = New System.Windows.Forms.TextBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.btnCompleted = New System.Windows.Forms.Button()
            Me.btnVerifyBox = New System.Windows.Forms.Button()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label2.Location = New System.Drawing.Point(280, 112)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(48, 16)
            Me.Label2.TabIndex = 145
            Me.Label2.Text = "Model:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBoxQty
            '
            Me.lblBoxQty.BackColor = System.Drawing.Color.White
            Me.lblBoxQty.ForeColor = System.Drawing.Color.Black
            Me.lblBoxQty.Location = New System.Drawing.Point(216, 112)
            Me.lblBoxQty.Name = "lblBoxQty"
            Me.lblBoxQty.Size = New System.Drawing.Size(48, 22)
            Me.lblBoxQty.TabIndex = 142
            Me.lblBoxQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label1.Location = New System.Drawing.Point(48, 112)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(160, 16)
            Me.Label1.TabIndex = 143
            Me.Label1.Text = "Qty of BER Screen  Unit(s):"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.White
            Me.lblModel.ForeColor = System.Drawing.Color.Black
            Me.lblModel.Location = New System.Drawing.Point(336, 112)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(184, 22)
            Me.lblModel.TabIndex = 144
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtBoxID
            '
            Me.txtBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBoxID.Location = New System.Drawing.Point(216, 80)
            Me.txtBoxID.MaxLength = 15
            Me.txtBoxID.Name = "txtBoxID"
            Me.txtBoxID.Size = New System.Drawing.Size(304, 22)
            Me.txtBoxID.TabIndex = 1
            Me.txtBoxID.Text = ""
            '
            'Label3
            '
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label3.Location = New System.Drawing.Point(136, 80)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(72, 16)
            Me.Label3.TabIndex = 147
            Me.Label3.Text = "WH Box ID:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCompleted
            '
            Me.btnCompleted.BackColor = System.Drawing.Color.Green
            Me.btnCompleted.Enabled = False
            Me.btnCompleted.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCompleted.ForeColor = System.Drawing.Color.White
            Me.btnCompleted.Location = New System.Drawing.Point(216, 232)
            Me.btnCompleted.Name = "btnCompleted"
            Me.btnCompleted.Size = New System.Drawing.Size(216, 24)
            Me.btnCompleted.TabIndex = 3
            Me.btnCompleted.Text = "Complete BER Screen"
            '
            'btnVerifyBox
            '
            Me.btnVerifyBox.BackColor = System.Drawing.Color.Green
            Me.btnVerifyBox.Enabled = False
            Me.btnVerifyBox.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnVerifyBox.ForeColor = System.Drawing.Color.White
            Me.btnVerifyBox.Location = New System.Drawing.Point(216, 168)
            Me.btnVerifyBox.Name = "btnVerifyBox"
            Me.btnVerifyBox.Size = New System.Drawing.Size(216, 24)
            Me.btnVerifyBox.TabIndex = 2
            Me.btnVerifyBox.Text = "Verify Box"
            '
            'lblScreenName
            '
            Me.lblScreenName.Font = New System.Drawing.Font("Tahoma", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Blue
            Me.lblScreenName.Location = New System.Drawing.Point(224, 16)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(296, 48)
            Me.lblScreenName.TabIndex = 148
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(216, 296)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(216, 24)
            Me.btnCancel.TabIndex = 4
            Me.btnCancel.Text = "Cancel"
            '
            'frmBERScreen
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(672, 510)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.lblScreenName, Me.btnVerifyBox, Me.btnCompleted, Me.Label3, Me.txtBoxID, Me.Label2, Me.lblBoxQty, Me.Label1, Me.lblModel})
            Me.Name = "frmBERScreen"
            Me.Text = "frmBERScreen"
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************************
        Private Sub frmBERScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                PSS.Core.Highlight.SetHighLight(Me)
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "frmBERScreen_Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub txtBoxID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxID.KeyUp
            Try
                If e.KeyCode = Keys.Enter AndAlso Me.txtBoxID.Text.Trim.Length > 0 Then
                    Dim strBoxID As String = Me.txtBoxID.Text.Trim.ToUpper
                    Me.btnCancel_Click(Nothing, Nothing)
                    Me.txtBoxID.Text = strBoxID
                    If ProcessBox(Me.txtBoxID.Text.Trim) Then
                        Me.btnVerifyBox.Enabled = True
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtBoxID_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************
        Private Function ProcessBox(ByVal strWHBoxID As String) As Boolean
            Dim dt As DataTable
            Dim booReturnVal As Boolean = False

            Try
                dt = _objTFMisc.GetWHBox(Me.txtBoxID.Text.Trim)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("This Box ID does not exist.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("Closed").ToString = "0" Then
                    MessageBox.Show("Box is open.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                ElseIf dt.Rows(0)("FuncRep").ToString = "0" Then
                    MessageBox.Show("Box is not function repair.", "ProcessBox", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtBoxID.Text = "" : Me.txtBoxID.Focus()
                Else
                    Me._iOrderID = dt.Rows(0)("Order_ID")
                    dt = Me._objTFMisc.GetBoxStationCount(Me.txtBoxID.Text)
                    Me.lblModel.Text = dt.Rows(0)("Model_Desc")
                    If Not IsDBNull(dt.Compute("Sum(Cnt)", "WorkStation = 'BER SCREEN'")) Then
                        Me.lblBoxQty.Text = dt.Compute("Sum(Cnt)", "WorkStation = 'BER SCREEN'")
                    Else
                        Me.lblBoxQty.Text = "0"
                    End If
                    Me.btnVerifyBox.Enabled = True
                    booReturnVal = True
                End If

                Return booReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Function

        '**************************************************************************************
        Private Sub btnVerifyBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerifyBox.Click
            Dim dt As DataTable
            Dim strIMEI As String = ""

            Try
                strIMEI = InputBox("Enter IMEI:", "Verify Box").Trim
                If strIMEI.Trim.Length > 0 Then
                    dt = Me._objTFMisc.GetDevicesInWHBox(Me.txtBoxID.Text, Me._iOrderID)
                    If dt.Select("SN = '" & strIMEI & "'").Length > 0 Then
                        If dt.Select("SN = '" & strIMEI & "' AND Workstation = 'BER Screen'").Length = 0 Then
                            Me.btnCompleted.Enabled = False
                            MessageBox.Show("IMEI does not belong to BER Screen. Please verify each device in box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Else
                            Me.btnCompleted.Enabled = True
                        End If
                    Else
                        Me.btnCompleted.Enabled = False
                        MessageBox.Show("IMEI does not belong to box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnVerifyBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub btnCompleted_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompleted.Click
            Try
                If Me.txtBoxID.Text.Trim.Length > 0 Then
                    If ProcessBox(Me.txtBoxID.Text.Trim) = True Then
                        If Me.lblBoxQty.Text = "0" OrElse Me.lblBoxQty.Text = "" Then
                            MessageBox.Show("Box is empty.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Else
                            Dim i As Integer = Me._objTFMisc.CompletedBERScreenBox(Me.txtBoxID.Text.Trim, Me._iOrderID)
                            If i > 0 Then
                                btnCancel_Click(Nothing, Nothing)
                                Me.txtBoxID.Focus()
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnTransfer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me.txtBoxID.Text = ""
                btnCompleted.Enabled = False : Me.btnVerifyBox.Enabled = False
                Me.lblBoxQty.Text = "0" : Me.lblModel.Text = ""
                _iOrderID = 0
                If Not IsNothing(sender) Then Me.txtBoxID.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnTransfer_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************************

    End Class
End Namespace