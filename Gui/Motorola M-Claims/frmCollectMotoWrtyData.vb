Option Explicit On 

Namespace Gui.Motorola
    Public Class frmCollectMotoWrtyData
        Inherits System.Windows.Forms.Form

        Private objMclaim As PSS.Data.Buisness.WarrantyClaim.MClaim
        Private iModel_ID As Integer = 0
        Private iModelGSMFlg As Integer = 0
        Private booReturnFlg As Boolean = False
        Private iManufWrty As Integer = 0
        Private strAPC As String = ""
        Private strMSN As String = ""
        Private strCSN As String = ""
        Private strSugIn As String = ""
        Private strSoftVerIN As String = ""

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
                Return Me.iManufWrty
            End Get
        End Property
        Public ReadOnly Property APC() As String
            Get
                Return Me.strAPC
            End Get
        End Property
        Public ReadOnly Property MSN() As String
            Get
                Return Me.strMSN
            End Get
        End Property
        Public ReadOnly Property CSN() As String
            Get
                Return Me.strCSN
            End Get
        End Property
        Public ReadOnly Property SugIn() As String
            Get
                Return Me.strSugIn
            End Get
        End Property
        Public ReadOnly Property SoftVerIN() As String
            Get
                Return Me.strSoftVerIN
            End Get
        End Property

        Private Shared ctl As Control
        Private Shared HighLightColor As Color = Color.Yellow
        Private Shared WindowColor As Color = Color.White
        Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
        Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal iModID As Integer, ByVal iGSMFlg As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMclaim = New PSS.Data.Buisness.WarrantyClaim.MClaim()
            iModel_ID = iModID
            iModelGSMFlg = iGSMFlg

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
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtMSN As System.Windows.Forms.TextBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cmbSofwareVersion As PSS.Gui.Controls.ComboBox
        Friend WithEvents cmbSUG As PSS.Gui.Controls.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cmbSofwareVersion = New PSS.Gui.Controls.ComboBox()
            Me.cmbSUG = New PSS.Gui.Controls.ComboBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtMSN = New System.Windows.Forms.TextBox()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmbSofwareVersion, Me.cmbSUG, Me.Label2, Me.Label1, Me.txtMSN, Me.Label4})
            Me.Panel1.Location = New System.Drawing.Point(-1, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(305, 107)
            Me.Panel1.TabIndex = 1
            '
            'cmbSofwareVersion
            '
            Me.cmbSofwareVersion.AutoComplete = True
            Me.cmbSofwareVersion.Location = New System.Drawing.Point(128, 72)
            Me.cmbSofwareVersion.Name = "cmbSofwareVersion"
            Me.cmbSofwareVersion.Size = New System.Drawing.Size(152, 21)
            Me.cmbSofwareVersion.TabIndex = 3
            '
            'cmbSUG
            '
            Me.cmbSUG.AutoComplete = True
            Me.cmbSUG.Location = New System.Drawing.Point(128, 40)
            Me.cmbSUG.Name = "cmbSUG"
            Me.cmbSUG.Size = New System.Drawing.Size(152, 21)
            Me.cmbSUG.TabIndex = 2
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label2.Location = New System.Drawing.Point(8, 44)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(112, 16)
            Me.Label2.TabIndex = 78
            Me.Label2.Text = "SJUG Number:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(8, 75)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(112, 16)
            Me.Label1.TabIndex = 75
            Me.Label1.Text = "Software Ver:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtMSN
            '
            Me.txtMSN.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtMSN.Location = New System.Drawing.Point(128, 8)
            Me.txtMSN.MaxLength = 11
            Me.txtMSN.Name = "txtMSN"
            Me.txtMSN.Size = New System.Drawing.Size(152, 23)
            Me.txtMSN.TabIndex = 1
            Me.txtMSN.Text = ""
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label4.Location = New System.Drawing.Point(8, 12)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(112, 16)
            Me.Label4.TabIndex = 71
            Me.Label4.Text = "MSN/CSN:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'frmCollectMotoWrtyData
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(304, 107)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1})
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmCollectMotoWrtyData"
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Motorola Warranty Data Collection"
            Me.Panel1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*******************************************************************
        Protected Overrides Sub Finalize()
            If Not IsNothing(objMclaim) Then
                objMclaim = Nothing
            End If
            MyBase.Finalize()
        End Sub

        '*******************************************************************
        Private Shared Sub SetHandler(ByVal ctl As Control)
            AddHandler ctl.Enter, EnterHandler
            AddHandler ctl.Leave, LeaveHandler
            AddHandler ctl.Click, EnterHandler
        End Sub

        '*******************************************************************
        Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
            Change_Color(sender, HighLightColor)
        End Sub

        '*******************************************************************
        Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
            Change_Color(sender, WindowColor)
        End Sub

        '*******************************************************************
        Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
            Dim Type As String = sender.GetType.Name.ToString

            Select Case Type
                Case "ComboBox"
                    CType(sender, ComboBox).BackColor = color
                Case "TextBox"
                    CType(sender, TextBox).BackColor = color
                Case Else
                    'no other types should be hightlighted.

            End Select
        End Sub

        '*******************************************************************
        Private Sub frmCollectMotoWrtyData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                SetHandler(Me.txtMSN)
                SetHandler(Me.cmbSUG)
                SetHandler(Me.cmbSofwareVersion)

                objMclaim.GetMotoSUGNumbers(iModel_ID, 1, Me.cmbSUG)
                objMclaim.GetMotoSoftwareVersion(iModel_ID, 1, Me.cmbSofwareVersion)

                Me.txtMSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Function checkOEMwrty_Motorola(ByVal strCode As String, _
                                               ByVal iGSMFlag As Integer) As Integer
            '//Check Data
            Dim strYearDigit As String
            Dim strYear As String
            Dim strMonthDigit As String
            Dim strMonth As String
            Dim strWrtyPeriodDigit As String
            Dim strWrtyPeriod As String
            Dim iInvalidYr As Integer = 0
            Dim dateManufDate As Date
            Dim strDateExp As String = ""
            Dim strToday As Date = Format(Now, "yyyy-MM-dd")

            Try
                If iGSMFlag = 1 Then
                    strYearDigit = UCase(Mid(strCode, 5, 1))
                    strMonthDigit = UCase(Mid(strCode, 6, 1))
                Else
                    strYearDigit = UCase(Mid(strCode, 9, 1))
                    strMonthDigit = UCase(Mid(strCode, 10, 1))
                End If


                Select Case strYearDigit
                    Case "A"
                        strYear = "2000"
                    Case "B"
                        strYear = "2001"
                    Case "C"
                        strYear = "2002"
                    Case "D"
                        strYear = "2003"
                    Case "E"
                        strYear = "2004"
                    Case "F"
                        strYear = "2005"
                    Case "G"
                        strYear = "2006"
                    Case "H"
                        strYear = "2007"

                        'Case "I"

                    Case "J"
                        strYear = "2008"
                        iInvalidYr = 1
                    Case "K"
                        strYear = "2009"
                        iInvalidYr = 1
                    Case "L"
                        strYear = "2010"
                        iInvalidYr = 1
                    Case "M"
                        strYear = "2011"
                        iInvalidYr = 1
                    Case "N"
                        strYear = "2012"
                        iInvalidYr = 1
                    Case Else
                        strYear = "1900"
                        iInvalidYr = 1
                End Select

                Select Case strMonthDigit
                    Case "A"
                        strMonth = "1"
                    Case "B"
                        strMonth = "1"
                    Case "C"
                        strMonth = "2"
                    Case "D"
                        strMonth = "2"
                    Case "E"
                        strMonth = "3"
                    Case "F"
                        strMonth = "3"
                    Case "G"
                        strMonth = "4"
                    Case "H"
                        strMonth = "4"
                    Case "J"
                        strMonth = "5"
                    Case "K"
                        strMonth = "5"
                    Case "L"
                        strMonth = "6"
                    Case "M"
                        strMonth = "6"
                    Case "N"
                        strMonth = "7"
                    Case "P"
                        strMonth = "7"
                    Case "Q"
                        strMonth = "8"
                    Case "R"
                        strMonth = "8"
                    Case "S"
                        strMonth = "9"
                    Case "T"
                        strMonth = "9"
                    Case "U"
                        strMonth = "10"
                    Case "V"
                        strMonth = "10"
                    Case "W"
                        strMonth = "11"
                    Case "X"
                        strMonth = "11"
                    Case "Y"
                        strMonth = "12"
                    Case "Z"
                        strMonth = "12"
                    Case Else
                        strMonth = "1"
                        iInvalidYr = 1
                End Select

                If Len(Trim(strCode)) > 10 Then
                    strWrtyPeriodDigit = UCase(Mid(strCode, 11, 1))
                    Select Case strWrtyPeriodDigit
                        Case "A"
                            strWrtyPeriod = "365"
                        Case "B"
                            strWrtyPeriod = "1095"
                        Case "C"
                            strWrtyPeriod = "1825"
                        Case "D"
                            strWrtyPeriod = "1095"
                        Case "E"
                            strWrtyPeriod = "0"
                        Case "F"
                            strWrtyPeriod = "90"
                        Case "H"                    '3 yrs, Cannada only
                            'strWrtyPeriod = "1095"
                            strWrtyPeriod = "0"
                        Case "J"
                            strWrtyPeriod = "365"
                        Case "L"
                            strWrtyPeriod = "365"
                        Case "M"
                            strWrtyPeriod = "365"
                        Case "N"
                            strWrtyPeriod = "1825"
                        Case "P"
                            strWrtyPeriod = "1825"
                        Case "Q"
                            strWrtyPeriod = "1095"
                        Case "R"
                            strWrtyPeriod = "1095"
                        Case "S"
                            strWrtyPeriod = "1095"
                        Case "T"                    'OEM telephone(serviced by dealers only)
                            strWrtyPeriod = "0"
                        Case "U"
                            strWrtyPeriod = "90"
                        Case "W"
                            strWrtyPeriod = "1460"
                        Case "X"
                            strWrtyPeriod = "1825"
                        Case "Y"
                            strWrtyPeriod = "1095"
                        Case "Z"
                            strWrtyPeriod = "1095"
                        Case Else
                            strWrtyPeriod = "365"
                    End Select
                Else
                    strWrtyPeriod = "365"
                End If

                dateManufDate = strMonth & "/1/" & strYear
                strDateExp = DateAdd(DateInterval.Day, CInt(strWrtyPeriod), dateManufDate)

                If iInvalidYr = 1 Then
                    Return 0    'no warranty
                ElseIf strToday < strDateExp Then
                    Return 1    'warranty
                Else
                    Return 0    'no warranty
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        '**************************************************************************
        Private Sub txtMSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMSN.KeyUp

            Try
                If e.KeyValue = 13 Then
                    If Trim(Me.txtMSN.Text) = "" Then
                        Exit Sub
                    End If

                    '*********************
                    'Validate MSN/CSN
                    '*********************
                    Me.iManufWrty = 0
                    Me.strAPC = ""
                    Me.strMSN = ""
                    Me.strCSN = ""
                    Me.strSugIn = ""
                    Me.strSoftVerIN = ""
                    Me.strMSN = UCase(Trim(Me.txtMSN.Text))

                    If Me.iModelGSMFlg = 1 Then
                        If Len(Me.strMSN) <> 10 Then
                            MessageBox.Show("MSN length must be 10 characters.", "Validate MSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If

                        '********************
                        'Validate APC
                        '********************
                        Me.strAPC = Microsoft.VisualBasic.Left(Me.strMSN, 3)
                        If IsNumeric(Microsoft.VisualBasic.Left(Me.strAPC, 1)) Then
                            MessageBox.Show("The first character of MSN must be alphabet.", "Validate MSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                        If Not IsNumeric(Microsoft.VisualBasic.Right(Me.strAPC, 2)) Then
                            MessageBox.Show("The 2nd and 3rd character of MSN must be number.", "Validate MSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Else
                        If Len(Me.strMSN) <> 11 Then
                            MessageBox.Show("CSN length must be 8 characters.", "Validate CSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    End If

                    '************************
                    'Check Warranty 
                    '************************
                    Me.iManufWrty = Me.checkOEMwrty_Motorola(Me.strMSN, Me.iModelGSMFlg)
                    If Me.iManufWrty = 0 Then
                        Me.strMSN = ""
                        Me.strAPC = ""
                        Me.booReturnFlg = True
                        Me.Close()
                    Else
                        If Me.iModelGSMFlg = 0 Then
                            Me.strCSN = Me.strMSN
                            Me.strMSN = ""
                        End If
                    End If
                    Me.cmbSUG.Focus()

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "MSN KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '**************************************************************************
        Private Sub cmbSUG_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSUG.SelectionChangeCommitted
            If Me.cmbSUG.SelectedValue > 0 Then
                Me.strSugIn = UCase(Trim(Me.cmbSUG.SelectedItem(Me.cmbSUG.DisplayMember)))
                Me.cmbSofwareVersion.Focus()
            End If
        End Sub

        '**************************************************************************
        Private Sub cmbSUG_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSUG.KeyUp
            If Me.cmbSUG.SelectedValue > 0 Then
                Me.strSugIn = UCase(Trim(Me.cmbSUG.SelectedItem(Me.cmbSUG.DisplayMember)))
                Me.cmbSofwareVersion.Focus()
            End If
        End Sub

        '**************************************************************************
        Private Sub cmbSofwareVersion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSofwareVersion.SelectionChangeCommitted
            If Me.cmbSUG.SelectedValue = 0 Then
                Exit Sub
            End If
            If Me.cmbSofwareVersion.SelectedValue > 0 Then
                Me.strSoftVerIN = UCase(Trim(Me.cmbSofwareVersion.SelectedItem(Me.cmbSofwareVersion.DisplayMember)))

                If Me.txtMSN.Text <> "" Then
                    Me.booReturnFlg = True
                    Me.Close()
                End If
            End If
        End Sub

        '**************************************************************************
        Private Sub cmbSofwareVersion_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSofwareVersion.KeyUp
            If Me.cmbSUG.SelectedValue = 0 Then
                Exit Sub
            End If
            If Me.cmbSofwareVersion.SelectedValue > 0 Then
                Me.strSoftVerIN = UCase(Trim(Me.cmbSofwareVersion.SelectedItem(Me.cmbSofwareVersion.DisplayMember)))
                If Me.txtMSN.Text <> "" Then
                    Me.booReturnFlg = True
                    Me.Close()
                End If
            End If
        End Sub

        '**************************************************************************
    End Class
End Namespace