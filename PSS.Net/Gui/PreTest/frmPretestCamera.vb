Imports PSS.Data
Imports PSS.Core
Imports PSS.Rules
Imports PSS.Core.Global

Namespace Gui.pretest


Public Class frmPretestCamera
    Inherits System.Windows.Forms.Form

        Private mSerialNumber As Long
        Private _device As Device = Nothing
        Private _tray As DataTable = Nothing
        Private tmpDeviceID, tmpModelID, tmpManufID, tmpTrayID, tmpCustID, tmpWOID, tmpTypeID As Int32
        Private valOldRepStat As String
        Private mFlash, mFunc, mRF, mL, mP As Integer
        Private mTF As Integer
        Private blnRUR As Boolean
        Private tmpRURbillcode As Integer = 0
        Private RURcode As Integer
        Public Shared mReturnCode As Int16
        Public Shared returnWaitState As Int16 = 0

        Private mFailID, mFailOLDID As Integer



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
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
        Friend WithEvents Label14 As System.Windows.Forms.Label
        Friend WithEvents txtTray As System.Windows.Forms.TextBox
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents lblTray As System.Windows.Forms.Label
        Friend WithEvents lblBill As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents chkLiquidDamage As System.Windows.Forms.CheckBox
        Friend WithEvents chkPhysicalDamage As System.Windows.Forms.CheckBox
        Friend WithEvents Label13 As System.Windows.Forms.Label
        Friend WithEvents Label12 As System.Windows.Forms.Label
        Friend WithEvents btnPhysicalDamage As System.Windows.Forms.Button
        Friend WithEvents btnLiquidDamage As System.Windows.Forms.Button
        Friend WithEvents chkVideoDownFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkUSBFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkVideoCapFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkCFCardFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkImageCapFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkMotionDetFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoFlash As System.Windows.Forms.CheckBox
        Friend WithEvents chkIntLCDFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkExtLCDFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkKeyboardFailed As System.Windows.Forms.CheckBox
        Friend WithEvents chkNoPower As System.Windows.Forms.CheckBox
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents btnKeypadFailed As System.Windows.Forms.Button
        Friend WithEvents btnExtLCDFailed As System.Windows.Forms.Button
        Friend WithEvents btnIntLCDFailed As System.Windows.Forms.Button
        Friend WithEvents btnNoFlash As System.Windows.Forms.Button
        Friend WithEvents btnMotionDetFailed As System.Windows.Forms.Button
        Friend WithEvents btnImgCaptureFailed As System.Windows.Forms.Button
        Friend WithEvents btnCFCardFailed As System.Windows.Forms.Button
        Friend WithEvents btnVideoCapFailed As System.Windows.Forms.Button
        Friend WithEvents btnUSBFailed As System.Windows.Forms.Button
        Friend WithEvents btnVideoDownFailed As System.Windows.Forms.Button
        Friend WithEvents btnNoPower As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox()
            Me.GroupBox2 = New System.Windows.Forms.GroupBox()
            Me.Label14 = New System.Windows.Forms.Label()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.txtTray = New System.Windows.Forms.TextBox()
            Me.lblTray = New System.Windows.Forms.Label()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.lblBill = New System.Windows.Forms.Label()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.chkLiquidDamage = New System.Windows.Forms.CheckBox()
            Me.chkPhysicalDamage = New System.Windows.Forms.CheckBox()
            Me.Label13 = New System.Windows.Forms.Label()
            Me.Label12 = New System.Windows.Forms.Label()
            Me.btnPhysicalDamage = New System.Windows.Forms.Button()
            Me.btnLiquidDamage = New System.Windows.Forms.Button()
            Me.chkVideoDownFailed = New System.Windows.Forms.CheckBox()
            Me.chkUSBFailed = New System.Windows.Forms.CheckBox()
            Me.chkVideoCapFailed = New System.Windows.Forms.CheckBox()
            Me.chkCFCardFailed = New System.Windows.Forms.CheckBox()
            Me.chkImageCapFailed = New System.Windows.Forms.CheckBox()
            Me.chkMotionDetFailed = New System.Windows.Forms.CheckBox()
            Me.chkNoFlash = New System.Windows.Forms.CheckBox()
            Me.chkIntLCDFailed = New System.Windows.Forms.CheckBox()
            Me.chkExtLCDFailed = New System.Windows.Forms.CheckBox()
            Me.chkKeyboardFailed = New System.Windows.Forms.CheckBox()
            Me.chkNoPower = New System.Windows.Forms.CheckBox()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.btnNoPower = New System.Windows.Forms.Button()
            Me.btnKeypadFailed = New System.Windows.Forms.Button()
            Me.btnExtLCDFailed = New System.Windows.Forms.Button()
            Me.btnIntLCDFailed = New System.Windows.Forms.Button()
            Me.btnNoFlash = New System.Windows.Forms.Button()
            Me.btnMotionDetFailed = New System.Windows.Forms.Button()
            Me.btnImgCaptureFailed = New System.Windows.Forms.Button()
            Me.btnCFCardFailed = New System.Windows.Forms.Button()
            Me.btnVideoCapFailed = New System.Windows.Forms.Button()
            Me.btnUSBFailed = New System.Windows.Forms.Button()
            Me.btnVideoDownFailed = New System.Windows.Forms.Button()
            Me.GroupBox1.SuspendLayout()
            Me.GroupBox2.SuspendLayout()
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnVideoDownFailed, Me.btnUSBFailed, Me.btnVideoCapFailed, Me.btnCFCardFailed, Me.btnImgCaptureFailed, Me.btnMotionDetFailed, Me.btnNoFlash, Me.btnIntLCDFailed, Me.btnExtLCDFailed, Me.btnKeypadFailed, Me.btnNoPower})
            Me.GroupBox1.Location = New System.Drawing.Point(16, 64)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(408, 312)
            Me.GroupBox1.TabIndex = 13
            Me.GroupBox1.TabStop = False
            Me.GroupBox1.Text = "Return To Vendor"
            '
            'GroupBox2
            '
            Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLiquidDamage, Me.btnPhysicalDamage})
            Me.GroupBox2.Location = New System.Drawing.Point(432, 72)
            Me.GroupBox2.Name = "GroupBox2"
            Me.GroupBox2.Size = New System.Drawing.Size(208, 128)
            Me.GroupBox2.TabIndex = 14
            Me.GroupBox2.TabStop = False
            Me.GroupBox2.Text = "Scrap"
            '
            'Label14
            '
            Me.Label14.Location = New System.Drawing.Point(48, 16)
            Me.Label14.Name = "Label14"
            Me.Label14.Size = New System.Drawing.Size(80, 16)
            Me.Label14.TabIndex = 15
            Me.Label14.Text = "Serial Number:"
            Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.Location = New System.Drawing.Point(128, 16)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.TabIndex = 1
            Me.txtDeviceSN.Text = ""
            '
            'txtTray
            '
            Me.txtTray.Location = New System.Drawing.Point(128, 40)
            Me.txtTray.Name = "txtTray"
            Me.txtTray.TabIndex = 2
            Me.txtTray.Text = ""
            '
            'lblTray
            '
            Me.lblTray.Location = New System.Drawing.Point(48, 40)
            Me.lblTray.Name = "lblTray"
            Me.lblTray.Size = New System.Drawing.Size(80, 16)
            Me.lblTray.TabIndex = 17
            Me.lblTray.Text = "Tray:"
            Me.lblTray.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(440, 296)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(216, 32)
            Me.btnSave.TabIndex = 19
            Me.btnSave.Text = "Save Data"
            '
            'lblBill
            '
            Me.lblBill.Location = New System.Drawing.Point(256, 40)
            Me.lblBill.Name = "lblBill"
            Me.lblBill.Size = New System.Drawing.Size(208, 16)
            Me.lblBill.TabIndex = 20
            Me.lblBill.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Button1
            '
            Me.Button1.Location = New System.Drawing.Point(440, 336)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(216, 32)
            Me.Button1.TabIndex = 21
            Me.Button1.Text = "Clear"
            '
            'chkLiquidDamage
            '
            Me.chkLiquidDamage.Location = New System.Drawing.Point(760, 24)
            Me.chkLiquidDamage.Name = "chkLiquidDamage"
            Me.chkLiquidDamage.Size = New System.Drawing.Size(8, 24)
            Me.chkLiquidDamage.TabIndex = 38
            Me.chkLiquidDamage.Visible = False
            '
            'chkPhysicalDamage
            '
            Me.chkPhysicalDamage.Location = New System.Drawing.Point(760, 8)
            Me.chkPhysicalDamage.Name = "chkPhysicalDamage"
            Me.chkPhysicalDamage.Size = New System.Drawing.Size(8, 24)
            Me.chkPhysicalDamage.TabIndex = 37
            Me.chkPhysicalDamage.Visible = False
            '
            'Label13
            '
            Me.Label13.Location = New System.Drawing.Point(712, 24)
            Me.Label13.Name = "Label13"
            Me.Label13.Size = New System.Drawing.Size(24, 16)
            Me.Label13.TabIndex = 36
            Me.Label13.Text = "Liquid Damage"
            Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label13.Visible = False
            '
            'Label12
            '
            Me.Label12.Location = New System.Drawing.Point(712, 8)
            Me.Label12.Name = "Label12"
            Me.Label12.Size = New System.Drawing.Size(24, 16)
            Me.Label12.TabIndex = 35
            Me.Label12.Text = "Physical Damage"
            Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label12.Visible = False
            '
            'btnPhysicalDamage
            '
            Me.btnPhysicalDamage.Location = New System.Drawing.Point(16, 16)
            Me.btnPhysicalDamage.Name = "btnPhysicalDamage"
            Me.btnPhysicalDamage.Size = New System.Drawing.Size(176, 40)
            Me.btnPhysicalDamage.TabIndex = 40
            Me.btnPhysicalDamage.Tag = "1406"
            Me.btnPhysicalDamage.Text = "Physical Damage"
            '
            'btnLiquidDamage
            '
            Me.btnLiquidDamage.Location = New System.Drawing.Point(16, 80)
            Me.btnLiquidDamage.Name = "btnLiquidDamage"
            Me.btnLiquidDamage.Size = New System.Drawing.Size(176, 40)
            Me.btnLiquidDamage.TabIndex = 41
            Me.btnLiquidDamage.Tag = "1407"
            Me.btnLiquidDamage.Text = "Liquid Damage"
            '
            'chkVideoDownFailed
            '
            Me.chkVideoDownFailed.Location = New System.Drawing.Point(752, 224)
            Me.chkVideoDownFailed.Name = "chkVideoDownFailed"
            Me.chkVideoDownFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkVideoDownFailed.TabIndex = 60
            Me.chkVideoDownFailed.Visible = False
            '
            'chkUSBFailed
            '
            Me.chkUSBFailed.Location = New System.Drawing.Point(752, 208)
            Me.chkUSBFailed.Name = "chkUSBFailed"
            Me.chkUSBFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkUSBFailed.TabIndex = 59
            Me.chkUSBFailed.Visible = False
            '
            'chkVideoCapFailed
            '
            Me.chkVideoCapFailed.Location = New System.Drawing.Point(752, 192)
            Me.chkVideoCapFailed.Name = "chkVideoCapFailed"
            Me.chkVideoCapFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkVideoCapFailed.TabIndex = 58
            Me.chkVideoCapFailed.Visible = False
            '
            'chkCFCardFailed
            '
            Me.chkCFCardFailed.Location = New System.Drawing.Point(752, 176)
            Me.chkCFCardFailed.Name = "chkCFCardFailed"
            Me.chkCFCardFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkCFCardFailed.TabIndex = 57
            Me.chkCFCardFailed.Visible = False
            '
            'chkImageCapFailed
            '
            Me.chkImageCapFailed.Location = New System.Drawing.Point(752, 160)
            Me.chkImageCapFailed.Name = "chkImageCapFailed"
            Me.chkImageCapFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkImageCapFailed.TabIndex = 56
            Me.chkImageCapFailed.Visible = False
            '
            'chkMotionDetFailed
            '
            Me.chkMotionDetFailed.Location = New System.Drawing.Point(752, 144)
            Me.chkMotionDetFailed.Name = "chkMotionDetFailed"
            Me.chkMotionDetFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkMotionDetFailed.TabIndex = 55
            Me.chkMotionDetFailed.Visible = False
            '
            'chkNoFlash
            '
            Me.chkNoFlash.Location = New System.Drawing.Point(752, 128)
            Me.chkNoFlash.Name = "chkNoFlash"
            Me.chkNoFlash.Size = New System.Drawing.Size(8, 24)
            Me.chkNoFlash.TabIndex = 54
            Me.chkNoFlash.Visible = False
            '
            'chkIntLCDFailed
            '
            Me.chkIntLCDFailed.Location = New System.Drawing.Point(752, 112)
            Me.chkIntLCDFailed.Name = "chkIntLCDFailed"
            Me.chkIntLCDFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkIntLCDFailed.TabIndex = 53
            Me.chkIntLCDFailed.Visible = False
            '
            'chkExtLCDFailed
            '
            Me.chkExtLCDFailed.Location = New System.Drawing.Point(752, 96)
            Me.chkExtLCDFailed.Name = "chkExtLCDFailed"
            Me.chkExtLCDFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkExtLCDFailed.TabIndex = 41
            Me.chkExtLCDFailed.Visible = False
            '
            'chkKeyboardFailed
            '
            Me.chkKeyboardFailed.Location = New System.Drawing.Point(752, 80)
            Me.chkKeyboardFailed.Name = "chkKeyboardFailed"
            Me.chkKeyboardFailed.Size = New System.Drawing.Size(8, 24)
            Me.chkKeyboardFailed.TabIndex = 40
            Me.chkKeyboardFailed.Visible = False
            '
            'chkNoPower
            '
            Me.chkNoPower.Location = New System.Drawing.Point(752, 64)
            Me.chkNoPower.Name = "chkNoPower"
            Me.chkNoPower.Size = New System.Drawing.Size(8, 24)
            Me.chkNoPower.TabIndex = 39
            Me.chkNoPower.Visible = False
            '
            'Label11
            '
            Me.Label11.Location = New System.Drawing.Point(704, 224)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(24, 16)
            Me.Label11.TabIndex = 52
            Me.Label11.Text = "Video Download Failed"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label11.Visible = False
            '
            'Label10
            '
            Me.Label10.Location = New System.Drawing.Point(704, 208)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(24, 16)
            Me.Label10.TabIndex = 51
            Me.Label10.Text = "USB Failed"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label10.Visible = False
            '
            'Label9
            '
            Me.Label9.Location = New System.Drawing.Point(704, 192)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(24, 16)
            Me.Label9.TabIndex = 50
            Me.Label9.Text = "Video Capture Failed"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label9.Visible = False
            '
            'Label8
            '
            Me.Label8.Location = New System.Drawing.Point(704, 176)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(24, 16)
            Me.Label8.TabIndex = 49
            Me.Label8.Text = "CF Card Failed"
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label8.Visible = False
            '
            'Label7
            '
            Me.Label7.Location = New System.Drawing.Point(704, 160)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(24, 16)
            Me.Label7.TabIndex = 48
            Me.Label7.Text = "Image Capture Failed"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label7.Visible = False
            '
            'Label6
            '
            Me.Label6.Location = New System.Drawing.Point(704, 144)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(24, 16)
            Me.Label6.TabIndex = 47
            Me.Label6.Text = "Motion Detection Failed"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label6.Visible = False
            '
            'Label5
            '
            Me.Label5.Location = New System.Drawing.Point(704, 128)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(24, 16)
            Me.Label5.TabIndex = 46
            Me.Label5.Text = "No Flash"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label5.Visible = False
            '
            'Label4
            '
            Me.Label4.Location = New System.Drawing.Point(704, 112)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(24, 16)
            Me.Label4.TabIndex = 45
            Me.Label4.Text = "Internal LCD Failed"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label4.Visible = False
            '
            'Label3
            '
            Me.Label3.Location = New System.Drawing.Point(704, 96)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(24, 16)
            Me.Label3.TabIndex = 44
            Me.Label3.Text = "Exterior LCD Failed"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label3.Visible = False
            '
            'Label2
            '
            Me.Label2.Location = New System.Drawing.Point(704, 80)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(24, 16)
            Me.Label2.TabIndex = 43
            Me.Label2.Text = "Keypad Failed"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label2.Visible = False
            '
            'Label1
            '
            Me.Label1.Location = New System.Drawing.Point(704, 64)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(24, 16)
            Me.Label1.TabIndex = 42
            Me.Label1.Text = "No Power"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label1.Visible = False
            '
            'btnNoPower
            '
            Me.btnNoPower.Location = New System.Drawing.Point(16, 24)
            Me.btnNoPower.Name = "btnNoPower"
            Me.btnNoPower.Size = New System.Drawing.Size(176, 40)
            Me.btnNoPower.TabIndex = 41
            Me.btnNoPower.Tag = "1395"
            Me.btnNoPower.Text = "No Power"
            '
            'btnKeypadFailed
            '
            Me.btnKeypadFailed.Location = New System.Drawing.Point(16, 72)
            Me.btnKeypadFailed.Name = "btnKeypadFailed"
            Me.btnKeypadFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnKeypadFailed.TabIndex = 42
            Me.btnKeypadFailed.Tag = "1396"
            Me.btnKeypadFailed.Text = "Keypad Failed"
            '
            'btnExtLCDFailed
            '
            Me.btnExtLCDFailed.Location = New System.Drawing.Point(16, 120)
            Me.btnExtLCDFailed.Name = "btnExtLCDFailed"
            Me.btnExtLCDFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnExtLCDFailed.TabIndex = 43
            Me.btnExtLCDFailed.Tag = "1397"
            Me.btnExtLCDFailed.Text = "Exterior LCD Failed"
            '
            'btnIntLCDFailed
            '
            Me.btnIntLCDFailed.Location = New System.Drawing.Point(16, 168)
            Me.btnIntLCDFailed.Name = "btnIntLCDFailed"
            Me.btnIntLCDFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnIntLCDFailed.TabIndex = 44
            Me.btnIntLCDFailed.Tag = "1398"
            Me.btnIntLCDFailed.Text = "Internal LCD Failed"
            '
            'btnNoFlash
            '
            Me.btnNoFlash.Location = New System.Drawing.Point(16, 216)
            Me.btnNoFlash.Name = "btnNoFlash"
            Me.btnNoFlash.Size = New System.Drawing.Size(176, 40)
            Me.btnNoFlash.TabIndex = 45
            Me.btnNoFlash.Tag = "1399"
            Me.btnNoFlash.Text = "No Flash"
            '
            'btnMotionDetFailed
            '
            Me.btnMotionDetFailed.Location = New System.Drawing.Point(16, 264)
            Me.btnMotionDetFailed.Name = "btnMotionDetFailed"
            Me.btnMotionDetFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnMotionDetFailed.TabIndex = 46
            Me.btnMotionDetFailed.Tag = "1400"
            Me.btnMotionDetFailed.Text = "Motion Detection Failed"
            '
            'btnImgCaptureFailed
            '
            Me.btnImgCaptureFailed.Location = New System.Drawing.Point(208, 24)
            Me.btnImgCaptureFailed.Name = "btnImgCaptureFailed"
            Me.btnImgCaptureFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnImgCaptureFailed.TabIndex = 47
            Me.btnImgCaptureFailed.Tag = "1401"
            Me.btnImgCaptureFailed.Text = "Image Capture Failed"
            '
            'btnCFCardFailed
            '
            Me.btnCFCardFailed.Location = New System.Drawing.Point(208, 72)
            Me.btnCFCardFailed.Name = "btnCFCardFailed"
            Me.btnCFCardFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnCFCardFailed.TabIndex = 48
            Me.btnCFCardFailed.Tag = "1402"
            Me.btnCFCardFailed.Text = "CF Card Failed"
            '
            'btnVideoCapFailed
            '
            Me.btnVideoCapFailed.Location = New System.Drawing.Point(208, 120)
            Me.btnVideoCapFailed.Name = "btnVideoCapFailed"
            Me.btnVideoCapFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnVideoCapFailed.TabIndex = 49
            Me.btnVideoCapFailed.Tag = "1403"
            Me.btnVideoCapFailed.Text = "Video Capture Failed"
            '
            'btnUSBFailed
            '
            Me.btnUSBFailed.Location = New System.Drawing.Point(208, 168)
            Me.btnUSBFailed.Name = "btnUSBFailed"
            Me.btnUSBFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnUSBFailed.TabIndex = 50
            Me.btnUSBFailed.Tag = "1404"
            Me.btnUSBFailed.Text = "USB Failed"
            '
            'btnVideoDownFailed
            '
            Me.btnVideoDownFailed.Location = New System.Drawing.Point(208, 216)
            Me.btnVideoDownFailed.Name = "btnVideoDownFailed"
            Me.btnVideoDownFailed.Size = New System.Drawing.Size(176, 40)
            Me.btnVideoDownFailed.TabIndex = 51
            Me.btnVideoDownFailed.Tag = "1405"
            Me.btnVideoDownFailed.Text = "Video Download Failed"
            '
            'frmPretestCamera
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(768, 389)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkVideoDownFailed, Me.chkUSBFailed, Me.chkVideoCapFailed, Me.chkCFCardFailed, Me.chkImageCapFailed, Me.chkMotionDetFailed, Me.chkNoFlash, Me.chkIntLCDFailed, Me.chkExtLCDFailed, Me.chkKeyboardFailed, Me.chkNoPower, Me.Label11, Me.Label10, Me.Label9, Me.Label8, Me.Label7, Me.Label6, Me.Label5, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.chkLiquidDamage, Me.chkPhysicalDamage, Me.Label13, Me.Label12, Me.Button1, Me.lblBill, Me.btnSave, Me.txtTray, Me.lblTray, Me.txtDeviceSN, Me.Label14, Me.GroupBox1, Me.GroupBox2})
            Me.Name = "frmPretestCamera"
            Me.Text = "Camera PreTest"
            Me.GroupBox1.ResumeLayout(False)
            Me.GroupBox2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        End Sub

        Private Sub frmPretestCamera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            txtDeviceSN.Focus()
        End Sub

        Private Sub txtSerial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDeviceSN.TextChanged

        End Sub

        Private Sub txtSerial_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyDown
            Dim blnGetData As Boolean

            mSerialNumber = 0

            If e.KeyValue = 13 Then
                txtDeviceSN.Text = UCase(txtDeviceSN.Text)  '//Format serial as all uppercase
                Dim val As Long = Me.verifySerialNumber(txtDeviceSN.Text)
                If val = 0 Then
                    lblTray.Visible = False
                    txtTray.Visible = False
                    txtDeviceSN.Text = ""
                    txtDeviceSN.Focus()
                    Exit Sub
                ElseIf val = 2 Then
                    txtTray.Text = ""
                    lblTray.Visible = True
                    txtTray.Visible = True
                    txtTray.Focus()
                Else
                    mSerialNumber = val
                    txtTray.Text = getTrayID(mSerialNumber)
                    lblTray.Visible = True
                    txtTray.Visible = True
                    retreiveData()
                End If
            End If

        End Sub


        Private Function verifySerialNumber(ByVal mDeviceSN As String) As Long

            Try
                Dim dRec As New PSS.Data.Production.tdevice()
                Dim tRec As DataTable = dRec.GetDataTableBySNPretest(mDeviceSN)
                Dim r As DataRow

                If tRec.Rows.Count < 1 Then     'If records returned = 0 then 
                    Return 0                    'send trigger to display error message
                ElseIf tRec.Rows.Count > 1 Then 'If more than 1 record is returned then 
                    Return 2                    'send trigger to display tray textbox
                Else
                    r = tRec.Rows(0)
                    Return r("Device_ID")       'Send back device ID
                End If
            Catch ex As Exception
                Return 0
            End Try

        End Function

        Private Function getTrayID(ByVal mDeviceID As Long) As Long

            getTrayID = 0

            Try

                Dim dTray As New PSS.Data.Production.tdevice()
                Dim tTray As DataRow = dTray.GetRowByPK(mDeviceID)

                getTrayID = tTray("Tray_ID")

            Catch ex As Exception
                '//will return value of 0 so no coding necessary here
            End Try

        End Function
        Private Sub retreiveData()

            Try
                '_device.Dispose()
                '_tray.Dispose()

                _device = Nothing
                _tray = Nothing
            Catch ex As Exception
            End Try

            getData(Me.txtTray.Text, Me.txtDeviceSN.Text)

            Try
                Me.LoadTray()
                Me.LoadDevice()
            Catch ex As Exception
            End Try

        End Sub



        Private Sub getBillCodes()

            If tmpDeviceID > 0 Then
                Dim r As DataRow
                Dim tmpBillCode As Integer = 0
                Dim dtP As New PSS.Data.Production.Joins()
                'Dim dtParts2 As DataTable = dtP.GenericSelect("SELECT tpartscodes.*,lbillcodes.billcode_desc, lbillcodes.billcode_id, lcodesmaster.Mcode_Desc, lcodesdetail.DCode_Ldesc FROM ((((tdevicebill INNER JOIN tpartscodes ON tdevicebill.DBill_ID = tpartscodes.DBill_ID) INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id) LEFT OUTER JOIN lcodesdetail ON tpartscodes.DCode_ID = lcodesdetail.DCode_ID) LEFT OUTER JOIN lcodesmaster ON lcodesdetail.MCode_ID = lcodesmaster.MCode_ID) WHERE tdevicebill.device_id= " & tmpDeviceID & " AND BillCode_Rule = 1 ORDER BY BillCode_Desc")
                Dim dtParts2 As DataTable = dtP.GenericSelect("SELECT lbillcodes.billcode_desc, lbillcodes.billcode_id FROM (tdevicebill INNER JOIN lbillcodes ON tdevicebill.billcode_id = lbillcodes.billcode_id) WHERE tdevicebill.device_id= " & tmpDeviceID & " AND BillCode_Rule = 1 ORDER BY BillCode_Desc")
                '//This will get a list of only RUR values
                If dtParts2.Rows.Count > 0 Then
                    r = dtParts2.Rows(0)
                    tmpBillCode = r("BillCode_ID")
                    Me.lblBill.Text = "THIS DEVICE IS RUR: " & r("BillCode_Desc")
                    DisableElements()
                End If
            End If

        End Sub


        Private Sub DisableElements()
            'Me.btnNoPower.Enabled = False
            'Me.btnKeypadFailed.Enabled = False
            'Me.btnExtLCDFailed.Enabled = False
            'Me.btnIntLCDFailed.Enabled = False
            'Me.btnNoFlash.Enabled = False
            'Me.btnMotionDetFailed.Enabled = False
            'Me.btnImgCaptureFailed.Enabled = False
            'Me.btnCFCardFailed.Enabled = False
            'Me.btnVideoCapFailed.Enabled = False
            'Me.btnUSBFailed.Enabled = False
            'Me.btnVideoDownFailed.Enabled = False
            'Me.btnPhysicalDamage.Enabled = False
            'Me.btnLiquidDamage.Enabled = False
            Me.btnSave.Enabled = False
        End Sub

        Private Sub EnableElements()
            Me.btnNoPower.Enabled = True
            Me.btnKeypadFailed.Enabled = True
            Me.btnExtLCDFailed.Enabled = True
            Me.btnIntLCDFailed.Enabled = True
            Me.btnNoFlash.Enabled = True
            Me.btnMotionDetFailed.Enabled = True
            Me.btnImgCaptureFailed.Enabled = True
            Me.btnCFCardFailed.Enabled = True
            Me.btnVideoCapFailed.Enabled = True
            Me.btnUSBFailed.Enabled = True
            Me.btnVideoDownFailed.Enabled = True
            Me.btnPhysicalDamage.Enabled = True
            Me.btnLiquidDamage.Enabled = True
            Me.btnSave.Enabled = True
        End Sub










        Private Sub getData(ByVal TrayNum As Int32, ByVal deviceSN As String)

            tmpDeviceID = 0
            tmpModelID = 0
            tmpTrayID = 0
            tmpManufID = 0
            tmpCustID = 0
            tmpWOID = 0
            tmpTypeID = 0
            valOldRepStat = ""

            tmpTrayID = Me.txtTray.Text

            Dim mthd As New PSS.Data.Production.tdevice()
            Dim mtDeviceID As DataTable = mthd.GetDataTableBySN(deviceSN)
            Dim r As DataRow
            Dim xCount As Integer = 0

            For xCount = 0 To mtDeviceID.Rows.Count - 1
                r = mtDeviceID.Rows(xCount)
                If r("Tray_ID") = TrayNum Then
                    tmpDeviceID = r("Device_ID")
                    tmpModelID = r("Model_ID")
                    tmpWOID = r("WO_ID")
                    Exit For
                End If
            Next

            'Craig Haney
            Dim tmpCds As PSS.Data.Production.Joins
            Dim tmpCdr As DataRow = tmpCds.GetCustomerFromDeviceID(tmpDeviceID)
            tmpCustID = tmpCdr("Cust_ID")

            '//Craig D Haney October 26, 2004
            If tmpWOID > 0 Then
                Try
                    Dim drType As DataRow
                    drType = PSS.Data.Production.tworkorder.GetRowByPK(tmpWOID)
                    tmpTypeID = drType("WO_Project")
                Catch ex As Exception
                    tmpTypeID = 0
                End Try
            End If


            Try
                mtDeviceID.Dispose()
                mtDeviceID = Nothing
            Catch ex As Exception
            End Try

            Dim mtManuf As New PSS.Data.Production.tmodel()
            Dim mtManufID As DataRow = mtManuf.GetRowByModel(tmpModelID)
            tmpManufID = mtManufID("Manuf_ID")
            If tmpDeviceID = 0 Or tmpModelID = 0 Or tmpManufID = 0 Then
                Exit Sub
            End If


            '//Get values from tcellopt
            Dim mthdCO As New PSS.Data.Production.tcellopt()
            Dim mtData As DataRow = mthdCO.GetRowByDeviceID(tmpDeviceID)

            Dim valFailure As String
            If IsDBNull(mtData("CellOpt_Failure")) = False Then
                valFailure = mtData("CellOpt_Failure")
            Else
                valFailure = 0
            End If

            If valFailure = 1395 Then
                Me.btnNoPower.ForeColor = Color.Blue
                mFailID = 1395
            End If

            If valFailure = 1396 Then
                Me.btnKeypadFailed.ForeColor = Color.Blue
                mFailID = 1396
            End If

            If valFailure = 1397 Then
                Me.btnExtLCDFailed.ForeColor = Color.Blue
                mFailID = 1397
            End If

            If valFailure = 1398 Then
                Me.btnIntLCDFailed.ForeColor = Color.Blue
                mFailID = 1398
            End If

            If valFailure = 1399 Then
                Me.btnNoFlash.ForeColor = Color.Blue
                mFailID = 1399
            End If

            If valFailure = 1400 Then
                Me.btnMotionDetFailed.ForeColor = Color.Blue
                mFailID = 1400
            End If

            If valFailure = 1401 Then
                Me.btnImgCaptureFailed.ForeColor = Color.Blue
                mFailID = 1401
            End If

            If valFailure = 1402 Then
                Me.btnCFCardFailed.ForeColor = Color.Blue
                mFailID = 1402
            End If

            If valFailure = 1403 Then
                Me.btnVideoCapFailed.ForeColor = Color.Blue
                mFailID = 1403
            End If

            If valFailure = 1404 Then
                Me.btnUSBFailed.ForeColor = Color.Blue
                mFailID = 1404
            End If

            If valFailure = 1405 Then
                Me.btnVideoDownFailed.ForeColor = Color.Blue
                mFailID = 1405
            End If

            If valFailure = 1406 Then
                Me.btnPhysicalDamage.ForeColor = Color.Blue
                mFailID = 1406
            End If

            If valFailure = 1407 Then
                Me.btnLiquidDamage.ForeColor = Color.Blue
                mFailID = 1407
            End If


            If valFailure > 0 Then Me.DisableElements()

            getBillCodes()

        End Sub

        Private Sub LoadDevice()
            Try
                Dim __device As DataRow() = _tray.Select("Device_SN = '" & UCase(txtDeviceSN.Text) & "'")
                _device = New Device(__device(0)("Device_ID"))
                Dim i As Integer = 0
                For i = 0 To _tray.Rows.Count - 1
                    If _tray.Rows(i)("Device_SN") = UCase(txtDeviceSN.Text) Then
                        Exit For
                    End If
                Next

            Catch ex As Exception
                MsgBox("This is not a valid billable device.", MsgBoxStyle.Information, "Error")
                _device = Nothing
            End Try
        End Sub

        Private Sub LoadTray()

            If IsNumeric(tmpTrayID) Then
                Dim Source As DataTable = PSS.Data.Buisness.DeviceBilling.GetDeviceTrayByID(tmpTrayID)
                If Source.Rows.Count = 0 Then
                    MsgBox("This is not a valid tray.", MsgBoxStyle.Information, "Error")
                    _tray = Nothing
                Else
                    _tray = Source
                End If
                Source = Nothing
            Else
                MsgBox("A tray number is all numeric. please enter a valid tray.", MsgBoxStyle.Information, "Error")
            End If

        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


            Dim valFailure As Integer = 0


            If mFailID > 0 Then
                valFailure = mFailID
            Else
                valFailure = ""
            End If
            'If mFailID = 1395 Then valFailure = 1395
            'If Me.btnKeypadFailed.ForeColor = Color.Blue Then valFailure = 1396
            'If Me.btnExtLCDFailed.ForeColor = Color.Blue Then valFailure = 1397
            'If Me.chkIntLCDFailed.Checked = True Then valFailure = 1398
            'If Me.chkNoFlash.Checked = True Then valFailure = 1399
            'If Me.chkMotionDetFailed.Checked = True Then valFailure = 1400
            'If Me.chkImageCapFailed.Checked = True Then valFailure = 1401
            'If Me.chkCFCardFailed.Checked = True Then valFailure = 1402
            'If Me.chkVideoCapFailed.Checked = True Then valFailure = 1403
            'If Me.chkUSBFailed.Checked = True Then valFailure = 1404
            'If Me.chkVideoDownFailed.Checked = True Then valFailure = 1405
            'If Me.chkPhysicalDamage.Checked = True Then valFailure = 1406
            'If Me.chkLiquidDamage.Checked = True Then valFailure = 1407

            If tmpDeviceID > 0 Then
                Dim dsDel As PSS.Data.Production.Joins
                Dim Delbln As Boolean = dsDel.OrderEntryUpdateDelete("DELETE FROM tdevicebill WHERE device_ID = " & tmpDeviceID)
            End If

            If valFailure > 0 Then

                If valFailure = 1395 Then AutoBill(578)
                If valFailure = 1396 Then AutoBill(578)
                If valFailure = 1397 Then AutoBill(578)
                If valFailure = 1398 Then AutoBill(578)
                If valFailure = 1399 Then AutoBill(578)
                If valFailure = 1400 Then AutoBill(578)
                If valFailure = 1401 Then AutoBill(578)
                If valFailure = 1402 Then AutoBill(578)
                If valFailure = 1403 Then AutoBill(578)
                If valFailure = 1404 Then AutoBill(578)
                If valFailure = 1405 Then AutoBill(578)

                If valFailure = 1406 Then AutoBill(580)
                If valFailure = 1407 Then AutoBill(580)


                'Assign Disposition
                Dim dsSKU As PSS.Data.Production.Joins
                Dim dtSKU As DataTable = dsSKU.OrderEntrySelect("SELECT tsku.sku_number FROM tdevice inner join tsku on tdevice.sku_id = tsku.sku_id WHERE tdevice.device_id = " & tmpDeviceID)
                Dim drSKU As DataRow = dtSKU.Rows(0)
                Dim strBase As String = Mid$(drSKU("Sku_Number"), 1, InStr(drSKU("Sku_Number"), "-U") - 1)

                Dim vdispid As Integer = 0
                Dim dashD As Integer
                Dim dashE As Integer
                Dim vOLD As Integer

                Dim dr2SKU As DataTable = dsSKU.OrderEntrySelect("SELECT * FROM tsku WHERE Sku_Number = '" & strBase & "-D'")
                Dim dr2 As DataRow = dr2SKU.Rows(0)
                dashD = dr2("Sku_ID")
                Dim dr3SKU As DataTable = dsSKU.OrderEntrySelect("SELECT * FROM tsku WHERE Sku_Number = '" & strBase & "-E'")
                Dim dr3 As DataRow = dr3SKU.Rows(0)
                dashE = dr3("Sku_ID")
                Dim dr4SKU As DataTable = dsSKU.OrderEntrySelect("SELECT * FROM tsku WHERE Sku_Number = '" & strBase & "-U'")
                Dim dr4 As DataRow = dr4SKU.Rows(0)
                vOLD = dr4("Sku_ID")


                If valFailure = 1395 Then vdispid = dashD
                If valFailure = 1396 Then vdispid = dashD
                If valFailure = 1397 Then vdispid = dashD
                If valFailure = 1398 Then vdispid = dashD
                If valFailure = 1399 Then vdispid = dashD
                If valFailure = 1400 Then vdispid = dashD
                If valFailure = 1401 Then vdispid = dashD
                If valFailure = 1402 Then vdispid = dashD
                If valFailure = 1403 Then vdispid = dashD
                If valFailure = 1404 Then vdispid = dashD
                If valFailure = 1405 Then vdispid = dashD

                If valFailure = 1406 Then vdispid = dashE
                If valFailure = 1407 Then vdispid = dashE

                If vdispid > 0 Then
                    Dim dsInsert As PSS.Data.Production.Joins
                    Dim blnInsert As Boolean = dsInsert.OrderEntryUpdateDelete("INSERT INTO tdisposition (Disp_Date, Disp_OLD, Disp_NEW, Device_ID) VALUES ('" & Now() & "', " & vOLD & ", " & vdispid & ", " & tmpDeviceID & ")")


                    Try
                        Dim blnInsertDevice As Boolean = dsInsert.OrderEntryUpdateDelete("UPDATE tdevice SET Sku_ID = " & vdispid & " WHERE device_id = " & tmpDeviceID)
                    Catch ex As Exception
                        MsgBox("Error updating tdevice field: sku_id")
                    End Try


                End If

                clearButtons()
                txtTray.Text = ""
                Me.txtDeviceSN.Text = ""
                txtDeviceSN.Focus()

            End If


            Dim ds As PSS.Data.Production.Joins
            If tmpDeviceID > 0 Then
                Dim dsBln As Boolean = ds.OrderEntryUpdateDelete("UPDATE tcellopt SET cellopt_Failure = " & valFailure & " WHERE device_ID = " & tmpDeviceID)
            End If

            mFailID = 0

            EnableElements()
            'Me.chkNoPower.Checked = False
            'Me.chkKeyboardFailed.Checked = False
            'Me.chkExtLCDFailed.Checked = False
            'Me.chkIntLCDFailed.Checked = False
            'Me.chkNoFlash.Checked = False
            'Me.chkMotionDetFailed.Checked = False
            'Me.chkImageCapFailed.Checked = False
            'Me.chkCFCardFailed.Checked = False
            'Me.chkVideoCapFailed.Checked = False
            'Me.chkUSBFailed.Checked = False
            'Me.chkVideoDownFailed.Checked = False
            'Me.chkPhysicalDamage.Checked = False
            'Me.chkLiquidDamage.Checked = False
            txtTray.Text = ""
            Me.txtDeviceSN.Text = ""
            txtDeviceSN.Focus()

        End Sub


        Private Sub AutoBill(ByVal intBillCode As Integer)

            'Try
            '_device = Nothing
            '_tray = Nothing
            'Catch ex As Exception
            'End Try


            Dim xCount As Integer = 0
            Dim dt As DataTable = PSS.Data.Production.Joins.OrderEntrySelect("SELECT * FROM tdevice WHERE device_id = " & tmpDeviceID)
            Dim r As DataRow

            For xCount = 0 To dt.Rows.Count - 1

                'r = dt.Rows(xCount)
                'Me.LoadDevice(r("Device_SN"))
                'System.Windows.Forms.Application.DoEvents()

                Try
                    'Bill Part
                    _device.AddPart(intBillCode)
                    System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try

                If Len(Trim(tmpTrayID)) > 0 Then
                    If Len(Trim(tmpDeviceID)) > 0 Then
                        UpdateBilling()
                    End If
                End If

                Try
                    _device = Nothing
                    System.Windows.Forms.Application.DoEvents()
                Catch ex As Exception
                End Try

            Next

        End Sub

        Private Sub UpdateBilling()
            Try 'here in case there is not refrence to _device
                _device.Update()
                Dim d As DataRow() = _tray.Select("Device_ID = " & _device.ID)
                If _device.Parts.Rows.Count = 0 Then
                    d(0)("Device_DateBill") = DBNull.Value
                Else
                    d(0)("Device_DateBill") = Now
                End If
                d = Nothing
                '_device.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Information, "Error")
            Finally
            End Try
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            EnableElements()

            'Me.chkNoPower.Checked = False
            'Me.chkKeyboardFailed.Checked = False
            'Me.chkExtLCDFailed.Checked = False
            'Me.chkIntLCDFailed.Checked = False
            'Me.chkNoFlash.Checked = False
            'Me.chkMotionDetFailed.Checked = False
            'Me.chkImageCapFailed.Checked = False
            'Me.chkCFCardFailed.Checked = False
            'Me.chkVideoCapFailed.Checked = False
            'Me.chkUSBFailed.Checked = False
            'Me.chkVideoDownFailed.Checked = False
            'Me.chkPhysicalDamage.Checked = False
            'Me.chkLiquidDamage.Checked = False

            Me.btnNoPower.ForeColor = Color.Black
            Me.btnKeypadFailed.ForeColor = Color.Black
            Me.btnExtLCDFailed.ForeColor = Color.Black
            Me.btnIntLCDFailed.ForeColor = Color.Black
            Me.btnNoFlash.ForeColor = Color.Black
            Me.btnMotionDetFailed.ForeColor = Color.Black
            Me.btnImgCaptureFailed.ForeColor = Color.Black
            Me.btnCFCardFailed.ForeColor = Color.Black
            Me.btnVideoCapFailed.ForeColor = Color.Black
            Me.btnUSBFailed.ForeColor = Color.Black
            Me.btnVideoDownFailed.ForeColor = Color.Black
            Me.btnPhysicalDamage.ForeColor = Color.Black
            Me.btnLiquidDamage.ForeColor = Color.Black

            mFailID = 0
            txtTray.Text = ""
            Me.txtDeviceSN.Text = ""
            txtDeviceSN.Focus()

            _tray = Nothing
            _device = Nothing

        End Sub


        Private Sub clearButtons()
            Me.btnNoPower.ForeColor = Color.Black
            Me.btnKeypadFailed.ForeColor = Color.Black
            Me.btnExtLCDFailed.ForeColor = Color.Black
            Me.btnIntLCDFailed.ForeColor = Color.Black
            Me.btnNoFlash.ForeColor = Color.Black
            Me.btnMotionDetFailed.ForeColor = Color.Black
            Me.btnImgCaptureFailed.ForeColor = Color.Black
            Me.btnCFCardFailed.ForeColor = Color.Black
            Me.btnVideoCapFailed.ForeColor = Color.Black
            Me.btnUSBFailed.ForeColor = Color.Black
            Me.btnVideoDownFailed.ForeColor = Color.Black
            Me.btnPhysicalDamage.ForeColor = Color.Black
            Me.btnLiquidDamage.ForeColor = Color.Black
            mFailID = 0
        End Sub

        Private Sub btnNoPower_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoPower.Click
            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If
        End Sub

        Private Sub btnKeypadFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeypadFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnExtLCDFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtLCDFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnIntLCDFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntLCDFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnNoFlash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoFlash.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnMotionDetFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMotionDetFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnImgCaptureFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImgCaptureFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnCFCardFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCFCardFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnVideoCapFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVideoCapFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnUSBFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUSBFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnVideoDownFailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVideoDownFailed.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnPhysicalDamage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPhysicalDamage.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub

        Private Sub btnLiquidDamage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiquidDamage.Click

            clearButtons()
            If mFailID = 0 Then
                mFailID = Trim(sender.tag.ToString)
                CType(sender, Button).ForeColor = Color.Blue
            End If

        End Sub
    End Class

End Namespace
