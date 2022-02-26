Imports System
Imports System.GC
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]

Namespace Gui.ValidateRejects

    Public Class frmValidateRejects
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
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents txtWorkorder As System.Windows.Forms.TextBox
        Friend WithEvents btnVerify As System.Windows.Forms.Button
        Friend WithEvents lblOutput As System.Windows.Forms.Label
        Friend WithEvents lblReport As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblDescription = New System.Windows.Forms.Label()
            Me.txtWorkorder = New System.Windows.Forms.TextBox()
            Me.btnVerify = New System.Windows.Forms.Button()
            Me.lblOutput = New System.Windows.Forms.Label()
            Me.lblReport = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.SuspendLayout()
            '
            'lblDescription
            '
            Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDescription.Location = New System.Drawing.Point(8, 8)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(168, 32)
            Me.lblDescription.TabIndex = 0
            Me.lblDescription.Text = "Verify Workorder:"
            '
            'txtWorkorder
            '
            Me.txtWorkorder.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtWorkorder.Location = New System.Drawing.Point(184, 8)
            Me.txtWorkorder.Name = "txtWorkorder"
            Me.txtWorkorder.Size = New System.Drawing.Size(192, 29)
            Me.txtWorkorder.TabIndex = 1
            Me.txtWorkorder.Text = ""
            '
            'btnVerify
            '
            Me.btnVerify.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnVerify.Location = New System.Drawing.Point(184, 48)
            Me.btnVerify.Name = "btnVerify"
            Me.btnVerify.Size = New System.Drawing.Size(192, 32)
            Me.btnVerify.TabIndex = 2
            Me.btnVerify.Text = "Verify"
            '
            'lblOutput
            '
            Me.lblOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOutput.Location = New System.Drawing.Point(184, 96)
            Me.lblOutput.Name = "lblOutput"
            Me.lblOutput.Size = New System.Drawing.Size(192, 32)
            Me.lblOutput.TabIndex = 3
            Me.lblOutput.Text = "Verification Output:"
            '
            'lblReport
            '
            Me.lblReport.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lblReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblReport.Location = New System.Drawing.Point(184, 144)
            Me.lblReport.Name = "lblReport"
            Me.lblReport.Size = New System.Drawing.Size(480, 224)
            Me.lblReport.TabIndex = 4
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(8, 40)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(168, 32)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "(ATCLE Only)"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'frmValidateRejects
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SkyBlue
            Me.ClientSize = New System.Drawing.Size(672, 373)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.lblReport, Me.lblOutput, Me.btnVerify, Me.txtWorkorder, Me.lblDescription})
            Me.Name = "frmValidateRejects"
            Me.Text = "frmValidateRejects"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmValidateRejects_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        End Sub

        Private Sub btnVerify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerify.Click

            lblOutput.Visible = False
            lblReport.Visible = False

            Dim countReject, countInvalid, countInvalidGT6, countInsulator As Long
            countReject = 0
            countInvalid = 0
            countInvalidGT6 = 0
            countInsulator = 0

            txtWorkorder.Text = UCase(txtWorkorder.Text)
            System.Windows.Forms.Application.DoEvents()

            '//This section is to determine if the workorder name has reserved values {}
            Dim blnWOname As Boolean = True
            Dim strWOcheck As String
            Dim mCount As Integer = 1

            For mCount = 1 To Len(txtWorkorder.Text)
                strWOcheck = Mid$(Trim(txtWorkorder.Text), mCount, 1)
                If strWOcheck = "{" Or strWOcheck = "}" Then
                    blnWOname = False
                    Exit For
                End If
            Next
            If blnWOname = False Then
                MsgBox("The workorder name can not contain the values {,}", MsgBoxStyle.OKOnly, "Change Name")
                Exit Sub
            End If

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dt As New DataTable()
            Dim objDataset1 As New DataSet()
            Dim xCount As Integer = 0
            Dim r As DataRow
            Dim vResponse As String

            Dim strFile As String


            Try
                '//Assigned location of file
                strFile = Dir("R:\ATCLE\ATCLE_DataFiles\" & Trim(txtWorkorder.Text) & ".xls")


                '//Create a datatable of all values from the assigned file
                sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=R:\ATCLE\ATCLE_DataFiles\" & strFile & ";Extended Properties=Excel 8.0;"
                objConn.ConnectionString = sConnectionstring
                objConn.Open()
                objCmdSelect.CommandText = ("SELECT * FROM [McHugh Export$]") '
                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(dt)
                objAdapter1.Fill(objDataset1, "XLData")
            Catch ex As Exception
                MsgBox("The data source can not be found. Please check the name and try again.", MsgBoxStyle.OKOnly, "ERROR")
                Me.txtWorkorder.Focus()
                Exit Sub
            End Try

            Dim dtSerials As New DataTable()
            Dim rSerials As DataRow

            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            objCmdSelect.CommandText = ("SELECT [Piece Identifier] FROM [McHugh Export$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect
            objAdapter1.Fill(dtSerials)

            Dim rCheck As DataRow
            Dim strSerial As String
            Dim strSQL As String
            Dim rVal As Long

            Dim DateCheck As String = Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Month, -6, Now))
            Dim DateCheckYear As String = Gui.Receiving.FormatDateShort(DateAdd(DateInterval.Year, -1, Now))

            For xCount = 0 To dtSerials.Rows.Count - 1
                '//Main process area
                rSerials = dtSerials.Rows(xCount)
                strSerial = rSerials("Piece Identifier")

                System.Windows.Forms.Application.DoEvents()
                rVal = checkSerialStatus(strSerial, DateCheck, DateCheckYear)

                If rVal = 0 Then
                    countReject += 1
                ElseIf rVal = 1 Then
                    countInvalid += 1
                ElseIf rVal = 3 Then
                    countInvalidGT6 += 1
                ElseIf rVal = 4 Then
                    countInsulator += 1
                End If

            Next

            Cursor.Current = System.Windows.Forms.Cursors.Default

            '//Get Data For Output
            lblOutput.Visible = True
            lblReport.BackColor = Color.SkyBlue
            lblReport.Visible = True
            Dim strReport As String = ""

            strReport += "Number Of Devices To Verify: " & dtSerials.Rows.Count & vbCrLf
            strReport += "Number Of Devices With History: " & countReject & vbCrLf
            strReport += "Number Of Devices With History (6 Months to 1 Year): " & countInvalidGT6 & vbCrLf
            strReport += "Number Of Devices Insulator Repair Only: " & countInsulator & vbCrLf
            strReport += "Number of New Devices: " & countInvalid & vbCrLf
            Me.lblReport.Text = strReport

            If countInvalid > 0 And (countReject Or countInvalidGT6) > 0 Then
                lblReport.BackColor = Color.Red
            Else
                lblReport.BackColor = Color.SkyBlue
            End If

            objConn.Close()
            objConn = Nothing

        End Sub


        Private Function checkSerialStatus(ByVal vSerialNum As String, ByVal vDate As String, ByVal vDateYear As String) As Integer

            Dim ds As PSS.Data.Production.Joins
            Dim dtCheck As DataTable
            Dim strSQL As String

            strSQL = "select * from " & _
                     "tdevice where device_sn = '" & vSerialNum & "' " & _
                     "and loc_id = 2540 " & _
                     "and device_dateship > '" & vDateYear & " 00:00:00' " & _
                     "and model_id <> 849 " & _
                     "order by device_id desc"

            dtCheck = ds.OrderEntrySelect(strSQL)

            System.Windows.Forms.Application.DoEvents()

            If dtCheck.Rows.Count > 0 Then
                '//Send back based on 6 motnhs or 1 year
                Dim r As DataRow
                r = dtCheck.Rows(0)
                Dim valDate As String = vDateYear & " 00:00:00 "
                If r("Device_DateShip") < valDate Then
                    Return 3    '//more than 6 months
                Else
                    Return 0
                End If
            Else
                '//Verify Insulator Tape Repair
                strSQL = "select * from " & _
                         "tdevice where device_sn = '" & vSerialNum & "' " & _
                         "and loc_id = 2540 " & _
                         "and device_dateship > '" & vDateYear & " 00:00:00' " & _
                         "and model_id = 849 " & _
                         "order by device_id desc"

                dtCheck = ds.OrderEntrySelect(strSQL)
                System.Windows.Forms.Application.DoEvents()

                If dtCheck.Rows.Count > 0 Then
                    Return 4
                Else
                    Return 1
                End If
            End If

        End Function



    End Class

End Namespace
