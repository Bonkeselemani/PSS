Imports PSS.Core.Global
Public Class frmQC
    Inherits System.Windows.Forms.Form

    Private objQC As PSS.Data.Buisness.QC
    Private iDevice_ID As Integer = 0
    Private arrSplitLine(0)
    Private Const strdelimiter As String = "~"
    Private iQCResult As Integer = 0

    Private strUserName As String = PSS.Core.Global.ApplicationUser.User
    Private iUserID As Integer = PSS.Core.Global.ApplicationUser.IDuser
    Private iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        objQC = New PSS.Data.Buisness.QC()

        'radioPassFail(0) = Me.RadioPass
        'radioPassFail(1) = Me.RadioFail

        'radioFqaCqa(0) = Me.RadioCQA
        'radioFqaCqa(1) = Me.RadioFQA
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
    Friend WithEvents txtSN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblSN As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents lstFailCodes As System.Windows.Forms.ListBox
    Friend WithEvents cboCodes As PSS.Gui.Controls.ComboBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cboProduct As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grdHistory As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdRemove As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboUsers As PSS.Gui.Controls.ComboBox
    Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboQCType As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents btnPass As System.Windows.Forms.Button
    Friend WithEvents btnFail As System.Windows.Forms.Button
    Friend WithEvents lbldate As System.Windows.Forms.Label
    Friend WithEvents lblPassed As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lblShift As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboLine As PSS.Gui.Controls.ComboBox
    Friend WithEvents cboGroup As PSS.Gui.Controls.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmQC))
        Dim GridLines1 As C1.Win.C1TrueDBGrid.Util.GridLines = New C1.Win.C1TrueDBGrid.Util.GridLines()
        Me.txtSN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCodes = New PSS.Gui.Controls.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdDelete = New System.Windows.Forms.Button()
        Me.grdHistory = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblSN = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.pnlFailCodes = New System.Windows.Forms.Panel()
        Me.cmdRemove = New System.Windows.Forms.Button()
        Me.lstFailCodes = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.cboLine = New PSS.Gui.Controls.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboGroup = New PSS.Gui.Controls.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboProduct = New PSS.Gui.Controls.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cboQCType = New PSS.Gui.Controls.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbldate = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cboUsers = New PSS.Gui.Controls.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnFail = New System.Windows.Forms.Button()
        Me.btnPass = New System.Windows.Forms.Button()
        Me.lblPassed = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel3.SuspendLayout()
        CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.pnlFailCodes.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSN
        '
        Me.txtSN.BackColor = System.Drawing.Color.Khaki
        Me.txtSN.Location = New System.Drawing.Point(122, 18)
        Me.txtSN.Name = "txtSN"
        Me.txtSN.Size = New System.Drawing.Size(159, 20)
        Me.txtSN.TabIndex = 5
        Me.txtSN.Text = ""
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Yellow
        Me.Label2.Location = New System.Drawing.Point(15, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(274, 63)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Quality Control"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 16)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Serial Number:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 16)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Fail Code:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCodes
        '
        Me.cboCodes.AutoComplete = True
        Me.cboCodes.BackColor = System.Drawing.SystemColors.Window
        Me.cboCodes.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCodes.ForeColor = System.Drawing.Color.Black
        Me.cboCodes.Location = New System.Drawing.Point(7, 29)
        Me.cboCodes.Name = "cboCodes"
        Me.cboCodes.Size = New System.Drawing.Size(345, 21)
        Me.cboCodes.TabIndex = 9
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdDelete, Me.grdHistory, Me.Label4, Me.lblSN})
        Me.Panel3.Location = New System.Drawing.Point(13, 209)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(808, 113)
        Me.Panel3.TabIndex = 73
        '
        'cmdDelete
        '
        Me.cmdDelete.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelete.ForeColor = System.Drawing.Color.White
        Me.cmdDelete.Location = New System.Drawing.Point(643, 2)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(152, 24)
        Me.cmdDelete.TabIndex = 15
        Me.cmdDelete.Text = "Delete (Are you sure?)"
        Me.cmdDelete.Visible = False
        '
        'grdHistory
        '
        Me.grdHistory.AllowFilter = True
        Me.grdHistory.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.AllRows
        Me.grdHistory.AllowSort = True
        Me.grdHistory.CaptionHeight = 17
        Me.grdHistory.CollapseColor = System.Drawing.Color.Black
        Me.grdHistory.DataChanged = False
        Me.grdHistory.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.grdHistory.ExpandColor = System.Drawing.Color.Black
        Me.grdHistory.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdHistory.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdHistory.Location = New System.Drawing.Point(9, 30)
        Me.grdHistory.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.DottedCellBorder
        Me.grdHistory.Name = "grdHistory"
        Me.grdHistory.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdHistory.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdHistory.PreviewInfo.ZoomFactor = 75
        Me.grdHistory.PrintInfo.ShowOptionsDialog = False
        Me.grdHistory.RecordSelectorWidth = 16
        GridLines1.Color = System.Drawing.Color.DarkGray
        GridLines1.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single
        Me.grdHistory.RowDivider = GridLines1
        Me.grdHistory.RowHeight = 15
        Me.grdHistory.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.grdHistory.ScrollTips = False
        Me.grdHistory.Size = New System.Drawing.Size(786, 72)
        Me.grdHistory.TabIndex = 14
        Me.grdHistory.Text = "C1TrueDBGrid1"
        Me.grdHistory.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
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
        "llGroup=""1""><ClientRect>0, 0, 782, 68</ClientRect><BorderSide>0</BorderSide><Cap" & _
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
        "idth><ClientArea>0, 0, 782, 68</ClientArea></Blob>"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "QC History for "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSN
        '
        Me.lblSN.BackColor = System.Drawing.Color.Transparent
        Me.lblSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSN.ForeColor = System.Drawing.Color.Red
        Me.lblSN.Location = New System.Drawing.Point(112, 4)
        Me.lblSN.Name = "lblSN"
        Me.lblSN.Size = New System.Drawing.Size(187, 16)
        Me.lblSN.TabIndex = 76
        Me.lblSN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label1, Me.txtSN})
        Me.Panel4.Location = New System.Drawing.Point(13, 149)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(304, 56)
        Me.Panel4.TabIndex = 75
        '
        'pnlFailCodes
        '
        Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdRemove, Me.lstFailCodes, Me.btnAdd, Me.cboCodes, Me.Label3})
        Me.pnlFailCodes.Location = New System.Drawing.Point(12, 357)
        Me.pnlFailCodes.Name = "pnlFailCodes"
        Me.pnlFailCodes.Size = New System.Drawing.Size(809, 82)
        Me.pnlFailCodes.TabIndex = 77
        Me.pnlFailCodes.Visible = False
        '
        'cmdRemove
        '
        Me.cmdRemove.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemove.ForeColor = System.Drawing.Color.White
        Me.cmdRemove.Location = New System.Drawing.Point(372, 44)
        Me.cmdRemove.Name = "cmdRemove"
        Me.cmdRemove.Size = New System.Drawing.Size(71, 24)
        Me.cmdRemove.TabIndex = 12
        Me.cmdRemove.Text = "<-----"
        '
        'lstFailCodes
        '
        Me.lstFailCodes.Location = New System.Drawing.Point(463, 5)
        Me.lstFailCodes.Name = "lstFailCodes"
        Me.lstFailCodes.Size = New System.Drawing.Size(337, 69)
        Me.lstFailCodes.TabIndex = 11
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.SteelBlue
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.ForeColor = System.Drawing.Color.White
        Me.btnAdd.Location = New System.Drawing.Point(372, 11)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(71, 24)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "----->"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.LightSteelBlue
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Blue
        Me.btnSave.Location = New System.Drawing.Point(209, 328)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(424, 25)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save (F5)"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboLine, Me.Label11, Me.cboGroup, Me.Label9, Me.cboProduct, Me.Label5, Me.Button4, Me.cboQCType, Me.Label8})
        Me.Panel6.Location = New System.Drawing.Point(14, 72)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(807, 72)
        Me.Panel6.TabIndex = 79
        '
        'cboLine
        '
        Me.cboLine.AutoComplete = True
        Me.cboLine.BackColor = System.Drawing.SystemColors.Window
        Me.cboLine.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboLine.ForeColor = System.Drawing.Color.Black
        Me.cboLine.Location = New System.Drawing.Point(528, 39)
        Me.cboLine.Name = "cboLine"
        Me.cboLine.Size = New System.Drawing.Size(143, 21)
        Me.cboLine.TabIndex = 86
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(456, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 87
        Me.Label11.Text = "Line:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboGroup
        '
        Me.cboGroup.AutoComplete = True
        Me.cboGroup.BackColor = System.Drawing.SystemColors.Window
        Me.cboGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGroup.ForeColor = System.Drawing.Color.Black
        Me.cboGroup.Location = New System.Drawing.Point(122, 39)
        Me.cboGroup.Name = "cboGroup"
        Me.cboGroup.Size = New System.Drawing.Size(143, 21)
        Me.cboGroup.TabIndex = 84
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(50, 39)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 85
        Me.Label9.Text = "Group:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboProduct
        '
        Me.cboProduct.AutoComplete = True
        Me.cboProduct.BackColor = System.Drawing.SystemColors.Window
        Me.cboProduct.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProduct.ForeColor = System.Drawing.Color.Black
        Me.cboProduct.Location = New System.Drawing.Point(122, 8)
        Me.cboProduct.Name = "cboProduct"
        Me.cboProduct.Size = New System.Drawing.Size(143, 21)
        Me.cboProduct.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(50, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Product:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'cboQCType
        '
        Me.cboQCType.AutoComplete = True
        Me.cboQCType.BackColor = System.Drawing.SystemColors.Window
        Me.cboQCType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboQCType.ForeColor = System.Drawing.Color.Black
        Me.cboQCType.Location = New System.Drawing.Point(528, 8)
        Me.cboQCType.Name = "cboQCType"
        Me.cboQCType.Size = New System.Drawing.Size(143, 21)
        Me.cboQCType.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(458, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "QC Type:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbldate
        '
        Me.lbldate.BackColor = System.Drawing.Color.Transparent
        Me.lbldate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldate.ForeColor = System.Drawing.Color.White
        Me.lbldate.Location = New System.Drawing.Point(392, 6)
        Me.lbldate.Name = "lbldate"
        Me.lbldate.Size = New System.Drawing.Size(130, 16)
        Me.lbldate.TabIndex = 84
        Me.lbldate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUserName
        '
        Me.lblUserName.BackColor = System.Drawing.Color.Transparent
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.ForeColor = System.Drawing.Color.White
        Me.lblUserName.Location = New System.Drawing.Point(211, 6)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(173, 16)
        Me.lblUserName.TabIndex = 83
        Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(131, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 16)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Inspector :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel7.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.Button3, Me.cboUsers})
        Me.Panel7.Location = New System.Drawing.Point(511, 149)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(310, 56)
        Me.Panel7.TabIndex = 80
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(21, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 16)
        Me.Label6.TabIndex = 82
        Me.Label6.Text = "Tech:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        'cboUsers
        '
        Me.cboUsers.AutoComplete = True
        Me.cboUsers.BackColor = System.Drawing.SystemColors.Window
        Me.cboUsers.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUsers.ForeColor = System.Drawing.Color.Black
        Me.cboUsers.Location = New System.Drawing.Point(69, 17)
        Me.cboUsers.Name = "cboUsers"
        Me.cboUsers.Size = New System.Drawing.Size(200, 21)
        Me.cboUsers.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.btnFail, Me.btnPass})
        Me.Panel1.Location = New System.Drawing.Point(321, 149)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(186, 56)
        Me.Panel1.TabIndex = 81
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(300, 300)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(700, 700)
        Me.Button1.TabIndex = 66
        Me.Button1.TabStop = False
        Me.Button1.Text = "Generate Report"
        '
        'btnFail
        '
        Me.btnFail.BackColor = System.Drawing.Color.SteelBlue
        Me.btnFail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFail.ForeColor = System.Drawing.Color.White
        Me.btnFail.Location = New System.Drawing.Point(95, 7)
        Me.btnFail.Name = "btnFail"
        Me.btnFail.Size = New System.Drawing.Size(78, 40)
        Me.btnFail.TabIndex = 7
        Me.btnFail.Text = "Fail (F12)"
        '
        'btnPass
        '
        Me.btnPass.BackColor = System.Drawing.Color.SteelBlue
        Me.btnPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPass.ForeColor = System.Drawing.Color.White
        Me.btnPass.Location = New System.Drawing.Point(9, 7)
        Me.btnPass.Name = "btnPass"
        Me.btnPass.Size = New System.Drawing.Size(78, 40)
        Me.btnPass.TabIndex = 6
        Me.btnPass.Text = "Pass (F9)"
        '
        'lblPassed
        '
        Me.lblPassed.BackColor = System.Drawing.Color.Black
        Me.lblPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassed.ForeColor = System.Drawing.Color.Lime
        Me.lblPassed.Location = New System.Drawing.Point(280, 34)
        Me.lblPassed.Name = "lblPassed"
        Me.lblPassed.Size = New System.Drawing.Size(47, 22)
        Me.lblPassed.TabIndex = 84
        Me.lblPassed.Text = "0"
        Me.lblPassed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Black
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Lime
        Me.Label10.Location = New System.Drawing.Point(192, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 22)
        Me.Label10.TabIndex = 85
        Me.Label10.Text = "Passed :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblShift, Me.Button2, Me.lbldate, Me.lblUserName, Me.Label7, Me.Label10, Me.lblPassed})
        Me.Panel2.Location = New System.Drawing.Point(293, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(528, 64)
        Me.Panel2.TabIndex = 86
        '
        'lblShift
        '
        Me.lblShift.BackColor = System.Drawing.Color.Transparent
        Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblShift.ForeColor = System.Drawing.Color.White
        Me.lblShift.Location = New System.Drawing.Point(15, 6)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(111, 16)
        Me.lblShift.TabIndex = 88
        Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'frmQC
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(896, 452)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel2, Me.Panel1, Me.Panel7, Me.Panel6, Me.btnSave, Me.pnlFailCodes, Me.Panel4, Me.Panel3, Me.Label2})
        Me.Name = "frmQC"
        Me.Text = "frmQC"
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.pnlFailCodes.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmQC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadProductTypes()
        LoadUsers()
        LoadQCTypes()
        LoadGroups()
        LoadLines()
        objQC.SetShiftInfo(iShiftID)
        Me.lblShift.Text = objQC.Shift
        Me.lblUserName.Text = strUserName
        Me.cboProduct.Focus()
        Me.lbldate.Text = "Date: " & Format(Now, "MM-dd-yyyy")

        'Set Special permissions
        If ApplicationUser.GetPermission("QC_Delete") > 0 Then
            Me.cmdDelete.Visible = True
        Else
            Me.cmdDelete.Visible = False
        End If
    End Sub
    '*********************************************************
    Private Sub LoadQCPASSNumber()
        Dim dt1 As New DataTable()
        Dim R1 As DataRow


        Try
            ''Comment this out before going live
            'iUserID = 297
            'iShiftID = 2

            If Me.cboQCType.SelectedValue = 0 Or iShiftID = 0 Or iUserID = 0 Then
                Exit Sub
            End If

            dt1 = objQC.GetQCPASSNumber(iUserID, iShiftID, Me.cboQCType.SelectedValue)
            If dt1.Rows.Count > 0 Then
                R1 = dt1.Rows(0)
                Me.lblPassed.Text = R1("PassCount")
            Else
                Me.lblPassed.Text = "0"
            End If

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadQCNumbers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            R1 = Nothing
            objQC.DisposeDT(dt1)
        End Try

    End Sub
    '*********************************************************
    Private Sub LoadQCTypes()
        Dim dtUsers As New DataTable()
        Try
            dtUsers = objQC.GetQCTypeInfo
            With Me.cboQCType
                .DataSource = dtUsers.DefaultView
                .DisplayMember = dtUsers.Columns("QCType").ToString
                .ValueMember = dtUsers.Columns("QCType_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadQCTypes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtUsers)
        End Try
    End Sub
    '*********************************************************
    Private Sub LoadLines()
        Dim dtLines As New DataTable()
        Try
            dtLines = objQC.LoadLines()
            With Me.cboLine
                .DataSource = dtLines.DefaultView
                .DisplayMember = dtLines.Columns("Line_Number").ToString
                .ValueMember = dtLines.Columns("Line_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadLines:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtLines)
        End Try
    End Sub

    '*********************************************************
    Private Sub LoadGroups()
        Dim dtGroups As New DataTable()
        Try
            dtGroups = objQC.LoadGroups()
            With Me.cboGroup
                .DataSource = dtGroups.DefaultView
                .DisplayMember = dtGroups.Columns("Group_Desc").ToString
                .ValueMember = dtGroups.Columns("Group_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadGroups:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtGroups)
        End Try
    End Sub
    '*********************************************************

    Private Sub LoadUsers()
        Dim dtUsers As New DataTable()
        Try
            dtUsers = objQC.LoadUsers()
            With Me.cboUsers
                .DataSource = dtUsers.DefaultView
                .DisplayMember = dtUsers.Columns("user_fullname").ToString
                .ValueMember = dtUsers.Columns("user_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadUsers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtUsers)
        End Try
    End Sub
    '*********************************************************
    Private Sub LoadFailureCodes()
        Dim dtCodes As New DataTable()
        Try
            dtCodes = objQC.LoadFailureCodes(Me.cboProduct.SelectedValue)
            With Me.cboCodes
                .DataSource = dtCodes.DefaultView
                .DisplayMember = dtCodes.Columns("DCode_SLDesc").ToString
                .ValueMember = dtCodes.Columns("DCode_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC.LoadFailureCodes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtCodes)
        End Try
    End Sub
    '****************************************************************************
    Private Sub LoadProductTypes()
        Dim dtProd As New DataTable()
        Try
            dtProd = objQC.LoadProductTypes
            With Me.cboProduct
                .DataSource = dtProd.DefaultView
                .DisplayMember = dtProd.Columns("prod_desc").ToString
                .ValueMember = dtProd.Columns("prod_id").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmQC_Codes.LoadProductTypes:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            objQC.DisposeDT(dtProd)
        End Try
    End Sub

    '*****************************************************************************
    Protected Overrides Sub Finalize()
        objQC = Nothing
        MyBase.Finalize()
    End Sub

    '*****************************************************************************
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddCodeToList()
    End Sub
    '*****************************************************************************
    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        RemoveItemFromList()
    End Sub
    '*****************************************************************************
    Private Sub txtSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSN.KeyUp

        If e.KeyValue = 13 Then
            If Me.cboProduct.SelectedValue = 0 Then
                MessageBox.Show("Please select a Product to continue.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                Me.cboProduct.Focus()
                Exit Sub
            ElseIf Me.cboQCType.SelectedValue = 0 Then
                MessageBox.Show("Please choose if this is CQA or FQA.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                Me.cboQCType.Focus()
                Exit Sub
            ElseIf Me.cboGroup.SelectedValue = 0 Then
                MessageBox.Show("Please choose a Group.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                Me.cboGroup.Focus()
                Exit Sub
            ElseIf Me.cboLine.SelectedValue = 0 Then
                MessageBox.Show("Please choose a Line.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.txtSN.Text = ""
                Me.cboLine.Focus()
                Exit Sub
            End If

            Try
                'Me.cboUsers.SelectedValue = 0
                'iQCResult = 0
                'iDevice_ID = 0
                'btnPass.BackColor = System.Drawing.Color.SteelBlue
                'btnFail.BackColor = System.Drawing.Color.SteelBlue
                'Me.cboCodes.SelectedValue = 0
                'Me.lstFailCodes.Items.Clear()
                'Me.pnlFailCodes.Visible = False
                ResetControls()

                'Check if this device is actually of the product type selected.
                If Me.cboProduct.SelectedValue <> objQC.GetDeviceProductType(Trim(Me.txtSN.Text)) Then
                    MessageBox.Show("The device scanned in is not of the Product type selected on the screen.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    Me.txtSN.Text = ""
                    Exit Sub
                End If

                'Get Device_ID
                iDevice_ID = objQC.GetDeviceInfo(Trim(Me.txtSN.Text))

                'Get Device QC History
                LoadQCHistory()

                Me.lblSN.Text = Trim(Me.txtSN.Text)
                Me.txtSN.Text = ""
                Me.txtSN.Focus()

            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        ElseIf e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        End If
    End Sub
    '*****************************************************************************
    Private Sub LoadQCHistory()
        Dim dt1 As DataTable

        Try
            dt1 = objQC.GetQCHistory(iDevice_ID)
            Me.grdHistory.ClearFields()
            Me.grdHistory.DataSource = dt1.DefaultView
            SetGridProperties()

        Catch ex As Exception
            Throw New Exception("frmQC.LoadQCHistory(): " & Environment.NewLine & ex.Message.ToString)
        Finally
            objQC.DisposeDT(dt1)
        End Try
    End Sub
    '*****************************************************************************
    Private Sub SetGridProperties()
        Dim iNumOfColumns As Integer = Me.grdHistory.Columns.Count
        Dim i As Integer

        'Heading style (Horizontal Alignment to Center)
        For i = 0 To (iNumOfColumns - 1)
            Me.grdHistory.Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Next

        'Set individual column data horizontal alignment
        Me.grdHistory.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        'Set Column Widths
        Me.grdHistory.Splits(0).DisplayColumns(0).Width = 55
        Me.grdHistory.Splits(0).DisplayColumns(1).Width = 132
        Me.grdHistory.Splits(0).DisplayColumns(2).Width = 54
        Me.grdHistory.Splits(0).DisplayColumns(3).Width = 63
        Me.grdHistory.Splits(0).DisplayColumns(4).Width = 71
        Me.grdHistory.Splits(0).DisplayColumns(5).Width = 235
        Me.grdHistory.Splits(0).DisplayColumns(6).Width = 179
        Me.grdHistory.Splits(0).DisplayColumns(7).Width = 182

        'Make some columns invisible
        Me.grdHistory.Splits(0).DisplayColumns(8).Visible = False
        Me.grdHistory.Splits(0).DisplayColumns(9).Visible = False
        Me.grdHistory.Splits(0).DisplayColumns(10).Visible = False
        Me.grdHistory.Splits(0).DisplayColumns(11).Visible = False

    End Sub

    '*****************************************************************************
    Private Sub ClearCodeList()
        Me.lstFailCodes.Items.Clear()
    End Sub

    '*****************************************************************************
    'Private Sub ClearControls()
    '    With Me
    '        .iDevice_ID = 0
    '        .cboQCType.SelectedValue = 0
    '        iQCResult = 0
    '        btnPass.BackColor = System.Drawing.Color.SteelBlue
    '        btnFail.BackColor = System.Drawing.Color.SteelBlue
    '        .cboUsers.SelectedValue = 0
    '        .txtSN.Text = ""
    '        .lblSN.Text = ""
    '        .cboQCType.SelectedValue = 0
    '        .cboUsers.SelectedValue = 0
    '        .cboCodes.SelectedValue = 0
    '        .lstFailCodes.Items.Clear()
    '    End With
    'End Sub
    '*****************************************************************************
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveQCInfo()
        LoadQCPASSNumber()
    End Sub
    '*****************************************************************************
    Private Function ConcatenateCodes() As String
        Dim i As Integer = 0
        Dim strCodes As String = ""

        For i = 0 To Me.lstFailCodes.Items.Count - 1
            arrSplitLine = Split(Trim(lstFailCodes.Items(i)), strdelimiter)
            strCodes += Trim(arrSplitLine(1))
            If i <> Me.lstFailCodes.Items.Count - 1 Then
                strCodes += ","
            End If

            ReDim arrSplitLine(0)
            arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)
        Next i

        ReDim arrSplitLine(0)
        arrSplitLine.Clear(arrSplitLine, 0, arrSplitLine.Length)

        Return strCodes
    End Function

    '*****************************************************************************
    Private Sub cboProduct_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProduct.SelectionChangeCommitted
        ResetControls()
        LoadFailureCodes()
        Me.cboQCType.Focus()
    End Sub
    '*****************************************************************************
    Private Sub cboQCType_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboQCType.SelectionChangeCommitted
        LoadQCPASSNumber()
        'Me.txtSN.Focus()
        Me.cboGroup.Focus()
    End Sub
    '*****************************************************************************
    Private Sub cboGroup_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGroup.SelectionChangeCommitted
        Me.cboLine.Focus()
    End Sub
    '*****************************************************************************
    Private Sub cboLine_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboLine.SelectionChangeCommitted
        Me.txtSN.Focus()
    End Sub
    '*****************************************************************************
    Private Sub cboUsers_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUsers.SelectionChangeCommitted
        Me.cboCodes.Focus()
    End Sub
    '*****************************************************************************
    Private Sub cboCodes_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCodes.SelectionChangeCommitted
        Me.btnAdd.Focus()
    End Sub
    '*****************************************************************************
    Private Sub PassQC()
        If iDevice_ID = 0 Then
            MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        End If

        btnPass.BackColor = System.Drawing.Color.Red
        btnFail.BackColor = System.Drawing.Color.SteelBlue

        iQCResult = 1
        pnlFailCodes.Visible = False
        Me.cboCodes.SelectedValue = 0
        ClearCodeList()
        Me.cboUsers.Focus()
    End Sub
    '*****************************************************************************
    Private Sub btnPass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPass.Click
        PassQC()
    End Sub
    '*****************************************************************************
    Private Sub btnFail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFail.Click
        FailQC()
    End Sub
    '*****************************************************************************
    Private Sub FailQC()
        If iDevice_ID = 0 Then
            MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        End If

        btnPass.BackColor = System.Drawing.Color.SteelBlue
        btnFail.BackColor = System.Drawing.Color.Red

        iQCResult = 2
        pnlFailCodes.Visible = True
        Me.cboUsers.Focus()
    End Sub
    '*****************************************************************************
    Private Sub cboCodes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboCodes.KeyUp
        If e.KeyValue = 13 Then        'Enter key presssed
            AddCodeToList()
        End If
    End Sub
    '*****************************************************************************
    Private Sub AddCodeToList()
        Dim i As Integer = 0

        If Me.cboCodes.SelectedValue = 0 Then
            MessageBox.Show("Please select the code again.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If

        Dim strItem As String = Trim(Me.cboCodes.Text) & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & strdelimiter & Me.cboCodes.SelectedValue

        For i = 0 To Me.lstFailCodes.Items.Count - 1
            If Me.lstFailCodes.Items(i) = strItem Then  'UCase(txtDevice.Text) Then
                MsgBox("This code is already added to the list.", MsgBoxStyle.Information, "QC")
                Exit Sub
            End If
        Next

        Me.lstFailCodes.Items.Add(strItem)
        Me.cboCodes.SelectedValue = 0
    End Sub
    '*****************************************************************************
    Private Sub lstFailCodes_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstFailCodes.KeyUp
        If e.KeyValue = 13 Then        'Enter Key Pressed
            RemoveItemFromList()
        End If
    End Sub
    '*****************************************************************************
    Private Sub RemoveItemFromList()
        If Me.lstFailCodes.SelectedIndex <> -1 Then    'If nothing is selected
            Me.lstFailCodes.Items.RemoveAt(Me.lstFailCodes.SelectedIndex)
            Me.lstFailCodes.Refresh()
        End If
    End Sub
    '*****************************************************************************
    Private Sub btnPass_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnPass.KeyUp
        If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        ElseIf e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        End If
    End Sub
    '*****************************************************************************
    Private Sub btnFail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnFail.KeyUp
        If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F12 Then
            FailQC()
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        End If
    End Sub
    '*****************************************************************************
    Private Sub AllControlsKeyupEvent(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProduct.KeyUp, cboQCType.KeyUp, cboUsers.KeyUp, cboCodes.KeyUp, lstFailCodes.KeyUp, grdHistory.KeyUp
        If e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        ElseIf e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        End If
    End Sub
    '*****************************************************************************
    Private Sub SaveQCInfo()
        Dim i As Integer = 0
        Dim strFailCodes As String = ""

        '********************************************************************
        'Required Field validations.
        If PSS.Core.Global.ApplicationUser.IDuser = 0 Then
            MessageBox.Show("Inspector does not have a QC Stamp Number assigned.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        End If
        If Me.cboProduct.SelectedValue = 0 Then
            MessageBox.Show("Please select a Product.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.cboQCType.Focus()
            Exit Sub
        End If
        If iDevice_ID = 0 Then      'Adding a new Device_ID
            MessageBox.Show("Please scan in a device to do QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.txtSN.Focus()
            Exit Sub
        End If
        If Me.cboQCType.SelectedValue = 0 Then
            MessageBox.Show("Please select QC Type.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.cboQCType.Focus()
            Exit Sub
        End If

        If iQCResult = 0 Then
            MessageBox.Show("Please choose if this device passed or failed QC.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.btnPass.Focus()
            Exit Sub
        End If

        If iQCResult = 2 Then   'if failed
            If Me.lstFailCodes.Items.Count = 0 Then
                MessageBox.Show("This device failed QC, so please select the QC reasons.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.cboCodes.Focus()
                Exit Sub
            End If
        End If
        If Me.cboUsers.SelectedValue = 0 Then
            MessageBox.Show("Please select the Tech who worked on this device.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.cboUsers.Focus()
            Exit Sub
        End If
        If Me.cboGroup.SelectedValue = 0 Then
            MessageBox.Show("Please choose a Group.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.cboGroup.Focus()
            Exit Sub
        End If
        If Me.cboLine.SelectedValue = 0 Then
            MessageBox.Show("Please choose a Line.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.cboLine.Focus()
            Exit Sub
        End If

        '********************************************************************
        Try
            strFailCodes = ConcatenateCodes()

            i = objQC.SaveQCResults(iDevice_ID, Me.cboQCType.SelectedValue, iQCResult, strFailCodes, Me.cboUsers.SelectedValue, PSS.Core.Global.ApplicationUser.IDuser, PSS.Core.Global.ApplicationUser.Workdate, Me.cboGroup.SelectedValue, Me.cboLine.SelectedValue)

            If i > 0 Then
                MessageBox.Show("QC Results are saved.", "QC", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            LoadQCHistory()

            iQCResult = 0
            btnPass.BackColor = System.Drawing.Color.SteelBlue
            btnFail.BackColor = System.Drawing.Color.SteelBlue


            Me.cboUsers.SelectedValue = 0
            Me.cboCodes.SelectedValue = 0
            Me.lstFailCodes.Items.Clear()
            Me.pnlFailCodes.Visible = False

        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, "QC", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try

    End Sub
    '********************************************************************
    Private Sub btnSave_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnSave.KeyUp
        If e.KeyValue = Keys.Return Or e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        End If
    End Sub
    '********************************************************************

    Private Sub btnAdd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles btnAdd.KeyUp
        If e.KeyValue = Keys.Return Then
            AddCodeToList()
        End If
        If e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        End If
    End Sub
    '********************************************************************
    Private Sub cmdRemove_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmdRemove.KeyUp
        If e.KeyValue = Keys.Return Then
            RemoveItemFromList()
        End If
        If e.KeyValue = Keys.F5 Then
            SaveQCInfo()
        ElseIf e.KeyValue = Keys.F9 Then
            PassQC()
        ElseIf e.KeyValue = Keys.F12 Then
            FailQC()
        End If
    End Sub
    '*********************************************************************
    Private Sub ResetControls()
        Me.cboUsers.SelectedValue = 0
        iQCResult = 0
        iDevice_ID = 0
        'Me.txtSN.Text = ""
        Me.lblSN.Text = ""
        btnPass.BackColor = System.Drawing.Color.SteelBlue
        btnFail.BackColor = System.Drawing.Color.SteelBlue
        Me.cboCodes.SelectedValue = 0
        Me.lstFailCodes.Items.Clear()
        Me.pnlFailCodes.Visible = False
    End Sub
    '*********************************************************************
    Private Sub cmdDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        Dim i As Integer = 0
        If MessageBox.Show("Are you sure you want to delete this QC result?", "Delete QC History", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Try
                i = objQC.DeleteQCHistory(CInt(Me.grdHistory.Columns("QC_ID").Value), iUserID, System.Net.Dns.GetHostName)
                If i > 0 Then
                    'MessageBox.Show("Deleted successfully", "Delete QC History", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    LoadQCHistory()
                Else
                    MessageBox.Show("Unable to delete QC history. Contact administrators.", "Delete QC History", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message.ToString, "Delete QC History", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End If
    End Sub

    '*********************************************************************
End Class
