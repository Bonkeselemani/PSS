Imports Microsoft.Data.Odbc
Imports System.IO

Public Class frmProcessFlow
    Inherits System.Windows.Forms.Form
    'Private dtBuckets As DataTable
    'Private dtFlow As DataTable
    Private iUserID As Integer = PSS.Core.[Global].ApplicationUser.IDuser

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'dtBuckets = New DataTable()
        'dtFlow = New DataTable()
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
    Friend WithEvents cmbCustomer As PSS.Gui.Controls.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbLine As PSS.Gui.Controls.ComboBox
    Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
    Friend WithEvents pnlFailCodes As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstFlow As System.Windows.Forms.ListBox
    Friend WithEvents cmdMoveDown As System.Windows.Forms.Button
    Friend WithEvents cmdMoveUp As System.Windows.Forms.Button
    Friend WithEvents lstBuckets As System.Windows.Forms.ListBox
    Friend WithEvents grdPreviousMaps As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdAddToList As System.Windows.Forms.Button
    Friend WithEvents cmdRemoveFromList As System.Windows.Forms.Button
    Friend WithEvents cmdAddNewBucket As System.Windows.Forms.Button
    Friend WithEvents cmdDelBucket As System.Windows.Forms.Button
    Friend WithEvents cmdSaveFlowSeq As System.Windows.Forms.Button
    Friend WithEvents cmdDeleteSeq As System.Windows.Forms.Button
    Friend WithEvents lstModel As System.Windows.Forms.ListBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl As System.Windows.Forms.Label
    Friend WithEvents chkPush As System.Windows.Forms.CheckBox
    Friend WithEvents cmdConditionalPush As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblPushTo As System.Windows.Forms.Label
    Friend WithEvents cmdClearCP As System.Windows.Forms.Button
    Friend WithEvents CheckSameAsSelectedSeq As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmProcessFlow))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCustomer = New PSS.Gui.Controls.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbLine = New PSS.Gui.Controls.ComboBox()
        Me.PanelPalletList = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lstModel = New System.Windows.Forms.ListBox()
        Me.pnlFailCodes = New System.Windows.Forms.Panel()
        Me.cmdClearCP = New System.Windows.Forms.Button()
        Me.lblPushTo = New System.Windows.Forms.Label()
        Me.cmdConditionalPush = New System.Windows.Forms.Button()
        Me.chkPush = New System.Windows.Forms.CheckBox()
        Me.cmdDelBucket = New System.Windows.Forms.Button()
        Me.cmdMoveDown = New System.Windows.Forms.Button()
        Me.cmdMoveUp = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lstBuckets = New System.Windows.Forms.ListBox()
        Me.cmdAddToList = New System.Windows.Forms.Button()
        Me.lstFlow = New System.Windows.Forms.ListBox()
        Me.cmdRemoveFromList = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdAddNewBucket = New System.Windows.Forms.Button()
        Me.cmdSaveFlowSeq = New System.Windows.Forms.Button()
        Me.grdPreviousMaps = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.cmdDeleteSeq = New System.Windows.Forms.Button()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.CheckSameAsSelectedSeq = New System.Windows.Forms.CheckBox()
        Me.PanelPalletList.SuspendLayout()
        Me.pnlFailCodes.SuspendLayout()
        CType(Me.grdPreviousMaps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(8, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Model:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCustomer
        '
        Me.cmbCustomer.AutoComplete = True
        Me.cmbCustomer.BackColor = System.Drawing.SystemColors.Window
        Me.cmbCustomer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCustomer.ForeColor = System.Drawing.Color.Black
        Me.cmbCustomer.Location = New System.Drawing.Point(8, 120)
        Me.cmbCustomer.Name = "cmbCustomer"
        Me.cmbCustomer.Size = New System.Drawing.Size(175, 21)
        Me.cmbCustomer.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Customer:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Line:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbLine
        '
        Me.cmbLine.AutoComplete = True
        Me.cmbLine.BackColor = System.Drawing.SystemColors.Window
        Me.cmbLine.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLine.ForeColor = System.Drawing.Color.Black
        Me.cmbLine.Location = New System.Drawing.Point(8, 72)
        Me.cmbLine.Name = "cmbLine"
        Me.cmbLine.Size = New System.Drawing.Size(175, 21)
        Me.cmbLine.TabIndex = 1
        '
        'PanelPalletList
        '
        Me.PanelPalletList.BackColor = System.Drawing.Color.LightSteelBlue
        Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label6, Me.Label2, Me.Label3, Me.Label1, Me.cmbCustomer, Me.cmbLine, Me.lstModel})
        Me.PanelPalletList.Location = New System.Drawing.Point(-1, 64)
        Me.PanelPalletList.Name = "PanelPalletList"
        Me.PanelPalletList.Size = New System.Drawing.Size(216, 439)
        Me.PanelPalletList.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(16, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(176, 40)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Select the following to define Work Flow Sequence."
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstModel
        '
        Me.lstModel.Location = New System.Drawing.Point(8, 168)
        Me.lstModel.Name = "lstModel"
        Me.lstModel.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstModel.Size = New System.Drawing.Size(176, 251)
        Me.lstModel.TabIndex = 3
        '
        'pnlFailCodes
        '
        Me.pnlFailCodes.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnlFailCodes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlFailCodes.Controls.AddRange(New System.Windows.Forms.Control() {Me.cmdClearCP, Me.lblPushTo, Me.cmdConditionalPush, Me.chkPush, Me.cmdDelBucket, Me.cmdMoveDown, Me.cmdMoveUp, Me.Label5, Me.lstBuckets, Me.cmdAddToList, Me.lstFlow, Me.cmdRemoveFromList, Me.Label4, Me.cmdAddNewBucket, Me.cmdSaveFlowSeq})
        Me.pnlFailCodes.Location = New System.Drawing.Point(214, 0)
        Me.pnlFailCodes.Name = "pnlFailCodes"
        Me.pnlFailCodes.Size = New System.Drawing.Size(770, 304)
        Me.pnlFailCodes.TabIndex = 2
        '
        'cmdClearCP
        '
        Me.cmdClearCP.BackColor = System.Drawing.SystemColors.Control
        Me.cmdClearCP.Enabled = False
        Me.cmdClearCP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClearCP.ForeColor = System.Drawing.Color.Red
        Me.cmdClearCP.Location = New System.Drawing.Point(543, 154)
        Me.cmdClearCP.Name = "cmdClearCP"
        Me.cmdClearCP.Size = New System.Drawing.Size(153, 27)
        Me.cmdClearCP.TabIndex = 119
        Me.cmdClearCP.Text = "Clear Failure Bucket"
        '
        'lblPushTo
        '
        Me.lblPushTo.BackColor = System.Drawing.Color.Black
        Me.lblPushTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPushTo.ForeColor = System.Drawing.Color.Lime
        Me.lblPushTo.Location = New System.Drawing.Point(543, 129)
        Me.lblPushTo.Name = "lblPushTo"
        Me.lblPushTo.Size = New System.Drawing.Size(216, 21)
        Me.lblPushTo.TabIndex = 118
        Me.lblPushTo.Text = "CELLULAR 1 REFURB"
        Me.lblPushTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblPushTo.Visible = False
        '
        'cmdConditionalPush
        '
        Me.cmdConditionalPush.BackColor = System.Drawing.SystemColors.Control
        Me.cmdConditionalPush.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConditionalPush.ForeColor = System.Drawing.Color.Blue
        Me.cmdConditionalPush.Location = New System.Drawing.Point(542, 96)
        Me.cmdConditionalPush.Name = "cmdConditionalPush"
        Me.cmdConditionalPush.Size = New System.Drawing.Size(154, 28)
        Me.cmdConditionalPush.TabIndex = 117
        Me.cmdConditionalPush.Text = "If Failed Push to Bucket"
        '
        'chkPush
        '
        Me.chkPush.BackColor = System.Drawing.Color.Transparent
        Me.chkPush.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPush.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPush.Location = New System.Drawing.Point(128, 21)
        Me.chkPush.Name = "chkPush"
        Me.chkPush.Size = New System.Drawing.Size(120, 16)
        Me.chkPush.TabIndex = 116
        Me.chkPush.Text = "Bucket PUSHES"
        Me.chkPush.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdDelBucket
        '
        Me.cmdDelBucket.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDelBucket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDelBucket.ForeColor = System.Drawing.Color.Red
        Me.cmdDelBucket.Location = New System.Drawing.Point(192, 249)
        Me.cmdDelBucket.Name = "cmdDelBucket"
        Me.cmdDelBucket.Size = New System.Drawing.Size(72, 40)
        Me.cmdDelBucket.TabIndex = 78
        Me.cmdDelBucket.Text = "Delete Bucket"
        Me.cmdDelBucket.Visible = False
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMoveDown.BackgroundImage = CType(resources.GetObject("cmdMoveDown.BackgroundImage"), System.Drawing.Bitmap)
        Me.cmdMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveDown.ForeColor = System.Drawing.Color.White
        Me.cmdMoveDown.Location = New System.Drawing.Point(541, 200)
        Me.cmdMoveDown.Name = "cmdMoveDown"
        Me.cmdMoveDown.Size = New System.Drawing.Size(32, 32)
        Me.cmdMoveDown.TabIndex = 75
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp.BackColor = System.Drawing.SystemColors.Control
        Me.cmdMoveUp.BackgroundImage = CType(resources.GetObject("cmdMoveUp.BackgroundImage"), System.Drawing.Bitmap)
        Me.cmdMoveUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdMoveUp.ForeColor = System.Drawing.Color.White
        Me.cmdMoveUp.Location = New System.Drawing.Point(541, 48)
        Me.cmdMoveUp.Name = "cmdMoveUp"
        Me.cmdMoveUp.Size = New System.Drawing.Size(32, 32)
        Me.cmdMoveUp.TabIndex = 74
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(268, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 16)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Current Bucket Sequence:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstBuckets
        '
        Me.lstBuckets.Location = New System.Drawing.Point(8, 41)
        Me.lstBuckets.Name = "lstBuckets"
        Me.lstBuckets.Size = New System.Drawing.Size(208, 199)
        Me.lstBuckets.TabIndex = 72
        '
        'cmdAddToList
        '
        Me.cmdAddToList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddToList.BackgroundImage = CType(resources.GetObject("cmdAddToList.BackgroundImage"), System.Drawing.Bitmap)
        Me.cmdAddToList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddToList.ForeColor = System.Drawing.Color.White
        Me.cmdAddToList.Location = New System.Drawing.Point(226, 48)
        Me.cmdAddToList.Name = "cmdAddToList"
        Me.cmdAddToList.Size = New System.Drawing.Size(33, 32)
        Me.cmdAddToList.TabIndex = 12
        '
        'lstFlow
        '
        Me.lstFlow.Location = New System.Drawing.Point(269, 41)
        Me.lstFlow.Name = "lstFlow"
        Me.lstFlow.Size = New System.Drawing.Size(261, 199)
        Me.lstFlow.TabIndex = 11
        '
        'cmdRemoveFromList
        '
        Me.cmdRemoveFromList.BackColor = System.Drawing.SystemColors.Control
        Me.cmdRemoveFromList.BackgroundImage = CType(resources.GetObject("cmdRemoveFromList.BackgroundImage"), System.Drawing.Bitmap)
        Me.cmdRemoveFromList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRemoveFromList.ForeColor = System.Drawing.Color.White
        Me.cmdRemoveFromList.Location = New System.Drawing.Point(226, 200)
        Me.cmdRemoveFromList.Name = "cmdRemoveFromList"
        Me.cmdRemoveFromList.Size = New System.Drawing.Size(33, 32)
        Me.cmdRemoveFromList.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(8, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 16)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Buckets:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdAddNewBucket
        '
        Me.cmdAddNewBucket.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAddNewBucket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAddNewBucket.ForeColor = System.Drawing.Color.Blue
        Me.cmdAddNewBucket.Location = New System.Drawing.Point(56, 256)
        Me.cmdAddNewBucket.Name = "cmdAddNewBucket"
        Me.cmdAddNewBucket.Size = New System.Drawing.Size(112, 31)
        Me.cmdAddNewBucket.TabIndex = 77
        Me.cmdAddNewBucket.Text = "Add New Bucket"
        '
        'cmdSaveFlowSeq
        '
        Me.cmdSaveFlowSeq.BackColor = System.Drawing.SystemColors.Control
        Me.cmdSaveFlowSeq.Enabled = False
        Me.cmdSaveFlowSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSaveFlowSeq.ForeColor = System.Drawing.Color.Blue
        Me.cmdSaveFlowSeq.Location = New System.Drawing.Point(319, 255)
        Me.cmdSaveFlowSeq.Name = "cmdSaveFlowSeq"
        Me.cmdSaveFlowSeq.Size = New System.Drawing.Size(170, 32)
        Me.cmdSaveFlowSeq.TabIndex = 114
        Me.cmdSaveFlowSeq.Text = "Save Bucket Sequence"
        '
        'grdPreviousMaps
        '
        Me.grdPreviousMaps.AllowColMove = False
        Me.grdPreviousMaps.AllowColSelect = False
        Me.grdPreviousMaps.AllowFilter = False
        Me.grdPreviousMaps.AllowSort = False
        Me.grdPreviousMaps.AlternatingRows = True
        Me.grdPreviousMaps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPreviousMaps.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdPreviousMaps.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
        Me.grdPreviousMaps.Location = New System.Drawing.Point(8, 8)
        Me.grdPreviousMaps.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdPreviousMaps.Name = "grdPreviousMaps"
        Me.grdPreviousMaps.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdPreviousMaps.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdPreviousMaps.PreviewInfo.ZoomFactor = 75
        Me.grdPreviousMaps.RowHeight = 20
        Me.grdPreviousMaps.Size = New System.Drawing.Size(520, 152)
        Me.grdPreviousMaps.TabIndex = 114
        Me.grdPreviousMaps.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
        "r""><Data>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}E" & _
        "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{" & _
        "ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Inactive" & _
        "CaptionText;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Cent" & _
        "er;}Style9{}Normal{Font:Microsoft Sans Serif, 8.25pt;BackColor:Control;AlignVert" & _
        ":Center;}HighlightRow{ForeColor:HighlightText;BackColor:Highlight;}Style12{}OddR" & _
        "ow{BackColor:Control;}RecordSelector{AlignImage:Center;}Style13{}Heading{Wrap:Tr" & _
        "ue;Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Cont" & _
        "rol;Border:Raised,,1, 1, 1, 1;ForeColor:ControlText;AlignVert:Center;}Style8{}St" & _
        "yle10{AlignHorz:Near;}Style11{}Style14{}Style15{}Style1{}</Data></Styles><Splits" & _
        "><C1.Win.C1TrueDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name" & _
        "="""" AlternatingRowStyle=""True"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" Colum" & _
        "nFooterHeight=""17"" MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""16"" DefR" & _
        "ecSelWidth=""16"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>148</H" & _
        "eight><CaptionStyle parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" " & _
        "me=""Style5"" /><EvenRowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle paren" & _
        "t=""FilterBar"" me=""Style13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupSt" & _
        "yle parent=""Group"" me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><" & _
        "HighLightRowStyle parent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Ina" & _
        "ctive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorS" & _
        "tyle parent=""RecordSelector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=" & _
        """Style6"" /><Style parent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 516, 148</Clie" & _
        "ntRect><BorderSide>0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1Tru" & _
        "eDBGrid.MergeView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style pa" & _
        "rent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent" & _
        "=""Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=" & _
        """Normal"" me=""Selected"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Nor" & _
        "mal"" me=""HighlightRow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""No" & _
        "rmal"" me=""OddRow"" /><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=" & _
        """Normal"" me=""FilterBar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><ve" & _
        "rtSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRe" & _
        "cSelWidth>16</DefaultRecSelWidth><ClientArea>0, 0, 516, 148</ClientArea><PrintPa" & _
        "geHeaderStyle parent="""" me=""Style14"" /><PrintPageFooterStyle parent="""" me=""Style" & _
        "15"" /></Blob>"
        '
        'cmdDeleteSeq
        '
        Me.cmdDeleteSeq.BackColor = System.Drawing.SystemColors.Control
        Me.cmdDeleteSeq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDeleteSeq.ForeColor = System.Drawing.Color.Red
        Me.cmdDeleteSeq.Location = New System.Drawing.Point(152, 168)
        Me.cmdDeleteSeq.Name = "cmdDeleteSeq"
        Me.cmdDeleteSeq.Size = New System.Drawing.Size(216, 24)
        Me.cmdDeleteSeq.TabIndex = 115
        Me.cmdDeleteSeq.Text = "Delete Selected Bucket Sequence"
        '
        'lbl
        '
        Me.lbl.BackColor = System.Drawing.Color.Black
        Me.lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Yellow
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(215, 64)
        Me.lbl.TabIndex = 113
        Me.lbl.Text = "WORK FLOW"
        Me.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdPreviousMaps, Me.cmdDeleteSeq, Me.CheckSameAsSelectedSeq})
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(214, 303)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(770, 200)
        Me.Panel1.TabIndex = 116
        '
        'CheckSameAsSelectedSeq
        '
        Me.CheckSameAsSelectedSeq.ForeColor = System.Drawing.Color.Blue
        Me.CheckSameAsSelectedSeq.Location = New System.Drawing.Point(536, 8)
        Me.CheckSameAsSelectedSeq.Name = "CheckSameAsSelectedSeq"
        Me.CheckSameAsSelectedSeq.Size = New System.Drawing.Size(192, 48)
        Me.CheckSameAsSelectedSeq.TabIndex = 120
        Me.CheckSameAsSelectedSeq.Text = "Make Current Bucket Sequence same as selected sequence"
        '
        'frmProcessFlow
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(992, 525)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1, Me.lbl, Me.pnlFailCodes, Me.PanelPalletList})
        Me.Name = "frmProcessFlow"
        Me.Text = "Define Work Flow"
        Me.PanelPalletList.ResumeLayout(False)
        Me.pnlFailCodes.ResumeLayout(False)
        CType(Me.grdPreviousMaps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub LoadGroups()
        Dim dtBuckets As DataTable
        Dim R1 As DataRow
        Dim objInventory As New PSS.Data.Buisness.Inventory()

        Try
            Me.lstBuckets.DataSource = Nothing

            dtBuckets = objInventory.GetGroups(, 1)

            'lstBuckets
            Me.lstBuckets.DisplayMember = dtBuckets.Columns("Group").ToString
            Me.lstBuckets.ValueMember = dtBuckets.Columns("Group_ID").ToString
            Me.lstBuckets.DataSource = dtBuckets.DefaultView

            Me.lstBuckets.ClearSelected()
            Me.lstBuckets.Refresh()

        Catch ex As Exception
            Throw New Exception("LoadGroups:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtBuckets) Then
                dtBuckets.Dispose()
                dtBuckets = Nothing
            End If

            dtBuckets = Nothing
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub LoadModels()
        Dim dtModels As New DataTable()
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Try
            dtModels = objInventory.GetModels(2, )
            With Me.lstModel
                .DataSource = dtModels.DefaultView
                .DisplayMember = dtModels.Columns("Model").ToString
                .ValueMember = dtModels.Columns("Model_ID").ToString
                '.SelectedValue = 0
            End With

        Catch ex As Exception
            MsgBox("Error in frmWIPReports.LoadModels:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtModels) Then
                dtModels.Dispose()
                dtModels = Nothing
            End If
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub LoadCustomers()
        Dim objMisc As New PSS.Data.Buisness.Misc()
        Dim dtCustomers As DataTable
        Try
            dtCustomers = objMisc.GetCustomers
            With Me.cmbCustomer
                .DataSource = dtCustomers.DefaultView
                .DisplayMember = dtCustomers.Columns("cust_name1").ToString
                .ValueMember = dtCustomers.Columns("Cust_ID").ToString
                .SelectedValue = 0
            End With
        Catch ex As Exception
            MsgBox("Error in frmWIPReports.LoadCustomers:: " & ex.Message.ToString, MsgBoxStyle.Critical)
        Finally
            If Not IsNothing(dtCustomers) Then
                dtCustomers.Dispose()
                dtCustomers = Nothing
            End If
            objMisc = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub LoadAllLines()
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim dtLines As DataTable

        Try
            dtLines = objInventory.GetLines(, 1)
            With Me.cmbLine
                .DataSource = dtLines.DefaultView
                .DisplayMember = dtLines.Columns("Line").ToString
                .ValueMember = dtLines.Columns("Line_ID").ToString
                .SelectedValue = 0
            End With

        Catch ex As Exception
            Throw New Exception("LoadAllLines:: " & ex.Message.ToString)
        Finally
            If Not IsNothing(dtLines) Then
                dtLines.Dispose()
                dtLines = Nothing
            End If
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub cmdUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveUp.Click
        Dim curIndex As Integer
        Dim appCurText As String
        Dim appAuxText As String

        curIndex = lstFlow.SelectedIndex
        If curIndex = -1 Then Exit Sub
        If curIndex = 0 Then Exit Sub 'first item in list, can't move up
        With lstFlow
            appCurText = lstFlow.Items.Item(curIndex)
            appAuxText = lstFlow.Items.Item(curIndex - 1)
            lstFlow.Items.Item(curIndex - 1) = appCurText
            lstFlow.Items.Item(curIndex) = appAuxText
            lstFlow.SelectedIndex = curIndex - 1
        End With

        Me.cmdConditionalPush.Enabled = False
        Me.cmdSaveFlowSeq.Enabled = True
    End Sub

    '***************************************************************************
    Private Sub cmdDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMoveDown.Click
        Dim curIndex As Integer
        Dim appCurText As String
        Dim appAuxText As String

        curIndex = lstFlow.SelectedIndex
        If curIndex = -1 Then Exit Sub
        If curIndex = Me.lstFlow.Items.Count - 1 Then Exit Sub 'last item in list, can't move down
        With lstFlow
            appCurText = lstFlow.Items.Item(curIndex)
            appAuxText = lstFlow.Items.Item(curIndex + 1)
            lstFlow.Items.Item(curIndex + 1) = appCurText
            lstFlow.Items.Item(curIndex) = appAuxText
            lstFlow.SelectedIndex = curIndex + 1
        End With

        Me.cmdConditionalPush.Enabled = False
        Me.cmdSaveFlowSeq.Enabled = True
    End Sub

    '***************************************************************************
    Protected Overrides Sub Finalize()

        'dtFlow = Nothing
        MyBase.Finalize()
    End Sub


    '***************************************************************************
    Private Sub frmProcessFlow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.LoadAllLines()
            Me.LoadCustomers()
            Me.LoadModels()
            Me.LoadGroups()
            Me.PopulateGrid()
            Me.cmbLine.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Loading Form", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************************
    Private Sub cmdAddToList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddToList.Click
        Dim strBucket As String = ""
        Try
            If Me.cmbLine.SelectedValue = 0 Then
                MessageBox.Show("Line is not selected.", "Validate Line", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Customer is not selected.", "Validate Customer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.lstModel.SelectedItems.Count = 0 Then
                MessageBox.Show("Model(s) is not selected.", "Validate Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.lstBuckets.SelectedIndex < 0 Then
                MessageBox.Show("Bucket(s) is not selected.", "Validate Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.chkPush.Checked Then
                strBucket = Trim(Me.lstBuckets.SelectedItem("Group")) & "(PUSH)"
            Else
                strBucket = Trim(Me.lstBuckets.SelectedItem("Group"))
            End If

            RefreshFlowList(1, strBucket)
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Add Item into Flow List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Listbox_ClearSelected(Me.lstBuckets)
        End Try
    End Sub

    '***************************************************************************
    Private Sub cmdRemoveFromList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveFromList.Click

        Try
            RefreshFlowList(0, )
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Remove Item from Flow List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            Listbox_ClearSelected(Me.lstFlow)
        End Try
    End Sub

    '***************************************************************************
    Private Sub RefreshFlowList(ByVal iAddRemove As Integer, _
                                Optional ByVal strDesc As String = "")

        Dim i As Integer = 0
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim strDoesBucketPush As String = ""
        Dim iPos As Integer = 0
        Dim strCurGroup As String = ""
        Dim strNewGroup As String = ""

        Try
            If iAddRemove = 1 Then
                If strDesc = "" Then
                    Exit Sub
                End If
                For i = 0 To Me.lstFlow.Items.Count - 1
                    '*************************
                    strDoesBucketPush = objInventory.DetermineIfBucketPushes(Trim(Me.lstFlow.Items(i)))
                    '*************************
                    If strDoesBucketPush = "PUSH" Then
                        iPos = InStr(Trim(Me.lstFlow.Items(i)), "(")
                        strCurGroup = Microsoft.VisualBasic.Left(Trim(Me.lstFlow.Items(i)), iPos - 1)
                    Else
                        strCurGroup = Trim(Me.lstFlow.Items(i))
                    End If
                    '*************************
                    strDoesBucketPush = objInventory.DetermineIfBucketPushes(Trim(strDesc))
                    '*************************
                    If strDoesBucketPush = "PUSH" Then
                        iPos = InStr(Trim(strDesc), "(")
                        strNewGroup = Microsoft.VisualBasic.Left(Trim(strDesc), iPos - 1)
                    Else
                        strNewGroup = Trim(strDesc)
                    End If

                    If strCurGroup = strNewGroup Then
                        Exit Sub 'exit if item already exist in list
                    End If
                Next i
                Me.lstFlow.Items.Add(strDesc)
            ElseIf iAddRemove = 0 Then
                If Me.lstFlow.SelectedIndex > -1 Then
                    Me.lstFlow.Items.RemoveAt(Me.lstFlow.SelectedIndex)
                    Me.lstFlow.Refresh()
                End If
            End If

            '**************************************
            'Enable/disable 'save flow seq' button
            If Me.lstFlow.Items.Count = 0 Then
                Me.cmdSaveFlowSeq.Enabled = False
            Else
                Me.cmdSaveFlowSeq.Enabled = True
            End If

            Me.cmdConditionalPush.Enabled = False

        Catch ex As Exception
            Throw ex
        Finally
            objInventory = Nothing
        End Try

    End Sub

    '***************************************************************************
    Private Sub cmdAddNewBucket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddNewBucket.Click
        Dim strGroupDesc As String = ""
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim i As Integer = 0
        Dim iPos As Integer = 0

        Try
            strGroupDesc = InputBox("Enter Bucket Name:")
            If strGroupDesc = "" Then
                Exit Sub
            End If

            iPos = InStr(Trim(strGroupDesc), "(")
            If iPos > 0 Then
                MessageBox.Show("'(' is a reserve letter. Please use { instead of (.", "Validate Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            Else
                iPos = InStr(Trim(strGroupDesc), ")")
                If iPos > 0 Then
                    MessageBox.Show("')' is a reserve letter. Please use '}' instead of ')'.", "Validate Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                    Exit Sub
                End If
            End If

            i = objInventory.SaveGroup(strGroupDesc, , )
            Me.LoadGroups()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Add New Bucket", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub cmdDelBucket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDelBucket.Click
        Dim i As Integer
        Dim objInventory As New PSS.Data.Buisness.Inventory()

        Try
            '************************
            If MessageBox.Show("Are you sure you want to delete the selected Bucket " & Me.lstBuckets.SelectedItem("Group") & "?", "Delete Bucket", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            '************************
            i = objInventory.DeleteGroup(Me.lstBuckets.SelectedValue, )
            Me.LoadGroups()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Delete Bucket", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
        End Try
    End Sub


    '***************************************************************************
    Private Sub cmdSaveFlowSeq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSaveFlowSeq.Click
        Dim selecteditem As Object
        Dim i As Integer = 0
        Dim iSaveResult As Integer = 0
        Dim objInventory As New PSS.Data.Buisness.Inventory()

        Try
            '************************
            If MessageBox.Show("Are you sure you want to save this flow sequence?", "Save Flow Sequence", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
            '************************
            'Validate user input
            '************************
            If Me.lstFlow.Items.Count = 0 Then
                MessageBox.Show("Flow Sequence is not defined.", "Validate Flow Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.cmbLine.SelectedValue = 0 Then
                MessageBox.Show("Line is not selected.", "Validate Line", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.cmbCustomer.SelectedValue = 0 Then
                MessageBox.Show("Customer is not selected.", "Validate Customer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            If Me.lstModel.SelectedItems.Count = 0 Then
                MessageBox.Show("Model(s) is not selected.", "Validate Model", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If
            '********************************
            'Save flow sequence into database
            '********************************
            For Each selecteditem In Me.lstModel.SelectedItems
                'strItem = selecteditem("Group_Desc")
                'MsgBox(strItem)
                i += objInventory.SaveFlowSequence(Me.iUserID, Me.cmbLine.SelectedValue, Me.cmbCustomer.SelectedValue, selecteditem("Model_ID"), Me.lstFlow)
            Next

            Me.PopulateGrid()
            Me.ResetControl()
            'MessageBox.Show("'Flow Sequence' is saved.", "Save Flow Sequence", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Save Flow Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub ResetControl()
        Listbox_ClearSelected(Me.lstFlow)
        Listbox_ClearSelected(Me.lstBuckets)
        Listbox_ClearSelected(Me.lstModel)
        Me.cmdSaveFlowSeq.Enabled = False
        Me.cmdConditionalPush.Enabled = False
        Me.cmbLine.SelectedValue = 0
        Me.cmbCustomer.SelectedValue = 0
    End Sub

    '***************************************************************************
    Private Sub Listbox_ClearSelected(ByRef lstListBox As System.Windows.Forms.ListBox)
        Dim i As Integer = 0
        If lstListBox.Items.Count > 0 Then
            'For i = 0 To lstListBox.Items.Count - 1
            lstListBox.ClearSelected()
            'Next i
            lstListBox.Refresh()
        End If
    End Sub

    '***************************************************************************
    Private Sub PopulateGrid()
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim dt1 As DataTable

        Try
            'ClearControls()
            dt1 = objInventory.GetAllWorkFlowSeq()
            Me.grdPreviousMaps.ClearFields()
            Me.grdPreviousMaps.DataSource = Nothing
            Me.grdPreviousMaps.DataSource = dt1.DefaultView

            '********************************
            'disable 'Delete Selected Flow Sequence' 
            ' button if grid is empty
            If dt1.Rows.Count = 0 Then
                Me.cmdDeleteSeq.Enabled = False
            Else
                Me.cmdDeleteSeq.Enabled = True
            End If
            '********************************
            SetFlowSeqGridProperties()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Populate Grid", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
        End Try
    End Sub

    '***************************************************************************
    Private Sub SetFlowSeqGridProperties()
        Dim iNumOfColumns As Integer = Me.grdPreviousMaps.Columns.Count
        Dim i As Integer


        With Me.grdPreviousMaps
            'Heading style (Horizontal Alignment to Center)
            For i = 0 To (iNumOfColumns - 1)
                .Splits(0).DisplayColumns(i).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Next

            'Set individual column data horizontal alignment
            .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            'Set Column Widths
            .Splits(0).DisplayColumns(3).Width = 80
            .Splits(0).DisplayColumns(4).Width = 100
            .Splits(0).DisplayColumns(5).Width = 150

            'Make some columns invisible
            .Splits(0).DisplayColumns(0).Visible = False
            .Splits(0).DisplayColumns(1).Visible = False
            .Splits(0).DisplayColumns(2).Visible = False
        End With
    End Sub

    '***************************************************************************
    Private Sub grdPreviousMaps_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdPreviousMaps.RowColChange
        RefreshFlowList()
    End Sub

    '***************************************************************************
    Private Sub RefreshFlowList()
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim dt1 As DataTable
        Dim R1 As DataRow

        If Me.grdPreviousMaps.RowCount = 0 Then
            Me.ResetControl()
            Me.cmdDeleteSeq.Enabled = False
            Me.cmbLine.Focus()
            Exit Sub
        End If

        If Me.grdPreviousMaps.Columns.Count = 0 Then
            Me.cmdDeleteSeq.Enabled = False
            Me.cmbLine.Focus()
            Exit Sub
        Else
            Me.cmdDeleteSeq.Enabled = True
        End If

        Try
            'Me.cmbLine.SelectedValue = Me.grdPreviousMaps.Columns("line_id").Value
            'Me.cmbCustomer.SelectedValue = Me.grdPreviousMaps.Columns("cust_id").Value
            'Me.Listbox_ClearSeleced(Me.lstModel)
            'Me.lstModel.SelectedValue = Me.grdPreviousMaps.Columns("model_id").Value

            dt1 = objInventory.GetWorkFlowSeq_GroupDesc(Me.grdPreviousMaps.Columns("line_id").Value, _
                                  Me.grdPreviousMaps.Columns("cust_id").Value, _
                                  Me.grdPreviousMaps.Columns("model_id").Value)

            If dt1.Rows.Count > 0 Then
                Me.lstFlow.Items.Clear()

                For Each R1 In dt1.Rows
                    If Trim(R1("LPF_DoesBucketPush")) = "" Then
                        Me.lstFlow.Items.Add(Trim(R1("Group_desc")))
                    Else
                        Me.lstFlow.Items.Add(Trim(R1("Group_desc")) & "(" & Trim(R1("LPF_DoesBucketPush")) & ")")
                    End If

                Next R1

                Me.lstFlow.Refresh()
                'Me.cmdSaveFlowSeq.Enabled = True
            Else
                Me.lstFlow.Items.Clear()
                Me.lstFlow.Refresh()
                'Me.cmdSaveFlowSeq.Enabled = False
            End If

            Me.cmdSaveFlowSeq.Enabled = False
            Me.cmdConditionalPush.Enabled = False
            Me.cmdClearCP.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Populate Flow List", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            If Not IsNothing(dt1) Then
                dt1.Dispose()
                dt1 = Nothing
            End If
            R1 = Nothing
            objInventory = Nothing
        End Try
    End Sub


    '***************************************************************************
    Private Sub cmbLine_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbLine.SelectionChangeCommitted
        Me.cmbCustomer.SelectedValue = 0
        Listbox_ClearSelected(Me.lstModel)
        Listbox_ClearSelected(Me.lstBuckets)
        Me.lstFlow.Items.Clear()
        Me.lstFlow.Refresh()
        Me.cmdSaveFlowSeq.Enabled = False
        Me.cmdConditionalPush.Enabled = False
    End Sub

    '***************************************************************************
    Private Sub cmbCustomer_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCustomer.SelectionChangeCommitted
        Listbox_ClearSelected(Me.lstModel)
        Listbox_ClearSelected(Me.lstBuckets)
        Me.lstFlow.Items.Clear()
        Me.lstFlow.Refresh()
        Me.cmdSaveFlowSeq.Enabled = False
        Me.cmdConditionalPush.Enabled = False
    End Sub

    '***************************************************************************
    Private Sub lstModel_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstModel.SelectedValueChanged
        Listbox_ClearSelected(Me.lstBuckets)
        Me.cmdConditionalPush.Enabled = False
        Me.lstFlow.Items.Clear()
        Me.lstFlow.Refresh()
    End Sub

    '***************************************************************************
    Private Sub lstFlow_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstFlow.SelectedIndexChanged
        Try
            Me.RefreshPushToLabel()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Display Push To Bucket", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    '***************************************************************************
    Private Sub cmdDeleteSeq_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDeleteSeq.Click
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim i As Integer

        If Me.grdPreviousMaps.Columns.Count = 0 Then
            Exit Sub
        End If

        Try
            If MessageBox.Show("Are you sure you want to delete selected work flow sequence?", "Save Flow Sequence", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            i = objInventory.DeleteWorkFlowSeq(Me.grdPreviousMaps.Columns("line_id").Value, _
                                               Me.grdPreviousMaps.Columns("cust_id").Value, _
                                               Me.grdPreviousMaps.Columns("model_id").Value)

            Me.PopulateGrid()

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Delete Work Flow Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
            Me.ResetControl()
        End Try
    End Sub

    '***************************************************************************
    Private Sub cmdConditionalPush_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConditionalPush.Click
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim LPF_id As Integer = 0
        Dim strDoesBucketPush As String = ""
        Dim strGroup As String = ""
        Dim iPos As Integer = 0
        Dim booVar As Boolean = False

        Try
            If Me.lstFlow.Items.Count = 0 Then
                Exit Sub
            End If

            If Me.lstFlow.SelectedIndex < 0 Then
                MessageBox.Show("Please select one item in 'Current Bucket Sequence'.", "Validate Input", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.grdPreviousMaps.Columns("line_id").Value = 0 Or _
               Me.grdPreviousMaps.Columns("cust_id").Value = 0 Or _
               Me.grdPreviousMaps.Columns("model_id").Value = 0 Then
                MessageBox.Show("No Record exist for conditional push.", "Validate Selected Record", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '*************************
            strDoesBucketPush = objInventory.DetermineIfBucketPushes(Trim(Me.lstFlow.SelectedItem))
            '*************************
            If strDoesBucketPush = "PUSH" Then
                iPos = InStr(Trim(Me.lstFlow.SelectedItem), "(")
                strGroup = Microsoft.VisualBasic.Left(Trim(Me.lstFlow.SelectedItem), iPos - 1)
            Else
                MessageBox.Show("This Bucket does not push.", "Check Push Bucket", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'Get LPF_id
            LPF_id = objInventory.GetLPF_ID(Me.grdPreviousMaps.Columns("line_id").Value, _
                                            Me.grdPreviousMaps.Columns("cust_id").Value, _
                                            Me.grdPreviousMaps.Columns("model_id").Value, _
                                            strGroup)

            If LPF_id = 0 Then
                MessageBox.Show("Can not define Line Process Flow ID.", "Get Line Flow Process ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'Display Push To Bucket window
            Dim frmConditionalBucket As New frmConditionalBucket(LPF_id)
            booVar = frmConditionalBucket.ShowDialog()

            If booVar = False Then
                MessageBox.Show("Conditional Bucket was canceled.", "MClaim Data Collection", MessageBoxButtons.OK)
                frmConditionalBucket.Dispose()
                frmConditionalBucket = Nothing
                Exit Sub
            End If

            If Not IsNothing(frmConditionalBucket) Then
                frmConditionalBucket.Dispose()
                frmConditionalBucket = Nothing
            End If

            'refresh Push To Bucket Label
            Me.RefreshPushToLabel()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Delete Work Flow Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub cmdClearCP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClearCP.Click
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim iLPF_id As Integer = 0
        Dim strDoesBucketPush As String = ""
        Dim strGroup As String = ""
        Dim iPos As Integer = 0
        Dim booVar As Boolean = False
        Dim i As Integer = 0

        Try
            If Me.lstFlow.Items.Count = 0 Then
                Exit Sub
            End If

            If Me.lstFlow.SelectedIndex < 0 Then
                MessageBox.Show("Please select one item in 'Current Bucket Sequence'.", "Validate Input", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            If Me.grdPreviousMaps.Columns("line_id").Value = 0 Or _
               Me.grdPreviousMaps.Columns("cust_id").Value = 0 Or _
               Me.grdPreviousMaps.Columns("model_id").Value = 0 Then
                MessageBox.Show("No Record exist for conditional push.", "Validate Selected Record", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            '*************************
            strDoesBucketPush = objInventory.DetermineIfBucketPushes(Trim(Me.lstFlow.SelectedItem))
            '*************************
            If strDoesBucketPush = "PUSH" Then
                iPos = InStr(Trim(Me.lstFlow.SelectedItem), "(")
                strGroup = Microsoft.VisualBasic.Left(Trim(Me.lstFlow.SelectedItem), iPos - 1)
            Else
                MessageBox.Show("This Bucket does not push.", "Check Push Bucket", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'Get LPF_id
            iLPF_id = objInventory.GetLPF_ID(Me.grdPreviousMaps.Columns("line_id").Value, _
                                            Me.grdPreviousMaps.Columns("cust_id").Value, _
                                            Me.grdPreviousMaps.Columns("model_id").Value, _
                                            strGroup)

            If iLPF_id = 0 Then
                MessageBox.Show("Can not define Line Process Flow ID.", "Get Line Flow Process ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'Delete conditional Push
            i = objInventory.DeleteConditionalPush(iLPF_id)

            'refresh Push To Bucket Label
            Me.RefreshPushToLabel()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Delete Work Flow Sequence", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        Finally
            objInventory = Nothing
        End Try
    End Sub

    '***************************************************************************
    Private Sub RefreshPushToLabel()
        Dim objInventory As New PSS.Data.Buisness.Inventory()
        Dim LPF_id As Integer = 0
        Dim strDoesBucketPush As String = ""
        Dim strGroup As String = ""
        Dim iPos As Integer = 0
        Dim strPushTo As String = ""

        Try
            If Me.lstFlow.Items.Count = 0 Then
                Exit Sub
            End If

            If Me.lstFlow.SelectedIndex < 0 Then
                Exit Sub
            End If

            '*************************
            strDoesBucketPush = objInventory.DetermineIfBucketPushes(Trim(Me.lstFlow.SelectedItem))
            '*************************
            If strDoesBucketPush = "PUSH" Then
                iPos = InStr(Trim(Me.lstFlow.SelectedItem), "(")
                strGroup = Microsoft.VisualBasic.Left(Trim(Me.lstFlow.SelectedItem), iPos - 1)
                Me.cmdConditionalPush.Enabled = True
            Else
                Me.lblPushTo.Text = ""
                Me.lblPushTo.Visible = False
                Me.cmdClearCP.Enabled = False
                Me.cmdConditionalPush.Enabled = False
                Exit Sub
            End If

            'Get LPF_id
            LPF_id = objInventory.GetLPF_ID(Me.grdPreviousMaps.Columns("line_id").Value, _
                                            Me.grdPreviousMaps.Columns("cust_id").Value, _
                                            Me.grdPreviousMaps.Columns("model_id").Value, _
                                            strGroup)

            If LPF_id = 0 Then
                MessageBox.Show("Can not define Line Process Flow ID.", "Get Line Flow Process ID", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
                Exit Sub
            End If

            'get conditional push bucket desc
            strPushTo = objInventory.GetCP_BucketDesc(LPF_id)

            If strPushTo <> "" Then
                Me.lblPushTo.Text = strPushTo
                Me.lblPushTo.Visible = True
                Me.cmdConditionalPush.Enabled = True
                Me.cmdClearCP.Enabled = True
            Else
                Me.lblPushTo.Text = ""
                Me.lblPushTo.Visible = False
                Me.cmdClearCP.Enabled = False
            End If

        Catch ex As Exception
            Throw New Exception("RefreshPushToLabel():: " & ex.ToString)
        Finally
            objInventory = Nothing
        End Try
    End Sub




End Class
