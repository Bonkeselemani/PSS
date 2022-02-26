Imports PSS.Core
Imports PSS.Data

Namespace Gui.Edits

    Public Class SkuEdit_Messaging
        Inherits System.Windows.Forms.Form

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
        Friend WithEvents btnInsertFreq As System.Windows.Forms.Button
        Friend WithEvents pnlInsertFreq As System.Windows.Forms.Panel
        Friend WithEvents lblFreq As System.Windows.Forms.Label
        Friend WithEvents btnFreq As System.Windows.Forms.Button
        Friend WithEvents txtFreq As System.Windows.Forms.TextBox
        Friend WithEvents Button1 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnInsertFreq = New System.Windows.Forms.Button()
            Me.pnlInsertFreq = New System.Windows.Forms.Panel()
            Me.lblFreq = New System.Windows.Forms.Label()
            Me.btnFreq = New System.Windows.Forms.Button()
            Me.txtFreq = New System.Windows.Forms.TextBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.pnlInsertFreq.SuspendLayout()
            Me.SuspendLayout()
            '
            'btnInsertFreq
            '
            Me.btnInsertFreq.Location = New System.Drawing.Point(8, 24)
            Me.btnInsertFreq.Name = "btnInsertFreq"
            Me.btnInsertFreq.Size = New System.Drawing.Size(120, 40)
            Me.btnInsertFreq.TabIndex = 0
            Me.btnInsertFreq.Text = "Insert Frequency"
            '
            'pnlInsertFreq
            '
            Me.pnlInsertFreq.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlInsertFreq.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFreq, Me.btnFreq, Me.txtFreq})
            Me.pnlInsertFreq.Location = New System.Drawing.Point(136, 24)
            Me.pnlInsertFreq.Name = "pnlInsertFreq"
            Me.pnlInsertFreq.Size = New System.Drawing.Size(312, 40)
            Me.pnlInsertFreq.TabIndex = 4
            '
            'lblFreq
            '
            Me.lblFreq.Location = New System.Drawing.Point(8, 8)
            Me.lblFreq.Name = "lblFreq"
            Me.lblFreq.Size = New System.Drawing.Size(88, 16)
            Me.lblFreq.TabIndex = 6
            Me.lblFreq.Text = "New Frequency:"
            '
            'btnFreq
            '
            Me.btnFreq.Location = New System.Drawing.Point(208, 8)
            Me.btnFreq.Name = "btnFreq"
            Me.btnFreq.Size = New System.Drawing.Size(88, 23)
            Me.btnFreq.TabIndex = 5
            Me.btnFreq.Text = "Submit"
            '
            'txtFreq
            '
            Me.txtFreq.Location = New System.Drawing.Point(104, 8)
            Me.txtFreq.Name = "txtFreq"
            Me.txtFreq.Size = New System.Drawing.Size(88, 20)
            Me.txtFreq.TabIndex = 4
            Me.txtFreq.Text = ""
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(8, 344)
            Me.Button1.Name = "Button1"
            Me.Button1.TabIndex = 5
            Me.Button1.Text = "Send Keys"
            '
            'SkuEdit_Messaging
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(560, 373)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.pnlInsertFreq, Me.btnInsertFreq})
            Me.Name = "SkuEdit_Messaging"
            Me.Text = "Edit Functions"
            Me.pnlInsertFreq.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub btnInsertFreq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsertFreq.Click
            SHOW_InsertFreq()
        End Sub

        Private Sub SHOW_InsertFreq()
            pnlInsertFreq.Visible = True
            txtFreq.Focus()
        End Sub

        Private Sub HIDE_InsertFreq()
            pnlInsertFreq.Visible = False
        End Sub

        Private Sub HIDE_ALL()
            HIDE_InsertFreq()
        End Sub


        Private Function PROCESS_InsertFreq(ByVal vFrequency As String) As String
            PROCESS_InsertFreq = "InProcess" '//Set initial value in case of process interruption

            Dim vCheck4Integer As Integer
            Dim vMark As String

            '//Verify the validity of the frequency format
            If Len(Trim(vFrequency)) <> 8 Then
                Return "Frequency is not the correct number of characters, please try again."
            End If

            If Mid$(vFrequency, 4, 1) <> "." Then
                Return "The frequency is not in the correct format."
            End If

            '//Verify the data value of the frequency as numberic
            Try
                vCheck4Integer = CInt(Mid$(vFrequency, 1, 3))
            Catch ex As Exception
                Return "The frequency prefix is not numeric."
            End Try

            Try
                vCheck4Integer = CInt(Mid$(vFrequency, 5, 4))
            Catch ex As Exception
                Return "The frequency suffix is not numeric."
            End Try

            '//Verify that the frequency is not currently in the table
            Dim strSQL As String = "SELECT * FROM lfrequency WHERE freq_Number = '" & vFrequency & "'"
            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect(strSQL)

            If dt.Rows.Count > 0 Then
                dt = Nothing
                ds = Nothing
                Return "This frequency is currently being used. It can not be entered."
            End If

            '//If all criteria has been met then enter into database
            strSQL = "INSERT INTO lfrequency (freq_Number) VALUES ('" & vFrequency & "')"
            Dim blndt As Boolean
            blndt = ds.OrderEntryUpdateDelete(strSQL)

            If blndt = False Then
                blndt = Nothing
                ds = Nothing
                Return "Insert Failed"
            ElseIf blndt = True Then
                blndt = Nothing
                ds = Nothing
                Return "Inserted"
            End If

        End Function

        Private Sub btnFreq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFreq.Click
            Dim respFreq As String
            Dim strResponse
            If Len(Trim(txtFreq.Text)) > 0 Then
                respFreq = PROCESS_InsertFreq(txtFreq.Text)

                If respFreq = "Inserted" Then
                    '//Process Successful
                    strResponse = "Load Successful"
                    txtFreq.Text = ""
                ElseIf respFreq = "Insert Failed" Then
                    '//Process Unsuccessful
                    strResponse = "Insert Failed, Please Tray Again."
                ElseIf respFreq = "InProcess" Then
                    '//Process Terminated
                    strResponse = "The process was interrupted unexpectedly. Please contact IT."
                Else
                    '//Process Failed
                    strResponse = respFreq
                End If

                '//Display response based on return value
                displayNoteBoard(strResponse)

                System.Windows.Forms.Application.DoEvents()
                HIDE_InsertFreq()
            End If


        End Sub

        Private Sub SkuEdit_Messaging_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            HIDE_InsertFreq()
        End Sub

        Private Sub displayNoteBoard(ByVal vString As String)
            Dim xForm As New Gui.NoteBoard.frmNoteBoard(vString)
            xForm.ShowDialog()
        End Sub



        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


            Dim myProcess As Process = New Process()
            'myProcess.StartInfo.FileName()


            myProcess.StartInfo.FileName = "notepad"
            myProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            myProcess.EnableRaisingEvents = True
            'AddHandler myProcess.Exited, AddressOf Me.SendKeysTestExited
            myProcess.Start()

            ' wait until the program is ready for input
            myProcess.WaitForInputIdle(1000)
            If myProcess.Responding Then
                System.Windows.Forms.SendKeys.SendWait("This text was entered using the System.Windows.Forms.SendKeys method.")
            Else
                MsgBox("ERROR")
            End If


        End Sub

    End Class

End Namespace
