Imports System
Imports System.GC
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global

Namespace DSCPalletBuild

    Public Class frmDscPalletBuild
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
        Friend WithEvents btnBuildPallet As System.Windows.Forms.Button
        Friend WithEvents lblTitle As System.Windows.Forms.Label
        Friend WithEvents lblDiscrepant As System.Windows.Forms.Label
        Friend WithEvents lstDiscrepant As System.Windows.Forms.ListBox
        Friend WithEvents txtBOX As System.Windows.Forms.TextBox
        Friend WithEvents lblBOX As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtDEVICE As System.Windows.Forms.TextBox
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents lblTitleCount As System.Windows.Forms.Label
        Friend WithEvents btnNoDevice As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.btnBuildPallet = New System.Windows.Forms.Button()
            Me.lblTitle = New System.Windows.Forms.Label()
            Me.txtBOX = New System.Windows.Forms.TextBox()
            Me.lblDiscrepant = New System.Windows.Forms.Label()
            Me.lstDiscrepant = New System.Windows.Forms.ListBox()
            Me.lblBOX = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtDEVICE = New System.Windows.Forms.TextBox()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.lblTitleCount = New System.Windows.Forms.Label()
            Me.btnNoDevice = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'btnBuildPallet
            '
            Me.btnBuildPallet.Location = New System.Drawing.Point(216, 248)
            Me.btnBuildPallet.Name = "btnBuildPallet"
            Me.btnBuildPallet.Size = New System.Drawing.Size(280, 56)
            Me.btnBuildPallet.TabIndex = 0
            Me.btnBuildPallet.Text = "Build Discrepant Pallet"
            '
            'lblTitle
            '
            Me.lblTitle.Location = New System.Drawing.Point(24, 16)
            Me.lblTitle.Name = "lblTitle"
            Me.lblTitle.Size = New System.Drawing.Size(152, 16)
            Me.lblTitle.TabIndex = 0
            Me.lblTitle.Text = "Scan Discrepant Device IMEI"
            '
            'txtBOX
            '
            Me.txtBOX.Location = New System.Drawing.Point(24, 64)
            Me.txtBOX.Name = "txtBOX"
            Me.txtBOX.Size = New System.Drawing.Size(144, 20)
            Me.txtBOX.TabIndex = 1
            Me.txtBOX.Text = ""
            '
            'lblDiscrepant
            '
            Me.lblDiscrepant.Location = New System.Drawing.Point(216, 16)
            Me.lblDiscrepant.Name = "lblDiscrepant"
            Me.lblDiscrepant.Size = New System.Drawing.Size(152, 16)
            Me.lblDiscrepant.TabIndex = 0
            Me.lblDiscrepant.Text = "Discrepant IMEI"
            '
            'lstDiscrepant
            '
            Me.lstDiscrepant.Location = New System.Drawing.Point(216, 32)
            Me.lstDiscrepant.Name = "lstDiscrepant"
            Me.lstDiscrepant.Size = New System.Drawing.Size(280, 212)
            Me.lstDiscrepant.TabIndex = 0
            '
            'lblBOX
            '
            Me.lblBOX.Location = New System.Drawing.Point(24, 40)
            Me.lblBOX.Name = "lblBOX"
            Me.lblBOX.Size = New System.Drawing.Size(48, 16)
            Me.lblBOX.TabIndex = 0
            Me.lblBOX.Text = "BOX:"
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(24, 88)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(48, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "DEVICE:"
            '
            'txtDEVICE
            '
            Me.txtDEVICE.Location = New System.Drawing.Point(24, 112)
            Me.txtDEVICE.Name = "txtDEVICE"
            Me.txtDEVICE.Size = New System.Drawing.Size(144, 20)
            Me.txtDEVICE.TabIndex = 2
            Me.txtDEVICE.Text = ""
            '
            'lblCount
            '
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.Location = New System.Drawing.Point(552, 56)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(100, 56)
            Me.lblCount.TabIndex = 0
            '
            'lblTitleCount
            '
            Me.lblTitleCount.Location = New System.Drawing.Point(544, 32)
            Me.lblTitleCount.Name = "lblTitleCount"
            Me.lblTitleCount.Size = New System.Drawing.Size(48, 16)
            Me.lblTitleCount.TabIndex = 0
            Me.lblTitleCount.Text = "COUNT:"
            '
            'btnNoDevice
            '
            Me.btnNoDevice.Location = New System.Drawing.Point(24, 144)
            Me.btnNoDevice.Name = "btnNoDevice"
            Me.btnNoDevice.Size = New System.Drawing.Size(144, 23)
            Me.btnNoDevice.TabIndex = 3
            Me.btnNoDevice.Text = "Box Serial Number Only"
            '
            'frmDscPalletBuild
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(688, 325)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnNoDevice, Me.lblTitleCount, Me.lblCount, Me.txtDEVICE, Me.Label1, Me.lblBOX, Me.lstDiscrepant, Me.lblDiscrepant, Me.txtBOX, Me.lblTitle, Me.btnBuildPallet})
            Me.Name = "frmDscPalletBuild"
            Me.Text = "frmDscPalletBuild"
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Const defaultCount As String = "-001"
        Private dtIMEI As New DataTable()




        Private strPallet As String
        Private strSQL As String
        Private dtGridMain, dtDSC_IMEI As DataTable



        Private Function CreateMainGrid() As DataTable
            Dim dtGrid As New DataTable("dtGridMain")

            dtGrid.MinimumCapacity = 500
            dtGrid.CaseSensitive = False

            Dim dcBoxSN As New DataColumn("BoxSN")
            dtGrid.Columns.Add(dcBoxSN)
            Dim dcDeviceSN As New DataColumn("DeviceSN")
            dtGrid.Columns.Add(dcDeviceSN)
            Dim dcWHR_ID As New DataColumn("WHR_ID")
            dtGrid.Columns.Add(dcWHR_ID)

            Return dtGrid

        End Function



        Private Sub validatedata(ByVal vBox As String, ByVal vDevice As String)


            Dim blnRecord As Boolean = False

            Dim x As Integer = 0
            Dim xC As Integer = 0
            Dim r As DataRow
            Dim rC As DataRow

            For x = 0 To dtIMEI.Rows.Count - 1
                r = dtIMEI.Rows(x)
                If IsDBNull(r("Box")) = False And IsDBNull(r("Device")) = False Then
                    If r("Box") = vBox And r("Device") = vDevice Then
                        '//add data to dtdsc_imei
                        '//Validate not already in list
                        For xC = 0 To dtDSC_IMEI.Rows.Count - 1
                            rC = dtDSC_IMEI.Rows(xC)
                            If r("Box") = vBox And r("Device") = vDevice And r("mID") = rC("WHR_ID") Then
                                MsgBox("This record is a duplicate for this pallet. IT CAN NOT BE ADDED.")
                                txtDEVICE.Text = ""
                                txtBOX.Text = ""
                                txtBOX.Focus()
                                Exit Sub
                            End If
                        Next
                        '//Validate not already in list

                        Dim dr1 As DataRow = dtDSC_IMEI.NewRow
                        dr1("BoxSN") = r("Box")
                        dr1("DeviceSN") = r("Device")
                        dr1("WHR_ID") = r("mID")
                        dtDSC_IMEI.Rows.Add(dr1)
                        blnRecord = True
                        lstDiscrepant.Items.Add(r("Device"))
                        System.Windows.Forms.Application.DoEvents()
                        Me.lblCount.Text = lstDiscrepant.Items.Count



                        '//Duplicate Count Check
                        'If r("Dup") > 0 Then
                        'Dim dsDupCount As PSS.Data.Production.Joins
                        'Dim dtDupCount As DataTable = dsDupCount.OrderEntrySelect("SELECT Count(WHP_PieceIdentifier) as recCount FROM twarehousepalletload WHERE WHP_Duplicate = 1 AND WHP_PieceIdentifier = '" & r("Device") & "'")
                        'Dim rDupCount As DataRow
                        'rDupCount = dtDupCount.Rows(0)
                        'If r("recCount") > 1 Then

                        'Dim countDup As Integer = 0
                        'For countDup = 0 To CInt(r("recCount")) - 1
                        'Dim dr2 As DataRow = dtDSC_IMEI.NewRow
                        'dr2("BoxSN") = "DUP" & countDup & " " & r("Box")
                        'dr2("DeviceSN") = "DUP" & countDup & " " & r("Device")
                        'dr2("WHR_ID") = countDup
                        'dtDSC_IMEI.Rows.Add(dr2)
                        'lstDiscrepant.Items.Add(r("Device"))
                        'System.Windows.Forms.Application.DoEvents()
                        'Me.lblCount.Text = lstDiscrepant.Items.Count
                        'Next
                        'End If
                        'End If
                '//Duplicate Count Check


                txtDEVICE.Text = ""
                txtBOX.Text = ""
                txtBOX.Focus()
                Exit For
                End If
                Else
                '//goto next record
                End If

            Next

            If blnRecord = False Then
                MsgBox("The device could not be reconciled - NOT ENTERD INTO PALLET.")
                txtDEVICE.Text = ""
                txtBOX.Text = ""
                txtBOX.Focus()
            End If


        End Sub




        Private Sub getIMEI_LIST()
            Dim ds As PSS.Data.Production.Joins
            strSQL = "select WHR_Box_SN as Box, WHR_Dev_SN as Device, WHR_ID as mID, WHR_DupInFile as Dup from twarehousereceive where WHR_Result > 0 and pallett_id is null order by whr_id desc"
            dtIMEI = ds.OrderEntrySelect(strSQL)
            If dtIMEI.Rows.Count < 1 Then
                MsgBox("There are no unshipped discrepant devices.")
            End If
        End Sub


        Private Sub checkIMEI()
            If Len(Trim(Me.txtBOX.Text)) > 0 And Len(Trim(Me.txtDEVICE.Text)) > 0 Then
                '//Try to validate data 
                validatedata(txtBOX.Text, txtDEVICE.Text)
            Else
                If Len(Trim(Me.txtBOX.Text)) < 1 Then
                    txtBOX.Focus()
                    Exit Sub
                ElseIf Len(Trim(Me.txtDEVICE.Text)) < 1 Then
                    txtDEVICE.Focus()
                    Exit Sub
                End If
            End If
        End Sub



        Private Sub btnBuildPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildPallet.Click


            If lstDiscrepant.Items.Count < 1 Then
                MsgBox("Please identify devices before continuing. Nothing to print.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If


            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim objDataset1 As New DataSet()
            Dim objXL As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet

            '//Get the correct name for the pallet
            Dim ds As PSS.Data.Production.Joins
            Dim mDate As String = (Format(Now, "yyyyMMdd"))
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM tpallett WHERE Pallett_Name LIKE '" & mDate & "%' ORDER BY Pallett_Name")
            Dim r As DataRow

            If dt.Rows.Count < 1 Then
                strPallet = mDate & defaultCount                              '//Set Default
            Else
                Dim mInt As Integer = 0
                r = dt.Rows(dt.Rows.Count - 1)                          '//Get Last Record
                mInt = CInt(Mid$(r("Pallett_Name"), 10, 3))                  '//Separate out counter value
                mInt += 1                                               '//Increment counter by 1
                strPallet = mDate & "-" & mInt.ToString.PadLeft(3, "0") '//Concactenate the pallet name
            End If

            '//Insert value to table
            strSQL = "INSERT INTO tpallett (Pallett_Name, Pallett_ShipDate, Pallett_BulkShipped) VALUES ('" & strPallet & "', '" & Gui.Receiving.FormatDateShort(Now) & "', 9)"

            Dim tblWO As New PSS.Data.Production.tworkorder()
            Dim mPalletID As Long = tblWO.idTransaction(strSQL)

            Dim dsUpdate As PSS.Data.Production.Joins
            Dim blnUpdate As Boolean

            Dim x As Integer = 0
            If mPalletID > 0 Then

                For x = 0 To dtDSC_IMEI.Rows.Count - 1
                    r = dtDSC_IMEI.Rows(x)
                    If Len(Trim(r("WHR_ID"))) > 0 Then
                        '//update record
                        strSQL = "UPDATE twarehousereceive SET Pallett_ID = " & mPalletID & " WHERE WHR_ID = " & r("WHR_ID")
                        System.Windows.Forms.Application.DoEvents()
                        blnUpdate = dsUpdate.OrderEntryUpdateDelete(strSQL)

                        If blnUpdate = False Then
                            MsgBox("Device Serial Number: " & r("DeviceSN") & " could not be set to this pallet.", MsgBoxStyle.Critical, "ERROR")
                        End If
                    End If
                Next
            End If


            '//Put report here
            '//Get data for report
            'Dim dtReport As DataTable = ds.OrderEntrySelect("SELECT * FROM twarehousereceive WHERE Pallett_ID = " & mPalletID)
            Dim dtReport As DataTable = ds.OrderEntrySelect("select twarehousepallet.whpallet_number, twarehousereceive.* from twarehousereceive inner join twarehousepallet on twarehousereceive.whpallet_id = twarehousepallet.whpallet_id where twarehousereceive.pallett_id = " & mPalletID)

            Dim lineNumber As Integer = 1

            objXL = New Excel.Application()
            oBook = objXL.workbooks.add
            oSheet = oBook.Worksheets(1)

            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "DISCREPANCEY REPORT"
            lineNumber += 1
            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "PALLET NUMBER: " & strPallet
            lineNumber += 1
            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "DATE: " & Now
            lineNumber += 2

            oSheet.Columns("A:A").Select()
            oSheet.Columns("A:A").ColumnWidth = 20
            oSheet.Columns("B:B").Select()
            oSheet.Columns("B:B").ColumnWidth = 20
            oSheet.Columns("C:C").Select()
            oSheet.Columns("C:C").ColumnWidth = 20
            oSheet.Columns("D:D").Select()
            oSheet.Columns("D:D").ColumnWidth = 25
            oSheet.Columns("E:E").Select()
            oSheet.Columns("E:E").ColumnWidth = 30
            oSheet.Columns("F:F").Select()
            oSheet.Columns("F:F").ColumnWidth = 25
            oSheet.Columns("G:G").Select()
            oSheet.Columns("G:G").ColumnWidth = 12
            oSheet.Columns("H:H").Select()
            oSheet.Columns("H:H").ColumnWidth = 12
            oSheet.Columns("I:I").Select()
            oSheet.Columns("I:I").ColumnWidth = 25
            oSheet.Columns("J:J").Select()
            oSheet.Columns("J:J").ColumnWidth = 20
            oSheet.Columns("K:K").Select()
            oSheet.Columns("K:K").ColumnWidth = 25

            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "ORIGINAL PALLET"
            oSheet.Range("B" & lineNumber).Select()
            oSheet.range("B" & lineNumber).FormulaR1C1 = "BOX SN"
            oSheet.Range("C" & lineNumber).Select()
            oSheet.range("C" & lineNumber).FormulaR1C1 = "DEVICE SN"
            oSheet.Range("D" & lineNumber).Select()
            oSheet.range("D" & lineNumber).FormulaR1C1 = "BOX SN ABSENT IN FILE"
            oSheet.Range("E" & lineNumber).Select()
            oSheet.range("E" & lineNumber).FormulaR1C1 = "DEVICE SN/ BOX SN DIFFERENT"
            oSheet.Range("F" & lineNumber).Select()
            oSheet.range("F" & lineNumber).FormulaR1C1 = "DEVICE SN ABSENT IN FILE"
            oSheet.Range("G" & lineNumber).Select()
            oSheet.range("G" & lineNumber).FormulaR1C1 = "BOX EMPTY"
            oSheet.Range("H" & lineNumber).Select()
            oSheet.range("H" & lineNumber).FormulaR1C1 = "WRONG SKU"
            oSheet.Range("I" & lineNumber).Select()
            oSheet.range("I" & lineNumber).FormulaR1C1 = "IN FILE - NOT ON PALLET"
            oSheet.Range("J" & lineNumber).Select()
            oSheet.range("J" & lineNumber).FormulaR1C1 = "DUPLICATE IN FILE"
            oSheet.Range("K" & lineNumber).Select()
            oSheet.range("K" & lineNumber).FormulaR1C1 = "MULTIPLE PHONES IN BOX"



            lineNumber += 1

            For x = 0 To dtReport.Rows.Count - 1
                r = dtReport.Rows(x)

                oSheet.Range("A" & lineNumber).Select()
                oSheet.range("A" & lineNumber).FormulaR1C1 = "'" & r("WHPallet_Number")
                oSheet.Range("B" & lineNumber).Select()
                oSheet.range("B" & lineNumber).FormulaR1C1 = "'" & r("WHR_Box_SN")
                oSheet.Range("C" & lineNumber).Select()
                oSheet.range("C" & lineNumber).FormulaR1C1 = "'" & r("WHR_Dev_SN")
                oSheet.Range("D" & lineNumber).Select()
                If r("WHR_BoxSN_Absent_in_File") = 1 Then oSheet.range("D" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("E" & lineNumber).Select()
                If r("WHR_DevSN_BoxSN_Different") = 1 Then oSheet.range("E" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("F" & lineNumber).Select()
                If r("WHR_DevSN_Absent_in_File") = 1 Then oSheet.range("F" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("G" & lineNumber).Select()
                If r("WHR_Box_Empty") = 1 Then oSheet.range("G" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("H" & lineNumber).Select()
                If r("WHR_WrongSKU") = 1 Then oSheet.range("H" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("I" & lineNumber).Select()
                If r("WHR_InFile_NotOnPallet") = 1 Then oSheet.range("I" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("J" & lineNumber).Select()
                If r("WHR_DupInFile") = 1 Then oSheet.range("J" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("K" & lineNumber).Select()
                If r("WHR_Mutltiple_Phones_In_Box") = 1 Then oSheet.range("K" & lineNumber).FormulaR1C1 = "X"

                lineNumber += 1

            Next

            oSheet.Range("A5:K" & lineNumber - 1).Select()

            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With



            oSheet.Columns("D:K").Select()
            With objXL.Selection
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With
            With objXL.ActiveSheet.PageSetup
                .LeftHeader = ""
                .CenterHeader = ""
                .RightHeader = ""
                .LeftFooter = ""
                .CenterFooter = ""
                .RightFooter = ""
                .PrintHeadings = False
                .PrintGridlines = False
                '.PrintQuality = 600
                .CenterHorizontally = False
                .CenterVertically = False
                '.BlackAndWhite = False
                .Zoom = False
                .FitToPagesWide = 1
                .FitToPagesTall = 1
                .Orientation = Excel.XlPageOrientation.xlLandscape
                .Draft = False
                '.PaperSize = Excel.XlPaperSize.xlPaperLetter

            End With

            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
            System.Windows.Forms.Application.DoEvents()

            oBook.saveas("P:\Dept\ATCLE\ASN Files\Current\" & strPallet & ".xls")

            oSheet = Nothing
            objXL = Nothing
            '//Put report here

            '//clear values for page
            getIMEI_LIST()
            dtDSC_IMEI = CreateMainGrid()
            txtDEVICE.Text = ""
            txtBOX.Text = ""
            txtBOX.Focus()
            lstDiscrepant.Items.Clear()
            Me.lblCount.Text = 0
            MsgBox(strPallet & " has been created.")

        End Sub

        Private Sub frmDscPalletBuild_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            getIMEI_LIST()
            '//Create datatable
            dtDSC_IMEI = CreateMainGrid()
        End Sub

        Private Sub txtBOX_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBOX.KeyDown
            If e.KeyCode = 13 Then
                checkIMEI()
            End If
        End Sub

        Private Sub txtDEVICE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDEVICE.KeyDown
            If e.KeyCode = 13 Then
                checkIMEI()
            End If
        End Sub




        Private Sub lstDiscrepant_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstDiscrepant.DoubleClick

            Dim vDevice As String = Me.lstDiscrepant.SelectedItem

            Dim x As Integer = 0
            Dim r As DataRow

            For x = 0 To dtDSC_IMEI.Rows.Count - 1
                r = dtDSC_IMEI.Rows(x)

                If r("DeviceSN") = vDevice Then

                    Dim strResponse As String = MsgBox("Remove IMEI number: " & r("DeviceSN") & " with a Box SN = " & r("BoxSN"), MsgBoxStyle.YesNo, "Verification")

                    Select Case strResponse
                        Case vbYes
                            lstDiscrepant.Items.RemoveAt(lstDiscrepant.SelectedIndex)
                            System.Windows.Forms.Application.DoEvents()
                            Me.lblCount.Text = lstDiscrepant.Items.Count
                            txtDEVICE.Text = ""
                            txtBOX.Text = ""
                            txtBOX.Focus()
                        Case vbNo
                            '//Do nothing
                    End Select
                End If
            Next

        End Sub

        Private Sub btnNoDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoDevice.Click

            Dim vBox As String
            vBox = Trim(Me.txtBOX.Text)

            Dim blnRecord As Boolean = False

            Dim x As Integer = 0
            Dim xC As Integer = 0
            Dim r As DataRow
            Dim rC As DataRow

            For x = 0 To dtIMEI.Rows.Count - 1
                r = dtIMEI.Rows(x)
                If IsDBNull(r("Box")) = False And IsDBNull(r("Device")) = True Then
                    If r("Box") = vBox Then
                        '//add data to dtdsc_imei
                        '//Validate not already in list
                        For xC = 0 To dtDSC_IMEI.Rows.Count - 1
                            rC = dtDSC_IMEI.Rows(xC)
                            If r("Box") = vBox And r("mID") = rC("WHR_ID") Then
                                MsgBox("This record is a duplicate for this pallet. IT CAN NOT BE ADDED.")
                                txtDEVICE.Text = ""
                                txtBOX.Text = ""
                                txtBOX.Focus()
                                Exit Sub
                            End If
                        Next
                        '//Validate not already in list

                        Dim dr1 As DataRow = dtDSC_IMEI.NewRow
                        dr1("BoxSN") = r("Box")
                        dr1("DeviceSN") = r("Box")
                        dr1("WHR_ID") = r("mID")
                        dtDSC_IMEI.Rows.Add(dr1)
                        blnRecord = True
                        lstDiscrepant.Items.Add(r("Box"))
                        System.Windows.Forms.Application.DoEvents()
                        Me.lblCount.Text = lstDiscrepant.Items.Count
                        txtDEVICE.Text = ""
                        txtBOX.Text = ""
                        txtBOX.Focus()
                        Exit For
                    End If
                Else
                    '//goto next record
                End If

            Next

            If blnRecord = False Then
                MsgBox("The device could not be reconciled - NOT ENTERD INTO PALLET.")
                txtDEVICE.Text = ""
                txtBOX.Text = ""
                txtBOX.Focus()
            End If



        End Sub


        Private Function createDiscrepantReport(ByVal mWHR_ID As Long) As Boolean

            If IsDBNull(mWHR_ID) Then Return False
            If Len(Trim(mWHR_ID)) < 1 Then Return False

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim objDataset1 As New DataSet()
            Dim objXL As Excel.Application
            Dim oBook As Excel.Workbook
            Dim oSheet As Excel.Worksheet


            '//Get the correct name for the pallet
            Dim ds As PSS.Data.Production.Joins
            Dim mDate As String = (Format(Now, "yyyyMMdd"))
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM tpallett WHERE Pallett_Name LIKE '" & mDate & "%' ORDER BY Pallett_Name")
            Dim r As DataRow

            If dt.Rows.Count < 1 Then
                strPallet = mDate & defaultCount                              '//Set Default
            Else
                Dim mInt As Integer = 0
                r = dt.Rows(dt.Rows.Count - 1)                          '//Get Last Record
                mInt = CInt(Mid$(r("Pallett_Name"), 10, 3))                  '//Separate out counter value
                mInt += 1                                               '//Increment counter by 1
                strPallet = mDate & "-" & mInt.ToString.PadLeft(3, "0") '//Concactenate the pallet name
            End If

            '//Insert value to table
            strSQL = "INSERT INTO tpallett (Pallett_Name, Pallett_ShipDate, Pallett_BulkShipped) VALUES ('" & strPallet & "', '" & Gui.Receiving.FormatDateShort(Now) & "', 9)"
            Dim tblWO As New PSS.Data.Production.tworkorder()
            Dim mPalletID As Long = tblWO.idTransaction(strSQL)


            Dim dsUpdate As PSS.Data.Production.Joins
            Dim blnUpdate As Boolean

            '//update record
            strSQL = "UPDATE twarehousereceive SET Pallett_ID = " & mPalletID & " WHERE WHR_ID = " & r("WHR_ID")
            System.Windows.Forms.Application.DoEvents()
            blnUpdate = dsUpdate.OrderEntryUpdateDelete(strSQL)

            '//Put report here
            '//Get data for report
            Dim dtReport As DataTable = ds.OrderEntrySelect("select twarehousepallet.whpallet_number, twarehousereceive.* from twarehousereceive inner join twarehousepallet on twarehousereceive.whpallet_id = twarehousepallet.whpallet_id where twarehousereceive.pallett_id = " & mPalletID)
            Dim lineNumber As Integer = 1

            objXL = New Excel.Application()
            oBook = objXL.workbooks.add
            oSheet = oBook.Worksheets(1)

            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "DISCREPANCEY REPORT"
            lineNumber += 1
            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "PALLET NUMBER: " & strPallet
            lineNumber += 1
            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "DATE: " & Now
            lineNumber += 2

            oSheet.Columns("A:A").Select()
            oSheet.Columns("A:A").ColumnWidth = 20
            oSheet.Columns("B:B").Select()
            oSheet.Columns("B:B").ColumnWidth = 20
            oSheet.Columns("C:C").Select()
            oSheet.Columns("C:C").ColumnWidth = 20
            oSheet.Columns("D:D").Select()
            oSheet.Columns("D:D").ColumnWidth = 25
            oSheet.Columns("E:E").Select()
            oSheet.Columns("E:E").ColumnWidth = 30
            oSheet.Columns("F:F").Select()
            oSheet.Columns("F:F").ColumnWidth = 25
            oSheet.Columns("G:G").Select()
            oSheet.Columns("G:G").ColumnWidth = 12
            oSheet.Columns("H:H").Select()
            oSheet.Columns("H:H").ColumnWidth = 12
            oSheet.Columns("I:I").Select()
            oSheet.Columns("I:I").ColumnWidth = 25
            oSheet.Columns("J:J").Select()
            oSheet.Columns("J:J").ColumnWidth = 20
            oSheet.Columns("K:K").Select()
            oSheet.Columns("K:K").ColumnWidth = 25

            oSheet.Range("A" & lineNumber).Select()
            oSheet.range("A" & lineNumber).FormulaR1C1 = "ORIGINAL PALLET"
            oSheet.Range("B" & lineNumber).Select()
            oSheet.range("B" & lineNumber).FormulaR1C1 = "BOX SN"
            oSheet.Range("C" & lineNumber).Select()
            oSheet.range("C" & lineNumber).FormulaR1C1 = "DEVICE SN"
            oSheet.Range("D" & lineNumber).Select()
            oSheet.range("D" & lineNumber).FormulaR1C1 = "BOX SN ABSENT IN FILE"
            oSheet.Range("E" & lineNumber).Select()
            oSheet.range("E" & lineNumber).FormulaR1C1 = "DEVICE SN/ BOX SN DIFFERENT"
            oSheet.Range("F" & lineNumber).Select()
            oSheet.range("F" & lineNumber).FormulaR1C1 = "DEVICE SN ABSENT IN FILE"
            oSheet.Range("G" & lineNumber).Select()
            oSheet.range("G" & lineNumber).FormulaR1C1 = "BOX EMPTY"
            oSheet.Range("H" & lineNumber).Select()
            oSheet.range("H" & lineNumber).FormulaR1C1 = "WRONG SKU"
            oSheet.Range("I" & lineNumber).Select()
            oSheet.range("I" & lineNumber).FormulaR1C1 = "IN FILE - NOT ON PALLET"
            oSheet.Range("J" & lineNumber).Select()
            oSheet.range("J" & lineNumber).FormulaR1C1 = "DUPLICATE IN FILE"
            oSheet.Range("K" & lineNumber).Select()
            oSheet.range("K" & lineNumber).FormulaR1C1 = "MULTIPLE PHONES IN BOX"

            Dim x As Integer
            lineNumber += 1

            For x = 0 To dtReport.Rows.Count - 1
                r = dtReport.Rows(x)

                oSheet.Range("A" & lineNumber).Select()
                oSheet.range("A" & lineNumber).FormulaR1C1 = "'" & r("WHPallet_Number")
                oSheet.Range("B" & lineNumber).Select()
                oSheet.range("B" & lineNumber).FormulaR1C1 = "'" & r("WHR_Box_SN")
                oSheet.Range("C" & lineNumber).Select()
                oSheet.range("C" & lineNumber).FormulaR1C1 = "'" & r("WHR_Dev_SN")
                oSheet.Range("D" & lineNumber).Select()
                If r("WHR_BoxSN_Absent_in_File") = 1 Then oSheet.range("D" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("E" & lineNumber).Select()
                If r("WHR_DevSN_BoxSN_Different") = 1 Then oSheet.range("E" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("F" & lineNumber).Select()
                If r("WHR_DevSN_Absent_in_File") = 1 Then oSheet.range("F" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("G" & lineNumber).Select()
                If r("WHR_Box_Empty") = 1 Then oSheet.range("G" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("H" & lineNumber).Select()
                If r("WHR_WrongSKU") = 1 Then oSheet.range("H" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("I" & lineNumber).Select()
                If r("WHR_InFile_NotOnPallet") = 1 Then oSheet.range("I" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("J" & lineNumber).Select()
                If r("WHR_DupInFile") = 1 Then oSheet.range("J" & lineNumber).FormulaR1C1 = "X"
                oSheet.Range("K" & lineNumber).Select()
                If r("WHR_Mutltiple_Phones_In_Box") = 1 Then oSheet.range("K" & lineNumber).FormulaR1C1 = "X"

                lineNumber += 1

            Next

            oSheet.Range("A5:K" & lineNumber - 1).Select()

            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalDown).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            objXL.Selection.Borders(Excel.XlBordersIndex.xlDiagonalUp).LineStyle = Excel.XlLineStyle.xlLineStyleNone
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeLeft)
                .LineStyle = Excel.XlLineStyle.xlContinuous 'xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeTop)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeBottom)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlEdgeRight)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideVertical)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With
            With objXL.Selection.Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                .LineStyle = Excel.XlLineStyle.xlContinuous
                .Weight = Excel.XlBorderWeight.xlThin
                .ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic
            End With

            oSheet.Columns("D:K").Select()
            With objXL.Selection
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = False
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With
            With objXL.ActiveSheet.PageSetup
                .LeftHeader = ""
                .CenterHeader = ""
                .RightHeader = ""
                .LeftFooter = ""
                .CenterFooter = ""
                .RightFooter = ""
                .PrintHeadings = False
                .PrintGridlines = False
                '.PrintQuality = 600
                .CenterHorizontally = False
                .CenterVertically = False
                '.BlackAndWhite = False
                .Zoom = False
                .FitToPagesWide = 1
                .FitToPagesTall = 1
                .Orientation = Excel.XlPageOrientation.xlLandscape
                .Draft = False
                '.PaperSize = Excel.XlPaperSize.xlPaperLetter

            End With

            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
            System.Windows.Forms.Application.DoEvents()
            oBook.saveas("P:\Dept\ATCLE\Palet Packing List\" & strPallet & ".xls")

            oSheet = Nothing
            objXL = Nothing

            Return True

        End Function


    End Class

End Namespace
