Imports System
Imports System.GC
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.[Global]
Imports System.Drawing.Printing

Namespace Gui.DockReceive

    Public Class frmDockReceive
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
        Friend WithEvents lblPallet As System.Windows.Forms.Label
        Friend WithEvents txtPallet As System.Windows.Forms.TextBox
        Friend WithEvents txtPhysicalCount As System.Windows.Forms.TextBox
        Friend WithEvents lblPhysicalCount As System.Windows.Forms.Label
        Friend WithEvents btnProcess As System.Windows.Forms.Button
        Friend WithEvents lstNarrative As System.Windows.Forms.ListBox
        Friend WithEvents lblModel As System.Windows.Forms.Label
        Friend WithEvents lblManufacturer As System.Windows.Forms.Label
        Friend WithEvents lblProjectType As System.Windows.Forms.Label
        Friend WithEvents chkBoxes As System.Windows.Forms.CheckBox
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents cboCustomer As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboManufacturer As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboModel As PSS.Gui.Controls.ComboBox
        Friend WithEvents cboProjectType As PSS.Gui.Controls.ComboBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.lblPallet = New System.Windows.Forms.Label()
            Me.txtPallet = New System.Windows.Forms.TextBox()
            Me.txtPhysicalCount = New System.Windows.Forms.TextBox()
            Me.lblPhysicalCount = New System.Windows.Forms.Label()
            Me.btnProcess = New System.Windows.Forms.Button()
            Me.lstNarrative = New System.Windows.Forms.ListBox()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.lblManufacturer = New System.Windows.Forms.Label()
            Me.lblProjectType = New System.Windows.Forms.Label()
            Me.chkBoxes = New System.Windows.Forms.CheckBox()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.cboCustomer = New PSS.Gui.Controls.ComboBox()
            Me.cboManufacturer = New PSS.Gui.Controls.ComboBox()
            Me.cboModel = New PSS.Gui.Controls.ComboBox()
            Me.cboProjectType = New PSS.Gui.Controls.ComboBox()
            Me.SuspendLayout()
            '
            'lblPallet
            '
            Me.lblPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.lblPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPallet.ForeColor = System.Drawing.Color.White
            Me.lblPallet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPallet.Location = New System.Drawing.Point(8, 64)
            Me.lblPallet.Name = "lblPallet"
            Me.lblPallet.Size = New System.Drawing.Size(112, 16)
            Me.lblPallet.TabIndex = 0
            Me.lblPallet.Text = "Pallet Number : "
            Me.lblPallet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPallet
            '
            Me.txtPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPallet.Location = New System.Drawing.Point(128, 64)
            Me.txtPallet.Name = "txtPallet"
            Me.txtPallet.Size = New System.Drawing.Size(168, 22)
            Me.txtPallet.TabIndex = 2
            Me.txtPallet.Text = ""
            '
            'txtPhysicalCount
            '
            Me.txtPhysicalCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtPhysicalCount.Location = New System.Drawing.Point(128, 192)
            Me.txtPhysicalCount.Name = "txtPhysicalCount"
            Me.txtPhysicalCount.Size = New System.Drawing.Size(72, 22)
            Me.txtPhysicalCount.TabIndex = 6
            Me.txtPhysicalCount.Text = ""
            '
            'lblPhysicalCount
            '
            Me.lblPhysicalCount.BackColor = System.Drawing.Color.SteelBlue
            Me.lblPhysicalCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPhysicalCount.ForeColor = System.Drawing.Color.White
            Me.lblPhysicalCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblPhysicalCount.Location = New System.Drawing.Point(8, 192)
            Me.lblPhysicalCount.Name = "lblPhysicalCount"
            Me.lblPhysicalCount.Size = New System.Drawing.Size(112, 16)
            Me.lblPhysicalCount.TabIndex = 0
            Me.lblPhysicalCount.Text = "Physical Count : "
            Me.lblPhysicalCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnProcess
            '
            Me.btnProcess.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnProcess.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnProcess.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnProcess.ForeColor = System.Drawing.Color.Black
            Me.btnProcess.Location = New System.Drawing.Point(40, 268)
            Me.btnProcess.Name = "btnProcess"
            Me.btnProcess.Size = New System.Drawing.Size(256, 24)
            Me.btnProcess.TabIndex = 8
            Me.btnProcess.Text = "Run Dock Receive Process "
            '
            'lstNarrative
            '
            Me.lstNarrative.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right)
            Me.lstNarrative.BackColor = System.Drawing.Color.LightSteelBlue
            Me.lstNarrative.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lstNarrative.ForeColor = System.Drawing.Color.Black
            Me.lstNarrative.ItemHeight = 16
            Me.lstNarrative.Location = New System.Drawing.Point(320, 24)
            Me.lstNarrative.Name = "lstNarrative"
            Me.lstNarrative.Size = New System.Drawing.Size(344, 324)
            Me.lstNarrative.TabIndex = 0
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.SteelBlue
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.White
            Me.lblModel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblModel.Location = New System.Drawing.Point(56, 131)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(64, 16)
            Me.lblModel.TabIndex = 0
            Me.lblModel.Text = "Model : "
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblManufacturer
            '
            Me.lblManufacturer.BackColor = System.Drawing.Color.SteelBlue
            Me.lblManufacturer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblManufacturer.ForeColor = System.Drawing.Color.White
            Me.lblManufacturer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblManufacturer.Location = New System.Drawing.Point(16, 96)
            Me.lblManufacturer.Name = "lblManufacturer"
            Me.lblManufacturer.Size = New System.Drawing.Size(104, 16)
            Me.lblManufacturer.TabIndex = 0
            Me.lblManufacturer.Text = "Manufacturer : "
            Me.lblManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblProjectType
            '
            Me.lblProjectType.BackColor = System.Drawing.Color.SteelBlue
            Me.lblProjectType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblProjectType.ForeColor = System.Drawing.Color.White
            Me.lblProjectType.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblProjectType.Location = New System.Drawing.Point(24, 163)
            Me.lblProjectType.Name = "lblProjectType"
            Me.lblProjectType.Size = New System.Drawing.Size(96, 16)
            Me.lblProjectType.TabIndex = 0
            Me.lblProjectType.Text = "Project Type : "
            Me.lblProjectType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkBoxes
            '
            Me.chkBoxes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxes.ForeColor = System.Drawing.Color.White
            Me.chkBoxes.Location = New System.Drawing.Point(128, 216)
            Me.chkBoxes.Name = "chkBoxes"
            Me.chkBoxes.Size = New System.Drawing.Size(160, 16)
            Me.chkBoxes.TabIndex = 7
            Me.chkBoxes.Text = "NO Boxes With Pallet"
            '
            'btnClear
            '
            Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
            Me.btnClear.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.Black
            Me.btnClear.Location = New System.Drawing.Point(40, 308)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(256, 24)
            Me.btnClear.TabIndex = 9
            Me.btnClear.Text = "Clear Form "
            '
            'lblCustomer
            '
            Me.lblCustomer.BackColor = System.Drawing.Color.SteelBlue
            Me.lblCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCustomer.ForeColor = System.Drawing.Color.White
            Me.lblCustomer.Location = New System.Drawing.Point(16, 30)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(104, 16)
            Me.lblCustomer.TabIndex = 9
            Me.lblCustomer.Text = "Customer : "
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboCustomer
            '
            Me.cboCustomer.AutoComplete = True
            Me.cboCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me.cboCustomer.Location = New System.Drawing.Point(128, 30)
            Me.cboCustomer.Name = "cboCustomer"
            Me.cboCustomer.Size = New System.Drawing.Size(168, 24)
            Me.cboCustomer.TabIndex = 1
            '
            'cboManufacturer
            '
            Me.cboManufacturer.AutoComplete = True
            Me.cboManufacturer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me.cboManufacturer.Location = New System.Drawing.Point(128, 94)
            Me.cboManufacturer.Name = "cboManufacturer"
            Me.cboManufacturer.Size = New System.Drawing.Size(168, 24)
            Me.cboManufacturer.TabIndex = 3
            '
            'cboModel
            '
            Me.cboModel.AutoComplete = True
            Me.cboModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me.cboModel.Location = New System.Drawing.Point(128, 128)
            Me.cboModel.Name = "cboModel"
            Me.cboModel.Size = New System.Drawing.Size(168, 24)
            Me.cboModel.TabIndex = 4
            '
            'cboProjectType
            '
            Me.cboProjectType.AutoComplete = True
            Me.cboProjectType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
            Me.cboProjectType.Location = New System.Drawing.Point(128, 160)
            Me.cboProjectType.Name = "cboProjectType"
            Me.cboProjectType.Size = New System.Drawing.Size(168, 24)
            Me.cboProjectType.TabIndex = 5
            '
            'frmDockReceive
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(696, 381)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboProjectType, Me.cboModel, Me.cboManufacturer, Me.cboCustomer, Me.lblCustomer, Me.btnClear, Me.chkBoxes, Me.lblProjectType, Me.lblManufacturer, Me.lblModel, Me.lstNarrative, Me.btnProcess, Me.txtPhysicalCount, Me.lblPhysicalCount, Me.txtPallet, Me.lblPallet})
            Me.Name = "frmDockReceive"
            Me.Text = "frmDockReceive"
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private dtIMEI As New DataTable()
        Private xCount As Integer = 0
        Private r As DataRow
        Private vResponse As String
        Private strFile As String
        Private mManufacturer As String
        Private mModel As String
        Private mProjectType As String
        Private countFileDevices As Long
        Private arrDuplicates() As String
        Private strDirectory As String = "R:\ATCLE\ATCLE_DataFiles\"

        'lan add for GS
        Private iCust_id As Integer = 0
        Private strSNFieldName As String = ""
        Private strExcelSheetName As String = ""
        Private strTextToPrint As String = ""

        'Add color to control got focus
        'Private Shared ctl As Control
        Private Shared HighLightColor As Color = Color.Yellow
        Private Shared WindowColor As Color = Color.White
        Private Shared EnterHandler As New EventHandler(AddressOf Enter_Event)
        Private Shared LeaveHandler As New EventHandler(AddressOf Leave_Event)

        '*******************************************************************
        Private Shared Sub SetHandler(ByVal ctl As Control)
            AddHandler ctl.Enter, EnterHandler
            AddHandler ctl.Leave, LeaveHandler
            AddHandler ctl.Click, EnterHandler
        End Sub

        '*******************************************************************
        Private Shared Sub Enter_Event(ByVal sender As Object, ByVal e As EventArgs)
            Change_Color(sender, HighLightColor)
        End Sub

        '*******************************************************************
        Private Shared Sub Leave_Event(ByVal sender As Object, ByVal e As EventArgs)
            Change_Color(sender, WindowColor)
        End Sub

        '*******************************************************************
        Private Shared Sub Change_Color(ByVal sender As Object, ByVal color As Color)
            Dim Type As String = sender.GetType.Name.ToString

            Select Case Type
                Case "ComboBox"
                    CType(sender, ComboBox).BackColor = color
                Case "TextBox"
                    CType(sender, TextBox).BackColor = color
                Case Else
                    'no other types should be hightlighted.

            End Select
        End Sub

        '*******************************************************************
        Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
            Dim objWHR As New PSS.Data.Buisness.WarehouseReceive()
            Dim i As Integer = 0
            Dim strModelPrefix As String = ""
            Dim strPalletName As String = ""
            Dim objPrintdoc As PrintDocument
            Dim R1 As DataRow

            Try
                strTextToPrint = ""
                ''//Header Creation
                strTextToPrint &= "CUSTOMER: " & UCase(Trim(Me.cboCustomer.Text)) & vbCrLf & vbCrLf
                strTextToPrint &= "PALLET: " & UCase(Trim(Me.txtPallet.Text)) & vbCrLf & vbCrLf
                strTextToPrint &= "MANUFACTURER: " & UCase(Trim(cboManufacturer.Text)) & vbCrLf
                strTextToPrint &= "MODEL: " & UCase(Trim(cboModel.Text)) & vbCrLf
                strTextToPrint &= "PROJECT TYPE: " & UCase(Trim(cboProjectType.Text)) & vbCrLf & vbCrLf
                strTextToPrint &= "COMMENT:____________________________________________________" & vbCrLf
                strTextToPrint &= "COMPLETED BY:_______________________________________________" & vbCrLf & vbCrLf

                Me.lstNarrative.Items.Clear()
                System.Windows.Forms.Application.DoEvents()

                Dim vString As String
                Dim vBoolean As Boolean

                '*************************
                'Verifying customer
                '*************************
                addNarrativeItem("Verifying customer.", strTextToPrint)
                vString = verifyCustomer()
                If vString <> "" Then
                    addNarrativeItem(vString, strTextToPrint)
                    Exit Sub
                End If
                addNarrativeItem("DONE", strTextToPrint)


                '*****************************
                'Verifying Pallet Data Name
                '*****************************
                addNarrativeItem("Verifying Pallet Data Name.", strTextToPrint)
                vString = verifyRMA()
                If vString <> "" Then
                    addNarrativeItem(vString, strTextToPrint)
                    Exit Sub
                End If
                addNarrativeItem("DONE", strTextToPrint)

                '*********************************
                'Verifying Manufacturer Data Name
                '*********************************
                addNarrativeItem("Verifying Manufacturer Data Name.", strTextToPrint)
                vString = verifyManufacturer()
                If vString <> "" Then
                    addNarrativeItem(vString, strTextToPrint)
                    Exit Sub
                End If
                addNarrativeItem("DONE", strTextToPrint)

                '*********************************
                'Verifying Model Data Name
                '*********************************
                addNarrativeItem("Verifying Model Data Name.", strTextToPrint)
                vString = verifyModel()
                If vString <> "" Then
                    addNarrativeItem(vString, strTextToPrint)
                    Exit Sub
                End If
                If Len(Trim(mModel)) < 1 Then
                    addNarrativeItem("Model is not defined.", strTextToPrint)
                    Exit Sub
                End If
                addNarrativeItem("DONE", strTextToPrint)

                '************************
                'Verifying Project Type
                '************************
                addNarrativeItem("Verifying Project Type Data Name.", strTextToPrint)
                vString = verifyProjectType()
                If vString <> "" Then
                    addNarrativeItem(vString, strTextToPrint)
                    Exit Sub
                End If
                addNarrativeItem("DONE", strTextToPrint)

                '**************************
                'Verifying Physical Count
                '**************************
                addNarrativeItem("Verifying Physical Count Number.", strTextToPrint)
                Try
                    If CInt(txtPhysicalCount.Text) < 0 Then
                        addNarrativeItem("Count Must Be Positive", strTextToPrint)
                        Exit Sub
                    End If
                Catch ex As Exception
                    addNarrativeItem("Count Is Not Defined", strTextToPrint)
                    Exit Sub
                End Try
                addNarrativeItem("DONE", strTextToPrint)

                '********************************
                'Verifying Existence Of Data File
                '********************************
                addNarrativeItem("Verifying Existence Of Data File", strTextToPrint)
                vBoolean = verifyDataFileExists()
                If vBoolean = False Then
                    addNarrativeItem("The Data File Could Not Be Located.", strTextToPrint)
                    Exit Sub
                End If
                addNarrativeItem("DONE", strTextToPrint)

                '**************************************
                'Format Excel File (lan add 10/15/2006)
                '**************************************
                If Me.cboCustomer.SelectedValue = 2219 Then
                    strModelPrefix = objWHR.GetModelMotosku(Me.cboModel.SelectedValue)
                    If strModelPrefix = "" Then
                        MessageBox.Show("'Model Prefix' for this model is missing in the system.", "Validate Model MotoSku", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        addNarrativeItem("THE LOAD IS TERMINATED - RECORDS HAVE NOT BEEN LOADED INTO THE PSS.NET SYSTEM.", strTextToPrint)
                        Exit Sub
                    End If
                    objWHR = Nothing
                End If

                Try
                    i = FormatExcel(Me.cboCustomer.SelectedValue, strModelPrefix, strPalletName)
                Catch ex As Exception
                    MessageBox.Show(ex.ToString, "Validate Lot Column in Excel File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    addNarrativeItem("THE LOAD IS TERMINATED - RECORDS HAVE NOT BEEN LOADED INTO THE PSS.NET SYSTEM.", strTextToPrint)
                    Exit Sub
                End Try

                '**********************
                If Not IsNothing(Me.dtIMEI) Then
                    Me.dtIMEI.Dispose()
                    Me.dtIMEI = Nothing
                End If
                dtIMEI = New DataTable()
                dtIMEI = getIMEI()

                '*******************************************************
                'validate data format in Excel file (lan add 10/12/2006)
                '*******************************************************
                If dtIMEI.Rows.Count = 0 Then
                    MessageBox.Show("The Excel file either contain no data or incorrect format.", "Validate Excel File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    addNarrativeItem("THE LOAD IS TERMINATED - RECORDS HAVE NOT BEEN LOADED INTO THE PSS.NET SYSTEM.", strTextToPrint)
                    Exit Sub
                End If


                '*******************************************************
                'validate BinLocation in Excel file (lan added on 02/23/2007)
                '*******************************************************
                If Me.cboCustomer.SelectedValue = 2019 Then 'ATCLE
                    If UCase(Trim(dtIMEI.Rows(0)("Bin Location"))) <> UCase(Trim(Me.txtPallet.Text)) Then
                        MessageBox.Show("The 'Bin Location' in the excel file does not match with the file name. Please edit the excel file and try again.", "Validate Excel File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                        addNarrativeItem("THE LOAD IS TERMINATED - RECORDS HAVE NOT BEEN LOADED INTO THE PSS.NET SYSTEM.", strTextToPrint)
                        Exit Sub
                    End If

                    'Added by Lan 08/31/2007. Check for ATT model.
                    If InStr(1, UCase(Trim(dtIMEI.Rows(0)("Load Number"))), "ATT") <> 0 Then
                        If InStr(1, UCase(Me.cboModel.SelectedItem(Me.cboModel.DisplayMember)), "ATT") = 0 Then
                            MessageBox.Show("This is ATT pallet and selected model is not ATT model. Please verify that.", "Validate Excel File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            addNarrativeItem("THE LOAD IS TERMINATED - RECORDS HAVE NOT BEEN LOADED INTO THE PSS.NET SYSTEM.", strTextToPrint)
                            Exit Sub
                        End If
                    End If
                    For Each R1 In dtIMEI.Rows
                        If IsDBNull(dtIMEI.Rows(0)("Part Client ID")) Then
                            MessageBox.Show("Part Client ID can't be empty.", "Validate Excel File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                            addNarrativeItem("THE LOAD IS TERMINATED - RECORDS HAVE NOT BEEN LOADED INTO THE PSS.NET SYSTEM.", strTextToPrint)
                            Exit Sub
                        End If
                    Next R1
                End If

                '*****************************
                'Checking For Duplicates
                '*****************************
                addNarrativeItem("Checking For Duplicates", strTextToPrint)
                System.Windows.Forms.Application.DoEvents()
                vString = checkDuplicates(dtIMEI, strTextToPrint)
                If vString <> "" Then
                End If
                addNarrativeItem("DONE", strTextToPrint)

                '*************************************
                'Validate physical count vs Fiele qty
                '*************************************
                countFileDevices = getFileDeviceCount(dtIMEI)
                addNarrativeItem("Getting Offical Count of Devices From File", strTextToPrint)
                If countFileDevices < CInt(txtPhysicalCount.Text) Then
                    addNarrativeItem("Devices on pallet is greater than devices in file", strTextToPrint)
                    addNarrativeItem("File: " & countFileDevices & " / Physical: " & txtPhysicalCount.Text, strTextToPrint)
                    addNarrativeItem("DIFFERENCE: " & Math.Abs(countFileDevices - CInt(txtPhysicalCount.Text)), strTextToPrint)
                ElseIf countFileDevices > CInt(txtPhysicalCount.Text) Then
                    addNarrativeItem("Devices on pallet is less than devices in file", strTextToPrint)
                    addNarrativeItem("File: " & countFileDevices & " / Physical: " & txtPhysicalCount.Text, strTextToPrint)
                    addNarrativeItem("DIFFERENCE: " & Math.Abs(countFileDevices - CInt(txtPhysicalCount.Text)), strTextToPrint)
                ElseIf countFileDevices = CInt(txtPhysicalCount.Text) Then
                    '//OK
                Else
                    addNarrativeItem("Error Comparing Physical Count to File Count of Devices", strTextToPrint)
                    addNarrativeItem("File: " & countFileDevices & " / Physical: " & txtPhysicalCount.Text, strTextToPrint)
                End If
                'addNarrativeItem("DONE", oSheet, lineNumber)
                addNarrativeItem("DONE", strTextToPrint)

                '*************************************
                '//Load data into database
                '*************************************
                vString = "XXX"
                System.Windows.Forms.Application.DoEvents()
                If vString <> "" Then
                    addNarrativeItem("Loading Data Into Database", strTextToPrint)

                    Dim objWH As New PSS.Data.Buisness.Warehouse()
                    Dim strFileName As String = Trim(txtPallet.Text) & ".xls"
                    Dim strFilePath As String = strDirectory & strFileName
                    Dim chkNoBox As Integer
                    If Me.chkBoxes.Checked = True Then chkNoBox = 1
                    If Me.chkBoxes.Checked = False Then chkNoBox = 0

                    Dim intLoad As Integer = 0

                    Try
                        intLoad = objWH.LoadFileDock(txtPallet.Text, strFilePath, _
                                             chkNoBox, txtPhysicalCount.Text, _
                                             countFileDevices, arrDuplicates, _
                                             cboModel.SelectedValue, _
                                             Trim(cboProjectType.Text.ToString), _
                                             Me.cboCustomer.SelectedValue, _
                                             dtIMEI) 'lan add Cust_id

                    Catch ex As Exception
                        MessageBox.Show(ex.ToString, "Load Excel File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    End Try

                    If intLoad = -1 Then
                        addNarrativeItem("LOAD IS TERMINATED. PALLET " & txtPallet.Text & " WAS ALREADY LOADED ONCE AND PROCESSED IN THE SYSTEM.", strTextToPrint)
                    ElseIf intLoad = -9 Then
                        addNarrativeItem("LOAD IS COMPLETED - RECORDS HAVE BEEN LOADED INTO THE PSS.NET SYSTEM.", strTextToPrint)
                    ElseIf intLoad = 0 Then
                        addNarrativeItem("LOAD IS TERMINATED - RECORDS HAVE NOT BEEN LOADED IN THE PSS.NET SYSTEM.", strTextToPrint)
                    Else
                        addNarrativeItem("LOAD IS COMPLETED - RECORDS HAVE BEEN LOADED INTO THE PSS.NET SYSTEM.", strTextToPrint)
                    End If
                Else
                    '//Data Not Loaded
                    addNarrativeItem("THE LOAD COULD NOT BE PERFORMED. PLEASE CORRECT DUPLICATES BEFORE LOADING.", strTextToPrint)
                End If

                ''*************************
                ''Print report
                ''*************************
                'Try
                '    objPrintdoc = New PrintDocument()
                '    AddHandler objPrintdoc.PrintPage, AddressOf Me.PrintText
                '    objPrintdoc.Print()
                'Catch ex As Exception
                '    MsgBox("There is a problem printing report.", MsgBoxStyle.Critical, "Print Reprot")
                'End Try
                ''*************************

                System.Windows.Forms.Application.DoEvents()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Dock Receive", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                R1 = Nothing
                objWHR = Nothing
                If Not IsNothing(objPrintdoc) Then
                    objPrintdoc.Dispose()
                    objPrintdoc = Nothing
                End If
            End Try
        End Sub

        '***************************************************************************
        Private Sub PrintText(ByVal sender As Object, _
                              ByVal ev As PrintPageEventArgs)
            ev.Graphics.DrawString(Me.strTextToPrint, New Font("Arial", 11, FontStyle.Regular), Brushes.Black, 120, 120)
            ev.HasMorePages = False
            Me.strTextToPrint = ""
        End Sub

        '***************************************************************************
        Private Sub addNarrativeItem(ByVal txtNarrative As String, ByRef strToPrintData As String)
            Me.lstNarrative.Items.Add(txtNarrative)
            System.Windows.Forms.Application.DoEvents()

            strToPrintData &= txtNarrative & vbCrLf
        End Sub

        '***************************************************************************
        Private Sub addNarrativeItemNumber(ByVal txtNarrative As String, ByRef strToPrintData As String)
            Me.lstNarrative.Items.Add(txtNarrative)
            System.Windows.Forms.Application.DoEvents()

            strToPrintData &= txtNarrative & vbCrLf
        End Sub

        '***************************************************************************
        Private Function verifyDataFileExists() As Boolean
            Try
                '//Assigned location of file
                'strFile = Dir("R:\ATCLE\ATCLE_DataFiles\" & Trim(txtPallet.Text) & ".xls")
                strFile = Dir(strDirectory & Trim(txtPallet.Text) & ".xls")   'lan

                If strFile = "" Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                strFile = ""
                Return False
            End Try
        End Function

        '***************************************************************************
        Private Function verifyRMA() As String
            '//check for data intextbox
            If Len(Trim(Me.txtPallet.Text)) < 1 Then
                Return "No pallet value is defined."
            End If
            Return ""
        End Function

        '***************************************************************************
        'lan add Customer 10/12/2006
        Private Function verifyCustomer() As String
            '//check for data intextbox
            Try
                If Me.cboCustomer.SelectedValue < 1 Then
                    Return "No customer is defined."
                End If
                Return ""
            Catch ex As Exception
                Return "No customer is defined."
            End Try
        End Function

        '***************************************************************************
        Private Function verifyManufacturer() As String
            '//check for data intextbox
            Try
                If cboManufacturer.SelectedValue < 1 Then
                    Return "No manufacturer is defined."
                End If
                Return ""
            Catch ex As Exception
                Return "No manufacturer is defined."
            End Try
        End Function

        '***************************************************************************
        Private Function verifyModel() As String
            '//check for data intextbox
            Try
                If Len(Trim(cboModel.Text)) < 1 Then
                    Return "No model is defined."
                End If
                Return ""
            Catch ex As Exception
                Return "No model is defined."
            End Try
        End Function

        '***************************************************************************
        Private Function verifyProjectType() As String
            '//check for data intextbox
            Try
                If cboProjectType.SelectedValue < 1 Then
                    Return "No project type is defined."
                End If
                Return ""
            Catch ex As Exception
                Return "No project type is defined."
            End Try
        End Function

        '***************************************************************************
        Private Function getIMEI() As DataTable
            Dim objExcel As Object = Nothing    ' Excel application
            Dim objBook As Object = Nothing     ' Excel workbook
            Dim objSheet As Object = Nothing    ' Excel Worksheet
            Dim sConnectionstring As String
            Dim objConn As New OleDbConnection()
            Dim objCmdSelect As New OleDbCommand()
            Dim objAdapter1 As New OleDbDataAdapter()
            Dim objDataset1 As New DataSet()
            Dim dt As New DataTable()

            Try
                '//Create a datatable of all values from the assigned file
                'sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=R:\ATCLE\ATCLE_DataFiles\" & strFile & ";Extended Properties=Excel 8.0;"
                sConnectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strDirectory & strFile & ";Extended Properties=Excel 8.0;"
                objConn.ConnectionString = sConnectionstring
                objConn.Open()

                'objCmdSelect.CommandText = ("SELECT * FROM [" & strExcelSheetName & "$] ORDER BY [" & strSNFieldName & "]")
                objCmdSelect.CommandText = ("SELECT * FROM [" & Me.strExcelSheetName & "$] WHERE [" & Me.strSNFieldName & "] is not null ORDER BY [" & strSNFieldName & "]")
                'objCmdSelect.CommandText = ("SELECT [Piece Identifier] FROM [McHugh Export$] ORDER BY [Piece Identifier]")

                objCmdSelect.Connection = objConn
                objAdapter1.SelectCommand = objCmdSelect
                objAdapter1.Fill(dt)
                objAdapter1.Fill(objDataset1, "XLData")
                'objConn.Close()
                Return dt
            Catch ex As Exception
                MsgBox(ex.ToString)
                Return dt
            Finally
                '*************************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close(False)
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If

                If Not IsNothing(objConn) Then
                    objConn.Close()
                    objConn.Dispose()
                    objConn = Nothing
                End If
                If Not IsNothing(objCmdSelect) Then
                    objCmdSelect.Dispose()
                    objCmdSelect = Nothing
                End If
                If Not IsNothing(objAdapter1) Then
                    objAdapter1.Dispose()
                    objAdapter1 = Nothing
                End If
                If Not IsNothing(objDataset1) Then
                    objDataset1.Dispose()
                    objDataset1 = Nothing
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '***************************************************************************
        Private Function checkDuplicates(ByVal dt As DataTable, _
                                 ByRef strToPrintData As String) As String

            Dim strDuplicates As String = ""
            Dim x As Integer = 0
            Dim oldValue As String
            Dim r As DataRow
            Dim dupCount As Integer = 0

            If Me.cboCustomer.SelectedValue = 2249 Then
                Exit Function
            End If

            '//initial value
            r = dt.Rows(0)
            'oldValue = Trim(r("Piece Identifier"))
            oldValue = UCase(Trim(r(strSNFieldName))) 'lan add Ucase

            For x = 1 To dt.Rows.Count - 1
                r = dt.Rows(x)
                'If Trim(r("Piece Identifier")) = oldValue Then 'Craig
                If oldValue <> "NA" And oldValue <> "" And Trim(r(strSNFieldName)) = oldValue Then      'lan change
                    '//Duplicate has occurred
                    If strDuplicates = "" Then
                        addNarrativeItem("DUPLICATE DEVICES:", strToPrintData)
                        strDuplicates = "DUPLICATES"
                    End If
                    addNarrativeItemNumber("    " & r(strSNFieldName), strToPrintData)
                    dupCount += 1
                End If
                '//Move to next record
                '//Assign new old value
                'oldValue = r("Piece Identifier")
                oldValue = UCase(Trim(r(strSNFieldName))) 'lan add UCase
            Next
            If Len(Trim(strDuplicates)) > 0 Then
                strDuplicates = "DUPLICATE DEVICES:" & vbCrLf & strDuplicates
            End If

            '//Make Array
            If dupCount > 0 Then
                ReDim Preserve arrDuplicates(dupCount - 1)
                Dim newCount As Integer = 0
                r = dt.Rows(0)
                'oldValue = Trim(r("Piece Identifier"))
                oldValue = UCase(Trim(r(strSNFieldName))) 'lan add Ucase

                For x = 1 To dt.Rows.Count - 1
                    r = dt.Rows(x)

                    'If Trim(r("Piece Identifier")) = oldValue Then                     'Craig
                    If oldValue <> "NA" And oldValue <> "" And Trim(r(strSNFieldName)) = oldValue Then     'lan change
                        '//Duplicate has occurred
                        'arrDuplicates(newCount) = r("Piece Identifier")
                        arrDuplicates(newCount) = r(strSNFieldName)
                        newCount += 1
                    End If
                    '//Move to next record
                    '//Assign new old value
                    'oldValue = r("Piece Identifier")
                    oldValue = UCase(r(strSNFieldName)) 'lan add Ucase
                Next
            End If

            Return strDuplicates
        End Function


        Private dtSource As PSS.Data.production.Joins
        Private dtManuf As DataTable
        Private dtModel As DataTable
        Private dtProjectType As DataTable

        '***************************************************************************
        'lan add
        Private Sub PopulateCustomers()
            Dim strSQL As String
            Dim dt1 As DataTable

            Try
                strSQL = "SELECT Cust_ID, Cust_Name1 FROM tcustomer WHERE Cust_id  IN (2019,2219, 2249)ORDER BY cust_name1;"
                dt1 = dtSource.OrderEntrySelect(strSQL)
                'dt1.LoadDataRow(New Object() {"0", ""}, False)
                dt1.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
                'dt1.DefaultView.Sort = "Cust_Name1"
                Me.cboCustomer.DataSource = dt1.DefaultView
                Me.cboCustomer.DisplayMember = dt1.Columns("Cust_Name1").ToString
                Me.cboCustomer.ValueMember = dt1.Columns("Cust_ID").ToString

                Me.cboCustomer.Text = ""
            Catch ex As Exception
                MessageBox.Show("frmDockReceive.PopulateCustomers(): " & ex.ToString, "Populate Customers", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '***************************************************************************
        Private Sub populateManufacturers()
            Dim strSQL As String
            strSQL = "SELECT Manuf_ID, Manuf_Desc FROM lmanuf ORDER BY Manuf_Desc"
            dtManuf = dtSource.OrderEntrySelect(strSQL)
            dtManuf.LoadDataRow(New Object() {"0", ""}, False)
            dtManuf.DefaultView.Sort = "Manuf_Desc"
            cboManufacturer.DataSource = dtManuf
            cboManufacturer.DisplayMember = dtManuf.Columns("Manuf_Desc").ToString
            cboManufacturer.ValueMember = dtManuf.Columns("Manuf_ID").ToString

            cboManufacturer.Text = ""
        End Sub

        '***************************************************************************
        Private Sub populateModels()
            Try
                Dim strSQL As String
                strSQL = "SELECT * FROM tmodel WHERE Manuf_ID = " & mManufacturer & " AND Prod_ID in (2,5) ORDER BY Model_Desc"
                dtModel = dtSource.OrderEntrySelect(strSQL)
                cboModel.DataSource = dtModel
                cboModel.DisplayMember = dtModel.Columns("Model_Desc").ToString
                cboModel.ValueMember = dtModel.Columns("Model_ID").ToString
                cboModel.Text = ""
            Catch ex As Exception
            End Try
        End Sub

        '***************************************************************************
        Private Sub populateProjectType()
            Try
                Dim strSQL As String
                strSQL = "SELECT pt_id, pt_desc FROM lprojecttype WHERE prod_id = 2"
                dtProjectType = dtSource.OrderEntrySelect(strSQL)
                dtProjectType.LoadDataRow(New Object() {"0", ""}, False)
                dtProjectType.DefaultView.Sort = "pt_desc"
                cboProjectType.DataSource = dtProjectType
                cboProjectType.DisplayMember = dtProjectType.Columns("pt_desc").ToString
                cboProjectType.ValueMember = dtProjectType.Columns("pt_ID").ToString
                cboProjectType.Text = ""
            Catch ex As Exception
            End Try
        End Sub

        '***************************************************************************
        Private Sub frmDockReceive_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Handlers to highlight in custom colors
            SetHandler(Me.cboCustomer)
            SetHandler(Me.cboManufacturer)
            SetHandler(Me.cboModel)
            SetHandler(Me.cboProjectType)
            SetHandler(Me.txtPallet)
            SetHandler(Me.txtPhysicalCount)

            populateManufacturers()
            populateProjectType()
            PopulateCustomers()
            Me.cboCustomer.SelectedValue = 0
            Me.cboCustomer.Focus()
        End Sub

        '***************************************************************************
        Private Function getFileDeviceCount(ByVal dt As DataTable) As Long
            Dim xCount As Integer = 0
            Dim x As Integer
            Dim r As DataRow

            For xCount = 0 To dt.Rows.Count - 1
                r = dt.Rows(x)
                'If Len(Trim(r("Piece Identifier"))) > 0 Then
                If Len(Trim(r(strSNFieldName))) > 0 Then
                    x += 1
                End If
            Next

            System.Windows.Forms.Application.DoEvents()
            Return x
        End Function

        '***************************************************************************
        Private Sub clearForm()
            Me.txtPallet.Text = ""
            Me.cboManufacturer.Text = ""
            Me.cboModel.Text = ""
            Me.cboProjectType.Text = ""
            Me.txtPhysicalCount.Text = ""
            Me.chkBoxes.Checked = False
            'lan add
            '---------
            Me.cboManufacturer.SelectedValue = 0
            Me.cboModel.SelectedValue = 0
            Me.cboProjectType.SelectedValue = 0
            Me.cboCustomer.SelectedValue = 0
            Me.cboCustomer.Focus()
            '---------
        End Sub

        '***************************************************************************
        Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
            clearForm()
        End Sub

        '***************************************************************************
        Private Sub cboManufacturer_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboManufacturer.SelectionChangeCommitted
            Try
                mManufacturer = cboManufacturer.SelectedValue
                If mManufacturer > 0 Then
                    populateModels()
                    Me.cboModel.Focus()
                End If
            Catch EX As Exception
            End Try
        End Sub

        '***************************************************************************
        Private Sub cboModel_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboModel.SelectionChangeCommitted
            Try
                mModel = cboModel.SelectedValue
                If CInt(mModel) > 0 Then
                    Me.cboProjectType.Focus()
                End If
            Catch EX As Exception
            End Try
        End Sub

        '***************************************************************************
        Private Sub cboProjectType_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProjectType.SelectionChangeCommitted
            Try
                If Me.cboProjectType.SelectedValue > 0 Then
                    Me.txtPhysicalCount.Focus()
                End If
            Catch ex As Exception
            End Try
        End Sub

        '*******************************************************
        'Lan add this function to format Excel file 10/25/2006
        '*******************************************************
        Private Function FormatExcel(ByVal iCust_ID As Integer, _
                                     ByVal strModelPrefix As String, _
                                     ByRef strPalletName As String) As Integer
            Dim objExcel As Excel.Application    ' Excel application
            Dim objBook As Excel.Workbook     ' Excel workbook
            Dim objSheet As Excel.Worksheet    ' Excel Worksheet
            Dim i As Integer = 0
            Dim j As Integer = 1
            Dim k As Integer = 0

            Try
                If iCust_ID = 2249 Then
                    Exit Function
                End If

                'Instantiate the excel related objects
                objExcel = New Excel.Application()      'Starts the Excel Session
                objExcel.Workbooks.Open(strDirectory & strFile)     'Add a Workbook
                objExcel.Application.Visible = False                'Make this false while going live
                objExcel.Application.DisplayAlerts = False
                'objSheet = objBook.Worksheets.Item(1)              'Select a Sheet 1 for this
                objSheet = objExcel.Worksheets(1)

                '*****************************************
                'Format cells Data Type
                '*****************************************
                objSheet.name = Me.strExcelSheetName  'Rename the selected sheet to Sheet 1

                If iCust_ID = 2219 Then

                    objExcel.Sheets("Sheet 1").Select()             'Select Sheet 1
                    objExcel.Columns("A:A").Select()                'Select column A 
                    objExcel.Selection.NumberFormat = "@"           'Assign Text Format to column A

                    While k <= 10
                        i += 1
                        If Trim(objSheet.Range("B" & i).FormulaR1C1) = "" And Trim(objSheet.Range("C" & i).FormulaR1C1) = "" And Trim(objSheet.Range("D" & i).FormulaR1C1) = "" Then
                            Exit While
                        End If
                        'MessageBox.Show(objSheet.Range("A" & i).FormulaR1C1)
                        If Trim(objSheet.Range("A" & i).FormulaR1C1) = "NA" Or Trim(objSheet.Range("A" & i).FormulaR1C1) = "na" Or Trim(objSheet.Range("A" & i).FormulaR1C1) = "n/a" Or Trim(objSheet.Range("A" & i).FormulaR1C1) = "N/A" Or Trim(objSheet.Range("A" & i).FormulaR1C1) = "" Then
                            objSheet.Range("A" & i).FormulaR1C1 = "NA" & j
                            j += 1
                        Else
                            objSheet.Range("A" & i).FormulaR1C1 = objSheet.Range("A" & i).FormulaR1C1
                        End If

                        '******************************
                        'Added by Lan 06/14/2007
                        ' Add prefix to lot number column
                        '******************************
                        If Trim(objSheet.Range("B" & i).FormulaR1C1) <> "Lot" Then
                            If Not IsNumeric(Trim(objSheet.Range("B" & i).FormulaR1C1)) Then
                                Throw New Exception("Excel file line #" & i & " contains non-numeric 'Lot Number'. Please edit the file and reload.")
                            End If
                            objSheet.Range("B" & i).FormulaR1C1 = strModelPrefix & "_" & objSheet.Range("B" & i).FormulaR1C1

                            'assign pallet name for report
                            If strPalletName = "" Then
                                strPalletName = objSheet.Range("B" & i).FormulaR1C1 & objSheet.Range("C" & i).FormulaR1C1
                            End If
                        End If
                        '******************************
                    End While
                    i = -1
                Else
                    i = 1
                End If

                'Save the excel file
                objExcel.ActiveWorkbook.Save()
                objExcel.Workbooks.close()
                '*************************************************
                Return i
            Catch ex As Exception
                Throw ex
            Finally
                '***********************************
                'Excel clean up
                If Not IsNothing(objSheet) Then
                    objSheet = Nothing
                    NAR(objSheet)
                End If
                If Not IsNothing(objBook) Then
                    objBook.Close()
                    objBook = Nothing
                    NAR(objBook)
                End If
                If Not IsNothing(objExcel) Then
                    objExcel.Quit()
                    objExcel = Nothing
                    NAR(objExcel)
                End If
                GC.Collect()
                GC.WaitForPendingFinalizers()
                GC.Collect()
                GC.WaitForPendingFinalizers()
            End Try
        End Function

        '***************************************************************************
        'Lan add this on 10/25/2006
        '***************************************************************************
        Private Sub NAR(ByVal o As Object)
            Try
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
            Catch
            Finally
                o = Nothing
            End Try
        End Sub

        '***************************************************************************
        'lan add for Game stop 10/11/2006
        Private Sub cboCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCustomer.SelectionChangeCommitted
            iCust_id = Me.cboCustomer.SelectedValue
            If Me.cboCustomer.SelectedValue > 0 Then
                Select Case Me.cboCustomer.SelectedValue
                    Case 2219
                        Me.strDirectory = "P:\Dept\Game Stop\Data Files\"
                        Me.strSNFieldName = "Serial Number"
                        Me.strExcelSheetName = "Sheet 1"
                        Me.chkBoxes.Enabled = True
                        Me.chkBoxes.Checked = True
                    Case 2019
                        Me.strDirectory = "R:\ATCLE\ATCLE_DataFiles\"
                        Me.strSNFieldName = "Piece Identifier"
                        Me.strExcelSheetName = "McHugh Export"
                        Me.chkBoxes.Checked = False
                        Me.chkBoxes.Enabled = False
                    Case 2249
                        Me.strDirectory = "R:\HTC\HTC_DataFiles\"
                        Me.strSNFieldName = "IMEI"
                        Me.strExcelSheetName = "Sheet1"
                        Me.chkBoxes.Checked = False
                        Me.chkBoxes.Enabled = False
                    Case Else
                        strDirectory = ""
                        strSNFieldName = ""
                        strExcelSheetName = ""
                End Select
                Me.txtPallet.Focus()
            End If
        End Sub

        '***************************************************************************

    End Class

End Namespace

