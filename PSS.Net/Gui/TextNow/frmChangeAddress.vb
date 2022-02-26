Option Explicit On 

Imports PSS.Data.Buisness

Public Class frmChangeAddress
    Inherits System.Windows.Forms.Form

    Private _strShipFullName As String = ""
    Private _strAddress1 As String = ""
    Private _strAddress2 As String = ""
    Private _strCity As String = ""
    Private _strState As String = ""
    Private _strZipCode As String = ""
    Private _strCountry As String = ""
    Private _strNote As String = ""

    Private _strOldAddressInfo As String = ""
    Private _strNewAddressInfo As String = ""
    Private _iCust_ID As Integer = 0
    Private _iSoHeaderID As Integer = 0

    Private _bAddressChanged As Boolean = False
    Private _UserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private _objTN As TN

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iCust_ID As Integer, ByVal iSoHeaderID As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._iCust_ID = iCust_ID
        Me._iSoHeaderID = iSoHeaderID
        Me._objTN = New TN()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            Try
                Me._objTN = Nothing
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
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents txtZipCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCoutry As System.Windows.Forms.TextBox
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.txtZipCode = New System.Windows.Forms.TextBox()
        Me.txtCoutry = New System.Windows.Forms.TextBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtNote
        '
        Me.txtNote.BackColor = System.Drawing.Color.White
        Me.txtNote.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtNote.Location = New System.Drawing.Point(136, 256)
        Me.txtNote.MaxLength = 200
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(248, 56)
        Me.txtNote.TabIndex = 153
        Me.txtNote.Text = ""
        '
        'txtZipCode
        '
        Me.txtZipCode.BackColor = System.Drawing.Color.White
        Me.txtZipCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtZipCode.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtZipCode.Location = New System.Drawing.Point(136, 192)
        Me.txtZipCode.Name = "txtZipCode"
        Me.txtZipCode.Size = New System.Drawing.Size(248, 22)
        Me.txtZipCode.TabIndex = 151
        Me.txtZipCode.Text = ""
        '
        'txtCoutry
        '
        Me.txtCoutry.BackColor = System.Drawing.Color.White
        Me.txtCoutry.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCoutry.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCoutry.Location = New System.Drawing.Point(136, 224)
        Me.txtCoutry.Name = "txtCoutry"
        Me.txtCoutry.Size = New System.Drawing.Size(248, 22)
        Me.txtCoutry.TabIndex = 152
        Me.txtCoutry.Text = ""
        '
        'txtState
        '
        Me.txtState.BackColor = System.Drawing.Color.White
        Me.txtState.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtState.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtState.Location = New System.Drawing.Point(136, 160)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(248, 22)
        Me.txtState.TabIndex = 150
        Me.txtState.Text = ""
        '
        'txtCity
        '
        Me.txtCity.BackColor = System.Drawing.Color.White
        Me.txtCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtCity.Location = New System.Drawing.Point(136, 128)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(248, 22)
        Me.txtCity.TabIndex = 149
        Me.txtCity.Text = ""
        '
        'txtAddress2
        '
        Me.txtAddress2.BackColor = System.Drawing.Color.White
        Me.txtAddress2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtAddress2.Location = New System.Drawing.Point(136, 96)
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.Size = New System.Drawing.Size(248, 22)
        Me.txtAddress2.TabIndex = 148
        Me.txtAddress2.Text = ""
        '
        'txtAddress1
        '
        Me.txtAddress1.BackColor = System.Drawing.Color.White
        Me.txtAddress1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtAddress1.Location = New System.Drawing.Point(136, 64)
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.Size = New System.Drawing.Size(248, 22)
        Me.txtAddress1.TabIndex = 147
        Me.txtAddress1.Text = ""
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label12.Location = New System.Drawing.Point(0, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(304, 16)
        Me.Label12.TabIndex = 154
        Me.Label12.Text = "Change Address Info"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(64, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(64, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 156
        Me.Label2.Text = "Address 1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(64, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "Address 2"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(64, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 158
        Me.Label4.Text = "City"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(64, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 159
        Me.Label5.Text = "State"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtName
        '
        Me.txtName.BackColor = System.Drawing.Color.White
        Me.txtName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.ForeColor = System.Drawing.SystemColors.Desktop
        Me.txtName.Location = New System.Drawing.Point(136, 32)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(248, 22)
        Me.txtName.TabIndex = 160
        Me.txtName.Text = ""
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(8, 256)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 16)
        Me.Label6.TabIndex = 161
        Me.Label6.Text = "Note for the Change"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(64, 224)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 162
        Me.Label7.Text = "Country"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(64, 192)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "Zip Code"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(264, 328)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 40)
        Me.btnSave.TabIndex = 164
        Me.btnSave.Text = "Save "
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(136, 328)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 40)
        Me.btnCancel.TabIndex = 165
        Me.btnCancel.Text = "Cancel"
        '
        'frmChangeAddress
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(456, 398)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnSave, Me.Label8, Me.Label7, Me.Label6, Me.txtName, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.Label12, Me.txtNote, Me.txtZipCode, Me.txtCoutry, Me.txtState, Me.txtCity, Me.txtAddress2, Me.txtAddress1})
        Me.Name = "frmChangeAddress"
        Me.Text = "Change Address"
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Property"
    Public ReadOnly Property IsAddressInfoChanged() As Boolean
        Get
            Return Me._bAddressChanged
        End Get

    End Property
    Public Property ShipFullName() As String
        Get
            Return Me._strShipFullName
        End Get
        Set(ByVal Value As String)
            Me._strShipFullName = Value
        End Set
    End Property
    Public Property Address1() As String
        Get
            Return Me._strAddress1
        End Get
        Set(ByVal Value As String)
            Me._strAddress1 = Value
        End Set
    End Property
    Public Property Address2() As String
        Get
            Return Me._strAddress2
        End Get
        Set(ByVal Value As String)
            Me._strAddress2 = Value
        End Set
    End Property
    Public Property City() As String
        Get
            Return Me._strCity
        End Get
        Set(ByVal Value As String)
            Me._strCity = Value
        End Set
    End Property
    Public Property State() As String
        Get
            Return Me._strState
        End Get
        Set(ByVal Value As String)
            Me._strState = Value
        End Set
    End Property
    Public Property ZipCode() As String
        Get
            Return Me._strZipCode
        End Get
        Set(ByVal Value As String)
            Me._strZipCode = Value
        End Set
    End Property
    Public Property Country() As String
        Get
            Return Me._strCountry
        End Get
        Set(ByVal Value As String)
            Me._strCountry = Value
        End Set
    End Property
#End Region

    Private Sub frmChangeAddress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

            Me.CenterToScreen()
            PSS.Core.Highlight.SetHighLight(Me)

            With Me
                .txtName.Text = ._strShipFullName.Trim
                .txtAddress1.Text = ._strAddress1.Trim
                .txtAddress2.Text = ._strAddress2.Trim
                .txtCity.Text = ._strCity.Trim
                .txtState.Text = ._strState.Trim
                .txtZipCode.Text = ._strZipCode.Trim
                .txtCoutry.Text = ._strCountry.Trim

                ._strOldAddressInfo = .txtName.Text.Trim
                ._strOldAddressInfo &= .txtAddress1.Text.Trim
                ._strOldAddressInfo &= .txtAddress2.Text.Trim
                ._strOldAddressInfo &= .txtCity.Text.Trim
                ._strOldAddressInfo &= .txtState.Text.Trim
                _strOldAddressInfo &= .txtZipCode.Text.Trim
                ._strOldAddressInfo &= .txtCoutry.Text.Trim
            End With
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub frmChangeAddress_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function IsAddressChanged() As Boolean
        Try
            Me._strNewAddressInfo = Me.txtName.Text.Trim
            Me._strNewAddressInfo &= Me.txtAddress1.Text.Trim
            Me._strNewAddressInfo &= Me.txtAddress2.Text.Trim
            Me._strNewAddressInfo &= Me.txtCity.Text.Trim
            Me._strNewAddressInfo &= Me.txtState.Text.Trim
            Me._strNewAddressInfo &= Me.txtZipCode.Text.Trim
            Me._strNewAddressInfo &= Me.txtCoutry.Text.Trim
            If Not Me._strOldAddressInfo.Trim.ToUpper = Me._strNewAddressInfo.Trim.ToUpper Then
                Return True
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Function IsAddressChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me._bAddressChanged = False
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim i As Integer = 0
        Try
            If Me.IsAddressChanged Then
                i = Me._objTN.UpdateAddressInfo(Me._iSoHeaderID, Me._iCust_ID, Me.txtName.Text.Trim, "", Me.txtAddress1.Text.Trim, Me.txtAddress2.Text.Trim, "", _
                                  Me.txtCity.Text.Trim, Me.txtState.Text.Trim, Me.txtZipCode.Text.Trim, Me.txtCoutry.Text.Trim, Me._UserID, _
                                  Format(Now, "yyyy-MM-dd HH:mm:ss"), Me.txtNote.Text.Trim)
                If Not i > 0 Then
                    MessageBox.Show("Failed to change. See IT.", "Pack Screen", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Else
                    Me._strShipFullName = Me.txtName.Text.Trim
                    Me._strAddress1 = Me.txtAddress1.Text.Trim
                    Me._strAddress2 = Me.txtAddress2.Text.Trim
                    Me._strCity = Me.txtCity.Text.Trim
                    Me._strState = Me.txtState.Text.Trim
                    Me._strZipCode = Me.txtZipCode.Text.Trim
                    Me._strCountry = Me.txtCoutry.Text.Trim

                    Me._bAddressChanged = True
                    Me.Close()
                End If
            Else
                MessageBox.Show("No changes!", "Address Change Screen", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Sub btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
