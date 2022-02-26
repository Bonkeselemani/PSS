Option Explicit On 

Imports PSS.Data.Buisness
Imports System.Text

Namespace Gui.WingTechATT

    Public Class frmWingTechATT_buildBox
        Inherits System.Windows.Forms.Form

        Private _iMenuCustID As Integer = 0
        Private _strScreenName As String = ""
        Private _strUserName As String = PSS.Core.Global.ApplicationUser.User
        Private _iShiftID As Integer = PSS.Core.Global.ApplicationUser.IDShift
        Private _strWorkDate As String = PSS.Core.Global.ApplicationUser.Workdate
        Private _objWingTechATT As PSS.Data.Buisness.WingTechATT.WingTechATT
        Private _objWingTechATT_BoxShip As PSS.Data.Buisness.WingTechATT.WingTechATT_BoxShip
        Private _iPallett_ID As Integer = 0

#Region " Windows Form Designer generated code "


        Public Sub New(ByVal iCust_ID As Integer, ByVal strScreenName As String)
            MyBase.New()

            'This call is required by the Windows Form Designer.
            InitializeComponent()

            'Add any initialization after the InitializeComponent() call
            Me._iMenuCustID = iCust_ID
            Me._strScreenName = strScreenName

            Me._objWingTechATT = New PSS.Data.Buisness.WingTechATT.WingTechATT()
            Me._objWingTechATT_BoxShip = New PSS.Data.Buisness.WingTechATT.WingTechATT_BoxShip()

        End Sub

        'Form overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                Try
                    Me._objWingTechATT = Nothing
                    Me._objWingTechATT_BoxShip = Nothing
                Catch ex As Exception
                End Try
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
        Friend WithEvents PanelPalletList As System.Windows.Forms.Panel
        Friend WithEvents btnDeleteBox As System.Windows.Forms.Button
        Friend WithEvents dbgPallets As C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Friend WithEvents btnReopenBox As System.Windows.Forms.Button
        Friend WithEvents btnReprintBoxLabel As System.Windows.Forms.Button
        Friend WithEvents lblScreenName As System.Windows.Forms.Label
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblCostCenter As System.Windows.Forms.Label
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents lblWorkDate As System.Windows.Forms.Label
        Friend WithEvents lblShift As System.Windows.Forms.Label
        Friend WithEvents lblMachine As System.Windows.Forms.Label
        Friend WithEvents lblLineSide As System.Windows.Forms.Label
        Friend WithEvents lblGroup As System.Windows.Forms.Label
        Friend WithEvents lblLine As System.Windows.Forms.Label
        Friend WithEvents Button2 As System.Windows.Forms.Button
        Friend WithEvents lblPassed As System.Windows.Forms.Label
        Friend WithEvents pnlShipType As System.Windows.Forms.Panel
        Friend WithEvents rbATT As System.Windows.Forms.RadioButton
        Friend WithEvents rbCricket As System.Windows.Forms.RadioButton
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents cboModel As C1.Win.C1List.C1Combo
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cboBoxTypes As C1.Win.C1List.C1Combo
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents cboLocation As C1.Win.C1List.C1Combo
        Friend WithEvents Button5 As System.Windows.Forms.Button
        Friend WithEvents btnCreateBoxID As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents panelPallet As System.Windows.Forms.Panel
        Friend WithEvents lPO As System.Windows.Forms.Label
        Friend WithEvents lblPO As System.Windows.Forms.Label
        Friend WithEvents lblOEMCustomerClass As System.Windows.Forms.Label
        Friend WithEvents txtDevSN As System.Windows.Forms.TextBox
        Friend WithEvents Label10 As System.Windows.Forms.Label
        Friend WithEvents btnCloseBox As System.Windows.Forms.Button
        Friend WithEvents btnRemoveAllSNs As System.Windows.Forms.Button
        Friend WithEvents btnRemoveSN As System.Windows.Forms.Button
        Friend WithEvents lstDevices As System.Windows.Forms.ListBox
        Friend WithEvents lblCount As System.Windows.Forms.Label
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents lblBoxName As System.Windows.Forms.Label
        Friend WithEvents btnFillBoxWithWHBox As System.Windows.Forms.Button
        Friend WithEvents lblBERReason As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmWingTechATT_buildBox))
            Me.PanelPalletList = New System.Windows.Forms.Panel()
            Me.btnDeleteBox = New System.Windows.Forms.Button()
            Me.dbgPallets = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
            Me.btnReopenBox = New System.Windows.Forms.Button()
            Me.btnReprintBoxLabel = New System.Windows.Forms.Button()
            Me.lblScreenName = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblCostCenter = New System.Windows.Forms.Label()
            Me.lblUserName = New System.Windows.Forms.Label()
            Me.lblWorkDate = New System.Windows.Forms.Label()
            Me.lblShift = New System.Windows.Forms.Label()
            Me.lblMachine = New System.Windows.Forms.Label()
            Me.lblLineSide = New System.Windows.Forms.Label()
            Me.lblGroup = New System.Windows.Forms.Label()
            Me.lblLine = New System.Windows.Forms.Label()
            Me.Button2 = New System.Windows.Forms.Button()
            Me.lblPassed = New System.Windows.Forms.Label()
            Me.pnlShipType = New System.Windows.Forms.Panel()
            Me.rbATT = New System.Windows.Forms.RadioButton()
            Me.rbCricket = New System.Windows.Forms.RadioButton()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.cboModel = New C1.Win.C1List.C1Combo()
            Me.Label4 = New System.Windows.Forms.Label()
            Me.cboBoxTypes = New C1.Win.C1List.C1Combo()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.cboLocation = New C1.Win.C1List.C1Combo()
            Me.Button5 = New System.Windows.Forms.Button()
            Me.btnCreateBoxID = New System.Windows.Forms.Button()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.panelPallet = New System.Windows.Forms.Panel()
            Me.lPO = New System.Windows.Forms.Label()
            Me.lblPO = New System.Windows.Forms.Label()
            Me.lblOEMCustomerClass = New System.Windows.Forms.Label()
            Me.txtDevSN = New System.Windows.Forms.TextBox()
            Me.Label10 = New System.Windows.Forms.Label()
            Me.btnCloseBox = New System.Windows.Forms.Button()
            Me.btnRemoveAllSNs = New System.Windows.Forms.Button()
            Me.btnRemoveSN = New System.Windows.Forms.Button()
            Me.lstDevices = New System.Windows.Forms.ListBox()
            Me.lblCount = New System.Windows.Forms.Label()
            Me.Label3 = New System.Windows.Forms.Label()
            Me.lblBoxName = New System.Windows.Forms.Label()
            Me.btnFillBoxWithWHBox = New System.Windows.Forms.Button()
            Me.lblBERReason = New System.Windows.Forms.Label()
            Me.PanelPalletList.SuspendLayout()
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.Panel2.SuspendLayout()
            Me.pnlShipType.SuspendLayout()
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelPallet.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelPalletList
            '
            Me.PanelPalletList.BackColor = System.Drawing.Color.SteelBlue
            Me.PanelPalletList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PanelPalletList.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDeleteBox, Me.dbgPallets, Me.btnReopenBox, Me.btnReprintBoxLabel})
            Me.PanelPalletList.Location = New System.Drawing.Point(11, 235)
            Me.PanelPalletList.Name = "PanelPalletList"
            Me.PanelPalletList.Size = New System.Drawing.Size(421, 344)
            Me.PanelPalletList.TabIndex = 133
            '
            'btnDeleteBox
            '
            Me.btnDeleteBox.BackColor = System.Drawing.Color.Red
            Me.btnDeleteBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnDeleteBox.ForeColor = System.Drawing.Color.White
            Me.btnDeleteBox.Location = New System.Drawing.Point(240, 240)
            Me.btnDeleteBox.Name = "btnDeleteBox"
            Me.btnDeleteBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnDeleteBox.Size = New System.Drawing.Size(168, 32)
            Me.btnDeleteBox.TabIndex = 2
            Me.btnDeleteBox.Text = "DELETE EMPTY BOX"
            '
            'dbgPallets
            '
            Me.dbgPallets.AllowColMove = False
            Me.dbgPallets.AllowColSelect = False
            Me.dbgPallets.AllowFilter = False
            Me.dbgPallets.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
            Me.dbgPallets.AllowSort = False
            Me.dbgPallets.AllowUpdate = False
            Me.dbgPallets.AllowUpdateOnBlur = False
            Me.dbgPallets.CaptionHeight = 19
            Me.dbgPallets.CollapseColor = System.Drawing.Color.White
            Me.dbgPallets.ExpandColor = System.Drawing.Color.White
            Me.dbgPallets.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.dbgPallets.ForeColor = System.Drawing.Color.White
            Me.dbgPallets.GroupByCaption = "Drag a column header here to group by that column"
            Me.dbgPallets.Images.Add(CType(resources.GetObject("resource.Images"), System.Drawing.Bitmap))
            Me.dbgPallets.Location = New System.Drawing.Point(8, 9)
            Me.dbgPallets.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
            Me.dbgPallets.Name = "dbgPallets"
            Me.dbgPallets.PreviewInfo.Location = New System.Drawing.Point(0, 0)
            Me.dbgPallets.PreviewInfo.Size = New System.Drawing.Size(0, 0)
            Me.dbgPallets.PreviewInfo.ZoomFactor = 75
            Me.dbgPallets.RowHeight = 20
            Me.dbgPallets.Size = New System.Drawing.Size(400, 223)
            Me.dbgPallets.TabIndex = 0
            Me.dbgPallets.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1TrueDBGrid.Design.ContextWrappe" & _
            "r""><Data>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}E" & _
            "ditor{}Style2{}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:SteelBlue;}Sele" & _
            "cted{ForeColor:HighlightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:Whi" & _
            "te;BackColor:InactiveCaption;}FilterBar{}Footer{}Caption{AlignHorz:Center;ForeCo" & _
            "lor:White;}Style1{}Normal{Font:Microsoft Sans Serif, 8.25pt, style=Bold;AlignVer" & _
            "t:Center;ForeColor:White;BackColor:LightSteelBlue;}HighlightRow{ForeColor:Highli" & _
            "ghtText;BackColor:Highlight;}Style14{}OddRow{BackColor:Teal;}RecordSelector{Fore" & _
            "Color:White;AlignImage:Center;}Style15{}Heading{Wrap:True;Font:Microsoft Sans Se" & _
            "rif, 8.25pt, style=Bold;AlignHorz:Center;BackColor:Control;Border:Raised,,1, 1, " & _
            "1, 1;ForeColor:Blue;AlignVert:Center;}Style8{}Style10{AlignHorz:Near;}Style11{}S" & _
            "tyle12{}Style13{}Style16{}Style17{}Style9{}</Data></Styles><Splits><C1.Win.C1Tru" & _
            "eDBGrid.MergeView AllowColMove=""False"" AllowColSelect=""False"" Name="""" AllowRowSi" & _
            "zing=""None"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight=""17"" " & _
            "MarqueeStyle=""DottedCellBorder"" RecordSelectorWidth=""17"" DefRecSelWidth=""17"" Ver" & _
            "ticalScrollGroup=""1"" HorizontalScrollGroup=""1""><Height>219</Height><CaptionStyle" & _
            " parent=""Style2"" me=""Style10"" /><EditorStyle parent=""Editor"" me=""Style5"" /><Even" & _
            "RowStyle parent=""EvenRow"" me=""Style8"" /><FilterBarStyle parent=""FilterBar"" me=""S" & _
            "tyle13"" /><FooterStyle parent=""Footer"" me=""Style3"" /><GroupStyle parent=""Group"" " & _
            "me=""Style12"" /><HeadingStyle parent=""Heading"" me=""Style2"" /><HighLightRowStyle p" & _
            "arent=""HighlightRow"" me=""Style7"" /><InactiveStyle parent=""Inactive"" me=""Style4"" " & _
            "/><OddRowStyle parent=""OddRow"" me=""Style9"" /><RecordSelectorStyle parent=""Record" & _
            "Selector"" me=""Style11"" /><SelectedStyle parent=""Selected"" me=""Style6"" /><Style p" & _
            "arent=""Normal"" me=""Style1"" /><ClientRect>0, 0, 396, 219</ClientRect><BorderSide>" & _
            "0</BorderSide><BorderStyle>Sunken</BorderStyle></C1.Win.C1TrueDBGrid.MergeView><" & _
            "/Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style parent=""Normal"" me=""H" & _
            "eading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=""Heading"" me=""Capt" & _
            "ion"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""Normal"" me=""Select" & _
            "ed"" /><Style parent=""Normal"" me=""Editor"" /><Style parent=""Normal"" me=""HighlightR" & _
            "ow"" /><Style parent=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /" & _
            "><Style parent=""Heading"" me=""RecordSelector"" /><Style parent=""Normal"" me=""Filter" & _
            "Bar"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><vertSplits>1</vertSpl" & _
            "its><horzSplits>1</horzSplits><Layout>None</Layout><DefaultRecSelWidth>17</Defau" & _
            "ltRecSelWidth><ClientArea>0, 0, 396, 219</ClientArea><PrintPageHeaderStyle paren" & _
            "t="""" me=""Style16"" /><PrintPageFooterStyle parent="""" me=""Style17"" /></Blob>"
            '
            'btnReopenBox
            '
            Me.btnReopenBox.BackColor = System.Drawing.Color.Green
            Me.btnReopenBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReopenBox.ForeColor = System.Drawing.Color.White
            Me.btnReopenBox.Location = New System.Drawing.Point(8, 240)
            Me.btnReopenBox.Name = "btnReopenBox"
            Me.btnReopenBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReopenBox.Size = New System.Drawing.Size(168, 32)
            Me.btnReopenBox.TabIndex = 1
            Me.btnReopenBox.Text = "REOPEN  BOX"
            '
            'btnReprintBoxLabel
            '
            Me.btnReprintBoxLabel.BackColor = System.Drawing.Color.LightSteelBlue
            Me.btnReprintBoxLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReprintBoxLabel.ForeColor = System.Drawing.Color.Black
            Me.btnReprintBoxLabel.Location = New System.Drawing.Point(8, 288)
            Me.btnReprintBoxLabel.Name = "btnReprintBoxLabel"
            Me.btnReprintBoxLabel.Size = New System.Drawing.Size(168, 31)
            Me.btnReprintBoxLabel.TabIndex = 3
            Me.btnReprintBoxLabel.Text = "REPRINT BOX LABEL"
            '
            'lblScreenName
            '
            Me.lblScreenName.BackColor = System.Drawing.Color.Black
            Me.lblScreenName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblScreenName.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblScreenName.ForeColor = System.Drawing.Color.Yellow
            Me.lblScreenName.Location = New System.Drawing.Point(11, 3)
            Me.lblScreenName.Name = "lblScreenName"
            Me.lblScreenName.Size = New System.Drawing.Size(221, 79)
            Me.lblScreenName.TabIndex = 135
            Me.lblScreenName.Text = "WingTechATT BUILD SHIP BOX"
            Me.lblScreenName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.Black
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCostCenter, Me.lblUserName, Me.lblWorkDate, Me.lblShift, Me.lblMachine, Me.lblLineSide, Me.lblGroup, Me.lblLine, Me.Button2, Me.lblPassed})
            Me.Panel2.Location = New System.Drawing.Point(235, 3)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(602, 80)
            Me.Panel2.TabIndex = 136
            '
            'lblCostCenter
            '
            Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCostCenter.ForeColor = System.Drawing.Color.Lime
            Me.lblCostCenter.Location = New System.Drawing.Point(418, 6)
            Me.lblCostCenter.Name = "lblCostCenter"
            Me.lblCostCenter.Size = New System.Drawing.Size(168, 22)
            Me.lblCostCenter.TabIndex = 101
            Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblUserName
            '
            Me.lblUserName.BackColor = System.Drawing.Color.Transparent
            Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblUserName.ForeColor = System.Drawing.Color.Lime
            Me.lblUserName.Location = New System.Drawing.Point(232, 7)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(184, 22)
            Me.lblUserName.TabIndex = 100
            Me.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblWorkDate
            '
            Me.lblWorkDate.BackColor = System.Drawing.Color.Transparent
            Me.lblWorkDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblWorkDate.ForeColor = System.Drawing.Color.Lime
            Me.lblWorkDate.Location = New System.Drawing.Point(232, 28)
            Me.lblWorkDate.Name = "lblWorkDate"
            Me.lblWorkDate.Size = New System.Drawing.Size(184, 21)
            Me.lblWorkDate.TabIndex = 99
            Me.lblWorkDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblShift
            '
            Me.lblShift.BackColor = System.Drawing.Color.Transparent
            Me.lblShift.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblShift.ForeColor = System.Drawing.Color.Lime
            Me.lblShift.Location = New System.Drawing.Point(232, 48)
            Me.lblShift.Name = "lblShift"
            Me.lblShift.Size = New System.Drawing.Size(184, 22)
            Me.lblShift.TabIndex = 98
            Me.lblShift.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblMachine
            '
            Me.lblMachine.BackColor = System.Drawing.Color.Transparent
            Me.lblMachine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblMachine.ForeColor = System.Drawing.Color.Lime
            Me.lblMachine.Location = New System.Drawing.Point(6, 48)
            Me.lblMachine.Name = "lblMachine"
            Me.lblMachine.Size = New System.Drawing.Size(221, 22)
            Me.lblMachine.TabIndex = 97
            Me.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLineSide
            '
            Me.lblLineSide.BackColor = System.Drawing.Color.Transparent
            Me.lblLineSide.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLineSide.ForeColor = System.Drawing.Color.Lime
            Me.lblLineSide.Location = New System.Drawing.Point(90, 28)
            Me.lblLineSide.Name = "lblLineSide"
            Me.lblLineSide.Size = New System.Drawing.Size(134, 21)
            Me.lblLineSide.TabIndex = 96
            Me.lblLineSide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblGroup
            '
            Me.lblGroup.BackColor = System.Drawing.Color.Transparent
            Me.lblGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblGroup.ForeColor = System.Drawing.Color.Lime
            Me.lblGroup.Location = New System.Drawing.Point(6, 7)
            Me.lblGroup.Name = "lblGroup"
            Me.lblGroup.Size = New System.Drawing.Size(221, 22)
            Me.lblGroup.TabIndex = 95
            Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblLine
            '
            Me.lblLine.BackColor = System.Drawing.Color.Transparent
            Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblLine.ForeColor = System.Drawing.Color.Lime
            Me.lblLine.Location = New System.Drawing.Point(6, 28)
            Me.lblLine.Name = "lblLine"
            Me.lblLine.Size = New System.Drawing.Size(77, 21)
            Me.lblLine.TabIndex = 94
            Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'Button2
            '
            Me.Button2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button2.Location = New System.Drawing.Point(196, 334)
            Me.Button2.Name = "Button2"
            Me.Button2.Size = New System.Drawing.Size(274, 44)
            Me.Button2.TabIndex = 66
            Me.Button2.TabStop = False
            Me.Button2.Text = "Generate Report"
            '
            'lblPassed
            '
            Me.lblPassed.BackColor = System.Drawing.Color.Black
            Me.lblPassed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblPassed.ForeColor = System.Drawing.Color.Lime
            Me.lblPassed.Location = New System.Drawing.Point(418, 37)
            Me.lblPassed.Name = "lblPassed"
            Me.lblPassed.Size = New System.Drawing.Size(168, 32)
            Me.lblPassed.TabIndex = 84
            Me.lblPassed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'pnlShipType
            '
            Me.pnlShipType.BackColor = System.Drawing.Color.SteelBlue
            Me.pnlShipType.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.pnlShipType.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbATT, Me.rbCricket, Me.btnReset, Me.cboModel, Me.Label4, Me.cboBoxTypes, Me.Label2, Me.cboLocation, Me.Button5, Me.btnCreateBoxID, Me.Label1})
            Me.pnlShipType.Location = New System.Drawing.Point(11, 83)
            Me.pnlShipType.Name = "pnlShipType"
            Me.pnlShipType.Size = New System.Drawing.Size(421, 152)
            Me.pnlShipType.TabIndex = 132
            '
            'rbATT
            '
            Me.rbATT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbATT.ForeColor = System.Drawing.Color.White
            Me.rbATT.Location = New System.Drawing.Point(192, 8)
            Me.rbATT.Name = "rbATT"
            Me.rbATT.Size = New System.Drawing.Size(136, 24)
            Me.rbATT.TabIndex = 92
            Me.rbATT.Text = "ATT Fedex and CTDI"
            '
            'rbCricket
            '
            Me.rbCricket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rbCricket.ForeColor = System.Drawing.Color.White
            Me.rbCricket.Location = New System.Drawing.Point(88, 8)
            Me.rbCricket.Name = "rbCricket"
            Me.rbCricket.TabIndex = 91
            Me.rbCricket.Text = "CRICKET"
            '
            'btnReset
            '
            Me.btnReset.BackColor = System.Drawing.Color.MediumBlue
            Me.btnReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnReset.ForeColor = System.Drawing.Color.White
            Me.btnReset.Location = New System.Drawing.Point(8, 104)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnReset.Size = New System.Drawing.Size(64, 32)
            Me.btnReset.TabIndex = 90
            Me.btnReset.Text = "Reset"
            Me.btnReset.Visible = False
            '
            'cboModel
            '
            Me.cboModel.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboModel.Caption = ""
            Me.cboModel.CaptionHeight = 17
            Me.cboModel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboModel.ColumnCaptionHeight = 17
            Me.cboModel.ColumnFooterHeight = 17
            Me.cboModel.ContentHeight = 15
            Me.cboModel.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboModel.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboModel.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboModel.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboModel.EditorHeight = 15
            Me.cboModel.Images.Add(CType(resources.GetObject("resource.Images1"), System.Drawing.Bitmap))
            Me.cboModel.ItemHeight = 15
            Me.cboModel.Location = New System.Drawing.Point(88, 40)
            Me.cboModel.MatchEntryTimeout = CType(2000, Long)
            Me.cboModel.MaxDropDownItems = CType(5, Short)
            Me.cboModel.MaxLength = 32767
            Me.cboModel.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboModel.Name = "cboModel"
            Me.cboModel.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboModel.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboModel.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboModel.Size = New System.Drawing.Size(240, 21)
            Me.cboModel.TabIndex = 88
            Me.cboModel.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label4
            '
            Me.Label4.BackColor = System.Drawing.Color.Transparent
            Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label4.ForeColor = System.Drawing.Color.White
            Me.Label4.Location = New System.Drawing.Point(8, 40)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(72, 21)
            Me.Label4.TabIndex = 89
            Me.Label4.Text = "Model:"
            Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboBoxTypes
            '
            Me.cboBoxTypes.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboBoxTypes.Caption = ""
            Me.cboBoxTypes.CaptionHeight = 17
            Me.cboBoxTypes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboBoxTypes.ColumnCaptionHeight = 17
            Me.cboBoxTypes.ColumnFooterHeight = 17
            Me.cboBoxTypes.ContentHeight = 15
            Me.cboBoxTypes.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboBoxTypes.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboBoxTypes.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboBoxTypes.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboBoxTypes.EditorHeight = 15
            Me.cboBoxTypes.Images.Add(CType(resources.GetObject("resource.Images2"), System.Drawing.Bitmap))
            Me.cboBoxTypes.ItemHeight = 15
            Me.cboBoxTypes.Location = New System.Drawing.Point(88, 72)
            Me.cboBoxTypes.MatchEntryTimeout = CType(2000, Long)
            Me.cboBoxTypes.MaxDropDownItems = CType(5, Short)
            Me.cboBoxTypes.MaxLength = 32767
            Me.cboBoxTypes.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboBoxTypes.Name = "cboBoxTypes"
            Me.cboBoxTypes.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboBoxTypes.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboBoxTypes.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboBoxTypes.Size = New System.Drawing.Size(240, 21)
            Me.cboBoxTypes.TabIndex = 1
            Me.cboBoxTypes.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{BackColor:ControlDark;Border:None,,0, 0, 0, 0;AlignVert:Center;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style9{AlignHorz:Near;}OddRow{}Reco" & _
            "rdSelector{AlignImage:Center;}Heading{Wrap:True;AlignVert:Center;Border:Raised,," & _
            "1, 1, 1, 1;ForeColor:ControlText;BackColor:Control;}Style8{}Style10{}Style11{}St" & _
            "yle1{}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.Transparent
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.ForeColor = System.Drawing.Color.White
            Me.Label2.Location = New System.Drawing.Point(8, 72)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(72, 23)
            Me.Label2.TabIndex = 87
            Me.Label2.Text = "Box Type:"
            Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cboLocation
            '
            Me.cboLocation.AddItemSeparator = Microsoft.VisualBasic.ChrW(59)
            Me.cboLocation.Caption = ""
            Me.cboLocation.CaptionHeight = 17
            Me.cboLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
            Me.cboLocation.ColumnCaptionHeight = 17
            Me.cboLocation.ColumnFooterHeight = 17
            Me.cboLocation.ContentHeight = 15
            Me.cboLocation.DeadAreaBackColor = System.Drawing.Color.Empty
            Me.cboLocation.EditorBackColor = System.Drawing.SystemColors.Window
            Me.cboLocation.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cboLocation.EditorForeColor = System.Drawing.SystemColors.WindowText
            Me.cboLocation.EditorHeight = 15
            Me.cboLocation.Images.Add(CType(resources.GetObject("resource.Images3"), System.Drawing.Bitmap))
            Me.cboLocation.ItemHeight = 15
            Me.cboLocation.Location = New System.Drawing.Point(336, 8)
            Me.cboLocation.MatchEntryTimeout = CType(2000, Long)
            Me.cboLocation.MaxDropDownItems = CType(5, Short)
            Me.cboLocation.MaxLength = 32767
            Me.cboLocation.MouseCursor = System.Windows.Forms.Cursors.Default
            Me.cboLocation.Name = "cboLocation"
            Me.cboLocation.RowDivider.Color = System.Drawing.Color.DarkGray
            Me.cboLocation.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
            Me.cboLocation.RowSubDividerColor = System.Drawing.Color.DarkGray
            Me.cboLocation.Size = New System.Drawing.Size(64, 21)
            Me.cboLocation.TabIndex = 0
            Me.cboLocation.Visible = False
            Me.cboLocation.PropBag = "<?xml version=""1.0""?><Blob><Styles type=""C1.Win.C1List.Design.ContextWrapper""><Da" & _
            "ta>Group{AlignVert:Center;Border:None,,0, 0, 0, 0;BackColor:ControlDark;}Style2{" & _
            "}Style5{}Style4{}Style7{}Style6{}EvenRow{BackColor:Aqua;}Selected{ForeColor:High" & _
            "lightText;BackColor:Highlight;}Style3{}Inactive{ForeColor:InactiveCaptionText;Ba" & _
            "ckColor:InactiveCaption;}Footer{}Caption{AlignHorz:Center;}Normal{}HighlightRow{" & _
            "ForeColor:HighlightText;BackColor:Highlight;}Style1{}OddRow{}RecordSelector{Alig" & _
            "nImage:Center;}Heading{Wrap:True;BackColor:Control;Border:Raised,,1, 1, 1, 1;For" & _
            "eColor:ControlText;AlignVert:Center;}Style8{}Style10{}Style11{}Style9{AlignHorz:" & _
            "Near;}</Data></Styles><Splits><C1.Win.C1List.ListBoxView AllowColSelect=""False"" " & _
            "Name=""Split[0,0]"" CaptionHeight=""17"" ColumnCaptionHeight=""17"" ColumnFooterHeight" & _
            "=""17"" VerticalScrollGroup=""1"" HorizontalScrollGroup=""1""><ClientRect>0, 0, 116, 1" & _
            "56</ClientRect><Height>156</Height><VScrollBar><Width>16</Width></VScrollBar><HS" & _
            "crollBar><Height>16</Height></HScrollBar><CaptionStyle parent=""Style2"" me=""Style" & _
            "9"" /><EvenRowStyle parent=""EvenRow"" me=""Style7"" /><FooterStyle parent=""Footer"" m" & _
            "e=""Style3"" /><GroupStyle parent=""Group"" me=""Style11"" /><HeadingStyle parent=""Hea" & _
            "ding"" me=""Style2"" /><HighLightRowStyle parent=""HighlightRow"" me=""Style6"" /><Inac" & _
            "tiveStyle parent=""Inactive"" me=""Style4"" /><OddRowStyle parent=""OddRow"" me=""Style" & _
            "8"" /><RecordSelectorStyle parent=""RecordSelector"" me=""Style10"" /><SelectedStyle " & _
            "parent=""Selected"" me=""Style5"" /><Style parent=""Normal"" me=""Style1"" /></C1.Win.C1" & _
            "List.ListBoxView></Splits><NamedStyles><Style parent="""" me=""Normal"" /><Style par" & _
            "ent=""Normal"" me=""Heading"" /><Style parent=""Heading"" me=""Footer"" /><Style parent=" & _
            """Heading"" me=""Caption"" /><Style parent=""Heading"" me=""Inactive"" /><Style parent=""" & _
            "Normal"" me=""Selected"" /><Style parent=""Normal"" me=""HighlightRow"" /><Style parent" & _
            "=""Normal"" me=""EvenRow"" /><Style parent=""Normal"" me=""OddRow"" /><Style parent=""Hea" & _
            "ding"" me=""RecordSelector"" /><Style parent=""Caption"" me=""Group"" /></NamedStyles><" & _
            "vertSplits>1</vertSplits><horzSplits>1</horzSplits><Layout>Modified</Layout><Def" & _
            "aultRecSelWidth>17</DefaultRecSelWidth></Blob>"
            '
            'Button5
            '
            Me.Button5.BackColor = System.Drawing.Color.Black
            Me.Button5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Button5.Location = New System.Drawing.Point(985, 274)
            Me.Button5.Name = "Button5"
            Me.Button5.Size = New System.Drawing.Size(410, 409)
            Me.Button5.TabIndex = 66
            Me.Button5.TabStop = False
            Me.Button5.Text = "Generate Report"
            '
            'btnCreateBoxID
            '
            Me.btnCreateBoxID.BackColor = System.Drawing.Color.Green
            Me.btnCreateBoxID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCreateBoxID.ForeColor = System.Drawing.Color.White
            Me.btnCreateBoxID.Location = New System.Drawing.Point(88, 104)
            Me.btnCreateBoxID.Name = "btnCreateBoxID"
            Me.btnCreateBoxID.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCreateBoxID.Size = New System.Drawing.Size(240, 32)
            Me.btnCreateBoxID.TabIndex = 3
            Me.btnCreateBoxID.Text = "CREATE BOX ID"
            Me.btnCreateBoxID.Visible = False
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.Transparent
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.White
            Me.Label1.Location = New System.Drawing.Point(8, 10)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(72, 21)
            Me.Label1.TabIndex = 85
            Me.Label1.Text = "Location:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'panelPallet
            '
            Me.panelPallet.BackColor = System.Drawing.Color.SteelBlue
            Me.panelPallet.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.panelPallet.Controls.AddRange(New System.Windows.Forms.Control() {Me.lPO, Me.lblPO, Me.lblOEMCustomerClass, Me.txtDevSN, Me.Label10, Me.btnCloseBox, Me.btnRemoveAllSNs, Me.btnRemoveSN, Me.lstDevices, Me.lblCount, Me.Label3, Me.lblBoxName, Me.btnFillBoxWithWHBox, Me.lblBERReason})
            Me.panelPallet.Location = New System.Drawing.Point(435, 83)
            Me.panelPallet.Name = "panelPallet"
            Me.panelPallet.Size = New System.Drawing.Size(400, 496)
            Me.panelPallet.TabIndex = 134
            Me.panelPallet.Visible = False
            '
            'lPO
            '
            Me.lPO.Location = New System.Drawing.Point(192, 88)
            Me.lPO.Name = "lPO"
            Me.lPO.Size = New System.Drawing.Size(184, 24)
            Me.lPO.TabIndex = 104
            '
            'lblPO
            '
            Me.lblPO.Location = New System.Drawing.Point(192, 48)
            Me.lblPO.Name = "lblPO"
            Me.lblPO.Size = New System.Drawing.Size(184, 23)
            Me.lblPO.TabIndex = 103
            '
            'lblOEMCustomerClass
            '
            Me.lblOEMCustomerClass.BackColor = System.Drawing.Color.Transparent
            Me.lblOEMCustomerClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblOEMCustomerClass.ForeColor = System.Drawing.Color.Black
            Me.lblOEMCustomerClass.Location = New System.Drawing.Point(200, 48)
            Me.lblOEMCustomerClass.Name = "lblOEMCustomerClass"
            Me.lblOEMCustomerClass.Size = New System.Drawing.Size(192, 16)
            Me.lblOEMCustomerClass.TabIndex = 101
            Me.lblOEMCustomerClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtDevSN
            '
            Me.txtDevSN.Location = New System.Drawing.Point(8, 64)
            Me.txtDevSN.Name = "txtDevSN"
            Me.txtDevSN.Size = New System.Drawing.Size(176, 20)
            Me.txtDevSN.TabIndex = 0
            Me.txtDevSN.Text = ""
            '
            'Label10
            '
            Me.Label10.BackColor = System.Drawing.Color.Transparent
            Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label10.ForeColor = System.Drawing.Color.White
            Me.Label10.Location = New System.Drawing.Point(8, 48)
            Me.Label10.Name = "Label10"
            Me.Label10.Size = New System.Drawing.Size(176, 16)
            Me.Label10.TabIndex = 99
            Me.Label10.Text = "Serial Number:"
            Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'btnCloseBox
            '
            Me.btnCloseBox.BackColor = System.Drawing.Color.Green
            Me.btnCloseBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCloseBox.ForeColor = System.Drawing.Color.White
            Me.btnCloseBox.Location = New System.Drawing.Point(200, 392)
            Me.btnCloseBox.Name = "btnCloseBox"
            Me.btnCloseBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnCloseBox.Size = New System.Drawing.Size(152, 30)
            Me.btnCloseBox.TabIndex = 2
            Me.btnCloseBox.Text = "CLOSE BOX"
            '
            'btnRemoveAllSNs
            '
            Me.btnRemoveAllSNs.BackColor = System.Drawing.Color.Red
            Me.btnRemoveAllSNs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveAllSNs.ForeColor = System.Drawing.Color.White
            Me.btnRemoveAllSNs.Location = New System.Drawing.Point(200, 264)
            Me.btnRemoveAllSNs.Name = "btnRemoveAllSNs"
            Me.btnRemoveAllSNs.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveAllSNs.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveAllSNs.TabIndex = 4
            Me.btnRemoveAllSNs.Text = "REMOVE ALL SNs"
            '
            'btnRemoveSN
            '
            Me.btnRemoveSN.BackColor = System.Drawing.Color.Red
            Me.btnRemoveSN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnRemoveSN.ForeColor = System.Drawing.Color.White
            Me.btnRemoveSN.Location = New System.Drawing.Point(200, 208)
            Me.btnRemoveSN.Name = "btnRemoveSN"
            Me.btnRemoveSN.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnRemoveSN.Size = New System.Drawing.Size(152, 30)
            Me.btnRemoveSN.TabIndex = 3
            Me.btnRemoveSN.Text = "REMOVE SN"
            '
            'lstDevices
            '
            Me.lstDevices.Location = New System.Drawing.Point(8, 88)
            Me.lstDevices.Name = "lstDevices"
            Me.lstDevices.Size = New System.Drawing.Size(176, 342)
            Me.lstDevices.TabIndex = 1
            '
            'lblCount
            '
            Me.lblCount.BackColor = System.Drawing.Color.Black
            Me.lblCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblCount.ForeColor = System.Drawing.Color.Lime
            Me.lblCount.Location = New System.Drawing.Point(232, 136)
            Me.lblCount.Name = "lblCount"
            Me.lblCount.Size = New System.Drawing.Size(96, 43)
            Me.lblCount.TabIndex = 97
            Me.lblCount.Text = "0"
            Me.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.Transparent
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.White
            Me.Label3.Location = New System.Drawing.Point(232, 120)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(96, 16)
            Me.Label3.TabIndex = 96
            Me.Label3.Text = "Box Count"
            Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblBoxName
            '
            Me.lblBoxName.BackColor = System.Drawing.Color.Black
            Me.lblBoxName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBoxName.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBoxName.ForeColor = System.Drawing.Color.Lime
            Me.lblBoxName.Location = New System.Drawing.Point(8, 7)
            Me.lblBoxName.Name = "lblBoxName"
            Me.lblBoxName.Size = New System.Drawing.Size(384, 33)
            Me.lblBoxName.TabIndex = 98
            Me.lblBoxName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnFillBoxWithWHBox
            '
            Me.btnFillBoxWithWHBox.BackColor = System.Drawing.Color.DarkOliveGreen
            Me.btnFillBoxWithWHBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnFillBoxWithWHBox.ForeColor = System.Drawing.Color.White
            Me.btnFillBoxWithWHBox.Location = New System.Drawing.Point(200, 312)
            Me.btnFillBoxWithWHBox.Name = "btnFillBoxWithWHBox"
            Me.btnFillBoxWithWHBox.RightToLeft = System.Windows.Forms.RightToLeft.No
            Me.btnFillBoxWithWHBox.Size = New System.Drawing.Size(152, 40)
            Me.btnFillBoxWithWHBox.TabIndex = 100
            Me.btnFillBoxWithWHBox.Text = "Fill Ship Box With Warehouse Box"
            Me.btnFillBoxWithWHBox.Visible = False
            '
            'lblBERReason
            '
            Me.lblBERReason.BackColor = System.Drawing.Color.Black
            Me.lblBERReason.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.lblBERReason.Font = New System.Drawing.Font("Verdana", 8.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblBERReason.ForeColor = System.Drawing.Color.Yellow
            Me.lblBERReason.Location = New System.Drawing.Point(192, 152)
            Me.lblBERReason.Name = "lblBERReason"
            Me.lblBERReason.Size = New System.Drawing.Size(10, 5)
            Me.lblBERReason.TabIndex = 99
            Me.lblBERReason.Text = "RUR - Invalid/Out of Date Proof of Purchase"
            Me.lblBERReason.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            Me.lblBERReason.Visible = False
            '
            'frmWingTechATT_buildBox
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(848, 582)
            Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PanelPalletList, Me.lblScreenName, Me.Panel2, Me.pnlShipType, Me.panelPallet})
            Me.Name = "frmWingTechATT_buildBox"
            Me.Text = "frmWingTechATT_buildBox"
            Me.PanelPalletList.ResumeLayout(False)
            CType(Me.dbgPallets, System.ComponentModel.ISupportInitialize).EndInit()
            Me.Panel2.ResumeLayout(False)
            Me.pnlShipType.ResumeLayout(False)
            CType(Me.cboModel, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboBoxTypes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.cboLocation, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelPallet.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private Sub frmWingTechATT_buildBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim iCount As Integer
            Dim dtLoc As DataTable
            Dim dtModel As DataTable
            Dim dtType As DataTable
            Dim iLoc_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim iType_ID As Integer = 0

            Try
                dtLoc = Me._objWingTechATT_BoxShip.GetWingTechATTLocations(Me._iMenuCustID, True)

                Misc.PopulateC1DropDownList(Me.cboLocation, dtLoc, "Loc_Name", "Loc_ID")
                If dtLoc.Rows.Count = 2 Then
                    iLoc_ID = dtLoc.Rows(0).Item("Loc_ID")
                    Me.cboLocation.SelectedValue = iLoc_ID
                Else
                    'Me.cboLocation.SeleFctedValue = 0
                End If
                rbCricket.Checked = True
                dtModel = Me._objWingTechATT_BoxShip.GetWingTechATTModels(Me._iMenuCustID, True)
                Misc.PopulateC1DropDownList(Me.cboModel, dtModel, "Model_Desc", "Model_ID")
                If dtModel.Rows.Count = 2 Then
                    iModel_ID = dtModel.Rows(0).Item("model_ID")
                    Me.cboModel.SelectedValue = iModel_ID
                Else
                    Me.cboModel.SelectedValue = 0
                End If

                dtType = Me._objWingTechATT_BoxShip.GetWingTechATTShipBoxTypes(True)
                Misc.PopulateC1DropDownList(Me.cboBoxTypes, dtType, "ShipTypeSDesc", "ShipTypeID")
                If dtModel.Rows.Count = 2 Then
                    iType_ID = dtType.Rows(0).Item("ShipTypeID")
                    Me.cboBoxTypes.SelectedValue = iType_ID
                Else
                    Me.cboBoxTypes.SelectedValue = 0
                End If

                Me.btnCreateBoxID.Visible = True : Me.btnReset.Visible = False
                Me.btnFillBoxWithWHBox.Visible = False

                Me.cboLocation.Focus()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "FormLoad", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub
        'Private Sub cbos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLocation.KeyUp, cboModel.KeyUp, cboBoxTypes.KeyUp
        '    Try
        '        If e.KeyCode = Keys.Enter Then

        '            If sender.name = "cboModels" Then
        '                If Me.cboModels.SelectedValue > 0 Then
        '                    'Populate open box
        '                    Me.PopulateOpenBoxs()
        '                    Me.cboBoxTypes.Focus()
        '                Else
        '                    Me.dbgPallets.DataSource = Nothing
        '                    Me.lblBoxName.Text = ""
        '                    Me.lblCount.Text = "0"
        '                    Me.txtDevSN.Text = ""
        '                    Me.lstDevices.DataSource = Nothing
        '                    Me.panelPallet.Visible = False
        '                    Me.btnCreateBoxID.Visible = False
        '                    Me.cboBoxTypes.Text = ""
        '                End If
        '            ElseIf sender.name.trim = "cboBoxTypes" Then
        '                If Not IsNothing(Me.cboBoxTypes.SelectedValue) AndAlso Me.cboBoxTypes.SelectedValue >= 0 AndAlso Me.cboModels.SelectedValue > 0 Then
        '                    Dim iShipType As Integer = Me.cboBoxTypes.SelectedValue
        '                    Me.PopulateOpenBoxs()
        '                    Me.cboBoxTypes.SelectedValue = iShipType
        '                    If IsNothing(Me.dbgPallets.DataSource) OrElse Me.dbgPallets.DataSource.Table.select("Pallet_SkuLen = '' AND Pallet_ShipType = " & iShipType).length = 0 Then Me.btnCreateBoxID.Visible = True Else Me.btnCreateBoxID.Visible = False
        '                Else
        '                    Me.btnCreateBoxID.Visible = False
        '                End If
        '            End If
        '        End If 'enter key
        '    Catch ex As Exception
        '        MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
        'End Sub

        Private Sub btnCreateBoxID_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreateBoxID.Click
            Dim iLoc_ID As Integer = 0
            Dim iModel_ID As Integer = 0
            Dim iType_ID As Integer = 0
            Dim strSW_Version As String = ""

            Try

                If IsNothing(Me.cboLocation.SelectedValue) OrElse Me.cboLocation.SelectedValue = 0 Then
                    MessageBox.Show("Please select WingTechATT location.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboLocation.Focus()
                ElseIf IsNothing(Me.cboModel.SelectedValue) OrElse Me.cboModel.SelectedValue = 0 Then
                    MessageBox.Show("Please select model.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboModel.Focus()
                ElseIf IsNothing(Me.cboBoxTypes.SelectedValue) OrElse Me.cboBoxTypes.SelectedValue = 9999 Then
                    MessageBox.Show("Please select shipbox type.", "Create Box ID", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Me.cboBoxTypes.Focus()
                Else
                    If Me.cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID _
AndAlso Not (Me.cboModel.SelectedValue = 5252 OrElse Me.cboModel.SelectedValue = 5251) Then
                        Dim strDefault As String = Me._objWingTechATT_BoxShip.GetLastSoftwareVersion(Me._iMenuCustID, Me.cboLocation.SelectedValue)
                        strSW_Version = InputBox("Enter SW Version Info if needed.", "SW Version", strDefault)
                        strSW_Version = strSW_Version.Trim

                        If strSW_Version.Length = 0 Then
                            Throw New Exception("Please enter a SW version info.")
                        End If
                    End If
                    Dim strLoc_id As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                    If rbCricket.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                    Me.cboLocation.Enabled = False : Me.cboModel.Enabled = False : Me.cboBoxTypes.Enabled = False
                    Me._iPallett_ID = Me._objWingTechATT_BoxShip.CreateBoxID(Me.cboModel.SelectedValue, Me.cboBoxTypes.SelectedValue, _
                                                                      Me.cboBoxTypes.DataSource.Table.Select("ShipTypeID = " & Me.cboBoxTypes.SelectedValue)(0)("ShipTypeSDesc"), _
                                                                      Me._iMenuCustID, strLoc_id, strSW_Version)
                    Me.PopulateOpenBoxs(Me._iPallett_ID)
                    Me.btnReset.Visible = True
                End If

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnCreateBoxID_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            Try
                Me.cboLocation.Enabled = True : Me.cboModel.Enabled = True : Me.cboBoxTypes.Enabled = True
                Me.btnCreateBoxID.Enabled = True : Me.btnCreateBoxID.Visible = True

                Me.PopulateOpenBoxs()

                '******************************
                'Reset Screen control properties.
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = 0
                Me.lstDevices.DataSource = Nothing
                Me.panelPallet.Visible = False
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "btnReset_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub
        Private Sub PopulateOpenBoxs(Optional ByVal iPallettID As Integer = 0)
            Dim dt As DataTable
            Dim strModelMotoSku As String

            Try
                Me.dbgPallets.DataSource = Nothing
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = "0"
                Me.panelPallet.Visible = False
                Me.btnCreateBoxID.Visible = False
                Dim strLoc_id As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                If rbCricket.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID


                dt = Me._objWingTechATT_BoxShip.GetWingTechATTOpenPallets(Me._iMenuCustID, strLoc_id)
                With Me.dbgPallets
                    .DataSource = dt.DefaultView
                    SetGridOpenBoxProperties(iPallettID)
                End With

            Catch ex As Exception
                MessageBox.Show(ex.ToString, "PopulateOpenBoxs", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub SetGridOpenBoxProperties(Optional ByVal iPallet_ID As Integer = 0)
            Dim iNumOfColumns As Integer = Me.dbgPallets.Columns.Count
            Dim i As Integer
            'Pallett_ID, Model_ID, Loc_ID, Pallet_ShipType, Pallett_QTY, Box Name, Location, Model

            With Me.dbgPallets
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
                .Splits(0).DisplayColumns(4).HeadingStyle.ForeColor = .ForeColor.Black

                'Set individual column data horizontal alignment
                .Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(1).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(2).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(3).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
                .Splits(0).DisplayColumns(4).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

                'Body Forecolor
                .Splits(0).DisplayColumns(0).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(1).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(2).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(3).Style.ForeColor = .ForeColor.Black
                .Splits(0).DisplayColumns(4).Style.ForeColor = .ForeColor.Black

                'Set Column Widths
                .Splits(0).DisplayColumns("Box Name").Width = 160
                .Splits(0).DisplayColumns("Location").Width = 100
                .Splits(0).DisplayColumns("Model").Width = 100

                'Make some columns invisible
                .Splits(0).DisplayColumns("Box Name").Visible = True
                .Splits(0).DisplayColumns("Location").Visible = True
                .Splits(0).DisplayColumns("Model").Visible = True

                .AlternatingRows = True

                For i = 0 To .RowCount - 1
                    If .Columns("Pallett_ID").CellValue(i) = iPallet_ID Then
                        Exit Sub
                    End If
                    .MoveNext()
                Next i
            End With
        End Sub

        Private Sub dbgPallets_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dbgPallets.Click

        End Sub

        Private Sub ProcessPalletSelection()
            Dim strShipType As String = ""
            Dim i As Integer = 0
            Dim booFound As Boolean = False

            Try
                Me.lblBERReason.Text = ""
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = "0"
                Me.txtDevSN.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.panelPallet.Visible = True
                Me.btnCreateBoxID.Visible = False
                Me.btnFillBoxWithWHBox.Visible = False

                If Me.dbgPallets.Columns.Count = 0 OrElse Me.dbgPallets.RowCount = 0 Then
                    Me.panelPallet.Visible = False
                    Exit Sub
                End If
                If Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Exit Sub
                End If

                Me.lblBoxName.Text = Me.dbgPallets.Columns("Box Name").Value.ToString

                '**********************************
                'Display BER Reason
                '**********************************
                'If Me.dbgPallets.Columns("Pallet_ShipType").Value = 1 Then
                '    Me.lblBERReason.Text = Me.dbgPallets.Columns("BER Reason").Value
                '    Me.lblBERReason.Visible = True
                'Else
                '    Me.lblBERReason.Text = ""
                Me.lblBERReason.Visible = False
                'End If
                '**********************************

                Select Case Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString
                    Case "0"    'REFURBISHED
                        Me.cboBoxTypes.SelectedValue = 0
                        'Me.cboFreqs.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_SkuLen").Value.ToString)
                        Me.Enabled = True
                    Case "1"    'BER
                        Me.cboBoxTypes.SelectedValue = 1
                        'Me.cboFreqs.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_SkuLen").Value.ToString)
                        Me.Enabled = True
                    Case "2"    'RUR
                        Me.cboBoxTypes.SelectedValue = 2
                        'Me.cboFreqs.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_SkuLen").Value.ToString)
                        Me.Enabled = True
                    Case Else
                        ' Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value.ToString)
                        ' Me.cboFreqs.SelectedValue = 0
                        'Me.cboFreqs.Enabled = False
                        '     If Me.cboBoxTypes.SelectedValue = 12 AndAlso Me._booAccessToFillBoxWithWHBox = True Then Me.btnFillBoxWithWHBox.Visible = True
                End Select

                Me.RefreshSNList()

                '*******************************************
                Me.txtDevSN.Focus()

            Catch ex As Exception
                Throw ex
            End Try
        End Sub

        Private Sub RefreshSNList()
            Dim dt1 As DataTable
            Dim iPallet_ID As Integer = 0
            Dim strPalletName As String = ""
            Dim strOEMCustomerClass As String = ""

            Try
                '************************
                'Validations
                iPallet_ID = CInt(Me.dbgPallets.Columns("Pallett_ID").Value.ToString)
                strPalletName = Me.dbgPallets.Columns("Box Name").Value.ToString.Trim

                If iPallet_ID = 0 Then
                    Throw New Exception("Box is not selected.")
                ElseIf strPalletName.Trim = "" Then
                    Throw New Exception("Box is not selected.")
                End If

                '*******************************************
                'Get all devices add put them in them in list box for a pallet

                dt1 = Me._objWingTechATT_BoxShip.GetAllSNsForPallet(iPallet_ID)
                Me.lstDevices.DataSource = dt1.DefaultView
                Me.lstDevices.ValueMember = dt1.Columns("device_id").ToString
                Me.lstDevices.DisplayMember = dt1.Columns("device_sn").ToString
                Me.lblBoxName.Text = strPalletName

                Me.lblOEMCustomerClass.Text = ""
                If dt1.Rows.Count > 0 Then
                    strOEMCustomerClass = Me._objWingTechATT_BoxShip.GetOEMCustomerClass(dt1.Rows(0).Item("Device_ID"), Me._iMenuCustID, dt1.Rows(0).Item("Loc_ID"))
                    Me.lblOEMCustomerClass.Text = strOEMCustomerClass.Trim
                End If

                '*******************************************
                Me.lblCount.Text = dt1.Rows.Count
            Catch ex As Exception
                Throw ex
            Finally
                PSS.Data.Buisness.Generic.DisposeDT(dt1)
                Me.txtDevSN.Focus()
            End Try
        End Sub

        Private Sub txtDevSN_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDevSN.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    If Me.txtDevSN.Text.Trim.Length > 0 Then Me.ProcessWingTechATTSN()
                    getPOnumber()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "txtDevSN_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub ProcessWingTechATTSN()
            Dim i As Integer = 0
            Dim isBillcodeSeedS As Boolean = False
            Dim strSN As String = Me.txtDevSN.Text.Trim.ToUpper
            Dim dtDevice, dtBill, dtFQA, dtRF, dtFlash, dtFlashManual As DataTable
            Dim booFailUnitHasPart As Boolean = False
            Dim strBERBillcodeID As String = ""
            Dim booRefreshBoxes As Boolean = False
            Dim iDevice_ID As Integer = 0
            Dim strItem As String = ""
            Dim dView As DataRowView
            Dim strDateTime As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
            Dim strOEMCustomerClass As String = ""
            Dim dtPO As New DataTable()
            Dim bIsSeedstock As Boolean
            'Dim strIMEITemp As String
            Dim tLocID As Integer
            Dim strLoc_id As String
            Dim dtSeedstock As New DataTable()

            Try
                '************************
                'Validations
                If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.txtDevSN.Text.Trim = "" Then
                    Exit Sub
                End If

                'check if device already scanned in the box
                For Each dView In Me.lstDevices.Items
                    strItem = dView.Item("Device_SN").ToString
                    If Trim(strItem).ToUpper = strSN.Trim.ToUpper Then
                        MsgBox("This device is already scanned in. Try another one.", MsgBoxStyle.Information, "Device Scan")
                        Me.txtDevSN.Text = ""
                        Me.txtDevSN.Focus()
                        Exit Sub
                    End If
                Next

                If Me._objWingTechATT_BoxShip.GetSwappedStatus(strSN.Trim.ToUpper, _iMenuCustID) > 0 Then
                    MsgBox("This device is already swapped, need to be moved into seedstock pool. Try another one.", MsgBoxStyle.Information, "Device Scan")
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                    Exit Sub
                End If

                '------------------Check if the order type is a seedstock or  ------------------------------------
                'two types seedstock devices: (1)devices directly from customer; (2) devices are repaired, closed, and moved to seedstock
                'the repaired device can be swapped with open seedstock
                bIsSeedstock = False
                dtSeedstock = Me._objWingTechATT_BoxShip.GettDeviceBill(strSN.Trim.ToUpper)
                If dtSeedstock.Rows.Count = 0 Then
                    MsgBox("The device doesn't have the Bill Information or need to be Swapped", MsgBoxStyle.Information, "Device Scan")
                    Me.txtDevSN.Text = ""
                    Me.txtDevSN.Focus()
                    Exit Sub
                ElseIf Me._objWingTechATT_BoxShip.GetAccount(strSN.Trim.ToUpper, _iMenuCustID) = 1 Then
                    Dim j As Integer

                    For j = 0 To dtSeedstock.Rows.Count - 1
                        If dtSeedstock.Rows(j)("BillCode_Id") = Me._objWingTechATT.WingTechATT_Swap_BillCode_ID Then
                            isBillcodeSeedS = True
                            Exit For
                        End If
                    Next

                    If Me.cboBoxTypes.SelectedValue = 0 And isBillcodeSeedS Then
                        bIsSeedstock = True
                    Else
                        MsgBox("This device must use REF Type", MsgBoxStyle.Information, "Device Scan")
                        Me.txtDevSN.Text = ""
                        Me.txtDevSN.Focus()
                        Exit Sub
                    End If

                End If
                '----------------- Check if the devices have the same PO Number for --------------------
                If Not cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
                    getPOnumber()
                    If lPO.Text <> "" Then
                        Dim iAccount As Integer = _objWingTechATT_BoxShip.GetAccount(Trim(txtDevSN.Text), _iMenuCustID) 'get the order Type of the device
                        Dim iDeviceId As Integer = _objWingTechATT_BoxShip.GetDeviceId(Trim(txtDevSN.Text))
                        Dim dtPO2 As DataTable = _objWingTechATT_BoxShip.GetPO(Trim(iDeviceId), iAccount)
                        If dtPO2.Rows(0)("ClaimNo") <> lPO.Text Then
                            MsgBox("This device belongs to a diferrent PO Number. Try another one.", MsgBoxStyle.Information, "Device Scan")
                            Me.txtDevSN.Text = ""
                            Me.txtDevSN.Focus()
                            Exit Sub
                        End If
                    Else
                    End If
                End If
                '***************************************************
                If Me.lstDevices.Items.Count > PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_MaxQtyInBox Then
                    Throw New Exception("Box can't contain more than " & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_MaxQtyInBox & " units.")
                End If

                '***************************************************
                If Generic.IsPalletClosed(CInt(Me.dbgPallets.Columns("Pallett_ID").Value)) = True Then
                    MsgBox("Box had been closed by another machine. Please refresh your screen.", MsgBoxStyle.Information, "Device Scan")
                    Exit Sub
                End If
                i = 0

                If lstDevices.Items.Count = 0 AndAlso Not rbCricket.Checked Then
                    strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                    'If rbCricket.Checked Then strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                    dtDevice = Me._objWingTechATT_BoxShip.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, strLoc_id)

                ElseIf rbCricket.Checked Then
                    strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
                    dtDevice = Me._objWingTechATT_BoxShip.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, strLoc_id)

                Else
                    strLoc_id = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID & "," & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
                    dtDevice = Me._objWingTechATT_BoxShip.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, strLoc_id)
                    '  tLocID = _objWingTechATT_BoxShip.GetLocID(strSN)
                    'dtDevice = Me._objWingTechATT_BoxShip.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, tLocID)
                    'dtDevice = Me._objWingTechATT_BoxShip.GetDeviceInfoInWIP(Me.txtDevSN.Text.Trim, CInt(Me.dbgPallets.Columns("Loc_ID").Value))
                End If



                If Not cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID AndAlso Not lblPO.Text = String.Empty AndAlso lstDevices.Items.Count > 0 Then
                    dtPO = Me._objWingTechATT_BoxShip.GetWingTechATTLocationsbyID(Me._iMenuCustID, Me.txtDevSN.Text.Trim)
                    If Not lblPO.Text.Trim = dtPO.Rows(0).Item("ClaimNo") Then
                        MsgBox("This device belongs to a diferrent PO Number. Try another one.", MsgBoxStyle.Information, "Device Scan")
                        Exit Sub
                    End If
                End If
                If dtDevice.Rows.Count > 1 Then
                    MsgBox("Duplicate device (WIP) found in the system. Please contact IT.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.SelectAll()
                    Exit Sub
                ElseIf dtDevice.Rows.Count = 0 Then
                    MsgBox("This device does not exist in the system, already ship or belong to a different customer or location.", MsgBoxStyle.Information, "Information")
                    Me.txtDevSN.SelectAll()
                    Exit Sub
                Else '1 row
                    'Check Bill, FQA, FR test, Flash, OEM Customer Class=======================================================================================


                    iDevice_ID = dtDevice.Rows(0).Item("Device_ID")

                    'DOA or not
                    If rbCricket.Checked And Not bIsSeedstock Then
                        strOEMCustomerClass = Me._objWingTechATT_BoxShip.GetOEMCustomerClass(iDevice_ID, Me._iMenuCustID, Me.cboLocation.SelectedValue)
                        If strOEMCustomerClass.Trim.Length = 0 Then
                            MessageBox.Show("OEM Customer Class can't be nothing. See IT.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDevSN.SelectAll()
                            Exit Sub
                        End If

                        If Me.lstDevices.Items.Count = 0 Then
                            Me.lblOEMCustomerClass.Text = strOEMCustomerClass.Trim
                        ElseIf Not strOEMCustomerClass.Trim.ToUpper = Me.lblOEMCustomerClass.Text.Trim.ToUpper Then
                            MessageBox.Show("This device is not belong to the OEM Customer Class " & Me.lblOEMCustomerClass.Text.Trim, Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDevSN.SelectAll()
                            Exit Sub
                        End If
                    End If

                    dtBill = Me._objWingTechATT_BoxShip.GetDeviceBillData(iDevice_ID)
                    If Not dtBill.Rows.Count > 0 Then
                        MessageBox.Show("The device has no bill data. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                        Me.txtDevSN.SelectAll()
                        Exit Sub
                    End If
                    If Me.cboBoxTypes.SelectedValue = 1 Then
                        Dim row As DataRow, bFoundBERBillCode As Boolean = False
                        For Each row In dtBill.Rows
                            If Convert.ToInt16(row("BillCode_ID")) = 1020 Then
                                bFoundBERBillCode = True : Exit For
                            End If
                        Next
                        If Not bFoundBERBillCode Then
                            MessageBox.Show("The device is not BER type.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDevSN.SelectAll()
                            Exit Sub
                        ElseIf bFoundBERBillCode AndAlso Not dtBill.Rows.Count = 1 Then
                            MessageBox.Show("The device is BER type, but has other bill codes. See IT.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDevSN.SelectAll()
                            Exit Sub
                        End If
                    End If

                    If Me.cboBoxTypes.SelectedValue = 2 Then
                        Dim row As DataRow, bFoundRURBillCode As Boolean = False
                        For Each row In dtBill.Rows
                            If Convert.ToInt16(row("BillCode_ID")) = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_RUR_BillCode_ID Or Convert.ToInt16(row("BillCode_ID")) = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_RUR_BillCode_ID2 Then
                                bFoundRURBillCode = True : Exit For
                            End If
                        Next
                        If Not bFoundRURBillCode Then
                            MessageBox.Show("The device is not RUR type.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDevSN.SelectAll()
                            Exit Sub
                        ElseIf bFoundRURBillCode AndAlso Not dtBill.Rows.Count = 1 Then
                            MessageBox.Show("The device is RUR type, but has other bill codes. See IT.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDevSN.SelectAll()
                            Exit Sub
                        End If
                    End If


                    If Me.cboBoxTypes.SelectedValue = 0 Then
                        If Not bIsSeedstock AndAlso Not dtDevice.Rows(0).Item("Model_ID") = Me._objWingTechATT.WingTechATT_SeedStock_Model Then
                            dtFQA = Me._objWingTechATT_BoxShip.GetDeviceFqaData(iDevice_ID)
                            If Not dtFQA.Rows.Count > 0 Then
                                MessageBox.Show("The device has no FQA test data. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            ElseIf dtFQA.Rows(0).IsNull("QCResult_ID") OrElse Not dtFQA.Rows(0).Item("QCResult_ID") = 1 Then
                                MessageBox.Show("The device didn't pass FQA test. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            End If
                            dtRF = Me._objWingTechATT_BoxShip.GetDeviceRfTestData(strSN)
                            If Not dtRF.Rows.Count > 0 Then
                                MessageBox.Show("The device either failed to pass Manual RF test or has no RF test. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            ElseIf dtRF.Rows(0).IsNull("TestTResult") OrElse Trim(dtRF.Rows(0).Item("TestTResult")).Length = 0 OrElse Not Trim(dtRF.Rows(0).Item("TestTResult")).ToUpper = "Pass".ToUpper Then
                                MessageBox.Show("The device didn't pass Manual RF test. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            End If

                            dtFlashManual = Me._objWingTechATT_BoxShip.GetDeviceFlashManual(strSN)
                            If Not dtFlashManual.Rows.Count > 0 Then
                                MessageBox.Show("The device either failed to pass Manual Flash or has no Flash data. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            ElseIf dtFlashManual.Rows(0).IsNull("TestTResult") OrElse Trim(dtFlashManual.Rows(0).Item("TestTResult")).Length = 0 OrElse Not Trim(dtFlashManual.Rows(0).Item("TestTResult")).ToUpper = "Pass".ToUpper Then
                                MessageBox.Show("The device didn't pass Manual Flash. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            End If
                            dtFlash = Me._objWingTechATT_BoxShip.GetDeviceFlashTestData(strSN)
                            If Not dtFlash.Rows.Count > 0 Then
                                MessageBox.Show("The device either failed to pass Flash or has no Flash data. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            ElseIf dtFlash.Rows(0).IsNull("TestTResult") OrElse Trim(dtFlash.Rows(0).Item("TestTResult")).Length = 0 OrElse Not Trim(dtFlash.Rows(0).Item("TestTResult")).ToUpper = "Pass".ToUpper Then
                                MessageBox.Show("The device didn't pass Flash. Can't ship it.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            End If
                            If getDateDiff(Trim(dtFlash.Rows(0).Item("TestDateTime")), Date.Now) > 55 Then
                                MessageBox.Show("The Flash File has more than 60 Days ,Please Flash it again .", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                                Me.txtDevSN.SelectAll()
                                Exit Sub
                            End If

                        End If

                    End If
                    If dtDevice.Rows(0).Item("Model_ID") = Me._objWingTechATT.WingTechATT_SeedStock_Model AndAlso _
                      Me.cboModel.SelectedValue = Me._objWingTechATT.WingTechATT_SeedBulk_Model Then
                        '   do no check for Model (DEMK4108 can be swapped with S690C)
                    Else
                        If Not dtDevice.Rows(0).Item("Model_ID") = Me.cboModel.SelectedValue Then
                            MessageBox.Show("Wrong model.", Me._strScreenName, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                            Me.txtDevSN.SelectAll()
                            Exit Sub
                        End If
                    End If
                    If Not IsDBNull(dtDevice.Rows(0)("Pallett_ID")) Then
                        MsgBox("This device already has assigned into a box.", MsgBoxStyle.Information, "Information")
                        Me.txtDevSN.Text = ""
                    Else
                        Me.Enabled = False
                        Cursor.Current = Cursors.WaitCursor

                        '***************************************
                        'Remove all part if Unit Pallett is BER
                        '***************************************
                        'If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 1 AndAlso booFailUnitHasPart = True Then
                        '    Me.RemoveAllParts(dtDevice.Rows(0)("Device_ID"))
                        'End If

                        '*****************************************
                        'Set pallett sku length
                        '*****************************************
                        'If CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value) = 1 Then
                        '    strBERBillcodeID = Me._objTFBuildShipPallet.GetBERBillcodeID(Convert.ToInt32(dtDevice.Rows(0)("Device_ID")))
                        '    If Me.lstDevices.Items.Count = 0 Then
                        '        If Me.dbgPallets.DataSource.Table.Select("Pallet_ShipType = 1 AND Model_ID = " & Me.dbgPallets.Columns("Model_ID").Value & " AND Pallet_SkuLen = '" & strBERBillcodeID & "'").length > 0 Then
                        '            MessageBox.Show("Please close all the open box(s) before start the new box.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '            Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                        '        End If
                        '        Me._objTFBuildShipPallet.SetPalletSkuLen(CInt(Me.dbgPallets.Columns("Pallett_id").Value), strBERBillcodeID)
                        '        booRefreshBoxes = True

                        '        'Disable this 08-27-2012
                        '        'ElseIf Me.lstDevices.Items.Count > 0 AndAlso Me.dbgPallets.Columns("Pallet_SkuLen").Value <> strBERBillcodeID.Trim Then
                        '        '    MessageBox.Show("BER reason does not match.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        '        '    Me.Enabled = True : Me.txtDevSN.SelectAll() : Me.txtDevSN.Focus() : Exit Sub
                        '    End If
                        'End If

                        '***************************************************
                        'if above all is fine then add it to the list and update the database
                        'i = PSS.Data.Production.Shipping.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value))
                        Me._objWingTechATT_BoxShip.AssignDeviceToPallet(dtDevice.Rows(0)("Device_ID"), CInt(Me.dbgPallets.Columns("Pallett_ID").Value), strDateTime)
                        '***************************************************


                        If booRefreshBoxes = True Then Me.PopulateOpenBoxs(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                        If Not rbCricket.Checked AndAlso Me.lstDevices.Items.Count = 1 Then
                            Dim iTempLoc_id As Integer
                            Dim dtLoc As New DataTable()
                            dtLoc = Me._objWingTechATT_BoxShip.GetWingTechATTLocationsbyID(_iMenuCustID, Me.txtDevSN.Text.Trim)
                            If dtLoc.Rows.Count = 1 Then
                                iTempLoc_id = (dtLoc.Rows(0)("Loc_ID"))
                                Me._objWingTechATT_BoxShip.UpdateWingTechATTPalletLocation(iTempLoc_id, CInt(Me.dbgPallets.Columns("Pallett_ID").Value))
                            End If
                        End If
                        Me.RefreshSNList()
                        Me.Enabled = True
                        Cursor.Current = Cursors.Default
                        Me.txtDevSN.Text = ""
                        Me.txtDevSN.Focus()
                    End If

                End If

            Catch ex As Exception
                MessageBox.Show("ProcessSN: " & ex.Message, "Device Scan", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Me.txtDevSN.Text = ""
                Me.txtDevSN.Focus()
            Finally
                Generic.DisposeDT(dtDevice)
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub
        Public Function getDateDiff(ByVal startDate As DateTime, ByVal EndDate As DateTime) As Integer
            Dim iTotalDays As Integer = 0
            iTotalDays = DateDiff(DateInterval.Day, startDate, EndDate) + 1
            Return iTotalDays
        End Function
        Private Sub getPOnumber()
            Dim strPO As String
            Dim j As Integer
            lPO.Text = ""
            For j = 0 To lstDevices.Items.Count - 1
                Dim iAccount As Integer = Me._objWingTechATT_BoxShip.GetAccount(Me.lstDevices.Items.Item(j)("Device_SN").ToString.Trim, Me._iMenuCustID)
                Dim iDeviceId As Integer = Me._objWingTechATT_BoxShip.GetDeviceId(Me.lstDevices.Items.Item(j)("Device_SN").ToString.Trim)
                Dim dtPO As DataTable = Me._objWingTechATT_BoxShip.GetPO(iDeviceId, iAccount)
                If Trim(dtPO.Rows(0)("ClaimNo")) <> String.Empty Then
                    strPO = dtPO.Rows(0)("ClaimNo")
                    lPO.Text = strPO
                    Exit For
                End If
            Next
        End Sub

        Private Sub btnCloseBox_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCloseBox.Click
            Dim i, iFailStation As Integer
            Dim strNextWrkStation As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_BuildProduce_WorkStation
            Dim iDeviceID As Integer = 0

            Try
                i = 0 : iFailStation = 0
                '************************
                'Validations
                If CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box name is not selected.")
                ElseIf Me.dbgPallets.Columns("Box Name").Value.ToString.Trim = "" Then
                    Throw New Exception("Box name is not selected.")
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    MessageBox.Show("This box is empty.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txtDevSN.Focus() : Exit Sub
                ElseIf Me.lstDevices.Items.Count > PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_MaxQtyInBox Then
                    MessageBox.Show("Box can't contain more than " & PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_MaxQtyInBox.ToString & " units.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.txtDevSN.Focus() : Exit Sub
                    'ElseIf Me.IsValidBoxTypeSelection = False Then
                    '    MessageBox.Show("Invalid Box type. Please select Box Name again.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Exit Sub
                ElseIf MessageBox.Show("Are you sure you want to close this box?", "Close Box", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                    Exit Sub
                End If

                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = Me._objWingTechATT_BoxShip.CloseWingTechATTPallet(Me._iMenuCustID, CInt(Me.dbgPallets.Columns("Pallett_ID").Value), _
                                                        Me.dbgPallets.Columns("Box Name").Value, Me.lstDevices.Items.Count, _
                                                        0, 0, )
                If i = 0 Then
                    Throw New Exception("Box has not closed yet due to an error. Please contact IT.")
                End If

                ' Me.cboBoxTypes.SelectedValue = CInt(Me.dbgPallets.Columns("Pallet_ShipType").Value)
                'PSS.Data.Production.Shipping.PrintPalletLicensePlate(Me.dbgPallets.Columns("Box Name").Value, Me.dbgPallets.Columns("Model_ID").Value, Me.cboBoxTypes.Text, Me.lstDevices.Items.Count, 3)

                '************************
                'Push units to next station
                '************************
                Generic.SetTcelloptWorkStationForPallet(strNextWrkStation, CInt(Me.dbgPallets.Columns("Pallett_ID").Value), Core.ApplicationUser.IDuser, Me._strScreenName, Me.Name)

                '************************
                'Print 4 x 6 Box Label
                '************************
                If CInt(Me.dbgPallets.Columns("Loc_ID").Value) = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID _
                   AndAlso Me.cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then

                    Me._objWingTechATT_BoxShip.PrintBoxLabel(CInt(Me.dbgPallets.Columns("Pallett_id").Value))

                ElseIf CInt(Me.dbgPallets.Columns("Loc_ID").Value) = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID _
                       AndAlso Me.cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID Then

                    Me._objWingTechATT_BoxShip.Print_AttCTDI_BoxLabel(CInt(Me.dbgPallets.Columns("Pallett_id").Value))

                Else
                    MessageBox.Show("Location ID mismatched! The pallet has been closed, but failed to print the label.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                'Refresh Pallet (Box) 
                Me.PopulateOpenBoxs()

                '******************************
                'Reset Screen control properties.
                Me.lblBoxName.Text = ""
                Me.lblCount.Text = 0
                Me.lblOEMCustomerClass.Text = ""
                Me.lstDevices.DataSource = Nothing
                Me.panelPallet.Visible = False
                '******************************
            Catch ex As Exception
                MessageBox.Show(ex.Message, "btnCloseBox_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try

        End Sub


        Private Sub cbos_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboLocation.KeyUp, cboModel.KeyUp, cboBoxTypes.KeyUp
            Try
                If e.KeyCode = Keys.Enter Then
                    'Me.btnFillBoxWithWHBox.Visible = False
                    'If sender.name = "cboModels" Then
                    '    If Me.cboModels.SelectedValue > 0 Then
                    '        'Populate open box
                    '        Me.PopulateOpenBoxs()
                    '        Me.cboBoxTypes.Focus()
                    '    Else
                    '        Me.dbgPallets.DataSource = Nothing
                    '        Me.lblBoxName.Text = ""
                    '        Me.lblCount.Text = "0"
                    '        Me.txtDevSN.Text = ""
                    '        Me.lstDevices.DataSource = Nothing
                    '        Me.panelPallet.Visible = False
                    '        Me.btnCreateBoxID.Visible = False
                    '        Me.cboBoxTypes.Text = ""
                    '    End If
                    'ElseIf sender.name.trim = "cboBoxTypes" Then
                    '    If Not IsNothing(Me.cboBoxTypes.SelectedValue) AndAlso Me.cboBoxTypes.SelectedValue >= 0 AndAlso Me.cboModels.SelectedValue > 0 Then
                    '        Dim iShipType As Integer = Me.cboBoxTypes.SelectedValue
                    '        Me.PopulateOpenBoxs()
                    '        Me.cboBoxTypes.SelectedValue = iShipType
                    '        If IsNothing(Me.dbgPallets.DataSource) OrElse Me.dbgPallets.DataSource.Table.select("Pallet_SkuLen = '' AND Pallet_ShipType = " & iShipType).length = 0 Then Me.btnCreateBoxID.Visible = True Else Me.btnCreateBoxID.Visible = False
                    '    Else
                    '        Me.btnCreateBoxID.Visible = False
                    '    End If
                    'End If
                    If Me.cboLocation.SelectedValue > 0 AndAlso Me.cboModel.SelectedValue > 0 _
                       AndAlso Me.cboBoxTypes.SelectedValue >= 0 AndAlso Me.cboBoxTypes.SelectedValue <> 9999 Then
                        Me.PopulateOpenBoxs()
                        Me.btnCreateBoxID.Visible = True
                    End If
                End If 'enter key
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "cbos_KeyUp", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Private Sub btnRemoveSN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveSN.Click
            Dim strSN As String = ""
            Dim i As Integer = 0
            Dim iDeviceID As Integer = 0

            Try
                '************************
                'Validations
                If Me.dbgPallets.RowCount = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
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

                    i = Me._objWingTechATT_BoxShip.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), iDeviceID)
                    If i = 0 Then
                        Throw New Exception("S/N entered was not removed from Box.")
                    End If

                    Me.RefreshSNList()

                    '*****************************************
                    'Set pallett sku length
                    '*****************************************
                    If Me.lstDevices.Items.Count = 0 Then
                        ' Me._objTFBuildShipPallet.SetPalletSkuLen(CInt(Me.dbgPallets.Columns("Pallett_id").Value), "")
                        Me.PopulateOpenBoxs(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                    End If
                    '*****************************************
                Else
                    Throw New Exception("S/N was not listed.")
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear S/N", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.txtDevSN.Focus()
            End Try
        End Sub

        Private Sub btnRemoveAllSNs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveAllSNs.Click
            Dim str_sn As String = ""
            Dim i As Integer = 0

            If MessageBox.Show("Are you sure you want to remove all devices from this Box?", "Clear All S/Ns", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If

            Try
                '************************
                'Validations
                If Me.dbgPallets.RowCount = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf CInt(Me.dbgPallets.Columns("Pallett_id").Value) = 0 Then
                    Throw New Exception("Box Name is not selected.")
                ElseIf Me.lstDevices.Items.Count = 0 Then
                    'Throw New Exception("No IMEI in the list to remove.")
                    Exit Sub
                End If

                '************************
                Me.Enabled = False
                Cursor.Current = Cursors.WaitCursor

                i = PSS.Data.Production.Shipping.RemoveSNfromPallet(CInt(Me.dbgPallets.Columns("Pallett_id").Value), )

                If i = 0 Then
                    Throw New Exception("No SNs were removed from box.")
                End If

                RefreshSNList()
                'Me.LoadCellProductionNumbers()
                'Me.LoadWeeklyCellProductionNumbers()

                '*****************************************
                'Set pallett sku length
                '*****************************************
                If Me.lstDevices.Items.Count = 0 Then
                    ' Me._objTFBuildShipPallet.SetPalletSkuLen(CInt(Me.dbgPallets.Columns("Pallett_id").Value), "")
                    Me.PopulateOpenBoxs(CInt(Me.dbgPallets.Columns("Pallett_id").Value))
                End If
                '*****************************************
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Clear All SNs", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
                Me.txtDevSN.Focus()
            End Try
        End Sub

        Private Sub btnDeleteBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBox.Click
            Dim i As Integer = 0

            Try
                If (Me.dbgPallets.RowCount = 0) Then
                    MsgBox("No box available ", MsgBoxStyle.Information, "Delete Box")
                    Exit Sub
                End If

                If CInt(Me.dbgPallets.Columns("Pallett_ID").Value) = 0 Then
                    Exit Sub
                End If

                If MessageBox.Show("Are you sure you want to delete selected Box?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    Me.Enabled = False
                    Cursor.Current = Cursors.WaitCursor

                    i = PSS.Data.Production.Shipping.DeleteEmptyPallet(CInt(Me.dbgPallets.Columns("Pallett_ID").Value), PSS.Core.ApplicationUser.IDuser)
                    MessageBox.Show("Box has been deleted.")

                    Me.PopulateOpenBoxs()
                    Me.lstDevices.DataSource = Nothing
                    Me.lblBoxName.Text = ""
                    Me.lblCount.Text = ""
                    Me.panelPallet.Visible = False

                    Me.btnCreateBoxID.Enabled = True : Me.btnCreateBoxID.Visible = True
                End If

            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            Finally
                Me.Enabled = True
                Cursor.Current = Cursors.Default
            End Try
        End Sub

        Private Sub btnReopenBox_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReopenBox.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            'Dim strGroupChar As String = Me._iMachineCC_GrpID.ToString
            Dim dt As DataTable
            Dim strCurrentStation As String = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_FQA_WorkStation

            Try
                '************************
                strPallet = InputBox("Enter Box ID.", "Reopen Box")
                strPallet = strPallet.Trim

                If strPallet.Length = 0 Then
                    Throw New Exception("Please enter a Box ID if you want to re-open it.")
                End If

                'Refresh open box list
                Me.PopulateOpenBoxs()

                dt = Me._objWingTechATT_BoxShip.GetWingTechATTPallettData(strPallet, Me._iMenuCustID)
                If dt.Rows.Count = 0 Then
                    MessageBox.Show("Box does not exist in the system or has been removed from the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows.Count > 1 Then
                    MessageBox.Show("Box name existed more than one in the system. Please contact IT.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsDBNull(dt.Rows(0)("Pallett_ShipDate")) Then
                    MessageBox.Show("Box has been dock-shipped. Not allow to reopen.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf dt.Rows(0)("Pallett_ReadyToShipFlg") = 0 Then
                    MessageBox.Show("Box is already open.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf Not IsNothing(Me.dbgPallets.DataSource) AndAlso Me.dbgPallets.RowCount > 0 AndAlso _
                       Me.dbgPallets.DataSource.Table.Select("Model_ID = " & dt.Rows(0)("Model_ID") & " AND Pallet_ShipType = " & dt.Rows(0)("Pallet_ShipType")).Length > 0 Then
                    MessageBox.Show("There is an open box in the list.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Else
                    i = Me._objWingTechATT_BoxShip.ReopenWingTechATTBoxByResetting(dt.Rows(0)("Pallett_ID"), strCurrentStation)
                    If i = 0 Then
                        Throw New Exception("Box was not reopened.")
                    End If

                    Me.cboModel.SelectedValue = dt.Rows(0)("Model_ID")
                    Me.cboBoxTypes.SelectedValue = dt.Rows(0)("Pallet_ShipType")

                    'Refresh Pallet( Box )
                    Me.PopulateOpenBoxs(dt.Rows(0)("Pallett_ID"))

                    '************************
                    Me.lstDevices.DataSource = Nothing
                    Me.lblCount.Text = "0"
                    Me.lblBoxName.Text = ""
                    Me.lblOEMCustomerClass.Text = ""
                    Me.panelPallet.Visible = False
                    '************************
                    Me.txtDevSN.Focus()
                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Reopen Box.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            Finally
                Generic.DisposeDT(dt)
            End Try
        End Sub

        Private Sub dbgPallets_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dbgPallets.MouseUp

            Try
                Me.ProcessPalletSelection()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
            btnCreateBoxID.Visible = True
            btnReset.Visible = True
            cboModel.SelectedValue = Me.dbgPallets.Columns("Model_id").Value()
            cboLocation.SelectedValue = Me.dbgPallets.Columns("loc_id").Value()
            If Me.dbgPallets.Columns("loc_id").Value() = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then
                rbCricket.Checked = True
                rbATT.Checked = False
            Else
                rbCricket.Checked = False
                rbATT.Checked = True
            End If
            getPOnumber()
        End Sub

        Private Sub btnReprintBoxLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprintBoxLabel.Click
            Dim strPallet As String = ""
            Dim i As Integer = 0
            Dim iIsOpenPallet As Boolean
            Dim strPalletId As String
            Dim dtTempClosepallet As New DataTable()

            Try
                strPallet = InputBox("Enter Box ID.", "Reprint the Label").ToString
                strPallet = strPallet.Trim
                dtTempClosepallet = Me._objWingTechATT_BoxShip.CheckOpenPallet(strPallet)
                If dtTempClosepallet.Rows.Count <> 0 Then
                    strPalletId = dtTempClosepallet.Rows(0)("Pallett_id")
                    If CInt(dtTempClosepallet.Rows(0)("Loc_id")) = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID Then

                        Me._objWingTechATT_BoxShip.PrintBoxLabel(CInt(strPalletId))

                    ElseIf CInt(dtTempClosepallet.Rows(0)("Loc_id")) = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID Then

                        Me._objWingTechATT_BoxShip.Print_AttCTDI_BoxLabel(CInt(strPalletId))

                    Else
                        MessageBox.Show("Location ID mismatched! The pallet has been closed, but failed to print the label.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Box must be Closed first or Doesn't Exist ,failed to print the label.", "Close Box", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "dbgPallets_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End Try
        End Sub

        Private Sub rbCricket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCricket.CheckedChanged
            If rbCricket.Checked = True Then
                Me.cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID
            Else
                Me.cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID
            End If
            Me.PopulateOpenBoxs(Me._iPallett_ID)
            'Me._objWingTechATT_BoxShip.GetWingTechATTOpenPallets(Me._iMenuCustID, PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCricket_LOC_ID)
        End Sub

        Private Sub rbATT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbATT.CheckedChanged
            'Dim strIME As String = String.Empty
            'Dim dtLoc As New DataTable()
            'If rbATT.Checked = True Then
            '    strIME = InputBox("Scan the First Device.", "Create Box")
            '    strIME = strIME.Trim
            '    dtLoc = Me._objWingTechATT_BoxShip.GetWingTechATTLocationsbyID(_iMenuCustID, strIME)
            '    If strIME.Length = 0 Then
            '        Throw New Exception("Please scan the Device if you want to create a Box.")
            '    End If
            '    If dtLoc.Rows.Count > 0 Then
            '        If dtLoc.Rows(0).Item("Loc_ID") = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID Then
            '            Me.cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttCTDI_LOC_ID
            '        ElseIf dtLoc.Rows(0).Item("Loc_ID") = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID Then
            '            Me.cboLocation.SelectedValue = PSS.Data.Buisness.WingTechATT.WingTechATT.WingTechATT_AttFedEx_LOC_ID
            '        End If
            '    Else
            '        MessageBox.Show("Location ID mismatched!", "Scan Device Serial Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    End If
            'End If
        End Sub
        Private Sub lstDevices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDevices.SelectedIndexChanged
            getPOnumber()
        End Sub

        Private Sub txtDevSN_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDevSN.TextChanged

        End Sub
    End Class
End Namespace