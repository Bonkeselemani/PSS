Imports eInfoDesigns.dbProvider.MySqlClient
Imports Microsoft.Data.Odbc

Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global
Imports System
Imports System.Data
Imports System.GC
Imports System.IO

Imports System.Data.OleDb
Imports System.Net
Imports System.Net.Dns

Namespace Gui.HideBillCodesCustomer


    Public Class frmHideBillCodesCustomer
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
        Friend WithEvents lblNarrative As System.Windows.Forms.Label
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboManuf As PSS.Gui.Controls.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblManuf As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents Button11 As System.Windows.Forms.Button
        Friend WithEvents chkBillCodesPrebill As System.Windows.Forms.CheckedListBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents chkBillCodes As System.Windows.Forms.CheckedListBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHideBillCodesCustomer))
            Me.lblNarrative = New System.Windows.Forms.Label()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.cboManuf = New PSS.Gui.Controls.ComboBox()
            Me.chkBillCodes = New System.Windows.Forms.CheckedListBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblManuf = New System.Windows.Forms.Label()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.Button11 = New System.Windows.Forms.Button()
            Me.chkBillCodesPrebill = New System.Windows.Forms.CheckedListBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'lblNarrative
            '
            Me.lblNarrative.BackColor = System.Drawing.Color.Transparent
            Me.lblNarrative.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblNarrative.ForeColor = System.Drawing.Color.Azure
            Me.lblNarrative.Location = New System.Drawing.Point(10, 109)
            Me.lblNarrative.Name = "lblNarrative"
            Me.lblNarrative.Size = New System.Drawing.Size(932, 59)
            Me.lblNarrative.TabIndex = 0
            Me.lblNarrative.Text = "PLEASE SELECTED BILLCODES THAT YOU DO NOT WANT TO DISPLAY ON THE TECHNICIAN SCREE" & _
            "N"
            Me.lblNarrative.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.Location = New System.Drawing.Point(154, 69)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(215, 24)
            Me.cboModel.TabIndex = 3
            '
            'cboManuf
            '
            Me.cboManuf.AutoComplete = True
            Me.cboManuf.Location = New System.Drawing.Point(154, 39)
            Me.cboManuf.Name = "cboManuf"
            Me.cboManuf.Size = New System.Drawing.Size(215, 24)
            Me.cboManuf.TabIndex = 2
            '
            'chkBillCodes
            '
            Me.chkBillCodes.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.chkBillCodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.chkBillCodes.Location = New System.Drawing.Point(31, 207)
            Me.chkBillCodes.Name = "chkBillCodes"
            Me.chkBillCodes.ScrollAlwaysVisible = True
            Me.chkBillCodes.Size = New System.Drawing.Size(430, 155)
            Me.chkBillCodes.TabIndex = 4
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(10, 79)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(133, 20)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "MODEL:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'lblManuf
            '
            Me.lblManuf.BackColor = System.Drawing.Color.Transparent
            Me.lblManuf.ForeColor = System.Drawing.Color.White
            Me.lblManuf.Location = New System.Drawing.Point(10, 46)
            Me.lblManuf.Name = "lblManuf"
            Me.lblManuf.Size = New System.Drawing.Size(133, 19)
            Me.lblManuf.TabIndex = 0
            Me.lblManuf.Text = "MANUFACTURER:"
            Me.lblManuf.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.Location = New System.Drawing.Point(154, 10)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(215, 24)
            Me.cboCustomer.TabIndex = 1
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
            Me.lblCustomer.ForeColor = System.Drawing.Color.White
            Me.lblCustomer.Location = New System.Drawing.Point(10, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(133, 20)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "CUSTOMER:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.TopRight
            '
            'Button11
            '
            Me.Button11.BackColor = System.Drawing.Color.PaleTurquoise
            Me.Button11.Location = New System.Drawing.Point(942, 405)
            Me.Button11.Name = "Button11"
            Me.Button11.Size = New System.Drawing.Size(10, 10)
            Me.Button11.TabIndex = 20
            Me.Button11.Text = "Invoice from Excel"
            Me.Button11.Visible = False
            '
            'chkBillCodesPrebill
            '
            Me.chkBillCodesPrebill.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left)
            Me.chkBillCodesPrebill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.chkBillCodesPrebill.Enabled = False
            Me.chkBillCodesPrebill.Location = New System.Drawing.Point(492, 207)
            Me.chkBillCodesPrebill.Name = "chkBillCodesPrebill"
            Me.chkBillCodesPrebill.ScrollAlwaysVisible = True
            Me.chkBillCodesPrebill.Size = New System.Drawing.Size(430, 155)
            Me.chkBillCodesPrebill.TabIndex = 21
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.LightCyan
            Me.Label2.Location = New System.Drawing.Point(31, 178)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(430, 19)
            Me.Label2.TabIndex = 22
            Me.Label2.Text = "TECHNICIAN"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.LightCyan
            Me.Label3.Enabled = False
            Me.Label3.Location = New System.Drawing.Point(492, 178)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(430, 19)
            Me.Label3.TabIndex = 23
            Me.Label3.Text = "PRE-BILLER"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(635, 20)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(96, 49)
            Me.Button1.TabIndex = 24
            Me.Button1.Text = "Button1"
            Me.Button1.Visible = False
            '
            'Button2
            '
            Me.Button2.Location = New System.Drawing.Point(799, 20)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(123, 28)
            Me.Button2.TabIndex = 25
            Me.Button2.Text = "Insert new Navision Parts"
            Me.Button2.Visible = False
            '
            'frmHideBillCodesCustomer
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
            Me.ClientSize = New System.Drawing.Size(962, 420)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button2, Me.Button1, Me.Label3, Me.Label2, Me.chkBillCodesPrebill, Me.Button11, Me.cboCustomer, Me.lblCustomer, Me.lblNarrative, Me.cboModel, Me.cboManuf, Me.chkBillCodes, Me.Label1, Me.lblManuf})
            Me.Name = "frmHideBillCodesCustomer"
            Me.Text = "frmHideBillCodesCustomer"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Public Enum PresentationEnum
            checkbox
            normal
        End Enum

        Private ds As PSS.Data.Production.Joins

        Private dtCustomer, dtCS, dtManuf, dtModel, dtBillCodes As DataTable
        Private strSQL As String

        Private Sub frmHideBillCodesCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            chkBillCodes.Visible = False
            chkBillCodesPrebill.Visible = False
            System.Windows.Forms.Application.DoEvents()
            cboManuf.Focus()
            loadCustomer()
            loadManuf()
            System.Windows.Forms.Application.DoEvents()
            chkBillCodes.Visible = True
            chkBillCodesPrebill.Visible = True
            cboCustomer.Focus()
        End Sub

#Region "Load Functions"

        Private Sub loadManuf()
            dtManuf = getManuf()
            cboManuf.DataSource = dtManuf
            cboManuf.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
            cboManuf.ValueMember = dtManuf.Columns("Manuf_ID").ToString
        End Sub
        Private Sub loadModel(ByVal mManuf As Long)
            dtModel = getModel(mManuf)
            cboModel.DataSource = dtModel
            cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
            cboModel.ValueMember = dtModel.Columns("Model_ID").ToString
        End Sub
        Private Sub loadCustomer()
            dtCustomer = getCustomer()
            cboCustomer.DataSource = dtCustomer
            cboCustomer.DisplayMember = dtCustomer.Columns("Cust_Name1").ToString
            cboCustomer.ValueMember = dtCustomer.Columns("Cust_ID").ToString
        End Sub

#End Region

#Region "Create Data Tables"

        Private Function getCustomer() As DataTable
            strSQL = "SELECT * FROM tcustomer WHERE Cust_Name2 is Null and Cust_Inactive = 0 ORDER BY Cust_Name1"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getManuf() As DataTable
            strSQL = "SELECT * FROM lmanuf ORDER BY Manuf_Desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getModel(ByVal vmanuf As Long) As DataTable
            strSQL = "SELECT * FROM tmodel WHERE manuf_ID = " & vmanuf & " ORDER BY Model_Desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getBillCodes(ByVal vmodel As Long) As DataTable
            strSQL = "SELECT tbilldisplayexceptions.display_type, lbillcodes.billcode_id, lbillcodes.billcode_desc, tpsmap.Laborlvl_ID, lpsprice.psprice_number, lpsprice.psprice_desc, tpsmap.inactive " & _
            "FROM tpsmap inner join lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id " & _
            "INNER JOIN lpsprice on tpsmap.psprice_id = lpsprice.psprice_id " & _
            "LEFT OUTER JOIN tbilldisplayexceptions ON (tpsmap.model_id = tbilldisplayexceptions.model_id " & _
            " AND tpsmap.billcode_id = tbilldisplayexceptions.billcode_id) " & _
            " AND tbilldisplayexceptions.cust_id = " & cboCustomer.SelectedValue & " " & _
            "WHERE tpsmap.model_id = " & vmodel & " " & _
            "AND (tbilldisplayexceptions.cust_id is null or tbilldisplayexceptions.cust_id = " & cboCustomer.SelectedValue & ") " & _
            "ORDER BY lbillcodes.billcode_desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getBillCodesOLD(ByVal vmodel As Long) As DataTable
            strSQL = "SELECT lbillcodes.billcode_id, lbillcodes.billcode_desc, tpsmap.inactive FROM tpsmap inner join lbillcodes on tpsmap.billcode_id = lbillcodes.billcode_id WHERE tpsmap.model_id = " & vmodel & " ORDER BY lbillcodes.billcode_desc"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getCustomers(ByVal vmodel As Long) As DataTable
            strSQL = "SELECT cust_id, cust_name1 FROM tcustomer WHERE cust_id in (2019,2113) ORDER BY tcustomer.cust_name1"
            Return ds.OrderEntrySelect(strSQL)
        End Function
        Private Function getCustomerSelections(ByVal vmodel As Long, ByVal vCustomer As Long) As DataTable
            strSQL = "SELECT * FROM tbilldisplayexceptions WHERE cust_id = " & vCustomer & " AND model_id = " & vmodel
            Return ds.OrderEntrySelect(strSQL)
        End Function
#End Region

#Region "On Change Events for Combo Boxes"

        Private Sub cboCustomer_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedValueChanged
            Try
                loadManuf()
                dtModel.Clear()
            Catch ex As Exception
            End Try
        End Sub
        Private Sub cboManuf_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManuf.SelectedValueChanged
            Try
                loadModel(cboManuf.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub
        Private Sub cboModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboModel.SelectedValueChanged
            Try
                loadBillCodes(cboModel.SelectedValue, cboCustomer.SelectedValue)
            Catch ex As Exception
            End Try
        End Sub

#End Region

#Region "Specific Bill Code Data"

        Private Sub formatText(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FormatTextEventArgs)
            Select Case e.Value
                Case "PreBill"
                    e.Value = "PB"
                Case "Tech"
                    e.Value = "TC"
                Case "None"
                    e.Value = "NO"
            End Select
        End Sub

        Private Sub loadBillCodes(ByVal mModel As Long, ByVal mCustomer As Long)

            '//This will load the billcodes for the selection manufacturer/model
            Try
                chkBillCodes.Items.Clear()
                chkBillCodesPrebill.Items.Clear()
            Catch ex As Exception
            End Try

            dtCS = getCustomerSelections(cboModel.SelectedValue, cboCustomer.SelectedValue)
            Dim rCS As DataRow
            Dim zCount As Integer

            If Len(cboModel.SelectedValue) < 1 Then Exit Sub

            Try
                dtBillCodes = getBillCodes(cboModel.SelectedValue)
                'MainGrid.DataSource = dtBillCodes
                'MainGrid.Columns(0).ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox


                Dim rBC As DataRow
                Dim xCount As Integer = 0
                Dim blnChecked As Boolean = False
                Dim blnCheckedPrebill As Boolean = False
                For xCount = 0 To dtBillCodes.Rows.Count - 1
                    rBC = dtBillCodes.Rows(xCount)
                    blnChecked = False
                    blnCheckedPrebill = False
                    For zCount = 0 To dtCS.Rows.Count - 1
                        rCS = dtCS.Rows(zCount)
                        If rCS("Billcode_ID") = rBC("BillCode_ID") Then
                            If rCS("tech") = 1 Then
                                blnChecked = True
                            End If
                            If rCS("prebill") = 1 Then
                                blnCheckedPrebill = True
                            End If
                        End If
                    Next
                    'If rBC("Inactive") = 1 Then blnChecked = True
                    chkBillCodes.Items.Add(rBC("BillCode_Desc"), blnChecked)
                    chkBillCodesPrebill.Items.Add(rBC("BillCode_Desc"), blnCheckedPrebill)
                Next
            Catch ex As Exception
            End Try
        End Sub
        Private Function getBillCodeID(ByVal mDesc As String) As Long
            Dim xCount As Integer = 0
            Dim r As DataRow
            For xCount = 0 To dtBillCodes.Rows.Count - 1
                r = dtBillCodes.Rows(xCount)
                If r("BillCode_Desc") = mDesc Then
                    Return r("BillCode_ID")
                End If
            Next
            Return 0
        End Function


#End Region

        Private Sub chkBillCodes_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkBillCodes.ItemCheck

            Dim CheckStatus As Integer
            Dim _ID As Long
            Dim ModelID As Long = cboModel.SelectedValue
            Dim mSQL As String
            Dim blnUpdate As Boolean
            Dim isRecordPresent As Boolean

            _ID = getBillCodeID(chkBillCodes.SelectedItem)

            Dim mTech As Integer = 0
            Dim mPrebill As Integer = 0

            If _ID > 0 And ModelID > 0 Then

                Dim dtrp As DataTable = ds.OrderEntrySelect("SELECT * FROM tbilldisplayexceptions WHERE cust_id = " & cboCustomer.SelectedValue & " AND model_id = " & cboModel.SelectedValue & " AND billcode_ID = " & _ID)
                If dtrp.Rows.Count > 0 Then isRecordPresent = True

                CheckStatus = chkBillCodes.GetItemCheckState(chkBillCodes.SelectedIndex)

                chkBillCodesPrebill.SelectedIndex = chkBillCodes.SelectedIndex
                If chkBillCodesPrebill.GetItemCheckState(chkBillCodesPrebill.SelectedIndex) = 0 Then
                    mPrebill = 0
                Else
                    mPrebill = 1
                End If

                If CheckStatus = 0 Then
                    '//Item is about to be checked
                    mSQL = "UPDATE tpsmap SET Inactive = 1 WHERE tpsmap.model_id = " & ModelID & " AND tpsmap.billcode_id = " & _ID
                    'blnUpdate = ds.OrderEntryUpdateDelete(mSQL)

                    If isRecordPresent = True Then


                        mSQL = "UPDATE tbilldisplayexceptions SET display_type = 1, tech = 1, prebill = " & mPrebill & " WHERE tbilldisplayexceptions.model_id = " & ModelID & " AND tbilldisplayexceptions.billcode_id = " & _ID & " AND tbilldisplayexceptions.cust_id = " & cboCustomer.SelectedValue
                        blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                    Else
                        mSQL = "INSERT INTO tbilldisplayexceptions (cust_id, model_id, billcode_id, display_type, tech, prebill) VALUES (" & cboCustomer.SelectedValue & ", " & cboModel.SelectedValue & ", " & _ID & ", 1,1, " & mPrebill & ")"
                        blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                    End If
                Else
                    '//Item is about to be unchecked
                    mSQL = "UPDATE tpsmap SET Inactive = 0 WHERE tpsmap.model_id = " & ModelID & " AND tpsmap.billcode_id = " & _ID
                    'blnUpdate = ds.OrderEntryUpdateDelete(mSQL)

                    If isRecordPresent = True Then
                        If mPrebill = 1 Then
                            mSQL = "UPDATE tbilldisplayexceptions SET display_type = 1, tech = 0, prebill = " & mPrebill & " WHERE tbilldisplayexceptions.model_id = " & ModelID & " AND tbilldisplayexceptions.billcode_id = " & _ID & " AND tbilldisplayexceptions.cust_id = " & cboCustomer.SelectedValue
                        Else
                            mSQL = "UPDATE tbilldisplayexceptions SET display_type = 0, tech = 0, prebill = " & mPrebill & " WHERE tbilldisplayexceptions.model_id = " & ModelID & " AND tbilldisplayexceptions.billcode_id = " & _ID & " AND tbilldisplayexceptions.cust_id = " & cboCustomer.SelectedValue
                        End If
                        blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                    Else
                        If mPrebill = 1 Then
                            mSQL = "INSERT INTO tbilldisplayexceptions (cust_id, model_id, billcode_id, display_type, tech, prebill) VALUES (" & cboCustomer.SelectedValue & ", " & cboModel.SelectedValue & ", " & _ID & ", 1,0 " & mPrebill & ")"
                        Else
                            mSQL = "INSERT INTO tbilldisplayexceptions (cust_id, model_id, billcode_id, display_type, tech, prebill) VALUES (" & cboCustomer.SelectedValue & ", " & cboModel.SelectedValue & ", " & _ID & ", 0,0 " & mPrebill & ")"
                        End If

                        blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                    End If
                End If
            End If
        End Sub

        Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click

            '//This method creates a text file from the invoice excel document
            '//Prepared by Crystal Cozart
            '//CONSTANTS *************************************************
            Dim strCustomer As String = "Brightpoint, Ltd."
            Dim strAddress1 As String = "601 S. Royal Lane"
            Dim strAddress2 As String = ""
            Dim strCity As String = "Coppell"
            Dim strState As String = "TX"
            Dim strZip As String = "75019"
            Dim strPhone As String = ""
            Dim strServiceCenter As String = "0001"
            Dim strRepairLevel As String = "R"
            Dim strComplaint As String = "NO COMPLAINT GIVEN"
            Dim strICRT As String = ""
            Dim strPartQty As String = "1"
            '//CONSTANTS *************************************************

            Dim ds As PSS.Data.Production.Joins
            Dim OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
            Dim vsWriter As StreamWriter
            Dim strData As String = ""
            Dim strHeader As String = ""
            Dim strPartNumber, mFileName, vService, mRepairStatus, mSerial, strSQL As String
            Dim dt1 As New DataTable()
            Dim dtDateRec, dt, dtService, dtCSIN, dtOld As DataTable
            Dim r, rDateRec, rService, rOld, rCSIN As DataRow
            Dim vParts, vLabor As Double
            Dim mHN As Integer = 0
            Dim xService As Integer = 0
            Dim x As Integer
            Dim strFile As String = "cell240383_" & mHN.ToString.PadLeft(4, "0") & "_PSSINEW.txt"
            Dim fs As New FileStream("D:\\cellstarINVOICE\Current\" & strFile, FileMode.Create, FileAccess.Write)
            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            '//Get the filename to load from
            OpenFileDialog1.ShowDialog()
            If Len(Trim(OpenFileDialog1.filename)) < 1 Then
                MsgBox("Data can not be loaded. No file has been selected.", MsgBoxStyle.OKOnly)
                Exit Sub
            End If

            Dim sConnectionstring As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & OpenFileDialog1.filename & ";Extended Properties=Excel 8.0;"
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()

            objConn.ConnectionString = sConnectionstring
            objConn.Open()
            objCmdSelect.CommandText = ("SELECT * FROM [Sheet1$]")
            objCmdSelect.Connection = objConn
            objAdapter1.SelectCommand = objCmdSelect
            Try
                objAdapter1.Fill(dt1)
            Catch ex As Exception
                MsgBox(ex.tostring)
            End Try


            strHeader = "EnterpriseCode" & vbTab & _
                        "Service Invoice" & vbTab & _
                        "ESN" & vbTab & _
                        "Model" & vbTab & _
                        "Customer" & vbTab & _
                        "Address One" & vbTab & _
                        "Address Two" & vbTab & _
                        "City" & vbTab & _
                        "State" & vbTab & _
                        "Zip" & vbTab & _
                        "Phone" & vbTab & _
                        "Service Center" & vbTab & _
                        "Date In" & vbTab & _
                        "Date Out" & vbTab & _
                        "Repair Level" & vbTab & _
                        "Complaint" & vbTab & _
                        "Labor Cost" & vbTab & _
                        "Parts Cost" & vbTab & _
                        "ICRT" & vbTab & _
                        "Service" & vbTab & _
                        "Part #" & vbTab & _
                        "Qty"

            s.WriteLine(strHeader)
            System.Windows.Forms.Application.DoEvents()

            For x = 0 To dt1.Rows.Count - 3
                r = dt1.Rows(x)
                Try
                    If IsDBNull(r("Serial No")) = True Then
                        s.Close()
                        MsgBox("File has been created")
                        Exit Sub
                    End If

                    dtOld = ds.OrderEntrySelect("SELECT tdevice.device_oldSN FROM tdevice inner join tworkorder on tdevice.wo_id = tworkorder.wo_id WHERE tworkorder.wo_custwo = '" & r("Workorder No") & "' AND tdevice.device_sn = '" & r("Serial No") & "'")
                    rOld = dtOld.Rows(0)

                    'trimble consequence
                    'If r("Workorder No") = "70307CS" Or r("Workorder No") = "41607CS" Or r("Workorder No") = "70419CS" Or r("Workorder No") = "70425CS" Then
                    'strSQL = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & r("Workorder No") & "' AND csin_ESN = '" & r("Serial No") & "'"
                    'mSerial = r("Serial No")
                    'End If

                    If Len(Trim(rOld("Device_OldSN"))) > 1 Then
                        'strSQL = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & r("Workorder No") & "' AND csin_ESN = '" & rOld("Device_OldSN") & "'"
                        'mSerial = rOld("Device_OldSN")
                        '//Modified May 2, 2007
                        strSQL = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & r("Workorder No") & "' AND csin_ESN = '" & rOld("Device_SN") & "'"
                        mSerial = rOld("Device_SN")
                        '//Modified May 2, 2007
                    ElseIf r("Serial No") > 0 Then
                        strSQL = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & r("Workorder No") & "' AND csin_ESN = '" & r("Serial No") & "'"
                        mSerial = r("Serial No")
                    End If
                Catch ex As Exception
                    strSQL = "SELECT * FROM cstincomingdata WHERE csin_RepairOrderNum = '" & r("Workorder No") & "' AND csin_ESN = '" & r("Serial No") & "'"
                    mSerial = r("Serial No")
                End Try

                dtCSIN = ds.OrderEntrySelect(strSQL)
                rCSIN = dtCSIN.Rows(0)

                strData += rCSIN("csin_EnterpriseCode").ToString & vbTab
                'strData += vbTab
                strData += r("Workorder No").ToString & vbTab
                strData += mSerial & vbTab
                strData += rCSIN("csin_Model").ToString & vbTab
                'strData += vbTab
                strData += strCustomer & vbTab
                strData += strAddress1 & vbTab
                strData += strAddress2 & vbTab
                strData += strCity & vbTab
                strData += strState & vbTab
                strData += strZip & vbTab
                strData += strPhone & vbTab
                strData += strServiceCenter & vbTab

                strSQL = "SELECT Device_DateRec FROM tdevice INNER JOIN tworkorder on tdevice.wo_id = tworkorder.wo_id WHERE tdevice.device_sn = '" & r("Serial No") & "' AND tworkorder.wo_custwo = '" & r("Workorder No") & "'"
                dtDateRec = ds.OrderEntrySelect(strSQL)
                rDateRec = dtDateRec.Rows(0)

                strData += Format(rDateRec("Device_DateRec"), "MMddyyyy") & vbTab
                strData += Format(r("Shipping Date"), "MMddyyyy") & vbTab

                mRepairStatus = r("Labor Level")

                strData += mRepairStatus & vbTab
                strData += strComplaint & vbTab

                vLabor = FormatNumber(r("Labor Charge"), 2)
                Dim sl As String = String.Format("{0:n2}", vLabor)
                strData += sl & vbTab

                vParts = FormatNumber(r("Parts Charge"), 2)
                Dim sp As String = String.Format("{0:n2}", vParts)
                strData += sp & vbTab

                strData += strICRT & vbTab
                Try
                    If r("Old Serial No") > 0 Then
                        strSQL = "select distinct lcodesdetail.dcode_Ldesc as mService from " & _
                        "cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                        "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
                        "inner join tbillmap on tdevice.model_id = tbillmap.model_id and tdevicebill.billcode_id = tbillmap.billcode_id and tbillmap.cust_id = 2113 " & _
                        "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                        "where cstincomingdata.csin_esn = '" & r("Old Serial No") & "' " & _
                        "and lcodesdetail.dcode_id = tbillmap.bmap_repairaction " & _
                        "and cstincomingdata.csin_RepairOrderNum = '" & r("Workorder No") & "' " & _
                        "order by laborlvl_id desc"
                    Else
                        strSQL = "select distinct lcodesdetail.dcode_Ldesc as mService from " & _
                        "cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                        "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                        "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
                        "inner join tbillmap on tdevice.model_id = tbillmap.model_id and tdevicebill.billcode_id = tbillmap.billcode_id and tbillmap.cust_id = 2113 " & _
                        "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                        "where cstincomingdata.csin_esn = '" & r("Serial No") & "' " & _
                        "and lcodesdetail.dcode_id = tbillmap.bmap_repairaction " & _
                        "and cstincomingdata.csin_RepairOrderNum = '" & r("Workorder No") & "' " & _
                        "order by laborlvl_id desc"
                    End If
                Catch ex As Exception
                    strSQL = "select distinct lcodesdetail.dcode_Ldesc as mService from " & _
                    "cstincomingdata inner join tdevice on cstincomingdata.csin_esn = tdevice.device_sn " & _
                    "inner join tdevicebill on tdevice.device_id = tdevicebill.device_id " & _
                    "inner join tpsmap on tdevice.model_id = tpsmap.model_id and tdevicebill.billcode_id = tpsmap.billcode_id " & _
                    "inner join tbillmap on tdevice.model_id = tbillmap.model_id and tdevicebill.billcode_id = tbillmap.billcode_id and tbillmap.cust_id = 2113 " & _
                    "inner join lcodesdetail on tbillmap.bmap_repairaction = lcodesdetail.dcode_id " & _
                    "where cstincomingdata.csin_esn = '" & r("Serial No") & "' " & _
                    "and lcodesdetail.dcode_id = tbillmap.bmap_repairaction " & _
                    "and cstincomingdata.csin_RepairOrderNum = '" & r("Workorder No") & "' " & _
                    "order by laborlvl_id desc"
                End Try

                dtService = ds.OrderEntrySelect(strSQL)
                System.Windows.Forms.Application.DoEvents()
                Try
                    vService = ""
                    For xService = 0 To dtService.Rows.Count - 1
                        rService = dtService.Rows(xService)
                        If xService = dtService.Rows.Count - 1 Then
                            vService += rService("mService")
                        Else
                            vService += rService("mService") & " ;  "
                        End If
                    Next

                    If mRepairStatus = 6 Then
                        vService = "WIPEDOWN"
                    End If
                    If mRepairStatus = 0 Then
                        vService = "BER"
                    End If
                    If mRepairStatus = 5 Then
                        vService = "NTF"
                    End If

                    If Len(Trim(vService)) > 199 Then
                        vService = Mid(vService, 1, 198)
                    End If


                Catch ex As Exception
                    MsgBox("vService has failed on device_id = " & r("csin_ESN"), MsgBoxStyle.Critical, "ERROR")
                End Try

                strData += vService & vbTab
                strData += rCSIN("csin_ItemNum").ToString & vbTab
                'strData += vbTab
                strData += strPartQty

                s.WriteLine(strData)
                System.Windows.Forms.Application.DoEvents()
                strData = ""
            Next

            s.Close()

            objConn = Nothing
            MsgBox("File has been created.")


        End Sub

        Private Sub chkBillCodes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBillCodes.SelectedIndexChanged
            'chkBillCodesPrebill.SelectedIndex = chkBillCodes.SelectedIndex
        End Sub

        Private Sub chkBillCodesPrebill_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles chkBillCodesPrebill.ItemCheck

            Dim CheckStatus As Integer
            Dim _ID As Long
            Dim ModelID As Long = cboModel.SelectedValue
            Dim mSQL As String
            Dim blnUpdate As Boolean
            Dim isRecordPresent As Boolean

            _ID = getBillCodeID(chkBillCodesPrebill.SelectedItem)
            Dim mTech As Integer = 0

            If _ID > 0 And ModelID > 0 Then

                Dim dtrp As DataTable = ds.OrderEntrySelect("SELECT * FROM tbilldisplayexceptions WHERE cust_id = " & cboCustomer.SelectedValue & " AND model_id = " & cboModel.SelectedValue & " AND billcode_ID = " & _ID)
                If dtrp.Rows.Count > 0 Then isRecordPresent = True

                CheckStatus = chkBillCodesPrebill.GetItemCheckState(chkBillCodesPrebill.SelectedIndex)

                chkBillCodes.SelectedIndex = chkBillCodesPrebill.SelectedIndex
                If chkBillCodes.GetItemCheckState(chkBillCodes.SelectedIndex) = 0 Then
                    mTech = 0
                Else
                    mTech = 1
                End If

                If CheckStatus = 0 Then
                    '//Item is about to be checked
                    mSQL = "UPDATE tpsmap SET Inactive = 1 WHERE tpsmap.model_id = " & ModelID & " AND tpsmap.billcode_id = " & _ID
                    'blnUpdate = ds.OrderEntryUpdateDelete(mSQL)

                    If isRecordPresent = True Then
                        mSQL = "UPDATE tbilldisplayexceptions SET display_type = 1, prebill = 1, tech = " & mTech & " WHERE tbilldisplayexceptions.model_id = " & ModelID & " AND tbilldisplayexceptions.billcode_id = " & _ID & " AND tbilldisplayexceptions.cust_id = " & cboCustomer.SelectedValue
                        blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                    Else
                        mSQL = "INSERT INTO tbilldisplayexceptions (cust_id, model_id, billcode_id, display_type, prebill, tech) VALUES (" & cboCustomer.SelectedValue & ", " & cboModel.SelectedValue & ", " & _ID & ", 1, 1," & mTech & ")"
                        blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                    End If
                Else
                    '//Item is about to be unchecked
                    mSQL = "UPDATE tpsmap SET Inactive = 0 WHERE tpsmap.model_id = " & ModelID & " AND tpsmap.billcode_id = " & _ID
                    'blnUpdate = ds.OrderEntryUpdateDelete(mSQL)

                    If isRecordPresent = True Then
                        If mTech = 1 Then
                            mSQL = "UPDATE tbilldisplayexceptions SET display_type = 1, prebill = 0, tech= " & mTech & " WHERE tbilldisplayexceptions.model_id = " & ModelID & " AND tbilldisplayexceptions.billcode_id = " & _ID & " AND tbilldisplayexceptions.cust_id = " & cboCustomer.SelectedValue
                        Else
                            mSQL = "UPDATE tbilldisplayexceptions SET display_type = 0, prebill = 0, tech= " & mTech & " WHERE tbilldisplayexceptions.model_id = " & ModelID & " AND tbilldisplayexceptions.billcode_id = " & _ID & " AND tbilldisplayexceptions.cust_id = " & cboCustomer.SelectedValue
                        End If
                        blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                    Else
                        If mTech = 1 Then
                            mSQL = "INSERT INTO tbilldisplayexceptions (cust_id, model_id, billcode_id, display_type, prebill, tech) VALUES (" & cboCustomer.SelectedValue & ", " & cboModel.SelectedValue & ", " & _ID & ", 1, 0," & mTech & ")"
                        Else
                            mSQL = "INSERT INTO tbilldisplayexceptions (cust_id, model_id, billcode_id, display_type, prebill, tech) VALUES (" & cboCustomer.SelectedValue & ", " & cboModel.SelectedValue & ", " & _ID & ", 0, 0," & mTech & ")"
                        End If
                        blnUpdate = ds.OrderEntryUpdateDelete(mSQL)
                    End If
                End If
            End If
        End Sub

        Private Sub chkBillCodesPrebill_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkBillCodesPrebill.SelectedIndexChanged
            'chkBillCodes.SelectedIndex = chkBillCodesPrebill.SelectedIndex
        End Sub


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim ds As PSS.Data.Production.Joins
            Dim dt1 As DataTable = ds.OrderEntrySelect("SELECT * FROM zVerizonTMP WHERE freq = '931.7375' order by capcode")
            Dim x, z As Integer
            'Dim dt2 As DataTable = ds.OrderEntrySelect("SELECT * FROM tverdata WHERE WO_Name in ('70308N9001','70309N9000','70309N9001') order by trans_id")
            Dim dt2 As DataTable = ds.OrderEntrySelect("SELECT * FROM tdevice WHERE tray_id in (1006073,1006074,1006075,1006076,1006077,1006078,1006079,1006080,1006083,1006084,1006085,1006086) order by tray_id, device_cnt")
            Dim r1, r2 As DataRow
            Dim blnUpdate As Boolean
            Dim oldTrans As Long = 0
            For x = 0 To dt2.Rows.Count - 1
                r2 = dt2.Rows(x)
                r1 = dt1.Rows(x)
                'update record
                'blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tverdata SET Device_capcode = '" & r1("capcode") & "', Device_Freq = '" & r1("Freq") & "' WHERE Trans_ID = " & r2("Trans_id"))
                blnUpdate = ds.OrderEntryUpdateDelete("UPDATE tdevicemetro SET Devicemetro_capcode = '" & r1("capcode") & "', Freq_id = '142' WHERE tdevicemetro.devicemetro_sn = '" & r2("Device_SN") & "'")


            Next
        End Sub

        Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
            '//Create datatable form Navision which holds data values for Part numbers and pricing
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objCmdSelect1 As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim dtNavision As New DataTable()
            Dim dsBin As New DataSet()
            Dim objDataset1 As New DataSet()
            Dim strFileBin As String
            Dim rBin As DataRow

            Dim blnDelete As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete("DELETE FROM tnavpriceinsert")
            If blnDelete = False Then
                MsgBox("The table tnavpriceinsert could not be cleared. The process can not continue.")
                Exit Sub
            End If

            '//NEW NAVISION DATATABLE FOR SOURCE DATA - START
            Dim odbcStr As String = "SELECT No_ as Part, ""Unit Cost"" as UnitCost, ""Unit Price"" as StandardCost, Description FROM Item where Description not like 'Tools-%' and Description not like 'Equip%' and Description not like 'Label-%' and Description not like 'Toner-%' and Description not like 'Crystals-%' and Description not like 'Holster-%' and Description not like 'Mktg-%'"

            Dim oODBConnection As New OdbcConnection("DSN=Navision Database")
            oODBConnection.Open()
            Dim ncmd As New OdbcCommand(odbcStr, oODBConnection)
            Dim nda As New OdbcDataAdapter()
            nda.SelectCommand = ncmd
            Dim ndt As New DataTable()
            Try
                nda.Fill(dtNavision)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            nda.Dispose()
            '//NEW NAVISION DATATABLE FOR SOURCE DATA - END

            '//NEW PSSI DATATABLE FOR SOURCE DATA - START
            Dim dtPSSI As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT PSPrice_Number, PSPrice_Desc, PSPrice_AvgCost, PSPrice_StndCost, PSPrice_InventoryPart FROM lpsprice where PSPrice_desc not like 'Tools-%' and PSPrice_desc not like 'Equip%' and PSPrice_desc not like 'Label-%' and PSPrice_desc not like 'Toner-%' and PSPrice_desc not like 'Crystals-%' and PSPrice_desc not like 'Holster-%'")

            '//NEW PSSI DATATABLE FOR SOURCE DATA - END

            Dim rPSSI As DataRow
            Dim rNavision As DataRow
            Dim strSQL As String

            Dim NavCount, PssiCount As Integer
            Dim blnExists As Boolean = False
            Dim blnInsert As Boolean
            Dim dsInsert As PSS.Data.Production.Joins
            '//Iterate through Navision
            For NavCount = 0 To dtNavision.Rows.Count - 1
                rNavision = dtNavision.Rows(NavCount)

                blnExists = False

                For PssiCount = 0 To dtPSSI.Rows.Count - 1
                    rPSSI = dtPSSI.Rows(PssiCount)
                    If Trim(UCase(rPSSI("PSPrice_Number"))) = Trim(UCase(rNavision("Part"))) Then
                        blnExists = True
                        Exit For
                    End If
                Next
                If blnExists = False Then
                    '//Insert data into tnavpriceinsert


                    Dim strDesc As String = rNavision("Description")
                    Dim strDescCh As String
                    Dim i As Integer

                    i = StrComp(strDesc, "'", vbTextCompare)
                    If i > 0 Then
                        strDescCh = Replace(strDesc, "'", "\'", 1, -1, vbTextCompare)
                        strDesc = strDescCh
                    End If



                    If Mid$(strDesc, 1, 4) <> "99Z_" Then

                        strSQL = "INSERT INTO tnavpriceinsert (PSSI_Date, PSSI_Number, PSSI_Desc, PSSI_AvgCost, PSSI_StndCost) VALUES ('" & Gui.Receiving.FormatDateShort(Now) & "', '" & rNavision("Part") & "', '" & strDesc & "', " & rNavision("UnitCost") & ", " & rNavision("StandardCost") & ")"
                        blnInsert = dsInsert.OrderEntryUpdateDelete(strSQL)
                        System.Windows.Forms.Application.DoEvents()
                        '//Insert data into lpsprice
                        strSQL = "INSERT INTO lpsprice (PSPrice_Number, PSPrice_Desc, PSPrice_AvgCost, PSPrice_StndCost, PSPrice_InventoryPart) VALUES ('" & rNavision("Part") & "', '" & strDesc & "', " & rNavision("UnitCost") & ", " & rNavision("StandardCost") & ", 1)"
                        blnInsert = dsInsert.OrderEntryUpdateDelete(strSQL)
                        System.Windows.Forms.Application.DoEvents()

                    End If


                End If
                blnExists = False
            Next

            MsgBox("DONE")
        End Sub


    End Class

End Namespace
