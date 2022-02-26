Public Class frmCollectBolTrackingNo
    Inherits System.Windows.Forms.Form
    Private _strPSSIBox As String = ""
    Private _objPackShip As PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip
    Public _strBOL As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal strPSSIBox As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._strPSSIBox = strPSSIBox
        Me._objPackShip = New PSS.Data.Buisness.TracFoneFulfillmentKit.TFFK_PickPackShip()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Try
                Me._objPackShip = Nothing
            Catch ex As Exception
            End Try

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
    Friend WithEvents lbllblPSSIBox As System.Windows.Forms.Label
    Friend WithEvents lblPSSIBox As System.Windows.Forms.Label
    Friend WithEvents lblBOL As System.Windows.Forms.Label
    Friend WithEvents txtBOL As System.Windows.Forms.TextBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lbllblPSSIBox = New System.Windows.Forms.Label()
        Me.lblPSSIBox = New System.Windows.Forms.Label()
        Me.lblBOL = New System.Windows.Forms.Label()
        Me.txtBOL = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbllblPSSIBox
        '
        Me.lbllblPSSIBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllblPSSIBox.Location = New System.Drawing.Point(24, 48)
        Me.lbllblPSSIBox.Name = "lbllblPSSIBox"
        Me.lbllblPSSIBox.Size = New System.Drawing.Size(88, 24)
        Me.lbllblPSSIBox.TabIndex = 0
        Me.lbllblPSSIBox.Text = "PSSI Box:"
        '
        'lblPSSIBox
        '
        Me.lblPSSIBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPSSIBox.Location = New System.Drawing.Point(104, 48)
        Me.lblPSSIBox.Name = "lblPSSIBox"
        Me.lblPSSIBox.Size = New System.Drawing.Size(144, 16)
        Me.lblPSSIBox.TabIndex = 1
        '
        'lblBOL
        '
        Me.lblBOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBOL.Location = New System.Drawing.Point(24, 80)
        Me.lblBOL.Name = "lblBOL"
        Me.lblBOL.Size = New System.Drawing.Size(224, 24)
        Me.lblBOL.TabIndex = 2
        Me.lblBOL.Text = "BOL Tracking Number:"
        '
        'txtBOL
        '
        Me.txtBOL.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBOL.Location = New System.Drawing.Point(28, 98)
        Me.txtBOL.Name = "txtBOL"
        Me.txtBOL.Size = New System.Drawing.Size(216, 26)
        Me.txtBOL.TabIndex = 3
        Me.txtBOL.Text = ""
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(64, 136)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(136, 32)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(248, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Please enter BOL tracking number"
        '
        'frmCollectBolTrackingNo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(280, 206)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.btnOK, Me.txtBOL, Me.lblBOL, Me.lblPSSIBox, Me.lbllblPSSIBox})
        Me.MaximizeBox = False
        Me.Name = "frmCollectBolTrackingNo"
        Me.Text = "Enter BOL Tracking Number"
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub frmCollectBolTrackingNo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            PSS.Core.Highlight.SetHighLight(Me)

            Me.CenterToScreen()

            Me.lblPSSIBox.Text = Me._strPSSIBox

            Me.txtBOL.SelectAll() : Me.txtBOL.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "frmCollectBolTrackingNo_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim strBOL As String = ""
        Dim strPSSIBox As String = ""

        Try
            strBOL = Me.txtBOL.Text.Trim
            strPSSIBox = Me.lblPSSIBox.Text.Trim
            If strBOL.Trim.Length = 0 Then
                MessageBox.Show("You have to enter a BOL tracking number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ElseIf strPSSIBox.Trim.Length = 0 Then
                MessageBox.Show("Missing PSSIBox name. See IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                Me._strBOL = strBOL
                Me._objPackShip.SaveBolTrackingNumber(strPSSIBox, strBOL)

                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub txtBOL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBOL.KeyPress
        'Allow to enter integer only
        Try
            If Asc(e.KeyChar) <> 13 AndAlso Asc(e.KeyChar) <> 8 AndAlso Not IsNumeric(e.KeyChar) Then
                'MessageBox.Show("Please enter numbers only")
                e.Handled = True
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
