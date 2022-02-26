Option Explicit On 

Imports Microsoft.VisualBasic

Public Class frmHTCBuilBox
    Inherits System.Windows.Forms.Form

    Const _HTC_CUSTOMERID As Integer = 2251
    Const _HTC_LOCID As Integer = 2775
    Const _SCREEN_NAME As String = "PACKAGING"
    Private _objHTC As PSS.Data.Buisness.HTC
    Private objMisc As PSS.Data.Buisness.Misc
    Private strMachine As String = System.Net.Dns.GetHostName
    Private strUserName As String = PSS.Core.Global.ApplicationUser.User
    Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
    Private strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
    Private iWCLocation_ID As Integer = 0
    Private iLine_ID As Integer = 0
    Private iGroup_ID As Integer = 0
    Private strGroup As String = ""
    Private strLineNumber As String = ""
    Private iLineSide_ID As Integer = 0
    Private strLineSide As String = ""
    Private strBin As String = ""

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objMisc = New PSS.Data.Buisness.Misc()
        _objHTC = New PSS.Data.Buisness.HTC()

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        objMisc = Nothing
        _objHTC = Nothing

        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents lblWorkDate As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblLine As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents lblMachine As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmbShipType As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblLineSide As System.Windows.Forms.Label
    Friend WithEvents lblBin As System.Windows.Forms.Label
    Friend WithEvents lblPalletName As System.Windows.Forms.Label
    Friend WithEvents panelPallet As System.Windows.Forms.Panel
    Friend WithEvents grdPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents panelShipType As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblUserProd As System.Windows.Forms.Label
    Friend WithEvents lblLineProd As System.Windows.Forms.Label
    Friend WithEvents lblGroupProd As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblShiftProd As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyGroupProd As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyLineProd As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyUserProd As System.Windows.Forms.Label
    Friend WithEvents lblWeeklyShiftProd As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents grdProd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdWeeklyProd As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnCloseBox As System.Windows.Forms.Button
    Friend WithEvents btnCreateBoxID As System.Windows.Forms.Button
    Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents pnlRMA As System.Windows.Forms.Panel
    Friend WithEvents lblRMAQty As System.Windows.Forms.Label
    Friend WithEvents lblCompletedRMAQty As System.Windows.Forms.Label
    Friend WithEvents cboOpenShipRMA As PSS.Gui.Controls.ComboBox
    Friend WithEvents pnlShipType As System.Windows.Forms.Panel
    Friend WithEvents btnReopenBox As System.Windows.Forms.Button
    Friend WithEvents btnDeleteBox As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTAT As System.Windows.Forms.Label
    Private WithEvents lblScreenName As System.Windows.Forms.Label
    Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
    Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
    Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHTCBuilBox))
        Me.lblScreenName = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblBin = New System.Windows.Forms.Label()
        Me.lblLineSide = New System.Windows.Forms.Label()
        Me.lblMachine = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.lblWorkDate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cboOpenShipRMA = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmbShipType = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelPallet = New System.Windows.Forms.Panel()
        Me.txtDevSN = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnCloseBox = New System.Windows.Forms.Button()
        Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
        Me.btnRemoveSN = New System.Windows.Forms.Button()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblPalletName = New System.Windows.Forms.Label()
        Me.btnReopenBox = New System.Windows.Forms.Button()
        Me.btnCreateBoxID = New System.Windows.Forms.Button()
        Me.grdPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.panelShipType = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.pnlShipType = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.lblWeeklyGroupProd = New System.Windows.Forms.Label()
        Me.lblWeeklyLineProd = New System.Windows.Forms.Label()
        Me.lblWeeklyUserProd = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblWeeklyShiftProd = New System.Windows.Forms.Label()
        Me.grdWeeklyProd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblGroupProd = New System.Windows.Forms.Label()
        Me.lblLineProd = New System.Windows.Forms.Label()
        Me.lblUserProd = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblShiftProd = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.grdProd = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.PanelPalletList = New System.Windows.Forms.Panel()
        Me.btnDeleteBox = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
        Me.pnlRMA = New System.Windows.Forms.Panel()
        Me.lblTAT = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblCompletedRMAQty = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblRMAQty = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.panelPallet.SuspendLayout()
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelShipType.SuspendLayout()
        Me.pnlShipType.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdWeeklyProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.grdProd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPalletList.SuspendLayout()
        Me.pnlRMA.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblScreenName
        '
        Me.lblScreenName.BackColor = System.Drawing.Color.Black
        Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
        Me.lblScreenName.Location = New System.Drawing.Point(3, 2)
        Me.lblScreenName.Name = "lblScreenName"
        Me.lblScreenName.Size = New System.Drawing.Size(229, 70)
        Me.lblScreenName.TabIndex = 7
        Me.lblScreenName.Text = "BUILD BOX"
        Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblBin, Me.lblLineSide, Me.lblMachine, Me.lblGroup, Me.lblLine, Me.lblShift, Me.lblWorkDate, Me.lblUserName})
        Me.Panel2.Location = New System.Drawing.Point(235, 1)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(614, 71)
        Me.Panel2.TabIndex = 87
        '
        'lblBin
        '
        Me.lblBin.BackColor = System.Drawing.Color.Transparent
        Me.lblBin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBin.ForeColor = System.Drawing.Color.Lime
        Me.lblBin.Location = New System.Drawing.Point(200, 25)
        Me.lblBin.Name = "lblBin"
        Me.lblBin.Size = New System.Drawing.Size(178, 16)
        Me.lblBin.TabIndex = 94
        Me.lblBin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineSide
        '
        Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
        Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
        Me.lblLineSide.Location = New System.Drawing.Point(29, 46)
        Me.lblLineSide.Name = "lblLineSide"
        Me.lblLineSide.Size = New System.Drawing.Size(146, 16)
        Me.lblLineSide.TabIndex = 93
        Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachine
        '
        Me.lblMachine.BackColor = System.Drawing.Color.Transparent
        Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachine.ForeColor = System.Drawing.Color.Lime
        Me.lblMachine.Location = New System.Drawing.Point(200, 4)
        Me.lblMachine.Name = "lblMachine"
        Me.lblMachine.Size = New System.Drawing.Size(178, 16)
        Me.lblMachine.TabIndex = 92
        Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGroup
        '
        Me.lblGroup.BackColor = System.Drawing.Color.Transparent
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.Lime
        Me.lblGroup.Location = New System.Drawing.Point(29, 4)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(146, 16)
        Me.lblGroup.TabIndex = 91
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLine
        '
        Me.lblLine.BackColor = System.Drawing.Color.Transparent
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.ForeColor = System.Drawing.Color.Lime
        Me.lblLine.Location = New System.Drawing.Point(29, 25)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(146, 16)
        Me.lblLine.TabIndex = 90
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.Lime
        Me.lblShift.Location = New System.Drawing.Point(402, 25)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(178, 16)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWorkDate
        '
        Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
        Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
        Me.lblWorkDate.Location = New System.Drawing.Point(402, 46)
        Me.lblWorkDate.Name = "lblWorkDate"
        Me.lblWorkDate.Size = New System.Drawing.Size(178, 16)
        Me.lblWorkDate.TabIndex = 84
        Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.Lime
        Me.lblUserName.Location = New System.Drawing.Point(402, 4)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(178, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboOpenShipRMA, Me.Label5, Me.Button4})
        Me.Panel6.Location = New System.Drawing.Point(234, 74)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(272, 54)
        Me.Panel6.TabIndex = 0
        '
        'cboOpenShipRMA
        '
        Me.cboOpenShipRMA.AutoComplete = True
        Me.cboOpenShipRMA.BackColor = System.Drawing.SystemColors.Window
        Me.cboOpenShipRMA.DropDownWidth = 300
        Me.cboOpenShipRMA.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboOpenShipRMA.ForeColor = System.Drawing.Color.Black
        Me.cboOpenShipRMA.Location = New System.Drawing.Point(8, 22)
        Me.cboOpenShipRMA.MaxDropDownItems = 30
        Me.cboOpenShipRMA.Name = "cboOpenShipRMA"
        Me.cboOpenShipRMA.Size = New System.Drawing.Size(256, 21)
        Me.cboOpenShipRMA.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(8, 6)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 16)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Available RMA:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(144, 245)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(200, 31)
        Me.Button4.TabIndex = 66
        Me.Button4.TabStop = False
        Me.Button4.Text = "Generate Report"
        '
        'cmbShipType
        '
        Me.cmbShipType.AutoComplete = True
        Me.cmbShipType.BackColor = System.Drawing.SystemColors.Window
        Me.cmbShipType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbShipType.ForeColor = System.Drawing.Color.Black
        Me.cmbShipType.Items.AddRange(New Object() {"REFURBISHED", "RUR"})
        Me.cmbShipType.Location = New System.Drawing.Point(80, 12)
        Me.cmbShipType.Name = "cmbShipType"
        Me.cmbShipType.Size = New System.Drawing.Size(168, 21)
        Me.cmbShipType.TabIndex = 84
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 16)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Ship Type:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'panelPallet
        '
        Me.panelPallet.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblPalletName})
        Me.panelPallet.Location = New System.Drawing.Point(508, 74)
        Me.panelPallet.Name = "panelPallet"
        Me.panelPallet.Size = New System.Drawing.Size(340, 414)
        Me.panelPallet.TabIndex = 3
        Me.panelPallet.Visible = False
        '
        'txtDevSN
        '
        Me.txtDevSN.Location = New System.Drawing.Point(11, 56)
        Me.txtDevSN.Name = "txtDevSN"
        Me.txtDevSN.Size = New System.Drawing.Size(156, 20)
        Me.txtDevSN.TabIndex = 0
        Me.txtDevSN.Text = ""
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(11, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(157, 16)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Serial Number:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCloseBox
        '
        Me.btnCloseBox.BackColor = System.Drawing.Color.Green
        Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCloseBox.ForeColor = System.Drawing.Color.White
        Me.btnCloseBox.Location = New System.Drawing.Point(11, 368)
        Me.btnCloseBox.Name = "btnCloseBox"
        Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCloseBox.Size = New System.Drawing.Size(157, 32)
        Me.btnCloseBox.TabIndex = 2
        Me.btnCloseBox.Text = "CLOSE BOX"
        '
        'btnRemoveAllSNs
        '
        Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
        Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
        Me.btnRemoveAllSNs.Location = New System.Drawing.Point(180, 175)
        Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
        Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveAllSNs.Size = New System.Drawing.Size(148, 33)
        Me.btnRemoveAllSNs.TabIndex = 4
        Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
        '
        'btnRemoveSN
        '
        Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
        Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
        Me.btnRemoveSN.Location = New System.Drawing.Point(180, 136)
        Me.btnRemoveSN.Name = "btnRemoveSN"
        Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnRemoveSN.Size = New System.Drawing.Size(148, 32)
        Me.btnRemoveSN.TabIndex = 903
        Me.btnRemoveSN.Text = "REMOVE SN"
        '
        'lstDevices
        '
        Me.lstDevices.Location = New System.Drawing.Point(11, 80)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(156, 277)
        Me.lstDevices.TabIndex = 1
        '
        'lblCount
        '
        Me.lblCount.BackColor = System.Drawing.Color.Black
        Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Lime
        Me.lblCount.Location = New System.Drawing.Point(205, 76)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(98, 32)
        Me.lblCount.TabIndex = 97
        Me.lblCount.Text = "0"
        Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(208, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Box Count"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPalletName
        '
        Me.lblPalletName.BackColor = System.Drawing.Color.Black
        Me.lblPalletName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPalletName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPalletName.ForeColor = System.Drawing.Color.Lime
        Me.lblPalletName.Location = New System.Drawing.Point(10, 5)
        Me.lblPalletName.Name = "lblPalletName"
        Me.lblPalletName.Size = New System.Drawing.Size(318, 32)
        Me.lblPalletName.TabIndex = 98
        Me.lblPalletName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReopenBox
        '
        Me.btnReopenBox.BackColor = System.Drawing.Color.Red
        Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReopenBox.ForeColor = System.Drawing.Color.White
        Me.btnReopenBox.Location = New System.Drawing.Point(27, 136)
        Me.btnReopenBox.Name = "btnReopenBox"
        Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnReopenBox.Size = New System.Drawing.Size(213, 32)
        Me.btnReopenBox.TabIndex = 1
        Me.btnReopenBox.Text = "REOPEN  BOX"
        '
        'btnCreateBoxID
        '
        Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
        Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
        Me.btnCreateBoxID.Location = New System.Drawing.Point(27, 64)
        Me.btnCreateBoxID.Name = "btnCreateBoxID"
        Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCreateBoxID.Size = New System.Drawing.Size(214, 32)
        Me.btnCreateBoxID.TabIndex = 1
        Me.btnCreateBoxID.Text = "CREATE BOX ID"
        Me.btnCreateBoxID.Visible = False
        '
        'grdPallets
        '
        Me.grdPallets.AllowColMove = False
        Me.grdPallets.AllowColSelect = False
        Me.grdPallets.AllowFilter = False
        Me.grdPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdPallets.AllowSort = False
        Me.grdPallets.AllowUpdate = False
        Me.grdPallets.AllowUpdateOnBlur = False
        Me.grdPallets.CollapseColor = System.Drawing.Color.White
        Me.grdPallets.ExpandColor = System.Drawing.Color.White
        Me.grdPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPallets.ForeColor = System.Drawing.Color.White
        Me.grdPallets.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPallets.Location = New System.Drawing.Point(27, 9)
        Me.grdPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPallets.Name = "grdPallets"
        Me.grdPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPallets.PreviewInfo.ZoomFactor = 75
        Me.grdPallets.RowHeight = 20
        Me.grdPallets.Size = New System.Drawing.Size(214, 111)
        Me.grdPallets.TabIndex = 1
        Me.grdPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
        "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
        "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
        "lor:White;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;BackColo" & _
        "r:LightSteelBlue;ForeColor:White;AlignVert:Center;}HighlightRow{ForeColor:Highli" & _
        "ghtText;BackColor:Highlight;}Style12{}OddRow{BackColor:Teal;}RecordSelector{Alig" & _
        "nImage:Center;ForeColor:White;}Style13{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
        "rif, 8.25pt, style=Bold;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1" & _
        ", 1;ForeColor:Blue;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
        "tyle14{}Style15{}Style16{}Style17{}Style1{}</Data></Styles><Splits><C1.Win.C1Tru" & _
        "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
        "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
        "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16"" Ver" & _
        "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>107</Height><CaptionStyle" & _
        " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
        "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
        "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
        "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
        "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
        "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
        "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
        "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 210, 107</ClientRect><BorderSide>" & _
        "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
        "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
        "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
        "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
        "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
        "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
        "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
        "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
        "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</Defau" & _
        "ltRecSelWidth><ClientArea>0, 0, 210, 107</ClientArea><PrintPageHeaderStyle paren" & _
        "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'panelShipType
        '
        Me.panelShipType.BackColor = System.Drawing.Color.LightSteelBlue
        Me.panelShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panelShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.Label1, Me.cmbShipType})
        Me.panelShipType.Location = New System.Drawing.Point(8, 6)
        Me.panelShipType.Name = "panelShipType"
        Me.panelShipType.Size = New System.Drawing.Size(256, 48)
        Me.panelShipType.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(144, 245)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(200, 31)
        Me.Button3.TabIndex = 66
        Me.Button3.TabStop = False
        Me.Button3.Text = "Generate Report"
        '
        'pnlShipType
        '
        Me.pnlShipType.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button5, Me.panelShipType, Me.btnCreateBoxID})
        Me.pnlShipType.Location = New System.Drawing.Point(234, 192)
        Me.pnlShipType.Name = "pnlShipType"
        Me.pnlShipType.Size = New System.Drawing.Size(272, 112)
        Me.pnlShipType.TabIndex = 1
        Me.pnlShipType.Visible = False
        '
        'Button5
        '
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(144, 245)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(200, 31)
        Me.Button5.TabIndex = 66
        Me.Button5.TabStop = False
        Me.Button5.Text = "Generate Report"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label20, Me.Panel4, Me.Label4, Me.Panel3})
        Me.Panel1.Location = New System.Drawing.Point(3, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(229, 454)
        Me.Panel1.TabIndex = 107
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(2, 232)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(150, 16)
        Me.Label20.TabIndex = 113
        Me.Label20.Text = "Weekly Production:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label21, Me.lblWeeklyGroupProd, Me.lblWeeklyLineProd, Me.lblWeeklyUserProd, Me.Label15, Me.Label16, Me.Label17, Me.Label18, Me.lblWeeklyShiftProd, Me.grdWeeklyProd})
        Me.Panel4.Location = New System.Drawing.Point(5, 249)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(216, 198)
        Me.Panel4.TabIndex = 112
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(3, 78)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(180, 16)
        Me.Label21.TabIndex = 111
        Me.Label21.Text = "Line Production by Model:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyGroupProd
        '
        Me.lblWeeklyGroupProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyGroupProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyGroupProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyGroupProd.Location = New System.Drawing.Point(140, 57)
        Me.lblWeeklyGroupProd.Name = "lblWeeklyGroupProd"
        Me.lblWeeklyGroupProd.Size = New System.Drawing.Size(64, 16)
        Me.lblWeeklyGroupProd.TabIndex = 89
        Me.lblWeeklyGroupProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyLineProd
        '
        Me.lblWeeklyLineProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyLineProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyLineProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyLineProd.Location = New System.Drawing.Point(140, 22)
        Me.lblWeeklyLineProd.Name = "lblWeeklyLineProd"
        Me.lblWeeklyLineProd.Size = New System.Drawing.Size(64, 16)
        Me.lblWeeklyLineProd.TabIndex = 88
        Me.lblWeeklyLineProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyUserProd
        '
        Me.lblWeeklyUserProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyUserProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyUserProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyUserProd.Location = New System.Drawing.Point(140, 5)
        Me.lblWeeklyUserProd.Name = "lblWeeklyUserProd"
        Me.lblWeeklyUserProd.Size = New System.Drawing.Size(64, 16)
        Me.lblWeeklyUserProd.TabIndex = 87
        Me.lblWeeklyUserProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Lime
        Me.Label15.Location = New System.Drawing.Point(5, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(128, 16)
        Me.Label15.TabIndex = 86
        Me.Label15.Text = "Group Production:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Lime
        Me.Label16.Location = New System.Drawing.Point(5, 22)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 16)
        Me.Label16.TabIndex = 85
        Me.Label16.Text = "Line Production:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Lime
        Me.Label17.Location = New System.Drawing.Point(5, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(118, 16)
        Me.Label17.TabIndex = 84
        Me.Label17.Text = "User Production:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Lime
        Me.Label18.Location = New System.Drawing.Point(5, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 16)
        Me.Label18.TabIndex = 90
        Me.Label18.Text = "Shift Production:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWeeklyShiftProd
        '
        Me.lblWeeklyShiftProd.BackColor = System.Drawing.Color.Transparent
        Me.lblWeeklyShiftProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWeeklyShiftProd.ForeColor = System.Drawing.Color.Lime
        Me.lblWeeklyShiftProd.Location = New System.Drawing.Point(140, 40)
        Me.lblWeeklyShiftProd.Name = "lblWeeklyShiftProd"
        Me.lblWeeklyShiftProd.Size = New System.Drawing.Size(64, 16)
        Me.lblWeeklyShiftProd.TabIndex = 91
        Me.lblWeeklyShiftProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdWeeklyProd
        '
        Me.grdWeeklyProd.AllowColMove = False
        Me.grdWeeklyProd.AllowColSelect = False
        Me.grdWeeklyProd.AllowFilter = False
        Me.grdWeeklyProd.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdWeeklyProd.AllowSort = False
        Me.grdWeeklyProd.AllowUpdate = False
        Me.grdWeeklyProd.AllowUpdateOnBlur = False
        Me.grdWeeklyProd.CollapseColor = System.Drawing.Color.White
        Me.grdWeeklyProd.ExpandColor = System.Drawing.Color.White
        Me.grdWeeklyProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdWeeklyProd.ForeColor = System.Drawing.Color.White
        Me.grdWeeklyProd.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdWeeklyProd.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.grdWeeklyProd.Location = New System.Drawing.Point(3, 94)
        Me.grdWeeklyProd.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdWeeklyProd.Name = "grdWeeklyProd"
        Me.grdWeeklyProd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdWeeklyProd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdWeeklyProd.PreviewInfo.ZoomFactor = 75
        Me.grdWeeklyProd.RowHeight = 20
        Me.grdWeeklyProd.Size = New System.Drawing.Size(205, 96)
        Me.grdWeeklyProd.TabIndex = 110
        Me.grdWeeklyProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:White;Ba" & _
        "ckColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:W" & _
        "hite;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVert:Cen" & _
        "ter;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style14{}OddRow{BackColor:LightSteelBlue;}RecordSelector" & _
        "{ForeColor:White;AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sa" & _
        "ns Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1" & _
        ", 1, 1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style" & _
        "11{}Style12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win." & _
        "C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" Allow" & _
        "RowSizing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16" & _
        """ VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>92</Height><CaptionS" & _
        "tyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><" & _
        "EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" m" & _
        "e=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Gro" & _
        "up"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowSty" & _
        "le parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Styl" & _
        "e4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Re" & _
        "cordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Sty" & _
        "le parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 201, 92</ClientRect><BorderSi" & _
        "de>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVie" & _
        "w></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me" & _
        "=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""C" & _
        "aption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sel" & _
        "ected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlig" & _
        "htRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow" & _
        """ /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fil" & _
        "terBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vert" & _
        "Splits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</De" & _
        "faultRecSelWidth><ClientArea>0, 0, 201, 92</ClientArea><PrintPageHeaderStyle par" & _
        "ent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(4, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(132, 16)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Daily Production:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGroupProd, Me.lblLineProd, Me.lblUserProd, Me.Label9, Me.Label7, Me.Label6, Me.Label11, Me.lblShiftProd, Me.Label13, Me.grdProd})
        Me.Panel3.Location = New System.Drawing.Point(5, 25)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(216, 199)
        Me.Panel3.TabIndex = 110
        '
        'lblGroupProd
        '
        Me.lblGroupProd.BackColor = System.Drawing.Color.Transparent
        Me.lblGroupProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupProd.ForeColor = System.Drawing.Color.Lime
        Me.lblGroupProd.Location = New System.Drawing.Point(140, 58)
        Me.lblGroupProd.Name = "lblGroupProd"
        Me.lblGroupProd.Size = New System.Drawing.Size(64, 16)
        Me.lblGroupProd.TabIndex = 89
        Me.lblGroupProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLineProd
        '
        Me.lblLineProd.BackColor = System.Drawing.Color.Transparent
        Me.lblLineProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLineProd.ForeColor = System.Drawing.Color.Lime
        Me.lblLineProd.Location = New System.Drawing.Point(140, 23)
        Me.lblLineProd.Name = "lblLineProd"
        Me.lblLineProd.Size = New System.Drawing.Size(64, 16)
        Me.lblLineProd.TabIndex = 88
        Me.lblLineProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserProd
        '
        Me.lblUserProd.BackColor = System.Drawing.Color.Transparent
        Me.lblUserProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserProd.ForeColor = System.Drawing.Color.Lime
        Me.lblUserProd.Location = New System.Drawing.Point(140, 5)
        Me.lblUserProd.Name = "lblUserProd"
        Me.lblUserProd.Size = New System.Drawing.Size(64, 16)
        Me.lblUserProd.TabIndex = 87
        Me.lblUserProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Lime
        Me.Label9.Location = New System.Drawing.Point(5, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(128, 16)
        Me.Label9.TabIndex = 86
        Me.Label9.Text = "Group Production:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(5, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 16)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Line Production:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(5, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(118, 16)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "User Production:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Lime
        Me.Label11.Location = New System.Drawing.Point(5, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(118, 16)
        Me.Label11.TabIndex = 90
        Me.Label11.Text = "Shift Production:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblShiftProd
        '
        Me.lblShiftProd.BackColor = System.Drawing.Color.Transparent
        Me.lblShiftProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShiftProd.ForeColor = System.Drawing.Color.Lime
        Me.lblShiftProd.Location = New System.Drawing.Point(140, 41)
        Me.lblShiftProd.Name = "lblShiftProd"
        Me.lblShiftProd.Size = New System.Drawing.Size(64, 16)
        Me.lblShiftProd.TabIndex = 91
        Me.lblShiftProd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(3, 78)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(180, 18)
        Me.Label13.TabIndex = 109
        Me.Label13.Text = "Line Production by Model:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdProd
        '
        Me.grdProd.AllowColMove = False
        Me.grdProd.AllowColSelect = False
        Me.grdProd.AllowFilter = False
        Me.grdProd.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.grdProd.AllowSort = False
        Me.grdProd.AllowUpdate = False
        Me.grdProd.AllowUpdateOnBlur = False
        Me.grdProd.CollapseColor = System.Drawing.Color.White
        Me.grdProd.ExpandColor = System.Drawing.Color.White
        Me.grdProd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdProd.ForeColor = System.Drawing.Color.White
        Me.grdProd.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdProd.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
        Me.grdProd.Location = New System.Drawing.Point(3, 96)
        Me.grdProd.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdProd.Name = "grdProd"
        Me.grdProd.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdProd.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdProd.PreviewInfo.ZoomFactor = 75
        Me.grdProd.RowHeight = 20
        Me.grdProd.Size = New System.Drawing.Size(205, 96)
        Me.grdProd.TabIndex = 110
        Me.grdProd.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:White;Ba" & _
        "ckColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeColor:W" & _
        "hite;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVert:Cen" & _
        "ter;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTe" & _
        "xt;BackColor:Highlight;}Style14{}OddRow{BackColor:LightSteelBlue;}RecordSelector" & _
        "{ForeColor:White;AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sa" & _
        "ns Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1" & _
        ", 1, 1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style" & _
        "11{}Style12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win." & _
        "C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" Allow" & _
        "RowSizing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=" & _
        """17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefRecSelWidth=""16" & _
        """ VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>92</Height><CaptionS" & _
        "tyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><" & _
        "EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" m" & _
        "e=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Gro" & _
        "up"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowSty" & _
        "le parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Styl" & _
        "e4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Re" & _
        "cordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Sty" & _
        "le parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 201, 92</ClientRect><BorderSi" & _
        "de>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeVie" & _
        "w></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me" & _
        "=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""C" & _
        "aption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Sel" & _
        "ected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""Highlig" & _
        "htRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow" & _
        """ /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Fil" & _
        "terBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vert" & _
        "Splits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</De" & _
        "faultRecSelWidth><ClientArea>0, 0, 201, 92</ClientArea><PrintPageHeaderStyle par" & _
        "ent="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
        '
        'PanelPalletList
        '
        Me.PanelPalletList.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteBox, Me.Button6, Me.grdPallets, Me.btnReopenBox})
        Me.PanelPalletList.Location = New System.Drawing.Point(234, 305)
        Me.PanelPalletList.Name = "PanelPalletList"
        Me.PanelPalletList.Size = New System.Drawing.Size(272, 223)
        Me.PanelPalletList.TabIndex = 2
        Me.PanelPalletList.Visible = False
        '
        'btnDeleteBox
        '
        Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
        Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
        Me.btnDeleteBox.Location = New System.Drawing.Point(28, 176)
        Me.btnDeleteBox.Name = "btnDeleteBox"
        Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDeleteBox.Size = New System.Drawing.Size(213, 32)
        Me.btnDeleteBox.TabIndex = 2
        Me.btnDeleteBox.Text = "DELETE EMPTY BOX"
        '
        'Button6
        '
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(144, 245)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(200, 31)
        Me.Button6.TabIndex = 66
        Me.Button6.TabStop = False
        Me.Button6.Text = "Generate Report"
        '
        'btnReprintBoxLabel
        '
        Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
        Me.btnReprintBoxLabel.Location = New System.Drawing.Point(512, 496)
        Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
        Me.btnReprintBoxLabel.Size = New System.Drawing.Size(216, 32)
        Me.btnReprintBoxLabel.TabIndex = 109
        Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
        '
        'pnlRMA
        '
        Me.pnlRMA.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlRMA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlRMA.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblTAT, Me.Label8, Me.lblCompletedRMAQty, Me.Label19, Me.lblRMAQty, Me.Label12})
        Me.pnlRMA.Location = New System.Drawing.Point(234, 128)
        Me.pnlRMA.Name = "pnlRMA"
        Me.pnlRMA.Size = New System.Drawing.Size(272, 64)
        Me.pnlRMA.TabIndex = 110
        '
        'lblTAT
        '
        Me.lblTAT.BackColor = System.Drawing.Color.Black
        Me.lblTAT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAT.ForeColor = System.Drawing.Color.Lime
        Me.lblTAT.Location = New System.Drawing.Point(208, 23)
        Me.lblTAT.Name = "lblTAT"
        Me.lblTAT.Size = New System.Drawing.Size(48, 32)
        Me.lblTAT.TabIndex = 103
        Me.lblTAT.Text = "0"
        Me.lblTAT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(208, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 16)
        Me.Label8.TabIndex = 102
        Me.Label8.Text = "TAT"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblCompletedRMAQty
        '
        Me.lblCompletedRMAQty.BackColor = System.Drawing.Color.Black
        Me.lblCompletedRMAQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCompletedRMAQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletedRMAQty.ForeColor = System.Drawing.Color.Lime
        Me.lblCompletedRMAQty.Location = New System.Drawing.Point(112, 23)
        Me.lblCompletedRMAQty.Name = "lblCompletedRMAQty"
        Me.lblCompletedRMAQty.Size = New System.Drawing.Size(80, 32)
        Me.lblCompletedRMAQty.TabIndex = 101
        Me.lblCompletedRMAQty.Text = "0"
        Me.lblCompletedRMAQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(112, 5)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(80, 16)
        Me.Label19.TabIndex = 100
        Me.Label19.Text = "Filled RMA"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'lblRMAQty
        '
        Me.lblRMAQty.BackColor = System.Drawing.Color.Black
        Me.lblRMAQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRMAQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRMAQty.ForeColor = System.Drawing.Color.Lime
        Me.lblRMAQty.Location = New System.Drawing.Point(8, 23)
        Me.lblRMAQty.Name = "lblRMAQty"
        Me.lblRMAQty.Size = New System.Drawing.Size(80, 32)
        Me.lblRMAQty.TabIndex = 99
        Me.lblRMAQty.Text = "0"
        Me.lblRMAQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(8, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 16)
        Me.Label12.TabIndex = 98
        Me.Label12.Text = "RMA Qty"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'frmHTCBuilBox
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(856, 533)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlRMA, Me.btnReprintBoxLabel, Me.PanelPalletList, Me.Panel1, Me.pnlShipType, Me.panelPallet, Me.Panel6, Me.Panel2, Me.lblScreenName})
        Me.Name = "frmHTCBuilBox"
        Me.Text = "Build Carton Box"
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.panelPallet.ResumeLayout(False)
        CType(Me.grdPallets, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelShipType.ResumeLayout(False)
        Me.pnlShipType.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdWeeklyProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdProd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPalletList.ResumeLayout(False)
        Me.pnlRMA.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**************************************************************************************************
    Protected Overrides Sub Finalize()
        objMisc = Nothing
        MyBase.Finalize()
    End Sub

    '**************************************************************************************************
    Private Function CheckIfMachineTiedToLine() As Integer
        Dim dt1 As DataTable
        Dim R1 As DataRow

        Try
            dt1 = objMisc.CheckIfMachineTiedToLine(strMachine)
            If dt1.Rows.Count = 0 Then
                Return 0
            End If

            For Each R1 In dt1.Rows
                iGroup_ID = R1("Group_ID")
                strGroup = Trim(R1("Group_Desc"))
                iLine_ID = R1("Line_ID")
                strLineNumber = Trim(R1("Line_Number"))
                iLineSide_ID = R1("LineSide_ID")
                strLineSide = Trim(R1("LineSide_Desc"))
                strBin = Trim(R1("WC_Location"))
                iWCLocation_ID = R1("WCLocation_ID")
            Next R1

            Me.lblGroup.Text = "Group: " & strGroup
            Me.lblLine.Text = strLineNumber
            Me.lblLineSide.Text = strLineSide
            Me.lblMachine.Text = "Machine: " & strMachine
            Me.lblUserName.Text = "User: " & strUserName
            Me.lblShift.Text = "Shift: " & iShiftID
            Me.lblWorkDate.Text = "Work Date: " & Format(CDate(strWorkDate), "MM/dd/yyyy")
            Me.lblBin.Text = "BIN: " & strBin

            Return 1
        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
        End Try
    End Function

    '**************************************************************************************************
    Private Sub LoadOpenShipRMAs()
        Dim dt As New DataTable()
        Try
            dt = Me._objHTC.GetHTCOpenShipRMA()
            dt.LoadDataRow(New Object() {"0", "-- SELECT --"}, False)
            With Me.cboOpenShipRMA
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("Open RMA").ToString
                .ValueMember = dt.Columns("WO_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub frmCellShipPallet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer = 0

        Try
            PSS.Core.Highlight.SetHighLight(Me)

            LoadOpenShipRMAs()

            i = CheckIfMachineTiedToLine()
            If i = 0 Then
                MessageBox.Show("Machine is not associated with any 'Line'. Can't continue.", "Validate Computer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.Close()
            ElseIf Me.iGroup_ID <> 79 Then
                MessageBox.Show("Machine is not mapped to HTC Line. Can't continue.", "Validate Computer", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.Close()
            End If

            LoadCellProductionNumbers()
            LoadWeeklyCellProductionNumbers()

            Me.cboOpenShipRMA.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub LoadWeeklyCellProductionNumbers()
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim iUserProd As Integer = 0
        Dim iShiftProd As Integer = 0
        Dim iLineProd As Integer = 0
        Dim iGroupProd As Integer = 0

        Try
            '**********************************************
            'Get production numbers by Line, Shift, User and Group
            dt1 = objMisc.LoadCellProductionNumbers(strWorkDate, iGroup_ID, 1)
            For Each R1 In dt1.Rows
                'get User Production
                If iUserID = R1("User_ID") Then
                    iUserProd += 1
                End If
                'Get Line Production
                If iLine_ID = R1("Line_ID") Then
                    iLineProd += 1
                End If
                'Get Group Production
                If iGroup_ID = R1("Group_ID") Then
                    iGroupProd += 1
                End If
                'Shift Production
                If iShiftID = R1("Shift_ID") Then
                    iShiftProd += 1
                End If
            Next R1

            Me.lblWeeklyUserProd.Text = iUserProd
            Me.lblWeeklyLineProd.Text = iLineProd
            Me.lblWeeklyGroupProd.Text = iGroupProd
            Me.lblWeeklyShiftProd.Text = iShiftProd
            '**********************************************
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            '**********************************************
            dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 1, Me.iGroup_ID)
            Me.grdWeeklyProd.DataSource = Nothing
            Me.grdWeeklyProd.DataSource = dt1.DefaultView
            SetGrdWeeklyProdProperties()
            '**********************************************

        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub LoadCellProductionNumbers()
        Dim dt1 As DataTable
        Dim R1 As DataRow
        Dim iUserProd As Integer = 0
        Dim iShiftProd As Integer = 0
        Dim iLineProd As Integer = 0
        Dim iGroupProd As Integer = 0

        Try
            '**********************************************
            'Get production numbers by Line, Shift, User and Group
            dt1 = objMisc.LoadCellProductionNumbers(strWorkDate, iGroup_ID, 0)
            For Each R1 In dt1.Rows
                'get User Production
                If iUserID = R1("User_ID") Then
                    iUserProd += 1
                End If
                'Get Line Production
                If iLine_ID = R1("Line_ID") Then
                    iLineProd += 1
                End If
                'Get Group Production
                If iGroup_ID = R1("Group_ID") Then
                    iGroupProd += 1
                End If
                'Shift Production
                If iShiftID = R1("Shift_ID") Then
                    iShiftProd += 1
                End If
            Next R1

            Me.lblUserProd.Text = iUserProd
            Me.lblLineProd.Text = iLineProd
            Me.lblGroupProd.Text = iGroupProd
            Me.lblShiftProd.Text = iShiftProd
            '**********************************************
            R1 = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            '**********************************************
            dt1 = objMisc.LoadCellProductionNumbersByModel(strWorkDate, iLine_ID, 0, Me.iGroup_ID)
            Me.grdProd.DataSource = Nothing
            Me.grdProd.DataSource = dt1.DefaultView
            SetGrdProdProperties()
            '**********************************************

        Catch ex As Exception
            Throw ex
        Finally
            R1 = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub SetGrdWeeklyProdProperties()
        Dim iNumOfColumns As Integer = Me.grdProd.Columns.Count
        Dim i As Integer

        With Me.grdWeeklyProd
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next
            'header forecolor
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Body Forecolor
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 100
            .Splits(0).DisplayColumns(2).Width = 48

            .Splits(0).DisplayColumns(0).Visible = False
        End With
        'grdWeeklyProd
    End Sub

    '**************************************************************************************************
    Private Sub SetGrdProdProperties()
        Dim iNumOfColumns As Integer = Me.grdProd.Columns.Count
        Dim i As Integer

        With Me.grdProd
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next
            'header forecolor
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Body Forecolor
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black

            'Set Column Widths
            .Splits(0).DisplayColumns(1).Width = 100
            .Splits(0).DisplayColumns(2).Width = 48

            .Splits(0).DisplayColumns(0).Visible = False
        End With
    End Sub

    '**************************************************************************************************
    Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
        Dim strSN As String = ""
        Dim i As Integer = 0
        Dim iDeviceID As Integer = 0

        Try
            '************************
            'Validations
            If Me.grdPallets.RowCount = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf CInt(Me.grdPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.lstDevices.Items.Count = 0 Then
                'Throw New Exception("No IMEI in the list to remove.")
                Exit Sub
            End If

            '************************
            strSN = InputBox("Enter S/N:", "S/N").Trim
            If strSN = "" Then
                Throw New Exception("Please enter a S/N if you want to remove it from the selected box.")
            End If

            For i = 0 To Me.lstDevices.Items.Count
                If Me.lstDevices.Items.Item(i)("Device_SN").ToString.Trim = strSN Then
                    iDeviceID = CInt(Me.lstDevices.Items.Item(i)("Device_ID").ToString)
                    Exit For
                End If
            Next i

            If iDeviceID > 0 Then
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = Me._objHTC.RemoveSNfromPallet(CInt(Me.grdPallets.Columns("Pallett_id").Value), iDeviceID)
                If i = 0 Then
                    Throw New Exception("S/N entered was not removed from Box.")
                End If

                Me.lblCompletedRMAQty.Text = Me._objHTC.GetTotalUnitsHasGivenShipRMA(Me.cboOpenShipRMA.SelectedItem("RMA"))

                Me.RefreshSNList()
                Me.LoadCellProductionNumbers()
                Me.LoadWeeklyCellProductionNumbers()
            Else
                Throw New Exception("S/N was not listed.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub btnClearAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
        Dim str_sn As String = ""
        Dim i As Integer = 0

        If MessageBox.Show("Are you sure you want to remove all devices from this Box?", "Clear All S/Ns", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If

        Try
            '************************
            'Validations
            If Me.grdPallets.RowCount = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf CInt(Me.grdPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.lstDevices.Items.Count = 0 Then
                'Throw New Exception("No IMEI in the list to remove.")
                Exit Sub
            End If

            '************************
            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            i = Me._objHTC.RemoveSNfromPallet(CInt(Me.grdPallets.Columns("Pallett_id").Value), )
            If i = 0 Then
                Throw New Exception("No SNs were removed from box.")
            End If

            Me.lblCompletedRMAQty.Text = Me._objHTC.GetTotalUnitsHasGivenShipRMA(Me.cboOpenShipRMA.SelectedItem("RMA"))

            RefreshSNList()
            Me.LoadCellProductionNumbers()
            Me.LoadWeeklyCellProductionNumbers()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub cboOpenShipRMA_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboOpenShipRMA.SelectionChangeCommitted
        Dim i As Integer = 0
        Dim strShortModelName As String = ""

        Try
            '*****************************
            Me.cmbShipType.Text = ""
            Me.cmbShipType.SelectedIndex = -1
            Me.grdPallets.ClearFields()
            Me.pnlShipType.Visible = False
            Me.PanelPalletList.Visible = False
            Me.panelPallet.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.btnCreateBoxID.Visible = False
            Me.lblRMAQty.Text = ""
            Me.lblCompletedRMAQty.Text = ""

            If Me.cboOpenShipRMA.SelectedValue = 0 Then
                Exit Sub
            Else
                Me.pnlShipType.Visible = True
                Me.lblRMAQty.Text = Me.cboOpenShipRMA.SelectedItem("RMA QTY")
            End If

            '*****************************
            If Me.cboOpenShipRMA.SelectedItem("Model_ID") = 0 Then
                Exit Sub
            End If

            'strShortModelName = objMisc.GetShortModelName(Me.cboOpenShipRMA.SelectedItem("Model_ID"))
            strShortModelName = Me.cboOpenShipRMA.SelectedItem("Model_MotoSku")
            If strShortModelName.Trim = "" Then
                strShortModelName = InputBox("This Model does not have a 'Short Name'. Please input it now to continue.")
                If strShortModelName.Trim = "" Then
                    Me.cboOpenShipRMA.SelectedValue = 0
                    Throw New Exception("You must input a 'Short Model Name'. Can't continue.")
                Else
                    i = objMisc.SaveShortModelName(Me.cboOpenShipRMA.SelectedItem("Model_ID"), strShortModelName)
                End If
            End If

            Me.lblCompletedRMAQty.Text = Me._objHTC.GetTotalUnitsHasGivenShipRMA(Me.cboOpenShipRMA.SelectedItem("RMA"))
            'Me.lblTAT.Text = DateDiff(DateInterval.Day, Me.cboOpenShipRMA.SelectedItem("ReceiptDate"), Me.cboOpenShipRMA.SelectedItem("Today"))
            Me.lblTAT.Text = 0

            Me.cmbShipType.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub cmbShipType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbShipType.SelectedIndexChanged
        Dim strGroupChar As String = Me.iGroup_ID.ToString

        Try
            '***************************************
            Me.PanelPalletList.Visible = False
            Me.lblPalletName.Text = ""
            Me.txtDevSN.Text = ""
            Me.lstDevices.DataSource = Nothing
            Me.btnCreateBoxID.Visible = False

            RefreshPalletGrid(strGroupChar)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Select Ship Type", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub RefreshPalletGrid(ByVal strGroupChar As String, _
                                  Optional ByVal iPallet_ID As Integer = 0, _
                                  Optional ByVal strPalletName As String = "")
        Dim dt1 As DataTable
        Try
            If Me.cboOpenShipRMA.SelectedValue = 0 Then
                Exit Sub
            End If
            If Me.cboOpenShipRMA.SelectedItem("Model_ID") = 0 Then
                Exit Sub
            ElseIf Me.cboOpenShipRMA.SelectedItem("Model_MotoSku").ToString.Trim.Length = 0 Then
                Exit Sub
            End If

            Me.grdPallets.ClearFields()

            'Get all open pallets for a model
            dt1 = Me._objHTC.GetOpenPallets(strGroupChar, Me.cboOpenShipRMA.SelectedItem("Model_MotoSku"), Me.cboOpenShipRMA.SelectedItem("Model_ID"), Me.cboOpenShipRMA.SelectedItem("RMA").ToString.Trim.ToUpper, Me.cmbShipType.SelectedIndex)

            'A max of 4 open pallets allowed at one time.
            If dt1.Rows.Count < 4 Then
                Me.btnCreateBoxID.Visible = True
            Else
                Me.btnCreateBoxID.Visible = False
            End If

            Me.PanelPalletList.Visible = True
            Me.grdPallets.DataSource = dt1.DefaultView
            SetGridProperties(iPallet_ID)
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub SetGridProperties(Optional ByVal iPallet_ID As Integer = 0)
        Dim iNumOfColumns As Integer = Me.grdPallets.Columns.Count
        Dim i As Integer

        With Me.grdPallets
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(i).Visible = False
            Next
            'header forecolor
            .Splits(0).DisplayColumns(0).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).HeadingStyle.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).HeadingStyle.ForeColor = .ForeColor.Black

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Body Forecolor
            .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
            .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black

            'Set Column Widths
            .Splits(0).DisplayColumns("Box Name").Width = 150

            'Make some columns invisible
            .Splits(0).DisplayColumns("Box Name").Visible = True

            .AlternatingRows = True

            For i = 0 To .RowCount - 1
                If .Columns("Pallett_ID").CellValue(i) = iPallet_ID Then
                    Exit Sub
                End If
                .MoveNext()
            Next i
        End With
    End Sub

    '**************************************************************************************************
    Private Sub cmdCreatePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click
        Dim strGroupChar As String = Me.iGroup_ID.ToString
        Dim strPalletName As String = ""
        Dim iPallet_ID As Integer = 0

        Try
            '************************
            'Validations
            If Me.cboOpenShipRMA.SelectedValue = 0 Then
                Throw New Exception("Please select RMA.")
            ElseIf Me.cmbShipType.SelectedItem.Trim = "" Then
                Throw New Exception("Ship Type is not selected.")
            End If
            '************************
            strPalletName = Me.ConstructPalletName()
            If strPalletName.Trim = "" Then
                Throw New Exception("Fail to construct pallet name.")
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            iPallet_ID = objMisc.CreatePallet(strPalletName, Me.cmbShipType.SelectedItem.Trim, "", Me.cboOpenShipRMA.SelectedItem("Model_ID"), Me._HTC_CUSTOMERID, Me.cboOpenShipRMA.SelectedItem("RMA"), Me.cboOpenShipRMA.SelectedValue)
            Me.btnCreateBoxID.Visible = False
            Me.panelPallet.Visible = True
            Me.lblPalletName.Text = strPalletName

            RefreshPalletGrid(strGroupChar, iPallet_ID)
            Me.RefreshSNList()
            Me.txtDevSN.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Box", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '**************************************************************************************************
    Private Function ConstructPalletName() As String
        Dim strGroupChar As String = Me.iGroup_ID.ToString
        Dim strdt As String = Format(CDate(strWorkDate), "MMddyy")
        Dim strLastAlphaInPallet As String = ""
        Dim strShipTypeChars As String = ""
        Dim strPalletName As String = ""

        Try
            strShipTypeChars = Microsoft.VisualBasic.Left(Me.cmbShipType.SelectedItem.Trim, 3)

            If Me.cboOpenShipRMA.SelectedValue = 0 Then
                Throw New Exception("Please select RMA.")
            End If

            'Get the last Alphabet 
            strLastAlphaInPallet = objMisc.GetLastCharFromPalletName(strGroupChar, strdt)
            strPalletName = strGroupChar & Me.cboOpenShipRMA.SelectedItem("Model_MotoSku") & strShipTypeChars & strdt & strLastAlphaInPallet

            Return strPalletName
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    '**************************************************************************************************
    Private Sub btnCloseBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
        Dim i As Integer = 0
        Dim strGroupChar As String = Microsoft.VisualBasic.Right(Trim(strGroup), 1)
        Dim iWO_ID As Integer = 0
        Dim iShipTypeIndex As Integer = -1

        Try
            '************************
            If MessageBox.Show("Are you sure you want to close this box?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            '************************
            'Validations
            If CInt(Me.grdPallets.Columns("Pallett_id").Value) = 0 Then
                Throw New Exception("Box name is not selected.")
            ElseIf Me.grdPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Throw New Exception("Box name is not selected.")
            End If

            If Me.lstDevices.Items.Count = 0 Then
                Throw New Exception("There are no devices on this box.")
            End If

            Me.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            '************************
            i = objMisc.ClosePallet(Me._HTC_CUSTOMERID, CInt(Me.grdPallets.Columns("Pallett_id").Value), Me.grdPallets.Columns("Box Name").Value, Me.lstDevices.Items.Count, Me.grdPallets.Columns("Pallet_ShipType").Value, 0, )
            If i = 0 Then
                Throw New Exception("Box was not closed due to an error. Please contact IT.")
            End If

            Me._objHTC.PushPalletToNextWorkingStation(CInt(Me.grdPallets.Columns("Pallett_id").Value), "SHIPPING")
            Me._objHTC.PrintHTCBoxLabel(Me.grdPallets.Columns("Pallett_id").Value)
            '************************

            'Refresh RMA
            iWO_ID = Me.cboOpenShipRMA.SelectedValue
            iShipTypeIndex = Me.cmbShipType.SelectedIndex
            LoadOpenShipRMAs()
            Me.cboOpenShipRMA.SelectedValue = iWO_ID
            Me.cmbShipType.SelectedIndex = iShipTypeIndex

            'Refresh Pallet (Box) 
            RefreshPalletGrid(strGroupChar)

            '******************************
            'Reset Screen control properties.
            Me.lblPalletName.Text = ""
            Me.lblCount.Text = 0
            Me.lstDevices.DataSource = Nothing
            Me.panelPallet.Visible = False
            '******************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub InitializePalletVar()
        Dim strShipType As String = ""
        Dim i As Integer = 0
        Dim booFound As Boolean = False

        Try
            If Me.grdPallets.Columns.Count = 0 Then
                Exit Sub
            End If
            If Me.grdPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Exit Sub
            End If

            Me.lblPalletName.Text = Me.grdPallets.Columns("Box Name").Value.ToString

            Select Case Me.grdPallets.Columns("Pallet_ShipType").Value.ToString
                Case "0"
                    strShipType = "REFURBISHED"
                Case "1"
                    strShipType = "RUR"
            End Select

            For i = 0 To Me.cmbShipType.Items.Count - 1
                If Me.cmbShipType.Items.Item(i).ToString.Trim = strShipType Then
                    Me.cmbShipType.SelectedIndex = i
                    booFound = True
                    Exit For
                End If
            Next i

            If booFound = False Then
                Me.cmbShipType.Text = ""
                Me.cmbShipType.SelectedIndex = -1
                Me.cboOpenShipRMA.SelectedValue = 0
                Throw New Exception("Can not define ship type.")
            End If

            Me.panelPallet.Visible = True
            Me.RefreshSNList()

            '*******************************************

            Me.txtDevSN.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Box", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub grdPallets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPallets.Click
        Me.btnCreateBoxID.Visible = False
        InitializePalletVar()
    End Sub

    '**************************************************************************************************
    Private Sub grdPallets_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPallets.RowColChange
        InitializePalletVar()
    End Sub

    '**************************************************************************************************
    Private Sub RefreshSNList()
        Dim dt1 As DataTable
        Dim iPallet_ID As Integer = 0
        Dim strPalletName As String = ""

        Try
            '************************
            'Validations
            iPallet_ID = CInt(Me.grdPallets.Columns("Pallett_ID").Value.ToString)
            strPalletName = Me.grdPallets.Columns("Box Name").Value.ToString.Trim

            If iPallet_ID = 0 Then
                Throw New Exception("Pallet is not selected.")
            ElseIf strPalletName.Trim = "" Then
                Throw New Exception("Pallet is not selected.")
            End If

            '*******************************************
            'Get all devices add put them in them in list box for a pallet
            dt1 = objMisc.GetAllSNsForPallet(iPallet_ID)
            Me.lstDevices.DataSource = dt1.DefaultView
            Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
            Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString

            '*******************************************
            Me.lblCount.Text = dt1.Rows.Count
        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt1)
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub ProcessSN()
        Dim i As Integer = 0
        Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
        Dim dtDevice As DataTable

        Try
            If Me.cboOpenShipRMA.SelectedValue = 0 Then
                Throw New Exception("Please select RMA.")
            ElseIf Me.cmbShipType.SelectedItem.Trim = "" Then
                Throw New Exception("Ship Type is not selected.")
            End If

            Me.lblCompletedRMAQty.Text = Me._objHTC.GetTotalUnitsHasGivenShipRMA(Me.cboOpenShipRMA.SelectedItem("RMA"))
            '************************
            'Validations
            If CInt(Me.grdPallets.Columns("Pallett_ID").Value) = 0 Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Me.grdPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                Throw New Exception("Box Name is not selected.")
            ElseIf Trim(Me.txtDevSN.Text) = "" Then
                Exit Sub
            ElseIf Me.txtDevSN.Text.Trim.StartsWith("TF") = False Then
                MsgBox("SN must start with TF.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            ElseIf Me.lstDevices.Items.Count >= 50 Then
                MsgBox("You have reached the box size of 50 units. Please close this box and start a new box.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            ElseIf Me.lblCompletedRMAQty.Text.Trim.Length > 0 And Me.lblRMAQty.Text.Trim.Length > 0 AndAlso CInt(Me.lblCompletedRMAQty.Text) >= CInt(Me.lblRMAQty.Text) Then
                MsgBox("You have reached the RMA quantity. Please close this box and start a new RMA.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            End If

            '***************************************************
            'Step 1: Check if the Device is already scanned in
            For i = 0 To Me.lstDevices.Items.Count - 1
                If UCase(Trim(Me.lstDevices.Items(i).ToString)) = strSN Then
                    MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                    Exit Sub
                End If
            Next

            '***************************************************
            'Added by Lan on 09/16/2007
            'Prevent the user from adding more devices to closed pallet.
            'This happen when a pallet open at the 2 computer, computer 1 
            '  close the pallet and refesh the screen while the other computer screen 
            '  did not get refresh. This check will force the user to refresh the screen.
            '***************************************************
            i = Me.objMisc.IsPalletClosed(CInt(Me.grdPallets.Columns("Pallett_ID").Value))
            If i = -1 Then
                MsgBox("Box ID does not exist.", MsgBoxStyle.Information, "CheckPalletAlreadyClosed")
                Exit Sub
            ElseIf i = 1 Then
                MsgBox("This ""Box"" was closed by other user. Please refesh the screen to get the update.", MsgBoxStyle.Information, "CheckPalletAlreadyClosed")
                Exit Sub
            End If
            i = 0

            dtDevice = Me._objHTC.GetHTC_TdeviceInfo_InWIP(Me.txtDevSN.Text.Trim)

            If dtDevice.Rows.Count > 1 Then
                MsgBox("This device existed twice in the system. Please contact IT.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            ElseIf dtDevice.Rows.Count = 0 Then
                MsgBox("This device does not exist in the system or already ship.", MsgBoxStyle.Information, "Information")
                Me.txtDevSN.SelectAll()
                Exit Sub
            Else
                If Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                    MsgBox("This device already has assigned into a box ID (" & dtDevice.Rows(0)("Pallett_ID") & ").", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf dtDevice.Rows(0)("Model_ID") <> CInt(Me.grdPallets.Columns("Model_ID").Value) Then
                    MsgBox("This device is of a different model. Can't put into this box.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf IsDBNull(dtDevice.Rows(0)("Device_DateBill")) Then
                    MsgBox("This device has not been billed.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf Me._objHTC.CheckDeviceShipType(CInt(Me.grdPallets.Columns("Pallet_ShipType").Value), dtDevice.Rows(0)("Device_ID")) = False Then
                    Me.txtDevSN.SelectAll()
                    'ElseIf Me._objHTC.IsRF_FinalTestPassed(dtDevice.Rows(0)("Device_ID")) = False Then
                    '    MsgBox("This device did not pass RF and Final test.", MsgBoxStyle.Information, "Information")
                    'Me.txtDevIMEI.Text = ""
                ElseIf Me.cmbShipType.SelectedItem.ToString.Trim.ToUpper = "REFURBISHED" And dtDevice.Rows(0)("Discrepancy Reason").ToString.Trim.Length > 0 Then
                    MsgBox("This device is a discrepant unit (" & dtDevice.Rows(0)("Discrepancy Reason").ToString.Trim & ").", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf Me._SCREEN_NAME.ToUpper <> dtDevice.Rows(0)("hd_Station").ToString.Trim.ToUpper Then
                    MsgBox("This device is at " & dtDevice.Rows(0)("hd_Station").ToString.Trim & ".", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.Text = ""
                ElseIf CInt(Me.grdPallets.Columns("Pallet_ShipType").Value) = 0 AndAlso Me._objHTC.IsStationTestPassed(dtDevice.Rows(0)("Device_ID"), 3) = False Then     'must Final passed
                    Me.txtDevSN.Text = ""
                Else
                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    '***************************************************
                    'if above all is fine then add it to the list and update the database
                    i = Me._objHTC.UpdateDeviceWithPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.grdPallets.Columns("Pallett_ID").Value), Me.iShiftID, Me.iUserID, iWCLocation_ID, iLine_ID, iGroup_ID, Me.cboOpenShipRMA.SelectedValue)

                    '***************************************************
                    Me.lblCompletedRMAQty.Text = Me._objHTC.GetTotalUnitsHasGivenShipRMA(Me.cboOpenShipRMA.SelectedItem("RMA"))
                    Me.RefreshSNList()
                    Me.LoadCellProductionNumbers()
                    Me.LoadWeeklyCellProductionNumbers()
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                End If
            End If

            ''***************************************************
            ''Step 1: Check REF/RUR/RTM, RUR/RTM with parts
            'strShipTypeChars = Microsoft.VisualBasic.Left(Me.cmbShipType.SelectedItem.ToString.Trim, 3)
            'i = objMisc.CheckDevice_REF_RUR_RTM(strSN, strShipTypeChars, Me._HTC_CUSTOMERID)
            ''***************************************************

            ''***************************************************
            ''Added on 10/02/2007. Allow RUR/RTM Staging Device
            'If strShipTypeChars = "REF" Then
            '    '***************************************************
            '    'Step 4: Check if this device belongs to group Pallett is tied to
            '    'i = objMisc.CheckDeviceGroup(strSN, iGroup_ID)
            'End If
            'i = 0

            ''***************************************************
            ''Step 5: Check device model
            'i = objMisc.CheckDeviceModel(strSN, Me.cboOpenShipRMA.SelectedItem("Model_MotoSku").ToString.Trim)
            'If i = 0 Then
            '    MsgBox("This device is of a different model. Can't put it on this box.", MsgBoxStyle.Information, "CheckDeviceModel")
            '    Me.txtDevIMEI.Text = ""
            '    Me.txtDevIMEI.Focus()
            '    Exit Sub
            'End If

            ''***************************************************
            ''Step 6: Check if a wrong sku length Device is being scanned in to this pallet
            'If Me.cmbShipType.SelectedItem.ToString.Trim = "REFURBISHED" Then
            '    'strSkuChar = Microsoft.VisualBasic.Left(Trim(strSkuLength), 1)
            '    i = Me._objHTC.CheckDeviceRMA(strSN, strSkuChar)
            '    If i = 0 Then
            '        MsgBox("This device is of wrong SKU length. Can't put it on this pallet.", MsgBoxStyle.Information, "CheckDeviceSKULength")
            '        Me.txtDevIMEI.Text = ""
            '        Me.txtDevIMEI.Focus()
            '        Exit Sub
            '    End If
            'End If

            ''***************************************************
            ''STEP 7: Check if the QC Check needs to be done
            'iQCChkFlg = objMisc.IsQCCheckNeeded(strSN)
            ''***************************************************
            ''Step 7: Check if Device has been passed in all QC Steps
            'If iQCChkFlg = 0 Then
            '    If strShipType = "REFURBISHED" Then
            '        'Check Functional, FQA, Cosmetic
            '        objMisc.CheckDeviceQC(strSN)

            '        'Added by Lan on 10/03/2007. 
            '        'Prevent failed AQL unit to be added to pass pallet
            '        objQC = New PSS.Data.Buisness.QC()
            '        booAQLFail = objQC.CheckAQLFailed(strSN)
            '        If booAQLFail = True Then
            '            Throw New Exception("Device has been failed at AQL test.")
            '        End If
            '    End If
            'End If

        Catch ex As Exception
            MessageBox.Show("ProcessSN: " & ex.ToString, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtDevSN.Text = ""
            Me.txtDevSN.Focus()
        Finally
            'objQC = Nothing
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub txtDevSN_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
        Try
            If e.KeyValue = 13 Then
                If Me.txtDevSN.Text.Trim = "" Then
                    'MessageBox.Show("Please scan in the 'Device SN' first.", "Scan Device SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                Else
                    ProcessSN()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.txtDevSN.Focus()
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub txtDevSN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDevSN.KeyPress
        Try
            If Not (e.KeyChar.IsLetterOrDigit(e.KeyChar) Or e.KeyChar.IsControl(e.KeyChar)) Then
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "txtSN_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub cmdReopenPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenBox.Click
        Dim str_pallet As String = ""
        Dim i As Integer = 0
        Dim strGroupChar As String = Me.iGroup_ID.ToString
        Dim iWO_ID As Integer = 0
        Dim iShipTypeIndex As Integer = -1

        Try
            '************************
            str_pallet = InputBox("Enter Box ID.", "Reopen Box")
            If str_pallet = "" Then
                Throw New Exception("Please enter a Box ID if you want to re-open it.")
            End If

            i = objMisc.ReopenPallet(str_pallet)
            If i = 0 Then
                Throw New Exception("Box was not reopened.")
            End If
            i = Me._objHTC.MovePalletBackToPackagingStation(str_pallet)
            If i = 0 Then
                Throw New Exception("Box was not reopened.")
            End If

            'Refresh RMA
            iWO_ID = Me.cboOpenShipRMA.SelectedValue
            iShipTypeIndex = Me.cmbShipType.SelectedIndex
            LoadOpenShipRMAs()
            Me.cboOpenShipRMA.SelectedValue = iWO_ID
            Me.cmbShipType.SelectedIndex = iShipTypeIndex

            'Refresh Pallet( Box )
            RefreshPalletGrid(strGroupChar, )

            '************************
            Me.lstDevices.DataSource = Nothing
            Me.lblCount.Text = "0"
            Me.lblPalletName.Text = ""
            Me.panelPallet.Visible = False
            '************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reopen Box.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
        Dim str_pallet As String = ""
        Dim iPalletID As Integer = 0

        Try
            str_pallet = InputBox("Enter Box Name.", "Reprint Box Label")
            If str_pallet = "" Then
                Throw New Exception("Please enter a Box Name if you want to reprint the box label.")
            End If

            Me.btnReprintBoxLabel.Enabled = False
            Cursor.Current = Cursors.WaitCursor

            iPalletID = objMisc.GetPalletID(Trim(str_pallet), 1)
            If iPalletID > 0 Then
                Me._objHTC.PrintHTCBoxLabel(iPalletID)
            Else
                Throw New Exception("Box Name was not defined in system.")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Reprint Box Label.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.btnReprintBoxLabel.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '**************************************************************************************************
    Private Sub btnDeleteCartonBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBox.Click
        Dim i As Integer = 0

        Try
            If CInt(Me.grdPallets.Columns("Pallett_ID").Value) = 0 Then
                Exit Sub
            End If
            If MessageBox.Show("Are you sure you want to delete this Box?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = objMisc.DeletePallet(CInt(Me.grdPallets.Columns("Pallett_ID").Value))
                MessageBox.Show("Box has been deleted.")

                RefreshPalletGrid(Me.iGroup_ID)

                Me.lblPalletName.Text = ""
                Me.lblPalletName.Text = ""
                Me.panelPallet.Visible = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        Finally
            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    '**************************************************************************************************



End Class

