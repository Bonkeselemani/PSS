'Imports eInfoDesigns.dbProvider.MySqlClient
'Imports Microsoft.Data.Odbc

'Imports PSS.Data
'Imports PSS.Core
'Imports PSS.Rules
'Imports PSS.Core.Global
'Imports System
'Imports System.Data
'Imports System.GC
'Imports System.IO
'Imports System.Data.OleDb

'Imports System.Net
'Imports System.Net.Dns

'Namespace TechTools

'    Public Class TechTools
'        Inherits System.Windows.Forms.Form

'#Region " Windows Form Designer generated code "

'        Public Sub New()
'            MyBase.New()

'            'This call is required by the Windows Form Designer.
'            InitializeComponent()

'            'Add any initialization after the InitializeComponent() call

'        End Sub

'        'Form overrides dispose to clean up the component list.
'        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'            If disposing Then
'                If Not (components Is Nothing) Then
'                    components.Dispose()
'                End If
'            End If
'            MyBase.Dispose(disposing)
'        End Sub

'        'Required by the Windows Form Designer
'        Private components As System.ComponentModel.IContainer

'        'NOTE: The following procedure is required by the Windows Form Designer
'        'It can be modified using the Windows Form Designer.  
'        'Do not modify it using the code editor.
'        Friend WithEvents Label5 As System.Windows.Forms.Label
'        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
'        Friend WithEvents lstTRAY As System.Windows.Forms.ListBox
'        Friend WithEvents btnCreateTray As System.Windows.Forms.Button
'        Friend WithEvents lblMain As System.Windows.Forms.Label
'        Friend WithEvents txtWO As System.Windows.Forms.TextBox
'        Friend WithEvents lblWO As System.Windows.Forms.Label
'        Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
'        Friend WithEvents lblCustomer As System.Windows.Forms.Label
'        Friend WithEvents btnCancel As System.Windows.Forms.Button
'        Friend WithEvents lblCount As System.Windows.Forms.Label
'        Friend WithEvents mCount As System.Windows.Forms.Label
'        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(TechTools))
'            Me.Label5 = New System.Windows.Forms.Label()
'            Me.txtIMEI = New System.Windows.Forms.TextBox()
'            Me.lstTRAY = New System.Windows.Forms.ListBox()
'            Me.btnCreateTray = New System.Windows.Forms.Button()
'            Me.lblMain = New System.Windows.Forms.Label()
'            Me.txtWO = New System.Windows.Forms.TextBox()
'            Me.lblWO = New System.Windows.Forms.Label()
'            Me.txtCustomer = New System.Windows.Forms.TextBox()
'            Me.lblCustomer = New System.Windows.Forms.Label()
'            Me.btnCancel = New System.Windows.Forms.Button()
'            Me.lblCount = New System.Windows.Forms.Label()
'            Me.mCount = New System.Windows.Forms.Label()
'            Me.SuspendLayout()
'            '
'            'Label5
'            '
'            Me.Label5.BackColor = System.Drawing.Color.Transparent
'            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.Label5.ForeColor = System.Drawing.Color.Black
'            Me.Label5.Location = New System.Drawing.Point(64, 56)
'            Me.Label5.Name = "Label5"
'            Me.Label5.Size = New System.Drawing.Size(48, 23)
'            Me.Label5.TabIndex = 5
'            Me.Label5.Text = "IMEI:"
'            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txtIMEI
'            '
'            Me.txtIMEI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtIMEI.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.txtIMEI.Location = New System.Drawing.Point(120, 56)
'            Me.txtIMEI.Name = "txtIMEI"
'            Me.txtIMEI.Size = New System.Drawing.Size(176, 26)
'            Me.txtIMEI.TabIndex = 6
'            Me.txtIMEI.Text = ""
'            '
'            'lstTRAY
'            '
'            Me.lstTRAY.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
'                        Or System.Windows.Forms.AnchorStyles.Left)
'            Me.lstTRAY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.lstTRAY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lstTRAY.ItemHeight = 16
'            Me.lstTRAY.Location = New System.Drawing.Point(120, 88)
'            Me.lstTRAY.Name = "lstTRAY"
'            Me.lstTRAY.Size = New System.Drawing.Size(176, 178)
'            Me.lstTRAY.TabIndex = 7
'            '
'            'btnCreateTray
'            '
'            Me.btnCreateTray.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
'            Me.btnCreateTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.btnCreateTray.Location = New System.Drawing.Point(120, 272)
'            Me.btnCreateTray.Name = "btnCreateTray"
'            Me.btnCreateTray.Size = New System.Drawing.Size(176, 40)
'            Me.btnCreateTray.TabIndex = 8
'            Me.btnCreateTray.Text = "Create Tray"
'            '
'            'lblMain
'            '
'            Me.lblMain.BackColor = System.Drawing.Color.Transparent
'            Me.lblMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblMain.ForeColor = System.Drawing.Color.Black
'            Me.lblMain.Location = New System.Drawing.Point(24, 16)
'            Me.lblMain.Name = "lblMain"
'            Me.lblMain.Size = New System.Drawing.Size(280, 24)
'            Me.lblMain.TabIndex = 10
'            Me.lblMain.Text = "CREATE CELLULAR TRAY"
'            '
'            'txtWO
'            '
'            Me.txtWO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.txtWO.Location = New System.Drawing.Point(440, 112)
'            Me.txtWO.Name = "txtWO"
'            Me.txtWO.Size = New System.Drawing.Size(200, 26)
'            Me.txtWO.TabIndex = 12
'            Me.txtWO.Text = ""
'            '
'            'lblWO
'            '
'            Me.lblWO.BackColor = System.Drawing.Color.Transparent
'            Me.lblWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblWO.ForeColor = System.Drawing.Color.Black
'            Me.lblWO.Location = New System.Drawing.Point(304, 112)
'            Me.lblWO.Name = "lblWO"
'            Me.lblWO.Size = New System.Drawing.Size(128, 23)
'            Me.lblWO.TabIndex = 11
'            Me.lblWO.Text = "WORKORDER:"
'            Me.lblWO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'txtCustomer
'            '
'            Me.txtCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'            Me.txtCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.txtCustomer.Location = New System.Drawing.Point(440, 80)
'            Me.txtCustomer.Name = "txtCustomer"
'            Me.txtCustomer.Size = New System.Drawing.Size(200, 26)
'            Me.txtCustomer.TabIndex = 14
'            Me.txtCustomer.Text = ""
'            '
'            'lblCustomer
'            '
'            Me.lblCustomer.BackColor = System.Drawing.Color.Transparent
'            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCustomer.ForeColor = System.Drawing.Color.Black
'            Me.lblCustomer.Location = New System.Drawing.Point(304, 80)
'            Me.lblCustomer.Name = "lblCustomer"
'            Me.lblCustomer.Size = New System.Drawing.Size(128, 23)
'            Me.lblCustomer.TabIndex = 13
'            Me.lblCustomer.Text = "CUSTOMER:"
'            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'            '
'            'btnCancel
'            '
'            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.btnCancel.Location = New System.Drawing.Point(440, 144)
'            Me.btnCancel.Name = "btnCancel"
'            Me.btnCancel.Size = New System.Drawing.Size(200, 32)
'            Me.btnCancel.TabIndex = 15
'            Me.btnCancel.Text = "Cancel"
'            '
'            'lblCount
'            '
'            Me.lblCount.BackColor = System.Drawing.Color.Transparent
'            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.lblCount.Location = New System.Drawing.Point(440, 192)
'            Me.lblCount.Name = "lblCount"
'            Me.lblCount.Size = New System.Drawing.Size(200, 23)
'            Me.lblCount.TabIndex = 16
'            Me.lblCount.Text = "COUNT"
'            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'mCount
'            '
'            Me.mCount.BackColor = System.Drawing.Color.Transparent
'            Me.mCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'            Me.mCount.Location = New System.Drawing.Point(440, 224)
'            Me.mCount.Name = "mCount"
'            Me.mCount.Size = New System.Drawing.Size(200, 64)
'            Me.mCount.TabIndex = 17
'            Me.mCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'            '
'            'TechTools
'            '
'            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'            Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Bitmap)
'            Me.ClientSize = New System.Drawing.Size(688, 365)
'            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.mCount, Me.lblCount, Me.btnCancel, Me.txtCustomer, Me.lblCustomer, Me.txtWO, Me.lblWO, Me.lblMain, Me.btnCreateTray, Me.lstTRAY, Me.txtIMEI, Me.Label5})
'            Me.Name = "TechTools"
'            Me.Text = "TechTools"
'            Me.ResumeLayout(False)

'        End Sub

'#End Region

'        Dim vConn As PSS.Data.Production.Joins
'        Dim mCustomer As String = ""
'        Dim mWO As String = ""
'        Dim intWO As Long = 0
'        Dim intDeviceID As Long = 0
'        Dim intCount As Integer = 0
'        Dim blnUpdate As Boolean

'        Private Sub TechTools_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'            clearForm()
'        End Sub

'        Private Sub clearForm()
'            mCustomer = ""
'            mWO = ""
'            txtIMEI.Text = ""
'            txtCustomer.Enabled = True
'            txtWO.Enabled = True
'            System.Windows.Forms.Application.DoEvents()
'            txtCustomer.Text = ""
'            txtWO.Text = ""
'            intWO = 0
'            intDeviceID = 0
'            intCount = 0
'            mCount.Text = 0
'            lstTRAY.Items.Clear()
'            txtIMEI.Focus()
'        End Sub

'        Private Sub getMainData()
'            If Len(Trim(txtIMEI.Text)) > 0 Then
'                txtCustomer.Text = getCustomerName(txtIMEI.Text)
'                System.Windows.Forms.Application.DoEvents()
'                mCustomer = txtCustomer.Text
'                txtCustomer.Enabled = False
'                System.Windows.Forms.Application.DoEvents()
'                txtWO.Text = getWorkorderName(txtIMEI.Text)
'                System.Windows.Forms.Application.DoEvents()
'                mWO = txtWO.Text
'                txtWO.Enabled = False
'                getWorkorderID(txtIMEI.Text)
'            End If
'        End Sub

'        Private Function getCustomerName(ByVal vIMEI As String) As String
'            Dim strSQL As String = "SELECT tcustomer.cust_name1, tcustomer.cust_name2, tdevice.device_ID FROM tdevice INNER JOIN tlocation ON tdevice.loc_id = tlocation.loc_id INNER JOIN tcustomer ON tlocation.cust_id = tcustomer.cust_id WHERE Device_SN = '" & vIMEI & "' AND Device_DateShip IS NULL"
'            Dim dt As DataTable = vConn.OrderEntrySelect(strSQL)
'            Dim r As DataRow
'            If dt.Rows.Count > 0 Then
'                r = dt.Rows(0)
'                mCustomer = Trim(r("Cust_Name1") & " " & r("Cust_Name2"))
'                intDeviceID = r("Device_ID")
'                Return Trim(r("Cust_Name1") & " " & r("Cust_Name2"))
'            Else
'                Return "ERROR"
'            End If
'        End Function

'        Private Function getWorkorderName(ByVal vIMEI As String) As String
'            Dim strSQL As String = "SELECT tworkorder.wo_custwo FROM tdevice INNER JOIN tworkorder ON tdevice.wo_id = tworkorder.wo_id WHERE Device_SN = '" & vIMEI & "' AND Device_DateShip IS NULL"
'            Dim dt As DataTable = vConn.OrderEntrySelect(strSQL)
'            Dim r As DataRow
'            If dt.Rows.Count > 0 Then
'                r = dt.Rows(0)
'                mWO = Trim(r("wo_custwo"))
'                Return Trim(r("wo_custwo"))
'            Else
'                Return "ERROR"
'            End If
'        End Function

'        Private Sub getWorkorderID(ByVal vIMEI As String)
'            Dim strSQL As String = "SELECT tworkorder.wo_id FROM tdevice INNER JOIN tworkorder ON tdevice.wo_id = tworkorder.wo_id WHERE Device_SN = '" & vIMEI & "' AND Device_DateShip IS NULL"
'            Dim dt As DataTable = vConn.OrderEntrySelect(strSQL)
'            Dim r As DataRow
'            If dt.Rows.Count > 0 Then
'                r = dt.Rows(0)
'                intWO = Trim(r("wo_id"))
'            End If
'        End Sub

'        Private Function checkLogicalTrayAssignment() As Boolean
'            If intDeviceID > 0 Then
'                Dim strSQL As String = "SELECT cellopt_LogicTray FROM tcellopt WHERE device_id = " & intDeviceID
'                Dim dt As DataTable = vConn.OrderEntrySelect(strSQL)
'                Dim r As DataRow
'                If dt.Rows.Count > 0 Then
'                    r = dt.Rows(0)
'                    If IsDBNull(r("cellopt_LogicTray")) = True Then
'                        Return True
'                    Else
'                        Return False
'                    End If
'                End If
'            End If
'        End Function

'        Private Function compareMainData(ByVal vIMEI As String) As Boolean
'            compareMainData = False
'            If UCase(Trim(mCustomer)) = UCase(Trim(getCustomerName(vIMEI))) Then
'                If UCase(Trim(mWO)) = UCase(Trim(getWorkorderName(vIMEI))) Then
'                    Return True
'                End If
'            End If
'        End Function

'        Private Sub txtIMEI_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyDown
'            If e.KeyCode = 13 Then

'                '//Verify that the device is not being used by another logical tray
'                getWorkorderID(Trim(txtIMEI.Text))
'                System.Windows.Forms.Application.DoEvents()
'                intDeviceID = getDeviceID(Trim(txtIMEI.Text))
'                System.Windows.Forms.Application.DoEvents()
'                Dim blnCheck As Boolean = checkLogicalTrayAssignment()
'                If blnCheck = False Then
'                    MsgBox("This item is already assign to another tray. CAN NOT ADD.", MsgBoxStyle.Critical, "ASSIGNED TO ANOTHER TRAY")
'                    txtIMEI.Text = ""
'                    txtIMEI.Focus()
'                    Exit Sub
'                End If

'                '//Verify that the deviec is not being used by another logical tray

'                Dim blnCompare As Boolean

'                txtIMEI.Text = UCase(Trim(txtIMEI.Text))
'                If mCustomer = "" Or mWO = "" Then
'                    getMainData()
'                    '//Add to listbox
'                    addItem()
'                Else
'                    '//Compare data 
'                    blnCompare = compareMainData(Trim(txtIMEI.Text))
'                    If blnCompare = False Then
'                        MsgBox("This device does not belong to the same workorder as the other devices in this tray. Please report this to your supervisor.", MsgBoxStyle.Critical, "Remove From Tray")
'                        txtIMEI.Text = ""
'                        txtIMEI.Focus()
'                        Exit Sub
'                    Else
'                        '//Device can be added to tray
'                        Dim xCount As Integer = 0
'                        For xCount = 0 To Me.lstTRAY.Items.Count - 1
'                            If Trim(lstTRAY.Items(xCount)) = Trim(txtIMEI.Text) Then
'                                MsgBox("This item is already in list. CAN NOT ADD.", MsgBoxStyle.Critical, "DUPLICATE")
'                                txtIMEI.Text = ""
'                                txtIMEI.Focus()
'                                Exit Sub
'                            End If
'                        Next
'                        '//Add to listbox
'                        addItem()
'                    End If
'                End If
'            End If
'        End Sub


'        Private Sub addItem()
'            lstTRAY.Items.Add(Trim(txtIMEI.Text))
'            txtIMEI.Text = ""
'            Me.intCount += 1
'            System.Windows.Forms.Application.DoEvents()
'            Me.mCount.Text = intCount
'            txtIMEI.Focus()
'        End Sub

'        Private Sub btnCreateTray_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateTray.Click

'            Dim intDevice As Long
'            Dim dtTray As New PSS.Data.Production.ttray()

'            '//Create Tray Number
'            Dim strSQL As String = "INSERT INTO tcell_logictray (LogicTray_Date, WO_ID) VALUES ('" & Gui.Receiving.FormatDate(Now) & "', " & intWO & ")"
'            Dim intTray As Int32 = dtTray.idTransDev(strSQL)

'            Dim xCount As Integer

'            For xCount = 0 To lstTRAY.Items.Count - 1
'                '//Get the deviceID for each
'                intDevice = getDeviceID(lstTRAY.Items(xCount))
'                System.Windows.Forms.Application.DoEvents()
'                '//Update tcellopt with data
'                If intDevice > 0 Then
'                    blnUpdate = False
'                    blnUpdate = vConn.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_LogicTray = " & intTray & " WHERE Device_ID = " & intDevice)
'                End If
'            Next

'            clearForm()


'        End Sub


'        Private Function getDeviceID(ByVal mIMEI As String) As Long
'            If intWO > 0 Then
'                Dim dt As DataTable = vConn.OrderEntrySelect("SELECT Device_ID FROM tdevice WHERE WO_ID = " & intWO & " AND Device_SN = '" & mIMEI & "'")
'                If dt.Rows.Count > 0 Then
'                    Dim r As DataRow
'                    r = dt.Rows(0)
'                    Return r("Device_ID")
'                Else
'                    Return 0
'                End If
'            End If
'        End Function





'        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
'            clearForm()
'        End Sub

'        Private Sub txtIMEI_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIMEI.TextChanged

'        End Sub
'    End Class

'End Namespace
