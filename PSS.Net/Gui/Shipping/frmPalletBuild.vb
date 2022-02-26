Imports PSS.Core
Imports PSS.Data
Imports System
Imports System.Data.OleDb
Imports Microsoft.Data.Odbc


Namespace Gui.Shipping

    Public Class frmPalletBuild
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
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cboPallets As System.Windows.Forms.ComboBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnCreatePallet As System.Windows.Forms.Button
        Friend WithEvents lstFO As System.Windows.Forms.ListBox
        Friend WithEvents txtFO As System.Windows.Forms.TextBox
        Friend WithEvents lblDeviceCount As System.Windows.Forms.Label
        Friend WithEvents lblFOLOTCount As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents btnDeletePallet As System.Windows.Forms.Button
        Friend WithEvents btnReport As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.cboPallets = New System.Windows.Forms.ComboBox()
            Me.lstFO = New System.Windows.Forms.ListBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.btnCreatePallet = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.btnDeletePallet = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblDeviceCount = New System.Windows.Forms.Label()
            Me.txtFO = New System.Windows.Forms.TextBox()
            Me.lblFOLOTCount = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.btnReport = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(16, 16)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(96, 16)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Available Pallets:"
            '
            'cboPallets
            '
            Me.cboPallets.Location = New System.Drawing.Point(112, 16)
            Me.cboPallets.Name = "cboPallets"
            Me.cboPallets.Size = New System.Drawing.Size(184, 21)
            Me.cboPallets.TabIndex = 0
            Me.cboPallets.TabStop = False
            '
            'lstFO
            '
            Me.lstFO.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lstFO.Location = New System.Drawing.Point(24, 120)
            Me.lstFO.Name = "lstFO"
            Me.lstFO.Size = New System.Drawing.Size(272, 264)
            Me.lstFO.TabIndex = 0
            Me.lstFO.TabStop = False
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(24, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(100, 16)
            Me.Label2.TabIndex = 3
            Me.Label2.Text = "Assigned FO/Lots"
            '
            'btnCreatePallet
            '
            Me.btnCreatePallet.Location = New System.Drawing.Point(304, 16)
            Me.btnCreatePallet.Name = "btnCreatePallet"
            Me.btnCreatePallet.Size = New System.Drawing.Size(104, 23)
            Me.btnCreatePallet.TabIndex = 0
            Me.btnCreatePallet.TabStop = False
            Me.btnCreatePallet.Text = "Create New Pallet"
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(528, 16)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(104, 23)
            Me.Button2.TabIndex = 0
            Me.Button2.TabStop = False
            Me.Button2.Text = "Close Pallet"
            '
            'Button3
            '
            Me.Button3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.Button3.Location = New System.Drawing.Point(512, 344)
            Me.Button3.Name = "Button3"
            Me.Button3.Size = New System.Drawing.Size(104, 23)
            Me.Button3.TabIndex = 0
            Me.Button3.TabStop = False
            Me.Button3.Text = "Re-Open Pallet"
            '
            'btnDeletePallet
            '
            Me.btnDeletePallet.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right)
            Me.btnDeletePallet.Location = New System.Drawing.Point(512, 376)
            Me.btnDeletePallet.Name = "btnDeletePallet"
            Me.btnDeletePallet.Size = New System.Drawing.Size(104, 23)
            Me.btnDeletePallet.TabIndex = 0
            Me.btnDeletePallet.TabStop = False
            Me.btnDeletePallet.Text = "Delete Pallet"
            '
            'Label3
            '
            Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.Label3.Location = New System.Drawing.Point(520, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 8
            Me.Label3.Text = "DEVICE COUNT"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'lblDeviceCount
            '
            Me.lblDeviceCount.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.lblDeviceCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDeviceCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceCount.Location = New System.Drawing.Point(520, 120)
            Me.lblDeviceCount.Name = "lblDeviceCount"
            Me.lblDeviceCount.Size = New System.Drawing.Size(96, 40)
            Me.lblDeviceCount.TabIndex = 9
            Me.lblDeviceCount.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'txtFO
            '
            Me.txtFO.Location = New System.Drawing.Point(24, 96)
            Me.txtFO.Name = "txtFO"
            Me.txtFO.Size = New System.Drawing.Size(272, 20)
            Me.txtFO.TabIndex = 1
            Me.txtFO.Text = ""
            '
            'lblFOLOTCount
            '
            Me.lblFOLOTCount.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.lblFOLOTCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblFOLOTCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFOLOTCount.Location = New System.Drawing.Point(520, 200)
            Me.lblFOLOTCount.Name = "lblFOLOTCount"
            Me.lblFOLOTCount.Size = New System.Drawing.Size(96, 40)
            Me.lblFOLOTCount.TabIndex = 12
            Me.lblFOLOTCount.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label6
            '
            Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
            Me.Label6.Location = New System.Drawing.Point(520, 176)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(96, 16)
            Me.Label6.TabIndex = 11
            Me.Label6.Text = "FO/LOT COUNT"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'btnReport
            '
            Me.btnReport.Location = New System.Drawing.Point(416, 16)
            Me.btnReport.Name = "btnReport"
            Me.btnReport.Size = New System.Drawing.Size(104, 23)
            Me.btnReport.TabIndex = 0
            Me.btnReport.TabStop = False
            Me.btnReport.Text = "Print Report"
            '
            'frmPalletBuild
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(640, 413)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReport, Me.lblFOLOTCount, Me.Label6, Me.txtFO, Me.lblDeviceCount, Me.Label3, Me.btnDeletePallet, Me.Button3, Me.Button2, Me.btnCreatePallet, Me.Label2, Me.lstFO, Me.cboPallets, Me.Label1})
            Me.Name = "frmPalletBuild"
            Me.Text = "frmPalletBuild"
            Me.ResumeLayout(False)

        End Sub

#End Region


        Private Const defaultCount As String = "-001"

        Private ds As PSS.Data.Production.Joins
        Private r As DataRow
        Private strPallet As String
        Private strSQL As String

        '//LEGEND Values for Status - tpalletdata.PD_Status
        '// 0 = Open
        '// 1 = Closed
        '// 9 = Deleted


        Private Sub frmPalletBuild_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            loadPalletNumbers()
        End Sub

        Private Sub btnCreatePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePallet.Click

            Dim mDate As String = (Format(Now, "yyyyMMdd"))
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM tpalletdata WHERE PD_Name LIKE '" & mDate & "%' ORDER BY PD_Name")

            If dt.Rows.Count < 1 Then
                strPallet = mDate & defaultCount                              '//Set Default
            Else
                Dim mInt As Integer = 0
                r = dt.Rows(dt.Rows.Count - 1)                          '//Get Last Record
                mInt = CInt(Mid$(r("PD_Name"), 10, 3))                  '//Separate out counter value
                mInt += 1                                               '//Increment counter by 1
                strPallet = mDate & "-" & mInt.ToString.PadLeft(3, "0") '//Concactenate the pallet name
            End If

            '//Insert value to table
            strSQL = "INSERT INTO tpalletdata (PD_Name, PD_Status) VALUES ('" & strPallet & "', 0)"
            Dim blnInsert As Boolean = ds.OrderEntryUpdateDelete(strSQL)

            loadPalletNumbers()                                         '//Reload the pallet names including new value

            cboPallets.Text = ""
            System.Windows.Forms.Application.DoEvents()
            cboPallets.Text = strPallet                                 '//Select the new value as the default

            getPageData()

        End Sub

        Private Sub loadPalletNumbers()

            '//Craig D. haney
            '//November 30, 2005
            '//This code is designed to acquire pallet numbers, 
            '//load the pallet numbers to the control combo box, 
            '//and supply the page data for the pallet selection displayed in the combo box

            '//Do not start until all other code has completed
            System.Windows.Forms.Application.DoEvents()
            '//This is to get the pallet number data and assign it to the combo box
            Dim dtPN As DataTable = getPalletNumbers()
            cboPallets.DataSource = dtPN
            cboPallets.DisplayMember = dtPN.Columns("PD_Name").ToString
            cboPallets.ValueMember = dtPN.Columns("PD_ID").ToString
            '//Do not start until all other code has completed
            System.Windows.Forms.Application.DoEvents()
            '//Load the page with the data for the selected pallet number
            getPageData()
            '//Complete this code before continuing
            System.Windows.Forms.Application.DoEvents()

        End Sub

        Private Function getPalletNumbers() As DataTable

            '//Craig D. haney
            '//November 30, 2005
            '//This code will return a datatable of all
            '//open pallet numbers
            Return ds.OrderEntrySelect("SELECT * FROM tpalletdata WHERE PD_Status = 0 ORDER BY PD_Name")

        End Function

        Private Sub getFOLOTdata(ByVal vPDID As Long)

            '//Verify that ID value exists
            If vPDID > 0 Then
                '//Assign counter value
                Dim xCount As Integer = 0
                '//acquire listing of FO/LOT numbers in FO/LOT order for selected pallet
                'Dim dtFO As DataTable = ds.OrderEntrySelect("SELECT * FROM tship WHERE ShipPallett = " & vPDID & " ORDER BY Ship_FO")
                '//November 27 2006
                Dim dtFO As DataTable = ds.OrderEntrySelect("SELECT * FROM tship WHERE ShipPallett = " & vPDID & " ORDER BY Ship_ID")

                '//Clear listbox for reloading
                lstFO.Items.Clear()
                '//Perform the load of FO/LOT numbers
                For xCount = 0 To dtFO.Rows.Count - 1
                    r = dtFO.Rows(xCount)
                    'lstFO.Items.Add(r("Ship_FO"))
                    '//November 27 2006
                    lstFO.Items.Add(r("Ship_ID"))
                Next
                '//close the datatable
                dtFO = Nothing
            Else
                MsgBox("Could not get data - can not determine pallet", MsgBoxStyle.OKOnly, "ERROR")
            End If

        End Sub

        Private Sub cboPallets_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPallets.SelectionChangeCommitted

            '//reload data for page based on newly selected pallet number
            getPageData()

        End Sub

        Private Sub getPageData()
            resetPage()
            getFOLOTdata(cboPallets.SelectedValue)
            System.Windows.Forms.Application.DoEvents()
            lblFOLOTCount.Text = lstFO.Items.Count
            getDeviceCount(cboPallets.SelectedValue)
            txtFO.Focus()
        End Sub

        Private Sub txtFO_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFO.KeyDown

            If e.KeyValue = 13 Then

                txtFO.Enabled = False

                '//run through lstbox and see if fo lot number already exists
                Try
                    Dim xCount As Integer = 0
                    For xCount = 0 To lstFO.Items.Count - 1
                        If Trim(lstFO.Items(xCount)) = Trim(txtFO.Text) Then
                            MsgBox("This item is already selected.", MsgBoxStyle.OKOnly, "DUPLICATE")
                            txtFO.Enabled = True
                            txtFO.Text = ""
                            txtFO.Focus()
                            Exit Sub
                        End If
                    Next
                Catch ex As Exception
                End Try

                '//If no duplicate then continue

                '//Check to see if fo lot is claimed by another pallet
                Try
                    'strSQL = "SELECT ShipPallett FROM tship where Ship_FO = '" & Trim(txtFO.Text) & "'"
                    '//November 27 2006
                    strSQL = "SELECT ShipPallett FROM tship where Ship_ID = " & Trim(txtFO.Text)
                    Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
                    r = dt.Rows(0)
                    If IsDBNull(r("ShipPallett")) = False Then
                        If Len(Trim(r("ShipPallett"))) > 0 Then
                            strSQL = "SELECT * FROM tpalletdata WHERE PD_ID = " & Trim(r("ShipPallett"))
                            dt = ds.OrderEntrySelect(strSQL)
                            r = dt.Rows(0)
                            MsgBox("This FO/LOT is being used by pallett " & Trim(r("PD_Name")) & ".", MsgBoxStyle.OKOnly, "IN USE")
                            txtFO.Enabled = True
                            txtFO.Text = ""
                            txtFO.Focus()
                            Exit Sub
                        End If
                    End If
                Catch ex As Exception
                End Try

                '//Assign to this pallet
                If cboPallets.SelectedValue > 0 Then
                    'strSQL = "UPDATE tship SET ShipPallett = " & cboPallets.SelectedValue & " WHERE Ship_FO = '" & Trim(txtFO.Text) & "'"
                    '//November 27 2006
                    strSQL = "UPDATE tship SET ShipPallett = " & cboPallets.SelectedValue & " WHERE Ship_ID = '" & Trim(txtFO.Text) & "'"
                    Dim blnUpdate As Boolean = ds.OrderEntryUpdateDelete(strSQL)

                    '//add item to lstPallet
                    Me.lstFO.Items.Add(Trim(txtFO.Text))

                    '//December 12, 2005 This is new
                    lstFO.SelectedIndex = lstFO.Items.Count - 1
                    '//December 12, 2005 This is new

                    System.Windows.Forms.Application.DoEvents()
                    txtFO.Text = ""
                    System.Windows.Forms.Application.DoEvents()
                    txtFO.Focus()

                    lblFOLOTCount.Text = lstFO.Items.Count
                    getDeviceCount(cboPallets.SelectedValue)

                Else
                    MsgBox("Could not assign to pallet.", MsgBoxStyle.OKOnly, "ERROR")
                    txtFO.Enabled = True
                    txtFO.Text = ""
                    txtFO.Focus()
                    Exit Sub
                End If
                txtFO.Enabled = True
                txtFO.Text = ""
                txtFO.Focus()
            End If

        End Sub

        Private Sub lstFO_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFO.DoubleClick

            If Len(Trim(lstFO.SelectedItem)) > 0 And cboPallets.SelectedValue > 0 Then
                strSQL = "UPDATE tship SET shippallett = NULL WHERE Ship_ID = " & Trim(lstFO.SelectedItem) & " AND ShipPallett = " & cboPallets.SelectedValue
                Dim blnRemove As Boolean = ds.OrderEntryUpdateDelete(strSQL)

                lstFO.Items.Clear()
                System.Windows.Forms.Application.DoEvents()
                getFOLOTdata(cboPallets.SelectedValue)
                System.Windows.Forms.Application.DoEvents()
                lblFOLOTCount.Text = lstFO.Items.Count
                getDeviceCount(cboPallets.SelectedValue)
            Else
                MsgBox("Could not remove FO/LOT.", MsgBoxStyle.OKOnly, "ERROR")
                txtFO.Text = ""
                txtFO.Focus()
                Exit Sub
            End If

        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

            If cboPallets.SelectedValue > 0 Then
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                Dim blnClose As Boolean
                strSQL = "UPDATE tpalletdata SET PD_Status = 1 WHERE PD_ID = " & cboPallets.SelectedValue
                blnClose = ds.OrderEntryUpdateDelete(strSQL)

                'makeReport(cboPallets.SelectedValue)

            End If

            resetPage()
            loadPalletNumbers()
            Cursor.Current = System.Windows.Forms.Cursors.Default

        End Sub


        Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim vPallet As String = InputBox("Enter Pallet Number to RE-OPEN:", "ENTER VALUE")

            If Len(Trim(vPallet)) < 1 Then Exit Sub
            strSQL = "SELECT * FROM tpalletdata WHERE PD_Name = '" & vPallet & "'"
            Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
            r = dt.Rows(0)

            If r("PD_Status") = 0 Then
                MsgBox("This pallet is already open.")
            Else
                strSQL = "UPDATE tpalletdata SET PD_Status = 0 WHERE PD_Name = '" & vPallet & "'"
                Dim blnReopen As Boolean = ds.OrderEntryUpdateDelete(strSQL)
                resetPage()
                loadPalletNumbers()
                System.Windows.Forms.Application.DoEvents()
            End If
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Sub


        Private Sub resetPage()

            txtFO.Text = ""
            lstFO.Items.Clear()

            lblDeviceCount.Text = "0"
            lblFOLOTCount.Text = "0"

        End Sub


        Private Sub btnDeletePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletePallet.Click
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            deletePallet(cboPallets.SelectedValue)
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Sub

        Private Sub deletePallet(ByVal vPDID As Long)

            '//Verify that ID value exists
            If vPDID > 0 Then
                '//Assign counter value
                Dim xCount As Integer = 0
                '//
                Dim dtFO As DataTable = ds.OrderEntrySelect("SELECT * FROM tship WHERE ShipPallett = " & vPDID)
                If dtFO.Rows.Count < 1 Then

                    '//delete record
                    If vPDID > 0 Then
                        strSQL = "UPDATE tpalletdata SET PD_Status = 9 WHERE PD_ID = " & vPDID
                        Dim blnDelete As Boolean = ds.OrderEntryUpdateDelete(strSQL)
                    End If

                    '//close the datatable
                    dtFO = Nothing

                    resetPage()
                    loadPalletNumbers()
                    System.Windows.Forms.Application.DoEvents()
                Else
                    MsgBox("This pallet contains FO/LOTs. Please remove FO/LOTs before deleting.")
                    Exit Sub
                End If
            Else
                MsgBox("Could not get data - can not determine pallet", MsgBoxStyle.OKOnly, "ERROR")
            End If

        End Sub


        Private Sub getDeviceCount(ByVal vPDID As Long)

            If vPDID > 0 Then
                Try
                    strSQL = "select count(tdevice.device_id) as devicecount from tpalletdata inner join tship on tpalletdata.pd_id = tship.shippallett inner join tdevice on tship.ship_id = tdevice.ship_id where tpalletdata.pd_id = " & vPDID & " group by tpalletdata.PD_ID"
                    Dim dt As DataTable = ds.OrderEntrySelect(strSQL)
                    r = dt.Rows(0)

                    lblDeviceCount.Text = r("devicecount")
                    dt = Nothing
                Catch ex As Exception
                    lblDeviceCount.Text = "0"
                End Try
            End If

        End Sub


        Private Sub makeReport(ByVal mPDID As Long)

            Dim objXL As Excel.Application
            Dim oSheet As Excel.Worksheet

            '//Create the XL doxument using the template
            objXL = New Excel.Application()
            objXL.workbooks.add()
            'objXL.Workbooks.Open("r:\PalletTemplate.xls")

            oSheet = objXL.Worksheets(1)

            oSheet.Columns("A").NumberFormat = "@"
            oSheet.Columns("B").NumberFormat = "@"
            oSheet.Columns("D").NumberFormat = "0"
            oSheet.Columns("E").NumberFormat = "0"

            '//This is to format the sheet - removing the need for a template file - BEGIN

            oSheet.Range("A1").Select()

            oSheet.range("A1").FormulaR1C1 = "PALLET NAME:"

            oSheet.Range("A2").Select()
            oSheet.range("A2").FormulaR1C1 = "PALLET NUMBER:"
            oSheet.Range("A4").Select()
            'oSheet.range("A4").FormulaR1C1 = "FO/LOT NUMBER"
            oSheet.range("A4").FormulaR1C1 = "SHIP NUMBER"
            oSheet.Range("B4").Select()
            'oSheet.range("B4").FormulaR1C1 = "FO/LOT(BARCODE)"
            oSheet.range("B4").FormulaR1C1 = "SHIP ID(BARCODE)"
            oSheet.Range("D4").Select()
            oSheet.range("D4").FormulaR1C1 = "COUNT"
            oSheet.Range("E4").Select()
            'oSheet.range("E4").FormulaR1C1 = "SHIP ID"
            oSheet.Columns("A:A").Select()
            oSheet.Columns("A:A").ColumnWidth = 21
            oSheet.Columns("B:B").Select()
            oSheet.Columns("B:B").columnwidth = 24
            oSheet.Columns("C:C").Select()
            oSheet.Columns("C:C").ColumnWidth = 6
            oSheet.Columns("D:D").Select()
            oSheet.Columns("D:D").ColumnWidth = 9
            oSheet.Columns("E:E").Select()
            oSheet.Columns("E:E").ColumnWidth = 9
            oSheet.Range("A4:E4").Select()
            'With oSheet.range("A4:E4").Interior
            '.ColorIndex = 6
            '.Pattern = objXL.xlSolid
            'End With
            '//*******************************************************************
            '//*******************************************************************

            objXL.Sheets("Sheet2").Select()
            oSheet = objXL.Worksheets(2)

            oSheet.range("A1").FormulaR1C1 = "WORKORDER INFORMATION"
            oSheet.Range("A2").Select()
            oSheet.range("A2").FormulaR1C1 = "PALLET NAME:"
            oSheet.Range("A3").Select()
            oSheet.range("A3").FormulaR1C1 = "PALLET NUMBER:"
            oSheet.Range("A4").Select()
            oSheet.range("A4").FormulaR1C1 = "WORKORDER NUMBER"
            oSheet.Range("B4").Select()
            oSheet.range("B4").FormulaR1C1 = "FINISHED SKU"
            oSheet.Range("C4").Select()
            oSheet.range("C4").FormulaR1C1 = "# DEVICES IN CURRENT PALLET"
            oSheet.Range("D4").Select()
            oSheet.range("D4").FormulaR1C1 = "TOTAL SHIPPED INCLUDING CURRENT"
            oSheet.Range("E4").Select()
            oSheet.range("E4").FormulaR1C1 = "TOTAL NUMBER DEVICES REMAINING"
            oSheet.Range("F4").Select()
            oSheet.range("F4").FormulaR1C1 = "NUMBER WORKORDER DEVICES TOTAL"
            oSheet.Range("G4").Select()
            oSheet.range("G4").FormulaR1C1 = "NUMBER DBR's"
            oSheet.Rows("4:4").Select()
            oSheet.rows("4:4").RowHeight = 36
            oSheet.Columns("A:A").Select()
            oSheet.Columns("A:A").ColumnWidth = 20
            oSheet.Columns("B:B").Select()
            oSheet.Columns("B:B").ColumnWidth = 15
            oSheet.Columns("C:C").Select()
            oSheet.Columns("C:C").ColumnWidth = 15
            oSheet.Columns("D:D").Select()
            oSheet.Columns("D:D").ColumnWidth = 15
            oSheet.Columns("E:E").Select()
            oSheet.Columns("E:E").ColumnWidth = 15
            oSheet.Columns("F:F").Select()
            oSheet.Columns("F:F").ColumnWidth = 15
            oSheet.Columns("G:G").Select()
            oSheet.Columns("G:G").ColumnWidth = 15
            oSheet.Range("A4:G4").Select()
            With oSheet.range("A4:G4")
                .HorizontalAlignment = Excel.Constants.xlGeneral
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = True
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With
            With oSheet.range("A4:G4")
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = True
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With
            oSheet.Rows("4:4").RowHeight = 43.5
            oSheet.Range("A4:G4").Select()
            'With oSheet.range("A4:F4").Interior
            '.ColorIndex = 6
            '.Pattern = objXL.xlSolid
            'End With
            '//__________________________________________________
            '//__________________________________________________
            '//__________________________________________________
            '//__________________________________________________

            '//*******************************************************************
            '//*******************************************************************


            '//*******************************************************************
            '//*******************************************************************

            objXL.Sheets("Sheet3").Select()
            oSheet = objXL.Worksheets(3)

            oSheet.range("A1").FormulaR1C1 = "WORKORDER INFORMATION"
            oSheet.Range("A2").Select()
            oSheet.range("A2").FormulaR1C1 = "VENDOR: PSSI, INC."
            oSheet.Range("A3").Select()
            oSheet.range("A3").FormulaR1C1 = "SHIP DATE: " & Now
            oSheet.Range("A4").Select()
            oSheet.range("A4").FormulaR1C1 = "WORKORDER"
            oSheet.Range("B4").Select()
            oSheet.range("B4").FormulaR1C1 = "FINISHED SKU"
            oSheet.Range("C4").Select()
            oSheet.range("C4").FormulaR1C1 = "ORIGINAL WO QTY"
            oSheet.Range("D4").Select()
            oSheet.range("D4").FormulaR1C1 = "QTY SHIPPED GOOD - CURRENT"
            oSheet.Range("E4").Select()
            oSheet.range("E4").FormulaR1C1 = "QTY SHIPPED - DBR/NER - CURRENT"
            oSheet.Range("F4").Select()
            oSheet.range("F4").FormulaR1C1 = "TOTAL SHIPPED TO DATE (GOOD + DBR)"
            oSheet.Rows("4:4").Select()
            oSheet.rows("4:4").RowHeight = 36
            oSheet.Columns("A:A").Select()
            oSheet.Columns("A:A").ColumnWidth = 15
            oSheet.Columns("B:B").Select()
            oSheet.Columns("B:B").ColumnWidth = 15
            oSheet.Columns("C:C").Select()
            oSheet.Columns("C:C").ColumnWidth = 10
            oSheet.Columns("D:D").Select()
            oSheet.Columns("D:D").ColumnWidth = 12
            oSheet.Columns("E:E").Select()
            oSheet.Columns("E:E").ColumnWidth = 12
            oSheet.Columns("F:F").Select()
            oSheet.Columns("F:F").ColumnWidth = 12
            oSheet.Range("A4:F4").Select()
            With oSheet.range("A4:F4")
                .HorizontalAlignment = Excel.Constants.xlGeneral
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = True
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With
            With oSheet.range("A4:F4")
                .HorizontalAlignment = Excel.Constants.xlCenter
                .VerticalAlignment = Excel.Constants.xlBottom
                .WrapText = True
                .Orientation = 0
                .AddIndent = False
                .ShrinkToFit = False
                .MergeCells = False
            End With
            oSheet.Rows("4:4").RowHeight = 50.0
            oSheet.Range("A4:F4").Select()
            'With oSheet.range("A4:F4").Interior
            '.ColorIndex = 6
            '.Pattern = objXL.xlSolid
            'End With
            '//__________________________________________________
            '//__________________________________________________
            '//__________________________________________________
            '//__________________________________________________

            '//*******************************************************************
            '//*******************************************************************



            objXL.Sheets("Sheet1").Select()
            oSheet = objXL.Worksheets(1)
            oSheet.Range("A1").Select()
            '//This is to format the sheet - removing the need for a template file - END

            Dim iRow As Integer = 5

            Dim dtData As New DataTable()

            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtBin As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            Dim odbcStr As String
            odbcStr = "SELECT tdevice.ship_id, COUNT(tdevice.device_id) as vCount, tship.Ship_FO " & _
            "FROM tpalletdata INNER JOIN tship ON tpalletdata.PD_ID = tship.ShipPallett " & _
            "INNER JOIN tdevice ON tship.Ship_ID = tdevice.Ship_ID " & _
            "WHERE tpalletdata.PD_ID = " & mPDID & " " & _
            "GROUP BY tdevice.ship_id " & _
            "ORDER BY tship.Ship_FO"

            dtData = PSS.Data.Production.Joins.OrderEntrySelect(odbcStr)

            Dim xCount As Integer = 0
            Dim r As DataRow

            oSheet.Range(CStr("B1")).Value = cboPallets.Text.ToString
            oSheet.Range(CStr("B2")).Value = cboPallets.SelectedValue

            For xCount = 0 To dtData.Rows.Count - 1
                r = dtData.Rows(xCount)
                'oSheet.Range(CStr("E" & iRow)).Value = r("Ship_ID").ToString
                oSheet.Range(CStr("D" & iRow)).Value = r("vCount").ToString
                oSheet.Range(CStr("A" & iRow)).Value = r("Ship_ID").ToString
                oSheet.Range(CStr("B" & iRow)).Value = "*" & r("Ship_ID").ToString & "*"

                oSheet.Range(CStr("B" & iRow)).Select()
                objXL.selection.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                With objXL.Selection.Font
                    .Name = "C39P12DhTt"
                    .Size = 10
                End With

                iRow += 1
            Next

            'oSheet.Range("A4:E" & iRow - 1).Select()
            oSheet.Range("A4:D" & iRow - 1).Select()


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



            iRow += 2

            Dim mTop, mBottom As Integer

            mTop = -1 * (iRow - 5)
            mBottom = -2
            oSheet.Range(CStr("B" & iRow)).Select()
            oSheet.Range(CStr("B" & iRow)).FormulaR1C1 = "TOTAL DEVICE COUNT"
            oSheet.Range(CStr("D" & iRow)).Select()
            oSheet.Range(CStr("D" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"

            iRow += 1

            mTop -= 1
            mBottom -= 1

            oSheet.Range(CStr("B" & iRow)).Select()
            'oSheet.Range(CStr("B" & iRow)).FormulaR1C1 = "TOTAL SHIP/FO-LOT COUNT"
            oSheet.Range(CStr("B" & iRow)).FormulaR1C1 = "TOTAL SHIP COUNT"
            oSheet.Range(CStr("D" & iRow)).Select()
            oSheet.Range(CStr("D" & iRow)).FormulaR1C1 = "=COUNT(R[" & mTop & "]C:R[" & mBottom & "]C)"

            '**************************************************************************
            oSheet.Range(CStr("A1:D" & iRow)).Select()
            objXL.ActiveSheet.PageSetup.PrintArea = CStr("$A$1:$E$" & iRow)
            With objXL.ActiveSheet.PageSetup
                .PrintTitleRows = "$1:$4"
                .PrintTitleColumns = ""
            End With
            objXL.ActiveSheet.PageSetup.PrintArea = CStr("$A$1:$D$" & iRow)
            With objXL.ActiveSheet.PageSetup
                .LeftHeader = ""
                .CenterHeader = ""
                .RightHeader = ""
                .LeftFooter = ""
                .CenterFooter = ""
                .RightFooter = ""
                .LeftMargin = objXL.Application.InchesToPoints(0.75)
                .RightMargin = objXL.Application.InchesToPoints(0.75)
                .TopMargin = objXL.Application.InchesToPoints(1)
                .BottomMargin = objXL.Application.InchesToPoints(1)
                .HeaderMargin = objXL.Application.InchesToPoints(0.5)
                .FooterMargin = objXL.Application.InchesToPoints(0.5)
                .PrintHeadings = False
                .PrintGridlines = False
                '.PrintQuality = 600
                .CenterHorizontally = False
                .CenterVertically = False
                .FitToPagesWide = 1
                .FitToPagesTall = 10
            End With

            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)
            System.Windows.Forms.Application.DoEvents()
            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)


            '//*******************************************************************
            '//*******************************************************************


            '//Move on to page 2 and second report
            objXL.Sheets("Sheet2").Select()
            oSheet = objXL.Worksheets(2)

            oSheet.Columns("A").NumberFormat = "@"
            oSheet.Columns("B").NumberFormat = "@"
            oSheet.Columns("C").NumberFormat = "0"
            oSheet.Columns("E").NumberFormat = "0"
            oSheet.Columns("F").NumberFormat = "0"

            '//This is new September 22, 2006
            oSheet.Columns("C:C").Select()
            With objXL.Selection.Font
                .Name = "Arial"
                .FontStyle = "Bold"
                .Size = 10
                .Strikethrough = False
                .Superscript = False
                .Subscript = False
                .OutlineFont = False
                .Shadow = False
            End With
            '//This is new September 22, 2006

            oSheet.Range(CStr("B2")).Value = cboPallets.Text.ToString
            oSheet.Range(CStr("B3")).Value = cboPallets.SelectedValue

            'odbcStr = "SELECT tworkorder.wo_custwo, tworkorder.wo_id, COUNT(tdevice.device_id) as vCount " & _
            '"FROM tpalletdata INNER JOIN tship ON tpalletdata.PD_ID = tship.ShipPallett " & _
            '"INNER JOIN tdevice ON tship.Ship_ID = tdevice.Ship_ID " & _
            '"INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & _
            '"WHERE tpalletdata.PD_ID = " & mPDID & " " & _
            '"GROUP BY tworkorder.wo_custwo "
            odbcStr = "SELECT tworkorder.wo_custwo, tworkorder.wo_id, COUNT(tdevice.device_id) as vCount, tusatest.usa_finishedgoodssku as vSKU " & _
            "FROM tpalletdata INNER JOIN tship ON tpalletdata.PD_ID = tship.ShipPallett " & _
            "INNER JOIN tdevice ON tship.Ship_ID = tdevice.Ship_ID " & _
            "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & _
            "INNER JOIN tusatest ON tworkorder.WO_Custwo = tusatest.usa_wo " & _
            "WHERE tpalletdata.PD_ID = " & mPDID & " " & _
            "GROUP BY tworkorder.wo_custwo "

            dtData = PSS.Data.Production.Joins.OrderEntrySelect(odbcStr)

            iRow = 5

            Dim ds As PSS.Data.Production.Joins
            Dim dtSub1Data As New DataTable()
            Dim dtSub2Data As New DataTable()
            Dim dtSub3Data As New DataTable()
            Dim dtSub4Data As New DataTable()
            Dim r0, r1, r2, r3, r4 As DataRow

            For xCount = 0 To dtData.Rows.Count - 1
                r = dtData.Rows(xCount)

                oSheet.Range(CStr("A" & iRow)).Value = r("WO_CustWO").ToString
                oSheet.Range(CStr("B" & iRow)).Value = r("vSKU").ToString
                '//Current
                oSheet.Range(CStr("C" & iRow)).Value = r("vCount").ToString

                '//Shipped
                odbcStr = "SELECT COUNT(Device_ID) as mCount1 FROM tdevice WHERE WO_ID = " & r("WO_ID") & " AND tdevice.device_dateship is not null"
                dtSub1Data = ds.OrderEntrySelect(odbcStr)
                r1 = dtSub1Data.Rows(0)
                oSheet.Range(CStr("D" & iRow)).Value = r1("mCount1").ToString

                '//Remaining
                odbcStr = "SELECT COUNT(Device_ID) as mCount2 FROM tdevice WHERE WO_ID = " & r("WO_ID") & " AND tdevice.device_dateship is null"
                dtSub2Data = ds.OrderEntrySelect(odbcStr)
                r2 = dtSub2Data.Rows(0)
                oSheet.Range(CStr("E" & iRow)).Value = r2("mCount2").ToString


                '//Total
                odbcStr = "SELECT COUNT(Device_ID) as mCount3 FROM tdevice WHERE WO_ID = " & r("WO_ID")
                dtSub3Data = ds.OrderEntrySelect(odbcStr)
                r3 = dtSub3Data.Rows(0)
                oSheet.Range(CStr("F" & iRow)).Value = r3("mCount3").ToString


                '//January 26, 2006 NEW
                '//DBR
                odbcStr = "SELECT COUNT(tdevice.Device_ID) as mCount4 FROM tdevice INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id WHERE WO_ID = " & r("WO_ID") & " And tdevicebill.billcode_ID = 25"
                dtSub4Data = ds.OrderEntrySelect(odbcStr)
                r4 = dtSub4Data.Rows(0)
                oSheet.Range(CStr("G" & iRow)).Value = r4("mCount4").ToString
                '//January 26, 2006 NEW



                iRow += 1

            Next

            oSheet.Range("A4:G" & iRow - 1).Select()

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


            iRow += 2

            mTop = -1 * (iRow - 5)
            mBottom = -2
            oSheet.Range(CStr("A" & iRow)).Select()
            oSheet.Range(CStr("A" & iRow)).FormulaR1C1 = "TOTALS"
            oSheet.Range(CStr("C" & iRow)).Select()
            oSheet.Range(CStr("C" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"
            'oSheet.Range(CStr("D" & iRow)).Select()
            'oSheet.Range(CStr("D" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"
            oSheet.Range(CStr("E" & iRow)).Select()
            oSheet.Range(CStr("E" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"
            oSheet.Range(CStr("F" & iRow)).Select()
            oSheet.Range(CStr("F" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"
            'oSheet.Range(CStr("G" & iRow)).Select()
            'oSheet.Range(CStr("G" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"


            '**************************************************************************
            oSheet.Range(CStr("A1:G" & iRow)).Select()
            objXL.ActiveSheet.PageSetup.PrintArea = CStr("$A$1:$G$" & iRow)
            With objXL.ActiveSheet.PageSetup
                .PrintTitleRows = "$1:$4"
                .PrintTitleColumns = ""
            End With
            objXL.ActiveSheet.PageSetup.PrintArea = CStr("$A$1:$G$" & iRow)
            With objXL.ActiveSheet.PageSetup
                .LeftHeader = ""
                .CenterHeader = ""
                .RightHeader = ""
                .LeftFooter = ""
                .CenterFooter = ""
                .RightFooter = ""
                .LeftMargin = objXL.Application.InchesToPoints(0.75)
                .RightMargin = objXL.Application.InchesToPoints(0.75)
                .TopMargin = objXL.Application.InchesToPoints(1)
                .BottomMargin = objXL.Application.InchesToPoints(1)
                .HeaderMargin = objXL.Application.InchesToPoints(0.5)
                .FooterMargin = objXL.Application.InchesToPoints(0.5)
                .PrintHeadings = False
                .PrintGridlines = False
                '.PrintQuality = 600
                .CenterHorizontally = False
                .CenterVertically = False
                .FitToPagesWide = 1
                .FitToPagesTall = 10
            End With

            oSheet.Columns("E:E").Select()
            objXL.Selection.EntireColumn.Hidden = True
            oSheet.Columns("F:F").Select()
            objXL.Selection.EntireColumn.Hidden = True
            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=2, Collate:=True)

            System.Windows.Forms.Application.DoEvents()

            '//*******************************************************************
            '//*******************************************************************



            oSheet.Columns("E:E").Select()
            objXL.Selection.EntireColumn.Hidden = False
            oSheet.Columns("F:F").Select()
            objXL.Selection.EntireColumn.Hidden = False


            objXL.activesheet.pagesetup.Orientation = Excel.XlPageOrientation.xlLandscape

            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)

            '//*******************************************************************
            '//*******************************************************************


            '//Move on to page 3 and second report
            objXL.Sheets("Sheet3").Select()
            oSheet = objXL.Worksheets(3)

            oSheet.Columns("A").NumberFormat = "@"
            oSheet.Columns("B").NumberFormat = "@"
            oSheet.Columns("C").NumberFormat = "0"
            oSheet.Columns("E").NumberFormat = "0"
            oSheet.Columns("F").NumberFormat = "0"


            'oSheet.Range(CStr("B2")).Value = cboPallets.Text.ToString
            'oSheet.Range(CStr("B3")).Value = cboPallets.SelectedValue

            odbcStr = "SELECT tworkorder.wo_custwo, tworkorder.wo_id, COUNT(tdevice.device_id) as vCount, tusatest.usa_finishedgoodssku as vSKU, tusatest.USA_Qty as qty " & _
            "FROM tpalletdata INNER JOIN tship ON tpalletdata.PD_ID = tship.ShipPallett " & _
            "INNER JOIN tdevice ON tship.Ship_ID = tdevice.Ship_ID " & _
            "INNER JOIN tworkorder ON tdevice.WO_ID = tworkorder.WO_ID " & _
            "INNER JOIN tusatest ON tworkorder.WO_Custwo = tusatest.usa_wo " & _
            "WHERE tpalletdata.PD_ID = " & mPDID & " " & _
            "GROUP BY tworkorder.wo_custwo "

            dtData = PSS.Data.Production.Joins.OrderEntrySelect(odbcStr)

            iRow = 5

            'Dim ds3 As PSS.Data.Production.Joins
            Dim dtSub1aData As New DataTable()
            Dim dtSub2aData As New DataTable()
            Dim dtSub3aData As New DataTable()
            Dim dtSub4aData As New DataTable()
            Dim ra0, ra1, ra2, ra3, ra4 As DataRow

            For xCount = 0 To dtData.Rows.Count - 1
                r = dtData.Rows(xCount)

                oSheet.Range(CStr("A" & iRow)).Value = r("WO_CustWO").ToString
                oSheet.Range(CStr("B" & iRow)).Value = r("vSKU").ToString
                '//Current
                oSheet.Range(CStr("C" & iRow)).Value = r("qty").ToString

                '//Shipped GOOD
                odbcStr = "SELECT COUNT(tdevice.Device_ID) as mCount1 FROM tdevice INNER JOIN tship ON tdevice.ship_ID = tship.ship_ID INNER JOIN tpalletdata ON tship.shippallett = tpalletdata.PD_ID WHERE WO_ID = " & r("WO_ID") & " AND tpalletdata.PD_ID = " & mPDID
                dtSub1Data = ds.OrderEntrySelect(odbcStr)
                r1 = dtSub1Data.Rows(0)
                oSheet.Range(CStr("D" & iRow)).Value = r1("mCount1").ToString

                '//Shipped DBR
                odbcStr = "SELECT COUNT(tdevice.Device_ID) as mCount4 FROM tdevice INNER JOIN tdevicebill ON tdevice.device_id = tdevicebill.device_id INNER JOIN tship ON tdevice.ship_ID = tship.ship_ID INNER JOIN tpalletdata ON tship.shippallett = tpalletdata.PD_ID WHERE WO_ID = " & r("WO_ID") & " And tdevicebill.billcode_ID = 25 AND tpalletdata.PD_ID = " & mPDID
                dtSub4Data = ds.OrderEntrySelect(odbcStr)
                r4 = dtSub4Data.Rows(0)
                oSheet.Range(CStr("E" & iRow)).Value = r4("mCount4").ToString

                '//Total
                odbcStr = "SELECT COUNT(tdevice.Device_ID) as mCount3 FROM tdevice WHERE WO_ID = " & r("WO_ID") & " AND Device_DateShip is not null"
                dtSub3Data = ds.OrderEntrySelect(odbcStr)
                r3 = dtSub3Data.Rows(0)
                oSheet.Range(CStr("F" & iRow)).Value = r3("mCount3").ToString

                ''//Remaining
                'odbcStr = "SELECT COUNT(Device_ID) as mCount2 FROM tdevice WHERE WO_ID = " & r("WO_ID") & " AND tdevice.device_dateship is null"
                'dtSub2Data = ds.OrderEntrySelect(odbcStr)
                'r2 = dtSub2Data.Rows(0)
                'oSheet.Range(CStr("E" & iRow)).Value = r2("mCount2").ToString

                iRow += 1

            Next

            oSheet.Range("A4:F" & iRow - 1).Select()

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


            iRow += 2

            mTop = -1 * (iRow - 5)
            mBottom = -2
            oSheet.Range(CStr("A" & iRow)).Select()
            oSheet.Range(CStr("A" & iRow)).FormulaR1C1 = "TOTALS"
            oSheet.Range(CStr("C" & iRow)).Select()
            oSheet.Range(CStr("C" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"
            oSheet.Range(CStr("D" & iRow)).Select()
            oSheet.Range(CStr("D" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"
            oSheet.Range(CStr("E" & iRow)).Select()
            oSheet.Range(CStr("E" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"
            oSheet.Range(CStr("F" & iRow)).Select()
            oSheet.Range(CStr("F" & iRow)).FormulaR1C1 = "=SUM(R[" & mTop & "]C:R[" & mBottom & "]C)"


            '**************************************************************************
            oSheet.Range(CStr("A1:F" & iRow)).Select()
            objXL.ActiveSheet.PageSetup.PrintArea = CStr("$A$1:$F$" & iRow)
            With objXL.ActiveSheet.PageSetup
                .PrintTitleRows = "$1:$4"
                .PrintTitleColumns = ""
            End With
            objXL.ActiveSheet.PageSetup.PrintArea = CStr("$A$1:$F$" & iRow)
            With objXL.ActiveSheet.PageSetup
                .LeftHeader = ""
                .CenterHeader = ""
                .RightHeader = ""
                .LeftFooter = ""
                .CenterFooter = ""
                .RightFooter = ""
                .LeftMargin = objXL.Application.InchesToPoints(0.75)
                .RightMargin = objXL.Application.InchesToPoints(0.75)
                .TopMargin = objXL.Application.InchesToPoints(1)
                .BottomMargin = objXL.Application.InchesToPoints(1)
                .HeaderMargin = objXL.Application.InchesToPoints(0.5)
                .FooterMargin = objXL.Application.InchesToPoints(0.5)
                .PrintHeadings = False
                .PrintGridlines = False
                '.PrintQuality = 600
                .CenterHorizontally = False
                .CenterVertically = False
                .FitToPagesWide = 1
                .FitToPagesTall = 10
            End With

            objXL.ActiveWindow.SelectedSheets.PrintOut(Copies:=1, Collate:=True)

            System.Windows.Forms.Application.DoEvents()

            '//*******************************************************************
            '//*******************************************************************




            dtSub4Data = Nothing
            dtSub3Data = Nothing
            dtSub2Data = Nothing
            dtSub1Data = Nothing


            objXL.visible = True
            objXL = Nothing

        End Sub


        Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
            If cboPallets.SelectedValue > 0 Then
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
                makeReport(cboPallets.SelectedValue)
                Cursor.Current = System.Windows.Forms.Cursors.Default
            Else
                MsgBox("Please selected a Pallet before running this operation.", MsgBoxStyle.OKOnly, "SELECT PALLET")
                cboPallets.Focus()
            End If
        End Sub

        Private Sub txtFO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFO.TextChanged

        End Sub

        Private Sub lstFO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstFO.SelectedIndexChanged

        End Sub

        Private Sub cboPallets_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPallets.SelectedIndexChanged

        End Sub
    End Class

End Namespace
