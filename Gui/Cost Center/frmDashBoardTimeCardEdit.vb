
Option Explicit On 

Imports PSS.Data.Production

Public Class frmDashBoardTimeCardEdit
    Inherits System.Windows.Forms.Form

    Private _objCCTT As CostCenterTimeTracking
    Private _iEENum As Integer = 0
    Private _strSelectedDate As String = ""
    Private _booAllowUpdate As Boolean = False
    Private _booUpdate As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal iEEnumber As Integer, _
                   ByVal strEEName As String, _
                   ByVal strSelectedDate As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        _iEENum = iEEnumber
        _strSelectedDate = strSelectedDate
        Me.lblEENum.Text = iEEnumber
        Me.lblEEName.Text = strEEName
        Me.lblPayPeriod.Text = DateAdd(DateInterval.Day, (Weekday(CDate(_strSelectedDate), FirstDayOfWeek.Monday) * -1) + 1, CDate(_strSelectedDate))
        Me.lblPayPeriod.Text &= " To "
        Me.lblPayPeriod.Text &= DateAdd(DateInterval.Day, 6 - Weekday(CDate(_strSelectedDate), FirstDayOfWeek.Monday), CDate(_strSelectedDate))

        _objCCTT = New CostCenterTimeTracking()

        Try
            Me._booAllowUpdate = Not (Me._objCCTT.IsStatProdIncDataAvail(DateAdd(DateInterval.Day, (Weekday(CDate(_strSelectedDate), FirstDayOfWeek.Monday) * -1) + 1, CDate(_strSelectedDate))))
        Catch ex As Exception
            MessageBox.Show(ex.Message, "TimeCardEdit_LoadEvent", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me._objCCTT = Nothing
            Me.Close()
        End Try
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If

            _objCCTT = Nothing
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblEEName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblPayPeriod As System.Windows.Forms.Label
    Friend WithEvents lblEENum As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dbgDay1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents dbgLegiant As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents btnAddRec As System.Windows.Forms.Button
    Friend WithEvents btnUpdateSelectedRecord As System.Windows.Forms.Button
    Friend WithEvents pnlNewDateTime As System.Windows.Forms.Panel
    Friend WithEvents dtpOutDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpInDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblInTime As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents cboGroups As System.Windows.Forms.ComboBox
    Friend WithEvents cboCostCenter As System.Windows.Forms.ComboBox
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnDeletedSelItem As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDashBoardTimeCardEdit))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnUpdateSelectedRecord = New System.Windows.Forms.Button()
        Me.lblPayPeriod = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblEENum = New System.Windows.Forms.Label()
        Me.lblEEName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAddRec = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dbgDay1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.dbgLegiant = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlNewDateTime = New System.Windows.Forms.Panel()
        Me.cboGroups = New System.Windows.Forms.ComboBox()
        Me.cboCostCenter = New System.Windows.Forms.ComboBox()
        Me.lblCostCenter = New System.Windows.Forms.Label()
        Me.lblGroup = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblInTime = New System.Windows.Forms.Label()
        Me.dtpOutDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpInDate = New System.Windows.Forms.DateTimePicker()
        Me.btnDeletedSelItem = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dbgDay1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dbgLegiant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNewDateTime.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeletedSelItem, Me.btnUpdateSelectedRecord, Me.lblPayPeriod, Me.Label3, Me.Label2, Me.lblEENum, Me.lblEEName, Me.Label5, Me.btnAddRec, Me.btnClose})
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(376, 135)
        Me.Panel1.TabIndex = 9
        '
        'btnUpdateSelectedRecord
        '
        Me.btnUpdateSelectedRecord.BackColor = System.Drawing.Color.Green
        Me.btnUpdateSelectedRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateSelectedRecord.ForeColor = System.Drawing.Color.White
        Me.btnUpdateSelectedRecord.Location = New System.Drawing.Point(296, 104)
        Me.btnUpdateSelectedRecord.Name = "btnUpdateSelectedRecord"
        Me.btnUpdateSelectedRecord.Size = New System.Drawing.Size(64, 24)
        Me.btnUpdateSelectedRecord.TabIndex = 23
        Me.btnUpdateSelectedRecord.Text = "Update"
        '
        'lblPayPeriod
        '
        Me.lblPayPeriod.BackColor = System.Drawing.Color.White
        Me.lblPayPeriod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPayPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayPeriod.Location = New System.Drawing.Point(136, 8)
        Me.lblPayPeriod.Name = "lblPayPeriod"
        Me.lblPayPeriod.Size = New System.Drawing.Size(168, 18)
        Me.lblPayPeriod.TabIndex = 10
        Me.lblPayPeriod.Text = "10/20/08 To 10/26/08"
        Me.lblPayPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(8, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(128, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Selected Date Period :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(32, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Employee Name :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEENum
        '
        Me.lblEENum.BackColor = System.Drawing.Color.White
        Me.lblEENum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEENum.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEENum.Location = New System.Drawing.Point(136, 72)
        Me.lblEENum.Name = "lblEENum"
        Me.lblEENum.Size = New System.Drawing.Size(168, 18)
        Me.lblEENum.TabIndex = 12
        Me.lblEENum.Text = "3301"
        Me.lblEENum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEEName
        '
        Me.lblEEName.BackColor = System.Drawing.Color.White
        Me.lblEEName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEEName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEEName.Location = New System.Drawing.Point(136, 40)
        Me.lblEEName.Name = "lblEEName"
        Me.lblEEName.Size = New System.Drawing.Size(168, 18)
        Me.lblEEName.TabIndex = 7
        Me.lblEEName.Text = "Nguyen, Lan Hong"
        Me.lblEEName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(32, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Employee # :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAddRec
        '
        Me.btnAddRec.BackColor = System.Drawing.Color.Green
        Me.btnAddRec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddRec.ForeColor = System.Drawing.Color.White
        Me.btnAddRec.Location = New System.Drawing.Point(192, 104)
        Me.btnAddRec.Name = "btnAddRec"
        Me.btnAddRec.Size = New System.Drawing.Size(72, 24)
        Me.btnAddRec.TabIndex = 22
        Me.btnAddRec.Text = "Add "
        '
        'btnClose
        '
        Me.btnClose.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnClose.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(322, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(48, 24)
        Me.btnClose.TabIndex = 24
        Me.btnClose.Text = "Close"
        '
        'dbgDay1
        '
        Me.dbgDay1.AllowColMove = False
        Me.dbgDay1.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgDay1.CaptionHeight = 20
        Me.dbgDay1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgDay1.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgDay1.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.dbgDay1.Location = New System.Drawing.Point(0, 136)
        Me.dbgDay1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.dbgDay1.Name = "dbgDay1"
        Me.dbgDay1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgDay1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgDay1.PreviewInfo.ZoomFactor = 75
        Me.dbgDay1.RowHeight = 25
        Me.dbgDay1.Size = New System.Drawing.Size(376, 224)
        Me.dbgDay1.TabIndex = 13
        Me.dbgDay1.Text = "C1TrueDBGrid1"
        Me.dbgDay1.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:LightSteelBlue;" & _
        "}Selected{ForeColor:HighlightText;BackColor:Teal;}Style3{}Inactive{ForeColor:Ina" & _
        "ctiveCaptionText;BackColor:InactiveCaption;}FilterBar{ForeColor:Red;}Footer{}Cap" & _
        "tion{AlignHorz:Center;BackColor:Black;}Style9{}Normal{Font:Microsoft Sans Serif," & _
        " 8.25pt, style=Bold;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}S" & _
        "tyle14{}OddRow{BackColor:LightSteelBlue;}RecordSelector{AlignImage:Center;}Style" & _
        "15{}Heading{Wrap:True;AlignHorz:Center;AlignVert:Center;Border:Raised,,1, 1, 1, " & _
        "1;ForeColor:Black;BackColor:LightSteelBlue;}Style8{}Style10{AlignHorz:Near;}Styl" & _
        "e11{}Style12{}Style13{}Style1{}</Data></Styles><Splits><C1.Win.C1TrueDBGrid.Merg" & _
        "eView AllowColMove=""False"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=""17"" C" & _
        "olumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" " & _
        "DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>22" & _
        "0</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Edit" & _
        "or"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle p" & _
        "arent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><Gro" & _
        "upStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2""" & _
        " /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=" & _
        """Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelec" & _
        "torStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected""" & _
        " me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 372, 220</" & _
        "ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C" & _
        "1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Styl" & _
        "e parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style pa" & _
        "rent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style par" & _
        "ent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=" & _
        """Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent" & _
        "=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style par" & _
        "ent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles" & _
        "><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><Defau" & _
        "ltRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 372, 220</ClientArea><Pri" & _
        "ntPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""S" & _
        "tyle15"" /></Blob>"
        '
        'dbgLegiant
        '
        Me.dbgLegiant.AllowColMove = False
        Me.dbgLegiant.AllowUpdate = False
        Me.dbgLegiant.BackColor = System.Drawing.Color.SteelBlue
        Me.dbgLegiant.Caption = "Legiant Data"
        Me.dbgLegiant.CaptionHeight = 20
        Me.dbgLegiant.Cursor = System.Windows.Forms.Cursors.Default
        Me.dbgLegiant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dbgLegiant.GroupByCaption = "Drag a column header here to group by that column"
        Me.dbgLegiant.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
        Me.dbgLegiant.Location = New System.Drawing.Point(376, 0)
        Me.dbgLegiant.Name = "dbgLegiant"
        Me.dbgLegiant.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.dbgLegiant.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.dbgLegiant.PreviewInfo.ZoomFactor = 75
        Me.dbgLegiant.RowHeight = 25
        Me.dbgLegiant.Size = New System.Drawing.Size(336, 136)
        Me.dbgLegiant.TabIndex = 21
        Me.dbgLegiant.Text = "C1TrueDBGrid1"
        Me.dbgLegiant.Visible = False
        Me.dbgLegiant.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{Font:Microsoft Sans Serif" & _
        ", 8.25pt, style=Bold;BackColor:LightSteelBlue;}Selected{ForeColor:HighlightText;" & _
        "BackColor:Teal;}Style3{}Inactive{ForeColor:InactiveCaptionText;BackColor:Inactiv" & _
        "eCaption;}FilterBar{ForeColor:Red;}Footer{}Caption{AlignHorz:Center;ForeColor:Wh" & _
        "ite;BackColor:Gray;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold" & _
        ";}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddRow{Back" & _
        "Color:LightSteelBlue;}RecordSelector{AlignImage:Center;BackColor:LightSteelBlue;" & _
        "}Style13{}Heading{Wrap:True;AlignHorz:Center;BackColor:LightSteelBlue;Border:Rai" & _
        "sed,,1, 1, 1, 1;ForeColor:Black;AlignVert:Center;}Style8{}Style10{AlignHorz:Near" & _
        ";}Style11{}Style14{}Style15{}Style9{}</Data></Styles><Splits><C1.Win.C1TrueDBGri" & _
        "d.MergeView AllowColMove=""False"" Name="""" CaptionHeight=""17"" ColumnCaptionHeight=" & _
        """17"" ColumnFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth" & _
        "=""16"" DefRecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Hei" & _
        "ght>112</Height><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent" & _
        "=""Editor"" me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarS" & _
        "tyle parent=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" " & _
        "/><GroupStyle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""S" & _
        "tyle2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle p" & _
        "arent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><Recor" & _
        "dSelectorStyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Sel" & _
        "ected"" me=""Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 20, 332" & _
        ", 112</ClientRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C" & _
        "1.Win.C1TrueDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" " & _
        "/><Style parent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><S" & _
        "tyle parent=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><St" & _
        "yle parent=""Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style " & _
        "parent=""Normal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style" & _
        " parent=""Normal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><St" & _
        "yle parent=""Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></Name" & _
        "dStyles><vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout" & _
        "><DefaultRecSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 332, 132</ClientAr" & _
        "ea><PrintPageHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent=""" & _
        """ me=""Style15"" /></Blob>"
        '
        'pnlNewDateTime
        '
        Me.pnlNewDateTime.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlNewDateTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlNewDateTime.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboGroups, Me.cboCostCenter, Me.lblCostCenter, Me.lblGroup, Me.btnCancel, Me.btnSave, Me.Label1, Me.lblInTime, Me.dtpOutDate, Me.dtpInDate})
        Me.pnlNewDateTime.Location = New System.Drawing.Point(376, 136)
        Me.pnlNewDateTime.Name = "pnlNewDateTime"
        Me.pnlNewDateTime.Size = New System.Drawing.Size(336, 224)
        Me.pnlNewDateTime.TabIndex = 22
        Me.pnlNewDateTime.Visible = False
        '
        'cboGroups
        '
        Me.cboGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGroups.Location = New System.Drawing.Point(96, 8)
        Me.cboGroups.Name = "cboGroups"
        Me.cboGroups.Size = New System.Drawing.Size(224, 24)
        Me.cboGroups.TabIndex = 22
        '
        'cboCostCenter
        '
        Me.cboCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCostCenter.Location = New System.Drawing.Point(96, 40)
        Me.cboCostCenter.Name = "cboCostCenter"
        Me.cboCostCenter.Size = New System.Drawing.Size(224, 24)
        Me.cboCostCenter.TabIndex = 23
        '
        'lblCostCenter
        '
        Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostCenter.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblCostCenter.Location = New System.Drawing.Point(8, 42)
        Me.lblCostCenter.Name = "lblCostCenter"
        Me.lblCostCenter.Size = New System.Drawing.Size(88, 16)
        Me.lblCostCenter.TabIndex = 24
        Me.lblCostCenter.Text = "Cost Center:"
        Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblGroup
        '
        Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroup.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblGroup.Location = New System.Drawing.Point(8, 10)
        Me.lblGroup.Name = "lblGroup"
        Me.lblGroup.Size = New System.Drawing.Size(88, 16)
        Me.lblGroup.TabIndex = 25
        Me.lblGroup.Text = "Group:"
        Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(248, 168)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(72, 24)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "CANCEL"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(96, 168)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "SAVE"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(8, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Out Time:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblInTime
        '
        Me.lblInTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInTime.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblInTime.Location = New System.Drawing.Point(8, 79)
        Me.lblInTime.Name = "lblInTime"
        Me.lblInTime.Size = New System.Drawing.Size(88, 16)
        Me.lblInTime.TabIndex = 16
        Me.lblInTime.Text = "In Time:"
        Me.lblInTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpOutDate
        '
        Me.dtpOutDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpOutDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOutDate.Location = New System.Drawing.Point(96, 112)
        Me.dtpOutDate.Name = "dtpOutDate"
        Me.dtpOutDate.Size = New System.Drawing.Size(224, 22)
        Me.dtpOutDate.TabIndex = 12
        Me.dtpOutDate.Value = New Date(2008, 10, 22, 12, 11, 0, 0)
        '
        'dtpInDate
        '
        Me.dtpInDate.CustomFormat = "MM/dd/yyyy hh:mm tt"
        Me.dtpInDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpInDate.Location = New System.Drawing.Point(96, 72)
        Me.dtpInDate.Name = "dtpInDate"
        Me.dtpInDate.Size = New System.Drawing.Size(224, 22)
        Me.dtpInDate.TabIndex = 11
        '
        'btnDeletedSelItem
        '
        Me.btnDeletedSelItem.BackColor = System.Drawing.Color.Green
        Me.btnDeletedSelItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeletedSelItem.ForeColor = System.Drawing.Color.White
        Me.btnDeletedSelItem.Location = New System.Drawing.Point(8, 104)
        Me.btnDeletedSelItem.Name = "btnDeletedSelItem"
        Me.btnDeletedSelItem.Size = New System.Drawing.Size(152, 24)
        Me.btnDeletedSelItem.TabIndex = 25
        Me.btnDeletedSelItem.Text = "Delete Selected Record"
        '
        'frmDashBoardTimeCardEdit
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(710, 363)
        Me.ControlBox = False
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlNewDateTime, Me.dbgLegiant, Me.Panel1, Me.dbgDay1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmDashBoardTimeCardEdit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cost Center Time Card"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dbgDay1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dbgLegiant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNewDateTime.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    '**************************************************************************
    Private Sub frmDashBoardTimeCardEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.LoadGroups()
            PopulateProdTimeCard(Me.dbgDay1)
            PopulateLegiantTimeCard()

            Me.dtpInDate.Value = Now
            Me.dtpOutDate.Value = Now

            If Me._booAllowUpdate = True Then
                Me.btnAddRec.Visible = True
                Me.btnUpdateSelectedRecord.Visible = True
                Me.btnDeletedSelItem.Visible = True
            Else
                Me.btnAddRec.Visible = False
                Me.btnUpdateSelectedRecord.Visible = False
                Me.btnDeletedSelItem.Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Form Load", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '**************************************************************************
    Private Sub PopulateLegiantTimeCard()
        Dim dt As DataTable
        Dim i As Integer
        Dim objLegiant As PSS.Data.Buisness.Legiant

        Try
            objLegiant = New PSS.Data.Buisness.Legiant()

            dt = objLegiant.GetLegiantLoginTime(Me._iEENum.ToString, _strSelectedDate)
            With Me.dbgLegiant
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .Visible = True

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                    .Splits(0).DisplayColumns(i).Locked = True
                Next i

                ''Hide the ID columns
                '.Splits(0).DisplayColumns("punch_id").Visible = False
                '.Splits(0).DisplayColumns("Group").Visible = False
                '.Splits(0).DisplayColumns("InTime").Visible = False
                '.Splits(0).DisplayColumns("OutTime").Visible = False
                .Splits(0).DisplayColumns("EE#").Width = 40
                .Splits(0).DisplayColumns("In").Width = 120
                .Splits(0).DisplayColumns("Out").Width = 120
                .Columns("In").NumberFormat = "MM/dd/yyyy hh:mm tt"
                .Columns("Out").NumberFormat = "MM/dd/yyyy hh:mm tt"

                '.Splits(0).DisplayColumns("Line").Locked = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "PopulateTimeCard", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
            objLegiant = Nothing
        End Try
    End Sub

    '**************************************************************************
    Private Sub LoadGroups()
        Dim objInventory As PSS.Data.Buisness.Inventory
        Dim dt As DataTable

        Try
            objInventory = New PSS.Data.Buisness.Inventory()
            dt = objInventory.GetGroups(1, , 1)

            With Me.cboGroups
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("Group").ToString
                .ValueMember = dt.Columns("Group_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            objInventory = Nothing
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '**************************************************************************
    Private Sub cboGroups_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboGroups.SelectionChangeCommitted

        Try
            If Not IsNothing(Me.cboCostCenter.DataSource) Then
                Me.cboCostCenter.DataSource = Nothing
                Me.cboCostCenter.Items.Clear()
                Me.cboCostCenter.Text = ""
            End If

            If Me.cboGroups.SelectedValue > 0 Then
                LoadCostCenter()
                Me.cboCostCenter.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "cboGroups_SelectionChangeCommitted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '**************************************************************************
    Private Sub LoadCostCenter()
        Dim dt As DataTable

        Try
            dt = Me._objCCTT.GetCCIDDesc(Me.cboGroups.SelectedValue, 1)

            With Me.cboCostCenter
                .DataSource = dt.DefaultView
                .DisplayMember = dt.Columns("cc_desc").ToString
                .ValueMember = dt.Columns("cc_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw ex
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '**************************************************************************
    Private Sub PopulateProdTimeCard(ByRef dbgTimeCard As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim dt As DataTable
        Dim i As Integer

        Try
            dt = Me._objCCTT.GetDasBoardTime(_strSelectedDate, Me._iEENum)
            With dbgTimeCard
                .DataSource = Nothing
                .DataSource = dt.DefaultView
                .Visible = True

                .Caption = Format(CDate(_strSelectedDate), "MM/dd/yyyy")

                For i = 0 To .Columns.Count - 1
                    .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                    .Splits(0).DisplayColumns(i).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
                    .Splits(0).DisplayColumns(i).Style.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Center

                    'If Me._booAllowUpdate = False Then
                    .Splits(0).DisplayColumns(i).Locked = True
                    'End If
                Next i

                'Hide the ID columns
                .Splits(0).DisplayColumns("punch_id").Visible = False
                .Splits(0).DisplayColumns("Group").Visible = False
                .Splits(0).DisplayColumns("InTime").Visible = False
                .Splits(0).DisplayColumns("OutTime").Visible = False
                .Splits(0).DisplayColumns("Line").Width = 50
                .Splits(0).DisplayColumns("In").Width = 130
                .Splits(0).DisplayColumns("Out").Width = 130

                .Splits(0).DisplayColumns("Line").Locked = True

                .Columns("InTime").NumberFormat = "yyyy-MM-dd HH:mm:ss"
                .Columns("OutTime").NumberFormat = "yyyy-MM-dd HH:mm:ss"
                .Columns("In").NumberFormat = "MM/dd/yyyy hh:mm tt"
                .Columns("Out").NumberFormat = "MM/dd/yyyy hh:mm tt"
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "PopulateTimeCard", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            PSS.Data.Buisness.Generic.DisposeDT(dt)
        End Try
    End Sub

    '**************************************************************************
    Private Sub dbgDay1_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles dbgDay1.RowColChange
        sender.Caption = Format(CDate(_strSelectedDate), "MM/dd/yyyy") & " -- " & sender.Columns("Group").Text.trim

        'Dim dtePunchDateTime As DateTime
        If Me._booUpdate = True Then
            If Me.dbgDay1.Columns("Punch_ID").Value.ToString.Trim.Length = 0 Then
                MessageBox.Show("Please select record to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.dtpInDate.Value = sender.Columns("In").Text
            Me.dtpOutDate.Value = Me.dtpInDate.Value
            If Not IsDBNull(sender.Columns("Out").Text.trim) Then
                Me.dtpOutDate.Value = sender.Columns("Out").Text
            End If
        End If
    End Sub

    '**************************************************************************
    'Private Sub dbgDay1_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles dbgDay1.BeforeColUpdate
    '    Dim strOldVal As String
    '    Dim strNewVal As String
    '    Dim strTemp As String
    '    Dim i As Integer = 0
    '    Dim dteNewValUpdate As DateTime = Nothing
    '    Dim strUpdateType As String = ""

    '    Try
    '        'MsgBox(sender.Columns(sender.col).Text.trim())

    '        If IsDBNull(e.OldValue) Then
    '            strOldVal = ""
    '        End If
    '        strOldVal = e.OldValue.ToString.Trim
    '        strNewVal = sender.Columns(sender.col).Text.trim()
    '        strOldVal = strOldVal.Replace(" ", "")
    '        strOldVal = strOldVal.Replace(":", "")
    '        strNewVal = strNewVal.Replace(" ", "")
    '        strNewVal = strNewVal.Replace(":", "")

    '        If strOldVal.Trim.ToUpper = strNewVal.Trim.ToUpper Then
    '            Exit Sub
    '        ElseIf strNewVal.Trim.Length <> 6 Then
    '            sender.Columns(sender.col).Text = e.OldValue
    '            MessageBox.Show("Invalid format (" & sender.Columns(sender.col).Text.trim() & "), must have format as ""hh:ss AM""", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        ElseIf strNewVal.ToUpper.EndsWith("PM") = False And strNewVal.ToUpper.EndsWith("AM") = False Then
    '            sender.Columns(sender.col).Text = e.OldValue
    '            MessageBox.Show("Invalid format (" & sender.Columns(sender.col).Text.trim() & "), must end with PM or AM", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '        Else
    '            strTemp = strNewVal.Substring(0, 4)
    '            For i = 0 To strTemp.Length - 1
    '                If Char.IsDigit(strTemp.Chars(i)) = False Then
    '                    sender.Columns(sender.col).Text = e.OldValue
    '                    MessageBox.Show("Invalid format (" & sender.Columns(sender.col).Text.trim() & "), must have format as ""hh:ss AM""", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                    Exit Sub
    '                End If
    '            Next i

    '            If strNewVal.ToUpper.EndsWith("PM") Then strNewVal = (CInt(strNewVal.Substring(0, 2)) + 12).ToString & strNewVal.Substring(2)
    '            strNewVal = strNewVal.Substring(0, strNewVal.Length - 2)

    '            strNewVal = strNewVal.Insert(2, ":")
    '            strNewVal = " " & strNewVal & ":00"

    '            If sender.Columns(sender.col).caption = "In" Then
    '                If strOldVal.Trim = "" Then
    '                    dteNewValUpdate = CDate(Me._strSelectedDate & strNewVal)
    '                Else
    '                    dteNewValUpdate = CDate(sender.Columns("InTime").Text.trim().ToString.Substring(0, 10) & strNewVal)
    '                End If

    '                If dteNewValUpdate < CDate(sender.Columns("InTime").Text.trim()) Then
    '                    sender.Columns(sender.col).Text = e.OldValue
    '                    MessageBox.Show("In time can not after out time.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                    Exit Sub
    '                End If

    '                strUpdateType = "InTime"
    '            Else
    '                If strOldVal.Trim = "" Then
    '                    dteNewValUpdate = CDate(Me._strSelectedDate & strNewVal)
    '                Else
    '                    dteNewValUpdate = CDate(sender.Columns("OutTime").Text.trim().ToString.Substring(0, 10) & strNewVal)
    '                End If

    '                If dteNewValUpdate > CDate(sender.Columns("OutTime").Text.trim()) Then
    '                    sender.Columns(sender.col).Text = e.OldValue
    '                    MessageBox.Show("Out time can not before in time.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '                    Exit Sub
    '                End If

    '                strUpdateType = "OutTime"
    '            End If

    '            i = Me._objCCTT.UpdateLogInOutTime(CInt(sender.Columns("Punch_ID").Text.trim), sender.Columns("Punch_ID").Text.trim, Format(dteNewValUpdate, "yyyy-MM-dd hh:mm:ss"), strUpdateType, PSS.Core.Global.ApplicationUser.IDuser, PSS.Core.Global.ApplicationUser.User)

    '            If i > 0 Then
    '                MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "PopulateTimeCard", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    '**************************************************************************
    Private Sub btnAddRec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRec.Click
        Try
            Me.lblGroup.Visible = True
            Me.cboGroups.Visible = True
            Me.lblCostCenter.Visible = True
            Me.cboCostCenter.Visible = True

            Me.pnlNewDateTime.Visible = True
            'Me.dbgDay1.Location = New System.Drawing.Point(0, 312)

            Me._booUpdate = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnAddRec_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '**************************************************************************
    Private Sub btnUpdateSelectedRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateSelectedRecord.Click
        Try
            Me.lblGroup.Visible = False
            Me.cboGroups.Visible = False
            Me.lblCostCenter.Visible = False
            Me.cboCostCenter.Visible = False

            Me.pnlNewDateTime.Visible = True
            'Me.dbgDay1.Location = New System.Drawing.Point(0, 312)

            If Me.dbgDay1.SelectedRows.Count = 0 OrElse Me.dbgDay1.Columns("Punch_ID").Value.ToString.Trim.Length = 0 Then
                MessageBox.Show("Please select record to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            Me.dtpInDate.Value = Me.dbgDay1.Columns("InTime").Value
            Me.dtpOutDate.Value = Me.dtpInDate.Value
            If Not IsDBNull(Me.dbgDay1.Columns("OutTime").Value) Then Me.dtpOutDate.Value = Me.dbgDay1.Columns("OutTime").Value
            Me._booUpdate = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnUpdateSelectedRecord_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '**************************************************************************
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me._booUpdate = False
        Me.pnlNewDateTime.Visible = False
        'Me.dbgDay1.Location = New System.Drawing.Point(0, 134)
    End Sub

    '**************************************************************************
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim i As Integer = 0
        Dim iPunchID As Integer = 0
        Dim iCCID As Integer = 0
        Dim strOldInTime As String = ""
        Dim strOldOutTime As String = ""
        Dim strNewInTime As String = ""
        Dim strNewOutTime As String = ""

        Try
            If Not IsNothing(Me.cboCostCenter) = True Then
                iCCID = Me.cboCostCenter.SelectedValue
            End If

            If Me._booUpdate = True Then

                If Me.dbgDay1.Columns("Punch_ID").Value.ToString.Trim.Length = 0 Then
                    MessageBox.Show("Please select record to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                iPunchID = CInt(Me.dbgDay1.Columns("Punch_ID").Value.ToString.Trim)
                If Not IsDBNull(Me.dbgDay1.Columns("InTime").Value) Then
                    strOldInTime = Me.dbgDay1.Columns("InTime").Value
                End If
                If Not IsDBNull(Me.dbgDay1.Columns("OutTime").Value) Then
                    strOldOutTime = Me.dbgDay1.Columns("InTime").Value
                End If
            End If

            If Me.dtpInDate.Value > Me.dtpOutDate.Value Then
                MessageBox.Show("In time can't after out time.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf iPunchID = 0 AndAlso iCCID = 0 Then
                MessageBox.Show("Please select cost center.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                strNewInTime = Format(Me.dtpInDate.Value, "yyyy-MM-dd HH:mm:ss")
                strNewOutTime = Format(Me.dtpOutDate.Value, "yyyy-MM-dd HH:mm:ss")

                i = Me._objCCTT.UpdateLogInOutTime(iPunchID, strOldInTime, strOldOutTime, strNewInTime, strNewOutTime, iCCID, Me._iEENum, PSS.Core.[Global].ApplicationUser.IDuser, PSS.Core.[Global].ApplicationUser.User)

                If i > 0 Then
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PopulateProdTimeCard(Me.dbgDay1)

                    Me.pnlNewDateTime.Visible = False
                    'Me.dbgDay1.Location = New System.Drawing.Point(0, 134)
                    Me._booUpdate = False
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnSave_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '**************************************************************************
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '**************************************************************************
    Private Sub dbgDay1_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles dbgDay1.FetchRowStyle
        e.CellStyle.BackColor = Color.Salmon
        MsgBox("FetchRowStyle")
    End Sub

    '**************************************************************************
    Private Sub btnDeletedSelItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletedSelItem.Click
        Dim iPunchID As Integer = 0
        Dim i As Integer = 0
        Dim strInTime As String = ""
        Dim strOutTime As String = ""

        Try
            If IsNothing(Me.dbgDay1.DataSource) OrElse Me.dbgDay1.RowCount = 0 Then Exit Sub

            If Me.dbgDay1.SelectedRows.Count > 0 Then
                If MessageBox.Show("Are you sure you want to delete the selected record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    iPunchID = CInt(Me.dbgDay1.Columns("Punch_ID").Value.ToString.Trim)
                    If Not IsDBNull(Me.dbgDay1.Columns("InTime").Value) Then strInTime = Format(Me.dbgDay1.Columns("InTime").Value, "yyyy-MM-dd HH:mm:ss")
                    If Not IsDBNull(Me.dbgDay1.Columns("OutTime").Value) Then strOutTime = Format(Me.dbgDay1.Columns("OutTime").Value, "yyyy-MM-dd HH:mm:ss")
                    'MsgBox(iPunchID & Environment.NewLine & strInTime & Environment.NewLine & strOutTime)
                    i = Me._objCCTT.DeletePunchRecord(iPunchID, PSS.Core.ApplicationUser.IDuser, PSS.Core.ApplicationUser.User, strInTime, strOutTime)
                    MessageBox.Show("Completed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    PopulateProdTimeCard(Me.dbgDay1)

                    Me.pnlNewDateTime.Visible = False
                    Me._booUpdate = False
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "btnDeletedSelItem_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '**************************************************************************
End Class
