Option Explicit On 

Imports PSS.Core.Global

Public Class frmPartRelated
    Inherits System.Windows.Forms.Form

    Private _objPartRelated As PSS.Data.Buisness.PartRelated
    Private _iUserID As Integer = ApplicationUser.IDuser
    Private _strWorkDate As String = ApplicationUser.Workdate

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objPartRelated = New PSS.Data.Buisness.PartRelated()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        Me._objPartRelated = Nothing

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPreBillLotName As System.Windows.Forms.ComboBox
    Friend WithEvents btnGetOptIIWaitingPartRpt As System.Windows.Forms.Button
    Friend WithEvents btnReleaseLotFrWatingPart As System.Windows.Forms.Button
    Friend WithEvents pnlReleasePrebillLot As System.Windows.Forms.Panel
    Friend WithEvents btnRollBackToWaitingPart As System.Windows.Forms.Button
    Friend WithEvents pnlOptIIPreBillAdmin As System.Windows.Forms.Panel
    Friend WithEvents btnGetReleasedLot As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlReleasePrebillLot = New System.Windows.Forms.Panel()
        Me.btnReleaseLotFrWatingPart = New System.Windows.Forms.Button()
        Me.cmbPreBillLotName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlOptIIPreBillAdmin = New System.Windows.Forms.Panel()
        Me.btnGetReleasedLot = New System.Windows.Forms.Button()
        Me.btnRollBackToWaitingPart = New System.Windows.Forms.Button()
        Me.btnGetOptIIWaitingPartRpt = New System.Windows.Forms.Button()
        Me.Panel4.SuspendLayout()
        Me.pnlReleasePrebillLot.SuspendLayout()
        Me.pnlOptIIPreBillAdmin.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Yellow
        Me.Label1.Location = New System.Drawing.Point(16, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(232, 24)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Pre-Bill Lot"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlReleasePrebillLot, Me.pnlOptIIPreBillAdmin})
        Me.Panel4.Location = New System.Drawing.Point(16, 48)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(320, 248)
        Me.Panel4.TabIndex = 78
        '
        'pnlReleasePrebillLot
        '
        Me.pnlReleasePrebillLot.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlReleasePrebillLot.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReleaseLotFrWatingPart, Me.cmbPreBillLotName, Me.Label3})
        Me.pnlReleasePrebillLot.Name = "pnlReleasePrebillLot"
        Me.pnlReleasePrebillLot.Size = New System.Drawing.Size(312, 80)
        Me.pnlReleasePrebillLot.TabIndex = 80
        '
        'btnReleaseLotFrWatingPart
        '
        Me.btnReleaseLotFrWatingPart.BackColor = System.Drawing.Color.SteelBlue
        Me.btnReleaseLotFrWatingPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReleaseLotFrWatingPart.ForeColor = System.Drawing.Color.White
        Me.btnReleaseLotFrWatingPart.Location = New System.Drawing.Point(8, 48)
        Me.btnReleaseLotFrWatingPart.Name = "btnReleaseLotFrWatingPart"
        Me.btnReleaseLotFrWatingPart.Size = New System.Drawing.Size(296, 25)
        Me.btnReleaseLotFrWatingPart.TabIndex = 75
        Me.btnReleaseLotFrWatingPart.Text = "Release Wating Part Lot To Production"
        '
        'cmbPreBillLotName
        '
        Me.cmbPreBillLotName.Location = New System.Drawing.Point(8, 24)
        Me.cmbPreBillLotName.Name = "cmbPreBillLotName"
        Me.cmbPreBillLotName.Size = New System.Drawing.Size(296, 21)
        Me.cmbPreBillLotName.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 16)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Select Pre-Bill Lot Name:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'pnlOptIIPreBillAdmin
        '
        Me.pnlOptIIPreBillAdmin.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlOptIIPreBillAdmin.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGetReleasedLot, Me.btnRollBackToWaitingPart, Me.btnGetOptIIWaitingPartRpt})
        Me.pnlOptIIPreBillAdmin.Location = New System.Drawing.Point(0, 80)
        Me.pnlOptIIPreBillAdmin.Name = "pnlOptIIPreBillAdmin"
        Me.pnlOptIIPreBillAdmin.Size = New System.Drawing.Size(312, 144)
        Me.pnlOptIIPreBillAdmin.TabIndex = 80
        '
        'btnGetReleasedLot
        '
        Me.btnGetReleasedLot.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGetReleasedLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetReleasedLot.ForeColor = System.Drawing.Color.White
        Me.btnGetReleasedLot.Location = New System.Drawing.Point(8, 96)
        Me.btnGetReleasedLot.Name = "btnGetReleasedLot"
        Me.btnGetReleasedLot.Size = New System.Drawing.Size(296, 25)
        Me.btnGetReleasedLot.TabIndex = 76
        Me.btnGetReleasedLot.Text = "Get Released Lots Rpt"
        '
        'btnRollBackToWaitingPart
        '
        Me.btnRollBackToWaitingPart.BackColor = System.Drawing.Color.Red
        Me.btnRollBackToWaitingPart.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRollBackToWaitingPart.ForeColor = System.Drawing.Color.White
        Me.btnRollBackToWaitingPart.Location = New System.Drawing.Point(8, 8)
        Me.btnRollBackToWaitingPart.Name = "btnRollBackToWaitingPart"
        Me.btnRollBackToWaitingPart.Size = New System.Drawing.Size(296, 25)
        Me.btnRollBackToWaitingPart.TabIndex = 75
        Me.btnRollBackToWaitingPart.Text = "Roll Lot Back to Waiting For Part"
        '
        'btnGetOptIIWaitingPartRpt
        '
        Me.btnGetOptIIWaitingPartRpt.BackColor = System.Drawing.Color.SteelBlue
        Me.btnGetOptIIWaitingPartRpt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetOptIIWaitingPartRpt.ForeColor = System.Drawing.Color.White
        Me.btnGetOptIIWaitingPartRpt.Location = New System.Drawing.Point(8, 56)
        Me.btnGetOptIIWaitingPartRpt.Name = "btnGetOptIIWaitingPartRpt"
        Me.btnGetOptIIWaitingPartRpt.Size = New System.Drawing.Size(296, 25)
        Me.btnGetOptIIWaitingPartRpt.TabIndex = 74
        Me.btnGetOptIIWaitingPartRpt.Text = "Get Waiting Part Rpt"
        '
        'frmPartRelated
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(408, 366)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.Panel4})
        Me.Name = "frmPartRelated"
        Me.Text = "Part Related"
        Me.Panel4.ResumeLayout(False)
        Me.pnlReleasePrebillLot.ResumeLayout(False)
        Me.pnlOptIIPreBillAdmin.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '*****************************************************************
    Private Sub frmPartRelated_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPreBillLotNamesCombo()

        If Me.cmbPreBillLotName.Items.Count > 0 Then
            Me.btnReleaseLotFrWatingPart.Enabled = True
        Else
            Me.btnReleaseLotFrWatingPart.Enabled = False
        End If

        If ApplicationUser.GetPermission("PartsRelatedAdmin") > 0 Then
            Me.pnlOptIIPreBillAdmin.Visible = True
        Else
            Me.pnlOptIIPreBillAdmin.Visible = False
        End If

    End Sub

    '*****************************************************************
    Private Sub LoadPreBillLotNamesCombo()
        Dim dt As DataTable

        Try
            Me.cmbPreBillLotName.DataSource = Nothing

            dt = Me._objPartRelated.GetPreBillLotNames()

            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    Me.cmbPreBillLotName.DataSource = dt
                    Me.cmbPreBillLotName.DisplayMember = dt.Columns(0).ToString
                    Me.cmbPreBillLotName.ValueMember = dt.Columns(0).ToString
                    Me.cmbPreBillLotName.SelectedIndex = 0
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error Loading PreBill Lot Names Combo")
        End Try
    End Sub

    '*****************************************************************
    Private Sub btnGetOptIIWaitingPartRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetOptIIWaitingPartRpt.Click
        Const strWorksheetName = "Opts II Waiting Parts"
        Dim dt As DataTable
        Dim dr As DataRow
        Dim objXL As Excel.Application
        Dim objWorkbook As Excel.Workbook
        Dim objSheet As Excel.Worksheet
        Dim iRow As Integer = 0

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            dt = Me._objPartRelated.GetPreBillReportData()

            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    objXL = New Excel.Application()
                    objWorkbook = objXL.workbooks.add
                    objXL.Visible = True

                    objSheet = objWorkbook.Sheets("Sheet1")
                    'objSheet.Activate()
                    objSheet.Name = strWorksheetName

                    FormatWaitingPartsXLsheet(objSheet)

                    With objSheet.PageSetup
                        .PrintTitleRows = ""
                        .PrintTitleColumns = ""
                        .PrintArea = ""
                        .PrintQuality = 600
                        .CenterHorizontally = False
                        .CenterVertically = False
                        .Orientation = Excel.XlPageOrientation.xlLandscape
                        .Draft = False
                        .PaperSize = Excel.XlPaperSize.xlPaperLetter
                        .FirstPageNumber = Excel.Constants.xlAutomatic
                        .BlackAndWhite = False
                        .Zoom = False
                        .FitToPagesWide = 1
                        .FitToPagesTall = 1
                    End With

                    iRow = 1

                    For Each dr In dt.Rows
                        iRow += 1

                        objSheet.Range(CStr("A" & iRow)).Value = dr("PreBillLot_Name")

                        objSheet.Range(CStr("B" & iRow & ":B" & iRow)).NumberFormat = "#,##0_);[Red](#,##0)"

                        objSheet.Range(CStr("B" & iRow)).Value = dr("PreBillLot_Qty")

                        objSheet.Range(CStr("C" & iRow)).Value = dr("Model_Desc")
                        objSheet.Range(CStr("D" & iRow)).NumberFormat = "@"
                        objSheet.Range(CStr("D" & iRow)).Value = dr("PSPrice_Number")
                        objSheet.Range(CStr("E" & iRow)).Value = dr("PSPrice_Desc")

                        objSheet.Range(CStr("F" & iRow & ":H" & iRow)).NumberFormat = "#,##0_);[Red](#,##0)"

                        objSheet.Range(CStr("F" & iRow)).Value = dr("BilledQty")
                        objSheet.Range(CStr("G" & iRow)).Value = dr("NavQty")
                        objSheet.Range(CStr("H" & iRow)).Value = dr("OnOrderQty")
                    Next

                    FormatXLSheetBorders(objXL, "A1:H" & iRow)

                    ' Freeze column title area
                    objXL.ActiveWindow.FreezePanes = False
                    objXL.Range(CStr("A2:H2")).Select()
                    objXL.ActiveWindow.FreezePanes = True

                    objSheet = objWorkbook.Sheets(strWorksheetName)
                    objSheet.select()
                End If
            End If

            If iRow > 0 Then
                MessageBox.Show("Report is completed.", "Get OptII Waiting Parts Rpt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("No data to generate report.", "Get OptII Waiting Parts Rpt", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error Processing Report")
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If

            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*****************************************************************
    Private Sub FormatWaitingPartsXLsheet(ByRef xlw As Excel.Worksheet)
        Dim strColumn() = {"A", "B", "C", "D", "E", "F", "G", "H"}
        Dim iColumnLength() = {25, 12, 25, 25, 40, 10, 12, 10}
        Dim strColumnHeader() = {"Lot Name", "Lot Unit Qty", "Model Desc", "Navision Part Number", "Navision Part Desc", "Billed Qty", "Navision Qty", "On Order"}
        Dim i As Integer

        Try
            With xlw.Rows("1:1")
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = True
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With

            For i = 0 To strColumn.Length - 1
                xlw.Range(strColumn(i) & "1").FormulaR1C1 = strColumnHeader(i)

                With xlw.Range(strColumn(i) & "1").Characters(Start:=1, Length:=iColumnLength(i)).Font
                    .Name = "Arial"
                    .FontStyle = "Regular"
                    .Size = 10
                    .Strikethrough = False
                    .Superscript = False
                    .Subscript = False
                    .OutlineFont = False
                    .Shadow = False
                    .ColorIndex = Excel.Constants.xlAutomatic
                End With
            Next i

            With xlw.Columns("A:A")
                .HorizontalAlignment = Excel.Constants.xlColumn.xlJustify.xlLeft
            End With

            With xlw.Columns("B:B")
                .HorizontalAlignment = Excel.Constants.xlColumn.xlJustify.xlRight
            End With



            With xlw.Columns("C:E")
                .HorizontalAlignment = Excel.Constants.xlColumn.xlJustify.xlLeft
            End With

            With xlw.Columns("F:H")
                .HorizontalAlignment = Excel.Constants.xlColumn.xlJustify.xlRight
            End With

            xlw.Columns("H:H").ColumnWidth = 10
            xlw.Columns("G:G").ColumnWidth = 12
            xlw.Columns("F:F").ColumnWidth = 10
            xlw.Columns("E:E").ColumnWidth = 40
            xlw.Columns("C:D").ColumnWidth = 25
            xlw.Columns("B:B").ColumnWidth = 12
            xlw.Columns("A:A").ColumnWidth = 25
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    '*****************************************************************
    Private Sub FormatXLSheetBorders(ByRef objXL As Excel.Application, _
                                     ByVal strRange As String)
        objXL.Range(strRange).Select()
        objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.Constants.xlNone
        objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.Constants.xlNone

        With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.Constants.xlAutomatic
        End With

        With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.Constants.xlAutomatic
        End With

        With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.Constants.xlAutomatic
        End With

        With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.Constants.xlAutomatic
        End With

        With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.Constants.xlAutomatic
        End With

        With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
            .LineStyle = Excel.XlLineStyle.xlContinuous
            .Weight = Excel.XlBorderWeight.xlThin
            .ColorIndex = Excel.Constants.xlAutomatic
        End With
    End Sub

    '*****************************************************************
    Private Sub btnReleaseLotFrWatingPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReleaseLotFrWatingPart.Click
        Dim strLotName As String
        Dim i As Integer = 0
        Dim iIncellWipOwnerID As Integer = 3

        Try
            If Me.cmbPreBillLotName.SelectedIndex = -1 Then
                MsgBox("Please select a lot to release.", MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Select Lot")
            Else
                strLotName = Me.cmbPreBillLotName.Text

                If MessageBox.Show("Are you sure you want to RELEASE this lot """ & strLotName & """ from 'Awaiting Parts' to 'Production'?", "Release Waiting Part Lot", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                i = Me._objPartRelated.ClosePreBillLot(strLotName, Me._iUserID, Me._strWorkDate, iIncellWipOwnerID)

                If i > 0 Then
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.LoadPreBillLotNamesCombo()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error Release Lot " & strLotName)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*****************************************************************
    Private Sub btnRollBackToWaitingPart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRollBackToWaitingPart.Click
        Dim strLotName As String
        Dim i As Integer = 0
        Dim iLotStatus As Integer = 0
        Dim iLotShipQty As Integer = 0
        Dim iAWAPWipOwnerID As Integer = 8
        Dim iProdInCellWipOwnereID As Integer = 3

        Try
            '**************************
            'Get lot name from user
            '**************************
            strLotName = Trim(InputBox("Lot Name:", "Get Lot Name", ""))
            If strLotName = "" Then
                MessageBox.Show("No data input from user.", "Roll Back Lot to wating for part", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If MessageBox.Show("Are you sure you want to ROLL BACK this LOT """ & strLotName & """ wating for part?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            '**************************
            'Check for status of lot
            '**************************
            iLotStatus = Me._objPartRelated.GetPreBillLotStatus(strLotName, iProdInCellWipOwnereID)

            If iLotStatus = -1 Then
                MessageBox.Show("Lot name does not existed or does not belong to wating for part.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            ElseIf iLotStatus = 0 Then
                MessageBox.Show("Lot is already in AWAP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '*******************************************
            'Check if any devices in lot got ship date
            '*******************************************
            iLotShipQty = Me._objPartRelated.GetShipQty_OfPreBillLot(strLotName)
            If iLotShipQty > 0 Then
                MessageBox.Show("Can't roll back because there are device(s) have been shipped out from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '***************
            'Roll back
            '***************
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            i = Me._objPartRelated.RollBackPreBillLotToWaitingParts(strLotName, Me._iUserID, Me._strWorkDate, iAWAPWipOwnerID)

            If i > 0 Then
                MessageBox.Show("This lot """ & strLotName & """ is now in wating for part.", "Roll Back To Waiting Part", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.LoadPreBillLotNamesCombo()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error in " & strLotName)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '*****************************************************************
    Private Sub btnGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetReleasedLot.Click
        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Me.Enabled = False
            Me._objPartRelated.GetInactivePreBillLotAndShipQty()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation Or MsgBoxStyle.OKOnly, "Error Get Released Lot")
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.Enabled = True
        End Try
    End Sub

    '*****************************************************************
End Class
