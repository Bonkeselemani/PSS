Public Class frmMessReports
    Inherits System.Windows.Forms.Form

    Private _objMessReports As PSS.Data.Buisness.MessReports
    Private _iUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser
    Private _strWorkDate As String = PSS.Core.[Global].ApplicationUser.Workdate

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._objMessReports = New PSS.Data.Buisness.MessReports()
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblHeader As System.Windows.Forms.Label
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents lstItems As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbReport As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCreateReport As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents radioSN As System.Windows.Forms.RadioButton
    Friend WithEvents radioTray As System.Windows.Forms.RadioButton
    Friend WithEvents radioShipID As System.Windows.Forms.RadioButton
    Friend WithEvents radioWO As System.Windows.Forms.RadioButton
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCreateDisRpt As System.Windows.Forms.Button
    Friend WithEvents dtpShipFr As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpShipTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkInWIP As System.Windows.Forms.CheckBox
    Friend WithEvents grpAmericanMsgWIPDetailRpt As System.Windows.Forms.GroupBox
    Friend WithEvents dtpAmericanMsgWIPCutoffDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAmericanMsgWIPCutoffDate As System.Windows.Forms.Label
    Friend WithEvents btnAmericanMsgWIPDetailRpt As System.Windows.Forms.Button
    Friend WithEvents btnUnicationDashboardRpt As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblDevQty As System.Windows.Forms.Label
    Friend WithEvents lblScanQty As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnWIPRpt As System.Windows.Forms.Button
    Friend WithEvents btnReceiptByWeek As System.Windows.Forms.Button
    Friend WithEvents btnEstimatedWeeklyShipmentDetail As System.Windows.Forms.Button
    Friend WithEvents btnDailyWeeklyMonthlyGoal As System.Windows.Forms.Button
    Friend WithEvents btnSNCCFreqBaudChange As System.Windows.Forms.Button
    Friend WithEvents btnCreateChangeSNCCFreq As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.lstItems = New System.Windows.Forms.ListBox()
        Me.radioSN = New System.Windows.Forms.RadioButton()
        Me.radioTray = New System.Windows.Forms.RadioButton()
        Me.radioShipID = New System.Windows.Forms.RadioButton()
        Me.radioWO = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblScanQty = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.lblDevQty = New System.Windows.Forms.Label()
        Me.cmbReport = New System.Windows.Forms.ComboBox()
        Me.cmdCreateReport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.chkInWIP = New System.Windows.Forms.CheckBox()
        Me.dtpShipTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpShipFr = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnCreateDisRpt = New System.Windows.Forms.Button()
        Me.grpAmericanMsgWIPDetailRpt = New System.Windows.Forms.GroupBox()
        Me.dtpAmericanMsgWIPCutoffDate = New System.Windows.Forms.DateTimePicker()
        Me.lblAmericanMsgWIPCutoffDate = New System.Windows.Forms.Label()
        Me.btnAmericanMsgWIPDetailRpt = New System.Windows.Forms.Button()
        Me.btnUnicationDashboardRpt = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCreateChangeSNCCFreq = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnWIPRpt = New System.Windows.Forms.Button()
        Me.btnReceiptByWeek = New System.Windows.Forms.Button()
        Me.btnEstimatedWeeklyShipmentDetail = New System.Windows.Forms.Button()
        Me.btnDailyWeeklyMonthlyGoal = New System.Windows.Forms.Button()
        Me.btnSNCCFreqBaudChange = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.grpAmericanMsgWIPDetailRpt.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.BackColor = System.Drawing.Color.Salmon
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.ForeColor = System.Drawing.Color.White
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(664, 20)
        Me.lblHeader.TabIndex = 84
        Me.lblHeader.Text = "MESSAGING REPORTS"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(9, 102)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(119, 20)
        Me.txtItem.TabIndex = 85
        Me.txtItem.Text = ""
        '
        'lstItems
        '
        Me.lstItems.Location = New System.Drawing.Point(9, 125)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(119, 225)
        Me.lstItems.TabIndex = 86
        '
        'radioSN
        '
        Me.radioSN.Location = New System.Drawing.Point(10, 21)
        Me.radioSN.Name = "radioSN"
        Me.radioSN.Size = New System.Drawing.Size(118, 13)
        Me.radioSN.TabIndex = 87
        Me.radioSN.Text = "Serial Number"
        '
        'radioTray
        '
        Me.radioTray.Location = New System.Drawing.Point(10, 38)
        Me.radioTray.Name = "radioTray"
        Me.radioTray.Size = New System.Drawing.Size(118, 21)
        Me.radioTray.TabIndex = 88
        Me.radioTray.Text = "Tray ID"
        '
        'radioShipID
        '
        Me.radioShipID.Location = New System.Drawing.Point(10, 77)
        Me.radioShipID.Name = "radioShipID"
        Me.radioShipID.Size = New System.Drawing.Size(118, 21)
        Me.radioShipID.TabIndex = 89
        Me.radioShipID.Text = "Ship ID"
        '
        'radioWO
        '
        Me.radioWO.Location = New System.Drawing.Point(10, 61)
        Me.radioWO.Name = "radioWO"
        Me.radioWO.Size = New System.Drawing.Size(118, 13)
        Me.radioWO.TabIndex = 90
        Me.radioWO.Text = "WO ID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.Label6, Me.lblScanQty, Me.txtItem, Me.radioWO, Me.radioSN, Me.lstItems, Me.radioTray, Me.btnClear, Me.btnClearAll, Me.lblDevQty, Me.cmbReport, Me.cmdCreateReport, Me.Label1, Me.radioShipID})
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(6, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(234, 448)
        Me.GroupBox1.TabIndex = 91
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select Item type and Scan Items"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Black
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Lime
        Me.Label7.Location = New System.Drawing.Point(144, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 99
        Me.Label7.Text = "Device Qty"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Lime
        Me.Label6.Location = New System.Drawing.Point(144, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Scan Qty"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblScanQty
        '
        Me.lblScanQty.BackColor = System.Drawing.Color.Black
        Me.lblScanQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScanQty.ForeColor = System.Drawing.Color.Lime
        Me.lblScanQty.Location = New System.Drawing.Point(144, 119)
        Me.lblScanQty.Name = "lblScanQty"
        Me.lblScanQty.Size = New System.Drawing.Size(80, 24)
        Me.lblScanQty.TabIndex = 97
        Me.lblScanQty.Text = "0"
        Me.lblScanQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Red
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Location = New System.Drawing.Point(144, 256)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(80, 25)
        Me.btnClear.TabIndex = 95
        Me.btnClear.Text = "CLEAR ONE"
        '
        'btnClearAll
        '
        Me.btnClearAll.BackColor = System.Drawing.Color.Red
        Me.btnClearAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearAll.ForeColor = System.Drawing.Color.White
        Me.btnClearAll.Location = New System.Drawing.Point(144, 208)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClearAll.Size = New System.Drawing.Size(80, 25)
        Me.btnClearAll.TabIndex = 96
        Me.btnClearAll.Text = "CLEAR ALL"
        '
        'lblDevQty
        '
        Me.lblDevQty.BackColor = System.Drawing.Color.Black
        Me.lblDevQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDevQty.ForeColor = System.Drawing.Color.Lime
        Me.lblDevQty.Location = New System.Drawing.Point(144, 32)
        Me.lblDevQty.Name = "lblDevQty"
        Me.lblDevQty.Size = New System.Drawing.Size(80, 24)
        Me.lblDevQty.TabIndex = 96
        Me.lblDevQty.Text = "0"
        Me.lblDevQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbReport
        '
        Me.cmbReport.Location = New System.Drawing.Point(8, 371)
        Me.cmbReport.Name = "cmbReport"
        Me.cmbReport.Size = New System.Drawing.Size(216, 21)
        Me.cmbReport.TabIndex = 92
        '
        'cmdCreateReport
        '
        Me.cmdCreateReport.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdCreateReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCreateReport.ForeColor = System.Drawing.Color.Black
        Me.cmdCreateReport.Location = New System.Drawing.Point(8, 403)
        Me.cmdCreateReport.Name = "cmdCreateReport"
        Me.cmdCreateReport.Size = New System.Drawing.Size(216, 32)
        Me.cmdCreateReport.TabIndex = 93
        Me.cmdCreateReport.Text = "Create Report"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(8, 357)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Report:"
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.Color.LightSteelBlue
        Me.cmdExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.Location = New System.Drawing.Point(590, 452)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(56, 24)
        Me.cmdExit.TabIndex = 94
        Me.cmdExit.Text = "Exit"
        '
        'chkInWIP
        '
        Me.chkInWIP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInWIP.ForeColor = System.Drawing.Color.CadetBlue
        Me.chkInWIP.Location = New System.Drawing.Point(304, 64)
        Me.chkInWIP.Name = "chkInWIP"
        Me.chkInWIP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.chkInWIP.Size = New System.Drawing.Size(81, 28)
        Me.chkInWIP.TabIndex = 70
        Me.chkInWIP.Text = "In WIP (Optional)"
        Me.chkInWIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkInWIP.Visible = False
        '
        'dtpShipTo
        '
        Me.dtpShipTo.CustomFormat = "yyyy-MM-dd"
        Me.dtpShipTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpShipTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpShipTo.Location = New System.Drawing.Point(272, 8)
        Me.dtpShipTo.Name = "dtpShipTo"
        Me.dtpShipTo.Size = New System.Drawing.Size(120, 21)
        Me.dtpShipTo.TabIndex = 68
        Me.dtpShipTo.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(208, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpShipFr
        '
        Me.dtpShipFr.CustomFormat = "yyyy-MM-dd"
        Me.dtpShipFr.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpShipFr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpShipFr.Location = New System.Drawing.Point(80, 8)
        Me.dtpShipFr.Name = "dtpShipFr"
        Me.dtpShipFr.Size = New System.Drawing.Size(120, 21)
        Me.dtpShipFr.TabIndex = 66
        Me.dtpShipFr.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(0, 10)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 16)
        Me.Label12.TabIndex = 67
        Me.Label12.Text = "From Date:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCreateDisRpt
        '
        Me.btnCreateDisRpt.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCreateDisRpt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateDisRpt.ForeColor = System.Drawing.Color.White
        Me.btnCreateDisRpt.Location = New System.Drawing.Point(16, 64)
        Me.btnCreateDisRpt.Name = "btnCreateDisRpt"
        Me.btnCreateDisRpt.Size = New System.Drawing.Size(280, 24)
        Me.btnCreateDisRpt.TabIndex = 3
        Me.btnCreateDisRpt.Text = "Create Abacus/PSS Discrepancy Rpt"
        Me.btnCreateDisRpt.Visible = False
        '
        'grpAmericanMsgWIPDetailRpt
        '
        Me.grpAmericanMsgWIPDetailRpt.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpAmericanMsgWIPCutoffDate, Me.lblAmericanMsgWIPCutoffDate, Me.btnAmericanMsgWIPDetailRpt})
        Me.grpAmericanMsgWIPDetailRpt.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAmericanMsgWIPDetailRpt.ForeColor = System.Drawing.Color.White
        Me.grpAmericanMsgWIPDetailRpt.Location = New System.Drawing.Point(245, 23)
        Me.grpAmericanMsgWIPDetailRpt.Name = "grpAmericanMsgWIPDetailRpt"
        Me.grpAmericanMsgWIPDetailRpt.Size = New System.Drawing.Size(411, 49)
        Me.grpAmericanMsgWIPDetailRpt.TabIndex = 97
        Me.grpAmericanMsgWIPDetailRpt.TabStop = False
        Me.grpAmericanMsgWIPDetailRpt.Text = "AM WIP Detail Report"
        '
        'dtpAmericanMsgWIPCutoffDate
        '
        Me.dtpAmericanMsgWIPCutoffDate.CustomFormat = "yyyy-MM-dd"
        Me.dtpAmericanMsgWIPCutoffDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAmericanMsgWIPCutoffDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAmericanMsgWIPCutoffDate.Location = New System.Drawing.Point(126, 18)
        Me.dtpAmericanMsgWIPCutoffDate.Name = "dtpAmericanMsgWIPCutoffDate"
        Me.dtpAmericanMsgWIPCutoffDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpAmericanMsgWIPCutoffDate.TabIndex = 66
        Me.dtpAmericanMsgWIPCutoffDate.Value = New Date(2007, 3, 16, 0, 0, 0, 0)
        '
        'lblAmericanMsgWIPCutoffDate
        '
        Me.lblAmericanMsgWIPCutoffDate.BackColor = System.Drawing.Color.Transparent
        Me.lblAmericanMsgWIPCutoffDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmericanMsgWIPCutoffDate.ForeColor = System.Drawing.Color.Yellow
        Me.lblAmericanMsgWIPCutoffDate.Location = New System.Drawing.Point(8, 20)
        Me.lblAmericanMsgWIPCutoffDate.Name = "lblAmericanMsgWIPCutoffDate"
        Me.lblAmericanMsgWIPCutoffDate.Size = New System.Drawing.Size(120, 16)
        Me.lblAmericanMsgWIPCutoffDate.TabIndex = 67
        Me.lblAmericanMsgWIPCutoffDate.Text = "WIP Cutoff Date:"
        Me.lblAmericanMsgWIPCutoffDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAmericanMsgWIPDetailRpt
        '
        Me.btnAmericanMsgWIPDetailRpt.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnAmericanMsgWIPDetailRpt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAmericanMsgWIPDetailRpt.ForeColor = System.Drawing.Color.Black
        Me.btnAmericanMsgWIPDetailRpt.Location = New System.Drawing.Point(264, 16)
        Me.btnAmericanMsgWIPDetailRpt.Name = "btnAmericanMsgWIPDetailRpt"
        Me.btnAmericanMsgWIPDetailRpt.Size = New System.Drawing.Size(120, 24)
        Me.btnAmericanMsgWIPDetailRpt.TabIndex = 3
        Me.btnAmericanMsgWIPDetailRpt.Text = "Create Report"
        '
        'btnUnicationDashboardRpt
        '
        Me.btnUnicationDashboardRpt.BackColor = System.Drawing.Color.SteelBlue
        Me.btnUnicationDashboardRpt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnicationDashboardRpt.ForeColor = System.Drawing.Color.White
        Me.btnUnicationDashboardRpt.Location = New System.Drawing.Point(16, 120)
        Me.btnUnicationDashboardRpt.Name = "btnUnicationDashboardRpt"
        Me.btnUnicationDashboardRpt.Size = New System.Drawing.Size(280, 24)
        Me.btnUnicationDashboardRpt.TabIndex = 98
        Me.btnUnicationDashboardRpt.Text = "Create Unication Dashboard Rpt"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(280, 16)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Select From Date and To Date"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(16, 104)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(280, 16)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Select From Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCreateChangeSNCCFreq, Me.Label5, Me.btnUnicationDashboardRpt, Me.btnCreateDisRpt, Me.Label2, Me.chkInWIP, Me.Label12, Me.Label3, Me.Label4, Me.dtpShipTo, Me.dtpShipFr})
        Me.Panel1.Location = New System.Drawing.Point(248, 80)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 200)
        Me.Panel1.TabIndex = 3
        '
        'btnCreateChangeSNCCFreq
        '
        Me.btnCreateChangeSNCCFreq.BackColor = System.Drawing.Color.SteelBlue
        Me.btnCreateChangeSNCCFreq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateChangeSNCCFreq.ForeColor = System.Drawing.Color.White
        Me.btnCreateChangeSNCCFreq.Location = New System.Drawing.Point(16, 168)
        Me.btnCreateChangeSNCCFreq.Name = "btnCreateChangeSNCCFreq"
        Me.btnCreateChangeSNCCFreq.Size = New System.Drawing.Size(280, 24)
        Me.btnCreateChangeSNCCFreq.TabIndex = 101
        Me.btnCreateChangeSNCCFreq.Text = "Create Changed SN, Capcode and Freq"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(16, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(280, 16)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "Select From Date and To Date"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnWIPRpt
        '
        Me.btnWIPRpt.BackColor = System.Drawing.Color.Green
        Me.btnWIPRpt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWIPRpt.ForeColor = System.Drawing.Color.White
        Me.btnWIPRpt.Location = New System.Drawing.Point(400, 296)
        Me.btnWIPRpt.Name = "btnWIPRpt"
        Me.btnWIPRpt.Size = New System.Drawing.Size(128, 32)
        Me.btnWIPRpt.TabIndex = 99
        Me.btnWIPRpt.Text = "WIP Report"
        '
        'btnReceiptByWeek
        '
        Me.btnReceiptByWeek.BackColor = System.Drawing.Color.Green
        Me.btnReceiptByWeek.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceiptByWeek.ForeColor = System.Drawing.Color.White
        Me.btnReceiptByWeek.Location = New System.Drawing.Point(256, 296)
        Me.btnReceiptByWeek.Name = "btnReceiptByWeek"
        Me.btnReceiptByWeek.Size = New System.Drawing.Size(128, 32)
        Me.btnReceiptByWeek.TabIndex = 100
        Me.btnReceiptByWeek.Text = "Receipts By Week"
        '
        'btnEstimatedWeeklyShipmentDetail
        '
        Me.btnEstimatedWeeklyShipmentDetail.BackColor = System.Drawing.Color.Green
        Me.btnEstimatedWeeklyShipmentDetail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEstimatedWeeklyShipmentDetail.ForeColor = System.Drawing.Color.White
        Me.btnEstimatedWeeklyShipmentDetail.Location = New System.Drawing.Point(256, 384)
        Me.btnEstimatedWeeklyShipmentDetail.Name = "btnEstimatedWeeklyShipmentDetail"
        Me.btnEstimatedWeeklyShipmentDetail.Size = New System.Drawing.Size(128, 40)
        Me.btnEstimatedWeeklyShipmentDetail.TabIndex = 101
        Me.btnEstimatedWeeklyShipmentDetail.Text = "Estimated Weekly Shipment Detail"
        '
        'btnDailyWeeklyMonthlyGoal
        '
        Me.btnDailyWeeklyMonthlyGoal.BackColor = System.Drawing.Color.Green
        Me.btnDailyWeeklyMonthlyGoal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDailyWeeklyMonthlyGoal.ForeColor = System.Drawing.Color.White
        Me.btnDailyWeeklyMonthlyGoal.Location = New System.Drawing.Point(256, 336)
        Me.btnDailyWeeklyMonthlyGoal.Name = "btnDailyWeeklyMonthlyGoal"
        Me.btnDailyWeeklyMonthlyGoal.Size = New System.Drawing.Size(128, 40)
        Me.btnDailyWeeklyMonthlyGoal.TabIndex = 102
        Me.btnDailyWeeklyMonthlyGoal.Text = "Daily, Weekly and Monthly Goals"
        '
        'btnSNCCFreqBaudChange
        '
        Me.btnSNCCFreqBaudChange.BackColor = System.Drawing.Color.Green
        Me.btnSNCCFreqBaudChange.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSNCCFreqBaudChange.ForeColor = System.Drawing.Color.White
        Me.btnSNCCFreqBaudChange.Location = New System.Drawing.Point(400, 336)
        Me.btnSNCCFreqBaudChange.Name = "btnSNCCFreqBaudChange"
        Me.btnSNCCFreqBaudChange.Size = New System.Drawing.Size(128, 40)
        Me.btnSNCCFreqBaudChange.TabIndex = 103
        Me.btnSNCCFreqBaudChange.Text = "Changes in SN, Capcode, etc."
        '
        'frmMessReports
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(658, 480)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSNCCFreqBaudChange, Me.btnDailyWeeklyMonthlyGoal, Me.btnEstimatedWeeklyShipmentDetail, Me.btnReceiptByWeek, Me.btnWIPRpt, Me.Panel1, Me.grpAmericanMsgWIPDetailRpt, Me.cmdExit, Me.GroupBox1, Me.lblHeader})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessReports"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Messaging Reports"
        Me.GroupBox1.ResumeLayout(False)
        Me.grpAmericanMsgWIPDetailRpt.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmMessReports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.LoadMessReport()

            Me.dtpShipFr.Text = Now
            Me.dtpShipTo.Text = Now
            Me.dtpAmericanMsgWIPCutoffDate.Value = Now
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub

    '*******************************************************************

#Region "Report by Scanned Items"

    '*******************************************************************
    Private Sub LoadMessReport()
        Dim dt1 As DataTable
        Dim iSelectedVal As Integer = 0

        Try
            dt1 = Me._objMessReports.GetMessReportTypes()
            If dt1.Rows.Count = 1 Then
                iSelectedVal = dt1.Rows(0)("MessReport_ID")
            End If

            dt1.LoadDataRow(New Object() {"0", "-- Select --"}, False)
            With Me.cmbReport
                .DataSource = dt1.DefaultView
                .DisplayMember = dt1.Columns("MessReport_Name").ToString
                .ValueMember = dt1.Columns("MessReport_ID").ToString
                .SelectedValue = iSelectedVal
            End With
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '*******************************************************************
    Private Sub txtItem_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItem.KeyUp
        Dim i As Integer = 0
        Dim iItemExisted As Integer = 0

        Try
            If e.KeyValue = 13 Then

                If Trim(Me.txtItem.Text) = "" Then
                    Exit Sub
                End If

                If Me.radioSN.Checked = False And Me.radioTray.Checked = False And Me.radioShipID.Checked = False And Me.radioWO.Checked = False Then
                    MessageBox.Show("Please select 'Item Type' before scan item.", "Get Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If

                If Me.radioSN.Checked = True Then
                    Exit Sub
                ElseIf Me.radioTray.Checked = True Then
                    Exit Sub
                ElseIf Me.radioWO.Checked = True Then
                    Exit Sub
                ElseIf Me.radioShipID.Checked = True Then
                    If Not IsNumeric(Trim(Me.txtItem.Text)) Then
                        MessageBox.Show("This is not a valid Ship ID.", "Scan in Ship ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                End If

                '****************
                'Check duplicate
                '****************
                If Me.lstItems.Items.IndexOf(Me.txtItem.Text.Trim) > -1 Then
                    MessageBox.Show("This item is already scanned in. Try another one.", "Scan in Items", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtItem.SelectAll()
                    Exit Sub
                End If

                '*********************************
                'Check if item existed in database
                '*********************************
                iItemExisted = Me.CheckItemExisted(Me.txtItem.Text.Trim)

                '********************
                'add item to listbox
                '********************
                If iItemExisted > 0 Then
                    Me.lstItems.Items.Add(Trim(Me.txtItem.Text))
                    Me.lstItems.Refresh()
                    Me.txtItem.Text = ""
                ElseIf Me.radioShipID.Checked = True Then
                    MessageBox.Show("There are no devices for this Ship ID.", "Check Devices in Ship ID", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

                '*****************************************
                'disable item types when list contain item
                '*****************************************
                If Me.lstItems.Items.Count = 0 Then
                    Me.EnableDisableAllRadioButton(1)
                    Me.lblDevQty.Text = Me.lstItems.Items.Count.ToString
                Else
                    Me.EnableDisableAllRadioButton(0)
                    Me.lblDevQty.Text = Me._objMessReports.GetTotalDevInList(Me.GetScannedItemType, lstItems)
                End If
                Me.lblScanQty.Text = Me.lstItems.Items.Count.ToString
                '*****************************************
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Get Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Me.txtItem.SelectAll()
        Finally
            'Me.txtItem.Text = ""
        End Try
    End Sub

    '*******************************************************************
    Private Sub EnableDisableAllRadioButton(ByVal iEnable As Integer)
        If iEnable = 1 Then
            Me.radioSN.Enabled = True
            Me.radioTray.Enabled = True
            Me.radioShipID.Enabled = True
            Me.radioWO.Enabled = True
        Else
            Me.radioSN.Enabled = False
            Me.radioTray.Enabled = False
            Me.radioShipID.Enabled = False
            Me.radioWO.Enabled = False
        End If
    End Sub

    '*******************************************************************
    Private Function CheckItemExisted(ByVal strItem As String) As Integer
        Dim dt1 As DataTable
        Dim iResutlt As Integer = 0

        Try
            If Me.radioSN.Checked = True Then
            ElseIf Me.radioTray.Checked = True Then
            ElseIf Me.radioWO.Checked = True Then
            ElseIf Me.radioShipID.Checked = True Then
                iResutlt = Me._objMessReports.GetDeviceNoInShipManifest(CInt(Me.txtItem.Text))
            End If

            Return iResutlt

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Function

    '*******************************************************************
    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim strItem As String = ""
        Dim i As Integer = 0

        Try
            If Me.lstItems.Items.Count = 0 Then
                Exit Sub
            End If

            '************************
            strItem = InputBox("Enter Item:", "Remove Item")
            If strItem = "" Then
                MessageBox.Show("Please enter an item if you want to remove it from the list.", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            i = Me.lstItems.Items.IndexOf(Me.txtItem.Text.Trim)

            If i > -1 Then
                Me.lstItems.Items.RemoveAt(i)
                Me.lstItems.Refresh()
            Else
                MessageBox.Show("This item is not listed.", "Remove Item", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtItem.SelectAll()
                Exit Sub
            End If

            '*****************************************
            'disable item types when list contain item
            '*****************************************
            If Me.lstItems.Items.Count = 0 Then
                Me.EnableDisableAllRadioButton(1)
                Me.lblDevQty.Text = Me.lstItems.Items.Count.ToString
            Else
                Me.EnableDisableAllRadioButton(0)
                Me.lblDevQty.Text = Me._objMessReports.GetTotalDevInList(Me.GetScannedItemType, lstItems)
            End If
            Me.lblScanQty.Text = Me.lstItems.Items.Count.ToString
            '*****************************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear One Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnClearAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAll.Click

        Try
            If MessageBox.Show("Are you sure you want to clear all items in the list?", "Clear List", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Me.EnableDisableAllRadioButton(1)

            If Me.lstItems.Items.Count = 0 Then
                Exit Sub
            End If

            Me.lstItems.Items.Clear()
            Me.lstItems.Refresh()
            Me.lblDevQty.Text = Me.lstItems.Items.Count.ToString
            Me.lblScanQty.Text = Me.lstItems.Items.Count.ToString

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Clear All Item", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************
    Private Sub OptionChaged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioWO.CheckedChanged, radioTray.CheckedChanged, radioShipID.CheckedChanged, radioSN.CheckedChanged
        '****************************
        'clear controls
        '****************************
        Me.lstItems.Items.Clear()
        Me.lstItems.Refresh()
        Me.lblDevQty.Text = Me.lstItems.Items.Count.ToString
        Me.lblScanQty.Text = Me.lstItems.Items.Count.ToString
        Me.EnableDisableAllRadioButton(1)
        '****************************
        Me.txtItem.Focus()
    End Sub

    '*******************************************************************
    Private Function GetScannedItemType() As String
        Dim strScannedItemType As String = ""

        If Me.radioSN.Checked = True Then
            strScannedItemType = "Device_SN"
        ElseIf Me.radioTray.Checked = True Then
            strScannedItemType = "Tray_ID"
        ElseIf Me.radioShipID.Checked = True Then
            strScannedItemType = "Ship_ID"
        ElseIf Me.radioWO.Checked = True Then
            strScannedItemType = "WO_ID"
        End If

        Return strScannedItemType
    End Function

    '*******************************************************************
    Private Sub cmdCreateReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateReport.Click
        Dim i As Integer = 0
        Dim iItemType As Integer = 0

        Try
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Me.cmdCreateReport.Enabled = False

            Select Case Me.cmbReport.SelectedValue
                Case 1, 2
                    If Me.lstItems.Items.Count = 0 Then
                        MessageBox.Show("Please scan in some items to create report.", "American Messaging Ship Report", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtItem.Focus()
                        Exit Sub
                    End If
            End Select

            If Me.cmbReport.SelectedValue = 0 Then
                MessageBox.Show("Please select a report.", "American Messaging Ship Report", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Me.cmbReport.Focus()
                Exit Sub
            End If

            If Me.radioSN.Checked = True Then
                iItemType = 1
            ElseIf Me.radioTray.Checked = True Then
                iItemType = 2
            ElseIf Me.radioWO.Checked = True Then
                iItemType = 3
            ElseIf Me.radioShipID.Checked = True Then
                iItemType = 4
            End If

            Select Case Me.cmbReport.SelectedValue
                Case 1      'American Messaging Shipping Report
                    If iItemType <> 4 Then
                        MessageBox.Show("You must scan in the Ship IDs to create this report.", "American Messaging Ship Report", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.cmbReport.Focus()
                        Exit Sub
                    End If
                    i = _objMessReports.CreateAmericanMessShipReport(Me.lstItems, Me._iUserID, Me._strWorkDate, CInt(Me.lblDevQty.Text.Trim))
                Case 2
            End Select

            If i > 0 Then
                MessageBox.Show("Report has created.", "American Messaging Shipping Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            '****************************
            'clear controls
            '****************************
            Me.EnableDisableAllRadioButton(1)
            ''****************************
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "American Messaging Shipping Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Cursor.Current = System.Windows.Forms.Cursors.Default
            Me.cmdCreateReport.Enabled = True

            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    '*******************************************************************

#End Region

#Region "WIP Detail Report"
    Private Sub btnAmericanMsgWIPDetailRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAmericanMsgWIPDetailRpt.Click
        Dim dt As DataTable
        Dim objXL, objSheet, objWorkbook As Object
        Dim i, j, iHAlignment() As Integer
        Dim arrOutput(,)
        Dim strNumberFormat(), strBarCodeCol As String
        Dim objXLReports As Data.ExcelReports

        Try
            Cursor.Current = Cursors.WaitCursor
            Me.Enabled = False

            dt = Me._objMessReports.GetMessWIPDetailData(Me.dtpAmericanMsgWIPCutoffDate.Value, 14)

            If Not IsNothing(dt) Then
                If dt.Rows.Count > 0 Then
                    objXLReports = New Data.ExcelReports()

                    objXLReports.RunAmericanMsgWIPDetailReport(dt, Me.dtpAmericanMsgWIPCutoffDate.Value)
                Else
                    MsgBox("No data found.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "Error Creating WIP Detail Report")
        Finally
            If Not IsNothing(dt) Then
                dt.Dispose()
                dt = Nothing
            End If

            Me.Enabled = True
            Cursor.Current = Cursors.Default
        End Try
    End Sub
#End Region 'WIP Detail Report    

#Region "Abacus Report"

    '*******************************************************************
    Private Sub btnCreateDisRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateDisRpt.Click
        Dim objMessAbacusData As New PSS.Data.Buisness.MessAbacusData()
        Dim i As Integer = 0

        Try
            If Me.dtpShipTo.Value < Me.dtpShipFr.Value Then
                MsgBox("'Ship To Date' can't be before 'Ship  From Date'.", MsgBoxStyle.Information, "Abacus/PSS Discrepancy Report")
                Exit Sub
            End If

            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            If Me.chkInWIP.Checked = True Then
                i = objMessAbacusData.CreateAbacusVsPSSData_DiscrepancyRpt(, )
            Else
                i = objMessAbacusData.CreateAbacusVsPSSData_DiscrepancyRpt(Me.dtpShipFr.Text, Me.dtpShipTo.Text)
            End If

            If i > 0 Then
                'MessageBox.Show("Report has been created.", "Create Abacus/PSS Discrepancy Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("No data for the report.", "Create Abacus/PSS Discrepancy Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Abacus/PSS Discrepancy Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMessAbacusData = Nothing
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

    '*******************************************************************

#End Region

#Region "Unication Dashbord Report"
    Private Sub btnUnicationDashboardRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnicationDashboardRpt.Click
        Dim objMessRpt As New PSS.Data.Buisness.MessReports()
        Dim i As Integer = 0

        Try
            Me.Enabled = False
            Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            i = objMessRpt.CreateAM_UnicationDashboardReport(Me.dtpShipFr.Value)

            If i > 0 Then
                'MessageBox.Show("Report has been created.", "Create Unication Dashboard Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("No data for the report.", "Create Unication Dashboard Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Create Unication Dashboard Report", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objMessRpt = Nothing
            Me.Enabled = True
            Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
    End Sub

#End Region

#Region "Other Report"

    '*******************************************************************
    Private Sub btnWIPRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWIPRpt.Click
        Try
            Me._objMessReports.CreateMsgWIPReport()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnReceiptByWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiptByWeek.Click
        Dim iLoc_ID As Integer = 19

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Me._objMessReports.CreateReceiptByWeekRpt(iLoc_ID)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnDailyWeeklyMonthlyGoal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyWeeklyMonthlyGoal.Click
        Dim iLoc_ID As Integer = 19

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Me._objMessReports.CreateDailyWeeklyMonthlyGoal(iLoc_ID)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnEstimatedWeeklyShipmentDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstimatedWeeklyShipmentDetail.Click
        Dim iLoc_ID As Integer = 19

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Me._objMessReports.CreateWeeklyShipmentDetail(iLoc_ID)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Cursor = Cursors.Default
            Me.Enabled = True
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnSNCCFreqBaudChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSNCCFreqBaudChange.Click
        Dim iLoc_ID As Integer = 19

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            Me._objMessReports.CreateSNCCFreqBaudChangesReport(iLoc_ID)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    '*******************************************************************
    Private Sub btnCreateChangeSNCCFreq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateChangeSNCCFreq.Click
        Dim iLoc_ID As Integer = 19
        Dim i As Integer = 0

        Try
            If Me.dtpShipTo.Value < Me.dtpShipFr.Value Then
                MsgBox("'Ship To Date' can't be before 'Ship  From Date'.", MsgBoxStyle.Information, "Abacus/PSS Discrepancy Report")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            Me.Enabled = False

            i = Me._objMessReports.CreateChangedSNCCFreqRpt(iLoc_ID, Me.dtpShipFr.Text, Me.dtpShipTo.Text)

            If i > 0 Then
                'MessageBox.Show("Report has been created.", "Create Abacus/PSS Discrepancy Report", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show("No data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Me.Enabled = True
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    '*******************************************************************

#End Region


    
    
End Class
