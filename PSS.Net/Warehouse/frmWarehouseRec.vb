Imports System.IO
Imports System.Drawing.Color
Imports PSS.Core.Global
Namespace warehouse

    Public Class frmWarehouseRec
        Inherits System.Windows.Forms.Form
        Private objWarehouse As PSS.Data.Buisness.Warehouse
        Private strDirectory As String = "R:\ATCLE\ATCLE_DataFiles\"
        Private strPallett As String = ""
        Private iNoBoxForPallet As Integer = 0
        Private iWrongSKU As Integer = 0

#Region " Windows Form Designer generated code "

        Public Sub New()
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            objWarehouse = New PSS.Data.Buisness.Warehouse()

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
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Button4 As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents txtBoxSN As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Label5 As System.Windows.Forms.Label
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents txtPallet As System.Windows.Forms.TextBox
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label6 As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents lblFileDevNum As System.Windows.Forms.Label
        Friend WithEvents chkBoxEmpty As System.Windows.Forms.CheckBox
        Friend WithEvents lblMsg As System.Windows.Forms.Label
        Friend WithEvents Label7 As System.Windows.Forms.Label
        Friend WithEvents Label9 As System.Windows.Forms.Label
        Friend WithEvents Label11 As System.Windows.Forms.Label
        Friend WithEvents lblRcvd As System.Windows.Forms.Label
        Friend WithEvents lblRejected As System.Windows.Forms.Label
        Friend WithEvents lblAccepted As System.Windows.Forms.Label
        Friend WithEvents cmdDone As System.Windows.Forms.Button
        Friend WithEvents chkWrongSKU As System.Windows.Forms.CheckBox
        Friend WithEvents chkBoxEmpty_Pallet As System.Windows.Forms.CheckBox
        Friend WithEvents cmdPallet As System.Windows.Forms.Button
        Friend WithEvents cmdUndo As System.Windows.Forms.Button
        Friend WithEvents tdgDescrep As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents cmdDeleteDescrap As System.Windows.Forms.Button
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cmdDeletePallet As System.Windows.Forms.Button
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWarehouseRec))
            Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Panel6 = New System.Windows.Forms.Panel()
            Me.chkWrongSKU = New System.Windows.Forms.CheckBox()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.txtBoxSN = New System.Windows.Forms.TextBox()
            Me.Button4 = New System.Windows.Forms.Button()
            Me.chkBoxEmpty = New System.Windows.Forms.CheckBox()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.cmdPallet = New System.Windows.Forms.Button()
            Me.Label5 = New System.Windows.Forms.Label()
            Me.txtPallet = New System.Windows.Forms.TextBox()
            Me.Button1 = New System.Windows.Forms.Button()
            Me.chkBoxEmpty_Pallet = New System.Windows.Forms.CheckBox()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblRcvd = New System.Windows.Forms.Label()
            Me.Label11 = New System.Windows.Forms.Label()
            Me.lblRejected = New System.Windows.Forms.Label()
            Me.Label9 = New System.Windows.Forms.Label()
            Me.lblAccepted = New System.Windows.Forms.Label()
            Me.Label7 = New System.Windows.Forms.Label()
            Me.lblFileDevNum = New System.Windows.Forms.Label()
            Me.Label6 = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.lblMsg = New System.Windows.Forms.Label()
            Me.cmdDone = New System.Windows.Forms.Button()
            Me.cmdUndo = New System.Windows.Forms.Button()
            Me.tdgDescrep = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.cmdDeleteDescrap = New System.Windows.Forms.Button()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cmdDeletePallet = New System.Windows.Forms.Button()
            Me.Panel6.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.tdgDescrep, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Black
            Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.Yellow
            Me.Label2.Location = New System.Drawing.Point(9, 8)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(223, 96)
            Me.Label2.TabIndex = 57
            Me.Label2.Text = "DOCK RECEIVING"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel6
            '
            Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkWrongSKU, Me.Label3, Me.txtDevSN, Me.Label1, Me.txtBoxSN, Me.Button4, Me.chkBoxEmpty})
            Me.Panel6.Location = New System.Drawing.Point(8, 194)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(416, 110)
            Me.Panel6.TabIndex = 5
            '
            'chkWrongSKU
            '
            Me.chkWrongSKU.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkWrongSKU.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkWrongSKU.Location = New System.Drawing.Point(78, 48)
            Me.chkWrongSKU.Name = "chkWrongSKU"
            Me.chkWrongSKU.TabIndex = 9
            Me.chkWrongSKU.Text = "Wrong SKU"
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label3.Location = New System.Drawing.Point(16, 74)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(152, 16)
            Me.Label3.TabIndex = 85
            Me.Label3.Text = "Device Serial Number:"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDevSN
            '
            Me.txtDevSN.BackColor = System.Drawing.Color.Khaki
            Me.txtDevSN.Location = New System.Drawing.Point(168, 74)
            Me.txtDevSN.MaxLength = 15
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(159, 20)
            Me.txtDevSN.TabIndex = 7
            Me.txtDevSN.Text = ""
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label1.Location = New System.Drawing.Point(32, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(128, 16)
            Me.Label1.TabIndex = 83
            Me.Label1.Text = "Box Serial Number:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtBoxSN
            '
            Me.txtBoxSN.BackColor = System.Drawing.Color.Khaki
            Me.txtBoxSN.Location = New System.Drawing.Point(168, 10)
            Me.txtBoxSN.MaxLength = 15
            Me.txtBoxSN.Name = "txtBoxSN"
            Me.txtBoxSN.Size = New System.Drawing.Size(159, 20)
            Me.txtBoxSN.TabIndex = 6
            Me.txtBoxSN.Text = ""
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
            'chkBoxEmpty
            '
            Me.chkBoxEmpty.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkBoxEmpty.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxEmpty.Location = New System.Drawing.Point(232, 48)
            Me.chkBoxEmpty.Name = "chkBoxEmpty"
            Me.chkBoxEmpty.Size = New System.Drawing.Size(96, 24)
            Me.chkBoxEmpty.TabIndex = 8
            Me.chkBoxEmpty.Text = "Empty Box"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdPallet, Me.Label5, Me.txtPallet, Me.Button1, Me.chkBoxEmpty_Pallet})
            Me.Panel1.Location = New System.Drawing.Point(8, 110)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(416, 77)
            Me.Panel1.TabIndex = 1
            '
            'cmdPallet
            '
            Me.cmdPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.cmdPallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdPallet.ForeColor = System.Drawing.Color.White
            Me.cmdPallet.Location = New System.Drawing.Point(338, 40)
            Me.cmdPallet.Name = "cmdPallet"
            Me.cmdPallet.Size = New System.Drawing.Size(64, 22)
            Me.cmdPallet.TabIndex = 4
            Me.cmdPallet.Text = "GO"
            '
            'Label5
            '
            Me.Label5.BackColor = System.Drawing.Color.Transparent
            Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
            Me.Label5.Location = New System.Drawing.Point(61, 41)
            Me.Label5.Name = "Label5"
            Me.Label5.Size = New System.Drawing.Size(104, 16)
            Me.Label5.TabIndex = 83
            Me.Label5.Text = "Pallet Number:"
            Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtPallet
            '
            Me.txtPallet.BackColor = System.Drawing.Color.Khaki
            Me.txtPallet.Location = New System.Drawing.Point(168, 41)
            Me.txtPallet.MaxLength = 15
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
            'chkBoxEmpty_Pallet
            '
            Me.chkBoxEmpty_Pallet.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.chkBoxEmpty_Pallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.chkBoxEmpty_Pallet.Location = New System.Drawing.Point(96, 8)
            Me.chkBoxEmpty_Pallet.Name = "chkBoxEmpty_Pallet"
            Me.chkBoxEmpty_Pallet.Size = New System.Drawing.Size(232, 24)
            Me.chkBoxEmpty_Pallet.TabIndex = 3
            Me.chkBoxEmpty_Pallet.Text = "No boxes for all devices in Pallet"
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblRcvd, Me.Label11, Me.lblRejected, Me.Label9, Me.lblAccepted, Me.Label7, Me.lblFileDevNum, Me.Label6, Me.Button2})
            Me.Panel2.Location = New System.Drawing.Point(430, 109)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(388, 195)
            Me.Panel2.TabIndex = 83
            '
            'lblRcvd
            '
            Me.lblRcvd.BackColor = System.Drawing.Color.Transparent
            Me.lblRcvd.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRcvd.ForeColor = System.Drawing.Color.Lime
            Me.lblRcvd.Location = New System.Drawing.Point(240, 136)
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
            Me.Label11.Location = New System.Drawing.Point(3, 136)
            Me.Label11.Name = "Label11"
            Me.Label11.Size = New System.Drawing.Size(232, 31)
            Me.Label11.TabIndex = 89
            Me.Label11.Text = "Total Received :"
            Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRejected
            '
            Me.lblRejected.BackColor = System.Drawing.Color.Transparent
            Me.lblRejected.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblRejected.ForeColor = System.Drawing.Color.Lime
            Me.lblRejected.Location = New System.Drawing.Point(240, 96)
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
            Me.Label9.Location = New System.Drawing.Point(3, 96)
            Me.Label9.Name = "Label9"
            Me.Label9.Size = New System.Drawing.Size(232, 31)
            Me.Label9.TabIndex = 87
            Me.Label9.Text = "Rejected :"
            Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAccepted
            '
            Me.lblAccepted.BackColor = System.Drawing.Color.Transparent
            Me.lblAccepted.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblAccepted.ForeColor = System.Drawing.Color.Lime
            Me.lblAccepted.Location = New System.Drawing.Point(240, 56)
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
            Me.Label7.Location = New System.Drawing.Point(3, 56)
            Me.Label7.Name = "Label7"
            Me.Label7.Size = New System.Drawing.Size(232, 31)
            Me.Label7.TabIndex = 85
            Me.Label7.Text = "Accepted :"
            Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFileDevNum
            '
            Me.lblFileDevNum.BackColor = System.Drawing.Color.Transparent
            Me.lblFileDevNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblFileDevNum.ForeColor = System.Drawing.Color.Lime
            Me.lblFileDevNum.Location = New System.Drawing.Point(240, 17)
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
            Me.Label6.Location = New System.Drawing.Point(3, 17)
            Me.Label6.Name = "Label6"
            Me.Label6.Size = New System.Drawing.Size(232, 31)
            Me.Label6.TabIndex = 83
            Me.Label6.Text = "Devices in file :"
            Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(144, 245)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(200, 31)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'lblMsg
            '
            Me.lblMsg.BackColor = System.Drawing.Color.SteelBlue
            Me.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 72.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMsg.ForeColor = System.Drawing.Color.White
            Me.lblMsg.Location = New System.Drawing.Point(242, 8)
            Me.lblMsg.Name = "lblMsg"
            Me.lblMsg.Size = New System.Drawing.Size(576, 96)
            Me.lblMsg.TabIndex = 84
            Me.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmdDone
            '
            Me.cmdDone.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDone.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDone.ForeColor = System.Drawing.Color.Navy
            Me.cmdDone.Location = New System.Drawing.Point(196, 488)
            Me.cmdDone.Name = "cmdDone"
            Me.cmdDone.Size = New System.Drawing.Size(437, 40)
            Me.cmdDone.TabIndex = 13
            Me.cmdDone.Text = "DONE with this Pallet"
            '
            'cmdUndo
            '
            Me.cmdUndo.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdUndo.Enabled = False
            Me.cmdUndo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdUndo.ForeColor = System.Drawing.Color.Red
            Me.cmdUndo.Location = New System.Drawing.Point(305, 427)
            Me.cmdUndo.Name = "cmdUndo"
            Me.cmdUndo.Size = New System.Drawing.Size(216, 32)
            Me.cmdUndo.TabIndex = 12
            Me.cmdUndo.Text = "UNDO (Last Reject Only)"
            '
            'tdgDescrep
            '
            Me.tdgDescrep.AllowFilter = True
            Me.tdgDescrep.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
            Me.tdgDescrep.AllowSort = True
            Me.tdgDescrep.BackColor = System.Drawing.Color.LightSteelBlue
            Me.tdgDescrep.CaptionHeight = 17
            Me.tdgDescrep.CollapseColor = System.Drawing.Color.Black
            Me.tdgDescrep.DataChanged = False
            Me.tdgDescrep.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.tdgDescrep.ExpandColor = System.Drawing.Color.Black
            Me.tdgDescrep.GroupByCaption = "Drag a column header here to group by that column"
            Me.tdgDescrep.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.tdgDescrep.Location = New System.Drawing.Point(8, 331)
            Me.tdgDescrep.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
            Me.tdgDescrep.Name = "tdgDescrep"
            Me.tdgDescrep.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.tdgDescrep.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.tdgDescrep.PreviewInfo.ZoomFactor = 75
            Me.tdgDescrep.PrintInfo.ShowOptionsDialog = False
            Me.tdgDescrep.RecordSelectorWidth = 16
            GridLines1.Color = System.Drawing.Color.DarkGray
            GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
            Me.tdgDescrep.RowDivider = GridLines1
            Me.tdgDescrep.RowHeight = 15
            Me.tdgDescrep.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.tdgDescrep.ScrollTips = False
            Me.tdgDescrep.Size = New System.Drawing.Size(809, 88)
            Me.tdgDescrep.TabIndex = 10
            Me.tdgDescrep.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
            "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
            "er;}Normal{BackColor:LightSteelBlue;}HighlightRow{ForeColor:HighlightText;BackCo" & _
            "lor:Highlight;}Style9{}OddRow{}RecordSelector{AlignImage:Center;}Heading{Wrap:Tr" & _
            "ue;AlignVert:Center;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;BackColor:Co" & _
            "ntrol;}Style8{}Style10{AlignHorz:Near;}Style11{}Style12{}Style13{}Style1{}</Data" & _
            "></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView Name="""" CaptionHeight=""17"" Colu" & _
            "mnCaptionHeight=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" Rec" & _
            "ordSelectorWidth=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScro" & _
            "llGroup=""1""><ClientRect>0, 0, 805, 84</ClientRect><BorderSide>0</BorderSide><Cap" & _
            "tionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5" & _
            """ /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterB" & _
            "ar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent" & _
            "=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightR" & _
            "owStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=" & _
            """Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle paren" & _
            "t=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /" & _
            "><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1TrueDBGrid.MergeView></Splits><" & _
            "NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""Heading"" /" & _
            "><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Caption"" /><S" & _
            "tyle parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Selected"" /><St" & _
            "yle parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightRow"" /><St" & _
            "yle parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style p" & _
            "arent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""FilterBar"" /><S" & _
            "tyle parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSplits><horz" & _
            "Splits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>16</DefaultRecSelW" & _
            "idth><ClientArea>0, 0, 805, 84</ClientArea></Blob>"
            '
            'cmdDeleteDescrap
            '
            Me.cmdDeleteDescrap.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDeleteDescrap.Enabled = False
            Me.cmdDeleteDescrap.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDeleteDescrap.ForeColor = System.Drawing.Color.Red
            Me.cmdDeleteDescrap.Location = New System.Drawing.Point(83, 427)
            Me.cmdDeleteDescrap.Name = "cmdDeleteDescrap"
            Me.cmdDeleteDescrap.Size = New System.Drawing.Size(216, 32)
            Me.cmdDeleteDescrap.TabIndex = 11
            Me.cmdDeleteDescrap.Text = "Delete Selected Descrepancy"
            Me.cmdDeleteDescrap.Visible = False
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 306)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(216, 24)
            Me.Label4.TabIndex = 89
            Me.Label4.Text = "Rejected/Descrepancies:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'cmdDeletePallet
            '
            Me.cmdDeletePallet.BackColor = System.Drawing.Color.LightSteelBlue
            Me.cmdDeletePallet.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmdDeletePallet.ForeColor = System.Drawing.Color.Red
            Me.cmdDeletePallet.Location = New System.Drawing.Point(527, 427)
            Me.cmdDeletePallet.Name = "cmdDeletePallet"
            Me.cmdDeletePallet.Size = New System.Drawing.Size(216, 32)
            Me.cmdDeletePallet.TabIndex = 90
            Me.cmdDeletePallet.Text = "Delete Pallet to Re-receive"
            '
            'frmWarehouseRec
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.BackColor = System.Drawing.Color.SteelBlue
            Me.ClientSize = New System.Drawing.Size(832, 604)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDeletePallet, Me.Label4, Me.cmdDeleteDescrap, Me.tdgDescrep, Me.cmdUndo, Me.cmdDone, Me.lblMsg, Me.Panel2, Me.Panel1, Me.Panel6, Me.Label2})
            Me.Name = "frmWarehouseRec"
            Me.Text = "Warehouse Receiving"
            Me.Panel6.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            CType(Me.tdgDescrep, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        '*********************************************************
        Private Sub txtBoxSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBoxSN.KeyDown
            If e.KeyValue = 13 Then
                Try
                    If strPallett = "" Then
                        txtBoxSN.Text = ""
                        Exit Sub
                    End If

                    'If Me.chkWrongSKU.Checked = True Then
                    '    iWrongSKU = 1
                    'Else
                    '    iWrongSKU = 0
                    'End If

                    Me.lblMsg.Text = ""
                    Me.lblMsg.BackColor = SteelBlue

                    System.Windows.Forms.Application.DoEvents()

                    If Trim(Me.txtBoxSN.Text) <> "" And (Trim(Me.txtDevSN.Text) <> "" Or Me.chkBoxEmpty.Checked = True) Then
                        Me.chkBoxEmpty.Checked = False
                        Dim i As Integer = 0

                        If Me.chkBoxEmpty.Checked = True Then
                            i = objWarehouse.ProcessSerialNumbers(strPallett, Trim(Me.txtBoxSN.Text), "", 1, iNoBoxForPallet, iWrongSKU)
                        Else
                            i = objWarehouse.ProcessSerialNumbers(strPallett, Trim(Me.txtBoxSN.Text), Trim(Me.txtDevSN.Text), 0, iNoBoxForPallet, iWrongSKU)
                        End If

                        'Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0)
                        'Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1)
                        'Me.lblRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)

                        If objWarehouse.Result = 1 Then
                            Me.cmdUndo.Enabled = True
                        Else
                            Me.cmdUndo.Enabled = False
                        End If

                        RecalculateNumbers()
                        FormatControls(i)
                        LoadDescrepancies()
                        Me.txtBoxSN.Focus()
                    Else
                        If Me.txtBoxSN.Text = "" Then
                            Me.txtBoxSN.Focus()
                        ElseIf Me.txtDevSN.Text = "" Then
                            Me.txtDevSN.Focus()
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("txtBoxSN_KeyDown: " & Environment.NewLine & ex.Message, "Input Box SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.chkBoxEmpty.Checked = False
                    Me.txtBoxSN.Focus()
                End Try
            End If
        End Sub
        '*********************************************************
        Private Sub txtDevSN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyDown
            If e.KeyValue = 13 Then
                Try


                    If strPallett = "" Then
                        txtDevSN.Text = ""
                        Exit Sub
                    End If

                    'If Me.chkWrongSKU.Checked = True Then
                    '    iWrongSKU = 1
                    'Else
                    '    iWrongSKU = 0
                    'End If

                    Me.lblMsg.Text = ""
                    Me.lblMsg.BackColor = SteelBlue

                    Dim i As Integer = 0

                    If iNoBoxForPallet = 1 Then
                        If Trim(Me.txtDevSN.Text) <> "" Then
                            i = objWarehouse.ProcessSerialNumbers(strPallett, Trim(Me.txtBoxSN.Text), Trim(Me.txtDevSN.Text), 0, iNoBoxForPallet, iWrongSKU)

                            If objWarehouse.Result = 1 Then
                                Me.cmdUndo.Enabled = True
                            Else
                                Me.cmdUndo.Enabled = False
                            End If

                            RecalculateNumbers()
                            'Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0)
                            'Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1)
                            'Me.lblRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)
                            FormatControls(i)
                            LoadDescrepancies()
                            Me.txtDevSN.Focus()
                        Else
                            Me.txtDevSN.Focus()
                        End If
                    Else
                        Me.chkBoxEmpty.Checked = False
                        System.Windows.Forms.Application.DoEvents()
                        If Trim(Me.txtBoxSN.Text) <> "" And Trim(Me.txtDevSN.Text) <> "" Then
                            i = objWarehouse.ProcessSerialNumbers(strPallett, Trim(Me.txtBoxSN.Text), Trim(Me.txtDevSN.Text), 0, iNoBoxForPallet, iWrongSKU)

                            If objWarehouse.Result = 1 Then
                                Me.cmdUndo.Enabled = True
                            Else
                                Me.cmdUndo.Enabled = False
                            End If

                            RecalculateNumbers()
                            FormatControls(i)
                            LoadDescrepancies()
                            Me.txtBoxSN.Focus()
                        Else
                            If Me.txtBoxSN.Text = "" Then
                                Me.txtBoxSN.Focus()
                            ElseIf Me.txtDevSN.Text = "" Then
                                Me.chkBoxEmpty.Focus()
                            End If
                        End If
                    End If

                Catch ex As Exception
                    MessageBox.Show("txtDevSN_KeyDown: " & Environment.NewLine & ex.Message, "Input Device SN", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.chkBoxEmpty.Checked = False
                    Me.txtBoxSN.Focus()
                End Try
            End If
        End Sub

        '*********************************************************
        Private Sub RecalculateNumbers()
            Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0)
            Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1)
            Me.lblRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)
        End Sub
        '*********************************************************
        Protected Overrides Sub Finalize()
            objWarehouse = Nothing
            MyBase.Finalize()
        End Sub
        '*********************************************************
        Private Sub chkBoxEmpty_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBoxEmpty.CheckedChanged
            Try
                If strPallett = "" Then
                    Me.chkBoxEmpty.Checked = False
                    Exit Sub
                End If



                If Me.chkBoxEmpty.Checked Then
                    If Trim(Me.txtBoxSN.Text) = "" Then
                        MessageBox.Show("Please input Box Serial Number.", "Input Box Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.chkBoxEmpty.Checked = False
                        Me.txtBoxSN.Focus()
                        Exit Sub
                    ElseIf Trim(Me.txtDevSN.Text) <> "" Then
                        MessageBox.Show("Please clear Device Serial Number.", "Input Device Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                        Me.chkBoxEmpty.Checked = False
                        Me.txtDevSN.Focus()
                        Exit Sub
                    End If
                    Dim i As Integer = 0
                    i = objWarehouse.ProcessSerialNumbers(strPallett, Trim(Me.txtBoxSN.Text), Trim(Me.txtDevSN.Text), 1, iNoBoxForPallet, iWrongSKU)

                    If objWarehouse.Result = 1 Then
                        Me.cmdUndo.Enabled = True
                    Else
                        Me.cmdUndo.Enabled = False
                    End If

                    RecalculateNumbers()
                    'Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0)
                    'Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1)
                    'Me.lblRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)

                    FormatControls(i)
                    LoadDescrepancies()
                    Me.txtBoxSN.Focus()
                Else
                    If Me.txtBoxSN.Text = "" Then
                        Me.txtBoxSN.Focus()
                    ElseIf Me.txtDevSN.Text = "" Then
                        Me.txtDevSN.Focus()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show("chkBoxEmpty_CheckedChanged: " & Environment.NewLine & ex.Message, "Empty Box", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtBoxSN.Text = ""
                Me.txtDevSN.Text = ""
                Me.chkBoxEmpty.Checked = False
                Me.txtBoxSN.Focus()
            End Try
        End Sub
        '*********************************************************
        Private Sub FormatControls(ByVal i As Integer)
            Select Case i

                Case 0          'No descrepencies
                    'Me.BackColor = SteelBlue
                    'Me.lblMsg.BackColor = SteelBlue
                    'Me.lblMsg.ForeColor = ForestGreen
                    Me.lblMsg.BackColor = ForestGreen
                    Me.lblMsg.Text = "ACCEPTED"
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.chkBoxEmpty.Checked = False
                    Me.txtBoxSN.Focus()
                    System.Windows.Forms.Application.DoEvents()

                Case 1          'Descrepencies are there
                    'Me.BackColor = Red
                    'Me.lblMsg.BackColor = White
                    'Me.lblMsg.ForeColor = Red
                    Me.lblMsg.BackColor = Red
                    Me.lblMsg.Text = "REJECTED"
                    Me.txtBoxSN.Text = ""
                    Me.txtDevSN.Text = ""
                    Me.chkBoxEmpty.Checked = False
                    Me.txtBoxSN.Focus()
                    System.Windows.Forms.Application.DoEvents()

            End Select
            Me.chkWrongSKU.Checked = False
        End Sub
        '*********************************************************
        Private Sub frmWarehouseRec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Me.txtPallet.Focus()

            'Set Special permissions
            If ApplicationUser.GetPermission("DockReceiving_Delete") > 0 Then
                Me.cmdDeleteDescrap.Visible = True
                Me.cmdDeletePallet.Visible = True
            Else
                Me.cmdDeleteDescrap.Visible = False
                Me.cmdDeletePallet.Visible = False
            End If
        End Sub
        '*********************************************************
        Private Sub cmdDone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDone.Click
            Dim i As Integer = 0

            Try
                If strPallett = "" Then
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure you want to close this pallet?" & Environment.NewLine & "Once the Pallet is closed it can not be reopened!", "Close Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    If CInt(Me.lblFileDevNum.Text) - CInt(Me.lblRcvd.Text) > 0 Then
                        i = 1   'Received number is less than file number
                    ElseIf CInt(Me.lblFileDevNum.Text) - CInt(Me.lblRcvd.Text) < 0 Then
                        i = 2   'Received number is greater than file number
                    End If

                    'Close out Pallet
                    i = objWarehouse.ClosePallet(strPallett, i)
                    If i = 0 Then
                        Throw New Exception("There was a problem closing out the pallet. Contact administrators.")
                    End If

                    'Generate Report
                    i = objWarehouse.CreateReport(strPallett)

                    ClearControls()
                Else
                    Exit Sub
                End If

            Catch ex As Exception
                MessageBox.Show("cmdDone_Click: " & Environment.NewLine & ex.Message, "Close Pallet", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        '*********************************************************
        Private Sub ClearControls()
            Me.lblMsg.Text = ""
            Me.lblMsg.BackColor = SteelBlue
            Me.lblFileDevNum.Text = ""
            Me.lblAccepted.Text = ""
            Me.lblRejected.Text = ""
            Me.lblRcvd.Text = ""
            Me.txtPallet.Text = ""
            Me.strPallett = ""
            Me.txtBoxSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.chkBoxEmpty.Checked = False
            Me.chkBoxEmpty_Pallet.Checked = False
            Me.chkBoxEmpty.Enabled = True
            Me.txtBoxSN.Enabled = True
            Me.tdgDescrep.ClearFields()
        End Sub
        '*********************************************************
        Private Sub OpenPallet()
            '*********************************************************
            'Step 1: Look for the file for the pallet
            Dim dirs As String()
            Dim i As Integer = 0
            Dim iNoBox As Integer = 0
            Dim dt1 As DataTable
            Dim R1 As DataRow

            Me.txtBoxSN.Text = ""
            Me.txtDevSN.Text = ""
            Me.lblFileDevNum.Text = ""
            Me.lblAccepted.Text = ""
            Me.lblRejected.Text = ""
            Me.lblRcvd.Text = ""
            Me.chkBoxEmpty.Checked = False
            strPallett = ""
            Me.tdgDescrep.ClearFields()
            strPallett = Trim(Me.txtPallet.Text)

            Dim strFileName As String = strPallett & ".xls"
            Dim strFilePath As String = strDirectory & strFileName

            Try
                If Me.chkBoxEmpty_Pallet.Checked = True Then
                    If MessageBox.Show("Are you sure there are no boxes for this whole pallet?" & Environment.NewLine & "This action can not be undone.", "No Boxes for Pallet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        iNoBox = 1
                    Else
                        Me.txtDevSN.Focus()
                        Exit Sub
                    End If
                End If

                dirs = Directory.GetFiles(strDirectory, strFileName)
                If dirs.Length > 0 Then
                    i = objWarehouse.LoadFile(strPallett, strFilePath, iNoBox)
                    If i = -1 Then      'Pallet was closed
                        Me.txtPallet.Text = ""
                        Throw New Exception("This Pallet has been closed. To rereceive delete it from the system first.")
                    Else                'Pallet was loaded but not closed yet
                        'Get Total Devices in the File loaded in to DB
                        Me.lblFileDevNum.Text = objWarehouse.GetDevCountFromLoadedFile(strPallett)

                        dt1 = objWarehouse.GetWarehousePalletInfo(strPallett)
                        For Each R1 In dt1.Rows
                            If R1("WHPallet_NoBox") = 1 Then
                                Me.chkBoxEmpty_Pallet.Checked = True
                                Me.txtBoxSN.Enabled = False
                                Me.chkBoxEmpty.Enabled = False
                                iNoBoxForPallet = 1
                                Me.txtDevSN.Focus()
                            Else
                                Me.chkBoxEmpty_Pallet.Checked = False
                                Me.txtBoxSN.Enabled = True
                                Me.chkBoxEmpty.Enabled = True
                                iNoBoxForPallet = 0
                                Me.txtBoxSN.Focus()
                            End If
                        Next R1

                        RecalculateNumbers()
                        'Me.lblAccepted.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 0)
                        'Me.lblRejected.Text = objWarehouse.GetAcceptedRejectedDevices(strPallett, 1)
                        'Me.lblRcvd.Text = CInt(Me.lblAccepted.Text) + CInt(Me.lblRejected.Text)

                        LoadDescrepancies()

                        System.Windows.Forms.Application.DoEvents()
                    End If
                Else
                    Throw New Exception("File does not exist for the Pallet you have entered. Check the Pallet number and reinput.")
                End If
            Catch ex As Exception
                MessageBox.Show("txtPallet_KeyDown: " & Environment.NewLine & ex.Message, "Pallet Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtBoxSN.Text = ""
                Me.txtDevSN.Text = ""
                Me.lblFileDevNum.Text = ""
                Me.lblAccepted.Text = ""
                Me.lblRejected.Text = ""
                Me.lblRcvd.Text = ""
                Me.chkBoxEmpty.Checked = False
                Me.txtPallet.Text = ""
                strPallett = ""
                Me.txtPallet.Focus()
            Finally
                dirs = Nothing
                R1 = Nothing
                If Not IsNothing(dt1) Then
                    dt1.Dispose()
                    dt1 = Nothing
                End If
            End Try
            '*********************************************************
        End Sub
        '*********************************************************
        Private Sub cmdPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPallet.Click
            OpenPallet()
        End Sub
        '*********************************************************
        Private Sub chkWrongSKU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWrongSKU.CheckedChanged
            If Me.strPallett = "" Then
                Me.chkWrongSKU.Checked = False
                Exit Sub
            End If
            If Me.chkWrongSKU.Checked = True Then
                iWrongSKU = 1
            Else
                iWrongSKU = 0
            End If
            If Me.txtBoxSN.Enabled = True And Me.txtBoxSN.Text = "" Then
                Me.txtBoxSN.Focus()
            Else
                Me.txtDevSN.Focus()
            End If
        End Sub
        '*********************************************************
        Private Sub txtPallet_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPallet.KeyDown
            If e.KeyValue = 13 Then
                OpenPallet()
                'LoadDescrepancies()
            End If
        End Sub
        '*********************************************************
        Private Sub LoadDescrepancies()
            Dim dt1 As DataTable

            Try
                If Trim(strPallett) = "" Then
                    Exit Sub
                End If

                'select * from twarehousereceive where whpallet_id = 30 and whr_result = 1 order by whr_id desc
                dt1 = objWarehouse.LoadDockDescrepancies(strPallett)
                Me.tdgDescrep.ClearFields()


                If dt1.Rows.Count > 0 Then
                    Me.tdgDescrep.DataSource = dt1.DefaultView
                    SetGridProperties()
                    Me.cmdDeleteDescrap.Enabled = True
                    'Me.cmdDeletePallet.Enabled = True
                Else
                    Me.cmdDeleteDescrap.Enabled = False
                    'Me.cmdDeletePallet.Enabled = False
                    Me.cmdUndo.Enabled = False
                End If

            Catch ex As Exception
                Throw New Exception("frmQC.LoadQCHistory(): " & Environment.NewLine & ex.Message.ToString)
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
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(5).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                .Splits(0).DisplayColumns(6).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

                'Set Column Widths
                .Splits(0).DisplayColumns(0).Width = 110
                .Splits(0).DisplayColumns(1).Width = 110
                .Splits(0).DisplayColumns(2).Width = 118
                .Splits(0).DisplayColumns(3).Width = 172
                .Splits(0).DisplayColumns(4).Width = 142
                .Splits(0).DisplayColumns(5).Width = 62
                .Splits(0).DisplayColumns(6).Width = 66

                'Make some columns invisible
                .Splits(0).DisplayColumns(7).Visible = False

            End With
        End Sub

        '****************************************************************
        Private Sub cmdDeleteDescrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteDescrap.Click
            Dim i As Integer = 0
            Try
                If Me.tdgDescrep.Columns.Count = 0 Then
                    Exit Sub
                End If
                If CInt(Me.tdgDescrep.Columns("whr_id").Value) = 0 Then
                    Exit Sub
                End If
                If MessageBox.Show("Are you sure you want to delete this Descrepancy?", "Delete Descrepancy", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    i = objWarehouse.DeleteDescrepancy(CInt(Me.tdgDescrep.Columns("whr_id").Value)) 'whr_id
                    RecalculateNumbers()
                    LoadDescrepancies()

                    If Me.txtBoxSN.Enabled = True Then
                        If Trim(Me.txtBoxSN.Text) = "" Then
                            Me.txtBoxSN.Focus()
                        Else
                            Me.txtDevSN.Focus()
                        End If
                    Else
                        Me.txtDevSN.Focus()
                    End If
                Else
                    Exit Sub
                End If
                '******************************************************
            Catch ex As Exception
                MsgBox("frmWarehouseRec.cmdDeleteDescrap_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Dock Receiving")
            End Try
        End Sub

        Private Sub cmdUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUndo.Click
            Dim i As Integer = 0
            Try
                If MessageBox.Show("Are you sure you want to undo the last rejected scan?", "Undo Last Scan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    If objWarehouse.Result = 1 Then
                        If objWarehouse.WHR_ID > 0 Then
                            i = objWarehouse.DeleteDescrepancy(objWarehouse.WHR_ID)
                            RecalculateNumbers()
                            LoadDescrepancies()
                            objWarehouse.WHR_ID = 0
                            objWarehouse.Result = 0
                            Me.cmdUndo.Enabled = False

                            If Me.txtBoxSN.Enabled = True Then
                                If Trim(Me.txtBoxSN.Text) = "" Then
                                    Me.txtBoxSN.Focus()
                                Else
                                    Me.txtDevSN.Focus()
                                End If
                            Else
                                Me.txtDevSN.Focus()
                            End If

                        End If
                    End If
                End If
                
            Catch ex As Exception
                MsgBox("frmWarehouseRec.cmdDeleteDescrap_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Dock Receiving")
            End Try

        End Sub

        Private Sub cmdDeletePallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeletePallet.Click
            Dim i As Integer = 0

            Try
                i = objWarehouse.DeletePalletFromDockReceiving(Trim(InputBox("Input Pallet Number.", "Delete Pallet")))

                If i > 0 Then
                    MessageBox.Show("Pallet successfully deleted.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    ClearControls()
                Else
                    MessageBox.Show("Pallet could not be deleted.", "Delete Pallet", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If

            Catch ex As Exception
                MsgBox("frmWarehouseRec.cmdDeletePallet_Click: " & ex.Message.ToString, MsgBoxStyle.Critical, "Delete Pallet")
            End Try

        End Sub
    End Class
End Namespace