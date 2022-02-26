'Public Class frmWCTrayScan
'    Inherits System.Windows.Forms.Form
'    Private objMisc As PSS.Data.Buisness.Misc
'    Private iWCLocation_ID As Integer = 0
'    'Private str As String = ""

'#Region " Windows Form Designer generated code "

'    Public Sub New()
'        MyBase.New()

'        'This call is required by the Windows Form Designer.
'        InitializeComponent()

'        'Add any initialization after the InitializeComponent() call
'        objMisc = New PSS.Data.Buisness.Misc()
'    End Sub

'    'Form overrides dispose to clean up the component list.
'    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
'        If disposing Then
'            If Not (components Is Nothing) Then
'                components.Dispose()
'            End If
'        End If
'        MyBase.Dispose(disposing)
'    End Sub

'    'Required by the Windows Form Designer
'    Private components As System.ComponentModel.IContainer

'    'NOTE: The following procedure is required by the Windows Form Designer
'    'It can be modified using the Windows Form Designer.  
'    'Do not modify it using the code editor.
'    Friend WithEvents Label1 As System.Windows.Forms.Label
'    Friend WithEvents txtTray As System.Windows.Forms.TextBox
'    Friend WithEvents grdTrayInfo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
'    Friend WithEvents btnUpdate As System.Windows.Forms.Button
'    Friend WithEvents Label2 As System.Windows.Forms.Label
'    Friend WithEvents Panel3 As System.Windows.Forms.Panel
'    Friend WithEvents cboWCLoc As PSS.Gui.Controls.ComboBox
'    Friend WithEvents Panel4 As System.Windows.Forms.Panel
'    Friend WithEvents pnlLocation As System.Windows.Forms.Panel
'    Friend WithEvents lblWCName As System.Windows.Forms.Label
'    Friend WithEvents cmdCreateRpt As System.Windows.Forms.Button
'    Friend WithEvents Label7 As System.Windows.Forms.Label
'    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
'    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
'    Friend WithEvents Label8 As System.Windows.Forms.Label
'    Friend WithEvents cmdBillPro As System.Windows.Forms.Button
'    Friend WithEvents panelBillPro As System.Windows.Forms.Panel
'    Friend WithEvents cmdWCSumRpt As System.Windows.Forms.Button
'    Friend WithEvents cmdCancel As System.Windows.Forms.Button
'    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
'        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWCTrayScan))
'        Me.Label1 = New System.Windows.Forms.Label()
'        Me.txtTray = New System.Windows.Forms.TextBox()
'        Me.grdTrayInfo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
'        Me.lblWCName = New System.Windows.Forms.Label()
'        Me.btnUpdate = New System.Windows.Forms.Button()
'        Me.pnlLocation = New System.Windows.Forms.Panel()
'        Me.Label2 = New System.Windows.Forms.Label()
'        Me.cboWCLoc = New PSS.Gui.Controls.ComboBox()
'        Me.Panel3 = New System.Windows.Forms.Panel()
'        Me.Panel4 = New System.Windows.Forms.Panel()
'        Me.cmdBillPro = New System.Windows.Forms.Button()
'        Me.cmdCreateRpt = New System.Windows.Forms.Button()
'        Me.panelBillPro = New System.Windows.Forms.Panel()
'        Me.cmdCancel = New System.Windows.Forms.Button()
'        Me.Label7 = New System.Windows.Forms.Label()
'        Me.cmdWCSumRpt = New System.Windows.Forms.Button()
'        Me.dtpToDate = New System.Windows.Forms.DateTimePicker()
'        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
'        Me.Label8 = New System.Windows.Forms.Label()
'        CType(Me.grdTrayInfo, System.ComponentModel.ISupportInitialize).BeginInit()
'        Me.pnlLocation.SuspendLayout()
'        Me.Panel3.SuspendLayout()
'        Me.Panel4.SuspendLayout()
'        Me.panelBillPro.SuspendLayout()
'        Me.SuspendLayout()
'        '
'        'Label1
'        '
'        Me.Label1.BackColor = System.Drawing.Color.Transparent
'        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
'        Me.Label1.Location = New System.Drawing.Point(40, 11)
'        Me.Label1.Name = "Label1"
'        Me.Label1.Size = New System.Drawing.Size(80, 16)
'        Me.Label1.TabIndex = 54
'        Me.Label1.Text = "Scan Tray:"
'        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'txtTray
'        '
'        Me.txtTray.BackColor = System.Drawing.SystemColors.Window
'        Me.txtTray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
'        Me.txtTray.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.txtTray.ForeColor = System.Drawing.Color.Black
'        Me.txtTray.Location = New System.Drawing.Point(120, 8)
'        Me.txtTray.Name = "txtTray"
'        Me.txtTray.Size = New System.Drawing.Size(112, 21)
'        Me.txtTray.TabIndex = 1
'        Me.txtTray.Text = ""
'        '
'        'grdTrayInfo
'        '
'        Me.grdTrayInfo.AllowArrows = False
'        Me.grdTrayInfo.AllowColMove = False
'        Me.grdTrayInfo.AllowColSelect = False
'        Me.grdTrayInfo.AllowFilter = False
'        Me.grdTrayInfo.AllowRowSelect = False
'        Me.grdTrayInfo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
'        Me.grdTrayInfo.AllowSort = False
'        Me.grdTrayInfo.AllowUpdate = False
'        Me.grdTrayInfo.AllowUpdateOnBlur = False
'        Me.grdTrayInfo.AlternatingRows = True
'        Me.grdTrayInfo.CaptionHeight = 17
'        Me.grdTrayInfo.EditDropDown = False
'        Me.grdTrayInfo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.grdTrayInfo.GroupByCaption = "Drag a column header here to group by that column"
'        Me.grdTrayInfo.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
'        Me.grdTrayInfo.Location = New System.Drawing.Point(8, 35)
'        Me.grdTrayInfo.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
'        Me.grdTrayInfo.Name = "grdTrayInfo"
'        Me.grdTrayInfo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
'        Me.grdTrayInfo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
'        Me.grdTrayInfo.PreviewInfo.ZoomFactor = 75
'        Me.grdTrayInfo.RowHeight = 15
'        Me.grdTrayInfo.Size = New System.Drawing.Size(512, 183)
'        Me.grdTrayInfo.TabIndex = 56
'        Me.grdTrayInfo.TabStop = False
'        Me.grdTrayInfo.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
'        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}S" & _
'        "tyle12{}Style13{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:LightSteelBlu" & _
'        "e;}Selected{ForeColor:HighlightText;BackColor:Highlight;}Heading{Wrap:True;Align" & _
'        "Horz:Center;BackColor:Control;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;Al" & _
'        "ignVert:Center;}Inactive{ForeColor:InactiveCaptionText;BackColor:InactiveCaption" & _
'        ";}FilterBar{}Footer{}Caption{AlignHorz:Center;}Editor{}Style10{AlignHorz:Near;}N" & _
'        "ormal{Font:Verdana, 8.25pt;AlignHorz:Center;BackColor:Window;}Style29{}Style28{}" & _
'        "Style27{}Style26{}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Styl" & _
'        "e2{}OddRow{}RecordSelector{AlignImage:Center;}Style1{}Style8{}Style3{}Style11{}S" & _
'        "tyle14{}Style15{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.MergeView " & _
'        "AllowColMove=""False"" AllowColSelect=""False"" AllowRowSelect=""False"" Name="""" Allow" & _
'        "RowSizing=""None"" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeig" & _
'        "ht=""17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWi" & _
'        "dth=""17"" DefRecSelWidth=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><" & _
'        "Height>179</Height><CaptionStyle parent=""Heading"" me=""Style10"" /><EditorStyle pa" & _
'        "rent=""Editor"" me=""Style2"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><Filter" & _
'        "BarStyle parent=""FilterBar"" me=""Style29"" /><FooterStyle parent=""Footer"" me=""Styl" & _
'        "e4"" /><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" m" & _
'        "e=""Style3"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveSty" & _
'        "le parent=""Inactive"" me=""Style6"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><R" & _
'        "ecordSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=" & _
'        """Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, " & _
'        "508, 179</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle>" & _
'        "</C1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Norma" & _
'        "l"" /><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /" & _
'        "><Style parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" />" & _
'        "<Style parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Sty" & _
'        "le parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><St" & _
'        "yle parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" />" & _
'        "<Style parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></N" & _
'        "amedStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified<" & _
'        "/Layout><DefaultRecSelWidth>17</DefaultRecSelWidth><ClientArea>0, 0, 508, 179</C" & _
'        "lientArea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle p" & _
'        "arent="""" me=""Style15"" /></Blob>"
'        '
'        'lblWCName
'        '
'        Me.lblWCName.Font = New System.Drawing.Font("Comic Sans MS", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.lblWCName.ForeColor = System.Drawing.Color.White
'        Me.lblWCName.Location = New System.Drawing.Point(7, 6)
'        Me.lblWCName.Name = "lblWCName"
'        Me.lblWCName.Size = New System.Drawing.Size(265, 16)
'        Me.lblWCName.TabIndex = 59
'        Me.lblWCName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'btnUpdate
'        '
'        Me.btnUpdate.BackColor = System.Drawing.Color.LightSteelBlue
'        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.btnUpdate.ForeColor = System.Drawing.SystemColors.ControlText
'        Me.btnUpdate.Location = New System.Drawing.Point(427, 3)
'        Me.btnUpdate.Name = "btnUpdate"
'        Me.btnUpdate.Size = New System.Drawing.Size(151, 24)
'        Me.btnUpdate.TabIndex = 2
'        Me.btnUpdate.Text = "Edit WC Location"
'        '
'        'pnlLocation
'        '
'        Me.pnlLocation.BackColor = System.Drawing.Color.LightSteelBlue
'        Me.pnlLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.pnlLocation.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.cboWCLoc})
'        Me.pnlLocation.Location = New System.Drawing.Point(584, 3)
'        Me.pnlLocation.Name = "pnlLocation"
'        Me.pnlLocation.Size = New System.Drawing.Size(191, 53)
'        Me.pnlLocation.TabIndex = 58
'        Me.pnlLocation.Visible = False
'        '
'        'Label2
'        '
'        Me.Label2.BackColor = System.Drawing.Color.Transparent
'        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
'        Me.Label2.Location = New System.Drawing.Point(6, 3)
'        Me.Label2.Name = "Label2"
'        Me.Label2.Size = New System.Drawing.Size(125, 16)
'        Me.Label2.TabIndex = 55
'        Me.Label2.Text = "Select Location:"
'        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'        '
'        'cboWCLoc
'        '
'        Me.cboWCLoc.AutoComplete = True
'        Me.cboWCLoc.BackColor = System.Drawing.SystemColors.Window
'        Me.cboWCLoc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.cboWCLoc.ForeColor = System.Drawing.Color.Black
'        Me.cboWCLoc.Location = New System.Drawing.Point(6, 22)
'        Me.cboWCLoc.Name = "cboWCLoc"
'        Me.cboWCLoc.Size = New System.Drawing.Size(175, 21)
'        Me.cboWCLoc.TabIndex = 3
'        '
'        'Panel3
'        '
'        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
'        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTray, Me.grdTrayInfo, Me.Label1})
'        Me.Panel3.Location = New System.Drawing.Point(5, 34)
'        Me.Panel3.Name = "Panel3"
'        Me.Panel3.Size = New System.Drawing.Size(531, 230)
'        Me.Panel3.TabIndex = 1
'        '
'        'Panel4
'        '
'        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
'        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdBillPro, Me.cmdCreateRpt, Me.btnUpdate, Me.pnlLocation, Me.panelBillPro, Me.Panel3, Me.lblWCName})
'        Me.Panel4.Location = New System.Drawing.Point(8, 8)
'        Me.Panel4.Name = "Panel4"
'        Me.Panel4.Size = New System.Drawing.Size(784, 272)
'        Me.Panel4.TabIndex = 60
'        '
'        'cmdBillPro
'        '
'        Me.cmdBillPro.BackColor = System.Drawing.Color.LightSteelBlue
'        Me.cmdBillPro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.cmdBillPro.Location = New System.Drawing.Point(543, 96)
'        Me.cmdBillPro.Name = "cmdBillPro"
'        Me.cmdBillPro.Size = New System.Drawing.Size(176, 24)
'        Me.cmdBillPro.TabIndex = 60
'        Me.cmdBillPro.Text = "End of Billing Production"
'        '
'        'cmdCreateRpt
'        '
'        Me.cmdCreateRpt.BackColor = System.Drawing.Color.LightSteelBlue
'        Me.cmdCreateRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.cmdCreateRpt.Location = New System.Drawing.Point(543, 64)
'        Me.cmdCreateRpt.Name = "cmdCreateRpt"
'        Me.cmdCreateRpt.Size = New System.Drawing.Size(177, 24)
'        Me.cmdCreateRpt.TabIndex = 59
'        Me.cmdCreateRpt.Text = "End of Line Production"
'        '
'        'panelBillPro
'        '
'        Me.panelBillPro.BackColor = System.Drawing.Color.LightSteelBlue
'        Me.panelBillPro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
'        Me.panelBillPro.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdCancel, Me.Label7, Me.cmdWCSumRpt, Me.dtpToDate, Me.dtpFromDate, Me.Label8})
'        Me.panelBillPro.Location = New System.Drawing.Point(542, 128)
'        Me.panelBillPro.Name = "panelBillPro"
'        Me.panelBillPro.Size = New System.Drawing.Size(233, 136)
'        Me.panelBillPro.TabIndex = 68
'        Me.panelBillPro.Visible = False
'        '
'        'cmdCancel
'        '
'        Me.cmdCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.cmdCancel.Location = New System.Drawing.Point(76, 102)
'        Me.cmdCancel.Name = "cmdCancel"
'        Me.cmdCancel.Size = New System.Drawing.Size(72, 24)
'        Me.cmdCancel.TabIndex = 67
'        Me.cmdCancel.Text = "Cancel"
'        '
'        'Label7
'        '
'        Me.Label7.BackColor = System.Drawing.Color.Transparent
'        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
'        Me.Label7.Location = New System.Drawing.Point(16, 44)
'        Me.Label7.Name = "Label7"
'        Me.Label7.Size = New System.Drawing.Size(88, 16)
'        Me.Label7.TabIndex = 65
'        Me.Label7.Text = "Bill Date to:"
'        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'cmdWCSumRpt
'        '
'        Me.cmdWCSumRpt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.cmdWCSumRpt.Location = New System.Drawing.Point(20, 71)
'        Me.cmdWCSumRpt.Name = "cmdWCSumRpt"
'        Me.cmdWCSumRpt.Size = New System.Drawing.Size(184, 24)
'        Me.cmdWCSumRpt.TabIndex = 66
'        Me.cmdWCSumRpt.Text = "Generate Report"
'        '
'        'dtpToDate
'        '
'        Me.dtpToDate.CustomFormat = "yyyy-MM-dd"
'        Me.dtpToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
'        Me.dtpToDate.Location = New System.Drawing.Point(108, 40)
'        Me.dtpToDate.Name = "dtpToDate"
'        Me.dtpToDate.Size = New System.Drawing.Size(104, 21)
'        Me.dtpToDate.TabIndex = 64
'        Me.dtpToDate.Value = New Date(2005, 2, 9, 0, 0, 0, 0)
'        '
'        'dtpFromDate
'        '
'        Me.dtpFromDate.CustomFormat = "yyyy-MM-dd"
'        Me.dtpFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
'        Me.dtpFromDate.Location = New System.Drawing.Point(108, 10)
'        Me.dtpFromDate.Name = "dtpFromDate"
'        Me.dtpFromDate.Size = New System.Drawing.Size(104, 21)
'        Me.dtpFromDate.TabIndex = 62
'        Me.dtpFromDate.Value = New Date(2005, 2, 9, 0, 0, 0, 0)
'        '
'        'Label8
'        '
'        Me.Label8.BackColor = System.Drawing.Color.Transparent
'        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
'        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
'        Me.Label8.Location = New System.Drawing.Point(-3, 12)
'        Me.Label8.Name = "Label8"
'        Me.Label8.Size = New System.Drawing.Size(112, 16)
'        Me.Label8.TabIndex = 63
'        Me.Label8.Text = "Bill Date From:"
'        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'        '
'        'frmWCTrayScan
'        '
'        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
'        Me.BackColor = System.Drawing.Color.SteelBlue
'        Me.ClientSize = New System.Drawing.Size(804, 405)
'        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel4})
'        Me.Name = "frmWCTrayScan"
'        Me.Text = "Scan the Tray"
'        CType(Me.grdTrayInfo, System.ComponentModel.ISupportInitialize).EndInit()
'        Me.pnlLocation.ResumeLayout(False)
'        Me.Panel3.ResumeLayout(False)
'        Me.Panel4.ResumeLayout(False)
'        Me.panelBillPro.ResumeLayout(False)
'        Me.ResumeLayout(False)

'    End Sub

'#End Region
'    '*****************************************************************
'    Private Sub frmWCTrayScan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Try
'            SetupWCFile()
'            FillWCLocations()
'            FillWCLocGrid()
'        Catch ex As Exception
'            MsgBox("frmWCTrayScan_Load:: " & ex.Message.ToString)
'        End Try
'    End Sub

'    Private Sub SetupWCFile()
'        iWCLocation_ID = CInt(objMisc.SetupWCFile())
'    End Sub
'    '*****************************************************************
'    Private Sub FillWCLocGrid()
'        Dim dtWCLocGrid As New DataTable()
'        Dim i, j As Integer
'        Try
'            dtWCLocGrid = objMisc.GetTrayLineInfo(iWCLocation_ID)

'            Me.grdTrayInfo.ClearFields()
'            Me.grdTrayInfo.DataSource = dtWCLocGrid.DefaultView

'            'For i = 0 To Me.grdTrayInfo.Splits(0).DisplayColumns.Count - 1
'            '    Me.grdTrayInfo.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
'            'Next i

'            SetGrdProdProperties()

'        Catch ex As Exception
'            MsgBox("frmWCTrayScan.FillWCLocGrid: " & ex.Message.ToString, MsgBoxStyle.Critical)
'        Finally
'            objMisc.DisposeDT(dtWCLocGrid)
'        End Try
'    End Sub
'    Private Sub SetGrdProdProperties()
'        Dim iNumOfColumns As Integer = Me.grdTrayInfo.Columns.Count
'        Dim i As Integer

'        With Me.grdTrayInfo
'            'Heading style (Horizontal Alignment to Center)
'            For i = 0 To (iNumOfColumns - 1)
'                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
'            Next

'            'Set individual column data horizontal alignment
'            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
'            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
'            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


'            'Set Column Widths
'            .Splits(0).DisplayColumns(1).Width = 100
'            .Splits(0).DisplayColumns(1).Width = 200
'            .Splits(0).DisplayColumns(2).Width = 100

'        End With

'    End Sub
'    '*****************************************************************
'    Private Sub FillWCLocations()
'        Dim dtWCLoc As New DataTable()
'        Try
'            dtWCLoc = objMisc.GetWCLocations
'            With Me.cboWCLoc
'                .DataSource = dtWCLoc.DefaultView
'                .DisplayMember = dtWCLoc.Columns("WC_Location").ToString
'                .ValueMember = dtWCLoc.Columns("WCLocation_ID").ToString
'                .SelectedValue = iWCLocation_ID
'            End With

'            Me.lblWCName.Text = Me.cboWCLoc.Text

'        Catch ex As Exception
'            MsgBox("Error in frmWCTrayScan.LoadDBRCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
'        Finally
'            objMisc.DisposeDT(dtWCLoc)
'        End Try
'    End Sub
'    '*****************************************************************
'    Protected Overrides Sub Finalize()
'        objMisc = Nothing
'        MyBase.Finalize()
'    End Sub
'    '*****************************************************************
'    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
'        Dim i As Integer = 0

'        If Not pnlLocation.Visible Then
'            pnlLocation.Visible = True
'            btnUpdate.Text = "Update WC Location"
'        Else
'            ''**********************
'            ''Update the File
'            ''**********************
'            iWCLocation_ID = Me.cboWCLoc.SelectedValue
'            i = objMisc.UpdateWCInfo(iWCLocation_ID)
'            FillWCLocGrid()
'            ''**********************
'            pnlLocation.Visible = False
'            btnUpdate.Text = "Edit WC Location"
'            Me.lblWCName.Text = Me.cboWCLoc.Text
'        End If
'    End Sub
'    '****************************************************************
'    Private Sub txtTray_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTray.KeyUp
'        Dim i As Integer = 0


'        Try
'            'Cursor.Current = Cursors.WaitCursor
'            'str += Trim(Me.txtTray.Text)
'            If e.KeyValue = 13 Then
'                If iWCLocation_ID = 0 Then
'                    MsgBox("Please edit the WC Location and then try to scan the trays in.", MsgBoxStyle.Information)
'                    Exit Sub
'                Else
'                    If Trim(txtTray.Text) <> "" Then
'                        If IsNumeric(Trim(txtTray.Text)) Then
'                            'If iWCLocation_ID = 16 Then    'if the location is 'Line 2 Shift 1' then
'                            '***************************************
'                            'Determine the Cust_ID of the device scanned in
'                            'i = objMisc.GetCustIDByTrayID(Trim(txtTray.Text))

'                            'Select Case i
'                            '    Case 16     'SBC
'                            '        i = objMisc.InputTray(Trim(Me.txtTray.Text), 43)    'WCLocation_ID for 'Line 2 Shift 1 (SBC)' is 43
'                            '    Case Else   'Others
'                            '        i = objMisc.InputTray(Trim(Me.txtTray.Text), iWCLocation_ID)
'                            'End Select
'                            '***************************************
'                            'Else
'                            '    i = objMisc.InputTray(Trim(Me.txtTray.Text), iWCLocation_ID)
'                            'End If


'                            i = objMisc.InputTray(Trim(Me.txtTray.Text), iWCLocation_ID)
'                        Else
'                            'MsgBox("Please enter a numeric value for Tray ID.", MsgBoxStyle.Information)
'                            MessageBox.Show("Please enter a numeric value for Tray ID.", "End of Line Tray Scan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
'                            Me.txtTray.Text = ""
'                            Me.txtTray.Focus()
'                        End If
'                    End If

'                    FillWCLocGrid()
'                    Me.txtTray.Text = ""
'                    Me.txtTray.Focus()
'                End If
'            End If

'        Catch ex As Exception
'            MessageBox.Show(ex.Message, "End of Line Tray Scan", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
'            Me.txtTray.Text = ""
'            Me.txtTray.Focus()
'        End Try
'    End Sub
'    '****************************************************************
'    Private Sub cmdCreateRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCreateRpt.Click
'        Dim frmReport As RptViewer
'        Try
'            frmReport = New RptViewer("End_of_Line.rpt")
'            frmReport.Show()
'        Catch ex As Exception
'            MsgBox(ex.Message, MsgBoxStyle.Critical)
'        Finally
'            frmReport = Nothing
'        End Try
'    End Sub
'    '*****************************************************************
'    Private Sub cmdWCDetailRpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdWCSumRpt.Click
'        Dim i As Integer = 0
'        Cursor.Current = Cursors.WaitCursor
'        'empty data Validation
'        If Me.dtpFromDate.Text = "" Or Me.dtpToDate.Text = "" Then
'            MsgBox("Please select 'Bill Date From' and 'Bill Date to'.", MsgBoxStyle.Information, "WC Detail Report")
'            Exit Sub
'        End If

'        If Me.dtpToDate.Value < Me.dtpFromDate.Value Then
'            MsgBox("'Bill Date to' can't be before 'Bill Date From'.", MsgBoxStyle.Information, "WC Detail Report")
'            Exit Sub
'        End If

'        Try
'            ' GenerateWCDetailReport
'            i = objMisc.GenerateWCDetailReport(Me.dtpFromDate.Text, Me.dtpToDate.Text, 999, , , )
'            If i <> 1 Then
'                Throw New Exception("Check the report for errors (i = 0).")
'            End If
'        Catch ex As Exception
'            MsgBox("frmExcel.cmdWCDetailRpt_Click:: " & ex.Message)
'        Finally
'            Cursor.Current = Cursors.Default
'            Me.panelBillPro.Visible = False
'        End Try
'    End Sub

'    Private Sub cmdBillPro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBillPro.Click
'        If Me.panelBillPro.Visible = False Then
'            Me.dtpFromDate.Text = Now()
'            Me.dtpToDate.Text = Now()
'            Me.panelBillPro.Visible = True
'        End If
'    End Sub

'    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
'        Me.panelBillPro.Visible = False
'    End Sub

'    Private Sub frmWCTrayScan_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
'        Me.txtTray.Focus()
'    End Sub

'    Private Sub frmWCTrayScan_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Enter
'        Me.txtTray.Focus()
'    End Sub

'    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        Asif()
'    End Sub
'    Private Sub Asif()
'        With Me.grdTrayInfo
'            MsgBox(.Splits(0).DisplayColumns(0).Width & Environment.NewLine & _
'            .Splits(0).DisplayColumns(1).Width & Environment.NewLine & _
'            .Splits(0).DisplayColumns(2).Width & Environment.NewLine)
'        End With

'    End Sub
'End Class
