Imports System.IO

Public Class frmGamestopRec
    Inherits System.Windows.Forms.Form
    'Private objGameStop As PSS.Data.Buisness.GameStop

    Private strMachine As String = System.Net.Dns.GetHostName
    Private strUserName As String = PSS.Core.Global.ApplicationUser.User
    Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
    Private iGroup_ID As Integer = 0
    Private strGroup As String = ""

    Private iProcessType As Integer = 0
    Private iModelID As Integer = 0
    Private iSkuID As Integer = 0
    Private iLocID As Integer = 0
    Private strWO As String = ""
    Private iWOID As Integer = 0
    Private dtExcelData As DataTable

    

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        '  objGameStop = New PSS.Data.Buisness.GameStop()
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
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents PanelRec As System.Windows.Forms.Panel
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lstSN As System.Windows.Forms.ListBox
    Friend WithEvents cmdReceive As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioScrap As System.Windows.Forms.RadioButton
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents txtWO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbModel As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbLocation As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PanelInfo As System.Windows.Forms.Panel
    Friend WithEvents lblSku As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmdClearScreen As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteWO As System.Windows.Forms.Button
    Friend WithEvents lblWOCount As System.Windows.Forms.Label
    Friend WithEvents RadioBad As System.Windows.Forms.RadioButton
    Friend WithEvents RadioGood As System.Windows.Forms.RadioButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.PanelRec = New System.Windows.Forms.Panel()
        Me.lblWOCount = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lstSN = New System.Windows.Forms.ListBox()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.cmdReceive = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioBad = New System.Windows.Forms.RadioButton()
        Me.RadioGood = New System.Windows.Forms.RadioButton()
        Me.RadioScrap = New System.Windows.Forms.RadioButton()
        Me.PanelInfo = New System.Windows.Forms.Panel()
        Me.lblSku = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbLocation = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbModel = New PSS.Gui.Controls.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtWO = New System.Windows.Forms.TextBox()
        Me.cmdClearScreen = New System.Windows.Forms.Button()
        Me.cmdDeleteWO = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.PanelRec.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Black
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Yellow
        Me.lbl.Location = New System.Drawing.Point(1, 1)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(327, 87)
        Me.lbl.TabIndex = 8
        Me.lbl.Text = "GAME STOP RECEIVING"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblLineSide, Me.lblMachine, Me.lblGroup, Me.lblLine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Location = New System.Drawing.Point(329, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(416, 87)
        Me.Panel2.TabIndex = 88
        '
        'lblLineSide
        '
        Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
        Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
        Me.lblLineSide.Location = New System.Drawing.Point(16, 40)
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.Size = New System.Drawing.Size(208, 16)
        Me.lblLineSide.TabIndex = 93
        Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(16, 58)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(208, 16)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(16, 4)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(208, 16)
        Me.lblGroup.TabIndex = 91
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine
        '
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.ForeColor = System.Drawing.Color.Lime
        Me.lblLine.Location = New System.Drawing.Point(16, 22)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(208, 16)
        Me.lblLine.TabIndex = 90
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(224, 22)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(184, 16)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(224, 40)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(184, 16)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(224, 4)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(184, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelRec
        '
        Me.PanelRec.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelRec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelRec.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblWOCount, Me.Label12, Me.Label4, Me.btnClearAll, Me.btnClear, Me.lstSN, Me.txtSN, Me.Label10, Me.Label3, Me.lblCount})
        Me.PanelRec.Location = New System.Drawing.Point(329, 88)
        Me.PanelRec.Name = "PanelRec"
        Me.PanelRec.Size = New System.Drawing.Size(415, 320)
        Me.PanelRec.TabIndex = 3
        '
        'lblWOCount
        '
        Me.lblWOCount.BackColor = System.Drawing.Color.Transparent
        Me.lblWOCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWOCount.ForeColor = System.Drawing.Color.Black
        Me.lblWOCount.Location = New System.Drawing.Point(336, 31)
        Me.lblWOCount.Name = "lblWOCount"
        Me.lblWOCount.Size = New System.Drawing.Size(48, 16)
        Me.lblWOCount.TabIndex = 109
        Me.lblWOCount.Text = "0"
        Me.lblWOCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(232, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(120, 32)
        Me.Label12.TabIndex = 108
        Me.Label12.Text = "No of Devices already in WO:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(40, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(146, 16)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "(Input the SN of Device)"
        '
        'btnClearAll
        '
        Me.btnClearAll.BackColor = System.Drawing.SystemColors.Control
        Me.btnClearAll.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAll.ForeColor = System.Drawing.Color.Black
        Me.btnClearAll.Location = New System.Drawing.Point(232, 236)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearAll.Size = New System.Drawing.Size(104, 40)
        Me.btnClearAll.TabIndex = 4
        Me.btnClearAll.Text = "Remove All SNs from List"
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.SystemColors.Control
        Me.btnClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(232, 192)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(105, 40)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Remove SN from List"
        '
        'lstSN
        '
        Me.lstSN.Location = New System.Drawing.Point(16, 76)
        Me.lstSN.Name = "lstSN"
        Me.lstSN.Size = New System.Drawing.Size(176, 225)
        Me.lstSN.TabIndex = 2
        '
        'txtSN
        '
        Me.txtSN.Location = New System.Drawing.Point(16, 27)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(176, 20)
        Me.txtSN.TabIndex = 1
        Me.txtSN.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(16, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(168, 16)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "SN (Serial Number):"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Black
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(256, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Count"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(232, 76)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(112, 72)
        Me.lblCount.TabIndex = 103
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cmdReceive
        '
        Me.cmdReceive.BackColor = System.Drawing.SystemColors.Control
        Me.cmdReceive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdReceive.ForeColor = System.Drawing.Color.Black
        Me.cmdReceive.Location = New System.Drawing.Point(408, 424)
        Me.cmdReceive.Name = "cmdReceive"
        Me.cmdReceive.Size = New System.Drawing.Size(216, 40)
        Me.cmdReceive.TabIndex = 4
        Me.cmdReceive.Text = "Receive in to PSS"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioBad, Me.RadioGood, Me.RadioScrap})
        Me.Panel1.Location = New System.Drawing.Point(1, 88)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(175, 80)
        Me.Panel1.TabIndex = 1
        '
        'RadioBad
        '
        Me.RadioBad.BackColor = System.Drawing.Color.LightSteelBlue
        Me.RadioBad.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioBad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioBad.ForeColor = System.Drawing.Color.Black
        Me.RadioBad.Location = New System.Drawing.Point(51, 26)
        Me.RadioBad.Name = "RadioBad"
        Me.RadioBad.Size = New System.Drawing.Size(112, 24)
        Me.RadioBad.TabIndex = 2
        Me.RadioBad.Text = "Level 3 (Bad)  "
        Me.RadioBad.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadioGood
        '
        Me.RadioGood.BackColor = System.Drawing.Color.LightSteelBlue
        Me.RadioGood.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioGood.ForeColor = System.Drawing.Color.Black
        Me.RadioGood.Location = New System.Drawing.Point(43, 2)
        Me.RadioGood.Name = "RadioGood"
        Me.RadioGood.Size = New System.Drawing.Size(120, 24)
        Me.RadioGood.TabIndex = 1
        Me.RadioGood.Text = "Level 2 (Good)  "
        Me.RadioGood.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RadioScrap
        '
        Me.RadioScrap.BackColor = System.Drawing.Color.LightSteelBlue
        Me.RadioScrap.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioScrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioScrap.ForeColor = System.Drawing.Color.Black
        Me.RadioScrap.Location = New System.Drawing.Point(3, 50)
        Me.RadioScrap.Name = "RadioScrap"
        Me.RadioScrap.Size = New System.Drawing.Size(160, 24)
        Me.RadioScrap.TabIndex = 3
        Me.RadioScrap.Text = "Scrap Devices (DBR)  "
        Me.RadioScrap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelInfo
        '
        Me.PanelInfo.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelInfo.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblSku, Me.Label7, Me.cmbLocation, Me.Label5, Me.cmbModel, Me.Label6, Me.Label2, Me.Label1, Me.txtWO})
        Me.PanelInfo.Location = New System.Drawing.Point(0, 192)
        Me.PanelInfo.Name = "PanelInfo"
        Me.PanelInfo.Size = New System.Drawing.Size(328, 152)
        Me.PanelInfo.TabIndex = 2
        '
        'lblSku
        '
        Me.lblSku.BackColor = System.Drawing.Color.Transparent
        Me.lblSku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSku.ForeColor = System.Drawing.Color.Black
        Me.lblSku.Location = New System.Drawing.Point(104, 85)
        Me.lblSku.Name = "lblSku"
        Me.lblSku.Size = New System.Drawing.Size(200, 16)
        Me.lblSku.TabIndex = 110
        Me.lblSku.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(24, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 109
        Me.Label7.Text = "SKU:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbLocation
        '
        Me.cmbLocation.AutoComplete = True
        Me.cmbLocation.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLocation.ForeColor = System.Drawing.Color.Black
        Me.cmbLocation.Location = New System.Drawing.Point(104, 113)
        Me.cmbLocation.Name = "cmbLocation"
        Me.cmbLocation.Size = New System.Drawing.Size(200, 21)
        Me.cmbLocation.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(24, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "Location:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbModel
        '
        Me.cmbModel.AutoComplete = True
        Me.cmbModel.BackColor = System.Drawing.SystemColors.Window
        Me.cmbModel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbModel.ForeColor = System.Drawing.Color.Black
        Me.cmbModel.Location = New System.Drawing.Point(104, 56)
        Me.cmbModel.Name = "cmbModel"
        Me.cmbModel.Size = New System.Drawing.Size(200, 21)
        Me.cmbModel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(24, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "Model:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(104, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 16)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "(Input WO/Lot No and Press Enter Key)"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "WO (Lot No):"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtWO
        '
        Me.txtWO.Location = New System.Drawing.Point(104, 13)
        Me.txtWO.Name = "txtWO"
        Me.txtWO.Size = New System.Drawing.Size(200, 20)
        Me.txtWO.TabIndex = 1
        Me.txtWO.Text = ""
        '
        'cmdClearScreen
        '
        Me.cmdClearScreen.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClearScreen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearScreen.ForeColor = System.Drawing.Color.Black
        Me.cmdClearScreen.Location = New System.Drawing.Point(68, 366)
        Me.cmdClearScreen.Name = "cmdClearScreen"
        Me.cmdClearScreen.Size = New System.Drawing.Size(88, 40)
        Me.cmdClearScreen.TabIndex = 8
        Me.cmdClearScreen.Text = "Clear Screen"
        '
        'cmdDeleteWO
        '
        Me.cmdDeleteWO.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDeleteWO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteWO.ForeColor = System.Drawing.Color.Black
        Me.cmdDeleteWO.Location = New System.Drawing.Point(164, 366)
        Me.cmdDeleteWO.Name = "cmdDeleteWO"
        Me.cmdDeleteWO.Size = New System.Drawing.Size(120, 40)
        Me.cmdDeleteWO.TabIndex = 9
        Me.cmdDeleteWO.Text = "Delete WO to Rereceive"
        '
        'frmGamestopRec
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(960, 484)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDeleteWO, Me.cmdClearScreen, Me.PanelInfo, Me.PanelRec, Me.Panel1, Me.Panel2, Me.lbl, Me.cmdReceive})
        Me.Name = "frmGamestopRec"
        Me.Text = "Game Stop Receiving"
        Me.Panel2.ResumeLayout(False)
        Me.PanelRec.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PanelInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub ResetControls()
        If Me.RadioGood.Checked Then
            iProcessType = 1
        ElseIf Me.RadioBad.Checked Then
            iProcessType = 2
        ElseIf Me.RadioScrap.Checked Then
            iProcessType = 3
        Else
            iProcessType = 0    'never happen
        End If

        Me.txtWO.Enabled = True
        Me.txtWO.Text = ""
        Me.txtSN.Text = ""
        Me.txtSN.Enabled = False
        Me.cmbLocation.SelectedValue = 0
        Me.cmbModel.SelectedValue = 0
        Me.lstSN.Items.Clear()
        Me.lblCount.Text = "0"
        Me.lblWOCount.Text = "0"

        iModelID = 0
        iSkuID = 0
        iLocID = 0
        'strSku_Number = ""
        strWO = ""
        iWOID = 0
        dtExcelData = Nothing
    End Sub

    Protected Overrides Sub Finalize()
        ' objGameStop = Nothing
        MyBase.Finalize()
    End Sub

    Private Sub frmGamestopRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0
        Try
            i = CheckIfMachineTiedToLine()
            If i = 0 Then
                Throw New Exception("Machine is not associated with any 'Line'. Can't continue.")
            End If

            '-----------------------
            Me.RadioGood.Checked = True
            LoadModels()
            LoadLocations()
            Me.txtWO.Focus()
            '------------------------

        Catch ex As Exception
            MessageBox.Show("frmGamestopRec.frmGamestopRec_Load: " & Environment.NewLine & ex.Message.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Function CheckIfMachineTiedToLine() As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim objMisc = New PSS.Data.Buisness.Misc()
        Dim strLineNumber As String = ""
        Dim strLineSide As String = ""

        Try
            dt1 = objMisc.CheckIfMachineTiedToLine(strMachine)
            If dt1.Rows.Count = 0 Then
                Return 0
            End If

            For Each R1 In dt1.Rows
                iGroup_ID = R1("Group_ID")
                strGroup = Trim(R1("Group_Desc"))
                'iLine_ID = R1("Line_ID")
                strLineNumber = Trim(R1("Line_Number"))
                'iLineSide_ID = R1("LineSide_ID")
                strLineSide = Trim(R1("LineSide_Desc"))
                'strBin = Trim(R1("WC_Location"))
                'iWCLocation_ID = R1("WCLocation_ID")
            Next R1

            Me.lblGroup.Text = "Group: " & strGroup
            Me.lblLine.Text = strLineNumber
            Me.lblLineSide.Text = strLineSide
            Me.lblMachine.Text = "Machine: " & strMachine
            Me.lblUserName.Text = "User: " & strUserName
            Me.lblShift.Text = "Shift: " & iShiftID
            Me.lblWorkDate.Text = "Work Date: " & Format(CDate(strWorkDate), "MM/dd/yyyy")
            'Me.lblBin.Text = "BIN: " & strBin

            Return 1
        Catch ex As Exception
            Throw ex
        Finally
            objMisc = Nothing
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function

    Private Sub RadioGood_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioGood.CheckedChanged
        If Me.RadioGood.Checked Then
            ResetControls()
        End If
    End Sub

    Private Sub RadioBad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioBad.CheckedChanged
        If Me.RadioBad.Checked Then
            ResetControls()
        End If
    End Sub

    Private Sub RadioScrap_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioScrap.CheckedChanged
        If Me.RadioScrap.Checked Then
            ResetControls()
        End If
    End Sub

    Private Sub LoadModels()
        Dim dtModels As New DataTable()
        Try
            ' dtModels = objGameStop.GetGameStopModels()
            With Me.cmbModel
                .DataSource = dtModels.DefaultView
                .DisplayMember = dtModels.Columns("Model_Desc").ToString
                .ValueMember = dtModels.Columns("Model_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmGameStopRec.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtModels) Then
                dtModels.Dispose()
                dtModels = Nothing
            End If
        End Try
    End Sub

    Private Sub LoadSkus()
        Dim dtSkus As New DataTable()
        Try
            ' dtSkus = objGameStop.GetGameStopSkus(iModelID)
            If dtSkus.Rows.Count > 0 Then
                iSkuID = dtSkus.Rows(0)("Sku_ID")
                Me.lblSku.Text = dtSkus.Rows(0)("Sku_Number")
            Else
                Throw New Exception("Sku was not exist for " & Me.cmbModel.SelectedText & " model.")
            End If

        Catch ex As Exception
            MsgBox("Error in frmGameStopRec.LoadSkus:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtSkus) Then
                dtSkus.Dispose()
                dtSkus = Nothing
            End If
        End Try
    End Sub

    Private Sub LoadLocations()
        Dim dtLocations As New DataTable()
        Try
            ' dtLocations = objGameStop.GetGameStopLocations()
            With Me.cmbLocation
                .DataSource = dtLocations.DefaultView
                .DisplayMember = dtLocations.Columns("Loc_Name").ToString
                .ValueMember = dtLocations.Columns("Loc_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmGameStopRec.LoadSkus:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtLocations) Then
                dtLocations.Dispose()
                dtLocations = Nothing
            End If
        End Try
    End Sub


    Private Sub cmbModel_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbModel.SelectionChangeCommitted
        If Me.cmbModel.SelectedValue > 0 Then
            iModelID = Me.cmbModel.SelectedValue
            LoadSkus()
            Me.cmbLocation.Focus()
        Else
            iModelID = 0
            Me.lblSku.Text = ""
        End If
    End Sub


    Private Sub cmbLocation_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLocation.SelectionChangeCommitted
        If Me.cmbLocation.SelectedValue > 0 Then
            iLocID = Me.cmbLocation.SelectedValue
            Me.txtSN.Focus()
        Else
            iLocID = 0
        End If
    End Sub

    Private Sub txtWO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWO.KeyUp
        Dim strFilePath As String = "P:\Dept\Game Stop\Data Files\" & Trim(Me.txtWO.Text) & ".xls"

        If e.KeyValue = 13 Then
            If Trim(Me.txtWO.Text) = "" Then
                Exit Sub
            End If

            Try
                'check file exist
                If Not File.Exists(strFilePath) Then
                    Throw New Exception("Excel file '" & strFilePath & "' does not exist.")
                End If

                'Read the excel file
                'dtExcelData = objGameStop.GetSNsFromExcel(strFilePath)
                If dtExcelData.Rows.Count = 0 Then
                    Throw New Exception("Excel file '" & strFilePath & "' was empty.")
                End If

                strWO = Trim(Me.txtWO.Text)
                Me.txtWO.Enabled = False
                Me.txtSN.Enabled = True
                Me.cmbModel.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Get WO", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.RadioGood.Checked = True
                If Me.RadioGood.Checked Then
                    ResetControls()
                End If
                Me.txtWO.Text = ""
            End Try

        End If
    End Sub

    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp
        If e.KeyValue = 13 Then
            If Trim(Me.txtSN.Text) = "" Then
                Exit Sub
            End If
            If iModelID = 0 Or iSkuID = 0 Then
                MessageBox.Show("Please select model.", "SN scan", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbModel.Focus()
                Exit Sub
            End If
            If iLocID = 0 Then
                MessageBox.Show("Please select Location.", "SN scan", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbModel.Focus()
                Exit Sub
            End If

            'check for duplicate in list box
            Dim i As Integer = 0
            If Me.lstSN.Items.Count > 0 Then
                For i = 0 To Me.lstSN.Items.Count - 1
                    If Trim(Me.txtSN.Text) = Me.lstSN.Items.Item(i) Then
                        MessageBox.Show("This SN is already scanned in.", "SN scan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtSN.Text = ""
                        Me.txtSN.Focus()
                        Exit Sub
                    End If
                Next i
            End If
            'validate SN

            Try
                'sn exist in excel file
                '-----------------------------------------------
                Dim R1 As DataRow
                For Each R1 In dtExcelData.Rows
                    If R1("Serial") = Trim(Me.txtSN.Text) Then
                        Me.lstSN.Items.Add(Trim(Me.txtSN.Text))
                    Else
                        'WAIT FOR ASIF
                        MessageBox.Show("not match with excel file.")
                    End If
                Next R1
                '-----------------------------------------------

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "SN scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.txtSN.Text = ""
            End Try

        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If Me.lstSN.SelectedIndex > -1 Then
            Me.lstSN.Items.RemoveAt(Me.lstSN.SelectedIndex)
            Me.lstSN.Refresh()
            Me.txtSN.Focus()
        End If
    End Sub

    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click
        If Me.lstSN.Items.Count > 0 Then
            Me.lstSN.Items.Clear()
            Me.lstSN.Refresh()
            Me.txtSN.Focus()
        End If
    End Sub

    Private Sub cmdClearScreen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearScreen.Click
        Me.RadioGood.Checked = True
        If Me.RadioGood.Checked Then
            ResetControls()
        End If
    End Sub

    Private Sub cmdReceive_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReceive.Click
        'If iWOID = 0 Then
        '    MessageBox.Show("Please enter WO and press enter.", "Receiving to PSS", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
        '    Me.txtWO.Focus()
        '    Exit Sub
        'End If
    End Sub
End Class
