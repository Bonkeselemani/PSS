Imports System.IO
Imports System.Drawing.Color
Imports PSS.Core.[Global]
Namespace warehouse

    Public Class frmWarehouseRec_OEM
        Inherits System.Windows.Forms.Form
        Private _objWHR_OEM As PSS.Data.Buisness.WarehouseRec_OEM
        Private _iMachineGroupID As Integer = PSS.Core.[Global].ApplicationUser.GroupID
        Private _iUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser
        Private _iEENum As Integer = PSS.Core.[Global].ApplicationUser.NumberEmp
        Private _iCustID As Integer = 2249
        Private _iLoc_ID As Integer = 2773
        Private _iPallet_ID As Integer = 0
        Private _iWrty As Integer = Nothing
        Private _iModel_ID As Integer = 0
        Private _iCurrentYr As Integer = 0
        Private _iCurrentWeek As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            _objWHR_OEM = New PSS.Data.Buisness.WarehouseRec_OEM()

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
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents txtPallet As System.Windows.Forms.TextBox
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents lblFileDevNum As System.Windows.Forms.Label
        Friend WithEvents lblMsg As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblRcvd As System.Windows.Forms.Label
        Friend WithEvents lblRejected As System.Windows.Forms.Label
        Friend WithEvents lblAccepted As System.Windows.Forms.Label
        Friend WithEvents cmdDone As System.Windows.Forms.Button
        Friend WithEvents cmdPallet As System.Windows.Forms.Button
        Friend WithEvents tdgDescrep As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmdDeleteDescrap As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents PanelATCLE As System.Windows.Forms.Panel
        Friend WithEvents PanelDevNoSN As System.Windows.Forms.Panel
        Friend WithEvents Button8 As System.Windows.Forms.Button
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents Button7 As System.Windows.Forms.Button
        Friend WithEvents chkWrongSKU As System.Windows.Forms.CheckBox
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents PanelOptions As System.Windows.Forms.Panel
        Friend WithEvents Button3 As System.Windows.Forms.Button
        Friend WithEvents chkMultiPhone As System.Windows.Forms.CheckBox
        Friend WithEvents chkBoxEmpty As System.Windows.Forms.CheckBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents PanelDevice As System.Windows.Forms.Panel
        Friend WithEvents Button6 As System.Windows.Forms.Button
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents cmdNewPallet As System.Windows.Forms.Button
        Friend WithEvents txtSN As System.Windows.Forms.TextBox
        Friend WithEvents txtIMEI As System.Windows.Forms.TextBox
        Friend WithEvents lblModel As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWarehouseRec_OEM))
            Me.lblHeader = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.lblModel = New System.Windows.Forms.Label()
            Me.cmdNewPallet = New System.Windows.Forms.Button()
            Me.cmdPallet = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtPallet = New System.Windows.Forms.TextBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.PanelATCLE = New System.Windows.Forms.Panel()
            Me.lblRcvd = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblRejected = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblAccepted = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblFileDevNum = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.lblMsg = New System.Windows.Forms.Label()
            Me.cmdDone = New System.Windows.Forms.Button()
            Me.tdgDescrep = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cmdDeleteDescrap = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.PanelDevNoSN = New System.Windows.Forms.Panel()
            Me.Button8 = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtSN = New System.Windows.Forms.TextBox()
            Me.Panel4 = New System.Windows.Forms.Panel()
            Me.Button7 = New System.Windows.Forms.Button()
            Me.chkWrongSKU = New System.Windows.Forms.CheckBox()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.PanelOptions = New System.Windows.Forms.Panel()
            Me.Button3 = New System.Windows.Forms.Button()
            Me.chkMultiPhone = New System.Windows.Forms.CheckBox()
            Me.chkBoxEmpty = New System.Windows.Forms.CheckBox()
            Me.PanelDevice = New System.Windows.Forms.Panel()
            Me.Button6 = New System.Windows.Forms.Button()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtIMEI = New System.Windows.Forms.TextBox()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.Panel1.SuspendLayout()
            Me.PanelATCLE.SuspendLayout()
            CType(Me.tdgDescrep, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelDevNoSN.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.PanelOptions.SuspendLayout()
            Me.PanelDevice.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Black
            Me.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblHeader.ForeColor = System.Drawing.Color.Yellow
            Me.lblHeader.Location = New System.Drawing.Point(9, 6)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(223, 104)
            Me.lblHeader.TabIndex = 57
            Me.lblHeader.Text = "HUAWEI RECEIVING"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblModel, Me.cmdNewPallet, Me.cmdPallet, Me.Label5, Me.txtPallet, Me.Button1})
            Me.Panel1.Location = New System.Drawing.Point(8, 110)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(536, 64)
            Me.Panel1.TabIndex = 1
            '
            'lblModel
            '
            Me.lblModel.BackColor = System.Drawing.Color.Transparent
            Me.lblModel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblModel.ForeColor = System.Drawing.Color.Blue
            Me.lblModel.Location = New System.Drawing.Point(112, 40)
            Me.lblModel.Name = "lblModel"
            Me.lblModel.Size = New System.Drawing.Size(152, 16)
            Me.lblModel.TabIndex = 87
            Me.lblModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmdNewPallet
            '
            Me.cmdNewPallet.BackColor = System.Drawing.Color.Green
            Me.cmdNewPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdNewPallet.ForeColor = System.Drawing.Color.White
            Me.cmdNewPallet.Location = New System.Drawing.Point(406, 8)
            Me.cmdNewPallet.Name = "cmdNewPallet"
            Me.cmdNewPallet.Size = New System.Drawing.Size(120, 32)
            Me.cmdNewPallet.TabIndex = 86
            Me.cmdNewPallet.Text = "New RMA"
            '
            'cmdPallet
            '
            Me.cmdPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdPallet.ForeColor = System.Drawing.Color.White
            Me.cmdPallet.Location = New System.Drawing.Point(275, 8)
            Me.cmdPallet.Name = "cmdPallet"
            Me.cmdPallet.Size = New System.Drawing.Size(40, 22)
            Me.cmdPallet.TabIndex = 4
            Me.cmdPallet.Text = "GO"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(0, 8)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 16)
            Me.Label5.TabIndex = 83
            Me.Label5.Text = "RMA Number:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPallet
            '
            Me.txtPallet.BackColor = System.Drawing.Color.Khaki
            Me.txtPallet.Location = New System.Drawing.Point(112, 8)
            Me.txtPallet.MaxLength = 30
            Me.txtPallet.Name = "txtPallet"
            Me.txtPallet.Size = New System.Drawing.Size(159, 20)
            Me.txtPallet.TabIndex = 2
            Me.txtPallet.Text = ""
            '
            'Button1
            '
            Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button1.Location = New System.Drawing.Point(144, 245)
            Me.Button1.Name = "Button1"
            Me.Button1.Size = New System.Drawing.Size(200, 31)
            Me.Button1.TabIndex = 66
            Me.Button1.TabStop = False
            Me.Button1.Text = "Generate Report"
            '
            'PanelATCLE
            '
            Me.PanelATCLE.BackColor = System.Drawing.Color.Black
            Me.PanelATCLE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelATCLE.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRcvd, Me.Label11, Me.lblRejected, Me.Label9, Me.lblAccepted, Me.Label7, Me.lblFileDevNum, Me.Label6})
            Me.PanelATCLE.Location = New System.Drawing.Point(544, 110)
            Me.PanelATCLE.Name = "PanelATCLE"
            Me.PanelATCLE.Size = New System.Drawing.Size(339, 184)
            Me.PanelATCLE.TabIndex = 83
            '
            'lblRcvd
            '
            Me.lblRcvd.BackColor = System.Drawing.Color.Transparent
            Me.lblRcvd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRcvd.ForeColor = System.Drawing.Color.Lime
            Me.lblRcvd.Location = New System.Drawing.Point(225, 136)
            Me.lblRcvd.Name = "lblRcvd"
            Me.lblRcvd.Size = New System.Drawing.Size(96, 31)
            Me.lblRcvd.TabIndex = 90
            Me.lblRcvd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label11
            '
            Me.Label11.BackColor = System.Drawing.Color.Transparent
            Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label11.ForeColor = System.Drawing.Color.Lime
            Me.Label11.Location = New System.Drawing.Point(-3, 136)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(224, 31)
            Me.Label11.TabIndex = 89
            Me.Label11.Text = "Total Received :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRejected
            '
            Me.lblRejected.BackColor = System.Drawing.Color.Transparent
            Me.lblRejected.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRejected.ForeColor = System.Drawing.Color.Lime
            Me.lblRejected.Location = New System.Drawing.Point(225, 96)
            Me.lblRejected.Name = "lblRejected"
            Me.lblRejected.Size = New System.Drawing.Size(96, 31)
            Me.lblRejected.TabIndex = 88
            Me.lblRejected.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label9
            '
            Me.Label9.BackColor = System.Drawing.Color.Transparent
            Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label9.ForeColor = System.Drawing.Color.Lime
            Me.Label9.Location = New System.Drawing.Point(13, 96)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(208, 31)
            Me.Label9.TabIndex = 87
            Me.Label9.Text = "Rejected :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAccepted
            '
            Me.lblAccepted.BackColor = System.Drawing.Color.Transparent
            Me.lblAccepted.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccepted.ForeColor = System.Drawing.Color.Lime
            Me.lblAccepted.Location = New System.Drawing.Point(225, 56)
            Me.lblAccepted.Name = "lblAccepted"
            Me.lblAccepted.Size = New System.Drawing.Size(96, 31)
            Me.lblAccepted.TabIndex = 86
            Me.lblAccepted.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label7
            '
            Me.Label7.BackColor = System.Drawing.Color.Transparent
            Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label7.ForeColor = System.Drawing.Color.Lime
            Me.Label7.Location = New System.Drawing.Point(13, 56)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(208, 31)
            Me.Label7.TabIndex = 85
            Me.Label7.Text = "Accepted :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFileDevNum
            '
            Me.lblFileDevNum.BackColor = System.Drawing.Color.Transparent
            Me.lblFileDevNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFileDevNum.ForeColor = System.Drawing.Color.Lime
            Me.lblFileDevNum.Location = New System.Drawing.Point(225, 16)
            Me.lblFileDevNum.Name = "lblFileDevNum"
            Me.lblFileDevNum.Size = New System.Drawing.Size(96, 31)
            Me.lblFileDevNum.TabIndex = 84
            Me.lblFileDevNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Label6
            '
            Me.Label6.BackColor = System.Drawing.Color.Transparent
            Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label6.ForeColor = System.Drawing.Color.Lime
            Me.Label6.Location = New System.Drawing.Point(13, 16)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(208, 31)
            Me.Label6.TabIndex = 83
            Me.Label6.Text = "Devices in file :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblMsg
            '
            Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
            Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 48.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMsg.ForeColor = System.Drawing.Color.White
            Me.lblMsg.Location = New System.Drawing.Point(233, 6)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(650, 104)
            Me.lblMsg.TabIndex = 84
            Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmdDone
            '
            Me.cmdDone.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDone.ForeColor = System.Drawing.Color.Navy
            Me.cmdDone.Location = New System.Drawing.Point(600, 448)
            Me.cmdDone.Name = "cmdDone"
            Me.cmdDone.Size = New System.Drawing.Size(280, 40)
            Me.cmdDone.TabIndex = 13
            Me.cmdDone.Text = "CLOSE PALLET"
            '
            'tdgDescrep
            '
            Me.tdgDescrep.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDescrep.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgDescrep.Location = New System.Drawing.Point(8, 320)
            Me.tdgDescrep.Name = "tdgDescrep"
            Me.tdgDescrep.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDescrep.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDescrep.PreviewInfo.ZoomFactor = 75
            Me.tdgDescrep.Size = New System.Drawing.Size(874, 120)
            Me.tdgDescrep.TabIndex = 10
            Me.tdgDescrep.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Caption{AlignHorz:Center;}Normal{BackColor:SteelBlue;}Selected{ForeColo" & _
            "r:HighlightText;BackColor:Highlight;}Editor{}Style18{}Style19{}Style14{}Style15{" & _
            "}Style16{}Style17{}Style10{AlignHorz:Near;}Style11{}OddRow{}Style13{}Style12{}Hi" & _
            "ghlightRow{ForeColor:HighlightText;BackColor:Highlight;}RecordSelector{AlignImag" & _
            "e:Center;}Footer{}Style21{}Style20{}Inactive{ForeColor:InactiveCaptionText;BackC" & _
            "olor:InactiveCaption;}EvenRow{BackColor:Aqua;}Heading{Wrap:True;BackColor:Contro" & _
            "l;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}FilterBar{}S" & _
            "tyle4{}Style9{}Style8{}Style5{}Group{AlignVert:Center;Border:None,,0, 0, 0, 0;Ba" & _
            "ckColor:ControlDark;}Style7{}Style6{}Style1{}Style3{}Style2{}</Data></Styles><Sp" & _
            "lits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" ColumnCaptionHeig" & _
            "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
            "dth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
            "Height>116</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle par" & _
            "ent=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterB" & _
            "arStyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style" & _
            "3"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me" & _
            "=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyl" & _
            "e parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Re" & _
            "cordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""" & _
            "Selected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 8" & _
            "70, 116</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle><" & _
            "/C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal" & _
            """ /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" />" & _
            "<Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><" & _
            "Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Styl" & _
            "e parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Sty" & _
            "le parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><" & _
            "Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Na" & _
            "medStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layo" & _
            "ut><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 870, 116</Client" & _
            "Area><PrintPageHeaderStyle parent="""" me=""Style20"" /><PrintPageFooterStyle parent" & _
            "="""" me=""Style21"" /></Blob>"
            '
            'cmdDeleteDescrap
            '
            Me.cmdDeleteDescrap.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDeleteDescrap.Enabled = False
            Me.cmdDeleteDescrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDeleteDescrap.ForeColor = System.Drawing.Color.Red
            Me.cmdDeleteDescrap.Location = New System.Drawing.Point(8, 448)
            Me.cmdDeleteDescrap.Name = "cmdDeleteDescrap"
            Me.cmdDeleteDescrap.Size = New System.Drawing.Size(216, 40)
            Me.cmdDeleteDescrap.TabIndex = 11
            Me.cmdDeleteDescrap.Text = "Delete Selected Discrepancy"
            Me.cmdDeleteDescrap.Visible = False
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 302)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(216, 16)
            Me.Label4.TabIndex = 89
            Me.Label4.Text = "Discrepancies:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Black
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Yellow
            Me.lblGroup.Location = New System.Drawing.Point(14, 85)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(209, 23)
            Me.lblGroup.TabIndex = 98
            Me.lblGroup.Text = "CELLULAR 1 STAGE 1"
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'PanelDevNoSN
            '
            Me.PanelDevNoSN.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelDevNoSN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelDevNoSN.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button8, Me.Label1, Me.txtSN})
            Me.PanelDevNoSN.Location = New System.Drawing.Point(7, 8)
            Me.PanelDevNoSN.Name = "PanelDevNoSN"
            Me.PanelDevNoSN.Size = New System.Drawing.Size(323, 40)
            Me.PanelDevNoSN.TabIndex = 103
            '
            'Button8
            '
            Me.Button8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button8.Location = New System.Drawing.Point(144, 245)
            Me.Button8.Name = "Button8"
            Me.Button8.Size = New System.Drawing.Size(200, 31)
            Me.Button8.TabIndex = 66
            Me.Button8.TabStop = False
            Me.Button8.Text = "Generate Report"
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(0, 8)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(104, 16)
            Me.Label1.TabIndex = 83
            Me.Label1.Text = "Serial Number :"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSN
            '
            Me.txtSN.BackColor = System.Drawing.Color.Khaki
            Me.txtSN.Location = New System.Drawing.Point(112, 6)
            Me.txtSN.MaxLength = 15
            Me.txtSN.Name = "txtSN"
            Me.txtSN.Size = New System.Drawing.Size(159, 20)
            Me.txtSN.TabIndex = 6
            Me.txtSN.Text = ""
            '
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button7, Me.chkWrongSKU})
            Me.Panel4.Location = New System.Drawing.Point(336, 78)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(192, 32)
            Me.Panel4.TabIndex = 102
            Me.Panel4.Visible = False
            '
            'Button7
            '
            Me.Button7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button7.Location = New System.Drawing.Point(144, 245)
            Me.Button7.Name = "Button7"
            Me.Button7.Size = New System.Drawing.Size(200, 31)
            Me.Button7.TabIndex = 66
            Me.Button7.TabStop = False
            Me.Button7.Text = "Generate Report"
            '
            'chkWrongSKU
            '
            Me.chkWrongSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkWrongSKU.ForeColor = System.Drawing.Color.White
            Me.chkWrongSKU.Location = New System.Drawing.Point(16, 0)
            Me.chkWrongSKU.Name = "chkWrongSKU"
            Me.chkWrongSKU.TabIndex = 9
            Me.chkWrongSKU.Text = "Wrong SKU"
            '
            'Button4
            '
            Me.Button4.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Button4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button4.Location = New System.Drawing.Point(144, 245)
            Me.Button4.Name = "Button4"
            Me.Button4.Size = New System.Drawing.Size(200, 31)
            Me.Button4.TabIndex = 66
            Me.Button4.TabStop = False
            Me.Button4.Text = "Generate Report"
            '
            'PanelOptions
            '
            Me.PanelOptions.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelOptions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelOptions.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.chkMultiPhone, Me.chkBoxEmpty})
            Me.PanelOptions.Location = New System.Drawing.Point(336, 4)
            Me.PanelOptions.Name = "PanelOptions"
            Me.PanelOptions.Size = New System.Drawing.Size(192, 72)
            Me.PanelOptions.TabIndex = 99
            Me.PanelOptions.Visible = False
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
            'chkMultiPhone
            '
            Me.chkMultiPhone.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkMultiPhone.ForeColor = System.Drawing.Color.White
            Me.chkMultiPhone.Location = New System.Drawing.Point(16, 32)
            Me.chkMultiPhone.Name = "chkMultiPhone"
            Me.chkMultiPhone.Size = New System.Drawing.Size(168, 24)
            Me.chkMultiPhone.TabIndex = 86
            Me.chkMultiPhone.Text = "Multiple Phones in Box"
            '
            'chkBoxEmpty
            '
            Me.chkBoxEmpty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxEmpty.ForeColor = System.Drawing.Color.White
            Me.chkBoxEmpty.Location = New System.Drawing.Point(16, 8)
            Me.chkBoxEmpty.Name = "chkBoxEmpty"
            Me.chkBoxEmpty.Size = New System.Drawing.Size(96, 24)
            Me.chkBoxEmpty.TabIndex = 8
            Me.chkBoxEmpty.Text = "Empty Box"
            '
            'PanelDevice
            '
            Me.PanelDevice.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelDevice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelDevice.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button6, Me.Label3, Me.txtIMEI})
            Me.PanelDevice.Location = New System.Drawing.Point(8, 64)
            Me.PanelDevice.Name = "PanelDevice"
            Me.PanelDevice.Size = New System.Drawing.Size(323, 40)
            Me.PanelDevice.TabIndex = 101
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
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(9, 9)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 85
            Me.Label3.Text = "IMEI:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtIMEI
            '
            Me.txtIMEI.BackColor = System.Drawing.Color.Khaki
            Me.txtIMEI.Location = New System.Drawing.Point(112, 8)
            Me.txtIMEI.MaxLength = 15
            Me.txtIMEI.Name = "txtIMEI"
            Me.txtIMEI.Size = New System.Drawing.Size(159, 20)
            Me.txtIMEI.TabIndex = 7
            Me.txtIMEI.Text = ""
            '
            'Panel6
            '
            Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelDevNoSN, Me.Panel4, Me.Button4, Me.PanelOptions, Me.PanelDevice})
            Me.Panel6.Location = New System.Drawing.Point(7, 177)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(536, 117)
            Me.Panel6.TabIndex = 5
            '
            'frmWarehouseRec_OEM
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(896, 501)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblGroup, Me.Label4, Me.cmdDeleteDescrap, Me.tdgDescrep, Me.cmdDone, Me.lblMsg, Me.PanelATCLE, Me.Panel1, Me.Panel6, Me.lblHeader})
            Me.Name = "frmWarehouseRec_OEM"
            Me.Text = "-"
            Me.Panel1.ResumeLayout(False)
            Me.PanelATCLE.ResumeLayout(False)
            CType(Me.tdgDescrep, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelDevNoSN.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.PanelOptions.ResumeLayout(False)
            Me.PanelDevice.ResumeLayout(False)
            Me.Panel6.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************
        Private Sub frmWarehouseRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Try
                If _iMachineGroupID = 0 Then
                    MessageBox.Show("This Computer is not mapped to any Line/Group. Receiving can not be done.")
                    Me.Close()
                End If

                '**************************************
                'Set Special permissions
                '**************************************
                If ApplicationUser.GetPermission("DockReceiving_Delete") > 0 Then
                    Me.cmdDeleteDescrap.Visible = True
                Else
                    Me.cmdDeleteDescrap.Visible = False
                End If
                '**************************************

                Me._iCurrentYr = Me._objWHR_OEM.GetCurrentYr()
                Me._iCurrentWeek = Me._objWHR_OEM.GetCurrentWeek()

                Me.txtPallet.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString)
            End Try
        End Sub

        '****************************************************************
        Private Sub cmdNewPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewPallet.Click
            Me.CleareVarsAndCtrls()
        End Sub

        '****************************************************************
        Private Sub CleareVarsAndCtrls()
            Me._iPallet_ID = 0
            Me._iModel_ID = 0
            Me._iWrty = Nothing

            Me.tdgDescrep.ClearFields()
            Me.txtPallet.Text = ""
            Me.txtSN.Text = ""
            Me.txtIMEI.Text = ""
            Me.lblFileDevNum.Text = ""
            Me.lblAccepted.Text = ""
            Me.lblRejected.Text = ""
            Me.lblRcvd.Text = ""

            Me.txtPallet.Enabled = True
            Me.lblModel.Text = ""
            Me.lblMsg.Text = ""
            Me.lblMsg.BackColor = Color.SteelBlue

        End Sub

        '*********************************************************
        Private Sub txtPallet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPallet.KeyDown
            Try
                If e.KeyValue = 13 Then
                    OpenPallet()
                    Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        '*********************************************************
        Private Sub OpenPallet()
            Dim dt1 As DataTable
            Dim R1 As DataRow
            Dim strPalletName As String = ""

            Try
                strPalletName = Me.txtPallet.Text.Trim.ToUpper
                Me.CleareVarsAndCtrls()

                Me.txtPallet.Text = strPalletName

                dt1 = _objWHR_OEM.GetWHPalletInfo(Me._iCustID, Me.txtPallet.Text.Trim.ToUpper)
                If dt1.Rows.Count > 0 Then
                    R1 = dt1.Rows(0)
                    Me._iPallet_ID = R1("WHPallet_ID")
                    Me._iModel_ID = R1("Model_ID")
                    Me.lblModel.Text = R1("Model_Desc")

                    Me.lblFileDevNum.Text = _objWHR_OEM.GetDevCountFromLoadedFile(Me._iPallet_ID)
                    Me.RecalculateNumbers()
                    Me.LoadDescrepancies()
                    Me.txtPallet.Enabled = False
                    '***************************************
                Else
                    MessageBox.Show("Pallet does not exist.", "Pallet Input", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, "Pallet Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me._iPallet_ID = 0
                Me.txtPallet.SelectAll()
                Me.txtPallet.Focus()
            Finally
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '*********************************************************
        Private Sub cmdPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPallet.Click
            Try
                OpenPallet()
                Me.txtSN.Focus()
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
            End Try
        End Sub

        '*********************************************************
        Private Sub RecalculateNumbers()
            Dim iTotal As Integer = 0
            Try
                Me.lblAccepted.Text = Me._objWHR_OEM.GetAcceptedRejectedDevices(Me._iPallet_ID, 0)
                Me.lblRejected.Text = Me._objWHR_OEM.GetAcceptedRejectedDevices(Me._iPallet_ID, 1)
                If Me.lblAccepted.Text <> "" Then
                    iTotal += CInt(Me.lblAccepted.Text)
                End If
                If Me.lblRejected.Text <> "" Then
                    iTotal += CInt(Me.lblRejected.Text)
                End If
                Me.lblRcvd.Text = iTotal
            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        '*********************************************************
        Private Sub txtSN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyDown

            Try
                If e.KeyValue = 13 Then
                    If Me._iPallet_ID = 0 Then
                        MsgBox("Please enter RMA number.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If

                    If Me.txtSN.Text.Trim <> "" Then
                        If Me.txtSN.Text.Trim.ToUpper.StartsWith("HT") = False Then
                            MsgBox("Incorrect format of SN. SN must start with HT.", MsgBoxStyle.Critical)
                            Exit Sub
                        End If

                        Me._iWrty = Me.CheckEOMWrty()
                        If Me._iWrty > 0 Then
                            Me.lblMsg.Text = "IN WARRANTY"
                            Me.lblMsg.BackColor = Color.SteelBlue
                        Else
                            Me.lblMsg.Text = "OUT WARRANTY"
                            Me.lblMsg.BackColor = Color.ForestGreen
                        End If

                        Me.txtIMEI.Text = ""
                        Me.txtIMEI.Focus()
                    End If
                    End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Input SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtSN.SelectAll()
            End Try
        End Sub

        '*********************************************************
        Public Function CheckEOMWrty() As Integer
            Dim iWty As Integer = 0

            Try
                If CInt(Mid(Me.txtSN.Text.Trim.ToUpper, 3, 1)) + 1 > Me._iCurrentYr Then
                    iWty = 1
                ElseIf CInt(Mid(Me.txtSN.Text.Trim.ToUpper, 3, 1)) + 1 = Me._iCurrentYr And CInt(Mid(Me.txtSN.Text.Trim.ToUpper, 4, 2) >= Me._iCurrentWeek) Then
                    iWty = 1
                End If

                Return iWty
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        '*********************************************************
        Private Sub txtDevSN_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtIMEI.KeyDown
            Dim iWrongSKU As Integer = 0
            Dim i As Integer = 0
            Dim WHP_ID As Integer = 0

            Try
                If e.KeyValue = 13 Then
                    If Me._iPallet_ID = 0 Then
                        MsgBox("Please enter RMA number.", MsgBoxStyle.Critical)
                        Exit Sub
                    ElseIf Me.txtSN.Text.Trim = "" Or IsNothing(Me._iWrty) Then
                        MsgBox("Please enter SN number and press enter.", MsgBoxStyle.Critical)
                        Exit Sub
                    ElseIf Me.txtIMEI.Text.Trim = "" Then
                        Exit Sub
                    End If

                    If Me._objWHR_OEM.IsExistedInWHR(Me.txtIMEI.Text.Trim, Me._iPallet_ID) = True Then
                        MessageBox.Show("This IMEI already received.", "Scan SN", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If

                    WHP_ID = Me._objWHR_OEM.GetWHPLoadID(Me.txtIMEI.Text.Trim, Me._iPallet_ID)

                    If Me.chkWrongSKU.Checked = True Then
                        iWrongSKU = 1
                    End If

                    If WHP_ID = 0 Then
                        If MessageBox.Show("This IMEI (" & Me.txtIMEI.Text.Trim & ") is missing in the ASN file. Would you like to receive as discrepancy?.", "Scan SN", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            Me.txtSN.Text = ""
                            Me.txtIMEI.Text = ""
                            Me._iWrty = Nothing
                            Me.lblMsg.Text = ""
                            Me.lblMsg.BackColor = SteelBlue
                            Me.txtSN.Focus()
                            Exit Sub
                        Else
                            Me.lblMsg.Text = "REJECT"
                            Me.lblMsg.BackColor = Red
                        End If
                    End If

                    '********************************************************
                    i = Me._objWHR_OEM.ProcessSerialNumbers(Me.txtSN.Text.Trim.ToUpper, _
                                                            Me.txtIMEI.Text.Trim.ToUpper, _
                                                            Me._iWrty, iWrongSKU, _
                                                            WHP_ID, _
                                                            Me._iPallet_ID, _
                                                            Me._iMachineGroupID, _
                                                            PSS.Core.[Global].ApplicationUser.IDuser, _
                                                            Me._iModel_ID)

                    RecalculateNumbers()
                    LoadDescrepancies()

                    Me.txtSN.Text = ""
                    Me.txtIMEI.Text = ""
                    Me._iWrty = Nothing

                    Me.txtSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Input Device SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                Me.txtIMEI.Text = ""
                Me._iWrty = Nothing
                Me.txtSN.Focus()
            End Try
        End Sub

        '*********************************************************
        Protected Overrides Sub Finalize()
            Me._objWHR_OEM = Nothing
            MyBase.Finalize()
        End Sub


        '*********************************************************
        Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click
            Dim iTotalRcvd As Integer = 0
            Dim i As Integer = 0
            Dim iPallet_Discrepancy As Integer = 0

            Try
                If MessageBox.Show("Are you sure you want to close this pallet?", "Close pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Me.cmdDone.Enabled = False

                    '********************************
                    'Validate data
                    '********************************
                    If Me._iPallet_ID = 0 Then
                        MessageBox.Show("WHPallet ID is not defined.", "Validate Pallet ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtPallet.SelectAll()
                        Exit Sub
                    End If

                    If Me.lblFileDevNum.Text = "0" Then
                        MessageBox.Show("This pallet is empty.", "Pallet QTY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtPallet.SelectAll()
                        Exit Sub
                    End If

                    iTotalRcvd = CInt(Me.lblRcvd.Text.Trim)

                    If iTotalRcvd = 0 Then
                        MessageBox.Show("This pallet is empty.", "Pallet QTY", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtPallet.SelectAll()
                        Exit Sub
                    End If

                    If CInt(Me.lblFileDevNum.Text.Trim) <> CInt(Me.lblRcvd.Text.Trim) Then
                        If MessageBox.Show("You are about to close a pallet discrepancy quantity. Do you want to continue?", "Verify Pallet Qty", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                            Me.txtPallet.SelectAll()
                            Exit Sub
                        End If
                        iPallet_Discrepancy = 1
                    End If

                    '**************************
                    'Re-validate pallet again
                    '**************************
                    If Me.ValidateWHPallet = False Then
                        Exit Sub
                    End If
                    '**************************

                    Me.Enabled = False
                    Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

                    '********************************
                    'Close pallet
                    '********************************
                    i = Me._objWHR_OEM.CloseWHPallet(Me.txtPallet.Text.Trim.ToUpper, _
                                                  Me._iPallet_ID, _
                                                  iTotalRcvd, _
                                                  Me._iCustID, _
                                                  Me._iLoc_ID, _
                                                  2, _
                                                  Me._iMachineGroupID, _
                                                  1, _
                                                  Me._iEENum, _
                                                  Me._iUserID, _
                                                  PSS.Core.[Global].ApplicationUser.User, _
                                                  PSS.Core.[Global].ApplicationUser.Workdate, _
                                                  iPallet_Discrepancy, )
                    '********************************
                    'display confirm message
                    '********************************
                    If i = 0 Then
                        Throw New Exception("There was a problem closing out the pallet. Contact Administrator.")
                    Else
                        MessageBox.Show("Pallet is closed.", "Close Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.CleareVarsAndCtrls()
                        '********************************
                    End If
                Else
                    Me.txtPallet.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show("cmdClosePallet_Click: " & Environment.NewLine & ex.Message.ToString, "Scan Device SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.cmdDone.Enabled = True
                Me.Enabled = True
                Cursor.Current = System.Windows.Forms.Cursors.Default
                Me.txtPallet.Focus()
            End Try
        End Sub

        '**********************************************************************
        Private Function ValidateWHPallet() As Boolean
            Dim dt1 As DataTable
            Dim bReturnVal As Boolean = False

            Try
                '***************************
                'get pallet info if existed
                '***************************
                dt1 = Me._objWHR_OEM.GetWHPalletInfo(Me._iCustID, Me.txtPallet.Text.Trim.ToUpper)
                If IsNothing(dt1) Or dt1.Rows.Count = 0 Then
                    MessageBox.Show("Pallet does not exist.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                    Me.txtPallet.SelectAll()
                    Return bReturnVal
                End If

                '***************************
                'validate existed pallet
                '***************************
                If Not IsDBNull(dt1.Rows(0)("WHPalletClosed")) Then
                    If dt1.Rows(0)("WHPalletClosed") = 1 Then
                        MessageBox.Show("Pallet was closed.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtPallet.SelectAll()
                        Return bReturnVal
                    End If
                End If
                If Not IsDBNull(dt1.Rows(0)("WHP_PalletRcvd")) Then
                    If dt1.Rows(0)("WHP_PalletRcvd") = 1 Then
                        MessageBox.Show("Pallet was production received.", "Validate Pallet", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.txtPallet.SelectAll()
                        Return bReturnVal
                    End If
                End If

                bReturnVal = True

                Return bReturnVal
            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Function

        '*********************************************************
        Private Sub LoadDescrepancies()
            Dim dt1 As DataTable

            Try
                If Me._iPallet_ID = 0 Then
                    Exit Sub
                End If

                'select * from twarehousereceive where whpallet_id = 30 and whr_result = 1 order by whr_id desc
                dt1 = Me._objWHR_OEM.LoadDockDescrepancies(Me._iPallet_ID)
                Me.tdgDescrep.ClearFields()


                If dt1.Rows.Count > 0 Then
                    Me.tdgDescrep.DataSource = dt1.DefaultView
                    SetGridProperties()
                    Me.cmdDeleteDescrap.Enabled = True
                Else
                    Me.cmdDeleteDescrap.Enabled = False
                End If

            Catch ex As Exception
                Throw ex
            Finally
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
        End Sub

        '*********************************************************
        Private Sub SetGridProperties()
            Dim iNumOfColumns As Integer = Me.tdgDescrep.Columns.Count
            Dim i As Integer


            With tdgDescrep
                'Heading style (Horizontal Alignment to Center)
                For i = 0 To (iNumOfColumns - 1)
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Next

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns(1).Width = 155
                .Splits(0).DisplayColumns(2).Width = 155

                'Make some columns invisible
                .Splits(0).DisplayColumns(0).Visible = False

            End With
        End Sub

        '*********************************************************
        Private Sub cmdDeleteDescrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteDescrap.Click
            Dim i As Integer = 0

            Try
                If Me.tdgDescrep.Columns.Count = 0 Then
                    Exit Sub
                End If
                If CInt(Me.tdgDescrep.Columns("whr_id").Value) = 0 Then
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure you want to delete the selected Descrepancy?", "Delete Descrepancy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    i = Me._objWHR_OEM.DeleteDescrepancy(CInt(Me.tdgDescrep.Columns("whr_id").Value)) 'whr_id
                    RecalculateNumbers()
                    LoadDescrepancies()

                    Me.txtSN.Text = ""
                    Me.txtIMEI.Text = ""
                    Me.txtSN.Focus()
                Else
                    Exit Sub
                End If
                '******************************************************
            Catch ex As Exception
                MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "Delete Discrepancy")
            End Try
        End Sub

        '*********************************************************

    End Class
End Namespace