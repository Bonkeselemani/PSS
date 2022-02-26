Option Explicit On 

Imports PSS.Data
Imports PSS.Data.Buisness
Imports PSS.Core

Namespace Gui
    Public Class SyxKitting
        Inherits System.Windows.Forms.Form

        Private _objSyx As Syx
        Private _Device_ID As Integer
        Private _Model_ID As Integer
        Private _Screen_ID = _objSyx.ScreenID_Kitting
        Private Const vBuffer As Integer = 5
        Private Const hBuffer As Integer = 5
        Private Const btnWidth = 120
        Private Const btnHeight = 50
        Private btnLeft As Int32 = 5
        Private btnTop As Int32 = 5
        Private pnlLeft As Integer
        Private pnlWidth As Integer
        Private colCount As Integer
        Private _dtAccessoriessList As DataTable
#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()
            Me._objSyx = New Syx()
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
        Friend WithEvents txtSerial As System.Windows.Forms.TextBox
        Friend WithEvents btnComplete As System.Windows.Forms.Button
        Friend WithEvents LabelSerial As System.Windows.Forms.Label
        Friend WithEvents LabelProduct As System.Windows.Forms.Label
        Friend WithEvents lblProduct As System.Windows.Forms.Label
        Friend WithEvents lblMfg As System.Windows.Forms.Label
        Friend WithEvents LabelMfg As System.Windows.Forms.Label
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents LabelModel As System.Windows.Forms.Label
        Friend WithEvents btnOverrideComplete As System.Windows.Forms.Button
        Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
        Friend WithEvents tbAccessories As System.Windows.Forms.TabPage
        Friend WithEvents pnlAccessories As System.Windows.Forms.Panel
        Friend WithEvents Status As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents btnReprint As System.Windows.Forms.Button

       
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.txtSerial = New System.Windows.Forms.TextBox()
            Me.btnComplete = New System.Windows.Forms.Button()
            Me.btnOverrideComplete = New System.Windows.Forms.Button()
            Me.LabelSerial = New System.Windows.Forms.Label()
            Me.pnlAccessories = New System.Windows.Forms.Panel()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.LabelModel = New System.Windows.Forms.Label()
            Me.lblMfg = New System.Windows.Forms.Label()
            Me.LabelMfg = New System.Windows.Forms.Label()
            Me.lblProduct = New System.Windows.Forms.Label()
            Me.LabelProduct = New System.Windows.Forms.Label()
            Me.TabControl1 = New System.Windows.Forms.TabControl()
            Me.tbAccessories = New System.Windows.Forms.TabPage()
            Me.Status = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnReprint = New System.Windows.Forms.Button()
            Me.TabControl1.SuspendLayout()
            Me.tbAccessories.SuspendLayout()
            Me.SuspendLayout()
            '
            'txtSerial
            '
            Me.txtSerial.BackColor = System.Drawing.Color.Aqua
            Me.txtSerial.Location = New System.Drawing.Point(72, 8)
            Me.txtSerial.Name = "txtSerial"
            Me.txtSerial.Size = New System.Drawing.Size(216, 20)
            Me.txtSerial.TabIndex = 0
            Me.txtSerial.Text = ""
            '
            'btnComplete
            '
            Me.btnComplete.BackColor = System.Drawing.Color.Green
            Me.btnComplete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnComplete.ForeColor = System.Drawing.Color.White
            Me.btnComplete.Location = New System.Drawing.Point(536, 8)
            Me.btnComplete.Name = "btnComplete"
            Me.btnComplete.Size = New System.Drawing.Size(104, 24)
            Me.btnComplete.TabIndex = 88
            Me.btnComplete.Text = "Complete"
            '
            'btnOverrideComplete
            '
            Me.btnOverrideComplete.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(128, Byte))
            Me.btnOverrideComplete.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnOverrideComplete.ForeColor = System.Drawing.Color.White
            Me.btnOverrideComplete.Location = New System.Drawing.Point(648, 8)
            Me.btnOverrideComplete.Name = "btnOverrideComplete"
            Me.btnOverrideComplete.Size = New System.Drawing.Size(136, 24)
            Me.btnOverrideComplete.TabIndex = 89
            Me.btnOverrideComplete.Text = "Override Complete"
            '
            'LabelSerial
            '
            Me.LabelSerial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSerial.ForeColor = System.Drawing.Color.White
            Me.LabelSerial.Location = New System.Drawing.Point(16, 8)
            Me.LabelSerial.Name = "LabelSerial"
            Me.LabelSerial.Size = New System.Drawing.Size(48, 23)
            Me.LabelSerial.TabIndex = 0
            Me.LabelSerial.Text = "Serial:"
            Me.LabelSerial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'pnlAccessories
            '
            Me.pnlAccessories.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(255, Byte))
            Me.pnlAccessories.Location = New System.Drawing.Point(8, 8)
            Me.pnlAccessories.Name = "pnlAccessories"
            Me.pnlAccessories.Size = New System.Drawing.Size(752, 320)
            Me.pnlAccessories.TabIndex = 90
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.Location = New System.Drawing.Point(608, 40)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(184, 23)
            Me.lblModel.TabIndex = 5
            '
            'LabelModel
            '
            Me.LabelModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelModel.ForeColor = System.Drawing.Color.White
            Me.LabelModel.Location = New System.Drawing.Point(552, 40)
            Me.LabelModel.Name = "LabelModel"
            Me.LabelModel.Size = New System.Drawing.Size(56, 23)
            Me.LabelModel.TabIndex = 4
            Me.LabelModel.Text = "Model:"
            Me.LabelModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMfg
            '
            Me.lblMfg.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.lblMfg.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMfg.Location = New System.Drawing.Point(328, 40)
            Me.lblMfg.Name = "lblMfg"
            Me.lblMfg.Size = New System.Drawing.Size(184, 23)
            Me.lblMfg.TabIndex = 3
            '
            'LabelMfg
            '
            Me.LabelMfg.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelMfg.ForeColor = System.Drawing.Color.White
            Me.LabelMfg.Location = New System.Drawing.Point(280, 40)
            Me.LabelMfg.Name = "LabelMfg"
            Me.LabelMfg.Size = New System.Drawing.Size(48, 23)
            Me.LabelMfg.TabIndex = 2
            Me.LabelMfg.Text = "Mfg:"
            Me.LabelMfg.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProduct
            '
            Me.lblProduct.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
            Me.lblProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProduct.Location = New System.Drawing.Point(72, 40)
            Me.lblProduct.Name = "lblProduct"
            Me.lblProduct.Size = New System.Drawing.Size(184, 23)
            Me.lblProduct.TabIndex = 1
            '
            'LabelProduct
            '
            Me.LabelProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelProduct.ForeColor = System.Drawing.Color.White
            Me.LabelProduct.Location = New System.Drawing.Point(8, 40)
            Me.LabelProduct.Name = "LabelProduct"
            Me.LabelProduct.Size = New System.Drawing.Size(64, 23)
            Me.LabelProduct.TabIndex = 0
            Me.LabelProduct.Text = "Product:"
            Me.LabelProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'TabControl1
            '
            Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbAccessories})
            Me.TabControl1.Location = New System.Drawing.Point(8, 112)
            Me.TabControl1.Name = "TabControl1"
            Me.TabControl1.SelectedIndex = 0
            Me.TabControl1.Size = New System.Drawing.Size(784, 368)
            Me.TabControl1.TabIndex = 91
            '
            'tbAccessories
            '
            Me.tbAccessories.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlAccessories})
            Me.tbAccessories.Location = New System.Drawing.Point(4, 22)
            Me.tbAccessories.Name = "tbAccessories"
            Me.tbAccessories.Size = New System.Drawing.Size(776, 342)
            Me.tbAccessories.TabIndex = 0
            Me.tbAccessories.Text = "ACCESSORIES"
            '
            'Status
            '
            Me.Status.BackColor = System.Drawing.Color.Black
            Me.Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Status.ForeColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            Me.Status.Location = New System.Drawing.Point(8, 64)
            Me.Status.Name = "Status"
            Me.Status.Size = New System.Drawing.Size(784, 48)
            Me.Status.TabIndex = 150
            Me.Status.Text = "Status"
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.Blue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.btnClear.Location = New System.Drawing.Point(464, 8)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(64, 24)
            Me.btnClear.TabIndex = 151
            Me.btnClear.Text = "&Clear"
            '
            'btnReprint
            '
            Me.btnReprint.BackColor = System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte))
            Me.btnReprint.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprint.ForeColor = System.Drawing.Color.White
            Me.btnReprint.Location = New System.Drawing.Point(368, 8)
            Me.btnReprint.Name = "btnReprint"
            Me.btnReprint.Size = New System.Drawing.Size(88, 24)
            Me.btnReprint.TabIndex = 152
            Me.btnReprint.Text = "Re-Print"
            '
            'SyxKitting
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(800, 486)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnReprint, Me.btnClear, Me.Status, Me.TabControl1, Me.LabelSerial, Me.btnOverrideComplete, Me.btnComplete, Me.txtSerial, Me.LabelModel, Me.LabelMfg, Me.lblMfg, Me.lblModel, Me.LabelProduct, Me.lblProduct})
            Me.Name = "SyxKitting"
            Me.Text = "SyxKitting"
            Me.TabControl1.ResumeLayout(False)
            Me.tbAccessories.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Loading "

        '****************************************************************************************************

        Private Sub SyxKitting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            ResetGlobals()
            Status.ForeColor = Color.Lime
            Status.Text = "Please scan a valid serial number..."

        End Sub


        '*******************************************************************

        Private Sub LoadAccessoriesList()
            Dim strSQL As String = ""
            Dim objPJoins As New PSS.Data.Production.Joins()

            Dim objSyxRec As New PSS.Data.Buisness.SyxReceivingShipping()
            Try
                'strSQL = "SELECT lbillcodes.*,tpsmap.PSMap_ID,tpsmap.PSPrice_ID,lpsprice.PSPrice_Number" & Environment.NewLine
                'strSQL &= "From tdevice" & Environment.NewLine
                'strSQL &= "Inner Join tpsmap on tpsmap.Model_ID=tdevice.Model_ID" & Environment.NewLine
                'strSQL &= "Inner Join lbillcodes on lbillcodes.Billcode_ID=tpsmap.Billcode_ID" & Environment.NewLine
                'strSQL &= "Inner Join lpsprice on lpsprice.psprice_id= tpsmap.psprice_id" & Environment.NewLine
                'strSQL &= "Where lbillcodes.BillType_ID = 3" & Environment.NewLine 'BillType=3 for SYX
                'strSQL &= "And tdevice.Device_ID=" & Me._Device_ID & Environment.NewLine
                'dtAccessoriessList = objPJoins.GenericSelect(strSQL)
                Me._dtAccessoriessList = objSyxRec.GetModelAccessories(_Model_ID, "3")
                Me.CreateAccessoriesButtons()
                Me.HighlightSelectedAccessories()

            Catch ex As Exception

                MessageBox.Show(ex.ToString, "LoadAccessoriesList", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Finally
                If Not IsNothing(objPJoins) Then objPJoins = Nothing
            End Try
        End Sub

        '****************************************************************************************************

#End Region

#Region "Button, Text box Events"

        '****************************************************************************************************
        Private Sub btnComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComplete.Click
            Dim user_ID As Integer = PSS.Core.ApplicationUser.IDuser
            Dim i As Integer
            Dim Miss_Assy As String = ""
            Try
                'Made sure all accessories is selected
                Miss_Assy = Me.Get_Missing_Accessories
                If Me.pnlAccessories.Controls.Count > 0 AndAlso Miss_Assy.Length > 0 Then
                    MessageBox.Show("The " & Miss_Assy & " accessories has not been selected. You can not complete with missing accessories." & vbCrLf & " Please select all accessories or contact your supervisor to override.", "Missing Accessories", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Exit Sub
                End If

                i = Me._objSyx.UpdateKitting(Me._Device_ID, user_ID)
                Me.PrintKittingLabel()
                Me.ResetGlobals()
                Me.Status.Text = "Kitting has been updated. Please scan another serial number..."

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Finally

                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtSerial.SelectAll() : Me.txtSerial.Focus()

            End Try


        End Sub

        '****************************************************************************************************

        Private Sub btnOverrideComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOverrideComplete.Click
            Dim user_ID As Integer = PSS.Core.ApplicationUser.IDuser
            Dim i As Integer

            Try
                i = Me._objSyx.UpdateKitting(Me._Device_ID, user_ID)
                Me.PrintKittingLabel()
                Me.ResetGlobals()
                Me.Status.Text = "Kitting has been updated. Please scan another serial number..."

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnComplete_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Finally

                Me.Enabled = True : Cursor.Current = Cursors.Default
                Me.txtSerial.SelectAll() : Me.txtSerial.Focus()

            End Try

        End Sub

        '****************************************************************************************************

        '*******************************************************************
        Private Sub txtSerial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSerial.KeyDown
            If e.KeyValue = 13 AndAlso Me.txtSerial.Text.Trim.Length > 0 Then
                Me.ProcessSN()
            End If
        End Sub


        '*****************************************************************

        Private Sub btnAccessories_Click(ByVal sender As Object, ByVal e As System.EventArgs)

            'Accessory Status '3411=Pass ;3412=Fail ;3413=Missing
            Dim btName As String
            Dim objAccessoryStatusWind As Gui.AccessoryStatus
            Dim strAction, strFailReason As String
            Dim iStatusID As Integer

            Dim R1, drNewRow As DataRow
            Dim BillCode_ID, Fail_ID, Repair_ID, Shift_ID, User_ID, EmpNo As Integer
            Dim Dbill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt As Decimal
            Dim Part_Number As String
            Dim objBilling As PSS.Data.Buisness.DeviceBilling
            Try

                Me.Enabled = False
                objBilling = New PSS.Data.Buisness.DeviceBilling()
                R1 = Me._dtAccessoriessList.Select("Billcode_ID = " & CInt(sender.tag.ToString))(0)
                Shift_ID = Core.ApplicationUser.IDShift
                User_ID = Core.ApplicationUser.IDuser
                EmpNo = Core.ApplicationUser.NumberEmp
                Fail_ID = 0
                Repair_ID = 0
                BillCode_ID = CInt(sender.tag.ToString)
                DBill_AvgCost = R1("PSPrice_AvgCost")
                DBill_StdCost = R1("PSPrice_StndCost")
                DBill_InvoiceAmt = 0
                Part_Number = R1("PSPrice_Number")
                Dbill_RegPartPrice = R1("PSPrice_StndCost")
                'Part_Number = Trim(sender.name.ToString)
                btName = Trim(sender.text.ToString)

                If CType(sender, Button).BackColor.ToString() = "Color [Orange]" Then
                    'FOR NOW DON'T COLLECT ACCESSORY STATUS.........
                    ''Failed or Remove Accessories
                    'objAccessoryStatusWind = New Gui.AccessoryStatus()
                    'objAccessoryStatusWind.ShowDialog()
                    'If objAccessoryStatusWind._booCancel = True Then
                    '    Exit Sub
                    'Else
                    '    iStatusID = objAccessoryStatusWind._iStatusDCodeID
                    '    strFailReason = objAccessoryStatusWind._strFailReason
                    'Me._objSyx.InsertRemoveAccessories(Me._Device_ID, BillCode_ID, Part_Number, Me._Screen_ID, user_ID, iStatusID, strFailReason)
                    Me._objSyx.InsertRemovetDeviceBill(Me._Device_ID, Dbill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, BillCode_ID, Part_Number, Fail_ID, Repair_ID, User_ID, False)
                    objBilling.InsertPartTransaction(Me._Device_ID, BillCode_ID, User_ID, EmpNo, Shift_ID, Part_Number, -1, _Screen_ID)

                    CType(sender, Button).BackColor = Color.LightGray
                    Status.Text = btName & " has been removed from accessories list..."
                    'End If
                Else
                    'Add New Accessory 
                    'If MessageBox.Show("The " & btName.ToUpper & " accessory is not available or missing during receiving. Are you sure you want to add the " & btName.ToUpper & " accessory ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then Exit Sub
                    iStatusID = 3411
                    'Me._objSyx.InsertRemoveAccessories(Me._Device_ID, BillCode_ID, Part_Number, Me._Screen_ID, User_ID, iStatusID)
                    Me._objSyx.InsertRemovetDeviceBill(Me._Device_ID, Dbill_RegPartPrice, DBill_AvgCost, DBill_StdCost, DBill_InvoiceAmt, BillCode_ID, Part_Number, Fail_ID, Repair_ID, User_ID, True)
                    objBilling.InsertPartTransaction(Me._Device_ID, BillCode_ID, User_ID, EmpNo, Shift_ID, Part_Number, 1, _Screen_ID)
                    CType(sender, Button).BackColor = Color.Orange
                    Status.Text = btName & " has been added to accessories list..."
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnAccessories_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                If Not IsNothing(objAccessoryStatusWind) Then
                    objAccessoryStatusWind.Dispose() : objAccessoryStatusWind = Nothing
                End If
                objBilling = Nothing
            End Try

        End Sub

        '*******************************************************************

        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click

            Me.ResetGlobals()

        End Sub

        '****************************************************************************************************
        Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
            Dim strSerial As String
            Dim dtDevice As DataTable

            Try
                strSerial = InputBox("Enter serial number.", "Re-Print Kitting Label").Trim.ToUpper
                If strSerial = "" Then
                    'Throw New Exception("Please enter serial number if you want to reprint label.")
                    Exit Sub
                End If

                Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                dtDevice = Me._objSyx.GetDeviceInfo(strSerial, False)
                If dtDevice.Rows.Count = 0 Then
                    MessageBox.Show("The serial#" & strSerial & " is not defined in system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                ElseIf IsDBNull(dtDevice.Rows(0)("Kitting_Date")) Then
                    MessageBox.Show("The serial#" & strSerial & " has not been Kitting completed yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me.txtSerial.Text = strSerial
                    Me._Device_ID = dtDevice.Rows(0)("Device_ID")
                    Me._Model_ID = dtDevice.Rows(0)("Model_ID")
                    Me.lblProduct.Text = dtDevice.Rows(0)("Prod_Desc")
                    Me.lblMfg.Text = dtDevice.Rows(0)("Manuf_Desc")
                    Me.lblModel.Text = dtDevice.Rows(0)("Model_Desc")
                    Me.LoadAccessoriesList()
                    Me.PrintKittingLabel()
                    Me.ResetGlobals()
                    Me.Status.Text = "The Kitting label for serial#" & strSerial & " has been re-print. Please scan another serial number..."
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReprint_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dtDevice)
                Me.Enabled = True : Cursor.Current = Cursors.Default
            End Try
        End Sub

        '****************************************************************************************************

#End Region

#Region "Function & Sub"

        '*****************************************************************

        Private Sub ResetGlobals()

            'Clear global variable

            Me._Device_ID = 0
            Me.lblProduct.Text = ""
            Me.lblMfg.Text = ""
            Me.lblModel.Text = ""

            Me.pnlAccessories.Controls.Clear()
            Me.btnComplete.Visible = False
            Me.tbAccessories.Visible = True
            Me.Status.Text = ""
            If ApplicationUser.GetPermission("OverrideAccessory") > 0 Then
                Me.btnOverrideComplete.Visible = True
            Else
                Me.btnOverrideComplete.Visible = False
            End If
            Me.txtSerial.Enabled = True
            Me.txtSerial.Text = ""
            Me.txtSerial.Focus()

        End Sub


        '*****************************************************************
        Private Sub CreateAccessoriesButtons()

            Dim drAccessories As DataRow
            Dim colLength As Integer = 4
            Dim btnAccessories() As Button
            Dim x As Integer = 0
            Me.pnlAccessories.Controls.Clear()

            Try
                colCount = 0
                pnlLeft = pnlAccessories.Left
                pnlWidth = tbAccessories.Width - 48
                ReDim btnAccessories(Me._dtAccessoriessList.Rows.Count)
                btnLeft = hBuffer
                btnTop = vBuffer

                For x = 0 To Me._dtAccessoriessList.Rows.Count - 1
                    drAccessories = Me._dtAccessoriessList.Rows(x)
                    btnAccessories(x) = New System.Windows.Forms.Button()
                    With btnAccessories(x)
                        .Text = drAccessories("BillCode_Desc")
                        .Name = drAccessories("PSPrice_Number")
                        .Size = New Size(btnWidth, btnHeight)
                        colCount += 1
                        .Location = New Point(btnLeft, btnTop)
                        .Visible = True
                        .BackColor = Color.LightGray
                        '  .Tag = drAccessories("psprice_id") '
                        .Tag = drAccessories("billcode_id") '
                        .Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        AddHandler .Click, AddressOf Me.btnAccessories_Click
                    End With


                    If colCount > colLength Then
                        btnLeft = btnLeft + btnWidth + 5
                        btnTop = vBuffer
                        colCount = 0
                    Else
                        btnTop = btnTop + btnHeight + 5
                    End If

                Next

                Me.pnlAccessories.Controls.AddRange(btnAccessories)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "CreateAccessoriesButtons", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                drAccessories = Nothing
                btnAccessories = Nothing

            End Try
        End Sub

        '******************************************************************
        Private Sub HighlightSelectedAccessories()
            'Highlight Accessories button that been selected in Receiving, Prestest, Tech screen

            Dim objPJoins As New PSS.Data.Production.Joins()
            Dim dtAssy As DataTable
            Dim iSavedCnt, iAllCnt As Integer
            Dim drAssy As DataRow
            Dim btnAssy As Button

            Try
                iSavedCnt = 0 : iAllCnt = 0
                'dtAssy  = objPJoins.GenericSelect("Select * From tDeviceAccessories WHERE Device_ID=" & Me._Device_ID & " And Status_ID=3411 ORDER BY DA_ID")
                dtAssy = Me._objSyx.gettdevicebill(Me._Device_ID)
                'Reset Backcolor
                For iAllCnt = 0 To Me.pnlAccessories.Controls.Count - 1
                    Me.pnlAccessories.Controls(iAllCnt).BackColor = Color.LightGray
                Next iAllCnt

                'Highlight the Accessoriess
                For iSavedCnt = 0 To dtAssy.Rows.Count - 1
                    drAssy = dtAssy.Rows(iSavedCnt)

                    'Accessories button panel
                    For iAllCnt = 0 To pnlAccessories.Controls.Count - 1
                        btnAssy = CType(pnlAccessories.Controls(iAllCnt), System.Windows.Forms.Button)
                        With btnAssy
                            If drAssy("billcode_ID") = .Tag Then
                                btnAssy.BackColor = Color.Orange
                                Exit For
                            End If

                        End With
                    Next iAllCnt

                Next iSavedCnt


            Catch ex As Exception
                MessageBox.Show(ex.ToString, "HighlightSelectedAccessoriess", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Buisness.Generic.DisposeDT(dtAssy)
                objPJoins = Nothing
                drAssy = Nothing

            End Try
        End Sub

        '*******************************************************************


        Private Sub ProcessSN()

            Dim dtDevice As DataTable
            Dim dr As DataRow

            Try

                Me.txtSerial.Text = Me.txtSerial.Text.Trim.ToUpper
                dtDevice = Me._objSyx.GetDeviceInfo(txtSerial.Text, True)

                If dtDevice.Rows.Count > 1 Then
                    MessageBox.Show("This serial#" & Me.txtSerial.Text & " existed twice in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                ElseIf dtDevice.Rows.Count = 0 Then
                    MessageBox.Show("The Serial#" & Me.txtSerial.Text & " is not found or has been shipped.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                    MessageBox.Show("This serial#" & Me.txtSerial.Text & " has not been billed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                    'ElseIf Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 1, "Functional", True, True) = False Then
                    '    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    '    Exit Sub
                ElseIf Generic.IsValidQCResults(dtDevice.Rows(0)("Device_ID"), 2, "FQA", False, True) = False Then
                    Me.Enabled = True : Me.txtSerial.SelectAll() : Me.txtSerial.Focus()
                    Exit Sub
                Else
                    Me.Enabled = False : Cursor.Current = Cursors.WaitCursor
                    Me._Device_ID = dtDevice.Rows(0)("Device_ID")
                    Me._Model_ID = dtDevice.Rows(0)("Model_ID")
                    Me.lblProduct.Text = dtDevice.Rows(0)("Prod_Desc")
                    Me.lblMfg.Text = dtDevice.Rows(0)("Manuf_Desc")
                    Me.lblModel.Text = dtDevice.Rows(0)("Model_Desc")
                    Me.LoadAccessoriesList()
                    Status.Text = "Toggle the 'Accessories' button to add/remove Accessories, then click on the 'Complete' button." & vbCrLf & ""
                    Me.btnComplete.Visible = True
                    Me.txtSerial.Enabled = False

                End If 'dtDevice
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "ProcessSN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)

            Finally

                Buisness.Generic.DisposeDT(dtDevice)
                Me.Enabled = True : Cursor.Current = Cursors.Default

            End Try
        End Sub

        '*************************************************************************************************************

        Private Sub PrintKittingLabel()

            Dim Missing_Accessories As String

            Try
                Missing_Accessories = Me.Get_Missing_Accessories()
                Me._objSyx.Label_KittingLabel(Me.lblMfg.Text, Me.lblModel.Text, Me.txtSerial.Text, Missing_Accessories)

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PrintKittingLabel", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally

            End Try
        End Sub

        '******************************************************************
        Private Function Get_Missing_Accessories() As String
            'Return missing accessories (button that not selected) 

            Dim iCnt As Integer = 0
            Dim btnAsy As Button
            Dim Miss_Assy As String = ""

            Try

                'If Me.pnlAccessories.Controls.Count > 0 Then

                '    For iCnt = 0 To Me.pnlAccessories.Controls.Count - 1
                '        btnAsy = CType(pnlAccessories.Controls(iCnt), System.Windows.Forms.Button)
                '        If btnAsy.BackColor.ToString() = "Color [LightGray]" Then
                '            'Miss_Assy += btnAsy.Name.ToString() + "' "
                '            Miss_Assy += btnAsy.Text + ", "
                '        End If

                '    Next iCnt

                '    If Miss_Assy.Trim.Length > 0 Then
                '        Miss_Assy = Miss_Assy.Substring(0, Len(Miss_Assy) - 2) 'Remove last semi-colon
                '        Miss_Assy = "Missing Accessory: " + Miss_Assy
                '    End If
                'Else
                '    'This device has no accessory
                '    Miss_Assy = ""
                'End If

                Return Miss_Assy

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Get_Missing_Accessories()", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally

            End Try
        End Function

        '*******************************************************************

#End Region


  
     
    End Class
End Namespace