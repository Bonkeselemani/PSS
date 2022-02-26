Public Class frmModelConfirm
    Inherits System.Windows.Forms.Form

    '    Private _dt As DataTable
    '    Private _strHeader As String = ""
    '    Private _strSelectedModel As String = ""
    '    Private _iSelectedModelID As Integer = 0
    '    Private _arrAllowedUserNames As String = ""
    '    Private _arrAllowedUID As New ArrayList()
    '    Private _arrAllowedPW As New ArrayList()
    '    Private _strScreenSysName As String = "NI-ModelApproval"

    '#Region " Windows Form Designer generated code "

    '    Public Sub New(ByVal strHeader As String, ByVal dt As DataTable, _
    '                   ByVal strSelectedModel As String, ByVal iSelectedModelID As Integer)
    '        MyBase.New()

    '        'This call is required by the Windows Form Designer.
    '        InitializeComponent()

    '        'Add any initialization after the InitializeComponent() call
    '        Me._dt = dt
    '        Me._strHeader = strHeader
    '        Me._strSelectedModel = strSelectedModel
    '        Me._iSelectedModelID = iSelectedModelID
    '    End Sub

    '    'Form overrides dispose to clean up the component list.
    '    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    '        If disposing Then
    '            If Not (components Is Nothing) Then
    '                components.Dispose()
    '            End If
    '        End If
    '        MyBase.Dispose(disposing)
    '    End Sub

    '    'Required by the Windows Form Designer
    '    Private components As System.ComponentModel.IContainer

    '    'NOTE: The following procedure is required by the Windows Form Designer
    '    'It can be modified using the Windows Form Designer.  
    '    'Do not modify it using the code editor.
    '    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    '    Friend WithEvents lblPass As System.Windows.Forms.Label
    '    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    '    Friend WithEvents lblUser As System.Windows.Forms.Label
    '    Friend WithEvents btnApprovalOK As System.Windows.Forms.Button
    '    Friend WithEvents btnApprovalCancel As System.Windows.Forms.Button
    '    Friend WithEvents lblHeader As System.Windows.Forms.Label
    '    Friend WithEvents tdgData As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    '    Friend WithEvents lblSelectedModelLabel As System.Windows.Forms.Label
    '    Friend WithEvents lblSelectModel As System.Windows.Forms.Label
    '    Friend WithEvents lblSelectedModelID As System.Windows.Forms.Label
    '    Friend WithEvents pnlSecurity As System.Windows.Forms.Panel
    '    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmModelConfirm))
    '        Me.tdgData = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
    '        Me.txtPass = New System.Windows.Forms.TextBox()
    '        Me.lblPass = New System.Windows.Forms.Label()
    '        Me.txtUser = New System.Windows.Forms.TextBox()
    '        Me.lblUser = New System.Windows.Forms.Label()
    '        Me.pnlSecurity = New System.Windows.Forms.Panel()
    '        Me.btnApprovalOK = New System.Windows.Forms.Button()
    '        Me.btnApprovalCancel = New System.Windows.Forms.Button()
    '        Me.lblHeader = New System.Windows.Forms.Label()
    '        Me.lblSelectedModelLabel = New System.Windows.Forms.Label()
    '        Me.lblSelectModel = New System.Windows.Forms.Label()
    '        Me.lblSelectedModelID = New System.Windows.Forms.Label()
    '        CType(Me.tdgData, System.ComponentModel.ISupportInitialize).BeginInit()
    '        Me.pnlSecurity.SuspendLayout()
    '        Me.SuspendLayout()
    '        '
    '        'tdgData
    '        '
    '        Me.tdgData.AllowColMove = False
    '        Me.tdgData.AllowColSelect = False
    '        Me.tdgData.AllowFilter = False
    '        Me.tdgData.AllowSort = False
    '        Me.tdgData.AllowUpdate = False
    '        Me.tdgData.AlternatingRows = True
    '        Me.tdgData.BackColor = System.Drawing.Color.GhostWhite
    '        Me.tdgData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    '        Me.tdgData.Caption = "EDI Required Product/Model"
    '        Me.tdgData.CaptionHeight = 17
    '        Me.tdgData.FetchRowStyles = True
    '        Me.tdgData.GroupByCaption = "Drag a column header here to group by that column"
    '        Me.tdgData.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
    '        Me.tdgData.Location = New System.Drawing.Point(16, 48)
    '        Me.tdgData.Name = "tdgData"
    '        Me.tdgData.PreviewInfo.Location = New System.Drawing.Point(0, 0)
    '        Me.tdgData.PreviewInfo.Size = New System.Drawing.Size(0, 0)
    '        Me.tdgData.PreviewInfo.ZoomFactor = 75
    '        Me.tdgData.RowHeight = 15
    '        Me.tdgData.Size = New System.Drawing.Size(632, 120)
    '        Me.tdgData.TabIndex = 83
    '        Me.tdgData.Text = "tdgData"
    '        Me.tdgData.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
    '        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
    '        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Locked:False;BackColor:Po" & _
    '        "wderBlue;}Selected{ForeColor:HighlightText;BackColor:RoyalBlue;}Style3{}Inactive" & _
    '        "{ForeColor:InactiveCaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Cap" & _
    '        "tion{AlignHorz:Center;ForeColor:Green;}Style1{}Normal{Font:Microsoft Sans Serif," & _
    '        " 9.75pt;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style14{}OddR" & _
    '        "ow{}RecordSelector{AlignImage:Center;}Style15{}Heading{Wrap:True;BackColor:Contr" & _
    '        "ol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}Sty" & _
    '        "le10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style9{}</Data></Styles><Splits>" & _
    '        "<C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name=" & _
    '        """"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Column" & _
    '        "FooterHeight=""17"" FetchRowStyles=""True"" MarqueeStyle=""DottedCellBorder"" RecordSe" & _
    '        "lectorWidth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGro" & _
    '        "up=""1""><Height>101</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorS" & _
    '        "tyle parent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" />" & _
    '        "<FilterBarStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" m" & _
    '        "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Hea" & _
    '        "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><Inac" & _
    '        "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
    '        "9"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle " & _
    '        "parent=""Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect" & _
    '        ">0, 17, 630, 101</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</Bord" & _
    '        "erStyle></C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" m" & _
    '        "e=""Normal"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""F" & _
    '        "ooter"" /><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inac" & _
    '        "tive"" /><Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor" & _
    '        """ /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRo" & _
    '        "w"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSele" & _
    '        "ctor"" /><Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Grou" & _
    '        "p"" /></NamedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>N" & _
    '        "one</Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 630, 11" & _
    '        "8</ClientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterSty" & _
    '        "le parent="""" me=""Style15"" /></Blob>"
    '        '
    '        'txtPass
    '        '
    '        Me.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    '        Me.txtPass.Location = New System.Drawing.Point(368, 8)
    '        Me.txtPass.Name = "txtPass"
    '        Me.txtPass.PasswordChar = Microsoft.VisualBasic.ChrW(42)
    '        Me.txtPass.Size = New System.Drawing.Size(152, 20)
    '        Me.txtPass.TabIndex = 87
    '        Me.txtPass.Text = ""
    '        '
    '        'lblPass
    '        '
    '        Me.lblPass.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        Me.lblPass.Location = New System.Drawing.Point(280, 8)
    '        Me.lblPass.Name = "lblPass"
    '        Me.lblPass.Size = New System.Drawing.Size(80, 24)
    '        Me.lblPass.TabIndex = 86
    '        Me.lblPass.Text = "Password:"
    '        Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '        '
    '        'txtUser
    '        '
    '        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    '        Me.txtUser.Location = New System.Drawing.Point(120, 8)
    '        Me.txtUser.Name = "txtUser"
    '        Me.txtUser.Size = New System.Drawing.Size(152, 20)
    '        Me.txtUser.TabIndex = 85
    '        Me.txtUser.Text = ""
    '        '
    '        'lblUser
    '        '
    '        Me.lblUser.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        Me.lblUser.Location = New System.Drawing.Point(24, 8)
    '        Me.lblUser.Name = "lblUser"
    '        Me.lblUser.Size = New System.Drawing.Size(88, 24)
    '        Me.lblUser.TabIndex = 84
    '        Me.lblUser.Text = "Approver UID:"
    '        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '        '
    '        'pnlSecurity
    '        '
    '        Me.pnlSecurity.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtPass, Me.lblPass, Me.txtUser, Me.lblUser})
    '        Me.pnlSecurity.Location = New System.Drawing.Point(48, 208)
    '        Me.pnlSecurity.Name = "pnlSecurity"
    '        Me.pnlSecurity.Size = New System.Drawing.Size(544, 40)
    '        Me.pnlSecurity.TabIndex = 88
    '        '
    '        'btnApprovalOK
    '        '
    '        Me.btnApprovalOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        Me.btnApprovalOK.ForeColor = System.Drawing.Color.DarkBlue
    '        Me.btnApprovalOK.Location = New System.Drawing.Point(344, 248)
    '        Me.btnApprovalOK.Name = "btnApprovalOK"
    '        Me.btnApprovalOK.Size = New System.Drawing.Size(152, 48)
    '        Me.btnApprovalOK.TabIndex = 90
    '        Me.btnApprovalOK.Text = "Approve"
    '        '
    '        'btnApprovalCancel
    '        '
    '        Me.btnApprovalCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        Me.btnApprovalCancel.ForeColor = System.Drawing.Color.Brown
    '        Me.btnApprovalCancel.Location = New System.Drawing.Point(152, 248)
    '        Me.btnApprovalCancel.Name = "btnApprovalCancel"
    '        Me.btnApprovalCancel.Size = New System.Drawing.Size(184, 48)
    '        Me.btnApprovalCancel.TabIndex = 89
    '        Me.btnApprovalCancel.Text = "Disapprove/Cancel"
    '        '
    '        'lblHeader
    '        '
    '        Me.lblHeader.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        Me.lblHeader.ForeColor = System.Drawing.Color.DarkBlue
    '        Me.lblHeader.Location = New System.Drawing.Point(8, 8)
    '        Me.lblHeader.Name = "lblHeader"
    '        Me.lblHeader.Size = New System.Drawing.Size(640, 24)
    '        Me.lblHeader.TabIndex = 90
    '        '
    '        'lblSelectedModelLabel
    '        '
    '        Me.lblSelectedModelLabel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        Me.lblSelectedModelLabel.ForeColor = System.Drawing.Color.Black
    '        Me.lblSelectedModelLabel.Location = New System.Drawing.Point(0, 168)
    '        Me.lblSelectedModelLabel.Name = "lblSelectedModelLabel"
    '        Me.lblSelectedModelLabel.Size = New System.Drawing.Size(112, 24)
    '        Me.lblSelectedModelLabel.TabIndex = 91
    '        Me.lblSelectedModelLabel.Text = "Selected Model:"
    '        Me.lblSelectedModelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '        '
    '        'lblSelectModel
    '        '
    '        Me.lblSelectModel.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        Me.lblSelectModel.ForeColor = System.Drawing.Color.Black
    '        Me.lblSelectModel.Location = New System.Drawing.Point(120, 168)
    '        Me.lblSelectModel.Name = "lblSelectModel"
    '        Me.lblSelectModel.Size = New System.Drawing.Size(440, 24)
    '        Me.lblSelectModel.TabIndex = 92
    '        Me.lblSelectModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '        '
    '        'lblSelectedModelID
    '        '
    '        Me.lblSelectedModelID.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        Me.lblSelectedModelID.ForeColor = System.Drawing.Color.Silver
    '        Me.lblSelectedModelID.Location = New System.Drawing.Point(560, 168)
    '        Me.lblSelectedModelID.Name = "lblSelectedModelID"
    '        Me.lblSelectedModelID.Size = New System.Drawing.Size(88, 24)
    '        Me.lblSelectedModelID.TabIndex = 93
    '        Me.lblSelectedModelID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '        '
    '        'frmModelConfirm
    '        '
    '        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    '        Me.ClientSize = New System.Drawing.Size(658, 312)
    '        Me.ControlBox = False
    '        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSelectedModelID, Me.lblSelectModel, Me.lblSelectedModelLabel, Me.btnApprovalOK, Me.btnApprovalCancel, Me.pnlSecurity, Me.tdgData, Me.lblHeader})
    '        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    '        Me.Name = "frmModelConfirm"
    '        Me.Text = "Model Confirmation"
    '        CType(Me.tdgData, System.ComponentModel.ISupportInitialize).EndInit()
    '        Me.pnlSecurity.ResumeLayout(False)
    '        Me.ResumeLayout(False)

    '    End Sub

    '#End Region

    '    Private Sub frmModelConfirm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        Dim dbgc As C1.Win.C1TrueDBGrid.C1DisplayColumn
    '        Dim objSecurity As PSS.Data.Buisness.Security
    '        'Dim objSecurityRulePW As PSS.Rules.SecurityPassword
    '        Dim dt As DataTable, row As DataRow

    '        Try
    '            Me.pnlSecurity.Visible = False

    '            objSecurity = New PSS.Data.Buisness.Security()

    '            dt = objSecurity.GetPermissionAndSecurityData(, , , , , , , , Me._strScreenSysName)
    '            If Not dt.Rows.Count > 0 Then
    '                MessageBox.Show("Can't find security permission 'NI-ModelApproval'. See IT.", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Me.DialogResult = Windows.Forms.DialogResult.No
    '            Else
    '                For Each row In dt.Rows
    '                    If Not Me._arrAllowedUID.Contains(row("user_name")) Then
    '                        If Me._arrAllowedUserNames.Trim.Length = 0 Then
    '                            Me._arrAllowedUserNames = row("user_fullname")
    '                        Else
    '                            Me._arrAllowedUserNames &= " or " & row("user_fullname")
    '                        End If
    '                        Me._arrAllowedUID.Add(row("user_name"))
    '                        Me._arrAllowedPW.Add(row("user_pass")) 'Me._arrAllowedPW.Add(row("user_pass_Decrypt"))
    '                    End If
    '                Next
    '            End If

    '            If Not PSS.Core.Global.ApplicationUser.GetPermission(Me._strScreenSysName) > 0 Then
    '                MessageBox.Show("Model Approval: You don't have the right to approve it. " & Environment.NewLine & "Please ask " & Me._arrAllowedUserNames & " to approve it.", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Me.pnlSecurity.Visible = True
    '                txtUser.SelectAll() : txtUser.Focus()
    '            End If

    '            dt = Nothing
    '            With Me.tdgData
    '                .DataSource = Me._dt.DefaultView
    '                For Each dbgc In .Splits(0).DisplayColumns
    '                    dbgc.Locked = True
    '                    dbgc.AutoSize()
    '                Next dbgc
    '            End With

    '            Me.lblHeader.Text = Me._strHeader
    '            Me.lblSelectModel.Text = Me._strSelectedModel
    '            Me.lblSelectedModelID.Text = Me._iSelectedModelID

    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString, "frmModelConfirm_Load", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        Finally
    '            objSecurity = Nothing
    '            dt = Nothing
    '        End Try
    '    End Sub

    '    Private Sub btnApprovalOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprovalOK.Click

    '        Dim strScreenSysName As String = "NI-ModelApproval"
    '        Dim iCurrentLoginUserID = PSS.Core.Global.ApplicationUser.IDuser()
    '        'Dim objSecurity As PSS.Data.Buisness.Security
    '        'Dim objSecurityRulePW As PSS.Rules.SecurityPassword
    '        Dim strUserName As String = Trim(Me.txtUser.Text)
    '        Dim strPassword As String = Trim(Me.txtPass.Text)
    '        Dim strEncryptedPW As String = ""
    '        Dim dt As DataTable, row As DataRow
    '        Dim strEncryErr As String = ""
    '        Dim strUID As String = "", strPW As String = ""
    '        Dim i As Integer = 0
    '        Dim bFound As Boolean = False

    '        Try
    '            'objSecurity = New PSS.Data.Buisness.Security()
    '            'objSecurityRulePW = New PSS.Rules.SecurityPassword()
    '            If Me.pnlSecurity.Visible = True Then
    '                'If Not PSS.Core.Global.ApplicationUser.GetPermission(strScreenSysName) > 0 Then
    '                '    MessageBox.Show("You don't have the right to approve it. " & Environment.NewLine & "Please ask " & _
    '                '                     Me._arrAllowedUserNames & " to approve it.", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                '    Me.pnlSecurity.Visible = True
    '                '    txtUser.SelectAll() : txtUser.Focus() : Exit Sub
    '                'End If

    '                If strUserName.Length = 0 Then
    '                    MessageBox.Show("Please enter user login name. ", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    txtUser.SelectAll() : txtUser.Focus() : Exit Sub
    '                End If
    '                If strPassword.Length = 0 Then
    '                    MessageBox.Show("Please enter password. ", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    txtPass.SelectAll() : txtPass.Focus() : Exit Sub
    '                End If

    '                ' dt = objSecurity.GetLoginDatatable(strUserName, strPassword)
    '                strEncryptedPW = EncDec.Rijndael.Encrypt(strPassword, strEncryErr)
    '                If strEncryErr.Trim.Length > 0 Then
    '                    MessageBox.Show("PW encrypt: " & strEncryErr, "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    txtPass.SelectAll() : txtPass.Focus() : Exit Sub
    '                    'Throw New Exception(strDecryErr)
    '                End If
    '                If Me._arrAllowedUID.Count = 0 Then
    '                    MessageBox.Show("at least one of allowed UID(s) and/or PW(s) is required.", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    txtPass.SelectAll() : txtPass.Focus() : Exit Sub
    '                ElseIf Me._arrAllowedUID.Count <> Me._arrAllowedPW.Count Then
    '                    MessageBox.Show("Allowed UID(s) and/or PW(s) are invalid.", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                    txtPass.SelectAll() : txtPass.Focus() : Exit Sub
    '                End If

    '                bFound = False
    '                For i = 0 To Me._arrAllowedUID.Count - 1
    '                    strUID = Me._arrAllowedUID(i) : strPW = Me._arrAllowedPW(i)
    '                    If strUID.Trim.ToUpper = strUserName.Trim.ToUpper _
    '                            AndAlso strPW.Trim.ToUpper = strEncryptedPW.Trim.ToUpper Then
    '                        Me.DialogResult = Windows.Forms.DialogResult.OK
    '                    ElseIf strUID.Trim.ToUpper <> strUserName.Trim.ToUpper Then
    '                        MessageBox.Show("Approval UID is invalid.", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                        txtUser.SelectAll() : txtUser.Focus() : Exit Sub
    '                    ElseIf strPW.Trim.ToUpper <> strEncryptedPW.Trim.ToUpper Then
    '                        MessageBox.Show("Approval UID is invalid.", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                        txtPass.SelectAll() : txtPass.Focus() : Exit Sub
    '                    End If
    '                Next

    '                'If Me._arrAllowedUID.con Then  'PASSED
    '                '    MessageBox.Show("Please enter user correct login name (Approver UID) and password.", "btnApprovalOK_Click", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                '    txtPass.SelectAll() : txtPass.Focus() : Exit Sub
    '                'End If
    '                'Me.DialogResult = Windows.Forms.DialogResult.OK
    '            Else
    '                Me.DialogResult = Windows.Forms.DialogResult.OK
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString, " btnClose", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        End Try
    '    End Sub

    '    Private Sub btnApprovalCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprovalCancel.Click
    '        Try
    '            Me.DialogResult = Windows.Forms.DialogResult.No
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString, " btnClose", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
    '        End Try
    '    End Sub


End Class
