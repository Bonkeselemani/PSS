Option Explicit On 

Namespace QualityControl
    Public Class frmGetManufactureDate
        Inherits System.Windows.Forms.Form

        Private iDevice_ID As Integer = 0
        Private dt As DataTable = Nothing
        Private objMisc As PSS.Data.Production.Misc
        Public booReturnVal As Boolean = False

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal ID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMisc = New PSS.Data.Production.Misc()

            iDevice_ID = ID
            Dim strSql As String = ""

            Try
                strSql = "SELECT * FROM twarehousereceive " & Environment.NewLine
                strSql &= "WHERE WHR_ManufDateCode is not null  " & Environment.NewLine
                strSql &= "AND DEVICE_ID = " & iDevice_ID & " " & Environment.NewLine

                dt = Me.objMisc.GetDataTable(strSql)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Information")
            End Try
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
        Friend WithEvents txtManufDate As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtManufDate = New System.Windows.Forms.TextBox()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(8, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(160, 32)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Enter manufacture date in 4 digits format ""MMYY"":"
            '
            'txtManufDate
            '
            Me.txtManufDate.Location = New System.Drawing.Point(8, 40)
            Me.txtManufDate.MaxLength = 4
            Me.txtManufDate.Name = "txtManufDate"
            Me.txtManufDate.Size = New System.Drawing.Size(160, 20)
            Me.txtManufDate.TabIndex = 1
            Me.txtManufDate.Text = ""
            '
            'frmGetManufactureDate
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(176, 70)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtManufDate, Me.Label1})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmGetManufactureDate"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Manufacture Date"
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************
        Private Sub txtManufDate_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtManufDate.KeyUp
            Try
                If e.KeyValue = 13 Then
                    If Me.txtManufDate.Text = "" Then
                        Exit Sub
                    Else
                        If IsNothing(dt) Then
                            booReturnVal = True
                            Me.CleanUpGlobalVar()
                            Me.Close()
                        ElseIf dt.Rows.Count = 0 Then
                            booReturnVal = True
                            Me.CleanUpGlobalVar()
                            Me.Close()
                        ElseIf dt.Rows.Count > 0 AndAlso IsDBNull(dt.Rows(0)("WHR_ManufDateCode")) Then
                            booReturnVal = True
                            Me.CleanUpGlobalVar()
                            Me.Close()
                        ElseIf Me.txtManufDate.Text.Trim.ToUpper = dt.Rows(0)("WHR_ManufDateCode").ToString.Trim.ToUpper Then
                            booReturnVal = True
                            Me.CleanUpGlobalVar()
                            Me.Close()
                        ElseIf MessageBox.Show("Incorrect manufacture date. Would you like to try again?", "Manufacture Date", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) = DialogResult.No Then
                            Me.CleanUpGlobalVar()
                            Me.Close()
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Information")
            End Try
        End Sub

        '**************************************************************************
        Private Sub txtManufDate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtManufDate.KeyPress
            If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        End Sub

        '**************************************************************************
        Private Sub CleanUpGlobalVar()
            iDevice_ID = Nothing
            If Not IsNothing(Me.dt) Then
                Me.dt.Dispose()
                Me.dt = Nothing
            End If
            objMisc = Nothing
        End Sub

        '**************************************************************************

    End Class
End Namespace



