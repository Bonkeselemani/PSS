Imports System.IO
Imports eInfoDesigns.dbProvider.MySqlClient
Imports Microsoft.Data.Odbc

Imports System
Imports System.Data


Namespace Gui.Shipping

    Public Class frmShippingPallet
        Inherits System.Windows.Forms.Form

        Private dsJoins As PSS.Data.Production.Joins
        Private Shared _conn As MySqlConnection = Nothing
        Public xNum As Integer = 0
        Private vPalletName As String
        Private vType As String

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
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As System.Windows.Forms.ComboBox
        Friend WithEvents txtShipID As System.Windows.Forms.TextBox
        Friend WithEvents lblScan As System.Windows.Forms.Label
        Friend WithEvents lboxSelectedID As System.Windows.Forms.ListBox
        Friend WithEvents lblDeviceCountDesc As System.Windows.Forms.Label
        Friend WithEvents lblDeviceCount As System.Windows.Forms.Label
        Friend WithEvents btnCreatePallet As System.Windows.Forms.Button
        Friend WithEvents grpType As System.Windows.Forms.GroupBox
        Friend WithEvents rbAdd As System.Windows.Forms.RadioButton
        Friend WithEvents rbRPR As System.Windows.Forms.RadioButton
        Friend WithEvents btnReprintLabels As System.Windows.Forms.Button
        Friend WithEvents btnSmall As System.Windows.Forms.Button
        Friend WithEvents Button1 As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New System.Windows.Forms.ComboBox()
            Me.txtShipID = New System.Windows.Forms.TextBox()
            Me.lblScan = New System.Windows.Forms.Label()
            Me.lboxSelectedID = New System.Windows.Forms.ListBox()
            Me.lblDeviceCountDesc = New System.Windows.Forms.Label()
            Me.lblDeviceCount = New System.Windows.Forms.Label()
            Me.btnCreatePallet = New System.Windows.Forms.Button()
            Me.grpType = New System.Windows.Forms.GroupBox()
            Me.rbRPR = New System.Windows.Forms.RadioButton()
            Me.rbAdd = New System.Windows.Forms.RadioButton()
            Me.btnReprintLabels = New System.Windows.Forms.Button()
            Me.btnSmall = New System.Windows.Forms.Button()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.grpType.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblCustomer
            '
            Me.lblCustomer.Location = New System.Drawing.Point(16, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(56, 21)
            Me.lblCustomer.TabIndex = 0
            Me.lblCustomer.Text = "Customer:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.Location = New System.Drawing.Point(80, 16)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(288, 21)
            Me.cboCustomer.TabIndex = 1
            '
            'txtShipID
            '
            Me.txtShipID.BackColor = System.Drawing.Color.LightYellow
            Me.txtShipID.Location = New System.Drawing.Point(80, 112)
            Me.txtShipID.Name = "txtShipID"
            Me.txtShipID.Size = New System.Drawing.Size(136, 20)
            Me.txtShipID.TabIndex = 2
            Me.txtShipID.Text = ""
            '
            'lblScan
            '
            Me.lblScan.Location = New System.Drawing.Point(56, 80)
            Me.lblScan.Name = "lblScan"
            Me.lblScan.Size = New System.Drawing.Size(192, 32)
            Me.lblScan.TabIndex = 4
            Me.lblScan.Text = "Please scan shipping manifest numbers to be used to create pallet"
            Me.lblScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lboxSelectedID
            '
            Me.lboxSelectedID.BackColor = System.Drawing.Color.PaleTurquoise
            Me.lboxSelectedID.Location = New System.Drawing.Point(80, 144)
            Me.lboxSelectedID.Name = "lboxSelectedID"
            Me.lboxSelectedID.Size = New System.Drawing.Size(136, 238)
            Me.lboxSelectedID.TabIndex = 5
            '
            'lblDeviceCountDesc
            '
            Me.lblDeviceCountDesc.Location = New System.Drawing.Point(240, 264)
            Me.lblDeviceCountDesc.Name = "lblDeviceCountDesc"
            Me.lblDeviceCountDesc.Size = New System.Drawing.Size(192, 16)
            Me.lblDeviceCountDesc.TabIndex = 6
            Me.lblDeviceCountDesc.Text = "Number of devices selected for pallet"
            Me.lblDeviceCountDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDeviceCount
            '
            Me.lblDeviceCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblDeviceCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDeviceCount.Location = New System.Drawing.Point(248, 280)
            Me.lblDeviceCount.Name = "lblDeviceCount"
            Me.lblDeviceCount.Size = New System.Drawing.Size(176, 64)
            Me.lblDeviceCount.TabIndex = 7
            Me.lblDeviceCount.Text = "0"
            Me.lblDeviceCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnCreatePallet
            '
            Me.btnCreatePallet.Location = New System.Drawing.Point(248, 360)
            Me.btnCreatePallet.Name = "btnCreatePallet"
            Me.btnCreatePallet.Size = New System.Drawing.Size(176, 23)
            Me.btnCreatePallet.TabIndex = 8
            Me.btnCreatePallet.Text = "Create Pallet"
            '
            'grpType
            '
            Me.grpType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbRPR, Me.rbAdd})
            Me.grpType.Location = New System.Drawing.Point(256, 168)
            Me.grpType.Name = "grpType"
            Me.grpType.Size = New System.Drawing.Size(128, 80)
            Me.grpType.TabIndex = 9
            Me.grpType.TabStop = False
            Me.grpType.Text = "Type"
            '
            'rbRPR
            '
            Me.rbRPR.Location = New System.Drawing.Point(16, 48)
            Me.rbRPR.Name = "rbRPR"
            Me.rbRPR.TabIndex = 1
            Me.rbRPR.Text = "RPR"
            '
            'rbAdd
            '
            Me.rbAdd.Location = New System.Drawing.Point(16, 24)
            Me.rbAdd.Name = "rbAdd"
            Me.rbAdd.TabIndex = 0
            Me.rbAdd.Text = "ADD"
            '
            'btnReprintLabels
            '
            Me.btnReprintLabels.Location = New System.Drawing.Point(448, 8)
            Me.btnReprintLabels.Name = "btnReprintLabels"
            Me.btnReprintLabels.Size = New System.Drawing.Size(88, 48)
            Me.btnReprintLabels.TabIndex = 10
            Me.btnReprintLabels.Text = "Reprint Pallet Labels"
            '
            'btnSmall
            '
            Me.btnSmall.Location = New System.Drawing.Point(448, 64)
            Me.btnSmall.Name = "btnSmall"
            Me.btnSmall.Size = New System.Drawing.Size(88, 48)
            Me.btnSmall.TabIndex = 11
            Me.btnSmall.Text = "Reprint Pallet Labels SMALL"
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(448, 128)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(88, 48)
            Me.Button1.TabIndex = 12
            Me.Button1.Text = "Reprint Pallet data file"
            '
            'frmShippingPallet
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(544, 397)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.btnSmall, Me.btnReprintLabels, Me.grpType, Me.btnCreatePallet, Me.lblDeviceCount, Me.lblDeviceCountDesc, Me.lboxSelectedID, Me.lblScan, Me.txtShipID, Me.cboCustomer, Me.lblCustomer})
            Me.Name = "frmShippingPallet"
            Me.Text = "Pallet Creation - SHIPPING"
            Me.grpType.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmShippingPallet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            hideAllObjects()
            loadCustomer()  '//Assigns defined customers to form combobox.
            disableFormElements() ''//Disable elements for input until customer is selected
            lblDeviceCount.Text = 0
            showAllObjects()
        End Sub

        Private Function validateShipID(ByVal vCust As Integer, ByVal vShipID As Long) As Boolean
            Dim strSQL As String = "select distinct tdevice.ship_id from " & _
            "tdevice inner join tlocation on tdevice.loc_id = tlocation.loc_id " & _
            "inner join tship on tdevice.ship_id = tship.ship_id " & _
            "where(tdevice.ship_id = " & vShipID & ") and tlocation.cust_id = " & vCust & " " & _
            "and tship.shippallett is null"
            Dim dtValidate As DataTable = dsJoins.OrderEntrySelect(strSQL)
            If dtValidate.Rows.Count < 1 Then
                Return False
            Else
                Return True
            End If
        End Function

#Region "Customer Methods"

        Private Sub loadCustomer()
            Dim dsCustomer As PSS.Data.Production.tcustomer
            Dim dtCustomer As DataTable = dsCustomer.GetPalletCustomersOrdered
            Dim blnLoad As Boolean = loadCustomerCombo(dtCustomer)
            If blnLoad = False Then
                MsgBox("Error loading customer records.")
                Exit Sub
            End If
        End Sub

        Private Function loadCustomerCombo(ByVal dtCust As DataTable) As Boolean
            Try
                cboCustomer.Items.Clear()
                cboCustomer.DataSource = dtCust
                cboCustomer.DisplayMember = dtCust.Columns("Cust_Name1").ToString
                cboCustomer.ValueMember = dtCust.Columns("Cust_ID").ToString
            Catch ex As Exception
                Return False
            End Try
            Return True
        End Function

#End Region

#Region "Form Elements"

        Private Sub disableFormElements()
            '//Customer is not disabled because that is the source to make others enabled
            Me.txtShipID.Enabled = False
            Me.lboxSelectedID.Enabled = False
            Me.lblDeviceCountDesc.Enabled = False
            Me.lblDeviceCount.Enabled = False
            Me.btnCreatePallet.Enabled = False
            If cboCustomer.Items.Count = 1 Then enableFormElements()
            If cboCustomer.SelectedValue > 0 Then enableFormElements()
        End Sub

        Private Sub enableFormElements()
            '//Customer is not disabled because that is the source to make others disabled
            Me.txtShipID.Enabled = True
            Me.lboxSelectedID.Enabled = True
            Me.lblDeviceCountDesc.Enabled = True
            Me.lblDeviceCount.Enabled = True
            Me.btnCreatePallet.Enabled = True
        End Sub

#End Region


        Private Sub cboCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectedIndexChanged
            txtShipID.Focus()
            If Len(Trim(cboCustomer.Text)) < 1 Then cboCustomer.Focus()
        End Sub

        Private Sub txtShipID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipID.KeyDown
            If e.KeyValue = 13 Then     '//Enter/Return has been pressed
                If cboCustomer.SelectedValue > 0 Then
                    If Len(Trim(txtShipID.Text)) > 0 Then
                        '//Check to see if already in list
                        Dim xCount As Integer = 0
                        For xCount = 0 To lboxSelectedID.Items.Count - 1
                            If Trim(lboxSelectedID.Items(xCount)) = Trim(txtShipID.Text) Then
                                MsgBox("The ship id is already selected for this pallet.", MsgBoxStyle.Critical, "ERROR")
                                txtShipID.Text = ""
                                txtShipID.Focus()
                                Exit Sub
                            End If
                        Next
                        Dim blnCheck As Boolean = Me.validateShipID(cboCustomer.SelectedValue, Trim(txtShipID.Text))
                        If blnCheck = True Then
                            addShipID(Trim(txtShipID.Text)) '//Ship ID is valid
                        Else
                            clearShipID() '//Ship ID is invalid
                        End If
                    Else
                        clearShipID() '//Ship id is not acceptable
                    End If
                Else
                    clearShipID() '//Customer id is not acceptable
                End If
            End If
        End Sub

        Private Sub clearShipID()
            MsgBox("This ship ID is INVALID! Removing from page.", MsgBoxStyle.Exclamation, "ERROR")
            txtShipID.Text = ""
            txtShipID.Focus()
        End Sub

        Private Sub addShipID(ByVal vShipID As Long)
            lboxSelectedID.Items.Add(vShipID)   '//Adds record to listbox
            '//Alter Counter
            addCount(vShipID)
            System.Windows.Forms.Application.DoEvents()
            txtShipID.Text = ""
            txtShipID.Focus()
        End Sub

        Private Sub deleteShipID()
            Dim mShipID As Long = lboxSelectedID.SelectedItem
            lboxSelectedID.Items.RemoveAt(lboxSelectedID.SelectedIndex)
            delCount(mShipID)
            txtShipID.Text = ""
            txtShipID.Focus()
        End Sub

        Private Sub addCount(ByVal vShipID As Long)
            Dim addCount As Long
            Dim dtCount As DataTable = dsJoins.OrderEntrySelect("Select Count(Device_ID) as valCount FROM tdevice WHERE ship_id = " & vShipID)
            Dim r As DataRow = dtCount.Rows(0)
            addCount = CInt(lblDeviceCount.Text) + r("valCount")
            lblDeviceCount.Text = addCount
        End Sub

        Private Sub delCount(ByVal vShipID As Long)
            Dim delCount As Long
            Dim dtCount As DataTable = dsJoins.OrderEntrySelect("Select Count(Device_ID) as valCount FROM tdevice WHERE ship_id = " & vShipID)
            Dim r As DataRow = dtCount.Rows(0)
            delCount = CInt(lblDeviceCount.Text) - r("valCount")
            lblDeviceCount.Text = delCount
        End Sub

        Private Sub lboxSelectedID_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lboxSelectedID.DoubleClick
            Try
                deleteShipID()
            Catch ex As Exception
            End Try
        End Sub

        Private Sub hideAllObjects()
            lblCustomer.Visible = False
            cboCustomer.Visible = False
            lblScan.Visible = False
            txtShipID.Visible = False
            lboxSelectedID.Visible = False
            lblDeviceCountDesc.Visible = False
            lblDeviceCount.Visible = False
            btnCreatePallet.Visible = False
            rbAdd.Visible = False
            rbRPR.Visible = False
            grpType.Visible = False
        End Sub

        Private Sub showAllObjects()
            lblCustomer.Visible = True
            cboCustomer.Visible = True
            lblScan.Visible = True
            txtShipID.Visible = True
            lboxSelectedID.Visible = True
            lblDeviceCountDesc.Visible = True
            lblDeviceCount.Visible = True
            btnCreatePallet.Visible = True
            rbAdd.Visible = True
            rbRPR.Visible = True
            grpType.Visible = True
        End Sub


        Private Function obtainPalletID() As Int32

            Dim vNow As String = Gui.Receiving.FormatDateShort(Now)
            Dim dsPallet As PSS.Data.Production.ttray
            Dim vPalletID As Int32
            vPalletID = dsPallet.idTransaction("INSERT INTO tpallett(Pallett_ShipDate, WO_ID, Loc_ID) VALUES ('" & vNow & "',0,0)")
            If vPalletID < 1 Then
                Return 0
            End If
            Return vPalletID
        End Function


        Private Sub btnCreatePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreatePallet.Click

            If rbAdd.Checked = True Then vType = "ADD"
            If rbRPR.Checked = True Then vType = "RPR"

            If rbAdd.Checked = False And rbRPR.Checked = False Then
                MsgBox("No Type Selected.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If

            '//Get new Pallett_ID from tpallett
            Dim mPalletID As Int32
            Dim vNow As String = Gui.Receiving.FormatDateShort(Now)
            Dim dsPallet As New PSS.Data.Production.ttray()
            'Dim vPalletID As Int32
            mPalletID = dsPallet.idTransaction("INSERT INTO tpallett(Pallett_ShipDate, WO_ID, Loc_ID) VALUES ('" & vNow & "',0,0)")

            If mPalletID = 0 Then
                MsgBox("The pallet id could not be assigned.", MsgBoxStyle.Critical, "EXITING")
                Exit Sub
            End If

            '//Get Latest PalletName
            Dim dsPalletName As PSS.Data.Production.Joins
            Dim dtPalletName As DataTable = dsPalletName.OrderEntrySelect("SELECT * FROM tpalletname WHERE Pallet_Name like '" & Trim(Format(Now, "yyyyMMdd")) & "%' ORDER BY trans_ID")
            Dim rPalletName As DataRow
            Dim PNcount As Integer
            xNum = 0
            For PNcount = 0 To dtPalletName.Rows.Count - 1
                rPalletName = dtPalletName.Rows(PNcount)
                Dim pnlen As Integer = Len(Trim(rPalletName("Pallet_Name")))
                pnlen -= 2
                xNum = CInt(Mid$(Trim(rPalletName("Pallet_Name")), pnlen, 3))
            Next

            xNum += 1
            vPalletName = Trim(Format(Now, "yyyyMMdd")) & "-" & CStr(xNum).PadLeft(3, "0")

            '//This is new to place the filename into tpalletname instead of what USA Mobility requested.
            Dim strFileName As String
            strFileName = createOutputFileName("EQ_RPR", "PSSI", xNum)
            'Dim blnInserName As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete("INSERT INTO tpalletname(pallet_id, pallet_name) VALUES (" & mPalletID & ", '" & vPalletName & "')")
            Dim blnInserName As Boolean = PSS.Data.Production.Joins.OrderEntryUpdateDelete("INSERT INTO tpalletname(pallet_id, pallet_name) VALUES (" & mPalletID & ", '" & strFileName & "')")
            '//This is new to place the filename into tpalletname instead of what USA Mobility requested.

            '//Update records in tship
            '//Make string of ship ID's to update
            Dim xcount As Integer = 0
            Dim strShipID As String
            For xcount = 0 To lboxSelectedID.Items.Count - 1
                If xcount = 0 Then
                    strShipID += lboxSelectedID.Items(xcount)
                Else
                    strShipID += "," & lboxSelectedID.Items(xcount)
                End If
            Next

            '//Verify list has at least 1 entry
            If Len(Trim(strShipID)) < 1 Then
                MsgBox("There are no ship ID's to include in this shipping pallet.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
            '//Perform Update
            Dim blnUpdate As Boolean = dsJoins.OrderEntryUpdateDelete("UPDATE tship SET ShipPallett = " & mPalletID & " WHERE Ship_ID IN (" & strShipID & ")")
            If blnUpdate = False Then
                MsgBox("Error in updating data to tship. Please contact IT.", MsgBoxStyle.Critical, "ERROR")
                Exit Sub
            End If
            '//Create data file

            createDataFile(mPalletID, strShipID, xNum, vPalletName, vType)
            '//Create labels
            '//Clear and reset form
            lboxSelectedID.Items.Clear()
            txtShipID.Text = ""
            txtShipID.Focus()
            lblDeviceCount.Text = 0
            rbAdd.Checked = False
            rbRPR.Checked = False

            '//Print the labels
            Dim rptApp As New CRAXDRT.Application()
            Dim rpt As New CRAXDRT.Report()
            Try
                'rpt = rptApp.OpenReport("\\svr_pssiusr\reports\PSSInet_Reports_Prod\Ship_PalletLabel.rpt")
                rpt = rptApp.OpenReport("\\svr_pssiusr\reports\PSSInet_Reports_Prod\Ship_PalletLabel_OLD.rpt")
                rpt.RecordSelectionFormula = "{tpalletname.Pallet_Name} = '" & vPalletName & "'"
                rpt.PrintOut(False, 1)
            Catch ex As Exception
            Finally
                rpt = Nothing
                rptApp = Nothing
            End Try
            Cursor.Current = System.Windows.Forms.Cursors.Default
            '//Print the labels

        End Sub

        Private Function getConnection(Optional ByVal database As String = "production") As MySqlConnection

            Dim strConn As String = "SERVER=172.16.25.21" & _
                                    ";DATABASE=production" & _
                                    ";USER ID=appuser" & _
                                    ";PASSWORD=appuser" & _
                                    ";POOLING=TRUE;"

            Dim c As New MySqlConnection()
            Return New MySqlConnection(strConn)

        End Function

        Public Function getData(ByVal palletID As Long, ByVal strShipID As String) As DataTable

            _conn = getConnection()
            'Dim strSQL As String = "select tdevice.device_sn, tdevicemetro.* from " & _
            '                        "tdevice left outer join tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn " & _
            '                        "inner join tship on tdevice.ship_id = tship.ship_id " & _
            '                        "where tship.ship_id in (" & strShipID & ") and tdevicemetro.devicemetro_capcode is not null order by tdevice.device_sn"
            'Dim strSQL As String = "select tdevice.device_sn, tdevicemetro.* from " & _
            '                        "tdevice left outer join tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn " & _
            '                        "inner join tship on tdevice.ship_id = tship.ship_id " & _
            '                        "inner join tpalletname on tship.shippallett = tpalletname.pallet_id " & _
            '                        "where tpalletname.pallet_id = " & palletID & " and tdevicemetro.devicemetro_capcode is not null order by tdevice.device_sn"
            'Dim strSQL As String = "select tdevice.device_sn, tdevicemetro.* from " & _
            '                        "tdevice left outer join tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn " & _
            '                        "inner join tship on tdevice.ship_id = tship.ship_id " & _
            '                        "where tship.shippallett = " & palletID & " order by tdevice.device_sn"
            Dim strSQL As String = "select tdevice.device_sn, tdevicemetro.* from " & _
                                    "tdevice left outer join tdevicemetro on tdevice.device_sn = tdevicemetro.devicemetro_sn " & _
                                    "inner join tship on tdevice.ship_id = tship.ship_id " & _
                                    "where tship.shippallett = " & palletID & " order by tdevicemetro.devicemetro_sku, tdevice.device_sn"

            Dim _cmd As New MySqlCommand(strSQL, _conn)
            Dim _da As New MySqlDataAdapter()
            _da.SelectCommand = _cmd
            Dim _dt As New DataTable()
            _da.Fill(_dt)
            _da.Dispose()
            _conn.Close()
            _conn.Dispose()
            _conn = Nothing
            Return _dt

        End Function



        Public Shared Function createShipDate() As String
            Return Format(Now, "yyyyMMdd") '//Set static variable = mShipDate
        End Function

        Public Shared Function createOutputFileName(ByVal vOutputPrefix, ByVal vVendor, ByVal xNum) As String
            Dim strNum As String
            If xNum = 1 Then
                Return Trim(Trim(vOutputPrefix) & Trim(vVendor) & "_" & Trim(Format(Now, "yyMMdd")) & ".csv")   '//Create name for output file
            Else
                strNum = ""
                If xNum = 2 Then strNum = "a"
                If xNum = 3 Then strNum = "b"
                If xNum = 4 Then strNum = "c"
                If xNum = 5 Then strNum = "d"
                If xNum = 6 Then strNum = "e"
                If xNum = 7 Then strNum = "f"
                If xNum = 8 Then strNum = "g"
                If xNum = 9 Then strNum = "h"
                If xNum = 10 Then strNum = "i"
                If xNum = 11 Then strNum = "j"
                If xNum = 12 Then strNum = "k"
                If xNum = 13 Then strNum = "l"
                If xNum = 14 Then strNum = "m"
                If xNum = 15 Then strNum = "n"
                If xNum = 16 Then strNum = "o"
                If xNum = 17 Then strNum = "p"
                If xNum = 18 Then strNum = "q"
                If xNum = 19 Then strNum = "r"
                If xNum = 20 Then strNum = "s"
                If xNum = 21 Then strNum = "t"
                If xNum = 22 Then strNum = "u"
                If xNum = 23 Then strNum = "v"
                If xNum = 24 Then strNum = "w"
                If xNum = 25 Then strNum = "x"
                If xNum = 26 Then strNum = "y"
                If xNum = 27 Then strNum = "z"
                Return Trim(Trim(vOutputPrefix) & Trim(vVendor) & "_" & Trim(Format(Now, "yyMMdd")) & strNum & ".csv")   '//Create name for output file
            End If

        End Function

        Public Shared Function checkFile(ByVal mfilename As String) As Integer

            Dim cFile As String
            cFile = Dir("C:\" & mfilename)

            If Trim(cFile) = "" Then
                checkFile = 0
            Else
                checkFile = 1
            End If


        End Function



        Private Sub createDataFile(ByVal mPallettID As Long, ByVal strShipID As String, ByVal strNum As String, ByVal strPalletName As String, ByVal strType As String)

            Dim mVendor As String = "PSSI"
            Dim mOutputPrefix As String = "EQ_RPR_"

            Dim mOutputFile, mShipDate As String

            '//***************************************
            '//Create instance of DLL (USA Mobility) *
            '//***************************************


            '//***************************************
            '//Assign non-detail values (constructs) *
            '//***************************************
            mShipDate = createShipDate()
            mOutputFile = createOutputFileName(mOutputPrefix, mVendor, strNum)

            '//***************************************
            '//Get data from database                *
            '//***************************************
            Dim dt As DataTable = getData(mPallettID, strShipID)


            MsgBox(dt.Rows.Count)



            '//***************************************
            '//Check to see if file already exists   *
            '//***************************************
            If checkFile(mOutputFile) = 1 Then
                MsgBox("The file already exists. Please move or remove the file " & mOutputFile & "  and re-run this process.", MsgBoxStyle.OKOnly, "ERROR")
                lblDeviceCount.Text = 0
                Exit Sub
            End If

            '//Iterate through all devices and verify data
            Dim errMsg As String = ""
            'If Len(Trim(txtFO.Text)) < 1 Then errMsg += "File Output is not defined." & vbCrLf
            'If Len(Trim(txtFrequency.Text)) < 1 Then errMsg += "Frequency is not defined." & vbCrLf
            'If Len(Trim(txtChannel.Text)) < 1 Then errMsg += "Channel is not defined." & vbCrLf
            'If Len(Trim(txtModel.Text)) < 1 Then errMsg += "Model is not defined." & vbCrLf
            'If Len(Trim(txtSKU.Text)) < 1 Then errMsg += "SKU is not defined." & vbCrLf
            'If Len(Trim(errMsg)) > 0 Then
            'MsgBox(errMsg, MsgBoxStyle.Exclamation, "Error - Process will now terminate")
            'dt = Nothing
            'myDLL = Nothing
            'Exit Sub
            'End If

            '//If all values are present then uppercase all elements
            'txtFO.Text = UCase(txtFO.Text)
            'txtFrequency.Text = UCase(txtFrequency.Text)
            'txtChannel.Text = UCase(txtChannel.Text)
            'txtModel.Text = UCase(txtModel.Text)
            'txtSKU.Text = UCase(txtSKU.Text)

            Dim newValue As Integer = CInt(strNum) - 1
            Dim mFO As String = "PSSI" & Trim(Format(Now, "yyMMdd")) & CStr(newValue)
            'Dim mFO As String = "PSSI" & Trim(Format(Now, "yyMMdd")) & "00001"

            Dim blnFile As Boolean = createOutput(dt, mOutputFile, mShipDate, strPalletName, strType, mFO)

            '//Remove all objects from memory - ready for garbage collection
            dt = Nothing
            'myDLL = Nothing

            '//Close out of system
            MsgBox("the output file has been created. It is at C:\" & mOutputFile & " .", MsgBoxStyle.OKOnly)

        End Sub





        Private Function createOutput(ByVal vdt As DataTable, ByVal mFileName As String, ByVal vShipDate As String, ByVal vPalletName As String, ByVal vType As String, ByVal strFO As String) As Boolean


            Dim origSku As String
            Dim origCount As Integer = -1


            Dim dsGeneral As PSS.Data.Production.Joins

            Dim fs As New FileStream("c:\" & mFileName, FileMode.Create, FileAccess.Write)

            Dim s As New StreamWriter(fs)
            s.BaseStream.Seek(0, SeekOrigin.End)

            '//Define Header
            Dim strHprefix As String = "HDR"
            Dim strDprefix As String = "DTL"
            Dim strTprefix As String = "TOT"

            Dim strHeader, strDetail, strTotal As String

            Dim seqNumber As Integer
            Dim mLot As String = "001"
            Dim mBox As String = "01"

            Dim mVendor As String = "PSSI"
            Dim mShipDate As String = vShipDate.PadLeft(6, " ")

            '//Write Header Line of File

            'strHeader = strHprefix & "," & mVendor & "," & mShipDate & "," & vPalletName & "," & vType
            strHeader = strHprefix & "," & mVendor & "," & mShipDate

            If Me.rbAdd.Checked = True Then
                strHeader += ",ADD"
            End If

            s.WriteLine(strHeader)

            '//Write Detail Line(s) of File
            Dim mSeqNumber As String
            Dim mSerialNumber As String
            Dim mCapCode, mCapCodeNew As String
            Dim mTempFreq, mFrequency, mFO, mChannel, mModel, mSKU As String


            Dim mLotStr, mBoxStr As String

            Dim xCount As Integer = 0
            Dim r As DataRow
            seqNumber = 0
            For xCount = 0 To vdt.Rows.Count - 1
                seqNumber += 1
                mSeqNumber = CStr(seqNumber).PadLeft(7, "0")

                r = vdt.Rows(xCount)
                mSerialNumber = r("Device_SN")

                If IsDBNull(r("Devicemetro_SKU")) = True Then
                    mSKU = ""
                    mChannel = ""
                    mModel = ""
                Else
                    mSKU = r("Devicemetro_SKU")
                    mChannel = Mid$(Trim(r("DeviceMetro_SKU")), 9, 3)
                    mModel = Mid$(Trim(r("DeviceMetro_SKU")), 1, 3)

                    If origSku = "" Then
                        origSku = mSKU 'First 1 only
                        origCount += 1
                    End If

                    If origSku <> mSKU Then
                        origSku = mSKU 'Increment by 1
                        origCount += 1
                        origSku = mSKU
                    End If

                End If

                'If Me.rbAdd.Checked = True Then
                Dim strOrigCount As String = CStr(origCount)
                strOrigCount = strOrigCount.PadLeft(5, "0")
                strFO = "PSSI" & Trim(Format(Now, "yyMMdd")) & strOrigCount
                mFO = strFO
                'mFO = Mid(strFO, 1, (Len(strFO) - Len(origCount))) & strOrigCount
                'Else
                '    mFO = strFO & "0000"
                'End If

                'If Me.rbAdd.Checked = True Then
                mLotStr = CStr(CInt(origCount) + 1)
                mBoxStr = CStr(CInt(origCount) + 1)
                mLot = mLotStr.PadLeft(3, "0")
                mBox = mBoxStr.PadLeft(2, "0")
                'End If

                '//Get frequency

                If IsDBNull(r("Freq_ID")) = False Then
                    Try
                        Dim dtFreq As DataTable = dsGeneral.OrderEntrySelect("SELECT * FROM lfrequency WHERE freq_id = " & r("Freq_ID"))
                        Dim rFreq As DataRow = dtFreq.Rows(0)
                        mTempFreq = rFreq("Freq_Number")
                        mFrequency = Mid$(Trim(mTempFreq), 1, 3) & Mid$(Trim(mTempFreq), 5, 4)
                    Catch ex As Exception
                        mTempFreq = "000.0000"
                        mFrequency = Mid$(Trim(mTempFreq), 1, 3) & Mid$(Trim(mTempFreq), 5, 4)
                    End Try
                Else
                    mTempFreq = "000.0000"
                    mFrequency = Mid$(Trim(mTempFreq), 1, 3) & Mid$(Trim(mTempFreq), 5, 4)
                End If

                Dim intCapcode As Long
                Try
                    intCapcode = CInt(r("Devicemetro_CapCode"))
                Catch ex As Exception
                    intCapcode = 0
                End Try

                'If IsDBNull(r("Devicemetro_CapCode")) = False Then
                If IsDBNull(r("Devicemetro_CapCode")) = False And intCapcode > 2000 Then
                    mCapCode = r("Devicemetro_CapCode")
                    If Mid$(mCapCode, 1, 1) = "E" Then mCapCode = Mid$(mCapCode, 2, 10)
                    If Mid$(mCapCode, 1, 1) = "e" Then mCapCode = Mid$(mCapCode, 2, 10)

                    'If Len(Trim(mCapCode.ToString)) < 10 Then October 14, 2005
                    If Len(Trim(mCapCode.ToString)) < 11 Then
                        mCapCodeNew = mCapCode.PadRight(10, " ")
                    End If

                Else
                    'mCapCode = CStr("").PadRight(10, " ")
                    'mCapCodeNew = CStr("").PadRight(10, " ")

                    mCapCode = CStr("").PadRight(10, " ")
                    mCapCodeNew = CStr("").PadRight(10, " ")

                End If

                Try
                    'If Len(mCapCodeNew) < 10 Then 'October 14, 2005
                    If Len(Trim(mCapCodeNew)) < 1 Then
                        mCapCodeNew = "0000000000"
                    End If
                Catch ex As Exception
                    mCapCodeNew = "0000000000"
                End Try

                If IsDBNull(mFrequency) = True Then mFrequency = "NONE"


                Dim strAdd As String = ""
                If Me.rbAdd.Checked = True Then
                    strAdd = "," & Mid$(mSKU, 7, 2) & " ," & Mid(mSKU, 4, 3)
                End If

                strDetail = strDprefix & "," & mSeqNumber & "," & mSerialNumber & "," & _
                            mFO & "," & mLot & "," & mBox & "," & mCapCodeNew.ToString & "," & mFrequency & "," & _
                            mChannel & "," & mModel & strAdd & "," & mSKU
                'strDetail = strDprefix & "," & mSeqNumber & "," & mSerialNumber & "," & _
                '            mFO & "," & mLot & "," & mBox & "," & mCapCode.ToString & "," & mFrequency & "," & _
                '            mChannel & "," & mModel & strAdd & "," & mSKU
                s.WriteLine(strDetail)
            Next

            '//Write TotalLine of File
            strTotal = strTprefix & "," & mSeqNumber
            s.WriteLine(strTotal)

            '//Close File
            s.Close()

            Return True

        End Function




        Private Sub txtShipID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipID.TextChanged

        End Sub

        Private Sub btnReprintLabels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintLabels.Click

            'Dim strDate As String = InputBox("Enter date the pallet was created", "Pallet Date", Now)
            'Dim strDateFormat = Trim(Format(strDate, "yyyyMMdd")) & "-"
            Dim strPallet As String = InputBox("Enter pallet number", "Pallet Number", Now)

            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM tpalletname WHERE Pallet_ID = " & strPallet)

            If dt.Rows.Count > 0 And dt.Rows.Count < 2 Then

                '//Get Pallet name
                Dim dtName As DataTable = ds.OrderEntrySelect("SELECT Pallet_Name FROM tpalletname WHERE Pallet_ID = " & strPallet)
                Dim r As DataRow = dtName.Rows(0)

                '//Print the labels
                Dim rptApp As New CRAXDRT.Application()
                Dim rpt As New CRAXDRT.Report()
                Try
                    rpt = rptApp.OpenReport("\\svr_pssiusr\reports\PSSInet_Reports_Prod\Ship_PalletLabel.rpt")
                    rpt.RecordSelectionFormula = "{tpalletname.Pallet_Name} = '" & r("Pallet_Name") & "'"
                    rpt.PrintOut(False, 1)
                Catch ex As Exception
                Finally
                    rpt = Nothing
                    rptApp = Nothing
                End Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                '//Print the labels

            End If

        End Sub

        Private Sub btnSmall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmall.Click

            Dim strPallet As String = InputBox("Enter pallet number", "Pallet Number")

            Dim ds As PSS.Data.Production.Joins
            Dim dt As DataTable = ds.OrderEntrySelect("SELECT * FROM tpalletname WHERE Pallet_Name = '" & Trim(strPallet) & "'")

            If dt.Rows.Count > 0 And dt.Rows.Count < 2 Then

                '//Get Pallet name
                Dim dtName As DataTable = ds.OrderEntrySelect("SELECT Pallet_Name FROM tpalletname WHERE Pallet_Name = '" & strPallet & "'")
                Dim r As DataRow = dtName.Rows(0)

                '//Print the labels
                Dim rptApp As New CRAXDRT.Application()
                Dim rpt As New CRAXDRT.Report()
                Try
                    rpt = rptApp.OpenReport("\\svr_pssiusr\reports\PSSInet_Reports_Prod\Ship_PalletLabel_OLD.rpt")
                    rpt.RecordSelectionFormula = "{tpalletname.Pallet_Name} = '" & Trim(r("Pallet_Name")) & "'"
                    rpt.PrintOut(False, 1)
                Catch ex As Exception
                Finally
                    rpt = Nothing
                    rptApp = Nothing
                End Try
                Cursor.Current = System.Windows.Forms.Cursors.Default
                '//Print the labels

            End If

        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            Dim vPallet As String = InputBox("Enter Pallet Number", "Enter ID")
            Dim vName As String = InputBox("Enter Pallet Name", "Enter Name")

            If Len(Trim(CInt(vPallet))) > 1 And Len(Trim(vName)) > 1 Then
                'createDataFile(100804, "", 1, "20050906-002", "RPR")
                createDataFile(CInt(vPallet), "", 1, vName, "RPR")
            End If
        End Sub

    End Class

End Namespace
