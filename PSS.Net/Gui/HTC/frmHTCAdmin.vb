Option Explicit On 

Public Class frmHTCAdmin
    Inherits System.Windows.Forms.Form

    Private _objHTC As PSS.Data.Buisness.HTC

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _objHTC = New PSS.Data.Buisness.HTC()

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
    Friend WithEvents btnLoadASNFile As System.Windows.Forms.Button
    Friend WithEvents btnUpdFCRC As System.Windows.Forms.Button
    Friend WithEvents btnCreateClaimRpt As System.Windows.Forms.Button
    Friend WithEvents gbRpt As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mcDate As System.Windows.Forms.MonthCalendar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnLoadASNFile = New System.Windows.Forms.Button()
        Me.btnUpdFCRC = New System.Windows.Forms.Button()
        Me.btnCreateClaimRpt = New System.Windows.Forms.Button()
        Me.gbRpt = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.mcDate = New System.Windows.Forms.MonthCalendar()
        Me.gbRpt.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoadASNFile
        '
        Me.btnLoadASNFile.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnLoadASNFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadASNFile.Location = New System.Drawing.Point(16, 16)
        Me.btnLoadASNFile.Name = "btnLoadASNFile"
        Me.btnLoadASNFile.Size = New System.Drawing.Size(232, 40)
        Me.btnLoadASNFile.TabIndex = 0
        Me.btnLoadASNFile.Text = "LoadASNFile"
        '
        'btnUpdFCRC
        '
        Me.btnUpdFCRC.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnUpdFCRC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdFCRC.Location = New System.Drawing.Point(16, 80)
        Me.btnUpdFCRC.Name = "btnUpdFCRC"
        Me.btnUpdFCRC.Size = New System.Drawing.Size(232, 40)
        Me.btnUpdFCRC.TabIndex = 1
        Me.btnUpdFCRC.Text = "Update Fail Codes/ Repair Codes"
        '
        'btnCreateClaimRpt
        '
        Me.btnCreateClaimRpt.BackColor = System.Drawing.Color.Green
        Me.btnCreateClaimRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateClaimRpt.ForeColor = System.Drawing.Color.White
        Me.btnCreateClaimRpt.Location = New System.Drawing.Point(16, 208)
        Me.btnCreateClaimRpt.Name = "btnCreateClaimRpt"
        Me.btnCreateClaimRpt.Size = New System.Drawing.Size(192, 40)
        Me.btnCreateClaimRpt.TabIndex = 2
        Me.btnCreateClaimRpt.Text = "Create Claim Report"
        '
        'gbRpt
        '
        Me.gbRpt.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.mcDate, Me.btnCreateClaimRpt})
        Me.gbRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbRpt.ForeColor = System.Drawing.Color.White
        Me.gbRpt.Location = New System.Drawing.Point(16, 128)
        Me.gbRpt.Name = "gbRpt"
        Me.gbRpt.Size = New System.Drawing.Size(232, 264)
        Me.gbRpt.TabIndex = 3
        Me.gbRpt.TabStop = False
        Me.gbRpt.Text = "Report"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Select a date."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'mcDate
        '
        Me.mcDate.FirstDayOfWeek = System.Windows.Forms.Day.Sunday
        Me.mcDate.Location = New System.Drawing.Point(12, 40)
        Me.mcDate.MinDate = New Date(2008, 11, 29, 0, 0, 0, 0)
        Me.mcDate.Name = "mcDate"
        Me.mcDate.TabIndex = 4
        '
        'frmHTCAdmin
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(560, 405)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbRpt, Me.btnUpdFCRC, Me.btnLoadASNFile})
        Me.Name = "frmHTCAdmin"
        Me.Text = "Administration"
        Me.gbRpt.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '************************************************************************************
    Private Sub frmHTCAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            PSS.Core.Highlight.SetHighLight(Me)

            DoSelection()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnUpdFCRC_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '************************************************************************************
    Private Sub btnLoadASNFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadASNFile.Click
        Dim fdOpenFile As OpenFileDialog
        Dim strFilePath As String = ""
        Dim i As Integer = 0

        Try
            fdOpenFile = New OpenFileDialog()
            fdOpenFile.DefaultExt = ".*"
            fdOpenFile.ShowDialog()
            strFilePath = fdOpenFile.FileName

            If strFilePath.Trim.Length = 0 Then
                Exit Sub
            Else
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor
                'i = Me._objHTC.LoadHTCASNFile(strFilePath)
                i = Me._objHTC.LoadHTCDetailFile(strFilePath)
                If i > 0 Then
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            'MsgBox(strFilePath)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnLoadASNFile_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If Not IsNothing(fdOpenFile) Then
                fdOpenFile.Dispose()
                fdOpenFile = Nothing
            End If
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '************************************************************************************
    Private Sub btnUpdFCRC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdFCRC.Click
        Const iTotalRow As Integer = 177
        Const iModel_ID As Integer = 1120
        Const iManufID As Integer = 47
        Const iProdID As Integer = 2
        Const strFilePath As String = "C:\Customers\HTC\ToPSSI\Fail Codes Repair Codes Part Map\HTC Fail Code selection matrix11 10 08RevD.xls"
        Dim objExcel As Excel.Application    ' Excel application
        Dim objBook As Excel.Workbook     ' Excel workbook
        Dim objSheet As Excel.Worksheet    ' Excel Worksheet
        Dim dt1 As DataTable
        Dim i As Integer = 2
        Dim strSql As String = ""
        Dim strFailCode As String = ""
        Dim strFailDesc As String = ""
        Dim strRepCode As String = ""
        Dim strRepDesc As String = ""
        Dim strRepType As String = ""
        Dim iRepLevel As Integer = 0
        Dim strPartNumber As String = ""
        Dim strPartDesc As String = ""
        Dim strPartComment As String = ""
        Dim strFailMainCategory As String = ""
        Dim iFailID As Integer
        Dim iRepairID As Integer
        Dim iPartID As Integer
        Dim iPsPriceID As Integer = 0
        Dim iMainCategoryID As Integer = 0

        Try
            objExcel = New Excel.Application()
            objBook = objExcel.Workbooks.Open(strFilePath)
            objSheet = objExcel.Worksheets(1)
            objExcel.Visible = True

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            While i <= iTotalRow
                strFailMainCategory = objSheet.Range("A" & i).Value.ToString.Trim.ToUpper
                strFailCode = objSheet.Range("B" & i).Value.ToString.Trim.ToUpper
                strFailDesc = objSheet.Range("C" & i).Value.ToString.Trim.ToUpper
                strRepCode = objSheet.Range("D" & i).Value.ToString.Trim.ToUpper
                strRepDesc = objSheet.Range("E" & i).Value.ToString.Trim.ToUpper
                iRepLevel = CInt(objSheet.Range("F" & i).Value.ToString)
                strPartNumber = objSheet.Range("G" & i).Value.ToString.Trim.ToUpper
                If Not IsNothing(objSheet.Range("H" & i).Value) Then strPartDesc = objSheet.Range("H" & i).Value.ToString.Trim.ToUpper
                strRepType = objSheet.Range("I" & i).Value.ToString.Trim.ToUpper
                If Not IsNothing(objSheet.Range("J" & i).Value) Then strPartComment = objSheet.Range("J" & i).Value.ToString.Trim

                If strFailCode.Length > 0 And strFailDesc.Length > 0 And strRepCode.Length > 0 And strRepDesc.Length > 0 And iRepLevel > 0 And strPartNumber.Length > 0 Then
                    '***********************
                    'Get Main Categories
                    '***********************
                    iMainCategoryID = Me._objHTC.GetFailCodeMainCategoriesID(strFailMainCategory, 0)
                    If iMainCategoryID = 0 Then
                        iMainCategoryID = Me._objHTC.InsertNewMainCategoryFailCode(strFailMainCategory)
                    Else
                        Me._objHTC.UpdateMainCategoryFailCode(strFailMainCategory, iMainCategoryID)
                    End If

                    '***********************
                    'Get Fail Code
                    '***********************
                    iFailID = Me._objHTC.GetFailID(strFailCode, iModel_ID, 0)
                    If iFailID = 0 Then
                        iFailID = Me._objHTC.InsertNewFailCode(strFailCode, strFailDesc, iModel_ID, iManufID, iProdID)
                    Else
                        Me._objHTC.UpdateFailCodeDescription(strFailCode, strFailDesc, iModel_ID, iFailID)
                    End If

                    '***********************
                    'Get Repair Code
                    '***********************
                    iRepairID = Me._objHTC.GetRepairID(strRepCode, iModel_ID, 0)
                    If iRepairID = 0 Then
                        iRepairID = Me._objHTC.InsertNewRepairCode(strRepCode, strRepDesc, iRepLevel, strRepType, iModel_ID, iManufID, iProdID)
                    Else
                        Me._objHTC.UpdateRepairCode(strRepDesc, iRepLevel, strRepType, iModel_ID, iRepairID)
                    End If

                    If strPartNumber <> "N/A" Then
                        '***********************
                        'Get part ID
                        '***********************
                        iPartID = Me._objHTC.GetHTCPartID(strPartNumber, iModel_ID, 0)
                        iPsPriceID = Me._objHTC.GetPsPriceIDByPartNumber(strPartNumber)
                        If iPartID = 0 Then
                            iPartID = Me._objHTC.InsertNewHTCPartNumber(strPartNumber, strPartDesc, iModel_ID, iPsPriceID)
                        Else
                            Me._objHTC.UpdateHTCPartDescPSPriceID(strPartNumber, strPartDesc, iPsPriceID, iModel_ID, iPartID)
                        End If
                    End If

                    '**********************************************
                    'Get maping of Main category, Fail code, Repair Code and Part Number
                    '**********************************************
                    If iMainCategoryID = 0 Or iFailID = 0 Or iRepairID = 0 Or iPartID = 0 Then
                        objSheet.Range("L" & i).FormulaR1C1 = "Fail to map MC/FC/RC/PN"
                    Else
                        PSS.Data.Buisness.Generic.DisposeDT(dt1)
                        dt1 = Me._objHTC.GetMainCategory_FailCode_RepairCode_PartNum_Matrix(iMainCategoryID, iFailID, iRepairID, iPartID, 0)
                        If dt1.Rows.Count = 0 Then
                            Me._objHTC.MapMainCategory_FailCode_RepairCode_PartNum(iMainCategoryID, iFailID, iRepairID, iPartID)
                        ElseIf dt1.Rows.Count = 1 Then
                            Me._objHTC.SetMapMainCategory_FailCode_RepairCode_PartNum_ToActiveInactive(dt1.Rows(0)("FCRCmap_ID"), 0)
                        Else
                            objSheet.Range("M" & i).FormulaR1C1 = "Duplicate map MC_ID = " & iMainCategoryID & " FailID = " & iFailID & " RepairID = " & iRepairID & " PartID = " & iPartID
                        End If
                    End If
                End If

                i += 1
                strFailMainCategory = ""
                strFailCode = ""
                strFailDesc = ""
                strRepCode = ""
                strRepDesc = ""
                iRepLevel = 0
                strPartNumber = ""
                strPartDesc = ""
                strPartComment = ""
                strRepType = ""
                iFailID = 0
                iRepairID = 0
                iPartID = 0
                iPsPriceID = 0
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
            End While

            objBook.SaveAs(strFilePath)
            MsgBox("Completed.")

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "btnUpdFCRC_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            If Not IsNothing(objSheet) Then
                objSheet = Nothing
                PSS.Data.Buisness.Generic.NAR(objSheet)
            End If
            If Not IsNothing(objBook) Then
                objBook.Close()
                objBook = Nothing
                PSS.Data.Buisness.Generic.NAR(objBook)
            End If
            If Not IsNothing(objExcel) Then
                objExcel.Quit()
                objExcel = Nothing
                PSS.Data.Buisness.Generic.NAR(objExcel)
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()

            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*************************************************************************
    Private Sub mcDate_DateSelected(ByVal sender As Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mcDate.DateSelected
        Try
            DoSelection()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "mcDate_DateSelected", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*************************************************************************
    Private Sub DoSelection()
        Try
            Me.mcDate.SelectionStart = DateAdd(DateInterval.Day, -1, Me.mcDate.SelectionStart)
            Me.mcDate.SelectionEnd = DateAdd(DateInterval.Day, 7, Me.mcDate.SelectionStart)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*************************************************************************
    Private Sub btnCreateClaimRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateClaimRpt.Click
        Try
            Me._objHTC.CreateInvoiceReport(Me.mcDate.SelectionStart, Me.mcDate.SelectionEnd)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "CreateClaimRpt", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '*************************************************************************



End Class
