Imports System
Imports System.IO
Imports System.Text

Namespace Gui.MClaims
    Public Class frmMotoClaimReconcile
        Inherits System.Windows.Forms.Form

        Private objUtility As MyLib.Utility
        Private objMotoSubcontract_Biz As PSS.Data.Buisness.MotorolaSubcontract_Biz
        Private radioButtons(1) As RadioButton
        Private strClaimType As String = ""
        Private iParts As Integer = 0
        Private strBatchDate As String = ""
        Private iBatchNumber As Integer = 0
        Private strWrty As String
        Private strRejectMsg As String = ""
        Private iClaimNo As Integer = 0
        Private ClaimNoArray(0)

        Private Const strFP As String = "C:\PSSException.txt"
        'Private Const strASCFilePath As String = "D:\ASC\"
        'Private Const strSUBFilePath As String = "D:\SUB\"
        Private Const strASCFilePath As String = "R:\Claim Batch Analysis Reports - ASC\"
        Private Const strSUBFilePath As String = "R:\Motorola NSC - Claim Batch Analysis Reports\"

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objMotoSubcontract_Biz = New PSS.Data.Buisness.MotorolaSubcontract_Biz()
            radioButtons(0) = Me.RadioASC
            radioButtons(1) = Me.radioSub

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
        'Private PrintDocument1 As System.Drawing.Printing.PrintDocument
        'Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents RadioASC As System.Windows.Forms.RadioButton
        Friend WithEvents radioSub As System.Windows.Forms.RadioButton
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents txtBatchNo As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnCreateRpt As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.radioSub = New System.Windows.Forms.RadioButton()
            Me.RadioASC = New System.Windows.Forms.RadioButton()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.txtBatchNo = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnCreateRpt = New System.Windows.Forms.Button()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.Khaki
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.radioSub, Me.RadioASC})
            Me.Panel1.Location = New System.Drawing.Point(24, 88)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(260, 88)
            Me.Panel1.TabIndex = 2
            '
            'radioSub
            '
            Me.radioSub.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.radioSub.Location = New System.Drawing.Point(38, 48)
            Me.radioSub.Name = "radioSub"
            Me.radioSub.Size = New System.Drawing.Size(165, 24)
            Me.radioSub.TabIndex = 2
            Me.radioSub.Text = "Sub(NSC) Claims"
            '
            'RadioASC
            '
            Me.RadioASC.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.RadioASC.Location = New System.Drawing.Point(38, 16)
            Me.RadioASC.Name = "RadioASC"
            Me.RadioASC.Size = New System.Drawing.Size(165, 24)
            Me.RadioASC.TabIndex = 1
            Me.RadioASC.Text = "ASC Claims"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Khaki
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtBatchNo, Me.Label1})
            Me.Panel2.Location = New System.Drawing.Point(24, 192)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(260, 48)
            Me.Panel2.TabIndex = 3
            '
            'txtBatchNo
            '
            Me.txtBatchNo.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtBatchNo.Location = New System.Drawing.Point(92, 11)
            Me.txtBatchNo.Name = "txtBatchNo"
            Me.txtBatchNo.Size = New System.Drawing.Size(120, 23)
            Me.txtBatchNo.TabIndex = 3
            Me.txtBatchNo.Text = ""
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.Location = New System.Drawing.Point(13, 13)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(83, 23)
            Me.Label1.TabIndex = 2
            Me.Label1.Text = "Batch No:"
            '
            'btnCreateRpt
            '
            Me.btnCreateRpt.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateRpt.Location = New System.Drawing.Point(24, 256)
            Me.btnCreateRpt.Name = "btnCreateRpt"
            Me.btnCreateRpt.Size = New System.Drawing.Size(260, 32)
            Me.btnCreateRpt.TabIndex = 4
            Me.btnCreateRpt.Text = "Load Batch Claim Data"
            '
            'Label2
            '
            Me.Label2.Font = New System.Drawing.Font("Comic Sans MS", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.OrangeRed
            Me.Label2.Location = New System.Drawing.Point(24, 6)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(264, 64)
            Me.Label2.TabIndex = 5
            Me.Label2.Text = "Motorola M-Claims (Load Batch Claim Data)"
            '
            'frmMotoClaimReconcile
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.DarkKhaki
            Me.ClientSize = New System.Drawing.Size(304, 309)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.btnCreateRpt, Me.Panel2, Me.Panel1})
            Me.Name = "frmMotoClaimReconcile"
            Me.Text = "M-Claims Reconciliation"
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '****************************************************************************
        'CheckChange event handler for both option buttons.
        '****************************************************************************
        Private Sub radioOptionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioSub.CheckedChanged, RadioASC.CheckedChanged

            Dim Found As Boolean = False
            Dim i As Integer = 0

            While i < radioButtons.GetLength(0) And Not Found
                If radioButtons(i).Checked Then
                    Found = True
                    If i = 0 Then
                        strClaimType = "ASC"
                    Else
                        strClaimType = "SUB"
                    End If
                End If
                i += 1
            End While
            Me.txtBatchNo.Focus()
        End Sub
        '****************************************************************************
        'Checks if the batch is loaded in to the database
        '****************************************************************************
        Private Sub CheckBatchLoaded()
            Dim dt1 As New DataTable()
            Dim R1 As DataRow

            Try
                dt1 = objMotoSubcontract_Biz.CheckifBatchExists(iBatchNumber)
                For Each R1 In dt1.Rows
                    If R1("BatchExists") > 0 Then
                        Throw New Exception("Batch has already been loaded in to 'tmotorolarecon' table.")
                    End If
                Next R1

                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If

                dt1 = New DataTable()
                dt1 = objMotoSubcontract_Biz.CheckifBatchExistsForParts(iBatchNumber)
                For Each R1 In dt1.Rows
                    If R1("BatchExists") > 0 Then
                        Throw New Exception("Batch has already been loaded in to 'tmotoreconparts' table.")
                    End If
                Next R1

            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try

        End Sub
        '****************************************************************************
        'Click event creates Reconciliation Report
        ''****************************************************************************
        Private Sub btnCreateRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateRpt.Click
            Dim strFileName As String = ""
            Dim strPath As String = ""

            '************************************************
            'Required field validations
            '************************************************
            If strClaimType = "" Then
                MsgBox("Please select the type of claims you want to reconcile.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If Me.txtBatchNo.Text = "" Then
                MsgBox("Please input the Batch No you want to reconcile.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '************************************************
            'Determine the batch file path
            '************************************************
            strFileName = "ClaimBatchAnalysis-" & Trim(Me.txtBatchNo.Text).PadLeft(8, "0") & ".txt"

            Select Case strClaimType
                Case "ASC"
                    strPath = strASCFilePath & strFileName
                Case "SUB"
                    strPath = strSUBFilePath & strFileName
            End Select
            '************************************************
            Dim filestr As StreamReader
            Dim filecontents As String
            Dim count As Integer = 0
            Dim iFlag As Integer = 0
            Dim arrSplitFile
            Dim i As Integer = 0
            Dim iAccptedRejectedClaims As Integer = 0      ' 1 - Accepted Claims; 2 - rejected Claims
            Dim dteBatchDate As DateTime
            Dim response As MsgBoxResult
            Dim strEx As String = ""

            Try
                'ObjPrinting = New MyLib.Printing()
                objUtility = New MyLib.Utility()

                'Opening a file
                filestr = File.OpenText(strPath)

                'Reading a file
                filecontents = filestr.ReadToEnd()

                'Here we have taken Comma as a delimiter
                arrSplitFile = Split(filecontents, vbCrLf)

                For count = 0 To UBound(arrSplitFile)
                    If iFlag = 1 Then iFlag += 1
                    If iParts = 1 Then iParts += 1
                    '*********************************************************
                    'Get Date
                    '*********************************************************
                    If Trim(arrSplitFile(count)) Like "*DATE*" Then
                        dteBatchDate = CDate(ReadValue(Trim(arrSplitFile(count)), "DATE", Chr(9)))
                        strBatchDate = DatePart(DateInterval.Year, dteBatchDate) & "-" & DatePart(DateInterval.Month, dteBatchDate) & "-" & DatePart(DateInterval.Day, dteBatchDate) & " " & DatePart(DateInterval.Hour, dteBatchDate) & ":" & DatePart(DateInterval.Minute, dteBatchDate) & ":" & DatePart(DateInterval.Second, dteBatchDate)
                    End If
                    '*********************************************************
                    'Get BATCH NUMBER
                    '*********************************************************
                    If Trim(arrSplitFile(count)) Like "*Batch Number*" Then
                        iBatchNumber = CInt(ReadValue(Trim(arrSplitFile(count)), "Batch Number", Chr(9)))
                        Me.CheckBatchLoaded()   'Check if the Bacth is already loaded
                    End If
                    '*********************************************************
                    'Added by Asif on 11/16/2005
                    If Trim(arrSplitFile(count)) Like "*Accepted Claims*" Then
                        iAccptedRejectedClaims = 1
                    ElseIf Trim(arrSplitFile(count)) Like "*Rejected Claims*" Then
                        iAccptedRejectedClaims = 2
                    ElseIf Trim(arrSplitFile(count)) Like "*Parts Summary*" Then
                        If iAccptedRejectedClaims = 2 Then
                            If Len(strRejectMsg) > 0 Then
                                i = InsertRow(iAccptedRejectedClaims, , , , )
                            End If
                        End If
                        iAccptedRejectedClaims = 3      'Parts
                    End If
                    '*********************************************************
                    'set Starting and stopping points for the rejected and failed sections
                    Select Case iAccptedRejectedClaims
                        Case 1      'Accepted
                            If Trim(arrSplitFile(count)) Like "*Claim No*" Then      'Starting point
                                iFlag = 1
                            ElseIf Trim(arrSplitFile(count)) Like "*TOTAL*" Then    'Stopping point     'Means Total line has been reached
                                iFlag = 0
                            End If
                        Case 2      'Rejected
                            If Trim(arrSplitFile(count)) Like "*Claim No*" Then      'Starting point
                                iFlag = 1
                            ElseIf Trim(arrSplitFile(count)) Like "*Parts Summary*" Then    'Stopping point     'Means Total line has been reached
                                iFlag = 0
                            End If
                        Case 3      'Parts
                            If Trim(arrSplitFile(count)) Like "*Part Code*" Then      'Starting point
                                iFlag = 1
                                iParts = 1
                            ElseIf Trim(arrSplitFile(count)) Like "*Total*" Then    'Stopping point     'Means Total line has been reached
                                iFlag = 0
                                iParts = 0
                                Exit For
                            End If

                    End Select
                    '*********************************************************
                    If iAccptedRejectedClaims > 0 Then
                        If iFlag > 1 Then
                            'Read and insert Rows in to database here
                            i = 0
                            i = Read_n_InsertRow(Trim(arrSplitFile(count)), iAccptedRejectedClaims, Chr(9))
                        End If
                    End If
                    '*********************************************************
                Next count
                MessageBox.Show("Claims Data has been successfully uploaded to the database.", "Upload Complete", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                Reset()
                filestr.Close()
                filestr = Nothing
                arrSplitFile = Nothing
                objUtility = Nothing
                ReDim ClaimNoArray(0)
                ClaimNoArray.Clear(ClaimNoArray, 0, ClaimNoArray.Length)

                'Reset the class level variables
                strBatchDate = ""
                iBatchNumber = 0
                strWrty = ""
                strRejectMsg = ""
                iClaimNo = 0

            End Try
            '************************************************
        End Sub

        '*****************************************************************************
        Private Function ReadValue(ByVal strLine As String, _
                                    ByVal strTargetStr As String, _
                                    ByVal delimiter As String) As String
            Dim arrSplitLine
            Dim iFlag As Integer = 0
            Dim strVal As String
            Dim i As Integer = 0

            Try
                arrSplitLine = Split(Trim(strLine), delimiter)

                For i = 0 To UBound(arrSplitLine)
                    If Trim(arrSplitLine(i)) <> "" Then
                        If Trim(arrSplitLine(i)) Like "*" & strTargetStr & "*" Then
                            iFlag = 1
                        ElseIf iFlag = 1 Then
                            strVal = Trim(arrSplitLine(i))
                            iFlag = 0
                            Exit For
                        End If
                    End If
                Next i
                Return strVal
            Catch ex As Exception
                Throw ex
            Finally
                arrSplitLine = Nothing
            End Try
        End Function

        '*****************************************************************************
        Private Function Read_n_InsertRow(ByVal strLine As String, _
                                   ByVal iAccptedRejectedClaims As Integer, _
                                   ByVal delimiter As String) As Integer
            Dim arrSplitLine
            Dim iFlg As Integer = 0
            Dim strVal As String
            Dim i As Integer = 0
            Dim j As Integer
            Dim decFixedRate, decPartPrice, decClaimDiscAmt, decConsDiscAmt, decTotalPaid As Decimal
            Dim iQuantity As Integer = 0
            Dim strPrtNum As String = ""

            If Len(Trim(strLine)) = 0 Then
                Exit Function
            End If

            Try
                arrSplitLine = Split(Trim(strLine), delimiter)

                If iAccptedRejectedClaims = 1 Then  'Accepted Claims here
                    For i = 0 To UBound(arrSplitLine)
                        Select Case i
                            Case 0
                                iClaimNo = Trim(arrSplitLine(i))
                            Case 3
                                strWrty = Trim(arrSplitLine(i))
                            Case 5
                                decFixedRate = Trim(arrSplitLine(i))    'Labor
                            Case 7
                                decPartPrice = Trim(arrSplitLine(i))    'Parts
                            Case 8
                                decClaimDiscAmt = Trim(arrSplitLine(i)) 'Claim-Disc
                            Case 9
                                decConsDiscAmt = Trim(arrSplitLine(i))  'Cons-Disc

                            Case 10
                                decTotalPaid = Trim(arrSplitLine(i))
                            
                        End Select
                    Next i
                    j = InsertRow(iAccptedRejectedClaims, decFixedRate, decPartPrice, decClaimDiscAmt, decConsDiscAmt, decTotalPaid)
                ElseIf iAccptedRejectedClaims = 2 Then    'Rejected claims here
                    For i = 0 To UBound(arrSplitLine)
                        Select Case i
                            Case 0  'Claim No
                                If Trim(arrSplitLine(i)) <> "" Then
                                    If Len(strRejectMsg) > 0 Then
                                        j = InsertRow(iAccptedRejectedClaims, , , , )
                                    End If
                                    iClaimNo = Trim(arrSplitLine(i))
                                Else
                                    iFlg = 1
                                End If
                            Case 2  'Rejected reason
                                If iFlg = 1 Then
                                    If Trim(arrSplitLine(i)) <> "" Then
                                        strRejectMsg += Trim(arrSplitLine(i)) & Environment.NewLine
                                    End If
                                End If
                            Case 3  'Warranty type
                                If iFlg = 0 Then
                                    If Trim(arrSplitLine(i)) <> "" Then
                                        strWrty = Trim(arrSplitLine(i))
                                    End If
                                End If
                        End Select
                    Next i
                ElseIf iAccptedRejectedClaims = 3 Then    'Parts here
                    If iParts > 1 Then
                        For i = 0 To UBound(arrSplitLine)
                            Select Case i
                                Case 0
                                    strPrtNum = Trim(arrSplitLine(i))
                                Case 6
                                    iQuantity = Trim(arrSplitLine(i))
                            End Select
                        Next i
                        j = InsertPartsRow(strPrtNum, iQuantity)
                    End If
                End If
            Catch ex As Exception
                Throw ex
            Finally
                arrSplitLine = Nothing
            End Try
        End Function
        '*****************************************************************************
        Private Function InsertRow(ByVal iAccptedRejectedClaims As Integer, _
                                    Optional ByVal decFixedRate As Decimal = 0, _
                                    Optional ByVal decPartPrice As Decimal = 0, _
                                    Optional ByVal decClaimDiscAmt As Decimal = 0, _
                                    Optional ByVal decConsDiscAmt As Decimal = 0, _
                                    Optional ByVal decTotalPaid As Decimal = 0) As Integer

            Dim strsql As String
            Dim i As Integer = 0
            Dim dt As DataTable
            Dim R1 As DataRow

            If iClaimNo = 0 Then
                MsgBox("Claim number missing")
                Exit Function
            End If

            Try
                '****************************************
                'Insert into database here
                '****************************************
                i = objMotoSubcontract_Biz.LoadClaimReconciliationData(strBatchDate, iBatchNumber, iAccptedRejectedClaims, strWrty, decFixedRate, decPartPrice, decClaimDiscAmt, decConsDiscAmt, decTotalPaid, strRejectMsg, iClaimNo)
                '****************************************
                'Update tcellopt with Reconciliation Status of each claim
                '****************************************
                i = UpdateReconStatus(iClaimNo, iAccptedRejectedClaims)
                '****************************************
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                iClaimNo = 0
                strWrty = ""
                strRejectMsg = ""
                R1 = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function
        '*****************************************************************************
        'Updates reconciliation status in tcellopt table
        '*****************************************************************************
        Private Function UpdateReconStatus(ByVal iClaim_No As Integer, _
                                            ByVal iAccptedRejectedClaims As Integer) As Integer
            Dim iClaimExistsInArray As Integer = 0
            Dim j As Integer = 0


            Try
                'Check if the Claim Number exists in the Array
                For j = 0 To UBound(ClaimNoArray)
                    If iClaim_No = ClaimNoArray(j) Then
                        iClaimExistsInArray = 1
                    End If
                Next j
                j = 0
                If iClaimExistsInArray = 0 Then
                    j = objMotoSubcontract_Biz.UpdateReconciliationStatus(iClaim_No, iAccptedRejectedClaims)
                    'Add Claim No to the array here
                    ReDim ClaimNoArray(UBound(ClaimNoArray) + 1)
                    ClaimNoArray(UBound(ClaimNoArray)) = iClaim_No
                End If

                Return j

            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*****************************************************************************
        Private Function InsertPartsRow(ByVal strPrtNum As String, _
                                            ByVal iQnty As Integer) As Integer

            Dim strsql As String
            Dim i As Integer
            Dim dt As DataTable
            Dim R1 As DataRow

            If strPrtNum = "" Then
                MsgBox("Part number missing")
                Exit Function
            End If

            If iQnty <= 0 Then
                MsgBox("Quantity of parts must be greater than zero.")
                Exit Function
            End If

            Try
                '****************************************
                'Insert into database here
                '****************************************
                i = objMotoSubcontract_Biz.LoadClaimReconciliationPartData(iBatchNumber, iQnty, strPrtNum)
                '****************************************

                Return i
            Catch ex As Exception
                Throw ex
            Finally
                R1 = Nothing
                If Not IsNothing(dt) Then
                    dt.Dispose()
                    dt = Nothing
                End If
            End Try
        End Function

        '*****************************************************************************

        Protected Overrides Sub Finalize()
            objMotoSubcontract_Biz = Nothing
            ClaimNoArray = Nothing
            MyBase.Finalize()
        End Sub

        Private Sub frmMotoClaimReconcile_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ClaimNoArray(UBound(ClaimNoArray)) = 0
        End Sub
        Friend WithEvents Label2 As System.Windows.Forms.Label
    End Class
End Namespace
