Namespace Gui.Billing
    Public Class frmDBRReason
        Inherits System.Windows.Forms.Form
        Private objMisc As PSS.Data.Buisness.Misc
        Private dtDBR As DataTable = Nothing
        Private R1 As DataRow = Nothing
        Private iPrevDcodeID As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMisc = New PSS.Data.Buisness.Misc()
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
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboDBRReasons As PSS.Gui.Controls.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboDBRReasons = New PSS.Gui.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'btnOK
            '
            Me.btnOK.BackColor = System.Drawing.Color.Transparent
            Me.btnOK.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOK.ForeColor = System.Drawing.Color.Black
            Me.btnOK.Location = New System.Drawing.Point(136, 112)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(75, 24)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "OK"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(19, 19)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(104, 11)
            Me.Label2.TabIndex = 10
            Me.Label2.Text = "DBR Reason:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboDBRReasons
            '
            Me.cboDBRReasons.AutoComplete = True
            Me.cboDBRReasons.Location = New System.Drawing.Point(32, 31)
            Me.cboDBRReasons.Name = "cboDBRReasons"
            Me.cboDBRReasons.Size = New System.Drawing.Size(288, 21)
            Me.cboDBRReasons.TabIndex = 1
            '
            'frmDBRReason
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.Thistle
            Me.ClientSize = New System.Drawing.Size(350, 155)
            Me.ControlBox = False
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboDBRReasons, Me.Label2, Me.btnOK})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
            Me.Name = "frmDBRReason"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "DBR Reason"
            Me.ResumeLayout(False)

        End Sub

#End Region
        '*************************************************************************
        Private Shared iDBRCode As Integer = 0
        Public Shared Property DBRCode() As Integer
            Get
                Return iDBRCode
            End Get
            Set(ByVal Value As Integer)
                iDBRCode = Value
            End Set
        End Property
        '*************************************************************************
        Private Shared iCust_ID As Integer = 0
        Public Shared Property CustID() As Integer
            Get
                Return iCust_ID
            End Get
            Set(ByVal Value As Integer)
                iCust_ID = Value
            End Set
        End Property
        '*************************************************************************
        Private Shared iDevice_ID As Integer = 0
        Public Shared Property DeviceID() As Integer
            Get
                Return iDevice_ID
            End Get
            Set(ByVal Value As Integer)
                iDevice_ID = Value
            End Set
        End Property
        '*************************************************************************
        Private Sub frmDBRReason_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            GetPrevDBR()
            LoadDBRCodes()
            Me.cboDBRReasons.Focus()
        End Sub
        '*************************************************************************
        Private Sub GetPrevDBR()
            iPrevDcodeID = 0
            iPrevDcodeID = objMisc.GetPrevDBR(Me.DeviceID)
        End Sub
        '*************************************************************************
        Private Sub LoadDBRCodes()
            Try
                dtDBR = objMisc.GetDBRCodes
                Me.cboDBRReasons.DataSource = dtDBR.DefaultView
                Me.cboDBRReasons.DisplayMember = dtDBR.Columns("DispalyDesc").ToString
                Me.cboDBRReasons.ValueMember = dtDBR.Columns("Dcode_ID").ToString
                Me.cboDBRReasons.SelectedValue = 0   'Empty Row      0 is a Magoc number :)
            Catch ex As Exception
                objMisc.DisposeDT(dtDBR)
                MessageBox("Error in frmDBRReason.LoadDBRCodes:: " & ex.Message.ToString)
            End Try
        End Sub
        '*************************************************************************
        Protected Overrides Sub Finalize()
            objMisc.DisposeDT(dtDBR)
            objMisc = Nothing
            MyBase.Finalize()
        End Sub
        '*************************************************************************
        Private Sub MessageBox(ByVal strMsg As String, _
                                Optional ByVal iLevel As Integer = 0, _
                                Optional ByVal strheading As String = "PSS.NET")
            Select Case iLevel
                Case 1      'Critical
                    MsgBox(strMsg, MsgBoxStyle.Critical, strheading)
                Case 2
                    'Add a different level here
                Case 3
                    'Add a different level here
                Case Else
                    MsgBox(strMsg, MsgBoxStyle.Information, strheading)
            End Select

        End Sub

        '*************************************************************************

        Private Sub KeyDownInControls(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboDBRReasons.KeyUp
            If e.KeyValue = 13 Then        'Enter Key
                SaveDBR()
                'ElseIf e.KeyValue = 49 Then
                '    Me.cboDBRReasons.SelectedValue = 1
                'ElseIf e.KeyValue = 50 Then
                '    Me.cboDBRReasons.SelectedValue = 2
                'ElseIf e.KeyValue = 51 Then
                '    Me.cboDBRReasons.Text = ""
                '    Me.cboDBRReasons.SelectedValue = 3
                '    Me.cboDBRReasons.Refresh()
                'ElseIf e.KeyValue = 52 Then
                '    Me.cboDBRReasons.SelectedValue = 4
                'ElseIf e.KeyValue = 53 Then
                '    Me.cboDBRReasons.SelectedValue = 5
                'ElseIf e.KeyValue = 54 Then
                '    Me.cboDBRReasons.SelectedValue = 6
                'ElseIf e.KeyValue = 55 Then
                '    Me.cboDBRReasons.SelectedValue = 7
                'ElseIf e.KeyValue = 56 Then
                '    Me.cboDBRReasons.SelectedValue = 8
            End If
        End Sub
        '*************************************************************************
        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            SaveDBR()
        End Sub
        '*************************************************************************
        Private Sub SaveDBR()
            If Me.cboDBRReasons.SelectedValue = 0 Then
                MessageBox("Please select a DBR Reason.")
                Exit Sub
            Else
                Me.DBRCode = Me.cboDBRReasons.SelectedValue
                Me.Close()
            End If
        End Sub
        '*************************************************************************
        Public Function DeleteDBRCode() As Integer
            Return objMisc.DeleteDBRCode(Me.DeviceID, Me.DBRCode)
        End Function
        '*************************************************************************
        Public Function UPD() As Integer
            Return objMisc.UPD(Me.DeviceID, Me.DBRCode)
        End Function
        '*************************************************************************

    End Class
End Namespace