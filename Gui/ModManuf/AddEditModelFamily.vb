Imports PSS.Rules

Namespace Gui
    Public Class AddEditModelFamily
        Inherits System.Windows.Forms.Form

        Dim _bAddModelFamily As Boolean
        Dim _iModelFamilyID As Integer
        Dim _strModelFamily As String
        Dim _bCancel As Boolean = True

        Public Sub New(ByVal bAddModelFamily As Boolean, ByVal iModelFamilyID As Integer, ByVal strModelFamily As String)
            Try
                InitializeComponent()

                Me._bAddModelFamily = bAddModelFamily
                Me._iModelFamilyID = iModelFamilyID
                Me._strModelFamily = strModelFamily
            Catch ex As Exception
                MsgBox("Error in AddEditModelFamily.New(). " & ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

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
        Friend WithEvents txtModelFamily As System.Windows.Forms.TextBox
        Friend WithEvents lblModelFamily As System.Windows.Forms.Label
        Friend WithEvents btnUpdate As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtModelFamily = New System.Windows.Forms.TextBox()
            Me.lblModelFamily = New System.Windows.Forms.Label()
            Me.btnUpdate = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'txtModelFamily
            '
            Me.txtModelFamily.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtModelFamily.Location = New System.Drawing.Point(0, 24)
            Me.txtModelFamily.Name = "txtModelFamily"
            Me.txtModelFamily.Size = New System.Drawing.Size(136, 20)
            Me.txtModelFamily.TabIndex = 95
            Me.txtModelFamily.Text = ""
            '
            'lblModelFamily
            '
            Me.lblModelFamily.Location = New System.Drawing.Point(0, 8)
            Me.lblModelFamily.Name = "lblModelFamily"
            Me.lblModelFamily.Size = New System.Drawing.Size(120, 16)
            Me.lblModelFamily.TabIndex = 96
            Me.lblModelFamily.Text = "Model Family"
            '
            'btnUpdate
            '
            Me.btnUpdate.BackColor = System.Drawing.Color.SteelBlue
            Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnUpdate.ForeColor = System.Drawing.Color.White
            Me.btnUpdate.Location = New System.Drawing.Point(16, 80)
            Me.btnUpdate.Name = "btnUpdate"
            Me.btnUpdate.Size = New System.Drawing.Size(88, 32)
            Me.btnUpdate.TabIndex = 97
            Me.btnUpdate.Text = "Update"
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.White
            Me.btnCancel.Location = New System.Drawing.Point(136, 80)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(88, 32)
            Me.btnCancel.TabIndex = 98
            Me.btnCancel.Text = "Cancel"
            '
            'AddEditModelFamily
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(240, 126)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancel, Me.btnUpdate, Me.lblModelFamily, Me.txtModelFamily})
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AddEditModelFamily"
            Me.Text = "AddEditModelFamily"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub AddEditModelFamily_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                Me.Text = String.Format("{0} Model Family", IIf(Me._bAddModelFamily, "Add", "Edit"))
                Me.txtModelFamily.Text = Me._strModelFamily
                'LoadCustomers()
            Catch ex As Exception
                MsgBox("Error in AddEditModelFamily_Load(). " & ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        'Private Sub LoadCustomers()
        '    Dim dt As DataTable
        '    Dim i As Integer

        '    Try
        '        Me.cboCustomer.DataSource = Nothing

        '        dt = ModManuf.GetCustomers()

        '        If dt.Rows.Count > 0 Then
        '            Misc.PopulateC1DropDownList(Me.cboCustomer, dt, "Customer", "CustomerID")
        '            'Me.cboCustomer.DataSource = dt.DefaultView
        '            'Me.cboCustomer.DisplayMember = "Customer"
        '            'Me.cboCustomer.ValueMember = "CustomerID"
        '            'Me.cboCustomer.Splits(0).DisplayColumns("CustomerID").Visible = False

        '            If Me._strCustomer.Equals(String.Empty) Then
        '                Me.cboCustomer.SelectedIndex = -1
        '                Me.cboCustomer.Enabled = True
        '            Else
        '                For i = 0 To Me.cboCustomer.ListCount - 1
        '                    Me.cboCustomer.SelectedIndex = i

        '                    If Me.cboCustomer.Columns(0).Text.Equals(Me._strCustomer) Then Exit For
        '                Next i

        '                Me.cboCustomer.Enabled = False
        '            End If
        '        End If
        '    Catch ex As Exception
        '        Throw ex
        '    Finally
        '        If Not IsNothing(dt) Then
        '            dt.Dispose()
        '            dt = Nothing
        '        End If
        '    End Try
        'End Sub

        Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            Try
                'If Me.cboCustomer.SelectedIndex = -1 Then
                '    MsgBox("You must select a customer.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                If Me.txtModelFamily.Text.Trim.Length = 0 Then
                    MsgBox("Model family cannot be empty.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                Else
                    Dim strModelFamily As String = Me.txtModelFamily.Text.Trim
                    'Dim iCustomerID As Integer = Convert.ToInt32(Me.cboCustomer.SelectedValue)
                    Dim bExists As Boolean

                    If Me._bAddModelFamily Then
                        bExists = ModManuf.CheckExisitingModelFamilies(strModelFamily)

                        If bExists Then
                            MsgBox("This model family already exists.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                        Else
                            ModManuf.AddNewModelFamily(strModelFamily)

                            MsgBox("Model family added succesfully.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")

                            Me._bCancel = False
                            Me.Close()
                        End If
                    Else
                        bExists = ModManuf.CheckExisitingModelFamilies(Me._strModelFamily)

                        If Not bExists Then
                            MsgBox("The original model family combination cannot be found.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                        Else
                            ModManuf.UpdateModelFamily(Me._strModelFamily, strModelFamily)

                            Me._bCancel = False
                            Me.Close()
                        End If
                    End If
                End If
            Catch ex As Exception
                MsgBox("Error in btnUpdate_Click(). " & ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        Public ReadOnly Property CancelProcess()
            Get
                Return Me._bCancel
            End Get
        End Property
    End Class
End Namespace
