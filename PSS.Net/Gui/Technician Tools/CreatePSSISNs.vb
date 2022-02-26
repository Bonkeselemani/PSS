Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Namespace PSSISNs
    Public Class CreatePSSISNs
        Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
        'NOTE: The maximum value for the numeric up down control numQuantity is set to 4095, which equals xFFF,
        'the max for a three-character hex string.
        Private Const _strReportDir As String = "R:\PSSInet_Reports_Repl1"  '"C:\Label\PSSI\"
        Private Const _strReportName As String = "PSSI Serial Number Push.rpt"
        Private ReadOnly _iMaxSNs As Integer

        Private _objCreatePSSISNs As PSS.Data.Buisness.CreatePSSISNs
        Private _bLocked As Boolean = False
        Private _bCanPrint As Boolean = True

        Public Sub New()
            MyBase.New()

            Try

                'This call is required by the Windows Form Designer.
                InitializeComponent()

                'Add any initialization after the InitializeComponent() call
                Me._objCreatePSSISNs = New PSS.Data.Buisness.CreatePSSISNs()
                Me._iMaxSNs = Me._objCreatePSSISNs.ConvertFromHexToInt("FFF")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CreatePSSISNs ctor", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If Not Me._bLocked Then Me._objCreatePSSISNs.Unlock()

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
        Friend WithEvents lblQuantity As System.Windows.Forms.Label
        Friend WithEvents numQuantity As System.Windows.Forms.NumericUpDown
        Friend WithEvents btnCreateSerialNumbers As System.Windows.Forms.Button
        Friend WithEvents grpCreate As System.Windows.Forms.GroupBox
        Friend WithEvents grpReprint As System.Windows.Forms.GroupBox
        Friend WithEvents btnReprintSerialNumbers As System.Windows.Forms.Button
        Friend WithEvents lblReprintQuantity As System.Windows.Forms.Label
        Friend WithEvents lblReprintStart As System.Windows.Forms.Label
        Friend WithEvents txtReprint As System.Windows.Forms.TextBox
        Friend WithEvents numReprintQuantity As System.Windows.Forms.NumericUpDown
        Friend WithEvents rtbLastCreated As System.Windows.Forms.RichTextBox
        Friend WithEvents rtbRemainingCount As System.Windows.Forms.RichTextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grpCreate = New System.Windows.Forms.GroupBox()
            Me.btnCreateSerialNumbers = New System.Windows.Forms.Button()
            Me.numQuantity = New System.Windows.Forms.NumericUpDown()
            Me.lblQuantity = New System.Windows.Forms.Label()
            Me.grpReprint = New System.Windows.Forms.GroupBox()
            Me.txtReprint = New System.Windows.Forms.TextBox()
            Me.lblReprintStart = New System.Windows.Forms.Label()
            Me.btnReprintSerialNumbers = New System.Windows.Forms.Button()
            Me.numReprintQuantity = New System.Windows.Forms.NumericUpDown()
            Me.lblReprintQuantity = New System.Windows.Forms.Label()
            Me.rtbLastCreated = New System.Windows.Forms.RichTextBox()
            Me.rtbRemainingCount = New System.Windows.Forms.RichTextBox()
            Me.grpCreate.SuspendLayout()
            CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grpReprint.SuspendLayout()
            CType(Me.numReprintQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'grpCreate
            '
            Me.grpCreate.Controls.AddRange(New System.Windows.Forms.Control() {Me.rtbRemainingCount, Me.rtbLastCreated, Me.btnCreateSerialNumbers, Me.numQuantity, Me.lblQuantity})
            Me.grpCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpCreate.ForeColor = System.Drawing.Color.Black
            Me.grpCreate.Location = New System.Drawing.Point(16, 16)
            Me.grpCreate.Name = "grpCreate"
            Me.grpCreate.Size = New System.Drawing.Size(464, 128)
            Me.grpCreate.TabIndex = 0
            Me.grpCreate.TabStop = False
            Me.grpCreate.Text = "Create Serial Numbers"
            '
            'btnCreateSerialNumbers
            '
            Me.btnCreateSerialNumbers.BackColor = System.Drawing.Color.SteelBlue
            Me.btnCreateSerialNumbers.ForeColor = System.Drawing.Color.White
            Me.btnCreateSerialNumbers.Location = New System.Drawing.Point(48, 72)
            Me.btnCreateSerialNumbers.Name = "btnCreateSerialNumbers"
            Me.btnCreateSerialNumbers.Size = New System.Drawing.Size(160, 40)
            Me.btnCreateSerialNumbers.TabIndex = 2
            Me.btnCreateSerialNumbers.Text = "Create Serial Numbers"
            '
            'numQuantity
            '
            Me.numQuantity.BackColor = System.Drawing.Color.FloralWhite
            Me.numQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.numQuantity.ForeColor = System.Drawing.Color.Blue
            Me.numQuantity.Location = New System.Drawing.Point(104, 32)
            Me.numQuantity.Maximum = New Decimal(New Integer() {4095, 0, 0, 0})
            Me.numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numQuantity.Name = "numQuantity"
            Me.numQuantity.Size = New System.Drawing.Size(88, 22)
            Me.numQuantity.TabIndex = 1
            Me.numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'lblQuantity
            '
            Me.lblQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblQuantity.Location = New System.Drawing.Point(16, 32)
            Me.lblQuantity.Name = "lblQuantity"
            Me.lblQuantity.Size = New System.Drawing.Size(64, 23)
            Me.lblQuantity.TabIndex = 0
            Me.lblQuantity.Text = "Quantity"
            '
            'grpReprint
            '
            Me.grpReprint.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtReprint, Me.lblReprintStart, Me.btnReprintSerialNumbers, Me.numReprintQuantity, Me.lblReprintQuantity})
            Me.grpReprint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.grpReprint.ForeColor = System.Drawing.Color.Black
            Me.grpReprint.Location = New System.Drawing.Point(16, 176)
            Me.grpReprint.Name = "grpReprint"
            Me.grpReprint.Size = New System.Drawing.Size(256, 176)
            Me.grpReprint.TabIndex = 1
            Me.grpReprint.TabStop = False
            Me.grpReprint.Text = "Reprint Serial Numbers"
            '
            'txtReprint
            '
            Me.txtReprint.BackColor = System.Drawing.Color.FloralWhite
            Me.txtReprint.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtReprint.ForeColor = System.Drawing.Color.Blue
            Me.txtReprint.Location = New System.Drawing.Point(104, 32)
            Me.txtReprint.Name = "txtReprint"
            Me.txtReprint.Size = New System.Drawing.Size(136, 20)
            Me.txtReprint.TabIndex = 4
            Me.txtReprint.Text = ""
            '
            'lblReprintStart
            '
            Me.lblReprintStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReprintStart.Location = New System.Drawing.Point(16, 32)
            Me.lblReprintStart.Name = "lblReprintStart"
            Me.lblReprintStart.Size = New System.Drawing.Size(88, 23)
            Me.lblReprintStart.TabIndex = 3
            Me.lblReprintStart.Text = "Starting SN"
            '
            'btnReprintSerialNumbers
            '
            Me.btnReprintSerialNumbers.BackColor = System.Drawing.Color.SteelBlue
            Me.btnReprintSerialNumbers.ForeColor = System.Drawing.Color.White
            Me.btnReprintSerialNumbers.Location = New System.Drawing.Point(48, 120)
            Me.btnReprintSerialNumbers.Name = "btnReprintSerialNumbers"
            Me.btnReprintSerialNumbers.Size = New System.Drawing.Size(160, 40)
            Me.btnReprintSerialNumbers.TabIndex = 2
            Me.btnReprintSerialNumbers.Text = "Reprint Serial Numbers"
            '
            'numReprintQuantity
            '
            Me.numReprintQuantity.BackColor = System.Drawing.Color.FloralWhite
            Me.numReprintQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.numReprintQuantity.ForeColor = System.Drawing.Color.Blue
            Me.numReprintQuantity.Location = New System.Drawing.Point(104, 80)
            Me.numReprintQuantity.Maximum = New Decimal(New Integer() {4095, 0, 0, 0})
            Me.numReprintQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numReprintQuantity.Name = "numReprintQuantity"
            Me.numReprintQuantity.Size = New System.Drawing.Size(88, 22)
            Me.numReprintQuantity.TabIndex = 1
            Me.numReprintQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'lblReprintQuantity
            '
            Me.lblReprintQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReprintQuantity.Location = New System.Drawing.Point(16, 80)
            Me.lblReprintQuantity.Name = "lblReprintQuantity"
            Me.lblReprintQuantity.Size = New System.Drawing.Size(64, 23)
            Me.lblReprintQuantity.TabIndex = 0
            Me.lblReprintQuantity.Text = "Quantity"
            '
            'rtbLastCreated
            '
            Me.rtbLastCreated.BackColor = System.Drawing.Color.LightSteelBlue
            Me.rtbLastCreated.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.rtbLastCreated.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rtbLastCreated.Location = New System.Drawing.Point(248, 32)
            Me.rtbLastCreated.Multiline = False
            Me.rtbLastCreated.Name = "rtbLastCreated"
            Me.rtbLastCreated.ReadOnly = True
            Me.rtbLastCreated.Size = New System.Drawing.Size(200, 24)
            Me.rtbLastCreated.TabIndex = 3
            Me.rtbLastCreated.TabStop = False
            Me.rtbLastCreated.Text = ""
            '
            'rtbRemainingCount
            '
            Me.rtbRemainingCount.BackColor = System.Drawing.Color.LightSteelBlue
            Me.rtbRemainingCount.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.rtbRemainingCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rtbRemainingCount.Location = New System.Drawing.Point(248, 80)
            Me.rtbRemainingCount.Multiline = False
            Me.rtbRemainingCount.Name = "rtbRemainingCount"
            Me.rtbRemainingCount.ReadOnly = True
            Me.rtbRemainingCount.Size = New System.Drawing.Size(200, 24)
            Me.rtbRemainingCount.TabIndex = 4
            Me.rtbRemainingCount.TabStop = False
            Me.rtbRemainingCount.Text = ""
            '
            'CreatePSSISNs
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.ClientSize = New System.Drawing.Size(496, 374)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpReprint, Me.grpCreate})
            Me.Name = "CreatePSSISNs"
            Me.Text = "Create PSSI Serial Numbers"
            Me.grpCreate.ResumeLayout(False)
            CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grpReprint.ResumeLayout(False)
            CType(Me.numReprintQuantity, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub CreatePSSISNs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                'CheckLocking()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CreatePSSISNs_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnCreateSerialNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateSerialNumbers.Click
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                Dim iQuantity As Integer = Convert.ToInt32(Me.numQuantity.Value)

                If iQuantity <= 0 Then
                    MessageBox.Show("You must select a quantity greater than zero.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim iLast As Integer = 0
                    Dim strNow As String = Me._objCreatePSSISNs.CheckSNs(iQuantity, iLast)

                    If strNow.Length > 0 Then
                        Dim i As Integer

                        For i = iLast + 1 To iLast + iQuantity
                            Dim strHex = i.ToString("X").PadLeft(3, "0")
                            Dim strSN As String = String.Format("P{0}{1}", strNow, strHex)

                            PrintSN(strSN)
                            Me._objCreatePSSISNs.SaveSN(strSN, PSS.Core.ApplicationUser.IDuser)
                        Next i

                        GetMostRecentlyCreatedSN()
                        GetRemainingCount()

                        MessageBox.Show("Serial number creation and printing completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCreateSerialNumbers_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub CreatePSSISNs_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            Try
                If Not Me._bLocked Then Me._objCreatePSSISNs.Unlock()

                Me._bLocked = False
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CreatePSSISNs_Closing", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub PrintSN(ByVal strSN As String)
            Try
                If Not File.Exists(Me._strReportDir & Me._strReportName) Then Throw New Exception(String.Format("Unable to locate report file '{0}'.", Me._strReportDir & Me._strReportName))

                Dim objRpt As New ReportDocument()
                Dim dtSN As New DataTable()

                dtSN.Columns.Add(New DataColumn("SerialNumber", System.Type.GetType("System.String")))

                Dim drSN As DataRow = dtSN.NewRow

                drSN("SerialNumber") = strSN

                dtSN.Rows.Add(drSN)

                With objRpt
                    .Load(Me._strReportDir & Me._strReportName)
                    .SetDataSource(dtSN)
                    .PrintToPrinter(1, True, 0, 0)
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CheckReportDir()
            Try
                If Not Directory.Exists(Me._strReportDir) Then Directory.CreateDirectory(Me._strReportDir)
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub CheckReport()
            Try
                If Not File.Exists(Me._strReportDir & Me._strReportName) Then
                    MessageBox.Show(String.Format("Unable to locate the report file {0}.  You will be unable to print labels.", Me._strReportDir & Me._strReportName), "Missing Report File", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.btnCreateSerialNumbers.Enabled = False
                    Me.btnReprintSerialNumbers.Enabled = False
                    Me._bCanPrint = False
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub btnReprintSerialNumbers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintSerialNumbers.Click
            Try
                Me.Cursor = Cursors.WaitCursor
                Me.Enabled = False

                Dim strStartSN As String = Me.txtReprint.Text.Trim
                Dim iStart As Integer = Me._objCreatePSSISNs.ConvertFromHexToInt(strStartSN.Substring(strStartSN.Length - 3))
                Dim iReprintQuantity As Integer = Convert.ToInt32(Me.numReprintQuantity.Value)

                If strStartSN.Length = 0 Then
                    MessageBox.Show("Please enter a starting serial number.", "Invalid Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf Not Me._objCreatePSSISNs.SNExists(strStartSN) Then
                    MessageBox.Show("This serial number doesn't exist.", "Invalid Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ElseIf iStart + iReprintQuantity - 1 > Me._iMaxSNs Then
                    MessageBox.Show(String.Format("You cannot reprint more than {0} serial numbers.", Me._iMaxSNs - (iStart - 1)), "Invalid Serial Number Quantity", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Dim i As Integer
                    Dim strBase As String = strStartSN.Substring(0, strStartSN.Length - 3)

                    For i = iStart To iStart + iReprintQuantity - 1
                        Dim strHex = i.ToString("X").PadLeft(3, "0")
                        Dim strSN As String = String.Format("{0}{1}", strBase, strHex)

                        PrintSN(strSN)
                        Me._objCreatePSSISNs.SaveSN(strSN, PSS.Core.ApplicationUser.IDuser)
                    Next i

                    GetMostRecentlyCreatedSN()
                    GetRemainingCount()

                    MessageBox.Show("Serial number reprint completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnReprintSerialNumbers_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Enabled = True
                Me.Cursor = Cursors.Default
            End Try
        End Sub

        Private Sub txtReprint_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReprint.KeyPress
            Try
                If Not (Char.IsLetterOrDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                    Beep()
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "txtReprint_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub numQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numQuantity.KeyPress
            Try
                If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                    Beep()
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "numQuantity_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub numReprintQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numReprintQuantity.KeyPress
            Try
                If Not (Char.IsDigit(e.KeyChar) Or Char.IsControl(e.KeyChar)) Then
                    Beep()
                    e.Handled = True
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "numReprintQuantity_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CreatePSSISNs_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Leave
            If Not Me._bLocked Then Me._objCreatePSSISNs.Unlock()
        End Sub

        Private Sub CreatePSSISNs_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
            Try
                CheckLocking()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CreatePSSISNs_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub CheckLocking()
            Try
                Me._bLocked = Me._objCreatePSSISNs.IsLocked()

                Me.grpCreate.Enabled = Not Me._bLocked
                Me.grpReprint.Enabled = Not Me._bLocked

                If Me._bLocked Then
                    Me.txtReprint.Text = String.Empty
                    Me.numQuantity.Value = 1
                    me.numReprintQuantity.Value = 1
                    Dim strUser As String = Me._objCreatePSSISNs.GetLockingUser()

                    MessageBox.Show(String.Format("Serial number creation is locked out by {0}.", strUser), "Lockout", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Me._objCreatePSSISNs.Lock(PSS.Core.ApplicationUser.User)
                    CheckReportDir()
                    CheckReport()
                    GetMostRecentlyCreatedSN()
                    GetRemainingCount()
                    Me.grpCreate.Text = String.Format("Create Serial Numbers for {0:MMM d, yyyy}", Me._objCreatePSSISNs.GetServerDate())
                End If
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub GetMostRecentlyCreatedSN()
            Try
                Dim strMostRecentlyCreatedSN As String = Me._objCreatePSSISNs.GetMostRecentlyCreatedSN()

                With Me.rtbLastCreated
                    .Text = String.Format("Last Created SN: {0}", strMostRecentlyCreatedSN)
                    .SelectionStart = 0
                    .SelectionLength = .Text.IndexOf(":") + 1
                    .SelectionColor = Color.Black
                    .SelectionStart = .Text.IndexOf(":") + 1
                    .SelectionLength = .Text.Length - (.Text.IndexOf(":") + 1)

                    If strMostRecentlyCreatedSN.Equals("N/A") Then
                        .SelectionColor = Color.Blue
                    Else
                        .SelectionColor = IIf(Convert.ToInt32(strMostRecentlyCreatedSN.Substring(strMostRecentlyCreatedSN.Length - 3)) < Me._iMaxSNs, Color.Blue, Color.Crimson)
                    End If
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub GetRemainingCount()
            Try
                Dim iRemaining As Integer = Me._iMaxSNs - Me._objCreatePSSISNs.GetTodaysCreatedSNsCount()

                With rtbRemainingCount
                    .Text = String.Format("Remaining Count: {0:#,##0}", iRemaining)
                    .SelectionStart = 0
                    .SelectionLength = .Text.IndexOf(":") + 1
                    .SelectionColor = Color.Black
                    .SelectionStart = .Text.IndexOf(":") + 1
                    .SelectionLength = .Text.Length - (.Text.IndexOf(":") + 1)
                    .SelectionColor = IIf(iRemaining > 0, Color.Blue, Color.Crimson)
                End With
            Catch ex As Exception
                Throw ex
            End Try
        End Sub
    End Class
End Namespace
