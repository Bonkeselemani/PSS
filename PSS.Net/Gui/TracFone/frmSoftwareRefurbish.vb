Option Explicit On 

Imports PSS.Data.Buisness

Namespace Gui.TracFone
    Public Class frmSoftwareRefurbish
        Inherits System.Windows.Forms.Form

        Private _strScreenName As String = ""
        Private _iMenuCustID As Integer = 0
        Private _iTestTypeID As Integer = 0
        Private _iDeviceID As Integer = 0
        Private _iResult As Integer = 0
        Private _iManufID As Integer = 0
        Private _booClaimable As Boolean = False
        Private _objWrtyData As PSS.Data.Buisness.TracFone.RFWrtyData
        Private _dtFailcodes As DataTable

#Region " Windows Form Designer generated code "

        Public Sub New(ByVal strSreenname As String, ByVal iCustID As Integer, ByVal iTestTypeID As Integer)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _strScreenName = strSreenname
            _iMenuCustID = iCustID
            _iTestTypeID = iTestTypeID

            _objWrtyData = New PSS.Data.Buisness.TracFone.RFWrtyData()
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
        Friend WithEvents lblMainInputName As System.Windows.Forms.Label
        Friend WithEvents txtDeviceSN As System.Windows.Forms.TextBox
        Friend WithEvents gbSoftwareVersion As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents btnFail As System.Windows.Forms.Button
        Friend WithEvents btnPass As System.Windows.Forms.Button
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents grdHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents Label8 As System.Windows.Forms.Label
        Friend WithEvents lblSN As System.Windows.Forms.Label
        Friend WithEvents lblDevRepType As System.Windows.Forms.Label
        Friend WithEvents lblDateCode As System.Windows.Forms.Label
        Friend WithEvents lblWrtyStatus As System.Windows.Forms.Label
        Friend WithEvents btnClear As System.Windows.Forms.Button
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents txtSoftVerOut As System.Windows.Forms.TextBox
        Friend WithEvents txtSoftVerIn As System.Windows.Forms.TextBox
        Friend WithEvents txtVerificationID As System.Windows.Forms.TextBox
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents lblVID As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSoftwareRefurbish))
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.lblMainInputName = New System.Windows.Forms.Label()
            Me.txtDeviceSN = New System.Windows.Forms.TextBox()
            Me.gbSoftwareVersion = New System.Windows.Forms.GroupBox()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.txtSoftVerOut = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtSoftVerIn = New System.Windows.Forms.TextBox()
            Me.lblVID = New System.Windows.Forms.Label()
            Me.txtVerificationID = New System.Windows.Forms.TextBox()
            Me.btnFail = New System.Windows.Forms.Button()
            Me.btnPass = New System.Windows.Forms.Button()
            Me.Panel3 = New System.Windows.Forms.Panel()
            Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.Label8 = New System.Windows.Forms.Label()
            Me.lblSN = New System.Windows.Forms.Label()
            Me.lblDevRepType = New System.Windows.Forms.Label()
            Me.lblDateCode = New System.Windows.Forms.Label()
            Me.lblWrtyStatus = New System.Windows.Forms.Label()
            Me.btnClear = New System.Windows.Forms.Button()
            Me.btnSave = New System.Windows.Forms.Button()
            Me.gbSoftwareVersion.SuspendLayout()
            Me.Panel3.SuspendLayout()
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(888, 48)
            Me.lblScreenName.TabIndex = 130
            Me.lblScreenName.Text = "Software Refurbish"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblMainInputName
            '
            Me.lblMainInputName.BackColor = System.Drawing.Color.Transparent
            Me.lblMainInputName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMainInputName.ForeColor = System.Drawing.Color.White
            Me.lblMainInputName.Location = New System.Drawing.Point(8, 66)
            Me.lblMainInputName.Name = "lblMainInputName"
            Me.lblMainInputName.Size = New System.Drawing.Size(160, 19)
            Me.lblMainInputName.TabIndex = 132
            Me.lblMainInputName.Text = "Device SN :"
            Me.lblMainInputName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDeviceSN
            '
            Me.txtDeviceSN.BackColor = System.Drawing.Color.White
            Me.txtDeviceSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtDeviceSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtDeviceSN.Location = New System.Drawing.Point(174, 64)
            Me.txtDeviceSN.Name = "txtDeviceSN"
            Me.txtDeviceSN.Size = New System.Drawing.Size(224, 20)
            Me.txtDeviceSN.TabIndex = 1
            Me.txtDeviceSN.Tag = ""
            Me.txtDeviceSN.Text = ""
            '
            'gbSoftwareVersion
            '
            Me.gbSoftwareVersion.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.txtSoftVerOut, Me.Label1, Me.txtSoftVerIn, Me.lblVID, Me.txtVerificationID})
            Me.gbSoftwareVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.gbSoftwareVersion.ForeColor = System.Drawing.Color.White
            Me.gbSoftwareVersion.Location = New System.Drawing.Point(0, 288)
            Me.gbSoftwareVersion.Name = "gbSoftwareVersion"
            Me.gbSoftwareVersion.Size = New System.Drawing.Size(888, 56)
            Me.gbSoftwareVersion.TabIndex = 2
            Me.gbSoftwareVersion.TabStop = False
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(256, 24)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(93, 19)
            Me.Label2.TabIndex = 136
            Me.Label2.Text = "Soft Ver. Out :"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSoftVerOut
            '
            Me.txtSoftVerOut.BackColor = System.Drawing.Color.White
            Me.txtSoftVerOut.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtSoftVerOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSoftVerOut.Location = New System.Drawing.Point(352, 24)
            Me.txtSoftVerOut.Name = "txtSoftVerOut"
            Me.txtSoftVerOut.Size = New System.Drawing.Size(136, 20)
            Me.txtSoftVerOut.TabIndex = 2
            Me.txtSoftVerOut.Tag = ""
            Me.txtSoftVerOut.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 24)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 19)
            Me.Label1.TabIndex = 134
            Me.Label1.Text = "Soft Ver. In :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSoftVerIn
            '
            Me.txtSoftVerIn.BackColor = System.Drawing.Color.White
            Me.txtSoftVerIn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtSoftVerIn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtSoftVerIn.Location = New System.Drawing.Point(88, 24)
            Me.txtSoftVerIn.Name = "txtSoftVerIn"
            Me.txtSoftVerIn.Size = New System.Drawing.Size(136, 20)
            Me.txtSoftVerIn.TabIndex = 1
            Me.txtSoftVerIn.Tag = ""
            Me.txtSoftVerIn.Text = ""
            '
            'lblVID
            '
            Me.lblVID.BackColor = System.Drawing.Color.Transparent
            Me.lblVID.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblVID.ForeColor = System.Drawing.Color.White
            Me.lblVID.Location = New System.Drawing.Point(520, 24)
            Me.lblVID.Name = "lblVID"
            Me.lblVID.Size = New System.Drawing.Size(96, 19)
            Me.lblVID.TabIndex = 134
            Me.lblVID.Text = "Verification ID :"
            Me.lblVID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtVerificationID
            '
            Me.txtVerificationID.BackColor = System.Drawing.Color.White
            Me.txtVerificationID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
            Me.txtVerificationID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.txtVerificationID.Location = New System.Drawing.Point(616, 24)
            Me.txtVerificationID.MaxLength = 4
            Me.txtVerificationID.Name = "txtVerificationID"
            Me.txtVerificationID.Size = New System.Drawing.Size(136, 20)
            Me.txtVerificationID.TabIndex = 3
            Me.txtVerificationID.Tag = ""
            Me.txtVerificationID.Text = ""
            '
            'btnFail
            '
            Me.btnFail.BackColor = System.Drawing.Color.Red
            Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFail.ForeColor = System.Drawing.Color.White
            Me.btnFail.Location = New System.Drawing.Point(408, 360)
            Me.btnFail.Name = "btnFail"
            Me.btnFail.Size = New System.Drawing.Size(168, 72)
            Me.btnFail.TabIndex = 4
            Me.btnFail.Text = "FAIL(F12)"
            '
            'btnPass
            '
            Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
            Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnPass.ForeColor = System.Drawing.Color.White
            Me.btnPass.Location = New System.Drawing.Point(208, 360)
            Me.btnPass.Name = "btnPass"
            Me.btnPass.Size = New System.Drawing.Size(144, 72)
            Me.btnPass.TabIndex = 3
            Me.btnPass.Tag = "2515"
            Me.btnPass.Text = "PASS      (F9)"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdHistory, Me.Label8, Me.lblSN})
            Me.Panel3.Location = New System.Drawing.Point(1, 104)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(887, 186)
            Me.Panel3.TabIndex = 137
            '
            'grdHistory
            '
            Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
            Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.grdHistory.Location = New System.Drawing.Point(7, 37)
            Me.grdHistory.Name = "grdHistory"
            Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.grdHistory.PreviewInfo.ZoomFactor = 75
            Me.grdHistory.Size = New System.Drawing.Size(873, 141)
            Me.grdHistory.TabIndex = 14
            Me.grdHistory.Text = "C1TrueDBGrid1"
            Me.grdHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Style9{}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightTex" & _
            "t;BackColor:Highlight;}Style12{}OddRow{}RecordSelector{AlignImage:Center;}Style1" & _
            "3{}Heading{Wrap:True;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:Contro" & _
            "lText;BackColor:Control;}Style8{}Style10{AlignHorz:Near;}Style11{}Style14{}Style" & _
            "15{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView HBarHeight=""2" & _
            "4"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" M" & _
            "arqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Vert" & _
            "icalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>137</Height><CaptionStyle " & _
            "parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><EvenR" & _
            "owStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""St" & _
            "yle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" m" & _
            "e=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle pa" & _
            "rent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" /" & _
            "><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""RecordS" & _
            "elector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style pa" & _
            "rent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 869, 137</ClientRect><BorderSide>0" & _
            "</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView></" & _
            "Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""He" & _
            "ading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capti" & _
            "on"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selecte" & _
            "d"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRo" & _
            "w"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" />" & _
            "<Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterB" & _
            "ar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpli" & _
            "ts><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defaul" & _
            "tRecSelWidth><ClientArea>0, 0, 869, 137</ClientArea><PrintPageHeaderStyle parent" & _
            "="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style15"" /></Blob>"
            '
            'Label8
            '
            Me.Label8.BackColor = System.Drawing.Color.Transparent
            Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label8.ForeColor = System.Drawing.Color.Black
            Me.Label8.Location = New System.Drawing.Point(4, 7)
            Me.Label8.Name = "Label8"
            Me.Label8.Size = New System.Drawing.Size(196, 19)
            Me.Label8.TabIndex = 74
            Me.Label8.Text = "Software Refubish History for "
            Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblSN
            '
            Me.lblSN.BackColor = System.Drawing.Color.Transparent
            Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblSN.ForeColor = System.Drawing.Color.Red
            Me.lblSN.Location = New System.Drawing.Point(208, 7)
            Me.lblSN.Name = "lblSN"
            Me.lblSN.Size = New System.Drawing.Size(218, 19)
            Me.lblSN.TabIndex = 76
            Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDevRepType
            '
            Me.lblDevRepType.BackColor = System.Drawing.Color.Black
            Me.lblDevRepType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDevRepType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDevRepType.ForeColor = System.Drawing.Color.Lime
            Me.lblDevRepType.Location = New System.Drawing.Point(430, 56)
            Me.lblDevRepType.Name = "lblDevRepType"
            Me.lblDevRepType.Size = New System.Drawing.Size(152, 32)
            Me.lblDevRepType.TabIndex = 140
            Me.lblDevRepType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblDateCode
            '
            Me.lblDateCode.BackColor = System.Drawing.Color.Black
            Me.lblDateCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblDateCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblDateCode.ForeColor = System.Drawing.Color.Lime
            Me.lblDateCode.Location = New System.Drawing.Point(782, 56)
            Me.lblDateCode.Name = "lblDateCode"
            Me.lblDateCode.Size = New System.Drawing.Size(104, 32)
            Me.lblDateCode.TabIndex = 139
            Me.lblDateCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblWrtyStatus
            '
            Me.lblWrtyStatus.BackColor = System.Drawing.Color.Black
            Me.lblWrtyStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblWrtyStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWrtyStatus.ForeColor = System.Drawing.Color.Lime
            Me.lblWrtyStatus.Location = New System.Drawing.Point(598, 56)
            Me.lblWrtyStatus.Name = "lblWrtyStatus"
            Me.lblWrtyStatus.Size = New System.Drawing.Size(168, 32)
            Me.lblWrtyStatus.TabIndex = 138
            Me.lblWrtyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnClear
            '
            Me.btnClear.BackColor = System.Drawing.Color.SteelBlue
            Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnClear.ForeColor = System.Drawing.Color.White
            Me.btnClear.Location = New System.Drawing.Point(16, 360)
            Me.btnClear.Name = "btnClear"
            Me.btnClear.Size = New System.Drawing.Size(136, 72)
            Me.btnClear.TabIndex = 141
            Me.btnClear.Text = "CLEAR     (ESC)"
            '
            'btnSave
            '
            Me.btnSave.BackColor = System.Drawing.Color.Green
            Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnSave.ForeColor = System.Drawing.Color.White
            Me.btnSave.Location = New System.Drawing.Point(632, 360)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(152, 72)
            Me.btnSave.TabIndex = 142
            Me.btnSave.Text = "SAVE (F5)"
            Me.btnSave.Visible = False
            '
            'frmSoftwareRefurbish
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(888, 462)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnSave, Me.btnClear, Me.lblDevRepType, Me.lblDateCode, Me.lblWrtyStatus, Me.Panel3, Me.btnFail, Me.btnPass, Me.gbSoftwareVersion, Me.lblMainInputName, Me.txtDeviceSN, Me.lblScreenName})
            Me.Name = "frmSoftwareRefurbish"
            Me.Text = "frmSoftwareRefurbish"
            Me.gbSoftwareVersion.ResumeLayout(False)
            Me.Panel3.ResumeLayout(False)
            CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '**********************************************************************************************************************
        Private Sub frmSoftwareRefurbish_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then Me.lblMainInputName.Text = "IMEI/MEID:"
                btnFail.BackColor = System.Drawing.Color.SteelBlue
                Me.lblScreenName.Text = _strScreenName

                '***************************
                'Define Fail code datatable
                '***************************
                Me._dtFailcodes = New DataTable()
                Generic.AddNewColumnToDataTable(Me._dtFailcodes, "Fail_ID", "System.Int32", )
                Generic.AddNewColumnToDataTable(Me._dtFailcodes, "Fail_LDesc", "System.String", )
                Generic.AddNewColumnToDataTable(Me._dtFailcodes, "trftest_id", "System.Int32", "0")    '0:Add 1:Delete

                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "frmSoftwareRefurbish_Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Function ProcessSN() As Boolean
            Dim strDevice_ccDesc, strWorkStation, strSN As String
            Dim dt1 As DataTable

            Try
                strDevice_ccDesc = "" : strWorkStation = "" : strSN = Me.txtDeviceSN.Text.Trim.ToUpper

                Me.Clear(True)

                If strSN.Length > 0 Then

                    '******************************************
                    'Get Device info and model type(Wip down/Non-WipeDown)
                    ''******************************************
                    dt1 = Generic.GetDeviceInfoInWIP(strSN, _iMenuCustID)
                    If dt1.Rows.Count = 1 Then
                        '******************************************
                        'tracfone only: check current station
                        '******************************************
                        If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                            strWorkStation = dt1.Rows(0)("WorkStation").ToString.Trim.ToUpper
                            If Misc.ValidateFrStationOfScreenInWorkFlow(Me._strScreenName, strWorkStation, Me._iMenuCustID, 0) = False Then
                                Return False
                            Else
                                '******************************************
                                If dt1.Rows(0)("FuncRep") = 1 Then Me.lblDevRepType.Text = "Functional" Else Me.lblDevRepType.Text = "Cosmetic"
                                Me.lblDateCode.Text = dt1.Rows(0)("ManufDate")
                                If dt1.Rows(0)("Device_ManufWrty") Then Me.lblWrtyStatus.Text = "In Warranty" Else Me.lblWrtyStatus.Text = "Out of Warranty"
                                Me.txtSoftVerIn.Text = dt1.Rows(0)("CellOpt_SoftVerIN")
                                Me.txtSoftVerOut.Text = dt1.Rows(0)("CellOpt_SoftVerOUT")
                                Me.txtVerificationID.Text = dt1.Rows(0)("CellOpt_VerificationID")
                                Me.lblSN.Text = strSN
                                Me._iDeviceID = dt1.Rows(0)("Device_ID")
                                _iManufID = dt1.Rows(0)("Manuf_ID")

                                '******************************************
                                'Claimable unit needs more data
                                '******************************************
                                If dt1.Rows(0)("Device_ManufWrty") = 1 Then _booClaimable = Me.IsClaimableDevice()
                                If _booClaimable = True Then
                                    Me.lblVID.ForeColor = Color.Red : Me.gbSoftwareVersion.Enabled = True
                                End If
                                '******************************************
                            End If
                        End If

                        If Me._iDeviceID > 0 Then Me.LoadTestHistory(Me._iDeviceID)

                        Me.txtDeviceSN.Text = "" : Me.txtSoftVerIn.SelectAll() : Me.txtSoftVerIn.Focus()

                    ElseIf dt1.Rows.Count = 0 Then
                        MessageBox.Show("Device does not exist in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus()
                    Else
                        MessageBox.Show("Device exist more than one in WIP.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus()
                    End If
                End If
            Catch ex As Exception
                Me.Clear(False)
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Function

        '**********************************************************************************************************************
        Private Function IsClaimableDevice() As Boolean
            Dim dt As DataTable
            Dim objTFBillingData As PSS.Data.Buisness.TracFone.TFBillingData

            Try
                'Check if device is claimable
                objTFBillingData = New PSS.Data.Buisness.TracFone.TFBillingData()
                dt = objTFBillingData.GetMaxClaimablePartsAndReflowTuningLevel(Me._iDeviceID, Me._iManufID)
                If dt.Rows.Count > 0 AndAlso dt.Rows(0)("LaborLevel") > 1 Then Return True Else Return False
            Catch ex As Exception
                Throw ex
            Finally
                objTFBillingData = Nothing
                Generic.DisposeDT(dt)
            End Try
        End Function

        '**********************************************************************************************************************
        Private Sub Clear(ByVal booKeepDeviceInfoData As Boolean)
            Try
                Me.txtDeviceSN.Text = "" : Me.txtSoftVerIn.Text = "" : Me.txtSoftVerOut.Text = "" : Me.txtVerificationID.Text = ""
                Me.btnPass.BackColor = Color.SteelBlue
                Me.btnFail.BackColor = Color.SteelBlue
                Me.btnClear.BackColor = Color.SteelBlue
                Me.lblVID.ForeColor = Color.White
                Me.btnSave.Visible = False
                Me.gbSoftwareVersion.Enabled = False

                If booKeepDeviceInfoData = False Then
                    Me.lblSN.Text = "" : Me.lblDateCode.Text = "" : Me.lblWrtyStatus.Text = "" : Me.lblDevRepType.Text = ""
                    Me.grdHistory.DataSource = Nothing
                End If

                Me._iDeviceID = 0 : Me._iResult = 0 : Me._iManufID = 0 : _booClaimable = False
                Me._dtFailcodes.Clear()
                Me.txtDeviceSN.Focus()
            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub LoadTestHistory(ByVal iDevice_ID As Integer)
            Dim dt1 As DataTable
            Dim i As Integer

            Try
                '**********************************************
                'Get history data and populate data to controls and variable
                '**********************************************
                dt1 = Me._objWrtyData.GetTestHistory(iDevice_ID, Me._iTestTypeID)

                If dt1.Rows.Count > 0 Then
                    '************************************************
                    'Set data grid layout
                    ''***********************************************
                    Me.grdHistory.DataSource = Nothing
                    Me.grdHistory.DataSource = dt1.DefaultView
                    Me.SetHistoryGridLayout(Me.grdHistory, _
                                                   Color.Black, _
                                                   New Integer() {80, 80, 70, 170, 170}, _
                                                   C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, _
                                                   New Integer() {C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Center, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near, C1.Win.C1TrueDBGrid.AlignHorzEnum.Near}, _
                                                   New String() {"QCResult_ID", "Test_ID", "TD_UsrID", "completedTechUsrID", "Device_ID", "Fail_ID"}, )
                    '************************************************
                End If
            Catch ex As Exception
                Throw ex
            Finally
                Generic.DisposeDT(dt1)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub SetHistoryGridLayout(ByRef grdCtrl As C1.Win.C1TrueDBGrid.C1TrueDBGrid, _
                                    ByVal clrHeaderForeColor As Color, _
                                    ByVal iArrColSize() As Integer, _
                                    ByVal iHeaderAlignment As Integer, _
                                    ByVal iArrColAlignment() As Integer, _
                                    ByVal strArrHideCol() As String, _
                                    Optional ByVal iGrandTotal As Integer = 0)
            Dim iNumOfColumns As Integer = grdCtrl.Columns.Count
            Dim i As Integer

            With grdCtrl
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To iArrColSize.Length - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = iHeaderAlignment 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).HeadingStyle.ForeColor = clrHeaderForeColor
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = iArrColAlignment(i) 'C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Width = iArrColSize(i)
                Next i
                For i = 0 To strArrHideCol.Length - 1
                    .Splits(0).DisplayColumns(strArrHideCol(i)).Visible = False
                Next i
            End With
        End Sub

        '**********************************************************************************************************************
        Private Sub btnPass_btnFail_btnSave_btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click, btnFail.Click, btnSave.Click, btnClear.Click
            Try
                If sender.name = "btnPass" Then
                    ProcessPass()
                ElseIf sender.name = "btnFail" Then
                    ProcessFail()
                ElseIf sender.name = "btnSave" Then
                    ProcessSave()
                ElseIf sender.name = "btnClear" Then
                    Me.Clear(True)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnPass_btnFail_btnSave_btnClear_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub KeyUpEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDeviceSN.KeyUp, txtSoftVerIn.KeyUp, _
                    txtSoftVerOut.KeyUp, txtVerificationID.KeyUp, btnPass.KeyUp, btnFail.KeyUp, btnSave.KeyUp, btnClear.KeyUp
            Try
                If e.KeyValue = 13 AndAlso sender.name = "txtDeviceSN" Then
                    Me.ProcessSN()
                ElseIf e.KeyValue = 13 AndAlso sender.name = "txtSoftVerIn" Then
                    Me.txtSoftVerOut.SelectAll() : Me.txtSoftVerOut.Focus()
                ElseIf e.KeyValue = 13 AndAlso sender.name = "txtSoftVerOut" Then
                    Me.txtVerificationID.SelectAll() : Me.txtVerificationID.Focus()
                ElseIf e.KeyCode = Keys.F5 Then
                    ProcessSave()
                ElseIf e.KeyCode = Keys.F9 Then
                    ProcessPass()
                ElseIf e.KeyCode = Keys.F12 Then
                    ProcessFail()
                ElseIf e.KeyCode = Keys.Escape Then
                    Me.Clear(False)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ProcessPass", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub ProcessPass()
            Try
                If Me._iDeviceID = 0 Then
                    Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus()
                ElseIf Me._booClaimable = True AndAlso Me.txtVerificationID.Text.Trim.Length = 0 Then
                    MessageBox.Show("You must enter verification ID.", "ProcessPass", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtVerificationID.Focus()
                ElseIf Me._booClaimable = True AndAlso Me.txtVerificationID.Text.Trim.Length <> 4 Then
                    MessageBox.Show("Verification ID must be 4 digits.", "ProcessPass", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.txtVerificationID.Focus()
                Else
                    btnPass.BackColor = System.Drawing.Color.Red
                    btnFail.BackColor = System.Drawing.Color.SteelBlue

                    Me._iResult = 1
                    Me.SaveTestInfo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ProcessPass", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub ProcessFail()
            Dim R1 As DataRow

            Try
                If Me._iDeviceID = 0 Then
                    Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus()
                Else
                    btnPass.BackColor = System.Drawing.Color.Red
                    btnFail.BackColor = System.Drawing.Color.SteelBlue

                    R1 = Me._dtFailcodes.NewRow
                    R1("Fail_ID") = 503 : R1("Fail_LDesc") = "Error in Flashing" : Me._dtFailcodes.Rows.Add(R1) : Me._dtFailcodes.AcceptChanges()

                    Me._iResult = 2
                    Me.SaveTestInfo()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "ProcessPass", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub ProcessSave()
            Try
                Me.SaveTestInfo()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnSave", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub SaveTestInfo()
            Dim objACC As Data.Production.AssignCostCenter
            Dim i As Integer = 0
            Dim strNextWrkStation As String = ""

            Try
                If Me._iDeviceID = 0 Then
                    MsgBox("You must enter a device SN/IMEI.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    Me.txtDeviceSN.Focus()
                    'ElseIf Me._iResult = 2 AndAlso Me._iTestTypeID <> 11 AndAlso (Me.lstFailCodes.Items.Count = 0 Or Me._dtFailcodes.Rows.Count = 0) Then
                    '    MsgBox("You must select a fail code.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    '    Me.cboPFCodes.Focus()
                Else
                    If Me._iResult <> 0 Then
                        If Me._iMenuCustID = PSS.Data.Buisness.TracFone.BuildShipPallet.TracFone_CUSTOMER_ID Then
                            '***********************************************
                            'Get and assign unit to workstation for TracFone
                            '***********************************************
                            If Me._iResult = 2 Then  'Fail
                                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, 1, )
                            Else
                                strNextWrkStation = Generic.GetNextWorkStationInWFP(Me._strScreenName, 0, Me._iMenuCustID, , )
                            End If

                            '***********************************************
                            'Save RF Test Result
                            '***********************************************
                            If Me._objWrtyData.InsertPFData(PSS.Core.Global.ApplicationUser.IDuser, Me._iDeviceID, Me._iTestTypeID, Me._dtFailcodes, Me._iResult, Me._strScreenName) Then
                                If strNextWrkStation.Trim.Length > 0 Then Generic.SetTcelloptWorkStationForDevice(strNextWrkStation, _iDeviceID, Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name, , Me.txtVerificationID.Text.Trim, Me.txtSoftVerIn.Text.Trim.ToUpper, Me.txtSoftVerOut.Text.Trim.ToUpper, , )
                                Me.LoadTestHistory(Me._iDeviceID)
                                MessageBox.Show("Results are saved. Unit has been pushed to " & strNextWrkStation & " workstation.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.Clear(True)
                            Else
                                Me.txtDeviceSN.SelectAll() : Me.txtDeviceSN.Focus()
                            End If
                            '***********************************************
                        End If
                        '**********************************                       
                    Else
                        MsgBox("Please select either pass or fail.", MsgBoxStyle.Information Or MsgBoxStyle.OKOnly, "Information")
                    End If

                    Me.txtDeviceSN.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "SavePretestResult")
            Finally
                objACC = Nothing
            End Try
        End Sub

        '**********************************************************************************************************************
        Private Sub txtVerificationID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVerificationID.KeyPress
            Try
                If Not Char.IsDigit(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then
                    e.Handled = True
                End If
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical Or MsgBoxStyle.OKOnly, "txtVerificationID_KeyPress")
            End Try
        End Sub

        '**********************************************************************************************************************
    End Class
End Namespace