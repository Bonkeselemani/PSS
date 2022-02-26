Option Explicit On 

Namespace Gui.ManufWarrantyInfo
    Public Class frmCollectWrtyDateCode
        Inherits System.Windows.Forms.Form

        Private booReturnFlg As Boolean = False
        Private _iManufWrty As Integer = -1
        Private _strLastDateInWarranty As String = ""
        Private _iManufCountryID As Integer = 0
        Private _strDateCode As String = ""
        Private _strInputCode As String = ""
        Private _iManufID As Integer = 0

#Region "Properties"
        '********************************
        'Read only property
        '********************************
        Public ReadOnly Property ReturnFlg() As Boolean
            Get
                Return Me.booReturnFlg
            End Get
        End Property
        Public ReadOnly Property ManufWrty() As Integer
            Get
                Return Me._iManufWrty
            End Get
        End Property
        Public ReadOnly Property LastDateInWarranty() As String
            Get
                Return Me._strLastDateInWarranty
            End Get
        End Property
        Public ReadOnly Property ManufacturingCountryID() As Integer
            Get
                Return Me._iManufCountryID
            End Get
        End Property
        Public ReadOnly Property DateCode() As String
            Get
                Return Me._strDateCode
            End Get
        End Property
        Public ReadOnly Property Code() As String
            Get
                Return Me._strInputCode
            End Get
        End Property
#End Region

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iManufID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _iManufID = iManufID
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
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents txtDateCode As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtDateCode = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'txtDateCode
            '
            Me.txtDateCode.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDateCode.Location = New System.Drawing.Point(104, 8)
            Me.txtDateCode.MaxLength = 25
            Me.txtDateCode.Name = "txtDateCode"
            Me.txtDateCode.Size = New System.Drawing.Size(152, 23)
            Me.txtDateCode.TabIndex = 1
            Me.txtDateCode.Text = ""
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label4.Location = New System.Drawing.Point(8, 12)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(88, 16)
            Me.Label4.TabIndex = 71
            Me.Label4.Text = "Date Code:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.SteelBlue
            Me.btnOK.ForeColor = System.Drawing.Color.White
            Me.btnOK.Location = New System.Drawing.Point(144, 40)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(72, 24)
            Me.btnOK.TabIndex = 72
            Me.btnOK.Text = "OK"
            '
            'frmCollectWrtyDateCode
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(274, 70)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnOK, Me.txtDateCode, Me.Label4})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmCollectWrtyDateCode"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Warranty Data Collection"
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**************************************************************************
        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Try
                If Me._iManufID = 24 Then
                    If ProcessWarrantyCode_Nokia() Then
                        Me.booReturnFlg = True : Me.Close()
                    End If
                ElseIf _iManufID = 48 Then
                    If ProcessWarrantyCode_Huawei() Then
                        Me.booReturnFlg = True : Me.Close()
                    End If
                ElseIf _iManufID = 201 Then
                    If ProcessWarrantyCode_ZTE() Then
                        Me.booReturnFlg = True : Me.Close()
                    End If
                Else
                    MessageBox.Show("This function is not availble for selected manufacture.....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub txtDateCode_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDateCode.KeyUp
            Try
                If e.KeyValue = 13 Then
                    If Me._iManufID = 24 Then
                        If ProcessWarrantyCode_Nokia() Then
                            Me.booReturnFlg = True : Me.Close()
                        End If
                    ElseIf _iManufID = 48 Then 'Huawei
                        If ProcessWarrantyCode_Huawei() Then
                            Me.booReturnFlg = True : Me.Close()
                        End If
                    ElseIf _iManufID = 201 Then 'ZTE
                        If ProcessWarrantyCode_ZTE() Then
                            Me.booReturnFlg = True : Me.Close()
                        End If
                    Else
                        MessageBox.Show("This function is not availble for selected manufacture.....", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDateCode_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Function ProcessWarrantyCode_Nokia() As Boolean
            Dim strDateCode, strManufCountryChar As String
            Dim R1 As DataRow
            Dim iManufacturingCountryID As Integer = 0

            Try
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Nokia = False

                If Me.txtDateCode.Text.Trim.Length = 0 Then
                    Return False
                ElseIf Me.txtDateCode.Text.Trim.Length < 13 Then
                    MessageBox.Show("Date code must be at least 13 character.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Return False
                Else
                    strDateCode = "" : strManufCountryChar = ""

                    If Char.IsLetter(Me.txtDateCode.Text.Trim.Substring(7, 1), 0) = False Then
                        strDateCode = Me.txtDateCode.Text.Trim.Substring(7, 6)
                    Else
                        strDateCode = Me.txtDateCode.Text.Trim.Substring(7, 4)
                    End If
                    'strManufCountryChar = Me.txtDateCode.Text.Trim.Substring(13, 1)

                    R1 = PSS.Data.Buisness.WarrantyClaim.Nokia.GetWrtyStatusAndLastDateInWrty(strDateCode)
                    Me._iManufWrty = R1("WarrantyStatus")
                    Me._strLastDateInWarranty = CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd")
                    Me._iManufCountryID = 0 'PSS.Data.Buisness.WarrantyClaim.Nokia.GetManufacturingCountryID(strManufCountryChar)
                    Me._strDateCode = strDateCode
                    Me._strInputCode = Me.txtDateCode.Text.Trim
                    Me.booReturnFlg = True

                    ProcessWarrantyCode_Nokia = True
                    Return True
                End If

            Catch ex As Exception
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Nokia = False
                MessageBox.Show(ex.ToString, "ProcessWarrantyCode_Nokia()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessWarrantyCode_Huawei() As Boolean
            Dim strDateCode As String
            Dim R1 As DataRow

            Try
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Huawei = False

                If Me.txtDateCode.Text.Trim.Length = 0 Then
                    Return False
                Else
                    R1 = PSS.Data.Buisness.WarrantyClaim.Huawei.GetWrtyStatusAndLastDateInWrty(Me.txtDateCode.Text.Trim.ToUpper)
                    Me._iManufWrty = R1("WarrantyStatus")
                    Me._strLastDateInWarranty = CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd")
                    Me._iManufCountryID = 0
                    Me._strInputCode = Me.txtDateCode.Text.Trim.ToUpper
                    Me._strDateCode = Mid(Me.txtDateCode.Text.Trim.ToUpper, 7, 5)
                    Me.booReturnFlg = True

                    ProcessWarrantyCode_Huawei = True
                    Return True
                End If

            Catch ex As Exception
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_Huawei = False
                MessageBox.Show(ex.ToString, "ProcessWarrantyCode_Huawei()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '**************************************************************************
        Private Function ProcessWarrantyCode_ZTE() As Boolean
            Dim strDateCode As String
            Dim R1 As DataRow

            Try
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_ZTE = False

                If Me.txtDateCode.Text.Trim.Length = 0 Then
                    Return False
                Else
                    R1 = PSS.Data.Buisness.WarrantyClaim.ZTE.GetWrtyStatusAndLastDateInWrty(Me.txtDateCode.Text.Trim.ToUpper)
                    Me._iManufWrty = R1("WarrantyStatus")
                    Me._strLastDateInWarranty = CDate(R1("WarrantyCoverageByDate")).ToString("yyyy-MM-dd")
                    Me._iManufCountryID = 0
                    Me._strInputCode = Me.txtDateCode.Text.Trim.ToUpper
                    Me._strDateCode = Mid(Me.txtDateCode.Text.Trim.ToUpper, 5, 4)
                    Me.booReturnFlg = True

                    ProcessWarrantyCode_ZTE = True
                    Return True
                End If

            Catch ex As Exception
                Me.booReturnFlg = False
                Me._iManufWrty = -1
                Me._strLastDateInWarranty = ""
                Me._iManufCountryID = 0
                Me._strDateCode = ""
                Me._strInputCode = ""
                ProcessWarrantyCode_ZTE = False
                MessageBox.Show(ex.ToString, "ProcessWarrantyCode_ZTE()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Function

        '**************************************************************************

    End Class
End Namespace